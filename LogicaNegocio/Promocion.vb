Imports System.ComponentModel
Public Class Promocion
    Implements INotifyPropertyChanged

    Private _id_prom_desc As Integer
    Private _fecha_inicial As Date
    Private _fecha_final As Date
    Private _cantidad As Decimal
    Private _producto As Producto
    Private _decuento As Decimal

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
        Descuento = 0

    End Sub
    Sub New(ByVal id As Integer, ByVal fecha_inicial As Date, ByVal fecha_final As Date, ByVal cantidad As Decimal, ByVal producto As Producto, ByVal descuento As Decimal)
        Me.Id = id
        Me.Fecha_Inicial = fecha_inicial
        Me.Fecha_Final = fecha_final
        Me.Cantidad = cantidad
        Me.Producto = producto
        Me.Descuento = descuento

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
    Public Property Descripcion() As String
        Get
            Return Producto.Descripcion
        End Get
        Set(ByVal value As String)
            Producto.Descripcion = value
        End Set
    End Property

    Public Property Descuento() As Decimal
        Get
            Return _decuento
        End Get
        Set(ByVal value As Decimal)
            _decuento = value
        End Set
    End Property


End Class
