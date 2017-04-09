Public Class Personal

    Private _nombre As String
    Private _direccion As String
    Private _telefono As String
    Private _celular As String
    Private _email As String
    Private _activo As Boolean
    Private _puesto As String
    Private _id As Integer

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Sub New()

    End Sub
    Sub New(ByVal id As Integer, ByVal nombre As String, ByVal direcc As String, ByVal tel As String, ByVal cel As String, ByVal email As String, ByVal activo As Boolean, ByVal puesto As String)
        Me.Id = id
        Me.Nombre = nombre
        Me.Direccion = direcc
        Me.Telefono = tel
        Me.Celular = cel
        Me.Email = email
        Me.Activo = activo
        Me.Puesto = puesto
    End Sub
    Sub New(ByVal nombre As String, ByVal direcc As String, ByVal tel As String, ByVal cel As String, ByVal email As String, ByVal activo As Boolean, ByVal puesto As String)
        Me.Nombre = nombre
        Me.Direccion = direcc
        Me.Telefono = tel
        Me.Celular = cel
        Me.Email = email
        Me.Activo = activo
        Me.Puesto = puesto
    End Sub

    Public Property Puesto() As String
        Get
            Return _puesto
        End Get
        Set(ByVal value As String)
            _puesto = value
        End Set
    End Property
    Public Property Activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Public Property Celular() As String
        Get
            Return _celular
        End Get
        Set(ByVal value As String)
            _celular = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

End Class
