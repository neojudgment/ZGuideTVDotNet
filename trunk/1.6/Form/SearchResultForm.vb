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
Imports TvdbLib.Data

' ReSharper disable CheckNamespace
Namespace ZGuideTVDotNetTvdb
    ' ReSharper restore CheckNamespace
    Public Class SearchResultForm
        Inherits Form

        'Private _mResults As List(Of TvdbSearchResult)
        Private _mSelection As TvdbSearchResult = Nothing

        '' 11/10/2010 Griser et désactiver la croix rouge de la form
        'Private Const CsNoclose As Integer = &H200

        'Protected Overrides ReadOnly Property CreateParams() As CreateParams
        '    Get
        '        Dim cp As CreateParams = MyBase.CreateParams
        '        cp.ClassStyle = cp.ClassStyle Or CsNoclose
        '        Return cp
        '    End Get
        'End Property

        ' Variable gérée lors du SearchResultForm_FormClosing
        Private _quitSearch As Boolean = True

        Friend Sub New(ByVal searchResults As IEnumerable(Of TvdbSearchResult), ByVal lngTab() As String)
            InitializeComponent()

            '_mResults = searchResults
            For Each r As TvdbSearchResult In searchResults
                Dim item As New ListViewItem(r.Id.ToString())

                With item
                    .SubItems.Add(r.SeriesName)
                    .SubItems.Add(r.Language.Name)
                    .Tag = r
                    lvSearchResult.Items.Add(item)
                End With
            Next r

            ThetvdbGroupBoxResult.Text = lngTab(0)
            ThetvdblabelFirstAiredResult.Text = lngTab(1)
            ThetvdbLabelIMDBIdResult.Text = lngTab(2)
            ThetvdbLabelOverviewResult.Text = lngTab(3)
            ThetvdbLabelStatusResult.Text = lngTab(4)
            ThetvdbButtonChooseResult.Text = lngTab(5)
            ThetvdbButtonCancelResult.Text = lngTab(6)
            lvSearchResult.Columns(0).Text = lngTab(7)
            lvSearchResult.Columns(1).Text = lngTab(8)
            lvSearchResult.Columns(2).Text = lngTab(9)

        End Sub

        Friend Sub New(ByVal searchResults As IEnumerable(Of TvdbSearchResult))
            InitializeComponent()

            '_mResults = searchResults
            For Each r As TvdbSearchResult In searchResults
                Dim item As New ListViewItem(r.Id.ToString())

                With item
                    .SubItems.Add(r.SeriesName)
                    .SubItems.Add(r.Language.Name)
                    .Tag = r
                    lvSearchResult.Items.Add(item)
                End With
            Next r
        End Sub

        Public Sub New()

            InitializeComponent()

        End Sub

        Private Sub SearchResultFormFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
            Handles Me.FormClosing

            If _quitSearch = True Then
                SeriesBrowser.Close()
            End If

            Dispose()
        End Sub

        Private Sub SearchResultFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            LanguageCheck()

            ' Par défaut c'est le boutton "Choisir" qui est appuyer quand on fait Enter
            AcceptButton = ThetvdbButtonChooseResult

            ' A l'ouverture de SearchResultForm on sélectionne et on affiche la description
            ' de la 1ère série dans la liste affichée
            ' C'est juste pour que cela ne reste pas vide ;)
            lvSearchResult.TopItem.Selected = True
            _mSelection = CType(lvSearchResult.SelectedItems(0).Tag, TvdbSearchResult)
            bcSeriesBanner.ClearControl()

            If _mSelection IsNot Nothing Then
                bcSeriesBanner.BannerImage = _mSelection.Banner
            End If

            txtOverview.Text = _mSelection.Overview
            linkImdb.Text = _
                If(String.IsNullOrEmpty(_mSelection.ImdbId), "", "http://www.imdb.com/title/" & _mSelection.ImdbId)
            txtFirstAired.Text = _mSelection.FirstAired.ToShortDateString()

        End Sub

        Private Sub CmdChooseClick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbButtonChooseResult.Click

            If _mSelection Is Nothing Then
                ThetvdbLabelStatusResult.Text = lngThetvdbLabelStatusResult
            Else
                DialogResult = Windows.Forms.DialogResult.OK
                _quitSearch = False
                Close()
            End If
        End Sub

        Private Sub CmdCancelClick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbButtonCancelResult.Click
            DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Friend Property Selection() As TvdbSearchResult
            Get
                Return _mSelection
            End Get
            Set(ByVal value As TvdbSearchResult)
                _mSelection = value
            End Set
        End Property

        Private Sub LvSearchResultDoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles lvSearchResult.DoubleClick

            If _mSelection Is Nothing Then
                ThetvdbLabelStatusResult.Text = lngThetvdbLabelStatusResult
            Else
                DialogResult = Windows.Forms.DialogResult.OK
                _quitSearch = False
                Close()
            End If
        End Sub

        Private Sub LvSearchResultSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
            Handles lvSearchResult.SelectedIndexChanged

            With bcSeriesBanner
                If lvSearchResult.SelectedItems.Count = 1 Then
                    _mSelection = CType(lvSearchResult.SelectedItems(0).Tag, TvdbSearchResult)
                    .ClearControl()

                    If .LoadingBackgroundColor = Color.Black Then
                        .LoadingBackgroundColor = Color.Transparent
                    End If

                    If _mSelection IsNot Nothing Then
                        .BannerImage = _mSelection.Banner
                    End If

                    txtOverview.Text = _mSelection.Overview
                    linkImdb.Text = _
                        If(String.IsNullOrEmpty(_mSelection.ImdbId), "", "http://www.imdb.com/title/" & _mSelection.ImdbId)
                    txtFirstAired.Text = _mSelection.FirstAired.ToShortDateString()
                End If
            End With
        End Sub

        Private Sub LinkImdbLinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
            Handles linkImdb.LinkClicked
            Process.Start(linkImdb.Text)
        End Sub
    End Class
End Namespace
