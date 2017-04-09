Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Privilegios



    Public Function Obtener_Todos() As List(Of Privilegio)
        Dim privilegios As List(Of Privilegio)
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT * FROM PRIVILEGIOS"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)

            datos = db.EjecutarConsulta()

            Dim id As Integer = datos.GetOrdinal("ID_GRUPO")
            Dim id_pri As Integer = datos.GetOrdinal("ID_PRIVILEGIO")
            Dim permiso As Integer = datos.GetOrdinal("PERMISO")


            Dim values(datos.FieldCount) As Object

            privilegios = New List(Of Privilegio)
            While datos.Read()
                Try
                    datos.GetValues(values)
                    privilegios.Add(New Privilegio(values(id_pri), values(id), values(permiso)))
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            Return privilegios
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function
    Public Sub Insertar(ByRef privilegio As Privilegio)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("INSERT INTO PRIVILEGIOS (PERMISO,ID_GRUPO) " _
 & "VALUES (@PERMISO,@ID_GRUPO) RETURNING ID_PRIVILEGIO", CommandType.Text)
            db.AgregarParametro("@PERMISO", privilegio.Permiso)
            db.AgregarParametro("@ID_GRUPO", privilegio.Id_Grupo)

            privilegio.Id_Privilegio = db.EjecutarEscalar

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al agregar." + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Public Sub Borrar(ByVal id As Integer)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("DELETE FROM  PRIVILEGIOS " _
 & " WHERE ID_PRIVILEGIO=@ID", CommandType.Text)
            db.AgregarParametro("@ID", id)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al borrar." + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Public Sub Actualizar(ByRef grupo As Grupo)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("UPDATE PRIVILEGIOS SET PERMISO=@PERMISO " _
 & " WHERE ID_PRIVILEGIO=@ID", CommandType.Text)
            db.AgregarParametro("@PERMISO", grupo.Nombre)
            db.AgregarParametro("@ID", grupo.Id_Grupo)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar." + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Function Obtener(ByVal id As Integer) As Privilegio
        Dim privilegio As Privilegio = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT * FROM PRIVILEGIOS WHERE ID_PRIVILEGIO=@ID"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@ID", id)

            datos = db.EjecutarConsulta()

            Dim id_grupo As Integer = datos.GetOrdinal("ID_GRUPO")
            Dim descripcion As Integer = datos.GetOrdinal("PERMISO")
            Dim idp As Integer = datos.GetOrdinal("ID_PRIVILEGIO")
            Dim values(datos.FieldCount) As Object

            If datos.Read() Then
                Try
                    datos.GetValues(values)
                    privilegio = New Privilegio(values(idp), values(id_grupo), values(descripcion))
                    Return privilegio

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
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Function Obtener_Todos_Por_Grupo(ByVal idgrupo As Integer) As List(Of Privilegio)
        Dim privilegios As List(Of Privilegio)
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT * FROM PRIVILEGIOS WHERE ID_GRUPO=@ID_GRUPO"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@ID_GRUPO", idgrupo)

            datos = db.EjecutarConsulta()

            Dim id As Integer = datos.GetOrdinal("ID_GRUPO")
            Dim id_pri As Integer = datos.GetOrdinal("ID_PRIVILEGIO")
            Dim permiso As Integer = datos.GetOrdinal("PERMISO")


            Dim values(datos.FieldCount) As Object

            privilegios = New List(Of Privilegio)
            While datos.Read()
                Try
                    datos.GetValues(values)
                    privilegios.Add(New Privilegio(values(id_pri), values(id), values(permiso)))
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            Return privilegios
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function


End Class
