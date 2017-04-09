Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Devolucion

    Public Function Devueltos(ByVal folio As Integer) As List(Of pDevueltos)

        Dim dev As List(Of pDevueltos) = Nothing
        Dim Db As BaseDatos = Nothing
        Dim Datos As FbDataReader = Nothing
        Try

            Dim Sql As String = "SELECT     venta_dev_det.id_producto, SUM( venta_dev_det.cantidad) as devueltos FROM venta_dev INNER JOIN  venta_dev_det ON venta_dev.id_dev = venta_dev_det.id_dev INNER JOIN   producto ON venta_dev_det.id_producto = producto.id_producto     where venta_dev.id_venta=@id  group by venta_dev_det.id_producto"

            Db = New BaseDatos()

            Db.Conectar()
            Db.CrearComando(Sql, CommandType.Text)
            Db.AgregarParametro("@id", folio)

            Datos = Db.EjecutarConsulta()


            Dim devuelt = Datos.GetOrdinal("devueltos")
            ' Dim id_detalle_venta = Datos.GetOrdinal("id_dev_det")
            Dim id_producto = Datos.GetOrdinal("id_producto")

            Dim values(Datos.FieldCount) As Object


            dev = New List(Of pDevueltos)
            While Datos.Read()
                Try
                    Dim p As New pDevueltos
                    Datos.GetValues(values)

                    dev.Add(New pDevueltos(values(devuelt), values(id_producto)))


                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While



        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener los productos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error a obtener las devoluciones. " + Ex.Message)
        Finally
            Datos.Close()
            Db.Desconectar()
        End Try
        Return dev

    End Function

    Public Function Guardar(ByRef dev As Devolucion, ByVal id_caja As Integer)
        Dim db As BaseDatos
        db = New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()

            Dim Sql As String
            Sql = "INSERT INTO venta_dev" _
           & "(id_usuario,id_venta,fecha,subtotal,descuento,iva,total,total_texto)" _
           & " VALUES(@id_usuario,@id_venta,@fecha,@subtotal,@descuento,@iva,@total,@total_texto) RETURNING id_dev"

            Dim fecha As Date = Utils.ObtenerFechaHora(dev.Fecha)
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id_usuario", dev.Id_usuario)
            db.AgregarParametro("@id_venta", dev.Id)
            db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fecha))
            db.AgregarParametro("@subtotal", dev.Subtotal)
            db.AgregarParametro("@descuento", dev.Descuento)
            db.AgregarParametro("@iva", dev.Iva)
            db.AgregarParametro("@total", dev.Total)
            db.AgregarParametro("@total_texto", dev.Total_texto)
            dev.Id = db.EjecutarEscalar

            Dim sqli As String = "INSERT INTO venta_dev_det" _
           & "(id_dev,id_producto,cantidad,costo,precio,descuento)" _
           & " VALUES(@id_dev,@id_producto,@cantidad,@costo,@precio,@descuento)"

            For Each item As Devolucion_Item In dev.Items
                If item.aDevolver > 0 Then
                    db.CrearComando(sqli, CommandType.Text)
                    db.AgregarParametro("@id_dev", dev.Id)
                    db.AgregarParametro("@id_producto", item.Producto.Id)
                    db.AgregarParametro("@cantidad", item.aDevolver)
                    db.AgregarParametro("@costo", item.Producto.Costo)
                    db.AgregarParametro("@precio", item.Producto.Precio)
                    db.AgregarParametro("@descuento", item.DescuentoP)
                    db.EjecutarComando()

                    db.CrearComando("update producto set existencia=existencia+@adevolver where id_producto=@id_producto", CommandType.Text)
                    db.AgregarParametro("@adevolver", item.aDevolver)
                    db.AgregarParametro("@id_producto", item.Producto.Id)
                    db.EjecutarComando()
                End If
            Next

            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar la venta. " + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return dev.Id
    End Function


End Class
