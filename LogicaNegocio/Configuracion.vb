Public Class Configuracion
    Private _propietario As String
    Private _sistema As String
    Private _rfc As String
    Private _calle As String
    Private _no_int As String
    Private _no_ext As String
    Private _colonia As String
    Private _ciudad As String
    Private _id_estado As Integer
    Private _cp As String
    Private _telefono As String
    Private _iva As Decimal
    Private _saludo As String
    Private _porcentaje As Decimal
    Private _dias As Integer
    Public estado As String
    Private _impresora As String
    Private _venderSinExistencias As Boolean
    Private _imprimeTicket As Boolean
    Private _imagen As String
    Private _cajon As Boolean

    Private _porcentaje_Medio As Decimal
    Private _porcentaje_Menudeo As Decimal
    Private _precio_Empaque As Decimal

    Sub New()

    End Sub
    Sub New(ByVal propietario As String, ByVal sistema As String, ByVal rfc As String, ByVal calle As String, ByVal no_int As String, ByVal no_ext As String, ByVal colonia As String, ByVal ciudad As String, ByVal id_estado As Integer, ByVal cp As String, ByVal telefono As String, ByVal iva As Decimal, ByVal saludo As String, ByVal porcentaje As Decimal, ByVal dias As Integer, ByVal impresora As String, ByVal vender As Boolean, ByVal imprimeTicket As Boolean, ByVal cajon As Boolean, ByVal porcentajeMedio As Decimal, ByVal porcentajeMenudeo As Decimal, ByVal precioEmpaque As Decimal, Optional ByVal imagen As String = "")
        Me.Propietario = propietario
        Me.Sistema = sistema
        Me.RFC = rfc
        Me.Calle = calle
        Me.No_int = no_int
        Me.No_ext = no_ext
        Me.Colonia = colonia
        Me.Ciudad = ciudad
        Me.Id_estado = id_estado
        Me.CP = cp
        Me.Telefono = telefono
        Me.IVA = iva
        Me.Saludo = saludo
        Me.Porcentaje = porcentaje
        Me.Dias = dias
        Me.Impresora = impresora
        Me.VenderSinExistencias = vender
        Me.ImprimeTicket = imprimeTicket
        Me.Cajon = cajon
        Me.Imagen = imagen
        Me.Porcentaje_Medio = porcentajeMedio
        Me.Porcentaje_Menudeo = porcentajeMenudeo
        Me.Precio_Empaque = precioEmpaque
    End Sub
    
    Public Property Imagen() As String
        Get
            Return _imagen
        End Get
        Set(ByVal value As String)
            _imagen = value
        End Set
    End Property
    Public Property Impresora() As String
        Get
            Return _impresora
        End Get
        Set(ByVal value As String)
            _impresora = value
        End Set
    End Property
    Public Property Propietario() As String
        Get
            Return _propietario
        End Get
        Set(ByVal value As String)
            _propietario = value
        End Set
    End Property
    Public Property Sistema() As String
        Get
            Return _sistema
        End Get
        Set(ByVal value As String)
            _sistema = value
        End Set
    End Property
    Public Property RFC() As String
        Get
            Return _rfc
        End Get
        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    Public Property Calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal value As String)
            _calle = value
        End Set
    End Property
    Public Property No_int() As String
        Get
            Return _no_int
        End Get
        Set(ByVal value As String)
            _no_int = value
        End Set
    End Property
    Public Property No_ext() As String
        Get
            Return _no_ext
        End Get
        Set(ByVal value As String)
            _no_ext = value
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return _colonia
        End Get
        Set(ByVal value As String)
            _colonia = value
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return _ciudad
        End Get
        Set(ByVal value As String)
            _ciudad = value
        End Set
    End Property
    Public Property Id_estado() As String
        Get
            Return _id_estado
        End Get
        Set(ByVal value As String)
            _id_estado = value
        End Set
    End Property
    Public Property CP() As String
        Get
            Return _cp
        End Get
        Set(ByVal value As String)
            _cp = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
    Public Property IVA() As Decimal
        Get
            Return _iva
        End Get
        Set(ByVal value As Decimal)
            _iva = value
        End Set
    End Property
    Public Property Saludo() As String
        Get
            Return _saludo
        End Get
        Set(ByVal value As String)
            _saludo = value
        End Set
    End Property
    Public Property Porcentaje()
        Get
            Return _porcentaje
        End Get
        Set(ByVal value)
            _porcentaje = value
        End Set
    End Property
    Public Property Dias() As Integer
        Get
            Return _dias
        End Get
        Set(ByVal value As Integer)
            _dias = value
        End Set
    End Property
    Public Property VenderSinExistencias() As Boolean
        Get
            Return _venderSinExistencias
        End Get
        Set(ByVal value As Boolean)
            _venderSinExistencias = value
        End Set
    End Property

    Public Property ImprimeTicket() As Boolean
        Get
            Return _imprimeTicket
        End Get
        Set(ByVal value As Boolean)
            _imprimeTicket = value
        End Set
    End Property
    Public Property Cajon() As Boolean
        Get
            Return _cajon
        End Get
        Set(ByVal value As Boolean)
            _cajon = value
        End Set
    End Property
    Public Property Porcentaje_Medio() As Decimal
        Get
            Return _porcentaje_Medio
        End Get
        Set(ByVal value As Decimal)
            _porcentaje_Medio = value
        End Set
    End Property
    Public Property Porcentaje_Menudeo() As Decimal
        Get
            Return _porcentaje_Menudeo
        End Get
        Set(ByVal value As Decimal)
            _porcentaje_Menudeo = value
        End Set
    End Property
    Public Property Precio_Empaque() As Decimal
        Get
            Return _precio_Empaque
        End Get
        Set(ByVal value As Decimal)
            _precio_Empaque = value
        End Set
    End Property
   End Class
