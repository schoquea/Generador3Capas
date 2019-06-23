Imports System
Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Public Class BusinessEntity
#Region "Atributos"
    Private Clase As String
    Private docXml As XmlDataDocument
    Private Lista As ListView
    Private Tabla As String
#End Region

#Region "Propiedades"

    Private Sub CrearClaseEntidadNegocio()
        Dim charw As Char = Microsoft.VisualBasic.Strings.ChrW(9)
        Dim strEntidad As String
        Dim node As XmlNode
        Dim enumerator As IEnumerator

        Dim builder As New StringBuilder
        Me.docXml.Load((Application.StartupPath & "\TiposDatos.xml"))
        Me.Clase = ("be" & Me.Tabla)
        Dim strTipos As String = String.Empty
        Dim strTipo As String = String.Empty
        Dim sbEntidad As New StringBuilder
        Dim sbAtributo As New StringBuilder
        Dim sbPropiedad As New StringBuilder
        Dim sbConstructor As New StringBuilder

        sbEntidad.AppendFormat("Public Class {0} {1}", Me.Clase, Environment.NewLine)
        sbAtributo.AppendFormat("#Region ""Atributos""{0}", Environment.NewLine)
        sbPropiedad.AppendFormat("#Region ""Propiedades""{0}", Environment.NewLine)
        sbConstructor.AppendFormat("#Region ""Constructor""{0}", Environment.NewLine)
        sbConstructor.AppendFormat("{0}Public Sub New(){1}", charw, Environment.NewLine)

        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                strEntidad = current.SubItems.Item(0).Text
                strTipos = current.SubItems.Item(1).Text
                node = Me.docXml.DocumentElement.SelectSingleNode(("tipo[tipo='" & strTipo.ToUpper & "']"))

                If (node Is Nothing) Then
                    strTipo = strTipos
                Else
                    strTipo = node.ChildNodes.ItemOf(3).FirstChild.Value
                End If

                'SCA-20131101-cuerpo del atributo
                sbAtributo.AppendFormat("{0}Private _{1} As {2}{3}", charw, strEntidad.ToLower, strTipo, Environment.NewLine)

                'SCA-20131101-cuerpo de la propiedad
                sbPropiedad.AppendFormat("{0}Public Property {1}() As {2}{3}", charw, strEntidad.ToLower, strTipo, Environment.NewLine)
                sbPropiedad.AppendFormat("{0}{0}Get{1}", charw, strTipo, Environment.NewLine)
                sbPropiedad.AppendFormat("{0}{0}{0}Return _{1}{2}", charw, strEntidad.ToLower, Environment.NewLine)
                sbPropiedad.AppendFormat("{0}{0}End Get{1}", charw, strTipo, Environment.NewLine)
                sbPropiedad.AppendFormat("{0}{0}Set(ByVal value As {1}){2}", charw, strTipo, Environment.NewLine)
                sbPropiedad.AppendFormat("{0}{0}{0}_{1} = value{2}", charw, strEntidad.ToLower, Environment.NewLine)
                sbPropiedad.AppendFormat("{0}{0}End Set{1}", charw, strTipo, Environment.NewLine)
                sbPropiedad.AppendFormat("{0}End Property{1}", charw, Environment.NewLine)

                'SCA-20131101-cuerpo del constructor
                sbConstructor.AppendFormat("{0}Me.{1} = String.Empty", charw, strEntidad.ToLower, Environment.NewLine)

            Loop

            sbAtributo.AppendFormat("#End Region{0}", Environment.NewLine)
            sbPropiedad.AppendFormat("#End Region{0}", Environment.NewLine)
            sbConstructor.AppendFormat("{0}End Sub{1}", charw, Environment.NewLine)
            sbConstructor.AppendFormat("#End Region{0}", Environment.NewLine)

        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try

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

#End Region

#Region "Constructor"
    Public Sub New(ByVal vTabla As String, ByVal vLista As ListView)
        Me.docXml = New XmlDataDocument
        Me.Lista = New ListView
        Me.Tabla = vTabla
        Me.Lista = vLista

        If Module1.leng = "VB" Then
            Me.CrearClaseEntidadNegocio()
        Else
            Me.CrearClaseEntidadNegocioCS()
        End If
    End Sub
#End Region

End Class


