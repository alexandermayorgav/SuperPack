Imports LogicaNegocio
Public Class frmCodigosHermanos

    Private esnuevo As Boolean
    Private codigo_hermano As Integer


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
         iniciar()
        Try
            Dim cat As New Service_Codigos
            codigo_hermano = cat.nuevoGrupo
            Label1.Text = codigo_hermano
            dgvCod.DataSource = Nothing
            esnuevo = False
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub iniciar()
        txtCodigo.Text = ""
        esnuevo = True
        codigo_hermano = -1
        txtCodigo.Focus()
    End Sub

    Private Sub VerGrupo(ByVal producto As Integer)
        esnuevo = False

        Try
            Dim cat As New Service_Codigos
            dgvCod.DataSource = cat.verGrupoChino(New Codigo(producto, 1, "", -1))
            codigo_hermano = CType(dgvCod.Rows(0).DataBoundItem, Codigo).Codigo_Hermano
            Label1.Text = codigo_hermano
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub AddtoGrupo()

        If esnuevo = False Then
            If codigo_hermano <> -1 Then

                Try

                    Dim cat As New Service_Codigos
                    If txtCodigo.Text.Trim = "" Then
                        frmBuscarProducto.ShowDialog()
                        If Not frmBuscarProducto.dgv.CurrentRow Is Nothing Then
                            Dim prod = CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto).Id
                            cat.AgregaraGrupo(New Codigo(prod, codigo_hermano))
                            VerGrupo(prod)
                        End If
                    Else
                        Dim sp = New Service_Producto
                        Dim prod = sp.Obtener(txtCodigo.Text.Trim).Id
                        cat.AgregaraGrupo(New Codigo(prod, codigo_hermano))
                        txtCodigo.Text = ""
                        VerGrupo(prod)
                    End If

                Catch ex As ReglasNegocioException
                    MsgBox(ex.Message)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End If

    End Sub
    Private Sub BorrarofGrupo()
        If dgvCod.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Try
            Dim cat As New Service_Codigos

            cat.QuitardeGrupo(CType(dgvCod.CurrentRow.DataBoundItem, Codigo).Id_Codigo)
            dgvCod.DataSource = cat.verGrupo2(codigo_hermano)

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click

        Try

            If txtCodigo.Text.Trim = "" Then
                frmBuscarProducto.ShowDialog()
                If Not frmBuscarProducto.dgv.CurrentRow Is Nothing Then
                    VerGrupo(CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto).Id)
                End If

            Else
                Dim sp = New Service_Producto
                Dim prod = sp.Obtener(txtCodigo.Text.Trim).Id
                txtCodigo.Text = ""
                VerGrupo(prod)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AddtoGrupo()
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        BorrarofGrupo()
    End Sub


    Private Sub frmCodigosHermanos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnNuevo.PerformClick()
        txtCodigo.Select()
        txtCodigo.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub frmUsuarios_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 40 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If

    End Sub
    Private Sub frmCodigosHermanos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

End Class