Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Imports System.ComponentModel
Public Class Service_Paquete



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
   & "PAQUETE_DETALLE.CANTIDAD ," _
   & "PAQUETE_DETALLE.ID_PAQ ," _
   & " PAQUETE_DETALLE.ID_PAQUETE" _
   & "    FROM " _
   & "       PAQUETE_DETALLE " _
   & " INNER JOIN PRODUCTO ON (PAQUETE_DETALLE.ID_PRODUCTO = PRODUCTO.ID_PRODUCTO) where ID_PAQUETE=@ID_PAQ"

    Public Sub crearPaquete(ByRef paquete As Paquete, ByVal cantidad As Integer)

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
            db.AgregarParametro("@existencia", cantidad)
            db.AgregarParametro("@descuento", 0)
            db.AgregarParametro("@rango", 0)
            db.AgregarParametro("@id_linea", 1)
            db.AgregarParametro("@descuento_1", 0)
            db.AgregarParametro("@descuento_2", 0)
            db.AgregarParametro("@iva", IIf(paquete.Iva = True, 1, 0))
            db.AgregarParametro("@status", IIf(paquete.Estatus = True, 1, 0))
            db.AgregarParametro("@es_producto", "0")
            paquete.Id = db.EjecutarEscalar()

            Dim sql2 As String
            sql2 = "insert into paquete_detalle(ID_PAQUETE,ID_PRODUCTO,COSTO,PRECIO,CANTIDAD) VALUES(@ID,@ID_PROD,@COSTO,@PRECIO,@CANTIDAD)"
            For Each item As ItemPaquete In paquete.Items
                db.CrearComando(sql2, CommandType.Text)
                db.AgregarParametro("@ID", paquete.Id)
                db.AgregarParametro("@ID_PROD", item.Id_Producto)
                db.AgregarParametro("@COSTO", item.Producto.Costo)
                db.AgregarParametro("@PRECIO", item.Producto.Precio)
                db.AgregarParametro("@CANTIDAD", item.Cantidad)
                db.EjecutarComando()


                db.CrearComando("Update producto set existencia=(existencia-@exis) where id_producto=@id_p", CommandType.Text)
                db.AgregarParametro("@id_p", item.Id_Producto)
                db.AgregarParametro("@exis", (item.Cantidad * cantidad))
                item.exis = item.Producto.Existencia - (item.Cantidad * cantidad)

                db.EjecutarComando()

            Next
            
            db.ConfirmarTransaccion()
        Catch ex As FbException
            db.CancelarTransaccion()
            If ex.ErrorCode = 335544665 Then
                Throw New ReglasNegocioException("Ya hay otro paquete con la misma clave")
            ElseIf ex.ErrorCode = 335544349 Then
                Throw New ReglasNegocioException("Ya hay otro paquete con el misma clave")
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

    Public Function obtenerPaquete(ByVal producto As Producto) As Paquete

        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try

            db = New BaseDatos
            db.Conectar()
            db.CrearComando(sqlGEN, CommandType.Text)
            db.AgregarParametro("@ID_PAQ", producto.Id)
            datos = db.EjecutarConsulta()
            Dim items As New BindingList(Of ItemPaquete)
            Dim prod As Producto
            While datos.Read()
                Try
                    prod = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("descuento_1"), datos("descuento_2"), datos("iva"), datos("status"))
                    items.Add(New ItemPaquete(prod, datos("id_paq"), datos("cantidad")))

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            
            Dim paquete As New Paquete(producto.Id, producto.Descripcion, producto.Codigo, producto.Costo, producto.Precio, producto.Existencia, items, producto.Iva, producto.Status)
            Return paquete
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
    End Function

    Public Sub Desarmar(ByVal paquete As Paquete, ByVal cantidad As Integer)

        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            Dim Sql As String
            Sql = "update producto set existencia=existencia-@existencia where id_producto=@id"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", paquete.Id)
            db.AgregarParametro("@existencia", cantidad)

            db.EjecutarComando()

            For Each item As ItemPaquete In paquete.Items
                db.CrearComando("update producto set existencia=existencia+@existencia2 where id_producto=@id2", CommandType.Text)
                db.AgregarParametro("@id2", item.Id_Producto)
                db.AgregarParametro("@existencia2", (item.Cantidad * cantidad))
                db.EjecutarComando()

                item.exis = item.Producto.Existencia + (item.Cantidad * cantidad)
            Next
            db.ConfirmarTransaccion()
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

    Public Sub sumarPaquetes(ByRef paquete As Paquete, ByVal cantidad As Integer)

        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            Dim Sql As String
            Sql = "update producto set existencia=existencia+@existencia where id_producto=@id"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", paquete.Id)
            db.AgregarParametro("@existencia", cantidad)
     
            db.EjecutarComando()

            For Each item As ItemPaquete In paquete.Items
                db.CrearComando("update producto set existencia=existencia-@existencia2 where id_producto=@id2", CommandType.Text)
                db.AgregarParametro("@id2", item.Id_Producto)
                db.AgregarParametro("@existencia2", (item.Cantidad * cantidad))
                db.EjecutarComando()

                item.exis = item.Producto.Existencia - (item.Cantidad * cantidad)
            Next
            db.ConfirmarTransaccion()
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

    Public Sub Actualiza(ByVal paquete As Paquete)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "update producto " _
           & "set codigo_clave=@codigo, descripcion=@descripcion,precio=@precio,iva=@iva,status=@status where id_producto=@id"

            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@codigo", Paquete.Codigo)
            db.AgregarParametro("@descripcion", Paquete.Descripcion)
            db.AgregarParametro("@precio", paquete.Precio)
            db.AgregarParametro("@iva", IIf(paquete.Iva = True, 1, 0))
            db.AgregarParametro("@status", IIf(Paquete.Estatus = True, 1, 0))
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
End Class



