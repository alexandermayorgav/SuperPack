Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Grupos


    Public Function Obtener_Todos() As List(Of Grupo)
        Dim grupos As List(Of Grupo)
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT * FROM GRUPOS WHERE ID_GRUPO<>1 AND ID_GRUPO<>2"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)

            datos = db.EjecutarConsulta()

            Dim id As Integer = datos.GetOrdinal("ID_GRUPO")
            Dim descripcion As Integer = datos.GetOrdinal("DESCRIPCION")

            Dim values(datos.FieldCount) As Object

            grupos = New List(Of Grupo)
            While datos.Read()
                Try
                    datos.GetValues(values)
                    grupos.Add(New Grupo(values(id), values(descripcion)))
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            Return grupos
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Sub Insertar(ByRef grupo As Grupo)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("INSERT INTO GRUPOS (DESCRIPCION) " _
 & "VALUES (@DESCRIPCION) RETURNING ID_GRUPO", CommandType.Text)
            db.AgregarParametro("@DESCRIPCION", grupo.Nombre)

            grupo.Id_Grupo = db.EjecutarEscalar

        Catch ex As FbException

            If ex.ErrorCode = 335544665 Then
                Throw New ReglasNegocioException("Ya hay otro grupo con el mismo nombre")
            End If
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
            db.CrearComando("DELETE FROM  GRUPOS " _
 & " WHERE ID_GRUPO=@ID", CommandType.Text)
            db.AgregarParametro("@ID", id)
            db.EjecutarComando()

        Catch EX As FbException
            If EX.ErrorCode = 335544466 Then
                'MsgBox(EX.Data.Count.ToString)

                Throw New ReglasNegocioException("No se puede borra el grupo por que tiene usuarios o privilegios")
            End If
            Throw New ReglasNegocioException("Error al Borrar")
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
            db.CrearComando("UPDATE GRUPOs SET DESCRIPCION=@DESCRIPCION " _
 & " WHERE ID_GRUPO=@ID", CommandType.Text)
            db.AgregarParametro("@DESCRIPCION", grupo.Nombre)
            db.AgregarParametro("@ID", grupo.Id_Grupo)
            db.EjecutarComando()

        Catch ex As FbException
            If ex.ErrorCode = 335544665 Then
                Throw New ReglasNegocioException("Ya hay otro grupo con el mismo nombre")
            Else
                Throw New ReglasNegocioException(ex.Message)
            End If
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar." + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Function Obtener(ByVal id As Integer) As Grupo
        Dim grupo As Grupo = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT * FROM GRUPOS WHERE ID_GRUPO=@ID AND WHERE ID_GRUPO<>1 AND ID_GRUPO<>2"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@ID", id)

            datos = db.EjecutarConsulta()

            Dim id_act As Integer = datos.GetOrdinal("ID_GRUPO")
            Dim descripcion As Integer = datos.GetOrdinal("DESCRIPCION")

            Dim values(datos.FieldCount) As Object

            If datos.Read() Then
                Try
                    datos.GetValues(values)
                    Grupo = New Grupo(values(id_act), values(descripcion))
                    Return Grupo

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


End Class
