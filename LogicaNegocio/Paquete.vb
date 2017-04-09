Imports System.ComponentModel
Public Class Paquete
    Implements INotifyPropertyChanged

    Private _id_paquete As Integer
    Private _costo As Decimal
    Private _precio As Decimal
    Friend _existencia As Decimal
    Private _codigo As String
    Private _descripcion As String
    Private _item As BindingList(Of ItemPaquete)
    Private _iva As Boolean
    Private _status As Boolean
    Private _paq_a_armar As Integer

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Shared Event Errores(ByVal err As String, ByVal num As Integer)
    Public Shared Event SinErr(ByVal num As Integer)


    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Sub New()
        _item = New BindingList(Of ItemPaquete)
        Iva = True
        Estatus = True
        Descripcion = ""
        Codigo = ""
        _costo = 1
        Precio = 1
        Id = -1
        PaqArmar = 0

    End Sub

    Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal codigo As String, ByVal costo As Decimal, ByVal precio As Decimal, ByVal existencia As Decimal, ByVal item As BindingList(Of ItemPaquete), ByVal iva As Boolean, ByVal status As Boolean)
        Me.Id = id
        Me.Descripcion = descripcion
        Me.Codigo = codigo
        Me.Costo = costo
        Me.Precio = precio
        Me.Existencia = existencia
        Me.Items = item
        Me.Iva = iva
        Me.Estatus = status

    End Sub


    Public Property Id() As Integer
        Get
            Return _id_paquete
        End Get
        Set(ByVal value As Integer)
            _id_paquete = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            If value.Trim = "" Then
                _codigo = value
                RaiseEvent Errores("Campo de codigo es requerido", 1)
            Else
                _codigo = value
                OnPropertyChanged("Codigo")
                RaiseEvent SinErr(1)
            End If


        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            If value.Trim = "" Then
                _descripcion = value
                RaiseEvent Errores("Campo de Descripcion es requerido", 2)
            Else
                _descripcion = value
                OnPropertyChanged("Descripcion")
                RaiseEvent SinErr(2)

            End If

        End Set
    End Property
    Public Property Costo() As Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As Decimal)
            If value <= 0 Then
                _costo = 1
                RaiseEvent Errores("Costo invalido", 3)
            Else
                _costo = value
                OnPropertyChanged("Costo")
                RaiseEvent SinErr(3)
            End If
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            If value <= 0 Then
                _precio = 1
                RaiseEvent Errores("Precio Invalido", 4)

            Else
                _precio = value
                OnPropertyChanged("Precio")
                RaiseEvent SinErr(4)

            End If


        End Set
    End Property
    Public Property Existencia() As Decimal
        Get
            Return _existencia
        End Get
        Set(ByVal value As Decimal)
            _existencia = value
            OnPropertyChanged("Existencia")

        End Set
    End Property
    Public Property Items() As BindingList(Of ItemPaquete)
        Get
            Return _item
        End Get
        Set(ByVal value As BindingList(Of ItemPaquete))
            _item = value
        End Set
    End Property
    Public Property Iva() As Boolean
        Get
            Return _iva
        End Get
        Set(ByVal value As Boolean)
            OnPropertyChanged("Iva")
            _iva = value
        End Set
    End Property
    Public Property Estatus() As Boolean
        Get
            Return _status
        End Get
        Set(ByVal value As Boolean)
            _status = value
                   OnPropertyChanged("Estatus")
        End Set
    End Property
    '    <Browsable(False)> _
    Public Property PaqArmar() As Integer
        Get
            Return _paq_a_armar
        End Get
        Set(ByVal value As Integer)
            _paq_a_armar = value
            OnPropertyChanged("PaqArmar")
        End Set
    End Property
End Class
