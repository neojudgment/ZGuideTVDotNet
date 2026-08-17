<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gestionbdd
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Gestionbdd))
        Me.ListViewGestionBdd = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonRestore = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonDelete = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.GroupBoxRestauration = New System.Windows.Forms.GroupBox()
        Me.CheckBoxRestaurationLogos = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRestaurationUserConfig = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRestaurationUrl = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRestaurationChaines = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRestaurationDataBase = New System.Windows.Forms.CheckBox()
        Me.ButtonRename = New System.Windows.Forms.Button()
        Me.FolderBrowserDialogDirectory = New System.Windows.Forms.FolderBrowserDialog()
        Me.DirectoryBackup = New System.Windows.Forms.Button()
        Me.TextBoxDirectory = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelBackupDirectory = New System.Windows.Forms.Label()
        Me.GroupBoxRestauration.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewGestionBdd
        '
        Me.ListViewGestionBdd.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListViewGestionBdd.FullRowSelect = True
        Me.ListViewGestionBdd.GridLines = True
        Me.ListViewGestionBdd.HideSelection = False
        Me.ListViewGestionBdd.Location = New System.Drawing.Point(207, 21)
        Me.ListViewGestionBdd.Name = "ListViewGestionBdd"
        Me.ListViewGestionBdd.Size = New System.Drawing.Size(403, 254)
        Me.ListViewGestionBdd.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewGestionBdd.TabIndex = 0
        Me.ListViewGestionBdd.UseCompatibleStateImageBehavior = False
        Me.ListViewGestionBdd.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 85
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 89
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 200
        '
        'ButtonRestore
        '
        Me.ButtonRestore.Location = New System.Drawing.Point(470, 288)
        Me.ButtonRestore.Name = "ButtonRestore"
        Me.ButtonRestore.Size = New System.Drawing.Size(67, 23)
        Me.ButtonRestore.TabIndex = 1
        Me.ButtonRestore.Text = "Restaurer"
        Me.ButtonRestore.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(543, 288)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(67, 23)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Quitter"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Location = New System.Drawing.Point(207, 288)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(67, 23)
        Me.ButtonDelete.TabIndex = 3
        Me.ButtonDelete.Text = "Supprimer"
        Me.ButtonDelete.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(385, 288)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(79, 23)
        Me.ButtonSave.TabIndex = 4
        Me.ButtonSave.Text = "Sauvegarder"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'GroupBoxRestauration
        '
        Me.GroupBoxRestauration.Controls.Add(Me.CheckBoxRestaurationLogos)
        Me.GroupBoxRestauration.Controls.Add(Me.CheckBoxRestaurationUserConfig)
        Me.GroupBoxRestauration.Controls.Add(Me.CheckBoxRestaurationUrl)
        Me.GroupBoxRestauration.Controls.Add(Me.CheckBoxRestaurationChaines)
        Me.GroupBoxRestauration.Controls.Add(Me.CheckBoxRestaurationDataBase)
        Me.GroupBoxRestauration.Location = New System.Drawing.Point(15, 21)
        Me.GroupBoxRestauration.Name = "GroupBoxRestauration"
        Me.GroupBoxRestauration.Size = New System.Drawing.Size(175, 138)
        Me.GroupBoxRestauration.TabIndex = 5
        Me.GroupBoxRestauration.TabStop = False
        Me.GroupBoxRestauration.Text = "Restauration"
        '
        'CheckBoxRestaurationLogos
        '
        Me.CheckBoxRestaurationLogos.AutoSize = True
        Me.CheckBoxRestaurationLogos.Location = New System.Drawing.Point(13, 106)
        Me.CheckBoxRestaurationLogos.Name = "CheckBoxRestaurationLogos"
        Me.CheckBoxRestaurationLogos.Size = New System.Drawing.Size(55, 17)
        Me.CheckBoxRestaurationLogos.TabIndex = 6
        Me.CheckBoxRestaurationLogos.Text = "Logos"
        Me.CheckBoxRestaurationLogos.UseVisualStyleBackColor = True
        '
        'CheckBoxRestaurationUserConfig
        '
        Me.CheckBoxRestaurationUserConfig.AutoSize = True
        Me.CheckBoxRestaurationUserConfig.Location = New System.Drawing.Point(13, 86)
        Me.CheckBoxRestaurationUserConfig.Name = "CheckBoxRestaurationUserConfig"
        Me.CheckBoxRestaurationUserConfig.Size = New System.Drawing.Size(135, 17)
        Me.CheckBoxRestaurationUserConfig.TabIndex = 5
        Me.CheckBoxRestaurationUserConfig.Text = "Configuration utilisateur"
        Me.CheckBoxRestaurationUserConfig.UseVisualStyleBackColor = True
        '
        'CheckBoxRestaurationUrl
        '
        Me.CheckBoxRestaurationUrl.AutoSize = True
        Me.CheckBoxRestaurationUrl.Location = New System.Drawing.Point(13, 66)
        Me.CheckBoxRestaurationUrl.Name = "CheckBoxRestaurationUrl"
        Me.CheckBoxRestaurationUrl.Size = New System.Drawing.Size(119, 17)
        Me.CheckBoxRestaurationUrl.TabIndex = 4
        Me.CheckBoxRestaurationUrl.Text = "Liens de mise à jour"
        Me.CheckBoxRestaurationUrl.UseVisualStyleBackColor = True
        '
        'CheckBoxRestaurationChaines
        '
        Me.CheckBoxRestaurationChaines.AutoSize = True
        Me.CheckBoxRestaurationChaines.Location = New System.Drawing.Point(13, 46)
        Me.CheckBoxRestaurationChaines.Name = "CheckBoxRestaurationChaines"
        Me.CheckBoxRestaurationChaines.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxRestaurationChaines.TabIndex = 3
        Me.CheckBoxRestaurationChaines.Text = "Liste des chaînes"
        Me.CheckBoxRestaurationChaines.UseVisualStyleBackColor = True
        '
        'CheckBoxRestaurationDataBase
        '
        Me.CheckBoxRestaurationDataBase.AutoSize = True
        Me.CheckBoxRestaurationDataBase.Location = New System.Drawing.Point(13, 26)
        Me.CheckBoxRestaurationDataBase.Name = "CheckBoxRestaurationDataBase"
        Me.CheckBoxRestaurationDataBase.Size = New System.Drawing.Size(109, 17)
        Me.CheckBoxRestaurationDataBase.TabIndex = 2
        Me.CheckBoxRestaurationDataBase.Text = "Base de données"
        Me.CheckBoxRestaurationDataBase.UseVisualStyleBackColor = True
        '
        'ButtonRename
        '
        Me.ButtonRename.Location = New System.Drawing.Point(312, 288)
        Me.ButtonRename.Name = "ButtonRename"
        Me.ButtonRename.Size = New System.Drawing.Size(67, 23)
        Me.ButtonRename.TabIndex = 6
        Me.ButtonRename.Text = "Renommer"
        Me.ButtonRename.UseVisualStyleBackColor = True
        '
        'DirectoryBackup
        '
        Me.DirectoryBackup.Location = New System.Drawing.Point(8, 288)
        Me.DirectoryBackup.Name = "DirectoryBackup"
        Me.DirectoryBackup.Size = New System.Drawing.Size(75, 23)
        Me.DirectoryBackup.TabIndex = 7
        Me.DirectoryBackup.Text = "Sélectionner"
        Me.DirectoryBackup.UseVisualStyleBackColor = True
        '
        'TextBoxDirectory
        '
        Me.TextBoxDirectory.BackColor = System.Drawing.Color.White
        Me.TextBoxDirectory.Location = New System.Drawing.Point(8, 259)
        Me.TextBoxDirectory.Name = "TextBoxDirectory"
        Me.TextBoxDirectory.ReadOnly = True
        Me.TextBoxDirectory.Size = New System.Drawing.Size(193, 20)
        Me.TextBoxDirectory.TabIndex = 8
        '
        'LabelBackupDirectory
        '
        Me.LabelBackupDirectory.AutoSize = True
        Me.LabelBackupDirectory.Location = New System.Drawing.Point(5, 243)
        Me.LabelBackupDirectory.Name = "LabelBackupDirectory"
        Me.LabelBackupDirectory.Size = New System.Drawing.Size(133, 13)
        Me.LabelBackupDirectory.TabIndex = 9
        Me.LabelBackupDirectory.Text = "Répertoire de sauvegarde:"
        '
        'Gestionbdd
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(626, 323)
        Me.Controls.Add(Me.LabelBackupDirectory)
        Me.Controls.Add(Me.TextBoxDirectory)
        Me.Controls.Add(Me.DirectoryBackup)
        Me.Controls.Add(Me.ButtonRename)
        Me.Controls.Add(Me.GroupBoxRestauration)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonDelete)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonRestore)
        Me.Controls.Add(Me.ListViewGestionBdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Gestionbdd"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Gestion bases de données"
        Me.GroupBoxRestauration.ResumeLayout(False)
        Me.GroupBoxRestauration.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListViewGestionBdd As System.Windows.Forms.ListView
    Friend WithEvents ButtonRestore As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonDelete As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBoxRestauration As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxRestaurationUserConfig As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRestaurationUrl As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRestaurationChaines As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRestaurationDataBase As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRestaurationLogos As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonRename As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialogDirectory As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DirectoryBackup As System.Windows.Forms.Button
    Friend WithEvents TextBoxDirectory As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LabelBackupDirectory As System.Windows.Forms.Label
End Class
