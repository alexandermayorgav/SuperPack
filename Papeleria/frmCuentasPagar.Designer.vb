<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentasPagar
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
        Me.tab1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgv2 = New System.Windows.Forms.DataGridView
        Me.txtProveedor = New System.Windows.Forms.TextBox
        Me.lblProveedor = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.dtp2 = New System.Windows.Forms.DateTimePicker
        Me.lblfechaFin = New System.Windows.Forms.Label
        Me.lblfechaInicio = New System.Windows.Forms.Label
        Me.dtp1 = New System.Windows.Forms.DateTimePicker
        Me.dgv3 = New System.Windows.Forms.DataGridView
        Me.btnSalir = New System.Windows.Forms.Button
        Me.lblDeudas = New System.Windows.Forms.Label
        Me.lblTituloDeudores = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblTitulototal = New System.Windows.Forms.Label
        Me.lbltotalcuentasnew = New System.Windows.Forms.Label
        Me.lblcuentasnew = New System.Windows.Forms.Label
        Me.lblnumtotalnew = New System.Windows.Forms.Label
        Me.lbltotalnew = New System.Windows.Forms.Label
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.tab1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tab1
        '
        Me.tab1.Controls.Add(Me.TabPage1)
        Me.tab1.Controls.Add(Me.TabPage2)
        Me.tab1.Controls.Add(Me.TabPage3)
        Me.tab1.Location = New System.Drawing.Point(16, 67)
        Me.tab1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(862, 400)
        Me.tab1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgv1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(854, 371)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Todas las cuentas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToOrderColumns = True
        Me.dgv1.AllowUserToResizeRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(6, 7)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(842, 357)
        Me.dgv1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgv2)
        Me.TabPage2.Controls.Add(Me.txtProveedor)
        Me.TabPage2.Controls.Add(Me.lblProveedor)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(854, 371)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Por proveedor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.AllowUserToOrderColumns = True
        Me.dgv2.AllowUserToResizeRows = False
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Location = New System.Drawing.Point(6, 49)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(842, 365)
        Me.dgv2.TabIndex = 4
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Location = New System.Drawing.Point(152, 11)
        Me.txtProveedor.MaxLength = 15
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(225, 22)
        Me.txtProveedor.TabIndex = 1
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(6, 17)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(140, 16)
        Me.lblProveedor.TabIndex = 2
        Me.lblProveedor.Text = "Nombre / Razón social"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dtp2)
        Me.TabPage3.Controls.Add(Me.lblfechaFin)
        Me.TabPage3.Controls.Add(Me.lblfechaInicio)
        Me.TabPage3.Controls.Add(Me.dtp1)
        Me.TabPage3.Controls.Add(Me.dgv3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(854, 371)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Por fecha"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dtp2
        '
        Me.dtp2.Location = New System.Drawing.Point(458, 10)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(253, 22)
        Me.dtp2.TabIndex = 9
        '
        'lblfechaFin
        '
        Me.lblfechaFin.AutoSize = True
        Me.lblfechaFin.Location = New System.Drawing.Point(423, 16)
        Me.lblfechaFin.Name = "lblfechaFin"
        Me.lblfechaFin.Size = New System.Drawing.Size(22, 16)
        Me.lblfechaFin.TabIndex = 8
        Me.lblfechaFin.Text = "al:"
        '
        'lblfechaInicio
        '
        Me.lblfechaInicio.AutoSize = True
        Me.lblfechaInicio.Location = New System.Drawing.Point(3, 17)
        Me.lblfechaInicio.Name = "lblfechaInicio"
        Me.lblfechaInicio.Size = New System.Drawing.Size(139, 16)
        Me.lblfechaInicio.TabIndex = 7
        Me.lblfechaInicio.Text = "Cuentas por pagar del:"
        '
        'dtp1
        '
        Me.dtp1.Location = New System.Drawing.Point(148, 11)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(252, 22)
        Me.dtp1.TabIndex = 6
        '
        'dgv3
        '
        Me.dgv3.AllowUserToAddRows = False
        Me.dgv3.AllowUserToDeleteRows = False
        Me.dgv3.AllowUserToOrderColumns = True
        Me.dgv3.AllowUserToResizeRows = False
        Me.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv3.Location = New System.Drawing.Point(6, 48)
        Me.dgv3.Name = "dgv3"
        Me.dgv3.ReadOnly = True
        Me.dgv3.Size = New System.Drawing.Size(842, 365)
        Me.dgv3.TabIndex = 5
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Papeleria.My.Resources.Resources.cancel2
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(23, 477)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 41)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblDeudas
        '
        Me.lblDeudas.AutoSize = True
        Me.lblDeudas.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudas.Location = New System.Drawing.Point(367, 469)
        Me.lblDeudas.Name = "lblDeudas"
        Me.lblDeudas.Size = New System.Drawing.Size(15, 16)
        Me.lblDeudas.TabIndex = 9
        Me.lblDeudas.Text = "0"
        '
        'lblTituloDeudores
        '
        Me.lblTituloDeudores.AutoSize = True
        Me.lblTituloDeudores.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloDeudores.Location = New System.Drawing.Point(310, 468)
        Me.lblTituloDeudores.Name = "lblTituloDeudores"
        Me.lblTituloDeudores.Size = New System.Drawing.Size(56, 16)
        Me.lblTituloDeudores.TabIndex = 8
        Me.lblTituloDeudores.Text = "Cuentas"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Location = New System.Drawing.Point(367, 506)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(15, 16)
        Me.lblTotal.TabIndex = 7
        Me.lblTotal.Text = "0"
        '
        'lblTitulototal
        '
        Me.lblTitulototal.AutoSize = True
        Me.lblTitulototal.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulototal.Location = New System.Drawing.Point(310, 506)
        Me.lblTitulototal.Name = "lblTitulototal"
        Me.lblTitulototal.Size = New System.Drawing.Size(47, 16)
        Me.lblTitulototal.TabIndex = 6
        Me.lblTitulototal.Text = "Total $"
        '
        'lbltotalcuentasnew
        '
        Me.lbltotalcuentasnew.AutoSize = True
        Me.lbltotalcuentasnew.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalcuentasnew.Location = New System.Drawing.Point(469, 506)
        Me.lbltotalcuentasnew.Name = "lbltotalcuentasnew"
        Me.lbltotalcuentasnew.Size = New System.Drawing.Size(15, 16)
        Me.lbltotalcuentasnew.TabIndex = 13
        Me.lbltotalcuentasnew.Text = "0"
        '
        'lblcuentasnew
        '
        Me.lblcuentasnew.AutoSize = True
        Me.lblcuentasnew.BackColor = System.Drawing.Color.Transparent
        Me.lblcuentasnew.Location = New System.Drawing.Point(407, 469)
        Me.lblcuentasnew.Name = "lblcuentasnew"
        Me.lblcuentasnew.Size = New System.Drawing.Size(56, 16)
        Me.lblcuentasnew.TabIndex = 12
        Me.lblcuentasnew.Text = "Cuentas"
        '
        'lblnumtotalnew
        '
        Me.lblnumtotalnew.AutoSize = True
        Me.lblnumtotalnew.BackColor = System.Drawing.Color.Transparent
        Me.lblnumtotalnew.Location = New System.Drawing.Point(469, 469)
        Me.lblnumtotalnew.Name = "lblnumtotalnew"
        Me.lblnumtotalnew.Size = New System.Drawing.Size(15, 16)
        Me.lblnumtotalnew.TabIndex = 11
        Me.lblnumtotalnew.Text = "0"
        '
        'lbltotalnew
        '
        Me.lbltotalnew.AutoSize = True
        Me.lbltotalnew.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalnew.Location = New System.Drawing.Point(407, 507)
        Me.lbltotalnew.Name = "lbltotalnew"
        Me.lbltotalnew.Size = New System.Drawing.Size(47, 16)
        Me.lbltotalnew.TabIndex = 10
        Me.lbltotalnew.Text = "Total $"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(755, 12)
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
        Me.btnClose.Location = New System.Drawing.Point(839, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 21
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(104, 477)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 40)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Exportar Pdf"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmCuentasPagar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(899, 542)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lbltotalcuentasnew)
        Me.Controls.Add(Me.lblcuentasnew)
        Me.Controls.Add(Me.lblnumtotalnew)
        Me.Controls.Add(Me.lbltotalnew)
        Me.Controls.Add(Me.lblDeudas)
        Me.Controls.Add(Me.lblTituloDeudores)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblTitulototal)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.tab1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCuentasPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por pagar"
        Me.tab1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tab1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblDeudas As System.Windows.Forms.Label
    Friend WithEvents lblTituloDeudores As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblTitulototal As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfechaFin As System.Windows.Forms.Label
    Friend WithEvents lblfechaInicio As System.Windows.Forms.Label
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv3 As System.Windows.Forms.DataGridView
    Friend WithEvents lbltotalcuentasnew As System.Windows.Forms.Label
    Friend WithEvents lblcuentasnew As System.Windows.Forms.Label
    Friend WithEvents lblnumtotalnew As System.Windows.Forms.Label
    Friend WithEvents lbltotalnew As System.Windows.Forms.Label
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
