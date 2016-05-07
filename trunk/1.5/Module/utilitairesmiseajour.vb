' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2013 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

' ReSharper disable CheckNamespace
Friend Module Utilitairesmiseajour
    ' ReSharper restore CheckNamespace
    Public MessageFichierCorrompu As String = "Le fichier XMLTV n'est pas conforme aux spécifications DTD !"
    Public MessageFichierCorrompu1 As String = "Voulez-vous essayer de récupérer votre ancienne base de donnée"
    Public MessageFichierCorrompu2 As String = "ou sélectionner un autre fichier de mise à jour ?"
    Public MessageFichierCorrompuTitre As String = "ZGuideTV.NET - Fichier non conforme"
    Private _poid As Integer

    Private ReadOnly Os As OperatingSystem = Environment.OSVersion

    Public Sub EcritureChannelsSet()
        Dim sw As New StreamWriter(ChannelSetPath & "\" & "ZGuideTVDotNet.channels.set")
        Dim nombredechaineselectionnees As Integer

        ' 'On déclare les variables
        Dim saveListview As String = ""

        Try
            For Each itm As ListViewItem In Miseajour.ListXMLTVFRChoisie.Items ' Boucle sur le nombre d'items dans la ListView
                If Miseajour.CollectionChannels.Contains(itm.Text) Then
                    ArrayOnechannel = DirectCast(Miseajour.CollectionChannels.Item(itm.Text), String())
                    saveListview = saveListview & _
                                    (ArrayOnechannel(0) & ("|") & ArrayOnechannel(1) & ("|") & ArrayOnechannel(2) & _
                                     ("|"))
                    sw.WriteLine(saveListview)
                    ' Ecrit dans le fichier le contenu de la variable Save_Listview

                    saveListview = ""
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
            sw.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Trace.WriteLine( _
                             DateTime.Now & _
                             " Erreur lors de l'écriture du ZGuideTVDotNet.channels.set dans frmmiseajour")
        End Try
    End Sub

    Public Sub InitierChannelsSet()
        Dim sw As New StreamWriter(ChannelSetPath & "ZGuideTVDotNet.channels.set")
        Dim ligne As String
        Dim z1 As String
        Dim z2 As String
        Dim z3 As String
        Dim i As Integer

        Try
            For i = 1 To NbTotalChaines
                'ligne = ""
                z1 = TableauChaine(i).Identificateur
                z2 = TableauChaine(i).Nom
                z3 = TableauChaine(i).Logo
                ligne = z1 & "|" & z2 & "|" & z3 & "|"
                If (Not z1 Is Nothing AndAlso String.IsNullOrEmpty(z1)) OrElse (Not z2 Is Nothing AndAlso String.IsNullOrEmpty(z2)) OrElse (Not z3 Is Nothing AndAlso String.IsNullOrEmpty(z3)) Then
                    Exit For
                End If
                sw.WriteLine(ligne)
            Next i

            sw.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Trace.WriteLine( _
                             DateTime.Now & _
                             " Erreur lors de l'initialisation du ZGuideTVDotNet.channels.set dans frmmiseajour")
        End Try
    End Sub

    Public Function DownloadFile(ByVal remoteFilePath As String, ByVal saveFilePath As String, ByVal timeOut As Integer, _
                                  Optional ByVal blockSize As Integer = 1024, Optional ByVal bMessage As Boolean = True) _
        As Boolean

        Select Case MajAutoFlag
            Case False
                Miseajour.ProgressBarMiseaJ.Style = ProgressBarStyle.Continuous

                ' Pour Windows 7 Seulement : Style de la progressbar 
                ' durant le Download en mise à jour manuelle
                If _
                    ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                    My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                    Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                    zGuideTvTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                End If

            Case True
                MiseAJourAuto.ProgressBar1.Style = ProgressBarStyle.Continuous

                ' Pour Windows 7 Seulement : Style de la progressbar
                ' durant le Download en mise à jour auto
                If ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                TaskbarManager.IsPlatformSupported Then
                    Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                    zGuideTvTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                End If
        End Select

        Try
            Select Case MajAutoFlag ' mise à jour automatique ou pas ?
                Case False
                    Miseajour.ProgressBarMiseaJ.Style = ProgressBarStyle.Continuous
                    Miseajour.ProgressBarMiseaJ.Step = blockSize

                    ' Pour Windows 7 Seulement : Style de la progressbar
                    ' durant le Download en mise à jour manuelle
                    If _
                        ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                        My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                        Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                        zGuideTvTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                    End If
                Case True
                    With MiseAJourAuto
                        .ProgressBar1.Style = ProgressBarStyle.Continuous
                        .ProgressBar1.Step = blockSize

                        .autoupdate_title.Text = .AutoUpdateOperation & " " & _
                                                              .DwnlOperation
                        .MiseAJourAuto_Weight.Text = .FileSize
                        .MiseajourAuto_estimated.Text = .RemainingTime

                        .BringToFront()
                        .ProgressBar1.Refresh()
                        .Refresh()
                        .Visible = True
                    End With

                    ' Pour Windows 7 Seulement : Style de la progressbar
                    ' durant le Download en mise à jour auto
                    If ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                    TaskbarManager.IsPlatformSupported Then
                        Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                        zGuideTvTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                    End If
            End Select

            ' Néo 25/06/2013 
            Dim wr As HttpWebRequest
            wr = CType(HttpWebRequest.Create(remoteFilePath), HttpWebRequest)

            If My.Settings.Proxy <> "" AndAlso My.Settings.ProxyPort <> Nothing Then
                Dim hcredential As New NetworkCredential(My.Settings.loginproxy, My.Settings.passproxy)
                Dim myProxy As New WebProxy(My.Settings.Proxy, CInt(My.Settings.ProxyPort))
                wr.Credentials = hcredential
                wr.Proxy = myProxy
            End If

            With wr
                .Timeout = timeOut
                .UserAgent = "ZGuideTV " & My.Application.Info.Version().ToString
                .AllowAutoRedirect = True
                ServicePointManager.Expect100Continue = False
            End With

            Try
                Dim wresp As WebResponse = wr.GetResponse()
                Dim remoteStream As Stream = wresp.GetResponseStream()

                ' calcul de Poid: la taille du fichier à telecharger
                _poid = CInt(wresp.ContentLength)
                Trace.WriteLine(DateTime.Now & " taille du fichier à telecharger (kbyte) : " & (_poid / 1000).ToString)

                Select Case MajAutoFlag ' mise a jour automatique?
                    Case False

                        Miseajour.ProgressBarMiseaJ.Maximum = _poid
                    Case True
                        MiseAJourAuto.ProgressBar1.Maximum = _poid
                        MiseAJourAuto.MiseAJourAuto_Weight.Text = MiseAJourAuto.FileSize & " " & CInt(_poid / 1024) & _
                                                                  " Ko"
                        MiseAJourAuto.ProgressBar1.Refresh()
                End Select

                Dim _
                    localStream As _
                        New FileStream(saveFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read)
                Dim localStreamW As New BinaryWriter(localStream)

                Dim buff(blockSize - 1) As Byte
                Dim iBytesRead As Integer = 1
                Dim compteurBlock As Integer = 1
                Dim startTime As Long
                startTime = DateTime.Now.Ticks

                Do While (iBytesRead > 0)
                    Select Case MajAutoFlag
                        Case False
                            Miseajour.ProgressBarMiseaJ.Increment(blockSize)

                            ' Pour Windows 7 Seulement : Mise à jour de la taskbar 
                            ' durant le Download en mise à jour manuelle
                            If _
                                ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                                My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                                Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                                zGuideTvTaskbar.SetProgressValue(Miseajour.ProgressBarMiseaJ.Value, _poid)
                            End If

                        Case True
                            MiseAJourAuto.ProgressBar1.Increment(blockSize)

                            ' Pour Windows 7 Seulement : Mise à jour de la taskbar
                            ' durant le Download en mise à jour automatique
                            If ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                            TaskbarManager.IsPlatformSupported Then
                                Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                                zGuideTvTaskbar.SetProgressValue(MiseAJourAuto.ProgressBar1.Value, _poid)
                            End If

                            If Modulo(compteurBlock, 25) = 1 Then
                                Dim actualTime As Long
                                Dim diffTemps As Long
                                actualTime = DateTime.Now.Ticks
                                Dim diffSize As Long
                                Dim vitesse As Double
                                Dim tempsEstime As Double

                                diffTemps = actualTime - startTime
                                diffSize = compteurBlock * blockSize
                                '07/02/2009
                                vitesse = 1024 * (1000 * diffSize / (diffTemps * 1))
                                ' en kbyte/sec
                                Trace.WriteLine(DateTime.Now & " compteur = " & compteurBlock.ToString)
                                Trace.WriteLine( _
                                                 DateTime.Now & " vitesse = " & vitesse.ToString & " actual-time= " & _
                                                 actualTime.ToString & "start time = " & startTime.ToString)
                                Trace.WriteLine(DateTime.Now & " diff_temps = " & diffTemps.ToString)

                                tempsEstime = (_poid - compteurBlock * blockSize) / vitesse
                                tempsEstime = Math.Max(tempsEstime, 0)
                                Trace.WriteLine(DateTime.Now & " temps estimé = " & tempsEstime.ToString)
                                '07/02/2009
                                MiseAJourAuto.MiseajourAuto_estimated.Text = MiseAJourAuto.RemainingTime & " " & _
                                                                             (CInt(tempsEstime)).ToString & " sec"
                                Trace.WriteLine(" ")
                                Thread.Sleep(50)
                                MiseAJourAuto.Refresh()

                            Else
                            End If
                    End Select

                    iBytesRead = remoteStream.Read(buff, 0, buff.Length)
                    localStreamW.Write(buff, 0, iBytesRead)
                    compteurBlock += 1
                Loop

                Select Case MajAutoFlag
                    Case False
                        Miseajour.ProgressBarMiseaJ.Maximum = 0

                        ' Pour Windows 7 Seulement : Mise à zéro taskbar
                        ' durant le Download en mise à jour manuelle
                        If _
                            ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                            My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                            Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                            zGuideTvTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
                        End If

                    Case True
                        MiseAJourAuto.ProgressBar1.Maximum = 0

                        ' Pour Windows 7 Seulement : Mise à zéro taskbar
                        ' durant le Download en mise à jour auto
                        If ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                        TaskbarManager.IsPlatformSupported Then
                            Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                            zGuideTvTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
                        End If
                End Select

                wresp.Close()
                remoteStream.Close()
                remoteStream.Dispose()
                localStreamW.Close()
                localStream.Close()
                localStream.Dispose()

            Catch ex As Exception
                Select Case MajAutoFlag
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

                    ' ReSharper disable NotAccessedVariable
                    Dim boxError As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxError = MessageBox.Show _
                        (ex.Message & Chr(13), _
                         ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                         MessageBoxDefaultButton.Button1)
                End If
                Return False
            End Try
        Catch ex As Exception
            ' ReSharper disable NotAccessedVariable
            Dim boxError As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxError = MessageBox.Show _
                (ex.Message & Chr(13), _
                 ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                 MessageBoxDefaultButton.Button1)
            Return False
        End Try

        Return True
    End Function

    Public Sub TraitementAppliquer()

        ' rvs75 le 11/09/2009
        ' Pour forcer la mise à jour de ''ZGuideTVDotNet.channels.set'
        DeleteDb()
        CreateDbTables()

        If Miseajour.ListXMLTVFRChoisie.Items.Count > 0 Then
            EcritureChannelsSet()
        End If
        If Miseajour.ButtonToutClick = "True" Then
            MiseAjourDb("ChannelTbl", Miseajour.CollectionSelectChannels)
        Else

            Dim itm As ListViewItem
            Trace.WriteLine(DateTime.Now & " Liste des chaines mises a jour dans frmmiseajour : ")

            Miseajour.CollectionSelectChannels.Clear()
            For Each itm In Miseajour.ListXMLTVFRChoisie.Items
                If Miseajour.CollectionChannels.Contains(itm.Text) Then

                    ArrayOnechannel = DirectCast(Miseajour.CollectionChannels.Item(itm.Text), String())

                    Miseajour.CollectionSelectChannels.Add(ArrayOnechannel)
                End If
                Thread.Sleep(25)
            Next itm

            NombreDeChainesDifferentes = Miseajour.ListXMLTVFRChoisie.Items.Count
            '010809
            My.Settings.nbchainesdiff = NombreDeChainesDifferentes
            My.Settings.Save()

            ' les chaines choisies sont sauvegardées dans
            ' collectionSelectChannels
            ' (3 infos par chaine sauvees dans arrayonechannel(2))
            ' C5.telepoche.com, arte, arte.gif)

            MiseAjourDb("ChannelTbl", Miseajour.CollectionSelectChannels)
        End If

        If (XmlTvName.Length > 0) Then
            Mainform.Timer_minute.Stop()
            Mainform.TimerUsageMemory.Stop() 'BB 260710
            ParseXmlPrograms(FichierProgramme)
            Mainform.Timer_minute.Start()
            Mainform.TimerUsageMemory.Stop() 'BB 260710
        Else
        End If
        Cursor.Current = Cursors.Default

        'On sauvergarde la date de la dernière mise à jour
        My.Settings.datemajmiseajour = (Date.Now).ToString

        Trace.WriteLine(DateTime.Now & " sortie de traitement_appliquer")

        Select Case MajAutoFlag
            Case False
                Miseajour.Hide()
                Miseajour.Close()
            Case True
                MiseAJourAuto.Hide()
                MiseAJourAuto.Close()
                Trace.WriteLine(" fermeture du formulaire mise a jour auto")
        End Select
    End Sub

    Private Sub ParseXmlPrograms(ByVal pathXml As String)

        Try

            ' Y a t il des erreurs à signaler au programme appelant? 050409
            Dim xmlTvDoc As New XmlDocument()
            Dim elementProgram As XmlNodeList
            Dim noeud As XmlNode
            Dim noeudEnfProgram As XmlNode
            Dim noeudEnfCredits As XmlNode
            Dim noeudEnfRating As XmlNode
            Dim noeudEnfStarRating As XmlNode
            Dim noeudEnfVideo As XmlNode
            Dim attribCount As Short
            Dim pos As Integer
            Dim pCount As Int32 '= 1
            Dim bperim As Boolean = My.Settings.bIntegrPerim

            ' ajouté le 01/03/2009
            Dim pTemp As String

            Trace.WriteLine("extraction des données des emissions:entree dans parse xml program")
            xmlTvDoc.Load(pathXml)

            elementProgram = xmlTvDoc.DocumentElement.GetElementsByTagName("programme")

            ' compte le nbre d'émission pour tous les channel selectionnés
            MiseAJourAuto.autoupdate_title.Text = MiseAJourAuto.AutoUpdateOperation & " " & _
                                                  MiseAJourAuto.ParsingOperation
            MiseAJourAuto.MiseAJourAuto_Weight.Text = MiseAJourAuto.NodeNumber & " "
            MiseAJourAuto.MiseajourAuto_estimated.Text = MiseAJourAuto.RemainingTime & " "

            pCount = elementProgram.Count + 1

            Select Case MajAutoFlag
                Case False
                    Miseajour.ProgressBarMiseaJ.Maximum = pCount
                    Miseajour.ProgressBarMiseaJ.Step = 1

                Case True
                    Trace.WriteLine(DateTime.Now & " parse xml program progress bar1 max = " & pCount.ToString)
                    MiseAJourAuto.ProgressBar1.Maximum = pCount
                    MiseAJourAuto.ProgressBar1.Step = 1
                    MiseAJourAuto.MiseAJourAuto_Weight.Text = MiseAJourAuto.NodeNumber & " " & pCount.ToString
            End Select

            Dim startTime As DateTime
            startTime = DateTime.Now

            Dim compteur As Integer = 1
            Dim tempsParNoeud As Double
            Dim tempsEstime As Double

            MiseAjourDb("ProgramTbl", , "Begin")

            For Each noeud In elementProgram
                Try

                    PStartA = "#01/01/0001 12:00:00 AM#"
                    PStopA = "#01/01/0001 12:00:00 AM#"
                    PDiff = 0
                    PDuration = 0
                    PCountry = ""
                    PShowviewA = ""
                    PChannelA = ""
                    PClumpidxA = ""
                    PPdcStartA = ""
                    PVpsStartA = ""
                    PVideoplusA = ""
                    PTitle = ""
                    PSubTitle = ""
                    PDescription = ""
                    PCredits = ""
                    PActor = ""
                    PDirector = ""
                    PWriter = ""
                    PPresent = ""
                    PRating = ""
                    PIconRating = ""
                    PStarRating = ""
                    PStarIconRating = " "
                    PPremiere = 0
                    PVideoAspect = ""
                    PVideoColor = True
                    PAudioStereo = ""
                    PSubType = 0
                    PLanguage = ""
                    PDate = ""
                    PCategory = ""
                    PCategoryTv = ""
                    PReview = ""
                    TextAttrib = ""

                    Dim channelFound As Boolean = False

                    With noeud.Attributes
                        ' lit les attributs de programe
                        For attribCount = 0 To CShort(.Count - 1)
                            TextAttrib = .ItemOf(attribCount).InnerText

                            Select Case .ItemOf(attribCount).Name
                                Case "start"

                                    PStartA = TextAttrib.Substring(0, 4) & "-" & TextAttrib.Substring(4, 2) & "-" & _
                                               TextAttrib.Substring(6, 2) & " " & TextAttrib.Substring(8, 2) & ":" & _
                                               TextAttrib.Substring(10, 2)
                                Case "stop"
                                    PStopA = TextAttrib.Substring(0, 4) & "-" & TextAttrib.Substring(4, 2) & "-" & _
                                              TextAttrib.Substring(6, 2) & " " & TextAttrib.Substring(8, 2) & ":" & _
                                              TextAttrib.Substring(10, 2)
                                Case "showview"
                                    PShowviewA = .ItemOf(attribCount).InnerText
                                Case "channel"
                                    PChannelA = .ItemOf(attribCount).InnerText

                                    For Each item As String() In Miseajour.CollectionSelectChannels
                                        If [String].Equals(item(0), PChannelA, StringComparison.CurrentCulture) Then
                                            channelFound = True
                                            PIndex += 1
                                            Exit For
                                        End If
                                    Next item

                                Case "clumpidx"
                                    PClumpidxA = .ItemOf(attribCount).InnerText
                                Case "pdc-start"
                                    PPdcStartA = .ItemOf(attribCount).InnerText
                                Case "vps-start"
                                    PVpsStartA = .ItemOf(attribCount).InnerText
                                Case "videoplus"
                                    PVideoplusA = .ItemOf(attribCount).InnerText
                            End Select

                        Next attribCount
                    End With

                    Dim dateFin As Date = Date.Now.AddHours(-6)
                    If channelFound AndAlso (Date.Compare(CDate(PStopA), dateFin) > 0 OrElse bperim) Then

                        ' lit les noeuds enfant de programme
                        For Each noeudEnfProgram In noeud
                            Select Case noeudEnfProgram.Name
                                Case "title"
                                    PTitle = noeudEnfProgram.InnerText

                                    ' lit les attributs de title
                                    For attribCount = 0 To CShort(noeudEnfProgram.Attributes.Count - 1)
                                        TextAttrib = noeudEnfProgram.Attributes.ItemOf(attribCount).InnerText

                                        Select Case noeudEnfProgram.Attributes.ItemOf(attribCount).Name
                                            Case "title lang"
                                        End Select
                                    Next attribCount

                                Case "sub-title"
                                    PSubTitle = noeudEnfProgram.InnerText

                                    ' lit les attributs de sub-title
                                    For attribCount = 0 To CShort(noeudEnfProgram.Attributes.Count - 1)
                                        TextAttrib = noeudEnfProgram.Attributes.ItemOf(attribCount).InnerText
                                        Select Case noeudEnfProgram.Attributes.ItemOf(attribCount).Name
                                            Case "title lang"
                                        End Select
                                    Next attribCount

                                Case "desc"
                                    PDescription = PDescription & noeudEnfProgram.InnerText

                                Case "credits"
                                    PCredits = noeudEnfProgram.InnerText

                                    ' lit les attributs de credits
                                    For Each noeudEnfCredits In noeudEnfProgram
                                        Select Case noeudEnfCredits.Name
                                            Case "director"
                                                PDirector = PDirector & noeudEnfCredits.InnerText & "/"

                                            Case "actor"

                                                'modifié le 01/03/2009
                                                pTemp = noeudEnfCredits.InnerText
                                                'pActor = pActor & "/" & noeudEnf_Credits.InnerText
                                                'pActor = Replace(pTemp, """", """""")
                                                PActor = String.Concat(PActor, "/", pTemp)

                                            Case "writer"
                                                PWriter = PWriter & noeudEnfCredits.InnerText & "/"
                                            Case "adapter"
                                                PAdapter = PAdapter & noeudEnfCredits.InnerText & "/"
                                            Case "producer"
                                            Case "presenter"
                                                PPresent = PPresent & noeudEnfCredits.InnerText & "/"
                                            Case "commentator"
                                            Case "guest"
                                        End Select
                                    Next noeudEnfCredits
                                Case "date"
                                    PDate = noeudEnfProgram.InnerText
                                Case "category"
                                    PCategory = PCategory & noeudEnfProgram.InnerText & "/"
                                    pos = PCategory.IndexOf("/", StringComparison.CurrentCulture)
                                    PCategoryTv = PCategory.Substring(0, pos)
                                Case "language"
                                    PLanguage = noeudEnfProgram.InnerText
                                Case "orig-language"
                                Case "length"
                                    PDuration = CInt(noeudEnfProgram.InnerText)


                                Case "episode-num"
                                Case "video"

                                    ' lit les attributs de video
                                    For Each noeudEnfVideo In noeudEnfProgram
                                        Select Case noeudEnfVideo.Name
                                            Case "aspect"
                                                PVideoAspect = noeudEnfVideo.InnerText
                                            Case "colour"
                                                PVideoColor = CBool(If([String].Equals(noeudEnfVideo.InnerText, "no", StringComparison.CurrentCulture), 0, 1))
                                        End Select
                                    Next noeudEnfVideo

                                Case "audio"
                                    PAudioStereo = noeudEnfProgram.InnerText
                                Case "previously-shown"
                                Case "premiere"
                                    If Not noeudEnfProgram.InnerText.ToString.Length = 0 Then
                                        PPremiere = CInt(noeudEnfProgram.InnerText.ToString)
                                    End If
                                Case "last-chance"
                                Case "new"
                                Case "subtitles"
                                    If Not noeudEnfProgram.InnerText.ToString.Length <> 0 Then
                                        PSubTitle = (1).ToString
                                    End If
                                Case "rating"
                                    PRating = noeudEnfProgram.InnerText

                                    ' lit les attributs de rating
                                    For Each noeudEnfRating In noeudEnfProgram
                                        Select Case noeudEnfRating.Name
                                            Case "value"
                                                PRating = noeudEnfRating.InnerText
                                            Case "icon"
                                                PIconRating = noeudEnfRating.Attributes(0).Value.ToString
                                        End Select
                                    Next noeudEnfRating
                                Case "icon" ' 
                                Case "url"
                                Case "country" ' BB 240710 redescendu dans le bas de select case
                                    PCountry = noeudEnfProgram.InnerText
                                Case "star-rating"
                                    For Each noeudEnfStarRating In noeudEnfProgram
                                        Select Case noeudEnfStarRating.Name
                                            Case "value"
                                                PStarRating = noeudEnfStarRating.InnerText.ToString
                                            Case "icon"
                                                PStarIconRating = noeudEnfStarRating.Attributes(0).Value.ToString
                                        End Select
                                    Next noeudEnfStarRating
                            End Select
                        Next noeudEnfProgram

                        MiseAjourDb("ProgramTbl")
                    End If

                    '   PIndex = PIndex + 1
                    Select Case MajAutoFlag
                        Case False
                            Miseajour.ProgressBarMiseaJ.Increment(1)

                            ' Pour Windows 7 Seulement : Mise à jour de la taskbar
                            ' durant le parsing en mise à jour manuelle
                            If _
                                ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                                My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                                Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                                'Dim greenOrb As Icon = My.Resources.manualupdate
                                'TaskbarManager.Instance.SetOverlayIcon(greenOrb, "In progress")
                                zGuideTvTaskbar.SetProgressValue(Miseajour.ProgressBarMiseaJ.Value, pCount)
                            End If

                        Case True

                            ' Pour Windows 7 Seulement : Mise à jour de la taskbar
                            ' durant le parsing en mise à jour automatique
                            MiseAJourAuto.ProgressBar1.Increment(1)
                            If ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                            TaskbarManager.IsPlatformSupported Then
                                Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                                'Dim greenOrb As Icon = My.Resources.manualupdate
                                'TaskbarManager.Instance.SetOverlayIcon(greenOrb, "In progress")
                                zGuideTvTaskbar.SetProgressValue(MiseAJourAuto.ProgressBar1.Value, pCount)
                            End If
                    End Select

                    If Modulo(compteur, 500) = 1 Then
                        ' fonction existante : x=compteur Mod 500
                        Dim actualTime As DateTime
                        actualTime = DateTime.Now
                        Dim diffTime As TimeSpan
                        diffTime = actualTime.Subtract(startTime)
                        ' en secondes
                        tempsParNoeud = ((diffTime.Seconds / compteur))
                        tempsEstime = (pCount - compteur) * tempsParNoeud
                        'Trace.WriteLine(datetime.now & "start_time= " & start_time.ToString & "  actual_time= " & actual_time.ToString)
                        'Trace.WriteLine(datetime.now & " compteur= " & compteur.ToString & "temps par noeud= " & temps_par_noeud.ToString)
                        MiseAJourAuto.MiseajourAuto_estimated.Text = MiseAJourAuto.RemainingTime & " " & _
                                                                     (CInt(tempsEstime)).ToString & " sec"
                        MiseAJourAuto.Refresh()
                    Else
                    End If
                    Application.DoEvents()
                    compteur = compteur + 1
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            Next noeud
            MiseAjourDb("ProgramTbl", , "Commit")
            Trace.WriteLine("fin de  mise à jour du fichier .db3")

            ' Pour Windows 7 Seulement : Remise de la taskbar à zéro
            If _
                ((Os.Version.Major = 6 AndAlso Os.Version.Minor >= 1) OrElse Os.Version.Major > 6) AndAlso _
                My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                Dim zGuideTvTaskbar As TaskbarManager = TaskbarManager.Instance
                zGuideTvTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
            End If

        Catch
            My.Settings.FichierCorrompu = 1
            'If Mainform.Visible = True Then FrmMiseajour.Hide()
            Dim boxFichierCorrompu As DialogResult
            boxFichierCorrompu = _
                MessageBox.Show( _
                                 MessageFichierCorrompu & Chr(13) & Chr(13) & MessageFichierCorrompu1 & Chr(13) & _
                                 MessageFichierCorrompu2, MessageFichierCorrompuTitre, MessageBoxButtons.YesNo, _
                                 MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If boxFichierCorrompu = DialogResult.Yes Then

                My.Settings.UserRestart = 1

            Else
                My.Settings.UserRestart = 0

            End If
        End Try
    End Sub

    Private Function Modulo(ByVal num As Integer, ByVal denom As Integer) As Integer

        Dim a As Integer
        Dim b As Integer
        Try
            a = CInt(num / denom)
        Catch ex As Exception
            Trace.WriteLine(ex.Message)
            Trace.WriteLine(DateTime.Now & " Probablement division par zero dans fonction Modulo")
            Return (-1)
        End Try
        b = denom * a
        Return (num - b)
    End Function
End Module
