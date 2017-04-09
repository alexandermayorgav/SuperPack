Imports LogicaNegocio
Public Class frmDevVenta

    Private sv As Service_Venta
    Private totalVenta As Decimal
    Private subtotalVenta As Decimal
    Private descuentoTotal As Decimal
    Private IvaVenta As Decimal
    Private aDevolverTotal As Decimal
    Private devueltosTotal As Decimal
    Private sc As Service_Cliente
    Private Cliente As Cliente
    Private sp As Service_Producto
    Private producto As Producto
    Private item As VentaItem
    Private dev As Devolucion
    Private sd As Service_Devolucion
    Private datosTicket As DatosTicket
    Private fecha As Date

    Dim validacion As CValidation
    Dim keyascii As Short

    Private Sub frmDevVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Not dev Is Nothing Then
                    If dev.Items.Count > 0 Then
                        Dim a = MsgBox("La devolucion se cerrará y los datos se perderán." & "¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                        If a = vbYes Then
                            Me.Close()
                        End If
                    Else
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If

            Case Keys.F3
                btnBuscaProducto.PerformClick()
            Case Keys.F4
                btnAgregar.PerformClick()
            Case Keys.F5
                btnGuardar.PerformClick()
            Case Keys.F7
                If Not dev Is Nothing Then
                    If dev.Items.Count > 0 Then
                        Dim a = MsgBox("Los datos actuales se perderán." & "¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                        If a = vbYes Then
                            btnNuevo.PerformClick()
                        End If
                    End If
                Else
                    btnNuevo.PerformClick()
                End If

        End Select

    End Sub
    Private Sub frmDevVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        lblPrecio.Text = String.Format("{0:c}", 0)
        lblTotal.Text = ""
    End Sub
    Private Sub limpiar()
        nuevoProducto()
        dgvp.Rows.Clear()
        dev = Nothing
        Cliente = Nothing
        totalVenta = 0
        subtotalVenta = 0
        descuentoTotal = 0
        IvaVenta = 0
        aDevolverTotal = 0
        devueltosTotal = 0
        sc = Nothing
        sp = Nothing
        dev = Nothing
        txtCliente.Text = ""

        txtDesc.Text = String.Format("{0:c}", 0)
        txtSubtotal.Text = String.Format("{0:c}", 0)
        txtTotalAdevolver.Text = String.Format("{0:c}", 0)
        txtDevueltos.Text = String.Format("{0:c}", 0)
        lblTotal.Text = ""
        txtFolio.Text = ""
        txtFolio.Select()
        txtFolio.Focus()
    End Sub
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Not txtCodigo.Text.Length <= 0 Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

                If Not dev Is Nothing Then
                    Try
                        sp = New Service_Producto
                        producto = New Producto
                        producto = sp.Obtener(txtCodigo.Text.Trim)
                        lblProducto.Text = producto.Descripcion
                        lblPrecio.Text = String.Format("{0:c}", producto.Precio)
                        txtCantidad.Focus()
                        sp = Nothing

                    Catch ex As Exception
                        MsgBox(ex.Message & Chr(13) & "El codigo " & txtCodigo.Text)
                        txtCodigo.Text = ""
                        txtCodigo.Focus()
                    End Try
                Else
                    MsgBox("Seleccione una venta.")
                    txtCodigo.Text = ""

                End If

            End If
        End If
    End Sub
    Public Sub VerVenta(ByVal id As Integer)
        Try
            sv = New Service_Venta
            dev = sv.Obtener(id)
            dtp.Value = dev.Fecha
            dev.ivaValor = Sesion.iva
            cargaCliente(dev.Id_Venta)

            Dim listadev As List(Of pDevueltos)
            listadev = New Service_Devolucion().Devueltos((dev.Id))
            dev.ActualizaDevueltos(listadev)
            dev.ActualizaPrecios()

            ActualizarGrid()
            txtCodigo.Select()
            txtCodigo.Focus()
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnObtenerVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerVenta.Click
        If txtFolio.Text.Length > 0 Then
            Try
                VerVenta(txtFolio.Text.Trim)
            Catch ex As Exception
                MsgBox(ex.Message)
                limpiar()
            End Try
        End If
    End Sub
    Private Sub cargaCliente(ByVal id As Integer)
        Try
            sc = New Service_Cliente
            Cliente = New Cliente
            Cliente = sc.Obtener(id)
            txtCliente.Text = Cliente.Razon
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActualizarGrid()

        Dim R As Short = 0
        dgvp.Rows.Clear()

        For Each item As Devolucion_Item In dev.Items
            With dgvp
                .Rows.Add()
                R = .RowCount - 1

                If item.Promo Then
                    .Rows(R).DefaultCellStyle.BackColor = Color.RoyalBlue
                End If

                .Rows(R).Cells("Id").Value = item.Id
                .Rows(R).Cells("Codigo").Value = item.Producto.Codigo
                .Rows(R).Cells("Descripcion").Value = item.Producto.Descripcion
                .Rows(R).Cells("Cantidad").Value = item.Cantidad
                .Rows(R).Cells("Devueltos").Value = item.Devueltos
                .Rows(R).Cells("ADevolver").Value = item.aDevolver
                .Rows(R).Cells("Precio").Value = item.Producto.Precio
                .Rows(R).Cells("iva").Value = IIf(item.Producto.Iva, "16 %", "0 %")
                .Rows(R).Cells("DescuentoPor").Value = item.DescuentoP & " %"
                .Rows(R).Cells("DescuentoDin").Value = item.DescuentoD
                .Rows(R).Cells("Total").Value = item.Total
            End With
        Next

        Dim fuente As New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel, 4)
        dgvp.Font = fuente

        Dim renglo As Integer = dgvp.RowCount - 1
        '    DGVP.Rows(renglo).Selected = True
        If Not renglo <= 0 Then
            dgvp.FirstDisplayedScrollingRowIndex = dgvp.Rows(renglo).Index
        End If

        dgvp.Columns(0).Width = 35
        dgvp.Columns(1).Width = 85
        dgvp.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvp.Columns(2).Width = 200
        dgvp.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvp.Columns(3).Width = 60
        dgvp.Columns(4).Width = 60
        dgvp.Columns(5).Width = 60
        dgvp.Columns(6).Width = 75
        dgvp.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvp.Columns(6).DefaultCellStyle.Format = "c"
        dgvp.Columns(7).Width = 50
        dgvp.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvp.Columns(8).Width = 75
        dgvp.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvp.Columns(8).HeaderText = "Desct. %"
        dgvp.Columns(9).Width = 75
        dgvp.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvp.Columns(9).DefaultCellStyle.Format = "c"
        dgvp.Columns(9).HeaderText = "Desct. $"
        dgvp.Columns(10).Width = 85
        dgvp.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvp.Columns(10).DefaultCellStyle.Format = "c"

        subtotalVenta = dev.Totalf
        IvaVenta = dev.ivaf
        totalVenta = subtotalVenta + IvaVenta
        descuentoTotal = dev.Descuentosf
        aDevolverTotal = dev.Adevolverf
        devueltosTotal = dev.Devueltosf

        Dim tot As Decimal = totalVenta
        txtSubtotal.Text = String.Format("{0:c}", subtotalVenta)
        txtDesc.Text = String.Format("{0:c}", descuentoTotal)
        txtTotalAdevolver.Text = String.Format("{0:c}", aDevolverTotal)
        txtDevueltos.Text = String.Format("{0:c}", devueltosTotal)

        lblTotal.Text = FormatCurrency(String.Format("{0:n}", subtotalVenta))
        Dim st As String = String.Format("{0:n}", subtotalVenta)
        Dim total() As String
        total = Split(st, ".")
        lblTotal.Text = "SON:  " & Utils.Num2Text(total(0)) & " PESOS " & total(1) & "/100 MN"

        lblDevolucion.Text = FormatCurrency(String.Format("{0:n}", aDevolverTotal))
        Dim st2 As String = String.Format("{0:n}", aDevolverTotal)
        Dim total2() As String
        total2 = Split(st2, ".")
        lblDevolucion.Text = "SON:  " & Utils.Num2Text(total2(0)) & " PESOS " & total2(1) & "/100 MN"

        dev.Total_texto = lblDevolucion.Text
    End Sub
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            If txtCantidad.Text = 0 Then
                MsgBox("Cantidad Invalida")
                txtCantidad.Select()
                txtCantidad.Focus()
                Exit Sub
            End If
            If producto Is Nothing Then
                MsgBox("Seleccione un producto.")
                txtCodigo.Focus()
                Exit Sub
            Else
                If dev.ExisteProducto(producto.Id) Then
                    If dev.Cantidad(producto.Id, txtCantidad.Text.Trim) Then
                        If dev.UpdateADevolcer(txtCantidad.Text.Trim, producto.Id) Then
                            ActualizarGrid()
                        Else
                            nuevoProducto()
                            Throw New Exception("No hay devoluciones en una promocion.")

                        End If
                    Else
                        txtCantidad.Select()
                        txtCantidad.Focus()
                        Throw New Exception("La cantidad a devolver es mayor a la permitida")
                    End If
                Else
                    nuevoProducto()
                    Throw New Exception("Producto no encontrado en esta venta.")

                End If
            End If

            nuevoProducto()
        Catch ex As Exception
            MsgBox(ex.Message)
            'nuevoProducto()
        End Try
    End Sub
    Private Sub nuevoProducto()
        producto = Nothing
        lblPrecio.Text = ""
        lblProducto.Text = ""
        txtCantidad.Text = 1
        txtCodigo.Text = ""
        txtCodigo.Select()
        txtCodigo.Focus()
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub
    Private Sub txtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If txtFolio.Text.Length <> 0 Then
                btnObtenerVenta.PerformClick()
            End If
        End If
        validacion = New CValidation
        keyascii = CShort(Asc(e.KeyChar))
        keyascii = CShort(validacion.SoloNumeros(keyascii))
        If keyascii = 0 Then
            e.Handled = True
        End If
        validacion = Nothing
    End Sub
    Private Sub btnBuscaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaProducto.Click
        Try
            Dim frm As New frmBuscarProducto
            frm.ShowDialog()
            txtCodigo.Text = frm.codigo
            txtCodigo.Focus()
            SendKeys.Send("{ENTER}")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Not dev Is Nothing Then
                If dev.ExisteADevolver Then
                    fecha = Date.Now
                    guardar()

                    MsgBox("Guardado Correctamente.")
                    Dim frm As New frmVales(aDevolverTotal, dev.Id_Venta, True)
                    frm.txtMonto.Enabled = False
                    frm.ShowDialog()
                    'If Sesion.imprimeTicket Then
                    'doTicket(Sesion.id_caja, dev.Id, Sesion.nombre_usuario, fecha, Cliente.Razon)
                    'ElseIf Sesion.Abrir_Cajon Then
                    'abreCajon()
                    'End If
                    limpiar()
                Else
                    Throw New Exception("No hay productos a devolver")
                End If
            Else
                Throw New Exception("No se ha cargado ninguna venta")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub abreCajon()
        Try
            Dim ticket As New BarControls.Ticket
            ticket.AddHeaderLine("")
            ticket.PrintTicket(Sesion.impresora)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub guardar()

        dev.Id_usuario = Sesion.id_usuario_sesion
        dev.Fecha = fecha
        dev.Subtotal = aDevolverTotal - IvaVenta
        dev.Descuento = 0
        dev.Iva = IvaVenta

        dev.Total = aDevolverTotal
        dev.Total_texto = lblDevolucion.Text

        sd = New Service_Devolucion
        sd.Guardar(dev, Sesion.id_caja)
        
    End Sub
    

    Public Sub doTicket(ByVal caja As Integer, ByVal no_ticket As Integer, ByVal nom_usuario As String, ByVal fecha As Date, ByVal cliente As String)
        Try
           
            Dim ticket As New BarControls.Ticket
            ticket.AddHeaderLine(Sesion.negocio)
            ticket.AddHeaderLine(Sesion.direccion)
            ticket.AddHeaderLine(Sesion.ciudad)

            If Not Sesion.telefono = "        " Then
                ticket.AddHeaderLine("Teléfono: " & Sesion.telefono)
            End If

            ticket.AddHeaderLine("Folio " & no_ticket & "     " & fecha)
            ticket.AddHeaderLine("Le atendió: " & Sesion.nombre_usuario)


            ticket.AddSubHeaderLine("Concepto: VALE")
            ticket.AddSubHeaderLine("Cliente: " & cliente)


            ticket.AddFooterLine("Monto        " & FormatCurrency(aDevolverTotal))
            Dim st2 As String = String.Format("{0:n}", aDevolverTotal)
            Dim total2() As String
            total2 = Split(st2, ".")
            ticket.AddFooterLine(Utils.Num2Text(total2(0)).ToLower & " Pesos " & total2(1) & "/100 MN")
            ticket.AddFooterLine("")
            ticket.AddFooterLine("Firma de Autorización _________________")
            ticket.AddFooterLine(Sesion.saludo)
            ticket.AddFooterLine("")
            ticket.PrintTicket2(Sesion.impresora)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Not dev Is Nothing Then
            If dev.Items.Count > 0 Then
                Dim a = MsgBox("La devolucion se cerrará y los datos se perderán." & "¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                If a = vbYes Then
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub


    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnAgregar.PerformClick()
        End If


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
    Private Sub frmCompra_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class