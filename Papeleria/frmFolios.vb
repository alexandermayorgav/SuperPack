Imports LogicaNegocio
Imports System.IO
Public Class frmFolios


    Private operaciones As opFolios
    Private Sub frmFolios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        iniciar()
    End Sub

    Private Sub iniciar()
        operaciones = New opFolios
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = operaciones.Folios
     
    End Sub
    Private Sub clean()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = operaciones.Folios
        txtNoAprobacion.Text = ""
        txtSelloDigital.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If OpenFileDialog1.FileName.Trim <> "" Then


                If Not System.IO.File.Exists(OpenFileDialog1.FileName) Then
                    Throw New Exception("La imagen no existe")
                End If
            Else
                Throw New Exception("Seleccione la imagen")

            End If
            If Not IsDate(txtHora.Text) Then
                Throw New Exception("Introduzca hora correcta")
            End If
            Dim HORA() As String = txtHora.Text.Split(":")
            Dim fecha As New Date(dtfecha.Value.Year, dtfecha.Value.Month, dtfecha.Value.Day, HORA(0), HORA(1), HORA(2))
            If txtFolioFinal.Text.Trim = "" Or txtFolioInicial.Text.Trim = "" Then
                Throw New Exception("El folio final y el inicial son requeridos")
            End If

            If Convert.ToInt32(txtFolioInicial.Text) > Convert.ToInt32(txtFolioFinal.Text) Then
                Throw New Exception("El folio inicial debe ser menor al folio final")
            End If

            checarFolios(Convert.ToInt32(txtFolioInicial.Text))

            Dim numfolios As Integer = (Convert.ToInt32(txtFolioFinal.Text) - Convert.ToInt32(txtFolioInicial.Text)) + 1
            If txtNoAprobacion.Text.Trim = "" Then
                Throw New Exception("El numero de aprobacion es requerido")
            End If
            Dim folio As New Folio(-1, txtNoAprobacion.Text, fecha, numfolios, 0, txtSelloDigital.Text, "0", txtCAdena.Text, txtSelloDigitaSat.Text, txtSerie.Text, txtFolioInicial.Text, txtFolioFinal.Text, txtTipoComprobante.Text)
            Dim reader As FileStream = Nothing
            Try
                reader = System.IO.File.OpenRead(OpenFileDialog1.FileName)
                Dim IMG(reader.Length) As Byte
                reader.Read(img, 0, Convert.ToInt32(reader.Length))

                folio.Imagen = IMG
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                reader.Close()
            End Try

            If operaciones.AgregarFolios(folio) Then
                clean()
                MsgBox("Se agregaron los folios")
            End If
        Catch ex As InvalidCastException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ActivarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivarToolStripMenuItem.Click
        operaciones.ActivarFolios(CType(DataGridView1.CurrentRow.DataBoundItem, Folio).Id)
    End Sub

    Private Sub DesactivarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesactivarToolStripMenuItem.Click
        operaciones.DesActivarFolios(CType(DataGridView1.CurrentRow.DataBoundItem, Folio).Id)
    End Sub

    Private Sub dgvPersonal_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp
        Try
            Dim hit As DataGridView.HitTestInfo
            With DataGridView1
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    hit = .HitTest(e.X, e.Y)
                    .CurrentCell = .Rows(hit.RowIndex).Cells(hit.ColumnIndex)

                    If hit.Type = DataGridViewHitTestType.Cell Then
                        ContextMenuStrip1.Show(DataGridView1, New Point(e.X, e.Y))

                    End If

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmUsuarios_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 40 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If

    End Sub
    Private Sub frmCodigosHermanos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
       
    End Sub
    Private Sub checarFolios(ByVal inicial As Integer)
        For Each item In operaciones.Folios
            If item.Folio_Final > inicial Then
                Throw New Exception("Ya existen estos folios")
            End If
        Next
    End Sub

End Class