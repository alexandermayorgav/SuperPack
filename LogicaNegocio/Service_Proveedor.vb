Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Proveedor

    Public Sub Insertar(ByRef proveedor As Proveedor)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("insert into proveedor (razon_social,rfc,calle,num_int,num_ext,colonia,cp,telefono,ciudad,id_estado,status) values (@rs,@rfc,@calle,@nint,@next,@colonia,@cp,@tel,@cd,@estado,@status) returning id_proveedor", CommandType.Text)

            db.AgregarParametro("@rs", proveedor.RazonSocial)
            db.AgregarParametro("@rfc", proveedor.Rfc)
            db.AgregarParametro("@calle", proveedor.Calle)
            db.AgregarParametro("@nint", proveedor.NumInt)
            db.AgregarParametro("@next", proveedor.NumExt)
            db.AgregarParametro("@colonia", proveedor.Colonia)
            db.AgregarParametro("@cp", proveedor.Cp)
            db.AgregarParametro("@tel", proveedor.Telefono)
            db.AgregarParametro("@cd", proveedor.Ciudad)
            db.AgregarParametro("@estado", proveedor.IdEstado)
            db.AgregarParametro("@status", IIf(proveedor.Status, 1, 0))
            proveedor.IdProveedor = db.EjecutarEscalar

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos")
        Catch ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al guardar el proveedor " + ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
    Public Sub Actualizar(ByVal proveedor As Proveedor)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("update proveedor set razon_social=@rs,rfc=@rfc,calle=@calle,num_int=@num_int,num_ext=@num_ext,colonia=@colonia,cp=@cp,telefono=@tel,ciudad=@ciudad,id_estado=@estado,status=@status where id_proveedor=@id_proveedor", CommandType.Text)

            db.AgregarParametro("@id_proveedor", proveedor.IdProveedor)
            db.AgregarParametro("@rs", proveedor.RazonSocial)
            db.AgregarParametro("@rfc", proveedor.Rfc)
            db.AgregarParametro("@calle", proveedor.Calle)
            db.AgregarParametro("@num_int", proveedor.NumInt)
            db.AgregarParametro("@num_ext", proveedor.NumExt)
            db.AgregarParametro("@colonia", proveedor.Colonia)
            db.AgregarParametro("@cp", proveedor.Cp)
            db.AgregarParametro("@tel", proveedor.Telefono)
            db.AgregarParametro("@ciudad", proveedor.Ciudad)
            db.AgregarParametro("@estado", proveedor.IdEstado)
            db.AgregarParametro("@status", IIf(proveedor.Status, 1, 0))
            db.EjecutarComando()

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos")
        Catch ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al actualizar los datos del proveedor " + ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
    Public Sub Eliminar(ByVal idproveedor As Integer)
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("update proveedor set status=0 where id_proveedor=@id_proveedor", CommandType.Text)
            db.AgregarParametro("@id_proveedor", idproveedor)
            db.EjecutarComando()

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos")
        Catch ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al eliminar el proveedor " + ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Sub
    Public Function ObtenerProveedor(ByVal idproveedor As Integer) As Proveedor
        Dim db As BaseDatos = Nothing
        Dim Prov As Proveedor = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("select * from proveedor where id_proveedor=@idproveedor", CommandType.Text)
            db.AgregarParametro("@idproveedor", idproveedor)
            datos = db.EjecutarConsulta()

            If datos.Read() Then
                Try
                    Prov = New Proveedor(datos("id_proveedor"), datos("razon_social"), datos("rfc"), datos("calle"), datos("num_int"), datos("num_ext"), datos("colonia"), datos("cp"), datos("telefono"), datos("ciudad"), datos("id_estado"), datos("status"))
                    Return Prov

                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden ", ex)
                Catch ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET ", ex)
                End Try
            Else
                Throw New ReglasNegocioException("No se encontró el proveedor")
            End If

        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos")
        Catch ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener el proveedor " + ex.Message)
        Finally
            datos.Close()
            db.Desconectar()
        End Try
    End Function
    Public Function MaxFolio() As Integer
        Dim db As BaseDatos = Nothing
        Dim data As FbDataReader = Nothing
        Try
            Dim sql As String = "select max (id_proveedor) as id_proveedor  from proveedor"
            db = New BaseDatos
            db.Conectar()
            db.CrearComando(sql, CommandType.Text)

            data = db.EjecutarConsulta()

            If data.Read() Then
                Try
                    Return data("id_proveedor")
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            Else
                Throw New ReglasNegocioException("No se puede encontrar")
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al leer el identificador. " + Ex.Message)
        Finally
            data.Close()
            db.Desconectar()
        End Try
    End Function
    Public Function Estados() As DataSet
        Dim db As BaseDatos = Nothing
        Dim data As DataSet = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("select * from estado", CommandType.Text)
            data = db.ObtenConsulta

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            data.Dispose()
            db.Desconectar()
        End Try
        Return data
    End Function
    Public Function existeProveedor(ByVal proveedor As String, ByVal id As Integer) As Boolean
        Dim db As BaseDatos = Nothing
        Try
            db = New BaseDatos
            db.Conectar()
            db.CrearComando("select id_proveedor from proveedor where proveedor.razon_social=@rs and proveedor.id_proveedor<>@id", CommandType.Text)
            db.AgregarParametro("@rs", proveedor)
            db.AgregarParametro("@id", id)

            Dim lee As FbDataReader
            lee = db.EjecutarConsulta

            If lee.Read Then
                lee.Close()
                Return True   'nombre no disponible
            Else
                lee.Close()
                Return False   'nombre  disponible
            End If

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error. " + Ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function
End Class
