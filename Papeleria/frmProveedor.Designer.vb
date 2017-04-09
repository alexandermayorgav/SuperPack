<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedor
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
        Me.lblIdentidicador = New System.Windows.Forms.Label
        Me.lblNombre = New System.Windows.Forms.Label
        Me.lblRfc = New System.Windows.Forms.Label
        Me.lblCalle = New System.Windows.Forms.Label
        Me.lblNumInt = New System.Windows.Forms.Label
        Me.lblNumExt = New System.Windows.Forms.Label
        Me.lblColonia = New System.Windows.Forms.Label
        Me.lblCP = New System.Windows.Forms.Label
        Me.lblCiudad = New System.Windows.Forms.Label
        Me.lblTelefono = New System.Windows.Forms.Label
        Me.lblEstado = New System.Windows.Forms.Label
        Me.chkStatus = New System.Windows.Forms.CheckBox
        Me.txtId = New System.Windows.Forms.TextBox
        Me.txtRfc = New System.Windows.Forms.TextBox
        Me.txtCalle = New System.Windows.Forms.TextBox
        Me.txtNumint = New System.Windows.Forms.TextBox
        Me.txtColonia = New System.Windows.Forms.TextBox
        Me.txtCP = New System.Windows.Forms.TextBox
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.txtCiudad = New System.Windows.Forms.TextBox
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.lblFolio = New System.Windows.Forms.Label
        Me.txtFolio = New System.Windows.Forms.TextBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtNumext = New System.Windows.Forms.TextBox
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.dgvprods = New System.Windows.Forms.DataGridView
        Me.lblPP = New System.Windows.Forms.Label
        Me.btnBuscar = New Papeleria.ImageButton
        Me.btnSalir = New Papeleria.ImageButton
        Me.btnNuevo = New Papeleria.ImageButton
        Me.btnEliminar = New Papeleria.ImageButton
        Me.btnGuardar = New Papeleria.ImageButton
        CType(Me.dgvprods, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblIdentidicador
        '
        Me.lblIdentidicador.AutoSize = True
        Me.lblIdentidicador.BackColor = System.Drawing.Color.Transparent
        Me.lblIdentidicador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdentidicador.Location = New System.Drawing.Point(80, 72)
        Me.lblIdentidicador.Name = "lblIdentidicador"
        Me.lblIdentidicador.Size = New System.Drawing.Size(77, 16)
        Me.lblIdentidicador.TabIndex = 0
        Me.lblIdentidicador.Text = "Identificador"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(24, 136)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(134, 16)
        Me.lblNombre.TabIndex = 1
        Me.lblNombre.Text = "Nombre/Razón Social"
        '
        'lblRfc
        '
        Me.lblRfc.AutoSize = True
        Me.lblRfc.BackColor = System.Drawing.Color.Transparent
        Me.lblRfc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRfc.Location = New System.Drawing.Point(124, 167)
        Me.lblRfc.Name = "lblRfc"
        Me.lblRfc.Size = New System.Drawing.Size(34, 16)
        Me.lblRfc.TabIndex = 2
        Me.lblRfc.Text = "RFC"
        '
        'lblCalle
        '
        Me.lblCalle.AutoSize = True
        Me.lblCalle.BackColor = System.Drawing.Color.Transparent
        Me.lblCalle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalle.Location = New System.Drawing.Point(122, 201)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(37, 16)
        Me.lblCalle.TabIndex = 3
        Me.lblCalle.Text = "Calle"
        '
        'lblNumInt
        '
        Me.lblNumInt.AutoSize = True
        Me.lblNumInt.BackColor = System.Drawing.Color.Transparent
        Me.lblNumInt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumInt.Location = New System.Drawing.Point(413, 201)
        Me.lblNumInt.Name = "lblNumInt"
        Me.lblNumInt.Size = New System.Drawing.Size(40, 16)
        Me.lblNumInt.TabIndex = 4
        Me.lblNumInt.Text = "N° Int"
        '
        'lblNumExt
        '
        Me.lblNumExt.AutoSize = True
        Me.lblNumExt.BackColor = System.Drawing.Color.Transparent
        Me.lblNumExt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumExt.Location = New System.Drawing.Point(529, 201)
        Me.lblNumExt.Name = "lblNumExt"
        Me.lblNumExt.Size = New System.Drawing.Size(46, 16)
        Me.lblNumExt.TabIndex = 5
        Me.lblNumExt.Text = "N° Ext"
        '
        'lblColonia
        '
        Me.lblColonia.AutoSize = True
        Me.lblColonia.BackColor = System.Drawing.Color.Transparent
        Me.lblColonia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColonia.Location = New System.Drawing.Point(110, 231)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(51, 16)
        Me.lblColonia.TabIndex = 6
        Me.lblColonia.Text = "Colonia"
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.BackColor = System.Drawing.Color.Transparent
        Me.lblCP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.Location = New System.Drawing.Point(72, 261)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(87, 16)
        Me.lblCP.TabIndex = 7
        Me.lblCP.Text = "Código postal"
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.BackColor = System.Drawing.Color.Transparent
        Me.lblCiudad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCiudad.Location = New System.Drawing.Point(111, 322)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(48, 16)
        Me.lblCiudad.TabIndex = 8
        Me.lblCiudad.Text = "Ciudad"
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.BackColor = System.Drawing.Color.Transparent
        Me.lblTelefono.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.Location = New System.Drawing.Point(105, 289)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(56, 16)
        Me.lblTelefono.TabIndex = 9
        Me.lblTelefono.Text = "Teléfono"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(110, 352)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(49, 16)
        Me.lblEstado.TabIndex = 10
        Me.lblEstado.Text = "Estado"
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.BackColor = System.Drawing.Color.Transparent
        Me.chkStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatus.Location = New System.Drawing.Point(115, 378)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkStatus.Size = New System.Drawing.Size(70, 20)
        Me.chkStatus.TabIndex = 13
        Me.chkStatus.Text = "Activo  "
        Me.chkStatus.UseVisualStyleBackColor = False
        '
        'txtId
        '
        Me.txtId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(171, 68)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(70, 22)
        Me.txtId.TabIndex = 0
        Me.txtId.TabStop = False
        '
        'txtRfc
        '
        Me.txtRfc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRfc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRfc.Location = New System.Drawing.Point(171, 164)
        Me.txtRfc.MaxLength = 15
        Me.txtRfc.Name = "txtRfc"
        Me.txtRfc.Size = New System.Drawing.Size(190, 22)
        Me.txtRfc.TabIndex = 4
        '
        'txtCalle
        '
        Me.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCalle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalle.Location = New System.Drawing.Point(171, 195)
        Me.txtCalle.MaxLength = 60
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(235, 22)
        Me.txtCalle.TabIndex = 5
        '
        'txtNumint
        '
        Me.txtNumint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumint.Location = New System.Drawing.Point(458, 195)
        Me.txtNumint.MaxLength = 6
        Me.txtNumint.Name = "txtNumint"
        Me.txtNumint.Size = New System.Drawing.Size(68, 22)
        Me.txtNumint.TabIndex = 6
        '
        'txtColonia
        '
        Me.txtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColonia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColonia.Location = New System.Drawing.Point(171, 227)
        Me.txtColonia.MaxLength = 60
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(235, 22)
        Me.txtColonia.TabIndex = 8
        '
        'txtCP
        '
        Me.txtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCP.Location = New System.Drawing.Point(171, 258)
        Me.txtCP.MaxLength = 6
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(68, 22)
        Me.txtCP.TabIndex = 9
        '
        'txtTelefono
        '
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(171, 286)
        Me.txtTelefono.MaxLength = 12
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(147, 22)
        Me.txtTelefono.TabIndex = 10
        '
        'txtCiudad
        '
        Me.txtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCiudad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiudad.Location = New System.Drawing.Point(171, 319)
        Me.txtCiudad.MaxLength = 12
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Size = New System.Drawing.Size(235, 22)
        Me.txtCiudad.TabIndex = 11
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(171, 350)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(142, 21)
        Me.cboEstado.TabIndex = 12
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.BackColor = System.Drawing.Color.Transparent
        Me.lblFolio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(122, 103)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(36, 16)
        Me.lblFolio.TabIndex = 17
        Me.lblFolio.Text = "Folio"
        '
        'txtFolio
        '
        Me.txtFolio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(171, 100)
        Me.txtFolio.MaxLength = 10
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(70, 22)
        Me.txtFolio.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(251, 71)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(46, 16)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "Status"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(171, 133)
        Me.txtNombre.MaxLength = 60
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(435, 22)
        Me.txtNombre.TabIndex = 3
        '
        'txtNumext
        '
        Me.txtNumext.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumext.Location = New System.Drawing.Point(580, 195)
        Me.txtNumext.MaxLength = 6
        Me.txtNumext.Name = "txtNumext"
        Me.txtNumext.Size = New System.Drawing.Size(68, 22)
        Me.txtNumext.TabIndex = 7
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(655, 14)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(25, 25)
        Me.btnMin.TabIndex = 20
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
        Me.btnClose.Location = New System.Drawing.Point(739, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.TabIndex = 19
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'dgvprods
        '
        Me.dgvprods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvprods.Location = New System.Drawing.Point(458, 248)
        Me.dgvprods.Name = "dgvprods"
        Me.dgvprods.Size = New System.Drawing.Size(300, 150)
        Me.dgvprods.TabIndex = 21
        Me.dgvprods.Visible = False
        '
        'lblPP
        '
        Me.lblPP.AutoSize = True
        Me.lblPP.BackColor = System.Drawing.Color.Transparent
        Me.lblPP.Location = New System.Drawing.Point(455, 231)
        Me.lblPP.Name = "lblPP"
        Me.lblPP.Size = New System.Drawing.Size(105, 13)
        Me.lblPP.TabIndex = 22
        Me.lblPP.Text = "Productos que surte:"
        Me.lblPP.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBuscar.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnBuscar.ButtonImage = Nothing
        Me.btnBuscar.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnBuscar.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnBuscar.Image = Global.Papeleria.My.Resources.Resources.buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(254, 91)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(73, 37)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSalir.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnSalir.ButtonImage = Nothing
        Me.btnSalir.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnSalir.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnSalir.Image = Global.Papeleria.My.Resources.Resources.cancel21
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(482, 415)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(65, 45)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnNuevo.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnNuevo.ButtonImage = Nothing
        Me.btnNuevo.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnNuevo.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnNuevo.Image = Global.Papeleria.My.Resources.Resources.personal_add
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(383, 415)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(80, 45)
        Me.btnNuevo.TabIndex = 16
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnEliminar.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnEliminar.ButtonImage = Nothing
        Me.btnEliminar.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnEliminar.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnEliminar.Image = Global.Papeleria.My.Resources.Resources.personal_delete
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(279, 415)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(83, 45)
        Me.btnEliminar.TabIndex = 15
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnGuardar.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.btnGuardar.ButtonImage = Nothing
        Me.btnGuardar.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.btnGuardar.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.btnGuardar.Image = Global.Papeleria.My.Resources.Resources.guardar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(171, 415)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(88, 45)
        Me.btnGuardar.TabIndex = 14
        Me.btnGuardar.Text = "Guardar / Actualizar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmProveedor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(782, 486)
        Me.Controls.Add(Me.lblPP)
        Me.Controls.Add(Me.dgvprods)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtNumext)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.lblFolio)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.txtCiudad)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.txtCP)
        Me.Controls.Add(Me.txtColonia)
        Me.Controls.Add(Me.txtNumint)
        Me.Controls.Add(Me.txtCalle)
        Me.Controls.Add(Me.txtRfc)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.chkStatus)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.lblTelefono)
        Me.Controls.Add(Me.lblCiudad)
        Me.Controls.Add(Me.lblCP)
        Me.Controls.Add(Me.lblColonia)
        Me.Controls.Add(Me.lblNumExt)
        Me.Controls.Add(Me.lblNumInt)
        Me.Controls.Add(Me.lblCalle)
        Me.Controls.Add(Me.lblRfc)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblIdentidicador)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proveedores"
        CType(Me.dgvprods, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIdentidicador As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblRfc As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblNumInt As System.Windows.Forms.Label
    Friend WithEvents lblNumExt As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtRfc As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtNumint As System.Windows.Forms.TextBox
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As Papeleria.ImageButton
    Friend WithEvents btnEliminar As Papeleria.ImageButton
    Friend WithEvents btnNuevo As Papeleria.ImageButton
    Friend WithEvents btnSalir As Papeleria.ImageButton
    Friend WithEvents btnBuscar As Papeleria.ImageButton
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtNumext As System.Windows.Forms.TextBox
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvprods As System.Windows.Forms.DataGridView
    Friend WithEvents lblPP As System.Windows.Forms.Label

End Class
