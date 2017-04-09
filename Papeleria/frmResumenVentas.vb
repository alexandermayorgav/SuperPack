Imports LogicaNegocio
Imports MonoReports.Model


Public Class frmResumenVentas
    Dim service As New Service_Venta
    Private resumen As List(Of ResumenVentas)

    Private Sub frmResumenVentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F5 Then
                verVentas()
            End If

            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarCboVendedor()
        Dim cargaVendedores As New Service_Venta
        Try
            With cboVendedor
                .DataSource = cargaVendedores.llenarUsuarios.Tables(0)
                .DisplayMember = ("USUARIO")
                .ValueMember = ("ID_USUARIO")
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmResumenVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            cargarCboVendedor()
            chkVendedor.Checked = False
            cboVendedor.Enabled = False
            negritasHeader()
            dtpfechainicio.MinDate = Date.Now.AddMonths(-3)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub verVentas()
        Try
            If chkVendedor.Checked = True Then
                service = New Service_Venta
                resumen = New List(Of ResumenVentas)
                resumen = service.verVentasFecha(dtpfechainicio.Value.ToShortDateString, dtpfechafin.Value.ToShortDateString, cboVendedor.SelectedValue)
                dgvVentas.DataSource = resumen
                formatoDG()

                Dim total As Decimal
                For Each item As ResumenVentas In resumen
                    total += item.Total
                Next
                lblTotal.Text = String.Format("{0:n}", total)
                resumen = Nothing



            Else


                service = New Service_Venta
                resumen = New List(Of ResumenVentas)
                resumen = service.verVentasFecha(dtpfechainicio.Value.ToShortDateString, dtpfechafin.Value.ToShortDateString, 0)
                dgvVentas.DataSource = resumen
                formatoDG()

                Dim total As Decimal
                For Each item As ResumenVentas In resumen
                    total += item.Total
                Next
                lblTotal.Text = String.Format("{0:n}", total)
                resumen = Nothing

            End If
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatoDG()
        ' dgvVentas.Columns(0).Visible = False 'id venta
        dgvVentas.Columns(0).Width = 50
        dgvVentas.Columns(0).HeaderText = "FOLIO VENTA"
        dgvVentas.Columns(1).Visible = False 'id usuario

        dgvVentas.Columns(2).HeaderText = "FECHA DE EXPEDICIÓN"
        dgvVentas.Columns(2).Width = 135 'Fecha
        dgvVentas.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy - hh:mm:ss"

        dgvVentas.Columns(3).HeaderText = "TOTAL ($) VENDIDO"
        dgvVentas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvVentas.Columns(3).DefaultCellStyle.Format = "c"
        dgvVentas.Columns(3).Width = 120 'Total

        dgvVentas.Columns(4).HeaderText = "VENDIÓ"
        dgvVentas.Columns(4).Width = 80 'usuario

        dgvVentas.Columns(5).HeaderText = "NOMBRE DEL USUARIO"
        dgvVentas.Columns(5).Width = 200 'total

        dgvVentas.Columns(6).HeaderText = "NOMBRE DEL CLIENTE"
        dgvVentas.Columns(6).Width = 200 'total

        Dim columna2 As DataGridViewColumn = dgvVentas.Columns(2)
        columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna3 As DataGridViewColumn = dgvVentas.Columns(3)
        columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna4 As DataGridViewColumn = dgvVentas.Columns(4)
        columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna5 As DataGridViewColumn = dgvVentas.Columns(5)
        columna5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub btnverVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnverVentas.Click
        verVentas()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub chkVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVendedor.CheckedChanged
        If chkVendedor.Checked = True Then
            cboVendedor.Enabled = True
        ElseIf chkVendedor.Checked = False Then
            cboVendedor.Enabled = False
        End If
    End Sub
    Private Sub negritasHeader()
        Dim cellStyle As New DataGridViewCellStyle

        cellStyle.Font = New Font("Arial", 7.5, FontStyle.Bold)

        dgvVentas.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmResumenVentas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

            If Not dgvVentas.DataSource Is Nothing Then



                Using Form As New FrmDespliegaReporte(TryCast(dgvVentas.DataSource, List(Of ResumenVentas)).ToList())
                    Form.ShowDialog()

                End Using



                'Dim rep As New Report

                'Dim total As Double = CType(dgvVentas.DataSource, List(Of ResumenVentas)).Sum(Function(p) p.Total)

                'rep.DataSource = dgvVentas.DataSource

                'Dim dic As New Dictionary(Of String, Object)
                'dic.Add("Param.Total", String.Format("{0:C}", total))

                'rep.Load("Reportes\reportedeventas.mrp")

                'Dim file As String = My.Computer.FileSystem.GetTempFileName
                'rep.ExportToPdf(file & ".pdf", dic)
                'System.Diagnostics.Process.Start(file & ".pdf")

                'rep = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        
    End Sub
    Private Sub dgvVentas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVentas.CellDoubleClick
        Try
            Dim frm As New frmConsultaVentas(dgvVentas.CurrentRow.Cells(0).Value, dgvVentas.CurrentRow.Cells(2).Value, dgvVentas.CurrentRow.Cells(3).Value, dgvVentas.CurrentRow.Cells(4).Value)

            frm.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub
End Class