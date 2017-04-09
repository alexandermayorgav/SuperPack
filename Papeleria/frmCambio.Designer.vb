<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambio
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
        Me.txtEfectivo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSubtotal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCambio = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblUsar = New System.Windows.Forms.Label
        Me.txtUsar = New System.Windows.Forms.TextBox
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtnumoperacion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtmontotarjeta = New System.Windows.Forms.TextBox
        Me.dgvtarjeta = New System.Windows.Forms.DataGridView
        Me.numoperacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnagregartarjeta = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnagregarmontovale = New System.Windows.Forms.Button
        Me.dgvVales = New System.Windows.Forms.DataGridView
        Me.folio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.montousar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.montorestante = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtmontousarvale = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtmontovale = New System.Windows.Forms.TextBox
        Me.btnobtenervale = New System.Windows.Forms.Button
        Me.txtfoliovale = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtrestopago = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtpagorealizado = New System.Windows.Forms.TextBox
        Me.btnfinalizar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvtarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvVales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(71, 26)
        Me.txtEfectivo.Multiline = True
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(132, 32)
        Me.txtEfectivo.TabIndex = 2
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Efectivo:"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(80, 53)
        Me.txtSubtotal.Multiline = True
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(150, 32)
        Me.txtSubtotal.TabIndex = 1
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 19)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Total"
        '
        'txtCambio
        '
        Me.txtCambio.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambio.Location = New System.Drawing.Point(71, 136)
        Me.txtCambio.Multiline = True
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.ReadOnly = True
        Me.txtCambio.Size = New System.Drawing.Size(132, 32)
        Me.txtCambio.TabIndex = 4
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Cambio:"
        '
        'lblUsar
        '
        Me.lblUsar.AutoSize = True
        Me.lblUsar.BackColor = System.Drawing.Color.Transparent
        Me.lblUsar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsar.Location = New System.Drawing.Point(18, 88)
        Me.lblUsar.Name = "lblUsar"
        Me.lblUsar.Size = New System.Drawing.Size(52, 16)
        Me.lblUsar.TabIndex = 22
        Me.lblUsar.Text = "A Usar:"
        Me.lblUsar.Visible = False
        '
        'txtUsar
        '
        Me.txtUsar.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsar.Location = New System.Drawing.Point(71, 80)
        Me.txtUsar.Multiline = True
        Me.txtUsar.Name = "txtUsar"
        Me.txtUsar.Size = New System.Drawing.Size(132, 32)
        Me.txtUsar.TabIndex = 3
        Me.txtUsar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUsar.Visible = False
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(823, 9)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(28, 20)
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
        Me.btnClose.Location = New System.Drawing.Point(919, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(28, 20)
        Me.btnClose.TabIndex = 23
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtEfectivo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtUsar)
        Me.GroupBox1.Controls.Add(Me.lblUsar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCambio)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 100)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 202)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pago Efectivo"
        '
        'txtnumoperacion
        '
        Me.txtnumoperacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumoperacion.Location = New System.Drawing.Point(107, 24)
        Me.txtnumoperacion.Multiline = True
        Me.txtnumoperacion.Name = "txtnumoperacion"
        Me.txtnumoperacion.Size = New System.Drawing.Size(109, 22)
        Me.txtnumoperacion.TabIndex = 23
        Me.txtnumoperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "No. Operación:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Monto:"
        '
        'txtmontotarjeta
        '
        Me.txtmontotarjeta.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmontotarjeta.Location = New System.Drawing.Point(107, 61)
        Me.txtmontotarjeta.Multiline = True
        Me.txtmontotarjeta.Name = "txtmontotarjeta"
        Me.txtmontotarjeta.Size = New System.Drawing.Size(109, 22)
        Me.txtmontotarjeta.TabIndex = 25
        Me.txtmontotarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvtarjeta
        '
        Me.dgvtarjeta.AllowUserToAddRows = False
        Me.dgvtarjeta.AllowUserToDeleteRows = False
        Me.dgvtarjeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtarjeta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numoperacion, Me.monto})
        Me.dgvtarjeta.Location = New System.Drawing.Point(6, 96)
        Me.dgvtarjeta.Name = "dgvtarjeta"
        Me.dgvtarjeta.ReadOnly = True
        Me.dgvtarjeta.Size = New System.Drawing.Size(319, 100)
        Me.dgvtarjeta.TabIndex = 26
        '
        'numoperacion
        '
        Me.numoperacion.HeaderText = "No. de Operación"
        Me.numoperacion.Name = "numoperacion"
        Me.numoperacion.ReadOnly = True
        Me.numoperacion.Width = 155
        '
        'monto
        '
        Me.monto.HeaderText = "Monto"
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        Me.monto.Width = 120
        '
        'btnagregartarjeta
        '
        Me.btnagregartarjeta.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnagregartarjeta.Image = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnagregartarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregartarjeta.Location = New System.Drawing.Point(223, 34)
        Me.btnagregartarjeta.Name = "btnagregartarjeta"
        Me.btnagregartarjeta.Size = New System.Drawing.Size(102, 37)
        Me.btnagregartarjeta.TabIndex = 27
        Me.btnagregartarjeta.Text = "&Agregar"
        Me.btnagregartarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregartarjeta.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgvtarjeta)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnagregartarjeta)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtnumoperacion)
        Me.GroupBox2.Controls.Add(Me.txtmontotarjeta)
        Me.GroupBox2.Location = New System.Drawing.Point(254, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(331, 202)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pago Tarjeta"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btnagregarmontovale)
        Me.GroupBox3.Controls.Add(Me.dgvVales)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtmontousarvale)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtmontovale)
        Me.GroupBox3.Controls.Add(Me.btnobtenervale)
        Me.GroupBox3.Controls.Add(Me.txtfoliovale)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(591, 100)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(358, 202)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pago Vale"
        '
        'btnagregarmontovale
        '
        Me.btnagregarmontovale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnagregarmontovale.Image = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnagregarmontovale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregarmontovale.Location = New System.Drawing.Point(247, 74)
        Me.btnagregarmontovale.Name = "btnagregarmontovale"
        Me.btnagregarmontovale.Size = New System.Drawing.Size(104, 37)
        Me.btnagregarmontovale.TabIndex = 34
        Me.btnagregarmontovale.Text = "&Agregar"
        Me.btnagregarmontovale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregarmontovale.UseVisualStyleBackColor = True
        '
        'dgvVales
        '
        Me.dgvVales.AllowUserToAddRows = False
        Me.dgvVales.AllowUserToDeleteRows = False
        Me.dgvVales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.folio, Me.montousar, Me.montorestante})
        Me.dgvVales.Location = New System.Drawing.Point(6, 119)
        Me.dgvVales.Name = "dgvVales"
        Me.dgvVales.ReadOnly = True
        Me.dgvVales.Size = New System.Drawing.Size(346, 77)
        Me.dgvVales.TabIndex = 33
        '
        'folio
        '
        Me.folio.HeaderText = "Folio Vale"
        Me.folio.Name = "folio"
        Me.folio.ReadOnly = True
        Me.folio.Width = 80
        '
        'montousar
        '
        Me.montousar.HeaderText = "Monto a usar"
        Me.montousar.Name = "montousar"
        Me.montousar.ReadOnly = True
        '
        'montorestante
        '
        Me.montorestante.HeaderText = "Monto Restante"
        Me.montorestante.Name = "montorestante"
        Me.montorestante.ReadOnly = True
        Me.montorestante.Width = 122
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 16)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Resto de vale:"
        '
        'txtmontousarvale
        '
        Me.txtmontousarvale.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtmontousarvale.Location = New System.Drawing.Point(107, 83)
        Me.txtmontousarvale.Multiline = True
        Me.txtmontousarvale.Name = "txtmontousarvale"
        Me.txtmontousarvale.Size = New System.Drawing.Size(134, 22)
        Me.txtmontousarvale.TabIndex = 31
        Me.txtmontousarvale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Monto a usar:"
        '
        'txtmontovale
        '
        Me.txtmontovale.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtmontovale.Location = New System.Drawing.Point(107, 49)
        Me.txtmontovale.Multiline = True
        Me.txtmontovale.Name = "txtmontovale"
        Me.txtmontovale.ReadOnly = True
        Me.txtmontovale.Size = New System.Drawing.Size(134, 22)
        Me.txtmontovale.TabIndex = 29
        Me.txtmontovale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnobtenervale
        '
        Me.btnobtenervale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnobtenervale.Image = Global.Papeleria.My.Resources.Resources.money
        Me.btnobtenervale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnobtenervale.Location = New System.Drawing.Point(247, 14)
        Me.btnobtenervale.Name = "btnobtenervale"
        Me.btnobtenervale.Size = New System.Drawing.Size(104, 37)
        Me.btnobtenervale.TabIndex = 28
        Me.btnobtenervale.Text = "&Obtener"
        Me.btnobtenervale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnobtenervale.UseVisualStyleBackColor = True
        '
        'txtfoliovale
        '
        Me.txtfoliovale.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtfoliovale.Location = New System.Drawing.Point(107, 23)
        Me.txtfoliovale.Multiline = True
        Me.txtfoliovale.Name = "txtfoliovale"
        Me.txtfoliovale.Size = New System.Drawing.Size(134, 22)
        Me.txtfoliovale.TabIndex = 24
        Me.txtfoliovale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Folio vale:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(25, 329)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 19)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Pago Realizado"
        '
        'txtrestopago
        '
        Me.txtrestopago.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrestopago.Location = New System.Drawing.Point(448, 321)
        Me.txtrestopago.Multiline = True
        Me.txtrestopago.Name = "txtrestopago"
        Me.txtrestopago.ReadOnly = True
        Me.txtrestopago.Size = New System.Drawing.Size(133, 32)
        Me.txtrestopago.TabIndex = 33
        Me.txtrestopago.Text = "$0.00"
        Me.txtrestopago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(319, 329)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 19)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Resto de Pago"
        '
        'txtpagorealizado
        '
        Me.txtpagorealizado.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpagorealizado.Location = New System.Drawing.Point(159, 321)
        Me.txtpagorealizado.Multiline = True
        Me.txtpagorealizado.Name = "txtpagorealizado"
        Me.txtpagorealizado.ReadOnly = True
        Me.txtpagorealizado.Size = New System.Drawing.Size(133, 32)
        Me.txtpagorealizado.TabIndex = 34
        Me.txtpagorealizado.Text = "$0.00"
        Me.txtpagorealizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnfinalizar
        '
        Me.btnfinalizar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnfinalizar.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnfinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnfinalizar.Location = New System.Drawing.Point(845, 316)
        Me.btnfinalizar.Name = "btnfinalizar"
        Me.btnfinalizar.Size = New System.Drawing.Size(104, 37)
        Me.btnfinalizar.TabIndex = 35
        Me.btnfinalizar.Text = "&Finalizar"
        Me.btnfinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnfinalizar.UseVisualStyleBackColor = True
        '
        'frmCambio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(980, 372)
        Me.Controls.Add(Me.btnfinalizar)
        Me.Controls.Add(Me.txtpagorealizado)
        Me.Controls.Add(Me.txtrestopago)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.Label5)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCambio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvtarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvVales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEfectivo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUsar As System.Windows.Forms.Label
    Friend WithEvents txtUsar As System.Windows.Forms.TextBox
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnumoperacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtmontotarjeta As System.Windows.Forms.TextBox
    Friend WithEvents dgvtarjeta As System.Windows.Forms.DataGridView
    Friend WithEvents btnagregartarjeta As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtmontousarvale As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtmontovale As System.Windows.Forms.TextBox
    Friend WithEvents btnobtenervale As System.Windows.Forms.Button
    Friend WithEvents txtfoliovale As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvVales As System.Windows.Forms.DataGridView
    Friend WithEvents btnagregarmontovale As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtrestopago As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtpagorealizado As System.Windows.Forms.TextBox
    Friend WithEvents folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents montousar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents montorestante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numoperacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnfinalizar As System.Windows.Forms.Button
End Class
