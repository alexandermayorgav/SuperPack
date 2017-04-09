Imports LogicaNegocio
Public Class frmCotizacion
    Private sc As Service_cotizacion
    Private lista As List(Of Cotizacion)

    Private Sub frmCotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sc = New Service_cotizacion
        sc.IniciarBusqueda()
        cargaCotizaciones()
        txtCliente.Select()
        txtCliente.Focus()
        Me.KeyPreview = True
    End Sub
    Private Sub frmBuscarCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not sc Is Nothing Then
            sc.FinalizarBusqueda()
            sc = Nothing
        End If
    End Sub

    Private Sub cargaCotizaciones()
        Try

            lista = sc.obtenerCotizaciones(txtCliente.Text)
            dgv.DataSource = lista
            formatoGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatoGrid()
        dgv.Columns(0).Width = 50
        dgv.Columns(1).Width = 120
        dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgv.Columns(3).DefaultCellStyle.Format = "c"
        dgv.Columns(3).Width = 80
        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

   
    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        Try

            lista = sc.obtenerCotizaciones(txtCliente.Text)
            dgv.DataSource = lista
            formatoGrid()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
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