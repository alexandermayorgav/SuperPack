<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbonosAp
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNombreC = New System.Windows.Forms.TextBox
        Me.dgvAbonos = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTotAp = New System.Windows.Forms.TextBox
        Me.btnAbono = New System.Windows.Forms.Button
        Me.btnMin = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.dgvAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(14, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente:"
        '
        'txtNombreC
        '
        Me.txtNombreC.Location = New System.Drawing.Point(72, 48)
        Me.txtNombreC.Name = "txtNombreC"
        Me.txtNombreC.ReadOnly = True
        Me.txtNombreC.Size = New System.Drawing.Size(214, 22)
        Me.txtNombreC.TabIndex = 1
        Me.txtNombreC.TabStop = False
        '
        'dgvAbonos
        '
        Me.dgvAbonos.AllowUserToAddRows = False
        Me.dgvAbonos.AllowUserToDeleteRows = False
        Me.dgvAbonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAbonos.Location = New System.Drawing.Point(14, 85)
        Me.dgvAbonos.Name = "dgvAbonos"
        Me.dgvAbonos.ReadOnly = True
        Me.dgvAbonos.Size = New System.Drawing.Size(498, 170)
        Me.dgvAbonos.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(328, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Total abonos:"
        '
        'txtTotAp
        '
        Me.txtTotAp.Location = New System.Drawing.Point(435, 48)
        Me.txtTotAp.Name = "txtTotAp"
        Me.txtTotAp.ReadOnly = True
        Me.txtTotAp.Size = New System.Drawing.Size(77, 22)
        Me.txtTotAp.TabIndex = 4
        Me.txtTotAp.TabStop = False
        Me.txtTotAp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAbono
        '
        Me.btnAbono.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbono.Image = Global.Papeleria.My.Resources.Resources.money
        Me.btnAbono.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbono.Location = New System.Drawing.Point(418, 268)
        Me.btnAbono.Name = "btnAbono"
        Me.btnAbono.Size = New System.Drawing.Size(92, 36)
        Me.btnAbono.TabIndex = 5
        Me.btnAbono.Text = "&Abono"
        Me.btnAbono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAbono.UseVisualStyleBackColor = True
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BackgroundImage = Global.Papeleria.My.Resources.Resources.min
        Me.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(442, 6)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(20, 20)
        Me.btnMin.TabIndex = 26
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
        Me.btnClose.Location = New System.Drawing.Point(499, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 25
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmAbonosAp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Papeleria.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(530, 316)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAbono)
        Me.Controls.Add(Me.txtTotAp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvAbonos)
        Me.Controls.Add(Me.txtNombreC)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmAbonosAp"
        Me.Text = "Abonos Apartado"
        CType(Me.dgvAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombreC As System.Windows.Forms.TextBox
    Friend WithEvents dgvAbonos As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotAp As System.Windows.Forms.TextBox
    Friend WithEvents btnAbono As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
