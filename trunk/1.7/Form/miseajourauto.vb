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
Imports System.IO.Compression
Imports System.Text
Imports Microsoft.WindowsAPICodePack.Taskbar

' ReSharper disable CheckNamespace
Public Class MiseAJourAuto
    ' ReSharper restore CheckNamespace

    Public NodeNumber As String = "Nombre de Noeuds :"
    Public AutoUpdateOperation As String = "Opération en cours :"
    Public DwnlOperation As String = "Téléchargement"
    Public ParsingOperation As String = "Analyse syntaxique du fichier XML"
    Public RemainingTime As String = "Temps restant estimé :"
    Public FileSize As String = "Taille du fichier :"

    ' Public Error1Majauto As String = "URL Invalide"
    Public MessageBoxMajautoUrl As String
    Public MessageBoxMajautoUrlTitre As String

    ' Public Error2Majauto As String = "Fichier introuvable ou serveur inaccessible"
    Public MessageBoxMajautoserverError As String
    Public MessageBoxMajautoserverErrorTitre As String

    ' Public Error3Majauto As String = "Echec lors de la copie du fichier XML"
    Public MessageBoxMajautoxmlError As String
    Public MessageBoxMajautoxmlErrorTitre As String

    ' Public Error4Majauto As String = "Echec lors de la décompression du fichier :"
    Public MessageBoxMajautoextractionError As String
    Public MessageBoxMajautoextractionErrorTitre As String

    ' Public Error5Majauto As String = "Echec lors de la copie de fichier"
    Public MessageBoxMajautocopyError As String
    Public MessageBoxMajautocopyErrorTitre As String


    'Public Error6Majauto As String = "Nom du fichier incorrect :"
    Public MessageBoxMajautonameError As String
    Public MessageBoxMajautonameErrorTitre As String

    Private ReadOnly _os As OperatingSystem = Environment.OSVersion

    ' 09/03/2009 Griser et désactiver la croix rouge de la form
    Private Const CsNoclose As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CsNoclose
            Return cp
        End Get
    End Property

    Private Sub MiseAJourAutoLoad(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6) AndAlso
           TaskbarManager.IsPlatformSupported = False Then
            WindowState = FormWindowState.Normal
        End If

        Mainform.MajautoReussie = True

        ' les sources d'erreur détectées mettront ce flag à false
        Try
            LanguageCheck()
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " plantage lors de languagecheck de mise a jour auto")
            Mainform.MajautoReussie = False
        End Try

        ' lecture_des_chaines_memorisees(et)
        ' leurs caracteristiques (c5.telepoche.com| arte| arte.gif
        ' memorisées dans...channel.set
        ' stockage dans Tabligne
        Dim sr As New StreamReader(ChannelSetPath & "ZGuideTVDotNet.channels.set", Encoding.ASCII)
        Dim tabLigne() As String

        ' on déclare un tableau dans lesquel sont stockés tous les items
        Dim lvi As ListViewItem
        Dim ligne As String
        Dim count As Integer

        autoupdate_title.Text = AutoUpdateOperation & DwnlOperation
        MiseAJourAuto_Weight.Text = FileSize & "  "
        MiseajourAuto_estimated.Text = RemainingTime & "  "
        Refresh()

        Trace.WriteLine(DateTime.Now & "entrée dans mise à jour automatique")
        Trace.WriteLine(DateTime.Now & "contenu de channel.set mis dans tabligne")
        Trace.WriteLine(DateTime.Now & " ")

        Try

            ligne = sr.ReadLine()
            Do

                ' (lecture du fichier ligne par ligne)
                lvi = New ListViewItem
                tabLigne = ligne.Split(CChar("|"))

                ' On découpe la ligne du fichier et la met dans le tableau
                lvi.Text = tabLigne(0) & " " & tabLigne(1) & " " & tabLigne(2)

                ' 1 ligne type comprend: c5.telepoche.com| arte| arte.gig
                Trace.WriteLine(lvi.Text)
                ligne = sr.ReadLine()
                count = count + 1
            Loop Until ligne Is Nothing
            sr.Close()
            sr.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Trace.WriteLine(
                DateTime.Now &
                " Erreur lors de la lecture du ZGuideTVDotNet.channels.set dans miseajourauto ")
            Mainform.MajautoReussie = False
        End Try

        'Dim choixdownload As Boolean = My.Settings.URLChecked

        Dim serveurUrl As String = My.Settings.Lienmiseajour
        Dim extention As String = ""
        Dim fileName As String = ""
        Dim filename2 As String = ""
        Dim xmlaTélécharger As String

        'Dim YesNo As Boolean = True
        Dim bError As Boolean = False

        ' en maj automatique on est d'office en téléchargement ...
        autoupdate_title.Text = AutoUpdateOperation & DwnlOperation
        Trace.WriteLine(DateTime.Now & " repere A")
        xmlaTélécharger = serveurUrl
        xmlaTélécharger = xmlaTélécharger.Trim(" "c)

        Try
            extention = xmlaTélécharger.Substring(xmlaTélécharger.LastIndexOf(Chr(46)) + 1)
            fileName = xmlaTélécharger.Substring(xmlaTélécharger.LastIndexOf(Chr(47)) + 1)
            filename2 = fileName.Remove(fileName.IndexOf(Chr(46)))
            extention = extention.ToUpper
        Catch ex As Exception

            ' Si il y a une erreur alors c'est que l'URL est invalide
            bError = True
            ' ReSharper disable NotAccessedVariable
            Dim boxMajautoUrl As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxMajautoUrl = MessageBox.Show _
                                (MessageBoxMajautoUrl,
                                 MessageBoxMajautoUrlTitre, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1)


            Mainform.MajautoReussie = False
        End Try

        If Not bError Then

            ' on télécharge le fichier dans le appdata
            autoupdate_title.Text = AutoUpdateOperation & DwnlOperation
            MiseAJourAuto_Weight.Text = FileSize & "  "
            MiseajourAuto_estimated.Text = RemainingTime & "  "


            If DownloadFile(xmlaTélécharger, AppData & fileName, 100000) Then

                ' le fichier a bien ete telechargé
                Application.DoEvents()
                Trace.WriteLine(
                    DateTime.Now & " le fichier " & xmlaTélécharger & " a ete telecharge vers " & AppData &
                    " " & fileName)
                XmlTvName = AppData & fileName
                Trace.WriteLine(DateTime.Now & " XmlTvName = " & XmlTvName)

            Else

                ' le fichier n a pas ete correctement telechargé
                ' LectureDesChainesMemorisees()
                ' ReSharper disable NotAccessedVariable
                Dim boxMajautoserverError As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxMajautoserverError = MessageBox.Show _
                                (MessageBoxMajautoserverError,
                                 MessageBoxMajautoserverErrorTitre, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1)

                bError = True
                Mainform.MajautoReussie = False
            End If
        End If

        ' on a a ce stade un fichier telechargé de contenu de type xml
        Trace.WriteLine(DateTime.Now & " repere D")
        FichierProgramme = AppData & filename2 & ".xml"
        Trace.WriteLine(DateTime.Now & " fichier programme = " & FichierProgramme)
        If Not bError Then
            Try

                If XmlTvName.Length > 0 Then

                    ' si fichier non compressé on le copie dans le appdata et on le renomme prog.xml
                    Select Case extention
                        Case "XML" ' l'autre cas etant "Zip"
                            If Miseajour.CopierFichier(XmlTvName, FichierProgramme, True) Then

                                ' la copie a ete faite
                                Miseajour.ParseXmlChannels(FichierProgramme)

                                ' copie non faite
                            Else

                                ' ReSharper disable NotAccessedVariable
                                Dim boxMajautoxmlError As DialogResult
                                ' ReSharper restore NotAccessedVariable
                                boxMajautoxmlError = MessageBox.Show _
                                (MessageBoxMajautoxmlError,
                                 MessageBoxMajautoxmlErrorTitre, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1)

                                Mainform.MajautoReussie = False
                            End If
                        Case Else

                            ' le fichier est compressé
                            If Miseajour.CopierFichier(XmlTvName, AppData & fileName, True) Then
                                Try

                                    ' on recherche les noms cours des emplacements de fichier
                                    Dim nomFichier As String
                                    Dim nomAppData As String
                                    Trace.WriteLine(DateTime.Now & " repere F")
                                    nomFichier = AppData & fileName
                                    nomAppData = AppData

                                    ' Rajout de Ronaldo1 03/11/2007
                                    Dim xmlPurge() As String
                                    xmlPurge = Directory.GetFiles(AppData, "*.XML")
                                    Trace.WriteLine(DateTime.Now & " xmlpurge.length =" & xmlPurge.Length)

                                    ' on décompresse le fichier zip. Modifié par Néo le 08/07/2014
                                    ZipFile.ExtractToDirectory(nomFichier, nomAppData)

                                    Dim xmlFile() As String = Directory.GetFiles(AppData, "*.xml")
                                    If xmlFile.Length > 0 Then
                                        XmlTvName = xmlFile(0)
                                        FichierProgramme = XmlTvName
                                        Miseajour.ParseXmlChannels(XmlTvName)
                                    Else
                                        Trace.WriteLine(DateTime.Now & " repere 4")

                                        ' ReSharper disable NotAccessedVariable
                                        Dim boxMajautocopyError As DialogResult
                                        ' ReSharper restore NotAccessedVariable
                                        boxMajautocopyError = MessageBox.Show _
                                (MessageBoxMajautocopyError,
                                 MessageBoxMajautocopyErrorTitre, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1)

                                        Mainform.MajautoReussie = False
                                    End If

                                Catch ex As Exception

                                    ' ReSharper disable NotAccessedVariable
                                    Dim boxMajautoextractionError As DialogResult
                                    ' ReSharper restore NotAccessedVariable
                                    boxMajautoextractionError = MessageBox.Show _
                                (MessageBoxMajautoextractionError,
                                 MessageBoxMajautoextractionErrorTitre, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1)

                                    Mainform.MajautoReussie = False
                                End Try
                            Else

                                ' ReSharper disable NotAccessedVariable
                                Dim boxMajautocopyError As DialogResult
                                ' ReSharper restore NotAccessedVariable
                                boxMajautocopyError = MessageBox.Show _
                                (MessageBoxMajautocopyError,
                                 MessageBoxMajautocopyErrorTitre, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1)

                                Mainform.MajautoReussie = False

                            End If
                    End Select
                End If

            Catch ex As Exception

                ' ReSharper disable NotAccessedVariable
                Dim boxMajautonameError As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxMajautonameError = MessageBox.Show _
                                (MessageBoxMajautonameError,
                                 MessageBoxMajautonameErrorTitre, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1)

                Mainform.MajautoReussie = False
            End Try

        End If
        If Mainform.MajautoReussie Then
            EcritureChannelsSet()

            ' meme si erreur ?250609
            ' double emploi?
        End If

        Hide()
    End Sub
End Class