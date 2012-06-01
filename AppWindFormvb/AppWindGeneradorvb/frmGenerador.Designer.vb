<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerador
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
        Me.tvwBD = New System.Windows.Forms.TreeView()
        Me.lvwTabla = New System.Windows.Forms.ListView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GenerateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StoreProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusinessEntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataAccesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusinessRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllComponentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllDataBaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateCSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StoreProcedureToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusinessEntityToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataAccesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusinessRulesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllComponesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllDataBaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvwBD
        '
        Me.tvwBD.Location = New System.Drawing.Point(12, 36)
        Me.tvwBD.Name = "tvwBD"
        Me.tvwBD.Size = New System.Drawing.Size(215, 239)
        Me.tvwBD.TabIndex = 0
        '
        'lvwTabla
        '
        Me.lvwTabla.Location = New System.Drawing.Point(233, 36)
        Me.lvwTabla.Name = "lvwTabla"
        Me.lvwTabla.Size = New System.Drawing.Size(412, 239)
        Me.lvwTabla.TabIndex = 1
        Me.lvwTabla.UseCompatibleStateImageBehavior = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateToolStripMenuItem, Me.GenerateCSToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(657, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GenerateToolStripMenuItem
        '
        Me.GenerateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StoreProcedureToolStripMenuItem, Me.BusinessEntityToolStripMenuItem, Me.DataAccesToolStripMenuItem, Me.BusinessRulesToolStripMenuItem, Me.AllComponentsToolStripMenuItem, Me.AllDataBaseToolStripMenuItem})
        Me.GenerateToolStripMenuItem.Name = "GenerateToolStripMenuItem"
        Me.GenerateToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.GenerateToolStripMenuItem.Text = "Generate VB"
        '
        'StoreProcedureToolStripMenuItem
        '
        Me.StoreProcedureToolStripMenuItem.Name = "StoreProcedureToolStripMenuItem"
        Me.StoreProcedureToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StoreProcedureToolStripMenuItem.Text = "Store Procedure"
        Me.StoreProcedureToolStripMenuItem.ToolTipText = "VB"
        '
        'BusinessEntityToolStripMenuItem
        '
        Me.BusinessEntityToolStripMenuItem.Name = "BusinessEntityToolStripMenuItem"
        Me.BusinessEntityToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BusinessEntityToolStripMenuItem.Text = "Business Entity"
        Me.BusinessEntityToolStripMenuItem.ToolTipText = "VB"
        '
        'DataAccesToolStripMenuItem
        '
        Me.DataAccesToolStripMenuItem.Name = "DataAccesToolStripMenuItem"
        Me.DataAccesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DataAccesToolStripMenuItem.Text = "Data Acces"
        Me.DataAccesToolStripMenuItem.ToolTipText = "VB"
        '
        'BusinessRulesToolStripMenuItem
        '
        Me.BusinessRulesToolStripMenuItem.Name = "BusinessRulesToolStripMenuItem"
        Me.BusinessRulesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BusinessRulesToolStripMenuItem.Text = "Business Rules"
        Me.BusinessRulesToolStripMenuItem.ToolTipText = "VB"
        '
        'AllComponentsToolStripMenuItem
        '
        Me.AllComponentsToolStripMenuItem.Name = "AllComponentsToolStripMenuItem"
        Me.AllComponentsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AllComponentsToolStripMenuItem.Text = "All Components"
        Me.AllComponentsToolStripMenuItem.ToolTipText = "VB"
        '
        'AllDataBaseToolStripMenuItem
        '
        Me.AllDataBaseToolStripMenuItem.Name = "AllDataBaseToolStripMenuItem"
        Me.AllDataBaseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AllDataBaseToolStripMenuItem.Text = "All DataBase"
        Me.AllDataBaseToolStripMenuItem.ToolTipText = "VB"
        '
        'GenerateCSToolStripMenuItem
        '
        Me.GenerateCSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StoreProcedureToolStripMenuItem1, Me.BusinessEntityToolStripMenuItem1, Me.DataAccesToolStripMenuItem1, Me.BusinessRulesToolStripMenuItem1, Me.AllComponesToolStripMenuItem, Me.AllDataBaseToolStripMenuItem1})
        Me.GenerateCSToolStripMenuItem.Name = "GenerateCSToolStripMenuItem"
        Me.GenerateCSToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.GenerateCSToolStripMenuItem.Text = "Generate CS"
        '
        'StoreProcedureToolStripMenuItem1
        '
        Me.StoreProcedureToolStripMenuItem1.Name = "StoreProcedureToolStripMenuItem1"
        Me.StoreProcedureToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.StoreProcedureToolStripMenuItem1.Text = "Store Procedure"
        Me.StoreProcedureToolStripMenuItem1.ToolTipText = "CS"
        '
        'BusinessEntityToolStripMenuItem1
        '
        Me.BusinessEntityToolStripMenuItem1.Name = "BusinessEntityToolStripMenuItem1"
        Me.BusinessEntityToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.BusinessEntityToolStripMenuItem1.Text = "Business Entity"
        Me.BusinessEntityToolStripMenuItem1.ToolTipText = "CS"
        '
        'DataAccesToolStripMenuItem1
        '
        Me.DataAccesToolStripMenuItem1.Name = "DataAccesToolStripMenuItem1"
        Me.DataAccesToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.DataAccesToolStripMenuItem1.Text = "Data Acces"
        Me.DataAccesToolStripMenuItem1.ToolTipText = "CS"
        '
        'BusinessRulesToolStripMenuItem1
        '
        Me.BusinessRulesToolStripMenuItem1.Name = "BusinessRulesToolStripMenuItem1"
        Me.BusinessRulesToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.BusinessRulesToolStripMenuItem1.Text = "Business Rules"
        Me.BusinessRulesToolStripMenuItem1.ToolTipText = "CS"
        '
        'AllComponesToolStripMenuItem
        '
        Me.AllComponesToolStripMenuItem.Name = "AllComponesToolStripMenuItem"
        Me.AllComponesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AllComponesToolStripMenuItem.Text = "All Components"
        Me.AllComponesToolStripMenuItem.ToolTipText = "CS"
        '
        'AllDataBaseToolStripMenuItem1
        '
        Me.AllDataBaseToolStripMenuItem1.Name = "AllDataBaseToolStripMenuItem1"
        Me.AllDataBaseToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AllDataBaseToolStripMenuItem1.Text = "All DataBase"
        Me.AllDataBaseToolStripMenuItem1.ToolTipText = "CS"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'frmGenerador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 284)
        Me.ControlBox = False
        Me.Controls.Add(Me.lvwTabla)
        Me.Controls.Add(Me.tvwBD)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmGenerador"
        Me.Text = "Generador de 3 capas"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvwBD As System.Windows.Forms.TreeView
    Friend WithEvents lvwTabla As System.Windows.Forms.ListView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GenerateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StoreProcedureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BusinessEntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataAccesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BusinessRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllComponentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllDataBaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateCSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StoreProcedureToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BusinessEntityToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataAccesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BusinessRulesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllComponesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllDataBaseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
