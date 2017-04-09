Imports System.ComponentModel
Imports LogicaNegocio
Public Class frmPromocionPieza

    Private binding As BindingSource
    Private promo As opPromocionesPieza
    Private promocion As PromocionPieza
    Sub New(ByRef promo As opPromocionesPieza)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        promocion = New PromocionPieza
        binding = New BindingSource
        binding.DataSource = promocion
        Me.promo = promo
        lblProducto.DataBindings.Add("Text", binding, "Producto.Descripcion", False, DataSourceUpdateMode.OnPropertyChanged)
        lblProducto2.DataBindings.Add("Text", binding, "ProductoRegalo.Descripcion", False, DataSourceUpdateMode.OnPropertyChanged)
        txtCantidadVendida.DataBindings.Add("Text", binding, "Cantidad", False, DataSourceUpdateMode.OnPropertyChanged)
        txtCantidad.DataBindings.Add("Text", binding, "CantidadRegalada", False, DataSourceUpdateMode.OnPropertyChanged)
        datein.DataBindings.Add("Value", binding, "Fecha_Inicial", False, DataSourceUpdateMode.OnPropertyChanged)
        datefin.DataBindings.Add("Value", binding, "Fecha_Final", False, DataSourceUpdateMode.OnPropertyChanged)

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        frmBuscarProducto.ShowDialog()
        Dim prod As Object = Nothing
        Try
            prod = CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto)
        Catch ex As Exception

        End Try

        If Not prod Is Nothing Then
            promocion.Producto = prod
        End If

    End Sub

    Private Sub frmPromocion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAgregarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarLinea.Click

        If promo.Save(promocion) Then
            promocion = New PromocionPieza
            binding.DataSource = promocion
        End If
        
    End Sub

    Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageButton1.Click
        frmBuscarProducto.ShowDialog()
        Dim prod As Object = Nothing
        Try
            prod = CType(frmBuscarProducto.dgv.CurrentRow.DataBoundItem, Producto)
        Catch ex As Exception

        End Try

        If Not prod Is Nothing Then
            promocion.ProductoRegalo = prod
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmPromociones_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub frmPromocioness_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub
End Class