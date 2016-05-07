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
Imports System.IO
Imports System.Globalization

' ReSharper disable CheckNamespace
Public Class Pref
    ' ReSharper restore CheckNamespace

    Public FichierLogActivé As Boolean 'scope trop grand, a deplacer dans Pref

    Private Sub TailleBdd()
        Dim fichierInfo As New FileInfo(BddPath & "db_progs.db3")
        If My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") Then
            Dim tailleFichier As Integer = CInt(fichierInfo.Length)
            tailleFichier = CInt(tailleFichier / 1024)
            If tailleFichier < 4 Then
                Dispose()
                Miseajour.ShowDialog()
            End If
        End If
    End Sub


    Private Sub FrmPrefLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        TabControl.TabPages.Remove(TabPage1)

        ' On regarde quel langue utiliser 22/08/2008
        LanguageCheck()
        Trace.WriteLine(DateTime.Now & " On vient d'entrer dans les Préférences")
    End Sub

    Private Sub BtCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCancel.Click

        With My.Settings
            If .firststart Then
                .firststart = False
                .Save()
                Close()
            End If
        End With
        TailleBdd()
        Trace.WriteLine(DateTime.Now & " On vient de quitterles Préférences via le bouton Cancel")

        'Néo 18/08/2010
        With Mainform.Timer_minute
            .Start()
            .Enabled = True
        End With

        Close()
    End Sub

    Private Sub BtOkClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOK.Click


        ' On va écrire les sons wav sélectionnés
        My.Settings.RSSSound = ComboBoxRSS.Text
        My.Settings.MessagesSound = ComboBoxMessages.Text
        My.Settings.ReminderSound = ComboBoxReminder.Text

        ' On va écrire le volume du flux RSS
        My.Settings.RSSVolume = TrackBarRSS.Value

        ' On va écrire le volume des messages
        My.Settings.MessagesVolume = TrackBarMessages.Value

        ' On va écrire le volume des rappels
        My.Settings.ReminderVolume = TrackBarReminder.Value

        With My.Settings
            If .firststart Then
                .firststart = False
                .Save()
                Close()
            End If
        End With

        ' dans frmpref on a cliqué sur OK pour accepter le choix des preferences
        Trace.WriteLine(DateTime.Now.ToString & "  passage dans bouton ok de frmpref")

        TailleBdd()

        ' port du proxy
        My.Settings.tracelog = FichierLogActivé

        ' on va écrire si l'option 'FadeOut' est activée ou non
        With My.Settings
            If CheckBoxFadeOut.Checked Then
                .FadeOut = 1
            Else
                .FadeOut = 0
            End If
        End With

        ' on va écrire si l'option 'InfoBulles' est activée ou non
        With My.Settings
            If CheckBoxToolTipsBallon.Checked Then
                .ToolTipsBallon = True
            Else
                .ToolTipsBallon = False
            End If
        End With

        ' on va écrire si l'option 'les dimensions et la position
        ' de la fenêtre principale() ' auto est activée ou non
        With CheckBoxConfigWindow
            If .Checked Then
                My.Settings.WindowState = 1
            Else
                My.Settings.WindowState = 0
            End If
        End With

        ' on va écrire si l'option 'sauvegarde de la position
        ' des buttons est activée ou non
        With CheckBoxbuttonssave
            If .Checked Then
                My.Settings.buttonssave = 1
            Else
                My.Settings.buttonssave = 0
            End If
        End With

        ' on va écrire si l'option 'Cacher automatiquement
        ' les filtres est activée ou non
        'With CheckBoxFilters
        '    If .Checked Then
        '        My.Settings.Cacher_Filtre = True
        '    Else
        '        My.Settings.Cacher_Filtre = False
        '    End If
        'End With

        ' On va écrire la configuration matérielle dans le user.config
        With My.Settings
            If RadioButtonConfNormal.Checked Then
                .ConfHardware = 1
            End If

            If RadioButtonConfAverage.Checked Then
                .ConfHardware = 2
            End If

            If RadioButtonConfMinimum.Checked Then
                .ConfHardware = 3
            End If
        End With

        ' On va écrire si
        ' L utilisateur autorise le scroll horizontal quand in demande d afficher
        ' moins de chaines que son ecran ne le permet?
        ' Autorisation dans les frmpref (checkbox)
        With CheckBoxaccordscrollhorizontal
            If .Checked Then
                My.Settings.accordscrollhorizontal = True
                Trace.WriteLine(DateTime.Now & " " & "accord scroll horizontal = true")
            Else
                My.Settings.accordscrollhorizontal = False
                Trace.WriteLine(DateTime.Now & " " & "accord scroll horizontal = false")
            End If
        End With

        ' on va écrire si l'option 'UrlUpdate auto' auto est activée ou non
        With CheckBoxUrlUpdate
            If .Checked Then
                My.Settings.UrlUpdate = True
                Trace.WriteLine(DateTime.Now & " " & "UrlUpdate = true")
            Else
                My.Settings.UrlUpdate = False
                Trace.WriteLine(DateTime.Now & " " & "UrlUpdate = false")
            End If
        End With

        ' !!!!!!!!!!!!!!! à modifier (à mettre dans un module ???) Néo
        Trace.WriteLine(DateTime.Now.ToString & "  passage dans bouton ok de frmpref")
        Trace.WriteLine(DateTime.Now & " " & "nb_max chaine ecran = " & Mainform.NbMaxChaineEcran.ToString)
        Trace.WriteLine(
                         DateTime.Now & " " & "nb de chaines differentes selectionnées à la mise a jour =" &
                         NombreDeChainesDifferentes.ToString)
        If My.Settings.nbchainesdiff < Mainform.NbMaxChaineEcran AndAlso My.Settings.accordscrollhorizontal Then
            Mainform.ScrollHorizontal = True
            My.Settings.scrollhorizontal = Mainform.ScrollHorizontal
            Trace.WriteLine(DateTime.Now & " " & "scroll_horizontal à true")
        End If

        If Not My.Settings.nbchainesdiff < Mainform.NbMaxChaineEcran Then
            Mainform.ScrollHorizontal = False
            My.Settings.scrollhorizontal = Mainform.ScrollHorizontal
            Trace.WriteLine(DateTime.Now & " " & "scroll_horizontal à false")
        End If

        ' on va écrire si l'option mise à jour auto est activée ou non
        With My.Settings
            If CheckBoxAutoUpdate.Checked Then
                .AutoUpdate = 1
            Else
                .AutoUpdate = 0
            End If
        End With

        ' On va écrire si l'option reprise automatique est activée ou non
        With My.Settings
            If CheckBoxResume.Checked Then
                .ResumeChecked = 1
            Else
                .ResumeChecked = 0
            End If
        End With

        ' On va écrire le nombre de minute avant la reprise automatique
        With My.Settings
            If RadioButtonResume5.Checked Then
                .ResumeBefore = 5
            End If
            If RadioButtonResume10.Checked Then
                .ResumeBefore = 10
            End If
            If RadioButtonResume15.Checked Then
                .ResumeBefore = 15
            End If
            If RadioButtonResume20.Checked Then
                .ResumeBefore = 20
            End If
            If RadioButtonResume30.Checked Then
                .ResumeBefore = 30
            End If
        End With

        ' On va écrire si l'option vérification auto est activée ou non
        With My.Settings
            If CheckBoxAutoverif.Checked Then
                .Autoverif = 1
            Else
                .Autoverif = 0
            End If
        End With

        ' 03/05/2008 on va écrire si l option fichier_log_activé est activée
        With My.Settings
            If CheckBoxtracelog.Checked Then
                .tracelog = True
            Else
                .tracelog = False
            End If
        End With

        ' on va écrire si l'option purge auto est activée ou non
        With My.Settings
            If CheckBoxPurge.Checked Then
                .Purgefichiers = 1
            Else
                .Purgefichiers = 0

            End If
        End With

        ' On va écrire l'intervalle de mise à jour dans le user.config
        My.Settings.intervalmiseajour = CInt(NumericUpDownUpdate.Value)

        ' on va écrire si l'option Slide est activée ou non
        With CheckBoxSlide
            Select Case .Checked
                Case True
                    My.Settings.Slide = 1
                Case Else
                    My.Settings.Slide = 0
            End Select
        End With

        ' on va écrire si l'option Zone de notification est activée ou non
        With CheckBoxSystray
            Select Case .Checked
                Case True
                    My.Settings.Systray = True
                Case Else
                    My.Settings.Systray = False
            End Select
        End With

        ' On va écrire la durée minimum de l'affichage
        ' dans Ce soir dans le user.config
        Dim tempsminimumcesoir As SByte
        With My.Settings
            If RadioButtonCesoirAll.Checked Then
                tempsminimumcesoir = 0
            End If

            If RadioButtonCesoir45.Checked Then
                tempsminimumcesoir = 45
            End If

            If RadioButtonCesoir60.Checked Then
                tempsminimumcesoir = 60
            End If

            If RadioButtonCesoir75.Checked Then
                tempsminimumcesoir = 75
            End If

            If RadioButtonCesoir90.Checked Then
                tempsminimumcesoir = 90
            End If

            If RadioButtonCesoir105.Checked Then
                tempsminimumcesoir = 105
            End If

            If RadioButtonCesoir120.Checked Then
                tempsminimumcesoir = 120
            End If
        End With

        ' On va écrire la durée minimum de l'affichage
        ' dans Maintenant dans le user.config
        Dim tempsminimummaintenant As SByte
        With My.Settings
            If RadioButtonMaintenantAll.Checked Then
                tempsminimummaintenant = 5
            End If

            If RadioButtonMaintenant45.Checked Then
                tempsminimummaintenant = 45
            End If

            If RadioButtonMaintenant60.Checked Then
                tempsminimummaintenant = 60
            End If

            If RadioButtonMaintenant75.Checked Then
                tempsminimummaintenant = 75
            End If

            If RadioButtonMaintenant90.Checked Then
                tempsminimummaintenant = 90
            End If

            If RadioButtonMaintenant105.Checked Then
                tempsminimummaintenant = 105
            End If

            If RadioButtonMaintenant120.Checked Then
                tempsminimummaintenant = 120
            End If
        End With

        ' Si la durée de 'Ce soir' ou 'Maintenant' seule à été modifiée
        ' on redémarre ZG
        With My.Settings

            ' Si on vient de changer les durees pour ce_soir ou maintenant
            If tempsminimumcesoir <> .dureecesoir OrElse tempsminimummaintenant <> .dureemaintenant Then
                .dureecesoir = tempsminimumcesoir
                .dureemaintenant = tempsminimummaintenant
                .Save()


                Trace.WriteLine(DateTime.Now.ToString & " On va faire un restart dans les préférences")
                Mainform.Tl.Close()
                Application.DoEvents()
                Mainform.AppliRestart = True
            End If
        End With

        Application.DoEvents()
        Trace.WriteLine(DateTime.Now.ToString & " On va sortir des préférences via le button OK")
        Close()

        ' on y passe toujors qq soit le cas de figure meme pour un application.restart
        Dispose() ' BB 040810 peut on faire cela ?? on execute encore du code dans frmpref!
        If Mainform.AppliRestart = True Then
            Mainform.Timer_wait.Enabled = True
            My.Settings.ModifPrefRestart = 1

        Else
            'Néo 18/08/2010
            With Mainform.Timer_minute
                .Start()
                .Enabled = True
            End With
        End If
    End Sub

    Public Sub New()
        InitializeComponent()

        ' intervalle de mise à jour en jour(s)
        Dim intervalmaj As Integer

        ' différence de date entre la dernière mise à jour et maintenant
        Dim diffjourmaj As Long

        ' nombre de jours restant avant la prochaine mise à jour
        Dim jourrestantmaj As String

        ' date de la dernière mise à jour
        Dim datemaj As String
        Dim datesave As Date

        '' Slide activé dans central screen
        'Dim Slide As Integer

        '' purge des fichiers
        'Purge = My.Settings.Purgefichiers

        '' mise à jour auto
        'AutoUpdate = My.Settings.AutoUpdate

        '' affichage effet Slide
        'Slide = My.Settings.Slide

        '' vérification(auto)
        'Autoverif = My.Settings.Autoverif


        ' interval de mise à jour
        intervalmaj = My.Settings.intervalmiseajour
        'verifinterval = My.Settings.intervalverif

        ' date dernière mise à jour
        datemaj = My.Settings.datemajmiseajour

        If Not (Not datemaj Is Nothing AndAlso String.IsNullOrEmpty(datemaj)) Then
            ' On affiche la date de la dernière mise à jour dans les préférences
            datemaj = My.Settings.datemajmiseajour
            datesave = CDate(datemaj)
            TextBoxUpdateLast.Text = (datesave.ToLongDateString).ToString
        End If

        ' On va lire l'intervalle de mise à jour dans le user.config et on affiche dans les préférences
        NumericUpDownUpdate.Value = My.Settings.intervalmiseajour

        ' On va lire si la sauvegarde de la position des buttons est activée dans le user.config
        ' et on affiche dans les préférences
        With My.Settings
            If .buttonssave = 1 Then

                CheckBoxbuttonssave.Checked = True
            Else
                CheckBoxbuttonssave.Checked = False

            End If
        End With

        ' On va lire si les InfoBulles sont activées ou non
        ' et on affiche dans les préférences
        With My.Settings
            If .ToolTipsBallon = True Then

                CheckBoxToolTipsBallon.Checked = True
            Else
                CheckBoxToolTipsBallon.Checked = False

            End If
        End With

        ' On va lire le temps minimum d'affichage dans ce soir
        ' user.config et on affiche dans les préférences
        With My.Settings
            If .dureecesoir = 0 Then
                RadioButtonCesoirAll.Checked = True
            End If

            If .dureecesoir = 45 Then
                RadioButtonCesoir45.Checked = True
            End If

            If .dureecesoir = 60 Then
                RadioButtonCesoir60.Checked = True
            End If

            If .dureecesoir = 75 Then
                RadioButtonCesoir75.Checked = True
            End If

            If .dureecesoir = 90 Then
                RadioButtonCesoir90.Checked = True
            End If

            If .dureecesoir = 105 Then
                RadioButtonCesoir105.Checked = True
            End If

            If .dureecesoir = 120 Then
                RadioButtonCesoir120.Checked = True
            End If
        End With

        ' On va lire le temps minimum d'affichage dans maintenant
        ' user.config et on affiche dans les préférences
        With My.Settings
            If .dureemaintenant = 5 Then
                RadioButtonMaintenantAll.Checked = True
            End If

            If .dureemaintenant = 45 Then
                RadioButtonMaintenant45.Checked = True
            End If

            If .dureemaintenant = 60 Then
                RadioButtonMaintenant60.Checked = True
            End If

            If .dureemaintenant = 75 Then
                RadioButtonMaintenant75.Checked = True
            End If

            If .dureemaintenant = 90 Then
                RadioButtonMaintenant90.Checked = True
            End If

            If .dureemaintenant = 105 Then
                RadioButtonMaintenant105.Checked = True
            End If

            If .dureemaintenant = 120 Then
                RadioButtonMaintenant120.Checked = True
            End If
        End With

        ' On va lire si l'option effets Slide est cochée
        With CheckBoxSlide
            Select Case My.Settings.Slide
                Case 1
                    .Checked = True
                Case Else
                    .Checked = False
            End Select
        End With

        ' On va lire si l'option Zone de notification est cochée
        With CheckBoxSystray
            Select Case My.Settings.Systray
                Case True
                    .Checked = True
                Case Else
                    .Checked = False
            End Select
        End With

        ' On va lire si l'option 'Cacher automatiquement
        ' est cochée
        'Select Case My.Settings.Cacher_Filtre
        '    Case True
        '        CheckBoxFilters.Checked = True
        '    Case Else
        '        CheckBoxFilters.Checked = False
        'End Select

        ' On va lire la configuration matériel dans le user.config et on affiche dans les préférences
        With My.Settings
            If .ConfHardware = 1 Then ' pour afficher 36 heures
                RadioButtonConfNormal.Checked = True
            End If

            If .ConfHardware = 2 Then ' pour afficher 30 heures
                RadioButtonConfAverage.Checked = True
            End If

            If .ConfHardware = 3 Then ' pour afficher 24 heures
                RadioButtonConfMinimum.Checked = True
            End If
        End With

        ' On va lire si
        ' L utilisateur autorise le scroll horizontal quand in demande d afficher
        ' moins de chaines que son ecran ne le permet?
        ' Autorisation dans les frmpref (checkbox) et on grise la box si nbchainesdiff >
        If My.Settings.nbchainesdiff < Mainform.NbMaxChaineEcran Then
            GroupBoxMouse.Enabled = True
        Else
            GroupBoxMouse.Enabled = False
        End If

        With CheckBoxaccordscrollhorizontal
            Select Case My.Settings.accordscrollhorizontal
                Case True
                    .Checked = True
                    Trace.WriteLine(DateTime.Now & " " & "accord scroll horizontal = vrai")
                Case Else
                    .Checked = False
                    Trace.WriteLine(DateTime.Now & " " & "accord scroll horizontal = false")
            End Select
        End With

        ' On va lire si l'option UrlUpdate auto est cochée
        With CheckBoxUrlUpdate
            Select Case My.Settings.UrlUpdate
                Case True
                    .Checked = True
                    Trace.WriteLine(DateTime.Now & " " & "UrlUpdate = true")
                Case Else
                    .Checked = False
                    Trace.WriteLine(DateTime.Now & " " & "UrlUpdate = false")
            End Select
        End With

        ' On va lire si l'option mise à jour auto est cochée
        With CheckBoxAutoUpdate
            Select Case My.Settings.AutoUpdate
                Case 1
                    .Checked = True
                Case Else
                    .Checked = False
            End Select
        End With

        ' On va lire si l'option reprise automatique est cochée
        With CheckBoxResume
            Select Case My.Settings.ResumeChecked
                Case 1
                    .Checked = True
                    GroupBoxResumeBefore.Enabled = True
                Case Else
                    .Checked = False
                    GroupBoxResumeBefore.Enabled = False
            End Select
        End With

        ' On va lire le temps avant la reprise automatique
        With My.Settings
            Select Case .ResumeBefore
                Case 5
                    RadioButtonResume5.Checked = True
                Case 10
                    RadioButtonResume10.Checked = True
                Case 15
                    RadioButtonResume15.Checked = True
                Case 20
                    RadioButtonResume20.Checked = True
                Case 30
                    RadioButtonResume30.Checked = True
            End Select
        End With

        ' On va lire si l'option vérification auto est cochée
        With CheckBoxAutoverif
            Select Case My.Settings.Autoverif
                Case 1
                    .Checked = True
                Case Else
                    .Checked = False
            End Select
        End With

        ' On va lire si l'option purge auto est cochée
        With CheckBoxPurge
            Select Case My.Settings.Purgefichiers
                Case 1
                    .Checked = True
                Case Else
                    .Checked = False
            End Select
        End With

        ' On va lire si l'option FadeOut est cochée
        With CheckBoxFadeOut
            Select Case My.Settings.FadeOut
                Case 1
                    .Checked = True
                Case Else
                    .Checked = False
            End Select
        End With

        ' on va lire si l option fichier_log_activé est activée
        With CheckBoxtracelog
            Select Case My.Settings.tracelog
                Case True
                    .Checked = True
                    FichierLogActivé = True
                Case Else
                    .Checked = False
                    FichierLogActivé = False
            End Select
        End With

        ' On va lire si l'option des dimensions et de la position
        ' de la fenêtre principale est cochée
        With CheckBoxConfigWindow
            Select Case My.Settings.WindowState
                Case 1
                    .Checked = True
                Case Else
                    .Checked = False
            End Select
        End With

        ' Mise à jour auto
        If Not (Not datemaj Is Nothing AndAlso String.IsNullOrEmpty(datemaj)) Then
            datesave = CDate(datemaj)
            diffjourmaj = DateDiff(DateInterval.Day, datesave, Date.Now)
            ' différence en jours
            jourrestantmaj = Str(intervalmaj - diffjourmaj)
            ' calcul du nombre de jours restant

            ' Si on a dépassé la date de mise à jour --> jourrestant = 0
            If Val(jourrestantmaj) <= 0 Then
                jourrestantmaj = Str(0)
            End If

            ' On affiche le nombre de jours restant dans les préférences
            LabelUpdateIn.Text = jourrestantmaj & " " & LngUpdateIn
        End If

        If Not (Not datemaj Is Nothing AndAlso String.IsNullOrEmpty(datemaj)) Then

            ' On affiche la date de la prochaine mise à jour dans les préférences
            Dim jourplusmaj As Integer
            jourplusmaj = CInt(intervalmaj - diffjourmaj)
            Dim dmaj As Date = Date.Now.AddDays(jourplusmaj)
            TextBoxUpdateNext.Text = (dmaj.ToLongDateString).ToString

        End If

        ' Mise à jour auto
        If Not (Not datemaj Is Nothing AndAlso String.IsNullOrEmpty(datemaj)) Then
            datesave = CDate(datemaj)
            diffjourmaj = DateDiff(DateInterval.Day, datesave, Date.Now)
            ' différence en jours
            jourrestantmaj = Str(intervalmaj - diffjourmaj)
            ' calcul du nombre de jours restant

            ' Si on a dépassé la date de mise à jour --> jourrestant = 0
            If Val(jourrestantmaj) <= 0 Then
                jourrestantmaj = Str(0)
            End If

            ' On affiche le nombre de jours restant dans les préférences

            LabelUpdateIn.Text = jourrestantmaj & " " & LngUpdateIn
        End If

        If Not (Not datemaj Is Nothing AndAlso String.IsNullOrEmpty(datemaj)) Then

            ' On affiche la date de la prochaine mise à jour dans les préférences
            Dim jourplusmaj As Integer
            jourplusmaj = CInt(intervalmaj - diffjourmaj)
            Dim dmaj As Date = Date.Now.AddDays(jourplusmaj)
            TextBoxUpdateNext.Text = (dmaj.ToLongDateString).ToString
        End If

        ' On affiche la taille de la bdd dans les préférences
        Dim fichierInfo As New FileInfo(BddPath & "db_progs.db3")
        Dim tailleFichier As Integer = CInt(fichierInfo.Length)
        tailleFichier = CInt(tailleFichier / 1024)
        TextBoxTailleBdd.Text = tailleFichier.ToString("##,###", CultureInfo.CurrentCulture) & " Ko"

        ' Combobox Gestion du Son
        ComboBoxRSS.Items.Clear()
        ComboBoxMessages.Items.Clear()
        ComboBoxReminder.Items.Clear()

        ' On scanne le répertoire 'Media' et on peuple dans les combobox
        Try
            Dim dirInfo As New DirectoryInfo(MediaPath)

            For Each fileInfo As FileInfo In From fileInfo1 In dirInfo.GetFiles Where [String].Equals(fileInfo1.Extension, ".wav", StringComparison.CurrentCulture)
                ComboBoxRSS.Items.Add(fileInfo.Name)
                ComboBoxMessages.Items.Add(fileInfo.Name)
                ComboBoxReminder.Items.Add(fileInfo.Name)
            Next
        Catch ex As IOException
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try

        ' On affiche les sons wav sélectionnés
        With My.Settings
            ComboBoxRSS.Text = .RSSSound
            ComboBoxMessages.Text = .MessagesSound
            ComboBoxReminder.Text = .ReminderSound
        End With

        ' On va lire le volume du flux RSS
        TrackBarRSS.Value = My.Settings.RSSVolume

        ' On va lire le volume des messages
        TrackBarMessages.Value = My.Settings.MessagesVolume

        ' On va lire le volume des rappels des émissions
        TrackBarReminder.Value = My.Settings.ReminderVolume

        ' On va lire si le son est sur muet
        Select Case My.Settings.AudioOn
            Case True
                CheckBoxAudioOn.Checked = False
            Case Else
                CheckBoxAudioOn.Checked = True
        End Select
    End Sub

    Private Sub FrmPrefFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        Dim fichierInfo As New FileInfo(BddPath & "db_progs.db3")
        If My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") Then
            Dim tailleFichier As Integer = CInt(fichierInfo.Length)
            tailleFichier = CInt(tailleFichier / 1024)
            If tailleFichier < 4 Then
                Application.Exit()
            End If
        End If
        Dispose()
    End Sub

    Private Sub CheckBoxAutoUpdateCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles CheckBoxAutoUpdate.CheckedChanged

        ' Si Autoupdate est coché on active les autres groupbox
        Select Case CheckBoxAutoUpdate.Checked
            Case False
                GroupBoxIntervalle.Enabled = False
                GroupBoxUpdateIn.Enabled = False
                GroupBoxUpdateNext.Enabled = False
            Case Else
                GroupBoxIntervalle.Enabled = True
                GroupBoxUpdateIn.Enabled = True
                GroupBoxUpdateNext.Enabled = True
        End Select
    End Sub

    Private Sub ButtonRssSoundClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonRSSSound.Click
        Try
            'Dim wave As New WaveOut
            'Dim xa() As Byte = File.ReadAllBytes(MediaPath & ComboBoxRSS.Text())
            'Dim data As New MemoryStream(xa)
            'wave.Init(New BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(New WaveFileReader(data))))
            'wave.Volume = CInt(TrackBarRSS.Value / 10)
            'wave.Play()
            'data.Close()
            'data.Dispose()
            Mainform.JouerSon(ComboBoxRSS.Text, CInt(TrackBarRSS.Value / 10))
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)

        End Try
    End Sub

    Private Sub ButtonMessagesSoundClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonMessagesSound.Click
        Try
            'Dim wave As New WaveOut
            'Dim xa() As Byte = File.ReadAllBytes(MediaPath & ComboBoxMessages.Text())
            'Dim data As New MemoryStream(xa)
            'wave.Init(New BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(New WaveFileReader(data))))
            'wave.Volume = CInt(TrackBarMessages.Value / 10)
            'wave.Play()
            'data.Close()
            'data.Dispose()
            Mainform.JouerSon(ComboBoxMessages.Text, CInt(TrackBarMessages.Value / 10))
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try
    End Sub

    Private Sub ButtonReminderSoundClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonReminderSound.Click
        Try
            'Dim wave As New WaveOut
            'Dim xa() As Byte = File.ReadAllBytes(MediaPath & ComboBoxReminder.Text())
            'Dim data As New MemoryStream(xa)
            'wave.Init(New BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(New WaveFileReader(data))))
            'wave.Volume = CInt(TrackBarReminder.Value / 10)
            'wave.Play()
            'data.Close()
            'data.Dispose()
            Mainform.JouerSon(ComboBoxReminder.Text(), CInt(TrackBarReminder.Value / 10))
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try
    End Sub

    Private Sub CheckBox1CheckedChanged(sender As System.Object, e As EventArgs) Handles CheckBoxAdaptationAuto.CheckedChanged

        If CheckBoxAdaptationAuto.Checked Then
            NumericUpDownToolTipTime.Enabled = False
        Else
            NumericUpDownToolTipTime.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxResumeCheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxResume.CheckedChanged

        If CheckBoxResume.Checked Then
            GroupBoxResumeBefore.Enabled = True
        Else
            GroupBoxResumeBefore.Enabled = False
        End If
    End Sub

    Private Sub ProxyClick(sender As Object, e As EventArgs) Handles Button1.Click

        PremierDemarrage.ShowDialog()
    End Sub
End Class
