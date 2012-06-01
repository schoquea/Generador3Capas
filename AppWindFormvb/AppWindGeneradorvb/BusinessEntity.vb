Imports System
Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Public Class BusinessEntity
    ' Methods
    Public Sub New(ByVal vTabla As String, ByVal vLista As ListView)
        Me.Tabla = vTabla
        Me.Lista = vLista

        If Module1.leng = "VB" Then
            Me.CrearClaseEntidadNegocio()
        Else
            Me.CrearClaseEntidadNegocioCS()
        End If


    End Sub

    Private Sub CrearClaseEntidadNegocio()
        Dim text As String
        Dim node As XmlNode
        Dim str2 As String
        Dim enumerator As IEnumerator
        Dim enumerator2 As IEnumerator
        Me.docXml.Load((Application.StartupPath & "\TiposDatos.xml"))
        Me.Clase = ("be" & Me.Tabla)
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("Public Class " & Me.Clase))
        builder2.AppendLine()
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                [text] = current.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & current.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = current.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
                End If
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & "Private _" & [text] & " As " & str2))
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder2.AppendLine("")
        Try
            enumerator2 = Me.Lista.Items.GetEnumerator
            Do While enumerator2.MoveNext
                Dim item2 As ListViewItem = DirectCast(enumerator2.Current, ListViewItem)
                [text] = item2.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[sql='" & item2.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = item2.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(2).FirstChild.Value
                End If
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & "Public Property " & [text] & " As " & str2))
                builder2.AppendLine("")
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & "Get")
                builder2.AppendLine("")
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & "Return (_" & [text] & ")"))
                builder2.AppendLine("")
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & "End Get")
                builder2.AppendLine("")
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & "Set(ByVal value As " & str2 & ")"))
                builder2.AppendLine("")
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & "_" & [text] & "=value"))
                builder2.AppendLine("")
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & "End Set")
                builder2.AppendLine("")
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "End Property")
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator2 Is IDisposable Then
                TryCast(enumerator2, IDisposable).Dispose()
            End If
        End Try
        builder2.Append("End Class")
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.Clase & ".vb"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    Private Sub CrearClaseEntidadNegocioCS()
        Dim text As String
        Dim node As XmlNode
        Dim str2 As String
        Dim enumerator As IEnumerator
        Dim enumerator2 As IEnumerator
        Me.docXml.Load((Application.StartupPath & "\TiposDatos.xml"))
        Me.Clase = ("be" & Me.Tabla)
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append("using System;")
        builder2.AppendLine("")
        builder2.Append(("public class " & Me.Clase))
        builder2.AppendLine("")
        builder2.AppendLine("{")
        builder2.AppendLine("")
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                [text] = current.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[ora='" & current.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = current.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(4).FirstChild.Value
                End If
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & "private " & str2 & " _" & [text]))
                builder2.Append(";")
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder2.AppendLine("")
        Try
            enumerator2 = Me.Lista.Items.GetEnumerator
            Do While enumerator2.MoveNext
                Dim item2 As ListViewItem = DirectCast(enumerator2.Current, ListViewItem)
                [text] = item2.SubItems.Item(0).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[ora='" & item2.SubItems.Item(1).Text & "']"))
                If (node Is Nothing) Then
                    str2 = item2.SubItems.Item(1).Text
                Else
                    str2 = node.ChildNodes.ItemOf(4).FirstChild.Value
                End If
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & "public " & str2 & " " & [text]))
                builder2.AppendLine("")
                builder2.AppendLine(Microsoft.VisualBasic.Strings.ChrW(9) & "{")
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & "get { " & " return _" & [text] & "; }")
                builder2.AppendLine("")
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & "set { " & "_" & [text] & " = value; }")
                builder2.AppendLine("")
                builder2.AppendLine(Microsoft.VisualBasic.Strings.ChrW(9) & "}")
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator2 Is IDisposable Then
                TryCast(enumerator2, IDisposable).Dispose()
            End If
        End Try
        builder2.Append("}")
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.Clase & ".cs"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    ' Fields
    Private Clase As String
    Private docXml As XmlDataDocument = New XmlDataDocument
    Private Lista As ListView
    Private Tabla As String
End Class


