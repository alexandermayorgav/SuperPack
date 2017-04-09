<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nueva", 3, 3)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Devoluciones", 4, 4)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Caja", 5, 5)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Abonos Crédito", 22, 22)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vales", 27, 27)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nueva", 8, 8)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Abonos", 9, 9)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Devoluciones", 24, 24)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Administrar", 16, 16)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Líneas", 26, 26)
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Promociones", 17, 17)
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Buscador", 18, 18)
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendidos Sin Existencia", 21, 21)
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traspasos")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Productos", 15, 15, New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12, TreeNode13, TreeNode14, TreeNode15, TreeNode16})
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Personal", 12, 12)
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Usuarios", 10, 10)
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes", 11, 11)
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores", 13, 13)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Códigos Hermanos", 19, 19)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Catálogos", 20, 20, New System.Windows.Forms.TreeNode() {TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22})
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas", 21, 21)
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras", 21, 21)
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cuentas por Cobrar", 21, 21)
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Faltantes de Almacén", 21, 21)
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cuentas por Pagar", 21, 21)
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventarios", 21, 21)
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Corte de Caja", 21, 21)
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Salidas Detalle", 21, 21)
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras Detalle", 21, 21)
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cotizaciones Detalle", 21, 21)
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Productos Actualizados", 21, 21)
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultas", 21, 21, New System.Windows.Forms.TreeNode() {TreeNode24, TreeNode25, TreeNode26, TreeNode27, TreeNode28, TreeNode29, TreeNode30, TreeNode31, TreeNode32, TreeNode33, TreeNode34})
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Administración de BD", 23, 23)
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuración", 14, 14)
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Manual de Ayuda", 33, 33)
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Config. y Soporte", 25, 25, New System.Windows.Forms.TreeNode() {TreeNode36, TreeNode37, TreeNode38})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.tvM = New System.Windows.Forms.TreeView
        Me.imgL = New System.Windows.Forms.ImageList(Me.components)
        Me.StripVentanas = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.StripVentanas.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvM
        '
        Me.tvM.BackColor = System.Drawing.Color.SteelBlue
        Me.tvM.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvM.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvM.ForeColor = System.Drawing.Color.White
        Me.tvM.ItemHeight = 40
        Me.tvM.LineColor = System.Drawing.Color.White
        Me.tvM.Location = New System.Drawing.Point(0, 0)
        Me.tvM.Margin = New System.Windows.Forms.Padding(15)
        Me.tvM.Name = "tvM"
        TreeNode1.ImageIndex = 3
        TreeNode1.Name = "ven,1"
        TreeNode1.SelectedImageIndex = 3
        TreeNode1.Text = "Nueva"
        TreeNode2.ImageIndex = 4
        TreeNode2.Name = "ven,2"
        TreeNode2.SelectedImageIndex = 4
        TreeNode2.Text = "Devoluciones"
        TreeNode3.ImageIndex = 5
        TreeNode3.Name = "ven,3"
        TreeNode3.SelectedImageIndex = 5
        TreeNode3.Text = "Caja"
        TreeNode4.ImageIndex = 22
        TreeNode4.Name = "ven,4"
        TreeNode4.SelectedImageIndex = 22
        TreeNode4.Text = "Abonos Crédito"
        TreeNode5.ImageIndex = 27
        TreeNode5.Name = "ven,5"
        TreeNode5.SelectedImageIndex = 27
        TreeNode5.Text = "Vales"
        TreeNode6.ImageIndex = 0
        TreeNode6.Name = "rVen"
        TreeNode6.SelectedImageIndex = 0
        TreeNode6.Text = "Ventas"
        TreeNode7.ImageIndex = 8
        TreeNode7.Name = "com,1"
        TreeNode7.SelectedImageIndex = 8
        TreeNode7.Text = "Nueva"
        TreeNode8.ImageIndex = 9
        TreeNode8.Name = "com,2"
        TreeNode8.SelectedImageIndex = 9
        TreeNode8.Text = "Abonos"
        TreeNode9.ImageIndex = 24
        TreeNode9.Name = "com,3"
        TreeNode9.SelectedImageIndex = 24
        TreeNode9.Text = "Devoluciones"
        TreeNode10.ImageIndex = 2
        TreeNode10.Name = "rComp"
        TreeNode10.SelectedImageIndex = 2
        TreeNode10.Text = "Compras"
        TreeNode11.ImageIndex = 16
        TreeNode11.Name = "pro,1"
        TreeNode11.SelectedImageIndex = 16
        TreeNode11.Text = "Administrar"
        TreeNode12.ImageIndex = 26
        TreeNode12.Name = "pro,2"
        TreeNode12.SelectedImageIndex = 26
        TreeNode12.Text = "Líneas"
        TreeNode13.ImageIndex = 17
        TreeNode13.Name = "pro,3"
        TreeNode13.SelectedImageIndex = 17
        TreeNode13.Text = "Promociones"
        TreeNode14.ImageIndex = 18
        TreeNode14.Name = "pro,4"
        TreeNode14.SelectedImageIndex = 18
        TreeNode14.Text = "Buscador"
        TreeNode15.ImageIndex = 21
        TreeNode15.Name = "pro,5"
        TreeNode15.SelectedImageIndex = 21
        TreeNode15.Text = "Vendidos Sin Existencia"
        TreeNode16.Name = "pro,6"
        TreeNode16.Text = "Traspasos"
        TreeNode17.ImageIndex = 15
        TreeNode17.Name = "rProds"
        TreeNode17.SelectedImageIndex = 15
        TreeNode17.Text = "Productos"
        TreeNode18.ImageIndex = 12
        TreeNode18.Name = "ca,1"
        TreeNode18.SelectedImageIndex = 12
        TreeNode18.Text = "Personal"
        TreeNode19.ImageIndex = 10
        TreeNode19.Name = "ca,2"
        TreeNode19.SelectedImageIndex = 10
        TreeNode19.Text = "Usuarios"
        TreeNode20.ImageIndex = 11
        TreeNode20.Name = "ca,3"
        TreeNode20.SelectedImageIndex = 11
        TreeNode20.Text = "Clientes"
        TreeNode21.ImageIndex = 13
        TreeNode21.Name = "ca,4"
        TreeNode21.SelectedImageIndex = 13
        TreeNode21.Text = "Proveedores"
        TreeNode22.ImageIndex = 19
        TreeNode22.Name = "ca,5"
        TreeNode22.SelectedImageIndex = 19
        TreeNode22.Text = "Códigos Hermanos"
        TreeNode23.ImageIndex = 20
        TreeNode23.Name = "rCat"
        TreeNode23.SelectedImageIndex = 20
        TreeNode23.Text = "Catálogos"
        TreeNode24.ImageIndex = 21
        TreeNode24.Name = "con,1"
        TreeNode24.SelectedImageIndex = 21
        TreeNode24.Text = "Ventas"
        TreeNode25.ImageIndex = 21
        TreeNode25.Name = "con,2"
        TreeNode25.SelectedImageIndex = 21
        TreeNode25.Text = "Compras"
        TreeNode26.ImageIndex = 21
        TreeNode26.Name = "con,3"
        TreeNode26.SelectedImageIndex = 21
        TreeNode26.Text = "Cuentas por Cobrar"
        TreeNode27.ImageIndex = 21
        TreeNode27.Name = "con,4"
        TreeNode27.SelectedImageIndex = 21
        TreeNode27.Text = "Faltantes de Almacén"
        TreeNode28.ImageIndex = 21
        TreeNode28.Name = "con,5"
        TreeNode28.SelectedImageIndex = 21
        TreeNode28.Text = "Cuentas por Pagar"
        TreeNode29.ImageIndex = 21
        TreeNode29.Name = "con,6"
        TreeNode29.SelectedImageIndex = 21
        TreeNode29.Text = "Inventarios"
        TreeNode30.ImageIndex = 21
        TreeNode30.Name = "con,7"
        TreeNode30.SelectedImageIndex = 21
        TreeNode30.Text = "Corte de Caja"
        TreeNode31.ImageIndex = 21
        TreeNode31.Name = "con,8"
        TreeNode31.SelectedImageIndex = 21
        TreeNode31.Text = "Salidas Detalle"
        TreeNode32.ImageIndex = 21
        TreeNode32.Name = "con,9"
        TreeNode32.SelectedImageIndex = 21
        TreeNode32.Text = "Compras Detalle"
        TreeNode33.ImageIndex = 21
        TreeNode33.Name = "con,10"
        TreeNode33.SelectedImageIndex = 21
        TreeNode33.Text = "Cotizaciones Detalle"
        TreeNode34.ImageIndex = 21
        TreeNode34.Name = "con,11"
        TreeNode34.SelectedImageIndex = 21
        TreeNode34.Text = "Productos Actualizados"
        TreeNode35.ImageIndex = 21
        TreeNode35.Name = "rRep"
        TreeNode35.SelectedImageIndex = 21
        TreeNode35.Text = "Consultas"
        TreeNode36.ImageIndex = 23
        TreeNode36.Name = "conf,1"
        TreeNode36.SelectedImageIndex = 23
        TreeNode36.Text = "Administración de BD"
        TreeNode37.ImageIndex = 14
        TreeNode37.Name = "conf,2"
        TreeNode37.SelectedImageIndex = 14
        TreeNode37.Text = "Configuración"
        TreeNode38.ImageIndex = 33
        TreeNode38.Name = "conf,4"
        TreeNode38.SelectedImageIndex = 33
        TreeNode38.Text = "Manual de Ayuda"
        TreeNode39.ImageIndex = 25
        TreeNode39.Name = "rSop"
        TreeNode39.SelectedImageIndex = 25
        TreeNode39.Text = "Config. y Soporte"
        Me.tvM.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode10, TreeNode17, TreeNode23, TreeNode35, TreeNode39})
        Me.tvM.Size = New System.Drawing.Size(210, 175)
        Me.tvM.TabIndex = 4
        '
        'imgL
        '
        Me.imgL.ImageStream = CType(resources.GetObject("imgL.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgL.TransparentColor = System.Drawing.Color.Transparent
        Me.imgL.Images.SetKeyName(0, "empty-shopping-cart.jpg")
        Me.imgL.Images.SetKeyName(1, "empty-shopping-bag.jpg")
        Me.imgL.Images.SetKeyName(2, "delivery.jpg")
        Me.imgL.Images.SetKeyName(3, "shopping-cart.jpg")
        Me.imgL.Images.SetKeyName(4, "shopcartexclude_32x32.jpg")
        Me.imgL.Images.SetKeyName(5, "cashbox.jpg")
        Me.imgL.Images.SetKeyName(6, "shopping-bag.jpg")
        Me.imgL.Images.SetKeyName(7, "shopping-bagadm.jpg")
        Me.imgL.Images.SetKeyName(8, "deliverynew.jpg")
        Me.imgL.Images.SetKeyName(9, "deliveryabs.jpg")
        Me.imgL.Images.SetKeyName(10, "Profile.jpg")
        Me.imgL.Images.SetKeyName(11, "clientes.jpg")
        Me.imgL.Images.SetKeyName(12, "personal.jpg")
        Me.imgL.Images.SetKeyName(13, "provs.jpg")
        Me.imgL.Images.SetKeyName(14, "config.jpg")
        Me.imgL.Images.SetKeyName(15, "basket.jpg")
        Me.imgL.Images.SetKeyName(16, "basketadm.jpg")
        Me.imgL.Images.SetKeyName(17, "free_gift.jpg")
        Me.imgL.Images.SetKeyName(18, "find.jpg")
        Me.imgL.Images.SetKeyName(19, "codes.jpg")
        Me.imgL.Images.SetKeyName(20, "cat.jpg")
        Me.imgL.Images.SetKeyName(21, "report.jpg")
        Me.imgL.Images.SetKeyName(22, "ab.jpg")
        Me.imgL.Images.SetKeyName(23, "Database.jpg")
        Me.imgL.Images.SetKeyName(24, "devolver_prov.jpg")
        Me.imgL.Images.SetKeyName(25, "Tool.jpg")
        Me.imgL.Images.SetKeyName(26, "Green-Cart.jpg")
        Me.imgL.Images.SetKeyName(27, "vales.JPG")
        Me.imgL.Images.SetKeyName(28, "Cabriolet-256.JPG")
        Me.imgL.Images.SetKeyName(29, "Muv-256.JPG")
        Me.imgL.Images.SetKeyName(30, "Car-256x256.JPG")
        Me.imgL.Images.SetKeyName(31, "fact.jpg")
        Me.imgL.Images.SetKeyName(32, "folios.jpg")
        Me.imgL.Images.SetKeyName(33, "ayuda.jpg")
        '
        'StripVentanas
        '
        Me.StripVentanas.Dock = System.Windows.Forms.DockStyle.Left
        Me.StripVentanas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.StripVentanas.Location = New System.Drawing.Point(210, 0)
        Me.StripVentanas.Name = "StripVentanas"
        Me.StripVentanas.Size = New System.Drawing.Size(24, 175)
        Me.StripVentanas.TabIndex = 7
        Me.StripVentanas.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(21, 44)
        Me.ToolStripButton1.Text = "Mostrar"
        Me.ToolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(21, 6)
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.Color.DimGray
        Me.Splitter2.Location = New System.Drawing.Point(234, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(5, 175)
        Me.Splitter2.TabIndex = 8
        Me.Splitter2.TabStop = False
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(409, 175)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.StripVentanas)
        Me.Controls.Add(Me.tvM)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StripVentanas.ResumeLayout(False)
        Me.StripVentanas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvM As System.Windows.Forms.TreeView
    Friend WithEvents imgL As System.Windows.Forms.ImageList
    Friend WithEvents StripVentanas As System.Windows.Forms.ToolStrip
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
