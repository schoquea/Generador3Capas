Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Data.OracleClient

<StandardModule()> _
Friend NotInheritable Class Module1
    ' Fields
    Public Shared csb As SqlConnectionStringBuilder = New SqlConnectionStringBuilder
    Public Shared csc As OracleConnectionStringBuilder = New OracleConnectionStringBuilder
    Public Shared tipo As String = ""
    Public Shared leng As String = ""

End Class