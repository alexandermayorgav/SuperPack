Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Compra

    Dim _datos As BaseDatos = Nothing
    Private codigosservice As Service_Codigos
    Private cod As Codigo
    Private listac As List(Of Codigo)
    Private listaprod As List(Of Producto)
    Private SProductos As Service_Producto
    Public Sub IniciarBusqueda()
        _datos = New BaseDatos
        _datos.Conectar()
    End Sub
    Public Sub FinalizarBusqueda()
        _datos.Desconectar()
        _datos.Dispose()
    End Sub
    Public Function insertar(ByVal compra As CCompras, ByVal credito As Boolean, ByVal listaTodosProdHijos As List(Of Producto), ByVal Fcompra As Date)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            Dim Sql As String
            Sql = "INSERT INTO COMPRA" _
           & "(ID_USUARIO,ID_PROVEEDOR,FECHA,TOTAL_TEXTO,SUBTOTAL,DESCUENTO,IVA,TOTAL,credito)" _
           & " VALUES(@idusu,@idprov,@fecha,@total_txt,@subT,@descuento,@iva,@total,@credito) RETURNING ID_COMPRA"

            Dim fecha As Date = Utils.ObtenerFechaHora(compra.Fecha)
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@idusu", compra.Usuario)
            db.AgregarParametro("@idprov", compra.Proveedor)
            db.AgregarParametro("@fecha", fecha)
            db.AgregarParametro("@total_txt", compra.TotalLetras)
            db.AgregarParametro("@subT", compra.SubT)
            db.AgregarParametro("@descuento", compra.Descuento)
            db.AgregarParametro("@iva", compra.IVA)
            db.AgregarParametro("@total", compra.Total)
            db.AgregarParametro("@credito", IIf(credito, 1, 0))
            compra.Id = db.EjecutarEscalar()

            If credito = True Then

                Dim Sqlcredito As String
                Sqlcredito = "INSERT INTO CUENTAS_PAGAR" _
                & "(ID_COMPRA,TOTAL,PAGADO) VALUES (@idcompra,@total,@pagado) RETURNING ID_CREDITO"
                db.CrearComando(Sqlcredito, CommandType.Text)
                db.AgregarParametro("@idcompra", compra.Id)
                db.AgregarParametro("@total", compra.Total)
                db.AgregarParametro("@pagado", 0)
                db.EjecutarEscalar()

            End If

            Dim sqldetalle As String

            sqldetalle = "INSERT INTO COMPRA_DETALLE" _
           & "(ID_COMPRA,ID_PRODUCTO,CANTIDAD,COSTO,IMPORTE,IVA,DESCUENTO)" _
           & " VALUES(@idcompra,@idproducto,@cantidad,@costo,@importe,@iva,@descuento)"

            For Each item As CCompraDetalle In compra._compraitems
                db.CrearComando(sqldetalle, CommandType.Text)
                db.AgregarParametro("@idcompra", compra.Id)
                db.AgregarParametro("@idproducto", item.Producto.Id)
                db.AgregarParametro("@cantidad", item.Cantidad)
                db.AgregarParametro("@costo", item.CUnitario)
                db.AgregarParametro("@importe", (item.Cantidad * item.Costo) - item.DescuentoD)
                db.AgregarParametro("@iva", item.IVA)
                db.AgregarParametro("@descuento", item.DescuentoP)
                db.EjecutarComando()

                Dim fechaAct As Date = Utils.ObtenerFecha(Date.Now)
                Dim fechacompra As Date = Utils.ObtenerFecha(Fcompra)

                db.CrearComando("select existencia,costo,precio,precio_menudeo from producto where id_producto=@prod", CommandType.Text)
                db.AgregarParametro("@prod", item.Producto.Id)
                Dim lee As FbDataReader
                Dim existenciaactual As Decimal
                Dim Cto As Decimal
                Dim Pcio As Decimal
                Dim Pmenu As Decimal


                lee = db.EjecutarConsulta

                If lee.Read Then
                    existenciaactual = lee("existencia")
                    Cto = lee("costo")
                    Pcio = lee("precio")
                    Pmenu = lee("precio_menudeo")
                End If

                lee.Close()

                ActualizaAlmacen(db, item, fechacompra, fechaAct, existenciaactual, item.Producto.Id)

                If item.Producto.ActualizarCodigosHermanos Then
                    listac = New List(Of Codigo)
                    listac = ObtenerCodHermanos(item.Producto.Id, db)
                    If listac.Count > 0 Then
                        If item.Costo <> Cto Or item.Precio <> Pcio Or item.PrecioMenudeo <> Pmenu Then
                            For Each i As Codigo In listac
                                If i.Id_Producto <> item.Producto.Id Then
                                    db.CrearComando("update producto set costo=@c,precio=@p,fecha_actualizacion=@Fact,precio_menudeo=@pmenu where id_producto=@idprod", CommandType.Text)
                                    db.AgregarParametro("@Fact", fechaAct)
                                    db.AgregarParametro("@c", item.Costo)
                                    db.AgregarParametro("@p", item.Precio)
                                    db.AgregarParametro("@pmenu", item.PrecioMenudeo)
                                    db.AgregarParametro("@idprod", i.Id_Producto)
                                    db.EjecutarComando()
                                End If
                            Next
                        End If
                    End If
                End If

                'Productos Hijos
                If item.Producto.IDCAJA < 1 Then

                    If listaTodosProdHijos.Count > 0 Then
                        listaprod = New List(Of Producto)
                        SProductos = New Service_Producto
                        listaprod = SProductos.ObtenerIDCGuardar(item.Producto.Id, db)
                        For Each itProdHijo As Producto In listaprod
                            For Each i As Producto In listaTodosProdHijos
                                If itProdHijo.Id = i.Id Then

                                    If itProdHijo.Costo <> i.Costo Or itProdHijo.Precio <> i.Precio Or itProdHijo.Precio_Menudeo <> i.Precio_Menudeo Then
                                        db.CrearComando("update producto set costo=@c,precio=@p,fecha_compra=@Fcompra,fecha_actualizacion=@Fact,precio_menudeo=@pmenu where id_producto=@idP", CommandType.Text)
                                        db.AgregarParametro("@Fcompra", fechacompra)
                                        db.AgregarParametro("@Fact", fechaAct)
                                        db.AgregarParametro("@c", i.Costo)
                                        db.AgregarParametro("@p", i.Precio)
                                        db.AgregarParametro("@pmenu", i.Precio_Menudeo)
                                        db.AgregarParametro("@idP", i.Id)
                                    Else
                                        db.CrearComando("update producto set fecha_compra=@Fcompra where id_producto=@idP", CommandType.Text)
                                        db.AgregarParametro("@Fcompra", fechacompra)
                                        db.AgregarParametro("@idP", i.Id)
                                    End If
                                    db.EjecutarComando()

                                    If i.ActualizarCodigosHermanos Then
                                        listac = New List(Of Codigo)
                                        listac = ObtenerCodHermanos(item.Producto.Id, db)
                                        If listac.Count > 0 Then
                                            If itProdHijo.Costo <> i.Costo Or itProdHijo.Precio <> i.Precio Or itProdHijo.Precio_Menudeo <> i.Precio_Menudeo Then
                                                For Each iCodHrno As Codigo In listac
                                                    If iCodHrno.Id_Producto <> item.Producto.Id Then
                                                        db.CrearComando("update producto set costo=@c,precio=@p,fecha_compra=@Fcompra,fecha_actualizacion=@Fact,precio_menudeo=@pmenu where id_producto=@idprod", CommandType.Text)
                                                        db.AgregarParametro("@Fcompra", fechacompra)
                                                        db.AgregarParametro("@Fact", fechaAct)
                                                        db.AgregarParametro("@c", i.Costo)
                                                        db.AgregarParametro("@p", i.Precio)
                                                        db.AgregarParametro("@pmenu", i.Precio_Menudeo)
                                                        db.AgregarParametro("@idprod", iCodHrno.Id_Producto)
                                                        db.EjecutarComando()
                                                    End If
                                                Next
                                            End If
                                        End If
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                    End If

                End If
            Next
            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar la compra. " + Ex.Message)
            MsgBox(Err.Number)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return compra.Id
    End Function
    Private Sub ActualizaAlmacen(ByRef db As BaseDatos, ByRef item As CCompraDetalle, ByVal fC As Date, ByVal fAct As Date, ByVal existenciaactual As Decimal, ByVal idp As Integer)
        db.CrearComando("update producto set costo=@costo,precio=@precio,existencia=@existencia,fecha_compra=@Fcompra,fecha_actualizacion=@Fact,precio_menudeo=@pmenu where id_producto=@idprodu", CommandType.Text)
        db.AgregarParametro("@Fcompra", fC)
        db.AgregarParametro("@Fact", fAct)
        db.AgregarParametro("@costo", item.Costo)
        db.AgregarParametro("@precio", item.Precio)
        db.AgregarParametro("@pmenu", item.PrecioMenudeo)
        db.AgregarParametro("@existencia", existenciaactual + item.Cantidad)
        db.AgregarParametro("@idprodu", idp)
        db.EjecutarComando()
    End Sub
    Private Function ObtenerCodHermanos(ByVal idProd As Integer, ByRef db As BaseDatos)
        'codigo hermano
        codigosservice = New Service_Codigos
        cod = New Codigo
        cod.Id_Producto = idProd
        listac = New List(Of Codigo)
        Try
            listac = codigosservice.verGrupo(cod, db)
        Catch ex As Exception
            If Err.Number = 5 Then
                Exit Try
            End If
        End Try
        Return listac
    End Function
    Public Function ObtenerCompra(ByVal folio As Integer) As CCompras
        Dim compraexistente As CCompras = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim Sql As String = "Select * from compra where id_compra=@idcompra"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@idcompra", folio)
            datos = db.EjecutarConsulta()

            Dim values(datos.FieldCount) As Object

            Dim id_compra = datos.GetOrdinal("ID_COMPRA")
            Dim id_usuario = datos.GetOrdinal("ID_USUARIO")
            Dim id_proveedor = datos.GetOrdinal("ID_PROVEEDOR")
            Dim fecha = datos.GetOrdinal("FECHA")
            Dim totaltxt = datos.GetOrdinal("TOTAL_TEXTO")
            Dim subtotal = datos.GetOrdinal("SUBTOTAL")
            Dim descuento = datos.GetOrdinal("DESCUENTO")
            Dim iva = datos.GetOrdinal("IVA")
            Dim total = datos.GetOrdinal("TOTAL")
            Dim credito = datos.GetOrdinal("credito")
            compraexistente = New CCompras

            If datos.Read() Then
                Try
                    datos.GetValues(values)
                    compraexistente.Id = values(id_compra)
                    compraexistente.Usuario = values(id_usuario)
                    compraexistente.Proveedor = values(id_proveedor)
                    compraexistente.Fecha = values(fecha)
                    compraexistente.TotalLetras = values(totaltxt)
                    compraexistente.SubT = values(subtotal)
                    compraexistente.Descuento = values(descuento)
                    compraexistente.IVA = values(iva)
                    compraexistente.Total = values(total)
                    compraexistente.credito = values(credito)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("Compra no encontrada")
            End If

            datos.Close()

            Dim sqldetalle As String
            sqldetalle = "SELECT compra_detalle.CANTIDAD,compra_detalle.COSTO,compra_detalle.IMPORTE,compra_detalle.IVA,compra_detalle.DESCUENTO,producto.CODIGO_CLAVE,producto.DESCRIPCION,producto.IVA, producto.precio FROM compra_detalle inner join producto on producto.ID_PRODUCTO = compra_detalle.ID_PRODUCTO WHERE compra_detalle.ID_COMPRA = @folio"

            db.CrearComando(sqldetalle, CommandType.Text)
            db.AgregarParametro("@folio", compraexistente.Id)

            datos = db.EjecutarConsulta()
            Dim valu(datos.FieldCount) As Object

            Dim cant = datos.GetOrdinal("CANTIDAD")
            Dim costo = datos.GetOrdinal("COSTO")
            Dim importe = datos.GetOrdinal("IMPORTE")
            Dim newiva = datos.GetOrdinal("IVA")
            Dim desc = datos.GetOrdinal("DESCUENTO")
            Dim cod_clave = datos.GetOrdinal("CODIGO_CLAVE")
            Dim descProd = datos.GetOrdinal("DESCRIPCION")
            Dim tieneIVA = datos.GetOrdinal("IVA")
            Dim precio = datos.GetOrdinal("precio")


            While datos.Read

                Try
                    datos.GetValues(valu)
                    Dim compradet As New CCompraDetalle
                    Dim prod As New Producto
                    prod.Codigo = valu(cod_clave)
                    prod.Descripcion = valu(descProd)
                    prod.Iva = valu(tieneIVA)
                    prod.Precio = valu(precio)

                    compradet.Cantidad = valu(cant)
                    compradet.Costo = valu(costo)
                    compradet.Importe = valu(importe)
                    compradet.IVA = valu(newiva)
                    compradet.DescuentoP = valu(desc)

                    Dim item As New CCompraDetalle(prod, valu(cant), valu(costo), valu(desc), 0, valu(newiva), 0, valu(importe))
                    ''item.Importe = valu(importe)


                    compraexistente.Items.Add(item)
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
            MsgBox("No existe la compra.")
        Finally
            datos.Close()
            db.Desconectar()
            db.Dispose()
        End Try
        Return compraexistente
    End Function
    Public Function ObtenerProductoProveedor(ByVal idprod As Integer, ByVal idprovee As Integer) 'As CCompras
        'Dim prodexistente As CCompras = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Dim esproductoproveedor As Boolean = False
        Try
            db = New BaseDatos
            db.Conectar()

            Dim Sql As String = "Select ID_PROVEEDOR from PRODUCTO_PROVEEDOR where ID_PRODUCTO=@idprod AND ID_PROVEEDOR=@idprovee"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@idprod", idprod)
            db.AgregarParametro("@idprovee", idprovee)
            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try

                    esproductoproveedor = True

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                esproductoproveedor = True
                ''Throw New ReglasNegocioException("El producto se agregara a la lista, pero debes relacionar este producto al proveedor seleccionado.")
            End If

            datos.Close()

        Catch Ex As BaseDatosException
            MsgBox("Error al acceder a la base de datos para obtener los productos.")
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
            db.Dispose()

        End Try
        Return esproductoproveedor
    End Function
    Public Function obtenerTodosCreditos() As List(Of CCompras)
        Dim db As BaseDatos = Nothing
        Dim rows As FbDataReader = Nothing
        Dim creditos As List(Of CCompras) = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            creditos = New List(Of CCompras)
            Dim getC As String = "SELECT CUENTAS_PAGAR.ID_CREDITO,CUENTAS_PAGAR.PAGADO,COMPRA.TOTAL,COMPRA.FECHA,PROVEEDOR.RAZON_SOCIAL " _
           & "FROM CUENTAS_PAGAR inner join COMPRA on CUENTAS_PAGAR.ID_COMPRA=COMPRA.ID_COMPRA inner join PROVEEDOR on " _
           & "COMPRA.ID_PROVEEDOR=PROVEEDOR.ID_PROVEEDOR"
            db.CrearComando(getC, CommandType.Text)

            rows = db.EjecutarConsulta
            Dim id_credito = rows.GetOrdinal("ID_CREDITO")
            Dim total = rows.GetOrdinal("TOTAL")
            Dim fecha = rows.GetOrdinal("FECHA")
            Dim razon = rows.GetOrdinal("RAZON_SOCIAL")
            Dim pagado = rows.GetOrdinal("PAGADO")

            Dim valores(rows.FieldCount) As Object
            While rows.Read
                Try
                    rows.GetValues(valores)
                    Dim objP As New CCompras(valores(razon), valores(total), valores(fecha), valores(id_credito), valores(pagado))
                    creditos.Add(objP)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden (Cuentas Por Pagar).", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET", Ex)
                End Try

            End While
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Cuentas Por Pagar)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener la lista de Cuentas Por Pagar. " + Ex.Message)
        Finally
            rows.Close()
            db.Desconectar()
        End Try
        Return creditos
    End Function
    'Función para obtener el total de compras
    Public Function verComprasFecha(ByVal fechaInicial As Date, ByVal fechaFinal As Date, ByVal usuarion As Integer, ByVal provedorn As Integer) As List(Of ResumenCompras)
        Dim resumenCompras As New List(Of ResumenCompras)
        Dim db As New BaseDatos
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "RESUMENCOMPRA"

          
            fechaFinal = DateAdd(DateInterval.Day, 1, fechaFinal)

            If usuarion > 0 And provedorn > 0 Then
                db.CrearComando(sQuery, CommandType.StoredProcedure)
                db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicial))
                db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(fechaFinal))
                db.AgregarParametro("@VENDEDOR", usuarion)
                db.AgregarParametro("@PROVEDOR", provedorn)

            ElseIf usuarion = 0 And provedorn > 0 Then
                db.CrearComando(sQuery, CommandType.StoredProcedure)
                db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicial))
                db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(fechaFinal))
                db.AgregarParametro("@VENDEDOR", usuarion)
                db.AgregarParametro("@PROVEDOR", provedorn)

            ElseIf usuarion > 0 And provedorn = 0 Then
                db.CrearComando(sQuery, CommandType.StoredProcedure)
                db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicial))
                db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(fechaFinal))
                db.AgregarParametro("@VENDEDOR", usuarion)
                db.AgregarParametro("@PROVEDOR", provedorn)

            ElseIf usuarion = 0 And provedorn = 0 Then
                db.CrearComando(sQuery, CommandType.StoredProcedure)
                db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicial))
                db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(fechaFinal))
                db.AgregarParametro("@VENDEDOR", usuarion)
                db.AgregarParametro("@PROVEDOR", provedorn)

            End If

            Dim data As FbDataReader = db.EjecutarConsulta()

            Dim id_compra = data.GetOrdinal("ID_COMPRA")
            Dim id_user = data.GetOrdinal("ID_USUARIO")
            Dim fecha = data.GetOrdinal("FECHA")
            Dim total = data.GetOrdinal("TOTAL")
            Dim usser = data.GetOrdinal("NOMBRE_USUARIO")
            Dim nombrepersonal = data.GetOrdinal("NOMBRE")
            Dim idprov = data.GetOrdinal("ID_PROVEEDOR")
            Dim rs = data.GetOrdinal("RAZON_SOCIAL")


            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Res = New ResumenCompras(values(id_compra), values(id_user), values(fecha), values(total), values(usser), values(nombrepersonal), values(idprov), values(rs))
                    resumenCompras.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            data.Close()


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las ventas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las ventas. " + Ex.Message)
        Finally
            db.Desconectar()

        End Try
        Return resumenCompras
    End Function
    Public Function llenarProveedores() As DataSet
        Dim db As New BaseDatos()
        Dim data As DataSet = Nothing
        Try
            db.Conectar()
            db.CrearComando("SELECT * FROM PROVEEDOR", CommandType.Text)
            data = db.ObtenConsulta
        Catch ex As Exception
        Finally
            db.Desconectar()
            data.Dispose()
        End Try
        Return data
    End Function
    Public Function ObtenerCompras(ByVal fecha1 As String, ByVal fecha2 As String, Optional ByVal verpor As String = "") As List(Of CCompras)
        Dim DB As BaseDatos = Nothing
        Dim read As FbDataReader = Nothing
        Dim compra As List(Of CCompras) = Nothing
        Try
            DB = New BaseDatos
            DB.Conectar()
            Dim sql As String
            If verpor = "Todos" Then
                sql = "select id_compra,id_usuario,id_proveedor,fecha,descuento,iva,total from compra order by fecha desc"
                DB.CrearComando(sql, CommandType.Text)
            Else
                sql = "select id_compra,id_usuario,id_proveedor,fecha,descuento,iva,total from compra where fecha between @fecha1 and @fecha2 order by fecha desc"
                DB.CrearComando(sql, CommandType.Text)
                DB.AgregarParametro("@fecha1", fecha1)
                DB.AgregarParametro("@fecha2", fecha2)
            End If

            read = DB.EjecutarConsulta
            Dim id_compra = read.GetOrdinal("id_compra")
            Dim id_usu = read.GetOrdinal("id_usuario")
            Dim id_provee = read.GetOrdinal("id_proveedor")
            Dim fecha = read.GetOrdinal("fecha")
            Dim descuento = read.GetOrdinal("descuento")
            Dim iva = read.GetOrdinal("iva")
            Dim total = read.GetOrdinal("total")
            Dim values(read.FieldCount) As Object
            compra = New List(Of CCompras)
            While read.Read
                read.GetValues(values)
                compra.Add(New CCompras(values(id_compra), values(id_usu), values(id_provee), values(fecha), values(descuento), values(iva), values(total)))
            End While
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error en insert. " + Ex.Message)
        Finally
            read.Close()
            DB.Desconectar()
        End Try
        Return compra
    End Function
    Public Function obtenerProductosCompra(ByVal fol As Integer) As CCompras
        Dim db As BaseDatos = Nothing
        Dim rows As FbDataReader = Nothing
        Dim compraDetalle As CCompras = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim getC As String = "SELECT compra_detalle.CANTIDAD,compra_detalle.COSTO,compra_detalle.IMPORTE,compra_detalle.IVA,compra_detalle.DESCUENTO,producto.DESCRIPCION FROM compra_detalle inner join producto on producto.ID_PRODUCTO = compra_detalle.ID_PRODUCTO WHERE compra_detalle.ID_COMPRA = @folio"
            db.CrearComando(getC, CommandType.Text)
            db.AgregarParametro("@folio", fol)
            rows = db.EjecutarConsulta
            Dim cant = rows.GetOrdinal("CANTIDAD")
            Dim costo = rows.GetOrdinal("COSTO")
            Dim importe = rows.GetOrdinal("IMPORTE")
            Dim newiva = rows.GetOrdinal("IVA")
            Dim desc = rows.GetOrdinal("DESCUENTO")
            Dim descProd = rows.GetOrdinal("DESCRIPCION")
            Dim valores(rows.FieldCount) As Object
            compraDetalle = New CCompras
            While rows.Read
                Try
                    rows.GetValues(valores)
                    Dim compradet As New CCompraDetalle
                    Dim prod As New Producto
                    prod.Descripcion = valores(descProd)
                    compradet.Cantidad = valores(cant)
                    compradet.Costo = valores(costo)
                    compradet.Importe = valores(importe)
                    compradet.IVA = valores(newiva)
                    compradet.DescuentoP = valores(desc)

                    Dim item As New CCompraDetalle(prod, valores(cant), valores(costo), valores(desc), 0, valores(newiva), 0, valores(importe))

                    compraDetalle.Items.Add(item)

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
        Return compraDetalle
    End Function
End Class