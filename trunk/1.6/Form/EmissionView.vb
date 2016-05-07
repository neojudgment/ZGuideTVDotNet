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

Imports System.Globalization
Imports System.Text
Imports ZGuideTV.SQLiteWrapper' ReSharper disable once CheckNamespace

Public Class EmissionView
    Private Structure InfoChaine
        Public Property Logo As String
        Public Property Nom As String

        Public Sub New(nomLogo As String, nomchaine As String)
            Logo = nomLogo
            Nom = nomchaine
        End Sub
    End Structure

    Dim _dejaCree As Boolean = False
    Private ReadOnly _listechannel As New Dictionary(Of String, InfoChaine)
    Dim list(500) As EmissionsList

    Private Sub EmissionView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'recuperation des chaines si la liste est vide
        If _listechannel.Count = 0 Then

            Dim strSql As String
            strSql =
                "select channeltbl.name, channeltbl.id, channeltbl.logo  from channeltbl group by channeltbl.id order by ordering "

            Dim db As SqLiteBase = New SqLiteBase
            Dim dtChaines As DataTable
            db.OpenDatabase(BddPath & "db_progs.db3")
            dtChaines = db.ExecuteQuery(strSql)
            db.CloseDatabase()

            For r As Integer = 0 To dtChaines.Rows.Count - 1
                _listechannel.Add(dtChaines.Rows(r).Item(1).ToString,
                                  New InfoChaine(dtChaines.Rows(r).Item(2).ToString, dtChaines.Rows(r).Item(0).ToString))
            Next
        End If

        If _dejaCree Then 'desactivation des evenements
            RemoveHandler dtp_Jour.ValueChanged, AddressOf Heure_changed
            RemoveHandler cboHeure.SelectedIndexChanged, AddressOf Heure_changed
            RemoveHandler cboMinutes.SelectedIndexChanged, AddressOf Heure_changed
        End If

        'mise à jour de la datetimepicker et des combobox heures et minutes
        dtp_Jour.Value = DateTimeEmission
        cboHeure.SelectedIndex = DateTimeEmission.Hour
        For i As Integer = 0 To cboMinutes.Items.Count - 1
            If cboMinutes.Items(i).ToString().Equals(DateTimeEmission.ToString("mm")) Then
                cboMinutes.SelectedIndex = i
                Exit For
            End If
        Next

        'affichage des donnees
        AfficheHeure()

        'reactivation des evenement
        AddHandler dtp_Jour.ValueChanged, AddressOf Heure_changed
        AddHandler cboHeure.SelectedIndexChanged, AddressOf Heure_changed
        AddHandler cboMinutes.SelectedIndexChanged, AddressOf Heure_changed

        'selection du premier item de la listview
        If EmissionListView.Items.Count > 0 Then
            EmissionListView.Items(0).Selected = True
        End If

        'la fenetre à déja été créé
        _dejaCree = True
    End Sub

    Private Sub AfficheHeure()
        'Dim strSql As String
        Dim reste As Integer
        Dim d As DateTime = dtp_Jour.Value

        'creation de la date a partir du datetimepicker et des combobox heure et minute
        DateTimeEmission =
            New DateTime(d.Year, d.Month, d.Day).AddHours(cboHeure.SelectedIndex).AddMinutes(
                CDbl(cboMinutes.SelectedItem))
        Dim heure As String = DateTimeEmission.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)

        'recuperation des emissions dans la base
        Dim db As SqLiteBase = New SqLiteBase
        Dim strsql2 As New StringBuilder()
        With strsql2
            .Append("SELECT programtbl.ChannelID , programtbl.PTitle ,programtbl.psubtitle, ")
            .Append("programtbl.Pstart, programtbl.Pstop, programtbl.Pduration, ")
            .Append("programtbl.PCategoryTV , programtbl.PCategory, programtbl.Pdescription,  ")
            .Append("programtbl.Prating , programtbl.pactors ,  programtbl.PDirectors, ")
            .Append("programtbl.Ppresents, programtbl.audiostereo, programtbl.Premiere,")
            .Append("programtbl.Showview, programtbl.subtype, programtbl.Pdate, ")
            .Append("channeltbl.ordering FROM Programtbl , channeltbl ")
            .Append("WHERE (((ProgramTbl.ChannelID)= ChannelTbl.id)) ")
            .Append("and PStart<= '" & heure & "' and PStop>= '" & heure & "'")
        End With
        ReDim list(500)
        Dim nb As Integer
        With db
            .OpenDatabase(BddPath & "db_progs.db3")
            nb = db.ExecuteQuery2TableauListEmissions(strsql2.ToString, list, 0)
            .CloseDatabase()
        End With
        ReDim Preserve list(nb - 1)
        'nettoyage de la listview des emissions
        EmissionListView.Items.Clear()
        Dim r As Integer = 0
        For Each c As EmissionsList In list
            'creation de l'item
            Dim emissionItem As New ListViewItem(_listechannel(c.ChannelId).Nom)
            EmissionListView.Items.Add(emissionItem)

            'ajout des information à l'item
            With emissionItem
                .SubItems.Add(CDate(c.Pstart).ToString("HH:mm"))
                .SubItems(1).Tag = c.ChannelId
                .SubItems.Add(CDate(c.Pstop).ToString("HH:mm"))
                .SubItems.Add(c.Ptitle)
                .SubItems.Add(c.PcategoryTv)
                .Tag = c.Pdescription
            End With
            ' change la couleur de fond 1 item sur 2
            Math.DivRem(r, 2, reste)
            If (reste = 0) Then
                emissionItem.BackColor = Color.WhiteSmoke

            End If
            r += 1
        Next
    End Sub

    Private Sub LwEmissionSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles EmissionListView.SelectedIndexChanged

        ' sur le click d'un item de listview, on affiche la description et l'image
        If EmissionListView.SelectedItems.Count = 1 Then
            rtb_desc.Text = EmissionListView.SelectedItems(0).Tag.ToString
            pb_chaine.Image =
                Image.FromFile(
                    LogosPath & _listechannel(EmissionListView.SelectedItems(0).SubItems(1).Tag.ToString()).Logo)
        End If
    End Sub

    Private Sub Heure_changed(sender As Object, e As EventArgs) 'Handles dtp_Jour.ValueChanged
        AfficheHeure()
    End Sub

    Private Sub btImprimer_Click(sender As Object, e As EventArgs) Handles btImprimer.Click
        Dim imprim As New ImprimeEmissions("Visu par heure", list)
        imprim.VoirPrevisualisation()
    End Sub
End Class