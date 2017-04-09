Public Class pDevueltos

    Private _id_detalle_venta As Integer
    Private _devueltos As Integer
    Private _id_producto As Integer


    Sub New()

    End Sub
    Sub New(ByVal devueltos As Integer, ByVal id_producto As Integer)
        Me.Devueltos = devueltos
        Me.Id_producto = id_producto
    End Sub

    Public Property IdDetalleVenta() As Integer
        Get
            Return _id_detalle_venta
        End Get
        Set(ByVal value As Integer)
            _id_detalle_venta = value
        End Set

    End Property

    Public Property Devueltos() As Integer
        Get
            Return _devueltos
        End Get
        Set(ByVal value As Integer)
            _devueltos = value
        End Set
    End Property
    Public Property Id_producto() As Integer
        Get
            Return _id_producto
        End Get
        Set(ByVal value As Integer)
            _id_producto = value
        End Set
    End Property
End Class
