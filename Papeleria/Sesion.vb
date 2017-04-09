Imports LogicaNegocio
Module Sesion
    Public id_usuario_sesion As Integer
    Public nombre_usuario As String
    Public iva As Decimal
    Public id_caja As Integer
    Public negocio As String
    Public rfc As String
    Public direccion As String '' calle, num int y ext y colonia
    Public ciudad As String  ''ciudad y estado
    Public telefono As String
    Public razonsocial As String
    Public conf As Configuracion

    Public saludo As String
    Public porcetaje As Decimal   ''porcentaje de ganancia
    Public caja_abierta As Boolean
    Public dias_apartado As Integer
    Public impresora As String
    Public venderSinExis As Boolean
    Public imprimeTicket As Boolean
    Public imagen As String
    Public Abrir_Cajon As Boolean



End Module
