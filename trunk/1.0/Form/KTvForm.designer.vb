<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KTvForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KTvForm))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.KTVChannelComboBox = New System.Windows.Forms.ComboBox()
        Me.Path = New System.Windows.Forms.TextBox()
        Me.BT_Path = New System.Windows.Forms.Button()
        Me.BT_Auto = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ListSources = New System.Windows.Forms.ComboBox()
        Me.LabelSource = New System.Windows.Forms.Label()
        Me.SuspendLayout()
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
        Me.ListView1.Location = New System.Drawing.Point(20, 128)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(447, 320)
        Me.ListView1.TabIndex = 0
        Me.ListView1.TileSize = New System.Drawing.Size(1, 1)
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'KTVChannelComboBox
        '
        Me.KTVChannelComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.KTVChannelComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.KTVChannelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.KTVChannelComboBox.Location = New System.Drawing.Point(20, 454)
        Me.KTVChannelComboBox.Name = "KTVChannelComboBox"
        Me.KTVChannelComboBox.Size = New System.Drawing.Size(336, 21)
        Me.KTVChannelComboBox.TabIndex = 1
        '
        'Path
        '
        Me.Path.BackColor = System.Drawing.Color.White
        Me.Path.Location = New System.Drawing.Point(20, 71)
        Me.Path.Name = "Path"
        Me.Path.Size = New System.Drawing.Size(414, 20)
        Me.Path.TabIndex = 2
        '
        'BT_Path
        '
        Me.BT_Path.Location = New System.Drawing.Point(440, 71)
        Me.BT_Path.Name = "BT_Path"
        Me.BT_Path.Size = New System.Drawing.Size(27, 24)
        Me.BT_Path.TabIndex = 3
        Me.BT_Path.Text = "..."
        Me.BT_Path.UseVisualStyleBackColor = True
        '
        'BT_Auto
        '
        Me.BT_Auto.Location = New System.Drawing.Point(473, 71)
        Me.BT_Auto.Name = "BT_Auto"
        Me.BT_Auto.Size = New System.Drawing.Size(89, 24)
        Me.BT_Auto.TabIndex = 4
        Me.BT_Auto.Text = "Auto"
        Me.BT_Auto.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(360, 454)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonSave.Size = New System.Drawing.Size(79, 23)
        Me.ButtonSave.TabIndex = 5
        Me.ButtonSave.Text = "Sauver"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonClose.Location = New System.Drawing.Point(20, 481)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(79, 24)
        Me.ButtonClose.TabIndex = 6
        Me.ButtonClose.Text = "Fermer"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ListSources
        '
        Me.ListSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListSources.FormattingEnabled = True
        Me.ListSources.Location = New System.Drawing.Point(130, 96)
        Me.ListSources.Name = "ListSources"
        Me.ListSources.Size = New System.Drawing.Size(304, 21)
        Me.ListSources.TabIndex = 8
        '
        'LabelSource
        '
        Me.LabelSource.AutoSize = True
        Me.LabelSource.BackColor = System.Drawing.Color.Transparent
        Me.LabelSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSource.Location = New System.Drawing.Point(18, 99)
        Me.LabelSource.Name = "LabelSource"
        Me.LabelSource.Size = New System.Drawing.Size(108, 16)
        Me.LabelSource.TabIndex = 9
        Me.LabelSource.Text = "Source Active:"
        '
        'KTvForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(580, 520)
        Me.Controls.Add(Me.LabelSource)
        Me.Controls.Add(Me.ListSources)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.BT_Auto)
        Me.Controls.Add(Me.BT_Path)
        Me.Controls.Add(Me.Path)
        Me.Controls.Add(Me.KTVChannelComboBox)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KTvForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Gestion des chaînes K!TV"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents KTVChannelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Path As System.Windows.Forms.TextBox
    Friend WithEvents BT_Path As System.Windows.Forms.Button
    Friend WithEvents BT_Auto As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents ListSources As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSource As System.Windows.Forms.Label
End Class
