<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChannelView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChannelView))
        Me.dtp_Jour = New System.Windows.Forms.DateTimePicker()
        Me.cbo_Chaine = New System.Windows.Forms.ComboBox()
        Me.ChannelListView = New System.Windows.Forms.ListView()
        Me.Debut = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Categorie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rtb_desc = New System.Windows.Forms.RichTextBox()
        Me.ChannelViewButtonClose = New System.Windows.Forms.Button()
        Me.pb_chaine = New System.Windows.Forms.PictureBox()
        Me.ChannelViewCheckBox24hHours = New System.Windows.Forms.CheckBox()
        Me.ChannelViewLabelOr = New System.Windows.Forms.Label()
        Me.btImprimer = New System.Windows.Forms.Button()
        CType(Me.pb_chaine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp_Jour
        '
        Me.dtp_Jour.Location = New System.Drawing.Point(40, 56)
        Me.dtp_Jour.Name = "dtp_Jour"
        Me.dtp_Jour.Size = New System.Drawing.Size(200, 20)
        Me.dtp_Jour.TabIndex = 0
        '
        'cbo_Chaine
        '
        Me.cbo_Chaine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Chaine.FormattingEnabled = True
        Me.cbo_Chaine.Location = New System.Drawing.Point(255, 55)
        Me.cbo_Chaine.Name = "cbo_Chaine"
        Me.cbo_Chaine.Size = New System.Drawing.Size(200, 21)
        Me.cbo_Chaine.TabIndex = 1
        '
        'ChannelListView
        '
        Me.ChannelListView.AllowColumnReorder = True
        Me.ChannelListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Debut, Me.Fin, Me.Nom, Me.Categorie})
        Me.ChannelListView.FullRowSelect = True
        Me.ChannelListView.GridLines = True
        Me.ChannelListView.Location = New System.Drawing.Point(26, 98)
        Me.ChannelListView.MultiSelect = False
        Me.ChannelListView.Name = "ChannelListView"
        Me.ChannelListView.Size = New System.Drawing.Size(444, 402)
        Me.ChannelListView.TabIndex = 2
        Me.ChannelListView.UseCompatibleStateImageBehavior = False
        Me.ChannelListView.View = System.Windows.Forms.View.Details
        '
        'Debut
        '
        Me.Debut.Text = "Début"
        Me.Debut.Width = 44
        '
        'Fin
        '
        Me.Fin.Text = "Fin"
        Me.Fin.Width = 44
        '
        'Nom
        '
        Me.Nom.Text = "Emission"
        Me.Nom.Width = 237
        '
        'Categorie
        '
        Me.Categorie.Text = "Catégorie"
        Me.Categorie.Width = 97
        '
        'rtb_desc
        '
        Me.rtb_desc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rtb_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtb_desc.Location = New System.Drawing.Point(116, 506)
        Me.rtb_desc.Name = "rtb_desc"
        Me.rtb_desc.ReadOnly = True
        Me.rtb_desc.Size = New System.Drawing.Size(354, 71)
        Me.rtb_desc.TabIndex = 3
        Me.rtb_desc.Text = ""
        '
        'ChannelViewButtonClose
        '
        Me.ChannelViewButtonClose.BackColor = System.Drawing.Color.White
        Me.ChannelViewButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ChannelViewButtonClose.Location = New System.Drawing.Point(395, 587)
        Me.ChannelViewButtonClose.Name = "ChannelViewButtonClose"
        Me.ChannelViewButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ChannelViewButtonClose.TabIndex = 4
        Me.ChannelViewButtonClose.Text = "Fermer"
        Me.ChannelViewButtonClose.UseVisualStyleBackColor = True
        '
        'pb_chaine
        '
        Me.pb_chaine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pb_chaine.Cursor = System.Windows.Forms.Cursors.Default
        Me.pb_chaine.Location = New System.Drawing.Point(26, 506)
        Me.pb_chaine.Name = "pb_chaine"
        Me.pb_chaine.Size = New System.Drawing.Size(73, 71)
        Me.pb_chaine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_chaine.TabIndex = 6
        Me.pb_chaine.TabStop = False
        '
        'ChannelViewCheckBox24hHours
        '
        Me.ChannelViewCheckBox24hHours.AutoSize = True
        Me.ChannelViewCheckBox24hHours.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ChannelViewCheckBox24hHours.Location = New System.Drawing.Point(47, 16)
        Me.ChannelViewCheckBox24hHours.Name = "ChannelViewCheckBox24hHours"
        Me.ChannelViewCheckBox24hHours.Size = New System.Drawing.Size(181, 17)
        Me.ChannelViewCheckBox24hHours.TabIndex = 7
        Me.ChannelViewCheckBox24hHours.Text = "24 heures à partir de maintenant "
        Me.ChannelViewCheckBox24hHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChannelViewCheckBox24hHours.UseVisualStyleBackColor = True
        '
        'ChannelViewLabelOr
        '
        Me.ChannelViewLabelOr.AutoSize = True
        Me.ChannelViewLabelOr.Location = New System.Drawing.Point(113, 36)
        Me.ChannelViewLabelOr.Name = "ChannelViewLabelOr"
        Me.ChannelViewLabelOr.Size = New System.Drawing.Size(43, 13)
        Me.ChannelViewLabelOr.TabIndex = 8
        Me.ChannelViewLabelOr.Text = "<- ou ->"
        '
        'btImprimer
        '
        Me.btImprimer.Location = New System.Drawing.Point(297, 587)
        Me.btImprimer.Name = "btImprimer"
        Me.btImprimer.Size = New System.Drawing.Size(92, 23)
        Me.btImprimer.TabIndex = 9
        Me.btImprimer.Text = "Imprimer la liste"
        Me.btImprimer.UseVisualStyleBackColor = True
        '
        'ChannelView
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CancelButton = Me.ChannelViewButtonClose
        Me.ClientSize = New System.Drawing.Size(498, 617)
        Me.Controls.Add(Me.btImprimer)
        Me.Controls.Add(Me.ChannelViewLabelOr)
        Me.Controls.Add(Me.ChannelViewCheckBox24hHours)
        Me.Controls.Add(Me.dtp_Jour)
        Me.Controls.Add(Me.pb_chaine)
        Me.Controls.Add(Me.ChannelViewButtonClose)
        Me.Controls.Add(Me.rtb_desc)
        Me.Controls.Add(Me.ChannelListView)
        Me.Controls.Add(Me.cbo_Chaine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ChannelView"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Visualisation par chaine"
        CType(Me.pb_chaine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp_Jour As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_Chaine As System.Windows.Forms.ComboBox
    Friend WithEvents ChannelListView As System.Windows.Forms.ListView
    Friend WithEvents Nom As System.Windows.Forms.ColumnHeader
    Friend WithEvents Debut As System.Windows.Forms.ColumnHeader
    Friend WithEvents Fin As System.Windows.Forms.ColumnHeader
    Friend WithEvents rtb_desc As System.Windows.Forms.RichTextBox
    Friend WithEvents Categorie As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChannelViewButtonClose As System.Windows.Forms.Button
    Friend WithEvents pb_chaine As System.Windows.Forms.PictureBox
    Friend WithEvents ChannelViewCheckBox24hHours As System.Windows.Forms.CheckBox
    Friend WithEvents ChannelViewLabelOr As System.Windows.Forms.Label
    Friend WithEvents btImprimer As System.Windows.Forms.Button
End Class
