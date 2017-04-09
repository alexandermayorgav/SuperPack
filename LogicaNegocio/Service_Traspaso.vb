Imports AccesoDatos
Imports FirebirdSql.Data.FirebirdClient
Public Class Service_Traspaso

    Public Sub ProcesarTraspaso(ByVal items As List(Of Traspaso))

        Dim db As BaseDatos = Nothing
      
        Try
            DB = New BaseDatos
            db.Conectar()
            db.ComenzarTransaccion()

            Dim updatepaquetes As String = "UPDATE producto SET EXISTENCIA=EXISTENCIA+@EXISTENCIA WHERE ID_PRODUCTO=@ID"

            Dim upcatecajas As String = "UPDATE producto SET EXISTENCIA=EXISTENCIA-@EXISTENCIA,SOBRANTE=SOBRANTE+@SOBRANTES WHERE ID_PRODUCTO=@ID"

           Dim cajapiezas As Decimal
            Dim cantidaddepiezas As Decimal
            Dim restantes As Decimal
            For Each item In items
                cajapiezas = item.Cajas_Abiertas * item.Caja.Piezas
                cantidaddepiezas = item.Cantidad_Paquetes * item.Producto.Piezas
                restantes = cajapiezas - cantidaddepiezas


                db.CrearComando(upcatecajas, CommandType.Text)
                db.AgregarParametro("@ID", item.Caja.Id)
                db.AgregarParametro("@EXISTENCIA", item.Cajas_Abiertas)
                db.AgregarParametro("@SOBRANTES", restantes)
                db.EjecutarComando()


                db.CrearComando(updatepaquetes, CommandType.Text)
                db.AgregarParametro("@ID", item.Producto.Id)
                db.AgregarParametro("@EXISTENCIA", item.Cantidad_Paquetes)
                db.EjecutarComando()
            Next



            db.ConfirmarTransaccion()
        Catch ex As FbException
            db.CancelarTransaccion()

            Throw New ReglasNegocioException(ex.Message)

        Catch Ex As BaseDatosException
            db.CancelarTransaccion()
            Throw New ReglasNegocioException("Error al acceder a la base de datos.")
        Catch Ex As Exception
            db.CancelarTransaccion()
            Throw New ReglasNegocioException(Err.Number)
        Finally
            db.Desconectar()
            db.Dispose()
        End Try


    End Sub


End Class
