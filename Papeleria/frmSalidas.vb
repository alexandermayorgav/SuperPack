Imports LogicaNegocio
Public Class frmSalidas
    Private salida As CSalida
    Private item As CSalidaDetalle
    Private salidaservice As Service_Salida
    Private compraservice As Service_Compra
    Private producto As Producto
    Private Sub frmSalidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NuevaSalida()
        Me.KeyPreview = True
    End Sub
    Private Sub frmSalidas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                btnbuscarprod.PerformClick()
            Case Keys.F5
                btnFinalizar.PerformClick()
            Case Keys.F6
                btnversalida.PerformClick()
            Case Keys.F7
                btnNueva.PerformClick()
            Case Keys.F9
                btnagregar.PerformClick()
        End Select
    End Sub
    Sub NuevaSalida()
        Try
            salida = New CSalida
            item = New CSalidaDetalle
            producto = New Producto

            txtdescripcionprod.Text = ""
            txtcodigo.Text = ""
            lblExistencia.Text = ""
            txtcantidad.Text = ""
            txtcosto.Text = ""
            DGVSalidas.Rows.Clear()
            btnFinalizar.Enabled = True
            btnbuscarprod.Enabled = True
            btnagregar.Enabled = True
            txtfolio.Text = ""
            txtcodigo.Focus()
            labelfecha.Visible = False
            fechasalida.Visible = False
            txtcantidad.Enabled = True
            txtcosto.Enabled = True
            txtcodigo.Enabled = True
            txtcodigo.Focus()
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
            txtdescripcionprod.Text = producto.Descripcion
            lblExistencia.Text = producto.Existencia
            txtcantidad.Focus()
            txtcosto.Text = String.Format("{0:c}", producto.Costo)
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        AgregarProducto()
    End Sub
    Sub AgregarProducto()
        If txtdescripcionprod.Text = "" Then
            MsgBox("Seleccione un producto")
            txtcodigo.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtcantidad.Text) Then
            MsgBox("La cantidad de salida debe ser un número")
            txtcantidad.Focus()
            txtcantidad.Text = ""
            Exit Sub
        ElseIf CDec(lblExistencia.Text) < 1 Then
            MsgBox("No puedes dar salida a este producto porque no hay en existencia")
            txtcodigo.Focus()
            txtcosto.Text = ""
            Exit Sub
        ElseIf CDec(txtcantidad.Text) < 1 Then
            MsgBox("La cantidad de salida debe ser mayor a cero")
            txtcantidad.Focus()
            txtcantidad.Text = ""
            Exit Sub
        ElseIf CDec(txtcantidad.Text) > CDec(lblExistencia.Text) Then
            MsgBox("La cantidad de salida no debe ser mayor a la existencia en almacen")
            txtcantidad.Focus()
            txtcantidad.Text = ""
            Exit Sub
        End If

        item = New CSalidaDetalle(producto, txtcantidad.Text, txtcosto.Text)

        salida.AgregarItemSalida(item)

        ActualizarGrid()
    End Sub
    Private Sub ActualizarGrid()

        Dim R As Short = 0
        Dim totalSalida As Decimal = 0

        DGVSalidas.Rows.Clear()

        For Each item As CSalidaDetalle In salida._salidaitems
            totalSalida += item.Cantidad * item.Costo
            With DGVSalidas
                .Rows.Add()
                R = .RowCount - 1
                .Rows(R).Cells("codigo").Value = item.Producto.Codigo
                .Rows(R).Cells("desc").Value = item.Producto.Descripcion
                .Rows(R).Cells("cantidad").Value = item.Cantidad
                .Rows(R).Cells("costo").Value = item.Costo
            End With

        Next


        Dim fuente As New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel, 4)

        DGVSalidas.Font = fuente


        DGVSalidas.Columns(0).Width = 60


        Dim renglo As Integer = DGVSalidas.RowCount - 1

        If Not renglo <= 0 Then
            DGVSalidas.FirstDisplayedScrollingRowIndex = DGVSalidas.Rows(renglo).Index
        End If

        DGVSalidas.Columns(0).Width = 100
        DGVSalidas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVSalidas.Columns(1).Width = 370
        DGVSalidas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVSalidas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVSalidas.Columns(2).Width = 65

        DGVSalidas.Columns(3).Width = 120
        DGVSalidas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVSalidas.Columns(3).DefaultCellStyle.Format = "c"

        txtTotalSalida.Text = String.Format("{0:c}", totalSalida)

        txtdescripcionprod.Text = ""
        txtcodigo.Text = ""
        lblExistencia.Text = ""
        txtcantidad.Text = ""
        txtcosto.Text = ""
        btnFinalizar.Enabled = True
        btnbuscarprod.Enabled = True
        btnagregar.Enabled = True
        txtcodigo.Focus()
    End Sub

    Private Sub btnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueva.Click
        NuevaSalida()
    End Sub

    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        ProcesarSalida()
    End Sub
    Sub ProcesarSalida()
        Try
            salidaservice = New Service_Salida

            If salida._salidaitems.Count = 0 Then
                MsgBox("No hay productos en la salida")
                Exit Sub
            End If

            'asignacion temporal
            id_usuario_sesion = 1

            salida.Usuario = id_usuario_sesion
            salida.Fecha = Date.Now

            salidaservice.insertar(salida)

            MsgBox("Salida Guardada Correctamente.")
            'txtfolio.Text = salida.Id
            NuevaSalida()
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btnvercompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnversalida.Click
        VerSalida()
    End Sub
    Sub VerSalida()
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
        salidaservice = New Service_Salida
        Dim folio As Integer
        folio = txtfolio.Text
        salida = salidaservice.ObtenerSalida(folio)
        If salida.Id > 0 Then
            ActualizarGrid()
            labelfecha.Visible = True
            fechasalida.Visible = True
            fechasalida.Text = salida.Fecha
            btnFinalizar.Enabled = False
            btnbuscarprod.Enabled = False
            btnagregar.Enabled = False
            txtcantidad.Enabled = False
            txtcosto.Enabled = False
            txtcodigo.Enabled = False
        End If
    End Sub
    Private Sub DGVSalidas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVSalidas.KeyDown
        If e.KeyCode = 46 Then
            Dim del As String = DGVSalidas.CurrentRow.Cells(0).Value
            Try
                salida.BorraItem(del)
                ActualizarGrid()
                txtcodigo.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Not salida Is Nothing Then
            If salida.ItemsS.Count > 0 Then
                Dim message = MsgBox("La salida actual se cerrará y los datos se perderán." & "¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
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
    Private Sub frmSalidas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    Private Sub txtcantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            AgregarProducto()
        End If
    End Sub

    Private Sub txtfolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfolio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            VerSalida()
        End If
    End Sub
End Class