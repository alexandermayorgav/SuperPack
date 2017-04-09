Public Class Apartado

    Private _id_apartado As Integer
    Private _id_cliente As Integer
    Private _id_usuario As Integer
    Private _codigo_barras As String
    Private _cantidad As Integer
    Private _monto As Decimal
    Private _fecha_apartado As Date
    Private _fecha_entrega As Date
    Private _entregado As Boolean
    Private _devuelto As Boolean
    Private _descripcion As String 'apartado
    
    Sub New()

    End Sub
    Sub New(ByVal id_ap As Integer, ByVal id_c As Integer, ByVal id_us As Integer, ByVal codigo As String, ByVal cant As Integer, ByVal monto As Decimal, ByVal fecha_ap As Date, ByVal fecha_ent As Date, ByVal entregado As Boolean, ByVal devuelto As Boolean)
        Me.IdApartado = id_ap
        Me.IdCliente = id_c
        Me.IdUsuario = id_us
        Me.CodigoBarras = codigo
        Me.Cantidad = cant
        Me.Monto = monto
        Me.FechaApartado = fecha_ap
        Me.FechaEntrega = fecha_ent
        Me.Entregado = entregado
        Me.Devuelto = devuelto
    End Sub

    Sub New(ByVal id_ap As Integer, ByVal monto As Decimal, ByVal fecha_ap As Date, ByVal descripcion As String)
        Me.IdApartado = id_ap
        Me.Monto = monto
        Me.FechaApartado = fecha_ap
        Me.Descripcion = descripcion
    End Sub

    Sub New(ByVal id_c As Integer, ByVal id_us As Integer, ByVal codigo As String, ByVal cant As Integer, ByVal monto As Decimal, ByVal fecha_ap As Date)
        Me.IdCliente = id_c
        Me.IdUsuario = id_us
        Me.CodigoBarras = codigo
        Me.Cantidad = cant
        Me.Monto = monto
        Me.FechaApartado = fecha_ap
    End Sub

    Public Property Devuelto() As Boolean
        Get
            Return _devuelto
        End Get
        Set(ByVal value As Boolean)
            _devuelto = value
        End Set
    End Property

    Public Property Entregado() As Boolean
        Get
            Return _entregado
        End Get
        Set(ByVal value As Boolean)
            _entregado = value
        End Set
    End Property

    Public Property FechaEntrega() As Date
        Get
            Return _fecha_entrega
        End Get
        Set(ByVal value As Date)
            _fecha_entrega = value
        End Set
    End Property

    Public Property FechaApartado() As Date
        Get
            Return _fecha_apartado
        End Get
        Set(ByVal value As Date)
            _fecha_apartado = value
        End Set
    End Property

    Public Property Monto() As Decimal
        Get
            Return _monto
        End Get
        Set(ByVal value As Decimal)
            _monto = value
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

    Public Property CodigoBarras() As String
        Get
            Return _codigo_barras
        End Get
        Set(ByVal value As String)
            _codigo_barras = value
        End Set
    End Property

    Public Property IdUsuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property

    Public Property IdCliente() As Integer
        Get
            Return _id_cliente
        End Get
        Set(ByVal value As Integer)
            _id_cliente = value
        End Set
    End Property

    Public Property IdApartado() As Integer
        Get
            Return _id_apartado
        End Get
        Set(ByVal value As Integer)
            _id_apartado = value
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
End Class
