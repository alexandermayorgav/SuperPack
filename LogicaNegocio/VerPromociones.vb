
Public Class VerPromociones
    Private _id As Integer
    Private _cant As Decimal
    Private _desc As String
    Private _precio As Decimal
    Private _cant2 As Decimal
    Private _desc2 As String
    Private _tipo As Boolean
    Sub New()

    End Sub
    Sub New(ByVal id As Integer, ByVal cant As Decimal, ByVal desc As String, ByVal precio As Decimal, ByVal cant2 As Decimal, ByVal desc2 As String, ByVal tipo As Boolean)
        Me.Id = id
        Me.Cant = cant
        Me.Cant2 = cant2
        Me.Desc = desc
        Me.Desc2 = desc2
        Me.Precio = precio
        Me.Tipo = tipo
    End Sub
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Cant() As Decimal
        Get
            Return _cant
        End Get
        Set(ByVal value As Decimal)
            _cant = value
        End Set
    End Property
    Public Property Desc() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property

    Public Property Cant2() As Decimal
        Get
            Return _cant2
        End Get
        Set(ByVal value As Decimal)
            _cant2 = value
        End Set
    End Property
    Public Property Desc2() As String
        Get
            Return _desc2
        End Get
        Set(ByVal value As String)
            _desc2 = value
        End Set
    End Property
    Public Property Tipo() As Boolean
        Get
            Return _tipo
        End Get
        Set(ByVal value As Boolean)
            _tipo = value
        End Set
    End Property
End Class
