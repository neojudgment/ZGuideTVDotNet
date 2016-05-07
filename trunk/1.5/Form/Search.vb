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

' ReSharper disable CheckNamespace
Public Class MySearch
    ' ReSharper restore CheckNamespace
    Private _mTvdbHandler As TvdbHandler
    Private _language As String

    Private Sub MySearchFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dispose()
    End Sub

    Private Sub Search(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        LanguageCheck()
        txtSeriesToFind.Text = ""

        ' Par défaut c'est le boutton "Rechercher" qui est appuyer quand on fait enter
        AcceptButton = ThetvdbButtonSearch

        Dim p As ICacheProvider
        Dim _
            cachePath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                                  "\ZGuideTVDotNet\"
        p = New XmlCacheProvider(cachePath.Substring _
                                      (0, cachePath.LastIndexOf("\", StringComparison.CurrentCulture)) & "\Cache")

        _mTvdbHandler = New TvdbHandler(p, API_KEY)
        _mTvdbHandler.InitCache()

        Dim mLanguages As List(Of TvdbLanguage) = _mTvdbHandler.Languages

        For Each l As TvdbLanguage In mLanguages
            cbLanguage.Items.Add(l)
        Next l

        ' On regarde dans le fichier .lng la variable lngLanguage
        ' On prend les 2 1ère lettres à partir de la gauche et on les met en LowCase (minuscule)
        ' ce qui donne fr, en, ru etc...
        _language = LSet(lngLanguage, 2).ToLower()

        With cbLanguage
            For i As Integer = 0 To .Items.Count - 1
                If [String].Equals(CType(.Items(i), TvdbLanguage).Abbriviation, _language, StringComparison.CurrentCulture) Then
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

    Private Sub CmdFindSeriesClick(ByVal sender As Object, ByVal e As EventArgs) Handles ThetvdbButtonSearch.Click

        If (Not txtSeriesToFind.Text Is Nothing AndAlso String.IsNullOrEmpty(txtSeriesToFind.Text)) Then
            Exit Sub
        Else
            ThetvdbName = txtSeriesToFind.Text
            SeriesBrowser.ShowDialog()
            Close()
        End If
    End Sub

    'Friend Sub CbUseZippedCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

    '    If ThetvdbLabelUseZipped.Checked Then
    '        ThetvdbLabelLoadFull.Checked = True
    '        ThetvdbLabelLoadFull.Enabled = False
    '        ThetvdbLabelBanner.Checked = True
    '        ThetvdbLabelBanner.Enabled = False
    '        ThetvdbLabelLoadActors.Checked = True
    '        ThetvdbLabelLoadActors.Enabled = False
    '    Else
    '        ThetvdbLabelLoadFull.Enabled = True
    '        ThetvdbLabelBanner.Enabled = True
    '        ThetvdbLabelLoadActors.Enabled = True
    '    End If
    'End Sub

    Private Sub ThetvdbButtonLoadClick(ByVal sender As Object, ByVal e As EventArgs) Handles ThetvdbButtonLoad.Click

        If (Not txtGetSeries.Text Is Nothing AndAlso String.IsNullOrEmpty(txtGetSeries.Text)) Then
            Exit Sub
        Else
            Exit Sub
            'Dim SerieID As String = txtGetSeries.Text
            'SeriesBrowser.Show()
            'Me.Close()
        End If
    End Sub

    Private Sub CbLanguageSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbLanguage.SelectedIndexChanged

        With cbLanguage
            If .SelectedItem IsNot Nothing AndAlso .SelectedItem.GetType() Is GetType(TvdbLanguage) _
                Then
                lblCurrentLanguage.Text = "[" & (CType(.SelectedItem, TvdbLanguage)).ToString() & "]"
                ThetvdbLanguage = CType(.SelectedItem, TvdbLanguage)
            End If
        End With
    End Sub

    Private Sub ThetvdbButtonCancelClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles ThetvdbButtonCancel.Click
        Close()
    End Sub
End Class