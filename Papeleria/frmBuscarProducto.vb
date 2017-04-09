Imports LogicaNegocio
Public Class frmBuscarProducto
    Private producto As Producto = Nothing
    Private sp As Service_Producto  = Nothing
    Public codigo As String = ""
    Public TipoProducto As Integer

    Public administracion As Boolean = False

    Private Sub frmBuscarCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not sp Is Nothing Then
            sp.FinalizarBusqueda()
            sp = Nothing
        End If
    End Sub

    Private Sub frmBuscarProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmBuscarCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgv.DataSource = Nothing
        txtProducto.Text = ""
        txtProducto.Select()
        txtProducto.Focus()
        sp = New Service_Producto
        sp.IniciarBusqueda()
        Me.KeyPreview = True
    End Sub
    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If dgv.RowCount > 0 Then
                Try
                    codigo = dgv.CurrentRow.Cells(1).Value
                    Me.Close()
                Catch ex As Exception
                    MsgBox("No ha seleccionado ningún producto", MsgBoxStyle.Exclamation)
                End Try
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub txtRazon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.TextChanged
        If Not txtProducto.Text.Length <= 2 Then
            If TipoProducto = 1 Then
                Dim listac As List(Of Producto) = sp.obtener_Productos(txtProducto.Text, 1)
                dgv.DataSource = listac
                listac = Nothing
            ElseIf TipoProducto = 2 Then
                Dim listac As List(Of Producto) = sp.obtener_Productos(txtProducto.Text, 2)
                dgv.DataSource = listac
                listac = Nothing
            ElseIf TipoProducto = 3 Then
                Dim listac As List(Of Producto) = sp.obtener_Productos(txtProducto.Text, 3)
                dgv.DataSource = listac
                listac = Nothing
            ElseIf TipoProducto = 0 Then
                Dim listac As List(Of Producto) = sp.obtener_Productos(txtProducto.Text, 0)
                dgv.DataSource = listac
                listac = Nothing
            Else

                Dim listac As List(Of Producto) = sp.obtener_Productos(txtProducto.Text)
                dgv.DataSource = listac
                listac = Nothing
            End If

            formatoGrid()
        Else
            dgv.DataSource = Nothing
        End If
    End Sub
    Private Sub formatoGrid()
        dgv.Columns(0).Visible = False

        dgv.Columns(2).Width = 120
        dgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgv.Columns(4).DefaultCellStyle.Format = "c"
        dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns(4).Width = 70
        If Not administracion Then
            dgv.Columns(4).Visible = False
        End If
        dgv.Columns(5).DefaultCellStyle.Format = "c"
        dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns(5).Width = 70
        dgv.Columns(6).Visible = False
        dgv.Columns(7).Visible = False
        dgv.Columns(8).Width = 60
        dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(9).Width = 60
        dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(10).Visible = False
        dgv.Columns(11).Visible = False
        dgv.Columns(12).Visible = False
        dgv.Columns(13).Visible = False
        dgv.Columns(14).Visible = False
        dgv.Columns(15).Visible = False
        dgv.Columns(16).Visible = False
        dgv.Columns(17).Visible = False
        dgv.Columns(18).Visible = False
        dgv.Columns(19).Visible = False
        dgv.Columns(20).Visible = False
        dgv.Columns(21).Visible = False
        dgv.Columns(22).Visible = False
        dgv.Columns(23).Width = 120
        'dgv.Columns(23).Visible = False
        'dgv.Columns(24).Visible = False
        dgv.Columns(25).HeaderText = "$ Menudeo"
        dgv.Columns(25).DefaultCellStyle.Format = "c"
        dgv.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns(25).Width = 70
        dgv.Columns(26).Visible = False
        dgv.Columns(27).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        rows()

    End Sub
    Private Sub rows()
        For row As Integer = 0 To dgv.RowCount - 1
            If row Mod 2 = 0 Then
                dgv.Rows(row).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next
    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If Not dgv.RowCount < 0 Then
            codigo = dgv.CurrentRow.Cells(1).Value
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmBuscarProducto_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 40 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

End Class