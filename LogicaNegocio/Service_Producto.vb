Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient

Public Class Service_Producto
    Dim _datos As BaseDatos = Nothing
    Public Sub IniciarBusqueda()
        _datos = New BaseDatos
        _datos.Conectar()
    End Sub
    Public Sub FinalizarBusqueda()
        _datos.Desconectar()
        _datos.Dispose()
    End Sub
    Public Sub borrar(ByVal id As Integer)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("delete from producto where id_producto=@id", CommandType.Text)
            db.AgregarParametro("@id", id)
            db.EjecutarComando()


        Catch Ex As BaseDatosException

            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException

            Throw New ReglasNegocioException("Error al borrar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Public Sub updateSobrante(ByVal id_producto As Integer, ByVal sobrante As Decimal, ByVal paquete As Producto)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()

            db.CrearComando("update producto set sobrante=@sobrante where id_producto=@id_producto ", CommandType.Text)
            db.AgregarParametro("@sobrante", sobrante)
            db.AgregarParametro("@id_producto", id_producto)
            db.EjecutarComando()

            db.CrearComando("update producto set existencia=existencia+@existencia where id_producto=@id_producto", CommandType.Text)
            db.AgregarParametro("@existencia", paquete.Existencia)
            db.AgregarParametro("@id_producto", paquete.Id)
            db.EjecutarComando()

            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al actualizar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub
    Public Function obtener_Proveedores(ByVal id_producto As Integer) As List(Of Proveedor)
        Dim proveedor As New List(Of Proveedor)
        Dim db As BaseDatos = Nothing
        Dim Datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "select proveedor.* from producto_proveedor inner join proveedor on producto_proveedor.id_proveedor=proveedor.id_proveedor where producto_proveedor.id_producto=@id_producto"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id_producto", id_producto)
            Datos = db.EjecutarConsulta()

            Dim values(Datos.FieldCount) As Object

            While Datos.Read()
                Try
                    Datos.GetValues(values)
                    Dim miproveedor As New Proveedor(Datos("id_proveedor"), Datos("razon_social"), True, False)
                    proveedor.Add(miproveedor)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los proveedores. " + Ex.Message)
        Finally
            Datos.Close()
            db.Desconectar()
        End Try
        Return Proveedor
    End Function

    Public Sub insertar(ByVal producto As Producto, ByVal lista As List(Of Proveedor), ByVal mispaquetes As List(Of Producto))
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            Dim Sql As String
            Sql = "INSERT INTO  producto" _
           & "(codigo_clave, descripcion,costo,precio,stock_min,stock_max,pieza_caja,existencia,descuento,rango,id_linea,descuento_1,descuento_2,iva,status,es_producto,id_caja,sobrante,fecha_compra,precio_menudeo)" _
           & " VALUES(@codigo,@descripcion,@costo,@precio,@stock_min,@stock_max,@pieza_caja,@existencia,@descuento,@rango,@id_linea,@descuento_1,@descuento_2,@iva,@status,@es,@codigo_caja,@sobrante,@fecha_compra,@precio_menudeo) RETURNING id_producto"

            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@codigo", producto.Codigo)
            db.AgregarParametro("@descripcion", producto.Descripcion)
            db.AgregarParametro("@costo", producto.Costo)
            db.AgregarParametro("@precio", producto.Precio)
            db.AgregarParametro("@stock_min", producto.Stock_min)
            db.AgregarParametro("@stock_max", producto.Stock_max)
            db.AgregarParametro("@pieza_caja", producto.Piezas)
            db.AgregarParametro("@existencia", producto.Existencia)
            db.AgregarParametro("@descuento", producto.Descuento)
            db.AgregarParametro("@rango", producto.Rango)
            db.AgregarParametro("@id_linea", producto.Id_linea)
            db.AgregarParametro("@descuento_1", producto.Descuento_1)
            db.AgregarParametro("@descuento_2", producto.Descuento_2)
            db.AgregarParametro("@iva", IIf(producto.Iva = True, 1, 0))
            db.AgregarParametro("@status", IIf(producto.Status = True, 1, 0))
            db.AgregarParametro("@es", 1)
            db.AgregarParametro("@codigo_caja", producto.IDCAJA)
            db.AgregarParametro("@sobrante", producto.Sobrante)
            db.AgregarParametro("@fecha_compra", Utils.ObtenerFechaHora(producto.Fecha_Compra))
            db.AgregarParametro("@precio_menudeo", producto.Precio_Menudeo)
            producto.Id = db.EjecutarEscalar()

            Dim sqli As String = "INSERT INTO producto_proveedor" _
           & "(id_producto,id_proveedor)" _
           & " VALUES(@id_producto,@id_proveedor)"

            For Each i As Proveedor In lista
                db.CrearComando(sqli, CommandType.Text)
                db.AgregarParametro("@id_producto", producto.Id)
                db.AgregarParametro("@id_proveedor", i.IdProveedor)
                db.EjecutarComando()
            Next

            If producto.Kg Then
                Dim sql3 As String = "insert into prod_fracc" _
            & "(id_producto)" _
            & " VALUES (@id_producto)"
                db.CrearComando(sql3, CommandType.Text)
                db.AgregarParametro("@id_producto", producto.Id)
                db.EjecutarComando()
            End If

            
            For Each it As Producto In mispaquetes
                If it.Actualizado Then
                    
                    If it.IDCAJA <> 0 Then
                        db.CrearComando("update producto set id_caja=@id_caja, costo=@costo,precio=@precio,precio_menudeo=@precio_menudeo,fecha_actualizacion=@today,fecha_compra=@FechaC where id_producto=@id_producto ", CommandType.Text)
                        db.AgregarParametro("@id_producto", it.Id)
                        db.AgregarParametro("@costo", it.Costo)
                        db.AgregarParametro("@precio", it.Precio)
                        db.AgregarParametro("@precio_menudeo", it.Precio_Menudeo)
                        db.AgregarParametro("@today", Utils.ObtenerFecha(Today))
                        db.AgregarParametro("@fechaC", producto.Fecha_Compra)
                        db.AgregarParametro("@id_caja", producto.Id)
                    Else
                        db.CrearComando("update producto set id_caja=@id_caja, costo=@costo,precio=@precio,precio_menudeo=@precio_menudeo,fecha_actualizacion=@today where id_producto=@id_producto ", CommandType.Text)
                        db.AgregarParametro("@id_producto", it.Id)
                        db.AgregarParametro("@costo", it.Costo)
                        db.AgregarParametro("@precio", it.Precio)
                        db.AgregarParametro("@precio_menudeo", it.Precio_Menudeo)
                        db.AgregarParametro("@today", Utils.ObtenerFecha(Today))
                        db.AgregarParametro("@id_caja", 0)
                    End If
                    db.EjecutarComando()
                Else
                    
                    If it.IDCAJA <> 0 Then
                        db.CrearComando("update producto set id_caja=@id_caja, costo=@costo,precio=@precio,precio_menudeo=@precio_menudeo, fecha_compra=@fechaC where id_producto=@id_producto ", CommandType.Text)
                        db.AgregarParametro("@id_producto", it.Id)
                        db.AgregarParametro("@costo", it.Costo)
                        db.AgregarParametro("@precio", it.Precio)
                        db.AgregarParametro("@precio_menudeo", it.Precio_Menudeo)
                        db.AgregarParametro("@fechaC", producto.Fecha_Compra)
                        db.AgregarParametro("@id_caja", producto.Id)
                    Else
                        db.CrearComando("update producto set id_caja=@id_caja, costo=@costo,precio=@precio,precio_menudeo=@precio_menudeo where id_producto=@id_producto ", CommandType.Text)
                        db.AgregarParametro("@id_producto", it.Id)
                        db.AgregarParametro("@costo", it.Costo)
                        db.AgregarParametro("@precio", it.Precio)
                        db.AgregarParametro("@precio_menudeo", it.Precio_Menudeo)
                        db.AgregarParametro("@id_caja", 0)
                    End If
                    db.EjecutarComando()
                End If

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
    Public Function ObtenerPaqRel(ByVal id As String) As List(Of Producto)
        Dim producto As Producto = Nothing
        Dim productos As New List(Of Producto)
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Dim datos2 As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select * from producto where id_caja=@id"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", id)
            datos = db.EjecutarConsulta()

            While datos.Read()
                Try

                    Dim Sql2 As String = "Select * from prod_fracc where id_producto=@id_producto"
                    db.CrearComando(Sql2, CommandType.Text)
                    db.AgregarParametro("@id_producto", datos("id_producto"))
                    datos2 = db.EjecutarConsulta()
                    Dim kg As Boolean = False
                    If datos2.Read Then
                        kg = True
                    End If

                    producto = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("iva"), datos("status"), Nothing, kg, datos("sobrante"), datos("fecha_compra"), datos("fecha_actualizacion"), datos("precio_menudeo"))
                    producto.IDCAJA = datos("id_caja")
                    producto.Actualizado = False
                    productos.Add(producto)

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                Finally
                    datos2.Close()
                End Try

            End While
           
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
        Return productos
    End Function
    Public Function ObtenerActualizados(ByVal inicial As Date, ByVal final As Date) As List(Of Producto)
        Dim producto As Producto = Nothing
        Dim productos As New List(Of Producto)
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select * from producto where fecha_actualizacion between @inicial and @final order by  producto.descripcion"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@inicial", inicial)
            db.AgregarParametro("@final", final)
            datos = db.EjecutarConsulta()

            While datos.Read()
                Try

                    producto = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("iva"), datos("status"), Nothing, True, datos("sobrante"), datos("fecha_compra"), datos("fecha_actualizacion"), datos("precio_menudeo"))
                    productos.Add(producto)

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)

                End Try

            End While

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
        Return productos
    End Function
    Public Function Obtener(ByVal codigo As String) As Producto
        Dim producto As Producto = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Dim datos2 As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select producto.*,linea.descripcion as linea from producto inner join linea on producto.id_linea=linea.id_linea where   UPPER (codigo_clave COLLATE DE_de) like  UPPER('" & codigo & "' COLLATE DE_de)"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            'db.AgregarParametro("@codigo", codigo)
            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try

                    Dim Sql2 As String = "Select * from prod_fracc where id_producto=@id_producto"
                    db.CrearComando(Sql2, CommandType.Text)
                    db.AgregarParametro("@id_producto", datos("id_producto"))
                    datos2 = db.EjecutarConsulta()
                    Dim kg As Boolean = False
                    If datos2.Read Then
                        kg = True
                    End If

                    producto = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("iva"), datos("status"), Nothing, kg, datos("sobrante"), datos("fecha_compra"), datos("fecha_actualizacion"), datos("precio_menudeo"))
                    Return producto

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                Finally
                    datos2.Close()
                End Try
            Else
                Throw New ReglasNegocioException("No encontrado")
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function
    Public Function ObtenerPorId(ByVal id As Integer, ByRef db As BaseDatos) As Producto
        Dim producto As Producto = Nothing
        Dim datos As FbDataReader = Nothing

        Try
            Dim Sql As String = "Select * from producto where id_producto=@id"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", id)
            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try
                    
                    producto = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("descuento_1"), datos("descuento_2"), datos("iva"), datos("status"))
                    Return producto

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No encontrado")
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function


    Public Sub actualizar(ByVal producto As Producto, ByVal lista As List(Of Proveedor), ByVal mispaquetes As List(Of Producto))
        Dim datos2 As FbDataReader = Nothing
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()

            db.CrearComando("select costo,precio,precio_menudeo from producto where id_producto=@id_producto", CommandType.Text)
            db.AgregarParametro("@id_producto", producto.Id)
            Dim lee As FbDataReader
            Dim Cto As Decimal
            Dim Pcio As Decimal
            Dim Pmenu As Decimal

            lee = db.EjecutarConsulta

            If lee.Read Then
                Cto = lee("costo")
                Pcio = lee("precio")
                Pmenu = lee("precio_menudeo")
            End If

            lee.Close()


            Dim today As Date = Date.Now

            If producto.Precio <> Pcio Or producto.Costo <> Cto Or producto.Precio_Menudeo <> Pmenu Then
                db.CrearComando("update producto set codigo_clave=@codigo,descripcion=@descripcion,costo=@costo,precio=@precio,stock_min=@stock_min,stock_max=@stock_max,pieza_caja=@pieza_caja,existencia=@existencia,descuento=@descuento,rango=@rango,id_linea=@id_linea,descuento_1=@descuento_1,descuento_2=@descuento_2,iva=@iva,status=@status, sobrante=@sobrante,fecha_compra=@fecha_compra,precio_menudeo=@precio_menudeo,fecha_actualizacion=@today where id_producto=@id_producto ", CommandType.Text)
                db.AgregarParametro("@codigo", producto.Codigo)
                db.AgregarParametro("@descripcion", producto.Descripcion)
                db.AgregarParametro("@costo", producto.Costo)
                db.AgregarParametro("@precio", producto.Precio)
                db.AgregarParametro("@stock_min", producto.Stock_min)
                db.AgregarParametro("@stock_max", producto.Stock_max)
                db.AgregarParametro("@pieza_caja", producto.Piezas)
                db.AgregarParametro("@existencia", producto.Existencia)
                db.AgregarParametro("@descuento", producto.Descuento)
                db.AgregarParametro("@rango", producto.Rango)
                db.AgregarParametro("@id_linea", producto.Id_linea)
                db.AgregarParametro("@descuento_1", producto.Descuento_1)
                db.AgregarParametro("@descuento_2", producto.Descuento_2)
                db.AgregarParametro("@iva", IIf(producto.Iva = True, 1, 0))
                db.AgregarParametro("@status", IIf(producto.Status = True, 1, 0))
                db.AgregarParametro("@id_producto", producto.Id)
                'db.AgregarParametro("@codigo_caja", producto.IDCAJA)
                db.AgregarParametro("@sobrante", producto.Sobrante)
                db.AgregarParametro("@fecha_compra", Utils.ObtenerFechaHora(producto.Fecha_Compra))
                db.AgregarParametro("@precio_menudeo", producto.Precio_Menudeo)

                db.AgregarParametro("@today", Utils.ObtenerFecha(today))

            Else
                db.CrearComando("update producto set codigo_clave=@codigo,descripcion=@descripcion,costo=@costo,precio=@precio,stock_min=@stock_min,stock_max=@stock_max,pieza_caja=@pieza_caja,existencia=@existencia,descuento=@descuento,rango=@rango,id_linea=@id_linea,descuento_1=@descuento_1,descuento_2=@descuento_2,iva=@iva,status=@status, sobrante=@sobrante,fecha_compra=@fecha_compra,precio_menudeo=@precio_menudeo where id_producto=@id_producto ", CommandType.Text)
                db.AgregarParametro("@codigo", producto.Codigo)
                db.AgregarParametro("@descripcion", producto.Descripcion)
                db.AgregarParametro("@costo", producto.Costo)
                db.AgregarParametro("@precio", producto.Precio)
                db.AgregarParametro("@stock_min", producto.Stock_min)
                db.AgregarParametro("@stock_max", producto.Stock_max)
                db.AgregarParametro("@pieza_caja", producto.Piezas)
                db.AgregarParametro("@existencia", producto.Existencia)
                db.AgregarParametro("@descuento", producto.Descuento)
                db.AgregarParametro("@rango", producto.Rango)
                db.AgregarParametro("@id_linea", producto.Id_linea)
                db.AgregarParametro("@descuento_1", producto.Descuento_1)
                db.AgregarParametro("@descuento_2", producto.Descuento_2)
                db.AgregarParametro("@iva", IIf(producto.Iva = True, 1, 0))
                db.AgregarParametro("@status", IIf(producto.Status = True, 1, 0))
                db.AgregarParametro("@id_producto", producto.Id)
                'db.AgregarParametro("@codigo_caja", producto.IDCAJA)
                db.AgregarParametro("@sobrante", producto.Sobrante)
                db.AgregarParametro("@fecha_compra", Utils.ObtenerFechaHora(producto.Fecha_Compra))
                db.AgregarParametro("@precio_menudeo", producto.Precio_Menudeo)

            End If


            Try
                db.EjecutarComando()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            If producto.Actualizar Then
                For Each item As Codigo In producto.Item
                    If item.Id_Producto <> producto.Id Then
                        db.CrearComando("update producto set costo=@costo,precio=@precio,iva=@iva,precio_menudeo=@precio_menudeo,fecha_actualizacion=@today, fecha_compra=@fecha_compra where id_producto=@id_producto ", CommandType.Text)
                        db.AgregarParametro("@id_producto", item.Id_Producto)
                        db.AgregarParametro("@costo", producto.Costo)
                        db.AgregarParametro("@precio", producto.Precio)
                        db.AgregarParametro("@iva", IIf(producto.Iva = True, 1, 0))
                        db.AgregarParametro("@precio_menudeo", producto.Precio_Menudeo)
                        db.AgregarParametro("@today", Utils.ObtenerFecha(today))
                        db.AgregarParametro("@fecha_compra", Utils.ObtenerFechaHora(producto.Fecha_Compra))
                        db.EjecutarComando()
                    End If
                Next
            End If

            For Each i As Proveedor In lista
                If i._nuevo Then
                    Dim sqli As String = "INSERT INTO producto_proveedor" _
           & "(id_producto,id_proveedor)" _
           & " VALUES(@id_producto,@id_proveedor)"
                    db.CrearComando(sqli, CommandType.Text)
                    db.AgregarParametro("@id_producto", producto.Id)
                    db.AgregarParametro("@id_proveedor", i.IdProveedor)
                    db.EjecutarComando()
                ElseIf Not i.Status Then
                    db.CrearComando("delete from producto_proveedor   where  id_producto =@id_producto and id_proveedor=@id_proveedor", CommandType.Text)
                    db.AgregarParametro("@id_producto", producto.Id)
                    db.AgregarParametro("@id_proveedor", i.IdProveedor)
                    db.EjecutarComando()
                End If
            Next


            Dim Sql2 As String = "Select * from prod_fracc where id_producto=@id_producto"
            db.CrearComando(Sql2, CommandType.Text)
            db.AgregarParametro("@id_producto", producto.Id)
            datos2 = db.EjecutarConsulta()

            If datos2.Read Then
                If Not producto.Kg Then
                    db.CrearComando("delete from prod_fracc where id_producto=@id_producto ", CommandType.Text)
                    db.AgregarParametro("@id_producto", producto.Id)
                    db.EjecutarComando()
                End If
            Else
                If producto.Kg Then
                    Dim sql3 As String = "insert into prod_fracc" _
            & "(id_producto)" _
            & " VALUES (@id_producto)"
                    db.CrearComando(sql3, CommandType.Text)
                    db.AgregarParametro("@id_producto", producto.Id)
                    db.EjecutarComando()
                End If
            End If


            For Each it As Producto In mispaquetes
                If it.Actualizado Then
                    db.CrearComando("update producto set id_caja=@id_caja, costo=@costo,precio=@precio,precio_menudeo=@precio_menudeo,fecha_actualizacion=@today, fecha_compra=@fecha_compra where id_producto=@id_producto ", CommandType.Text)
                    db.AgregarParametro("@id_producto", it.Id)
                    db.AgregarParametro("@costo", it.Costo)
                    db.AgregarParametro("@precio", it.Precio)
                    db.AgregarParametro("@precio_menudeo", it.Precio_Menudeo)
                    db.AgregarParametro("@today", Utils.ObtenerFecha(today))
                    'demas
                    db.AgregarParametro("@fecha_compra", Utils.ObtenerFechaHora(producto.Fecha_Compra))
                    If it.IDCAJA <> 0 Then
                        db.AgregarParametro("@id_caja", producto.Id)
                    Else
                        db.AgregarParametro("@id_caja", 0)
                    End If
                    db.EjecutarComando()
                Else
                    db.CrearComando("update producto set id_caja=@id_caja, costo=@costo,precio=@precio,precio_menudeo=@precio_menudeo,  fecha_compra=@fecha_compra where id_producto=@id_producto ", CommandType.Text)
                    db.AgregarParametro("@id_producto", it.Id)
                    db.AgregarParametro("@costo", it.Costo)
                    db.AgregarParametro("@precio", it.Precio)
                    db.AgregarParametro("@precio_menudeo", it.Precio_Menudeo)
                    ''demas
                    db.AgregarParametro("@fecha_compra", Utils.ObtenerFechaHora(producto.Fecha_Compra))
                    If it.IDCAJA <> 0 Then
                        db.AgregarParametro("@id_caja", producto.Id)
                    Else
                        db.AgregarParametro("@id_caja", 0)
                    End If
                    db.EjecutarComando()
                End If
                
            Next

            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al actualizar los datos. " + Ex.Message)
        Finally
            datos2.Close()
            db.Desconectar()
        End Try
    End Sub
    '0 todos, 1 productos, 2 paquetes
    Public Function obtener_Productos(ByVal producto As String, Optional ByVal tipoproducto As Integer = 1) As List(Of Producto)
        Dim productos As New List(Of Producto)
        Dim datos As FbDataReader = Nothing
        Try
            Dim sql As String = ""

            If tipoproducto = 0 Then
                'sql = "select producto.*,linea.descripcion as linea from producto inner join linea on producto.id_linea=linea.id_linea WHERE UPPER (producto.descripcion COLLATE DE_de) like  UPPER('%" & producto & "%' COLLATE DE_de) or UPPER (linea.descripcion COLLATE DE_de) like  UPPER('%" & producto & "%' COLLATE DE_de) "
                sql = "select producto.*,linea.descripcion as linea,PROVEEDOR.RAZON_SOCIAL  from producto inner join linea on producto.id_linea=linea.id_linea inner join producto_proveedor on PRODUCTO.ID_PRODUCTO=PRODUCTO_PROVEEDOR.ID_PRODUCTO INNER JOIN PROVEEDOR ON PRODUCTO_PROVEEDOR.ID_PROVEEDOR=PROVEEDOR.ID_PROVEEDOR WHERE producto.descripcion like  '%" & producto & "%'or linea.descripcion  like '%" & producto & "%' or producto.codigo_clave like '%" & producto & "%' order by linea.descripcion, producto.descripcion"
            ElseIf tipoproducto = 1 Then
                sql = "select producto.*,linea.descripcion as linea from producto inner join linea on producto.id_linea=linea.id_linea WHERE producto.descripcion like  '%" & producto & "%'or linea.descripcion  like '%" & producto & "%' or producto.codigo_clave like '%" & producto & "%' order by linea.descripcion, producto.descripcion"
            ElseIf tipoproducto = 2 Then
                sql = "select producto.*,linea.descripcion as linea from producto inner join linea on producto.id_linea=linea.id_linea WHERE producto.descripcion like  '%" & producto & "%'or linea.descripcion  like '%" & producto & "%' or producto.codigo_clave like '%" & producto & "%' order by linea.descripcion, producto.descripcion"
                'ElseIf tipoproducto = 3 Then
                '    sql = "select producto.*,linea.descripcion as linea from producto inner join linea on producto.id_linea=linea.id_linea WHERE producto.descripcion like  '%" & producto & "%'or linea.descripcion  like '%" & producto & "%'"

            End If


            _datos.CrearComando(sql, CommandType.StoredProcedure)
            datos = (_datos.EjecutarConsulta())

            Dim values(Datos.FieldCount) As Object

            While Datos.Read()
                Try
                    Datos.GetValues(values)
                    Dim miproducto As New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("descuento_1"), datos("descuento_2"), datos("iva"), datos("status"))
                    miproducto.IDCAJA = datos("id_caja")
                    miproducto.Proveedor = datos("razon_social")
                    Try
                        miproducto.Precio_Menudeo = datos("precio_menudeo")
                        miproducto.Linea = datos("linea")
                        miproducto.Fecha_Compra = datos("fecha_compra")
                        miproducto.Fecha_Actualizacion = datos("fecha_actualizacion")
                    Catch ex As Exception
                        Exit Try
                    End Try
                    productos.Add(miproducto)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            Datos.Close()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los productos. " + Ex.Message)
        Finally
            datos.Close()
        End Try
        Return productos
    End Function
    Public Function obtenListaProductos(ByVal descripcion As String, ByVal lin As Integer) As List(Of BuscadorProductos)
        Dim objProductos As New List(Of BuscadorProductos)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "SELECT PRODUCTO.ID_PRODUCTO,PRODUCTO.CODIGO_CLAVE,PRODUCTO.DESCRIPCION,PRODUCTO.EXISTENCIA,PRODUCTO.STOCK_MIN, PRODUCTO.STOCK_MAX,LINEA.DESCRIPCION AS LINEAS,PRODUCTO.PRECIO,PRODUCTO.PRECIO_MENUDEO,PRODUCTO.COSTO FROM PRODUCTO INNER JOIN LINEA ON PRODUCTO.ID_LINEA=LINEA.ID_LINEA WHERE UPPER (PRODUCTO.CODIGO_CLAVE COLLATE DE_de||PRODUCTO.DESCRIPCION COLLATE DE_de) LIKE UPPER('%" & descripcion & "%' COLLATE DE_de) AND LINEA.ID_LINEA=@LINE AND PRODUCTO.STATUS<>0 AND PRODUCTO.ES_PRODUCTO='1' ORDER BY PRODUCTO.CODIGO_CLAVE"
            db.CrearComando(sQuery, CommandType.Text)

            db.AsignarParametroEntero("@LINE", lin)


            data = db.EjecutarConsulta()
            Dim id = data.GetOrdinal("ID_PRODUCTO")
            Dim clave = data.GetOrdinal("CODIGO_CLAVE")
            Dim descr = data.GetOrdinal("DESCRIPCION")
            Dim existencia = data.GetOrdinal("EXISTENCIA")
            Dim min = data.GetOrdinal("STOCK_MIN")
            Dim max = data.GetOrdinal("STOCK_MAX")
            Dim line = data.GetOrdinal("LINEAS")
            Dim precio = data.GetOrdinal("PRECIO")
            Dim menudeo = data.GetOrdinal("PRECIO_MENUDEO")
            Dim costo = data.GetOrdinal("COSTO")

            Dim values(data.FieldCount) As Object

            While data.Read
                Try
                    data.GetValues(values)
                    Dim producto As New BuscadorProductos(values(id), values(clave), values(descr), values(existencia), values(min), values(max), values(line), values(precio), values(menudeo), values(costo))
                    objProductos.Add(producto)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Inconsistencia de tipo de datos.", ex)
                Catch ex As DataException
                    Throw New ReglasNegocioException("ADO.net Error.", ex)
                End Try
            End While
            data.Close()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error de BD. No se obtuvo algún producto.")
        Catch ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los productos. " + ex.Message)
        Finally
            data.Close()
            db.Desconectar()
        End Try
        Return objProductos
    End Function
    Public Function llenarLineas() As DataSet
        Dim db As New BaseDatos()
        Dim data As DataSet = Nothing
        Try
            db.Conectar()
            db.CrearComando("SELECT * FROM LINEA", CommandType.Text)
            data = db.ObtenConsulta
        Catch ex As Exception
        Finally
            data.Dispose()
            db.Desconectar()

        End Try
        Return data
    End Function
    '***********FALTANTES ALMACÉN*******************
    Public Function faltantesTodos() As List(Of Faltantes)
        Dim listaFaltantes As New List(Of Faltantes)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "FALTANTES"
            db.CrearComando(sQuery, CommandType.StoredProcedure)

            data = db.EjecutarConsulta()

            Dim idprod = data.GetOrdinal("ID_PRODUCTO")
            Dim codigo = data.GetOrdinal("CODIGO_CLAVE")
            Dim descripcion = data.GetOrdinal("DESCRIPCION")
            Dim costo = data.GetOrdinal("COSTO")
            Dim precio = data.GetOrdinal("PRECIO")
            Dim smin = data.GetOrdinal("STOCK_MIN")
            Dim smax = data.GetOrdinal("STOCK_MAX")
            Dim exist = data.GetOrdinal("EXISTENCIA")
            Dim pzas = data.GetOrdinal("Pieza_caja")
            Dim linea = data.GetOrdinal("DESCRIPCION_LINEA")
            Dim proveedor = data.GetOrdinal("razon_social")


            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Res = New Faltantes(values(idprod), values(codigo), values(descripcion), values(costo), values(precio), values(smin), values(smax), values(exist), values(pzas), values(linea), values(proveedor))
                    listaFaltantes.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            ' data.Close()


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error BD al obtener los productos que faltan en el almacén.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los productos que faltan en el almacén. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()

        End Try
        Return listaFaltantes
    End Function
    '*******FALTANTES POR PRODUCTO
    Public Function faltantesporProducto(ByVal producto As String) As List(Of Faltantes)
        Dim objFalta As New List(Of Faltantes)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim sQuery As String = " SELECT PRODUCTO.ID_PRODUCTO,PRODUCTO.CODIGO_CLAVE,PRODUCTO.DESCRIPCION,PRODUCTO.COSTO,PRODUCTO.PRECIO,PRODUCTO.STOCK_MIN,PRODUCTO.STOCK_MAX,PRODUCTO.EXISTENCIA,PRODUCTO.PIEZA_CAJA,LINEA.DESCRIPCION AS DESCRIPCION_LINEA,  LIST(PROVEEDOR.RAZON_SOCIAL, ', ' ) AS RAZON_SOCIAL FROM producto" &
            "INNER JOIN LINEA ON (PRODUCTO.ID_LINEA = LINEA.ID_LINEA)" &
  "INNER JOIN PRODUCTO_PROVEEDOR ON (PRODUCTO.ID_PRODUCTO = PRODUCTO_PROVEEDOR.ID_PRODUCTO)" &
  "INNER JOIN PROVEEDOR ON (PRODUCTO_PROVEEDOR.ID_PROVEEDOR = PROVEEDOR.ID_PROVEEDOR) WHERE PRODUCTO.STATUS<>0 AND PRODUCTO.EXISTENCIA<=PRODUCTO.STOCK_MIN AND PRODUCTO.ES_PRODUCTO='1' AND UPPER (PRODUCTO.CODIGO_CLAVE COLLATE DE_de||PRODUCTO.DESCRIPCION COLLATE DE_de) LIKE UPPER('%" & producto & "%' COLLATE DE_de) GROUP BY  PRODUCTO.ID_PRODUCTO,   PRODUCTO.CODIGO_CLAVE,  PRODUCTO.DESCRIPCION," & "PRODUCTO.COSTO,   PRODUCTO.PRECIO,   PRODUCTO.STOCK_MIN,   PRODUCTO.STOCK_MAX,   PRODUCTO.EXISTENCIA,   LINEA.DESCRIPCION,  PRODUCTO.PIEZA_CAJA,   PROVEEDOR.RAZON_SOCIAL ORDER BY PRODUCTO.CODIGO_CLAVE"

            db.CrearComando(sQuery, CommandType.Text)

            data = db.EjecutarConsulta()
            Dim idprod = data.GetOrdinal("ID_PRODUCTO")
            Dim codigo = data.GetOrdinal("CODIGO_CLAVE")
            Dim descripcion = data.GetOrdinal("DESCRIPCION")
            Dim costo = data.GetOrdinal("COSTO")
            Dim precio = data.GetOrdinal("PRECIO")
            Dim smin = data.GetOrdinal("STOCK_MIN")
            Dim smax = data.GetOrdinal("STOCK_MAX")
            Dim exist = data.GetOrdinal("EXISTENCIA")
            Dim pzas = data.GetOrdinal("PIEZA_CAJA")
            Dim linea = data.GetOrdinal("DESCRIPCION_LINEA")
            Dim provedor = data.GetOrdinal("razon_social")

            Dim values(data.FieldCount) As Object

            While data.Read
                Try
                    data.GetValues(values)
                    Dim productoF As New Faltantes(values(idprod), values(codigo), values(descripcion), values(costo), values(precio), values(smin), values(smax), values(exist), values(pzas), values(linea), values(provedor))
                    objFalta.Add(productoF)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Inconsistencia de tipo de datos.", ex)
                Catch ex As DataException
                    Throw New ReglasNegocioException("ADO.net Error.", ex)
                End Try
            End While

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error de BD. No se obtuvo algún producto.")
        Catch ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los productos. " + ex.Message)
        Finally
            data.Close()
            db.Desconectar()

        End Try
        Return objFalta
    End Function
    '***********Inventario
    Public Function Inventario(ByVal producto As String, ByVal tipobusqueda As Integer) As List(Of BuscadorProductos)
        Dim objFalta As New List(Of BuscadorProductos)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim sQuery As String = "SELECT PRODUCTO.CODIGO_CLAVE,PRODUCTO.DESCRIPCION,PRODUCTO.COSTO,PRODUCTO.PRECIO,PRODUCTO.PRECIO_MENUDEO,PRODUCTO.EXISTENCIA,PRODUCTO.PIEZA_CAJA,PRODUCTO.STATUS,linea.DESCRIPCION AS LINEA_DESCRIPCION, (PRODUCTO.PRECIO/PRODUCTO.PIEZA_CAJA) as PrecioUnitario FROM producto INNER JOIN LINEA ON (PRODUCTO.ID_LINEA = LINEA.ID_LINEA) "

            Select Case tipobusqueda
                Case 0 'codigo
                    sQuery = sQuery & "WHERE PRODUCTO.CODIGO_CLAVE LIKE '%" & producto & "%'  ORDER BY PRODUCTO.CODIGO_CLAVE , linea.descripcion,producto.descripcion"
                Case 1 'descripcion 
                    sQuery = sQuery & "WHERE PRODUCTO.DESCRIPCION LIKE '%" & producto & "%' ORDER BY linea.descripcion,PRODUCTO.DESCRIPCION"
                Case 2 'actegoria
                    sQuery = sQuery & "WHERE LINEA.DESCRIPCION LIKE '%" & producto & "%' ORDER BY LINEA.DESCRIPCION,PRODUCTO.DESCRIPCION"
                Case 3 'todo
                    sQuery = sQuery & "WHERE PRODUCTO.CODIGO_CLAVE   LIKE '%" & producto & "%'  OR PRODUCTO.DESCRIPCION LIKE '%" & producto & "%' OR LINEA.DESCRIPCION LIKE '%" & producto & "%' ORDER BY LINEA.DESCRIPCION,PRODUCTO.DESCRIPCION"

            End Select

            db.CrearComando(sQuery, CommandType.Text)

            data = db.EjecutarConsulta()
            'Dim idprod = data.GetOrdinal("ID_PRODUCTO")
            Dim codigo = data.GetOrdinal("CODIGO_CLAVE")
            Dim descripcion = data.GetOrdinal("DESCRIPCION")
            Dim costo = data.GetOrdinal("COSTO")
            Dim precio = data.GetOrdinal("PRECIO")
            Dim menudeo = data.GetOrdinal("PRECIO_MENUDEO")
            Dim exist = data.GetOrdinal("EXISTENCIA")
            Dim pzas = data.GetOrdinal("PIEZA_CAJA")
            Dim status = data.GetOrdinal("STATUS")
            Dim linea = data.GetOrdinal("LINEA_DESCRIPCION")
            'Dim id_linea = data.GetOrdinal("ID_LINEA")
            Dim precioUnitario = data.GetOrdinal("precioUnitario")

            Dim values(data.FieldCount) As Object

            While data.Read
                Try
                    data.GetValues(values)
                    Dim productoF As New BuscadorProductos(0, values(codigo), values(descripcion), values(costo), values(precio), values(menudeo), values(exist), values(pzas), values(status), values(linea), 0)
                    productoF.PrecioUnitario = values(precioUnitario)

                    objFalta.Add(productoF)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Inconsistencia de tipo de datos.", ex)
                Catch ex As DataException
                    Throw New ReglasNegocioException("ADO.net Error.", ex)
                End Try
            End While

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error de BD. No se obtuvo algún producto.")
        Catch ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los productos. " + ex.Message)
        Finally
            data.Close()
            db.Desconectar()
        End Try
        Return objFalta
    End Function

    Public Function obtenerProductosVSE()
        Dim productos As New List(Of ProductoVSE)
        Dim datos As FbDataReader = Nothing
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "select producto.codigo_clave,producto.descripcion,producto.existencia," _
            & "producto.costo, producto.precio from producto where existencia < 0 order by producto.existencia asc"
            db.CrearComando(sql, CommandType.Text)

            datos = db.EjecutarConsulta

            Dim values(datos.FieldCount) As Object

            While datos.Read()
                Try
                    datos.GetValues(values)
                    Dim miproducto As New ProductoVSE(datos("codigo_clave"), datos("descripcion"), datos("existencia"), datos("costo"), datos("precio"))
                    productos.Add(miproducto)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            datos.Close()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los productos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
        Return productos
    End Function


    Public Function obtenerProductosProveedor(ByVal idprov As Integer)
        Dim productos As New List(Of ProductoVSE)
        Dim datos As FbDataReader = Nothing
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "select PRODUCTO.CODIGO_CLAVE, producto.DESCRIPCION, " _
            & " producto.existencia,producto.costo,producto.precio from PRODUCTO " _
            & "inner join PRODUCTO_PROVEEDOR on PRODUCTO.ID_PRODUCTO=PRODUCTO_PROVEEDOR.ID_PRODUCTO " _
            & "where PRODUCTO_PROVEEDOR.ID_PROVEEDOR=@IDPROV"
            db.CrearComando(sql, CommandType.Text)
            db.AgregarParametro("@IDPROV", idprov)

            datos = db.EjecutarConsulta

            Dim values(datos.FieldCount) As Object

            While datos.Read()
                Try
                    datos.GetValues(values)
                    Dim miproducto As New ProductoVSE(datos("codigo_clave"), datos("descripcion"), datos("existencia"), datos("costo"), datos("precio"))
                    productos.Add(miproducto)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            datos.Close()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los productos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
            db.Dispose()
        End Try
        Return productos
    End Function

    Public Function ObtenerPorId(ByVal id As Integer) As Producto
        Dim producto As Producto = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Dim datos2 As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select * from producto where id_producto=@id"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", id)
            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try

                    Dim Sql2 As String = "Select * from prod_fracc where id_producto=@id_producto"
                    db.CrearComando(Sql2, CommandType.Text)
                    db.AgregarParametro("@id_producto", datos("id_producto"))
                    datos2 = db.EjecutarConsulta()
                    Dim kg As Boolean = False
                    If datos2.Read Then
                        kg = True
                    End If

                    producto = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("descuento_1"), datos("descuento_2"), datos("iva"), datos("status"), kg)
                    Return producto

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                Finally
                    datos2.Close()
                End Try
            Else
                Throw New ReglasNegocioException("No encontrado")
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function
    Public Function ObtenerIDC(ByVal idP As Integer)
        Dim db As BaseDatos = Nothing
        Dim lista As New List(Of Producto)
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT ID_PRODUCTO,CODIGO_CLAVE,DESCRIPCION,PIEZA_CAJA,COSTO,PRECIO,PRECIO_MENUDEO FROM PRODUCTO WHERE ID_CAJA=@IDP"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@IDP", idP)

            datos = db.EjecutarConsulta()
            Dim valu(datos.FieldCount) As Object

            While datos.Read
                Try
                    datos.GetValues(valu)
                    Dim item As New Producto(datos("ID_PRODUCTO"), datos("CODIGO_CLAVE"), datos("DESCRIPCION"), datos("PIEZA_CAJA"), datos("COSTO"), datos("PRECIO"), datos("PRECIO_MENUDEO"), False)
                    lista.Add(item)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            db.Desconectar()
            datos.Close()
        End Try
        Return lista
    End Function
    Public Function ObtenerIDCGuardar(ByVal idP As Integer, ByRef db As BaseDatos)
        Dim lista As New List(Of Producto)
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT ID_PRODUCTO,CODIGO_CLAVE,DESCRIPCION,PIEZA_CAJA,COSTO,PRECIO,PRECIO_MENUDEO FROM PRODUCTO WHERE ID_CAJA=@IDP"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@IDP", idP)

            datos = db.EjecutarConsulta()
            Dim valu(datos.FieldCount) As Object

            While datos.Read
                Try
                    datos.GetValues(valu)
                    Dim item As New Producto(datos("ID_PRODUCTO"), datos("CODIGO_CLAVE"), datos("DESCRIPCION"), datos("PIEZA_CAJA"), datos("COSTO"), datos("PRECIO"), datos("PRECIO_MENUDEO"), False)
                    lista.Add(item)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
        End Try
        Return lista
    End Function
End Class
