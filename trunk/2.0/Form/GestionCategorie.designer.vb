<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionCategorie
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
        Me.btRecharger = New System.Windows.Forms.Button()
        Me.lblNomGroupeCategorie = New System.Windows.Forms.Label()
        Me.txbNomGroupeCategorie = New System.Windows.Forms.TextBox()
        Me.lblCouleurGroupeCategorie = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.btCouleur = New System.Windows.Forms.Button()
        Me.btSauvegarder = New System.Windows.Forms.Button()
        Me.btFermer = New System.Windows.Forms.Button()
        Me.gbxGroupeCategorie = New System.Windows.Forms.GroupBox()
        Me.btAjouterGroupe = New System.Windows.Forms.Button()
        Me.btModifierGroupeCategorie = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.chkSuppGroupeVide = New System.Windows.Forms.CheckBox()
        Me.lblIdGroupe = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmsGroup = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DéplacerVersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tvwCategorie = New ZGuideTV.TreeViewCategorie()
        Me.pvCouleur = New ZGuideTV.PaveCentral()
        Me.gbxGroupeCategorie.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.cmsGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'btRecharger
        '
        Me.btRecharger.Location = New System.Drawing.Point(352, 357)
        Me.btRecharger.Name = "btRecharger"
        Me.btRecharger.Size = New System.Drawing.Size(206, 29)
        Me.btRecharger.TabIndex = 1
        Me.btRecharger.Text = "Annuler les modifications"
        Me.btRecharger.UseVisualStyleBackColor = True
        '
        'lblNomGroupeCategorie
        '
        Me.lblNomGroupeCategorie.AutoSize = True
        Me.lblNomGroupeCategorie.Location = New System.Drawing.Point(9, 16)
        Me.lblNomGroupeCategorie.Name = "lblNomGroupeCategorie"
        Me.lblNomGroupeCategorie.Size = New System.Drawing.Size(86, 13)
        Me.lblNomGroupeCategorie.TabIndex = 2
        Me.lblNomGroupeCategorie.Text = "Nom du groupe :"
        '
        'txbNomGroupeCategorie
        '
        Me.txbNomGroupeCategorie.Location = New System.Drawing.Point(9, 33)
        Me.txbNomGroupeCategorie.Name = "txbNomGroupeCategorie"
        Me.txbNomGroupeCategorie.Size = New System.Drawing.Size(206, 20)
        Me.txbNomGroupeCategorie.TabIndex = 3
        '
        'lblCouleurGroupeCategorie
        '
        Me.lblCouleurGroupeCategorie.AutoSize = True
        Me.lblCouleurGroupeCategorie.Location = New System.Drawing.Point(6, 65)
        Me.lblCouleurGroupeCategorie.Name = "lblCouleurGroupeCategorie"
        Me.lblCouleurGroupeCategorie.Size = New System.Drawing.Size(103, 13)
        Me.lblCouleurGroupeCategorie.TabIndex = 4
        Me.lblCouleurGroupeCategorie.Text = "Couleur du groupe  :"
        '
        'btCouleur
        '
        Me.btCouleur.Location = New System.Drawing.Point(179, 90)
        Me.btCouleur.Name = "btCouleur"
        Me.btCouleur.Size = New System.Drawing.Size(36, 30)
        Me.btCouleur.TabIndex = 6
        Me.btCouleur.Text = "..."
        Me.btCouleur.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btCouleur.UseVisualStyleBackColor = True
        '
        'btSauvegarder
        '
        Me.btSauvegarder.Location = New System.Drawing.Point(5, 61)
        Me.btSauvegarder.Name = "btSauvegarder"
        Me.btSauvegarder.Size = New System.Drawing.Size(206, 28)
        Me.btSauvegarder.TabIndex = 9
        Me.btSauvegarder.Text = "Sauvegarder tout"
        Me.btSauvegarder.UseVisualStyleBackColor = True
        '
        'btFermer
        '
        Me.btFermer.Location = New System.Drawing.Point(475, 597)
        Me.btFermer.Name = "btFermer"
        Me.btFermer.Size = New System.Drawing.Size(83, 29)
        Me.btFermer.TabIndex = 10
        Me.btFermer.Text = "Fermer"
        Me.btFermer.UseVisualStyleBackColor = True
        '
        'gbxGroupeCategorie
        '
        Me.gbxGroupeCategorie.Controls.Add(Me.pvCouleur)
        Me.gbxGroupeCategorie.Controls.Add(Me.btAjouterGroupe)
        Me.gbxGroupeCategorie.Controls.Add(Me.btModifierGroupeCategorie)
        Me.gbxGroupeCategorie.Controls.Add(Me.lblNomGroupeCategorie)
        Me.gbxGroupeCategorie.Controls.Add(Me.txbNomGroupeCategorie)
        Me.gbxGroupeCategorie.Controls.Add(Me.lblCouleurGroupeCategorie)
        Me.gbxGroupeCategorie.Controls.Add(Me.btCouleur)
        Me.gbxGroupeCategorie.Location = New System.Drawing.Point(347, 140)
        Me.gbxGroupeCategorie.Name = "gbxGroupeCategorie"
        Me.gbxGroupeCategorie.Size = New System.Drawing.Size(234, 179)
        Me.gbxGroupeCategorie.TabIndex = 11
        Me.gbxGroupeCategorie.TabStop = False
        Me.gbxGroupeCategorie.Text = "Groupe de catégories"
        '
        'btAjouterGroupe
        '
        Me.btAjouterGroupe.Location = New System.Drawing.Point(100, 123)
        Me.btAjouterGroupe.Name = "btAjouterGroupe"
        Me.btAjouterGroupe.Size = New System.Drawing.Size(73, 32)
        Me.btAjouterGroupe.TabIndex = 2
        Me.btAjouterGroupe.Text = "Ajouter"
        Me.btAjouterGroupe.UseVisualStyleBackColor = True
        '
        'btModifierGroupeCategorie
        '
        Me.btModifierGroupeCategorie.Location = New System.Drawing.Point(9, 123)
        Me.btModifierGroupeCategorie.Name = "btModifierGroupeCategorie"
        Me.btModifierGroupeCategorie.Size = New System.Drawing.Size(85, 32)
        Me.btModifierGroupeCategorie.TabIndex = 9
        Me.btModifierGroupeCategorie.Text = "Modifier"
        Me.btModifierGroupeCategorie.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(344, 12)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(233, 125)
        Me.lblInfo.TabIndex = 13
        Me.lblInfo.Text = "Pour passer une catégorie d'un groupe à un autre, cliquez sur la catégorie puis g" &
    "lissez-déposer vers le groupe désiré."
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkSuppGroupeVide
        '
        Me.chkSuppGroupeVide.Checked = True
        Me.chkSuppGroupeVide.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSuppGroupeVide.Location = New System.Drawing.Point(15, 19)
        Me.chkSuppGroupeVide.Name = "chkSuppGroupeVide"
        Me.chkSuppGroupeVide.Size = New System.Drawing.Size(179, 36)
        Me.chkSuppGroupeVide.TabIndex = 14
        Me.chkSuppGroupeVide.Text = "Supprimer les groupes vides lors de la sauvegarde"
        Me.chkSuppGroupeVide.UseVisualStyleBackColor = True
        '
        'lblIdGroupe
        '
        Me.lblIdGroupe.AutoSize = True
        Me.lblIdGroupe.Location = New System.Drawing.Point(240, 338)
        Me.lblIdGroupe.Name = "lblIdGroupe"
        Me.lblIdGroupe.Size = New System.Drawing.Size(0, 13)
        Me.lblIdGroupe.TabIndex = 15
        Me.lblIdGroupe.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btSauvegarder)
        Me.GroupBox1.Controls.Add(Me.chkSuppGroupeVide)
        Me.GroupBox1.Location = New System.Drawing.Point(347, 435)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 100)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'cmsGroup
        '
        Me.cmsGroup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DéplacerVersToolStripMenuItem})
        Me.cmsGroup.Name = "cmsGroup"
        Me.cmsGroup.Size = New System.Drawing.Size(145, 26)
        '
        'DéplacerVersToolStripMenuItem
        '
        Me.DéplacerVersToolStripMenuItem.Name = "DéplacerVersToolStripMenuItem"
        Me.DéplacerVersToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.DéplacerVersToolStripMenuItem.Text = "Déplacer vers"
        '
        'tvwCategorie
        '
        Me.tvwCategorie.AllowDrop = True
        Me.tvwCategorie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvwCategorie.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        Me.tvwCategorie.Indent = 23
        Me.tvwCategorie.ItemHeight = 17
        Me.tvwCategorie.Location = New System.Drawing.Point(12, 12)
        Me.tvwCategorie.Name = "tvwCategorie"
        Me.tvwCategorie.ShowLines = False
        Me.tvwCategorie.ShowPlusMinus = False
        Me.tvwCategorie.ShowRootLines = False
        Me.tvwCategorie.Size = New System.Drawing.Size(304, 623)
        Me.tvwCategorie.TabIndex = 16
        '
        'pvCouleur
        '
        Me.pvCouleur.Align = System.Drawing.StringAlignment.Near
        Me.pvCouleur.BgColor = System.Drawing.Color.White
        Me.pvCouleur.Location = New System.Drawing.Point(9, 90)
        Me.pvCouleur.Marquage = False
        Me.pvCouleur.Name = "pvCouleur"
        Me.pvCouleur.Size = New System.Drawing.Size(164, 30)
        Me.pvCouleur.TabIndex = 10
        '
        'GestionCategorie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 647)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tvwCategorie)
        Me.Controls.Add(Me.lblIdGroupe)
        Me.Controls.Add(Me.btRecharger)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.gbxGroupeCategorie)
        Me.Controls.Add(Me.btFermer)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "GestionCategorie"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ZGuideTV.NET - Gestion des catégories"
        Me.TopMost = True
        Me.gbxGroupeCategorie.ResumeLayout(False)
        Me.gbxGroupeCategorie.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.cmsGroup.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btRecharger As System.Windows.Forms.Button
    Friend WithEvents lblNomGroupeCategorie As System.Windows.Forms.Label
    Friend WithEvents txbNomGroupeCategorie As System.Windows.Forms.TextBox
    Friend WithEvents lblCouleurGroupeCategorie As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btCouleur As System.Windows.Forms.Button
    Friend WithEvents btSauvegarder As System.Windows.Forms.Button
    Friend WithEvents btFermer As System.Windows.Forms.Button
    Friend WithEvents gbxGroupeCategorie As System.Windows.Forms.GroupBox
    Friend WithEvents btModifierGroupeCategorie As System.Windows.Forms.Button
    Friend WithEvents btAjouterGroupe As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents chkSuppGroupeVide As System.Windows.Forms.CheckBox
    Friend WithEvents lblIdGroupe As System.Windows.Forms.Label
    Friend WithEvents tvwCategorie As ZGuideTV.TreeViewCategorie
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pvCouleur As PaveCentral
    Friend WithEvents cmsGroup As ContextMenuStrip
    Friend WithEvents DéplacerVersToolStripMenuItem As ToolStripMenuItem
End Class
