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
Imports System.Xml
Imports System.IO
Imports System.Net
Imports ZGuideTV.SQLiteWrapper
Imports System.Threading
Imports System.Text
Imports Microsoft.WindowsAPICodePack.Taskbar

Module UtilitaireMiseaJourEPGData

    Dim url2 As String
    Dim temp2 As String
    Dim nombreDownload As Decimal = My.Settings.EpgdataDownload

    Private os As OperatingSystem = Environment.OSVersion

    Private _parsing As String

    Public Property Parsing As String
        Get
            Return _parsing
        End Get
        Set(ByVal Value As String)
            _parsing = Value
        End Set
    End Property

    Private _telechargement As String

    Public Property Telechargement As String
        Get
            Return _telechargement
        End Get
        Set(ByVal Value As String)
            _telechargement = Value
        End Set
    End Property

    Sub ParseInclude()
        DeleteDBEPGData()
        CreateDBEPGDATA()
        Dim filename As String = "includes.zip"
        If Miseajour.CopierFichier(XmlTvName, AppData & filename, True) Then

            ' Rajout de Ronaldo1 03/11/2007
            Dim XMLPurge() As String
            XMLPurge = Directory.GetFiles(AppData, "*.xml")
            Dim i As Integer = 0
            Do While i < XMLPurge.Length
                File.Delete(XMLPurge(i))
                i = i + 1
            Loop

            ' on décompresse le fichier avec 7-zip. Modifié par Néo le 27/02/2010
            Dim p As Process = Nothing
            Try
                p = New Process
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.StartInfo.CreateNoWindow = False
                p.StartInfo.UseShellExecute = True
                p.StartInfo.FileName = UnZipPath
                p.StartInfo.Arguments = " e " & """" & AppData & filename & """" & " -y -o" & """" & _
                                        AppData & """"
                p.Start()
                p.WaitForExit()
                p.Dispose()
                p = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Exception")
                Trace.WriteLine(DateTime.Now & "Erreur lors de la décompression du fichier avec 7-zip dans frmMiseajour.vb")
            Finally
                If p IsNot Nothing Then
                    If Not p.HasExited Then
                        p.Kill()
                    End If
                    p.Dispose()
                    p = Nothing
                End If
            End Try

            Dim XMLFile() As String = Directory.GetFiles(AppData, "*.XML")

            Dim DebutNom As String
            For i = 0 To XMLFile.Length - 1
                DebutNom = XMLFile(i).Substring(XMLFile(i).LastIndexOf("\", StringComparison.CurrentCulture) + 1, 7)
                Select Case DebutNom
                    Case "channel"
                        parsechannel(XMLFile(i))
                    Case "categor"
                        parsecategory(XMLFile(i))
                    Case "genre.x"
                        ParseGenre(XMLFile(i))
                End Select
            Next
        Else
        End If

    End Sub

    Private Sub ParseGenre(ByVal nomFichier As String)
        Dim XmlTvDoc As New XmlDocument()
        XmlTvDoc.Load(nomFichier)
        Dim elementGenre As XmlNodeList = XmlTvDoc.DocumentElement.GetElementsByTagName("data")
        Dim noeud As XmlNode
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "EPGData.db3")
        db.ExecuteNonQueryFast("begin transaction;")
        For Each noeud In elementGenre
            db.ExecuteNonQueryFast("insert into Genre (id,name) values ('" & noeud.ChildNodes(0).InnerText & "','" & noeud.ChildNodes(1).InnerText & "')")
        Next
        db.ExecuteNonQueryFast("end transaction;")
        db = Nothing
    End Sub

    Private Sub parsecategory(ByVal nomFichier As String)
        Dim XmlTvDoc As New XmlDocument()
        XmlTvDoc.Load(nomFichier)
        Dim elementCategorie As XmlNodeList = XmlTvDoc.DocumentElement.GetElementsByTagName("data")
        Dim noeud As XmlNode
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "EPGData.db3")
        db.ExecuteNonQueryFast("begin transaction;")
        For Each noeud In elementCategorie
            db.ExecuteNonQueryFast("insert into Category (id,name) values ('" & noeud.ChildNodes(0).InnerText & "','" & noeud.ChildNodes(1).InnerText & "')")
        Next
        db.ExecuteNonQueryFast("end transaction;")
        db = Nothing
    End Sub

    Private Sub parsechannel(ByVal nomFichier As String)
        Dim XmlTvDoc As New XmlDocument()
        XmlTvDoc.Load(nomFichier)
        Dim elementChannel As XmlNodeList = XmlTvDoc.DocumentElement.GetElementsByTagName("data")
        Dim noeud As XmlNode

        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "EPGData.db3")
        db.ExecuteNonQueryFast("begin transaction;")
        For Each noeud In elementChannel
            db.ExecuteNonQueryFast("insert or ignore into channel (id,name) values ('" & noeud.ChildNodes(4).InnerText & "','" & noeud.ChildNodes(0).InnerText & "')")
        Next
        db.ExecuteNonQueryFast("end transaction;")
        db = Nothing
    End Sub

    Sub traitementEPGDataMT()

        DeleteDB()
        CreateDBTables()
        Dim tbInfoDownload As TextBox
        If maj_auto_flag Then
            tbInfoDownload = miseajourautoEPGDATA.tbInfo
        Else
            tbInfoDownload = MiseajourEPGData.tbInfo
        End If

        Dim XmlTvName() As String = Directory.GetFiles(TempPath, "temp_programme?.zip")
        For cpt As Integer = 0 To XmlTvName.Length - 1
            If Miseajour.CopierFichier(XmlTvName(cpt), AppData & "program" & cpt.ToString & ".zip", True) Then
                tbInfoDownload.Text = tbInfoDownload.Text & Parsing & " " & cpt.ToString & Environment.NewLine
                ' Rajout de Ronaldo1 03/11/2007
                Dim XMLPurge() As String
                XMLPurge = Directory.GetFiles(AppData, "*.xml")
                Dim i As Integer = 0
                Do While i < XMLPurge.Length
                    File.Delete(XMLPurge(i))
                    i = i + 1
                Loop
                XMLPurge = Directory.GetFiles(AppData, "*.dtd")
                i = 0
                Do While i < XMLPurge.Length
                    File.Delete(XMLPurge(i))
                    i = i + 1
                Loop

                ' on décompresse le fichier avec 7-zip. Modifié par Néo le 27/02/2010
                Dim p As Process = Nothing
                Try
                    p = New Process
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    p.StartInfo.CreateNoWindow = False
                    p.StartInfo.UseShellExecute = True
                    p.StartInfo.FileName = UnZipPath
                    p.StartInfo.Arguments = " e " & """" & AppData & "program" & cpt.ToString & ".zip" & """" & " *.xml *.dtd -y -o" & """" & _
                                            AppData & """"
                    p.Start()
                    p.WaitForExit()
                    p.Dispose()
                    p = Nothing

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Exception")
                    Trace.WriteLine(DateTime.Now & "Erreur lors de la décompression du fichier avec 7-zip dans frmMiseajour.vb")
                Finally
                    If p IsNot Nothing Then
                        If Not p.HasExited Then
                            p.Kill()
                        End If
                        p.Dispose()
                        p = Nothing
                    End If
                End Try

                Dim XMLFile() As String = Directory.GetFiles(AppData, "*.XML")
                'creation de la liste des chaines selectionnées
                Dim collChaine As New Collection
                If maj_auto_flag Then
                    'à recuperer dans channel.set ou originallist
                    'For Each chaineL As Variables.channel_list In tableau_chaine
                    '    collChaine.Add(chaineL.identificateur)
                    'Next
                    Dim sr As New StreamReader(ChannelSetPath & "ZGuideTVDotNet.channels.set", Encoding.ASCII)
                    Dim Ligne As String
                    Ligne = ""
                    Ligne = sr.ReadLine()
                    Do
                        collChaine.Add(Ligne.Split(CChar("|"))(0))
                        Ligne = sr.ReadLine()
                    Loop Until Ligne Is Nothing
                    sr.Close()

                Else
                    For Each itemchaine As ListViewItem In MiseajourEPGData.ListXMLTVFRChoisie.Items
                        collChaine.Add(DirectCast(itemchaine.Tag, String())(0))
                    Next

                End If
                If cpt = 0 Then
                    MaJChannel()
                End If
                parseProgramme(XMLFile(0), collChaine)
            End If
        Next

    End Sub

    Private Sub MaJChannel()
        Dim strSql As String
        Dim intOrdreing As Integer = 1
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        db.ExecuteNonQueryFast("begin transaction;")
        'à remplacer dans zg

        If maj_auto_flag Then
            'à recuperer dans channel.set ou originallist
            'For Each chaineL As Variables.channel_list In tableau_chaine
            '    strSql = "insert into ChannelTbl(Name,ID,Logo,Ordering) values ('" & chaineL.nom.Replace("'", "''") & _
            '    "','" & chaineL.identificateur & "','" & _
            '    chaineL.logo & "'," & intOrdreing.ToString & ");"
            '    db.ExecuteNonQueryFast(strSql)
            '    intOrdreing += 1
            'Next


            Dim sr As New StreamReader(ChannelSetPath & "ZGuideTVDotNet.channels.set", Encoding.ASCII)
            Dim Ligne As String
            Ligne = ""
            Ligne = sr.ReadLine()
            Do
                strSql = "insert into ChannelTbl(Name,ID,Logo,Ordering) values ('" & Ligne.Split(CChar("|"))(1).Replace("'", "''") & _
                "','" & Ligne.Split(CChar("|"))(0) & "','" & _
                Ligne.Split(CChar("|"))(2) & "'," & intOrdreing.ToString & ");"
                db.ExecuteNonQueryFast(strSql)
                intOrdreing += 1
                Ligne = sr.ReadLine()
            Loop Until Ligne Is Nothing
            sr.Close()

        Else
            For Each chaine As ListViewItem In MiseajourEPGData.ListXMLTVFRChoisie.Items
                Dim strlogo As String = DirectCast(chaine.Tag, String())(1)
                Dim strID As String = DirectCast(chaine.Tag, String())(0)
                strSql = "insert into ChannelTbl(Name,ID,Logo,Ordering) values ('" & chaine.Text.Replace("'", "''") & _
                                "','" & strID & "','" & _
                                strlogo & "'," & intOrdreing.ToString & ");"
                db.ExecuteNonQueryFast(strSql)
                intOrdreing += 1
            Next

        End If

        db.ExecuteNonQueryFast("end transaction;")
        db = Nothing
        'ne met à jour le channel.set que si choix des chaines
        If Not (maj_auto_flag) Then
            ecriture_channels_setEPGData()
        End If
    End Sub

    Private Sub parseProgramme(ByVal fichier As String, ByVal RecordCollection As Collection)
        Dim chaineTrouve As Boolean = False
        Dim XmlTvDoc As New XmlDocument()
        XmlTvDoc.Load(fichier)
        Dim elementProgramme As XmlNodeList = XmlTvDoc.DocumentElement.GetElementsByTagName("data")
        Dim noeud As XmlNode
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        db.AttachDatabase(BDDPath & "EPGData.db3", "epgdata")
        db.ExecuteNonQueryFast("begin transaction;")
        For Each noeud In elementProgramme
            chaineTrouve = False
            For Each chaine As String In RecordCollection
                If chaine = noeud.ChildNodes(2).InnerText Then
                    chaineTrouve = True
                    Exit For
                End If
            Next
            If chaineTrouve Then
                pStart_A = noeud.ChildNodes(4).InnerText.Substring(0, noeud.ChildNodes(4).InnerText.Length - 3)
                pStop_A = noeud.ChildNodes(5).InnerText.Substring(0, noeud.ChildNodes(5).InnerText.Length - 3)
                pDiff = 0
                pDuration = CInt(noeud.ChildNodes(7).InnerText)
                PCountry = noeud.ChildNodes(32).InnerText.Replace("'", "''")
                pShowview_A = ""
                pChannel_A = noeud.ChildNodes(2).InnerText
                pClumpidx_A = ""
                pPdcStart_A = ""
                pVpsStart_A = ""
                pVideoplus_A = ""
                pTitle = noeud.ChildNodes(19).InnerText.Replace("'", "''")
                pSubTitle = noeud.ChildNodes(20).InnerText.Replace("'", "''")
                pDescription = noeud.ChildNodes(21).InnerText.Replace("'", "''")
                pCredits = ""
                If noeud.ChildNodes(37).InnerText.Length > 0 Then
                    pActor = "/" & noeud.ChildNodes(37).InnerText.Replace(" - ", "/").Replace("'", "''")
                Else
                    pActor = ""
                End If
                pDirector = noeud.ChildNodes(36).InnerText.Replace("'", "''")
                pWriter = ""
                If noeud.ChildNodes(34).InnerText.Length > 2 Then
                    PPresent = noeud.ChildNodes(34).InnerText.Replace("'", "''").Substring(noeud.ChildNodes(34).InnerText.LastIndexOf(":", StringComparison.CurrentCulture) + 1).Trim
                Else
                    PPresent = noeud.ChildNodes(34).InnerText.Replace("'", "''")
                End If
                PRating = noeud.ChildNodes(16).InnerText
                pIconRating = ""

                If noeud.ChildNodes(30).InnerText <> "0" Then
                    PStarRating = noeud.ChildNodes(30).InnerText & "/5"
                Else
                    PStarRating = ""
                End If

                pStarIconRating = " "
                pPremiere = 0
                If noeud.ChildNodes(29).InnerText.Length = 1 Then
                    pVideoAspect = "16:9"
                Else
                    pVideoAspect = "4:3"
                End If

                PVideoColor = Not CBool(noeud.ChildNodes(11).InnerText)
                If noeud.ChildNodes(28).InnerText = "1" Then
                    PAudioStereo = "dolby"
                ElseIf noeud.ChildNodes(27).InnerText = "1" Then
                    PAudioStereo = "stereo"
                Else
                    PAudioStereo = "mono"
                End If
                PSubType = 0
                PLanguage = ""
                pDate = noeud.ChildNodes(33).InnerText
                pCategory = noeud.ChildNodes(10).InnerText.Replace("'", "''")
                pCategoryTV = noeud.ChildNodes(25).InnerText
                PReview = ""
                textAttrib = ""

                Dim strSql2 As String = ""
                strSql2 = _
                    "insert into ProgramTbl(ChannelID, PTitle, PSubTitle, PIndex, PDiff, PStart, PStop, " & _
                    "PDuration, Pcountry, PcategoryTV, PCategory, Pdate, PDescription, PReview, PActors, PDirectors, " & _
                    "PWriters, PPresents, PIconSR, PRating, Pstar, Premiere, VideoAspect, VideoColour, AudioStereo, Language, " & _
                    "Subtype, ShowView) values ('" & _
                    pChannel_A & "' , '" & pTitle & "' , '" & _
                    pSubTitle & "' , " & PIndex & " , " & pDiff & _
                    " , '" & pStart_A & "' , '" & pStop_A & "' , " & _
                    pDuration & " , '" & _
                    PCountry & "' , " & _
                    "(select category.name from epgdata.category where epgdata.category.id='" & pCategory & "') , " & _
                    "(select genre.name from epgdata.genre where epgdata.genre.id='" & pCategoryTV & "'), '" & _
                    pDate & "' , '" & _
                    pDescription & "', '" & PReview & "' , '" & _
                    pActor & "' , '" & pDirector & "' , '" & _
                    pWriter.Replace("'", "''") & "', '" & _
                    PPresent & "' , '" & pIconRating & "' , '" & PRating & "' , '" & PStarRating & _
                    "' , " & _
                    pPremiere & " , '" & pVideoAspect & "'  , " & _
                    (CInt(PVideoColor) + 1).ToString & " , '" & PAudioStereo & "' , '" & PLanguage & "' , " & _
                    PSubType & " , '" & _
                    pShowview_A & "' )"

                db.ExecuteNonQueryFast(strSql2)
                PIndex = PIndex + 1
            End If
        Next
        db.ExecuteNonQueryFast("end transaction;")
        db.DetachDatabase("epgdata")
        'supression des doublons, à voir s'il n'y a pas d'autre solution
        db.ExecuteNonQueryFast("delete from programtbl where pindex not in (select min(pindex) from programtbl group by channelid, pstart,pstop)")
        db.CloseDatabase()
        db = Nothing

    End Sub

    Public Function DownloadFileEPGData(ByVal RemoteFilePath As String, ByVal SaveFilePath As String, ByVal TimeOut As Integer, ByVal type As String, _
                              Optional ByVal BlockSize As Integer = 1024, Optional ByVal bMessage As Boolean = True) _
    As Boolean

        Select Case maj_auto_flag
            Case False
                ' FrmMiseajour.ProgressBarMiseaJ.Style = ProgressBarStyle.Continuous

                ' Pour Windows 7 Seulement : Style de la progressbar 
                ' durant le Download en mise à jour manuelle
                If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                    Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                    ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                End If

            Case True
                ' MiseAJourAuto.ProgressBar1.Style = ProgressBarStyle.Continuous

                ' Pour Windows 7 Seulement : Style de la progressbar
                ' durant le Download en mise à jour auto
                If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso TaskbarManager.IsPlatformSupported Then
                    Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                    ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                End If
        End Select

        Dim proxy As String = ""
        Dim wr As HttpWebRequest
        Dim proxyport As Integer
        Dim login As String = ""
        Dim pass As String = ""

        'Try

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
                '        FrmMiseajour.ProgressBarMiseaJ.Style = ProgressBarStyle.Continuous
                '        FrmMiseajour.ProgressBarMiseaJ.Step = BlockSize

                ' Pour Windows 7 Seulement : Style de la progressbar
                ' durant le Download en mise à jour manuelle
                If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                    Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                    ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                End If
            Case True

                '        MiseAJourAuto.ProgressBar1.Style = ProgressBarStyle.Continuous
                '        MiseAJourAuto.ProgressBar1.Step = BlockSize

                '        MiseAJourAuto.autoupdate_title.Text = MiseAJourAuto.Auto_update_operation & " " & _
                '                                              MiseAJourAuto.dwnl_operation
                '        MiseAJourAuto.MiseAJourAuto_Weight.Text = MiseAJourAuto.file_size
                '        MiseAJourAuto.MiseajourAuto_estimated.Text = MiseAJourAuto.remaining_time

                '        MiseAJourAuto.BringToFront()
                '        MiseAJourAuto.ProgressBar1.Refresh()
                '        MiseAJourAuto.Refresh()
                '        MiseAJourAuto.Visible = True

                ' Pour Windows 7 Seulement : Style de la progressbar
                ' durant le Download en mise à jour auto
                If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso TaskbarManager.IsPlatformSupported Then
                    Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                    ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
                End If
        End Select

        wr = DirectCast(HttpWebRequest.Create(RemoteFilePath), HttpWebRequest)
        wr.Timeout = TimeOut
        wr.UserAgent = "ZGuideTV " & My.Application.Info.Version().ToString
        wr.AllowAutoRedirect = True

        If Not (Not login Is Nothing AndAlso String.IsNullOrEmpty(login)) Then
            Dim hcredential As New NetworkCredential(login, pass)
            wr.Credentials = hcredential
        End If
        'Try
        Dim wresp As WebResponse = wr.GetResponse()

        If type.Equals("prog", StringComparison.CurrentCulture) Then
            If wresp.Headers("x-epgdata-packageavailable") <> "1" Then
                MessageBox.Show("Pas de package valide. Abonnement Terminé ?")
                Return False
            End If
            ' MessageBox.Show("Date d'expiration : " & DateAdd("s", CDbl(wresp.Headers("x-epgdata-timeout")), New DateTime(1970, 1, 1).ToString))
            My.Settings.EpgdataExpire = DateAdd("s", CDbl(wresp.Headers("x-epgdata-timeout")), New DateTime(1970, 1, 1))
        End If

        Dim RemoteStream As Stream = wresp.GetResponseStream()

        ' calcul de Poid: la taille du fichier à telecharger
        Dim Poid As Integer = CInt(wresp.ContentLength)
        Trace.WriteLine(DateTime.Now & " taille du fichier à telecharger (kbyte) : " & (Poid / 1000).ToString)

        'Select Case maj_auto_flag ' mise a jour automatique?
        '    Case False
        '        FrmMiseajour.ProgressBarMiseaJ.Maximum = Poid

        '    Case True
        '        MiseAJourAuto.ProgressBar1.Maximum = Poid
        '        MiseAJourAuto.MiseAJourAuto_Weight.Text = MiseAJourAuto.file_size & " " & CInt(Poid / 1024) & _
        '                                                  " Ko"
        '        MiseAJourAuto.ProgressBar1.Refresh()
        'End Select

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
                    '            FrmMiseajour.ProgressBarMiseaJ.Increment(BlockSize)

                    ' Pour Windows 7 Seulement : Mise à jour de la taskbar 
                    ' durant le Download en mise à jour manuelle
                    If _
                    ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                       My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
                        Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                        ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.Indeterminate)
                    End If

                Case True
                    '            MiseAJourAuto.ProgressBar1.Increment(BlockSize)

                    '            ' Pour Windows 7 Seulement : Mise à jour de la taskbar
                    '            ' durant le Download en mise à jour automatique
                    '            If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
                    '            TaskbarManager.IsPlatformSupported Then
                    '                Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
                    '                ZGuideTVTaskbar.SetProgressValue(MiseAJourAuto.ProgressBar1.Value, Poid)
                    '            End If

                    '            If modulo(compteur_block, 25) = 1 Then
                    '                Dim actual_time As Long
                    '                Dim diff_temps As Long
                    '                actual_time = DateTime.Now.Ticks
                    '                Dim diff_size As Long
                    '                Dim vitesse As Double
                    '                Dim temps_estime As Double

                    '                diff_temps = actual_time - start_time
                    '                diff_size = compteur_block * BlockSize
                    '                '07/02/2009
                    '                vitesse = 1024 * (1000 * diff_size / (diff_temps * 1))
                    '                ' en kbyte/sec
                    '                Trace.WriteLine(DateTime.Now & " compteur = " & compteur_block.ToString)
                    '                Trace.WriteLine( _
                    '                                 DateTime.Now & " vitesse = " & vitesse.ToString & " actual-time= " & _
                    '                                 actual_time.ToString & "start time = " & start_time.ToString)
                    '                Trace.WriteLine(DateTime.Now & " diff_temps = " & diff_temps.ToString)

                    '                temps_estime = (Poid - compteur_block * BlockSize) / vitesse
                    '                temps_estime = Math.Max(temps_estime, 0)
                    '                Trace.WriteLine(DateTime.Now & " temps estimé = " & temps_estime.ToString)
                    '                '07/02/2009
                    '                MiseAJourAuto.MiseajourAuto_estimated.Text = MiseAJourAuto.remaining_time & " " & _
                    '                                                             (CInt(temps_estime)).ToString & " sec"
                    '                Trace.WriteLine(" ")
                    '                Thread.Sleep(50)
                    '                MiseAJourAuto.Refresh()

                    '            Else
                    '            End If
            End Select

            iBytesRead = RemoteStream.Read(buff, 0, buff.Length)
            LocalStreamW.Write(buff, 0, iBytesRead)
            compteur_block += 1
        Loop

        'Select Case maj_auto_flag
        '    Case False
        '        FrmMiseajour.ProgressBarMiseaJ.Maximum = 0

        '        ' Pour Windows 7 Seulement : Mise à zéro taskbar
        '        ' durant le Download en mise à jour manuelle
        '        If _
        '            ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
        '            My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False AndAlso TaskbarManager.IsPlatformSupported Then
        '            Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
        '            ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
        '        End If

        '    Case True
        '        MiseAJourAuto.ProgressBar1.Maximum = 0

        '        ' Pour Windows 7 Seulement : Mise à zéro taskbar
        '        ' durant le Download en mise à jour auto
        '        If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
        '        TaskbarManager.IsPlatformSupported Then
        '            Dim ZGuideTVTaskbar As TaskbarManager = TaskbarManager.Instance
        '            ZGuideTVTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
        '        End If
        'End Select

        wresp.Close()
        RemoteStream.Close()
        RemoteStream.Dispose()
        LocalStreamW.Close()
        LocalStream.Close()
        LocalStream.Dispose()

        'Catch ex As Exception
        '    'Select Case maj_auto_flag
        '    '    Case False
        '    '        FrmMiseajour.ProgressBarMiseaJ.Style = ProgressBarStyle.Continuous
        '    '        FrmMiseajour.ProgressBarMiseaJ.Maximum = 0
        '    '        Trace.WriteLine(DateTime.Now & "exception dans downloadfile en maj manuelle")
        '    '        Trace.WriteLine(ex.Message)

        '    '    Case True
        '    '        MiseAJourAuto.ProgressBar1.Maximum = 0
        '    '        MiseAJourAuto.ProgressBar1.Style = ProgressBarStyle.Continuous
        '    '        Trace.WriteLine(DateTime.Now & "exception dans downloadfile en maj automatique")
        '    '        Trace.WriteLine(ex.Message)
        '    'End Select

        '    If bMessage Then

        '        'Dim FenMessage As New FrmMessage(ex.Message, MsgBoxStyle.Critical, True)
        '        'FenMessage.ShowDialog()
        '    End If
        '    Return False
        'End Try
        'Catch ex As Exception
        '    'Dim FenMessage As New FrmMessage("Proxy error", "Erreur de gestion proxy", MsgBoxStyle.Critical, True)
        '    'FenMessage.ShowDialog()
        '    Return False
        'End Try

        Return True
    End Function

    Public Sub downloadMT()
        Dim pin As String = My.Settings.PinEpgdata
        Dim offset As String = "1" 'decalage par rapport à aujourd'hui
        Dim baseURl As String = "http://www.epgdata.com/index.php?action=sendPackage&iOEM=&pin="
        'Dim url As String ' = baseURl & pin & "&dayOffset=" & offset & "&dataType=xml"
        Dim listthread As New Collection()

        Dim XMLPurge() As String
        XMLPurge = Directory.GetFiles(TempPath, "*.zip")
        Dim i As Integer = 0
        Do While i < XMLPurge.Length
            File.Delete(XMLPurge(i))
            i = i + 1
        Loop
        Dim titi As DateTime = DateTime.Now

        'on ne peut télécharger que deux fichiers en même temps
        'limitation du site www.epgdata.com ???

        'premier thread
        offset = "0"
        url2 = baseURl & pin & "&dayOffset=" & offset & "&dataType=xml"
        temp2 = "temp_programme" & "0" & ".zip"
        Dim t1 As Thread = New Thread(AddressOf Download)
        t1.Priority = ThreadPriority.BelowNormal

        t1.Start()
        listthread.Add(t1)
        Dim tbInfoDownload As TextBox
        If maj_auto_flag Then
            tbInfoDownload = miseajourautoEPGDATA.tbInfo
        Else
            tbInfoDownload = MiseajourEPGData.tbInfo
        End If
        tbInfoDownload.Text = tbInfoDownload.Text & Telechargement & " 0" & Environment.NewLine

        If nombreDownload >= 2 Then
            Application.DoEvents()
            'Thread.Sleep(10000) 'initialisation d'un décalage entre les thread de temps entre le premier et le second thread
            'second thread
            offset = "1"
            url2 = baseURl & pin & "&dayOffset=" & offset & "&dataType=xml"
            temp2 = "temp_programme" & offset & ".zip"
            Dim t2 As Thread = New Thread(AddressOf Download)
            t2.Priority = ThreadPriority.BelowNormal
            t2.Start()
            listthread.Add(t2)
            tbInfoDownload.Text = tbInfoDownload.Text & Telechargement & " 1" & Environment.NewLine
            If nombreDownload >= 3 Then
                'troisieme thread
                t1.Join() 'attend que le premier thread s'arrete
                offset = "2"
                url2 = baseURl & pin & "&dayOffset=" & offset & "&dataType=xml"
                temp2 = "temp_programme" & offset & ".zip"
                Dim t3 As Thread = New Thread(AddressOf Download)
                t3.Priority = ThreadPriority.BelowNormal
                t3.Start()
                listthread.Add(t3)
                tbInfoDownload.Text = tbInfoDownload.Text & Telechargement & " 2" & Environment.NewLine
                If nombreDownload >= 4 Then
                    'quatrième thread
                    t2.Join() 'attend que le deuxieme thread s'arrete
                    offset = "3"
                    url2 = baseURl & pin & "&dayOffset=" & offset & "&dataType=xml"
                    temp2 = "temp_programme" & offset & ".zip"
                    Dim t4 As Thread = New Thread(AddressOf Download)
                    t4.Priority = ThreadPriority.BelowNormal
                    t4.Start()
                    listthread.Add(t4)
                    tbInfoDownload.Text = tbInfoDownload.Text & Telechargement & " 3" & Environment.NewLine
                    If nombreDownload >= 5 Then
                        'cinquième thread
                        t3.Join() 'attend que le troisieme thread s'arrete
                        offset = "4"
                        url2 = baseURl & pin & "&dayOffset=" & offset & "&dataType=xml"
                        temp2 = "temp_programme" & offset & ".zip"
                        Dim t5 As Thread = New Thread(AddressOf Download)
                        t5.Priority = ThreadPriority.BelowNormal
                        t5.Start()
                        listthread.Add(t5)
                        tbInfoDownload.Text = tbInfoDownload.Text & Telechargement & " 4" & Environment.NewLine
                        If nombreDownload >= 6 Then
                            'sixieme thread
                            t4.Join() 'attend que quatrième thread s'arrete
                            offset = "5"
                            url2 = baseURl & pin & "&dayOffset=" & offset & "&dataType=xml"
                            temp2 = "temp_programme" & offset & ".zip"
                            Dim t6 As Thread = New Thread(AddressOf Download)
                            t6.Priority = ThreadPriority.BelowNormal
                            t6.Start()
                            listthread.Add(t6)
                            tbInfoDownload.Text = tbInfoDownload.Text & Telechargement & " 5" & Environment.NewLine
                            If nombreDownload = 7 Then
                                'septieme thread
                                t5.Join() '    attend que le cinquieme thread s'arrete
                                offset = "6"
                                url2 = baseURl & pin & "&dayOffset=" & offset & "&dataType=xml"
                                temp2 = "temp_programme" & offset & ".zip"
                                Dim t7 As Thread = New Thread(AddressOf Download)
                                t7.Priority = ThreadPriority.BelowNormal
                                t7.Start()
                                listthread.Add(t7)
                                tbInfoDownload.Text = tbInfoDownload.Text & Telechargement & " 6" & Environment.NewLine
                            End If
                        End If
                    End If
                End If
            End If
        End If
        'End If
        'on s'assure que l'on attend la fin de tous les threads
        For Each objThread As Object In listthread
            DirectCast(objThread, Thread).Join()
        Next
        Application.DoEvents()
        'Thread.Sleep(10000) ' un peu d'attente si il y a un l'antivirus
        traitementEPGDataMT()
        'MessageBox.Show("temps d'éxécurion : " & DateDiff(DateInterval.Second, titi, DateTime.Now).ToString & " secondes")
    End Sub

    Public Sub Download()
        DownloadFileEPGData(url2, TempPath & temp2, 20000, "prog", 1024, False)
    End Sub

    Public Sub downloadChannel()
        Dim pin As String = My.Settings.PinEpgdata
        Dim baseURl As String = "http://www.epgdata.com/index.php?action=sendInclude&iOEM=&pin="
        Dim url As String = baseURl & pin & "&dataType=xml"

        XmlTvName = TempPath & "Temp_includes.zip"

        Dim XMLPurge() As String
        XMLPurge = Directory.GetFiles(TempPath, "*.zip")
        Dim i As Integer = 0
        Do While i < XMLPurge.Length
            File.Delete(XMLPurge(i))
            i = i + 1
        Loop

        DownloadFileEPGData(url, XmlTvName, 20000, "inc", 1024, False)

        ParseInclude()
    End Sub

    Public Sub ecriture_channels_setEPGData()
        Dim SW As New StreamWriter(ChannelSetPath & "\" & "ZGuideTVDotNet.channels.set")
        Dim nombredechaineselectionnees As Integer

        ' 'On déclare les variables
        Dim Save_Listview As String = ""
        Dim itm As New ListViewItem
        Try
            For Each itm In MiseajourEPGData.ListXMLTVFRChoisie.Items ' Boucle sur le nombre d'items dans la ListView
                'If FrmMiseajour.collectionChannels.Contains(itm.Text) Then
                '    arrayOnechannel = DirectCast(frmMiseajourEPGData.collectionChannels.Item(itm.Text), String())
                'Save_Listview = Save_Listview & _
                '                (arrayOnechannel(0) & ("|") & arrayOnechannel(1) & ("|") & arrayOnechannel(2) & _
                '                 ("|"))
                Dim strlogo As String = DirectCast(itm.Tag, String())(1)
                Dim strID As String = DirectCast(itm.Tag, String())(0)

                Save_Listview = Save_Listview & strID & "|" & itm.Text & "|" & strlogo & "|"
                SW.WriteLine(Save_Listview)
                ' Ecrit dans le fichier le contenu de la variable Save_Listview

                Save_Listview = ""
                ' Remplacement du contenu de Save_Listview par une chaîne vide

                'End If

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
End Module
