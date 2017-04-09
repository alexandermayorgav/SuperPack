Imports LogicaNegocio
Public Class frmFormaPago
    Private objFP As FinalizarPago
    Public lista_vales As List(Of Vales)
    Public lista_tarjeta As List(Of Tarjeta)
    Public vale As Vales
    Public efectivo As Decimal
    Private apartado As Boolean
    Private credito As Boolean
    Public totalConformado As Decimal
    Public oculto = False
    Private btn As Button
    Private CerroForma As Boolean = False
    Private editando_efectivo As Boolean = False
    Private editando_ausar As Boolean = False
    Sub New()
        InitializeComponent()
        CreateControls()
    End Sub
    Sub New(ByRef objFPref As FinalizarPago, Optional ByVal apartado As Boolean = False, Optional ByVal credito As Boolean = False)
        Me.objFP = objFPref
        Me.apartado = apartado
        Me.credito = credito
        efectivo = 0.0
        lista_tarjeta = New List(Of Tarjeta)
        lista_vales = New List(Of Vales)
        InitializeComponent()
        CreateControls()
    End Sub
    Private Sub frmFormaPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                btnfinalizar.PerformClick()
            Case Keys.F7
                btnagregartarjeta.PerformClick()
            Case Keys.F9
                btnobtenervale.PerformClick()
            Case Keys.F10
                btnagregarmontovale.PerformClick()
        End Select
    End Sub
    Private Sub frmFormaPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.btnHide.PerformClick()
        txtSubtotal.Text = String.Format("{0:n}", objFP.Total)
        txtEfectivo.Text = String.Format("{0:n}", objFP.Total)
        txtEfectivo.Select()
        txtEfectivo.Focus()
    End Sub
    Private Sub txtEfectivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEfectivo.Click
        txtEfectivo.SelectAll()
    End Sub
    Private Sub Funcionefectivo()
        If txtEfectivo.Text <> 0 Then
            If txtUsar.Text = "" Then
                txtUsar.Text = "0.00"
            End If
            objFP.Efectivo = txtEfectivo.Text

            'txtEfectivo.Text = String.Format("{0:n}", objFP.Efectivo)

            If objFP.Efectivo < objFP.Total And dgvtarjeta.Rows.Count < 1 And dgvVales.Rows.Count < 1 Then
                txtUsar.Text = String.Format("{0:n}", objFP.Efectivo)
            ElseIf dgvtarjeta.Rows.Count > 0 Or dgvVales.Rows.Count > 0 Then
                If CDec(txtEfectivo.Text) >= CDec(LBRestoPago.Text) Then
                    txtUsar.Text = String.Format("{0:n}", CDec(txtUsar.Text) + CDec(LBRestoPago.Text))
                ElseIf CDec(txtEfectivo.Text) < CDec(LBRestoPago.Text) Then
                    txtUsar.Text = String.Format("{0:n}", txtEfectivo.Text)
                ElseIf CDec(LBRestoPago.Text) < objFP.Total Then
                    txtUsar.Text = String.Format("{0:n}", LBRestoPago.Text)
                End If
            Else
                txtUsar.Text = String.Format("{0:n}", objFP.Total)
            End If
            'txtUsar.Focus()
        End If
    End Sub
    Private Sub txtEfectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEfectivo.KeyPress
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
        '    Funcionefectivo()
        'End If
        SoloNumeros(sender, e)
    End Sub
    Private Sub txtEfectivo_textChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEfectivo.TextChanged
        If editando_efectivo = False Then
            editando_efectivo = True
            If txtEfectivo.Text.Trim <> "" And txtEfectivo.Text.Trim <> "." Then
                Funcionefectivo()
                FuncionAUsar()
            End If
            editando_efectivo = False
        End If
    End Sub

    Private Sub txtEfectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEfectivo.LostFocus
        editando_efectivo = True
        txtEfectivo.Text = String.Format("{0:n}", objFP.Efectivo)
        editando_efectivo = False
    End Sub

    Private Sub txtUsar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsar.Click
        txtUsar.SelectAll()
    End Sub
    Private Sub FuncionAUsar()
        If txtEfectivo.Text.Length <> 0 And Not txtEfectivo.Text = "" And txtUsar.Text.Length <> 0 And Not txtUsar.Text = "" Then
            objFP.aUsar = String.Format("{0:n}", txtUsar.Text)
            If objFP.aUsar > objFP.Total Then
                objFP.aUsar = 0
                MsgBox("El monto a usar no debe ser mayor al Total.")
                txtUsar.Text = objFP.Total
                txtCambio.Text = String.Format("{0:n}", 0)
            ElseIf objFP.aUsar > objFP.Efectivo Then
                'txtUsar.Text = String.Format("{0:n}", objFP.Efectivo)
                objFP.aUsar = 0
                MsgBox("El monto a usar no debe ser mayor al Efectivo.")
                txtUsar.Text = objFP.Efectivo
                txtCambio.Text = String.Format("{0:n}", 0)
                txtUsar.Focus()
              Else
                ' txtUsar.Text = objFP.aUsar
                objFP.Cambio = objFP.Efectivo - objFP.aUsar
                If objFP.Cambio < 0 Then
                    txtCambio.Text = String.Format("{0:n}", 0)
                Else
                    txtCambio.Text = String.Format("{0:n}", objFP.Cambio)
                    ' txtCambio.Focus()
                End If

            End If
        End If
    End Sub
    Private Sub txtUsar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsar.KeyPress
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
        '    FuncionAUsar()
        'End If
        SoloNumeros(sender, e)
    End Sub

    Private Sub txtUsar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsar.LostFocus

        editando_ausar = True
        txtUsar.Text = String.Format("{0:n}", objFP.aUsar)
        editando_ausar = False

    End Sub
   
    Private Sub txtUsar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsar.TextChanged
        If txtUsar.Text <> "" And txtUsar.Text.Trim <> "." Then
            If editando_ausar = False Then
                editando_ausar = True
                ' objFP.aUsar = String.Format("{0:n}", txtUsar.Text)
                FuncionAUsar()
                CalcularResto()
                editando_ausar = False
            End If
        End If
    End Sub
    Private Sub CalcularResto()
        Dim resto As Decimal = 0

        For Each itemT In lista_tarjeta
            resto += itemT.Monto
        Next

        For Each itemV In lista_vales
            resto += itemV.MontoUsar
        Next

        If objFP.aUsar > 0 Then
            resto += objFP.aUsar
        End If

        resto = objFP.Total - resto

        LBRestoPago.Text = String.Format("{0:n}", resto)

    End Sub
    Private Sub FuncionCambio()
        If txtEfectivo.Text.Length <> 0 And Not txtEfectivo.Text = "" And txtUsar.Text.Length <> 0 And Not txtUsar.Text = "" Then
            If btn IsNot Nothing And btn.Enabled = True Then
                btn.PerformClick()
            Else
                btnfinalizar.PerformClick()
            End If
        End If
    End Sub
    Private Sub txtCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCambio.KeyPress, txtEfectivo.KeyPress, txtUsar.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            FuncionCambio()
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
                txtnumoperacion.Text = ""
                txtnumoperacion.Focus()
            ElseIf Not IsNumeric(txtnumoperacion.Text) Then
                MsgBox("Número de operación (ticket/boucher) requerido.")
                txtnumoperacion.Text = ""
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
                Dim itemTarjeta As New Tarjeta(txtnumoperacion.Text.Trim, CDec(txtmontotarjeta.Text.Trim))
                lista_tarjeta.Add(itemTarjeta)
                ActualizarDGVTrajeta()
                CalcularResto()
                txtnumoperacion.Text = ""
                txtmontotarjeta.Text = ""
                txtnumoperacion.Focus()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnobtenervale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnobtenervale.Click
        Try
            If txtfoliovale.Text.Trim <> "" And IsNumeric(txtfoliovale.Text) Then
                Dim newfolio As Integer = txtfoliovale.Text
                txtfoliovale.Text = ""
                txtfoliovale.Text = newfolio
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If txtfoliovale.Text = "" Then
            MsgBox("Folio requerido")
            txtfoliovale.Text = ""
            txtfoliovale.Focus()
        ElseIf Not IsNumeric(txtfoliovale.Text) Then
            MsgBox("Folio debe ser numerico")
            txtfoliovale.Text = ""
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
                Dim montoNuevo As Decimal = CDec(vale.MontoActual - CDec(txtmontousarvale.Text.Trim))
                Dim itemvale As New Vales(vale.Folio, CDec(txtmontousarvale.Text.Trim), montoNuevo, vale.MontoInicial, vale.Cliente)
                itemvale.NombreCliente = vale.NombreCliente
                lista_vales.Add(itemvale)
                ActualizarDgvVales()
                CalcularResto()
                txtfoliovale.Text = ""
                txtmontovale.Text = ""
                txtmontousarvale.Text = ""
                txtfoliovale.Focus()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtnumoperacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumoperacion.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Try
                If txtnumoperacion.Text.Trim <> "" Then
                    Dim newnumoperacion As Integer = txtnumoperacion.Text
                    txtnumoperacion.Text = ""
                    txtnumoperacion.Text = newnumoperacion
                    txtmontotarjeta.Focus()
                Else
                    MsgBox("Número de operacion es requerido y debe ser numerico")
                    txtnumoperacion.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        SoloNumeros(sender, e)
    End Sub
    Private Sub txtmontotarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmontotarjeta.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Try
                If txtmontotarjeta.Text.Trim <> "" Then
                    Dim newmontotarjeta As Decimal = txtmontotarjeta.Text
                    txtmontotarjeta.Text = ""
                    txtmontotarjeta.Text = newmontotarjeta
                    txtmontotarjeta.Focus()
                    btnagregartarjeta.PerformClick()
                Else
                    MsgBox("Monto de tarjeta es requerido.")
                    txtmontotarjeta.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        SoloNumeros(sender, e)
    End Sub
    Private Sub txtfoliovale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfoliovale.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            txtmontovale.Text = ""
            txtmontousarvale.Text = ""
            btnobtenervale.PerformClick()
        End If
        SoloNumeros(sender, e)
    End Sub
    Private Sub txtmontousarvale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmontousarvale.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnagregarmontovale.PerformClick()
        End If
        SoloNumeros(sender, e)
    End Sub
    Private Sub btnfinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfinalizar.Click
        Try
            If txtEfectivo.Text.Length <> 0 And Not txtEfectivo.Text = "" And txtUsar.Text.Length <> 0 And Not txtUsar.Text = "" Then
                If apartado Then
                    GetConformacionPago()
                    If totalConformado <= 0 Then
                        MsgBox("No se ha realizado ningún tipo de pago.")
                        txtEfectivo.Focus()
                        txtEfectivo.SelectAll()
                        Exit Sub
                    ElseIf totalConformado > objFP.Total Then
                        MsgBox("El monto conformado supera el total, porfavor borra o disminuye las cantidades de los pagos.")
                        txtEfectivo.Focus()
                        txtEfectivo.SelectAll()
                        Exit Sub
                    Else
                        objFP.Pagado = True
                        efectivo = objFP.aUsar
                        Me.Close()
                    End If
                ElseIf credito Then
                    GetConformacionPago()
                    If totalConformado > objFP.Total Then
                        MsgBox("El monto conformado supera el total, porfavor borra o disminuye las cantidades de los pagos.")
                        txtEfectivo.Focus()
                        txtEfectivo.SelectAll()
                        Exit Sub
                    Else
                        objFP.Pagado = True
                        efectivo = objFP.aUsar
                        Me.Close()
                    End If

                Else
                    GetConformacionPago()
                    If totalConformado < objFP.Total Then
                        'txtEfectivo.Focus()
                        'txtEfectivo.SelectAll()
                        MsgBox("No se ha solventado el total de la venta.")
                        Exit Sub
                    ElseIf totalConformado > objFP.Total Then
                        MsgBox("El monto conformado supera el total, porfavor borra o disminuye las cantidades de los pagos.")
                        'txtEfectivo.Focus()
                        'txtEfectivo.SelectAll()
                        Exit Sub
                    ElseIf CerroForma = True Then
                        Exit Sub
                    ElseIf totalConformado = objFP.Total Then
                        objFP.Pagado = True
                        efectivo = objFP.aUsar
                        Me.Close()
                    Else
                        txtEfectivo.Focus()
                        Throw New Exception("No se ha realizado ningún tipo de pago.")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetConformacionPago()
        totalConformado = 0.0
        For Each itemT In lista_tarjeta
            totalConformado += itemT.Monto
        Next

        For Each itemV In lista_vales
            totalConformado += itemV.MontoUsar
        Next

        If objFP.aUsar > 0 Then
            totalConformado += objFP.aUsar
        End If

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
    Private Function VerificaListaVales(ByVal idvale As Integer) As Boolean
        For Each item In lista_vales
            If item.Folio = idvale Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function removerTarjeta(ByVal operacion As String) As Boolean
        For Each itemT As Tarjeta In lista_tarjeta
            If itemT.NumeroOperacion = operacion Then
                lista_tarjeta.Remove(itemT)
                Return True
            End If
        Next
        Return False
    End Function
    Public Function removerVale(ByVal idVale As Integer) As Boolean
        For Each itemV As Vales In lista_vales
            If itemV.Folio = idVale Then
                lista_vales.Remove(itemV)
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub dgvtarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvtarjeta.KeyDown
        If e.KeyCode = 46 Then
            If dgvtarjeta.Rows.Count > 0 Then
                Dim operacion As String = dgvtarjeta.CurrentRow.Cells(0).Value
                Try

                    If Not removerTarjeta(operacion) Then
                        Throw New ReglasNegocioException("Seleccione una operacion de tarjeta")
                    Else
                        ActualizarDGVTrajeta()
                        CalcularResto()
                        If CDec(txtEfectivo.Text) > 0 And Not txtEfectivo.Text = "" And CDec(txtEfectivo.Text) >= objFP.Total Then
                            txtUsar.Text = CDec(txtUsar.Text) + CDec(LBRestoPago.Text)
                        ElseIf CDec(txtEfectivo.Text) > 0 And Not txtEfectivo.Text = "" And CDec(txtEfectivo.Text) <= CDec(LBRestoPago.Text) Or CDec(txtEfectivo.Text) > CDec(LBRestoPago.Text) Then
                            Dim sum As Decimal = CDec(txtUsar.Text) + CDec(LBRestoPago.Text)
                            If sum <= CDec(txtEfectivo.Text) Then
                                txtUsar.Text = sum
                            Else
                                txtUsar.Text = String.Format("{0:n}", txtEfectivo.Text)
                            End If
                        End If
                    End If
                Catch Ex As ReglasNegocioException
                    MsgBox(Ex.Message)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub dgvVales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVales.KeyDown
        If e.KeyCode = 46 Then
            If dgvVales.Rows.Count > 0 Then
                Dim idVale As Integer = dgvVales.CurrentRow.Cells(0).Value
                Try
                    If Not removerVale(idVale) Then
                        Throw New ReglasNegocioException("Seleccione un vale")
                    Else
                        ActualizarDgvVales()
                        CalcularResto()
                        If CDec(txtEfectivo.Text) > 0 And Not txtEfectivo.Text = "" And CDec(txtEfectivo.Text) >= objFP.Total Then
                            txtUsar.Text = CDec(txtUsar.Text) + CDec(LBRestoPago.Text)
                        ElseIf CDec(txtEfectivo.Text) > 0 And Not txtEfectivo.Text = "" And CDec(txtEfectivo.Text) <= CDec(LBRestoPago.Text) Or CDec(txtEfectivo.Text) > CDec(LBRestoPago.Text) Then
                            Dim sum As Decimal = CDec(txtUsar.Text) + CDec(LBRestoPago.Text)
                            If sum <= CDec(txtEfectivo.Text) Then
                                txtUsar.Text = sum
                            Else
                                txtUsar.Text = String.Format("{0:n}", txtEfectivo.Text)
                            End If
                        End If
                    End If
                Catch Ex As ReglasNegocioException
                    MsgBox(Ex.Message)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
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
    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        objFP.Pagado = False
        CerroForma = True
        Me.Close()
    End Sub
    Private Sub frmFormaPago_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 20 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click

        If oculto = False Then
            Me.GroupBox1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            CType(Me.dgvVales, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dgvtarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            Me.Panel1.Hide()
            btn.Enabled = True
            btn.Visible = True

            btnClose.Location = New Point(Me.Width - Panel1.Width + 165, 7)
            btnMin.Location = New Point(Me.Width - Panel1.Width - 70 + 200, 7)
            Dim loca As Decimal = ((Me.Width - Panel1.Width + 200) / 2) - (Panel2.Width / 2)
            btnHide.Text = "+"
            Panel2.Location = New Point(loca, 30)
            Me.Width = Me.Width - Panel1.Width + 200
            Me.Height = Me.Height + btnfinalizar.Height + LBRestoPago.Height
            oculto = True
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            CType(Me.dgvVales, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            CType(Me.dgvtarjeta, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
            'limpiar pago tarjeta y vales, si se oculta el panel
            dgvtarjeta.Rows.Clear()
            txtnumoperacion.Text = ""
            txtmontotarjeta.Text = ""
            dgvVales.Rows.Clear()
            txtfoliovale.Text = ""
            txtmontovale.Text = ""
            txtmontousarvale.Text = ""
            LBRestoPago.Text = String.Format("{0:n}", objFP.Total)
            If CDec(txtEfectivo.Text) < objFP.Total And CDec(txtEfectivo.Text) < CDec(LBRestoPago.Text) Then
                txtUsar.Text = String.Format("{0:n}", txtEfectivo.Text)
            End If
        Else
            Me.GroupBox1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            CType(Me.dgvVales, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dgvtarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            Me.Width = Me.Width + Panel1.Width - 200
            Me.Height = Me.Height - btnfinalizar.Height - LBRestoPago.Height
            btn.Enabled = False
            btn.Visible = False
            btnClose.Location = New Point(890, 6)
            btnMin.Location = New Point(798, 6)
            Panel2.Location = New Point(12, 30)
            btnHide.Text = "-"
            Me.Panel1.Show()
            oculto = False
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            CType(Me.dgvVales, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            CType(Me.dgvtarjeta, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End If
    End Sub

    Private Sub CreateControls()



        '' Button finalizar
        btn = New Button
        btn.BackgroundImage = Global.Papeleria.My.Resources.Resources.guardar1
        btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        btn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        btn.Size = New System.Drawing.Size(140, 39)
        Dim loca As Decimal = ((Me.Width - Panel1.Width + 200) / 2) - (btn.Width / 2)
        btn.Location = New System.Drawing.Point(loca, 340)
        Me.btnfinalizar.Name = "btnfinalizar"
        btn.TabIndex = 125
        btn.TabStop = False
        btn.Text = "&Finalizar Pago"
        btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        btn.UseVisualStyleBackColor = True
        btn.Enabled = False
        btn.Visible = False
        AddHandler btn.Click, AddressOf btnfinalizar_Click
        Me.Controls.Add(btn)


    End Sub

   
End Class