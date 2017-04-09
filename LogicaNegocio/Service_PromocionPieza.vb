Imports System.ComponentModel
Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_PromocionPieza

    Private sqlprod = "SELECT * FROM PROMO_PZas"
    

    Public Function obtenerPromociones() As BindingList(Of PromocionPieza)

        Dim db As BaseDatos = Nothing
        Dim db2 As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try

            db = New BaseDatos
            db2 = New BaseDatos
            db.Conectar()
            db2.Conectar()
            db.CrearComando(sqlprod, CommandType.Text)

            datos = db.EjecutarConsulta()
            Dim items As New BindingList(Of PromocionPieza)

            While datos.Read()
                Try
                    items.Add(New PromocionPieza(datos("id_promo_pza"), datos("fecha_inicial"), datos("fecha_final"), datos("cant_vendida"), ObtenerProd(datos("id_producto"), db2), ObtenerProd(datos("ID_prod"), db2), datos("cant_regalada")))

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While

            Return items
        Catch ex As FbException
            Throw New ReglasNegocioException("Error " + ex.Message)
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            db2.Desconectar()
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Private Function ObtenerProd(ByVal id As Integer, ByVal bd As BaseDatos) As Producto
        Return New Service_Producto().ObtenerPorId(id, bd)
    End Function


    Public Function obtenerActivos() As BindingList(Of PromocionPieza)

        Dim db As BaseDatos = Nothing
        Dim db2 As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try
            db2 = New BaseDatos
            db = New BaseDatos
            db.Conectar()
            db2.Conectar()
            Dim fechafin As String = Chr(39) + String.Format("{0:MM/dd/yyyy}", Date.Now) + Chr(39)

            db.CrearComando(sqlprod + " where promo_pzas.fecha_final> " + fechafin, CommandType.Text)

            datos = db.EjecutarConsulta()
            Dim items As New BindingList(Of PromocionPieza)
            While datos.Read()
                Try


                    items.Add(New PromocionPieza(datos("id_promo_pza"), datos("fecha_inicial"), datos("fecha_final"), datos("cant_vendida"), ObtenerProd(datos("id_producto"), db2), ObtenerProd(datos("ID_prod"), db2), datos("cant_regalada")))

                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While

            Return items
        Catch ex As FbException
            Throw New ReglasNegocioException("Error " + ex.Message)
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error al obtener los datos. " + Ex.Message)
        Finally
            db2.Desconectar()
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Sub Agregar(ByVal promo As PromocionPieza)

        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "INSERT INTO  promo_pzas" _
           & "(fecha_inicial,fecha_final,cant_vendida,id_producto,cant_regalada,id_prod)" _
           & " VALUES(@fecha_in,@fecha_fin,@cantidad,@id_producto,@cantidad_regalada,@id_prod) RETURNING id_promo_pza"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@fecha_in", promo.Fecha_Inicial)
            db.AgregarParametro("@fecha_fin", promo.Fecha_Final)
            db.AgregarParametro("@cantidad", promo.Cantidad)
            db.AgregarParametro("@id_producto", promo.Producto.Id)
            db.AgregarParametro("@cantidad_regalada", promo.CantidadRegalada)
            db.AgregarParametro("@id_prod", promo.ProductoRegalo.Id)

            promo.Id = db.EjecutarEscalar()

        Catch ex As FbException
            Throw New Exception(ex.Message)
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            Throw New ReglasNegocioException(Err.Number)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Sub Delete(ByVal id As Integer)
        Dim db As New BaseDatos
        Try

            db.Conectar()
            Dim Sql As String
            Sql = "delete from promo_pzas where id_promo_pza=@id"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@id", id)
            db.EjecutarComando()

        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            Throw New ReglasNegocioException(Err.Number)
        Finally
            db.Desconectar()
        End Try

    End Sub

End Class
