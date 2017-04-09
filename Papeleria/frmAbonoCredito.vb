Imports LogicaNegocio
Public Class frmAbonoCredito
    Private cliente As Cliente
    Private sc As Service_Cliente
    Private abono As Decimal
    Private saldoActual As Decimal
    Private usar As Decimal
    Private efectivo As Decimal

    Dim validacion As CValidation
    Dim keyascii As Short
    Private objFP As FinalizarPago

    Private Sub frmAbonoCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                btnBuscacliente.PerformClick()
            Case Keys.F5
                'btnGuardar.PerformClick()
            Case Keys.F7
                'btnNuevo.PerformClick()
        End Select



    End Sub

    Private Sub frmAbonoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nuevo()
        Me.KeyPreview = True
    End Sub

    Private Sub nuevo()

        txtCliente.Text = ""
        txtLimite.Text = String.Format("{0:c}", 0)
        txtSaldo.Text = String.Format("{0:c}", 0)
        'txtEfectivo.Text = String.Format("{0:c}", 0)
        'txtUsar.Text = String.Format("{0:c}", 0)

        'txtCambio.Text = String.Format("{0:c}", 0)
        'txtSaldoActual.Text = String.Format("{0:c}", 0)
        txtFolioC.Text = ""
        sc = Nothing
        txtFolioC.Select()
        txtFolioC.Focus()
        dgv.DataSource = Nothing
        cliente = Nothing

        'txtEfectivo.Enabled = False
        'txtUsar.Enabled = False
        'txtCambio.Enabled = False
        'btnGuardar.Enabled = False

        dgvvtas.DataSource = Nothing
    End Sub

    Private Sub txtFolioC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioC.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                If txtFolioC.Text.Length <> 0 Then
                    sc = New Service_Cliente
                    cliente = sc.Obtener(CInt(txtFolioC.Text.Trim))
                    If Not cliente.CreditoActivo And cliente.Saldo <= 0 Then
                        Throw New Exception("Este cliente no tiene una cuenta de credito activa.")
                    End If
                    Try
                        Dim lista As List(Of Abono) = sc.obtener_abonos(cliente.Id_credito)
                        dgv.DataSource = lista
                        formatoGrid()
                    Catch ex As Exception
                        Exit Try
                    End Try
                    txtCliente.Text = cliente.Razon
                    txtLimite.Text = String.Format("{0:c}", cliente.Limite)
                    txtSaldo.Text = String.Format("{0:c}", cliente.Saldo)

                    If cliente.Saldo = 0 Then
                        btnGuardar.Enabled = False
                    Else
                        btnGuardar.Enabled = True
                    End If

                    Dim svent As New Service_Venta
                    Dim ventas As List(Of Venta) = svent.getVentasCredito(cliente.Id_credito)

                    actualizarGridVentas(ventas)

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        validacion = New CValidation
        keyascii = CShort(Asc(e.KeyChar))
        keyascii = CShort(validacion.SoloNumeros(keyascii))
        If keyascii = 0 Then
            e.Handled = True
        End If
        validacion = Nothing

    End Sub
    Private Sub actualizarGridVentas(ByVal ventas As List(Of Venta))
        Try
            With dgvvtas
                .DataSource = ventas
                .Columns(0).HeaderText = "Folio Venta"
                .Columns(0).Width = 70
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Width = 120

                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(4).DefaultCellStyle.Format = "c"
                .Columns(4).Width = 70
                .Columns(5).Visible = False

                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(6).DefaultCellStyle.Format = "c"
                .Columns(6).Width = 70
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).DefaultCellStyle.Format = "c"
                .Columns(7).Width = 70

                .Columns(8).Visible = False
                .Columns(9).Visible = False
            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatoGrid()

        dgv.Columns(0).Visible = False
        dgv.Columns(1).Visible = False
        dgv.Columns(2).Width = 120
        dgv.Columns(3).Width = 60
        dgv.Columns(3).DefaultCellStyle.Format = "c"
        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Private Sub btnBuscacliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscacliente.Click
        Try
            Dim frm As New frmBuscarCliente
            frm.ShowDialog()
            txtFolioC.Text = frm.id_cliente
            txtFolioC.Focus()
            SendKeys.Send("{ENTER}")
            frm = Nothing
        Catch ex As Exception
            nuevo()
            MsgBox(ex.Message)
            txtFolioC.Text = ""
            txtFolioC.Focus()

        End Try
    End Sub
    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmCompra_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 55 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub dgvvtas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvvtas.CellDoubleClick
        Try
            Dim frm As New frmConsultaVentas(dgvvtas.CurrentRow.Cells(0).Value, dgvvtas.CurrentRow.Cells(3).Value, dgvvtas.CurrentRow.Cells(7).Value, "")
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If caja_abierta Then

                objFP = New FinalizarPago(txtSaldo.Text, 0, 0, 0, False)
                Dim frm As New frmFormaPago(objFP, False, True)
                frm.ShowDialog()

                Dim totalab As Decimal = objFP.aUsar
                '******************cambiar idusuario e idcaja
                If Not frm.lista_vales Is Nothing Then
                    For Each vale In frm.lista_vales
                        totalab += vale.MontoUsar
                    Next
                End If
                If Not frm.lista_tarjeta Is Nothing Then
                    For Each tarj In frm.lista_tarjeta
                        totalab += tarj.Monto
                    Next
                End If

                ' 

                If Not objFP Is Nothing Then
                    If objFP.Pagado Then
                        If totalab > 0 Then
                            sc.insertar_abono(cliente.Id_credito, Date.Now, totalab, txtSaldo.Text - totalab, id_caja, frm.lista_vales, frm.lista_tarjeta, objFP.aUsar)
                            'AGREGADO REIMPRESION DE TICKETS
                            If Sesion.imprimeTicket Then
                                If frm.lista_vales.Count > 0 Then

                                    For Each it As Vales In frm.lista_vales
                                        If it.MontoActual <> 0 Then
                                            Try
                                                Dim ticket As New BarControls.Ticket
                                                ticket.AddHeaderLine(Sesion.negocio)
                                                ticket.AddHeaderLine(Sesion.direccion)
                                                ticket.AddHeaderLine(Sesion.ciudad)
                                                If Not Sesion.telefono = "        " Then
                                                    ticket.AddHeaderLine("Teléfono: " & Sesion.telefono)
                                                End If

                                                ticket.AddSubHeaderLine("Concepto: VALE")
                                                ticket.AddSubHeaderLine(it.NombreCliente)
                                                ticket.AddHeaderLine("Folio Vale# " & it.Folio)
                                                ticket.AddHeaderLine("Le atendió: " & Sesion.nombre_usuario)
                                                ticket.AddHeaderLine("Exped: " & it.Fecha)
                                                ticket.AddHeaderLine("Reimp: " & Date.Now)

                                                ticket.AddTotal("Monto Inicial", FormatCurrency(it.MontoInicial))
                                                ticket.AddTotal("Monto Actual", FormatCurrency(it.MontoActual))

                                                ticket.AddFooterLine("")
                                                ticket.AddFooterLine("***** " & Sesion.saludo & " *****")

                                                ticket.PrintTicket(Sesion.impresora)
                                            Catch ex As Exception
                                                MsgBox(ex.Message)
                                            End Try
                                        End If
                                    Next
                                End If
                            End If 'aqui reimpresion tickets
                            MsgBox("Abono Guardado Correctamente")
                            nuevo()
                        End If

                    End If

                End If


            Else
                MsgBox("Debes inicializar la caja para realizar el abono.")
                frmCaja.ShowDialog()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
End Class