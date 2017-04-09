Imports LogicaNegocio
Public Class frmUsuarios

    Private per As Permisos
    Private catuser As Service_Usuario
    Public formclave As String = "c1"
    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_usuario_sesion = 1 Then
            btnPassword.Enabled = True
            btnPassword.Visible = True
        Else
            btnPassword.Enabled = False
            btnPassword.Visible = False

        End If
        Iniciar()
        CargarUsuarios()
        'Grupos con susu usuarios
        CargarGrupos()
        CargarGruposUsuarios()

        'Grupos con los permisos
        cargargrupos2()
        cargagruposprivilegios()
    End Sub

    Private Sub cargagruposprivilegios()
        Try

            Dim catp As New Service_Privilegios
            For Each item As Privilegio In catp.Obtener_Todos
                For Each node As TreeNode In tvPrivilegios.Nodes
                    If "gr," & item.Id_Grupo = node.Name Then
                        Dim nodo As New TreeNode
                        nodo.Name = item.Id_Privilegio
                        Dim compara As String = CargarApartato(item.Permiso) & "|" & per.obtenerNombre(item.Permiso)
                        nodo.Text = compara
                        node.Nodes.Add(nodo)
                        Exit For
                    End If
                Next
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargargrupos2()
        Try
            tvPrivilegios.Nodes.Clear()

            Dim image As New ImageList

            image.Images.Add(My.Resources.apply)
            image.Images.Add(my.Resources._1rightarrow)
            image.Images.Add(My.Resources._1downarrow)
            tvPrivilegios.ImageList = image
            tvpermisos.ImageList = image
            Dim cat As New Service_Grupos

            For Each item As Grupo In cat.Obtener_Todos
                Dim tree As New TreeNode
                tree.Text = item.Nombre
                tree.Name = "gr," & item.Id_Grupo
                tree.ImageIndex = 1
                tree.SelectedImageIndex = 2
                tvPrivilegios.Nodes.Add(tree)
            Next
            tvPrivilegios.ExpandAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarGruposUsuarios()
        Try

            For Each item As Usuario In catuser.Obtener_Todos
                For Each node As TreeNode In tvgrupos.Nodes
                    If "gr," & item.Id_Grupo = node.Name Then
                        Dim nodo As New TreeNode
                        nodo.Name = item.Id_Usuario
                        nodo.Text = item.Usuario
                        node.Nodes.Add(nodo)
                        Exit For
                    End If
                Next
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CargarGrupos()
        Try

            tvgrupos.Nodes.Clear()
            Dim image As New ImageList
            image.Images.Add(My.Resources.otro)
            image.Images.Add(My.Resources._1rightarrow)
            image.Images.Add(My.Resources._1downarrow)
            tvgrupos.ImageList = image
            Dim cat As New Service_Grupos

            For Each item As Grupo In cat.Obtener_Todos
                Dim tree As New TreeNode
                tree.Text = item.Nombre
                tree.Name = "gr," & item.Id_Grupo
                tree.ImageIndex = 1
                tree.SelectedImageIndex = 2
                tvgrupos.Nodes.Add(tree)
            Next
            tvgrupos.ExpandAll()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CargarUsuarios()
        Try
            DGVusers.DataSource = catuser.Obtener_Todos
            DGVusers.Columns("PASSWORD").Visible = False
            DGVusers.Columns("ID_USUARIO").Visible = False
            DGVusers.Columns("ID_PERSONAL").Visible = False
            DGVusers.Columns("ID_GRUPO").Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Iniciar()
        per = New Permisos
        catuser = New Service_Usuario

    End Sub

    Private Sub cbVentanas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVentanas.SelectedIndexChanged
        CargarTreviewPermisos(cbVentanas.SelectedItem)
    End Sub


    Private Sub CargarTreviewPermisos(ByVal tipo As String)

        tvpermisos.Nodes.Clear()

        Dim busqueda = From perm In per.Permisos Where perm.Apartado = tipo Select perm.Apartado, perm.Clave, perm.Nombre


        Dim tree As New TreeNode

        For Each item In busqueda.ToList
            tree.Text = item.Apartado
            tree.Nodes.Add(item.Clave, item.Nombre)
            tree.ImageIndex = 1
        Next

        tvpermisos.Nodes.Add(tree)
        tvpermisos.ExpandAll()


    End Sub


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tvpermisos.Nodes.Remove(tvpermisos.SelectedNode)
    End Sub


    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        BorrarPrivilegios(tvPrivilegios.SelectedNode.Name)
        tvPrivilegios.Nodes.Remove(tvPrivilegios.SelectedNode)

    End Sub

    Private Sub BorrarUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarUsuarioToolStripMenuItem.Click
        BorrarUsuario(tvgrupos.SelectedNode.Name)
        tvgrupos.Nodes.Remove(tvgrupos.SelectedNode)
    End Sub




    Private Sub tvpermisos_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvpermisos.NodeMouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then
            tvpermisos.SelectedNode = e.Node
        End If

    End Sub



    Private Sub tvprivilegios_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvPrivilegios.AfterCollapse
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 2
            e.Node.SelectedImageIndex = 2
        Else
            e.Node.ImageIndex = 1
            e.Node.SelectedImageIndex = 1
        End If

    End Sub

    Private Sub tvprivilegios_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvPrivilegios.BeforeExpand
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 2
            e.Node.SelectedImageIndex = 2
        Else
            e.Node.ImageIndex = 1
            e.Node.SelectedImageIndex = 1
        End If

    End Sub


    Private Sub tvpermisos_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvpermisos.AfterCollapse
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 2
            e.Node.SelectedImageIndex = 2
        Else
            e.Node.ImageIndex = 1
            e.Node.SelectedImageIndex = 1
        End If
    End Sub

    Private Sub tvpermisos_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvpermisos.BeforeExpand
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 2
            e.Node.SelectedImageIndex = 2
        Else
            e.Node.SelectedImageIndex = 1
            e.Node.ImageIndex = 1
        End If
    End Sub

    Private Sub tvgrupos_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvgrupos.BeforeExpand
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 2
            If e.Node.Nodes.Count > 0 Then
                e.Node.SelectedImageIndex = 2
            End If

        Else
            e.Node.ImageIndex = 1
            If e.Node.Nodes.Count > 0 Then
                e.Node.SelectedImageIndex = 1
            End If
        End If

    End Sub

    Private Sub tvgrupos_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvgrupos.AfterCollapse
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 2
            If e.Node.Nodes.Count > 0 Then
                e.Node.SelectedImageIndex = 2
            End If

        Else
            e.Node.ImageIndex = 1
            If e.Node.Nodes.Count > 0 Then
                e.Node.SelectedImageIndex = 1
            End If
        End If

    End Sub

   

    Private Sub tvgruposNodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvgrupos.NodeMouseClick

        
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim tipo As String = e.Node.Name.Split(",").GetValue(0)

            tvgrupos.SelectedNode = e.Node
            'If e.Node.Nodes.Count > 0 Then
            '    tvgrupos.SelectedNode.SelectedImageIndex = 2
            'Else
            '    tvgrupos.SelectedNode.SelectedImageIndex = 1
            'End If
            If tipo = "gr" Then
                e.Node.ContextMenuStrip = menugrupos
                e.Node.ContextMenuStrip.Show()
            Else
                e.Node.ContextMenuStrip = menuusuarios
                e.Node.ContextMenuStrip.Show()
            End If

       
        End If

    End Sub




    Private Sub tvprivilegiosNodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvPrivilegios.NodeMouseClick

      
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim tipo As String = e.Node.Name.Split(",").GetValue(0)
            tvgrupos.SelectedNode = e.Node
            'If e.Node.Nodes.Count > 0 Then
            '    tvgrupos.SelectedNode.SelectedImageIndex = 2
            'Else
            '    tvgrupos.SelectedNode.SelectedImageIndex = 1
            'End If
            If tipo <> "gr" Then
                e.Node.ContextMenuStrip = menuprivilegios
                e.Node.ContextMenuStrip.Show()
            End If

        End If

    End Sub




    Private Sub tvpermisos_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles tvpermisos.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub



    Private Sub tvPrivilegios_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvPrivilegios.DragDrop
        Dim NewNode As TreeNode

        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", False) Then
            Dim pt As Point
            Dim DestinationNode As TreeNode
            pt = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
            DestinationNode = CType(sender, TreeView).GetNodeAt(pt)
            NewNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"),  _
                                            TreeNode)
            If Not DestinationNode.TreeView Is NewNode.TreeView Then
                Dim compara = CargarApartato(NewNode.Name) & "|" & NewNode.Text
                If DestinationNode.Parent Is Nothing Then

                    For Each item As TreeNode In DestinationNode.Nodes
                        If item.Text = compara Then
                            Exit Sub
                        End If
                    Next
                    Dim nodo As TreeNode = NewNode.Clone
                    nodo.Text = compara
                    DestinationNode.Nodes.Add(nodo)
                    Dim add As Integer = AgregarPrivilegio(DestinationNode.Name, nodo.Text)
                    If add <> -1 Then
                        nodo.Name = add
                    End If

                Else
                    For Each item As TreeNode In DestinationNode.Parent.Nodes
                        If item.Text = compara Then
                            Exit Sub
                        End If
                    Next
                    Dim nodo As TreeNode = NewNode.Clone
                    nodo.Text = compara
                    DestinationNode.Parent.Nodes.Add(nodo)
                    Dim add As Integer = AgregarPrivilegio(DestinationNode.Parent.Name, nodo.Text)
                    If add <> -1 Then
                        nodo.Name = add
                    End If
                End If

                DestinationNode.Expand()
                'Remove original node
                '   NewNode.Remove()
            End If
        End If

    End Sub

    Private Sub tvPrivilegios_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvPrivilegios.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub


    Private Sub tvPrivilegios_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvPrivilegios.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            tvPrivilegios.SelectedNode = e.Node
        End If
    End Sub


    Class Permisos

        Private _permisos As List(Of Permiso)
        Sub New()
            _permisos = New List(Of Permiso)
            Cargar()
        End Sub

        Public Function obtenerClave(ByVal text As String) As String
            Dim busq As String = text.Split("|").GetValue(1)
            For Each item As Permiso In Permisos
                If item.Nombre = busq Then
                    busq = item.Clave
                    Exit For
                End If
            Next
            Return busq
        End Function

        Public Function obtenerNombre(ByVal clave As String) As String
            Dim nombre As String = ""
            For Each item As Permiso In Permisos
                If item.Clave = clave Then
                    nombre = item.Nombre
                    Exit For
                End If
            Next
            Return nombre
        End Function
        Private Sub Cargar()
            Permisos.Add(New Permiso("Nueva Venta", "ven,1"))
            Permisos.Add(New Permiso("Devoluciones Venta", "ven,2"))
            Permisos.Add(New Permiso("Caja", "ven,3"))
            Permisos.Add(New Permiso("Abonos Credito", "ven,4"))
            Permisos.Add(New Permiso("Vales", "ven,5"))
            '   Permisos.Add(New Permiso("Facturar", "ven,6"))

            Permisos.Add(New Permiso("Nuevo", "ap,1"))
            Permisos.Add(New Permiso("Administrar Apartado", "ap,2"))

            Permisos.Add(New Permiso("Nueva Compra", "com,1"))
            Permisos.Add(New Permiso("Abonos", "com,2"))
            Permisos.Add(New Permiso("Devoluciones Compra", "com,3"))

            Permisos.Add(New Permiso("Administrar Productos", "pro,1"))
            Permisos.Add(New Permiso("Lineas", "pro,2"))
            Permisos.Add(New Permiso("Promociones", "pro,3"))
            Permisos.Add(New Permiso("Buscador", "pro,4"))
            Permisos.Add(New Permiso("Vendidos Sin Existencia", "pro,5"))
            Permisos.Add(New Permiso("Traspasos", "pro,6"))

            Permisos.Add(New Permiso("Personal", "ca,1"))
            Permisos.Add(New Permiso("Usuarios", "ca,2"))
            Permisos.Add(New Permiso("Clientes", "ca,3"))
            Permisos.Add(New Permiso("Proveedor", "ca,4"))
            Permisos.Add(New Permiso("Codigos Hermanos", "ca,5"))

            Permisos.Add(New Permiso("Ventas", "con,1"))
            Permisos.Add(New Permiso("Compras", "con,2"))
            Permisos.Add(New Permiso("Deudas", "con,3"))
            Permisos.Add(New Permiso("Productos", "con,4"))
            Permisos.Add(New Permiso("Cuentas por Cobrar", "con,5"))
            Permisos.Add(New Permiso("Inventarios", "con,6"))
            Permisos.Add(New Permiso("Corte de Caja", "con,7"))
            Permisos.Add(New Permiso("Salidas Detalles", "con,8"))
            Permisos.Add(New Permiso("Compras Detalles", "con,9"))
            Permisos.Add(New Permiso("Cotizaciones", "con,10"))


            Permisos.Add(New Permiso("Administracion", "conf,1"))
            Permisos.Add(New Permiso("Configuracion", "conf,2"))
            'Permisos.Add(New Permiso("Folios", "conf,3"))




        End Sub


        Public ReadOnly Property Permisos() As List(Of Permiso)
            Get
                Return _permisos
            End Get
        End Property

    End Class

    Class Permiso
        Private _nombre As String
        Private _clave As String
        Private _apartado As String
        Sub New()

        End Sub
        Sub New(ByVal nombre As String, ByVal clave As String)
            Me.Nombre = nombre
            Me.Clave = clave
            Me.Apartado = frmUsuarios.CargarApartato(clave)
        End Sub
        Public Property Nombre() As String
            Get
                Return _nombre
            End Get
            Set(ByVal value As String)
                _nombre = value
            End Set
        End Property
        Public Property Clave() As String
            Get
                Return _clave
            End Get
            Set(ByVal value As String)
                _clave = value
            End Set
        End Property
        Public Property Apartado() As String
            Get
                Return _apartado
            End Get
            Set(ByVal value As String)
                _apartado = value
            End Set
        End Property


    End Class
    Private Function CargarApartato(ByVal clave As String) As String
        Dim tipo As String = clave.Split(",").GetValue(0)
        If tipo = "ven" Then
            Return "Ventas"
        ElseIf tipo = "ap" Then
            Return "Apartado"
        ElseIf tipo = "com" Then
            Return "Compras"
        ElseIf tipo = "pro" Then
            Return "Productos"
        ElseIf tipo = "ca" Then
            Return "Catalogos"
        ElseIf tipo = "con" Then
            Return "Consultas"
        ElseIf tipo = "conf" Then
            Return "Configuracion y Soporte"

        End If
        Return ""
    End Function

    Private Function AgregarPrivilegio(ByVal idgrupo As String, ByVal permiso As String) As Integer

        Try
            Dim catpri As New Service_Privilegios

            Dim id_grupo As String = idgrupo.Split(",").GetValue(1)
            Dim privilegio As New Privilegio(-1, id_grupo, per.obtenerClave(permiso))
            catpri.Insertar(privilegio)
            Return privilegio.Id_Privilegio
        Catch ex As Exception
            Return -1
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub BorrarPrivilegios(ByVal id As String)
        Try
            Dim catpro As New Service_Privilegios
            catpro.Borrar(id)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BorrarUsuario(ByVal id As Integer)
        Try
            Dim cat As New Service_Usuario

            Dim user As Usuario = cat.Obtener(id)

            user.Id_Grupo = 2

            cat.Actualizar(user)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub DGVusers_CellMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGVusers.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim grid As DataGridView.HitTestInfo = DGVusers.HitTest(e.X, e.Y)

            If grid.RowIndex >= 0 Then

                Dim data As Usuario = CType(DGVusers.Rows(grid.RowIndex).DataBoundItem, Usuario)

                If Not data Is Nothing Then
                    DGVusers.DoDragDrop(data, DragDropEffects.Copy)
                End If


            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            'Dim grid As DataGridView.HitTestInfo = DGVusers.HitTest(e.X, e.Y)
            'If grid.RowIndex >= 0 Then
            '    DGVusers.Rows(grid.RowIndex).Selected = True
            '    DGVusers.Rows(1).Stat = DataGridViewElementStates.Selected
            'End If
        End If

    End Sub



    Private Sub tvgrupos_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvgrupos.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub


    Private Sub tvgrupos_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvgrupos.DragDrop


        Dim user As Usuario

        If e.Data.GetDataPresent("LogicaNegocio.Usuario", False) Then
            Dim pt As Point
            Dim DestinationNode As TreeNode
            pt = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
            DestinationNode = CType(sender, TreeView).GetNodeAt(pt)
            user = CType(e.Data.GetData("LogicaNegocio.Usuario"), Usuario)
            'If Not DestinationNode.TreeView Is NewNode.TreeView Then
            'Dim compara = CargarApartato(NewNode.Name) & "|" & NewNode.Text
            If DestinationNode.Parent Is Nothing Then


                If Not hayUsuario(user.Id_Usuario) Then
                    Dim nodo As New TreeNode
                    nodo.Name = user.Id_Usuario
                    nodo.Text = user.Usuario
                    Dim grupo As String = DestinationNode.Name.Split(",").GetValue(1)
                    user.Id_Grupo = grupo
                    DestinationNode.Nodes.Add(nodo)
                    AgregarUsuarioaGrupo(user)
                End If


            Else
                If Not hayUsuario(user.Id_Usuario) Then
                    Dim nodo As New TreeNode
                    nodo.Name = user.Id_Usuario
                    nodo.Text = user.Usuario
                    Dim grupo As String = DestinationNode.Parent.Name.Split(",").GetValue(1)
                    user.Id_Grupo = grupo
                    DestinationNode.Parent.Nodes.Add(nodo)
                    AgregarUsuarioaGrupo(user)
                End If
            End If

            DestinationNode.Expand()

        End If

    End Sub

    Private Function hayUsuario(ByVal id As String) As Boolean
        Try

            For Each node As TreeNode In tvgrupos.Nodes

                For Each chilnode As TreeNode In node.Nodes
                    If chilnode.Name = id Then
                        Return True
                    End If
                Next

            Next
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return True
        End Try

    End Function

    Private Sub AgregarUsuarioaGrupo(ByVal user As Usuario)
        Try
            Dim catusu As New Service_Usuario
            catusu.Actualizar(user)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarToolStripMenuItem.Click
        Try
            BorrarGrupo(tvgrupos.SelectedNode.Name.Split(",").GetValue(1))
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CambiarNombreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarNombreToolStripMenuItem.Click
        If tvgrupos.SelectedNode IsNot Nothing Then
            tvgrupos.LabelEdit = True
            tvgrupos.SelectedNode.BeginEdit()
        End If
        
    End Sub

    Private Sub tvgrupos_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles tvgrupos.AfterLabelEdit
        Dim id As String = tvgrupos.SelectedNode.Name.Split(",").GetValue(1)
        If Not ActualizarGrupo(id, e.Label) Then
            e.CancelEdit = True
        End If

    End Sub




    Private Sub BorrarGrupo(ByVal id As String)
        Try
            Dim catgru As New Service_Grupos

            catgru.Borrar(id)
            Dim grupo As String = tvgrupos.SelectedNode.Name
            tvgrupos.Nodes.Remove(tvgrupos.SelectedNode)

            For Each item As TreeNode In tvPrivilegios.Nodes
                If item.Name = grupo Then
                    tvPrivilegios.Nodes.Remove(item)
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function ActualizarGrupo(ByVal id As String, ByVal texto As String) As Boolean
        Try
            If texto Is Nothing Then
                Return False
            End If
            If texto.Trim <> "" Then
                Dim catgru As New Service_Grupos
                Dim grupo As New Grupo
                grupo.Nombre = texto
                grupo.Id_Grupo = id
                catgru.Actualizar(grupo)

                cargargrupos2()
                cargagruposprivilegios()

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Private Sub InsertarGrupo()
        Try

            frmNuevoGrupo.ShowDialog()

            If frmNuevoGrupo.txtDescripcion.Text.Trim = "" Then
                Exit Sub
            End If

            Dim cat As New Service_Grupos
            Dim grupo As New Grupo(-1, frmNuevoGrupo.txtDescripcion.Text.Trim)
            cat.Insertar(grupo)
            Dim tree As New TreeNode
            tree.Text = grupo.Nombre
            tree.Name = "gr," & grupo.Id_Grupo
            tree.SelectedImageIndex = 2
            tree.ImageIndex = 1
            tvgrupos.Nodes.Add(tree)
            tvPrivilegios.Nodes.Add(tree.Clone)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NuevoGrupoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoGrupoToolStripMenuItem.Click
        InsertarGrupo()
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmNuevoUsuario.ShowDialog()
        CargarUsuarios()
    End Sub

    Private Sub BorrarUsuario2(ByVal id As Integer)
        Try

            Dim serviu As New Service_Usuario

            serviu.Borrar(id)

            CargarUsuarios()
            CargarGrupos()
            CargarGruposUsuarios()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub activarusuario(ByVal id As Integer)
        Try

            Dim serviu As New Service_Usuario

            serviu.Activar(id)

            CargarUsuarios()
            CargarGrupos()
            CargarGruposUsuarios()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Actualizar

    'Private Sub ActualizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    frmNuevoUsuario.editar = True
    '    Dim usuario As Usuario = Nothing
    '    Try
    '        usuario = CType(DGVusers.CurrentRow.DataBoundItem, Usuario)
    '    Catch ex As Exception
    '        MsgBox("Seleccione un usuario")
    '    End Try
    '    If Not usuario Is Nothing Then

    '        frmNuevoUsuario.User = usuario
    '        frmNuevoUsuario.ShowDialog()
    '        frmNuevoUsuario.editar = False
    '        CargarUsuarios()
    '        CargarGrupos()
    '        CargarGruposUsuarios()
    '    End If

    'End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim usuario As Usuario = Nothing
        Try
            usuario = CType(DGVusers.CurrentRow.DataBoundItem, Usuario)
        Catch ex As Exception
            MsgBox("Seleccione un usuario")
        End Try
        If Not usuario Is Nothing Then
            frmCambiarPassword.Usuario = usuario
            frmCambiarPassword.ShowDialog()
        End If


    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmUsuarios_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Y > 40 Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' pasar el formulario como parámetro  
            Mover.Mover_Formulario(Me)
        End If
    End Sub
    Private Sub frmPromocioness_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub
    Private Sub dgvPersonal_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGVusers.MouseUp
        Try
            Dim hit As DataGridView.HitTestInfo
            With DGVusers
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    hit = .HitTest(e.X, e.Y)
                    .CurrentCell = .Rows(hit.RowIndex).Cells(hit.ColumnIndex)

                    If hit.Type = DataGridViewHitTestType.Cell And hit.ColumnIndex = 1 Or hit.ColumnIndex = 3 Or hit.ColumnIndex = 6 Or hit.ColumnIndex = 5 Then
                        menunuevousuario.Show(DGVusers, New Point(e.X, e.Y))
                    End If

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BorrarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarToolStripMenuItem1.Click
        If DGVusers.CurrentRow Is Nothing Then
            MsgBox("No hay usuario seleccionado")
        Else
            BorrarUsuario2(DGVusers.CurrentRow.Cells(0).Value)
        End If
    End Sub

    Private Sub ActivarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivarToolStripMenuItem.Click
        If DGVusers.CurrentRow Is Nothing Then
            MsgBox("No hay usuario seleccionado")
        Else
            activarusuario(DGVusers.CurrentRow.Cells(0).Value)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim usuario As Usuario = Nothing
        Try
            Dim servi As New Service_Usuario

            usuario = servi.Obtener(1)
        Catch ex As ReglasNegocioException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If Not usuario Is Nothing Then
            frmCambiarPassword.Usuario = usuario
            frmCambiarPassword.ShowDialog()
        End If


    End Sub
End Class