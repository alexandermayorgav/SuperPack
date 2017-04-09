Public Class VentaItem

    Private _id As Integer = 1
    Private _id_venta As Integer
    Private _producto As Producto
    Private _cantidad As Decimal
    Private _descuentoP As Decimal
    Private _descuentoD As Decimal
    Private _promocion As Boolean
    Private _tipoPormocion As String
    Private _relacion As String

    Sub New()

    End Sub
    Sub New(ByVal cantidad As Decimal, ByVal descuentoP As Decimal, ByVal producto As Producto)
        Me.Cantidad = cantidad
        Me.DescuentoPor = descuentoP
        Me.Producto = producto
    End Sub
    Sub New(ByVal cantidad As Decimal, ByVal descuentoP As Decimal, ByVal producto As Producto, ByVal promocion As Boolean, ByVal tipo As String)
        Me.Cantidad = cantidad
        Me.DescuentoPor = descuentoP
        Me.Producto = producto
        Me.Promocion = promocion
        Me.TipoPromocion = tipo
    End Sub

    Public Function Total() As Decimal
        Return Math.Round((_producto.Precio * Cantidad) - (_producto.Precio * DescuentoPor / 100 * Cantidad), 2)
        'Return Math.Round(_producto.Precio * DescuentoPor / 100, 2)
        'Return Math.Round(((_producto.Precio / (1 + (DescuentoPor / 100))) * Cantidad), 2)
    End Function
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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
    Public Property Cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    Public Property DescuentoPor() As Decimal
        Get
            Return _descuentoP
        End Get
        Set(ByVal value As Decimal)
            _descuentoP = value
        End Set
    End Property
    Public Property DescuentoDin() As Decimal
        Get
            Return _descuentoD
        End Get
        Set(ByVal value As Decimal)
            _descuentoD = value
        End Set
    End Property
    Public Property Promocion() As Boolean

        Get
            Return _promocion
        End Get
        Set(ByVal value As Boolean)
            _promocion = value
        End Set
    End Property
    Public Property TipoPromocion() As String
        Get
            Return _tipoPormocion
        End Get
        Set(ByVal value As String)
            _tipoPormocion = value
        End Set
    End Property
    Public Property Relacion() As String
        Get
            Return _relacion
        End Get
        Set(ByVal value As String)
            _relacion = value
        End Set
    End Property
End Class
