Public Class Vales
    Private _id As Integer
    Private _monto_inicial As Decimal
    Private _monto_actual As Decimal
    Private _fecha As Date
    Private _nombre_cliente As String
    Private _id_cliente As Integer
    Private _borrado As Char
    Private _id_usuario As Integer

    'PROPIEDADES UTILIZADAS PARA LA LISTA DE VALES EN CUALQUIER PAGO
    Private _monto_usar As Decimal
    Private _monto_restante As Decimal
    Public Property MontoRestante() As Decimal
        Get
            Return _monto_restante
        End Get
        Set(ByVal value As Decimal)
            _monto_restante = value
        End Set
    End Property
    Public Property MontoUsar() As Decimal
        Get
            Return _monto_usar
        End Get
        Set(ByVal value As Decimal)
            _monto_usar = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Integer, ByVal monto_inicial As Decimal, ByVal monto_actual As Decimal, ByVal fecha As Date, ByVal nombre As String, ByVal activo As Char, ByVal cliente As Integer)
        Me.Folio = id
        Me.MontoInicial = monto_inicial
        Me.MontoActual = monto_actual
        Me.Fecha = fecha
        Me.NombreCliente = nombre
        Me.Activo = activo
        Me.Cliente = cliente
    End Sub
    Sub New(ByVal id_vale As Integer, ByVal monto_usar As Decimal, ByVal monto_restante As Decimal, ByVal monto_inicial As Decimal, ByVal id_c As Integer)
        Me._monto_usar = monto_usar
        Me._monto_restante = monto_restante
        Me._id = id_vale
        Me.MontoInicial = monto_inicial
        Me.Cliente = id_c
    End Sub
    Public Sub New(ByVal id As Integer, ByVal monto_inicial As Decimal, ByVal fecha As Date, ByVal nombre As String, ByVal cliente As Integer, ByVal activo As Char, ByVal monto_actual As Decimal, ByVal usu As Integer)
        Me.Folio = id
        Me.MontoInicial = monto_inicial
        Me.Fecha = fecha
        Me.NombreCliente = nombre
        Me.Cliente = cliente
        Me.Activo = activo
        Me.MontoActual = monto_actual
        Me.Usuario = usu
    End Sub
    Public Property Cliente() As Integer
        Get
            Return _id_cliente
        End Get
        Set(ByVal value As Integer)
            _id_cliente = value
        End Set
    End Property
    Public Property Folio() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property MontoInicial() As Decimal
        Get
            Return _monto_inicial
        End Get
        Set(ByVal value As Decimal)
            _monto_inicial = value
        End Set
    End Property
    Public Property MontoActual() As Decimal
        Get
            Return _monto_actual
        End Get
        Set(ByVal value As Decimal)
            _monto_actual = value
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
    Public Property NombreCliente() As String
        Get
            Return _nombre_cliente
        End Get
        Set(ByVal value As String)
            _nombre_cliente = value
        End Set
    End Property
    Public Property Activo() As Char
        Get
            Return _borrado
        End Get
        Set(ByVal value As Char)
            _borrado = value
        End Set
    End Property
    Public Property Usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property
End Class
