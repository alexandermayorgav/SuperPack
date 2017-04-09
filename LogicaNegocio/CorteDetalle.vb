Public Class CorteDetalle

    Private _id As Integer
    Private _id_caja As Integer
    Private _fecha As Date
    Private _monto As Double
    Private _concepto As String
    Private _tipo As String

    Sub New(ByVal id As Integer, ByVal idcaja As Integer, ByVal fecha As Date, ByVal monto As Double, ByVal concepto As String, ByVal tipo As String)
        Me.Id = id
        Me.Id_Caja = Id_Caja
        Me.Fecha = fecha
        Me.Monto = monto
        Me.Concepto = concepto
        Me.Tipo = tipo

    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Id_Caja() As Integer
        Get
            Return _id_caja
        End Get
        Set(ByVal value As Integer)
            _id_caja = value
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

    Public Property Monto() As Double
        Get
            Return _monto
        End Get
        Set(ByVal value As Double)
            _monto = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property


End Class
