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

#Region "Imports"

Imports System.Runtime
Imports System.IO
Imports System.Threading
Imports System.Reflection
Imports System.Globalization
Imports System.Configuration
Imports System.Net
Imports Microsoft.Win32
Imports NAudio.Wave
Imports SearchOption = Microsoft.VisualBasic.FileIO.SearchOption
Imports System.Xml
Imports System.Runtime.InteropServices

#End Region

' ReSharper disable CheckNamespace
Public Class Mainform
    ' ReSharper restore CheckNamespace
    Inherits Form

#Region "Property"

    Private _mutex As Mutex

    ' on est averti un certain temps avant le debut d une emission marquee
    ' exprimé en heures
    Public Const DelaiAvertissement As Integer = 8
    Private ReadOnly _autoComplete As New AutoCompleteStringCollection()

    ' pour les heures a
    ' partir de maintenant jusque la fin des date( < nb_total_type_emission)
    Public TshEnCours As Boolean

    ' traitement scroll horizontal
    ' en cours , ne pas les accumuler trop rapidement
    Public ScrollHorizontal As Boolean ' = False

    Public NbMaxChaineEcran As Integer
    Public AppliRestart As Boolean

    'Private _sw1 As StreamWriter

    ' flag specifiant si on veut creer un fichier log où seront
    ' écrites les indstructions trace.writeline
    ' ce flag est mis à un en allant dans les préférences et cochant
    ' une option précise(activer trace log)
    Public ReadOnly Tl As TextWriterTraceListener

    ' ReSharper disable NotAccessedField.Global
    ' ReSharper disable UnusedMember.Local
    Private _mGraphics As Graphics
    ' ReSharper restore UnusedMember.Local
    ' ReSharper restore NotAccessedField.Global
    'Private _gLine As PaintEventArgs
    Public MajautoReussie As Boolean
    ' ReSharper disable NotAccessedField.Global
    Public MsgProxyTitle As String
    ' ReSharper restore NotAccessedField.Global
    ' ReSharper disable NotAccessedField.Global
    Public MsgProxy As String
    ' ReSharper restore NotAccessedField.Global

    'Private _sMaintenant As String
    ' ReSharper disable NotAccessedField.Global
    Public JumelleEnfonce As Boolean
    ' ReSharper restore NotAccessedField.Global
    Private _dateMajBack As String = DateTime.Now.ToString

    Public NameofMonth1 As String
    Public NameofMonth2 As String
    Public NameofMonth3 As String
    Public NameofMonth4 As String
    Public NameofMonth5 As String
    Public NameofMonth6 As String
    Public NameofMonth7 As String
    Public NameofMonth8 As String
    Public NameofMonth9 As String
    Public NameofMonth10 As String
    Public NameofMonth11 As String
    Public NameofMonth12 As String

    Public MessageBoxMiseaJour As String
    Public MessageBoxMiseaJour1 As String
    Public MessageBoxMiseaJourTitre As String

    Public MessageBoxMiseaJourDone As String
    Public MessageBoxMiseaJour1Done As String
    Public MessageBoxMiseaJourTitreDone As String

    Public MessageBoxNoData As String
    Public MessageBoxNoDataTitre As String

    Public MessageBoxModifPref As String
    Public MessageBoxModifPref1 As String
    Public MessageBoxModifPrefTitre As String

    Public MessageBoxNoConnection As String
    Public MessageBoxNoConnection1 As String
    Public MessageBoxNoConnectionTitre As String

    Public ToolStripStatusLabelMb As String
    Private ReadOnly _os As OperatingSystem = Environment.OSVersion

    Public MessageBoxResume As String
    Public MessageBoxResume1 As String
    Public MessageBoxResumeTitre As String

    Public MessageBoxBasePerimee As String
    Public MessageBoxBasePerimee1 As String
    Public MessageBoxBasePerimeeTitre As String

    Public Siteofficiel As String
    Public Forumofficiel As String

    Public MessageBoxTitleRaz As String
    'Private _msgRaz As String

    Public MessageBoxRaz As String
    'Private _msgRaz2 As String
    Public MessageBoxRaz1 As String
    Private _miseaJourAutoExe As Boolean

    Public MessageBoxMiseaJourExe As String
    Public MessageBoxMiseaJourExe1 As String
    Public MessageBoxMiseaJourExeTitre As String
    Public MessageBoxMiseaJourExeActual As String
    Public MessageBoxMiseaJourExeNew As String

    Public MessageBoxnoupdate As String
    Public MessageBoxnoupdateTitre As String

    Private ReadOnly _swStartTime As New Stopwatch

    Public NoDatabaseOnStart As Boolean
    Public DataBaseIsExpired As Boolean

    Public BalloonText1 As String
    Public BalloonText3 As String

    Public MessageBoxMajauto As String
    Public MessageBoxMajautoTitre As String

    Public MessageBoxfichierRetabli As String
    Public MessageBoxfichierRetabliTitre As String

    Public IncrementationSourisHorizontale As Integer

#End Region

#Region "MainformLoad"

    Private Sub MainformLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Néo 31/07/2015
        MenuStrip1.BackColor = Color.White
        StatusStrip2.BackColor = Color.White
        ToolStrip1.Renderer = New CustomRenderer

        ' rvs75:21/09/2013: adaptation pour les fonts systèmes agrandies
        Dim gr As Graphics = CreateGraphics()
        HauteurRichtextbox = CInt((gr.DpiX * HauteurRichtextbox) / 96)
        LargeurLogoAdaptee = CInt((gr.DpiX * LargeurLogoAdaptee) / 96)
        gr.Dispose()

        ' Mutex pour l'assistant d'installation
        _mutex = New Mutex(False, "ZGUIDETV_MUTEX")

        ' Néo 17/01/2011 Mode Suspend/Resume
        AddHandler SystemEvents.PowerModeChanged, AddressOf PowerChanged

        Dim fv As FileVersionInfo
        fv = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)

        Dim opSys As String
        If Environment.Is64BitOperatingSystem Then
            opSys = "64-bit"
        Else
            opSys = "32-bit"
        End If

        ' On envoie au second Thread (SplashScreen)
        SplashScreenClass.VersionText(fv.ProductName & " v" & fv.FileVersion & " beta Release " & opSys)
        SplashScreenClass.CopyrightText(fv.LegalCopyright & " " & fv.CompanyName)

        Hide()

        If My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") Then
            NoDatabaseOnStart = False
        Else
            NoDatabaseOnStart = True
        End If

        'Saisie semi auto recherche rapide dans la barre d'outils
        If File.Exists(AutoCompletePath & "AutoComplete.set") Then
            Dim sr As StreamReader
            sr = File.OpenText(AutoCompletePath & "AutoComplete.set")
            While Not sr.EndOfStream
                _autoComplete.Add(sr.ReadLine)
            End While
            sr.Close()
            sr.Dispose()
        Else
            If Not File.Exists(AutoCompletePath & "AutoComplete.set") Then
                File.Create(AutoCompletePath & "AutoComplete.set")
            End If
        End If

        With ToolStripTextBoxRecherche
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = _autoComplete
        End With

        RechercheTextBoxToolStrip()

        ' prise en compte du decalage horaire sauvé dans les settings
        DecalHoraire = -My.Settings.decalage_horaire

        MomentSouhaite = DebutHeure(DateTime.Now)
        MomentSouhaite = MomentSouhaite.AddHours(DecalHoraire)
        DateReference = MomentSouhaite

        Trace.WriteLine(DateTime.Now & " " & "moment souhaité " & MomentSouhaite.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Décalage horaire = " & DecalHoraire.ToString & " heures")
        Trace.WriteLine(DateTime.Now & " " & "date reference =" & DateReference.ToString)

        ' On va récupérer la configuration matérielle dans le fichier user.config et en fonction de la config
        ' Néo le 25/07/2009
        Select Case My.Settings.ConfHardware
            Case 1
                NbDePeriodesDe_6H = 6
            ' On charge 36 heures d'émissions
            Case 2
                NbDePeriodesDe_6H = 5
            ' On charge 30 heures d'émissions
            Case 3
                NbDePeriodesDe_6H = 4
                ' on charge 24 heures d'émissions
        End Select

        ' On regarde dans .config si il faut utiliser la taille et
        ' la position sauvegardée de la fenêtre principale
        With My.Settings
            Select Case .WindowState
                Case 1
                    Size = .WindowSizeMain
                    Location = .WindowLocationMain
                Case Else
                    Size = My.Computer.Screen.WorkingArea.Size

                    ' 29/03/2009 Néo
                    Top = (Screen.PrimaryScreen.WorkingArea.Height() - Height)
                    Left = (Screen.PrimaryScreen.WorkingArea.Width() - Width)
                    Trace.WriteLine(
                        DateTime.Now & " " & "Screen.PrimaryScreen.WorkingArea.Height= " &
                        Screen.PrimaryScreen.WorkingArea.Height.ToString)
                    Trace.WriteLine(
                        DateTime.Now & " " & "Screen.PrimaryScreen.WorkingArea.width= " &
                        Screen.PrimaryScreen.WorkingArea.Width.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "me.top = " & Top.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "me.left = " & Left.ToString)
                    WindowState = FormWindowState.Maximized
            End Select

            ' On regarde dans .config si il faut utiliser
            ' la sauvegarde des buttons
            With My.Settings
                If .buttonssave = 1 Then

                    ' SynthBoutons = .buttonsstate
                    SynthBoutons = Math.Min(1, .buttonsstate)

                    ' ReSharper disable once SimplifyIIf
                    Bdpad = DirectCast(IIf(SynthBoutons = 1, True, False), Boolean)
                End If
            End With
        End With

        Text = String.Format(fv.ProductName & " v" & fv.FileVersion & " beta Release")

        'Néo 29/05/2010 On regarde si la bdd est périmée
        If _
            My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") AndAlso
             My.Settings.Lienmiseajour.Trim().Length > 0 Then
            Dim fichierInfo As FileInfo = New FileInfo(BddPath & "db_progs.db3")
            Dim tailleBdd As Integer = CInt(fichierInfo.Length)
            If BasePerimee() AndAlso tailleBdd > 6000 Then
                My.Settings.DataBaseExpired = True
                DataBaseIsExpired = True
                Hide()

                'Néo le 09/09/2010
                If Not My.Settings.DIRChecked Then
                    Try

                        HideControls.Hide()

                        LanguageCheck(16)

                        Application.DoEvents()
                        Show()
                        Application.DoEvents()
                        Opacity = 100

                        ' On fait passer le mainform en foreground (remplace l'ancien focus et activate)
                        BringToFront()
                        TopMost = True
                        Activate()

                        ' Ce DoEvents permet de ne pas voir le splashscreen au dessus de la msgbox de mise à jour auto ci-dessous
                        Application.DoEvents()

                        ' On arrête le thread du SplashScreen
                        Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du SplashScreen")
                        SplashScreenClass.CloseSplashScreen()

                    Catch ex As ThreadAbortException
                        Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    End Try

                    TopMost = False

                    Dim myUri As New Uri(My.Settings.Lienmiseajour)
                    Dim baseUri As String = myUri.GetLeftPart(UriPartial.Authority)
                    If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable(baseUri) Then

                        Try
                            If My.Settings.AudioOn Then
                                JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                            End If
                        Catch ex As Exception
                            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                        End Try

                        TopMost = False

                        Dim boxBasePerimee As DialogResult
                        boxBasePerimee = MessageBox.Show _
                            (MessageBoxBasePerimee & Chr(13) & Chr(13) & MessageBoxBasePerimee1,
                             MessageBoxBasePerimeeTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1)

                        If boxBasePerimee = DialogResult.Yes Then
                            Trace.WriteLine(DateTime.Now & " " & "entree Miseajour car base périmée")
                            Miseajour.Show()
                            '!!!!!!!!
                        Else
                            Trace.WriteLine(DateTime.Now & " " & "passage exit sub")
                            Exit Sub
                        End If
                    End If

                Else

                    ' Mise à jour depuis un fichier xmltv sur le hdd
                    ' Néo 22/01/2012 
                    Try

                        HideControls.Hide()

                        LanguageCheck(16)

                        Application.DoEvents()
                        Show()
                        Application.DoEvents()
                        Opacity = 100

                        ' On fait passer le mainform en foreground (remplace l'ancien focus et activate)
                        BringToFront()
                        TopMost = True
                        Activate()

                        ' Ce DoEvents permet de ne pas voir le splashscreen au dessus de la msgbox de mise à jour auto ci-dessous
                        Application.DoEvents()

                        ' On arrête le thread du SplashScreen
                        Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du SplashScreen")
                        SplashScreenClass.CloseSplashScreen()

                    Catch ex As ThreadAbortException
                        Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    End Try

                    TopMost = False

                    Try
                        If My.Settings.AudioOn Then
                            JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                        End If
                    Catch ex As Exception
                        Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    End Try

                    Dim boxBasePerimee As DialogResult
                    boxBasePerimee = MessageBox.Show _
                        (MessageBoxBasePerimee & Chr(13) & Chr(13) & MessageBoxBasePerimee1,
                         MessageBoxBasePerimeeTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1)

                    If boxBasePerimee = DialogResult.Yes Then
                        Trace.WriteLine(DateTime.Now & " " & "entree Miseajour car base périmée")

                        Miseajour.Show()
                        '!!!!!!!!
                    Else
                        Trace.WriteLine(DateTime.Now & " " & "passage exit sub")
                        Exit Sub
                    End If
                End If
                Return
            End If
        End If

        ' vérifie si la db existe sinon la créer et faire la connection
        If My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") = False Then
            My.Settings.BddExists = False

            ' la BD n existe pas
            NombreDeChainesDifferentes = My.Settings.nbchainesdiff
            CreateDbTables()
            DessineLigneTemps()
            NotifyIcon1.Visible = False

            Hide()

            'Néo le 05/09/2010
            Try

                HideControls.Hide()

                LanguageCheck(15)

                Application.DoEvents()
                Show()
                Application.DoEvents()
                Opacity = 100%

                ' On arrête le thread du SplashScreen
                Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du SplashScreen")
                SplashScreenClass.CloseSplashScreen()

            Catch ex As ThreadAbortException
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try
            Return
        Else

            ' la  BD existe
            My.Settings.BddExists = True
            NombreDeChainesDifferentes = My.Settings.nbchainesdiff

            PanelB.Width = LargeurLogoAdaptee
            'HauteurTaskbar = GetTaskBarHeight()

            ZSplitButton1.Width = LargeurBoutonsVerticaux
            ZSplitButtonGauche.Width = LargeurBoutonsVerticaux
            ZSplitButtonDroit.Width = LargeurBoutonsVerticaux

            CaracteristiquesEcranEtMainform()

            Dim z1 As Integer
            'Dim z2 As Integer
            z1 = Size.Width
            If z1 > LargeurEcran Then
                Erreurh = z1 - LargeurEcran
            End If

            ZSplitButtonDroit.Left = z1 - Calendar.Width - LargeurBoutonsVerticaux - Erreurh
            PanelAPointWidthMax = z1 - ZSplitButtonDroit.Width - ZSplitButton1.Width - ZSplitButtonGauche.Width -
                                  PanelB.Width -
                                  Erreurh

            LongueurLigneTemp = PanelAPointWidthMax
            NbPixelsPour30Minutes = CInt(LongueurLigneTemp / (2 * NbHeuresLigneTemps))

            ReferencesTemps()

            PremiereInitialisation()

            ChargeCategorie()


            ZSplitButton1.Visible = True

            DefinirHauteurButtonGaucheEtAutres()

            ' il faut que à ce stade( avant create_panelboxes)
            ' nb_emissions_for_ce_Soir et
            ' nb_emissions_for_maintenant soient calculés.

            ' calcul de nb_emissions_for_ce_soir 
            Panel_ce_soir.Controls.Clear()
            Panel_maintenant.Controls.Clear()
            GetNumberOfEmissionsForMaintenant()
            CreatePanelboxes()

            ' Modifié par Néo le 05/01/2014
            Dim hauteurEffective As Integer = Screen.PrimaryScreen.WorkingArea.Height - MenuStrip1.Height -
                                              ToolStrip1.Height - navigtemporelle.Height - StatusStrip2.Height

            NbMaxChaineEcran = CInt(hauteurEffective / PeriodiciteVerticale) - 1

            Trace.WriteLine(DateTime.Now & " " & "nb_max chaine ecran = " & NbMaxChaineEcran.ToString)
            Trace.WriteLine(
                DateTime.Now & " " & "nb de chaines differentes selectionnées à la mise a jour =" &
                NombreDeChainesDifferentes.ToString)

            If My.Settings.nbchainesdiff < NbMaxChaineEcran AndAlso My.Settings.accordscrollhorizontal Then
                ScrollHorizontal = True
                My.Settings.scrollhorizontal = ScrollHorizontal
                Trace.WriteLine(DateTime.Now & " " & "scroll_horizontal à true")
            End If

            If Not My.Settings.nbchainesdiff < NbMaxChaineEcran Then
                ScrollHorizontal = False
                My.Settings.scrollhorizontal = ScrollHorizontal
                Trace.WriteLine(DateTime.Now & " " & "scroll_horizontal à false")
            End If

            CentralScreen.PixelsNonUtilisésPourLesEmissions()

            ConstantsWidestScreen()

            DessineLigneTemps()

            DeplacerPanelA()

            CentralScreen.InitialisationsDiverses()

            AffichageCeSoir()

            PanelE.BringToFront()
            Trace.WriteLine(DateTime.Now & " " & "démarrage timer minute")

            Trace.WriteLine(
                DateTime.Now & " " & "Left = " & LargeurLogoAdaptee.ToString & " top = " &
                ValTopMaintenant(0).ToString & " text= " & TableauListEmissionsMaintenant(0).Ptitle)

            ' Init ouvre le fichier english.lng ou francais.lng ou lng d une autre langue
            ' et attribue les valeurs de contantes comme lngshortfilm, lngdebate....
            Trace.WriteLine(DateTime.Now & " " & "LanguageCheck Dans Mainform Load")
            LanguageCheck()

            AffichageMaintenant()

            'Dim numeroDEmission As Integer
            Dim nbPixels As Integer
            nbPixels = -PanelA.Left + InutiliseAGauche(SynthBoutons)
            DateOrigineEcran =
                DateReference.AddMinutes((30 * nbPixels) / NbPixelsPour30Minutes).AddHours(DecalHoraire)

            NomFichierLogo = TableauChaine(NumChaineHautEcran).Logo
            ' DrawLogoInPictureboxlogo(nom_fichier_logo)
            Trace.WriteLine(DateTime.Now & " " & "composer message descrip")
            'Central_Screen.ComposerMessageDescrip(numeroDEmission, "principale")
            PanelB.Select()

            ' permettre le mousewheel pour changer
            ' les chaines affichees
            AfficherDateOrigineEcran()
            ResumeLayout()
        End If

        PositionneBoutonsMemorises()
        Trace.WriteLine(
            DateTime.Now & " " &
            "On est dans le mainform repere 1  avant un Central_Screen.examine_memory()")

        ' Verifier les conditions pour voir si une mise a jour automatique est possible
        ' Néo 06/07/11
        If _
            (My.Settings.URLChecked AndAlso
             (Not (Not My.Settings.Lienmiseajour Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Lienmiseajour)))) _
            Then 'OrElse

            ToolStripAutoUpdate.Enabled = True
            ToolStripMenuOptionsAutoUpdate.Enabled = True
        Else
            ToolStripAutoUpdate.Enabled = False
            ToolStripMenuOptionsAutoUpdate.Enabled = False
        End If

        IniCalendrier(Date.Now)

        If Not File.Exists(ChannelSetPath & "ZGuideTVDotNet.channels.set") Then
            InitierChannelsSet()
        End If

        Trace.WriteLine(
            DateTime.Now & " " & "On met a jour la compensation dans la ToolStatusStrip : " &
            My.Settings.decalage_horaire)

        With My.Settings
            Select Case .decalage_horaire
                Case Is > 0
                    ToolStripStatusLabelMinutes.Text = "+" & .decalage_horaire & " h."
                Case Is < 0
                    ToolStripStatusLabelMinutes.Text = "-" & .decalage_horaire.ToString & " h."
                Case 0
                    ToolStripStatusLabelMinutes.Text = "Off"
            End Select
        End With

        'On affiche l'heure dans la StatusStrip
        Trace.WriteLine(DateTime.Now & " " & "Timer_seconde.Start()")
        Timer_seconde.Start()

        ' On affiche la mémoire utilisée par zg et la mémoire totale dans la StatusStrip
        ' Usage_Memory()
        Trace.WriteLine(DateTime.Now & " " & "TimerUsageMemory.Start()")
        TimerUsageMemory.Start()

        Trace.WriteLine(DateTime.Now & " " & "Mainform Me.Show")
        ShowInTaskbar = True
        Show()

        ' Ce DoEvents permet de ne pas voir les controles qui se dessinent à l'écran avant
        ' d'afficher ZGuideTV
        Application.DoEvents()
        Trace.WriteLine(DateTime.Now & " " & "Mainform Me.Opacity = 100")
        Opacity = 100

        ' On fait passer le mainform en foreground (remplace l'ancien focus et activate)
        BringToFront()
        TopMost = True
        Activate()

        ' Ce DoEvents permet de ne pas voir le splashscreen au dessus de la msgbox de mise à jour auto ci-dessous
        Application.DoEvents()

        ' Néo le 08/09/2010
        ' On arrête le thread du SplashScreen
        Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du SplashScreen")
        Try
            SplashScreenClass.CloseSplashScreen()
        Catch ex As ThreadAbortException
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try

        TopMost = False


        Trace.WriteLine(DateTime.Now & " " & "on va entrer dans MaJ_Date_StatusBar ")
        MaJDateStatusBar()
        Trace.WriteLine(DateTime.Now & " " & "fin mise a jour date status bar")

        CentralScreen.CurseurVertical()
        Trace.WriteLine(DateTime.Now & " " & "sortie de curseur_vertical")

        With Timer_minute
            .Start()
            .Enabled = True
        End With

        RecupererEmissionsMarquees()

        MyMemoireClean()

        ' Néo le 05/09/2010
        ' Purge des fichiers obsolètes
        Mypurge()

        _swStartTime.Stop()

        ' Néo le 11/09/2015 
        ' On lance la vérification auto des grilles tv après 0,5 secondes
        Timer_AutoUpdate.Interval = 500
        Timer_AutoUpdate.Start()

        Trace.WriteLine(
            DateTime.Now & " " &
            "on sort de la SR mainform load --------------------------------------------------------->")
        Trace.WriteLine(
            DateTime.Now & " " & "Temps de démarrage : " & _swStartTime.ElapsedMilliseconds / 1000 & " secondes")


        ' On crée une erreur pour tester les routines try catch
        ' Dim moi(2) As String
        ' Dim lui As String = moi(4)

    End Sub

