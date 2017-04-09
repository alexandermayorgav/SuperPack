Imports System.Text.RegularExpressions

Public Class CValidation

    Public Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        ' teclas adicionales permitidas
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii 'Backspace
            Case 13
                SoloNumeros = Keyascii 'Enter
        End Select
    End Function
    Public Function SoloLetras(ByVal Keyascii) As Integer
        Keyascii = Asc(UCase(Chr(Keyascii)))
        If InStr("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ. /-,", Chr(Keyascii)) = 0 Then
            SoloLetras = 0
        Else
            SoloLetras = Keyascii
        End If
        ' teclas adicionales permitidas
        Select Case Keyascii
            Case 8
                SoloLetras = Keyascii 'Backspace
            Case 13
                SoloLetras = Keyascii 'Enter
        End Select
    End Function
    Public Function ValidaTelefonos(ByVal Keyascii) As Integer
        If InStr("1234567890 -()", Chr(Keyascii)) = 0 Then
            ValidaTelefonos = 0
        Else
            ValidaTelefonos = Keyascii
        End If
        ' teclas adicionales permitidas
        Select Case Keyascii
            Case 8
                ValidaTelefonos = Keyascii 'Backspace
            Case 13
                ValidaTelefonos = Keyascii 'Enter
        End Select
    End Function
    Public Function LetrasNumeros(ByVal Keyascii) As Integer
        Keyascii = Asc(UCase(Chr(Keyascii)))
        If InStr("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890. /-,#", Chr(Keyascii)) = 0 Then
            LetrasNumeros = 0
        Else
            LetrasNumeros = Keyascii
        End If
        ' teclas adicionales permitidas
        Select Case Keyascii
            Case 8
                LetrasNumeros = Keyascii 'Backspace
            Case 13
                LetrasNumeros = Keyascii 'Enter
        End Select
    End Function
    Public Function codigoBarras(ByVal Keyascii) As Integer
        Keyascii = Asc(UCase(Chr(Keyascii)))
        If InStr("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890", Chr(Keyascii)) = 0 Then
            codigoBarras = 0
        Else
            codigoBarras = Keyascii
        End If
        ' teclas adicionales permitidas
        Select Case Keyascii
            Case 8
                codigoBarras = Keyascii 'Backspace
            Case 13
                codigoBarras = Keyascii 'Enter
        End Select
    End Function
    Public Function ValidaNumeroDeCalle(ByVal Keyascii As Short) As Short
        Keyascii = Asc(UCase(Chr(Keyascii)))
        If InStr("1234567890 ABCD-", Chr(Keyascii)) = 0 Then
            ValidaNumeroDeCalle = 0
        Else
            ValidaNumeroDeCalle = Keyascii
        End If
        ' teclas adicionales permitidas
        Select Case Keyascii
            Case 8
                ValidaNumeroDeCalle = Keyascii 'Backspace
            Case 13
                ValidaNumeroDeCalle = Keyascii 'Enter
        End Select
    End Function
    Public Function ValidaLimiteCredito(ByVal Keyascii As Short) As Short
        Keyascii = Asc(UCase(Chr(Keyascii)))
        If InStr("1234567890 ,.", Chr(Keyascii)) = 0 Then
            ValidaLimiteCredito = 0
        Else
            ValidaLimiteCredito = Keyascii
        End If
        ' teclas adicionales permitidas
        Select Case Keyascii
            Case 8
                ValidaLimiteCredito = Keyascii 'Backspace
            Case 13
                ValidaLimiteCredito = Keyascii 'Enter
        End Select
    End Function
End Class
