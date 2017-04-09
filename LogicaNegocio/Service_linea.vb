Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Imports System.Collections.Generic
Public Class Service_linea

    Dim _datos As BaseDatos = Nothing
    Public Sub IniciarBusqueda()
        _datos = New BaseDatos
        _datos.Conectar()
    End Sub
    Public Sub FinalizarBusqueda()
        _datos.Desconectar()
        _datos.Dispose()
    End Sub
    Public Sub eliminar(ByVal id As Integer)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "delete from linea where id_linea=@id"
            db.CrearComando(sql, CommandType.Text)
            db.AgregarParametro("@id", id)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            Throw New ReglasNegocioException("Error al guardar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
    Public Sub insertar(ByVal linea As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "INSERT INTO  linea" _
           & "(descripcion)" _
           & " VALUES(@descripcion) RETURNING id_linea"

            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@descripcion", linea)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            Throw New ReglasNegocioException("Error al guardar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Sub actualizar(ByVal id As Integer, ByVal linea As String)
        Dim db As New BaseDatos
        Try

            db.Conectar()
            db.CrearComando("update linea set descripcion=@descripcion where id_linea=@id_linea  ", CommandType.Text)

            db.AgregarParametro("@descripcion", linea)
            db.AgregarParametro("@id_linea", id)
            db.EjecutarComando()

            db.Desconectar()
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Function obtener_Lineas() As List(Of Linea)
        Dim lineas As New List(Of Linea)
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "select * from linea order by descripcion"

            _datos.CrearComando(Sql, CommandType.StoredProcedure)
            datos = _datos.EjecutarConsulta()

            Dim id = Datos.GetOrdinal("id_linea")
            Dim descripcion = Datos.GetOrdinal("descripcion")

            Dim values(Datos.FieldCount) As Object

            While Datos.Read()
                Try
                    Datos.GetValues(values)
                    Dim linea As New Linea(values(id), values(descripcion))
                    lineas.Add(linea)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las lineas. " + Ex.Message)
        Finally
            datos.Close()
        End Try
        Return lineas
    End Function

    Public Function existe(ByVal linea As String) As Boolean
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "select * from linea WHERE UPPER (descripcion COLLATE DE_de) like  UPPER('%" & linea & "%' COLLATE DE_de)"

            db = New BaseDatos
            db.Conectar()

            db.CrearComando(Sql, CommandType.StoredProcedure)
            datos = db.EjecutarConsulta()


            Dim values(Datos.FieldCount) As Object

            If Datos.Read Then
                Return True
            Else
                Return False

            End If
          
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las lineas. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function
End Class
