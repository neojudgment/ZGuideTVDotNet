Imports Microsoft.VisualBasic
Imports System
Namespace ZGuideTVDotNetTvdb
    Partial Public Class SeriesBrowser
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeriesBrowser))
            Me.label5 = New System.Windows.Forms.Label()
            Me.ThetvdbLabelEpisodesTabEpisodes = New System.Windows.Forms.TabPage()
            Me.lbDirectors = New System.Windows.Forms.ListBox()
            Me.bcEpisodeBanner = New ZGuideTV.ZGuideTVDotNetTvdb.BannerControl()
            Me.lbWriters = New System.Windows.Forms.ListBox()
            Me.lbGuestStars = New System.Windows.Forms.ListBox()
            Me.pnlSeasonBanner = New System.Windows.Forms.Panel()
            Me.bcSeasonBanner = New ZGuideTV.ZGuideTVDotNetTvdb.BannerControl()
            Me.pnlSeasonBannerWide = New System.Windows.Forms.Panel()
            Me.bcSeasonBannerWide = New ZGuideTV.ZGuideTVDotNetTvdb.BannerControl()
            Me.txtEpisodeImdbID = New System.Windows.Forms.TextBox()
            Me.txtEpisodeAbsoluteNumber = New System.Windows.Forms.TextBox()
            Me.ThetvdbLabelIDIMDBComTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelAbsoluteNumberTabEpisodes = New System.Windows.Forms.Label()
            Me.txtEpisodeOverview = New System.Windows.Forms.RichTextBox()
            Me.txtEpisodeDVDChapter = New System.Windows.Forms.TextBox()
            Me.txtEpisodeFirstAired = New System.Windows.Forms.TextBox()
            Me.txtEpisodeDVDSeason = New System.Windows.Forms.TextBox()
            Me.txtEpisodeDVDNumber = New System.Windows.Forms.TextBox()
            Me.txtEpisodeLanguage = New System.Windows.Forms.TextBox()
            Me.txtEpisodeProductionCode = New System.Windows.Forms.TextBox()
            Me.txtEpisodeDVDId = New System.Windows.Forms.TextBox()
            Me.ThetvdbLabelOverviewTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelGueststarTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelFirstAiredTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelDVDChapterTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelWriterTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelDVDSeasonTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelProductCodeTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelLanguageTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelDVDNumberTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelDirectorTabTabEpisodes = New System.Windows.Forms.Label()
            Me.ThetvdbLabelDVDIDTabEpisodes = New System.Windows.Forms.Label()
            Me.tvEpisodes = New System.Windows.Forms.TreeView()
            Me.showImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.copyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.saveImageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
            Me.ThetvdbLabelSeriesTabSeries = New System.Windows.Forms.TabPage()
            Me.ThetvdbButtonSearchShow = New System.Windows.Forms.Button()
            Me.ThetvdbButtonExit = New System.Windows.Forms.Button()
            Me.ThetvdbButtonForceUpdate = New System.Windows.Forms.Button()
            Me.lbGenre = New System.Windows.Forms.ListBox()
            Me.lbActors = New System.Windows.Forms.ListBox()
            Me.llblImdb = New System.Windows.Forms.LinkLabel()
            Me.llblTvComId = New System.Windows.Forms.LinkLabel()
            Me.raterSeriesSiteRating = New ZGuideTV.Rater()
            Me.panelSeriesBannerFrame = New System.Windows.Forms.Panel()
            Me.bcSeriesBanner = New ZGuideTV.ZGuideTVDotNetTvdb.BannerControl()
            Me.posterControlSeries = New ZGuideTV.ZGuideTVDotNetTvdb.PosterControl()
            Me.txtOverview = New System.Windows.Forms.RichTextBox()
            Me.txtRuntime = New System.Windows.Forms.TextBox()
            Me.txtImdbId = New System.Windows.Forms.TextBox()
            Me.txtSeriesName = New System.Windows.Forms.TextBox()
            Me.txtRating = New System.Windows.Forms.TextBox()
            Me.txtFirstAired = New System.Windows.Forms.TextBox()
            Me.txtTvComId = New System.Windows.Forms.TextBox()
            Me.txtSeriesId = New System.Windows.Forms.TextBox()
            Me.ThetvdbLabelActors = New System.Windows.Forms.Label()
            Me.ThetvdbLabelRuntime = New System.Windows.Forms.Label()
            Me.ThetvdbLabelGenre = New System.Windows.Forms.Label()
            Me.ThetvdbLabelIDIMDB = New System.Windows.Forms.Label()
            Me.ThetvdbLabelSearchName1 = New System.Windows.Forms.Label()
            Me.ThetvdbLabelRating = New System.Windows.Forms.Label()
            Me.ThetvdbLabelFirstAired = New System.Windows.Forms.Label()
            Me.ThetvdbLabelIDTVCom = New System.Windows.Forms.Label()
            Me.ThetvdbLabelSiteRating = New System.Windows.Forms.Label()
            Me.ThetvdbLabelDescription = New System.Windows.Forms.Label()
            Me.ThetvdbLabelID = New System.Windows.Forms.Label()
            Me.ThetvdbTabControlTvdb = New System.Windows.Forms.TabControl()
            Me.ThetvdbLabelActorsTabActors = New System.Windows.Forms.TabPage()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.BannerControl1 = New ZGuideTV.ZGuideTVDotNetTvdb.BannerControl()
            Me.ThetvdbActors = New System.Windows.Forms.ListBox()
            Me.ThetvdbGroupBoxInformationTabActors = New System.Windows.Forms.GroupBox()
            Me.txtActorSortOrder = New System.Windows.Forms.TextBox()
            Me.ThetvdbLabelIDTabActors = New System.Windows.Forms.Label()
            Me.ThetvdbLabelNameTabActors = New System.Windows.Forms.Label()
            Me.txtActorRole = New System.Windows.Forms.TextBox()
            Me.ThetvdbLabelRoleTabActors = New System.Windows.Forms.Label()
            Me.txtActorName = New System.Windows.Forms.TextBox()
            Me.ThetvdbLabelSortOrderTabActors = New System.Windows.Forms.Label()
            Me.txtActorId = New System.Windows.Forms.TextBox()
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.bcActors = New ZGuideTV.ZGuideTVDotNetTvdb.BannerControl()
            Me.pnlEpisodeEnabled = New System.Windows.Forms.Panel()
            Me.ThetvdbLabelEpisodes = New System.Windows.Forms.Label()
            Me.pnlActorsEnabled = New System.Windows.Forms.Panel()
            Me.ThetvdbLabelActors1 = New System.Windows.Forms.Label()
            Me.ThetvdbLabelEpisodesTabEpisodes.SuspendLayout()
            Me.pnlSeasonBanner.SuspendLayout()
            Me.pnlSeasonBannerWide.SuspendLayout()
            Me.ThetvdbLabelSeriesTabSeries.SuspendLayout()
            CType(Me.raterSeriesSiteRating, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelSeriesBannerFrame.SuspendLayout()
            Me.ThetvdbTabControlTvdb.SuspendLayout()
            Me.ThetvdbLabelActorsTabActors.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.ThetvdbGroupBoxInformationTabActors.SuspendLayout()
            Me.panel1.SuspendLayout()
            Me.pnlEpisodeEnabled.SuspendLayout()
            Me.pnlActorsEnabled.SuspendLayout()
            Me.SuspendLayout()
            '
            'label5
            '
            Me.label5.AutoSize = True
            Me.label5.Location = New System.Drawing.Point(15, 30)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(0, 13)
            Me.label5.TabIndex = 4
            '
            'ThetvdbLabelEpisodesTabEpisodes
            '
            Me.ThetvdbLabelEpisodesTabEpisodes.BackColor = System.Drawing.Color.Transparent
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.lbDirectors)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.bcEpisodeBanner)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.lbWriters)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.lbGuestStars)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.pnlSeasonBanner)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.pnlSeasonBannerWide)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeImdbID)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeAbsoluteNumber)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelIDIMDBComTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelAbsoluteNumberTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeOverview)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeDVDChapter)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeFirstAired)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeDVDSeason)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeDVDNumber)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeLanguage)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeProductionCode)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.txtEpisodeDVDId)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelOverviewTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelGueststarTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelFirstAiredTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelDVDChapterTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelWriterTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelDVDSeasonTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelProductCodeTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelLanguageTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelDVDNumberTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelDirectorTabTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.ThetvdbLabelDVDIDTabEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Controls.Add(Me.tvEpisodes)
            Me.ThetvdbLabelEpisodesTabEpisodes.Location = New System.Drawing.Point(4, 19)
            Me.ThetvdbLabelEpisodesTabEpisodes.Name = "ThetvdbLabelEpisodesTabEpisodes"
            Me.ThetvdbLabelEpisodesTabEpisodes.Padding = New System.Windows.Forms.Padding(3)
            Me.ThetvdbLabelEpisodesTabEpisodes.Size = New System.Drawing.Size(764, 618)
            Me.ThetvdbLabelEpisodesTabEpisodes.TabIndex = 1
            Me.ThetvdbLabelEpisodesTabEpisodes.Text = "Episodes"
            Me.ThetvdbLabelEpisodesTabEpisodes.UseVisualStyleBackColor = True
            '
            'lbDirectors
            '
            Me.lbDirectors.FormattingEnabled = True
            Me.lbDirectors.Location = New System.Drawing.Point(417, 283)
            Me.lbDirectors.Name = "lbDirectors"
            Me.lbDirectors.Size = New System.Drawing.Size(134, 43)
            Me.lbDirectors.TabIndex = 87
            '
            'bcEpisodeBanner
            '
            Me.bcEpisodeBanner.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.bcEpisodeBanner.Cursor = System.Windows.Forms.Cursors.Default
            Me.bcEpisodeBanner.DefaultImage = Global.ZGuideTV.My.Resources.Resources.episode_notfound
            Me.bcEpisodeBanner.ImageSizeMode = System.Windows.Forms.ImageLayout.Zoom
            Me.bcEpisodeBanner.Index = 0
            Me.bcEpisodeBanner.LoadingBackgroundColor = System.Drawing.Color.Black
            Me.bcEpisodeBanner.LoadingImage = Global.ZGuideTV.My.Resources.Resources.loader4
            Me.bcEpisodeBanner.Location = New System.Drawing.Point(2, 298)
            Me.bcEpisodeBanner.Name = "bcEpisodeBanner"
            Me.bcEpisodeBanner.Size = New System.Drawing.Size(309, 209)
            Me.bcEpisodeBanner.TabIndex = 0
            Me.bcEpisodeBanner.UnavailableImage = Nothing
            Me.bcEpisodeBanner.UseThumb = False
            '
            'lbWriters
            '
            Me.lbWriters.FormattingEnabled = True
            Me.lbWriters.Location = New System.Drawing.Point(417, 407)
            Me.lbWriters.Name = "lbWriters"
            Me.lbWriters.Size = New System.Drawing.Size(134, 43)
            Me.lbWriters.TabIndex = 86
            '
            'lbGuestStars
            '
            Me.lbGuestStars.FormattingEnabled = True
            Me.lbGuestStars.Location = New System.Drawing.Point(417, 332)
            Me.lbGuestStars.Name = "lbGuestStars"
            Me.lbGuestStars.Size = New System.Drawing.Size(134, 69)
            Me.lbGuestStars.TabIndex = 86
            '
            'pnlSeasonBanner
            '
            Me.pnlSeasonBanner.BackColor = System.Drawing.SystemColors.Control
            Me.pnlSeasonBanner.Controls.Add(Me.bcSeasonBanner)
            Me.pnlSeasonBanner.Location = New System.Drawing.Point(555, 164)
            Me.pnlSeasonBanner.Name = "pnlSeasonBanner"
            Me.pnlSeasonBanner.Size = New System.Drawing.Size(205, 295)
            Me.pnlSeasonBanner.TabIndex = 84
            '
            'bcSeasonBanner
            '
            Me.bcSeasonBanner.BackColor = System.Drawing.SystemColors.Control
            Me.bcSeasonBanner.DefaultImage = Global.ZGuideTV.My.Resources.Resources.season_notfound
            Me.bcSeasonBanner.ImageSizeMode = System.Windows.Forms.ImageLayout.Stretch
            Me.bcSeasonBanner.Index = 0
            Me.bcSeasonBanner.LoadingBackgroundColor = System.Drawing.Color.Black
            Me.bcSeasonBanner.LoadingImage = Global.ZGuideTV.My.Resources.Resources.loader4
            Me.bcSeasonBanner.Location = New System.Drawing.Point(2, 4)
            Me.bcSeasonBanner.Name = "bcSeasonBanner"
            Me.bcSeasonBanner.Size = New System.Drawing.Size(200, 289)
            Me.bcSeasonBanner.TabIndex = 0
            Me.bcSeasonBanner.UnavailableImage = Nothing
            Me.bcSeasonBanner.UseThumb = True
            '
            'pnlSeasonBannerWide
            '
            Me.pnlSeasonBannerWide.BackColor = System.Drawing.SystemColors.Control
            Me.pnlSeasonBannerWide.Controls.Add(Me.bcSeasonBannerWide)
            Me.pnlSeasonBannerWide.Location = New System.Drawing.Point(0, 0)
            Me.pnlSeasonBannerWide.Name = "pnlSeasonBannerWide"
            Me.pnlSeasonBannerWide.Size = New System.Drawing.Size(763, 147)
            Me.pnlSeasonBannerWide.TabIndex = 83
            '
            'bcSeasonBannerWide
            '
            Me.bcSeasonBannerWide.BackColor = System.Drawing.SystemColors.Control
            Me.bcSeasonBannerWide.DefaultImage = Global.ZGuideTV.My.Resources.Resources.tvdb_logo
            Me.bcSeasonBannerWide.ImageSizeMode = System.Windows.Forms.ImageLayout.Stretch
            Me.bcSeasonBannerWide.Index = 0
            Me.bcSeasonBannerWide.LoadingBackgroundColor = System.Drawing.Color.Black
            Me.bcSeasonBannerWide.LoadingImage = Global.ZGuideTV.My.Resources.Resources.loader4
            Me.bcSeasonBannerWide.Location = New System.Drawing.Point(0, 0)
            Me.bcSeasonBannerWide.Name = "bcSeasonBannerWide"
            Me.bcSeasonBannerWide.Size = New System.Drawing.Size(765, 145)
            Me.bcSeasonBannerWide.TabIndex = 0
            Me.bcSeasonBannerWide.UnavailableImage = Nothing
            Me.bcSeasonBannerWide.UseThumb = False
            '
            'txtEpisodeImdbID
            '
            Me.txtEpisodeImdbID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeImdbID.BackColor = System.Drawing.Color.White
            Me.txtEpisodeImdbID.Location = New System.Drawing.Point(417, 236)
            Me.txtEpisodeImdbID.Name = "txtEpisodeImdbID"
            Me.txtEpisodeImdbID.ReadOnly = True
            Me.txtEpisodeImdbID.Size = New System.Drawing.Size(126, 20)
            Me.txtEpisodeImdbID.TabIndex = 81
            '
            'txtEpisodeAbsoluteNumber
            '
            Me.txtEpisodeAbsoluteNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeAbsoluteNumber.BackColor = System.Drawing.Color.White
            Me.txtEpisodeAbsoluteNumber.Location = New System.Drawing.Point(417, 211)
            Me.txtEpisodeAbsoluteNumber.Name = "txtEpisodeAbsoluteNumber"
            Me.txtEpisodeAbsoluteNumber.ReadOnly = True
            Me.txtEpisodeAbsoluteNumber.Size = New System.Drawing.Size(126, 20)
            Me.txtEpisodeAbsoluteNumber.TabIndex = 82
            '
            'ThetvdbLabelIDIMDBComTabEpisodes
            '
            Me.ThetvdbLabelIDIMDBComTabEpisodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ThetvdbLabelIDIMDBComTabEpisodes.AutoSize = True
            Me.ThetvdbLabelIDIMDBComTabEpisodes.Location = New System.Drawing.Point(319, 239)
            Me.ThetvdbLabelIDIMDBComTabEpisodes.Name = "ThetvdbLabelIDIMDBComTabEpisodes"
            Me.ThetvdbLabelIDIMDBComTabEpisodes.Size = New System.Drawing.Size(74, 13)
            Me.ThetvdbLabelIDIMDBComTabEpisodes.TabIndex = 79
            Me.ThetvdbLabelIDIMDBComTabEpisodes.Text = "IMDB.com ID:"
            '
            'ThetvdbLabelAbsoluteNumberTabEpisodes
            '
            Me.ThetvdbLabelAbsoluteNumberTabEpisodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ThetvdbLabelAbsoluteNumberTabEpisodes.AutoSize = True
            Me.ThetvdbLabelAbsoluteNumberTabEpisodes.Location = New System.Drawing.Point(319, 214)
            Me.ThetvdbLabelAbsoluteNumberTabEpisodes.Name = "ThetvdbLabelAbsoluteNumberTabEpisodes"
            Me.ThetvdbLabelAbsoluteNumberTabEpisodes.Size = New System.Drawing.Size(91, 13)
            Me.ThetvdbLabelAbsoluteNumberTabEpisodes.TabIndex = 80
            Me.ThetvdbLabelAbsoluteNumberTabEpisodes.Text = "Absolute Number:"
            '
            'txtEpisodeOverview
            '
            Me.txtEpisodeOverview.BackColor = System.Drawing.Color.White
            Me.txtEpisodeOverview.Location = New System.Drawing.Point(414, 465)
            Me.txtEpisodeOverview.Name = "txtEpisodeOverview"
            Me.txtEpisodeOverview.ReadOnly = True
            Me.txtEpisodeOverview.Size = New System.Drawing.Size(343, 152)
            Me.txtEpisodeOverview.TabIndex = 75
            Me.txtEpisodeOverview.Text = ""
            '
            'txtEpisodeDVDChapter
            '
            Me.txtEpisodeDVDChapter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeDVDChapter.BackColor = System.Drawing.Color.White
            Me.txtEpisodeDVDChapter.Location = New System.Drawing.Point(265, 530)
            Me.txtEpisodeDVDChapter.Name = "txtEpisodeDVDChapter"
            Me.txtEpisodeDVDChapter.ReadOnly = True
            Me.txtEpisodeDVDChapter.Size = New System.Drawing.Size(43, 20)
            Me.txtEpisodeDVDChapter.TabIndex = 66
            '
            'txtEpisodeFirstAired
            '
            Me.txtEpisodeFirstAired.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeFirstAired.BackColor = System.Drawing.Color.White
            Me.txtEpisodeFirstAired.Location = New System.Drawing.Point(417, 187)
            Me.txtEpisodeFirstAired.Name = "txtEpisodeFirstAired"
            Me.txtEpisodeFirstAired.ReadOnly = True
            Me.txtEpisodeFirstAired.Size = New System.Drawing.Size(126, 20)
            Me.txtEpisodeFirstAired.TabIndex = 67
            '
            'txtEpisodeDVDSeason
            '
            Me.txtEpisodeDVDSeason.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeDVDSeason.BackColor = System.Drawing.Color.White
            Me.txtEpisodeDVDSeason.Location = New System.Drawing.Point(96, 566)
            Me.txtEpisodeDVDSeason.Name = "txtEpisodeDVDSeason"
            Me.txtEpisodeDVDSeason.ReadOnly = True
            Me.txtEpisodeDVDSeason.Size = New System.Drawing.Size(43, 20)
            Me.txtEpisodeDVDSeason.TabIndex = 64
            '
            'txtEpisodeDVDNumber
            '
            Me.txtEpisodeDVDNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeDVDNumber.BackColor = System.Drawing.Color.White
            Me.txtEpisodeDVDNumber.Location = New System.Drawing.Point(265, 566)
            Me.txtEpisodeDVDNumber.Name = "txtEpisodeDVDNumber"
            Me.txtEpisodeDVDNumber.ReadOnly = True
            Me.txtEpisodeDVDNumber.Size = New System.Drawing.Size(43, 20)
            Me.txtEpisodeDVDNumber.TabIndex = 72
            '
            'txtEpisodeLanguage
            '
            Me.txtEpisodeLanguage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeLanguage.BackColor = System.Drawing.Color.White
            Me.txtEpisodeLanguage.Location = New System.Drawing.Point(417, 163)
            Me.txtEpisodeLanguage.Name = "txtEpisodeLanguage"
            Me.txtEpisodeLanguage.ReadOnly = True
            Me.txtEpisodeLanguage.Size = New System.Drawing.Size(126, 20)
            Me.txtEpisodeLanguage.TabIndex = 73
            '
            'txtEpisodeProductionCode
            '
            Me.txtEpisodeProductionCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeProductionCode.BackColor = System.Drawing.Color.White
            Me.txtEpisodeProductionCode.Location = New System.Drawing.Point(417, 260)
            Me.txtEpisodeProductionCode.Name = "txtEpisodeProductionCode"
            Me.txtEpisodeProductionCode.ReadOnly = True
            Me.txtEpisodeProductionCode.Size = New System.Drawing.Size(126, 20)
            Me.txtEpisodeProductionCode.TabIndex = 71
            '
            'txtEpisodeDVDId
            '
            Me.txtEpisodeDVDId.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtEpisodeDVDId.BackColor = System.Drawing.Color.White
            Me.txtEpisodeDVDId.Location = New System.Drawing.Point(96, 530)
            Me.txtEpisodeDVDId.Name = "txtEpisodeDVDId"
            Me.txtEpisodeDVDId.ReadOnly = True
            Me.txtEpisodeDVDId.Size = New System.Drawing.Size(43, 20)
            Me.txtEpisodeDVDId.TabIndex = 69
            '
            'ThetvdbLabelOverviewTabEpisodes
            '
            Me.ThetvdbLabelOverviewTabEpisodes.AutoSize = True
            Me.ThetvdbLabelOverviewTabEpisodes.Location = New System.Drawing.Point(320, 479)
            Me.ThetvdbLabelOverviewTabEpisodes.Name = "ThetvdbLabelOverviewTabEpisodes"
            Me.ThetvdbLabelOverviewTabEpisodes.Size = New System.Drawing.Size(55, 13)
            Me.ThetvdbLabelOverviewTabEpisodes.TabIndex = 60
            Me.ThetvdbLabelOverviewTabEpisodes.Text = "Overview:"
            '
            'ThetvdbLabelGueststarTabEpisodes
            '
            Me.ThetvdbLabelGueststarTabEpisodes.AutoSize = True
            Me.ThetvdbLabelGueststarTabEpisodes.Location = New System.Drawing.Point(319, 332)
            Me.ThetvdbLabelGueststarTabEpisodes.Name = "ThetvdbLabelGueststarTabEpisodes"
            Me.ThetvdbLabelGueststarTabEpisodes.Size = New System.Drawing.Size(65, 13)
            Me.ThetvdbLabelGueststarTabEpisodes.TabIndex = 59
            Me.ThetvdbLabelGueststarTabEpisodes.Text = "Guest Stars:"
            '
            'ThetvdbLabelFirstAiredTabEpisodes
            '
            Me.ThetvdbLabelFirstAiredTabEpisodes.AutoSize = True
            Me.ThetvdbLabelFirstAiredTabEpisodes.Location = New System.Drawing.Point(319, 190)
            Me.ThetvdbLabelFirstAiredTabEpisodes.Name = "ThetvdbLabelFirstAiredTabEpisodes"
            Me.ThetvdbLabelFirstAiredTabEpisodes.Size = New System.Drawing.Size(56, 13)
            Me.ThetvdbLabelFirstAiredTabEpisodes.TabIndex = 49
            Me.ThetvdbLabelFirstAiredTabEpisodes.Text = "First Aired:"
            '
            'ThetvdbLabelDVDChapterTabEpisodes
            '
            Me.ThetvdbLabelDVDChapterTabEpisodes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ThetvdbLabelDVDChapterTabEpisodes.AutoSize = True
            Me.ThetvdbLabelDVDChapterTabEpisodes.Location = New System.Drawing.Point(168, 533)
            Me.ThetvdbLabelDVDChapterTabEpisodes.Name = "ThetvdbLabelDVDChapterTabEpisodes"
            Me.ThetvdbLabelDVDChapterTabEpisodes.Size = New System.Drawing.Size(73, 13)
            Me.ThetvdbLabelDVDChapterTabEpisodes.TabIndex = 50
            Me.ThetvdbLabelDVDChapterTabEpisodes.Text = "DVD Chapter:"
            '
            'ThetvdbLabelWriterTabEpisodes
            '
            Me.ThetvdbLabelWriterTabEpisodes.AutoSize = True
            Me.ThetvdbLabelWriterTabEpisodes.Location = New System.Drawing.Point(319, 407)
            Me.ThetvdbLabelWriterTabEpisodes.Name = "ThetvdbLabelWriterTabEpisodes"
            Me.ThetvdbLabelWriterTabEpisodes.Size = New System.Drawing.Size(38, 13)
            Me.ThetvdbLabelWriterTabEpisodes.TabIndex = 51
            Me.ThetvdbLabelWriterTabEpisodes.Text = "Writer:"
            '
            'ThetvdbLabelDVDSeasonTabEpisodes
            '
            Me.ThetvdbLabelDVDSeasonTabEpisodes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ThetvdbLabelDVDSeasonTabEpisodes.AutoSize = True
            Me.ThetvdbLabelDVDSeasonTabEpisodes.Location = New System.Drawing.Point(6, 533)
            Me.ThetvdbLabelDVDSeasonTabEpisodes.Name = "ThetvdbLabelDVDSeasonTabEpisodes"
            Me.ThetvdbLabelDVDSeasonTabEpisodes.Size = New System.Drawing.Size(72, 13)
            Me.ThetvdbLabelDVDSeasonTabEpisodes.TabIndex = 48
            Me.ThetvdbLabelDVDSeasonTabEpisodes.Text = "DVD Season:"
            '
            'ThetvdbLabelProductCodeTabEpisodes
            '
            Me.ThetvdbLabelProductCodeTabEpisodes.AutoSize = True
            Me.ThetvdbLabelProductCodeTabEpisodes.Location = New System.Drawing.Point(319, 263)
            Me.ThetvdbLabelProductCodeTabEpisodes.Name = "ThetvdbLabelProductCodeTabEpisodes"
            Me.ThetvdbLabelProductCodeTabEpisodes.Size = New System.Drawing.Size(89, 13)
            Me.ThetvdbLabelProductCodeTabEpisodes.TabIndex = 52
            Me.ThetvdbLabelProductCodeTabEpisodes.Text = "Production Code:"
            '
            'ThetvdbLabelLanguageTabEpisodes
            '
            Me.ThetvdbLabelLanguageTabEpisodes.AutoSize = True
            Me.ThetvdbLabelLanguageTabEpisodes.Location = New System.Drawing.Point(319, 166)
            Me.ThetvdbLabelLanguageTabEpisodes.Name = "ThetvdbLabelLanguageTabEpisodes"
            Me.ThetvdbLabelLanguageTabEpisodes.Size = New System.Drawing.Size(58, 13)
            Me.ThetvdbLabelLanguageTabEpisodes.TabIndex = 56
            Me.ThetvdbLabelLanguageTabEpisodes.Text = "Language:"
            '
            'ThetvdbLabelDVDNumberTabEpisodes
            '
            Me.ThetvdbLabelDVDNumberTabEpisodes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ThetvdbLabelDVDNumberTabEpisodes.AutoSize = True
            Me.ThetvdbLabelDVDNumberTabEpisodes.Location = New System.Drawing.Point(168, 569)
            Me.ThetvdbLabelDVDNumberTabEpisodes.Name = "ThetvdbLabelDVDNumberTabEpisodes"
            Me.ThetvdbLabelDVDNumberTabEpisodes.Size = New System.Drawing.Size(89, 13)
            Me.ThetvdbLabelDVDNumberTabEpisodes.TabIndex = 57
            Me.ThetvdbLabelDVDNumberTabEpisodes.Text = "DVD Ep Number:"
            '
            'ThetvdbLabelDirectorTabTabEpisodes
            '
            Me.ThetvdbLabelDirectorTabTabEpisodes.AutoSize = True
            Me.ThetvdbLabelDirectorTabTabEpisodes.Location = New System.Drawing.Point(319, 288)
            Me.ThetvdbLabelDirectorTabTabEpisodes.Name = "ThetvdbLabelDirectorTabTabEpisodes"
            Me.ThetvdbLabelDirectorTabTabEpisodes.Size = New System.Drawing.Size(47, 13)
            Me.ThetvdbLabelDirectorTabTabEpisodes.TabIndex = 58
            Me.ThetvdbLabelDirectorTabTabEpisodes.Text = "Director:"
            '
            'ThetvdbLabelDVDIDTabEpisodes
            '
            Me.ThetvdbLabelDVDIDTabEpisodes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ThetvdbLabelDVDIDTabEpisodes.AutoSize = True
            Me.ThetvdbLabelDVDIDTabEpisodes.Location = New System.Drawing.Point(6, 568)
            Me.ThetvdbLabelDVDIDTabEpisodes.Name = "ThetvdbLabelDVDIDTabEpisodes"
            Me.ThetvdbLabelDVDIDTabEpisodes.Size = New System.Drawing.Size(71, 13)
            Me.ThetvdbLabelDVDIDTabEpisodes.TabIndex = 55
            Me.ThetvdbLabelDVDIDTabEpisodes.Text = "DVD Disc ID:"
            '
            'tvEpisodes
            '
            Me.tvEpisodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tvEpisodes.Location = New System.Drawing.Point(3, 168)
            Me.tvEpisodes.Name = "tvEpisodes"
            Me.tvEpisodes.Size = New System.Drawing.Size(309, 125)
            Me.tvEpisodes.TabIndex = 43
            '
            'showImageToolStripMenuItem
            '
            Me.showImageToolStripMenuItem.Name = "showImageToolStripMenuItem"
            Me.showImageToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
            Me.showImageToolStripMenuItem.Text = "Show Image"
            '
            'copyToClipboardToolStripMenuItem
            '
            Me.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem"
            Me.copyToClipboardToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
            Me.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard"
            '
            'saveImageToolStripMenuItem1
            '
            Me.saveImageToolStripMenuItem1.Name = "saveImageToolStripMenuItem1"
            Me.saveImageToolStripMenuItem1.Size = New System.Drawing.Size(171, 22)
            Me.saveImageToolStripMenuItem1.Text = "Save Image"
            '
            'ThetvdbLabelSeriesTabSeries
            '
            Me.ThetvdbLabelSeriesTabSeries.BackColor = System.Drawing.Color.Transparent
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbButtonSearchShow)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbButtonExit)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbButtonForceUpdate)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.lbGenre)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.lbActors)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.llblImdb)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.llblTvComId)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.raterSeriesSiteRating)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.panelSeriesBannerFrame)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.posterControlSeries)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.txtOverview)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.txtRuntime)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.txtImdbId)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.txtSeriesName)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.txtRating)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.txtFirstAired)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.txtTvComId)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.txtSeriesId)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelActors)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelRuntime)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelGenre)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelIDIMDB)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelSearchName1)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelRating)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelFirstAired)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelIDTVCom)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelSiteRating)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelDescription)
            Me.ThetvdbLabelSeriesTabSeries.Controls.Add(Me.ThetvdbLabelID)
            Me.ThetvdbLabelSeriesTabSeries.Location = New System.Drawing.Point(4, 19)
            Me.ThetvdbLabelSeriesTabSeries.Name = "ThetvdbLabelSeriesTabSeries"
            Me.ThetvdbLabelSeriesTabSeries.Padding = New System.Windows.Forms.Padding(3)
            Me.ThetvdbLabelSeriesTabSeries.Size = New System.Drawing.Size(764, 618)
            Me.ThetvdbLabelSeriesTabSeries.TabIndex = 0
            Me.ThetvdbLabelSeriesTabSeries.Text = "Series"
            Me.ThetvdbLabelSeriesTabSeries.UseVisualStyleBackColor = True
            '
            'ThetvdbButtonSearchShow
            '
            Me.ThetvdbButtonSearchShow.Location = New System.Drawing.Point(554, 136)
            Me.ThetvdbButtonSearchShow.Name = "ThetvdbButtonSearchShow"
            Me.ThetvdbButtonSearchShow.Size = New System.Drawing.Size(99, 23)
            Me.ThetvdbButtonSearchShow.TabIndex = 55
            Me.ThetvdbButtonSearchShow.Text = "Search"
            Me.ThetvdbButtonSearchShow.UseVisualStyleBackColor = True
            Me.ThetvdbButtonSearchShow.Visible = False
            '
            'ThetvdbButtonExit
            '
            Me.ThetvdbButtonExit.Location = New System.Drawing.Point(655, 136)
            Me.ThetvdbButtonExit.Name = "ThetvdbButtonExit"
            Me.ThetvdbButtonExit.Size = New System.Drawing.Size(99, 23)
            Me.ThetvdbButtonExit.TabIndex = 54
            Me.ThetvdbButtonExit.Text = "Exit"
            Me.ThetvdbButtonExit.UseVisualStyleBackColor = True
            '
            'ThetvdbButtonForceUpdate
            '
            Me.ThetvdbButtonForceUpdate.Enabled = False
            Me.ThetvdbButtonForceUpdate.Location = New System.Drawing.Point(452, 136)
            Me.ThetvdbButtonForceUpdate.Name = "ThetvdbButtonForceUpdate"
            Me.ThetvdbButtonForceUpdate.Size = New System.Drawing.Size(99, 23)
            Me.ThetvdbButtonForceUpdate.TabIndex = 41
            Me.ThetvdbButtonForceUpdate.Text = "Reload"
            Me.ThetvdbButtonForceUpdate.UseVisualStyleBackColor = True
            Me.ThetvdbButtonForceUpdate.Visible = False
            '
            'lbGenre
            '
            Me.lbGenre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lbGenre.CausesValidation = False
            Me.lbGenre.FormattingEnabled = True
            Me.lbGenre.Location = New System.Drawing.Point(103, 180)
            Me.lbGenre.Name = "lbGenre"
            Me.lbGenre.SelectionMode = System.Windows.Forms.SelectionMode.None
            Me.lbGenre.Size = New System.Drawing.Size(285, 41)
            Me.lbGenre.TabIndex = 53
            '
            'lbActors
            '
            Me.lbActors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lbActors.CausesValidation = False
            Me.lbActors.FormattingEnabled = True
            Me.lbActors.Location = New System.Drawing.Point(103, 305)
            Me.lbActors.Name = "lbActors"
            Me.lbActors.SelectionMode = System.Windows.Forms.SelectionMode.None
            Me.lbActors.Size = New System.Drawing.Size(285, 106)
            Me.lbActors.TabIndex = 52
            '
            'llblImdb
            '
            Me.llblImdb.AutoSize = True
            Me.llblImdb.Location = New System.Drawing.Point(653, 225)
            Me.llblImdb.Name = "llblImdb"
            Me.llblImdb.Size = New System.Drawing.Size(0, 13)
            Me.llblImdb.TabIndex = 51
            '
            'llblTvComId
            '
            Me.llblTvComId.AutoSize = True
            Me.llblTvComId.Location = New System.Drawing.Point(653, 198)
            Me.llblTvComId.Name = "llblTvComId"
            Me.llblTvComId.Size = New System.Drawing.Size(0, 13)
            Me.llblTvComId.TabIndex = 51
            '
            'raterSeriesSiteRating
            '
            Me.raterSeriesSiteRating.CurrentRating = 0
            Me.raterSeriesSiteRating.Enabled = False
            Me.raterSeriesSiteRating.LabelAlignment = System.Drawing.ContentAlignment.MiddleCenter
            Me.raterSeriesSiteRating.LabelFormatString = "{0} / {1}"
            Me.raterSeriesSiteRating.LabelText = "RateLabel"
            Me.raterSeriesSiteRating.LabelTextItems = New String() {"Poor", "Fair", "Good", "Better", "Best"}
            Me.raterSeriesSiteRating.LabelTypeHover = ZGuideTV.Rater.eLabelType.FormatString
            Me.raterSeriesSiteRating.LabelTypeText = ZGuideTV.Rater.eLabelType.FormatString
            Me.raterSeriesSiteRating.Location = New System.Drawing.Point(130, 597)
            Me.raterSeriesSiteRating.MaxRating = 10
            Me.raterSeriesSiteRating.Name = "raterSeriesSiteRating"
            Me.raterSeriesSiteRating.RadiusInner = 0.0!
            Me.raterSeriesSiteRating.RadiusOuter = 7.0!
            Me.raterSeriesSiteRating.Shape = ZGuideTV.Rater.eShape.Star
            Me.raterSeriesSiteRating.ShapeBorderEmptyColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(21, Byte), Integer))
            Me.raterSeriesSiteRating.ShapeBorderFilledColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(21, Byte), Integer))
            Me.raterSeriesSiteRating.ShapeBorderHoverColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(21, Byte), Integer))
            Me.raterSeriesSiteRating.ShapeBorderWidth = 2
            Me.raterSeriesSiteRating.ShapeColorFill = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(21, Byte), Integer))
            Me.raterSeriesSiteRating.ShapeColorHover = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(21, Byte), Integer))
            Me.raterSeriesSiteRating.ShapeNumberShow = ZGuideTV.Rater.eShapeNumberShow.None
            Me.raterSeriesSiteRating.Size = New System.Drawing.Size(251, 15)
            Me.raterSeriesSiteRating.TabIndex = 46
            '
            'panelSeriesBannerFrame
            '
            Me.panelSeriesBannerFrame.BackColor = System.Drawing.Color.White
            Me.panelSeriesBannerFrame.Controls.Add(Me.bcSeriesBanner)
            Me.panelSeriesBannerFrame.ForeColor = System.Drawing.SystemColors.Control
            Me.panelSeriesBannerFrame.Location = New System.Drawing.Point(0, 2)
            Me.panelSeriesBannerFrame.Name = "panelSeriesBannerFrame"
            Me.panelSeriesBannerFrame.Size = New System.Drawing.Size(763, 147)
            Me.panelSeriesBannerFrame.TabIndex = 45
            '
            'bcSeriesBanner
            '
            Me.bcSeriesBanner.BackColor = System.Drawing.Color.DarkGray
            Me.bcSeriesBanner.DefaultImage = Global.ZGuideTV.My.Resources.Resources.tvdb_logo
            Me.bcSeriesBanner.ImageSizeMode = System.Windows.Forms.ImageLayout.Stretch
            Me.bcSeriesBanner.Index = 0
            Me.bcSeriesBanner.LoadingBackgroundColor = System.Drawing.Color.Black
            Me.bcSeriesBanner.LoadingImage = Global.ZGuideTV.My.Resources.Resources.loader4
            Me.bcSeriesBanner.Location = New System.Drawing.Point(0, 0)
            Me.bcSeriesBanner.Name = "bcSeriesBanner"
            Me.bcSeriesBanner.Size = New System.Drawing.Size(765, 145)
            Me.bcSeriesBanner.TabIndex = 0
            Me.bcSeriesBanner.UnavailableImage = Nothing
            Me.bcSeriesBanner.UseThumb = False
            '
            'posterControlSeries
            '
            Me.posterControlSeries.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.posterControlSeries.Location = New System.Drawing.Point(440, 246)
            Me.posterControlSeries.Name = "posterControlSeries"
            Me.posterControlSeries.Size = New System.Drawing.Size(280, 365)
            Me.posterControlSeries.TabIndex = 44
            '
            'txtOverview
            '
            Me.txtOverview.BackColor = System.Drawing.Color.White
            Me.txtOverview.Location = New System.Drawing.Point(103, 417)
            Me.txtOverview.Name = "txtOverview"
            Me.txtOverview.ReadOnly = True
            Me.txtOverview.Size = New System.Drawing.Size(285, 174)
            Me.txtOverview.TabIndex = 39
            Me.txtOverview.Text = ""
            '
            'txtRuntime
            '
            Me.txtRuntime.BackColor = System.Drawing.Color.White
            Me.txtRuntime.Location = New System.Drawing.Point(103, 253)
            Me.txtRuntime.Name = "txtRuntime"
            Me.txtRuntime.ReadOnly = True
            Me.txtRuntime.Size = New System.Drawing.Size(285, 20)
            Me.txtRuntime.TabIndex = 30
            '
            'txtImdbId
            '
            Me.txtImdbId.BackColor = System.Drawing.Color.White
            Me.txtImdbId.Location = New System.Drawing.Point(494, 220)
            Me.txtImdbId.Name = "txtImdbId"
            Me.txtImdbId.ReadOnly = True
            Me.txtImdbId.Size = New System.Drawing.Size(136, 20)
            Me.txtImdbId.TabIndex = 26
            '
            'txtSeriesName
            '
            Me.txtSeriesName.BackColor = System.Drawing.Color.White
            Me.txtSeriesName.Location = New System.Drawing.Point(103, 154)
            Me.txtSeriesName.Name = "txtSeriesName"
            Me.txtSeriesName.ReadOnly = True
            Me.txtSeriesName.Size = New System.Drawing.Size(285, 20)
            Me.txtSeriesName.TabIndex = 27
            '
            'txtRating
            '
            Me.txtRating.BackColor = System.Drawing.Color.White
            Me.txtRating.Location = New System.Drawing.Point(103, 279)
            Me.txtRating.Name = "txtRating"
            Me.txtRating.ReadOnly = True
            Me.txtRating.Size = New System.Drawing.Size(285, 20)
            Me.txtRating.TabIndex = 36
            '
            'txtFirstAired
            '
            Me.txtFirstAired.BackColor = System.Drawing.Color.White
            Me.txtFirstAired.Location = New System.Drawing.Point(103, 227)
            Me.txtFirstAired.Name = "txtFirstAired"
            Me.txtFirstAired.ReadOnly = True
            Me.txtFirstAired.Size = New System.Drawing.Size(285, 20)
            Me.txtFirstAired.TabIndex = 32
            '
            'txtTvComId
            '
            Me.txtTvComId.BackColor = System.Drawing.Color.White
            Me.txtTvComId.Location = New System.Drawing.Point(494, 194)
            Me.txtTvComId.Name = "txtTvComId"
            Me.txtTvComId.ReadOnly = True
            Me.txtTvComId.Size = New System.Drawing.Size(136, 20)
            Me.txtTvComId.TabIndex = 33
            '
            'txtSeriesId
            '
            Me.txtSeriesId.BackColor = System.Drawing.Color.White
            Me.txtSeriesId.Location = New System.Drawing.Point(494, 168)
            Me.txtSeriesId.Name = "txtSeriesId"
            Me.txtSeriesId.ReadOnly = True
            Me.txtSeriesId.Size = New System.Drawing.Size(250, 20)
            Me.txtSeriesId.TabIndex = 34
            '
            'ThetvdbLabelActors
            '
            Me.ThetvdbLabelActors.AutoSize = True
            Me.ThetvdbLabelActors.Location = New System.Drawing.Point(27, 305)
            Me.ThetvdbLabelActors.Name = "ThetvdbLabelActors"
            Me.ThetvdbLabelActors.Size = New System.Drawing.Size(40, 13)
            Me.ThetvdbLabelActors.TabIndex = 24
            Me.ThetvdbLabelActors.Text = "Actors:"
            '
            'ThetvdbLabelRuntime
            '
            Me.ThetvdbLabelRuntime.AutoSize = True
            Me.ThetvdbLabelRuntime.Location = New System.Drawing.Point(27, 256)
            Me.ThetvdbLabelRuntime.Name = "ThetvdbLabelRuntime"
            Me.ThetvdbLabelRuntime.Size = New System.Drawing.Size(49, 13)
            Me.ThetvdbLabelRuntime.TabIndex = 14
            Me.ThetvdbLabelRuntime.Text = "Runtime:"
            '
            'ThetvdbLabelGenre
            '
            Me.ThetvdbLabelGenre.AutoSize = True
            Me.ThetvdbLabelGenre.Location = New System.Drawing.Point(27, 180)
            Me.ThetvdbLabelGenre.Name = "ThetvdbLabelGenre"
            Me.ThetvdbLabelGenre.Size = New System.Drawing.Size(39, 13)
            Me.ThetvdbLabelGenre.TabIndex = 15
            Me.ThetvdbLabelGenre.Text = "Genre:"
            '
            'ThetvdbLabelIDIMDB
            '
            Me.ThetvdbLabelIDIMDB.AutoSize = True
            Me.ThetvdbLabelIDIMDB.Location = New System.Drawing.Point(410, 223)
            Me.ThetvdbLabelIDIMDB.Name = "ThetvdbLabelIDIMDB"
            Me.ThetvdbLabelIDIMDB.Size = New System.Drawing.Size(74, 13)
            Me.ThetvdbLabelIDIMDB.TabIndex = 13
            Me.ThetvdbLabelIDIMDB.Text = "IMDB.com ID:"
            '
            'ThetvdbLabelSearchName1
            '
            Me.ThetvdbLabelSearchName1.AutoSize = True
            Me.ThetvdbLabelSearchName1.Location = New System.Drawing.Point(27, 157)
            Me.ThetvdbLabelSearchName1.Name = "ThetvdbLabelSearchName1"
            Me.ThetvdbLabelSearchName1.Size = New System.Drawing.Size(38, 13)
            Me.ThetvdbLabelSearchName1.TabIndex = 11
            Me.ThetvdbLabelSearchName1.Text = "Name:"
            '
            'ThetvdbLabelRating
            '
            Me.ThetvdbLabelRating.AutoSize = True
            Me.ThetvdbLabelRating.Location = New System.Drawing.Point(27, 282)
            Me.ThetvdbLabelRating.Name = "ThetvdbLabelRating"
            Me.ThetvdbLabelRating.Size = New System.Drawing.Size(41, 13)
            Me.ThetvdbLabelRating.TabIndex = 12
            Me.ThetvdbLabelRating.Text = "Rating:"
            '
            'ThetvdbLabelFirstAired
            '
            Me.ThetvdbLabelFirstAired.AutoSize = True
            Me.ThetvdbLabelFirstAired.Location = New System.Drawing.Point(27, 230)
            Me.ThetvdbLabelFirstAired.Name = "ThetvdbLabelFirstAired"
            Me.ThetvdbLabelFirstAired.Size = New System.Drawing.Size(56, 13)
            Me.ThetvdbLabelFirstAired.TabIndex = 20
            Me.ThetvdbLabelFirstAired.Text = "First Aired:"
            '
            'ThetvdbLabelIDTVCom
            '
            Me.ThetvdbLabelIDTVCom.AutoSize = True
            Me.ThetvdbLabelIDTVCom.Location = New System.Drawing.Point(410, 197)
            Me.ThetvdbLabelIDTVCom.Name = "ThetvdbLabelIDTVCom"
            Me.ThetvdbLabelIDTVCom.Size = New System.Drawing.Size(61, 13)
            Me.ThetvdbLabelIDTVCom.TabIndex = 17
            Me.ThetvdbLabelIDTVCom.Text = "TV.com ID:"
            '
            'ThetvdbLabelSiteRating
            '
            Me.ThetvdbLabelSiteRating.AutoSize = True
            Me.ThetvdbLabelSiteRating.Location = New System.Drawing.Point(28, 597)
            Me.ThetvdbLabelSiteRating.Name = "ThetvdbLabelSiteRating"
            Me.ThetvdbLabelSiteRating.Size = New System.Drawing.Size(62, 13)
            Me.ThetvdbLabelSiteRating.TabIndex = 18
            Me.ThetvdbLabelSiteRating.Text = "Site Rating:"
            '
            'ThetvdbLabelDescription
            '
            Me.ThetvdbLabelDescription.AutoSize = True
            Me.ThetvdbLabelDescription.Location = New System.Drawing.Point(28, 420)
            Me.ThetvdbLabelDescription.Name = "ThetvdbLabelDescription"
            Me.ThetvdbLabelDescription.Size = New System.Drawing.Size(55, 13)
            Me.ThetvdbLabelDescription.TabIndex = 18
            Me.ThetvdbLabelDescription.Text = "Overview:"
            '
            'ThetvdbLabelID
            '
            Me.ThetvdbLabelID.AutoSize = True
            Me.ThetvdbLabelID.Location = New System.Drawing.Point(410, 171)
            Me.ThetvdbLabelID.Name = "ThetvdbLabelID"
            Me.ThetvdbLabelID.Size = New System.Drawing.Size(53, 13)
            Me.ThetvdbLabelID.TabIndex = 19
            Me.ThetvdbLabelID.Text = "Series ID:"
            '
            'ThetvdbTabControlTvdb
            '
            Me.ThetvdbTabControlTvdb.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.ThetvdbTabControlTvdb.Controls.Add(Me.ThetvdbLabelSeriesTabSeries)
            Me.ThetvdbTabControlTvdb.Controls.Add(Me.ThetvdbLabelEpisodesTabEpisodes)
            Me.ThetvdbTabControlTvdb.Controls.Add(Me.ThetvdbLabelActorsTabActors)
            Me.ThetvdbTabControlTvdb.ItemSize = New System.Drawing.Size(180, 15)
            Me.ThetvdbTabControlTvdb.Location = New System.Drawing.Point(6, 4)
            Me.ThetvdbTabControlTvdb.MinimumSize = New System.Drawing.Size(772, 641)
            Me.ThetvdbTabControlTvdb.Multiline = True
            Me.ThetvdbTabControlTvdb.Name = "ThetvdbTabControlTvdb"
            Me.ThetvdbTabControlTvdb.SelectedIndex = 0
            Me.ThetvdbTabControlTvdb.Size = New System.Drawing.Size(772, 641)
            Me.ThetvdbTabControlTvdb.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
            Me.ThetvdbTabControlTvdb.TabIndex = 46
            '
            'ThetvdbLabelActorsTabActors
            '
            Me.ThetvdbLabelActorsTabActors.Controls.Add(Me.Panel2)
            Me.ThetvdbLabelActorsTabActors.Controls.Add(Me.ThetvdbActors)
            Me.ThetvdbLabelActorsTabActors.Controls.Add(Me.ThetvdbGroupBoxInformationTabActors)
            Me.ThetvdbLabelActorsTabActors.Controls.Add(Me.panel1)
            Me.ThetvdbLabelActorsTabActors.Location = New System.Drawing.Point(4, 19)
            Me.ThetvdbLabelActorsTabActors.Name = "ThetvdbLabelActorsTabActors"
            Me.ThetvdbLabelActorsTabActors.Padding = New System.Windows.Forms.Padding(3)
            Me.ThetvdbLabelActorsTabActors.Size = New System.Drawing.Size(764, 618)
            Me.ThetvdbLabelActorsTabActors.TabIndex = 3
            Me.ThetvdbLabelActorsTabActors.Text = "Actors"
            Me.ThetvdbLabelActorsTabActors.UseVisualStyleBackColor = True
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.SystemColors.Control
            Me.Panel2.Controls.Add(Me.BannerControl1)
            Me.Panel2.Location = New System.Drawing.Point(0, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(763, 147)
            Me.Panel2.TabIndex = 84
            '
            'BannerControl1
            '
            Me.BannerControl1.BackColor = System.Drawing.SystemColors.Control
            Me.BannerControl1.DefaultImage = Global.ZGuideTV.My.Resources.Resources.tvdb_logo
            Me.BannerControl1.ImageSizeMode = System.Windows.Forms.ImageLayout.Stretch
            Me.BannerControl1.Index = 0
            Me.BannerControl1.LoadingBackgroundColor = System.Drawing.Color.Black
            Me.BannerControl1.LoadingImage = Global.ZGuideTV.My.Resources.Resources.loader4
            Me.BannerControl1.Location = New System.Drawing.Point(0, 0)
            Me.BannerControl1.Name = "BannerControl1"
            Me.BannerControl1.Size = New System.Drawing.Size(765, 145)
            Me.BannerControl1.TabIndex = 0
            Me.BannerControl1.UnavailableImage = Nothing
            Me.BannerControl1.UseThumb = False
            '
            'ThetvdbActors
            '
            Me.ThetvdbActors.FormattingEnabled = True
            Me.ThetvdbActors.Location = New System.Drawing.Point(127, 159)
            Me.ThetvdbActors.Name = "ThetvdbActors"
            Me.ThetvdbActors.Size = New System.Drawing.Size(230, 290)
            Me.ThetvdbActors.TabIndex = 6
            '
            'ThetvdbGroupBoxInformationTabActors
            '
            Me.ThetvdbGroupBoxInformationTabActors.Controls.Add(Me.txtActorSortOrder)
            Me.ThetvdbGroupBoxInformationTabActors.Controls.Add(Me.ThetvdbLabelIDTabActors)
            Me.ThetvdbGroupBoxInformationTabActors.Controls.Add(Me.ThetvdbLabelNameTabActors)
            Me.ThetvdbGroupBoxInformationTabActors.Controls.Add(Me.txtActorRole)
            Me.ThetvdbGroupBoxInformationTabActors.Controls.Add(Me.ThetvdbLabelRoleTabActors)
            Me.ThetvdbGroupBoxInformationTabActors.Controls.Add(Me.txtActorName)
            Me.ThetvdbGroupBoxInformationTabActors.Controls.Add(Me.ThetvdbLabelSortOrderTabActors)
            Me.ThetvdbGroupBoxInformationTabActors.Controls.Add(Me.txtActorId)
            Me.ThetvdbGroupBoxInformationTabActors.Location = New System.Drawing.Point(127, 455)
            Me.ThetvdbGroupBoxInformationTabActors.Name = "ThetvdbGroupBoxInformationTabActors"
            Me.ThetvdbGroupBoxInformationTabActors.Size = New System.Drawing.Size(230, 148)
            Me.ThetvdbGroupBoxInformationTabActors.TabIndex = 5
            Me.ThetvdbGroupBoxInformationTabActors.TabStop = False
            Me.ThetvdbGroupBoxInformationTabActors.Text = ".:: Information ::."
            '
            'txtActorSortOrder
            '
            Me.txtActorSortOrder.BackColor = System.Drawing.Color.White
            Me.txtActorSortOrder.Location = New System.Drawing.Point(76, 104)
            Me.txtActorSortOrder.Name = "txtActorSortOrder"
            Me.txtActorSortOrder.ReadOnly = True
            Me.txtActorSortOrder.Size = New System.Drawing.Size(144, 20)
            Me.txtActorSortOrder.TabIndex = 3
            '
            'ThetvdbLabelIDTabActors
            '
            Me.ThetvdbLabelIDTabActors.AutoSize = True
            Me.ThetvdbLabelIDTabActors.Location = New System.Drawing.Point(15, 23)
            Me.ThetvdbLabelIDTabActors.Name = "ThetvdbLabelIDTabActors"
            Me.ThetvdbLabelIDTabActors.Size = New System.Drawing.Size(19, 13)
            Me.ThetvdbLabelIDTabActors.TabIndex = 2
            Me.ThetvdbLabelIDTabActors.Text = "Id:"
            '
            'ThetvdbLabelNameTabActors
            '
            Me.ThetvdbLabelNameTabActors.AutoSize = True
            Me.ThetvdbLabelNameTabActors.Location = New System.Drawing.Point(15, 49)
            Me.ThetvdbLabelNameTabActors.Name = "ThetvdbLabelNameTabActors"
            Me.ThetvdbLabelNameTabActors.Size = New System.Drawing.Size(38, 13)
            Me.ThetvdbLabelNameTabActors.TabIndex = 2
            Me.ThetvdbLabelNameTabActors.Text = "Name:"
            '
            'txtActorRole
            '
            Me.txtActorRole.BackColor = System.Drawing.Color.White
            Me.txtActorRole.Location = New System.Drawing.Point(76, 75)
            Me.txtActorRole.Name = "txtActorRole"
            Me.txtActorRole.ReadOnly = True
            Me.txtActorRole.Size = New System.Drawing.Size(144, 20)
            Me.txtActorRole.TabIndex = 3
            '
            'ThetvdbLabelRoleTabActors
            '
            Me.ThetvdbLabelRoleTabActors.AutoSize = True
            Me.ThetvdbLabelRoleTabActors.Location = New System.Drawing.Point(15, 78)
            Me.ThetvdbLabelRoleTabActors.Name = "ThetvdbLabelRoleTabActors"
            Me.ThetvdbLabelRoleTabActors.Size = New System.Drawing.Size(32, 13)
            Me.ThetvdbLabelRoleTabActors.TabIndex = 2
            Me.ThetvdbLabelRoleTabActors.Text = "Role:"
            '
            'txtActorName
            '
            Me.txtActorName.BackColor = System.Drawing.Color.White
            Me.txtActorName.Location = New System.Drawing.Point(76, 46)
            Me.txtActorName.Name = "txtActorName"
            Me.txtActorName.ReadOnly = True
            Me.txtActorName.Size = New System.Drawing.Size(144, 20)
            Me.txtActorName.TabIndex = 3
            '
            'ThetvdbLabelSortOrderTabActors
            '
            Me.ThetvdbLabelSortOrderTabActors.AutoSize = True
            Me.ThetvdbLabelSortOrderTabActors.Location = New System.Drawing.Point(15, 107)
            Me.ThetvdbLabelSortOrderTabActors.Name = "ThetvdbLabelSortOrderTabActors"
            Me.ThetvdbLabelSortOrderTabActors.Size = New System.Drawing.Size(55, 13)
            Me.ThetvdbLabelSortOrderTabActors.TabIndex = 2
            Me.ThetvdbLabelSortOrderTabActors.Text = "SortOrder:"
            '
            'txtActorId
            '
            Me.txtActorId.BackColor = System.Drawing.Color.White
            Me.txtActorId.Location = New System.Drawing.Point(76, 20)
            Me.txtActorId.Name = "txtActorId"
            Me.txtActorId.ReadOnly = True
            Me.txtActorId.Size = New System.Drawing.Size(144, 20)
            Me.txtActorId.TabIndex = 3
            '
            'panel1
            '
            Me.panel1.BackColor = System.Drawing.Color.Black
            Me.panel1.Controls.Add(Me.bcActors)
            Me.panel1.Location = New System.Drawing.Point(367, 159)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(302, 452)
            Me.panel1.TabIndex = 4
            '
            'bcActors
            '
            Me.bcActors.BackColor = System.Drawing.Color.Black
            Me.bcActors.DefaultImage = Nothing
            Me.bcActors.ImageSizeMode = System.Windows.Forms.ImageLayout.Zoom
            Me.bcActors.Index = 0
            Me.bcActors.LoadingBackgroundColor = System.Drawing.Color.Black
            Me.bcActors.LoadingImage = Global.ZGuideTV.My.Resources.Resources.loader4
            Me.bcActors.Location = New System.Drawing.Point(1, 1)
            Me.bcActors.Name = "bcActors"
            Me.bcActors.Size = New System.Drawing.Size(300, 450)
            Me.bcActors.TabIndex = 0
            Me.bcActors.UnavailableImage = Nothing
            Me.bcActors.UseThumb = False
            '
            'pnlEpisodeEnabled
            '
            Me.pnlEpisodeEnabled.BackColor = System.Drawing.Color.Silver
            Me.pnlEpisodeEnabled.Controls.Add(Me.ThetvdbLabelEpisodes)
            Me.pnlEpisodeEnabled.Location = New System.Drawing.Point(189, 7)
            Me.pnlEpisodeEnabled.Name = "pnlEpisodeEnabled"
            Me.pnlEpisodeEnabled.Size = New System.Drawing.Size(178, 17)
            Me.pnlEpisodeEnabled.TabIndex = 42
            '
            'ThetvdbLabelEpisodes
            '
            Me.ThetvdbLabelEpisodes.AutoSize = True
            Me.ThetvdbLabelEpisodes.Location = New System.Drawing.Point(73, 2)
            Me.ThetvdbLabelEpisodes.Name = "ThetvdbLabelEpisodes"
            Me.ThetvdbLabelEpisodes.Size = New System.Drawing.Size(50, 13)
            Me.ThetvdbLabelEpisodes.TabIndex = 0
            Me.ThetvdbLabelEpisodes.Text = "Episodes"
            '
            'pnlActorsEnabled
            '
            Me.pnlActorsEnabled.BackColor = System.Drawing.Color.Silver
            Me.pnlActorsEnabled.Controls.Add(Me.ThetvdbLabelActors1)
            Me.pnlActorsEnabled.Location = New System.Drawing.Point(369, 7)
            Me.pnlActorsEnabled.Name = "pnlActorsEnabled"
            Me.pnlActorsEnabled.Size = New System.Drawing.Size(178, 17)
            Me.pnlActorsEnabled.TabIndex = 42
            '
            'ThetvdbLabelActors1
            '
            Me.ThetvdbLabelActors1.AutoSize = True
            Me.ThetvdbLabelActors1.Location = New System.Drawing.Point(68, 2)
            Me.ThetvdbLabelActors1.Name = "ThetvdbLabelActors1"
            Me.ThetvdbLabelActors1.Size = New System.Drawing.Size(37, 13)
            Me.ThetvdbLabelActors1.TabIndex = 0
            Me.ThetvdbLabelActors1.Text = "Actors"
            '
            'SeriesBrowser
            '
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(784, 644)
            Me.Controls.Add(Me.pnlEpisodeEnabled)
            Me.Controls.Add(Me.pnlActorsEnabled)
            Me.Controls.Add(Me.ThetvdbTabControlTvdb)
            Me.Controls.Add(Me.label5)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(790, 668)
            Me.Name = "SeriesBrowser"
            Me.Opacity = 0.0R
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "ZGuideTV.NET  - The TVDB.Com"
            Me.ThetvdbLabelEpisodesTabEpisodes.ResumeLayout(False)
            Me.ThetvdbLabelEpisodesTabEpisodes.PerformLayout()
            Me.pnlSeasonBanner.ResumeLayout(False)
            Me.pnlSeasonBannerWide.ResumeLayout(False)
            Me.ThetvdbLabelSeriesTabSeries.ResumeLayout(False)
            Me.ThetvdbLabelSeriesTabSeries.PerformLayout()
            CType(Me.raterSeriesSiteRating, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelSeriesBannerFrame.ResumeLayout(False)
            Me.ThetvdbTabControlTvdb.ResumeLayout(False)
            Me.ThetvdbLabelActorsTabActors.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.ThetvdbGroupBoxInformationTabActors.ResumeLayout(False)
            Me.ThetvdbGroupBoxInformationTabActors.PerformLayout()
            Me.panel1.ResumeLayout(False)
            Me.pnlEpisodeEnabled.ResumeLayout(False)
            Me.pnlEpisodeEnabled.PerformLayout()
            Me.pnlActorsEnabled.ResumeLayout(False)
            Me.pnlActorsEnabled.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private label5 As System.Windows.Forms.Label
        Private txtEpisodeOverview As System.Windows.Forms.RichTextBox
        Private txtEpisodeDVDChapter As System.Windows.Forms.TextBox
        Private txtEpisodeFirstAired As System.Windows.Forms.TextBox
        Private txtEpisodeDVDSeason As System.Windows.Forms.TextBox
        Private txtEpisodeDVDNumber As System.Windows.Forms.TextBox
        Private txtEpisodeLanguage As System.Windows.Forms.TextBox
        Private txtEpisodeProductionCode As System.Windows.Forms.TextBox
        Private txtEpisodeDVDId As System.Windows.Forms.TextBox
        Private WithEvents tvEpisodes As System.Windows.Forms.TreeView
        Private txtOverview As System.Windows.Forms.RichTextBox
        Private txtRuntime As System.Windows.Forms.TextBox
        Private txtImdbId As System.Windows.Forms.TextBox
        Private txtSeriesName As System.Windows.Forms.TextBox
        Private txtRating As System.Windows.Forms.TextBox
        Private txtFirstAired As System.Windows.Forms.TextBox
        Private txtTvComId As System.Windows.Forms.TextBox
        Private txtSeriesId As System.Windows.Forms.TextBox
        Private WithEvents ThetvdbTabControlTvdb As System.Windows.Forms.TabControl
        Private pnlEpisodeEnabled As System.Windows.Forms.Panel
        Private txtEpisodeImdbID As System.Windows.Forms.TextBox
        Private txtEpisodeAbsoluteNumber As System.Windows.Forms.TextBox
        Private posterControlSeries As PosterControl
        Private panelSeriesBannerFrame As System.Windows.Forms.Panel
        Private pnlSeasonBannerWide As System.Windows.Forms.Panel
        Private pnlSeasonBanner As System.Windows.Forms.Panel
        Private lbGuestStars As System.Windows.Forms.ListBox
        Private WithEvents saveImageContext As System.Windows.Forms.ContextMenuStrip
        Private WithEvents saveImageToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
        Private raterSeriesSiteRating As Rater
        Private bcSeasonBannerWide As BannerControl
        Private bcSeasonBanner As BannerControl
        Private bcEpisodeBanner As BannerControl
        Private bcSeriesBanner As BannerControl
        Private pnlActorsEnabled As System.Windows.Forms.Panel
        Private WithEvents bcActors As BannerControl
        Private txtActorSortOrder As System.Windows.Forms.TextBox
        Private txtActorRole As System.Windows.Forms.TextBox
        Private txtActorName As System.Windows.Forms.TextBox
        Private txtActorId As System.Windows.Forms.TextBox
        Private panel1 As System.Windows.Forms.Panel
        Private lbDirectors As System.Windows.Forms.ListBox
        Private lbWriters As System.Windows.Forms.ListBox
        Private WithEvents ThetvdbActors As System.Windows.Forms.ListBox
        Private WithEvents showImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents copyToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents llblImdb As System.Windows.Forms.LinkLabel
        Private WithEvents llblTvComId As System.Windows.Forms.LinkLabel
        Friend WithEvents ThetvdbLabelSearchName1 As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelID As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelGenre As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelActors As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelDescription As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelGueststarTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelDirectorTabTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelWriterTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelRuntime As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelRating As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelSiteRating As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelActors1 As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelFirstAired As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelIDIMDB As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelIDTVCom As System.Windows.Forms.Label
        Friend WithEvents ThetvdbButtonForceUpdate As System.Windows.Forms.Button
        Friend WithEvents ThetvdbLabelEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelSeriesTabSeries As System.Windows.Forms.TabPage
        Friend WithEvents ThetvdbLabelEpisodesTabEpisodes As System.Windows.Forms.TabPage
        Friend WithEvents ThetvdbLabelActorsTabActors As System.Windows.Forms.TabPage
        Friend WithEvents ThetvdbLabelFirstAiredTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelLanguageTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelIDIMDBComTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelAbsoluteNumberTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelOverviewTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelDVDChapterTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelDVDSeasonTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelProductCodeTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelDVDNumberTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelDVDIDTabEpisodes As System.Windows.Forms.Label
        Friend WithEvents ThetvdbGroupBoxInformationTabActors As System.Windows.Forms.GroupBox
        Friend WithEvents ThetvdbLabelIDTabActors As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelNameTabActors As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelSortOrderTabActors As System.Windows.Forms.Label
        Friend WithEvents ThetvdbLabelRoleTabActors As System.Windows.Forms.Label
        Friend WithEvents lbActors As System.Windows.Forms.ListBox
        Friend WithEvents lbGenre As System.Windows.Forms.ListBox
        Friend WithEvents ThetvdbButtonExit As System.Windows.Forms.Button
        Private WithEvents Panel2 As System.Windows.Forms.Panel
        Private WithEvents BannerControl1 As ZGuideTV.ZGuideTVDotNetTvdb.BannerControl
        Friend WithEvents ThetvdbButtonSearchShow As System.Windows.Forms.Button
    End Class
End Namespace

