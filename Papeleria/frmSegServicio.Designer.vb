<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSegServicio
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSXC = New System.Windows.Forms.Button
        Me.btnObtener = New System.Windows.Forms.Button
        Me.txtFolioS = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.gp1 = New System.Windows.Forms.GroupBox
        Me.btnBuscarC = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnObtenerC = New System.Windows.Forms.Button
        Me.txtFolioC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvServ = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvRefs = New System.Windows.Forms.DataGridView
        Me.cmsserv = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ESPERAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.COMPLETOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NOSEAPLICOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsrefs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IMPLEMENTADA = New System.Windows.Forms.ToolStripMenuItem
        Me.NOIMPLEMENTADA = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCompleto = New System.Windows.Forms.Button
        Me.lblservcomp = New System.Windows.Forms.Label
        Me.lblFactura = New System.Windows.Forms.Label
        Me.btnProcV = New System.Windows.Forms.Button
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.gp1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvServ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvRefs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsserv.SuspendLayout()
        Me.cmsrefs.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnSXC)
        Me.GroupBox2.Controls.Add(Me.btnObtener)
        Me.GroupBox2.Controls.Add(Me.txtFolioS)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Location = New System.Drawing.Point(615, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(176, 118)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar Servicio"
        '
        'btnSXC
        '
        Me.btnSXC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSXC.Image = Global.Papeleria.My.Resources.Resources._16__Binoculars_2_
        Me.btnSXC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSXC.Location = New System.Drawing.Point(9, 89)
        Me.btnSXC.Name = "btnSXC"
        Me.btnSXC.Size = New System.Drawing.Size(149, 23)
        Me.btnSXC.TabIndex = 6
        Me.btnSXC.Text = "Buscar &por Cliente"
        Me.btnSXC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSXC.UseVisualStyleBackColor = True
        '
        'btnObtener
        '
        Me.btnObtener.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnObtener.Image = Global.Papeleria.My.Resources.Resources.Corvette_256__1_
        Me.btnObtener.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnObtener.Location = New System.Drawing.Point(58, 48)
        Me.btnObtener.Name = "btnObtener"
        Me.btnObtener.Size = New System.Drawing.Size(100, 36)
        Me.btnObtener.TabIndex = 5
        Me.btnObtener.Text = "Ob&tener"
        Me.btnObtener.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtener.UseVisualStyleBackColor = True
        '
        'txtFolioS
        '
        Me.txtFolioS.Location = New System.Drawing.Point(58, 21)
        Me.txtFolioS.Name = "txtFolioS"
        Me.txtFolioS.Size = New System.Drawing.Size(100, 22)
        Me.txtFolioS.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 16)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Folio:"
        '
        'gp1
        '
        Me.gp1.BackColor = System.Drawing.Color.Transparent
        Me.gp1.Controls.Add(Me.btnBuscarC)
        Me.gp1.Controls.Add(Me.txtCliente)
        Me.gp1.Controls.Add(Me.Label2)
        Me.gp1.Controls.Add(Me.btnObtenerC)
        Me.gp1.Controls.Add(Me.txtFolioC)
        Me.gp1.Controls.Add(Me.Label1)
        Me.gp1.Location = New System.Drawing.Point(16, 60)
        Me.gp1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gp1.Name = "gp1"
        Me.gp1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gp1.Size = New System.Drawing.Size(590, 118)
        Me.gp1.TabIndex = 22
        Me.gp1.TabStop = False
        Me.gp1.Text = "Datos Cliente"
        '
        'btnBuscarC
        '
        Me.btnBuscarC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarC.Image = Global.Papeleria.My.Resources.Resources.find
        Me.btnBuscarC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarC.Location = New System.Drawing.Point(416, 59)
        Me.btnBuscarC.Name = "btnBuscarC"
        Me.btnBuscarC.Size = New System.Drawing.Size(142, 36)
        Me.btnBuscarC.TabIndex = 3
        Me.btnBuscarC.Text = "&Buscar cliente"
        Me.btnBuscarC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarC.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtCliente.Location = New System.Drawing.Point(124, 66)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(277, 22)
        Me.txtCliente.TabIndex = 5
        Me.txtCliente.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cliente:"
        '
        'btnObtenerC
        '
        Me.btnObtenerC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnObtenerC.Image = Global.Papeleria.My.Resources.Resources.clientes
        Me.btnObtenerC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnObtenerC.Location = New System.Drawing.Point(241, 20)
        Me.btnObtenerC.Name = "btnObtenerC"
        Me.btnObtenerC.Size = New System.Drawing.Size(100, 36)
        Me.btnObtenerC.TabIndex = 2
        Me.btnObtenerC.Text = "&Obtener"
        Me.btnObtenerC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtenerC.UseVisualStyleBackColor = True
        '
        'txtFolioC
        '
        Me.txtFolioC.Location = New System.Drawing.Point(124, 27)
        Me.txtFolioC.Name = "txtFolioC"
        Me.txtFolioC.Size = New System.Drawing.Size(100, 22)
        Me.txtFolioC.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio del cliente:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dgvServ)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 185)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(590, 128)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Servicios:"
        '
        'dgvServ
        '
        Me.dgvServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvServ.Location = New System.Drawing.Point(18, 18)
        Me.dgvServ.Name = "dgvServ"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvServ.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvServ.Size = New System.Drawing.Size(557, 101)
        Me.dgvServ.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dgvRefs)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 329)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(590, 128)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Refacciones:"
        '
        'dgvRefs
        '
        Me.dgvRefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRefs.Location = New System.Drawing.Point(18, 19)
        Me.dgvRefs.Name = "dgvRefs"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvRefs.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRefs.Size = New System.Drawing.Size(557, 101)
        Me.dgvRefs.TabIndex = 1
        '
        'cmsserv
        '
        Me.cmsserv.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ESPERAToolStripMenuItem, Me.COMPLETOToolStripMenuItem, Me.NOSEAPLICOToolStripMenuItem})
        Me.cmsserv.Name = "cmsserv"
        Me.cmsserv.Size = New System.Drawing.Size(156, 70)
        '
        'ESPERAToolStripMenuItem
        '
        Me.ESPERAToolStripMenuItem.Name = "ESPERAToolStripMenuItem"
        Me.ESPERAToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ESPERAToolStripMenuItem.Text = "ESPERA"
        '
        'COMPLETOToolStripMenuItem
        '
        Me.COMPLETOToolStripMenuItem.Name = "COMPLETOToolStripMenuItem"
        Me.COMPLETOToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.COMPLETOToolStripMenuItem.Text = "COMPLETO"
        '
        'NOSEAPLICOToolStripMenuItem
        '
        Me.NOSEAPLICOToolStripMenuItem.Name = "NOSEAPLICOToolStripMenuItem"
        Me.NOSEAPLICOToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.NOSEAPLICOToolStripMenuItem.Text = "NO SE APLICO"
        '
        'cmsrefs
        '
        Me.cmsrefs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IMPLEMENTADA, Me.NOIMPLEMENTADA})
        Me.cmsrefs.Name = "cmsrefs"
        Me.cmsrefs.Size = New System.Drawing.Size(181, 48)
        '
        'IMPLEMENTADA
        '
        Me.IMPLEMENTADA.Name = "IMPLEMENTADA"
        Me.IMPLEMENTADA.Size = New System.Drawing.Size(180, 22)
        Me.IMPLEMENTADA.Text = "IMPLEMENTADA"
        '
        'NOIMPLEMENTADA
        '
        Me.NOIMPLEMENTADA.Name = "NOIMPLEMENTADA"
        Me.NOIMPLEMENTADA.Size = New System.Drawing.Size(180, 22)
        Me.NOIMPLEMENTADA.Text = "NO IMPLEMENTADA"
        '
        'btnCompleto
        '
        Me.btnCompleto.Enabled = False
        Me.btnCompleto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompleto.Image = Global.Papeleria.My.Resources.Resources.va
        Me.btnCompleto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCompleto.Location = New System.Drawing.Point(615, 336)
        Me.btnCompleto.Name = "btnCompleto"
        Me.btnCompleto.Size = New System.Drawing.Size(173, 36)
        Me.btnCompleto.TabIndex = 26
        Me.btnCompleto.Text = "&Servicio Completo"
        Me.btnCompleto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCompleto.UseVisualStyleBackColor = True
        '
        'lblservcomp
        '
        Me.lblservcomp.AutoSize = True
        Me.lblservcomp.BackColor = System.Drawing.Color.Transparent
        Me.lblservcomp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblservcomp.Location = New System.Drawing.Point(623, 203)
        Me.lblservcomp.Name = "lblservcomp"
        Me.lblservcomp.Size = New System.Drawing.Size(0, 19)
        Me.lblservcomp.TabIndex = 27
        '
        'lblFactura
        '
        Me.lblFactura.AutoSize = True
        Me.lblFactura.BackColor = System.Drawing.Color.Transparent
        Me.lblFactura.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactura.Location = New System.Drawing.Point(655, 250)
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Size = New System.Drawing.Size(0, 19)
        Me.lblFactura.TabIndex = 28
        Me.lblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnProcV
        '
        Me.btnProcV.Enabled = False
        Me.btnProcV.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcV.Image = Global.Papeleria.My.Resources.Resources.save1
        Me.btnProcV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcV.Location = New System.Drawing.Point(615, 394)
        Me.btnProcV.Name = "btnProcV"
        Me.btnProcV.Size = New System.Drawing.Size(173, 36)
        Me.btnProcV.TabIndex = 29
        Me.btnProcV.Text = "P&rocesar Venta  "
        Me.btnProcV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcV.UseVisualStyleBackColor = True
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(678, 9)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(28, 28)
        Me.btnMin.TabIndex = 31
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
        Me.btnClose.Location = New System.Drawing.Point(761, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(28, 28)
        Me.btnClose.TabIndex = 30
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmSegServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(810, 495)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnProcV)
        Me.Controls.Add(Me.gp1)
        Me.Controls.Add(Me.lblFactura)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblservcomp)
        Me.Controls.Add(Me.btnCompleto)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSegServicio"
        Me.Text = "Seguimiento del servicio"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gp1.ResumeLayout(False)
        Me.gp1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvServ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvRefs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsserv.ResumeLayout(False)
        Me.cmsrefs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSXC As System.Windows.Forms.Button
    Friend WithEvents btnObtener As System.Windows.Forms.Button
    Friend WithEvents txtFolioS As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents gp1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscarC As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnObtenerC As System.Windows.Forms.Button
    Friend WithEvents txtFolioC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvServ As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRefs As System.Windows.Forms.DataGridView
    Friend WithEvents cmsserv As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ESPERAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COMPLETOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOSEAPLICOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsrefs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents IMPLEMENTADA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOIMPLEMENTADA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCompleto As System.Windows.Forms.Button
    Friend WithEvents lblservcomp As System.Windows.Forms.Label
    Friend WithEvents lblFactura As System.Windows.Forms.Label
    Friend WithEvents btnProcV As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
