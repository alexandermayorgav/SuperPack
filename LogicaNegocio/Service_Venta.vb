Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Venta

    Public Sub CambiaCliente(ByVal id_venta As Integer, ByVal id_cliente As Integer)
        Dim db As BaseDatos = Nothing

        Try

            db = New BaseDatos
            db.Conectar()

            Dim sql As String = "update venta set id_cliente=@id_cliente where id_venta=@id"

            db.CrearComando(sql, CommandType.Text)
            db.AgregarParametro("@id_cliente", id_cliente)
            db.AgregarParametro("@id", id_venta)
            db.EjecutarComando()

        Catch fb As FbException
            Throw New ReglasNegocioException(fb.Message)
        Catch ex As Exception
            Throw New ReglasNegocioException(ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try

    End Sub
    Public Function Obtener(ByVal folioid As Integer) As Devolucion
        Dim vent As Devolucion
        Dim db As BaseDatos = Nothing
        Dim Datos As FbDataReader = Nothing
        '  Dim datos2 As FbDataReader = Nothing

        Try

            db = New BaseDatos
            db.Conectar()

            Dim sql As String
            sql = "SELECT * FROM venta where id_venta=@id "
            db.CrearComando(sql, CommandType.Text)
            db.AgregarParametro("@id", folioid)

            Datos = db.EjecutarConsulta()

            Dim id_venta = Datos.GetOrdinal("id_venta")
            Dim id_user = Datos.GetOrdinal("ID_USUARIO")
            Dim id_cli = Datos.GetOrdinal("id_cliente")
            Dim fecha = Datos.GetOrdinal("FECHA")
            Dim subtotal = Datos.GetOrdinal("subtotal")
            Dim descuento = Datos.GetOrdinal("descuento")
            Dim iva = Datos.GetOrdinal("iva")
            Dim total = Datos.GetOrdinal("total")
            Dim totaltxt = Datos.GetOrdinal("TOTAL_TEXTO")
            Dim values(Datos.FieldCount) As Object

            vent = New Devolucion
            If Datos.Read() Then
                Try
                    Datos.GetValues(values)
                    vent.Id = values(id_venta)
                    vent.Id_usuario = values(id_user)
                    vent.Id_Venta = values(id_cli)
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
                Throw New ReglasNegocioException("No existe la venta")
            End If

            'Datos.Close()

            Dim sql1 As String
            sql1 = "SELECT  venta_detalle.id_ven_det,  venta_detalle.CANTIDAD, venta_detalle.id_producto,  PRODUCTO.CODIGO_CLAVE,  PRODUCTO.DESCRIPCION , linea.descripcion as linea,  venta_detalle.COSTO,  venta_detalle.PRECIO,  venta_detalle.DESCUENTO as vDescuento,  PRODUCTO.EXISTENCIA,  PRODUCTO.DESCUENTO as pDescuento,  PRODUCTO.RANGO,  PRODUCTO.DESCUENTO_1, PRODUCTO.DESCUENTO_2,  producto.IVA,venta_detalle.tipo_promocion      from venta_detalle inner join PRODUCTO   on PRODUCTO.ID_PRODUCTO=venta_detalle.ID_PRODUCTO    inner join linea on producto.id_linea=linea.id_linea    WHERE  venta_detalle.id_venta=@ID"

            db.CrearComando(sql1, CommandType.Text)
            db.AgregarParametro("@ID", vent.Id)

            Datos = db.EjecutarConsulta()
            Dim valu(Datos.FieldCount) As Object

            Dim id_ven_det = Datos.GetOrdinal("id_ven_det")
            Dim cant = Datos.GetOrdinal("CANTIDAD")

            Dim idpr = Datos.GetOrdinal("ID_PRODUCTO")
            Dim descripcion = Datos.GetOrdinal("DESCRIPCION")
            Dim codigo = Datos.GetOrdinal("codigo_clave")
            Dim costo = Datos.GetOrdinal("costo")
            Dim precio = Datos.GetOrdinal("PRECIO")
            Dim descItem = Datos.GetOrdinal("vDescuento")
            Dim existencia = Datos.GetOrdinal("existencia")
            Dim descProd = Datos.GetOrdinal("pDescuento")
            Dim rango = Datos.GetOrdinal("rango")
            Dim desc1 = Datos.GetOrdinal("descuento_1")
            Dim desc2 = Datos.GetOrdinal("descuento_2")
            Dim ivaProd = Datos.GetOrdinal("iva")
            Dim tipo_promocion = Datos.GetOrdinal("tipo_promocion")
            Dim line = Datos.GetOrdinal("linea")



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

                    Dim item As New Devolucion_Item(valu(cant), valu(descProd), prod, IIf(valu(tipo_promocion) = "Ninguna", False, True), valu(tipo_promocion)) ''desmadre

                    item.Id = linea
                    item.DescuentoP = valu(descItem)
                    vent.Items.Add(item)
                    linea += 1




                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try

            End While

            'Datos.Close()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener los productos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            Datos.Close()
            '   datos2.Close()
            db.Desconectar()
            db.Dispose()
        End Try

        Return vent
    End Function
    Public Function GuardarVenta(ByRef venta As Venta, ByVal id_caja As Integer, ByVal efectivo As Decimal, Optional ByVal listaVales As List(Of Vales) = Nothing, Optional ByVal listaTarj As List(Of Tarjeta) = Nothing)
        Dim db As New BaseDatos

        Try
            db.Conectar()
            db.ComenzarTransaccion()

            Dim Sql As String
            Sql = "INSERT INTO venta" _
           & "(id_usuario,id_cliente,fecha,subtotal,descuento,iva,total,total_texto)" _
           & " VALUES(@id_usuario,@id_cliente,@fecha,@subtotal,@descuento,@iva,@total,@total_texto) RETURNING id_venta"
            Dim subtotal As Decimal = Math.Round(venta.Subtotal, 2)
            Dim iva As Decimal = Math.Round(venta.Total, 2) - subtotal



            Dim fecha As Date = Utils.ObtenerFechaHora(venta.Fecha)
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id_usuario", venta.Id_usuario)
            db.AgregarParametro("@id_cliente", venta.Id_cliente)
            db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fecha))
            db.AgregarParametro("@subtotal", subtotal)
            db.AgregarParametro("@descuento", venta.Descuento)
            db.AgregarParametro("@iva", iva)
            db.AgregarParametro("@total", Math.Round(venta.Total, 2))
            db.AgregarParametro("@total_texto", venta.Total_texto)
            venta.Id = db.EjecutarEscalar

            If efectivo > 0 Then
                Dim sqlCaja = "INSERT INTO caja_detalle" _
                & "(id_caja,fecha,monto,concepto,tipo_pago)" _
                & "VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago)"
                db.CrearComando(sqlCaja, CommandType.Text)
                db.AgregarParametro("@id_caja", id_caja) ''caja
                db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fecha))
                db.AgregarParametro("@monto", efectivo)
                db.AgregarParametro("@concepto", "Venta  Folio: " & venta.Id)
                db.AgregarParametro("@tipo_pago", "Efectivo")
                db.EjecutarComando()
            End If

            Dim sqli As String = "INSERT INTO venta_detalle" _
           & "(id_venta,id_producto,cantidad,costo,precio,descuento,tipo_promocion)" _
           & " VALUES(@id_venta,@id_producto,@cantidad,@costo,@precio,@descuento,@tipo_promocion) RETURNING id_ven_det"

            Dim sqli2 As String = "INSERT INTO promociones" _
          & "(id_det_vta,fecha)" _
          & " VALUES(@id_det_vta,@fecha)"


            For Each item As VentaItem In venta.Items
                db.CrearComando(sqli, CommandType.Text)
                db.AgregarParametro("@id_venta", venta.Id)
                db.AgregarParametro("@id_producto", item.Producto.Id)
                db.AgregarParametro("@cantidad", item.Cantidad)
                db.AgregarParametro("@costo", item.Producto.Costo)
                db.AgregarParametro("@precio", item.Producto.Precio)
                db.AgregarParametro("@descuento", item.DescuentoPor)
                db.AgregarParametro("@tipo_promocion", item.TipoPromocion)
                Dim id_ven_det As Integer = db.EjecutarEscalar

                If item.Promocion Then
                    db.CrearComando(sqli2, CommandType.Text)
                    db.AgregarParametro("@id_det_vta", id_ven_det)
                    db.AgregarParametro("@fecha", venta.Fecha)
                    db.EjecutarComando()
                End If
                If Not item.TipoPromocion = "Servicio" Then
                    ActualizaAlmacen(db, item, "select existencia from producto where id_producto=@prod")
                End If

            Next

            If venta.credito Then
                Dim sql2 As String = "INSERT INTO credito_detalle" _
           & "(id_credito,id_venta)" _
           & " VALUES(@id_credito,@id_venta)"
                db.CrearComando(sql2, CommandType.Text)
                db.AgregarParametro("@id_venta", venta.Id)
                db.AgregarParametro("@id_credito", venta.id_credito)
                db.EjecutarComando()

                db.CrearComando("update creditos  set saldo=saldo+@saldo , fecha_act = @fecha_act where id_cliente=@id_cliente  ", CommandType.Text)
                db.AgregarParametro("@saldo", venta.Total - venta.abono)
                db.AgregarParametro("@id_cliente", venta.Id_cliente)
                db.AgregarParametro("@fecha_act", venta.Fecha)
                db.EjecutarComando()

                If venta.abono <> 0 Then
                    Dim sql3 As String = "INSERT INTO abono_credito" _
           & "(id_credito,fecha,abono)" _
           & " VALUES(@id_credito,@fecha,@abono)"
                    db.CrearComando(sql3, CommandType.Text)
                    db.AgregarParametro("@id_credito", venta.id_credito)
                    db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(venta.Fecha))
                    db.AgregarParametro("@abono", venta.abono)
                    db.EjecutarComando()

                End If
            End If

            Dim SCaja As New Service_Caja
            Dim SVale As New Service_Vale

            If Not listaVales Is Nothing Then
                If listaVales.Count > 0 Then
                    For Each item As Vales In listaVales
                        SCaja.agregarEntrada(db, item.MontoUsar, Utils.ObtenerFechaHora(fecha), "Venta Folio: " & venta.Id & "/Folio V: " & item.Folio, id_caja, "Vale")
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
                        SCaja.agregarEntrada(db, itemT.Monto, Utils.ObtenerFechaHora(fecha), "Venta Folio: " & venta.Id & "/No. Op.: " & itemT.NumeroOperacion, id_caja, "Tarjeta")
                    Next
                End If
            End If

            If Not venta.Id_Servicio = 0 Then
                Dim Serv_Venta As String = "INSERT INTO servicio_venta" _
           & "(id_servicio,id_venta)" _
           & " VALUES(@id_servicio,@id_venta)"
                db.CrearComando(Serv_Venta, CommandType.Text)
                db.AgregarParametro("@id_servicio", venta.Id_Servicio)
                db.AgregarParametro("@id_venta", venta.Id)
                db.EjecutarComando()

            End If
            

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
        Return venta.Id
    End Function
    Public Sub ActualizaAlmacen(ByRef db As BaseDatos, ByRef item As VentaItem, ByVal sql As String)

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

    Public Function ObtenerMax() As Integer
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select max (id_venta) as id_venta  from venta"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)

            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try

                    Return datos("id_venta")

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("no encontrado")
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el folio. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
    End Function
    'Función para obtener el total de ventas
    Public Function verVentasFecha(ByVal fechaInicial As Date, ByVal fechaFinal As Date, ByVal usuarion As Integer) As List(Of ResumenVentas)
        Dim resumenVentas As New List(Of ResumenVentas)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String
            fechaFinal = DateAdd(DateInterval.Day, 1, fechaFinal)

            If usuarion = 0 Then
                sQuery = "RESUMENVENTA" 'Resumen de ventas por rango de fechas
                db.CrearComando(sQuery, CommandType.StoredProcedure)

                'If fechaInicial = fechaFinal Then
                '    db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicial))
                '    db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(DateAdd(DateInterval.Day, 1, fechaFinal)))
                'Else
                db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicial))
                db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(fechaFinal))
                ' System.Windows.Forms.MessageBox.Show(Utils.ObtenerFecha(fechaFinal))

                'End If


            Else
                sQuery = "RESUMENFECHA" 'Resumen de ventas por rango de fechas y usuario
                db.CrearComando(sQuery, CommandType.StoredProcedure)

                'If fechaInicial = fechaFinal Then
                '    db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicial))
                '    db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(DateAdd(DateInterval.Day, 1, fechaFinal)))
                '    db.AgregarParametro("@VENDEDOR", usuarion)
                'Else
                db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicial))
                db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(fechaFinal))
                db.AgregarParametro("@VENDEDOR", usuarion)
                'End If

            End If

            data = db.EjecutarConsulta()

            Dim id_vta = data.GetOrdinal("ID_VENTA")
            Dim id_user = data.GetOrdinal("ID_USUARIO")
            Dim fecha = data.GetOrdinal("FECHA")
            Dim total = data.GetOrdinal("TOTAL")
            Dim usser = data.GetOrdinal("NOMBRE_USUARIO")
            Dim nombrepersonal = data.GetOrdinal("NOMBRE")
            Dim cliente = data.GetOrdinal("RAZON_SOCIAL")

            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Res = New ResumenVentas(values(id_vta), values(id_user), values(fecha), values(total), values(usser), values(nombrepersonal), values(cliente))
                    resumenVentas.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While



        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las ventas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las ventas. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()
        End Try
        Return resumenVentas
    End Function
    Public Function llenarUsuarios() As DataSet
        Dim db As New BaseDatos()
        Dim data As DataSet = Nothing
        Try
            db.Conectar()
            db.CrearComando("SELECT * FROM USUARIOS", CommandType.Text)
            data = db.ObtenConsulta
        Catch ex As Exception

        Finally
            db.Desconectar()
            data.Dispose()
        End Try
        Return data
    End Function

    Public Function getVentasCredito(ByVal idcred As Integer) As List(Of Venta)
        Dim ventas As New List(Of Venta)
        Dim db As BaseDatos = Nothing
        Dim Datos As FbDataReader = Nothing
        '  Dim datos2 As FbDataReader = Nothing

        Try

            db = New BaseDatos
            db.Conectar()

            Dim sql As String
            sql = "SELECT * FROM VENTA INNER JOIN CREDITO_DETALLE " _
            & "ON CREDITO_DETALLE.ID_VENTA=VENTA.ID_VENTA " _
            & "WHERE CREDITO_DETALLE.ID_CREDITO=@ID order by fecha desc"
            db.CrearComando(sql, CommandType.Text)
            db.AgregarParametro("@ID", idcred)

            Datos = db.EjecutarConsulta()

            Dim id_venta = Datos.GetOrdinal("id_venta")
            Dim id_user = Datos.GetOrdinal("ID_USUARIO")
            Dim id_cli = Datos.GetOrdinal("id_cliente")
            Dim fecha = Datos.GetOrdinal("FECHA")
            Dim subtotal = Datos.GetOrdinal("subtotal")
            Dim descuento = Datos.GetOrdinal("descuento")
            Dim iva = Datos.GetOrdinal("iva")
            Dim total = Datos.GetOrdinal("total")
            Dim totaltxt = Datos.GetOrdinal("TOTAL_TEXTO")
            Dim values(Datos.FieldCount) As Object


            While Datos.Read()
                Try
                    Dim vent As New Venta
                    Datos.GetValues(values)
                    vent.Id = values(id_venta)
                    vent.Id_usuario = values(id_user)
                    vent.Fecha = values(fecha)
                    vent.Subtotal = values(subtotal)
                    vent.Descuento = values(descuento)
                    vent.Iva = values(iva)
                    vent.Total = values(total)
                    vent.Total_texto = values(totaltxt)

                    ventas.Add(vent)

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener los productos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las ventas. " + Ex.Message)
        Finally
            Datos.Close()

            db.Desconectar()
            db.Dispose()
        End Try

        Return ventas
    End Function
End Class
