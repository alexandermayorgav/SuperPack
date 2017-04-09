<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromocionPieza
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
        Me.txtCantidadVendida = New System.Windows.Forms.TextBox
        Me.datein = New System.Windows.Forms.DateTimePicker
        Me.datefin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblProducto = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.lblProducto2 = New System.Windows.Forms.Label
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.ImageButton1 = New Papeleria.ImageButton
        Me.btnAgregarLinea = New Papeleria.ImageButton
        Me.btnBuscar = New Papeleria.ImageButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCantidadVendida
        '
        Me.txtCantidadVendida.Location = New System.Drawing.Point(135, 58)
        Me.txtCantidadVendida.Name = "txtCantidadVendida"
        Me.txtCantidadVendida.Size = New System.Drawing.Size(92, 20)
        Me.txtCantidadVendida.TabIndex = 2
        '
        'datein
        '
        Me.datein.Location = New System.Drawing.Point(67, 299)
        Me.datein.Name = "datein"
        Me.datein.Size = New System.Drawing.Size(200, 20)
        Me.datein.TabIndex = 6
        '
        'datefin
        '
        Me.datefin.Location = New System.Drawing.Point(314, 299)
        Me.datefin.Name = "datefin"
        Me.datefin.Size = New System.Drawing.Size(200, 20)
        Me.datefin.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 300)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Del:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(286, 301)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Al:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 16)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Cantidad Vendida"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.BackColor = System.Drawing.Color.Transparent
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(9, 29)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(13, 16)
        Me.lblProducto.TabIndex = 116
        Me.lblProducto.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 16)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "Cantidad Regalada"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(132, 59)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(92, 20)
        Me.txtCantidad.TabIndex = 5
        '
        'lblProducto2
        '
        Me.lblProducto2.AutoSize = True
        Me.lblProducto2.BackColor = System.Drawing.Color.Transparent
        Me.lblProducto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto2.Location = New System.Drawing.Point(9, 29)
        Me.lblProducto2.Name = "lblProducto2"
        Me.lblProducto2.Size = New System.Drawing.Size(13, 16)
        Me.lblProducto2.TabIndex = 120
        Me.lblProducto2.Text = "-"
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(450, 10)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(26, 18)
        Me.btnMin.TabIndex = 122
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
        Me.btnClose.Location = New System.Drawing.Point(501, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(26, 18)
        Me.btnClose.TabIndex = 121
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'ImageButton1
        '
        Me.ImageButton1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ImageButton1.BotonTipo = Papeleria.ImageButton.TipoBoton.Normal
        Me.ImageButton1.ButtonImage = Nothing
        Me.ImageButton1.ButtonImageOffset = New System.Drawing.Point(0, 0)
        Me.ImageButton1.ButtonState = Papeleria.ImageButton.Status.[Default]
        Me.ImageButton1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImageButton1.Location = New System.Drawing.Point(393, 19)
        Me.ImageButton1.Name = "ImageButton1"
        Me.ImageButton1.Size = New System.Drawing.Size(93, 36)
        Me.ImageButton1.TabIndex = 4
        Me.ImageButton1.Text = "Producto 2"
        Me.ImageButton1.UseVisualStyleBackColor = True
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
        Me.btnAgregarLinea.Location = New System.Drawing.Point(421, 335)
        Me.btnAgregarLinea.Name = "btnAgregarLinea"
        Me.btnAgregarLinea.Size = New System.Drawing.Size(93, 36)
        Me.btnAgregarLinea.TabIndex = 8
        Me.btnAgregarLinea.Text = "Agregar"
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
        Me.btnBuscar.Location = New System.Drawing.Point(393, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(93, 36)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Producto 1"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.txtCantidadVendida)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblProducto)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(489, 102)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto Vendido"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ImageButton1)
        Me.GroupBox2.Controls.Add(Me.txtCantidad)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblProducto2)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 173)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(489, 108)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto Regalado"
        '
        'frmPromocionPieza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(540, 403)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAgregarLinea)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.datefin)
        Me.Controls.Add(Me.datein)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPromocionPieza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Promocion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCantidadVendida As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As Papeleria.ImageButton
    Friend WithEvents datein As System.Windows.Forms.DateTimePicker
    Friend WithEvents datefin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarLinea As Papeleria.ImageButton
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents ImageButton1 As Papeleria.ImageButton
    Friend WithEvents lblProducto2 As System.Windows.Forms.Label
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
