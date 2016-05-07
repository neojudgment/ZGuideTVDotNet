Imports Microsoft.VisualBasic
Imports System
Namespace ZGuideTVDotNetTvdb
    Partial Public Class SearchResultForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchResultForm))
            Me.lvSearchResult = New System.Windows.Forms.ListView()
            Me.chId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.chLang = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ThetvdbGroupBoxResult = New System.Windows.Forms.GroupBox()
            Me.linkImdb = New System.Windows.Forms.LinkLabel()
            Me.txtOverview = New System.Windows.Forms.RichTextBox()
            Me.txtFirstAired = New System.Windows.Forms.TextBox()
            Me.ThetvdbLabelOverviewResult = New System.Windows.Forms.Label()
            Me.ThetvdbLabelIMDBIdResult = New System.Windows.Forms.Label()
            Me.ThetvdblabelFirstAiredResult = New System.Windows.Forms.Label()
            Me.ThetvdbButtonChooseResult = New System.Windows.Forms.Button()
            Me.ThetvdbButtonCancelResult = New System.Windows.Forms.Button()
            Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.ThetvdbLabelStatusResult = New System.Windows.Forms.ToolStripStatusLabel()
            Me.bcSeriesBanner = New ZGuideTV.ZGuideTVDotNetTvdb.BannerControl()
            Me.ThetvdbGroupBoxResult.SuspendLayout()
            Me.statusStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lvSearchResult
            '
            Me.lvSearchResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chId, Me.chName, Me.chLang})
            Me.lvSearchResult.FullRowSelect = True
            Me.lvSearchResult.Location = New System.Drawing.Point(20, 73)
            Me.lvSearchResult.MultiSelect = False
            Me.lvSearchResult.Name = "lvSearchResult"
            Me.lvSearchResult.Size = New System.Drawing.Size(300, 201)
            Me.lvSearchResult.TabIndex = 0
            Me.lvSearchResult.UseCompatibleStateImageBehavior = False
            Me.lvSearchResult.View = System.Windows.Forms.View.Details
            '
            'chId
            '
            Me.chId.Text = "Id"
            Me.chId.Width = 45
            '
            'chName
            '
            Me.chName.Text = "Name"
            Me.chName.Width = 179
            '
            'chLang
            '
            Me.chLang.Text = "Language"
            Me.chLang.Width = 70
            '
            'ThetvdbGroupBoxResult
            '
            Me.ThetvdbGroupBoxResult.Controls.Add(Me.linkImdb)
            Me.ThetvdbGroupBoxResult.Controls.Add(Me.txtOverview)
            Me.ThetvdbGroupBoxResult.Controls.Add(Me.txtFirstAired)
            Me.ThetvdbGroupBoxResult.Controls.Add(Me.ThetvdbLabelOverviewResult)
            Me.ThetvdbGroupBoxResult.Controls.Add(Me.ThetvdbLabelIMDBIdResult)
            Me.ThetvdbGroupBoxResult.Controls.Add(Me.ThetvdblabelFirstAiredResult)
            Me.ThetvdbGroupBoxResult.Location = New System.Drawing.Point(10, 280)
            Me.ThetvdbGroupBoxResult.Name = "ThetvdbGroupBoxResult"
            Me.ThetvdbGroupBoxResult.Size = New System.Drawing.Size(319, 256)
            Me.ThetvdbGroupBoxResult.TabIndex = 1
            Me.ThetvdbGroupBoxResult.TabStop = False
            Me.ThetvdbGroupBoxResult.Text = "Details"
            '
            'linkImdb
            '
            Me.linkImdb.AutoSize = True
            Me.linkImdb.Location = New System.Drawing.Point(64, 63)
            Me.linkImdb.Name = "linkImdb"
            Me.linkImdb.Size = New System.Drawing.Size(0, 13)
            Me.linkImdb.TabIndex = 3
            '
            'txtOverview
            '
            Me.txtOverview.Location = New System.Drawing.Point(67, 83)
            Me.txtOverview.Name = "txtOverview"
            Me.txtOverview.ReadOnly = True
            Me.txtOverview.Size = New System.Drawing.Size(242, 163)
            Me.txtOverview.TabIndex = 2
            Me.txtOverview.Text = ""
            '
            'txtFirstAired
            '
            Me.txtFirstAired.Location = New System.Drawing.Point(67, 30)
            Me.txtFirstAired.Name = "txtFirstAired"
            Me.txtFirstAired.ReadOnly = True
            Me.txtFirstAired.Size = New System.Drawing.Size(242, 20)
            Me.txtFirstAired.TabIndex = 1
            '
            'ThetvdbLabelOverviewResult
            '
            Me.ThetvdbLabelOverviewResult.AutoSize = True
            Me.ThetvdbLabelOverviewResult.Location = New System.Drawing.Point(6, 86)
            Me.ThetvdbLabelOverviewResult.Name = "ThetvdbLabelOverviewResult"
            Me.ThetvdbLabelOverviewResult.Size = New System.Drawing.Size(55, 13)
            Me.ThetvdbLabelOverviewResult.TabIndex = 0
            Me.ThetvdbLabelOverviewResult.Text = "Overview:"
            '
            'ThetvdbLabelIMDBIdResult
            '
            Me.ThetvdbLabelIMDBIdResult.AutoSize = True
            Me.ThetvdbLabelIMDBIdResult.Location = New System.Drawing.Point(6, 63)
            Me.ThetvdbLabelIMDBIdResult.Name = "ThetvdbLabelIMDBIdResult"
            Me.ThetvdbLabelIMDBIdResult.Size = New System.Drawing.Size(46, 13)
            Me.ThetvdbLabelIMDBIdResult.TabIndex = 0
            Me.ThetvdbLabelIMDBIdResult.Text = "IMDB Id"
            '
            'ThetvdblabelFirstAiredResult
            '
            Me.ThetvdblabelFirstAiredResult.AutoSize = True
            Me.ThetvdblabelFirstAiredResult.Location = New System.Drawing.Point(6, 33)
            Me.ThetvdblabelFirstAiredResult.Name = "ThetvdblabelFirstAiredResult"
            Me.ThetvdblabelFirstAiredResult.Size = New System.Drawing.Size(50, 13)
            Me.ThetvdblabelFirstAiredResult.TabIndex = 0
            Me.ThetvdblabelFirstAiredResult.Text = "FirstAired"
            '
            'ThetvdbButtonChooseResult
            '
            Me.ThetvdbButtonChooseResult.Location = New System.Drawing.Point(37, 540)
            Me.ThetvdbButtonChooseResult.Name = "ThetvdbButtonChooseResult"
            Me.ThetvdbButtonChooseResult.Size = New System.Drawing.Size(139, 23)
            Me.ThetvdbButtonChooseResult.TabIndex = 3
            Me.ThetvdbButtonChooseResult.Text = "Choose"
            Me.ThetvdbButtonChooseResult.UseVisualStyleBackColor = True
            '
            'ThetvdbButtonCancelResult
            '
            Me.ThetvdbButtonCancelResult.Location = New System.Drawing.Point(182, 540)
            Me.ThetvdbButtonCancelResult.Name = "ThetvdbButtonCancelResult"
            Me.ThetvdbButtonCancelResult.Size = New System.Drawing.Size(131, 23)
            Me.ThetvdbButtonCancelResult.TabIndex = 3
            Me.ThetvdbButtonCancelResult.Text = "Cancel"
            Me.ThetvdbButtonCancelResult.UseVisualStyleBackColor = True
            '
            'statusStrip1
            '
            Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThetvdbLabelStatusResult})
            Me.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
            Me.statusStrip1.Location = New System.Drawing.Point(0, 566)
            Me.statusStrip1.Name = "statusStrip1"
            Me.statusStrip1.Size = New System.Drawing.Size(340, 20)
            Me.statusStrip1.TabIndex = 4
            Me.statusStrip1.Text = "statusStrip1"
            '
            'ThetvdbLabelStatusResult
            '
            Me.ThetvdbLabelStatusResult.Name = "ThetvdbLabelStatusResult"
            Me.ThetvdbLabelStatusResult.Size = New System.Drawing.Size(82, 15)
            Me.ThetvdbLabelStatusResult.Text = "Search Results"
            Me.ThetvdbLabelStatusResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'bcSeriesBanner
            '
            Me.bcSeriesBanner.BackColor = System.Drawing.Color.Transparent
            Me.bcSeriesBanner.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.tvdb_logo
            Me.bcSeriesBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.bcSeriesBanner.DefaultImage = Nothing
            Me.bcSeriesBanner.ImageSizeMode = System.Windows.Forms.ImageLayout.Stretch
            Me.bcSeriesBanner.Index = 0
            Me.bcSeriesBanner.LoadingBackgroundColor = System.Drawing.Color.Black
            Me.bcSeriesBanner.LoadingImage = Global.ZGuideTV.My.Resources.Resources.loader4
            Me.bcSeriesBanner.Location = New System.Drawing.Point(20, 12)
            Me.bcSeriesBanner.Name = "bcSeriesBanner"
            Me.bcSeriesBanner.Size = New System.Drawing.Size(300, 55)
            Me.bcSeriesBanner.TabIndex = 6
            Me.bcSeriesBanner.UnavailableImage = Nothing
            Me.bcSeriesBanner.UseThumb = False
            '
            'SearchResultForm
            '
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
            Me.CausesValidation = False
            Me.ClientSize = New System.Drawing.Size(340, 586)
            Me.Controls.Add(Me.bcSeriesBanner)
            Me.Controls.Add(Me.statusStrip1)
            Me.Controls.Add(Me.ThetvdbButtonCancelResult)
            Me.Controls.Add(Me.ThetvdbButtonChooseResult)
            Me.Controls.Add(Me.ThetvdbGroupBoxResult)
            Me.Controls.Add(Me.lvSearchResult)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SearchResultForm"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "ZGuideTV.NET  - The TVDB.com"
            Me.ThetvdbGroupBoxResult.ResumeLayout(False)
            Me.ThetvdbGroupBoxResult.PerformLayout()
            Me.statusStrip1.ResumeLayout(False)
            Me.statusStrip1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private chId As System.Windows.Forms.ColumnHeader
        Private chName As System.Windows.Forms.ColumnHeader
        Private txtOverview As System.Windows.Forms.RichTextBox
        Private txtFirstAired As System.Windows.Forms.TextBox
        Private chLang As System.Windows.Forms.ColumnHeader
        Private statusStrip1 As System.Windows.Forms.StatusStrip
        Private WithEvents linkImdb As System.Windows.Forms.LinkLabel
        Private bcSeriesBanner As BannerControl
        Friend WithEvents ThetvdblabelFirstAiredResult As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelStatusResult As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents ThetvdbButtonCancelResult As System.Windows.Forms.Button
        Friend WithEvents ThetvdbLabelOverviewResult As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelIMDBIdResult As System.Windows.Forms.Label
        Public WithEvents lvSearchResult As System.Windows.Forms.ListView
        Public WithEvents ThetvdbGroupBoxResult As System.Windows.Forms.GroupBox
        Friend WithEvents ThetvdbButtonChooseResult As System.Windows.Forms.Button
    End Class
End Namespace