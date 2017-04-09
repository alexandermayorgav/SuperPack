Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Codigos
    Public Sub AgregaraGrupo(ByVal cod As Codigo)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("INSERT INTO CODIGOS_HERMANOS (ID_PRODUCTO,CODIGO_HERMANO) " _
 & "VALUES (@id_prod,@codig) ", CommandType.Text)
            db.AgregarParametro("@id_prod", cod.Id_Producto)
            db.AgregarParametro("@codig", cod.Codigo_Hermano)
            db.EjecutarComando()
        Catch ex As FbException
            If ex.ErrorCode = 335544665 Then
                Throw New ReglasNegocioException("El producto ya esta en un grupo")
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
    Public Sub QuitardeGrupo(ByVal id As Integer)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("delete from  CODIGOS_HERMANOS where id_CODIGO=@cod", CommandType.Text)
            db.AgregarParametro("@cod", id)

            db.EjecutarComando()
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al agregar." + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub
    Public Function VerGrupoWrap(ByVal codigo As Codigo)
        Return verGrupo(codigo, New BaseDatos)
    End Function
    Public Function verGrupo(ByVal codigo As Codigo, Optional ByVal db As BaseDatos = Nothing) As List(Of Codigo)
        Dim lista As List(Of Codigo) = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "SELECT  CODIGO_HERMANO fROM CODIGOS_HERMANOS WHERE ID_PRODUCTO=@ID  "
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@ID", Codigo.Id_Producto)

            datos = db.EjecutarConsulta()

            Dim codigo_hermano As Integer = -1
            If datos.Read() Then
                Try
                    codigo_hermano = datos("CODIGO_HERMANO")
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No Existe este producto en algun grupo")
            End If

            If codigo_hermano <> -1 Then
                lista = listaCodigos(db, codigo_hermano)
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()

        End Try
        Return lista
    End Function

    Private Function listaCodigos(ByVal db As BaseDatos, ByVal codigo_hermano As Integer) As List(Of Codigo)
        Dim datos As FbDataReader = Nothing
        Dim codigos As List(Of Codigo) = Nothing
        Try
            Dim sql2 = "SELECT CODIGOS_HERMANOS.ID_PRODUCTO,CODIGOS_HERMANOS.ID_CODIGO, PRODUCTO.DESCRIPCION FROM CODIGOS_HERMANOS INNER JOIN PRODUCTO ON (CODIGOS_HERMANOS.ID_PRODUCTO = PRODUCTO.ID_PRODUCTO) where codigo_hermano=@cod"

            db.CrearComando(sql2, CommandType.Text)
            db.AgregarParametro("@cod", codigo_hermano)

            datos = db.EjecutarConsulta()
            codigos = New List(Of Codigo)
            While datos.Read
                codigos.Add(New Codigo(datos("ID_PRODUCTO"), codigo_hermano, datos("DESCRIPCION"), datos("ID_CODIGO")))
            End While
            datos.Close()
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        End Try
        Return codigos
    End Function
    Public Function verGrupo2(ByVal codigo As String) As List(Of Codigo)

        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()

            Dim sql2 = "SELECT CODIGOS_HERMANOS.ID_PRODUCTO,CODIGOS_HERMANOS.ID_CODIGO, PRODUCTO.DESCRIPCION " _
            & "FROM " _
           & "CODIGOS_HERMANOS " _
& "INNER JOIN PRODUCTO ON (CODIGOS_HERMANOS.ID_PRODUCTO = PRODUCTO.ID_PRODUCTO) where codigo_hermano=@cod"

            db.CrearComando(sql2, CommandType.Text)
            db.AgregarParametro("@cod", codigo)


            datos = db.EjecutarConsulta()
            Dim codigos As New List(Of Codigo)
            While datos.Read
                codigos.Add(New Codigo(datos("ID_PRODUCTO"), codigo, datos("DESCRIPCION"), datos("ID_CODIGO")))
            End While

            Return codigos


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try


    End Function


    Public Function nuevoGrupo() As Integer
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Dim grupo As Integer = -1
        Try
            db = New BaseDatos
            db.Conectar()

            Dim sql2 = "select MAX(codigos_hermanos.CODIGO_HERMANO) as mas from codigos_hermanos"

            db.CrearComando(sql2, CommandType.Text)


            datos = db.EjecutarConsulta()

            While datos.Read
                If IsDBNull(datos("mas")) Then
                    grupo = 1
                Else
                    grupo = datos("mas")
                    grupo += 1
                End If
                
            End While

            Return grupo

            Return Nothing
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try



    End Function

    Public Function verGrupoChino(ByVal codigo As Codigo) As List(Of Codigo)
        Dim lista As List(Of Codigo) = Nothing
        Dim datos As FbDataReader = Nothing
        Dim db As New BaseDatos
        Try
            db = New BaseDatos
            db.Conectar()
            Dim Sql As String = "SELECT  CODIGO_HERMANO fROM CODIGOS_HERMANOS WHERE ID_PRODUCTO=@ID  "
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@ID", codigo.Id_Producto)

            datos = db.EjecutarConsulta()

            Dim codigo_hermano As Integer = -1
            If datos.Read() Then
                Try
                    codigo_hermano = datos("CODIGO_HERMANO")
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No Existe este producto en algun grupo")
            End If

            If codigo_hermano <> -1 Then
                lista = listaCodigos(db, codigo_hermano)
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
        Return lista
    End Function


End Class
