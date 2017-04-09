Imports LogicaNegocio
Imports MonoReports.Model


Public Class frmcortes

    Private resumen As List(Of ResumenVentas)

    Private Sub frmResumenVentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F5 Then
                verVentas()
            End If

            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarCboVendedor()
        Dim cargaVendedores As New Service_Venta
        Try
            With cboVendedor
                .DataSource = cargaVendedores.llenarUsuarios.Tables(0)
                .DisplayMember = ("USUARIO")
                .ValueMember = ("ID_USUARIO")
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmResumenVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            cargarCboVendedor()
            chkVendedor.Checked = False
            cboVendedor.Enabled = False
            negritasHeader()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub verVentas()
        Try

            Dim service As New ServiceCortes
            Dim detalles As List(Of Cortes) = service.ObtenerCortes

            Dim fecha1 As New Date(dtpfechainicio.Value.Year, dtpfechainicio.Value.Month, dtpfechainicio.Value.Day)
            Dim fechados As Date = dtpfechafin.Value.AddDays(1)

            Dim fecha2 As New Date(fechados.Year, fechados.Month, fechados.Day)

            If chkVendedor.Checked = False Then
                Dim var = From q In detalles Where q.FechaInicial > fecha1 And q.FechaInicial < fecha2 Select q.Id, q.FechaInicial, q.FechaCierre, q.Nombre, q.Monto
                dgvVentas.DataSource = var.ToList


            Else
                Dim var = From q In detalles Where (q.FechaInicial > fecha1 And q.FechaInicial < fecha2) And q.Id_Usuario = cboVendedor.SelectedValue Select q.Id, q.FechaInicial, q.FechaCierre, q.Nombre, q.Monto
                dgvVentas.DataSource = var.ToList



            End If
            
            With dgvVentas
                .Columns(0).Width = 60
                .Columns(1).Width = 140
                .Columns(2).Width = 140
                .Columns(3).Width = 200
                .Columns(4).DefaultCellStyle.Format = "c"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub formatoDG()
        
    End Sub

    Private Sub btnverVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnverVentas.Click
        verVentas()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub chkVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVendedor.CheckedChanged
        If chkVendedor.Checked = True Then
            cboVendedor.Enabled = True
        ElseIf chkVendedor.Checked = False Then
            cboVendedor.Enabled = False
        End If
    End Sub
    Private Sub negritasHeader()
        Dim cellStyle As New DataGridViewCellStyle

        cellStyle.Font = New Font("Arial", 7.5, FontStyle.Bold)

        dgvVentas.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmResumenVentas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub


    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Not dgvVentas.DataSource Is Nothing Then
                If dgvVentas.Rows.Count <> 0 Then


                    Dim rep As New Report

                    ' Dim total As Double = CType(dgvVentas.DataSource, List(Of ResumenVentas)).Sum(Function(p) p.Total)

                    Dim item As Object = dgvVentas.CurrentRow.DataBoundItem

                    Dim serv As New ServiceCortes
                    Dim detalles As List(Of CorteDetalle) = serv.ObtenerDetalles(item.Id)
                    rep.DataSource = detalles

                    Dim dic As New Dictionary(Of String, Object)
                    dic.Add("Param.MontoIn", String.Format("{0:C}", item.Monto))
                    dic.Add("Param.Folio", item.Id)
                    dic.Add("Param.FechaApertura", item.FechaInicial)
                    dic.Add("Param.FechaCierre", item.FechaCierre)



                    Dim efectivo As Double = (From c In detalles Where c.Tipo = "Efectivo" Select c.Monto).Sum - item.monto
                    Dim targeta As Double = (From c In detalles Where c.Tipo = "Tarjeta" Select c.Monto).Sum

                    Dim vales As Double = (From c In detalles Where c.Tipo = "Vale" Select c.Monto).Sum
                    Dim totalgeneral As Double = (From c In detalles Select c.Monto).Sum - item.monto



                    dic.Add("Param.Efectivo", String.Format("{0:C}", efectivo))
                    dic.Add("Param.Targeta", String.Format("{0:C}", targeta))
                    dic.Add("Param.Vale", String.Format("{0:C}", vales))
                    dic.Add("Param.Total", String.Format("{0:C}", totalgeneral))


                    rep.Load("Reportes\reportecaja.mrp")

                    Dim file As String = My.Computer.FileSystem.GetTempFileName
                    rep.ExportToPdf(file & ".pdf", dic)
                    System.Diagnostics.Process.Start(file & ".pdf")

                    rep = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub
End Class