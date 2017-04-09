Imports LogicaNegocio
Public Class frmCambiarPassword

    Private _usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As Usuario)
            _usuario = value
        End Set
    End Property

    Private Sub btnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        Cambiar()


    End Sub

    Private Sub Cambiar()

        Try

            If txtNuevoPassword.Text <> txtNuevoPasswordConfirm.Text Then
                txtNuevoPassword.Text = ""
                txtNuevoPasswordConfirm.Text = ""
                Throw New Exception("Password Diferentes")
            End If
            If Usuario.Password = Utils.GenerarHash(txtPasswordAnterior.Text) Then
                Dim cata As New Service_Usuario
                Usuario.Password = Utils.GenerarHash(txtNuevoPassword.Text)
                cata.ActualizarContraseña(Usuario)
                MsgBox("Contraseña Cambiada")
                Me.Close()
            Else
                txtPasswordAnterior.Text = ""
                Throw New Exception("Contraseña Anterior invalida")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmCambiarPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNuevoPassword.Text = ""
        txtNuevoPasswordConfirm.Text = ""
        txtPasswordAnterior.Text = ""
        txtPasswordAnterior.Select()
        txtPasswordAnterior.Focus()
    End Sub
End Class