#End Region

#Region "AutoUpdate"

    Private Sub Timer_AutoUpdate_Tick(sender As Object, e As EventArgs) Handles Timer_AutoUpdate.Tick

        Dim miseajouraeffectuer As Boolean

        Timer_AutoUpdate.Stop()

        ' mise à jour auto des grilles tv
        ' On regarde si dans les préfs ,on a activé la miseajour auto
        Trace.WriteLine(DateTime.Now & " " & "On regarde si dans les préfs ,on a activé la miseajour auto")
        If My.Settings.AutoUpdate = 1 Then

            Dim datemaj As String
            ' date de la derniere mise a jour
            Dim datesave As Date
            Dim diffjourmaj As Long
            Dim jourrestantmaj As String
            ' nb de jours restant avant maj
            Dim majinterval As Integer
            ' nb de jours max entre 2 maj
            ' intervalle de miseajour en jour(s)
            majinterval = My.Settings.intervalmiseajour
            datemaj = My.Settings.datemajmiseajour
            _dateMajBack = datemaj
            ' memorisation en cas de fichier corrompu
            Trace.WriteLine(DateTime.Now & " " & "date de derniere mise a jour = " & datemaj)
            ' date dernière miseajour
            ' vérification des conditions de dates
            ' pour les mises a jour auto

            Try
                If Not (Not datemaj Is Nothing AndAlso String.IsNullOrEmpty(datemaj)) Then
                    datesave = CDate(datemaj)
                    diffjourmaj = DateDiff(DateInterval.Day, datesave, Date.Now)
                    ' différence en jours 
                    jourrestantmaj = Str(majinterval - diffjourmaj)
                    ' nombre de jours restant avant maj                  
                    ' Si on a dépassé la date de vérification(jourrestant<= 0)
                    ' et vérification auto activée on lance une miseajour auto
                    If Val(jourrestantmaj) <= 0 AndAlso My.Settings.AutoUpdate = 1 Then

                        miseajouraeffectuer = True

                        Application.DoEvents()

                        ' Ajout de Néo le 16/02/2010
                        ' On teste si l'URL de mise à jour auto est accessible pour éviter que cela plante
                        Dim myUri As New Uri(My.Settings.Lienmiseajour)
                        Dim baseUri As String = myUri.GetLeftPart(UriPartial.Authority)
                        If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable(baseUri) Then

                            Try
                                If My.Settings.AudioOn Then
                                    JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                                End If
                            Catch ex As Exception
                                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                            End Try

                            Dim boxMiseaJour As DialogResult
                            boxMiseaJour = MessageBox.Show _
                                (MessageBoxMiseaJour & Chr(13) & MessageBoxMiseaJour1,
                                 MessageBoxMiseaJourTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button1)

                            If boxMiseaJour = DialogResult.Yes Then
                                Trace.WriteLine(DateTime.Now & " " & "entree dans maj_grille_tv")

                                ' Néo le 27/01/2013
                                TopMost = False
                                MajGrilleTv()
                            Else
                                Trace.WriteLine(" passage return")
                                Return
                            End If

                            ' test de majauto_reussie a faire avant de mettre a jour la date de mise a jour
                            If MajautoReussie Then
                                Trace.WriteLine(DateTime.Now & " " & "la mise a jour auto a reussi")
                                Timer_minute.Stop()
                                ' une mise a jour reussie peut se passer avec un fichier corrompu
                                My.Settings.datemajmiseajour = (Date.Now).ToString
                                My.Settings.Save()
                                Trace.WriteLine(DateTime.Now & "mise a jour full auto effectuée au démarrage de zguide")
                                MajautoReussie = False
                                Trace.WriteLine(" juste avant application.restart dans maj grille tv full automatique")
                                Application.DoEvents()
                                Miseajour.Close()
                                Trace.WriteLine(
                                    DateTime.Now & " " & "redemarrage du timer_minute " &
                                    DateTime.Now.ToString)
                                'BB240609

                                Timer_wait.Start()
                                'BB 220610
                                Timer_wait.Enabled = True
                                AppliRestart = True
                                Trace.WriteLine(
                                    DateTime.Now & " " &
                                    "on attend l interrupt timer_wait  pour restarter l application")
                            Else
                                ' La mise a jour full auto a echoué et sera effectuée plus tard
                                Trace.WriteLine(
                                    DateTime.Now & " " &
                                    "La mise a jour planifiée a échoué et sera effectuée plus tard !")

                                ' ReSharper disable NotAccessedVariable
                                Dim boxMajauto As DialogResult
                                ' ReSharper restore NotAccessedVariable
                                boxMajauto = MessageBox.Show _
                                (MessageBoxMajauto,
                                 MessageBoxMajautoTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                 MessageBoxDefaultButton.Button1)
                            End If
                        End If
                    End If

                    ' Si aucune vérif n'a été effectuée
                    ' on sauvegarde la date actuelle
                    If (Not datemaj Is Nothing AndAlso String.IsNullOrEmpty(datemaj)) Then
                        My.Settings.datemajmiseajour = (Date.Now).ToString
                        My.Settings.Save()
                    End If
                End If
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & "Echec lors de la mise a jour full auto au démarrage de zguide")
            End Try
        End If

        If miseajouraeffectuer = False Then
            ' Néo le 02/01/2017 
            ' On lance la vérification auto de la version de zguidetv.exe
            ' car il n'y a pas de mise à jour auto des grilles tv prévue
            ZGuideTvDotNetUpdateSr()
        End If
    End Sub

#End Region

#Region "ZGuideTVDotNetUpdateSR"

    Private Sub ZGuideTvDotNetUpdateSr()

        '------------------------------------------------------------
        ' vérification auto de la version de zguidetv.exe
        ' On regarde si dans les préfs on a activé la vérif auto
        '------------------------------------------------------------
        If My.Settings.Autoverif = 1 Then

            Trace.WriteLine(DateTime.Now & " " & "Vérification auto de la version de zguidetv.exe")
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.zguidetv.net/") Then
                ' maj de la version de zguidetv.exe
                _miseaJourAutoExe = True

                ' Néo le 24/04/2013
                ' On crée un thread pour parser le XML
                Dim xmlParserthread As Thread = New Thread(AddressOf XmlParser)
                With xmlParserthread
                    .IsBackground = True
                    .Start()
                End With

                Trace.WriteLine(DateTime.Now & " " & "Vérification auto effectuée au démarrage de zguide")
            End If
        End If
    End Sub

#End Region

