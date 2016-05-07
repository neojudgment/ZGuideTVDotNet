<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MySearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MySearch))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ThetvdbLabelUseZipped = New System.Windows.Forms.CheckBox()
        Me.ThetvdbLabelLoadActors = New System.Windows.Forms.CheckBox()
        Me.ThetvdbLabelBanner = New System.Windows.Forms.CheckBox()
        Me.ThetvdbLabelLoadFull = New System.Windows.Forms.CheckBox()
        Me.ThetvdbButtonLoad = New System.Windows.Forms.Button()
        Me.txtSeriesToFind = New System.Windows.Forms.TextBox()
        Me.txtGetSeries = New System.Windows.Forms.TextBox()
        Me.ThetvdbButtonSearch = New System.Windows.Forms.Button()
        Me.cbLanguage = New System.Windows.Forms.ComboBox()
        Me.lblCurrentLanguage = New System.Windows.Forms.Label()
        Me.ThetvdbLabelID1 = New System.Windows.Forms.Label()
        Me.ThetvdbLabelSearchName = New System.Windows.Forms.Label()
        Me.ThetvdbLabelLanguage = New System.Windows.Forms.Label()
        Me.bcSeriesBanner = New ZGuideTV.ZGuideTVDotNetTvdb.BannerControl()
        Me.ThetvdbButtonCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ThetvdbLabelUseZipped)
        Me.GroupBox1.Controls.Add(Me.ThetvdbLabelLoadActors)
        Me.GroupBox1.Controls.Add(Me.ThetvdbLabelBanner)
        Me.GroupBox1.Controls.Add(Me.ThetvdbLabelLoadFull)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 125)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'ThetvdbLabelUseZipped
        '
        Me.ThetvdbLabelUseZipped.AutoSize = True
        Me.ThetvdbLabelUseZipped.Checked = True
        Me.ThetvdbLabelUseZipped.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ThetvdbLabelUseZipped.Location = New System.Drawing.Point(15, 94)
        Me.ThetvdbLabelUseZipped.Name = "ThetvdbLabelUseZipped"
        Me.ThetvdbLabelUseZipped.Size = New System.Drawing.Size(120, 17)
        Me.ThetvdbLabelUseZipped.TabIndex = 57
        Me.ThetvdbLabelUseZipped.Text = "zipped downloading"
        Me.ThetvdbLabelUseZipped.UseVisualStyleBackColor = True
        '
        'ThetvdbLabelLoadActors
        '
        Me.ThetvdbLabelLoadActors.AutoSize = True
        Me.ThetvdbLabelLoadActors.Checked = True
        Me.ThetvdbLabelLoadActors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ThetvdbLabelLoadActors.Enabled = False
        Me.ThetvdbLabelLoadActors.Location = New System.Drawing.Point(15, 48)
        Me.ThetvdbLabelLoadActors.Name = "ThetvdbLabelLoadActors"
        Me.ThetvdbLabelLoadActors.Size = New System.Drawing.Size(144, 17)
        Me.ThetvdbLabelLoadActors.TabIndex = 56
        Me.ThetvdbLabelLoadActors.Text = "Load extended actor info"
        Me.ThetvdbLabelLoadActors.UseVisualStyleBackColor = True
        '
        'ThetvdbLabelBanner
        '
        Me.ThetvdbLabelBanner.AutoSize = True
        Me.ThetvdbLabelBanner.Checked = True
        Me.ThetvdbLabelBanner.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ThetvdbLabelBanner.Enabled = False
        Me.ThetvdbLabelBanner.Location = New System.Drawing.Point(15, 71)
        Me.ThetvdbLabelBanner.Name = "ThetvdbLabelBanner"
        Me.ThetvdbLabelBanner.Size = New System.Drawing.Size(92, 17)
        Me.ThetvdbLabelBanner.TabIndex = 54
        Me.ThetvdbLabelBanner.Text = "Load Banners"
        Me.ThetvdbLabelBanner.UseVisualStyleBackColor = True
        '
        'ThetvdbLabelLoadFull
        '
        Me.ThetvdbLabelLoadFull.AutoSize = True
        Me.ThetvdbLabelLoadFull.Checked = True
        Me.ThetvdbLabelLoadFull.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ThetvdbLabelLoadFull.Enabled = False
        Me.ThetvdbLabelLoadFull.Location = New System.Drawing.Point(15, 25)
        Me.ThetvdbLabelLoadFull.Name = "ThetvdbLabelLoadFull"
        Me.ThetvdbLabelLoadFull.Size = New System.Drawing.Size(146, 17)
        Me.ThetvdbLabelLoadFull.TabIndex = 55
        Me.ThetvdbLabelLoadFull.Text = "Load Episode Information"
        Me.ThetvdbLabelLoadFull.UseVisualStyleBackColor = True
        '
        'ThetvdbButtonLoad
        '
        Me.ThetvdbButtonLoad.BackColor = System.Drawing.Color.White
        Me.ThetvdbButtonLoad.Enabled = False
        Me.ThetvdbButtonLoad.Location = New System.Drawing.Point(241, 285)
        Me.ThetvdbButtonLoad.Name = "ThetvdbButtonLoad"
        Me.ThetvdbButtonLoad.Size = New System.Drawing.Size(75, 23)
        Me.ThetvdbButtonLoad.TabIndex = 52
        Me.ThetvdbButtonLoad.Text = "Load"
        Me.ThetvdbButtonLoad.UseVisualStyleBackColor = True
        '
        'txtSeriesToFind
        '
        Me.txtSeriesToFind.Location = New System.Drawing.Point(115, 259)
        Me.txtSeriesToFind.Name = "txtSeriesToFind"
        Me.txtSeriesToFind.Size = New System.Drawing.Size(116, 20)
        Me.txtSeriesToFind.TabIndex = 7
        Me.txtSeriesToFind.WordWrap = False
        '
        'txtGetSeries
        '
        Me.txtGetSeries.Location = New System.Drawing.Point(115, 288)
        Me.txtGetSeries.Name = "txtGetSeries"
        Me.txtGetSeries.Size = New System.Drawing.Size(116, 20)
        Me.txtGetSeries.TabIndex = 49
        '
        'ThetvdbButtonSearch
        '
        Me.ThetvdbButtonSearch.BackColor = System.Drawing.Color.White
        Me.ThetvdbButtonSearch.Location = New System.Drawing.Point(241, 257)
        Me.ThetvdbButtonSearch.Name = "ThetvdbButtonSearch"
        Me.ThetvdbButtonSearch.Size = New System.Drawing.Size(75, 23)
        Me.ThetvdbButtonSearch.TabIndex = 51
        Me.ThetvdbButtonSearch.Text = "Find"
        Me.ThetvdbButtonSearch.UseVisualStyleBackColor = True
        '
        'cbLanguage
        '
        Me.cbLanguage.FormattingEnabled = True
        Me.cbLanguage.Location = New System.Drawing.Point(192, 226)
        Me.cbLanguage.Name = "cbLanguage"
        Me.cbLanguage.Size = New System.Drawing.Size(123, 21)
        Me.cbLanguage.TabIndex = 53
        '
        'lblCurrentLanguage
        '
        Me.lblCurrentLanguage.AutoSize = True
        Me.lblCurrentLanguage.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentLanguage.Location = New System.Drawing.Point(97, 229)
        Me.lblCurrentLanguage.Name = "lblCurrentLanguage"
        Me.lblCurrentLanguage.Size = New System.Drawing.Size(13, 13)
        Me.lblCurrentLanguage.TabIndex = 54
        Me.lblCurrentLanguage.Text = "[]"
        '
        'ThetvdbLabelID1
        '
        Me.ThetvdbLabelID1.AutoSize = True
        Me.ThetvdbLabelID1.BackColor = System.Drawing.Color.Transparent
        Me.ThetvdbLabelID1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ThetvdbLabelID1.Location = New System.Drawing.Point(24, 291)
        Me.ThetvdbLabelID1.Name = "ThetvdbLabelID1"
        Me.ThetvdbLabelID1.Size = New System.Drawing.Size(53, 13)
        Me.ThetvdbLabelID1.TabIndex = 46
        Me.ThetvdbLabelID1.Text = "Series ID:"
        '
        'ThetvdbLabelSearchName
        '
        Me.ThetvdbLabelSearchName.AutoSize = True
        Me.ThetvdbLabelSearchName.BackColor = System.Drawing.Color.Transparent
        Me.ThetvdbLabelSearchName.Location = New System.Drawing.Point(24, 262)
        Me.ThetvdbLabelSearchName.Name = "ThetvdbLabelSearchName"
        Me.ThetvdbLabelSearchName.Size = New System.Drawing.Size(70, 13)
        Me.ThetvdbLabelSearchName.TabIndex = 47
        Me.ThetvdbLabelSearchName.Text = "Series Name:"
        '
        'ThetvdbLabelLanguage
        '
        Me.ThetvdbLabelLanguage.AutoSize = True
        Me.ThetvdbLabelLanguage.BackColor = System.Drawing.Color.Transparent
        Me.ThetvdbLabelLanguage.Location = New System.Drawing.Point(24, 229)
        Me.ThetvdbLabelLanguage.Name = "ThetvdbLabelLanguage"
        Me.ThetvdbLabelLanguage.Size = New System.Drawing.Size(58, 13)
        Me.ThetvdbLabelLanguage.TabIndex = 48
        Me.ThetvdbLabelLanguage.Text = "Language:"
        '
        'bcSeriesBanner
        '
        Me.bcSeriesBanner.DefaultImage = Global.ZGuideTV.My.Resources.Resources.tvdb_logo
        Me.bcSeriesBanner.ImageSizeMode = System.Windows.Forms.ImageLayout.Zoom
        Me.bcSeriesBanner.Index = 0
        Me.bcSeriesBanner.LoadingBackgroundColor = System.Drawing.Color.Black
        Me.bcSeriesBanner.LoadingImage = Global.ZGuideTV.My.Resources.Resources.loader4
        Me.bcSeriesBanner.Location = New System.Drawing.Point(20, 12)
        Me.bcSeriesBanner.Name = "bcSeriesBanner"
        Me.bcSeriesBanner.Size = New System.Drawing.Size(300, 55)
        Me.bcSeriesBanner.TabIndex = 8
        Me.bcSeriesBanner.UnavailableImage = Nothing
        Me.bcSeriesBanner.UseThumb = True
        '
        'ThetvdbButtonCancel
        '
        Me.ThetvdbButtonCancel.Location = New System.Drawing.Point(241, 313)
        Me.ThetvdbButtonCancel.Name = "ThetvdbButtonCancel"
        Me.ThetvdbButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ThetvdbButtonCancel.TabIndex = 55
        Me.ThetvdbButtonCancel.Text = "Cancel"
        Me.ThetvdbButtonCancel.UseVisualStyleBackColor = True
        '
        'search
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(340, 342)
        Me.Controls.Add(Me.ThetvdbButtonCancel)
        Me.Controls.Add(Me.ThetvdbButtonLoad)
        Me.Controls.Add(Me.txtSeriesToFind)
        Me.Controls.Add(Me.txtGetSeries)
        Me.Controls.Add(Me.ThetvdbButtonSearch)
        Me.Controls.Add(Me.cbLanguage)
        Me.Controls.Add(Me.lblCurrentLanguage)
        Me.Controls.Add(Me.ThetvdbLabelID1)
        Me.Controls.Add(Me.ThetvdbLabelSearchName)
        Me.Controls.Add(Me.ThetvdbLabelLanguage)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bcSeriesBanner)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "search"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - The TVDB.Com"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents bcSeriesBanner As ZGuideTV.ZGuideTVDotNetTvdb.BannerControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ThetvdbLabelUseZipped As System.Windows.Forms.CheckBox
    Friend WithEvents ThetvdbLabelLoadActors As System.Windows.Forms.CheckBox
    Friend WithEvents ThetvdbLabelBanner As System.Windows.Forms.CheckBox
    Friend WithEvents ThetvdbLabelLoadFull As System.Windows.Forms.CheckBox
    Friend WithEvents ThetvdbButtonLoad As System.Windows.Forms.Button
    Friend WithEvents ThetvdbButtonSearch As System.Windows.Forms.Button
    Public WithEvents cbLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents ThetvdbLabelID1 As System.Windows.Forms.Label
    Friend WithEvents ThetvdbLabelSearchName As System.Windows.Forms.Label
    Friend WithEvents ThetvdbLabelLanguage As System.Windows.Forms.Label
    Public WithEvents txtSeriesToFind As System.Windows.Forms.TextBox
    Public WithEvents txtGetSeries As System.Windows.Forms.TextBox
    Public WithEvents lblCurrentLanguage As System.Windows.Forms.Label
    Friend WithEvents ThetvdbButtonCancel As System.Windows.Forms.Button
End Class
