Imports LogicaNegocio
Public Class frmBuscarCliente
    Private cliente As Cliente = Nothing
    Private sc As Service_Cliente = Nothing
    Public id_cliente As Integer = 0

    Private Sub frmBuscarCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not sc Is Nothing Then
            sc.FinalizarBusqueda()
            sc = Nothing
        End If
    End Sub

    Private Sub frmBuscarCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmBuscarCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sc = New Service_Cliente
        sc.IniciarBusqueda()
        Me.KeyPreview = True
    End Sub
    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazon.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If dgv.RowCount > 0 Then
                Try
                    id_cliente = CInt(dgv.CurrentRow.Cells(0).Value)
                    Me.Close()
                Catch ex As Exception
                    MsgBox("No ha seleccionado ningún cliente", MsgBoxStyle.Exclamation)
                End Try
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub txtRazon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazon.TextChanged
        Try
            If Not txtRazon.Text.Length <= 0 Then
                Dim listac As List(Of Cliente) = sc.obtener_Clientes(txtRazon.Text)
                dgv.DataSource = listac
                listac = Nothing
                formatoGrid()
            Else
                dgv.DataSource = Nothing
            End If
        Catch ex As Exception
            If Err.Number = 91 Then
                dgv.DataSource = Nothing
                Exit Try
            Else
                MsgBox(ex.Message)
            End If

        End Try
        
    End Sub
    Private Sub formatoGrid()
        dgv.Columns(0).Visible = False
        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgv.Columns(2).Visible = False
        dgv.Columns(3).Visible = False
        dgv.Columns(4).Visible = False
        dgv.Columns(5).Visible = False
        dgv.Columns(6).Visible = False
        dgv.Columns(7).Visible = False
        dgv.Columns(8).Visible = False
        dgv.Columns(9).Visible = False
        dgv.Columns(10).Visible = False
        dgv.Columns(11).Visible = False
        dgv.Columns(12).Visible = False
        dgv.Columns(13).Width = 50
        dgv.Columns(13).HeaderText = "Credito"
        'dgv.Columns(14).Width = 120
        dgv.Columns(14).Visible = False
        'dgv.Columns(15).Visible = False
        dgv.Columns(15).DefaultCellStyle.Format = "c"
        dgv.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns(16).Visible = False
        'dgv.Columns(17).Visible = False
        dgv.Columns(17).DefaultCellStyle.Format = "c"
        dgv.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If Not dgv.RowCount < 0 Then
            id_cliente = CInt(dgv.CurrentRow.Cells(0).Value)
            Me.Close()
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmBuscarCliente_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 25 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class