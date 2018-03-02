' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2017 ZGuideTV.NET Team <https://github.com/neojudgment>                              |
' |                                                                                                            |
' |    Project administrator : Pascal Hubert (neojudgment@hotmail.com)                                         |
' |                                                                                                            |
' |    This program is free software: you can redistribute it and/or modify                                    |
' |    it under the terms of the Microsoft Reciprocal License (MS-RL)                                          |
' |                                                                                                            |
' |    This program is distributed in the hope that it will be useful,                                         |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of                                          |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.                                                    |
' |                                                                                                            |
' |                                                                                                            |
' |    You should have received a copy of the MS-RL License                                                    |
' |    along with this program.  If not, see <https://opensource.org/licenses/MS-RL>.                          |
' |                                                                                                            |
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
Imports TvdbLib.Data.Banner
Imports TvdbLib.Exceptions
Imports ZGuideTV.My.Resources
Imports TvdbLib.Cache
Imports TvdbLib.Data
Imports TvdbLib
Imports System.Globalization

' ReSharper disable CheckNamespace
Namespace ZGuideTVDotNetTvdb
    ' ReSharper restore CheckNamespace
    Partial Public Class SeriesBrowser
        Inherits Form

#Region "Property"
        Public ThetvdbLabelOpen As String
        Public ThetvdbNodeSeasonTabEpisodes As String
        Public ThetvdbNoResult As String
        Public ThetvdbNoResultTitre As String
        Public ThetvdbNoValidSeriesId As String
        Public ThetvdbNoValidSeriesIdTitre As String
        Public ThetvdbNoSerieDetails As String
        Public ThetvdbNoSerieDetailsTitre As String
        Public ThetvdbNoActorInfo As String
        Public ThetvdbNoActorInfoTitre As String
        Public ThetvdbNoBanner As String
        Public ThetvdbNoBannerTitre As String
        Public ThetvdbBoxNoSheet As String
        Public ThetvdbBoxNoSheetTitre As String
        Private _findSeries As String
        Private _mTvdbHandler As TvdbHandler
        Private _mCurrentSeries As TvdbSeries
