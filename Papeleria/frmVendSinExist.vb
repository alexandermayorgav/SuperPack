Imports LogicaNegocio
Public Class frmVendSinExist
    Private sprods As Service_Producto
    Private prods As List(Of ProductoVSE)

    Private Sub frmVendSinExist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Try
            sprods = New Service_Producto
            prods = sprods.obtenerProductosVSE
            formatoCantidad()
            actualizarGrid()
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub
    Private Sub formatoCantidad()
        Try
            For Each prod As ProductoVSE In prods
                prod.Cantidad = prod.Cantidad * -1
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub actualizarGrid()
        Try
            With dgvProds
                .DataSource = prods
                .Columns(0).Width = 110
                .Columns(1).Width = 250
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).DefaultCellStyle.Format = "c"
                .Columns(4).DefaultCellStyle.Format = "c"
            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmVendSinExist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmVendSinExist_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class