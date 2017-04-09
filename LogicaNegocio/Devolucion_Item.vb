Public Class Devolucion_Item
    Private _id As Integer
    Private _producto As Producto
    Private _cant As Integer
    Private _devueltos As Integer
    Private _adevolver As Integer
    Private _descuentoP As Decimal
    Private _decuentoD As Decimal

    Private _promo As Boolean
    Private _tipo_promocion As String


    Public Function Total() As Decimal
        If Not Cantidad = aDevolver + Devueltos Then
            Return Math.Round(_producto.Precio * (_cant - _adevolver - _devueltos) - (_producto.Precio * DescuentoP / 100 * Cantidad), 2)
        Else
            Return Math.Round(_producto.Precio * (_cant - _adevolver - _devueltos), 2)
        End If

    End Function


    Sub New()

    End Sub
    Sub New(ByVal producto As Producto, ByVal cantidad As Integer)
        Me.Producto = producto
        Me.Cantidad = cantidad
    End Sub

    Sub New(ByVal cant As Decimal, ByVal descuentoP As Decimal, ByVal producto As Producto)

        Me.Cantidad = cant
        Me.DescuentoP = descuentoP
        Me.Producto = producto

    End Sub
    Sub New(ByVal cant As Decimal, ByVal descuentoP As Decimal, ByVal producto As Producto, ByVal promo As Boolean, ByVal tipo_promocion As String)

        Me.Cantidad = cant
        Me.DescuentoP = descuentoP
        Me.Producto = producto
        Me.Promo = promo
        Me.Tipo_promocion = tipo_promocion
    End Sub

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


    Public Property Cantidad() As Integer
        Get
            Return _cant
        End Get
        Set(ByVal value As Integer)
            _cant = value
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

    Public Property aDevolver() As Integer
        Get
            Return _adevolver
        End Get
        Set(ByVal value As Integer)
            _adevolver = value
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
    Public Property DescuentoD() As Decimal
        Get
            Return _decuentoD
        End Get
        Set(ByVal value As Decimal)
            _decuentoD = value
        End Set
    End Property
    Public Property Promo() As Boolean
        Get
            Return _promo
        End Get
        Set(ByVal value As Boolean)
            _promo = value
        End Set
    End Property

    Public Property Tipo_promocion() As String
        Get
            Return _tipo_promocion
        End Get
        Set(ByVal value As String)
            _tipo_promocion = value
        End Set
    End Property


    Public Function Imp() As Decimal
        Return (_producto.Precio * Cantidad) - (_producto.Precio * DescuentoP / 100 * Cantidad)
    End Function

    Public ReadOnly Property Importe() As Double
        Get
            Return Imp()
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Producto.Descripcion
        End Get
    End Property
    Public ReadOnly Property PrecioUnitario() As Double
        Get
            Return Producto.Precio
        End Get
    End Property


End Class
