' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2017 ZGuideTV.NET Team <https://github.com/neojudgment>                              |
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
Imports System.IO
Imports System.Globalization

' ReSharper disable CheckNamespace
Module Marquage
    ' ReSharper restore CheckNamespace

    Public Function GetLowesttDate() As DateTime

        Trace.WriteLine(DateTime.Now & " " & "entree dans Function GetLowesttDate() dans Marquage.vb")
        Dim marquedFile As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
        'Dim repereLigne As Integer = -1
        ' On regarde si le fichier ZGuideTVDotNet.marked.set existe
        If File.Exists(marquedFile) Then

            Dim streamEmissionMarquee As StreamReader = New StreamReader(marquedFile)

            Dim strligne As String = streamEmissionMarquee.ReadToEnd
            Trace.WriteLine(DateTime.Now & " " & "strligne : " & strligne)

            streamEmissionMarquee.Close()
            streamEmissionMarquee.Dispose()
            If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                Dim retour As IList(Of Long) = {}
                Dim ligne As String() = strligne.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                For Each s As String In ligne
                    Dim temp As DateTime = DateTime.Parse(s)
                    If temp > DateTime.Now Then
                        retour.Add(temp.ToBinary())
                    End If
                Next
                If retour.Count > 0 Then
                    Return New DateTime(retour.Min())
                End If
            End If
        End If
        Return DateTime.Now.AddDays(1)

    End Function

    Public Sub DecomposerEnregistrement(ByRef chtot As String, ByRef ch1 As String, ByRef ch2 As String,
                                          ByRef ch3 As String, ByRef ch4 As String)

        'structure d un enregistrement
        'chaine heure start § chaine chaine §§ chaine titre §§§ chaine heure stop
        ' ch1               §    ch2        §§    ch3       §§§       ch4
        ' la chaine total s appeleant chtot
        Trace.WriteLine(DateTime.Now & " " & "entree dans sub DecomposerEnregistrement dans Marquage.vb")
        Dim pos1, pos2, pos3 As Integer
        Dim lnChaine, lnTitre, lnStop As Integer
        pos1 = chtot.IndexOf("§", StringComparison.CurrentCulture)
        pos2 = chtot.IndexOf("§§", StringComparison.CurrentCulture)
        pos3 = chtot.IndexOf("§§§", StringComparison.CurrentCulture)
        lnChaine = pos2 - pos1 - 1
        lnTitre = pos3 - pos2 - 2
        lnStop = chtot.Length - pos3 - 3
        ch1 = chtot.Substring(0, pos1)
        ch2 = chtot.Substring(pos1 + 1, lnChaine)
        ch3 = chtot.Substring(pos2 + 2, lnTitre)
        ch4 = chtot.Substring(pos3 + 3, lnStop)

    End Sub

    Public Sub RecupererEmissionsMarquees()

        ' Lecture du fichier  et mettre a jour tableau_list_emissions et surtout les titres
        ' pour remettre , au demarrage, les 4 espaces
        ' avant et apres le titre des emissions marquees 
        ' si le fichier marked.set n existe pas : exit sub
        Trace.WriteLine(DateTime.Now & " " & "entree dans sub recuperer emissions marquées")
        Dim chaineAExaminer() As String = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "}
        Dim nomDuFichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"

        If Not (File.Exists(nomDuFichier)) Then
            Trace.WriteLine(DateTime.Now & " " & "Le fichier ZGuideTVDotNet.marked.set n'existe pas on le crée dans sub recupereremissionsmarquées")
            File.Create(nomDuFichier).Dispose()
            Exit Sub
        End If

        '250310 si le fichier n existe pas il n y a rien a recuperer
        ' le fichier existe
        Dim monStreamDocument As New StreamReader(nomDuFichier)
        Dim strligne, ch1, ss As String
        Dim indice As Integer = 0

        Try
            Trace.WriteLine(DateTime.Now & " " & "liste des emissions memorisees dans le fichier ZGuideTVDotNet.marked.set")
            Do While (monStreamDocument.Peek <> -1) ' tant qu il y a des records ds le fichier
                strligne = monStreamDocument.ReadLine

                If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                    chaineAExaminer(indice) = strligne
                    ' ch1 = partie date de la ligne d une emission extraite du fichier ZGuideTVDotNet.marked.set
                    ch1 = strligne.Substring(0, 19)
                    ' ("yyyy/MM/dd HH:mm:ss")
                    ' chaine = partie nom de chaine d une ligne d une emission marquee
                    Dim pos1 As Integer
                    pos1 = strligne.IndexOf("§§", StringComparison.CurrentCulture)
                    Dim lnChaine As Integer
                    lnChaine = pos1 - 19 - 1
                    Dim nomChaine As String
                    nomChaine = strligne.Substring(20, lnChaine)
                    ' en fait ce qu il y a apres les 19 caract de la date
                    Trace.WriteLine(DateTime.Now & " " & "heure = " & ch1, "  chaine = " & nomChaine)

                    For Each lecontrol As Control In Mainform.PanelA.Controls
                        If TypeOf (lecontrol) Is PaveCentral Then
                            Dim lecontrol2 As PaveCentral = DirectCast(lecontrol, PaveCentral)
                            ss = TableauListEmissions(lecontrol2.TabIndex).Pstart.ToString("yyyy/MM/dd HH:mm:ss")
                            If ([String].Equals(ss, ch1, StringComparison.CurrentCulture)) Then ' la date et heure de l emission correspond a la date de la ligne du fichier
                                Dim pos As Integer
                                Dim z1 As String = (TableauListEmissions(lecontrol2.TabIndex).ChannelId.ToString)
                                Dim z2 As String = nomChaine
                                pos = z1.IndexOf(z2, StringComparison.CurrentCulture)
                                If pos <> -1 Then
                                    'on remet 4 espaces devant et derriere le titre
                                    TableauListEmissions(lecontrol2.TabIndex).Ptitle = "    " &
                                                                                      TableauListEmissions(
                                                                                                              lecontrol2 _
                                                                                                                 .
                                                                                                                 TabIndex) _
                                                                                          .Ptitle & "    "
                                    lecontrol2.Marquage = True
                                    lecontrol2.Text = TableauListEmissions(lecontrol2.TabIndex).Ptitle
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
            sActuelleDecale As String =
                (DateTime.Now.AddHours(Mainform.DelaiAvertissement)).ToString("yyyy/MM/dd HH:mm:ss")

            Dim kk As Integer
            For kk = 0 To 12
                If Not [String].Equals(chaineAExaminer(kk), " ", StringComparison.CurrentCulture) Then
                    If [String].Equals(sActuelleDecale, chaineAExaminer(kk), StringComparison.CurrentCulture) Then

                        Try
                            If My.Settings.AudioOn Then
                                Mainform.JouerSon(My.Settings.ReminderSound, CInt(My.Settings.MessagesVolume / 10))
                            End If

                        Catch ex As Exception
                            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                        End Try

                        'lancer le timer heure
                        Mainform.Timer_heure.Start()
                    End If
                End If
            Next kk

            monStreamDocument.Close()
            monStreamDocument.Dispose()

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "Une erreur c'est produite dans sub recupereremissionsmarquées")
            Trace.WriteLine(DateTime.Now & " " & "Si le fichier ZGuideTVDotNet.marked.set existe on l'efface et on le recrée")

            If File.Exists(nomDuFichier) Then

                monStreamDocument.Close()
                monStreamDocument.Dispose()

                File.Delete(nomDuFichier)
                Trace.WriteLine(DateTime.Now & " " & "On vient d'effacer le fichier ZGuideTVDotNet.marked.set dans sub recupereremissionsmarquées")
                File.Create(nomDuFichier).Dispose()
                Trace.WriteLine(DateTime.Now & " " & "On vient de recréer le fichier ZGuideTVDotNet.marked.set dans sub recupereremissionsmarquées")
                Trace.WriteLine(DateTime.Now & " " & "sortie de sub recupereremissionsmarquées")
                Trace.WriteLine(" ")
                Exit Sub
            End If
        End Try

        Trace.WriteLine(DateTime.Now & " " & "sortie de sub recupereremissionsmarquées")
        Trace.WriteLine(" ")
    End Sub

    'Public Sub SupprimerFichierMarquage() ' sous certaines conditions
    '    '--------------------------------------------------------------------------------------
    '    ' il faut d abord eliminer les infos perimées en appelant la SR maj_fichier_marquage()
    '    ' si les infos sont perimees dans tableau_liste_emission(i)
    '    '-------------------------------------------------------------
    '    Trace.WriteLine(DateTime.Now & " " & "entree dans supprimer fichier marquage")
    '    Dim i As Integer
    '    'Dim fichierASupprimer As Boolean = True
    '    Mainform.Timer_minute.Enabled = False
    '    For i = 1 To NbEmissionsForSqlRequest - 1
    '        With TableauListEmissions(i)
    '            Dim l As Integer
    '            l = .Ptitle.Length
    '            'Trace.WriteLine("                   " & l.ToString)
    '            If l >= 4 Then
    '                Dim zz As String
    '                zz = .Ptitle.Substring(0, 4)
    '                'Trace.WriteLine(zz)
    '                'If [String].Equals(zz, "    ", StringComparison.CurrentCulture) Then
    '                '    fichierASupprimer = False
    '                '    Exit For
    '                'End If
    '            End If
    '        End With
    '    Next i
    '    'If ((fichierASupprimer = True) AndAlso (File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set"))) Then
    '    '    Try
    '    '        File.Delete(MarqueesPath & "ZGuideTVDotNet.marked.set")
    '    '        Trace.WriteLine(DateTime.Now & " " & "fichier marked.set supprimé")
    '    '    Catch ex As Exception
    '    '        Trace.WriteLine(DateTime.Now & " " & "dans supprimer fichier marquage , " & ex.Message)
    '    '    End Try
    '    '    Trace.WriteLine(DateTime.Now & " " & "le fichier émissions marquées a eté supprimé(obsolete")
    '    'End If
    '    Mainform.Timer_minute.Start()
    '    Mainform.Timer_minute.Enabled = True

    '    Trace.WriteLine(DateTime.Now & " " & " sortie de supprimer fichier marquage")

    'End Sub

    Public Sub AjouterLigneFichierMarquage(ByVal reper As Integer)

        'rvs75 20/10/2012 Simplification du code
        Trace.WriteLine(DateTime.Now & " " & "entree dans ajouter ligne fichier marquage")
        'Dim ligne, z1, z0S, z2, z3 As String
        Dim ligne As String

        'Dim z0 As Date
        Dim nomDuFichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
        Mainform.Timer_minute.Enabled = False
        Dim sw3 As New StreamWriter(nomDuFichier, True)

        With TableauListEmissions(reper)
            ligne = .Pstart.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture) & "§" & .ChannelId.ToString & "§§" &
            .Ptitle & "§§§" & .Pstop.ToString("yyyy/MM/dd HH:mm:ss") & Environment.NewLine
        End With

        ' on ajoute la ligne a la fin du fichier
        'z0 = TableauListEmissions(reper).Pstart
        'z0S = z0.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture)
        'z1 = TableauListEmissions(reper).ChannelId.ToString
        'z2 = TableauListEmissions(reper).Ptitle
        'z3 = TableauListEmissions(reper).Pstop.ToString("yyyy/MM/dd HH:mm:ss")
        'ligne = z0S & "§" & z1 & "§§" & z2 & "§§§" & z3 & vbCrLf
        sw3.WriteLine(ligne)
        sw3.Close()

        Trace.WriteLine(
                         DateTime.Now & " " & "on a écrit la ligne suivante dans la liste des émissions marquées" &
                         ligne)

        ' recuperer le fichier en entier pour l imprimer
        Dim monStreamDocument As New StreamReader(nomDuFichier)
        Dim strligne As String
        If Not (File.Exists(nomDuFichier)) Then
            Exit Sub
        End If
        Dim chGlob As String = ""
        Do While (monStreamDocument.Peek <> -1)
            ' tant qu il y a des records ds le fichier
            strligne = monStreamDocument.ReadLine
            chGlob &= strligne
        Loop
        Trace.WriteLine(
                         DateTime.Now & " " & "apres ajout de l émission marquée, le contenu du fichier total est :  " &
                         Environment.NewLine & chGlob)
        Mainform.Timer_minute.Start()
        'BB 220610
        Mainform.Timer_minute.Enabled = True
        sw3.Dispose()
        monStreamDocument.Close()
        monStreamDocument.Dispose()
        Trace.WriteLine(DateTime.Now & " " & "sortie de ajouter ligne fichier marquage")
    End Sub

    Public Sub MajFichierMarquage() ' si le fichier existe
        '----------------------------------------------------
        ' BUT : eliminer les emissions marquées perimées
        '----------------------------------------------------
        ' 1.lire ligne par ligne le fichier "ZGuideTVDotNe t.marked.set"
        ' et  eliminer les data perimees.
        ' On batit un nouveau contenu global du fichier dans un fichier bis temporaire
        ' 2.apres purge des éléments périmes du fichier bis ,on recopie
        ' le tout dans le fichier original emissions_marquees_zg
        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "entree dans maj fichier marquage ; suppression des marquages perimes")

        Dim z As Boolean
        Dim dateDuJour As DateTime
        Dim sDateDuJour, ch1, ch2 As String
        Dim strligne As String
        Dim nomDuFichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
        Dim monStreamDocument As New StreamReader(nomDuFichier)
        Dim chaineGlobale As String = ""
        Dim nomDuFichierDestination As String = MarqueesPath & "ZGuideTVDotNet.marked.bak"
        Dim sw2 As New StreamWriter(nomDuFichierDestination, False)

        Try

            dateDuJour = DateTime.Now

            ' on ne retient que les emissions marquées
            ' avec des dates superieure a date_du_jour;
            Trace.WriteLine(DateTime.Now & " " & "on ne retient que les emissions marquées avec des dates superieure a date_du_jour")
            If Not File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
                Trace.WriteLine(DateTime.Now & " " & "sortie de maj fichier marquage via Exit Sub")
                Trace.WriteLine(" ")
                Exit Sub
            End If

            sDateDuJour = dateDuJour.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture)

            ' on ecrase le fichier existant
            Trace.WriteLine(DateTime.Now & " " & "on ecrase le fichier existant")

            ch1 = sDateDuJour

            Do Until (monStreamDocument.Peek = -1)
                ' tant qu il y a des records ds le fichier
                strligne = monStreamDocument.ReadLine

                If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                    ch2 = strligne.Substring(0, 19)
                    ' date au format"YYYY/MM/dd hh:mm"...19 caracteres


                    Trace.WriteLine(DateTime.Now & " " & "ch1 <= ch2")
                    ' ReSharper disable SpecifyStringComparison
                    If ch1 <= ch2 Then  ' faut il conserver la ligne : date< date du jour
                        ' ReSharper restore SpecifyStringComparison

                        chaineGlobale &= strligne & Environment.NewLine
                    End If
                End If
            Loop

            ' chaine globale contient alors les emissions marquées non périmées
            Trace.WriteLine(
                         DateTime.Now & " " & "apres suppression eventuelle des lignes perimees, le fichier devient : " &
                         chaineGlobale & Environment.NewLine)
            sw2.WriteLine(chaineGlobale)
            ' ecriture dans le fichier .bak
            monStreamDocument.Close()
            ' fermeture fichier lu .bak
            sw2.Close()

            'nomDuFichier = MarqueesPath & "ZGuideTVDotNet.marked.set"

            'Trace.WriteLine(DateTime.Now & " " & "Suppression du fichier ZGuideTVDotNet.marked.set")
            'If File.Exists(nomDuFichier) Then
            '    File.Delete(nomDuFichier)
            'End If

            Application.DoEvents()
            Trace.WriteLine(DateTime.Now & " " & "application.DoEvents()")

            z = Miseajour.CopierFichier(nomDuFichierDestination, nomDuFichier, True)

            If z = False Then

                ' il y a eu erreur de copie de fichier
                Trace.WriteLine(DateTime.Now & " " & "erreur de copie de fichiers de memorisation d emissions marquees")
                ' 2eme essai
                Miseajour.CopierFichier(nomDuFichierDestination, nomDuFichier, True)
            End If

            sw2.Dispose()
            monStreamDocument.Dispose()

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "dans maj fichier marquage : " & ex.Message)
        End Try

        Trace.WriteLine(DateTime.Now & " " & "sortie de maj fichier marquage")
        Trace.WriteLine(" ")
    End Sub
End Module
