Imports LogicaNegocio
Imports MonoReports.Model

Public Class frmResumenCompras

    Dim service As New Service_Compra

    Private Sub frmResumenCompras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F5 Then
                verCompras()
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
    Private Sub cargarCboProveedor()
        Dim cargaProveedores As New Service_Compra
        Try
            With cboProveedor
                .DataSource = cargaProveedores.llenarProveedores.Tables(0)
                .DisplayMember = ("RAZON_SOCIAL")
                .ValueMember = ("ID_PROVEEDOR")
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmResumenVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            cargarCboVendedor()
            cargarCboProveedor()
            chkVendedor.Checked = False
            cboVendedor.Enabled = False
            chkProveedor.Checked = False
            cboProveedor.Enabled = False
            negritasHeader()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub verCompras()
        Try
            If chkVendedor.Checked = True And chkProveedor.Checked = True Then
                service = New Service_Compra
                Dim resumen As List(Of ResumenCompras)
                resumen = service.verComprasFecha(dtpfechainicio.Value.ToShortDateString, dtpfechafin.Value.ToShortDateString, cboVendedor.SelectedValue, cboProveedor.SelectedValue)
                dgvCompras.DataSource = resumen
                formatoDG()

                Dim total As Decimal
                For Each item As ResumenCompras In resumen
                    total += item.Total
                Next
                lblTotal.Text = String.Format("{0:n}", total)
                resumen = Nothing



            ElseIf chkVendedor.Checked = False And chkProveedor.Checked = True Then


                service = New Service_Compra
                Dim resumen As List(Of ResumenCompras)
                resumen = service.verComprasFecha(dtpfechainicio.Value.ToShortDateString, dtpfechafin.Value.ToShortDateString, 0, cboProveedor.SelectedValue)
                dgvCompras.DataSource = resumen
                formatoDG()

                Dim total As Decimal
                For Each item As ResumenCompras In resumen
                    total += item.Total
                Next
                lblTotal.Text = String.Format("{0:n}", total)
                resumen = Nothing


            ElseIf chkVendedor.Checked = True And chkProveedor.Checked = False Then


                service = New Service_Compra
                Dim resumen As List(Of ResumenCompras)
                resumen = service.verComprasFecha(dtpfechainicio.Value.ToShortDateString, dtpfechafin.Value.ToShortDateString, cboVendedor.SelectedValue, 0)
                dgvCompras.DataSource = resumen
                formatoDG()

                Dim total As Decimal
                For Each item As ResumenCompras In resumen
                    total += item.Total
                Next
                lblTotal.Text = String.Format("{0:n}", total)
                resumen = Nothing

            ElseIf chkVendedor.Checked = False And chkProveedor.Checked = False Then


                service = New Service_Compra
                Dim resumen As List(Of ResumenCompras)
               
                resumen = service.verComprasFecha(dtpfechainicio.Value, dtpfechafin.Value, 0, 0)
                dgvCompras.DataSource = resumen
                formatoDG()

                Dim total As Decimal
                For Each item As ResumenCompras In resumen
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
        dgvCompras.Columns(0).Visible = False 'id compra
        dgvCompras.Columns(1).Visible = False 'id usuario
        dgvCompras.Columns(6).Visible = False 'id proveedor

        dgvCompras.Columns(2).HeaderText = "FECHA DE EXPEDICIÓN"
        dgvCompras.Columns(2).Width = 135 'Fecha
        dgvCompras.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy - hh:mm:ss"

        dgvCompras.Columns(3).HeaderText = "TOTAL ($) COMPRADO"
        dgvCompras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompras.Columns(3).DefaultCellStyle.Format = "c"
        dgvCompras.Columns(3).Width = 120 'Total

        dgvCompras.Columns(4).HeaderText = "COMPRÓ"
        dgvCompras.Columns(4).Width = 80 'usuario

        dgvCompras.Columns(5).HeaderText = "NOMBRE DEL USUARIO"
        dgvCompras.Columns(5).Width = 200 'total

        dgvCompras.Columns(7).HeaderText = "PROVEEDOR"
        dgvCompras.Columns(7).Width = 200

        Dim columna2 As DataGridViewColumn = dgvCompras.Columns(2)
        columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna3 As DataGridViewColumn = dgvCompras.Columns(3)
        columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna4 As DataGridViewColumn = dgvCompras.Columns(4)
        columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna5 As DataGridViewColumn = dgvCompras.Columns(5)
        columna5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna7 As DataGridViewColumn = dgvCompras.Columns(7)
        columna7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub btnverCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnverCompras.Click
        verCompras()
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
    Private Sub chkProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If chkProveedor.Checked = True Then
            cboProveedor.Enabled = True
        ElseIf chkProveedor.Checked = False Then
            cboProveedor.Enabled = False

        End If
    End Sub
    Private Sub negritasHeader()
        Dim cellStyle As New DataGridViewCellStyle

        cellStyle.Font = New Font("Arial", 7.5, FontStyle.Bold)

        dgvCompras.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmResumenCompras_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
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
            If Not dgvCompras.DataSource Is Nothing Then


                Dim rep As New Report

                Dim total As Double = CType(dgvCompras.DataSource, List(Of ResumenCompras)).Sum(Function(p) p.Total)

                rep.DataSource = dgvCompras.DataSource

                Dim dic As New Dictionary(Of String, Object)
                dic.Add("Param.Total", String.Format("{0:c}", total))

                rep.Load("Reportes\reportedecompras.mrp")

                Dim file As String = My.Computer.FileSystem.GetTempFileName

                rep.ExportToPdf(file & ".pdf", dic)
                System.Diagnostics.Process.Start(file & ".pdf")

                rep = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub
End Class