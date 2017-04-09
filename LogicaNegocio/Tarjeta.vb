Public Class Tarjeta
    Private _numero_operacion As String
    Private _monto As Decimal

    Sub New(ByVal numoperacion As String, ByVal monto As Decimal)
        Me._numero_operacion = numoperacion
        Me._monto = monto
    End Sub

    Public Property NumeroOperacion() As String
        Get
            Return _numero_operacion
        End Get
        Set(ByVal value As String)
            _numero_operacion = value
        End Set
    End Property
    Public Property Monto() As Decimal
        Get
            Return _monto
        End Get
        Set(ByVal value As Decimal)
            _monto = value
        End Set
    End Property
End Class
