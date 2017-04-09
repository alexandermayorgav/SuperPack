Public Class Linea
    Public _id As Integer
    Public _linea As String

    Sub New()

    End Sub
    Sub New(ByVal id As Integer, ByVal linea As String)
        Me.Id = id
        Me.Linea = linea
    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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

End Class
