<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListRecKTV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListRecKTV))
        Me.CboChannel = New System.Windows.Forms.ComboBox()
        Me.DateDebut = New System.Windows.Forms.DateTimePicker()
        Me.DateFin = New System.Windows.Forms.DateTimePicker()
        Me.RecordName = New System.Windows.Forms.TextBox()
        Me.CmdModify = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.GroupBoxDetails = New System.Windows.Forms.GroupBox()
        Me.LabelNom = New System.Windows.Forms.Label()
        Me.LabelProfile = New System.Windows.Forms.Label()
        Me.LabelFin = New System.Windows.Forms.Label()
        Me.LabelDebut = New System.Windows.Forms.Label()
        Me.LabelChaine = New System.Windows.Forms.Label()
        Me.GroupBoxRepete = New System.Windows.Forms.GroupBox()
        Me.CheckBoxDimanche = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSamedi = New System.Windows.Forms.CheckBox()
        Me.CheckBoxVendredi = New System.Windows.Forms.CheckBox()
        Me.CheckBoxJeudi = New System.Windows.Forms.CheckBox()
        Me.CheckBoxMercredi = New System.Windows.Forms.CheckBox()
        Me.CheckBoxMardi = New System.Windows.Forms.CheckBox()
        Me.CheckBoxLundi = New System.Windows.Forms.CheckBox()
        Me.RadioButtonMensuel = New System.Windows.Forms.RadioButton()
        Me.RadioButtonHebdo = New System.Windows.Forms.RadioButton()
        Me.RadioButtonJournalier = New System.Windows.Forms.RadioButton()
        Me.RadioButtonUnique = New System.Windows.Forms.RadioButton()
        Me.CboProfile = New System.Windows.Forms.ComboBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.GroupBoxDetails.SuspendLayout()
        Me.GroupBoxRepete.SuspendLayout()
        Me.SuspendLayout()
        '
        'CboChannel
        '
        Me.CboChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboChannel.FormattingEnabled = True
        Me.CboChannel.Location = New System.Drawing.Point(96, 32)
        Me.CboChannel.Name = "CboChannel"
        Me.CboChannel.Size = New System.Drawing.Size(192, 21)
        Me.CboChannel.TabIndex = 1
        '
        'DateDebut
        '
        Me.DateDebut.CustomFormat = "HH:mm  dddd d MMM yyyy"
        Me.DateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateDebut.Location = New System.Drawing.Point(96, 64)
        Me.DateDebut.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.DateDebut.Name = "DateDebut"
        Me.DateDebut.ShowUpDown = True
        Me.DateDebut.Size = New System.Drawing.Size(192, 20)
        Me.DateDebut.TabIndex = 2
        '
        'DateFin
        '
        Me.DateFin.CustomFormat = "HH:mm  dddd d MMM yyyy"
        Me.DateFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFin.Location = New System.Drawing.Point(96, 96)
        Me.DateFin.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.DateFin.Name = "DateFin"
        Me.DateFin.ShowUpDown = True
        Me.DateFin.Size = New System.Drawing.Size(192, 20)
        Me.DateFin.TabIndex = 3
        '
        'RecordName
        '
        Me.RecordName.Location = New System.Drawing.Point(96, 160)
        Me.RecordName.Name = "RecordName"
        Me.RecordName.Size = New System.Drawing.Size(192, 20)
        Me.RecordName.TabIndex = 4
        '
        'CmdModify
        '
        Me.CmdModify.Location = New System.Drawing.Point(312, 32)
        Me.CmdModify.Name = "CmdModify"
        Me.CmdModify.Size = New System.Drawing.Size(80, 24)
        Me.CmdModify.TabIndex = 5
        Me.CmdModify.Text = "Modifier"
        Me.CmdModify.UseVisualStyleBackColor = True
        '
        'CmdDelete
        '
        Me.CmdDelete.Location = New System.Drawing.Point(312, 64)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(80, 24)
        Me.CmdDelete.TabIndex = 6
        Me.CmdDelete.Text = "Effacer"
        Me.CmdDelete.UseVisualStyleBackColor = True
        '
        'CmdAdd
        '
        Me.CmdAdd.Location = New System.Drawing.Point(312, 96)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(80, 24)
        Me.CmdAdd.TabIndex = 7
        Me.CmdAdd.Text = "Ajouter"
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.Location = New System.Drawing.Point(312, 128)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.CmdCancel.TabIndex = 8
        Me.CmdCancel.Text = "Fermer"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBoxDetails
        '
        Me.GroupBoxDetails.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBoxDetails.Controls.Add(Me.LabelNom)
        Me.GroupBoxDetails.Controls.Add(Me.LabelProfile)
        Me.GroupBoxDetails.Controls.Add(Me.LabelFin)
        Me.GroupBoxDetails.Controls.Add(Me.LabelDebut)
        Me.GroupBoxDetails.Controls.Add(Me.LabelChaine)
        Me.GroupBoxDetails.Controls.Add(Me.GroupBoxRepete)
        Me.GroupBoxDetails.Controls.Add(Me.CboProfile)
        Me.GroupBoxDetails.Controls.Add(Me.CmdModify)
        Me.GroupBoxDetails.Controls.Add(Me.RecordName)
        Me.GroupBoxDetails.Controls.Add(Me.CmdCancel)
        Me.GroupBoxDetails.Controls.Add(Me.DateFin)
        Me.GroupBoxDetails.Controls.Add(Me.CmdDelete)
        Me.GroupBoxDetails.Controls.Add(Me.DateDebut)
        Me.GroupBoxDetails.Controls.Add(Me.CmdAdd)
        Me.GroupBoxDetails.Controls.Add(Me.CboChannel)
        Me.GroupBoxDetails.Location = New System.Drawing.Point(0, 193)
        Me.GroupBoxDetails.Name = "GroupBoxDetails"
        Me.GroupBoxDetails.Size = New System.Drawing.Size(408, 304)
        Me.GroupBoxDetails.TabIndex = 9
        Me.GroupBoxDetails.TabStop = False
        Me.GroupBoxDetails.Text = "Détails de l'enregistrement"
        '
        'LabelNom
        '
        Me.LabelNom.AutoSize = True
        Me.LabelNom.Location = New System.Drawing.Point(24, 168)
        Me.LabelNom.Name = "LabelNom"
        Me.LabelNom.Size = New System.Drawing.Size(29, 13)
        Me.LabelNom.TabIndex = 16
        Me.LabelNom.Text = "Nom"
        '
        'LabelProfile
        '
        Me.LabelProfile.AutoSize = True
        Me.LabelProfile.Location = New System.Drawing.Point(24, 136)
        Me.LabelProfile.Name = "LabelProfile"
        Me.LabelProfile.Size = New System.Drawing.Size(36, 13)
        Me.LabelProfile.TabIndex = 15
        Me.LabelProfile.Text = "Profile"
        '
        'LabelFin
        '
        Me.LabelFin.AutoSize = True
        Me.LabelFin.Location = New System.Drawing.Point(24, 104)
        Me.LabelFin.Name = "LabelFin"
        Me.LabelFin.Size = New System.Drawing.Size(21, 13)
        Me.LabelFin.TabIndex = 14
        Me.LabelFin.Text = "Fin"
        '
        'LabelDebut
        '
        Me.LabelDebut.AutoSize = True
        Me.LabelDebut.Location = New System.Drawing.Point(24, 72)
        Me.LabelDebut.Name = "LabelDebut"
        Me.LabelDebut.Size = New System.Drawing.Size(36, 13)
        Me.LabelDebut.TabIndex = 13
        Me.LabelDebut.Text = "Début"
        '
        'LabelChaine
        '
        Me.LabelChaine.AutoSize = True
        Me.LabelChaine.Location = New System.Drawing.Point(24, 32)
        Me.LabelChaine.Name = "LabelChaine"
        Me.LabelChaine.Size = New System.Drawing.Size(42, 13)
        Me.LabelChaine.TabIndex = 12
        Me.LabelChaine.Text = "Chaîne"
        '
        'GroupBoxRepete
        '
        Me.GroupBoxRepete.Controls.Add(Me.CheckBoxDimanche)
        Me.GroupBoxRepete.Controls.Add(Me.CheckBoxSamedi)
        Me.GroupBoxRepete.Controls.Add(Me.CheckBoxVendredi)
        Me.GroupBoxRepete.Controls.Add(Me.CheckBoxJeudi)
        Me.GroupBoxRepete.Controls.Add(Me.CheckBoxMercredi)
        Me.GroupBoxRepete.Controls.Add(Me.CheckBoxMardi)
        Me.GroupBoxRepete.Controls.Add(Me.CheckBoxLundi)
        Me.GroupBoxRepete.Controls.Add(Me.RadioButtonMensuel)
        Me.GroupBoxRepete.Controls.Add(Me.RadioButtonHebdo)
        Me.GroupBoxRepete.Controls.Add(Me.RadioButtonJournalier)
        Me.GroupBoxRepete.Controls.Add(Me.RadioButtonUnique)
        Me.GroupBoxRepete.Location = New System.Drawing.Point(19, 200)
        Me.GroupBoxRepete.Name = "GroupBoxRepete"
        Me.GroupBoxRepete.Size = New System.Drawing.Size(368, 96)
        Me.GroupBoxRepete.TabIndex = 11
        Me.GroupBoxRepete.TabStop = False
        Me.GroupBoxRepete.Text = "Répétition"
        '
        'CheckBoxDimanche
        '
        Me.CheckBoxDimanche.AutoSize = True
        Me.CheckBoxDimanche.Location = New System.Drawing.Point(176, 72)
        Me.CheckBoxDimanche.Name = "CheckBoxDimanche"
        Me.CheckBoxDimanche.Size = New System.Drawing.Size(74, 17)
        Me.CheckBoxDimanche.TabIndex = 20
        Me.CheckBoxDimanche.Text = "Dimanche"
        Me.CheckBoxDimanche.UseVisualStyleBackColor = True
        '
        'CheckBoxSamedi
        '
        Me.CheckBoxSamedi.AutoSize = True
        Me.CheckBoxSamedi.Location = New System.Drawing.Point(88, 72)
        Me.CheckBoxSamedi.Name = "CheckBoxSamedi"
        Me.CheckBoxSamedi.Size = New System.Drawing.Size(61, 17)
        Me.CheckBoxSamedi.TabIndex = 19
        Me.CheckBoxSamedi.Text = "Samedi"
        Me.CheckBoxSamedi.UseVisualStyleBackColor = True
        '
        'CheckBoxVendredi
        '
        Me.CheckBoxVendredi.AutoSize = True
        Me.CheckBoxVendredi.Location = New System.Drawing.Point(8, 72)
        Me.CheckBoxVendredi.Name = "CheckBoxVendredi"
        Me.CheckBoxVendredi.Size = New System.Drawing.Size(68, 17)
        Me.CheckBoxVendredi.TabIndex = 18
        Me.CheckBoxVendredi.Text = "Vendredi"
        Me.CheckBoxVendredi.UseVisualStyleBackColor = True
        '
        'CheckBoxJeudi
        '
        Me.CheckBoxJeudi.AutoSize = True
        Me.CheckBoxJeudi.Location = New System.Drawing.Point(280, 48)
        Me.CheckBoxJeudi.Name = "CheckBoxJeudi"
        Me.CheckBoxJeudi.Size = New System.Drawing.Size(51, 17)
        Me.CheckBoxJeudi.TabIndex = 17
        Me.CheckBoxJeudi.Text = "Jeudi"
        Me.CheckBoxJeudi.UseVisualStyleBackColor = True
        '
        'CheckBoxMercredi
        '
        Me.CheckBoxMercredi.AutoSize = True
        Me.CheckBoxMercredi.Location = New System.Drawing.Point(176, 48)
        Me.CheckBoxMercredi.Name = "CheckBoxMercredi"
        Me.CheckBoxMercredi.Size = New System.Drawing.Size(67, 17)
        Me.CheckBoxMercredi.TabIndex = 16
        Me.CheckBoxMercredi.Text = "Mercredi"
        Me.CheckBoxMercredi.UseVisualStyleBackColor = True
        '
        'CheckBoxMardi
        '
        Me.CheckBoxMardi.AutoSize = True
        Me.CheckBoxMardi.Location = New System.Drawing.Point(88, 48)
        Me.CheckBoxMardi.Name = "CheckBoxMardi"
        Me.CheckBoxMardi.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxMardi.TabIndex = 15
        Me.CheckBoxMardi.Text = "Mardi"
        Me.CheckBoxMardi.UseVisualStyleBackColor = True
        '
        'CheckBoxLundi
        '
        Me.CheckBoxLundi.AutoSize = True
        Me.CheckBoxLundi.Location = New System.Drawing.Point(8, 48)
        Me.CheckBoxLundi.Name = "CheckBoxLundi"
        Me.CheckBoxLundi.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxLundi.TabIndex = 14
        Me.CheckBoxLundi.Text = "Lundi"
        Me.CheckBoxLundi.UseVisualStyleBackColor = True
        '
        'RadioButtonMensuel
        '
        Me.RadioButtonMensuel.AutoSize = True
        Me.RadioButtonMensuel.Location = New System.Drawing.Point(280, 16)
        Me.RadioButtonMensuel.Name = "RadioButtonMensuel"
        Me.RadioButtonMensuel.Size = New System.Drawing.Size(65, 17)
        Me.RadioButtonMensuel.TabIndex = 13
        Me.RadioButtonMensuel.TabStop = True
        Me.RadioButtonMensuel.Text = "Mensuel"
        Me.RadioButtonMensuel.UseVisualStyleBackColor = True
        '
        'RadioButtonHebdo
        '
        Me.RadioButtonHebdo.AutoSize = True
        Me.RadioButtonHebdo.Location = New System.Drawing.Point(176, 16)
        Me.RadioButtonHebdo.Name = "RadioButtonHebdo"
        Me.RadioButtonHebdo.Size = New System.Drawing.Size(94, 17)
        Me.RadioButtonHebdo.TabIndex = 12
        Me.RadioButtonHebdo.TabStop = True
        Me.RadioButtonHebdo.Text = "Hebdomadaire"
        Me.RadioButtonHebdo.UseVisualStyleBackColor = True
        '
        'RadioButtonJournalier
        '
        Me.RadioButtonJournalier.AutoSize = True
        Me.RadioButtonJournalier.Location = New System.Drawing.Point(88, 16)
        Me.RadioButtonJournalier.Name = "RadioButtonJournalier"
        Me.RadioButtonJournalier.Size = New System.Drawing.Size(70, 17)
        Me.RadioButtonJournalier.TabIndex = 11
        Me.RadioButtonJournalier.TabStop = True
        Me.RadioButtonJournalier.Text = "Journalier"
        Me.RadioButtonJournalier.UseVisualStyleBackColor = True
        '
        'RadioButtonUnique
        '
        Me.RadioButtonUnique.AutoSize = True
        Me.RadioButtonUnique.Location = New System.Drawing.Point(8, 16)
        Me.RadioButtonUnique.Name = "RadioButtonUnique"
        Me.RadioButtonUnique.Size = New System.Drawing.Size(59, 17)
        Me.RadioButtonUnique.TabIndex = 10
        Me.RadioButtonUnique.TabStop = True
        Me.RadioButtonUnique.Text = "Unique"
        Me.RadioButtonUnique.UseVisualStyleBackColor = True
        '
        'CboProfile
        '
        Me.CboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProfile.FormattingEnabled = True
        Me.CboProfile.Location = New System.Drawing.Point(96, 128)
        Me.CboProfile.Name = "CboProfile"
        Me.CboProfile.Size = New System.Drawing.Size(192, 21)
        Me.CboProfile.TabIndex = 9
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        Me.ListView1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(408, 192)
        Me.ListView1.TabIndex = 10
        Me.ListView1.TileSize = New System.Drawing.Size(1, 1)
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ListRecKTV
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(408, 497)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBoxDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListRecKTV"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Liste des enregistrements K!TV..."
        Me.GroupBoxDetails.ResumeLayout(False)
        Me.GroupBoxDetails.PerformLayout()
        Me.GroupBoxRepete.ResumeLayout(False)
        Me.GroupBoxRepete.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CboChannel As System.Windows.Forms.ComboBox
    Friend WithEvents DateDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents RecordName As System.Windows.Forms.TextBox
    Friend WithEvents CmdModify As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBoxDetails As System.Windows.Forms.GroupBox
    Friend WithEvents CboProfile As System.Windows.Forms.ComboBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents RadioButtonUnique As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxRepete As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonMensuel As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonHebdo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonJournalier As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxMardi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxLundi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSamedi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxVendredi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxJeudi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxMercredi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDimanche As System.Windows.Forms.CheckBox
    Friend WithEvents LabelNom As System.Windows.Forms.Label
    Friend WithEvents LabelProfile As System.Windows.Forms.Label
    Friend WithEvents LabelFin As System.Windows.Forms.Label
    Friend WithEvents LabelDebut As System.Windows.Forms.Label
    Friend WithEvents LabelChaine As System.Windows.Forms.Label
End Class
