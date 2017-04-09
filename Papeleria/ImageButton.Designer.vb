
Partial Class ImageButton

    Private components As System.ComponentModel.IContainer = Nothing

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

#Region "Component Designer generated code"

    Private Sub InitializeComponent()

        Me.SuspendLayout()
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Name = "ImageButton"

        AddHandler MyBase.MouseLeave, New EventHandler(AddressOf Me.ImageButton_MouseLeave)
        AddHandler MyBase.Paint, New PaintEventHandler(AddressOf Me.ImageButton_Paint)
        AddHandler MyBase.MouseDown, New MouseEventHandler(AddressOf Me.ImageButton_MouseDown)
        AddHandler MyBase.MouseUp, New MouseEventHandler(AddressOf Me.ImageButton_MouseUp)
        AddHandler MyBase.MouseEnter, New EventHandler(AddressOf Me.ImageButton_MouseEnter)

        Me.ResumeLayout(False)

    End Sub

#End Region


End Class