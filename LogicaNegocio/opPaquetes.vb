Imports System.ComponentModel
Public Class opPaquetes

    Private paquete As Paquete

    Sub New()
        paquete = New Paquete
    End Sub
    Sub New(ByVal paq As Paquete)
        Me.paquete = paq
    End Sub
    Public ReadOnly Property Paq() As Paquete
        Get
            Return paquete
        End Get
    End Property

    Public Function crearPaquetes2(Optional ByVal guardado As Boolean = False) As Integer
        Dim paqaarmar As Integer = 0


        For Each item As ItemPaquete In paquete.Items
            If item.Producto.Existencia = 0 Then
                paqaarmar = 0
                Exit For
            End If
            Dim armar As Integer = Math.Floor((item.Producto.Existencia / item.Cantidad))
            If paqaarmar = 0 Then
                paqaarmar = armar
                Continue For
            End If
            If paqaarmar > armar Then
                paqaarmar = armar
            End If
        Next
        Paq.PaqArmar = paqaarmar
        If guardado Then
            Total()
        End If
        Return paqaarmar
    End Function

    Public Function crearPaquetes(Optional ByVal guardado As Boolean = False) As Integer
        Dim paqaarmar As Integer = 0


        For Each item As ItemPaquete In paquete.Items
            If item.Cantidad = 0 Then
                MsgBox("Cantidad a armar no puede ser 0")
                paqaarmar = 0
                Exit For
            End If
            If item.Cantidad > item.Producto.Existencia Then
                MsgBox("Cantidad no debe ser mayor a existencia")
                paqaarmar = 0
                Exit For
            End If
            If item.Producto.Existencia = 0 Then
                paqaarmar = 0
                Exit For
            End If
            Dim armar As Integer = Math.Floor((item.Producto.Existencia / item.Cantidad))
            If paqaarmar = 0 Then
                paqaarmar = armar
                Continue For
            End If
            If paqaarmar > armar Then
                paqaarmar = armar
            End If
        Next
        Paq.PaqArmar = paqaarmar
        If guardado Then
            Total()
        End If
        Return paqaarmar
    End Function
    Public Function ObtenerItems() As BindingList(Of ItemPaquete)
        Return paquete.Items
    End Function
    Public Sub Total()

        Dim costo As Decimal
        Dim precio As Decimal
        For Each item As ItemPaquete In paquete.Items
            costo += item.Producto.Costo * item.Cantidad
            precio += item.Producto.Precio * item.Cantidad
        Next
        Paq.Costo = costo
        Paq.Precio = precio

    End Sub

    Public Sub AddProducto(ByVal prod As Producto, Optional ByVal cant As Integer = 1)
        Dim item As New ItemPaquete(prod)
        paquete.Items.Add(item)
        item.Cantidad = cant
        Total()
    End Sub
    Public Sub Save(ByVal narmar As String)

        If Paq.Id = -1 Then


            If Paq.Items.Count = 0 Then
                Throw New Exception("No hay productos en el paquete")
            End If

            For Each item As ItemPaquete In paquete.Items
                If item.Cantidad > item.Producto.Existencia Then
                    Throw New Exception("La cantidad del producto " & item.Producto.Descripcion & " es mayor a la existencia")
                    Exit For
                End If

            Next

            If narmar.Trim = "" Then

                Armar(crearPaquetes)

            ElseIf CInt(narmar) > crearPaquetes() Then
                Throw New Exception("No se pueden completar " + narmar + " paquetes")
            Else
                Armar(CInt(narmar))
            End If
        Else
            Actualiza()
        End If

    End Sub
    Private Sub Actualiza()
        Try
            Dim cat As New Service_Paquete
            cat.Actualiza(Paq)
            MsgBox("Paquete Actualizado")

        Catch ex As ReglasNegocioException
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Armar(ByVal cantidad As Integer)

        Try
            Dim cat As New Service_Paquete
            cat.crearPaquete(Paq, cantidad)
            If Paq.Descripcion.Trim = "" Then
                Throw New ReglasNegocioException("Descripcion es requerida")
            ElseIf Paq.Codigo.Trim = "" Then
                Throw New ReglasNegocioException("Codigo es requerido")
            End If
            Paq.Existencia = cantidad
            MsgBox("Paquete Agregado")

        Catch ex As ReglasNegocioException
            Paq.Id = -1
            Throw New Exception(ex.Message)
            Paq.Id = -1
        Catch ex As Exception
            Paq.Id = -1
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Function ObtenerPaquete(ByVal producto As Producto) As Paquete
        Try
            Dim cat As New Service_Paquete
            Return cat.obtenerPaquete(producto)
        Catch ex As ReglasNegocioException
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub AddPaquetes(ByVal narmar As String)


        If narmar.Trim = "" Then
            SumarPaquetes(crearPaquetes)
        ElseIf CInt(narmar) > crearPaquetes2() Then
            Throw New Exception("No se pueden completar " + narmar + " paquetes")
        Else
            SumarPaquetes(CInt(narmar))
        End If
    End Sub

    Private Sub SumarPaquetes(ByVal cantidad As Integer)

        Try
            Dim cat As New Service_Paquete
            cat.sumarPaquetes(Paq, cantidad)
            Paq.Existencia = Paq.Existencia + cantidad

        Catch ex As ReglasNegocioException
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub Deshacer(ByVal cantidad As Integer)
        Try
            If Paq.Existencia < cantidad Then
                MsgBox("No hay esa cantidad de paquetes")
                Exit Sub
            End If
            Dim cat As New Service_Paquete
            cat.Desarmar(Paq, cantidad)
            Paq.Existencia = Paq.Existencia - cantidad

        Catch ex As ReglasNegocioException
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
