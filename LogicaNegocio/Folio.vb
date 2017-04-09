Imports System.ComponentModel
Public Class Folio

    Private _id As Integer
    Private _no_aprobacion As Integer
    Private _fecha As Date
    Private _folios As Integer
    Private _folios_usados As Integer
    Private _sello_digital As String
    Private _sello_digita_sat As String
    Private _cadena_original As String
    Private _estatus As String
    Private _serie As String
    Private _folio_inicial As Integer
    Private _folio_final As Integer
    Private _tipo_comprobante As String
    Private _imagen() As Byte

    Sub New(ByVal id As Integer, ByVal numapro As Integer, ByVal fecha As Date, ByVal folios As Integer, ByVal foliousados As Integer, ByVal sello As String, ByVal estatus As String, ByVal cadena As String, ByVal sellosat As String, ByVal serie As String, ByVal folioinicial As Integer, ByVal folio_final As Integer, ByVal tipocomprobante As String)
        Me.Id = id
        Me.No_Aprobacion = numapro
        Me.Fecha = fecha
        Me.Numero_Folios = folios
        Me.Folios_Usados = foliousados
        Me.Sello_Digital = sello
        Me.Estatus = estatus
        Me.Sello_Digital_Sat = sellosat
        Me.Cadena_Original = cadena
        Me.Serie = serie
        Me.Folio_Inicial = folioinicial
        Me.Folio_Final = folio_final
        Me.Tipo_Comprobante = tipocomprobante
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
    <DisplayName("No. Aprobación")> _
    Public Property No_Aprobacion() As Integer
        Get
            Return _no_aprobacion
        End Get
        Set(ByVal value As Integer)
            If value.ToString.Trim = "" Then
                Throw New Exception("El numero de aprobacion es requerido")
            Else
                _no_aprobacion = value
            End If
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
    <DisplayName("No. Folios")> _
    Public Property Numero_Folios() As Integer
        Get
            Return _folios
        End Get
        Set(ByVal value As Integer)
            _folios = value
        End Set
    End Property
    <DisplayName("Folios Usados")> _
    Public Property Folios_Usados() As Integer
        Get
            Return _folios_usados
        End Get
        Set(ByVal value As Integer)
            _folios_usados = value
        End Set
    End Property
    <DisplayName("Folios Activos")> _
    Public Property Estatus() As String
        Get
            Return _estatus
        End Get
        Set(ByVal value As String)
            _estatus = value
        End Set
    End Property
    <DisplayName("Cadena Original")> _
    Public Property Cadena_Original() As String
        Get
            Return _cadena_original
        End Get
        Set(ByVal value As String)
            If value.ToString.Trim = "" Then
                Throw New Exception("La cadena origninal es rquerida")
            Else
                _cadena_original = value
            End If
        End Set
    End Property
    <DisplayName("Sello Digital")> _
    Public Property Sello_Digital() As String
        Get
            Return _sello_digital
        End Get
        Set(ByVal value As String)
            If value.ToString.Trim = "" Then
                Throw New Exception("El sello digital es requerido")
            Else
                _sello_digital = value
            End If
        End Set
    End Property
    <DisplayName("Sello Digital Sat")> _
    Public Property Sello_Digital_Sat() As String
        Get
            Return _sello_digita_sat
        End Get
        Set(ByVal value As String)
            If value.ToString.Trim = "" Then
                Throw New Exception("El sello digital del sat es requerido")
            Else
                _sello_digita_sat = value
            End If
        End Set
    End Property
    <DisplayName("Serie")> _
    Public Property Serie() As String
        Get
            Return _serie
        End Get
        Set(ByVal value As String)
            If value.ToString.Trim = "" Then
                Throw New Exception("La serie es requerida")
            Else
                _serie = value
            End If
        End Set
    End Property
    <DisplayName("Folio Inicial")> _
    Public Property Folio_Inicial() As Integer
        Get
            Return _folio_inicial
        End Get
        Set(ByVal value As Integer)
            If value.ToString.Trim = "" Then
                Throw New Exception("El folio inicial es requerido")
            Else
                _folio_inicial = value
            End If
        End Set
    End Property
    <DisplayName("Folio Final")> _
    Public Property Folio_Final() As Integer
        Get
            Return _folio_final
        End Get
        Set(ByVal value As Integer)
            If value.ToString.Trim = "" Then
                Throw New Exception("El folio final es requerido")
            Else
                _folio_final = value
            End If
        End Set
    End Property
    <DisplayName("Tipo Comprobante")> _
    Public Property Tipo_Comprobante() As String
        Get
            Return _tipo_comprobante
        End Get
        Set(ByVal value As String)
            If value.ToString.Trim = "" Then
                Throw New Exception("El tipo de comprobante es requerido")
            Else
                _tipo_comprobante = value
            End If
        End Set
    End Property
    <DisplayName("Codigo Bidimensional")> _
    Public Property Imagen() As Byte()
        Get
            Return _imagen
        End Get
        Set(ByVal value() As Byte)
            _imagen = value
        End Set
    End Property


End Class
