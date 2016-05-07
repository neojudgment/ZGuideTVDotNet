<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EPGDataSubscription
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EPGDataSubscription))
        Me.LabelChoixPays = New System.Windows.Forms.Label()
        Me.cboCountry = New System.Windows.Forms.ComboBox()
        Me.cboLangue = New System.Windows.Forms.ComboBox()
        Me.LabelChoixLangue = New System.Windows.Forms.Label()
        Me.ButtonGoEPGData = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelChoixPays
        '
        Me.LabelChoixPays.Location = New System.Drawing.Point(13, 9)
        Me.LabelChoixPays.Name = "LabelChoixPays"
        Me.LabelChoixPays.Size = New System.Drawing.Size(337, 13)
        Me.LabelChoixPays.TabIndex = 0
        Me.LabelChoixPays.Text = "Sélectionnez le pays"
        Me.LabelChoixPays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboCountry
        '
        Me.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountry.FormattingEnabled = True
        Me.cboCountry.Items.AddRange(New Object() {"France/France", "Italie/Italia", "Allemagne/Germany", "Autriche/Austria", "Suisse/Switzerland"})
        Me.cboCountry.Location = New System.Drawing.Point(43, 31)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(277, 21)
        Me.cboCountry.TabIndex = 1
        '
        'cboLangue
        '
        Me.cboLangue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLangue.FormattingEnabled = True
        Me.cboLangue.Items.AddRange(New Object() {"Français/French", "Anglais/English", "Italien/Italian", "Allemand/German", "Espagnol/Spanish"})
        Me.cboLangue.Location = New System.Drawing.Point(43, 88)
        Me.cboLangue.Name = "cboLangue"
        Me.cboLangue.Size = New System.Drawing.Size(277, 21)
        Me.cboLangue.TabIndex = 3
        '
        'LabelChoixLangue
        '
        Me.LabelChoixLangue.Location = New System.Drawing.Point(13, 66)
        Me.LabelChoixLangue.Name = "LabelChoixLangue"
        Me.LabelChoixLangue.Size = New System.Drawing.Size(337, 13)
        Me.LabelChoixLangue.TabIndex = 2
        Me.LabelChoixLangue.Text = "Sélectionner la langue"
        Me.LabelChoixLangue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonGoEPGData
        '
        Me.ButtonGoEPGData.Location = New System.Drawing.Point(43, 140)
        Me.ButtonGoEPGData.Name = "ButtonGoEPGData"
        Me.ButtonGoEPGData.Size = New System.Drawing.Size(277, 23)
        Me.ButtonGoEPGData.TabIndex = 4
        Me.ButtonGoEPGData.Text = "Aller sur le site web"
        Me.ButtonGoEPGData.UseVisualStyleBackColor = True
        '
        'EPGDataSubscription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(362, 182)
        Me.Controls.Add(Me.ButtonGoEPGData)
        Me.Controls.Add(Me.cboLangue)
        Me.Controls.Add(Me.LabelChoixLangue)
        Me.Controls.Add(Me.cboCountry)
        Me.Controls.Add(Me.LabelChoixPays)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EPGDataSubscription"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ZGuideTV.NET - epgData.com"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelChoixPays As System.Windows.Forms.Label
    Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
    Friend WithEvents cboLangue As System.Windows.Forms.ComboBox
    Friend WithEvents LabelChoixLangue As System.Windows.Forms.Label
    Friend WithEvents ButtonGoEPGData As System.Windows.Forms.Button
End Class
