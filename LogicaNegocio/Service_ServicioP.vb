Imports FirebirdSql.Data.FirebirdClient
Imports AccesoDatos
Imports System.ComponentModel
Public Class Service_ServicioP

    Private sqlGEN As String = "SELECT " _
   & "PRODUCTO.ID_PRODUCTO," _
   & "PRODUCTO.CODIGO_CLAVE," _
   & "PRODUCTO.DESCRIPCION," _
   & "PRODUCTO.COSTO," _
   & "PRODUCTO.PRECIO," _
   & "PRODUCTO.STOCK_MIN," _
   & "PRODUCTO.STOCK_MAX," _
   & "PRODUCTO.PIEZA_CAJA," _
   & "PRODUCTO.EXISTENCIA," _
   & "PRODUCTO.DESCUENTO," _
   & "PRODUCTO.RANGO," _
   & "PRODUCTO.ID_LINEA," _
   & "PRODUCTO.DESCUENTO_1," _
   & "PRODUCTO.DESCUENTO_2," _
   & "PRODUCTO.IVA," _
   & "PRODUCTO.STATUS," _
   & "PRODUCTO.ES_PRODUCTO," _
   & "SERVICIOS_PRODS.ID_SP ," _
   & "SERVICIOS_PRODS.ID_SERVICIO" _
   & "    FROM " _
   & "       SERVICIOS_PRODS " _
   & " INNER JOIN PRODUCTO ON (SERVICIOS_PRODS.ID_PRODUCTO = PRODUCTO.ID_PRODUCTO) where ID_SERVICIO=@ID_SERV"

    Public Sub crearServicio(ByRef paquete As ServicioP)

        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "INSERT INTO  producto" _
           & "(codigo_clave, descripcion,costo,precio,stock_min,stock_max,pieza_caja,existencia,descuento,rango,id_linea,descuento_1,descuento_2,iva,status,es_producto)" _
           & " VALUES(@codigo,@descripcion,@costo,@precio,@stock_min,@stock_max,@pieza_caja,@existencia,@descuento,@rango,@id_linea,@descuento_1,@descuento_2,@iva,@status,@es_producto) RETURNING id_producto"
            db.ComenzarTransaccion()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@codigo", paquete.Codigo)
            db.AgregarParametro("@descripcion", paquete.Descripcion)
            db.AgregarParametro("@costo", paquete.Costo)
            db.AgregarParametro("@precio", paquete.Precio)
            db.AgregarParametro("@stock_min", 0)
            db.AgregarParametro("@stock_max", 0)
            db.AgregarParametro("@pieza_caja", 0)
            db.AgregarParametro("@descuento", 0)
            db.AgregarParametro("@rango", 0)
            db.AgregarParametro("@id_linea", 6)
            db.AgregarParametro("@descuento_1", 0)
            db.AgregarParametro("@descuento_2", 0)
            db.AgregarParametro("@iva", IIf(paquete.Iva = True, 1, 0))
            db.AgregarParametro("@status", IIf(paquete.Estatus = True, 1, 0))
            db.AgregarParametro("@es_producto", "2")
            db.AgregarParametro("@existencia", "0")
            paquete.Id = db.EjecutarEscalar()

            Dim sql2 As String
            sql2 = "insert into SERVICIOS_PRODS(ID_SP,ID_servicio,ID_PRODUCTO) VALUES(NULL,@ID,@ID_PROD)"
            For Each item As ItemServicio In paquete.Items
                db.CrearComando(sql2, CommandType.Text)
                db.AgregarParametro("@ID", paquete.Id)
                db.AgregarParametro("@ID_PROD", item.Id_Producto)
                db.EjecutarComando()
            Next

            db.ConfirmarTransaccion()
        Catch ex As FbException
            db.CancelarTransaccion()
            If ex.ErrorCode = 335544665 Then
                Throw New ReglasNegocioException("Ya hay otro servicio con la misma clave")
            ElseIf ex.ErrorCode = 335544349 Then
                Throw New ReglasNegocioException("Ya hay otro servicio con el misma clave")
            Else
                Throw New ReglasNegocioException(ex.Message)
            End If
        Catch Ex As BaseDatosException

            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            db.CancelarTransaccion()
            Throw New ReglasNegocioException(Err.Number)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Public Function obtenerServicio(ByVal producto As Producto) As ServicioP

        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try

            db = New BaseDatos
            db.Conectar()
            db.CrearComando(sqlGEN, CommandType.Text)
            db.AgregarParametro("@ID_SERV", producto.Id)
            datos = db.EjecutarConsulta()
            Dim items As New BindingList(Of ItemServicio)
            Dim prod As Producto
            While datos.Read()
                Try
                    prod = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("descuento_1"), datos("descuento_2"), datos("iva"), datos("status"))
                    items.Add(New ItemServicio(prod, datos("id_SP")))

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While

            Dim serv As New ServicioP(producto.Id, producto.Descripcion, producto.Codigo, producto.Costo, producto.Precio, items, producto.Iva, producto.Status)
            Return serv
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
    End Function

    Public Sub Actualiza(ByVal paquete As ServicioP)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "update producto " _
           & "set codigo_clave=@codigo, descripcion=@descripcion,precio=@precio,iva=@iva,status=@status where id_producto=@id"

            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@codigo", paquete.Codigo)
            db.AgregarParametro("@descripcion", paquete.Descripcion)
            db.AgregarParametro("@precio", paquete.Precio)
            db.AgregarParametro("@iva", IIf(paquete.Iva = True, 1, 0))
            db.AgregarParametro("@status", IIf(paquete.Estatus = True, 1, 0))
            db.AgregarParametro("@id", paquete.Id)
            db.EjecutarComando()

        Catch Ex As BaseDatosException

            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception

            Throw New ReglasNegocioException(Err.Number)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Sub borraItem(ByVal id)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "delete from servicios_prods where id_sp=@id"

            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", id)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception

            Throw New ReglasNegocioException(Err.Number)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Sub agregaItem(ByVal item As ItemServicio, ByVal idserv As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String = "insert into SERVICIOS_PRODS(ID_SP,ID_servicio,ID_PRODUCTO) VALUES(NULL,@ID,@ID_PROD)"

            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@ID", idserv)
            db.AgregarParametro("@ID_PROD", item.Id_Producto)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception

            Throw New ReglasNegocioException(Err.Number)
        Finally
            db.Desconectar()
        End Try
    End Sub

End Class


