<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaquetes
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
        Me.DGVPaquetes = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnguardar = New System.Windows.Forms.Button
        Me.btnClose2 = New System.Windows.Forms.Button
        Me.btnMin2 = New System.Windows.Forms.Button
        Me.btnNvaCantidades = New System.Windows.Forms.Button
        Me.btnRegresarCant = New System.Windows.Forms.Button
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.preciomenudeo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.piezas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codhermanos = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.DGVPaquetes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGVPaquetes
        '
        Me.DGVPaquetes.AllowUserToAddRows = False
        Me.DGVPaquetes.AllowUserToDeleteRows = False
        Me.DGVPaquetes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPaquetes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.desc, Me.costo, Me.precio, Me.preciomenudeo, Me.piezas, Me.idp, Me.codhermanos})
        Me.DGVPaquetes.Location = New System.Drawing.Point(6, 19)
        Me.DGVPaquetes.Name = "DGVPaquetes"
        Me.DGVPaquetes.Size = New System.Drawing.Size(711, 135)
        Me.DGVPaquetes.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DGVPaquetes)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(723, 161)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Actualización De Paquetes"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(656, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(15, 15)
        Me.btnClose.TabIndex = 100
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(586, 6)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(15, 15)
        Me.btnMin.TabIndex = 99
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'btnguardar
        '
        Me.btnguardar.BackgroundImage = Global.Papeleria.My.Resources.Resources.guardar4
        Me.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Location = New System.Drawing.Point(650, 217)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(91, 38)
        Me.btnguardar.TabIndex = 101
        Me.btnguardar.Text = "&Finalizar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btnClose2
        '
        Me.btnClose2.BackColor = System.Drawing.Color.Transparent
        Me.btnClose2.BackgroundImage = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose2.FlatAppearance.BorderSize = 0
        Me.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose2.Location = New System.Drawing.Point(719, 5)
        Me.btnClose2.Name = "btnClose2"
        Me.btnClose2.Size = New System.Drawing.Size(15, 15)
        Me.btnClose2.TabIndex = 103
        Me.btnClose2.UseVisualStyleBackColor = False
        '
        'btnMin2
        '
        Me.btnMin2.BackColor = System.Drawing.Color.Transparent
        Me.btnMin2.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin2.FlatAppearance.BorderSize = 0
        Me.btnMin2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin2.Location = New System.Drawing.Point(643, 6)
        Me.btnMin2.Name = "btnMin2"
        Me.btnMin2.Size = New System.Drawing.Size(15, 15)
        Me.btnMin2.TabIndex = 102
        Me.btnMin2.UseVisualStyleBackColor = False
        '
        'btnNvaCantidades
        '
        Me.btnNvaCantidades.BackgroundImage = Global.Papeleria.My.Resources.Resources.money
        Me.btnNvaCantidades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNvaCantidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNvaCantidades.Location = New System.Drawing.Point(17, 217)
        Me.btnNvaCantidades.Name = "btnNvaCantidades"
        Me.btnNvaCantidades.Size = New System.Drawing.Size(138, 38)
        Me.btnNvaCantidades.TabIndex = 104
        Me.btnNvaCantidades.Text = "&Calcular nuevas cantidades"
        Me.btnNvaCantidades.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNvaCantidades.UseVisualStyleBackColor = True
        '
        'btnRegresarCant
        '
        Me.btnRegresarCant.BackgroundImage = Global.Papeleria.My.Resources.Resources.eliminar1
        Me.btnRegresarCant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRegresarCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegresarCant.Location = New System.Drawing.Point(158, 217)
        Me.btnRegresarCant.Name = "btnRegresarCant"
        Me.btnRegresarCant.Size = New System.Drawing.Size(112, 38)
        Me.btnRegresarCant.TabIndex = 105
        Me.btnRegresarCant.Text = "&Regresar cantidades"
        Me.btnRegresarCant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRegresarCant.UseVisualStyleBackColor = True
        '
        'codigo
        '
        Me.codigo.HeaderText = "Código"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 70
        '
        'desc
        '
        Me.desc.HeaderText = "Descripción"
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Width = 230
        '
        'costo
        '
        Me.costo.HeaderText = "Costo"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.Width = 70
        '
        'precio
        '
        Me.precio.HeaderText = "Precio"
        Me.precio.Name = "precio"
        Me.precio.Width = 70
        '
        'preciomenudeo
        '
        Me.preciomenudeo.HeaderText = "PrecioMenudeo"
        Me.preciomenudeo.Name = "preciomenudeo"
        Me.preciomenudeo.Width = 90
        '
        'piezas
        '
        Me.piezas.HeaderText = "Piezas"
        Me.piezas.Name = "piezas"
        Me.piezas.ReadOnly = True
        Me.piezas.Width = 60
        '
        'idp
        '
        Me.idp.HeaderText = "ID"
        Me.idp.Name = "idp"
        Me.idp.ReadOnly = True
        Me.idp.Visible = False
        '
        'codhermanos
        '
        Me.codhermanos.HeaderText = "C. Hermanos"
        Me.codhermanos.Name = "codhermanos"
        Me.codhermanos.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codhermanos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.codhermanos.Width = 60
        '
        'frmPaquetes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo21
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(763, 271)
        Me.Controls.Add(Me.btnRegresarCant)
        Me.Controls.Add(Me.btnNvaCantidades)
        Me.Controls.Add(Me.btnClose2)
        Me.Controls.Add(Me.btnMin2)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPaquetes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Costo Nuevo Paquetes"
        CType(Me.DGVPaquetes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGVPaquetes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnClose2 As System.Windows.Forms.Button
    Friend WithEvents btnMin2 As System.Windows.Forms.Button
    Friend WithEvents btnNvaCantidades As System.Windows.Forms.Button
    Friend WithEvents btnRegresarCant As System.Windows.Forms.Button
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents preciomenudeo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents piezas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codhermanos As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
