Imports LogicaNegocio


Public Class frmTraspaso

    Private operaciones As opTraspaso
    Private WithEvents pro As frmProductosRelacionados


    Private Sub frmTraspaso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        iniciar()
      
    End Sub

    Private Sub iniciar()
        operaciones = New opTraspaso
        dgvitems.DataSource = Nothing

        clean()
    End Sub


    Private Sub btnPaq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaq.Click


        frmBuscarProducto.ShowDialog()

        If frmBuscarProducto.dgv.CurrentRow IsNot Nothing Then

            ' Dim traspaso As Traspaso = operaciones.verItem(CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto))

            operaciones.AddPaquete(CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto))


            If operaciones.ItemActual IsNot Nothing Then
                lblPaquete.Text = operaciones.ItemActual.Producto.Descripcion
                lblPiezasPaquete.Text = operaciones.ItemActual.Producto.Piezas & "   Pz"
                Recalcula()
                CalculaSobrantes()
            End If

        End If



    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If operaciones.ItemActual IsNot Nothing Then
            If txtBoxOpen.Text.Trim = "" Then
                MsgBox("Cajas Requeridas")
                Exit Sub
            ElseIf txtNumPaq.Text.Trim = "" Then
                MsgBox("Numero de paquetes requeridos")
                Exit Sub
            End If
            If operaciones.ItemActual.Sobrantes < 0 Then
                MsgBox("No se pueden armar esa cantidad de paquetes")
                Exit Sub
            End If

            operaciones.AgregarTraspaso(txtNumPaq.Text, txtBoxOpen.Text)
            DGVItems.DataSource = Nothing
            DGVItems.DataSource = operaciones.ItemsTraspaso
            clean()
            ' operaciones.ItemActual = Nothing
        End If
    End Sub

    Private Sub clean()
        lblCaja.Text = ""
        lblPaquete.Text = ""
        txtBoxOpen.Text = ""
        txtNumPaq.Text = ""
        lblCajaPiezas.Text = ""
        lblPiezasPaquete.Text = ""
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If operaciones.Guardar Then
            clean()
            iniciar()
        End If
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmResumenVentas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub btnCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaja.Click

        frmBuscarProducto.ShowDialog()

        If frmBuscarProducto.dgv.CurrentRow IsNot Nothing Then

            operaciones.AddCaja(CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto))
            If txtBoxOpen.Text.Trim <> "" Then
                txtNumPaq.Text = operaciones.TotalPaquetes(CInt(txtBoxOpen.Text))
            Else
                txtNumPaq.Text = "0"
            End If
            If operaciones.ItemActual IsNot Nothing Then
                lblCaja.Text = operaciones.ItemActual.Caja.Descripcion
                lblCajaPiezas.Text = operaciones.ItemActual.Caja.Piezas & "     Pz."
                Recalcula()
                CalculaSobrantes()
            End If

        End If

    End Sub


    Private Sub txts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxOpen.KeyPress, txtNumPaq.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            '' Me.Button1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(8) Then ' se pulsó Retroceso
            e.Handled = False
        ElseIf (e.KeyChar = ","c) Then ' no permite la coma
            e.Handled = True ' Handled = True, no permite; = False, si permite...
        ElseIf (e.KeyChar = "."c) Then
            Dim ctrl As TextBox = DirectCast(sender, TextBox)
            If (ctrl.Text.IndexOf("."c) <> -1) Then ' sólo puede haber una coma
                e.Handled = True
            End If
        ElseIf (e.KeyChar < "0"c Or e.KeyChar > "9"c) Then
            ' desechar los caracteres que no son dígitos
            e.Handled = True
        End If
    End Sub


    Private Sub txtBoxOpen_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoxOpen.TextChanged
        Recalcula()
    End Sub
    Private Sub txtpaq_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoxOpen.TextChanged, txtNumPaq.TextChanged
        CalculaSobrantes()
    End Sub

    Private Sub CalculaSobrantes()
        If txtBoxOpen.Text.Trim <> "" And txtNumPaq.Text.Trim <> "" And txtBoxOpen.Text.Trim <> "." And txtNumPaq.Text.Trim <> "." Then
            lblSobrantes.Text = operaciones.CalculaSobrantes(txtBoxOpen.Text, txtNumPaq.Text)
        Else
            lblSobrantes.Text = "0"
        End If

    End Sub
    Private Sub Recalcula()
        If operaciones.ItemActual IsNot Nothing Then
            If txtBoxOpen.Text.Trim <> "" And txtBoxOpen.Text.Trim <> "." Then
                txtNumPaq.Text = operaciones.TotalPaquetes(CInt(txtBoxOpen.Text))
                lblSobrantes.Text = operaciones.ItemActual.Sobrantes
            Else
                txtNumPaq.Text = "0"
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaqRel.Click

        Dim location As Point = Me.PointToScreen(New Point(btnPaqRel.Left + 20, btnPaqRel.Bottom + btnPaqRel.Height + 5))
        If operaciones.ItemActual IsNot Nothing Then

            If pro Is Nothing Then


                pro = New frmProductosRelacionados(operaciones.ItemActual.Caja.Id)
                pro.StartPosition = FormStartPosition.Manual
                pro.Location = location
                pro.Show()

            Else
                pro.Items(operaciones.ItemActual.Caja.Id)
                pro.Location = location
                pro.Show()
                pro.BringToFront()
            End If
        End If
    End Sub

    Private Sub cerrar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pro.Deactivate
        pro.Hide()
    End Sub
    Private Sub Seleccionado() Handles pro.Seleccionado
        pro.Hide()
        If pro.DataGridView1.CurrentRow IsNot Nothing Then

            operaciones.AddPaquete(CType(pro.DataGridView1.CurrentRow.DataBoundItem, Producto))

            If operaciones.ItemActual IsNot Nothing Then
                lblPaquete.Text = operaciones.ItemActual.Producto.Descripcion
                lblPiezasPaquete.Text = operaciones.ItemActual.Producto.Piezas & "   Pz."
                Recalcula()
                CalculaSobrantes()
            End If

        End If

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        iniciar()
    End Sub

    Private Sub frmTraspaso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub dgvitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvitems.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvitems.CurrentRow IsNot Nothing Then
                operaciones.BorrarItem(CType(dgvitems.CurrentRow.DataBoundItem, Traspaso).Caja.Id)
                dgvitems.DataSource = Nothing
                dgvitems.DataSource = operaciones.ItemsTraspaso
            End If
        End If
    End Sub


End Class