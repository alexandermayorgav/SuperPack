Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Caja
    'Select sum(monto) from caja_detalle where   UPPER (concepto COLLATE DE_de) like  UPPER('" & venta & "' COLLATE DE_de)
    Public Function obtenerTotales(ByVal id_caja As Integer, ByVal concepto As String) As Decimal
        Dim Db As BaseDatos = New BaseDatos()
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select sum(monto) as total from caja_detalle where UPPER (concepto COLLATE DE_de) like  UPPER('" & concepto & "%' COLLATE DE_de) and id_caja=@id_caja"


            Db.Conectar()
            Db.CrearComando(Sql, CommandType.Text)
            Db.AgregarParametro("@id_caja", id_caja)
            ' Db.AgregarParametro("@concepto", concepto)
            datos = Db.EjecutarConsulta()
            Dim total = Datos.GetOrdinal("total")
            Dim values(Datos.FieldCount) As Object

            If Datos.Read Then
                Try
                    Datos.GetValues(values)
                    Return values(total)
                Catch ex As Exception
                    Return 0
                End Try

            Else
                Return 0
            End If


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los totales de la caja. " + Ex.Message)
        Finally
            Datos.Close()
            Db.Desconectar()
        End Try
    End Function
    Public Function obtenerMovimientos(ByVal id_caja As Integer) As List(Of Caja.CajaDetalle)
        Dim Micaja As New List(Of Caja.CajaDetalle)
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "select * from caja_detalle where caja_detalle.id_caja=@id_caja order by fecha desc"
            db = New BaseDatos()
            Db.Conectar()
            Db.CrearComando(Sql, CommandType.Text)
            Db.AgregarParametro("@id_caja", id_caja)
            datos = db.EjecutarConsulta()
            Dim id = Datos.GetOrdinal("id_caja_det")
            Dim idcaja = Datos.GetOrdinal("id_caja")
            Dim monto = Datos.GetOrdinal("monto")
            Dim fecha = Datos.GetOrdinal("fecha")
            Dim concepto = Datos.GetOrdinal("concepto")
            Dim tipo_pago = Datos.GetOrdinal("tipo_pago")

            Dim values(Datos.FieldCount) As Object

            While Datos.Read()
                Try
                    Datos.GetValues(values)
                    Dim caja As New Caja.CajaDetalle(values(id), values(idcaja), values(fecha), values(monto), values(concepto), values(tipo_pago))

                    Micaja.Add(caja)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los movimientos de la caja. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
        Return Micaja
    End Function
    Public Sub actualizar(ByVal id_CAJA As Integer, ByVal fechaCierre As Date)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("update caja  set cerrada=@cerrada,fecha_cierre=@fecha where id_caja=@id_caja and cerrada=0 ", CommandType.Text)
            db.AgregarParametro("@cerrada", 1)
            db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fechaCierre))
            db.AgregarParametro("@ID_CAJA", id_CAJA)
            db.EjecutarComando()


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al cerrar la caja. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Function sumatoria(ByVal id_caja As Integer) As Decimal
    '    Try
    '        Dim Sql As String = "sumaMontoInicialyMonto"
    '        Dim Db As BaseDatos = New BaseDatos()
    '        Db.Conectar()
    '        Db.CrearComando(Sql, CommandType.StoredProcedure)
    '        Db.AgregarParametro("@id_caja", id_caja)
    '        Dim Datos As FbDataReader = Db.EjecutarConsulta()
    '        Dim monto_final = Datos.GetOrdinal("monto_final")
    '        Dim values(Datos.FieldCount) As Object
    '        If Datos.Read() Then
    '            Datos.GetValues(values)
    '            Return values(monto_final)
    '        Else
    '            Return 0
    '        End If
    '        Datos.Close()
    '        Db.Desconectar()
    '    Catch Ex As BaseDatosException
    '        Throw New ReglasNegocioException("Error al acceder a la base de datos.")
    '    Catch Ex As ReglasNegocioException
    '        Throw New ReglasNegocioException("Error a obtener la caja inicial." + Ex.Message)
    '    End Try
    'End Function

    Public Function Insertar(ByRef caja As Caja)
        Dim db As New BaseDatos
        Try

            db.Conectar()
            db.ComenzarTransaccion()

            Dim Sql As String
            Sql = "INSERT INTO caja" _
           & "(id_usuario,fecha_apertura,monto_inicial,cerrada,fecha_cierre)" _
           & " VALUES(@id_usuario,@fecha_apertura,@monto_inicial,@cerrada,@fecha_cierre) RETURNING id_caja"

            Dim fecha As Date = Date.Now
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id_usuario", caja.Id_usuario)
            db.AgregarParametro("@fecha_apertura", Utils.ObtenerFechaHora(fecha))
            db.AgregarParametro("@fecha_cierre", Utils.ObtenerFechaHora(fecha))
            db.AgregarParametro("@cerrada", IIf(caja.Cerrada = False, 0, 1))
            db.AgregarParametro("@monto_inicial", caja.Monto_Inicial)
            caja.Id = db.EjecutarEscalar

            agregarEntrada(db, caja.Monto_Inicial, fecha, "Monto Inicial", caja.Id, "Efectivo")

            db.ConfirmarTransaccion()

        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al guardar la caja inicial. " + Ex.Message)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try
        Return caja.Id
    End Function
    Public Function obtener() As Caja
        Dim micaja As Caja = Nothing
        Dim Db As BaseDatos = New BaseDatos()

        Dim Sql As String = "select caja.*,personal.nombre from caja inner join usuarios on caja.id_usuario=usuarios.id_usuario inner join personal on usuarios.id_personal=personal.id_personal where cerrada=@cerrada"

        Db.Conectar()
        Db.CrearComando(Sql, CommandType.Text)
        '' Db.AgregarParametro("@fecha_apertura", Utils.ObtenerFecha(Date.Now))
        Db.AgregarParametro("@cerrada", 0)
        Dim Datos As FbDataReader = Db.EjecutarConsulta()
        Try
            If Datos.Read() Then
                micaja = New Caja
                micaja.Id = Datos("id_caja")
                micaja.Id_usuario = Datos("id_usuario")
                micaja.Monto_Inicial = Datos("monto_inicial")
                micaja.Cerrada = Datos("cerrada")
                micaja.Fecha_Apertura = Datos("fecha_apertura")
                micaja.Nombre = Datos("nombre")
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error a obtener la caja inicial." + Ex.Message)
        Finally
            Datos.Close()
            Db.Desconectar()
        End Try
        Return micaja
    End Function
    Public Sub agregarEntrada(ByVal db As BaseDatos, ByVal monto As Decimal, ByVal fecha As Date, ByVal concepto As String, ByVal idCaja As Integer, ByVal tipo_pago As String)
        Try

            db.CrearComando("INSERT INTO caja_detalle" _
           & "(id_caja,fecha,monto,concepto,tipo_pago)" _
           & " VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago) ", CommandType.Text)
            db.AgregarParametro("@monto", monto)
            db.AgregarParametro("@id_caja", idCaja)
            db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(fecha))
            db.AgregarParametro("@concepto", concepto)
            db.AgregarParametro("@tipo_pago", tipo_pago)
            db.EjecutarComando()
            'db.Desconectar()
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al agregar la entrada. " + Ex.Message)
        End Try
    End Sub

    Public Sub agregarEfectivo(ByVal monto As Decimal, ByVal concepto As String, ByVal idCaja As Integer)
        Dim Db As BaseDatos = New BaseDatos()
        Try

            Db.Conectar()
            db.CrearComando("INSERT INTO caja_detalle" _
           & "(id_caja,fecha,monto,concepto,tipo_pago)" _
           & " VALUES(@id_caja,@fecha,@monto,@concepto,@tipo_pago) ", CommandType.Text)
            db.AgregarParametro("@monto", monto)
            db.AgregarParametro("@id_caja", idCaja)
            Db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(Date.Now))
            db.AgregarParametro("@concepto", concepto)
            Db.AgregarParametro("@tipo_pago", "Efectivo")
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al agregar la entrada. " + Ex.Message)
        Finally
            Db.Desconectar()
        End Try
    End Sub
End Class
