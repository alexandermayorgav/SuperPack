
Public Class BuscadorProductos
  
    Private _id As Integer
    Private _clave As String
    Private _descripcion As String
    Private _existencia As Decimal
    Private _stockmin As Decimal
    Private _stockmax As Decimal
    Private _linea As String
    Private _precio As Decimal
    Private _status As Boolean
    Private _costo As Decimal
    Private _id_linea As Integer
    Private _menudeo As Decimal
    Private _pzas As Integer

    'BuscadorProductos
    Public Sub New(ByVal id As Integer, ByVal clave As String, ByVal descripcion As String, ByVal existencia As Decimal, ByVal stockmin As Decimal, ByVal stockmax As Decimal, ByVal linea As String, ByVal precio As Decimal, ByVal menudeo As Decimal, ByVal costo As Decimal)
        Me.Id = id
        Me.CLAVE = clave
        Me.DESCRIPCION = descripcion
        Me.EXISTENCIA = existencia
        Me.STOCK_MIN = stockmin
        Me.STOCK_MAX = stockmax
        Me.LINEA = linea
        Me.PRECIO = precio
        Me.MENUDEO = menudeo
        Me.COSTO = costo
    End Sub
    'Inventario
    Public Sub New(ByVal id As Integer, ByVal clave As String, ByVal descripcion As String, ByVal costo As Decimal, ByVal precio As Decimal, ByVal preciomenudeo As Decimal, ByVal existencia As Decimal, ByVal pzas As Integer, ByVal status As Boolean, ByVal linea As String, ByVal id_linea As Integer)
        Me.Id = id
        Me.CLAVE = clave
        Me.DESCRIPCION = descripcion
        Me.COSTO = costo
        Me.PRECIO = precio
        Me.MENUDEO = preciomenudeo
        Me.EXISTENCIA = existencia
        Me.PZAS = pzas
        Me.STATUS = status
        Me.LINEA = linea
        Me.IdLinea = id_linea
    End Sub


    Private _selecciona As Boolean
    Public Property Selecciona() As Boolean
        Get
            Return _selecciona
        End Get
        Set(ByVal value As Boolean)
            _selecciona = value
        End Set
    End Property


    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Public Property CLAVE() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property
    Public Property DESCRIPCION() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property EXISTENCIA() As Double
        Get
            Return _existencia
        End Get
        Set(ByVal value As Double)
            _existencia = value
        End Set
    End Property
    Public Property PZAS() As Integer
        Get
            Return _pzas
        End Get
        Set(ByVal value As Integer)
            _pzas = value
        End Set
    End Property
    Public Property STOCK_MIN() As Double
        Get
            Return _stockmin
        End Get
        Set(ByVal value As Double)
            _stockmin = value
        End Set
    End Property
    Public Property STOCK_MAX() As Double
        Get
            Return _stockmax
        End Get
        Set(ByVal value As Double)
            _stockmax = value
        End Set
    End Property
    Public Property LINEA() As String
        Get
            Return _linea
        End Get
        Set(ByVal value As String)
            _linea = value
        End Set
    End Property
    Public Property PRECIO() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property
    Public Property MENUDEO() As Decimal
        Get
            Return _menudeo
        End Get
        Set(ByVal value As Decimal)
            _menudeo = value
        End Set
    End Property
    Public Property STATUS() As Boolean
        Get
            Return _status
        End Get
        Set(ByVal value As Boolean)
            _status = value
        End Set
    End Property

    Public Property COSTO() As Double
        Get
            Return _costo
        End Get
        Set(ByVal value As Double)
            _costo = value
        End Set
    End Property
    Public Property IdLinea() As Integer
        Get
            Return _id_linea
        End Get
        Set(ByVal value As Integer)
            _id_linea = value
        End Set
    End Property
    Public ReadOnly Property STATUS2() As String
        Get
            If STATUS Then
                Return "Activo"
            Else
                Return "Inactivo"
            End If

        End Get

    End Property


    Private _PrecioUnitario As Double
    Public Property PrecioUnitario() As Double
        Get
            Return _PrecioUnitario
        End Get
        Set(ByVal value As Double)
            _PrecioUnitario = value
        End Set
    End Property



End Class
