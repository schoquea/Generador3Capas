Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO

Public Class frmGenerador

    Private isCancelar As Boolean

    Private Sub CargarDatos(ByVal sender As Object, ByVal e As EventArgs)
        Me.CrearColumnasListView()

        If Module1.tipo = "SQL" Then
            Dim node As TreeNode = Me.tvwBD.Nodes.Add(Module1.csb.InitialCatalog)
            Using connection As SqlConnection = New SqlConnection(Module1.csb.ToString)
                connection.Open()
                Dim reader As SqlDataReader = New SqlCommand("SELECT Name FROM sysobjects WHERE xtype='U'", connection).ExecuteReader
                Do While reader.Read
                    node.Nodes.Add(reader.GetString(0))
                Loop
            End Using
        ElseIf Module1.tipo = "ORACLE" Then
            Dim node As TreeNode = Me.tvwBD.Nodes.Add(Module1.csc.UserID)
            Using connection As OracleConnection = New OracleConnection(Module1.csc.ToString)
                connection.Open()
                Dim reader As OracleDataReader = New OracleCommand("select table_name as Name from user_tables", connection).ExecuteReader
                Do While reader.Read
                    node.Nodes.Add(reader.GetString(0))
                Loop
            End Using

        End If
        Me.tvwBD.ExpandAll()
    End Sub

    Private Sub CrearColumnasListView()
        Dim lvwTabla As ListView = Me.lvwTabla
        lvwTabla.Columns.Add("Nombre", 150, HorizontalAlignment.Left)
        lvwTabla.Columns.Add("Tipo", 60, HorizontalAlignment.Left)
        lvwTabla.Columns.Add("Tama" & Microsoft.VisualBasic.Strings.ChrW(241) & "o", 60, HorizontalAlignment.Left)
        lvwTabla.Columns.Add("Scale", 60, HorizontalAlignment.Left)
        lvwTabla.Columns.Add("Nulo", 60, HorizontalAlignment.Left)
        lvwTabla.Columns.Add("Identidad", 60, HorizontalAlignment.Left)
        lvwTabla.View = View.Details
        lvwTabla = Nothing
    End Sub

    Private Sub MostrarCamposPorTabla(ByVal sender As Object, ByVal e As TreeViewEventArgs)
        Me.lvwTabla.Items.Clear()
        If (e.Node.Level = 1) Then

            If Module1.tipo = "SQL" Then
                Using connection As SqlConnection = New SqlConnection(Module1.csb.ConnectionString)
                    connection.Open()
                    Dim command As New SqlCommand(("Select * From [" & e.Node.Text & "]"), connection)
                    Dim schemaTable As DataTable = command.ExecuteReader.GetSchemaTable
                    Dim item As ListViewItem = Nothing
                    Dim num2 As Integer = (schemaTable.Rows.Count - 1)
                    Dim i As Integer = 0
                    Do While (i <= num2)
                        Dim arguments As Object() = New Object(1 - 1) {}
                        Dim row As DataRow = schemaTable.Rows.Item(i)
                        Dim str As String = "ColumnName"
                        arguments(0) = RuntimeHelpers.GetObjectValue(row.Item(str))
                        Dim objArray2 As Object() = arguments
                        Dim copyBack As Boolean() = New Boolean() {True}
                        'If copyBack(0) Then
                        '    row.Item(str) = RuntimeHelpers.GetObjectValue(objArray2(0))
                        'End If
                        item = DirectCast(NewLateBinding.LateGet(Me.lvwTabla.Items, Nothing, "Add", objArray2, Nothing, Nothing, copyBack), ListViewItem)
                        objArray2 = New Object(1 - 1) {}
                        row = schemaTable.Rows.Item(i)
                        str = "DataTypeName"
                        objArray2(0) = RuntimeHelpers.GetObjectValue(row.Item(str))
                        arguments = objArray2
                        copyBack = New Boolean() {True}
                        NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)
                        If copyBack(0) Then
                            row.Item(str) = RuntimeHelpers.GetObjectValue(arguments(0))
                        End If
                        objArray2 = New Object(1 - 1) {}
                        row = schemaTable.Rows.Item(i)
                        str = "ColumnSize"
                        objArray2(0) = RuntimeHelpers.GetObjectValue(row.Item(str))
                        arguments = objArray2
                        copyBack = New Boolean() {True}
                        NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)
                        If copyBack(0) Then
                            row.Item(str) = RuntimeHelpers.GetObjectValue(arguments(0))
                        End If
                        objArray2 = New Object(1 - 1) {}
                        row = schemaTable.Rows.Item(i)
                        str = "AllowDBNull"
                        objArray2(0) = RuntimeHelpers.GetObjectValue(row.Item(str))
                        arguments = objArray2
                        copyBack = New Boolean() {True}
                        NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)
                        If copyBack(0) Then
                            row.Item(str) = RuntimeHelpers.GetObjectValue(arguments(0))
                        End If
                        objArray2 = New Object(1 - 1) {}
                        row = schemaTable.Rows.Item(i)
                        str = "IsIdentity"
                        objArray2(0) = RuntimeHelpers.GetObjectValue(row.Item(str))
                        arguments = objArray2
                        copyBack = New Boolean() {True}
                        NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)
                        If copyBack(0) Then
                            row.Item(str) = RuntimeHelpers.GetObjectValue(arguments(0))
                        End If
                        i += 1
                    Loop
                End Using
            Else
                Using oraconnection As OracleConnection = New OracleConnection(Module1.csc.ConnectionString)
                    oraconnection.Open()
                    Dim oracommand As New OracleCommand(String.Format("select * from {0} ", e.Node.Text), oraconnection)
                    Dim schemaTable As DataTable = oracommand.ExecuteReader(CommandBehavior.KeyInfo).GetSchemaTable
                    Dim item As ListViewItem = Nothing

                    Dim str As String = String.Empty
                    Dim objArray2 As Object()
                    Dim copyBack As Boolean()
                    Dim arguments As Object()

                    For Each oRows As DataRow In schemaTable.Rows
                        arguments = New Object(1 - 1) {}
                        copyBack = New Boolean() {True}

                        str = "ColumnName"
                        arguments(0) = RuntimeHelpers.GetObjectValue(oRows.Item(str))
                        objArray2 = arguments
                        item = DirectCast(NewLateBinding.LateGet(Me.lvwTabla.Items, Nothing, "Add", objArray2, Nothing, Nothing, copyBack), ListViewItem)

                        str = "IsLong"
                        If (Not RuntimeHelpers.GetObjectValue(oRows.Item(str))) Then

                            str = "DataType"
                            objArray2(0) = RuntimeHelpers.GetObjectValue(oRows.Item(str))
                            objArray2(0) = objArray2(0).Name()
                            arguments = objArray2
                            NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)

                            str = "NumericPrecision"
                            If (oRows.Item(str) <> "0") Then
                                str = "NumericPrecision"
                                objArray2(0) = RuntimeHelpers.GetObjectValue(oRows.Item(str))
                                arguments = objArray2
                                NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)

                                str = "NumericScale"
                                objArray2(0) = RuntimeHelpers.GetObjectValue(oRows.Item(str))
                                arguments = objArray2
                                NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)
                            Else
                                str = "ColumnSize"
                                objArray2(0) = RuntimeHelpers.GetObjectValue(oRows.Item(str))
                                arguments = objArray2
                                NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)

                                objArray2(0) = RuntimeHelpers.GetObjectValue(String.Empty)
                                arguments = objArray2
                                NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)
                            End If
                        Else

                            objArray2(0) = RuntimeHelpers.GetObjectValue("Blob")
                            arguments = objArray2
                            NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)

                            objArray2(0) = RuntimeHelpers.GetObjectValue(String.Empty)
                            arguments = objArray2
                            NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)

                            objArray2(0) = RuntimeHelpers.GetObjectValue(String.Empty)
                            arguments = objArray2
                            NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)
                        End If

                        str = "AllowDBNull"
                        objArray2(0) = RuntimeHelpers.GetObjectValue(oRows.Item(str))
                        arguments = objArray2
                        NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)

                        str = "IsKey"
                        objArray2(0) = RuntimeHelpers.GetObjectValue(oRows.Item(str))
                        arguments = objArray2
                        NewLateBinding.LateCall(item.SubItems, Nothing, "Add", arguments, Nothing, Nothing, copyBack, True)

                    Next
                End Using
        End If
        End If
    End Sub

    Private Sub Desvanecer(ByVal sender As Object, ByVal e As EventArgs)
        Me.Opacity = (Me.Opacity - 0.01)
        If (Me.Opacity = 0) Then
            Me.isCancelar = False
            Me.Close()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.isCancelar = True
        CargarDatos(sender, e)
    End Sub

    Private Sub tvwBD_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwBD.AfterSelect
        MostrarCamposPorTabla(sender, e)
    End Sub

    '--------------------------------------
    Private Sub StoreProcedureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreProcedureToolStripMenuItem.Click, StoreProcedureToolStripMenuItem1.Click
        If ((Not Me.tvwBD.SelectedNode Is Nothing) AndAlso (Me.tvwBD.SelectedNode.Level = 1)) Then

            Directory.CreateDirectory((Application.StartupPath & "\StoreProcedures"))
            Directory.SetCurrentDirectory((Application.StartupPath & "\StoreProcedures"))
            Dim procedures As New StoreProcedures(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            MessageBox.Show("Store Procedures fueron creados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Else
            MessageBox.Show("Selecciona una tabla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub DataAccesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataAccesToolStripMenuItem.Click, DataAccesToolStripMenuItem1.Click
        Module1.leng = sender.ToolTipText.ToString()
        If ((Not Me.tvwBD.SelectedNode Is Nothing) AndAlso (Me.tvwBD.SelectedNode.Level = 1)) Then
            Directory.CreateDirectory((Application.StartupPath & "\DataAccess" & Module1.leng))
            Directory.SetCurrentDirectory((Application.StartupPath & "\DataAccess" & Module1.leng))
            Dim access As New DataAccess(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            MessageBox.Show("Componente de Datos fue creado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            MessageBox.Show("Selecciona una tabla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub BusinessEntityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BusinessEntityToolStripMenuItem.Click, BusinessEntityToolStripMenuItem1.Click
        Module1.leng = sender.ToolTipText.ToString()
        If ((Not Me.tvwBD.SelectedNode Is Nothing) AndAlso (Me.tvwBD.SelectedNode.Level = 1)) Then
            Directory.CreateDirectory((Application.StartupPath & "\BusinessEntity" & Module1.leng))
            Directory.SetCurrentDirectory((Application.StartupPath & "\BusinessEntity" & Module1.leng))
            Dim entity As New BusinessEntity(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            MessageBox.Show("Componente Entidad de Negocio fue creado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            MessageBox.Show("Selecciona una tabla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub BusinessRulesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BusinessRulesToolStripMenuItem.Click, BusinessRulesToolStripMenuItem1.Click
        Module1.leng = sender.ToolTipText.ToString()
        If ((Not Me.tvwBD.SelectedNode Is Nothing) AndAlso (Me.tvwBD.SelectedNode.Level = 1)) Then
            Directory.CreateDirectory((Application.StartupPath & "\BusinessRules" & Module1.leng))
            Directory.SetCurrentDirectory((Application.StartupPath & "\BusinessRules" & Module1.leng))
            Dim rules As New BusinessRules(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            MessageBox.Show("Componente de Regla de Negocio fue creado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            MessageBox.Show("Selecciona una tabla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub AllComponentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllComponentsToolStripMenuItem.Click
        If ((Not Me.tvwBD.SelectedNode Is Nothing) AndAlso (Me.tvwBD.SelectedNode.Level = 1)) Then
            Directory.CreateDirectory((Application.StartupPath & "\AllComponents"))
            Directory.SetCurrentDirectory((Application.StartupPath & "\AllComponents"))
            Dim procedures As New StoreProcedures(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            Dim entity As New BusinessEntity(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            Dim access As New DataAccess(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            Dim rules As New BusinessRules(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            MessageBox.Show("Todos los Componentes de la Tabla fueron creados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            MessageBox.Show("Selecciona una tabla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub AllDataBaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllDataBaseToolStripMenuItem.Click
        Dim num2 As Integer = (Me.tvwBD.Nodes.Item(0).Nodes.Count - 1)
        Dim i As Integer = 0
        Do While (i <= num2)
            Me.tvwBD.SelectedNode = Me.tvwBD.Nodes.Item(0).Nodes.Item(i)
            Directory.CreateDirectory((Application.StartupPath & "\StoreProcedures"))
            Directory.SetCurrentDirectory((Application.StartupPath & "\StoreProcedures"))
            Dim procedures As New StoreProcedures(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            Directory.CreateDirectory((Application.StartupPath & "\BusinessEntity"))
            Directory.SetCurrentDirectory((Application.StartupPath & "\BusinessEntity"))
            Dim entity As New BusinessEntity(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            Directory.CreateDirectory((Application.StartupPath & "\DataAccess"))
            Directory.SetCurrentDirectory((Application.StartupPath & "\DataAccess"))
            Dim access As New DataAccess(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            Directory.CreateDirectory((Application.StartupPath & "\BusinessRules"))
            Directory.SetCurrentDirectory((Application.StartupPath & "\BusinessRules"))
            Dim rules As New BusinessRules(Me.tvwBD.SelectedNode.Text, Me.lvwTabla)
            i += 1
        Loop
        MessageBox.Show("Todos los Componentes de la BD fueron creados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
 
End Class
