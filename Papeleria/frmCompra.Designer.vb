<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompra))
        Me.DGVcompra = New System.Windows.Forms.DataGridView
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostoU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescuentoPorcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescuentoDinero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcodigo = New System.Windows.Forms.TextBox
        Me.btnbuscarprod = New System.Windows.Forms.Button
        Me.txtfolio = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtletras = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcosto = New System.Windows.Forms.TextBox
        Me.btnFinalizar = New System.Windows.Forms.Button
        Me.btnNueva = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtprecio = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtproveedor = New System.Windows.Forms.TextBox
        Me.btnbuscarproveedor = New System.Windows.Forms.Button
        Me.txtnombreproveedor = New System.Windows.Forms.Label
        Me.txtdescripcionprod = New System.Windows.Forms.Label
        Me.lblExistencia = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnagregar = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtdesc = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnvercompra = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChkCredito = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtSubtotal = New System.Windows.Forms.Label
        Me.txtDescuento = New System.Windows.Forms.Label
        Me.txtiva = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.Label
        CType(Me.DGVcompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGVcompra
        '
        Me.DGVcompra.AllowUserToAddRows = False
        Me.DGVcompra.AllowUserToDeleteRows = False
        Me.DGVcompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVcompra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.Cantidad, Me.CostoU, Me.DescuentoPorcentaje, Me.DescuentoDinero, Me.IVA, Me.Importe})
        Me.DGVcompra.Location = New System.Drawing.Point(19, 281)
        Me.DGVcompra.Name = "DGVcompra"
        Me.DGVcompra.ReadOnly = True
        Me.DGVcompra.Size = New System.Drawing.Size(815, 156)
        Me.DGVcompra.TabIndex = 100
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
        Me.Descripcion.Width = 335
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
        Me.CostoU.HeaderText = "CostoU"
        Me.CostoU.Name = "CostoU"
        Me.CostoU.ReadOnly = True
        Me.CostoU.Width = 90
        '
        'DescuentoPorcentaje
        '
        Me.DescuentoPorcentaje.HeaderText = "Desc %"
        Me.DescuentoPorcentaje.Name = "DescuentoPorcentaje"
        Me.DescuentoPorcentaje.ReadOnly = True
        Me.DescuentoPorcentaje.Width = 75
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
        Me.IVA.Width = 80
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 90
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
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(131, 74)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(94, 20)
        Me.txtcodigo.TabIndex = 3
        '
        'btnbuscarprod
        '
        Me.btnbuscarprod.Image = CType(resources.GetObject("btnbuscarprod.Image"), System.Drawing.Image)
        Me.btnbuscarprod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbuscarprod.Location = New System.Drawing.Point(231, 64)
        Me.btnbuscarprod.Name = "btnbuscarprod"
        Me.btnbuscarprod.Size = New System.Drawing.Size(78, 41)
        Me.btnbuscarprod.TabIndex = 4
        Me.btnbuscarprod.Text = "Buscar"
        Me.btnbuscarprod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnbuscarprod.UseVisualStyleBackColor = True
        '
        'txtfolio
        '
        Me.txtfolio.Location = New System.Drawing.Point(18, 53)
        Me.txtfolio.Name = "txtfolio"
        Me.txtfolio.Size = New System.Drawing.Size(108, 20)
        Me.txtfolio.TabIndex = 10
        Me.txtfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Folio"
        '
        'txtletras
        '
        Me.txtletras.AutoSize = True
        Me.txtletras.BackColor = System.Drawing.Color.Transparent
        Me.txtletras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtletras.ForeColor = System.Drawing.Color.Black
        Me.txtletras.Location = New System.Drawing.Point(136, 569)
        Me.txtletras.Name = "txtletras"
        Me.txtletras.Size = New System.Drawing.Size(0, 20)
        Me.txtletras.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(66, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Cantidad"
        '
        'txtcantidad
        '
        Me.txtcantidad.Location = New System.Drawing.Point(131, 176)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(94, 20)
        Me.txtcantidad.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(82, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Costo"
        '
        'txtcosto
        '
        Me.txtcosto.Location = New System.Drawing.Point(131, 149)
        Me.txtcosto.Name = "txtcosto"
        Me.txtcosto.Size = New System.Drawing.Size(94, 20)
        Me.txtcosto.TabIndex = 5
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = Global.Papeleria.My.Resources.Resources.guardar1
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(114, 448)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(101, 43)
        Me.btnFinalizar.TabIndex = 13
        Me.btnFinalizar.Text = "Guardar"
        Me.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'btnNueva
        '
        Me.btnNueva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNueva.Image = Global.Papeleria.My.Resources.Resources.nuevo
        Me.btnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNueva.Location = New System.Drawing.Point(19, 448)
        Me.btnNueva.Name = "btnNueva"
        Me.btnNueva.Size = New System.Drawing.Size(84, 43)
        Me.btnNueva.TabIndex = 14
        Me.btnNueva.Text = "Nueva"
        Me.btnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNueva.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(281, 455)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "SubTotal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(269, 490)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 16)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Descuento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(299, 526)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "I.V.A."
        '
        'txtprecio
        '
        Me.txtprecio.Location = New System.Drawing.Point(311, 149)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(100, 20)
        Me.txtprecio.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(264, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 16)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Precio"
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
        Me.txtproveedor.Location = New System.Drawing.Point(131, 29)
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.Size = New System.Drawing.Size(94, 20)
        Me.txtproveedor.TabIndex = 1
        '
        'btnbuscarproveedor
        '
        Me.btnbuscarproveedor.Image = CType(resources.GetObject("btnbuscarproveedor.Image"), System.Drawing.Image)
        Me.btnbuscarproveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbuscarproveedor.Location = New System.Drawing.Point(231, 18)
        Me.btnbuscarproveedor.Name = "btnbuscarproveedor"
        Me.btnbuscarproveedor.Size = New System.Drawing.Size(78, 42)
        Me.btnbuscarproveedor.TabIndex = 2
        Me.btnbuscarproveedor.Text = "Buscar"
        Me.btnbuscarproveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnbuscarproveedor.UseVisualStyleBackColor = True
        '
        'txtnombreproveedor
        '
        Me.txtnombreproveedor.BackColor = System.Drawing.Color.White
        Me.txtnombreproveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtnombreproveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtnombreproveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombreproveedor.ForeColor = System.Drawing.Color.Black
        Me.txtnombreproveedor.Location = New System.Drawing.Point(314, 30)
        Me.txtnombreproveedor.Name = "txtnombreproveedor"
        Me.txtnombreproveedor.Size = New System.Drawing.Size(309, 22)
        Me.txtnombreproveedor.TabIndex = 79
        Me.txtnombreproveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtdescripcionprod
        '
        Me.txtdescripcionprod.BackColor = System.Drawing.Color.White
        Me.txtdescripcionprod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtdescripcionprod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtdescripcionprod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescripcionprod.ForeColor = System.Drawing.Color.Black
        Me.txtdescripcionprod.Location = New System.Drawing.Point(314, 71)
        Me.txtdescripcionprod.Name = "txtdescripcionprod"
        Me.txtdescripcionprod.Size = New System.Drawing.Size(309, 22)
        Me.txtdescripcionprod.TabIndex = 80
        Me.txtdescripcionprod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExistencia
        '
        Me.lblExistencia.BackColor = System.Drawing.Color.White
        Me.lblExistencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblExistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia.ForeColor = System.Drawing.Color.Black
        Me.lblExistencia.Location = New System.Drawing.Point(131, 112)
        Me.lblExistencia.Name = "lblExistencia"
        Me.lblExistencia.Size = New System.Drawing.Size(77, 23)
        Me.lblExistencia.TabIndex = 81
        Me.lblExistencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 117)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 16)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "Existencia Actual"
        '
        'btnagregar
        '
        Me.btnagregar.Image = Global.Papeleria.My.Resources.Resources.agregar3
        Me.btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregar.Location = New System.Drawing.Point(426, 149)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(132, 41)
        Me.btnagregar.TabIndex = 9
        Me.btnagregar.Text = "Agregar producto"
        Me.btnagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(239, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 16)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Descuento"
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(311, 176)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(51, 20)
        Me.txtdesc.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(363, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 16)
        Me.Label13.TabIndex = 88
        Me.Label13.Text = "%"
        '
        'btnvercompra
        '
        Me.btnvercompra.Image = CType(resources.GetObject("btnvercompra.Image"), System.Drawing.Image)
        Me.btnvercompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnvercompra.Location = New System.Drawing.Point(42, 77)
        Me.btnvercompra.Name = "btnvercompra"
        Me.btnvercompra.Size = New System.Drawing.Size(60, 37)
        Me.btnvercompra.TabIndex = 11
        Me.btnvercompra.Text = "Ver"
        Me.btnvercompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnvercompra.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtfolio)
        Me.GroupBox1.Controls.Add(Me.btnvercompra)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(657, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(143, 141)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ver Compra"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
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
        Me.GroupBox2.Size = New System.Drawing.Size(815, 202)
        Me.GroupBox2.TabIndex = 90
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agregar Producto"
        '
        'ChkCredito
        '
        Me.ChkCredito.AutoSize = True
        Me.ChkCredito.BackColor = System.Drawing.Color.Transparent
        Me.ChkCredito.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCredito.Location = New System.Drawing.Point(116, 507)
        Me.ChkCredito.Name = "ChkCredito"
        Me.ChkCredito.Size = New System.Drawing.Size(68, 20)
        Me.ChkCredito.TabIndex = 12
        Me.ChkCredito.Text = "Crédito"
        Me.ChkCredito.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(597, 490)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 16)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Total"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(27, 571)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 16)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Cantidad con letra:"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(719, 16)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(25, 25)
        Me.btnMin.TabIndex = 97
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
        Me.btnClose.Location = New System.Drawing.Point(803, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 98
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtSubtotal
        '
        Me.txtSubtotal.BackColor = System.Drawing.Color.White
        Me.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtSubtotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtSubtotal.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubtotal.Location = New System.Drawing.Point(345, 451)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(146, 30)
        Me.txtSubtotal.TabIndex = 118
        Me.txtSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.White
        Me.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtDescuento.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtDescuento.Location = New System.Drawing.Point(345, 486)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(146, 30)
        Me.txtDescuento.TabIndex = 119
        Me.txtDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtiva
        '
        Me.txtiva.BackColor = System.Drawing.Color.White
        Me.txtiva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtiva.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtiva.ForeColor = System.Drawing.Color.Black
        Me.txtiva.Location = New System.Drawing.Point(345, 521)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(146, 30)
        Me.txtiva.TabIndex = 120
        Me.txtiva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 19.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotal.Location = New System.Drawing.Point(640, 477)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(180, 42)
        Me.txtTotal.TabIndex = 121
        Me.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(856, 620)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtiva)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.ChkCredito)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnNueva)
        Me.Controls.Add(Me.txtletras)
        Me.Controls.Add(Me.DGVcompra)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras"
        CType(Me.DGVcompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGVcompra As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnbuscarprod As System.Windows.Forms.Button
    Friend WithEvents txtfolio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtletras As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcosto As System.Windows.Forms.TextBox
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents btnNueva As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtproveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnbuscarproveedor As System.Windows.Forms.Button
    Friend WithEvents txtnombreproveedor As System.Windows.Forms.Label
    Friend WithEvents txtdescripcionprod As System.Windows.Forms.Label
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnagregar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnvercompra As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ChkCredito As System.Windows.Forms.CheckBox
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostoU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescuentoPorcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescuentoDinero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtSubtotal As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.Label
End Class
