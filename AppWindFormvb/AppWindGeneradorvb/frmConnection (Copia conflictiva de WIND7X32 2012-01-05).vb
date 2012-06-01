
Public Class frmConnection

    Private Sub Connection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub validatxt(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If sender.Text.Length = 0 Then
            ErrorProvider1.SetError(sender, "Debe tener un valor")
        Else
            ErrorProvider1.SetError(sender, "")
        End If
    End Sub

    Private Sub txtServer_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ErrorProvider1.SetError(sender, "")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Module1.csb.DataSource = txtServer.Text
            Module1.csb.InitialCatalog = txtDataBase.Text
            Module1.csb.UserID = txtUsuario.Text
            Module1.csb.Password = txtPassword.Text
            Module1.csb.IntegratedSecurity = False ' indica si la conceccion es mixta o es por windows
            lblMensaje.Text = Module1.csb.ConnectionString.ToString
            Module1.csb.ToString()
            Using cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(Module1.csb.ConnectionString.ToString)
                cn.Open()
            End Using
            MessageBox.Show("Login Successful", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            My.Forms.frmGenerador.Show()
            'Me.Close()
        Catch ex As Exception
            Microsoft.VisualBasic.CompilerServices.ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            MessageBox.Show("Login Failed", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Microsoft.VisualBasic.CompilerServices.ProjectData.ClearProjectError()
        End Try

    End Sub
End Class