Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_cotizacion

    Dim _datos As BaseDatos = Nothing
    Public Sub IniciarBusqueda()
        _datos = New BaseDatos
        _datos.Conectar()
    End Sub
    Public Sub FinalizarBusqueda()
        _datos.Desconectar()
        _datos.Dispose()
    End Sub

    Public Function GuardarCotizacion(ByRef venta As Venta)

        Dim db As BaseDatos
        db = New BaseDatos
        Try


            db.Conectar()
            db.ComenzarTransaccion()


            Dim Sql As String

            Sql = "INSERT INTO cotizacion" _
           & "(id_usuario,id_cliente,fecha,subtotal,descuento,iva,total,total_texto)" _
           & " VALUES(@id_usuario,@id_cliente,@fecha,@subtotal,@descuento,@iva,@total,@total_texto) RETURNING id_cotizacion"


            Dim fecha As Date = Utils.ObtenerFechaHora(venta.Fecha)
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id_usuario", 1)
            db.AgregarParametro("@id_cliente", venta.Id_cliente)
            db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fecha))
            db.AgregarParametro("@subtotal", venta.Subtotal)
            db.AgregarParametro("@descuento", venta.Descuento)
            db.AgregarParametro("@iva", venta.Iva)
            db.AgregarParametro("@total", venta.Total)
            db.AgregarParametro("@total_texto", venta.Total_texto)
            venta.Id = db.EjecutarEscalar

            Dim sqli As String = "INSERT INTO cotizacion_det" _
           & "(id_cotizacion,id_producto,cantidad,costo,precio,descuento,descuentoporc)" _
           & " VALUES(@id_cotizacion,@id_producto,@cantidad,@costo,@precio,@descuento,@descPor)"

            For Each item As VentaItem In venta.Items
                db.CrearComando(sqli, CommandType.Text)
                db.AgregarParametro("@id_cotizacion", venta.Id)
                db.AgregarParametro("@id_producto", item.Producto.Id)
                db.AgregarParametro("@cantidad", item.Cantidad)
                db.AgregarParametro("@costo", item.Producto.Costo)
                db.AgregarParametro("@precio", item.Producto.Precio)
                db.AgregarParametro("@descuento", item.DescuentoDin)
                db.AgregarParametro("@descPor", item.DescuentoPor)
                db.EjecutarComando()
            Next




            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar la cotizacion. " + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return venta.Id
    End Function
    Public Function Obtener(ByVal folioid As Integer) As Venta
        Dim vent As Venta
        Dim db As BaseDatos = Nothing
        Dim Datos As FbDataReader = Nothing

        Try

            db = New BaseDatos
            db.Conectar()

            Dim sql As String
            sql = "SELECT * FROM cotizacion where id_cotizacion=@id "

            db.CrearComando(sql, CommandType.Text)
            db.AgregarParametro("@id", folioid)

            Datos = db.EjecutarConsulta()


            Dim id_cotizacion = Datos.GetOrdinal("id_cotizacion")
            Dim id_user = Datos.GetOrdinal("ID_USUARIO")
            Dim id_cli = Datos.GetOrdinal("id_cliente")
            Dim fecha = Datos.GetOrdinal("FECHA")
            Dim subtotal = Datos.GetOrdinal("subtotal")
            Dim descuento = Datos.GetOrdinal("descuento")
            Dim iva = Datos.GetOrdinal("iva")
            Dim total = Datos.GetOrdinal("total")
            Dim totaltxt = Datos.GetOrdinal("TOTAL_TEXTO")
            Dim values(Datos.FieldCount) As Object

            vent = New Venta
            If Datos.Read() Then
                Try
                    Datos.GetValues(values)
                    vent.Id = values(id_cotizacion)
                    vent.Id_usuario = values(id_user)
                    vent.Id_cliente = values(id_cli)
                    vent.Fecha = values(fecha)
                    vent.Subtotal = values(subtotal)
                    vent.Descuento = values(descuento)
                    vent.Iva = values(iva)
                    vent.Total = values(total)
                    vent.Total_texto = values(totaltxt)




                Catch Ex As InvalidCastException

                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No existe la cotizacion")
            End If


            Datos.Close()

            Dim sql1 As String
            sql1 = "DET_COTIZACION"
            db.CrearComando(sql1, CommandType.StoredProcedure)
            db.AgregarParametro("@ID", vent.Id)

            Datos = db.EjecutarConsulta()
            Dim valu(Datos.FieldCount) As Object

            Dim id_cot_det = Datos.GetOrdinal("ID_COT_DET")
            Dim cant = Datos.GetOrdinal("CANTIDAD")

            Dim idpr = Datos.GetOrdinal("ID_PRODUCTO")
            Dim descripcion = Datos.GetOrdinal("DESCRIPCION")
            Dim codigo = Datos.GetOrdinal("CODIGO")
            Dim costo = Datos.GetOrdinal("costo")
            Dim precio = Datos.GetOrdinal("PRECIO")
            Dim descCot = Datos.GetOrdinal("DESCUENTO")
            Dim existencia = Datos.GetOrdinal("existencia")
            Dim descProd = Datos.GetOrdinal("descProd")
            Dim rango = Datos.GetOrdinal("rango")
            Dim desc1 = Datos.GetOrdinal("descuento_1")
            Dim desc2 = Datos.GetOrdinal("descuento_2")
            Dim ivaProd = Datos.GetOrdinal("iva")
            Dim descPorc = Datos.GetOrdinal("descuentoporc")

            Dim linea As Integer = 1
            While Datos.Read

                Try
                    Datos.GetValues(valu)
                    Dim prod As New Producto
                    prod.Id = valu(idpr)
                    prod.Descripcion = valu(descripcion)
                    prod.Codigo = valu(codigo)
                    prod.Precio = valu(precio)
                    prod.Costo = valu(costo)
                    prod.Descuento = valu(descProd)
                    prod.Existencia = valu(existencia)
                    prod.Rango = valu(rango)
                    prod.Descuento_1 = valu(desc1)
                    prod.Descuento_2 = valu(desc2)
                    prod.Iva = valu(ivaProd)

                    Dim item As New VentaItem(valu(cant), valu(descPorc), prod) ''desmadre




                    item.Id = linea
                    item.DescuentoDin = valu(descCot)

                    vent.Items.Add(item)
                    linea += 1

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try

            End While

            Datos.Close()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener los productos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error a obtener la cotizacion. " + Ex.Message)
        Finally
            Datos.Close()
            db.Desconectar()
            db.Dispose()
        End Try

        Return vent
    End Function
    Public Function obtenerCotizaciones(ByVal cliente As String) As List(Of Cotizacion)
        Dim cotizaciones As New List(Of Cotizacion)
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "select cotizacion.*,cliente.razon_social from cotizacion inner join cliente on cliente.id_cliente=cotizacion.id_cliente where UPPER (cliente.razon_social COLLATE DE_de) like  UPPER('%" & cliente & "%' COLLATE DE_de) order by cotizacion.fecha desc"


            _datos.CrearComando(Sql, CommandType.Text)

            datos = _datos.EjecutarConsulta()
            Dim id = Datos.GetOrdinal("id_cotizacion")
            Dim id_cliente = Datos.GetOrdinal("razon_social")
            Dim monto = Datos.GetOrdinal("total")
            Dim fecha = Datos.GetOrdinal("fecha")

            Dim values(Datos.FieldCount) As Object

            While Datos.Read()
                Try
                    Datos.GetValues(values)
                    Dim cotizacion As New Cotizacion(values(id), values(fecha), values(id_cliente), values(monto))

                    cotizaciones.Add(cotizacion)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las cotizaciones. " + Ex.Message)
        Finally
            datos.Close()
        End Try
        Return cotizaciones
    End Function
End Class
