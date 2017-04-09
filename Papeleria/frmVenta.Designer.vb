<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVenta
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFolio = New System.Windows.Forms.TextBox
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSubtotal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDescuento = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.dgvp = New System.Windows.Forms.DataGridView
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFolioCliente = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblProducto = New System.Windows.Forms.Label
        Me.lblPrecio = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.lbl2 = New System.Windows.Forms.Label
        Me.lblRango = New System.Windows.Forms.Label
        Me.lblExistencia = New System.Windows.Forms.Label
        Me.lbl1 = New System.Windows.Forms.Label
        Me.lbl3 = New System.Windows.Forms.Label
        Me.chkConsultar = New System.Windows.Forms.CheckBox
        Me.lbl4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblDescProd = New System.Windows.Forms.Label
        Me.btnMax = New System.Windows.Forms.Button
        Me.imagen = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chkMenudeo = New System.Windows.Forms.CheckBox
        Me.btnObtenerCotizacion = New Papeleria.ImageButton
        Me.btnCancelarDesc = New Papeleria.ImageButton
        Me.btnAplicarDesc = New Papeleria.ImageButton
        Me.btnBuscaProducto = New Papeleria.ImageButton
        Me.btnAgregar = New Papeleria.ImageButton
        Me.btnBuscacliente = New Papeleria.ImageButton
        Me.btnNuevo = New Papeleria.ImageButton
        Me.btnCredito = New Papeleria.ImageButton
        Me.btnCotizacion = New Papeleria.ImageButton
        Me.btnGuardar = New Papeleria.ImageButton
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescuentoPor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescuentoDin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Existencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtFolio
        '
        Me.txtFolio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(120, 72)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(100, 22)
        Me.txtFolio.TabIndex = 1
        '
        'dtp
        '
        Me.dtp.Enabled = False
        Me.dtp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp.Location = New System.Drawing.Point(582, 75)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(234, 22)
        Me.dtp.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(525, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha"
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(296, 110)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(367, 22)
        Me.txtCliente.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(242, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cliente"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(649, 484)
        Me.txtSubtotal.Multiline = True
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(166, 35)
        Me.txtSubtotal.TabIndex = 9
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(584, 488)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 22)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Total"
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.Location = New System.Drawing.Point(148, 449)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(55, 22)
        Me.txtDescuento.TabIndex = 11
        Me.txtDescuento.Text = "0"
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 452)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Aplicar Descuento"
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(649, 443)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.Size = New System.Drawing.Size(167, 35)
        Me.txtDesc.TabIndex = 13
        Me.txtDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(534, 447)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 22)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Descuento"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(21, 520)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 22)
        Me.lblTotal.TabIndex = 16
        Me.lblTotal.Text = "Total"
        '
        'dgvp
        '
        Me.dgvp.AllowUserToAddRows = False
        Me.dgvp.AllowUserToDeleteRows = False
        Me.dgvp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Codigo, Me.Descripcion, Me.Cantidad, Me.Precio, Me.iva, Me.DescuentoPor, Me.DescuentoDin, Me.Total, Me.Existencia})
        Me.dgvp.Location = New System.Drawing.Point(21, 238)
        Me.dgvp.Name = "dgvp"
        Me.dgvp.Size = New System.Drawing.Size(795, 199)
        Me.dgvp.TabIndex = 17
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(282, 206)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(128, 22)
        Me.txtCodigo.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(190, 209)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 16)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Código/Clave"
        '
        'txtFolioCliente
        '
        Me.txtFolioCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolioCliente.Location = New System.Drawing.Point(120, 110)
        Me.txtFolioCliente.Name = "txtFolioCliente"
        Me.txtFolioCliente.Size = New System.Drawing.Size(100, 22)
        Me.txtFolioCliente.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(20, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 16)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Folio Cliente"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.BackColor = System.Drawing.Color.Transparent
        Me.lblProducto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(22, 177)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(65, 16)
        Me.lblProducto.TabIndex = 30
        Me.lblProducto.Text = "Producto"
        Me.lblProducto.Visible = False
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.BackColor = System.Drawing.Color.Transparent
        Me.lblPrecio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(620, 209)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(15, 16)
        Me.lblPrecio.TabIndex = 31
        Me.lblPrecio.Text = "0"
        Me.lblPrecio.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(22, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 16)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(92, 206)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(75, 22)
        Me.txtCantidad.TabIndex = 7
        Me.txtCantidad.Text = "1"
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.BackColor = System.Drawing.Color.Transparent
        Me.lbl2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.Location = New System.Drawing.Point(446, 209)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(70, 16)
        Me.lbl2.TabIndex = 32
        Me.lbl2.Text = "Descuento"
        Me.lbl2.Visible = False
        '
        'lblRango
        '
        Me.lblRango.AutoSize = True
        Me.lblRango.BackColor = System.Drawing.Color.Transparent
        Me.lblRango.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRango.Location = New System.Drawing.Point(620, 177)
        Me.lblRango.Name = "lblRango"
        Me.lblRango.Size = New System.Drawing.Size(15, 16)
        Me.lblRango.TabIndex = 34
        Me.lblRango.Text = "0"
        Me.lblRango.Visible = False
        '
        'lblExistencia
        '
        Me.lblExistencia.AutoSize = True
        Me.lblExistencia.BackColor = System.Drawing.Color.Transparent
        Me.lblExistencia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia.Location = New System.Drawing.Point(519, 177)
        Me.lblExistencia.Name = "lblExistencia"
        Me.lblExistencia.Size = New System.Drawing.Size(15, 16)
        Me.lblExistencia.TabIndex = 35
        Me.lblExistencia.Text = "0"
        Me.lblExistencia.Visible = False
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(447, 177)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(69, 16)
        Me.lbl1.TabIndex = 36
        Me.lbl1.Text = "Existencia"
        Me.lbl1.Visible = False
        '
        'lbl3
        '
        Me.lbl3.AutoSize = True
        Me.lbl3.BackColor = System.Drawing.Color.Transparent
        Me.lbl3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3.Location = New System.Drawing.Point(569, 177)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(45, 16)
        Me.lbl3.TabIndex = 37
        Me.lbl3.Text = "Rango" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbl3.Visible = False
        '
        'chkConsultar
        '
        Me.chkConsultar.AutoSize = True
        Me.chkConsultar.BackColor = System.Drawing.Color.Transparent
        Me.chkConsultar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConsultar.Location = New System.Drawing.Point(22, 150)
        Me.chkConsultar.Name = "chkConsultar"
        Me.chkConsultar.Size = New System.Drawing.Size(142, 20)
        Me.chkConsultar.TabIndex = 5
        Me.chkConsultar.Text = "Consultar Producto "
        Me.chkConsultar.UseVisualStyleBackColor = False
        '
        'lbl4
        '
        Me.lbl4.AutoSize = True
        Me.lbl4.BackColor = System.Drawing.Color.Transparent
        Me.lbl4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4.Location = New System.Drawing.Point(569, 209)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(45, 16)
        Me.lbl4.TabIndex = 38
        Me.lbl4.Text = "Precio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbl4.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(205, 452)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 16)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "%"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(700, 11)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(30, 30)
        Me.btnMin.TabIndex = 44
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
        Me.btnClose.Location = New System.Drawing.Point(790, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnClose.Size = New System.Drawing.Size(30, 30)
        Me.btnClose.TabIndex = 43
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblDescProd
        '
        Me.lblDescProd.AutoSize = True
        Me.lblDescProd.BackColor = System.Drawing.Color.Transparent
        Me.lblDescProd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescProd.Location = New System.Drawing.Point(519, 209)
        Me.lblDescProd.Name = "lblDescProd"
        Me.lblDescProd.Size = New System.Drawing.Size(15, 16)
        Me.lblDescProd.TabIndex = 45
        Me.lblDescProd.Text = "0"
        Me.lblDescProd.Visible = False
        '
        'btnMax
        '
        Me.btnMax.BackColor = System.Drawing.Color.Transparent
        Me.btnMax.BackgroundImage = Global.Papeleria.My.Resources.Resources.agregar
        Me.btnMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMax.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMax.FlatAppearance.BorderSize = 0
        Me.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMax.Location = New System.Drawing.Point(745, 11)
        Me.btnMax.Name = "btnMax"
        Me.btnMax.Size = New System.Drawing.Size(30, 30)
        Me.btnMax.TabIndex = 47
        Me.btnMax.UseVisualStyleBackColor = False
        '
        'imagen
        '
        Me.imagen.BackColor = System.Drawing.Color.Transparent
        Me.imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imagen.Location = New System.Drawing.Point(823, 70)
        Me.imagen.Name = "imagen"
        Me.imagen.Size = New System.Drawing.Size(350, 159)
        Me.imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imagen.TabIndex = 49
        Me.imagen.TabStop = False
        Me.imagen.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Location = New System.Drawing.Point(823, 238)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(380, 199)
        Me.Panel1.TabIndex = 52
        Me.Panel1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 22)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Label4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(2, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(170, 22)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "En la Compra de:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(35, 154)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 24)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Label13"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(9, 154)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 24)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "lbl"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(33, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 24)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "lbl"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(9, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "lbl"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(36, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 24)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Label1"
        '
        'Timer1
        '
        '
        'chkMenudeo
        '
        Me.chkMenudeo.AutoSize = True
        Me.chkMenudeo.BackColor = System.Drawing.Color.Transparent
        Me.chkMenudeo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMenudeo.Location = New System.Drawing.Point(22, 577)
        Me.chkMenudeo.Name = "chkMenudeo"
        Me.chkMenudeo.Size = New System.Drawing.Size(141, 20)
        Me.chkMenudeo.TabIndex = 53
        Me.chkMenudeo.Text = "Imprimir $ Menudeo"
        Me.chkMenudeo.UseVisualStyleBackColor = False
        '
        'btnObtenerCotizacion
        '
        Me.btnObtenerCotizacion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnObtenerCotizacion.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnObtenerCotizacion.ButtonImage = Nothing
        Me.btnObtenerCotizacion.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnObtenerCotizacion.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnObtenerCotizacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnObtenerCotizacion.Image = Global.Papeleria.My.Resources.Resources.leer
        Me.btnObtenerCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnObtenerCotizacion.Location = New System.Drawing.Point(245, 69)
        Me.btnObtenerCotizacion.Name = "btnObtenerCotizacion"
        Me.btnObtenerCotizacion.Size = New System.Drawing.Size(154, 37)
        Me.btnObtenerCotizacion.TabIndex = 2
        Me.btnObtenerCotizacion.Text = "Traer Cotizacion"
        Me.btnObtenerCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtenerCotizacion.UseVisualStyleBackColor = True
        '
        'btnCancelarDesc
        '
        Me.btnCancelarDesc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCancelarDesc.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnCancelarDesc.ButtonImage = Nothing
        Me.btnCancelarDesc.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnCancelarDesc.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnCancelarDesc.Enabled = False
        Me.btnCancelarDesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarDesc.Image = Global.Papeleria.My.Resources.Resources.cancelar
        Me.btnCancelarDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelarDesc.Location = New System.Drawing.Point(360, 440)
        Me.btnCancelarDesc.Name = "btnCancelarDesc"
        Me.btnCancelarDesc.Size = New System.Drawing.Size(136, 40)
        Me.btnCancelarDesc.TabIndex = 12
        Me.btnCancelarDesc.Text = "Cancelar Desct."
        Me.btnCancelarDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelarDesc.UseVisualStyleBackColor = True
        '
        'btnAplicarDesc
        '
        Me.btnAplicarDesc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAplicarDesc.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnAplicarDesc.ButtonImage = Nothing
        Me.btnAplicarDesc.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnAplicarDesc.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnAplicarDesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarDesc.Image = Global.Papeleria.My.Resources.Resources.va
        Me.btnAplicarDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAplicarDesc.Location = New System.Drawing.Point(224, 440)
        Me.btnAplicarDesc.Name = "btnAplicarDesc"
        Me.btnAplicarDesc.Size = New System.Drawing.Size(125, 40)
        Me.btnAplicarDesc.TabIndex = 46
        Me.btnAplicarDesc.Text = "Aplicar Desct."
        Me.btnAplicarDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAplicarDesc.UseVisualStyleBackColor = True
        '
        'btnBuscaProducto
        '
        Me.btnBuscaProducto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBuscaProducto.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnBuscaProducto.ButtonImage = Nothing
        Me.btnBuscaProducto.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnBuscaProducto.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnBuscaProducto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaProducto.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnBuscaProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscaProducto.Location = New System.Drawing.Point(669, 148)
        Me.btnBuscaProducto.Name = "btnBuscaProducto"
        Me.btnBuscaProducto.Size = New System.Drawing.Size(148, 36)
        Me.btnBuscaProducto.TabIndex = 6
        Me.btnBuscaProducto.Text = "Buscar Producto"
        Me.btnBuscaProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscaProducto.UseVisualStyleBackColor = True
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
        Me.btnAgregar.Location = New System.Drawing.Point(709, 193)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 36)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBuscacliente
        '
        Me.btnBuscacliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBuscacliente.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnBuscacliente.ButtonImage = Nothing
        Me.btnBuscacliente.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnBuscacliente.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnBuscacliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscacliente.Image = Global.Papeleria.My.Resources.Resources.clientes
        Me.btnBuscacliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscacliente.Location = New System.Drawing.Point(669, 103)
        Me.btnBuscacliente.Name = "btnBuscacliente"
        Me.btnBuscacliente.Size = New System.Drawing.Size(148, 36)
        Me.btnBuscacliente.TabIndex = 4
        Me.btnBuscacliente.Text = "Buscar Cliente"
        Me.btnBuscacliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscacliente.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnNuevo.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnNuevo.ButtonImage = Nothing
        Me.btnNuevo.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnNuevo.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnNuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.Papeleria.My.Resources.Resources.nuevo
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(282, 554)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(87, 36)
        Me.btnNuevo.TabIndex = 16
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnCredito
        '
        Me.btnCredito.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCredito.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnCredito.ButtonImage = Nothing
        Me.btnCredito.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnCredito.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnCredito.Enabled = False
        Me.btnCredito.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCredito.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCredito.Location = New System.Drawing.Point(595, 554)
        Me.btnCredito.Name = "btnCredito"
        Me.btnCredito.Size = New System.Drawing.Size(94, 36)
        Me.btnCredito.TabIndex = 14
        Me.btnCredito.Text = "Crédito"
        Me.btnCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCredito.UseVisualStyleBackColor = True
        '
        'btnCotizacion
        '
        Me.btnCotizacion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCotizacion.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnCotizacion.ButtonImage = Nothing
        Me.btnCotizacion.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnCotizacion.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnCotizacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCotizacion.Image = Global.Papeleria.My.Resources.Resources.imprimir
        Me.btnCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCotizacion.Location = New System.Drawing.Point(401, 554)
        Me.btnCotizacion.Name = "btnCotizacion"
        Me.btnCotizacion.Size = New System.Drawing.Size(164, 36)
        Me.btnCotizacion.TabIndex = 15
        Me.btnCotizacion.Text = "Imprimir Cotizacion"
        Me.btnCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCotizacion.UseVisualStyleBackColor = True
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
        Me.btnGuardar.Location = New System.Drawing.Point(722, 554)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(93, 36)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'ID
        '
        Me.ID.Frozen = True
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Codigo
        '
        Me.Codigo.Frozen = True
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.Frozen = True
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.Frozen = True
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'Precio
        '
        Me.Precio.Frozen = True
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        '
        'iva
        '
        Me.iva.Frozen = True
        Me.iva.HeaderText = "I.V.A."
        Me.iva.Name = "iva"
        Me.iva.ReadOnly = True
        Me.iva.Visible = False
        '
        'DescuentoPor
        '
        Me.DescuentoPor.Frozen = True
        Me.DescuentoPor.HeaderText = "Descuento %"
        Me.DescuentoPor.Name = "DescuentoPor"
        Me.DescuentoPor.ReadOnly = True
        '
        'DescuentoDin
        '
        Me.DescuentoDin.Frozen = True
        Me.DescuentoDin.HeaderText = "Descuento $"
        Me.DescuentoDin.Name = "DescuentoDin"
        '
        'Total
        '
        Me.Total.Frozen = True
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'Existencia
        '
        Me.Existencia.Frozen = True
        Me.Existencia.HeaderText = "Existencia"
        Me.Existencia.Name = "Existencia"
        Me.Existencia.ReadOnly = True
        Me.Existencia.Visible = False
        '
        'frmVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(842, 616)
        Me.Controls.Add(Me.chkMenudeo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.imagen)
        Me.Controls.Add(Me.btnMax)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.lblRango)
        Me.Controls.Add(Me.lbl4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblExistencia)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.btnObtenerCotizacion)
        Me.Controls.Add(Me.lbl3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.btnCancelarDesc)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnAplicarDesc)
        Me.Controls.Add(Me.btnBuscaProducto)
        Me.Controls.Add(Me.lblDescProd)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dgvp)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnBuscacliente)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtFolioCliente)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.chkConsultar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCredito)
        Me.Controls.Add(Me.btnCotizacion)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label5)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Venta"
        CType(Me.dgvp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents dgvp As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscacliente As Papeleria.ImageButton
    Friend WithEvents btnNuevo As Papeleria.ImageButton
    Friend WithEvents btnGuardar As Papeleria.ImageButton
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaProducto As Papeleria.ImageButton
    Friend WithEvents txtFolioCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lblRango As System.Windows.Forms.Label
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents btnCancelarDesc As Papeleria.ImageButton
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents chkConsultar As System.Windows.Forms.CheckBox
    Friend WithEvents btnCotizacion As Papeleria.ImageButton
    Friend WithEvents btnObtenerCotizacion As Papeleria.ImageButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCredito As Papeleria.ImageButton
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblDescProd As System.Windows.Forms.Label
    Friend WithEvents btnAplicarDesc As Papeleria.ImageButton
    Friend WithEvents btnMax As System.Windows.Forms.Button
    Friend WithEvents imagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnAgregar As Papeleria.ImageButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkMenudeo As System.Windows.Forms.CheckBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescuentoPor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescuentoDin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Existencia As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
