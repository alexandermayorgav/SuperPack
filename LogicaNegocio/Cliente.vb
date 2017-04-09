Public Class Cliente
    Private _id As Integer
    Private _razon As String
    Private _rfc As String
    Private _calle As String
    Private _num_int As String
    Private _num_ext As String
    Private _colonia As String
    Private _cp As String
    Private _telefono As String
    Private _ciudad As String
    Private _id_estado As Integer
    Private _status As Boolean
    Private _descuento As Integer


    Private _creditoActivo As Boolean
    Private _fecha As Date
    Private _limite As Decimal
    Private _id_credito As Integer
    Private _saldo As Decimal
    Public NombreEstado As String


    Sub New()

    End Sub

    'Sub New(ByVal id As Integer, ByVal razon As String, ByVal rfc As String, ByVal calle As String, ByVal num_int As String, ByVal num_ext As String, ByVal colonia As String, _
    '        ByVal cp As String, ByVal telefono As String, ByVal ciudad As String, ByVal id_estado As Integer, ByVal status As Boolean, ByVal descuento As Integer)
    '    Me.Id = id
    '    Me.Razon = razon
    '    Me.RFC = rfc
    '    Me.Calle = calle
    '    Me.Num_int = num_int
    '    Me.Num_ext = num_ext
    '    Me.Colonia = colonia
    '    Me.CP = cp
    '    Me.Telefono = telefono
    '    Me.Ciudad = ciudad
    '    Me.Id_estado = id_estado
    '    Me.Status = status
    '    Me.Descuento = descuento
    'End Sub

    Sub New(ByVal id As Integer, ByVal razon As String, ByVal rfc As String, ByVal calle As String, ByVal num_int As String, ByVal num_ext As String, ByVal colonia As String, _
            ByVal cp As String, ByVal telefono As String, ByVal ciudad As String, ByVal id_estado As Integer, ByVal status As Boolean, ByVal descuento As Integer, ByVal credito As Boolean, ByVal fecha As Date, ByVal limite As Decimal, ByVal id_credito As Integer, ByVal saldo As Decimal)
        Me.Id = id
        Me.Razon = razon
        Me.RFC = rfc
        Me.Calle = calle
        Me.Num_int = num_int
        Me.Num_ext = num_ext
        Me.Colonia = colonia
        Me.CP = cp
        Me.Telefono = telefono
        Me.Ciudad = ciudad
        Me.Id_estado = id_estado
        Me.Status = status
        Me.Descuento = descuento

        Me.CreditoActivo = credito
        Me.Fecha = fecha
        Me.Limite = limite
        Me.Id_credito = id_credito
        Me.Saldo = saldo

    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Razon() As String
        Get
            Return _razon
        End Get
        Set(ByVal value As String)
            _razon = value
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
    Public Property Calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal value As String)
            _calle = value
        End Set
    End Property
    Public Property Num_int() As String
        Get
            Return _num_int
        End Get
        Set(ByVal value As String)
            _num_int = value
        End Set
    End Property
    Public Property Num_ext() As String
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
    Public Property CP() As String
        Get
            Return _cp
        End Get
        Set(ByVal value As String)
            _cp = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
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
    Public Property Id_estado() As Integer
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
    Public Property Descuento() As Integer
        Get
            Return _descuento
        End Get
        Set(ByVal value As Integer)
            _descuento = value
        End Set
    End Property

    Public Property CreditoActivo() As Boolean
        Get
            Return _creditoActivo
        End Get
        Set(ByVal value As Boolean)
            _creditoActivo = value
        End Set
    End Property
    Public Property Fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Public Property Limite() As Decimal
        Get
            Return _limite
        End Get
        Set(ByVal value As Decimal)
            _limite = value
        End Set
    End Property
    Public Property Id_credito() As Integer
        Get
            Return _id_credito
        End Get
        Set(ByVal value As Integer)
            _id_credito = value
        End Set
    End Property
    Public Property Saldo() As Decimal
        Get
            Return _saldo
        End Get
        Set(ByVal value As Decimal)
            _saldo = value
        End Set
    End Property
End Class
