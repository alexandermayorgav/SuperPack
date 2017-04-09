Imports System.ComponentModel
Public Class PromocionPieza
    Implements INotifyPropertyChanged

    Private _id_prom_desc As Integer
    Private _fecha_inicial As Date
    Private _fecha_final As Date
    Private _cantidad As Decimal
    Private _producto As Producto
    Private _producto2 As Producto
    Private _cantidad_regalada As Decimal

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Shared Event Recalcula()
    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Sub New()
        Id = -1
        Fecha_Inicial = Date.Now
        Fecha_Final = Date.Now
        Cantidad = 1
        Producto = New Producto
        ProductoRegalo = New Producto
        CantidadRegalada = 1

    End Sub
    Sub New(ByVal id As Integer, ByVal fecha_inicial As Date, ByVal fecha_final As Date, ByVal cantidad As Decimal, ByVal producto As Producto, ByVal productoregalo As Producto, ByVal cantidadregalada As Decimal)
        Me.Id = id
        Me.Fecha_Inicial = fecha_inicial
        Me.Fecha_Final = fecha_final
        Me.Cantidad = cantidad
        Me.Producto = producto
        Me.CantidadRegalada = cantidadregalada
        Me.ProductoRegalo = productoregalo


    End Sub

    Public Property Id() As Integer
        Get
            Return _id_prom_desc
        End Get
        Set(ByVal value As Integer)
            _id_prom_desc = value
        End Set
    End Property
    Public Property Fecha_Final() As Date
        Get
            Return _fecha_final
        End Get
        Set(ByVal value As Date)
            _fecha_final = value
        End Set
    End Property
    Public Property Fecha_Inicial() As Date
        Get
            Return _fecha_inicial
        End Get
        Set(ByVal value As Date)
            _fecha_inicial = value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    Public Property Producto() As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
            OnPropertyChanged("Producto")
        End Set
    End Property
    Public Property ProductoRegalo() As Producto
        Get
            Return _producto2
        End Get
        Set(ByVal value As Producto)
            _producto2 = value
            OnPropertyChanged("ProductoRegalo")
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return Producto.Descripcion
        End Get
        Set(ByVal value As String)
            Producto.Descripcion = value
        End Set
    End Property
    Public Property DescripcionRegalo() As String
        Get
            Return ProductoRegalo.Descripcion
        End Get
        Set(ByVal value As String)
            ProductoRegalo.Descripcion = value
        End Set
    End Property

    Public Property CantidadRegalada() As Decimal
        Get
            Return _cantidad_regalada
        End Get
        Set(ByVal value As Decimal)
            _cantidad_regalada = value
        End Set
    End Property


End Class
