Imports LogicaNegocio
Public Class frmBuscarProveedor
    Private busqueda As BuscarProveedor = Nothing
    Public _id_proveedor As Integer
    Public razon As String
    Public _seCancelo = True
    Private Sub frmBuscarProveedorvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtNombre.Focus()
        Try
            busqueda = New BuscarProveedor
            busqueda.iniciarBusqueda()
            FormatoDG()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmBuscarProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        enddb()
    End Sub
    Private Sub enddb()
        If Not busqueda Is Nothing Then
            busqueda.FinalizarBusqueda()
            busqueda = Nothing
        End If
    End Sub
    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If dgvP.RowCount > 0 Then
                Try
                    _id_proveedor = dgvP.CurrentRow.Cells(0).Value
                    razon = dgvP.CurrentRow.Cells(1).Value
                    Me.Close()
                Catch ex As Exception
                    MsgBox("No ha seleccionado ningún proveedor", MsgBoxStyle.Exclamation)
                End Try
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub dgvP_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvP.CellDoubleClick
        If dgvP.RowCount > 0 Then
            _id_proveedor = dgvP.CurrentRow.Cells(0).Value
            razon = dgvP.CurrentRow.Cells(1).Value
            Me.Close()
        End If
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        FormatoDG()
    End Sub
    Private Sub FormatoDG()
        Try
            If Not busqueda Is Nothing Then
                Dim list As List(Of BuscarProveedor.BProveedor) = busqueda.Obtener(txtNombre.Text)
                dgvP.DataSource = list
                dgvP.Columns(0).Width = 50
                dgvP.Columns(1).Width = 290
                dgvP.Columns(2).Width = 150
                list = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim columna0 As DataGridViewColumn = dgvP.Columns(0)
        columna0.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim columna1 As DataGridViewColumn = dgvP.Columns(1)
        columna1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim columna2 As DataGridViewColumn = dgvP.Columns(2)
        columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub
    Private Sub BaseCods_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub frmBuscarProveedor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class