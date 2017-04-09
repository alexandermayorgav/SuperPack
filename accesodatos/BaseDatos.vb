Imports FirebirdSql.Data.FirebirdClient
Imports System.Configuration

Public Class BaseDatos
    Implements IDisposable

    Private _Conexion As FbConnection = Nothing 'Conexion
    Private _Comando As FbCommand = Nothing 'Comandos (consultas, inserts, deletes..) a ejecutar
    Private _Transaccion As FbTransaction = Nothing
    Private _CadenaConexion As String  'Cadena de conexion
    Private _disposed As Boolean

    ''Datos de configuración Administración de la base de datos
    Public _userid As String
    Public _passworddb As String
    Public _db As String
    Public _ds As String

    Public Property Cadena() As String
        Get
            Return _CadenaConexion
        End Get
        Set(ByVal value As String)
            _CadenaConexion = value
        End Set
    End Property

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not _disposed Then

            If disposing Then
                If (Not (_Conexion) Is Nothing) Then
                    _Conexion.Dispose()
                End If
                If (Not (_Comando) Is Nothing) Then
                    _Comando.Dispose()
                End If
                If (Not (_Transaccion) Is Nothing) Then
                    _Transaccion.Dispose()
                End If

            End If

            _Conexion = Nothing
            _Comando = Nothing
            _Transaccion = Nothing
            _disposed = True

        End If
    End Sub

    Public Sub New()
        'If datasource.Trim = "" Or database.Trim = "" Then
        '    datasource = ConfigurationManager.AppSettings("DataSource").ToString
        '    database = ConfigurationManager.AppSettings("InitialCatalog").ToString
        '    ''leer()
        'End If

        If cadenaConexion.Trim = "" Then
            cadenaConexion = ConfigurationManager.ConnectionStrings("CadenaConexion").ToString()
        End If


        Dim cn As New FbConnectionStringBuilder
        cn.ConnectionString = cadenaConexion
        Me.Cadena = cn.ToString

        _userid = cn.UserID
        _passworddb = cn.Password
        _db = cn.Database
        _ds = cn.DataSource
    End Sub
    Public Sub Conectar()
        If Not Me._Conexion Is Nothing Then 'si tiene valor la conexion
            If Not Me._Conexion.State.Equals(ConnectionState.Closed) Then 'si no esta cerrada
                Throw New BaseDatosException("La conexión ya se encuentra abierta.") 'mandamos exepcion
            End If
        End If

        Try
            If Me._Conexion Is Nothing Then 'Si no se a creado la conexion
                Me._Conexion = New FbConnection 'Creamos una nueva instancia
                Me._Conexion.ConnectionString = _CadenaConexion ' y le asignamos la cadena de conexion
            End If
            Me._Conexion.Open() 'abrimos la BDs
            '   MsgBox("conexion succesfull")
        Catch ex As FbException
            Throw New BaseDatosException("Error al conectarse.") 'cualquier error propagamos excepcion
        End Try
    End Sub

    Public Sub Desconectar()
        If Me._Conexion.State.Equals(ConnectionState.Open) Then 'Si esta abierta la conexion
            Me._Conexion.Close() 'La cerramos

        End If
    End Sub

    Public Sub CrearComando(ByVal sentenciaSQL As String, ByVal Tipo As System.Data.CommandType)
        _Comando = New FbCommand 'Creamos un nuevo comando (consulta, insert, delete, update, etc)
        Me._Comando.Connection = Me._Conexion 'le asigamos la conexion
        Me._Comando.CommandType = Tipo ' y el tipo, tipo=text o storeprocedure
        Me._Comando.CommandText = sentenciaSQL 'Le pasamos la sentancia SQL
        If Not Me._Transaccion Is Nothing Then
            Me._Comando.Transaction = Me._Transaccion
        End If
    End Sub

    Public Sub AgregarParametro(ByVal nom As String, ByVal valor As String)
        _Comando.Parameters.AddWithValue(nom, valor)
        '_Comando.Parameters.AddWithValue(nom, OleDb.OleDbType.Variant)
        '_Comando.Parameters(nom).Value = valor
    End Sub

    'Asignar parametro a la sentencia SQL
    Private Sub AsignarParametro(ByVal nombre As String, ByVal separador As String, ByVal valor As String)
        Dim indice As Integer = Me._Comando.CommandText.IndexOf(nombre)
        Dim prefijo As String = Me._Comando.CommandText.Substring(0, indice)
        Dim sufijo As String = Me._Comando.CommandText.Substring(indice + nombre.Length)
        Me._Comando.CommandText = prefijo + separador + valor + separador + sufijo
    End Sub

    Public Sub AsignarParametroNulo(ByVal nombre As String) 'Asiganacion de parametros nulos
        AsignarParametro(nombre, "", "NULL")
    End Sub

    Public Sub AsignarParametroCadena(ByVal nombre As String, ByVal valor As String) 'Asiganacion de parametros cadena
        AsignarParametro(nombre, "'", valor)
    End Sub

    Public Sub AsignarParametroEntero(ByVal nombre As String, ByVal valor As Integer) 'Asiganacion de parametros enteros
        AsignarParametro(nombre, "", valor.ToString())
    End Sub

    Public Sub AsignarParametroFecha(ByVal nombre As String, ByVal valor As DateTime) 'Asiganacion de parametros de tipo date
        AsignarParametro(nombre, "'", valor.ToString())
    End Sub

    Public Sub AsignarParametroBoleano(ByVal nombre As String, ByVal valor As Boolean) 'Asiganacion de parametros booleanos
        AsignarParametro(nombre, "", valor.ToString())
    End Sub

    Public Sub AsignarParametroByte(ByVal nombre As String, ByVal valor As Byte())
        Dim img As New FbParameter(nombre, OleDb.OleDbType.VarBinary)
        If Not valor Is Nothing Then
            img.Value = valor
            _Comando.Parameters.Add(img)
        Else
            AsignarParametroNulo(nombre)
        End If

    End Sub

    Public Function EjecutarConsulta() As FbDataReader 'Ejecucion de consultas devolviendonos un data reader para la lectura de sus campos
        Return Me._Comando.ExecuteReader()
    End Function

    Public Function ObtenConsulta() As DataSet 'Obtener consultas para ser llenadas en un datagrid
        Dim DA As New FbDataAdapter(_Comando)
        Dim ds As New DataSet
        DA.Fill(ds)
        Return ds
    End Function


    Public Sub EjecutarComando() 'Ejecucion de comando como insert, delete, update
        Me._Comando.ExecuteNonQuery()
    End Sub

    Public Sub ComenzarTransaccion()
        If Me._Transaccion Is Nothing Then
            Me._Transaccion = Me._Conexion.BeginTransaction()
        End If
    End Sub

    Public Sub CancelarTransaccion()
        If Not Me._Transaccion Is Nothing Then
            Me._Transaccion.Rollback()
        End If
    End Sub

    Public Sub ConfirmarTransaccion()
        If Not Me._Transaccion Is Nothing Then
            Me._Transaccion.Commit()
        End If
    End Sub

    Public Function EjecutarEscalar() As Integer
        Dim escalar As Integer = 0
        Try
            escalar = Integer.Parse(Me._Comando.ExecuteScalar().ToString())
        Catch ex As InvalidCastException
            Throw New BaseDatosException("Error al ejecutar un escalar.", ex)
        End Try
        Return escalar
    End Function
    Public Function EjecutarEscalarDec() As Decimal
        Dim escalar As Decimal = 0
        Try
            escalar = Decimal.Parse(Me._Comando.ExecuteScalar().ToString())
        Catch ex As InvalidCastException
            Throw New BaseDatosException("Error al ejecutar un escalar.", ex)
        End Try
        Return escalar
    End Function
End Class
