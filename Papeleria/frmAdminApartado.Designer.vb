<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminApartado
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFolioAp = New System.Windows.Forms.TextBox
        Me.btnObtenerAp = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtFechaEnt = New System.Windows.Forms.TextBox
        Me.lblFechaE = New System.Windows.Forms.Label
        Me.txtFechaAp = New System.Windows.Forms.TextBox
        Me.status = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtMonto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCant = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblDias = New System.Windows.Forms.Label
        Me.pbxSemaforo = New System.Windows.Forms.PictureBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnAdmAb = New System.Windows.Forms.Button
        Me.btnEntregarAp = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblSaldo = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnMin = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pbxSemaforo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(24, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio apartado:"
        '
        'txtFolioAp
        '
        Me.txtFolioAp.Location = New System.Drawing.Point(122, 65)
        Me.txtFolioAp.Name = "txtFolioAp"
        Me.txtFolioAp.Size = New System.Drawing.Size(100, 22)
        Me.txtFolioAp.TabIndex = 1
        '
        'btnObtenerAp
        '
        Me.btnObtenerAp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnObtenerAp.Image = Global.Papeleria.My.Resources.Resources.reload
        Me.btnObtenerAp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnObtenerAp.Location = New System.Drawing.Point(228, 58)
        Me.btnObtenerAp.Name = "btnObtenerAp"
        Me.btnObtenerAp.Size = New System.Drawing.Size(100, 36)
        Me.btnObtenerAp.TabIndex = 2
        Me.btnObtenerAp.Text = "&Obtener"
        Me.btnObtenerAp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtenerAp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtCliente.Location = New System.Drawing.Point(111, 26)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(270, 22)
        Me.txtCliente.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtFechaEnt)
        Me.GroupBox1.Controls.Add(Me.lblFechaE)
        Me.GroupBox1.Controls.Add(Me.txtFechaAp)
        Me.GroupBox1.Controls.Add(Me.status)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCant)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 111)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 316)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del apartado"
        '
        'txtFechaEnt
        '
        Me.txtFechaEnt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFechaEnt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaEnt.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtFechaEnt.Location = New System.Drawing.Point(111, 283)
        Me.txtFechaEnt.Name = "txtFechaEnt"
        Me.txtFechaEnt.ReadOnly = True
        Me.txtFechaEnt.Size = New System.Drawing.Size(190, 22)
        Me.txtFechaEnt.TabIndex = 18
        Me.txtFechaEnt.TabStop = False
        Me.txtFechaEnt.Visible = False
        '
        'lblFechaE
        '
        Me.lblFechaE.AutoSize = True
        Me.lblFechaE.Location = New System.Drawing.Point(10, 286)
        Me.lblFechaE.Name = "lblFechaE"
        Me.lblFechaE.Size = New System.Drawing.Size(97, 16)
        Me.lblFechaE.TabIndex = 17
        Me.lblFechaE.Text = "Fecha Entrega:"
        Me.lblFechaE.Visible = False
        '
        'txtFechaAp
        '
        Me.txtFechaAp.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFechaAp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaAp.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtFechaAp.Location = New System.Drawing.Point(111, 249)
        Me.txtFechaAp.Name = "txtFechaAp"
        Me.txtFechaAp.ReadOnly = True
        Me.txtFechaAp.Size = New System.Drawing.Size(190, 22)
        Me.txtFechaAp.TabIndex = 16
        Me.txtFechaAp.TabStop = False
        '
        'status
        '
        Me.status.FlatAppearance.BorderSize = 0
        Me.status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.status.Location = New System.Drawing.Point(113, 196)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(121, 36)
        Me.status.TabIndex = 15
        Me.status.Text = "Entregado"
        Me.status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.status.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(57, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Status:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Fecha Apartado:"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtMonto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtMonto.Location = New System.Drawing.Point(111, 165)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(100, 22)
        Me.txtMonto.TabIndex = 12
        Me.txtMonto.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(59, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Monto:"
        '
        'txtCant
        '
        Me.txtCant.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCant.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtCant.Location = New System.Drawing.Point(111, 131)
        Me.txtCant.Name = "txtCant"
        Me.txtCant.ReadOnly = True
        Me.txtCant.Size = New System.Drawing.Size(100, 22)
        Me.txtCant.TabIndex = 10
        Me.txtCant.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Cantidad:"
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProducto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtProducto.Location = New System.Drawing.Point(111, 95)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(270, 22)
        Me.txtProducto.TabIndex = 8
        Me.txtProducto.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Producto:"
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtUsuario.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtUsuario.Location = New System.Drawing.Point(111, 60)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(270, 22)
        Me.txtUsuario.TabIndex = 6
        Me.txtUsuario.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Atendió:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblDias)
        Me.GroupBox2.Controls.Add(Me.pbxSemaforo)
        Me.GroupBox2.Location = New System.Drawing.Point(496, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 153)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Días Restantes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(34, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 24)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Quedan:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDias.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDias.Location = New System.Drawing.Point(171, 92)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(0, 32)
        Me.lblDias.TabIndex = 1
        Me.lblDias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbxSemaforo
        '
        Me.pbxSemaforo.Location = New System.Drawing.Point(66, 26)
        Me.pbxSemaforo.Name = "pbxSemaforo"
        Me.pbxSemaforo.Size = New System.Drawing.Size(150, 50)
        Me.pbxSemaforo.TabIndex = 0
        Me.pbxSemaforo.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btnAdmAb)
        Me.GroupBox3.Controls.Add(Me.btnEntregarAp)
        Me.GroupBox3.Controls.Add(Me.btnCancelar)
        Me.GroupBox3.Location = New System.Drawing.Point(496, 274)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(272, 153)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Acciones"
        '
        'btnAdmAb
        '
        Me.btnAdmAb.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdmAb.Image = Global.Papeleria.My.Resources.Resources.calcs
        Me.btnAdmAb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdmAb.Location = New System.Drawing.Point(48, 107)
        Me.btnAdmAb.Name = "btnAdmAb"
        Me.btnAdmAb.Size = New System.Drawing.Size(179, 36)
        Me.btnAdmAb.TabIndex = 2
        Me.btnAdmAb.Text = "&Administrar Abonos"
        Me.btnAdmAb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdmAb.UseVisualStyleBackColor = True
        '
        'btnEntregarAp
        '
        Me.btnEntregarAp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEntregarAp.Image = Global.Papeleria.My.Resources.Resources.save1
        Me.btnEntregarAp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEntregarAp.Location = New System.Drawing.Point(48, 66)
        Me.btnEntregarAp.Name = "btnEntregarAp"
        Me.btnEntregarAp.Size = New System.Drawing.Size(179, 36)
        Me.btnEntregarAp.TabIndex = 1
        Me.btnEntregarAp.Text = "&Entregar Apartado"
        Me.btnEntregarAp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEntregarAp.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(48, 27)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(179, 36)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "&Cancelar Apartado"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.Papeleria.My.Resources.Resources.find
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(391, 58)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(94, 36)
        Me.btnBuscar.TabIndex = 9
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(497, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Saldo:"
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSaldo.Location = New System.Drawing.Point(562, 65)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(0, 24)
        Me.lblSaldo.TabIndex = 3
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImage = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(750, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(28, 28)
        Me.btnClose.TabIndex = 11
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
        Me.btnMin.Location = New System.Drawing.Point(667, 9)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(28, 28)
        Me.btnMin.TabIndex = 12
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'frmAdminApartado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(795, 450)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnObtenerAp)
        Me.Controls.Add(Me.txtFolioAp)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmAdminApartado"
        Me.Text = "Administración de apartados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pbxSemaforo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFolioAp As System.Windows.Forms.TextBox
    Friend WithEvents btnObtenerAp As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCant As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.Button
    Friend WithEvents txtFechaAp As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaEnt As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaE As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pbxSemaforo As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDias As System.Windows.Forms.Label
    Friend WithEvents btnAdmAb As System.Windows.Forms.Button
    Friend WithEvents btnEntregarAp As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
End Class
