Public Class Proveedor
    Private _id_proveedor As Integer
    Private _razon_social As String
    Private _rfc As String
    Private _calle As String
    Private _num_int As String
    Private _num_ext As String
    Private _colonia As String
    Private _cp As String
    Private _tel As String
    Private _ciudad As String
    Private _id_estado As Integer
    Private _status As Boolean
    Public _nuevo As Boolean
    Sub New()
        _id_proveedor = 0
    End Sub
    Sub New(ByVal id As Integer, ByVal razon As String, ByVal status As Boolean, ByVal nuevo As Boolean)
        Me.IdProveedor = id
        Me.RazonSocial = razon
        Me.Status = status
        Me._nuevo = nuevo
    End Sub
    Sub New(ByVal id_proveedor As Integer, ByVal razon_social As String, ByVal rfc As String, ByVal calle As String, ByVal num_int As String, ByVal num_ext As String, ByVal colonia As String, ByVal cp As String, ByVal tel As String, ByVal ciudad As String, ByVal id_estado As Integer, ByVal status As Boolean)
        Me.IdProveedor = id_proveedor
        Me.RazonSocial = razon_social
        Me.Rfc = rfc
        Me.Calle = calle
        Me.NumInt = num_int
        Me.NumExt = num_ext
        Me.Colonia = colonia
        Me.Cp = cp
        Me.Telefono = tel
        Me.Ciudad = ciudad
        Me.IdEstado = id_estado
        Me.Status = status
    End Sub
    Public Property IdProveedor() As Integer
        Get
            Return _id_proveedor
        End Get
        Set(ByVal value As Integer)
            _id_proveedor = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return _razon_social
        End Get
        Set(ByVal value As String)
            _razon_social = value
        End Set
    End Property
    Public Property Rfc() As String
        Get
            Return _rfc
        End Get
        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    Public Property Calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal value As String)
            _calle = value
        End Set
    End Property
    Public Property NumInt() As String
        Get
            Return _num_int
        End Get
        Set(ByVal value As String)
            _num_int = value
        End Set
    End Property
    Public Property NumExt() As String
        Get
            Return _num_ext
        End Get
        Set(ByVal value As String)
            _num_ext = value
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return _colonia
        End Get
        Set(ByVal value As String)
            _colonia = value
        End Set
    End Property
    Public Property Cp() As String
        Get
            Return _cp
        End Get
        Set(ByVal value As String)
            _cp = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _tel
        End Get
        Set(ByVal value As String)
            _tel = value
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return _ciudad
        End Get
        Set(ByVal value As String)
            _ciudad = value
        End Set
    End Property
    Public Property IdEstado() As Integer
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Integer)
            _id_estado = value
        End Set
    End Property
    Public Property Status() As Boolean
        Get
            Return _status
        End Get
        Set(ByVal value As Boolean)
            _status = value
        End Set
    End Property
End Class
