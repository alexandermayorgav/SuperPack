Imports LogicaNegocio
Public Class frmBuscadorProductos
    Private busqueda As BuscadorProductos = Nothing
    Dim service As New Service_Producto
    Private Sub frmBuscadorProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            cargarCboLinea()
            txtProducto.Select()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub buscarProductos()
        Try

            service = New Service_Producto
            Dim listaProductos As List(Of BuscadorProductos)
            listaProductos = service.obtenListaProductos(txtProducto.Text, cboLinea.SelectedValue)
            dgvResultado.DataSource = listaProductos
            listaProductos = Nothing
            FormatoDG()


        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            'MsgBox(ex.Message) 'La conversion del tipo datarowview en el tipo integer no es valida
        End Try
    End Sub
    Private Sub txtProducto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.TextChanged
        Try
            'If txtProducto.Text = "" Then
            '    dgvResultado.DataSource = Nothing
            'Else
            buscarProductos()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        buscarProductos()
    End Sub
    Private Sub cargarCboLinea()
        Dim cargaLinea As New Service_Producto
        Try
            With cboLinea
                .DataSource = cargaLinea.llenarLineas.Tables(0)
                .DisplayMember = ("DESCRIPCION")
                .ValueMember = ("ID_LINEA")
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmBuscadorProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub FormatoDG()
        dgvResultado.Columns(0).Visible = False 'idproducto
        dgvResultado.Columns(4).Visible = False 'pzas
        dgvResultado.Columns(10).Visible = False 'status
        dgvResultado.Columns(12).Visible = False 'idlinea
        dgvResultado.Columns(13).Visible = False 'status2
        dgvResultado.Columns(1).Width = 85 'clave
        dgvResultado.Columns(2).Width = 200
        dgvResultado.Columns(3).Width = 75 'existencia
        dgvResultado.Columns(5).Width = 75 'min
        dgvResultado.Columns(6).Width = 75 'max
        dgvResultado.Columns(8).DefaultCellStyle.Format = "c" 'precio
        dgvResultado.Columns(9).DefaultCellStyle.Format = "c" 'menudeo
        dgvResultado.Columns(11).DefaultCellStyle.Format = "c" 'costo
        dgvResultado.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvResultado.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvResultado.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvResultado.Columns(8).Width = 75
        dgvResultado.Columns(9).Width = 75
        dgvResultado.Columns(11).Width = 75
      
        alinearEncabezadoGrid()
    End Sub
    Private Sub alinearEncabezadoGrid()
        Try
            For x As Integer = 0 To dgvResultado.Columns.Count - 1
                dgvResultado.Columns(x).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboLinea_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLinea.SelectedValueChanged
        buscarProductos()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmBuscadorProductos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class