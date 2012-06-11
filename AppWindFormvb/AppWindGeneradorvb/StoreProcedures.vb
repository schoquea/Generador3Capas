Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

'Namespace NETCodeGenerator
Public Class StoreProcedures
    ' Methods
    Public Sub New(ByVal vTabla As String, ByVal vLista As ListView)
        Me.Tabla = vTabla
        Me.Lista = vLista

        If Module1.tipo = "SQL" Then
            Me.CrearSPSelect()
            Me.CrearSPInsert()
            Me.CrearSPUpdate()
            Me.CrearSPDelete()
        Else
            Me.CrearPKC_HEAD_CS()
            Me.CrearPKC_BODY_CS()
        End If

    End Sub

    '--//-----------------------------SQL------------------------------
    Private Sub CrearSPDelete()
        Dim str3 As String
        Me.SP = ("USP_" & Me.Tabla & "_DEL01")
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("CREATE PROCEDURE " & Me.SP))
        builder2.AppendLine()
        Dim text As String = Me.Lista.Items.Item(0).SubItems.Item(0).Text
        Dim str4 As String = Me.Lista.Items.Item(0).SubItems.Item(1).Text
        Dim str2 As String = Me.Lista.Items.Item(0).SubItems.Item(2).Text
        If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
            str3 = ("(" & str2 & ")")
        Else
            str3 = ""
        End If
        builder2.Append(String.Concat(New String() {Microsoft.VisualBasic.Strings.ChrW(9) & "@", [text], " ", str4, str3}))
        builder2.AppendLine("")
        builder2.Append("AS")
        builder2.AppendLine("")
        builder2.Append(("DELETE FROM " & Me.Tabla))
        builder2.AppendLine("")
        builder2.Append(("WHERE " & [text] & "=@" & [text]))
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.SP & ".txt"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    Private Sub CrearSPInsert()
        Dim text As String
        Dim flag2 As Boolean
        Dim str4 As String
        Dim enumerator As IEnumerator
        Dim enumerator2 As IEnumerator
        Dim enumerator3 As IEnumerator
        Me.SP = ("USP_" & Me.Tabla & "_INS01")
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("CREATE PROCEDURE " & Me.SP))
        builder2.AppendLine()
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim flag As Boolean
                Dim str3 As String
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                [text] = current.SubItems.Item(0).Text
                str4 = current.SubItems.Item(1).Text
                Dim str2 As String = current.SubItems.Item(2).Text
                If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
                    str3 = ("(" & str2 & ")")
                Else
                    str3 = ""
                End If
                If Not flag Then
                    builder2.Append(String.Concat(New String() {Microsoft.VisualBasic.Strings.ChrW(9) & "@", [text], " ", str4, str3, ","}))
                    builder2.AppendLine("")
                End If
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append("AS")
        builder2.AppendLine("")
        builder2.Append(("INSERT INTO " & Me.Tabla))
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "(")
        builder2.AppendLine("")
        Try
            enumerator2 = Me.Lista.Items.GetEnumerator
            Do While enumerator2.MoveNext
                Dim item2 As ListViewItem = DirectCast(enumerator2.Current, ListViewItem)
                [text] = item2.SubItems.Item(0).Text
                str4 = item2.SubItems.Item(1).Text
                flag2 = Conversions.ToBoolean(item2.SubItems.Item(3).Text)
                If Not Conversions.ToBoolean(item2.SubItems.Item(4).Text) Then
                    builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & [text] & ","))
                    builder2.AppendLine("")
                End If
            Loop
        Finally
            If TypeOf enumerator2 Is IDisposable Then
                TryCast(enumerator2, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & ")")
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "VALUES")
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "(")
        builder2.AppendLine("")
        Try
            enumerator3 = Me.Lista.Items.GetEnumerator
            Do While enumerator3.MoveNext
                Dim item3 As ListViewItem = DirectCast(enumerator3.Current, ListViewItem)
                [text] = item3.SubItems.Item(0).Text
                str4 = item3.SubItems.Item(1).Text
                flag2 = Conversions.ToBoolean(item3.SubItems.Item(3).Text)
                If Not Conversions.ToBoolean(item3.SubItems.Item(4).Text) Then
                    builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & "@" & [text] & ","))
                    builder2.AppendLine("")
                End If
            Loop
        Finally
            If TypeOf enumerator3 Is IDisposable Then
                TryCast(enumerator3, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & ")")
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.SP & ".txt"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    Private Sub CrearSPSelect()
        Dim enumerator As IEnumerator
        Me.SP = ("USP_" & Me.Tabla & "_SEL01")
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("CREATE PROCEDURE " & Me.SP))
        builder2.AppendLine("")
        builder2.Append("AS")
        builder2.AppendLine("")
        builder2.Append("SELECT ")
        builder2.AppendLine("")
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim str2 As String
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                Dim text As String = current.SubItems.Item(0).Text
                Dim str3 As String = current.SubItems.Item(1).Text
                Dim flag2 As Boolean = Conversions.ToBoolean(current.SubItems.Item(3).Text)
                Dim flag As Boolean = Conversions.ToBoolean(current.SubItems.Item(4).Text)
                If flag2 Then
                    str2 = ("IsNull(" & [text] & ",")
                    If ((((str3 = "char") Or (str3 = "nchar")) Or (str3 = "varchar")) Or (str3 = "nvarchar")) Then
                        str2 = (str2 & "''")
                    End If
                    If ((((str3 = "tinyint") Or (str3 = "smallint")) Or (str3 = "int")) Or (str3 = "decimal")) Then
                        str2 = (str2 & "0")
                    End If
                    If (str3 = "datetime") Then
                        str2 = (str2 & "'1/1/1900'")
                    End If
                    str2 = (str2 & ") As " & [text] & ",")
                Else
                    str2 = ([text] & ",")
                End If
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & str2))
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(("FROM " & Me.Tabla))
        builder2.AppendLine("")
        builder2.Append("ORDER BY 1")
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.SP & ".txt"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    Private Sub CrearSPUpdate()
        Dim text As String
        Dim enumerator As IEnumerator
        Me.SP = ("USP_" & Me.Tabla & "_UPD01")
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        builder2.Append(("CREATE PROCEDURE " & Me.SP))
        builder2.AppendLine()
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim str3 As String
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                [text] = current.SubItems.Item(0).Text
                Dim str4 As String = current.SubItems.Item(1).Text
                Dim str2 As String = current.SubItems.Item(2).Text
                If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
                    str3 = ("(" & str2 & ")")
                Else
                    str3 = ""
                End If
                builder2.Append(String.Concat(New String() {Microsoft.VisualBasic.Strings.ChrW(9) & "@", [text], " ", str4, str3, ","}))
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append("AS")
        builder2.AppendLine("")
        builder2.Append(("UPDATE " & Me.Tabla))
        builder2.AppendLine("")
        builder2.Append("SET ")
        builder2.AppendLine("")
        Dim num2 As Integer = (Me.Lista.Items.Count - 1)
        Dim i As Integer = 1
        Do While (i <= num2)
            [text] = Me.Lista.Items.Item(i).SubItems.Item(0).Text
            builder2.Append(String.Concat(New String() {Microsoft.VisualBasic.Strings.ChrW(9), [text], "=@", [text], ","}))
            builder2.AppendLine("")
            i += 1
        Loop
        [text] = Me.Lista.Items.Item(0).SubItems.Item(0).Text
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append("WHERE")
        builder2.AppendLine("")
        builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & [text] & "=@" & [text]))
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter((Me.SP & ".txt"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    '--//-----------------------------ORACLE----------------------------
    Private Sub CrearPKC_HEAD_CS()

        Dim str3 As String
        Dim str2 As String
        Me.SP = ("USP_" & Me.Tabla & "_DEL01")
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder
        Dim enumerator As IEnumerator
        builder2.AppendLine("")
        builder2.Append("CREATE OR REPLACE PACKAGE PCK_" & Me.Tabla & " IS")
        builder2.AppendLine("")
        builder2.Append("TYPE V_CURSOR IS REF CURSOR;")
        builder2.AppendLine("")
        builder2.Append("--//DEL01------------------------------------------------------------------------------------")
        builder2.AppendLine(" ")
        builder2.AppendLine(" ")
        builder2.Append(("PROCEDURE " & Me.SP))
        builder2.AppendLine()
        Dim text As String = Me.Lista.Items.Item(0).SubItems.Item(0).Text
        Dim str4 As String = Me.Lista.Items.Item(0).SubItems.Item(1).Text
        str2 = Me.Lista.Items.Item(0).SubItems.Item(2).Text
        If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
            str3 = ("(" & str2 & ")")
        Else
            str3 = ""
        End If
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(String.Concat(New String() {"(", str4, " IN P_", [text], str3, ");"}))
        builder2.AppendLine(" ")
        builder2.Append("--//INS01------------------------------------------------------------------------------------")
        builder2.AppendLine(" ")
        builder2.AppendLine(" ")
        Me.SP = ("USP_" & Me.Tabla & "_INS01")
        builder2.Append(("PROCEDURE " & Me.SP))
        builder2.AppendLine("")
        builder2.Append("(")
        builder2.AppendLine("")
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim flag As Boolean
                'Dim str3 As String
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                [text] = current.SubItems.Item(0).Text
                str4 = current.SubItems.Item(1).Text
                str2 = current.SubItems.Item(2).Text
                If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
                    str3 = ("(" & str2 & ")")
                Else
                    str3 = ""
                End If
                If Not flag Then
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(String.Concat(New String() {"P_", [text], " IN ", str4, str3, ","}))
                    builder2.AppendLine("")
                End If
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(");")
        builder2.AppendLine("")
        builder2.Append("--//SEL01------------------------------------------------------------------------------------")
        builder2.AppendLine(" ")
        builder2.AppendLine(" ")
        Me.SP = ("USP_" & Me.Tabla & "_SEL01")
        builder2.Append(("PROCEDURE " & Me.SP))
        builder2.Append("(P_CURSOR IN OUT V_CURSOR)")
        builder2.AppendLine("")
        builder2.Append("--//UPD01------------------------------------------------------------------------------------")
        builder2.AppendLine(" ")
        builder2.AppendLine(" ")
        Me.SP = ("USP_" & Me.Tabla & "_UPD01")
        builder2.Append(("PROCEDURE " & Me.SP))
        builder2.AppendLine("")
        builder2.Append("(")
        builder2.AppendLine("")
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                [text] = current.SubItems.Item(0).Text
                str4 = current.SubItems.Item(1).Text
                str2 = current.SubItems.Item(2).Text
                If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
                    str3 = ("(" & str2 & ")")
                Else
                    str3 = ""
                End If
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(String.Concat(New String() {"P_", [text], " IN ", str4, str3, ","}))
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(");")
        builder2.AppendLine("")
        builder2.AppendLine("END PKC_" & Me.Tabla & ";")
        builder2.AppendLine("")
        builder2.AppendLine("")
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter(("PKC_" & Me.Tabla & "_HEAD.txt"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    Private Sub CrearPKC_BODY_CS()
        Dim str3 As String
        Dim str2 As String
        Me.SP = ("USP_" & Me.Tabla & "_DEL01")
        Dim builder As New StringBuilder
        Dim builder2 As StringBuilder = builder

        builder2.AppendLine("")
        builder2.AppendLine("CREATE OR REPLACE PACKAGE BODY PKC_" & Me.Tabla & " IS")
        builder2.AppendLine("")
        builder2.Append("--//DEL01------------------------------------------------------------------------------------")
        builder2.AppendLine(" ")
        builder2.AppendLine(" ")
        builder2.Append(("PROCEDURE " & Me.SP))
        builder2.AppendLine()
        Dim text As String = Me.Lista.Items.Item(0).SubItems.Item(0).Text
        Dim str4 As String = Me.Lista.Items.Item(0).SubItems.Item(1).Text
        str2 = Me.Lista.Items.Item(0).SubItems.Item(2).Text
        If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
            str3 = ("(" & str2 & ")")
        Else
            str3 = ""
        End If
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(String.Concat(New String() {"(", str4, " IN P_", [text], str3, ")"}))
        builder2.AppendLine("")
        builder2.Append("AS")
        builder2.AppendLine("")
        builder2.Append("BEGIN")
        builder2.AppendLine(" ")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & ("DELETE FROM " & Me.Tabla))
        builder2.AppendLine(" ")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & ("WHERE " & [text] & " = P_" & [text]) & ";")
        builder2.AppendLine(" ")
        builder2.Append("END " & Me.SP & ";")
        builder2.AppendLine(" ")
        builder2.Append("--//INS01------------------------------------------------------------------------------------")
        builder2.AppendLine(" ")
        builder2.AppendLine(" ")
        Dim flag2 As Boolean
        'Dim str4 As String
        Dim enumerator As IEnumerator
        Dim enumerator2 As IEnumerator
        Dim enumerator3 As IEnumerator
        Me.SP = ("USP_" & Me.Tabla & "_INS01")
        builder2.Append(("PROCEDURE " & Me.SP))
        builder2.AppendLine("")
        builder2.Append("(")
        builder2.AppendLine("")
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim flag As Boolean
                'Dim str3 As String
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                [text] = current.SubItems.Item(0).Text
                str4 = current.SubItems.Item(1).Text
                str2 = current.SubItems.Item(2).Text
                If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
                    str3 = ("(" & str2 & ")")
                Else
                    str3 = ""
                End If
                If Not flag Then
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(String.Concat(New String() {"P_", [text], " IN ", str4, str3, ","}))
                    builder2.AppendLine("")
                End If
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(")")
        builder2.AppendLine("")
        builder2.Append("AS")
        builder2.AppendLine("")
        builder2.Append("BEGIN")
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "INSERT INTO " & Me.Tabla)
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("(")
        builder2.AppendLine("")
        Try
            enumerator2 = Me.Lista.Items.GetEnumerator
            Do While enumerator2.MoveNext
                Dim item2 As ListViewItem = DirectCast(enumerator2.Current, ListViewItem)
                [text] = item2.SubItems.Item(0).Text
                str4 = item2.SubItems.Item(1).Text
                flag2 = Conversions.ToBoolean(item2.SubItems.Item(3).Text)
                If Not Conversions.ToBoolean(item2.SubItems.Item(4).Text) Then
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(([text] & ","))
                    builder2.AppendLine("")
                End If
            Loop
        Finally
            If TypeOf enumerator2 Is IDisposable Then
                TryCast(enumerator2, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & ")")
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "VALUES")
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "(")
        builder2.AppendLine("")
        Try
            enumerator3 = Me.Lista.Items.GetEnumerator
            Do While enumerator3.MoveNext
                Dim item3 As ListViewItem = DirectCast(enumerator3.Current, ListViewItem)
                [text] = item3.SubItems.Item(0).Text
                str4 = item3.SubItems.Item(1).Text
                flag2 = Conversions.ToBoolean(item3.SubItems.Item(3).Text)
                If Not Conversions.ToBoolean(item3.SubItems.Item(4).Text) Then
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                    builder2.Append(("P_" & [text] & ","))
                    builder2.AppendLine("")
                End If
            Loop
        Finally
            If TypeOf enumerator3 Is IDisposable Then
                TryCast(enumerator3, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & ");")
        builder2.AppendLine("")
        builder2.Append("END " & Me.SP & ";")
        builder2.AppendLine(" ")
        builder2.Append("--//SEL01------------------------------------------------------------------------------------")
        builder2.AppendLine(" ")
        builder2.AppendLine(" ")
        Me.SP = ("USP_" & Me.Tabla & "_SEL01")
        builder2.Append(("PROCEDURE " & Me.SP))
        builder2.Append("(P_CURSOR IN OUT V_CURSOR)")
        builder2.AppendLine("")
        builder2.Append("AS")
        builder2.AppendLine("")
        builder2.Append("BEGIN")
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "OPEN P_CURSOR FOR")
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "SELECT ")
        builder2.AppendLine("")
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                'Dim str2 As String
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                text = current.SubItems.Item(0).Text
                str3 = current.SubItems.Item(1).Text
                flag2 = Conversions.ToBoolean(current.SubItems.Item(3).Text)
                Dim flag As Boolean = Conversions.ToBoolean(current.SubItems.Item(4).Text)
                If flag2 Then
                    str2 = ([text])
                    If ((((str3 = "char") Or (str3 = "nchar")) Or (str3 = "varchar")) Or (str3 = "nvarchar")) Then
                        str2 = (str2 & "''")
                    End If
                    If ((((str3 = "tinyint") Or (str3 = "smallint")) Or (str3 = "int")) Or (str3 = "decimal")) Then
                        str2 = (str2 & "0")
                    End If
                    If (str3 = "datetime") Then
                        str2 = (str2 & "'1/1/1900'")
                    End If
                    str2 = (Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & str2 & ",")
                Else
                    str2 = (Microsoft.VisualBasic.Strings.ChrW(9) & Microsoft.VisualBasic.Strings.ChrW(9) & [text] & ",")
                End If
                builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & str2))
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & ("FROM " & Me.Tabla))
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9) & "ORDER BY 1;")
        builder2.AppendLine(" ")
        builder2.Append("END " & Me.SP & ";")
        builder2.AppendLine(" ")
        builder2.Append("--//UPD01------------------------------------------------------------------------------------")
        builder2.AppendLine(" ")
        builder2.AppendLine(" ")
        Me.SP = ("USP_" & Me.Tabla & "_UPD01")
        builder2.Append(("PROCEDURE " & Me.SP))
        builder2.AppendLine("")
        builder2.Append("(")
        builder2.AppendLine("")
        Try
            enumerator = Me.Lista.Items.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                [text] = current.SubItems.Item(0).Text
                str4 = current.SubItems.Item(1).Text
                str2 = current.SubItems.Item(2).Text
                If ((((str4 = "char") Or (str4 = "nchar")) Or (str4 = "varchar")) Or (str4 = "nvarchar")) Then
                    str3 = ("(" & str2 & ")")
                Else
                    str3 = ""
                End If
                builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
                builder2.Append(String.Concat(New String() {"P_", [text], " IN ", str4, str3, ","}))
                builder2.AppendLine("")
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(")")
        builder2.AppendLine("")
        builder2.Append("AS")
        builder2.AppendLine("")
        builder2.Append("BEGIN")
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append(("UPDATE " & Me.Tabla))
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("SET ")
        builder2.AppendLine("")
        Dim num2 As Integer = (Me.Lista.Items.Count - 1)
        Dim i As Integer = 1
        Do While (i <= num2)
            [text] = Me.Lista.Items.Item(i).SubItems.Item(0).Text
            builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
            builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
            builder2.Append(String.Concat(New String() {[text], " = P_", [text], ","}))
            builder2.AppendLine("")
            i += 1
        Loop
        [text] = Me.Lista.Items.Item(0).SubItems.Item(0).Text
        builder.Remove((builder.Length - 3), 3)
        builder2.AppendLine("")
        builder2.Append(Microsoft.VisualBasic.Strings.ChrW(9))
        builder2.Append("WHERE")
        builder2.AppendLine("")
        builder2.Append((Microsoft.VisualBasic.Strings.ChrW(9) & [text] & " = P_" & [text]) & ";")
        builder2.AppendLine("")
        builder2.Append("END " & Me.SP & ";")
        builder2.AppendLine("")
        builder2.AppendLine("END PKC_" & Me.Tabla & ";")
        builder2.AppendLine("")
        builder2.AppendLine("")
        builder2 = Nothing
        Using writer As StreamWriter = New StreamWriter(("PKC_" & Me.Tabla & "_BODY.txt"))
            writer.Write(builder.ToString)
        End Using
    End Sub

    ' Fields
    Private Lista As ListView
    Private SP As String
    Private Tabla As String
End Class
'End Namespace

