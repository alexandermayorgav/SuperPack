Public Class CuentasCobrar
    Private _id_credito As Integer
    Private _id_cliente As Integer
    Private _fecha As Date
    Private _limite As Decimal
    Private _activo As Boolean
    Private _saldo As Decimal
    Private _rs As String
    Sub New()
    End Sub
    Sub New(ByVal id_credito As Integer, ByVal id_cliente As Integer, ByVal fecha As Date, ByVal limite As Decimal, ByVal activo As Boolean, ByVal saldo As Decimal, ByVal rs As String)
        Me.IdCredito = id_credito
        Me.IdCliente = id_cliente
        Me.FechaApertura = fecha
        Me.LimiteCredito = limite
        Me.Activo = activo
        Me.Saldo = saldo
        Me.RSocial = rs
    End Sub
    Public Property IdCredito() As Integer
        Get
            Return _id_credito
        End Get
        Set(ByVal value As Integer)
            _id_credito = value
        End Set
    End Property
    Public Property IdCliente() As Integer
        Get
            Return _id_cliente
        End Get
        Set(ByVal value As Integer)
            _id_cliente = value
        End Set
    End Property
    Public Property FechaApertura() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Public Property LimiteCredito() As Double
        Get
            Return _limite
        End Get
        Set(ByVal value As Double)
            _limite = value
        End Set
    End Property
    Public Property Activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property
 
    Public Property Saldo() As Double
        Get
            Return _saldo
        End Get
        Set(ByVal value As Double)
            _saldo = value
        End Set
    End Property
    Public Property RSocial() As String
        Get
            Return _rs
        End Get
        Set(ByVal value As String)
            _rs = value
        End Set
    End Property

    Public ReadOnly Property Activo2() As String
        Get
            If Activo = True Then
                Return "Si"
            Else
                Return "No"
            End If
        End Get

    End Property
End Class
