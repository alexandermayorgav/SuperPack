<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductos
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.Proveedores = New System.Windows.Forms.TabPage
        Me.dgvp = New System.Windows.Forms.DataGridView
        Me.id_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.razonsocial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.dgvPaquetes = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodigoPaq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionPaq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiezasPaq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostoPaq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrecioPaq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenudeoPaq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ddlPorcentajes = New System.Windows.Forms.ComboBox
        Me.txtMenudeo = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtRango = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtSobrante = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDescuento = New System.Windows.Forms.TextBox
        Me.txtPiezas = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtExistencia = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMAx = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtMin = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPrecio = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCosto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkkg = New System.Windows.Forms.CheckBox
        Me.chkActualizar = New System.Windows.Forms.CheckBox
        Me.chkIva = New System.Windows.Forms.CheckBox
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ddlLinea = New System.Windows.Forms.ComboBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtdeshacer = New System.Windows.Forms.TextBox
        Me.btnAgregarPaq = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblDsiponibles = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtNumPaq = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cbIvaP = New System.Windows.Forms.CheckBox
        Me.cbActivoP = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtExistenciaP = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtPrecioP = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtCostoP = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtDescripcionP = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtCodigoP = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageButton1 = New Papeleria.ImageButton
        Me.btnProveedor = New Papeleria.ImageButton
        Me.btnCanPrecios = New Papeleria.ImageButton
        Me.btnActPrecios = New Papeleria.ImageButton
        Me.btnAgregarPaquetes = New Papeleria.ImageButton
        Me.btnArmarPaquetes = New Papeleria.ImageButton
        Me.btnnuevo = New Papeleria.ImageButton
        Me.btnGuardar = New Papeleria.ImageButton
        Me.btnAgregarLinea = New Papeleria.ImageButton
        Me.btnBuscar = New Papeleria.ImageButton
        Me.btnDeshacer = New Papeleria.ImageButton
        Me.btnNewPaq = New Papeleria.ImageButton
        Me.btnCrearpq = New Papeleria.ImageButton
        Me.btnAgregar = New Papeleria.ImageButton
        Me.btnBuscarP = New Papeleria.ImageButton
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.Proveedores.SuspendLayout()
        CType(Me.dgvp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvPaquetes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(22, 75)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(543, 610)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ImageButton1)
        Me.TabPage1.Controls.Add(Me.dtp)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.TabControl2)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btnnuevo)
        Me.TabPage1.Controls.Add(Me.btnGuardar)
        Me.TabPage1.Controls.Add(Me.btnAgregarLinea)
        Me.TabPage1.Controls.Add(Me.btnBuscar)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtDescripcion)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.ddlLinea)
        Me.TabPage1.Controls.Add(Me.txtCodigo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(535, 584)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Productos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtp
        '
        Me.dtp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp.Location = New System.Drawing.Point(112, 110)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(249, 22)
        Me.dtp.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 16)
        Me.Label15.TabIndex = 106
        Me.Label15.Text = "Fecha Compra"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.Proveedores)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Location = New System.Drawing.Point(6, 344)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(523, 193)
        Me.TabControl2.TabIndex = 19
        '
        'Proveedores
        '
        Me.Proveedores.Controls.Add(Me.btnProveedor)
        Me.Proveedores.Controls.Add(Me.dgvp)
        Me.Proveedores.Location = New System.Drawing.Point(4, 22)
        Me.Proveedores.Name = "Proveedores"
        Me.Proveedores.Padding = New System.Windows.Forms.Padding(3)
        Me.Proveedores.Size = New System.Drawing.Size(515, 167)
        Me.Proveedores.TabIndex = 0
        Me.Proveedores.Text = "Proveedores"
        Me.Proveedores.UseVisualStyleBackColor = True
        '
        'dgvp
        '
        Me.dgvp.AllowUserToAddRows = False
        Me.dgvp.AllowUserToDeleteRows = False
        Me.dgvp.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_proveedor, Me.razonsocial})
        Me.dgvp.Location = New System.Drawing.Point(6, 6)
        Me.dgvp.Name = "dgvp"
        Me.dgvp.ReadOnly = True
        Me.dgvp.Size = New System.Drawing.Size(404, 155)
        Me.dgvp.TabIndex = 0
        '
        'id_proveedor
        '
        Me.id_proveedor.HeaderText = "id"
        Me.id_proveedor.Name = "id_proveedor"
        Me.id_proveedor.ReadOnly = True
        Me.id_proveedor.Visible = False
        '
        'razonsocial
        '
        Me.razonsocial.HeaderText = "Razon Social"
        Me.razonsocial.Name = "razonsocial"
        Me.razonsocial.ReadOnly = True
        Me.razonsocial.Width = 270
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.btnCanPrecios)
        Me.TabPage5.Controls.Add(Me.btnActPrecios)
        Me.TabPage5.Controls.Add(Me.btnAgregarPaquetes)
        Me.TabPage5.Controls.Add(Me.dgvPaquetes)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(515, 167)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Paquetes Relacionados"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvPaquetes
        '
        Me.dgvPaquetes.AllowUserToAddRows = False
        Me.dgvPaquetes.AllowUserToDeleteRows = False
        Me.dgvPaquetes.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvPaquetes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPaquetes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaquetes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.CodigoPaq, Me.DescripcionPaq, Me.PiezasPaq, Me.CostoPaq, Me.PrecioPaq, Me.MenudeoPaq})
        Me.dgvPaquetes.Location = New System.Drawing.Point(6, 6)
        Me.dgvPaquetes.Name = "dgvPaquetes"
        Me.dgvPaquetes.Size = New System.Drawing.Size(419, 155)
        Me.dgvPaquetes.TabIndex = 20
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'CodigoPaq
        '
        Me.CodigoPaq.HeaderText = "Codigo"
        Me.CodigoPaq.Name = "CodigoPaq"
        Me.CodigoPaq.ReadOnly = True
        '
        'DescripcionPaq
        '
        Me.DescripcionPaq.HeaderText = "Descripcion"
        Me.DescripcionPaq.Name = "DescripcionPaq"
        Me.DescripcionPaq.ReadOnly = True
        '
        'PiezasPaq
        '
        Me.PiezasPaq.HeaderText = "Piezas"
        Me.PiezasPaq.Name = "PiezasPaq"
        Me.PiezasPaq.ReadOnly = True
        '
        'CostoPaq
        '
        Me.CostoPaq.HeaderText = "Costo"
        Me.CostoPaq.Name = "CostoPaq"
        '
        'PrecioPaq
        '
        Me.PrecioPaq.HeaderText = "Precio"
        Me.PrecioPaq.Name = "PrecioPaq"
        '
        'MenudeoPaq
        '
        Me.MenudeoPaq.HeaderText = "$ Menudeo"
        Me.MenudeoPaq.Name = "MenudeoPaq"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnArmarPaquetes)
        Me.GroupBox2.Controls.Add(Me.ddlPorcentajes)
        Me.GroupBox2.Controls.Add(Me.txtMenudeo)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtRango)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtSobrante)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtDescuento)
        Me.GroupBox2.Controls.Add(Me.txtPiezas)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtExistencia)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtMAx)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtMin)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPrecio)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCosto)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(507, 156)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Precios y Costos"
        '
        'ddlPorcentajes
        '
        Me.ddlPorcentajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlPorcentajes.FormattingEnabled = True
        Me.ddlPorcentajes.Items.AddRange(New Object() {"Mayoreo", "1/2 Mayoreo"})
        Me.ddlPorcentajes.Location = New System.Drawing.Point(178, 16)
        Me.ddlPorcentajes.Name = "ddlPorcentajes"
        Me.ddlPorcentajes.Size = New System.Drawing.Size(87, 21)
        Me.ddlPorcentajes.TabIndex = 138
        '
        'txtMenudeo
        '
        Me.txtMenudeo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMenudeo.Location = New System.Drawing.Point(106, 43)
        Me.txtMenudeo.Name = "txtMenudeo"
        Me.txtMenudeo.Size = New System.Drawing.Size(64, 22)
        Me.txtMenudeo.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(170, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(20, 16)
        Me.Label16.TabIndex = 132
        Me.Label16.Text = "%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkRed
        Me.Label12.Location = New System.Drawing.Point(423, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 16)
        Me.Label12.TabIndex = 135
        Me.Label12.Text = "Pz."
        '
        'txtRango
        '
        Me.txtRango.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRango.Location = New System.Drawing.Point(359, 98)
        Me.txtRango.Name = "txtRango"
        Me.txtRango.Size = New System.Drawing.Size(64, 22)
        Me.txtRango.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(0, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 16)
        Me.Label14.TabIndex = 137
        Me.Label14.Text = "Precio Menudeo"
        '
        'txtSobrante
        '
        Me.txtSobrante.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSobrante.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSobrante.Location = New System.Drawing.Point(359, 126)
        Me.txtSobrante.Name = "txtSobrante"
        Me.txtSobrante.Size = New System.Drawing.Size(64, 22)
        Me.txtSobrante.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(295, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 16)
        Me.Label11.TabIndex = 134
        Me.Label11.Text = "Sobrante"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(310, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 16)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "Rango"
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.Location = New System.Drawing.Point(106, 98)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(64, 22)
        Me.txtDescuento.TabIndex = 12
        '
        'txtPiezas
        '
        Me.txtPiezas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPiezas.Location = New System.Drawing.Point(105, 126)
        Me.txtPiezas.Name = "txtPiezas"
        Me.txtPiezas.Size = New System.Drawing.Size(65, 22)
        Me.txtPiezas.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "No. Piezas"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(32, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 16)
        Me.Label9.TabIndex = 124
        Me.Label9.Text = "Descuento"
        '
        'txtExistencia
        '
        Me.txtExistencia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExistencia.Location = New System.Drawing.Point(359, 43)
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.Size = New System.Drawing.Size(64, 22)
        Me.txtExistencia.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(286, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 16)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "Existencia"
        '
        'txtMAx
        '
        Me.txtMAx.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMAx.Location = New System.Drawing.Point(106, 70)
        Me.txtMAx.Name = "txtMAx"
        Me.txtMAx.Size = New System.Drawing.Size(64, 22)
        Me.txtMAx.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 16)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "Stock Max."
        '
        'txtMin
        '
        Me.txtMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMin.Location = New System.Drawing.Point(359, 70)
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(64, 22)
        Me.txtMin.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(286, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 16)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Stock Min."
        '
        'txtPrecio
        '
        Me.txtPrecio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(359, 16)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(64, 22)
        Me.txtPrecio.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(310, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "Precio"
        '
        'txtCosto
        '
        Me.txtCosto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCosto.Location = New System.Drawing.Point(106, 16)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(64, 22)
        Me.txtCosto.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "Costo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkkg)
        Me.GroupBox1.Controls.Add(Me.chkActualizar)
        Me.GroupBox1.Controls.Add(Me.chkIva)
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 292)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 46)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuracion"
        '
        'chkkg
        '
        Me.chkkg.AutoSize = True
        Me.chkkg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkkg.Location = New System.Drawing.Point(162, 18)
        Me.chkkg.Name = "chkkg"
        Me.chkkg.Size = New System.Drawing.Size(103, 20)
        Me.chkkg.TabIndex = 19
        Me.chkkg.Text = "Venta  en Kg"
        Me.chkkg.UseVisualStyleBackColor = True
        '
        'chkActualizar
        '
        Me.chkActualizar.AutoSize = True
        Me.chkActualizar.Checked = True
        Me.chkActualizar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActualizar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActualizar.Location = New System.Drawing.Point(271, 18)
        Me.chkActualizar.Name = "chkActualizar"
        Me.chkActualizar.Size = New System.Drawing.Size(199, 20)
        Me.chkActualizar.TabIndex = 20
        Me.chkActualizar.Text = "Actualizar Codigos Hermanos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkActualizar.UseVisualStyleBackColor = True
        Me.chkActualizar.Visible = False
        '
        'chkIva
        '
        Me.chkIva.AutoSize = True
        Me.chkIva.Checked = True
        Me.chkIva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIva.Location = New System.Drawing.Point(17, 18)
        Me.chkIva.Name = "chkIva"
        Me.chkIva.Size = New System.Drawing.Size(68, 20)
        Me.chkIva.TabIndex = 17
        Me.chkIva.Text = "I. V. A."
        Me.chkIva.UseVisualStyleBackColor = True
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(94, 18)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(62, 20)
        Me.chkActivo.TabIndex = 18
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(70, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 16)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "Línea"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(113, 78)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(232, 22)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Descripción"
        '
        'ddlLinea
        '
        Me.ddlLinea.DisplayMember = "Linea"
        Me.ddlLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlLinea.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlLinea.FormattingEnabled = True
        Me.ddlLinea.Location = New System.Drawing.Point(112, 46)
        Me.ddlLinea.Name = "ddlLinea"
        Me.ddlLinea.Size = New System.Drawing.Size(233, 24)
        Me.ddlLinea.TabIndex = 2
        Me.ddlLinea.ValueMember = "Id"
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(112, 8)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(233, 22)
        Me.txtCodigo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Código/Clave"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.txtdeshacer)
        Me.TabPage2.Controls.Add(Me.btnAgregarPaq)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.lblDsiponibles)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txtNumPaq)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.txtDescripcionP)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtCodigoP)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.btnDeshacer)
        Me.TabPage2.Controls.Add(Me.btnNewPaq)
        Me.TabPage2.Controls.Add(Me.btnCrearpq)
        Me.TabPage2.Controls.Add(Me.btnAgregar)
        Me.TabPage2.Controls.Add(Me.btnBuscarP)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(535, 584)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Paquetes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(15, 446)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(134, 16)
        Me.Label20.TabIndex = 125
        Me.Label20.Text = "Paquetes a Desarmar"
        '
        'txtdeshacer
        '
        Me.txtdeshacer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdeshacer.Location = New System.Drawing.Point(177, 442)
        Me.txtdeshacer.Name = "txtdeshacer"
        Me.txtdeshacer.Size = New System.Drawing.Size(64, 22)
        Me.txtdeshacer.TabIndex = 124
        '
        'btnAgregarPaq
        '
        Me.btnAgregarPaq.Location = New System.Drawing.Point(247, 403)
        Me.btnAgregarPaq.Name = "btnAgregarPaq"
        Me.btnAgregarPaq.Size = New System.Drawing.Size(37, 30)
        Me.btnAgregarPaq.TabIndex = 123
        Me.btnAgregarPaq.Text = "+"
        Me.btnAgregarPaq.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(14, 416)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(125, 16)
        Me.Label21.TabIndex = 121
        Me.Label21.Text = "Paquetes a Realizar"
        '
        'lblDsiponibles
        '
        Me.lblDsiponibles.AutoSize = True
        Me.lblDsiponibles.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDsiponibles.ForeColor = System.Drawing.Color.Maroon
        Me.lblDsiponibles.Location = New System.Drawing.Point(174, 379)
        Me.lblDsiponibles.Name = "lblDsiponibles"
        Me.lblDsiponibles.Size = New System.Drawing.Size(12, 16)
        Me.lblDsiponibles.TabIndex = 120
        Me.lblDsiponibles.Text = "-"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(14, 377)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 16)
        Me.Label17.TabIndex = 119
        Me.Label17.Text = "Paquetes Posibles"
        '
        'txtNumPaq
        '
        Me.txtNumPaq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPaq.Location = New System.Drawing.Point(177, 411)
        Me.txtNumPaq.Name = "txtNumPaq"
        Me.txtNumPaq.Size = New System.Drawing.Size(64, 22)
        Me.txtNumPaq.TabIndex = 116
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(14, 226)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(460, 144)
        Me.DataGridView1.TabIndex = 116
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbIvaP)
        Me.GroupBox4.Controls.Add(Me.cbActivoP)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 161)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(329, 59)
        Me.GroupBox4.TabIndex = 115
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Configuracion"
        '
        'cbIvaP
        '
        Me.cbIvaP.AutoSize = True
        Me.cbIvaP.Checked = True
        Me.cbIvaP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIvaP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIvaP.Location = New System.Drawing.Point(28, 26)
        Me.cbIvaP.Name = "cbIvaP"
        Me.cbIvaP.Size = New System.Drawing.Size(68, 20)
        Me.cbIvaP.TabIndex = 79
        Me.cbIvaP.Text = "I. V. A."
        Me.cbIvaP.UseVisualStyleBackColor = True
        '
        'cbActivoP
        '
        Me.cbActivoP.AutoSize = True
        Me.cbActivoP.Checked = True
        Me.cbActivoP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActivoP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActivoP.Location = New System.Drawing.Point(202, 29)
        Me.cbActivoP.Name = "cbActivoP"
        Me.cbActivoP.Size = New System.Drawing.Size(62, 20)
        Me.cbActivoP.TabIndex = 102
        Me.cbActivoP.Text = "Activo"
        Me.cbActivoP.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtExistenciaP)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtPrecioP)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.txtCostoP)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(460, 59)
        Me.GroupBox3.TabIndex = 114
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Precios y Costos"
        '
        'txtExistenciaP
        '
        Me.txtExistenciaP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExistenciaP.Location = New System.Drawing.Point(356, 18)
        Me.txtExistenciaP.Name = "txtExistenciaP"
        Me.txtExistenciaP.ReadOnly = True
        Me.txtExistenciaP.Size = New System.Drawing.Size(64, 22)
        Me.txtExistenciaP.TabIndex = 117
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(281, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(69, 16)
        Me.Label22.TabIndex = 116
        Me.Label22.Text = "Existencia"
        '
        'txtPrecioP
        '
        Me.txtPrecioP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioP.Location = New System.Drawing.Point(180, 19)
        Me.txtPrecioP.Name = "txtPrecioP"
        Me.txtPrecioP.Size = New System.Drawing.Size(64, 22)
        Me.txtPrecioP.TabIndex = 115
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(131, 22)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(45, 16)
        Me.Label31.TabIndex = 114
        Me.Label31.Text = "Precio"
        '
        'txtCostoP
        '
        Me.txtCostoP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoP.Location = New System.Drawing.Point(61, 19)
        Me.txtCostoP.Name = "txtCostoP"
        Me.txtCostoP.ReadOnly = True
        Me.txtCostoP.Size = New System.Drawing.Size(64, 22)
        Me.txtCostoP.TabIndex = 113
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(15, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(42, 16)
        Me.Label32.TabIndex = 112
        Me.Label32.Text = "Costo"
        '
        'txtDescripcionP
        '
        Me.txtDescripcionP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionP.Location = New System.Drawing.Point(107, 66)
        Me.txtDescripcionP.Name = "txtDescripcionP"
        Me.txtDescripcionP.Size = New System.Drawing.Size(236, 22)
        Me.txtDescripcionP.TabIndex = 110
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(27, 69)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 16)
        Me.Label18.TabIndex = 109
        Me.Label18.Text = "Descripción"
        '
        'txtCodigoP
        '
        Me.txtCodigoP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoP.Location = New System.Drawing.Point(106, 20)
        Me.txtCodigoP.Name = "txtCodigoP"
        Me.txtCodigoP.Size = New System.Drawing.Size(237, 22)
        Me.txtCodigoP.TabIndex = 107
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(20, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 16)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "Código/Clave"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(489, 21)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(24, 24)
        Me.btnMin.TabIndex = 18
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
        Me.btnClose.Location = New System.Drawing.Point(543, 21)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(24, 24)
        Me.btnClose.TabIndex = 17
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'ImageButton1
        '
        Me.ImageButton1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ImageButton1.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.ImageButton1.ButtonImage = Nothing
        Me.ImageButton1.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.ImageButton1.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.ImageButton1.Enabled = False
        Me.ImageButton1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImageButton1.Image = Global.Papeleria.My.Resources.Resources.eliminar2
        Me.ImageButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ImageButton1.Location = New System.Drawing.Point(6, 542)
        Me.ImageButton1.Name = "ImageButton1"
        Me.ImageButton1.Size = New System.Drawing.Size(94, 40)
        Me.ImageButton1.TabIndex = 107
        Me.ImageButton1.Text = "Eliminar"
        Me.ImageButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ImageButton1.UseVisualStyleBackColor = True
        '
        'btnProveedor
        '
        Me.btnProveedor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnProveedor.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnProveedor.ButtonImage = Nothing
        Me.btnProveedor.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnProveedor.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnProveedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProveedor.Image = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProveedor.Location = New System.Drawing.Point(416, 6)
        Me.btnProveedor.Name = "btnProveedor"
        Me.btnProveedor.Size = New System.Drawing.Size(93, 36)
        Me.btnProveedor.TabIndex = 21
        Me.btnProveedor.Text = "Agregar"
        Me.btnProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProveedor.UseVisualStyleBackColor = True
        '
        'btnCanPrecios
        '
        Me.btnCanPrecios.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCanPrecios.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnCanPrecios.ButtonImage = Nothing
        Me.btnCanPrecios.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnCanPrecios.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnCanPrecios.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCanPrecios.Image = Global.Papeleria.My.Resources.Resources.eliminar
        Me.btnCanPrecios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCanPrecios.Location = New System.Drawing.Point(428, 96)
        Me.btnCanPrecios.Name = "btnCanPrecios"
        Me.btnCanPrecios.Size = New System.Drawing.Size(83, 40)
        Me.btnCanPrecios.TabIndex = 23
        Me.btnCanPrecios.Text = "Cancelar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Precios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnCanPrecios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCanPrecios.UseVisualStyleBackColor = True
        '
        'btnActPrecios
        '
        Me.btnActPrecios.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnActPrecios.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnActPrecios.ButtonImage = Nothing
        Me.btnActPrecios.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnActPrecios.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnActPrecios.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActPrecios.Image = Global.Papeleria.My.Resources.Resources.va
        Me.btnActPrecios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActPrecios.Location = New System.Drawing.Point(428, 47)
        Me.btnActPrecios.Name = "btnActPrecios"
        Me.btnActPrecios.Size = New System.Drawing.Size(83, 40)
        Me.btnActPrecios.TabIndex = 22
        Me.btnActPrecios.Text = "Calcular" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Precios"
        Me.btnActPrecios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActPrecios.UseVisualStyleBackColor = True
        '
        'btnAgregarPaquetes
        '
        Me.btnAgregarPaquetes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAgregarPaquetes.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnAgregarPaquetes.ButtonImage = Nothing
        Me.btnAgregarPaquetes.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnAgregarPaquetes.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnAgregarPaquetes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarPaquetes.Image = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnAgregarPaquetes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarPaquetes.Location = New System.Drawing.Point(428, 3)
        Me.btnAgregarPaquetes.Name = "btnAgregarPaquetes"
        Me.btnAgregarPaquetes.Size = New System.Drawing.Size(83, 36)
        Me.btnAgregarPaquetes.TabIndex = 22
        Me.btnAgregarPaquetes.Text = "Agregar"
        Me.btnAgregarPaquetes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarPaquetes.UseVisualStyleBackColor = True
        '
        'btnArmarPaquetes
        '
        Me.btnArmarPaquetes.BackColor = System.Drawing.Color.Transparent
        Me.btnArmarPaquetes.BackgroundImage = Global.Papeleria.My.Resources.Resources.va
        Me.btnArmarPaquetes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnArmarPaquetes.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnArmarPaquetes.ButtonImage = Nothing
        Me.btnArmarPaquetes.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnArmarPaquetes.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnArmarPaquetes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArmarPaquetes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArmarPaquetes.Location = New System.Drawing.Point(453, 122)
        Me.btnArmarPaquetes.Name = "btnArmarPaquetes"
        Me.btnArmarPaquetes.Size = New System.Drawing.Size(30, 30)
        Me.btnArmarPaquetes.TabIndex = 24
        Me.btnArmarPaquetes.Text = "        Armar Paquete"
        Me.btnArmarPaquetes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnArmarPaquetes.UseVisualStyleBackColor = False
        Me.btnArmarPaquetes.Visible = False
        '
        'btnnuevo
        '
        Me.btnnuevo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnnuevo.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnnuevo.ButtonImage = Nothing
        Me.btnnuevo.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnnuevo.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnnuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Image = Global.Papeleria.My.Resources.Resources.nuevo
        Me.btnnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnuevo.Location = New System.Drawing.Point(311, 542)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(83, 36)
        Me.btnnuevo.TabIndex = 24
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnGuardar.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnGuardar.ButtonImage = Nothing
        Me.btnGuardar.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnGuardar.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnGuardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(419, 542)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(100, 36)
        Me.btnGuardar.TabIndex = 23
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnAgregarLinea
        '
        Me.btnAgregarLinea.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAgregarLinea.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnAgregarLinea.ButtonImage = Nothing
        Me.btnAgregarLinea.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnAgregarLinea.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnAgregarLinea.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarLinea.Image = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnAgregarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarLinea.Location = New System.Drawing.Point(426, 43)
        Me.btnAgregarLinea.Name = "btnAgregarLinea"
        Me.btnAgregarLinea.Size = New System.Drawing.Size(93, 40)
        Me.btnAgregarLinea.TabIndex = 105
        Me.btnAgregarLinea.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Linea"
        Me.btnAgregarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarLinea.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBuscar.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnBuscar.ButtonImage = Nothing
        Me.btnBuscar.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnBuscar.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnBuscar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(426, 1)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(93, 36)
        Me.btnBuscar.TabIndex = 104
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnDeshacer
        '
        Me.btnDeshacer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnDeshacer.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnDeshacer.ButtonImage = Nothing
        Me.btnDeshacer.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnDeshacer.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnDeshacer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeshacer.Location = New System.Drawing.Point(247, 440)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(37, 27)
        Me.btnDeshacer.TabIndex = 122
        Me.btnDeshacer.Text = "-"
        Me.btnDeshacer.UseVisualStyleBackColor = True
        '
        'btnNewPaq
        '
        Me.btnNewPaq.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnNewPaq.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnNewPaq.ButtonImage = Nothing
        Me.btnNewPaq.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnNewPaq.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnNewPaq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewPaq.Image = Global.Papeleria.My.Resources.Resources.nuevo
        Me.btnNewPaq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewPaq.Location = New System.Drawing.Point(366, 384)
        Me.btnNewPaq.Name = "btnNewPaq"
        Me.btnNewPaq.Size = New System.Drawing.Size(108, 36)
        Me.btnNewPaq.TabIndex = 118
        Me.btnNewPaq.Text = "Nuevo"
        Me.btnNewPaq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNewPaq.UseVisualStyleBackColor = True
        '
        'btnCrearpq
        '
        Me.btnCrearpq.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCrearpq.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnCrearpq.ButtonImage = Nothing
        Me.btnCrearpq.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnCrearpq.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnCrearpq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearpq.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnCrearpq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCrearpq.Location = New System.Drawing.Point(366, 426)
        Me.btnCrearpq.Name = "btnCrearpq"
        Me.btnCrearpq.Size = New System.Drawing.Size(108, 36)
        Me.btnCrearpq.TabIndex = 117
        Me.btnCrearpq.Text = "Crear"
        Me.btnCrearpq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCrearpq.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAgregar.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnAgregar.ButtonImage = Nothing
        Me.btnAgregar.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnAgregar.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnAgregar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(370, 165)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(93, 52)
        Me.btnAgregar.TabIndex = 113
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBuscarP
        '
        Me.btnBuscarP.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBuscarP.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnBuscarP.ButtonImage = Nothing
        Me.btnBuscarP.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnBuscarP.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnBuscarP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarP.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnBuscarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarP.Location = New System.Drawing.Point(381, 13)
        Me.btnBuscarP.Name = "btnBuscarP"
        Me.btnBuscarP.Size = New System.Drawing.Size(93, 36)
        Me.btnBuscarP.TabIndex = 112
        Me.btnBuscarP.Text = "Buscar"
        Me.btnBuscarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarP.UseVisualStyleBackColor = True
        '
        'frmProductos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(584, 711)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.Proveedores.ResumeLayout(False)
        CType(Me.dgvp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvPaquetes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chkActualizar As System.Windows.Forms.CheckBox
    Friend WithEvents btnnuevo As Papeleria.ImageButton
    Friend WithEvents btnGuardar As Papeleria.ImageButton
    Friend WithEvents btnAgregarLinea As Papeleria.ImageButton
    Friend WithEvents btnBuscar As Papeleria.ImageButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkIva As System.Windows.Forms.CheckBox
    Friend WithEvents ddlLinea As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRango As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtExistencia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPiezas As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMAx As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewPaq As Papeleria.ImageButton
    Friend WithEvents btnCrearpq As Papeleria.ImageButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbIvaP As System.Windows.Forms.CheckBox
    Friend WithEvents cbActivoP As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrecioP As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtCostoP As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As Papeleria.ImageButton
    Friend WithEvents txtDescripcionP As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoP As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblDsiponibles As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNumPaq As System.Windows.Forms.TextBox
    Friend WithEvents btnDeshacer As Papeleria.ImageButton
    Friend WithEvents btnBuscarP As Papeleria.ImageButton
    Friend WithEvents txtExistenciaP As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarPaq As System.Windows.Forms.Button
    Friend WithEvents txtdeshacer As System.Windows.Forms.TextBox
    Friend WithEvents btnProveedor As Papeleria.ImageButton
    Friend WithEvents dgvp As System.Windows.Forms.DataGridView
    Friend WithEvents id_proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents razonsocial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkkg As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents Proveedores As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents btnAgregarPaquetes As Papeleria.ImageButton
    Friend WithEvents dgvPaquetes As System.Windows.Forms.DataGridView
    Friend WithEvents txtMenudeo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSobrante As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ddlPorcentajes As System.Windows.Forms.ComboBox
    Friend WithEvents btnActPrecios As Papeleria.ImageButton
    Private WithEvents btnCanPrecios As Papeleria.ImageButton
    Friend WithEvents btnArmarPaquetes As Papeleria.ImageButton
    Friend WithEvents ImageButton1 As Papeleria.ImageButton
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoPaq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionPaq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiezasPaq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostoPaq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioPaq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenudeoPaq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
