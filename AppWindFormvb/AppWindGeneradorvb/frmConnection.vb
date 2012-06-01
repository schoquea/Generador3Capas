Imports Microsoft.VisualBasic.CompilerServices
Imports System.Windows.Forms

Public Class frmConnection

    Private Sub validatxt(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtServer.Validating, txtDataBase.Validating, txtPassword.Validating, txtUsuario.Validating
        If sender.Text.Length = 0 Then
            ErrorProvider1.SetError(sender, "Debe tener un valor")
        Else
            ErrorProvider1.SetError(sender, "")
        End If
    End Sub

    Private Sub txtServer_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataBase.VisibleChanged, txtPassword.VisibleChanged, txtServer.VisibleChanged, txtUsuario.VisibleChanged
        Me.ErrorProvider1.SetError(sender, "")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Module1.csb.DataSource = txtServer.Text

            Module1.csb.InitialCatalog = txtDataBase.Text
            Module1.csb.UserID = txtUsuario.Text
            Module1.csb.Password = txtPassword.Text
            Module1.csb.IntegratedSecurity = False ' indica si la conceccion es mixta o es por windows

            Using connection As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(Module1.csb.ToString)
                connection.Open()
            End Using
            MessageBox.Show("Login Successful", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Module1.tipo = "SQL"
            frmGenerador.Show()
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            MessageBox.Show("Login Failed", "Denegate Access", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            ProjectData.ClearProjectError()
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click, orabtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub orabtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles orabtnAceptar.Click
        Try
            Module1.csc.UserID = oratxtUsuario.Text
            Module1.csc.Password = oratxtPassword.Text
            Module1.csc.DataSource = oratxtBaseDatos.Text
            Module1.csc.IntegratedSecurity = False ' indica si la coneccion es mixta o es por windows

            Using connection As System.Data.OracleClient.OracleConnection = New System.Data.OracleClient.OracleConnection(Module1.csc.ToString)
                connection.Open()
            End Using
            MessageBox.Show("Login Successful", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Module1.tipo = "ORACLE"
            frmGenerador.Show()
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            MessageBox.Show("Login Failed", "Denegate Access", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            ProjectData.ClearProjectError()
        End Try
    End Sub
End Class