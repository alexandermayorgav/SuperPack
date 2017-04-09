Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_CuentaPagar
    Dim _datos As BaseDatos = Nothing
    Public Sub IniciarBusqueda()
        _datos = New BaseDatos
        _datos.Conectar()
    End Sub
    Public Sub FinalizarBusqueda()
        _datos.Desconectar()
        _datos.Dispose()
    End Sub
    Public Sub insertar(ByVal cantidadabono As Decimal, ByVal idcredito As Integer, ByVal creditopagado As Boolean)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            Dim Sql As String
            Sql = "INSERT INTO ABONO_PROVEEDOR " _
           & "(ID_CREDITO,FECHA,ABONO) " _
           & " VALUES (@idcredito,@fecha,@abono) RETURNING ID_ABONO"

            Dim fecha As Date = Utils.ObtenerFechaHora(Date.Now)
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@idcredito", idcredito)
            db.AgregarParametro("@fecha", fecha)
            db.AgregarParametro("@abono", cantidadabono)
            db.EjecutarEscalar()

            If creditopagado = True Then
                db.CrearComando("update CUENTAS_PAGAR set PAGADO=@c where ID_CREDITO=@idcredito", CommandType.Text)
                db.AgregarParametro("@c", 1)
                db.AgregarParametro("@idcredito", idcredito)
                db.EjecutarComando()
            End If

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
    End Sub
    Public Function obtenerAbonosCreditos(ByVal idcredito As Integer) As List(Of CAbonoCuentaPagar)
        Dim db As BaseDatos = Nothing
        Dim rows As FbDataReader = Nothing
        Dim abonos As List(Of CAbonoCuentaPagar) = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            abonos = New List(Of CAbonoCuentaPagar)
            Dim getC As String = "SELECT * FROM ABONO_PROVEEDOR WHERE ID_CREDITO=@idcredito"
            db.CrearComando(getC, CommandType.Text)
            db.AgregarParametro("@idcredito", idcredito)
            rows = db.EjecutarConsulta
            Dim id_abono = rows.GetOrdinal("ID_ABONO")
            Dim id_credito = rows.GetOrdinal("ID_CREDITO")
            Dim fecha = rows.GetOrdinal("FECHA")
            Dim abono = rows.GetOrdinal("ABONO")

            Dim valores(rows.FieldCount) As Object
            ' If rows.Read() Then
            While rows.Read
                Try
                    rows.GetValues(valores)
                    Dim objA As New CAbonoCuentaPagar(valores(id_abono), valores(id_credito), valores(fecha), valores(abono))
                    abonos.Add(objA)
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
        Return abonos
    End Function
    Public Sub BorrarAbono(ByVal idabono As Integer)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim borraAbono As String = "DELETE FROM ABONO_PROVEEDOR WHERE ID_ABONO=@ida"
            db.CrearComando(borraAbono, CommandType.Text)
            db.AgregarParametro("@ida", idabono)
            db.EjecutarComando()

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Abonos Proveedor)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al borrar abono. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class
