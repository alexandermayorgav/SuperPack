Imports LogicaNegocio
Public Class frmVales
    Private vale As Vales = Nothing
    Private cliente As Cliente = Nothing
    Private datosTicket As DatosTicket = Nothing
    Private dineroDevolver As Decimal
    Private esDevVenta As Boolean
    Private IDCliente As Integer
    Private entroBuscarCliente As Boolean = False
    Private esReimprimirVale As Boolean = False
    Dim folio As Integer
    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByRef devolver As Decimal, ByVal IdC As Integer, Optional ByVal esDevVenta As Boolean = False)
        Me.dineroDevolver = devolver
        Me.IDCliente = IdC
        Me.esDevVenta = esDevVenta
        InitializeComponent()
    End Sub
    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        BuscarCliente()
    End Sub
    Private Sub BuscarCliente()
        entroBuscarCliente = True
        If esDevVenta = False Then
            Dim form As New frmBuscarCliente
            form.ShowDialog()
            If form.id_cliente > 0 Then
                folio = form.id_cliente
            End If
        Else
            folio = IDCliente
        End If
        Try
            If folio > 0 Then
                Dim Scliente As New Service_Cliente
                cliente = Scliente.Obtener(folio)
                txtCliente.Text = cliente.Razon
            End If
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
    Private Sub frmVales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                btnCliente.PerformClick()
            Case Keys.F3
                btnVer.PerformClick()
            Case Keys.F5
                btnReimprimir.PerformClick()
            Case Keys.F6
                btnDel.PerformClick()
            Case Keys.F7
                btnNew.PerformClick()
            Case Keys.F9
                btnAdd.PerformClick()
        End Select
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
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Agregar()
    End Sub
    Private Sub Agregar()
        Try

            Dim Svale As New Service_Vale
            Dim cli As Integer
            Dim nombre As String = ""

            If txtCliente.Text = "" Then
                txtCliente.Focus()
                Throw New Exception("Debes escribir o seleccionar un cliente.")
            Else
                If entroBuscarCliente = True Then
                    If Not cliente.Razon <> txtCliente.Text Then
                        cli = cliente.Id
                        nombre = cliente.Razon
                    Else
                        cli = 0
                        nombre = txtCliente.Text
                    End If
                Else
                    cli = 0
                    nombre = txtCliente.Text
                End If
            End If

            If txtMonto.Text = "" Then
                txtMonto.Focus()
                Throw New Exception("Monto Requerido")
            ElseIf Not IsNumeric(txtMonto.Text) Then
                txtMonto.Focus()
                txtMonto.Text = ""
                Throw New Exception("Debes escribir una cantidad entera o con decimales en monto.")
            Else
                If CDec(txtMonto.Text) = 0 Then
                    txtMonto.Focus()
                    txtMonto.SelectAll()
                    Throw New Exception("Monto Incorrecto")
                End If
            End If

            vale = New Vales(-1, txtMonto.Text, Date.Now, nombre, cli, "0", txtMonto.Text, Sesion.id_usuario_sesion)
            Svale.AgregarVale(vale)
            MsgBox("Vale agregado correctamente.")

            Dim tot As Decimal = vale.MontoActual

            Dim st As String = String.Format("{0:n}", tot)

            Dim total() As String

            total = Split(st, ".")
            esReimprimirVale = False
            If Sesion.imprimeTicket Then
                doTicket(vale.Folio, vale.Fecha, esReimprimirVale, vale)
            End If

            If esDevVenta = True Then
                Me.Close()
            End If

            Limpiar()
            VerVales()
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub doTicket(ByVal folio_vale As Integer, ByVal fecha As Date, ByVal ReimprimirVale As Boolean, Optional ByVal val As Vales = Nothing)
        Try
            Dim ticket As New BarControls.Ticket

            ticket.AddHeaderLine(Sesion.negocio)
            ticket.AddHeaderLine(Sesion.direccion)
            ticket.AddHeaderLine(Sesion.ciudad)
            If Not Sesion.telefono = "        " Then
                ticket.AddHeaderLine("Teléfono: " & Sesion.telefono)
            End If


            ticket.AddSubHeaderLine("Concepto: VALE")
            ticket.AddSubHeaderLine(val.NombreCliente)
            ticket.AddHeaderLine("Folio Vale# " & folio_vale)
            ticket.AddHeaderLine("Le atendió: " & Sesion.nombre_usuario)
            ticket.AddHeaderLine("Exped: " & fecha)
            If esReimprimirVale Then
                ticket.AddHeaderLine("Reimp: " & Date.Now)
            End If

            ticket.AddTotal("Monto Inicial", FormatCurrency(val.MontoInicial))
            If val.MontoActual < val.MontoInicial Then
                ticket.AddTotal("Monto Actual", FormatCurrency(val.MontoActual))
            End If

            ticket.AddFooterLine("")
            ticket.AddFooterLine("***** " & Sesion.saludo & " *****")
            ticket.PrintTicket(Sesion.impresora)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Limpiar()
        entroBuscarCliente = False
        txtCliente.Text = ""
        txtMonto.Text = ""
        cliente = Nothing
        vale = Nothing
        dgvv.DataSource = Nothing
        txtCliente.Focus()
    End Sub
    Private Sub VerVales()
        Try
            Dim verpor As String = ""
            Dim fecha1 As String = Utils.ObtenerFecha(dt1.Value)
            Dim fecha2 As String = Utils.ObtenerFecha(DateAdd(DateInterval.Day, 1, dt2.Value))
            If rbTodos.Checked Then
                verpor = "Todos"
            Else
                verpor = "Fecha"
            End If
            Dim Svale As New Service_Vale
            dgvv.DataSource = Svale.ObtenerVales(fecha1, fecha2, verpor)
            dgvv.Columns(0).Visible = False
            dgvv.Columns(1).Visible = False
            dgvv.Columns(2).Visible = False
            dgvv.Columns(3).Visible = True
            dgvv.Columns(8).Visible = False
            dgvv.Columns(9).Visible = False
            dgvv.Columns(3).Width = 70
            dgvv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvv.Columns(4).Width = 80
            dgvv.Columns(4).DefaultCellStyle.Format = "c"
            dgvv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvv.Columns(5).Width = 80
            dgvv.Columns(5).DefaultCellStyle.Format = "c"
            dgvv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvv.Columns(6).Width = 89
            dgvv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvv.Columns(7).Width = 323
            dgvv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        VerVales()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Limpiar()
    End Sub
    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        If dgvv.SelectedCells.Count > 0 Then
            dgvv.Select()
            BorrarVale()
            VerVales()
        End If
    End Sub
    Private Sub BorrarVale()
        Try
            Dim id As Integer
            id = dgvv.CurrentRow.Cells("Folio").Value

            If MsgBox("Esta seguro de borrar el vale: " & id, MsgBoxStyle.YesNo, "Borrar Vale") = MsgBoxResult.Yes Then
                Dim Svale As New Service_Vale
                Svale.BorrarVale(id)
                MsgBox("Vale número " & id & " borrado")
            End If

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnReimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReimprimir.Click
        Try
            Dim idV As String = InputBox("¿FOLIO DEL VALE?", "IMPRESIÓN DE VALE")
            If idV <> vbNullString Then
                Try
                    Dim Svale As New Service_Vale
                    vale = New Vales
                    vale = Svale.ObtenerVale(CInt(idV))
                    Dim montoAct As Decimal = vale.MontoActual
                    Dim stMontoAct As String = String.Format("{0:n}", montoAct)
                    Dim total() As String
                    total = Split(stMontoAct, ".")
                    esReimprimirVale = True
                    doTicket(idV, vale.Fecha, esReimprimirVale, vale)
                Catch ex As ReglasNegocioException
                    MsgBox(ex.Message)
                Catch Ex As Exception
                    MsgBox(Ex.Message)
                End Try
            Else

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmVales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        If esDevVenta = True Then
            If IDCliente <> 1 Then
                txtCliente.Enabled = False
                btnCliente.Enabled = False
            End If
            BuscarCliente()
            txtMonto.Text = dineroDevolver
        End If
    End Sub
    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnAdd.PerformClick()
        End If
        SoloNumeros(sender, e)
    End Sub
    Private Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            '' Me.Button1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(8) Then ' se pulsó Retroceso
            e.Handled = False
        ElseIf (e.KeyChar = ","c) Then ' no permite la coma
            e.Handled = True ' Handled = True, no permite; = False, si permite...
        ElseIf (e.KeyChar = "."c) Then
            Dim ctrl As TextBox = DirectCast(sender, TextBox)
            If (ctrl.Text.IndexOf("."c) <> -1) Then ' sólo puede haber una coma
                e.Handled = True
            End If
        ElseIf (e.KeyChar < "0"c Or e.KeyChar > "9"c) Then
            ' desechar los caracteres que no son dígitos
            e.Handled = True
        End If
    End Sub
End Class