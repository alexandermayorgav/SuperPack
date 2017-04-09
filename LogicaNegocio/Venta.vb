
Public Class Venta
    Public ivaValor As Decimal
    Private _id As Integer
    Private _id_usuario As Integer
    Private _id_cliente As Integer
    Private _fecha As Date
    Private _subtotal As Decimal
    Private _descuento As Decimal
    Private _iva As Decimal
    Private _total As Decimal
    Private _total_texto As String
    Private _ventaItems As List(Of VentaItem)
    Public credito As Boolean = False
    Public id_credito As Integer
    Public abono As Decimal = 0
    Public venderSinExistencia As Boolean
    Private _id_servicio As Integer


    Sub New(ByVal id As Integer, ByVal id_usuarios As Integer, ByVal id_cliente As Integer, ByVal fechas As Date, ByVal subtotal As Decimal, ByVal descuento As Decimal, ByVal iva As Decimal, ByVal total As Decimal, ByVal total_texto As String, ByVal ventaItems As List(Of VentaItem))
        Me.Id = id
        Me.Id_usuario = Id_usuario
        Me.Id_cliente = id_cliente
        Me.Fecha = fechas
        Me.Subtotal = subtotal
        Me.Descuento = descuento
        Me.Iva = iva
        Me.Total = total
        Me.Total_texto = total_texto
        Me.Items = ventaItems
    End Sub
    Public Function Totalf() As Decimal
        Dim tot As Decimal = 0
        For Each item In _ventaItems
            tot += item.Total()
        Next
        Return tot
    End Function
    Public Function Descuentosf() As Decimal
        Dim tot As Decimal = 0
        For Each item In _ventaItems
            tot += item.DescuentoDin()
        Next
        Return tot
    End Function
    Public Function ivaf() As Decimal
        Dim tot As Decimal = 0
        For Each item In _ventaItems
            If item.Producto.Iva Then
                Dim precioDescuento As Decimal = item.Producto.Precio - item.Producto.Precio * item.DescuentoPor / 100
                tot += (precioDescuento - (precioDescuento / (1 + (ivaValor / 100)))) * item.Cantidad
            End If
        Next
        Return Math.Round(tot, 2)
    End Function
    Public Function BorraItem(ByVal id As Integer) As Boolean
        For Each it As VentaItem In _ventaItems
            If it.Id = Id Then
                _ventaItems.Remove(it)
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub UpdateItem(ByVal descuento As Decimal)
        For Each it As VentaItem In _ventaItems
            it.DescuentoPor = descuento
            ' it.DescuentoDin = (it.Producto.Precio * it.Cantidad) - ((it.Producto.Precio * it.DescuentoPor / 100) * it.Cantidad)
            it.DescuentoDin = ((it.Producto.Precio * it.DescuentoPor / 100) * it.Cantidad)
            it.Total()
        Next
    End Sub
    Public Sub UpdateItem2(ByVal descuento As Decimal, ByVal id As Integer)
        For Each it As VentaItem In _ventaItems
            If it.Id = id Then
                it.DescuentoPor = descuento
                ' it.DescuentoDin = (it.Producto.Precio * it.Cantidad) - ((it.Producto.Precio * it.DescuentoPor / 100) * it.Cantidad)
                it.DescuentoDin = ((it.Producto.Precio * it.DescuentoPor / 100) * it.Cantidad)
                it.Total()
            End If
        Next
    End Sub
    Public Sub UpdateCantidad(ByVal cantidad As Decimal, ByVal id As Integer)
        Dim vendidos As Decimal = 0
        Dim existencia As Decimal = 0
        For Each it As VentaItem In _ventaItems
            If Not it.Id = id Then
                vendidos += it.Cantidad
            End If
        Next

        For Each it As VentaItem In _ventaItems
            If it.Id = id Then
                If Not venderSinExistencia Then
                    If cantidad + vendidos > it.Producto.Existencia Then
                        Throw New Exception("Existencia Insuficiente.")
                    Else
                        it.Cantidad = cantidad
                        'it.DescuentoDin = it.Producto.Precio * it.DescuentoPor / 100 * it.Cantidad
                        it.Total()
                        Descuentos(it.Id)
                    End If

                Else
                    it.Cantidad = cantidad
                    'it.DescuentoDin = it.Producto.Precio * it.DescuentoPor / 100 * it.Cantidad
                    it.Total()
                    Descuentos(it.Id)
                End If
                
            End If
        Next
    End Sub
    Private Function hayExistencia(ByVal it As VentaItem) As Boolean
        If Not venderSinExistencia Then
            Dim totalsalida As Integer = 0
            totalsalida = it.Cantidad

            For Each item As VentaItem In Items
                If item.Producto.Id = it.Producto.Id Then
                    totalsalida += item.Cantidad
                End If
            Next

            If totalsalida > it.Producto.Existencia Then
                Return False
            End If
            Return True
        Else
            Return True
        End If

        
    End Function
    Public Sub AgregarItem(ByVal item As VentaItem)
        If item.Cantidad <= 0 Then
            Throw New ReglasNegocioException("Cantidad invalida")
        End If

        If hayExistencia(item) Then
            item.Id = _id

            If Not item.Promocion Then

                If ExisteItem(item.Producto.Id, item.Cantidad, item.DescuentoPor) Then
                    Exit Sub
                End If

                If Not item.Producto.Rango = 0 Then
                    If item.DescuentoPor = 0 Then
                        If item.Cantidad >= item.Producto.Rango Then
                            item.DescuentoPor = item.Producto.Descuento
                        End If
                    End If
                    '  item.DescuentoDin = (item.Producto.Precio * item.Cantidad) - (item.Producto.Precio / (1 + (item.DescuentoPor / 100)) * item.Cantidad)
                    'item.DescuentoDin = (item.Producto.Precio * item.Cantidad) - ((item.Producto.Precio * item.DescuentoPor / 100) * item.Cantidad)
                    item.DescuentoDin = ((item.Producto.Precio * item.DescuentoPor / 100) * item.Cantidad)
                End If
                item.DescuentoDin = ((item.Producto.Precio * item.DescuentoPor / 100) * item.Cantidad)
            Else
                If ExisteItemPromocion(item.Producto.Id, item.Cantidad) Then
                    Exit Sub
                End If
                'item.DescuentoDin = item.Producto.Precio * item.DescuentoPor / 100 * item.Cantidad
                ' item.DescuentoDin = (item.Producto.Precio * item.Cantidad) - (item.Producto.Precio / (1 + (item.DescuentoPor / 100)) * item.Cantidad)
                'item.DescuentoDin = (item.Producto.Precio * item.Cantidad) - ((item.Producto.Precio * item.DescuentoPor / 100) * item.Cantidad)
                item.DescuentoDin = ((item.Producto.Precio * item.DescuentoPor / 100) * item.Cantidad)
            End If
            ''calculo del iva desgosado por producto
            ' If item.Producto.Iva Then
            ' item.Producto.Precio = item.Producto.Precio / (1 + (ivaValor / 100))
            'End If


            Items.Add(item)

            _id += 1
        Else
            Throw New ReglasNegocioException("No se puede cubrir la cantidad solicitada")
        End If
    End Sub
    Public Function GetItem(ByVal id As Integer) As VentaItem
        For Each i As VentaItem In _ventaItems
            If id = i.Id Then
                Return i
                Exit For
            End If
        Next
        Return Nothing
    End Function
    Public Function ExisteItemPromocion(ByVal id_prod As Integer, ByVal cantidad As Decimal) As Boolean
        For Each i As VentaItem In _ventaItems
            If id_prod = i.Producto.Id And i.Promocion = True Then
                i.Cantidad += cantidad
                If Not i.TipoPromocion = "Descuento" Then
                    i.DescuentoPor = 100
                End If

                i.DescuentoDin = i.Producto.Precio * i.DescuentoPor / 100 * i.Cantidad
                i.Total()
                'Descuentos(i.Id)
                Return True
                Exit For
            End If
        Next
        Return False
    End Function
    Public Function ExisteItem(ByVal id_prod As Integer, ByVal cantidad As Decimal, ByVal descuento As Decimal) As Boolean
        For Each i As VentaItem In _ventaItems
            If id_prod = i.Producto.Id And Not i.Promocion Then
                i.Cantidad += cantidad
                i.DescuentoPor = descuento
                i.DescuentoDin = i.Producto.Precio * i.DescuentoPor / 100 * i.Cantidad
                i.Total()
                Descuentos(i.Id)
                Return True
                Exit For
            End If
        Next
        Return False
    End Function
    Private Sub Descuentos(ByVal id_item As Integer)
        For Each i As VentaItem In _ventaItems
            If i.Id = id_item Then
                If Not i.Producto.Rango = 0 Then
                    'If i.DescuentoPor = 0 Then
                    If i.Cantidad >= i.Producto.Rango Then
                        i.DescuentoPor = i.Producto.Descuento
                        'Else
                        '    i.DescuentoPor = 0
                    End If
                    'End If
                    Dim desc As Decimal = i.Producto.Precio * i.DescuentoPor / 100 * i.Cantidad
                    i.DescuentoDin = desc
                    'i.DescuentoDin = (i.Producto.Precio * i.Cantidad) - (i.Producto.Precio / (1 + (i.DescuentoPor / 100)) * i.Cantidad)
                Else
                    Dim desc As Decimal = i.Producto.Precio * i.DescuentoPor / 100 * i.Cantidad
                    i.DescuentoDin = desc

                End If
            End If
        Next
    End Sub
    Sub New()
        _ventaItems = New List(Of VentaItem)
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
    Public Property Id_cliente() As Integer
        Get
            Return _id_cliente
        End Get
        Set(ByVal value As Integer)
            _id_cliente = value
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
    Public Property Items() As List(Of VentaItem)
        Get
            Return _ventaItems
        End Get
        Set(ByVal value As List(Of VentaItem))
            _ventaItems = value
        End Set
    End Property
    Public Property Id_Servicio() As Integer
        Get
            Return _id_servicio
        End Get
        Set(ByVal value As Integer)
            _id_servicio = value
        End Set
    End Property
End Class
