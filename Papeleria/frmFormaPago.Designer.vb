<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormaPago
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LBRestoPago = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnfinalizar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvVales = New System.Windows.Forms.DataGridView
        Me.folio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.montousar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.montorestante = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnagregarmontovale = New System.Windows.Forms.Button
        Me.btnobtenervale = New System.Windows.Forms.Button
        Me.txtmontousarvale = New System.Windows.Forms.TextBox
        Me.txtmontovale = New System.Windows.Forms.TextBox
        Me.txtfoliovale = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvtarjeta = New System.Windows.Forms.DataGridView
        Me.numoperacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnagregartarjeta = New System.Windows.Forms.Button
        Me.txtmontotarjeta = New System.Windows.Forms.TextBox
        Me.txtnumoperacion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnHide = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtCambio = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUsar = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEfectivo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSubtotal = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvVales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvtarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(798, 6)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(25, 18)
        Me.btnMin.TabIndex = 19
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
        Me.btnClose.Location = New System.Drawing.Point(890, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 18)
        Me.btnClose.TabIndex = 20
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LBRestoPago)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.btnfinalizar)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(228, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 300)
        Me.Panel1.TabIndex = 123
        '
        'LBRestoPago
        '
        Me.LBRestoPago.BackColor = System.Drawing.Color.White
        Me.LBRestoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LBRestoPago.Font = New System.Drawing.Font("Arial", 19.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBRestoPago.ForeColor = System.Drawing.Color.Black
        Me.LBRestoPago.Location = New System.Drawing.Point(560, 28)
        Me.LBRestoPago.Name = "LBRestoPago"
        Me.LBRestoPago.Size = New System.Drawing.Size(136, 31)
        Me.LBRestoPago.TabIndex = 128
        Me.LBRestoPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(440, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 23)
        Me.Label11.TabIndex = 129
        Me.Label11.Text = "Resto Pago"
        '
        'btnfinalizar
        '
        Me.btnfinalizar.BackgroundImage = Global.Papeleria.My.Resources.Resources.guardar1
        Me.btnfinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnfinalizar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfinalizar.Location = New System.Drawing.Point(3, 24)
        Me.btnfinalizar.Name = "btnfinalizar"
        Me.btnfinalizar.Size = New System.Drawing.Size(140, 39)
        Me.btnfinalizar.TabIndex = 125
        Me.btnfinalizar.TabStop = False
        Me.btnfinalizar.Text = "&Finalizar Pago"
        Me.btnfinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnfinalizar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dgvVales)
        Me.GroupBox3.Controls.Add(Me.btnagregarmontovale)
        Me.GroupBox3.Controls.Add(Me.btnobtenervale)
        Me.GroupBox3.Controls.Add(Me.txtmontousarvale)
        Me.GroupBox3.Controls.Add(Me.txtmontovale)
        Me.GroupBox3.Controls.Add(Me.txtfoliovale)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(340, 80)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(358, 202)
        Me.GroupBox3.TabIndex = 127
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pago Vale"
        '
        'dgvVales
        '
        Me.dgvVales.AllowUserToAddRows = False
        Me.dgvVales.AllowUserToDeleteRows = False
        Me.dgvVales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.folio, Me.montousar, Me.montorestante})
        Me.dgvVales.Location = New System.Drawing.Point(6, 118)
        Me.dgvVales.Name = "dgvVales"
        Me.dgvVales.ReadOnly = True
        Me.dgvVales.Size = New System.Drawing.Size(346, 77)
        Me.dgvVales.TabIndex = 15
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
        'btnagregarmontovale
        '
        Me.btnagregarmontovale.BackgroundImage = Global.Papeleria.My.Resources.Resources.agregar5
        Me.btnagregarmontovale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnagregarmontovale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnagregarmontovale.Location = New System.Drawing.Point(242, 73)
        Me.btnagregarmontovale.Name = "btnagregarmontovale"
        Me.btnagregarmontovale.Size = New System.Drawing.Size(103, 39)
        Me.btnagregarmontovale.TabIndex = 11
        Me.btnagregarmontovale.Text = "&Agregar"
        Me.btnagregarmontovale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregarmontovale.UseVisualStyleBackColor = True
        '
        'btnobtenervale
        '
        Me.btnobtenervale.BackgroundImage = Global.Papeleria.My.Resources.Resources.money
        Me.btnobtenervale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnobtenervale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnobtenervale.Location = New System.Drawing.Point(242, 27)
        Me.btnobtenervale.Name = "btnobtenervale"
        Me.btnobtenervale.Size = New System.Drawing.Size(104, 37)
        Me.btnobtenervale.TabIndex = 8
        Me.btnobtenervale.Text = "&Obtener"
        Me.btnobtenervale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnobtenervale.UseVisualStyleBackColor = True
        '
        'txtmontousarvale
        '
        Me.txtmontousarvale.BackColor = System.Drawing.Color.White
        Me.txtmontousarvale.Location = New System.Drawing.Point(102, 81)
        Me.txtmontousarvale.Multiline = True
        Me.txtmontousarvale.Name = "txtmontousarvale"
        Me.txtmontousarvale.Size = New System.Drawing.Size(134, 22)
        Me.txtmontousarvale.TabIndex = 10
        Me.txtmontousarvale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtmontovale
        '
        Me.txtmontovale.BackColor = System.Drawing.Color.White
        Me.txtmontovale.Location = New System.Drawing.Point(102, 46)
        Me.txtmontovale.Multiline = True
        Me.txtmontovale.Name = "txtmontovale"
        Me.txtmontovale.ReadOnly = True
        Me.txtmontovale.Size = New System.Drawing.Size(134, 22)
        Me.txtmontovale.TabIndex = 9
        Me.txtmontovale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtfoliovale
        '
        Me.txtfoliovale.Location = New System.Drawing.Point(102, 21)
        Me.txtfoliovale.Multiline = True
        Me.txtfoliovale.Name = "txtfoliovale"
        Me.txtfoliovale.Size = New System.Drawing.Size(134, 22)
        Me.txtfoliovale.TabIndex = 7
        Me.txtfoliovale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 16)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Resto de vale"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 16)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Monto a usar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(34, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 16)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Folio vale"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgvtarjeta)
        Me.GroupBox2.Controls.Add(Me.btnagregartarjeta)
        Me.GroupBox2.Controls.Add(Me.txtmontotarjeta)
        Me.GroupBox2.Controls.Add(Me.txtnumoperacion)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(331, 202)
        Me.GroupBox2.TabIndex = 126
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pago Tarjeta"
        '
        'dgvtarjeta
        '
        Me.dgvtarjeta.AllowUserToAddRows = False
        Me.dgvtarjeta.AllowUserToDeleteRows = False
        Me.dgvtarjeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtarjeta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numoperacion, Me.monto})
        Me.dgvtarjeta.Location = New System.Drawing.Point(6, 91)
        Me.dgvtarjeta.Name = "dgvtarjeta"
        Me.dgvtarjeta.ReadOnly = True
        Me.dgvtarjeta.Size = New System.Drawing.Size(319, 105)
        Me.dgvtarjeta.TabIndex = 14
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
        Me.btnagregartarjeta.BackgroundImage = Global.Papeleria.My.Resources.Resources.agregar5
        Me.btnagregartarjeta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnagregartarjeta.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnagregartarjeta.Location = New System.Drawing.Point(222, 33)
        Me.btnagregartarjeta.Name = "btnagregartarjeta"
        Me.btnagregartarjeta.Size = New System.Drawing.Size(103, 39)
        Me.btnagregartarjeta.TabIndex = 6
        Me.btnagregartarjeta.Text = "&Agregar"
        Me.btnagregartarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregartarjeta.UseVisualStyleBackColor = True
        '
        'txtmontotarjeta
        '
        Me.txtmontotarjeta.Location = New System.Drawing.Point(107, 61)
        Me.txtmontotarjeta.Multiline = True
        Me.txtmontotarjeta.Name = "txtmontotarjeta"
        Me.txtmontotarjeta.Size = New System.Drawing.Size(109, 22)
        Me.txtmontotarjeta.TabIndex = 5
        Me.txtmontotarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtnumoperacion
        '
        Me.txtnumoperacion.Location = New System.Drawing.Point(107, 23)
        Me.txtnumoperacion.Multiline = True
        Me.txtnumoperacion.Name = "txtnumoperacion"
        Me.txtnumoperacion.Size = New System.Drawing.Size(109, 22)
        Me.txtnumoperacion.TabIndex = 4
        Me.txtnumoperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Monto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "No. Operación"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btnHide)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtSubtotal)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(12, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(210, 300)
        Me.Panel2.TabIndex = 124
        '
        'btnHide
        '
        Me.btnHide.Location = New System.Drawing.Point(182, 60)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(23, 23)
        Me.btnHide.TabIndex = 128
        Me.btnHide.Text = "+"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtCambio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtUsar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtEfectivo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 202)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pago Efectivo"
        '
        'txtCambio
        '
        Me.txtCambio.BackColor = System.Drawing.Color.White
        Me.txtCambio.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambio.Location = New System.Drawing.Point(64, 152)
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.ReadOnly = True
        Me.txtCambio.Size = New System.Drawing.Size(127, 32)
        Me.txtCambio.TabIndex = 203
        Me.txtCambio.Text = "0.00"
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Cambio"
        '
        'txtUsar
        '
        Me.txtUsar.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsar.Location = New System.Drawing.Point(64, 91)
        Me.txtUsar.Name = "txtUsar"
        Me.txtUsar.Size = New System.Drawing.Size(127, 32)
        Me.txtUsar.TabIndex = 201
        Me.txtUsar.Text = "0.00"
        Me.txtUsar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "A Usar"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(64, 28)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(127, 32)
        Me.txtEfectivo.TabIndex = 200
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 16)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "Efectivo"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.BackColor = System.Drawing.Color.White
        Me.txtSubtotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtSubtotal.Font = New System.Drawing.Font("Arial", 19.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubtotal.Location = New System.Drawing.Point(69, 27)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(136, 31)
        Me.txtSubtotal.TabIndex = 125
        Me.txtSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 23)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Total"
        '
        'frmFormaPago
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(947, 332)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFormaPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmFormaPago"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvVales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvtarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LBRestoPago As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnfinalizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVales As System.Windows.Forms.DataGridView
    Friend WithEvents folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents montousar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents montorestante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnagregarmontovale As System.Windows.Forms.Button
    Friend WithEvents btnobtenervale As System.Windows.Forms.Button
    Friend WithEvents txtmontousarvale As System.Windows.Forms.TextBox
    Friend WithEvents txtmontovale As System.Windows.Forms.TextBox
    Friend WithEvents txtfoliovale As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvtarjeta As System.Windows.Forms.DataGridView
    Friend WithEvents numoperacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnagregartarjeta As System.Windows.Forms.Button
    Friend WithEvents txtmontotarjeta As System.Windows.Forms.TextBox
    Friend WithEvents txtnumoperacion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnHide As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEfectivo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSubtotal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
