<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmonBD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.tabBD = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lblporcentajeBackUp = New System.Windows.Forms.Label
        Me.procesoBackUp = New System.Windows.Forms.Label
        Me.barraBackUp = New System.Windows.Forms.ProgressBar
        Me.btnRespaldar = New System.Windows.Forms.Button
        Me.btnExaminar = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.lblUbicacionBack = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lblPorcentajeRestaura = New System.Windows.Forms.Label
        Me.procesoRestaura = New System.Windows.Forms.Label
        Me.barraRestaurar = New System.Windows.Forms.ProgressBar
        Me.btnRestore = New System.Windows.Forms.Button
        Me.btnExaminarRestore = New System.Windows.Forms.Button
        Me.txtRestore = New System.Windows.Forms.TextBox
        Me.lblUbicacionRestore = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.lblPorcentajeCompacta = New System.Windows.Forms.Label
        Me.procesoCompacta = New System.Windows.Forms.Label
        Me.barraCompacta = New System.Windows.Forms.ProgressBar
        Me.btnCompact = New System.Windows.Forms.Button
        Me.txtCompact = New System.Windows.Forms.TextBox
        Me.lblUbicacionCompact = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.timerBackUp = New System.Windows.Forms.Timer(Me.components)
        Me.timerRestaura = New System.Windows.Forms.Timer(Me.components)
        Me.timerCompacta = New System.Windows.Forms.Timer(Me.components)
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tabBD.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabBD
        '
        Me.tabBD.Controls.Add(Me.TabPage1)
        Me.tabBD.Controls.Add(Me.TabPage2)
        Me.tabBD.Controls.Add(Me.TabPage3)
        Me.tabBD.Location = New System.Drawing.Point(16, 47)
        Me.tabBD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabBD.Name = "tabBD"
        Me.tabBD.SelectedIndex = 0
        Me.tabBD.Size = New System.Drawing.Size(797, 263)
        Me.tabBD.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblporcentajeBackUp)
        Me.TabPage1.Controls.Add(Me.procesoBackUp)
        Me.TabPage1.Controls.Add(Me.barraBackUp)
        Me.TabPage1.Controls.Add(Me.btnRespaldar)
        Me.TabPage1.Controls.Add(Me.btnExaminar)
        Me.TabPage1.Controls.Add(Me.txtPath)
        Me.TabPage1.Controls.Add(Me.lblUbicacionBack)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(789, 234)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Crear Copia de Seguridad"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblporcentajeBackUp
        '
        Me.lblporcentajeBackUp.AutoSize = True
        Me.lblporcentajeBackUp.Location = New System.Drawing.Point(185, 172)
        Me.lblporcentajeBackUp.Name = "lblporcentajeBackUp"
        Me.lblporcentajeBackUp.Size = New System.Drawing.Size(20, 16)
        Me.lblporcentajeBackUp.TabIndex = 5
        Me.lblporcentajeBackUp.Text = "%"
        '
        'procesoBackUp
        '
        Me.procesoBackUp.AutoSize = True
        Me.procesoBackUp.Location = New System.Drawing.Point(157, 172)
        Me.procesoBackUp.Name = "procesoBackUp"
        Me.procesoBackUp.Size = New System.Drawing.Size(15, 16)
        Me.procesoBackUp.TabIndex = 4
        Me.procesoBackUp.Text = "0"
        '
        'barraBackUp
        '
        Me.barraBackUp.Location = New System.Drawing.Point(10, 167)
        Me.barraBackUp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barraBackUp.Name = "barraBackUp"
        Me.barraBackUp.Size = New System.Drawing.Size(132, 28)
        Me.barraBackUp.TabIndex = 3
        '
        'btnRespaldar
        '
        Me.btnRespaldar.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnRespaldar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRespaldar.Location = New System.Drawing.Point(684, 154)
        Me.btnRespaldar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRespaldar.Name = "btnRespaldar"
        Me.btnRespaldar.Size = New System.Drawing.Size(83, 48)
        Me.btnRespaldar.TabIndex = 2
        Me.btnRespaldar.Text = "O.K."
        Me.btnRespaldar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRespaldar.UseVisualStyleBackColor = True
        '
        'btnExaminar
        '
        Me.btnExaminar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(684, 62)
        Me.btnExaminar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(83, 47)
        Me.btnExaminar.TabIndex = 1
        Me.btnExaminar.Text = "..."
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(217, 69)
        Me.txtPath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(452, 22)
        Me.txtPath.TabIndex = 1
        Me.txtPath.TabStop = False
        '
        'lblUbicacionBack
        '
        Me.lblUbicacionBack.AutoSize = True
        Me.lblUbicacionBack.Location = New System.Drawing.Point(7, 76)
        Me.lblUbicacionBack.Name = "lblUbicacionBack"
        Me.lblUbicacionBack.Size = New System.Drawing.Size(174, 16)
        Me.lblUbicacionBack.TabIndex = 0
        Me.lblUbicacionBack.Text = "Crear copia de seguridad en:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblPorcentajeRestaura)
        Me.TabPage2.Controls.Add(Me.procesoRestaura)
        Me.TabPage2.Controls.Add(Me.barraRestaurar)
        Me.TabPage2.Controls.Add(Me.btnRestore)
        Me.TabPage2.Controls.Add(Me.btnExaminarRestore)
        Me.TabPage2.Controls.Add(Me.txtRestore)
        Me.TabPage2.Controls.Add(Me.lblUbicacionRestore)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(789, 234)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Restaurar Base de Datos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblPorcentajeRestaura
        '
        Me.lblPorcentajeRestaura.AutoSize = True
        Me.lblPorcentajeRestaura.Location = New System.Drawing.Point(185, 171)
        Me.lblPorcentajeRestaura.Name = "lblPorcentajeRestaura"
        Me.lblPorcentajeRestaura.Size = New System.Drawing.Size(20, 16)
        Me.lblPorcentajeRestaura.TabIndex = 8
        Me.lblPorcentajeRestaura.Text = "%"
        '
        'procesoRestaura
        '
        Me.procesoRestaura.AutoSize = True
        Me.procesoRestaura.Location = New System.Drawing.Point(157, 171)
        Me.procesoRestaura.Name = "procesoRestaura"
        Me.procesoRestaura.Size = New System.Drawing.Size(15, 16)
        Me.procesoRestaura.TabIndex = 7
        Me.procesoRestaura.Text = "0"
        '
        'barraRestaurar
        '
        Me.barraRestaurar.Location = New System.Drawing.Point(10, 166)
        Me.barraRestaurar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barraRestaurar.Name = "barraRestaurar"
        Me.barraRestaurar.Size = New System.Drawing.Size(132, 28)
        Me.barraRestaurar.TabIndex = 6
        '
        'btnRestore
        '
        Me.btnRestore.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRestore.Location = New System.Drawing.Point(568, 132)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(83, 48)
        Me.btnRestore.TabIndex = 2
        Me.btnRestore.Text = "O.K."
        Me.btnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'btnExaminarRestore
        '
        Me.btnExaminarRestore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminarRestore.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnExaminarRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminarRestore.Location = New System.Drawing.Point(568, 62)
        Me.btnExaminarRestore.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExaminarRestore.Name = "btnExaminarRestore"
        Me.btnExaminarRestore.Size = New System.Drawing.Size(83, 47)
        Me.btnExaminarRestore.TabIndex = 1
        Me.btnExaminarRestore.Text = "..."
        Me.btnExaminarRestore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminarRestore.UseVisualStyleBackColor = True
        '
        'txtRestore
        '
        Me.txtRestore.Location = New System.Drawing.Point(97, 71)
        Me.txtRestore.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRestore.Name = "txtRestore"
        Me.txtRestore.ReadOnly = True
        Me.txtRestore.Size = New System.Drawing.Size(452, 22)
        Me.txtRestore.TabIndex = 2
        Me.txtRestore.TabStop = False
        '
        'lblUbicacionRestore
        '
        Me.lblUbicacionRestore.AutoSize = True
        Me.lblUbicacionRestore.Location = New System.Drawing.Point(7, 79)
        Me.lblUbicacionRestore.Name = "lblUbicacionRestore"
        Me.lblUbicacionRestore.Size = New System.Drawing.Size(71, 16)
        Me.lblUbicacionRestore.TabIndex = 1
        Me.lblUbicacionRestore.Text = "Buscar en:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lblPorcentajeCompacta)
        Me.TabPage3.Controls.Add(Me.procesoCompacta)
        Me.TabPage3.Controls.Add(Me.barraCompacta)
        Me.TabPage3.Controls.Add(Me.btnCompact)
        Me.TabPage3.Controls.Add(Me.txtCompact)
        Me.TabPage3.Controls.Add(Me.lblUbicacionCompact)
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(789, 234)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Compactar Base de Datos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lblPorcentajeCompacta
        '
        Me.lblPorcentajeCompacta.AutoSize = True
        Me.lblPorcentajeCompacta.Location = New System.Drawing.Point(188, 174)
        Me.lblPorcentajeCompacta.Name = "lblPorcentajeCompacta"
        Me.lblPorcentajeCompacta.Size = New System.Drawing.Size(20, 16)
        Me.lblPorcentajeCompacta.TabIndex = 11
        Me.lblPorcentajeCompacta.Text = "%"
        '
        'procesoCompacta
        '
        Me.procesoCompacta.AutoSize = True
        Me.procesoCompacta.Location = New System.Drawing.Point(160, 174)
        Me.procesoCompacta.Name = "procesoCompacta"
        Me.procesoCompacta.Size = New System.Drawing.Size(15, 16)
        Me.procesoCompacta.TabIndex = 10
        Me.procesoCompacta.Text = "0"
        '
        'barraCompacta
        '
        Me.barraCompacta.Location = New System.Drawing.Point(13, 169)
        Me.barraCompacta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barraCompacta.Name = "barraCompacta"
        Me.barraCompacta.Size = New System.Drawing.Size(132, 28)
        Me.barraCompacta.TabIndex = 9
        '
        'btnCompact
        '
        Me.btnCompact.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnCompact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCompact.Location = New System.Drawing.Point(605, 42)
        Me.btnCompact.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCompact.Name = "btnCompact"
        Me.btnCompact.Size = New System.Drawing.Size(83, 48)
        Me.btnCompact.TabIndex = 2
        Me.btnCompact.Text = "O.K."
        Me.btnCompact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCompact.UseVisualStyleBackColor = True
        '
        'txtCompact
        '
        Me.txtCompact.Location = New System.Drawing.Point(131, 63)
        Me.txtCompact.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCompact.Name = "txtCompact"
        Me.txtCompact.ReadOnly = True
        Me.txtCompact.Size = New System.Drawing.Size(452, 22)
        Me.txtCompact.TabIndex = 1
        Me.txtCompact.TabStop = False
        Me.txtCompact.Visible = False
        '
        'lblUbicacionCompact
        '
        Me.lblUbicacionCompact.AutoSize = True
        Me.lblUbicacionCompact.Location = New System.Drawing.Point(9, 70)
        Me.lblUbicacionCompact.Name = "lblUbicacionCompact"
        Me.lblUbicacionCompact.Size = New System.Drawing.Size(98, 16)
        Me.lblUbicacionCompact.TabIndex = 2
        Me.lblUbicacionCompact.Text = "Base de Datos:"
        Me.lblUbicacionCompact.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(16, 333)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(83, 48)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'timerBackUp
        '
        Me.timerBackUp.Interval = 1
        '
        'timerRestaura
        '
        Me.timerRestaura.Interval = 1
        '
        'timerCompacta
        '
        Me.timerCompacta.Interval = 1
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(694, 6)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(25, 25)
        Me.btnMin.TabIndex = 22
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImage = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(778, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 21
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmAdmonBD
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(834, 405)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.tabBD)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmAdmonBD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de la Base de Datos"
        Me.tabBD.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabBD As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lblUbicacionBack As System.Windows.Forms.Label
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnRespaldar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblUbicacionRestore As System.Windows.Forms.Label
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents btnExaminarRestore As System.Windows.Forms.Button
    Friend WithEvents txtRestore As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicacionCompact As System.Windows.Forms.Label
    Friend WithEvents btnCompact As System.Windows.Forms.Button
    Friend WithEvents txtCompact As System.Windows.Forms.TextBox
    Friend WithEvents barraBackUp As System.Windows.Forms.ProgressBar
    Friend WithEvents timerBackUp As System.Windows.Forms.Timer
    Friend WithEvents procesoBackUp As System.Windows.Forms.Label
    Friend WithEvents lblporcentajeBackUp As System.Windows.Forms.Label
    Friend WithEvents timerRestaura As System.Windows.Forms.Timer
    Friend WithEvents timerCompacta As System.Windows.Forms.Timer
    Friend WithEvents lblPorcentajeRestaura As System.Windows.Forms.Label
    Friend WithEvents procesoRestaura As System.Windows.Forms.Label
    Friend WithEvents barraRestaurar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPorcentajeCompacta As System.Windows.Forms.Label
    Friend WithEvents procesoCompacta As System.Windows.Forms.Label
    Friend WithEvents barraCompacta As System.Windows.Forms.ProgressBar
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
