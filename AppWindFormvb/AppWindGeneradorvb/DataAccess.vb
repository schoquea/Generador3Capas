Imports System
Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml
Imports System.Data.OracleClient
Imports System.Data.SqlClient

Public Class DataAccess
    ' Methods
    Public Sub New(ByVal vTabla As String, ByVal vLista As ListView)
        Me.Tabla = vTabla
        Me.Lista = vLista

        If Module1.tipo = "SQL" Then
            Me.SystemData = "Sql"
        Else
            Me.SystemData = "Oracle" ' System.Data.OracleClient;"
        End If

        If Module1.leng = "VB" Then
            Me.CrearClaseDataAccessVB()
        Else
            Me.CrearClaseDataAccessCS()
        End If

    End Sub

    Private Sub CrearClaseDataAccessVB()
        Dim text As String
        Dim node As XmlNode
        Dim str2 As String
        Dim enumerator As IEnumerator
        Dim enumerator2 As IEnumerator
        Dim enumerator3 As IEnumerator
        Dim enumerator4 As IEnumerator
        Me.docXml.Load((Application.StartupPath & "\TiposDatos.xml"))
        Me.Clase = ("da" & Me.Tabla)
        Me.Entidad = ("be" & Me.Tabla)
        Me.Instancia = ("o" & Me.Entidad)
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("Imports be" & Module1.csb.InitialCatalog))
        builder2.AppendLine()
        builder2.Append("Imports System.Data")
        builder2.AppendLine()
        builder2.Append("Imports System.Data.SqlClient")
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(("Public Class " & Me.Clase))
        builder2.AppendLine()
        '------------------------------------------------------------- fListar
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Public Function fListar(ByVal con As SqlConnection) As List(Of ")
        builder2.Append(Me.Entidad)
        builder2.Append(")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim lo")
        builder2.Append(Me.Entidad)
        builder2.Append(" As New List(Of ")
        builder2.Append(Me.Entidad)
        builder2.Append(")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim cmd As New SqlCommand(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_SEL01")
        builder2.Append(""""c)
        builder2.Append(",con)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim drd As SqlDataReader=cmd.ExecuteReader")
        builder2.AppendLine()
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                builder2.AppendLine()
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                [text] = current.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & current.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = current.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
                End If
                builder2.Append("Dim pos_")
                builder2.Append([text])
                builder2.Append(" As Integer")
                builder2.Append(" = drd.GetOrdinal(")
                builder2.Append(""""c)
                builder2.Append([text])
                builder2.Append(""""c)
                builder2.Append(")")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim ")
        builder2.Append(Me.Instancia)
        builder2.Append(" As ")
        builder2.Append(Me.Entidad)
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Do While drd.Read")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Me.Instancia)
        builder2.Append("=New ")
        builder2.Append(Me.Entidad)
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("With ")
        builder2.Append(Me.Instancia)
        Try
            enumerator2 = Me.Lista.Items.GetEnumerator
            Do While enumerator2.MoveNext
                Dim item2 As ListViewItem = DirectCast(enumerator2.Current, ListViewItem)
                builder2.AppendLine()
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                [text] = item2.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & item2.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = item2.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
                    Select Case str2
                        Case "Byte"
                            str2 = "Int8"
                            Exit Select
                        Case "Short"
                            str2 = "Int16"
                            Exit Select
                        Case "Integer"
                            str2 = "Int32"
                            Exit Select
                        Case "Long"
                            str2 = "Int64"
                            Exit Select
                    End Select
                End If
                builder2.Append(".")
                builder2.Append([text])
                builder2.Append("=drd.Get")
                builder2.Append(str2)
                builder2.Append("(pos_")
                builder2.Append([text])
                builder2.Append(")")
            Loop
        Finally
            If TypeOf enumerator2 Is IDisposable Then
                TryCast(enumerator2, IDisposable).Dispose()
            End If
        End Try
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End With")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("lo")
        builder2.Append(Me.Entidad)
        builder2.Append(".Add(")
        builder2.Append(Me.Instancia)
        builder2.Append(")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Loop")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Return (lo")
        builder2.Append(Me.Entidad)
        builder2.Append(")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Function")
        builder2.AppendLine()
        builder2.AppendLine()
        '------------------------------------------------------------- fAdicionar
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Public Function fAdicionar(ByVal con As SqlConnection,")
        builder2.Append(Me.Instancia)
        builder2.Append(" As ")
        builder2.Append(Me.Entidad)
        builder2.Append(") As Integer")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim N As Integer=-1")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim cmd As New SqlCommand(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_INS01")
        builder2.Append(""""c)
        builder2.Append(",con)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure")
        builder2.AppendLine()
        Try
            enumerator3 = Me.Lista.Items.GetEnumerator
            Do While enumerator3.MoveNext
                Dim item3 As ListViewItem = DirectCast(enumerator3.Current, ListViewItem)
                builder2.AppendLine()
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                [text] = item3.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & item3.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = item3.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
                End If
                builder2.Append("cmd.Parameters.Add(")
                builder2.Append(""""c)
                builder2.Append([text])
                builder2.Append(""""c)
                builder2.Append(",SqlDbType.")
                builder2.Append(item3.SubItems.Item(1).Text)
                builder2.Append(",")
                builder2.Append(item3.SubItems.Item(2).Text)
                builder2.Append(").value=")
                builder2.Append(Me.Instancia)
                builder2.Append(".")
                builder2.Append([text])
            Loop
        Finally
            If TypeOf enumerator3 Is IDisposable Then
                TryCast(enumerator3, IDisposable).Dispose()
            End If
        End Try
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("N=cmd.ExecuteNonQuery")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Return N")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Function")
        builder2.AppendLine()
        builder2.AppendLine()
        '------------------------------------------------------------- fActualizar 
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Public Function fActualizar(ByVal con As SqlConnection,")
        builder2.Append(Me.Instancia)
        builder2.Append(" As ")
        builder2.Append(Me.Entidad)
        builder2.Append(") As Integer")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim N As Integer=-1")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim cmd As New SqlCommand(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_UPD01")
        builder2.Append(""""c)
        builder2.Append(",con)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure")
        builder2.AppendLine()
        Try
            enumerator4 = Me.Lista.Items.GetEnumerator
            Do While enumerator4.MoveNext
                Dim item4 As ListViewItem = DirectCast(enumerator4.Current, ListViewItem)
                builder2.AppendLine()
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                [text] = item4.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & item4.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = item4.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
                End If
                builder2.Append("cmd.Parameters.Add(")
                builder2.Append(""""c)
                builder2.Append([text])
                builder2.Append(""""c)
                builder2.Append(",SqlDbType.")
                builder2.Append(item4.SubItems.Item(1).Text)
                builder2.Append(",")
                builder2.Append(item4.SubItems.Item(2).Text)
                builder2.Append(").value=")
                builder2.Append(Me.Instancia)
                builder2.Append(".")
                builder2.Append([text])
            Loop
        Finally
            If TypeOf enumerator4 Is IDisposable Then
                TryCast(enumerator4, IDisposable).Dispose()
            End If
        End Try
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("N=cmd.ExecuteNonQuery")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Return N")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Function")
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.AppendLine()
        '------------------------------------------------------------- fEliminar
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Public Function fEliminar(ByVal con As SqlConnection,")
        builder2.Append(Me.Instancia)
        builder2.Append(" As ")
        builder2.Append(Me.Entidad)
        builder2.Append(") As Integer")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim N As Integer=-1")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim cmd As New SqlCommand(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_DEL01")
        builder2.Append(""""c)
        builder2.Append(",con)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure")
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        [text] = Me.Lista.Items.Item(0).SubItems.Item(0).Text
        node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & Me.Lista.Items.Item(0).SubItems.Item(1).Text & "']"))
        If (node Is Nothing) Then
            str2 = Me.Lista.Items.Item(0).SubItems.Item(1).Text
        Else
            str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
        End If
        builder2.Append("cmd.Parameters.Add(")
        builder2.Append(""""c)
        builder2.Append([text])
        builder2.Append(""""c)
        builder2.Append(",SqlDbType.")
        builder2.Append(Me.Lista.Items.Item(0).SubItems.Item(1).Text)
        builder2.Append(",")
        builder2.Append(Me.Lista.Items.Item(0).SubItems.Item(2).Text)
        builder2.Append(").value=")
        builder2.Append(Me.Instancia)
        builder2.Append(".")
        builder2.Append([text])
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("N=cmd.ExecuteNonQuery")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Return N")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Function")
        builder2.AppendLine()
        builder2.Append("End Class")
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.Clase & ".vb"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    Private Sub CrearClaseDataAccessCS()
        Dim text As String
        Dim node As XmlNode
        Dim str2 As String
        Dim enumerator As IEnumerator
        Dim enumerator2 As IEnumerator
        Dim enumerator3 As IEnumerator
        Dim enumerator4 As IEnumerator
        Me.docXml.Load((Application.StartupPath & "\TiposDatos.xml"))
        Me.Clase = ("da" & Me.Tabla)
        Me.Entidad = ("be" & Me.Tabla)
        Me.Instancia = ("o" & Me.Entidad)
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("using " & Me.Entidad & ";")) 'Module1.csb.InitialCatalog & ";"))
        builder2.AppendLine()
        builder2.Append("using System;")
        builder2.AppendLine()
        builder2.Append("using System.Collections.Generic;")
        builder2.AppendLine()
        builder2.Append("using System.Data;")
        builder2.AppendLine()
        builder2.Append("using System.Data." & SystemData & "Client;")
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(("public class " & Me.Clase))
        builder2.AppendLine()
        builder2.Append("{")
        builder2.AppendLine()
        '------------------------------------------------------------- fListar
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("public List<" & Me.Entidad & "> fListar(" & SystemData & "Connection con)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("List<" & Me.Entidad & "> l" & Me.Instancia & " = null;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("using (" & SystemData & "Command cmd = new " & SystemData & "Command(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_SEL01")
        builder2.Append(""""c)
        builder2.Append(",con))")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.Parameters.Add(""p_cursor"", OracleType.Cursor).Direction = ParameterDirection.Output;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(SystemData & "DataReader drd = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("if (drd != null)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
            Try
                enumerator = Me.Lista.Items.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    builder2.AppendLine()
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    [text] = current.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[ora='" & current.SubItems.Item(1).Text & "']"))
                    If (node Is Nothing) Then
                        str2 = current.SubItems.Item(1).Text
                    Else
                    str2 = node.ChildNodes.ItemOf(4).FirstChild.Value
                    End If
                builder2.Append("Int32 pos_")
                builder2.Append([text])
                builder2.Append(" = drd.GetOrdinal(")
                    builder2.Append(""""c)
                    builder2.Append([text])
                    builder2.Append(""""c)
                builder2.Append(");")
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
        End Try
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("l" & Me.Instancia & " = new List<" & Me.Entidad & ">();")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Me.Entidad & " " & Me.Instancia & " = null;")

            builder2.AppendLine()
            builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("while (drd.Read())")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
            builder2.AppendLine()
            builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
            builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
            builder2.Append(Me.Instancia)
        builder2.Append(" = new ")
        builder2.Append(Me.Entidad)
        builder2.Append("();")
            Try
                enumerator2 = Me.Lista.Items.GetEnumerator
                Do While enumerator2.MoveNext
                    Dim item2 As ListViewItem = DirectCast(enumerator2.Current, ListViewItem)
                    builder2.AppendLine()
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    [text] = item2.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & item2.SubItems.Item(1).Text & "']"))
                    If (node Is Nothing) Then
                        str2 = item2.SubItems.Item(1).Text
                    Else
                    str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
                        Select Case str2
                            Case "Byte"
                                str2 = "Int8"
                                Exit Select
                            Case "Short"
                                str2 = "Int16"
                                Exit Select
                            Case "Integer"
                                str2 = "Int32"
                                Exit Select
                            Case "Long"
                                str2 = "Int64"
                                Exit Select
                        End Select
                    End If
                builder2.Append(Me.Instancia & ".")
                    builder2.Append([text])
                    builder2.Append("=drd.Get")
                    builder2.Append(str2)
                    builder2.Append("(pos_")
                    builder2.Append([text])
                builder2.Append(");")
                Loop
            Finally
                If TypeOf enumerator2 Is IDisposable Then
                    TryCast(enumerator2, IDisposable).Dispose()
                End If
            End Try
            builder2.AppendLine()
            builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
            builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
            builder2.Append("lo")
            builder2.Append(Me.Entidad)
            builder2.Append(".Add(")
            builder2.Append(Me.Instancia)
        builder2.Append(");")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("return (l")
        builder2.Append(Me.Instancia)
        builder2.Append(");")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.AppendLine()

        '------------------------------------------------------------- fInsertar
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("public Int32 fInsertar(" & SystemData & "Connection con, ")
        builder2.Append(Me.Entidad & " " & Me.Instancia & ")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Int32 lsResultado = -1;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("using (" & SystemData & "Command cmd = new " & SystemData & "Command(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_INS01")
        builder2.Append(""""c)
        builder2.Append(",con))")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure;")
            Try
                enumerator3 = Me.Lista.Items.GetEnumerator
                Do While enumerator3.MoveNext
                    Dim item3 As ListViewItem = DirectCast(enumerator3.Current, ListViewItem)
                    builder2.AppendLine()
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    [text] = item3.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[ora='" & item3.SubItems.Item(1).Text & "']"))
                    If (node Is Nothing) Then
                        str2 = item3.SubItems.Item(1).Text
                    Else
                    str2 = node.ChildNodes.ItemOf(5).FirstChild.Value
                    End If
                    builder2.Append("cmd.Parameters.Add(")
                    builder2.Append(""""c)
                    builder2.Append([text])
                    builder2.Append(""""c)
                builder2.Append("," & SystemData & "Type.")
                builder2.Append(str2.ToString())
                    builder2.Append(",")
                builder2.Append(item3.SubItems.Item(2).Text)
                    builder2.Append(").Value = ")
                    builder2.Append(Me.Instancia)
                    builder2.Append(".")
                    builder2.Append([text])
                    builder2.Append(";")
                Loop
            Finally
                If TypeOf enumerator3 Is IDisposable Then
                    TryCast(enumerator3, IDisposable).Dispose()
                End If
            End Try

        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("lsResultado = cmd.ExecuteNonQuery();")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("return (lsResultado);")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.AppendLine()

        ''------------------------------------------------------------- fActualizar
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("public Int32 fActualizar(" & SystemData & "Connection con, ")
        builder2.Append(Me.Entidad & " " & Me.Instancia & ")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Int32 lsResultado = -1;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("using (" & SystemData & "Command cmd = new " & SystemData & "Command(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_UPD01")
        builder2.Append(""""c)
        builder2.Append(",con))")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure;")

        Try
            enumerator4 = Me.Lista.Items.GetEnumerator
            Do While enumerator4.MoveNext
                Dim item4 As ListViewItem = DirectCast(enumerator4.Current, ListViewItem)
                builder2.AppendLine()
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                [text] = item4.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[ora='" & item4.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = item4.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(5).FirstChild.Value
                End If
                builder2.Append("cmd.Parameters.Add(")
                builder2.Append(""""c)
                builder2.Append([text])
                builder2.Append(""""c)
                builder2.Append("," & SystemData & "Type.")
                builder2.Append(str2.ToString())
                builder2.Append(",")
                builder2.Append(item4.SubItems.Item(2).Text)
                builder2.Append(").Value=")
                builder2.Append(Me.Instancia)
                builder2.Append(".")
                builder2.Append([text])
                builder2.Append(";")
            Loop
        Finally
            If TypeOf enumerator4 Is IDisposable Then
                TryCast(enumerator4, IDisposable).Dispose()
            End If
        End Try

        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("lsResultado = cmd.ExecuteNonQuery();")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("return (lsResultado);")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.AppendLine()

        '------------------------------------------------------------- fEliminar
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("public Int32 fEliminar(" & SystemData & "Connection con, ")
        builder2.Append(Me.Entidad & " " & Me.Instancia & ")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Int32 lsResultado = -1;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("using (" & SystemData & "Command cmd = new " & SystemData & "Command(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_DEL01")
        builder2.Append(""""c)
        builder2.Append(",con))")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure;")

        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        [text] = Me.Lista.Items.Item(0).SubItems.Item(0).Text
        node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[ora='" & Me.Lista.Items.Item(0).SubItems.Item(1).Text & "']"))
        If (node Is Nothing) Then
            str2 = Me.Lista.Items.Item(0).SubItems.Item(1).Text
        Else
            str2 = node.ChildNodes.ItemOf(5).FirstChild.Value
        End If
        builder2.Append("cmd.Parameters.Add(")
        builder2.Append(""""c)
        builder2.Append([text])
        builder2.Append(""""c)
        builder2.Append("," & SystemData & "Type.")
        builder2.Append(str2.ToString())
        builder2.Append(",")
        builder2.Append(Me.Lista.Items.Item(0).SubItems.Item(2).Text)
        builder2.Append(").Value=")
        builder2.Append(Me.Instancia)
        builder2.Append(".")
        builder2.Append([text])
        builder2.Append(";")

        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("lsResultado = cmd.ExecuteNonQuery();")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("return (lsResultado);")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.AppendLine()
        '------------------------------------------------------------- fListarPK
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("public " & Me.Entidad & " fListarPK(" & SystemData & "Connection con,")
        builder2.Append(Me.Entidad & " " & Me.Instancia & ")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Me.Entidad & " l" & Me.Instancia & " = null;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("using (" & SystemData & "Command cmd = new " & SystemData & "Command(")
        builder2.Append(""""c)
        builder2.Append("USP_")
        builder2.Append(Me.Tabla)
        builder2.Append("_SEL02")
        builder2.Append(""""c)
        builder2.Append(",con))")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.CommandType = CommandType.StoredProcedure;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("cmd.Parameters.Add(""p_cursor"", OracleType.Cursor).Direction = ParameterDirection.Output;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(SystemData & "DataReader drd = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("if (drd != null)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                builder2.AppendLine()
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                [text] = current.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[ora='" & current.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = current.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(4).FirstChild.Value
                End If
                builder2.Append("Int32 pos_")
                builder2.Append([text])
                builder2.Append(" = drd.GetOrdinal(")
                builder2.Append(""""c)
                builder2.Append([text])
                builder2.Append(""""c)
                builder2.Append(");")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("l" & Me.Instancia & " = new " & Me.Entidad & "();")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("while (drd.Read())")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("{")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("l" & Me.Instancia)
        builder2.Append(" = new ")
        builder2.Append(Me.Entidad)
        builder2.Append("();")
        Try
            enumerator2 = Me.Lista.Items.GetEnumerator
            Do While enumerator2.MoveNext
                Dim item2 As ListViewItem = DirectCast(enumerator2.Current, ListViewItem)
                builder2.AppendLine()
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                [text] = item2.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & item2.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = item2.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
                    Select Case str2
                        Case "Byte"
                            str2 = "Int8"
                            Exit Select
                        Case "Short"
                            str2 = "Int16"
                            Exit Select
                        Case "Integer"
                            str2 = "Int32"
                            Exit Select
                        Case "Long"
                            str2 = "Int64"
                            Exit Select
                    End Select
                End If
                builder2.Append("l" & Me.Instancia & ".")
                builder2.Append([text])
                builder2.Append("=drd.Get")
                builder2.Append(str2)
                builder2.Append("(pos_")
                builder2.Append([text])
                builder2.Append(");")
            Loop
        Finally
            If TypeOf enumerator2 Is IDisposable Then
                TryCast(enumerator2, IDisposable).Dispose()
            End If
        End Try
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("return (l")
        builder2.Append(Me.Instancia)
        builder2.Append(");")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("}")
        builder2.AppendLine()
        builder2.AppendLine()
        '--------------------------
        builder2.AppendLine()
        builder2.Append("}")

        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.Clase & ".cs"))
            writer.Write(builder.ToString)
        End Using

    End Sub

    ' Fields
    Private Clase As String
    Private docXml As XmlDataDocument = New XmlDataDocument
    Private Entidad As String
    Private Instancia As String
    Private Lista As ListView
    Private Tabla As String
    Private SystemData As String

End Class
