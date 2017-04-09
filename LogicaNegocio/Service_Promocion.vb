Imports System.ComponentModel
Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Promocion

    Private sqlprod = "SELECT " _
      & "PRODUCTO.ID_PRODUCTO," _
      & "PRODUCTO.CODIGO_CLAVE," _
      & "PRODUCTO.DESCRIPCION," _
      & "PRODUCTO.COSTO," _
      & "PRODUCTO.PRECIO," _
      & "PRODUCTO.STOCK_MIN," _
      & "PRODUCTO.STOCK_MAX," _
      & "PRODUCTO.PIEZA_CAJA," _
      & "PRODUCTO.EXISTENCIA," _
      & "PRODUCTO.DESCUENTO," _
      & "PRODUCTO.RANGO," _
      & "PRODUCTO.ID_LINEA," _
      & "PRODUCTO.DESCUENTO_1," _
      & "PRODUCTO.DESCUENTO_2," _
      & "PRODUCTO.IVA," _
      & "PRODUCTO.STATUS," _
      & "PRODUCTO.ES_PRODUCTO," _
      & "PROMO_DESC.ID_PROMO_DESC," _
      & "PROMO_DESC.FECHA_INICIAL," _
      & "PROMO_DESC.FECHA_FINAL," _
      & "PROMO_DESC.CANTIDAD," _
      & "PROMO_DESC.ID_PRODUCTO," _
      & "PROMO_DESC.DESCUENTO as descuento_promo" _
    & " FROM" _
      & " PROMO_DESC" _
      & " INNER JOIN PRODUCTO ON (PROMO_DESC.ID_PRODUCTO = PRODUCTO.ID_PRODUCTO)"


    Public Function obtenerPromociones() As BindingList(Of Promocion)

        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try

            db = New BaseDatos
            db.Conectar()
            db.CrearComando(sqlprod, CommandType.Text)

            datos = db.EjecutarConsulta()
            Dim items As New BindingList(Of Promocion)
            Dim prod As Producto
            While datos.Read()
                Try
                    prod = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("descuento_1"), datos("descuento_2"), datos("iva"), datos("status"))

                    items.Add(New Promocion(datos("id_promo_desc"), datos("fecha_inicial"), datos("fecha_final"), datos("cantidad"), prod, datos("descuento_promo")))

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
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Function obtenerActivos() As BindingList(Of Promocion)

        Dim db As BaseDatos = Nothing
        Dim datos As FbDataReader = Nothing
        Try

            db = New BaseDatos
            db.Conectar()

            Dim fechafin As String = Chr(39) + String.Format("{0:MM/dd/yyyy}", Date.Now) + Chr(39)

            db.CrearComando(sqlprod + " where promo_desc.fecha_final> " + fechafin, CommandType.Text)

            datos = db.EjecutarConsulta()
            Dim items As New BindingList(Of Promocion)
            Dim prod As Producto
            While datos.Read()
                Try
                    prod = New Producto(datos("id_producto"), datos("codigo_clave"), datos("descripcion"), datos("costo"), datos("precio"), datos("stock_min"), datos("stock_max"), datos("pieza_caja"), datos("existencia"), datos("descuento"), datos("rango"), datos("id_linea"), datos("descuento_1"), datos("descuento_2"), datos("iva"), datos("status"))

                    items.Add(New Promocion(datos("id_promo_desc"), datos("fecha_inicial"), datos("fecha_final"), datos("cantidad"), prod, datos("DESCUENTO_promo")))

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
            datos.Close()
            db.Desconectar()
        End Try

    End Function

    Public Sub Agregar(ByVal promo As Promocion)

        Dim db As New BaseDatos
        Try
            db.Conectar()
            Dim Sql As String
            Sql = "INSERT INTO  promo_desc" _
           & "(fecha_inicial,fecha_final,cantidad,id_producto,descuento)" _
           & " VALUES(@fecha_in,@fecha_fin,@cantidad,@id_prod,@desc) RETURNING id_promo_desc"
            db.CrearComando(Sql, CommandType.Text)
            db.AgregarParametro("@fecha_in", promo.Fecha_Inicial)
            db.AgregarParametro("@fecha_fin", promo.Fecha_Final)
            db.AgregarParametro("@cantidad", promo.Cantidad)
            db.AgregarParametro("@id_prod", promo.Producto.Id)
            db.AgregarParametro("@desc", promo.Descuento)
     
            promo.Id = db.EjecutarEscalar()


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
            Sql = "delete from promo_desc where id_promo_desc=@id"
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
