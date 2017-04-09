Imports LogicaNegocio
Imports System.IO
Public Class frmImagen

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName.Trim <> "" Then

            If File.Exists(OpenFileDialog1.FileName) Then
                cargar(OpenFileDialog1.FileName)
            Else
                MsgBox("No se encontro el archivo especificado")
            End If
        End If

    End Sub

    Private Sub cargar(ByVal file As String)
        PictureBox1.Image = Image.FromFile(file)
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmImagen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ClearMemory()
    End Sub

    Private Sub frmCompra_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub

    Private Sub frmFaltantes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
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

    Private Sub frmImagen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If Sesion.imagen.Trim <> "" Then
                If File.Exists(Sesion.imagen) Then
                    PictureBox1.Image = Image.FromFile(Sesion.imagen)
                Else
                    MsgBox("No se encuentra la imagen")
                End If

            End If

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try



            If OpenFileDialog1.FileName.Trim = "" Then
                Throw New Exception("No se ha seleccionado una imagen")
            Else
                Dim service As New Service_Configuracion
                service.insertarImagen(OpenFileDialog1.FileName)
                Sesion.imagen = OpenFileDialog1.FileName
                Me.Close()
            End If

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class