Imports System.ComponentModel
Public Class opServicio

    Private servicio As ServicioP

    Sub New()
        servicio = New ServicioP
    End Sub
    Sub New(ByVal se As ServicioP)
        Me.servicio = se
    End Sub
    Public ReadOnly Property Serv() As ServicioP
        Get
            Return servicio
        End Get
    End Property

    Public Function ObtenerItems() As BindingList(Of ItemServicio)
        Return servicio.Items
    End Function

    Public Function yaExiste(ByVal prod As Producto) As Boolean

        For Each iten In servicio.Items
            If iten.Id_Producto = prod.Id Then
                Return True
            End If
        Next
        Return False
    End Function



    Public Sub AddProducto(ByVal prod As Producto)


        If yaExiste(prod) Then
            MsgBox("Ya existe el producto")
            Exit Sub
        End If
        If Serv.Id = -1 Then
            Dim item As New ItemServicio(prod)
            servicio.Items.Add(item)
        Else
            Try
                Dim servici As New Service_ServicioP
                Dim item As New ItemServicio(prod)
                servici.agregaItem(item, Serv.Id)
                servicio.Items.Add(item)
            Catch ex As ReglasNegocioException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
    Public Sub Save()

        If Serv.Id = -1 Then

            If servicio.Items.Count = 0 Then
                Throw New Exception("No hay productos en el servicio")
            End If
            Crear()
            MsgBox("Servicio Agregado")

        Else
            Actualiza()
            MsgBox("Servicio Actualizado")

        End If

    End Sub
    Private Sub Actualiza()
        Try
            Dim cat As New Service_ServicioP
            cat.Actualiza(Serv)
        Catch ex As ReglasNegocioException
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Crear()

        Try
            Dim cat As New Service_ServicioP
            cat.crearServicio(Serv)
        Catch ex As ReglasNegocioException
            Serv.Id = -1
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Serv.Id = -1
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Function ObtenerServicio(ByVal producto As Producto) As ServicioP
        Try
            Dim cat As New Service_ServicioP
            Return cat.obtenerServicio(producto)
        Catch ex As ReglasNegocioException
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Borrar(ByVal id As Integer)

        Try
            If Serv.Id <> -1 Then
                Dim serv As New Service_ServicioP
                serv.borraItem(id)
            End If
        Catch ex As ReglasNegocioException
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
