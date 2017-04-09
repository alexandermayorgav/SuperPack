Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Salida
    Dim _datos As BaseDatos = Nothing
    Public Sub IniciarBusqueda()
        _datos = New BaseDatos
        _datos.Conectar()
    End Sub
    Public Sub FinalizarBusqueda()
        _datos.Desconectar()
        _datos.Dispose()
    End Sub
    Public Function insertar(ByVal salida As CSalida)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            Dim Sql As String
            Sql = "INSERT INTO SALIDA" _
           & "(ID_USUARIO,FECHA_SALIDA)" _
           & " VALUES(@idusu,@fecha) RETURNING ID_SALIDA"

            Dim fecha As Date = Utils.ObtenerFechaHora(salida.Fecha)
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@idusu", salida.Usuario)
            db.AgregarParametro("@fecha", fecha)
            salida.Id = db.EjecutarEscalar()

            Dim sqldetalle As String

            sqldetalle = "INSERT INTO SALIDA_DET" _
           & "(ID_SALIDA,ID_PRODUCTO,CANTIDAD,COSTO)" _
           & " VALUES(@idsalida,@idproducto,@cantidad,@costo)"

            For Each item As CSalidaDetalle In salida._salidaitems
                db.CrearComando(sqldetalle, CommandType.Text)
                db.AgregarParametro("@idsalida", salida.Id)
                db.AgregarParametro("@idproducto", item.Producto.Id)
                db.AgregarParametro("@cantidad", item.Cantidad)
                db.AgregarParametro("@costo", item.Costo)
                db.EjecutarComando()

                ActualizaAlmacen(db, item, "select existencia from producto where id_producto=@prod")

            Next
            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar la salida. " + Ex.Message)
            MsgBox(Err.Number)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return salida.Id
    End Function
    Private Sub ActualizaAlmacen(ByRef db As BaseDatos, ByRef item As CSalidaDetalle, ByVal sql As String)
        db.CrearComando(sql, CommandType.Text)
        db.AgregarParametro("@prod", item.Producto.Id)
        Dim lee As FbDataReader
        Dim existenciaactual As Integer

        lee = db.EjecutarConsulta

        If lee.Read Then
            existenciaactual = lee("existencia")
        End If

        lee.Close()

        db.CrearComando("update producto set existencia=@existencia where id_producto=@idprodu", CommandType.Text)
        db.AgregarParametro("@existencia", existenciaactual - item.Cantidad)
        db.AgregarParametro("@idprodu", item.Producto.Id)
        db.EjecutarComando()
    End Sub
    Public Function ObtenerSalida(ByVal folio As Integer) As CSalida
        Dim salidaexistente As CSalida = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim Sql As String = "Select * from SALIDA where ID_SALIDA=@idsalida"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@idsalida", folio)
            datos = db.EjecutarConsulta()

            Dim values(datos.FieldCount) As Object

            Dim id_salida = datos.GetOrdinal("ID_SALIDA")
            Dim id_usuario = datos.GetOrdinal("ID_USUARIO")
            Dim fecha = datos.GetOrdinal("FECHA_SALIDA")

            salidaexistente  = New CSalida 

            If datos.Read() Then
                Try
                    datos.GetValues(values)
                    salidaexistente.Id = values(id_salida)
                    salidaexistente.Usuario = values(id_usuario)
                    salidaexistente.Fecha = values(fecha)
                   
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("Salida no encontrada")
            End If

            datos.Close()

            Dim sqldetalle As String
            sqldetalle = "SELECT SALIDA_DET.CANTIDAD,SALIDA_DET.COSTO,producto.CODIGO_CLAVE,producto.DESCRIPCION FROM SALIDA_DET inner join PRODUCTO on PRODUCTO.ID_PRODUCTO = SALIDA_DET.ID_PRODUCTO WHERE SALIDA_DET.ID_SALIDA = @folio"

            db.CrearComando(sqldetalle, CommandType.Text)
            db.AgregarParametro("@folio", salidaexistente.Id)

            datos = db.EjecutarConsulta()
            Dim valu(datos.FieldCount) As Object

            Dim cant = datos.GetOrdinal("CANTIDAD")
            Dim costo = datos.GetOrdinal("COSTO")
            Dim cod_clave = datos.GetOrdinal("CODIGO_CLAVE")
            Dim descProd = datos.GetOrdinal("DESCRIPCION")

            While datos.Read

                Try
                    datos.GetValues(valu)
                    Dim salidadet As New CSalidaDetalle
                    Dim prod As New Producto
                    prod.Codigo = valu(cod_clave)
                    prod.Descripcion = valu(descProd)
                    salidadet.Cantidad = valu(cant)
                    salidadet.Costo = valu(costo)

                    Dim item As New CSalidaDetalle(prod, valu(cant), valu(costo))

                    salidaexistente.ItemsS.Add(item)

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try

            End While

            datos.Close()

        Catch Ex As BaseDatosException
            MsgBox("Error al acceder a la base de datos para obtener los productos.")
        Catch Ex As ReglasNegocioException
            MsgBox("No existe la salida.")
        Finally
            datos.Close()
            db.Desconectar()
            db.Dispose()
        End Try
        Return salidaexistente
    End Function
    Public Function ObtenerSalidas(ByVal fecha1 As String, ByVal fecha2 As String, Optional ByVal verpor As String = "") As List(Of CSalida)
        Dim DB As BaseDatos = Nothing
        Dim read As FbDataReader = Nothing
        Dim salida As List(Of CSalida) = Nothing
        Try
            DB = New BaseDatos
            DB.Conectar()
            Dim sql As String
            If verpor = "Todos" Then
                sql = "select salida.*,usuarios.usuario from salida inner join usuarios on usuarios.id_usuario = salida.id_usuario order by fecha_salida desc"
                DB.CrearComando(sql, CommandType.Text)
            Else
                sql = "select salida.*,usuarios.usuario from salida inner join usuarios on usuarios.id_usuario = salida.id_usuario where fecha_salida between @fecha1 and @fecha2 order by fecha_salida desc"
                DB.CrearComando(sql, CommandType.Text)
                DB.AgregarParametro("@fecha1", fecha1)
                DB.AgregarParametro("@fecha2", fecha2)
            End If

            read = DB.EjecutarConsulta
            Dim id_salida = read.GetOrdinal("id_salida")
            Dim fecha_salida = read.GetOrdinal("fecha_salida")
            Dim id_usuario = read.GetOrdinal("id_usuario")
            Dim nom_usu = read.GetOrdinal("usuario")
            Dim values(read.FieldCount) As Object
            salida = New List(Of CSalida)
            While read.Read
                read.GetValues(values)
                salida.Add(New CSalida(values(id_salida), values(nom_usu), values(fecha_salida), values(id_usuario)))
            End While
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error en insert. " + Ex.Message)
        Finally
            read.Close()
            DB.Desconectar()
        End Try
        Return salida
    End Function
    Public Function obtenerProductosSalidas(ByVal fol As Integer) As CSalida
        Dim db As BaseDatos = Nothing
        Dim rows As FbDataReader = Nothing
        Dim Csalida As CSalida = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim getP As String
            getP = "SELECT SALIDA_DET.CANTIDAD,SALIDA_DET.COSTO,producto.CODIGO_CLAVE,producto.DESCRIPCION FROM SALIDA_DET inner join PRODUCTO on PRODUCTO.ID_PRODUCTO = SALIDA_DET.ID_PRODUCTO WHERE SALIDA_DET.ID_SALIDA=@fol"
            db.CrearComando(getP, CommandType.Text)
            db.AgregarParametro("@fol", fol)
            rows = db.EjecutarConsulta
            Dim valores(rows.FieldCount) As Object
            Dim cant = rows.GetOrdinal("CANTIDAD")
            Dim costo = rows.GetOrdinal("COSTO")
            Dim cod_clave = rows.GetOrdinal("CODIGO_CLAVE")
            Dim descProd = rows.GetOrdinal("DESCRIPCION")
             Csalida = New CSalida
            While rows.Read
                Try
                    rows.GetValues(valores)
                    Dim compradet As New CCompraDetalle
                    Dim prod As New Producto
                    prod.Codigo = valores(cod_clave)
                    prod.Descripcion = valores(descProd)
                    compradet.Cantidad = valores(cant)
                    compradet.Costo = valores(costo)

                    Dim item As New CSalidaDetalle(prod, valores(cant), valores(costo))

                    Csalida.ItemsS.Add(item)

                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden (Abonos).", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET", Ex)
                End Try
            End While
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Abonos)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException(Ex.Message)
        Finally
            rows.Close()
            db.Desconectar()
        End Try
        Return Csalida
    End Function
End Class
