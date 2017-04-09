Imports LogicaNegocio
Public Class frmAbonoCuentaPagar
    Private compraservice As Service_Compra
    Private abonoservice As Service_CuentaPagar
    Private abono As CAbonoCuentaPagar
    Private listC As List(Of CCompras)
    Private listA As List(Of CAbonoCuentaPagar)
    Private idcredito As Integer = 0
    Private totalcredito As Decimal = 0
    Private CreditoPagado As Boolean = False
    Private TotalResto As Decimal
    Private Col As Integer = 1
    Private valorpagado As Char

    Private Sub frmAbonoCuentaPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmAbonoCuentaPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        obtenerCreditos()
        ''txtfecha.Focus()
        DGVabonos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVcreditos.SelectionMode = DataGridViewSelectionMode.FullRowSelect


    End Sub
    Sub LimpiarGridAbonos()
        DGVabonos.DataSource = Nothing
        txttotalcredito.Text = ""
        txtrestocredito.Text = ""
        txtabono.Text = ""
        TotalResto = 0
        idcredito = 0
        ' txtfecha.Focus()
    End Sub
    Public Sub obtenerCreditos()
        Try
            compraservice = New Service_Compra
            With DGVcreditos
                listC = compraservice.obtenerTodosCreditos
                If listC.Count > 0 Then
                    Dim filtro = From creditos In listC Select creditos.Fecha, creditos.RazonProv, creditos.Total, creditos.IdCredito, creditos.Pagado
                    .DataSource = filtro.ToList
                Else
                    DGVcreditos.DataSource = Nothing
                    MsgBox("No existen creditos por pagar a proveedores")
                    Exit Sub
                End If
                .Columns(0).Visible = True
                .Columns(0).Width = 150
                .Columns(1).Visible = True
                .Columns(2).Visible = True
                .Columns(2).DefaultCellStyle.Format = "c"
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).Visible = False
                .Columns(4).Visible = False
            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtfecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filtrarDGV()
    End Sub
    Private Sub filtrarDGV()
        Try
            Dim filtro = From creditos In listC Select creditos.Fecha, creditos.RazonProv, creditos.Total, creditos.IdCredito, creditos.Pagado Where (Fecha.ToString).Contains(String.Format("{0:dd/MM/yyyy}", dtFecha.Value))
            DGVcreditos.DataSource = filtro.ToList
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DGVcreditos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVcreditos.CellDoubleClick
        If Not DGVcreditos.RowCount < 0 Then
            TotalResto = 0
            totalcredito = DGVcreditos.CurrentRow.Cells(2).Value
            idcredito = DGVcreditos.CurrentRow.Cells(3).Value
            valorpagado = DGVcreditos.CurrentRow.Cells(4).Value
            If valorpagado = "1" Then
                MsgBox("Este credito ya esta pagado por completo.")
                txtabono.Enabled = False
                btnagregarabono.Enabled = False
            Else
                txtabono.Enabled = True
                btnagregarabono.Enabled = True
            End If
            txttotalcredito.Text = String.Format("{0:c}", totalcredito)
            obtenerAbonos(idcredito)
            txtabono.Focus()
        End If
    End Sub
    Public Sub obtenerAbonos(ByVal idcreditos As Integer)
        Try
            abonoservice = New Service_CuentaPagar
            With DGVabonos
                listA = abonoservice.obtenerAbonosCreditos(idcreditos)
                If listA.Count > 0 Then
                    Dim filtro = From abonos In listA Select abonos.Fecha, abonos.Abono, abonos.Id, abonos.IdCredito
                    .DataSource = filtro.ToList
                Else
                    DGVabonos.DataSource = Nothing
                    MsgBox("Este credito aun no tiene abonos")
                    Exit Sub
                End If
                .Columns(0).Visible = True
                .Columns(0).Width = 145
                .Columns(1).Visible = True
                .Columns(1).Width = 85
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(1).DefaultCellStyle.Format = "c"
                .Columns(2).Visible = False
                .Columns(3).Visible = False
            End With
            For Each row As DataGridViewRow In Me.DGVabonos.Rows
                TotalResto += Val(row.Cells(Col).Value)
            Next
            txtrestocredito.Text = String.Format("{0:c}", totalcredito - TotalResto)
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnagregarabono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregarabono.Click
        If idcredito < 1 Then
            txtabono.Text = ""
            'txtfecha.Focus()
            MsgBox("Debe seleccionar un credito.")
        ElseIf Not IsNumeric(txtabono.Text) Then
            MsgBox("Debes introducir solo números.")
            txtabono.Text = ""
            txtabono.Focus()
        ElseIf CDec(txtabono.Text) < 1 Then
            MsgBox("El abono no debe ser mayor a cero pesos.")
            txtabono.Text = ""
            txtabono.Focus()
        ElseIf CDec(txtabono.Text) > totalcredito Then
            MsgBox("El abono no debe ser mayor al total del credito.")
            txtabono.Text = ""
            txtabono.Focus()
        ElseIf CDec(txtabono.Text) > (totalcredito - TotalResto) Then
            MsgBox("El abono no debe ser mayor al resto del credito.")
            txtabono.Text = ""
            txtabono.Focus()
        Else
            If (TotalResto + CDec(txtabono.Text)) = totalcredito Then
                CreditoPagado = True
            End If
            GuardarAbono(idcredito, CreditoPagado)
        End If
    End Sub
    Public Sub GuardarAbono(ByVal idcredito As Integer, ByVal creditopagado As Boolean)
        Try
            abonoservice = New Service_CuentaPagar
            abonoservice.insertar(txtabono.Text.Trim, idcredito, creditopagado)
            TotalResto = 0
            txtabono.Text = ""
            txtabono.Focus()
            obtenerAbonos(idcredito)
            If creditopagado = True Then
                MsgBox("Credito pagado por completo.")
                creditopagado = False
                LimpiarGridAbonos()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtabono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtabono.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            GuardarAbono(idcredito, CreditoPagado)
        End If
        SoloNumeros(sender, e)
    End Sub
    Private Sub frmCompra_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
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

    Private Sub DGVabonos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVabonos.KeyDown
        If e.KeyCode = 46 Then
            Dim IDAbono As String = DGVabonos.CurrentRow.Cells(2).Value
            Dim IDCredito As String = DGVabonos.CurrentRow.Cells(3).Value
            Dim Cantidad As String = DGVabonos.CurrentRow.Cells(1).Value
            Try      
                abonoservice = New Service_CuentaPagar
                abonoservice.BorrarAbono(IDAbono)
                TotalResto = 0
                txtabono.Text = ""
                txtabono.Focus()
                Dim restoAnterior As Decimal = CDec(txtrestocredito.Text)
                txtrestocredito.Text = String.Format("{0:c}", restoAnterior + Cantidad)
                obtenerAbonos(IDCredito)
            Catch Ex As ReglasNegocioException
                MsgBox(Ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub dtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFecha.ValueChanged
        filtrarDGV()
    End Sub
End Class