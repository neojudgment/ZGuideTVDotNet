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
Imports System.Text
Imports Microsoft.WindowsAPICodePack.Taskbar

Public Class MiseAJourAuto
    Public Node_number As String = "Nombre de Noeuds :"
    Public Auto_update_operation As String = "Opération en cours :"
    Public dwnl_operation As String = "Téléchargement"
    Public Parsing_operation As String = "Analyse syntaxique du fichier XML"
    Public remaining_time As String = "Temps restant estimé :"
    Public file_size As String = "Taille du fichier :"
    Public Error1_majauto As String = "URL Invalide"
    Public Error2_majauto As String = "Fichier introuvable ou serveur inaccessible"
    Public Error3_majauto As String = "Echec lors de la copie du fichier XML"
    Public Error4_majauto As String = "Echec lors de la décompression du fichier :"
    Public Error5_majauto As String = "Echec lors de la copie de fichier"
    Public Error6_majauto As String = "Nom du fichier incorrect :"

    Private os As OperatingSystem = Environment.OSVersion

    ' 09/03/2009 Griser et désactiver la croix rouge de la form
    Private Const CS_NOCLOSE As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub MiseAJourAuto_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        If Not ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
        TaskbarManager.IsPlatformSupported = False Then
            Me.WindowState = FormWindowState.Normal
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
        Dim TabLigne() As String

        ' on déclare un tableau dans lesquel sont stockés tous les items
        Dim LVI As New ListViewItem
        Dim Ligne As String
        Dim count As Integer

        autoupdate_title.Text = Auto_update_operation & dwnl_operation
        MiseAJourAuto_Weight.Text = file_size & "  "
        MiseajourAuto_estimated.Text = remaining_time & "  "
        Me.Refresh()

        Trace.WriteLine(DateTime.Now & "entrée dans mise à jour automatique")
        Trace.WriteLine(DateTime.Now & "contenu de channel.set mis dans tabligne")
        Trace.WriteLine(DateTime.Now & " ")

        Try
            Ligne = ""
            Ligne = sr.ReadLine()
            Do

                ' (lecture du fichier ligne par ligne)
                LVI = New ListViewItem
                TabLigne = Ligne.Split(CChar("|"))

                ' On découpe la ligne du fichier et la met dans le tableau
                LVI.Text = TabLigne(0) & " " & TabLigne(1) & " " & TabLigne(2)

                ' 1 ligne type comprend: c5.telepoche.com| arte| arte.gig
                TabLigne = Nothing
                Trace.WriteLine(LVI.Text)
                Ligne = sr.ReadLine()
                count = count + 1
            Loop Until Ligne Is Nothing
            sr.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Trace.WriteLine( _
                             DateTime.Now & _
                             " Erreur lors de la lecture du ZGuideTVDotNet.channels.set dans miseajourauto ")
            Mainform.MajautoReussie = False
        End Try

        Dim choixdownload As Boolean = My.Settings.URLChecked

        Dim ServeurUrl As String = My.Settings.Lienmiseajour

        Dim Extention As String = ""
        Dim FileName As String = ""
        Dim Filename2 As String = ""
        Dim XMLATélécharger As String = ""

        Dim YesNo As Boolean = True
        Dim bError As Boolean = False

        ' en maj automatique on est d'office en téléchargement ...
        Me.autoupdate_title.Text = Auto_update_operation & dwnl_operation
        Trace.WriteLine(DateTime.Now & " repere A")
        XMLATélécharger = ServeurUrl
        XMLATélécharger = XMLATélécharger.Trim(" "c)

        Try
            Extention = XMLATélécharger.Substring(XMLATélécharger.LastIndexOf(Chr(46)) + 1)
            FileName = XMLATélécharger.Substring(XMLATélécharger.LastIndexOf(Chr(47)) + 1)
            Filename2 = FileName.Remove(FileName.IndexOf(Chr(46)))
            Extention = Extention.ToUpper
        Catch ex As Exception

            ' Si il y a une erreur alors c'est que l'URL est invalide
            bError = True
            Dim FenMessage As Message = New Message(Error1_majauto, MsgBoxStyle.Critical, True)
            FenMessage.ShowDialog()
            Mainform.MajautoReussie = False
        End Try

        If Not bError Then

            ' on télécharge le fichier dans le appdata
            autoupdate_title.Text = Auto_update_operation & dwnl_operation
            MiseAJourAuto_Weight.Text = file_size & "  "
            MiseajourAuto_estimated.Text = remaining_time & "  "


            If DownloadFile(XMLATélécharger, AppData & FileName, 100000) Then

                ' le fichier a bien ete telechargé
                Application.DoEvents()
                Trace.WriteLine( _
                                 DateTime.Now & " le fichier " & XMLATélécharger & " a ete telecharge vers " & AppData & _
                                 " " & FileName)
                XmlTvName = AppData & FileName
                Trace.WriteLine(DateTime.Now & " XmlTvName = " & XmlTvName)

            Else

                ' le fichier n a pas ete correctement telechargé
                lecture_des_chaines_memorisees()
                Dim FenMessage As Message = New Message(Error2_majauto, MsgBoxStyle.Critical, True)
                FenMessage.ShowDialog()
                bError = True
                Mainform.MajautoReussie = False
            End If
        End If

        ' on a a ce stade un fichier telechargé de contenu de type xml
        Trace.WriteLine(DateTime.Now & " repere D")
        FichierProgramme = AppData & Filename2 & ".xml"
        Trace.WriteLine(DateTime.Now & " fichier programme = " & FichierProgramme)
        If Not bError Then
            Try

                If XmlTvName.Length > 0 Then

                    ' si fichier non compressé on le copie dans le appdata et on le renomme prog.xml
                    Select Case Extention
                        Case "XML" ' lautre cas etant "Zip"
                            If Miseajour.CopierFichier(XmlTvName, FichierProgramme, True) Then

                                ' la copie a ete faite
                                Miseajour.ParseXmlChannels(FichierProgramme)

                                ' copie non faite
                            Else
                                Dim _
                                    FenMessage As Message = _
                                        New Message(Error3_majauto, _
                                                        MsgBoxStyle.Critical, True)
                                FenMessage.ShowDialog()
                                Mainform.MajautoReussie = False
                            End If
                        Case Else

                            ' le fichier est compressé
                            If Miseajour.CopierFichier(XmlTvName, AppData & FileName, True) Then
                                Try

                                    ' on recherche les noms cours des emplacements de fichier
                                    Dim nomFichier As String
                                    Dim nomAPPData As String
                                    Trace.WriteLine(DateTime.Now & " repere F")
                                    nomFichier = AppData & FileName
                                    nomAPPData = AppData

                                    ' Rajout de Ronaldo1 03/11/2007
                                    Dim XMLPurge() As String
                                    XMLPurge = Directory.GetFiles(AppData, "*.XML")
                                    Trace.WriteLine(DateTime.Now & " xmlpurge.length =" & XMLPurge.Length)
                                    Dim i As Integer = 0

                                    ' on décompresse le fichier avec 7-zip
                                    Dim p As New Process
                                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                                    p.StartInfo.CreateNoWindow = False
                                    p.StartInfo.UseShellExecute = True
                                    p.StartInfo.FileName = UnZipPath
                                    p.StartInfo.Arguments = "e " & """" & nomFichier & """" & " -y -o" & """" & _
                                                            nomAPPData & """"
                                    p.Start()
                                    p.WaitForExit(10000)

                                    Dim XMLFile() As String = Directory.GetFiles(AppData, "*.xml")
                                    If XMLFile.Length > 0 Then
                                        XmlTvName = XMLFile(0)
                                        FichierProgramme = XmlTvName
                                        Miseajour.ParseXmlChannels(XmlTvName)
                                    Else
                                        Trace.WriteLine(DateTime.Now & " repere 4")
                                        Dim _
                                            FenMessage As Message = _
                                                New Message(Error5_majauto & _
                                                                AppData & FileName, MsgBoxStyle.Critical, True)
                                        FenMessage.ShowDialog()
                                        Mainform.MajautoReussie = False
                                    End If

                                Catch ex As Exception
                                    Dim _
                                        FenMessage As Message = _
                                            New Message(Error4_majauto, _
                                                            MsgBoxStyle.Critical, True)
                                    FenMessage.ShowDialog()
                                    Mainform.MajautoReussie = False
                                End Try
                            Else
                                Dim _
                                    FenMessage As Message = _
                                        New Message(Error5_majauto & _
                                                        XmlTvName, MsgBoxStyle.Critical, True)
                                FenMessage.ShowDialog()
                                Mainform.MajautoReussie = False

                            End If
                    End Select
                End If

            Catch ex As Exception
                Dim _
                    FenMessage As Message = _
                        New Message(Error6_majauto & XmlTvName, _
                                        MsgBoxStyle.Critical, True)
                FenMessage.ShowDialog()
                Mainform.MajautoReussie = False
            End Try

        End If
        If Mainform.MajautoReussie Then
            ecriture_channels_set()

            ' meme si erreur ?250609
            ' double emploi?
        End If

        Me.Hide()

    End Sub

    Private Sub MiseAJourAuto_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
        Handles MyBase.FormClosing
        Dim i As Integer
        i = 0
    End Sub
End Class