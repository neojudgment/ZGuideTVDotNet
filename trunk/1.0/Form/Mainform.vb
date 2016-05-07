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

#Region "Imports"

Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.ComponentModel
Imports System.Reflection
Imports System.Globalization
Imports System.Configuration
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Collections.Specialized
Imports System.Net
Imports Microsoft.Win32
Imports System.ServiceModel.Syndication
Imports ZGuideTV.SQLiteWrapper
Imports Windows7.DesktopIntegration
Imports System.Xml
Imports ZGuideTVDotNet.Render.ZGuideTVDotNetRender
Imports Windows7.DesktopIntegration.WindowsForms.WindowsFormsExtensions
Imports Microsoft.DirectX
Imports Microsoft.DirectX.AudioVideoPlayback
Imports SearchOption = Microsoft.VisualBasic.FileIO.SearchOption

#End Region

Public Class Mainform
    Inherits Form
    Private _mutex As Mutex

#Region "Property"

    Private _delaiAvertissement As Integer = 8

    ' on est averti un certain temps avant le debut d une emission marquee
    ' exprimé en heures
    Public Property DelaiAvertissement As Integer
        Get
            Return _delaiAvertissement
        End Get
        Set(ByVal value As Integer)
            _delaiAvertissement = Value
        End Set
    End Property

    ' Public bandeau_signaletique As New RichTextBox
    ' Public largeur_panneau_signaletique As Integer = 120
    ' Public hauteur_panneau_signaletique As Integer = 25
    Private _filledTreeviewheight As Integer
    Private ReadOnly _autoComplete As New AutoCompleteStringCollection()

    Private Property FilledTreeviewheight As Integer
        Get
            Return _filledTreeviewheight
        End Get
        Set(ByVal value As Integer)
            _filledTreeviewheight = value
        End Set
    End Property

    Private _characterHeight As Double

    Private Property CharacterHeight As Double
        Get
            Return _characterHeight
        End Get
        Set(ByVal value As Double)
            _characterHeight = value
        End Set
    End Property

    Private _parametre As Integer = 1

    Private Property Parametre As Integer
        Get
            Return _parametre
        End Get
        Set(ByVal value As Integer)
            _parametre = value
        End Set
    End Property

    Private _largeurInitialeTreeview1 As Integer

    Public Property LargeurInitialeTreeview1 As Integer
        Get
            Return _largeurInitialeTreeview1
        End Get
        Set(ByVal value As Integer)
            _largeurInitialeTreeview1 = Value
        End Set
    End Property

    ' BB 231009 fixée par le design
    Private _nbTotalTypeEmissionPourPeriodeFixee As Integer

    Private Property NbTotalTypeEmissionPourPeriodeFixee As Integer
        Get
            Return _nbTotalTypeEmissionPourPeriodeFixee
        End Get
        Set(ByVal value As Integer)
            _nbTotalTypeEmissionPourPeriodeFixee = value
        End Set
    End Property

    ' pour les heures a
    ' partir de maintenant jusque la fin des date( < nb_total_type_emission)
    Private _tshEnCours As Boolean

    Public Property TshEnCours As Boolean
        Get
            Return _tshEnCours
        End Get
        Set(ByVal Value As Boolean)
            _tshEnCours = Value
        End Set
    End Property

    ' traitement scroll horizontal
    ' en cours , ne pas les accumuler trop rapidement
    Private _scrollHorizontal As Boolean
    ' = False

    Public Property ScrollHorizontal As Boolean
        Get
            Return _scrollHorizontal
        End Get
        Set(ByVal value As Boolean)
            _scrollHorizontal = Value
        End Set
    End Property

    Private _nbMaxChaineEcran As Integer

    Public Property NbMaxChaineEcran As Integer
        Get
            Return _nbMaxChaineEcran
        End Get
        Set(ByVal value As Integer)
            _nbMaxChaineEcran = Value
        End Set
    End Property

    Private _memoRichtextboxDescripHeight As Integer

    Private Property MemoRichtextboxDescripHeight As Integer
        Get
            Return _memoRichtextboxDescripHeight
        End Get
        Set(ByVal value As Integer)
            _memoRichtextboxDescripHeight = value
        End Set
    End Property

    Private _appliRestart As Boolean

    Public Property AppliRestart As Boolean
        Get
            Return _appliRestart
        End Get
        Set(ByVal value As Boolean)
            _appliRestart = Value
        End Set
    End Property

    Private _sw As StreamWriter

    Private Property Sw As StreamWriter
        Get
            Return _sw
        End Get
        Set(ByVal value As StreamWriter)
            _sw = value
        End Set
    End Property

    Private _sw1 As StreamWriter

    Public Property Sw1 As StreamWriter
        Get
            Return _sw1
        End Get
        Set(ByVal value As StreamWriter)
            _sw1 = Value
        End Set
    End Property

    Private _tl As TextWriterTraceListener

    ' flag specifiant si on veut creer un fichier log où seront
    ' écrites les indstructions trace.writeline
    ' ce flag est mis à un en allant dans les préférences et cochant
    ' une option précise(activer trace log)
    Public Property Tl As TextWriterTraceListener
        Get
            Return _tl
        End Get
        Set(ByVal value As TextWriterTraceListener)
            _tl = value
        End Set
    End Property

    Private _mGraphics As Graphics

    Private Property MGraphics As Graphics
        Get
            Return _mGraphics
        End Get
        Set(ByVal value As Graphics)
            _mGraphics = value
        End Set
    End Property

    Private _gLine As PaintEventArgs

    Private Property GLine As PaintEventArgs
        Get
            Return _gLine
        End Get
        Set(ByVal value As PaintEventArgs)
            _gLine = Value
        End Set
    End Property

    Private _majautoReussie As Boolean
  
    Public Property MajautoReussie As Boolean
        Get
            Return _majautoReussie
        End Get
        Set(ByVal value As Boolean)
            _majautoReussie = Value
        End Set
    End Property

    Private _msgProxyTitle As String

    Public Property MsgProxyTitle As String
        Get
            Return _msgProxyTitle
        End Get
        Set(ByVal value As String)
            _msgProxyTitle = Value
        End Set
    End Property

    Private _msgProxy As String

    Public Property MsgProxy As String
        Get
            Return _msgProxy
        End Get
        Set(ByVal value As String)
            _msgProxy = Value
        End Set
    End Property

    Private _ktvChannel As Integer

    Public Property KtvChannel As Integer
        Get
            Return _ktvChannel
        End Get
        Set(ByVal value As Integer)
            _ktvChannel = Value
        End Set
    End Property

    Private _sMaintenant As String

    Private Property SMaintenant As String
        Get
            Return _sMaintenant
        End Get
        Set(ByVal value As String)
            _sMaintenant = Value
        End Set
    End Property

    Private _jumelleEnfonce As Boolean

    Public Property JumelleEnfonce As Boolean
        Get
            Return _jumelleEnfonce
        End Get
        Set(ByVal value As Boolean)
            _jumelleEnfonce = Value
        End Set
    End Property

    Private _dateMajBack As String = DateTime.Now.ToString

    Private Property DateMajBack As String
        Get
            Return _dateMajBack
        End Get
        Set(ByVal value As String)
            _dateMajBack = Value
        End Set
    End Property

    Private _nameofMonth1 As String

    Public Property NameofMonth1 As String
        Get
            Return _nameofMonth1
        End Get
        Set(ByVal value As String)
            _nameofMonth1 = Value
        End Set
    End Property

    Private _nameofMonth2 As String

    Public Property NameofMonth2 As String
        Get
            Return _nameofMonth2
        End Get
        Set(ByVal value As String)
            _nameofMonth2 = Value
        End Set
    End Property

    Private _nameofMonth3 As String

    Public Property NameofMonth3 As String
        Get
            Return _nameofMonth3
        End Get
        Set(ByVal value As String)
            _nameofMonth3 = Value
        End Set
    End Property

    Private _nameofMonth4 As String

    Public Property NameofMonth4 As String
        Get
            Return _nameofMonth4
        End Get
        Set(ByVal value As String)
            _nameofMonth4 = Value
        End Set
    End Property

    Private _nameofMonth5 As String

    Public Property NameofMonth5 As String
        Get
            Return _nameofMonth5
        End Get
        Set(ByVal value As String)
            _nameofMonth5 = Value
        End Set
    End Property

    Private _nameofMonth6 As String

    Public Property NameofMonth6 As String
        Get
            Return _nameofMonth6
        End Get
        Set(ByVal value As String)
            _nameofMonth6 = Value
        End Set
    End Property

    Private _nameofMonth7 As String

    Public Property NameofMonth7 As String
        Get
            Return _nameofMonth7
        End Get
        Set(ByVal value As String)
            _nameofMonth7 = Value
        End Set
    End Property

    Private _nameofMonth8 As String

    Public Property NameofMonth8 As String
        Get
            Return _nameofMonth8
        End Get
        Set(ByVal Value As String)
            _nameofMonth8 = Value
        End Set
    End Property

    Private _nameofMonth9 As String

    Public Property NameofMonth9 As String
        Get
            Return _nameofMonth9
        End Get
        Set(ByVal value As String)
            _nameofMonth9 = Value
        End Set
    End Property

    Private _nameofMonth10 As String

    Public Property NameofMonth10 As String
        Get
            Return _nameofMonth10
        End Get
        Set(ByVal value As String)
            _nameofMonth10 = Value
        End Set
    End Property

    Private _nameofMonth11 As String

    Public Property NameofMonth11 As String
        Get
            Return _nameofMonth11
        End Get
        Set(ByVal value As String)
            _nameofMonth11 = Value
        End Set
    End Property

    Private _nameofMonth12 As String

    Public Property NameofMonth12 As String
        Get
            Return _nameofMonth12
        End Get
        Set(ByVal value As String)
            _nameofMonth12 = Value
        End Set
    End Property

    Private _messageBoxMiseaJour As String

    Public Property MessageBoxMiseaJour As String
        Get
            Return _messageBoxMiseaJour
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJour = Value
        End Set
    End Property

    Private _messageBoxMiseaJour1 As String

    Public Property MessageBoxMiseaJour1 As String
        Get
            Return _messageBoxMiseaJour1
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJour1 = Value
        End Set
    End Property

    Private _messageBoxMiseaJourTitre As String

    Public Property MessageBoxMiseaJourTitre As String
        Get
            Return _messageBoxMiseaJourTitre
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJourTitre = Value
        End Set
    End Property

    Private _messageBoxMiseaJourDone As String

    Public Property MessageBoxMiseaJourDone As String
        Get
            Return _messageBoxMiseaJourDone
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJourDone = Value
        End Set
    End Property

    Private _messageBoxMiseaJour1Done As String

    Public Property MessageBoxMiseaJour1Done As String
        Get
            Return _messageBoxMiseaJour1Done
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJour1Done = Value
        End Set
    End Property

    Private _messageBoxMiseaJourTitreDone As String

    Public Property MessageBoxMiseaJourTitreDone As String
        Get
            Return _messageBoxMiseaJourTitreDone
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJourTitreDone = Value
        End Set
    End Property

    Private _messageBoxModifPref As String

    Public Property MessageBoxModifPref As String
        Get
            Return _messageBoxModifPref
        End Get
        Set(ByVal value As String)
            _messageBoxModifPref = Value
        End Set
    End Property

    Private _messageBoxModifPref1 As String

    Public Property MessageBoxModifPref1 As String
        Get
            Return _messageBoxModifPref1
        End Get
        Set(ByVal value As String)
            _messageBoxModifPref1 = Value
        End Set
    End Property

    Private _messageBoxModifPrefTitre As String

    Public Property MessageBoxModifPrefTitre As String
        Get
            Return _messageBoxModifPrefTitre
        End Get
        Set(ByVal value As String)
            _messageBoxModifPrefTitre = Value
        End Set
    End Property

    Private _messageBoxNoConnection As String

    Public Property MessageBoxNoConnection As String
        Get
            Return _messageBoxNoConnection
        End Get
        Set(ByVal value As String)
            _messageBoxNoConnection = Value
        End Set
    End Property

    Private _messageBoxNoConnection1 As String

    Public Property MessageBoxNoConnection1 As String
        Get
            Return _messageBoxNoConnection1
        End Get
        Set(ByVal value As String)
            _messageBoxNoConnection1 = Value
        End Set
    End Property

    Private _messageBoxNoConnectionTitre As String

    Public Property MessageBoxNoConnectionTitre As String
        Get
            Return _messageBoxNoConnectionTitre
        End Get
        Set(ByVal value As String)
            _messageBoxNoConnectionTitre = Value
        End Set
    End Property

    Private _toolStripStatusLabelMb As String

    Public Property ToolStripStatusLabelMb As String
        Get
            Return _toolStripStatusLabelMb
        End Get
        Set(ByVal Value As String)
            _toolStripStatusLabelMb = Value
        End Set
    End Property

    Private _rsslink As String

    Private Property Rsslink As String
        Get
            Return _rsslink
        End Get
        Set(ByVal value As String)
            _rsslink = Value
        End Set
    End Property

    Private WithEvents jumplist As JumpListManager
    Private ReadOnly _os As OperatingSystem = Environment.OSVersion
    
    Private _weatherInformation As String

    Public Property WeatherInformation As String
        Get
            Return _weatherInformation
        End Get
        Set(ByVal value As String)
            _weatherInformation = Value
        End Set
    End Property

    Private _messageBoxResume As String

    Public Property MessageBoxResume As String
        Get
            Return _messageBoxResume
        End Get
        Set(ByVal value As String)
            _messageBoxResume = Value
        End Set
    End Property

    Private _messageBoxResume1 As String

    Public Property MessageBoxResume1 As String
        Get
            Return _messageBoxResume1
        End Get
        Set(ByVal value As String)
            _messageBoxResume1 = Value
        End Set
    End Property

    Private _messageBoxResumeTitre As String

    Public Property MessageBoxResumeTitre As String
        Get
            Return _messageBoxResumeTitre
        End Get
        Set(ByVal value As String)
            _messageBoxResumeTitre = Value
        End Set
    End Property

    Private _messageBoxBasePerimee As String

    Public Property MessageBoxBasePerimee As String
        Get
            Return _messageBoxBasePerimee
        End Get
        Set(ByVal value As String)
            _messageBoxBasePerimee = Value
        End Set
    End Property

    Private _messageBoxBasePerimee1 As String

    Public Property MessageBoxBasePerimee1 As String
        Get
            Return _messageBoxBasePerimee1
        End Get
        Set(ByVal value As String)
            _messageBoxBasePerimee1 = Value
        End Set
    End Property

    Private _messageBoxBasePerimeeTitre As String

    Public Property MessageBoxBasePerimeeTitre As String
        Get
            Return _messageBoxBasePerimeeTitre
        End Get
        Set(ByVal value As String)
            _messageBoxBasePerimeeTitre = Value
        End Set
    End Property

    Private _siteofficiel As String

    Public Property SiteOfficiel As String
        Get
            Return _siteofficiel
        End Get
        Set(ByVal value As String)
            _siteofficiel = Value
        End Set
    End Property

    Private _forumofficiel As String

    Public Property ForumOfficiel As String
        Get
            Return _forumofficiel
        End Get
        Set(ByVal value As String)
            _forumofficiel = Value
        End Set
    End Property

    Private _titleRaz As String

    Public Property MessageBoxTitleRaz As String
        Get
            Return _titleRaz
        End Get
        Set(ByVal value As String)
            _titleRaz = Value
        End Set
    End Property

    Private _msgRaz As String

    Public Property MessageBoxRaz As String
        Get
            Return _msgRaz
        End Get
        Set(ByVal value As String)
            _msgRaz = Value
        End Set
    End Property

    Private _msgRaz2 As String

    Public Property MessageBoxRaz1 As String
        Get
            Return _msgRaz2
        End Get
        Set(ByVal value As String)
            _msgRaz2 = Value
        End Set
    End Property

    Private _miseaJourAutoExe As Boolean

    Public Property MiseaJourAutoExe As Boolean
        Get
            Return _MiseaJourAutoExe
        End Get
        Set(ByVal value As Boolean)
            _miseaJourAutoExe = Value
        End Set
    End Property
#End Region

#Region "MainformLoad"
    Private Sub MainformLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Mutex pour l'assistant d'installation
        _mutex = New Mutex(False, "ZGUIDETV_MUTEX")

        ' Néo 17/01/2011 Mode Suspend/Resume
        AddHandler SystemEvents.PowerModeChanged, AddressOf PowerChanged

        ' rvs75 : 27/10/2010 : détection offline
        Dim args As String() = Environment.GetCommandLineArgs()
        If args.Length = 2 AndAlso args(1) = "/offline" Then
            isOffline = True
        Else
            isOffline = False
        End If

        Dim fv As FileVersionInfo
        fv = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)

        ' On envoie au second Thread (SplashScreen)
        SplashScreenClass.VersionText("ZGuideTV.NET RC7 v" & fv.FileVersion)
        SplashScreenClass.CopyrightText(fv.LegalCopyright & " ZGuideTV Team")

        Hide()

        'Saisie semi auto recherche rapide dans la barre d'outils
        With ToolStripTextBoxRecherche
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = _autoComplete
        End With

        RechercheTextBoxToolStrip()

        ' prise en compte du decalage horaire sauvé dans les settings
        decal_horaire = -My.Settings.decalage_horaire

        moment_souhaite = DebutHeure(DateTime.Now)

        date_reference = moment_souhaite
        moment_souhaite = moment_souhaite.AddHours(decal_horaire)
        date_reference = moment_souhaite

        Trace.WriteLine(DateTime.Now & " " & "moment souhaité " & moment_souhaite.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Décalage horaire = " & decal_horaire.ToString & " heures")
        Trace.WriteLine(DateTime.Now & " " & "date reference =" & date_reference.ToString)

        ' On va récupérer la configuration matérielle dans le fichier user.config et en fonction de la config
        ' Néo le 25/07/2009
        Select Case My.Settings.ConfHardware
            Case 1
                nb_de_periodes_de_6h = 6
                ' On charge 36 heures d'émissions
            Case 2
                nb_de_periodes_de_6h = 5
                ' On charge 30 heures d'émissions
            Case 3
                nb_de_periodes_de_6h = 4
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
                    Trace.WriteLine( _
                                     DateTime.Now & " " & "Screen.PrimaryScreen.WorkingArea.Height= " & _
                                     Screen.PrimaryScreen.WorkingArea.Height.ToString)
                    Trace.WriteLine( _
                                     DateTime.Now & " " & "Screen.PrimaryScreen.WorkingArea.width= " & _
                                     Screen.PrimaryScreen.WorkingArea.Width.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "me.top = " & Top.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "me.left = " & Left.ToString)
                    WindowState = FormWindowState.Maximized
            End Select

            ' On regarde dans .config si il faut utiliser
            ' la sauvegarde des buttons
            With My.Settings
                If .buttonssave = 1 Then
                    synth_boutons = .buttonsstate
                    If (CInt(4 And synth_boutons) = 4) Then
                        b1pad = True
                    End If
                    bgpad = False
                    ' provisoire If (CInt(2 And synth_boutons) = 2) Then bgpad = True

                    If (CInt(1 And synth_boutons) = 1) Then
                        bdpad = True
                    End If
                End If
            End With
        End With

        Text = "ZGuideTV.NET RC7 v" & fv.FileVersion

        'Néo 29/05/2010 On regarde si la bdd est périmée
        If My.Computer.FileSystem.FileExists(BDDPath & "db_progs.db3") Then
            Dim fichierInfo As FileInfo = New FileInfo(BDDPath & "db_progs.db3")
            Dim tailleBdd As Integer = CInt(fichierInfo.Length)
            If BasePerimee() AndAlso tailleBdd > 6000 Then
                My.Settings.DataBaseExpired = True
                Hide()

                'Néo le 09/09/2010
                If Not My.Settings.DIRChecked Then
                    If My.Settings.Epgdata Then
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
                    Else
                        Try

                            HideControls.Hide()

                            LanguageCheck(16)

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

                        If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable(My.Settings.Lienmiseajour) Then

                            Try
                                If My.Settings.AudioOn Then
                                    ' le volume va de 0 (max) à -10000 (min)
                                    Dim audioPlay As Audio
                                    audioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                                    audioPlay.Volume = My.Settings.MessagesVolume
                                    audioPlay.Play()
                                End If
                            Catch ex As DirectXException
                                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                            End Try

                            Dim boxBasePerimee As DialogResult
                            boxBasePerimee = MessageBox.Show _
                                (MessageBoxBasePerimee & Chr(13) & MessageBoxBasePerimee1, _
                                 MessageBoxBasePerimeeTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                 MessageBoxDefaultButton.Button1)

                            If boxBasePerimee = Windows.Forms.DialogResult.Yes Then
                                Trace.WriteLine(DateTime.Now & " " & "entree Miseajour car base périmée")

                                Miseajour.Show()
                                '!!!!!!!!
                            Else
                                Trace.WriteLine(DateTime.Now & " " & "passage return")
                                Return
                            End If
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
                        Opacity = 100%

                        ' On arrête le thread du SplashScreen
                        Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du SplashScreen")
                        SplashScreenClass.CloseSplashScreen()

                    Catch ex As ThreadAbortException
                        Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    End Try

                    Try
                        If My.Settings.AudioOn Then
                            ' le volume va de 0 (max) à -10000 (min)
                            Dim audioPlay As Audio
                            audioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                            audioPlay.Volume = My.Settings.MessagesVolume
                            audioPlay.Play()
                        End If
                    Catch ex As DirectXException
                        Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    End Try

                    Dim boxBasePerimee As DialogResult
                    boxBasePerimee = MessageBox.Show _
                        (MessageBoxBasePerimee & Chr(13) & MessageBoxBasePerimee1, _
                         MessageBoxBasePerimeeTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                         MessageBoxDefaultButton.Button1)

                    If boxBasePerimee = Windows.Forms.DialogResult.Yes Then
                        Trace.WriteLine(DateTime.Now & " " & "entree Miseajour car base périmée")

                        Miseajour.Show()
                        '!!!!!!!!
                    Else
                        Trace.WriteLine(DateTime.Now & " " & "passage return")
                        Return
                    End If
                End If
                Return
            End If
        End If

        ' vérifie si la db existe sinon la créer et faire la connection
        If My.Computer.FileSystem.FileExists(BDDPath & "db_progs.db3") = False Then
            My.Settings.BddExists = False

            ' la BD n existe pas
            nombre_de_chaines_differentes = My.Settings.nbchainesdiff
            CreateDBTables()
            DessineLigneTemps()

            NotifyIcon1.Visible = False
            Hide()

            'Néo le 05/09/2010
            If My.Settings.Epgdata Then
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
            Else
                Try

                    HideControls.Hide()

                    LanguageCheck(15)

                    ' test de Néo !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    Dim newPictureBox As New PictureBox

                    With newPictureBox
                        .BackColor = Color.White
                        .Height = 84
                        .Width = 299
                        .Top = ToolStrip1.Bottom
                        .Left = 263
                        .BringToFront()
                        .Visible = True
                    End With

                    With Me
                        .Controls.Add(newPictureBox)

                        Application.DoEvents()
                        .Show()
                        Application.DoEvents()
                        .Opacity = 100%
                    End With

                    ' On arrête le thread du SplashScreen
                    Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du SplashScreen")
                    SplashScreenClass.CloseSplashScreen()

                Catch ex As ThreadAbortException
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                End Try
            End If
            Return
        Else

            ' la  BD existe
            My.Settings.BddExists = True
            nombre_de_chaines_differentes = My.Settings.nbchainesdiff

            PanelB.Width = largeur_logo_adaptee
            hauteur_taskbar = GetTaskBarHeight()

            Button1.Width = largeur_boutons_verticaux
            ButtonGauche.Width = largeur_boutons_verticaux
            ButtonDroit.Width = largeur_boutons_verticaux
            ButtonBas1.Height = largeur_boutons_verticaux

            CaracteristiquesEcranEtMainform()

            Dim z1 As Integer
            Dim z2 As Integer
            z1 = Size.Width
            If z1 > largeur_ecran Then
                erreurh = Size.Width - largeur_ecran
            End If

            z2 = Size.Height
            If z2 + hauteur_taskbar > hauteur_ecran Then
                erreurv = Size.Height + CInt(hauteur_taskbar) - hauteur_ecran
            End If
#If DEBUG Then
            Trace.WriteLine(DateTime.Now & " Erreur h = " & erreurh.ToString)
            Trace.WriteLine(DateTime.Now & " Erreur v = " & erreurv.ToString)
            Trace.WriteLine(DateTime.Now & " hauteur_taskbar = " & hauteur_taskbar.ToString)
#End If
            ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
            ' buttondroit.left non definitif

            ' majoration de la hauteur de richtextboxdescrip par
            ' par rapport à la hauteur du dessin ds mainform
            ' meme majoration pour pictureboxlogo
            ' 261109 a verifier
            With RichTextBoxDescrip
                .Height += major_haut_richtextboxdescrip
                .Width = ButtonDroit.Right - PictureBoxLogo.Width
            End With

            PictureBoxLogo.Height += major_haut_richtextboxdescrip - StatusStrip2.Height
            panelA_point_width_max = z1 - ButtonDroit.Width - Button1.Width - ButtonGauche.Width - PanelB.Width - _
                                     erreurh

            Longueur_Ligne_Temp = panelA_point_width_max
            nb_pixels_pour_30_minutes = CDec(Longueur_Ligne_Temp / (2 * Nb_heures_LigneTemps))

            ReferencesTemps()

            PremiereInitialisation()

#If DEBUG Then
            ' mesure du temps d execution de charge_categorie
            Dim montsw_categorie As New Stopwatch
            montsw_categorie.Start()
            Dim tps_ecoule As Long
#End If

            Charge_Categorie()

#If DEBUG Then

            montsw_categorie.Stop()
            tps_ecoule = montsw_categorie.ElapsedMilliseconds
            Trace.WriteLine(DateTime.Now & " " & "temps d execution de charge categorie(msec) = " & tps_ecoule.ToString)

            montsw_categorie = Nothing
#End If
            TreeView1.ExpandAll()

            ' pre calcul du scroll maximal vers le bas
            Dim nbNoeudsInterne As Integer = TreeView1.Nodes.Item(0).Nodes.Item(0).Nodes.Count
            CharacterHeight = TreeView1.ItemHeight
            FilledTreeviewheight = CInt(CharacterHeight * (nbNoeudsInterne + 4))

            TreeView1.Height = 3 * hauteur_ecran

            With Panel_glob_devant
                .Top = ToolStrip1.Bottom()
                .Height = TreeView1.Height
            End With
            ' nb_noeuds_interne est le nbre de categorie (outre pays, fournisseurs,..)

            ' affiche tous les types d'émission dans treeview1
            ChargeListeChannel()

            PositionneBoutonsMemorises()

            lecture_des_chaines_memorisees()

            ' gestion du scroll de treeview1
            With Panel_glob_devant
                .Parent = Me
                .Top = ToolStrip1.Bottom
                .Left = 0
            End With

            With Panel_devant
                .Parent = Panel_glob_devant
                .Top = 0
                .Left = 0
            End With

            With TreeView1
                .Parent = Panel_devant
                .Top = 0
                .Left = 0
            End With
            Button1.Visible = True
            ' BB 231009

            If b1pad Then
                With TreeView1
                    .ExpandAll()
                    .Visible = True
                End With
                Panel_glob_devant.Visible = True
                ' BB 231009
                Panel_devant.Visible = True
                PanelB.Visible = True
                PanelC.Visible = True

            End If
            If b1pad = False Then ' BB 231009
                With TreeView1
                    .CollapseAll()
                    .Visible = False
                End With
                Panel_devant.Visible = False
                Panel_glob_devant.Visible = False

            End If
            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
            RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width

            DefinirHauteurButtonGaucheEtAutres()

            ' il faut que à ce stade( avant create_panelboxes)
            ' nb_emissions_for_ce_Soir et
            ' nb_emissions_for_maintenant soient calculés.
            Panel_glob_devant.Width = TreeView1.Width + 2 * Parametre
            Panel_devant.Width = TreeView1.Width + 1 * Parametre

            ' calcul de nb_emissions_for_ce_soir 
            Panel_ce_soir.Controls.Clear()
            ' 070110 Get_number_Of_Emissions_For_ce_soir()
            Get_List_Of_Emissions_For_ce_soir()

#If DEBUG Then ' bloc impressions
            Trace.WriteLine(DateTime.Now & " " & "Liste des émissions Maintenant ")
            Trace.WriteLine(" ")

            ' impression des 10 prem. et 10 dern. emissions de ce soir
            Dim q As Integer
            For q = 0 To Math.Min(10, nb_emissions_for_Maintenant - 1)
                Trace.WriteLine( _
                                 DateTime.Now & " " & "i=" & q.ToString & " cha_id=" & _
                                 tableau_list_emissions_Maintenant(q).ChannelID & " pstart=" & _
                                 tableau_list_emissions_Maintenant(q).pstart & " dur.=" & _
                                 tableau_list_emissions_Maintenant(q).Pduration & "  " & _
                                 tableau_list_emissions_Maintenant(q).Ptitle)
            Next q
            Trace.WriteLine(" ")
            For q = Math.Max(0, nb_emissions_for_Maintenant - 10) To Math.Max(0, nb_emissions_for_Maintenant - 1)
                Trace.WriteLine( _
                                 DateTime.Now & " " & "i=" & q.ToString & " cha_id=" & _
                                 tableau_list_emissions_Maintenant(q).ChannelID & " pstart=" & _
                                 tableau_list_emissions_Maintenant(q).pstart & " dur.=" & _
                                 tableau_list_emissions_Maintenant(q).Pduration & "  " & _
                                 tableau_list_emissions_Maintenant(q).Ptitle)
            Next q
            Trace.WriteLine(" ")
#End If

            ' calcul de nb_emissions_for_maintenant 6
            DATETIMENOW = Date.Now().ToString("yyyy-MM-dd HH:mm:ss")

#If DEBUG Then
            Trace.WriteLine(DateTime.Now, " " & " requete emissions maintenant")
            Trace.WriteLine(DateTime.Now & " " & str_sql_Maintenant)
#End If
            Panel_maintenant.Controls.Clear()
            Get_number_Of_Emissions_For_Maintenant()
            CreatePanelboxes()

            NbMaxChaineEcran = CInt((-PanelD.Bottom + ButtonBas1.Top) / periodicite_verticale) + 1

            Trace.WriteLine(DateTime.Now & " " & "nb_max chaine ecran = " & NbMaxChaineEcran.ToString)
            Trace.WriteLine( _
                             DateTime.Now & " " & "nb de chaines differentes selectionnées à la mise a jour =" & _
                             nombre_de_chaines_differentes.ToString)

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

            Central_Screen.Pixels_Non_Utilisés_Pour_Les_emissions()

            ConstantsWidestScreen()

            ' calcul de largeur_max_panelA pour les 8  cas de figure(000,010,100,...
            CalculLargeurMaxPanelA()

            DessineLigneTemps()

            DeplacerPanelA()

            Central_Screen.Initialisations_Diverses()

            AffichageCeSoir()

            PanelE.BringToFront()
            Trace.WriteLine(DateTime.Now & " " & "démarrage timer minute")

            ' creer panel_titre_maintenant.item(0) avant l appel
            ' de  LanguageCheck()               
            Dim box2 As New Button
            Dim i As Integer

            With box2
                .Left = 0
                .Top = val_top_Maintenant(i)
                .Height = hauteur_richtextbox
                .Width = Calendar.Width
                .Text = "Maintenant  "
                val_backcolor_Maintenant(0) = Color.LightGray
                .BackColor = val_backcolor_Maintenant(i)
                .ForeColor = Color.White
                .TextAlign = ContentAlignment.MiddleLeft
            End With

            Trace.WriteLine( _
                             DateTime.Now & " " & "Left = " & val_left_cesoir_maintenant.ToString & " top = " & _
                             val_top_Maintenant(0).ToString & " text= " & tableau_list_emissions_Maintenant(0).Ptitle)
            Try
                Panel_titre_maintenant.Controls.Add(box2)
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & "Exception = " & ex.ToString)
            End Try

            Dim s1 As String

            SMaintenant = " Maintenant   "
            s1 = Panel_titre_maintenant.Controls.Item(0).Text & "   "
            Maintenant_et_heure = s1

            ' Init ouvre le fichier english.lng ou francais.lng ou lng d une autre langue
            ' et attribue les valeurs de contantes comme lngshortfilm, lngdebate....
            Trace.WriteLine(DateTime.Now & " " & "LanguageCheck Dans Mainform Load")
            LanguageCheck()

            ' remplir l arbre treenode avec ses categories
            With TreeView1.Nodes.Item(0)
                .Text = lngNodeFilter
                .Nodes.Item(0).Text = lngNodeCategory & " (" & nb_total_type_emission.ToString & _
                                                               ")"
                .Nodes.Item(1).Text = lngNodeCountry
                .Nodes.Item(2).Text = lngNodeProvider
            End With

            ' remplit (entre autres)  panel_titre_maintenant.item(0).text
            SMaintenant = Panel_titre_maintenant.Controls.Item(0).Text

            AffichageMaintenant()

