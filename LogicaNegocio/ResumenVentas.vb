Public Class ResumenVentas
    Private _id_venta As Integer
    Private _id_usuario As Integer
    Private _fecha As Date
    Private _total As Decimal
    Private _user As String
    Private _nombre As String
    Private _Cliente As String

    Sub New()
    End Sub
    Sub New(ByVal id_venta As Integer, ByVal id_usuario As Integer, ByVal fecha As Date, ByVal total As Decimal, ByVal user As String, ByVal nombre As String,ByVal cliente As String)
        Me.IdVenta = id_venta
        Me.IdUsuario = id_usuario
        Me.Fecha = fecha
        Me.Total = total
        Me.User = user
        Me.Nombre = nombre
        Me._Cliente = cliente

    End Sub
    Public Property IdVenta() As Integer
        Get
            Return _id_venta
        End Get
        Set(ByVal value As Integer)
            _id_venta = value
        End Set
    End Property
    Public Property IdUsuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
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
    Public Property Total() As Double
        Get
            Return _total
        End Get
        Set(ByVal value As Double)
            _total = value
        End Set
    End Property
    Public Property User() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

End Class
