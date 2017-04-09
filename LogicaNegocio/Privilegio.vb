Public Class Privilegio

    Private _id_privilegio As Integer
    Private _id_grupo As Integer
    Private _permiso As String

    Sub New()

    End Sub

    Sub New(ByVal id_priviegio As Integer, ByVal id_grupo As Integer, ByVal permiso As String)
        Me.Id_Privilegio = id_priviegio
        Me.Id_Grupo = id_grupo
        Me.Permiso = permiso
    End Sub

    Public Property Id_Privilegio() As Integer
        Get
            Return _id_privilegio
        End Get
        Set(ByVal value As Integer)
            _id_privilegio = value
        End Set
    End Property
    Public Property Id_Grupo() As Integer
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As Integer)
            _id_grupo = value
        End Set
    End Property
    Public Property Permiso() As String
        Get
            Return _permiso
        End Get
        Set(ByVal value As String)
            _permiso = value
        End Set
    End Property


End Class