#If DEBUG Then
            Trace.WriteLine(DateTime.Now & " " & "l1 = " & l1.ToString)
            Trace.WriteLine(DateTime.Now & " " & "l2 = " & l2.ToString)
            Trace.WriteLine(DateTime.Now & " " & "l3 = " & l3.ToString)
            Central_Screen.Ecriture_panelboxes()
            write_panelC_location()
#End If
            WritePanelbLocation()
            Dim numeroDEmission As Integer
            Dim nbPixels As Integer
            RichTextBoxDescrip.SuspendLayout()
            nbPixels = -PanelA.Left + inutilise_a_gauche(synth_boutons)
            date_origine_ecran = _
                date_reference.AddMinutes((30 * nbPixels) / nb_pixels_pour_30_minutes).AddHours(decal_horaire)
            num_emission_visible = 1
            numeroDEmission = _
                Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_origine_ecran)

            While flag_emission_not_found AndAlso num_chaine_haut_ecran < nombre_de_chaines_differentes
                Trace.WriteLine(DateTime.Now & " " & "On a incrémenté num_chaine Haut écran volontairement")
                num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
                num_chaine_haut_ecran += 1
            End While

            If num_emission_visible = 400 Then
                Trace.WriteLine(DateTime.Now & " " & "On a trouve aucune emission visible dans la tranche horaire")
                Trace.WriteLine(DateTime.Now & " " & "!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
                Trace.WriteLine(" ")
                num_emission_visible = 20
                Trace.WriteLine(DateTime.Now & " " & "num_emission visible fixe arbirairement a 20")

                ' Néo 17/09/2010 Le fichier est corrompu
                Dim BoxFichierCorrompu As DialogResult
                BoxFichierCorrompu = _
                    MessageBox.Show( _
                                     MessageFichierCorrompu, MessageFichierCorrompuTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

            nom_fichier_logo = tableau_chaine(num_chaine_haut_ecran).logo
            DrawLogoInPictureboxlogo(nom_fichier_logo)
            Trace.WriteLine(DateTime.Now & " " & "composer message descrip")
            Central_Screen.ComposerMessageDescrip(numeroDEmission, "principale")
            PanelB.Select()

            ' permettre le mousewheel pour changer
            ' les chaines affichees
            AfficherDateOrigineEcran()
            ResumeLayout()

        End If

        Trace.WriteLine( _
                         DateTime.Now & " " & _
                         "On est dans le mainform repere 1  avant un Central_Screen.examine_memory()")

        ' Verifier les conditions pour voir si une mise a jour automatique est possible
        ' Néo 06/07/11
        If _
            (My.Settings.URLChecked AndAlso
             (Not (Not My.Settings.Lienmiseajour Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Lienmiseajour)))) Then 'OrElse
            '(My.Settings.DIRChecked AndAlso
            '(Not _
            '('Not My.Settings.Cheminmiseajour Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Cheminmiseajour)))) OrElse
            'My.Settings.Epgdata Then

            ToolStripAutoUpdate.Enabled = True
            ToolStripMenuOptionsAutoUpdate.Enabled = True
        Else
            ToolStripAutoUpdate.Enabled = False
            ToolStripMenuOptionsAutoUpdate.Enabled = False
        End If

        IniCalendrier(Date.Now)

        If Not File.Exists(ChannelSetPath & "ZGuideTVDotNet.channels.set") Then
            initier_channels_set()
        End If

        Trace.WriteLine( _
                         DateTime.Now & " " & "On met a jour la compensation dans la ToolStatusStrip : " & _
                         My.Settings.decalage_horaire)

        With My.Settings
            Select Case .decalage_horaire
                Case Is > 0
                    ToolStripStatusLabelMinutes.Text = "+" & .decalage_horaire & " m."
                Case Is < 0
                    ToolStripStatusLabelMinutes.Text = "-" & .decalage_horaire.ToString & " m."
                Case 0
                    ToolStripStatusLabelMinutes.Text = "Off"
            End Select
        End With

        Trace.WriteLine(DateTime.Now & " " & "On met a jour le nom du moteur actif dans la ToolStatusStrip")
        Dim engine As Integer
        engine = My.Settings.EngineSelection

        With ToolStripStatusLabelEngine
            Select Case engine
                Case 1
                    .Text = lngToolStripStatusLabelTHEDVB
                Case 2
                    .Text = lngToolStripStatusLabelIMDB
                Case 3
                    .Text = lngToolStripStatusLabelALLOCINE
            End Select
        End With

        ' On affiche le flux rss dans la StatusStrip
        Rssfeed()

        ' Pour Windows 7 seulement et > : Mise à jour de la taskbar
        ' Lancement de tâches (K!TV,etc...)
        If ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6) AndAlso _
           TaskbarManager.IsPlatformSupported Then

            ' On crée un thread pour l'affichage de la jumplist
            Dim myjumplistThread As Thread = New Thread(AddressOf Myjumplist)
            Trace.WriteLine(DateTime.Now & " " & "On lance le Thread de la Myjumplist")
            With myjumplistThread
                .IsBackground = True
                .Start()
            End With
        End If

        'On affiche l'heure dans la StatusStrip
        Trace.WriteLine(DateTime.Now & " " & "Timer_seconde.Start()")
        Timer_seconde.Start()

        ' On affiche la mémoire utilisée par zg et la mémoire totale dans la StatusStrip
        ' Usage_Memory()
        Trace.WriteLine(DateTime.Now & " " & "TimerUsageMemory.Start()")
        TimerUsageMemory.Start()

        'On affiche la météo dans la StatusStrip
        'Image par défaut
        ToolStripStatusLabelWeatherImage.BackgroundImage = My.Resources.mostly_sunny

        WeatherUpdate()

        ' On regarde dans la base de registre si iMON est installé
        ' Si oui on affiche l'icone dans la StatusStrip
        If (Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\SOUNDGRAPH", "iMON", "")) IsNot Nothing Then
            ToolStripStatusLabeliMON.Image = My.Resources.imon
            ToolStripStatusLabeliMON.Visible = True
        Else
            ToolStripStatusLabeliMON.Visible = False
        End If

        'Néo 29/08/2010 On met a jour l'état de la connection internet dans la StatusStrip
        Try
            With ToolStripLabelStatusInternet
                If IsNetConnectOnline() Then
                    .Image = My.Resources.connect
                Else
                    .Image = My.Resources.disconnect
                End If
            End With
        Catch ex As WebException
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            ToolStripLabelStatusInternet.Image = My.Resources.disconnect
        End Try

        'Néo 29/08/2010 On met a jour l'état de la reprise de veille dans la StatusStrip
        Try
            With ToolStripStatusLabelWakeUp
                Select Case My.Settings.ResumeChecked
                    Case 1
                        .Image = My.Resources.asteriskrouge
                    Case 0
                        .Image = My.Resources.asterisk
                End Select
            End With
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            ToolStripStatusLabelWakeUp.Image = My.Resources.asteriskrouge
        End Try

        With ToolStripStatusLabelAudio
            Select Case My.Settings.AudioOn
                Case True
                    .Image = My.Resources.sound
                Case Else
                    .Image = My.Resources.soundmute
            End Select
        End With

        Trace.WriteLine(DateTime.Now & " " & "Mainform Me.Show")
        Show()

        ' Ce DoEvents permet de ne pas voir les controles qui se dessinent à l'écran avant
        ' d'afficher ZGuideTV
        Application.DoEvents()
        Trace.WriteLine(DateTime.Now & " " & "Mainform Me.Opacity = 100")
        Opacity = 100

        ' On fait passer le mainform en foreground (remplace l'ancien focus et activate)
        Trace.WriteLine(DateTime.Now & " " & "On fait passer le mainform en foreground")
        Dim hWnd As IntPtr = Handle
        SetForegroundWindow(hWnd)

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
            DateMajBack = datemaj
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

                        Application.DoEvents()

                        ' Ajout de Néo le 16/02/2010
                        ' On teste si l'URL de mise à jour auto est accessible pour éviter que cela plante
                        If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable(My.Settings.Lienmiseajour) Then

                            Try
                                If My.Settings.AudioOn Then
                                    ' le volume va de 0 (max) à -10000 (min)
                                    Dim audioPlay As Audio
                                    audioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                                    audioPlay.Volume = My.Settings.MessagesVolume
                                    audioPlay.Play()
                                End If
                            Catch ex As DirectXException
                                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                            End Try

                            Dim boxMiseaJour As DialogResult
                            boxMiseaJour = MessageBox.Show _
                                (MessageBoxMiseaJour & Chr(13) & MessageBoxMiseaJour1, _
                                 MessageBoxMiseaJourTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                 MessageBoxDefaultButton.Button1)

                            If boxMiseaJour = Windows.Forms.DialogResult.Yes Then
                                Trace.WriteLine(DateTime.Now & " " & "entree dans maj_grille_tv")

                                If My.Settings.Epgdata Then
                                    'downloadMT()
                                Else
                                    MajGrilleTv()
                                End If

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
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "redemarrage du timer_minute " & _
                                                 DateTime.Now.ToString)
                                'BB240609

                                Timer_wait.Start()
                                'BB 220610
                                Timer_wait.Enabled = True
                                AppliRestart = True
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "on attend l interrupt timer_wait  pour restarter l application")
                            Else
                                Trace.WriteLine(DateTime.Now & " " & "la mise a jour auto a échoué")
                                Dim _
                                    error7_majauto As String = _
                                        "La mise a jour full auto a echoué et sera effectuée plus tard"
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "La mise a jour full auto a echoué et sera effectuée plus tard")
                                Dim fenMessage As New Message(error7_majauto, MsgBoxStyle.Critical, True)
                                fenMessage.ShowDialog()

                                ' recuperer la BDD sauvegardée?

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

        '------------------------------------------------------------
        ' vérification auto de la version de zguidetv.exe
        ' On regarde si dans les préfs on a activé la vérif auto
        '------------------------------------------------------------
        If My.Settings.Autoverif = 1 Then
            Trace.WriteLine(DateTime.Now & " " & "verification auto de la version de zguidetv.exe")
            Dim datemajverif As String
            Dim datesaveverif As Date
            ' date de la dernière vérification
            Dim diffjourverif As Long
            ' différence de date entre la dernière vérification et maintenant
            Dim jourrestantverif As String
            ' nombre de jours restant avant la prochaine vérification
            Dim verifinterval As Integer
            ' intervalle de vérification en jour(s)
            verifinterval = My.Settings.intervalverif
            datemajverif = My.Settings.datemajverif
            ' date dernière vérification
            ' vérification des mises à jour

            Try
                If Not (Not datemajverif Is Nothing AndAlso String.IsNullOrEmpty(datemajverif)) Then
                    datesaveverif = CDate(datemajverif)
                    diffjourverif = DateDiff(DateInterval.Day, datesaveverif, Date.Now)
                    ' différence en jours
                    jourrestantverif = Str(verifinterval - diffjourverif)
                    ' calcul du nombre de jours restant
                    ' Si on a dépassé la date de vérification
                    ' (jourrestant <= 0)et vérification
                    ' auto activée on lance une vérification

                    If Val(jourrestantverif) <= 0 AndAlso My.Settings.Autoverif = 1 Then

                        My.Settings.datemajverif = (Date.Now).ToString
                        My.Settings.Save()

                        If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://zguidetv.tuxfamily.org/") Then
                            ' maj de la version de zguidetv.exe
                            MiseaJourAutoExe = True
                            XMLParser()
                            Trace.WriteLine(DateTime.Now & "vérification auto effectuée au démarrage de zguide")
                        End If
                    End If
                End If

                ' Si aucune vérif n'a été effectuée on sauvegarde
                ' la date actuelle
                If (Not datemajverif Is Nothing AndAlso String.IsNullOrEmpty(datemajverif)) Then
                    My.Settings.datemajverif = (Date.Now).ToString
                    My.Settings.Save()
                End If
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & "Echec lors de la vérif auto au démarrage de zguide")
            End Try

        End If
        Trace.WriteLine(DateTime.Now & " " & "on va entrer dans MaJ_Date_StatusBar ")
        MaJDateStatusBar()
        Trace.WriteLine(DateTime.Now & " " & "fin mise a jour date status bar")

        'rvs75 : 30/07/2010 ajout style sur bouton
        navigtemporelle.old_UI = CBool(My.Settings.oldUI)

        Central_Screen.Curseur_Vertical()

        Trace.WriteLine(DateTime.Now & " " & "sortie de curseur_vertical")
        ' On crée une erreur pour tester les routines try catch
        'Dim moi(2) As String
        'Dim lui As String = moi(4)

        With Timer_minute
            .Start()
            .Enabled = True
        End With

        recuperer_emissions_marquees()

        Memoire_Clean()

        ' Néo le 05/09/2010
        ' Purge des fichiers obsolètes
        purge.purge()

        Trace.WriteLine(DateTime.Now & " " & "on sort de la SR mainform load --------------------------------------------------------->")
    End Sub
