Public Class Devolucion
    Public ivaValor As Decimal
    Private _id As Integer
    Private _id_usuario As Integer
    Private _id_venta As Integer
    Private _fecha As Date
    Private _subtotal As Decimal
    Private _descuento As Decimal
    Private _iva As Decimal
    Private _total As Decimal
    Private _total_texto As String
    Public _devolucionitems As List(Of Devolucion_Item)

    Public Function Descuentosf() As Decimal
        Dim tot As Decimal = 0
        For Each item In _devolucionitems
            tot += item.DescuentoD()
        Next
        Return Math.Round(tot, 2)
    End Function
    Public Function Adevolverf() As Decimal
        Dim tot As Decimal = 0
        For Each item In _devolucionitems
            Dim precio As Decimal = item.Producto.Precio - item.Producto.Precio * item.DescuentoP / 100
            tot += item.aDevolver * precio
        Next
        Return Math.Round(tot, 2)
    End Function
    Public Function Devueltosf() As Decimal
        Dim tot As Decimal = 0
        For Each item In _devolucionitems
            Dim precio As Decimal = item.Producto.Precio * item.DescuentoP / 100
            tot += item.Devueltos * precio
        Next
        Return Math.Round(tot, 2)
    End Function
    Public Function GetItem(ByVal id As Integer) As Devolucion_Item
        For Each i As Devolucion_Item In _devolucionitems
            If id = i.Id Then
                Return i
                Exit For
            End If
        Next
        Return Nothing
    End Function
    Public Sub ActualizaDevueltos(ByVal lista As List(Of pDevueltos))
        For Each item As pDevueltos In lista
            For Each i As Devolucion_Item In Items
                If i.Producto.Id = item.Id_producto Then
                    i.Devueltos = item.Devueltos
                    Exit For
                End If
            Next
        Next
    End Sub
    Public Sub ActualizaPrecios()
        For Each item As Devolucion_Item In _devolucionitems
            'If item.Producto.Iva Then
            '    item.Producto.Precio = item.Producto.Precio / (1 + (ivaValor / 100))
            'End If
            item.DescuentoD = Math.Round(item.Producto.Precio * item.DescuentoP / 100 * item.Cantidad, 2)
            'item.DescuentoD = (item.Producto.Precio * item.Cantidad) - (item.Producto.Precio / (1 + (item.DescuentoP / 100)) * item.Cantidad)
        Next
    End Sub
    Public Function UpdateADevolcer(ByVal cantidad As Decimal, ByVal id_producto As Integer) As Boolean
        For Each it As Devolucion_Item In _devolucionitems
            If it.Producto.Id = id_producto And Not it.Promo Then
                it.aDevolver = it.aDevolver + cantidad

                'If it.Producto.Iva Then
                '    it.Producto.Precio = it.Producto.Precio / (1 + (ivaValor / 100))
                'End If

                If Not it.Cantidad = (it.Devueltos + it.aDevolver) Then
                    it.DescuentoD = Math.Round(it.Producto.Precio * it.DescuentoP / 100 * it.Cantidad, 2)
                    ' it.DescuentoD = (it.Producto.Precio * it.Cantidad) - (it.Producto.Precio / (1 + (it.DescuentoP / 100)) * it.Cantidad)
                Else
                    it.DescuentoD = 0
                End If

                it.Total()
                Return True
            End If
        Next
        Return False
    End Function
    Public Function ExisteProducto(ByVal id_prod As Integer) As Boolean
        For Each i As Devolucion_Item In _devolucionitems
            If id_prod = i.Producto.Id Then
                Return True
                Exit For
            End If
        Next
        Return False
    End Function
    Public Function ExisteADevolver() As Boolean
        For Each i As Devolucion_Item In _devolucionitems
            If i.aDevolver > 0 Then
                Return True
                Exit For
            End If
        Next
        Return False
    End Function
    Public Function Totalf() As Decimal
        Dim tot As Decimal = 0
        For Each item In _devolucionitems
            tot += item.Total()
        Next
        Return tot
    End Function

    Public Function ivaf() As Decimal
        Dim tot As Decimal = 0
        For Each item In _devolucionitems
            If (item.Producto.Iva And item.aDevolver > 0) Then
                Dim precio As Decimal = item.Producto.Precio / (1 + (item.DescuentoP / 100))
                tot += (precio - (precio / (1 + (ivaValor / 100)))) * item.aDevolver
            End If
        Next
        Return Math.Round ( tot,2)
    End Function
    Public Function ivafBASE() As Decimal
        Dim tot As Decimal = 0
        For Each item In _devolucionitems
            If (item.Producto.Iva) Then
                Dim precioDescuento As Decimal = item.Producto.Precio / (1 + (item.DescuentoP / 100))
                tot += (precioDescuento - (precioDescuento / (1 + (ivaValor / 100)))) * item.Cantidad

                '    tot += (item.Producto.Precio - (item.Producto.Precio / (1 + (ivaValor / 100)))) * item.Cantidad
            End If
        Next
        Return tot
    End Function
    Public Function Cantidad(ByVal id_producto As Integer, ByVal cant As Decimal) As Boolean

        For Each it As Devolucion_Item In _devolucionitems
            If it.Producto.Id = id_producto Then
                If it.aDevolver + it.Devueltos + cant <= it.Cantidad Then
                    Return True
                End If
                Exit For
            End If
        Next
        Return False
    End Function
    Sub New()
        _devolucionitems = New List(Of Devolucion_Item)
    End Sub
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Id_usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property
    Public Property Id_Venta() As Integer
        Get
            Return _id_venta
        End Get
        Set(ByVal value As Integer)
            _id_venta = value
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
    Public Property Subtotal() As Decimal
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property
    Public Property Descuento() As Decimal
        Get
            Return _descuento
        End Get
        Set(ByVal value As Decimal)
            _descuento = value
        End Set
    End Property
    Public Property Iva() As Decimal
        Get
            Return _iva
        End Get
        Set(ByVal value As Decimal)
            _iva = value
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
    Public Property Total_texto() As String
        Get
            Return _total_texto
        End Get
        Set(ByVal value As String)
            _total_texto = value
        End Set
    End Property
    Public Property Items() As List(Of Devolucion_Item)
        Get
            Return _devolucionitems
        End Get
        Set(ByVal value As List(Of Devolucion_Item))
            _devolucionitems = value
        End Set
    End Property
End Class
