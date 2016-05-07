<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPopup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucPopup))
        Me.pnlBorder = New System.Windows.Forms.Panel()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.lblDateEmission = New System.Windows.Forms.Label()
        Me.pbChaine = New System.Windows.Forms.PictureBox()
        Me.btImprimer = New System.Windows.Forms.Button()
        Me.lblInfosEmission = New System.Windows.Forms.Label()
        Me.lblRealise = New System.Windows.Forms.Label()
        Me.lblAvec = New System.Windows.Forms.Label()
        Me.lblInfoActeur = New System.Windows.Forms.Label()
        Me.lblSynopsis = New System.Windows.Forms.Label()
        Me.lblInfoSynopsis = New System.Windows.Forms.Label()
        Me.lblShowView = New System.Windows.Forms.Label()
        Me.lblInfoRealisateur = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblInfoPresentateur = New System.Windows.Forms.Label()
        Me.lblPresents = New System.Windows.Forms.Label()
        Me.cboRecherche = New ZGuideTV.ZComboBox()
        CType(Me.pbChaine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBorder
        '
        Me.pnlBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.pnlBorder.Location = New System.Drawing.Point(0, 0)
        Me.pnlBorder.Name = "pnlBorder"
        Me.pnlBorder.Size = New System.Drawing.Size(30, 366)
        Me.pnlBorder.TabIndex = 0
        '
        'lblTitre
        '
        Me.lblTitre.AutoSize = True
        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lblTitre.Location = New System.Drawing.Point(33, 1)
        Me.lblTitre.MaximumSize = New System.Drawing.Size(575, 0)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(134, 21)
        Me.lblTitre.TabIndex = 3
        Me.lblTitre.Text = "On m'appele King"
        '
        'lblDateEmission
        '
        Me.lblDateEmission.AutoSize = True
        Me.lblDateEmission.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateEmission.ForeColor = System.Drawing.Color.Black
        Me.lblDateEmission.Location = New System.Drawing.Point(37, 28)
        Me.lblDateEmission.Name = "lblDateEmission"
        Me.lblDateEmission.Size = New System.Drawing.Size(202, 13)
        Me.lblDateEmission.TabIndex = 4
        Me.lblDateEmission.Text = "Mercredi 29 Avril de 11:07  à 12:23 sur "
        '
        'pbChaine
        '
        Me.pbChaine.BackColor = System.Drawing.Color.Transparent
        Me.pbChaine.Location = New System.Drawing.Point(234, 23)
        Me.pbChaine.Name = "pbChaine"
        Me.pbChaine.Size = New System.Drawing.Size(28, 21)
        Me.pbChaine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbChaine.TabIndex = 5
        Me.pbChaine.TabStop = False
        '
        'btImprimer
        '
        Me.btImprimer.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btImprimer.FlatAppearance.BorderSize = 0
        Me.btImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImprimer.Image = Global.ZGuideTV.My.Resources.Resources.PrintHS
        Me.btImprimer.Location = New System.Drawing.Point(592, 329)
        Me.btImprimer.Name = "btImprimer"
        Me.btImprimer.Size = New System.Drawing.Size(25, 23)
        Me.btImprimer.TabIndex = 2
        Me.btImprimer.UseVisualStyleBackColor = True
        '
        'lblInfosEmission
        '
        Me.lblInfosEmission.AutoSize = True
        Me.lblInfosEmission.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfosEmission.ForeColor = System.Drawing.Color.Black
        Me.lblInfosEmission.Location = New System.Drawing.Point(267, 28)
        Me.lblInfosEmission.Name = "lblInfosEmission"
        Me.lblInfosEmission.Size = New System.Drawing.Size(260, 13)
        Me.lblInfosEmission.TabIndex = 6
        Me.lblInfosEmission.Text = ". Film - Film, Western - 76 min - Tous public - 1971"
        '
        'lblRealise
        '
        Me.lblRealise.AutoSize = True
        Me.lblRealise.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRealise.Location = New System.Drawing.Point(37, 53)
        Me.lblRealise.Name = "lblRealise"
        Me.lblRealise.Size = New System.Drawing.Size(24, 13)
        Me.lblRealise.TabIndex = 7
        Me.lblRealise.Text = "De "
        '
        'lblAvec
        '
        Me.lblAvec.AutoSize = True
        Me.lblAvec.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvec.Location = New System.Drawing.Point(37, 80)
        Me.lblAvec.Name = "lblAvec"
        Me.lblAvec.Size = New System.Drawing.Size(32, 13)
        Me.lblAvec.TabIndex = 9
        Me.lblAvec.Text = "Avec"
        '
        'lblInfoActeur
        '
        Me.lblInfoActeur.AutoSize = True
        Me.lblInfoActeur.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoActeur.Location = New System.Drawing.Point(37, 100)
        Me.lblInfoActeur.MaximumSize = New System.Drawing.Size(585, 0)
        Me.lblInfoActeur.Name = "lblInfoActeur"
        Me.lblInfoActeur.Size = New System.Drawing.Size(579, 39)
        Me.lblInfoActeur.TabIndex = 10
        Me.lblInfoActeur.Text = resources.GetString("lblInfoActeur.Text")
        '
        'lblSynopsis
        '
        Me.lblSynopsis.AutoSize = True
        Me.lblSynopsis.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSynopsis.Location = New System.Drawing.Point(37, 191)
        Me.lblSynopsis.Name = "lblSynopsis"
        Me.lblSynopsis.Size = New System.Drawing.Size(48, 13)
        Me.lblSynopsis.TabIndex = 11
        Me.lblSynopsis.Text = "Résumé"
        '
        'lblInfoSynopsis
        '
        Me.lblInfoSynopsis.AutoSize = True
        Me.lblInfoSynopsis.BackColor = System.Drawing.Color.White
        Me.lblInfoSynopsis.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoSynopsis.Location = New System.Drawing.Point(37, 216)
        Me.lblInfoSynopsis.MaximumSize = New System.Drawing.Size(585, 0)
        Me.lblInfoSynopsis.Name = "lblInfoSynopsis"
        Me.lblInfoSynopsis.Size = New System.Drawing.Size(581, 78)
        Me.lblInfoSynopsis.TabIndex = 12
        Me.lblInfoSynopsis.Text = resources.GetString("lblInfoSynopsis.Text")
        '
        'lblShowView
        '
        Me.lblShowView.AutoSize = True
        Me.lblShowView.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowView.Location = New System.Drawing.Point(40, 335)
        Me.lblShowView.Name = "lblShowView"
        Me.lblShowView.Size = New System.Drawing.Size(113, 20)
        Me.lblShowView.TabIndex = 13
        Me.lblShowView.Text = "ShowView : 703263287"
        Me.lblShowView.UseCompatibleTextRendering = True
        '
        'lblInfoRealisateur
        '
        Me.lblInfoRealisateur.AutoSize = True
        Me.lblInfoRealisateur.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoRealisateur.Location = New System.Drawing.Point(60, 53)
        Me.lblInfoRealisateur.MaximumSize = New System.Drawing.Size(585, 0)
        Me.lblInfoRealisateur.Name = "lblInfoRealisateur"
        Me.lblInfoRealisateur.Size = New System.Drawing.Size(104, 13)
        Me.lblInfoRealisateur.TabIndex = 14
        Me.lblInfoRealisateur.Text = "Giancarlo Romitelli"
        '
        'pbClose
        '
        Me.pbClose.Image = CType(resources.GetObject("pbClose.Image"), System.Drawing.Image)
        Me.pbClose.Location = New System.Drawing.Point(586, 0)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(41, 21)
        Me.pbClose.TabIndex = 55
        Me.pbClose.TabStop = False
        '
        'lblInfoPresentateur
        '
        Me.lblInfoPresentateur.AutoEllipsis = True
        Me.lblInfoPresentateur.AutoSize = True
        Me.lblInfoPresentateur.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoPresentateur.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoPresentateur.Location = New System.Drawing.Point(123, 158)
        Me.lblInfoPresentateur.MaximumSize = New System.Drawing.Size(462, 0)
        Me.lblInfoPresentateur.Name = "lblInfoPresentateur"
        Me.lblInfoPresentateur.Size = New System.Drawing.Size(46, 13)
        Me.lblInfoPresentateur.TabIndex = 58
        Me.lblInfoPresentateur.Text = "Toto,titi"
        '
        'lblPresents
        '
        Me.lblPresents.AutoSize = True
        Me.lblPresents.BackColor = System.Drawing.Color.Transparent
        Me.lblPresents.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresents.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblPresents.Location = New System.Drawing.Point(37, 157)
        Me.lblPresents.Name = "lblPresents"
        Me.lblPresents.Size = New System.Drawing.Size(73, 13)
        Me.lblPresents.TabIndex = 57
        Me.lblPresents.Text = "Présentateur"
        '
        'cboRecherche
        '
        Me.cboRecherche.BackColor = System.Drawing.Color.White
        Me.cboRecherche.Location = New System.Drawing.Point(403, 330)
        Me.cboRecherche.Name = "cboRecherche"
        Me.cboRecherche.Size = New System.Drawing.Size(186, 22)
        Me.cboRecherche.TabIndex = 1
        '
        'ucPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.lblInfoPresentateur)
        Me.Controls.Add(Me.lblPresents)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblInfoRealisateur)
        Me.Controls.Add(Me.lblShowView)
        Me.Controls.Add(Me.lblInfoSynopsis)
        Me.Controls.Add(Me.lblSynopsis)
        Me.Controls.Add(Me.lblInfoActeur)
        Me.Controls.Add(Me.lblAvec)
        Me.Controls.Add(Me.lblRealise)
        Me.Controls.Add(Me.lblInfosEmission)
        Me.Controls.Add(Me.pbChaine)
        Me.Controls.Add(Me.lblDateEmission)
        Me.Controls.Add(Me.lblTitre)
        Me.Controls.Add(Me.btImprimer)
        Me.Controls.Add(Me.cboRecherche)
        Me.Controls.Add(Me.pnlBorder)
        Me.Name = "ucPopup"
        Me.Size = New System.Drawing.Size(630, 362)
        CType(Me.pbChaine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBorder As System.Windows.Forms.Panel
    Friend WithEvents cboRecherche As ZComboBox
    Friend WithEvents btImprimer As System.Windows.Forms.Button
    Friend WithEvents lblTitre As System.Windows.Forms.Label
    Friend WithEvents lblDateEmission As System.Windows.Forms.Label
    Friend WithEvents pbChaine As System.Windows.Forms.PictureBox
    Friend WithEvents lblInfosEmission As System.Windows.Forms.Label
    Friend WithEvents lblRealise As System.Windows.Forms.Label
    Friend WithEvents lblAvec As System.Windows.Forms.Label
    Friend WithEvents lblInfoActeur As System.Windows.Forms.Label
    Friend WithEvents lblSynopsis As System.Windows.Forms.Label
    Friend WithEvents lblInfoSynopsis As System.Windows.Forms.Label
    Friend WithEvents lblShowView As System.Windows.Forms.Label
    Friend WithEvents lblInfoRealisateur As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Protected Friend WithEvents lblInfoPresentateur As System.Windows.Forms.Label
    Private WithEvents lblPresents As System.Windows.Forms.Label

End Class
