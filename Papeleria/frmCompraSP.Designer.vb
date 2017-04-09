<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompraSP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompraSP))
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnMin = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtpreciomenudeo = New System.Windows.Forms.TextBox
        Me.chkmedmay = New System.Windows.Forms.RadioButton
        Me.chkmayoreo = New System.Windows.Forms.RadioButton
        Me.Label16 = New System.Windows.Forms.Label
        Me.DTPfechacompra = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtnombreproveedor = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtcodigo = New System.Windows.Forms.TextBox
        Me.txtdesc = New System.Windows.Forms.TextBox
        Me.btnbuscarprod = New System.Windows.Forms.Button
        Me.lblExistencia = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtfolio = New System.Windows.Forms.TextBox
        Me.btnvercompra = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.btnagregar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtcosto = New System.Windows.Forms.TextBox
        Me.txtdescripcionprod = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtprecio = New System.Windows.Forms.TextBox
        Me.btnbuscarproveedor = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtproveedor = New System.Windows.Forms.TextBox
        Me.DGVcompra = New System.Windows.Forms.DataGridView
        Me.txtTotal = New System.Windows.Forms.Label
        Me.txtiva = New System.Windows.Forms.Label
        Me.txtDescuento = New System.Windows.Forms.Label
        Me.txtSubtotal = New System.Windows.Forms.Label
        Me.ChkCredito = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnFinalizar = New System.Windows.Forms.Button
        Me.btnNueva = New System.Windows.Forms.Button
        Me.txtletras = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostoU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescuentoPorcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescuentoDinero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.piezas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codhermano = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MenudeoPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVcompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImage = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(932, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(37, 28)
        Me.btnClose.TabIndex = 100
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
        Me.btnMin.Location = New System.Drawing.Point(848, 12)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(37, 28)
        Me.btnMin.TabIndex = 99
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtpreciomenudeo)
        Me.GroupBox2.Controls.Add(Me.chkmedmay)
        Me.GroupBox2.Controls.Add(Me.chkmayoreo)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.DTPfechacompra)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtnombreproveedor)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtcodigo)
        Me.GroupBox2.Controls.Add(Me.txtdesc)
        Me.GroupBox2.Controls.Add(Me.btnbuscarprod)
        Me.GroupBox2.Controls.Add(Me.lblExistencia)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtcantidad)
        Me.GroupBox2.Controls.Add(Me.btnagregar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtcosto)
        Me.GroupBox2.Controls.Add(Me.txtdescripcionprod)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtprecio)
        Me.GroupBox2.Controls.Add(Me.btnbuscarproveedor)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtproveedor)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(968, 218)
        Me.GroupBox2.TabIndex = 101
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agregar Producto"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(467, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 16)
        Me.Label17.TabIndex = 128
        Me.Label17.Text = "Precio/Menudeo"
        '
        'txtpreciomenudeo
        '
        Me.txtpreciomenudeo.Location = New System.Drawing.Point(571, 150)
        Me.txtpreciomenudeo.Name = "txtpreciomenudeo"
        Me.txtpreciomenudeo.Size = New System.Drawing.Size(100, 20)
        Me.txtpreciomenudeo.TabIndex = 9
        '
        'chkmedmay
        '
        Me.chkmedmay.AutoSize = True
        Me.chkmedmay.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmedmay.Location = New System.Drawing.Point(446, 117)
        Me.chkmedmay.Name = "chkmedmay"
        Me.chkmedmay.Size = New System.Drawing.Size(99, 17)
        Me.chkmedmay.TabIndex = 6
        Me.chkmedmay.Text = "Medio mayoreo"
        Me.chkmedmay.UseVisualStyleBackColor = True
        '
        'chkmayoreo
        '
        Me.chkmayoreo.AutoSize = True
        Me.chkmayoreo.Checked = True
        Me.chkmayoreo.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmayoreo.Location = New System.Drawing.Point(370, 117)
        Me.chkmayoreo.Name = "chkmayoreo"
        Me.chkmayoreo.Size = New System.Drawing.Size(66, 17)
        Me.chkmayoreo.TabIndex = 5
        Me.chkmayoreo.TabStop = True
        Me.chkmayoreo.Text = "Mayoreo"
        Me.chkmayoreo.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(732, 158)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 16)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "Fecha de compra"
        '
        'DTPfechacompra
        '
        Me.DTPfechacompra.Location = New System.Drawing.Point(709, 181)
        Me.DTPfechacompra.Name = "DTPfechacompra"
        Me.DTPfechacompra.Size = New System.Drawing.Size(154, 20)
        Me.DTPfechacompra.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(247, 116)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(114, 16)
        Me.Label15.TabIndex = 90
        Me.Label15.Text = "Tipo de porcentaje"
        '
        'txtnombreproveedor
        '
        Me.txtnombreproveedor.BackColor = System.Drawing.Color.White
        Me.txtnombreproveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtnombreproveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtnombreproveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombreproveedor.ForeColor = System.Drawing.Color.Black
        Me.txtnombreproveedor.Location = New System.Drawing.Point(327, 30)
        Me.txtnombreproveedor.Name = "txtnombreproveedor"
        Me.txtnombreproveedor.Size = New System.Drawing.Size(344, 22)
        Me.txtnombreproveedor.TabIndex = 79
        Me.txtnombreproveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código Producto"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(396, 191)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 16)
        Me.Label13.TabIndex = 88
        Me.Label13.Text = "%"
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(125, 74)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(94, 20)
        Me.txtcodigo.TabIndex = 3
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(344, 189)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(51, 20)
        Me.txtdesc.TabIndex = 11
        '
        'btnbuscarprod
        '
        Me.btnbuscarprod.Image = CType(resources.GetObject("btnbuscarprod.Image"), System.Drawing.Image)
        Me.btnbuscarprod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbuscarprod.Location = New System.Drawing.Point(238, 64)
        Me.btnbuscarprod.Name = "btnbuscarprod"
        Me.btnbuscarprod.Size = New System.Drawing.Size(78, 41)
        Me.btnbuscarprod.TabIndex = 4
        Me.btnbuscarprod.Text = "&Buscar"
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
        Me.lblExistencia.Location = New System.Drawing.Point(125, 112)
        Me.lblExistencia.Name = "lblExistencia"
        Me.lblExistencia.Size = New System.Drawing.Size(78, 23)
        Me.lblExistencia.TabIndex = 81
        Me.lblExistencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Cantidad"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtfolio)
        Me.GroupBox1.Controls.Add(Me.btnvercompra)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(715, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(143, 106)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ver Compra"
        '
        'txtfolio
        '
        Me.txtfolio.Location = New System.Drawing.Point(18, 41)
        Me.txtfolio.Name = "txtfolio"
        Me.txtfolio.Size = New System.Drawing.Size(108, 20)
        Me.txtfolio.TabIndex = 16
        Me.txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnvercompra
        '
        Me.btnvercompra.Image = CType(resources.GetObject("btnvercompra.Image"), System.Drawing.Image)
        Me.btnvercompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnvercompra.Location = New System.Drawing.Point(42, 65)
        Me.btnvercompra.Name = "btnvercompra"
        Me.btnvercompra.Size = New System.Drawing.Size(60, 37)
        Me.btnvercompra.TabIndex = 17
        Me.btnvercompra.Text = "&Ver"
        Me.btnvercompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnvercompra.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Folio"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(264, 190)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 16)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Descuento"
        '
        'txtcantidad
        '
        Me.txtcantidad.Location = New System.Drawing.Point(125, 189)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(94, 20)
        Me.txtcantidad.TabIndex = 10
        '
        'btnagregar
        '
        Me.btnagregar.BackgroundImage = Global.Papeleria.My.Resources.Resources.agregar2
        Me.btnagregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnagregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregar.Location = New System.Drawing.Point(523, 173)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(148, 41)
        Me.btnagregar.TabIndex = 13
        Me.btnagregar.Text = "&Agregar producto"
        Me.btnagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(76, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Costo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 117)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 16)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "Existencia Actual"
        '
        'txtcosto
        '
        Me.txtcosto.Location = New System.Drawing.Point(125, 149)
        Me.txtcosto.Name = "txtcosto"
        Me.txtcosto.Size = New System.Drawing.Size(94, 20)
        Me.txtcosto.TabIndex = 7
        '
        'txtdescripcionprod
        '
        Me.txtdescripcionprod.BackColor = System.Drawing.Color.White
        Me.txtdescripcionprod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtdescripcionprod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtdescripcionprod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescripcionprod.ForeColor = System.Drawing.Color.Black
        Me.txtdescripcionprod.Location = New System.Drawing.Point(327, 73)
        Me.txtdescripcionprod.Name = "txtdescripcionprod"
        Me.txtdescripcionprod.Size = New System.Drawing.Size(344, 22)
        Me.txtdescripcionprod.TabIndex = 80
        Me.txtdescripcionprod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(243, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 16)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Precio/Mayoreo"
        '
        'txtprecio
        '
        Me.txtprecio.Location = New System.Drawing.Point(344, 149)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(100, 20)
        Me.txtprecio.TabIndex = 8
        '
        'btnbuscarproveedor
        '
        Me.btnbuscarproveedor.Image = CType(resources.GetObject("btnbuscarproveedor.Image"), System.Drawing.Image)
        Me.btnbuscarproveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbuscarproveedor.Location = New System.Drawing.Point(238, 18)
        Me.btnbuscarproveedor.Name = "btnbuscarproveedor"
        Me.btnbuscarproveedor.Size = New System.Drawing.Size(78, 42)
        Me.btnbuscarproveedor.TabIndex = 2
        Me.btnbuscarproveedor.Text = "&Buscar"
        Me.btnbuscarproveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnbuscarproveedor.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(28, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 16)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "Folio Proveedor"
        '
        'txtproveedor
        '
        Me.txtproveedor.Location = New System.Drawing.Point(125, 29)
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.Size = New System.Drawing.Size(94, 20)
        Me.txtproveedor.TabIndex = 1
        '
        'DGVcompra
        '
        Me.DGVcompra.AllowUserToAddRows = False
        Me.DGVcompra.AllowUserToDeleteRows = False
        Me.DGVcompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVcompra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.Cantidad, Me.CostoU, Me.price, Me.DescuentoPorcentaje, Me.DescuentoDinero, Me.IVA, Me.Importe, Me.idp, Me.piezas, Me.codhermano, Me.MenudeoPrecio})
        Me.DGVcompra.Location = New System.Drawing.Point(19, 297)
        Me.DGVcompra.Name = "DGVcompra"
        Me.DGVcompra.Size = New System.Drawing.Size(968, 178)
        Me.DGVcompra.TabIndex = 102
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 19.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotal.Location = New System.Drawing.Point(502, 485)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(72, 42)
        Me.txtTotal.TabIndex = 134
        Me.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txtTotal.Visible = False
        '
        'txtiva
        '
        Me.txtiva.BackColor = System.Drawing.Color.White
        Me.txtiva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtiva.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtiva.ForeColor = System.Drawing.Color.Black
        Me.txtiva.Location = New System.Drawing.Point(823, 478)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(146, 30)
        Me.txtiva.TabIndex = 133
        Me.txtiva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.White
        Me.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtDescuento.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtDescuento.Location = New System.Drawing.Point(823, 515)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(146, 30)
        Me.txtDescuento.TabIndex = 132
        Me.txtDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSubtotal
        '
        Me.txtSubtotal.BackColor = System.Drawing.Color.White
        Me.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtSubtotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtSubtotal.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubtotal.Location = New System.Drawing.Point(823, 551)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(146, 30)
        Me.txtSubtotal.TabIndex = 131
        Me.txtSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChkCredito
        '
        Me.ChkCredito.AutoSize = True
        Me.ChkCredito.BackColor = System.Drawing.Color.Transparent
        Me.ChkCredito.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCredito.Location = New System.Drawing.Point(313, 491)
        Me.ChkCredito.Name = "ChkCredito"
        Me.ChkCredito.Size = New System.Drawing.Size(84, 23)
        Me.ChkCredito.TabIndex = 14
        Me.ChkCredito.Text = "Credito"
        Me.ChkCredito.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(459, 498)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 16)
        Me.Label5.TabIndex = 129
        Me.Label5.Text = "Total"
        Me.Label5.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(763, 485)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 19)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "I.V.A."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(720, 522)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 19)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "Descuento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(732, 558)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 19)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "SubTotal"
        '
        'btnFinalizar
        '
        Me.btnFinalizar.BackgroundImage = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFinalizar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(129, 481)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(101, 43)
        Me.btnFinalizar.TabIndex = 15
        Me.btnFinalizar.Text = "&Guardar"
        Me.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'btnNueva
        '
        Me.btnNueva.BackgroundImage = Global.Papeleria.My.Resources.Resources.nuevo
        Me.btnNueva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNueva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNueva.Location = New System.Drawing.Point(34, 481)
        Me.btnNueva.Name = "btnNueva"
        Me.btnNueva.Size = New System.Drawing.Size(84, 43)
        Me.btnNueva.TabIndex = 18
        Me.btnNueva.Text = "&Nueva"
        Me.btnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNueva.UseVisualStyleBackColor = True
        '
        'txtletras
        '
        Me.txtletras.AutoSize = True
        Me.txtletras.BackColor = System.Drawing.Color.Transparent
        Me.txtletras.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtletras.ForeColor = System.Drawing.Color.Black
        Me.txtletras.Location = New System.Drawing.Point(30, 595)
        Me.txtletras.Name = "txtletras"
        Me.txtletras.Size = New System.Drawing.Size(47, 19)
        Me.txtletras.TabIndex = 125
        Me.txtletras.Text = "Total"
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 80
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 250
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 60
        '
        'CostoU
        '
        Me.CostoU.HeaderText = "Costo"
        Me.CostoU.Name = "CostoU"
        Me.CostoU.ReadOnly = True
        Me.CostoU.Width = 70
        '
        'price
        '
        Me.price.HeaderText = "Precio"
        Me.price.Name = "price"
        Me.price.Width = 70
        '
        'DescuentoPorcentaje
        '
        Me.DescuentoPorcentaje.HeaderText = "Desc %"
        Me.DescuentoPorcentaje.Name = "DescuentoPorcentaje"
        Me.DescuentoPorcentaje.ReadOnly = True
        Me.DescuentoPorcentaje.Width = 70
        '
        'DescuentoDinero
        '
        Me.DescuentoDinero.HeaderText = "Desc $"
        Me.DescuentoDinero.Name = "DescuentoDinero"
        Me.DescuentoDinero.ReadOnly = True
        Me.DescuentoDinero.Width = 75
        '
        'IVA
        '
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        Me.IVA.ReadOnly = True
        Me.IVA.Width = 70
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 90
        '
        'idp
        '
        Me.idp.HeaderText = "ID"
        Me.idp.Name = "idp"
        Me.idp.ReadOnly = True
        Me.idp.Visible = False
        '
        'piezas
        '
        Me.piezas.HeaderText = "Piezas"
        Me.piezas.Name = "piezas"
        Me.piezas.ReadOnly = True
        Me.piezas.Visible = False
        '
        'codhermano
        '
        Me.codhermano.HeaderText = "C. Hermanos"
        Me.codhermano.Name = "codhermano"
        Me.codhermano.ToolTipText = "Activa esta opcion para actualizar los productos hermanos del producto actual"
        Me.codhermano.Width = 70
        '
        'MenudeoPrecio
        '
        Me.MenudeoPrecio.HeaderText = "PrecioMenudeo"
        Me.MenudeoPrecio.Name = "MenudeoPrecio"
        Me.MenudeoPrecio.Visible = False
        '
        'frmCompraSP
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo22
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1010, 643)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtiva)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.ChkCredito)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnNueva)
        Me.Controls.Add(Me.txtletras)
        Me.Controls.Add(Me.DGVcompra)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMin)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCompraSP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGVcompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTPfechacompra As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtnombreproveedor As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtdesc As System.Windows.Forms.TextBox
    Friend WithEvents btnbuscarprod As System.Windows.Forms.Button
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtfolio As System.Windows.Forms.TextBox
    Friend WithEvents btnvercompra As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents btnagregar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtcosto As System.Windows.Forms.TextBox
    Friend WithEvents txtdescripcionprod As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents btnbuscarproveedor As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtproveedor As System.Windows.Forms.TextBox
    Friend WithEvents DGVcompra As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotal As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.Label
    Friend WithEvents txtSubtotal As System.Windows.Forms.Label
    Friend WithEvents ChkCredito As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents btnNueva As System.Windows.Forms.Button
    Friend WithEvents txtletras As System.Windows.Forms.Label
    Friend WithEvents chkmedmay As System.Windows.Forms.RadioButton
    Friend WithEvents chkmayoreo As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtpreciomenudeo As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostoU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescuentoPorcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescuentoDinero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents piezas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codhermano As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MenudeoPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
