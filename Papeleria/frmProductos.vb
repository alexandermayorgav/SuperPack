Imports System.ComponentModel
Imports LogicaNegocio

Public Class frmProductos
    Private sl As Service_linea
    Private sp As Service_Producto
    Private producto As Producto
    Private nuevo As Boolean = True
    Private id_producto As Integer = 0
    Dim validacion As CValidation
    Dim keyascii As Short
    Private precio As Decimal
    Private costo As Decimal
    Private sc As Service_Codigos
    Private codigos As Codigo
    Private listac As List(Of Codigo)
    Private paquete As opPaquetes
    Private servicio As opServicio
    Private iniciado As Boolean = False

    Private milista As New List(Of Proveedor)
    'Private proveedores As List(Of Proveedor)
    Private proveedor As Proveedor
    Private misPaquetes As New List(Of Producto)
    Private misPaquetesCopy As New List(Of Producto)

    Private operaciones As opTraspaso
    Private WithEvents pro As frmProductosRelacionados

  
    Private Sub frmProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                btnBuscar.PerformClick()
            Case Keys.F4
                btnAgregarLinea.PerformClick()
            Case Keys.F5
                btnGuardar.PerformClick()
            Case Keys.F6
                btnnuevo.PerformClick()
        End Select

    End Sub

    Private Sub frmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nueva()
        IniciarPaquete()
        'iniciarservicios()
        cargarLineas()
        limpiar()
        txtCodigo.Select()
        txtCodigo.Focus()
        Me.KeyPreview = True

    End Sub
    Private Sub btnAgregarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarLinea.Click
        Try
            Dim frm As New frmLineas
            frm.ShowDialog()
            frm = Nothing
            cargarLineas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarLineas()
        Try
            sl = New Service_linea
            sl.IniciarBusqueda()
            Dim lista As List(Of Linea) = sl.obtener_Lineas
            ddlLinea.DataSource = lista
            sl.FinalizarBusqueda()
            sl = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
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
        Dim bandera As Boolean = False
        If Not txtDescuento.Text.Length <= 0 Then
            If CDec(txtDescuento.Text) > 100 Then
                MsgBox("Los descuentos no pueden ser mayores al 100 %")
                txtDescuento.Select()
                txtDescuento.Focus()
                Exit Sub
            End If
        End If
        
        If Not txtCodigo.Text.Length <= 0 And Not txtCosto.Text.Length <= 0 And Not txtDescripcion.Text.Length <= 0 And Not txtDescuento.Text.Length <= 0 And Not txtMenudeo.Text.Length <= 0 And Not txtSobrante.Text.Length <= 0 And Not txtExistencia.Text.Length <= 0 And Not txtMAx.Text.Length <= 0 And Not txtMin.Text.Length <= 0 And Not txtPiezas.Text.Length <= 0 And Not txtPrecio.Text.Length <= 0 And Not txtRango.Text.Length <= 0 Then

            Try
                sp = New Service_Producto
                producto = New Producto(id_producto, txtCodigo.Text, txtDescripcion.Text, txtCosto.Text, txtPrecio.Text, txtMin.Text, txtMAx.Text, txtPiezas.Text, txtExistencia.Text, txtDescuento.Text, txtRango.Text, ddlLinea.SelectedValue, chkIva.Checked, chkActivo.Checked, listac, chkkg.Checked, txtSobrante.Text, dtp.Value, Date.Now, txtMenudeo.Text)

                producto.Actualizar = chkActualizar.Checked
                If nuevo Then
                    If milista.Count > 0 Then
                        sp.insertar(producto, milista, misPaquetes)
                        MsgBox("Guardado Correctamente.")
                    Else
                        MsgBox("Debe seleccionar un proveedor por lo menos.")
                        Exit Sub
                    End If

                Else 'actualizar
                    For Each it As Proveedor In milista
                        If it.Status Then
                            sp.actualizar(producto, milista, misPaquetes)
                            MsgBox("Actualizado Correctamente.")
                            bandera = True
                            Exit For
                        End If
                    Next
                    If Not bandera Then
                        MsgBox("Debe seleccionar un proveedor por lo menos.")
                        Exit Sub
                    End If
                End If

                limpiar()
                txtCodigo.Select()
                txtCodigo.Focus()
            Catch ex As Exception
                If Err.Number = 5 Then
                    MsgBox("El codigo ya existe.")
                    txtCodigo.Focus()
                Else
                    MsgBox(ex.Message)
                End If
            End Try

        Else
            MsgBox("Todos los campos son requeridos.")
        End If
    End Sub
    Private Sub limpiar()
        txtCodigo.Text = ""
        txtCosto.Text = String.Format("{0:c}", 0)
        txtDescripcion.Text = ""
        txtDescuento.Text = 0
      
        txtExistencia.Text = 0
        txtMAx.Text = 0
        txtMin.Text = 0
        txtPiezas.Text = 0
        txtPrecio.Text = String.Format("{0:c}", 0)
        txtRango.Text = 0
        ddlLinea.SelectedIndex = 0
        chkActivo.Checked = True
        chkIva.Checked = True
        nuevo = True
        id_producto = 0
        sp = Nothing
        producto = Nothing
        
        btnGuardar.Text = "Guardar"

        chkActualizar.Visible = False
        proveedor = Nothing
        milista = New List(Of Proveedor)
        dgvp.Rows.Clear()
        chkkg.Checked = False
        chkActualizar.Checked = True

        txtSobrante.Text = 0
        txtMenudeo.Text = 0

        ddlPorcentajes.SelectedIndex = 0
        misPaquetes = New List(Of Producto)
        '   misPaquetesCopy = New List(Of Producto)
        dgvPaquetes.Rows.Clear()

        btnAgregarPaquetes.Enabled = False
        btnActPrecios.Enabled = False
        btnCanPrecios.Enabled = False
        btnArmarPaquetes.Visible = False
    End Sub
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress

        If Not txtCodigo.Text.Length <= 0 Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                Try
                    sp = New Service_Producto
                    producto = New Producto
                    Try
                        producto = sp.Obtener(txtCodigo.Text.Trim)
                    Catch ex As Exception
                        producto = Nothing
                        sp = Nothing
                        MsgBox(ex.Message)
                        Exit Sub
                    End Try

                    milista = sp.obtener_Proveedores(producto.Id)
                    formatoGrid()
                    ''codigo hermano
                    sc = New Service_Codigos
                    codigos = New Codigo
                    codigos.Id_Producto = producto.Id
                    Try
                        listac = New List(Of Codigo)
                        listac = sc.verGrupoChino(codigos)
                        If listac.Count > 0 Then
                            chkActualizar.Visible = True
                        End If
                    Catch ex As Exception
                        Exit Try
                    End Try

                    'paquetes relacionados
                    misPaquetes = sp.ObtenerPaqRel(producto.Id)
                    'misPaquetesCopy = sp.ObtenerPaqRel(producto.Id)
                    formatoGridPaquetes()

                    cargarDAtos(producto)
                    'milista = New List(Of Proveedor)
                    producto = Nothing
                    sp = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

        End If

        validacion = New CValidation
        keyascii = CShort(Asc(e.KeyChar))
        keyascii = CShort(validacion.codigoBarras(keyascii))
        If keyascii = 0 Then
            e.Handled = True
        End If
        validacion = Nothing

    End Sub
    Private Sub cargarDAtos(ByVal producto As Producto)
        id_producto = producto.Id
        txtCosto.Text = String.Format("{0:c}", producto.Costo)
        txtDescripcion.Text = producto.Descripcion
        txtDescuento.Text = producto.Descuento
        'txtDescuento1.Text = producto.Descuento_1
        'txtDescuento2.Text = producto.Descuento_2
        txtExistencia.Text = producto.Existencia
        txtMAx.Text = producto.Stock_max
        txtMin.Text = producto.Stock_min
        txtPiezas.Text = producto.Piezas
        txtPrecio.Text = String.Format("{0:c}", producto.Precio)
        txtRango.Text = producto.Rango
        ddlLinea.SelectedValue = producto.Id_linea
        chkActivo.Checked = producto.Status
        chkIva.Checked = producto.Iva
        nuevo = False
        btnGuardar.Text = "Actualizar"
        chkkg.Checked = producto.Kg

        txtSobrante.Text = producto.Sobrante
        If producto.Sobrante > 0 Then
            btnArmarPaquetes.Visible = True
        Else
            btnArmarPaquetes.Visible = False
        End If

        txtMenudeo.Text = String.Format("{0:c}", producto.Precio_Menudeo)
        dtp.Value = producto.Fecha_Compra

        btnAgregarPaquetes.Enabled = True
        btnActPrecios.Enabled = True
        ' btnCanPrecios.Enabled = True
        ImageButton1.Enabled = True
    End Sub
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        limpiar()
        txtCodigo.Select()
        txtCodigo.Focus()
    End Sub
    Private Sub txtExistencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtExistencia.KeyPress, txtCosto.KeyPress, txtDescuento.KeyPress, txtMAx.KeyPress, txtMin.KeyPress, txtPiezas.KeyPress, txtPrecio.KeyPress, txtRango.KeyPress, txtMenudeo.KeyPress, txtSobrante.KeyPress
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
    Private Sub txtCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCosto.TextChanged
        calculaPrecios()
    End Sub

    Private Sub calculaPrecios()
        Dim porcentaje As Decimal = 0
        Dim precioMenudeo As Decimal = 0
        Try
            If txtCosto.Text.Length <> 0 Then
                If ddlPorcentajes.SelectedIndex = 0 Then
                    porcentaje = Sesion.conf.Porcentaje
                Else
                    porcentaje = Sesion.conf.Porcentaje_Medio
                End If


                Try
                    costo = CDec(txtCosto.Text)
                Catch ex As Exception
                    txtCosto.Text = String.Format("{0:c}", 0)
                    Exit Sub
                End Try
                precio = costo * porcentaje / 100 + costo
                txtPrecio.Text = String.Format("{0:c}", precio)
                If txtPiezas.Text.Length <> 0 And costo <> 0 Then
                    If Not txtPiezas.Text <> 0 Then
                        Exit Sub
                    End If
                    Dim pUni As Decimal = costo / CDec(txtPiezas.Text)
                    precioMenudeo = (pUni) * Sesion.conf.Porcentaje_Menudeo / 100 + pUni
                    txtMenudeo.Text = String.Format("{0:c}", precioMenudeo)
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '//////////////////Paquetes

    Private Sub txtCodigoPaquete_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoP.KeyPress

        If Not txtCodigoP.Text.Length <= 0 Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                Try
                    sp = New Service_Producto
                    Dim pro As Producto
                    pro = sp.Obtener(txtCodigoP.Text.Trim)

                    If pro IsNot Nothing Then
                        btnAgregar.Enabled = False
                        btnAgregarPaq.Enabled = True
                        btnCrearpq.Text = "Actualizar"
                        paquete = New opPaquetes(paquete.ObtenerPaquete(pro))
                        binding.DataSource = paquete
                        paquete.crearPaquetes()
                        txtNumPaq.Text = paquete.Paq.PaqArmar
                        DataGridView1.ReadOnly = True
                        DataGridView1.AllowUserToDeleteRows = False
                    End If

                Catch ex As ReglasNegocioException
                    MsgBox(ex.Message)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If

    End Sub

    Private binding As New BindingSource
    Private Sub IniciarPaquete()
        AddHandler LogicaNegocio.Paquete.Errores, AddressOf VerError
        AddHandler LogicaNegocio.Paquete.SinErr, AddressOf QuitaErr
        AddHandler LogicaNegocio.ItemPaquete.Recalcula, AddressOf actualizacampos
        paquete = New opPaquetes



        binding.DataSource = paquete
        txtCodigoP.DataBindings.Add("Text", binding, "Paq.Codigo", False, DataSourceUpdateMode.OnPropertyChanged)
        txtCostoP.DataBindings.Add("Text", binding, "Paq.Costo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCostoP.DataBindings(0).FormatString = "c"
        txtPrecioP.DataBindings.Add("Text", binding, "Paq.Precio", True, DataSourceUpdateMode.OnPropertyChanged)
        txtPrecioP.DataBindings(0).FormatString = "c"
        txtDescripcionP.DataBindings.Add("Text", binding, "Paq.Descripcion", False, DataSourceUpdateMode.OnPropertyChanged)
        txtExistenciaP.DataBindings.Add("Text", binding, "Paq.Existencia", False, DataSourceUpdateMode.OnPropertyChanged)
        lblDsiponibles.DataBindings.Add("Text", binding, "Paq.PaqArmar", False, DataSourceUpdateMode.OnPropertyChanged)
        cbActivoP.DataBindings.Add("Checked", binding, "Paq.Iva", False, DataSourceUpdateMode.OnPropertyChanged)
        cbIvaP.DataBindings.Add("Checked", binding, "Paq.Estatus", False, DataSourceUpdateMode.OnPropertyChanged)
        'DataGridView1.DataSource = paquete.ObtenerItems
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.DataBindings.Add("DataSource", binding, "Paq.Items", False, DataSourceUpdateMode.OnPropertyChanged)
        txtNumPaq.Text = ""
        lblDsiponibles.Text = ""
    End Sub
    Private Sub VerError(ByVal erro As String, ByVal num As Integer)
        If num = 1 Then
            txtCodigoP.BackColor = Color.Red
            txtCodigoP.ForeColor = Color.White
        End If
        If num = 2 Then
            txtDescripcionP.BackColor = Color.Red
            txtDescripcionP.ForeColor = Color.White
        End If
    End Sub
    Private Sub QuitaErr(ByVal num As Integer)
        If num = 1 Then
            txtCodigoP.BackColor = Color.White
            txtCodigoP.ForeColor = Color.Black
        End If
        If num = 2 Then
            txtDescripcionP.BackColor = Color.White
            txtDescripcionP.ForeColor = Color.Black
        End If
    End Sub
    Private Sub ImageButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewPaq.Click
        nueva()
    End Sub
    Private Sub nueva()
        btnAgregar.Enabled = True
        btnAgregarPaq.Enabled = False
        DataGridView1.ReadOnly = False
        DataGridView1.AllowUserToDeleteRows = True
        paquete = New opPaquetes
        binding.DataSource = paquete
        btnCrearpq.Text = "Crear"
        txtdeshacer.Text = "0"
        actualizacampos()
    End Sub
    Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            frmBuscarProducto.TipoProducto = 1
            frmBuscarProducto.ShowDialog()
            If Not frmBuscarProducto.dgv.CurrentRow Is Nothing Then
                Dim item As Producto = CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto)
                paquete.AddProducto(item)
                '  actualizacampos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub actualizacampos()
        If paquete.Paq.Id = -1 Then
            paquete.crearPaquetes()
        Else
            paquete.crearPaquetes2()
        End If
        txtNumPaq.Text = paquete.Paq.PaqArmar
        lblDsiponibles.Text = paquete.Paq.PaqArmar
    End Sub
    Private Sub txtCrearPq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearpq.Click
        Try

            If paquete.Paq.Id = -1 Then
                For Each item In paquete.Paq.Items
                    If item.Existencia <= 0 Then
                        Throw New Exception("No se pueden crear el paquete con productos sin existencia")
                    End If
                Next
            End If

            paquete.Save(txtNumPaq.Text)
          
            btnCrearpq.Text = "Actualizar"
            DataGridView1.ReadOnly = True
            btnAgregar.Enabled = False
            btnCrearpq.Enabled = True
            btnAgregarPaq.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
        If txtdeshacer.Text.Trim <> "" Then
            paquete.Deshacer(txtdeshacer.Text)
        End If
    End Sub
    Private Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarP.Click
        frmBuscarProducto.TipoProducto = 2
        frmBuscarProducto.ShowDialog()
        If Not frmBuscarProducto.dgv.CurrentRow Is Nothing Then
            btnAgregar.Enabled = False
            btnCrearpq.Text = "Actualizar"
            btnAgregarPaq.Enabled = True
            Dim item As Producto = CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto)
            paquete = New opPaquetes(paquete.ObtenerPaquete(item))
            binding.DataSource = paquete
            paquete.crearPaquetes()
            txtNumPaq.Text = paquete.Paq.PaqArmar
            DataGridView1.ReadOnly = True
            DataGridView1.AllowUserToDeleteRows = False
        End If



    End Sub
    Private Sub DataGridView1_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        actualizacampos()
    End Sub
    Private Sub btnAgregarPaq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPaq.Click
        Try
            ' DataGridView1.ReadOnly = True
            paquete.AddPaquetes(txtNumPaq.Text)
            MsgBox("Paquetes Agregados")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''///Agregar proveedores
    Private Sub btnProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            frm.ShowDialog()
            If Not frm._id_proveedor <> 0 Then
                Exit Sub
            End If
            proveedor = New Proveedor(frm._id_proveedor, frm.razon, True, True)

            If Not milista Is Nothing Then
                If Not existeItem(proveedor) Then
                    milista.Add(proveedor)
                End If

                'formatoGrid()
                'frm = Nothing
            Else
                If producto Is Nothing Then
                    milista = New List(Of Proveedor)
                    milista.Add(proveedor)
                End If
            End If
            formatoGrid()
            frm = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function existeItem(ByVal items As Proveedor) As Boolean
        For Each it As Proveedor In milista
            If it.IdProveedor = items.IdProveedor Then
                If it.Status = False Then
                    it.Status = True
                End If
                Return True
                Exit For
            End If
        Next
        Return False
    End Function
    Private Sub formatoGrid()
        Dim R As Short = 0

        dgvp.Rows.Clear()

        For Each item As Proveedor In milista
            If item.Status Then
                With dgvp
                    .Rows.Add()
                    R = .RowCount - 1

                    .Rows(R).Cells("id_proveedor").Value = item.IdProveedor
                    .Rows(R).Cells("RazonSocial").Value = item.RazonSocial

                End With

            End If
        Next

        Dim fuente As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel, 4)
        dgvp.Font = fuente





        Dim renglo As Integer = dgvp.RowCount - 1
        '    DGVP.Rows(renglo).Selected = True
        If Not renglo <= 0 Then
            dgvp.FirstDisplayedScrollingRowIndex = dgvp.Rows(renglo).Index
        End If




    End Sub

    Private Sub dgvp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvp.KeyDown
        If e.KeyCode = 46 Then
            'Dim item As New Proveedor(dgvp.CurrentRow.Cells(0).Value, dgvp.CurrentRow.Cells(1).Value, False)
            Try

                For Each i As Proveedor In milista
                    If i.IdProveedor = dgvp.CurrentRow.Cells(0).Value Then
                        i.Status = False
                        Exit For
                    End If
                Next

                formatoGrid()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnAgregarPaquetes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPaquetes.Click
        Try
            Dim frm As New frmBuscarProducto
            frm.ShowDialog()
            If frm.codigo <> "" Then
                sp = New Service_Producto
                Dim paquete As Producto = sp.Obtener(frm.codigo)
                paquete.IDCAJA = IIf(id_producto = 0, 1, id_producto)
                If existePaquete(paquete.Id) Then
                    If paquete.Id <> id_producto Then
                        misPaquetes.Add(paquete)
                        misPaquetesCopy.Add(paquete)

                    End If
                End If
                formatoGridPaquetes()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function existePaquete(ByVal id As Integer) As Boolean
        Try
            For Each it As Producto In misPaquetes
                If it.Id = id Then
                    If it.IDCAJA <> 0 Then
                        Return False
                    Else
                        it.IDCAJA = id_producto
                        Return False
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub formatoGridPaquetes()
        Dim R As Short = 0

        dgvPaquetes.Rows.Clear()

        For Each it As Producto In misPaquetes
            If it.IDCAJA <> 0 Then
                With dgvPaquetes
                    .Rows.Add()
                    R = .RowCount - 1
                    .Rows(R).Cells("id").Value = it.Id
                    .Rows(R).Cells("codigoPaq").Value = it.Codigo
                    .Rows(R).Cells("descripcionPaq").Value = it.Descripcion
                    .Rows(R).Cells("piezasPaq").Value = it.Piezas
                    .Rows(R).Cells("costoPaq").Value = it.Costo
                    .Rows(R).Cells("precioPaq").Value = it.Precio
                    .Rows(R).Cells("menudeoPaq").Value = it.Precio_Menudeo
                End With
            End If
        Next

        Dim fuente As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel, 4)
        dgvPaquetes.Font = fuente

        Dim renglo As Integer = dgvPaquetes.RowCount - 1
        '    DGVP.Rows(renglo).Selected = True
        If Not renglo <= 0 Then
            dgvPaquetes.FirstDisplayedScrollingRowIndex = dgvPaquetes.Rows(renglo).Index
        End If

        dgvPaquetes.Columns(1).Width = 70
        dgvPaquetes.Columns(2).Width = 120
        dgvPaquetes.Columns(3).Width = 50
        dgvPaquetes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPaquetes.Columns(4).Width = 70
        dgvPaquetes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPaquetes.Columns(4).DefaultCellStyle.Format = "c"
        dgvPaquetes.Columns(5).Width = 70
        dgvPaquetes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPaquetes.Columns(5).DefaultCellStyle.Format = "c"
        dgvPaquetes.Columns(6).Width = 70
        dgvPaquetes.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPaquetes.Columns(6).DefaultCellStyle.Format = "c"

    End Sub

    Private Sub ddlPorcentajes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPorcentajes.SelectedIndexChanged
        calculaPrecios()
    End Sub


    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
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

    Private Sub dgvPaquetes_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaquetes.CellEndEdit
        Try
            Dim row As Integer = dgvPaquetes.CurrentRow.Cells(0).Value
            For Each it As Producto In misPaquetes
                If it.Id = row Then
                    it.Costo = dgvPaquetes.CurrentRow.Cells(4).Value
                    it.Precio = dgvPaquetes.CurrentRow.Cells(5).Value
                    it.Precio_Menudeo = dgvPaquetes.CurrentRow.Cells(6).Value
                    it.Actualizado = True
                End If
            Next
            formatoGridPaquetes()
        Catch ex As Exception
            If Err.Number = 5 Then
                Exit Try
            Else
                MsgBox(ex.Message)
            End If


        End Try
    End Sub

    Private Sub dgvPaquetes_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvPaquetes.CellValidating
        Select Case dgvPaquetes.Columns(e.ColumnIndex).Index
            Case 4
                If Not IsNumeric(e.FormattedValue.ToString()) And Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = "El Costo debe ser un valor numérico"
                    e.Cancel = True
                ElseIf String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = "El Costo no puede estar vacío"
                    e.Cancel = True
                Else
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = String.Empty
                End If
            Case 5
                If Not IsNumeric(e.FormattedValue.ToString()) And Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = "El Precio debe ser un valor numérico"
                    e.Cancel = True
                ElseIf String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = "El Precio no puede estar vacío"
                    e.Cancel = True
                Else
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = String.Empty
                End If
            Case 6
                If Not IsNumeric(e.FormattedValue.ToString()) And Not String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = "El Precio Menudeo debe ser un valor numérico"
                    e.Cancel = True
                ElseIf String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = "El Precio Menudeo no puede estar vacío"
                    e.Cancel = True
                Else
                    dgvPaquetes.Rows(e.RowIndex).ErrorText = String.Empty
                End If
            Case Else

        End Select
    End Sub

    Private Sub dgvPaquetes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPaquetes.KeyDown
        If e.KeyCode = 46 Then
            'Dim item As New Proveedor(dgvp.CurrentRow.Cells(0).Value, dgvp.CurrentRow.Cells(1).Value, False)
            Dim del As Integer = dgvPaquetes.CurrentRow.Cells(0).Value
            Try

                For Each i As Producto In misPaquetes
                    If i.Id = del Then
                        i.IDCAJA = 0
                        Exit For
                    End If
                Next

                For Each i As Producto In misPaquetesCopy
                    If i.Id = del Then
                        i.IDCAJA = 0
                        Exit For
                    End If
                Next

                formatoGridPaquetes()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtPiezas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPiezas.TextChanged
        Try
            If txtPiezas.Text <> 0 Then
                calculaPrecios()
            End If
        Catch ex As Exception
            txtPiezas.Text = 0
            Exit Try
        End Try
       
    End Sub

    Private Sub btnActPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActPrecios.Click
        Try
            Dim costo As Decimal
            Dim precio As Decimal
            Dim pz As Decimal
            Try
                costo = CDec(txtCosto.Text)
                precio = CDec(txtPrecio.Text)
                pz = CDec(txtPiezas.Text)
            Catch ex As Exception
                txtCosto.Text = 0
                txtPrecio.Text = 0
                txtPiezas.Text = 0
                costo = 0
                precio = 0
                pz = 0
                Exit Try
            End Try

            If costo = 0 Or precio = 0 Or pz = 0 Then
                MsgBox("Verifique que el costo, precio y No. de piezas sean diferente de 0")
                Exit Sub
            End If
            Dim pUni As Decimal = costo / pz
            Dim pUniMay As Decimal = precio / pz + Sesion.conf.Precio_Empaque
            For Each it As Producto In misPaquetes
                it.Precio = it.Piezas * pUniMay
                Try
                    it.Precio_Menudeo = CDec(txtMenudeo.Text)
                Catch ex As Exception
                    it.Precio_Menudeo = 0
                    txtMenudeo.Text = 0
                    Exit Try
                End Try

                it.Costo = pUni * it.Piezas
                it.Actualizado = True
            Next
            formatoGridPaquetes()
            btnActPrecios.Enabled = False
            btnCanPrecios.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ImageButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanPrecios.Click

        Try
            misPaquetesCopy = New List(Of Producto)
            For Each it As Producto In misPaquetes
                If it.IDCAJA <> 0 Then
                    sp = New Service_Producto
                    Dim paquete As Producto = sp.Obtener(it.Codigo)
                    paquete.IDCAJA = IIf(id_producto = 0, 1, id_producto)
                    misPaquetesCopy.Add(paquete)
                End If
            Next
            misPaquetes = misPaquetesCopy
            btnActPrecios.Enabled = True
            btnCanPrecios.Enabled = False
            formatoGridPaquetes()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub btnArmarPaquetes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArmarPaquetes.Click
        Dim location As Point = Me.PointToScreen(New Point(dtp.Left, dtp.Top))
        'If operaciones.ItemActual IsNot Nothing Then

        If pro Is Nothing Then


            pro = New frmProductosRelacionados(id_producto)
            pro.StartPosition = FormStartPosition.Manual
            pro.Location = location
            pro.Show()

        Else
            pro.Items(id_producto)
            pro.Location = Location
            pro.Show()
            pro.BringToFront()
            'End If
        End If
    End Sub

    Private Sub cerrar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pro.Deactivate
        pro.Hide()
    End Sub
    Private Sub Seleccionado() Handles pro.Seleccionado
        pro.Hide()
        If pro.DataGridView1.CurrentRow IsNot Nothing Then
            Dim paquete As Producto
            paquete = (CType(pro.DataGridView1.CurrentRow.DataBoundItem, Producto))

            Dim IntNum2 As String = InputBox("Paquete: " & paquete.Descripcion & "    " & paquete.Piezas & " Pz." & Chr(13) & Chr(13) & "Cuantos paquetes desea crear?", "CREAR PAQUETES", Fix(txtSobrante.Text / paquete.Piezas))

            Dim sobrante As Decimal = CDec(txtSobrante.Text)
            Dim existencia As Decimal = 0
            If Not IntNum2 = "" Then
                Try
                    existencia = Fix(CDec(IntNum2))
                    If existencia = 0 Then
                        Throw New Exception("")
                    End If
                    If existencia > Fix(txtSobrante.Text / paquete.Piezas) Then
                        MsgBox("La cantidad de paquetes a crear es mayor a la permitida.")
                        Exit Sub
                    End If

                    paquete.Existencia = existencia
                    sp = New Service_Producto

                    Dim aux As Decimal = 0
                    aux = sobrante - (existencia * paquete.Piezas)

                    txtSobrante.Text = aux
                    sp.updateSobrante(id_producto, aux, paquete)
                    MsgBox("Paquete creado correctamente")
                Catch ex As Exception
                    MsgBox("Cantidad incorrecta.")
                    Exit Sub
                End Try



            End If

        End If

    End Sub

    Private Sub ImageButton1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageButton1.Click
        Try
            If Not id_producto = 0 Then
                Dim A = MsgBox("Esta seguro que desea eliminar el producto?" _
                                 , MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                If A = vbYes Then
                    sp = New Service_Producto
                    sp.borrar(id_producto)
                    MsgBox("Eliminado Correctamente")
                    sp = Nothing
                    limpiar()
                    ImageButton1.Enabled = False
                End If
                
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.ControlKey + Keys.C

                    Clipboard.SetText(txtDescripcion.Text)

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarPaquetes_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPaquetes.MouseHover, btnCanPrecios.MouseHover, btnActPrecios.MouseHover

        ToolTip1.SetToolTip(btnAgregarPaquetes, "Agregar Paquetes")
        ToolTip1.SetToolTip(btnActPrecios, "Calcular Precios")
        ToolTip1.SetToolTip(btnCanPrecios, "Cancelar Precios")

    End Sub

    Private Sub btnAgregarPaquetes_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAgregarPaquetes.MouseMove, btnCanPrecios.MouseMove, btnActPrecios.MouseMove
        ToolTip1.SetToolTip(btnAgregarPaquetes, "Agregar Paquetes")
        ToolTip1.SetToolTip(btnActPrecios, "Calcular Precios")
        ToolTip1.SetToolTip(btnCanPrecios, "Cancelar Precios")

    End Sub
End Class