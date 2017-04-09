Imports System.ComponentModel
Public Class opPromocionesPieza

    Private _promo As BindingList(Of PromocionPieza)


    Sub New(ByVal num As Integer)
        _promo = New BindingList(Of PromocionPieza)
        Obten(num)
    End Sub

    Private Sub CargaItems()
        Try
            Dim cat As New Service_PromocionPieza
            Promociones = cat.obtenerPromociones
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub CargActivos()
        Try
            Dim cat As New Service_PromocionPieza
            Promociones = cat.obtenerActivos
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function ExisteEnpromocion(ByVal promo As PromocionPieza) As eProducto

        Dim consulta = From c In _promo Where c.Fecha_Final > Date.Now And c.Producto.Id = promo.Producto.Id _
        Select c.Id
        If consulta.ToList.Count > 0 Then
            Return eProducto.ProductoNormal
        End If
        Dim consulta2 = From c In _promo Where c.Fecha_Final > Date.Now And c.ProductoRegalo.Id = promo.ProductoRegalo.Id _
        Select c.Id
        If consulta2.ToList.Count > 0 Then
            Return eProducto.Regalo
        End If
        Return eProducto.None
    End Function


    Public Function Save(ByVal promo As PromocionPieza) As Boolean
        If promo.Producto.Id = 0 Or promo.ProductoRegalo.Id = 0 Then
            MsgBox("Seleccione un producto")
            Return False
        End If
        If promo.Cantidad = 0 Or promo.CantidadRegalada = 0 Then
            MsgBox("La cantidad no puede ir en cero")
            Return False
        End If
        Dim pro As eProducto = ExisteEnpromocion(promo)
        If pro = eProducto.ProductoNormal Then
            MsgBox("El producto " & promo.Producto.Descripcion & " ya se encuentra en una promoción")

            Return False
        ElseIf pro = eProducto.Regalo Then
            MsgBox("El producto " & promo.ProductoRegalo.Descripcion & " ya se encuentra en una promoción")
            Return False
        End If
        Try
            Dim se As New opPromociones(1)

            For Each item In se.Promociones
                If item.Producto.Id = promo.Producto.Id Or item.Producto.Id = promo.Producto.Id Then
                    MsgBox("El producto " & item.Producto.Descripcion & " ya se encuentra en una promoción")

                    se = Nothing
                    Return False
                End If

            Next
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try

        Try

            Dim cat As New Service_PromocionPieza
            cat.Agregar(promo)
            Promociones.Add(promo)
            MsgBox("Promocion creada")
            Return True
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Sub Delete(ByVal id As Integer)

        Dim cat As New Service_PromocionPieza
        cat.delete(id)


    End Sub
    Public Sub Obten(ByVal id As Integer)

        Try
            If id = 0 Then
                CargaItems()
            Else
                CargActivos()
            End If
        Catch ex As ReglasNegocioException

        Catch ex As Exception

        End Try
    End Sub

    Public Property Promociones() As BindingList(Of PromocionPieza)
        Get
            Return _promo
        End Get
        Set(ByVal value As BindingList(Of PromocionPieza))
            _promo = value
        End Set
    End Property


    Enum eProducto
        Regalo
        ProductoNormal
        None
    End Enum

End Class
