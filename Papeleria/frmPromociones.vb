Imports LogicaNegocio
Public Class frmPromociones

    Private promo As opPromociones
    Private promo2 As opPromocionesPieza
    Private binding As New BindingSource
    Private binding2 As New BindingSource
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ToolStripComboBox1.SelectedIndex = 0
        ToolStripComboBox2.SelectedIndex = 0
        '  promo = New opPromociones(0)
        binding.DataSource = promo.Promociones
        DataGridView1.ReadOnly = True
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Dim id As New DataGridViewTextBoxColumn
        id.DataPropertyName = "Id"
        id.HeaderText = "Id"

        Dim fechainicial As New DataGridViewTextBoxColumn
        fechainicial.DataPropertyName = "Fecha_Inicial"
        fechainicial.HeaderText = "Fecha Inicial"
        fechainicial.CellTemplate.Style.Format = "dd/MM/yyy"

        Dim fechafin As New DataGridViewTextBoxColumn
        fechafin.DataPropertyName = "Fecha_Final"
        fechafin.HeaderText = "Fecha Final"
        fechafin.CellTemplate.Style.Format = "dd/MM/yyy"

        Dim descripcion As New DataGridViewTextBoxColumn
        descripcion.DataPropertyName = "Descripcion"
        descripcion.HeaderText = "Descripcion"

        Dim cantidad As New DataGridViewTextBoxColumn
        cantidad.DataPropertyName = "Cantidad"
        cantidad.HeaderText = "Cantidad"

        Dim descuento As New DataGridViewTextBoxColumn
        descuento.DataPropertyName = "Descuento"
        descuento.HeaderText = "Descuento"

        DataGridView1.Columns.Add(id)
        DataGridView1.Columns.Add(fechainicial)
        DataGridView1.Columns.Add(fechafin)
        DataGridView1.Columns.Add(descripcion)
        DataGridView1.Columns.Add(cantidad)
        DataGridView1.Columns.Add(descuento)
        DataGridView1.DataSource = binding



        ' promo2 = New opPromocionesPieza(0)
        binding2.DataSource = promo2.Promociones
        DataGridView2.ReadOnly = True
        DataGridView2.AutoGenerateColumns = False
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Dim id2 As New DataGridViewTextBoxColumn
        id2.DataPropertyName = "Id"
        id2.HeaderText = "Id"

        Dim fechainicial2 As New DataGridViewTextBoxColumn
        fechainicial2.DataPropertyName = "Fecha_Inicial"
        fechainicial2.HeaderText = "Fecha Inicial"
        fechainicial2.CellTemplate.Style.Format = "dd/MM/yyy"

        Dim fechafin2 As New DataGridViewTextBoxColumn
        fechafin2.DataPropertyName = "Fecha_Final"
        fechafin2.HeaderText = "Fecha Final"
        fechafin2.CellTemplate.Style.Format = "dd/MM/yyy"

        Dim descripcion2 As New DataGridViewTextBoxColumn
        descripcion2.DataPropertyName = "Descripcion"
        descripcion2.HeaderText = "Descripcion"

        Dim descripcion22 As New DataGridViewTextBoxColumn
        descripcion22.DataPropertyName = "DescripcionRegalo"
        descripcion22.HeaderText = "Descripcion Regalo"

        Dim cantidad2 As New DataGridViewTextBoxColumn
        cantidad2.DataPropertyName = "Cantidad"
        cantidad2.HeaderText = "Cantidad"

        Dim cantidad22 As New DataGridViewTextBoxColumn
        cantidad22.DataPropertyName = "CantidadRegalada"
        cantidad22.HeaderText = "Cantidad Regalada"

        DataGridView2.Columns.Add(id2)
        DataGridView2.Columns.Add(fechainicial2)
        DataGridView2.Columns.Add(fechafin2)
        DataGridView2.Columns.Add(descripcion2)
        DataGridView2.Columns.Add(descripcion22)
        DataGridView2.Columns.Add(cantidad2)
        DataGridView2.Columns.Add(cantidad22)
        DataGridView2.DataSource = binding2



    End Sub

    Private Sub frmPromociones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ClearMemory()
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

    Private Sub frmPromociones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frm As New frmPromocion(promo)
        frm.ShowDialog()
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub DataGridView1_UserDeletingRow1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        If MsgBox("Esta Seguro de borrar la promocion", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try
                promo.Delete(CType(e.Row.DataBoundItem, Promocion).Id)
            Catch ex As ReglasNegocioException
                e.Cancel = True
                MsgBox(ex.Message)
            Catch ex As Exception
                e.Cancel = True
                MsgBox(ex.Message)
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        If MsgBox("Esta Seguro de borrar la promocion", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                If Not DataGridView1.CurrentRow Is Nothing Then
                    Dim item As Promocion = CType(DataGridView1.CurrentRow.DataBoundItem, Promocion)
                    promo.Delete(item.Id)
                    promo.Promociones.Remove(item)
                End If

            Catch ex As ReglasNegocioException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        promo = New opPromociones(ToolStripComboBox1.SelectedIndex)
        binding.DataSource = promo.Promociones
    End Sub
    Private Sub ToolStripComboBox1_SelectedIndexChanged2(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        promo2 = New opPromocionesPieza(ToolStripComboBox2.SelectedIndex)
        binding2.DataSource = promo2.Promociones
    End Sub


    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim frm As New frmPromocionPieza(promo2)
        frm.ShowDialog()
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If MsgBox("Esta Seguro de borrar la promocion", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try
                If Not DataGridView2.CurrentRow Is Nothing Then
                    Dim item As PromocionPieza = CType(DataGridView2.CurrentRow.DataBoundItem, PromocionPieza)
                    promo2.Delete(item.Id)
                    promo2.Promociones.Remove(item)
                End If

            Catch ex As ReglasNegocioException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView2.UserDeletingRow
        If MsgBox("Esta Seguro de borrar la promocion", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try
                promo2.Delete(CType(e.Row.DataBoundItem, PromocionPieza).Id)
            Catch ex As ReglasNegocioException
                e.Cancel = True
                MsgBox(ex.Message)
            Catch ex As Exception
                e.Cancel = True
                MsgBox(ex.Message)
            End Try
        Else
            e.Cancel = True
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