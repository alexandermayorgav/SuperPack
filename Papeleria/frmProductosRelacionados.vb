Imports LogicaNegocio

Public Class frmProductosRelacionados
    Private binding As New BindingSource
    Public Event Seleccionado()
    Sub New(ByVal id As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        DataGridView1.ReadOnly = True
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        '        Dim id2 As New DataGridViewTextBoxColumn
        '       id2.DataPropertyName = "Id"
        '      id2.HeaderText = "Id"


        Dim codigo As New DataGridViewTextBoxColumn
        codigo.DataPropertyName = "Codigo"
        codigo.HeaderText = "Codigo"

        Dim descripcion As New DataGridViewTextBoxColumn
        descripcion.DataPropertyName = "Descripcion"
        descripcion.HeaderText = "Descripcion"

        Dim piezas As New DataGridViewTextBoxColumn
        piezas.DataPropertyName = "Piezas"
        piezas.HeaderText = "Piezas"

        DataGridView1.Columns.Add(codigo)
        DataGridView1.Columns.Add(descripcion)
        DataGridView1.Columns.Add(piezas)


        Try
            Dim service As New Service_Producto


            binding.DataSource = service.ObtenerPaqRel(id)
            DataGridView1.DataSource = binding
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub Items(ByVal id As Integer)
        Try
            Dim service As New Service_Producto
            binding.DataSource = service.ObtenerPaqRel(id)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
 

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.RowCount > 0 Then
            RaiseEvent Seleccionado()
        End If
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class