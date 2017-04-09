<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResumenVentas
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
        Me.lblfechaInicial = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.lblfechaFinal = New System.Windows.Forms.Label()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.chkVendedor = New System.Windows.Forms.CheckBox()
        Me.btnverVentas = New System.Windows.Forms.Button()
        Me.dgvVentas = New System.Windows.Forms.DataGridView()
        Me.lbltitulototal = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnMin = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblfechaInicial
        '
        Me.lblfechaInicial.AutoSize = True
        Me.lblfechaInicial.BackColor = System.Drawing.Color.Transparent
        Me.lblfechaInicial.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfechaInicial.Location = New System.Drawing.Point(14, 72)
        Me.lblfechaInicial.Name = "lblfechaInicial"
        Me.lblfechaInicial.Size = New System.Drawing.Size(73, 16)
        Me.lblfechaInicial.TabIndex = 0
        Me.lblfechaInicial.Text = "Ventas del:"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechainicio.Checked = False
        Me.dtpfechainicio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechainicio.Location = New System.Drawing.Point(104, 68)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(232, 22)
        Me.dtpfechainicio.TabIndex = 1
        '
        'lblfechaFinal
        '
        Me.lblfechaFinal.AutoSize = True
        Me.lblfechaFinal.BackColor = System.Drawing.Color.Transparent
        Me.lblfechaFinal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfechaFinal.Location = New System.Drawing.Point(347, 72)
        Me.lblfechaFinal.Name = "lblfechaFinal"
        Me.lblfechaFinal.Size = New System.Drawing.Size(22, 16)
        Me.lblfechaFinal.TabIndex = 2
        Me.lblfechaFinal.Text = "al:"
        '
        'dtpfechafin
        '
        Me.dtpfechafin.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechafin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechafin.Location = New System.Drawing.Point(377, 68)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(239, 22)
        Me.dtpfechafin.TabIndex = 2
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(103, 127)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(121, 24)
        Me.cboVendedor.TabIndex = 4
        '
        'chkVendedor
        '
        Me.chkVendedor.AutoSize = True
        Me.chkVendedor.BackColor = System.Drawing.Color.Transparent
        Me.chkVendedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVendedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVendedor.Location = New System.Drawing.Point(16, 131)
        Me.chkVendedor.Name = "chkVendedor"
        Me.chkVendedor.Size = New System.Drawing.Size(81, 20)
        Me.chkVendedor.TabIndex = 3
        Me.chkVendedor.Text = "Vendedor"
        Me.chkVendedor.UseVisualStyleBackColor = False
        '
        'btnverVentas
        '
        Me.btnverVentas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnverVentas.Image = Global.Papeleria.My.Resources.Resources.search3
        Me.btnverVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnverVentas.Location = New System.Drawing.Point(377, 115)
        Me.btnverVentas.Name = "btnverVentas"
        Me.btnverVentas.Size = New System.Drawing.Size(40, 36)
        Me.btnverVentas.TabIndex = 5
        Me.btnverVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnverVentas.UseVisualStyleBackColor = True
        '
        'dgvVentas
        '
        Me.dgvVentas.AllowUserToAddRows = False
        Me.dgvVentas.AllowUserToDeleteRows = False
        Me.dgvVentas.AllowUserToOrderColumns = True
        Me.dgvVentas.AllowUserToResizeRows = False
        Me.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentas.Location = New System.Drawing.Point(17, 175)
        Me.dgvVentas.Name = "dgvVentas"
        Me.dgvVentas.ReadOnly = True
        Me.dgvVentas.Size = New System.Drawing.Size(726, 298)
        Me.dgvVentas.TabIndex = 6
        '
        'lbltitulototal
        '
        Me.lbltitulototal.AutoSize = True
        Me.lbltitulototal.BackColor = System.Drawing.Color.Transparent
        Me.lbltitulototal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulototal.Location = New System.Drawing.Point(235, 512)
        Me.lbltitulototal.Name = "lbltitulototal"
        Me.lbltitulototal.Size = New System.Drawing.Size(46, 16)
        Me.lbltitulototal.TabIndex = 9
        Me.lbltitulototal.Text = "Total $"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(281, 512)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(15, 16)
        Me.lblTotal.TabIndex = 10
        Me.lblTotal.Text = "0"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(647, 12)
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
        Me.btnClose.Location = New System.Drawing.Point(709, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 21
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.Papeleria.My.Resources.Resources.cancelar1
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(17, 495)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(71, 43)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(104, 495)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 43)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Exportar Pdf"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmResumenVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(765, 564)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lbltitulototal)
        Me.Controls.Add(Me.dgvVentas)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnverVentas)
        Me.Controls.Add(Me.chkVendedor)
        Me.Controls.Add(Me.cboVendedor)
        Me.Controls.Add(Me.dtpfechafin)
        Me.Controls.Add(Me.lblfechaFinal)
        Me.Controls.Add(Me.dtpfechainicio)
        Me.Controls.Add(Me.lblfechaInicial)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmResumenVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas"
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblfechaInicial As System.Windows.Forms.Label
    Friend WithEvents dtpfechainicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfechaFinal As System.Windows.Forms.Label
    Friend WithEvents dtpfechafin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents chkVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents btnverVentas As System.Windows.Forms.Button
    Friend WithEvents dgvVentas As System.Windows.Forms.DataGridView
    Friend WithEvents lbltitulototal As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
