<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.DGVusers = New System.Windows.Forms.DataGridView
        Me.menunuevousuario = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.BorrarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ActivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tvgrupos = New System.Windows.Forms.TreeView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cbVentanas = New System.Windows.Forms.ComboBox
        Me.tvpermisos = New System.Windows.Forms.TreeView
        Me.tvPrivilegios = New System.Windows.Forms.TreeView
        Me.menuprivilegios = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.menugrupos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CambiarNombreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NuevoGrupoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.menuusuarios = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnPassword = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGVusers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menunuevousuario.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.menuprivilegios.SuspendLayout()
        Me.menugrupos.SuspendLayout()
        Me.menuusuarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(26, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(602, 369)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DGVusers)
        Me.TabPage1.Controls.Add(Me.tvgrupos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(594, 341)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Grupos/Usuarios"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DGVusers
        '
        Me.DGVusers.AllowDrop = True
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.DGVusers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVusers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGVusers.BackgroundColor = System.Drawing.Color.White
        Me.DGVusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVusers.ContextMenuStrip = Me.menunuevousuario
        Me.DGVusers.Location = New System.Drawing.Point(202, 6)
        Me.DGVusers.Name = "DGVusers"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.DGVusers.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVusers.Size = New System.Drawing.Size(382, 324)
        Me.DGVusers.TabIndex = 1
        '
        'menunuevousuario
        '
        Me.menunuevousuario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem3, Me.BorrarToolStripMenuItem1, Me.ActivarToolStripMenuItem})
        Me.menunuevousuario.Name = "menuusuarios"
        Me.menunuevousuario.Size = New System.Drawing.Size(183, 92)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuItem1.Text = "Nuevo Usuario"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuItem3.Text = "Cambiar Contraseña"
        '
        'BorrarToolStripMenuItem1
        '
        Me.BorrarToolStripMenuItem1.Name = "BorrarToolStripMenuItem1"
        Me.BorrarToolStripMenuItem1.Size = New System.Drawing.Size(182, 22)
        Me.BorrarToolStripMenuItem1.Text = "Desactivar"
        '
        'ActivarToolStripMenuItem
        '
        Me.ActivarToolStripMenuItem.Name = "ActivarToolStripMenuItem"
        Me.ActivarToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ActivarToolStripMenuItem.Text = "Activar"
        '
        'tvgrupos
        '
        Me.tvgrupos.AllowDrop = True
        Me.tvgrupos.BackColor = System.Drawing.Color.Lavender
        Me.tvgrupos.ContextMenuStrip = Me.menugrupos
        Me.tvgrupos.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tvgrupos.Location = New System.Drawing.Point(6, 6)
        Me.tvgrupos.Name = "tvgrupos"
        Me.tvgrupos.Size = New System.Drawing.Size(190, 324)
        Me.tvgrupos.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cbVentanas)
        Me.TabPage2.Controls.Add(Me.tvpermisos)
        Me.TabPage2.Controls.Add(Me.tvPrivilegios)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(594, 341)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Privilegios"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cbVentanas
        '
        Me.cbVentanas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbVentanas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbVentanas.FormattingEnabled = True
        Me.cbVentanas.Items.AddRange(New Object() {"Ventas", "Apartado", "Compras", "Productos", "Catalogos", "Consultas", "Configuracion y Soporte"})
        Me.cbVentanas.Location = New System.Drawing.Point(287, 8)
        Me.cbVentanas.Name = "cbVentanas"
        Me.cbVentanas.Size = New System.Drawing.Size(289, 23)
        Me.cbVentanas.TabIndex = 4
        '
        'tvpermisos
        '
        Me.tvpermisos.AllowDrop = True
        Me.tvpermisos.BackColor = System.Drawing.Color.Lavender
        Me.tvpermisos.LabelEdit = True
        Me.tvpermisos.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tvpermisos.Location = New System.Drawing.Point(287, 35)
        Me.tvpermisos.Name = "tvpermisos"
        Me.tvpermisos.Size = New System.Drawing.Size(289, 295)
        Me.tvpermisos.TabIndex = 3
        '
        'tvPrivilegios
        '
        Me.tvPrivilegios.AllowDrop = True
        Me.tvPrivilegios.BackColor = System.Drawing.Color.Lavender
        Me.tvPrivilegios.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tvPrivilegios.Location = New System.Drawing.Point(8, 8)
        Me.tvPrivilegios.Name = "tvPrivilegios"
        Me.tvPrivilegios.Size = New System.Drawing.Size(270, 322)
        Me.tvPrivilegios.TabIndex = 2
        '
        'menuprivilegios
        '
        Me.menuprivilegios.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2})
        Me.menuprivilegios.Name = "cbopciones"
        Me.menuprivilegios.Size = New System.Drawing.Size(107, 26)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(106, 22)
        Me.ToolStripMenuItem2.Text = "Borrar"
        '
        'menugrupos
        '
        Me.menugrupos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarToolStripMenuItem, Me.CambiarNombreToolStripMenuItem, Me.NuevoGrupoToolStripMenuItem})
        Me.menugrupos.Name = "menugrupos"
        Me.menugrupos.Size = New System.Drawing.Size(167, 70)
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar Grupo"
        '
        'CambiarNombreToolStripMenuItem
        '
        Me.CambiarNombreToolStripMenuItem.Name = "CambiarNombreToolStripMenuItem"
        Me.CambiarNombreToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CambiarNombreToolStripMenuItem.Text = "Cambiar Nombre"
        '
        'NuevoGrupoToolStripMenuItem
        '
        Me.NuevoGrupoToolStripMenuItem.Name = "NuevoGrupoToolStripMenuItem"
        Me.NuevoGrupoToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.NuevoGrupoToolStripMenuItem.Text = "Nuevo Grupo"
        '
        'menuusuarios
        '
        Me.menuusuarios.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarUsuarioToolStripMenuItem})
        Me.menuusuarios.Name = "menuusuarios"
        Me.menuusuarios.Size = New System.Drawing.Size(150, 26)
        '
        'BorrarUsuarioToolStripMenuItem
        '
        Me.BorrarUsuarioToolStripMenuItem.Name = "BorrarUsuarioToolStripMenuItem"
        Me.BorrarUsuarioToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.BorrarUsuarioToolStripMenuItem.Text = "Borrar Usuario"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(537, 7)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(28, 28)
        Me.btnMin.TabIndex = 14
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
        Me.btnClose.Location = New System.Drawing.Point(611, 7)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(28, 28)
        Me.btnClose.TabIndex = 13
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnPassword
        '
        Me.btnPassword.Location = New System.Drawing.Point(370, 12)
        Me.btnPassword.Name = "btnPassword"
        Me.btnPassword.Size = New System.Drawing.Size(125, 22)
        Me.btnPassword.TabIndex = 15
        Me.btnPassword.Text = "Cambiar Contraseña"
        Me.btnPassword.UseVisualStyleBackColor = True
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(650, 450)
        Me.Controls.Add(Me.btnPassword)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmUsuarios"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DGVusers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menunuevousuario.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.menuprivilegios.ResumeLayout(False)
        Me.menugrupos.ResumeLayout(False)
        Me.menuusuarios.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DGVusers As System.Windows.Forms.DataGridView
    Friend WithEvents tvgrupos As System.Windows.Forms.TreeView
    Friend WithEvents cbVentanas As System.Windows.Forms.ComboBox
    Friend WithEvents tvpermisos As System.Windows.Forms.TreeView
    Friend WithEvents tvPrivilegios As System.Windows.Forms.TreeView
    Friend WithEvents menuprivilegios As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menugrupos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarNombreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuusuarios As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoGrupoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menunuevousuario As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents BorrarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPassword As System.Windows.Forms.Button
End Class
