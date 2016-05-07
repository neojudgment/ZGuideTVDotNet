' •—————————————————————————————————————————————————————————————————————————————————•
' |                                                                                 |
' |    TvdbLib: A library to retrieve information and media from http://thetvdb.com |
' |                                                                                 |
' |    Copyright (C) 2008  Benjamin Gmeiner                                         |
' |                                                                                 |
' |    This program is free software: you can redistribute it and/or modify         |
' |    it under the terms of the GNU General Public License as published by         |
' |    the Free Software Foundation, either version 3 of the License, or            |
' |    (at your option) any later version.                                          |
' |                                                                                 |
' |    This program is distributed in the hope that it will be useful,              |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of               |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                |
' |    GNU General Public License for more details.                                 |
' |                                                                                 |
' |    You should have received a copy of the GNU General Public License            |
' |    along with this program.  If not, see <http://www.gnu.org/licenses/>.        |
' |                                                                                 |
' |    Converted to VB.NET and modified by Neo (neojudgment) and rvs75.             |
' |    October 2009 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>.              |
' |                                                                                 |
' •—————————————————————————————————————————————————————————————————————————————————•
Imports TvdbLib.Data.Banner
Imports TvdbLib.Exceptions
Imports ZGuideTV.My.Resources
Imports TvdbLib.Cache
Imports TvdbLib.Data
Imports TvdbLib
Imports System.Globalization

Namespace ZGuideTVDotNetTvdb
    Partial Public Class SeriesBrowser
        Inherits Form

        ' 11/10/2010 Griser et désactiver la croix rouge de la form
        Private Const CS_NOCLOSE As Integer = &H200

        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
                Return cp
            End Get
        End Property

#Region "Property"
        Private _thetvdbLabelOpen As String

        Public Property ThetvdbLabelOpen As String
            Get
                Return _thetvdbLabelOpen
            End Get
            Set(ByVal Value As String)
                _thetvdbLabelOpen = Value
            End Set
        End Property

        Private _thetvdbNodeSeasonTabEpisodes As String

        Public Property ThetvdbNodeSeasonTabEpisodes As String
            Get
                Return _thetvdbNodeSeasonTabEpisodes
            End Get
            Set(ByVal Value As String)
                _thetvdbNodeSeasonTabEpisodes = Value
            End Set
        End Property

        Private _thetvdbNoResult As String

        Public Property ThetvdbNoResult As String
            Get
                Return _thetvdbNoResult
            End Get
            Set(ByVal Value As String)
                _thetvdbNoResult = Value
            End Set
        End Property

        Private _thetvdbNoResultTitre As String

        Public Property ThetvdbNoResultTitre As String
            Get
                Return _thetvdbNoResultTitre
            End Get
            Set(ByVal Value As String)
                _thetvdbNoResultTitre = Value
            End Set
        End Property

        Private _thetvdbNoValidSeriesId As String

        Public Property ThetvdbNoValidSeriesId As String
            Get
                Return _thetvdbNoValidSeriesId
            End Get
            Set(ByVal Value As String)
                _thetvdbNoValidSeriesId = Value
            End Set
        End Property

        Private _thetvdbNoValidSeriesIdTitre As String

        Public Property ThetvdbNoValidSeriesIdTitre As String
            Get
                Return _thetvdbNoValidSeriesIdTitre
            End Get
            Set(ByVal Value As String)
                _thetvdbNoValidSeriesIdTitre = Value
            End Set
        End Property

        Private _thetvdbNoSerieDetails As String

        Public Property ThetvdbNoSerieDetails As String
            Get
                Return _thetvdbNoSerieDetails
            End Get
            Set(ByVal Value As String)
                _thetvdbNoSerieDetails = Value
            End Set
        End Property

        Private _thetvdbNoSerieDetailsTitre As String

        Public Property ThetvdbNoSerieDetailsTitre As String
            Get
                Return _thetvdbNoSerieDetailsTitre
            End Get
            Set(ByVal Value As String)
                _thetvdbNoSerieDetailsTitre = Value
            End Set
        End Property

        Private _thetvdbNoActorInfo As String

        Public Property ThetvdbNoActorInfo As String
            Get
                Return _thetvdbNoActorInfo
            End Get
            Set(ByVal Value As String)
                _thetvdbNoActorInfo = Value
            End Set
        End Property

        Private _thetvdbNoActorInfoTitre As String

        Public Property ThetvdbNoActorInfoTitre As String
            Get
                Return _thetvdbNoActorInfoTitre
            End Get
            Set(ByVal Value As String)
                _thetvdbNoActorInfoTitre = Value
            End Set
        End Property

        Private _thetvdbNoBanner As String

        Public Property ThetvdbNoBanner As String
            Get
                Return _thetvdbNoBanner
            End Get
            Set(ByVal Value As String)
                _thetvdbNoBanner = Value
            End Set
        End Property

        Private _thetvdbNoBannerTitre As String

        Public Property ThetvdbNoBannerTitre As String
            Get
                Return _thetvdbNoBannerTitre
            End Get
            Set(ByVal Value As String)
                _thetvdbNoBannerTitre = Value
            End Set
        End Property

        Private _thetvdbBoxNoSheet As String

        Public Property ThetvdbBoxNoSheet As String
            Get
                Return _thetvdbBoxNoSheet
            End Get
            Set(ByVal Value As String)
                _thetvdbBoxNoSheet = Value
            End Set
        End Property

        Private _thetvdbBoxNoSheetTitre As String

        Public Property ThetvdbBoxNoSheetTitre As String
            Get
                Return _thetvdbBoxNoSheetTitre
            End Get
            Set(ByVal Value As String)
                _thetvdbBoxNoSheetTitre = Value
            End Set
        End Property

        Private _findSeries As String

        Public Property FindSeries As String
            Get
                Return _findSeries
            End Get
            Set(ByVal Value As String)
                _findSeries = Value
            End Set
        End Property
