Imports LogicaNegocio
Imports MonoReports.Model


Public Class frmFaltantes
    Private busqueda As Service_Producto = Nothing
    Private lista As List(Of Faltantes)

    Private Sub frmFaltantes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ClearMemory()
    End Sub
    Private Sub frmFaltantes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmFaltantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            negritasHeader()
            'formatDGProducto()
            ' formatoGridFalta()
            todosFaltantes()
            dgvProducto.DataSource = Nothing
            busqueda = New Service_Producto
            busqueda.IniciarBusqueda()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub todosFaltantes()
        Try
            Dim service As Service_Producto = Nothing
            service = New Service_Producto

            lista = service.faltantesTodos()
            dgvFalta.DataSource = lista
            formatoGridFalta()
            ' lista = Nothing

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatoGridFalta()
        dgvFalta.Columns(1).Frozen = True
        dgvFalta.Columns(2).Frozen = True
        dgvFalta.Columns(3).Frozen = True

        dgvFalta.Columns(0).Visible = False 'idproducto
        dgvFalta.Columns(1).HeaderText = "CLAVE"
        dgvFalta.Columns(2).HeaderText = "DESCRIPCIÓN"


        dgvFalta.Columns(5).HeaderText = "COSTO"
        dgvFalta.Columns(6).HeaderText = "PRECIO"
        dgvFalta.Columns(7).HeaderText = "STOCK_MIN"
        dgvFalta.Columns(8).HeaderText = "STOCK_MAX"
        dgvFalta.Columns(4).HeaderText = "EXISTENCIA"
        dgvFalta.Columns(3).HeaderText = "PIEZAS"
        dgvFalta.Columns(9).HeaderText = "LINEA"
        dgvFalta.Columns(10).HeaderText = "PROVEEDORES"

        dgvFalta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvFalta.Columns(5).DefaultCellStyle.Format = "c"
        dgvFalta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvFalta.Columns(6).DefaultCellStyle.Format = "c"
        dgvFalta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvFalta.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvFalta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvFalta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvFalta.Columns(2).Width = "250"

        dgvFalta.Columns(7).Width = "75"
        dgvFalta.Columns(8).Width = "75"
        dgvFalta.Columns(4).Width = "75"
        dgvFalta.Columns(3).Width = "75"
        dgvFalta.Columns(9).Width = "120"
        dgvFalta.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvFalta.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        alinearEncabezadoGridF()

    End Sub
    Private Sub alinearEncabezadoGridF()
        Try
            For x As Integer = 0 To dgvFalta.Columns.Count - 1
                dgvFalta.Columns(x).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub alinearEncabezadoGridP()
        Try
            For x As Integer = 0 To dgvProducto.Columns.Count - 1
                dgvProducto.Columns(x).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatDGProducto()
        dgvProducto.Columns(1).Frozen = True
        dgvProducto.Columns(2).Frozen = True
        dgvProducto.Columns(3).Frozen = True
        'dgvProducto.Columns(0).Visible = False 'idproducto
        'dgvProducto.Columns(1).HeaderText = "CLAVE"
        'dgvProducto.Columns(2).HeaderText = "DESCRIPCIÓN"
        'dgvProducto.Columns(3).HeaderText = "COSTO"
        'dgvProducto.Columns(4).HeaderText = "PRECIO"
        'dgvProducto.Columns(5).HeaderText = "STOCK_MIN"
        'dgvProducto.Columns(6).HeaderText = "STOCK_MAX"
        'dgvProducto.Columns(7).HeaderText = "EXISTENCIA"
        'dgvProducto.Columns(8).HeaderText = "PIEZAS"
        'dgvProducto.Columns(9).HeaderText = "LINEA"


        'dgvProducto.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvProducto.Columns(3).DefaultCellStyle.Format = "c"
        'dgvProducto.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvProducto.Columns(4).DefaultCellStyle.Format = "c"
        'dgvProducto.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgvProducto.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgvProducto.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgvProducto.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'dgvProducto.Columns(2).Width = "250"
        'dgvProducto.Columns(5).Width = "75"
        'dgvProducto.Columns(6).Width = "75"
        'dgvProducto.Columns(7).Width = "75"
        'dgvProducto.Columns(8).Width = "75"
        'dgvProducto.Columns(9).Width = "120"
        dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProducto.Columns(0).Visible = False 'idproducto
        dgvProducto.Columns(1).HeaderText = "CLAVE"
        dgvProducto.Columns(2).HeaderText = "DESCRIPCIÓN"



        dgvProducto.Columns(5).HeaderText = "COSTO"
        dgvProducto.Columns(6).HeaderText = "PRECIO"
        dgvProducto.Columns(7).HeaderText = "STOCK_MIN"
        dgvProducto.Columns(8).HeaderText = "STOCK_MAX"
        dgvProducto.Columns(4).HeaderText = "EXISTENCIA"
        dgvProducto.Columns(3).HeaderText = "PIEZAS"
        dgvProducto.Columns(9).HeaderText = "LINEA"
        dgvProducto.Columns(10).HeaderText = "PROVEEDORES"

        dgvProducto.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvProducto.Columns(5).DefaultCellStyle.Format = "c"
        dgvProducto.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvProducto.Columns(6).DefaultCellStyle.Format = "c"
        dgvProducto.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvProducto.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvProducto.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvProducto.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvProducto.Columns(2).Width = "250"

        dgvProducto.Columns(7).Width = "75"
        dgvProducto.Columns(8).Width = "75"
        dgvProducto.Columns(4).Width = "75"
        dgvProducto.Columns(3).Width = "75"
        dgvProducto.Columns(9).Width = "120"
        dgvProducto.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        alinearEncabezadoGridP()

    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub negritasHeader()
        Dim cellStyle As New DataGridViewCellStyle
        cellStyle.Font = New Font("Arial", 7.5, FontStyle.Bold)
        dgvFalta.ColumnHeadersDefaultCellStyle = cellStyle
        dgvProducto.ColumnHeadersDefaultCellStyle = cellStyle
    End Sub
    Private Sub frmFaltantes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        enddb()
    End Sub
    Private Sub enddb()
        If Not busqueda Is Nothing Then
            busqueda.finalizarBusqueda()
            busqueda = Nothing
        End If
    End Sub
    Private Sub txtPoducto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.TextChanged
        If Not txtProducto.TextLength <= 2 Then
            'busquedaPorProducto() 'BUSQUEDA POR producto
            Dim list As List(Of Faltantes) = (From productos In lista
                       Where productos.Codigo.ToUpper.Contains(txtProducto.Text.ToUpper) Or productos.Descripcion.ToUpper.Contains(txtProducto.Text.ToUpper)
                       Select productos).ToList()
            dgvProducto.DataSource = list
            formatDGProducto()
            


            Else
                dgvProducto.DataSource = Nothing
            End If
    End Sub
    Private Sub busquedaPorProducto()
        Try
            If Not busqueda Is Nothing Then
                Dim list As List(Of Faltantes) = busqueda.faltantesporProducto(txtProducto.Text)
                dgvProducto.DataSource = list
                formatDGProducto()
                list = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tabfalta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabfalta.SelectedIndexChanged
        Try
            If tabfalta.SelectedIndex = 1 Then
                txtProducto.Focus()
            End If
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
    Private Sub frmFaltantes_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If tabfalta.SelectedIndex = 0 Then
            If Not dgvFalta.DataSource Is Nothing Then


                Dim rep As New Report
                rep.DataSource = dgvFalta.DataSource
                rep.Load("Reportes\faltantes.mrp")
                
                Dim file As String = My.Computer.FileSystem.GetTempFileName

                rep.ExportToPdf(file & ".pdf")
                System.Diagnostics.Process.Start(file & ".pdf")

                rep = Nothing
            End If
        ElseIf tabfalta.SelectedIndex = 1 Then
            If Not dgvProducto.DataSource Is Nothing Then


                Dim rep As New Report


                rep.DataSource = dgvProducto.DataSource

                rep.Load("Reportes\deudas.mrp")

                Dim file As String = My.Computer.FileSystem.GetTempFileName

                rep.ExportToPdf(file & ".pdf")
                System.Diagnostics.Process.Start(file & ".pdf")

                rep = Nothing
            End If
        End If
      
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
End Class