Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class BuscarProveedor
    Private db As BaseDatos = Nothing
    Public Sub iniciarBusqueda()
        db = New BaseDatos
        db.Conectar()
    End Sub
    Public Sub finalizarBusqueda()
        db.Desconectar()
    End Sub
    Public Function Obtener(ByVal nombre As String) As List(Of BProveedor)
        Dim datos As FbDataReader = Nothing
        Dim Proveedores As New List(Of BProveedor)
        Try
            db.CrearComando("select id_proveedor, razon_social, rfc from proveedor where UPPER (razon_social COLLATE DE_de) like UPPER ('%" & nombre & "%' COLLATE DE_de) or UPPER (rfc COLLATE DE_de) like UPPER ('%" & nombre & "%' COLLATE DE_de) ", CommandType.Text)

            datos = db.EjecutarConsulta()

            Dim id = datos.GetOrdinal("id_proveedor")
            Dim rs = datos.GetOrdinal("razon_social")
            Dim rfc = datos.GetOrdinal("rfc")

            Dim values(datos.FieldCount) As Object

            While datos.Read()
                Try
                    datos.GetValues(values)

                    Dim buscaProveedor As New BProveedor(values(id), values(rs), values(rfc))
                    Proveedores.Add(buscaProveedor)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener los proveedores")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error a obtener los proveedores. " + Ex.Message)
        Finally
            datos.Close()
        End Try
        Return Proveedores
    End Function
    Class BProveedor
        Private _id_proveedor As Integer
        Private _razon_social As String
        Private _rfc As String
        Public Sub New(ByVal id_proveedor As Integer, ByVal razon_social As String, ByVal rfc As String)
            MyClass.FOLIO = id_proveedor
            MyClass.RAZON_SOCIAL = razon_social
            MyClass.RFC = rfc
        End Sub
        Public Property FOLIO() As Integer
            Get
                Return _id_proveedor
            End Get
            Set(ByVal value As Integer)
                _id_proveedor = value
            End Set
        End Property
        Public Property RAZON_SOCIAL() As String
            Get
                Return _razon_social
            End Get
            Set(ByVal value As String)
                _razon_social = value
            End Set
        End Property
        Public Property RFC() As String
            Get
                Return _rfc
            End Get
            Set(ByVal value As String)
                _rfc = value
            End Set
        End Property
    End Class
End Class
