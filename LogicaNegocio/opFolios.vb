Imports LogicaNegocio
Public Class opFolios

    Private service As Service_Folios
    Private _folios As List(Of Folio)

    Sub New()
        service = New Service_Folios
        _folios = obtener()
    End Sub

    Private Function obtener() As List(Of Folio)

        Try
            _folios = service.ObtenerTodosFolios
            Return Folios
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Function AgregarFolios(ByVal folio As Folio) As Boolean

        Try
            service.AgregarFolios(folio)
            _folios.Add(folio)
            Return True
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function
    Public Function ActivarFolios(ByVal id As Integer) As Boolean

        If hayActivos() Then
            MsgBox("Ya existen folios activos")
        Else
            Try
                service.ActivarFolios(id)
                Activar(id)
                MsgBox("Folios Activados")
                Return True
            Catch ex As ReglasNegocioException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Return False
    End Function
    Public Function DesActivarFolios(ByVal id As Integer) As Boolean

        If estaactivo(id) Then
            MsgBox("No esta activo")
        Else
            Try
                service.DesactivarFolios(id)
                DesActivar(id)
                MsgBox("Folios Des Activados")
                Return True
            Catch ex As ReglasNegocioException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Return False
    End Function
    Private Sub Activar(ByVal id As Integer)
        For Each item In Folios
            If item.Id = id Then
                item.Estatus = "1"
                Exit For
            End If
        Next
    End Sub
    Private Sub DesActivar(ByVal id As Integer)
        For Each item In Folios
            If item.Id = id Then
                item.Estatus = "0"
                Exit For
            End If
        Next
    End Sub
    Private Function hayActivos() As Boolean

        For Each item In Folios
            If item.Estatus = "1" Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function estaactivo(ByVal id As Integer) As Boolean

        For Each item In Folios
            If item.Id = id Then
                If item.Estatus = "0" Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function



    Public ReadOnly Property Folios() As List(Of Folio)
        Get
            Return _folios
        End Get
    End Property

End Class
