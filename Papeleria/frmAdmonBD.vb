Imports LogicaNegocio
Imports FirebirdSql.Data.FirebirdClient
Imports FirebirdSql.Data.Services
Public Class frmAdmonBD
    Dim linkdatabase As linkBD = Nothing
    Private Sub frmAdmonBD_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        linkdatabase = Nothing
    End Sub
    Private Sub frmAdmonBD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If tabBD.SelectedIndex = 0 Then

            If e.KeyCode = Keys.F5 Then
                If Not txtPath.Text = "" Then
                    'crearCopiaSeguridad()
                    habilitarBackUp()
                Else
                    MsgBox("Debe seleccionar una ruta de destino", MsgBoxStyle.Exclamation)
                    btnExaminar.Focus()
                    btnRespaldar.Enabled = False
                End If
            ElseIf e.KeyCode = Keys.F2 Then
                examinarRutaCopia()
            End If

        ElseIf tabBD.SelectedIndex = 1 Then

            If e.KeyCode = Keys.F5 Then
                If Not txtRestore.Text = "" Then
                    'restaurarBD()
                    habilitarRestore()
                Else
                    MsgBox("Debe seleccionar una ruta de ubicación", MsgBoxStyle.Exclamation)
                    btnExaminarRestore.Focus()
                    btnRestore.Enabled = False
                End If

            ElseIf e.KeyCode = Keys.F2 Then
                examinarRutaRestore()
            End If

        ElseIf tabBD.SelectedIndex = 2 Then

            If e.KeyCode = Keys.F5 Then
                'compactar()
                habilitarCompacto()
            End If

        End If

    End Sub
    Private Sub frmAdmonBD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Obteniendo los datos de la clase Acceso Datos
        linkdatabase = New linkBD
        linkdatabase.obtenerDatos()
        'My.Application.Info.DirectoryPath 'Ruta de la carpeta DEBUG

        txtPath.Text = ""
        txtRestore.Text = ""
        btnRespaldar.Enabled = False
        btnRestore.Enabled = False
        Me.KeyPreview = True

        'Ruta de la base de datos
        txtCompact.Text = linkdatabase.nombreBaseDatos

        barraBackUp.Visible = False
        procesoBackUp.Visible = False
        lblporcentajeBackUp.Visible = False

        barraRestaurar.Visible = False
        procesoRestaura.Visible = False
        lblPorcentajeRestaura.Visible = False

        barraCompacta.Visible = False
        procesoCompacta.Visible = False
        lblPorcentajeCompacta.Visible = False

    End Sub
    '********************************BACKUP******************************************************
    'Click boton Examinar 
    Private Sub examinarRutaCopia()
        Try
            Dim dir As New FolderBrowserDialog
            If dir.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtPath.Text = dir.SelectedPath
                btnRespaldar.Enabled = True
                btnRespaldar.Select()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
        examinarRutaCopia()
    End Sub
    'Click boton OK
    Private Sub crearCopiaSeguridad()
        Try
            Dim n As FirebirdSql.Data.Services.FbBackup = New FirebirdSql.Data.Services.FbBackup()

            Dim fl As FirebirdSql.Data.Services.FbBackupFile = New FirebirdSql.Data.Services.FbBackupFile(txtPath.Text & "\" & linkdatabase.nombreCopiaSeguridad, FileLen(linkdatabase.nombreBaseDatos))

            n.BackupFiles.Add(fl)
            n.ConnectionString = "servertype=" & linkBD.servertype & ";username=" & linkdatabase.nombreUsuario & ";password=" & linkdatabase.password & ";database=" & linkdatabase.nombreBaseDatos
            n.Execute()
            MsgBox("Copia de seguridad creada", MsgBoxStyle.Information)
            btnRespaldar.Enabled = False
            txtPath.Text = ""

            lblporcentajeBackUp.Visible = False
            procesoBackUp.Text = "0"
            procesoBackUp.Visible = False
            barraBackUp.Value = 0
            barraBackUp.Visible = False

            btnExaminar.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnRespaldar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRespaldar.Click
        habilitarBackUp()
        'crearCopiaSeguridad()
    End Sub
    '************************RESTORE********************************************
    'Click boton Examinar
    Private Sub examinarRutaRestore()
        Try
            Dim openFD As New OpenFileDialog()
            With openFD
                .Title = "Seleccione archivos Backup"
                .Filter = "Todos los archivos (*.gdk)|*.gdk"
                .Multiselect = False
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.txtRestore.Text = .FileName
                    btnRestore.Enabled = True
                    btnRestore.Select()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnExaminarRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminarRestore.Click
        examinarRutaRestore()
    End Sub
    'Click boton Restaurar
    Private Sub restaurarBD()
        Dim n1 As FirebirdSql.Data.Services.FbRestore = New FirebirdSql.Data.Services.FbRestore()
        On Error GoTo 1
        On Error Resume Next

        Dim cs As FbConnectionStringBuilder = New FbConnectionStringBuilder
        Dim restoreSvc As FbRestore = New FbRestore

        cs.UserID = linkdatabase.nombreUsuario
        cs.Password = linkdatabase.password
        cs.Database = linkdatabase.nombreBaseDatos

        restoreSvc.ConnectionString() = cs.ToString
        restoreSvc.BackupFiles.Add(New FbBackupFile(txtRestore.Text, FileLen(linkdatabase.nombreBaseDatos)))
        restoreSvc.Verbose = True
        restoreSvc.PageSize = 4096
        restoreSvc.PageBuffers = 2048
        restoreSvc.Options = FbRestoreFlags.Replace
        FbConnection.ClearAllPools()
        restoreSvc.Execute()
        MsgBox("Base de Datos restaurada", MsgBoxStyle.Information)
        btnRestore.Enabled = False
        txtRestore.Text = ""

        lblPorcentajeRestaura.Visible = False
        procesoRestaura.Text = "0"
        procesoRestaura.Visible = False
        barraRestaurar.Value = 0
        barraRestaurar.Visible = False

        btnExaminarRestore.Focus()
        tabBD.SelectedTab = tabBD.TabPages.Item(0)
        Exit Sub
1:
        restoreSvc.Execute()

    End Sub
    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        habilitarRestore()
        'restaurarBD()
    End Sub
    '**********************************COMPACTAR***************************************************
    Private Sub compactar()
        Dim n As FirebirdSql.Data.Services.FbBackup = New FirebirdSql.Data.Services.FbBackup()
        Dim fl As FirebirdSql.Data.Services.FbBackupFile = New FirebirdSql.Data.Services.FbBackupFile(linkdatabase.nombreGDKBaseDatos & ".gdk", FileLen(linkdatabase.nombreBaseDatos))
        n.BackupFiles.Add(fl)
    
        n.ConnectionString = "servertype=" & linkBD.servertype & ";username=" & linkdatabase.nombreUsuario & ";password=" & linkdatabase.password & ";database=" & linkdatabase.nombreBaseDatos

        n.Execute()

        On Error Resume Next

        Dim cs As FbConnectionStringBuilder = New FbConnectionStringBuilder
        Dim restoreSvc As FbRestore = New FbRestore
        cs.UserID = linkdatabase.nombreUsuario
        cs.Password = linkdatabase.password
        cs.Database = linkdatabase.nombreBaseDatos
        restoreSvc.ConnectionString() = cs.ToString

        restoreSvc.BackupFiles.Add(New FbBackupFile(linkdatabase.nombreGDKBaseDatos & ".gdk", FileLen(linkdatabase.nombreBaseDatos)))
        restoreSvc.Verbose = True
        restoreSvc.PageSize = 4096
        restoreSvc.PageBuffers = 2048
        restoreSvc.Options = FbRestoreFlags.Replace
        FbConnection.ClearAllPools()
        restoreSvc.Execute()
        MsgBox("Base de Datos compactada", MsgBoxStyle.Information)

        lblPorcentajeCompacta.Visible = False
        procesoCompacta.Text = "0"
        procesoCompacta.Visible = False
        barraCompacta.Value = 0
        barraCompacta.Visible = False

        tabBD.SelectedTab = tabBD.TabPages.Item(0)
        Exit Sub
1:
        restoreSvc.Execute()
    End Sub
    Private Sub btnCompact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompact.Click
        habilitarCompacto()
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub timerBackUp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerBackUp.Tick
        Try
            barraBackUp.Value = barraBackUp.Value + 1
            procesoBackUp.Text = CInt(procesoBackUp.Text + 1)
            If CInt(barraBackUp.Value) = 100 Then
                timerBackUp.Stop()
                Try
                    crearCopiaSeguridad()
                Catch ex As Exception
                    MsgBox("Error. " & vbNewLine & ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub timerRestaura_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerRestaura.Tick
        Try
            barraRestaurar.Value = barraRestaurar.Value + 1
            procesoRestaura.Text = CInt(procesoRestaura.Text + 1)
            If CInt(barraRestaurar.Value) = 100 Then
                timerRestaura.Stop()
                Try
                    restaurarBD()
                Catch ex As Exception
                    MsgBox("Error. " & vbNewLine & ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub timerCompacta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerCompacta.Tick
        Try
            barraCompacta.Value = barraCompacta.Value + 1
            procesoCompacta.Text = CInt(procesoCompacta.Text + 1)
            If CInt(barraCompacta.Value) = 100 Then
                timerCompacta.Stop()
                Try
                    compactar()
                Catch ex As Exception
                    MsgBox("Error. " & vbNewLine & ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub habilitarCompacto()
        Try
            If MsgBox("Confirma que desea compactar la Base de Datos", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                timerCompacta.Start()
                procesoCompacta.Visible = True
                barraCompacta.Visible = True
                lblPorcentajeCompacta.Visible = True
            Else
                tabBD.SelectedTab = tabBD.TabPages.Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub habilitarBackUp()
        Try
            timerBackUp.Start()
            procesoBackUp.Visible = True
            barraBackUp.Visible = True
            lblporcentajeBackUp.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub habilitarRestore()
        Try
            timerRestaura.Start()
            procesoRestaura.Visible = True
            barraRestaurar.Visible = True
            lblPorcentajeRestaura.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmAdmonBD_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class