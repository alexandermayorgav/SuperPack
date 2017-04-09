Imports LogicaNegocio
Public Class frmPaquetes
    Public listaprod As List(Of Producto)
    Public listaTodosProd As List(Of Producto)
    Private SProductos As Service_Producto
    Public cto As Decimal
    Public pzas As Decimal
    Private idprod As Integer
    Public FilaEditada As Boolean = False
    Private PresionoBtnCantidades As Boolean = False
    Private Finalizar As Boolean = False
    Private PrecioCaja As Decimal
    Private PrecioMenudeoPieza As Decimal
    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByVal lista As List(Of Producto), ByVal listaTodos As List(Of Producto), ByVal cost As Decimal, ByVal pzs As Decimal, ByVal id As Integer, ByVal precioCaja As Decimal, ByVal precioMenudeo As Decimal)
        InitializeComponent()
        Me.listaprod = lista
        Me.listaTodosProd = listaTodos
        Me.cto = cost
        Me.pzas = pzs
        Me.idprod = id
        Me.PrecioCaja = precioCaja
        Me.PrecioMenudeoPieza = precioMenudeo
    End Sub
    Private Sub frmPaquetes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizarGrid()
    End Sub
    Private Sub ActualizarGrid()

        Dim R As Short = 0
        Dim Costo As Decimal = 0
        Dim Price As Decimal = 0
        Dim Pmenudeo As Decimal = 0

        DGVPaquetes.Rows.Clear()

        If PresionoBtnCantidades = False Then
            For Each item As Producto In listaprod
                For Each i As Producto In listaTodosProd
                    If item.Id = i.Id Then
                        With DGVPaquetes
                            .Rows.Add()
                            R = .RowCount - 1

                            If i.ActualizarCodigosHermanos Then
                                DGVPaquetes.Rows(R).Cells(7).Value = True
                                item.ActualizarCodigosHermanos = i.ActualizarCodigosHermanos
                            End If

                            .Rows(R).Cells("codigo").Value = item.Codigo
                            .Rows(R).Cells("desc").Value = item.Descripcion
                            .Rows(R).Cells("costo").Value = i.Costo
                            .Rows(R).Cells("precio").Value = i.Precio
                            .Rows(R).Cells("preciomenudeo").Value = i.Precio_Menudeo
                            .Rows(R).Cells("piezas").Value = item.Piezas
                            .Rows(R).Cells("idp").Value = item.Id
                        End With
                        Exit For
                    End If
                Next
            Next
        Else
            For Each item As Producto In listaprod
                With DGVPaquetes
                    .Rows.Add()
                    R = .RowCount - 1

                    If item.ActualizarCodigosHermanos Then
                        DGVPaquetes.Rows(R).Cells(7).Value = True
                    End If

                    .Rows(R).Cells("codigo").Value = item.Codigo
                    .Rows(R).Cells("desc").Value = item.Descripcion
                    .Rows(R).Cells("costo").Value = item.Costo
                    .Rows(R).Cells("precio").Value = item.Precio
                    .Rows(R).Cells("preciomenudeo").Value = item.Precio_Menudeo
                    .Rows(R).Cells("piezas").Value = item.Piezas
                    .Rows(R).Cells("idp").Value = item.Id
                End With
            Next
        End If
        Dim renglo As Integer = DGVPaquetes.RowCount - 1

        If Not renglo <= 0 Then
            DGVPaquetes.FirstDisplayedScrollingRowIndex = DGVPaquetes.Rows(renglo).Index
        End If
        DGVPaquetes.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPaquetes.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGVPaquetes.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVPaquetes.Columns(2).DefaultCellStyle.Format = "c"
        DGVPaquetes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVPaquetes.Columns(3).DefaultCellStyle.Format = "c"
        DGVPaquetes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVPaquetes.Columns(4).DefaultCellStyle.Format = "c"
        DGVPaquetes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Try
            If Finalizar Then
                For Each i As Producto In listaprod
                    For Each it As Producto In listaTodosProd
                        If it.Id = i.Id Then
                            If it.Costo <> i.Costo Or it.Precio <> i.Precio Or it.Precio_Menudeo <> i.Precio_Menudeo Or i.ActualizarCodigosHermanos = True Then
                                it.Costo = i.Costo
                                it.Precio = i.Precio
                                it.Precio_Menudeo = i.Precio_Menudeo
                                it.ActualizarCodigosHermanos = i.ActualizarCodigosHermanos
                                FilaEditada = True
                            End If
                            Exit For
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Close()
    End Sub
    Private Sub DGVPaquetes_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVPaquetes.CellEndEdit
        Dim id As Integer = DGVPaquetes.CurrentRow.Cells(6).Value
        Dim Cto As Decimal = DGVPaquetes.CurrentRow.Cells(2).Value
        Dim Pre As Decimal = DGVPaquetes.CurrentRow.Cells(3).Value
        Dim PreMenu As Decimal = DGVPaquetes.CurrentRow.Cells(4).Value
        Dim ActivoCodHrno As Boolean = DGVPaquetes.CurrentRow.Cells(7).Value
        Try
            For Each i As Producto In listaprod
                If i.Id = id Then
                    i.Costo = Cto
                    i.Precio = Pre
                    i.Precio_Menudeo = PreMenu
                    DGVPaquetes.CurrentCell.Style.BackColor = Color.LightSteelBlue
                    If ActivoCodHrno Then
                        i.ActualizarCodigosHermanos = True
                    Else
                        i.ActualizarCodigosHermanos = False
                    End If
                    Exit For
                End If
            Next
            Finalizar = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmPaquetes_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    Private Sub btnMin2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose2.Click
        Me.Close()
    End Sub
    Private Sub btnNvaCantidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNvaCantidades.Click
        Dim costoProd As Decimal = 0
        Dim NewCostoPack As Decimal = 0
        Dim price As Decimal = 0
        Dim precioMenudeo As Decimal = 0

        For Each i As Producto In listaprod

            costoProd = cto / pzas

            NewCostoPack = costoProd * i.Piezas
            NewCostoPack = Format(NewCostoPack, "0.00")

            'price = NewCostoPack * conf.Porcentaje_Medio / 100 + NewCostoPack
            'price = Format(price, "0.00")
            price = (PrecioCaja / pzas + Sesion.conf.Precio_Empaque) * i.Piezas
            price = Format(price, "0.00")

            'precioMenudeo = (NewCostoPack / i.Piezas) + (NewCostoPack * conf.Porcentaje_Menudeo / 100)
            'precioMenudeo = 
            ' precioMenudeo = Format(precioMenudeo, "0.00")

            i.Costo = NewCostoPack
            i.Precio = price
            i.Precio_Menudeo = Me.PrecioMenudeoPieza

        Next
        Finalizar = True
        PresionoBtnCantidades = True
        ActualizarGrid()
    End Sub
    Private Sub btnRegresarCant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresarCant.Click
        listaprod = New List(Of Producto)
        SProductos = New Service_Producto
        listaprod = SProductos.ObtenerIDC(idprod)
        PresionoBtnCantidades = True
        Finalizar = True
        ActualizarGrid()
    End Sub
End Class