Public Class Faltantes
    Private _id_producto As Integer
    Private _codigo_clave As String
    Private _descripcion As String
    Private _costo As Decimal
    Private _precio As Decimal
    Private _stock_min As Decimal
    Private _stock_max As Decimal
    Private _existencia As Decimal
    Private _descripcion_linea As String
    Private _pzas As Integer
    Private _razonSocial As String
    Sub New()
    End Sub
    Sub New(ByVal id_producto As Integer, ByVal codigo_clave As String, ByVal descripcion As String, ByVal costo As Decimal, ByVal precio As Decimal, ByVal stock_min As Decimal, ByVal stock_max As Decimal, ByVal existencia As Decimal, ByVal pzas As Integer, ByVal descripcion_linea As String, ByVal proveedor As String)
        Me.IdProducto = id_producto
        Me.Codigo = codigo_clave
        Me.Descripcion = descripcion
        Me.Costo = costo
        Me.Precio = precio
        Me.StockMin = stock_min
        Me.StockMax = stock_max
        Me.Existencia = existencia
        Me.PzasCaja = pzas
        Me.Linea = descripcion_linea
        Me.Proveedor = proveedor

    End Sub
   
    Public Property IdProducto() As Integer
        Get
            Return _id_producto
        End Get
        Set(ByVal value As Integer)
            _id_producto = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return _codigo_clave
        End Get
        Set(ByVal value As String)
            _codigo_clave = value
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
    Public Property PzasCaja() As Integer
        Get
            Return _pzas
        End Get
        Set(ByVal value As Integer)
            _pzas = value
        End Set
    End Property
    Public Property Existencia() As Double
        Get
            Return _existencia
        End Get
        Set(ByVal value As Double)
            _existencia = value
        End Set
    End Property
    Public Property Costo() As Double
        Get
            Return _costo
        End Get
        Set(ByVal value As Double)
            _costo = value
        End Set
    End Property
    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property
    Public Property StockMin() As Double
        Get
            Return _stock_min
        End Get
        Set(ByVal value As Double)
            _stock_min = value
        End Set
    End Property
    Public Property StockMax() As Double
        Get
            Return _stock_max
        End Get
        Set(ByVal value As Double)
            _stock_max = value
        End Set
    End Property
    
    
    Public Property Linea() As String
        Get
            Return _descripcion_linea
        End Get
        Set(ByVal value As String)
            _descripcion_linea = value
        End Set
    End Property

    
    Public Property Proveedor() As String
        Get
            Return _razonSocial
        End Get
        Set(ByVal value As String)
            _razonSocial = value
        End Set
    End Property

End Class
