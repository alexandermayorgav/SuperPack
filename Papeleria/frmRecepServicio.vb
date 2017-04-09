Imports LogicaNegocio
Public Class frmRecepServicio
    Private sserv As Service_Servicio
    Private objserv As Servicio
    Private objC As Cliente
    Private sCl As Service_Cliente
    Private lisserv As List(Of ServicioP)
    Private servicio As opServicio
    Private listfinal As List(Of Producto)
    Private itemsServ As List(Of ServicioItem)
    Private idpers As Integer
    Private total As Decimal = 0

    Private ids As Integer = 0
    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByVal idser As Integer)
        InitializeComponent()
        Me.ids = idser
    End Sub
    Private Sub frmRecepServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ids = 0 Then
            Me.KeyPreview = True
            gp3.Enabled = False
            gp4.Enabled = False
            iniciarObjetos()
            txtFolioC.Select()
        Else
            Me.KeyPreview = True
            txtFolioS.Text = ids
            iniciarObjetos()
            btnObtener.PerformClick()
        End If
        
    End Sub
    Private Sub btnObtenerC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerC.Click
        Try
            obtenerCliente()
        Catch cast As InvalidCastException
            MsgBox("Caracteres incorrectos. Debes proporcionar un folio de cliente (Númerico)")
            txtFolioC.Focus()
            txtFolioC.SelectAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnBuscarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarC.Click
        Try
            Dim frm As New frmBuscarCliente
            frm.ShowDialog()
            If frm.id_cliente > 0 Then
                txtFolioC.Text = frm.id_cliente
                txtFolioC.Focus()
                btnObtenerC.PerformClick()
                frm = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            txtFolioC.Text = ""
            txtFolioC.Select()
        End Try
    End Sub
    Private Sub obtenerCliente()
        Try
            If txtFolioC.Text = "" Then
                MsgBox("Debes proporcionar el folio del cliente")
                txtFolioC.Select()
                txtFolioC.Focus()
            Else
                objC = sCl.Obtener(CInt(txtFolioC.Text))
                txtCliente.Text = objC.Razon
                If Not actualizando Then
                    resetForm(True)
                End If
                txtConc.Select()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
            txtFolioC.Focus()
            txtFolioC.SelectAll()
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If objC Is Nothing Then
            MsgBox("Debes seleccionar un cliente para buscar en su historial")
            txtFolioC.Select()
        Else
            Try
                Dim frm As New frmHistAutos(sserv, objC.Id, objC.Razon, False)
                frm.ShowDialog()
                If Not frm.objAuto Is Nothing Then
                    txtConc.Text = frm.objAuto.Concecionaria
                    txtLin.Text = frm.objAuto.Linea
                    txtTipo.Text = frm.objAuto.Tipo
                    txtMod.Text = frm.objAuto.Modelo
                    txtColor.Text = frm.objAuto.Color
                    txtPlacas.Text = frm.objAuto.Placas
                    txtKm.Select()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                txtFolioC.Text = ""
                txtFolioC.Select()
            End Try
        End If
    End Sub
    Private Sub iniciarObjetos()
        sserv = New Service_Servicio
        objserv = New Servicio

        sCl = New Service_Cliente
        servicio = New opServicio
        lisserv = New List(Of ServicioP)
        listfinal = New List(Of Producto)
    End Sub

    Private Sub frmRecepServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

   
    Private Sub txtFolioC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioC.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnObtenerC.PerformClick()
        End If
    End Sub

    Private Sub btnPaso1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaso1.Click
        If objC Is Nothing Then
            MsgBox("Debes seleccionar un cliente para continuar")
            txtFolioC.Select()
        ElseIf txtConc.Text = "" Or txtLin.Text = "" Or txtTipo.Text = "" Or txtMod.Text = "" Or txtColor.Text = "" Or txtPlacas.Text = "" Or txtKm.Text = "" Then
            MsgBox("Los datos del automovil son requeridos")
            txtConc.Focus()
            txtConc.SelectAll()
        ElseIf txtRec.Text = "" Then
            MsgBox("El nombre del personal que recibio es requerido")
            btnPers.Focus()
        ElseIf txtMec.Text = "" Then
            MsgBox("El nombre del tecnico asignado al servicio es requerido")
            btnMec.Focus()
        Else
            gp3.Enabled = True
            gp4.Enabled = True
            tbcntrl.SelectedTab = tp2
            txtDiag.Focus()
        End If
    End Sub

    Private Sub btnBuscarServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarServicios.Click
        frmBuscarProducto.TipoProducto = 3
        frmBuscarProducto.ShowDialog()
        If Not frmBuscarProducto.dgv.CurrentRow Is Nothing Then
            Dim item As Producto = CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto)
            If Not actualizando Then
                servicio = New opServicio(servicio.ObtenerServicio(item))
                lisserv.Add(servicio.Serv)
                total += servicio.Serv.Precio
                actualizarGridServ()
            Else
                Dim its As New ServicioItem(0, 0, item.Descripcion, "SERVICIO", "", 1, item.Costo, item.Precio, item.Id)
                itemsservact.Add(its)
                total += its.Precio
                llenarGridServAct()
            End If
        End If
    End Sub
    Private Sub actualizarGridServ()
        Try
            dgvServ.DataSource = Nothing
            With dgvServ
                .DataSource = lisserv
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Width = 216
                .Columns(3).Visible = False
                .Columns(4).Width = 80
                .Columns(4).DefaultCellStyle.Format = "c"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).Visible = False
                .Columns(6).Visible = False

            End With
            lblTotal.Text = FormatCurrency(total)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvServ_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServ.CellClick
        If dgvServ.RowCount > 0 Then
            If Not actualizando Then
                Dim item As ServicioP = CType(dgvServ.CurrentRow.DataBoundItem, ServicioP)
                With dgvRefs
                    .DataSource = item.Items
                    .Columns(0).Width = 210
                    .Columns(1).Visible = False
                    .Columns(2).DefaultCellStyle.Format = "c"
                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(2).Width = 80
                End With
            Else
                Dim items As List(Of ItemServicio) = sserv.obtenerItemsServicio(dgvServ.CurrentRow.Cells(0).Value)
                With dgvRefs
                    .DataSource = items
                    .Columns(0).Width = 210
                    .Columns(1).Visible = False
                    .Columns(2).DefaultCellStyle.Format = "c"
                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(2).Width = 80
                End With
            End If
            
        End If
    End Sub

    Private Sub dgvRefs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRefs.DoubleClick
        If dgvRefs.RowCount > 0 Then
            If Not actualizando Then
                Dim item As ItemServicio = CType(dgvRefs.CurrentRow.DataBoundItem, ItemServicio)
                If existe(item) Then
                    agrega(item)
                Else
                    listfinal.Add(item.Producto)
                End If
                total += item.Precio
                actualizarListaRefacciones()
            Else
                Dim item As ItemServicio = CType(dgvRefs.CurrentRow.DataBoundItem, ItemServicio)
                If existeact(item) Then
                    agregaact(item)
                Else
                    Dim its As New ServicioItem(0, 0, item.Descripcion, "REFACCION", "", 1, item.Producto.Costo, item.Producto.Precio, item.Id_Producto)
                    itemsrefact.Add(its)
                End If
                total += item.Precio
                llenarGridRefsAct()
            End If
            
        End If
    End Sub
    Private Sub actualizarListaRefacciones()
        Try
            dgvRefsF.DataSource = Nothing
            With dgvRefsF
                .DataSource = listfinal
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Width = 210
                .Columns(3).Visible = False
                .Columns(4).Width = 77
                .Columns(4).DefaultCellStyle.Format = "c"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .Columns(11).Visible = False
                .Columns(12).Visible = False
                .Columns(13).Visible = False
                .Columns(14).Visible = False
                .Columns(15).Visible = False
                .Columns(16).Visible = False
                .Columns(17).Width = 90
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            lblTotal.Text = FormatCurrency(total)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function existe(ByVal item As ItemServicio)
        Try
            For Each prodf As Producto In listfinal
                If prodf.Id = item.Id_Producto Then
                    Return True
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function
    Private Sub agrega(ByVal item As ItemServicio)
        Try
            For Each prodf As Producto In listfinal
                If prodf.Id = item.Id_Producto Then
                    prodf.Cantidad += 1
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function existeact(ByVal item As ItemServicio)
        Try
            For Each prodf As ServicioItem In itemsrefact
                If prodf.IdProducto = item.Id_Producto Then
                    Return True
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function
    Private Sub agregaact(ByVal item As ItemServicio)
        Try
            For Each prodf As ServicioItem In itemsrefact
                If prodf.IdProducto = item.Id_Producto Then
                    prodf.Cantidad += 1

                    'ACTUALIZAR EN LA BASE TAMBIEN
                    sserv.actCantServDetSum(prodf.IdServDetalle)
                    
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function existe2(ByVal item As Producto)
        Try
            If Not actualizando Then
                For Each prodf As Producto In listfinal
                    If prodf.Id = item.Id Then
                        Return True
                    End If
                Next
            Else
                For Each prodf As ServicioItem In itemsrefact
                    If prodf.IdProducto = item.Id Then
                        Return True
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function
    Private Sub agrega2(ByVal item As Producto)
        Try
            If Not actualizando Then
                For Each prodf As Producto In listfinal
                    If prodf.Id = item.Id Then
                        prodf.Cantidad += 1
                    End If
                Next
            Else
                For Each prodf As ServicioItem In itemsrefact
                    If prodf.IdProducto = item.Id Then
                        prodf.Cantidad += 1
                    End If
                Next
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnPers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPers.Click
        Try
            Dim frmp As New frmPersonal
            frmp.ShowDialog()
            If Not frmp.objP Is Nothing Then
                txtRec.Text = frmp.objP.Nombre
                idpers = frmp.objP.Id
                btnMec.Focus()
            End If
            frmp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMec.Click
        Try
            Dim frmp As New frmPersonal
            frmp.ShowDialog()
            If Not frmp.objP Is Nothing Then
                txtMec.Text = frmp.objP.Nombre
                btnPaso1.Focus()
            End If
            frmp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvServ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvServ.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If Not dgvServ.CurrentRow Is Nothing Then
                    Dim id As Integer = dgvServ.CurrentRow.Cells(0).Value
                    If Not actualizando Then
                        For Each serv As ServicioP In lisserv
                            If serv.Id = id Then
                                lisserv.Remove(serv)
                                dgvRefs.DataSource = Nothing
                                total -= serv.Precio
                                lblTotal.Text = FormatCurrency(total)
                                actualizarGridServ()
                                Exit For
                            End If
                        Next
                    Else
                        If dgvServ.CurrentRow.Cells(3).Value <> 0 Then
                            Dim confirmacion = MsgBox("El servicio ya habia sido guardado durante la recepción." & Chr(13) & " ¿Estas seguro que deseas eliminar el servicio?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
                            If confirmacion = vbYes Then
                                Try
                                    sserv.eliminarServDet(dgvServ.CurrentRow.Cells(2).Value)
                                Catch ex As ReglasNegocioException
                                    MsgBox(ex.Message)
                                Finally
                                    For Each serv As ServicioItem In itemsservact
                                        If serv.IdProducto = id Then
                                            itemsservact.Remove(serv)
                                            dgvRefs.DataSource = Nothing
                                            total -= serv.Precio
                                            lblTotal.Text = FormatCurrency(total)
                                            llenarGridServAct()
                                            Exit For
                                        End If
                                    Next
                                End Try
                            End If

                        Else
                            For Each serv As ServicioItem In itemsservact
                                If serv.IdProducto = id Then
                                    itemsservact.Remove(serv)
                                    dgvRefs.DataSource = Nothing
                                    total -= serv.Precio
                                    lblTotal.Text = FormatCurrency(total)
                                    llenarGridServAct()
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvRefsF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRefsF.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If Not dgvRefsF.CurrentRow Is Nothing Then
                    Dim id As Integer = dgvRefsF.CurrentRow.Cells(0).Value
                    If Not actualizando Then
                        For Each ref As Producto In listfinal
                            If ref.Id = id Then
                                If ref.Cantidad > 1 Then
                                    ref.Cantidad -= 1
                                Else
                                    listfinal.Remove(ref)
                                End If
                                total -= ref.Precio
                                lblTotal.Text = FormatCurrency(total)
                                actualizarListaRefacciones()
                                Exit For
                            End If
                        Next
                    Else
                        If dgvRefsF.CurrentRow.Cells(2).Value <> 0 Then
                            Dim confirmacion = MsgBox("La refaccion ya habia sido guardada durante la recepción." & Chr(13) & " ¿Estas seguro que deseas eliminar la refacción?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
                            If confirmacion = vbYes Then
                                Try
                                    If dgvRefsF.CurrentRow.Cells(9).Value > 1 Then
                                        sserv.actCantServDet(dgvRefsF.CurrentRow.Cells(2).Value)
                                        For Each ref As ServicioItem In itemsrefact
                                            If ref.IdProducto = id Then
                                                If ref.Cantidad > 1 Then
                                                    ref.Cantidad -= 1
                                                Else
                                                    itemsrefact.Remove(ref)
                                                End If
                                                total -= ref.Precio
                                                lblTotal.Text = FormatCurrency(total)
                                                llenarGridRefsAct()
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        sserv.eliminarServDet(dgvRefsF.CurrentRow.Cells(2).Value)
                                        For Each refa As ServicioItem In itemsrefact
                                            If refa.IdProducto = id Then
                                                itemsrefact.Remove(refa)
                                                total -= refa.Precio
                                                lblTotal.Text = FormatCurrency(total)
                                                llenarGridRefsAct()
                                                Exit For
                                            End If
                                        Next
                                    End If
                                Catch ex As ReglasNegocioException
                                    MsgBox(ex.Message)
                                End Try
                            End If
                        Else
                            For Each ref As ServicioItem In itemsrefact
                                If ref.IdProducto = id Then
                                    If ref.Cantidad > 1 Then
                                        ref.Cantidad -= 1
                                    Else
                                        itemsrefact.Remove(ref)
                                    End If
                                    total -= ref.Precio
                                    lblTotal.Text = FormatCurrency(total)
                                    llenarGridRefsAct()
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarRef.Click
        Try
            frmBuscarProducto.TipoProducto = 1
            frmBuscarProducto.ShowDialog()
            If Not frmBuscarProducto.dgv.CurrentRow Is Nothing Then
                If Not actualizando Then
                    Dim item As Producto = CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto)
                    If existe2(item) Then
                        agrega2(item)
                    Else
                        listfinal.Add(item)
                    End If
                    total += item.Precio
                    actualizarListaRefacciones()
                Else
                    Dim item As Producto = CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto)
                    If existe2(item) Then
                        agrega2(item)
                    Else
                        Dim sit As New ServicioItem(0, 0, item.Descripcion, "REFACCION", "", 1, item.Costo, item.Precio, item.Id)
                        itemsrefact.Add(sit)
                    End If
                    total += item.Precio
                    llenarGridRefsAct()
                End If
                
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnProcServ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcServ.Click
        Try
            If lisserv Is Nothing Then
                MsgBox("Debes seleccionar al menos un servicio a realizar en el automovil")
                btnBuscarServicios.Focus()
            ElseIf itemsservact Is Nothing And actualizando Then
                MsgBox("Debes seleccionar al menos un servicio a realizar en el automovil")
                btnBuscarServicios.Focus()
            Else
                agregarDatosServicio()
                itemsServ = New List(Of ServicioItem)
                agregarServicios()
                agregarRefacciones()
                objserv.Items = itemsServ
                If Not actualizando Then
                    MsgBox("Servicio guardado con éxito. Folio del servicio: " & sserv.guardar(objserv))
                    resetForm(False)
                Else
                    sserv.actualizar(objserv)
                    MsgBox("Servicio actualizado con éxito")
                    resetForm(False)
                End If

            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub agregarDatosServicio()
        Try
            objserv.Id_Cliente = objC.Id
            objserv.Concecionaria = txtConc.Text
            objserv.Linea = txtLin.Text
            objserv.Tipo = txtTipo.Text
            objserv.Modelo = txtMod.Text
            objserv.Color = txtColor.Text
            objserv.Placas = txtPlacas.Text
            objserv.Diagnostico = txtDiag.Text
            objserv.Fecha_Recepcion = dtpS.Value
            objserv.Id_Personal = txtRec.Text
            objserv.Observaciones = txtObs.Text
            objserv.Kilometraje = txtKm.Text
            objserv.Mecanico = txtMec.Text
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub agregarRefacciones()
        Try
            If Not actualizando Then
                For Each refa As Producto In listfinal
                    Dim sasprod As New ServicioItem(refa.Descripcion, "REFACCION", "", refa.Cantidad, refa.Costo, refa.Precio, refa.Id)
                    itemsServ.Add(sasprod)
                Next
            Else
                For Each refa As ServicioItem In itemsrefact
                    If refa.IdServDetalle = 0 Then
                        itemsServ.Add(refa)
                    End If
                Next
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub agregarServicios()
        Try
            If Not actualizando Then
                For Each serv As ServicioP In lisserv
                    Dim sasprod As New ServicioItem(serv.Descripcion, "SERVICIO", "ESPERA", 1, serv.Costo, serv.Precio, serv.Id)
                    itemsServ.Add(sasprod)
                Next
            Else
                For Each serv As ServicioItem In itemsservact
                    If serv.IdServDetalle = 0 Then
                        itemsServ.Add(serv)
                    End If
                Next
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub resetForm(ByVal band As Boolean)
        Try

            txtColor.Text = ""
            txtConc.Text = ""
            txtDiag.Text = ""
            txtKm.Text = ""
            txtLin.Text = ""
            txtMec.Text = ""
            txtMod.Text = ""
            txtObs.Text = ""
            txtPlacas.Text = ""
            txtRec.Text = ""
            txtTipo.Text = ""
            total = 0.0
            lblTotal.Text = FormatCurrency(total)
            dgvServ.DataSource = Nothing
            dgvRefs.DataSource = Nothing
            dgvRefsF.DataSource = Nothing

            txtFolioS.Text = ""

            objserv = Nothing
            actualizando = False

            If Not band Then
                txtFolioC.Text = ""
                txtCliente.Text = ""
                objC = Nothing
            End If

            lisserv = Nothing
            servicio = Nothing
            listfinal = Nothing
            itemsServ = Nothing
            iniciarObjetos()

            gp3.Enabled = False
            gp4.Enabled = False
            tbcntrl.SelectedTab = tp1
            txtFolioC.Focus()

            lblservcomp.Text = ""
            lblFactura.Text = ""
            lblFechaEnt.Text = ""
            lblTitFechaE.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        resetForm(False)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sserv.obtener(8)
    End Sub


    'EMPIEZA EL TRACA TRACA DE ACTUALIZAR
    Private actualizando As Boolean = False
    Private itemsservact As List(Of ServicioItem)
    Private itemsrefact As List(Of ServicioItem)
    Private Sub btnObtener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtener.Click
        Try
            If txtFolioS.Text = "" Then
                MsgBox("Debes proporcionar el folio del servicio")
                txtFolioS.Select()
            Else
                objserv = sserv.obtener(txtFolioS.Text)
                actualizando = True
                llenarCampos()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message & ". No existe.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub llenarCampos()
        Try
            'CAMPOS
            txtFolioC.Text = objserv.Id_Cliente
            txtCliente.Text = objserv.NombreC
            txtConc.Text = objserv.Concecionaria
            txtLin.Text = objserv.Linea
            txtTipo.Text = objserv.Tipo
            txtColor.Text = objserv.Color
            txtMod.Text = objserv.Modelo
            txtKm.Text = objserv.Kilometraje
            txtPlacas.Text = objserv.Placas
            dtpS.Value = objserv.Fecha_Recepcion
            txtRec.Text = objserv.Id_Personal
            txtMec.Text = objserv.Mecanico
            txtDiag.Text = objserv.Diagnostico
            txtObs.Text = objserv.Observaciones
            total = 0.0
            lblTotal.Text = FormatCurrency(total)
            'OBJETOS
            objC = New Cliente
            objC.Id = objserv.Id_Cliente
            objC.Razon = objserv.NombreC
            'GRIDS
            itemsservact = New List(Of ServicioItem)
            itemsrefact = New List(Of ServicioItem)
            llenarListas()
            llenarGridServAct()
            llenarGridRefsAct()

            'ACTIVAR CAMPOS
            gp3.Enabled = True
            gp4.Enabled = True

            contenidoEtiquetasComp()
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub llenarListas()
        Try
            For Each it As ServicioItem In objserv.Items
                If it.Tipo.Trim = "SERVICIO" Then
                    itemsservact.Add(it)
                    total += it.Precio
                Else
                    itemsrefact.Add(it)
                    total += it.Precio * it.Cantidad
                End If
            Next
            lblTotal .Text = FormatCurrency (total )
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub llenarGridServAct()
        Try
            dgvServ.DataSource = Nothing
            With dgvServ
                .DataSource = itemsservact
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Width = 210
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).DefaultCellStyle.Format = "c"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).Width = 80
                .Columns(8).Visible = True 'asi queda
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .Columns(11).Visible = False
            End With
            lblTotal.Text = FormatCurrency(total)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub
    Private Sub llenarGridRefsAct()
        Try
            dgvRefsF.DataSource = Nothing
            With dgvRefsF
                .DataSource = itemsrefact
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Width = 210
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).DefaultCellStyle.Format = "c"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).Width = 80
                .Columns(8).Visible = True 'asi estaba
                .Columns(10).Visible = False
                .Columns(11).Visible = False
            End With
            lblTotal.Text = FormatCurrency(total)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFolioS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioS.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnObtener.PerformClick()
        End If
    End Sub

    Private Sub btnSXC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSXC.Click
        Try
            If objC Is Nothing Then
                MsgBox("Debes seleccionar un cliente para mostrar los servicios que le corresponden")
                txtFolioC.Select()
            Else
                Dim frm As New frmHistAutos(sserv, objC.Id, objC.Razon, True)
                frm.ShowDialog()
                If Not frm.ids = 0 Then
                    txtFolioS.Text = frm.ids
                    btnObtener.PerformClick()
                End If
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub contenidoEtiquetasComp()
        If objserv.Completo Then
            lblservcomp.Text = "Servicio Completo"
            lblservcomp.ForeColor = Color.Gold
            lblTitFechaE.Visible = True
            lblFechaEnt.Text = objserv.Fecha_Entrega
            lblFechaEnt.ForeColor = Color.LimeGreen
            If objserv.Factura Then
                lblFactura.Text = "Factura: Si"
                lblFactura.ForeColor = Color.LimeGreen
            Else
                lblFactura.Text = "Factura: No"
                lblFactura.ForeColor = Color.Firebrick
            End If
        Else
            lblservcomp.Text = "Servicio Incompleto"
            lblservcomp.ForeColor = Color.Crimson
        End If
    End Sub

    Private Sub frmRecepServicio_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class