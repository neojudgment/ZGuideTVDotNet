' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2012 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
' |                                                                                                            |
' |    Project administrator : Pascal Hubert (neojudgment@hotmail.com)                                         |
' |                                                                                                            |
' |    This program is free software: you can redistribute it and/or modify                                    |
' |    it under the terms of the GNU General Public License as published by                                    |
' |    the Free Software Foundation, either version 2 of the License, or                                       |
' |    (at your option) any later version.                                                                     |
' |                                                                                                            |
' |    This program is distributed in the hope that it will be useful,                                         |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of                                          |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                                           |
' |    GNU General Public License for more details.                                                            |
' |                                                                                                            |
' |    You should have received a copy of the GNU General Public License                                       |
' |    along with this program.  If not, see <http://www.gnu.org/licenses/>.                                   |
' |                                                                                                            |
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
Imports ZGuideTV.SQLiteWrapper
Imports System.Globalization
Imports System.Net

Public Class TriAvance
    Private _chaineaRechercher As String = ""

    Public Property chaine_a_rechercher As String
        Get
            Return _chaineaRechercher
        End Get
        Set(ByVal Value As String)
            _chaineaRechercher = Value
        End Set
    End Property

    Private _icone As String()

    Public Property icone As String()
        Get
            Return _icone
        End Get
        Set(ByVal Value As String())
            _icone = Value
        End Set
    End Property

    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' on veut que ts les checkbox soient cochés au lancement
        TriAvanceLabeltitre.Checked = True
        'CheckBox_auteur.Checked = True
        'CheckBox_indefini.Checked = True
        TriAvanceCheckBoxNow.Checked = True
        TriAvanceCheckBoxBegin.Checked = True
        TriAvanceButtonSearch.Enabled = False
    End Sub

    'Private Sub Textbox_titre_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
    '    Handles Textbox_titre.TextChanged
    '    chaine_a_rechercher = Textbox_titre.Text
    'End Sub

    Public Sub traitement_wildcards()

        ' supprimer les etoiles au debut et a la fin de la chaine à rechercher
        Dim i1 As Integer
        Dim i2 As Integer

        With chaine_a_rechercher
            i1 = .IndexOf("*", StringComparison.CurrentCulture)
            If i1 = 0 Then
                chaine_a_rechercher = .Substring(1, .Length - 1)
            End If
            i2 = .LastIndexOf("*", StringComparison.CurrentCulture)
            If i2 = .Length - 1 Then
                chaine_a_rechercher = .Substring(0, .Length - 1)
            End If

            ' rvs75 remplacement des wilcard "msdos" par des wilcard SQL
            chaine_a_rechercher = .Replace("*", "%").Replace("?", "_")
            chaine_a_rechercher = .Replace("'", "''")
        End With
    End Sub

    Private Sub Buttton_search_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TriAvanceButtonSearch.Click

        'If Textbox_titre.Text = "" Then Exit Sub

        chaine_a_rechercher = Textbox_titre.Text
        traitement_wildcards()

        Dim reste As Integer
        Dim strSql As String
        strSql = _
            "SELECT  ChannelTbl.name, ProgramTbl.ptitle, ProgramTbl.pstart, ProgramTbl.pstop,channeltbl.logo, programtbl.pdescription, programtbl.pcategorytv FROM ProgramTbl, ChannelTbl WHERE (ProgramTbl.channelid=ChannelTbl.id) AND ("
        If TriAvanceCheckBoxNow.Checked Then
            strSql = strSql & "programtbl.pstop > '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture) & "') AND ("
        End If

        ' rvs75 19/12/2009
        ' exemple de recherche avec "chat"
        ' si CheckBox_Commencement.Checked=true
        ' recherche des mots commençant par "chat*" (rien devant)
        ' recherche des mots commençant par "* chat*" (un espace devant)
        ' recherche des mots commençant par "*(chat*" (une parenthèse devant)
        ' recherche des mots commençant par "*"chat*" (un guillemet devant
        ' si CheckBox_Commencement.Checked=false
        ' recherche des mots contenant  "*chat*"

        If TriAvanceLabeltitre.Checked Then
            If TriAvanceCheckBoxBegin.Checked Then
                strSql = strSql & "(programtbl.ptitle like '% " & chaine_a_rechercher & _
                         "%' or programtbl.psubtitle like '% " & chaine_a_rechercher & "%'" & _
                         " or programtbl.ptitle like '" & chaine_a_rechercher & "%' or programtbl.psubtitle like '" & _
                         chaine_a_rechercher & "%'" & _
                         " or programtbl.ptitle like '%«" & chaine_a_rechercher & "%' or programtbl.psubtitle like '%«" & _
                         chaine_a_rechercher & "%'" & _
                         " or programtbl.ptitle like '%(" & chaine_a_rechercher & "%' or programtbl.psubtitle like '%(" & _
                         chaine_a_rechercher & "%'" & _
                         " or programtbl.ptitle like '%""" & chaine_a_rechercher & _
                         "%' or programtbl.psubtitle like '%""" & chaine_a_rechercher & "%'" & _
                         ") OR "
            Else
                strSql = strSql & "(programtbl.ptitle like '%" & chaine_a_rechercher & _
                         "%' or programtbl.psubtitle like '%" & chaine_a_rechercher & "%') OR "
            End If
        End If
        If TriAvanceLabelauteur.Checked Then
            If TriAvanceCheckBoxBegin.Checked Then
                strSql = strSql & "(programtbl.pactors like '% " & chaine_a_rechercher & _
                         "%' or programtbl.pdirectors like '% " & chaine_a_rechercher & "%'" & _
                         " or programtbl.pactors like '" & chaine_a_rechercher & "%' or programtbl.pdirectors like '" & _
                         chaine_a_rechercher & "%'" & _
                         " or programtbl.pactors like '%«" & chaine_a_rechercher & _
                         "%' or programtbl.pdirectors like '%«" & chaine_a_rechercher & "%'" & _
                         " or programtbl.pactors like '%(" & chaine_a_rechercher & _
                         "%' or programtbl.pdirectors like '%(" & chaine_a_rechercher & "%'" & _
                         " or programtbl.pactors like '%""" & chaine_a_rechercher & _
                         "%' or programtbl.pdirectors like '%""" & chaine_a_rechercher & "%'" & _
                         ") OR "
            Else
                strSql = strSql & "(programtbl.pactors like '%" & chaine_a_rechercher & _
                         "%' or programtbl.pdirectors like '%" & chaine_a_rechercher & "%') OR "
            End If
        End If
        If TriAvanceLabelndefini.Checked Then
            If TriAvanceCheckBoxBegin.Checked Then
                strSql = strSql & "(programtbl.pdescription like '% " & chaine_a_rechercher & "%'" & _
                         " or programtbl.pdescription like '" & chaine_a_rechercher & "%'" & _
                         " or programtbl.pdescription like '%«" & chaine_a_rechercher & "%'" & _
                         " or programtbl.pdescription like '%(" & chaine_a_rechercher & "%'" & _
                         " or programtbl.pdescription like '%""" & chaine_a_rechercher & "%'" & _
                         ") OR "
            Else
                strSql = strSql & "(programtbl.pdescription like '%" & chaine_a_rechercher & "%') OR"
            End If
        End If
        strSql = strSql.Substring(0, strSql.LastIndexOf("OR", StringComparison.CurrentCulture) - 1) & ") order by programtbl.pstart"
        Dim db As SQLiteBase = New SQLiteBase
        Dim dt_Emissions As DataTable
        db.OpenDatabase(BDDPath & "db_progs.db3")
        dt_Emissions = db.ExecuteQuery(strSql)
        db.CloseDatabase()
        db = Nothing
        TriAvanceListView.Items.Clear()
        rtb_desc.Text = ""
        ReDim icone(dt_Emissions.Rows.Count)

        For r As Integer = 0 To dt_Emissions.Rows.Count - 1
            Dim EmissionItem As New ListViewItem(dt_Emissions.Rows(r).Item(0).ToString)

            With EmissionItem
                .SubItems.Add(dt_Emissions.Rows(r).Item(1).ToString)
                .SubItems.Add(CDate(dt_Emissions.Rows(r).Item(2)).ToString("dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture))
                .SubItems.Add(CDate(dt_Emissions.Rows(r).Item(3)).ToString("dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture))
                .SubItems.Add(dt_Emissions.Rows(r).Item(6).ToString)
                icone(r) = dt_Emissions.Rows(r).Item(4).ToString
                .Tag = dt_Emissions.Rows(r).Item(5)
                Math.DivRem(r, 2, reste)
                If (reste = 0) Then
                    .BackColor = Color.WhiteSmoke
                End If
                TriAvanceListView.Items.Add(EmissionItem)
            End With
        Next
        If TriAvanceListView.Items.Count > 0 Then
            TriAvanceListView.Items(0).Selected = True
        End If

        TriAvanceButtonCancel.Visible = True
        TriAvanceButtonSearch.Visible = True
        TriAvanceButtonSearch.Enabled = True

    End Sub

    Private Sub Button_return_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TriAvanceButtonCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub CheckBox_auteur_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TriAvanceLabelauteur.CheckedChanged, TriAvanceLabelauteur.CheckedChanged

        If TriAvanceLabelauteur.Checked Then
            Textbox_titre.Visible = True
        Else
            Dim b2 As Boolean
            Dim b3 As Boolean
            b2 = TriAvanceLabeltitre.Checked
            b3 = TriAvanceLabelndefini.Checked
            If Not b2 AndAlso Not b3 Then
                Textbox_titre.Visible = False
            End If
        End If

        ' donner le focus là où l'on doit écrire
        Textbox_titre.Focus()

    End Sub

    Private Sub CheckBox_indefini_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TriAvanceLabelndefini.CheckedChanged

        If TriAvanceLabelndefini.Checked Then
            Textbox_titre.Visible = True
        Else
            Dim b1 As Boolean
            Dim b2 As Boolean
            b1 = TriAvanceLabelauteur.Checked
            b2 = TriAvanceLabeltitre.Checked
            If Not b1 AndAlso Not b2 Then
                Textbox_titre.Visible = False
            End If
        End If

        ' donner le focus là où l'on doit écrire
        Textbox_titre.Focus()

    End Sub

    Private Sub tri_avance_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        With Mainform
            .ToolStripSearch.Enabled = True
            .ToolStripMenuSearch.Enabled = True
            .JumelleEnfonce = False
        End With
    End Sub

    Private Sub tri_avance_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Mainform.ToolStripSearch.Enabled = False
        Mainform.ToolStripMenuSearch.Enabled = False

        ' modifié le 09/03/2009

        Try
            LanguageCheck()

            Me.AcceptButton = TriAvanceButtonSearch

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " plantage lors de languagecheck de tri_avance")
        End Try

        If Textbox_titre.Text <> " " Then
            TriAvanceButtonSearch.PerformClick()
        End If

    End Sub

    ' on recherche petite chaine dans grande chaine
    Public Function recherche(ByVal Petite_chaine As String, ByVal Grande_chaine As String) As Integer
        Return (Grande_chaine.IndexOf(Petite_chaine, StringComparison.CurrentCulture))
    End Function

    Private Sub CheckBox_titre_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TriAvanceLabeltitre.CheckStateChanged, TriAvanceLabeltitre.CheckStateChanged

        If TriAvanceLabeltitre.Checked Then
            Textbox_titre.Visible = True
        Else
            Dim b1 As Boolean
            Dim b3 As Boolean
            b1 = TriAvanceLabelauteur.Checked
            b3 = TriAvanceLabelndefini.Checked
            If Not b1 AndAlso Not b3 Then
                Textbox_titre.Visible = False
            End If
        End If
        Textbox_titre.Focus()
    End Sub

    Private Sub ProgramListView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TriAvanceListView.DoubleClick

        If TriAvanceListView.SelectedItems.Count = 1 Then

            Try
                If IsNetConnectOnline() Then
                    ThetvdbName = TriAvanceListView.Items(TriAvanceListView.SelectedIndices.Item(0)).SubItems(1).Text
                    Me.TopMost = False
                    Me.SuspendLayout()
                    My.Forms.SeriesBrowser.ShowDialog()
                    Me.ResumeLayout()
                    Me.TopMost = True
                Else

                    ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                    ' la fiche thetvdb.com
                    Dim BoxNoConnection As DialogResult
                    BoxNoConnection = _
                        MessageBox.Show(Central_Screen.MessageBoxNoConnection & Chr(13) & Central_Screen.MessageBoxNoConnection1, Central_Screen.MessageBoxNoConnectionTitre, _
                                         MessageBoxButtons.OK, _
                                         MessageBoxIcon.Exclamation)
                End If

            Catch ex As WebException
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(Central_Screen.MessageBoxNoConnection & Chr(13) & Central_Screen.MessageBoxNoConnection1, Central_Screen.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Sub ProgramListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TriAvanceListView.SelectedIndexChanged

        If TriAvanceListView.SelectedItems.Count = 1 Then
            pb_chaine.Image = Image.FromFile(LogosPath & icone(TriAvanceListView.SelectedIndices.Item(0)))
            rtb_desc.Text = TriAvanceListView.SelectedItems(0).Tag.ToString
        End If

    End Sub

    Private Sub Textbox_titre_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Textbox_titre.TextChanged

        With Textbox_titre
            .Text = .Text.Replace("_", "")
            .Text = .Text.Replace("%", "")
            If .Text.Length > 1 Then
                TriAvanceButtonSearch.Enabled = True
            Else
                TriAvanceButtonSearch.Enabled = False
            End If
        End With
    End Sub
End Class