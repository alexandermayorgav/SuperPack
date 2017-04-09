Imports LogicaNegocio
Public Class frmPersonal
    Private sPers As Service_Personal
    Private listP As List(Of Personal)
    Public objP As Personal
    Private Sub frmPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPersonal.CellDoubleClick
        If dgvPersonal.RowCount > 0 Then
            objP = New Personal
            objP.Id = dgvPersonal.CurrentRow.Cells(0).Value
            objP.Nombre = dgvPersonal.CurrentRow.Cells(1).Value
            Try
                objP.Puesto = dgvPersonal.CurrentRow.Cells(7).Value
            Catch ex As Exception
                objP.Puesto = dgvPersonal.CurrentRow.Cells(5).Value
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub frmPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        sPers = New Service_Personal
        obtenerActivos()
    End Sub
    Private Sub nuevo()
        Try
            Dim frmNP As New frmNuevoPersonal
            frmNP.ShowDialog()
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub borrar()
        Try
            If dgvPersonal.CurrentRow.Cells(0).Value = Nothing Then
                Throw New Exception("Debes seleccionar un registro")
                Exit Sub
            End If

            Dim confirmacion = MsgBox("¿Desactivar el personal?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
            If confirmacion = vbYes Then
                sPers.desactivar(dgvPersonal.CurrentRow.Cells(0).Value)
                obtenerActivos()
            End If

        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub editar()
        Try
            
            If dgvPersonal.CurrentRow.Cells(0).Value = Nothing Then
                Throw New Exception("Debes seleccionar un registro")
                Exit Sub
            End If
            Dim frmP As New frmNuevoPersonal(dgvPersonal.CurrentRow.Cells(0).Value)
            frmP.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub obtenerActivos()
        Try
            chkInact.Checked = False
            With dgvPersonal
                listP = sPers.obtenerTodos
                If listP.Count > 0 Then
                    Dim filtro = From personal In listP Select personal.Id, personal.Nombre, personal.Direccion, personal.Telefono, personal.Celular, personal.Email, personal.Activo, personal.Puesto Where Activo = True
                    .DataSource = filtro.ToList
                End If
                .Columns(0).Visible = False
                .Columns(1).Width = 300
                .Columns(2).Visible = False
                .Columns(4).Width = 113
                .Columns(6).Visible = False
                .Columns(5).Visible = False
                .Columns(7).Width = 150
                If Not .RowCount > 0 Then
                    btnEdit.Enabled = False
                    btnDelete.Enabled = False
                Else
                    btnEdit.Enabled = True
                    btnDelete.Enabled = True
                End If
            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub obtenerInActivos()
        Try
            btnDelete.Enabled = False
            With dgvPersonal
                listP = sPers.obtenerTodos
                If listP.Count > 0 Then
                    Dim filtro = From personal In listP Select personal.Id, personal.Nombre, personal.Direccion, personal.Telefono, personal.Celular, personal.Email, personal.Activo, personal.Puesto Where Activo = False
                    .DataSource = filtro.ToList
                End If
                .Columns(0).Visible = False
                .Columns(1).Width = 300
                .Columns(2).Visible = False
                .Columns(4).Width = 113
                .Columns(6).Visible = False
                .Columns(5).Visible = False
                If Not .RowCount > 0 Then
                    btnEdit.Enabled = False
                    btnDelete.Enabled = False
                Else
                    btnEdit.Enabled = True
                End If
            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkInact_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkInact.CheckedChanged
        If chkInact.Checked = True Then
            obtenerInActivos()
        Else
            obtenerActivos()
        End If
    End Sub

    Private Sub dgvPersonal_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPersonal.MouseUp
        Try
            Dim hit As DataGridView.HitTestInfo
            With dgvPersonal
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    hit = .HitTest(e.X, e.Y)
                    .CurrentCell = .Rows(hit.RowIndex).Cells(hit.ColumnIndex)
                   
                    If hit.Type = DataGridViewHitTestType.Cell And hit.ColumnIndex = 1 Or hit.ColumnIndex = 3 Or hit.ColumnIndex = 4 Then
                        cmsPers.Show(dgvPersonal, New Point(e.X, e.Y))
                    End If

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub filtrarDGV()
        Try
            Dim filtro = From personal In listP Select personal.Id, personal.Nombre, personal.Telefono, personal.Direccion, personal.Celular, personal.Email, personal.Puesto, personal.Activo Where (Nombre.ToUpper).Contains(txtNombre.Text.ToUpper) And Activo = True
            dgvPersonal.DataSource = filtro.ToList
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub filtrarDGVinac()
        Try
            Dim filtro = From personal In listP Select personal.Id, personal.Nombre, personal.Telefono, personal.Direccion, personal.Celular, personal.Email, personal.Puesto, personal.Activo Where (Nombre.ToUpper).Contains(txtNombre.Text.ToUpper) And Activo = False
            dgvPersonal.DataSource = filtro.ToList
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tsmiDesact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiDesact.Click
        borrar()
    End Sub

    Private Sub tsmiEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiEdit.Click
        editar()
    End Sub

    Private Sub tsmiNvo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiNvo.Click
        nuevo()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        nuevo()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        editar()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        borrar()
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        If chkInact.Checked Then
            filtrarDGVInac()
        Else

            filtrarDGV()
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmPersonal_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class