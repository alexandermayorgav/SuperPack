Imports LogicaNegocio
Imports System.ComponentModel
Public Class Traspaso

    Private _id As Integer
    Private _prod As Producto
    Private _caja As Producto
    Private _cantidad_paquetes As Decimal
    Private _cajas_abiertas As Decimal
    Private _sobrantes As Decimal

    Sub New()

    End Sub
    Sub New(ByVal id As Integer, ByVal prod As Producto, ByVal caja As Producto, ByVal numpaq As Decimal, ByVal cajas As Decimal)
        Me.Id = id
        Me.Producto = prod
        Me.Caja = caja
        Me.Cantidad_Paquetes = numpaq
        Me.Cajas_Abiertas = cajas
    End Sub
    <Browsable(False)> _
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    <Browsable(False)> _
    Public Property Producto() As Producto
        Get
            Return _prod
        End Get
        Set(ByVal value As Producto)
            _prod = value
        End Set
    End Property
    <Browsable(False)> _
    Public Property Caja() As Producto
        Get
            Return _caja
        End Get
        Set(ByVal value As Producto)
            _caja = value
        End Set
    End Property
    Public Property Paquete() As String
        Get
            Return Producto.Descripcion
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    <DisplayName("Caja")> _
    Public Property Caj() As String
        Get
            Return Caja.Descripcion
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property Cantidad_Paquetes() As Decimal
        Get
            Return _cantidad_paquetes
        End Get
        Set(ByVal value As Decimal)
            _cantidad_paquetes = value
        End Set
    End Property
    Public Property Cajas_Abiertas() As Decimal
        Get
            Return _cajas_abiertas
        End Get
        Set(ByVal value As Decimal)
            _cajas_abiertas = value
        End Set
    End Property
    Public Property Sobrantes() As Decimal
        Get
            Return _sobrantes
        End Get
        Set(ByVal value As Decimal)
            _sobrantes = value
        End Set
    End Property

End Class
