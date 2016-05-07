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

Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Drawing.Imaging
Imports System.Xml
Imports System.Net
Imports System.Threading
Imports System.Configuration
Imports ZGuideTV.SQLiteWrapper
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Globalization
Imports Microsoft.DirectX
Imports Microsoft.DirectX.AudioVideoPlayback

#End Region

Public Class Miseajour
    Public IndexdInsertion As Integer
    Public ButtonToutClick As String

    Public ReadOnly CollectionChannels As New Collection

    ' contient les arrayOnechannel
    Public ReadOnly CollectionSelectChannels As New Collection
    Private Const NomFichierUrl As String = "ZGuideTVDotNet.url.set"
    Private ReadOnly _tableTypeUrl(100) As String
    Private ReadOnly _tableUrlUrl(100) As String
    Public SelectedUrl As String
    Private _serveurUrl As String = "http://zguidetv.tuxfamily.org/"
    Private _listDraged As String = ""

#Region "Property"

    Private _messageBoxUrlChecked As String

    Public Property MessageBoxUrlChecked As String
        Get
            Return _messageBoxUrlChecked
        End Get
        Set(ByVal value As String)
            _messageBoxUrlChecked = Value
        End Set
    End Property

    Private _messageBoxUrlChecked1 As String

    Public Property MessageBoxUrlChecked1 As String
        Get
            Return _messageBoxUrlChecked1
        End Get
        Set(ByVal value As String)
            _messageBoxUrlChecked1 = Value
        End Set
    End Property

    Private _messageBoxUrlCheckedTitre As String

    Public Property MessageBoxUrlCheckedTitre As String
        Get
            Return _messageBoxUrlCheckedTitre
        End Get
        Set(ByVal value As String)
            _messageBoxUrlCheckedTitre = Value
        End Set
    End Property

    Private _messageBoxFileNotExist As String

    Public Property MessageBoxFileNotExist As String
        Get
            Return _messageBoxFileNotExist
        End Get
        Set(ByVal value As String)
            _messageBoxFileNotExist = Value
        End Set
    End Property

    Private _messageBoxFileNotExist1 As String

    Public Property MessageBoxFileNotExist1 As String
        Get
            Return _messageBoxFileNotExist1
        End Get
        Set(ByVal value As String)
            _messageBoxFileNotExist1 = Value
        End Set
    End Property

    Private _messageBoxFileNotExistTitre As String

    Public Property MessageBoxFileNotExistTitre As String
        Get
            Return _messageBoxFileNotExistTitre
        End Get
        Set(ByVal value As String)
            _messageBoxFileNotExistTitre = Value
        End Set
    End Property

    Private _messageBoxDirChecked As String

    Public Property MessageBoxDirChecked As String
        Get
            Return _messageBoxDirChecked
        End Get
        Set(ByVal value As String)
            _messageBoxDirChecked = Value
        End Set
    End Property

    Private _messageBoxDirChecked1 As String

    Public Property MessageBoxDirChecked1 As String
        Get
            Return _messageBoxDirChecked1
        End Get
        Set(ByVal value As String)
            _messageBoxDirChecked1 = Value
        End Set
    End Property

    Private _messageBoxDirCheckedTitre As String

    Public Property MessageBoxDirCheckedTitre As String
        Get
            Return _messageBoxDirCheckedTitre
        End Get
        Set(ByVal value As String)
            _messageBoxDirCheckedTitre = Value
        End Set
    End Property

    Private _errorInChannelListRecovery As String

    Public Property ErrorInChannelListRecovery As String
        Get
            Return _errorInChannelListRecovery
        End Get
        Set(ByVal value As String)
            _errorInChannelListRecovery = Value
        End Set
    End Property

    Private _noUrlUpdate As String

    Public Property NoUrlUpdate As String
        Get
            Return _noUrlUpdate
        End Get
        Set(ByVal value As String)
            _noUrlUpdate = Value
        End Set
    End Property

    Private _invalidUrl As String

    Public Property InvalidUrl As String
        Get
            Return _invalidUrl
        End Get
        Set(ByVal value As String)
            _invalidUrl = Value
        End Set
    End Property

    Private _untraceableFile As String

    Public Property UntraceableFile As String
        Get
            Return _untraceableFile
        End Get
        Set(ByVal value As String)
            _untraceableFile = Value
        End Set
    End Property

    Private _invalidFile As String

    Public Property InvalidFile As String
        Get
            Return _invalidFile
        End Get
        Set(ByVal value As String)
            _invalidFile = Value
        End Set
    End Property

    Private _errorInUpdate As String

    Public Property ErrorInUpdate As String
        Get
            Return _errorInUpdate
        End Get
        Set(ByVal value As String)
            _errorInUpdate = Value
        End Set
    End Property

    Private _errorInXmlCopy As String

    Public Property ErrorInXmlCopy As String
        Get
            Return _errorInXmlCopy
        End Get
        Set(ByVal value As String)
            _errorInXmlCopy = Value
        End Set
    End Property

    Private _errorInFileCopy As String

    Public Property ErrorInFileCopy As String
        Get
            Return _errorInFileCopy
        End Get
        Set(ByVal value As String)
            _errorInFileCopy = Value
        End Set
    End Property

    Private _errorInUnzip As String

    Public Property ErrorInUnzip As String
        Get
            Return _errorInUnzip
        End Get
        Set(ByVal value As String)
            _errorInUnzip = Value
        End Set
    End Property

    Private _wrongFileName As String

    Public Property WrongFileName As String
        Get
            Return _wrongFileName
        End Get
        Set(ByVal value As String)
            _wrongFileName = Value
        End Set
    End Property

    Private _failUrlFileDownload As String

    Public Property FailUrlFileDownload As String
        Get
            Return _failUrlFileDownload
        End Get
        Set(ByVal value As String)
            _failUrlFileDownload = Value
        End Set
    End Property

    Private _untraceableUrlListFile As String

    Public Property UntraceableUrlListFile As String
        Get
            Return _untraceableUrlListFile
        End Get
        Set(ByVal value As String)
            _untraceableUrlListFile = Value
        End Set
    End Property

    Private _theFile As String

    Public Property TheFile As String
        Get
            Return _theFile
        End Get
        Set(ByVal value As String)
            _theFile = Value
        End Set
    End Property

    Private _dontExist As String

    Public Property DontExist As String
        Get
            Return _dontExist
        End Get
        Set(ByVal value As String)
            _dontExist = Value
        End Set
    End Property

    Private _protectedFile As String

    Public Property ProtectedFile As String
        Get
            Return _protectedFile
        End Get
        Set(ByVal value As String)
            _protectedFile = Value
        End Set
    End Property

    Private _chosenChannels As String

    Public Property ChosenChannels As String
        Get
            Return _chosenChannels
        End Get
        Set(ByVal value As String)
            _chosenChannels = Value
        End Set
    End Property

    Private _availableChannels As String

    Public Property AvailableChannels As String
        Get
            Return _availableChannels
        End Get
        Set(ByVal Value As String)
            _availableChannels = Value
        End Set
    End Property

    Private _choseFile As String

    Public Property ChoseFile As String
        Get
            Return _choseFile
        End Get
        Set(ByVal value As String)
            _choseFile = Value
        End Set
    End Property

    Private _invalidChoice As String

    Public Property InvalidChoice As String
        Get
            Return _invalidChoice
        End Get
        Set(ByVal value As String)
            _invalidChoice = Value
        End Set
    End Property

    Private _messageBoxListXmltvfrChoisie As String

    Public Property MessageBoxListXmltvfrChoisie As String
        Get
            Return _messageBoxListXmltvfrChoisie
        End Get
        Set(ByVal value As String)
            _messageBoxListXmltvfrChoisie = Value
        End Set
    End Property

    Private _messageBoxListXmltvfrChoisie1 As String

    Public Property MessageBoxListXmltvfrChoisie1 As String
        Get
            Return _messageBoxListXmltvfrChoisie1
        End Get
        Set(ByVal value As String)
            _messageBoxListXmltvfrChoisie1 = Value
        End Set
    End Property

    Private _messageBoxListXmltvfrChoisieTitre As String

    Public Property MessageBoxListXmltvfrChoisieTitre As String
        Get
            Return _messageBoxListXmltvfrChoisieTitre
        End Get
        Set(ByVal value As String)
            _messageBoxListXmltvfrChoisieTitre = Value
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
#End Region

    Private ReadOnly _os As OperatingSystem = Environment.OSVersion

    ' 09/03/2009 Griser et désactiver la croix rouge de la form
    Private Const CsNoclose As Integer = &H200

    Private Function CreerLogo(ByVal nomlogo As String) As String

        ' variable contenant la chaine qui sera écrit dans le logo
        Dim chainedanslogo As String = nomlogo.ToUpper.Substring(0, nomlogo.IndexOf("."))

        ' pour les noms de chaine contenant un caractère interdit dans un nom de fichier on renvoie "vide.jpg"
        Dim invalidFileNameChars() As Char = Path.GetInvalidFileNameChars()
        For Each invalidFileNameChar As Char In invalidFileNameChars
            If nomlogo.Contains(invalidFileNameChar.ToString(CultureInfo.CurrentCulture)) Then
                Return "vide.jpg"
            End If
        Next

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

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CsNoclose
            Return cp
        End Get
    End Property

    Private Structure ChannelList
        Public Name As String
        Public Id As String
        Public Ordering As Integer
        Public Logo As String
        Public KTv As Integer

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Private ReadOnly _originalList(1000) As ChannelList
    Private ReadOnly _nbChannels As Integer = -1

    Public Sub ParseXmlChannels(ByVal pathXml As String)

        ' Y a t il des erreurs a signaler au programme appelant?
        Dim xmlTvDoc As XmlDocument = New XmlDocument()
        Dim elementChannel As XmlNodeList
        Dim noeud, noeudEnf As XmlNode
        Dim channelId As String
        Dim channelName As String = ""
        Dim logoUrl As String = ""
        Dim logoFilename As String = ""
        Dim icountChannels As Integer = 0
        Dim chaineDoublon As Integer

        Dim channelRen As String = ""

        Dim newList(1000) As ChannelList
        Dim i As Integer

        Trace.WriteLine(DateTime.Now & " Chargement des Chaînes dans frmmiseajour")
        imageListSmall.ImageSize = New Size(38, 29)

        Try
            CollectionSelectChannels.Clear()
            CollectionChannels.Clear()
            Trace.WriteLine(DateTime.Now & " " & pathXml)
            xmlTvDoc.Load(pathXml)

            elementChannel = xmlTvDoc.DocumentElement.GetElementsByTagName("channel")
            ListViewAllChannel.Columns.Add(AvailableChannels & elementChannel.Count & ")", -2, _
                                            HorizontalAlignment.Left)
            ListViewAllChannel.Columns.Item(0).Width = ListViewAllChannel.Width - 22
            ' ListViewAllChannel.Sorting = SortOrder.Ascending
            For Each noeud In elementChannel
                channelId = noeud.Attributes(0).Value
                arrayOnechannel(0) = channelId
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

                                ' la ligne de code de Ronaldo : ChannelRen = ChannelName.Replace("\", "").Replace("/", "")
                                ' ou a remplacer par :
                                ' la ligne de code de rvs75 : ChannelRen = ChannelName.Replace("\", "").Replace("/", "").Replace(">", "").Replace("<", "").Replace("&", "").Replace("'", "").Replace("""", "")

                                ' Modifié le 10/09/2009 rvs75                                                
                                listViewMyItem.Text = channelName.ToString
                                listViewMyItem.SubItems.Add("")
                                ListViewAllChannel.Items.Add(listViewMyItem)

                                ' comptage des noeuds enfants qui ont un tag "icon"
                                Dim cptIcon As Integer = 0
                                For t As Integer = 0 To noeud.ChildNodes.Count - 1
                                    If noeud.ChildNodes.ItemOf(t).Name = "icon" Then
                                        cptIcon += 1
                                    End If
                                Next

                                ' choix si il y a ou pas un noeud enfant "icon"
                                Select Case cptIcon
                                    Case 0

                                        ' rvs 03/11/2009 tous le code ici a été externaliser dans la function "Recherche_logo
                                        ' afin de pouvoir être réutiliser si 'il y a un noeud enfant "icon"
                                        arrayOnechannel(2) = RechercherLogo(channelRen)
                                End Select
                            End If

                        Case Else
                            If (noeudEnf.LocalName = "icon") Then
                                Dim wc As New WebClient
                                Dim entree As String
                                Dim posPoint As Integer
                                Dim posSlash As Integer
                                ' Dim longueur As Integer
                                Dim s2 As String
                                entree = noeudEnf.OuterXml
                                posPoint = entree.LastIndexOf(".", StringComparison.CurrentCulture)
                                s2 = entree.Substring(0, posPoint + 4)

                                ' fichier type .jpg ou .gif ou .xxx
                                posSlash = s2.LastIndexOf("/", StringComparison.CurrentCulture)
                                logoFilename = s2.Substring(posSlash + 1, s2.Length - posSlash - 1)

                                If Not File.Exists(LogosPath & logoFilename) Then
                                    Try
                                        wc.DownloadFile(logoUrl, LogosPath & logoFilename)
                                    Catch
                                        arrayOnechannel(2) = RechercherLogo(channelRen)
                                        Trace.WriteLine(" erreur try catch")
                                    End Try
                                Else
                                    arrayOnechannel(2) = RechercherLogo(channelRen)
                                End If
                            End If
                    End Select
                    With newList(i - 1)
                        .Id = channelId
                        .Name = channelName.ToString
                        .Logo = logoFilename
                    End With
                Next noeudEnf

                arrayOnechannel(1) = channelName
                CollectionChannels.Add(arrayOnechannel, arrayOnechannel(1))
                ReDim Preserve arrayOnechannel(2)
                listViewMyItem.ImageIndex = icountChannels
                ListViewAllChannel.SmallImageList = imageListSmall
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
                'Dim imageListSmall2 As New ImageList()
                Do While i <= _nbChannels
                    j = 0
                    Do While j <= icountChannels AndAlso Not bTrouve
                        bTrouve = (newList(j).Id = _originalList(i).Id)
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
                        bTrouve = (newList(j).Id = _originalList(i).Id)
                        If newList(j).Id <> "****-1****" AndAlso Not bTrouve Then
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
                    .SmallImageList = imageListSmall
                    ListViewAllChannel.Sorting = SortOrder.Ascending
                    .Columns.Item(0).Text = ChosenChannels & .Items.Count & ")"
                End With

                If ListXMLTVFRChoisie.Items.Count > 0 Then
                    ButtonAppliquer.Location = ButtonDemarrer.Location
                    ButtonDemarrer.Visible = False
                    ButtonAppliquer.Visible = True
                End If

            Catch ex As Exception
                ' Dim FenMessage As FrmMessage = New FrmMessage("Erreur lors de la récuperation de l'ancienne liste des chaines", MsgBoxStyle.Critical, True)
                Dim fenMessage As New Message(ex.Message, MsgBoxStyle.Critical, True)
                fenMessage.ShowDialog()
            End Try
            ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & ")"

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " Erreur lors de la récupération de la liste des chaines dans frmmiseajour")
            Trace.WriteLine(DateTime.Now & " " & ex.Message)
            Trace.WriteLine(DateTime.Now & " " & ex.ToString)

            Dim fenMessage As New Message(ErrorInChannelListRecovery, MsgBoxStyle.Critical, True)
            fenMessage.ShowDialog()

        End Try
    End Sub

    ' CreateMyListView
    Private Sub ButtonOpenfileClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOpenfile.Click
        OpenFileDialogXml.ShowDialog()
        If (TextBoxPathXml.Text.Trim(" "c).Length) > 0 Then '02/10/07
            ButtonDemarrer.Enabled = True
        End If
    End Sub

    Private Sub FrmMiseajourDisposed(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Disposed

        ReDim arrayOnechannel(2)
        Try
            Mainform.Timer_minute.Start()
        Catch
            Trace.WriteLine(DateTime.Now & " erreur dans frm mise à jour disposed")
        End Try
    End Sub

    Private Sub FrmMiseajour_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        imageListSmall.Images.Clear()
        Dim fichierInfo As New FileInfo(BDDPath & "db_progs.db3")
        If My.Computer.FileSystem.FileExists(BDDPath & "db_progs.db3") Then
            Dim tailleFichier As Integer = CInt(fichierInfo.Length)
            tailleFichier = CInt(tailleFichier / 1024)
            If tailleFichier < 4 Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub FrmMiseajour_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
        Handles Me.FormClosing
        ' a remplir pour pallier aux fermetures intempestives du formulaire
    End Sub

    Private Sub FrmMiseajourLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        imageListSmall.Images.Clear()
        Trace.WriteLine(DateTime.Now & " " & "entree dans frm mise a jour Load")

        If Not My.Settings.UrlUpdate Then
            ButtonEdit.Enabled = True
        End If

        Try
            ' On regarde quel langue utiliser 22/08/2008
            LanguageCheck(7)
            Mainform.Panel_titre_maintenant.Text = Maintenant_et_heure
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
                'Dim FenMessage As New FrmMessage(NoURLUpdate, MsgBoxStyle.Critical, True)
                'FenMessage.ShowDialog()
                RemplirUrlCombo()
            End If

        Else
            RemplirUrlCombo()
        End If
        'URLComboBox.SelectedIndex = 1
        Trace.WriteLine(DateTime.Now & " " & "sortie de frm mise a jour Load")
    End Sub

    Private Sub ButtonAnnulerClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAnnuler.Click

        Close()
    End Sub

    Private Sub OpenFileDialogXmlFileOk(ByVal sender As Object, ByVal e As CancelEventArgs) _
        Handles OpenFileDialogXml.FileOk

        XmlTvName = OpenFileDialogXml.FileName
        TextBoxPathXml.Text = XmlTvName.ToString

        ' 14/01/2009 On sauvegarde l'état des radio button et le lien de mise a jour
        'With My.Settings
        '.URLChecked = False
        '.DIRChecked = True
        '.Cheminmiseajour = TextBoxPathXml.Text
        '.Save()
        ' End With
    End Sub

    Private Sub ButtonDemarrerClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDemarrer.Click

        ' Néo 22/01/2012
        ' Le fichier de mise à jour sur le disque dur n'existe pas
        If RadioButtonXmlPath.Checked Then
            If Not File.Exists(TextBoxPathXml.Text) Then

                Dim boxFileNotExist As DialogResult
                boxFileNotExist = MessageBox.Show _
                    (MessageBoxFileNotExist & Chr(13) & MessageBoxFileNotExist1, _
                     MessageBoxFileNotExistTitre, MessageBoxButtons.OK, MessageBoxIcon.Information, _
                     MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        ButtonDemarrer.Enabled = False

        ' Ajout de Ronaldo1 le 08/01/2008
        ' On teste si on a choisie une URL pour éviter que cela plante
        If URLComboBox.SelectedIndex > 0 AndAlso RadioButtonDownload.Checked Then
            _serveurUrl = _tableUrlUrl(URLComboBox.SelectedIndex)

            ' Ajout de Néo le 14/02/2010
            ' On teste l'URL est accessible pour éviter que cela plante
            If Not IsNetConnectOnline() AndAlso Not ConnectionAvailable.ConnectionAvailable(_serveurUrl) Then

                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1, Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
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
        Dim extention As String = ""
        Dim fileName As String = ""
        Dim filename2 As String = ""

        Dim xmlaTélécharger As String

        Dim yesNo As Boolean = True

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

                ' Si il y a une erreur alors c'est que l'URL est invalide
                bError = True
                ButtonDemarrer.Visible = True
                ButtonDemarrer.Enabled = True
                Dim fenMessage As New Message(InvalidURL, MsgBoxStyle.Critical, True)
                fenMessage.ShowDialog()
            End Try

            If Not bError Then

                ' on télécharge le fichier dans le appdata
                If DownloadFile(xmlaTélécharger, AppData & fileName, 100000) Then
                    XmlTvName = AppData & fileName
                Else
                    Dim fenMessage As New Message(UntraceableFile, MsgBoxStyle.Critical, True)
                    fenMessage.ShowDialog()
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
                'Dim FenMessage As New Message(InvalidFile, MsgBoxStyle.Critical, True)
                'FenMessage.ShowDialog()
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
                                Dim _
                                    fenMessage As _
                                        New Message(ErrorInUpdate, ErrorInXmlCopy, MsgBoxStyle.Critical, True)
                                fenMessage.ShowDialog()

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
                                            p = Nothing
                                        End If
                                    End Try

                                    Dim xmlFile() As String = Directory.GetFiles(AppData, "*.XML")

                                    If xmlFile.Length > 0 Then
                                        XmlTvName = xmlFile(0)
                                        FichierProgramme = XmlTvName
                                        If File.Exists(AppData & "Flag.info") Then

                                            Try

                                                Dim _
                                                    information As _
                                                        New StreamReader(AppData & "Flag.info", UnicodeEncoding.Default)

                                                Dim style As MsgBoxStyle
                                                Dim msg As String
                                                Dim titre As String

                                                Dim reponse As MsgBoxResult
                                                style = MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground
                                                titre = information.ReadLine
                                                msg = information.ReadToEnd

                                                If msg.ToString <> Nothing Then
                                                    Application.DoEvents()
                                                    Thread.Sleep(500)
                                                    Dim _
                                                        fenMessage As Message = _
                                                            New Message(titre.ToString, msg.ToString, style)
                                                    fenMessage.ShowDialog()
                                                    reponse = fenMessage.Reponse
                                                End If

                                                information.Close()
                                                File.Delete(AppData & "Flag.info")
                                            Catch ex As Exception
                                                Trace.WriteLine(DateTime.Now & " " & "erreur try catch ligne XXXX")
                                            End Try
                                        End If

                                        If File.Exists(AppData & "Flag.Warning") Then

                                            Try
                                                Dim _
                                                    information As _
                                                        New StreamReader(AppData & "Flag.Warning", _
                                                                          UnicodeEncoding.Default)

                                                Dim style As MsgBoxStyle
                                                Dim msg As String
                                                Dim titre As String
                                                Dim reponse As MsgBoxResult
                                                style = MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground
                                                titre = information.ReadLine
                                                msg = information.ReadToEnd

                                                If msg <> Nothing Then
                                                    Application.DoEvents()
                                                    Thread.Sleep(500)
                                                    Dim _
                                                        fenMessage As _
                                                            New Message(titre.ToString, msg.ToString, style)
                                                    fenMessage.ShowDialog()
                                                    reponse = fenMessage.Reponse

                                                    Select Case reponse
                                                        Case MsgBoxResult.Ok, MsgBoxResult.Yes
                                                            yesNo = True
                                                        Case Else
                                                            yesNo = False
                                                    End Select
                                                End If

                                                information.Close()
                                                File.Delete(AppData & "Flag.Warning")

                                            Catch ex As Exception
                                                Trace.WriteLine(DateTime.Now & " " & "erreur try catch ligne YYYY")
                                            End Try
                                        End If

                                        If File.Exists(AppData & "Flag.Error") Then
                                            Try
                                                Dim _
                                                    information As _
                                                        New StreamReader(AppData & "Flag.Error", _
                                                                          UnicodeEncoding.Default)

                                                Dim style As MsgBoxStyle
                                                Dim msg As String
                                                Dim titre As String
                                                Dim reponse As MsgBoxResult
                                                style = MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground
                                                titre = information.ReadLine
                                                msg = information.ReadToEnd
                                                yesNo = False
                                                If msg <> Nothing Then
                                                    Application.DoEvents()
                                                    Thread.Sleep(500)
                                                    Dim _
                                                        fenMessage As _
                                                            New Message(titre.ToString, msg.ToString, style)
                                                    fenMessage.ShowDialog()
                                                    reponse = fenMessage.Reponse
                                                End If

                                                information.Close()
                                                File.Delete(AppData & "Flag.Error")
                                            Catch ex As Exception
                                                Trace.WriteLine(DateTime.Now & " " & "erreur try catch ligne YYYYZ")
                                            End Try
                                        End If

                                        If File.Exists(AppData & "URL.Flag") Then
                                            Try
                                                Dim _
                                                    information As _
                                                        New StreamReader(AppData & "URL.Flag", UnicodeEncoding.Default)

                                                Dim style As MsgBoxStyle
                                                Dim reponse As MsgBoxResult
                                                Dim URL As String
                                                Dim msg As String
                                                URL = information.ReadLine
                                                style = MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or _
                                                        MsgBoxStyle.MsgBoxSetForeground
                                                msg = "Voulez-vous visiter " & URL & " ?"
                                                If URL.ToUpper.StartsWith("HTTP://", StringComparison.CurrentCulture) Then
                                                    If Not URL.ToUpper.EndsWith(".EXE", StringComparison.CurrentCulture) Then
                                                        Application.DoEvents()
                                                        Thread.Sleep(1000)
                                                        Dim fenMessage As New Message(URL.ToString, msg.ToString)
                                                        fenMessage.ShowDialog()
                                                        reponse = fenMessage.Reponse
                                                        Select Case reponse
                                                            Case MsgBoxResult.Yes
                                                                Process.Start(URL).WaitForExit(10)
                                                        End Select
                                                    End If
                                                End If
                                                information.Close()
                                                File.Delete(AppData & "URL.Flag")
                                            Catch ex As Exception
                                                Trace.WriteLine(DateTime.Now & " " & "erreur try catch ligne YYYYZZZ")
                                            End Try
                                        End If

                                        If yesNo Then

                                            ' à corriger si nécessaire par Ronaldo
                                            ParseXmlChannels(XmlTvName)
                                        End If

                                    Else
                                        Dim _
                                            fenMessage As _
                                                New Message(ErrorInUpdate, _
                                                                ErrorInFileCopy & " " & AppData & fileName, _
                                                                MsgBoxStyle.Critical, True)
                                        fenMessage.ShowDialog()

                                    End If

                                Catch ex As Exception
                                    Dim _
                                        fenMessage As _
                                            New Message(ErrorInUpdate, ErrorInUnzip, MsgBoxStyle.Critical, True)
                                    fenMessage.ShowDialog()
                                End Try
                            Else
                                Dim _
                                    fenMessage As _
                                        New Message(ErrorInUpdate, ErrorInFileCopy & " " & XmlTvName, _
                                                        MsgBoxStyle.Critical, True)
                                fenMessage.ShowDialog()

                            End If
                    End Select
                End If

            Catch ex As Exception

                Dim _
                    fenMessage As _
                        New Message(ErrorInUpdate, WrongFileName & " " & XmlTvName, MsgBoxStyle.Critical, True)

                fenMessage.ShowDialog()
            End Try

            Cursor = Cursors.Default
            ButtonDemarrer.Enabled = False
            ButtonTout.Enabled = True
            ButtonSuppr.Enabled = True
        End If
    End Sub

    Private Sub ButtonTout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonTout.Click
        Dim i As Short
        Dim nbElem As Integer = ListViewAllChannel.Items.Count
        'ListXMLTVFRChoisie.Columns.Add("Chaines choisies (" & ListViewAllChannel.Items.Count & ")", -2, HorizontalAlignment.Left)
        'ListXMLTVFRChoisie.Sorting = SortOrder.Ascending

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
                ListXMLTVFRChoisie.SmallImageList = imageListSmall
            End If
        Next i
        Dim itm As New ListViewItem
        For Each itm In ListXMLTVFRChoisie.Items
            If CollectionChannels.Contains(itm.Text) Then
                arrayOnechannel = DirectCast(CollectionChannels.Item(itm.Text), String())
                CollectionSelectChannels.Add(arrayOnechannel)
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

            Dim BoxMiseaJour As DialogResult
            BoxMiseaJour = MessageBox.Show _
                (MessageBoxListXMLTVFRChoisie & Chr(13) & MessageBoxListXMLTVFRChoisie1, _
                 MessageBoxListXMLTVFRChoisieTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                 MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If ButtonAppliquer.Enabled = False Then
            Exit Sub
        End If

        ' 290409 pallier au double clic sur bouton mise a jour manuelle 
        ButtonAppliquer.Enabled = False

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
                (MessageBoxURLChecked & Chr(13) & MessageBoxURLChecked1, _
                 MessageBoxURLCheckedTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
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
        traitement_appliquer()

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

            Dim boxMiseaJourManuelle As DialogResult
            boxMiseaJourManuelle = MessageBox.Show _
                ( _
                 MessageBoxMiseaJourDone & Chr(13) & MessageBoxMiseaJour1Done _
                 , MessageBoxMiseaJourTitreDone, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                 MessageBoxDefaultButton.Button1)

            If boxMiseaJourManuelle = DialogResult.Yes Then
                My.Settings.BddExists = True
                My.Settings.Save()
                Mainform.NotifyIcon1.Dispose()
                Mainform.tl.Close()

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
            Mainform.NotifyIcon1.Dispose()
            Mainform.tl.Close()

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

        ' Loop though the SelectedItems collection for the source.
        For Each myItem In ListViewAllChannel.SelectedItems

            ' Add the ListViewItem to the array of ListViewItems.
            myItems(i) = myItem
            i += 1
        Next myItem

        ' Create a DataObject containg the array of ListViewItems.
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

        ' Loop though the SelectedItems collection for the source.
        For Each myItem In ListXMLTVFRChoisie.SelectedItems

            ' Add the ListViewItem to the array of ListViewItems.
            myItems(i) = myItem
            i += 1
        Next myItem

        ' Create a DataObject containg the array of ListViewItems.
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

        ' Check for the custom DataFormat ListViewItem array.
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

        ' Check for the custom DataFormat ListViewItem array.
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
                    Dim i As Integer = 0
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
                        ListViewAllChannel.SmallImageList = imageListSmall
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
            Dim fenMessage As New Message(ex.Message, MsgBoxStyle.Critical, True)
            fenMessage.ShowDialog()
        End Try
    End Sub

    Private Sub ListViewDragDrop2(ByVal sender As Object, ByVal e As  _
                                       DragEventArgs) Handles ListXMLTVFRChoisie.DragDrop

        Dim i As Integer = 0

        'Dim x As Integer = 5
        'Dim y As Integer = MousePosition.Y - ListXMLTVFRChoisie.Location.Y - Me.Location.Y


        Dim nTemp As Integer = 0
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

                        'Numitem = ListXMLTVFRChoisie.GetItemAt(x, y).Index
                    Catch ex As Exception
                        numitem = 0
                        Trace.WriteLine(" erreur try catch ligne AAA")
                    End Try

                    'If y > 0 AndAlso x > 0 AndAlso Numitem < 1 Then
                    '    nTemp = ListXMLTVFRChoisie.Items.Count
                    '    If nTemp > 0 Then
                    '        If ListXMLTVFRChoisie.Items.Item(nTemp - 1).Position.Y < y Then
                    '            Numitem = nTemp
                    '        Else
                    '            Numitem = 0
                    '        End If
                    '    Else
                    '        Numitem = 0
                    '    End If
                    'End If

                    For i = 0 To myItems.GetUpperBound(0)
                        Dim itmListViewAllChannel As New ListViewItem
                        itmListViewAllChannel.Text = myItems(i).Text
                        itmListViewAllChannel.SubItems.Add("")
                        ListXMLTVFRChoisie.Items.Insert(numitem + i, itmListViewAllChannel)
                        itmListViewAllChannel.ImageIndex = myItems(i).ImageIndex
                        ListXMLTVFRChoisie.SmallImageList = imageListSmall
                        ListViewAllChannel.Items.Remove(ListViewAllChannel.SelectedItems.Item(0))
                    Next i
                Case Else
                    Dim _
                        myItems() As ListViewItem = _
                            DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem()"), ListViewItem())
                    Dim numitem As Integer

                    Try
                        Dim targetPoint As Point = ListXMLTVFRChoisie.PointToClient(New Point(e.X, e.Y))                        ' Retrieve the index of the item closest to the mouse pointer.
                        numitem = ListXMLTVFRChoisie.InsertionMark.NearestIndex(targetPoint)
                        If numitem = -1 Then
                            numitem = 0
                        End If
                        If numitem = ListXMLTVFRChoisie.Items.Count - 1 Then
                            numitem = ListXMLTVFRChoisie.Items.Count
                        End If

                        'Numitem = ListXMLTVFRChoisie.GetItemAt(x, y).Index
                    Catch ex As Exception
                        numitem = 0
                        Trace.WriteLine(" erreur try catch ligne AAA2")
                    End Try

                    'If y > 0 AndAlso x > 0 AndAlso Numitem < 1 Then
                    '    nTemp = ListXMLTVFRChoisie.Items.Count
                    '    If nTemp > 0 Then
                    '        If ListXMLTVFRChoisie.Items.Item(nTemp - 1).Position.Y < y Then
                    '            Numitem = nTemp
                    '        Else
                    '            Numitem = 0
                    '        End If
                    '    Else
                    '        Numitem = 0
                    '    End If
                    'End If

                    For i = 0 To myItems.GetUpperBound(0)
                        Dim itmListViewAllChannel As New ListViewItem
                        itmListViewAllChannel.Text = myItems(i).Text
                        itmListViewAllChannel.SubItems.Add("")
                        ListXMLTVFRChoisie.Items.Insert(numitem + i, itmListViewAllChannel)
                        itmListViewAllChannel.ImageIndex = myItems(i).ImageIndex
                        ListXMLTVFRChoisie.SmallImageList = imageListSmall
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
            Dim fenMessage As New Message(ex.Message, MsgBoxStyle.Critical, True)
            fenMessage.ShowDialog()
        End Try
    End Sub

    Private Sub ComboBox1SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles URLComboBox.SelectedIndexChanged

        If URLComboBox.SelectedIndex <= 0 Then
            ButtonDemarrer.Enabled = False
            'WarningURl(3)
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

        Dim bConnect As Boolean = True

        ' avant toute mise à jour manuelle , sauver la base de donnee db_progs.db3 dans db_progrs.bak
        Trace.WriteLine(DateTime.Now & " " & "entree dans Sub New Frm mise a jour")

        ' copie de sauvegarde de la base de données au cas ou il y aurait
        ' corruption du ficher à télécharger
        ' a faire: mémorisation de la date de derniere mise a jour reussie
        Dim success As Boolean
        Dim sourcefile As String
        Dim destinationfile As String
        Dim bdDisGood As Boolean = True
        sourcefile = BDDPath & "db_progs.db3"
        destinationfile = BDDPath & "db_progs.bak"
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
            qwAllChanneltbl = "SELECT  Name,ID,ordering,logo,KTV FROM Channeltbl ORDER BY ORDERING "
            Try
                Dim db As SQLiteBase = New SQLiteBase
                Dim dtChannels As DataTable
                db.OpenDatabase(BDDPath & "db_progs.db3")
                dtChannels = db.ExecuteQuery(qwAllChanneltbl)
                db.CloseDatabase()
                db = Nothing
                Try
                    For r As Integer = 0 To dtChannels.Rows.Count - 1
                        With _originalList(i)
                            .Name = dtChannels.Rows(r).Item(0).ToString
                            .Id = dtChannels.Rows(r).Item(1).ToString
                            .Ordering = CInt(dtChannels.Rows(r).Item(2))
                            .Logo = dtChannels.Rows(r).Item(3).ToString
                            .KTv = CInt(dtChannels.Rows(r).Item(4))
#If DEBUG Then
                            Trace.WriteLine( _
                                             DateTime.Now & " i= " & i.ToString & " nom chaine = " & OriginalList(i).Name & _
                                             " identif = " & OriginalList(i).ID & "logo = " & OriginalList(i).Logo)
#End If

                        End With
                        i += 1
                    Next
                    _nbChannels = i - 1

                    ' 020409 probleme previsible si = 0
                Catch ex As Exception
                    bConnect = False
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

        If Not IsNetConnectOnline() Then
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

#If Not Debug Then
                If ligne.Split(CChar(";"))(2).Trim(" "c) <> "1" Then
                    URLComboBox.Items.Add(mess)
                    _tableUrlUrl(itab) = ligne.Split(CChar(";"))(0).Replace(CChar(" "), "")
                    _tableTypeUrl(itab) = ligne.Split(CChar(";"))(2).Replace(CChar(" "), "")

                    ' si la ligne correspond à la dernière mise à jours alors on la sélectionne
                    If _
                        My.Settings.Lienmiseajour = ligne.Split(CChar(";"))(0).Trim(" "c) AndAlso _
                        ligne.Split(CChar(";"))(2).Trim(" "c) <> "2" Then
                        If Not (Not ligne.Split(CChar(";"))(0).Trim(" "c) Is Nothing AndAlso String.IsNullOrEmpty(ligne.Split(CChar(";"))(0).Trim(" "c))) Then
                            URLComboBox.SelectedIndex = itab
                        End If
                    End If
                Else
                    itab -= 1
                End If
#Else
                Me.URLComboBox.Items.Add(Mess)
                TableURL_URL(itab) = ligne.Split(CChar(";"))(0).Replace(CChar(" "), "")
                TableTypeURL(itab) = ligne.Split(CChar(";"))(2).Replace(CChar(" "), "")

                If _
                    My.Settings.Lienmiseajour = ligne.Split(CChar(";"))(0).Trim(" "c) AndAlso _
                    ligne.Split(CChar(";"))(2).Trim(" "c) <> "2" Then
                    If ligne.Split(CChar(";"))(0).Trim(" "c) <> "" Then
                        Me.URLComboBox.SelectedIndex = itab
                    End If
                End If

#End If

                ligne = monStreamReader.ReadLine
                itab += 1
            Loop Until ligne Is Nothing
            monStreamReader.Close()
            WarningURl(1)

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
                        Dim _
                            fenMessage As Message = _
                                New Message(FailURLFileDownload, MsgBoxStyle.Critical, _
                                                True)
                        fenMessage.ShowDialog()
                    End If
                Case Else
                    Dim fenMessage As New Message(UntraceableURLListFile, MsgBoxStyle.Critical, True)
                    fenMessage.ShowDialog()
            End Select
        End Try

    End Sub

    Public Function CopierFichier(ByVal fichierSource As String, ByVal fichierDest As String, _
                                   Optional ByVal bEcraser As Boolean = False) As Boolean

        ' Vérifier que le fichier source existe
        If Not File.Exists(fichierSource) Then
            Dim fenMessage As New Message(TheFile & fichierSource & DontExist, MsgBoxStyle.Critical, True)
            fenMessage.ShowDialog()
            Return False
        End If

        ' Si l'utilisateur a déjà choisi le fichier dans le AppData
        ' alors il est inutile de faire une copie
        If fichierSource = fichierDest Then
            Return True
        End If

        ' Vérifier Si il y a déjà un "FichierDest" de présent
        If File.Exists(fichierDest) Then
            If bEcraser Then
                Try
                    File.Delete(fichierDest)
                Catch ex As Exception
                    Dim _
                        fenMessage As _
                            New Message(ErrorInFileCopy, TheFile & " " & fichierSource & ProtectedFile, _
                                            MsgBoxStyle.Critical, True)
                    fenMessage.ShowDialog()
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

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function GetShortPathName(ByVal longPath As String, _
                                             <MarshalAs(UnmanagedType.LPTStr)> _
                                                ByVal shortPath As StringBuilder, _
                                             < _
                                                MarshalAs( _
                                                           UnmanagedType.U4)> _
                                                ByVal bufferSize As Integer) As Integer
    End Function

    Public Function GetShortPathName(ByVal fileName As String) As String
        Dim sb As New StringBuilder(1024)
        GetShortPathName(fileName, sb, sb.Capacity)

        Return sb.ToString()

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
                ListViewAllChannel.SmallImageList = imageListSmall
            End If
        Next i
        Dim itm As New ListViewItem
        For Each itm In ListViewAllChannel.Items
            If CollectionChannels.Contains(itm.Text) Then
                arrayOnechannel = DirectCast(CollectionChannels.Item(itm.Text), String())
                CollectionSelectChannels.Add(arrayOnechannel)
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

    Private Sub WarningURl(ByVal nType As Integer)

        ' Cette SR affiche un message en cas d erreur dans le formuliare de mise ajour
        ' ...cases vide  choix non correct....
        Select Case nType
            Case 1
                If URLComboBox.SelectedIndex > -1 Then
                    If _tableTypeUrl(URLComboBox.SelectedIndex) _
                       <> _
                       "2" Then
                        Warning.Visible = False
                    End If
                Else
                    Warning.Visible = True
                    Warning.Text = ChoseFile
                    Warning.Left = CInt((Width - Warning.Width) / 2)
                    Trace.WriteLine(DateTime.Now & " " & "Warning Url case 1 ")
                End If

            Case 2
                If _tableTypeUrl(URLComboBox.SelectedIndex) _
                   <> _
                   "2" Then
                    Warning.Text = InvalidChoice
                    Warning.Left = CInt((Width - Warning.Width) / 2)
                    Warning.Visible = True
                    Trace.WriteLine(DateTime.Now & " " & "Warning Url case 2 ")
                Else
                    Warning.Visible = False
                End If

            Case 3
                If (URLComboBox.Text.Trim(" "c).Length) > 0 Then
                    If _tableTypeUrl(URLComboBox.SelectedIndex) _
                       <> _
                       "2" Then
                        Warning.Visible = False
                        If URLComboBox.Text.IndexOf(Chr(45)) _
                           <> _
                           1 Then
                            ButtonDemarrer.Enabled = True
                        End If
                    Else
                        Warning.Text = InvalidChoice
                        Warning.Left = CInt((Width - Warning.Width) / 2)
                        Warning.Visible = True
                        ButtonDemarrer.Enabled = False

                    End If
                Else
                    Warning.Text = InvalidChoice
                    Warning.Left = CInt((Width - Warning.Width) / 2)
                    Warning.Visible = True
                    Trace.WriteLine(DateTime.Now & " " & "Warning Url case 3 ")
                    ButtonDemarrer.Enabled = False
                End If
        End Select
    End Sub

    Public Function RechercherLogo(ByVal channelRen As String) As String
        '-------------------------------------------------------------------------------------------------
        'la routine renvoit ,sauf mention contraire, la variable "sortie" de type string  via l instruction return
        '-------------------------------------------------------------------------------------------------
        'rvs 30/05/2010 : essaie de récuperer le logo qui est renseigné dans la bdd en premier
        'pas très propre mais fonctionnel...
        channelRen = channelRen.Replace(".", "").Replace("-", "").Replace("\", " ").Replace("/", " ").Replace("ü", "u").Replace("ß", "ss")
        Dim sortie As String
        If _originalList.Length > 0 Then
            Dim memlogochannel As String
            For Each channel As ChannelList In _originalList
                If channel.Name = channelRen Then
                    memlogochannel = channel.Logo
                    If File.Exists(LogosPath & memlogochannel) Then
                        imageListSmall.Images.Add(Image.FromFile(LogosPath & memlogochannel))
                        Return memlogochannel ' BB230610
                    End If
                End If
            Next
        End If

        ' rvs 03/11/2009 code repris de parse_xml_channels afin de
        ' pouvoir être réutiliser si 'il y a un noeud enfant "icon"
        If Directory.GetFiles(LogosPath, channelRen & ".*").Length > 0 Then
            If File.Exists(LogosPath & channelRen & ".gif") Then
                imageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & channelRen & _
                                                           ".gif"))
                sortie = channelRen & ".gif"
            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                imageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & channelRen & _
                                                           ".jpg"))
                sortie = channelRen & ".jpg"
            Else

                ' Modifier le 05092009
                Dim memo As String
                memo = CreerLogo(channelRen & ".jpg")
                imageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & _
                                                           memo))
                sortie = memo
                'imageListSmall.Images.Add(Image.FromFile(LogosPath & "vide.jpg"))
                'LogoFilename = "vide.jpg"
            End If
        Else
            channelRen = channelRen.Replace("é", "e").Replace("è", "e")

            ' Modifier le 25092009
            If File.Exists(LogosPath & channelRen & ".gif") Then
                imageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & channelRen & _
                                                           ".gif"))
                sortie = channelRen & ".gif"
            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                imageListSmall.Images.Add( _
                                           Image.FromFile( _
                                                           LogosPath & channelRen & _
                                                           ".jpg"))
                sortie = channelRen.Replace(" ", "") & ".jpg"
            Else

                ' Modifier le 01092009
                channelRen = channelRen.Replace(" ", "")
                If File.Exists(LogosPath & channelRen & ".gif") Then
                    imageListSmall.Images.Add( _
                                               Image.FromFile( _
                                                               LogosPath & channelRen & _
                                                               ".gif"))
                    sortie = channelRen & ".gif"
                ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                    imageListSmall.Images.Add( _
                                               Image.FromFile( _
                                                               LogosPath & channelRen & _
                                                               ".jpg"))
                    ' rechercher_Logo = ChannelRen & ".jpg"
                    sortie = channelRen & ".jpg"
                Else
                    channelRen = channelRen.Replace("+", "plus")
                    If File.Exists(LogosPath & channelRen & ".gif") Then
                        imageListSmall.Images.Add( _
                                                   Image.FromFile( _
                                                                   LogosPath & _
                                                                   channelRen & ".gif"))
                        sortie = channelRen & ".gif"
                    ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                        imageListSmall.Images.Add( _
                                                   Image.FromFile( _
                                                                   LogosPath & _
                                                                   channelRen & ".jpg"))
                        ' rechercher_Logo = ChannelRen & ".jpg"
                        sortie = channelRen & ".jpg"
                    Else
                        channelRen = _
                            channelRen.Replace("television", "TV").Replace( _
                                                                             "Television", _
                                                                             "TV"). _
                                Replace("TELEVISION", "TV")
                        If File.Exists(LogosPath & channelRen & ".gif") Then
                            imageListSmall.Images.Add( _
                                                       Image.FromFile( _
                                                                       LogosPath & _
                                                                       channelRen & _
                                                                       ".gif"))
                            'rechercher_Logo = ChannelRen & ".gif"
                            sortie = channelRen & ".gif"
                        ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                            imageListSmall.Images.Add( _
                                                       Image.FromFile( _
                                                                       LogosPath & _
                                                                       channelRen & _
                                                                       ".jpg"))
                            'rechercher_Logo = ChannelRen & ".jpg"
                            sortie = channelRen & ".jpg"
                        Else
                            channelRen = _
                                channelRen.Replace("tv", "").Replace("Tv", "").Replace( _
                                                                                          "TV", _
                                                                                          "")
                            If File.Exists(LogosPath & channelRen & ".gif") Then
                                imageListSmall.Images.Add( _
                                                           Image.FromFile( _
                                                                           LogosPath & _
                                                                           channelRen & _
                                                                           ".gif"))
                                ' rechercher_Logo = ChannelRen & ".gif"
                                sortie = channelRen & ".gif"
                            ElseIf File.Exists(LogosPath & channelRen & ".jpg") Then
                                imageListSmall.Images.Add( _
                                                           Image.FromFile( _
                                                                           LogosPath & _
                                                                           channelRen & _
                                                                           ".jpg"))
                                ' rechercher_Logo = ChannelRen & ".jpg"
                                sortie = channelRen & ".jpg"
                            Else
                                channelRen = channelRen.Replace("plus", "")
                                If File.Exists(LogosPath & channelRen & ".gif") Then
                                    imageListSmall.Images.Add( _
                                                               Image.FromFile( _
                                                                               LogosPath & _
                                                                               channelRen & _
                                                                               ".gif"))
                                    'rechercher_Logo = ChannelRen & ".gif"
                                    sortie = channelRen & ".gif"
                                ElseIf File.Exists(LogosPath & channelRen & ".jpg") _
                                    Then
                                    imageListSmall.Images.Add( _
                                                               Image.FromFile( _
                                                                               LogosPath & _
                                                                               channelRen & _
                                                                               ".jpg"))
                                    'rechercher_Logo = ChannelRen & ".jpg"
                                    sortie = channelRen & ".jpg"
                                Else
                                    ' Modifier le 05092009
                                    Dim memo As String
                                    memo = CreerLogo(channelRen & ".jpg")
                                    imageListSmall.Images.Add( _
                                                               Image.FromFile( _
                                                                               LogosPath & _
                                                                               memo))
                                    'rechercher_Logo = memo
                                    sortie = memo
                                    'imageListSmall.Images.Add(Image.FromFile(LogosPath & "vide.jpg"))
                                    'LogoFilename = "vide.jpg"
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
End Class


