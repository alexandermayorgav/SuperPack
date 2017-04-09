Imports LogicaNegocio
Public Class frmNuevoPersonal

    Private sPersonal As Service_Personal
    Private act As Boolean = False
    Private id_pers As Integer
    Private objP As Personal
    Private Sub frmNuevoPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        inicializar()
        If Me.id_pers > 0 Then
            act = True
            objP = sPersonal.obtener(Me.id_pers)
            mostrarDatosPersonal()
        Else
            nuevoPersonal()
        End If

    End Sub
    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByVal idPers As Integer)
        Me.id_pers = idPers
        InitializeComponent()
    End Sub
    Private Sub guardarPersonal()
        Try
            If txtNombre.Text = "" Then
                MsgBox("Nombre requerido")
                txtNombre.Focus()
            ElseIf txtDireccion.Text = "" Then
                MsgBox("Direccion requerida")
                txtDireccion.Focus()
            ElseIf txtTelefono.Text = "" Then
                MsgBox("Teléfono requerido")
                txtTelefono.Focus()
            ElseIf txtPuesto.Text = "" Then
                MsgBox("Puesto requerido")
                txtPuesto.Focus()
            Else
                If Not act Then
                    Dim objP As New Personal(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, txtEmail.Text, 1, txtPuesto.Text)
                    sPersonal.insertar(objP)
                    MsgBox("Personal: " + txtNombre.Text + " agregado con éxito ")
                    'nuevoPersonal()
                    'Cerrar y actualizar grid
                    Me.Close()
                    If Not frmPersonal Is Nothing Then
                        frmPersonal.obtenerActivos()
                    End If
                Else
                    Dim objPers As New Personal(objP.Id, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, txtEmail.Text, chkActivo.Checked, txtPuesto.Text)
                    sPersonal.actualizar(objPers)
                    MsgBox("Personal: " + txtNombre.Text + " actualizado con éxito ")
                    'nuevoPersonal()
                    'Cerrar y actualizar grid
                    Me.Close()
                    If Not frmPersonal Is Nothing Then
                        frmPersonal.obtenerActivos()
                    End If
                End If
                
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub nuevoPersonal()
        txtNombre.Text = ""
        txtDireccion.Text = ""
        txtEmail.Text = ""
        txtTelefono.Text = ""
        txtCelular.Text = ""
        txtPuesto.Text = ""

        txtNombre.Select()
        txtNombre.Focus()
    End Sub
    Private Sub mostrarDatosPersonal()
        Try

            txtNombre.Text = objP.Nombre
            txtDireccion.Text = objP.Direccion
            txtTelefono.Text = objP.Telefono
            txtCelular.Text = objP.Celular
            txtEmail.Text = objP.Email
            chkActivo.Visible = True
            chkActivo.Checked = objP.Activo
            txtPuesto.Text = objP.Puesto

        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmNuevoPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            guardarPersonal()
        End If
        If e.KeyCode = Keys.F7 Then
            nuevoPersonal()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardarPersonal()
    End Sub
 

    Private Sub inicializar()
        sPersonal = New Service_Personal
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevoPersonal()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmNuevoPersonal_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 25 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class