Public Class Factura

    Private _id As Integer
    Private _id_venta As Integer
    Private _fecha As Date
    Private _estatus As String
    Private _folio As Integer
    Private _id_folio As Integer

    Sub New(ByVal id As Integer, ByVal id_venta As Integer, ByVal fecha As Date, ByVal estatus As String, ByVal folio As Integer, ByVal id_folio As Integer)
        Me.Id = id
        Me.Id_Venta = id_venta
        Me.Fecha = fecha
        Me.Estatus = estatus
        Me.Folio = folio
        Me.id_folio = id_folio
    End Sub
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Id_Venta() As Integer
        Get
            Return _id_venta
        End Get
        Set(ByVal value As Integer)
            _id_venta = value
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
    Public Property Estatus() As String
        Get
            Return _estatus
        End Get
        Set(ByVal value As String)
            _estatus = value
        End Set
    End Property
    Public Property Folio() As Integer
        Get
            Return _folio
        End Get
        Set(ByVal value As Integer)
            _folio = value
        End Set
    End Property
    Public Property Id_Folio() As Integer
        Get
            Return _id_folio
        End Get
        Set(ByVal value As Integer)
            _id_folio = value
        End Set
    End Property

End Class