#End Region

    <DllImport("user32.dll")>
 _
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

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

                    Dim datePourReveil As Date = trouver_emission_reveil()

                    'On récupère le date et l'heure de l'émission marquée
                    Dim rappelEmission As String
                    rappelEmission = CStr(datePourReveil)
                    Dim _
                        rappelDateHeure As Date = _
                            (CDate((FormatDateTime(CDate(rappelEmission), DateFormat.GeneralDate).ToString)))
                    rappelDateHeure = DateAdd("n", -My.Settings.ResumeBefore, rappelDateHeure)
                    Trace.WriteLine(DateTime.Now & " " & "Heure de réveil : " & rappelDateHeure)

                    Try
                        Dim wup As New WakeUP()
                        ' On envoie la date et l'heure à laquelle le pc doit se réveiller
                        Trace.WriteLine( _
                                         DateTime.Now & " " & _
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
            Dim hWnd As IntPtr = Handle
            SetForegroundWindow(hWnd)

            Application.DoEvents()

            Dim BoxResume As DialogResult
            BoxResume = MessageBox.Show _
                (MessageBoxResume & Chr(13) & MessageBoxResume1, _
                 MessageBoxResumeTitre, MessageBoxButtons.OK, MessageBoxIcon.Information, _
                 MessageBoxDefaultButton.Button1)
        End If
    End Sub
#End Region

#Region "trouver_emission_reveil"
    Private Function trouver_emission_reveil() As Date
        Dim marquedFile As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
        'Dim repereLigne As Integer = -1
        ' On regarde si le fichier ZGuideTVDotNet.marked.set existe
        If File.Exists(marquedFile) Then

            Dim streamEmissionMarquee As StreamReader = New StreamReader(marquedFile)

            Dim strligne As String = streamEmissionMarquee.ReadToEnd
            Trace.WriteLine(DateTime.Now & " " & "strligne : " & strligne)

            streamEmissionMarquee.Close()

            ' On regarde si le fichier n'est pas vide
            If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then

                Dim tabDebutEmission(25) As Date
                ' Tableau des dates ultérieures a NOW
                Dim longueurTotal As Integer = strligne.Length
                ' Longueur totale de strligne
                Dim indice As Integer = 0
                ' Position dans tab_debut_emission
                Dim dateReveil As Date
                'On récupère le date et l'heure de l'émission marquée
                Dim rappelEmission As String
                Dim arreter As Boolean = False
                Dim indiceLimite As Integer = -1
                Dim pos As Integer
                ' Position dans la chaine de la sous chaine recherchée
                While arreter = False
                    rappelEmission = strligne.Substring(0, 19)
                    ' Extraire la date du solde de la chaine
                    Dim _
                        rappelDateHeure As Date = _
                            (CDate((FormatDateTime(CDate(rappelEmission), DateFormat.GeneralDate).ToString)))
                    If rappelDateHeure > DateTime.Now Then
                        tabDebutEmission(indice) = rappelDateHeure
                        indice += 1
                        indiceLimite = indice - 1
                        ' Calculer la position de nouvelle date (juste avant le deuxième sigle §)
                        ' Repérer le sigle §§§
                        pos = strligne.IndexOf("§§§")
                        If pos < 0 Then
                            arreter = True
                            Exit While
                        End If

                        ' Eliminer ce qui se trouve avant ces '§§§
                        strligne = Mid(strligne, pos + 4, longueurTotal - pos - 4)
                        longueurTotal = strligne.Length
                        ' Rechercher '§" qui suit la date de début d'émission 
                        ' la date de début d'émission fait 19 caractères plus un espace avant de se trouver à '§'
                        pos = strligne.IndexOf("§") - 19
                        If pos < 0 Then
                            arreter = True
                            Exit While
                        End If
                        longueurTotal = strligne.Length
                        If longueurTotal < 19 Then Exit While
                        strligne = Mid(strligne, pos + 1, longueurTotal - pos - 1)
                        ' strligne commence par la date de début et on a supprimer une ligne entière
                        longueurTotal = strligne.Length
                        ' On doit arrêter si on ne trouve plus une occurence de ""§§§""
                        If strligne.IndexOf("§§§") = -1 Then arreter = True
                    Else
                        pos = strligne.IndexOf("§§§")
                        If pos < 0 Then
                            arreter = True
                            Exit While
                        End If
                        strligne = Mid(strligne, pos + 4, longueurTotal - pos - 4)
                        longueurTotal = strligne.Length
                        pos = strligne.IndexOf("§") - 19
                        If pos < 0 Then
                            arreter = True
                            Exit While
                        End If
                        longueurTotal = strligne.Length
                        If longueurTotal < 19 Then Exit While
                        ' Il n y a plus de date de début
                        strligne = Mid(strligne, pos + 1, longueurTotal - pos - 1)
                        longueurTotal = strligne.Length
                        ' On doit arrêter si on ne trouve plus une occurence de ""§§§""
                        If strligne.IndexOf("§§§") = -1 Then arreter = True
                    End If
                End While

                ' A ce stade, tab_debut d'émission contient les dates supérieures a Now
                ' reste à trouver la plus petite de ces dates
                dateReveil = DateTime.Now.AddDays(1)
                If indiceLimite = 0 Then dateReveil = tabDebutEmission(0)

                Dim i As Integer
                For i = 0 To indiceLimite - 1
                    If tabDebutEmission(i) < tabDebutEmission(i + 1) Then ' Choisir la plus petite
                        dateReveil = tabDebutEmission(i)
                    Else
                        dateReveil = tabDebutEmission(i + 1)
                        ' Choisir la plus petite
                    End If
                Next
                Return dateReveil
            End If
        Else
            ' Il ne faut pas reveiller le pc car il n y a pas d'émission marquée 
            ' avec une heure de commencement supérieure à datetime.now
            ' retourner la date de demain , même heure
            Return DateTime.Now.AddDays(1)
        End If
    End Function
#End Region

    Private Sub WakeUpWoken(ByVal sender As Object, ByVal e As EventArgs)
        ' DO NOT DELETE
    End Sub

    Sub LoaderShow()
        With LbLoader1
            .Visible = True
            .Top = Panel_date.Bottom + (PanelE.Top - Panel_date.Bottom - .Height) \ 2
            .Left = ButtonGauche.Right + (ButtonDroit.Left - ButtonGauche.Right - .Width) \ 2
            .BringToFront()
        End With
    End Sub

    Sub LoaderHide()
        With LbLoader1
            .Visible = False
            .SendToBack()
        End With
    End Sub

#Region "WeatherUpdate"
    Sub WeatherUpdate()

        'Néo le 21/07/2010
        If IsNetConnectOnline() Then
            'On affiche la météo dans la ToolStatusStrip
            Trace.WriteLine(DateTime.Now & " " & "On met a jour la météo dans la ToolStatusStrip")

            With My.Settings
                If (Not .WeatherCity Is Nothing AndAlso String.IsNullOrEmpty(.WeatherCity)) Then
                    ' Si aucune ville, on géolocalise la ville
                    If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://ipinfodb.com/") Then
                        Dim xmlvalue As String = String.Empty
                        .WeatherCity = GetCityByIp(xmlvalue)
                    End If
                End If
            End With

            With My.Settings
                If (Not .WeatherCity Is Nothing AndAlso String.IsNullOrEmpty(.WeatherCity)) Then
                    ' Si la géolocalisation n'a pas trouvé la ville on indique Paris par défaut
                    .WeatherCity = "Paris"
                End If
            End With

            WeatherMain()

            If WeatherError = True Then
                ToolStripStatusLabelWeather.Text = WeatherInformation
                Exit Sub
            End If

            If My.Settings.WeatherFahrenheit = False Then
                ToolStripStatusLabelWeather.Text = My.Settings.WeatherCity & ", " _
                                                   & WeatherCelsiusNow & " °C. " & WeatherConditionNow & "."
            Else
                ToolStripStatusLabelWeather.Text = My.Settings.WeatherCity & ", " _
                                                   & WeatherFahrenheitNow & " °F. " & WeatherConditionNow & "."
            End If
        Else
            ToolStripStatusLabelWeather.Text = WeatherInformation
        End If

        Trace.WriteLine(DateTime.Now & " " & "On sort de ma mise à jour météo")
    End Sub
#End Region

#Region "GetCityByIp"
    Private Function GetCityByIp(ByVal ipAddress As String) As String

        ' Modifié le 20/01/2011 (api v2)
        Dim _
            ipResponse As String = _
                IpRequestHelper( _
                                 "http://api.ipinfodb.com/v2/ip_query.php?key=d326deefead2f439484cee0a52ac954f385b5c18a6a81f96c53869341e8618c8&ip=", _
                                 ipAddress & "&timezone=false")

        Dim ipInfoXml As XmlDocument = New XmlDocument()
        ipInfoXml.LoadXml(ipResponse)
        Dim responseXml As XmlNodeList = ipInfoXml.GetElementsByTagName("Response")

        Dim dataXml As NameValueCollection = New NameValueCollection()

        dataXml.Add(responseXml.Item(0).ChildNodes(5).InnerText, responseXml.Item(0).ChildNodes(5).Value)

        Dim xmlValue As String = dataXml.Keys(0)

        Return xmlValue
    End Function
#End Region

#Region "IpRequestHelper"
    Private Function IpRequestHelper(ByVal url As String, ByVal ipAddress As String) As String
        'Dim checkURL As String = url & ipAddress

        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        Dim objResponse As HttpWebResponse = CType(objRequest.GetResponse(), HttpWebResponse)

        Dim responseStream As New StreamReader(objResponse.GetResponseStream())
        Dim responseRead As String = responseStream.ReadToEnd()

        With responseStream
            .Close()
            .Dispose()
        End With
        objRequest.Abort()
        objResponse.Close()
        Return responseRead
    End Function
#End Region

#Region "TimerUsageMemory"
    Private Sub TimerUsageMemoryTick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerUsageMemory.Tick

        ' On affiche la mémoire utilisée par zg et la mémoire totale dans la ToolStatusStrip
        Trace.WriteLine(DateTime.Now & " " & "on entre dans timer_usage_memory(1sec)")
        Trace.WriteLine( _
                         DateTime.Now & " " & _
                         "On affiche la mémoire utilisée par zg et la mémoire totale dans la ToolStatusStrip")

        Dim memoireTotale As Double = Math.Round(My.Computer.Info.TotalPhysicalMemory / 1024 ^ 2, 0)
        Dim memoireUtilisee As Double = Math.Round(Environment.WorkingSet / 1024 ^ 2, 0) / 2
        ToolStripStatusLabelMemoryUsage.Text = memoireUtilisee & " " & ToolStripStatusLabelMb & " / " & memoireTotale & _
                                               " " _
                                               & ToolStripStatusLabelMb
        Trace.WriteLine(DateTime.Now & " " & "memoire totale = " & memoireTotale.ToString)
        Trace.WriteLine(DateTime.Now & " " & "memoire utilisée = " & memoireUtilisee.ToString)
        Trace.WriteLine(DateTime.Now & " " & "on sort de timer_usage_memory(1sec)")
    End Sub
#End Region

    Public Sub GetEmHeight(ByVal e As PaintEventArgs)

        ' Création de la Font
        Dim emFontFamily As New FontFamily("arial")

        ' Hauteur de la Font en em
        Dim emHeight As Integer = _
                emFontFamily.GetEmHeight(FontStyle.Regular)

        ' Affiche le résultat
        e.Graphics.DrawString( _
                               "emFontFamily.GetEmHeight() returns " & emHeight.ToString(CultureInfo.CurrentCulture) & _
                               ".", _
                               New Font(emFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub

    ' Lancé lorsque un thread n'intercepte pas une exception qu'il a généré
    ' On affiche un message avec l'erreur d'exception non gérée
    Private Shared Sub ApplicationThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
        Try

            ExceptError = vbLf + vbLf + e.Exception.Message + e.Exception.StackTrace
            'MessageBox.Show(ExceptError)
            Feedback.ShowDialog()

        Finally
            Application.Exit()
        End Try
    End Sub

    Private Shared Sub CurrentDomainUnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Try
            Dim ex As Exception = CType(e.ExceptionObject, Exception)

            ExceptError = vbLf + vbLf + ex.Message + ex.StackTrace
            'MessageBox.Show(ExceptError)
            Feedback.ShowDialog()

        Finally
            Application.Exit()
        End Try
    End Sub

#Region "PositionneBoutonsMemorises"
    Private Sub PositionneBoutonsMemorises()
        Select Case synth_boutons
            Case 7
                Button1.Left = l1
                PanelB.Left = l1 + Button1.Width
                PanelC.Left = PanelB.Right
                ButtonGauche.Left = Button1.Right + largeur_logo_adaptee
                ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                Panel_glob_devant.Visible = True
            Case 6
                Button1.Left = l1
                ButtonGauche.Left = +l1 + l2 + Button1.Width
                ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                Panel_glob_devant.Visible = True
            Case 5
                Button1.Left = l1
                ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                ButtonGauche.Left = Button1.Right + largeur_logo_adaptee
                Panel_glob_devant.Visible = True
            Case 4
                Button1.Left = l1
                ButtonGauche.Left = Button1.Right + largeur_logo_adaptee
                ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                Panel_glob_devant.Visible = True
            Case 3
                Button1.Left = 0
                ButtonGauche.Left = l2 + Button1.Width
                ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
            Case 2
                Button1.Left = 0
                ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                ButtonGauche.Left = l2 + Button1.Width
            Case 1
                Button1.Left = 0
                ButtonGauche.Left = Button1.Width + PanelB.Width
                ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
            Case 0
                Button1.Left = 0
                ButtonGauche.Left = Button1.Width + PanelB.Width
                ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
            Case Else
                Trace.WriteLine( _
                                 DateTime.Now & _
                                 " problème de récupération de synthèse bouttons : valeur supérieure à 7 inacceptable")
        End Select
    End Sub
#End Region

#Region "AffichageCeSoir"
    Private Sub AffichageCeSoir()
        Dim kk1 As Integer
        Dim kk2 As Integer
        'Central_Screen.kill_handle(Panel_ce_soir)
        Panel_ce_soir.Controls.Clear()
        Get_List_Of_Emissions_For_ce_soir()
        kk1 = nb_emissions_for_ce_soir
        kk2 = nb_lignes_ce_soir
        Panel_ce_soir.Height = Math.Max(kk1, kk2) * periodicite_verticale


        ' 19/09/2009 rvs75 code rajouté dans  affichage_ce_soir
        ' afin de permettre la mise à jour de ce soir après minuit
        With Central_Screen
            .Fill_Tableaux_Top_Width_Left_ce_soir()
            .fill_color_of_richtextbox_ce_soir()
            .Affect_Richtextbox_ce_soir()
            .Affect_Logo_Picturebox_ce_soir(0)
        End With
    End Sub
#End Region

    Private Sub AffichageMaintenant(Optional ByVal forceRefresh As Boolean = False)

        ' 06/12/2009 rvs75 modif afin que le panel maintenant ne se mette à jour
        ' seulement s'il a une diférence entre la minute précédente et cette minute
        ' (n'affecte pas le démarrage)
        Dim blChangeMaintenant As Boolean = False
        If Not (forceRefresh) Then
            'Dim memo_ancien_tableau(tableau_list_emissions_Maintenant.Length - 1) As ce_soir
            Dim memoAncienTableau(tableau_list_emissions_Maintenant.Length - 1) As Emissions_List
            'rvs 
            Array.Copy(tableau_list_emissions_Maintenant, memoAncienTableau, tableau_list_emissions_Maintenant.Length)
            Get_List_Of_Emissions_For_Maintenant()
            For r As Integer = 0 To memoAncienTableau.Length - 1
                If memoAncienTableau(r).pstart <> tableau_list_emissions_Maintenant(r).pstart Then
                    blChangeMaintenant = True
                    Exit For
                End If
            Next

        Else
            blChangeMaintenant = True
        End If

        If blChangeMaintenant Then
            Dim s1 As String
            SMaintenant = lngPanelTitreMaintenant
            s1 = SMaintenant & "   "
            'Central_Screen.kill_handle(Panel_titre_maintenant)
            Panel_titre_maintenant.Controls.Clear()
            Maintenant_et_heure = s1
            DATETIMENOW = Date.Now().ToString("yyyy-MM-dd HH:mm:ss")
            'Central_Screen.kill_handle(Panel_maintenant)
            Panel_maintenant.Controls.Clear()
            With Panel_maintenant
                '.Controls.Clear()
                .Height = nb_emissions_for_Maintenant * periodicite_verticale
            End With

            With Central_Screen
                .Fill_Tableaux_Top_Width_Left_Maintenant()
                .fill_color_of_richtextbox_Maintenant()
                .Affect_Richtextbox_Maintenant()
                .Affect_Logo_Picturebox_Maintenant(0)
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
                    DirectCast(ctrEmission, PaveActuellement).rafraichir()
                End If
            Next
            Trace.WriteLine(DateTime.Now & " " & "redemarrage de timer minute")

            With Timer_minute
                .Start()
                .Enabled = True
            End With

        End If
    End Sub

    Private Sub WritePanelbLocation()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "PanelB.left = " & PanelB.Left.ToString)
        Trace.WriteLine(DateTime.Now & " " & "PanelB.right = " & PanelB.Right.ToString)
        Trace.WriteLine(DateTime.Now & " " & "PanelB.width = " & PanelB.Width.ToString)
#End If
    End Sub

    Private Sub RetourChainesInitiales()
        SuspendLayout()
        Trace.WriteLine(DateTime.Now & " Entree dans Retour_Chaines_Initiales")
        PutVisibleToTrueForPanelAButtons()
        tri_categorie = False

        If PanelA.Controls.Count <> 0 Then
            Central_Screen.Curseur_Vertical()
        End If

        Dim nbPixels As Integer

        RichTextBoxDescrip.SuspendLayout()
        nbPixels = -PanelA.Left + inutilise_a_gauche(synth_boutons)
        date_origine_ecran = _
            date_reference.AddMinutes((30 * nbPixels) / nb_pixels_pour_30_minutes).AddHours(decal_horaire)

        num_emission_visible = 1

        While flag_emission_not_found AndAlso num_chaine_haut_ecran < nombre_de_chaines_differentes '150210
            Trace.WriteLine(DateTime.Now & " " & "On a incrémenté num_chaine Haut écran volontairement")
            num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
            num_chaine_haut_ecran += 1
        End While

        If num_emission_visible = 400 Then ' 180210
            Trace.WriteLine(DateTime.Now & " " & "on n a trouve aucune emission visible dan sla tranche horaire")
            Trace.WriteLine(DateTime.Now & " " & "!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
            Trace.WriteLine(" ")
            num_emission_visible = 20
            Trace.WriteLine(DateTime.Now & " " & "num_emission visible fixe arbirairement a 20")

            ' Néo 18/09/2010 Le fichier est corrompu
            Dim boxFichierCorrompu As DialogResult = MessageBox.Show( _
                MessageFichierCorrompu, MessageFichierCorrompuTitre, MessageBoxButtons.OK, _
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End If

        nom_fichier_logo = tableau_chaine(num_chaine_haut_ecran).logo
        DrawLogoInPictureboxlogo(nom_fichier_logo)
        PanelB.Select()

        ' permettre le mousewheel pour changer les chaines affichees
        AfficherDateOrigineEcran()
        Trace.WriteLine(DateTime.Now & " Sortie de  Retour_Chaines_Initiales")
        ResumeLayout()
    End Sub

    Public Sub DeplacerPanelA()
        Dim deplacementTemps As New TimeSpan
        Dim entier As Double
        Trace.WriteLine(DateTime.Now & " " & "passage dans deplacer panelA")

        deplacementTemps = moment_souhaite.Subtract(date_reference)

        'rvs75 : 02/09/2010
        'Deplacement_temps peut être du type : 8:59:59:6544 au lieu de 9:00:00
        'entier = 2 * (deplacement_temps.Days * 24 + deplacement_temps.Hours)
        entier = Math.Round(deplacementTemps.TotalMinutes / 30)

        ' entier represente un nbre de tranche de 30 minutes
        ' entre moment souhaite et date de reference
        deplacement_panelA_en_pixels = CInt(entier * nb_pixels_pour_30_minutes)
        PanelA.Left = -deplacement_panelA_en_pixels + ButtonGauche.Right


        If decal_horaire < 0 Then
            ' on doit deplacer panelA vers la gauche
            PanelA.Left += CInt(decal_horaire * 2 * nb_pixels_pour_30_minutes)
        End If

        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "panelA.left = " & PanelA.Left.ToString)

        PanelD.Left = -deplacement_panelA_en_pixels + ButtonGauche.Right
        If decal_horaire > 0 Then
            PanelD.Left -= CInt(decal_horaire * 2 * nb_pixels_pour_30_minutes)
        End If

#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "On est dans déplacer panelA")
        Trace.WriteLine(DateTime.Now & " " & "Déplacement temps = " & deplacement_temps.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Déplacement panelA en pixels = " & deplacement_panelA_en_pixels.ToString)
        Trace.WriteLine(DateTime.Now & " " & "PanelA.left = " & PanelA.Left.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Longueur segment = " & longueur_segment.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Buttongauche.right = " & ButtonGauche.Right.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Date reference = " & date_reference.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Moment souhaité = " & moment_souhaite.ToString)
#End If
        PanelA.SendToBack()
        deplacementTemps = Nothing
    End Sub

    Private Sub ChercherDataEnMemoire()
        SuspendLayout()
        Timer_minute.Enabled = False
        DeplacerPanelA()
    End Sub

    Sub ChercherPremiereEmission()
        Central_Screen.Calcul_Date_Origine_Ecran()
        num_emission_visible = 1
        date_z = date_origine_ecran.AddHours(decal_horaire)
        num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)

        ' If flag_emission_not_found Then
        ' num_chaine_haut_ecran += 1
        ' Trace.WriteLine(DateTime.Now & " " & "On a incrémenté num_chaine Haut ecran volontairement")
        ' num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
        ' End If

        While flag_emission_not_found AndAlso num_chaine_haut_ecran < nombre_de_chaines_differentes
            Trace.WriteLine(DateTime.Now & " " & "On a incrémenté num_chaine Haut écran volontairement")
            num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
            num_chaine_haut_ecran += 1
        End While

        If num_emission_visible = 400 Then ' 180210
            Trace.WriteLine(DateTime.Now & " " & "on n a trouve aucune emission visible dansla tranche horaire")
            Trace.WriteLine(DateTime.Now & " " & "!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
            Trace.WriteLine(" ")
            num_emission_visible = 20
            num_chaine_haut_ecran = 1
            Trace.WriteLine(DateTime.Now & " " & "num_emission visible fixe arbirairement a 20")

            ' Néo 18/09/2010 Le fichier est corrompu
            Dim boxFichierCorrompu As DialogResult = MessageBox.Show( _
                MessageFichierCorrompu, MessageFichierCorrompuTitre, MessageBoxButtons.OK, _
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End If

        Trace.WriteLine( _
                         DateTime.Now & " " & "1ere emission visible = " & num_emission_visible.ToString & _
                         " pour la chaine " & num_chaine_haut_ecran.ToString)
        nom_fichier_logo = tableau_chaine(num_chaine_haut_ecran).logo
        If Not (Central_Screen.nom_fichier Is Nothing) AndAlso String.IsNullOrEmpty(Central_Screen.nom_fichier) Then
            nom_fichier_logo = Central_Screen.nom_fichier
        End If
        Trace.WriteLine(DateTime.Now & " " & "Logo name = " & nom_fichier_logo.ToString)
        DrawLogoInPictureboxlogo(nom_fichier_logo)
        Central_Screen.ComposerMessageDescrip(num_emission_visible, "principale")
        PanelA.SendToBack()
        If PanelA.Controls.Count <> 0 Then
            Central_Screen.Curseur_Vertical()
        End If
        AfficherDateOrigineEcran()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Date origine ecran = " & date_origine_ecran.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Moment souhaite = " & moment_souhaite.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Date_reference =  " & date_reference.ToString)
#End If
        ResumeLayout()
        Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
        'BB240609
        Timer_minute.Start()
        'BB 210610
        Timer_minute.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub PutVisibleToTrueForPanelAButtons()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " entree dans put_Visible_to_TRUE_for_panelA_buttons")
#End If
        Dim ctl As New Control
        For Each ctl In PanelA.Controls
            ctl.Visible = True
        Next ctl
        ctl = Nothing
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " sorie de put_visible_to_TRUE_for_panelA_buttons")
#End If
    End Sub

    Private Sub VisibleToFalseForChoosenControls()

        '        ' mettre a false la propriete visible des controles de PanelA
        '        ' dont la categorie
        '        ' ne correspond pas à celle choisie dans le tri
        '        Dim n1 As Integer
        '        Dim N As Integer
        '        Dim s1 As String
        '        n1 = nb_emissions_for_SQL_Request
        '        Trace.WriteLine(DateTime.Now & " émissions repondant à la categorie")
        '        Trace.WriteLine(DateTime.Now & " " & "categorie recherchee = " & categorie_choisie)
        '        categorie_choisie = categorie_choisie.ToLower
        '        For N = 1 To n1
        '            s1 = tableau_list_emissions(N).PcategoryTV.ToLower
        '            If s1 = categorie_choisie Then
        '#If DEBUG Then
        '                Trace.WriteLine(tableau_list_emissions(N).pstart.ToString)
        '#End If
        '            Else
        '                PanelA.Controls.Item(N + 1).Visible = False
        '            End If
        '        Next N


        Trace.WriteLine(DateTime.Now & " émissions repondant à la categorie")
        Trace.WriteLine(DateTime.Now & " " & "categorie recherchee = " & categorie_choisie)
        categorie_choisie = categorie_choisie.ToLower

        For Each lecontrol As Control In PanelA.Controls
            If TypeOf (lecontrol) Is PaveCentral Then
                Dim lecontrol2 As PaveCentral = DirectCast(lecontrol, PaveCentral)
                Dim theCategory As String = tableau_list_emissions(lecontrol2.TabIndex).PcategoryTV
                If Not (theCategory Is Nothing) AndAlso theCategory.ToLower <> categorie_choisie Then
                    lecontrol2.Visible = False
                Else
#If DEBUG Then
                                    Trace.WriteLine(tableau_list_emissions(N).pstart.ToString)
#End If

                End If
            End If
        Next
    End Sub

    Private Sub TrierSuivantCategorie()
        If filtre_non_autorise Then
            filtre_non_autorise = False
            Return
        End If
        Timer_minute.Enabled = False
        stop_timer = True

        If tri_categorie Then

            ' on enchaine 2 tris successifs
            PutVisibleToTrueForPanelAButtons()
        End If

#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Entree dans trier suivant categorie")
#End If
        Dim deplacementTemps As New TimeSpan
        Dim entier As Integer
        deplacementTemps = moment_souhaite.Subtract(date_reference)
        entier = 2 * (deplacementTemps.Days * 24 + deplacementTemps.Hours)
        deplacement_panelA_en_pixels = CInt(entier * nb_pixels_pour_30_minutes)
        moment_souhaite = date_reference
        PanelA.Left = -deplacement_panelA_en_pixels + ButtonGauche.Right
        PanelD.Left = -deplacement_panelA_en_pixels + ButtonGauche.Right
        depart_affichage = date_reference
        fin_affichage = depart_affichage.AddHours(nb_de_periodes_de_6h * Nb_heures_LigneTemps)
        date_origine_ecran = depart_affichage
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & _
"On vient juste de modifier les dates avant d'effectuer un rechargement de données")
        Trace.WriteLine(DateTime.Now & " " & "Date reference = " & date_reference.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Date origine_ecran = " & date_origine_ecran.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Moment souhaite = " & moment_souhaite.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Départ affichage = " & depart_affichage.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Fin affichage = " & fin_affichage.ToString)
#End If
        VisibleToFalseForChoosenControls()
        indice_courant_TLE = 1
        tri_categorie = True
        If PanelA.Controls.Count <> 0 Then
            Central_Screen.Curseur_Vertical()
        End If
        Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
        'BB240609
        With Timer_minute
            .Start()
            .Enabled = True
        End With
    End Sub

    Private Sub AfficherDateOrigineEcran()
        Dim s1 As String
        Dim n1 As Integer
        Dim da As New Date
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Entree SR afficher date origine")
#End If
        With Panel_date
            Select Case synth_boutons
                Case 7
                    .Width = l2
                Case 6
                    .Width = l2
                Case 5
                    .Width = PanelB.Width
                Case 4
                    .Width = PanelB.Width
                Case 3
                    .Width = l2
                Case 2
                    .Width = l2
                Case 1
                    .Width = PanelB.Width
                Case 0
                    .Width = PanelB.Width
            End Select
            .Left = Button1.Right
        End With
        'Central_Screen.kill_handle(Panel_date)
        Panel_date.Controls.Clear()
        Trace.WriteLine(DateTime.Now & " " & "Avant calcul date origine " & date_origine_ecran.ToString)
        Central_Screen.Calcul_Date_Origine_Ecran()
        Trace.WriteLine(DateTime.Now & " " & "Apres calcul date origine " & date_origine_ecran.ToString)
        da = date_origine_ecran
        n1 = da.DayOfWeek
        s1 = jour_semaine(n1) & " " & da.Day.ToString

        Dim richDateButton As New Button
        With richDateButton
            .Left = 0
            .Top = 0
            .Width = Panel_date.Width
            .Height = Panel_date.Height
            .Text = s1
            .Visible = False
            .BackColor = Color.White
        End With

        If DateTime.Now.DayOfYear <> date_origine_ecran.DayOfYear Then
            richDateButton.BackColor = Color.Red
        End If
        Try
            Panel_date.Controls.Add(richDateButton)
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try

        Panel_date.BringToFront()
    End Sub

    Public Sub InitialisationTraceListener()
        Trace.Listeners.Clear()

        ' supprimer tous les listeners et en particulier celui de la fenetre de sortie a l écran
        Trace.Listeners.Add(Tl)
        Trace.AutoFlush = True

        ' écrire immédiatement (sans délai) dans le tl
    End Sub

    Private Sub CaracteristiquesEcranEtMainform()
        hauteur_barre_menus = MenuStrip1.Bottom - MenuStrip1.Top
        hauteur_barre_outils = ToolStrip1.Bottom - ToolStrip1.Top
        largeur_ecran = My.Computer.Screen.Bounds.Right - My.Computer.Screen.Bounds.Left
        hauteur_ecran = My.Computer.Screen.Bounds.Bottom - My.Computer.Screen.Bounds.Top

        hauteur_mainform = Size.Height - CInt(hauteur_taskbar)
        largeur_mainform = Size.Width
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "hauteur barre outils = " & hauteur_barre_outils.ToString)
        Trace.WriteLine(DateTime.Now & " " & "hauteur barre menus = " & hauteur_barre_menus.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Largeur_ecran = " & largeur_ecran.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Hauteur_ecran = " & hauteur_ecran.ToString)
        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "Largeur_mainform = " & largeur_mainform.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Hauteur_mainform = " & hauteur_mainform.ToString)
#End If
    End Sub

    Private Sub ReferencesTemps()
        Dim deplacementTemps As New TimeSpan
        Dim entier As Integer
        deplacementTemps = moment_souhaite.Subtract(date_reference)
        entier = 2 * (deplacementTemps.Days * 24 + deplacementTemps.Hours)
        ' entier represente un nbre de tranche de
        ' 30 minutes entre moment souhaite et date de reference
        deplacement_panelA_en_pixels = CInt(entier * nb_pixels_pour_30_minutes)
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Date de référence = " & date_reference.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Moment souhaité = " & moment_souhaite.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Déplacement panelA en pixels = " & deplacement_panelA_en_pixels.ToString)
#End If
        deplacementTemps = Nothing
    End Sub

    Private Sub PremiereInitialisation()

        ' memorisation de listviewchannel.width pour recuperation future
        ListViewChannel.Width = reduced_listviewchannel_width
        l3 = Calendar.Width
        l2 = ListViewChannel.Width
        l1 = TreeView1.Width + 2 * Parametre
        ' 221009
        Button1.Left = 0
        ButtonGauche.Left = Button1.Right + largeur_logo_adaptee
        TreeView1.Visible = False
    End Sub

    Private Sub DefinirHauteurButtonGaucheEtAutres()

        Button1.Top = hauteur_barre_menus + hauteur_barre_outils
#If DEBUG Then
        Trace.WriteLine(" entree sub definir")
        Trace.WriteLine(" boutonbas1 lu dans les settings= " & My.Settings.boutonbas1.ToString)
