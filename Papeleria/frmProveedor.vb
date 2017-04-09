Imports LogicaNegocio
Public Class frmProveedor
    Private esNuevo As Boolean = True
    Dim proveedor As Proveedor
    Private KeyAscii As Short
    Dim id_prov As Integer = 0
    Dim forma As frmBuscarProveedor

    Private Sub frmProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F7 Then
            cleanForma()
        End If
        If e.KeyCode = Keys.F5 Then
            GuardarActualizar()
        End If
        If e.KeyCode = Keys.Delete Then
            Eliminar()
        End If
        If e.KeyCode = Keys.F2 Then
            buscarProveedor()
        End If
    End Sub
    Private Sub frmProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            txtFolio.Select()
            UltimoFolioMasUno()
            chkStatus.Checked = True
            lblStatus.Text = "Nuevo proveedor"
            btnGuardar.Text = "Guardar"
            esNuevo = True
            cargarEstados()
            cboEstado.SelectedValue = 2
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub UltimoFolioMasUno()
        Dim service As New Service_Proveedor
        Try
            id_prov = service.MaxFolio()
            txtId.Text = id_prov + 1
            service = Nothing
        Catch ex As Exception
            txtId.Text = id_prov + 1
            Exit Try
        End Try
    End Sub
    Private Sub cargarEstados()
        Dim service As New Service_Proveedor
        Try
            With cboEstado
                .DataSource = service.Estados.Tables(0)
                .DisplayMember = "estado"
                .ValueMember = "id_estado"
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress
        Dim validation As New CValidation

        KeyAscii = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(validation.SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If txtFolio.Text = "" Or txtFolio.Text.Length <= 0 Then
            cleanForma()
        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

            If txtFolio.Text = "" Then
                lblStatus.Text = "Nuevo proveedor"
                cleanForma()
            End If

            Dim service As New Service_Proveedor
            Try
                If Not txtFolio.Text = "" Then
                    proveedor = New Proveedor
                    proveedor = service.ObtenerProveedor(CInt(txtFolio.Text))

                    lblPP.Visible = True
                    dgvprods.Visible = True
                    obtenerProductosProveedor()

                    proveedor.IdProveedor = CInt(txtFolio.Text)
                    txtNombre.Text = proveedor.RazonSocial
                    txtRfc.Text = proveedor.Rfc
                    txtCalle.Text = proveedor.Calle
                    txtNumint.Text = proveedor.NumInt
                    txtNumext.Text = proveedor.NumExt
                    txtColonia.Text = proveedor.Colonia
                    txtCP.Text = proveedor.Cp
                    txtTelefono.Text = proveedor.Telefono
                    txtCiudad.Text = proveedor.Ciudad
                    cboEstado.SelectedValue = proveedor.IdEstado
                    chkStatus.Checked = IIf(proveedor.Status, 1, 0)

                    lblStatus.Text = proveedor.RazonSocial
                    btnGuardar.Text = "Actualizar"
                    esNuevo = False

                Else
                    cleanForma()
                End If
            Catch ex As ReglasNegocioException
                cleanForma()
            Catch ex As Exception
                MsgBox(ex.Message)
                cleanForma()
            End Try
        End If
    End Sub

    Private Sub obtenerProductosProveedor()
        Try
            Dim sprod As New Service_Producto
            Dim prods As List(Of ProductoVSE)
            prods = sprod.obtenerProductosProveedor(proveedor.IdProveedor)
            dgvprods.DataSource = Nothing
            With dgvprods
                .DataSource = prods
                .Columns(0).Width = 70
                .Columns(1).Width = 220
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cleanForma()
        proveedor = Nothing
        lblStatus.Text = "Nuevo proveedor"
        btnGuardar.Text = "Guardar"
        esNuevo = True
        chkStatus.Checked = True
        cboEstado.SelectedValue = 2
        txtFolio.Text = ""
        txtNombre.Text = ""
        txtRfc.Text = ""
        txtCalle.Text = ""
        txtNumint.Text = ""
        txtNumext.Text = ""
        txtColonia.Text = ""
        txtCP.Text = ""
        txtTelefono.Text = ""
        txtCiudad.Text = ""
        txtFolio.Focus()

        lblPP.Visible = False
        dgvprods.Visible = False
    End Sub
    Private Sub GuardarActualizar()
        Dim service As New Service_Proveedor
        Try
            If txtNombre.Text = "" Then
                Throw New Exception("Debe capturar un nombre")
            End If

            If esNuevo = True Then
                If service.existeProveedor(txtNombre.Text, -1) Then
                    MsgBox("Ya existe un proveedor con este nombre", MsgBoxStyle.Information)
                    txtNombre.Text = ""
                    esNuevo = True
                    txtNombre.Focus()
                    Exit Sub

                Else

                    proveedor = New Proveedor(-1, txtNombre.Text, txtRfc.Text, txtCalle.Text, txtNumint.Text, txtNumext.Text, txtColonia.Text, txtCP.Text, txtTelefono.Text, txtCiudad.Text, cboEstado.SelectedValue, IIf(chkStatus.Checked, 1, 0))
                    service.Insertar(proveedor)
                    esNuevo = False
                    MsgBox("Proveedor agregado", MsgBoxStyle.Information)
                    cleanForma()
                    UltimoFolioMasUno()
                End If

            Else

                Dim id As Integer = proveedor.IdProveedor
                proveedor = New Proveedor(id, txtNombre.Text, txtRfc.Text, txtCalle.Text, txtNumint.Text, txtNumext.Text, txtColonia.Text, txtCP.Text, txtTelefono.Text, txtCiudad.Text, cboEstado.SelectedValue, IIf(chkStatus.Checked, 1, 0))
                service.Actualizar(proveedor)
                MsgBox("Proveedor actualizado", MsgBoxStyle.Information)
                cleanForma()
                UltimoFolioMasUno()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            If txtFolio.Text = "" Or proveedor Is Nothing Then
                MsgBox("Seleccione un proveedor", MsgBoxStyle.Exclamation)
                txtFolio.Focus()
            Else
                Dim service As New Service_Proveedor
                If MsgBox("Eliminar a " & proveedor.RazonSocial, MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    service.Eliminar(CInt(txtFolio.Text.Trim))
                    MsgBox(proveedor.RazonSocial & " se eliminó correctamente", MsgBoxStyle.Information)
                    cleanForma()
                    esNuevo = True
                    txtFolio.Focus()
                Else
                    'cleanForma()
                    txtFolio.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub buscarProveedor()
        forma = New frmBuscarProveedor
        forma.ShowDialog()
        txtFolio.Text = ""
        txtFolio.Text = forma._id_proveedor
        txtFolio.Focus()
        SendKeys.Send("{ENTER}")
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        GuardarActualizar()
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        cleanForma()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        buscarProveedor()
    End Sub
    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress, txtRfc.KeyPress, txtColonia.KeyPress
        Dim validacion As New CValidation
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(validacion.LetrasNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtNumint_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumint.KeyPress, txtNumext.KeyPress
        Dim validacion As New CValidation
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(validacion.ValidaNumeroDeCalle(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtCP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP.KeyPress
        Dim validacion As New CValidation
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(validacion.SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtCiudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiudad.KeyPress
        Dim validacion As New CValidation
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(validacion.SoloLetras(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        Dim validacion As New CValidation
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(validacion.ValidaTelefonos(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmProveedor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class
