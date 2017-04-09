<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbonoCuentaPagar
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtabono = New System.Windows.Forms.TextBox
        Me.DGVabonos = New System.Windows.Forms.DataGridView
        Me.btnagregarabono = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txttotalcredito = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtrestocredito = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DGVcreditos = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtFecha = New System.Windows.Forms.DateTimePicker
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnMin = New System.Windows.Forms.Button
        CType(Me.DGVabonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGVcreditos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Abono"
        '
        'txtabono
        '
        Me.txtabono.Location = New System.Drawing.Point(69, 30)
        Me.txtabono.Name = "txtabono"
        Me.txtabono.Size = New System.Drawing.Size(110, 20)
        Me.txtabono.TabIndex = 3
        '
        'DGVabonos
        '
        Me.DGVabonos.AllowUserToAddRows = False
        Me.DGVabonos.AllowUserToDeleteRows = False
        Me.DGVabonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVabonos.Location = New System.Drawing.Point(21, 70)
        Me.DGVabonos.Name = "DGVabonos"
        Me.DGVabonos.ReadOnly = True
        Me.DGVabonos.Size = New System.Drawing.Size(292, 135)
        Me.DGVabonos.TabIndex = 4
        '
        'btnagregarabono
        '
        Me.btnagregarabono.Image = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnagregarabono.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregarabono.Location = New System.Drawing.Point(185, 18)
        Me.btnagregarabono.Name = "btnagregarabono"
        Me.btnagregarabono.Size = New System.Drawing.Size(86, 42)
        Me.btnagregarabono.TabIndex = 82
        Me.btnagregarabono.Text = "Agregar"
        Me.btnagregarabono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregarabono.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 212)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Total Crédito"
        '
        'txttotalcredito
        '
        Me.txttotalcredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalcredito.ForeColor = System.Drawing.Color.Black
        Me.txttotalcredito.Location = New System.Drawing.Point(46, 231)
        Me.txttotalcredito.Multiline = True
        Me.txttotalcredito.Name = "txttotalcredito"
        Me.txttotalcredito.ReadOnly = True
        Me.txttotalcredito.Size = New System.Drawing.Size(105, 24)
        Me.txttotalcredito.TabIndex = 93
        Me.txttotalcredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(185, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Resto Crédito"
        '
        'txtrestocredito
        '
        Me.txtrestocredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrestocredito.ForeColor = System.Drawing.Color.Black
        Me.txtrestocredito.Location = New System.Drawing.Point(175, 231)
        Me.txtrestocredito.Multiline = True
        Me.txtrestocredito.Name = "txtrestocredito"
        Me.txtrestocredito.ReadOnly = True
        Me.txtrestocredito.Size = New System.Drawing.Size(105, 24)
        Me.txtrestocredito.TabIndex = 95
        Me.txtrestocredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.DGVabonos)
        Me.GroupBox2.Controls.Add(Me.txtrestocredito)
        Me.GroupBox2.Controls.Add(Me.btnagregarabono)
        Me.GroupBox2.Controls.Add(Me.txtabono)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txttotalcredito)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(482, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(331, 262)
        Me.GroupBox2.TabIndex = 96
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agregar Abono"
        '
        'DGVcreditos
        '
        Me.DGVcreditos.AllowUserToAddRows = False
        Me.DGVcreditos.AllowUserToDeleteRows = False
        Me.DGVcreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVcreditos.Location = New System.Drawing.Point(21, 51)
        Me.DGVcreditos.Name = "DGVcreditos"
        Me.DGVcreditos.ReadOnly = True
        Me.DGVcreditos.Size = New System.Drawing.Size(414, 205)
        Me.DGVcreditos.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 16)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Buscar crédito por fecha"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DGVcreditos)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 262)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar Crédito"
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(173, 23)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(262, 20)
        Me.dtFecha.TabIndex = 89
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImage = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(793, 7)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(18, 18)
        Me.btnClose.TabIndex = 100
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(706, 7)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(18, 18)
        Me.btnMin.TabIndex = 99
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'frmAbonoCuentaPagar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(840, 334)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAbonoCuentaPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abono Cuentas Por Pagar"
        CType(Me.DGVabonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGVcreditos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtabono As System.Windows.Forms.TextBox
    Friend WithEvents DGVabonos As System.Windows.Forms.DataGridView
    Friend WithEvents btnagregarabono As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttotalcredito As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtrestocredito As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVcreditos As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
End Class
