Public Class CAbonoCuentaPagar
    Private _id As Integer
    Private _id_credito As Integer
    Private _fecha As Date
    Private _abono As Decimal
    Sub New()
    End Sub
    Sub New(ByVal id As Integer, ByVal id_credito As Integer, ByVal fecha As Date, ByVal abono As Decimal)
        Me.Id = id
        Me.IdCredito = id_credito
        Me.Fecha = fecha
        Me.Abono = abono
    End Sub
    Public Property Fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Public Property Abono() As Decimal
        Get
            Return _abono
        End Get
        Set(ByVal value As Decimal)
            _abono = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property IdCredito() As Integer
        Get
            Return _id_credito
        End Get
        Set(ByVal value As Integer)
            _id_credito = value
        End Set
    End Property
End Class
