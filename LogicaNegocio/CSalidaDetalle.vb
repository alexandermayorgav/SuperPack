Public Class CSalidaDetalle
    Private _id As Integer
    Private _id_salida As Integer
    Private _cantidad As Decimal
    Private _costo As Decimal
    Private _producto As Producto
    Sub New(ByVal producto As Producto, ByVal cant As Integer, ByVal cost As Decimal)

        Me.Producto = producto
        Me.Cantidad = cant
        Me.Costo = cost

    End Sub
    Sub New()

    End Sub
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property IdSalida() As Integer
        Get
            Return _id_salida
        End Get
        Set(ByVal value As Integer)
            _id_salida = value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    Public Property Costo() As Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As Decimal)
            _costo = value
        End Set
    End Property
    Public Property Producto() As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property
End Class
