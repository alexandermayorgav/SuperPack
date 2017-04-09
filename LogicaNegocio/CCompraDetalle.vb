Public Class CCompraDetalle
    Private _id As Integer
    Private _id_compra As Integer
    Private _cantidad As Integer
    Private _costo As Decimal
    Private _importe As Decimal
    Private _iva As Decimal
    Private _precio As Decimal
    Private _descuentoD As Decimal
    Private _descuentoP As Decimal
    Private _precioMenudeo As Decimal
    Private _producto As Producto

    Public Function CUnitario() As Decimal
        Return _costo
    End Function


    Public Function Import() As Decimal

        Return (_cantidad * CUnitario())

    End Function

    Sub New(ByVal productos As Producto, ByVal cant As Integer, ByVal cost As Decimal, ByVal descP As Decimal, ByVal price As Decimal, ByVal newiva As Decimal, ByVal priceMenudeo As Decimal, ByVal imp As Decimal)
        Me.Producto = productos
        Me.Cantidad = cant
        Me.Costo = cost
        Me.DescuentoP = descP
        Me.Precio = price
        Me.IVA = newiva
        Me.PrecioMenudeo = priceMenudeo
        Me.Importe = imp
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
    Public Property IdCompra() As Integer
        Get
            Return _id_compra
        End Get
        Set(ByVal value As Integer)
            _id_compra = value
        End Set
    End Property
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
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
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property
    Public Property PrecioMenudeo() As Decimal
        Get
            Return _precioMenudeo
        End Get
        Set(ByVal value As Decimal)
            _precioMenudeo = value
        End Set
    End Property
    Public Property Importe() As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
    Public Property IVA() As Decimal
        Get
            Return _iva
        End Get
        Set(ByVal value As Decimal)
            _iva = value
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
    Public Property DescuentoD() As Decimal
        Get
            Return _descuentoD
        End Get
        Set(ByVal value As Decimal)
            _descuentoD = value
        End Set
    End Property
    Public Property DescuentoP() As Decimal
        Get
            Return _descuentoP
        End Get
        Set(ByVal value As Decimal)
            _descuentoP = value
        End Set
    End Property
End Class
