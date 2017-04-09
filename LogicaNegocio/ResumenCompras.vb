Public Class ResumenCompras
    Private _id_compra As Integer
    Private _id_usuario As Integer
    Private _fecha As Date
    Private _total As Decimal
    Private _usuario As String
    Private _nombreusuario As String
    Private _id_proveedor As Integer
    Private _nombreproveedor As String
    Sub New()
    End Sub

    Sub New(ByVal id_compra As Integer, ByVal id_usuario As Integer, ByVal fecha As Date, ByVal total As Decimal, ByVal usuario As String, ByVal nombreusuario As String, ByVal id_proveedor As Integer, ByVal nombreproveedor As String)
        Me.IdCompra = id_compra
        Me.IdUsuario = id_usuario
        Me.Fecha = fecha
        Me.Total = total
        Me.Usuario = usuario
        Me.NombreUsuario = nombreusuario
        Me.IdProveedor = id_proveedor
        Me.NombreProveedor = nombreproveedor
    End Sub
    Public Property IdCompra() As Integer
        Get
            Return _id_compra
        End Get
        Set(ByVal value As Integer)
            _id_compra = value
        End Set
    End Property
    Public Property IdUsuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property
    Public Property Fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Public Property Total() As Double
        Get
            Return _total
        End Get
        Set(ByVal value As Double)
            _total = value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property
    Public Property NombreUsuario() As String
        Get
            Return _nombreusuario
        End Get
        Set(ByVal value As String)
            _nombreusuario = value
        End Set
    End Property
    Public Property IdProveedor() As Integer
        Get
            Return _id_proveedor
        End Get
        Set(ByVal value As Integer)
            _id_proveedor = value
        End Set
    End Property
    Public Property NombreProveedor() As String
        Get
            Return _nombreproveedor
        End Get
        Set(ByVal value As String)
            _nombreproveedor = value
        End Set
    End Property
End Class
