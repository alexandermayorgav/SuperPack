Imports LogicaNegocio
'Imports System.Threading
Imports MonoReports.Model
Public Class frmVenta
    Private sp As Service_Producto
    Private producto As Producto
    Public venta As Venta
    Public item As VentaItem
    Public cliente As Cliente
    Private sc As Service_Cliente
    Dim validacion As CValidation
    Dim keyascii As Short
    Private totalVenta As Decimal
    Private subtotalVenta As Decimal
    Private IvaVenta As Decimal
    Private folio As Integer
    Dim descuento As Decimal
    Private descuentoTotal As Decimal
    Public pagado As Boolean = False
    Public efectivo As Decimal
    Public cambio As Decimal
    Private datosTicket As DatosTicket = Nothing

    Private objFp As FinalizarPago
    Private fecha As Date
    '//VARIABLES PROMOCIONES 
    Private promo As opPromociones
    Private promo2 As opPromocionesPieza
    Private promoP As PromocionPieza
    Private promoD As Promocion
    '//VARIABLES PARA MAXIMIZAR
    Private maximizado As Boolean = False
    Private meWidht As Integer = 842
    Private meheigth As Integer = 616
    Private promocionesX As Integer = 350
    Private porcentajeX As Integer = (Screen.PrimaryScreen.WorkingArea.Width - promocionesX) * 100 / meWidht
    Private porcentajeY As Integer = (Screen.PrimaryScreen.WorkingArea.Height) * 100 / meheigth
    Private porcentajeReal As Integer
    'Private areaMin As Integer = meheigth * meWidht
    'Private areaMax As Integer = Screen.PrimaryScreen.WorkingArea.Width * Screen.PrimaryScreen.WorkingArea.Height
    'Private areaMaxP As Integer = (Screen.PrimaryScreen.WorkingArea.Width - promocionesX) * Screen.PrimaryScreen.WorkingArea.Height
    'Private PorcentaMax As Integer = (Screen.PrimaryScreen.WorkingArea.Width * Screen.PrimaryScreen.WorkingArea.Height) * 100 / (meheigth * meWidht)
    'Private PorcentajeMaxP As Integer = ((Screen.PrimaryScreen.WorkingArea.Width - promocionesX) * Screen.PrimaryScreen.WorkingArea.Height) * 100 / (meheigth * meWidht)

    Private tot As Integer = 0
    Private aux As Integer = 0
    Private lista As New List(Of VerPromociones)
    Public servicios As Boolean

    Private vales As Decimal = 0
    Private tarjetas As Decimal = 0
    Private publico As Boolean = True
   

    Private Sub btnBuscaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaProducto.Click
        Try
            Dim frm As New frmBuscarProducto
            frm.TipoProducto = 0
            frm.ShowDialog()
            txtCodigo.Text = frm.codigo
            txtCodigo.Focus()
            SendKeys.Send("{ENTER}")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Not txtCodigo.Text.Length <= 0 Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                If Not cliente Is Nothing Then
                    Try
                        sp = New Service_Producto
                        'producto = New Producto
                        producto = sp.Obtener(txtCodigo.Text.Trim)

                        ''//PROMOCION PIEZAS
                        Dim lista = From promo In promo2.Promociones Where promo.Producto.Id = producto.Id
                        If lista.Count > 0 Then
                            For Each it In lista
                                promoP = New PromocionPieza
                                promoP.Cantidad = it.Cantidad
                                promoP.Producto = it.Producto
                                promoP.CantidadRegalada = it.CantidadRegalada
                                promoP.ProductoRegalo = it.ProductoRegalo
                            Next
                        End If
                        ''//PROMOCION DESCUENTO
                        Dim lista2 = From promo In promo.Promociones Where promo.Producto.Id = producto.Id
                        If lista2.Count > 0 Then
                            For Each i In lista2
                                promoD = New Promocion
                                promoD.Cantidad = i.Cantidad
                                promoD.Producto = i.Producto
                                promoD.Descuento = i.Descuento
                            Next
                        End If
                        '//YA ESTABA
                        lblProducto.Text = producto.Descripcion
                        lblPrecio.Text = String.Format("{0:c}", producto.Precio)
                        lblRango.Text = producto.Rango
                        lblExistencia.Text = producto.Existencia
                        descuentos()
                        txtCantidad.Focus()
                        sp = Nothing
                        If Not chkConsultar.Checked = True Then
                            btnAgregar.PerformClick()
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message & Chr(13) & "El codigo " & txtCodigo.Text)
                        txtCodigo.Text = ""
                        txtCodigo.Focus()
                    End Try
                Else
                    MsgBox("Seleccione un cliente.")
                    txtFolioCliente.Focus()
                End If

            End If
        End If
    End Sub
    Private Sub frmVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Not venta Is Nothing Then
                    If venta.Items.Count > 0 Then
                        Dim a = MsgBox("La venta actual se cerrará y los datos se perderán." & "¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                        If a = vbYes Then
                            Me.Close()
                        End If
                    Else
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If

            Case Keys.F1
                If chkConsultar.Checked = True Then
                    chkConsultar.Checked = False
                Else
                    chkConsultar.Checked = True
                End If
            Case Keys.F2
                btnBuscacliente.PerformClick()
            Case Keys.F3
                btnBuscaProducto.PerformClick()
            Case Keys.F4
                btnAgregar.PerformClick()
            Case Keys.F5
                btnGuardar.PerformClick()
            Case Keys.F7
                If Not venta Is Nothing Then
                    If venta.Items.Count > 0 Then
                        Dim a = MsgBox("Los datos actuales se perderán." & "¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                        If a = vbYes Then
                            btnNuevo.PerformClick()
                        End If
                    End If
                Else
                    btnNuevo.PerformClick()
                End If
            Case Keys.F8
                btnCotizacion.PerformClick()
            Case Keys.F9
                btnCancelarDesc.PerformClick()
        End Select
    End Sub
    Private Sub frmVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        limpiar()
        cargarFolio()
        If servicios Then
            primerCliente(venta.Id_cliente)
        Else
            primerCliente(1)
        End If
        servicios = False

        promociones()


    End Sub
    Private Sub promociones()
        promo = New opPromociones(1)
        promo2 = New opPromocionesPieza(1)
    End Sub
    Private Sub primerCliente(ByVal id As Integer)
        Try
            sc = New Service_Cliente
            cliente = New Cliente
            cliente = sc.Obtener(id)
            txtFolioCliente.Text = 1
            txtCliente.Text = cliente.Razon
            txtCodigo.Select()
            txtCodigo.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
            txtFolioCliente.Focus()
        End Try
    End Sub
    Private Sub cargarFolio()
        Try
            Dim sv As New Service_Venta
            folio = sv.ObtenerMax()
            txtFolio.Text = folio + 1
            txtFolioCliente.Select()
            txtFolioCliente.Focus()
        Catch ex As Exception
            txtFolio.Text = folio + 1
        End Try
    End Sub
    Private Sub limpiar()
        descuento = 0
        lblPrecio.Text = String.Format("{0:c}", 0)
        lblProducto.Text = ""
        lblTotal.Text = ""
        lblRango.Text = 0
        lblExistencia.Text = 0
        Try

            If Not servicios Then
                venta = New Venta
            End If

            item = New VentaItem
            producto = Nothing
            sp = Nothing
            cliente = Nothing
            sc = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        txtFolioCliente.Text = ""
        txtCliente.Text = ""
        txtSubtotal.Text = String.Format("{0:c}", 0)
        txtDesc.Text = String.Format("{0:c}", 0)
        txtDescuento.Text = String.Format("{0:d}", 0)
        dgvp.Rows.Clear()
        '
        totalVenta = 0
        subtotalVenta = 0
        IvaVenta = 0
        folio = 0
        txtCodigo.Text = ""
        txtDescuento.Text = 0
        btnAgregar.Enabled = True
        btnCancelarDesc.Enabled = False
        btnAplicarDesc.Enabled = True
        btnCotizacion.Enabled = True

        pagado = False
        efectivo = 0
        cambio = 0

        btnCredito.Enabled = False

        promoD = Nothing
        promoP = Nothing
        txtCantidad.Text = 1
        publico = True
        chkMenudeo.Checked = False
    End Sub
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Not cliente Is Nothing Then
            agregar()
        Else
            MsgBox("Seleccione un cliente.")
            txtFolioCliente.Focus()
        End If

    End Sub
    Private Sub agregar()
        Try
            If producto Is Nothing Then
                MsgBox("Seleccione un producto.")
                txtCodigo.Focus()
                Exit Sub
            End If

            venta.venderSinExistencia = Sesion.venderSinExis
            '//PROMOCION PIEZAS
            If Not promoP Is Nothing Then
                Dim IntNum As String = InputBox("COMPRA:  " & Chr(13) & promoP.Cantidad & "    " & promoP.Producto.Descripcion.ToLower & "    " & String.Format("{0:c}", promoP.Producto.Precio) & "    c/u" & Chr(13) & "LLEVATE GRATIS:" & Chr(13) & promoP.CantidadRegalada & " " & promoP.ProductoRegalo.Descripcion & " " & String.Format("{0:c}", promoP.ProductoRegalo.Precio) & Chr(13) & "CANTIDAD A COMPRAR:", "PROMOCION DISPONIBLE", promoP.Cantidad)

                If Not IntNum = "" Then
                    Try
                        txtCantidad.Text = CDec(IntNum)
                    Catch ex As Exception
                        Throw New Exception("Cantidad invalida.")
                    End Try
                ElseIf txtCantidad.Text = "" Then
                    txtCantidad.Text = 1
                End If

                Dim cantidad As Decimal = txtCantidad.Text / promoP.Cantidad
                cantidad = Fix(cantidad)
                Dim aux As Decimal = txtCantidad.Text - cantidad
                'If aux > 0 And producto.Kg Then
                item = New VentaItem(IIf(txtCantidad.Text = "", 1, txtCantidad.Text), descuento, producto, False, "Pieza")
                item.Relacion = promoP.ProductoRegalo.Codigo
                venta.AgregarItem(item)
                'Else
                'item = New VentaItem(Fix(txtCantidad.Text), descuento, producto, False, "Pieza")
                'item.Relacion = promoP.ProductoRegalo.Codigo
                'venta.AgregarItem(item)
                ''End If

                If Not cantidad = 0 Then
                    item = New VentaItem(cantidad * promoP.CantidadRegalada, 100, promoP.ProductoRegalo, True, "Pieza")
                    venta.AgregarItem(item)
                End If
                promoP = Nothing

                '/PROMOCION DESCUENTO
            ElseIf Not promoD Is Nothing Then
                Dim IntNum2 As String = InputBox("COMPRA:    " & Chr(13) & promoD.Cantidad & " " & promoD.Producto.Descripcion.ToLower & " " & String.Format("{0:c}", promoD.Producto.Precio) & Chr(13) & "AL " & promoD.Descuento & " % de DESCUENTO" & Chr(13) & "CANTIDAD A COMPRAR:", "PROMOCION DISPONIBLE", promoD.Cantidad)

                If Not IntNum2 = "" Then
                    Try
                        txtCantidad.Text = CDec(IntNum2)
                        Dim resto = txtCantidad.Text Mod promoD.Cantidad
                        If Not resto = 0 Then
                            Dim aux As Integer = Fix(resto)
                            Dim aux2 As Decimal = resto - aux
                            'If aux2 > 0 And producto.Kg Then
                            item = New VentaItem(resto, descuento, producto, False, "Descuento")
                            venta.AgregarItem(item)
                            'ElseIf aux > 0 Then
                            '   item = New VentaItem(aux, descuento, producto, False, "Descuento")
                            '  venta.AgregarItem(item)
                            'End If

                        End If
                        If Not txtCantidad.Text - resto <= 0 Then
                            item = New VentaItem(txtCantidad.Text - resto, promoD.Descuento, producto, True, "Descuento")
                            venta.AgregarItem(item)
                        End If
                    Catch ex As Exception
                        Throw New Exception("Cantidad invalida.")
                    End Try
                Else
                    item = New VentaItem(IIf(txtCantidad.Text = "", 1, txtCantidad.Text), descuento, producto, False, "Descuento")
                    venta.AgregarItem(item)
                End If
                promoD = Nothing
            Else
                '/SI NO HAY PROMOCIONES DISPONIBLES


                'If Not txtCantidad.Text = "" And Not txtCantidad.Text = "." Then
                '    Dim cant As Decimal = CDec(txtCantidad.Text)
                '    Dim aux As Integer = Fix(cant)
                '    Dim aux2 As Decimal = cant - aux
                '    If aux2 > 0 Then
                '        If Not producto.Kg Then
                '            If Not CInt(cant) = 0 Then
                '                txtCantidad.Text = aux
                '            Else
                '                txtCantidad.Text = 1
                '            End If
                '        End If
                '    End If
                'End If


                item = New VentaItem(IIf(txtCantidad.Text = "", 1, txtCantidad.Text), descuento, producto, False, "Ninguna")
                venta.AgregarItem(item)
            End If
            '//YA ESTABA
            venta.ivaValor = Sesion.iva
            ActualizarGrid()
            lblProducto.Text = ""
            lblPrecio.Text = String.Format("{0:c}", 0)
            txtCantidad.Text = 1
            txtCodigo.Text = ""
            lblExistencia.Text = 0
            lblRango.Text = 0
            lblDescProd.Text = 0
            producto = Nothing
            txtCodigo.Focus()

        Catch ex As Exception
            ActualizarGrid()
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub ActualizarGrid()
        Try
            Dim R As Short = 0
            dgvp.Rows.Clear()

            For Each item As VentaItem In venta.Items
                With dgvp
                    .Rows.Add()
                    R = .RowCount - 1

                    If item.TipoPromocion = "Pieza" Or item.TipoPromocion = "Descuento" Then
                        .Rows(R).Cells("Cantidad").ReadOnly = True
                        If item.Promocion Then
                            .Rows(R).DefaultCellStyle.BackColor = System.Drawing.Color.RoyalBlue
                        End If
                    End If

                    .Rows(R).Cells("Id").Value = item.Id
                    .Rows(R).Cells("Codigo").Value = item.Producto.Codigo
                    If item.Promocion Then
                        .Rows(R).Cells("Descripcion").Value = item.Producto.Descripcion & "/" & item.Producto.Piezas & "/Promocion"
                    Else
                        .Rows(R).Cells("Descripcion").Value = item.Producto.Descripcion & "/" & item.Producto.Piezas
                    End If
                    .Rows(R).Cells("Cantidad").Value = item.Cantidad
                    .Rows(R).Cells("Precio").Value = item.Producto.Precio
                    .Rows(R).Cells("iva").Value = IIf(item.Producto.Iva, "16 %", "0 %")
                    .Rows(R).Cells("DescuentoPor").Value = item.DescuentoPor & " %"
                    .Rows(R).Cells("DescuentoDin").Value = item.DescuentoDin
                    .Rows(R).Cells("Total").Value = item.Total
                    .Rows(R).Cells("Existencia").Value = item.Producto.Existencia
                End With
            Next


            Dim renglo As Integer = dgvp.RowCount - 1
            '    DGVP.Rows(renglo).Selected = True
            If Not renglo <= 0 Then
                dgvp.FirstDisplayedScrollingRowIndex = dgvp.Rows(renglo).Index
            End If

            If Not maximizado Then
                Dim fuente As New System.Drawing.Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel, 4)
                dgvp.Font = fuente
                dgvp.Columns(0).Width = 70
                dgvp.Columns(1).Width = 90
                dgvp.Columns(2).Width = 250
                dgvp.Columns(3).Width = 70
                dgvp.Columns(4).Width = 75
                dgvp.Columns(5).Width = 75
                dgvp.Columns(6).Width = 75
                dgvp.Columns(7).Width = 75
                dgvp.Columns(8).Width = 95
            End If

            dgvp.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvp.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvp.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvp.Columns(4).DefaultCellStyle.Format = "c"
            dgvp.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvp.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvp.Columns(6).HeaderText = "Desct. %"
            dgvp.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvp.Columns(7).DefaultCellStyle.Format = "c"
            dgvp.Columns(7).HeaderText = "Desct. $"
            dgvp.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvp.Columns(8).DefaultCellStyle.Format = "c"


            subtotalVenta = venta.Totalf
            descuentoTotal = venta.Descuentosf
            IvaVenta = venta.ivaf
            totalVenta = subtotalVenta
            Dim tot As Decimal = totalVenta

            txtSubtotal.Text = Math.Round(subtotalVenta, 2)
            txtDesc.Text = Math.Round(descuentoTotal, 2)
            txtSubtotal.Text = String.Format("{0:c}", subtotalVenta)
            txtDesc.Text = String.Format("{0:c}", descuentoTotal)
            lblTotal.Text = FormatCurrency(String.Format("{0:n}", tot))

            Dim st As String = String.Format("{0:n}", tot)
            Dim total() As String
            total = Split(st, ".")
            lblTotal.Text = Utils.Num2Text(total(0)) & " PESOS " & total(1) & "/100 MN"
            venta.Total_texto = lblTotal.Text
        Catch ex As Exception
            Exit Try
        End Try
    End Sub
    Private Sub btnBuscacliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscacliente.Click
        Try
            Dim frm As New frmBuscarCliente
            frm.ShowDialog()
            txtFolioCliente.Text = frm.id_cliente
            txtFolioCliente.Focus()
            SendKeys.Send("{ENTER}")
            frm = Nothing
        Catch ex As Exception
            limpiar()
            MsgBox(ex.Message)
            txtFolio.Text = ""
            txtFolio.Focus()

        End Try



    End Sub
 
    Private Sub txtFolioCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioCliente.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If txtFolioCliente.Text.Length <> 0 And txtFolioCliente.Text <> 0 Then
                Dim aux As Integer = cliente.Id
                Try
                    'If Not publico And venta.Items.Count > 0 Then
                    '    Dim A = MsgBox("Si cambia el cliente los datos de la venta actual se perderan, Desea continuar?" _
                    '                    , MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                    '    If A = vbYes Then
                    '        sc = New Service_Cliente
                    '        cliente = New Cliente
                    '        cliente = sc.Obtener(CInt(txtFolioCliente.Text))
                    '        txtCliente.Text = cliente.Razon

                    '        If cliente.Id = 1 Or cliente.Razon = "PUBLICO GENERAL" Then
                    '            publico = True
                    '        Else
                    '            publico = False
                    '        End If

                    '        If cliente.CreditoActivo Then
                    '            btnCredito.Enabled = True
                    '        Else
                    '            btnCredito.Enabled = False
                    '        End If

                    '        txtCodigo.Focus()

                    '        venta.Items.Clear()
                    '        ActualizarGrid()
                    '    Else
                    '        Exit Sub
                    '    End If
                    'Else
                    sc = New Service_Cliente
                    cliente = New Cliente
                    cliente = sc.Obtener(CInt(txtFolioCliente.Text))
                    txtCliente.Text = cliente.Razon


                    If cliente.Id = 1 Or cliente.Razon = "PUBLICO GENERAL" Then
                        publico = True
                    Else
                        publico = False
                    End If

                    If cliente.CreditoActivo Then
                        btnCredito.Enabled = True
                    Else
                        btnCredito.Enabled = False
                    End If

                    txtCodigo.Focus()
                    'End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                    primerCliente(1)
                End Try
            Else
                txtFolioCliente.Text = 1
                txtCodigo.Focus()
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

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar()
        cargarFolio()
        primerCliente(1)
    End Sub
    'Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
    '    If Not Sesion.id_caja = 0 Then
    '        If venta.Items.Count = 0 Then
    '            MsgBox("No hay productos seleccionados.")
    '            txtCodigo.Focus()
    '            Exit Sub
    '        End If
    '        Try
    '            Dim total As String = String.Format("{0:f2}", totalVenta)
    '            objFp = New FinalizarPago(total, 0, 0, 0, False)
    '            Dim frm As New frmFormaPago(objFp, False)
    '            frm.ShowDialog()

    '            If objFp.Pagado Then

    '                venta.ivaValor = Sesion.iva
    '                fecha = Date.Now
    '                guardarVenta(1, frm.efectivo, frm.lista_vales, frm.lista_tarjeta)
    '                Dim id_cliente As Integer = venta.Id_cliente
    '                If Sesion.imprimeTicket Then
    '                    Dim A = MsgBox("GUARDADO CORRECTAMENTE." & Chr(13) & Chr(13) & "Desea imprimir el ticket de venta?." _
    '                             , MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
    '                    If A = vbYes Then
    '                        'doTicket(Sesion.id_caja, venta.Id, "Ticket de Venta", fecha, cliente.Razon, 1)
    '                        doTicket2(Sesion.id_caja, venta.Id, "Ticket de Venta", fecha, cliente.Razon, 1)
    '                    Else
    '                        If Sesion.Abrir_Cajon Then
    '                            abreCajon()
    '                        End If
    '                        limpiar()
    '                        cargarFolio()
    '                        primerCliente(1)
    '                    End If
    '                Else
    '                    MsgBox("GUARDADO CORRECTAMENTE.")
    '                    If Sesion.Abrir_Cajon Then
    '                        abreCajon()
    '                    End If

    '                    limpiar()
    '                    cargarFolio()
    '                    primerCliente(1)

    '                End If

    '                If Sesion.imprimeTicket Then
    '                    If frm.lista_vales.Count > 0 Then

    '                        For Each it As Vales In frm.lista_vales
    '                            If it.MontoActual <> 0 Then
    '                                Try
    '                                    Dim ticket As New BarControls.Ticket
    '                                    ticket.AddHeaderLine(Sesion.negocio)
    '                                    ticket.AddHeaderLine(Sesion.direccion)
    '                                    ticket.AddHeaderLine(Sesion.ciudad)
    '                                    If Not Sesion.telefono = "        " Then
    '                                        ticket.AddHeaderLine("Teléfono: " & Sesion.telefono)
    '                                    End If

    '                                    ticket.AddSubHeaderLine("Concepto: VALE")
    '                                    ticket.AddSubHeaderLine(it.NombreCliente)
    '                                    ticket.AddHeaderLine("Folio Vale# " & it.Folio)
    '                                    ticket.AddHeaderLine("Le atendió: " & Sesion.nombre_usuario)
    '                                    ticket.AddHeaderLine("Exped: " & it.Fecha)
    '                                    ticket.AddHeaderLine("Reimp: " & Date.Now)

    '                                    ticket.AddTotal("Monto Inicial", FormatCurrency(it.MontoInicial))
    '                                    ticket.AddTotal("Monto Actual", FormatCurrency(it.MontoActual))

    '                                    ticket.AddFooterLine("")
    '                                    ticket.AddFooterLine("***** " & Sesion.saludo & " *****")

    '                                    ticket.PrintTicket(Sesion.impresora)
    '                                Catch ex As Exception
    '                                    MsgBox(ex.Message)
    '                                End Try
    '                            End If
    '                        Next
    '                    End If
    '                End If
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    Else
    '        Dim frm As New frmCaja
    '        frm.ShowDialog()
    '    End If

    'End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not Sesion.id_caja = 0 Then
            If venta.Items.Count = 0 Then
                MsgBox("No hay productos seleccionados.")
                txtCodigo.Focus()
                Exit Sub
            End If
            Try
                Dim total As String = String.Format("{0:f2}", totalVenta)
                objFp = New FinalizarPago(total, 0, 0, 0, False)
                Dim frm As New frmFormaPago(objFp, False)
                frm.ShowDialog()

                If objFp.Pagado Then
                    vales = 0
                    tarjetas = 0
                    For Each i As Vales In frm.lista_vales
                        vales += i.MontoUsar
                    Next
                    For Each i As Tarjeta In frm.lista_tarjeta
                        tarjetas += i.Monto
                    Next


                    venta.ivaValor = Sesion.iva
                    fecha = Date.Now
                    guardarVenta(1, frm.efectivo, frm.lista_vales, frm.lista_tarjeta)
                    Dim id_cliente As Integer = venta.Id_cliente
                    If Sesion.imprimeTicket Then
                        Dim A = MsgBox("GUARDADO CORRECTAMENTE." & Chr(13) & Chr(13) & "Desea imprimir la nota de venta?." _
                                 , MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1)
                        If A = vbYes Then
                            doTicket2(Sesion.id_caja, venta.Id, "", fecha, cliente, 1)
                        Else
                            If Sesion.Abrir_Cajon Then
                                abreCajon()
                            End If
                            limpiar()
                            cargarFolio()
                            primerCliente(1)
                        End If
                    Else
                        MsgBox("GUARDADO CORRECTAMENTE.")
                        If Sesion.Abrir_Cajon Then
                            abreCajon()
                        End If

                        limpiar()
                        cargarFolio()
                        primerCliente(1)

                    End If
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
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim frm As New frmCaja
            frm.ShowDialog()
        End If

    End Sub

    'Private Sub doTicket(ByVal caja As Integer, ByVal no_ticket As Integer, ByVal concepto As String, ByVal fecha As Date, ByVal cliente As String, ByVal transaccion As Integer)
    '    Try
    '        Dim ticket As New BarControls.Ticket
    '        ticket.AddHeaderLine(Sesion.negocio)
    '        ticket.AddHeaderLine(Sesion.direccion)
    '        ticket.AddHeaderLine(Sesion.ciudad)
    '        If Not Sesion.telefono = "        " Then
    '            ticket.AddHeaderLine("Teléfono: " & Sesion.telefono)
    '        End If
    '        ticket.AddHeaderLine(concepto & "    " & fecha)
    '        ticket.AddSubHeaderLine("Le atendió: " & Sesion.nombre_usuario)
    '        ticket.AddSubHeaderLine("Folio " & no_ticket & "  " & cliente)

    '        Dim total As Double = 0.0
    '        Dim lista = From prod In venta.Items Group By prod.Cantidad, prod.Producto.Codigo, prod.Producto.Descripcion, prod.Producto.Precio Into productos = Group, Count()

    '        For Each items In venta.Items
    '            ticket.AddItem(items.Cantidad, IIf(items.Promocion = True, items.Producto.Descripcion.ToLower & "/prom", items.Producto.Descripcion.ToLower), FormatNumber(items.Producto.Precio, 2), FormatNumber(items.Total, 2))
    '            total += items.Producto.Precio * items.Cantidad
    '        Next
    '        ticket.AddTotal("*DESCT.", String.Format("{0:c}", descuentoTotal))
    '        ticket.AddTotal("TOTAL", String.Format("{0:c}", totalVenta))
    '        If transaccion = 1 Then
    '            ticket.AddTotal("EFECTIVO", String.Format("{0:c}", objFp.Efectivo))
    '            ticket.AddTotal("CAMBIO", String.Format("{0:c}", objFp.Cambio))
    '        ElseIf transaccion = 2 Then
    '            ticket.AddTotal("*Precios sujetos a cambio sin previo aviso.", "")
    '        ElseIf transaccion = 3 Then
    '            ticket.AddTotal("ABONO", String.Format("{0:c}", objFp.aUsar))
    '            ticket.AddTotal("SALDO", String.Format("{0:c}", total - objFp.aUsar))
    '        End If

    '        ticket.AddTotal("", "")
    '        ticket.AddFooterLine(Sesion.saludo)
    '        ticket.AddCode(no_ticket)
    '        ticket.PrintTicket(Sesion.impresora)

    '        limpiar()
    '        cargarFolio()
    '        primerCliente(1)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Private Sub doTicket(ByVal caja As Integer, ByVal no_ticket As Integer, ByVal concepto As String, ByVal fecha As Date, ByVal cliente As String, ByVal transaccion As Integer)
        Try
            Dim ticket As New BarControls.Ticket
            ticket.AddHeaderLine(Sesion.negocio)
            ticket.AddHeaderLine(Sesion.direccion)
            ticket.AddHeaderLine(Sesion.ciudad)
            If Not Sesion.telefono = "        " Then
                ticket.AddHeaderLine("Teléfono: " & Sesion.telefono)
            End If
            ticket.AddHeaderLine(concepto & "    " & fecha)
            ticket.AddSubHeaderLine("Atendió: " & Sesion.nombre_usuario)
            ticket.AddSubHeaderLine("Folio " & no_ticket & "  " & cliente)

            Dim total As Double = 0.0
            Dim lista = From prod In venta.Items Group By prod.Cantidad, prod.Producto.Codigo, prod.Producto.Descripcion, prod.Producto.Precio Into productos = Group, Count()

            For Each items In venta.Items
                ticket.AddItem(items.Cantidad, IIf(items.Promocion = True, items.Producto.Descripcion.ToLower & "/prom", items.Producto.Descripcion.ToLower), FormatNumber(items.Producto.Precio, 2), FormatNumber(items.Total, 2))
                total += items.Producto.Precio * items.Cantidad
            Next
            ticket.AddTotal("*DESCT.", String.Format("{0:c}", descuentoTotal))
            ticket.AddTotal("TOTAL", String.Format("{0:c}", totalVenta))
            If transaccion = 1 Then
                If vales <> 0 Then
                    ticket.AddTotal(" Vales", String.Format("{0:c}", vales))
                End If
                If tarjetas <> 0 Then
                    ticket.AddTotal(" Tarjeta", String.Format("{0:c}", tarjetas))
                End If

                ticket.AddTotal(" Efectivo", String.Format("{0:c}", objFp.Efectivo))
                ticket.AddTotal("CAMBIO", String.Format("{0:c}", objFp.Cambio))
            ElseIf transaccion = 2 Then
                ticket.AddTotal("*Precios sujetos a cambio sin previo aviso.", "")
            ElseIf transaccion = 3 Then
                ticket.AddTotal("ABONO", String.Format("{0:c}", objFp.aUsar))
                ticket.AddTotal("SALDO", String.Format("{0:c}", total - objFp.aUsar))
            End If

            ticket.AddTotal("", "")
            ticket.AddFooterLine(Sesion.saludo)
            ticket.AddCode(no_ticket)
            ticket.PrintTicket(Sesion.impresora)

            limpiar()
            cargarFolio()
            primerCliente(1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Class privada
        Private _cantidad As Double
        Private _desc As String
        Private _precio As Double
        Private _menudeo As String
        Private _total As Double
        Sub New()

        End Sub
        Public Property Total() As Double
            Get
                Return _total
            End Get
            Set(ByVal value As Double)
                _total = value
            End Set
        End Property
        Public Property Menudeo() As String
            Get
                Return _menudeo
            End Get
            Set(ByVal value As String)
                _menudeo = value
            End Set
        End Property
        Public Property Precio() As Double
            Get
                Return _precio
            End Get
            Set(ByVal value As Double)
                _precio = value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return _desc
            End Get
            Set(ByVal value As String)
                _desc = value
            End Set
        End Property
        Public Property Cantidad() As Double
            Get
                Return _cantidad
            End Get
            Set(ByVal value As Double)
                _cantidad = value
            End Set
        End Property
    End Class
    Private Sub doTicket2(ByVal caja As Integer, ByVal no_ticket As Integer, ByVal concepto As String, ByVal fecha As Date, ByVal cliente As Cliente, ByVal transaccion As Integer)
        Try


            Dim rep As New Report

            rep.Load("Reportes\nota.mrp")

            Dim lista As New List(Of privada)
            For Each items In venta.Items
                Dim it As New privada
                it.Cantidad = items.Cantidad
                it.Descripcion = IIf(items.Promocion = True, items.Producto.Descripcion & "/" & items.Producto.Piezas & "/prom", items.Producto.Descripcion & "/" & items.Producto.Piezas)
                it.Precio = items.Producto.Precio
                If chkMenudeo.Checked = True Then
                    it.Menudeo = String.Format("{0:c}", items.Producto.Precio_Menudeo)
                Else
                    it.Menudeo = ""
                End If

                it.Total = items.Total
                lista.Add(it)
            Next

            rep.DataSource = lista


            Dim dic As New Dictionary(Of String, Object)
            dic.Add("codigo", "*" & no_ticket & "*")
            dic.Add("NoTicket", no_ticket & " " & concepto)
            dic.Add("Saludo", Sesion.saludo)
            dic.Add("fecha", Utils.obtenerFechaFormatoExtendido(fecha.Date))

            dic.Add("Negocio", Sesion.negocio)
            dic.Add("Direccion", Sesion.direccion)
            dic.Add("concepto", concepto)

            dic.Add("Ciudad", Sesion.ciudad)
            dic.Add("Telefono", Sesion.telefono)


            dic.Add("Usuario", Sesion.nombre_usuario)
            dic.Add("Cliente", cliente.Razon)

            dic.Add("Total", String.Format("{0:C}", totalVenta).ToString)
            If Not descuentoTotal = 0 Then
                dic.Add("Descuento", String.Format("{0:C}", descuentoTotal).ToString)
                dic.Add("DescuentoText", "Descuento")
            End If

            dic.Add("DirCliente", cliente.Calle & ", " & IIf(cliente.Num_ext = "", "", "# " & cliente.Num_ext) & IIf(cliente.Num_int = "", "", " Int. " & cliente.Num_int) & ", " & cliente.Colonia & IIf(cliente.CP = "", "", " CP " & cliente.CP) & ", " & cliente.Ciudad & ", " & cliente.NombreEstado.ToUpper)
            dic.Add("totalTexto", lblTotal.Text)
            Dim file As String = My.Computer.FileSystem.GetTempFileName

            rep.ExportToPdf(file & ".pdf", dic)
            lista = Nothing
            System.Diagnostics.Process.Start(file & ".pdf")

            limpiar()
            cargarFolio()
            primerCliente(1)
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
    Private Sub guardarVenta(ByVal transaccion As Integer, ByVal efectivo As Decimal, Optional ByVal listaVales As List(Of Vales) = Nothing, Optional ByVal listaTarj As List(Of Tarjeta) = Nothing)
        Try
            venta.Id_cliente = cliente.Id
            venta.Id_usuario = Sesion.id_usuario_sesion
            venta.Fecha = fecha
            venta.Subtotal = subtotalVenta - IvaVenta
            venta.Descuento = descuentoTotal
            venta.Iva = IvaVenta
            venta.Total = subtotalVenta
            venta.Total_texto = lblTotal.Text

            If transaccion = 1 Then
                Dim sv As New Service_Venta
                folio = sv.GuardarVenta(venta, Sesion.id_caja, efectivo, listaVales, listaTarj)
                sv = Nothing
            ElseIf transaccion = 2 Then
                Dim sc As New Service_cotizacion
                sc.GuardarCotizacion(venta)
                sc = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvp_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvp.CellValidating
        Select Case dgvp.Columns(e.ColumnIndex).Index
            Case 3
                If Not IsNumeric(e.FormattedValue.ToString()) And Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvp.Rows(e.RowIndex).ErrorText = "La Cantidad debe ser un valor numérico"
                    e.Cancel = True
                ElseIf String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvp.Rows(e.RowIndex).ErrorText = "La Cantidad no puede estar vacía"
                    e.Cancel = True
                Else
                    dgvp.Rows(e.RowIndex).ErrorText = String.Empty
                End If
            Case 7
                If Not IsNumeric(e.FormattedValue.ToString()) And Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvp.Rows(e.RowIndex).ErrorText = "El descuento $ debe ser un valor numérico"
                    e.Cancel = True
                ElseIf String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvp.Rows(e.RowIndex).ErrorText = "El descuento $no puede estar vacío"
                    e.Cancel = True
                Else
                    dgvp.Rows(e.RowIndex).ErrorText = String.Empty
                End If
            Case Else

        End Select
    End Sub
    Private Sub dgvp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvp.KeyDown
        If e.KeyCode = 46 Then
            Dim del As String = dgvp.CurrentRow.Cells(0).Value
            Dim codigo As String = dgvp.CurrentRow.Cells(1).Value
            Dim listas As New List(Of Integer)
            Try
                For Each it As VentaItem In venta.Items
                    If it.TipoPromocion = "Pieza" Then
                        'If it.Promocion And it.Producto.Codigo = codigo Then
                        '    listas.Add(it.Id)
                        '    Exit For
                        'ElseIf it.Producto.Codigo = codigo And it.Id = del Then
                        '    listas.Add(it.Id)
                        'End If
                        If it.Promocion And it.Producto.Codigo = codigo Then
                            listas.Add(it.Id)
                            Exit For
                        ElseIf it.Producto.Codigo = codigo And it.Id = del Then
                            listas.Add(it.Id)
                            For Each i As VentaItem In venta.Items
                                If i.TipoPromocion = "Pieza" And i.Promocion And i.Producto.Codigo = it.Relacion Then
                                    listas.Add(i.Id)
                                    Exit For
                                End If
                            Next
                        End If

                    ElseIf it.TipoPromocion = "Descuento" And it.Id = del Then
                        listas.Add(it.Id)
                    ElseIf it.TipoPromocion = "Ninguna" And it.Id = del Then
                        listas.Add(del)
                    ElseIf it.Id = del Then


                        listas.Add(del)
                    End If
                Next

                For Each i As Integer In listas
                    venta.BorraItem(i.ToString)
                Next
                ActualizarGrid()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub txtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuento.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnAplicarDesc.PerformClick()
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
    Private Sub btnCancelarDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarDesc.Click
        Try
            venta.UpdateItem(0)
            txtDescuento.Text = 0
            ActualizarGrid()
            btnCancelarDesc.Enabled = False
            btnAgregar.Enabled = True
            btnAplicarDesc.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvp_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvp.CellEndEdit
        Try
            Select Case dgvp.Columns(e.ColumnIndex).Index
                Case 3
                    venta.venderSinExistencia = Sesion.venderSinExis
                    If dgvp.RowCount > 0 Then
                        If Not venta.venderSinExistencia Then
                            If Not dgvp.CurrentRow.Cells(3).Value > dgvp.CurrentRow.Cells(9).Value Then
                                venta.UpdateCantidad(dgvp.CurrentRow.Cells(3).Value, dgvp.CurrentRow.Cells(0).Value)
                                ActualizarGrid()
                            Else
                                MsgBox("EXISTENCIAS INSUFICIENTES!!!" & Chr(13) & Chr(13) & dgvp.CurrentRow.Cells(2).Value.ToString.ToUpper & Chr(13) & Chr(13) & "EXISTENCIA     " & dgvp.CurrentRow.Cells(9).Value)
                                ActualizarGrid()
                            End If
                        Else
                            venta.UpdateCantidad(dgvp.CurrentRow.Cells(3).Value, dgvp.CurrentRow.Cells(0).Value)
                            ActualizarGrid()
                        End If
                    End If

                Case 7
                    ''cell edit descuento
                    If dgvp.RowCount > 0 Then
                        If Not dgvp.CurrentRow.Cells(7).Value > dgvp.CurrentRow.Cells(4).Value Then
                            Dim price As Decimal = dgvp.CurrentRow.Cells(4).Value
                            Dim price_desc As Decimal = dgvp.CurrentRow.Cells(7).Value
                            Dim precioFinal As Decimal = price - price_desc
                            Dim CalcDescuento As Decimal = 100 - (precioFinal * 100 / price)
                            venta.UpdateItem2(CalcDescuento, dgvp.CurrentRow.Cells(0).Value)
                            ActualizarGrid()
                        End If
                    End If
                Case Else
            End Select

        Catch ex As Exception
            If Err.Number = 5 Then
                ActualizarGrid()
                Exit Try
            Else
                MsgBox(ex.Message)
                ActualizarGrid()
            End If

        End Try

    End Sub
    Private Sub descuentos()
        If Not producto.Rango = 0 Then
            If IIf(txtCantidad.Text = "", 1, txtCantidad.Text) >= producto.Rango Then
                descuento = producto.Descuento
                lblDescProd.Text = descuento

            ElseIf cliente.Descuento = 1 Then
                descuento = producto.Descuento_1
                lblDescProd.Text = descuento
            ElseIf cliente.Descuento = 2 Then
                descuento = producto.Descuento_2
                lblDescProd.Text = descuento
            End If
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
    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If txtCantidad.Text.Length > 0 Then
            If Not producto Is Nothing Then
                descuentos()
            End If
        End If
    End Sub
    Private Sub btnObtenerCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerCotizacion.Click
        Try
            Dim IntNum2 As String = InputBox("No. de Cotizacion:" & Chr(13), "BUSCAR COTIZACION")

            If Not IntNum2 = "" Then
                Dim sc As New Service_cotizacion
                venta = New Venta
                venta = sc.Obtener(CInt(IntNum2))

                ActualizarGrid()
                txtFolioCliente.Text = venta.Id_cliente
                txtFolioCliente.Select()
                txtFolioCliente.Focus()
                SendKeys.Send("{ENTER}")

                btnCotizacion.Enabled = False

            End If
        Catch ex As Exception
            If Err.Number = 13 Then
                MsgBox("No existe la cotizacion.")
            Else
                MsgBox(ex.Message)
            End If

        End Try
    End Sub
    Private Sub txtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If txtFolio.Text.Length <> 0 Then
                btnObtenerCotizacion.PerformClick()
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
    Private Sub btnCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCredito.Click
        Try
            If venta.Items.Count > 0 Then
                If cliente.CreditoActivo And (cliente.Saldo + subtotalVenta) <= cliente.Limite Then
                    venta.credito = True
                    venta.id_credito = cliente.Id_credito

                    objFp = New FinalizarPago(totalVenta, 0, 0, 0, False)
                    Dim frm As New frmFormaPago(objFp, False, True)
                    frm.ShowDialog()


                    If objFp.Pagado Then
                        venta.ivaValor = Sesion.iva
                        fecha = Date.Now
                        venta.credito = True
                        venta.abono = objFp.aUsar

                        guardarVenta(1, frm.efectivo, frm.lista_vales, frm.lista_tarjeta)

                        MsgBox("Guardado Correctamente.")
                        If Sesion.imprimeTicket Then
                            doTicket2(Sesion.id_caja, venta.Id, "CR", fecha, cliente, 3)
                        Else
                            If Sesion.Abrir_Cajon Then
                                abreCajon()
                            End If
                            limpiar()
                            cargarFolio()
                            primerCliente(1)

                        End If

                    End If

                Else
                    Throw New Exception("LIMITE DE CREDITO EXEDIDO!!!." & Chr(13) & Chr(13) & "Limite de Credito: " & String.Format("{0:c}", cliente.Limite) & Chr(13) & Chr(13) & "Credito Disponible " & String.Format("{0:c}", cliente.Limite - cliente.Saldo))
                End If
            Else
                Throw New Exception("No hay productos seleccionados.")
                txtCodigo.Focus()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Not venta Is Nothing Then
            If venta.Items.Count > 0 Then
                Dim a = MsgBox("La venta actual se cerrará y los datos se perderán." & "¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
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
    Private Sub frmCompra_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 150 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    Private Sub ImageButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicarDesc.Click
        Try
            If txtDescuento.Text.Length > 0 And Not txtDescuento.Text = "." Then
                If dgvp.RowCount > 0 Then
                    If txtDescuento.Text < Sesion.porcetaje Then
                        Dim A = MsgBox("Desea aplicar el " & txtDescuento.Text & " % de descuento a esta venta?" & Chr(13) & "Nota: los descuentos aplicados a cada producto seran eliminados." _
                                 , MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                        If A = vbYes Then
                            venta.UpdateItem(txtDescuento.Text)
                            ActualizarGrid()
                            btnCancelarDesc.Enabled = True
                            btnAgregar.Enabled = False
                            btnAplicarDesc.Enabled = False
                        End If
                    Else
                        txtDescuento.Select()
                        txtDescuento.Focus()
                        Throw New Exception("Descuento inválido.")
                    End If
                Else
                    MsgBox("No hay productos seleccionados")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCotizacion.Click
        Try
            If venta.Items.Count = 0 Then
                MsgBox("No hay productos seleccionados.")
                txtCodigo.Focus()
                Exit Sub
            End If
            fecha = Date.Now
            guardarVenta(2, 0, Nothing, Nothing)
            MsgBox("Guardado Correctamente." & Chr(13) & "Folio " & venta.Id)
            If Sesion.imprimeTicket Then
                ' doTicket(Sesion.id_caja, venta.Id, "COTIZACIÓN", fecha, cliente.Razon, 2)
                doTicket2(Sesion.id_caja, venta.Id, "CO", fecha, cliente, 2)
            Else
                If Sesion.Abrir_Cajon Then
                    abreCajon()
                End If
                limpiar()
                cargarFolio()
                primerCliente(1)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub chkConsultar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsultar.CheckedChanged
        Dim valor As Boolean = False
        If chkConsultar.Checked = True Then
            valor = True
        End If
        lbl1.Visible = valor
        lbl2.Visible = valor
        lbl3.Visible = valor
        lbl4.Visible = valor
        lblExistencia.Visible = valor
        lblPrecio.Visible = valor
        lblRango.Visible = valor
        lblDescProd.Visible = valor
        lblProducto.Visible = valor

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax.Click
        If maximizado Then
            Me.Width = meWidht
            Me.Height = meheigth
            'Me.Left = x
            'Me.Top = y
            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
            Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2

            For Each obj In Me.Controls
                If obj Is btnMin Or obj Is btnClose Or obj Is btnMax Then
                    obj.Size = New System.Drawing.Size((obj.Width * 100 / porcentajeX), obj.Height * 100 / porcentajeY)
                    obj.Location = New System.Drawing.Point((obj.Location.X * 100 / (Screen.PrimaryScreen.WorkingArea.Width * 100 / meWidht)), (obj.Location.Y * 100 / porcentajeY))

                ElseIf obj Is dgvp Or obj Is Label5 Or obj Is Label6 Or obj Is Label7 Or obj Is Label8 Or obj Is txtDescuento Or obj Is txtDesc Or obj Is txtSubtotal Or obj Is btnAplicarDesc Or obj Is btnCancelarDesc Or obj Is btnNuevo Or obj Is btnCotizacion Or obj Is btnCredito Or obj Is btnGuardar Then
                    If obj Is Label7 Or obj Is Label5 Then
                        obj.Font = New System.Drawing.Font("Arial", obj.font.size * 100 / porcentajeReal, FontStyle.Bold)
                    Else
                        obj.Font = New System.Drawing.Font("Arial", obj.font.size * 100 / porcentajeReal)
                    End If
                    'obj.Font = New System.drawing.font("Arial", (meheigth) * obj.Font.Size / (Screen.PrimaryScreen.WorkingArea.Height))
                    obj.Size = New System.Drawing.Size(obj.Width * 100 / porcentajeReal, obj.Height * 100 / porcentajeY)
                    obj.Location = New System.Drawing.Point(obj.Location.X * 100 / porcentajeReal, (obj.Location.Y * 100 / porcentajeY))
                Else
                    If obj Is lblProducto Or obj Is lblExistencia Or obj Is lblDescProd Or obj Is lblPrecio Or obj Is lblRango Then
                        obj.Font = New System.Drawing.Font("Arial", obj.font.size * 100 / porcentajeX, FontStyle.Bold)
                    Else
                        obj.Font = New System.Drawing.Font("Arial", obj.font.size * 100 / porcentajeX)
                    End If
                    'obj.Font = New System.drawing.font("Arial", (meheigth) * obj.Font.Size / (Screen.PrimaryScreen.WorkingArea.Height))
                    obj.Size = New System.Drawing.Size(obj.Width * 100 / porcentajeX, obj.Height * 100 / porcentajeY)
                    obj.Location = New System.Drawing.Point(obj.Location.X * 100 / porcentajeX, (obj.Location.Y * 100 / porcentajeY))

                End If
            Next
            'Web1.Visible = False
            imagen.Visible = False
            maximizado = False

            Dim fuente As New System.Drawing.Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel, 4)
            dgvp.Font = fuente
            dgvp.Columns(0).Width = 70
            dgvp.Columns(1).Width = 90
            dgvp.Columns(2).Width = 250
            dgvp.Columns(3).Width = 70
            dgvp.Columns(4).Width = 75
            dgvp.Columns(5).Width = 75
            dgvp.Columns(6).Width = 75
            dgvp.Columns(7).Width = 75
            dgvp.Columns(8).Width = 95

            Timer1.Stop()
            Panel1.Visible = False
        Else ''maximizado

            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            Me.Size = Screen.PrimaryScreen.WorkingArea.Size

            setPromociones()
            If lista.Count > 0 Then ''si hay promociones se muestra el panel
                Timer1.Interval = 5000
                Timer1.Start()
                aux += 1
                Panel1.Visible = True
                porcentajeReal = (Screen.PrimaryScreen.WorkingArea.Width - promocionesX) * 100 / meWidht
            Else
                porcentajeReal = (Screen.PrimaryScreen.WorkingArea.Width) * 100 / meWidht
            End If

            For Each obj In Me.Controls
                If obj Is btnMin Or obj Is btnClose Or obj Is btnMax Then ''botenes de min, max y cerrar
                    obj.Size = New System.Drawing.Size((obj.Width * porcentajeX / 100), obj.Height * porcentajeY / 100)
                    obj.Location = New System.Drawing.Point((obj.Location.X * (Screen.PrimaryScreen.WorkingArea.Width * 100 / meWidht) / 100), (obj.Location.Y * porcentajeY / 100))
                ElseIf obj Is imagen Or obj Is Panel1 Or obj Is Label13 Or obj Is Label14 Or obj Is Label15 Or obj Is Label16 Or obj Is Label17 Or obj Is Label4 Or obj Is Label12 Then 'imagen y panel de promociones
                    'obj.Font = New System.drawing.font("Arial", obj.font.size * porcentajeX / 100, FontStyle.Strikeout)
                    obj.Size = New System.Drawing.Size(promocionesX, obj.Height * porcentajeY / 100)
                    obj.Location = New System.Drawing.Point(obj.Location.X * porcentajeX / 100, (obj.Location.Y * porcentajeY / 100))

                ElseIf obj Is dgvp Or obj Is Label5 Or obj Is Label6 Or obj Is Label7 Or obj Is Label8 Or obj Is txtDescuento Or obj Is txtDesc Or obj Is txtSubtotal Or obj Is btnAplicarDesc Or obj Is btnCancelarDesc Or obj Is btnNuevo Or obj Is btnCotizacion Or obj Is btnCredito Or obj Is btnGuardar Then ''objetos que crecen en toda la pantalla si no hay promociones
                    If obj Is Label7 Or obj Is Label5 Then
                        obj.Font = New System.Drawing.Font("Arial", obj.font.size * porcentajeReal / 100, FontStyle.Bold)
                    Else
                        obj.Font = New System.Drawing.Font("Arial", obj.font.size * porcentajeReal / 100)
                    End If
                    ' obj.Font = New System.drawing.font("Arial", obj.font.size * porcentajeReal / 100)
                    obj.Size = New System.Drawing.Size(obj.Width * porcentajeReal / 100, obj.Height * porcentajeY / 100)
                    obj.Location = New System.Drawing.Point(obj.Location.X * porcentajeReal / 100, (obj.Location.Y * porcentajeY / 100))
                Else ''restos de los objetos que crecen hasta antes de la imagen

                    If obj Is lblProducto Or obj Is lblExistencia Or obj Is lblDescProd Or obj Is lblPrecio Or obj Is lblRango Then
                        obj.Font = New System.Drawing.Font("Arial", obj.font.size * porcentajeX / 100, FontStyle.Bold)
                    Else
                        obj.Font = New System.Drawing.Font("Arial", obj.font.size * porcentajeX / 100)
                    End If

                    'obj.Font = New System.drawing.font("Arial", obj.font.size * porcentajeX / 100)
                    obj.Size = New System.Drawing.Size(obj.Width * porcentajeX / 100, obj.Height * porcentajeY / 100)
                    obj.Location = New System.Drawing.Point(obj.Location.X * porcentajeX / 100, (obj.Location.Y * porcentajeY / 100))
                End If
            Next

            dgvp.Columns(0).Width = dgvp.Columns(0).Width * porcentajeReal / 100
            dgvp.Columns(1).Width = dgvp.Columns(1).Width * porcentajeReal / 100
            dgvp.Columns(2).Width = dgvp.Columns(2).Width * porcentajeReal / 100
            dgvp.Columns(3).Width = dgvp.Columns(3).Width * porcentajeReal / 100
            dgvp.Columns(4).Width = dgvp.Columns(4).Width * porcentajeReal / 100
            dgvp.Columns(5).Width = dgvp.Columns(5).Width * porcentajeReal / 100
            dgvp.Columns(6).Width = dgvp.Columns(6).Width * porcentajeReal / 100
            dgvp.Columns(7).Width = dgvp.Columns(7).Width * porcentajeReal / 100
            dgvp.Columns(8).Width = dgvp.Columns(8).Width * porcentajeReal / 100

            maximizado = True
            imagen.Visible = True
            Try
                imagen.Image = Image.FromFile(Sesion.imagen)
            Catch ex As Exception
                Exit Try
            End Try


            Label13.Text = ""
            Label14.Text = ""
            Label15.Text = ""
            Label16.Text = ""
            Label17.Text = ""
            Label4.Text = ""
            Label12.Text = ""


        End If
        txtCodigo.Select()
        txtCodigo.Focus()
    End Sub
    Private Sub setPromociones()
        Dim id As Integer = 0
        Dim cadenahtml As String = ""
        Dim sPromos As New opPromociones(1)
        If Not sPromos Is Nothing AndAlso sPromos.Promociones.Count > 0 Then
            tot = sPromos.Promociones.Count
            For Each iten In sPromos.Promociones
                cadenahtml = "En la compra de " & Chr(13) & iten.Cantidad & " " & iten.Descripcion & " " & iten.Producto.Precio & Chr(13) & " obten " & iten.Descuento & "% de descuento. " & Chr(13) & Chr(13)
                id += 1
                Dim linea As New VerPromociones(id, iten.Cantidad, iten.Descripcion, iten.Producto.Precio, iten.Descuento, "", True)
                lista.Add(linea)
            Next
        End If
        Dim sPromos2 As New opPromocionesPieza(1)
        If Not sPromos2 Is Nothing AndAlso sPromos2.Promociones.Count > 0 Then
            tot = tot + sPromos2.Promociones.Count
            For Each iten In sPromos2.Promociones
                cadenahtml = "En la compra de " & Chr(13) & iten.Cantidad & " " & iten.Descripcion & " " & iten.Producto.Precio & Chr(13) & " Te llevas " & Chr(13) & iten.CantidadRegalada & iten.ProductoRegalo.Descripcion & " Gratis." & Chr(13) & Chr(13)
                id += 1
                Dim linea As New VerPromociones(id, iten.Cantidad, iten.Descripcion, iten.Producto.Precio, iten.CantidadRegalada, iten.DescripcionRegalo, False)
                lista.Add(linea)
            Next
        End If
        tot += 1

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lista.Count > 0 Then
            Label12.Text = "En la Compra de:"

            For Each it As VerPromociones In lista
                If it.Id = aux Then
                    Label16.Text = it.Cant & " "
                    Label17.Text = it.Desc.ToUpper & " "
                    If it.Tipo Then
                        Label15.Text = String.Format("{0:c}", it.Precio)
                        Label4.Text = "Obten"
                        Label14.Text = it.Cant2 & "  % de Descuento."
                        Label13.Text = ""
                    Else
                        Label15.Text = String.Format("{0:c}", it.Precio)
                        Label4.Text = "Llevate Gratis"
                        Label14.Text = it.Cant2
                        Label13.Text = it.Desc2.ToUpper
                    End If
                    Exit For
                End If
            Next

            If aux = tot Then
                aux = 1
                Label13.Text = ""
                Label14.Text = ""
                Label15.Text = ""
                Label16.Text = ""
                Label17.Text = ""
                Label4.Text = ""
                Label12.Text = ""
            Else
                aux += 1
            End If
        Else
            Label12.Text = "NO HAY PROMOCIONES."
        End If
    End Sub

End Class