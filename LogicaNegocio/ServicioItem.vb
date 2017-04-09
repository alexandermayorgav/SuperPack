Public Class ServicioItem

    Private _id_list As Integer
    Private _id_sd As String
    Private _id_serv As String
    Private _desc As String
    Private _tipo As String
    Private _edo_serv As String
    Private _cantidad As Integer
    Private _costo As Decimal
    Private _precio As Decimal
    Private _disp As Boolean
    Private _producto As Producto
    Private _id_prod As String
    Sub New()

    End Sub
    ''CON PRODUCTO
    'Sub New(ByVal idsd As String, ByVal idserv As String, ByVal desc As String, ByVal tipo As String, ByVal edoserv As String, ByVal cant As Integer, ByVal costo As Decimal, ByVal precio As Decimal, ByVal prod As Producto)
    '    Me.IdServDetalle = idsd
    '    Me.Id_Servicio = idserv
    '    Me.Descripcion = desc
    '    Me.Tipo = tipo
    '    Me.Estado_Servicio = edoserv
    '    Me.Cantidad = cant
    '    Me.Costo = costo
    '    Me.Precio = precio
    '    Me.Disponible = False
    '    Me.Producto = prod
    'End Sub
    'SIN PRODUCTO
    Sub New(ByVal idsd As String, ByVal idserv As String, ByVal desc As String, ByVal tipo As String, ByVal edoserv As String, ByVal cant As Integer, ByVal costo As Decimal, ByVal precio As Decimal, ByVal idprod As String)
        Me.IdServDetalle = idsd
        Me.Id_Servicio = idserv
        Me.Descripcion = desc
        Me.Tipo = tipo
        Me.Estado = edoserv
        Me.Cantidad = cant
        Me.Costo = costo
        Me.Precio = precio
        Me.Disponible = False
        Me.IdProducto = idprod
    End Sub
    'PARA LA CONFORMACION
    Sub New(ByVal desc As String, ByVal tipo As String, ByVal edoserv As String, ByVal cant As Integer, ByVal costo As Decimal, ByVal precio As Decimal, ByVal idprod As String)
        Me.Descripcion = desc
        Me.Tipo = tipo
        Me.Estado = edoserv
        Me.Cantidad = cant
        Me.Costo = costo
        Me.Precio = precio
        Me.Disponible = False
        Me.IdProducto = idprod
    End Sub
    Public Property IdProducto() As String
        Get
            Return _id_prod
        End Get
        Set(ByVal value As String)
            _id_prod = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _id_list
        End Get
        Set(ByVal value As Integer)
            _id_list = value
        End Set
    End Property
    Public Property IdServDetalle() As String
        Get
            Return _id_sd
        End Get
        Set(ByVal value As String)
            _id_sd = value
        End Set
    End Property
    Public Property Id_Servicio() As String
        Get
            Return _id_serv
        End Get
        Set(ByVal value As String)
            _id_serv = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return _edo_serv
        End Get
        Set(ByVal value As String)
            _edo_serv = value
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
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Public Property Disponible() As Boolean
        Get
            Return _disp
        End Get
        Set(ByVal value As Boolean)
            _disp = value
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
End Class
