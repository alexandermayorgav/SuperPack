Public Class FinalizarPago
    Private _total As Decimal
    Private _efectivo As Decimal
    Private _cambio As Decimal
    Private _pagado As Boolean
    Private _ausar As Decimal
    Public Property aUsar() As Decimal
        Get
            Return _ausar
        End Get
        Set(ByVal value As Decimal)
            _ausar = value
        End Set
    End Property

    Sub New()

    End Sub
    Sub New(ByVal total As Decimal, ByVal efectivo As Decimal, ByVal cambio As Decimal, ByVal pagado As Boolean)
        Me.Total = total
        Me.Efectivo = efectivo
        Me.Cambio = cambio
        Me.Pagado = pagado
    End Sub

    Sub New(ByVal total As Decimal, ByVal efectivo As Decimal, ByVal ausar As Decimal, ByVal cambio As Decimal, ByVal pagado As Boolean)
        Me.Total = total
        Me.Efectivo = efectivo
        Me.Cambio = cambio
        Me.Pagado = pagado
        Me.aUsar = ausar
    End Sub
    Public Property Pagado() As Boolean
        Get
            Return _pagado
        End Get
        Set(ByVal value As Boolean)
            _pagado = value
        End Set
    End Property

    Public Property Cambio() As Decimal
        Get
            Return _cambio
        End Get
        Set(ByVal value As Decimal)
            _cambio = value
        End Set
    End Property

    Public Property Efectivo() As Decimal
        Get
            Return _efectivo
        End Get
        Set(ByVal value As Decimal)
            _efectivo = value
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
