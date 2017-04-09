Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Imports System.Text
Public Class Service_AbonoAp
    Public Sub insertar(ByVal db As BaseDatos, ByVal abono As AbonoApartado)
        'Dim db As BaseDatos = Nothing
        Try
            'db = New BaseDatos
            'db.Conectar()
            'db.ComenzarTransaccion()
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

            ' Dim sqlCaja = "INSERT INTO caja_detalle" _
            '& "(id_caja,fecha,monto,concepto,tipo_pago)" _
            '& "VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago)"
            ' db.CrearComando(sqlCaja, CommandType.Text)
            ' db.AgregarParametro("@id_caja", abono.IdCaja)
            ' db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(abono.Fecha_Abono))
            ' db.AgregarParametro("@monto", abono.Cantidad_Abono)
            ' db.AgregarParametro("@concepto", "Abono Apartado, Folio: " & abono.IdApartado)
            ' db.AgregarParametro("@tipo_pago", "Efectivo")
            ' db.EjecutarComando()


            ' db.ConfirmarTransaccion()
        Catch ex As BaseDatosException
            'db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos. (Abono Apartado)")
        Catch Ex As ReglasNegocioException
            'db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar el abono del apartado. " + Ex.Message)
        End Try
    End Sub

    Public Sub insertarDesdeab(ByVal abono As AbonoApartado, ByVal listarg As List(Of Tarjeta), ByVal listv As List(Of Vales), ByVal efect As Decimal)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()
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
            Throw New ReglasNegocioException("Error al acceder a la base de datos. (Abono Apartado)")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar el abono del apartado. " + Ex.Message)
        Finally

            db.Desconectar()
        End Try
    End Sub

    Public Function obtenerTodos(ByVal id_ap As Integer) As List(Of AbonoApartado)
        Dim db As BaseDatos = Nothing
        Dim rows As FbDataReader = Nothing
        Dim abonos As List(Of AbonoApartado) = Nothing
        Try
            db = New BaseDatos
            abonos = New List(Of AbonoApartado)
            db.Conectar()
            Dim getCs As String = "SELECT ABONO_APARTADO.ID_ABONOAP,ABONO_APARTADO.ID_APARTADO," _
            & "ABONO_APARTADO.FECHA_ABONO, ABONO_APARTADO.ID_CAJA,ABONO_APARTADO.ID_USUARIO," _
            & "ABONO_APARTADO.CANTIDAD,USUARIOS.USUARIO " _
            & "FROM ABONO_APARTADO INNER JOIN USUARIOS ON ABONO_APARTADO.ID_USUARIO=USUARIOS.ID_USUARIO " _
            & "WHERE ID_APARTADO=@id_apartado"
            db.CrearComando(getCs, CommandType.Text)
            db.AgregarParametro("@id_apartado", id_ap)

            rows = db.EjecutarConsulta
            Dim idAAp = rows.GetOrdinal("ID_ABONOAP")
            Dim idAp = rows.GetOrdinal("ID_APARTADO")
            Dim fecha = rows.GetOrdinal("FECHA_ABONO")
            Dim idC = rows.GetOrdinal("ID_CAJA")
            Dim idUs = rows.GetOrdinal("ID_USUARIO")
            Dim cantidad = rows.GetOrdinal("CANTIDAD")
            Dim nombreUs = rows.GetOrdinal("USUARIO")


            Dim valores(rows.FieldCount) As Object
            While rows.Read
                Try
                    rows.GetValues(valores)
                    Dim objAb As New AbonoApartado(valores(idAAp), valores(idAp), valores(fecha), valores(idC), valores(idUs), valores(cantidad), valores(nombreUs))
                    abonos.Add(objAb)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden (Personal).", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET", Ex)
                End Try

            End While
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Personal)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener la lista de personal. " + Ex.Message)
        Finally
            rows.Close()
            db.Desconectar()
        End Try
        Return abonos
    End Function
End Class
