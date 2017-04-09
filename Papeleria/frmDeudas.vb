Imports LogicaNegocio
Imports MonoReports.Model


Public Class frmDeudas
    Private busqueda As Service_Credito = Nothing
    Private listaDeudas As List(Of CuentasCobrar)
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.busqueda = New Service_Credito
        Me.listaDeudas = Me.busqueda.obtenerTodosCreditos()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmDeudas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmDeudas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtpfin.Value.AddDays(1)
            lbltitulofechadeudas.Visible = False
            lbldeudasfecha.Visible = False
            lbltitulototalfechas.Visible = False
            lbltotalfechas.Visible = False

            Me.KeyPreview = True
            negritasHeader()
            verDeudas() 'TODAS LAS DEUDAS


            'busqueda = New Service_Credito
            'busqueda.iniciarBusqueda()
            'FormatoDGBusqueda() 'BUSQUEDA POR CLIENTE

            'verDeudasFecha() 'Entre 2 fechas

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmDeudas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ''enddb()
    End Sub
    Private Sub enddb()
        If Not busqueda Is Nothing Then
            busqueda.finalizarBusqueda()
            busqueda = Nothing
        End If
    End Sub
    Private Sub txtCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        ''FormatoDGBusqueda() 'BUSQUEDA POR CLIENTE
        verDeudas()
    End Sub
    Private Sub FormatoDGBusqueda()
        'Try
        '    If Not busqueda Is Nothing Then
        '        Dim list As List(Of CuentasCobrar) = busqueda.Obtener(txtCliente.Text)
        '        dgvCliente.DataSource = list
        '        formatDGCliente()

        '        Dim totalb As Decimal
        '        Dim totalDeudoresb As Integer = 0

        '        For Each item As CuentasCobrar In list
        '            totalb += item.Saldo
        '            totalDeudoresb = list.Count
        '        Next
        '        lblTotal.Text = String.Format("{0:n}", totalb)
        '        lblDeudas.Text = totalDeudoresb

        '        list = Nothing
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Private Sub verDeudas()
        Try
            'Dim service As Service_Credito = Nothing
            'service = New Service_Credito
            'Dim ds As List(Of CuentasCobrar)
            'ds = service.obtenerTodosCreditos()
            Dim lista = From cuentas In listaDeudas Where cuentas.FechaApertura >= dtpinicio.Value.ToShortDateString And cuentas.FechaApertura <= dtpfin.Value And cuentas.RSocial.Contains(txtCliente.Text) Select cuentas
            dgvDeudas.DataSource = lista.ToList()
            formatDG()
            Dim total As Decimal
            Dim totalDeudores As Integer = 0


            For Each item As CuentasCobrar In lista.ToList()
                total += item.Saldo
                totalDeudores = lista.Count
            Next
            lblTotal.Text = String.Format("{0:n}", total)
            lblDeudas.Text = totalDeudores

            ''ds = Nothing
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatDG()
        dgvDeudas.Columns(0).Visible = False 'idcredito
        dgvDeudas.Columns(1).Visible = False 'idcliente

        dgvDeudas.Columns(2).Width = 150
        dgvDeudas.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy - hh:mm:ss"
        dgvDeudas.Columns(2).HeaderText = "FECHA ULTIMA VENTA"

        dgvDeudas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDeudas.Columns(3).DefaultCellStyle.Format = "c"
        dgvDeudas.Columns(3).HeaderText = "LÍMITE DE CRÉDITO ($)"
        dgvDeudas.Columns(3).Width = 130

        dgvDeudas.Columns(4).HeaderText = "ACTIVO"
        dgvDeudas.Columns(4).Width = 50
        dgvDeudas.Columns(4).Visible = False 'idcliente

        dgvDeudas.Columns(5).HeaderText = "SALDO ($)"
        dgvDeudas.Columns(5).Width = 100
        dgvDeudas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDeudas.Columns(5).DefaultCellStyle.Format = "c"

        dgvDeudas.Columns(6).HeaderText = "CLIENTE"
        dgvDeudas.Columns(6).Width = 300
        dgvDeudas.Columns(7).Visible = False 'idcliente

        Dim columna2 As DataGridViewColumn = dgvDeudas.Columns(2)
        columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna3 As DataGridViewColumn = dgvDeudas.Columns(3)
        columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna4 As DataGridViewColumn = dgvDeudas.Columns(4)
        columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna5 As DataGridViewColumn = dgvDeudas.Columns(5)
        columna5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim columna6 As DataGridViewColumn = dgvDeudas.Columns(6)
        columna6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub
    Private Sub formatDGCliente()
        'dgvCliente.Columns(0).Visible = False 'idcredito
        'dgvCliente.Columns(1).Visible = False 'idcliente

        'dgvCliente.Columns(2).Width = 150
        'dgvCliente.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy - hh:mm:ss"
        'dgvCliente.Columns(2).HeaderText = "FECHA ULTIMA VENTA"

        'dgvCliente.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvCliente.Columns(3).DefaultCellStyle.Format = "c"
        'dgvCliente.Columns(3).HeaderText = "LÍMITE DE CRÉDITO ($)"
        'dgvCliente.Columns(3).Width = 130

        'dgvCliente.Columns(4).HeaderText = "ACTIVO"
        'dgvCliente.Columns(4).Width = 50

        'dgvCliente.Columns(5).HeaderText = "SALDO ($)"
        'dgvCliente.Columns(5).Width = 100
        'dgvCliente.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvCliente.Columns(5).DefaultCellStyle.Format = "c"

        'dgvCliente.Columns(6).HeaderText = "CLIENTE"
        'dgvCliente.Columns(6).Width = 300

        'Dim columna2 As DataGridViewColumn = dgvCliente.Columns(2)
        'columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim columna3 As DataGridViewColumn = dgvCliente.Columns(3)
        'columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim columna4 As DataGridViewColumn = dgvCliente.Columns(4)
        'columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim columna5 As DataGridViewColumn = dgvCliente.Columns(5)
        'columna5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim columna6 As DataGridViewColumn = dgvCliente.Columns(6)
        'columna6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub formatDGFecha()
        'dgvFecha.Columns(0).Visible = False 'idcredito
        'dgvFecha.Columns(1).Visible = False 'idcliente

        'dgvFecha.Columns(2).Width = 150
        'dgvFecha.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy - hh:mm:ss"
        'dgvFecha.Columns(2).HeaderText = "FECHA ULTIMA VENTA"

        'dgvFecha.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvFecha.Columns(3).DefaultCellStyle.Format = "c"
        'dgvFecha.Columns(3).HeaderText = "LÍMITE DE CRÉDITO ($)"
        'dgvFecha.Columns(3).Width = 130

        'dgvFecha.Columns(4).HeaderText = "ACTIVO"
        'dgvFecha.Columns(4).Width = 50

        'dgvFecha.Columns(5).HeaderText = "SALDO ($)"
        'dgvFecha.Columns(5).Width = 100
        'dgvFecha.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvFecha.Columns(5).DefaultCellStyle.Format = "c"

        'dgvFecha.Columns(6).HeaderText = "CLIENTE"
        'dgvFecha.Columns(6).Width = 300

        'Dim columna2 As DataGridViewColumn = dgvFecha.Columns(2)
        'columna2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim columna3 As DataGridViewColumn = dgvFecha.Columns(3)
        'columna3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim columna4 As DataGridViewColumn = dgvFecha.Columns(4)
        'columna4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim columna5 As DataGridViewColumn = dgvFecha.Columns(5)
        'columna5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim columna6 As DataGridViewColumn = dgvFecha.Columns(6)
        'columna6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub negritasHeader()
        Dim cellStyle As New DataGridViewCellStyle

        cellStyle.Font = New Font("Arial", 7.5, FontStyle.Bold)

        dgvDeudas.ColumnHeadersDefaultCellStyle = cellStyle
        'dgvCliente.ColumnHeadersDefaultCellStyle = cellStyle
        'dgvFecha.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub
    Private Sub verDeudasFecha()
        'Try
        '    'Dim servicef As Service_Credito = Nothing
        '    'servicef = New Service_Credito
        '    'Dim dsfecha As List(Of CuentasCobrar)
        '    Dim lista = From cuentas In listaDeudas Where cuentas.FechaApertura >= dtpinicio.Value.ToShortDateString And cuentas.FechaApertura <= dtpfin.Value.ToShortDateString Select cuentas
        '    ''dsfecha = servicef.obtenerCreditosFecha(dtpinicio.Value.ToShortDateString, dtpfin.Value.ToShortDateString)
        '    dgvFecha.DataSource = lista.ToList()
        '    formatDGFecha()
        '    Dim totalf As Decimal
        '    Dim totalDeudoresf As Integer = 0


        '    For Each item As CuentasCobrar In lista.ToList()
        '        totalf += item.Saldo
        '        totalDeudoresf = lista.Count
        '    Next
        '    lbltotalfechas.Text = String.Format("{0:n}", totalf)
        '    lbldeudasfecha.Text = totalDeudoresf

        '    'dsfecha = Nothing

        'Catch ex As ReglasNegocioException
        '    MsgBox(ex.Message)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Private Sub dtpinicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpinicio.ValueChanged
        ''verDeudasFecha()
        verDeudas()
    End Sub
    Private Sub dtpfin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpfin.ValueChanged
        ' verDeudasFecha()
        verDeudas()
    End Sub
    Private Sub tabctrlDeudas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If tabctrlDeudas.SelectedIndex = 0 Then
        '    lbltitulofechadeudas.Visible = False
        '    lbldeudasfecha.Visible = False
        '    lbltitulototalfechas.Visible = False
        '    lbltotalfechas.Visible = False

        '    lblTituloDeudores.Visible = True
        '    lblDeudas.Visible = True
        '    lblTitulototal.Visible = True
        '    lblTotal.Visible = True

        '    verDeudas() 'Todas

        'ElseIf tabctrlDeudas.SelectedIndex = 1 Then
        '    txtCliente.Focus()
        '    lbltitulofechadeudas.Visible = False
        '    lbldeudasfecha.Visible = False
        '    lbltitulototalfechas.Visible = False
        '    lbltotalfechas.Visible = False

        '    lblTituloDeudores.Visible = True
        '    lblDeudas.Visible = True
        '    lblTitulototal.Visible = True
        '    lblTotal.Visible = True


        '    busqueda = New Service_Credito
        '    busqueda.iniciarBusqueda()
        '    FormatoDGBusqueda() 'BUSQUEDA POR CLIENTE

        'ElseIf tabctrlDeudas.SelectedIndex = 2 Then
        '    dtpinicio.Focus()
        '    lbltitulofechadeudas.Visible = True
        '    lbldeudasfecha.Visible = True
        '    lbltitulototalfechas.Visible = True
        '    lbltotalfechas.Visible = True

        '    lblTituloDeudores.Visible = False
        '    lblDeudas.Visible = False
        '    lblTitulototal.Visible = False
        '    lblTotal.Visible = False

        '    verDeudasFecha() 'Entre fechas

        '
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmDeudas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '' If tabctrlDeudas.SelectedIndex = 0 Then
        If Not dgvDeudas.DataSource Is Nothing Then


            Dim rep As New Report

            Dim total As Double = CType(dgvDeudas.DataSource, List(Of CuentasCobrar)).Sum(Function(p) p.Saldo)

            rep.DataSource = dgvDeudas.DataSource

            Dim dic As New Dictionary(Of String, Object)
            dic.Add("Param.Total", String.Format("{0:C}", total))
            dic.Add("Param.Deudas", dgvDeudas.Rows.Count)

            rep.Load("Reportes\deudas.mrp")

            Dim file As String = My.Computer.FileSystem.GetTempFileName

            rep.ExportToPdf(file & ".pdf", dic)
            System.Diagnostics.Process.Start(file & ".pdf")

            rep = Nothing
        End If
        ' ''ElseIf tabctrlDeudas.SelectedIndex = 1 Then
        ' ''If Not dgvCliente.DataSource Is Nothing Then


        'Dim rep As New Report

        'Dim total As Double = CType(dgvCliente.DataSource, List(Of CuentasCobrar)).Sum(Function(p) p.Saldo)

        'rep.DataSource = dgvCliente.DataSource

        'Dim dic As New Dictionary(Of String, Object)
        'dic.Add("Param.Total", total)
        'dic.Add("Param.Deudas", dgvCliente.Rows.Count)

        'rep.Load("deudas.mrp")

        'Dim file As String = My.Computer.FileSystem.GetTempFileName

        'rep.ExportToPdf(file & ".pdf", dic)
        'System.Diagnostics.Process.Start(file & ".pdf")

        'rep = Nothing
        'End If
        'ElseIf tabctrlDeudas.SelectedIndex = 2 Then
        'If Not dgvFecha.DataSource Is Nothing Then


        '    Dim rep As New Report

        '    Dim total As Double = CType(dgvFecha.DataSource, List(Of CuentasCobrar)).Sum(Function(p) p.Saldo)

        '    rep.DataSource = dgvFecha.DataSource

        '    Dim dic As New Dictionary(Of String, Object)
        '    dic.Add("Param.Total", total)
        '    dic.Add("Param.Deudas", dgvFecha.Rows.Count)

        '    rep.Load("deudas.mrp")

        '    Dim file As String = My.Computer.FileSystem.GetTempFileName

        '    rep.ExportToPdf(file & ".pdf", dic)
        '    System.Diagnostics.Process.Start(file & ".pdf")

        '    rep = Nothing
        'End If
        'End If
  
    End Sub
End Class