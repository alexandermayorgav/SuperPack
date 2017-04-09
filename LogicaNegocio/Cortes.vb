Public Class Cortes

    Private _id As Integer
    Private _id_usuario As Integer
    Private _nombre As String
    Private _fechainicial As Date
    Private _fechacierre As Date
    Private _monto_inicial As Double
    Private _cerrada As String


    Sub New(ByVal id As Integer, ByVal id_usuario As Integer, ByVal nombre As String, ByVal fechainical As Date, ByVal fechacierre As Date, ByVal monto As Double, ByVal cerrada As String)
        Me.Id = id
        Me.Id_Usuario = id_usuario
        Me.Nombre = nombre
        Me.FechaInicial = fechainical
        Me.FechaCierre = fechacierre
        Me.Monto = monto
        Me.Cerrada = cerrada

    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Id_Usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
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

    Public Property FechaInicial() As Date
        Get
            Return _fechainicial
        End Get
        Set(ByVal value As Date)
            _fechainicial = value
        End Set
    End Property
    Public Property FechaCierre() As Date
        Get
            Return _fechacierre
        End Get
        Set(ByVal value As Date)
            _fechacierre = value
        End Set
    End Property
    Public Property Monto() As Double
        Get
            Return _monto_inicial
        End Get
        Set(ByVal value As Double)
            _monto_inicial = value
        End Set
    End Property

    Public Property Cerrada() As String
        Get
            Return _cerrada
        End Get
        Set(ByVal value As String)
            _cerrada = value
        End Set
    End Property


End Class
