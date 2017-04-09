Imports LogicaNegocio
Imports MonoReports.Model

Public Class frmCuentasPagar
    Private busqueda As Service_Credito = Nothing
    Private Sub frmCuentasPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmCuentasPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True

            lblcuentasnew.Visible = False
            lbltotalcuentasnew.Visible = False
            lbltotalnew.Visible = False
            lblnumtotalnew.Visible = False

            negritasHeader()
            verCuentas() 'TODAS LAS CUENTAS
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub verCuentas()
        Try
            Dim service As Service_Credito = Nothing
            service = New Service_Credito
            Dim ds As List(Of CuentasPagar)
            ds = service.obtenerTodosCreditosProveedor()
            dgv1.DataSource = ds
            formatDG()
            Dim total As Decimal
            Dim totalDeudores As Integer = 0


            For Each item As CuentasPagar In ds
                total += item.Total
                totalDeudores = ds.Count
            Next
            lblTotal.Text = String.Format("{0:n}", total)
            lblDeudas.Text = totalDeudores

            ds = Nothing
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatDG()
  
        dgv1.Columns(0).Visible = False 'id_credito
        dgv1.Columns(1).Visible = False 'id_compra
        dgv1.Columns(6).Visible = False 'id_proveedor

        dgv1.Columns(2).Width = 150
        dgv1.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy - hh:mm:ss"
        dgv1.Columns(2).HeaderText = "FECHA DE COMPRA"
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Format = "c"
        dgv1.Columns(3).HeaderText = "TOTAL ($)"
        dgv1.Columns(3).Width = 130
        dgv1.Columns(4).HeaderText = "REALIZÓ LA COMPRA"
        dgv1.Columns(4).Width = 250
        dgv1.Columns(5).HeaderText = "USUARIO"
        dgv1.Columns(7).Width = 250
        dgv1.Columns(7).HeaderText = "PROVEEDOR"

        Dim columna2 As DataGridViewColumn = dgv1.Columns(2)
        columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna3 As DataGridViewColumn = dgv1.Columns(3)
        columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna4 As DataGridViewColumn = dgv1.Columns(4)
        columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna5 As DataGridViewColumn = dgv1.Columns(5)
        columna5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna7 As DataGridViewColumn = dgv1.Columns(7)
        columna7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub
    Private Sub formatDGProveedor()

        dgv2.Columns(0).Visible = False 'id_credito
        dgv2.Columns(1).Visible = False 'id_compra
        dgv2.Columns(6).Visible = False 'id_proveedor

        dgv2.Columns(2).Width = 150
        dgv2.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy - hh:mm:ss"
        dgv2.Columns(2).HeaderText = "FECHA DE COMPRA"
        dgv2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(3).DefaultCellStyle.Format = "c"
        dgv2.Columns(3).HeaderText = "TOTAL ($)"
        dgv2.Columns(3).Width = 130
        dgv2.Columns(4).HeaderText = "REALIZÓ LA COMPRA"
        dgv2.Columns(4).Width = 250
        dgv2.Columns(5).HeaderText = "USUARIO"
        dgv2.Columns(7).Width = 250
        dgv2.Columns(7).HeaderText = "PROVEEDOR"

        Dim columna2 As DataGridViewColumn = dgv2.Columns(2)
        columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna3 As DataGridViewColumn = dgv2.Columns(3)
        columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna4 As DataGridViewColumn = dgv2.Columns(4)
        columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna5 As DataGridViewColumn = dgv2.Columns(5)
        columna5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna7 As DataGridViewColumn = dgv2.Columns(7)
        columna7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub
    Private Sub formatDGFecha()

        dgv3.Columns(0).Visible = False 'id_credito
        dgv3.Columns(1).Visible = False 'id_compra
        dgv3.Columns(6).Visible = False 'id_proveedor

        dgv3.Columns(2).Width = 150
        dgv3.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy - hh:mm:ss"
        dgv3.Columns(2).HeaderText = "FECHA DE COMPRA"
        dgv3.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(3).DefaultCellStyle.Format = "c"
        dgv3.Columns(3).HeaderText = "TOTAL ($)"
        dgv3.Columns(3).Width = 130
        dgv3.Columns(4).HeaderText = "REALIZÓ LA COMPRA"
        dgv3.Columns(4).Width = 250
        dgv3.Columns(5).HeaderText = "USUARIO"
        dgv3.Columns(7).Width = 250
        dgv3.Columns(7).HeaderText = "PROVEEDOR"

        Dim columna2 As DataGridViewColumn = dgv3.Columns(2)
        columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna3 As DataGridViewColumn = dgv3.Columns(3)
        columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna4 As DataGridViewColumn = dgv3.Columns(4)
        columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna5 As DataGridViewColumn = dgv3.Columns(5)
        columna5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna7 As DataGridViewColumn = dgv3.Columns(7)
        columna7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub negritasHeader()
        Dim cellStyle As New DataGridViewCellStyle

        cellStyle.Font = New Font("Arial", 7.5, FontStyle.Bold)

        dgv1.ColumnHeadersDefaultCellStyle = cellStyle
        dgv2.ColumnHeadersDefaultCellStyle = cellStyle
        dgv3.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub
    Private Sub frmCuentasPagar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        enddb()
    End Sub
    Private Sub enddb()
        If Not busqueda Is Nothing Then
            busqueda.finalizarBusqueda()
            busqueda = Nothing
        End If
    End Sub
    Private Sub txtProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged
        buscarPorProveedor() 'BUSQUEDA POR CLIENTE
    End Sub
    Private Sub buscarPorProveedor()
        Try
            If Not busqueda Is Nothing Then
                Dim list As List(Of CuentasPagar) = busqueda.obtenerCreditosProveedor(txtProveedor.Text)
                dgv2.DataSource = list
                formatDGProveedor()

                Dim totalb As Decimal
                Dim totalDeudoresb As Integer = 0

                For Each item As CuentasPagar In list
                    totalb += item.Total
                    totalDeudoresb = list.Count
                Next
                lblTotal.Text = String.Format("{0:n}", totalb)
                lblDeudas.Text = totalDeudoresb

                list = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub verDeudasFecha()
        Try
            Dim servicef As Service_Credito = Nothing
            servicef = New Service_Credito
            Dim dsfecha As List(Of CuentasPagar)
            dsfecha = servicef.cuentasPagarPorFecha(dtp1.Value.ToShortDateString, dtp2.Value.ToShortDateString)
            dgv3.DataSource = dsfecha
            formatDGFecha()
            Dim totalf As Decimal
            Dim totalDeudoresf As Integer = 0


            For Each item As CuentasPagar In dsfecha
                totalf += item.Total
                totalDeudoresf = dsfecha.Count
            Next
            lbltotalcuentasnew.Text = String.Format("{0:n}", totalf)
            lblnumtotalnew.Text = totalDeudoresf

            dsfecha = Nothing

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp1.ValueChanged
        verDeudasFecha()
    End Sub
    Private Sub dtp2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp2.ValueChanged
        verDeudasFecha()
    End Sub
    Private Sub tab1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab1.SelectedIndexChanged
        If tab1.SelectedIndex = 0 Then
            lblTituloDeudores.Visible = True
            lblDeudas.Visible = True
            lblTitulototal.Visible = True
            lblTotal.Visible = True

            lblcuentasnew.Visible = False
            lbltotalcuentasnew.Visible = False
            lbltotalnew.Visible = False
            lblnumtotalnew.Visible = False

            verCuentas()
        ElseIf tab1.SelectedIndex = 1 Then

            lblTituloDeudores.Visible = True
            lblDeudas.Visible = True
            lblTitulototal.Visible = True
            lblTotal.Visible = True

            lblcuentasnew.Visible = False
            lbltotalcuentasnew.Visible = False
            lbltotalnew.Visible = False
            lblnumtotalnew.Visible = False

            txtProveedor.Focus()
            busqueda = New Service_Credito
            busqueda.iniciarBusqueda()
            buscarPorProveedor()

        ElseIf tab1.SelectedIndex = 2 Then
            dtp1.Focus()
            lblTituloDeudores.Visible = False
            lblDeudas.Visible = False
            lblTitulototal.Visible = False
            lblTotal.Visible = False

            lblcuentasnew.Visible = True
            lbltotalcuentasnew.Visible = True
            lbltotalnew.Visible = True
            lblnumtotalnew.Visible = True
            verDeudasFecha()

        End If
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmCuentasPagar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
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
            If tab1.SelectedIndex = 0 Then
                If Not dgv1.DataSource Is Nothing Then


                    Dim rep As New Report

                    Dim total As Double = CType(dgv1.DataSource, List(Of CuentasPagar)).Sum(Function(p) p.Total)

                    rep.DataSource = dgv1.DataSource

                    Dim dic As New Dictionary(Of String, Object)
                    dic.Add("Param.Total", String.Format("{0:c}", total))
                    dic.Add("Param.Cuentas", dgv1.Rows.Count)

                    rep.Load("Reportes\cuentaspagar.mrp")

                    Dim file As String = My.Computer.FileSystem.GetTempFileName

                    rep.ExportToPdf(file & ".pdf", dic)
                    System.Diagnostics.Process.Start(file & ".pdf")

                    rep = Nothing
                End If
            ElseIf tab1.SelectedIndex = 1 Then
                If Not dgv2.DataSource Is Nothing Then


                    Dim rep As New Report

                    Dim total As Double = CType(dgv2.DataSource, List(Of CuentasPagar)).Sum(Function(p) p.Total)

                    rep.DataSource = dgv2.DataSource

                    Dim dic As New Dictionary(Of String, Object)
                    dic.Add("Param.Total", total)
                    dic.Add("Param.Cuentas", dgv2.Rows.Count)

                    rep.Load("Reportes\cuentaspagar.mrp")

                    Dim file As String = My.Computer.FileSystem.GetTempFileName

                    rep.ExportToPdf(file & ".pdf", dic)
                    System.Diagnostics.Process.Start(file & ".pdf")

                    rep = Nothing
                End If
            ElseIf tab1.SelectedIndex = 2 Then
                If Not dgv3.DataSource Is Nothing Then


                    Dim rep As New Report

                    Dim total As Double = CType(dgv3.DataSource, List(Of CuentasPagar)).Sum(Function(p) p.Total)

                    rep.DataSource = dgv3.DataSource

                    Dim dic As New Dictionary(Of String, Object)
                    dic.Add("Param.Total", total)
                    dic.Add("Param.Deudas", dgv3.Rows.Count)

                    rep.Load("Reportes\cuentaspagar.mrp")

                    Dim file As String = My.Computer.FileSystem.GetTempFileName

                    rep.ExportToPdf(file & ".pdf", dic)
                    System.Diagnostics.Process.Start(file & ".pdf")

                    rep = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub
End Class