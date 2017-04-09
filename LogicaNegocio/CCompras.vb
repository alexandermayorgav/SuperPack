Public Class CCompras
    Private _id As Integer
    Private _idusuario As Integer
    Private _idproveedor As String
    Private _fecha As Date
    Private _totalletras As String
    Private _subtotal As Decimal
    Private _descuento As Decimal
    Private _iva As Decimal
    Private _total As Decimal
    Private _id_credito As Integer
    Private _razon_proveedor As String
    Private _pagado As Char
    Public credito As Boolean
    Public _compraitems As List(Of CCompraDetalle)
    Sub New(ByVal id_compra As Integer, ByVal id_usu As Integer, ByVal id_provee As Integer, ByVal fechaCompra As Date, ByVal descCompra As Decimal, ByVal ivaCompra As Decimal, ByVal totalCompra As Decimal)
        Me.Id = id_compra
        Me.Usuario = id_usu
        Me.Proveedor = id_provee
        Me.Fecha = fechaCompra
        Me.Descuento = descCompra
        Me.IVA = ivaCompra
        Me.Total = totalCompra
    End Sub
    Sub New(ByVal rprov As String, ByVal tot As Decimal, ByVal fecha As Date, ByVal idcred As Integer, ByVal paga As Char)
        Me.RazonProv = rprov
        Me.Total = tot
        Me.Fecha = fecha
        Me.IdCredito = idcred
        Me.Pagado = paga
    End Sub
    Public Function SubTotal() As Decimal
        Dim subt As Decimal
        For Each item As CCompraDetalle In _compraitems
            subt += item.CUnitario * item.Cantidad
        Next
        Return subt
    End Function

    Public Function Totalf() As Decimal
        Dim tot As Decimal
        tot = SubTotal()
        Return tot
    End Function

    Public Function Desc() As Decimal
        Dim tot As Decimal = 0
        For Each item In _compraitems
            tot += item.DescuentoD 
        Next
        Return tot
    End Function
    Public Function BorraItem(ByVal clave As String) As Boolean
        For Each it As CCompraDetalle In _compraitems
            If it.Producto.Codigo = clave Then
                _compraitems.Remove(it)
                Return True
            End If
        Next
        Return False
    End Function

    Public Function DescuentoDinero(ByVal descP As Decimal, ByVal cant As Integer, ByVal costo As Decimal)
        Dim dinero As Decimal = 0

        dinero = ((costo * (descP / 100)) * cant)

        Return dinero
    End Function

    Public Sub AgregarItem(ByVal item As CCompraDetalle)
        Dim add As Boolean = True
        
        If _compraitems.Count = 0 Then
            _compraitems.Add(item)
            item.DescuentoD = DescuentoDinero(item.DescuentoP, item.Cantidad, item.Costo)
        Else
            For Each i As CCompraDetalle In _compraitems
                If i.Producto.Id = item.Producto.Id Then
                    add = False
                    i.Cantidad += item.Cantidad
                    i.Costo = item.Costo
                    If item.DescuentoP > 0 Then
                        i.DescuentoP = item.DescuentoP
                    End If
                    i.DescuentoD = DescuentoDinero(i.DescuentoP, i.Cantidad, i.Costo)
                    'i.DescuentoD = (i.Costo / 1 + (i.DescuentoP / 100) * i.Cantidad)
                    Exit For
                End If
            Next
            If add = True Then
                _compraitems.Add(item)
                item.DescuentoD = DescuentoDinero(item.DescuentoP, item.Cantidad, item.Costo)
            End If
        End If

    End Sub
    Sub New()
        _compraitems = New List(Of CCompraDetalle)
    End Sub
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Usuario() As Integer
        Get
            Return _idusuario
        End Get
        Set(ByVal value As Integer)
            _idusuario = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As String)
            _idproveedor = value
        End Set
    End Property
    Public Property RazonProv() As String
        Get
            Return _razon_proveedor
        End Get
        Set(ByVal value As String)
            _razon_proveedor = value
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
    Public Property TotalLetras() As String
        Get
            Return _totalletras
        End Get
        Set(ByVal value As String)
            _totalletras = value
        End Set
    End Property
    Public Property SubT() As Decimal
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
    Public Property IVA() As Decimal
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
    Public Property Items() As List(Of CCompraDetalle)
        Get
            Return _compraitems
        End Get
        Set(ByVal value As List(Of CCompraDetalle))
            _compraitems = value
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
    Public Property Pagado() As Char
        Get
            Return _pagado
        End Get
        Set(ByVal value As Char)
            _pagado = value
        End Set
    End Property
End Class
