Public Class BaseDatosException
    Inherits ApplicationException
    Public Sub New(ByVal mensaje As String, ByVal original As Exception)
        MyBase.New(mensaje, original)
    End Sub
    Public Sub New(ByVal mensaje As String)
        MyBase.New(mensaje)
    End Sub
End Class