#Region "XmlParser"

    Private Sub XmlParser()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans Sub XmlParser()")

        ' La variable newVersion contient
        ' la version contenue dans le fichier xml 
        Dim newVersion As Version = Nothing
        Dim productZguideTv As String = String.Empty
        Dim reader As XmlTextReader = Nothing

        Try
            ' Fourni les url et versions contenues dans le document xml
            Const xmlUrl As String = "http://www.zguidetv.net/zguidetv/zguidetv_version200.xml"
            reader = New XmlTextReader(xmlUrl)
            reader.MoveToContent()

            Dim elementName As String = ""
            ' On controle si le fichier xml contient le noeud "zguidetv"
            If _
                (reader.NodeType = XmlNodeType.Element) AndAlso
                ([String].Equals(reader.Name, "zguidetv", StringComparison.CurrentCulture)) Then
                Do While reader.Read()
                    ' Quand on trouve un noeud on se souvient de son nom  
                    If reader.NodeType = XmlNodeType.Element Then
                        elementName = reader.Name
                    Else
                        ' noeud suivant 
                        If (reader.NodeType = XmlNodeType.Text) AndAlso (reader.HasValue) Then
                            ' On controle le nom des noeuds  
                            Select Case elementName
                                Case "product"
                                    productZguideTv = reader.Value
                                Case "version"
                                    ' On parse le num de version
                                    ' dans le format :  xxx.xxx.xxx.xxx
                                    newVersion = New Version(reader.Value)
                            End Select
                        End If
                    End If
                Loop
            End If
        Catch ex As Exception
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try

        ' On regarde le numéro de la version actuelle  
        Dim curVersion As Version = Assembly.GetExecutingAssembly().GetName().Version

        ' On compare les versions
        Trace.WriteLine(DateTime.Now & " " & "On compare les versions dans Sub XmlParser()")
        If curVersion.CompareTo(newVersion) < 0 Then
            Trace.WriteLine(DateTime.Now & " " & "Il y a une nouvelle version disponible dans Sub XmlParser()")
            ' On demande à l'utilisateur si  
            ' il veut télécharger la nouvelle version

            Try
                If My.Settings.AudioOn Then
                    JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                End If
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            Dim fv As FileVersionInfo
            fv = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)


            Dim boxMiseaJourExe As DialogResult
            boxMiseaJourExe = MessageBox.Show _
                (
                    MessageBoxMiseaJourExe & Chr(13) & Chr(13) & MessageBoxMiseaJourExeActual & fv.ProductName & " v" &
                    fv.FileVersion & Chr(13) & MessageBoxMiseaJourExeNew & productZguideTv & " v" &
                    newVersion.ToString() & Chr(13) & Chr(13) & MessageBoxMiseaJourExe1,
                    MessageBoxMiseaJourExeTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1)


            If boxMiseaJourExe = DialogResult.Yes Then
                Trace.WriteLine(DateTime.Now & " " & "On va télécharger la mise à jour de l'exe")

                SuspendLayout()

                ' -------------------------------------------------------------------------------------------------------
                ' Provisoire !!!!
                ' Modifié par Néo le 12/12/2015
                If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://github.com/") Then

                    If [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                        Process.Start("https://github.com/neojudgment/ZGuideTVDotNet/blob/master/Docs/READMEFR.md")
                    Else
                        Process.Start("https://github.com/neojudgment/ZGuideTVDotNet")
                    End If

                    Application.DoEvents()
                    My.Settings.Save()
                    Application.Exit()
                Else

                    ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                    ' aller sur le site internet de zguidetv
                    ' ReSharper disable NotAccessedVariable
                    Dim boxNoConnection As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                End If
                '-------------------------------------------------------------------------------------------------------

                ' ZGuideTvDotNetUpdate.ShowDialog(Me)
                'Application.DoEvents()
                'My.Settings.Save()
                'Application.Exit()
                ResumeLayout()
            Else
                Trace.WriteLine(DateTime.Now & " " & "On ne va pas télécharger la mise à jour de l'exe")
                Return
            End If
        Else

            Trace.WriteLine(DateTime.Now & " " & "Il n'y a pas de mise à jour de l'exe")
            Trace.WriteLine(DateTime.Now & " ")

            ' On regarde si c'est une mise à jour auto
            If Not _miseaJourAutoExe Then
                ' ReSharper disable NotAccessedVariable
                Dim boxMiseaJour As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxMiseaJour = MessageBox.Show _
                    (MessageBoxnoupdate,
                     MessageBoxnoupdateTitre, MessageBoxButtons.OK, MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1)
                Return
            Else
                _miseaJourAutoExe = False
            End If
        End If
    End Sub

#End Region

#Region "PowerdChanged"

    Private Sub PowerChanged(ByVal sender As Object, ByVal e As PowerModeChangedEventArgs)

        Trace.WriteLine(DateTime.Now & " " & "Entrée dans PowerChanged")

        ' Gestion du mode veille
        If My.Settings.ResumeChecked = 1 Then

            ' Le système passe en veille
            If e.Mode = PowerModes.Suspend Then
                Trace.WriteLine(DateTime.Now & " " & "Le système entre en veille")
                Dim marquedFile As String = MarqueesPath & "ZGuideTVDotNet.marked.set"

                ' On regarde si le fichier ZGuideTVDotNet.marked.set existe
                If File.Exists(marquedFile) Then

                    Dim datePourReveil As Date = GetLowesttDate()

                    'On récupère le date et l'heure de l'émission marquée
                    Dim rappelEmission As String
                    rappelEmission = datePourReveil.ToString()
                    Dim _
                        rappelDateHeure As Date =
                            (CDate((FormatDateTime(CDate(rappelEmission), DateFormat.GeneralDate).ToString)))
                    rappelDateHeure = DateAdd("n", -My.Settings.ResumeBefore, rappelDateHeure)
                    Trace.WriteLine(DateTime.Now & " " & "Heure de réveil : " & rappelDateHeure)

                    Try
                        Dim wup As New WakeUp()
                        ' On envoie la date et l'heure à laquelle le pc doit se réveiller
                        Trace.WriteLine(
                            DateTime.Now & " " &
                            "On envoie la date et l'heure à laquelle le pc doit se réveiller")
                        wup.SetWakeUpTime(rappelDateHeure)
                    Catch ex As Exception
                        Trace.WriteLine(DateTime.Now & " " & "Erreur lors du passage en mode veille")
                    End Try
                End If
            End If
        End If

        ' Le système sort de veille
        If e.Mode = PowerModes.Resume Then
            Trace.WriteLine(DateTime.Now & " " & "Le système sort de veille à : " & Date.Now)

            ' On fait passer le mainform en foreground après la sortie de veille
            Trace.WriteLine(DateTime.Now & " " & "On fait passer le mainform en foreground")
            BringToFront()

            Application.DoEvents()

            ' ReSharper disable NotAccessedVariable
            Dim boxResume As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxResume = MessageBox.Show _
                (MessageBoxResume & Chr(13) & MessageBoxResume1,
                 MessageBoxResumeTitre, MessageBoxButtons.OK, MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#Region "TimerUsageMemory"

    Private Sub TimerUsageMemoryTick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerUsageMemory.Tick

        ' On affiche la mémoire utilisée par zg et la mémoire totale dans la ToolStatusStrip
        Dim memoireTotale As Double = Math.Round(My.Computer.Info.TotalPhysicalMemory / 1024 ^ 2, 0)
        Dim memoireUtilisee As Double = Math.Round(Environment.WorkingSet / 1024 ^ 2, 0) / 2
        ToolStripStatusLabelMemoryUsage.Text = memoireUtilisee & " " & ToolStripStatusLabelMb & " / " & memoireTotale &
                                               " " _
                                               & ToolStripStatusLabelMb
    End Sub

#End Region

#Region "PositionneBoutonsMemorises"

    Private Sub PositionneBoutonsMemorises()
        SuspendLayout()
        If Bdpad Then
            ZSplitButtonDroit.Left = Size.Width - Calendar.Width - LargeurBoutonsVerticaux - Erreurh
            panel_droit.Visible = True
        Else
            ZSplitButtonDroit.Left = Size.Width - ZSplitButtonDroit.Width - Erreurh
            panel_droit.Visible = False
        End If
        panel_droit.Left = ZSplitButtonDroit.Right
        PanelE.Left = ZSplitButtonGauche.Right
        PanelE.Width = ZSplitButtonDroit.Left - ZSplitButtonGauche.Right
        PanelD.Width = PanelA.Width
        Panel_date.Left = PanelB.Left

        ResumeLayout()
    End Sub

#End Region

#Region "AffichageCeSoir"

    Private Sub AffichageCeSoir()
        'rvs75 05/08/2017
        'evite d'avoir des fuites
        'voir ClearAetBPanelboxes pour plus d'infos

        With Panel_ce_soir
            .Visible = False
            For Each ctl As Control In .Controls
                ctl.Dispose()
            Next
            .Controls.Clear()
            .Visible = True
        End With
        'Panel_ce_soir.Controls.Clear()
        GetListOfEmissionsForCeSoir()
        Panel_ce_soir.Height = Math.Max(NbEmissionsForCeSoir, NbLignesCeSoir) * PeriodiciteVerticale

        ' 19/09/2009 rvs75 code rajouté dans  affichage_ce_soir
        ' afin de permettre la mise à jour de ce soir après minuit
        With CentralScreen
            .FillTableauxTopWidthLeftCeSoir()
            '.FillColorOfRichtextboxCeSoir()
            .AffectRichtextboxCeSoir()
            .AffectLogoPictureboxCeSoir(0)
        End With
    End Sub

#End Region

    Private Sub AffichageMaintenant(Optional ByVal forceRefresh As Boolean = False)

        ' 06/12/2009 rvs75 modif afin que le panel maintenant ne se mette à jour
        ' seulement s'il a une diférence entre la minute précédente et cette minute
        ' (n'affecte pas le démarrage)
        Dim blChangeMaintenant As Boolean = False
        If Not (forceRefresh) Then

            Dim memoAncienTableau(TableauListEmissionsMaintenant.Length - 1) As EmissionsList
            'rvs 
            Array.Copy(TableauListEmissionsMaintenant, memoAncienTableau, TableauListEmissionsMaintenant.Length)
            GetListOfEmissionsForMaintenant()
            For r As Integer = 0 To memoAncienTableau.Length - 1
                If memoAncienTableau(r).Pstart <> TableauListEmissionsMaintenant(r).Pstart Then
                    blChangeMaintenant = True
                    Exit For
                End If
            Next

        Else
            blChangeMaintenant = True
        End If

        If blChangeMaintenant Then
            'rvs75 05/08/2017
            'evite d'avoir des fuites
            'voir ClearAetBPanelboxes pour plus d'infos
            With Panel_maintenant
                .Visible = False
                For Each ctl As Control In .Controls
                    ctl.Dispose()
                Next
                .Controls.Clear()
                .Visible = True
            End With
            Panel_maintenant.Controls.Clear()
            With Panel_maintenant
                .Height = NbEmissionsForMaintenant * PeriodiciteVerticale
            End With

            With CentralScreen
                .FillTableauxTopWidthLeftMaintenant()
                '.FillColorOfRichtextboxMaintenant()
                .AffectRichtextboxMaintenant()
                .AffectLogoPictureboxMaintenant(0)
            End With

            Trace.WriteLine(DateTime.Now & " " & "redemarrage de timer minute")

            With Timer_minute
                .Start()
                .Enabled = True
            End With

        Else
            ' rvs75 10/08/2010 : mise à jour de l'etat d'avancement des emissions
            For Each ctrEmission As Control In Panel_maintenant.Controls
                If TypeOf (ctrEmission) Is PaveActuellement Then
                    DirectCast(ctrEmission, PaveActuellement).Rafraichir()
                End If
            Next
            Trace.WriteLine(DateTime.Now & " " & "redemarrage de timer minute")

            With Timer_minute
                .Start()
                .Enabled = True
            End With

        End If
    End Sub

    Public Sub DeplacerPanelA()
        Dim deplacementTemps As TimeSpan
        Dim entier As Double
        Trace.WriteLine(DateTime.Now & " " & "passage dans deplacer panelA")

        deplacementTemps = MomentSouhaite.Subtract(DateReference)

        'rvs75 : 02/09/2010
        'Deplacement_temps peut être du type : 8:59:59:6544 au lieu de 9:00:00
        entier = Math.Round(deplacementTemps.TotalMinutes / 30)

        ' entier represente un nbre de tranche de 30 minutes
        ' entre moment souhaite et date de reference
        DeplacementPanelAEnPixels = CInt(entier * NbPixelsPour30Minutes)
        PanelA.Left = -DeplacementPanelAEnPixels + ZSplitButtonGauche.Right

        If DecalHoraire < 0 Then
            ' on doit deplacer panelA vers la gauche
            PanelA.Left += DecalHoraire * 2 * NbPixelsPour30Minutes
        End If

        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "panelA.left = " & PanelA.Left.ToString)

        PanelD.Left = -DeplacementPanelAEnPixels + ZSplitButtonGauche.Right
        If DecalHoraire > 0 Then
            PanelD.Left -= DecalHoraire * 2 * NbPixelsPour30Minutes
        End If

        PanelA.SendToBack()
    End Sub

    Private Sub ChercherDataEnMemoire()
        SuspendLayout()
        Timer_minute.Enabled = False
        DeplacerPanelA()
        Timer_minute.Enabled = True
    End Sub

    Private Sub AfficherDateOrigineEcran()

        Trace.WriteLine(DateTime.Now & " " & "Avant calcul date origine " & DateOrigineEcran.ToString)
        CentralScreen.CalculDateOrigineEcran()
        Trace.WriteLine(DateTime.Now & " " & "Apres calcul date origine " & DateOrigineEcran.ToString)
    End Sub

    Private Sub InitialisationTraceListener()
        Trace.Listeners.Clear()

        ' supprimer tous les listeners et en particulier celui de la fenetre de sortie a l écran
        Trace.Listeners.Add(Tl)
        Trace.AutoFlush = True

        ' écrire immédiatement (sans délai) dans le tl
    End Sub

    Private Sub CaracteristiquesEcranEtMainform()

        LargeurEcran = My.Computer.Screen.Bounds.Right - My.Computer.Screen.Bounds.Left
        'HauteurEcran = My.Computer.Screen.Bounds.Bottom - My.Computer.Screen.Bounds.Top
    End Sub

    Private Sub ReferencesTemps()
        Dim deplacementTemps As TimeSpan
        Dim entier As Double
        deplacementTemps = MomentSouhaite.Subtract(DateReference)
        entier = Math.Round(deplacementTemps.TotalMinutes / 30)
        ' entier represente un nbre de tranche de
        ' 30 minutes entre moment souhaite et date de reference
        DeplacementPanelAEnPixels = CInt(entier * NbPixelsPour30Minutes)
    End Sub

    Private Sub PremiereInitialisation()

        ' memorisation de listviewchannel.width pour recuperation future
        ListViewChannel.Width = LargeurLogoAdaptee + 30
        L3 = Calendar.Width
        L2 = ListViewChannel.Width
        ZSplitButton1.Left = 0
        ZSplitButtonGauche.Left = ZSplitButton1.Right + LargeurLogoAdaptee
    End Sub

    Private Sub DefinirHauteurButtonGaucheEtAutres()

        ZSplitButton1.Top = MenuStrip1.Bottom - MenuStrip1.Top + ToolStrip1.Bottom - ToolStrip1.Top
        Trace.WriteLine(DateTime.Now & " " & "boutonbas1 vaut 0")

        ' pour ne pas tronquer la partie superieure des logo tres grands comm bbc one ....
        Panel_glob_maintenant.Height = StatusStrip2.Location.Y - Panel_glob_maintenant.Location.Y

        ZSplitButton1.Height = StatusStrip2.Top - ZSplitButton1.Top
        ZSplitButtonGauche.Top = ZSplitButton1.Top
        ZSplitButtonGauche.Height = ZSplitButton1.Height
        ZSplitButtonDroit.Top = ZSplitButton1.Top
        ZSplitButtonDroit.Height = ZSplitButton1.Height
        Trace.WriteLine(DateTime.Now & " " & "sortie sub definir")
    End Sub

    Private Sub CreatePanelboxes()

        Trace.WriteLine(DateTime.Now & " " & "Entrée dans create panelboxes")
        If Size.Width > LargeurEcran Then
            Erreurh = Size.Width - LargeurEcran
        End If

        ListViewChannel.Visible = False

        SuspendLayout()
        HauteurPaves = CInt(HauteurRichtextbox * 0.8) + 5
        PeriodiciteVerticale = HauteurRichtextbox + EspaceEntreRichtextbox

        NbLignesCeSoir =
            (CInt(
                (Panel_glob_maintenant.Top - Panel_glob_ce_soir.Top - lbl_titre_maintenant.Height) / PeriodiciteVerticale)) -
            1

        With PanelB
            .Left = ZSplitButton1.Right
            .Top = ZSplitButtonGauche.Top + 22
            .Height = ZSplitButtonGauche.Height - 22
            .Width = LargeurLogoAdaptee
        End With

        With PanelD
            .Left = ZSplitButtonGauche.Right
            .Top = ZSplitButton1.Top
            .Height = 22
        End With

        With PanelE
            .Left = ZSplitButtonGauche.Right
            .Top = StatusStrip2.Top - HauteurPaves
            .Height = HauteurPaves
            .Width = Size.Width - Calendar.Width - LargeurBoutonsVerticaux - ZSplitButtonGauche.Right - Erreurh
        End With

        PanelE.Width = Size.Width - Calendar.Width - LargeurBoutonsVerticaux - ZSplitButtonGauche.Right - Erreurh
        If Bdpad Then
            PanelE.Width += Calendar.Width
        End If

        PanelA.Top = PanelB.Top

        PanelA.Width = 200 + (NbDePeriodesDe_6H * NbHeuresLigneTemps * 2 * NbPixelsPour30Minutes)
        PanelD.Width = PanelA.Width

        With Panel_date
            .Left = ZSplitButton1.Right
            .Width = ZSplitButtonGauche.Left - ZSplitButton1.Right
            .Top = ZSplitButtonGauche.Top
            .Height = PanelD.Height
        End With

        ' panel_droit créé en mode design
        With panel_droit
            .Width = Calendar.Width
            .Left = ZSplitButtonDroit.Right
        End With

        ' imposer que panel_droit est parent de calendar,panel_glob_maintenenant et panel_glob_ce_Soir
        Panel_glob_maintenant.Parent = panel_droit
        Panel_glob_ce_soir.Parent = panel_droit
        Calendar.Parent = panel_droit

        With Panel_glob_ce_soir.Controls
            .Add(lbl_Titre_Ce_Soir)
            .Add(Panel_ce_soir)
        End With

        With Panel_glob_maintenant.Controls
            .Add(lbl_titre_maintenant)
            .Add(Panel_maintenant)
        End With

        With lbl_Titre_Ce_Soir
            .Top = 0
            .Left = 0
        End With

        ' par rapport à panel_glob_ce_soir
        With lbl_Titre_Ce_Soir
            .Width = Calendar.Width
            .Height = PeriodiciteVerticale
        End With

        Trace.WriteLine(DateTime.Now & " " & "Panel_titre_ce_soir  top       left   width   height")
        Trace.WriteLine(
            DateTime.Now & " " & lbl_Titre_Ce_Soir.Top.ToString & "    " &
            lbl_Titre_Ce_Soir.Left.ToString & "    " & lbl_Titre_Ce_Soir.Width.ToString & "    " &
            lbl_Titre_Ce_Soir.Height.ToString)

        With Panel_ce_soir
            .Top = lbl_Titre_Ce_Soir.Bottom + EspaceEntreRichtextbox
            .Left = 0
            .Width = Calendar.Width
            .Height = NbEmissionsForCeSoir * PeriodiciteVerticale
        End With

        Trace.WriteLine(DateTime.Now & " " & "Panel_ce_soir  top     left     width     height")
        Trace.WriteLine(
            DateTime.Now & " " & Panel_ce_soir.Top.ToString & "    " & Panel_ce_soir.Left.ToString & "    " &
            Panel_ce_soir.Width.ToString & "    " & Panel_ce_soir.Height.ToString)

        With lbl_titre_maintenant
            .Top = 0
            .Left = 0
            .Width = Calendar.Width
            .Height = PeriodiciteVerticale
        End With

        Trace.WriteLine(DateTime.Now & " " & "Panel_titre_maintenant  top   left     width     height")
        Trace.WriteLine(
            DateTime.Now & " " & lbl_titre_maintenant.Top.ToString & "    " &
            lbl_titre_maintenant.Left.ToString & "    " & lbl_titre_maintenant.Width.ToString & "    " &
            lbl_titre_maintenant.Height.ToString)

        With Panel_maintenant
            .Top = lbl_titre_maintenant.Bottom + EspaceEntreRichtextbox
            .Left = 0
            .Width = Calendar.Width
            .Height = (NbEmissionsForMaintenant) * PeriodiciteVerticale
        End With

        Trace.WriteLine(DateTime.Now & " " & "Panel_maintenant top       left       width       height")
        Trace.WriteLine(
            DateTime.Now & " " & Panel_maintenant.Top.ToString & "    " & Panel_maintenant.Left.ToString &
            "    " & Panel_maintenant.Width.ToString & "    " & Panel_maintenant.Height.ToString)

        With Controls
            .Add(PanelA)
            .Add(PanelB)
            .Add(PanelD)
            .Add(PanelE)
        End With

        PanelB.Visible = True
        PanelA.Visible = True
        PanelD.Visible = True
        PanelE.Visible = True

        panel_droit.Visible = True

        PanelB.Enabled = True
        PanelA.Enabled = True
        PanelD.Enabled = True
        PanelE.Enabled = True

        Panel_ce_soir.Enabled = True
        Panel_maintenant.Enabled = True
        Calendar.Enabled = True
        lbl_Titre_Ce_Soir.Enabled = False
        lbl_titre_maintenant.Enabled = False

        PanelConteneurs()

        PanelD.Left = -DeplacementPanelAEnPixels + ZSplitButtonGauche.Right

        ' decalage horaire
        ' attention à ne pas decaler 2 x
        If DecalHoraire < 0 Then ' on ne doit pas decaler panelA 
        Else ' decal_horaire >0  on doit  decaler panelA vers la gauche
            PanelA.Left = -DeplacementPanelAEnPixels + ZSplitButtonGauche.Right -
                          (DecalHoraire * 2 * NbPixelsPour30Minutes)
            ' 040210
        End If

        PanelA.SendToBack()
        Trace.WriteLine(DateTime.Now & " " & "PanelA.height = " & PanelA.Height.ToString)
        ResumeLayout()
    End Sub

    Private Sub PanelConteneurs()

        ' Panel_droit est localisé comme suit dans mainform:
        ' top : 0
        ' calé a droite
        ' width :  calendar.width 
        ' height : hauteur_mainform
        ' cette defintion est faite precedemment dans crete_panelboxes

        ' localiser calendar dans panel_droit
        Calendar.Left = 0

        ' par rapport à panel_droit
        ' localiser panel_glob_ce_soir dans panel_droit
        With Panel_glob_ce_soir
            .Top = Calendar.Height
            .Left = 0
            .Width = Calendar.Width
        End With

        ' localiser panel_glob_maintenant dans panel_droit
        With Panel_glob_maintenant
            Panel_glob_maintenant.SendToBack()
            .Top = Panel_glob_ce_soir.Bottom
            .Left = 0
            .Width = Calendar.Width
        End With

        ' localiser panel_titre ce soir dans panel_glob_ce_soir
        With lbl_Titre_Ce_Soir
            .Left = 0
            .Top = 0
            .Width = Calendar.Width
            .Height = PeriodiciteVerticale
        End With

        ' localiser panel_ce soir dans panel_glob_ce_soir
        With Panel_ce_soir
            .Left = 0
            .Top = lbl_Titre_Ce_Soir.Bottom
            .Width = Calendar.Width
            .Height = Panel_glob_ce_soir.Height - lbl_Titre_Ce_Soir.Height
        End With

        ' localiser panel_titre_maintenant dans panel_glob_maintenant
        With lbl_titre_maintenant
            .Left = 0
            .Top = 0
            .Width = Calendar.Width
            .Height = PeriodiciteVerticale
        End With

        ' localiser panel_maintenant dans panel_glob_maintenant
        With Panel_maintenant
            .Left = 0
            .Top = lbl_titre_maintenant.Bottom
            .Width = Calendar.Width
            .Height = Panel_glob_maintenant.Height - lbl_titre_maintenant.Height
        End With
    End Sub

    Private Sub ConstantsWidestScreen()

        ' lorsque treeview1 et panelC et monthcalendar sont invisibles,
        ' alors panelA  (partie reservée aux émissions)  a sa valeur
        ' maximale en pixels et vaut (60*nb d heures)  minutes cette echelle
        ' doit etre invariable pendant toute l' execution du programme
        PanelAPointWidthMax = LargMaxPanelA(1)

        Echelle1 = PanelAPointWidthMax / (60 * NbHeuresLigneTemps)
        Trace.WriteLine(DateTime.Now & " " & "Périodicité verticale = " & PeriodiciteVerticale.ToString)
        LongueurLigneTemp = PanelAPointWidthMax
        NbPixelsPour30Minutes = CInt(LongueurLigneTemp / (2 * NbHeuresLigneTemps))
        Trace.WriteLine(DateTime.Now & " " & "Sortie de constants_widest_screen")
    End Sub

    Private Sub MyTextboxTemps_MousedoubleClick(sender As Object, e As MouseEventArgs)

        'Dim dt As DateTime = DateReference
        Dim minutes As Integer = CInt((DirectCast(sender, Ztextbox).Tag)) * 30
        DateTimeEmission = DateReference
        DateTimeEmission = DateTimeEmission.AddMinutes(CDbl(minutes))
        'MessageBox.Show(DateTimeEmission.ToString("dd:MM:yyyy HH:mm"))
        Using ra As New TVGuideMainForm(ObjRecherche.ParHoraire, DateTimeEmission)
            ra.ShowDialog()
        End Using

        'EmissionView.ShowDialog()
    End Sub

    Public Sub DessineLigneTemps()

        ' à appeler à chaque fois qu on a pousse sur un bouton de
        ' mofification de la fenêtre principale d'ecran
        ' ou quand le curseur veut depasser la fin d ecran
        Dim icount As Integer
        Dim pair As Integer
        Dim limit As Integer
        Trace.WriteLine(DateTime.Now & " " & "dessine ligne temps")

        ' Nb_heures_LigneTemps = 6 quand certaines listes sont cachées
        ' (monthcalendar, treeview1, panelC...)

        PanelD.SuspendLayout()
        PanelD.Controls.Clear()

        limit = (NbDePeriodesDe_6H * NbHeuresLigneTemps * 2)
        ' pour avoir les demies heures
        For icount = 0 To limit
            Dim myTextboxTemps As New Ztextbox
            AddHandler myTextboxTemps.MouseDoubleClick, AddressOf MyTextboxTemps_MousedoubleClick
            With myTextboxTemps
                .Location = New Point((NbPixelsPour30Minutes * icount), 0)
                .Width = CInt(NbPixelsPour30Minutes)
                '.Name = "TextTemp" & icount
                .Height = PanelD.Height - 1
                .BackColor = Color.White
                .Cursor = Cursors.Default
            End With
            pair = icount Mod 2
            Select Case pair
                Case 0
                    myTextboxTemps.Text =
                        (DateReference.AddHours(icount \ 2)).ToString("HH:00", CultureInfo.CurrentCulture)
                    Trace.Write(myTextboxTemps.Text & "   ")
                Case Else
                    myTextboxTemps.Text = ""
            End Select

            PanelD.Controls.Add(myTextboxTemps)
            ' Le panelD doit avoir la meme largeur que panelA et
            ' doit subir le meme decalage horizontal que panelA
        Next icount
        PanelD.Visible = True
        PanelD.ResumeLayout()
        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "Sortie dessine ligne temps")
    End Sub

    Private Sub PowerModeChangedeventHandler(ByVal sender As Object, ByVal e As PowerModeChangedEventArgs)
        ' 02/11/2017 rvs75 mise à jour en sortie de veille
        If e.Mode = PowerModes.Resume Then
            EveryMinute()
            CentralScreen.CurseurVertical()
        End If
    End Sub


    Private Sub EveryMinute()

        ' ne fait pas appel à curseur vertical
        ' toutes les minutes:  
        ' voir si la position du curseur verical est supérieure 
        ' à fin d affichage, rappel panelA.width est variable en 
        ' fonction de la valeur des 3 bits:button1 positionné à droite
        ' bouton gauche positionne à droite....
        ' toutes les minutes , réactualiser les émissions correspondant
        ' à Maintenant

        AffichageMaintenant()

        ' 19/09/2009 rvs75 code de mise à jour de ce soir
        ' après un  changement de jour
        ' 02/11/2017 rvs75 mise à jour automatique si le jour n'est pas le même
        ' plus d'obligation de passer par 00h00 (PC en veille)
        Static jour As Integer = -1
        If jour <> DateTime.Today.Day Then
            jour = DateTime.Today.Day
            AffichageCeSoir()
            MaJDateStatusBar()

        End If

        ' mets a jour maintenant mais pas titre_maintenant
        '02/11/2017 rvs75 code inutile
        'If WindowState = FormWindowState.Minimized Then
        '    Return
        'End If
    End Sub

    Private Sub ButtonsVerticauxResumé(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ZSplitButtonDroit.Click ', ZSplitButton1.Click ', ButtonGauche.Click

        ' remarque : une bouton positionné a droite est a true 
        ' il y a 3 boutons de poids =4 , 2 , 1 dans l'ordre pour 
        ' button1, buttongauche et buttondroit 
        ' b1    bg    bd
        ' 4      2     1 
        ' on mémorise, au 1er passage dans un des 3 boutons click verticaux: 
        ' les postions gauche de button1, buttongauche et buttondroit

        ' c est le deplacement à appliquer à panelA suite à l appui sur un
        ' bouton
        SuspendLayout()

        PanelB.Width = LargeurLogoAdaptee

        Bdpad = Not (Bdpad)

        If Size.Width > LargeurEcran Then
            Erreurh = Size.Width - LargeurEcran
        End If

        Trace.WriteLine(
            DateTime.Now & " " & "Click bouton nouvelle largeur utile = " &
            (ZSplitButtonDroit.Left - ZSplitButtonGauche.Right).ToString)

        AfficherDateOrigineEcran()
        CentralScreen.CurseurVertical()
        PositionneBoutonsMemorises()

        PanelA.SendToBack()

        PanelB.Select()
        ResumeLayout()
        Application.DoEvents()
    End Sub

    Private Sub TimerMinuteTick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_minute.Tick

        ' rvs75 6/12/2009 recalage du timer_minute sur la seconde "00" pour la minute suivante
        Dim secondeMaintenant As Integer = DateTime.Now.Second
        If secondeMaintenant > 1 Then
            Timer_minute.Interval = 60000 - secondeMaintenant * 1000
        Else
            Timer_minute.Interval = 60000
        End If

        ' fin modif recalage
        '**********************************************
        ' faut il afficher le panneau cinema?'03081
        '**********************************************

        ' Neutralier les tick pendant un tri suivant categorie
        ' pendant lequel stop_timer = true
        Trace.WriteLine(DateTime.Now & " interrupt 1 minute")
        If PanelA.Controls.Count <> 0 Then
            CentralScreen.CurseurVertical()
        End If
        EveryMinute()

        MyMemoireClean()

        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform Timer_Minute_Tick")
    End Sub

    Private Sub ChercherDataBasedonnees()
        Dim deplacementTemps As TimeSpan
        Dim entier As Integer
        Timer_minute.Enabled = False
        Trace.WriteLine(DateTime.Now & " " & "entree sub chercher_data_basedonnéees")
        deplacementTemps = MomentSouhaite.Subtract(DateReference)
        entier = 2 * (deplacementTemps.Days * 24 + deplacementTemps.Hours)
        DeplacementPanelAEnPixels = entier * NbPixelsPour30Minutes

        MomentSouhaite = DateReference

        PanelA.Left = -DeplacementPanelAEnPixels + ZSplitButtonGauche.Right

        If DecalHoraire < 0 Then ' 040210
            ' on doit deplacer panelA vers la gauche
            PanelA.Left += DecalHoraire * 2 * NbPixelsPour30Minutes
        Else ' decal_horaire >0
            ' on  doit  deplacer panelA 
        End If

        PanelD.Left = -DeplacementPanelAEnPixels + ZSplitButtonGauche.Right

        DepartAffichage = DateReference
        FinAffichage = DepartAffichage.AddHours(NbDePeriodesDe_6H * NbHeuresLigneTemps)
        DateOrigineEcran = DepartAffichage

        Build_Qwery_On_Channels_Where_and_Between()
        IndiceCourantTle = 1

        CentralScreen.GroupFonction1()
        CentralScreen.GroupFonction2()

        AfficherDateOrigineEcran()
        Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
        Timer_minute.Start()
        Timer_minute.Enabled = True
        Application.DoEvents()
        Trace.WriteLine(DateTime.Now & " " & "sortie sub chercher_data_basedonnéees")
    End Sub

    Public Sub ReloadData()
        Trace.WriteLine(DateTime.Now & " " & "Entree reload data")
        DateReference = DebutHeure(MomentSouhaite)
        ChercherDataBasedonnees()
        RecupererEmissionsMarquees()
        Trace.WriteLine(DateTime.Now & " " & "Sortie reload data")
        Application.DoEvents()
    End Sub

    Private Sub ToolStripMenuItemChaineHautClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuItemChaineHaut.Click

        Trace.WriteLine(DateTime.Now & " " & "ToolStripMenuItemChaineHaut ")

        Increment = 1

        If PanelA.Bottom < StatusStrip2.Top Then
            Exit Sub
        Else
            SuspendLayout()
            NumChaineHautEcran += 1
            Do While NbEmissionsYc0ApresTriParChaine(NumChaineHautEcran) = 0
                Increment += 1
                NumChaineHautEcran += 1
            Loop
            PanelA.Top -= (PeriodiciteVerticale) * (Increment)
            PanelB.Top -= (PeriodiciteVerticale) * (Increment)

            CentralScreen.CalculDateOrigineEcran()

            NomFichierLogo = TableauChaine(NumChaineHautEcran).Logo
            Trace.WriteLine(DateTime.Now & " " & "Logo name = " & NomFichierLogo.ToString)
            CentralScreen.CurseurVertical()
            PanelA.SendToBack()

            AfficherDateOrigineEcran()
            ResumeLayout()
            Return
        End If
    End Sub

    Private Sub ToolStripMenuItemChaineBasClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuItemChaineBas.Click
        Trace.WriteLine(DateTime.Now & " " & "ToolStripMenuItemChaineHautBas ")

        Select Case NumChaineHautEcran
            Case 1
                Return
            Case Else
                SuspendLayout()
                NumChaineHautEcran -= 1

                Do While NbEmissionsYc0ApresTriParChaine(NumChaineHautEcran) = 0
                    Increment += 1
                    NumChaineHautEcran -= 1
                Loop

                PanelA.Top += (PeriodiciteVerticale) * Increment
                PanelB.Top += (PeriodiciteVerticale) * Increment
                PanelA.SendToBack()

                CentralScreen.CalculDateOrigineEcran()

                NomFichierLogo = TableauChaine(NumChaineHautEcran).Logo
                Trace.WriteLine(DateTime.Now & " " & "Logo name = " & NomFichierLogo.ToString)
                CentralScreen.CurseurVertical()
                AfficherDateOrigineEcran()
                PanelA.SendToBack()
                ResumeLayout()
                Return
        End Select
    End Sub

    Private Sub PanelBMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PanelB.MouseWheel, PanelA.MouseWheel

        ' Si la roulette de la souris est en cours d'utilisation on n'affiche pas les ToolTips sur les émissions
        CentralScreen.MouseWheelInUse = True

        If TshEnCours Then
            ' eviter les click de molette repetitifs en scroll horizontal
            ' tsh_en_cours = traitement scroll horizontal en cours
            Return
        End If

        If Not ScrollHorizontal Then
            ' le scroll horizontal ne peut se faire (trop de chaines sélectionnées)
            ' on reste donc en scroll vertical

            Trace.WriteLine(DateTime.Now & " " & "PanelB_Mousewheel ")

            ' molette souris de l avant vers l arriere = var
            ' est  positif num_chaine_haut_ecran()
            Increment = 1

            ' ne pas donner le focus à PanelA et ne pas faire
            ' de scroll quand il y a peu d emissions dans ce soir
            ' et qu on fait un mousewheel dans panel_ce_soir
            Dim repere1 As Integer
            repere1 = ZSplitButtonDroit.Left
            If (Not Bdpad) AndAlso e.X > repere1 Then
                Panel_ce_soir.Focus()
                Return
            End If

            If e.Delta < 0 Then ' afficher des chaines de numero + eleve
                If PanelA.Bottom < StatusStrip2.Top - PanelE.Height Then
                    Return
                Else
                    SuspendLayout()
                    NumChaineHautEcran += 1
                    PanelA.Top -= (PeriodiciteVerticale) * (Increment)
                    PanelB.Top -= (PeriodiciteVerticale) * (Increment)

                    PanelA.SendToBack()
                    ResumeLayout()
                    Return
                End If

            Else ' e.delta est positif;afficher des chaines de numero moins elevé

                Select Case NumChaineHautEcran
                    Case 1
                        Return
                    Case Else
                        SuspendLayout()
                        NumChaineHautEcran -= 1

                        PanelA.Top += (PeriodiciteVerticale) * Increment
                        PanelB.Top += (PeriodiciteVerticale) * Increment
                        PanelA.SendToBack()

                        PanelA.SendToBack()
                        ResumeLayout()
                        Return
                End Select
            End If
        Else

            ' scroll horizontal est a true( le nbre de chaines selectionnées est suffisant
            ' a t on l accord de l utilisateur poiur faire du scroll horizontal
            If My.Settings.accordscrollhorizontal Then

                Dim tmpDate As New Date(MomentSouhaite.Year, MomentSouhaite.Month, MomentSouhaite.Day)
                Dim nombreheuresemission As Integer

                ' On va récupérer la configuration matérielle dans le fichier user.config et en fonction de la config
                ' Néo le 05/04/2014
                Select Case My.Settings.ConfHardware
                    Case 1
                        nombreheuresemission = 32
                    ' On charge 36 heures d'émissions
                    Case 2
                        nombreheuresemission = 26
                    ' On charge 30 heures d'émissions
                    Case 3
                        nombreheuresemission = 20
                        ' on charge 24 heures d'émissions
                End Select

                ' on a l accord , on fait du scroll horizontal
                TshEnCours = True
                ' lancer le timer 250 msec qui interdira tout scroll horizontal pdt 250 msec
                Timer_250msec.Start()
                Timer_250msec.Enabled = True

                If e.Delta < 0 Then ' on fait heure =heure +1

                    ' equivalent du bouton heure  +
                    Trace.WriteLine(DateTime.Now & " " & "MouseWheel H +1 ")

                    ' Néo le 05/04/2014
                    MomentSouhaite = MomentSouhaite.AddHours(1)
                    Dim differencespan As TimeSpan = (MomentSouhaite - DateTime.Now)
                    Dim difference As Integer = CType(differencespan.TotalHours, Integer)

                    Trace.WriteLine(DateTime.Now & " " & "differencespan: " & differencespan.ToString())
                    Trace.WriteLine(DateTime.Now & " " & "difference: " & difference)

                    If _
                        IncrementationSourisHorizontale <= nombreheuresemission AndAlso
                        difference <= nombreheuresemission Then

                        IncrementationSourisHorizontale += 1
                        IniCalendrier(MomentSouhaite)

                        If MomentSouhaite > LastDateWithData Then ' data souhaitee non existantes dans BDD

                            If tmpDate > LastDateWithData Then
                                Trace.WriteLine(DateTime.Now & " " & "Vous allez vers une zone vide de données")
                                MomentSouhaite = MomentSouhaite.AddHours(-24)
                                IniCalendrier(MomentSouhaite)
                                Return
                            Else
                                MomentSouhaite = tmpDate
                                IniCalendrier(MomentSouhaite)
                            End If
                        End If

                        'If MomentSouhaite > DateReference.AddHours(NbDePeriodesDe_6H * NbHeuresLigneTemps) Then
                        '    Trace.WriteLine(DateTime.Now & " " & "Début rechargement des data")
                        '    Timer_minute.Enabled = False
                        '    ReloadData()
                        '    Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                        '    Timer_minute.Start()
                        '    Timer_minute.Enabled = True
                        '    Trace.WriteLine(DateTime.Now & " " & "Fin rechargement des data")
                        '    Return
                        'End If

                        ' data souhaitees deja presentes en memoire
                        ChercherDataEnMemoire()
                    End If
                End If

                ' e.delta>0 then on fait heure=heure-1(scroll horizontal)
                If e.Delta > 1 Then

                    ' Néo le 05/04/2014
                    MomentSouhaite = MomentSouhaite.AddHours(-1)
                    Dim differencespan As TimeSpan = (MomentSouhaite - DateTime.Now)
                    Dim difference As Integer = CType(differencespan.TotalHours, Integer)

                    If _
                        IncrementationSourisHorizontale <= nombreheuresemission AndAlso
                        difference <= nombreheuresemission Then

                        IncrementationSourisHorizontale -= 1

                        ' equivalent du bouton heure -1
                        TshEnCours = True

                        Trace.WriteLine(DateTime.Now & " " & "MouseWheel H -1 ")
                        Trace.WriteLine(DateTime.Now & " " & "differencespan: " & differencespan.ToString())
                        Trace.WriteLine(DateTime.Now & " " & "difference: " & difference)

                        IniCalendrier(MomentSouhaite)

                        ' Néo le 05/02/2014
                        Dim currentDate As DateTime = DateTime.Now
                        Dim firstDateWithData As DateTime = New DateTime(currentDate.Year, currentDate.Month,
                                                                         currentDate.Day, currentDate.Hour, 0, 0)

                        If MomentSouhaite < firstDateWithData Then

                            IncrementationSourisHorizontale = 0

                            'Dim tmpDate As Date = firstDateWithData
                            'If tmpDate < firstDateWithData Then
                            '    Trace.WriteLine(DateTime.Now & " " & " vous allez vers une zone vide de donnéees")

                            '    MomentSouhaite = MomentSouhaite.AddHours(+1)
                            '    IniCalendrier(MomentSouhaite)
                            '    Return
                            'Else
                            MomentSouhaite = firstDateWithData
                            IniCalendrier(MomentSouhaite)
                            'End If
                        End If

                        If MomentSouhaite < DateReference Then
                            '    s = "debut de rechargement de data"
                            '    Trace.WriteLine(s)
                            '    MomentSouhaite = MomentSouhaite.AddHours(-3)
                            '    IniCalendrier(MomentSouhaite)

                            '    Timer_minute.Enabled = False
                            '    ReloadData()
                            '    s = "fin de rechargement de data"
                            '    Trace.WriteLine(s)
                            '    Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                            '    Timer_minute.Start()
                            '    Timer_minute.Enabled = True
                            '    DessineLigneTemps()
                            '    Return
                        End If

                        ChercherDataEnMemoire()
                        DessineLigneTemps()
                    End If
                End If
            End If
        End If
        ' fin du test sur l accord de scroll horizontal

        Timer_minute.Start()
        Timer_minute.Enabled = True
    End Sub

    Private Sub NavigationTemporelle(ByVal heure As Integer)

        BloquerBoutonCalendrier()

        With MomentSouhaite
            MomentSouhaite = DebutJournee(MomentSouhaite)
            MomentSouhaite = .AddHours(heure)
        End With

        Dim differencespan As TimeSpan = (MomentSouhaite - DateTime.Now)
        Dim difference As Integer = CType(differencespan.TotalHours, Integer)
        IncrementationSourisHorizontale = difference

        IniCalendrier(MomentSouhaite)

        If _
            DateEntre(MomentSouhaite, DateReference,
                      DateReference.AddHours(NbDePeriodesDe_6H * NbHeuresLigneTemps)) Then
            'data souhaitees deja presentes en memoire
            ChercherDataEnMemoire()
            DessineLigneTemps()

        Else
            Timer_minute.Enabled = False
            navigtemporelle.EnabledButton = False

            ReloadData()

            navigtemporelle.EnabledButton = True

            With Timer_minute
                .Start()
                .Enabled = True
            End With
        End If

        AutoriserBoutonCalendrier()
    End Sub

    Private Sub ToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuItem6H.Click,
                ToolStripMenuItem9H.Click,
                ToolStripMenuItem12H.Click,
                ToolStripMenuItem15H.Click,
                ToolStripMenuItem18H.Click,
                ToolStripMenuItem20H.Click,
                ToolStripMenuItem23H.Click,
                ToolStripMenuItemheure_plus.Click,
                ToolStripMenuItemheure_moins.Click,
                ToolStripMenuItemJour_Moins.Click,
                ToolStripMenuItemJour_Plus.Click,
                ToolStripMenuItemMaintenant.Click

        Trace.WriteLine(DateTime.Now & " " & "Entrée dans pavé click 6h, 9h, 12h, 15h, 20h, 23h")
        Trace.WriteLine(DateTime.Now & " " & "Nous somme le " & DateTime.Now.ToString)

        Dim heure As Integer
        If sender Is ToolStripMenuItem6H Then
            heure = 6
        ElseIf sender Is ToolStripMenuItem9H Then
            heure = 9
        ElseIf sender Is ToolStripMenuItem12H Then
            heure = 12
        ElseIf sender Is ToolStripMenuItem15H Then
            heure = 15
        ElseIf sender Is ToolStripMenuItem18H Then
            heure = 18
        ElseIf sender Is ToolStripMenuItem20H Then
            heure = 20
        ElseIf sender Is ToolStripMenuItem23H Then
            heure = 23
        ElseIf sender Is ToolStripMenuItemheure_plus Then
            If MomentSouhaite.Hour <> 23 Then
                heure = MomentSouhaite.AddHours(1).Hour
            Else
                heure = 24
                ' Apres 23 c'est 0 donc on force à 24 
            End If
        ElseIf sender Is ToolStripMenuItemheure_moins Then
            If MomentSouhaite.Hour <> 0 Then
                heure = MomentSouhaite.AddHours(-1).Hour
            Else
                heure = -1
                ' avant 0 c'est 23 donc on force à -1 
            End If
        ElseIf sender Is ToolStripMenuItemJour_Moins Then
            heure = -24 + MomentSouhaite.Hour
        ElseIf sender Is ToolStripMenuItemJour_Plus Then
            heure = 24 + MomentSouhaite.Hour
        ElseIf sender Is ToolStripMenuItemMaintenant Then
            MomentSouhaite = DateTime.Now
            heure = DateTime.Now.Hour
        End If

        Dim tmpDate As DateTime = DebutJournee(MomentSouhaite.AddHours(heure))

        If tmpDate > LastDateWithData OrElse tmpDate < FirstDateWithData Then
            MessageBox.Show(MessageBoxNoData, MessageBoxNoDataTitre, MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return
        Else
            NavigationTemporelle(heure)
        End If
    End Sub

    Private Sub NavigtemporelleButtonChanged(ByVal testbt As String) Handles navigtemporelle.ButtonChanged

        Dim heure As Integer
        Select Case testbt
            Case "btJourmoins"
                heure = -24 + MomentSouhaite.Hour
            Case "btHeuremoins"
                If MomentSouhaite.Hour <> 0 Then
                    heure = MomentSouhaite.AddHours(-1).Hour
                Else
                    heure = -1
                    ' avant 0 c'est 23 donc on force à -1 
                End If
            Case "bt06h"
                heure = 6
            Case "bt09h"
                heure = 9
            Case "bt12h"
                heure = 12
            Case "bt15h"
                heure = 15
            Case "bt18h"
                heure = 18
            Case "bt20h"
                heure = 20
            Case "bt23h"
                heure = 23
            Case "btMaintenant"
                MomentSouhaite = DateTime.Now
                heure = DateTime.Now.Hour
            Case "btHeureplus"
                If MomentSouhaite.Hour <> 23 Then
                    heure = MomentSouhaite.AddHours(1).Hour
                Else
                    heure = 24
                    ' Apres 23 c'est 0 donc on force à 24 
                End If
            Case "btJourplus"
                heure = 24 + MomentSouhaite.Hour
        End Select

        Dim tmpDate As DateTime = DebutJournee(MomentSouhaite.AddHours(heure))

        If tmpDate > LastDateWithData OrElse tmpDate < FirstDateWithData Then
            MessageBox.Show(MessageBoxNoData, MessageBoxNoDataTitre, MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return
        Else
            NavigationTemporelle(heure)

        End If
    End Sub

    Public Sub New()

        Dim sw As StreamWriter
        ' sub New est appellé AVANT Mainform_load
        InitializeComponent()

        Pathdefinition()
        AffecterCheminDll()

        ' Néo le 08/07/2014
        ProfileOptimization.SetProfileRoot(AppPath & "profiles")
        ProfileOptimization.StartProfile("profile")

        ' Néo 18/09/2010
        SetStyle(
            ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
            ControlStyles.OptimizedDoubleBuffer, True)

        _swStartTime.Start()

        'ShowInTaskbar = False

        ' 17/11/2010
        ' On patch la base de registre afin d'éviter les bugs des anciennes versions
        Dim rk As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\ZGuideTV Team")
        If rk IsNot Nothing Then
            My.Computer.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\ZGuideTV Team")
        End If

        Dim _
            rk1 As RegistryKey =
                Registry.LocalMachine.OpenSubKey(
                    "SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\ZGuideTVDotNet.exe")
        If rk1 IsNot Nothing Then
            My.Computer.Registry.LocalMachine.DeleteSubKeyTree(
                "SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\ZGuideTVDotNet.exe")
        End If

        ' Néo 08/09/2010
        ' On va rechercher l'ancien user.config si le num de version est différent
        With My.Settings
            If .CallUpgrade Then
                .Upgrade()

                ' Néo le 10/10/2012
                ' Durant une mise à jour de l'ancienne version de ZGuideTV.NET
                If _
                    [String].Equals(.RSSSound, "sound4.mp3", StringComparison.CurrentCulture) OrElse
                    [String].Equals(.MessagesSound, "sound7.mp3", StringComparison.CurrentCulture) OrElse
                    .ReminderSound = "sound6.mp3" Then
                    .RSSSound = "chimes.wav"
                    .MessagesSound = "notify.wav"
                    .ReminderSound = "tada.wav"

                    .RSSVolume = 9
                    .MessagesVolume = 8
                    .ReminderVolume = 7
                    .Save()
                End If
                .CallUpgrade = False
            End If

            If .ProxyPort = "1" OrElse .ProxyPort = "0" Then
                .ProxyPort = ""
            End If
            .Save()
        End With

        With My.Settings
            ' On redémarre zguidetv après une mise à jour (par défaut)
            .UserRestart = 1
            ' On redémarre zguidetv après des modifs dans les préférences
            .ModifPrefRestart = 0
            ' Base de donnée expirée false par défaut
            .DataBaseExpired = False
        End With

        ' Néo le 01/06/2011
        ' Si un fichier compressé traine dans le répertoire ProgramData on l'efface
        For Each foundFile As String In
            My.Computer.FileSystem.GetFiles(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) &
                "\ZGuideTVDotNet\", SearchOption.SearchTopLevelOnly, "*.zip", "*.7z",
                "*.rar", "*.xml")
            File.Delete(foundFile)
        Next

        CheminFichierLog = LogPath & "ZGuideTVDotNet.exe.log"
        sw = New StreamWriter(CheminFichierLog, False)
        ' sw = New StreamWriter(chemin_fichier_log, True)
        ' true veut dire en mode append 
        ' false pour ne pas re ecrire a la fin du fichier precedent mais bien écraser
        Tl = New TextWriterTraceListener(sw)

        Select Case My.Settings.tracelog
            Case True
                InitialisationTraceListener()
        End Select

        Dim maVersion As Version = Assembly.GetExecutingAssembly.GetName.Version
        Trace.WriteLine(DateTime.Now & " " & "Démarrage du programme...")
        Trace.WriteLine(
            DateTime.Now & " " & "Système d'exploitation : " & My.Computer.Info.OSFullName &
            " " & My.Computer.Info.OSVersion & Date.Now().ToString("yyyy-MM-dd HH:mm:ss"))
        Trace.WriteLine(DateTime.Now & " " & "Version de ZGuideTV.NET : " & maVersion.ToString)
        Trace.WriteLine(
            DateTime.Now & " " & "Date de compilation de ZGuideTV.NET : " &
            File.GetLastWriteTime(AppPath & "ZGuideTVDotNet.exe"))
        Trace.WriteLine(DateTime.Now & " " & "Chemin vers ZGuideTV.NET : " & Application.StartupPath)

        ' Néo le 08/09/2010
        ' On sélectionne la langue
        With My.Settings
            If .firststart Then
                My.Settings.GestionCategorie = True
                Timer_minute.Enabled = False
                Trace.WriteLine(DateTime.Now & " " & "C'est le 1er démarrage on sélectionne la langue")
                SelectLanguage.ShowDialog()
                Trace.WriteLine(DateTime.Now & " " & "C'est le 1er démarrage on affiche frmPremierDemarrage")
                PremierDemarrage.ShowDialog()
                My.Settings.buttonsstate = 0
                .firststart = False
                Timer_minute.Enabled = True
                .Save()
            End If
        End With

        'rvs75 09/07/2014 : creation de la base categorie si besoin
        If Not My.Computer.FileSystem.FileExists(BddPath & "Categorie.db3") Then
            CreateCategorieDataBase()
            InitColor()
            If My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") Then
                InitCategorie()
            End If
        End If

        ' Si la bdd < ou = 5 Ko on l'efface (en fait elle est vide !!!!!)
        Dim fichierInfo As New FileInfo(BddPath & "db_progs.db3")
        If My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") Then
            Dim tailleFichier As Integer = CInt(fichierInfo.Length)
            tailleFichier = CInt(tailleFichier)
            If tailleFichier = 6000 OrElse tailleFichier < 6000 Then
                File.Delete(BddPath & "db_progs.db3")
            End If
        End If

        ' La dernière mise à jour manuelle s'est mal passée si à 1
        With My.Computer.FileSystem
            If My.Settings.FichierCorrompu = 1 Then

                Trace.WriteLine(DateTime.Now & " " & "La bdd était corrompue lors de la dernière mise à jour manuelle")

                If _
                    .FileExists(BddPath & "db_progs.bak") AndAlso
                    .FileExists(ChannelSetPath & "ZGuideTVDotNet.channels.bak") Then

                    ' On récupère les sauvegardes effectuées si elles existent
                    Dim _
                        configZGuideTv As Configuration =
                            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)

                    File.Copy(BddPath & "db_progs.bak", BddPath & "db_progs.db3", True)
                    'File.Copy(BddPath & "Categorie.bak", BddPath & "Categorie.db3", True)


                    Dim fiChannels As New FileInfo(ChannelSetPath & "ZGuideTVDotNet.channels.bak")
                    If fiChannels.Exists Then
                        fiChannels.CopyTo(ChannelSetPath & "ZGuideTVDotNet.channels.set", True)
                    End If
                    'If File.Exists(ChannelSetPath & "ZGuideTVDotNet.channels.bak") Then
                    '    File.Copy(ChannelSetPath & "ZGuideTVDotNet.channels.bak",
                    '              ChannelSetPath & "ZGuideTVDotNet.channels.set", True)

                    'End If

                    ' Néo le 23/09/2010
                    Dim fiUrl As New FileInfo(UrlPath & "ZGuideTVDotNet.url.bak")
                    If fiUrl.Exists Then
                        fiUrl.CopyTo(UrlPath & "ZGuideTVDotNet.url.set", True)
                    End If
                    'If File.Exists(UrlPath & "ZGuideTVDotNet.url.bak") Then
                    '    File.Copy(UrlPath & "ZGuideTVDotNet.url.bak",
                    '              UrlPath & "ZGuideTVDotNet.url.set", True)
                    'End If

                    Dim fiConfig As New FileInfo(configZGuideTv.FilePath & ".bak")
                    If fiConfig.Exists Then
                        fiConfig.CopyTo(configZGuideTv.FilePath, True)
                    End If
                    'If File.Exists(configZGuideTv.FilePath & ".bak") Then
                    '    File.Copy(configZGuideTv.FilePath & ".bak", configZGuideTv.FilePath, True)
                    'End If

                    ' Néo le 25/05/2013
                    'If Directory.Exists(LogosPath) Then

                    '    ' on efface les anciens logos si ils sont présents
                    '    If Not Directory.GetDirectories(LogosPath) Is Nothing Then
                    '        For Each myLogo As String In Directory.GetFiles(LogosPath, "*.gif")
                    '            File.Delete(myLogo)
                    '        Next
                    '        For Each myLogo As String In Directory.GetFiles(LogosPath, "*.jpg")
                    '            File.Delete(myLogo)
                    '        Next

                    '        ' On renome les logos restaurés
                    '        Dim filename As String
                    '        For Each myLogo As String In Directory.GetFiles(LogosPath, "*.gik")
                    '            filename = Strings.Left(myLogo, myLogo.Length - 4)
                    '            File.Move(myLogo, filename)
                    '        Next

                    '        For Each myLogo As String In Directory.GetFiles(LogosPath, "*.jpk")
                    '            filename = Strings.Left(myLogo, myLogo.Length - 4)
                    '            File.Move(myLogo, filename)
                    '        Next
                    '    End If
                    'End If

                    Trace.WriteLine(
                        DateTime.Now & " " &
                        "On vient de récupérer une sauvegarde de la bdd, ZGuideTVDotNet.channels.set et le user.config après une mise à jour manuelle")
                    With My.Settings
                        .Reload()
                        .FichierCorrompu = 0
                    End With
                Else

                    ' sinon on efface les fichiers et on réaffiche frmmiseajour
                    If .FileExists(BddPath & "db_progs.db3") Then
                        File.Delete(BddPath & "db_progs.db3")
                    End If

                    If .FileExists(BddPath & "Categorie.db3") Then
                        File.Delete(BddPath & "Categorie.db3")
                    End If

                    If .FileExists(ChannelSetPath & "ZGuideTVDotNet.channels.set") Then
                        File.Delete(ChannelSetPath & "ZGuideTVDotNet.channels.set")
                    End If
                    Trace.WriteLine(DateTime.Now & " " & "On vient d'effacer une bdd corrompue et le channel.set")
                    With My.Settings
                        .BddExists = False
                        .FichierCorrompu = 0
                    End With
                End If
            End If
        End With

        ' Néo le 05/04/2011
        ' Par sécurité, si le fichier ZGuideTVDotNet.url.set n'existe pas dans UrlPath on le copie 
        If Not File.Exists(UrlPath & "ZGuideTVDotNet.url.set") Then
            File.Copy(AppPath & "ZGuideTVDotNet.url.set", UrlPath & "ZGuideTVDotNet.url.set", True)
        End If

        EmissionDurationMaintenant = My.Settings.dureemaintenant
        EmissionDurationCesoir = My.Settings.dureecesoir
        Timer_minute.Enabled = False


        AddHandler SystemEvents.PowerModeChanged, AddressOf PowerModeChangedeventHandler

        ' Néo le 22/09/2010
        ' On crée un thread pour l'affichage du SplashScreen
        Dim splashthread As Thread = New Thread(AddressOf SplashScreenClass.ShowSplashScreen)
        With splashthread
            .IsBackground = True
            .Start()
        End With
    End Sub

    ' ReSharper disable once UnusedMethodReturnValue.Local
    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    Private Sub RestoreWindow()

        With Me
            .Opacity = 0
            .Show()
            NotifyIcon1.Visible = False
            .WindowState = FormWindowState.Maximized
            Application.DoEvents()
            .Opacity = 100
        End With

        ' On fait passer le mainform en foreground (remplace l'ancien focus et activate)
        Dim hWnd As IntPtr = Handle
        SetForegroundWindow(hWnd)
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As Object, ByVal e As EventArgs) _
        Handles NotifyIcon1.BalloonTipClicked

        'On affiche plus le message dans le systray 26/07/2010
        My.Settings.NotifyIconShow = False
    End Sub

    Private Sub MainformPaint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint

        Trace.WriteLine(DateTime.Now & " " & "On entre dans Mainform_paint")

        'Néo le 29/05/2010
        If My.Settings.DataBaseExpired Then
            If My.Settings.DIRChecked = False Then
                Miseajour.ButtonDemarrer.PerformClick()
            End If
        End If

        Trace.WriteLine(DateTime.Now & " " & "On sort du Mainform_paint")
    End Sub

    Private Sub MainformResize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize

        If Me.IsHandleCreated Then
            Trace.WriteLine(" ")
            Trace.WriteLine(DateTime.Now & " entrée dans mainform resize ")
            Trace.WriteLine(DateTime.Now & " me.size.width = " & Size.Width.ToString)
            Trace.WriteLine(DateTime.Now & " me.size.height= " & Size.Height.ToString)
            Try
                Trace.WriteLine(DateTime.Now & " buttondroit.right= " & ZSplitButtonDroit.Right.ToString)
                Trace.WriteLine(DateTime.Now & " panel_droit.left= " & panel_droit.Left.ToString)
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            Select Case WindowState
                Case FormWindowState.Minimized

                    MyMemoireClean()

                    If My.Settings.Systray Then
                        NotifyIcon1.Visible = True

                        ' Modif le 08/12/2013 Néo
                        If My.Settings.NotifyIconShow Then
                            With NotifyIcon1
                                .BalloonTipTitle = "ZGuideTV.NET"
                                .BalloonTipText =
                                    BalloonText1 &
                                    Chr(13) & Chr(13) & BalloonText3
                                .BalloonTipIcon = ToolTipIcon.Info
                                .ShowBalloonTip(2000)
                                .Text = "ZGuideTV.NET"
                            End With
                        End If
                        Hide()
                    End If

            End Select

            Trace.WriteLine(DateTime.Now & " sortie de mainform resize apres modif de buttondroit.left")
            Trace.WriteLine(DateTime.Now & " me.size.width=" & Size.Width.ToString)
            Trace.WriteLine(DateTime.Now & " me.size.height=" & Size.Height.ToString)
            Trace.WriteLine(DateTime.Now & " buttondroit.right=" & ZSplitButtonDroit.Right.ToString)


            Trace.WriteLine(DateTime.Now & " panel_droit.left= " & panel_droit.Left.ToString)

            Calendar.Top = 0

            ' on reduit la haut. de panel_glob_ce_soir pour continuer
            ' a voir panel_glob_maintenant lors de la reduction
            ' de hauteur de mainform lors du resize
            Panel_glob_ce_soir.Height =
                CInt(
                    (DisplayRectangle.Height - ToolStrip1.Height - MenuStrip1.Height - StatusStrip2.Height -
                     Calendar.Height) \ 2)
            Panel_glob_maintenant.Top = Panel_glob_ce_soir.Bottom
            'rvs75 12/08/2010 les panel ont maintenant la même taille + remise du top des panels au niveau des bottoms des titres  
            Panel_glob_maintenant.Height = Panel_glob_ce_soir.Height
            Panel_ce_soir.Top = lbl_Titre_Ce_Soir.Bottom
            Panel_maintenant.Top = lbl_titre_maintenant.Bottom
            PositionneBoutonsMemorises()
            SuspendLayout()

            With PanelE
                .Left = ZSplitButtonGauche.Right
                .Top = StatusStrip2.Top - HauteurPaves
                .Height = HauteurPaves
                .Width = ZSplitButtonDroit.Left - ZSplitButtonGauche.Right
            End With

            Trace.WriteLine(DateTime.Now & " " & "fin de mainform_resize, apres dimensionner 12 paves")
            ResumeLayout()
        End If
    End Sub

    Private Sub RestaurerClick(ByVal sender As Object, ByVal e As EventArgs) Handles Restaurer.Click

        NotifyIcon1.Visible = False
        Application.DoEvents()
        RestoreWindow()
    End Sub

    Private Sub PanelGlobCeSoirMouseWheel1(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles Panel_glob_ce_soir.MouseWheel

        'dectetion du sens du scroll
        'si descente
        If e.Delta > 0 Then
            ' si le top du panel des émissions est inferieure au bottom du panel du titre
            If Panel_ce_soir.Top < lbl_Titre_Ce_Soir.Bottom Then
                'on descend le top 
                Panel_ce_soir.Top += PeriodiciteVerticale
            End If
            'si montée
        Else
            'si le bas des emission  du panel est superieur au bas du panel global
            If Panel_ce_soir.Top + (NbEmissionsForCeSoir * PeriodiciteVerticale) > Panel_glob_ce_soir.Height Then
                'On monte le top
                Panel_ce_soir.Top -= PeriodiciteVerticale
            End If
        End If
    End Sub

    Private Sub PanelGlobMaintenantMouseWheel1(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles Panel_glob_maintenant.MouseWheel

        'dectetion du sens du scroll
        'si descente
        If e.Delta > 0 Then
            ' si le top du panel des émissions est inferieure au bottom du panel du titre
            If Panel_maintenant.Top < lbl_titre_maintenant.Bottom Then
                'on descend le top 
                Panel_maintenant.Top += PeriodiciteVerticale
            End If
            'si montée
        Else
            'si le bas des emission dans le panel est superieur au bas du panel global
            If Panel_maintenant.Top + (NbEmissionsForMaintenant * PeriodiciteVerticale) > Panel_glob_maintenant.Height _
                Then
                'On monte le top
                Panel_maintenant.Top -= PeriodiciteVerticale
            End If
        End If
    End Sub

    Private Sub ToolStripButton7Click(ByVal sender As Object, ByVal e As EventArgs) Handles miseajourdeschaines.Click
        Miseajour.Show()
    End Sub

    Private Sub ToujoursenavantplanClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles toujoursenavantplan.Click

        Select Case TopMost
            Case False
                TopMost = True
            Case Else
                TopMost = False
        End Select
    End Sub

    Private Sub MainformFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        _mutex.Close()

        Dim i As Double
        Dim oldVal As Double

        Trace.WriteLine(DateTime.Now & " On entre dans Mainform_FormClosing")

        'rvs 18/06/2010 : 
        'test pour éviter l'erreur "Impossible d'appeler Invoke ou BeginInvoke sur un contrôle tant que le handle de fenêtre n'a pas été créé" à la fermeture
        Timer_minute.Stop()
        Timer_250msec.Stop()
        Timer_wait.Stop()
        Timer_seconde.Stop()
        TimerUsageMemory.Stop()
        Timer_heure.Stop()
        'fin test

        ' on va écrire les dimensions et la position
        ' de la fenêtre principale
        With My.Settings
            .WindowSizeMain = Size
            .WindowLocationMain = Location
        End With

        ' on va écrire la position des buttons
        My.Settings.buttonsstate = DirectCast(IIf(Bdpad, 1, 0), Integer)

        ' On regarde si l'effet 'FadeOut est activé dasn les préférences
        Select Case My.Settings.FadeOut
            Case 1

                oldVal = Opacity
                For i = oldVal To 0 Step -0.05
                    Opacity = i
                    Application.DoEvents()
                    Thread.Sleep(25)
                Next i
        End Select

        ' Si la bdd est < ou = 5 Ko on l'efface 
        Dim fichierInfo As FileInfo = New FileInfo(BddPath & "db_progs.db3")
        Dim tailleBdd As Integer = CInt(fichierInfo.Length)
        If tailleBdd = 6000 OrElse tailleBdd < 6000 Then
            File.Delete(BddPath & "db_progs.db3")
        End If

        My.Settings.Save()
        MyMemoireClean()

        Trace.WriteLine(DateTime.Now & " On ferme ZGuideTV.NET...")
        Tl.Close()
    End Sub

    Private Sub PanelAMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PanelA.MouseMove

        Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform panelA_MouseMove")

        If ToolStripTextBoxRecherche.Text <> LngToolStripTextBoxRecherche Then
            RechercheTextBoxToolStrip()
        End If

        PanelB.Select()
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform panelA_MouseMove")
    End Sub

    Private Sub Pathdefinition()

        AppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) &
                  "\ZGuideTVDotNet\"
        AppPath = Application.ExecutablePath
        AppPath = AppPath.Remove(AppPath.LastIndexOf(Chr(92)) + 1)
        LogosPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) &
                    "\ZGuideTVDotNet\Logos\"

        BddPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) &
                  "\ZGuideTVDotNet\DataBase\"
        SettingsPath = AppData
        TempPath = AppData
        'UnZipPath = AppPath & "7z.exe"
        LogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) &
                  "\ZGuideTVDotNet\Log\"
        UrlPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) &
                  "\ZGuideTVDotNet\Url\"
        ChannelSetPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) &
                         "\ZGuideTVDotNet\Channels\"
        MarqueesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) &
                       "\ZGuideTVDotNet\Marked\"
        Wavepath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) &
                   "\ZGuideTVDotNet\resources\"
        AutoCompletePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) &
                           "\ZGuideTVDotNet\AutoComplete\"

        Try
            If Not Directory.Exists(AppData) Then
                Directory.CreateDirectory(AppData)
            End If
            If Not Directory.Exists(LogosPath) Then
                Directory.CreateDirectory(LogosPath)
            End If
            If Not Directory.Exists(BddPath) Then
                Directory.CreateDirectory(BddPath)
            End If
            If Not Directory.Exists(SettingsPath) Then
                Directory.CreateDirectory(TempPath)
            End If
            If Not Directory.Exists(LogPath) Then
                Directory.CreateDirectory(LogPath)
            End If
            If Not Directory.Exists(UrlPath) Then
                Directory.CreateDirectory(UrlPath)
            End If
            If Not Directory.Exists(ChannelSetPath) Then
                Directory.CreateDirectory(ChannelSetPath)
            End If
            If Not Directory.Exists(MarqueesPath) Then
                Directory.CreateDirectory(MarqueesPath)
            End If
            If Not Directory.Exists(AutoCompletePath) Then
                Directory.CreateDirectory(AutoCompletePath)
            End If

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try
    End Sub

    Private Sub MiseajourchainesClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripUpdate.Click

        Try
            Miseajour.Show()
        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub AddModifyLogoClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripLogos.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ReorgChannel.ShowDialog()
    End Sub

    Private Sub PreferencesClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripPreferences.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Timer_minute.Enabled = False
        Pref.ShowDialog()
    End Sub

    Private Sub AvantplanClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripOntop.Click

        ToolStripMenuEditOntop.PerformClick()
    End Sub

    Private Sub DualMonitorClick1(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripDualMonitor.Click

        DualMonitor()
    End Sub

    Private Sub DualMonitor()

        Try
            Dim myScreens() As Screen = Screen.AllScreens

            With myScreens
                If .Length >= 2 AndAlso My.Settings.dualmonitor = 1 Then
                    Dualmonitor2()
                    Return
                End If
                If .Length >= 2 AndAlso My.Settings.dualmonitor = 2 Then
                    Dualmonitor1()
                    Return
                End If
            End With

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur DualMonitor...")
        End Try
    End Sub

    Private Sub Dualmonitor1()
        Try
            Dim screen As Screen

            WindowState = FormWindowState.Normal
            screen = Screen.AllScreens(0)

            StartPosition = FormStartPosition.Manual

            Location = screen.Bounds.Location

            WindowState = FormWindowState.Maximized
            Show()
            My.Settings.dualmonitor = 1

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            Trace.WriteLine(DateTime.Now & " " & "On vient de basculer vers le moniteur 1...")
        End Try
    End Sub

    Private Sub Dualmonitor2()
        Try
            Dim screen As Screen

            WindowState = FormWindowState.Normal
            screen = Screen.AllScreens(1)

            StartPosition = FormStartPosition.Manual

            Location = screen.Bounds.Location

            WindowState = FormWindowState.Maximized
            Show()
            My.Settings.dualmonitor = 2

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            Trace.WriteLine(DateTime.Now & " " & "On vient de basculer vers le moniteur 2...")
        End Try
    End Sub

    Private Sub ToolStripSaveClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripSave.Click

        ToolStripMenuFileSave.PerformClick()
    End Sub

    Private Sub ToolStripButton2Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripAbout.Click

        About.ShowDialog()
    End Sub

    Private Sub ToolStripButton8Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripForum.Click

        Try

            ' Modifié par Néo le 26/08/2009
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.zguidetv.net/") Then
                Process.Start("http://www.zguidetv.net/")

            Else
                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internat de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripButton9Click1(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripWebsite.Click

        Try

            ' Modifié par Néo le 26/08/2009
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://github.com/") Then

                If [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                    Process.Start("https://github.com/neojudgment/ZGuideTVDotNet/blob/master/Docs/READMEFR.md")
                Else
                    Process.Start("https://github.com/neojudgment/ZGuideTVDotNet")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripButton10Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripLangue.Click

        SelectLanguage.ShowDialog()
    End Sub

    Public Sub IniCalendrier(ByVal nvDate As Date)

        Try
            If ((Not nvDate.ToString Is Nothing AndAlso String.IsNullOrEmpty(nvDate.ToString))) Then
                nvDate = Date.Now
            End If

            'DDateSelection = nvDate
            'GDate = DDateSelection
            GDate = nvDate
            JourActif.DateActif = GDate

            Dim nameofMonth() As String = {NameofMonth1, NameofMonth2, NameofMonth3, NameofMonth4, NameofMonth5,
                                           NameofMonth6, NameofMonth7, NameofMonth8, NameofMonth9, NameofMonth10,
                                           NameofMonth11, NameofMonth12}
            Dim sMois As String

            sMois = nameofMonth((GDate.Month - 1))

            Dim sAnnée As String = GDate.Year.ToString()

            ' Dim dDate As Date

            Dim i As Integer
            Dim nPremierJour As Integer
            Dim nLigne As Integer
            Dim nColonne As Integer

            L_MOIS_ANNEE.Text = sMois & " " & sAnnée

            nPremierJour = GDate.AddDays(-GDate.Day + 1).DayOfWeek
            With JourActif
                .NumPremierJour = nPremierJour
                .NumMois = GDate.Month
                .An = GDate.Year
            End With

            ' 18/09/2009 rvs75 ajout du style old_ui depuis .config
            ' +  reprise des du text du visible et du font du contrôle

            Dim ctrTest As Control
            Dim cpTest As Calendrierpavé
            For Each ctrTest In Calendar.Controls
                If TypeOf (ctrTest) Is Calendrierpavé Then
                    cpTest = CType(ctrTest, Calendrierpavé)
                    'cpTest.OldUi = CBool(My.Settings.oldUI)
                    cpTest.Text = ""
                    cpTest.Visible = True
                    cpTest.Font = New Font(cpTest.Font, 0)
                End If
            Next ctrTest

            Dim joursdanslemois As Integer = Date.DaysInMonth(GDate.Year, GDate.Month)
            'For i = 1 To 31
            For i = 1 To joursdanslemois
                ' Calcul de la ligne et de la colonne du lien
                nLigne = ((i + nPremierJour) Mod 7) - 1
                nColonne = ((i + nPremierJour) \ 7) + 1

                If nPremierJour = 0 Then
                    nColonne += 1
                End If

                If nLigne = 0 Then
                    nLigne = 7
                    nColonne -= 1
                ElseIf nLigne = -1 Then
                    nLigne = 6
                    nColonne -= 1
                End If

                ' Change le libellé du lien
                Dim _
                    bouton As Calendrierpavé =
                        DirectCast(Calendar.Controls.Find("Button" & nColonne & "_" & nLigne, False)(0),
                                   Calendrierpavé)

                bouton.Text = i.ToString

                If JourActif.Présent(i, GDate.Month, GDate.Year) Then
                    If JourActif.BJourAffiché(i) Then
                        bouton.Font = New Font(bouton.Font, FontStyle.Bold)
                        bouton.BgColor = Color.FromArgb(219, 77, 72)

                    Else
                        bouton.Font = New Font(bouton.Font, FontStyle.Bold)
                        bouton.BgColor = Color.FromArgb(72, 181, 130)
                    End If

                Else
                    bouton.Font = New Font(bouton.Font, 0)
                    bouton.BgColor = Color.FromArgb(72, 128, 182)

                End If
            Next i

            For Each c As Control In Calendar.Controls
                If String.IsNullOrEmpty(c.Text) Then
                    c.Visible = False
                End If
            Next

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try
    End Sub

    Private Sub MoisSClick(ByVal sender As Object, ByVal e As EventArgs) Handles lblMoisS.Click
        IniCalendrier(GDate.AddMonths(1))
    End Sub

    Private Sub MoisPClick(ByVal sender As Object, ByVal e As EventArgs) Handles lblMoisP.Click
        IniCalendrier(GDate.AddMonths(-1))
    End Sub

    Private Sub Button1_1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1_1.Click
        JourActif.ChangeJour(1)
    End Sub

    Private Sub Button1_2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1_2.Click
        JourActif.ChangeJour(2)
    End Sub

    Private Sub Button1_3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1_3.Click
        JourActif.ChangeJour(3)
    End Sub

    Private Sub Button1_4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1_4.Click
        JourActif.ChangeJour(4)
    End Sub

    Private Sub Button1_5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1_5.Click
        JourActif.ChangeJour(5)
    End Sub

    Private Sub Button1_6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1_6.Click
        JourActif.ChangeJour(6)
    End Sub

    Private Sub Button1_7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1_7.Click
        JourActif.ChangeJour(7)
    End Sub

    Private Sub Button2_1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2_1.Click
        JourActif.ChangeJour(8)
    End Sub

    Private Sub Button2_2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2_2.Click
        JourActif.ChangeJour(9)
    End Sub

    Private Sub Button2_3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2_3.Click
        JourActif.ChangeJour(10)
    End Sub

    Private Sub Button2_4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2_4.Click
        JourActif.ChangeJour(11)
    End Sub

    Private Sub Button2_5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2_5.Click
        JourActif.ChangeJour(12)
    End Sub

    Private Sub Button2_6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2_6.Click
        JourActif.ChangeJour(13)
    End Sub

    Private Sub Button2_7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2_7.Click
        JourActif.ChangeJour(14)
    End Sub

    Private Sub Button3_1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3_1.Click
        JourActif.ChangeJour(15)
    End Sub

    Private Sub Button3_2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3_2.Click
        JourActif.ChangeJour(16)
    End Sub

    Private Sub Button3_3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3_3.Click
        JourActif.ChangeJour(17)
    End Sub

    Private Sub Button3_4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3_4.Click
        JourActif.ChangeJour(18)
    End Sub

    Private Sub Button3_5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3_5.Click
        JourActif.ChangeJour(19)
    End Sub

    Private Sub Button3_6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3_6.Click
        JourActif.ChangeJour(20)
    End Sub

    Private Sub Button3_7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3_7.Click
        JourActif.ChangeJour(21)
    End Sub

    Private Sub Button4_1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4_1.Click
        JourActif.ChangeJour(22)
    End Sub

    Private Sub Button4_2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4_2.Click
        JourActif.ChangeJour(23)
    End Sub

    Private Sub Button4_3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4_3.Click
        JourActif.ChangeJour(24)
    End Sub

    Private Sub Button4_4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4_4.Click
        JourActif.ChangeJour(25)
    End Sub

    Private Sub Button4_5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4_5.Click
        JourActif.ChangeJour(26)
    End Sub

    Private Sub Button4_6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4_6.Click
        JourActif.ChangeJour(27)
    End Sub

    Private Sub Button4_7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4_7.Click
        JourActif.ChangeJour(28)
    End Sub

    Private Sub Button5_1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5_1.Click
        JourActif.ChangeJour(29)
    End Sub

    Private Sub Button5_2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5_2.Click
        JourActif.ChangeJour(30)
    End Sub

    'Néo 28/11/2010 2 fois le même bouton 5_2   
    Private Sub Button5_3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5_3.Click
        JourActif.ChangeJour(31)
    End Sub

    Private Sub Button5_4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5_4.Click
        JourActif.ChangeJour(32)
    End Sub

    Private Sub Button5_5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5_5.Click
        JourActif.ChangeJour(33)
    End Sub

    Private Sub Button5_6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5_6.Click
        JourActif.ChangeJour(34)
    End Sub

    Private Sub Button5_7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5_7.Click
        JourActif.ChangeJour(35)
    End Sub

    Private Sub Button6_1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6_1.Click
        JourActif.ChangeJour(36)
    End Sub

    Private Sub Button6_2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6_2.Click
        JourActif.ChangeJour(37)
    End Sub

    Private Sub Button6_3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6_3.Click
        JourActif.ChangeJour(38)
    End Sub

    Private Sub Button6_4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6_4.Click
        JourActif.ChangeJour(39)
    End Sub

    Private Sub Button6_5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6_5.Click
        JourActif.ChangeJour(40)
    End Sub

    Private Sub Button6_6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6_6.Click
        JourActif.ChangeJour(41)
    End Sub

    Private Sub Button6_7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6_7.Click
        JourActif.ChangeJour(42)
    End Sub

    Private Sub SommaireDeLaideToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpHelptopics.Click

        ToolStripHelptopics.PerformClick()
    End Sub

    Private Sub SiteOfficielZGuideTvToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpWebsite.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            ' Modifié par Néo le 26/08/2009
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://github.com/") Then

                If [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                    Process.Start("https://github.com/neojudgment/ZGuideTVDotNet/blob/master/Docs/READMEFR.md")
                Else
                    Process.Start("https://github.com/neojudgment/ZGuideTVDotNet")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ForumOfficielZGuideTvToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpForum.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            ' Modifié par Néo le 26/08/2009
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.zguidetv.net/") Then
                Process.Start("http://www.zguidetv.net/")

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le forum de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub AProposDeZGuideTvToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpAbout.Click

        About.ShowDialog()
    End Sub

    Private Sub LangueToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpLanguage.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ' On affiche la sélection des langues
        SelectLanguage.ShowDialog()
    End Sub

    Private Sub AvantPlanToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuEditOntop.Click

        Select Case TopMost
            Case False
                TopMost = True
            Case Else
                TopMost = False
        End Select
    End Sub

    Private Sub PréférencesToolStripMenuItemClick1(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsPreferences.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Timer_minute.Enabled = False
        Pref.ShowDialog()
    End Sub

    Private Sub ModifierLogosToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsLogos.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ReorgChannel.ShowDialog()
    End Sub

    Private Sub QuitterToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuFileExit.Click
        Dim i As Double
        Dim oldVal As Double

        ' on va écrire les dimensions et la position de la fenêtre principale et de boutons
        With My.Settings
            .WindowSizeMain = Size
            .WindowLocationMain = Location
            .buttonsstate = SynthBoutons
        End With

        ' On regarde si l'effet 'FadeOut est activé dasn les préférences
        Select Case My.Settings.FadeOut
            Case 1

                oldVal = Opacity
                For i = oldVal To 0 Step -0.05
                    Opacity = i
                    Application.DoEvents()
                    Thread.Sleep(25)
                Next i
        End Select
        Timer_minute.Enabled = False
        NotifyIcon1.Visible = False
        Application.DoEvents()
        My.Settings.Save()
        Application.Exit()
    End Sub

    Private Sub ToolStripAutoUpdateClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripAutoUpdate.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            If My.Computer.Network.IsAvailable Then
                MajGrilleTv()
                MajGrilleTvBouton()
            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' une mise à jour auto
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub MajGrilleTvBouton()

        ' on a cliqué sur mise à jour ( soit bouton barre d outils , soit menu/option/mise à jour automatique
        Trace.WriteLine(DateTime.Now & " toolstripbouton2_click = mise a jour semi automatique")

        ' maj_grille_tv()
        If MajautoReussie Then ' ce flag est positionne à true dans SR majauto
            ' Timer_minute.Stop()
            Trace.WriteLine(DateTime.Now & "miseajour auto reussie ")

            ' C'est une mise a jour automatique
            If (_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6 Then

                Try
                    If My.Settings.AudioOn Then
                        JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                    End If
                Catch ex As Exception
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                End Try

                Dim boxMiseaJourAuto As DialogResult
                boxMiseaJourAuto =
                    MessageBox.Show(
                        Miseajour.MessageBoxMiseaJourDone & Chr(13) & Chr(13) &
                        Miseajour.MessageBoxMiseaJour1Done, Miseajour.MessageBoxMiseaJourTitreDone,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                If boxMiseaJourAuto = DialogResult.Yes Then

                    Tl.Close()
                    Dispose()
                    Close()

                    Application.DoEvents()
                    Application.Restart()
                Else
                    ToolStripAutoUpdate.Enabled = False
                    ToolStripMenuOptionsAutoUpdate.Enabled = False
                    ToolStripUpdate.Enabled = False
                    ToolStripMenuOptionsUpdate.Enabled = False
                    Return
                End If
            Else
                Tl.Close()
                Dispose()
                Close()

                Application.DoEvents()
                Application.Restart()
            End If

            ' ce faisant, on efface le fichier log
        Else ' la maj auto n a pas reussi
            Dim successRecuperation As Boolean
            successRecuperation = Miseajour.CopierFichier(BddPath & "db_progs.bak", BddPath & "db_progs.db3", True)
            My.Settings.datemajmiseajour = _dateMajBack
            Trace.WriteLine(DateTime.Now & " " & "La mise a jour planifiée a échoué et sera effectuée plus tard !")

            ' ReSharper disable NotAccessedVariable
            Dim boxMajauto As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxMajauto = MessageBox.Show _
                                (MessageBoxMajauto,
                                 MessageBoxMajautoTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                 MessageBoxDefaultButton.Button1)

            If successRecuperation Then
                Trace.WriteLine(DateTime.Now & " " & "Les fichiers initiaux ont été rétablis !")

                ' ReSharper disable NotAccessedVariable
                Dim boxfichierRetabli As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxfichierRetabli = MessageBox.Show _
                                    (MessageBoxfichierRetabli,
                                     MessageBoxfichierRetabliTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                     MessageBoxDefaultButton.Button1)
            Else
                Trace.WriteLine(
                    DateTime.Now & " " &
                    "La restauration de db_prog.db3 a échoué après constatation de fichier corrompu")
            End If
        End If
    End Sub

    Private Sub MajGrilleTv()
        Dim b1 As Boolean
        Dim b2 As Boolean
        Dim b3 As Boolean
        MajautoReussie = True

        If My.Settings.URLChecked Then
            b1 = My.Settings.URLChecked
            b2 =
                (Not (Not My.Settings.Lienmiseajour Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Lienmiseajour)))

        Else
            b1 = My.Settings.DIRChecked
            b2 =
                (Not _
                 (Not My.Settings.Cheminmiseajour Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Cheminmiseajour)))
        End If

        If Not ((b1 Or b3) AndAlso b2) Then
            Trace.WriteLine(
                DateTime.Now &
                "une mise à jour manuelle des grilles tv doit préceder la mise à jour automatique ou sa demande par boutons")
            Trace.WriteLine(DateTime.Now & " la maj des grilles tv  a été arretée")
            Return
        Else

            If My.Settings.URLChecked Then
                ' a t on une connection internet? testée avec google
                Try
                    If Not My.Computer.Network.IsAvailable Then
                        Trace.WriteLine(DateTime.Now & " Pas de connexion Internet ou Google ne répond pas")
                        Return
                    Else
                        Timer_minute.Stop()
                        MajAutoFlag = True
                        ' pour differencier les progress bar à mettre à jour
                        MiseAJourAuto.Show()
                        Trace.WriteLine(DateTime.Now & " juste avant traitement_appliquer()")
                        TraitementAppliquer()

                        Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                        Timer_minute.Start()
                        Timer_minute.Enabled = True
                        MajAutoFlag = False
                    End If

                Catch ex As Exception
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                    Timer_minute.Start()
                    Timer_minute.Enabled = True
                    MajAutoFlag = False
                    MajautoReussie = False
                End Try
            Else
                Timer_minute.Stop()
                MajAutoFlag = True
                ' pour differencier les progress bar à mettre à jour
                MiseAJourAuto.Show()
                Trace.WriteLine(DateTime.Now & " juste avant traitement_appliquer()")
                TraitementAppliquer()
                Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                Timer_minute.Start()
                Timer_minute.Enabled = True
                MajAutoFlag = False
            End If
        End If
    End Sub

    Private Sub ToolStripSearchClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripSearch.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If
        Using ra As New TVGuideMainForm(ObjRecherche.Aucun)
            ra.ShowDialog()
        End Using
        'TriAvance.ShowDialog()
    End Sub

    Private Sub ToolStripSearchMenuClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuSearch.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If
        Using ra As New TVGuideMainForm(ObjRecherche.Aucun)
            ra.ShowDialog()
        End Using
        'TriAvance.ShowDialog()
    End Sub

    Private Sub ToolStripMenuOptionsDualMonitorClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsDualMonitor.Click

        DualMonitor()
    End Sub

    Private Sub MiseÀJourManuelleToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsUpdate.Click

        Try
            Miseajour.Show()
        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripMenuOptionsAutoUpdateClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsAutoUpdate.Click

        Try
            If My.Settings.URLChecked = True Then
                If My.Computer.Network.IsAvailable Then
                    MajGrilleTv()
                    MajGrilleTvBouton()

                Else

                    ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                    ' une mise à jour auto
                    ' ReSharper disable NotAccessedVariable
                    Dim boxNoConnection As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxNoConnection =
                        MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                        MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation)
                End If
            Else
                MajGrilleTv()
                MajGrilleTvBouton()
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub TimerWaitTick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_wait.Tick

        If AppliRestart = False Then
            Return
        End If

        ' Windows 7 = 6.1, Windows Vista = 6.0, Windows Xp 5.x

        ' Des modifs ont été effectuées dans les prefs et on doit redémarrer
        ' On regarde si c'est Windows 7 --> si oui on affiche la messagebox

        ' On doit bien redémarrer car des options ont été modifiées et nécessitent un restart
        If ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1)) AndAlso My.Settings.ModifPrefRestart = 1 Then

            AppliRestart = False
            Timer_wait.Enabled = False
            My.Settings.Save()

            Try
                If My.Settings.AudioOn Then
                    JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                End If
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            Dim boxModifPref As DialogResult
            boxModifPref =
                MessageBox.Show(MessageBoxModifPref & Chr(13) & Chr(13) & MessageBoxModifPref1,
                                MessageBoxModifPrefTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1)

            'Si on a cliqué sur oui on redémarre zg
            If boxModifPref = DialogResult.Yes Then

                Close()

                Application.DoEvents()
                Application.Restart()
                Exit Sub
            Else
                ' Si on a cliqué sur non on ne fait rien
                ToolStripAutoUpdate.Enabled = False
                ToolStripMenuOptionsAutoUpdate.Enabled = False
                ToolStripUpdate.Enabled = False
                ToolStripMenuOptionsUpdate.Enabled = False
                Return
            End If
        End If

        ' C'est Windows Vista ou XP on redémarre
        If ((_os.Version.Major = 6 AndAlso _os.Version.Minor < 1)) Or ((_os.Version.Major < 6)) Then

            ' On doit bien redémarrer car des options ont été modifiées et nécessitent un restart
            If My.Settings.ModifPrefRestart = 1 Then

                AppliRestart = False
                Timer_wait.Enabled = False
                My.Settings.Save()

                Close()

                Application.DoEvents()
                Application.Restart()
                Exit Sub
            End If
        End If

        ' C'est une mise a jour automatique
        ' On regarde si c'est Windows 7 --> si oui on affiche la messagebox

        ' Une mise a jour automatique a été effectuée et demande un restart
        If _
            ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1)) AndAlso AppliRestart AndAlso
            My.Settings.firststart = False Then

            AppliRestart = False
            Timer_wait.Enabled = False
            My.Settings.Save()

            Try
                If My.Settings.AudioOn Then
                    JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                End If
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            Dim boxMiseaJourAuto As DialogResult
            boxMiseaJourAuto =
                MessageBox.Show(MessageBoxMiseaJourDone & Chr(13) & MessageBoxMiseaJour1Done,
                                MessageBoxMiseaJourTitreDone, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1)

            'Si on a cliqué sur oui on redémarre zg
            If boxMiseaJourAuto = DialogResult.Yes Then

                Close()

                Application.DoEvents()
                Application.Restart()
                Exit Sub
            Else
                ' Si on a cliqué sur non on ne fait rien
                ToolStripAutoUpdate.Enabled = False
                ToolStripMenuOptionsAutoUpdate.Enabled = False
                ToolStripUpdate.Enabled = False
                ToolStripMenuOptionsUpdate.Enabled = False
                Return
            End If

            ' C'est Windows Vista ou XP on redémarre
        Else

            Close()

            Application.DoEvents()
            Application.Restart()
            Exit Sub
        End If
    End Sub

    Private Sub RechercheInfosToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RechercheInfosToolStripMenuItem.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.thetvdb.com") Then

                MySearch.ShowDialog()

            Else
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ButtonGaucheMouseHover(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ZSplitButtonGauche.MouseHover

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> ButtonGauche_MouseHover")
        PanelB.Focus()

        ' redonner le focus au panneau central

        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ButtonGauche_MouseHover")
    End Sub

    Private Sub PanelCeSoirLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Panel_ce_soir.Leave

        PanelB.Select()
    End Sub

    Public Sub MaJDateStatusBar()

        'Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> MaJ_Date_StatusBar")
        ToolStripStatusLabel_date.Text = DateLangue(DateTime.Today)
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> MaJ_Date_StatusBar")
    End Sub

    Private Sub TimerSecondeTick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_seconde.Tick

        Select Case My.Settings.Language
            Case "English"
                ToolStripStatusLabel_heure.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture)
            Case Else
                ToolStripStatusLabel_heure.Text = DateTime.Now.ToString("HH:mm:ss", CultureInfo.CurrentCulture)
        End Select
    End Sub

    Private Sub RedémmarerToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuFileRestart.Click
        Close()
        Application.Restart()
    End Sub

    Private Sub EnvoyerUnFeedbackToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpManualFeedBack.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> EnvoyerUnFeedbackToolStripMenuItem")
        Try

            ' Feedback manuel
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.zguidetv.net/") Then
                My.Settings.ManualFeedBack = True
                My.Settings.Save()
                Feedback.ShowDialog()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' un Feedback manuel
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try

        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> EnvoyerUnFeedbackToolStripMenuItem")
    End Sub

    Private Sub ToolStripManualFeedBackClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripManualFeedBack.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> ToolStripManualFeedBack")
        Try

            ' Feedback manuel
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.zguidetv.net/") Then
                My.Settings.ManualFeedBack = True
                My.Settings.Save()
                Feedback.ShowDialog()
            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' un Feedback manuel
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try

        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ToolStripManualFeedBack")
    End Sub

    Private Sub ToolStripCalendarClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripCalendar.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ZSplitButtonDroit.PerformClick()
    End Sub

    Private Sub AfficherCacherCalendrierToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuCalendar.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ZSplitButtonDroit.PerformClick()
    End Sub

    Private Sub ToolStripButton2Click4(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RechercheToolStripButton.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> ToolStripButton2")
        Try

            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.thetvdb.com") Then

                MySearch.ShowDialog()

            Else
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ToolStripButton2")
    End Sub

    Public Sub BloquerBoutonCalendrier()

        For Each c As Control In Calendar.Controls
            c.Enabled = False
        Next
    End Sub

    Public Sub AutoriserBoutonCalendrier()

        For Each c As Control In Calendar.Controls
            c.Enabled = True
        Next
    End Sub

    Private Sub DécalageFuseauxHorairesToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpCompensation.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        TimeZone.ShowDialog()
    End Sub

    Private Sub FaireUnDonToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpDonate.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            ' Modifié par Néo le 28/01/2010
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://www.paypal.com/") Then
                Process.Start(
                    "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ZZBD7C6HV8V52")

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur Paypal
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripStatusLabelCompensationDoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelCompensation.DoubleClick
        TimeZone.ShowDialog()

        JetLag()
    End Sub

    Private Sub ToolStripStatusLabelMinutesDoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelMinutes.DoubleClick
        TimeZone.ShowDialog()

        JetLag()
    End Sub

    Private Sub JetLag()

        ' Néo le 10/11/2015
        If TimeZone.Decalhoraire = True Then
            Trace.WriteLine("le décalage choisi est de " & TimeZone.DecalhoraireHeure & " heures")
            My.Settings.decalage_horaire = TimeZone.DecalhoraireHeure
            TimeZone.DecalhoraireHeure = 0
            My.Settings.Save()
            Trace.WriteLine("sauvegarde du décalage horaire dans les settings")

            Dim boxBaseJetlag As DialogResult
            boxBaseJetlag = MessageBox.Show _
                            (LngMessageBoxModifPref & Chr(13) & Chr(13) & LngMessageBoxModifPref1,
                             LngMessageBoxModifPrefTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1)

            If boxBaseJetlag = DialogResult.Yes Then
                Trace.WriteLine(DateTime.Now & " " & "redémarrage dee zg après modification JetLag")

                Tl.Close()
                Close()
                Dispose()

                Application.DoEvents()
                Application.Restart()
            Else
                Trace.WriteLine(DateTime.Now & " " & "pas de redémarrage de zg après modification JetLag")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TimerHeureTick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_heure.Tick

        ' interrupt toutes les heures
        Trace.WriteLine(
            DateTime.Now.ToString &
            " entre dans timer 1 heure pour effectuer un rappel des emissions marquees")
        MajFichierMarquage()
        ' pour supprimer les emissions marquees perimees

        ' BB 110810
        ' Faut il un rappel d une emission marquée?
        ' oui si on se trouve dans un delai de 8 heures avant le debut de l emission
        ' A examiner pour toutes les emissions marquees du fichier des emissions marquees: ...zguidetvdotnet.marked.set
        Trace.WriteLine(DateTime.Now & " " & " on faisait un rappel il y a une heure , Faut il en faire un nouveau")

        Dim chaineAExaminer() As String = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "}
        'BB110810 13 emissions maximum
        Dim nomDuFichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
        If Not (File.Exists(nomDuFichier)) Then
            Exit Sub
            '250310 si le fichier n existe pas il n y a rien a recuperer
        End If

        ' le fichier existe
        'Dim sr As New StreamReader(nomDuFichier)

        Dim monStreamDocument As New StreamReader(nomDuFichier)
        Dim strligne As String

        Trace.WriteLine(DateTime.Now & " " & "liste des emissions memorisees dans le fichier ZGuideTVDotNet.marked.set")
        Dim indice As Integer = 0
        Do While (monStreamDocument.Peek <> -1) ' tant qu il y a des records ds le fichier
            strligne = monStreamDocument.ReadLine
            If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                Trace.WriteLine(strligne)
                chaineAExaminer(indice) = strligne
                indice += 1
            End If
        Loop

        'Faut il faire un rappel sonore pour une emission marquée? BB110810
        ' On le fait si on est dans la tranche de 8 heures qui precedent l emission
        Dim _
            sActuelleDecalee As String =
                (DateTime.Now.AddHours(DelaiAvertissement)).ToString("yyyy/MM/dd HH:mm:ss")

        Dim sNow As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim kk As Integer
        Dim bAvertissementSonore As Boolean = False
        For kk = 0 To 12 '(13 emissions maximum)
            If ((sActuelleDecalee > chaineAExaminer(kk)) AndAlso sNow < chaineAExaminer(kk)) Then
                bAvertissementSonore = True
            Else
            End If
        Next kk
        If bAvertissementSonore Then
            Trace.WriteLine(DateTime.Now & " " & "rappel d une emission marque : musique jouée")

            Try
                If My.Settings.AudioOn Then
                    JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                End If
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            ' ou tout autre traitement
        End If

        'sr.Close()
        monStreamDocument.Close()
        monStreamDocument.Dispose()
        Trace.WriteLine(DateTime.Now & " " & "fin de timer heure")
        Trace.WriteLine("   ")
    End Sub

    Private Sub ToolStripButtonRechercheClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripButtonRecherche.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform ToolStripButtonRecherche_Click")

        If _
            ToolStripTextBoxRecherche.TextLength > 1 AndAlso
            ToolStripTextBoxRecherche.Text <> LngToolStripTextBoxRecherche Then

            ' On ajoute le terme dans la recherche
            _autoComplete.Add(ToolStripTextBoxRecherche.Text)

            ' On évite les doublons dans AutoComplete.set
            Dim sr As StreamReader
            Dim sline As String
            Dim update As Boolean = True

            sr = File.OpenText(AutoCompletePath & "AutoComplete.set")

            While Not sr.EndOfStream
                sline = sr.ReadLine()
                If sline = ToolStripTextBoxRecherche.Text Then
                    update = False
                End If
            End While
            sr.Close()
            sr.Dispose()

            ' On ajoute le terme recherché dans AutoComplete.set
            If update Then
                Using writer As New StreamWriter(AutoCompletePath & "AutoComplete.set", True)
                    writer.WriteLine(ToolStripTextBoxRecherche.Text, Environment.NewLine)
                    writer.Close()
                End Using
            End If

            ' On affiche le résultat de la recherche
            'TriAvance.Textbox_titre.Text = ToolStripTextBoxRecherche.Text
            Using ra As New TVGuideMainForm(ObjRecherche.ParTerme, ToolStripTextBoxRecherche.Text.Trim)
                RechercheTextBoxToolStrip()
                ra.ShowDialog()
            End Using
            'TriAvance.ShowDialog()
        End If
        Trace.WriteLine(DateTime.Now & " " & "On sort de mainform ToolStripButtonRecherche_Click")
    End Sub

    Private Sub ToolStripTextBoxRechercheClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripTextBoxRecherche.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform ToolStripTextBoxRecherche_Click")

        With ToolStripTextBoxRecherche
            .Text = ""
            .ForeColor = Color.Black
            .Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular)
            .TextBoxTextAlign = HorizontalAlignment.Left
        End With
        Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform ToolStripTextBoxRecherche_Click")
    End Sub

    Public Sub RechercheTextBoxToolStrip()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform Recherche_TextBox_ToolStrip")

        With ToolStripTextBoxRecherche
            .Text = LngToolStripTextBoxRecherche
            .ForeColor = Color.Gray
            .Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic)
            .TextBoxTextAlign = HorizontalAlignment.Center
        End With
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform Recherche_TextBox_ToolStrip")
    End Sub

    Private Sub ToolStripMenuFileSaveClick1(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuFileSave.Click

        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur Gestion de la bdd à partir du menu")
        SuspendLayout()
        Gestionbdd.ShowDialog()
    End Sub

    Private Sub ToolStripTextBoxRechercheKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles ToolStripTextBoxRecherche.KeyDown

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter Then
            Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform ToolStripTextBoxRecherche.KeyDown")

            If _
                ToolStripTextBoxRecherche.TextLength > 1 AndAlso
                ToolStripTextBoxRecherche.Text <> LngToolStripTextBoxRecherche Then

                ' On ajoute le terme dans la recherche
                _autoComplete.Add(ToolStripTextBoxRecherche.Text)

                ' On évite les doublons dans AutoComplete.set
                Dim sr As StreamReader
                Dim sline As String
                Dim update As Boolean = True

                sr = File.OpenText(AutoCompletePath & "AutoComplete.set")

                While Not sr.EndOfStream
                    sline = sr.ReadLine()
                    If sline = ToolStripTextBoxRecherche.Text Then
                        update = False
                    End If
                End While
                sr.Close()
                sr.Dispose()
                ' On ajoute le terme recherché dans AutoComplete.set
                If update Then
                    Using writer As New StreamWriter(AutoCompletePath & "AutoComplete.set", True)
                        writer.WriteLine(ToolStripTextBoxRecherche.Text, Environment.NewLine)
                        writer.Close()
                    End Using
                End If

                ' On affiche le résultat de la recherche
                'TriAvance.Textbox_titre.Text = ToolStripTextBoxRecherche.Text
                Using ra As New TVGuideMainForm(ObjRecherche.ParTerme, ToolStripTextBoxRecherche.Text.Trim)
                    RechercheTextBoxToolStrip()
                    ra.ShowDialog()
                End Using

                'TriAvance.ShowDialog()
            End If
            Trace.WriteLine(DateTime.Now & " " & "On sort de mainform ToolStripTextBoxRecherche.KeyDown")
        End If
    End Sub

    Private Sub ToolStripHelptopicsClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripHelptopics.Click

        Try

            ' Modifié par Néo le 13/02/2011
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://github.com/") Then

                If My.Settings.Language = "Français" Then

                    Process.Start("https://github.com/neojudgment/ZGuideTVDotNet/blob/master/Docs/DemarrageRapide.md")
                Else
                    Process.Start("https://github.com/neojudgment/ZGuideTVDotNet/blob/master/Docs/QuickStart.md")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripMenuItemSettingsResetClick(sender As Object, e As EventArgs) _
        Handles ToolStripMenuItemSettingsReset.Click
        Trace.WriteLine(DateTime.Now.ToString & " On va faire un reset des data dans les préférences")

        ' Remise à zero de tous les paramètres
        Dim boxRaz As DialogResult
        boxRaz =
            MessageBox.Show(MessageBoxRaz & Chr(13) & Chr(13) & MessageBoxRaz1,
                            MessageBoxTitleRaz, MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1)

        'Si on a cliqué sur oui on redémarre zg
        If boxRaz = DialogResult.Yes Then

            Try

                ' On efface la bdd ainsi que les autres fichiers
                If My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") Then
                    File.Delete(BddPath & "db_progs.db3")
                End If
                If My.Computer.FileSystem.FileExists(ChannelSetPath & "ZGuideTVDotNet.channels.set") Then
                    File.Delete(ChannelSetPath & "ZGuideTVDotNet.channels.set")
                End If

                ' On redémarre ZGuideTV.NET
                Trace.WriteLine(
                    DateTime.Now.ToString &
                    " On vient de faire un reset des data dans le Mainform. zguidetv redémarre")
                Dispose()
                Close()
                Application.DoEvents()
                Application.Restart()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Trace.WriteLine(DateTime.Now & " Erreur lors du RAZ dans Mainform")
            End Try
        End If
    End Sub

    Private Sub TestToolStripMenuHelpHelpShortcutsClick(sender As Object, e As EventArgs) _
        Handles ToolStripMenuHelpHelpShortcuts.Click

        ToolStripHelpShortcuts.PerformClick()
    End Sub

    Private Sub ToolStripHelpShortcutsClick(sender As Object, e As EventArgs) Handles ToolStripHelpShortcuts.Click

        Try

            ' Modifié par Néo le 13/02/2011
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://github.com/") Then

                If [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                    ' Process.Start(
                    ' "http://zguidetv.codeplex.com/wikipage?title=Raccourcis clavier de r%u00e9f%u00e9rences")
                Else
                    ' Process.Start("http://zguidetv.codeplex.com/wikipage?title=Keyboard Shortcuts")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripButtonDonateClick(sender As Object, e As EventArgs) Handles ToolStripButtonDonate.Click

        ToolStripMenuHelpDonate.PerformClick()
    End Sub

    Private Sub ToolStripPrint_Click(sender As Object, e As EventArgs) _
        Handles ToolStripPrintTonight.Click, ToolStripMenuPrintTonight.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Dim test As New ImprimeEmissions("CE SOIR", TableauListEmissionsCeSoir)
        test.VoirPrevisualisation()
    End Sub

    Private Sub ToolStripStatusLabel2Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabelUpdate.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            ' mise a jour logicielle
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.zguidetv.net/") Then

                ' Néo le 24/04/2013
                ' On crée un thread pour parser le XML
                Dim xmlParserthread As Thread = New Thread(AddressOf XmlParser)
                With xmlParserthread
                    .IsBackground = True
                    .Start()
                End With
            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le forum de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Button_MouseEnter(sender As Object, e As EventArgs) _
        Handles ZSplitButtonDroit.MouseEnter, ZSplitButton1.MouseEnter
        CType(sender, Control).Select()
    End Sub

    Private Sub Timer_250msec_Tick(sender As Object, e As EventArgs) Handles Timer_250msec.Tick

        'rvs75 26/09/2013 remis la ligne de code de timer_500ms
        TshEnCours = False
    End Sub

    Private Sub ToolStripFacebook_Click(sender As Object, e As EventArgs) Handles ToolStripFacebook.Click

        Try

            ' Modifié par Néo le 15/04/2014
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://www.facebook.com/") Then
                Process.Start("https://www.facebook.com/groups/14846687962/")

            Else
                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le facebook de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub FacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FacebookToolStripMenuItem.Click

        Try

            ' Modifié par Néo le 15/04/2014
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://www.facebook.com/") Then
                Process.Start("https://www.facebook.com/groups/14846687962/")

            Else
                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le facebook de zguidetv
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub BtImprimeCeSoir_Click(sender As Object, e As EventArgs) Handles btImprimeCeSoir.Click

        Dim test As New ImprimeEmissions("CE SOIR", TableauListEmissionsCeSoir)
        test.VoirPrevisualisation()
    End Sub

    Private Sub BtImprimemaintenant_Click(sender As Object, e As EventArgs) Handles btImprimemaintenant.Click

        Dim test As New ImprimeEmissions("MAINTENANT", TableauListEmissionsMaintenant)
        test.VoirPrevisualisation()
    End Sub

    Public Sub JouerSon(nomSon As String, volume As Integer)
        Dim wave As New WaveOut
        Dim xa() As Byte = File.ReadAllBytes(MediaPath & nomSon)
        Dim data As New MemoryStream(xa)
        wave.Init(
            New BlockAlignReductionStream(
                WaveFormatConversionStream.CreatePcmStream(New WaveFileReader(data))))
        wave.Volume = CInt(My.Settings.MessagesVolume / 10)
        wave.Play()
        data.Close()
        data.Dispose()

    End Sub

    Private Sub ToolStripMenuCouleurCategorie_Click(sender As Object, e As EventArgs) Handles ToolStripMenuOptionsCouleurCategorie.Click

        Dim gestcat As New GestionCategorie() With {.ApresMajXmltv = False}
        gestcat.ShowDialog()
    End Sub

    Private Sub ToolStripOptionsCouleurCategorie_Click(sender As Object, e As EventArgs) Handles ToolStripOptionsCouleurCategorie.Click

        ToolStripMenuOptionsCouleurCategorie.PerformClick()
    End Sub
End Class