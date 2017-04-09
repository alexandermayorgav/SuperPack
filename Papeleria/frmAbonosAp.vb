Imports LogicaNegocio
Public Class frmAbonosAp
    Private nomC As String
    Private idAp As Integer
    Private listaAbs As List(Of AbonoApartado)
    Private sAb As Service_AbonoAp
    Private objFp As FinalizarPago
    Private saldo As Decimal
    Private devuelto As Boolean
    Sub New(ByVal nomCp As String, ByVal idap As Integer, ByVal saldo As Decimal, ByVal dev As Boolean)
        Me.nomC = nomCp
        Me.idAp = idap
        Me.saldo = saldo
        Me.devuelto = dev
        InitializeComponent()
    End Sub

    Private Sub frmAbonosAp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            btnAbono.PerformClick()
        End If
    End Sub
    Private Sub frmAbonosAp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        sAb = New Service_AbonoAp
        txtNombreC.Text = nomC
        llenarGrid()
    End Sub
    Private Sub llenarGrid()
        Try
            listaAbs = sAb.obtenerTodos(idAp)
            txtTotAp.Text = listaAbs.Count
            With dgvAbonos
                .DataSource = listaAbs
                .Columns(0).Width = 200
                .Columns(1).Width = 110
                .Columns(1).DefaultCellStyle.Format = "c"
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Width = 145
                .Columns(5).Visible = False
                .Columns(6).Visible = False

            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbono.Click
        Try
            If saldo > 0 Then
                If Not devuelto Then
                    If caja_abierta Then
                        objFp = New FinalizarPago(saldo, 0, 0, 0, False)
                        Dim frm As New frmFormaPago(objFp, True)
                        frm.ShowDialog()
                        Dim totalab As Decimal = objFp.aUsar
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
                        If Not objFp Is Nothing Then
                            If objFp.Pagado Then
                                
                                If totalab > 0 Then

                                    Dim abono As New AbonoApartado(idAp, Utils.ObtenerFechaHora(Date.Now), id_caja, id_usuario_sesion, totalab)
                                    sAb.insertarDesdeab(abono, frm.lista_tarjeta, frm.lista_vales, objFp.aUsar)
                                    saldo -= abono.Cantidad_Abono
                                    llenarGrid()

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

                                End If

                            End If

                        End If
                    Else
                        MsgBox("Debes inicializar la caja para realizar el abono.")
                        frmCaja.ShowDialog()
                        Exit Sub
                    End If
                Else
                    MsgBox("El apartado ha sido cancelado. No es posible registrar mas abonos.")
                End If
                
            Else
                MsgBox("El saldo del apartado es 0")
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
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

    Private Sub frmAbonosAp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 25 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class