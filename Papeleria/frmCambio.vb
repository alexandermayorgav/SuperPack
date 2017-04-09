Imports LogicaNegocio
Public Class frmCambio
    Private objFP As FinalizarPago
    Public lista_vales As List(Of Vales)
    Public lista_tarjeta As List(Of Tarjeta)
    Public vale As Vales
    Public efectivo As Decimal
    Private apartado As Boolean
    Private credito As Boolean
    Public totalConformado As Decimal
    Private efectivo_variable As Decimal
    Private ausar As Decimal

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByRef objFPref As FinalizarPago, Optional ByVal apartado As Boolean = False, Optional ByVal credito As Boolean = False)
        Me.objFP = objFPref
        Me.apartado = apartado
        Me.credito = credito
        efectivo = 0.0
        lista_tarjeta = New List(Of Tarjeta)
        lista_vales = New List(Of Vales)
        InitializeComponent()
    End Sub
    Private Sub frmCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                btnfinalizar.PerformClick()
        End Select
    End Sub
    Private Sub frmCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtSubtotal.Text = FormatCurrency(objFP.Total)
        If apartado Then
            txtUsar.Visible = True
            lblUsar.Visible = True
            txtUsar.Text = FormatCurrency(objFP.aUsar)
        End If
        If credito Then
            txtUsar.Visible = True
            lblUsar.Visible = True
            txtUsar.Text = FormatCurrency(objFP.aUsar)
        End If
        txtCambio.Text = FormatCurrency(objFP.Cambio)
        txtEfectivo.Text = FormatCurrency(objFP.Efectivo)
        txtrestopago.Text = FormatCurrency(objFP.Total)
        txtEfectivo.Focus()
        txtEfectivo.Select()
    End Sub
    Private Sub txtEfectivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEfectivo.Click
        txtEfectivo.Select()
    End Sub
    Private Sub txtEfectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEfectivo.KeyPress
        Try
            If txtEfectivo.Text <> "" Then
                efectivo_variable = CDec(txtEfectivo.Text)
            End If
        Catch ex As Exception
            txtEfectivo.Text = String.Format("{0:c}", 0)
            Exit Try
        End Try

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If txtEfectivo.Text = "" Then
                MsgBox("Debes introducir efectivo")
                txtEfectivo.Text = String.Format("{0:c}", 0)
            ElseIf CDec(txtEfectivo.Text) = 0 Then
                MsgBox("Debes introducir efectivo")
                txtEfectivo.Text = String.Format("{0:c}", 0)
            Else
                txtEfectivo.Text = String.Format("{0:c}", efectivo_variable)
                txtUsar.Text = FormatCurrency(objFP.Total)
                txtUsar.Focus()
            End If
        End If

        If e.KeyChar = Convert.ToChar(13) Then
            '' Me.Button1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(8) Then ' se pulsó Retroceso
            e.Handled = False
        ElseIf (e.KeyChar < "0"c Or e.KeyChar > "9"c) Then
            ' desechar los caracteres que no son dígitos
            e.Handled = True
        End If
    End Sub
    Private Sub txtUsar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsar.Click
        txtUsar.Select()
    End Sub
    Private Sub txtCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCambio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If CDec(txtrestopago.Text) = 0 Then
                btnfinalizar.PerformClick()
            Else
                txtUsar.Text = "$0.00"
                objFP.Efectivo = 0
                objFP.aUsar = 0
                txtCambio.Text = String.Format("{0:c}", 0)
                txtUsar.Focus()
                txtpagorealizado.Text = FormatCurrency(GetConformacionPago())
                MsgBox("Se debe completar el pago de la venta.")
            End If
        End If
    End Sub
    Private Sub txtUsar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsar.KeyPress
        Try
            If txtUsar.Text <> "" Then
                ausar = txtUsar.Text
                txtUsar.Text = ausar
            End If
        Catch ex As Exception
            txtUsar.Text = String.Format("{0:c}", 0)
            Exit Try
        End Try

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Try
                ' If apartado And Not txtEfectivo.Text = "" Then
                If txtEfectivo.Text.Trim.Length <> 0 And Not txtEfectivo.Text.Trim = "" And txtUsar.Text.Trim.Length <> 0 And Not txtUsar.Text.Trim = "" Then
                    If CDec(txtUsar.Text.Trim) > objFP.Total Then
                        txtUsar.Text = "$0.00"
                        objFP.Efectivo = 0
                        objFP.aUsar = 0
                        txtCambio.Text = String.Format("{0:c}", 0)
                        txtpagorealizado.Text = FormatCurrency(GetConformacionPago())
                        txtUsar.Focus()
                        MsgBox("El monto a usar no debe ser mayor al Total.")
                    ElseIf CDec(txtUsar.Text.Trim) > CDec(txtEfectivo.Text.Trim) Then
                        txtUsar.Text = "$0.00"
                        objFP.Efectivo = 0
                        objFP.aUsar = 0
                        txtCambio.Text = String.Format("{0:c}", 0)
                        txtpagorealizado.Text = FormatCurrency(GetConformacionPago())
                        txtUsar.Focus()
                        MsgBox("El monto a usar no debe ser mayor al Efectivo.")
                    Else
                        txtpagorealizado.Text = String.Format("{0:c}", 0)
                        objFP.Efectivo = CDec(txtEfectivo.Text)
                        objFP.aUsar = ausar
                        objFP.Cambio = objFP.Efectivo - objFP.aUsar
                        If objFP.Cambio < 0 Then
                            txtCambio.Text = String.Format("{0:c}", 0)
                        Else
                            txtCambio.Text = String.Format("{0:c}", objFP.Cambio)
                            txtpagorealizado.Text = FormatCurrency(GetConformacionPago())
                            txtUsar.Text = String.Format("{0:c}", ausar)
                            txtCambio.Focus()
                        End If
                    End If
                Else
                    objFP.Efectivo = 0
                    objFP.aUsar = 0
                    txtCambio.Text = String.Format("{0:c}", 0)
                    txtpagorealizado.Text = FormatCurrency(GetConformacionPago())
                End If
                'End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmCambio_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 20 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub btnagregartarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregartarjeta.Click
        Try
            If VerificaListaTarjeta(txtnumoperacion.Text) Then
                MsgBox("El número de operación ya se encuentra en la lista.")
                txtnumoperacion.Focus()
                txtnumoperacion.SelectAll()
                Exit Sub
            End If
            If txtnumoperacion.Text = "" Then
                MsgBox("Número de operación (ticket/boucher) requerido.")
                txtnumoperacion.Focus()
            ElseIf txtmontotarjeta.Text.Trim = "" Then
                MsgBox("Monto de la operación requerido.")
                txtmontotarjeta.Focus()
            ElseIf Not CDec(txtmontotarjeta.Text) > 0 Then
                MsgBox("Monto inválido.")
                txtmontotarjeta.Focus()
                txtmontotarjeta.SelectAll()
            ElseIf CDec(txtmontotarjeta.Text) > objFP.Total Then
                MsgBox("El monto a usar de pago con tarjeta no puede ser mayor al TOTAL.")
                txtmontotarjeta.Text = ""
                txtmontotarjeta.Focus()
            Else
                If objFP.aUsar > 0 Then
                    Dim resta As Decimal = CDec(objFP.aUsar) - CDec(txtmontotarjeta.Text)
                    If resta < 0 Then
                        MsgBox("La cantidad total esta cubierta.")
                        txtmontotarjeta.Text = ""
                        txtnumoperacion.Text = ""
                        txtnumoperacion.Focus()
                        Exit Sub
                    End If
                    txtUsar.Text = String.Format("{0:c}", resta)
                    objFP.aUsar = FormatCurrency(txtUsar.Text)
                    txtpagorealizado.Text = FormatCurrency(GetConformacionPago())
                    txtUsar.Focus()
                    SendKeys.Send("{ENTER}")
                End If

                If (CDec(txtmontotarjeta.Text) + CDec(txtpagorealizado.Text) > objFP.Total) Then
                    MsgBox("La cantidad sobrepasa el total o ya esta cubierta")
                    txtmontotarjeta.Text = ""
                    txtmontotarjeta.Focus()
                Else
                    Dim itemTarjeta As New Tarjeta(txtnumoperacion.Text, CDec(txtmontotarjeta.Text))
                    lista_tarjeta.Add(itemTarjeta)
                    ActualizarDGVTrajeta()
                    txtnumoperacion.Text = ""
                    txtmontotarjeta.Text = ""
                    txtnumoperacion.Focus()
                End If
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActualizarDGVTrajeta()
        Try
            Dim rowDestino As Short = 0
            dgvtarjeta.Rows.Clear()
            For Each itemTarjeta In lista_tarjeta
                With dgvtarjeta
                    .Rows.Add()
                    rowDestino = .RowCount - 1
                    .Rows(rowDestino).Cells("numoperacion").Value = itemTarjeta.NumeroOperacion
                    .Rows(rowDestino).Cells("monto").Value = itemTarjeta.Monto
                End With
            Next

            With dgvtarjeta
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(1).DefaultCellStyle.Format = "c"
            End With
            txtpagorealizado.Text = FormatCurrency(GetConformacionPago())
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function VerificaListaTarjeta(ByVal num_op As String) As Boolean
        For Each item In lista_tarjeta
            If item.NumeroOperacion = num_op Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub btnobtenervale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnobtenervale.Click
        If txtfoliovale.Text = "" Then
            MsgBox("Folio requerido")
            txtfoliovale.Focus()
        Else
            Try
                Dim SVale As New Service_Vale
                vale = SVale.ObtenerVale(CInt(txtfoliovale.Text))
                txtmontovale.Text = FormatCurrency(vale.MontoActual)
                txtmontousarvale.Focus()
            Catch ex As ReglasNegocioException
                MsgBox(ex.Message)
            Catch Ex As Exception
                MsgBox(Ex.Message)
            End Try
        End If
    End Sub
    Private Sub txtfoliovale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfoliovale.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnobtenervale.PerformClick()
            txtmontousarvale.Focus()
        End If
    End Sub
    Private Sub btnagregarmontovale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregarmontovale.Click
        Try
            If txtfoliovale.Text = "" Then
                MsgBox("Debe elegir un vale.")
                txtmontovale.Text = ""
                txtmontousarvale.Text = ""
                txtfoliovale.Focus()
                txtfoliovale.SelectAll()
                Exit Sub
            ElseIf txtmontovale.Text = "" Then
                MsgBox("Debe obtener el resto del vale.")
                txtmontovale.Text = ""
                txtmontousarvale.Text = ""
                btnobtenervale.Focus()
                Exit Sub
            ElseIf VerificaListaVales(txtfoliovale.Text) Then
                MsgBox("El vale con este folio ya se encuentra en la lista.")
                txtmontovale.Text = ""
                txtmontousarvale.Text = ""
                txtfoliovale.Focus()
                txtfoliovale.SelectAll()
                Exit Sub
            End If
            If txtmontousarvale.Text = "" Then
                MsgBox("Monto a usar requerido.")
                txtmontousarvale.Focus()
            ElseIf Not CDec(txtmontousarvale.Text) > 0 Then
                MsgBox("Monto a usar debe ser mayor a cero")
                txtmontousarvale.Focus()
                txtmontousarvale.SelectAll()
            ElseIf CDec(txtmontousarvale.Text) > CDec(txtmontovale.Text) Then
                MsgBox("Monto a usar no debe ser mayor a la cantidad actual del vale.")
                txtmontousarvale.Focus()
                txtmontousarvale.SelectAll()
            ElseIf CDec(txtmontousarvale.Text) > objFP.Total Then
                MsgBox("Monto a usar en vale no debe ser mayor a la cantidad Total.")
                txtmontousarvale.Focus()
                txtmontousarvale.SelectAll()
            Else
                If objFP.aUsar > 0 Then
                    Dim resta As Decimal = CDec(txtUsar.Text) - CDec(txtmontousarvale.Text)
                    If resta < 0 Then
                        MsgBox("La cantidad total esta cubierta.")
                        txtmontousarvale.Text = ""
                        txtmontovale.Text = ""
                        txtfoliovale.Text = ""
                        txtfoliovale.Focus()
                        Exit Sub
                    End If
                    txtUsar.Text = String.Format("{0:c}", resta)
                End If

                If (CDec(txtmontousarvale.Text) + CDec(txtpagorealizado.Text) > objFP.Total) Then
                    MsgBox("La cantidad sobrepasa el total o ya esta cubierta")
                    txtmontousarvale.Text = ""
                    txtmontousarvale.Focus()
                Else
                    Dim montoNuevo As Decimal = CDec(vale.MontoActual - CDec(txtmontousarvale.Text))
                    Dim itemvale As New Vales(vale.Folio, CDec(txtmontousarvale.Text), montoNuevo, vale.MontoInicial, vale.Cliente)
                    itemvale.NombreCliente = vale.NombreCliente
                    lista_vales.Add(itemvale)
                    ActualizarDgvVales()
                    txtfoliovale.Text = ""
                    txtmontovale.Text = ""
                    txtmontousarvale.Text = ""
                    txtfoliovale.Focus()
                End If
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActualizarDgvVales()
        Try
            Dim rowDestino As Short = 0
            dgvVales.Rows.Clear()
            For Each itemvale In lista_vales
                If objFP.aUsar > 0 Then
                    txtUsar.Text = CDec(txtUsar.Text) + itemvale.MontoUsar
                End If
                With dgvVales
                    .Rows.Add()
                    rowDestino = .RowCount - 1
                    .Rows(rowDestino).Cells("folio").Value = itemvale.Folio
                    .Rows(rowDestino).Cells("montousar").Value = itemvale.MontoUsar
                    .Rows(rowDestino).Cells("montorestante").Value = itemvale.MontoRestante
                End With
            Next
            With dgvVales
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(1).DefaultCellStyle.Format = "c"
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(2).DefaultCellStyle.Format = "c"
            End With
            txtpagorealizado.Text = FormatCurrency(GetConformacionPago())
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function VerificaListaVales(ByVal idvale As Integer) As Boolean
        For Each item In lista_vales
            If item.Folio = idvale Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function GetConformacionPago() As Decimal
        Dim TotalConf As Decimal = 0.0

        For Each itemT In lista_tarjeta
            TotalConf += itemT.Monto
        Next

        For Each itemV In lista_vales
            TotalConf += itemV.MontoUsar
        Next

        If objFP.aUsar > 0 Then
            TotalConf += objFP.aUsar
        End If

        If TotalConf > objFP.Total Then
            txtrestopago.Text = FormatCurrency(TotalConf - objFP.Total)
        Else
            txtrestopago.Text = FormatCurrency(objFP.Total - TotalConf)
        End If

        Return TotalConf
    End Function
    Private Sub txtmontotarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmontotarjeta.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnagregartarjeta.PerformClick()
        End If
    End Sub
    Public Function removerVale(ByVal idVale As Integer) As Boolean
        For Each itemV As Vales In lista_vales
            If itemV.Folio = idVale Then
                lista_vales.Remove(itemV)
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub dgvVales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVales.KeyDown
        If e.KeyCode = 46 Then
            Dim idVale As Integer = dgvVales.CurrentRow.Cells(0).Value
            Try
                If Not removerVale(idVale) Then
                    Throw New ReglasNegocioException("Seleccione un vale")
                Else
                    ActualizarDgvVales()
                End If
            Catch Ex As ReglasNegocioException
                MsgBox(Ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Public Function removerTarjeta(ByVal operacion As String) As Boolean
        For Each itemT As Tarjeta In lista_tarjeta
            If itemT.NumeroOperacion = operacion Then
                lista_tarjeta.Remove(itemT)
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub dgvtarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvtarjeta.KeyDown
        If e.KeyCode = 46 Then
            Dim operacion As String = dgvtarjeta.CurrentRow.Cells(0).Value
            Try

                If Not removerTarjeta(operacion) Then
                    Throw New ReglasNegocioException("Seleccione una operacion de tarjeta")
                Else
                    ActualizarDGVTrajeta()
                End If
            Catch Ex As ReglasNegocioException
                MsgBox(Ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnfinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfinalizar.Click
        Try
            If apartado Then
                If CDec(txtpagorealizado.Text) <= 0 Then
                    MsgBox("No se ha realizado ningún tipo de pago.")
                    txtEfectivo.Focus()
                    txtEfectivo.SelectAll()
                    Exit Sub
                Else
                    
                    objFP.Pagado = True
                    totalConformado = GetConformacionPago()
                    efectivo = CDec(txtpagorealizado.Text)
                    Me.Close()

                End If
            ElseIf credito Then
                If objFP.aUsar >= objFP.Total Then
                    MsgBox("Cantidad a abonar mayor que el total")
                    txtUsar.Focus()
                    txtUsar.SelectAll()
                    Exit Sub
                ElseIf objFP.aUsar > objFP.Efectivo Then
                    MsgBox("Cantidad a usar mayor que el efectivo")
                    txtUsar.Focus()
                    txtUsar.SelectAll()
                    Exit Sub
                Else
                    
                    objFP.Pagado = True
                    totalConformado = GetConformacionPago()
                    efectivo = CDec(txtpagorealizado.Text)
                    Me.Close()

                End If

            Else
                If CDec(txtrestopago.Text) > 0 Then
                    Throw New Exception("No se ha solventado el total de la venta.")
                ElseIf CDec(txtpagorealizado.Text) > 0 Then
                    
                    objFP.Pagado = True
                    totalConformado = GetConformacionPago()
                    efectivo = CDec(txtpagorealizado.Text)
                    Me.Close()

                Else
                    txtEfectivo.Focus()
                    Throw New Exception("No se ha realizado ningún tipo de pago.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class