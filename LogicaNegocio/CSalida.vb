Public Class CSalida
    Private _id As Integer
    Private _id_usuario As Integer
    Private _fecha As Date
    Private _nom_usu As String
    Public _salidaitems As List(Of CSalidaDetalle)

    Public Sub New(ByVal id_salida As Integer, ByVal fecha_salida As Date, ByVal id_usuario As Integer)
        Me.Id = id_salida
        Me.Fecha = fecha_salida
        Me.Usuario = id_usuario
    End Sub
    Public Sub New(ByVal id_salida As Integer, ByVal nom_usu As String, ByVal fecha_salida As Date, ByVal id_usuario As Integer)
        Me.Id = id_salida
        Me.Fecha = fecha_salida
        Me.Usuario = id_usuario
        Me.NomUsuario = nom_usu
    End Sub

    Public Sub AgregarItemSalida(ByVal item As CSalidaDetalle)
        Dim add As Boolean = True
        If _salidaitems.Count = 0 Then
            _salidaitems.Add(item)
        Else
            For Each i As CSalidaDetalle In _salidaitems
                If i.Producto.Id = item.Producto.Id Then
                    If (i.Cantidad + item.Cantidad) <= item.Producto.Existencia Then
                        add = False
                        i.Cantidad += item.Cantidad
                        i.Costo = item.Costo
                        Exit For
                    Else
                        add = False
                        Exit For
                    End If
                End If
            Next
            If add = True Then
                _salidaitems.Add(item)
            End If
        End If
    End Sub
    Public Function BorraItem(ByVal clave As String) As Boolean
        For Each it As CSalidaDetalle In _salidaitems
            If it.Producto.Codigo = clave Then
                _salidaitems.Remove(it)
                Return True
            End If
        Next
        Return False
    End Function
    Sub New()
        _salidaitems = New List(Of CSalidaDetalle)
    End Sub
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property
    Public Property NomUsuario() As String
        Get
            Return _nom_usu
        End Get
        Set(ByVal value As String)
            _nom_usu = value
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
    Public Property ItemsS() As List(Of CSalidaDetalle)
        Get
            Return _salidaitems
        End Get
        Set(ByVal value As List(Of CSalidaDetalle))
            _salidaitems = value
        End Set
    End Property
End Class