#End Region

        Public Sub New()

            InitializeComponent()
        End Sub

        Private Sub SeriesBrowserLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            LanguageCheck()
            _findSeries = ThetvdbName
        End Sub

        Private Sub TesterShown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown

            Dim p As ICacheProvider
            Dim cachePath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                                      "\ZGuideTVDotNet\Cache\"
            p = New XmlCacheProvider(cachePath)

            Try
                InitialiseForm(Nothing, p)
                If Not (Not ThetvdbName Is Nothing AndAlso String.IsNullOrEmpty(ThetvdbName)) Then
                    FindSerie()
                Else
                    WindowState = FormWindowState.Normal
                    CenterToScreen()
                End If

            Catch
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection = _
                    MessageBox.Show(Mainform, ThetvdbBoxNoSheet, ThetvdbBoxNoSheetTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub InitialiseForm(ByVal userId As String, ByVal provider As ICacheProvider)
            Visible = False
            _mTvdbHandler = New TvdbHandler(provider, API_KEY)
            _mTvdbHandler.InitCache()
            Dim mLanguages As List(Of TvdbLanguage) = _mTvdbHandler.Languages
            If Thetvdblanguage Is Nothing Then
                For Each l As TvdbLanguage In mLanguages
                    If [String].Equals(l.Abbriviation, LSet(lngLanguage, 2).ToLower(), StringComparison.CurrentCulture) Then
                        Thetvdblanguage = l
                    End If
                Next l
            End If
        End Sub

        Private Sub TesterFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
            Handles MyBase.FormClosing
            If _mTvdbHandler IsNot Nothing Then
                _mTvdbHandler.CloseCache()
            End If
            ThetvdbName = ""
            Thetvdblanguage = Nothing

            Dispose()
        End Sub

        Private Sub LoadSeries(ByVal seriesId As Integer)
            Dim series As TvdbSeries = Nothing

            Try
                series = _
                    _mTvdbHandler.GetSeries(seriesId, Thetvdblanguage, MySearch.ThetvdbLabelLoadFull.Checked, _
                                             MySearch.ThetvdbLabelLoadActors.Checked, _
                                             MySearch.ThetvdbLabelBanner.Checked, MySearch.ThetvdbLabelUseZipped.Checked)
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

        Private Sub UpdateSeries(ByVal series As TvdbSeries)
            _mCurrentSeries = series
            FillSeriesDetails(series)

            ThetvdbButtonForceUpdate.Enabled = True

            If series.PosterBanners.Count > 0 Then
                posterControlSeries.PosterImages = series.PosterBanners
            Else
                posterControlSeries.ClearPoster()
            End If

            If series.EpisodesLoaded Then
                pnlEpisodeEnabled.Visible = False
                FillFullSeriesDetails(series)
            Else

                pnlEpisodeEnabled.Visible = True
            End If

            If series.TvdbActorsLoaded AndAlso series.Actors.Count > 0 Then
                pnlActorsEnabled.Visible = False
                ThetvdbActors.Items.Clear()
                bcActors.ClearControl()
                If series.TvdbActors.Count > 0 Then
                    Dim bannerList As New List(Of TvdbBanner)()
                    For Each a As TvdbActor In series.TvdbActors
                        ThetvdbActors.Items.Add(a.Name)
                        bannerList.Add(a.ActorImage)
                    Next a

                    bcActors.BannerImages = bannerList
                    SetActorInfo(series.TvdbActors(0))
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

            Dim bannerlist As List(Of TvdbBanner) = (From b In series.Banners Where b.GetType() Is GetType(TvdbSeriesBanner)).ToList()

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
            For Each actor As String In series.Actors
                lbActors.Items.Add(actor)
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

        Private Sub FillFullSeriesDetails(ByVal series As TvdbSeries)

            Dim seasonBannerList As List(Of TvdbSeasonBanner) = series.SeasonBanners
            tvEpisodes.Nodes.Clear()
            For Each e As TvdbEpisode In series.Episodes
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

                    ' Néo 29/09/2013
                    Dim episode As TvdbEpisode = e
                    Dim tagList As List(Of TvdbSeasonBanner) = (From b In seasonBannerList Where b.Season = episode.SeasonNumber).ToList()

                    Dim tag As New SeasonTag(e.SeasonNumber, e.SeasonId, tagList)
                    node.Tag = tag
                    tvEpisodes.Nodes.Add(node)

                    Dim epNode As New TreeNode(e.EpisodeNumber & " - " & e.EpisodeName)
                    epNode.Tag = e
                    node.Nodes.Add(epNode)
                End If
            Next e
        End Sub

        Private Sub FillEpisodeDetail(ByVal episode As TvdbEpisode)

            txtEpisodeLanguage.Text = If(episode.Language IsNot Nothing, episode.Language.ToString(), "")
            txtEpisodeFirstAired.Text = episode.FirstAired.ToShortDateString()

            lbGuestStars.Items.Clear()
            For Each s As String In episode.GuestStars
                lbGuestStars.Items.Add(s.Trim())
            Next s

            lbDirectors.Items.Clear()
            For Each s As String In episode.Directors
                lbDirectors.Items.Add(s.Trim())
            Next s

            lbWriters.Items.Clear()
            For Each s As String In episode.Writer
                lbWriters.Items.Add(s.Trim())
            Next s

            txtEpisodeProductionCode.Text = episode.ProductionCode
            txtEpisodeOverview.Text = episode.Overview
            txtEpisodeDVDId.Text = If(episode.DvdDiscId <> -99, episode.DvdDiscId.ToString(CultureInfo.CurrentCulture), "")
            txtEpisodeDVDSeason.Text = If(episode.DvdSeason <> -99, episode.DvdSeason.ToString(CultureInfo.CurrentCulture), "")
            txtEpisodeDVDNumber.Text = If(episode.DvdEpisodeNumber <> -99, episode.DvdEpisodeNumber.ToString(CultureInfo.CurrentCulture), "")
            txtEpisodeDVDChapter.Text = If(episode.DvdChapter <> -99, episode.DvdChapter.ToString(CultureInfo.CurrentCulture), "")
            txtEpisodeAbsoluteNumber.Text = If(episode.AbsoluteNumber <> -99, episode.AbsoluteNumber.ToString(CultureInfo.CurrentCulture), "")
            txtImdbId.Text = episode.ImdbId

        End Sub

        Private Sub TvEpisodesAfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) _
            Handles tvEpisodes.AfterSelect

            If tvEpisodes.SelectedNode IsNot Nothing AndAlso tvEpisodes.SelectedNode.Tag IsNot Nothing Then
                Dim selectedSeason As Integer
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

                    If _mCurrentSeries.SeasonBanners IsNot Nothing AndAlso _mCurrentSeries.SeasonBanners.Count > 0 Then
                        For Each b As TvdbSeasonBanner In _mCurrentSeries.SeasonBanners
                            If b.Season = selectedSeason Then
                                If b.BannerType = TvdbSeasonBanner.Type.season Then
                                    If _
                                        b.Language Is Nothing OrElse _
                                        b.Language.Abbriviation.Equals(Thetvdblanguage.Abbriviation, StringComparison.CurrentCulture) Then
                                        seasonList.Add(b)
                                    End If
                                End If

                                If b.BannerType = TvdbSeasonBanner.Type.seasonwide Then
                                    If _
                                        b.Language Is Nothing OrElse _
                                        b.Language.Abbriviation.Equals(Thetvdblanguage.Abbriviation, StringComparison.CurrentCulture) Then
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

        Private Sub FindSerie()

            If (Not String.IsNullOrEmpty(_findSeries)) Then
                Dim list As List(Of TvdbSearchResult) = _mTvdbHandler.SearchSeries(_findSeries, Thetvdblanguage)
                Dim lngTab(10) As String

                With SearchResultForm
                    lngTab(0) = .ThetvdbGroupBoxResult.Text
                    lngTab(1) = .ThetvdblabelFirstAiredResult.Text
                    lngTab(2) = .ThetvdbLabelIMDBIdResult.Text
                    lngTab(3) = .ThetvdbLabelOverviewResult.Text
                    lngTab(4) = .ThetvdbLabelStatusResult.Text
                    lngTab(5) = .ThetvdbButtonChooseResult.Text
                    lngTab(6) = .ThetvdbButtonCancelResult.Text
                    lngTab(7) = .lvSearchResult.Columns(0).Text
                    lngTab(8) = .lvSearchResult.Columns(1).Text
                    lngTab(9) = .lvSearchResult.Columns(2).Text
                End With

                If list IsNot Nothing AndAlso list.Count > 0 Then
                    Dim form As New SearchResultForm(list, lngTab)
                    Dim res As DialogResult = form.ShowDialog()
                    If res = DialogResult.OK Then
                        LoadSeries(form.Selection.Id)
                        Opacity = 100
                        Show()
                    Else

                    End If
                Else

                    Dim boxNoConnection As DialogResult = MessageBox.Show _
                            (Mainform, ThetvdbNoResult, _
                             ThetvdbNoResultTitre, MessageBoxButtons.OK, MessageBoxIcon.Information, _
                             MessageBoxDefaultButton.Button1)

                    If boxNoConnection = DialogResult.OK Then
                        Close()
                    Else
                        Close()
                    End If
                End If
            End If
        End Sub

        Private Sub CmdForceUpdateClick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbButtonForceUpdate.Click
            Dim series As TvdbSeries = Nothing
            Try
                series = _
                    _mTvdbHandler.ForceReload(_mCurrentSeries, MySearch.ThetvdbLabelLoadFull.Checked, _
                                               MySearch.ThetvdbLabelLoadActors.Checked, _
                                               MySearch.ThetvdbLabelBanner.Checked)
            Catch ex As TvdbInvalidApiKeyException
                MessageBox.Show(ex.Message)
            Catch ex As TvdbNotAvailableException
                MessageBox.Show(ex.Message)
            End Try
            If series IsNot Nothing Then
                _mCurrentSeries = series
                UpdateSeries(_mCurrentSeries)
            End If
        End Sub

        'Private Sub CmdLoadFullSeriesInfoClick(ByVal sender As Object, ByVal e As EventArgs)

        '    Dim series As TvdbSeries = Nothing
        '    Try
        '        series = _
        '            _mTvdbHandler.GetSeries(_mCurrentSeries.Id, _mCurrentSeries.Language, True, _
        '                                     _mCurrentSeries.TvdbActorsLoaded, _mCurrentSeries.BannersLoaded)
        '    Catch ex As TvdbInvalidApiKeyException
        '        MessageBox.Show(ex.Message)
        '    Catch ex As TvdbNotAvailableException
        '        MessageBox.Show(ex.Message)
        '    End Try

        '    If series IsNot Nothing AndAlso series.Episodes IsNot Nothing AndAlso series.Episodes.Count <> 0 Then
        '        UpdateSeries(series)
        '    Else

        '        Dim boxNoConnection As DialogResult
        '        boxNoConnection = _
        '            MessageBox.Show(Mainform, ThetvdbNoSerieDetails, ThetvdbNoSerieDetailsTitre, MessageBoxButtons.OK, _
        '                             MessageBoxIcon.Information)

        '    End If
        'End Sub

        'Private Sub CmdLoadActorInfoClick(ByVal sender As Object, ByVal e As EventArgs)

        '    Dim series As TvdbSeries = Nothing
        '    Try
        '        series = _
        '            _mTvdbHandler.GetSeries(_mCurrentSeries.Id, _mCurrentSeries.Language, _
        '                                     _mCurrentSeries.EpisodesLoaded, True, _mCurrentSeries.BannersLoaded)
        '    Catch ex As TvdbInvalidApiKeyException
        '        MessageBox.Show(ex.Message)
        '    Catch ex As TvdbNotAvailableException
        '        MessageBox.Show(ex.Message)
        '    End Try

        '    If series IsNot Nothing AndAlso series.TvdbActorsLoaded Then
        '        UpdateSeries(series)
        '    Else

        '        Dim boxNoConnection As DialogResult
        '        boxNoConnection = _
        '            MessageBox.Show(Mainform, ThetvdbNoActorInfo, ThetvdbNoActorInfoTitre, MessageBoxButtons.OK, _
        '                             MessageBoxIcon.Information)

        '    End If
        'End Sub

        'Private Sub CmdLoadBannersClick(ByVal sender As Object, ByVal e As EventArgs)

        '    Dim series As TvdbSeries = Nothing
        '    Try
        '        series = _
        '            _mTvdbHandler.GetSeries(_mCurrentSeries.Id, _mCurrentSeries.Language, _
        '                                     _mCurrentSeries.EpisodesLoaded, _mCurrentSeries.TvdbActorsLoaded, True)
        '    Catch ex As TvdbInvalidApiKeyException
        '        MessageBox.Show(ex.Message)
        '    Catch ex As TvdbNotAvailableException
        '        MessageBox.Show(ex.Message)
        '    End Try

        '    If series IsNot Nothing AndAlso series.BannersLoaded Then
        '        UpdateSeries(series)
        '    Else

        '        Dim boxNoConnection As DialogResult
        '        boxNoConnection = _
        '            MessageBox.Show(Mainform, ThetvdbNoBanner, ThetvdbNoBannerTitre, MessageBoxButtons.OK, _
        '                             MessageBoxIcon.Information)
        '    End If
        'End Sub

        Private Sub BcActorsIndexChanged(ByVal [event] As EventArgs) Handles bcActors.IndexChanged

            If ThetvdbActors.SelectedIndex <> bcActors.Index Then
                ThetvdbActors.SelectedIndex = bcActors.Index
            Else
                SetActorInfo(_mCurrentSeries.TvdbActors(bcActors.Index))
            End If
        End Sub

        Private Sub SetActorInfo(ByVal actor As TvdbActor)

            txtActorId.Text = actor.Id.ToString(CultureInfo.CurrentCulture)
            txtActorName.Text = actor.Name.ToString(CultureInfo.CurrentCulture)
            txtActorRole.Text = actor.Role.ToString(CultureInfo.CurrentCulture)
            txtActorSortOrder.Text = actor.SortOrder.ToString(CultureInfo.CurrentCulture)
        End Sub

        Private Sub LbAllActorsSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbActors.SelectedIndexChanged

            ' 14/02/2010 Si on clique en dehors de l'index (-1) dans la liste des acteurs on quitte la routine 
            If ThetvdbActors.SelectedIndex < 0 Then
                Exit Sub
            End If

            bcActors.Index = ThetvdbActors.SelectedIndex
            SetActorInfo(_mCurrentSeries.TvdbActors(ThetvdbActors.SelectedIndex))

        End Sub

        Private Sub LinkLabelLinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
            Handles llblImdb.LinkClicked, llblTvComId.LinkClicked

            If e.Link.LinkData IsNot Nothing Then
                Process.Start(CType(e.Link.LinkData, String))
                Close()
            End If
        End Sub

        Private Sub Button2Click(ByVal sender As Object, ByVal e As EventArgs) Handles ThetvdbButtonExit.Click
            Close()
            'Dispose()
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

        Private Sub ThetvdbButtonSearchShowClick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbButtonSearchShow.Click
            MySearch.Show()
            Close()
        End Sub
    End Class
End Namespace
