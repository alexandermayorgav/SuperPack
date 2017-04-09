Public Class Producto
    Private _id As Integer
    Private _codigo As String
    Private _descripcion As String
    Private _costo As Decimal
    Private _precio As Decimal
    Private _stock_min As Decimal
    Private _stock_max As Decimal
    Private _pieza_caja As Integer
    Private _existencia As Decimal
    Private _descuento As Decimal
    Private _rango As Integer
    Private _id_linea As Integer
    Private _descuento_1 As Decimal
    Private _descuento_2 As Decimal
    Private _iva As Boolean
    Private _status As Boolean
    Private _items As List(Of Codigo)
    Private _kg As Boolean
    Private _id_caja As Integer
    Private _ProdActualizado As Boolean
    Private _ActualizarCodHermanos As Boolean

    Private _sobrante As Decimal
    Private _fechaCompras As Date
    Private _fechaActualizacion As Date
    Private _precioMenudeo As Decimal
    Private _linea As String
    Private _actulizado As Boolean ''bandera para actualizar las fechas de actualizacion de los paquetes paquetes

    Public Actualizar As Boolean
    Private _proveedor As String

    Private _cant As Integer = 1

    Sub New()

    End Sub
    Sub New(ByVal id As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal costo As Decimal, ByVal precio As Decimal, ByVal stock_min As Integer, ByVal stock_max As Integer, _
            ByVal piezas As Integer, ByVal existencia As Decimal, ByVal descuento As Decimal, ByVal rango As Integer, ByVal id_linea As Integer, ByVal descuento_1 As Decimal, _
            ByVal descuento_2 As Decimal, ByVal iva As Boolean, ByVal status As Boolean)
        Me.Id = id
        Me.Codigo = codigo
        Me.Descripcion = descripcion
        Me.Costo = costo
        Me.Precio = precio
        Me.Stock_min = stock_min
        Me.Stock_max = stock_max
        Me.Piezas = piezas
        Me.Existencia = existencia
        Me.Descuento = descuento
        Me.Rango = rango
        Me.Id_linea = id_linea
        Me.Descuento_1 = descuento_1
        Me.Descuento_2 = descuento_2
        Me.Iva = iva
        Me.Status = status
    End Sub

    Sub New(ByVal id As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal costo As Decimal, ByVal precio As Decimal, ByVal stock_min As Integer, ByVal stock_max As Integer, _
            ByVal piezas As Integer, ByVal existencia As Decimal, ByVal descuento As Decimal, ByVal rango As Integer, ByVal id_linea As Integer, ByVal iva As Boolean, ByVal status As Boolean, ByVal items As List(Of Codigo), ByVal kg As Boolean, ByVal sobrante As Decimal, ByVal fechaCompra As Date, ByVal fechaActualizacion As Date, ByVal precioMenudeo As Decimal)
        Me.Id = id
        Me.Codigo = codigo
        Me.Descripcion = descripcion
        Me.Costo = costo
        Me.Precio = precio
        Me.Stock_min = stock_min
        Me.Stock_max = stock_max
        Me.Piezas = piezas
        Me.Existencia = existencia
        Me.Descuento = descuento
        Me.Rango = rango
        Me.Id_linea = id_linea
        'Me.Descuento_1 = descuento_1
        'Me.Descuento_2 = descuento_2
        Me.Iva = iva
        Me.Status = status
        Me.Item = items
        Me.Kg = kg

        Me.Sobrante = sobrante
        Me.Fecha_Actualizacion = fechaActualizacion
        Me.Fecha_Compra = fechaCompra
        Me.Precio_Menudeo = precioMenudeo
    End Sub
    Sub New(ByVal id As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal costo As Decimal, ByVal precio As Decimal, ByVal stock_min As Integer, ByVal stock_max As Integer, _
           ByVal piezas As Integer, ByVal existencia As Decimal, ByVal descuento As Decimal, ByVal rango As Integer, ByVal id_linea As Integer, ByVal descuento_1 As Decimal, _
           ByVal descuento_2 As Decimal, ByVal iva As Boolean, ByVal status As Boolean, ByVal kg As Boolean)
        Me.Id = id
        Me.Codigo = codigo
        Me.Descripcion = descripcion
        Me.Costo = costo
        Me.Precio = precio
        Me.Stock_min = stock_min
        Me.Stock_max = stock_max
        Me.Piezas = piezas
        Me.Existencia = existencia
        Me.Descuento = descuento
        Me.Rango = rango
        Me.Id_linea = id_linea
        Me.Descuento_1 = descuento_1
        Me.Descuento_2 = descuento_2
        Me.Iva = iva
        Me.Status = status
        Me.Kg = kg
    End Sub
    Sub New(ByVal idprod As Integer, ByVal cod As String, ByVal desc As String, ByVal pieza As Integer, ByVal cost As Decimal, ByVal price As Decimal, ByVal priceMenudeo As Decimal, ByVal prodActualizado As Boolean)
        Me.Id = idprod
        Me.Codigo = cod
        Me.Descripcion = desc
        Me.Piezas = pieza
        Me.Costo = cost
        Me.Precio = price
        Me.Precio_Menudeo = priceMenudeo
        Me.ProductoActualizado = prodActualizado
    End Sub
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property
    Public Property Linea() As String
        Get
            Return _linea
        End Get
        Set(ByVal value As String)
            _linea = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
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
    Public Property Stock_min() As Integer
        Get
            Return _stock_min
        End Get
        Set(ByVal value As Integer)
            _stock_min = value
        End Set
    End Property
    Public Property Stock_max() As Integer
        Get
            Return _stock_max
        End Get
        Set(ByVal value As Integer)
            _stock_max = value
        End Set
    End Property
    Public Property Piezas() As Integer
        Get
            Return _pieza_caja
        End Get
        Set(ByVal value As Integer)
            _pieza_caja = value
        End Set
    End Property
    Public Property Existencia() As Decimal
        Get
            Return _existencia
        End Get
        Set(ByVal value As Decimal)
            _existencia = value
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
    Public Property Rango() As Integer
        Get
            Return _rango
        End Get
        Set(ByVal value As Integer)
            _rango = value
        End Set
    End Property
    Public Property Id_linea() As Integer
        Get
            Return _id_linea
        End Get
        Set(ByVal value As Integer)
            _id_linea = value
        End Set
    End Property
    Public Property Descuento_1() As Decimal
        Get
            Return _descuento_1
        End Get
        Set(ByVal value As Decimal)
            _descuento_1 = value
        End Set
    End Property
    Public Property Descuento_2() As Decimal
        Get
            Return _descuento_2
        End Get
        Set(ByVal value As Decimal)
            _descuento_2 = value
        End Set
    End Property
    Public Property Iva() As Boolean
        Get
            Return _iva
        End Get
        Set(ByVal value As Boolean)
            _iva = value

        End Set
    End Property
    Public Property Status() As Boolean
        Get
            Return _status
        End Get
        Set(ByVal value As Boolean)
            _status = value
        End Set
    End Property
    Public Property Item() As List(Of Codigo)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of Codigo))
            _items = value
        End Set
    End Property
    Public Property Kg() As Boolean
        Get
            Return _kg
        End Get
        Set(ByVal value As Boolean)
            _kg = value
        End Set
    End Property
    Public Property ProductoActualizado() As Boolean
        Get
            Return _ProdActualizado
        End Get
        Set(ByVal value As Boolean)
            _ProdActualizado = value
        End Set
    End Property
    Public Property ActualizarCodigosHermanos() As Boolean
        Get
            Return _ActualizarCodHermanos
        End Get
        Set(ByVal value As Boolean)
            _ActualizarCodHermanos = value
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
    Public Property IDCAJA() As Integer
        Get
            Return _id_caja
        End Get
        Set(ByVal value As Integer)
            _id_caja = value
        End Set
    End Property

    Public Property Sobrante() As Decimal
        Get
            Return _sobrante
        End Get
        Set(ByVal value As Decimal)
            _sobrante = value
        End Set
    End Property
    Public Property Fecha_Compra() As Date
        Get
            Return _fechaCompras
        End Get
        Set(ByVal value As Date)
            _fechaCompras = value
        End Set
    End Property
    Public Property Fecha_Actualizacion() As Date
        Get
            Return _fechaActualizacion
        End Get
        Set(ByVal value As Date)
            _fechaActualizacion = value
        End Set
    End Property
    Public Property Precio_Menudeo() As Decimal
        Get
            Return _precioMenudeo
        End Get
        Set(ByVal value As Decimal)
            _precioMenudeo = value
        End Set
    End Property
    Public Property Actualizado() As Boolean
        Get
            Return _actulizado
        End Get
        Set(ByVal value As Boolean)
            _actulizado = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
    End Class
