<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TriAvance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TriAvance))
        Me.TriAvanceLabeltitre = New System.Windows.Forms.CheckBox()
        Me.TriAvanceLabelauteur = New System.Windows.Forms.CheckBox()
        Me.TriAvanceLabelndefini = New System.Windows.Forms.CheckBox()
        Me.Textbox_titre = New System.Windows.Forms.TextBox()
        Me.TriAvanceButtonSearch = New System.Windows.Forms.Button()
        Me.TriAvanceButtonCancel = New System.Windows.Forms.Button()
        Me.TriAvanceGroupBoxCriteres = New System.Windows.Forms.GroupBox()
        Me.TriAvanceCheckBoxBegin = New System.Windows.Forms.CheckBox()
        Me.TriAvanceCheckBoxNow = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TriAvanceListView = New System.Windows.Forms.ListView()
        Me.Chaine = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Emission = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Debut = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Catégorie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pb_chaine = New System.Windows.Forms.PictureBox()
        Me.rtb_desc = New System.Windows.Forms.RichTextBox()
        Me.TriAvanceGroupBoxCriteres.SuspendLayout()
        CType(Me.pb_chaine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TriAvanceLabeltitre
        '
        Me.TriAvanceLabeltitre.AutoSize = True
        Me.TriAvanceLabeltitre.Location = New System.Drawing.Point(39, 26)
        Me.TriAvanceLabeltitre.Name = "TriAvanceLabeltitre"
        Me.TriAvanceLabeltitre.Size = New System.Drawing.Size(107, 17)
        Me.TriAvanceLabeltitre.TabIndex = 4
        Me.TriAvanceLabeltitre.Text = "Titre ou sous titre"
        Me.TriAvanceLabeltitre.UseVisualStyleBackColor = True
        '
        'TriAvanceLabelauteur
        '
        Me.TriAvanceLabelauteur.AutoSize = True
        Me.TriAvanceLabelauteur.Location = New System.Drawing.Point(39, 48)
        Me.TriAvanceLabelauteur.Name = "TriAvanceLabelauteur"
        Me.TriAvanceLabelauteur.Size = New System.Drawing.Size(92, 17)
        Me.TriAvanceLabelauteur.TabIndex = 1
        Me.TriAvanceLabelauteur.Text = "Auteur/acteur"
        Me.TriAvanceLabelauteur.UseVisualStyleBackColor = True
        '
        'TriAvanceLabelndefini
        '
        Me.TriAvanceLabelndefini.AutoSize = True
        Me.TriAvanceLabelndefini.Location = New System.Drawing.Point(39, 71)
        Me.TriAvanceLabelndefini.Name = "TriAvanceLabelndefini"
        Me.TriAvanceLabelndefini.Size = New System.Drawing.Size(60, 17)
        Me.TriAvanceLabelndefini.TabIndex = 2
        Me.TriAvanceLabelndefini.Text = "Indéfini"
        Me.TriAvanceLabelndefini.UseVisualStyleBackColor = True
        '
        'Textbox_titre
        '
        Me.Textbox_titre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Textbox_titre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.Textbox_titre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Textbox_titre.Location = New System.Drawing.Point(245, 70)
        Me.Textbox_titre.Name = "Textbox_titre"
        Me.Textbox_titre.Size = New System.Drawing.Size(152, 20)
        Me.Textbox_titre.TabIndex = 0
        '
        'TriAvanceButtonSearch
        '
        Me.TriAvanceButtonSearch.AutoSize = True
        Me.TriAvanceButtonSearch.Location = New System.Drawing.Point(418, 68)
        Me.TriAvanceButtonSearch.Name = "TriAvanceButtonSearch"
        Me.TriAvanceButtonSearch.Size = New System.Drawing.Size(94, 23)
        Me.TriAvanceButtonSearch.TabIndex = 0
        Me.TriAvanceButtonSearch.Text = "Rechercher"
        Me.TriAvanceButtonSearch.UseVisualStyleBackColor = True
        '
        'TriAvanceButtonCancel
        '
        Me.TriAvanceButtonCancel.AutoSize = True
        Me.TriAvanceButtonCancel.Location = New System.Drawing.Point(560, 556)
        Me.TriAvanceButtonCancel.Name = "TriAvanceButtonCancel"
        Me.TriAvanceButtonCancel.Size = New System.Drawing.Size(94, 23)
        Me.TriAvanceButtonCancel.TabIndex = 2
        Me.TriAvanceButtonCancel.Text = "Annuler"
        Me.TriAvanceButtonCancel.UseVisualStyleBackColor = True
        '
        'TriAvanceGroupBoxCriteres
        '
        Me.TriAvanceGroupBoxCriteres.Controls.Add(Me.TriAvanceCheckBoxBegin)
        Me.TriAvanceGroupBoxCriteres.Controls.Add(Me.TriAvanceCheckBoxNow)
        Me.TriAvanceGroupBoxCriteres.Controls.Add(Me.TriAvanceButtonSearch)
        Me.TriAvanceGroupBoxCriteres.Controls.Add(Me.Textbox_titre)
        Me.TriAvanceGroupBoxCriteres.Controls.Add(Me.TriAvanceLabelndefini)
        Me.TriAvanceGroupBoxCriteres.Controls.Add(Me.TriAvanceLabelauteur)
        Me.TriAvanceGroupBoxCriteres.Controls.Add(Me.TriAvanceLabeltitre)
        Me.TriAvanceGroupBoxCriteres.Location = New System.Drawing.Point(12, 10)
        Me.TriAvanceGroupBoxCriteres.Name = "TriAvanceGroupBoxCriteres"
        Me.TriAvanceGroupBoxCriteres.Size = New System.Drawing.Size(642, 99)
        Me.TriAvanceGroupBoxCriteres.TabIndex = 1
        Me.TriAvanceGroupBoxCriteres.TabStop = False
        Me.TriAvanceGroupBoxCriteres.Text = "Critéres de recherche"
        '
        'TriAvanceCheckBoxBegin
        '
        Me.TriAvanceCheckBoxBegin.AutoSize = True
        Me.TriAvanceCheckBoxBegin.Location = New System.Drawing.Point(245, 48)
        Me.TriAvanceCheckBoxBegin.Name = "TriAvanceCheckBoxBegin"
        Me.TriAvanceCheckBoxBegin.Size = New System.Drawing.Size(191, 17)
        Me.TriAvanceCheckBoxBegin.TabIndex = 19
        Me.TriAvanceCheckBoxBegin.Text = "Commençant par (sinon contenant)"
        Me.TriAvanceCheckBoxBegin.UseVisualStyleBackColor = True
        '
        'TriAvanceCheckBoxNow
        '
        Me.TriAvanceCheckBoxNow.AutoSize = True
        Me.TriAvanceCheckBoxNow.Location = New System.Drawing.Point(245, 26)
        Me.TriAvanceCheckBoxNow.Name = "TriAvanceCheckBoxNow"
        Me.TriAvanceCheckBoxNow.Size = New System.Drawing.Size(129, 17)
        Me.TriAvanceCheckBoxNow.TabIndex = 18
        Me.TriAvanceCheckBoxNow.Text = "A partir de maintenant"
        Me.TriAvanceCheckBoxNow.UseVisualStyleBackColor = True
        '
        'TriAvanceListView
        '
        Me.TriAvanceListView.AllowColumnReorder = True
        Me.TriAvanceListView.AutoArrange = False
        Me.TriAvanceListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Chaine, Me.Emission, Me.Debut, Me.Fin, Me.Catégorie})
        Me.TriAvanceListView.FullRowSelect = True
        Me.TriAvanceListView.GridLines = True
        Me.TriAvanceListView.Location = New System.Drawing.Point(12, 115)
        Me.TriAvanceListView.MultiSelect = False
        Me.TriAvanceListView.Name = "TriAvanceListView"
        Me.TriAvanceListView.Size = New System.Drawing.Size(642, 355)
        Me.TriAvanceListView.TabIndex = 3
        Me.TriAvanceListView.UseCompatibleStateImageBehavior = False
        Me.TriAvanceListView.View = System.Windows.Forms.View.Details
        '
        'Chaine
        '
        Me.Chaine.Text = "Chaine"
        Me.Chaine.Width = 79
        '
        'Emission
        '
        Me.Emission.Text = "Emission"
        Me.Emission.Width = 190
        '
        'Debut
        '
        Me.Debut.Text = "Début"
        Me.Debut.Width = 120
        '
        'Fin
        '
        Me.Fin.Text = "Fin"
        Me.Fin.Width = 120
        '
        'Catégorie
        '
        Me.Catégorie.Text = "Catégorie"
        Me.Catégorie.Width = 110
        '
        'pb_chaine
        '
        Me.pb_chaine.Location = New System.Drawing.Point(19, 479)
        Me.pb_chaine.Name = "pb_chaine"
        Me.pb_chaine.Size = New System.Drawing.Size(73, 71)
        Me.pb_chaine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_chaine.TabIndex = 4
        Me.pb_chaine.TabStop = False
        '
        'rtb_desc
        '
        Me.rtb_desc.Location = New System.Drawing.Point(104, 479)
        Me.rtb_desc.Name = "rtb_desc"
        Me.rtb_desc.Size = New System.Drawing.Size(550, 71)
        Me.rtb_desc.TabIndex = 5
        Me.rtb_desc.Text = ""
        '
        'TriAvance
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(666, 585)
        Me.Controls.Add(Me.rtb_desc)
        Me.Controls.Add(Me.pb_chaine)
        Me.Controls.Add(Me.TriAvanceListView)
        Me.Controls.Add(Me.TriAvanceButtonCancel)
        Me.Controls.Add(Me.TriAvanceGroupBoxCriteres)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TriAvance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Recherche avancée"
        Me.TriAvanceGroupBoxCriteres.ResumeLayout(False)
        Me.TriAvanceGroupBoxCriteres.PerformLayout()
        CType(Me.pb_chaine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TriAvanceLabeltitre As System.Windows.Forms.CheckBox
    Friend WithEvents TriAvanceLabelauteur As System.Windows.Forms.CheckBox
    Friend WithEvents TriAvanceLabelndefini As System.Windows.Forms.CheckBox
    Friend WithEvents Textbox_titre As System.Windows.Forms.TextBox
    Friend WithEvents TriAvanceButtonSearch As System.Windows.Forms.Button
    Friend WithEvents TriAvanceButtonCancel As System.Windows.Forms.Button
    Friend WithEvents TriAvanceGroupBoxCriteres As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TriAvanceListView As System.Windows.Forms.ListView
    Friend WithEvents Chaine As System.Windows.Forms.ColumnHeader
    Friend WithEvents Emission As System.Windows.Forms.ColumnHeader
    Friend WithEvents Debut As System.Windows.Forms.ColumnHeader
    Friend WithEvents Fin As System.Windows.Forms.ColumnHeader
    Friend WithEvents pb_chaine As System.Windows.Forms.PictureBox
    Friend WithEvents rtb_desc As System.Windows.Forms.RichTextBox
    Friend WithEvents TriAvanceCheckBoxNow As System.Windows.Forms.CheckBox
    Friend WithEvents TriAvanceCheckBoxBegin As System.Windows.Forms.CheckBox
    Friend WithEvents Catégorie As System.Windows.Forms.ColumnHeader
End Class
