Imports LogicaNegocio
Public Class frmAdminApartado
    Private objAp As Apartado
    Private sAp As Service_Apartado
    Private sC As Service_Cliente
    Private sUs As Service_Usuario
    Private sP As Service_Producto
    Private sAb As Service_AbonoAp
    Private objC As Cliente
    Private objAte As Usuario
    Private objP As Producto
    Private diasAp As Integer = Sesion.dias_apartado
    Private totalAbs As Decimal
    Private Sub btnObtenerAp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerAp.Click
        Try
            obtenerApartado()
        Catch cast As InvalidCastException
            MsgBox("Caracteres incorrectos. Debes proporcionar un folio de cliente (Númerico)")
            txtFolioAp.Focus()
            txtFolioAp.SelectAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub obtenerApartado()
        Try
            If txtFolioAp.Text = "" Then
                MsgBox("Debes proporcionar el folio del apartado")
                txtFolioAp.Select()
                txtFolioAp.Focus()
            Else
                objAp = sAp.obtener(txtFolioAp.Text)
                If Not objAp Is Nothing Then
                    sC = New Service_Cliente
                    objC = sC.Obtener(objAp.IdCliente)

                    sUs = New Service_Usuario
                    objAte = sUs.Obtener(objAp.IdUsuario)

                    sP = New Service_Producto
                    objP = sP.Obtener(objAp.CodigoBarras)

                    txtCliente.Text = objC.Razon
                    txtUsuario.Text = objAte.Nombre
                    txtProducto.Text = objP.Descripcion
                    txtCant.Text = objAp.Cantidad
                    txtMonto.Text = FormatCurrency(objAp.Monto)
                    txtFechaAp.Text = objAp.FechaApartado

                    calcularSaldo()

                    If objAp.Entregado Then
                        status.Text = "Entregado"
                        status.Image = My.Resources.va
                        lblFechaE.Visible = True
                        txtFechaEnt.Visible = True
                        txtFechaEnt.Text = objAp.FechaEntrega
                        pbxSemaforo.Image = My.Resources.semverde
                        btnEntregarAp.Enabled = False
                        btnCancelar.Enabled = False
                        lblDias.Text = "N/A"
                    End If
                    If objAp.Devuelto Then
                        status.Text = "Cancelado"
                        status.Image = My.Resources.cancelar
                        lblFechaE.Visible = False
                        txtFechaEnt.Visible = False
                        pbxSemaforo.Image = My.Resources.semrojo
                        btnCancelar.Enabled = False
                        btnEntregarAp.Enabled = False
                        lblDias.Text = "N/A"
                    End If
                    If Not objAp.Entregado And Not objAp.Devuelto Then
                        status.Text = "Pendiente"
                        status.Image = My.Resources.load
                        lblFechaE.Visible = False
                        txtFechaEnt.Visible = False
                        calculaDias()
                        btnEntregarAp.Enabled = True
                        btnCancelar.Enabled = True
                    End If
                    txtFolioAp.SelectAll()
                End If
                
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
            txtFolioAp.Focus()
            txtFolioAp.SelectAll()
        Catch ex As Exception
            MsgBox(ex.Message)
            txtFolioAp.Focus()
            txtFolioAp.SelectAll()
        End Try
    End Sub
    Private Sub calcularSaldo()
        Try
            totalAbs = 0
            sAb = New Service_AbonoAp
            Dim listaAbs As List(Of AbonoApartado) = sAb.obtenerTodos(objAp.IdApartado)

            For Each abono As AbonoApartado In listaAbs
                totalAbs += abono.Cantidad_Abono
            Next
            lblSaldo.Text = FormatCurrency(objAp.Monto - totalAbs)
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub calculaDias()
        Try

            Dim diasRest As Integer = diasAp - DateDiff(DateInterval.Day, objAp.FechaApartado, Date.Now)
            Dim rango As Integer = diasAp / 3

            If diasRest <= rango Then
                'rojo
                pbxSemaforo.Image = My.Resources.semrojo
                lblDias.Text = diasRest
            ElseIf diasRest <= rango * 2 Then
                'amarillos
                pbxSemaforo.Image = My.Resources.semama
                lblDias.Text = diasRest
            ElseIf diasRest <= rango * 3 Then
                'verde
                pbxSemaforo.Image = My.Resources.semverde
                lblDias.Text = diasRest
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmAdminApartado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        Me.KeyPreview = True
        inicializar()
    End Sub
    Private Sub limpiar()
        txtCant.Text = ""
        txtCliente.Text = ""
        txtFechaAp.Text = ""
        txtFechaEnt.Text = ""
        txtFolioAp.Text = ""
        txtMonto.Text = ""
        txtProducto.Text = ""
        txtUsuario.Text = ""
        lblDias.Text = ""
      
    End Sub
    Private Sub inicializar()
        sAp = New Service_Apartado
    End Sub
    Private Sub frmAdminApartado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            btnBuscar.PerformClick()
        End If
        If e.KeyCode = Keys.F5 Then
            btnEntregarAp.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnObtenerC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnObtenerAp.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnObtenerAp.PerformClick()
        End If
    End Sub

    Private Sub txtFolioAp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioAp.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnObtenerAp.PerformClick()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            If objAp Is Nothing Then
                MsgBox("Debes seleccionar un apartado.")
                txtFolioAp.Select()
            ElseIf Not objAp.Entregado And Not objAp.Devuelto Then
                Dim confirmacion = MsgBox("¿Estas seguro que deseas cancelar el apartado?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
                If confirmacion = vbYes Then
                    sAp.cancelar(objAp)
                    txtFolioAp.Text = objAp.IdApartado
                    btnObtenerAp.PerformClick()
                End If
            ElseIf objAp.Entregado Then
                MsgBox("No es posible cancelar el apartado. Ya fue entregado.")
            ElseIf objAp.Devuelto Then
                MsgBox("No es posible cancelar el apartado. Ya fue cancelado.")
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        frmBuscarApartado.ShowDialog()
        If frmBuscarApartado.idAp > 0 Then
            txtFolioAp.Text = frmBuscarApartado.idAp
            btnObtenerAp.PerformClick()
        End If
    End Sub

    Private Sub btnEntregarAp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntregarAp.Click
        Try
            If Not objAp Is Nothing Then
                If caja_abierta Then
repite:
                    Dim codigo As String = InputBox("Escanea el producto porfavor")

                    If codigo.ToUpper = objAp.CodigoBarras.ToUpper Then
                        Dim saldo As Decimal = objAp.Monto - totalAbs

                        Dim objFp As New FinalizarPago(saldo, 0, 0, 0, False)
                        Dim frm As New frmFormaPago(objFp, False)
                        frm.ShowDialog()

                        Dim totalab As Decimal = objFp.aUsar

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

                        'Entrega del apartado

                        If totalab = saldo Then
                            Dim abono As New AbonoApartado(objAp.IdApartado, Utils.ObtenerFechaHora(Date.Now), id_caja, id_usuario_sesion, saldo)
                            sAp.entregar(abono, id_caja, objFp.aUsar, frm.lista_tarjeta, frm.lista_vales)
                            MsgBox("Entregado con éxito")
                            txtFolioAp.Text = objAp.IdApartado
                            btnObtenerAp.PerformClick()


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

                        Else
                            If objFp.aUsar > 0 AndAlso (Not frm.lista_vales Is Nothing Or frm.lista_tarjeta Is Nothing) Then
                                MsgBox("No se ha cubierto el saldo del apartado")
                            End If

                        End If
                    Else
                        MsgBox("El producto escaneado no coincide con el apartado")
                        Dim conf = MsgBox("¿Intentar nuevamaente?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
                        If conf = vbYes Then
                            GoTo repite
                        Else
                            Exit Sub
                        End If
                    End If

                Else
                    MsgBox("Debes inicializar la caja para realizar esta transaccion")
                    frmCaja.ShowDialog()
                End If


                'Dim frmEntAp As New frmEntregarApartado(objAp, totalAbs)
                'frmEntAp.ShowDialog()
                'If frmEntAp.idap > 0 Then
                '    txtFolioAp.Text = frmEntAp.idap
                '    btnObtenerAp.PerformClick()
                'End If
            Else
                MsgBox("Debes seleccionar un apartado.")
                txtFolioAp.Select()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAdmAb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdmAb.Click
        If Not objAp Is Nothing Then
            Dim frmAb As New frmAbonosAp(objC.Razon, objAp.IdApartado, objAp.Monto - totalAbs, objAp.Devuelto)
            frmAb.ShowDialog()
            If Not objAp Is Nothing Then
                txtFolioAp.Text = objAp.IdApartado
                btnObtenerAp.PerformClick()
            End If
        Else
            MsgBox("Debes seleccionar un apartado.")
            txtFolioAp.Select()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmAdminApartado_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class