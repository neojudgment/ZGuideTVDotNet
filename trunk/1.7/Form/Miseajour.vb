' ��������������������������������������������������������������������������������������������������������������
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
' ��������������������������������������������������������������������������������������������������������������

#Region "Imports"

Imports System.ComponentModel
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports ZGuideTV.SQLiteWrapper

#End Region

' ReSharper disable CheckNamespace
Public Class Miseajour
    ' ReSharper restore CheckNamespace

#Region "Property"

    Private _memoListViewItem As List(Of ListViewItem)
    Public ButtonToutClick As String
    Public ReadOnly CollectionChannels As New Collection
    Public ReadOnly CollectionSelectChannels As New Collection
    Private Const NomFichierUrl As String = "ZGuideTVDotNet.url.set"
    Private ReadOnly _tableTypeUrl(100) As String
    Private ReadOnly _tableUrlUrl(100) As String
    Private _serveurUrl As String = "http://www.zguidetv.net/"
    Private _listDraged As String = ""
    Public MessageBoxUrlChecked As String
    Public MessageBoxUrlChecked1 As String
    Public MessageBoxUrlCheckedTitre As String
    Public MessageBoxFileNotExist As String
    Public MessageBoxFileNotExist1 As String
    Public MessageBoxFileNotExistTitre As String
    Public MessageBoxDirChecked As String
    Public MessageBoxDirChecked1 As String
    Public MessageBoxDirCheckedTitre As String
    Public ErrorInChannelListRecovery As String
    Public InvalidUrl As String
    Public UntraceableFile As String
    Public ErrorInUpdate As String
    Public ErrorInXmlCopy As String
    Public ErrorInFileCopy As String
    Public ErrorInUnzip As String
    Public WrongFileName As String
    Public FailUrlFileDownload As String
    Public UntraceableUrlListFile As String
    Public TheFile As String
    Public DontExist As String
    Public ProtectedFile As String
    Public ChosenChannels As String
    Public AvailableChannels As String
    Public MessageBoxListXmltvfrChoisie As String
    Public MessageBoxListXmltvfrChoisie1 As String
    Public MessageBoxListXmltvfrChoisieTitre As String
    Public MessageBoxMiseaJourDone As String
    Public MessageBoxMiseaJour1Done As String
    Public MessageBoxMiseaJourTitreDone As String

