Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Credito
    Private db As BaseDatos = Nothing

    Public Function obtenerTodosCreditos() As List(Of CuentasCobrar)
        Dim listaDeudas As New List(Of CuentasCobrar)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "DEUDASTODAS"
            db.CrearComando(sQuery, CommandType.StoredProcedure)

            data = db.EjecutarConsulta()

            Dim idcred = data.GetOrdinal("ID_CREDITO")
            Dim idcliente = data.GetOrdinal("ID_CLIENTE")
            Dim fecha = data.GetOrdinal("FECHA_ACT")
            Dim limite = data.GetOrdinal("LIMITE")
            Dim activo = data.GetOrdinal("ACTIVO")
            Dim saldo = data.GetOrdinal("SALDO")
            Dim rs = data.GetOrdinal("RAZON_SOCIAL")


            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Res = New CuentasCobrar(values(idcred), values(idcliente), values(fecha), values(limite), values(activo), values(saldo), values(rs))
                    listaDeudas.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While
            data.Close()


        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las deudas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las deudas. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()

        End Try
        Return listaDeudas
    End Function

    Public Sub iniciarBusqueda()
        db = New BaseDatos
        db.Conectar()
    End Sub
    Public Sub finalizarBusqueda()
        db.Desconectar()
    End Sub
    Public Function Obtener(ByVal nombre As String) As List(Of CuentasCobrar)
        Dim listaDeudas As New List(Of CuentasCobrar)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "SELECT CREDITOS.ID_CREDITO, CREDITOS.ID_CLIENTE, CREDITOS.FECHA_ACT, CREDITOS.LIMITE,CREDITOS.ACTIVO, CREDITOS.SALDO, CLIENTE.RAZON_SOCIAL FROM CREDITOS INNER JOIN CLIENTE ON (CREDITOS.ID_CLIENTE = CLIENTE.ID_CLIENTE) WHERE CREDITOS.SALDO>0 AND UPPER (razon_social COLLATE DE_de) like UPPER ('%" & nombre & "%' COLLATE DE_de)"

            db.CrearComando(sQuery, CommandType.Text)

            data = db.EjecutarConsulta()

            Dim idcred = data.GetOrdinal("ID_CREDITO")
            Dim idcliente = data.GetOrdinal("ID_CLIENTE")
            Dim fecha = data.GetOrdinal("FECHA_ACT")
            Dim limite = data.GetOrdinal("LIMITE")
            Dim activo = data.GetOrdinal("ACTIVO")
            Dim saldo = data.GetOrdinal("SALDO")
            Dim rs = data.GetOrdinal("RAZON_SOCIAL")


            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Res = New CuentasCobrar(values(idcred), values(idcliente), values(fecha), values(limite), values(activo), values(saldo), values(rs))
                    listaDeudas.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While



        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las deudas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las deudas. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()

        End Try
        Return listaDeudas
    End Function

    Public Function obtenerCreditosFecha(ByVal fechaInicio As Date, ByVal fechaFin As Date) As List(Of CuentasCobrar)
        Dim listaDeudasFecha As New List(Of CuentasCobrar)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "DEUDASFECHA"
            db.CrearComando(sQuery, CommandType.StoredProcedure)

            'If fechaInicio = fechaFin Then
            fechaFin = DateAdd(DateInterval.Day, 1, fechaFin)
            'End If

            db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicio))
            db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(fechaFin))

            data = db.EjecutarConsulta()

            Dim idcred = data.GetOrdinal("ID_CREDITO")
            Dim idcliente = data.GetOrdinal("ID_CLIENTE")
            Dim fecha = data.GetOrdinal("FECHA_ACT")
            Dim limite = data.GetOrdinal("LIMITE")
            Dim activo = data.GetOrdinal("ACTIVO")
            Dim saldo = data.GetOrdinal("SALDO")
            Dim rs = data.GetOrdinal("RAZON_SOCIAL")


            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Resfecha = New CuentasCobrar(values(idcred), values(idcliente), values(fecha), values(limite), values(activo), values(saldo), values(rs))
                    listaDeudasFecha.Add(Resfecha)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While



        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las deudas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las deudas. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()

        End Try
        Return listaDeudasFecha
    End Function

    '************CUENTAS POR PAGAR (PROVEEDOR)
    Public Function obtenerTodosCreditosProveedor() As List(Of CuentasPagar)
        Dim listaDeudas As New List(Of CuentasPagar)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "DEUDASTODASPROV"
            db.CrearComando(sQuery, CommandType.StoredProcedure)

            data = db.EjecutarConsulta()

            Dim idcred = data.GetOrdinal("ID_CREDITO")
            Dim idcompra = data.GetOrdinal("ID_COMPRA")
            Dim fecha = data.GetOrdinal("FECHA")
            Dim total = data.GetOrdinal("TOTAL")
            Dim nombre = data.GetOrdinal("NOMBRE")
            Dim usuario = data.GetOrdinal("USUARIO_L")
            Dim idprov = data.GetOrdinal("ID_PROVEEDOR")
             Dim rs = data.GetOrdinal("RAZON_SOCIAL")

            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Res = New CuentasPagar(values(idcred), values(idcompra), values(fecha), values(total), values(nombre), values(usuario), values(idprov), values(rs))
                    listaDeudas.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While



        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las deudas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las deudas. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()
        End Try
        Return listaDeudas
    End Function
    Public Function obtenerCreditosProveedor(ByVal nombreprov As String) As List(Of CuentasPagar)
        Dim listaDeudas As New List(Of CuentasPagar)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "SELECT CUENTAS_PAGAR.ID_CREDITO,CUENTAS_PAGAR.ID_COMPRA,COMPRA.FECHA,CUENTAS_PAGAR.TOTAL,PERSONAL.NOMBRE,USUARIOS.USUARIO AS USUARIO_L,PROVEEDOR.ID_PROVEEDOR,Proveedor.RAZON_SOCIAL FROM CUENTAS_PAGAR INNER JOIN COMPRA ON (CUENTAS_PAGAR.ID_COMPRA = COMPRA.ID_COMPRA) INNER JOIN PROVEEDOR ON (COMPRA.ID_PROVEEDOR = PROVEEDOR.ID_PROVEEDOR) INNER JOIN USUARIOS ON (COMPRA.ID_USUARIO = USUARIOS.ID_USUARIO) INNER JOIN PERSONAL ON (USUARIOS.ID_PERSONAL = PERSONAL.ID_PERSONAL) WHERE CUENTAS_PAGAR.PAGADO=0 AND UPPER (PROVEEDOR.razon_social COLLATE DE_de) like UPPER ('%" & nombreprov & "%' COLLATE DE_de)"

            db.CrearComando(sQuery, CommandType.Text)

            data = db.EjecutarConsulta()

            Dim idcred = data.GetOrdinal("ID_CREDITO")
            Dim idcompra = data.GetOrdinal("ID_COMPRA")
            Dim fecha = data.GetOrdinal("FECHA")
            Dim total = data.GetOrdinal("TOTAL")
            Dim nombre = data.GetOrdinal("NOMBRE")
            Dim usuario = data.GetOrdinal("USUARIO_L")
            Dim idprov = data.GetOrdinal("ID_PROVEEDOR")
            Dim rs = data.GetOrdinal("RAZON_SOCIAL")

            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Res = New CuentasPagar(values(idcred), values(idcompra), values(fecha), values(total), values(nombre), values(usuario), values(idprov), values(rs))
                    listaDeudas.Add(Res)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While



        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las deudas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las deudas. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()
        End Try
        Return listaDeudas
    End Function
    Public Function cuentasPagarPorFecha(ByVal fechaInicio As Date, ByVal fechaFin As Date) As List(Of CuentasPagar)
        Dim listaCuentasFecha As New List(Of CuentasPagar)
        Dim db As New BaseDatos
        Dim data As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            Dim sQuery As String = "CUENTASPAGARPORFECHA"
            db.CrearComando(sQuery, CommandType.StoredProcedure)


            fechaFin = DateAdd(DateInterval.Day, 1, fechaFin)


            db.AgregarParametro("@FECHA1", Utils.ObtenerFecha(fechaInicio))
            db.AgregarParametro("@FECHA2", Utils.ObtenerFecha(fechaFin))

            data = db.EjecutarConsulta()

            Dim idcred = data.GetOrdinal("ID_CREDITO")
            Dim idcompra = data.GetOrdinal("ID_COMPRA")
            Dim fecha = data.GetOrdinal("FECHA")
            Dim total = data.GetOrdinal("TOTAL")
            Dim nombre = data.GetOrdinal("NOMBRE")
            Dim usuario = data.GetOrdinal("USUARIO_L")
            Dim idprov = data.GetOrdinal("ID_PROVEEDOR")
            Dim rs = data.GetOrdinal("RAZON_SOCIAL")


            Dim values(data.FieldCount) As Object
            While data.Read()
                Try
                    data.GetValues(values)
                    Dim Resfecha = New CuentasPagar(values(idcred), values(idcompra), values(fecha), values(total), values(nombre), values(usuario), values(idprov), values(rs))
                    listaCuentasFecha.Add(Resfecha)
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While



        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener las cuentas.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener las cuentas. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()
        End Try
        Return listaCuentasFecha
    End Function
End Class
