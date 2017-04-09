Imports LogicaNegocio
Imports MonoReports.Model


Public Class frmProdActualizados
    Private misProductos As List(Of Producto)

    Private Sub frmProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                btnBuscar.PerformClick()
            Case Else
        End Select

    End Sub
    Private Sub t_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim sp As New Service_Producto

            misProductos = sp.ObtenerActualizados(dtpInicial.Value.Date, dtpFinal.Value.Date)
            formatoGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatoGrid()
        Dim R As Short = 0

        dgv.Rows.Clear()

        For Each it As Producto In misProductos

            With dgv
                .Rows.Add()
                R = .RowCount - 1
                .Rows(R).Cells("id").Value = it.Id
                .Rows(R).Cells("codigo").Value = it.Codigo
                .Rows(R).Cells("descripcion").Value = it.Descripcion
                .Rows(R).Cells("piezas").Value = it.Piezas
                .Rows(R).Cells("costo").Value = it.Costo
                .Rows(R).Cells("precio").Value = it.Precio
                .Rows(R).Cells("menudeo").Value = it.Precio_Menudeo
            End With

        Next

        Dim fuente As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel, 4)
        dgv.Font = fuente

        Dim renglo As Integer = dgv.RowCount - 1
        '    DGVP.Rows(renglo).Selected = True
        If Not renglo <= 0 Then
            dgv.FirstDisplayedScrollingRowIndex = dgv.Rows(renglo).Index
        End If

        dgv.Columns(1).Width = 100
        dgv.Columns(2).Width = 300
        dgv.Columns(3).Width = 70
        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(4).Width = 80
        dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns(4).DefaultCellStyle.Format = "c"
        dgv.Columns(5).Width = 80
        dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns(5).DefaultCellStyle.Format = "c"
        dgv.Columns(6).Width = 80
        dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns(6).DefaultCellStyle.Format = "c"

        lbTotal.Text = misProductos.Count & "   Productos Actualizados"
    End Sub

    Private Sub frmProdActualizados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv.Rows.Clear()
        lbTotal.Text = ""
        misProductos = New List(Of Producto)
        Me.KeyPreview = True
    End Sub


    Public Class prodactualizados
        Private _codigo As String
        Private _descripcion As String
        Private _menudeo As Double
        Private _precio As Double
        Private _piezas As Double

        Public Sub New()

        End Sub
        Public Sub New(ByVal codigo As String, ByVal desc As String, ByVal menudeo As Double, ByVal precio As Double, ByVal piezas As Double)
            Me.Codigo = Codigo
            Me.Descripcion = desc
            Me.Menudeo = menudeo
            Me.Precio = precio
            Me.Piezas = piezas

        End Sub
        Public Property Codigo() As String
            Get
                Return _codigo
            End Get
            Set(ByVal value As String)
                _codigo = value
            End Set
        End Property

        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property

        Public Property Menudeo() As Double
            Get
                Return _menudeo
            End Get
            Set(ByVal value As Double)
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
        Public Property Piezas() As Double
            Get
                Return _piezas
            End Get
            Set(ByVal value As Double)
                _piezas = value
            End Set
        End Property

    End Class

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If misProductos.Count <> 0 Then

                Try


                    Dim rep As New Report

                    rep.Load("Reportes\actualizados.mrp")

                    Dim lista As New List(Of prodactualizados)
                    For Each item In misProductos
                       
                        lista.Add(New prodactualizados(item.Codigo, item.Descripcion, item.Precio_Menudeo, item.Precio, item.Piezas))

                    Next

                    rep.DataSource = lista


                    Dim dic As New Dictionary(Of String, Object)
                    dic.Add("fecha", Date.Now)
                  


                    Dim file As String = My.Computer.FileSystem.GetTempFileName

                    rep.ExportToPdf(file & ".pdf", dic)
                    lista = Nothing
                    System.Diagnostics.Process.Start(file & ".pdf")

                 
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                Throw New Exception("No hay productos seleccionados")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmCliente_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 45 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class