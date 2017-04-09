Imports LogicaNegocio
Public Class frmConfiguracion
    Private sc As Service_Configuracion
    Private configuracion As Configuracion
    Private nuevo As Boolean = True
    Public cargados As Boolean = False

    Dim validacion As CValidation
    Dim keyascii As Short

    Private Sub frmConfiguracion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            btnGuardar.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmConfiguracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaEstados()
        obtener()
        Me.KeyPreview = True

    End Sub
    Private Sub obtener()
        Try
            sc = New Service_Configuracion
            configuracion = New Configuracion
            configuracion = sc.Obtener

            txtCalle.Text = configuracion.Calle
            txtCiudad.Text = configuracion.Ciudad
            txtColonia.Text = configuracion.Colonia
            txtCP.Text = configuracion.CP
            txtExt.Text = configuracion.No_ext
            txtsistema.Text = configuracion.Sistema
            txtInt.Text = configuracion.No_int
            txtRazon.Text = configuracion.Propietario
            txtRFC.Text = configuracion.RFC
            txtTelefono.Text = configuracion.Telefono
            txtIVa.Text = configuracion.IVA
            txtSaludo.Text = configuracion.Saludo
            txtporecentaje.Text = configuracion.Porcentaje
            ddlEstados.SelectedIndex = configuracion.Id_estado - 1
            txtImpresora.Text = configuracion.Impresora
            btnGuardar2.Text = "Actualizar"
            nuevo = False
            txtdias.Text = configuracion.Dias
            chkVender.Checked = configuracion.VenderSinExistencias
            chkImprimeTicket.Checked = configuracion.ImprimeTicket
            chkCajon.Checked = configuracion.Cajon

            txtMedio.Text = configuracion.Porcentaje_Medio
            txtMenudeo.Text = configuracion.Porcentaje_Menudeo
            txtPrecioEmpaque.Text = configuracion.Precio_Empaque
            cargaSesion(1)




        Catch ex As Exception
            If Err.Number = 5 Then
                nuevo = True
                Exit Try
            Else
                MsgBox(ex.Message)
            End If
            cargados = False
        End Try
    End Sub
    Private Sub cargaSesion(ByVal transaccion As Integer)
        Try
            If transaccion = 1 Then
                Sesion.ciudad = configuracion.Ciudad & " " & configuracion.estado
            ElseIf transaccion = 2 Then
                Sesion.ciudad = configuracion.Ciudad & " " & ddlEstados.Text
            End If
            Sesion.direccion = configuracion.Calle & " # " & configuracion.No_ext & " " & configuracion.Colonia & " C.P " & configuracion.CP
            Sesion.iva = configuracion.IVA
            Sesion.negocio = configuracion.Sistema
            Sesion.porcetaje = configuracion.Porcentaje
            Sesion.rfc = configuracion.RFC
            Sesion.saludo = configuracion.Saludo
            Sesion.telefono = configuracion.Telefono
            Sesion.dias_apartado = configuracion.Dias
            Sesion.impresora = configuracion.Impresora
            Sesion.venderSinExis = configuracion.VenderSinExistencias
            Sesion.imprimeTicket = configuracion.ImprimeTicket
            Sesion.Abrir_Cajon = configuracion.Cajon
            Sesion.razonsocial = configuracion.Propietario
            Sesion.conf = configuracion

            cargados = True
        Catch ex As Exception
            cargados = False
            Throw New Exception("Error al cargar los datos en la sesion.")
        End Try

    End Sub
    Private Sub cargaEstados()
        Try
            sc = New Service_Configuracion
            Dim lista As List(Of Linea) = sc.obtener_Estados()
            ddlEstados.DataSource = lista
            sc = Nothing
            '  ddlEstado.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtIVa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIVa.KeyPress, txtporecentaje.KeyPress, txtMedio.KeyPress, txtMenudeo.KeyPress, txtPrecioEmpaque.KeyPress
        ChrW(Keys.Enter)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnGuardar.PerformClick()
        End If
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
    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmCompra_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    Private Sub txtdias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdias.KeyPress
        validacion = New CValidation
        keyascii = CShort(Asc(e.KeyChar))
        keyascii = CShort(validacion.SoloNumeros(keyascii))
        If keyascii = 0 Then
            e.Handled = True
        End If
        validacion = Nothing
    End Sub
    Private Sub btnImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImage.Click
        frmImagen.ShowDialog()
    End Sub
    Private Sub btnGuardar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar2.Click
        Try
            If Not txtCalle.Text.Length <= 0 And Not txtCiudad.Text.Length <= 0 And Not txtColonia.Text.Length <= 0 And Not txtExt.Text.Length <= 0 And Not txtIVa.Text.Length <= 0 And Not txtporecentaje.Text.Length <= 0 And Not txtRazon.Text.Length <= 0 And Not txtSaludo.Text.Length <= 0 And Not txtsistema.Text.Length <= 0 Then
                If (txtImpresora.Text.Length <= 0 And (chkImprimeTicket.Checked = True Or chkCajon.Checked = True)) Then
                    txtImpresora.Select()
                    txtImpresora.Focus()
                    Throw New Exception("Los datos de la impresora son requeridos.")

                End If
                sc = New Service_Configuracion
                configuracion = New Configuracion(txtRazon.Text, txtsistema.Text, txtRFC.Text, txtCalle.Text, txtInt.Text, txtExt.Text, txtColonia.Text, txtCiudad.Text, ddlEstados.SelectedValue, txtCP.Text, txtTelefono.Text, txtIVa.Text, txtSaludo.Text, CDec(txtporecentaje.Text), 0, IIf(txtImpresora.Text.Length > 0, txtImpresora.Text, ""), chkVender.Checked, chkImprimeTicket.Checked, chkCajon.Checked, txtMedio.Text, txtMenudeo.Text, txtPrecioEmpaque.Text)
                If nuevo Then
                    sc.insertar(configuracion)
                    MsgBox("Datos guardados correctamente.")
                    btnGuardar2.Text = "Actualizar"
                    nuevo = False
                Else 'actualizar
                    sc.actualizar(configuracion)
                    MsgBox("Datos actualizados correctamente.")

                End If
                cargaSesion(2)
                sc = Nothing
                configuracion = Nothing
            Else
                Throw New Exception("Los campos marcados con  *  son requeridos")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class