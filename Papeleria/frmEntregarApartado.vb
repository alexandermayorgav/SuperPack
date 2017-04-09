Imports LogicaNegocio
Public Class frmEntregarApartado
    Private objAp As Apartado
    Private sAbAp As Service_AbonoAp
    Private sAp As Service_Apartado
    Private totalAbs As Decimal
    Private saldo As Decimal
    Public idap As Integer
    Sub New(ByVal objApp As Apartado, ByVal totalAbs As Decimal)
        Me.objAp = objApp
        Me.totalAbs = totalAbs
        Me.saldo = objAp.Monto - totalAbs
        sAbAp = New Service_AbonoAp
        InitializeComponent()
    End Sub
    Private Sub frmEntregarApartado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtSaldo.Text = FormatCurrency(saldo)
        txtProducto.Select()
    End Sub

    Private Sub txtEfectivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEfectivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnEntregar.PerformClick()
        End If
    End Sub

    Private Sub txtEfectivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEfectivo.TextChanged
        If txtEfectivo.Text.Length <> 0 And Not txtEfectivo.Text = "" Then
            txtCambio.Text = String.Format("{0:c}", CDec(txtEfectivo.Text) - CDec(txtSaldo.Text))
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEfectivo.Select()
        End If
    End Sub

    Private Sub frmEntregarApartado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            btnEntregar.PerformClick()
        End If
    End Sub

    Private Sub btnEntregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntregar.Click
        If Not txtProducto.Text = objAp.CodigoBarras Then
            MsgBox("El producto leido no coincide con el apartado.")
            txtProducto.Focus()
            txtProducto.SelectAll()
        ElseIf Not CDec(txtEfectivo.Text) >= saldo Then
            MsgBox("Cantidad incorrecta. Debe cubrir el saldo para liberar el apartado.")
            txtEfectivo.Focus()
            txtEfectivo.SelectAll()
        Else
            '**********cambiar ids de caja y usuario
            Dim abono As New AbonoApartado(objAp.IdApartado, Utils.ObtenerFechaHora(Date.Now), id_caja, id_usuario_sesion, saldo)
            sAp = New Service_Apartado
            'sAp.entregar(abono, id_caja)
            MsgBox("Entregado con éxito")
            idap = abono.IdApartado
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmEntregarApartado_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 20 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class