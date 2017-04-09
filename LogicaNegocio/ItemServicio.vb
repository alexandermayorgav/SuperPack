Imports System.ComponentModel
Public Class ItemServicio
    Implements INotifyPropertyChanged

    Private _id As Integer
    Private _producto As Producto
    'Private _cantidad As Decimal

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Shared Event Recalcula()
    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Sub New()

    End Sub
    Sub New(ByVal prod As Producto, ByVal id As Integer)
        Me.Producto = prod
        Me.Id = id
        '        Me.Cantidad = cant
    End Sub
    Sub New(ByVal prod As Producto)
        Me.Producto = prod
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
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return Producto.Descripcion
        End Get
    End Property

    Public ReadOnly Property Existencia() As Decimal
        Get
            Return Producto.Existencia
        End Get

    End Property
    Public ReadOnly Property Precio() As Decimal
        Get
            Return Producto.Precio
        End Get

    End Property
    <Browsable(False)> _
    Public Property exis() As Decimal
        Get
            Return Existencia
        End Get
        Set(ByVal value As Decimal)
            Producto.Existencia = value
            OnPropertyChanged("Existencia")
            RaiseEvent Recalcula()
        End Set
    End Property

    <Browsable(False)> _
    Public ReadOnly Property Id_Producto() As Integer
        Get
            Return Producto.Id
        End Get
    End Property
    '<DisplayName("Cantidad de Productos")> _
    'Public Property Cantidad() As Decimal
    '    Get
    '        Return _cantidad
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _cantidad = value
    '        OnPropertyChanged("Cantidad")
    '        RaiseEvent Recalcula()
    '    End Set
    'End Property
End Class