#End Region

    Private ReadOnly _os As OperatingSystem = Environment.OSVersion

    Private Function CreerLogo(nomlogo As String) As String

        ' variable contenant la chaine qui sera �crit dans le logo
        Dim chainedanslogo As String = nomlogo.ToUpper.Substring(0, nomlogo.IndexOf(".", StringComparison.Ordinal))

        ' pour les noms de chaine contenant un caract�re interdit dans un nom de fichier on renvoie "vide.gif"
        Dim invalidFileNameChars() As Char = Path.GetInvalidFileNameChars()
        If _
            invalidFileNameChars.Any(
                Function(invalidFileNameChar) nomlogo.Contains(invalidFileNameChar.ToString(CultureInfo.CurrentCulture))) _
            Then
            Return "vide.gif"
        End If

        ' Si la chaine est top longue pour �tre enti�rement dans le logo, on ins�re un saut de ligne
        With chainedanslogo
            If .Length > 7 Then

                ' test pour savoir si les dernier caracteres sont des chiffres
                Dim testChiffre As Match = Regex.Match(chainedanslogo, "\d+$")

                ' r�gle de d�coupage si les dernier caracteres sont des chiffres
                If testChiffre.Success Then
                    chainedanslogo = .Substring(0, testChiffre.Index) & vbCrLf & testChiffre.Value

                    ' r�gle de d�coupage si le nom contient "HD"
                ElseIf .IndexOf("HD", StringComparison.CurrentCulture) > 0 Then
                    chainedanslogo = .Replace("HD", vbCrLf & "HD")

                    ' r�gle de d�coupage si le nom contient "PLUS"
                ElseIf .IndexOf("PLUS", StringComparison.CurrentCulture) > 0 Then
                    chainedanslogo = .Replace("PLUS", "+" & vbCrLf)

                    ' r�gle de d�coupage si le nom contient "PARIS"
                ElseIf .IndexOf("PARIS", StringComparison.CurrentCulture) >= 0 Then
                    chainedanslogo = .Replace("PARIS", "PARIS" & vbCrLf)

                    ' ici on peut ins�rer d'autre r�gles de d�coupage
                    ' sinon d�coupage � la hache
                Else
                    chainedanslogo = .Substring(0, 7) & vbCrLf &
                                     .Substring(7, .Length - 8)
                End If
            End If
        End With

        ' creation du logo et renvoi du nom du logo
        Dim objBitmap As Bitmap = New Bitmap(132, 99)
        Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
        Try
            objGraphics.Clear(Color.White)
            objGraphics.DrawString(chainedanslogo, New Font("Arial", 18, FontStyle.Bold), Brushes.Black, 0, 25)
            objBitmap.Save(LogosPath & nomlogo, ImageFormat.Gif)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return nomlogo
    End Function

    Private Structure ChannelList
        Public Name As String
        Public Id As String
        Public Logo As String

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Private ReadOnly _originalList(1000) As ChannelList
    Private ReadOnly _nbChannels As Integer = -1
    Public ReadOnly ImageListSmall As New ImageList()

    Public XmlTvDoc As XmlDocument = New XmlDocument()

    Public Sub ParseXmlChannels(pathXml As String)

        ' Y a t il des erreurs a signaler au programme appelant?
        Dim elementChannel As XmlNodeList
        Dim noeud, noeudEnf As XmlNode
        Dim channelId As String
        Dim channelName As String = Nothing
        Dim logoFilename As String = Nothing
        Dim icountChannels As Integer
        Dim chaineDoublon As Integer
        Dim channelRen As String = Nothing
        Dim newList(1000) As ChannelList
        Dim i As Integer

        Trace.WriteLine(DateTime.Now & " Chargement des Cha�nes dans frmmiseajour")
        ImageListSmall.ImageSize = New Size(38, 29)

        Try
            CollectionSelectChannels.Clear()
            CollectionChannels.Clear()
            Trace.WriteLine(DateTime.Now & " " & pathXml)
            XmlTvDoc.Load(pathXml)

            elementChannel = XmlTvDoc.DocumentElement.GetElementsByTagName("channel")
            ListViewAllChannel.Columns.Add(AvailableChannels & elementChannel.Count & ")", -2,
                                           HorizontalAlignment.Left)
            ListViewAllChannel.Columns.Item(0).Width = ListViewAllChannel.Width - 22

            For Each noeud In elementChannel
                channelId = noeud.Attributes(0).Value
                ArrayOnechannel(0) = channelId
                Dim listViewMyItem As New ListViewItem
                Dim bPass�Dans As Boolean = False
                For Each noeudEnf In noeud.ChildNodes
                    Select Case noeudEnf.LocalName.ToLower
                        Case "display-name"
                            If Not bPass�Dans Then
                                bPass�Dans = True

                                channelName = noeudEnf.InnerText

                                'rvs75 le 29/12/2010 : r��criture du changement de nom de chaines si doublons
                                Dim testNomChannel As String = channelName
                                chaineDoublon = 0
                                While CollectionChannels.Contains(testNomChannel)
                                    If chaineDoublon = 0 Then
                                        testNomChannel = channelName & "(bis)"
                                    Else
                                        testNomChannel = channelName & "(bis" & chaineDoublon.ToString & ")"
                                    End If
                                    chaineDoublon += 1
                                End While
                                channelName = testNomChannel
                                i += 1

                                ' Modifi� le 05/09/2009 rvs75
                                channelRen = channelName
                                Dim invalidFileNameChars() As Char = Path.GetInvalidFileNameChars()
                                For Each invalidFileNameChar As Char In invalidFileNameChars
                                    If channelRen.Contains(invalidFileNameChar.ToString(CultureInfo.CurrentCulture)) _
                                        Then
                                        channelRen = channelRen.Replace(invalidFileNameChar.ToString, "")
                                    End If
                                Next

                                ' Modifi� le 10/09/2009 rvs75
                                listViewMyItem.Text = channelName.ToString
                                listViewMyItem.SubItems.Add("")
                                ListViewAllChannel.Items.Add(listViewMyItem)

                                ' comptage des noeuds enfants qui ont un tag "icon"
                                Dim cptIcon As Integer = 0
                                For t As Integer = 0 To noeud.ChildNodes.Count - 1
                                    If _
                                        [String].Equals(noeud.ChildNodes.ItemOf(t).Name, "icon",
                                                        StringComparison.CurrentCulture) Then
                                        cptIcon += 1
                                    End If
                                Next

                                ' choix si il y a ou pas un noeud enfant "icon"
                                Select Case cptIcon
                                    Case 0

                                        ' rvs 03/11/2009 tous le code ici a �t� externaliser dans la function "Recherche_logo
                                        ' afin de pouvoir �tre r�utiliser si 'il y a un noeud enfant "icon"
                                        ArrayOnechannel(2) = RechercherLogo(channelRen)
                                End Select
                            End If

                        Case Else
                            If ([String].Equals(noeudEnf.LocalName, "icon", StringComparison.CurrentCulture)) Then
                                Dim entree As String
                                Dim posPoint As Integer
                                Dim posSlash As Integer
                                Dim s2 As String
                                entree = noeudEnf.OuterXml
                                posPoint = entree.LastIndexOf(".", StringComparison.CurrentCulture)
                                s2 = entree.Substring(0, posPoint + 4)

                                ' fichier type .jpg ou .gif ou .xxx
                                posSlash = s2.LastIndexOf("/", StringComparison.CurrentCulture)
                                logoFilename = s2.Substring(posSlash + 1, s2.Length - posSlash - 1)

                                ArrayOnechannel(2) = RechercherLogo(channelRen)
                            End If
                    End Select
                    With newList(i - 1)
                        .Id = channelId
                        .Name = channelName.ToString
                        .Logo = logoFilename
                    End With
                Next noeudEnf

                ArrayOnechannel(1) = channelName
                CollectionChannels.Add(ArrayOnechannel, ArrayOnechannel(1))
                ReDim Preserve ArrayOnechannel(2)
                listViewMyItem.ImageIndex = icountChannels
                ListViewAllChannel.SmallImageList = ImageListSmall
                icountChannels += 1
            Next noeud

            i = 0
            Try
                With ListXMLTVFRChoisie
                    .Clear()
                    .Columns.Add(ChosenChannels & .Items.Count & ")", -2,
                                 HorizontalAlignment.Left)
                    .Columns.Item(0).Width = .Width - 22
                End With

                Dim bTrouve As Boolean = False
                Dim j As Integer
                Dim k As Integer

                Do While i <= _nbChannels
                    j = 0
                    Do While j <= icountChannels AndAlso Not bTrouve
                        bTrouve = ([String].Equals(newList(j).Id, _originalList(i).Id, StringComparison.CurrentCulture))
                        j += 1

                    Loop
                    i += 1
                    If bTrouve Then
                        bTrouve = False

                        Dim itmListXmltvfrChoisie As New ListViewItem

                        With itmListXmltvfrChoisie
                            .Text = ListViewAllChannel.Items.Item(j - 1).Text
                            .SubItems.Add("")
                            ListXMLTVFRChoisie.Items.Add(itmListXmltvfrChoisie)
                            .ImageIndex = ListViewAllChannel.Items(j - 1).ImageIndex
                        End With
                    End If
                Loop

                ' Supression des cha�nes pr�s�lectionn� de la liste
                ' ListViewAllChannel
                i = 0
                Do While i <= _nbChannels
                    k = 0
                    j = -1
                    Do While j <= icountChannels AndAlso Not bTrouve
                        j += 1
                        bTrouve = ([String].Equals(newList(j).Id, _originalList(i).Id, StringComparison.CurrentCulture))
                        If _
                            Not [String].Equals(newList(j).Id, "****-1****", StringComparison.CurrentCulture) AndAlso
                            Not bTrouve Then
                            k += 1
                        End If
                    Loop
                    i += 1
                    If bTrouve Then
                        bTrouve = False
                        If k <= ListViewAllChannel.Items.Count Then
                            ListViewAllChannel.Items(k).Remove()
                            newList(j).Id = "****-1****"
                        End If

                    End If
                Loop

                With ListXMLTVFRChoisie
                    .SmallImageList = ImageListSmall
                    ListViewAllChannel.Sorting = SortOrder.Ascending
                    .Columns.Item(0).Text = ChosenChannels & .Items.Count & ")"
                End With

                If ListXMLTVFRChoisie.Items.Count > 0 Then
                    ButtonAppliquer.Location = ButtonDemarrer.Location
                    ButtonDemarrer.Visible = False
                    ButtonAppliquer.Visible = True
                    AcceptButton = ButtonAppliquer
                End If

            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & ex.Message)
            End Try

            ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & ")"

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " Erreur lors de la r�cup�ration de la liste des chaines dans frmmiseajour")
            Trace.WriteLine(DateTime.Now & " " & ex.Message)
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)

            ' ReSharper disable NotAccessedVariable
            Dim boxErrorInChannelListRecovery As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxErrorInChannelListRecovery = MessageBox.Show _
                (ErrorInChannelListRecovery & Chr(13),
                 ErrorInChannelListRecovery, MessageBoxButtons.OK, MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    ' CreateMyListView
    Private Sub ButtonOpenfileClick(sender As Object, e As EventArgs) Handles ButtonOpenfile.Click
        OpenFileDialogXml.ShowDialog()
        If (TextBoxPathXml.Text.Trim(" "c).Length) > 0 Then '02/10/07
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub FrmMiseajour_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles Me.FormClosing

        ImageListSmall.Images.Clear()

        ' On efface les r�sidus des fichiers xml et zip t�l�charg�s ou pars�s dans C:\ProgramData\ZGuideTVDotNet
        If Directory.Exists(AppData) Then
            If Not Directory.GetDirectories(AppData) Is Nothing Then
                For Each myXml As String In Directory.GetFiles(AppData, "*.xml")
                    File.Delete(myXml)
                Next
                For Each myZip As String In Directory.GetFiles(AppData, "*.zip")
                    File.Delete(myZip)
                Next
            End If
        End If

        If Not Mainform.NoDatabaseOnStart AndAlso Not Mainform.DataBaseIsExpired Then
            Mainform.Timer_minute.Start()
        Else
            Mainform.Timer_minute.Stop()
        End If
    End Sub

    Private Sub FrmMiseajourLoad(sender As Object, e As EventArgs) Handles Me.Load

        Trace.WriteLine(DateTime.Now & " " & "entree dans frm mise a jour Load")

        AcceptButton = ButtonDemarrer

        TxbRecherchechaine()

        If _
            ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6) Then

            CheckBoxAutoRestartManualUpdate.Enabled = True
        End If

        ImageListSmall.Images.Clear()

        If My.Settings.AutoRestartManualUpdate Then
            CheckBoxAutoRestartManualUpdate.Checked = True
        End If

        If Not My.Settings.UrlUpdate Then
            ButtonEdit.Enabled = True
        End If

        Try
            ' On regarde quel langue utiliser 22/08/2008
            LanguageCheck(7)
            'Mainform.lbl_titre_maintenant.Text = MaintenantEtHeure
        Catch ex As ArgumentOutOfRangeException
            Trace.WriteLine(ex.Message)
            Trace.WriteLine(DateTime.Now & " Frm mise a jour plante a l'appel de language Check")
        End Try

        ' 14/01/2009 On va lire le dernier chemin utilis� sur le disque dur
        XmlTvName = My.Settings.Cheminmiseajour

        TextBoxPathXml.Text = XmlTvName.ToString

        If (TextBoxPathXml.Text.Trim(" "c).Length) > 0 Then

            ButtonDemarrer.Enabled = True
        End If

        ' N�o le 14/04/08
        ButtonToutClick = ""
        Mainform.Timer_minute.Stop()

        ' Mise � jour de la liste des liens automatiques (urlb.set)
        If My.Settings.UrlUpdate Then
            If DownloadFile(_serveurUrl & NomFichierUrl, UrlPath & NomFichierUrl & ".Tmp", 5000, 1024, False) Then
                CopierFichier(UrlPath & NomFichierUrl & ".Tmp", UrlPath & NomFichierUrl, True)
                Dim tmpFile() As String
                tmpFile = Directory.GetFiles(UrlPath, NomFichierUrl & ".Tmp")
                Dim i As Integer = 0
                Do While i < tmpFile.Length
                    File.Delete(tmpFile(i))
                    i += 1
                Loop

                RemplirUrlCombo()
            Else
                RemplirUrlCombo()
            End If

        Else
            RemplirUrlCombo()
        End If

        Trace.WriteLine(DateTime.Now & " " & "sortie de frm mise a jour Load")
    End Sub

    Private Sub ButtonAnnulerClick(sender As Object, e As EventArgs) Handles ButtonAnnuler.Click

        Close()
    End Sub

    Private Sub OpenFileDialogXmlFileOk(sender As Object, e As CancelEventArgs) _
        Handles OpenFileDialogXml.FileOk

        XmlTvName = OpenFileDialogXml.FileName
        TextBoxPathXml.Text = XmlTvName.ToString
    End Sub

    Private Sub ButtonDemarrerClick(sender As Object, e As EventArgs) Handles ButtonDemarrer.Click

        ' N�o 22/01/2012
        ' Le fichier de mise � jour sur le disque dur n'existe pas
        If RadioButtonXmlPath.Checked Then

            ' N�o 19/07/2015
            If Not TextBoxPathXml.Text.Equals(String.Empty) Then
                Dim attrib As Integer
                Dim attributs As Integer
                Try
                    attributs = File.GetAttributes(TextBoxPathXml.Text)
                    If attributs = 32 Then
                        attrib = 1
                    End If

                    If attributs = 128 Then
                        attrib = 1
                    End If
                Catch ex As Exception
                    attrib = 1
                End Try

                If _
                   Not File.Exists(TextBoxPathXml.Text) Then
                    attrib = 1
                End If

                If attrib <> 1 Then
                    ' ReSharper disable NotAccessedVariable
                    Dim boxFileNotExist As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxFileNotExist = MessageBox.Show _
                        (New Form() With {.TopMost = True}, MessageBoxFileNotExist & Chr(13) & MessageBoxFileNotExist1,
                         MessageBoxFileNotExistTitre, MessageBoxButtons.OK, MessageBoxIcon.Information,
                         MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            End If

            'If _
            '       Not File.Exists(TextBoxPathXml.Text) Then

            '    ' ReSharper disable NotAccessedVariable
            '    Dim boxFileNotExist As DialogResult
            '    ' ReSharper restore NotAccessedVariable
            '    boxFileNotExist = MessageBox.Show _
            '        (New Form() With {.TopMost = True}, MessageBoxFileNotExist & Chr(13) & MessageBoxFileNotExist1,
            '         MessageBoxFileNotExistTitre, MessageBoxButtons.OK, MessageBoxIcon.Information,
            '         MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If
        End If
        CheckBoxAutoRestartManualUpdate.Enabled = False
        ButtonDemarrer.Enabled = False

        ' Ajout de Ronaldo1 le 08/01/2008
        ' On teste si on a choisie une URL pour �viter que cela plante
        If URLComboBox.SelectedIndex > 0 AndAlso RadioButtonDownload.Checked Then
            _serveurUrl = _tableUrlUrl(URLComboBox.SelectedIndex)

            ' Ajout de N�o le 24/06/2013
            ' On teste l'URL est accessible pour �viter que cela plante
            Dim myUri As New Uri(_serveurUrl)
            Dim baseUri As String = myUri.GetLeftPart(UriPartial.Authority)

            If My.Computer.Network.IsAvailable Then
                If Not ConnectionAvailable(baseUri) Then

                    ' ReSharper disable NotAccessedVariable
                    Dim boxNoConnection As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxNoConnection =
                        MessageBox.Show(New Form() With {.TopMost = True},
                                        Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1,
                                        Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation)
                    ButtonDemarrer.Enabled = True
                    Exit Sub
                End If
            Else
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(New Form() With {.TopMost = True},
                                    Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1,
                                    Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                ButtonDemarrer.Enabled = True
                Exit Sub
            End If

            ' 14/01/2009 On sauvegarde l'�tat des radio button et le chemin de l'URL
            With My.Settings
                .URLChecked = True
                .DIRChecked = False
                .Lienmiseajour = _serveurUrl
            End With
            My.Settings.Save()

            ' 05/07/2011 Sinon on sauvegarde l'�tat des radio button et le chemin sur le dd
        Else
            With My.Settings
                .URLChecked = False
                .DIRChecked = True
                .Cheminmiseajour = TextBoxPathXml.Text
            End With
        End If

        ' lit le fichier xml pour charger les chaines,les logos
        Dim extention As String
        Dim fileName As String
        Dim filename2 As String

        Dim xmlaT�l�charger As String

        With ListViewAllChannel.Columns
            If .Count > 0 Then
                .RemoveAt(0)
            End If
        End With

        ListViewAllChannel.Items.Clear()
        Dim bError As Boolean = False
        Mainform.ToolStripAutoUpdate.Enabled = True

        ' Si l'utilisateur s�lectionne le t�l�chargement ...
        If Not RadioButtonXmlPath.Checked Then
            xmlaT�l�charger = _serveurUrl
            xmlaT�l�charger = xmlaT�l�charger.Trim(" "c)

            ' on extrait le nom du fichier et son extension
            Try
                extention = xmlaT�l�charger.Substring(xmlaT�l�charger.LastIndexOf(Chr(46)) + 1)
                fileName = xmlaT�l�charger.Substring(xmlaT�l�charger.LastIndexOf(Chr(47)) + 1)
                filename2 = fileName.Remove(fileName.IndexOf(Chr(46)))
                extention = extention.ToUpper
            Catch ex As Exception

                ' Si il y a une erreur c'est que l'URL est invalide
                bError = True
                ButtonDemarrer.Visible = True
                ButtonDemarrer.Enabled = True

                ' ReSharper disable NotAccessedVariable
                Dim boxInvalidUrl As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxInvalidUrl = MessageBox.Show _
                    (New Form() With {.TopMost = True}, InvalidUrl & Chr(13),
                     ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try

            If Not bError Then

                ' on t�l�charge le fichier dans le appdata
                If DownloadFile(xmlaT�l�charger, AppData & fileName, 100000) Then
                    XmlTvName = AppData & fileName
                Else

                    ' ReSharper disable NotAccessedVariable
                    Dim boxUntraceableFile As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxUntraceableFile = MessageBox.Show _
                        (New Form() With {.TopMost = True}, UntraceableFile & Chr(13),
                         ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error,
                         MessageBoxDefaultButton.Button1)

                    bError = True
                    ButtonDemarrer.Visible = True
                    ButtonDemarrer.Enabled = True
                End If
            End If

        Else
            Try
                extention = XmlTvName.Substring(XmlTvName.LastIndexOf(Chr(46)) + 1)
                fileName = XmlTvName.Substring(XmlTvName.LastIndexOf(Chr(92)) + 1)
                filename2 = fileName.Remove(fileName.IndexOf(Chr(46)))
                extention = extention.ToUpper
            Catch ex As Exception
                bError = True
                ButtonDemarrer.Visible = True
                ButtonDemarrer.Enabled = True
                Return
            End Try
        End If

        FichierProgramme = AppData & filename2 & ".xml"
        If Not bError Then
            Try
                If XmlTvName.Length > 0 Then

                    ' si le fichier n'est pas compress� on le copie dans le appdata et on le renomme prog.xml
                    Select Case extention
                        Case "XML"
                            If CopierFichier(XmlTvName, FichierProgramme, True) Then
                                ParseXmlChannels(FichierProgramme)
                            Else
                                ' ReSharper disable NotAccessedVariable
                                Dim boxErrorInUpdate As DialogResult
                                ' ReSharper restore NotAccessedVariable
                                boxErrorInUpdate = MessageBox.Show _
                                    (New Form() With {.TopMost = True}, ErrorInXmlCopy & Chr(13),
                                     ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                     MessageBoxDefaultButton.Button1)
                            End If
                        Case "GZ"
                            Try
                                ' Rajout de Ronaldo1 03/11/2007
                                Dim xmlPurge() As String
                                xmlPurge = Directory.GetFiles(AppData, "*.XML")
                                Dim i As Integer = 0
                                Do While i < xmlPurge.Length
                                    File.Delete(xmlPurge(i))
                                    i += 1
                                Loop


                                Try
                                    'd�compression GZ
                                    Using fichiercompresse As FileStream = New FileInfo(XmlTvName).OpenRead()
                                        Using fichierxml As FileStream = File.Create(FichierProgramme)
                                            Using DecompressionGZ As GZipStream = New GZipStream(fichiercompresse, CompressionMode.Decompress)
                                                DecompressionGZ.CopyTo(fichierxml)
                                            End Using
                                        End Using
                                    End Using

                                Catch ex As Exception
                                    MessageBox.Show(New Form() With {.TopMost = True}, ex.Message, "Exception")
                                    Trace.WriteLine(
                                            DateTime.Now &
                                            "Erreur lors de la d�compression du fichier avec 7-zip dans frmMiseajour.vb")
                                End Try

                                ParseXmlChannels(FichierProgramme)

                            Catch ex As Exception

                            End Try
                        Case Else
                            If CopierFichier(XmlTvName, AppData & fileName, True) Then
                                Try

                                    ' Rajout de Ronaldo1 03/11/2007
                                    Dim xmlPurge() As String
                                    xmlPurge = Directory.GetFiles(AppData, "*.XML")
                                    Dim i As Integer = 0
                                    Do While i < xmlPurge.Length
                                        File.Delete(xmlPurge(i))
                                        i += 1
                                    Loop

                                    Try
                                        ' on d�compresse le fichier zip. Modifi� par N�o le 08/07/2014
                                        ZipFile.ExtractToDirectory(XmlTvName, AppData)

                                    Catch ex As Exception
                                        MessageBox.Show(New Form() With {.TopMost = True}, ex.Message, "Exception")
                                        Trace.WriteLine(
                                            DateTime.Now &
                                            "Erreur lors de la d�compression du fichier avec 7-zip dans frmMiseajour.vb")
                                    End Try

                                    Dim xmlFile() As String = Directory.GetFiles(AppData, "*.XML")

                                    If xmlFile.Length > 0 Then
                                        XmlTvName = xmlFile(0)
                                        FichierProgramme = XmlTvName

                                        ' � corriger si n�cessaire par Ronaldo
                                        ParseXmlChannels(XmlTvName)
                                    Else
                                        ' ReSharper disable NotAccessedVariable
                                        Dim boxErrorInUpdate As DialogResult
                                        ' ReSharper restore NotAccessedVariable
                                        boxErrorInUpdate = MessageBox.Show _
                                            (New Form() With {.TopMost = True}, ErrorInFileCopy & Chr(13),
                                             ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                             MessageBoxDefaultButton.Button1)
                                    End If

                                Catch ex As Exception
                                    ' ReSharper disable NotAccessedVariable
                                    Dim boxErrorInUpdate As DialogResult
                                    ' ReSharper restore NotAccessedVariable
                                    boxErrorInUpdate = MessageBox.Show _
                                        (New Form() With {.TopMost = True}, ErrorInUnzip & Chr(13),
                                         ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                         MessageBoxDefaultButton.Button1)
                                End Try
                            Else
                                ' ReSharper disable NotAccessedVariable
                                Dim boxErrorInUpdate As DialogResult
                                ' ReSharper restore NotAccessedVariable
                                boxErrorInUpdate = MessageBox.Show _
                                    (New Form() With {.TopMost = True}, ErrorInFileCopy & Chr(13),
                                     ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                     MessageBoxDefaultButton.Button1)
                            End If
                    End Select
                End If
                _memoListViewItem = New List(Of ListViewItem)(ListViewAllChannel.Items.Cast(Of ListViewItem))
            Catch ex As Exception
                ' ReSharper disable NotAccessedVariable
                Dim boxErrorInUpdate As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxErrorInUpdate = MessageBox.Show _
                    (New Form() With {.TopMost = True}, WrongFileName & Chr(13),
                     ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1)
            End Try

            Cursor = Cursors.Default
            ButtonDemarrer.Enabled = False
            ButtonTout.Enabled = True
            ButtonSuppr.Enabled = True

            CheckBoxAutoRestartManualUpdate.Enabled = True
        End If
    End Sub

    Private Sub ButtonToutClick1(sender As Object, e As EventArgs) Handles ButtonTout.Click
        Dim i As Short
        Dim nbElem As Integer = ListViewAllChannel.Items.Count

        Select Case ListXMLTVFRChoisie.Columns.Count
            Case 0
                ListXMLTVFRChoisie.Columns.Add(ChosenChannels & ListXMLTVFRChoisie.Items.Count & ")", -2,
                                               HorizontalAlignment.Left)
                ListXMLTVFRChoisie.Columns.Item(0).Width = ListXMLTVFRChoisie.Width - 22
        End Select

        For i = 0 To CShort(ListViewAllChannel.Items.Count - 1)
            If Not ListViewAllChannel.Items.Item(i).Font.Bold Then
                Dim itmListXmltvfrChoisie As New ListViewItem
                itmListXmltvfrChoisie.Text = ListViewAllChannel.Items.Item(i).Text
                itmListXmltvfrChoisie.SubItems.Add("")
                ListXMLTVFRChoisie.Items.Add(itmListXmltvfrChoisie)
                itmListXmltvfrChoisie.ImageIndex = ListViewAllChannel.Items(i).ImageIndex
                ListXMLTVFRChoisie.SmallImageList = ImageListSmall
            End If
        Next i
        Dim itm As ListViewItem
        For Each itm In ListXMLTVFRChoisie.Items
            If CollectionChannels.Contains(itm.Text) Then
                ArrayOnechannel = DirectCast(CollectionChannels.Item(itm.Text), String())
                CollectionSelectChannels.Add(ArrayOnechannel)
            End If
        Next itm

        ListXMLTVFRChoisie.Columns.Item(0).Text = ChosenChannels & ListXMLTVFRChoisie.Items.Count & ")"

        For i = 1 To CShort(ListViewAllChannel.Items.Count)
            ListViewAllChannel.Items.Item(nbElem - i).Remove()
        Next i

        ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & ")"
        ButtonToutClick = "True"
        ButtonAppliquer.Location = ButtonDemarrer.Location
        ButtonDemarrer.Visible = False
        ButtonAppliquer.Visible = True
        AcceptButton = ButtonAppliquer
    End Sub

    Private Sub ButtonAppliquerClick(sender As Object, e As EventArgs) Handles ButtonAppliquer.Click

        ' N�o le 14/02/2012
        ' On limite � 160 le nombre de chaines s�lectionnables
        If ListXMLTVFRChoisie.Items.Count > 160 Then

            ' ReSharper disable NotAccessedVariable
            Dim boxMiseaJour As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxMiseaJour = MessageBox.Show _
                (New Form() With {.TopMost = True},
                 MessageBoxListXmltvfrChoisie & Chr(13) & MessageBoxListXmltvfrChoisie1,
                 MessageBoxListXmltvfrChoisieTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning,
                 MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If ButtonAppliquer.Enabled = False Then
            Exit Sub
        End If

        ' 290409 pallier au double clic sur bouton mise a jour manuelle
        ButtonAppliquer.Enabled = False

        CheckBoxAutoRestartManualUpdate.Enabled = False

        ' N�o 12/02/2012
        ' C'est une mise � jour � partir d'un emplacement local et la mise � jour auto est activ�e
        If RadioButtonXmlPath.Checked AndAlso My.Settings.AutoUpdate = 1 AndAlso My.Settings.firstDIRChecked Then

            ' N�o le 14/02/2012
            ' Ne plus proposer le message la prochaine fois
            My.Settings.firstDIRChecked = False

            Dim boxDirChecked As DialogResult
            boxDirChecked = MessageBox.Show _
                (New Form() With {.TopMost = True}, MessageBoxDirChecked & Chr(13) & MessageBoxDirChecked1,
                 MessageBoxDirCheckedTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button1)

            If boxDirChecked = DialogResult.Yes Then
                ' On d�sactive la mise � jour automatique
                My.Settings.AutoUpdate = 0
            End If
        End If

        ' N�o 14/02/2012
        ' C'est une mise � jour � partir d'une URL et la mise � jour auto est d�sactiv�e
        If RadioButtonDownload.Checked AndAlso My.Settings.AutoUpdate = 0 AndAlso My.Settings.firstURLChecked Then

            ' N�o le 14/02/2012
            ' Ne plus proposer le message la prochaine fois
            My.Settings.firstURLChecked = False

            Dim boxUrlChecked As DialogResult
            boxUrlChecked = MessageBox.Show _
                (New Form() With {.TopMost = True}, MessageBoxUrlChecked & Chr(13) & MessageBoxUrlChecked1,
                 MessageBoxUrlCheckedTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button1)

            If boxUrlChecked = DialogResult.Yes Then
                ' On active la mise � jour automatique
                My.Settings.AutoUpdate = 1
            End If
        End If

        My.Settings.Save()

        If _
            ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6) AndAlso
            My.Settings.BddExists AndAlso BasePerimee() = False AndAlso TaskbarManager.IsPlatformSupported Then
            Hide()
        End If
        TraitementAppliquer()

        ' on a cliqu� sur "appliquer" apres la selection des chaines
        ButtonAppliquer.Enabled = False
        '120809
        Mainform.TshEnCours = False

        ' securite en cas d oubli qq part
        Trace.WriteLine(DateTime.Now & " " & "scrollhorizontal sauv� dans les settings")
        Trace.WriteLine(DateTime.Now & " " & "accord scroll horizontal = " & My.Settings.accordscrollhorizontal.ToString)

        ' Le fichier n'est pas corrompu, c'est une mise a jour manuelle
        ' et la bd existe et n'�tait pas expir�e
        If _
            ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6) AndAlso
            My.Settings.FichierCorrompu = 0 Then

            ' On regarde si l'utilisateur � demand� de red�mmarrer zg automatiquement apr�s une mise � jour manuelle
            ' Si oui on ne joue pas le son
            If Not My.Settings.AutoRestartManualUpdate Then
                Try
                    If My.Settings.AudioOn Then
                        'Dim wave As New WaveOut
                        'Dim xa() As Byte = File.ReadAllBytes(MediaPath & My.Settings.MessagesSound)
                        'Dim data As New MemoryStream(xa)
                        'wave.Init(
                        '    New BlockAlignReductionStream(
                        '        WaveFormatConversionStream.CreatePcmStream(New WaveFileReader(data))))
                        'wave.Volume = CInt(My.Settings.MessagesVolume / 10)
                        'wave.Play()
                        'data.Close()
                        'data.Dispose()
                        Mainform.JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                    End If
                Catch ex As Exception
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                End Try
            End If

            If Not Mainform.NoDatabaseOnStart AndAlso Not Mainform.DataBaseIsExpired Then
                ReDim ArrayOnechannel(2)
                Mainform.Timer_minute.Start()
            Else
                Mainform.Timer_minute.Stop()
            End If

            ' On regarde si l'utilisateur � demand� de red�mmarrer zg automatiquement apr�s une mise � jour manuelle
            If Not My.Settings.AutoRestartManualUpdate Then

                Dim boxMiseaJourManuelle As DialogResult
                boxMiseaJourManuelle = MessageBox.Show _
                    (New Form() With {.TopMost = True},
                     MessageBoxMiseaJourDone & Chr(13) & Chr(13) & MessageBoxMiseaJour1Done _
                     , MessageBoxMiseaJourTitreDone, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1)

                If boxMiseaJourManuelle = DialogResult.Yes Then
                    My.Settings.BddExists = True
                    My.Settings.Save()
                    Mainform.Tl.Close()

                    Mainform.Close()
                    Dispose()
                    Close()
                    Application.DoEvents()
                    Application.Restart()
                Else
                    With Mainform
                        .ToolStripUpdate.Enabled = False
                        .ToolStripMenuOptionsUpdate.Enabled = False
                        .ToolStripAutoUpdate.Enabled = False
                        .ToolStripMenuOptionsAutoUpdate.Enabled = False
                    End With
                    Exit Sub
                End If
            Else
                My.Settings.BddExists = True
                My.Settings.Save()
                Mainform.Tl.Close()

                Mainform.Close()
                Dispose()
                Close()
                Application.DoEvents()
                Application.Restart()
            End If
        Else
            My.Settings.BddExists = True
            My.Settings.Save()
            Mainform.Tl.Close()

            Mainform.Close()
            Dispose()
            Close()
            Application.DoEvents()
            Application.Restart()
        End If
    End Sub

    Private Sub ListViewItemDrag(sender As Object, e As _
                                    ItemDragEventArgs) Handles ListViewAllChannel.ItemDrag
        Dim myItem As ListViewItem
        Dim myItems(ListViewAllChannel.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0

        _listDraged = "ListViewAllChannel"

        For Each myItem In ListViewAllChannel.SelectedItems

            myItems(i) = myItem
            i += 1
        Next myItem

        ListViewAllChannel.DoDragDrop(New _
                                         DataObject("System.Windows.Forms.ListViewItem()", myItems),
                                      DragDropEffects.Copy)
        ButtonAppliquer.Location = ButtonDemarrer.Location
        ButtonDemarrer.Visible = False
        ButtonAppliquer.Visible = True
        AcceptButton = ButtonAppliquer
    End Sub

    Private Sub ListViewItemDrag1(sender As Object, e As _
                                     ItemDragEventArgs) Handles ListXMLTVFRChoisie.ItemDrag
        Dim myItem As ListViewItem
        Dim myItems(ListXMLTVFRChoisie.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0

        _listDraged = "ListXMLTVFRChoisie"

        For Each myItem In ListXMLTVFRChoisie.SelectedItems

            myItems(i) = myItem
            i += 1
        Next myItem

        ListXMLTVFRChoisie.DoDragDrop(New _
                                         DataObject("System.Windows.Forms.ListViewItem()", myItems),
                                      DragDropEffects.Copy)

        ButtonAppliquer.Location = ButtonDemarrer.Location
        ButtonDemarrer.Visible = False

        ' rvs75 le 11/09/2009                        |
        ButtonAppliquer.Visible = ListXMLTVFRChoisie.Items.Count > 0
    End Sub

    Private Sub ListViewDragEnter1(sender As Object, e As _
                                      DragEventArgs) Handles ListViewAllChannel.DragEnter

        If sender Is ListViewAllChannel Then
            If e.Data.GetDataPresent("System.Windows.Forms.ListViewItem()") Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView_DragEnter2(sender As Object, e As _
                                       DragEventArgs) Handles ListXMLTVFRChoisie.DragEnter

        If e.Data.GetDataPresent("System.Windows.Forms.ListViewItem()") Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListViewDragDrop1(sender As Object, e As _
                                     DragEventArgs) Handles ListViewAllChannel.DragDrop
        Try
            Select Case _listDraged
                Case "ListXMLTVFRChoisie"
                    _listDraged = ""
                    Dim _
                        myItems() As ListViewItem =
                            DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem()"), ListViewItem())
                    Dim i As Integer
                    Select Case ListXMLTVFRChoisie.Columns.Count
                        Case 0
                            ListXMLTVFRChoisie.Columns.Add(ChosenChannels & ListXMLTVFRChoisie.Items.Count & ")",
                                                           -2,
                                                           HorizontalAlignment.Left)
                            ListXMLTVFRChoisie.Columns.Item(0).Width = ListXMLTVFRChoisie.Width - 22
                    End Select
                    Dim itmListXmltvfrChoisie2 As New ListViewItem
                    For i = 0 To myItems.GetUpperBound(0)
                        Dim itmListXmltvfrChoisie As New ListViewItem
                        itmListXmltvfrChoisie.Text = myItems(i).Text
                        itmListXmltvfrChoisie.SubItems.Add("")
                        itmListXmltvfrChoisie2.Text = myItems(i).Text
                        itmListXmltvfrChoisie2.SubItems.Add("")
                        ListViewAllChannel.Items.Add(itmListXmltvfrChoisie)
                        itmListXmltvfrChoisie.ImageIndex = myItems(i).ImageIndex
                        itmListXmltvfrChoisie2.ImageIndex = myItems(i).ImageIndex
                        ListViewAllChannel.SmallImageList = ImageListSmall
                        ListXMLTVFRChoisie.Items.Remove(ListXMLTVFRChoisie.SelectedItems.Item(0))
                    Next i
                    ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count &
                                                              ")"
                    ListXMLTVFRChoisie.Columns.Item(0).Text = ChosenChannels & ListXMLTVFRChoisie.Items.Count &
                                                              ")"

                    ButtonToutClick = "False"
                    If ListXMLTVFRChoisie.Items.Count < 1 Then
                        ButtonAppliquer.Location = ButtonDemarrer.Location
                        ButtonDemarrer.Visible = True
                        ButtonAppliquer.Visible = False
                    End If
                    _memoListViewItem.Add(itmListXmltvfrChoisie2)
            End Select
        Catch ex As Exception
            ' ReSharper disable NotAccessedVariable
            Dim boxError As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxError = MessageBox.Show _
                (New Form() With {.TopMost = True}, ex.Message & Chr(13),
                 ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ListViewDragDrop2(sender As Object, e As _
                                     DragEventArgs) Handles ListXMLTVFRChoisie.DragDrop

        Dim i As Integer

        Try
            Select Case _listDraged
                Case "ListViewAllChannel"
                    _listDraged = ""
                    Dim _
                        myItems() As ListViewItem =
                            DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem()"), ListViewItem())

                    Dim numitem As Integer
                    Try
                        Dim targetPoint As Point = ListXMLTVFRChoisie.PointToClient(New Point(e.X, e.Y))
                        numitem = ListXMLTVFRChoisie.InsertionMark.NearestIndex(targetPoint)
                        If numitem = -1 Then
                            numitem = 0
                        End If
                        If numitem = ListXMLTVFRChoisie.Items.Count - 1 Then
                            numitem = ListXMLTVFRChoisie.Items.Count
                        End If

                    Catch ex As Exception
                        numitem = 0
                        Trace.WriteLine(" erreur try catch ligne AAA")
                    End Try

                    For i = 0 To myItems.GetUpperBound(0)
                        Dim itmListViewAllChannel As New ListViewItem
                        itmListViewAllChannel.Text = myItems(i).Text
                        itmListViewAllChannel.SubItems.Add("")
                        ListXMLTVFRChoisie.Items.Insert(numitem + i, itmListViewAllChannel)
                        itmListViewAllChannel.ImageIndex = myItems(i).ImageIndex
                        ListXMLTVFRChoisie.SmallImageList = ImageListSmall
                        _memoListViewItem =
                            _memoListViewItem.Where(
                                Function(itm) _
                                                       Not _
                                                       (itm.Text.ToUpper.Contains(
                                                           ListViewAllChannel.SelectedItems.Item(0).Text.ToUpper))).
                                ToList
                        ListViewAllChannel.Items.Remove(ListViewAllChannel.SelectedItems.Item(0))
                    Next i

                Case Else
                    Dim _
                        myItems() As ListViewItem =
                            DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem()"), ListViewItem())
                    Dim numitem As Integer

                    Try
                        Dim targetPoint As Point = ListXMLTVFRChoisie.PointToClient(New Point(e.X, e.Y))
                        numitem = ListXMLTVFRChoisie.InsertionMark.NearestIndex(targetPoint)
                        If numitem = -1 Then
                            numitem = 0
                        End If
                        If numitem = ListXMLTVFRChoisie.Items.Count - 1 Then
                            numitem = ListXMLTVFRChoisie.Items.Count
                        End If

                    Catch ex As Exception
                        numitem = 0
                        Trace.WriteLine(" erreur try catch ligne AAA2")
                    End Try

                    For i = 0 To myItems.GetUpperBound(0)
                        Dim itmListViewAllChannel As New ListViewItem
                        itmListViewAllChannel.Text = myItems(i).Text
                        itmListViewAllChannel.SubItems.Add("")
                        ListXMLTVFRChoisie.Items.Insert(numitem + i, itmListViewAllChannel)
                        itmListViewAllChannel.ImageIndex = myItems(i).ImageIndex
                        ListXMLTVFRChoisie.SmallImageList = ImageListSmall
                        ListXMLTVFRChoisie.Items.Remove(ListXMLTVFRChoisie.SelectedItems.Item(0))
                    Next i
            End Select

            ListViewAllChannel.Columns.Item(0).Text = ChosenChannels & ListViewAllChannel.Items.Count & ")"
            ListXMLTVFRChoisie.Columns.Item(0).Text = AvailableChannels & ListXMLTVFRChoisie.Items.Count & ")"

            Select Case ListXMLTVFRChoisie.Items.Count
                Case 0
                    ButtonDemarrer.Visible = True
                    ButtonAppliquer.Visible = False
                Case Else
                    Select Case ListViewAllChannel.Items.Count
                        Case 0
                            ButtonToutClick = ""
                            ButtonDemarrer.Visible = False
                            ButtonAppliquer.Visible = True
                            ButtonAppliquer.Location = ButtonDemarrer.Location
                            AcceptButton = ButtonAppliquer
                    End Select
            End Select

        Catch ex As Exception
            ' ReSharper disable NotAccessedVariable
            Dim boxError As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxError = MessageBox.Show _
                (New Form() With {.TopMost = True}, ex.Message & Chr(13),
                 ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ComboBox1SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles URLComboBox.SelectedIndexChanged

        If URLComboBox.SelectedIndex <= 0 Then
            ButtonDemarrer.Enabled = False
        Else
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Try
            Dispose(False)
        Catch

        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Dim bConnect As Boolean = True

        ' avant toute mise � jour manuelle , sauver la base de donnee db_progs.db3 dans db_progrs.bak
        Trace.WriteLine(DateTime.Now & " " & "entree dans Sub New Frm mise a jour")

        ' copie de sauvegarde de la base de donn�es au cas ou il y aurait
        ' corruption du ficher � t�l�charger
        ' a faire: m�morisation de la date de derniere mise a jour reussie
        Dim success As Boolean
        Dim sourcefile As String
        Dim destinationfile As String
        Dim bdDisGood As Boolean = True
        sourcefile = BddPath & "db_progs.db3"
        destinationfile = BddPath & "db_progs.bak"
        Dim fichier As New FileInfo(sourcefile)
        If File.Exists(sourcefile) AndAlso fichier.Length > 4096 Then
            success = CopierFichier(sourcefile, destinationfile, True)
            If Not success Then
                Trace.WriteLine(DateTime.Now & " " & "la copie de db_progs.db3 vers db_progs.bak a �chou�")
                Trace.WriteLine(DateTime.Now & " " & "pas de r�cup�ration possible si fichier corrompu")
            Else
                Trace.WriteLine(DateTime.Now & " " & "db_prob.db3 a �t� copi� dans db_prog.bak  pour r�cup �ventuelle")
            End If
        Else
            bdDisGood = False
        End If

        ' copie de sauvegarde du fichier ZGuideTVDotNet.channels.set
        ' au cas ou il y aurait corruption du ficher � t�l�charger
        sourcefile = ChannelSetPath & "ZGuideTVDotNet.channels.set"
        destinationfile = ChannelSetPath & "ZGuideTVDotNet.channels.bak"
        fichier = New FileInfo(sourcefile)
        If File.Exists(sourcefile) AndAlso fichier.Length > 0 Then
            success = CopierFichier(sourcefile, destinationfile, True)
            If Not success Then
                Trace.WriteLine(
                    DateTime.Now & " " &
                    "la copie de ZGuideTVDotNet.channels.set vers ZGuideTVDotNet.channels.bak a �chou�")
                Trace.WriteLine(DateTime.Now & " " & "pas de r�cup�ration possible si fichier corrompu")
            Else
                Trace.WriteLine(
                    DateTime.Now & " " &
                    "ZGuideTVDotNet.channels.set a �t� copi� dans ZGuideTVDotNet.channels.bak  pour r�cup �ventuelle")
            End If
        End If

        ' copie de sauvegarde du fichier user.config
        ' au cas ou il y aurait corruption du ficher � t�l�charger
        Dim _
            configZGuideTv As Configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)
        sourcefile = configZGuideTv.FilePath
        destinationfile = configZGuideTv.FilePath & ".bak"
        fichier = New FileInfo(sourcefile)
        If File.Exists(sourcefile) AndAlso fichier.Length > 0 Then
            success = CopierFichier(sourcefile, destinationfile, True)
            If Not success Then
                Trace.WriteLine(DateTime.Now & " " & "la copie de user.config vers user.config.bak a �chou�")
                Trace.WriteLine(DateTime.Now & " " & "pas de r�cup�ration possible si fichier corrompu")
            Else
                Trace.WriteLine(
                    DateTime.Now & " " & "user.config a �t� copi� dans user.config.bak  pour r�cup �ventuelle")
            End If
        End If

        ' lecture de channeltbl (liste des canaux tel que Arte,TV5, Rtbf,...)
        If bdDisGood Then
            Dim i As Integer
            Dim qwAllChanneltbl As String
            qwAllChanneltbl = "SELECT  Name,ID,ordering,logo FROM Channeltbl ORDER BY ORDERING "
            Try
                Dim db As SqLiteBase = New SqLiteBase
                Dim dtChannels As DataTable
                db.OpenDatabase(BddPath & "db_progs.db3")
                dtChannels = db.ExecuteQuery(qwAllChanneltbl)
                db.CloseDatabase()
                Try
                    For r As Integer = 0 To dtChannels.Rows.Count - 1
                        With _originalList(i)
                            .Name = dtChannels.Rows(r).Item(0).ToString
                            .Id = dtChannels.Rows(r).Item(1).ToString
                            .Logo = dtChannels.Rows(r).Item(3).ToString
                        End With
                        i += 1
                    Next
                    _nbChannels = i - 1

                    ' 020409 probleme previsible si = 0
                Catch ex As Exception
                    'bConnect = False
                    Trace.WriteLine(DateTime.Now & " Base de donn�es inexistante ou non disponible ou chemin invalide ")
                End Try
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " Base de donn�es inexistante ou non disponible ou chemin invalide ")
            End Try
            'End Using

        End If

        If Not File.Exists(AppData & "xmltv.dtd") Then
            CopierFichier(AppPath & "\xmltv.dtd", AppData & "xmltv.dtd")
        End If

        ' 14/01/2009 On regarde le dernier lien s�lectionn� URL ou Disque dur

        If Not My.Computer.Network.IsAvailable Then
            RadioButtonDownload.Enabled = False
            RadioButtonXmlPath.Checked = True
            TextBoxPathXml.Enabled = True
            ButtonOpenfile.Enabled = True
            URLComboBox.Enabled = False
        Else

            If My.Settings.DIRChecked Then

                ' on n a pas choisi une url mais un fichier
                RadioButtonXmlPath.Checked = True
            Else
                RadioButtonDownload.Checked = True
            End If

            If RadioButtonXmlPath.Checked Then
                TextBoxPathXml.Enabled = True
                ButtonOpenfile.Enabled = True
                URLComboBox.Enabled = False
            Else
                TextBoxPathXml.Enabled = False
                ButtonOpenfile.Enabled = False
                URLComboBox.Enabled = True
            End If
        End If

        'N�o 29/05/2010
        Try
            If BasePerimee() = True Then
                Trace.WriteLine(DateTime.Now & " " & "BasePerimee() = True dans Miseajour")
                ButtonDemarrer.PerformClick()
            End If
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "ButtonDemarrer.PerformClick() dans Miseajour.vb" & ex.ToString)
        Finally
            Trace.WriteLine(DateTime.Now & " " & "ButtonDemarrer.PerformClick() ==> Finally dans Miseajour.vb")
        End Try

         Trace.WriteLine(DateTime.Now & " " & "sortie de sub new de Miseajour")
    End Sub

    Private Sub RemplirUrlCombo(Optional ByVal bdernierEssai As Boolean = False)

        ' Remplissage de la Combo Box qui donne les liens vers les serveurs
        ' pour mise a jour des emissions. Choix du lien a faire dans cette
        ' combo(box)
        ' le fichier NomFichierURL est compos� de plusieurs collones s�par�s par des ";"

        ' 1:      �re(col) : URL()
        ' 2i�me col: id de la ligne
        ' 3i�me col: Texte � afficher
        ' 4i�me col: ==> 0=> on peut t�l�charger; 1=>visible quand mode d�bug;2=>ligneque l'on affiche mais qui ne comporte pas de URL

        Dim urlList As Stream
        Dim mess As String
        Dim itab As Integer

        Try
            urlList = File.OpenRead(UrlPath & NomFichierUrl)

            Dim monStreamReader As New StreamReader(urlList, UnicodeEncoding.UTF7)
            Dim ligne As String
            ligne = monStreamReader.ReadLine

            If ligne <> Nothing Then
                URLComboBox.Items.Clear()
            End If
            itab = 0
            Do
                mess = ligne.Split(CChar(";"))(1)

                If Not [String].Equals(ligne.Split(CChar(";"))(2).Trim(" "c), "1", StringComparison.CurrentCulture) Then
                    URLComboBox.Items.Add(mess)
                    _tableUrlUrl(itab) = ligne.Split(CChar(";"))(0).Replace(CChar(" "), "")
                    _tableTypeUrl(itab) = ligne.Split(CChar(";"))(2).Replace(CChar(" "), "")

                    ' si la ligne correspond � la derni�re mise � jours alors on la s�lectionne
                    If _
                        [String].Equals(My.Settings.Lienmiseajour, ligne.Split(CChar(";"))(0).Trim(" "c),
                                        StringComparison.CurrentCulture) AndAlso
                        Not [String].Equals(ligne.Split(CChar(";"))(2).Trim(" "c), "2", StringComparison.CurrentCulture) _
                        Then
                        If _
                            Not _
                            (Not ligne.Split(CChar(";"))(0).Trim(" "c) Is Nothing AndAlso
                             String.IsNullOrEmpty(ligne.Split(CChar(";"))(0).Trim(" "c))) Then
                            URLComboBox.SelectedIndex = itab
                        End If
                    End If
                Else
                    itab -= 1
                End If

                ligne = monStreamReader.ReadLine
                itab += 1
            Loop Until ligne Is Nothing
            monStreamReader.Close()
            monStreamReader.Dispose()
            WarningURl()

            ' N�o 25/06/2013
            ' Si une url n'est pas s�lectionn�e on affiche la 1er ligne
            If URLComboBox.Text = Nothing Then
                URLComboBox.SelectedIndex = 0
            End If
            urlList.Close()
            urlList.Dispose()

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "erreur try catch ligne AAA3")
            Select Case bdernierEssai
                Case True

                    ' T�l�chargement sans message d'erreur
                    If _
                        DownloadFile(_serveurUrl & NomFichierUrl, SettingsPath & NomFichierUrl & ".Tmp", 10000,
                                     1024,
                                     False) Then
                        CopierFichier(AppData & NomFichierUrl & ".Tmp", AppData & NomFichierUrl, True)
                        Dim tmpFile() As String
                        tmpFile = Directory.GetFiles(AppData, NomFichierUrl & ".Tmp")
                        Dim i As Integer = 0
                        Do While i < tmpFile.Length
                            File.Delete(tmpFile(i))
                            i += 1
                        Loop
                        RemplirUrlCombo(False)
                    Else
                        ' ReSharper disable NotAccessedVariable
                        Dim boxFailUrlFileDownload As DialogResult
                        ' ReSharper restore NotAccessedVariable
                        boxFailUrlFileDownload = MessageBox.Show _
                            (New Form() With {.TopMost = True}, FailUrlFileDownload & Chr(13),
                             FailUrlFileDownload, MessageBoxButtons.OK, MessageBoxIcon.Error,
                             MessageBoxDefaultButton.Button1)
                    End If
                Case Else

                    ' ReSharper disable NotAccessedVariable
                    Dim boxUntraceableUrlListFile As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxUntraceableUrlListFile = MessageBox.Show _
                        (New Form() With {.TopMost = True}, UntraceableUrlListFile & Chr(13),
                         UntraceableUrlListFile, MessageBoxButtons.OK, MessageBoxIcon.Error,
                         MessageBoxDefaultButton.Button1)
            End Select
        End Try
    End Sub

    Public Function CopierFichier(fichierSource As String, fichierDest As String,
                                  Optional ByVal bEcraser As Boolean = False) As Boolean

        ' V�rifier que le fichier source existe
        If Not File.Exists(fichierSource) Then
            ' ReSharper disable NotAccessedVariable
            Dim boxError As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxError = MessageBox.Show _
                (New Form() With {.TopMost = True}, TheFile & DontExist & Chr(13),
                 TheFile & DontExist, MessageBoxButtons.OK, MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1)
            Return False
        End If

        ' Si l'utilisateur a d�j� choisi le fichier dans le AppData
        ' alors il est inutile de faire une copie
        If [String].Equals(fichierSource, fichierDest, StringComparison.CurrentCulture) Then
            Return True
        End If

        ' V�rifier Si il y a d�j� un "FichierDest" de pr�sent
        If File.Exists(fichierDest) Then
            If bEcraser Then
                Try
                    File.Delete(fichierDest)
                Catch ex As Exception
                    ' ReSharper disable NotAccessedVariable
                    Dim boxError As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxError = MessageBox.Show _
                        (New Form() With {.TopMost = True}, ErrorInFileCopy & Chr(13),
                         ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error,
                         MessageBoxDefaultButton.Button1)
                    Return False
                End Try
            Else
                Return False
            End If
        End If

        ' Copie du fichier
        Try
            File.Copy(fichierSource, fichierDest)
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "erreur try catch ligne AAA3")
            ' Echec de la copie
            Return False
        End Try

        Return True
    End Function

    Private Sub UrlComboBoxSelectedValueChanged(sender As Object, e As EventArgs) _
        Handles URLComboBox.SelectedValueChanged
        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub UrlComboBoxSelectionChangeCommitted(sender As Object, e As EventArgs) _
        Handles URLComboBox.SelectionChangeCommitted
        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub UrlComboBoxTextChanged(sender As Object, e As EventArgs) Handles URLComboBox.TextChanged
        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub UrlComboBoxValueMemberChanged(sender As Object, e As EventArgs) _
        Handles URLComboBox.ValueMemberChanged
        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub ListXmltvfrChoisieMouseEnter(sender As Object, e As EventArgs) _
        Handles ListXMLTVFRChoisie.MouseEnter
        _listDraged = ""
    End Sub

    Private Sub ListViewAllChannelMouseEnter(sender As Object, e As EventArgs) _
        Handles ListViewAllChannel.MouseEnter
        _listDraged = ""
    End Sub

    Private Sub ButtonSupprClick(sender As Object, e As EventArgs) Handles ButtonSuppr.Click
        Dim i As Short
        Dim nbElem As Integer = ListXMLTVFRChoisie.Items.Count

        Select Case ListXMLTVFRChoisie.Columns.Count
            Case 0
                ListViewAllChannel.Columns.Add(ChosenChannels & ListViewAllChannel.Items.Count & ")", -2,
                                               HorizontalAlignment.Left)
                ListViewAllChannel.Columns.Item(0).Width = ListXMLTVFRChoisie.Width - 22
        End Select

        For i = 0 To CShort(ListXMLTVFRChoisie.Items.Count - 1)
            If Not ListXMLTVFRChoisie.Items.Item(i).Font.Bold Then
                Dim itmListXmltvfrChoisie As New ListViewItem
                itmListXmltvfrChoisie.Text = ListXMLTVFRChoisie.Items.Item(i).Text
                itmListXmltvfrChoisie.SubItems.Add("")
                ListViewAllChannel.Items.Add(itmListXmltvfrChoisie)
                itmListXmltvfrChoisie.ImageIndex = ListXMLTVFRChoisie.Items(i).ImageIndex
                ListViewAllChannel.SmallImageList = ImageListSmall
            End If
        Next i
        Dim itm As ListViewItem
        For Each itm In ListViewAllChannel.Items
            If CollectionChannels.Contains(itm.Text) Then
                ArrayOnechannel = DirectCast(CollectionChannels.Item(itm.Text), String())
                CollectionSelectChannels.Add(ArrayOnechannel)
            End If
        Next itm

        For i = 1 To CShort(ListXMLTVFRChoisie.Items.Count)
            ListXMLTVFRChoisie.Items.Item(nbElem - i).Remove()
        Next i

        ButtonToutClick = "False"
        ListXMLTVFRChoisie.Columns.Item(0).Text = ChosenChannels & ListXMLTVFRChoisie.Items.Count & ")"
        ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & ")"
        ButtonAppliquer.Location = ButtonDemarrer.Location

        ' rvs75 le 11/09/2009  : visible � False
        ButtonDemarrer.Visible = False
        ButtonAppliquer.Visible = False
    End Sub

    Private Sub RadioButtonXmlPathCheckedChanged(sender As Object, e As EventArgs) _
        Handles RadioButtonXmlPath.CheckedChanged

        ' 06/07/2011 Modifi� par N�o
        If RadioButtonXmlPath.Checked Then
            ButtonDemarrer.Enabled = True
        Else
            ButtonDemarrer.Enabled = False
        End If
    End Sub

    Private Sub RadioButton1CheckedChanged(sender As Object, e As EventArgs) _
        Handles RadioButtonDownload.CheckedChanged

        ' 06/07/2011 Modifi� par N�o
        If RadioButtonDownload.Checked Then

            If URLComboBox.SelectedIndex <= 0 Then
                ButtonDemarrer.Enabled = False
            Else
                ButtonDemarrer.Enabled = True
            End If
        End If
    End Sub

    Private Sub WarningURl()

        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            If Not [String].Equals(_tableTypeUrl(URLComboBox.SelectedIndex), "2", StringComparison.CurrentCulture) Then
                If URLComboBox.Text.IndexOf(Chr(45)) _
                   <>
                   1 Then
                    ButtonDemarrer.Enabled = True
                End If
            Else
                ButtonDemarrer.Enabled = False

            End If
        Else
            Trace.WriteLine(DateTime.Now & " " & "Warning Url case 3 ")
            ButtonDemarrer.Enabled = False
        End If
    End Sub

    Private Function RechercherLogo(channelRen As String) As String
        '-------------------------------------------------------------------------------------------------
        'la routine renvoit ,sauf mention contraire, la variable "sortie" de type string  via l instruction return
        '-------------------------------------------------------------------------------------------------
        'rvs 30/05/2010 : essaie de r�cuperer le logo qui est renseign� dans la bdd en premier
        'pas tr�s propre mais fonctionnel...

        channelRen = channelRen.ToLower()
        If channelRen.EndsWith(".fr") Then
            channelRen = channelRen.Substring(0, channelRen.LastIndexOf("."))
        End If

        channelRen =
            channelRen.Replace(".", "").Replace("-", "").Replace("\", "").Replace("/", "").Replace("�", "u").Replace(
                "�", "ss").Replace("'", "").Replace("�", "i").Replace("�", "i").Replace("�", "o").Replace("�", "o").
                Replace("�", "e").Replace("&", "").Replace("_", "").Replace("(", "").Replace(")", "").Replace("+", "")

        Dim sortie As String
        If _originalList.Length > 0 Then
            Dim memlogochannel As String
            Dim localList As List(Of ChannelList) = _originalList.Where(Function(p) p.Id <> Nothing).ToList
            For Each channel As ChannelList In localList
                If [String].Equals(channel.Name, channelRen, StringComparison.CurrentCulture) Then
                    memlogochannel = channel.Logo
                    If File.Exists(LogosPath & memlogochannel) Then
                        ImageListSmall.Images.Add(Image.FromFile(LogosPath & memlogochannel))
                        Return memlogochannel ' BB230610
                    End If
                End If
            Next
        End If

        ' rvs 03/11/2009 code repris de parse_xml_channels afin de
        ' pouvoir �tre r�utiliser si 'il y a un noeud enfant "icon"
        If Directory.GetFiles(LogosPath, channelRen & ".*").Length > 0 Then
            If File.Exists(LogosPath & channelRen & ".gif") Then
                ImageListSmall.Images.Add(
                    Image.FromFile(
                        LogosPath & channelRen &
                        ".gif"))
                sortie = channelRen & ".gif"
            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                ImageListSmall.Images.Add(
                    Image.FromFile(
                        LogosPath & channelRen &
                        ".jpg"))
                sortie = channelRen & ".jpg"
            Else

                ' Modifier le 05092009
                Dim memo As String
                memo = CreerLogo(channelRen & ".jpg")
                ImageListSmall.Images.Add(
                    Image.FromFile(
                        LogosPath &
                        memo))
                sortie = memo
            End If
        Else
            channelRen = channelRen.Replace("�", "e").Replace("�", "e")

            ' Modifier le 25092009
            If File.Exists(LogosPath & channelRen & ".gif") Then
                ImageListSmall.Images.Add(
                    Image.FromFile(
                        LogosPath & channelRen &
                        ".gif"))
                sortie = channelRen & ".gif"
            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                ImageListSmall.Images.Add(
                    Image.FromFile(
                        LogosPath & channelRen &
                        ".jpg"))
                sortie = channelRen.Replace(" ", "") & ".jpg"
            Else

                ' Modifier le 01092009
                channelRen = channelRen.Replace(" ", "")
                If File.Exists(LogosPath & channelRen & ".gif") Then
                    ImageListSmall.Images.Add(
                        Image.FromFile(
                            LogosPath & channelRen &
                            ".gif"))
                    sortie = channelRen & ".gif"
                ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                    ImageListSmall.Images.Add(
                        Image.FromFile(
                            LogosPath & channelRen &
                            ".jpg"))
                    sortie = channelRen & ".jpg"
                Else
                    channelRen = channelRen.Replace("+", "plus")
                    If File.Exists(LogosPath & channelRen & ".gif") Then
                        ImageListSmall.Images.Add(
                            Image.FromFile(
                                LogosPath &
                                channelRen & ".gif"))
                        sortie = channelRen & ".gif"
                    ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                        ImageListSmall.Images.Add(
                            Image.FromFile(
                                LogosPath &
                                channelRen & ".jpg"))
                        sortie = channelRen & ".jpg"
                    Else
                        channelRen =
                            channelRen.Replace("television", "TV").Replace(
                                "Television",
                                "TV").
                                Replace("TELEVISION", "TV")
                        If File.Exists(LogosPath & channelRen & ".gif") Then
                            ImageListSmall.Images.Add(
                                Image.FromFile(
                                    LogosPath &
                                    channelRen &
                                    ".gif"))
                            sortie = channelRen & ".gif"
                        ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                            ImageListSmall.Images.Add(
                                Image.FromFile(
                                    LogosPath &
                                    channelRen &
                                    ".jpg"))
                            sortie = channelRen & ".jpg"
                        Else
                            channelRen =
                                channelRen.Replace("tv", "").Replace("Tv", "").Replace(
                                    "TV",
                                    "")
                            If File.Exists(LogosPath & channelRen & ".gif") Then
                                ImageListSmall.Images.Add(
                                    Image.FromFile(
                                        LogosPath &
                                        channelRen &
                                        ".gif"))
                                sortie = channelRen & ".gif"
                            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                                ImageListSmall.Images.Add(
                                    Image.FromFile(
                                        LogosPath &
                                        channelRen &
                                        ".jpg"))
                                sortie = channelRen & ".jpg"
                            Else
                                channelRen = channelRen.Replace("plus", "")
                                If File.Exists(LogosPath & channelRen & ".gif") Then
                                    ImageListSmall.Images.Add(
                                        Image.FromFile(
                                            LogosPath &
                                            channelRen &
                                            ".gif"))
                                    sortie = channelRen & ".gif"
                                ElseIf File.Exists(LogosPath & channelRen & ".jpg") _
                                    Then
                                    ImageListSmall.Images.Add(
                                        Image.FromFile(
                                            LogosPath &
                                            channelRen &
                                            ".jpg"))
                                    sortie = channelRen & ".jpg"
                                Else
                                    ' Modifier le 05092009
                                    Dim memo As String
                                    memo = CreerLogo(channelRen & ".jpg")
                                    ImageListSmall.Images.Add(
                                        Image.FromFile(
                                            LogosPath &
                                            memo))
                                    'rechercher_Logo = memo
                                    sortie = memo

                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return sortie
    End Function

    Private Sub TextBoxPathXmlTextChanged(sender As Object, e As EventArgs) _
        Handles TextBoxPathXml.TextChanged
        ButtonDemarrer.Visible = True
    End Sub

    Private Sub ButtonEditClick(sender As Object, e As EventArgs) Handles ButtonEdit.Click

        Process.Start("notepad.exe", UrlPath & NomFichierUrl)
        Close()
    End Sub

    Private Sub Button1Click(sender As Object, e As EventArgs) Handles ButtonHelpMiseaJour.Click

        Try

            ' Modifi� par N�o le 13/02/2011
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://zguidetv.codeplex.com") Then

                Close()

                If [String].Equals(My.Settings.Language, "Fran�ais", StringComparison.CurrentCulture) Then

                    Process.Start("http://zguidetv.codeplex.com/wikipage?title=Quick%20Start-fr")
                Else
                    Process.Start("http://zguidetv.codeplex.com/wikipage?title=Quick%20Start")
                End If

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le site internet de zguidetv

                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(New Form() With {.TopMost = True},
                                    Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1,
                                    Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(New Form() With {.TopMost = True},
                                Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1,
                                Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub CheckBoxAutoRestartManualUpdate_CheckedChanged(sender As Object, e As EventArgs) _
        Handles CheckBoxAutoRestartManualUpdate.CheckedChanged

        If CheckBoxAutoRestartManualUpdate.Checked = True Then
            My.Settings.AutoRestartManualUpdate = True
        Else
            My.Settings.AutoRestartManualUpdate = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub txbRecherche_TextChanged(sender As Object, e As EventArgs) Handles txbRecherche.TextChanged
        Try

            txbRecherche.Enabled = True

            If txbRecherche.Text <> LngTextBoxRecherche AndAlso txbRecherche.Text.Trim().Length > 0 Then
                Dim templistviewitems As List(Of ListViewItem)
                templistviewitems =
                    _memoListViewItem.Where(
                        Function(itm) _
                                               itm.Text.IndexOf(txbRecherche.Text.Trim(), 0,
                                                                StringComparison.CurrentCultureIgnoreCase) > -1).ToList()
                ListViewAllChannel.Items.Clear()
                ListViewAllChannel.Items.AddRange(templistviewitems.ToArray)
            Else
                ListViewAllChannel.Items.Clear()
                ListViewAllChannel.Items.AddRange(_memoListViewItem.ToArray)
            End If
            ListXMLTVFRChoisie.Columns.Item(0).Text = ChosenChannels & ListXMLTVFRChoisie.Items.Count & ")"
            ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & ")"

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btReset_Click(sender As Object, e As EventArgs) Handles btReset.Click

        TxbRecherchechaine()
    End Sub

    Public Sub TxbRecherchechaine()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans Miseajour TxbRecherchechaine")

        With txbRecherche
            .Enabled = True
            .Text = LngTextBoxRecherche
            .ForeColor = Color.Gray
            .Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic)
            .TextAlign = HorizontalAlignment.Center
            .SelectionLength = 0
            .ReadOnly = True
            .BackColor = Color.White
        End With

        Trace.WriteLine(DateTime.Now & " " & "On sort de Miseajour TxbRecherchechaine")
    End Sub

    Private Sub TxbRechercheClick(sender As Object, e As EventArgs) _
        Handles txbRecherche.Click

        Trace.WriteLine(DateTime.Now & " " & "On entre dans Miseajour TxbRecherchechaineClick")

        If ListViewAllChannel.Items.Count() > 0 Then

            With txbRecherche
                .Text = ""
                .ForeColor = Color.Black
                .Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Left
                .ReadOnly = False
            End With

        Else
            txbRecherche.Enabled = False
            AcceptButton = ButtonDemarrer
        End If

        txbRecherche.Enabled = True

        Trace.WriteLine(DateTime.Now & " " & "On entre dans Miseajour TxbRecherchechaineClick")
    End Sub
End Class