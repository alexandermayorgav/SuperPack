<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiarPassword
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPasswordAnterior = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNuevoPassword = New System.Windows.Forms.TextBox
        Me.txtNuevoPasswordConfirm = New System.Windows.Forms.TextBox
        Me.btnCambiar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Password Anterior:"
        '
        'txtPasswordAnterior
        '
        Me.txtPasswordAnterior.Location = New System.Drawing.Point(17, 30)
        Me.txtPasswordAnterior.Name = "txtPasswordAnterior"
        Me.txtPasswordAnterior.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordAnterior.Size = New System.Drawing.Size(236, 21)
        Me.txtPasswordAnterior.TabIndex = 1
        Me.txtPasswordAnterior.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nuevo Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Confirmar Password:"
        '
        'txtNuevoPassword
        '
        Me.txtNuevoPassword.Location = New System.Drawing.Point(17, 87)
        Me.txtNuevoPassword.Name = "txtNuevoPassword"
        Me.txtNuevoPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNuevoPassword.Size = New System.Drawing.Size(236, 21)
        Me.txtNuevoPassword.TabIndex = 2
        Me.txtNuevoPassword.UseSystemPasswordChar = True
        '
        'txtNuevoPasswordConfirm
        '
        Me.txtNuevoPasswordConfirm.Location = New System.Drawing.Point(17, 144)
        Me.txtNuevoPasswordConfirm.Name = "txtNuevoPasswordConfirm"
        Me.txtNuevoPasswordConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNuevoPasswordConfirm.Size = New System.Drawing.Size(236, 21)
        Me.txtNuevoPasswordConfirm.TabIndex = 3
        Me.txtNuevoPasswordConfirm.UseSystemPasswordChar = True
        '
        'btnCambiar
        '
        Me.btnCambiar.Image = My.Resources.llave
        Me.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCambiar.Location = New System.Drawing.Point(153, 171)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(100, 40)
        Me.btnCambiar.TabIndex = 4
        Me.btnCambiar.Text = "&Cambiar"
        Me.btnCambiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCambiar.UseVisualStyleBackColor = True
        '
        'frmCambiarPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(278, 230)
        Me.Controls.Add(Me.btnCambiar)
        Me.Controls.Add(Me.txtNuevoPasswordConfirm)
        Me.Controls.Add(Me.txtNuevoPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPasswordAnterior)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambiarPassword"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordAnterior As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNuevoPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNuevoPasswordConfirm As System.Windows.Forms.TextBox
    Friend WithEvents btnCambiar As System.Windows.Forms.Button
End Class
