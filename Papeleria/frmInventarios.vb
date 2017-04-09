''Imports MonoReports.Model
Imports LogicaNegocio
Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text


Public Class frmInventarios
    Private busqueda As Service_Producto = Nothing
    Private tipoBusqueda As Integer = 0
    Private listaProductos As List(Of BuscadorProductos)



    Private Sub frmInventarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ClearMemory()
    End Sub
    Private Sub frmInventarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''negritasHeader()
        txtProducto.Focus()
        Me.KeyPreview = True
        dgvP.DataSource = Nothing
        busqueda = New Service_Producto
        busqueda.IniciarBusqueda()
        verInventarios()
        dgvP.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub verInventarios()
        Try
            If Not busqueda Is Nothing Then
                If rbCodigo.Checked = True Then
                    tipoBusqueda = 0
                ElseIf rbDescripcion.Checked = True Then
                    tipoBusqueda = 1
                ElseIf rbCategoria.Checked = True Then
                    tipoBusqueda = 2
                ElseIf rbTodo.Checked = True Then
                    tipoBusqueda = 3
                End If

                listaProductos = busqueda.Inventario(txtProducto.Text, tipoBusqueda)
                dgvP.DataSource = listaProductos
                lblTotal.Text = listaProductos.Count
                formatoDG()
                listaProductos = Nothing
            End If
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub formatoDG()

        dgvP.Columns(0).Width = 50
        dgvP.Columns(1).Visible = False 'Idproducto
        dgvP.Columns(1).Frozen = True
        dgvP.Columns(2).Frozen = True
        dgvP.Columns(3).Frozen = True
        dgvP.Columns(3).Width = 280 'Descripcion
        dgvP.Columns(4).Width = 75 'Existencia
        dgvP.Columns(5).Width = 75 'PzasCaja
        dgvP.Columns(5).HeaderText = "PIEZAS"
        dgvP.Columns(6).Width = 75 'Min
        dgvP.Columns(7).Width = 75 'Max
        dgvP.Columns(8).Width = 170 'Linea
        dgvP.Columns(9).Width = 80
        dgvP.Columns(10).Width = 80
        dgvP.Columns(12).Width = 80
        dgvP.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Precio
        dgvP.Columns(9).DefaultCellStyle.Format = "c"
        dgvP.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Menudeo
        dgvP.Columns(10).DefaultCellStyle.Format = "c"
        dgvP.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Costo
        dgvP.Columns(12).DefaultCellStyle.Format = "c"

        dgvP.Columns(11).Width = 75

        dgvP.Columns(13).Visible = False 'idlinea
        dgvP.Columns(14).Visible = False 'status2
        dgvP.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Precio Unitario
        dgvP.Columns(15).DefaultCellStyle.Format = "c"
    End Sub
    Private Sub alinearEncabezadoGrid()
        Try
            For x As Integer = 0 To dgvP.Columns.Count - 1
                dgvP.Columns(x).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Sub negritasHeader()
    '    Dim cellStyle As New DataGridViewCellStyle

    '    cellStyle.Font = New Font("Arial", 7.5, FontStyle.Bold)

    '    dgvP.ColumnHeadersDefaultCellStyle = cellStyle

    'End Sub
    Private Sub txtProducto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.TextChanged
        If Not txtProducto.Text.Trim.Length <= 0 Then
            verInventarios()
        Else
            dgvP.DataSource = Nothing
            lblTotal.Text = 0
        End If
    End Sub
    Private Sub frmInventarios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        enddb()
    End Sub
    Private Sub enddb()
        If Not busqueda Is Nothing Then
            busqueda.finalizarBusqueda()
            busqueda = Nothing
        End If
    End Sub


    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub frmBuscadorInventarios_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    ''' <summary>
    ''' Genera el reporte en pdf con la clase ItextSharp
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ImprimirInventario()
        Dim pdf As Document = Nothing
        Dim writer As PdfWriter = Nothing
        Dim table As PdfPTable = Nothing
        Try
            Dim folder As String = Configuration.ConfigurationManager.AppSettings("Folder").ToString()
            Dim archivo As String = "Inventario - " & DateTime.Now.ToString("dd-MM-yyyy HH_mm") & ".pdf"
            Dim path__1 As String = Path.Combine(folder, archivo)
            Dim cambiaColor As Boolean
            pdf = New iTextSharp.text.Document()
            pdf.SetPageSize(PageSize.LETTER)
            writer = PdfWriter.GetInstance(pdf, File.Open(path__1, FileMode.Create))
            pdf.Open()

            Dim noColumns As Integer = IIf(chkCosto.Checked, 7, 6)
            noColumns += IIf(chkPrecioSugerido.Checked, 1, 0)

            table = New PdfPTable(noColumns)
            table.WidthPercentage = 100

            Dim widths As Single() = Nothing

            Select Case noColumns
                Case 6
                    widths = New Single() {4.5F, 4.0F, 15.0F, 2.0F, 3.0F, 3.0F}
                Case 7
                    widths = New Single() {4.5F, 4.0F, 15.0F, 2.0F, 3.0F, 3.0F, 3.0F}
                Case 8
                    widths = New Single() {4.5F, 4.0F, 15.0F, 2.0F, 3.0F, 3.0F, 3.0F, 3.0F}
            End Select

            table.SetWidths(widths)
            table.HorizontalAlignment = 0
            table.SpacingBefore = 20.0F
            table.SpacingAfter = 30.0F
            table.HeaderRows = 3
            myfont = FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.BOLD)
            CrearEncabezado(table, noColumns)
            myfont = FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL)

            For Each item As BuscadorProductos In TryCast(dgvP.DataSource, List(Of BuscadorProductos)).Where(Function(i) i.Selecciona).ToList()
                CrearColumna(item.CLAVE, 3, table, True, cambiaColor)
                CrearColumna(item.LINEA, 3, table, True, cambiaColor)
                CrearColumna(item.DESCRIPCION & "/" & item.PZAS, 3, table, False, cambiaColor)
                CrearColumna(item.EXISTENCIA, 2, table, False, cambiaColor)
                If chkCosto.Checked Then
                    CrearColumna(String.Format("{0:c}", item.COSTO), 2, table, False, cambiaColor)
                End If
                CrearColumna(String.Format("{0:c}", item.PRECIO), 2, table, False, cambiaColor)
                CrearColumna(String.Format("{0:c}", item.PrecioUnitario), 2, table, False, cambiaColor)
                If chkPrecioSugerido.Checked Then
                    CrearColumna(String.Format("{0:c}", item.PrecioUnitario + (item.PrecioUnitario * (txtPorcentaje.Text) / 100)), 2, table, False, cambiaColor)
                End If
                cambiaColor = Not cambiaColor
            Next

            pdf.Add(table)


            Dim parrafo As New Paragraph(Sesion.conf.Sistema, myfont)
            parrafo.Alignment = Element.ALIGN_CENTER
            pdf.Add(parrafo)

            parrafo = New Paragraph(Sesion.conf.Calle & ", " & Sesion.conf.No_ext & ", " & Sesion.conf.Colonia, myfont)
            parrafo.Alignment = Element.ALIGN_CENTER
            pdf.Add(parrafo)

            parrafo = New Paragraph(Sesion.conf.Ciudad & ", " & Sesion.conf.estado, myfont)
            parrafo.Alignment = Element.ALIGN_CENTER
            pdf.Add(parrafo)

            parrafo = New Paragraph("C.P. " & Sesion.conf.CP, myfont)
            parrafo.Alignment = Element.ALIGN_CENTER
            pdf.Add(parrafo)

            parrafo = New Paragraph("Tel: " & Sesion.conf.Telefono, myfont)
            parrafo.Alignment = Element.ALIGN_CENTER
            pdf.Add(parrafo)

            pdf.Close()
            pdf.Dispose()
            Process.Start(path__1)

        Catch ex As Exception

        Finally
            If Not pdf Is Nothing Then
                pdf.Close()
                pdf.Dispose()
            End If

            If Not writer Is Nothing Then
                writer.Close()
                writer.Dispose()
            End If

            If Not table Is Nothing Then
                table = Nothing
            End If

        End Try

    End Sub
    Private cell As PdfPCell
    Private myfont As iTextSharp.text.Font
    Private myfontLine As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA, 7, iTextSharp.text.Font.NORMAL)

    ''' <summary>
    ''' Crear las columnas de la tabla
    ''' </summary>
    ''' <param name="text">Texto de la columna</param>
    ''' <param name="tabla">tabla a la que se agregan las columnas</param>
    ''' <param name="Alineacion">Alineacion del texto 
    ''' 1 centro
    ''' 2 derecha
    ''' </param>
    ''' <remarks></remarks>
    Private Sub CrearColumna(ByVal text As String, ByVal Alineacion As Integer, ByRef tabla As PdfPTable, Optional ByVal FontPequeña As [Boolean] = False, Optional ByVal cambiaColor As [Boolean] = False)

        If FontPequeña Then
            cell = New PdfPCell(New Paragraph(text, myfontLine))
        Else
            cell = New PdfPCell(New Paragraph(text, myfont))
        End If
        cell.Border = 0
        'If DibujarBorde Then
        '    cell.BorderWidthBottom = 1.0F
        'End If
        If cambiaColor Then
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        End If
        cell.HorizontalAlignment = Alineacion
        tabla.AddCell(cell)
    End Sub

    ''' <summary>
    ''' Crear el encabezado de la tabla del reporte
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Private Sub CrearEncabezado(ByRef table As PdfPTable, ByVal noColumns As Integer)

        cell = New PdfPCell(New iTextSharp.text.Phrase(Sesion.conf.Sistema))
        cell.Colspan = noColumns - 1
        cell.Border = 0
        cell.HorizontalAlignment = 1
        table.AddCell(cell)
        CrearColumna("Fecha", 1, table)

        cell = New PdfPCell(New iTextSharp.text.Phrase("INVENTARIO"))
        cell.Colspan = noColumns - 1
        cell.Border = 0
        cell.HorizontalAlignment = 1
        table.AddCell(cell)

        CrearColumna(Date.Now.ToString("dd/MM/yy"), 2, table)
        CrearColumna("Clave", 3, table)
        CrearColumna("Línea", 3, table)
        CrearColumna("Descripción / No. Piezas", 3, table)
        CrearColumna("Exist.", 3, table)
        If chkCosto.Checked Then
            CrearColumna("Costo", 2, table)
        End If
        CrearColumna("Precio", 2, table)
        CrearColumna("P.U.", 2, table)
        If chkPrecioSugerido.Checked Then
            CrearColumna("P.S. " & txtPorcentaje.Text & " %", 2, table)
        End If
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Not dgvP.DataSource Is Nothing Then

                Dim deseleccionar As Boolean = False
                If TryCast(dgvP.DataSource, List(Of BuscadorProductos)).Where(Function(i) i.Selecciona).Count = 0 Then
                    If MsgBox("No ha seleccionado ningun producto, desea generar el reporte con todos los productos del inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    deseleccionar = True
                    For Each item As BuscadorProductos In TryCast(dgvP.DataSource, List(Of BuscadorProductos))
                        item.Selecciona = True
                    Next
                End If
                ImprimirInventario()

                If deseleccionar Then
                    For Each item As BuscadorProductos In TryCast(dgvP.DataSource, List(Of BuscadorProductos))
                        item.Selecciona = False
                    Next
                End If

                'Dim lista As List(Of BuscadorProductos) = New List(Of BuscadorProductos)
                'Dim producto As BuscadorProductos
                'For i As Integer = 0 To dgvP.RowCount - 1

                '    If dgvP.Rows(i).Cells(0).Value Then
                '        producto = (dgvP.Rows(i).DataBoundItem)

                '        If chkPrecio.Checked = False Then
                '            producto.COSTO = 0
                '        End If

                '        lista.Add(producto)
                '    End If

                'Next


                'Dim rep As New Report

                'If lista.Count = 0 Then
                '    Dim A = MsgBox("No ha seleccionado ningun producto, desea generar el reporte con todos los productos del inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                '    If A = vbYes Then
                '        rep.DataSource = dgvP.DataSource
                '    Else
                '        Exit Sub
                '    End If
                'Else
                '    rep.DataSource = lista
                'End If


                'rep.Load("Reportes\inventario.mrp")

                'Dim file As String = My.Computer.FileSystem.GetTempFileName

                'rep.ExportToPdf(file & ".pdf")
                'System.Diagnostics.Process.Start(file & ".pdf")

                'rep = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Public Sub ClearMemory()
        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Catch ex As Exception
            'Control de errores
        End Try

    End Sub

    Private Sub chkSeleccionar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeleccionar.CheckedChanged

        Dim valor As Boolean = False
        If chkSeleccionar.Checked = True Then
            valor = True
        Else
            valor = False
        End If

        For i As Integer = 0 To dgvP.RowCount - 1
            dgvP.Rows(i).Cells(0).Value = valor
        Next

    End Sub

    Private Sub chkPrecio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCosto.CheckedChanged


    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txtPorcentaje_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If e.KeyChar = Convert.ToChar(8) Then ' se pulsó Retroceso
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

    Private Sub chkPrecioSugerido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrecioSugerido.CheckedChanged

        If chkPrecioSugerido.Checked Then
            txtPorcentaje.Visible = True
            lblPorcentaje.Visible = True
        Else
            txtPorcentaje.Visible = False
            lblPorcentaje.Visible = False
        End If

    End Sub
End Class