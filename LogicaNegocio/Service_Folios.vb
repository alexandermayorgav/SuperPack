Imports LogicaNegocio
Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Folios

    Public Sub AgregarFolios(ByRef folio As Folio)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "insert into folios(id_folio,no_aprobacion,folios,folios_usados,sello_digital,estatus,fecha,sello_digital_sat,cadena,serie,folio_inicial,folio_final,tipo_comprobante,imagen) values(NULL,@no_aprobacion,@folios,@folios_usados,@sello_digital,@estatus,@fecha,@sello_digital_sat,@cadena,@serie,@folioinicial,@foliofinal,@tipocomprobante,@imagen) returning id_folio"

            db.CrearComando(sql, CommandType.Text)

            db.AgregarParametro("@no_aprobacion", folio.No_Aprobacion)
            db.AgregarParametro("@folios", folio.Numero_Folios)
            db.AgregarParametro("@folios_usados", 0)
            db.AgregarParametro("@sello_digital", folio.Sello_Digital)
            db.AgregarParametro("@estatus", "0")
            db.AgregarParametro("@fecha", Utils.ObtenerFechaHora(folio.Fecha))
            db.AgregarParametro("@sello_digital_sat", folio.Sello_Digital_Sat)
            db.AgregarParametro("@cadena", folio.Cadena_Original)
            db.AgregarParametro("@serie", folio.Serie)
            db.AgregarParametro("@folioinicial", folio.Folio_Inicial)
            db.AgregarParametro("@foliofinal", folio.Folio_Final)
            db.AgregarParametro("@tipocomprobante", folio.Tipo_Comprobante)
            db.AsignarParametroByte("@imagen", folio.Imagen)


            folio.Id = db.EjecutarEscalar
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al guardar los folios. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Public Function ObtenerFoliosActivos() As Folio

        Dim db As BaseDatos = Nothing
        Dim folio As Folio = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "select * from folios where estatus=1"

            db.CrearComando(sql, CommandType.Text)

            Dim reader As FbDataReader = db.EjecutarConsulta
            If reader.Read Then
                folio = New Folio(reader("id_folio"), reader("no_aprobacion"), reader("fecha"), reader("folios"), reader("folios_usados"), reader("sello_digital"), reader("estatus"), reader("cadena"), reader("sello_digital_sat"), reader("serie"), reader("folio_inicial"), reader("folio_final"), reader("tipo_comprobante"))

            End If

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error no hay folios activos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
        Return folio
    End Function

    Public Function ObtenerFoliosId(ByVal id As Integer) As Folio

        Dim db As BaseDatos = Nothing
        Dim folio As Folio = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "select * from folios where id_folio=@idfolio"

            db.CrearComando(sql, CommandType.Text)
            db.AgregarParametro("@idfolio", id)
            Dim reader As FbDataReader = db.EjecutarConsulta
            If reader.Read Then
                folio = New Folio(reader("id_folio"), reader("no_aprobacion"), reader("fecha"), reader("folios"), reader("folios_usados"), reader("sello_digital"), reader("estatus"), reader("cadena"), reader("sello_digital_sat"), reader("serie"), reader("folio_inicial"), reader("folio_final"), reader("tipo_comprobante"))

            End If

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error no hay folios activos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
        Return folio
    End Function

    Public Function ObtenerTodosFolios() As List(Of Folio)

        Dim db As BaseDatos = Nothing
        Dim fol As List(Of Folio) = Nothing
        Dim reader As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "select * from folios "

            db.CrearComando(sql, CommandType.Text)

            reader = db.EjecutarConsulta
            fol = New List(Of Folio)
            While reader.Read
                Dim folio = New Folio(reader("id_folio"), reader("no_aprobacion"), reader("fecha"), reader("folios"), reader("folios_usados"), reader("sello_digital"), reader("estatus"), reader("cadena"), reader("sello_digital_sat"), reader("serie"), reader("folio_inicial"), reader("folio_final"), reader("tipo_comprobante"))
                folio.Imagen = reader("imagen")
                fol.Add(folio)

            End While


        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error no hay folios. " + Ex.Message)
        Finally
            reader.Close()
            db.Desconectar()
        End Try
        Return fol
    End Function

    Public Sub ActivarFolios(ByVal id As Integer)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "update folios set estatus=1 where id_folio=@id"

            db.CrearComando(sql, CommandType.Text)

            db.AgregarParametro("@id", id)
            
            db.EjecutarComando()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al activar los folios. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Public Sub DesactivarFolios(ByVal id As Integer)

        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "update folios set estatus=0 where id_folio=@id"

            db.CrearComando(sql, CommandType.Text)

            db.AgregarParametro("@id", id)

            db.EjecutarComando()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al desactivar folios. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Public Sub BorrarFolios(ByVal id As Integer)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sql As String = "delete from folios  where id_folio=@id"

            db.CrearComando(sql, CommandType.Text)

            db.AgregarParametro("@id", id)

            db.EjecutarComando()
        Catch ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al borrar los folios. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Public Function DescontardeFolios(ByRef base As BaseDatos, ByVal id As Integer) As Integer
        Dim db As BaseDatos = Nothing
        db = base

        db.CrearComando("select folios_usados from folios where id_folio=@idf", CommandType.Text)
        db.AgregarParametro("@idf", id)
        Dim reader As FbDataReader = Nothing
        Dim folios_usados As Integer

        Try
            reader = db.EjecutarConsulta
       

            If reader.Read Then
                folios_usados = Convert.ToInt32(reader("folios_usados"))
            Else
                Throw New ReglasNegocioException("Erro al obtener el folio intentelo otra vez")
            End If

            db.CrearComando("update folios set folios_usados=folios_usados+1 where id_folio=@id", CommandType.Text)

            db.AgregarParametro("@id", id)

            db.EjecutarComando()

        Catch ex As Exception
            Throw
        Finally
            reader.Close()
        End Try
        Return folios_usados
    End Function
End Class
