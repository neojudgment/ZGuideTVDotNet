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
Imports ZGuideTV.My.Resources
Imports TvdbLib.Cache
Imports TvdbLib
Imports ZGuideTV.ZGuideTVDotNetTvdb

Public Class search
    Private m_tvdbHandler As TvdbHandler
    Private _language As String

    Public Property Language As String
        Get
            Return _language
        End Get
        Set(ByVal Value As String)
            _language = Value
        End Set
    End Property

    Friend Sub Search(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        LanguageCheck()
        txtSeriesToFind.Text = ""

        ' Par défaut c'est le boutton "Rechercher" qui est appuyer quand on fait enter
        Me.AcceptButton = ThetvdbButtonSearch

        Dim p As ICacheProvider = Nothing
        Dim _
            CachePath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                                  "\ZGuideTVDotNet\"
        p = New XmlCacheProvider(CachePath.Substring _
                                      (0, CachePath.LastIndexOf("\", StringComparison.CurrentCulture)) & "\Cache")

        m_tvdbHandler = New TvdbHandler(p, API_KEY)
        m_tvdbHandler.InitCache()

        Dim m_languages As List(Of TvdbLanguage) = m_tvdbHandler.Languages

        For Each l As TvdbLanguage In m_languages
            cbLanguage.Items.Add(l)
        Next l

        ' On regarde dans le fichier .lng la variable lngLanguage
        ' On prend les 2 1ère lettres à partir de la gauche et on les met en LowCase (minuscule)
        ' ce qui donne fr, en, ru etc...
        Language = LSet(lngLanguage, 2).ToLower()

        With cbLanguage
            For i As Integer = 0 To .Items.Count - 1
                If CType(.Items(i), TvdbLanguage).Abbriviation = Language Then
                    .SelectedIndex = i
                    ThetvdbLanguage = CType(.Items(i), TvdbLanguage)
                End If
            Next i
        End With

        lblCurrentLanguage.Text = "[" & ThetvdbLanguage.ToString() & "]"

    End Sub

    Public Sub New()

        InitializeComponent()

    End Sub

    Friend Sub cmdFindSeries_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ThetvdbButtonSearch.Click

        If (Not txtSeriesToFind.Text Is Nothing AndAlso String.IsNullOrEmpty(txtSeriesToFind.Text)) Then
            Exit Sub
        Else
            ThetvdbName = txtSeriesToFind.Text
            SeriesBrowser.ShowDialog()
            Me.Close()
        End If
    End Sub

    Friend Sub cbUseZipped_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

        If ThetvdbLabelUseZipped.Checked Then
            ThetvdbLabelLoadFull.Checked = True
            ThetvdbLabelLoadFull.Enabled = False
            ThetvdbLabelBanner.Checked = True
            ThetvdbLabelBanner.Enabled = False
            ThetvdbLabelLoadActors.Checked = True
            ThetvdbLabelLoadActors.Enabled = False
        Else
            ThetvdbLabelLoadFull.Enabled = True
            ThetvdbLabelBanner.Enabled = True
            ThetvdbLabelLoadActors.Enabled = True
        End If
    End Sub

    Private Sub ThetvdbButtonLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ThetvdbButtonLoad.Click

        If (Not txtGetSeries.Text Is Nothing AndAlso String.IsNullOrEmpty(txtGetSeries.Text)) Then
            Exit Sub
        Else
            Exit Sub
            'Dim SerieID As String = txtGetSeries.Text
            'SeriesBrowser.Show()
            'Me.Close()
        End If
    End Sub

    Friend Sub cbLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbLanguage.SelectedIndexChanged

        With cbLanguage
            If .SelectedItem IsNot Nothing AndAlso .SelectedItem.GetType() Is GetType(TvdbLanguage) _
                Then
                lblCurrentLanguage.Text = "[" & (CType(.SelectedItem, TvdbLanguage)).ToString() & "]"
                ThetvdbLanguage = CType(.SelectedItem, TvdbLanguage)
            End If
        End With
    End Sub

    Private Sub ThetvdbButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThetvdbButtonCancel.Click
        Me.Close()
    End Sub
End Class