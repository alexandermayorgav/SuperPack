Imports LogicaNegocio
Public Class frmLineas
    Private sl As Service_linea = Nothing
    Dim id_linea As Integer = 0
    Dim nuevo As Boolean = True
    Private lista As List(Of Linea)

    Private Sub frmLineas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not sl Is Nothing Then
                sl.FinalizarBusqueda()
                sl = Nothing

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub frmLineas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            btnGuardar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmLineas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            sl = New Service_linea
            sl.IniciarBusqueda()
            cargarLineas()
            limpiar()
        Catch ex As Exception
            MsgBox("Error al conectarse.", ex.Message)
        End Try
        
    End Sub

    Private Sub cargarLineas()
        Try
            lista = sl.obtener_Lineas()
            dgv.DataSource = lista
            dgv.Columns(0).Visible = False
            dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
   
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Not txtLinea.Text.Length <= 0 Then
                If nuevo Then
                    If Not sl.existe(txtLinea.Text) Then
                        sl.insertar(txtLinea.Text.Trim)
                    Else
                        Throw New Exception("Ya existe una linea con este nombre " & Chr(13) & "'" & txtLinea.Text & "'")
                    End If


                Else ''acutializar
                    sl.actualizar(id_linea, txtLinea.Text.Trim)
                End If

                    cargarLineas()
                    limpiar()
                Else
                    Throw New ReglasNegocioException("Debe escribir una descripcion.")
                    txtLinea.Select()
                    txtLinea.Focus()
                End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub limpiar()
        id_linea = 0
        txtLinea.Text = ""
        btnGuardar.Text = "Guardar"
        nuevo = True
    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If dgv.RowCount > 0 Then
            id_linea = dgv.CurrentRow.Cells(0).Value
            txtLinea.Text = dgv.CurrentRow.Cells(1).Value
            nuevo = False
            btnGuardar.Text = "Actualizar"
        End If
    End Sub

    Private Sub txtLinea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLinea.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnGuardar.PerformClick()
        End If
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmCompra_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 45 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub dgvp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyDown
        If e.KeyCode = 46 Then
            'Dim item As New Proveedor(dgvp.CurrentRow.Cells(0).Value, dgvp.CurrentRow.Cells(1).Value, False)
            Try
                sl.eliminar(dgv.CurrentRow.Cells(0).Value)
                cargarLineas()

            Catch ex As Exception
                If Err.Number = 5 Then
                    MsgBox("Imposible borrar.")
                Else
                    MsgBox(ex.Message)
                End If

            End Try
        End If
    End Sub

    

End Class