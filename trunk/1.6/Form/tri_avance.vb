' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2014 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

' ReSharper disable CheckNamespace
Public Class TriAvance
    ' ReSharper restore CheckNamespace

    Private _chaineARrechercher As String
    Private _icone As String()

    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' on veut que ts les checkbox soient cochés au lancement
        TriAvanceLabeltitre.Checked = True
        TriAvanceCheckBoxNow.Checked = True
        TriAvanceCheckBoxBegin.Checked = True
        TriAvanceButtonSearch.Enabled = False
    End Sub

    Private Sub TraitementWildcards()

        ' supprimer les etoiles au debut et a la fin de la chaine à rechercher
        Dim i1 As Integer
        Dim i2 As Integer

        With _chaineARrechercher
            i1 = .IndexOf("*", StringComparison.CurrentCulture)
            If i1 = 0 Then
                _chaineARrechercher = .Substring(1, .Length - 1)
            End If
            i2 = .LastIndexOf("*", StringComparison.CurrentCulture)
            If i2 = .Length - 1 Then
                _chaineARrechercher = .Substring(0, .Length - 1)
            End If

            ' rvs75 remplacement des wilcard "msdos" par des wilcard SQL
            _chaineARrechercher = .Replace("*", "%").Replace("?", "_")
            _chaineARrechercher = .Replace("'", "''")
        End With
    End Sub

    Private Sub ButttonSearchClick(ByVal sender As Object, ByVal e As EventArgs) Handles TriAvanceButtonSearch.Click

        _chaineARrechercher = Textbox_titre.Text
        TraitementWildcards()

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
                strSql = strSql & "(programtbl.ptitle like '% " & _chaineARrechercher & _
                         "%' or programtbl.psubtitle like '% " & _chaineARrechercher & "%'" & _
                         " or programtbl.ptitle like '" & _chaineARrechercher & "%' or programtbl.psubtitle like '" & _
                         _chaineARrechercher & "%'" & _
                         " or programtbl.ptitle like '%«" & _chaineARrechercher & "%' or programtbl.psubtitle like '%«" & _
                         _chaineARrechercher & "%'" & _
                         " or programtbl.ptitle like '%(" & _chaineARrechercher & "%' or programtbl.psubtitle like '%(" & _
                         _chaineARrechercher & "%'" & _
                         " or programtbl.ptitle like '%""" & _chaineARrechercher & _
                         "%' or programtbl.psubtitle like '%""" & _chaineARrechercher & "%'" & _
                         ") OR "
            Else
                strSql = strSql & "(programtbl.ptitle like '%" & _chaineARrechercher & _
                         "%' or programtbl.psubtitle like '%" & _chaineARrechercher & "%') OR "
            End If
        End If
        If TriAvanceLabelauteur.Checked Then
            If TriAvanceCheckBoxBegin.Checked Then
                strSql = strSql & "(programtbl.pactors like '% " & _chaineARrechercher & _
                         "%' or programtbl.pdirectors like '% " & _chaineARrechercher & "%'" & _
                         " or programtbl.pactors like '" & _chaineARrechercher & "%' or programtbl.pdirectors like '" & _
                         _chaineARrechercher & "%'" & _
                         " or programtbl.pactors like '%«" & _chaineARrechercher & _
                         "%' or programtbl.pdirectors like '%«" & _chaineARrechercher & "%'" & _
                         " or programtbl.pactors like '%(" & _chaineARrechercher & _
                         "%' or programtbl.pdirectors like '%(" & _chaineARrechercher & "%'" & _
                         " or programtbl.pactors like '%""" & _chaineARrechercher & _
                         "%' or programtbl.pdirectors like '%""" & _chaineARrechercher & "%'" & _
                         ") OR "
            Else
                strSql = strSql & "(programtbl.pactors like '%" & _chaineARrechercher & _
                         "%' or programtbl.pdirectors like '%" & _chaineARrechercher & "%') OR "
            End If
        End If
        If TriAvanceLabelndefini.Checked Then
            If TriAvanceCheckBoxBegin.Checked Then
                strSql = strSql & "(programtbl.pdescription like '% " & _chaineARrechercher & "%'" & _
                         " or programtbl.pdescription like '" & _chaineARrechercher & "%'" & _
                         " or programtbl.pdescription like '%«" & _chaineARrechercher & "%'" & _
                         " or programtbl.pdescription like '%(" & _chaineARrechercher & "%'" & _
                         " or programtbl.pdescription like '%""" & _chaineARrechercher & "%'" & _
                         ") OR "
            Else
                strSql = strSql & "(programtbl.pdescription like '%" & _chaineARrechercher & "%') OR"
            End If
        End If
        strSql = strSql.Substring(0, strSql.LastIndexOf("OR", StringComparison.CurrentCulture) - 1) & ") order by programtbl.pstart"
        Dim db As SqLiteBase = New SqLiteBase
        Dim dtEmissions As DataTable
        db.OpenDatabase(BddPath & "db_progs.db3")
        dtEmissions = db.ExecuteQuery(strSql)
        db.CloseDatabase()

        TriAvanceListView.Items.Clear()
        rtb_desc.Text = ""
        ReDim _icone(dtEmissions.Rows.Count)

        For r As Integer = 0 To dtEmissions.Rows.Count - 1
            Dim emissionItem As New ListViewItem(dtEmissions.Rows(r).Item(0).ToString)

            With emissionItem
                .SubItems.Add(dtEmissions.Rows(r).Item(1).ToString)
                .SubItems.Add(CDate(dtEmissions.Rows(r).Item(2)).ToString("dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture))
                .SubItems.Add(CDate(dtEmissions.Rows(r).Item(3)).ToString("dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture))
                .SubItems.Add(dtEmissions.Rows(r).Item(6).ToString)
                _icone(r) = dtEmissions.Rows(r).Item(4).ToString
                .Tag = dtEmissions.Rows(r).Item(5)
                Math.DivRem(r, 2, reste)
                If (reste = 0) Then
                    .BackColor = Color.WhiteSmoke
                End If
                TriAvanceListView.Items.Add(emissionItem)
            End With
        Next
        If TriAvanceListView.Items.Count > 0 Then
            TriAvanceListView.Items(0).Selected = True
        End If

        TriAvanceButtonCancel.Visible = True
        TriAvanceButtonSearch.Visible = True
        TriAvanceButtonSearch.Enabled = True

    End Sub

    Private Sub ButtonReturnClick(ByVal sender As Object, ByVal e As EventArgs) Handles TriAvanceButtonCancel.Click

        Close()
    End Sub

    Private Sub CheckBoxAuteurCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
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

    Private Sub CheckBoxIndefiniCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
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

    Private Sub TriAvanceFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        _chaineARrechercher = Nothing
        Textbox_titre.Text = Nothing

        With Mainform
            .ToolStripSearch.Enabled = True
            .ToolStripMenuSearch.Enabled = True
            .JumelleEnfonce = False
        End With

        Dispose()
    End Sub

    Private Sub TriAvanceLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Mainform.ToolStripSearch.Enabled = False
        Mainform.ToolStripMenuSearch.Enabled = False

        ' modifié le 09/03/2009

        Try
            LanguageCheck()

            AcceptButton = TriAvanceButtonSearch

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " plantage lors de languagecheck de tri_avance")
        End Try

        If Not [String].Equals(Textbox_titre.Text, " ", StringComparison.CurrentCulture) Then
            TriAvanceButtonSearch.PerformClick()
        End If

    End Sub

    Private Sub CheckBoxTitreCheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
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

    Private Sub ProgramListViewDoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TriAvanceListView.DoubleClick

        If TriAvanceListView.SelectedItems.Count = 1 Then

            Try
                If My.Computer.Network.IsAvailable Then
                    ThetvdbName = TriAvanceListView.Items(TriAvanceListView.SelectedIndices.Item(0)).SubItems(1).Text
                    TopMost = False
                    SuspendLayout()
                    My.Forms.SeriesBrowser.ShowDialog()
                    ResumeLayout()
                    TopMost = True
                Else

                    ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                    ' la fiche thetvdb.com
                    ' ReSharper disable NotAccessedVariable
                    Dim boxNoConnection As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxNoConnection = _
                        MessageBox.Show(CentralScreen.MessageBoxNoConnection & Chr(13) & CentralScreen.MessageBoxNoConnection1, CentralScreen.MessageBoxNoConnectionTitre, _
                                         MessageBoxButtons.OK, _
                                         MessageBoxIcon.Exclamation)
                End If

            Catch ex As WebException
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection = _
                    MessageBox.Show(CentralScreen.MessageBoxNoConnection & Chr(13) & CentralScreen.MessageBoxNoConnection1, CentralScreen.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Sub ProgramListViewSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TriAvanceListView.SelectedIndexChanged

        If TriAvanceListView.SelectedItems.Count = 1 Then
            pb_chaine.Image = Image.FromFile(LogosPath & _icone(TriAvanceListView.SelectedIndices.Item(0)))
            rtb_desc.Text = TriAvanceListView.SelectedItems(0).Tag.ToString
        End If

    End Sub

    Private Sub TextboxTitreTextChanged(ByVal sender As Object, ByVal e As EventArgs) _
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