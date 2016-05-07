<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmissionView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtp_Jour = New System.Windows.Forms.DateTimePicker()
        Me.cboHeure = New System.Windows.Forms.ComboBox()
        Me.cboMinutes = New System.Windows.Forms.ComboBox()
        Me.pb_chaine = New System.Windows.Forms.PictureBox()
        Me.ChannelViewButtonClose = New System.Windows.Forms.Button()
        Me.rtb_desc = New System.Windows.Forms.RichTextBox()
        Me.EmissionListView = New System.Windows.Forms.ListView()
        Me.Chaines = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Debut = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Categorie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btImprimer = New System.Windows.Forms.Button()
        CType(Me.pb_chaine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp_Jour
        '
        Me.dtp_Jour.Location = New System.Drawing.Point(12, 12)
        Me.dtp_Jour.Name = "dtp_Jour"
        Me.dtp_Jour.Size = New System.Drawing.Size(200, 20)
        Me.dtp_Jour.TabIndex = 1
        '
        'cboHeure
        '
        Me.cboHeure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHeure.FormattingEnabled = True
        Me.cboHeure.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboHeure.Location = New System.Drawing.Point(219, 12)
        Me.cboHeure.Name = "cboHeure"
        Me.cboHeure.Size = New System.Drawing.Size(42, 21)
        Me.cboHeure.TabIndex = 2
        '
        'cboMinutes
        '
        Me.cboMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMinutes.FormattingEnabled = True
        Me.cboMinutes.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cboMinutes.Location = New System.Drawing.Point(284, 12)
        Me.cboMinutes.Name = "cboMinutes"
        Me.cboMinutes.Size = New System.Drawing.Size(43, 21)
        Me.cboMinutes.TabIndex = 3
        '
        'pb_chaine
        '
        Me.pb_chaine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pb_chaine.Cursor = System.Windows.Forms.Cursors.Default
        Me.pb_chaine.Location = New System.Drawing.Point(12, 464)
        Me.pb_chaine.Name = "pb_chaine"
        Me.pb_chaine.Size = New System.Drawing.Size(73, 71)
        Me.pb_chaine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_chaine.TabIndex = 9
        Me.pb_chaine.TabStop = False
        '
        'ChannelViewButtonClose
        '
        Me.ChannelViewButtonClose.BackColor = System.Drawing.Color.White
        Me.ChannelViewButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ChannelViewButtonClose.Location = New System.Drawing.Point(444, 542)
        Me.ChannelViewButtonClose.Name = "ChannelViewButtonClose"
        Me.ChannelViewButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ChannelViewButtonClose.TabIndex = 8
        Me.ChannelViewButtonClose.Text = "Fermer"
        Me.ChannelViewButtonClose.UseVisualStyleBackColor = True
        '
        'rtb_desc
        '
        Me.rtb_desc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rtb_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtb_desc.Location = New System.Drawing.Point(102, 464)
        Me.rtb_desc.Name = "rtb_desc"
        Me.rtb_desc.ReadOnly = True
        Me.rtb_desc.Size = New System.Drawing.Size(417, 71)
        Me.rtb_desc.TabIndex = 7
        Me.rtb_desc.Text = ""
        '
        'EmissionListView
        '
        Me.EmissionListView.AllowColumnReorder = True
        Me.EmissionListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Chaines, Me.Debut, Me.Fin, Me.Nom, Me.Categorie})
        Me.EmissionListView.FullRowSelect = True
        Me.EmissionListView.GridLines = True
        Me.EmissionListView.Location = New System.Drawing.Point(12, 38)
        Me.EmissionListView.MultiSelect = False
        Me.EmissionListView.Name = "EmissionListView"
        Me.EmissionListView.Size = New System.Drawing.Size(507, 402)
        Me.EmissionListView.TabIndex = 10
        Me.EmissionListView.UseCompatibleStateImageBehavior = False
        Me.EmissionListView.View = System.Windows.Forms.View.Details
        '
        'Chaines
        '
        Me.Chaines.Text = "Chaines"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(263, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "H"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(333, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "M"
        '
        'btImprimer
        '
        Me.btImprimer.BackColor = System.Drawing.Color.White
        Me.btImprimer.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btImprimer.Location = New System.Drawing.Point(350, 542)
        Me.btImprimer.Name = "btImprimer"
        Me.btImprimer.Size = New System.Drawing.Size(88, 23)
        Me.btImprimer.TabIndex = 13
        Me.btImprimer.Text = "Imprimer la liste"
        Me.btImprimer.UseVisualStyleBackColor = True
        '
        'EmissionView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(532, 577)
        Me.Controls.Add(Me.btImprimer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EmissionListView)
        Me.Controls.Add(Me.pb_chaine)
        Me.Controls.Add(Me.ChannelViewButtonClose)
        Me.Controls.Add(Me.rtb_desc)
        Me.Controls.Add(Me.cboMinutes)
        Me.Controls.Add(Me.cboHeure)
        Me.Controls.Add(Me.dtp_Jour)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EmissionView"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ZGuideTV.NET - Visualisation par heure"
        CType(Me.pb_chaine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp_Jour As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboHeure As System.Windows.Forms.ComboBox
    Friend WithEvents cboMinutes As System.Windows.Forms.ComboBox
    Friend WithEvents pb_chaine As System.Windows.Forms.PictureBox
    Friend WithEvents ChannelViewButtonClose As System.Windows.Forms.Button
    Friend WithEvents rtb_desc As System.Windows.Forms.RichTextBox
    Friend WithEvents EmissionListView As System.Windows.Forms.ListView
    Friend WithEvents Chaines As System.Windows.Forms.ColumnHeader
    Friend WithEvents Debut As System.Windows.Forms.ColumnHeader
    Friend WithEvents Fin As System.Windows.Forms.ColumnHeader
    Friend WithEvents Nom As System.Windows.Forms.ColumnHeader
    Friend WithEvents Categorie As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btImprimer As System.Windows.Forms.Button
End Class
