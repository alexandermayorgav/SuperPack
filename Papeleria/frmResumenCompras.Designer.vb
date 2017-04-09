<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResumenCompras
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
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lbltitulototal = New System.Windows.Forms.Label
        Me.dgvCompras = New System.Windows.Forms.DataGridView
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnverCompras = New System.Windows.Forms.Button
        Me.chkVendedor = New System.Windows.Forms.CheckBox
        Me.cboVendedor = New System.Windows.Forms.ComboBox
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker
        Me.lblfechaFinal = New System.Windows.Forms.Label
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker
        Me.lblfechaInicial = New System.Windows.Forms.Label
        Me.chkProveedor = New System.Windows.Forms.CheckBox
        Me.cboProveedor = New System.Windows.Forms.ComboBox
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(283, 513)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(15, 16)
        Me.lblTotal.TabIndex = 21
        Me.lblTotal.Text = "0"
        '
        'lbltitulototal
        '
        Me.lbltitulototal.AutoSize = True
        Me.lbltitulototal.BackColor = System.Drawing.Color.Transparent
        Me.lbltitulototal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulototal.Location = New System.Drawing.Point(237, 513)
        Me.lbltitulototal.Name = "lbltitulototal"
        Me.lbltitulototal.Size = New System.Drawing.Size(46, 16)
        Me.lbltitulototal.TabIndex = 20
        Me.lbltitulototal.Text = "Total $"
        '
        'dgvCompras
        '
        Me.dgvCompras.AllowUserToAddRows = False
        Me.dgvCompras.AllowUserToDeleteRows = False
        Me.dgvCompras.AllowUserToOrderColumns = True
        Me.dgvCompras.AllowUserToResizeRows = False
        Me.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompras.Location = New System.Drawing.Point(19, 190)
        Me.dgvCompras.Name = "dgvCompras"
        Me.dgvCompras.ReadOnly = True
        Me.dgvCompras.Size = New System.Drawing.Size(745, 301)
        Me.dgvCompras.TabIndex = 18
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.Papeleria.My.Resources.Resources.cancelar1
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(19, 496)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(71, 43)
        Me.btnSalir.TabIndex = 19
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnverCompras
        '
        Me.btnverCompras.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnverCompras.Image = Global.Papeleria.My.Resources.Resources.search3
        Me.btnverCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnverCompras.Location = New System.Drawing.Point(724, 148)
        Me.btnverCompras.Name = "btnverCompras"
        Me.btnverCompras.Size = New System.Drawing.Size(40, 36)
        Me.btnverCompras.TabIndex = 17
        Me.btnverCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnverCompras.UseVisualStyleBackColor = True
        '
        'chkVendedor
        '
        Me.chkVendedor.AutoSize = True
        Me.chkVendedor.BackColor = System.Drawing.Color.Transparent
        Me.chkVendedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVendedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVendedor.Location = New System.Drawing.Point(19, 113)
        Me.chkVendedor.Name = "chkVendedor"
        Me.chkVendedor.Size = New System.Drawing.Size(81, 20)
        Me.chkVendedor.TabIndex = 15
        Me.chkVendedor.Text = "Vendedor"
        Me.chkVendedor.UseVisualStyleBackColor = False
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(106, 109)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(178, 24)
        Me.cboVendedor.TabIndex = 16
        '
        'dtpfechafin
        '
        Me.dtpfechafin.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechafin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechafin.Location = New System.Drawing.Point(416, 67)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(239, 22)
        Me.dtpfechafin.TabIndex = 13
        '
        'lblfechaFinal
        '
        Me.lblfechaFinal.AutoSize = True
        Me.lblfechaFinal.BackColor = System.Drawing.Color.Transparent
        Me.lblfechaFinal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfechaFinal.Location = New System.Drawing.Point(367, 72)
        Me.lblfechaFinal.Name = "lblfechaFinal"
        Me.lblfechaFinal.Size = New System.Drawing.Size(22, 16)
        Me.lblfechaFinal.TabIndex = 14
        Me.lblfechaFinal.Text = "al:"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechainicio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechainicio.Location = New System.Drawing.Point(106, 66)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(232, 22)
        Me.dtpfechainicio.TabIndex = 12
        '
        'lblfechaInicial
        '
        Me.lblfechaInicial.AutoSize = True
        Me.lblfechaInicial.BackColor = System.Drawing.Color.Transparent
        Me.lblfechaInicial.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfechaInicial.Location = New System.Drawing.Point(16, 70)
        Me.lblfechaInicial.Name = "lblfechaInicial"
        Me.lblfechaInicial.Size = New System.Drawing.Size(85, 16)
        Me.lblfechaInicial.TabIndex = 11
        Me.lblfechaInicial.Text = "Compras del:"
        '
        'chkProveedor
        '
        Me.chkProveedor.AutoSize = True
        Me.chkProveedor.BackColor = System.Drawing.Color.Transparent
        Me.chkProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkProveedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkProveedor.Location = New System.Drawing.Point(318, 113)
        Me.chkProveedor.Name = "chkProveedor"
        Me.chkProveedor.Size = New System.Drawing.Size(84, 20)
        Me.chkProveedor.TabIndex = 22
        Me.chkProveedor.Text = "Proveedor"
        Me.chkProveedor.UseVisualStyleBackColor = False
        '
        'cboProveedor
        '
        Me.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(416, 109)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(348, 24)
        Me.cboProveedor.TabIndex = 23
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(659, 12)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(25, 25)
        Me.btnMin.TabIndex = 25
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
        Me.btnClose.Location = New System.Drawing.Point(733, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 24
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(106, 496)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 43)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Exportar Pdf"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmResumenCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(787, 564)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cboProveedor)
        Me.Controls.Add(Me.chkProveedor)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lbltitulototal)
        Me.Controls.Add(Me.dgvCompras)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnverCompras)
        Me.Controls.Add(Me.chkVendedor)
        Me.Controls.Add(Me.cboVendedor)
        Me.Controls.Add(Me.dtpfechafin)
        Me.Controls.Add(Me.lblfechaFinal)
        Me.Controls.Add(Me.dtpfechainicio)
        Me.Controls.Add(Me.lblfechaInicial)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmResumenCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras"
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lbltitulototal As System.Windows.Forms.Label
    Friend WithEvents dgvCompras As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnverCompras As System.Windows.Forms.Button
    Friend WithEvents chkVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents dtpfechafin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfechaFinal As System.Windows.Forms.Label
    Friend WithEvents dtpfechainicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfechaInicial As System.Windows.Forms.Label
    Friend WithEvents chkProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents cboProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
