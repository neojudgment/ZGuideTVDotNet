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
Imports System.IO
Imports System.Globalization
Imports Microsoft.DirectX
Imports Microsoft.DirectX.AudioVideoPlayback

Module Marquage
    Public Sub decomposer_enregistrement(ByRef chtot As String, ByRef ch1 As String, ByRef ch2 As String, _
                                          ByRef ch3 As String, ByRef ch4 As String)
        'structure d un enregistrement

        'chaine heure start § chaine chaine §§ chaine titre §§§ chaine heure stop
        ' ch1               §    ch2        §§    ch3       §§§       ch4
        ' la chaine total s appeleant chtot

        Dim pos1, pos2, pos3 As Integer
        Dim ln_chaine, ln_titre, ln_stop As Integer
        pos1 = chtot.IndexOf("§", StringComparison.CurrentCulture)
        pos2 = chtot.IndexOf("§§", StringComparison.CurrentCulture)
        pos3 = chtot.IndexOf("§§§", StringComparison.CurrentCulture)
        ln_chaine = pos2 - pos1 - 1
        ln_titre = pos3 - pos2 - 2
        ln_stop = chtot.Length - pos3 - 3
        ch1 = chtot.Substring(0, pos1)
        ch2 = chtot.Substring(pos1 + 1, ln_chaine)
        ch3 = chtot.Substring(pos2 + 2, ln_titre)
        ch4 = chtot.Substring(pos3 + 3, ln_stop)

    End Sub

    Public Sub recuperer_emissions_marquees()
        ' Lecture du fichier  et mettre a jour tableau_list_emissions et surtout les titres
        ' pour remettre , au demarrage, les 4 espaces
        ' avant et apres le titre des emissions marquees 
        ' si le fichier marked.set n existe pas : exit sub
        Trace.WriteLine(DateTime.Now & " " & "entree dans sub recuperer emissions marquées")
        Dim chaine_a_examiner() As String = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "}
        'BB110810
        Dim nom_du_fichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
        If Not (File.Exists(nom_du_fichier)) Then
            Exit Sub
        End If
        '250310 si le fichier n existe pas il n y a rien a recuperer
        ' le fichier existe
        mon_stream_document = New StreamReader(nom_du_fichier)
        Dim strligne, ch1, ss As String
        Dim s_now As New DateTime
        s_now = DateTime.Now
        Dim indice As Integer = 0
        Trace.WriteLine(DateTime.Now & " " & "liste des emissions memorisees dans le fichier ZGuideTVDotNet.marked.set")
        Do While (mon_stream_document.Peek <> -1) ' tant qu il y a des records ds le fichier
            strligne = mon_stream_document.ReadLine
            If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                chaine_a_examiner(indice) = strligne
                ' ch1 = partie date de la ligne d une emission extraite du fichier ZGuideTVDotNet.marked.set
                ch1 = strligne.Substring(0, 19)
                ' ("yyyy/MM/dd HH:mm:ss")
                ' chaine = partie nom de chaine d une ligne d une emission marquee
                Dim pos1 As Integer
                pos1 = strligne.IndexOf("§§", StringComparison.CurrentCulture)
                Dim ln_chaine As Integer
                ln_chaine = pos1 - 19 - 1
                Dim nom_chaine As String
                nom_chaine = strligne.Substring(20, ln_chaine)
                ' en fait ce qu il y a apres les 19 caract de la date
                Trace.WriteLine(DateTime.Now & " " & "heure = " & ch1, "  chaine = " & nom_chaine)

                For Each lecontrol As Control In Mainform.PanelA.Controls
                    If TypeOf (lecontrol) Is PaveCentral Then
                        Dim lecontrol2 As PaveCentral = DirectCast(lecontrol, PaveCentral)
                        Dim titre1 As String = tableau_list_emissions(lecontrol2.TabIndex).Ptitle
                        ss = tableau_list_emissions(lecontrol2.TabIndex).pstart.ToString("yyyy/MM/dd HH:mm:ss")
                        If (ss = ch1) Then ' la date et heure de l emission correspond a la date de la ligne du fichier
                            Dim pos As Integer
                            Dim z1 As String = (tableau_list_emissions(lecontrol2.TabIndex).ChannelID.ToString)
                            Dim z2 As String = nom_chaine
                            pos = z1.IndexOf(z2, StringComparison.CurrentCulture)
                            If pos <> -1 Then
                                'on remet 4 espaces devant et derriere le titre
                                tableau_list_emissions(lecontrol2.TabIndex).Ptitle = "    " & _
                                                                                      tableau_list_emissions( _
                                                                                                              lecontrol2 _
                                                                                                                 . _
                                                                                                                 TabIndex) _
                                                                                          .Ptitle & "    "
                                lecontrol2.Marquage = True
                                lecontrol2.Text = tableau_list_emissions(lecontrol2.TabIndex).Ptitle
                                Exit For
                                'BB 260310
                            End If
                        End If
                    End If
                Next
            End If
            ' bouclage pour tous les lignes du fichier ZGuideTVDotNet.marked.set
            indice += 1
        Loop

        'Faut il faire un rappel sonore pour une emission marquée? BB110810
        ' On le fait si on est dans la tranche de 2 heures qui precedent l emission
        Dim _
            s_actuelle_decale As String = _
                (DateTime.Now.AddHours(Mainform.DelaiAvertissement)).ToString("yyyy/MM/dd HH:mm:ss")

        Dim kk As Integer
        For kk = 0 To 12
            If chaine_a_examiner(kk) <> " " Then
                If s_actuelle_decale > chaine_a_examiner(kk) Then

                    Try
                        If My.Settings.AudioOn Then
                            ' le volume va de 0 (max) à -10000 (min)
                            Dim AudioPlay As Audio
                            AudioPlay = New Audio(MediaPath & My.Settings.ReminderSound, True)
                            AudioPlay.Volume = My.Settings.ReminderVolume
                            AudioPlay.Play()
                        End If

                    Catch ex As DirectXException
                        Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    End Try

                    'lancer le timer heure
                    Mainform.Timer_heure.Start()
                End If
            End If
        Next kk

        mon_stream_document.Close()
        mon_stream_document = Nothing
        strligne = Nothing
        ss = Nothing
        ch1 = Nothing
        s_now = Nothing
        nom_du_fichier = Nothing
        Trace.WriteLine(DateTime.Now & " " & "sortie de sub recuperer emissions marquées")
        Trace.WriteLine(" ")

    End Sub

    Public Sub supprimer_fichier_marquage() ' sous certaines conditions
        '--------------------------------------------------------------------------------------
        ' il faut d abord eliminer les infos perimées en appelant la SR maj_fichier_marquage()
        ' si les infos sont perimees dans tableau_liste_emission(i)
        '-------------------------------------------------------------
        Trace.WriteLine(DateTime.Now & " " & "entree dans supprimer fichier marquage")
        Dim i As Integer
        Dim fichier_a_supprimer As Boolean = True
        Mainform.Timer_minute.Enabled = False
        For i = 1 To nb_emissions_for_SQL_Request - 1
            With tableau_list_emissions(i)
                Dim l As Integer
                l = .Ptitle.Length
                'Trace.WriteLine("                   " & l.ToString)
                If l >= 4 Then
                    Dim zz As String
                    zz = .Ptitle.Substring(0, 4)
                    'Trace.WriteLine(zz)
                    If zz = "    " Then
                        fichier_a_supprimer = False
                        Exit For
                    End If
                End If
            End With
        Next i
        If ((fichier_a_supprimer = True) AndAlso (File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set"))) Then
            Try
                File.Delete(MarqueesPath & "ZGuideTVDotNet.marked.set")
                Trace.WriteLine(DateTime.Now & " " & "fichier marked.set supprimé")
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & "dans supprimer fichier marquage , " & ex.Message)
            End Try
            Trace.WriteLine(DateTime.Now & " " & "le fichier émissions marquées a eté supprimé(obsolete")
        End If
        Mainform.Timer_minute.Start()
        Mainform.Timer_minute.Enabled = True

        Trace.WriteLine(DateTime.Now & " " & " sortie de supprimer fichier marquage")

    End Sub

    Public Sub ajouter_ligne_fichier_marquage(ByVal reper As Integer)
        Trace.WriteLine(DateTime.Now & " " & "entree dans ajouter ligne fichier marquage")
        Dim ligne, z1, z0s, z2, z3 As String
        Dim z0 As New Date
        Dim nom_du_fichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
        Mainform.Timer_minute.Enabled = False
        Dim sw3 As New StreamWriter(nom_du_fichier, True)

        ' on ajoute la ligne a la fin du fichier
        z0 = tableau_list_emissions(reper).pstart
        z0s = z0.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture)
        z1 = tableau_list_emissions(reper).ChannelID.ToString
        z2 = tableau_list_emissions(reper).Ptitle
        z3 = tableau_list_emissions(reper).pstop.ToString("yyyy/MM/dd HH:mm:ss")
        ligne = z0s & "§" & z1 & "§§" & z2 & "§§§" & z3 & vbCrLf
        sw3.WriteLine(ligne)
        sw3.Close()
        Trace.WriteLine( _
                         DateTime.Now & " " & "on a écrit la ligne suivante dans la liste des émissions marquées" & _
                         ligne)

        ' recuperer le fichier en entier pour l imprimer
        mon_stream_document = New StreamReader(nom_du_fichier)
        Dim strligne As String
        If Not (File.Exists(nom_du_fichier)) Then
            Exit Sub
        End If
        Dim ch_glob As String = ""
        Do While (mon_stream_document.Peek <> -1)
            ' tant qu il y a des records ds le fichier
            strligne = mon_stream_document.ReadLine
            ch_glob &= strligne
        Loop
        Trace.WriteLine( _
                         DateTime.Now & " " & "apres ajout de l émission marquée, le contenu du fichier total est :  " & _
                         vbCrLf & ch_glob)
        Mainform.Timer_minute.Start()
        'BB 220610
        Mainform.Timer_minute.Enabled = True
        sw3.Dispose()
        z0 = Nothing
        z1 = Nothing
        z0s = Nothing
        ligne = Nothing
        mon_stream_document.Close()
        Trace.WriteLine(DateTime.Now & " " & "sortie de ajouter ligne fichier marquage")
    End Sub

    Public Sub maj_fichier_marquage() ' si le fichier existe
        '----------------------------------------------------
        ' BUT : eliminer les emissions marquées perimées
        '----------------------------------------------------
        ' 1.lire ligne par ligne le fichier "ZGuideTVDotNe t.marked.set"
        ' et  eliminer les data perimees.
        ' On batit un nouveau contenu global du fichier dans un fichier bis temporaire
        ' 2.apres purge des éléments périmes du fichier bis ,on recopie
        ' le tout dans le fichier original emissions_marquees_zg
        Trace.WriteLine(DateTime.Now & " " & "entree dans maj fichier marquage ; suppression des marquages perimes")
        Dim date_du_jour As New DateTime
        Dim s_date_du_jour, ch1, ch2 As String
        date_du_jour = DateTime.Now

        ' on ne retient que les emissions marquées
        ' avec des dates superieure a date_du_jour;
        If Not File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
            Exit Sub
        End If

        s_date_du_jour = date_du_jour.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture)
        Dim strligne As String
        Dim nom_du_fichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
        Dim sr As New StreamReader(nom_du_fichier)
        mon_stream_document = New StreamReader(nom_du_fichier)
        Dim chaine_globale As String = ""
        Dim nom_du_fichier_destination As String = MarqueesPath & "ZGuideTVDotNet.marked.bak"
        Dim sw2 As New StreamWriter(nom_du_fichier_destination, False)
        ' on ecrase le fichier existant

        ' Partie 1
        ch1 = s_date_du_jour
        Do Until (mon_stream_document.Peek = -1)
            ' tant qu il y a des records ds le fichier
            strligne = mon_stream_document.ReadLine
            If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                ch2 = strligne.Substring(0, 19)
                ' date au format"YYYY/MM/dd hh:mm"...19 caracteres
                If ch1 <= ch2 Then ' faut il conserver la ligne : date< date du jour
                    chaine_globale &= strligne & Environment.NewLine
                End If
            End If
        Loop

        ' chaine globale contient alors les emissions marquées non périmées
        Trace.WriteLine( _
                         DateTime.Now & " " & "apres suppression eventuelle des lignes perimees, le fichier devient : " & _
                         chaine_globale & vbCrLf)
        sw2.WriteLine(chaine_globale)
        ' ecriture dans le fichier .bak
        mon_stream_document.Close()
        ' fermeture fichier lu .bak
        sw2.Close()
        ' fermeture fichier temporaire ecrit
        sr.Close()

        ' recopier le fichier copie  dans le fichier original

        ' Syntaxe de la routine de copie'
        ' CopierFichier(ByVal FichierSource As String, ByVal FichierDest As String, _
        ' Optional ByVal bEcraser As Boolean = False) As Boolean

        nom_du_fichier = MarqueesPath & "ZGuideTVDotNet.marked.set"
        Dim z As Boolean
        If File.Exists(nom_du_fichier) Then
            File.Delete(nom_du_fichier)
        End If
        Application.DoEvents()
        Try
            z = Miseajour.CopierFichier(nom_du_fichier_destination, nom_du_fichier, True)
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "dans maj fichier marquage : " & ex.Message)
        End Try
        If z = False Then

            ' il y a eu erreur de copie de fichier
            Trace.WriteLine(DateTime.Now & " " & "erreur de copie de fichiers de memorisation d emissions marquees")
            ' 2eme essai
            Miseajour.CopierFichier(nom_du_fichier_destination, nom_du_fichier, True)
        End If
        sr = Nothing
        sw2.Dispose()
        mon_stream_document = Nothing
        date_du_jour = Nothing
        s_date_du_jour = Nothing
        strligne = Nothing
        Trace.WriteLine(DateTime.Now & " " & "sortie de maj fichier marquage ; suppression des marquages perimes")
    End Sub
End Module
