Imports LogicaNegocio
Public Class frmCaja
    Private sc As Service_Caja
    Private caja As Caja

    Dim id_caja As Integer
    Dim total As Decimal
    Dim cerrada As Boolean

    Private efectivo As Decimal
    Private vales As Decimal
    Private tarjeta As Decimal
    Private pagos As Decimal
    Private venta As Decimal
    Private apartado As Decimal
    Private otros As Decimal
    Private abono As Decimal

    Private Sub frmCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                btnAgregar.PerformClick()
            Case Keys.F3
                btnRetirar.PerformClick()
            Case Keys.F5
                btnGuardar.PerformClick()
        End Select
    End Sub

    Private Sub Caja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        obtenerCaja()
        Me.KeyPreview = True

    End Sub
    Private Sub obtenerCaja()
        Try
            sc = New Service_Caja
            caja = New Caja
            Try
                caja = sc.obtener
                txtMonto.Text = String.Format("{0:c}", caja.Monto_Inicial)
                id_caja = caja.Id
                lblCaja.Text = id_caja
                lblUsuario.Text = caja.Nombre
                dtf.Value = caja.Fecha_Apertura

                btnRetirar.Enabled = True
                btnAgregar.Enabled = True
                btnGuardar.Text = "Cerrar " & Chr(13) & "Caja  "
                cargarGrid()

                cerrada = False
                txtMonto.Enabled = False

            Catch ex As Exception
                btnRetirar.Enabled = False
                btnAgregar.Enabled = False
                btnGuardar.Text = "Guardar"
                id_caja = 0
                lblTotal.Text = String.Format("{0:c}", 0)
                cerrada = True
                Exit Try
            End Try

            sc = Nothing
            'caja = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
    Private Sub limpiar()
        lblUsuario.Text = ""
        lblTotal.Text = String.Format("{0:c}", 0)
        lblCaja.Text = ""
        txtMonto.Text = ""
        btnAgregar.Enabled = False
        btnRetirar.Enabled = False
        btnGuardar.Text = "Guardar"
        id_caja = 0
        total = 0
        cerrada = True
        dgv.DataSource = Nothing
        txtMonto.Enabled = True

        efectivo = 0
        vales = 0
        tarjeta = 0
        pagos = 0
        abono = 0
        otros = 0
    End Sub
    'Private Sub cargarGrid()
    '    Try
    '        sc = New Service_Caja
    '        Dim lista As List(Of Caja.CajaDetalle) = sc.obtenerMovimientos(id_caja)
    '        dgv.DataSource = lista
    '        venta = sc.obtenerTotales(id_caja, "Venta")
    '        apartado = sc.obtenerTotales(id_caja, "Apartado")

    '        total = 0
    '        For i As Integer = 0 To dgv.RowCount - 1
    '            If Not dgv.Rows(i).Cells(4).Value = "Monto Inicial" Then
    '                total += dgv.Rows(i).Cells(3).Value

    '                If dgv.Rows(i).Cells(5).Value = "Efectivo" And dgv.Rows(i).Cells(3).Value > 0 Then
    '                    efectivo += dgv.Rows(i).Cells(3).Value
    '                ElseIf dgv.Rows(i).Cells(5).Value = "Vale" Then
    '                    vales += dgv.Rows(i).Cells(3).Value
    '                ElseIf dgv.Rows(i).Cells(5).Value = "Tarjeta" Then
    '                    tarjeta += dgv.Rows(i).Cells(3).Value
    '                End If
    '                If dgv.Rows(i).Cells(3).Value < 0 Then
    '                    pagos += dgv.Rows(i).Cells(3).Value
    '                End If

    '            End If




    '        Next
    '        lblTotal.Text = String.Format("{0:c}", total)

    '        dgv.Columns(0).Visible = False
    '        dgv.Columns(1).Visible = False
    '        dgv.Columns(2).Width = 120
    '        dgv.Columns(3).Width = 80
    '        dgv.Columns(3).DefaultCellStyle.Format = "c"
    '        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '        dgv.Columns(5).Width = 60



    '        lista = Nothing
    '        sc = Nothing
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub
    Private Sub cargarGrid()
        Try
            sc = New Service_Caja
            Dim lista As List(Of Caja.CajaDetalle) = sc.obtenerMovimientos(id_caja)
            dgv.DataSource = lista
            venta = sc.obtenerTotales(id_caja, "Venta")
            apartado = sc.obtenerTotales(id_caja, "Apartado")
            otros = sc.obtenerTotales(id_caja, "Entrada")
            pagos = sc.obtenerTotales(id_caja, "Retiro")
            Abono = sc.obtenerTotales(id_caja, "Abono Credito")
            total = 0
            vales = 0
            tarjeta = 0
            efectivo = 0

            For i As Integer = 0 To dgv.RowCount - 1
                If Not dgv.Rows(i).Cells(4).Value = "Monto Inicial" Then
                    total += dgv.Rows(i).Cells(3).Value

                    If dgv.Rows(i).Cells(5).Value = "Efectivo" Then
                        efectivo += dgv.Rows(i).Cells(3).Value
                    ElseIf dgv.Rows(i).Cells(5).Value = "Vale" Then
                        vales += dgv.Rows(i).Cells(3).Value
                    ElseIf dgv.Rows(i).Cells(5).Value = "Tarjeta" Then
                        tarjeta += dgv.Rows(i).Cells(3).Value
                    End If
                    'If dgv.Rows(i).Cells(3).Value < 0 Then
                    '    pagos += dgv.Rows(i).Cells(3).Value
                    'End If

                End If




            Next
            lblTotal.Text = String.Format("{0:c}", total)

            dgv.Columns(0).Visible = False
            dgv.Columns(1).Visible = False
            dgv.Columns(2).Width = 120
            dgv.Columns(3).Width = 80
            dgv.Columns(3).DefaultCellStyle.Format = "c"
            dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns(5).Width = 60



            lista = Nothing
            sc = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try

            Dim monto As Decimal
            Try
                monto = CDec(txtMonto.Text)
            Catch ex As Exception
                txtMonto.Text = String.Format("{0:c}", 0)
                Exit Sub
            End Try
            sc = New Service_Caja
            If cerrada Then
                caja = New Caja(0, Sesion.id_usuario_sesion, dtf.Value, dtf.Value, monto, False)
                Sesion.id_caja = sc.Insertar(caja)
                Sesion.caja_abierta = True
                MsgBox("Caja inicial establecida correctamente.")
                caja = Nothing
                cerrada = False
                obtenerCaja()
            Else ''actualizar
                Dim A = MsgBox("Desea realizar el corte de caja? " _
                                     , MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
                If A = vbYes Then
                    Dim fechaCierre As Date = Date.Now
                    sc.actualizar(id_caja, fechaCierre)
                    MsgBox("Caja cerrada correctamente.")
                    If Sesion.imprimeTicket Or Sesion.Abrir_Cajon Then
                        doTicket(caja.Fecha_Apertura, fechaCierre)
                        'ElseIf Sesion.Abrir_Cajon Then
                        '    abreCajon()
                    End If
                    'doTicket(caja.Fecha_Apertura, fechaCierre)


                    limpiar()
                    Sesion.id_caja = Nothing
                    Sesion.caja_abierta = False
                End If
            End If
            sc = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
    Private Sub abreCajon()
        Try
            Dim ticket As New BarControls.Ticket
            ticket.AddHeaderLine("")
            ticket.PrintTicket(Sesion.impresora)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub doTicket(ByVal fechaInicio As Date, ByVal fechaCierre As Date)
        Try

            Dim ticket As New BarControls.Ticket
            ticket.AddHeaderLine(Sesion.negocio)
            ticket.AddHeaderLine(Sesion.direccion)
            ticket.AddHeaderLine(Sesion.ciudad)
            ticket.AddHeaderLine("Corte de Caja " & Sesion.id_caja)
            ticket.AddHeaderLine("Del  " & fechaInicio)
            ticket.AddHeaderLine("  Al  " & fechaCierre)

            ticket.AddSubHeaderLine("Realizó: " & Sesion.nombre_usuario)


            ticket.AddTotal("M. INICIAL", String.Format("{0:c}", caja.Monto_Inicial))
            ticket.AddTotal("TOTAL EN CAJA", String.Format("{0:c}", total))
            ticket.AddTotal("     Efectivo", String.Format("{0:c}", efectivo))

            If Not vales = 0 Then
                ticket.AddTotal("     Vales", String.Format("{0:c}", vales))
            End If
            If Not tarjeta = 0 Then
                ticket.AddTotal("     Tarjeta", String.Format("{0:c}", tarjeta))
            End If


            ticket.AddTotal("", "")
            If Not venta = 0 Then
                ticket.AddTotal("VENTAS", String.Format("{0:c}", venta))
            End If

            If Not apartado = 0 Then
                ticket.AddTotal("APARTADOS", String.Format("{0:c}", apartado))
            End If
            If Not abono = 0 Then
                ticket.AddTotal("ABONO A CREDITO", String.Format("{0:c}", abono))
            End If

            If Not otros = 0 Then
                ticket.AddTotal("OTRAS ENTRADAS", String.Format("{0:c}", otros))
            End If

            If Not pagos = 0 Then
                ticket.AddTotal("PAGOS", String.Format("{0:c}", pagos))
            End If



            ticket.PrintTicket(Sesion.impresora)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnGuardar.PerformClick()
        End If
        If e.KeyChar = Convert.ToChar(13) Then
            '' Me.Button1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(8) Then ' se pulsó Retroceso
            e.Handled = False
        ElseIf (e.KeyChar = ","c) Then ' no permite la coma
            e.Handled = True ' Handled = True, no permite; = False, si permite...
        ElseIf (e.KeyChar = "."c) Then
            Dim ctrl As TextBox = DirectCast(sender, TextBox)
            If (ctrl.Text.IndexOf("."c) <> -1) Then ' sólo puede haber una coma
                e.Handled = True
            End If
        ElseIf (e.KeyChar < "0"c Or e.KeyChar > "9"c) Then
            ' desechar los caracteres que no son dígitos
            e.Handled = True
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        'Try
        '    Dim idV As String = InputBox("Escriba el monto que va a ingresar.")
        '    If idV <> vbNullString Then
        '        Try
        '            Dim monto As Decimal

        '            Try
        '                monto = CDec(idV)
        '            Catch ex As Exception
        '                Throw New ReglasNegocioException("Monto incorrecto")
        '            End Try

        '            sc = New Service_Caja
        '            sc.agregarEfectivo(monto, "Entrada Efectivo", id_caja)
        '            sc = Nothing
        '            cargarGrid()
        '        Catch Ex As Exception
        '            MsgBox(Ex.Message)
        '        End Try
        '    Else

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Try
            Dim frm As New frmInputBox
            frm.lblDescripcion.Text = "Escriba el monto que va a ingresar."
            frm.retirar = False
            frm.ShowDialog()


            If frm.datos Then
                sc = New Service_Caja
                '  sc.agregarEfectivo(frm.monto, frm.concepto, id_caja)
                sc.agregarEfectivo(frm.monto, "Entrada: " & frm.concepto, id_caja)
                sc = Nothing
                cargarGrid()
            End If

            frm = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub btnRetirar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetirar.Click
        'Try
        '    Dim idV As String = InputBox("Escriba el monto que va a retirar.")
        '    If idV <> vbNullString Then
        '        Try

        '            Dim monto As Decimal
        '            Try
        '                monto = CDec(idV)
        '            Catch ex As Exception
        '                Throw New ReglasNegocioException("Monto incorrecto")
        '            End Try

        '            If monto > total Then
        '                Throw New Exception("El monto a retirar no debe ser mayor que el total")
        '            End If
        '            sc = New Service_Caja
        '            sc.agregarEfectivo((monto) * -1, "Salida Efectivo", id_caja)
        '            sc = Nothing
        '            cargarGrid()
        '        Catch Ex As Exception
        '            MsgBox(Ex.Message)
        '        End Try
        '    Else

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Try
            Dim frm As New frmInputBox
            frm.lblDescripcion.Text = "Escriba el monto que va a retirar."
            frm.retirar = True
            frm.total = total
            frm.ShowDialog()

            If frm.datos Then
                sc = New Service_Caja
                'sc.agregarEfectivo((frm.monto) * -1, frm.concepto, id_caja)
                sc.agregarEfectivo((frm.monto) * -1, "Retiro: " & frm.concepto, id_caja)
                sc = Nothing
                cargarGrid()
            End If

            frm = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmCompra_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 35 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
End Class