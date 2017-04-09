
Public Class opTraspaso

    Private service As Service_Traspaso
    Private serviceproducto As Service_Producto
    Private items As List(Of Traspaso)
    Private item As Traspaso

    Sub New()
        service = New Service_Traspaso
        serviceproducto = New Service_Producto
        items = New List(Of Traspaso)
    End Sub

    Sub Reiniciar()
        items = New List(Of Traspaso)
    End Sub

    'Public Function verItem(ByVal prod As Producto) As Traspaso
    '    Try
    '        If prod.IDCAJA <> 0 Then
    '            Dim pr As Producto = serviceproducto.ObtenerPorId(prod.IDCAJA)
    '            item = New Traspaso
    '            item.Caja = pr
    '            item.Producto = prod
    '            Return item
    '        Else
    '            Throw New Exception("Este producto no esta asociado a una caja")
    '        End If

    '    Catch ex As ReglasNegocioException
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    End Try

    'End Function

    Public Sub AddPaquete(ByVal producto As Producto)

        If ItemActual Is Nothing Then
            item = New Traspaso
        End If
        item.Producto = producto
    End Sub

    Public Function CalculaSobrantes(ByVal cajas As Decimal, ByVal paquetes As Decimal) As Integer

        If ItemActual IsNot Nothing Then
            If ItemActual.Producto Is Nothing Or ItemActual.Caja Is Nothing Then
                ItemActual.Sobrantes = -1
                Return -1
            End If
            Dim cajapiezas As Decimal
            Dim cantidaddepiezas As Decimal
            Dim restantes As Decimal

            cajapiezas = cajas * item.Caja.Piezas
            If cajapiezas < item.Producto.Piezas Then
                ItemActual.Sobrantes = -1
                Return -1
            End If
            cantidaddepiezas = paquetes * item.Producto.Piezas
            restantes = cajapiezas - cantidaddepiezas
            ItemActual.Sobrantes = restantes
            If restantes < 0 Then
                ItemActual.Sobrantes = -1
                Return -1
            End If
            Return restantes

        Else
            '  ItemActual.Sobrantes = -1
            Return -1
        End If
    End Function

    Public Function TotalPaquetes(Optional ByVal cajas As Integer = 0) As Integer
        If cajas = 0 Then
            Return 0
        End If
        If ItemActual IsNot Nothing Then
            If ItemActual.Producto Is Nothing Or ItemActual.Caja Is Nothing Then
                Return 0
            End If
            'Dim cajapiezas As Decimal
            'Dim cantidaddepiezas As Decimal
            'Dim restantes As Decimal

            'cajapiezas = item.Cajas_Abiertas * item.Caja.Piezas
            'cantidaddepiezas = item.Cantidad_Paquetes * item.Producto.Piezas
            'restantes = cajapiezas - cantidaddepiezas
            'ItemActual.Sobrantes = restantes
            Return Math.Floor((item.Caja.Piezas * cajas) / item.Producto.Piezas)
        Else
            Return 0
        End If
    End Function
    Public Sub AddCaja(ByVal producto As Producto)

        If ItemActual Is Nothing Then
            item = New Traspaso
        End If
        item.Caja = producto
    End Sub

    Public Property ItemActual() As Traspaso
        Get
            Return item
        End Get
        Set(ByVal value As Traspaso)
            item = value
        End Set
    End Property
    Public Function ItemsTraspaso() As List(Of Traspaso)
        Return items
    End Function
    Public Function Guardar() As Boolean
        Try
            If items.Count = 0 Then
                Throw New Exception("No hay productos para traspasar")
            End If
            service.ProcesarTraspaso(items)
            MsgBox("Traspaso realizado")
            Return True
        Catch EX As ReglasNegocioException
            MsgBox(EX.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub BorrarItem(ByVal idcaja As Integer)
        For Each it In items
            If it.Caja.Id = idcaja Then
                items.Remove(it)
                Exit For
            End If
        Next
    End Sub

    Public Function existe(ByVal item As Traspaso) As Boolean
        For Each it In items
            If it.Producto.Id = item.Producto.Id Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub AgregarTraspaso(ByVal paquete As Decimal, ByVal caja As Decimal)
        If existe(item) Then
            MsgBox("Este item ya existe")
            Exit Sub
        End If
        item.Cantidad_Paquetes = paquete
        item.Cajas_Abiertas = caja
        items.Add(item)
        item = New Traspaso
    End Sub


End Class
