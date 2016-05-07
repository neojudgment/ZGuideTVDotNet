<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MMTvForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MMTvForm))
        Me.MMTVSourcesCombo = New System.Windows.Forms.ComboBox()
        Me.MMTVChannelsCombo = New System.Windows.Forms.ComboBox()
        Me.Fermer = New System.Windows.Forms.Button()
        Me.BT_Save = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BT_Auto = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MMTVSourcesCombo
        '
        Me.MMTVSourcesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MMTVSourcesCombo.FormattingEnabled = True
        Me.MMTVSourcesCombo.Location = New System.Drawing.Point(16, 80)
        Me.MMTVSourcesCombo.Name = "MMTVSourcesCombo"
        Me.MMTVSourcesCombo.Size = New System.Drawing.Size(232, 21)
        Me.MMTVSourcesCombo.TabIndex = 0
        '
        'MMTVChannelsCombo
        '
        Me.MMTVChannelsCombo.FormattingEnabled = True
        Me.MMTVChannelsCombo.Location = New System.Drawing.Point(16, 448)
        Me.MMTVChannelsCombo.Name = "MMTVChannelsCombo"
        Me.MMTVChannelsCombo.Size = New System.Drawing.Size(360, 21)
        Me.MMTVChannelsCombo.TabIndex = 1
        '
        'Fermer
        '
        Me.Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Fermer.Location = New System.Drawing.Point(16, 480)
        Me.Fermer.Name = "Fermer"
        Me.Fermer.Size = New System.Drawing.Size(79, 24)
        Me.Fermer.TabIndex = 9
        Me.Fermer.Text = "Fermer"
        Me.Fermer.UseVisualStyleBackColor = True
        '
        'BT_Save
        '
        Me.BT_Save.Location = New System.Drawing.Point(384, 448)
        Me.BT_Save.Name = "BT_Save"
        Me.BT_Save.Size = New System.Drawing.Size(79, 24)
        Me.BT_Save.TabIndex = 8
        Me.BT_Save.Text = "Sauver"
        Me.BT_Save.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(54, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(335, 23)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Gestion des chaînes MeuhMeuhTV"
        '
        'BT_Auto
        '
        Me.BT_Auto.Location = New System.Drawing.Point(384, 77)
        Me.BT_Auto.Name = "BT_Auto"
        Me.BT_Auto.Size = New System.Drawing.Size(79, 24)
        Me.BT_Auto.TabIndex = 11
        Me.BT_Auto.Text = "Auto"
        Me.BT_Auto.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        Me.ListView1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ListView1.Location = New System.Drawing.Point(16, 120)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(447, 320)
        Me.ListView1.TabIndex = 0
        Me.ListView1.TileSize = New System.Drawing.Size(1, 1)
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MMTvForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(498, 510)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BT_Auto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Fermer)
        Me.Controls.Add(Me.BT_Save)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.MMTVChannelsCombo)
        Me.Controls.Add(Me.MMTVSourcesCombo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MMTvForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "ZGuideTV.NET - Gestion des chaînes MeuhMeuhTV"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MMTVSourcesCombo As System.Windows.Forms.ComboBox
    Friend WithEvents MMTVChannelsCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Fermer As System.Windows.Forms.Button
    Friend WithEvents BT_Save As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_Auto As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