#End If
        ' la position de bb1peh est memorisee dans my.settings.boutonbas1
        ' boutonbas1 vaut 1 quand le button bas1 est haut cad quand bb1peh =true
        ' boutonbas1 vaut 0 quand le button bas1 est bas cad quand  bb1peh = false
        ' au premier ,depart dans les settings, boutonbas1 vaut 1

        If My.Settings.boutonbas1 = 1 Then ' buttonbas1 est positionné en haut
            RichTextBoxDescrip.Top = Size.Height - RichTextBoxDescrip.Height - StatusStrip2.Height - _
                                     CInt(hauteur_taskbar)
            Trace.WriteLine(DateTime.Now & " " & "rich descrip.top = " & RichTextBoxDescrip.Top.ToString)
            RichTextBoxDescrip.Height = StatusStrip2.Location.Y - RichTextBoxDescrip.Location.Y
            MemoRichtextboxDescripHeight = RichTextBoxDescrip.Height
            My.Settings.memortbheight = MemoRichtextboxDescripHeight
            My.Settings.Save()

            Trace.WriteLine(DateTime.Now & " " & "richtextboxdescrip.height = " & RichTextBoxDescrip.Height.ToString)

            ButtonBas1.Top = RichTextBoxDescrip.Top - ButtonBas1.Height
            ' on fait une differencre entre
            ' richtextboxdescrip et pictureboxlogo pour leur valeur Top!!!!261109
            Trace.WriteLine(DateTime.Now & " " & "buttonbas1.top= " & ButtonBas1.Top.ToString)
            bb1peh = True
        Else
            Trace.WriteLine(DateTime.Now & " " & "boutonbas1 vaut 0")
            ' buttonbas1 positionné en bas
            With RichTextBoxDescrip
                .Visible = False
                .Height = My.Settings.memortbheight
            End With


            ' on definit d abord buttonbas1.top et puis richtexboxdescrip.top
            ButtonBas1.Top = StatusStrip2.Top - ButtonBas1.Height

            RichTextBoxDescrip.Top = ButtonBas1.Top + ButtonBas1.Height + StatusStrip2.Height + CInt(hauteur_taskbar)
            Trace.WriteLine(DateTime.Now & " " & "buttonbas1.top =" & ButtonBas1.Top.ToString)
            bb1peh = False

        End If

        ' pour ne pas tronquer la partie superieure des logo tres grands comm bbc one ....
        Trace.WriteLine(DateTime.Now & " " & "memo richtextbox.height =" & MemoRichtextboxDescripHeight.ToString)
        Panel_glob_maintenant.Height = StatusStrip2.Location.Y - Panel_glob_maintenant.Location.Y

        ' double emploi ButtonBas1.Top = RichTextBoxDescrip.Top - ButtonBas1.Height
        With PictureBoxLogo
            .Top = ButtonBas1.Bottom
            .Height = RichTextBoxDescrip.Height
        End With

        Button1.Height = ButtonBas1.Top - Button1.Top
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Button1.top  = " & Button1.Top)
        Trace.WriteLine(DateTime.Now & " " & "Button1.bottom  = " & Button1.Bottom)
        Trace.WriteLine(DateTime.Now & " " & "Button1.height  = " & Button1.Height)
        Trace.WriteLine(DateTime.Now & " " & "Nombre de periodes de 6 heures = " & nb_de_periodes_de_6h.ToString)
#End If
        ButtonGauche.Top = Button1.Top
        ButtonGauche.Height = Button1.Height
        ButtonDroit.Top = Button1.Top
        ButtonDroit.Height = Button1.Height
#If DEBUG Then
        ecrire_boutons_principaux()
#End If
        Trace.WriteLine(DateTime.Now & " " & "sortie sub definir")
    End Sub

    Private Sub CreatePanelboxes()

        ' logos: panelB
        ' emissions : panelbox A
        ' zone de mvt de souris : panelC
        ' ligne de temps superieure = panelbox D
        ' ligne de temps inferieure = panelbox E avec buttons activant
        ' le changement dans le temps
        ' affichage date : panel_date
        ' panel_droit est un panel qui contient: calendar,panel_glob_ce_soir,
        ' panel_glob_maintenant
        ' panel_glob_ce_soir contient : panel_titre_ce_soir, panel_ce_soir
        ' panel_glob_maintenant contient panel_titre_maintenant,
        ' panel_maintenant

        Trace.WriteLine(DateTime.Now & " " & "Entrée dans create panelboxes")
        If Size.Width > largeur_ecran Then
            erreurh = Size.Width - largeur_ecran
        End If

        ListViewChannel.Visible = False
        largeur_utile = Size.Width - Calendar.Width - largeur_boutons_verticaux - _
                        ButtonGauche.Right - erreurh

        SuspendLayout()
        hauteur_paves = CInt(hauteur_richtextbox * 0.8) + 5
        navigtemporelle.Height = hauteur_paves
        periodicite_verticale = hauteur_richtextbox + espace_entre_richtextbox

        nb_lignes_ce_soir = _
            (CInt( _
                (Panel_glob_maintenant.Top - Panel_glob_ce_soir.Top - Panel_titre_ce_soir.Height) / periodicite_verticale)) - _
            1

        With PanelB
            .Left = Button1.Right
            .Top = ButtonGauche.Top + 22
            .Height = ButtonGauche.Height - 22
            .Width = largeur_logo_adaptee
        End With

        With PanelC
            .Top = PanelB.Top
            .Left = PanelB.Right
            .Width = l2 - PanelB.Width - 10
            .Height = PanelB.Height
        End With

        With PanelD
            .Left = ButtonGauche.Right
            .Top = Button1.Top
            .Height = 22
        End With

        With Panel_cinema ' BB 030810
            .Top = PanelD.Bottom
            .Height = 2 * hauteur_richtextbox
            .Left = Button1.Right
            .Width = ButtonDroit.Left - Button1.Right
            .Visible = False
        End With


        With PanelE
            .Left = ButtonGauche.Right
            .Top = ButtonBas1.Top - hauteur_paves
            .Height = hauteur_paves
            .Width = Size.Width - Calendar.Width - largeur_boutons_verticaux - ButtonGauche.Right - erreurh
        End With

        PanelE.Width = Size.Width - Calendar.Width - largeur_boutons_verticaux - ButtonGauche.Right - erreurh
        If bdpad Then
            PanelE.Width += Calendar.Width
        End If
        navigtemporelle.Width = PanelE.Width
        PanelA.Top = PanelB.Top

        PanelA.Width = 200 + CInt(nb_de_periodes_de_6h * Nb_heures_LigneTemps * 2 * nb_pixels_pour_30_minutes)
        PanelD.Width = PanelA.Width

        With Panel_date
            .Left = Button1.Right
            .Width = ButtonGauche.Left - Button1.Right
            .Top = ButtonGauche.Top
            .Height = PanelD.Height
        End With

        ' panel_droit créé en mode design
        With panel_droit
            .Width = Calendar.Width
            .Left = ButtonDroit.Right
        End With

        ' imposer que panel_droit est parent de calendar,panel_glob_maintenenant et panel_glob_ce_Soir
        Panel_glob_maintenant.Parent = panel_droit
        Panel_glob_ce_soir.Parent = panel_droit
        Calendar.Parent = panel_droit

        With Panel_glob_ce_soir.Controls
            .Add(Panel_titre_ce_soir)
            .Add(Panel_ce_soir)
        End With

        With Panel_glob_maintenant.Controls
            .Add(Panel_titre_maintenant)
            .Add(Panel_maintenant)
        End With

        With Panel_titre_ce_soir
            .Top = 0
            .Left = 0
        End With

        ' par rapport à panel_glob_ce_soir
        With Panel_titre_ce_soir
            .Width = Calendar.Width
            .Height = periodicite_verticale
        End With

        Trace.WriteLine(DateTime.Now & " " & " ")
        Trace.WriteLine(DateTime.Now & " " & " ")
        Trace.WriteLine(DateTime.Now & " " & "Panel_titre_ce_soir  top       left   width   height")
        Trace.WriteLine( _
                         DateTime.Now & " " & Panel_titre_ce_soir.Top.ToString & "    " & _
                         Panel_titre_ce_soir.Left.ToString & "    " & Panel_titre_ce_soir.Width.ToString & "    " & _
                         Panel_titre_ce_soir.Height.ToString)

        With Panel_ce_soir
            .Top = Panel_titre_ce_soir.Bottom + espace_entre_richtextbox
            .Left = 0
            .Width = Calendar.Width
            .Height = nb_emissions_for_ce_soir * periodicite_verticale
        End With

        Trace.WriteLine(DateTime.Now & " " & "Panel_ce_soir  top     left     width     height")
        Trace.WriteLine( _
                         DateTime.Now & " " & Panel_ce_soir.Top.ToString & "    " & Panel_ce_soir.Left.ToString & "    " & _
                         Panel_ce_soir.Width.ToString & "    " & Panel_ce_soir.Height.ToString)

        With Panel_titre_maintenant
            .Top = 0
            .Left = 0
            .Width = Calendar.Width
            .Height = periodicite_verticale
        End With

        Trace.WriteLine(DateTime.Now & " " & "Panel_titre_maintenant  top   left     width     height")
        Trace.WriteLine( _
                         DateTime.Now & " " & Panel_titre_maintenant.Top.ToString & "    " & _
                         Panel_titre_maintenant.Left.ToString & "    " & Panel_titre_maintenant.Width.ToString & "    " & _
                         Panel_titre_maintenant.Height.ToString)

        With Panel_maintenant
            .Top = Panel_titre_maintenant.Bottom + espace_entre_richtextbox
            .Left = 0
            .Width = Calendar.Width
            .Height = (nb_emissions_for_Maintenant) * periodicite_verticale
        End With

        Dim tempo As Integer
        tempo = panel_droit.Height - Panel_glob_maintenant.Top
        reserve_depart = Panel_maintenant.Height - tempo + 15
        reserve = reserve_depart
        Trace.WriteLine(DateTime.Now & " " & "Panel_maintenant top       left       width       height")
        Trace.WriteLine( _
                         DateTime.Now & " " & Panel_maintenant.Top.ToString & "    " & Panel_maintenant.Left.ToString & _
                         "    " & Panel_maintenant.Width.ToString & "    " & Panel_maintenant.Height.ToString)

        With Controls
            .Add(PanelA)
            .Add(PanelB)
            .Add(PanelC)
            .Add(PanelD)
            .Add(PanelE)
            .Add(Panel_date)
        End With

        PanelC.Visible = True
        PanelB.Visible = True
        PanelA.Visible = True
        PanelD.Visible = True
        PanelE.Visible = True
        Panel_date.Visible = True

        panel_droit.Visible = True

        PanelC.Enabled = True
        PanelB.Enabled = True
        PanelA.Enabled = True
        PanelD.Enabled = True
        PanelE.Enabled = True
        Panel_date.Enabled = True

        Panel_ce_soir.Enabled = True
        Panel_maintenant.Enabled = True
        Calendar.Enabled = True
        Panel_titre_ce_soir.Enabled = False
        Panel_titre_maintenant.Enabled = False

        PanelConteneurs()

        PictureBoxLogo.Top = ButtonBas1.Bottom

        PanelD.Left = -deplacement_panelA_en_pixels + ButtonGauche.Right

        ' decalage horaire
        ' attention à ne pas decaler 2 x
        If decal_horaire < 0 Then ' on ne doit pas decaler panelA 
        Else ' decal_horaire >0  on doit  decaler panelA vers la gauche
            PanelA.Left = -deplacement_panelA_en_pixels + ButtonGauche.Right - _
                          CInt(decal_horaire * 2 * nb_pixels_pour_30_minutes)
            ' 040210
        End If

#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Dépl panelA en pixels = " & deplacement_panelA_en_pixels.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Buttongauche.right = " & ButtonGauche.Right.ToString)
        Trace.WriteLine(DateTime.Now & " " & "PanelA.left = " & PanelA.Left.ToString)
        Trace.WriteLine(DateTime.Now & " " & "PanelD.left = " & PanelD.Left.ToString)
#End If

        PanelA.SendToBack()
        Trace.WriteLine(DateTime.Now & " " & "PanelA.height = " & PanelA.Height.ToString)
        ResumeLayout()


#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "top            bottom          let        right        panelbox")
        Trace.WriteLine(DateTime.Now & " " & PanelA.Top.ToString & "          " & PanelA.Bottom.ToString & "          " _
                         & PanelA.Left.ToString & "            " & PanelA.Right.ToString)

        Trace.WriteLine(DateTime.Now & " " & PanelB.Top.ToString & "          " & PanelB.Bottom.ToString & "          " _
                         & PanelB.Left.ToString & "            " & PanelB.Right.ToString)

        Trace.WriteLine(DateTime.Now & " " & PanelC.Top.ToString & "          " & PanelC.Bottom.ToString & "          " _
                         & PanelC.Left.ToString & "            " & PanelC.Right.ToString)

        Trace.WriteLine(DateTime.Now & " " & PanelD.Top.ToString & "          " & PanelD.Bottom.ToString & "          " _
                         & PanelD.Left.ToString & "            " & PanelD.Right.ToString)

        Trace.WriteLine(DateTime.Now & " " & PanelE.Top.ToString & "          " & PanelE.Bottom.ToString & "          " _
                         & PanelE.Left.ToString & "            " & PanelE.Right.ToString)

        Trace.WriteLine(DateTime.Now & " " & "Largeur_utile = " & largeur_utile.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Echelle1 = " & echelle1.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Larg logo adaptee = " & largeur_logo_adaptee)
        Trace.WriteLine(DateTime.Now & " " & "Sortie de create panelboxes")
#End If
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
            'rvs75 11/09/2010 inutile car recalculer dans le resize
            '.Height = CInt((hauteur_mainform - ToolStrip1.Height - MenuStrip1.Height - StatusStrip2.Height - Calendar.Height) \ 2)
            .Width = Calendar.Width
        End With

        ' localiser panel_glob_maintenant dans panel_droit
        With Panel_glob_maintenant
            Panel_glob_maintenant.SendToBack()
            .Top = Panel_glob_ce_soir.Bottom
            .Left = 0
            'rvs75 11/09/2010 inutile car recalculer dans le resize
            '.Height = Panel_glob_ce_soir.Height
            '.Width = Panel_glob_ce_soir.Width
            .Width = Calendar.Width
        End With

        ' localiser panel_titre ce soir dans panel_glob_ce_soir
        With Panel_titre_ce_soir
            .Left = 0
            .Top = 0
            .Width = Calendar.Width
            .Height = periodicite_verticale
        End With

        ' localiser panel_ce soir dans panel_glob_ce_soir
        With Panel_ce_soir
            .Left = 0
            .Top = Panel_titre_ce_soir.Bottom
            '.Width = Panel_titre_ce_soir.Width
            .Width = Calendar.Width
            .Height = Panel_glob_ce_soir.Height - Panel_titre_ce_soir.Height
        End With

        ' localiser panel_titre_maintenant dans panel_glob_maintenant
        With Panel_titre_maintenant
            .Left = 0
            .Top = 0
            '.Width = Panel_titre_ce_soir.Width
            .Width = Calendar.Width
            .Height = periodicite_verticale
        End With

        ' localiser panel_maintenant dans panel_glob_maintenant
        With Panel_maintenant
            .Left = 0
            .Top = Panel_titre_maintenant.Bottom
            '.Width = Panel_titre_ce_soir.Width
            .Width = Calendar.Width
            .Height = Panel_glob_maintenant.Height - Panel_titre_maintenant.Height
        End With
    End Sub

    Private Sub ConstantsWidestScreen()

        ' lorsque treeview1 et panelC et monthcalendar sont invisibles,
        ' alors panelA  (partie reservée aux émissions)  a sa valeur
        ' maximale en pixels et vaut (60*nb d heures)  minutes cette echelle
        ' doit etre invariable pendant toute l' execution du programme
        panelA_point_width_max = larg_max_panelA(1)

        echelle1 = panelA_point_width_max / (60 * Nb_heures_LigneTemps)
        Trace.WriteLine(DateTime.Now & " " & "Périodicité verticale = " & periodicite_verticale.ToString)
        CoordY_Ligne_Temps = hauteur_barre_menus + hauteur_barre_outils + 4
        Longueur_Ligne_Temp = panelA_point_width_max
        nb_pixels_pour_30_minutes = CDec(Longueur_Ligne_Temp / (2 * Nb_heures_LigneTemps))
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans constants_widest_screen")
        Trace.WriteLine(DateTime.Now & " " & "PanelA maximum = " & panelA_point_width_max.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Nbre d heures max affichées = " & Nb_heures_LigneTemps.ToString)
        Trace.WriteLine(DateTime.Now & " " & "CoordY ligne temps = " & CoordY_Ligne_Temps.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Longueur_Ligne_Temp = " & Longueur_Ligne_Temp.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Nb_pixels_pour_30_minutes = " & nb_pixels_pour_30_minutes.ToString)
#End If
        Trace.WriteLine(DateTime.Now & " " & "Sortie de constants_widest_screen")
    End Sub

    Private Sub CalculLargeurMaxPanelA()

        ' suivant la valeur des 3 bits de positionnement
        ' button1,button gauche , button droit, cette sr definit la valeur
        ' max de la fenetre centrale ( de buttongauche à buttondroit
        With larg_max_panelA
            Select Case synth_boutons
                Case 0
                    largeur_max_panelA = (0)
                Case 1
                    largeur_max_panelA = (1)
                Case 2
                    largeur_max_panelA = (2)
                Case 3
                    largeur_max_panelA = (3)
                Case 4
                    largeur_max_panelA = (4)
                Case 5
                    largeur_max_panelA = (5)
                Case 6
                    largeur_max_panelA = (6)
                Case 7
                    largeur_max_panelA = (7)
            End Select
        End With
        PanelA.Width = 200 + CInt(nb_de_periodes_de_6h * Nb_heures_LigneTemps * 2 * nb_pixels_pour_30_minutes)
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Largeur max panelA modifiée = " & largeur_max_panelA.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Sortie de calcul largeur max panelA")
#End If
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
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Entrée dessine ligne temps")
        Trace.WriteLine(DateTime.Now & " " & "Date de référence = " & date_reference.ToString)
#End If
        PanelD.SuspendLayout()
        'Central_Screen.kill_handle(PanelD)
        PanelD.Controls.Clear()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Nbre de periodes de 6 heures = " & nb_de_periodes_de_6h.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Nbre d heures lignes temps = " & Nb_heures_LigneTemps.ToString)
        Trace.WriteLine(DateTime.Now & " " & "La ligne temps totale compte : " & (nb_de_periodes_de_6h * _
Nb_heures_LigneTemps).ToString & " heures")
#End If
        limit = (nb_de_periodes_de_6h * Nb_heures_LigneTemps * 2)
        ' pour avoir les demies heures
        For icount = 0 To limit
            Dim myTextboxTemps As New TextBox
            With myTextboxTemps
                .Location = New Point(CInt((nb_pixels_pour_30_minutes * icount)), 0)
                .Width = CInt(nb_pixels_pour_30_minutes)
                .Name = "TextTemp" & icount
                .Height = CInt(CoordY_Ligne_Temps)
                .BackColor = Color.White
                .Cursor = Cursors.Default
            End With
            pair = icount Mod 2
            Select Case pair
                Case 0
                    myTextboxTemps.Text = _
                        (date_reference.AddHours(icount \ 2)).ToString("HH:00", CultureInfo.CurrentCulture)
                    Trace.Write(myTextboxTemps.Text & "   ")
                Case Else
                    myTextboxTemps.Text = ""
            End Select
            With myTextboxTemps
                .TextAlign = HorizontalAlignment.Left
                .ReadOnly = True
            End With
            PanelD.Controls.Add(myTextboxTemps)
            ' Le panelD doit avoir la meme largeur que panelA et
            ' doit subir le meme decalage horizontal que panelA
        Next icount
        PanelD.Visible = True
        PanelD.ResumeLayout()
        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "Sortie dessine ligne temps")
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
        'Dim z As Double

        AffichageMaintenant()

        ' 19/09/2009 rvs75 code de mise à jour de ce soir
        ' après un  changement de jour
        If DateTime.Now.Hour = 0 AndAlso DateTime.Now.Minute = 0 Then
            AffichageCeSoir()
            MaJDateStatusBar()
        End If

        ' mets a jour maintenant mais pas titre_maintenant
        If WindowState = FormWindowState.Minimized Then
            Return
        End If

        'z = longueur_segment
        Dim y As Integer
        Dim d As Integer
        Const securite As Integer = 15
        d = ButtonDroit.Left - PanelA.Left
        y = longueur_segment

        My.Settings.RssFeedMinute = True
        Rssfeed()

        If y > (d - securite) Then
#If DEBUG Then
            Trace.WriteLine(DateTime.Now & " " & "On est passé a la valeur critique de fin d'écran")
            Trace.WriteLine(DateTime.Now & " " & "Position curseur = " & y.ToString)
            Trace.WriteLine(DateTime.Now & " " & "Valeur critique bout d'écran = " & d.ToString)
            Trace.WriteLine(DateTime.Now & " " & "Boutton droitleft " & ButtonDroit.Left.ToString)
