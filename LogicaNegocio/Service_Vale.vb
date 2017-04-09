Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient

Public Class Service_Vale
    Public Function ObtenerVale(ByVal id As Integer) As Vales
        Dim DB As BaseDatos = Nothing
        Dim read As FbDataReader = Nothing
        Dim vale As Vales = Nothing
        Try
            DB = New BaseDatos
            DB.Conectar()
            Dim Sql As String = "select * from vales where id_vale=@id and borrado<>1"
            DB.CrearComando(Sql, CommandType.Text)
            DB.AgregarParametro("@id", id)
            read = DB.EjecutarConsulta

            If read.Read Then
                vale = New Vales(read("id_vale"), read("monto_inicial"), read("monto_actual"), read("fecha"), read("nombre_cliente"), read("borrado"), read("id_cliente"))
            Else
                Throw New ReglasNegocioException("No se encontro el vale")
            End If

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error en consulta. " + Ex.Message)
        Finally
            read.Close()
            DB.Desconectar()
        End Try
        Return vale
    End Function
    Public Sub DescontarVale(ByVal vale As Vales)
        Dim DB As BaseDatos = Nothing
        Try
            DB = New BaseDatos
            DB.Conectar()
            Dim Sql As String = "update vales set monto_actual=@monto_actual where id_vale=@id_vale"

            DB.CrearComando(Sql, CommandType.Text)

            DB.AgregarParametro("@monto_actual", vale.MontoActual)
            DB.AgregarParametro("@id_vale", vale.Folio)
            DB.EjecutarComando()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error en insert. " + Ex.Message)
        Finally
            DB.Desconectar()
        End Try
    End Sub
    Public Sub AgregarVale(ByRef Val As Vales)
        Dim DB As BaseDatos = Nothing
        Try
            DB = New BaseDatos
            DB.Conectar()
            Dim Sql As String = "insert into vales (monto_inicial,fecha,nombre_cliente,id_cliente,borrado,monto_actual,id_usuario)" _
            & "values (@monto_inicial,@fecha,@nombre_cliente,@id_cliente,@borrado,@monto_actual,@id_usuario) RETURNING ID_VALE"

            DB.CrearComando(Sql, CommandType.Text)
            DB.AgregarParametro("@monto_inicial", Val.MontoActual)
            DB.AgregarParametro("@fecha", Utils.ObtenerFechaHora(Val.Fecha))
            DB.AgregarParametro("@nombre_cliente", Val.NombreCliente)
            DB.AgregarParametro("@id_cliente", Val.Cliente)
            DB.AgregarParametro("@borrado", 0)
            DB.AgregarParametro("@monto_actual", Val.MontoActual)
            DB.AgregarParametro("@id_usuario", Val.Usuario)

            Val.Folio = DB.EjecutarEscalar
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error en insert. " + Ex.Message)
        Finally
            DB.Desconectar()
        End Try

    End Sub
    Public Function ObtenerVales(ByVal fecha1 As String, ByVal fecha2 As String, Optional ByVal verpor As String = "") As List(Of Vales)
        Dim DB As BaseDatos = Nothing
        Dim read As FbDataReader = Nothing
        Dim vales As List(Of Vales) = Nothing
        Try
            DB = New BaseDatos
            DB.Conectar()
            Dim sql As String
            If verpor = "Todos" Then
                sql = "select * from vales where borrado<>1 order by  fecha desc "
                DB.CrearComando(sql, CommandType.Text)
            Else
                sql = "select * from vales where borrado<>1 and fecha between @fecha1 and @fecha2 order by  fecha desc"
                DB.CrearComando(sql, CommandType.Text)
                DB.AgregarParametro("@fecha1", fecha1)
                DB.AgregarParametro("@fecha2", fecha2)
            End If

            read = DB.EjecutarConsulta
            Dim id_vale = read.GetOrdinal("id_vale")
            Dim monto_inicial = read.GetOrdinal("monto_inicial")
            Dim monto_actual = read.GetOrdinal("monto_actual")
            Dim fecha = read.GetOrdinal("fecha")
            Dim nombre = read.GetOrdinal("nombre_cliente")
            Dim borrado = read.GetOrdinal("borrado")
            Dim id_cliente = read.GetOrdinal("id_cliente")
            Dim id_usuario = read.GetOrdinal("id_usuario")
            Dim values(read.FieldCount) As Object
            vales = New List(Of Vales)
            While read.Read
                read.GetValues(values)
                vales.Add(New Vales(values(id_vale), values(monto_inicial), values(monto_actual), values(fecha), values(nombre), values(borrado), values(id_cliente)))
            End While


        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error en insert. " + Ex.Message)
        Finally
            read.Close()
            DB.Desconectar()
        End Try
        Return vales
    End Function
    Public Sub BorrarVale(ByVal id As Integer)
        Dim DB As BaseDatos = Nothing
        Try
            DB = New BaseDatos
            DB.Conectar()
            Dim Sql As String = "update vales set borrado=1 where id_vale=@id_vale"

            DB.CrearComando(Sql, CommandType.Text)
            DB.AgregarParametro("@id_vale", id)

            DB.EjecutarComando()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error en insert. " + Ex.Message)
        Finally
            DB.Desconectar()
        End Try
    End Sub
End Class
