Imports LogicaNegocio

'Imports System.Threading
Imports MonoReports.Model
Imports Papeleria.frmVenta


Public Class frmConsultaVentas
    Private Id As Integer
    Private TotalVenta As Decimal
    Private Fecha As Date
    Private Vendedor As String
    Private venta As Devolucion
    Private sv As Service_Venta
    Private sc As Service_Cliente
    Private miCliente As Cliente
    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByVal id_venta As Integer, ByVal fecha As Date, ByVal totalVenta As Decimal, ByVal vendedor As String)
        Me.Id = id_venta
        Me.Fecha = fecha
        Me.TotalVenta = totalVenta
        Me.Vendedor = vendedor
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ver()
    End Sub
    Private Sub ver()
        Try
            Me.Text = "Detalle de Venta # " & Id & "    del dia " & Fecha & ",      Total  " & String.Format("{0:c}", TotalVenta) & "              " & Vendedor
            sv = New Service_Venta
            sc = New Service_Cliente
            venta = sv.Obtener(Id)

            miCliente = sc.Obtener(venta.Id_Venta)
            lblCliente.Text = "Cliente: " & miCliente.Razon
            lblTotal.Text = "TOTAL: " & String.Format("{0:c}", TotalVenta)
            lblFecha.Text = "Fecha: " & Fecha


            ActualizarGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmConsultaVentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmConsultaVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub
    Private Sub ActualizarGrid()

        Dim R As Short = 0
        dgvp.Rows.Clear()

        For Each item As Devolucion_Item In venta.Items
            With dgvp
                .Rows.Add()
                R = .RowCount - 1

                If item.Promo Then
                    .Rows(R).DefaultCellStyle.BackColor = Drawing.Color.RoyalBlue

                End If

                .Rows(R).Cells("IdItem").Value = item.Id
                .Rows(R).Cells("Codigo").Value = item.Producto.Codigo
                .Rows(R).Cells("Descripcion").Value = item.Producto.Descripcion
                .Rows(R).Cells("Cantidad").Value = item.Cantidad
                .Rows(R).Cells("Precio").Value = item.Producto.Precio

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

        dgvp.Columns(4).Width = 75
        dgvp.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvp.Columns(4).DefaultCellStyle.Format = "c"

        dgvp.Columns(5).Width = 75
        dgvp.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvp.Columns(5).HeaderText = "Desct. %"
        dgvp.Columns(6).Width = 75
        dgvp.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvp.Columns(6).DefaultCellStyle.Format = "c"
        dgvp.Columns(6).HeaderText = "Desct. $"
        dgvp.Columns(7).Width = 85
        dgvp.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvp.Columns(7).DefaultCellStyle.Format = "c"

        'subtotalVenta = dev.Totalf
        'IvaVenta = dev.ivaf
        'totalVenta = subtotalVenta + IvaVenta
        'descuentoTotal = dev.Descuentosf
        'aDevolverTotal = dev.Adevolverf
        'devueltosTotal = dev.Devueltosf

        'Dim tot As Decimal = totalVenta
        'txtSubtotal.Text = String.Format("{0:c}", subtotalVenta)
        'txtDesc.Text = String.Format("{0:c}", descuentoTotal)
        'txtTotalAdevolver.Text = String.Format("{0:c}", aDevolverTotal)
        'txtDevueltos.Text = String.Format("{0:c}", devueltosTotal)

        'lblTotal.Text = FormatCurrency(String.Format("{0:n}", subtotalVenta))
        'Dim st As String = String.Format("{0:n}", subtotalVenta)
        'Dim total() As String
        'total = Split(st, ".")
        'lblTotal.Text = "SON:  " & Utils.Num2Text(total(0)) & " PESOS " & total(1) & "/100 MN"

        'lblDevolucion.Text = FormatCurrency(String.Format("{0:n}", aDevolverTotal))
        'Dim st2 As String = String.Format("{0:n}", aDevolverTotal)
        'Dim total2() As String
        'total2 = Split(st2, ".")
        'lblDevolucion.Text = "SON:  " & Utils.Num2Text(total2(0)) & " PESOS " & total2(1) & "/100 MN"

        'dev.Total_texto = lblDevolucion.Text
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        doTicket2(0, 0, "", DateTime.Now, miCliente, 1)

    End Sub

    Private Sub doTicket2(ByVal caja As Integer, ByVal no_ticket As Integer, ByVal concepto As String, ByVal fecha As Date, ByVal cliente As Cliente, ByVal transaccion As Integer)
        Try


            Dim rep As New Report

            rep.Load("Reportes\nota.mrp")

            Dim lista As New List(Of privada)
            For Each items In venta.Items
                Dim it As New privada
                it.Cantidad = items.Cantidad
                it.Descripcion = IIf(items.Promo = True, items.Producto.Descripcion & "/" & items.Producto.Piezas & "/prom", items.Producto.Descripcion & "/" & items.Producto.Piezas)
                it.Precio = items.Producto.Precio
                'If chkMenudeo.Checked = True Then
                '    it.Menudeo = String.Format("{0:c}", items.Producto.Precio_Menudeo)
                'Else
                '    it.Menudeo = ""
                'End If

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

            dic.Add("Total", String.Format("{0:C}", TotalVenta).ToString)
            'If Not descuentoTotal = 0 Then
            '    dic.Add("Descuento", String.Format("{0:C}", descuentoTotal).ToString)
            '    dic.Add("DescuentoText", "Descuento")
            'End If

            dic.Add("DirCliente", cliente.Calle & ", " & IIf(cliente.Num_ext = "", "", "# " & cliente.Num_ext) & IIf(cliente.Num_int = "", "", " Int. " & cliente.Num_int) & ", " & cliente.Colonia & IIf(cliente.CP = "", "", " CP " & cliente.CP) & ", " & cliente.Ciudad & ", " & cliente.NombreEstado.ToUpper)
            ''dic.Add("totalTexto", lblTotal.Text)
            Dim file As String = My.Computer.FileSystem.GetTempFileName

            rep.ExportToPdf(file & ".pdf", dic)
            lista = Nothing
            System.Diagnostics.Process.Start(file & ".pdf")

            ''limpiar()
            ''cargarFolio()
            ''primerCliente(1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class