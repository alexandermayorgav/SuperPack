Public Class Usuario

    Private _id_usuario As Integer
    Private _usuario As String
    Private _id_personal As Integer
    Private _nombre As String
    Private _password As String
    Private _id_grupo As String
    Private _activo As Boolean
    Sub New(ByVal id_usuario As Integer, ByVal usuario As String, ByVal id_personal As Integer, ByVal password As String, ByVal id_grupo As String, ByVal nombre As String, ByVal activo As Boolean)
        Me.Id_Usuario = id_usuario
        Me.Usuario = usuario
        Me.Id_Personal = id_personal
        Me.Password = password
        Me.Id_Grupo = id_grupo
        Me.Nombre = nombre
        Me.Activo = activo
    End Sub

    Sub New(ByVal id_usuario As Integer, ByVal usuario As String, ByVal id_personal As Integer, ByVal password As String, ByVal id_grupo As String, ByVal nombre As String)
        Me.Id_Usuario = id_usuario
        Me.Usuario = usuario
        Me.Id_Personal = id_personal
        Me.Password = password
        Me.Id_Grupo = id_grupo
        Me.Nombre = nombre
    End Sub
    Sub New(ByVal nombre As String, ByVal idg As Integer, ByVal idus As Integer, ByVal act As Boolean)
        Me.Nombre = nombre
        Me.Id_Grupo = idg
        Me.Id_Usuario = idus
        Me.Activo = act
    End Sub
    Sub New()

    End Sub

    Public Property Id_Usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property
    Public Property Id_Personal() As Integer
        Get
            Return _id_personal
        End Get
        Set(ByVal value As Integer)
            _id_personal = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Public Property Id_Grupo() As String
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As String)
            _id_grupo = value
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
    Public Property Activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property
End Class
