Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Factura

    Public Function guardarFactura(ByRef factura As Factura, ByRef folio As Folio) As Integer
        Dim db As BaseDatos = Nothing
        Dim siguiente As Integer = -1
        Try
            db = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()

            'completar esta funcion agregar campos a la tabla de folio de rango de folios
            'el folio sera de rango  + folios usados , por mientras sera folios usados
            Dim numfolio = descontar(db, folio)

            Dim sql As String = "insert into facturas(id_factura,id_venta,fecha,estatus,folio,id_folio) values(NULL,@id_venta,@fecha,@estatus,@folio,@id_folio) returning id_factura"

            db.CrearComando(sql, CommandType.Text)

            db.AgregarParametro("@id_venta", factura.Id_Venta)
            db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(factura.Fecha))
            db.AgregarParametro("@estatus", 0)
            siguiente = folio.Folio_Inicial + numfolio
            db.AgregarParametro("@folio", siguiente)
            db.AgregarParametro("@id_folio", factura.Id_Folio)
            factura.Id = db.EjecutarEscalar

            db.ConfirmarTransaccion()
        Catch ex As BaseDatosException
            db.CancelarTransaccion()
            siguiente = -1
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            siguiente = -1
            Throw New ReglasNegocioException("Error al guardar la factura. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
        Return siguiente
    End Function
    Private Function descontar(ByRef db As BaseDatos, ByRef folio As Folio) As Integer

        Dim servicefol As New Service_Folios
        Return servicefol.DescontardeFolios(db, folio.Id)

    End Function



    Public Function VerFactura(ByVal id As Integer) As Factura
        Dim db As BaseDatos = Nothing
        Dim factura As Factura = Nothing
        Dim reader As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "select * from facturas where id_factura=@id"

            db.CrearComando(sql, CommandType.Text)

            db.AgregarParametro("@id", id)

            reader = db.EjecutarConsulta

            If reader.Read Then
                factura = New Factura(reader("id_factura"), reader("id_venta"), reader("fecha"), reader("estatus"), reader("folio"), reader("id_folio"))

            End If


        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener la factura. " + Ex.Message)
        Finally
            reader.Close()
            db.Desconectar()
        End Try
        Return factura
    End Function

    Public Function VerFacturas() As List(Of Factura)
        Dim db As BaseDatos = Nothing
        Dim fact As New List(Of Factura)
        Dim reader As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "select * from facturas"

            db.CrearComando(sql, CommandType.Text)


            reader = db.EjecutarConsulta
            fact = New List(Of Factura)

            While reader.Read
                Dim factura = New Factura(reader("id_factura"), reader("id_venta"), reader("fecha"), reader("estatus"), reader("folio"), reader("id_folio"))
                fact.Add(factura)
            End While


        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener la factura. " + Ex.Message)
        Finally
            reader.Close()
            db.Desconectar()
        End Try
        Return fact
    End Function

    Public Function checarVenta(ByVal id_venta As Integer) As Boolean

        Dim db As BaseDatos = Nothing
        Dim existe As Boolean = False
        Dim reader As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "select * from facturas where id_venta=@id"

            db.CrearComando(sql, CommandType.Text)

            db.AgregarParametro("@id", id_venta)

            reader = db.EjecutarConsulta
            If reader.Read Then
                existe = True
            End If
        Catch ex As FbException
            MsgBox(ex.Message)
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener la factura. " + Ex.Message)
        Finally
            reader.Close()
            db.Desconectar()
        End Try
        Return existe
    End Function




End Class
