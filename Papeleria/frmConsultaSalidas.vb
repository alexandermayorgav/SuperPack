Imports LogicaNegocio
Public Class frmConsultaSalidas
    Private Salidas As CSalida
    Private SalidasDetalle As CSalidaDetalle
    Private salidasservice As Service_Salida
    Private Sub frmConsultaCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SalidasDetalle = New CSalidaDetalle
        Salidas = New CSalida
        salidasservice = New Service_Salida
        Me.KeyPreview = True
    End Sub
    Private Sub frmCotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        VerCompras()
    End Sub

    Private Sub VerCompras()
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
            Dim Ssalidas As New Service_Salida
            dgvSalidas.DataSource = Ssalidas.ObtenerSalidas(fecha1, fecha2, verpor)
            dgvSalidas.Columns(0).HeaderText = "Folio"
            dgvSalidas.Columns(0).Width = 70
            dgvSalidas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSalidas.Columns(1).Visible = False
            dgvSalidas.Columns(2).HeaderText = "Nombre Usuario"
            dgvSalidas.Columns(2).Width = 279
            dgvSalidas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvSalidas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            Salidas = salidasservice.obtenerProductosSalidas(folio)
            ObtenerProductosSalidas()
        End If
    End Sub
    Public Sub ObtenerProductosSalidas()
        Dim R As Short = 0
        Dim totalSalida As Decimal = 0
        dgvProductosSalidas.Rows.Clear()

        For Each item As CSalidaDetalle In Salidas._salidaitems
            totalSalida += item.Cantidad * item.Costo
            With dgvProductosSalidas
                .Rows.Add()
                R = .RowCount - 1
                .Rows(R).Cells("codigo").Value = item.Producto.Codigo
                .Rows(R).Cells("Descripcion").Value = item.Producto.Descripcion
                .Rows(R).Cells("Cantidad").Value = item.Cantidad
                .Rows(R).Cells("CostoU").Value = item.Costo
            End With
        Next

        Dim renglo As Integer = dgvProductosSalidas.RowCount - 1

        If Not renglo <= 0 Then
            dgvProductosSalidas.FirstDisplayedScrollingRowIndex = dgvProductosSalidas.Rows(renglo).Index
        End If
        dgvProductosSalidas.Columns(0).Width = 80
        dgvProductosSalidas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvProductosSalidas.Columns(1).Width = 219
        dgvProductosSalidas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvProductosSalidas.Columns(2).Width = 60
        dgvProductosSalidas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvProductosSalidas.Columns(3).Width = 90
        dgvProductosSalidas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvProductosSalidas.Columns(3).DefaultCellStyle.Format = "c"
        txtTotalsalida.Text = String.Format("{0:c}", totalSalida)
    End Sub
End Class