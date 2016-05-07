<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiseajourEPGData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MiseajourEPGData))
        Me.ListViewAllChannel = New System.Windows.Forms.ListView()
        Me.ListXMLTVFRChoisie = New System.Windows.Forms.ListView()
        Me.ButtonSuppr = New System.Windows.Forms.Button()
        Me.ButtonMiseaJour = New System.Windows.Forms.Button()
        Me.ButtonTout = New System.Windows.Forms.Button()
        Me.ButtonAnnuler = New System.Windows.Forms.Button()
        Me.ButtonForceDownload = New System.Windows.Forms.Button()
        Me.tbInfo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ListViewAllChannel
        '
        Me.ListViewAllChannel.AllowDrop = True
        Me.ListViewAllChannel.FullRowSelect = True
        Me.ListViewAllChannel.Location = New System.Drawing.Point(31, 12)
        Me.ListViewAllChannel.Name = "ListViewAllChannel"
        Me.ListViewAllChannel.Size = New System.Drawing.Size(190, 373)
        Me.ListViewAllChannel.TabIndex = 6
        Me.ListViewAllChannel.UseCompatibleStateImageBehavior = False
        Me.ListViewAllChannel.View = System.Windows.Forms.View.Details
        '
        'ListXMLTVFRChoisie
        '
        Me.ListXMLTVFRChoisie.AllowDrop = True
        Me.ListXMLTVFRChoisie.FullRowSelect = True
        Me.ListXMLTVFRChoisie.Location = New System.Drawing.Point(262, 12)
        Me.ListXMLTVFRChoisie.Name = "ListXMLTVFRChoisie"
        Me.ListXMLTVFRChoisie.Size = New System.Drawing.Size(190, 373)
        Me.ListXMLTVFRChoisie.TabIndex = 12
        Me.ListXMLTVFRChoisie.UseCompatibleStateImageBehavior = False
        Me.ListXMLTVFRChoisie.View = System.Windows.Forms.View.Details
        '
        'ButtonSuppr
        '
        Me.ButtonSuppr.Enabled = False
        Me.ButtonSuppr.Location = New System.Drawing.Point(246, 391)
        Me.ButtonSuppr.Name = "ButtonSuppr"
        Me.ButtonSuppr.Size = New System.Drawing.Size(98, 23)
        Me.ButtonSuppr.TabIndex = 24
        Me.ButtonSuppr.Text = "Tout supprimer"
        Me.ButtonSuppr.UseVisualStyleBackColor = True
        '
        'ButtonMiseaJour
        '
        Me.ButtonMiseaJour.Location = New System.Drawing.Point(354, 391)
        Me.ButtonMiseaJour.Name = "ButtonMiseaJour"
        Me.ButtonMiseaJour.Size = New System.Drawing.Size(98, 23)
        Me.ButtonMiseaJour.TabIndex = 23
        Me.ButtonMiseaJour.Text = "&Appliquer"
        Me.ButtonMiseaJour.UseVisualStyleBackColor = True
        Me.ButtonMiseaJour.Visible = False
        '
        'ButtonTout
        '
        Me.ButtonTout.Location = New System.Drawing.Point(138, 391)
        Me.ButtonTout.Name = "ButtonTout"
        Me.ButtonTout.Size = New System.Drawing.Size(98, 23)
        Me.ButtonTout.TabIndex = 22
        Me.ButtonTout.Text = "Tout sélectionner"
        Me.ButtonTout.UseMnemonic = False
        Me.ButtonTout.UseVisualStyleBackColor = True
        '
        'ButtonAnnuler
        '
        Me.ButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonAnnuler.Location = New System.Drawing.Point(354, 538)
        Me.ButtonAnnuler.Name = "ButtonAnnuler"
        Me.ButtonAnnuler.Size = New System.Drawing.Size(95, 23)
        Me.ButtonAnnuler.TabIndex = 21
        Me.ButtonAnnuler.Text = "&Annuler"
        Me.ButtonAnnuler.UseVisualStyleBackColor = True
        '
        'ButtonForceDownload
        '
        Me.ButtonForceDownload.Location = New System.Drawing.Point(31, 391)
        Me.ButtonForceDownload.Name = "ButtonForceDownload"
        Me.ButtonForceDownload.Size = New System.Drawing.Size(98, 23)
        Me.ButtonForceDownload.TabIndex = 25
        Me.ButtonForceDownload.Text = "Forcer MAJ"
        Me.ButtonForceDownload.UseVisualStyleBackColor = True
        '
        'tbInfo
        '
        Me.tbInfo.Location = New System.Drawing.Point(31, 420)
        Me.tbInfo.Multiline = True
        Me.tbInfo.Name = "tbInfo"
        Me.tbInfo.Size = New System.Drawing.Size(242, 141)
        Me.tbInfo.TabIndex = 26
        '
        'MiseajourEPGData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(482, 576)
        Me.Controls.Add(Me.tbInfo)
        Me.Controls.Add(Me.ButtonForceDownload)
        Me.Controls.Add(Me.ButtonSuppr)
        Me.Controls.Add(Me.ButtonMiseaJour)
        Me.Controls.Add(Me.ButtonTout)
        Me.Controls.Add(Me.ButtonAnnuler)
        Me.Controls.Add(Me.ListXMLTVFRChoisie)
        Me.Controls.Add(Me.ListViewAllChannel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MiseajourEPGData"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Mise à jour de la base de données"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListViewAllChannel As System.Windows.Forms.ListView
    Friend WithEvents ListXMLTVFRChoisie As System.Windows.Forms.ListView
    Friend WithEvents ButtonSuppr As System.Windows.Forms.Button
    Friend WithEvents ButtonMiseaJour As System.Windows.Forms.Button
    Friend WithEvents ButtonTout As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnuler As System.Windows.Forms.Button
    Friend WithEvents ButtonForceDownload As System.Windows.Forms.Button
    Friend WithEvents tbInfo As System.Windows.Forms.TextBox
End Class
