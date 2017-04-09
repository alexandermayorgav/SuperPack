Public Class Caja
    Private _id As Integer
    Private _id_usuario As Integer
    Private _fecha_apertura As Date
    Private _fecha_cierre As Date
    Private _monto_incial As Decimal
    Private _cerrada As Boolean
    Public Nombre As String

    Sub New()
    End Sub
    Sub New(ByVal id As Integer, ByVal id_usuario As Integer, ByVal fecha_apertura As Date, ByVal fecha_cierre As Date, ByVal monto As Decimal, ByVal cerrada As Boolean)
        Me.Id = id
        Me.Id_usuario = id_usuario
        Me.Fecha_Apertura = fecha_apertura
        Me.Fecha_Cierre = fecha_cierre
        Me.Monto_Inicial = monto
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
    Public Property Id_usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property
    Public Property Fecha_Apertura() As Date
        Get
            Return _fecha_apertura
        End Get
        Set(ByVal value As Date)
            _fecha_apertura = value
        End Set
    End Property
    Public Property Fecha_Cierre() As Date
        Get
            Return _fecha_cierre
        End Get
        Set(ByVal value As Date)
            _fecha_cierre = value
        End Set
    End Property
    Public Property Monto_Inicial() As Decimal
        Get
            Return _monto_incial
        End Get
        Set(ByVal value As Decimal)
            _monto_incial = value
        End Set
    End Property
    Public Property Cerrada() As Boolean
        Get
            Return _cerrada
        End Get
        Set(ByVal value As Boolean)
            _cerrada = value
        End Set
    End Property

    Class CajaDetalle
        Private _id As Integer
        Private _id_caja As Integer
        Private _fecha As Date
        Private _monto As Decimal
        Private _concepto As String
        Private _tipo_pago As String

        Sub New()

        End Sub
        Sub New(ByVal id As Integer, ByVal id_caja As Integer, ByVal fecha As Date, ByVal monto As Decimal, ByVal concepto As String, ByVal tipo_pago As String)
            Me.Id = id
            Me.Id_caja = id_caja
            Me.Fecha = fecha
            Me.Monto = monto
            Me.Concepto = concepto
            Me.Tipo_pago = tipo_pago
        End Sub

        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
        Public Property Id_caja() As Integer
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
        Public Property Monto() As Decimal
            Get
                Return _monto
            End Get
            Set(ByVal value As Decimal)
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
        Public Property Tipo_pago() As String
            Get
                Return _tipo_pago
            End Get
            Set(ByVal value As String)
                _tipo_pago = value
            End Set
        End Property

    End Class
    

End Class
