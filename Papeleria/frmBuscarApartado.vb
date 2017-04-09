Imports LogicaNegocio
Public Class frmBuscarApartado
    Private sC As Service_Cliente
    Private sAp As Service_Apartado
    Private objC As Cliente
    Public idAp As Integer = 0
    Private Sub frmBuscarApartado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        Me.KeyPreview = True
        sC = New Service_Cliente
        txtFolioC.Select()
    End Sub
    Private Sub limpiar()
        txtFolioC.Text = ""
        txtNom.Text = ""
        dgvAps.DataSource = Nothing
    End Sub
    Private Sub btnObtenerC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerC.Click
        Try
            objC = sC.Obtener(CInt(txtFolioC.Text))
            txtNom.Text = objC.Razon
            sAp = New Service_Apartado
            Dim listaAps As List(Of Apartado) = sAp.obtenerTodos(objC.Id)
            If Not listaAps Is Nothing Then
                If listaAps.Count > 0 Then
                    actualizaGrid(listaAps)
                Else
                    MsgBox("El cliente no tiene apartados")
                    dgvAps.DataSource = Nothing
                End If
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub limpiarAp()
        txtNom.Text = ""
        objC = Nothing
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim frm As New frmBuscarCliente
            frm.ShowDialog()
            If frm.id_cliente > 0 Then
                txtFolioC.Text = frm.id_cliente
                txtFolioC.Focus()
                btnObtenerC.PerformClick()
                frm = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            txtFolioC.Text = ""
            txtFolioC.Select()
        End Try
    End Sub
    Private Sub frmBuscarApartado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            btnBuscar.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub actualizaGrid(ByVal listaAps As List(Of Apartado))
        Try
            With dgvAps
                .DataSource = listaAps
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Width = 150
                .Columns(4).Width = 80
                .Columns(4).DefaultCellStyle.Format = "c"
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .Columns(10).Width = 200
            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvAps_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAps.DoubleClick
        Try
            If Not dgvAps.RowCount <= 0 Then
                idAp = CInt(dgvAps.CurrentRow.Cells(9).Value)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    
    Private Sub txtFolioC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioC.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnObtenerC.PerformClick()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class