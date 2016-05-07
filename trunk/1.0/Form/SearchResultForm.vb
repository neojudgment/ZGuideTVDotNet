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

Namespace ZGuideTVDotNetTvdb
    Public Class SearchResultForm
        Inherits Form

        Private m_results As List(Of TvdbSearchResult)
        Private m_selection As TvdbSearchResult = Nothing

        ' 11/10/2010 Griser et désactiver la croix rouge de la form
        Private Const CS_NOCLOSE As Integer = &H200

        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
                Return cp
            End Get
        End Property

        ' Variable gérée lors du SearchResultForm_FormClosing
        Private _quitSearch As Boolean = True

        Public Property QuitSearch As Boolean
            Get
                Return _quitSearch
            End Get
            Set(ByVal Value As Boolean)
                _quitSearch = Value
            End Set
        End Property

        Friend Sub New(ByVal _searchResults As List(Of TvdbSearchResult), ByVal LngTab() As String)
            InitializeComponent()

            m_results = _searchResults
            For Each r As TvdbSearchResult In _searchResults
                Dim item As New ListViewItem(r.Id.ToString())

                With item
                    .SubItems.Add(r.SeriesName)
                    .SubItems.Add(r.Language.Name)
                    .Tag = r
                    lvSearchResult.Items.Add(item)
                End With
            Next r

            ThetvdbGroupBoxResult.Text = LngTab(0)
            ThetvdblabelFirstAiredResult.Text = LngTab(1)
            ThetvdbLabelIMDBIdResult.Text = LngTab(2)
            ThetvdbLabelOverviewResult.Text = LngTab(3)
            ThetvdbLabelStatusResult.Text = LngTab(4)
            ThetvdbButtonChooseResult.Text = LngTab(5)
            ThetvdbButtonCancelResult.Text = LngTab(6)
            lvSearchResult.Columns(0).Text = LngTab(7)
            lvSearchResult.Columns(1).Text = LngTab(8)
            lvSearchResult.Columns(2).Text = LngTab(9)

        End Sub

        Friend Sub New(ByVal _searchResults As List(Of TvdbSearchResult))
            InitializeComponent()

            m_results = _searchResults
            For Each r As TvdbSearchResult In _searchResults
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

        Private Sub SearchResultForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
            Handles Me.FormClosing

            If QuitSearch = True Then
                SeriesBrowser.Close()
            End If
        End Sub

        Friend Sub SearchResultForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            LanguageCheck()

            ' Par défaut c'est le boutton "Choisir" qui est appuyer quand on fait Enter
            Me.AcceptButton = ThetvdbButtonChooseResult

            ' A l'ouverture de SearchResultForm on sélectionne et on affiche la description
            ' de la 1ère série dans la liste affichée
            ' C'est juste pour que cela ne reste pas vide ;)
            lvSearchResult.TopItem.Selected = True
            m_selection = CType(lvSearchResult.SelectedItems(0).Tag, TvdbSearchResult)
            bcSeriesBanner.ClearControl()

            If m_selection IsNot Nothing Then
                bcSeriesBanner.BannerImage = m_selection.Banner
            End If

            txtOverview.Text = m_selection.Overview
            linkImdb.Text = _
                If(String.IsNullOrEmpty(m_selection.ImdbId), "", "http://www.imdb.com/title/" & m_selection.ImdbId)
            txtFirstAired.Text = m_selection.FirstAired.ToShortDateString()

        End Sub

        Private Sub cmdChoose_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbButtonChooseResult.Click

            If m_selection Is Nothing Then
                ThetvdbLabelStatusResult.Text = lngThetvdbLabelStatusResult
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                QuitSearch = False
                Me.Close()
            End If
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ThetvdbButtonCancelResult.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Friend Property Selection() As TvdbSearchResult
            Get
                Return m_selection
            End Get
            Set(ByVal value As TvdbSearchResult)
                m_selection = value
            End Set
        End Property

        Private Sub lvSearchResult_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles lvSearchResult.DoubleClick

            If m_selection Is Nothing Then
                ThetvdbLabelStatusResult.Text = lngThetvdbLabelStatusResult
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                QuitSearch = False
                Me.Close()
            End If
        End Sub

        Private Sub lvSearchResult_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
            Handles lvSearchResult.SelectedIndexChanged

            With bcSeriesBanner
                If lvSearchResult.SelectedItems.Count = 1 Then
                    m_selection = CType(lvSearchResult.SelectedItems(0).Tag, TvdbSearchResult)
                    .ClearControl()

                    If .LoadingBackgroundColor = System.Drawing.Color.Black Then
                        .LoadingBackgroundColor = System.Drawing.Color.Transparent
                    End If

                    If m_selection IsNot Nothing Then
                        .BannerImage = m_selection.Banner
                    End If

                    txtOverview.Text = m_selection.Overview
                    linkImdb.Text = _
                        If(String.IsNullOrEmpty(m_selection.ImdbId), "", "http://www.imdb.com/title/" & m_selection.ImdbId)
                    txtFirstAired.Text = m_selection.FirstAired.ToShortDateString()
                End If
            End With
        End Sub

        Private Sub linkImdb_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
            Handles linkImdb.LinkClicked
            Process.Start(linkImdb.Text)
        End Sub
    End Class
End Namespace
