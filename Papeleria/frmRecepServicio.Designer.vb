<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecepServicio
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
        Me.gp1 = New System.Windows.Forms.GroupBox
        Me.btnBuscarC = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnObtenerC = New System.Windows.Forms.Button
        Me.txtFolioC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gp2 = New System.Windows.Forms.GroupBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.txtKm = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPlacas = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtColor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtMod = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTipo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLin = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtConc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbcntrl = New System.Windows.Forms.TabControl
        Me.tp1 = New System.Windows.Forms.TabPage
        Me.lblTitFechaE = New System.Windows.Forms.Label
        Me.lblFechaEnt = New System.Windows.Forms.Label
        Me.lblFactura = New System.Windows.Forms.Label
        Me.lblservcomp = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSXC = New System.Windows.Forms.Button
        Me.btnObtener = New System.Windows.Forms.Button
        Me.txtFolioS = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnMec = New System.Windows.Forms.Button
        Me.btnPers = New System.Windows.Forms.Button
        Me.txtMec = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtRec = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtpS = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.btnPaso1 = New System.Windows.Forms.Button
        Me.tp2 = New System.Windows.Forms.TabPage
        Me.gp4 = New System.Windows.Forms.GroupBox
        Me.lblTotal = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.btnAgregarRef = New Papeleria.ImageButton
        Me.btnProcServ = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnBuscarServicios = New Papeleria.ImageButton
        Me.dgvRefsF = New System.Windows.Forms.DataGridView
        Me.dgvServ = New System.Windows.Forms.DataGridView
        Me.Label13 = New System.Windows.Forms.Label
        Me.dgvRefs = New System.Windows.Forms.DataGridView
        Me.gp3 = New System.Windows.Forms.GroupBox
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.txtDiag = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.gp1.SuspendLayout()
        Me.gp2.SuspendLayout()
        Me.tbcntrl.SuspendLayout()
        Me.tp1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tp2.SuspendLayout()
        Me.gp4.SuspendLayout()
        CType(Me.dgvRefsF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvServ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRefs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gp3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gp1
        '
        Me.gp1.Controls.Add(Me.btnBuscarC)
        Me.gp1.Controls.Add(Me.txtCliente)
        Me.gp1.Controls.Add(Me.Label2)
        Me.gp1.Controls.Add(Me.btnObtenerC)
        Me.gp1.Controls.Add(Me.txtFolioC)
        Me.gp1.Controls.Add(Me.Label1)
        Me.gp1.Location = New System.Drawing.Point(16, 7)
        Me.gp1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gp1.Name = "gp1"
        Me.gp1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gp1.Size = New System.Drawing.Size(590, 118)
        Me.gp1.TabIndex = 0
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
        'gp2
        '
        Me.gp2.Controls.Add(Me.btnBuscar)
        Me.gp2.Controls.Add(Me.txtKm)
        Me.gp2.Controls.Add(Me.Label9)
        Me.gp2.Controls.Add(Me.txtPlacas)
        Me.gp2.Controls.Add(Me.Label8)
        Me.gp2.Controls.Add(Me.txtColor)
        Me.gp2.Controls.Add(Me.Label7)
        Me.gp2.Controls.Add(Me.txtMod)
        Me.gp2.Controls.Add(Me.Label6)
        Me.gp2.Controls.Add(Me.txtTipo)
        Me.gp2.Controls.Add(Me.Label5)
        Me.gp2.Controls.Add(Me.txtLin)
        Me.gp2.Controls.Add(Me.Label4)
        Me.gp2.Controls.Add(Me.txtConc)
        Me.gp2.Controls.Add(Me.Label3)
        Me.gp2.Location = New System.Drawing.Point(16, 132)
        Me.gp2.Name = "gp2"
        Me.gp2.Size = New System.Drawing.Size(590, 180)
        Me.gp2.TabIndex = 1
        Me.gp2.TabStop = False
        Me.gp2.Text = "Datos Vehiculo"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(377, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(165, 36)
        Me.btnBuscar.TabIndex = 11
        Me.btnBuscar.Text = "&B&uscar en historial"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtKm
        '
        Me.txtKm.Location = New System.Drawing.Point(124, 131)
        Me.txtKm.Name = "txtKm"
        Me.txtKm.Size = New System.Drawing.Size(175, 22)
        Me.txtKm.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(41, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Kilometraje:"
        '
        'txtPlacas
        '
        Me.txtPlacas.Location = New System.Drawing.Point(367, 133)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.Size = New System.Drawing.Size(175, 22)
        Me.txtPlacas.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(309, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Placas:"
        '
        'txtColor
        '
        Me.txtColor.Location = New System.Drawing.Point(124, 100)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(175, 22)
        Me.txtColor.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(76, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Color:"
        '
        'txtMod
        '
        Me.txtMod.Location = New System.Drawing.Point(367, 98)
        Me.txtMod.Name = "txtMod"
        Me.txtMod.Size = New System.Drawing.Size(175, 22)
        Me.txtMod.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(307, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Modelo:"
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(124, 65)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(175, 22)
        Me.txtTipo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(82, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tipo:"
        '
        'txtLin
        '
        Me.txtLin.Location = New System.Drawing.Point(367, 62)
        Me.txtLin.Name = "txtLin"
        Me.txtLin.Size = New System.Drawing.Size(175, 22)
        Me.txtLin.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(318, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Linea:"
        '
        'txtConc
        '
        Me.txtConc.Location = New System.Drawing.Point(124, 29)
        Me.txtConc.Name = "txtConc"
        Me.txtConc.Size = New System.Drawing.Size(175, 22)
        Me.txtConc.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Concecionaria:"
        '
        'tbcntrl
        '
        Me.tbcntrl.Controls.Add(Me.tp1)
        Me.tbcntrl.Controls.Add(Me.tp2)
        Me.tbcntrl.Location = New System.Drawing.Point(18, 68)
        Me.tbcntrl.Name = "tbcntrl"
        Me.tbcntrl.SelectedIndex = 0
        Me.tbcntrl.Size = New System.Drawing.Size(802, 496)
        Me.tbcntrl.TabIndex = 2
        '
        'tp1
        '
        Me.tp1.Controls.Add(Me.lblTitFechaE)
        Me.tp1.Controls.Add(Me.lblFechaEnt)
        Me.tp1.Controls.Add(Me.lblFactura)
        Me.tp1.Controls.Add(Me.lblservcomp)
        Me.tp1.Controls.Add(Me.GroupBox2)
        Me.tp1.Controls.Add(Me.btnNuevo)
        Me.tp1.Controls.Add(Me.GroupBox1)
        Me.tp1.Controls.Add(Me.btnPaso1)
        Me.tp1.Controls.Add(Me.gp1)
        Me.tp1.Controls.Add(Me.gp2)
        Me.tp1.Location = New System.Drawing.Point(4, 22)
        Me.tp1.Name = "tp1"
        Me.tp1.Padding = New System.Windows.Forms.Padding(3)
        Me.tp1.Size = New System.Drawing.Size(794, 470)
        Me.tp1.TabIndex = 0
        Me.tp1.Text = "Paso 1"
        Me.tp1.UseVisualStyleBackColor = True
        '
        'lblTitFechaE
        '
        Me.lblTitFechaE.AutoSize = True
        Me.lblTitFechaE.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitFechaE.Location = New System.Drawing.Point(646, 230)
        Me.lblTitFechaE.Name = "lblTitFechaE"
        Me.lblTitFechaE.Size = New System.Drawing.Size(115, 18)
        Me.lblTitFechaE.TabIndex = 32
        Me.lblTitFechaE.Text = "Fecha Entrega:"
        Me.lblTitFechaE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTitFechaE.Visible = False
        '
        'lblFechaEnt
        '
        Me.lblFechaEnt.AutoSize = True
        Me.lblFechaEnt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEnt.Location = New System.Drawing.Point(616, 263)
        Me.lblFechaEnt.Name = "lblFechaEnt"
        Me.lblFechaEnt.Size = New System.Drawing.Size(0, 18)
        Me.lblFechaEnt.TabIndex = 31
        Me.lblFechaEnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFactura
        '
        Me.lblFactura.AutoSize = True
        Me.lblFactura.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactura.Location = New System.Drawing.Point(654, 194)
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Size = New System.Drawing.Size(0, 19)
        Me.lblFactura.TabIndex = 30
        Me.lblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblservcomp
        '
        Me.lblservcomp.AutoSize = True
        Me.lblservcomp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblservcomp.Location = New System.Drawing.Point(622, 147)
        Me.lblservcomp.Name = "lblservcomp"
        Me.lblservcomp.Size = New System.Drawing.Size(0, 19)
        Me.lblservcomp.TabIndex = 29
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSXC)
        Me.GroupBox2.Controls.Add(Me.btnObtener)
        Me.GroupBox2.Controls.Add(Me.txtFolioS)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Location = New System.Drawing.Point(612, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(176, 118)
        Me.GroupBox2.TabIndex = 21
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
        Me.btnSXC.TabIndex = 3
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
        Me.btnObtener.TabIndex = 2
        Me.btnObtener.Text = "Ob&tener"
        Me.btnObtener.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtener.UseVisualStyleBackColor = True
        '
        'txtFolioS
        '
        Me.txtFolioS.Location = New System.Drawing.Point(58, 21)
        Me.txtFolioS.Name = "txtFolioS"
        Me.txtFolioS.Size = New System.Drawing.Size(100, 22)
        Me.txtFolioS.TabIndex = 1
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
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.Papeleria.My.Resources.Resources.nuevo
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(621, 360)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(109, 36)
        Me.btnNuevo.TabIndex = 20
        Me.btnNuevo.Text = "&Nuevo   "
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMec)
        Me.GroupBox1.Controls.Add(Me.btnPers)
        Me.GroupBox1.Controls.Add(Me.txtMec)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtRec)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtpS)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 318)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(590, 133)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Recepción"
        '
        'btnMec
        '
        Me.btnMec.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMec.Image = Global.Papeleria.My.Resources.Resources.find
        Me.btnMec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMec.Location = New System.Drawing.Point(407, 88)
        Me.btnMec.Name = "btnMec"
        Me.btnMec.Size = New System.Drawing.Size(160, 36)
        Me.btnMec.TabIndex = 17
        Me.btnMec.Text = "Busc&ar mecanico"
        Me.btnMec.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMec.UseVisualStyleBackColor = True
        '
        'btnPers
        '
        Me.btnPers.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPers.Image = Global.Papeleria.My.Resources.Resources.find
        Me.btnPers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPers.Location = New System.Drawing.Point(407, 42)
        Me.btnPers.Name = "btnPers"
        Me.btnPers.Size = New System.Drawing.Size(160, 36)
        Me.btnPers.TabIndex = 6
        Me.btnPers.Text = "Bu&scar personal"
        Me.btnPers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPers.UseVisualStyleBackColor = True
        '
        'txtMec
        '
        Me.txtMec.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtMec.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMec.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtMec.Location = New System.Drawing.Point(124, 95)
        Me.txtMec.Name = "txtMec"
        Me.txtMec.ReadOnly = True
        Me.txtMec.Size = New System.Drawing.Size(277, 22)
        Me.txtMec.TabIndex = 15
        Me.txtMec.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(50, 98)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 16)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Mecanico:"
        '
        'txtRec
        '
        Me.txtRec.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRec.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRec.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtRec.Location = New System.Drawing.Point(124, 55)
        Me.txtRec.Name = "txtRec"
        Me.txtRec.ReadOnly = True
        Me.txtRec.Size = New System.Drawing.Size(277, 22)
        Me.txtRec.TabIndex = 7
        Me.txtRec.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(63, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 16)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Recibió:"
        '
        'dtpS
        '
        Me.dtpS.Location = New System.Drawing.Point(338, 14)
        Me.dtpS.Name = "dtpS"
        Me.dtpS.Size = New System.Drawing.Size(246, 22)
        Me.dtpS.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(284, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Fecha:"
        '
        'btnPaso1
        '
        Me.btnPaso1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaso1.Image = Global.Papeleria.My.Resources.Resources.va
        Me.btnPaso1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPaso1.Location = New System.Drawing.Point(621, 415)
        Me.btnPaso1.Name = "btnPaso1"
        Me.btnPaso1.Size = New System.Drawing.Size(109, 36)
        Me.btnPaso1.TabIndex = 18
        Me.btnPaso1.Text = "&Continuar"
        Me.btnPaso1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPaso1.UseVisualStyleBackColor = True
        '
        'tp2
        '
        Me.tp2.Controls.Add(Me.gp4)
        Me.tp2.Controls.Add(Me.gp3)
        Me.tp2.Location = New System.Drawing.Point(4, 22)
        Me.tp2.Name = "tp2"
        Me.tp2.Padding = New System.Windows.Forms.Padding(3)
        Me.tp2.Size = New System.Drawing.Size(794, 470)
        Me.tp2.TabIndex = 1
        Me.tp2.Text = "Paso 2"
        Me.tp2.UseVisualStyleBackColor = True
        '
        'gp4
        '
        Me.gp4.Controls.Add(Me.lblTotal)
        Me.gp4.Controls.Add(Me.Label18)
        Me.gp4.Controls.Add(Me.btnAgregarRef)
        Me.gp4.Controls.Add(Me.btnProcServ)
        Me.gp4.Controls.Add(Me.Label12)
        Me.gp4.Controls.Add(Me.Label14)
        Me.gp4.Controls.Add(Me.btnBuscarServicios)
        Me.gp4.Controls.Add(Me.dgvRefsF)
        Me.gp4.Controls.Add(Me.dgvServ)
        Me.gp4.Controls.Add(Me.Label13)
        Me.gp4.Controls.Add(Me.dgvRefs)
        Me.gp4.Location = New System.Drawing.Point(15, 128)
        Me.gp4.Name = "gp4"
        Me.gp4.Size = New System.Drawing.Size(749, 337)
        Me.gp4.TabIndex = 137
        Me.gp4.TabStop = False
        Me.gp4.Text = "Servicios y Refacciones"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(512, 233)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(59, 29)
        Me.lblTotal.TabIndex = 140
        Me.lblTotal.Text = "$0.0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(450, 241)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 18)
        Me.Label18.TabIndex = 139
        Me.Label18.Text = "Total:"
        '
        'btnAgregarRef
        '
        Me.btnAgregarRef.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAgregarRef.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnAgregarRef.ButtonImage = Nothing
        Me.btnAgregarRef.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnAgregarRef.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnAgregarRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarRef.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnAgregarRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarRef.Location = New System.Drawing.Point(450, 175)
        Me.btnAgregarRef.Name = "btnAgregarRef"
        Me.btnAgregarRef.Size = New System.Drawing.Size(154, 36)
        Me.btnAgregarRef.TabIndex = 138
        Me.btnAgregarRef.Text = "Agregar Refacción"
        Me.btnAgregarRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarRef.UseVisualStyleBackColor = True
        '
        'btnProcServ
        '
        Me.btnProcServ.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnProcServ.FlatAppearance.BorderSize = 0
        Me.btnProcServ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnProcServ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnProcServ.Image = Global.Papeleria.My.Resources.Resources.save1
        Me.btnProcServ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcServ.Location = New System.Drawing.Point(450, 291)
        Me.btnProcServ.Name = "btnProcServ"
        Me.btnProcServ.Size = New System.Drawing.Size(154, 40)
        Me.btnProcServ.TabIndex = 137
        Me.btnProcServ.Text = "&Procesar Servicio"
        Me.btnProcServ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcServ.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(27, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Selecciona los servicios:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(27, 154)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(170, 16)
        Me.Label14.TabIndex = 136
        Me.Label14.Text = "Refacciones seleccionadas:"
        '
        'btnBuscarServicios
        '
        Me.btnBuscarServicios.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBuscarServicios.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnBuscarServicios.ButtonImage = Nothing
        Me.btnBuscarServicios.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnBuscarServicios.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnBuscarServicios.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarServicios.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnBuscarServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarServicios.Location = New System.Drawing.Point(229, 12)
        Me.btnBuscarServicios.Name = "btnBuscarServicios"
        Me.btnBuscarServicios.Size = New System.Drawing.Size(137, 36)
        Me.btnBuscarServicios.TabIndex = 131
        Me.btnBuscarServicios.Text = "Buscar Servicio"
        Me.btnBuscarServicios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarServicios.UseVisualStyleBackColor = True
        '
        'dgvRefsF
        '
        Me.dgvRefsF.AllowUserToAddRows = False
        Me.dgvRefsF.AllowUserToDeleteRows = False
        Me.dgvRefsF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRefsF.Location = New System.Drawing.Point(6, 175)
        Me.dgvRefsF.Name = "dgvRefsF"
        Me.dgvRefsF.ReadOnly = True
        Me.dgvRefsF.Size = New System.Drawing.Size(438, 157)
        Me.dgvRefsF.TabIndex = 135
        '
        'dgvServ
        '
        Me.dgvServ.AllowUserToAddRows = False
        Me.dgvServ.AllowUserToDeleteRows = False
        Me.dgvServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvServ.Location = New System.Drawing.Point(6, 51)
        Me.dgvServ.Name = "dgvServ"
        Me.dgvServ.ReadOnly = True
        Me.dgvServ.Size = New System.Drawing.Size(360, 93)
        Me.dgvServ.TabIndex = 132
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(408, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(160, 16)
        Me.Label13.TabIndex = 133
        Me.Label13.Text = "Refacciones relacionadas:"
        '
        'dgvRefs
        '
        Me.dgvRefs.AllowUserToAddRows = False
        Me.dgvRefs.AllowUserToDeleteRows = False
        Me.dgvRefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRefs.Location = New System.Drawing.Point(387, 51)
        Me.dgvRefs.Name = "dgvRefs"
        Me.dgvRefs.ReadOnly = True
        Me.dgvRefs.Size = New System.Drawing.Size(348, 93)
        Me.dgvRefs.TabIndex = 134
        '
        'gp3
        '
        Me.gp3.Controls.Add(Me.txtObs)
        Me.gp3.Controls.Add(Me.txtDiag)
        Me.gp3.Controls.Add(Me.Label11)
        Me.gp3.Controls.Add(Me.Label10)
        Me.gp3.Location = New System.Drawing.Point(15, 5)
        Me.gp3.Name = "gp3"
        Me.gp3.Size = New System.Drawing.Size(749, 121)
        Me.gp3.TabIndex = 0
        Me.gp3.TabStop = False
        Me.gp3.Text = "Status del Vehiculo"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(381, 41)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(336, 64)
        Me.txtObs.TabIndex = 3
        '
        'txtDiag
        '
        Me.txtDiag.Location = New System.Drawing.Point(24, 41)
        Me.txtDiag.Multiline = True
        Me.txtDiag.Name = "txtDiag"
        Me.txtDiag.Size = New System.Drawing.Size(336, 64)
        Me.txtDiag.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(378, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 16)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Observaciones:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Diagnostico:"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(711, 14)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(28, 28)
        Me.btnMin.TabIndex = 16
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
        Me.btnClose.Location = New System.Drawing.Point(794, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(28, 28)
        Me.btnClose.TabIndex = 15
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmRecepServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(840, 600)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tbcntrl)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmRecepServicio"
        Me.Text = "Servicio: Recepción del Automovil"
        Me.gp1.ResumeLayout(False)
        Me.gp1.PerformLayout()
        Me.gp2.ResumeLayout(False)
        Me.gp2.PerformLayout()
        Me.tbcntrl.ResumeLayout(False)
        Me.tp1.ResumeLayout(False)
        Me.tp1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tp2.ResumeLayout(False)
        Me.gp4.ResumeLayout(False)
        Me.gp4.PerformLayout()
        CType(Me.dgvRefsF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvServ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRefs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gp3.ResumeLayout(False)
        Me.gp3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gp1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFolioC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnObtenerC As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarC As System.Windows.Forms.Button
    Friend WithEvents gp2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMod As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtConc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtKm As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents tbcntrl As System.Windows.Forms.TabControl
    Friend WithEvents tp1 As System.Windows.Forms.TabPage
    Friend WithEvents tp2 As System.Windows.Forms.TabPage
    Friend WithEvents gp3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents txtDiag As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnPaso1 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dgvRefs As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvServ As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscarServicios As Papeleria.ImageButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvRefsF As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpS As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMec As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
    Friend WithEvents btnMec As System.Windows.Forms.Button
    Friend WithEvents btnPers As System.Windows.Forms.Button
    Friend WithEvents gp4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregarRef As Papeleria.ImageButton
    Friend WithEvents btnProcServ As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnObtener As System.Windows.Forms.Button
    Friend WithEvents txtFolioS As System.Windows.Forms.TextBox
    Friend WithEvents btnSXC As System.Windows.Forms.Button
    Friend WithEvents lblFactura As System.Windows.Forms.Label
    Friend WithEvents lblservcomp As System.Windows.Forms.Label
    Friend WithEvents lblFechaEnt As System.Windows.Forms.Label
    Friend WithEvents lblTitFechaE As System.Windows.Forms.Label
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
