Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class ServiceCortes


    Public Function ObtenerCortes() As List(Of Cortes)
        Dim cortes As New List(Of Cortes)
        Dim db As New BaseDatos
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String

        
            sQuery = "select caja.id_caja,caja.id_usuario,caja.fecha_apertura,caja.fecha_cierre,caja.monto_inicial,caja.cerrada,usuarios.usuario from caja inner join usuarios on caja.id_usuario=usuarios.id_usuario where caja.cerrada=1"
            db.CrearComando(sQuery, CommandType.StoredProcedure)


            Dim data As FbDataReader = db.EjecutarConsulta()

            Dim id = data.GetOrdinal("id_caja")
            Dim id_user = data.GetOrdinal("id_usuario")
            Dim fecha = data.GetOrdinal("fecha_apertura")
            Dim fecha_cierre = data.GetOrdinal("fecha_cierre")
            Dim monto = data.GetOrdinal("monto_inicial")
            Dim usuario = data.GetOrdinal("usuario")
            Dim cerrada = data.GetOrdinal("cerrada")

            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)

                    Dim Res = New Cortes(values(id), values(id_user), values(usuario), values(fecha), values(fecha_cierre), values(monto), values(cerrada))
                    cortes.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            data.Close()


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las ventas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las ventas. " + Ex.Message)
        Finally
            db.Desconectar()

        End Try
        Return cortes

    End Function

    Public Function ObtenerDetalles(ByVal idcaja As Integer) As List(Of CorteDetalle)

        Dim cortes As New List(Of CorteDetalle)
        Dim db As New BaseDatos
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String


            sQuery = "select * from caja_detalle where id_caja=@id"
            db.CrearComando(sQuery, CommandType.StoredProcedure)
            db.AgregarParametro("@id", idcaja)

            Dim data As FbDataReader = db.EjecutarConsulta()

            Dim id = data.GetOrdinal("id_caja")
            Dim id_caja_det = data.GetOrdinal("id_caja_det")
            Dim fecha = data.GetOrdinal("fecha")
            Dim monto = data.GetOrdinal("monto")
            Dim concepto = data.GetOrdinal("concepto")
            Dim tipo = data.GetOrdinal("tipo_pago")


            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)

                    Dim Res = New CorteDetalle(values(id_caja_det), values(id), values(fecha), values(monto), values(concepto), values(tipo))
                    cortes.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            data.Close()


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las ventas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las ventas. " + Ex.Message)
        Finally
            db.Desconectar()

        End Try
        Return cortes

    End Function

End Class
