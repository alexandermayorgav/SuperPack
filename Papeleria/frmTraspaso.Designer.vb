<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraspaso
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblSobrantes = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPiezasPaquete = New System.Windows.Forms.Label
        Me.lblCajaPiezas = New System.Windows.Forms.Label
        Me.btnPaqRel = New System.Windows.Forms.Button
        Me.btnCaja = New System.Windows.Forms.Button
        Me.txtBoxOpen = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCaja = New System.Windows.Forms.Label
        Me.lblPaquete = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNumPaq = New System.Windows.Forms.TextBox
        Me.btnPaq = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.dgvitems = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.lblSobrantes)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnPaqRel)
        Me.GroupBox1.Controls.Add(Me.btnCaja)
        Me.GroupBox1.Controls.Add(Me.txtBoxOpen)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNumPaq)
        Me.GroupBox1.Controls.Add(Me.btnPaq)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(656, 180)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'lblSobrantes
        '
        Me.lblSobrantes.AutoSize = True
        Me.lblSobrantes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSobrantes.Location = New System.Drawing.Point(594, 99)
        Me.lblSobrantes.Name = "lblSobrantes"
        Me.lblSobrantes.Size = New System.Drawing.Size(15, 16)
        Me.lblSobrantes.TabIndex = 15
        Me.lblSobrantes.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(521, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Sobrantes"
        '
        'lblPiezasPaquete
        '
        Me.lblPiezasPaquete.AutoSize = True
        Me.lblPiezasPaquete.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiezasPaquete.Location = New System.Drawing.Point(3, 104)
        Me.lblPiezasPaquete.Name = "lblPiezasPaquete"
        Me.lblPiezasPaquete.Size = New System.Drawing.Size(56, 18)
        Me.lblPiezasPaquete.TabIndex = 13
        Me.lblPiezasPaquete.Text = "Label5"
        '
        'lblCajaPiezas
        '
        Me.lblCajaPiezas.AutoSize = True
        Me.lblCajaPiezas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajaPiezas.Location = New System.Drawing.Point(3, 28)
        Me.lblCajaPiezas.Name = "lblCajaPiezas"
        Me.lblCajaPiezas.Size = New System.Drawing.Size(56, 18)
        Me.lblCajaPiezas.TabIndex = 12
        Me.lblCajaPiezas.Text = "Label5"
        '
        'btnPaqRel
        '
        Me.btnPaqRel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaqRel.Image = Global.Papeleria.My.Resources.Resources.buscar1
        Me.btnPaqRel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPaqRel.Location = New System.Drawing.Point(6, 94)
        Me.btnPaqRel.Name = "btnPaqRel"
        Me.btnPaqRel.Size = New System.Drawing.Size(125, 40)
        Me.btnPaqRel.TabIndex = 2
        Me.btnPaqRel.Text = "Paquetes Relacionados"
        Me.btnPaqRel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPaqRel.UseVisualStyleBackColor = True
        '
        'btnCaja
        '
        Me.btnCaja.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnCaja.Image = Global.Papeleria.My.Resources.Resources.buscar1
        Me.btnCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCaja.Location = New System.Drawing.Point(6, 15)
        Me.btnCaja.Name = "btnCaja"
        Me.btnCaja.Size = New System.Drawing.Size(125, 36)
        Me.btnCaja.TabIndex = 0
        Me.btnCaja.Text = "Caja"
        Me.btnCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCaja.UseVisualStyleBackColor = True
        '
        'txtBoxOpen
        '
        Me.txtBoxOpen.Location = New System.Drawing.Point(521, 26)
        Me.txtBoxOpen.MaxLength = 6
        Me.txtBoxOpen.Name = "txtBoxOpen"
        Me.txtBoxOpen.Size = New System.Drawing.Size(100, 20)
        Me.txtBoxOpen.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(517, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cajas Abiertas"
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.Location = New System.Drawing.Point(3, 8)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(56, 18)
        Me.lblCaja.TabIndex = 7
        Me.lblCaja.Text = "Label5"
        '
        'lblPaquete
        '
        Me.lblPaquete.AutoSize = True
        Me.lblPaquete.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaquete.Location = New System.Drawing.Point(3, 82)
        Me.lblPaquete.Name = "lblPaquete"
        Me.lblPaquete.Size = New System.Drawing.Size(56, 18)
        Me.lblPaquete.TabIndex = 6
        Me.lblPaquete.Text = "Label4"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnAdd.Image = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(521, 132)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 36)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Agregar"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(518, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Paquetes Realizados"
        '
        'txtNumPaq
        '
        Me.txtNumPaq.Location = New System.Drawing.Point(521, 71)
        Me.txtNumPaq.MaxLength = 6
        Me.txtNumPaq.Name = "txtNumPaq"
        Me.txtNumPaq.Size = New System.Drawing.Size(100, 20)
        Me.txtNumPaq.TabIndex = 3
        '
        'btnPaq
        '
        Me.btnPaq.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnPaq.Image = Global.Papeleria.My.Resources.Resources.buscar1
        Me.btnPaq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPaq.Location = New System.Drawing.Point(6, 138)
        Me.btnPaq.Name = "btnPaq"
        Me.btnPaq.Size = New System.Drawing.Size(125, 36)
        Me.btnPaq.TabIndex = 1
        Me.btnPaq.Text = "Paquetes"
        Me.btnPaq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPaq.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnSave.Image = Global.Papeleria.My.Resources.Resources.save13
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(580, 396)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 40)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnNew.Image = Global.Papeleria.My.Resources.Resources.nuevo2
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(489, 396)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(80, 40)
        Me.btnNew.TabIndex = 9
        Me.btnNew.Text = "Nuevo"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(590, 8)
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
        Me.btnClose.Location = New System.Drawing.Point(650, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 23
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvitems.Location = New System.Drawing.Point(19, 237)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.ReadOnly = True
        Me.dgvitems.Size = New System.Drawing.Size(656, 150)
        Me.dgvitems.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblCaja)
        Me.Panel1.Controls.Add(Me.lblPaquete)
        Me.Panel1.Controls.Add(Me.lblCajaPiezas)
        Me.Panel1.Controls.Add(Me.lblPiezasPaquete)
        Me.Panel1.Location = New System.Drawing.Point(137, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(374, 139)
        Me.Panel1.TabIndex = 16
        '
        'frmTraspaso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(698, 456)
        Me.Controls.Add(Me.dgvitems)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmTraspaso"
        Me.Text = "frmTraspaso"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumPaq As System.Windows.Forms.TextBox
    Friend WithEvents btnPaq As System.Windows.Forms.Button
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents lblPaquete As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents txtBoxOpen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCaja As System.Windows.Forms.Button
    Friend WithEvents lblPiezasPaquete As System.Windows.Forms.Label
    Friend WithEvents lblCajaPiezas As System.Windows.Forms.Label
    Friend WithEvents btnPaqRel As System.Windows.Forms.Button
    Friend WithEvents lblSobrantes As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvitems As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
