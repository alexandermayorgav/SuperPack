Imports System.IO
Public Class Imprime

    Public Const GENERIC_WRITE = &H40000000
    Public Const OPEN_EXISTING = 3
    Public Const FILE_SHARE_WRITE = &H2


    Public Structure SECURITY_ATTRIBUTES
        Private nLength As Integer
        Private lpSecurityDescriptor As Integer
        Private bInheritHandle As Integer
    End Structure


    Dim SA As SECURITY_ATTRIBUTES
    Dim outFile As FileStream
    Dim Safe As Microsoft.Win32.SafeHandles.SafeFileHandle
    Dim LPTPORT As String
    Dim hPort As Integer
    Dim hPortP As IntPtr
    Dim retval As Integer

    Public Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As Integer

    Public Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As Integer) As Integer


    Public Sub AbrirCajon()
        Dim fw As StreamWriter


        LPTPORT = "LPT1"
        hPort = CreateFile(LPTPORT, GENERIC_WRITE, FILE_SHARE_WRITE, SA, OPEN_EXISTING, 0, 0)
        hPortP = New IntPtr(hPort)
        Safe = New Microsoft.Win32.SafeHandles.SafeFileHandle(hPortP, True)
        If Not Safe.IsInvalid Then
            outFile = New System.IO.FileStream(Safe, IO.FileAccess.Write)
            fw = New System.IO.StreamWriter(outFile)
            fw.AutoFlush = True
            fw.WriteLine(Chr(27) & Chr(112) & 0) 'Genérico Epson 
            fw.Close()
        End If
        CloseHandle(hPort)
    End Sub
  

End Class
