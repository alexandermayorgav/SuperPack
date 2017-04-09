Imports LogicaNegocio
Public Class frmConsServicios
    Private sserv As Service_Servicio
    Private objserv As Servicio
    Private servs As List(Of Servicio)
    Private totalserv As Integer
    Private comp As Integer
    Private incomp As Integer

    Private Sub frmConsServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        inicializar_objetos()
        obtenerLista()
        llenarGrid()
        lblTotal.Text = totalserv
        lblComp.Text = comp
        lblIncomp.Text = incomp
        rbTodos.Checked = True
    End Sub

    Private Sub llenarGrid()
        Try
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura
            With dgvservs
                .DataSource = filtro.ToList
                .Columns(0).Visible = False
                .Columns(1).Width = 200
                .Columns(3).Width = 70
                .Columns(4).Width = 60
                .Columns(5).Width = 60
                .Columns(6).Width = 130
                .Columns(7).Width = 130
                .Columns(8).Width = 65
                .Columns(9).Width = 60
            End With
            coloresGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
    Private Sub coloresGrid()
        Try
            Dim i As Integer
            With dgvservs
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells(8).Value Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.LimeGreen
                        comp += 1
                    Else
                        .Rows(i).DefaultCellStyle.BackColor = Color.PaleVioletRed
                        incomp += 1
                    End If
                Next
            End With        
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub inicializar_objetos()
        sserv = New Service_Servicio
    End Sub

    Private Sub obtenerLista()
        Try
            servs = sserv.obtenerTodos()
            totalserv = servs.Count
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub actualizarGrid(ByVal filtro As Object)
        Try
            With dgvservs
                .DataSource = filtro
                .Columns(0).Visible = False
                .Columns(1).Width = 200
                .Columns(3).Width = 70
                .Columns(4).Width = 60
                .Columns(5).Width = 60
                .Columns(6).Width = 130
                .Columns(7).Width = 130
                .Columns(8).Width = 65
                .Columns(9).Width = 60
            End With
            coloresGrid()
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmConsServicios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged

        If rbTodos.Checked Then
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper)
            actualizarGrid(filtro.ToList)
        End If
        If rbComp.Checked Then
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Completo = True
            actualizarGrid(filtro.ToList)
        End If
        If rbIncomp.Checked Then
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Completo = False
            actualizarGrid(filtro.ToList)
        End If
    End Sub

    Private Sub rbComp_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbComp.MouseClick
        If txtCliente.Text = "" Then
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = True
            actualizarGrid(filtro.ToList)
        Else
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Completo = True
            actualizarGrid(filtro.ToList)
        End If
    End Sub

    Private Sub rbIncomp_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbIncomp.MouseClick
        If txtCliente.Text = "" Then
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = False
            actualizarGrid(filtro.ToList)
        Else
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Completo = False
            actualizarGrid(filtro.ToList)
        End If
    End Sub

    Private Sub rbTodos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbTodos.MouseClick
        If txtCliente.Text = "" Then
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura
            actualizarGrid(filtro.ToList)
        Else
            Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper)
            actualizarGrid(filtro.ToList)
        End If
    End Sub

    Private Sub dtpFechaE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaE.TextChanged
        Try
            If rbTodos.Checked Then
                If txtCliente.Text = "" Then
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Utils.ObtenerFecha(Fecha_Entrega) = Utils.ObtenerFecha(dtpFechaE.Value)
                    actualizarGrid(filtro.ToList)
                Else
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Utils.ObtenerFecha(Fecha_Entrega) = Utils.ObtenerFecha(dtpFechaE.Value)
                    actualizarGrid(filtro.ToList)
                End If
            ElseIf rbComp.Checked Then
                If txtCliente.Text = "" Then
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = True And Utils.ObtenerFecha(Fecha_Entrega) = Utils.ObtenerFecha(dtpFechaE.Value)
                    actualizarGrid(filtro.ToList)
                Else
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = True And (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Utils.ObtenerFecha(Fecha_Entrega) = Utils.ObtenerFecha(dtpFechaE.Value)
                    actualizarGrid(filtro.ToList)
                End If
            ElseIf rbIncomp.Checked Then
                If txtCliente.Text = "" Then
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = False And Utils.ObtenerFecha(Fecha_Entrega) = Utils.ObtenerFecha(dtpFechaE.Value)
                    actualizarGrid(filtro.ToList)
                Else
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = False And (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Utils.ObtenerFecha(Fecha_Entrega) = Utils.ObtenerFecha(dtpFechaE.Value)
                    actualizarGrid(filtro.ToList)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtpFechaR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaR.TextChanged
        Try
            If rbTodos.Checked Then
                If txtCliente.Text = "" Then
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Utils.ObtenerFecha(Fecha_Recepcion) = Utils.ObtenerFecha(dtpFechaR.Value)
                    actualizarGrid(filtro.ToList)
                Else
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Utils.ObtenerFecha(Fecha_Recepcion) = Utils.ObtenerFecha(dtpFechaR.Value)
                    actualizarGrid(filtro.ToList)
                End If
            ElseIf rbComp.Checked Then
                If txtCliente.Text = "" Then
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = True And Utils.ObtenerFecha(Fecha_Recepcion) = Utils.ObtenerFecha(dtpFechaR.Value)
                    actualizarGrid(filtro.ToList)
                Else
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = True And (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Utils.ObtenerFecha(Fecha_Recepcion) = Utils.ObtenerFecha(dtpFechaR.Value)
                    actualizarGrid(filtro.ToList)
                End If
            ElseIf rbIncomp.Checked Then
                If txtCliente.Text = "" Then
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = False And Utils.ObtenerFecha(Fecha_Recepcion) = Utils.ObtenerFecha(dtpFechaR.Value)
                    actualizarGrid(filtro.ToList)
                Else
                    Dim filtro = From servicio In servs Select servicio.Id_Servicio, servicio.NombreC, servicio.Concecionaria, servicio.Linea, servicio.Modelo, servicio.Color, servicio.Fecha_Recepcion, servicio.Fecha_Entrega, servicio.Completo, servicio.Factura Where Completo = False And (NombreC.ToUpper).Contains(txtCliente.Text.ToUpper) And Utils.ObtenerFecha(Fecha_Recepcion) = Utils.ObtenerFecha(dtpFechaR.Value)
                    actualizarGrid(filtro.ToList)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvservs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvservs.DoubleClick
        Try
            With dgvservs
                If Not .CurrentRow Is Nothing Then
                    Dim frmRS As New frmRecepServicio(.CurrentRow.Cells(0).Value)
                    frmRS.ShowDialog()
                End If
            End With
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmConsServicios_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class