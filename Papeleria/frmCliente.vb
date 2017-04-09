Imports LogicaNegocio
Public Class frmCliente
    Dim nuevo As Boolean = True
    Private sc As Service_Cliente = Nothing
    Private cliente As Cliente = Nothing
    Dim folio As Integer = 0
    Dim validacion As CValidation
    Dim keyascii As Short
    Private id_cliente As Integer

    Private Sub frmCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
       

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                btnBuscar.PerformClick()
            Case Keys.F5
                btnGuardar.PerformClick()
            Case Keys.F7
                btnNuevo.PerformClick()
        End Select
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarEstados()
        limpiar()
        obtenerFolio()
        Me.KeyPreview = True
    End Sub
    Private Sub cargarEstados()
        Try
            sc = New Service_Cliente
            With Me.ddlEstado
                .DataSource = sc.obtener_Estados.Tables(0)
                .DisplayMember = ("estado")
                .ValueMember = ("id_estado")
            End With
            sc = Nothing
            ddlEstado.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los Estados.", ex.Message)
        End Try

    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Try
            If Not txtFolio.Text = 1 Then


                If Not txtRazon.Text.Length <= 0 Then
                    sc = New Service_Cliente
                    If chkCredito.Checked Then
                        If txtLimite.Text = "" Then
                            MsgBox("Debes capturar el limite de credito")
                            txtLimite.Select()
                            Exit Sub
                        ElseIf Not CDec(txtLimite.Text) > 0 Then
                            MsgBox("El limite debe ser superior a 0")
                            txtLimite.Focus()
                            txtLimite.SelectAll()
                            Exit Sub
                        End If
                    End If

                    cliente = New Cliente(id_cliente, txtRazon.Text, IIf(txtRFC.Text.Length <= 0, "", txtRFC.Text), IIf(txtCalle.Text.Length <= 0, "", txtCalle.Text), IIf(txtInt.Text.Length <= 0, "", txtInt.Text), IIf(txtExt.Text.Length <= 0, "", txtExt.Text), IIf(txtColonia.Text.Length <= 0, "", txtColonia.Text), IIf(txtCP.Text.Length <= 0, "", txtCP.Text), IIf(txtTelefono.Text.Length <= 0, "", txtTelefono.Text), IIf(txtCiudad.Text.Length <= 0, "", txtCiudad.Text), IIf(ddlEstado.SelectedIndex < 0, 1, ddlEstado.SelectedValue), chkActivo.Checked, ddlDescuento.SelectedItem, IIf(chkCredito.Checked = True, True, False), Date.Now, CDec(txtLimite.Text), 0, 0)
                    cliente.Saldo = txtSaldo.Text


                    If nuevo Then ''insertar
                        Try
                            sc.insertar(cliente)
                            MsgBox("Guardado Correctamente.")
                            limpia()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    Else ''actualizar
                        Try

                            sc.actualizar(cliente)
                            MsgBox("Actualizado Correctamente.")
                            limpia()

                        Catch ex As ReglasNegocioException
                            MsgBox(ex.Message)
                        End Try

                    End If



                Else
                    MsgBox("Debe escribir la Razón Social/nombre del cliente.")
                    txtRazon.Focus()
                End If


            End If

        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End sub
    Private Sub limpia()
        sc = Nothing
        cliente = Nothing
        limpiar()
        obtenerFolio()
    End Sub
    Private Sub limpiar()
        txtCalle.Text = ""
        txtCiudad.Text = ""
        txtColonia.Text = ""
        txtCP.Text = ""
        txtExt.Text = ""
        txtInt.Text = ""
        txtRazon.Text = ""
        txtRFC.Text = ""
        txtTelefono.Text = ""
        chkActivo.Checked = True
        ddlEstado.Text = "-Seleccione-"
        ddlDescuento.SelectedIndex = 0
        btnGuardar.Text = "Guardar"
        ' obtenerFolio()
        txtRazon.Select()
        txtRazon.Focus()
        nuevo = True
        txtSaldo.Text = String.Format("{0:c}", 0)
        chkCredito.Checked = False
        dtp.Enabled = False
        txtLimite.Enabled = False
        txtLimite.Text = String.Format("{0:c}", 0)
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub obtenerFolio()
        Try
            sc = New Service_Cliente
            folio = sc.ObtenerMax()
            txtFolio.Text = folio + 1
            sc = Nothing
        Catch ex As Exception
            txtFolio.Text = folio + 1
            'Exit Try
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try

        Dim frm As New frmBuscarCliente
            frm.ShowDialog()


            If Not frm.id_cliente = 0 Then
                txtFolio.Text = frm.id_cliente
                folio = frm.id_cliente
                CargarDatos()
                
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub CargarDatos()
        Try
            sc = New Service_Cliente
            cliente = New Cliente
            cliente = sc.Obtener(CInt(txtFolio.Text))
            ' folio = cliente.Id
            id_cliente = cliente.Id
            txtFolio.Text = id_cliente
            txtRazon.Text = cliente.Razon
            txtRFC.Text = cliente.RFC
            txtCalle.Text = cliente.Calle
            txtInt.Text = cliente.Num_int
            txtExt.Text = cliente.Num_ext
            txtColonia.Text = cliente.Colonia
            txtCiudad.Text = cliente.Ciudad
            ddlEstado.SelectedValue = cliente.Id_estado
            chkActivo.Checked = cliente.Status
            ddlDescuento.SelectedIndex = cliente.Descuento
            txtCP.Text = cliente.CP
            txtTelefono.Text = cliente.Telefono
            nuevo = False
            btnGuardar.Text = "Actualizar"

            chkCredito.Checked = cliente.CreditoActivo
            Try
                dtp.Value = cliente.Fecha
            Catch ex As Exception
                Exit Try
            End Try

            txtLimite.Text = String.Format("{0:c}", cliente.Limite)
            txtSaldo.Text = String.Format("{0:c}", cliente.Saldo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If txtFolio.Text.Length <> 0 Then
                'If Not txtFolio.Text > folio Then
                CargarDatos()
                'Else
                'MsgBox("No existe el cliente.")
                'End If
            End If
        End If


        validacion = New CValidation
        keyascii = CShort(Asc(e.KeyChar))
        keyascii = CShort(validacion.SoloNumeros(keyascii))
        If keyascii = 0 Then
            e.Handled = True
        End If
        validacion = Nothing
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar()
        obtenerFolio()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCredito.CheckedChanged
        Try
            If chkCredito.Checked = True Then

                txtLimite.Enabled = True
                txtSaldo.Enabled = True
            Else
                txtSaldo.Enabled = False
                txtLimite.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtLimite_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLimite.KeyPress


        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))

        ChrW(Keys.Enter)
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
        '    'btnAceptar.PerformClick()
        'End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(13) Then
            ''Me.Button1.Focus()
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmCliente_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 45 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Not nuevo Then
            If MsgBox("Desea eliminar el cliente seleccionado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                Exit Sub
            End If
            sc.eliminar(id_cliente)
        End If
        
    End Sub
End Class
