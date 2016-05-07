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
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Net
Imports System.Threading
Imports System.Xml

Friend Module utilitairesmiseajour
    Public MessageFichierCorrompu As String = "Le fichier XMLTV n'est pas conforme aux spécifications DTD !"
    Public MessageFichierCorrompu1 As String = "Voulez-vous essayer de récupérer votre ancienne base de donnée"
    Public MessageFichierCorrompu2 As String = "ou sélectionner un autre fichier de mise à jour ?"
    Public MessageFichierCorrompuTitre As String = "ZGuideTV.NET - Fichier non conforme"

    Private os As OperatingSystem = Environment.OSVersion

    Public Sub ecriture_channels_set()
        Dim SW As New StreamWriter(ChannelSetPath & "\" & "ZGuideTVDotNet.channels.set")
        Dim nombredechaineselectionnees As Integer

        ' 'On déclare les variables
        Dim Save_Listview As String = ""
        Dim itm As New ListViewItem
        Try
            For Each itm In Miseajour.ListXMLTVFRChoisie.Items ' Boucle sur le nombre d'items dans la ListView
                If Miseajour.collectionChannels.Contains(itm.Text) Then
                    arrayOnechannel = DirectCast(Miseajour.collectionChannels.Item(itm.Text), String())
                    Save_Listview = Save_Listview & _
                                    (arrayOnechannel(0) & ("|") & arrayOnechannel(1) & ("|") & arrayOnechannel(2) & _
                                     ("|"))
                    SW.WriteLine(Save_Listview)
                    ' Ecrit dans le fichier le contenu de la variable Save_Listview

                    Save_Listview = ""
                    ' Remplacement du contenu de Save_Listview par une chaîne vide

                End If

                ' Néo 03/08/2009
                ' On compte le nombre de chaines sauvegardées durant une mise à jour manuelle
                nombredechaineselectionnees = nombredechaineselectionnees + 1

            Next itm

            ' Néo 03/08/2009
            ' On va écrire le nombre de chaines sauvegardée durant
            ' une mise à jour manuelle dans My.Settings.nbchainesdiff
            My.Settings.nbchainesdiff = nombredechaineselectionnees
            My.Settings.Save()
            Application.DoEvents()

            ' Fermeture du fichier
            SW.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Trace.WriteLine( _
                             DateTime.Now & _
                             " Erreur lors de l'écriture du ZGuideTVDotNet.channels.set dans frmmiseajour")
        End Try
    End Sub

    Public Sub initier_channels_set()
        Dim SW As New StreamWriter(ChannelSetPath & "ZGuideTVDotNet.channels.set")
        Dim ligne As String
        Dim z1 As String
        Dim z2 As String
        Dim z3 As String
        Dim i As Integer

        Try
            For i = 1 To nb_total_chaines
                ligne = ""
                z1 = tableau_chaine(i).identificateur
                z2 = tableau_chaine(i).nom
                z3 = tableau_chaine(i).logo
                ligne = z1 & "|" & z2 & "|" & z3 & "|"
                If (Not z1 Is Nothing AndAlso String.IsNullOrEmpty(z1)) OrElse (Not z2 Is Nothing AndAlso String.IsNullOrEmpty(z2)) OrElse (Not z3 Is Nothing AndAlso String.IsNullOrEmpty(z3)) Then
                    Exit For
                End If
                SW.WriteLine(ligne)
            Next i

            SW.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Trace.WriteLine( _
                             DateTime.Now & _
                             " Erreur lors de l'initialisation du ZGuideTVDotNet.channels.set dans frmmiseajour")
        End Try
    End Sub

    Public Function DownloadFile(ByVal RemoteFilePath As String, ByVal SaveFilePath As String, ByVal TimeOut As Integer, _
                                  Optional ByVal BlockSize As Integer = 1024, Optional ByVal bMessage As Boolean = True) _
        As Boolean

        Select Case maj_auto_flag
            Case False
                Miseajour.ProgressBarMiseaJ.Style = ProgressBarStyle.Continuous

                ' Pour Windows 7 Seulement : Style de la progressbar 
                ' durant le Download en mise à jour manuelle
                If _
                    ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                    My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                    Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                    ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                End If

            Case True
                MiseAJourAuto.ProgressBar1.Style = ProgressBarStyle.Continuous

                ' Pour Windows 7 Seulement : Style de la progressbar
                ' durant le Download en mise à jour auto
                If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                TaskbarManager.IsPlatformSupported Then
                    Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                    ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                End If
        End Select

        Dim proxy As String = ""
        Dim wr As HttpWebRequest
        Dim proxyport As Integer
        Dim login As String = ""
        Dim pass As String = ""

        Try

            proxy = My.Settings.Proxy
            proxyport = CInt(My.Settings.ProxyPort)
            login = My.Settings.loginproxy
            pass = My.Settings.passproxy

            If Not (Not proxy Is Nothing AndAlso String.IsNullOrEmpty(proxy)) Then
                Dim hproxy As WebProxy
                hproxy = New WebProxy(proxy, proxyport)
                WebRequest.DefaultWebProxy = hproxy
            End If

            Select Case maj_auto_flag ' mise à jour automatique ou pas ?
                Case False
                    Miseajour.ProgressBarMiseaJ.Style = ProgressBarStyle.Continuous
                    Miseajour.ProgressBarMiseaJ.Step = BlockSize

                    ' Pour Windows 7 Seulement : Style de la progressbar
                    ' durant le Download en mise à jour manuelle
                    If _
                        ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                        My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                        Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                        ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                    End If
                Case True
                    With MiseAJourAuto
                        .ProgressBar1.Style = ProgressBarStyle.Continuous
                        .ProgressBar1.Step = BlockSize

                        .autoupdate_title.Text = .Auto_update_operation & " " & _
                                                              .dwnl_operation
                        .MiseAJourAuto_Weight.Text = .file_size
                        .MiseajourAuto_estimated.Text = .remaining_time

                        .BringToFront()
                        .ProgressBar1.Refresh()
                        .Refresh()
                        .Visible = True
                    End With

                    ' Pour Windows 7 Seulement : Style de la progressbar
                    ' durant le Download en mise à jour auto
                    If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                    TaskbarManager.IsPlatformSupported Then
                        Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                        ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                    End If
            End Select

            wr = DirectCast(HttpWebRequest.Create(RemoteFilePath), HttpWebRequest)

            With wr
                .Timeout = TimeOut
                .UserAgent = "ZGuideTV " & My.Application.Info.Version().ToString
                .AllowAutoRedirect = True
            End With

            If Not (Not login Is Nothing AndAlso String.IsNullOrEmpty(login)) Then
                Dim hcredential As New NetworkCredential(login, pass)
                wr.Credentials = hcredential
            End If
            Try
                Dim wresp As WebResponse = wr.GetResponse()
                Dim RemoteStream As Stream = wresp.GetResponseStream()

                ' calcul de Poid: la taille du fichier à telecharger
                Dim Poid As Integer = CInt(wresp.ContentLength)
                Trace.WriteLine(DateTime.Now & " taille du fichier à telecharger (kbyte) : " & (Poid / 1000).ToString)

                Select Case maj_auto_flag ' mise a jour automatique?
                    Case False
                        Miseajour.ProgressBarMiseaJ.Maximum = Poid

                    Case True
                        MiseAJourAuto.ProgressBar1.Maximum = Poid
                        MiseAJourAuto.MiseAJourAuto_Weight.Text = MiseAJourAuto.file_size & " " & CInt(Poid / 1024) & _
                                                                  " Ko"
                        MiseAJourAuto.ProgressBar1.Refresh()
                End Select

                Dim _
                    LocalStream As _
                        New FileStream(SaveFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read)
                Dim LocalStreamW As New BinaryWriter(LocalStream)

                Dim buff(BlockSize - 1) As Byte
                Dim iBytesRead As Integer = 1
                Dim compteur_block As Integer = 1
                Dim start_time As Long
                start_time = DateTime.Now.Ticks

                Do While (iBytesRead > 0)
                    Select Case maj_auto_flag
                        Case False
                            Miseajour.ProgressBarMiseaJ.Increment(BlockSize)

                            ' Pour Windows 7 Seulement : Mise à jour de la taskbar 
                            ' durant le Download en mise à jour manuelle
                            If _
                                ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                                My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                                Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                                ZGuideTVTaskbar.SetProgressValue(Miseajour.ProgressBarMiseaJ.Value, Poid)
                            End If

                        Case True
                            MiseAJourAuto.ProgressBar1.Increment(BlockSize)

                            ' Pour Windows 7 Seulement : Mise à jour de la taskbar
                            ' durant le Download en mise à jour automatique
                            If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                            TaskbarManager.IsPlatformSupported Then
                                Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                                ZGuideTVTaskbar.SetProgressValue(MiseAJourAuto.ProgressBar1.Value, Poid)
                            End If

                            If modulo(compteur_block, 25) = 1 Then
                                Dim actual_time As Long
                                Dim diff_temps As Long
                                actual_time = DateTime.Now.Ticks
                                Dim diff_size As Long
                                Dim vitesse As Double
                                Dim temps_estime As Double

                                diff_temps = actual_time - start_time
                                diff_size = compteur_block * BlockSize
                                '07/02/2009
                                vitesse = 1024 * (1000 * diff_size / (diff_temps * 1))
                                ' en kbyte/sec
                                Trace.WriteLine(DateTime.Now & " compteur = " & compteur_block.ToString)
                                Trace.WriteLine( _
                                                 DateTime.Now & " vitesse = " & vitesse.ToString & " actual-time= " & _
                                                 actual_time.ToString & "start time = " & start_time.ToString)
                                Trace.WriteLine(DateTime.Now & " diff_temps = " & diff_temps.ToString)

                                temps_estime = (Poid - compteur_block * BlockSize) / vitesse
                                temps_estime = Math.Max(temps_estime, 0)
                                Trace.WriteLine(DateTime.Now & " temps estimé = " & temps_estime.ToString)
                                '07/02/2009
                                MiseAJourAuto.MiseajourAuto_estimated.Text = MiseAJourAuto.remaining_time & " " & _
                                                                             (CInt(temps_estime)).ToString & " sec"
                                Trace.WriteLine(" ")
                                Thread.Sleep(50)
                                MiseAJourAuto.Refresh()

                            Else
                            End If
                    End Select

                    iBytesRead = RemoteStream.Read(buff, 0, buff.Length)
                    LocalStreamW.Write(buff, 0, iBytesRead)
                    compteur_block += 1
                Loop

                Select Case maj_auto_flag
                    Case False
                        Miseajour.ProgressBarMiseaJ.Maximum = 0

                        ' Pour Windows 7 Seulement : Mise à zéro taskbar
                        ' durant le Download en mise à jour manuelle
                        If _
                            ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                            My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                            Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                            ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
                        End If

                    Case True
                        MiseAJourAuto.ProgressBar1.Maximum = 0

                        ' Pour Windows 7 Seulement : Mise à zéro taskbar
                        ' durant le Download en mise à jour auto
                        If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                        TaskbarManager.IsPlatformSupported Then
                            Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                            ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
                        End If
                End Select

                wresp.Close()
                RemoteStream.Close()
                RemoteStream.Dispose()
                LocalStreamW.Close()
                LocalStream.Close()
                LocalStream.Dispose()

            Catch ex As Exception
                Select Case maj_auto_flag
                    Case False
                        Miseajour.ProgressBarMiseaJ.Style = ProgressBarStyle.Continuous
                        Miseajour.ProgressBarMiseaJ.Maximum = 0
                        Trace.WriteLine(DateTime.Now & "exception dans downloadfile en maj manuelle")
                        Trace.WriteLine(ex.Message)

                    Case True
                        MiseAJourAuto.ProgressBar1.Maximum = 0
                        MiseAJourAuto.ProgressBar1.Style = ProgressBarStyle.Continuous
                        Trace.WriteLine(DateTime.Now & "exception dans downloadfile en maj automatique")
                        Trace.WriteLine(ex.Message)
                End Select

                If bMessage Then

                    Dim FenMessage As New Message(ex.Message, MsgBoxStyle.Critical, True)
                    FenMessage.ShowDialog()
                End If
                Return False
            End Try
        Catch ex As Exception
            Dim FenMessage As New Message("Proxy error", "Erreur de gestion proxy", MsgBoxStyle.Critical, True)
            FenMessage.ShowDialog()
            Return False
        End Try

        Return True
    End Function

    Public Sub traitement_appliquer()

        ' rvs75 le 11/09/2009
        ' Pour forcer la mise à jour de ''ZGuideTVDotNet.channels.set'
        DeleteDB()
        CreateDBTables()
        'OpenConnection()
        If Miseajour.ListXMLTVFRChoisie.Items.Count > 0 Then
            ecriture_channels_set()
        End If
        If Miseajour.buttonToutClick = "True" Then
            MiseAjourDB("ChannelTbl", Miseajour.collectionSelectChannels)
        Else
#If DEBUG Then
            Trace.WriteLine(datetime.now & " Liste des chaînes choisies dans frmmiseajour")
#End If
            Dim itm As New ListViewItem
            Trace.WriteLine(DateTime.Now & " Liste des chaines mises a jour dans frmmiseajour : ")

            Miseajour.collectionSelectChannels.Clear()
            For Each itm In Miseajour.ListXMLTVFRChoisie.Items
                If Miseajour.collectionChannels.Contains(itm.Text) Then

                    arrayOnechannel = DirectCast(Miseajour.collectionChannels.Item(itm.Text), String())

#If DEBUG Then
                    Trace.WriteLine(datetime.now & arrayOnechannel(0) & " " & arrayOnechannel(1) & " " & arrayOnechannel(2))
#End If
                    Miseajour.collectionSelectChannels.Add(arrayOnechannel)
                End If
                Thread.Sleep(25)
            Next itm

            nombre_de_chaines_differentes = Miseajour.ListXMLTVFRChoisie.Items.Count
            '010809
            My.Settings.nbchainesdiff = nombre_de_chaines_differentes
            My.Settings.Save()

            ' les chaines choisies sont sauvegardées dans
            ' collectionSelectChannels
            ' (3 infos par chaine sauvees dans arrayonechannel(2))
            ' C5.telepoche.com, arte, arte.gif)

#If DEBUG Then
            Trace.WriteLine(datetime.now & " Nombre de chaînes mises a jour = " & (FrmMiseajour.collectionSelectChannels.Count).ToString)
#End If
            MiseAjourDB("ChannelTbl", Miseajour.collectionSelectChannels)
        End If

        If (XmlTvName.Length > 0) Then
            Mainform.Timer_minute.Stop()
            Mainform.TimerUsageMemory.Stop() 'BB 260710
            Parse_Xml_Programs(FichierProgramme)
            Mainform.Timer_minute.Start()
            Mainform.TimerUsageMemory.Stop() 'BB 260710
        Else
        End If
        Cursor.Current = Cursors.Default

        'On sauvergarde la date de la dernière mise à jour
        My.Settings.datemajmiseajour = (Date.Now).ToString

        Trace.WriteLine(DateTime.Now & " sortie de traitement_appliquer")

        Select Case maj_auto_flag
            Case False
                Miseajour.Hide()
                Miseajour.Close()
            Case True
                MiseAJourAuto.Hide()
                MiseAJourAuto.Close()
                Trace.WriteLine(" fermeture du formulaire mise a jour auto")
        End Select
    End Sub

    Public Sub Parse_Xml_Programs(ByVal PATH_XML As String)

        Try

            ' Y a t il des erreurs à signaler au programme appelant? 050409
            Dim XmlTvDoc As New XmlDocument()
            Dim elementProgram As XmlNodeList
            Dim noeud As XmlNode
            Dim noeudEnf_Program As XmlNode
            Dim noeudEnf_Credits As XmlNode
            Dim noeudEnf_Rating As XmlNode
            Dim noeudEnf_StarRating As XmlNode
            Dim noeudEnf_video As XmlNode
            Dim attribCount As Short = 0
            Dim pos As Integer
            Dim PCount As Int32 = 1
            Dim bperim As Boolean = My.Settings.bIntegrPerim

            ' ajouté le 01/03/2009
            Dim pTemp As String = ""

            'Memoire_Clean()

            Trace.WriteLine("extraction des données des emissions:entree dans parse xml program")
            XmlTvDoc.Load(PATH_XML)

            elementProgram = XmlTvDoc.DocumentElement.GetElementsByTagName("programme")

#If DEBUG Then
            Dim monstop As New Stopwatch
            monstop.Start()
            Dim duree As Long
#End If

            ' compte le nbre d'émission pour tous les channel selectionnés
            MiseAJourAuto.autoupdate_title.Text = MiseAJourAuto.Auto_update_operation & " " & _
                                                  MiseAJourAuto.Parsing_operation
            MiseAJourAuto.MiseAJourAuto_Weight.Text = MiseAJourAuto.Node_number & " "
            MiseAJourAuto.MiseajourAuto_estimated.Text = MiseAJourAuto.remaining_time & " "


            PCount = elementProgram.Count + 1
            'Trace.WriteLine(datetime.now & " Pcount = " & PCount.ToString & " (elementProgram.Count = " & elementProgram.Count & ")")

            Select Case maj_auto_flag
                Case False
                    Miseajour.ProgressBarMiseaJ.Maximum = PCount
                    Miseajour.ProgressBarMiseaJ.Step = 1

                Case True
                    Trace.WriteLine(DateTime.Now & " parse xml program progress bar1 max = " & PCount.ToString)
                    MiseAJourAuto.ProgressBar1.Maximum = PCount
                    MiseAJourAuto.ProgressBar1.Step = 1
                    MiseAJourAuto.MiseAJourAuto_Weight.Text = MiseAJourAuto.Node_number & " " & PCount.ToString
            End Select

            Dim start_time As New DateTime
            start_time = DateTime.Now

            Dim compteur As Integer = 1
            Dim temps_par_noeud As Double
            Dim temps_estime As Double

            MiseAjourDB("ProgramTbl", , "Begin")

            For Each noeud In elementProgram
                Try

                    pStart_A = "#01/01/0001 12:00:00 AM#"
                    pStop_A = "#01/01/0001 12:00:00 AM#"
                    pDiff = 0
                    pDuration = 0
                    PCountry = ""
                    pShowview_A = ""
                    pChannel_A = ""
                    pClumpidx_A = ""
                    pPdcStart_A = ""
                    pVpsStart_A = ""
                    pVideoplus_A = ""
                    pTitle = ""
                    pSubTitle = ""
                    pDescription = ""
                    pCredits = ""
                    pActor = ""
                    pDirector = ""
                    pWriter = ""
                    PPresent = ""
                    PRating = ""
                    pIconRating = ""
                    PStarRating = ""
                    pStarIconRating = " "
                    pPremiere = 0
                    pVideoAspect = ""
                    PVideoColor = True
                    PAudioStereo = ""
                    PSubType = 0
                    PLanguage = ""
                    pDate = ""
                    pCategory = ""
                    pCategoryTV = ""
                    PReview = ""
                    textAttrib = ""
                    Dim channelFound As Boolean = False

                    With noeud.Attributes
                        ' lit les attributs de programe
                        For attribCount = 0 To CShort(.Count - 1)
                            textAttrib = .ItemOf(attribCount).InnerText
                            Select Case .ItemOf(attribCount).Name
                                Case "start"

                                    pStart_A = textAttrib.Substring(0, 4) & "-" & textAttrib.Substring(4, 2) & "-" & _
                                               textAttrib.Substring(6, 2) & " " & textAttrib.Substring(8, 2) & ":" & _
                                               textAttrib.Substring(10, 2)
                                    'pStart_A = New DateTime(CType(textAttrib.Substring(0, 4), Integer), CType(textAttrib.Substring(4, 2), Integer), CType(textAttrib.Substring(6, 2), Integer), CType(textAttrib.Substring(8, 2), Integer), CType(textAttrib.Substring(10, 2), Integer), 0, DateTimeKind.Utc)
                                Case "stop"
                                    pStop_A = textAttrib.Substring(0, 4) & "-" & textAttrib.Substring(4, 2) & "-" & _
                                              textAttrib.Substring(6, 2) & " " & textAttrib.Substring(8, 2) & ":" & _
                                              textAttrib.Substring(10, 2)
                                Case "showview"
                                    pShowview_A = .ItemOf(attribCount).InnerText
                                Case "channel"
                                    pChannel_A = .ItemOf(attribCount).InnerText
                                    Dim item As String()
                                    For Each item In Miseajour.collectionSelectChannels
                                        If item(0) = pChannel_A Then
                                            channelFound = True
                                            PIndex += 1
                                            Exit For
                                        End If
                                    Next item
                                Case "clumpidx"
                                    pClumpidx_A = .ItemOf(attribCount).InnerText
                                Case "pdc-start"
                                    pPdcStart_A = .ItemOf(attribCount).InnerText
                                Case "vps-start"
                                    pVpsStart_A = .ItemOf(attribCount).InnerText
                                Case "videoplus"
                                    pVideoplus_A = .ItemOf(attribCount).InnerText
                            End Select
                        Next attribCount
                    End With

                    Dim DateFin As Date = Date.Now.AddHours(-6)
                    If channelFound AndAlso (Date.Compare(CDate(pStop_A), DateFin) > 0 OrElse bperim) Then

                        ' lit les noeuds enfant de programme
                        For Each noeudEnf_Program In noeud
                            Select Case noeudEnf_Program.Name
                                Case "title"
                                    pTitle = noeudEnf_Program.InnerText

                                    ' lit les attributs de title
                                    For attribCount = 0 To CShort(noeudEnf_Program.Attributes.Count - 1)
                                        textAttrib = noeudEnf_Program.Attributes.ItemOf(attribCount).InnerText

                                        Select Case noeudEnf_Program.Attributes.ItemOf(attribCount).Name
                                            Case "title lang"
                                        End Select
                                    Next attribCount

                                Case "sub-title"
                                    pSubTitle = noeudEnf_Program.InnerText

                                    ' lit les attributs de sub-title
                                    For attribCount = 0 To CShort(noeudEnf_Program.Attributes.Count - 1)
                                        textAttrib = noeudEnf_Program.Attributes.ItemOf(attribCount).InnerText
                                        Select Case noeudEnf_Program.Attributes.ItemOf(attribCount).Name
                                            Case "title lang"
                                        End Select
                                    Next attribCount

                                Case "desc"
                                    pDescription = pDescription & noeudEnf_Program.InnerText

                                Case "credits"
                                    pCredits = noeudEnf_Program.InnerText

                                    ' lit les attributs de credits
                                    For Each noeudEnf_Credits In noeudEnf_Program
                                        Select Case noeudEnf_Credits.Name
                                            Case "director"
                                                pDirector = pDirector & noeudEnf_Credits.InnerText & "/"

                                            Case "actor"

                                                'modifié le 01/03/2009
                                                pTemp = noeudEnf_Credits.InnerText
                                                'pActor = pActor & "/" & noeudEnf_Credits.InnerText
                                                'pActor = Replace(pTemp, """", """""")
                                                pActor = String.Concat(pActor, "/", pTemp)

                                            Case "writer"
                                                pWriter = pWriter & noeudEnf_Credits.InnerText & "/"
                                            Case "adapter"
                                                pAdapter = pAdapter & noeudEnf_Credits.InnerText & "/"
                                            Case "producer"
                                            Case "presenter"
                                                PPresent = PPresent & noeudEnf_Credits.InnerText & "/"
                                            Case "commentator"
                                            Case "guest"
                                        End Select
                                    Next noeudEnf_Credits
                                Case "date"
                                    pDate = noeudEnf_Program.InnerText
                                Case "category"
                                    pCategory = pCategory & noeudEnf_Program.InnerText & "/"
                                    pos = pCategory.IndexOf("/", StringComparison.CurrentCulture)
                                    pCategoryTV = pCategory.Substring(0, pos)
                                Case "language"
                                    PLanguage = noeudEnf_Program.InnerText
                                Case "orig-language"
                                Case "length"
                                    pDuration = CInt(noeudEnf_Program.InnerText)


                                Case "episode-num"
                                Case "video"

                                    ' lit les attributs de video
                                    For Each noeudEnf_video In noeudEnf_Program
                                        Select Case noeudEnf_video.Name
                                            Case "aspect"
                                                pVideoAspect = noeudEnf_video.InnerText
                                            Case "colour"
                                                PVideoColor = CBool(If(noeudEnf_video.InnerText = "no", 0, 1))
                                        End Select
                                    Next noeudEnf_video

                                Case "audio"
                                    PAudioStereo = noeudEnf_Program.InnerText
                                Case "previously-shown"
                                Case "premiere"
                                    If Not noeudEnf_Program.InnerText.ToString.Length = 0 Then
                                        pPremiere = CInt(noeudEnf_Program.InnerText.ToString)
                                    End If
                                Case "last-chance"
                                Case "new"
                                Case "subtitles"
                                    If Not noeudEnf_Program.InnerText.ToString.Length <> 0 Then
                                        pSubTitle = (1).ToString
                                    End If
                                Case "rating"
                                    PRating = noeudEnf_Program.InnerText

                                    ' lit les attributs de rating
                                    For Each noeudEnf_Rating In noeudEnf_Program
                                        Select Case noeudEnf_Rating.Name
                                            Case "value"
                                                PRating = noeudEnf_Rating.InnerText
                                            Case "icon"
                                                pIconRating = noeudEnf_Rating.Attributes(0).Value.ToString
                                        End Select
                                    Next noeudEnf_Rating
                                Case "icon" ' 
                                Case "url"
                                Case "country" ' BB 240710 redescendu dans le bas de select case
                                    PCountry = noeudEnf_Program.InnerText
                                Case "star-rating"
                                    For Each noeudEnf_StarRating In noeudEnf_Program
                                        Select Case noeudEnf_StarRating.Name
                                            Case "value"
                                                PStarRating = noeudEnf_StarRating.InnerText.ToString
                                            Case "icon"
                                                pStarIconRating = noeudEnf_StarRating.Attributes(0).Value.ToString
                                        End Select
                                    Next noeudEnf_StarRating
                            End Select
                        Next noeudEnf_Program

                        MiseAjourDB("ProgramTbl")
                    End If

                    '   PIndex = PIndex + 1
                    Select Case maj_auto_flag
                        Case False
                            Miseajour.ProgressBarMiseaJ.Increment(1)

                            ' Pour Windows 7 Seulement : Mise à jour de la taskbar
                            ' durant le parsing en mise à jour manuelle
                            If _
                                ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                                My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                                Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                                'Dim greenOrb As Icon = My.Resources.manualupdate
                                'TaskbarManager.Instance.SetOverlayIcon(greenOrb, "In progress")
                                ZGuideTVTaskbar.SetProgressValue(Miseajour.ProgressBarMiseaJ.Value, PCount)
                            End If

                        Case True

                            ' Pour Windows 7 Seulement : Mise à jour de la taskbar
                            ' durant le parsing en mise à jour automatique
                            MiseAJourAuto.ProgressBar1.Increment(1)
                            If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                            TaskbarManager.IsPlatformSupported Then
                                Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                                'Dim greenOrb As Icon = My.Resources.manualupdate
                                'TaskbarManager.Instance.SetOverlayIcon(greenOrb, "In progress")
                                ZGuideTVTaskbar.SetProgressValue(MiseAJourAuto.ProgressBar1.Value, PCount)
                            End If
                    End Select

                    If modulo(compteur, 500) = 1 Then
                        ' fonction existante : x=compteur Mod 500
                        Dim actual_time As New DateTime
                        actual_time = DateTime.Now
                        Dim diff_time As New TimeSpan
                        diff_time = actual_time.Subtract(start_time)
                        ' en secondes
                        temps_par_noeud = ((diff_time.Seconds / compteur))
                        temps_estime = (PCount - compteur) * temps_par_noeud
                        'Trace.WriteLine(datetime.now & "start_time= " & start_time.ToString & "  actual_time= " & actual_time.ToString)
                        'Trace.WriteLine(datetime.now & " compteur= " & compteur.ToString & "temps par noeud= " & temps_par_noeud.ToString)
                        MiseAJourAuto.MiseajourAuto_estimated.Text = MiseAJourAuto.remaining_time & " " & _
                                                                     (CInt(temps_estime)).ToString & " sec"
                        MiseAJourAuto.Refresh()
                        diff_time = Nothing
                    Else
                    End If
                    Application.DoEvents()
                    compteur = compteur + 1
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            Next noeud
            MiseAjourDB("ProgramTbl", , "Commit")
            Trace.WriteLine("fin de  mise à jour du fichier .db3")

            ' Pour Windows 7 Seulement : Remise de la taskbar à zéro
            If _
                ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
            End If

#If DEBUG Then
            monstop.Stop()
            duree = monstop.ElapsedMilliseconds
            Trace.WriteLine(datetime.now & " ")
            Trace.WriteLine(datetime.now & "temps exécution de PARSE XML Programs = " & duree.ToString)
            monstop = Nothing
#End If

        Catch
            My.Settings.FichierCorrompu = 1
            'If Mainform.Visible = True Then FrmMiseajour.Hide()
            Dim BoxFichierCorrompu As DialogResult
            BoxFichierCorrompu = _
                MessageBox.Show( _
                                 MessageFichierCorrompu & Chr(13) & Chr(13) & MessageFichierCorrompu1 & Chr(13) & _
                                 MessageFichierCorrompu2, MessageFichierCorrompuTitre, MessageBoxButtons.YesNo, _
                                 MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If BoxFichierCorrompu = DialogResult.Yes Then

                My.Settings.UserRestart = 1

            Else
                My.Settings.UserRestart = 0

            End If
        End Try
    End Sub

    Public Function modulo(ByVal Num As Integer, ByVal denom As Integer) As Integer
        Dim a As Integer
        Dim b As Integer
        Try
            a = CInt(Num / denom)
        Catch ex As Exception
            Trace.WriteLine(ex.Message)
            Trace.WriteLine(DateTime.Now & " Probablement division par zero dans fonction Modulo")
            Return (-1)
        End Try
        b = denom * a
        Return (Num - b)
    End Function
End Module
