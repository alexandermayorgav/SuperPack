Imports System.ComponentModel
Public Class opPromociones

    Private _promo As BindingList(Of Promocion)


    Sub New(ByVal num As Integer)
        _promo = New BindingList(Of Promocion)
        Obten(num)
    End Sub

    Private Sub CargaItems()
        Try
            Dim cat As New Service_Promocion
            Promociones = cat.obtenerPromociones
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub CargActivos()
        Try
            Dim cat As New Service_Promocion
            Promociones = cat.obtenerActivos
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ExisteEnpromocion(ByVal promo As Promocion) As Boolean

        Dim consulta = From c In _promo Where c.Fecha_Final > Date.Now And c.Producto.Id = promo.Producto.Id _
        Select c.Id
        If consulta.ToList.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Save(ByVal promo As Promocion) As Boolean

        If promo.Cantidad = 0 Then
            MsgBox("Cantidad no deber ser cero")
            Return False
        End If

        If promo.Producto.Id = 0 Then
            MsgBox("Seleccione un producto")
            Return False
        End If
        If promo.Descuento = 0 Then
            MsgBox("El descuento no puede ser cero")
            Return False
        End If
        If ExisteEnpromocion(promo) Then
            MsgBox("Ya esta este producto en una promocion")
            Return False
        End If
        Try
            Dim se As New opPromocionesPieza(1)

            For Each item In se.Promociones
                If item.Producto.Id = promo.Producto.Id Or item.ProductoRegalo.Id = promo.Producto.Id Then
                    MsgBox("Ya esta este producto en una promocion")
                    se = Nothing
                    Return False
                End If

            Next
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Try

            Dim cat As New Service_Promocion
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

        Dim cat As New Service_Promocion
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

    Public Property Promociones() As BindingList(Of Promocion)
        Get
            Return _promo
        End Get
        Set(ByVal value As BindingList(Of Promocion))
            _promo = value
        End Set
    End Property



End Class
