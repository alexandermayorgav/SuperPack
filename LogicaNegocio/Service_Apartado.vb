Imports AccesoDatos
Imports System.Text
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Apartado

    Public Function insertar(ByVal apartado As Apartado, ByVal objab As AbonoApartado, ByVal efectivo As Decimal, Optional ByVal listaVales As List(Of Vales) = Nothing, Optional ByVal listaTarj As List(Of Tarjeta) = Nothing)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()
            Dim insert As String = "INSERT INTO APARTADO " _
            & "(ID_CLIENTE,ID_USUARIO,CODIGO_BARRAS,CANTIDAD,MONTO,FECHA_APARTADO,ENTREGADO,DEVUELTO) " _
            & "VALUES (@id_c,@id_us,@codigo,@cant,@monto,@fecha_ap,0,0) RETURNING ID_APARTADO"

            db.CrearComando(insert, CommandType.Text)
            db.AgregarParametro("@id_c", apartado.IdCliente)
            db.AgregarParametro("@id_us", apartado.IdUsuario)
            db.AgregarParametro("@codigo", apartado.CodigoBarras)
            db.AgregarParametro("@cant", apartado.Cantidad)
            db.AgregarParametro("@monto", apartado.Monto)
            db.AgregarParametro("@fecha_ap", apartado.FechaApartado)

            apartado.IdApartado = db.EjecutarEscalar
            Dim sProd As New Service_Producto
            Dim producto As Producto = sProd.Obtener(apartado.CodigoBarras)
            ActualizaAlmacen(db, apartado, producto.Id, "select existencia from producto where id_producto=@prod")

            Dim sAb As New Service_AbonoAp
            objab.IdApartado = apartado.IdApartado
            sAb.insertar(db, objab)

            Dim SCaja As New Service_Caja
            Dim SVale As New Service_Vale

            If Not listaVales Is Nothing Then
                If listaVales.Count > 0 Then
                    For Each item As Vales In listaVales
                        SCaja.agregarEntrada(db, item.MontoUsar, apartado.FechaApartado, "ABONO APARTADO/FOLIO: " & item.Folio, objab.IdCaja, "Vale")
                        item.MontoActual = item.MontoRestante
                    Next
                    For Each item As Vales In listaVales
                        SVale.DescontarVale(item)
                    Next
                End If
            End If

            If Not listaTarj Is Nothing Then
                If listaTarj.Count > 0 Then
                    For Each itemT As Tarjeta In listaTarj
                        SCaja.agregarEntrada(db, itemT.Monto, apartado.FechaApartado, "ABONO APARTADO/NO.OPERACION:" & itemT.NumeroOperacion, objab.IdCaja, "Tarjeta")
                    Next
                End If
            End If

            If efectivo > 0 Then
                SCaja.agregarEntrada(db, efectivo, apartado.FechaApartado, "Abono Apartado, Folio: " & apartado.IdApartado, objab.IdCaja, "Efectivo")
            End If

            db.ConfirmarTransaccion()
        Catch ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos. (Apartado)")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar el apartado. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
        Return apartado.IdApartado
    End Function

    Public Function obtener(ByVal id_ap As Integer) As Apartado
        Dim objAp As Apartado = Nothing
        Dim db As BaseDatos = Nothing
        Dim row As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim getC As String = "SELECT * FROM APARTADO WHERE ID_APARTADO=@id_apartado"
            db.CrearComando(getC, CommandType.Text)

            db.AgregarParametro("@id_apartado", id_ap)
            row = db.EjecutarConsulta()

            If row.Read Then
                Try
                    objAp = New Apartado(row("id_apartado"), row("id_cliente"), row("id_usuario"), row("codigo_barras"), row("cantidad"), row("monto"), row("fecha_apartado"), row("fecha_entrega"), row("entregado"), row("devuelto"))

                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden (Apartado).", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No existe.")
            End If

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Apartado)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el apartado. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
        Return objAp
    End Function
    Public Function obtenerTodos(ByVal id_c As Integer) As List(Of Apartado)
        Dim db As BaseDatos = Nothing
        Dim rows As FbDataReader = Nothing
        Dim apartados As List(Of Apartado) = Nothing
        Try
            db = New BaseDatos
            apartados = New List(Of Apartado)
            db.Conectar()
            Dim getCs As String = "SELECT APARTADO.ID_APARTADO, APARTADO.MONTO, " _
            & "APARTADO.FECHA_APARTADO, PRODUCTO.DESCRIPCION as DESCRIPCION " _
            & "FROM APARTADO INNER JOIN PRODUCTO ON APARTADO.CODIGO_BARRAS = PRODUCTO.CODIGO_CLAVE " _
            & "WHERE APARTADO.ID_CLIENTE=@id_cliente"

            db.CrearComando(getCs, CommandType.Text)
            db.AgregarParametro("@id_cliente", id_c)

            rows = db.EjecutarConsulta
            Dim idAp = rows.GetOrdinal("ID_APARTADO")
            Dim monto = rows.GetOrdinal("MONTO")
            Dim fechaAp = rows.GetOrdinal("FECHA_APARTADO")
            Dim descripcion = rows.GetOrdinal("DESCRIPCION")

            Dim valores(rows.FieldCount) As Object
            While rows.Read
                Try
                    rows.GetValues(valores)
                    Dim objAp As New Apartado(valores(idAp), valores(monto), valores(fechaAp), valores(descripcion))
                    apartados.Add(objAp)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden (Apartado).", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET", Ex)
                End Try

            End While
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Apartado)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener la lista de apartados. " + Ex.Message)
        Finally
            rows.Close()
            db.Desconectar()
        End Try
        Return apartados
    End Function
    Public Sub cancelar(ByVal apartado As Apartado)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()
            Dim update As String = "UPDATE APARTADO SET " _
            & "DEVUELTO=1" _
            & "WHERE ID_APARTADO=@idap"

            db.CrearComando(update, CommandType.Text)
            db.AgregarParametro("@idap", apartado.IdApartado)
            db.EjecutarComando()

            Dim sProd As New Service_Producto
            Dim producto As Producto = sProd.Obtener(apartado.CodigoBarras)
            devuelveAAlmacen(db, apartado, producto.Id, "select existencia from producto where id_producto=@prod")

            db.ConfirmarTransaccion()
        Catch ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos. (Apartado)")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al cancelar el apartado. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Sub entregar(ByVal abono As AbonoApartado, ByVal id_caja As Integer, ByVal efect As Decimal, ByVal listarg As List(Of Tarjeta), ByVal listv As List(Of Vales))
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()
            Dim update As String = "UPDATE APARTADO SET " _
            & "ENTREGADO=1" _
            & "WHERE ID_APARTADO=@idap"
            db.CrearComando(update, CommandType.Text)
            db.AgregarParametro("@idap", abono.IdApartado)
            db.EjecutarComando()

            Dim insert As String = "INSERT INTO ABONO_APARTADO " _
           & "(ID_APARTADO,FECHA_ABONO,ID_CAJA,ID_USUARIO,CANTIDAD) " _
           & "VALUES (@idap,@fechaab,@idc,@idus,@cant)"

            db.CrearComando(insert, CommandType.Text)
            db.AgregarParametro("@idap", abono.IdApartado)
            db.AgregarParametro("@fechaab", abono.Fecha_Abono)
            db.AgregarParametro("@idc", abono.IdCaja)
            db.AgregarParametro("@idus", abono.IdUsuario)
            db.AgregarParametro("@cant", abono.Cantidad_Abono)
            db.EjecutarComando()
            If efect > 0 Then
                Dim sqlCaja = "INSERT INTO caja_detalle" _
           & "(id_caja,fecha,monto,concepto,tipo_pago)" _
           & "VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago)"
                db.CrearComando(sqlCaja, CommandType.Text)
                db.AgregarParametro("@id_caja", abono.IdCaja)
                db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(abono.Fecha_Abono))
                db.AgregarParametro("@monto", efect)
                db.AgregarParametro("@concepto", "Abono Apartado, Folio: " & abono.IdApartado)
                db.AgregarParametro("@tipo_pago", "Efectivo")
                db.EjecutarComando()
            End If

            If Not listarg Is Nothing Then
                For Each tar As Tarjeta In listarg
                    Dim sqlCaja = "INSERT INTO caja_detalle" _
           & "(id_caja,fecha,monto,concepto,tipo_pago)" _
           & "VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago)"
                    db.CrearComando(sqlCaja, CommandType.Text)
                    db.AgregarParametro("@id_caja", abono.IdCaja)
                    db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(abono.Fecha_Abono))
                    db.AgregarParametro("@monto", tar.Monto)
                    db.AgregarParametro("@concepto", "Abono Apartado, Folio: " & abono.IdApartado & "/No.Op: " & tar.NumeroOperacion)
                    db.AgregarParametro("@tipo_pago", "Tarjeta")
                    db.EjecutarComando()
                Next
            End If

            If Not listv Is Nothing Then
                For Each vale As Vales In listv
                    Dim sqlCaja = "INSERT INTO caja_detalle" _
           & "(id_caja,fecha,monto,concepto,tipo_pago)" _
           & "VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago)"
                    db.CrearComando(sqlCaja, CommandType.Text)
                    db.AgregarParametro("@id_caja", abono.IdCaja)
                    db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(abono.Fecha_Abono))
                    db.AgregarParametro("@monto", vale.MontoUsar)
                    db.AgregarParametro("@concepto", "Abono Apartado, Folio: " & abono.IdApartado & "/Folio V:" & vale.Folio)
                    db.AgregarParametro("@tipo_pago", "Vale")
                    db.EjecutarComando()
                Next

                Dim SVale As New Service_Vale

                If listv.Count > 0 Then
                    For Each item As Vales In listv
                        item.MontoActual = item.MontoRestante
                        SVale.DescontarVale(item)
                    Next
                End If
            End If

            db.ConfirmarTransaccion()
        Catch ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos. (Apartado)")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al cancelar el apartado. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
    Public Sub ActualizaAlmacen(ByRef db As BaseDatos, ByRef item As Apartado, ByVal id As Integer, ByVal sql As String)

        db.CrearComando(sql, CommandType.Text)
        db.AgregarParametro("@prod", id)
        Dim lee As FbDataReader
        Dim existenciaactual As Integer
        lee = db.EjecutarConsulta

        If lee.Read Then
            existenciaactual = lee("existencia")
        End If
        lee.Close()

        db.CrearComando("update producto set existencia=@existencia where id_producto=@idprodu", CommandType.Text)
        db.AgregarParametro("@existencia", existenciaactual - item.Cantidad)
        db.AgregarParametro("@idprodu", id)
        db.EjecutarComando()
    End Sub

    Public Sub devuelveAAlmacen(ByRef db As BaseDatos, ByRef item As Apartado, ByVal id As Integer, ByVal sql As String)

        db.CrearComando(sql, CommandType.Text)
        db.AgregarParametro("@prod", id)
        Dim lee As FbDataReader
        Dim existenciaactual As Integer
        lee = db.EjecutarConsulta

        If lee.Read Then
            existenciaactual = lee("existencia")
        End If
        lee.Close()

        db.CrearComando("update producto set existencia=@existencia where id_producto=@idprodu", CommandType.Text)
        db.AgregarParametro("@existencia", existenciaactual + item.Cantidad)
        db.AgregarParametro("@idprodu", id)
        db.EjecutarComando()
    End Sub

End Class
