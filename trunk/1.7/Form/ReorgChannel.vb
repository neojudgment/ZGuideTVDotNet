' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2016 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

Imports ZGuideTV.SQLiteWrapper
Imports System.Text
Imports System.Globalization

' ReSharper disable CheckNamespace
Public Class ReorgChannel
    ' ReSharper restore CheckNamespace
    Dim _strNomChannel As String

#Region "Property"
    Public MessageBoxReorgChannel As String
    Public MessageBoxReorgChannel1 As String
    Public MessageBoxReorgChannelTitre As String
#End Region

    Private Sub ReorgChannelLoad(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        ' Néo On regarde quel langue utilisée 30/05/2010
        LanguageCheck()

        Dim reste As Integer
        Dim strSql As String
        strSql = _
            "SELECT Name, Ordering, ID,logo FROM channeltbl order by ordering "
        Dim db As SqLiteBase = New SqLiteBase
        Dim dtChaines As DataTable
        db.OpenDatabase(BddPath & "db_progs.db3")
        dtChaines = db.ExecuteQuery(strSql)
        db.CloseDatabase()

        lstChaine.Items.Clear()

        For r As Integer = 0 To dtChaines.Rows.Count - 1
            Dim chaineItem As New ListViewItem(dtChaines.Rows(r).Item(0).ToString)

            With chaineItem
                .SubItems.Add(dtChaines.Rows(r).Item(1).ToString)
                .SubItems.Add(dtChaines.Rows(r).Item(2).ToString())
                .SubItems.Add(dtChaines.Rows(r).Item(3).ToString())
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

    Private Sub BtAnnulerClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAnnuler.Click
        Close()
        Dispose()
    End Sub

    Private Sub BtMonterClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btMonter.Click

        If lstChaine.SelectedIndices.Count = 1 AndAlso lstChaine.SelectedIndices.Item(0) > 0 Then
            Dim selIndex As Integer = lstChaine.SelectedIndices.Item(0)
            Dim tItem As ListViewItem

            With lstChaine
                tItem = .Items(selIndex - 1)
                .Items(selIndex - 1) = CType(.Items(selIndex).Clone, ListViewItem)
                .Items(selIndex - 1).SubItems(1).Text = selIndex.ToString
                .Items(selIndex) = CType(tItem.Clone, ListViewItem)
                .Items(selIndex).SubItems(1).Text = (selIndex + 1).ToString
                FaireBgListview()
                .Items(selIndex - 1).Selected = True
                .Select()
            End With
        End If
    End Sub

    Private Sub BtDescendreClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDescendre.Click

        With lstChaine
            If .SelectedIndices.Count = 1 AndAlso .SelectedIndices.Item(0) < .Items.Count - 1 Then
                Dim selIndex As Integer = lstChaine.SelectedIndices.Item(0) + 1
                Dim tItem As ListViewItem
                tItem = .Items(selIndex - 1)
                .Items(selIndex - 1) = CType(.Items(selIndex).Clone, ListViewItem)
                .Items(selIndex - 1).SubItems(1).Text = selIndex.ToString
                .Items(selIndex) = CType(tItem.Clone, ListViewItem)
                .Items(selIndex).SubItems(1).Text = (selIndex + 1).ToString
                FaireBgListview()
                .Items(selIndex).Selected = True
                .Select()
            End If
        End With
    End Sub

    Private Sub BtSupprimerClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSupprimer.Click

        With lstChaine
            If .SelectedIndices.Count = 1 Then
                .Items.RemoveAt(.SelectedIndices.Item(0))
                For i As Integer = 0 To .Items.Count - 1
                    .Items(i).SubItems(1).Text = (i + 1).ToString
                Next
                FaireBgListview()
            End If
        End With
    End Sub

    Private Sub BtEnregistrerClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btEnregistrer.Click

        Dim strSql As String
        Dim strId As String
        Dim strOrdering As String
        Dim strNotIn As StringBuilder = New StringBuilder
        strNotIn.Append(" (")
        Dim db As SqLiteBase = New SqLiteBase
        db.OpenDatabase(BddPath & "db_progs.db3")
        db.ExecuteNonQueryFast("begin transaction;")
        For Each lstitem As ListViewItem In lstChaine.Items
            strOrdering = lstitem.SubItems(1).Text
            strId = lstitem.SubItems(2).Text
            'strId = lstitem.Tag.ToString
            strNotIn.Append("'" & strId & "', ")
            strSql = "UPDATE ChannelTbl SET Ordering=" & strOrdering & " WHERE ID ='" & strId & "';"
            db.ExecuteNonQueryFast(strSql)

            If Not (Not lstitem.Tag.ToString Is Nothing AndAlso String.IsNullOrEmpty(lstitem.Tag.ToString)) Then
                'Dim Nom_chaine_des_logos As String()
                Dim repertoireTemp As String = Environment.GetEnvironmentVariable("TEMP") & "\"
                Dim newLogoFileName As String
                'Dim OldLogoFileName As String
                Dim strExtFichier As String
                Dim strNom As String
                newLogoFileName = lstitem.Tag.ToString.Substring((lstitem.Tag.ToString.LastIndexOf("\", StringComparison.CurrentCulture) + 1))
                strExtFichier = lstitem.Tag.ToString.Substring((lstitem.Tag.ToString.LastIndexOf(".", StringComparison.CurrentCulture)))
                strNom = lstitem.SubItems(0).Text
                'OldLogoFileName = lstitem.SubItems(3).Text

                'supprime le fichier s'il existe dans le repertoire temp
                If My.Computer.FileSystem.FileExists(repertoireTemp & newLogoFileName) Then
                    My.Computer.FileSystem.DeleteFile(repertoireTemp & newLogoFileName)
                End If

                'copie le" fichier sélectionné dans le repertoire temp
                My.Computer.FileSystem.CopyFile(lstitem.Tag.ToString, repertoireTemp & newLogoFileName)

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
                    My.Computer.FileSystem.CopyFile(repertoireTemp & newLogoFileName, _
                                                     LogosPath & strNom & "_new" & cpt.ToString(CultureInfo.CurrentCulture) & strExtFichier)
                Catch ex As Exception
                    Trace.WriteLine("le fichier de logo n'a pu être copié  dans le répertoires des logos")
                    Exit Sub
                End Try
                'supprime le fichier du repertoire temp
                My.Computer.FileSystem.DeleteFile(repertoireTemp & newLogoFileName)
                strSql = "UPDATE ChannelTbl SET logo='" & strNom & "_new" & cpt.ToString(CultureInfo.CurrentCulture) & strExtFichier & "' WHERE ID ='" & strId & "';"
                db.ExecuteNonQueryFast(strSql)


            End If
        Next lstitem
        strNotIn.Remove(strNotIn.Length - 2, 1).Append(")")

        strSql = "DELETE FROM ChannelTbl WHERE ID NOT IN" & strNotIn.ToString
        db.ExecuteNonQueryFast(strSql)
        strSql = "DELETE FROM ProgramTbl WHERE ChannelID NOT IN" & strNotIn.ToString
        db.ExecuteNonQueryFast(strSql)
        db.ExecuteNonQueryFast("end transaction;")

        db.CloseDatabase()

        ' Néo 21/10/2010
        Try
            If My.Settings.AudioOn Then
                'Dim wave As New WaveOut
                'Dim xa() As Byte = File.ReadAllBytes(MediaPath & My.Settings.MessagesSound)
                'Dim data As New MemoryStream(xa)
                'wave.Init(New BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(New WaveFileReader(data))))
                'wave.Volume = CInt(My.Settings.MessagesVolume / 10)
                'data.Close()
                'data.Dispose()
                Mainform.JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
            End If
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try

        Dim boxReorgChannel As DialogResult
        boxReorgChannel = MessageBox.Show _
            (MessageBoxReorgChannel & Chr(13) & MessageBoxReorgChannel1, _
             MessageBoxReorgChannelTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
             MessageBoxDefaultButton.Button1)

        If boxReorgChannel = DialogResult.Yes Then
            Trace.WriteLine(DateTime.Now & " " & "entree dans maj_grille_tv")

            Mainform.Close()
            Dispose()
            Close()
            Application.DoEvents()
            Application.Restart()

        Else
            Close()
        End If
    End Sub

    Private Sub LstChaineSelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles lstChaine.SelectedIndexChanged

        If lstChaine.SelectedIndices.Count = 1 Then
            If (Not lstChaine.Items(lstChaine.SelectedIndices(0)).Tag.ToString Is Nothing AndAlso String.IsNullOrEmpty(lstChaine.Items(lstChaine.SelectedIndices(0)).Tag.ToString)) Then
                pbLogo.Image = Image.FromFile(LogosPath & lstChaine.Items(lstChaine.SelectedIndices(0)).SubItems(3).Text)
            Else
                pbLogo.Image = Image.FromFile(lstChaine.Items(lstChaine.SelectedIndices(0)).Tag.ToString)
            End If

            _strNomChannel = lstChaine.Items(lstChaine.SelectedIndices(0)).SubItems(0).Text
            btLogo.Enabled = True
        Else
            pbLogo.Image = Nothing
            btLogo.Enabled = False
        End If
    End Sub

    Private Sub BtLogoClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btLogo.Click

        OpenFileDialog1.FileName = _strNomChannel
        OpenFileDialog1.InitialDirectory = LogosPath
        OpenFileDialog1.Filter = "Image Files(*.JPEG;*.JPG;*.GIF)|*.JPEG;*.JPG;*.GIF"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            lstChaine.SelectedItems(0).Tag = OpenFileDialog1.FileName
            pbLogo.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
        OpenFileDialog1.Dispose()

    End Sub

    Private Sub FaireBgListview()
        For r As Integer = 0 To lstChaine.Items.Count - 1
            Dim reste As Integer
            Math.DivRem(r, 2, reste)
            If (reste = 0) Then lstChaine.Items(r).BackColor = Color.WhiteSmoke Else lstChaine.Items(r).BackColor = Color.White
        Next
    End Sub
End Class