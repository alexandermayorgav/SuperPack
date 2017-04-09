Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Servicio
    Public Function guardar(ByVal servicio As Servicio) As String
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()

            '**INSERTAR DATOS GENERALES DEL SERVICIO
            Dim sqlServ As String = "INSERT INTO SERVICIO " _
            & "(ID_CLIENTE,CONCECIONARIA,LINEA,TIPO,MODELO,COLOR," _
            & "PLACAS,DIAGNOSTICO,FECHA_RECEPCION,FECHA_ENTREGA," _
            & "ID_PERSONAL,OBSERVACIONES,KILOMETRAJE,FACTURA," _
            & "COMPLETO,MECANICO) values " _
            & "(@IDCLIENTE,@CONCEC,@LINEA,@TIPO,@MODELO,@COLOR," _
            & "@PLACAS,@DIAG,@FECHARECEP,@FECHAENT,@IDPERS," _
            & "@OBSERV,@KM,@FACT,@COMPLETO,@MECANICO) " _
            & "RETURNING ID_SERVICIO"

            db.CrearComando(sqlServ, CommandType.Text)
            db.AgregarParametro("@IDCLIENTE", servicio.Id_Cliente)
            db.AgregarParametro("@CONCEC", servicio.Concecionaria)
            db.AgregarParametro("@LINEA", servicio.Linea)
            db.AgregarParametro("@TIPO", servicio.Tipo)
            db.AgregarParametro("@MODELO", servicio.Modelo)
            db.AgregarParametro("@COLOR", servicio.Color)
            db.AgregarParametro("@PLACAS", servicio.Placas)
            db.AgregarParametro("@DIAG", servicio.Diagnostico)
            db.AgregarParametro("@FECHARECEP", Utils.ObtenerFechaHora(servicio.Fecha_Recepcion))
            db.AgregarParametro("@FECHAENT", Utils.ObtenerFechaHora(servicio.Fecha_Recepcion))
            db.AgregarParametro("@IDPERS", servicio.Id_Personal)
            db.AgregarParametro("@OBSERV", servicio.Observaciones)
            db.AgregarParametro("@KM", servicio.Kilometraje)
            db.AgregarParametro("@FACT", "0")
            db.AgregarParametro("@COMPLETO", "0")
            db.AgregarParametro("@MECANICO", servicio.Mecanico)

            servicio.Id_Servicio = db.EjecutarEscalar


            '**INSERTAR ITEMS DEL SERVICIO
            Dim sqlItem As String = "INSERT INTO SERVICIO_DETALLE " _
            & "(ID_SERVICIO,DESCRIPCION,TIPO,EDO_SERVICIO," _
            & "CANTIDAD,COSTO,PRECIO,ID_PRODUCTO) values(" _
            & "@IDSERV,@DESC,@TIPO,@EDOSERV,@CANT,@COSTO,@PRECIO,@IDPROD) " _
            & "RETURNING ID_SD"

            For Each item As ServicioItem In servicio.Items
                db.CrearComando(sqlItem, CommandType.Text)
                db.AgregarParametro("@IDSERV", servicio.Id_Servicio)
                db.AgregarParametro("@DESC", item.Descripcion)
                db.AgregarParametro("@TIPO", item.Tipo)
                db.AgregarParametro("@EDOSERV", item.Estado)
                db.AgregarParametro("@CANT", item.Cantidad)
                db.AgregarParametro("@COSTO", item.Costo)
                db.AgregarParametro("@PRECIO", item.Precio)
                db.AgregarParametro("@IDPROD", item.IdProducto)

                db.EjecutarComando()
            Next

            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar el servicio.")
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return servicio.Id_Servicio
    End Function

    Public Function actualizar(ByVal servicio As Servicio) As String
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()

            '**INSERTAR DATOS GENERALES DEL SERVICIO
            Dim sqlServ As String = "UPDATE SERVICIO SET " _
            & "ID_CLIENTE=@IDCLIENTE,CONCECIONARIA=@CONCEC,LINEA=@LINEA,TIPO=@TIPO,MODELO=@MODELO," _
            & "COLOR=@COLOR,PLACAS=@PLACAS,DIAGNOSTICO=@DIAG,FECHA_RECEPCION=@FECHARECEP," _
            & "FECHA_ENTREGA=@FECHAENT,ID_PERSONAL=@IDPERS,OBSERVACIONES=@OBSERV,KILOMETRAJE=@KM," _
            & "FACTURA=@FACT,COMPLETO=@COMPLETO,MECANICO=@MECANICO " _
            & "WHERE ID_SERVICIO=@IDSERV"
            
            db.CrearComando(sqlServ, CommandType.Text)
            db.AgregarParametro("@IDSERV", servicio.Id_Servicio)
            db.AgregarParametro("@IDCLIENTE", servicio.Id_Cliente)
            db.AgregarParametro("@CONCEC", servicio.Concecionaria)
            db.AgregarParametro("@LINEA", servicio.Linea)
            db.AgregarParametro("@TIPO", servicio.Tipo)
            db.AgregarParametro("@MODELO", servicio.Modelo)
            db.AgregarParametro("@COLOR", servicio.Color)
            db.AgregarParametro("@PLACAS", servicio.Placas)
            db.AgregarParametro("@DIAG", servicio.Diagnostico)
            db.AgregarParametro("@FECHARECEP", Utils.ObtenerFechaHora(servicio.Fecha_Recepcion))
            db.AgregarParametro("@FECHAENT", Utils.ObtenerFechaHora(servicio.Fecha_Recepcion))
            db.AgregarParametro("@IDPERS", servicio.Id_Personal)
            db.AgregarParametro("@OBSERV", servicio.Observaciones)
            db.AgregarParametro("@KM", servicio.Kilometraje)
            If servicio.Factura Then
                db.AgregarParametro("@FACT", "1")
            Else
                db.AgregarParametro("@FACT", "0")
            End If

            If servicio.Completo Then
                db.AgregarParametro("@COMPLETO", "1")
            Else
                db.AgregarParametro("@COMPLETO", "0")
            End If

            db.AgregarParametro("@MECANICO", servicio.Mecanico)

            db.EjecutarComando()


            '**INSERTAR ITEMS DEL SERVICIO
            Dim sqlItem As String = "INSERT INTO SERVICIO_DETALLE " _
            & "(ID_SERVICIO,DESCRIPCION,TIPO,EDO_SERVICIO," _
            & "CANTIDAD,COSTO,PRECIO,ID_PRODUCTO) values(" _
            & "@IDSERV,@DESC,@TIPO,@EDOSERV,@CANT,@COSTO,@PRECIO,@IDPROD) " _
            & "RETURNING ID_SD"

            For Each item As ServicioItem In servicio.Items
                db.CrearComando(sqlItem, CommandType.Text)
                db.AgregarParametro("@IDSERV", servicio.Id_Servicio)
                db.AgregarParametro("@DESC", item.Descripcion)
                db.AgregarParametro("@TIPO", item.Tipo)
                db.AgregarParametro("@EDOSERV", item.Estado)
                db.AgregarParametro("@CANT", item.Cantidad)
                db.AgregarParametro("@COSTO", item.Costo)
                db.AgregarParametro("@PRECIO", item.Precio)
                db.AgregarParametro("@IDPROD", item.IdProducto)

                db.EjecutarComando()
            Next

            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar el servicio.")
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return servicio.Id_Servicio
    End Function

    Public Function obtener(ByVal ids As String) As Servicio
        Dim db As BaseDatos = Nothing
        Dim serv As Servicio = Nothing
        Dim s As FbDataReader = Nothing
        Dim sitems As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            '**OBTENER SERVICIO
            Dim sqlserv As String = "SELECT SERVICIO.*,CLIENTE.RAZON_SOCIAL FROM SERVICIO " _
            & "INNER JOIN CLIENTE ON SERVICIO.ID_CLIENTE=CLIENTE.ID_CLIENTE " _
            & "WHERE ID_SERVICIO=@ID"
            db.CrearComando(sqlserv, CommandType.Text)
            db.AgregarParametro("@ID", ids)
            s = db.EjecutarConsulta

            Dim idserv = s.GetOrdinal("ID_SERVICIO")
            Dim idc = s.GetOrdinal("ID_CLIENTE")
            Dim cliente = s.GetOrdinal("RAZON_SOCIAL")
            Dim conc = s.GetOrdinal("CONCECIONARIA")
            Dim lin = s.GetOrdinal("LINEA")
            Dim tipo = s.GetOrdinal("TIPO")
            Dim modelo = s.GetOrdinal("MODELO")
            Dim color = s.GetOrdinal("COLOR")
            Dim placas = s.GetOrdinal("PLACAS")
            Dim diag = s.GetOrdinal("DIAGNOSTICO")
            Dim fechare = s.GetOrdinal("FECHA_RECEPCION")
            Dim fechaent = s.GetOrdinal("FECHA_ENTREGA")
            'Dim idpers = s.GetOrdinal("ID_PERSONAL")
            Dim pers = s.GetOrdinal("ID_PERSONAL")
            Dim obs = s.GetOrdinal("OBSERVACIONES")
            Dim km = s.GetOrdinal("KILOMETRAJE")
            Dim fact = s.GetOrdinal("FACTURA")
            Dim comp = s.GetOrdinal("COMPLETO")
            Dim mec = s.GetOrdinal("MECANICO")

            Dim vals(s.FieldCount) As Object

            If s.Read Then
                Try
                    s.GetValues(vals)
                    serv = New Servicio(vals(idserv), vals(idc), vals(cliente), vals(conc), vals(lin), vals(tipo), vals(modelo), vals(color), vals(placas), vals(diag), vals(fechare), vals(fechaent), vals(pers), vals(obs), vals(km), vals(fact), vals(comp), vals(mec))

                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.net", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No existe el servicio correspondiente al folio proporcionado.")
            End If
            s.Close()

            '**OBTENER ITEMS DEL SERVICIO
            Dim sqlitems As String = "SELECT SERVICIO_DETALLE.* " _
            & "FROM SERVICIO_DETALLE WHERE ID_SERVICIO=@IDS"

            db.CrearComando(sqlitems, CommandType.Text)
            db.AgregarParametro("@IDS", ids)

            sitems = db.EjecutarConsulta
            Dim idsd = sitems.GetOrdinal("ID_SD")
            Dim idse = sitems.GetOrdinal("ID_SERVICIO")
            Dim desc = sitems.GetOrdinal("DESCRIPCION")
            Dim tip = sitems.GetOrdinal("TIPO")
            Dim edo = sitems.GetOrdinal("EDO_SERVICIO")
            Dim canti = sitems.GetOrdinal("CANTIDAD")
            Dim cost = sitems.GetOrdinal("COSTO")
            Dim prec = sitems.GetOrdinal("PRECIO")
            Dim idprod = sitems.GetOrdinal("ID_PRODUCTO")

            Dim val(sitems.FieldCount) As Object
            
            While sitems.Read
                Try
                    sitems.GetValues(val)

                    Dim item As New ServicioItem(val(idsd), val(idse), val(desc), val(tip), val(edo), val(canti), val(cost), val(prec), val(idprod))

                    serv.Items.Add(item)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.net", Ex)
                End Try
            End While
            sitems.Close()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el servicio")
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return serv
    End Function
    Public Function getAutos(ByVal id_cliente) As List(Of Servicio)
        Dim db As BaseDatos = Nothing
        Dim autos As FbDataReader = Nothing
        Dim serv As List(Of Servicio)
        Try
            db = New BaseDatos
            serv = New List(Of Servicio)
            Dim sqlitems As String = "SELECT CONCECIONARIA,LINEA,TIPO,MODELO,COLOR,PLACAS " _
            & "FROM SERVICIO WHERE ID_CLIENTE=@ID GROUP BY CONCECIONARIA,LINEA,TIPO,MODELO,COLOR,PLACAS"

            db.Conectar()
            db.CrearComando(sqlitems, CommandType.Text)
            db.AgregarParametro("@ID", id_cliente)

            autos = db.EjecutarConsulta

            Dim conc = autos.GetOrdinal("CONCECIONARIA")
            Dim lin = autos.GetOrdinal("LINEA")
            Dim tip = autos.GetOrdinal("TIPO")
            Dim mode = autos.GetOrdinal("MODELO")
            Dim color = autos.GetOrdinal("COLOR")
            Dim placas = autos.GetOrdinal("PLACAS")
            ' Dim km = autos.GetOrdinal("KILOMETRAJE")

            Dim vals(autos.FieldCount) As Object

            While autos.Read
                Try
                    autos.GetValues(vals)

                    Dim auto As New Servicio(vals(conc), vals(lin), vals(tip), vals(mode), vals(color), vals(placas))
                    serv.Add(auto)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.net", Ex)
                End Try
            End While

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el servicio")
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return serv
    End Function

    Public Function getServicios(ByVal id_cliente) As List(Of Servicio)
        Dim db As BaseDatos = Nothing
        Dim servs As FbDataReader = Nothing
        Dim servl As List(Of Servicio)
        Try
            db = New BaseDatos
            servl = New List(Of Servicio)
            Dim sqlitems As String = "SELECT ID_SERVICIO,LINEA,MODELO,COLOR,PLACAS,FECHA_RECEPCION," _
            & " FECHA_ENTREGA,COMPLETO " _
            & "FROM SERVICIO WHERE ID_CLIENTE=@ID"

            db.Conectar()
            db.CrearComando(sqlitems, CommandType.Text)
            db.AgregarParametro("@ID", id_cliente)

            servs = db.EjecutarConsulta

            Dim id = servs.GetOrdinal("ID_SERVICIO")
            Dim lin = servs.GetOrdinal("LINEA")
            Dim mode = servs.GetOrdinal("MODELO")
            Dim color = servs.GetOrdinal("COLOR")
            Dim placas = servs.GetOrdinal("PLACAS")
            Dim fecharec = servs.GetOrdinal("FECHA_RECEPCION")
            Dim fechaent = servs.GetOrdinal("FECHA_ENTREGA")
            Dim comp = servs.GetOrdinal("COMPLETO")

            Dim vals(servs.FieldCount) As Object

            While servs.Read
                Try
                    servs.GetValues(vals)
                    If vals(fecharec) = vals(fechaent) Then
                        vals(fechaent) = Nothing
                    End If
                    Dim serv As New Servicio(vals(id), vals(lin), vals(mode), vals(color), vals(placas), vals(fecharec), vals(fechaent), vals(comp))
                    servl.Add(serv)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.net", Ex)
                End Try
            End While

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el servicio")
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return servl
    End Function

    Public Function obtenerItemsServicio(ByVal id_serv As Integer) As List(Of ItemServicio)

        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try

            db = New BaseDatos
            db.Conectar()
            Dim sqlGEN As String = "SELECT " _
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
            & "servicios_prods.ID_SP ," _
            & "servicios_prods.ID_SERVICIO" _
            & "    FROM " _
            & "       servicios_prods " _
            & " INNER JOIN PRODUCTO ON (servicios_prods.ID_PRODUCTO = PRODUCTO.ID_PRODUCTO) where ID_SERVICIO=@ID_SERV"
            db.CrearComando(sqlGEN, CommandType.Text)
            db.AgregarParametro("@ID_SERV", id_serv)
            datos = db.EjecutarConsulta()
            Dim items As New List(Of ItemServicio)
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

            Return items
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
    End Function
    Public Sub eliminarServDet(ByVal idsd As Integer)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("DELETE FROM SERVICIO_DETALLE " _
            & " WHERE ID_SD=@ID", CommandType.Text)
            db.AgregarParametro("@ID", idsd)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al borrar el servicio detalle." + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try

    End Sub
    Public Sub actCantServDet(ByVal idsd As Integer)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("UPDATE SERVICIO_DETALLE SET CANTIDAD=CANTIDAD-1 " _
            & " WHERE ID_SD=@ID", CommandType.Text)
            db.AgregarParametro("@ID", idsd)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al borrar el servicio detalle." + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try

    End Sub

    Public Sub actCantServDetSum(ByVal idsd As Integer)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("UPDATE SERVICIO_DETALLE SET CANTIDAD=CANTIDAD+1 " _
            & " WHERE ID_SD=@ID", CommandType.Text)
            db.AgregarParametro("@ID", idsd)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al agregar el servicio detalle." + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try

    End Sub

    Public Sub actEstadoServicio(ByVal valor As String, ByVal idsd As String)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("UPDATE SERVICIO_DETALLE SET EDO_SERVICIO=@VALOR " _
            & " WHERE ID_SD=@ID", CommandType.Text)
            db.AgregarParametro("@VALOR", valor)
            db.AgregarParametro("@ID", idsd)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar el estado del servicio detalle." + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try

    End Sub

    Public Sub actEstadoRefa(ByVal valor As String, ByVal idsd As String, ByVal item As ServicioItem, ByVal dec As Boolean)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando("UPDATE SERVICIO_DETALLE SET EDO_SERVICIO=@VALOR " _
            & " WHERE ID_SD=@ID", CommandType.Text)
            db.AgregarParametro("@VALOR", valor)
            db.AgregarParametro("@ID", idsd)
            db.EjecutarComando()

            If dec Then
                decAlmacen(db, item, "select existencia from producto where id_producto=@prod")
            Else
                incAlmacen(db, item, "select existencia from producto where id_producto=@prod")
            End If


            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al actualizar el estado del servicio detalle. " + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try

    End Sub

    Public Sub decAlmacen(ByRef db As BaseDatos, ByRef item As ServicioItem, ByVal sql As String)

        db.CrearComando(sql, CommandType.Text)
        db.AgregarParametro("@prod", item.IdProducto)
        Dim qres As FbDataReader
        Dim existenciaactual As Integer
        qres = db.EjecutarConsulta

        If qres.Read Then
            existenciaactual = qres("existencia")
        End If
        qres.Close()
        'existenciaactual = 0
        'If existenciaactual >= item.Cantidad Then
        db.CrearComando("update producto set existencia=@existencia where id_producto=@idprodu", CommandType.Text)
        db.AgregarParametro("@existencia", existenciaactual - item.Cantidad)
        db.AgregarParametro("@idprodu", item.IdProducto)
        db.EjecutarComando()
        'Else
        'Throw New ReglasNegocioException("No se puede surtir el producto: " & item.Descripcion & " , ya que la existencia en almacen es de: " & existenciaactual)
        'End If
       
    End Sub

    Public Sub incAlmacen(ByRef db As BaseDatos, ByRef item As ServicioItem, ByVal sql As String)

        db.CrearComando(sql, CommandType.Text)
        db.AgregarParametro("@prod", item.IdProducto)
        Dim qres As FbDataReader
        Dim existenciaactual As Integer
        qres = db.EjecutarConsulta

        If qres.Read Then
            existenciaactual = qres("existencia")
        End If
        qres.Close()

        db.CrearComando("update producto set existencia=@existencia where id_producto=@idprodu", CommandType.Text)
        db.AgregarParametro("@existencia", existenciaactual + item.Cantidad)
        db.AgregarParametro("@idprodu", item.IdProducto)
        db.EjecutarComando()
    End Sub

    Public Sub servicioCompleto(ByVal ids As Integer, ByVal band As Boolean)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            If band Then
                db.CrearComando("UPDATE SERVICIO SET COMPLETO=1, fecha_entrega=@FECHA " _
            & " WHERE ID_SERVICIO=@ID", CommandType.Text)
            Else
                db.CrearComando("UPDATE SERVICIO SET COMPLETO=0, fecha_entrega=fecha_recepcion" _
            & " WHERE ID_SERVICIO=@ID", CommandType.Text)
            End If
            
            db.AgregarParametro("@ID", ids)
            db.AgregarParametro("@FECHA", Utils.ObtenerFechaHora(Date.Now))
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar el servicio." + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try

    End Sub
    Public Sub generoFactura(ByVal ids As Integer)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()


            db.CrearComando("UPDATE SERVICIO SET FACTURA=1 " _
            & " WHERE ID_SERVICIO=@ID", CommandType.Text)
            

            db.AgregarParametro("@ID", ids)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar el servicio." + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try

    End Sub

    Public Function obtenerTodos() As List(Of Servicio)
        Dim db As BaseDatos = Nothing
        Dim servs As List(Of Servicio) = Nothing
        Dim s As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            servs = New List(Of Servicio)
            '**OBTENER SERVICIO
            Dim sqlserv As String = "SELECT SERVICIO.*,CLIENTE.RAZON_SOCIAL FROM SERVICIO " _
            & "INNER JOIN CLIENTE ON SERVICIO.ID_CLIENTE=CLIENTE.ID_CLIENTE "
            db.CrearComando(sqlserv, CommandType.Text)
            s = db.EjecutarConsulta

            Dim idserv = s.GetOrdinal("ID_SERVICIO")
            Dim idc = s.GetOrdinal("ID_CLIENTE")
            Dim cliente = s.GetOrdinal("RAZON_SOCIAL")
            Dim conc = s.GetOrdinal("CONCECIONARIA")
            Dim lin = s.GetOrdinal("LINEA")
            Dim tipo = s.GetOrdinal("TIPO")
            Dim modelo = s.GetOrdinal("MODELO")
            Dim color = s.GetOrdinal("COLOR")
            Dim placas = s.GetOrdinal("PLACAS")
            Dim diag = s.GetOrdinal("DIAGNOSTICO")
            Dim fechare = s.GetOrdinal("FECHA_RECEPCION")
            Dim fechaent = s.GetOrdinal("FECHA_ENTREGA")
            'Dim idpers = s.GetOrdinal("ID_PERSONAL")
            Dim pers = s.GetOrdinal("ID_PERSONAL")
            Dim obs = s.GetOrdinal("OBSERVACIONES")
            Dim km = s.GetOrdinal("KILOMETRAJE")
            Dim fact = s.GetOrdinal("FACTURA")
            Dim comp = s.GetOrdinal("COMPLETO")
            Dim mec = s.GetOrdinal("MECANICO")

            Dim vals(s.FieldCount) As Object


            While s.Read
                Try
                    s.GetValues(vals)
                    Dim serv As Servicio = New Servicio(vals(idserv), vals(idc), vals(cliente), vals(conc), vals(lin), vals(tipo), vals(modelo), vals(color), vals(placas), vals(diag), vals(fechare), vals(fechaent), vals(pers), vals(obs), vals(km), vals(fact), vals(comp), vals(mec))
                    servs.Add(serv)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.net", Ex)
                End Try
            End While
           
            s.Close()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el servicio")
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return servs
    End Function
End Class
