Imports LogicaNegocio
Public Class frmHistAutos
    Public objAuto As Servicio
    Private autos As List(Of Servicio)
    Private servs As List(Of Servicio)
    Private bandserv As Boolean
    Public ids As Integer = 0
    Sub New(ByVal ss As Service_Servicio, ByVal idc As String, ByVal nombrec As String, ByVal serv As Boolean)
        Me.bandserv = serv
        If Not serv Then
            autos = ss.getAutos(idc)
        Else
            servs = ss.getServicios(idc)
        End If

        InitializeComponent()
        txtCliente.Text = nombrec
    End Sub
    Private Sub frmHistAutos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        With dgvAutos
            If Not bandserv Then
                Me.Text = "Historial Automoviles"
                .DataSource = autos
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
                .Columns(5).Visible = False
                .Columns(6).Width = 145
                .Columns(7).Width = 145
                .Columns(8).Width = 90
                .Columns(9).Width = 90
                .Columns(10).Width = 90
                .Columns(11).Width = 90
                .Columns(12).Visible = False
                .Columns(13).Visible = False
                .Columns(14).Visible = False
                .Columns(15).Visible = False
                .Columns(16).Visible = False
                .Columns(17).Visible = False
            Else
                Me.Text = "Historial Servicios"
                .DataSource = servs
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Width = 140
                .Columns(8).Visible = False
                .Columns(9).Width = 65
                .Columns(10).Width = 80
                .Columns(11).Width = 70
                .Columns(12).Visible = False
                .Columns(13).Width = 140
                .Columns(14).Width = 140
                .Columns(15).Width = 65
                .Columns(16).Visible = False
                .Columns(17).Visible = False
            End If
            
        End With
    End Sub
    Private Sub frmHistAutos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub dgvAutos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAutos.DoubleClick
        Try
            If Not dgvAutos.RowCount < 0 Then
                If Not bandserv Then
                    objAuto = New Servicio
                    objAuto.Concecionaria = dgvAutos.CurrentRow.Cells(6).Value
                    objAuto.Linea = dgvAutos.CurrentRow.Cells(7).Value
                    objAuto.Tipo = dgvAutos.CurrentRow.Cells(8).Value
                    objAuto.Modelo = dgvAutos.CurrentRow.Cells(9).Value
                    objAuto.Color = dgvAutos.CurrentRow.Cells(10).Value
                    objAuto.Placas = dgvAutos.CurrentRow.Cells(11).Value
                    objAuto.Kilometraje = dgvAutos.CurrentRow.Cells(12).Value
                    Me.Close()
                Else
                    ids = dgvAutos.CurrentRow.Cells(17).Value
                    Me.Close()
                End If
                
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class