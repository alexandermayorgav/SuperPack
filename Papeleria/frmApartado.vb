Imports LogicaNegocio
Public Class frmApartado
    Private sAp As Service_Apartado
    Private sCaj As Service_Caja
    Private sCl As Service_Cliente
    Private sAb As Service_AbonoAp
    Private sP As Service_Producto
    Private objAp As Apartado
    Private objAA As AbonoApartado
    Private objC As Cliente
    Private objP As Producto
    Private objFp As FinalizarPago
    Private totalAp As Decimal
    Private desc As Decimal

    Private Sub frmApartado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nuevoApartado(True)
        Me.KeyPreview = True
        sCl = New Service_Cliente
        sP = New Service_Producto
        txtFolioC.Select()
    End Sub

    Private Sub btnObtenerC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnObtenerC.Click
        Try
            nuevoApartado(False)
            obtenerCliente()
        Catch cast As InvalidCastException
            MsgBox("Caracteres incorrectos. Debes proporcionar un folio de cliente (Númerico)")
            txtFolioC.Focus()
            txtFolioC.SelectAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub obtenerCliente()
        Try
            If txtFolioC.Text = "" Then
                MsgBox("Debes proporcionar el folio del cliente")
                txtFolioC.Select()
                txtFolioC.Focus()
            Else
                objC = sCl.Obtener(CInt(txtFolioC.Text))
                txtCliente.Text = objC.Razon
                txtTipoD.Text = objC.Descuento
                txtProducto.Select()
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
            txtFolioC.Focus()
            txtFolioC.SelectAll()
        End Try
    End Sub

    Private Sub txtFolioC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioC.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnObtenerC.PerformClick()
        End If
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If objC Is Nothing Then
                    txtProducto.Text = ""
                    MsgBox("Debe seleccionar un cliente para iniciar el apartado")
                    txtFolioC.Select()
                Else
                    If txtProducto.Text = "" Then
                        MsgBox("Debe proporcionar un codigo correcto ")
                    Else
                        objP = sP.Obtener(txtProducto.Text)
                        txtDescP.Text = objP.Descripcion
                        txtPrecio.Text = FormatCurrency(objP.Precio)
                        txtRango.Text = objP.Rango
                        txtEx.Text = objP.Existencia
                        Select Case objC.Descuento
                            Case 1
                                txtDesc.Text = objP.Descuento_1
                            Case 2
                                txtDesc.Text = objP.Descuento_2
                            Case Else
                                txtDesc.Text = 0
                        End Select
                    End If
                End If
            Catch cast As InvalidCastException
                MsgBox("Debe proporcionar un codigo correcto.")
                txtProducto.Focus()
                txtProducto.SelectAll()
            Catch ex As ReglasNegocioException
                MsgBox(ex.Message)
            Catch Ex As Exception
                MsgBox(Ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtCant_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCant.TextChanged
        Try
            If Not objC.Descuento > 0 AndAlso CInt(txtCant.Text) >= objP.Rango Then
                txtDesc.Text = objP.Descuento
            Else
                Select Case objC.Descuento
                    Case 1
                        txtDesc.Text = objP.Descuento_1
                    Case 2
                        txtDesc.Text = objP.Descuento_2
                    Case Else
                        txtDesc.Text = 0
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBuscarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarC.Click
        Try
            Dim frm As New frmBuscarCliente
            frm.ShowDialog()
            If frm.id_cliente > 0 Then
                txtFolioC.Text = frm.id_cliente
                txtFolioC.Focus()
                btnObtenerC.PerformClick()
                frm = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            txtFolioC.Text = ""
            txtFolioC.Select()
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim frm As New frmBuscarProducto
        frm.ShowDialog()
        txtProducto.Text = frm.codigo
        txtProducto.Focus()
        txtProducto.SelectAll()
        If Not txtProducto.Text = "" Then
            SendKeys.Send("{ENTER}")
        End If
    End Sub

    Private Sub btnProces_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProces.Click
        Try
            If objC Is Nothing Then
                MsgBox("Debes seleccionar un cliente")
                txtFolioC.Select()
            ElseIf objP Is Nothing Then
                MsgBox("Debes seleccionar el producto a apartar")
                txtProducto.Select()
            ElseIf txtCant.Text = "" Then
                MsgBox("Debes especificar una cantidad de producto.")
                txtCant.SelectAll()
            ElseIf CDec(txtCant.Text) < 1 Then
                MsgBox("La cantidad de productos no puede ser menor a 1.")
                txtCant.SelectAll()
            ElseIf CInt(txtCant.Text) > objP.Existencia Then
                MsgBox("No se puede cubrir la cantidad solicitada")
                txtCant.Focus()
                txtCant.SelectAll()
            Else
                If objC.Descuento > 0 Then
                    Select Case objC.Descuento
                        Case 1
                            desc = objP.Descuento_1
                            totalAp = objP.Precio * CInt(txtCant.Text)
                            totalAp = totalAp - (totalAp * (desc / 100))
                        Case 2
                            desc = objP.Descuento_2
                            totalAp = objP.Precio * CInt(txtCant.Text)
                            totalAp = totalAp - (totalAp * (desc / 100))
                        Case Else
                            totalAp = objP.Precio * CInt(txtCant.Text)
                    End Select
                ElseIf CDec(txtDesc.Text) > 0 Then
                    desc = CDec(txtDesc.Text)
                    totalAp = objP.Precio * CInt(txtCant.Text)
                    totalAp = totalAp - (totalAp * (desc / 100))
                Else
                    totalAp = objP.Precio * CInt(txtCant.Text)
                    desc = 0
                End If

                objFp = New FinalizarPago(totalAp, 0, 0, 0, False)
                Dim frm As New frmFormaPago(objFp, True)
                Dim TConformado As Decimal = 0.0
                frm.ShowDialog()
                TConformado = FormatCurrency(frm.totalConformado)

                If objFp.Pagado Then
                    If frm.lista_vales.Count > 0 Or frm.lista_tarjeta.Count > 0 Or frm.efectivo > 0 Then
                        'Dim nomus As String = sUs.Obtenerusuario(id_usuario_sesion).Nombre()
                        Dim fechaH As Date = Utils.ObtenerFechaHora(Date.Now)
                        Dim objAp As New Apartado(objC.Id, id_usuario_sesion, objP.Codigo, CInt(txtCant.Text), totalAp, fechaH)
                        Dim sAp As New Service_Apartado
                        Dim objAb As New AbonoApartado(-1, fechaH, id_caja, id_usuario_sesion, TConformado)

                        If caja_abierta Then
                            Dim folioAp As Integer = sAp.insertar(objAp, objAb, frm.efectivo, frm.lista_vales, frm.lista_tarjeta)
                            MsgBox("Apartado guardado con éxito")
                            '**********CAMBIAR ID CAJA Y NOMBRE DE USUARIO
                            If Sesion.imprimeTicket Then
                                doTicket(id_caja, folioAp, nombre_usuario, fechaH, objC.Razon)
                            ElseIf Sesion.Abrir_Cajon Then
                                abreCajon()
                            End If
                            nuevoApartado(True)
                        Else
                            MsgBox("Debes iniciar la caja para realizar el apartado.")
                            frmCaja.ShowDialog()
                            Exit Sub
                        End If
                    Else
                        MsgBox("Debe consolidar el abono.")
                        btnProces.Select()
                    End If

                End If
            End If

        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevoApartado(True)
    End Sub
    Private Sub abreCajon()
        'Try
        '    Dim ticket As New BarControls.Ticket
        '    ticket.AddHeaderLine("")
        '    ticket.PrintTicket(Sesion.impresora)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Dim im As New Imprime

        Try
            im.AbrirCajon()
        Catch ex As Exception
        Finally
            im = Nothing
        End Try
    End Sub
    Private Sub doTicket(ByVal caja As Integer, ByVal no_ap As Integer, ByVal nom_usuario As String, ByVal fecha As Date, ByVal cliente As String)
        Try

            Dim ticket As New BarControls.Ticket

            ticket.AddHeaderLine(Sesion.negocio)
            ticket.AddHeaderLine(Sesion.direccion)
            ticket.AddHeaderLine(Sesion.ciudad)
            If Not Sesion.telefono = "        " Then
                ticket.AddHeaderLine("Teléfono: " & Sesion.telefono)
            End If

            ticket.AddSubHeaderLine("Apartado    " & fecha)
            ticket.AddSubHeaderLine("Le atendió: " & Sesion.nombre_usuario)
            ticket.AddSubHeaderLine("Folio " & no_ap & "  " & cliente)


            ticket.AddItem(txtCant.Text, objP.Descripcion.ToLower, FormatNumber(objP.Precio, 2), FormatNumber(totalAp, 2))

            If desc > 0 Then
                ticket.AddTotal("*DESCT.", String.Format("{0:c}", (objP.Precio * txtCant.Text) - totalAp))
            End If

            ticket.AddTotal("TOTAL", String.Format("{0:c}", totalAp))
            ticket.AddTotal("EFECTIVO", String.Format("{0:c}", objFp.Efectivo))
            ticket.AddTotal("A USAR", String.Format("{0:c}", objFp.aUsar))
            ticket.AddTotal("CAMBIO", String.Format("{0:c}", objFp.Cambio))
            ticket.AddTotal("", "")
            ticket.AddTotal("RESTANTE", String.Format("{0:c}", objFp.Total - objFp.aUsar))

            ticket.AddFooterLine(Sesion.saludo)
            ticket.AddCode(no_ap)
            ticket.PrintTicket(Sesion.impresora)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

  
    Private Sub nuevoApartado(ByVal cliente As Boolean)
        txtProducto.Text = ""
        txtDescP.Text = ""
        txtEx.Text = ""
        txtPrecio.Text = ""
        txtDesc.Text = ""
        txtRango.Text = ""
        txtCant.Text = 1

        If cliente Then
            txtFolioC.Text = ""
            txtCliente.Text = ""
            txtTipoD.Text = ""
            objC = Nothing
            objAp = Nothing
            objAA = Nothing
            objFp = Nothing
            objP = Nothing
            txtFolioC.Select()
        End If
        txtProducto.Select()
    End Sub

    Private Sub frmApartado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F2 Then
            btnBuscarC.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F7 Then
            nuevoApartado(True)
        End If
        If e.KeyCode = Keys.F5 Then
            btnProces.PerformClick()
        End If
        If e.KeyCode = Keys.F3 Then
            btnBuscar.PerformClick()
        End If
    End Sub
    
    Private Sub frmApartado_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 50 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class

Public Class OrigenExcepcion

    Inherits System.Exception

    Public Shared _nombreProcedimiento As String
    Public Shared _origen As Object

    Public Sub New(ByVal sender As Object, ByVal e As EventArgs, ByVal ex As Exception, ByVal nombreProc As String)

        MyBase.New(ex.Message, ex)

        _nombreProcedimiento = nombreProc
        _origen = sender.GetType

        If TypeOf (sender) Is Control Then

            _origen = DirectCast(sender, Control)

            Dim datosOrg As Type = _origen.GetType
            'Dim tmp As String = String.Format("{1}", datosOrg.Name, datosOrg.FullName)
        Else
            _origen = sender
        End If

    End Sub

End Class
