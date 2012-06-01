<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnection
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnection))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpSQL = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDataBase = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.tpOracle = New System.Windows.Forms.TabPage()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.oratxtConnect = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.oratxtBaseDatos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.oratxtPassword = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.oratxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.orabtnCancelar = New System.Windows.Forms.Button()
        Me.orabtnAceptar = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tpSQL.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tpOracle.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpSQL)
        Me.TabControl1.Controls.Add(Me.tpOracle)
        Me.TabControl1.Location = New System.Drawing.Point(1, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(414, 225)
        Me.TabControl1.TabIndex = 0
        '
        'tpSQL
        '
        Me.tpSQL.Controls.Add(Me.PictureBox1)
        Me.tpSQL.Controls.Add(Me.GroupBox1)
        Me.tpSQL.Controls.Add(Me.btnCancelar)
        Me.tpSQL.Controls.Add(Me.btnAceptar)
        Me.tpSQL.Location = New System.Drawing.Point(4, 22)
        Me.tpSQL.Name = "tpSQL"
        Me.tpSQL.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSQL.Size = New System.Drawing.Size(406, 199)
        Me.tpSQL.TabIndex = 0
        Me.tpSQL.Text = "SQL Server"
        Me.tpSQL.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 117)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDataBase)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtServer)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(120, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 162)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(235, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Segurity              SQL Server - Windows( Mixed )"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(84, 133)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(166, 20)
        Me.txtPassword.TabIndex = 16
        Me.txtPassword.Text = "tetraciclina"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Password"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(84, 107)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(166, 20)
        Me.txtUsuario.TabIndex = 14
        Me.txtUsuario.Text = "sa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "User"
        '
        'txtDataBase
        '
        Me.txtDataBase.Location = New System.Drawing.Point(84, 45)
        Me.txtDataBase.Name = "txtDataBase"
        Me.txtDataBase.Size = New System.Drawing.Size(166, 20)
        Me.txtDataBase.TabIndex = 12
        Me.txtDataBase.Text = "Almacen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Data Base"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(84, 19)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(166, 20)
        Me.txtServer.TabIndex = 10
        Me.txtServer.Text = "WIND7X32\SQLWIND7"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Server "
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(204, 171)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(120, 171)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'tpOracle
        '
        Me.tpOracle.Controls.Add(Me.PictureBox2)
        Me.tpOracle.Controls.Add(Me.GroupBox2)
        Me.tpOracle.Controls.Add(Me.orabtnCancelar)
        Me.tpOracle.Controls.Add(Me.orabtnAceptar)
        Me.tpOracle.Location = New System.Drawing.Point(4, 22)
        Me.tpOracle.Name = "tpOracle"
        Me.tpOracle.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOracle.Size = New System.Drawing.Size(406, 199)
        Me.tpOracle.TabIndex = 1
        Me.tpOracle.Text = "Oracle EX"
        Me.tpOracle.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(7, 36)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(108, 117)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.oratxtConnect)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.oratxtBaseDatos)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.oratxtPassword)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.oratxtUsuario)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(121, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 162)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(235, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Segurity              SQL Server - Windows( Mixed )"
        '
        'oratxtConnect
        '
        Me.oratxtConnect.Location = New System.Drawing.Point(84, 133)
        Me.oratxtConnect.Name = "oratxtConnect"
        Me.oratxtConnect.Size = New System.Drawing.Size(166, 20)
        Me.oratxtConnect.TabIndex = 16
        Me.oratxtConnect.Text = "normal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Connect as"
        '
        'oratxtBaseDatos
        '
        Me.oratxtBaseDatos.Location = New System.Drawing.Point(84, 107)
        Me.oratxtBaseDatos.Name = "oratxtBaseDatos"
        Me.oratxtBaseDatos.Size = New System.Drawing.Size(166, 20)
        Me.oratxtBaseDatos.TabIndex = 14
        Me.oratxtBaseDatos.Text = "XE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Base de Datos"
        '
        'oratxtPassword
        '
        Me.oratxtPassword.Location = New System.Drawing.Point(84, 45)
        Me.oratxtPassword.Name = "oratxtPassword"
        Me.oratxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.oratxtPassword.Size = New System.Drawing.Size(166, 20)
        Me.oratxtPassword.TabIndex = 12
        Me.oratxtPassword.Text = "password"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Password"
        '
        'oratxtUsuario
        '
        Me.oratxtUsuario.Location = New System.Drawing.Point(84, 19)
        Me.oratxtUsuario.Name = "oratxtUsuario"
        Me.oratxtUsuario.Size = New System.Drawing.Size(166, 20)
        Me.oratxtUsuario.TabIndex = 10
        Me.oratxtUsuario.Text = "SIICEX"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Usuario"
        '
        'orabtnCancelar
        '
        Me.orabtnCancelar.Location = New System.Drawing.Point(205, 170)
        Me.orabtnCancelar.Name = "orabtnCancelar"
        Me.orabtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.orabtnCancelar.TabIndex = 14
        Me.orabtnCancelar.Text = "Cancelar"
        Me.orabtnCancelar.UseVisualStyleBackColor = True
        '
        'orabtnAceptar
        '
        Me.orabtnAceptar.Location = New System.Drawing.Point(121, 170)
        Me.orabtnAceptar.Name = "orabtnAceptar"
        Me.orabtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.orabtnAceptar.TabIndex = 13
        Me.orabtnAceptar.Text = "Aceptar"
        Me.orabtnAceptar.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Location = New System.Drawing.Point(35, 5)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(0, 13)
        Me.lblMensaje.TabIndex = 1
        '
        'frmConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 228)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConnection"
        Me.Text = "Connection"
        Me.TabControl1.ResumeLayout(False)
        Me.tpSQL.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpOracle.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpSQL As System.Windows.Forms.TabPage
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents tpOracle As System.Windows.Forms.TabPage
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDataBase As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents oratxtConnect As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents oratxtBaseDatos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents oratxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents oratxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents orabtnCancelar As System.Windows.Forms.Button
    Friend WithEvents orabtnAceptar As System.Windows.Forms.Button
End Class
