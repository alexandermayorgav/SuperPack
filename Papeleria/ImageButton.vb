

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Partial Public Class ImageButton
    Inherits Button
    Enum Status
        [Default] = 0
        Down = 2
        Hover = 1
    End Enum
    Enum TipoBoton
        Normal
        Cerrar
    End Enum
    Public _ButtonImage As Image
    Public _ButtonImageOffset As Point
    Public _ButtonState As Status
    Private _button_tipo As TipoBoton

    Sub New()
        InitializeComponent()
    End Sub

    Public Property ButtonState() As Status
        Get
            Return _ButtonState
        End Get
        Set(ByVal value As Status)
            _ButtonState = value
        End Set
    End Property

    Public Property BotonTipo() As TipoBoton
        Get
            Return _button_tipo
        End Get
        Set(ByVal value As TipoBoton)
            _button_tipo = value
        End Set
    End Property

    Public Property ButtonImage() As Image
        Get
            Return _ButtonImage
        End Get
        Set(ByVal value As Image)
            _ButtonImage = value
        End Set
    End Property

    Public Property ButtonImageOffset() As Point
        Get
            Return _ButtonImageOffset
        End Get
        Set(ByVal value As Point)
            _ButtonImageOffset = value
        End Set
    End Property

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        MyBase.OnClick(e)
        MyBase.Cursor = Cursors.Default
    End Sub


    Private Sub ImageButton_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        Me.ButtonState = Status.Hover
        Me.Refresh()
    End Sub
    Private Sub ImageButton_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        Me.ButtonState = Status.Default
        Me.Refresh()
    End Sub
    Private Sub ImageButton_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Me.ButtonState = Status.Down
        Me.Refresh()
    End Sub
    Private Sub ImageButton_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Me.ButtonState = Status.Hover
        Me.Refresh()
    End Sub

    Private Sub ImageButton_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        If Me.ButtonImage Is Nothing Then
            Return
        End If
        
        Dim destinationRect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)

        Dim sourceRect = New Rectangle(Me.ButtonImageOffset.X, Me.ButtonImageOffset.Y + (CInt(Me.ButtonState) * Me.Height), Me.Width, Me.Height)

        e.Graphics.DrawImage(Me.ButtonImage, destinationRect, sourceRect, GraphicsUnit.Pixel)

        If BotonTipo = TipoBoton.Normal Then
            If (Me.TabStop = True And Me.Focused = True) Then

                Dim Pen = New Pen(Color.LightGray, 1)

                Pen.DashStyle = DashStyle.Dot

                e.Graphics.DrawRectangle(Pen, 2, 2, Me.Width - 5, Me.Height - 5)

            End If
        End If
    End Sub


End Class