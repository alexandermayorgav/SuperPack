Imports AccesoDatos
Imports System.Text
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Personal
    Public Sub insertar(ByVal personal As Personal)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim insert As String = "INSERT INTO PERSONAL " _
            & "(NOMBRE,DIRECCION,TELEFONO,CELULAR,CORREO,ACTIVO,PUESTO) " _
            & "VALUES (@nombre,@direccion,@telefono,@celular,@correo,1,@puesto)"

            db.CrearComando(insert, CommandType.Text)
            db.AgregarParametro("@nombre", personal.Nombre)
            db.AgregarParametro("@direccion", personal.Direccion)
            db.AgregarParametro("@telefono", personal.Telefono)
            db.AgregarParametro("@celular", personal.Celular)
            db.AgregarParametro("@correo", personal.Email)
            db.AgregarParametro("@puesto", personal.Puesto)

            db.EjecutarComando()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos. (Personal)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al insertar el personal. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Sub actualizar(ByVal objP As Personal)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim update As String = "UPDATE PERSONAL SET " _
            & "NOMBRE=@nombre,DIRECCION=@direccion,TELEFONO=@telefono,CELULAR=@celular,CORREO=@correo,ACTIVO=@activo,PUESTO=@puesto " _
            & "WHERE ID_PERSONAL=@id_personal"

            db.CrearComando(update, CommandType.Text)
            db.AgregarParametro("@nombre", objP.Nombre)
            db.AgregarParametro("@direccion", objP.Direccion)
            db.AgregarParametro("@telefono", objP.Telefono)
            db.AgregarParametro("@celular", objP.Celular)
            db.AgregarParametro("@correo", objP.Email)
            db.AgregarParametro("@id_personal", objP.Id)
            If objP.Activo Then
                db.AgregarParametro("@activo", "1")
            Else
                db.AgregarParametro("@activo", "0")
            End If
            db.AgregarParametro("@puesto", objP.Puesto)

            db.EjecutarComando()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos. (Personal)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al editar el personal. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Sub desactivar(ByVal idPers As Integer)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim desactiva As String = "UPDATE PERSONAL SET ACTIVO=0 WHERE ID_PERSONAL=@id_pers"
            db.CrearComando(desactiva, CommandType.Text)
            db.AgregarParametro("@id_pers", idPers)
            db.EjecutarComando()

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Personal)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al desactivar al personal. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Function obtener(ByVal id_personal As Integer) As Personal
        Dim objP As Personal = Nothing
        Dim db As BaseDatos = Nothing
        Dim row As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim getC As String = "SELECT * FROM PERSONAL WHERE ID_PERSONAL=@id_personal"
            db.CrearComando(getC, CommandType.Text)

            db.AgregarParametro("@id_personal", id_personal)
            row = db.EjecutarConsulta()

            If row.Read Then
                Try
                    objP = New Personal(row("id_personal"), row("nombre"), row("direccion"), row("telefono"), row("celular"), row("correo"), row("activo"), row("puesto"))
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden (Personal).", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No existe.")
            End If

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Personal)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el personal. " + Ex.Message)
        Finally
            row.Close()
            db.Desconectar()
        End Try
        Return objP
    End Function

    Public Function obtenerTodos() As List(Of Personal)
        Dim db As BaseDatos = Nothing
        Dim rows As FbDataReader = Nothing
        Dim personal As List(Of Personal) = Nothing
        Try
            db = New BaseDatos
            personal = New List(Of Personal)
            db.Conectar()
            Dim getCs As String = "SELECT * FROM PERSONAL"
            db.CrearComando(getCs, CommandType.Text)

            rows = db.EjecutarConsulta
            Dim id_pers = rows.GetOrdinal("ID_PERSONAL")
            Dim nombre = rows.GetOrdinal("NOMBRE")
            Dim direccion = rows.GetOrdinal("DIRECCION")
            Dim telefono = rows.GetOrdinal("TELEFONO")
            Dim celular = rows.GetOrdinal("CELULAR")
            Dim email = rows.GetOrdinal("CORREO")
            Dim activo = rows.GetOrdinal("ACTIVO")
            Dim puesto = rows.GetOrdinal("PUESTO")

            Dim valores(rows.FieldCount) As Object
            While rows.Read
                Try
                    rows.GetValues(valores)
                    Dim objP As New Personal(valores(id_pers), valores(nombre), valores(direccion), valores(telefono), valores(celular), valores(email), valores(activo), valores(puesto))
                    personal.Add(objP)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden (Personal).", ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET", Ex)
                End Try

            End While
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos (Personal)")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener la lista de personal. " + Ex.Message)
        Finally
            rows.Close()
            db.Desconectar()
        End Try
        Return personal
    End Function
End Class
