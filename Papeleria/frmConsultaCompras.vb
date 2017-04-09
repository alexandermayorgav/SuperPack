Imports LogicaNegocio
Public Class frmConsultaCompras
    Private Compras As CCompras
    Private ComprasDetalle As CCompraDetalle
    Private compraservice As Service_Compra
    Private Sub frmConsultaCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        ComprasDetalle = New CCompraDetalle
        Compras = New CCompras
        compraservice = New Service_Compra
    End Sub
    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        VerSalidas()
    End Sub
    Private Sub frmCotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub VerSalidas()
        Try
            dgvProductosSalidas.Rows.Clear()
            Dim verpor As String = ""
            Dim fecha1 As String = Utils.ObtenerFecha(dt1.Value)
            Dim fecha2 As String = Utils.ObtenerFecha(DateAdd(DateInterval.Day, 1, dt2.Value))
            If rbTodos.Checked Then
                verpor = "Todos"
            Else
                verpor = "Fecha"
            End If
            Dim Scompra As New Service_Compra
            dgvSalidas.DataSource = Scompra.ObtenerCompras(fecha1, fecha2, verpor)
            dgvSalidas.Columns(0).HeaderText = "Folio"
            dgvSalidas.Columns(1).Visible = False
            dgvSalidas.Columns(2).Visible = False
            dgvSalidas.Columns(3).Visible = False
            dgvSalidas.Columns(5).Visible = False
            dgvSalidas.Columns(6).Visible = False
            dgvSalidas.Columns(10).Visible = False
            dgvSalidas.Columns(11).Visible = False
            dgvSalidas.Columns(0).Width = 80
            dgvSalidas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSalidas.Columns(4).Width = 160
            dgvSalidas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSalidas.Columns(7).Width = 100
            dgvSalidas.Columns(7).DefaultCellStyle.Format = "c"
            dgvSalidas.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSalidas.Columns(8).Width = 100
            dgvSalidas.Columns(8).DefaultCellStyle.Format = "c"
            dgvSalidas.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSalidas.Columns(9).Width = 100
            dgvSalidas.Columns(9).DefaultCellStyle.Format = "c"
            dgvSalidas.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
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
    Private Sub frmVales_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    Private Sub dgvSalidas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSalidas.DoubleClick
        Dim folio As Integer
        If dgvSalidas.RowCount > 0 Then
            folio = dgvSalidas.CurrentRow.Cells(0).Value
            Compras = compraservice.obtenerProductosCompra(folio)
            ObtenerProductosCompra()
        End If
    End Sub
    Public Sub ObtenerProductosCompra()
        Dim R As Short = 0
        dgvProductosSalidas.Rows.Clear()

        For Each item As CCompraDetalle In Compras._compraitems
            With dgvProductosSalidas
                .Rows.Add()
                R = .RowCount - 1
                .Rows(R).Cells("Descripcion").Value = item.Producto.Descripcion
                .Rows(R).Cells("Cantidad").Value = item.Cantidad
                .Rows(R).Cells("CostoU").Value = item.Costo
                .Rows(R).Cells("DescuentoDinero").Value = (item.Costo * item.DescuentoD / 100 * item.Cantidad)
                .Rows(R).Cells("Importe").Value = item.Importe
            End With
        Next

        Dim renglo As Integer = dgvProductosSalidas.RowCount - 1

        If Not renglo <= 0 Then
            dgvProductosSalidas.FirstDisplayedScrollingRowIndex = dgvProductosSalidas.Rows(renglo).Index
        End If
        dgvProductosSalidas.Columns(0).Width = 224
        dgvProductosSalidas.Columns(1).Width = 60
        dgvProductosSalidas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvProductosSalidas.Columns(2).Width = 90
        dgvProductosSalidas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvProductosSalidas.Columns(2).DefaultCellStyle.Format = "c"

        dgvProductosSalidas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvProductosSalidas.Columns(3).Width = 75
        dgvProductosSalidas.Columns(3).DefaultCellStyle.Format = "c"

        dgvProductosSalidas.Columns(4).Width = 90
        dgvProductosSalidas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvProductosSalidas.Columns(4).DefaultCellStyle.Format = "c"
    End Sub
End Class