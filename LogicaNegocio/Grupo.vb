Public Class Grupo

    Private _id_grupo As Integer
    Private _nombre As String


    Sub New()

    End Sub
    Sub New(ByVal id_grupo As Integer, ByVal nombre As String)
        Me.Id_Grupo = id_grupo
        Me.Nombre = nombre
    End Sub

    Public Property Id_Grupo() As Integer
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As Integer)
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

End Class
