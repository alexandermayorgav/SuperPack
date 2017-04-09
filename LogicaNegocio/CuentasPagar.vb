
Public Class CuentasPagar
    Private _id_credito As Integer
    Private _id_compra As Integer
    Private _fecha As Date
    Private _total As Decimal


    Private _nombre As String

    Private _usuario As String

    Private _id_proveedor As Integer
    Private _rs As String
    Sub New()
    End Sub
    Sub New(ByVal id_credito As Integer, ByVal id_compra As Integer, ByVal fecha As Date, ByVal total As Decimal, ByVal nombre As String, ByVal usuario As String, ByVal id_proveedor As Integer, ByVal rs As String)
        Me.IdCredito = id_credito
        Me.IdCompra = id_compra
        Me.Fecha = fecha
        Me.Total = total
        Me.Nombre = nombre
        Me.Usuario = usuario
        Me.IdProveedor = id_proveedor
        Me.RazonSocial = rs
    End Sub
    Public Property IdCredito() As Integer
        Get
            Return _id_credito
        End Get
        Set(ByVal value As Integer)
            _id_credito = value
        End Set
    End Property
    Public Property IdCompra() As Integer
        Get
            Return _id_compra
        End Get
        Set(ByVal value As Integer)
            _id_compra = value
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
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
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
    Public Property IdProveedor() As Integer
        Get
            Return _id_proveedor
        End Get
        Set(ByVal value As Integer)
            _id_proveedor = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return _rs
        End Get
        Set(ByVal value As String)
            _rs = value
        End Set
    End Property
End Class