#End Region

        Private m_tvdbHandler As TvdbHandler

        ' nom de la série
        Private m_currentSeries As TvdbSeries

        Public Sub New()

            InitializeComponent()

        End Sub

        Public Sub SeriesBrowser_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            LanguageCheck()
            FindSeries = ThetvdbName

        End Sub

        Private Sub Tester_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown

            Dim p As ICacheProvider = Nothing
            Dim CachePath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                                      "\ZGuideTVDotNet\Cache\"
            p = New XmlCacheProvider(CachePath)

            Try
                InitialiseForm(Nothing, p)
                If Not (Not ThetvdbName Is Nothing AndAlso String.IsNullOrEmpty(ThetvdbName)) Then
                    findSerie()
                Else
                    Me.WindowState = FormWindowState.Normal
                    Me.CenterToScreen()
                End If

            Catch
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(ThetvdbBoxNoSheet, ThetvdbBoxNoSheetTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                Me.Close()
            End Try

        End Sub

        Friend Sub InitialiseForm(ByVal _userId As String, ByVal _provider As ICacheProvider)
            Me.Visible = False
            m_tvdbHandler = New TvdbHandler(_provider, API_KEY)
            m_tvdbHandler.InitCache()
            Dim m_languages As List(Of TvdbLanguage) = m_tvdbHandler.Languages
            If ThetvdbLanguage Is Nothing Then
                For Each l As TvdbLanguage In m_languages
                    If l.Abbriviation = LSet(lngLanguage, 2).ToLower() Then
                        ThetvdbLanguage = l
                    End If
                Next l
            End If
        End Sub

        Public Sub Tester_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
            Handles MyBase.FormClosing
            If m_tvdbHandler IsNot Nothing Then
                m_tvdbHandler.CloseCache()
            End If
            ThetvdbName = ""
            ThetvdbLanguage = Nothing
        End Sub

        Private Sub cmdGetSeries()
            Try
                LoadSeries(Int32.Parse(search.txtGetSeries.Text, CultureInfo.CurrentCulture))
            Catch e1 As FormatException

                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(ThetvdbNoValidSeriesId, ThetvdbNoValidSeriesIdTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
            End Try
        End Sub

        Private Sub LoadSeries(ByVal _seriesId As Integer)
            Dim series As TvdbSeries = Nothing

            Try
                series = _
                    m_tvdbHandler.GetSeries(_seriesId, ThetvdbLanguage, search.ThetvdbLabelLoadFull.Checked, _
                                             search.ThetvdbLabelLoadActors.Checked, _
                                             search.ThetvdbLabelBanner.Checked, search.ThetvdbLabelUseZipped.Checked)
            Catch ex As TvdbInvalidApiKeyException
                MessageBox.Show(ex.Message)
            Catch ex As TvdbNotAvailableException
                MessageBox.Show(ex.Message)
            End Try

            If series IsNot Nothing Then
                CleanUpForm()
                ThetvdbTabControlTvdb.SelectedTab = ThetvdbLabelSeriesTabSeries
                UpdateSeries(series)
            End If
        End Sub

        Private Sub UpdateSeries(ByVal _series As TvdbSeries)
            m_currentSeries = _series
            FillSeriesDetails(_series)

            ThetvdbButtonForceUpdate.Enabled = True

            If _series.PosterBanners.Count > 0 Then
                posterControlSeries.PosterImages = _series.PosterBanners
            Else
                posterControlSeries.ClearPoster()
            End If


            If _series.EpisodesLoaded Then
                pnlEpisodeEnabled.Visible = False
                FillFullSeriesDetails(_series)
            Else

                pnlEpisodeEnabled.Visible = True
            End If

            If _series.TvdbActorsLoaded AndAlso _series.Actors.Count > 0 Then
                pnlActorsEnabled.Visible = False
                ThetvdbActors.Items.Clear()
                bcActors.ClearControl()
                If _series.TvdbActors.Count > 0 Then
                    Dim bannerList As New List(Of TvdbBanner)()
                    For Each a As TvdbActor In _series.TvdbActors
                        ThetvdbActors.Items.Add(a.Name)
                        bannerList.Add(a.ActorImage)
                    Next a

                    bcActors.BannerImages = bannerList
                    SetActorInfo(_series.TvdbActors(0))
                End If
            Else
                bcActors.ClearControl()

                pnlActorsEnabled.Visible = True
            End If

        End Sub

        Private Sub CleanUpForm()
            posterControlSeries.ClearPoster()
            'coverFlowFanart.Clear()
            bcSeriesBanner.ClearControl()
            bcSeasonBanner.ClearControl()
            bcSeasonBannerWide.ClearControl()
            bcEpisodeBanner.ClearControl()
            bcActors.ClearControl()
            ThetvdbActors.Items.Clear()
            ClearSeriesDetails()

            ClearEpisodeDetail()
            tvEpisodes.Nodes.Clear()
        End Sub

        Private Sub ClearSeriesDetails()
            txtSeriesId.Text = ""
            txtSeriesName.Text = ""
            'txtStatus.Text = ""
            'txtGenre.Text = ""
            lbGenre.Items.Clear()
            txtFirstAired.Text = ""
            txtRuntime.Text = ""
            txtRating.Text = ""
            'txtActors.Text = ""
            lbActors.Items.Clear()
            txtOverview.Text = ""
            txtTvComId.Text = ""
            'series.
            llblTvComId.Text = ""
            llblTvComId.Links.Clear()
            txtImdbId.Text = ""
            llblImdb.Text = ""
            llblImdb.Links.Clear()
            'txtZap2itId.Text = ""
            raterSeriesSiteRating.CurrentRating = 0

            bcSeriesBanner.ClearControl()
        End Sub

        Private Sub ClearEpisodeDetail()
            txtEpisodeAbsoluteNumber.Text = ""
            txtEpisodeDVDChapter.Text = ""
            txtEpisodeDVDId.Text = ""
            txtEpisodeDVDNumber.Text = ""
            txtEpisodeDVDSeason.Text = ""
            txtEpisodeFirstAired.Text = ""
            lbGuestStars.Items.Clear()
            lbWriters.Items.Clear()
            lbDirectors.Items.Clear()
            txtEpisodeImdbID.Text = ""
            txtEpisodeLanguage.Text = ""
            txtEpisodeOverview.Text = ""
            txtEpisodeProductionCode.Text = ""
            bcEpisodeBanner.ClearControl()
        End Sub

        Private Sub FillSeriesDetails(ByVal series As TvdbSeries)

            Dim bannerlist As New List(Of TvdbBanner)()
            For Each b As TvdbBanner In series.Banners
                If b.GetType() Is GetType(TvdbSeriesBanner) Then
                    'if (b.Language.Id == m_defaultLang.Id)
                    bannerlist.Add(b)
                End If
            Next b

            If bannerlist.Count > 0 Then
                bcSeriesBanner.BannerImages = bannerlist
            Else
                bcSeriesBanner.ClearControl()
            End If

            txtSeriesId.Text = series.Id.ToString(CultureInfo.CurrentCulture)
            txtSeriesName.Text = series.SeriesName
            'txtStatus.Text = series.Status

            'txtGenre.Text = series.GenreString
            For Each genre As String In series.Genre
                lbGenre.Items.Add(genre)
            Next


            txtFirstAired.Text = series.FirstAired.ToShortDateString()
            txtRuntime.Text = If(series.Runtime <> -99, series.Runtime.ToString(CultureInfo.CurrentCulture), "")
            txtRating.Text = If(series.Rating <> -99, series.Rating.ToString(CultureInfo.CurrentCulture), "")

            'txtActors.Text = series.ActorsString
            For Each Actor As String In series.Actors
                lbActors.Items.Add(Actor)
            Next

            txtOverview.Text = series.Overview
            txtTvComId.Text = If(series.TvDotComId <> -99, series.TvDotComId.ToString(CultureInfo.CurrentCulture), "")
            'series.

            With llblTvComId
                If series.TvDotComId <> -99 Then
                    Dim link As String = "http://www.tv.com/show/" & series.TvDotComId & "/summary.html"
                    .Text = ThetvdbLabelOpen
                    .Links.Clear()
                    .Links.Add(0, link.Length, link)
                Else
                    .Links.Clear()
                    .Text = ""
                End If
            End With

            txtImdbId.Text = series.ImdbId

            With llblImdb
                If series.ImdbId IsNot Nothing AndAlso (Not String.IsNullOrEmpty(series.ImdbId)) Then
                    Dim link As String = "http://www.imdb.com/title/" & series.ImdbId
                    .Text = ThetvdbLabelOpen
                    .Links.Clear()
                    .Links.Add(0, link.Length, link)
                Else
                    .Links.Clear()
                    .Text = ""
                End If
            End With

            If series.Rating <> -99 Then
                raterSeriesSiteRating.CurrentRating = CInt(series.Rating)
            Else
                raterSeriesSiteRating.CurrentRating = 0
            End If

        End Sub

        Private Sub FillFullSeriesDetails(ByVal _series As TvdbSeries)

            Dim seasonBannerList As List(Of TvdbSeasonBanner) = _series.SeasonBanners
            tvEpisodes.Nodes.Clear()
            For Each e As TvdbEpisode In _series.Episodes
                Dim found As Boolean = False
                For Each seasonNode As TreeNode In tvEpisodes.Nodes
                    If (CType(seasonNode.Tag, SeasonTag)).SeasonId = e.SeasonId Then
                        Dim node As New TreeNode(e.EpisodeNumber & " - " & e.EpisodeName)
                        node.Tag = e
                        seasonNode.Nodes.Add(node)
                        found = True
                        Exit For
                    End If
                Next seasonNode
                If (Not found) Then
                    Dim node As New TreeNode(ThetvdbNodeSeasonTabEpisodes & " " & e.SeasonNumber)

                    Dim tagList As New List(Of TvdbSeasonBanner)()
                    For Each b As TvdbSeasonBanner In seasonBannerList
                        If b.Season = e.SeasonNumber Then
                            tagList.Add(b)
                        End If
                    Next b
                    Dim tag As New SeasonTag(e.SeasonNumber, e.SeasonId, tagList)
                    node.Tag = tag
                    tvEpisodes.Nodes.Add(node)

                    Dim epNode As New TreeNode(e.EpisodeNumber & " - " & e.EpisodeName)
                    epNode.Tag = e
                    node.Nodes.Add(epNode)
                End If
            Next e
        End Sub

        Private Sub FillEpisodeDetail(ByVal _episode As TvdbEpisode)

            txtEpisodeLanguage.Text = If(_episode.Language IsNot Nothing, _episode.Language.ToString(), "")
            txtEpisodeFirstAired.Text = _episode.FirstAired.ToShortDateString()

            lbGuestStars.Items.Clear()
            For Each s As String In _episode.GuestStars
                lbGuestStars.Items.Add(s.Trim())
            Next s

            lbDirectors.Items.Clear()
            For Each s As String In _episode.Directors
                lbDirectors.Items.Add(s.Trim())
            Next s

            lbWriters.Items.Clear()
            For Each s As String In _episode.Writer
                lbWriters.Items.Add(s.Trim())
            Next s

            txtEpisodeProductionCode.Text = _episode.ProductionCode
            txtEpisodeOverview.Text = _episode.Overview
            txtEpisodeDVDId.Text = If(_episode.DvdDiscId <> -99, _episode.DvdDiscId.ToString(CultureInfo.CurrentCulture), "")
            txtEpisodeDVDSeason.Text = If(_episode.DvdSeason <> -99, _episode.DvdSeason.ToString(CultureInfo.CurrentCulture), "")
            txtEpisodeDVDNumber.Text = If(_episode.DvdEpisodeNumber <> -99, _episode.DvdEpisodeNumber.ToString(CultureInfo.CurrentCulture), "")
            txtEpisodeDVDChapter.Text = If(_episode.DvdChapter <> -99, _episode.DvdChapter.ToString(CultureInfo.CurrentCulture), "")
            txtEpisodeAbsoluteNumber.Text = If(_episode.AbsoluteNumber <> -99, _episode.AbsoluteNumber.ToString(CultureInfo.CurrentCulture), "")
            txtImdbId.Text = _episode.ImdbId

        End Sub

        Private Sub tvEpisodes_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) _
            Handles tvEpisodes.AfterSelect

            If tvEpisodes.SelectedNode IsNot Nothing AndAlso tvEpisodes.SelectedNode.Tag IsNot Nothing Then
                Dim selectedSeason As Integer = 0
                If tvEpisodes.SelectedNode.Tag.GetType() Is GetType(TvdbEpisode) Then
                    Dim ep As TvdbEpisode = CType(tvEpisodes.SelectedNode.Tag, TvdbEpisode)
                    FillEpisodeDetail(ep)

                    'load episode image
                    If ep.Banner IsNot Nothing Then
                        bcEpisodeBanner.BannerImage = ep.Banner
                    Else
                        bcEpisodeBanner.ClearControl()
                    End If
                    selectedSeason = ep.SeasonNumber
                ElseIf tvEpisodes.SelectedNode.Tag.GetType() Is GetType(SeasonTag) Then
                    Dim tag As SeasonTag = CType(tvEpisodes.SelectedNode.Tag, SeasonTag)
                    selectedSeason = tag.SeasonNumber
                    ClearEpisodeDetail()
                Else
                    Return
                End If

                If bcSeasonBanner.Tag Is Nothing OrElse selectedSeason <> CInt(Fix(bcSeasonBanner.Tag)) Then
                    Dim seasonList As New List(Of TvdbBanner)()
                    Dim seasonWideList As New List(Of TvdbBanner)()

                    If m_currentSeries.SeasonBanners IsNot Nothing AndAlso m_currentSeries.SeasonBanners.Count > 0 Then
                        For Each b As TvdbSeasonBanner In m_currentSeries.SeasonBanners
                            If b.Season = selectedSeason Then
                                If b.BannerType = TvdbSeasonBanner.Type.season Then
                                    If _
                                        b.Language Is Nothing OrElse _
                                        b.Language.Abbriviation.Equals(ThetvdbLanguage.Abbriviation, StringComparison.CurrentCulture) Then
                                        seasonList.Add(b)
                                    End If
                                End If

                                If b.BannerType = TvdbSeasonBanner.Type.seasonwide Then
                                    If _
                                        b.Language Is Nothing OrElse _
                                        b.Language.Abbriviation.Equals(ThetvdbLanguage.Abbriviation, StringComparison.CurrentCulture) Then
                                        seasonWideList.Add(b)
                                    End If
                                End If
                            End If
                        Next b
                    End If
                    If seasonList.Count > 0 Then
                        bcSeasonBanner.BannerImages = seasonList
                    Else
                        bcSeasonBanner.ClearControl()
                    End If
                    bcSeasonBanner.Tag = selectedSeason

                    If seasonWideList.Count > 0 Then
                        bcSeasonBannerWide.BannerImages = seasonWideList
                    Else
                        bcSeasonBannerWide.ClearControl()
                    End If

                    bcSeasonBannerWide.Tag = selectedSeason
                End If
            End If
        End Sub

        'Private Sub cmdFindSeries_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ThetvdbButtonSearch.Click
        'findSerie()
        'End Sub

        Private Sub findSerie()

            If (Not String.IsNullOrEmpty(FindSeries)) Then
                Dim list As List(Of TvdbSearchResult) = m_tvdbHandler.SearchSeries(FindSeries, ThetvdbLanguage)
                Dim LngTab(10) As String

                With SearchResultForm
                    LngTab(0) = .ThetvdbGroupBoxResult.Text
                    LngTab(1) = .ThetvdblabelFirstAiredResult.Text
                    LngTab(2) = .ThetvdbLabelIMDBIdResult.Text
                    LngTab(3) = .ThetvdbLabelOverviewResult.Text
                    LngTab(4) = .ThetvdbLabelStatusResult.Text
                    LngTab(5) = .ThetvdbButtonChooseResult.Text
                    LngTab(6) = .ThetvdbButtonCancelResult.Text
                    LngTab(7) = .lvSearchResult.Columns(0).Text
                    LngTab(8) = .lvSearchResult.Columns(1).Text
                    LngTab(9) = .lvSearchResult.Columns(2).Text
                End With

                If list IsNot Nothing AndAlso list.Count > 0 Then
                    Dim form As New SearchResultForm(list, LngTab)
                    Dim res As DialogResult = form.ShowDialog()
                    If res = System.Windows.Forms.DialogResult.OK Then
                        LoadSeries(form.Selection.Id)
                        Me.Opacity = 100
                        Me.Show()
                    Else

                    End If
                Else

                    Dim BoxNoConnection As DialogResult
                    BoxNoConnection = _
                        MessageBox.Show(ThetvdbNoResult, ThetvdbNoResultTitre, MessageBoxButtons.OK, _
                                         MessageBoxIcon.Information)
                    Me.Close()
                End If
            End If
        End Sub

        Private Sub cmdForceUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbButtonForceUpdate.Click
            Dim series As TvdbSeries = Nothing
            Try
                series = _
                    m_tvdbHandler.ForceReload(m_currentSeries, search.ThetvdbLabelLoadFull.Checked, _
                                               search.ThetvdbLabelLoadActors.Checked, _
                                               search.ThetvdbLabelBanner.Checked)
            Catch ex As TvdbInvalidApiKeyException
                MessageBox.Show(ex.Message)
            Catch ex As TvdbNotAvailableException
                MessageBox.Show(ex.Message)
            End Try
            If series IsNot Nothing Then
                m_currentSeries = series
                UpdateSeries(m_currentSeries)
            End If
        End Sub

        Private Sub cmdLoadFullSeriesInfo_Click(ByVal sender As Object, ByVal e As EventArgs)

            Dim series As TvdbSeries = Nothing
            Try
                series = _
                    m_tvdbHandler.GetSeries(m_currentSeries.Id, m_currentSeries.Language, True, _
                                             m_currentSeries.TvdbActorsLoaded, m_currentSeries.BannersLoaded)
            Catch ex As TvdbInvalidApiKeyException
                MessageBox.Show(ex.Message)
            Catch ex As TvdbNotAvailableException
                MessageBox.Show(ex.Message)
            End Try

            If series IsNot Nothing AndAlso series.Episodes IsNot Nothing AndAlso series.Episodes.Count <> 0 Then
                UpdateSeries(series)
            Else

                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(ThetvdbNoSerieDetails, ThetvdbNoSerieDetailsTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
            End If
        End Sub

        Private Sub cmdLoadActorInfo_Click(ByVal sender As Object, ByVal e As EventArgs)

            Dim series As TvdbSeries = Nothing
            Try
                series = _
                    m_tvdbHandler.GetSeries(m_currentSeries.Id, m_currentSeries.Language, _
                                             m_currentSeries.EpisodesLoaded, True, m_currentSeries.BannersLoaded)
            Catch ex As TvdbInvalidApiKeyException
                MessageBox.Show(ex.Message)
            Catch ex As TvdbNotAvailableException
                MessageBox.Show(ex.Message)
            End Try

            If series IsNot Nothing AndAlso series.TvdbActorsLoaded Then
                UpdateSeries(series)
            Else

                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(ThetvdbNoActorInfo, ThetvdbNoActorInfoTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
            End If
        End Sub

        Private Sub cmdLoadBanners_Click(ByVal sender As Object, ByVal e As EventArgs)

            Dim series As TvdbSeries = Nothing
            Try
                series = _
                    m_tvdbHandler.GetSeries(m_currentSeries.Id, m_currentSeries.Language, _
                                             m_currentSeries.EpisodesLoaded, m_currentSeries.TvdbActorsLoaded, True)
            Catch ex As TvdbInvalidApiKeyException
                MessageBox.Show(ex.Message)
            Catch ex As TvdbNotAvailableException
                MessageBox.Show(ex.Message)
            End Try

            If series IsNot Nothing AndAlso series.BannersLoaded Then
                UpdateSeries(series)
            Else

                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(ThetvdbNoBanner, ThetvdbNoBannerTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
            End If
        End Sub

        Private Sub bcActors_IndexChanged(ByVal _event As EventArgs) Handles bcActors.IndexChanged

            If ThetvdbActors.SelectedIndex <> bcActors.Index Then
                ThetvdbActors.SelectedIndex = bcActors.Index
            Else
                SetActorInfo(m_currentSeries.TvdbActors(bcActors.Index))
            End If
        End Sub

        Private Sub SetActorInfo(ByVal _actor As TvdbActor)

            txtActorId.Text = _actor.Id.ToString(CultureInfo.CurrentCulture)
            txtActorName.Text = _actor.Name.ToString(CultureInfo.CurrentCulture)
            txtActorRole.Text = _actor.Role.ToString(CultureInfo.CurrentCulture)
            txtActorSortOrder.Text = _actor.SortOrder.ToString(CultureInfo.CurrentCulture)
        End Sub

        Private Sub lbAllActors_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbActors.SelectedIndexChanged

            ' 14/02/2010 Si on clique en dehors de l'index (-1) dans la liste des acteurs on quitte la routine 
            If ThetvdbActors.SelectedIndex < 0 Then
                Exit Sub
            End If

            bcActors.Index = ThetvdbActors.SelectedIndex
            SetActorInfo(m_currentSeries.TvdbActors(ThetvdbActors.SelectedIndex))

        End Sub

        Private Sub LinkLabel_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
            Handles llblImdb.LinkClicked, llblTvComId.LinkClicked

            If e.Link.LinkData IsNot Nothing Then
                Process.Start(CType(e.Link.LinkData, String))
                Me.Close()
            End If
        End Sub

        Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ThetvdbButtonExit.Click
            'Me.Close()
            Me.Dispose()
        End Sub

        Protected Overrides Sub Finalize()

            ' MyBase.Finalize()
            Try
                Dispose(False)
            Catch

            Finally

                MyBase.Finalize()
            End Try

        End Sub

        Private Sub ThetvdbButtonSearchShow_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbButtonSearchShow.Click
            search.Show()
            Me.Close()
        End Sub
    End Class
End Namespace
