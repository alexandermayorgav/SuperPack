Imports LogicaNegocio
Public Class frmNuevoUsuario

    Private catalogo As Service_Usuario = Nothing
    Private usuario As Usuario = Nothing
    Public editar As Boolean = False
    Private id_personal As Integer = -1
  
    Public Property User() As Usuario
        Get
            Return usuario
        End Get
        Set(ByVal value As Usuario)
            usuario = value
        End Set
    End Property


    Private Sub frmNuevoUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If editar = True Then
            catalogo = New Service_Usuario
            ActualizaCampos()
            txtPassword.Enabled = False
            txtPasswordConfirm.Enabled = False
        Else
            txtPassword.Enabled = True
            txtPasswordConfirm.Enabled = True
            chkActivo.Visible = False
            Iniciar()
            ActualizaCampos()
        End If
        txtPersonal.SelectAll()
    End Sub

    Private Sub Iniciar()
        catalogo = New Service_Usuario
        usuario = Nothing
        editar = False
        id_personal = -1
    End Sub
    Private Sub Limpiar()
        usuario = Nothing
        editar = False
        id_personal = -1
    End Sub

    Private Sub ActualizaCampos()
        If usuario Is Nothing Then
            txtPersonal.Text = ""
            txtPasswordConfirm.Text = ""
            txtPassword.Text = ""
            txtUsuario.Text = ""
            btnAgregar.Text = "Agregar"
        Else
            txtPersonal.Text = usuario.Nombre
            txtPasswordConfirm.Text = usuario.Password
            txtPassword.Text = usuario.Password
            txtUsuario.Text = usuario.Usuario
            chkActivo.Checked = usuario.Activo
            btnAgregar.Text = "Actualizar"
        End If
    End Sub

    Private Sub ActualizaUsuario()

        If txtPersonal.Text.Trim = "" Or txtPassword.Text.Trim = "" Or txtPasswordConfirm.Text.Trim = "" Or txtUsuario.Text.Trim = "" Then
            Throw New Exception("Complete los campos")
        End If
        If txtPasswordConfirm.Text.Trim <> txtPassword.Text.Trim Then
            Throw New Exception("Contraseñas diferentes")
        End If
        If usuario Is Nothing Then
            usuario = New Usuario(-1, txtUsuario.Text, id_personal, utils.GenerarHash(txtPassword.Text), "2", txtPersonal.Text)
        Else
            usuario.Usuario = txtUsuario.Text
            usuario.Password = Utils.GenerarHash(txtPassword.Text)
            usuario.Activo = chkActivo.Checked
        End If
    End Sub

    Private Sub ActualizarInsertar()
        If usuario Is Nothing Then
            Try
                ActualizaUsuario()
                catalogo.Insertar(usuario)
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Limpiar()
                ActualizaCampos()
            End Try
        Else
            Try
                ActualizaUsuario()
                catalogo.Actualizar(usuario)
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
              
            End Try

        End If
    End Sub



    Private Sub btnAddAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        ActualizarInsertar()

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        frmPersonal.ShowDialog()
        Try
            Dim usu As Object = CType(frmPersonal.dgvPersonal.CurrentRow.DataBoundItem, Object)
            txtPersonal.Text = usu.Nombre
            id_personal = usu.id
            txtUsuario.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmNuevoUsuario_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 20 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    Private Sub frmPromocioness_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub
End Class