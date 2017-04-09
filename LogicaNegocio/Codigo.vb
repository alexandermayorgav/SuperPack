Public Class Codigo
    Private _id_codigo As Integer
    Private _codigo_hermano As Integer
    Private _id_prod As Integer
    Private _desc As String

    Sub New()

    End Sub
    Sub New(ByVal id_producto As Integer, ByVal codigo As Integer, ByVal descripcion As String, ByVal id_cod As Integer)
        Me.Descripcion = descripcion
        Me.Codigo_Hermano = codigo
        Me.Id_Producto = id_producto
        Me.Id_Codigo = id_cod
    End Sub

    Sub New(ByVal id_producto As Integer, ByVal codigo As Integer)
        Me.Id_Producto = id_producto
        Me.Codigo_Hermano = codigo
    End Sub


    Public Property Id_Codigo() As Integer
        Get
            Return _id_codigo
        End Get
        Set(ByVal value As Integer)
            _id_codigo = value
        End Set
    End Property
    Public Property Id_Producto() As Integer
        Get
            Return _id_prod
        End Get
        Set(ByVal value As Integer)
            _id_prod = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property
    
    Public Property Codigo_Hermano() As Integer
        Get
            Return _codigo_hermano
        End Get
        Set(ByVal value As Integer)
            _codigo_hermano = value
        End Set
    End Property
End Class