#End If
            PanelA.Left -= CInt(larg_max_panelA(synth_boutons) * 0.75)
            PanelD.Left -= CInt(larg_max_panelA(synth_boutons) * 0.75)

            PanelA.SendToBack()
            Return
        Else
        End If
    End Sub

    Private Sub ButtonsVerticauxResumé(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ButtonDroit.Click, Button1.Click, ButtonGauche.Click

        ' remarque : une bouton positionné a droite est a true 
        ' il y a 3 boutons de poids =4 , 2 , 1 dans l'ordre pour 
        ' button1, buttongauche et buttondroit 
        ' b1    bg    bd
        ' 4      2     1 
        ' on mémorise, au 1er passage dans un des 3 boutons click verticaux: 
        ' les postions gauche de button1, buttongauche et buttondroit
        Dim deplacementSigne As Integer

        ' c est le deplacement à appliquer à panelA suite à l appui sur un
        ' bouton
        SuspendLayout()
        'Select Case first_button_click
        '    Case True
        '        memo_button_droit_point_left = ButtonDroit.Left
        '        memo_button_1_point_left = Button1.Left
        '        memo_button_gauche_point_left = ButtonGauche.Left
        '        first_button_click = False
        'End Select

        PanelB.Width = largeur_logo_adaptee
        PanelC.Width = l2 - PanelB.Width
        PanelC.Height = Button1.Height - 22
        PanelC.Top = PanelB.Top

        If sender Is Button1 Then
            If b1pad Then
                deplacementSigne = -l1
            Else
                deplacementSigne = +l1
            End If
            b1pad = Not (b1pad)
        End If

        If sender Is ButtonGauche Then
            If bgpad Then
                deplacementSigne = -PanelC.Width
            Else
                deplacementSigne = +PanelC.Width
            End If
            bgpad = Not (bgpad)
        End If

        If sender Is ButtonDroit Then
            deplacementSigne = 0
            bdpad = Not (bdpad)
        End If

        bgpad = False
        ' court circuiter buttongauche PROVISOIR

        synth_boutons = (CInt(b1pad) And 4) + (CInt(bgpad) And 2) + (CInt(bdpad) And 1)

        If Size.Width > largeur_ecran Then
            erreurh = Size.Width - largeur_ecran
        End If
        Select Case synth_boutons
            Case 7
                largeur_max_panelA = larg_max_panelA(7)
                Button1.Left = l1
                PanelB.Left = l1 + Button1.Width
                PanelC.Left = PanelB.Right
                ButtonGauche.Left = PanelC.Right
                ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                ButtonBas1.Width = Size.Width - erreurh
                TreeView1.Visible = True
                panel_droit.Visible = False
                ListViewChannel.Visible = False
                PanelC.Visible = True
                PanelB.Visible = True
                RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width
                ExpandTreeviewNodes()
            Case 6 ' 
                largeur_max_panelA = larg_max_panelA(6)
                Button1.Left = l1
                ButtonGauche.Left = l1 + l2 + Button1.Width
                ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                TreeView1.Visible = True
                panel_droit.Visible = True
                PanelC.Visible = True
                PanelB.Visible = True
                ListViewChannel.Visible = False
                PanelB.Left = l1 + Button1.Width
                PanelC.Left = PanelB.Right
                ButtonBas1.Width = Size.Width - Calendar.Width
                ButtonBas1.Width = ButtonDroit.Right
                RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width
                ExpandTreeviewNodes()
            Case 5
                Trace.WriteLine(DateTime.Now & " " & "synth bouton =5")
                Panel_glob_devant.Visible = True
                Panel_devant.Visible = True
                TreeView1.Visible = True
                largeur_max_panelA = larg_max_panelA(5)
                Button1.Left = l1
                ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                PanelB.Left = l1 + Button1.Width
                ButtonGauche.Left = PanelB.Right
                panel_droit.Visible = False
                TreeView1.Visible = True
                ListViewChannel.Visible = False
                PanelC.Visible = False
                PanelB.Visible = True
                ButtonBas1.Width = Size.Width
                RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width
                ExpandTreeviewNodes()

                EcrireBoutonsPrincipaux()

            Case 4
                Trace.WriteLine(DateTime.Now & " " & "synth bouton =4")
                largeur_max_panelA = larg_max_panelA(4)
                Button1.Left = l1
                ButtonGauche.Left = Button1.Right + PanelB.Width
                ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                PanelB.Left = l1 + Button1.Width
                PanelB.Visible = True
                ButtonBas1.Width = ButtonDroit.Right
                PanelC.Visible = False
                ListViewChannel.Visible = False
                TreeView1.Visible = True
                Panel_glob_devant.Visible = True
                Panel_devant.Visible = True
                panel_droit.Visible = True
                RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width
                ExpandTreeviewNodes()
                EcrireBoutonsPrincipaux()

            Case 3
                largeur_max_panelA = larg_max_panelA(3)
                Button1.Left = 0
                ButtonGauche.Left = l2 + Button1.Width
                ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                PanelB.Left = Button1.Width
                PanelC.Left = PanelB.Right
                TreeView1.Visible = False
                Panel_glob_devant.Visible = False
                Panel_devant.Visible = False
                panel_droit.Visible = False
                ListViewChannel.Visible = True
                PanelC.Visible = True
                ListViewChannel.Visible = False
                RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width
                ButtonBas1.Width = Size.Width
                If tri_categorie AndAlso sortie_filtre_entendue Then
                    TreeView1.CollapseAll()
                    RetourChainesInitiales()
                End If
            Case 2
                largeur_max_panelA = larg_max_panelA(2)
                Button1.Left = 0
                ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                panel_droit.Visible = True
                ListViewChannel.Visible = False
                TreeView1.Visible = False
                Panel_glob_devant.Visible = False
                Panel_devant.Visible = False
                PanelC.Visible = True
                PanelB.Left = Button1.Width
                ButtonGauche.Left = l2 + Button1.Width
                PanelC.Left = PanelB.Right
                ButtonBas1.Width = ButtonDroit.Right
                RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width
                If tri_categorie AndAlso sortie_filtre_entendue Then
                    TreeView1.CollapseAll()
                    RetourChainesInitiales()
                End If
            Case 1
                Trace.WriteLine(DateTime.Now & " " & "synth bouton =1")
                largeur_max_panelA = larg_max_panelA(1)
                Button1.Left = 0
                ButtonGauche.Left = Button1.Width + PanelB.Width
                PanelB.Left = Button1.Width
                PanelC.Left = PanelB.Right
                ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                panel_droit.Visible = False
                ListViewChannel.Visible = False
                PanelC.Visible = False
                TreeView1.Visible = False
                Panel_glob_devant.Visible = False
                Panel_devant.Visible = False
                ButtonBas1.Width = Size.Width

                RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width
                If tri_categorie AndAlso sortie_filtre_entendue Then
                    TreeView1.CollapseAll()
                    RetourChainesInitiales()
                End If

                EcrireBoutonsPrincipaux()

            Case 0
                Trace.WriteLine(DateTime.Now & " " & "synth bouton =0")
                largeur_max_panelA = larg_max_panelA(0)
                Button1.Left = 0
                ButtonGauche.Left = Button1.Width + PanelB.Width
                TreeView1.Visible = False
                Panel_glob_devant.Visible = False
                Panel_devant.Visible = False
                panel_droit.Visible = True
                PanelB.Visible = True
                PanelC.Visible = False
                ListViewChannel.Visible = False
                PanelB.Left = Button1.Right
                PanelB.Width = largeur_logo_adaptee
                PanelC.Left = PanelB.Right
                ButtonDroit.Left = Size.Width - largeur_boutons_verticaux - Calendar.Width - erreurh
                ButtonBas1.Width = ButtonDroit.Right
                RichTextBoxDescrip.Width = ButtonDroit.Right - PictureBoxLogo.Width
                If tri_categorie AndAlso sortie_filtre_entendue Then
                    TreeView1.CollapseAll()
                    RetourChainesInitiales()
                End If

                EcrireBoutonsPrincipaux()
        End Select

        largeur_utile = ButtonDroit.Left - ButtonGauche.Right
        Trace.WriteLine(DateTime.Now & " " & "Click bouton nouvelle largeur utile = " & largeur_utile.ToString)

        PanelA.Left += deplacementSigne
        PanelD.Left += deplacementSigne

        AfficherDateOrigineEcran()
        Central_Screen.Curseur_Vertical()

        PanelE.Left = ButtonGauche.Right
        PanelE.Width = ButtonDroit.Left - ButtonGauche.Right
        PanelD.Width = PanelA.Width

        If PanelB.Top < Button1.Top Then
            PanelC.Top = Panel_date.Bottom
            PanelC.Height += (periodicite_verticale) * (increment)
        End If

        PanelA.SendToBack()

        MainformResize(sender, e)

#If DEBUG Then
        write_panelC_location()
#End If
        'rvs 18/06/2010 ne composer la description que si repere>0!!!!!!!!!!!!!!!!!!!
        If Central_Screen.repere_click_emission > 0 Then
            Central_Screen.ComposerMessageDescrip(Central_Screen.repere_click_emission, "principale")
        End If
        PanelB.Select()
        ResumeLayout()
    End Sub

    Private Sub EcrireBoutonsPrincipaux() ' BB 231009
        Trace.WriteLine(DateTime.Now & " " & "Buttongauche.height = " & ButtonGauche.Height.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Buttongauche.bottom = " & ButtonGauche.Bottom.ToString)
        Trace.WriteLine(DateTime.Now & " " & "RichTextBoxDescrip.top " & RichTextBoxDescrip.Top.ToString)
        Trace.WriteLine(DateTime.Now & " " & "RichTextBoxDescrip.bottom " & RichTextBoxDescrip.Bottom.ToString)
        Trace.WriteLine(DateTime.Now & " " & "RichTextBoxDescrip.height " & RichTextBoxDescrip.Height.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Buttonbas1.bottom = " & ButtonBas1.Bottom.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Buttonbas1.top = " & ButtonBas1.Top.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Buttonbas1.width = " & ButtonBas1.Width.ToString)
        Trace.WriteLine(DateTime.Now & " buttondroit.right = " & ButtonDroit.Right.ToString)
        Trace.WriteLine(DateTime.Now & " pictureboxlogo.top = " & PictureBoxLogo.Top.ToString)
        Trace.WriteLine(DateTime.Now & " pictureboxlogo.bottom = " & PictureBoxLogo.Bottom.ToString)
        Trace.WriteLine(DateTime.Now & " pictureboxlogo.height = " & PictureBoxLogo.Height.ToString)

    End Sub

    Public Sub WritePanelCLocation()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & " ")
        Trace.WriteLine(DateTime.Now & " " & "Panelc.top = " & PanelC.Top.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Panelc.bottom = " & PanelC.Bottom.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Panelc.height =  " & PanelC.Height.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Panelc.width =  " & PanelC.Width.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Panelc.left =  " & PanelC.Left.ToString)
#End If
    End Sub

    Private Sub ButtonBas1Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonBas1.Click
        Select Case bb1peh 'bouton bas 1 etait en position haute au moment du click
            Case True
                Trace.WriteLine(DateTime.Now & " " & "bb1 de haut vers bas")

                ' on impose d abord buttonbas1 collé a statustrip2
                ' ensuite(RichTextBoxDescrip.Top)
                ButtonBas1.Top = StatusStrip2.Top - ButtonBas1.Height
                Trace.WriteLine(DateTime.Now & " " & "buttonbas1.top=" & ButtonBas1.Top.ToString)
                RichTextBoxDescrip.Top = ButtonBas1.Top + ButtonBas1.Height

                PictureBoxLogo.Visible = False
                RichTextBoxDescrip.Visible = False
                ListViewChannel.Height += RichTextBoxDescrip.Height
                PanelC.Height += RichTextBoxDescrip.Height
                bb1peh = False
                Button1.Height += RichTextBoxDescrip.Height
                ButtonGauche.Height += RichTextBoxDescrip.Height
                ButtonDroit.Height += RichTextBoxDescrip.Height
                Dim tempo, tempo1, tempo2 As Integer
                tempo = num_chaine_haut_ecran
                tempo1 = nb_chaines_ecran
                tempo2 = NbMaxChaineEcran

                If ((tempo + tempo2) > tempo1) Then
                    ' num_chaine_haut_ecran -= 1
                    'PanelA.Top += (tempo + tempo2 - tempo1 - 1) * periodicite_verticale * increment
                    'PanelB.Top += (tempo + tempo2 - tempo1 - 1) * periodicite_verticale * increment
                    'PanelA.Top += periodicite_verticale * increment
                    'PanelB.Top += periodicite_verticale * increment
                End If

                My.Settings.boutonbas1 = 0

            Case Else 'bouton bas 1 etait en position basse au moment du click
                Trace.WriteLine(DateTime.Now & " " & "bb1 de bas vers haut")

                ' on diminue buttonbas1.top et richtextbox.top de richtextbox.height
                bb1peh = True
                PictureBoxLogo.Visible = True
                RichTextBoxDescrip.Visible = True
                Trace.WriteLine(DateTime.Now & " " & "richtextbox.height= " & RichTextBoxDescrip.Height.ToString)
                ButtonBas1.Top -= RichTextBoxDescrip.Height

                Trace.WriteLine(DateTime.Now & " " & "buttonbas1.top=" & ButtonBas1.Top.ToString)

                ListViewChannel.Height -= RichTextBoxDescrip.Height
                Button1.Height -= RichTextBoxDescrip.Height
                ButtonGauche.Height -= RichTextBoxDescrip.Height
                ButtonDroit.Height -= RichTextBoxDescrip.Height
                RichTextBoxDescrip.Top -= RichTextBoxDescrip.Height

                My.Settings.boutonbas1 = 1

        End Select
        My.Settings.Save()
        EcrireBoutonsPrincipaux()

        Trace.WriteLine(DateTime.Now & " treeview1.top = " & TreeView1.Top.ToString)
        Trace.WriteLine(DateTime.Now & " treeview1.bottom = " & TreeView1.Bottom.ToString)

        PictureBoxLogo.Top = ButtonBas1.Bottom
        PanelE.Top = ButtonBas1.Top - hauteur_paves

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

        Central_Screen.compteur_minute += 1

        'a reactiver des que le contenu du panel cinema sera pret BB 090810
        '    If Central_Screen.compteur_minute = Central_Screen.interval_cinema Then '030810
        'on doit faire apparaitre le panneau cinema et glisser pannelA (les emissions)
        ' et PanelB (les logos ) vers le bas
        'Central_Screen.compteur_minute = 0
        'Panel_cinema.Visible = True
        'Panel_cinema.Height = 2 * hauteur_richtextbox
        'PanelA.Top += 2 * hauteur_richtextbox
        'PanelB.Top += 2 * hauteur_richtextbox
        'lancer le timer qui arretera l affichage de ce panneau cinema
        'Timer_cinema.Interval = Central_Screen.duree_affichage_cinema ' affichage de panel_cinema toutes les 20 minutes
        'Timer_cinema.Enabled = True
        'Timer_cinema.Start()

        'End If

        'Néo 29/08/2010 On met a jour l'état de la connection internet et de la météo à jour dans la StatusStrip
        Try
            If IsNetConnectOnline() Then
                ToolStripLabelStatusInternet.Image = My.Resources.connect
            Else
                ToolStripLabelStatusInternet.Image = My.Resources.disconnect
            End If
        Catch
            ToolStripLabelStatusInternet.Image = Nothing
        End Try

        'Néo 29/08/2010 On met a jour la météo à jour dans la StatusStrip
        WeatherUpdate()

        If stop_timer Then
            Exit Sub
        End If

        ' Neutralier les tick pendant un tri suivant categorie
        ' pendant lequel stop_timer = true
        Trace.WriteLine(DateTime.Now & " interrupt 1 minute")
        If PanelA.Controls.Count <> 0 Then
            Central_Screen.Curseur_Vertical()
        End If
        EveryMinute()

        Memoire_Clean()

        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform Timer_Minute_Tick")

    End Sub

    Private Sub TimerCinemaTick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_cinema.Tick
        ' on arrete l affichage du panneau cinema
        Panel_cinema.Height = 0
        Panel_cinema.Visible = False
        ' PanelA.Top -= 2 * hauteur_richtextbox' BB 010810 
        'PanelB.Top -= 2 * hauteur_richtextbox
        Timer_cinema.Stop()
        Timer_cinema.Enabled = False
    End Sub

    Private Sub ChercherDataBasedonnees()
        Dim deplacementTemps As New TimeSpan
        Dim entier As Integer
        Timer_minute.Enabled = False
        Trace.WriteLine(DateTime.Now & " " & "entree sub chercher_data_basedonnéees")
        deplacementTemps = moment_souhaite.Subtract(date_reference)
        entier = 2 * (deplacementTemps.Days * 24 + deplacementTemps.Hours)
        deplacement_panelA_en_pixels = CInt(entier * nb_pixels_pour_30_minutes)

        moment_souhaite = date_reference

        PanelA.Left = -deplacement_panelA_en_pixels + ButtonGauche.Right

        If decal_horaire < 0 Then ' 040210
            ' on doit deplacer panelA vers la gauche
            PanelA.Left += CInt(decal_horaire * 2 * nb_pixels_pour_30_minutes)
        Else ' decal_horaire >0
            ' on  doit  deplacer panelA 
        End If

        PanelD.Left = -deplacement_panelA_en_pixels + ButtonGauche.Right

        depart_affichage = date_reference
        fin_affichage = depart_affichage.AddHours(nb_de_periodes_de_6h * Nb_heures_LigneTemps)
        date_origine_ecran = depart_affichage
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & _
"On vient juste de modifier les dates avant d effectuer un rechargement de données")
        Trace.WriteLine(DateTime.Now & " " & "Date référence = " & date_reference.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Date origine_ecran = " & date_origine_ecran.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Moment souhaité = " & moment_souhaite.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Départ affichage = " & ToString())
        Trace.WriteLine(DateTime.Now & " " & "Fin affichage = " & fin_affichage.ToString)
#End If
        Build_Qwery_On_Channels_Where_and_Between()
        indice_courant_TLE = 1
        'Central_Screen.Clear_AetB_panelboxes()
        Central_Screen.Group_Fonction1()
        Central_Screen.Group_Fonction2()

        AfficherDateOrigineEcran()
        Trace.WriteLine(DateTime.Now & " " & "avant curseur vertical dans chercher_date_basedonnées")
        Trace.WriteLine(DateTime.Now & " " & "apres curseur vertical dans chercher_date_basedonnées")
        Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
        'BB240609
        Timer_minute.Start()
        'BB 210610
        Timer_minute.Enabled = True
        Application.DoEvents()
        Trace.WriteLine(DateTime.Now & " " & "sortie sub chercher_data_basedonnéees")
    End Sub

    Public Sub ReloadData()
        Trace.WriteLine(DateTime.Now & " " & "Entree reload data")
        date_reference = DebutHeure(moment_souhaite)
        ChercherDataBasedonnees()
        recuperer_emissions_marquees()
        Trace.WriteLine(DateTime.Now & " " & "Sortie reload data")
        Application.DoEvents()
    End Sub

    Private Sub ToolStripMenuItemChaineHautClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuItemChaineHaut.Click
        'Dim i As Integer = 1
        num_emission_visible = 1
        Trace.WriteLine(DateTime.Now & " " & "ToolStripMenuItemChaineHaut ")

        increment = 1
        'Dim repere1 As Integer = ButtonDroit.Left

        If PanelA.Bottom < ButtonBas1.Top Then
            Exit Sub
        Else
            SuspendLayout()
            num_chaine_haut_ecran += 1
            Do While nb_emissions_yc0_apres_tri_par_chaine(num_chaine_haut_ecran) = 0
                increment += 1
                num_chaine_haut_ecran += 1
            Loop
            PanelA.Top -= (periodicite_verticale) * (increment)
            PanelB.Top -= (periodicite_verticale) * (increment)

            If PanelB.Top < Button1.Top Then
                PanelC.Top = Panel_date.Bottom
                PanelC.Height += (periodicite_verticale) * (increment)
            End If


            Central_Screen.Calcul_Date_Origine_Ecran()
#If DEBUG Then
            Trace.WriteLine(DateTime.Now & " " & "Date origine ecran = " & date_origine_ecran.ToString)
            Trace.WriteLine(DateTime.Now & " " & "Moment souhaité = " & moment_souhaite.ToString)
            Trace.WriteLine(DateTime.Now & " " & "Date_référence =  " & date_reference.ToString)
            Trace.WriteLine(DateTime.Now & " " & "Numéro de chaine écran = " & num_chaine_haut_ecran.ToString)
#End If
            date_z = date_origine_ecran.AddHours(decal_horaire)
            num_emission_visible = 1
            num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
            If flag_emission_not_found Then
                num_chaine_haut_ecran += 1
                Trace.WriteLine(DateTime.Now & " " & "On a incrémente num_chaine Haut écran volontairement")
                num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
                If flag_emission_not_found Then
                    num_emission_visible = 1
                End If
            End If

            While flag_emission_not_found AndAlso num_chaine_haut_ecran < nombre_de_chaines_differentes
                Trace.WriteLine(DateTime.Now & " " & "On a incrémenté num_chaine Haut écran volontairement")
                num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
                num_chaine_haut_ecran += 1
            End While

            If num_emission_visible = 400 Then ' 180210
                Trace.WriteLine(DateTime.Now & " " & "on n a trouve aucune emission visible dans la tranche horaire")
                Trace.WriteLine(DateTime.Now & " " & "!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
                Trace.WriteLine(" ")
                num_emission_visible = 20
                Trace.WriteLine(DateTime.Now & " " & "num_emission visible fixe arbirairement a 20")

                ' Néo 18/09/2010 Le fichier est corrompu
                Dim BoxFichierCorrompu As DialogResult
                BoxFichierCorrompu = _
                    MessageBox.Show( _
                                     MessageFichierCorrompu, MessageFichierCorrompuTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            End If

            Trace.WriteLine( _
                             DateTime.Now & " " & "1ere emission visible = " & num_emission_visible.ToString & _
                             " pour la chaine " & num_chaine_haut_ecran.ToString)
            nom_fichier_logo = tableau_chaine(num_chaine_haut_ecran).logo
            Trace.WriteLine(DateTime.Now & " " & "Logo name = " & nom_fichier_logo.ToString)
            DrawLogoInPictureboxlogo(nom_fichier_logo)
            Central_Screen.Curseur_Vertical()
            PanelA.SendToBack()

            AfficherDateOrigineEcran()
            ResumeLayout()
            Return
        End If

    End Sub

    Private Sub ToolStripMenuItemChaineBasClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuItemChaineBas.Click
        Trace.WriteLine(DateTime.Now & " " & "ToolStripMenuItemChaineHautBas ")

        Select Case num_chaine_haut_ecran
            Case 1
                Return
            Case Else
                SuspendLayout()
                num_chaine_haut_ecran -= 1

                Do While nb_emissions_yc0_apres_tri_par_chaine(num_chaine_haut_ecran) = 0
                    increment += 1
                    num_chaine_haut_ecran -= 1
                Loop

                PanelA.Top += (periodicite_verticale) * increment
                PanelB.Top += (periodicite_verticale) * increment
                PanelA.SendToBack()

                Central_Screen.Calcul_Date_Origine_Ecran()
#If DEBUG Then
                Trace.WriteLine(DateTime.Now & " " & "Date origine ecran = " & date_origine_ecran.ToString)
                Trace.WriteLine(DateTime.Now & " " & "Moment souhaité = " & moment_souhaite.ToString)
                Trace.WriteLine(DateTime.Now & " " & "Date_référence = " & date_reference.ToString)
#End If

                ' remplacer par nouveau bloc calque sur
                date_z = date_origine_ecran.AddHours(decal_horaire)
                num_emission_visible = 1
                num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
                If flag_emission_not_found Then
                    num_chaine_haut_ecran -= 1
                    Trace.WriteLine(DateTime.Now & " " & "On a incrémenté num_chaine Haut écran volontairement")
                    num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
                    If flag_emission_not_found Then
                        num_emission_visible = 1
                    End If
                End If

                While flag_emission_not_found AndAlso num_chaine_haut_ecran < nombre_de_chaines_differentes '150210
                    Trace.WriteLine(DateTime.Now & " " & "On a incrémenté num_chaine Haut écran volontairement")
                    num_emission_visible = Central_Screen.Premiere_Emission_Visible(num_chaine_haut_ecran, date_z)
                    num_chaine_haut_ecran += 1
                End While

                If num_emission_visible = 400 Then ' 180210
                    Trace.WriteLine( _
                                     DateTime.Now & " " & _
                                     "on n a trouve aucune emission visible dan sla tranche horaire")
                    Trace.WriteLine(DateTime.Now & " " & "!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
                    Trace.WriteLine(" ")
                    num_emission_visible = 20
                    Trace.WriteLine(DateTime.Now & " " & "num_emission visible fixe arbirairement a 20")

                    ' Néo 18/09/2010 Le fichier est corrompu
                    Dim BoxFichierCorrompu As DialogResult
                    BoxFichierCorrompu = _
                        MessageBox.Show( _
                                         MessageFichierCorrompu, MessageFichierCorrompuTitre, MessageBoxButtons.OK, _
                                         MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                End If

                Trace.WriteLine( _
                                 DateTime.Now & " " & "1ere emission visible = " & num_emission_visible.ToString & _
                                 " pour la chaine " & num_chaine_haut_ecran.ToString)
                nom_fichier_logo = tableau_chaine(num_chaine_haut_ecran).logo
                Trace.WriteLine(DateTime.Now & " " & "Logo name = " & nom_fichier_logo.ToString)
                DrawLogoInPictureboxlogo(nom_fichier_logo)
                Central_Screen.Curseur_Vertical()
                AfficherDateOrigineEcran()
                PanelA.SendToBack()
                ResumeLayout()
                Return
        End Select

    End Sub

    Private Sub PanelBLostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles PanelB.LostFocus
        Trace.WriteLine(DateTime.Now & " " & "On entre dans PanelB_LostFocus")
        Panel_devant.Focus()
        Trace.WriteLine(DateTime.Now & " " & "On sort du PanelB_LostFocus")
    End Sub

    Private Sub PanelBMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PanelB.MouseWheel

        If TshEnCours Then
            ' eviter les click de molette repetitifs en scroll horizontal
            ' tsh_en_cours = traitement scroll horizontal en cours
            Return
        End If

        If Not ScrollHorizontal Then
            ' le scroll horizontal ne peut se faire (trop de chaines sélectionnées)
            ' on reste donc en scroll vertical
            'Dim i As Integer = 1
            num_emission_visible = 1

            Trace.WriteLine(DateTime.Now & " " & "PanelB_Mousewheel ")

            ' molette souris de l avant vers l arriere = var
            ' est  positif num_chaine_haut_ecran()
            increment = 1

            ' ne pas donner le focus à PanelA et ne pas faire
            ' de scroll quand il y a peu d emissions dans ce soir
            ' et qu on fait un mousewheel dans panel_ce_soir
            Dim repere1 As Integer
            repere1 = ButtonDroit.Left
            If (Not bdpad) AndAlso e.X > repere1 Then
                Panel_ce_soir.Focus()
                Return
            End If

            If e.Delta < 0 Then ' afficher des chaines de numero + eleve
                If PanelA.Bottom < ButtonBas1.Top - PanelE.Height Then
                    Return
                Else
                    SuspendLayout()
                    num_chaine_haut_ecran += 1
                    PanelA.Top -= (periodicite_verticale) * (increment)
                    PanelB.Top -= (periodicite_verticale) * (increment)

                    If PanelB.Top < Button1.Top Then
                        PanelC.Top = Panel_date.Bottom
                        PanelC.Height += (periodicite_verticale) * (increment)
                    End If

                    num_emission_visible = 1
                    PanelA.SendToBack()
                    ResumeLayout()
                    Return
                End If

            Else ' e.delta est positif;afficher des chaines de numero moins elevé
                Select Case num_chaine_haut_ecran
                    Case 1
                        Return
                    Case Else
                        SuspendLayout()
                        num_chaine_haut_ecran -= 1

                        PanelA.Top += (periodicite_verticale) * increment
                        PanelB.Top += (periodicite_verticale) * increment
                        PanelA.SendToBack()

                        num_emission_visible = 1
                        PanelA.SendToBack()
                        ResumeLayout()
                        Return
                End Select
            End If
        Else

            ' scroll horizontal est a true( le nbre de chaines selectionnées est suffisant
            ' a t on l accord de l utilisateur poiur faire du scroll horizontal
            If My.Settings.accordscrollhorizontal Then

                ' on a l accord , on fait du scroll horizontal
                TshEnCours = True
                ' lancer le timer 500 msec qui interdira tout scroll horizontal pdt 500 msec
                Timer_500msec.Start()
                'BB 260710
                Timer_500msec.Enabled = True

                If e.Delta < 0 Then ' on fait heure =heure +1

                    ' equivalent du bouton heure  +
                    Trace.WriteLine(DateTime.Now & " " & "Le pave cliqué était H +1 ")

                    moment_souhaite = moment_souhaite.AddHours(1)
                    IniCalendrier(moment_souhaite)
                    If moment_souhaite > last_date_with_data Then ' data souhaitee non existantes dans BDD

                        Dim tmpDate As New Date(moment_souhaite.Year, moment_souhaite.Month, moment_souhaite.Day)

                        If tmpDate > last_date_with_data Then
                            Trace.WriteLine(DateTime.Now & " " & "Vous allez vers une zone vide de données")
                            moment_souhaite = moment_souhaite.AddHours(-24)
                            IniCalendrier(moment_souhaite)
                            Return
                        Else
                            moment_souhaite = tmpDate
                            IniCalendrier(moment_souhaite)
                        End If
                    End If

                    If moment_souhaite > date_reference.AddHours(nb_de_periodes_de_6h * Nb_heures_LigneTemps) Then
                        Trace.WriteLine(DateTime.Now & " " & "Début rechargement des data")
                        Timer_minute.Enabled = False
                        ReloadData()
                        Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                        'BB240609
                        Timer_minute.Start()
                        'BB 210610
                        Timer_minute.Enabled = True
                        Trace.WriteLine(DateTime.Now & " " & "Fin rechargement des data")
                        Return
                    End If

                    ' data souhaitees deja presentes en memoire
                    ChercherDataEnMemoire()

                Else ' e.delta>0 then on fait heure=heure-1(scroll horizontal)


                    ' equivalent du bouton heure -1
                    TshEnCours = True
                    Dim s As String
                    Trace.WriteLine(DateTime.Now & " " & "Le pave cliqué était H -1 ")
                    moment_souhaite = moment_souhaite.AddHours(-1)
                    IniCalendrier(moment_souhaite)
                    If moment_souhaite < first_date_with_data Then
                        Dim tmpDate As Date = first_date_with_data
                        If tmpDate < first_date_with_data Then
                            s = " vous allez vers une zone vide de donnéees"
                            Trace.WriteLine(s)
                            moment_souhaite = moment_souhaite.AddHours(+1)
                            IniCalendrier(moment_souhaite)
                            Return
                        Else
                            moment_souhaite = tmpDate
                            IniCalendrier(moment_souhaite)
                        End If
                    End If

                    If moment_souhaite < date_reference Then
                        s = "debut de rechargement de data"
                        Trace.WriteLine(s)
                        moment_souhaite = moment_souhaite.AddHours(-3)
                        IniCalendrier(moment_souhaite)

                        'load_data_before = True
                        Timer_minute.Enabled = False
                        ReloadData()
                        s = "fin de rechargement de data"
                        Trace.WriteLine(s)
                        Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                        'BB240609
                        Timer_minute.Start()
                        'BB 210610
                        Timer_minute.Enabled = True
                        DessineLigneTemps()
                        Return
                    End If

                    ChercherDataEnMemoire()
                    DessineLigneTemps()

                End If
            End If
            ' fin du test sur l accord de scroll horizontal
        End If

        ' fin du test sur scroll_horizontal
    End Sub

    Private Sub NavigationTemporelle(ByVal heure As Integer)
        BloquerBoutonCalendrier()

        With moment_souhaite
            moment_souhaite = DebutJournee(moment_souhaite)
            moment_souhaite = .AddHours(heure)
        End With

        IniCalendrier(moment_souhaite)
        If _
            DateEntre(moment_souhaite, date_reference, _
                       date_reference.AddHours(nb_de_periodes_de_6h * Nb_heures_LigneTemps)) Then
            'data souhaitees deja presentes en memoire
            LoaderShow()
            ChercherDataEnMemoire()
            DessineLigneTemps()
            ChercherPremiereEmission()
            LoaderHide()
        Else
            Timer_minute.Enabled = False
            navigtemporelle.Enabled_Button = False
            'navigtemporelle.Visible = False
            ReloadData()
            'navigtemporelle.Visible = True

            navigtemporelle.Enabled_Button = True

            With Timer_minute
                .Start()
                .Enabled = True
            End With

        End If
        AutoriserBoutonCalendrier()
    End Sub

    Private Sub ToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuItem6H.Click, _
                ToolStripMenuItem9H.Click, _
                ToolStripMenuItem12H.Click, _
                ToolStripMenuItem15H.Click, _
                ToolStripMenuItem18H.Click, _
                ToolStripMenuItem20H.Click, _
                ToolStripMenuItem23H.Click, _
                ToolStripMenuItemheure_plus.Click, _
                ToolStripMenuItemheure_moins.Click, _
                ToolStripMenuItemJour_Moins.Click, _
                ToolStripMenuItemJour_Plus.Click, _
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
            If moment_souhaite.Hour <> 23 Then
                heure = moment_souhaite.AddHours(1).Hour
            Else
                heure = 24
                ' Apres 23 c'est 0 donc on force à 24 
            End If
        ElseIf sender Is ToolStripMenuItemheure_moins Then
            If moment_souhaite.Hour <> 0 Then
                heure = moment_souhaite.AddHours(-1).Hour
            Else
                heure = -1
                ' avant 0 c'est 23 donc on force à -1 
            End If
        ElseIf sender Is ToolStripMenuItemJour_Moins Then
            heure = -24 + moment_souhaite.Hour
        ElseIf sender Is ToolStripMenuItemJour_Plus Then
            heure = 24 + moment_souhaite.Hour
        ElseIf sender Is ToolStripMenuItemMaintenant Then
            moment_souhaite = DateTime.Now
            heure = DateTime.Now.Hour
        End If

        'Dim TmpDate As New Date(moment_souhaite.Year, moment_souhaite.Month, moment_souhaite.Day)
        Dim tmpDate As DateTime = DebutJournee(moment_souhaite.AddHours(heure))

        If tmpDate > last_date_with_data OrElse tmpDate < first_date_with_data Then
            MessageBox.Show("Désolé, il n'y a pas de donnée à cette date.", "Information", MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
            Return
        Else
            NavigationTemporelle(heure)
            LoaderHide()
        End If
    End Sub

    Private Sub Test(ByVal testbt As String) Handles navigtemporelle.ButtonChanged
        'MessageBox.Show(testbt)
        Dim heure As Integer
        Select Case testbt
            Case "btJourmoins"
                heure = -24 + moment_souhaite.Hour
            Case "btHeuremoins"
                If moment_souhaite.Hour <> 0 Then
                    heure = moment_souhaite.AddHours(-1).Hour
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
                moment_souhaite = DateTime.Now
                heure = DateTime.Now.Hour
            Case "btHeureplus"
                If moment_souhaite.Hour <> 23 Then
                    heure = moment_souhaite.AddHours(1).Hour
                Else
                    heure = 24
                    ' Apres 23 c'est 0 donc on force à 24 
                End If
            Case "btJourplus"
                heure = 24 + moment_souhaite.Hour
        End Select

        'Dim TmpDate As New Date(moment_souhaite.Year, moment_souhaite.Month, moment_souhaite.Day)
        Dim tmpDate As DateTime = DebutJournee(moment_souhaite.AddHours(heure))

        If tmpDate > last_date_with_data OrElse tmpDate < first_date_with_data Then
            MessageBox.Show("Désolé, il n'y a pas de donnée à cette date.", "Information", MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
            Return
        Else
            NavigationTemporelle(heure)

        End If
    End Sub

    Private Sub TreeView1Click(ByVal sender As Object, ByVal e As EventArgs) Handles TreeView1.Click
        Panel_devant.Focus()
    End Sub

    Private Sub TreeView1NodeMouseDoubleClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) _
        Handles TreeView1.NodeMouseDoubleClick
        Dim tn As New TreeNode
        tn = e.Node
        categorie_choisie = tn.Text

        ' pour rappel categorie choisie peut etre un mot de langue
        ' etrangere alors que la BD ne contient que du français
        Dim i As Integer
        If My.Settings.Language <> "Français" Then
            For i = 1 To NbTotalTypeEmissionPourPeriodeFixee
                If categorie_choisie = cat_distincte_etran(i) Then
                    categorie_choisie = cat_distincte_fran(i)
                End If
            Next i
        Else
        End If

        Dim s As String
        s = tn.Text
        Select Case s
            Case "Pays", "Fournisseurs", "Filtres", "Catégories"
                filtre_non_autorise = True
                Return
        End Select
        Dim t As String
        t = "Catégories (" & (NbTotalTypeEmissionPourPeriodeFixee).ToString & ")"

        If s = t Then
            Return
        End If
        TrierSuivantCategorie()
        categorie_choisie = ""
    End Sub

    Public Sub New()

        ' sub New est appellé AVANT Mainform_load
        InitializeComponent()

        ' Néo 18/09/2010
        SetStyle( _
                      ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or _
                      ControlStyles.OptimizedDoubleBuffer, True)

        ' 17/11/2010
        ' On patch la base de registre afin d'éviter les bugs des anciennes versions
        Dim rk As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\ZGuideTV Team")
        If rk IsNot Nothing Then
            My.Computer.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\ZGuideTV Team")
        End If

        Dim _
            rk1 As RegistryKey = _
                Registry.LocalMachine.OpenSubKey( _
                                                  "SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\ZGuideTVDotNet.exe")
        If rk1 IsNot Nothing Then
            My.Computer.Registry.LocalMachine.DeleteSubKeyTree( _
                                                                "SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\ZGuideTVDotNet.exe")
        End If

        ' 15/11/2010 On regarde si zguidetv est déjà lancé
        ' On recupere le process en cours
        Dim pa As Process = Process.GetCurrentProcess
        ' Recupere les process qui ont le même nom que le process en cours
        Dim poolprocess As Process() = Process.GetProcessesByName(pa.ProcessName)
        ' Si le nombre de process ayant le même nom est supérieure à 1
        If poolprocess.Length > 1 Then
            ' Pour chaque process ayant le même nom
            For Each pb As Process In poolprocess
                ' Si l'identifiant est diférent de l'identifiant du process en cours 
                If pb.Id <> pa.Id Then
                    ' On tue le process
                    pb.Kill()
                    ' On attend deux secondes
                    Thread.Sleep(2000)
                    ' Test si le proces s'est bien arrété
                    If Not (pb.HasExited) Then
                        Application.Exit()
                    End If
                End If
            Next
        End If

        ' Néo 08/09/2010
        ' On va rechercher l'ancien user.config si le num de version est différent
        With My.Settings
            If .CallUpgrade Then
                .Upgrade()
                .Save()
                .CallUpgrade = False
            End If
        End With

        With My.Settings
            ' On redémarre zguidetv après une mise à jour (par défaut)
            .UserRestart = 1
            ' On redémarre zguidetv après des modifs dans les préférences
            .ModifPrefRestart = 0
            ' Base de donnée expirée false par défaut
            .DataBaseExpired = False
        End With

        ' Le rendu 3d de la barre d'outils et du menu ....
        Dim render As New Render()
        With render.Toolstrip
            .Curve = 2
            .BackgroundTop = Color.FromArgb(255, 255, 255)
            .BackgroundBottom = Color.FromArgb(230, 230, 230)
            render.SmoothText = False
        End With

        ToolStripManager.Renderer = render

        ' On surveille les erreurs d'exception non gérées 
        ' Si exception non gérée est effectuée on exécute : Public Shared Sub Application_ThreadException et
        ' Public Shared Sub CurrentDomain_UnhandledException()
        AddHandler Application.ThreadException, AddressOf ApplicationThreadException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomainUnhandledException
        
        Pathdefinition()

        ' Néo le 01/06/2011
        ' Si un fichier compressé traine dans le répertoire ProgramData on l'efface
        For Each foundFile As String In _
            My.Computer.FileSystem.GetFiles( _
                                             Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                                             "\ZGuideTVDotNet\", SearchOption.SearchTopLevelOnly, "*.zip", "*.7z", _
                                             "*.rar", "*.xml")
            File.Delete(foundFile)
        Next

        chemin_fichier_log = LogPath & "ZGuideTVDotNet.exe.log"
        Sw = New StreamWriter(chemin_fichier_log, False)
        ' sw = New StreamWriter(chemin_fichier_log, True)
        ' true veut dire en mode append 
        ' false pour ne pas re ecrire a la fin du fichier precedent mais bien écraser
        Tl = New TextWriterTraceListener(Sw)
        Select Case My.Settings.tracelog
            Case True
                InitialisationTraceListener()
        End Select

        Dim maVersion As Version = Assembly.GetExecutingAssembly.GetName.Version
        Trace.WriteLine(DateTime.Now & " " & "Démarrage du programme...")
        Trace.WriteLine( _
                         DateTime.Now & " " & "Système d'exploitation : " & My.Computer.Info.OSFullName & _
                         My.Computer.Info.OSVersion & DATETIMENOW)
        Trace.WriteLine(DateTime.Now & " " & "Version de ZGuideTV.NET : " & maVersion.ToString)
        Trace.WriteLine( _
                         DateTime.Now & " " & "Date de compilation de ZGuideTV.NET : " & _
                         File.GetLastWriteTime(AppPath & "ZGuideTVDotNet.exe"))
        Trace.WriteLine(DateTime.Now & " " & "Chemin vers ZGuideTV.NET : " & Application.StartupPath)
        Trace.WriteLine(DateTime.Now & " " & "Chemin vers Kastor! TV : " & My.Settings.KtvPath)
        Trace.WriteLine(DateTime.Now & " " & "Source Kastor! TV : " & My.Settings.KtvSource)

        ' Néo le 08/09/2010
        ' On sélectionne la langue
        With My.Settings
            If .firststart Then
                Trace.WriteLine(DateTime.Now & " " & "C'est le 1er démarrage on sélectionne la langue")
                SelectLanguage.ShowDialog()
                Trace.WriteLine(DateTime.Now & " " & "C'est le 1er démarrage on affiche frmPremierDemarrage")
                PremierDemarrage.ShowDialog()
                .firststart = False
                .Save()
            End If
        End With

        ' Si la bdd < ou = 5 Ko on l'efface (en fait elle est vide !!!!!)
        Dim fichierInfo As New FileInfo(BDDPath & "db_progs.db3")
        If My.Computer.FileSystem.FileExists(BDDPath & "db_progs.db3") Then
            Dim tailleFichier As Integer = CInt(fichierInfo.Length)
            tailleFichier = CInt(tailleFichier)
            If tailleFichier = 6000 OrElse tailleFichier < 6000 Then
                File.Delete(BDDPath & "db_progs.db3")
            End If
        End If

        ' La dernière mise à jour manuelle s'est mal passée si à 1
        If My.Settings.FichierCorrompu = 1 Then

            Trace.WriteLine(DateTime.Now & " " & "La bdd était corrompue lors de la dernière mise à jour manuelle")
            If _
                My.Computer.FileSystem.FileExists(BDDPath & "db_progs.bak") AndAlso _
                My.Computer.FileSystem.FileExists(ChannelSetPath & "ZGuideTVDotNet.channels.bak") Then

                ' On récupère les sauvegardes effectuées si elles existent
                Dim _
                    configZGuideTv As Configuration = _
                        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)

                File.Copy(BDDPath & "db_progs.bak", BDDPath & "db_progs.db3", True)
                File.Copy(ChannelSetPath & "ZGuideTVDotNet.channels.bak", _
                           ChannelSetPath & "ZGuideTVDotNet.channels.set", True)

                ' Néo le 23/09/2010
                If File.Exists(UrlPath & "ZGuideTVDotNet.url.bak") Then
                    File.Copy(UrlPath & "ZGuideTVDotNet.url.bak", _
                               UrlPath & "ZGuideTVDotNet.url.set", True)
                End If

                If File.Exists(BDDPath & "EPGData.bak") Then
                    File.Copy(BDDPath & "EPGData.bak", BDDPath & "EPGData.db3", True)
                End If

                If File.Exists(configZGuideTv.FilePath & ".bak") Then
                    File.Copy(configZGuideTv.FilePath & ".bak", configZGuideTv.FilePath, True)
                End If

                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "On vient de récupérer une sauvegarde de la bdd, ZGuideTVDotNet.channels.set et le user.config après une mise à jour manuelle")
                With My.Settings
                    .Reload()
                    .FichierCorrompu = 0
                End With
            Else

                ' sinon on efface les fichiers et on réaffiche frmmiseajour
                If My.Computer.FileSystem.FileExists(BDDPath & "db_progs.db3") Then
                    File.Delete(BDDPath & "db_progs.db3")
                End If
                If My.Computer.FileSystem.FileExists(ChannelSetPath & "ZGuideTVDotNet.channels.set") Then
                    File.Delete(ChannelSetPath & "ZGuideTVDotNet.channels.set")
                End If
                Trace.WriteLine(DateTime.Now & " " & "On vient d'effacer une bdd corrompue et le channel.set")
                'My.Settings.Reload()

                With My.Settings
                    .BddExists = False
                    .FichierCorrompu = 0
                End With
            End If
        End If

        ' Néo le 05/04/2011
        ' Par sécurité, si le fichier ZGuideTVDotNet.url.set n'existe pas dans UrlPath on le copie 
        If Not File.Exists(UrlPath & "ZGuideTVDotNet.url.set") Then
            File.Copy(AppPath & "ZGuideTVDotNet.url.set", UrlPath & "ZGuideTVDotNet.url.set", True)
        End If

        emission_duration_maintenant = My.Settings.dureemaintenant
        emission_duration_cesoir = My.Settings.dureecesoir
        Timer_minute.Enabled = False

        ' Néo le 22/09/2010
        ' On crée un thread pour l'affichage du SplashScreen
        Dim splashthread As Thread = New Thread(AddressOf SplashScreenClass.ShowSplashScreen)
        With splashthread
            .IsBackground = True
            .Start()
        End With
    End Sub

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

    Private Sub MainformPaint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint

        Trace.WriteLine(DateTime.Now & " " & "On entre dans Mainform_paint")
        GLine = e

        'Néo le 29/05/2010
        If My.Settings.DataBaseExpired Then
            If My.Settings.DIRChecked = False Then
                Miseajour.ButtonDemarrer.PerformClick()
            End If
        End If

        Trace.WriteLine(DateTime.Now & " " & "On sort du Mainform_paint")
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As Object, ByVal e As EventArgs) _
        Handles NotifyIcon1.BalloonTipClicked

        'On affiche plus le message dans le systray 26/07/2010
        My.Settings.NotifyIconShow = False

    End Sub

    ' redimensionnement du mainform
    Private Sub MainformResize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        Select Case WindowState
            Case FormWindowState.Minimized
                Memoire_Clean()

                NotifyIcon1.Visible = True

                ' Modif le 26/07/2010
                If My.Settings.NotifyIconShow Then
                    With NotifyIcon1
                        .BalloonTipTitle = "ZGuideTV.NET"
                        .BalloonTipText = _
                            BalloonText1 & _
                            Chr(13) & Chr(13) & BalloonText3
                        .BalloonTipIcon = ToolTipIcon.Info
                        .ShowBalloonTip(2000)
                        .Text = "ZGuideTV.NET"
                    End With
                End If

                Hide()

            Case Else
                Trace.WriteLine(" ")
                Trace.WriteLine(DateTime.Now & " entrée dans mainform resize ")
                Trace.WriteLine(DateTime.Now & " me.size.width = " & Size.Width.ToString)
                Trace.WriteLine(DateTime.Now & " me.size.height= " & Size.Height.ToString)
                If fin_initialize Then
                    Panel_glob_devant.Top = ToolStrip1.Bottom
                End If

                Try
                    Trace.WriteLine(DateTime.Now & " buttondroit.right= " & ButtonDroit.Right.ToString)
                    Trace.WriteLine(DateTime.Now & " panel_droit.left= " & panel_droit.Left.ToString)
                Catch ex As Exception
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                End Try

                Try
                    Select Case synth_boutons

                        Case 7
                            ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
                        Case 6
                            ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
                        Case 5
                            ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
                        Case 4
                            ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
                        Case 3
                            ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
                        Case 2
                            ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
                        Case 1
                            ButtonDroit.Left = Size.Width - ButtonDroit.Width - erreurh
                            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
                        Case 0
                            ButtonDroit.Left = Size.Width - Calendar.Width - largeur_boutons_verticaux - erreurh
                            ButtonBas1.Width = ButtonDroit.Left + ButtonDroit.Width
                    End Select

                Catch ex As InvalidOperationException
                    Trace.WriteLine(DateTime.Now & " ex.message")
                End Try

                Trace.WriteLine(DateTime.Now & " sortie de mainform resize apres modif de buttondroit.left")
                Trace.WriteLine(DateTime.Now & " me.size.width=" & Size.Width.ToString)
                Trace.WriteLine(DateTime.Now & " me.size.height=" & Size.Height.ToString)
                Trace.WriteLine(DateTime.Now & " buttondroit.right=" & ButtonDroit.Right.ToString)

                panel_droit.Left = ButtonDroit.Right
                Trace.WriteLine(DateTime.Now & " panel_droit.left= " & panel_droit.Left.ToString)

                Calendar.Top = 0

                ButtonBas1.Top = ButtonGauche.Bottom
                PictureBoxLogo.Top = ButtonBas1.Bottom

                With RichTextBoxDescrip
                    .Top = ButtonBas1.Bottom
                    .Width = ButtonDroit.Right - .Left
                End With

                PictureBoxLogo.Height += 200
                '  pour cacher les categories qui apparaissent en dessous 
                ' de pictureboxlogo lors d un mousewheel dans les categories

                ' on reduit la haut. de panel_glob_ce_soir pour continuer
                ' a voir panel_glob_maintenant lors de la reduction
                ' de hauteur de mainform lors du resize
                Panel_glob_ce_soir.Height = _
                    CInt( _
                        (DisplayRectangle.Height - ToolStrip1.Height - MenuStrip1.Height - StatusStrip2.Height - _
                         Calendar.Height) \ 2)
                Panel_glob_maintenant.Top = Panel_glob_ce_soir.Bottom
                'rvs75 12/08/2010 les panel ont maintenant la même taille + remise du top des panels au niveau des bottoms des titres  
                Panel_glob_maintenant.Height = Panel_glob_ce_soir.Height
                Panel_ce_soir.Top = Panel_titre_ce_soir.Bottom
                Panel_maintenant.Top = Panel_titre_maintenant.Bottom
                'ecart_max = Panel_maintenant.Height

                largeur_utile = ButtonDroit.Left - ButtonGauche.Right
                SuspendLayout()
                'PanelE.Controls.Clear()
                TreeView1.Top = 0
                With PanelE
                    .Left = ButtonGauche.Right
                    .Top = ButtonBas1.Top - hauteur_paves
                    .Height = hauteur_paves
                    .Width = ButtonDroit.Left - ButtonGauche.Right
                End With

                'RichTextBoxDescrip.Controls.Add(bandeau_signaletique) '3/4/10
                'bandeau_signaletique.Left = 200 '3/4/10
                'bandeau_signaletique.Top = 0 '3/4/10
                'Central_Screen.r2.Left = RichTextBoxDescrip.Width - Central_Screen.r2.Width 

                Trace.WriteLine(DateTime.Now & " " & "fin de mainform_resize, apres dimensionner 12 paves")
                ResumeLayout()
        End Select
    End Sub

    ' double clic dans le systray
    Private Sub NotifyIcon1DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles NotifyIcon1.DoubleClick
        NotifyIcon1.Visible = False
        Application.DoEvents()
        RestoreWindow()
    End Sub

    ' info dans le menu systray
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
            If Panel_ce_soir.Top < Panel_titre_ce_soir.Bottom Then
                'on descend le top 
                Panel_ce_soir.Top += periodicite_verticale
            End If
            'si montée
        Else
            'si le bas des emission  du panel est superieur au bas du panel global
            If Panel_ce_soir.Top + (nb_emissions_for_ce_soir * periodicite_verticale) > Panel_glob_ce_soir.Height Then
                'On monte le top
                Panel_ce_soir.Top -= periodicite_verticale
            End If
        End If
    End Sub

    Private Sub PanelGlobMaintenantMouseWheel1(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles Panel_glob_maintenant.MouseWheel
        'dectetion du sens du scroll
        'si descente
        If e.Delta > 0 Then
            ' si le top du panel des émissions est inferieure au bottom du panel du titre
            If Panel_maintenant.Top < Panel_titre_maintenant.Bottom Then
                'on descend le top 
                Panel_maintenant.Top += periodicite_verticale
            End If
            'si montée
        Else
            'si le bas des emission dans le panel est superieur au bas du panel global
            If Panel_maintenant.Top + (nb_emissions_for_Maintenant * periodicite_verticale) > Panel_glob_maintenant.Height _
                Then
                'On monte le top
                Panel_maintenant.Top -= periodicite_verticale
            End If
        End If
        'A mettre sinon si on appui sur le titre, c'est comme si on appyait sur l'emission qui est en dessous !
        Panel_titre_maintenant.BringToFront()
    End Sub

    Private Sub ChargeListeChannel()
        ' Dim ObjetDataSet As New DataSet()
        Dim objetDataTable As DataTable
        Dim rowNumber As Integer

        ' Numéro de l'enregistrement courant
        Dim strSqlChannel As String = ""
        Dim logoName As String = ""
        Dim imageListChannel As New ImageList()
        collectionImagesListViewChannel.Clear()
        imageListChannel.ImageSize = New Size(38, 29)
        strSqlChannel = "Select distinct name,logo From ChannelTbl;"

        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        objetDataTable = db.ExecuteQuery(strSqlChannel)
        db.CloseDatabase()

        ListViewChannel.Clear()
        ListViewChannel.Columns.Add("Chaines disponibles", -2, HorizontalAlignment.Left)

        If rowNumber < 0 Then
            Return
        End If

        ' Lors de l'ouverture de la BD, s'il n'y a aucun enregistrement
        Try
            If rowNumber > objetDataTable.Rows.Count Then
                Return
            Else
                For rowNumber = 0 To objetDataTable.Rows.Count - 1
                    Dim listViewMyItem As New ListViewItem
                    listViewMyItem.Text = objetDataTable.Rows(rowNumber).Item("Name").ToString
                    listViewMyItem.SubItems.Add("")
                    ListViewChannel.Items.Add(listViewMyItem)


                    logoName = objetDataTable.Rows(rowNumber).Item("Logo").ToString
                    If File.Exists(LogosPath & logoName) Then
                        imageListChannel.Images.Add(Image.FromFile(LogosPath & logoName))

                        collectionImagesListViewChannel.Add(LogosPath & logoName)
                    Else
                        imageListChannel.Images.Add(Image.FromFile(LogosPath & "vide.jpg"))

                    End If
                    listViewMyItem.ImageIndex = rowNumber
                    ListViewChannel.SmallImageList = imageListChannel

                Next rowNumber
            End If
        Catch
            Trace.WriteLine(DateTime.Now & " " & "Erreur exception dans charge liste channel")
        End Try

    End Sub

    Private Sub ListViewChannelClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewChannel.Click
        Dim logoFileName As String = ""
        logoFileName = (collectionImagesListViewChannel.Item((ListViewChannel.SelectedItems(0).Index) + 1)).ToString
        If File.Exists(logoFileName) Then
            PictureBoxLogo.Load(logoFileName)
        Else
            PictureBoxLogo.Load(LogosPath & "vide.jpg")
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
        Timer_500msec.Stop()
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
        My.Settings.buttonsstate = synth_boutons

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

        ' On réactive l'écran de veille
        'ScreenSaver_On()

        ' Si la bdd est < ou = 5 Ko on l'efface 
        Dim fichierInfo As FileInfo = New FileInfo(BDDPath & "db_progs.db3")
        Dim tailleBdd As Integer = CInt(fichierInfo.Length)
        If tailleBdd = 6000 OrElse tailleBdd < 6000 Then
            File.Delete(BDDPath & "db_progs.db3")
        End If

        My.Settings.Save()
        NotifyIcon1.Dispose()
        Memoire_Clean()

        Trace.WriteLine(DateTime.Now & " On ferme ZGuideTV.NET...")
        ' 220709 fermer les fichier log et tous les fichiers ouverts!!!
        Tl.Close()

    End Sub

    Private Sub TreeView1AfterCollapse(ByVal sender As Object, ByVal e As TreeViewEventArgs) _
        Handles TreeView1.AfterCollapse
        Dim tn As TreeNode = e.Node
        Select Case tn.Name
            Case "Categories"
                Return
        End Select
        Select Case tn.Text
            Case "Filtres"
                If tri_categorie = False Then
                    Return
                End If
                RetourChainesInitiales()
                stop_timer = False
            Case lngNodeFilter
                If tri_categorie = False Then
                    Return
                End If
                RetourChainesInitiales()
                stop_timer = False
        End Select

    End Sub

    Private Sub PanelAMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PanelA.MouseMove

        Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform panelA_MouseMove")
        If ToolStripTextBoxRecherche.Text <> lngToolStripTextBoxRecherche Then
            RechercheTextBoxToolStrip()
        End If

        PanelB.Select()
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform panelA_MouseMove")
    End Sub

    Private Sub Pathdefinition()

        AppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                  "\ZGuideTVDotNet\"
        AppPath = Application.ExecutablePath
        AppPath = AppPath.Remove(AppPath.LastIndexOf(Chr(92)) + 1)
        LogosPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                    "\ZGuideTVDotNet\Logos\"

        BDDPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & _
                  "\ZGuideTVDotNet\DataBase\"
        SettingsPath = AppData
        TempPath = AppData
        UnZipPath = AppPath & "7z.exe"
        LogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & _
                  "\ZGuideTVDotNet\Log\"
        UrlPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & _
                  "\ZGuideTVDotNet\Url\"
        ChannelSetPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & _
                         "\ZGuideTVDotNet\Channels\"
        MarqueesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & _
                       "\ZGuideTVDotNet\Marked\"
        wavepath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                   "\ZGuideTVDotNet\resources\"

        Try
            If Not Directory.Exists(AppData) Then
                Directory.CreateDirectory(AppData)
            End If
            If Not Directory.Exists(LogosPath) Then
                Directory.CreateDirectory(LogosPath)
            End If
            If Not Directory.Exists(BDDPath) Then
                Directory.CreateDirectory(BDDPath)
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

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try
    End Sub

    Private Sub ExpandTreeviewNodes()
        Dim i As Integer
        For i = 0 To TreeView1.Nodes.Count - 1
            TreeView1.Nodes(i).ExpandAll()
        Next i
    End Sub

    Public Sub DrawLogoInPictureboxlogo(ByVal nomDuFichier As String)
        Dim logobox1 As New PictureBox
        PictureBoxLogo.Controls.Clear()
        'Central_Screen.kill_handle(PictureBoxLogo)
        Application.DoEvents()

        With logobox1
            .SizeMode = PictureBoxSizeMode.Normal
            .Left = 15
            .Top = 2
            .Height = PictureBoxLogo.Height
            .Width = PictureBoxLogo.Width
            .Image = Image.FromFile(LogosPath & nomDuFichier)
            .BorderStyle = BorderStyle.None
        End With
        Try
            PictureBoxLogo.Controls.Add(logobox1)
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try
    End Sub

    ' Quitter via le systray
    Private Sub MenuItem1Click(ByVal sender As Object, ByVal e As EventArgs) Handles SystrayMenuExit.Click
        NotifyIcon1.Visible = False
        Application.DoEvents()
        My.Settings.Save()
        Application.Exit()
    End Sub

    Private Sub MiseajourchainesClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripUpdate.Click

        Try
            If My.Settings.Epgdata Then
                If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://www.epgdata.com/") Then
                    MiseajourEPGData.Show()
                Else

                    ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                    ' faire une mise à jour manuelle
                    Dim BoxNoConnection As DialogResult
                    BoxNoConnection = _
                        MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                         MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                         MessageBoxIcon.Exclamation)

                End If
            Else
                Miseajour.Show()
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
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

    Private Sub MenuItem2Click(ByVal sender As Object, ByVal e As EventArgs) Handles SystrayMenuRestore.Click
        RestoreWindow()
    End Sub

    Private Sub GestionDesChaînesKtvToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuGestionChainesKTV.Click
        KTvForm.ShowDialog()
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
            screen = Windows.Forms.Screen.AllScreens(0)

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
            screen = Windows.Forms.Screen.AllScreens(1)

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

    Private Sub ImprimDescriptClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripPrint.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ' On imprime la RichtextBoxDescrip
        ' http://msdn.microsoft.com/fr-fr/library/7d29f66t(VS.80).aspx
        PrintDialog1.Document = RichTextBoxDescrip.PrintDocument

        Select Case PrintDialog1.ShowDialog()
            Case DialogResult.OK
                RichTextBoxDescrip.SelPrint()
        End Select
    End Sub

    Private Sub ToolStripButton2Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripAbout.Click

        About.ShowDialog()
    End Sub

    Private Sub ToolStripButton8Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripForum.Click

        Try

            ' Modifié par Néo le 26/08/2009
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://www.zguidetv.net/") Then
                Process.Start("http://www.zguidetv.net/")

            Else
                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internat de zguidetv
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub ToolStripButton9Click1(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripWebsite.Click

        Try

            ' Modifié par Néo le 26/08/2009
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://zguidetv.codeplex.com") Then

                If My.Settings.Language = "Français" Then
                    Process.Start("http://zguidetv.codeplex.com/wikipage?title=home-fr")
                Else
                    Process.Start("http://zguidetv.codeplex.com/")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
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

            dDateSelection = nvDate
            g_Date = dDateSelection
            'd_DateSelectionnée = g_Date
            JourActif.dateActif = g_Date

            Dim nameofMonth() As String = {NameofMonth1, NameofMonth2, NameofMonth3, NameofMonth4, NameofMonth5, _
                                           NameofMonth6, NameofMonth7, NameofMonth8, NameofMonth9, NameofMonth10, _
                                           NameofMonth11, NameofMonth12}
            Dim sMois As String

            sMois = nameofMonth((g_Date.Month - 1))

            Dim sAnnée As String = g_Date.Year.ToString()

            Dim dDate As Date = g_Date

            Dim i As Integer
            Dim j As Integer
            Dim nPremierJour As Integer
            Dim nLigne As Integer
            Dim nColonne As Integer
            ' Dim nCouleur, nCouleurFond, nEtat As Integer

            L_MOIS_ANNEE.Text = sMois & " " & sAnnée

            dDate = g_Date.AddDays(-g_Date.Day + 1)
            nPremierJour = dDate.DayOfWeek
            With JourActif
                .NumPremierJour = nPremierJour
                .NumMois = dDate.Month
                .An = dDate.Year
            End With

            ' 18/09/2009 rvs75 ajout du style old_ui depuis .config
            ' +  reprise des du text du visible et du font du contrôle

            Dim ctrTest As Control
            Dim cpTest As calendrierpavé
            For Each ctrTest In Calendar.Controls
                If TypeOf (ctrTest) Is calendrierpavé Then
                    cpTest = CType(ctrTest, calendrierpavé)
                    cpTest.old_UI = CBool(My.Settings.oldUI)
                    cpTest.Text = "00"
                    cpTest.Visible = True
                    cpTest.Font = New Font(cpTest.Font, 0)
                End If
            Next ctrTest

            For i = 1 To 31

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
                    bouton As calendrierpavé = _
                        DirectCast(Calendar.Controls.Find("Button" & nColonne & "_" & nLigne, False)(0),  _
                        calendrierpavé)
                'If bouton.Length > 0 Then
                bouton.Text = i.ToString

                If JourActif.Présent(i, g_Date.Month, g_Date.Year) Then
                    If JourActif.bJourAffiché(i) Then
                        bouton.Font = New Font(bouton.Font, FontStyle.Bold)
                        bouton.BGColor = _
                            Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(77, Byte), Integer), _
                                            CType(CType(72, Byte), Integer))


                    Else
                        bouton.Font = New Font(bouton.Font, FontStyle.Bold)
                        bouton.BGColor = _
                            Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(181, Byte), Integer), _
                                            CType(CType(130, Byte), Integer))
                    End If

                Else
                    bouton.Font = New Font(bouton.Font, 0)
                    'bouton(0).ForeColor = Color.Black
                    bouton.BGColor = _
                        Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), _
                                        CType(CType(182, Byte), Integer))
                End If

                'End If

                ' Vérifie si le jour suivant est valide
                dDate = dDate.AddDays(1)
                If dDate.Month <> g_Date.Month Then
                    i = 32
                End If
            Next i

            For j = 1 To 7
                Dim bouton1() As Control = Calendar.Controls.Find("Button1_" & j, False)
                If bouton1.Length > 0 Then
                    If bouton1(0).Text = "00" Then
                        bouton1(0).Visible = False
                    End If
                End If

                Dim bouton5() As Control = Calendar.Controls.Find("Button5_" & j, False)
                If bouton5.Length > 0 Then
                    If bouton5(0).Text = "00" Then
                        bouton5(0).Visible = False
                    End If
                End If

                Dim bouton6() As Control = Calendar.Controls.Find("Button6_" & j, False)
                If bouton6.Length > 0 Then
                    If bouton6(0).Text = "00" Then
                        bouton6(0).Visible = False
                    End If
                End If
            Next j
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
        End Try
    End Sub

    Private Sub MoisSClick(ByVal sender As Object, ByVal e As EventArgs) Handles MoisS.Click
        IniCalendrier(g_Date.AddMonths(1))
    End Sub

    Private Sub MoisPClick(ByVal sender As Object, ByVal e As EventArgs) Handles MoisP.Click
        IniCalendrier(g_Date.AddMonths(-1))
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

    Private Sub ToolStripButton7Click2(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripCheckupdates.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            ' mise a jour logicielle
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://zguidetv.tuxfamily.org/") Then

                XMLParser()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le forum de zguidetv
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try

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
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://zguidetv.codeplex.com/") Then

                If My.Settings.Language = "Français" Then
                    Process.Start("http://zguidetv.codeplex.com/wikipage?title=home-fr")
                Else
                    Process.Start("http://zguidetv.codeplex.com/")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
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
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://www.zguidetv.net/") Then
                Process.Start("http://www.zguidetv.net/")

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le forum de zguidetv
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub AProposDeZGuideTvToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpAbout.Click

        About.ShowDialog()
    End Sub

    Private Sub VérificationDesMisesÀJourToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpCheckupdates.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            ' mise a jour logicielle
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://zguidetv.tuxfamily.org/") Then

                XMLParser()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le forum de zguidetv
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try

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

    Private Sub ImprimerToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuEditPrint.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ' On imprime la RichtextBoxDescrip
        ' http://msdn.microsoft.com/fr-fr/library/7d29f66t(VS.80).aspx
        PrintDialog1.Document = RichTextBoxDescrip.PrintDocument

        Select Case PrintDialog1.ShowDialog()
            Case DialogResult.OK
                RichTextBoxDescrip.SelPrint()
        End Select
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

    Private Sub ImprimerLaDescriptionToolStripMenuItem1Click1(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuPrintDescript.Click

        ' On imprime la RichtextBoxDescrip
        ' http://msdn.microsoft.com/fr-fr/library/7d29f66t(VS.80).aspx
        PrintDialog1.Document = RichTextBoxDescrip.PrintDocument

        Select Case PrintDialog1.ShowDialog()
            Case DialogResult.OK
                RichTextBoxDescrip.SelPrint()
        End Select
    End Sub

    Private Sub QuitterToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuFileExit.Click
        Dim i As Double
        Dim oldVal As Double

        ' on va écrire les dimensions et la position de la fenêtre principale et de boutons
        With My.Settings
            .WindowSizeMain = Size
            .WindowLocationMain = Location
            .buttonsstate = synth_boutons
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

    Private Sub ProgrammerktvClick(ByVal sender As Object, ByVal e As EventArgs) Handles programmerktv.Click
        ListRecKTV.ShowDialog()
    End Sub

    Private Sub ProgrammerMMTvToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuProgramMMTV.Click
        ' frmListRecKTV.Show()
    End Sub

    Private Sub ProgrammerKtvToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuProgramKTV.Click
        ListRecKTV.Fonction(1)
        ListRecKTV.ShowDialog()
    End Sub

    Private Function FctPathKtvRegistre() As String
        Return (Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\K!TV", "", "").ToString)
    End Function

    Private Sub ContextMenuKtvOpening(ByVal sender As Object, ByVal e As CancelEventArgs) _
        Handles Context_menu_KTV.Opening

        ' 08/01/2008 provisoirement on désactive le menu contextuel de mmtv
        ToolStripMenuZapperMMTV.Enabled = False
        ToolStripMenuProgramMMTV.Enabled = False
        ToolStripMenuGestionRecordMMTV.Enabled = False
        ToolStripMenuGestionChainesMMTV.Enabled = False

        '12/12/2008
        'Dim Ktvpath As String
        'Ktvpath = Fct_Path_KTV_Registre()

        'If My.Settings.KtvPath() = "" Then
        'ToolStripMenuZapperKTV.Enabled = False
        'ToolStripMenuProgramKTV.Enabled = False
        'ToolStripMenuGestionRecordKTV.Enabled = False
        'ToolStripMenuGestionChainesKTV.Enabled = False
        'Else

        If File.Exists(My.Settings.KtvPath() & "\K!TV.ini") Then
            If CType(sender, ContextMenuStrip).SourceControl.Name.ToString = "Botton_Em" Then
                Dim i As Integer
                Dim nomFichier As String
                Dim z As String = ""
                Dim bTrouvé As Boolean = False
                Central_Screen.repere_click_emission = CInt(CType(sender, ContextMenuStrip).SourceControl.TabIndex)
                Trace.WriteLine( _
                                 DateTime.Now & " " & "Tag de l'émission = " & _
                                 Central_Screen.repere_click_emission.ToString)
                Trace.WriteLine(DateTime.Now & " " & "composer message descript")
                Central_Screen.ComposerMessageDescrip(Central_Screen.repere_click_emission, "principale")
                PictureBoxLogo.SuspendLayout()
                PictureBoxLogo.Controls.Clear()
                'Central_Screen.kill_handle(PictureBoxLogo)

                ' il faut rechercher le nom de la chaine
                ' à partir de ChannelID
                For i = 1 To nb_total_chaines
                    z = tableau_chaine(i).identificateur
                    If z = s_chid Then
                        Exit For
                    End If
                Next i
                nomFichier = tableau_chaine(i).logo
                DrawLogoInPictureboxlogo(nomFichier)
                PictureBoxLogo.ResumeLayout()
                Refresh()

                ' On recherche s'il y a une correspondance K!Tv
                ' et cette chaine
                ' S'il n'y a pas on grise certaine partie du menu
                Dim zName As String = ""
                Dim zId As String = ""
                If Not (Not My.Settings.KtvPath Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.KtvPath)) Then
                    Dim ktvChannels() As String = KTvForm.Fct_KTV_Channels(My.Settings.KtvPath)
                    Dim xmlChannels As New ChannelsConfigs
                    Dim ktvSource As String = My.Settings.KtvSource
                    If ktvChannels.Length > 0 Then
                        For i = 1 To (ktvChannels.Length)
                            xmlChannels.GetLogChannel(i.ToString, "KTV", ktvSource, zName, zId)
                            If Not (Not zName Is Nothing AndAlso String.IsNullOrEmpty(zName)) Then
                                If z = zId Then
                                    bTrouvé = True
                                    Exit For
                                End If
                            End If
                        Next i
                    End If
                End If
                If bTrouvé Then
                    EmmissionSel = tableau_list_emissions(Central_Screen.repere_click_emission)
                    KtvChannel = i
                    ToolStripMenuProgramKTV.Enabled = True
                    ToolStripMenuZapperKTV.Enabled = True
                Else
                    EmmissionSel = Nothing
                    KtvChannel = 0
                    ToolStripMenuProgramKTV.Enabled = False
                    ToolStripMenuZapperKTV.Enabled = False
                End If
                ToolStripMenuGestionRecordKTV.Enabled = True
            End If
        Else
            ToolStripMenuProgramKTV.Enabled = False
            ToolStripMenuZapperKTV.Enabled = False
            ToolStripMenuGestionRecordMMTV.Enabled = False
        End If
        ' End If
    End Sub

    Private Sub GestionDesEnregistrementsKtvToolStripMenuItem1Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuGestionRecordKTV.Click
        ListRecKTV.Fonction(2)
        ListRecKTV.ShowDialog()
    End Sub

    Private Sub ZapperDansKtvToolStripMenuItem1Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuZapperKTV.Click
        If KtvChannel > 0 Then
            If Not (Not My.Settings.KtvPath Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.KtvPath)) Then
                Try
                    Process.Start(My.Settings.KtvPath & "\K!TV.exe", "-c=" & KtvChannel.ToString)
                Catch ex As Exception
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                End Try
            End If

            'RetVal = ShellExecute(Me.hwnd, "open", KTV_Path & "\K!TV.exe", "-c=" & CStr(ChannelKTV), KTV_Path, SW_MAXIMIZE)
        End If
    End Sub

    Private Sub ToolStripAutoUpdateClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripAutoUpdate.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            If IsNetConnectOnline() Then
                MajGrilleTv()
                MajGrilleTvBouton()
            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' une mise à jour auto
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub MajGrilleTvBouton()

        ' on a cliqué sur mise à jour ( soit bouton barre d outils , soit menu/option/mise à jour automatique
        Trace.WriteLine(DateTime.Now & " toolstripbouton2_click = mise a jour semi automatique")

        ' maj_grille_tv()
        If MajautoReussie Then ' ce flag est positionne à true dans SR majauto
            Timer_minute.Stop()
            Trace.WriteLine(DateTime.Now & "miseajour auto reussie ")

            ' C'est une mise a jour automatique
            If (_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6 Then

                Try
                    If My.Settings.AudioOn Then
                        ' le volume va de 0 (max) à -10000 (min)
                        Dim audioPlay As Audio
                        audioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                        audioPlay.Volume = My.Settings.MessagesVolume
                        audioPlay.Play()
                    End If
                Catch ex As DirectXException
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                End Try

                Dim boxMiseaJourAuto As DialogResult
                boxMiseaJourAuto = _
                    MessageBox.Show( _
                                     Miseajour.MessageBoxMiseaJourDone & Chr(13) & _
                                     Miseajour.MessageBoxMiseaJour1Done, Miseajour.MessageBoxMiseaJourTitreDone, _
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
            successRecuperation = Miseajour.CopierFichier(BDDPath & "db_progs.bak", BDDPath & "db_progs.db3", True)
            My.Settings.datemajmiseajour = DateMajBack
            Const errorMajauto As String = "la mise à jour automatique a echoué et se fera plus tard"
            Trace.WriteLine(DateTime.Now & " " & errorMajauto)
            Dim fenMessage As New Message(errorMajauto, MsgBoxStyle.Critical, True)
            fenMessage.ShowDialog()

            If successRecuperation Then
                Const fichierRetabli As String = " Les fichiers initiaux ont été Retablis"
                Dim fenMessage1 As New Message(fichierRetabli, MsgBoxStyle.Critical, True)
                fenMessage1.ShowDialog()
            Else
                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "la restauration de db_prog.db3 a echoue apres constatation de fichier corrompu")
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
            b2 = (Not (Not My.Settings.Lienmiseajour Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Lienmiseajour)))

        Else
            b1 = My.Settings.DIRChecked
            b2 = (Not (Not My.Settings.Cheminmiseajour Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Cheminmiseajour)))
        End If

        b3 = My.Settings.Epgdata
        If Not ((b1 Or b3) AndAlso b2) Then
            Trace.WriteLine( _
                             DateTime.Now & _
                             "une mise à jour manuelle des grilles tv doit préceder la mise à jour automatique ou sa demande par boutons")
            Trace.WriteLine(DateTime.Now & " la maj des grilles tv  a été arretée")
            Return
        Else

            If My.Settings.URLChecked Then
                ' a t on une connection internet? testée avec google
                Try
                    If Not IsNetConnectOnline() Then
                        Trace.WriteLine(DateTime.Now & " Pas de connexion Internet ou Google ne répond pas")
                        Return
                    Else
                        Timer_minute.Stop()
                        maj_auto_flag = True
                        If My.Settings.Epgdata Then
                            miseajourautoEPGDATA.Show()
                        Else
                            ' pour differencier les progress bar à mettre à jour
                            MiseAJourAuto.Show()
                            Trace.WriteLine(DateTime.Now & " juste avant traitement_appliquer()")
                            traitement_appliquer()
                        End If
                        Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                        'BB240609
                        Timer_minute.Start()
                        'BB 210610
                        Timer_minute.Enabled = True
                        maj_auto_flag = False
                    End If

                Catch ex As Exception
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                    'BB240609
                    Timer_minute.Start()
                    Timer_minute.Enabled = True
                    '220610
                    maj_auto_flag = False
                    MajautoReussie = False
                End Try
            Else
                Timer_minute.Stop()
                maj_auto_flag = True
                ' pour differencier les progress bar à mettre à jour
                MiseAJourAuto.Show()
                Trace.WriteLine(DateTime.Now & " juste avant traitement_appliquer()")
                traitement_appliquer()
                Trace.WriteLine(DateTime.Now & " " & "redemarrage du timer_minute " & DateTime.Now.ToString)
                'BB240609
                Timer_minute.Start()
                'BB 210610
                Timer_minute.Enabled = True
                maj_auto_flag = False
            End If
        End If
    End Sub

    Private Sub ImprimerCeSoirToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuPrintTonight.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        imprimer_fichier_ce_soir()
    End Sub

    Private Sub ToolStripSearchClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripSearch.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        TriAvance.ShowDialog()

    End Sub

    Private Sub ToolStripSearchMenuClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuSearch.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        TriAvance.ShowDialog()

    End Sub

    Private Sub ToolStripMenuOptionsDualMonitorClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsDualMonitor.Click

        DualMonitor()
    End Sub

    Private Sub MiseÀJourManuelleToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsUpdate.Click

        Try
            If My.Settings.Epgdata Then
                If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://www.epgdata.com/") Then
                    MiseajourEPGData.Show()
                Else

                    ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                    ' faire une mise à jour manuelle
                    Dim BoxNoConnection As DialogResult
                    BoxNoConnection = _
                        MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                         MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                         MessageBoxIcon.Exclamation)

                End If
            Else
                Miseajour.Show()
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripMenuOptionsAutoUpdateClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsAutoUpdate.Click

        Try
            If My.Settings.URLChecked = True Then
                If IsNetConnectOnline() Then
                    MajGrilleTv()
                    MajGrilleTvBouton()

                Else

                    ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                    ' une mise à jour auto
                    Dim BoxNoConnection As DialogResult
                    BoxNoConnection = _
                        MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                         MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                         MessageBoxIcon.Exclamation)
                End If
            Else
                MajGrilleTv()
                MajGrilleTvBouton()
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
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
                    ' le volume va de 0 (max) à -10000 (min)
                    Dim audioPlay As Audio
                    audioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                    audioPlay.Volume = My.Settings.MessagesVolume
                    audioPlay.Play()
                End If
            Catch ex As DirectXException
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            Dim boxModifPref As DialogResult
            boxModifPref = _
                MessageBox.Show(MessageBoxModifPref & Chr(13) & Chr(13) & MessageBoxModifPref1, _
                                 MessageBoxModifPrefTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
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
            ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1)) AndAlso AppliRestart AndAlso _
            My.Settings.firststart = False Then

            AppliRestart = False
            Timer_wait.Enabled = False
            My.Settings.Save()

            Try
                If My.Settings.AudioOn Then
                    ' le volume va de 0 (max) à -10000 (min)
                    Dim audioPlay As Audio
                    audioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                    audioPlay.Volume = My.Settings.MessagesVolume
                    audioPlay.Play()
                End If
            Catch ex As DirectXException
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            Dim boxMiseaJourAuto As DialogResult
            boxMiseaJourAuto = _
                MessageBox.Show(MessageBoxMiseaJourDone & Chr(13) & MessageBoxMiseaJour1Done, _
                                 MessageBoxMiseaJourTitreDone, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
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

    Private Sub RichTextBoxDescripMouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RichTextBoxDescrip.MouseEnter
        With RichTextBoxDescrip
            .Focus()
            .DeselectAll()
        End With
    End Sub

    Private Sub RichTextBoxDescripMouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RichTextBoxDescrip.MouseLeave
        With PanelB
            .Focus()
            .Select()
        End With
    End Sub

    Private Sub RechercheInfosToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RechercheInfosToolStripMenuItem.Click


        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Try

            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://www.thetvdb.com") Then

                search.ShowDialog()

            Else
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try

    End Sub

    ' GESTION DU SCROLL DANS TREEVIEW1(liste des categories)
    Private Sub PanelDevantMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles Panel_devant.MouseWheel
        If FilledTreeviewheight <= ButtonBas1.Top - ToolStrip1.Bottom Then
            Exit Sub

            ' le treeview est - haut que l espace disponible,pas de scroll autorisé
        Else
            If e.Delta < 0 Then

                ' on remonte le treeview
                Trace.WriteLine(DateTime.Now & " " & "on remonte le treeview1")
                TreeView1.Top -= 20
                Trace.WriteLine(DateTime.Now & " " & "treeview1.top= " & TreeView1.Top.ToString)
                If TreeView1.Top < -0.75 * FilledTreeviewheight Then
                    TreeView1.Top = 0
                End If
                Trace.WriteLine(" ")
            Else

                ' on redescend le treeview
                Trace.WriteLine(DateTime.Now & " " & "on redescend le treeview1")
                TreeView1.Top += 20
                Trace.WriteLine(DateTime.Now & " " & "treeview1 pass a " & TreeView1.Top.ToString)
                If TreeView1.Top > 0 Then
                    TreeView1.Top -= 20
                End If
            End If
            TreeView1.Visible = True
            ' BB 231009
            PanelB.Visible = True
            ' BB ..
            Button1.BringToFront()
            ' BB ..
            TreeView1.ExpandAll()
            ' BB ..
        End If
    End Sub

    Private Sub ButtonGaucheMouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonGauche.MouseHover

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> ButtonGauche_MouseHover")
        PanelB.Focus()

        ' redonner le focus au panneau central
        With TreeView1
            .Visible = True
            .Top = 0
        End With
        ' recaler le treeview vers le haut
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ButtonGauche_MouseHover")
    End Sub

    Friend Sub PanelCeSoirEnter(ByVal sender As Object, ByVal e As EventArgs)
        Panel_ce_soir.Select()
    End Sub

    Friend Sub PanelCeSoirLeave(ByVal sender As Object, ByVal e As EventArgs)
        PanelB.Select()
    End Sub

    Friend Sub PanelMaintenantEnter(ByVal sender As Object, ByVal e As EventArgs)
        Panel_maintenant.Select()
    End Sub

    Public Sub Myjumplist()
        Try

            Trace.WriteLine(" ")
            Trace.WriteLine(DateTime.Now & " " & "Nous sommes dans un second Thread")
            Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> Private Sub Myjumplist()")

            Dim data As ShellLink
            jumplist = CreateJumpListManager()

            ' Pour avoir accès à la base de registre 64bits
            Using _
                localMachine As RegistryKey = _
                    RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)

                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "On est dans le mainform --> Myjumplist. On ajoute le lien du site internet dans la jumplist")

                ' Windows 7 seulement. On affiche le lien vers le site officiel de ZGuideTV.NET
                ' dans la jumplist de la taskbar http://zguidetv.codeplex.com/ 
                data = New ShellLink
                With data
                    .Path = "http://zguidetv.codeplex.com/"
                    .Title = SiteOfficiel
                    .Category = "ZGuideTV.NET"
                    .IconLocation = AppPath & "\" & "ZGuideTVDotNet.Resources.dll"
                    .IconIndex = 1
                End With

                jumplist.AddUserTask(data)

                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "On est dans le mainform --> Myjumplist(). On ajoute le lien du forum internet dans la jumplist")
                ' Windows 7 seulement. On affiche le lien vers le site officiel de ZGuideTV.NET
                ' dans la jumplist de la taskbar http://zguidetv.codeplex.com/
                data = New ShellLink
                With data
                    .Path = "http://www.zguidetv.net/"
                    .Title = ForumOfficiel
                    .Category = "ZGuideTV.NET"
                    .IconLocation = AppPath & "\" & "ZGuideTVDotNet.Resources.dll"
                    .IconIndex = 2
                End With

                jumplist.AddUserTask(data)

                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "On est dans le mainform --> Myjumplist(). On ajoute le lien de K!TV dans la jumplist")
                ' Windows 7 seulement. On affiche une séparation si une des applications ci-dessous
                ' est présente et affichée dans la jumplist de la taskbar
                If (Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\K!TV", "", "")) IsNot Nothing Or _
                   (Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\MeuhMeuhTV", "", "")) IsNot Nothing Or _
                   (Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ProgDVB", _
                                       "", _
                                       "")) IsNot Nothing Or _
                   (Registry.GetValue( _
                                       "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Pouchin TV Mod", _
                                       "", "")) IsNot Nothing Or _
                   localMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Pouchin TV Mod") IsNot _
                   Nothing Then

                    jumplist.AddUserTask(New Separator())
                End If

                ' Windows 7 seulement. On regarde dans la base de registre si K!TV est installé
                ' Si K!TV est installé on l'ajoute dans la jumplist de la taskbar
                Dim ktvpath As String
                If (Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\K!TV", "", "")) IsNot Nothing Then
                    ktvpath = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\K!TV", "", "").ToString
                    data = New ShellLink
                    With data
                        .Path = ktvpath & "\" & "K!TV.exe"
                        .Title = "K!TV"
                        .Category = "Applications"
                        .IconLocation = ktvpath & "\" & "K!TV.exe"
                        .IconIndex = 0
                    End With

                    jumplist.AddUserTask(data)
                End If

                'jumplist.AddUserTask(New Separator())

                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "On est dans le mainform --> Myjumplist(). On ajoute le lien de MeuhMeuhTV dans la jumplist")
                ' Windows 7 seulement. On regarde dans la base de registre si MeuhMeuhTV est installé
                ' Si MeuhMeuhTV est installé on l'ajoute dans la jumplist de la taskbar
                Dim meuhMeuhTvPath As String
                If (Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MMTV", "", "")) IsNot Nothing Then
                    meuhMeuhTvPath = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MMTV", "Directory", "").ToString
                    data = New ShellLink
                    With data
                        .Path = meuhMeuhTvPath & "\" & "MeuhMeuhTV.exe"
                        .Title = "MeuhMeuhTV"
                        .Category = "Applications"
                        .IconLocation = meuhMeuhTvPath & "\" & "MeuhMeuhTV.exe"
                        .IconIndex = 0
                    End With

                    jumplist.AddUserTask(data)
                End If

                'jumplist.AddUserTask(New Separator())

                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "On est dans le mainform --> Myjumplist(). On ajoute le lien de Pouchin TV MOd dans la jumplist")
                ' Pouchin TV Mod 32 bit seulement
                ' Windows 7 seulement. On regarde dans la base de registre si Pouchin 32 bit est installé
                ' Si Pouchin est installé on l'ajoute dans la jumplist.
                Dim pouchinPath As String
                If _
                    (Registry.GetValue( _
                                        "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Pouchin TV Mod", _
                                        "", _
                                        "")) IsNot _
                    Nothing Then
                    pouchinPath = _
                        Registry.GetValue( _
                                           "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Pouchin TV Mod", _
                                           "InstallLocation", "").ToString
                    data = New ShellLink
                    With data
                        .Path = pouchinPath & "\" & "PouchinTVMod.exe"
                        .Title = "Pouchin TV Mod"
                        .Category = "Applications"
                        .IconLocation = pouchinPath & "\" & "PouchinTVMod.exe"
                        .IconIndex = 0
                    End With

                    jumplist.AddUserTask(data)
                End If

                ' Pouchin TV Mod 64 bit seulement
                ' Windows 7 seulement. On regarde dans la base de registre si Pouchin TV Mod 64 bit est installé
                ' Si Pouchin est installé on l'ajoute dans la jumplist.
                Dim reg As RegistryKey

                If _
                    localMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Pouchin TV Mod") IsNot _
                    Nothing Then

                    reg = localMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Pouchin TV Mod")
                    pouchinPath = CStr(reg.GetValue("InstallLocation"))

                    data = New ShellLink
                    With data
                        .Path = pouchinPath & "\" & "PouchinTVMod_x64.exe"
                        .Title = "Pouchin TV Mod"
                        .Category = "Applications"
                        .IconLocation = pouchinPath & "\" & "PouchinTVMod_x64.exe"
                        .IconIndex = 0
                    End With

                    jumplist.AddUserTask(data)
                End If
            End Using

            Trace.WriteLine( _
                             DateTime.Now & " " & _
                             "On est dans le mainform --> Myjumplist(). On ajoute le lien de ProgDVB dans la jumplist")
            ' ProgDVB 32 bit seulement
            ' Windows 7 seulement. On regarde dans la base de registre si ProgDVB 32 bit est installé
            ' Si ProgDVB est installé on l'ajoute dans la jumplist.
            Dim progDvbPath As String
            If _
                (Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ProgDVB", "", _
                                    "")) IsNot _
                Nothing Then
                progDvbPath = _
                    Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ProgDVB", _
                                       "InstallDir", "").ToString
                data = New ShellLink
                With data
                    .Path = progDvbPath & "\" & "ProgDvbNet.exe"
                    .Title = "ProgDVB"
                    .Category = "Applications"
                    .IconLocation = progDvbPath & "\" & "ProgDvbNet.exe"
                    .IconIndex = 0
                End With

                jumplist.AddUserTask(data)
            End If

            ' ProgDVB 64 bit seulement
            ' Windows 7 seulement. On regarde dans la base de registre si ProgDVB 32 bit est installé
            ' Si ProgDVB est installé on l'ajoute dans la jumplist.
            Using _
                localMachine As RegistryKey = _
                    RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                Dim reg As RegistryKey

                If localMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ProgDVB") IsNot Nothing _
                    Then

                    reg = localMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ProgDVB")
                    progDvbPath = CStr(reg.GetValue("InstallDir"))

                    data = New ShellLink
                    With data
                        .Path = progDvbPath & "\" & "ProgDvbNet.exe"
                        .Title = "ProgDVB"
                        .Category = "Applications"
                        .IconLocation = progDvbPath & "\" & "ProgDvbNet.exe"
                        .IconIndex = 0
                    End With

                    jumplist.AddUserTask(data)
                End If
            End Using

            'jumplist.AddUserTask(New Separator())

            Trace.WriteLine( _
                             DateTime.Now & " " & _
                             "On est dans le mainform --> Myjumplist(). On ajoute le lien de ZViewTV.NET dans la jumplist")
            ' Windows 7 seulement. On regarde dans la base de registre si ZViewTV.NET est installé
            ' Si ZViewTV.NET est installé on l'ajoute dans la jumplist de la taskbar
            Dim zViewTvPath As String
            If (Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ZGuideTV Team\ZViewTV.NET", "", "")) IsNot Nothing Then
                zViewTvPath = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ZGuideTV Team\ZViewTV.NET\Settings", _
                                                 "InstallPath", "").ToString
                data = New ShellLink
                With data
                    .Path = zViewTvPath & "\" & "ZViewTVDotNet.exe"
                    .Title = "ZViewTV.NET"
                    .Category = "Applications"
                    .IconLocation = zViewTvPath & "\" & "ZViewTVDotNet.exe"
                    .IconIndex = 0
                End With

                jumplist.AddUserTask(data)
            End If

            ' Windows 7 seulement. Ceci est un test d'ouverture de fichier dans la taskbar
            'data = New ShellLink
            'data.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "notepad.exe")
            'data.Title = "Notepad"
            'data.IconLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "notepad.exe")
            'data.IconIndex = 0
            'data.Arguments = AppPath & "ZGuideTVDotNet.exe.config"
            'jumplist.AddUserTask(data)

            Trace.WriteLine(DateTime.Now & " " & "On est dans le mainform --> Myjumplist(). On rafraichi la jumplist")
            jumplist.Refresh()

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            Trace.WriteLine( _
                             DateTime.Now & " " & _
                             "On est dans le mainform --> Myjumplist(). Erreur dans la création de la jumplist")
        End Try

        Trace.WriteLine( _
                         DateTime.Now & " " & _
                         "On est dans le mainform --> Myjumplist(). On quitte Private Sub Myjumplist()")
        Trace.WriteLine(DateTime.Now & " " & "Nous quittons le second Thread")
        Trace.WriteLine(" ")
    End Sub

    Private Sub jumplist_UserRemovedItems(ByVal sender As Object, ByVal e As UserRemovedItemsEventArgs) _
        Handles jumplist.UserRemovedItems
        ' rien à enlever
    End Sub

    Private Sub TreeView1MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles TreeView1.MouseHover

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> TreeView1")
        Panel_devant.Focus()
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> TreeView1")
    End Sub

    Public Sub MaJDateStatusBar()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> MaJ_Date_StatusBar")
        ToolStripStatusLabel_date.Text = DateLangue(DateTime.Today)
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> MaJ_Date_StatusBar")
    End Sub

    Private Sub TimerSecondeTick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_seconde.Tick

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> Timer_seconde")
        If My.Settings.Language = "English" Then
            ToolStripStatusLabel_heure.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture)
        Else
            ToolStripStatusLabel_heure.Text = DateTime.Now.ToString("HH:mm:ss", CultureInfo.CurrentCulture)
        End If
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> Timer_seconde")
    End Sub

    Private Sub RedémmarerToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuFileRestart.Click
        Close()
        Application.Restart()
    End Sub

    Private Sub Timer500MsecTick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_500msec.Tick

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> Timer_500msec")
        ' apres 500 msec, remettre à 0 tsh traitement scroll horizontal
        TshEnCours = False
        Timer_500msec.Enabled = False
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> Timer_500msec")
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
            If IsNetConnectOnline() Then
                My.Settings.ManualFeedBack = True
                Feedback.ShowDialog()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' un Feedback manuel
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
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
            If IsNetConnectOnline() Then
                My.Settings.ManualFeedBack = True
                Feedback.ShowDialog()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' un Feedback manuel
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ToolStripManualFeedBack")
    End Sub

    Private Sub ToolStripButton2Click3(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripCategories.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Button1.PerformClick()
    End Sub

    Private Sub AffichercacherCatégoriesToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuCategories.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Button1.PerformClick()
    End Sub

    Private Sub ToolStripCalendarClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripCalendar.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ButtonDroit.PerformClick()
    End Sub

    Private Sub AfficherCacherCalendrierToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuCalendar.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ButtonDroit.PerformClick()
    End Sub

    Private Sub ToolStripButton3Click2(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripDescription.Click
        ButtonBas1.PerformClick()
    End Sub

    Private Sub AfficherCacherDescriptionToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuDescription.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ButtonBas1.PerformClick()
    End Sub

    Private Sub ToolStripButton2Click4(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RechercheToolStripButton.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> ToolStripButton2")
        Try

            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://www.thetvdb.com") Then

                search.ShowDialog()

            Else
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ToolStripButton2")
    End Sub

    Public Sub BloquerBoutonCalendrier()
        Button1_1.Enabled = False
        Button1_2.Enabled = False
        Button1_3.Enabled = False
        Button1_4.Enabled = False
        Button1_5.Enabled = False
        Button1_6.Enabled = False
        Button1_7.Enabled = False

        Button2_1.Enabled = False
        Button2_2.Enabled = False
        Button2_3.Enabled = False
        Button2_4.Enabled = False
        Button2_5.Enabled = False
        Button2_6.Enabled = False
        Button2_7.Enabled = False

        Button3_1.Enabled = False
        Button3_2.Enabled = False
        Button3_3.Enabled = False
        Button3_4.Enabled = False
        Button3_5.Enabled = False
        Button3_6.Enabled = False
        Button3_7.Enabled = False

        Button4_1.Enabled = False
        Button4_2.Enabled = False
        Button4_3.Enabled = False
        Button4_4.Enabled = False
        Button4_5.Enabled = False
        Button4_6.Enabled = False
        Button4_7.Enabled = False

        Button5_1.Enabled = False
        Button5_2.Enabled = False
        Button5_3.Enabled = False
        Button5_4.Enabled = False
        Button5_5.Enabled = False
        Button5_6.Enabled = False
        Button5_7.Enabled = False

        Button6_1.Enabled = False
        Button6_2.Enabled = False
        Button6_3.Enabled = False
        Button6_4.Enabled = False
        Button6_5.Enabled = False
        Button6_6.Enabled = False
        Button6_7.Enabled = False

    End Sub

    Public Sub AutoriserBoutonCalendrier()
        Button1_1.Enabled = True
        Button1_2.Enabled = True
        Button1_3.Enabled = True
        Button1_4.Enabled = True
        Button1_5.Enabled = True
        Button1_6.Enabled = True
        Button1_7.Enabled = True

        Button2_1.Enabled = True
        Button2_2.Enabled = True
        Button2_3.Enabled = True
        Button2_4.Enabled = True
        Button2_5.Enabled = True
        Button2_6.Enabled = True
        Button2_7.Enabled = True

        Button3_1.Enabled = True
        Button3_2.Enabled = True
        Button3_3.Enabled = True
        Button3_4.Enabled = True
        Button3_5.Enabled = True
        Button3_6.Enabled = True
        Button3_7.Enabled = True

        Button4_1.Enabled = True
        Button4_2.Enabled = True
        Button4_3.Enabled = True
        Button4_4.Enabled = True
        Button4_5.Enabled = True
        Button4_6.Enabled = True
        Button4_7.Enabled = True

        Button5_1.Enabled = True
        Button5_2.Enabled = True
        Button5_3.Enabled = True
        Button5_4.Enabled = True
        Button5_5.Enabled = True
        Button5_6.Enabled = True
        Button5_7.Enabled = True

        Button6_1.Enabled = True
        Button6_2.Enabled = True
        Button6_3.Enabled = True
        Button6_4.Enabled = True
        Button6_5.Enabled = True
        Button6_6.Enabled = True
        Button6_7.Enabled = True

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
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("https://www.paypal.com/") Then
                Process.Start( _
                               "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=neojudgment%40hotmail%2ecom&lc=BE&item_name=ZGuideTV%20Team&currency_code=EUR&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted")

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur Paypal
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub ToolStripStatusLabelCompensationDoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelCompensation.DoubleClick
        TimeZone.ShowDialog()
    End Sub

    Private Sub ToolStripStatusLabelMinutesDoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelMinutes.DoubleClick
        TimeZone.ShowDialog()
    End Sub

    Private Sub SélectionDeLaRechercheToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuOptionsEngineSelection.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        EngineSelection.ShowDialog()
    End Sub

    Private Sub ToolStripStatusLabel1DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelActiveEngine.DoubleClick
        EngineSelection.ShowDialog()
    End Sub

    Private Sub ToolStripStatusLabel2DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelEngine.DoubleClick
        EngineSelection.ShowDialog()
    End Sub

    Sub Rssfeed()

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        ' Lecture du flux rss
        ' Néo 16/03/2010
        Try
            ' Valeur en px de la position de gauche par défaut (sur base d'une longueur de 602px) du Label "ToolStripMenuNews"
            ToolStripMenuNews.Text = ""
            ToolStripMenuNews.Left = MenuStrip1.Right - 602

            Trace.WriteLine(DateTime.Now.ToString & " On met à jour le flux rss dans rssfeed()")
            Dim url As String
            If My.Settings.Language = "Français" Then
                url = "http://zguidetv.tuxfamily.org/fluxrssfr.xml"
            Else
                url = "http://zguidetv.tuxfamily.org/fluxrssen.xml"
            End If

            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable(url) Then
                Dim reader As XmlReader = XmlReader.Create(url)
                Dim feed As SyndicationFeed = SyndicationFeed.Load(reader)
                ToolStripMenuNews.Text = feed.Title.Text

                'On regarde si on vient de frmSelectLAnguage (true)
                If My.Settings.RssFeedLanguage Then
                    My.Settings.RssFeed = feed.Title.Text
                    My.Settings.RssFeedLanguage = False
                End If

                'On regarde si on vient du timer_minute
                If My.Settings.RssFeedMinute AndAlso My.Settings.RssFeed <> feed.Title.Text Then
                    My.Settings.RssFeed = feed.Title.Text

                    Try
                        If My.Settings.AudioOn Then
                            ' le volume va de 0 (max) à -10000 (min)
                            Dim audioPlay As Audio
                            audioPlay = New Audio(MediaPath & My.Settings.RSSSound, True)
                            audioPlay.Volume = My.Settings.RSSVolume
                            audioPlay.Play()
                        End If
                    Catch ex As DirectXException
                        Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    End Try

                    My.Settings.RssFeedMinute = False
                End If

                'On sauvegarde le flux rss dans My.Settings.RssFeed
                If _
                    (Not My.Settings.RssFeed Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.RssFeed)) AndAlso _
                    Not (Not feed.Title.Text Is Nothing AndAlso String.IsNullOrEmpty(feed.Title.Text)) Then
                    My.Settings.RssFeed = feed.Title.Text
                End If

                ' On recalcule la position de gauche du Label "ToolStripMenuNews" en 
                ' fonction de sa longueur (nombre de caractères exprimé ici en px)  
                With ToolStripMenuNews
                    If .Width > 602 Then
                        .Left = .Left + (.Width - 602)
                    End If
                    If .Width < 602 Then
                        .Left = .Left - (.Width - 602)
                    End If
                End With

                'on lit l'URL contenue dans le flux ress
                rsslink = feed.Links.First().Uri.AbsoluteUri.ToString(CultureInfo.CurrentCulture)
                If Not (Not feed.Title.Text Is Nothing AndAlso String.IsNullOrEmpty(feed.Title.Text)) Then
                    ToolStripMenuNews.Cursor = Cursors.Hand
                End If

                reader.Close()
            End If

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            Trace.WriteLine(DateTime.Now.ToString & " Erreur dans rssfeed()")
            Return
        End Try

    End Sub

    Private Sub ToolStripMenuNewsClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuNews.Click
        Try

            ' Modifié par Néo le 15/03/2010
            Trace.WriteLine( _
                             DateTime.Now.ToString & _
                             "  On teste la connection internet de l'URL dans le flux rss suivant la langue")
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable(rsslink) Then
                Process.Start(rsslink)
            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site contenu dans le link du fichier rss
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub LégendesEtClassementDuContenuToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpContent.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        signaletique.ShowDialog()
    End Sub

    Private Sub PluginsToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpPlugins.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton2Click5(ByVal sender As Object, ByVal e As EventArgs)

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripMenuItemHelpWeatherClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpWeather.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> ToolStripMenuItemHelpWeather")
        Try

            ' Prévision météo
            If IsNetConnectOnline() Then
                Forecast.ShowDialog()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' les prévisions météo
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ToolStripMenuItemHelpWeather")
    End Sub

    Private Sub ToolStripStatusLabelWeatherImageClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelWeatherImage.DoubleClick

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> ToolStripStatusLabelWeatherImage")
        Try

            ' Prévision météo
            If IsNetConnectOnline() Then
                Forecast.ShowDialog()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' les prévisions météo
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ToolStripStatusLabelWeatherImage")
    End Sub

    Private Sub ToolStripStatusLabelWeatherClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelWeather.DoubleClick

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> ToolStripStatusLabelWeather")
        Try

            ' Prévision météo
            If IsNetConnectOnline() Then
                Forecast.ShowDialog()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' les prévisions météo
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> ToolStripStatusLabelWeather")
    End Sub

    Private Sub EmplacementToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripMenuHelpLocation.Click

        ' La bdd n'existe pas ou est périmée
        If Not My.Settings.BddExists OrElse My.Settings.DataBaseExpired Then
            Exit Sub
        End If

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le mainform --> EmplacementToolStripMenuItem")
        Try

            ' Sélection de l'emplacement géographique
            If IsNetConnectOnline() Then
                WeatherCitySelect.ShowDialog()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' l'emplacement géographique
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
        Trace.WriteLine(DateTime.Now & " " & "On sort du mainform --> EmplacementToolStripMenuItem")
    End Sub

    Private Sub TimerHeureTick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_heure.Tick
        ' interrupt toutes les heures
        Trace.WriteLine( _
                         DateTime.Now.ToString & _
                         " entre dans timer 1 heure pour effectuer un rappel des emissions marquees")
        maj_fichier_marquage()
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
        Dim sr As New StreamReader(nomDuFichier)

        mon_stream_document = New StreamReader(nomDuFichier)
        Dim strligne, ch1, ss As String

        Trace.WriteLine(DateTime.Now & " " & "liste des emissions memorisees dans le fichier ZGuideTVDotNet.marked.set")
        Dim indice As Integer = 0
        Do While (mon_stream_document.Peek <> -1) ' tant qu il y a des records ds le fichier
            strligne = mon_stream_document.ReadLine
            If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                Trace.WriteLine(strligne)
                chaineAExaminer(indice) = strligne
                indice += 1
            End If
        Loop

        'Faut il faire un rappel sonore pour une emission marquée? BB110810
        ' On le fait si on est dans la tranche de 8 heures qui precedent l emission
        Dim _
            sActuelleDecalee As String = _
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
                    ' le volume va de 0 (max) à -10000 (min)
                    Dim audioPlay As Audio
                    audioPlay = New Audio(MediaPath & My.Settings.ReminderSound, True)
                    audioPlay.Volume = My.Settings.ReminderVolume
                    audioPlay.Play()
                End If
            Catch ex As DirectXException
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            ' ou tout autre traitement
        End If

        sr.Close()
        mon_stream_document.Close()
        mon_stream_document = Nothing
        ss = Nothing
        ch1 = Nothing
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

        _autoComplete.Add(ToolStripTextBoxRecherche.Text)
        If _
            ToolStripTextBoxRecherche.TextLength > 1 AndAlso _
            ToolStripTextBoxRecherche.Text <> lngToolStripTextBoxRecherche Then
            TriAvance.Textbox_titre.Text = ToolStripTextBoxRecherche.Text
            RechercheTextBoxToolStrip()
            TriAvance.ShowDialog()
        End If
        Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform ToolStripButtonRecherche_Click")
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
            .Text = lngToolStripTextBoxRecherche
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
            Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform ToolStripButtonRecherche_Click")

            _autoComplete.Add(ToolStripTextBoxRecherche.Text)
            If _
                ToolStripTextBoxRecherche.TextLength > 1 AndAlso _
                ToolStripTextBoxRecherche.Text <> lngToolStripTextBoxRecherche Then
                TriAvance.Textbox_titre.Text = ToolStripTextBoxRecherche.Text
                RechercheTextBoxToolStrip()
                TriAvance.ShowDialog()
            End If
            Trace.WriteLine(DateTime.Now & " " & "On entre dans mainform ToolStripButtonRecherche_Click")

        End If
    End Sub

    Private Sub ToolStripHelptopicsClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripHelptopics.Click

        Try

            ' Modifié par Néo le 13/02/2011
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://zguidetv.codeplex.com") Then

                If My.Settings.Language = "Français" Then

                    Process.Start("http://zguidetv.codeplex.com/wikipage?title=Quick%20Start-fr")
                Else
                    Process.Start("http://zguidetv.codeplex.com/wikipage?title=Quick%20Start")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripStatusLabelWakeUpClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ToolStripStatusLabelWakeUp.DoubleClick

        ' On doubleclique dans la barre de status pour afficher la gestion du réveil du PC
        Pref.TabControl.SelectedTab = Pref.TabControl.TabPages.Item(5)
        Pref.ShowDialog()
    End Sub

    Private Sub ToolStripStatusLabelAudioClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabelAudio.DoubleClick

        ' On doubleclique dans la barre de status pour afficher la gestion du son
        Pref.TabControl.SelectedTab = Pref.TabControl.TabPages.Item(6)
        Pref.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItemSettingsResetClick(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItemSettingsReset.Click
        Trace.WriteLine(DateTime.Now.ToString & " On va faire un reset des data dans les préférences")

        ' Remise à zero de tous les paramètres
        Dim boxRaz As DialogResult
        boxRaz = _
            MessageBox.Show(MessageBoxRaz & Chr(13) & Chr(13) & MessageBoxRaz1, _
                             MessageBoxTitleRaz, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
                             MessageBoxDefaultButton.Button1)

        'Si on a cliqué sur oui on redémarre zg
        If boxRaz = DialogResult.Yes Then

            Try

                ' On efface la bdd ainsi que les autres fichiers
                If My.Computer.FileSystem.FileExists(BDDPath & "db_progs.db3") Then
                    File.Delete(BDDPath & "db_progs.db3")
                End If
                If My.Computer.FileSystem.FileExists(ChannelSetPath & "ZGuideTVDotNet.channels.set") Then
                    File.Delete(ChannelSetPath & "ZGuideTVDotNet.channels.set")
                End If

                ' On efface tout les user.config
                ' 30/10/2009
                'If My.Computer.FileSystem.DirectoryExists(Local & "\ZGuideTV_Team") Then
                'Directory.Delete(Local & "\ZGuideTV_Team", True)
                'End If

                ' On redémarre ZGuideTV.NET
                Trace.WriteLine( _
                                 DateTime.Now.ToString & _
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

    Private Sub TestToolStripMenuHelpHelpShortcutsClick(sender As Object, e As EventArgs) Handles ToolStripMenuHelpHelpShortcuts.Click

        ToolStripHelpShortcuts.PerformClick()
    End Sub

    Private Sub ToolStripHelpShortcutsClick(sender As Object, e As EventArgs) Handles ToolStripHelpShortcuts.Click

        Try

            ' Modifié par Néo le 13/02/2011
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://zguidetv.codeplex.com") Then

                If My.Settings.Language = "Français" Then

                    Process.Start("http://zguidetv.codeplex.com/wikipage?title=Raccourcis%20clavier%20de%20r%u00e9f%u00e9rences")
                Else
                    Process.Start("http://zguidetv.codeplex.com/wikipage?title=Keyboard%20Shortcuts%20Reference")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class