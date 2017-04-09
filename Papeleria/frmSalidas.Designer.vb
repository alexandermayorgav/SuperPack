<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalidas))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtfolio = New System.Windows.Forms.TextBox
        Me.btnversalida = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcodigo = New System.Windows.Forms.TextBox
        Me.btnbuscarprod = New System.Windows.Forms.Button
        Me.lblExistencia = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.btnagregar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtcosto = New System.Windows.Forms.TextBox
        Me.txtdescripcionprod = New System.Windows.Forms.Label
        Me.DGVSalidas = New System.Windows.Forms.DataGridView
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnFinalizar = New System.Windows.Forms.Button
        Me.btnNueva = New System.Windows.Forms.Button
        Me.fechasalida = New System.Windows.Forms.Label
        Me.labelfecha = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnMin = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotalsalida = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtcodigo)
        Me.GroupBox2.Controls.Add(Me.btnbuscarprod)
        Me.GroupBox2.Controls.Add(Me.lblExistencia)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtcantidad)
        Me.GroupBox2.Controls.Add(Me.btnagregar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtcosto)
        Me.GroupBox2.Controls.Add(Me.txtdescripcionprod)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 191)
        Me.GroupBox2.TabIndex = 91
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agregar Producto"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtfolio)
        Me.GroupBox1.Controls.Add(Me.btnversalida)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(456, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(230, 94)
        Me.GroupBox1.TabIndex = 92
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ver Salida"
        '
        'txtfolio
        '
        Me.txtfolio.Location = New System.Drawing.Point(114, 23)
        Me.txtfolio.Name = "txtfolio"
        Me.txtfolio.Size = New System.Drawing.Size(110, 20)
        Me.txtfolio.TabIndex = 10
        Me.txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnversalida
        '
        Me.btnversalida.Image = CType(resources.GetObject("btnversalida.Image"), System.Drawing.Image)
        Me.btnversalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnversalida.Location = New System.Drawing.Point(165, 49)
        Me.btnversalida.Name = "btnversalida"
        Me.btnversalida.Size = New System.Drawing.Size(60, 39)
        Me.btnversalida.TabIndex = 11
        Me.btnversalida.Text = "Ver"
        Me.btnversalida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnversalida.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Folio salida"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código Producto"
        '
        'txtcodigo
        '
        Me.txtcodigo.BackColor = System.Drawing.Color.White
        Me.txtcodigo.Location = New System.Drawing.Point(131, 30)
        Me.txtcodigo.MaxLength = 50
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(94, 20)
        Me.txtcodigo.TabIndex = 3
        '
        'btnbuscarprod
        '
        Me.btnbuscarprod.Image = CType(resources.GetObject("btnbuscarprod.Image"), System.Drawing.Image)
        Me.btnbuscarprod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbuscarprod.Location = New System.Drawing.Point(231, 20)
        Me.btnbuscarprod.Name = "btnbuscarprod"
        Me.btnbuscarprod.Size = New System.Drawing.Size(78, 39)
        Me.btnbuscarprod.TabIndex = 4
        Me.btnbuscarprod.Text = "Buscar"
        Me.btnbuscarprod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnbuscarprod.UseVisualStyleBackColor = True
        '
        'lblExistencia
        '
        Me.lblExistencia.BackColor = System.Drawing.Color.White
        Me.lblExistencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblExistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia.ForeColor = System.Drawing.Color.Black
        Me.lblExistencia.Location = New System.Drawing.Point(131, 70)
        Me.lblExistencia.Name = "lblExistencia"
        Me.lblExistencia.Size = New System.Drawing.Size(77, 23)
        Me.lblExistencia.TabIndex = 81
        Me.lblExistencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(235, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Cantidad"
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.White
        Me.txtcantidad.Location = New System.Drawing.Point(300, 107)
        Me.txtcantidad.MaxLength = 4
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(94, 20)
        Me.txtcantidad.TabIndex = 5
        '
        'btnagregar
        '
        Me.btnagregar.Image = Global.Papeleria.My.Resources.Resources.agregar3
        Me.btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregar.Location = New System.Drawing.Point(131, 142)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(132, 37)
        Me.btnagregar.TabIndex = 7
        Me.btnagregar.Text = "Agregar producto"
        Me.btnagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(82, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Costo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 16)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "Existencia Actual"
        '
        'txtcosto
        '
        Me.txtcosto.BackColor = System.Drawing.Color.White
        Me.txtcosto.Location = New System.Drawing.Point(131, 107)
        Me.txtcosto.Name = "txtcosto"
        Me.txtcosto.ReadOnly = True
        Me.txtcosto.Size = New System.Drawing.Size(94, 20)
        Me.txtcosto.TabIndex = 8
        '
        'txtdescripcionprod
        '
        Me.txtdescripcionprod.BackColor = System.Drawing.Color.White
        Me.txtdescripcionprod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtdescripcionprod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtdescripcionprod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescripcionprod.ForeColor = System.Drawing.Color.Black
        Me.txtdescripcionprod.Location = New System.Drawing.Point(314, 27)
        Me.txtdescripcionprod.Name = "txtdescripcionprod"
        Me.txtdescripcionprod.Size = New System.Drawing.Size(372, 22)
        Me.txtdescripcionprod.TabIndex = 80
        Me.txtdescripcionprod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DGVSalidas
        '
        Me.DGVSalidas.AllowUserToAddRows = False
        Me.DGVSalidas.AllowUserToDeleteRows = False
        Me.DGVSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSalidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.desc, Me.cantidad, Me.costo})
        Me.DGVSalidas.Location = New System.Drawing.Point(28, 270)
        Me.DGVSalidas.Name = "DGVSalidas"
        Me.DGVSalidas.ReadOnly = True
        Me.DGVSalidas.Size = New System.Drawing.Size(698, 150)
        Me.DGVSalidas.TabIndex = 92
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        '
        'desc
        '
        Me.desc.HeaderText = "Descripción"
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Width = 370
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.Width = 65
        '
        'costo
        '
        Me.costo.HeaderText = "Costo"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.Width = 120
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(137, 437)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(101, 36)
        Me.btnFinalizar.TabIndex = 94
        Me.btnFinalizar.Text = "Guardar"
        Me.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'btnNueva
        '
        Me.btnNueva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNueva.Image = Global.Papeleria.My.Resources.Resources.nuevo
        Me.btnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNueva.Location = New System.Drawing.Point(30, 437)
        Me.btnNueva.Name = "btnNueva"
        Me.btnNueva.Size = New System.Drawing.Size(89, 36)
        Me.btnNueva.TabIndex = 93
        Me.btnNueva.Text = "Nueva"
        Me.btnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNueva.UseVisualStyleBackColor = True
        '
        'fechasalida
        '
        Me.fechasalida.BackColor = System.Drawing.Color.White
        Me.fechasalida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fechasalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fechasalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechasalida.ForeColor = System.Drawing.Color.Black
        Me.fechasalida.Location = New System.Drawing.Point(587, 444)
        Me.fechasalida.Name = "fechasalida"
        Me.fechasalida.Size = New System.Drawing.Size(134, 23)
        Me.fechasalida.TabIndex = 95
        Me.fechasalida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelfecha
        '
        Me.labelfecha.AutoSize = True
        Me.labelfecha.BackColor = System.Drawing.Color.Transparent
        Me.labelfecha.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelfecha.Location = New System.Drawing.Point(485, 448)
        Me.labelfecha.Name = "labelfecha"
        Me.labelfecha.Size = New System.Drawing.Size(100, 16)
        Me.labelfecha.TabIndex = 93
        Me.labelfecha.Text = "Fecha de salida"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImage = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(706, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 102
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
        Me.btnMin.Location = New System.Drawing.Point(634, 11)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(25, 25)
        Me.btnMin.TabIndex = 101
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(273, 449)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 16)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Total"
        '
        'txtTotalsalida
        '
        Me.txtTotalsalida.BackColor = System.Drawing.Color.White
        Me.txtTotalsalida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTotalsalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtTotalsalida.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalsalida.ForeColor = System.Drawing.Color.Black
        Me.txtTotalsalida.Location = New System.Drawing.Point(315, 442)
        Me.txtTotalsalida.Name = "txtTotalsalida"
        Me.txtTotalsalida.Size = New System.Drawing.Size(156, 30)
        Me.txtTotalsalida.TabIndex = 104
        Me.txtTotalsalida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSalidas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(757, 505)
        Me.Controls.Add(Me.txtTotalsalida)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.labelfecha)
        Me.Controls.Add(Me.fechasalida)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnNueva)
        Me.Controls.Add(Me.DGVSalidas)
        Me.Controls.Add(Me.GroupBox2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSalidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Salidas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGVSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnbuscarprod As System.Windows.Forms.Button
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents btnagregar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtcosto As System.Windows.Forms.TextBox
    Friend WithEvents txtdescripcionprod As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtfolio As System.Windows.Forms.TextBox
    Friend WithEvents btnversalida As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGVSalidas As System.Windows.Forms.DataGridView
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents btnNueva As System.Windows.Forms.Button
    Friend WithEvents fechasalida As System.Windows.Forms.Label
    Friend WithEvents labelfecha As System.Windows.Forms.Label
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalsalida As System.Windows.Forms.Label
End Class
