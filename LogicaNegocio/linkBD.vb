Imports AccesoDatos
Public Class linkBD
    Public nombreBaseDatos As String
    Public nombreUsuario As String
    Public password As String
    Public dataSource As String
    Public absNombreBaseDatos As String
    Dim fecha As Date = Date.Now
    Public nombreCopiaSeguridad As String
    Public Const servertype As Integer = 0
    Public nombreGDKBaseDatos As String
    Public Sub obtenerDatos()
        Dim db As BaseDatos = Nothing
        db = New BaseDatos

        nombreBaseDatos = db._db
        nombreUsuario = db._userid
        password = db._passworddb
        dataSource = db._ds

        Dim x As Integer
        Dim nnom As Array
        nnom = Split(nombreBaseDatos, "\")

        For i As Integer = 0 To nnom.Length - 1
            x = i
        Next


        absNombreBaseDatos = nnom(x) 'Nombre de la base de datos sin ruta

        Dim y As Integer
        Dim nnomgdk As Array
        nnomgdk = Split(nombreBaseDatos, ".")
        For w As Integer = 0 To nnomgdk.Length - 1
            y = w
        Next

        nombreGDKBaseDatos = nnomgdk(y - 1) 'Nombre de la base de datos sin extensión

        'MsgBox(nombreGDKBaseDatos)

        nombreCopiaSeguridad = Utils.fechaSinDiagonal(fecha) & "-" & Utils.horaSinPuntos(fecha) & "-CopiaSeguridad.gdk"

        ' MsgBox(nombreCopiaSeguridad)

    End Sub

End Class
