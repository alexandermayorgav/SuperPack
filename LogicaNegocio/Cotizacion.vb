Public Class Cotizacion
    Private _id As Integer
    Private _fecha As Date
    Private _cliente As String
    Private _total As Decimal
    Sub New(ByVal id As Integer, ByVal fecha As Date, ByVal cliente As String, ByVal total As Decimal)
        Me.Id = id
        Me.Fecha = fecha
        Me.Cliente = cliente
        Me.Total = total
    End Sub



    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property
End Class
