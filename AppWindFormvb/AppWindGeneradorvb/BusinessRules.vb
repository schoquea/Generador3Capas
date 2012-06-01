﻿Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml
Imports System.Globalization.CultureInfo


Public Class BusinessRules
    ' Methods
    Public Sub New(ByVal vTabla As String, ByVal vLista As ListView)
        Me.Tabla = vTabla
        Me.Lista = vLista
        Me.Clase = ("da" & Me.Tabla)
        Me.Entidad = ("be" & Me.Tabla)
        Me.Instancia = ("o" & Me.Entidad)

        If Module1.tipo = "SQL" Then
            Me.SystemData = "System.Data.SqlClient;"
        Else
            Me.SystemData = "System.Data.OracleClient;"
        End If

        If Module1.leng = "VB" Then
            Me.CrearClaseBusinessRules()
        Else
            Me.CrearClaseBusinessRulesCS()
        End If

    End Sub

    Private Sub CrearClaseBusinessRules()
        Me.docXml.Load((Application.StartupPath & "\TiposDatos.xml"))
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("Imports be" & Module1.csb.InitialCatalog))
        builder2.AppendLine()
        builder2.Append(("Imports da" & Module1.csb.InitialCatalog))
        builder2.AppendLine()
        builder2.Append("Imports System.Data.SqlClient")
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(("Public Class " & Me.Clase))
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Dim oda")
        builder2.Append(Me.Tabla)
        builder2.Append(" As New da")
        builder2.Append(Me.Tabla)
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Public Function Listar(ByVal strConexion As String) As List(Of ")
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
        builder2.Append("Using con As New SqlConnection(strConexion)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("con.Open")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("lo")
        builder2.Append(Me.Entidad)
        builder2.Append("=oda")
        builder2.Append(Me.Tabla)
        builder2.Append(".fListar(con)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Using")
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
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Public Function Adicionar(ByVal strConexion As String,")
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
        builder2.Append("Using con As New SqlConnection(strConexion)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("con.Open")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("N=oda")
        builder2.Append(Me.Tabla)
        builder2.Append(".fAdicionar(con,")
        builder2.Append(Me.Instancia)
        builder2.Append(")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Using")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Return N")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Function")
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Public Function Actualizar(ByVal strConexion As String,")
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
        builder2.Append("Using con As New SqlConnection(strConexion)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("con.Open")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("N=oda")
        builder2.Append(Me.Tabla)
        builder2.Append(".fActualizar(con,")
        builder2.Append(Me.Instancia)
        builder2.Append(")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Using")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Return N")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Function")
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Public Function Eliminar(ByVal strConexion As String,")
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
        builder2.Append("Using con As New SqlConnection(strConexion)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("con.Open")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("N=oda")
        builder2.Append(Me.Tabla)
        builder2.Append(".fEliminar(con,")
        builder2.Append(Me.Instancia)
        builder2.Append(")")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("End Using")
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

    Private Sub CrearClaseBusinessRulesCS()
        Me.docXml.Load((Application.StartupPath & "\TiposDatos.xml"))

        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("using " & Me.Entidad & ";")) 'builder2.Append(("using be" & Module1.csb.InitialCatalog))
        builder2.AppendLine()
        builder2.Append(("using " & Me.Clase & ";")) 'builder2.Append(("using da" & Module1.csb.InitialCatalog))
        builder2.AppendLine()
        builder2.Append("using " & SystemData & ";")
        builder2.AppendLine()
        builder2.AppendLine()
        builder2.Append("public class " & Me.Clase)
        builder2.AppendLine()
        builder2.AppendLine("{")
        ' ----------------------------------  fListar     ----------------------------------
        AddReglaNegocio("fListar", builder2)
        builder2.AppendLine()
        ' ----------------------------------  fInsertar   ----------------------------------
        AddReglaNegocio("fInsertar", builder2)
        builder2.AppendLine()
        ' ----------------------------------  fActualizar ----------------------------------
        AddReglaNegocio("fActualizar", builder2)
        builder2.AppendLine()
        ' ----------------------------------  fEliminar   ----------------------------------
        AddReglaNegocio("fEliminar", builder2)
        builder2.AppendLine()
        ' ----------------------------------  fBuscar     ----------------------------------
        AddReglaNegocio("fBuscar", builder2)
        builder2.AppendLine()

        builder2.AppendLine("}")

        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.Clase & ".cs"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    Private Function AddReglaNegocio(lsFuncion As String, builder2 As StringBuilder) As StringBuilder

        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("public List<" & Me.Entidad & "> " & lsFuncion.ToString() & "(string OrclConnection)")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.AppendLine("{")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("List<" & Me.Entidad & "> lo" & Me.Entidad & " = null;")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("using (OracleConnection con = new OracleConnection(OrclConnection))")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.AppendLine("{")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("Try")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.AppendLine("{")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("con.Open();")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Me.Clase & " o" & Me.Clase & " = new " & Me.Clase & "();")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("lo" & Me.Entidad & " = o" & Me.Clase & "." & lsFuncion.ToString() & "(con, lsUsuario);")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.AppendLine("}")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("catch (Exception ex) {}")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.AppendLine("}")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("return (lo" & Me.Entidad & ");")
        builder2.AppendLine()
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.AppendLine("}")
        Return (builder2)
    End Function

    ' Fields
    Private Clase As String
    Private docXml As XmlDataDocument = New XmlDataDocument
    Private Entidad As String
    Private Instancia As String
    Private Lista As ListView
    Private Tabla As String
    Private SystemData As String
End Class


