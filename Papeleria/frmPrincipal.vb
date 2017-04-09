Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports LogicaNegocio

Public Class frmPrincipal
    Private clientMDI As MdiClient
    Private _coord As System.Drawing.Point
    Private privs As List(Of Privilegio)
    Sub New(ByVal usuario As Usuario, ByVal privs As List(Of Privilegio))
        InitializeComponent()
        Me.privs = privs
        configurarPermisos(usuario)
        verificarCaja()

    End Sub
    Private Sub verificarCaja()
        Try
            Dim sC As New Service_Caja
            Dim caja = sC.obtener()

            If caja Is Nothing Then
                'frmCaja.MdiParent = Me
                frmCaja.ShowDialog()
            Else
                id_caja = caja.Id
                caja_abierta = True
            End If
        Catch Ex As ReglasNegocioException
            MsgBox(Ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub configurarPermisos(ByVal usuario As Usuario)
        id_usuario_sesion = usuario.Id_Usuario
        nombre_usuario = usuario.Nombre
        If Not usuario.Id_Grupo = 1 Then
            Dim aborrar As New List(Of String)
            For Each r As TreeNode In tvM.Nodes.Item("rVen").Nodes
                Dim nomr As String = r.Name
                If Not verificaPermiso(nomr) Then
                    aborrar.Add(nomr)
                End If
            Next
            For Each r As TreeNode In tvM.Nodes.Item("rApart").Nodes
                Dim nomr As String = r.Name
                If Not verificaPermiso(nomr) Then
                    aborrar.Add(nomr)
                End If
            Next
            For Each r As TreeNode In tvM.Nodes.Item("rComp").Nodes
                Dim nomr As String = r.Name
                If Not verificaPermiso(nomr) Then
                    aborrar.Add(nomr)
                End If
            Next
            For Each r As TreeNode In tvM.Nodes.Item("rProds").Nodes
                Dim nomr As String = r.Name
                If Not verificaPermiso(nomr) Then
                    aborrar.Add(nomr)
                End If
            Next
            For Each r As TreeNode In tvM.Nodes.Item("rCat").Nodes
                Dim nomr As String = r.Name
                If Not verificaPermiso(nomr) Then
                    aborrar.Add(nomr)
                End If
            Next
            For Each r As TreeNode In tvM.Nodes.Item("rRep").Nodes
                Dim nomr As String = r.Name
                If Not verificaPermiso(nomr) Then
                    aborrar.Add(nomr)
                End If
            Next
            For Each r As TreeNode In tvM.Nodes.Item("rSop").Nodes
                Dim nomr As String = r.Name
                If Not verificaPermiso(nomr) Then
                    aborrar.Add(nomr)
                End If
            Next
            borrarNodos(aborrar)
        End If
    End Sub
    Private Sub borrarNodos(ByVal nodos As List(Of String))
        Try
            For Each it As String In nodos
                Dim n As TreeNode() = tvM.Nodes.Find(it, True)
                If n.Length = 0 Then
                Else
                    n(0).Remove()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function verificaPermiso(ByVal nombre As String) As Boolean
        Try
            For Each perm As Privilegio In privs
                If Not perm Is Nothing Then
                    If perm.Permiso = nombre Then
                        Return True
                    End If
                End If
            Next
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub frmPrincipal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ClearMemory()
    End Sub

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Public Sub ClearMemory()


        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Catch ex As Exception
            'Control de errores
        End Try

    End Sub


    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Sesion.negocio & " / " & Sesion.nombre_usuario
        StripVentanas.Hide()
        Me.KeyPreview = True
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        tvM.ImageList = imgL
        'Dim ctl As Control
        ''se busca el control que representa el cliente del MDI
        'For Each ctl In Me.Controls
        '    Try
        '        clientMDI = CType(ctl, MdiClient)
        '        'color de fondo
        '        clientMDI.BackColor = Color.WhiteSmoke
        '        'asignar manejador para cambiar el color de fondo o degradado
        '        AddHandler clientMDI.Paint, AddressOf Degradado
        '    Catch ex As InvalidCastException
        '    End Try
        'Next

        'Dim mdiclient As MdiClient = Nothing
        'For Each control As Control In Controls
        '    mdiclient = TryCast(control, MdiClient)
        '    If mdiclient IsNot Nothing Then

        '        SetWindowLong(mdiclient.Handle, CInt(-16), GetWindowLong(mdiclient.Handle, CInt(-16)) And Not CInt(&H800000))

        '        SetWindowLong(mdiclient.Handle, CInt(-20), GetWindowLong(mdiclient.Handle, CInt(-20)) And Not CInt(&H200))

        '        SetWindowPos(mdiclient.Handle, IntPtr.Zero, 0, 0, 0, 0, _
        '         CUInt(1 Or 2 Or 4 Or &H10 Or &H20 Or &H200))

        '        Exit For
        '    End If
        'Next
    End Sub

    Private Sub Degradado(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Dim GradientePanel As New LinearGradientBrush(New RectangleF(0, 0, clientMDI.Width, clientMDI.Height), Color.SteelBlue, Color.LightSteelBlue, LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(GradientePanel, New RectangleF(0, 0, clientMDI.Width, clientMDI.Height))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub principalResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try
            If Not (Me.clientMDI Is Nothing) Then
                Me.Degradado(Me.clientMDI, New PaintEventArgs(Me.clientMDI.CreateGraphics, New Rectangle(Me.clientMDI.Location, Me.clientMDI.Size)))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.WindowState = FormWindowState.Maximized
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmLogin.Visible = True
        Me.Close()
    End Sub
    Private Sub frmPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            cerrarSesion()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cerrarSesion()

        Try
            Dim lis As New List(Of Form)

            For Each formaAbierta As Form In My.Application.OpenForms
                If TypeOf (formaAbierta) Is frmLogin Or TypeOf (formaAbierta) Is frmPrincipal Then
                Else
                    lis.Add(formaAbierta)
                End If
            Next
            For Each it As Form In lis
                If Not TypeOf (it) Is frmLogin Or Not TypeOf (it) Is frmPrincipal Then
                    it.Close()
                    it.Dispose()
                End If
            Next
            lis = Nothing
            id_usuario_sesion = -1
            frmLogin.Show()
            frmLogin.txtUsuario.Text = ""
            frmLogin.txtPass.Text = ""
            frmLogin.txtUsuario.Focus()
            ''Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tvM_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvM.DoubleClick
        Dim nodo As System.Windows.Forms.TreeNode = tvM.GetNodeAt(_coord)
        If (Not nodo Is Nothing) AndAlso nodo.Bounds.Contains(_coord) Then
            despliega(nodo.Name)
        End If
    End Sub


    Private Sub tvM_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvM.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim nodo As TreeNode = tvM.GetNodeAt(_coord)
            If (Not nodo Is Nothing) AndAlso nodo.Bounds.Contains(_coord) Then
                despliega(nodo.Name)
            End If

        End If

    End Sub

    Private Sub tvM_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvM.MouseUp
        With _coord
            .X = e.X
            .Y = e.Y
        End With
    End Sub

    Private Sub tvM_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvM.AfterSelect
        'frmVenta.Show()
    End Sub

    Private Function estaabierto(ByVal form As Form) As Boolean
        For Each formaAbierta As Form In My.Application.OpenForms
            If form.Name = formaAbierta.Name Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub cerrada(ByVal obj As Object, ByVal e As System.EventArgs)

        StripVentanas.Items.RemoveByKey(CType(obj, Form).Name)
    End Sub



    Private Sub despliega(ByVal nodo As String)
        Try
            Select Case nodo
                Case "ven,1"
                    If estaabierto(frmVenta) Then
                        frmVenta.BringToFront()
                    Else
                        AddHandler frmVenta.FormClosing, AddressOf cerrada
                        frmVenta.Show()

                    End If
                Case "ven,2"
                    If estaabierto(frmDevVenta) Then
                        frmDevVenta.BringToFront()
                    Else
                        AddHandler frmDevVenta.FormClosing, AddressOf cerrada
                        frmDevVenta.MdiParent = Me
                        frmDevVenta.Show()
                    End If
                Case "ven,3"
                    If estaabierto(frmCaja) Then
                        frmCaja.BringToFront()

                    Else
                        AddHandler frmCaja.FormClosing, AddressOf cerrada
                        frmCaja.MdiParent = Me
                        frmCaja.Show()
                    End If
                Case "ven,4"
                    If estaabierto(frmAbonoCredito) Then
                        frmAbonoCredito.BringToFront()
                    Else
                        AddHandler frmAbonoCredito.FormClosing, AddressOf cerrada
                        '  frmAbonoCredito.MdiParent = Me
                        frmAbonoCredito.Show()
                    End If
                Case "ven,5"
                    If estaabierto(frmVales) Then
                        frmVales.BringToFront()
                    Else
                        AddHandler frmVales.FormClosing, AddressOf cerrada
                        frmVales.MdiParent = Me
                        frmVales.Show()
                    End If
                Case "ven,6"
                    'If estaabierto(frmFacturar) Then
                    '    frmFacturar.BringToFront()
                    'Else
                    '    AddHandler frmFacturar.FormClosing, AddressOf cerrada
                    '    frmFacturar.MdiParent = Me
                    '    frmFacturar.Show()
                    'End If
                Case "serv,1"
                    If estaabierto(frmRecepServicio) Then
                        frmRecepServicio.BringToFront()
                    Else
                        AddHandler frmRecepServicio.FormClosing, AddressOf cerrada
                        frmRecepServicio.MdiParent = Me
                        frmRecepServicio.Show()
                    End If
                Case "serv,2"
                    If estaabierto(frmSegServicio) Then
                        frmSegServicio.BringToFront()
                    Else
                        AddHandler frmSegServicio.FormClosing, AddressOf cerrada
                        frmSegServicio.MdiParent = Me
                        frmSegServicio.Show()
                    End If
                Case "serv,3"
                    'If estaabierto(frmConsServicios) Then
                    '    frmConsServicios.BringToFront()
                    'Else
                    '    AddHandler frmConsServicios.FormClosing, AddressOf cerrada
                    '    frmConsServicios.MdiParent = Me
                    '    frmConsServicios.Show()
                    'End If
                Case "ap,1"
                    If estaabierto(frmApartado) Then
                        frmApartado.BringToFront()
                    Else
                        AddHandler frmApartado.FormClosing, AddressOf cerrada
                        frmApartado.MdiParent = Me
                        frmApartado.Show()
                    End If
                Case "ap,2"
                    If estaabierto(frmAdminApartado) Then
                        frmAdminApartado.BringToFront()
                    Else
                        AddHandler frmAdminApartado.FormClosing, AddressOf cerrada
                        frmAdminApartado.MdiParent = Me
                        frmAdminApartado.Show()
                    End If
                Case "com,1"
                    If estaabierto(frmCompraSP) Then
                        frmCompraSP.BringToFront()
                    Else
                        AddHandler frmCompraSP.FormClosing, AddressOf cerrada
                        frmCompraSP.Show()
                    End If
                Case "com,2"
                    If estaabierto(frmAbonoCuentaPagar) Then
                        frmAbonoCuentaPagar.BringToFront()
                    Else
                        AddHandler frmAbonoCuentaPagar.FormClosing, AddressOf cerrada
                        frmAbonoCuentaPagar.MdiParent = Me
                        frmAbonoCuentaPagar.Show()
                    End If
                Case "com,3"
                    If estaabierto(frmSalidas) Then
                        frmSalidas.BringToFront()
                    Else
                        AddHandler frmSalidas.FormClosing, AddressOf cerrada
                        frmSalidas.MdiParent = Me
                        frmSalidas.Show()
                    End If
                Case "pro,1"
                    If estaabierto(frmProductos) Then
                        frmProductos.BringToFront()
                    Else
                        AddHandler frmProductos.FormClosing, AddressOf cerrada
                        'frmProductos.MdiParent = Me
                        frmProductos.Show()
                    End If
                Case "pro,2"
                    If estaabierto(frmLineas) Then
                        frmLineas.BringToFront()
                    Else
                        AddHandler frmLineas.FormClosing, AddressOf cerrada
                        frmLineas.MdiParent = Me
                        frmLineas.Show()
                    End If
                Case "pro,3"
                    If estaabierto(frmPromociones) Then
                        frmPromociones.BringToFront()
                    Else
                        AddHandler frmPromociones.FormClosing, AddressOf cerrada
                        frmPromociones.MdiParent = Me
                        frmPromociones.Show()
                    End If
                Case "pro,4"
                    If estaabierto(frmBuscadorProductos) Then
                        frmBuscadorProductos.BringToFront()
                    Else
                        AddHandler frmBuscadorProductos.FormClosing, AddressOf cerrada
                        frmBuscadorProductos.MdiParent = Me
                        frmBuscadorProductos.Show()
                    End If
                Case "pro,5"
                    If estaabierto(frmVendSinExist) Then
                        frmVendSinExist.BringToFront()
                    Else
                        AddHandler frmVendSinExist.FormClosing, AddressOf cerrada
                        frmVendSinExist.MdiParent = Me
                        frmVendSinExist.Show()
                    End If
                Case "pro,6"
                    If estaabierto(frmTraspaso) Then
                        frmTraspaso.BringToFront()
                    Else
                        AddHandler frmTraspaso.FormClosing, AddressOf cerrada
                        '  frmTraspaso.MdiParent = Me
                        frmTraspaso.Show()
                    End If
                Case "ca,1"
                    If estaabierto(frmPersonal) Then
                        frmPersonal.BringToFront()
                    Else
                        AddHandler frmPersonal.FormClosing, AddressOf cerrada
                        frmPersonal.MdiParent = Me
                        frmPersonal.Show()
                    End If
                Case "ca,2"
                    If estaabierto(frmUsuarios) Then
                        frmUsuarios.BringToFront()
                    Else
                        AddHandler frmUsuarios.FormClosing, AddressOf cerrada
                        frmUsuarios.MdiParent = Me
                        frmUsuarios.Show()
                    End If
                Case "ca,3"
                    If estaabierto(frmCliente) Then
                        frmCliente.BringToFront()
                    Else
                        AddHandler frmCliente.FormClosing, AddressOf cerrada
                        frmCliente.MdiParent = Me
                        frmCliente.Show()
                    End If
                Case "ca,4"
                    If estaabierto(frmProveedor) Then
                        frmProveedor.BringToFront()
                    Else
                        AddHandler frmProveedor.FormClosing, AddressOf cerrada
                        frmProveedor.MdiParent = Me
                        frmProveedor.Show()
                    End If
                Case "ca,5"
                    If estaabierto(frmCodigosHermanos) Then
                        frmCodigosHermanos.BringToFront()
                    Else
                        AddHandler frmCodigosHermanos.FormClosing, AddressOf cerrada
                        frmCodigosHermanos.MdiParent = Me
                        frmCodigosHermanos.Show()
                    End If
                Case "con,1"
                    If estaabierto(frmResumenVentas) Then
                        frmResumenVentas.BringToFront()
                    Else
                        AddHandler frmResumenVentas.FormClosing, AddressOf cerrada
                        frmResumenVentas.MdiParent = Me
                        frmResumenVentas.Show()
                    End If
                Case "con,2"
                    If estaabierto(frmResumenCompras) Then
                        frmResumenCompras.BringToFront()
                    Else
                        AddHandler frmResumenCompras.FormClosing, AddressOf cerrada
                        frmResumenCompras.MdiParent = Me
                        frmResumenCompras.Show()
                    End If
                Case "con,3"
                    If estaabierto(frmDeudas) Then
                        frmDeudas.BringToFront()
                    Else
                        AddHandler frmDeudas.FormClosing, AddressOf cerrada
                        frmDeudas.MdiParent = Me
                        frmDeudas.Show()
                    End If
                Case "con,4"
                    If estaabierto(frmFaltantes) Then
                        frmFaltantes.BringToFront()
                    Else
                        AddHandler frmFaltantes.FormClosing, AddressOf cerrada
                        frmFaltantes.MdiParent = Me
                        frmFaltantes.Show()
                    End If
                Case "con,5"
                    If estaabierto(frmCuentasPagar) Then
                        frmCuentasPagar.BringToFront()
                    Else
                        AddHandler frmCuentasPagar.FormClosing, AddressOf cerrada
                        frmCuentasPagar.MdiParent = Me
                        frmCuentasPagar.Show()
                    End If
                Case "con,6"
                    If estaabierto(frmInventarios) Then
                        frmInventarios.BringToFront()
                    Else
                        AddHandler frmInventarios.FormClosing, AddressOf cerrada
                        frmInventarios.MdiParent = Me
                        frmInventarios.Show()
                    End If
                Case "con,7"
                    If estaabierto(frmcortes) Then
                        frmcortes.BringToFront()
                    Else
                        AddHandler frmcortes.FormClosing, AddressOf cerrada
                        frmcortes.MdiParent = Me
                        frmcortes.Show()
                    End If
                Case "con,8"
                    If estaabierto(frmConsultaSalidas) Then
                        frmConsultaSalidas.BringToFront()
                    Else
                        AddHandler frmConsultaSalidas.FormClosing, AddressOf cerrada
                        frmConsultaSalidas.MdiParent = Me
                        frmConsultaSalidas.Show()
                    End If
                Case "con,9"
                    If estaabierto(frmProveedor) Then
                        frmProveedor.BringToFront()
                    Else
                        AddHandler frmConsultaCompras.FormClosing, AddressOf cerrada
                        frmConsultaCompras.MdiParent = Me
                        frmConsultaCompras.Show()
                    End If
                Case "con,10"
                    If estaabierto(frmCotizacion) Then
                        frmCotizacion.BringToFront()
                    Else
                        AddHandler frmCotizacion.FormClosing, AddressOf cerrada
                        frmCotizacion.MdiParent = Me
                        frmCotizacion.Show()
                    End If
                Case "con,11"
                    If estaabierto(frmProdActualizados) Then
                        frmProdActualizados.BringToFront()
                    Else
                        AddHandler frmProdActualizados.FormClosing, AddressOf cerrada
                        frmProdActualizados.MdiParent = Me
                        frmProdActualizados.Show()
                    End If
                Case "conf,1"
                    If estaabierto(frmAdmonBD) Then
                        frmAdmonBD.BringToFront()
                    Else
                        AddHandler frmAdmonBD.FormClosing, AddressOf cerrada
                        frmAdmonBD.MdiParent = Me
                        frmAdmonBD.Show()
                    End If
                Case "conf,2"
                    If estaabierto(frmConfiguracion) Then
                        frmConfiguracion.BringToFront()
                    Else
                        AddHandler frmConfiguracion.FormClosing, AddressOf cerrada
                        frmConfiguracion.MdiParent = Me
                        frmConfiguracion.Show()
                    End If

                Case "conf,3"

                    If estaabierto(frmFolios) Then
                        frmFolios.BringToFront()
                    Else
                        AddHandler frmFolios.FormClosing, AddressOf cerrada
                        frmFolios.MdiParent = Me
                        frmFolios.Show()
                    End If
                Case "conf,4"
                    System.Diagnostics.Process.Start("Ayuda\BManualSistema.pdf")
                Case Else

            End Select

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Function obtenerNombreForm(ByVal nodo As String)
        Try
            Select Case nodo
                Case "frmVenta"
                    Return "ven,1"
                Case "frmDevVenta"
                    Return "ven,2"
                Case "frmCaja"
                    Return "ven,3"
                Case "frmAbonoCredito"
                    Return "ven,4"
                Case "frmVales"
                    Return "ven,5"
                Case "frmFacturar"
                    Return "ven,6"
                Case "frmRecepServicio"
                    Return "serv,1"
                Case "frmSegServicio"
                    Return "serv,2"
                Case "frmApartado"
                    Return "ap,1"
                Case "frmAdminApartado"
                    Return "ap,2"
                Case "frmCompra"
                    Return "com,1"
                Case "frmAbonoCuentaPagar"
                    Return "com,2"
                Case "frmSalidas"
                    Return "com,3"
                Case "frmProductos"
                    Return "pro,1"
                Case "frmLineas"
                    Return "pro,2"
                Case "frmPromociones"
                    Return "pro,3"
                Case "frmBuscadorProductos"
                    Return "pro,4"
                Case "frmVendSinExist"
                    Return "pro,5"
                Case "frmTraspaso"
                    Return "pro,6"
                Case "frmPersonal"
                    Return "ca,1"
                Case "frmUsuarios"
                    Return "ca,2"
                Case "frmCliente"
                    Return "ca,3"
                Case "frmProveedor"
                    Return "ca,4"
                Case "frmCodigosHermanos"
                    Return "ca,5"
                Case "frmResumenVentas"
                    Return "con,1"
                Case "frmResumenCompras"
                    Return "con,2"
                Case "frmDeudas"
                    Return "con,3"
                Case "frmFaltantes"
                    Return "con,4"
                Case "frmCuentasPagar"
                    Return "con,5"
                Case "frmInventarios"
                    Return "con,6"
                Case "frmcortes"
                    Return "con,7"
                Case "frmConsultaSalidas"
                    Return "con,8"
                Case "frmConsultaCompras"
                    Return "con,9"
                Case "frmCotizacion"
                    Return "con,10"
                Case "frmAdmonBD"
                    Return "conf,1"
                Case "frmConfiguracion"
                    Return "conf,2"
                Case "frmFolios"
                    Return "conf,3"
                Case Else

            End Select

        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Return Nothing
    End Function

    Private Sub frmPrincipal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim confirmacion = MsgBox("¿Cerrar sesión del sistema?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
            If confirmacion = vbYes Then
                Me.Close()
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            System.Diagnostics.Process.Start("BManualSistema.pdf")
        End If
        If e.KeyCode = Keys.F12 Then
            Dim frm As New frmVenta
            frm.Show()
        End If
    End Sub



    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        StripVentanas.Hide()
        tvM.Show()

    End Sub

    Private Sub creabotones()
        Try

            For Each formaAbierta As Form In My.Application.OpenForms
                If TypeOf (formaAbierta) Is frmLogin Or TypeOf (formaAbierta) Is frmPrincipal Then
                Else
                    If Not StripVentanas.Items.ContainsKey((formaAbierta.Name)) Then
                        Dim too As New ToolStripButton(formaAbierta.Text)
                        too.Name = formaAbierta.Name
                        too.TextDirection = ToolStripTextDirection.Vertical270
                        AddHandler too.Click, AddressOf spliterclick
                        StripVentanas.Items.Add(too)

                    End If



                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub spliterclick(ByVal sender As Object, ByVal e As System.EventArgs)

        Try

            For Each formaAbierta As Form In My.Application.OpenForms
                If formaAbierta.Name = CType(sender, ToolStripButton).Name Then
                    Dim forma As String = obtenerNombreForm(CType(sender, ToolStripButton).Name)
                    despliega(forma)

                    Exit For
                End If


            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Splitter2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Splitter2.DoubleClick
        tvM.Hide()
        Splitter2.Dock = DockStyle.Left
        creabotones()
        StripVentanas.Show()

    End Sub


    Private Sub tvM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvM.KeyDown
        Dim nodo As TreeNode
        NODO = tvM.SelectedNode
        If e.KeyCode = Keys.Enter Then
                despliega(nodo.Name)
        End If
    End Sub
End Class


'Partial Public Class frmPrincipal
'    <System.Runtime.InteropServices.DllImport("user32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
'Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal iIndex As Integer, ByVal lNewVal As Integer) As Integer
'    End Function

'    <System.Runtime.InteropServices.DllImport("user32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
'    Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal iIndex As Integer) As Integer
'    End Function

'    <System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling:=True)> _
'    Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hwndInsertAfter As IntPtr, ByVal iX As Integer, ByVal iY As Integer, ByVal iWidth As Integer, ByVal iHeight As Integer, _
'     ByVal uWinPosFlags As UInteger) As Integer
'    End Function

'End Class