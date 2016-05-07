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

#Region "Imports"

Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Drawing.Imaging
Imports System.Xml
Imports System.Net
Imports System.Configuration
Imports NAudio.Wave
Imports ZGuideTV.SQLiteWrapper
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Globalization

#End Region

' ReSharper disable CheckNamespace
Public Class Miseajour
    ' ReSharper restore CheckNamespace

#Region "Property"

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

    Private Function CreerLogo(ByVal nomlogo As String) As String

        ' variable contenant la chaine qui sera écrit dans le logo
        Dim chainedanslogo As String = nomlogo.ToUpper.Substring(0, nomlogo.IndexOf(".", StringComparison.Ordinal))

        ' pour les noms de chaine contenant un caractère interdit dans un nom de fichier on renvoie "vide.jpg"
        Dim invalidFileNameChars() As Char = Path.GetInvalidFileNameChars()
        If invalidFileNameChars.Any(Function(invalidFileNameChar) nomlogo.Contains(invalidFileNameChar.ToString(CultureInfo.CurrentCulture))) Then
            Return "vide.jpg"
        End If

        ' Si la chaine est top longue pour être entièrement dans le logo, on insère un saut de ligne
        With chainedanslogo
            If .Length > 7 Then

                ' test pour savoir si les dernier caracteres sont des chiffres
                Dim testChiffre As Match = Regex.Match(chainedanslogo, "\d+$")

                ' règle de découpage si les dernier caracteres sont des chiffres
                If testChiffre.Success Then
                    chainedanslogo = .Substring(0, testChiffre.Index) & vbCrLf & testChiffre.Value

                    ' règle de découpage si le nom contient "HD"
                ElseIf .IndexOf("HD", StringComparison.CurrentCulture) > 0 Then
                    chainedanslogo = .Replace("HD", vbCrLf & "HD")

                    ' règle de découpage si le nom contient "PLUS"
                ElseIf .IndexOf("PLUS", StringComparison.CurrentCulture) > 0 Then
                    chainedanslogo = .Replace("PLUS", "+" & vbCrLf)

                    ' règle de découpage si le nom contient "PARIS"
                ElseIf .IndexOf("PARIS", StringComparison.CurrentCulture) >= 0 Then
                    chainedanslogo = .Replace("PARIS", "PARIS" & vbCrLf)

                    ' ici on peut insérer d'autre règles de découpage
                    ' sinon découpage à la hache
                Else
                    chainedanslogo = .Substring(0, 7) & vbCrLf & _
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
            objBitmap.Save(LogosPath & nomlogo, ImageFormat.Jpeg)
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

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Private ReadOnly _originalList(1000) As ChannelList
    Private ReadOnly _nbChannels As Integer = -1
    Public ReadOnly ImageListSmall As New ImageList()

    Public Sub ParseXmlChannels(ByVal pathXml As String)

        ' Y a t il des erreurs a signaler au programme appelant?
        Dim xmlTvDoc As XmlDocument = New XmlDocument()
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

        Trace.WriteLine(DateTime.Now & " Chargement des Chaînes dans frmmiseajour")
        ImageListSmall.ImageSize = New Size(38, 29)

        Try
            CollectionSelectChannels.Clear()
            CollectionChannels.Clear()
            Trace.WriteLine(DateTime.Now & " " & pathXml)
            xmlTvDoc.Load(pathXml)

            elementChannel = xmlTvDoc.DocumentElement.GetElementsByTagName("channel")
            ListViewAllChannel.Columns.Add(AvailableChannels & elementChannel.Count & ")", -2, _
                                            HorizontalAlignment.Left)
            ListViewAllChannel.Columns.Item(0).Width = ListViewAllChannel.Width - 22

            For Each noeud In elementChannel
                channelId = noeud.Attributes(0).Value
                ArrayOnechannel(0) = channelId
                Dim listViewMyItem As New ListViewItem
                Dim bPasséDans As Boolean = False
                For Each noeudEnf In noeud.ChildNodes
                    Select Case noeudEnf.LocalName.ToLower
                        Case "display-name"
                            If Not bPasséDans Then
                                bPasséDans = True

                                channelName = noeudEnf.InnerText

                                'rvs75 le 29/12/2010 : réécriture du changement de nom de chaines si doublons
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

                                ' Modifié le 05/09/2009 rvs75
                                channelRen = channelName
                                Dim invalidFileNameChars() As Char = Path.GetInvalidFileNameChars()
                                For Each invalidFileNameChar As Char In invalidFileNameChars
                                    If channelRen.Contains(invalidFileNameChar.ToString(CultureInfo.CurrentCulture)) Then
                                        channelRen = channelRen.Replace(invalidFileNameChar.ToString, "")
                                    End If
                                Next

                                ' Modifié le 10/09/2009 rvs75                                                
                                listViewMyItem.Text = channelName.ToString
                                listViewMyItem.SubItems.Add("")
                                ListViewAllChannel.Items.Add(listViewMyItem)

                                ' comptage des noeuds enfants qui ont un tag "icon"
                                Dim cptIcon As Integer = 0
                                For t As Integer = 0 To noeud.ChildNodes.Count - 1
                                    If [String].Equals(noeud.ChildNodes.ItemOf(t).Name, "icon", StringComparison.CurrentCulture) Then
                                        cptIcon += 1
                                    End If
                                Next

                                ' choix si il y a ou pas un noeud enfant "icon"
                                Select Case cptIcon
                                    Case 0

                                        ' rvs 03/11/2009 tous le code ici a été externaliser dans la function "Recherche_logo
                                        ' afin de pouvoir être réutiliser si 'il y a un noeud enfant "icon"
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
                    .Columns.Add(ChosenChannels & .Items.Count & ")", -2, _
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

                ' Supression des chaînes présélectionné de la liste
                ' ListViewAllChannel
                i = 0
                Do While i <= _nbChannels
                    k = 0
                    j = -1
                    Do While j <= icountChannels AndAlso Not bTrouve
                        j += 1
                        bTrouve = ([String].Equals(newList(j).Id, _originalList(i).Id, StringComparison.CurrentCulture))
                        If Not [String].Equals(newList(j).Id, "****-1****", StringComparison.CurrentCulture) AndAlso Not bTrouve Then
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
                End If

            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & ex.Message)
            End Try

            ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & ")"

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " Erreur lors de la récupération de la liste des chaines dans frmmiseajour")
            Trace.WriteLine(DateTime.Now & " " & ex.Message)
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)

            ' ReSharper disable NotAccessedVariable
            Dim boxErrorInChannelListRecovery As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxErrorInChannelListRecovery = MessageBox.Show _
                (ErrorInChannelListRecovery & Chr(13), _
                 ErrorInChannelListRecovery, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                 MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    ' CreateMyListView
    Private Sub ButtonOpenfileClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOpenfile.Click
        OpenFileDialogXml.ShowDialog()
        If (TextBoxPathXml.Text.Trim(" "c).Length) > 0 Then '02/10/07
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub FrmMiseajour_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
        Handles Me.FormClosing

        ImageListSmall.Images.Clear()

        ' On efface les résidus des fichiers xml et zip téléchargés ou parsés dans C:\ProgramData\ZGuideTVDotNet
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

    Private Sub FrmMiseajourLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Trace.WriteLine(DateTime.Now & " " & "entree dans frm mise a jour Load")

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

        ' 14/01/2009 On va lire le dernier chemin utilisé sur le disque dur
        XmlTvName = My.Settings.Cheminmiseajour

        TextBoxPathXml.Text = XmlTvName.ToString

        If (TextBoxPathXml.Text.Trim(" "c).Length) > 0 Then

            ButtonDemarrer.Enabled = True
        End If

        ' Néo le 14/04/08
        ButtonToutClick = ""
        Mainform.Timer_minute.Stop()

        ' Mise à jour de la liste des liens automatiques (urlb.set)
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

    Private Sub ButtonAnnulerClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAnnuler.Click

        Close()
    End Sub

    Private Sub OpenFileDialogXmlFileOk(ByVal sender As Object, ByVal e As CancelEventArgs) _
        Handles OpenFileDialogXml.FileOk

        XmlTvName = OpenFileDialogXml.FileName
        TextBoxPathXml.Text = XmlTvName.ToString
    End Sub

    Private Sub ButtonDemarrerClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDemarrer.Click

        ' Néo 22/01/2012
        ' Le fichier de mise à jour sur le disque dur n'existe pas
        If RadioButtonXmlPath.Checked Then
            If Not File.Exists(TextBoxPathXml.Text) Then

                ' ReSharper disable NotAccessedVariable
                Dim boxFileNotExist As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxFileNotExist = MessageBox.Show _
                    (MessageBoxFileNotExist & Chr(13) & MessageBoxFileNotExist1, _
                     MessageBoxFileNotExistTitre, MessageBoxButtons.OK, MessageBoxIcon.Information, _
                     MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        CheckBoxAutoRestartManualUpdate.Enabled = False
        ButtonDemarrer.Enabled = False

        ' Ajout de Ronaldo1 le 08/01/2008
        ' On teste si on a choisie une URL pour éviter que cela plante
        If URLComboBox.SelectedIndex > 0 AndAlso RadioButtonDownload.Checked Then
            _serveurUrl = _tableUrlUrl(URLComboBox.SelectedIndex)

            ' Ajout de Néo le 24/06/2013
            ' On teste l'URL est accessible pour éviter que cela plante
            Dim myUri As New Uri(_serveurUrl)
            Dim baseUri As String = myUri.GetLeftPart(UriPartial.Authority)

            If My.Computer.Network.IsAvailable Then
                If Not ConnectionAvailable(baseUri) Then

                    ' ReSharper disable NotAccessedVariable
                    Dim boxNoConnection As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxNoConnection =
                        MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1,
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
                    MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1,
                                    Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                ButtonDemarrer.Enabled = True
                Exit Sub
            End If

            ' 14/01/2009 On sauvegarde l'état des radio button et le chemin de l'URL
            With My.Settings
                .URLChecked = True
                .DIRChecked = False
                .Lienmiseajour = _serveurUrl
            End With
            My.Settings.Save()

            ' 05/07/2011 Sinon on sauvegarde l'état des radio button et le chemin sur le dd
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

        Dim xmlaTélécharger As String

        With ListViewAllChannel.Columns
            If .Count > 0 Then
                .RemoveAt(0)
            End If
        End With

        ListViewAllChannel.Items.Clear()
        Dim bError As Boolean = False
        Mainform.ToolStripAutoUpdate.Enabled = True

        ' Si l'utilisateur sélectionne le téléchargement ...
        If Not RadioButtonXmlPath.Checked Then
            xmlaTélécharger = _serveurUrl
            xmlaTélécharger = xmlaTélécharger.Trim(" "c)

            ' on extrait le nom du fichier et son extension
            Try
                extention = xmlaTélécharger.Substring(xmlaTélécharger.LastIndexOf(Chr(46)) + 1)
                fileName = xmlaTélécharger.Substring(xmlaTélécharger.LastIndexOf(Chr(47)) + 1)
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
                    (InvalidUrl & Chr(13), _
                     ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                     MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try

            If Not bError Then

                ' on télécharge le fichier dans le appdata
                If DownloadFile(xmlaTélécharger, AppData & fileName, 100000) Then
                    XmlTvName = AppData & fileName
                Else

                    ' ReSharper disable NotAccessedVariable
                    Dim boxUntraceableFile As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxUntraceableFile = MessageBox.Show _
                        (UntraceableFile & Chr(13), _
                         ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error, _
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

                    ' si le fichier n'est pas compressé on le copie dans le appdata et on le renomme prog.xml
                    Select Case extention
                        Case "XML"
                            If CopierFichier(XmlTvName, FichierProgramme, True) Then
                                ParseXmlChannels(FichierProgramme)
                            Else
                                ' ReSharper disable NotAccessedVariable
                                Dim boxErrorInUpdate As DialogResult
                                ' ReSharper restore NotAccessedVariable
                                boxErrorInUpdate = MessageBox.Show _
                                    (ErrorInXmlCopy & Chr(13), _
                                     ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                                     MessageBoxDefaultButton.Button1)
                            End If
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

                                    ' on décompresse le fichier avec 7-zip. Modifié par Néo le 27/02/2010
                                    Dim p As Process = Nothing
                                    Try
                                        p = New Process
                                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                                        p.StartInfo.CreateNoWindow = False
                                        p.StartInfo.UseShellExecute = True
                                        p.StartInfo.FileName = UnZipPath
                                        p.StartInfo.Arguments = " e " & """" & AppData & fileName & """" & " -y -o" & """" & _
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
                                        End If
                                    End Try

                                    Dim xmlFile() As String = Directory.GetFiles(AppData, "*.XML")

                                    If xmlFile.Length > 0 Then
                                        XmlTvName = xmlFile(0)
                                        FichierProgramme = XmlTvName

                                        ' à corriger si nécessaire par Ronaldo
                                        ParseXmlChannels(XmlTvName)
                                    Else
                                        ' ReSharper disable NotAccessedVariable
                                        Dim boxErrorInUpdate As DialogResult
                                        ' ReSharper restore NotAccessedVariable
                                        boxErrorInUpdate = MessageBox.Show _
                                            (ErrorInFileCopy & Chr(13), _
                                             ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                                             MessageBoxDefaultButton.Button1)
                                    End If

                                Catch ex As Exception
                                    ' ReSharper disable NotAccessedVariable
                                    Dim boxErrorInUpdate As DialogResult
                                    ' ReSharper restore NotAccessedVariable
                                    boxErrorInUpdate = MessageBox.Show _
                                        (ErrorInUnzip & Chr(13), _
                                         ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                                         MessageBoxDefaultButton.Button1)
                                End Try
                            Else
                                ' ReSharper disable NotAccessedVariable
                                Dim boxErrorInUpdate As DialogResult
                                ' ReSharper restore NotAccessedVariable
                                boxErrorInUpdate = MessageBox.Show _
                                    (ErrorInFileCopy & Chr(13), _
                                     ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                                     MessageBoxDefaultButton.Button1)
                            End If
                    End Select
                End If

            Catch ex As Exception
                ' ReSharper disable NotAccessedVariable
                Dim boxErrorInUpdate As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxErrorInUpdate = MessageBox.Show _
                    (WrongFileName & Chr(13), _
                     ErrorInUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                     MessageBoxDefaultButton.Button1)
            End Try

            Cursor = Cursors.Default
            ButtonDemarrer.Enabled = False
            ButtonTout.Enabled = True
            ButtonSuppr.Enabled = True

            CheckBoxAutoRestartManualUpdate.Enabled = True
        End If
    End Sub

    Private Sub ButtonToutClick1(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonTout.Click
        Dim i As Short
        Dim nbElem As Integer = ListViewAllChannel.Items.Count

        Select Case ListXMLTVFRChoisie.Columns.Count
            Case 0
                ListXMLTVFRChoisie.Columns.Add(ChosenChannels & ListXMLTVFRChoisie.Items.Count & ")", -2, _
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
    End Sub

    Private Sub ButtonAppliquerClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAppliquer.Click

        ' Néo le 14/02/2012
        ' On limite à 160 le nombre de chaines sélectionnables
        If ListXMLTVFRChoisie.Items.Count > 160 Then

            ' ReSharper disable NotAccessedVariable
            Dim boxMiseaJour As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxMiseaJour = MessageBox.Show _
                (MessageBoxListXmltvfrChoisie & Chr(13) & MessageBoxListXmltvfrChoisie1, _
                 MessageBoxListXmltvfrChoisieTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                 MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If ButtonAppliquer.Enabled = False Then
            Exit Sub
        End If

        ' 290409 pallier au double clic sur bouton mise a jour manuelle 
        ButtonAppliquer.Enabled = False

        CheckBoxAutoRestartManualUpdate.Enabled = False

        ' Néo 12/02/2012
        ' C'est une mise à jour à partir d'un emplacement local et la mise à jour auto est activée
        If RadioButtonXmlPath.Checked AndAlso My.Settings.AutoUpdate = 1 AndAlso My.Settings.firstDIRChecked Then

            ' Néo le 14/02/2012 
            ' Ne plus proposer le message la prochaine fois
            My.Settings.firstDIRChecked = False

            Dim boxDirChecked As DialogResult
            boxDirChecked = MessageBox.Show _
                (MessageBoxDirChecked & Chr(13) & MessageBoxDirChecked1, _
                 MessageBoxDirCheckedTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                 MessageBoxDefaultButton.Button1)

            If boxDirChecked = Windows.Forms.DialogResult.Yes Then
                ' On désactive la mise à jour automatique
                My.Settings.AutoUpdate = 0
            End If
        End If

        ' Néo 14/02/2012
        ' C'est une mise à jour à partir d'une URL et la mise à jour auto est désactivée
        If RadioButtonDownload.Checked AndAlso My.Settings.AutoUpdate = 0 AndAlso My.Settings.firstURLChecked Then

            ' Néo le 14/02/2012 
            ' Ne plus proposer le message la prochaine fois
            My.Settings.firstURLChecked = False

            Dim boxUrlChecked As DialogResult
            boxUrlChecked = MessageBox.Show _
                (MessageBoxUrlChecked & Chr(13) & MessageBoxUrlChecked1, _
                 MessageBoxUrlCheckedTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                 MessageBoxDefaultButton.Button1)

            If boxUrlChecked = Windows.Forms.DialogResult.Yes Then
                ' On active la mise à jour automatique
                My.Settings.AutoUpdate = 1
            End If
        End If

        My.Settings.Save()

        If _
            ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6) AndAlso _
            My.Settings.BddExists AndAlso BasePerimee() = False AndAlso TaskbarManager.IsPlatformSupported Then
            Hide()
        End If
        TraitementAppliquer()

        ' on a cliqué sur "appliquer" apres la selection des chaines
        ButtonAppliquer.Enabled = False
        '120809
        Mainform.TshEnCours = False

        ' securite en cas d oubli qq part
        Trace.WriteLine(DateTime.Now & " " & "scrollhorizontal sauvé dans les settings")
        Trace.WriteLine(DateTime.Now & " " & "accord scroll horizontal = " & My.Settings.accordscrollhorizontal.ToString)

        ' Le fichier n'est pas corrompu, c'est une mise a jour manuelle
        ' et la bd existe et n'était pas expirée
        If _
            ((_os.Version.Major = 6 AndAlso _os.Version.Minor >= 1) OrElse _os.Version.Major > 6) AndAlso _
            My.Settings.FichierCorrompu = 0 Then

            ' On regarde si l'utilisateur à demandé de redémmarrer zg automatiquement après une mise à jour manuelle
            ' Si oui on ne joue pas le son
            If Not My.Settings.AutoRestartManualUpdate Then
                Try
                    If My.Settings.AudioOn Then
                        Dim wave As New WaveOut
                        Dim xa() As Byte = File.ReadAllBytes(MediaPath & My.Settings.MessagesSound)
                        Dim data As New MemoryStream(xa)
                        wave.Init(New BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(New WaveFileReader(data))))
                        wave.Volume = CInt(My.Settings.MessagesVolume / 10)
                        wave.Play()
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

            ' On regarde si l'utilisateur à demandé de redémmarrer zg automatiquement après une mise à jour manuelle
            If Not My.Settings.AutoRestartManualUpdate Then

                Dim boxMiseaJourManuelle As DialogResult
                boxMiseaJourManuelle = MessageBox.Show _
                    ( _
                     MessageBoxMiseaJourDone & Chr(13) & Chr(13) & MessageBoxMiseaJour1Done _
                     , MessageBoxMiseaJourTitreDone, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
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

    Private Sub ListViewItemDrag(ByVal sender As Object, ByVal e As  _
                                      ItemDragEventArgs) Handles ListViewAllChannel.ItemDrag
        Dim myItem As ListViewItem
        Dim myItems(ListViewAllChannel.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0

        _listDraged = "ListViewAllChannel"

        For Each myItem In ListViewAllChannel.SelectedItems

            myItems(i) = myItem
            i += 1
        Next myItem

        ListViewAllChannel.DoDragDrop(New  _
                                          DataObject("System.Windows.Forms.ListViewItem()", myItems), _
                                       DragDropEffects.Copy)
        ButtonAppliquer.Location = ButtonDemarrer.Location
        ButtonDemarrer.Visible = False
        ButtonAppliquer.Visible = True
    End Sub

    Private Sub ListViewItemDrag1(ByVal sender As Object, ByVal e As  _
                                       ItemDragEventArgs) Handles ListXMLTVFRChoisie.ItemDrag
        Dim myItem As ListViewItem
        Dim myItems(ListXMLTVFRChoisie.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0

        _listDraged = "ListXMLTVFRChoisie"

        For Each myItem In ListXMLTVFRChoisie.SelectedItems

            myItems(i) = myItem
            i += 1
        Next myItem

        ListXMLTVFRChoisie.DoDragDrop(New  _
                                          DataObject("System.Windows.Forms.ListViewItem()", myItems), _
                                       DragDropEffects.Copy)

        ButtonAppliquer.Location = ButtonDemarrer.Location
        ButtonDemarrer.Visible = False

        ' rvs75 le 11/09/2009                        |
        ButtonAppliquer.Visible = ListXMLTVFRChoisie.Items.Count > 0
    End Sub

    Private Sub ListViewDragEnter1(ByVal sender As Object, ByVal e As  _
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

    Private Sub ListView_DragEnter2(ByVal sender As Object, ByVal e As  _
                                        DragEventArgs) Handles ListXMLTVFRChoisie.DragEnter

        If e.Data.GetDataPresent("System.Windows.Forms.ListViewItem()") Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListViewDragDrop1(ByVal sender As Object, ByVal e As  _
                                       DragEventArgs) Handles ListViewAllChannel.DragDrop
        Try
            Select Case _listDraged
                Case "ListXMLTVFRChoisie"
                    _listDraged = ""
                    Dim _
                        myItems() As ListViewItem = _
                            DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem()"), ListViewItem())
                    Dim i As Integer
                    Select Case ListXMLTVFRChoisie.Columns.Count
                        Case 0
                            ListXMLTVFRChoisie.Columns.Add(ChosenChannels & ListXMLTVFRChoisie.Items.Count & ")", _
                                                            -2, _
                                                            HorizontalAlignment.Left)
                            ListXMLTVFRChoisie.Columns.Item(0).Width = ListXMLTVFRChoisie.Width - 22
                    End Select
                    For i = 0 To myItems.GetUpperBound(0)
                        Dim itmListXmltvfrChoisie As New ListViewItem
                        itmListXmltvfrChoisie.Text = myItems(i).Text
                        itmListXmltvfrChoisie.SubItems.Add("")
                        ListViewAllChannel.Items.Add(itmListXmltvfrChoisie)
                        itmListXmltvfrChoisie.ImageIndex = myItems(i).ImageIndex
                        ListViewAllChannel.SmallImageList = ImageListSmall
                        ListXMLTVFRChoisie.Items.Remove(ListXMLTVFRChoisie.SelectedItems.Item(0))
                    Next i
                    ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & _
                                                               ")"
                    ListXMLTVFRChoisie.Columns.Item(0).Text = ChosenChannels & ListXMLTVFRChoisie.Items.Count & _
                                                               ")"

                    ButtonToutClick = "False"
                    If ListXMLTVFRChoisie.Items.Count < 1 Then
                        ButtonAppliquer.Location = ButtonDemarrer.Location
                        ButtonDemarrer.Visible = True
                        ButtonAppliquer.Visible = False
                    End If
            End Select
        Catch ex As Exception
            ' ReSharper disable NotAccessedVariable
            Dim boxError As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxError = MessageBox.Show _
                (ex.Message & Chr(13), _
                 ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                 MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ListViewDragDrop2(ByVal sender As Object, ByVal e As  _
                                       DragEventArgs) Handles ListXMLTVFRChoisie.DragDrop

        Dim i As Integer

        Try
            Select Case _listDraged
                Case "ListViewAllChannel"
                    _listDraged = ""
                    Dim _
                        myItems() As ListViewItem = _
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
                        ListViewAllChannel.Items.Remove(ListViewAllChannel.SelectedItems.Item(0))
                    Next i
                Case Else
                    Dim _
                        myItems() As ListViewItem = _
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
                    End Select
            End Select

        Catch ex As Exception
            ' ReSharper disable NotAccessedVariable
            Dim boxError As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxError = MessageBox.Show _
                (ex.Message & Chr(13), _
                 ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                 MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ComboBox1SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
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

        ' avant toute mise à jour manuelle , sauver la base de donnee db_progs.db3 dans db_progrs.bak
        Trace.WriteLine(DateTime.Now & " " & "entree dans Sub New Frm mise a jour")

        ' copie de sauvegarde de la base de données au cas ou il y aurait
        ' corruption du ficher à télécharger
        ' a faire: mémorisation de la date de derniere mise a jour reussie
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
                Trace.WriteLine(DateTime.Now & " " & "la copie de db_progs.db3 vers db_progs.bak a échoué")
                Trace.WriteLine(DateTime.Now & " " & "pas de récupération possible si fichier corrompu")
            Else
                Trace.WriteLine(DateTime.Now & " " & "db_prob.db3 a été copié dans db_prog.bak  pour récup éventuelle")
            End If
        Else
            bdDisGood = False
        End If

        ' copie de sauvegarde du fichier ZGuideTVDotNet.channels.set
        ' au cas ou il y aurait corruption du ficher à télécharger
        sourcefile = ChannelSetPath & "ZGuideTVDotNet.channels.set"
        destinationfile = ChannelSetPath & "ZGuideTVDotNet.channels.bak"
        fichier = New FileInfo(sourcefile)
        If File.Exists(sourcefile) AndAlso fichier.Length > 0 Then
            success = CopierFichier(sourcefile, destinationfile, True)
            If Not success Then
                Trace.WriteLine(DateTime.Now & " " & "la copie de ZGuideTVDotNet.channels.set vers ZGuideTVDotNet.channels.bak a échoué")
                Trace.WriteLine(DateTime.Now & " " & "pas de récupération possible si fichier corrompu")
            Else
                Trace.WriteLine( _
                                 DateTime.Now & " " & "ZGuideTVDotNet.channels.set a été copié dans ZGuideTVDotNet.channels.bak  pour récup éventuelle")
            End If
        End If

        ' copie de sauvegarde du fichier user.config
        ' au cas ou il y aurait corruption du ficher à télécharger
        Dim _
            configZGuideTv As Configuration = _
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)
        sourcefile = configZGuideTv.FilePath
        destinationfile = configZGuideTv.FilePath & ".bak"
        fichier = New FileInfo(sourcefile)
        If File.Exists(sourcefile) AndAlso fichier.Length > 0 Then
            success = CopierFichier(sourcefile, destinationfile, True)
            If Not success Then
                Trace.WriteLine(DateTime.Now & " " & "la copie de user.config vers user.config.bak a échoué")
                Trace.WriteLine(DateTime.Now & " " & "pas de récupération possible si fichier corrompu")
            Else
                Trace.WriteLine( _
                                 DateTime.Now & " " & "user.config a été copié dans user.config.bak  pour récup éventuelle")
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
                    Trace.WriteLine(DateTime.Now & " Base de données inexistante ou non disponible ou chemin invalide ")
                End Try
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " Base de données inexistante ou non disponible ou chemin invalide ")
            End Try
            'End Using

        End If

        If Not File.Exists(AppData & "xmltv.dtd") Then
            CopierFichier(AppPath & "\xmltv.dtd", AppData & "xmltv.dtd")
        End If

        ' 14/01/2009 On regarde le dernier lien sélectionné URL ou Disque dur

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
        Trace.WriteLine(DateTime.Now & " " & "sortie de sub new de FrmMiseajour")

        'Néo 29/05/2010
        If BasePerimee() = True Then
            ButtonDemarrer.PerformClick()
        End If
    End Sub

    Private Sub RemplirUrlCombo(Optional ByVal bdernierEssai As Boolean = False)

        ' Remplissage de la Combo Box qui donne les liens vers les serveurs
        ' pour mise a jour des emissions. Choix du lien a faire dans cette
        ' combo(box)
        ' le fichier NomFichierURL est composé de plusieurs collones séparés par des ";"

        ' 1:      ère(col) : URL()
        ' 2ième col: id de la ligne
        ' 3ième col: Texte à afficher
        ' 4ième col: ==> 0=> on peut télécharger; 1=>visible quand mode débug;2=>ligneque l'on affiche mais qui ne comporte pas de URL

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

                    ' si la ligne correspond à la dernière mise à jours alors on la sélectionne
                    If _
                        [String].Equals(My.Settings.Lienmiseajour, ligne.Split(CChar(";"))(0).Trim(" "c), StringComparison.CurrentCulture) AndAlso _
                        Not [String].Equals(ligne.Split(CChar(";"))(2).Trim(" "c), "2", StringComparison.CurrentCulture) Then
                        If Not (Not ligne.Split(CChar(";"))(0).Trim(" "c) Is Nothing AndAlso String.IsNullOrEmpty(ligne.Split(CChar(";"))(0).Trim(" "c))) Then
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
            WarningURl()

            ' Néo 25/06/2013
            ' Si une url n'est pas sélectionnée on affiche la 1er ligne
            If URLComboBox.Text = Nothing Then
                URLComboBox.SelectedIndex = 0
            End If

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "erreur try catch ligne AAA3")
            Select Case bdernierEssai
                Case True

                    ' Téléchargement sans message d'erreur
                    If _
                        DownloadFile(_serveurUrl & NomFichierUrl, SettingsPath & NomFichierUrl & ".Tmp", 10000, _
                                      1024, _
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
                            (FailUrlFileDownload & Chr(13), _
                             FailUrlFileDownload, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                             MessageBoxDefaultButton.Button1)
                    End If
                Case Else

                    ' ReSharper disable NotAccessedVariable
                    Dim boxUntraceableUrlListFile As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxUntraceableUrlListFile = MessageBox.Show _
                        (UntraceableUrlListFile & Chr(13), _
                         UntraceableUrlListFile, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                         MessageBoxDefaultButton.Button1)
            End Select
        End Try
    End Sub

    Public Function CopierFichier(ByVal fichierSource As String, ByVal fichierDest As String, _
                                   Optional ByVal bEcraser As Boolean = False) As Boolean

        ' Vérifier que le fichier source existe
        If Not File.Exists(fichierSource) Then
          ' ReSharper disable NotAccessedVariable
            Dim boxError As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxError = MessageBox.Show _
                (TheFile & DontExist & Chr(13), _
                 TheFile & DontExist, MessageBoxButtons.OK, MessageBoxIcon.Error, _
                 MessageBoxDefaultButton.Button1)
            Return False
        End If

        ' Si l'utilisateur a déjà choisi le fichier dans le AppData
        ' alors il est inutile de faire une copie
        If [String].Equals(fichierSource, fichierDest, StringComparison.CurrentCulture) Then
            Return True
        End If

        ' Vérifier Si il y a déjà un "FichierDest" de présent
        If File.Exists(fichierDest) Then
            If bEcraser Then
                Try
                    File.Delete(fichierDest)
                Catch ex As Exception
                    ' ReSharper disable NotAccessedVariable
                    Dim boxError As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxError = MessageBox.Show _
                        (ErrorInFileCopy & Chr(13), _
                         ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, _
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

    Private Sub UrlComboBoxSelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles URLComboBox.SelectedValueChanged
        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub UrlComboBoxSelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) _
        Handles URLComboBox.SelectionChangeCommitted
        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub UrlComboBoxTextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles URLComboBox.TextChanged
        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub UrlComboBoxValueMemberChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles URLComboBox.ValueMemberChanged
        If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub ListXmltvfrChoisieMouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ListXMLTVFRChoisie.MouseEnter
        _listDraged = ""
    End Sub

    Private Sub ListViewAllChannelMouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ListViewAllChannel.MouseEnter
        _listDraged = ""
    End Sub

    Private Sub ButtonSupprClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSuppr.Click
        Dim i As Short
        Dim nbElem As Integer = ListXMLTVFRChoisie.Items.Count

        Select Case ListXMLTVFRChoisie.Columns.Count
            Case 0
                ListViewAllChannel.Columns.Add(ChosenChannels & ListViewAllChannel.Items.Count & ")", -2, _
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

        ' rvs75 le 11/09/2009  : visible à False
        ButtonDemarrer.Visible = False
        ButtonAppliquer.Visible = False
    End Sub

    Private Sub RadioButtonXmlPathCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RadioButtonXmlPath.CheckedChanged

        ' 06/07/2011 Modifié par Néo
        If RadioButtonXmlPath.Checked Then
            ButtonDemarrer.Enabled = True
        Else
            ButtonDemarrer.Enabled = False
        End If

    End Sub

    Private Sub RadioButton1CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RadioButtonDownload.CheckedChanged

        ' 06/07/2011 Modifié par Néo
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
                    <> _
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

    Private Function RechercherLogo(ByVal channelRen As String) As String
        '-------------------------------------------------------------------------------------------------
        'la routine renvoit ,sauf mention contraire, la variable "sortie" de type string  via l instruction return
        '-------------------------------------------------------------------------------------------------
        'rvs 30/05/2010 : essaie de récuperer le logo qui est renseigné dans la bdd en premier
        'pas très propre mais fonctionnel...

        channelRen = channelRen.ToLower()
        channelRen =
            channelRen.Replace(".", "").Replace("-", "").Replace("\", "").Replace("/", "").Replace("ü", "u").Replace(
                "ß", "ss").Replace("'", "").Replace("ï", "i").Replace("î", "i").Replace("ô", "o").Replace("ö", "o").
                Replace("ê", "e").Replace("&", "").Replace("_", "").Replace("(", "").Replace(")", "").Replace("+", "")

        Dim sortie As String
        If _originalList.Length > 0 Then
            Dim memlogochannel As String
            For Each channel As ChannelList In _originalList
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
        ' pouvoir être réutiliser si 'il y a un noeud enfant "icon"
        If Directory.GetFiles(LogosPath, channelRen & ".*").Length > 0 Then
            If File.Exists(LogosPath & channelRen & ".gif") Then
                ImageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & channelRen & _
                                                           ".gif"))
                sortie = channelRen & ".gif"
            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                ImageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & channelRen & _
                                                           ".jpg"))
                sortie = channelRen & ".jpg"
            Else

                ' Modifier le 05092009
                Dim memo As String
                memo = CreerLogo(channelRen & ".jpg")
                ImageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & _
                                                           memo))
                sortie = memo
            End If
        Else
            channelRen = channelRen.Replace("é", "e").Replace("è", "e")

            ' Modifier le 25092009
            If File.Exists(LogosPath & channelRen & ".gif") Then
                ImageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & channelRen & _
                                                           ".gif"))
                sortie = channelRen & ".gif"
            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                ImageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & channelRen & _
                                                           ".jpg"))
                sortie = channelRen.Replace(" ", "") & ".jpg"
            Else

                ' Modifier le 01092009
                channelRen = channelRen.Replace(" ", "")
                If File.Exists(LogosPath & channelRen & ".gif") Then
                    ImageListSmall.Images.Add( _
                                               Image.FromFile( _
                                                               LogosPath & channelRen & _
                                                               ".gif"))
                    sortie = channelRen & ".gif"
                ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                    ImageListSmall.Images.Add( _
                                               Image.FromFile( _
                                                               LogosPath & channelRen & _
                                                               ".jpg"))
                    sortie = channelRen & ".jpg"
                Else
                    channelRen = channelRen.Replace("+", "plus")
                    If File.Exists(LogosPath & channelRen & ".gif") Then
                        ImageListSmall.Images.Add( _
                                                   Image.FromFile( _
                                                                   LogosPath & _
                                                                   channelRen & ".gif"))
                        sortie = channelRen & ".gif"
                    ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                        ImageListSmall.Images.Add( _
                                                   Image.FromFile( _
                                                                   LogosPath & _
                                                                   channelRen & ".jpg"))
                        sortie = channelRen & ".jpg"
                    Else
                        channelRen = _
                            channelRen.Replace("television", "TV").Replace( _
                                                                             "Television", _
                                                                             "TV"). _
                                Replace("TELEVISION", "TV")
                        If File.Exists(LogosPath & channelRen & ".gif") Then
                            ImageListSmall.Images.Add( _
                                                       Image.FromFile( _
                                                                       LogosPath & _
                                                                       channelRen & _
                                                                       ".gif"))
                            sortie = channelRen & ".gif"
                        ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                            ImageListSmall.Images.Add( _
                                                       Image.FromFile( _
                                                                       LogosPath & _
                                                                       channelRen & _
                                                                       ".jpg"))
                            sortie = channelRen & ".jpg"
                        Else
                            channelRen = _
                                channelRen.Replace("tv", "").Replace("Tv", "").Replace( _
                                                                                          "TV", _
                                                                                          "")
                            If File.Exists(LogosPath & channelRen & ".gif") Then
                                ImageListSmall.Images.Add( _
                                                           Image.FromFile( _
                                                                           LogosPath & _
                                                                           channelRen & _
                                                                           ".gif"))
                                sortie = channelRen & ".gif"
                            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                                ImageListSmall.Images.Add( _
                                                           Image.FromFile( _
                                                                           LogosPath & _
                                                                           channelRen & _
                                                                           ".jpg"))
                                sortie = channelRen & ".jpg"
                            Else
                                channelRen = channelRen.Replace("plus", "")
                                If File.Exists(LogosPath & channelRen & ".gif") Then
                                    ImageListSmall.Images.Add( _
                                                               Image.FromFile( _
                                                                               LogosPath & _
                                                                               channelRen & _
                                                                               ".gif"))
                                    sortie = channelRen & ".gif"
                                ElseIf File.Exists(LogosPath & channelRen & ".jpg") _
                                    Then
                                    ImageListSmall.Images.Add( _
                                                               Image.FromFile( _
                                                                               LogosPath & _
                                                                               channelRen & _
                                                                               ".jpg"))
                                    sortie = channelRen & ".jpg"
                                Else
                                    ' Modifier le 05092009
                                    Dim memo As String
                                    memo = CreerLogo(channelRen & ".jpg")
                                    ImageListSmall.Images.Add( _
                                                               Image.FromFile( _
                                                                               LogosPath & _
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

    Private Sub TextBoxPathXmlTextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextBoxPathXml.TextChanged
        ButtonDemarrer.Visible = True
    End Sub

    Private Sub ButtonEditClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEdit.Click

        Process.Start("notepad.exe", UrlPath & NomFichierUrl)
        Close()
    End Sub

    Private Sub Button1Click(sender As Object, e As EventArgs) Handles ButtonHelpMiseaJour.Click

        Try

            ' Modifié par Néo le 13/02/2011
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://zguidetv.codeplex.com") Then

                Close()

                If [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then

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
                boxNoConnection = _
                    MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1, _
                                    Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException
            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection = _
                MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1, _
                                 Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub CheckBoxAutoRestartManualUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAutoRestartManualUpdate.CheckedChanged

        If CheckBoxAutoRestartManualUpdate.Checked = True Then
            My.Settings.AutoRestartManualUpdate = True
        Else
            My.Settings.AutoRestartManualUpdate = False
        End If
        My.Settings.Save()
    End Sub
End Class


