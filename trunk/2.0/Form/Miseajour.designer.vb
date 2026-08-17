

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Miseajour
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Miseajour))
        Me.ButtonDemarrer = New System.Windows.Forms.Button()
        Me.ListViewAllChannel = New System.Windows.Forms.ListView()
        Me.ButtonAnnuler = New System.Windows.Forms.Button()
        Me.OpenFileDialogXml = New System.Windows.Forms.OpenFileDialog()
        Me.ButtonOpenfile = New System.Windows.Forms.Button()
        Me.TextBoxPathXml = New System.Windows.Forms.TextBox()
        Me.RadioButtonXmlPath = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDownload = New System.Windows.Forms.RadioButton()
        Me.ListXMLTVFRChoisie = New System.Windows.Forms.ListView()
        Me.ButtonTout = New System.Windows.Forms.Button()
        Me.ButtonAppliquer = New System.Windows.Forms.Button()
        Me.ProgressBarMiseaJ = New System.Windows.Forms.ProgressBar()
        Me.URLComboBox = New System.Windows.Forms.ComboBox()
        Me.ButtonSuppr = New System.Windows.Forms.Button()
        Me.ButtonEdit = New System.Windows.Forms.Button()
        Me.BackgroundWorkerParseXML = New System.ComponentModel.BackgroundWorker()
        Me.ButtonHelpMiseaJour = New System.Windows.Forms.Button()
        Me.CheckBoxAutoRestartManualUpdate = New System.Windows.Forms.CheckBox()
        Me.txbRecherche = New System.Windows.Forms.TextBox()
        Me.btReset = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonDemarrer
        '
        Me.ButtonDemarrer.Enabled = False
        Me.ButtonDemarrer.Location = New System.Drawing.Point(349, 530)
        Me.ButtonDemarrer.Name = "ButtonDemarrer"
        Me.ButtonDemarrer.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDemarrer.TabIndex = 4
        Me.ButtonDemarrer.Text = "&Démarrer"
        Me.ButtonDemarrer.UseVisualStyleBackColor = True
        '
        'ListViewAllChannel
        '
        Me.ListViewAllChannel.AllowDrop = True
        Me.ListViewAllChannel.FullRowSelect = True
        Me.ListViewAllChannel.Location = New System.Drawing.Point(71, 149)
        Me.ListViewAllChannel.Name = "ListViewAllChannel"
        Me.ListViewAllChannel.Size = New System.Drawing.Size(190, 373)
        Me.ListViewAllChannel.TabIndex = 5
        Me.ListViewAllChannel.UseCompatibleStateImageBehavior = False
        Me.ListViewAllChannel.View = System.Windows.Forms.View.Details
        '
        'ButtonAnnuler
        '
        Me.ButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonAnnuler.Location = New System.Drawing.Point(428, 530)
        Me.ButtonAnnuler.Name = "ButtonAnnuler"
        Me.ButtonAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAnnuler.TabIndex = 6
        Me.ButtonAnnuler.Text = "&Annuler"
        Me.ButtonAnnuler.UseVisualStyleBackColor = True
        '
        'OpenFileDialogXml
        '
        Me.OpenFileDialogXml.Filter = "Fichiers xmltv|*.xml; *.zip;*.gz|Tous les fichiers|*.*"
        Me.OpenFileDialogXml.SupportMultiDottedExtensions = True
        '
        'ButtonOpenfile
        '
        Me.ButtonOpenfile.Location = New System.Drawing.Point(477, 84)
        Me.ButtonOpenfile.Name = "ButtonOpenfile"
        Me.ButtonOpenfile.Size = New System.Drawing.Size(40, 20)
        Me.ButtonOpenfile.TabIndex = 7
        Me.ButtonOpenfile.Text = "....."
        Me.ButtonOpenfile.UseVisualStyleBackColor = True
        '
        'TextBoxPathXml
        '
        Me.TextBoxPathXml.Location = New System.Drawing.Point(72, 84)
        Me.TextBoxPathXml.Name = "TextBoxPathXml"
        Me.TextBoxPathXml.Size = New System.Drawing.Size(399, 20)
        Me.TextBoxPathXml.TabIndex = 8
        '
        'RadioButtonXmlPath
        '
        Me.RadioButtonXmlPath.AutoSize = True
        Me.RadioButtonXmlPath.Location = New System.Drawing.Point(71, 66)
        Me.RadioButtonXmlPath.Name = "RadioButtonXmlPath"
        Me.RadioButtonXmlPath.Size = New System.Drawing.Size(95, 17)
        Me.RadioButtonXmlPath.TabIndex = 9
        Me.RadioButtonXmlPath.Text = "Fichier XMLTV"
        Me.RadioButtonXmlPath.UseVisualStyleBackColor = True
        '
        'RadioButtonDownload
        '
        Me.RadioButtonDownload.AutoSize = True
        Me.RadioButtonDownload.Checked = True
        Me.RadioButtonDownload.Location = New System.Drawing.Point(71, 17)
        Me.RadioButtonDownload.Name = "RadioButtonDownload"
        Me.RadioButtonDownload.Size = New System.Drawing.Size(82, 17)
        Me.RadioButtonDownload.TabIndex = 10
        Me.RadioButtonDownload.TabStop = True
        Me.RadioButtonDownload.Text = "Télécharger"
        Me.RadioButtonDownload.UseVisualStyleBackColor = True
        '
        'ListXMLTVFRChoisie
        '
        Me.ListXMLTVFRChoisie.AllowDrop = True
        Me.ListXMLTVFRChoisie.FullRowSelect = True
        Me.ListXMLTVFRChoisie.Location = New System.Drawing.Point(327, 149)
        Me.ListXMLTVFRChoisie.Name = "ListXMLTVFRChoisie"
        Me.ListXMLTVFRChoisie.Size = New System.Drawing.Size(190, 373)
        Me.ListXMLTVFRChoisie.TabIndex = 11
        Me.ListXMLTVFRChoisie.UseCompatibleStateImageBehavior = False
        Me.ListXMLTVFRChoisie.View = System.Windows.Forms.View.Details
        '
        'ButtonTout
        '
        Me.ButtonTout.Enabled = False
        Me.ButtonTout.Location = New System.Drawing.Point(71, 530)
        Me.ButtonTout.Name = "ButtonTout"
        Me.ButtonTout.Size = New System.Drawing.Size(100, 23)
        Me.ButtonTout.TabIndex = 12
        Me.ButtonTout.Text = "Tout sélectionner"
        Me.ButtonTout.UseVisualStyleBackColor = True
        '
        'ButtonAppliquer
        '
        Me.ButtonAppliquer.Location = New System.Drawing.Point(272, 530)
        Me.ButtonAppliquer.Name = "ButtonAppliquer"
        Me.ButtonAppliquer.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAppliquer.TabIndex = 13
        Me.ButtonAppliquer.Text = "&Appliquer"
        Me.ButtonAppliquer.UseVisualStyleBackColor = True
        Me.ButtonAppliquer.Visible = False
        '
        'ProgressBarMiseaJ
        '
        Me.ProgressBarMiseaJ.Location = New System.Drawing.Point(71, 563)
        Me.ProgressBarMiseaJ.Name = "ProgressBarMiseaJ"
        Me.ProgressBarMiseaJ.Size = New System.Drawing.Size(446, 15)
        Me.ProgressBarMiseaJ.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBarMiseaJ.TabIndex = 15
        '
        'URLComboBox
        '
        Me.URLComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.URLComboBox.FormattingEnabled = True
        Me.URLComboBox.Location = New System.Drawing.Point(72, 36)
        Me.URLComboBox.MaxDropDownItems = 14
        Me.URLComboBox.Name = "URLComboBox"
        Me.URLComboBox.Size = New System.Drawing.Size(343, 21)
        Me.URLComboBox.TabIndex = 16
        '
        'ButtonSuppr
        '
        Me.ButtonSuppr.Enabled = False
        Me.ButtonSuppr.Location = New System.Drawing.Point(174, 530)
        Me.ButtonSuppr.Name = "ButtonSuppr"
        Me.ButtonSuppr.Size = New System.Drawing.Size(87, 23)
        Me.ButtonSuppr.TabIndex = 19
        Me.ButtonSuppr.Text = "Tout supprimer"
        Me.ButtonSuppr.UseVisualStyleBackColor = True
        '
        'ButtonEdit
        '
        Me.ButtonEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonEdit.Location = New System.Drawing.Point(421, 36)
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.Size = New System.Drawing.Size(64, 23)
        Me.ButtonEdit.TabIndex = 23
        Me.ButtonEdit.Text = "Editer"
        Me.ButtonEdit.UseVisualStyleBackColor = True
        '
        'ButtonHelpMiseaJour
        '
        Me.ButtonHelpMiseaJour.Image = Global.ZGuideTV.My.Resources.Resources.Help
        Me.ButtonHelpMiseaJour.Location = New System.Drawing.Point(491, 36)
        Me.ButtonHelpMiseaJour.Name = "ButtonHelpMiseaJour"
        Me.ButtonHelpMiseaJour.Size = New System.Drawing.Size(26, 23)
        Me.ButtonHelpMiseaJour.TabIndex = 24
        Me.ButtonHelpMiseaJour.UseVisualStyleBackColor = True
        '
        'CheckBoxAutoRestartManualUpdate
        '
        Me.CheckBoxAutoRestartManualUpdate.AutoSize = True
        Me.CheckBoxAutoRestartManualUpdate.Enabled = False
        Me.CheckBoxAutoRestartManualUpdate.Location = New System.Drawing.Point(71, 589)
        Me.CheckBoxAutoRestartManualUpdate.Name = "CheckBoxAutoRestartManualUpdate"
        Me.CheckBoxAutoRestartManualUpdate.Size = New System.Drawing.Size(268, 17)
        Me.CheckBoxAutoRestartManualUpdate.TabIndex = 25
        Me.CheckBoxAutoRestartManualUpdate.Text = "Redémarrer automatiquement après une mise à jour"
        Me.CheckBoxAutoRestartManualUpdate.UseVisualStyleBackColor = True
        '
        'txbRecherche
        '
        Me.txbRecherche.BackColor = System.Drawing.Color.White
        Me.txbRecherche.Location = New System.Drawing.Point(94, 116)
        Me.txbRecherche.Name = "txbRecherche"
        Me.txbRecherche.Size = New System.Drawing.Size(145, 20)
        Me.txbRecherche.TabIndex = 26
        '
        'btReset
        '
        Me.btReset.FlatAppearance.BorderSize = 0
        Me.btReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btReset.Image = Global.ZGuideTV.My.Resources.Resources.cross
        Me.btReset.Location = New System.Drawing.Point(245, 117)
        Me.btReset.Name = "btReset"
        Me.btReset.Size = New System.Drawing.Size(16, 16)
        Me.btReset.TabIndex = 27
        Me.btReset.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Image = Global.ZGuideTV.My.Resources.Resources.ArrowNormal
        Me.Label1.Location = New System.Drawing.Point(71, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 19)
        Me.Label1.TabIndex = 28
        '
        'Miseajour
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(589, 627)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btReset)
        Me.Controls.Add(Me.txbRecherche)
        Me.Controls.Add(Me.CheckBoxAutoRestartManualUpdate)
        Me.Controls.Add(Me.ButtonHelpMiseaJour)
        Me.Controls.Add(Me.ButtonEdit)
        Me.Controls.Add(Me.ButtonSuppr)
        Me.Controls.Add(Me.URLComboBox)
        Me.Controls.Add(Me.ProgressBarMiseaJ)
        Me.Controls.Add(Me.ButtonAppliquer)
        Me.Controls.Add(Me.ButtonTout)
        Me.Controls.Add(Me.ListXMLTVFRChoisie)
        Me.Controls.Add(Me.RadioButtonDownload)
        Me.Controls.Add(Me.RadioButtonXmlPath)
        Me.Controls.Add(Me.TextBoxPathXml)
        Me.Controls.Add(Me.ButtonOpenfile)
        Me.Controls.Add(Me.ButtonAnnuler)
        Me.Controls.Add(Me.ListViewAllChannel)
        Me.Controls.Add(Me.ButtonDemarrer)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Miseajour"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Mise à jour de la base de données"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonDemarrer As System.Windows.Forms.Button
    Friend WithEvents ListViewAllChannel As System.Windows.Forms.ListView
    Friend WithEvents ButtonAnnuler As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialogXml As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonOpenfile As System.Windows.Forms.Button
    Friend WithEvents TextBoxPathXml As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonXmlPath As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDownload As System.Windows.Forms.RadioButton
    Friend WithEvents ListXMLTVFRChoisie As System.Windows.Forms.ListView
    Friend WithEvents ButtonTout As System.Windows.Forms.Button
    Friend WithEvents ButtonAppliquer As System.Windows.Forms.Button
    Friend WithEvents ProgressBarMiseaJ As System.Windows.Forms.ProgressBar
    Friend WithEvents URLComboBox As System.Windows.Forms.ComboBox

    Private Sub RadioButtonXmlPath_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonXmlPath.Click
        If RadioButtonXmlPath.Checked Then
            TextBoxPathXml.Enabled = True
            ButtonOpenfile.Enabled = True

            URLComboBox.Enabled = False
            'ButtonMAJ_List.Enabled = False
        Else
            TextBoxPathXml.Enabled = False
            ButtonOpenfile.Enabled = False

            URLComboBox.Enabled = True
            'ButtonMAJ_List.Enabled = True
        End If
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonDownload.Click
        If RadioButtonXmlPath.Checked Then
            TextBoxPathXml.Enabled = True
            ButtonOpenfile.Enabled = True

            URLComboBox.Enabled = False
            'ButtonMAJ_List.Enabled = False
        Else
            TextBoxPathXml.Enabled = False
            ButtonOpenfile.Enabled = False

            URLComboBox.Enabled = True
            'ButtonMAJ_List.Enabled = True
        End If
    End Sub
    Friend WithEvents ButtonSuppr As System.Windows.Forms.Button
    Friend WithEvents ButtonEdit As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorkerParseXML As System.ComponentModel.BackgroundWorker
    Friend WithEvents ButtonHelpMiseaJour As System.Windows.Forms.Button
    Friend WithEvents CheckBoxAutoRestartManualUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents txbRecherche As System.Windows.Forms.TextBox
    Friend WithEvents btReset As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class


