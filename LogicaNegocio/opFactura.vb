
Public Class opFactura

    Private service As Service_Venta
    Private _devolucion As Devolucion
    Private _cliente As Cliente
    Private servicecliente As Service_Cliente
    Private sfacturas As Service_Factura
    Private sfolios As Service_Folios
    Private folionuevo As Integer
    Private _foliosactuales As Folio

    Sub New()
        service = New Service_Venta
        servicecliente = New Service_Cliente
        sfacturas = New Service_Factura
        sfolios = New Service_Folios
        folionuevo = -1
    End Sub


    Public Function obtenerVenta(ByVal id As Integer) As Devolucion
        Try

            Venta = service.Obtener(id)
            Cliente = obtenerCliente(IdCliente)
            folionuevo = -1
            Return Venta
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Function obtenerFacturas() As List(Of Factura)
        Try

            Return sfacturas.VerFacturas
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Function obtenerCliente(ByVal id As Integer) As Cliente
        Return servicecliente.Obtener(id)
    End Function
    Public Function estaFacturada(ByVal id_venta As Integer) As Boolean
        Try

            Return sfacturas.checarVenta(id_venta)
        Catch fb As ReglasNegocioException
            MsgBox(fb.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function

    Public Function ObtenerFolioporId(ByVal id As Integer)
        Try
            Dim folio As Folio = sfolios.ObtenerFoliosId(id)
            Return folio
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Function FoliosActivos() As Folio
        Try
            Dim folio As Folio = sfolios.ObtenerFoliosActivos
            If folio Is Nothing Then
                MsgBox("No hay Folios")
                Return Nothing
            End If
            If folio.Folios_Usados = folio.Numero_Folios Then
                MsgBox("Ya no hay folios")
                Return Nothing
            End If
            Return folio
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Function Facturar() As Boolean
        Try
            Dim folio As Folio = sfolios.ObtenerFoliosActivos
            If folio Is Nothing Then
                MsgBox("No hay Folios")
                Return False
            End If
            If folio.Folios_Usados = folio.Numero_Folios Then
                MsgBox("Ya no hay folios")
                Return False
            End If
            If estaFacturada(_devolucion.Id) Then
                MsgBox("Esta venta ya se facturo")
                Return False
            End If
            Dim fact As New Factura(-1, _devolucion.Id, Date.Now, "0", -1, folio.Id)
            folionuevo = sfacturas.guardarFactura(fact, folio)
            _foliosactuales = folio
            Return True
        Catch fb As ReglasNegocioException
            MsgBox(fb.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function
    Public ReadOnly Property Folio() As Folio
        Get
            Return _foliosactuales
        End Get
    End Property


    Public Function CambiarCliente(ByVal id_cliente As Integer) As Boolean
        Try
            service.CambiaCliente(Venta.Id, id_cliente)
            MsgBox("Cliente Cambiado")
            Return True
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function
    Public Property Cliente() As Cliente
        Get
            Return _cliente
        End Get
        Set(ByVal value As Cliente)
            _cliente = value
        End Set
    End Property

    Public Property IdCliente() As Integer
        Get
            Return Venta.Id_Venta
        End Get
        Set(ByVal value As Integer)
            Venta.Id_Venta = value
        End Set
    End Property
    Public Property Venta() As Devolucion
        Get
            Return _devolucion
        End Get
        Set(ByVal value As Devolucion)
            _devolucion = value
        End Set
    End Property
    Public ReadOnly Property NumFolio() As Integer
        Get
            Return folionuevo
        End Get
    End Property
End Class
