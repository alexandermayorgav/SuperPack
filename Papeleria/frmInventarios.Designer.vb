<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventarios
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
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.dgvP = New System.Windows.Forms.DataGridView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rbCodigo = New System.Windows.Forms.RadioButton()
        Me.rbDescripcion = New System.Windows.Forms.RadioButton()
        Me.rbTodo = New System.Windows.Forms.RadioButton()
        Me.rbCategoria = New System.Windows.Forms.RadioButton()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.chkCosto = New System.Windows.Forms.CheckBox()
        Me.btnMin = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.chkPrecioSugerido = New System.Windows.Forms.CheckBox()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        CType(Me.dgvP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.BackColor = System.Drawing.Color.Transparent
        Me.lblProducto.Location = New System.Drawing.Point(23, 66)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(49, 16)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Buscar"
        '
        'txtProducto
        '
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Location = New System.Drawing.Point(75, 62)
        Me.txtProducto.MaxLength = 20
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(302, 22)
        Me.txtProducto.TabIndex = 1
        '
        'dgvP
        '
        Me.dgvP.AllowUserToAddRows = False
        Me.dgvP.AllowUserToDeleteRows = False
        Me.dgvP.AllowUserToOrderColumns = True
        Me.dgvP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvP.Location = New System.Drawing.Point(23, 90)
        Me.dgvP.Name = "dgvP"
        Me.dgvP.Size = New System.Drawing.Size(926, 402)
        Me.dgvP.TabIndex = 2
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Papeleria.My.Resources.Resources.cancel2
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(33, 497)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 39)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(114, 497)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 39)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Exportar Pdf"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rbCodigo
        '
        Me.rbCodigo.AutoSize = True
        Me.rbCodigo.BackColor = System.Drawing.Color.Transparent
        Me.rbCodigo.Checked = True
        Me.rbCodigo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCodigo.Location = New System.Drawing.Point(341, 22)
        Me.rbCodigo.Name = "rbCodigo"
        Me.rbCodigo.Size = New System.Drawing.Size(71, 20)
        Me.rbCodigo.TabIndex = 32
        Me.rbCodigo.TabStop = True
        Me.rbCodigo.Text = "Codigo"
        Me.rbCodigo.UseVisualStyleBackColor = False
        '
        'rbDescripcion
        '
        Me.rbDescripcion.AutoSize = True
        Me.rbDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.rbDescripcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDescripcion.Location = New System.Drawing.Point(413, 22)
        Me.rbDescripcion.Name = "rbDescripcion"
        Me.rbDescripcion.Size = New System.Drawing.Size(100, 20)
        Me.rbDescripcion.TabIndex = 33
        Me.rbDescripcion.Text = "Descripcion"
        Me.rbDescripcion.UseVisualStyleBackColor = False
        '
        'rbTodo
        '
        Me.rbTodo.AutoSize = True
        Me.rbTodo.BackColor = System.Drawing.Color.Transparent
        Me.rbTodo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodo.Location = New System.Drawing.Point(600, 22)
        Me.rbTodo.Name = "rbTodo"
        Me.rbTodo.Size = New System.Drawing.Size(57, 20)
        Me.rbTodo.TabIndex = 34
        Me.rbTodo.Text = "Todo"
        Me.rbTodo.UseVisualStyleBackColor = False
        '
        'rbCategoria
        '
        Me.rbCategoria.AutoSize = True
        Me.rbCategoria.BackColor = System.Drawing.Color.Transparent
        Me.rbCategoria.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCategoria.Location = New System.Drawing.Point(513, 22)
        Me.rbCategoria.Name = "rbCategoria"
        Me.rbCategoria.Size = New System.Drawing.Size(88, 20)
        Me.rbCategoria.TabIndex = 35
        Me.rbCategoria.Text = "Categoria"
        Me.rbCategoria.UseVisualStyleBackColor = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(263, 509)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(15, 16)
        Me.lblTotal.TabIndex = 36
        Me.lblTotal.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(336, 509)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Productos Encontrados"
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(400, 64)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(126, 20)
        Me.chkSeleccionar.TabIndex = 38
        Me.chkSeleccionar.Text = "Seleccionar Todo"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '
        'chkCosto
        '
        Me.chkCosto.AutoSize = True
        Me.chkCosto.Location = New System.Drawing.Point(556, 64)
        Me.chkCosto.Name = "chkCosto"
        Me.chkCosto.Size = New System.Drawing.Size(105, 20)
        Me.chkCosto.TabIndex = 39
        Me.chkCosto.Text = "Mostar Costo"
        Me.chkCosto.UseVisualStyleBackColor = True
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(826, 12)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(25, 25)
        Me.btnMin.TabIndex = 41
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
        Me.btnClose.Location = New System.Drawing.Point(910, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 40
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'chkPrecioSugerido
        '
        Me.chkPrecioSugerido.AutoSize = True
        Me.chkPrecioSugerido.Location = New System.Drawing.Point(673, 64)
        Me.chkPrecioSugerido.Name = "chkPrecioSugerido"
        Me.chkPrecioSugerido.Size = New System.Drawing.Size(167, 20)
        Me.chkPrecioSugerido.TabIndex = 42
        Me.chkPrecioSugerido.Text = "Mostrar Precio Sugerido"
        Me.chkPrecioSugerido.UseVisualStyleBackColor = True
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPorcentaje.Location = New System.Drawing.Point(846, 62)
        Me.txtPorcentaje.MaxLength = 20
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(54, 22)
        Me.txtPorcentaje.TabIndex = 43
        Me.txtPorcentaje.Text = "20"
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPorcentaje.Visible = False
        Me.txtPorcentaje.WordWrap = False
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.BackColor = System.Drawing.Color.Transparent
        Me.lblPorcentaje.Location = New System.Drawing.Point(900, 66)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(20, 16)
        Me.lblPorcentaje.TabIndex = 44
        Me.lblPorcentaje.Text = "%"
        Me.lblPorcentaje.Visible = False
        '
        'frmInventarios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo22
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(978, 553)
        Me.Controls.Add(Me.lblPorcentaje)
        Me.Controls.Add(Me.txtPorcentaje)
        Me.Controls.Add(Me.chkPrecioSugerido)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.chkCosto)
        Me.Controls.Add(Me.chkSeleccionar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.rbCategoria)
        Me.Controls.Add(Me.rbTodo)
        Me.Controls.Add(Me.rbDescripcion)
        Me.Controls.Add(Me.rbCodigo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.dgvP)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.lblProducto)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmInventarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario"
        CType(Me.dgvP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents dgvP As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents rbCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents rbDescripcion As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodo As System.Windows.Forms.RadioButton
    Friend WithEvents rbCategoria As System.Windows.Forms.RadioButton
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents chkCosto As System.Windows.Forms.CheckBox
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkPrecioSugerido As System.Windows.Forms.CheckBox
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
End Class
