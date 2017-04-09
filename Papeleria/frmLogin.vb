Imports LogicaNegocio
Public Class frmLogin

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
    End Sub

    Private Sub btnLogin_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseHover
        lblAcc.Text = "Entrar"
    End Sub

    Private Sub btnLogin_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseLeave
        lblAcc.Text = ""
    End Sub

    Private Sub btnCancel_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseHover
        lblAcc.Text = "Cancelar"
    End Sub

    Private Sub btnCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
        lblAcc.Text = ""
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim sUs As New Service_Usuario
        Try
            If txtUsuario.Text = "" Then
                lblError.Text = "Nombre de usuario requerido."
                txtUsuario.Select()
            ElseIf txtPass.Text = "" Then
                txtPass.Select()
                lblError.Text = "Password requerido."
            Else
                Dim usuario As Usuario
                Try
                    usuario = sUs.Login(txtUsuario.Text, txtPass.Text)
                Catch ex As ReglasNegocioException
                    MsgBox(ex.Message)
                    Exit Sub
                Catch ex As Exception
                    MsgBox("Error de conexion")
                    Exit Sub
                End Try

                If Not Usuario.Activo Then
                    lblError.Text = "Usuario inactivo. Consulte al Admin."
                    txtPass.Text = ""
                    txtUsuario.Text = ""
                    txtUsuario.Select()
                Else
                    Me.Hide()
                    Dim sPr As New Service_Privilegios
                    Dim privs As List(Of Privilegio) = sPr.Obtener_Todos_Por_Grupo(Usuario.Id_Grupo)

                    Sesion.nombre_usuario = Usuario.Nombre
                    Sesion.id_usuario_sesion = Usuario.Id_Usuario

                    '//CARGANDO VARIABLES DE SESION

                    Dim configuracion As Configuracion = Nothing
                    Try
                        Dim sc As New Service_Configuracion
                        configuracion = sc.Obtener
                        Sesion.ciudad = configuracion.Ciudad & " " & configuracion.estado
                        Sesion.direccion = configuracion.Calle & " # " & configuracion.No_ext & " " & configuracion.Colonia & " " & configuracion.CP
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
                        Sesion.imagen = configuracion.Imagen
                        Sesion.Abrir_Cajon = configuracion.Cajon
                        Sesion.razonsocial = configuracion.Propietario
                        Sesion.conf = configuracion
                    Catch ex As Exception
                        If Err.Number = 5 Then
                            Dim A = MsgBox("Los datos de configuracion no han sido capturados, desea hacerlo ahora ?" _
                        , MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "")
                            If A = vbYes Then
                                Dim frm As New frmConfiguracion
                                frm.ShowDialog()

                                If Not frm.cargados Then
                                    MsgBox("Los datos de configuracion no fueron capturados.")
                                    Me.Close()
                                End If

                            Else
                                Me.Close()
                            End If
                        Else
                            MsgBox(ex.Message)
                        End If
                    End Try

                    lblError.Text = ""
                    Dim formaP As New frmPrincipal(Usuario, privs)
                    formaP.Show()




                End If
                
            End If


        Catch Ex As ReglasNegocioException
            lblError.Text = Ex.Message
            txtUsuario.Text = ""
            txtPass.Text = ""
            txtUsuario.Select()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPass.SelectAll()
        End If
    End Sub

    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub frmLogin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 45 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class