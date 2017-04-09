Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Imports System.Security.Cryptography
Imports System.Text
Public Class Service_Usuario


    Public Function Obtener_Todos() As List(Of Usuario)
        Dim usuarios As List(Of Usuario)
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT USUARIOS.ID_USUARIO, USUARIOS.ID_GRUPO, USUARIOS.""PASSWORD"", USUARIOS.USUARIO, USUARIOS.ID_PERSONAL, USUARIOS.ACTIVO, PERSONAL.NOMBRE  as NOMBRE fROM Usuarios INNER JOIN Personal ON Usuarios.ID_PERSONAL = Personal.ID_PERSONAL WHERE USUARIOS.ID_GRUPO<>1"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)

            datos = db.EjecutarConsulta()

            Dim id_usuario As Integer = datos.GetOrdinal("ID_USUARIO")
            Dim id_personal As Integer = datos.GetOrdinal("ID_PERSONAL")
            Dim password As Integer = datos.GetOrdinal("PASSWORD")
            Dim usuario As Integer = datos.GetOrdinal("USUARIO")
            Dim nombre_grupo As Integer = datos.GetOrdinal("ID_GRUPO")
            Dim nombre As Integer = datos.GetOrdinal("NOMBRE")
            Dim act As Integer = datos.GetOrdinal("ACTIVO")
            Dim values(datos.FieldCount) As Object

            usuarios = New List(Of Usuario)
            While datos.Read()
                Try
                    datos.GetValues(values)
                    usuarios.Add(New Usuario(values(id_usuario), values(usuario), values(id_personal), values(password), values(nombre_grupo), values(nombre), values(act)))
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            Return usuarios
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Sub Insertar(ByRef usuario As Usuario)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("INSERT INTO USUARIOS (USUARIO,""PASSWORD"",ID_PERSONAL,ID_GRUPO,ACTIVO) " _
 & "VALUES (@USUARIO,@PASSWORD,@ID_PERSONAL,@GRUPO,1) returning ID_USUARIO", CommandType.Text)
            db.AgregarParametro("@USUARIO", usuario.Usuario)
            db.AgregarParametro("@PASSWORD", usuario.Password)
            db.AgregarParametro("@ID_PERSONAL", usuario.Id_Personal)
            db.AgregarParametro("GRUPO", usuario.Id_Grupo)
            usuario.Id_Usuario = db.EjecutarEscalar
        Catch ex As FbException
            If ex.ErrorCode = 335544665 Or ex.ErrorCode = 335544349 Then
                Throw New ReglasNegocioException("Usuario existente")
            Else
                Throw New ReglasNegocioException(ex.Message)
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
            db.CrearComando("update  USUARIOS set activo=0" _
 & " WHERE ID_USUARIO=@ID", CommandType.Text)
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

    Public Sub Activar(ByVal id As Integer)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("update  USUARIOS set activo=1" _
 & " WHERE ID_USUARIO=@ID", CommandType.Text)
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



    Public Sub ActualizarContraseña(ByRef usuario As Usuario)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("UPDATE USUARIOS SET ""PASSWORD""=@PASSWORD" _
 & " WHERE ID_USUARIO=@ID", CommandType.Text)
            'db.AgregarParametro("@USUARIO", usuario.Usuario)
            db.AgregarParametro("@ID", usuario.Id_Usuario)
            'db.AgregarParametro("@ID_PERSONAL", usuario.Id_Personal)
            db.AgregarParametro("@PASSWORD", usuario.Password)
            'db.AgregarParametro("GRUPO", usuario.Id_Grupo)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar contraseña." + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
    Public Sub Actualizar(ByRef usuario As Usuario)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("UPDATE USUARIOS SET USUARIO=@USUARIO, ID_GRUPO=@GRUPO, ACTIVO=@ACT" _
 & " WHERE ID_USUARIO=@ID", CommandType.Text)
            db.AgregarParametro("@USUARIO", usuario.Usuario)
            db.AgregarParametro("@ID", usuario.Id_Usuario)
            'db.AgregarParametro("@ID_PERSONAL", usuario.Id_Personal)
            'db.AgregarParametro("@PASSWORD", usuario.Password)
            db.AgregarParametro("GRUPO", usuario.Id_Grupo)
            If usuario.Activo Then
                db.AgregarParametro("@ACT", "1")
            Else
                db.AgregarParametro("@ACT", "0")
            End If
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar." + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Function Obtener(ByVal id_del As Integer) As Usuario
        Dim usuario As Usuario = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
         
            Dim Sql As String = "SELECT  Usuarios.ID_USUARIO, Usuarios.ID_GRUPO, Usuarios.""PASSWORD"", Usuarios.USUARIO, Usuarios.ID_PERSONAL, (Personal.NOMBRE) as NOMBRE fROM Usuarios INNER JOIN Personal ON Usuarios.ID_PERSONAL = Personal.ID_PERSONAL  WHERE ID_USUARIO=@ID"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@ID", id_del)

            datos = db.EjecutarConsulta()

            Dim id_usuario As Integer = datos.GetOrdinal("ID_USUARIO")
            Dim id_personal As Integer = datos.GetOrdinal("ID_PERSONAL")
            Dim password As Integer = datos.GetOrdinal("PASSWORD")
            Dim user As Integer = datos.GetOrdinal("USUARIO")
            Dim nombre_grupo As Integer = datos.GetOrdinal("ID_GRUPO")
            Dim nombre As Integer = datos.GetOrdinal("NOMBRE")
            Dim values(datos.FieldCount) As Object

            If datos.Read() Then
                Try
                    datos.GetValues(values)
                    usuario = New Usuario(values(id_usuario), values(user), values(id_personal), values(password), values(nombre_grupo), values(nombre))
                    Return usuario

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
            Throw New ReglasNegocioException("Error al obtener el usuario. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Function Login(ByVal usuario As String, ByVal pass As String) As Usuario
        Dim us As Usuario = Nothing
        Dim datos As FbDataReader = Nothing
        Dim db As BaseDatos = Nothing
        Try

            db = New BaseDatos
            db.Conectar()
            Dim Sql As String = "SELECT PERSONAL.NOMBRE,USUARIOS.ID_GRUPO,USUARIOS.ID_USUARIO,USUARIOS.ACTIVO " _
           & "FROM USUARIOS INNER JOIN PERSONAL " _
           & "ON PERSONAL.ID_PERSONAL=USUARIOS.ID_PERSONAL " _
           & "WHERE USUARIO=@USUARIO and ""PASSWORD""=@PASSWORD"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@USUARIO", usuario)
            db.AgregarParametro("@PASSWORD", GenerarHash(pass))

            datos = db.EjecutarConsulta()
            Dim nombre As Integer = Datos.GetOrdinal("NOMBRE")
            Dim id_grupo As Integer = Datos.GetOrdinal("ID_GRUPO")
            Dim id_usuario As Integer = Datos.GetOrdinal("ID_USUARIO")
            Dim act As Integer = Datos.GetOrdinal("ACTIVO")

            Dim values(Datos.FieldCount) As Object
            If Datos.Read Then
                Try
                    Datos.GetValues(values)
                    us = New Usuario(values(nombre), values(id_grupo), values(id_usuario), values(act))
                    Return us

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("Usuario y/o contraseña invalidos")
            End If
            Datos.Close()
            db.Desconectar()
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Function GenerarHash(ByVal Texto As String) As String
        'Creamos un objeto de codificación Unicode que
        'representa una codificación UTF-16 de caracteres Unicode. 

        Dim Codificar As New UnicodeEncoding()
        'Declaramos una matriz (array) de tipo Byte para recuperar dentro los bytes del texto
        'utilizando el objeto Codificar
        Dim ByteTexto() As Byte = Codificar.GetBytes(Texto)
        'Instanciamos el objeto MD5 
        Dim Md5 As New MD5CryptoServiceProvider()
        'Se calcula el Hash del Texto en bytes 
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteTexto)
        'convertimos el texto 

        Return Convert.ToBase64String(ByteHash)
        'Eliminamos los objetos usados con Nothing
        Codificar = Nothing
        ByteTexto = Nothing

    End Function
End Class
