Public Class Servicio
    Private _id As Integer = 0
    Private _id_servicio As String
    Private _id_cliente As String
    Private _concecionaria As String
    Private _linea As String
    Private _tipo As String
    Private _modelo As Integer
    Private _color As String
    Private _placas As String
    Private _diagnostico As String
    Private _fecha_recep As Date
    Private _fecha_ent As Date
    Private _id_personal As String
    Private _observaciones As String
    Private _kilometraje As String
    Private _factura As Boolean
    Private _completo As Boolean
    Private _mecanico As String
    Private _items As List(Of ServicioItem)
    
    Sub New()
        Items = New List(Of ServicioItem)
    End Sub
    'CONSTRUCTOR GENERAL
    Sub New(ByVal id_serv As String, ByVal id_cliente As String, ByVal nombrec As String, ByVal concecionaria As String, ByVal linea As String, ByVal tipo As String, ByVal modelo As Integer, ByVal color As String, ByVal placas As String, ByVal diagnostico As String, ByVal fecha_recep As String, ByVal fecha_ent As String, ByVal id_pers As String, ByVal observ As String, ByVal km As String, ByVal fact As Boolean, ByVal comp As Boolean, ByVal mecanico As String)
        Me.Id_Servicio = id_serv
        Me.Id_Cliente = id_cliente
        Me.Concecionaria = concecionaria
        Me.Linea = linea
        Me.Tipo = tipo
        Me.Modelo = modelo
        Me.Color = color
        Me.Placas = placas
        Me.Diagnostico = diagnostico
        Me.Fecha_Recepcion = fecha_recep
        Me.Fecha_Entrega = fecha_ent
        Me.Id_Personal = id_pers
        Me.Observaciones = observ
        Me.Kilometraje = km
        Me.Factura = fact
        Me.Completo = comp
        Me.Mecanico = mecanico
        Me.NombreC = nombrec
        Me.Items = New List(Of ServicioItem)
    End Sub

    ''CONSTRUCTOR PARA OBTENER LOS AUTOS PERTENECIENTES A UN CLIENTE
    'Sub New(ByVal id_c As String, ByVal conc As String, ByVal linea As String, ByVal tipo As String, ByVal modelo As Integer, ByVal color As String, ByVal placas As String, ByVal km As String)
    '    Me.Id_Cliente = id_c
    '    Me.Concecionaria = conc
    '    Me.Linea = linea
    '    Me.Modelo = modelo
    '    Me.Color = color
    '    Me.Placas = placas
    '    Me.Kilometraje = km
    'End Sub
    Sub New(ByVal conc As String, ByVal linea As String, ByVal tipo As String, ByVal modelo As Integer, ByVal color As String, ByVal placas As String)
        Me.Concecionaria = conc
        Me.Linea = linea
        Me.Tipo = tipo
        Me.Modelo = modelo
        Me.Color = color
        Me.Placas = placas
    End Sub

    'OBTENER SERVICIOS
    Sub New(ByVal ids As String, ByVal lin As String, ByVal mode As String, ByVal color As String, ByVal plac As String, ByVal fechar As Date, ByVal fechaent As Date, ByVal comp As Boolean)
        Me.Id_Servicio = ids
        Me.Linea = lin
        Me.Modelo = mode
        Me.Color = color
        Me.Placas = plac
        Me.Fecha_Recepcion = fechar
        Me.Fecha_Entrega = fechaent
        Me.Completo = comp
    End Sub
    Private _cliente As String
    Public Property NombreC() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property

    Public Property Items() As List(Of ServicioItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of ServicioItem))
            _items = value
        End Set
    End Property
    Public Property Mecanico() As String
        Get
            Return _mecanico
        End Get
        Set(ByVal value As String)
            _mecanico = value
        End Set
    End Property

    Public Property Factura() As Boolean
        Get
            Return _factura
        End Get
        Set(ByVal value As Boolean)
            _factura = value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property

    Public Property Id_Personal() As String
        Get
            Return _id_personal
        End Get
        Set(ByVal value As String)
            _id_personal = value
        End Set
    End Property

    Public Property Diagnostico() As String
        Get
            Return _diagnostico
        End Get
        Set(ByVal value As String)
            _diagnostico = value
        End Set
    End Property

    Public Property Concecionaria() As String
        Get
            Return _concecionaria
        End Get
        Set(ByVal value As String)
            _concecionaria = value
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
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property
    Public Property Modelo() As Integer
        Get
            Return _modelo
        End Get
        Set(ByVal value As Integer)
            _modelo = value
        End Set
    End Property
    Public Property Color() As String
        Get
            Return _color
        End Get
        Set(ByVal value As String)
            _color = value
        End Set
    End Property

    Public Property Placas() As String
        Get
            Return _placas
        End Get
        Set(ByVal value As String)
            _placas = value
        End Set
    End Property
    Public Property Kilometraje() As String
        Get
            Return _kilometraje
        End Get
        Set(ByVal value As String)
            _kilometraje = value
        End Set
    End Property

    Public Property Fecha_Recepcion() As Date
        Get
            Return _fecha_recep
        End Get
        Set(ByVal value As Date)
            _fecha_recep = value
        End Set
    End Property

    Public Property Fecha_Entrega() As Date
        Get
            Return _fecha_ent
        End Get
        Set(ByVal value As Date)
            _fecha_ent = value
        End Set
    End Property
    Public Property Completo() As Boolean
        Get
            Return _completo
        End Get
        Set(ByVal value As Boolean)
            _completo = value
        End Set
    End Property
    
    Public Property Id_Cliente() As String
        Get
            Return _id_cliente
        End Get
        Set(ByVal value As String)
            _id_cliente = value
        End Set
    End Property

    Public Property Id_Servicio() As String
        Get
            Return _id_servicio
        End Get
        Set(ByVal value As String)
            _id_servicio = value
        End Set
    End Property


    'METODOS PARA EL MANEJO DE LOS ITEMS DEL SERVICIO

    Public Sub AgregarItem(ByVal item As ServicioItem)
        If item.Cantidad <= 0 Then
            Throw New ReglasNegocioException("Cantidad invalida")
        End If
        'If hayExistencia(item) Then
        item.Id = _id
        Items.Add(item)
        _id += 1
        'Else
        'Throw New ReglasNegocioException("No se puede cubrir la cantidad solicitada.")
        'End If
    End Sub

    Private Function hayExistencia(ByVal it As ServicioItem) As Boolean

        Dim totalsalida As Integer = it.Cantidad

        For Each item As ServicioItem In Items
            If item.Producto.Id = it.Producto.Id Then
                totalsalida += item.Cantidad
            End If
        Next

        If totalsalida > it.Producto.Existencia Then
            Return False
        End If
        Return True
    End Function

    Public Function GetItem(ByVal id As Integer) As ServicioItem
        For Each i As ServicioItem In Items
            If id = i.Id Then
                Return i
                Exit For
            End If
        Next
        Return Nothing
    End Function


    Public Function ExisteItem(ByVal id As Integer) As Boolean
        For Each i As ServicioItem In Items
            If id = i.Id Then
                Return True
                Exit For
            End If
        Next
        Return False
    End Function

    Public Function BorraItem(ByVal id As Integer) As Boolean
        For Each it As ServicioItem In Items
            If it.Id = id Then
                Items.Remove(it)
                Return True
            End If
        Next
        Return False
    End Function
End Class
