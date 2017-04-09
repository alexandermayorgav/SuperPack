Public Class AbonoApartado

    Private _id_abonoap As Integer
    Private _id_apartado As Integer
    Private _fecha_abono As Date
    Private _id_caja As Integer
    Private _id_usuario As Integer
    Private _cantidad As Decimal
    Private _nombreUs As String
    

    Sub New()

    End Sub
    Sub New(ByVal id_abonoap As Integer, ByVal id_ap As Integer, ByVal fecha_abono As Date, ByVal id_caja As Integer, ByVal id_usuario As Integer, ByVal cantidad As Decimal, Optional ByVal nombreUs As String = Nothing)
        Me.IdAbonoAP = id_abonoap
        Me.IdApartado = id_ap
        Me.Fecha_Abono = fecha_abono
        Me.IdCaja = id_caja
        Me.IdUsuario = id_usuario
        Me.Cantidad_Abono = cantidad
        Me.Recibio = nombreUs
    End Sub
    Sub New(ByVal id_ap As Integer, ByVal fecha_abono As Date, ByVal id_caja As Integer, ByVal id_usuario As Integer, ByVal cantidad As Decimal)
        Me.IdApartado = id_ap
        Me.Fecha_Abono = fecha_abono
        Me.IdCaja = id_caja
        Me.IdUsuario = id_usuario
        Me.Cantidad_Abono = cantidad
    End Sub
    Public Property Recibio() As String
        Get
            Return _nombreUs
        End Get
        Set(ByVal value As String)
            _nombreUs = value
        End Set
    End Property
    Public Property Cantidad_Abono() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property

    Public Property IdUsuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property

    Public Property IdCaja() As Integer
        Get
            Return _id_caja
        End Get
        Set(ByVal value As Integer)
            _id_caja = value
        End Set
    End Property

    Public Property Fecha_Abono() As Date
        Get
            Return _fecha_abono
        End Get
        Set(ByVal value As Date)
            _fecha_abono = value
        End Set
    End Property

    Public Property IdApartado() As Integer
        Get
            Return _id_apartado
        End Get
        Set(ByVal value As Integer)
            _id_apartado = value
        End Set
    End Property

    Public Property IdAbonoAP() As Integer
        Get
            Return _id_abonoap
        End Get
        Set(ByVal value As Integer)
            _id_abonoap = value
        End Set
    End Property

End Class
