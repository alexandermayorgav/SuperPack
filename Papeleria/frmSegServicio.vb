Imports LogicaNegocio
Public Class frmSegServicio
    Private objC As Cliente
    Private sCl As Service_Cliente
    Private objserv As Servicio
    Private sserv As Service_Servicio
    Private servs As List(Of ServicioItem)
    Private refs As List(Of ServicioItem)

    Private item As VentaItem
    Private venta As Venta

    Private Sub frmSegServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        iniciarObjetos()
    End Sub

    Private Sub iniciarObjetos()
        sserv = New Service_Servicio
        objserv = New Servicio
        servs = New List(Of ServicioItem)
        refs = New List(Of ServicioItem)
        sCl = New Service_Cliente
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
    Private Sub obtenerCliente()
        Try
            If txtFolioC.Text = "" Then
                MsgBox("Debes proporcionar el folio del cliente")
                txtFolioC.Select()
                txtFolioC.Focus()
            Else
                objC = sCl.Obtener(CInt(txtFolioC.Text))
                txtCliente.Text = objC.Razon
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
            txtFolioC.Focus()
            txtFolioC.SelectAll()
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

    Private Sub btnObtener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtener.Click
        Try
            If txtFolioS.Text = "" Then
                MsgBox("Debes proporcionar el folio del servicio")
                txtFolioS.Select()
            Else
                objserv = sserv.obtener(txtFolioS.Text)
                txtFolioC.Text = objserv.Id_Cliente
                txtCliente.Text = objserv.NombreC
                llenarListas()
                actualizarGridServs()
                actualizarGridRefs()
                getColores()
                getColoresRefs()
                btnCompleto.Enabled = True
                btnProcV.Enabled = True
                contenidoEtiquetasComp()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message & ". No existe.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub contenidoEtiquetasComp()
        If objserv.Completo Then
            lblservcomp.Text = "Servicio Completo"
            lblservcomp.ForeColor = Color.LimeGreen
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

    Private Sub llenarListas()
        Try
            servs.Clear()
            refs.Clear()
            Dim sprod As New Service_Producto
            For Each it As ServicioItem In objserv.Items
                If it.Tipo.Trim = "SERVICIO" Then
                    Dim prod As Producto = sprod.ObtenerPorId(it.IdProducto)
                    it.Producto = prod
                    servs.Add(it)

                Else
                    If it.Estado = "" Then
                        it.Estado = "NO IMPLEMENTADA"
                    End If
                    Dim prod As Producto = sprod.ObtenerPorId(it.IdProducto)
                    it.Producto = prod
                    refs.Add(it)

                End If
                
            Next
            'lblTotal.Text = FormatCurrency(total)
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub actualizarGridServs()
        Try
            dgvServ.DataSource = Nothing
            With dgvServ
                .DataSource = servs
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Width = 210
                .Columns(5).Visible = False
                .Columns(6).Visible = True
                .Columns(6).Width = 140
                .Columns(7).Visible = False
                .Columns(8).DefaultCellStyle.Format = "c"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).Width = 80
                .Columns(8).Visible = True 'asi queda
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .Columns(11).Visible = False
            End With
            ' lblTotal.Text = FormatCurrency(total)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub actualizarGridRefs()
        Try
            dgvRefs.DataSource = Nothing
            With dgvRefs
                .DataSource = refs
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Width = 210
                .Columns(5).Visible = False
                .Columns(6).Visible = True
                .Columns(6).Width = 140
                .Columns(7).Visible = False
                .Columns(8).DefaultCellStyle.Format = "c"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).Width = 80
                .Columns(8).Visible = True
                .Columns(9).Width = 60
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(10).Visible = False
                .Columns(11).Visible = False
            End With
            'lblTotal.Text = FormatCurrency(total)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFolioS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioS.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnObtener.PerformClick()
        End If
    End Sub
    Private Sub frmSegServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub dgvRefs_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvRefs.MouseDown
        Try
            Dim hit As DataGridView.HitTestInfo
            With dgvRefs
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    hit = .HitTest(e.X, e.Y)
                    .CurrentCell = .Rows(hit.RowIndex).Cells(hit.ColumnIndex)

                    If hit.Type = DataGridViewHitTestType.Cell And hit.ColumnIndex = 6 Or hit.ColumnIndex = 8 Or hit.ColumnIndex = 9 Or hit.ColumnIndex = 4 Then
                        cmsrefs.Show(dgvRefs, New Point(e.X, e.Y))
                    End If

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvServ_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvServ.MouseDown
        Try
            Dim hit As DataGridView.HitTestInfo
            With dgvServ
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    hit = .HitTest(e.X, e.Y)
                    .CurrentCell = .Rows(hit.RowIndex).Cells(hit.ColumnIndex)

                    If hit.Type = DataGridViewHitTestType.Cell And hit.ColumnIndex = 6 Or hit.ColumnIndex = 8 Or hit.ColumnIndex = 4 Then
                        cmsserv.Show(dgvServ, New Point(e.X, e.Y))
                    End If

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ESPERAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ESPERAToolStripMenuItem.Click
        Try
            Dim r As Short = dgvServ.CurrentRow.Index
            If Not dgvServ.CurrentRow.Cells(6).Value = "ESPERA" Then
                Dim idsd As Integer = dgvServ.CurrentRow.Cells(2).Value
                sserv.actEstadoServicio("ESPERA", idsd)
                actualizaEnLista("ESPERA", idsd)
                actualizarGridServs()
                getColores()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub COMPLETOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMPLETOToolStripMenuItem.Click
        Try
            Dim r As Short = dgvServ.CurrentRow.Index
            If Not dgvServ.CurrentRow.Cells(6).Value = "COMPLETO" Then
                Dim idsd As Integer = dgvServ.CurrentRow.Cells(2).Value
                sserv.actEstadoServicio("COMPLETO", idsd)
                actualizaEnLista("COMPLETO", idsd)
                actualizarGridServs()
                getColores()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub NOSEAPLICOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOSEAPLICOToolStripMenuItem.Click
        Try
            Dim r As Short = dgvServ.CurrentRow.Index
            If Not dgvServ.CurrentRow.Cells(6).Value = "NO SE APLICO" Then
                Dim idsd As Integer = dgvServ.CurrentRow.Cells(2).Value
                sserv.actEstadoServicio("NO SE APLICO", idsd)
                actualizaEnLista("NO SE APLICO", idsd)
                actualizarGridServs()
                getColores()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub actualizaEnLista(ByVal valor As String, ByVal idprod As Integer)
        Try
            For Each serv As ServicioItem In servs
                If serv.IdServDetalle = idprod Then
                    serv.Estado = valor
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub actualizaEnListaRefs(ByVal valor As String, ByVal idprod As Integer)
        Try
            For Each refa As ServicioItem In refs
                If refa.IdServDetalle = idprod Then
                    refa.Estado = valor
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub getColores()
        Try
            With dgvServ
                Dim i As Integer
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells(6).Value = "ESPERA" Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Gold
                    ElseIf .Rows(i).Cells(6).Value = "COMPLETO" Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    ElseIf .Rows(i).Cells(6).Value = "NO SE APLICO" Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.PaleVioletRed
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub getColoresRefs()
        Try
            With dgvRefs
                Dim i As Integer
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells(6).Value = "IMPLEMENTADA" Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    ElseIf .Rows(i).Cells(6).Value = "NO IMPLEMENTADA" Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.PaleVioletRed
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    
    Private Sub IMPLEMENTADA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMPLEMENTADA.Click
        Try
            Dim r As Short = dgvRefs.CurrentRow.Index
            Dim item As ServicioItem = CType(dgvRefs.CurrentRow.DataBoundItem, ServicioItem)
            If Not dgvRefs.CurrentRow.Cells(6).Value = "IMPLEMENTADA" Then
                Dim idsd As Integer = dgvRefs.CurrentRow.Cells(2).Value
                sserv.actEstadoRefa("IMPLEMENTADA", idsd, item, True)
                actualizaEnListaRefs("IMPLEMENTADA", idsd)
                actualizarGridRefs()
                getColoresRefs()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NOIMPLEMENTADA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOIMPLEMENTADA.Click
        Try
            Dim r As Short = dgvRefs.CurrentRow.Index
            Dim item As ServicioItem = CType(dgvRefs.CurrentRow.DataBoundItem, ServicioItem)
            If Not dgvRefs.CurrentRow.Cells(6).Value = "NO IMPLEMENTADA" Then
                Dim idsd As Integer = dgvRefs.CurrentRow.Cells(2).Value
                sserv.actEstadoRefa("NO IMPLEMENTADA", idsd, item, False)
                actualizaEnListaRefs("NO IMPLEMENTADA", idsd)
                actualizarGridRefs()
                getColoresRefs()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCompleto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleto.Click
        If Not objserv.Completo Then
            Dim conf = MsgBox("¿Marcar el servicio como completo?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If conf = vbYes Then
                sserv.servicioCompleto(objserv.Id_Servicio, True)
                objserv.Completo = True
                contenidoEtiquetasComp()
            End If
        Else
            Dim conf = MsgBox("El servicio ya esta marcado como completo," & Chr(13) & "¿Deseas cambiar su status a incompleto?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If conf = vbYes Then
                sserv.servicioCompleto(objserv.Id_Servicio, False)
                objserv.Completo = False
                contenidoEtiquetasComp()
            End If
        End If
       
    End Sub

    Private Sub btnProcV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcV.Click
        Try
            If Not objserv.Completo Then
                Dim conf = MsgBox("El servicio aun no esta marcado como completo," & Chr(13) & "¿Deseas que se marque el servicio como completo y posteriormente procesar el mismo como venta?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If conf = vbYes Then
                    sserv.servicioCompleto(objserv.Id_Servicio, True)
                    objserv.Completo = True
                    contenidoEtiquetasComp()

                    '*******ACCIONES/FORMA VENTA
                    venta = New Venta
                    venta.Id_cliente = objserv.Id_Cliente
                    venta.Id_Servicio = objserv.Id_Servicio
                    venta.venderSinExistencia = Sesion.venderSinExis
                    venta.ivaValor = Sesion.iva

                    For Each it As ServicioItem In servs
                        If it.Estado = "COMPLETO" Then
                            it.Producto.Existencia = 1 '********IDEA DEL CHINO(CODIGO AJENO A MI INTELECTO)
                            item = New VentaItem(it.Cantidad, 0, it.Producto)
                            item.TipoPromocion = "Servicio"
                            venta.AgregarItem(item)
                        End If

                    Next
                    For Each it As ServicioItem In refs
                        If it.Estado = "IMPLEMENTADA" Then
                            item = New VentaItem(it.Cantidad, 0, it.Producto)
                            item.TipoPromocion = "Servicio"
                            venta.AgregarItem(item)
                        End If
                    Next

                    Dim frm As New frmVenta
                    frm.venta = venta
                    frm.servicios = True
                    frm.Show()
                    frm.ActualizarGrid()

                    'Dim fact = MsgBox("¿Deseas generar factura?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                    'If fact = vbYes Then
                    '    '******SE GENERA LA FACTURA
                    '    sserv.generoFactura(objserv.Id_Servicio)
                    '    objserv.Factura = True
                    '    contenidoEtiquetasComp()
                    'End If
                Else
                    btnCompleto.Focus()
                End If
            Else
                If Not objserv.Completo And objserv.Factura Then
                    Dim conf2 = MsgBox("¿Procesar el servicio como venta?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                    If conf2 = vbYes Then
                        '*******ACCIONES/FORMA VENTA
                        Dim fact = MsgBox("¿Deseas generar factura?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                        If fact = vbYes Then
                            '******SE GENERA LA FACTURA
                            sserv.generoFactura(objserv.Id_Servicio)
                            objserv.Factura = True
                            contenidoEtiquetasComp()
                        End If
                    End If
                Else
                    MsgBox("El servicio ya ha sido registrado como venta." & Chr(13) & IIf(objserv.Factura, " Generó factura", "No Generó factura"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFolioC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioC.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnObtenerC.PerformClick()
        End If
    End Sub

    Private Sub frmSegServicio_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
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