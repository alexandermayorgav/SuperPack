Public Class Mover
    Private Declare Function SendMessage _
             Lib "user32" _
             Alias "SendMessageA" ( _
                 ByVal hwnd As Integer, _
                 ByVal wMsg As Integer, _
                 ByVal wParam As Integer, _
                 ByRef lParam As Object) As Integer

    Private Declare Function ReleaseCapture Lib "user32" () As Integer
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2

    Public Shared Sub Mover_Formulario(ByVal frm As Form)
        ReleaseCapture()
        frm.Cursor = Cursors.NoMove2D
        Dim ret As Integer = SendMessage( _
                                    frm.Handle.ToInt32, _
                                    WM_NCLBUTTONDOWN, _
                                    HTCAPTION, 0)
        frm.Cursor = Cursors.Default
    End Sub
End Class
