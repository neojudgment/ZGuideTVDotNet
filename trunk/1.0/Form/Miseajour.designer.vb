Imports System
Imports System.IO

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
        Me.Warning = New System.Windows.Forms.Label()
        Me.ButtonEdit = New System.Windows.Forms.Button()
        Me.BackgroundWorkerParseXML = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'ButtonDemarrer
        '
        Me.ButtonDemarrer.Enabled = False
        Me.ButtonDemarrer.Location = New System.Drawing.Point(338, 523)
        Me.ButtonDemarrer.Name = "ButtonDemarrer"
        Me.ButtonDemarrer.Size = New System.Drawing.Size(64, 23)
        Me.ButtonDemarrer.TabIndex = 4
        Me.ButtonDemarrer.Text = "&Démarrer"
        Me.ButtonDemarrer.UseVisualStyleBackColor = True
        '
        'ListViewAllChannel
        '
        Me.ListViewAllChannel.AllowDrop = True
        Me.ListViewAllChannel.FullRowSelect = True
        Me.ListViewAllChannel.Location = New System.Drawing.Point(71, 142)
        Me.ListViewAllChannel.Name = "ListViewAllChannel"
        Me.ListViewAllChannel.Size = New System.Drawing.Size(190, 373)
        Me.ListViewAllChannel.TabIndex = 5
        Me.ListViewAllChannel.UseCompatibleStateImageBehavior = False
        Me.ListViewAllChannel.View = System.Windows.Forms.View.Details
        '
        'ButtonAnnuler
        '
        Me.ButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.ButtonAnnuler.Location = New System.Drawing.Point(408, 523)
        Me.ButtonAnnuler.Name = "ButtonAnnuler"
        Me.ButtonAnnuler.Size = New System.Drawing.Size(64, 23)
        Me.ButtonAnnuler.TabIndex = 6
        Me.ButtonAnnuler.Text = "&Annuler"
        Me.ButtonAnnuler.UseVisualStyleBackColor = True
        '
        'OpenFileDialogXml
        '
        Me.OpenFileDialogXml.Filter = "Fichiers xmltv|*.7z; *.rar;*.xml; *.zip|Tous les fichiers|*.*"
        Me.OpenFileDialogXml.SupportMultiDottedExtensions = True
        '
        'ButtonOpenfile
        '
        Me.ButtonOpenfile.Location = New System.Drawing.Point(453, 110)
        Me.ButtonOpenfile.Name = "ButtonOpenfile"
        Me.ButtonOpenfile.Size = New System.Drawing.Size(40, 20)
        Me.ButtonOpenfile.TabIndex = 7
        Me.ButtonOpenfile.Text = "....."
        Me.ButtonOpenfile.UseVisualStyleBackColor = True
        '
        'TextBoxPathXml
        '
        Me.TextBoxPathXml.Location = New System.Drawing.Point(72, 110)
        Me.TextBoxPathXml.Name = "TextBoxPathXml"
        Me.TextBoxPathXml.Size = New System.Drawing.Size(375, 20)
        Me.TextBoxPathXml.TabIndex = 8
        '
        'RadioButtonXmlPath
        '
        Me.RadioButtonXmlPath.AutoSize = True
        Me.RadioButtonXmlPath.Location = New System.Drawing.Point(71, 92)
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
        Me.RadioButtonDownload.Location = New System.Drawing.Point(71, 43)
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
        Me.ListXMLTVFRChoisie.Location = New System.Drawing.Point(327, 142)
        Me.ListXMLTVFRChoisie.Name = "ListXMLTVFRChoisie"
        Me.ListXMLTVFRChoisie.Size = New System.Drawing.Size(190, 373)
        Me.ListXMLTVFRChoisie.TabIndex = 11
        Me.ListXMLTVFRChoisie.UseCompatibleStateImageBehavior = False
        Me.ListXMLTVFRChoisie.View = System.Windows.Forms.View.Details
        '
        'ButtonTout
        '
        Me.ButtonTout.Enabled = False
        Me.ButtonTout.Location = New System.Drawing.Point(58, 523)
        Me.ButtonTout.Name = "ButtonTout"
        Me.ButtonTout.Size = New System.Drawing.Size(104, 23)
        Me.ButtonTout.TabIndex = 12
        Me.ButtonTout.Text = "Tout sélectionner"
        Me.ButtonTout.UseVisualStyleBackColor = True
        '
        'ButtonAppliquer
        '
        Me.ButtonAppliquer.Location = New System.Drawing.Point(268, 523)
        Me.ButtonAppliquer.Name = "ButtonAppliquer"
        Me.ButtonAppliquer.Size = New System.Drawing.Size(64, 23)
        Me.ButtonAppliquer.TabIndex = 13
        Me.ButtonAppliquer.Text = "&Appliquer"
        Me.ButtonAppliquer.UseVisualStyleBackColor = True
        Me.ButtonAppliquer.Visible = False
        '
        'ProgressBarMiseaJ
        '
        Me.ProgressBarMiseaJ.Location = New System.Drawing.Point(71, 554)
        Me.ProgressBarMiseaJ.Name = "ProgressBarMiseaJ"
        Me.ProgressBarMiseaJ.Size = New System.Drawing.Size(446, 15)
        Me.ProgressBarMiseaJ.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBarMiseaJ.TabIndex = 15
        '
        'URLComboBox
        '
        Me.URLComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.URLComboBox.FormattingEnabled = True
        Me.URLComboBox.Location = New System.Drawing.Point(72, 62)
        Me.URLComboBox.MaxDropDownItems = 14
        Me.URLComboBox.Name = "URLComboBox"
        Me.URLComboBox.Size = New System.Drawing.Size(375, 21)
        Me.URLComboBox.TabIndex = 16
        '
        'ButtonSuppr
        '
        Me.ButtonSuppr.Enabled = False
        Me.ButtonSuppr.Location = New System.Drawing.Point(165, 523)
        Me.ButtonSuppr.Name = "ButtonSuppr"
        Me.ButtonSuppr.Size = New System.Drawing.Size(104, 23)
        Me.ButtonSuppr.TabIndex = 19
        Me.ButtonSuppr.Text = "Tout supprimer"
        Me.ButtonSuppr.UseVisualStyleBackColor = True
        '
        'Warning
        '
        Me.Warning.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Warning.AutoSize = True
        Me.Warning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Warning.ForeColor = System.Drawing.Color.Red
        Me.Warning.Location = New System.Drawing.Point(264, 22)
        Me.Warning.Name = "Warning"
        Me.Warning.Size = New System.Drawing.Size(45, 13)
        Me.Warning.TabIndex = 22
        Me.Warning.Text = "Label2"
        '
        'ButtonEdit
        '
        Me.ButtonEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonEdit.Location = New System.Drawing.Point(453, 61)
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.Size = New System.Drawing.Size(64, 23)
        Me.ButtonEdit.TabIndex = 23
        Me.ButtonEdit.Text = "Editer"
        Me.ButtonEdit.UseVisualStyleBackColor = True
        '
        'Miseajour
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(589, 585)
        Me.Controls.Add(Me.ButtonEdit)
        Me.Controls.Add(Me.Warning)
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
    Friend WithEvents Warning As System.Windows.Forms.Label
    Friend WithEvents ButtonEdit As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorkerParseXML As System.ComponentModel.BackgroundWorker
End Class


