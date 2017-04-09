<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeudas
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
        Me.dgvDeudas = New System.Windows.Forms.DataGridView
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.lblCliente = New System.Windows.Forms.Label
        Me.lblAl = New System.Windows.Forms.Label
        Me.lblDel = New System.Windows.Forms.Label
        Me.dtpfin = New System.Windows.Forms.DateTimePicker
        Me.dtpinicio = New System.Windows.Forms.DateTimePicker
        Me.btnSalir = New System.Windows.Forms.Button
        Me.lblTitulototal = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblTituloDeudores = New System.Windows.Forms.Label
        Me.lblDeudas = New System.Windows.Forms.Label
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.lbldeudasfecha = New System.Windows.Forms.Label
        Me.lbltotalfechas = New System.Windows.Forms.Label
        Me.lbltitulototalfechas = New System.Windows.Forms.Label
        Me.lbltitulofechadeudas = New System.Windows.Forms.Label
        CType(Me.dgvDeudas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDeudas
        '
        Me.dgvDeudas.AllowUserToAddRows = False
        Me.dgvDeudas.AllowUserToDeleteRows = False
        Me.dgvDeudas.AllowUserToOrderColumns = True
        Me.dgvDeudas.AllowUserToResizeRows = False
        Me.dgvDeudas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDeudas.Location = New System.Drawing.Point(34, 169)
        Me.dgvDeudas.Name = "dgvDeudas"
        Me.dgvDeudas.ReadOnly = True
        Me.dgvDeudas.Size = New System.Drawing.Size(784, 370)
        Me.dgvDeudas.TabIndex = 0
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Location = New System.Drawing.Point(123, 141)
        Me.txtCliente.MaxLength = 15
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(251, 22)
        Me.txtCliente.TabIndex = 1
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(69, 147)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(48, 16)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "Cliente"
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Location = New System.Drawing.Point(41, 116)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(76, 16)
        Me.lblAl.TabIndex = 7
        Me.lblAl.Text = "Fecha Final"
        '
        'lblDel
        '
        Me.lblDel.AutoSize = True
        Me.lblDel.Location = New System.Drawing.Point(36, 89)
        Me.lblDel.Name = "lblDel"
        Me.lblDel.Size = New System.Drawing.Size(81, 16)
        Me.lblDel.TabIndex = 6
        Me.lblDel.Text = "Fecha Inicial"
        '
        'dtpfin
        '
        Me.dtpfin.Location = New System.Drawing.Point(123, 113)
        Me.dtpfin.Name = "dtpfin"
        Me.dtpfin.Size = New System.Drawing.Size(251, 22)
        Me.dtpfin.TabIndex = 5
        '
        'dtpinicio
        '
        Me.dtpinicio.Location = New System.Drawing.Point(123, 86)
        Me.dtpinicio.Name = "dtpinicio"
        Me.dtpinicio.Size = New System.Drawing.Size(251, 22)
        Me.dtpinicio.TabIndex = 4
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Papeleria.My.Resources.Resources.cancel2
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(34, 545)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 45)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblTitulototal
        '
        Me.lblTitulototal.AutoSize = True
        Me.lblTitulototal.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulototal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulototal.Location = New System.Drawing.Point(274, 587)
        Me.lblTitulototal.Name = "lblTitulototal"
        Me.lblTitulototal.Size = New System.Drawing.Size(51, 16)
        Me.lblTitulototal.TabIndex = 2
        Me.lblTitulototal.Text = "Total $"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(343, 586)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(15, 16)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "0"
        '
        'lblTituloDeudores
        '
        Me.lblTituloDeudores.AutoSize = True
        Me.lblTituloDeudores.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloDeudores.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloDeudores.Location = New System.Drawing.Point(270, 549)
        Me.lblTituloDeudores.Name = "lblTituloDeudores"
        Me.lblTituloDeudores.Size = New System.Drawing.Size(55, 16)
        Me.lblTituloDeudores.TabIndex = 4
        Me.lblTituloDeudores.Text = "Deudas"
        '
        'lblDeudas
        '
        Me.lblDeudas.AutoSize = True
        Me.lblDeudas.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudas.Location = New System.Drawing.Point(343, 549)
        Me.lblDeudas.Name = "lblDeudas"
        Me.lblDeudas.Size = New System.Drawing.Size(15, 16)
        Me.lblDeudas.TabIndex = 5
        Me.lblDeudas.Text = "0"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(726, 12)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(25, 25)
        Me.btnMin.TabIndex = 24
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
        Me.btnClose.Location = New System.Drawing.Point(810, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 23
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(115, 545)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 43)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Exportar Pdf"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbldeudasfecha
        '
        Me.lbldeudasfecha.AutoSize = True
        Me.lbldeudasfecha.BackColor = System.Drawing.Color.Transparent
        Me.lbldeudasfecha.Location = New System.Drawing.Point(646, 549)
        Me.lbldeudasfecha.Name = "lbldeudasfecha"
        Me.lbldeudasfecha.Size = New System.Drawing.Size(15, 16)
        Me.lbldeudasfecha.TabIndex = 9
        Me.lbldeudasfecha.Text = "0"
        Me.lbldeudasfecha.Visible = False
        '
        'lbltotalfechas
        '
        Me.lbltotalfechas.AutoSize = True
        Me.lbltotalfechas.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalfechas.Location = New System.Drawing.Point(646, 586)
        Me.lbltotalfechas.Name = "lbltotalfechas"
        Me.lbltotalfechas.Size = New System.Drawing.Size(15, 16)
        Me.lbltotalfechas.TabIndex = 7
        Me.lbltotalfechas.Text = "0"
        Me.lbltotalfechas.Visible = False
        '
        'lbltitulototalfechas
        '
        Me.lbltitulototalfechas.AutoSize = True
        Me.lbltitulototalfechas.BackColor = System.Drawing.Color.Transparent
        Me.lbltitulototalfechas.Location = New System.Drawing.Point(593, 586)
        Me.lbltitulototalfechas.Name = "lbltitulototalfechas"
        Me.lbltitulototalfechas.Size = New System.Drawing.Size(47, 16)
        Me.lbltitulototalfechas.TabIndex = 6
        Me.lbltitulototalfechas.Text = "Total $"
        Me.lbltitulototalfechas.Visible = False
        '
        'lbltitulofechadeudas
        '
        Me.lbltitulofechadeudas.AutoSize = True
        Me.lbltitulofechadeudas.BackColor = System.Drawing.Color.Transparent
        Me.lbltitulofechadeudas.Location = New System.Drawing.Point(593, 548)
        Me.lbltitulofechadeudas.Name = "lbltitulofechadeudas"
        Me.lbltitulofechadeudas.Size = New System.Drawing.Size(52, 16)
        Me.lbltitulofechadeudas.TabIndex = 8
        Me.lbltitulofechadeudas.Text = "Deudas"
        Me.lbltitulofechadeudas.Visible = False
        '
        'frmDeudas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(864, 634)
        Me.Controls.Add(Me.lblAl)
        Me.Controls.Add(Me.dgvDeudas)
        Me.Controls.Add(Me.lblDel)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.dtpfin)
        Me.Controls.Add(Me.dtpinicio)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lbldeudasfecha)
        Me.Controls.Add(Me.lbltitulofechadeudas)
        Me.Controls.Add(Me.lbltotalfechas)
        Me.Controls.Add(Me.lbltitulototalfechas)
        Me.Controls.Add(Me.lblDeudas)
        Me.Controls.Add(Me.lblTituloDeudores)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblTitulototal)
        Me.Controls.Add(Me.btnSalir)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmDeudas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por cobrar"
        CType(Me.dgvDeudas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDeudas As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblTitulototal As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblTituloDeudores As System.Windows.Forms.Label
    Friend WithEvents lblDeudas As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblAl As System.Windows.Forms.Label
    Friend WithEvents lblDel As System.Windows.Forms.Label
    Friend WithEvents dtpfin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpinicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbldeudasfecha As System.Windows.Forms.Label
    Friend WithEvents lbltotalfechas As System.Windows.Forms.Label
    Friend WithEvents lbltitulototalfechas As System.Windows.Forms.Label
    Friend WithEvents lbltitulofechadeudas As System.Windows.Forms.Label
End Class
