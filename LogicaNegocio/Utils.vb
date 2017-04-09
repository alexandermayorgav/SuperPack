Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms

Public Class Utils
    Public Shared Function ObtenerFechaHora(ByVal fechaaconvertir As Date) As String
        Dim fecha As String = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", fechaaconvertir)
        Return fecha
    End Function

    'Este sirve para las consultas
  
    Public Shared Function ObtenerFechaHora24Horas(ByVal fechaaconvertir As Date) As String
        Dim fecha As String = String.Format("{0:MM/dd/yyyy HH:mm:ss }", fechaaconvertir)
        Return fecha
    End Function

    Public Shared Function ObtenerFecha(ByVal fechaaconvertir As Date) As String

        'Dim newfecha As String
        'Dim fecha() As String
        'fecha = Split(String.Format("{0:yyyy/MM/dd}", fechaaconvertir), "/")

        'newfecha = fecha(0).ToString & fecha(1).ToString & fecha(2).ToString
        ''para que tambien guarde la hora' & " " & fechaaconvertir.Hour & ":" & fechaaconvertir.Minute & ":" & fechaaconvertir.Second
        Dim fecha As String = String.Format("{0:dd/MM/yyyy}", fechaaconvertir)
        Return fecha
    End Function
    Public Shared Function ObtenerFechaCorrecta(ByVal fechaaconvertir As Date) As String

        Dim newfecha As String
        Dim fecha() As String
        fecha = Split(String.Format("{0:dd/MM/yyyy", fechaaconvertir), "/")

        newfecha = fecha(0).ToString & fecha(1).ToString & fecha(2).ToString
        'para que tambien guarde la hora' & " " & fechaaconvertir.Hour & ":" & fechaaconvertir.Minute & ":" & fechaaconvertir.Second
        Return newfecha
    End Function
    Public Shared Function Num2Text(ByVal value As Double) As String
        Try
            Select Case value
                Case 0 : Num2Text = "CERO"
                Case 1 : Num2Text = "UN"
                Case 2 : Num2Text = "DOS"
                Case 3 : Num2Text = "TRES"
                Case 4 : Num2Text = "CUATRO"
                Case 5 : Num2Text = "CINCO"
                Case 6 : Num2Text = "SEIS"
                Case 7 : Num2Text = "SIETE"
                Case 8 : Num2Text = "OCHO"
                Case 9 : Num2Text = "NUEVE"
                Case 10 : Num2Text = "DIEZ"
                Case 11 : Num2Text = "ONCE"
                Case 12 : Num2Text = "DOCE"
                Case 13 : Num2Text = "TRECE"
                Case 14 : Num2Text = "CATORCE"
                Case 15 : Num2Text = "QUINCE"
                Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
                Case 20 : Num2Text = "VEINTE"
                Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
                Case 30 : Num2Text = "TREINTA"
                Case 40 : Num2Text = "CUARENTA"
                Case 50 : Num2Text = "CINCUENTA"
                Case 60 : Num2Text = "SESENTA"
                Case 70 : Num2Text = "SETENTA"
                Case 80 : Num2Text = "OCHENTA"
                Case 90 : Num2Text = "NOVENTA"
                Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
                Case 100 : Num2Text = "CIEN"
                Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
                Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
                Case 500 : Num2Text = "QUINIENTOS"
                Case 700 : Num2Text = "SETECIENTOS"
                Case 900 : Num2Text = "NOVECIENTOS"
                Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
                Case 1000 : Num2Text = "MIL"
                Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
                Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                    If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
                Case 1000000 : Num2Text = "UN MILLON"
                Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
                Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                    If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
                Case 1000000000000.0# : Num2Text = "UN BILLON"
                Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
                Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                    If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        

    End Function

    Public Shared Function obtenerFechaFormatoExtendido(ByVal fecha As Date) As String
        Dim fechaFormato As String = ""
        Dim arrFecha() As String
        Dim arrAnio() As String
        Dim anio As Integer = 0
        arrFecha = Split(fecha, "/")
        arrAnio = Split(arrFecha(2), " ")
        anio = arrAnio(0)

        fechaFormato = arrFecha(0) & " de " & obtenerMes(arrFecha(1)) & " de " & anio
        Return fechaFormato
    End Function
    Public Shared Function obtenerFechaFormatoExtendidoSinAnio(ByVal fecha As Date) As String
        Dim fechaFormato As String = ""
        Dim arrFecha() As String
        Dim arrAnio() As String
        Dim anio As Integer = 0
        arrFecha = Split(fecha, "/")
        arrAnio = Split(arrFecha(2), " ")
        anio = arrAnio(0)

        fechaFormato = arrFecha(0) & " de " & obtenerMes(arrFecha(1))
        Return fechaFormato
    End Function

    Public Shared Function obtenerMes(ByVal numero As Integer) As String
        Dim exc As String = "Error"

        Select Case numero
            Case "01"
                Return "Enero"
            Case "02"
                Return "Febrero"
            Case "03"
                Return "Marzo"
            Case "04"
                Return "Abril"
            Case "05"
                Return "Mayo"
            Case "06"
                Return "Junio"
            Case "07"
                Return "Julio"
            Case "08"
                Return "Agosto"
            Case "09"
                Return "Septiembre"
            Case "10"
                Return "Octubre"
            Case "11"
                Return "Noviembre"
            Case "12"
                Return "Diciembre"
        End Select

        Return exc

    End Function

    'Public Shared Function ObtenerHora(ByVal fechaaconvertir As Date) As String

    '    Dim newfecha As String
    '    Dim fecha() As String
    '    fecha = Split(String.Format("{0:t}", fechaaconvertir), "/")

    '    newfecha = fecha(0).ToString & fecha(1).ToString & fecha(2).ToString & " " & fechaaconvertir.Hour & ":" & fechaaconvertir.Minute & ":" & fechaaconvertir.Second
    '    'para que tambien guarde la hora' & " " & fechaaconvertir.Hour & ":" & fechaaconvertir.Minute & ":" & fechaaconvertir.Second
    '    Return newfecha
    'End Function

    Public Shared Function GenerarHash(ByVal Texto As String) As String
        'Creamos un objeto de codificación Unicode que
        'representa una codificación UTF-16 de caracteres Unicode. 

        Dim Codificar As New UnicodeEncoding()
        'Declaramos una matriz (array) de tipo Byte para recuperar dentro los bytes del texto
        'utilizando el objeto Codificar
        Dim ByteTexto() As Byte = Codificar.GetBytes(Texto)
        'Instanciamos el objeto MD5 
        Dim Md5 As New MD5CryptoServiceProvider()
        'Se calcula el Hash del Texto en bytes 
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteTexto)
        'convertimos el texto 

        Return Convert.ToBase64String(ByteHash)
        'Eliminamos los objetos usados con Nothing
        Codificar = Nothing
        ByteTexto = Nothing

    End Function

    Public Shared Function fechaSinDiagonal(ByVal fechaaconvertir As Date) As String

        Dim newfecha As String
        Dim fecha() As String
        fecha = Split(String.Format("{0:dd/MM/yyyy}", fechaaconvertir), "/")

        newfecha = fecha(0).ToString & fecha(1).ToString & fecha(2).ToString


        Return newfecha
    End Function
    Public Shared Function horaSinPuntos(ByVal horaconvertir As Date) As String

        Dim newHora As String
        Dim hora() As String
        hora = Split(String.Format("{0:hh:mm:ss tt}", horaconvertir), ":")
        newHora = hora(0).ToString & hora(1).ToString & hora(2).ToString

        Return newHora
    End Function
End Class
