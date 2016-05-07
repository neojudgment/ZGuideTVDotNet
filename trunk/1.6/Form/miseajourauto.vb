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
Imports System.IO
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
    Public Error1Majauto As String = "URL Invalide"
    Public Error2Majauto As String = "Fichier introuvable ou serveur inaccessible"
    Public Error3Majauto As String = "Echec lors de la copie du fichier XML"
    Public Error4Majauto As String = "Echec lors de la décompression du fichier :"
    Public Error5Majauto As String = "Echec lors de la copie de fichier"
    Public Error6Majauto As String = "Nom du fichier incorrect :"

    Private ReadOnly _os As OperatingSystem = Environment.OSVersion

    ' 09/03/2009 Griser et désactiver la croix rouge de la form
    Private Const CsNoclose As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CsNoclose
            Return cp
        End Get
    End Property

    Private Sub MiseAJourAutoLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        If Not ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6) AndAlso _
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

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Trace.WriteLine( _
                             DateTime.Now & _
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
            Dim fenMessage As Message = New Message(Error1Majauto, MsgBoxStyle.Critical, True)
            fenMessage.ShowDialog()
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
                Trace.WriteLine( _
                                 DateTime.Now & " le fichier " & xmlaTélécharger & " a ete telecharge vers " & AppData & _
                                 " " & fileName)
                XmlTvName = AppData & fileName
                Trace.WriteLine(DateTime.Now & " XmlTvName = " & XmlTvName)

            Else

                ' le fichier n a pas ete correctement telechargé
                ' LectureDesChainesMemorisees()
                Dim fenMessage As Message = New Message(Error2Majauto, MsgBoxStyle.Critical, True)
                fenMessage.ShowDialog()
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
                                Dim _
                                    fenMessage As Message = _
                                        New Message(Error3Majauto, _
                                                        MsgBoxStyle.Critical, True)
                                fenMessage.ShowDialog()
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
                                    'Dim i As Integer = 0

                                    ' on décompresse le fichier avec 7-zip
                                    Dim p As New Process
                                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                                    p.StartInfo.CreateNoWindow = False
                                    p.StartInfo.UseShellExecute = True
                                    p.StartInfo.FileName = UnZipPath
                                    p.StartInfo.Arguments = "e " & """" & nomFichier & """" & " -y -o" & """" & _
                                                            nomAppData & """"
                                    p.Start()
                                    p.WaitForExit(10000)

                                    Dim xmlFile() As String = Directory.GetFiles(AppData, "*.xml")
                                    If xmlFile.Length > 0 Then
                                        XmlTvName = xmlFile(0)
                                        FichierProgramme = XmlTvName
                                        Miseajour.ParseXmlChannels(XmlTvName)
                                    Else
                                        Trace.WriteLine(DateTime.Now & " repere 4")
                                        Dim _
                                            fenMessage As Message = _
                                                New Message(Error5Majauto & _
                                                                AppData & fileName, MsgBoxStyle.Critical, True)
                                        fenMessage.ShowDialog()
                                        Mainform.MajautoReussie = False
                                    End If

                                Catch ex As Exception
                                    Dim _
                                        fenMessage As Message = _
                                            New Message(Error4Majauto, _
                                                            MsgBoxStyle.Critical, True)
                                    fenMessage.ShowDialog()
                                    Mainform.MajautoReussie = False
                                End Try
                            Else
                                Dim _
                                    fenMessage As Message = _
                                        New Message(Error5Majauto & _
                                                        XmlTvName, MsgBoxStyle.Critical, True)
                                fenMessage.ShowDialog()
                                Mainform.MajautoReussie = False

                            End If
                    End Select
                End If

            Catch ex As Exception
                Dim _
                    fenMessage As Message = _
                        New Message(Error6Majauto & XmlTvName, _
                                        MsgBoxStyle.Critical, True)
                fenMessage.ShowDialog()
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