<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZComboBox
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.lblNomRecherche = New System.Windows.Forms.Label()
        Me.lblRechercher = New System.Windows.Forms.Label()
        Me.cmsListeNom = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RechercheAvancéeinterneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TVDBinterneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IMDBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RottenTomatoesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllocinéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YoutubeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoogleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblListeNomRecherche = New System.Windows.Forms.Label()
        Me.cmsListeNom.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNomRecherche
        '
        Me.lblNomRecherche.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.lblNomRecherche.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomRecherche.Location = New System.Drawing.Point(19, 0)
        Me.lblNomRecherche.Name = "lblNomRecherche"
        Me.lblNomRecherche.Size = New System.Drawing.Size(150, 22)
        Me.lblNomRecherche.TabIndex = 2
        Me.lblNomRecherche.Text = "Recherche avancée (interne)"
        Me.lblNomRecherche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRechercher
        '
        Me.lblRechercher.Image = Global.ZGuideTV.My.Resources.Resources.ArrowNormal
        Me.lblRechercher.Location = New System.Drawing.Point(166, 0)
        Me.lblRechercher.Name = "lblRechercher"
        Me.lblRechercher.Size = New System.Drawing.Size(21, 22)
        Me.lblRechercher.TabIndex = 0
        Me.lblRechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmsListeNom
        '
        Me.cmsListeNom.AutoSize = False
        Me.cmsListeNom.BackColor = System.Drawing.Color.White
        Me.cmsListeNom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmsListeNom.DropShadowEnabled = False
        Me.cmsListeNom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RechercheAvancéeinterneToolStripMenuItem, Me.TVDBinterneToolStripMenuItem, Me.IMDBToolStripMenuItem, Me.RottenTomatoesToolStripMenuItem, Me.AllocinéToolStripMenuItem, Me.YoutubeToolStripMenuItem, Me.GoogleToolStripMenuItem})
        Me.cmsListeNom.Name = "ContextMenuStrip1"
        Me.cmsListeNom.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsListeNom.ShowImageMargin = False
        Me.cmsListeNom.Size = New System.Drawing.Size(170, 158)
        '
        'RechercheAvancéeinterneToolStripMenuItem
        '
        Me.RechercheAvancéeinterneToolStripMenuItem.Name = "RechercheAvancéeinterneToolStripMenuItem"
        Me.RechercheAvancéeinterneToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.RechercheAvancéeinterneToolStripMenuItem.Text = "Recherche avancée (interne)"
        '
        'TVDBinterneToolStripMenuItem
        '
        Me.TVDBinterneToolStripMenuItem.Name = "TVDBinterneToolStripMenuItem"
        Me.TVDBinterneToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.TVDBinterneToolStripMenuItem.Text = "TVDB (interne)"
        '
        'IMDBToolStripMenuItem
        '
        Me.IMDBToolStripMenuItem.Name = "IMDBToolStripMenuItem"
        Me.IMDBToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.IMDBToolStripMenuItem.Text = "IMDB"
        '
        'RottenTomatoesToolStripMenuItem
        '
        Me.RottenTomatoesToolStripMenuItem.Name = "RottenTomatoesToolStripMenuItem"
        Me.RottenTomatoesToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.RottenTomatoesToolStripMenuItem.Text = "Rotten Tomatoes"
        '
        'AllocinéToolStripMenuItem
        '
        Me.AllocinéToolStripMenuItem.Name = "AllocinéToolStripMenuItem"
        Me.AllocinéToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.AllocinéToolStripMenuItem.Text = "Allociné"
        '
        'YoutubeToolStripMenuItem
        '
        Me.YoutubeToolStripMenuItem.Name = "YoutubeToolStripMenuItem"
        Me.YoutubeToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.YoutubeToolStripMenuItem.Text = "Youtube"
        '
        'GoogleToolStripMenuItem
        '
        Me.GoogleToolStripMenuItem.Name = "GoogleToolStripMenuItem"
        Me.GoogleToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.GoogleToolStripMenuItem.Text = "Google"
        '
        'lblListeNomRecherche
        '
        Me.lblListeNomRecherche.Image = Global.ZGuideTV.My.Resources.Resources.chevron_expand
        Me.lblListeNomRecherche.Location = New System.Drawing.Point(0, 0)
        Me.lblListeNomRecherche.Name = "lblListeNomRecherche"
        Me.lblListeNomRecherche.Size = New System.Drawing.Size(21, 22)
        Me.lblListeNomRecherche.TabIndex = 1
        Me.lblListeNomRecherche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ZComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Controls.Add(Me.lblListeNomRecherche)
        Me.Controls.Add(Me.lblNomRecherche)
        Me.Controls.Add(Me.lblRechercher)
        Me.DoubleBuffered = True
        Me.Name = "ZComboBox"
        Me.Size = New System.Drawing.Size(187, 22)
        Me.cmsListeNom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblRechercher As System.Windows.Forms.Label
    Friend WithEvents IMDBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RottenTomatoesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllocinéToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YoutubeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoogleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblListeNomRecherche As System.Windows.Forms.Label
    Public WithEvents RechercheAvancéeinterneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TVDBinterneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents cmsListeNom As System.Windows.Forms.ContextMenuStrip
    Public WithEvents lblNomRecherche As System.Windows.Forms.Label

End Class
