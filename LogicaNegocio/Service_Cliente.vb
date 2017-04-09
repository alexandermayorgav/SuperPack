Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Cliente

    Dim _datos As BaseDatos = Nothing
    Public Sub IniciarBusqueda()
        _datos = New BaseDatos
        _datos.Conectar()
    End Sub
    Public Sub FinalizarBusqueda()
        _datos.Desconectar()
        _datos.Dispose()
    End Sub
    Public Sub insertar(ByVal cliente As Cliente)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()

            Dim Sql As String
            Sql = "INSERT INTO  cliente " _
           & "(razon_social,rfc,calle,num_int,num_ext,colonia,cp,telefono,ciudad,id_estado,status,descuento)" _
           & " VALUES(@razon,@rfc,@calle,@num_int,@num_ext,@colonia,@cp,@telefono,@ciudad,@id_estado,@status,@descuento) RETURNING id_cliente"

            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@razon", cliente.Razon)
            db.AgregarParametro("@rfc", cliente.RFC)
            db.AgregarParametro("@calle", cliente.Calle)
            db.AgregarParametro("@num_int", cliente.Num_int)
            db.AgregarParametro("@num_ext", cliente.Num_ext)
            db.AgregarParametro("@colonia", cliente.Colonia)
            db.AgregarParametro("@cp", cliente.CP)
            db.AgregarParametro("@telefono", cliente.Telefono)
            db.AgregarParametro("@ciudad", cliente.Ciudad)
            db.AgregarParametro("@id_estado", cliente.Id_estado)
            db.AgregarParametro("@status", IIf(cliente.Status = True, 1, 0))
            db.AgregarParametro("@descuento", cliente.Descuento)
            cliente.Id = db.EjecutarEscalar()

            If cliente.CreditoActivo Then
                insertar_credito(cliente.Id, cliente.Fecha, cliente.Limite, IIf(cliente.CreditoActivo = True, 1, 0), db, cliente.Saldo)
            End If

            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
    Public Function ObtenerMax() As Integer
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select max (id_cliente) as id_cliente  from cliente"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)

            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try

                    Return datos("id_cliente")

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
    Public Function Obtener(ByVal id As Integer) As Cliente
        Dim cliente As Cliente = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Dim datos2 As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select cliente.*,estado.* from cliente inner join  estado on estado.id_estado=cliente.id_estado  where cliente.id_cliente=@id"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", id)
            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try
                    Dim Sql2 As String = "Select * from creditos where id_cliente=@id"
                    db.CrearComando(Sql2, CommandType.Text)
                    db.AgregarParametro("@id", datos("id_cliente"))
                    datos2 = db.EjecutarConsulta()
                    Dim creditoActivo = datos2.GetOrdinal("activo")
                    Dim fecha = datos2.GetOrdinal("fecha_apertura")
                    Dim limite = datos2.GetOrdinal("limite")
                    Dim id_credito = datos2.GetOrdinal("id_credito")
                    Dim saldo = datos2.GetOrdinal("saldo")
                    Dim valores(datos.FieldCount) As Object
                    If datos2.Read() Then
                        datos2.GetValues(valores)
                    End If
                    cliente = New Cliente(datos("id_cliente"), datos("razon_social"), datos("rfc"), datos("calle"), datos("num_int"), datos("num_ext"), datos("colonia"), datos("cp"), datos("telefono"), datos("ciudad"), datos("id_estado"), datos("status"), datos("descuento"), valores(creditoActivo), valores(fecha), valores(limite), valores(id_credito), valores(saldo))
                    cliente.NombreEstado = datos("estado")
                    Return cliente
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                Finally
                    datos2.Close()
                End Try
            Else
                Throw New ReglasNegocioException("No existe.")
            End If
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el cliente. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function
    Private Sub insertar_credito(ByVal id As Integer, ByVal fecha As Date, ByVal limite As Decimal, ByVal activo As Integer, ByVal db As BaseDatos, ByVal saldo As Decimal)
        Try
            Dim Sql4 As String
            Sql4 = "INSERT INTO  creditos " _
           & "(id_cliente,fecha_apertura,limite,activo,saldo)" _
           & " VALUES(@id_cliente,@fecha,@limite,@activo,@saldo) RETURNING id_credito "

            db.CrearComando(Sql4, CommandType.Text)
            db.AgregarParametro("@id_cliente", id)
            db.AgregarParametro("@fecha", (Utils.ObtenerFechaHora(fecha)))
            db.AgregarParametro("@limite", limite)
            db.AgregarParametro("@activo", activo)
            db.AgregarParametro("@saldo", saldo)
            Dim id_credito As Integer = db.EjecutarEscalar
        Catch ex As Exception
            'MsgBox(ex.Message)
            Throw New ReglasNegocioException("Error al guardar el credito")
        End Try

    End Sub
    Public Sub actualizar(ByVal cliente As Cliente)
        Dim db As New BaseDatos
        Dim datos As FbDataReader = Nothing
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando("update cliente set razon_social=@razon,rfc=@rfc,calle=@calle,num_int=@num_int,num_ext=@num_ext,colonia=@colonia,cp=@cp,telefono=@telefono,ciudad=@ciudad,id_estado=@id_estado,status=@status,descuento=@descuento where id_cliente=@id_cliente  ", CommandType.Text)
            db.AgregarParametro("@razon", cliente.Razon)
            db.AgregarParametro("@rfc", cliente.RFC)
            db.AgregarParametro("@calle", cliente.Calle)
            db.AgregarParametro("@num_int", cliente.Num_int)
            db.AgregarParametro("@num_ext", cliente.Num_ext)
            db.AgregarParametro("@colonia", cliente.Colonia)
            db.AgregarParametro("@cp", cliente.CP)
            db.AgregarParametro("@telefono", cliente.Telefono)
            db.AgregarParametro("@ciudad", cliente.Ciudad)
            db.AgregarParametro("@id_estado", cliente.Id_estado)
            db.AgregarParametro("@status", IIf(cliente.Status, 1, 0))
            db.AgregarParametro("@descuento", cliente.Descuento)
            db.AgregarParametro("@id_cliente", cliente.Id)
            db.EjecutarComando()

            Dim Sql As String = "Select * from creditos where id_cliente=@id"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", cliente.Id)
            datos = db.EjecutarConsulta()

            If datos.Read() Then
                db.CrearComando("update creditos  set limite=@limite,activo=@activo, saldo=@saldo, fecha_act = @fecha_act where id_cliente=@id_cliente  ", CommandType.Text)
                db.AgregarParametro("@limite", cliente.Limite)
                db.AgregarParametro("@id_cliente", cliente.Id)
                db.AgregarParametro("@activo", IIf(cliente.CreditoActivo = True, 1, 0))
                db.AgregarParametro("@saldo", cliente.Saldo)
                db.AgregarParametro("@fecha_act", Utils.ObtenerFechaHora (date.Now))
                db.EjecutarComando()
            Else
                insertar_credito(cliente.Id, cliente.Fecha, cliente.Limite, IIf(cliente.CreditoActivo = True, 1, 0), db, cliente.Saldo)
            End If
            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.Desconectar()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.Desconectar()
            Throw New ReglasNegocioException("Error al actualizar los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
    End Sub

    Public Function obtener_Clientes(ByVal razon_social As String) As List(Of Cliente)
        Dim clientes As New List(Of Cliente)
        Dim datos2 As FbDataReader = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "select cliente.*,CREDITOS.ID_CLIENTE as id,CREDITOS.FECHA_APERTURA,creditos.ID_CREDITO,CREDITOS.SALDO,CREDITOS.ACTIVO,CREDITOS.LIMITE  from cliente left join CREDITOS on cliente.ID_CLIENTE= CREDITOS.ID_CLIENTE  WHERE UPPER (cliente.razon_social COLLATE DE_de) like  UPPER('%" & razon_social & "%' COLLATE DE_de)"

            _datos.CrearComando(Sql, CommandType.StoredProcedure)
            datos = _datos.EjecutarConsulta()

            Dim id_cliente = Datos.GetOrdinal("id_cliente")
            Dim razon = Datos.GetOrdinal("razon_social")
            Dim rfc = Datos.GetOrdinal("rfc")
            Dim calle = Datos.GetOrdinal("calle")
            Dim num_int = Datos.GetOrdinal("num_int")
            Dim num_ext = Datos.GetOrdinal("num_ext")
            Dim colonia = Datos.GetOrdinal("colonia")
            Dim cp = Datos.GetOrdinal("cp")
            Dim telefono = Datos.GetOrdinal("telefono")
            Dim ciudad = Datos.GetOrdinal("ciudad")
            Dim id_estado = Datos.GetOrdinal("id_estado")
            Dim status = Datos.GetOrdinal("status")
            Dim descuento = Datos.GetOrdinal("descuento")
            Dim creditoActivo = datos.GetOrdinal("activo")
            Dim fecha = datos.GetOrdinal("fecha_apertura")
            Dim limite = datos.GetOrdinal("limite")
            Dim id_credito = datos.GetOrdinal("id_credito")
            Dim saldo = datos.GetOrdinal("saldo")

            Dim values(Datos.FieldCount) As Object

            While Datos.Read()
                Try
                    Datos.GetValues(values)

                    'Dim Sql2 As String = "Select * from creditos where id_cliente=@id"

                    '_datos.CrearComando(Sql2, CommandType.Text)
                    '_datos.AgregarParametro("@id", values(id_cliente))
                    'datos2 = _datos.EjecutarConsulta()

                    'Dim creditoActivo = datos2.GetOrdinal("activo")
                    'Dim fecha = datos2.GetOrdinal("fecha_apertura")
                    'Dim limite = datos2.GetOrdinal("limite")
                    'Dim id_credito = datos2.GetOrdinal("id_credito")
                    'Dim saldo = datos2.GetOrdinal("saldo")

                    'Dim valores(datos2.FieldCount) As Object
                    'If datos2.Read() Then
                    '    datos2.GetValues(valores)
                    'End If
                    'datos2.Close()
                    'Dim cliente As New Cliente(values(id_cliente), values(razon), values(rfc), values(calle), values(num_int), values(num_ext), values(colonia), values(cp), values(telefono), values(ciudad), values(id_estado), values(status), values(descuento), valores(creditoActivo), valores(fecha), valores(limite), valores(id_credito), valores(saldo))
                    Dim cliente As New Cliente(values(id_cliente), values(razon), values(rfc), values(calle), values(num_int), values(num_ext), values(colonia), values(cp), values(telefono), values(ciudad), values(id_estado), values(status), values(descuento), IIf(IsDBNull(values(creditoActivo)), False, values(creditoActivo)), IIf(IsDBNull(values(fecha)), Date.Now, values(fecha)), IIf(IsDBNull(values(limite)), 0, values(limite)), IIf(IsDBNull(values(id_credito)), -1, values(id_credito)), IIf(IsDBNull(values(saldo)), 0, values(saldo)))

                    clientes.Add(cliente)


                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                Finally
                    'datos2.Close()
                End Try
            End While


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los clientes. " + Ex.Message)
        Finally
            datos.Close()

        End Try
        Return clientes
    End Function

    Public Function obtener_Estados() As DataSet
        Dim db As New BaseDatos()
        Dim data As DataSet = Nothing
        Try

            db.Conectar()
            db.CrearComando("select * from estado order by id_estado ", CommandType.Text)
            data = db.ObtenConsulta
            Return data
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los estados. " + Ex.Message)
        Finally
            data.Dispose()
            db.Desconectar()
        End Try
    End Function


    Public Sub insertar_abono(ByVal id_credito As Integer, ByVal fecha As Date, ByVal abono As Decimal, ByVal saldo As Decimal, ByVal id_caja As Integer, ByVal vales As List(Of Vales), ByVal tarjeta As List(Of Tarjeta), ByVal efectivo As Decimal)
        Dim db As New BaseDatos
        Try

            db.Conectar()
            db.ComenzarTransaccion()
            Dim Sql4 As String
            Sql4 = "INSERT INTO  abono_credito " _
           & "(id_credito,fecha,abono)" _
           & " VALUES(@id_credito,@fecha,@abono) "

            db.CrearComando(Sql4, CommandType.Text)
            db.AgregarParametro("@id_credito", id_credito)
            db.AgregarParametro("@fecha", (Utils.ObtenerFechaHora(fecha)))
            db.AgregarParametro("@abono", abono)
            db.EjecutarComando()

            db.CrearComando("update creditos  set  saldo=@saldo where id_credito=@id_credito  ", CommandType.Text)
            db.AgregarParametro("@saldo", saldo)
            db.AgregarParametro("@id_credito", id_credito)
            db.EjecutarComando()

            If efectivo > 0 Then
                Dim sqlCaja = "INSERT INTO caja_detalle" _
           & "(id_caja,fecha,monto,concepto,tipo_pago)" _
           & "VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago)"
                db.CrearComando(sqlCaja, CommandType.Text)
                db.AgregarParametro("@id_caja", id_caja)
                db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fecha))
                db.AgregarParametro("@monto", efectivo)
                db.AgregarParametro("@concepto", "Abono Credito: " & id_credito)
                db.AgregarParametro("@tipo_pago", "Efectivo")
                db.EjecutarComando()
            End If

            If Not tarjeta Is Nothing Then
                For Each tar As Tarjeta In tarjeta
                    Dim sqlCaja = "INSERT INTO caja_detalle" _
           & "(id_caja,fecha,monto,concepto,tipo_pago)" _
           & "VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago)"
                    db.CrearComando(sqlCaja, CommandType.Text)
                    db.AgregarParametro("@id_caja", id_caja)
                    db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fecha))
                    db.AgregarParametro("@monto", tar.Monto)
                    db.AgregarParametro("@concepto", "Abono Credito: " & id_credito & "/No.Op: " & tar.NumeroOperacion)
                    db.AgregarParametro("@tipo_pago", "Tarjeta")
                    db.EjecutarComando()
                Next
            End If

            If Not vales Is Nothing Then
                For Each vale As Vales In vales
                    Dim sqlCaja = "INSERT INTO caja_detalle" _
           & "(id_caja,fecha,monto,concepto,tipo_pago)" _
           & "VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago)"
                    db.CrearComando(sqlCaja, CommandType.Text)
                    db.AgregarParametro("@id_caja", id_caja)
                    db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fecha))
                    db.AgregarParametro("@monto", vale.MontoUsar)
                    db.AgregarParametro("@concepto", "Abono Credito: " & id_credito & "/Folio V:" & vale.Folio)
                    db.AgregarParametro("@tipo_pago", "Vale")
                    db.EjecutarComando()
                Next

                Dim SVale As New Service_Vale

                If vales.Count > 0 Then
                    For Each item As Vales In vales
                        item.MontoActual = item.MontoRestante
                        SVale.DescontarVale(item)
                    Next
                End If
            End If
            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            db.Desconectar()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            db.Desconectar()
            Throw New ReglasNegocioException("Error al guardar el abono. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub



    Public Function obtener_abonos(ByVal idCredito As Integer) As List(Of Abono)
        Dim abonos As New List(Of Abono)
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "select * from abono_credito where id_credito =@id_credito order by fecha desc"
            db = New BaseDatos()
            Db.Conectar()
            Db.CrearComando(Sql, CommandType.Text)
            Db.AgregarParametro("@id_credito", idCredito)
            datos = db.EjecutarConsulta()
            Dim id = Datos.GetOrdinal("id_abono")
            Dim id_credito = Datos.GetOrdinal("id_credito")
            Dim fecha = Datos.GetOrdinal("fecha")
            Dim abono = Datos.GetOrdinal("abono")

            Dim values(Datos.FieldCount) As Object

            While Datos.Read()
                Try
                    Datos.GetValues(values)
                    Dim item As New Abono(values(id), values(id_credito), values(fecha), values(abono))

                    abonos.Add(item)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los abonos. " + Ex.Message)
        Finally
            Datos.Close()
            db.Desconectar()
        End Try
        Return abonos
    End Function

    Public Sub eliminar(ByVal idCliente As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            Dim Sql As String
            Sql = "delete from cliente where id_cliente = @idCliente "
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@idCliente", idCliente)
            db.EjecutarComando()
            db.ConfirmarTransaccion()
        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

End Class
