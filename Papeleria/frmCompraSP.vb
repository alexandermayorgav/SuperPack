Imports LogicaNegocio
Public Class frmCompraSP
    Private compra As CCompras
    Private item As CCompraDetalle
    Private producto As Producto
    Private SProductos As Service_Producto
    Private listaprod As New List(Of Producto)
    Private listaTodosProd As New List(Of Producto)
    Private provee As Proveedor
    Private compraservice As Service_Compra
    Private subtotal As Decimal
    Private totalVenta As Decimal
    Private descuentoTotal As Decimal
    Public esCompraNueva As Boolean = True
    Public esVerCompra As Boolean = False
    Private precio As Decimal
    Private costo As Decimal
    Private precioMenudeo As Decimal
    Private esdeproveedorprod As Boolean = False
    Private Sub frmCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NuevaCompra()
        Me.KeyPreview = True
    End Sub
    Private Sub frmCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                btnClose.PerformClick()
            Case Keys.F2
                btnbuscarproveedor.PerformClick()
            Case Keys.F3
                btnbuscarprod.PerformClick()
            Case Keys.F5
                btnFinalizar.PerformClick()
            Case Keys.F6
                btnvercompra.PerformClick()
            Case Keys.F7
                btnNueva.PerformClick()
            Case Keys.F9
                btnagregar.PerformClick()
        End Select
    End Sub
    Private Sub btnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueva.Click
        NuevaCompra()
        txtfolio.Text = ""
    End Sub
    Sub NuevaCompra()
        Try
            compra = New CCompras
            item = New CCompraDetalle
            producto = New Producto
            listaprod = New List(Of Producto)
            listaTodosProd = New List(Of Producto)

            txtproveedor.Text = ""
            txtnombreproveedor.Text = ""
            txtdescripcionprod.Text = ""
            txtcodigo.Text = ""
            lblExistencia.Text = ""
            txtcantidad.Text = ""
            txtcosto.Text = ""
            txtprecio.Text = ""
            DGVcompra.Rows.Clear()
            txtSubtotal.Text = "$0.00"
            txtDescuento.Text = "$0.00"
            txtiva.Text = "$0.00"
            txtletras.Text = "CERO PESOS 00/100 MN"
            txtTotal.Text = "$0.00"
            txtdesc.Text = ""
            ChkCredito.Checked = False
            esCompraNueva = True
            esVerCompra = False
            btnFinalizar.Enabled = True
            btnbuscarproveedor.Enabled = True
            btnbuscarprod.Enabled = True
            btnagregar.Enabled = True
            ChkCredito.Enabled = True
            DGVcompra.Enabled = True
            txtproveedor.Enabled = True
            txtcosto.Enabled = True
            txtprecio.Enabled = True
            txtcantidad.Enabled = True
            txtdesc.Enabled = True
            txtcodigo.Enabled = True
            txtproveedor.Select()
            txtproveedor.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        AgregarProducto()
    End Sub
    Sub AgregarProducto()

        If provee Is Nothing Then
            MsgBox("No hay proveedor seleccionado")
            txtcodigo.Text = ""
            txtproveedor.Focus()
            Exit Sub
        End If

        If txtdescripcionprod.Text = "" Then
            MsgBox("Seleccione un producto")
            txtcodigo.Focus()
            Exit Sub
        End If

        If txtcosto.Text.Length = 0 Then
            MsgBox("Falta capturar costo del producto")
            txtcosto.Focus()
            Exit Sub
        ElseIf Not IsNumeric(txtcosto.Text) Then
            MsgBox("Campo costo debe contener solo números")
            txtcosto.Focus()
            Exit Sub
        End If

        If txtprecio.Text.Length = 0 Then
            MsgBox("Falta capturar precio del producto")
            txtprecio.Focus()
            Exit Sub
        End If

        If txtcantidad.Text = "" Then
            MsgBox("Falta cantidad del producto")
            txtcantidad.Text = ""
            txtcantidad.Focus()
            Exit Sub
        End If

        If txtdesc.Text.Length = 0 Then
            txtdesc.Text = 0
        ElseIf CInt(txtdesc.Text) > 100 Then
            MsgBox("El descuento no debe sobrepasar el 100%")
            txtdesc.Focus()
            Exit Sub
        End If

        producto.Precio_Menudeo = txtpreciomenudeo.Text
        item = New CCompraDetalle(producto, txtcantidad.Text, txtcosto.Text, txtdesc.Text, txtprecio.Text, Sesion.iva, txtpreciomenudeo.Text, 0)
        '      item.PrecioMenudeo = txtpreciomenudeo.Text
        compra.AgregarItem(item)

        ActualizarGrid()

        txtdescripcionprod.Text = ""
        txtcodigo.Text = ""
        lblExistencia.Text = ""
        txtcantidad.Text = ""
        txtcosto.Text = ""
        txtprecio.Text = ""
        txtpreciomenudeo.Text = ""
        txtcodigo.Focus()
        BuscarProductosHijos(item.Producto.Id)
        listaTodosProd.AddRange(listaprod)
    End Sub
    Private Sub ActualizarGrid()

        Dim R As Short = 0
        Dim iva As Decimal
        Dim ivaPorProd As Decimal
        Dim importe As Decimal
        Dim tieneiva As Boolean = False
        Dim TotalIVA As Decimal = 0
        Try

        
            DGVcompra.Rows.Clear()

            For Each item As CCompraDetalle In compra._compraitems

                tieneiva = item.Producto.Iva

                If esVerCompra = False Then

                    importe = (item.Cantidad * item.Costo) - item.DescuentoD

                    If tieneiva = True Then
                        TotalIVA = importe * (1 + (Sesion.iva / 100))
                        iva += TotalIVA - importe
                        ivaPorProd = TotalIVA - importe
                    End If
                Else
                    importe = item.Importe
                    'Calcula el descuento en dinero
                    item.DescuentoD = compra.DescuentoDinero(item.DescuentoP, item.Cantidad, item.Costo)
                    If tieneiva = True Then
                        TotalIVA = importe * (1 + (item.IVA / 100))
                        iva += TotalIVA - importe
                        ivaPorProd = TotalIVA - importe
                    End If
                End If

                With DGVcompra
                    .Rows.Add()
                    R = .RowCount - 1

                    If item.Producto.ProductoActualizado Then
                        DGVcompra.Rows(R).DefaultCellStyle.BackColor = Color.LightSteelBlue
                    End If

                    If item.Producto.ActualizarCodigosHermanos Then
                        DGVcompra.Rows(R).Cells(10).Value = True
                    End If

                    .Rows(R).Cells("Codigo").Value = item.Producto.Codigo
                    .Rows(R).Cells("Descripcion").Value = item.Producto.Descripcion
                    .Rows(R).Cells("Cantidad").Value = item.Cantidad
                    .Rows(R).Cells("CostoU").Value = item.Costo
                    .Rows(R).Cells("price").Value = item.Precio
                    .Rows(R).Cells("DescuentoPorcentaje").Value = item.DescuentoP
                    .Rows(R).Cells("DescuentoDinero").Value = item.DescuentoD
                    .Rows(R).Cells("IVA").Value = ivaPorProd
                    .Rows(R).Cells("Importe").Value = importe
                    .Rows(R).Cells("idp").Value = item.Producto.Id
                    .Rows(R).Cells("piezas").Value = item.Producto.Piezas
                    .Rows(R).Cells("MenudeoPrecio").Value = item.Producto.Precio_Menudeo
                End With
            Next

            Dim renglo As Integer = DGVcompra.RowCount - 1

            If Not renglo <= 0 Then
                DGVcompra.FirstDisplayedScrollingRowIndex = DGVcompra.Rows(renglo).Index
            End If
            DGVcompra.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVcompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVcompra.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGVcompra.Columns(3).DefaultCellStyle.Format = "c"

            DGVcompra.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGVcompra.Columns(4).DefaultCellStyle.Format = "c"

            DGVcompra.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVcompra.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGVcompra.Columns(6).DefaultCellStyle.Format = "c"

            DGVcompra.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGVcompra.Columns(7).DefaultCellStyle.Format = "c"
            DGVcompra.Columns(8).DefaultCellStyle.Format = "c"
            DGVcompra.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            If esVerCompra = True Then
                iva = compra.IVA
            End If

            subtotal = compra.Totalf
            descuentoTotal = compra.Desc
            totalVenta = subtotal
            Dim stot As Decimal = subtotal - descuentoTotal
            txtSubtotal.Text = String.Format("{0:c}", stot)
            txtDescuento.Text = String.Format("{0:c}", descuentoTotal)

            txtiva.Text = String.Format("{0:c}", iva)

            Dim Tot As Decimal

            Tot = stot + String.Format("{0:c}", iva)
            txtTotal.Text = String.Format("{0:c}", Tot)

            ''Dim st As String = String.Format("{0:n}", Tot)
            Dim st As String = String.Format("{0:n}", stot)
            Dim total() As String

            total = Split(st, ".")

            txtletras.Text = Utils.Num2Text(total(0)) & " PESOS " & total(1) & "/100 MN"
            compra.TotalLetras = txtletras.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnbuscarprod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscarprod.Click
        BuscarProducto()
    End Sub
    Sub BuscarProducto()
        Try
            Dim formProd As New frmBuscarProducto
            formProd.ShowDialog()
            txtcodigo.Text = formProd.codigo
            txtcodigo.Focus()
            SendKeys.Send("{ENTER}")
            formProd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtcodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If Not provee Is Nothing Then
                compra.Proveedor = provee.IdProveedor
            Else
                MsgBox("No hay proveedor seleccionado")
                txtcodigo.Text = ""
                txtproveedor.Focus()
                Exit Sub
            End If
            If txtcodigo.Text.Length > 0 Then
                EncontrarProducto(txtcodigo.Text.Trim)
            End If
        End If
    End Sub
    Sub EncontrarProducto(ByVal codigo As String)
        Try
            Dim prod As New Service_Producto
            compraservice = New Service_Compra
            producto = New Producto
            producto = prod.Obtener(codigo)
            esdeproveedorprod = compraservice.ObtenerProductoProveedor(producto.Id, txtproveedor.Text.Trim)
            If esdeproveedorprod = True Then
                txtdescripcionprod.Text = producto.Descripcion
                lblExistencia.Text = producto.Existencia
                txtcantidad.Focus()
                txtcosto.Text = String.Format("{0:n}", producto.Costo)
                txtprecio.Text = String.Format("{0:n}", producto.Precio)
                txtpreciomenudeo.Text = String.Format("{0:n}", producto.Precio_Menudeo)
            End If
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnbuscarproveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscarproveedor.Click
        BuscarProveedor()
    End Sub
    Private Sub BuscarProveedor()
        Try
            Dim form As New frmBuscarProveedor
            form.ShowDialog()
            If form._id_proveedor > 0 Then
                txtproveedor.Text = form._id_proveedor
            End If
            txtproveedor.Focus()
            SendKeys.Send("{ENTER}")
            form.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtproveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtproveedor.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If txtproveedor.Text.Length < 1 Then
                MsgBox("Campo folio de proveedor no debe ser vacio")
                txtproveedor.Focus()
            ElseIf Not IsNumeric(txtproveedor.Text) Then
                MsgBox("Campo folio de proveedor debe contener solo números")
                txtproveedor.Text = ""
                txtproveedor.Focus()
            Else
                EncontrarProveedor(txtproveedor.Text.Trim)
            End If
        End If
    End Sub
    Public Sub EncontrarProveedor(ByVal idprov As Integer)
        Try
            Dim prov As New Service_Proveedor
            provee = New Proveedor
            provee = prov.ObtenerProveedor(idprov)
            txtnombreproveedor.Text = provee.RazonSocial
            txtcodigo.Focus()

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        ProcesarCompra()
        esVerCompra = False
    End Sub
    Sub ProcesarCompra()
        Try
            compraservice = New Service_Compra

            If Not esCompraNueva Then
                MsgBox("Esta compra ya se guardo")
                Exit Sub
            End If

            If compra._compraitems.Count = 0 Then
                MsgBox("No hay productos en la compra")
                Exit Sub
            End If

            compra.Usuario = Sesion.id_usuario_sesion
            compra.TotalLetras = txtletras.Text
            compra.SubT = txtSubtotal.Text
            compra.Fecha = DTPfechacompra.Value
            compra.Descuento = txtDescuento.Text
            compra.IVA = txtiva.Text
            ''compra.Total = txtTotal.Text
            compra.Total = txtSubtotal.Text
            compra.TotalLetras = txtletras.Text
            compraservice.insertar(compra, ChkCredito.Checked, listaTodosProd, DTPfechacompra.Value)

            MsgBox("Compra Guardada Correctamente.")
            txtfolio.Text = compra.Id
            NuevaCompra()

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btnvercompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvercompra.Click
        Try
            VerCompra()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Sub VerCompra()
        If txtfolio.Text = "" Then
            MsgBox("Debe introducir un folio de compra")
            txtfolio.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtfolio.Text) Then
            MsgBox("Debe introducir solo números para visualizar una compra")
            txtfolio.Focus()
            Exit Sub
        End If
        compraservice = New Service_Compra
        Dim folio As Integer
        folio = txtfolio.Text
        compra = compraservice.ObtenerCompra(folio)
        If compra.Id > 0 Then
            esVerCompra = True
            txtproveedor.Text = compra.Proveedor
            EncontrarProveedor(txtproveedor.Text.Trim)
            ActualizarGrid()
            ChkCredito.Checked = compra.credito 
            btnFinalizar.Enabled = False
            btnbuscarproveedor.Enabled = False
            btnbuscarprod.Enabled = False
            btnagregar.Enabled = False
            ChkCredito.Enabled = False
            DGVcompra.Enabled = False
            txtproveedor.Enabled = False
            txtcosto.Enabled = False
            txtprecio.Enabled = False
            txtcantidad.Enabled = False
            txtdesc.Enabled = False
            txtcodigo.Enabled = False
        End If
    End Sub
    Private Sub txtproveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtproveedor.TextChanged
        txtnombreproveedor.Text = ""
        txtdescripcionprod.Text = ""
        lblExistencia.Text = ""
        txtcosto.Text = ""
        txtprecio.Text = ""
        txtcantidad.Text = ""
        txtdesc.Text = ""
        txtcodigo.Text = ""
        DGVcompra.Rows.Clear()
        txtSubtotal.Text = "$0.00"
        txtDescuento.Text = "$0.00"
        txtiva.Text = "$0.00"
        txtletras.Text = "CERO PESOS 00/100 MN"
        txtTotal.Text = "$0.00"
        txtdesc.Text = ""
        ChkCredito.Checked = False
    End Sub
    Private Sub txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodigo.TextChanged
        txtdescripcionprod.Text = ""
        lblExistencia.Text = ""
        txtcosto.Text = ""
        txtprecio.Text = ""
        txtcantidad.Text = ""
        txtdesc.Text = ""
    End Sub
    Private Sub txtdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            '' Me.Button1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(8) Then ' se pulsó Retroceso
            e.Handled = False
        ElseIf (e.KeyChar < "0"c Or e.KeyChar > "9"c) Then
            ' desechar los caracteres que no son dígitos
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            AgregarProducto()
        End If
    End Sub
    Private Sub txtcantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            '' Me.Button1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(8) Then ' se pulsó Retroceso
            e.Handled = False
        ElseIf (e.KeyChar < "0"c Or e.KeyChar > "9"c) Then
            ' desechar los caracteres que no son dígitos
            e.Handled = True
        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            AgregarProducto()
        End If
    End Sub
    Private Sub txtcosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcosto.KeyPress, txtprecio.KeyPress
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
    Private Sub txtcosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcosto.TextChanged
        Try
            If txtcosto.Text.Length <> 0 Then
                If chkmayoreo.Checked Then
                    If Sesion.porcetaje <> 0 Then
                        costo = CDec(txtcosto.Text)
                        precio = costo * Sesion.porcetaje / 100 + costo
                        txtprecio.Text = String.Format("{0:n}", precio)
                    End If
                ElseIf chkmedmay.Checked Then
                    If conf.Porcentaje_Medio <> 0 Then
                        costo = CDec(txtcosto.Text)
                        precio = costo * conf.Porcentaje_Medio / 100 + costo
                        txtprecio.Text = String.Format("{0:n}", precio)
                    End If
                End If
                Dim costoPieza As Decimal = costo / producto.Piezas
                precioMenudeo = costoPieza + (costoPieza * conf.Porcentaje_Menudeo / 100)
                txtpreciomenudeo.Text = String.Format("{0:n}", precioMenudeo)
            Else
                txtprecio.Text = "0.00"
                txtpreciomenudeo.Text = "0.00"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub chkmayoreo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkmayoreo.Click
        If Sesion.porcetaje <> 0 Then
            If txtcosto.Text <> "" Then
                costo = CDec(txtcosto.Text)
                precio = costo * Sesion.porcetaje / 100 + costo
                txtprecio.Text = String.Format("{0:n}", precio)
                precioMenudeo = (costo / producto.Piezas) + (costo * conf.Porcentaje_Menudeo / 100)
                txtpreciomenudeo.Text = String.Format("{0:n}", precioMenudeo)
            End If
        End If
    End Sub
    Private Sub chkmedmay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkmedmay.Click
        If conf.Porcentaje_Medio <> 0 Then
            If txtcosto.Text <> "" Then
                costo = CDec(txtcosto.Text)
                precio = costo * conf.Porcentaje_Medio / 100 + costo
                txtprecio.Text = String.Format("{0:n}", precio)
                precioMenudeo = (costo / producto.Piezas) + (costo * conf.Porcentaje_Menudeo / 100)
                txtpreciomenudeo.Text = String.Format("{0:n}", precioMenudeo)
            End If
        End If
    End Sub
    Private Sub DGVcompra_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVcompra.CellDoubleClick
        If Not DGVcompra.Rows.Count < 0 Then
            BuscarProductosHijos(DGVcompra.CurrentRow.Cells(9).Value)
            Dim CostoProdPadre As Decimal = DGVcompra.CurrentRow.Cells(3).Value
            Dim PzasProdPadre As Decimal = DGVcompra.CurrentRow.Cells(10).Value
            Dim idprod As Decimal = DGVcompra.CurrentRow.Cells(9).Value
            Dim fila As Short = DGVcompra.CurrentRow.Index
            Dim frm As New frmPaquetes(listaprod, listaTodosProd, CostoProdPadre, PzasProdPadre, idprod, DGVcompra.CurrentRow.Cells(4).Value, DGVcompra.CurrentRow.Cells(12).Value)
            frm.ShowDialog()
            If frm.FilaEditada Then
                item.Producto.ProductoActualizado = True
                DGVcompra.Rows(fila).DefaultCellStyle.BackColor = Color.LightSteelBlue
            End If
        End If
    End Sub
    Private Sub BuscarProductosHijos(ByVal idP As Integer)
        listaprod = New List(Of Producto)
        SProductos = New Service_Producto
        listaprod = SProductos.ObtenerIDC(idP)
    End Sub
    Private Sub DGVcompra_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVcompra.CellEndEdit
        Dim id As Integer = DGVcompra.CurrentRow.Cells(8).Value
        Dim ActivoCodHrno As Boolean = DGVcompra.CurrentRow.Cells(10).Value
        If ActivoCodHrno Then
            For Each item As CCompraDetalle In compra._compraitems
                If item.Producto.Id = id Then
                    item.Producto.ActualizarCodigosHermanos = True
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub DGVcompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVcompra.KeyDown
        If e.KeyCode = 46 Then
            Dim del As String = DGVcompra.CurrentRow.Cells(0).Value
            Dim id As String = DGVcompra.CurrentRow.Cells(8).Value
            Try
                compra.BorraItem(del)
                BorraItemListaTodosProd(id)
                ActualizarGrid()
                txtcodigo.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub BorraItemListaTodosProd(ByVal id As String)
        BuscarProductosHijos(id)
        For Each item As Producto In listaprod
            For Each i As Producto In listaTodosProd
                If item.Id = i.Id Then
                    listaTodosProd.Remove(i)
                    Exit For
                End If
            Next
        Next
    End Sub
    Private Sub btnMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        cerrar()
    End Sub
    Public Sub cerrar()
        If Not compra Is Nothing Then
            If compra.Items.Count > 0 And esVerCompra = False Then
                Dim message = MsgBox("La compra actual se cerrará y los datos se perderán." & " ¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                If message = vbYes Then
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
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    Private Sub txtfolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfolio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            VerCompra()
        End If
    End Sub

    Private Sub txtiva_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtiva.MouseMove, Label8.MouseMove, ChkCredito.MouseMove

        ToolTip1.SetToolTip(txtiva, "Este valor es unicamente informativo")
        ToolTip1.SetToolTip(Label8, "Este valor es unicamente informativo")
        ToolTip1.SetToolTip(ChkCredito, "Activa esta opcion si tu compra fue a credito")
    End Sub
End Class