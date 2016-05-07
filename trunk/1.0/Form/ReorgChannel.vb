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
Imports System.Text
Imports System.Globalization
Imports Microsoft.DirectX
Imports Microsoft.DirectX.AudioVideoPlayback

Public Class ReorgChannel
    Dim strNomChannel As String

#Region "Property"
    Private _messageBoxReorgChannel As String

    Public Property MessageBoxReorgChannel As String
        Get
            Return _messageBoxReorgChannel
        End Get
        Set(ByVal Value As String)
            _messageBoxReorgChannel = Value
        End Set
    End Property

    Private _messageBoxReorgChannel1 As String

    Public Property MessageBoxReorgChannel1 As String
        Get
            Return _messageBoxReorgChannel1
        End Get
        Set(ByVal Value As String)
            _messageBoxReorgChannel1 = Value
        End Set
    End Property

    Private _messageBoxReorgChannelTitre As String

    Public Property MessageBoxReorgChannelTitre As String
        Get
            Return _messageBoxReorgChannelTitre
        End Get
        Set(ByVal Value As String)
            _messageBoxReorgChannelTitre = Value
        End Set
    End Property
#End Region

    Private Sub ReorgChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Néo On regarde quel langue utilisée 30/05/2010
        LanguageCheck()

        Dim reste As Integer
        Dim strSql As String
        strSql = _
            "SELECT Name, Ordering, ID,logo FROM channeltbl order by ordering "
        Dim db As SQLiteBase = New SQLiteBase
        Dim dt_Chaines As DataTable
        db.OpenDatabase(BDDPath & "db_progs.db3")
        dt_Chaines = db.ExecuteQuery(strSql)
        db.CloseDatabase()
        db = Nothing

        lstChaine.Items.Clear()

        For r As Integer = 0 To dt_Chaines.Rows.Count - 1
            Dim chaineItem As New ListViewItem(dt_Chaines.Rows(r).Item(0).ToString)

            With chaineItem
                .SubItems.Add(dt_Chaines.Rows(r).Item(1).ToString)
                .SubItems.Add(dt_Chaines.Rows(r).Item(2).ToString())
                .SubItems.Add(dt_Chaines.Rows(r).Item(3).ToString())
                .Tag = ""
            End With

            Math.DivRem(r, 2, reste)
            If (reste = 0) Then
                chaineItem.BackColor = Color.WhiteSmoke
            End If

            lstChaine.Items.Add(chaineItem)

        Next
        If lstChaine.Items.Count > 0 Then
            lstChaine.Items(0).Selected = True
        End If

    End Sub

    Private Sub btAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnnuler.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btMonter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMonter.Click

        If lstChaine.SelectedIndices.Count = 1 AndAlso lstChaine.SelectedIndices.Item(0) > 0 Then
            Dim SelIndex As Integer = Me.lstChaine.SelectedIndices.Item(0)
            Dim tItem As ListViewItem

            With lstChaine
                tItem = .Items(SelIndex - 1)
                .Items(SelIndex - 1) = CType(.Items(SelIndex).Clone, ListViewItem)
                .Items(SelIndex - 1).SubItems(1).Text = SelIndex.ToString
                .Items(SelIndex) = CType(tItem.Clone, ListViewItem)
                .Items(SelIndex).SubItems(1).Text = (SelIndex + 1).ToString
                faireBGListview()
                .Items(SelIndex - 1).Selected = True
                .Select()
            End With
        End If
    End Sub

    Private Sub btDescendre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDescendre.Click

        With lstChaine
            If .SelectedIndices.Count = 1 AndAlso .SelectedIndices.Item(0) < .Items.Count - 1 Then
                Dim SelIndex As Integer = Me.lstChaine.SelectedIndices.Item(0) + 1
                Dim tItem As ListViewItem
                tItem = .Items(SelIndex - 1)
                .Items(SelIndex - 1) = CType(.Items(SelIndex).Clone, ListViewItem)
                .Items(SelIndex - 1).SubItems(1).Text = SelIndex.ToString
                .Items(SelIndex) = CType(tItem.Clone, ListViewItem)
                .Items(SelIndex).SubItems(1).Text = (SelIndex + 1).ToString
                faireBGListview()
                .Items(SelIndex).Selected = True
                .Select()
            End If
        End With
    End Sub

    Private Sub btSupprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSupprimer.Click

        With lstChaine
            If .SelectedIndices.Count = 1 Then
                .Items.RemoveAt(.SelectedIndices.Item(0))
                For i As Integer = 0 To .Items.Count - 1
                    .Items(i).SubItems(1).Text = (i + 1).ToString
                Next
                faireBGListview()
            End If
        End With
    End Sub

    Private Sub btEnregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEnregistrer.Click
        Dim strSql As String = ""
        Dim strId As String = ""
        Dim strOrdering As String = ""
        Dim strNotIN As StringBuilder = New StringBuilder
        strNotIN.Append(" (")
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        db.ExecuteNonQueryFast("begin transaction;")
        For Each lstitem As ListViewItem In lstChaine.Items
            strOrdering = lstitem.SubItems(1).Text
            strId = lstitem.SubItems(2).Text
            'strId = lstitem.Tag.ToString
            strNotIN.Append("'" & strId & "', ")
            strSql = "UPDATE ChannelTbl SET Ordering=" & strOrdering & " WHERE ID ='" & strId & "';"
            db.ExecuteNonQueryFast(strSql)

            If Not (Not lstitem.Tag.ToString Is Nothing AndAlso String.IsNullOrEmpty(lstitem.Tag.ToString)) Then
                'Dim Nom_chaine_des_logos As String()
                Dim repertoire_temp As String = Environment.GetEnvironmentVariable("TEMP") & "\"
                Dim NewLogoFileName As String
                'Dim OldLogoFileName As String
                Dim strExtFichier As String
                Dim strNom As String
                NewLogoFileName = lstitem.Tag.ToString.Substring((lstitem.Tag.ToString.LastIndexOf("\", StringComparison.CurrentCulture) + 1))
                strExtFichier = lstitem.Tag.ToString.Substring((lstitem.Tag.ToString.LastIndexOf(".", StringComparison.CurrentCulture)))
                strNom = lstitem.SubItems(0).Text
                'OldLogoFileName = lstitem.SubItems(3).Text

                'supprime le fichier s'il existe dans le repertoire temp
                If My.Computer.FileSystem.FileExists(repertoire_temp & NewLogoFileName) Then
                    My.Computer.FileSystem.DeleteFile(repertoire_temp & NewLogoFileName)
                End If

                'copie le" fichier sélectionné dans le repertoire temp
                My.Computer.FileSystem.CopyFile(lstitem.Tag.ToString, repertoire_temp & NewLogoFileName)

                'recherche des fichiers "new" deja existant
                Dim cpt As Integer = 0
                Do
                    If My.Computer.FileSystem.FileExists(LogosPath & strNom & "_new" & cpt.ToString(CultureInfo.CurrentCulture) & strExtFichier) _
                        Then
                        cpt += 1
                    Else
                        Exit Do
                    End If
                Loop
                'copie du fichier du repertoire temp vers le repertoire des logos de zg avec renommage
                Try
                    My.Computer.FileSystem.CopyFile(repertoire_temp & NewLogoFileName, _
                                                     LogosPath & strNom & "_new" & cpt.ToString(CultureInfo.CurrentCulture) & strExtFichier)
                Catch ex As Exception
                    Trace.WriteLine("le fichier de logo n'a pu être copié  dans le répertoires des logos")
                    Exit Sub
                End Try
                'supprime le fichier du repertoire temp
                My.Computer.FileSystem.DeleteFile(repertoire_temp & NewLogoFileName)
                strSql = "UPDATE ChannelTbl SET logo='" & strNom & "_new" & cpt.ToString(CultureInfo.CurrentCulture) & strExtFichier & "' WHERE ID ='" & strId & "';"
                db.ExecuteNonQueryFast(strSql)


            End If
        Next lstitem
        strNotIN.Remove(strNotIN.Length - 2, 1).Append(")")

        strSql = "DELETE FROM ChannelTbl WHERE ID NOT IN" & strNotIN.ToString
        db.ExecuteNonQueryFast(strSql)
        strSql = "DELETE FROM ProgramTbl WHERE ChannelID NOT IN" & strNotIN.ToString
        db.ExecuteNonQueryFast(strSql)
        db.ExecuteNonQueryFast("end transaction;")

        db.CloseDatabase()
        db = Nothing

        ' Néo 21/10/2010
        Try
            If My.Settings.AudioOn Then
                ' le volume va de 0 (max) à -10000 (min)
                Dim AudioPlay As Audio
                AudioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                AudioPlay.Volume = My.Settings.MessagesVolume
                AudioPlay.Play()
            End If
        Catch ex As DirectXException
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try

        Dim BoxReorgChannel As DialogResult
        BoxReorgChannel = MessageBox.Show _
            (MessageBoxReorgChannel & Chr(13) & MessageBoxReorgChannel1, _
             MessageBoxReorgChannelTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
             MessageBoxDefaultButton.Button1)

        If BoxReorgChannel = System.Windows.Forms.DialogResult.Yes Then
            Trace.WriteLine(DateTime.Now & " " & "entree dans maj_grille_tv")

            Mainform.Close()
            Me.Dispose()
            Me.Close()
            Application.DoEvents()
            Application.Restart()

        Else
            Me.Close()
        End If
    End Sub

    Private Sub lstChaine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChaine.SelectedIndexChanged
        If lstChaine.SelectedIndices.Count = 1 Then
            If (Not lstChaine.Items(lstChaine.SelectedIndices(0)).Tag.ToString Is Nothing AndAlso String.IsNullOrEmpty(lstChaine.Items(lstChaine.SelectedIndices(0)).Tag.ToString)) Then
                pbLogo.Image = Image.FromFile(LogosPath & lstChaine.Items(lstChaine.SelectedIndices(0)).SubItems(3).Text)
            Else
                pbLogo.Image = Image.FromFile(lstChaine.Items(lstChaine.SelectedIndices(0)).Tag.ToString)
            End If

            strNomChannel = lstChaine.Items(lstChaine.SelectedIndices(0)).SubItems(0).Text
            btLogo.Enabled = True
        Else
            pbLogo.Image = Nothing
            btLogo.Enabled = False
        End If
    End Sub

    Private Sub btLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLogo.Click
        OpenFileDialog1.FileName = strNomChannel
        OpenFileDialog1.InitialDirectory = LogosPath
        OpenFileDialog1.Filter = "Image Files(*.JPEG;*.JPG;*.GIF)|*.JPEG;*.JPG;*.GIF"

        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            lstChaine.SelectedItems(0).Tag = OpenFileDialog1.FileName
            pbLogo.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
        OpenFileDialog1.Dispose()

    End Sub

    Sub faireBGListview()
        For r As Integer = 0 To lstChaine.Items.Count - 1
            Dim reste As Integer
            Math.DivRem(r, 2, reste)
            If (reste = 0) Then lstChaine.Items(r).BackColor = Color.WhiteSmoke Else lstChaine.Items(r).BackColor = Color.White
        Next
    End Sub
End Class