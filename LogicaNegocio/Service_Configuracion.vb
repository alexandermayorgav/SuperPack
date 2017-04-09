Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Configuracion

    Public Sub insertar(ByVal configuracion As Configuracion)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "INSERT INTO  configuracion" _
           & "( propietario,sistema,rfc,calle,num_int,num_ext,colonia,ciudad,id_estado,cp,telefono,iva,saludo,porcentaje,dias_apartado,sin_existencias,impresora,imprime_ticket,imagen,abrir_cajon,porcentaje_medio,porcentaje_menudeo,precio_empaque)" _
           & " VALUES(@propietario,@sistema,@rfc,@calle,@num_int,@num_ext,@colonia,@ciudad,@id_estado,@cp,@telefono,@iva,@saludo,@porcentaje,@dias,@sin,@impresora,@imprime_ticket,@imagen,@cajon,@medio,@menudeo,@precio)"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@propietario", configuracion.Propietario)
            db.AgregarParametro("@sistema", configuracion.Sistema)
            db.AgregarParametro("@rfc", configuracion.RFC)
            db.AgregarParametro("@calle", configuracion.Calle)
            db.AgregarParametro("@num_int", configuracion.No_int)
            db.AgregarParametro("@num_ext", configuracion.No_ext)
            db.AgregarParametro("@colonia", configuracion.Colonia)
            db.AgregarParametro("@ciudad", configuracion.Ciudad)
            db.AgregarParametro("@id_estado", configuracion.Id_estado)
            db.AgregarParametro("@cp", configuracion.CP)
            db.AgregarParametro("@telefono", configuracion.Telefono)
            db.AgregarParametro("@iva", configuracion.IVA)
            db.AgregarParametro("@saludo", configuracion.Saludo)
            db.AgregarParametro("@porcentaje", configuracion.Porcentaje)
            db.AgregarParametro("@dias", configuracion.Dias)
            db.AgregarParametro("@sin", IIf(configuracion.VenderSinExistencias = True, 1, 0))
            db.AgregarParametro("@impresora", configuracion.Impresora)
            db.AgregarParametro("@imprime_ticket", IIf(configuracion.ImprimeTicket = True, 1, 0))
            db.AgregarParametro("@imagen", " ")
            db.AgregarParametro("@cajon", IIf(configuracion.Cajon = True, 1, 0))
            db.AgregarParametro("@medio", configuracion.Porcentaje_Medio)
            db.AgregarParametro("@menudeo", configuracion.Porcentaje_Menudeo)
            db.AgregarParametro("@precio", configuracion.Precio_Empaque)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            Throw New ReglasNegocioException("Error al guardar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Sub insertarImagen(ByVal file As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "update configuracion" _
           & " set imagen=@imagen"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@imagen", file)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            Throw New ReglasNegocioException("Error al guardar los datos. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub


    Public Function Obtener() As Configuracion
        Dim configuracion As Configuracion = Nothing
        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "Select configuracion.*,estado.estado from configuracion inner join estado on configuracion.id_estado=estado.id_estado"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(Sql, CommandType.Text)
            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try
                    'propietario,sistema,rfc,calle,num_int,num_ext,colonia,ciudad,id_estado,cp,telefono,iva
                    configuracion = New Configuracion(datos("propietario"), datos("sistema"), datos("rfc"), datos("calle"), datos("num_int"), datos("num_ext"), datos("colonia"), datos("ciudad"), datos("id_estado"), datos("cp"), datos("telefono"), datos("IVA"), datos("saludo"), datos("porcentaje"), datos("dias_apartado"), datos("impresora"), datos("sin_existencias"), datos("imprime_ticket"), datos("abrir_cajon"), datos("PORCENTAJE_MEDIO"), datos("PORCENTAJE_MENUDEO"), datos("precio_empaque"), datos("imagen"))
                    configuracion.estado = datos("estado")
                    Return configuracion

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No encontrado")
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Sub actualizar(ByVal configuracion As Configuracion)
        Dim db As BaseDatos = Nothing

        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("update configuracion set propietario=@propietario,sistema=@sistema,rfc=@rfc,calle=@calle,num_int=@num_int,num_ext=@num_ext,colonia=@colonia,ciudad=@ciudad,id_estado=@id_estado,cp=@cp,telefono=@telefono,iva=@iva,saludo=@saludo,porcentaje=@porcentaje, dias_apartado=@dias,sin_existencias=@sin,impresora=@printer,imprime_ticket=@imprime_ticket,abrir_cajon=@cajon,porcentaje_medio=@medio,porcentaje_menudeo=@menudeo,precio_empaque=@precio ", CommandType.Text)

            db.AgregarParametro("@propietario", configuracion.Propietario)
            db.AgregarParametro("@sistema", configuracion.Sistema)
            db.AgregarParametro("@rfc", configuracion.RFC)
            db.AgregarParametro("@calle", configuracion.Calle)
            db.AgregarParametro("@num_int", configuracion.No_int)
            db.AgregarParametro("@num_ext", configuracion.No_ext)
            db.AgregarParametro("@colonia", configuracion.Colonia)
            db.AgregarParametro("@ciudad", configuracion.Ciudad)
            db.AgregarParametro("@id_estado", configuracion.Id_estado)
            db.AgregarParametro("@cp", configuracion.CP)
            db.AgregarParametro("@telefono", configuracion.Telefono)
            db.AgregarParametro("@iva", configuracion.IVA)
            db.AgregarParametro("@saludo", configuracion.Saludo)
            db.AgregarParametro("@porcentaje", configuracion.Porcentaje)
            db.AgregarParametro("@dias", configuracion.Dias)
            db.AgregarParametro("@sin", IIf(configuracion.venderSinExistencias = True, 1, 0))
            db.AgregarParametro("@printer", configuracion.Impresora)
            db.AgregarParametro("@imprime_ticket", IIf(configuracion.ImprimeTicket = True, 1, 0))
            db.AgregarParametro("@cajon", IIf(configuracion.Cajon = True, 1, 0))
            db.AgregarParametro("@medio", configuracion.Porcentaje_Medio)
            db.AgregarParametro("@menudeo", configuracion.Porcentaje_Menudeo)
            db.AgregarParametro("@precio", configuracion.Precio_Empaque)
            db.EjecutarComando()


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar los datos. " + Ex.Message)

        Finally
            db.Desconectar()
            db.Dispose()
        End Try
    End Sub

    Public Function obtener_Estados() As List(Of Linea)
        Dim estados As New List(Of Linea)
        Dim _datos As New BaseDatos
        Dim Datos As FbDataReader = Nothing
        Try
            Dim Sql As String = "select * from estado order by id_estado"

            _datos.Conectar()
            _datos.CrearComando(Sql, CommandType.StoredProcedure)
            Datos = _datos.EjecutarConsulta()

            Dim id = Datos.GetOrdinal("id_estado")
            Dim nom_estado = Datos.GetOrdinal("estado")

            Dim values(Datos.FieldCount) As Object

            While Datos.Read()
                Try
                    Datos.GetValues(values)
                    Dim estado As New Linea(values(id), values(nom_estado))
                    estados.Add(estado)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los estados. " + Ex.Message)
        Finally
            Datos.Close()
            _datos.Desconectar()
            _datos.Dispose()
        End Try
        Return estados
    End Function

End Class
