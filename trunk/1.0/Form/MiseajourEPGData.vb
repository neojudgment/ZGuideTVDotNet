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
Imports System.Configuration
Imports System.IO
Imports ZGuideTV.SQLiteWrapper
Imports System.Globalization
Imports Microsoft.DirectX
Imports Microsoft.DirectX.AudioVideoPlayback

Public Class MiseajourEPGData
    Public Structure channel_list
        Public Name As String
        Public ID As String
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

    Public OriginalList(1000) As channel_list
    Public Nb_Channels As Integer = -1
    Public collectionChannels As New Collection
    Dim BDDisGood As Boolean = True
    Public ListDraged As String = ""

    ' 09/03/2009 Griser et désactiver la croix rouge de la form
    Private Const CS_NOCLOSE As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

#Region "Property"
    Private _chosenChannels As String

    Public Property ChosenChannels As String
        Get
            Return _chosenChannels
        End Get
        Set(ByVal Value As String)
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

    Private _messageBoxListXmltvfrChoisie As String

    Public Property MessageBoxListXMLTVFRChoisie As String
        Get
            Return _messageBoxListXmltvfrChoisie
        End Get
        Set(ByVal Value As String)
            _messageBoxListXmltvfrChoisie = Value
        End Set
    End Property

    Private _messageBoxListXmltvfrChoisie1 As String

    Public Property MessageBoxListXMLTVFRChoisie1 As String
        Get
            Return _messageBoxListXmltvfrChoisie1
        End Get
        Set(ByVal Value As String)
            _messageBoxListXmltvfrChoisie1 = Value
        End Set
    End Property

    Private _messageBoxListXmltvfrChoisieTitre As String

    Public Property MessageBoxListXMLTVFRChoisieTitre As String
        Get
            Return _messageBoxListXmltvfrChoisieTitre
        End Get
        Set(ByVal Value As String)
            _messageBoxListXmltvfrChoisieTitre = Value
        End Set
    End Property

    Private _messageBoxMiseaJourDone As String

    Public Property MessageBoxMiseaJourDone As String
        Get
            Return _messageBoxMiseaJourDone
        End Get
        Set(ByVal Value As String)
            _messageBoxMiseaJourDone = Value
        End Set
    End Property

    Private _messageBoxMiseaJour1Done As String

    Public Property MessageBoxMiseaJour1Done As String
        Get
            Return _messageBoxMiseaJour1Done
        End Get
        Set(ByVal Value As String)
            _messageBoxMiseaJour1Done = Value
        End Set
    End Property

    Private _messageBoxMiseaJourTitreDone As String

    Public Property MessageBoxMiseaJourTitreDone As String
        Get
            Return _messageBoxMiseaJourTitreDone
        End Get
        Set(ByVal Value As String)
            _messageBoxMiseaJourTitreDone = Value
        End Set
    End Property
#End Region

    Private Sub ButtonMiseaJour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMiseaJour.Click

        ButtonMiseaJour.Enabled = False
        If ListXMLTVFRChoisie.Items.Count > 120 Then ' 031109

            Dim BoxMiseaJour As DialogResult
            BoxMiseaJour = MessageBox.Show _
                (MessageBoxListXMLTVFRChoisie & Chr(13) & MessageBoxListXMLTVFRChoisie1, _
                 MessageBoxListXMLTVFRChoisieTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                 MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        downloadMT()

        My.Settings.datemajmiseajour = CStr(Date.Now())

        ' Le fichier n'est pas corrompu, c'est une mise a jour manuelle
        ' et la bd existe et n'était pas expirée
        Dim os As OperatingSystem = Environment.OSVersion
        If _
            ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
            My.Settings.FichierCorrompu = 0 AndAlso My.Settings.BddExists AndAlso My.Settings.DataBaseExpired = False Then

            Try
                If My.Settings.AudioOn Then
                    ' le volume va de 0 (max) à -10000 (min)
                    Dim AudioPlay As Audio
                    AudioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                    AudioPlay.Volume = My.Settings.MessagesVolume
                    AudioPlay.Play()
                End If
            Catch ex As DirectXException
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            Me.Hide()

            Dim BoxMiseaJourManuelle As DialogResult
            BoxMiseaJourManuelle = MessageBox.Show _
                ( _
                 MessageBoxMiseaJourDone & Chr(13) & MessageBoxMiseaJour1Done _
                 , MessageBoxMiseaJourTitreDone, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                 MessageBoxDefaultButton.Button1)

            If BoxMiseaJourManuelle = DialogResult.Yes Then

                My.Settings.Save()
                Mainform.NotifyIcon1.Dispose()
                Mainform.tl.Close()

                Mainform.Close()
                Me.Dispose()
                Me.Close()
                Application.DoEvents()
                Application.Restart()
            Else
                Mainform.ToolStripUpdate.Enabled = False
                Mainform.ToolStripMenuOptionsUpdate.Enabled = False
                Mainform.ToolStripAutoUpdate.Enabled = False
                Mainform.ToolStripMenuOptionsAutoUpdate.Enabled = False
                Exit Sub
            End If
        Else
            My.Settings.Save()
            Mainform.NotifyIcon1.Dispose()
            Mainform.tl.Close()

            Mainform.Close()
            Me.Dispose()
            Me.Close()
            Application.DoEvents()
            Application.Restart()

        End If
    End Sub

    Private Sub btDownloadChannel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForceDownload.Click
        downloadChannel()
        ListViewAllChannel.Items.Clear()
        ListXMLTVFRChoisie.Items.Clear()
        MisaAJourListView()
    End Sub

    Private Sub frmMiseajourEPGData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LanguageCheck(7)

        ListViewAllChannel.Clear()

        Dim test_epgdata As Boolean = File.Exists(BDDPath & "EPGData.db3")
        If My.Settings.firststart = True Or My.Settings.BddExists = False Or test_epgdata = False Then
            downloadChannel()
        End If

        MisaAJourListView()

    End Sub

    Sub MisaAJourListView()
        'remplissage de la liste complète
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "EPGData.db3")
        Dim dtChaine As DataTable
        dtChaine = db.ExecuteQuery("select name,id from channel")

        imageListSmall.ImageSize = New Size(38, 29)
        ListViewAllChannel.Columns.Add(AvailableChannels & dtChaine.Rows.Count & ")", -2, _
                                HorizontalAlignment.Left)
        ListViewAllChannel.Columns.Item(0).Width = ListViewAllChannel.Width - 22

        For i As Integer = 0 To dtChaine.Rows.Count - 1

            Dim ListView_myItem As New ListViewItem

            Dim ChannelRen As String = dtChaine.Rows(i).Item(0).ToString
            Dim InvalidFileNameChars() As Char = Path.GetInvalidFileNameChars()
            For Each InvalidFileNameChar As Char In InvalidFileNameChars
                If ChannelRen.Contains(InvalidFileNameChar.ToString(CultureInfo.CurrentCulture)) Then
                    ChannelRen = ChannelRen.Replace(InvalidFileNameChar.ToString, "")
                End If
            Next
            Dim logofilename As String = Miseajour.RechercherLogo(ChannelRen)
            ListView_myItem.Text = dtChaine.Rows(i).Item(0).ToString
            ListView_myItem.SubItems.Add("")
            'le tag contient un tableau de chaines (id et logo), plus aucune gestion de tableau en parallele !!!!
            ListView_myItem.Tag = New String(1) {dtChaine.Rows(i).Item(1).ToString, logofilename}
            ListViewAllChannel.Items.Add(ListView_myItem)
            ListView_myItem.ImageIndex = i
            ListViewAllChannel.SmallImageList = imageListSmall

        Next
        db.CloseDatabase()
        db = Nothing
        ListXMLTVFRChoisie.Clear()
        ListXMLTVFRChoisie.Columns.Add(ChosenChannels & ListXMLTVFRChoisie.Items.Count & ")", -2, _
                                        HorizontalAlignment.Left)
        ListXMLTVFRChoisie.Columns.Item(0).Width = ListXMLTVFRChoisie.Width - 22

        'deplacment des chaines deja selection de ListViewAllChannel vers ListXMLTVFRChoisie
        If BDDisGood Then 'si la base est bonne, on récupère les chaine de la base
            For Each chaineL As channel_list In OriginalList
                For Each itChaine As ListViewItem In ListViewAllChannel.Items
                    If DirectCast(itChaine.Tag, String())(0).Equals(chaineL.ID, StringComparison.CurrentCulture) Then
                        Dim cloneitChaine As ListViewItem = DirectCast(itChaine.Clone, ListViewItem)
                        ListXMLTVFRChoisie.Items.Add(cloneitChaine)
                        ListXMLTVFRChoisie.SmallImageList = imageListSmall
                        ListViewAllChannel.Items.Remove(itChaine)
                        Exit For
                    End If
                Next
            Next
        Else 'sinon on recupere celle de channel.set
            'P'tain, pourquoi, il y a une structure channel_list dans variable et dans la forme qui sont diferents !?!?!
            For Each chaineL As Variables.channel_list In tableau_chaine
                For Each itChaine As ListViewItem In ListViewAllChannel.Items
                    If DirectCast(itChaine.Tag, String())(0).ToString.Equals(chaineL.identificateur, StringComparison.CurrentCulture) Then
                        Dim cloneitChaine As ListViewItem = DirectCast(itChaine.Clone, ListViewItem)
                        ListXMLTVFRChoisie.Items.Add(cloneitChaine)
                        ListXMLTVFRChoisie.SmallImageList = imageListSmall
                        ListViewAllChannel.Items.Remove(itChaine)
                        Exit For
                    End If
                Next
            Next

        End If

        ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & _
                                                   ")"
        ListXMLTVFRChoisie.Columns.Item(0).Text = ChosenChannels & ListXMLTVFRChoisie.Items.Count & _
                                                   ")"

        Select Case ListXMLTVFRChoisie.Items.Count
            Case 0
                ButtonMiseaJour.Visible = False
                ButtonSuppr.Enabled = False
            Case Else
                ButtonMiseaJour.Visible = True
                ButtonSuppr.Enabled = True
                Select Case ListViewAllChannel.Items.Count
                    Case 0
                        ButtonTout.Enabled = False
                        ButtonMiseaJour.Visible = True
                        'ButtonMiseaJour.Location = ButtonDemarrer.Location
                    Case Else
                        ButtonTout.Enabled = True
                End Select
        End Select

    End Sub

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Dim bConnect As Boolean = True

        ' avant toute mise à jour manuelle , sauver la base de donnee db_progs.db3 dans db_progrs.bak
        Trace.WriteLine(DateTime.Now & " " & "entree dans Sub New Frm mise a jour")

        ' copie de sauvegarde de la base de données au cas ou il y aurait
        ' corruption du ficher à télécharger
        ' a faire: mémorisation de la date de derniere mise a jour reussie
        Dim success As Boolean
        Dim sourcefile As String
        Dim destinationfile As String

        sourcefile = BDDPath & "db_progs.db3"
        destinationfile = BDDPath & "db_progs.bak"
        Dim fichier As New FileInfo(sourcefile)
        If File.Exists(sourcefile) AndAlso fichier.Length > 4096 Then
            success = Miseajour.CopierFichier(sourcefile, destinationfile, True)
            If Not success Then
                Trace.WriteLine(DateTime.Now & " " & "la copie de db_progs.db3 vers db_progs.bak a échoué")
                Trace.WriteLine(DateTime.Now & " " & "pas de récupération possible si fichier corrompu")
            Else
                Trace.WriteLine(DateTime.Now & " " & "db_prob.db3 a été copié dans db_prog.bak  pour récup éventuelle")
            End If
        Else
            BDDisGood = False
        End If

        ' copie de sauvegarde du fichier ZGuideTVDotNet.channels.set
        ' au cas ou il y aurait corruption du ficher à télécharger
        sourcefile = ChannelSetPath & "ZGuideTVDotNet.channels.set"
        destinationfile = ChannelSetPath & "ZGuideTVDotNet.channels.bak"
        fichier = New FileInfo(sourcefile)
        If File.Exists(sourcefile) AndAlso fichier.Length > 0 Then
            success = Miseajour.CopierFichier(sourcefile, destinationfile, True)
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
            ConfigZGuideTV As Configuration = _
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)
        sourcefile = ConfigZGuideTV.FilePath
        destinationfile = ConfigZGuideTV.FilePath & ".bak"
        fichier = New FileInfo(sourcefile)
        If File.Exists(sourcefile) AndAlso fichier.Length > 0 Then
            success = Miseajour.CopierFichier(sourcefile, destinationfile, True)
            If Not success Then
                Trace.WriteLine(DateTime.Now & " " & "la copie de user.config vers user.config.bak a échoué")
                Trace.WriteLine(DateTime.Now & " " & "pas de récupération possible si fichier corrompu")
            Else
                Trace.WriteLine( _
                                 DateTime.Now & " " & "user.config a été copié dans user.config.bak  pour récup éventuelle")
            End If
        End If
        Trace.WriteLine(" ")

        ' lecture de channeltbl (liste des canaux tel que Arte,TV5, Rtbf,...)
        If BDDisGood Then
            Dim i As Integer
            Dim qw_all_channeltbl As String
            qw_all_channeltbl = "SELECT  Name,ID,ordering,logo,KTV FROM Channeltbl ORDER BY ORDERING "
            Try
                Dim db As SQLiteBase = New SQLiteBase
                Dim dt_channels As DataTable
                db.OpenDatabase(BDDPath & "db_progs.db3")
                dt_channels = db.ExecuteQuery(qw_all_channeltbl)
                db.CloseDatabase()
                db = Nothing
                Try
                    For r As Integer = 0 To dt_channels.Rows.Count - 1
                        With OriginalList(i)
                            .Name = dt_channels.Rows(r).Item(0).ToString
                            .ID = dt_channels.Rows(r).Item(1).ToString
                            .Ordering = CInt(dt_channels.Rows(r).Item(2))
                            .Logo = dt_channels.Rows(r).Item(3).ToString
                            .KTv = CInt(dt_channels.Rows(r).Item(4))
#If DEBUG Then
                            Trace.WriteLine( _
                                             DateTime.Now & " i= " & i.ToString & " nom chaine = " & OriginalList(i).Name & _
                                             " identif = " & OriginalList(i).ID & "logo = " & OriginalList(i).Logo)
#End If

                        End With
                        i += 1
                    Next
                    Nb_Channels = i - 1

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
    End Sub

    Private Sub ListView_ItemDrag(ByVal sender As Object, ByVal e As  _
                                  ItemDragEventArgs) Handles ListViewAllChannel.ItemDrag
        Dim myItem As ListViewItem
        Dim myItems(ListViewAllChannel.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0

        ListDraged = "ListViewAllChannel"

        ' Loop though the SelectedItems collection for the source.
        For Each myItem In ListViewAllChannel.SelectedItems

            ' Add the ListViewItem to the array of ListViewItems.
            myItems(i) = myItem
            i = i + 1
        Next myItem

        ' Create a DataObject containg the array of ListViewItems.
        ListViewAllChannel.DoDragDrop(New  _
                                          DataObject("System.Windows.Forms.ListViewItem()", myItems), _
                                       DragDropEffects.Copy)
        'ButtonMiseaJour.Location = ButtonDemarrer.Location
        'ButtonDemarrer.Visible = False
        ButtonMiseaJour.Visible = True
    End Sub

    Private Sub ListView_ItemDrag1(ByVal sender As Object, ByVal e As  _
                                       ItemDragEventArgs) Handles ListXMLTVFRChoisie.ItemDrag
        Dim myItem As ListViewItem
        Dim myItems(ListXMLTVFRChoisie.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0

        ListDraged = "ListXMLTVFRChoisie"

        ' Loop though the SelectedItems collection for the source.
        For Each myItem In ListXMLTVFRChoisie.SelectedItems

            ' Add the ListViewItem to the array of ListViewItems.
            myItems(i) = myItem
            i = i + 1
        Next myItem

        ' Create a DataObject containg the array of ListViewItems.
        ListXMLTVFRChoisie.DoDragDrop(New  _
                                          DataObject("System.Windows.Forms.ListViewItem()", myItems), _
                                       DragDropEffects.Copy)

        ' rvs75 le 11/09/2009                        |
        ButtonMiseaJour.Visible = ListXMLTVFRChoisie.Items.Count > 0
    End Sub

    Private Sub ListView_DragEnter1(ByVal sender As Object, ByVal e As  _
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

    Private Sub ListView_DragDrop1(ByVal sender As Object, ByVal e As  _
                                       DragEventArgs) Handles ListViewAllChannel.DragDrop
        Try
            Select Case ListDraged
                Case "ListXMLTVFRChoisie"
                    ListDraged = ""
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
                        Dim itmListXMLTVFRChoisie As ListViewItem = DirectCast(myItems(i).Clone, ListViewItem)
                        'itmListXMLTVFRChoisie.Text = myItems(i).Text
                        'itmListXMLTVFRChoisie.SubItems.Add("")
                        ListViewAllChannel.Items.Add(itmListXMLTVFRChoisie)
                        itmListXMLTVFRChoisie.ImageIndex = myItems(i).ImageIndex
                        ListViewAllChannel.SmallImageList = imageListSmall
                        ListXMLTVFRChoisie.Items.Remove(ListXMLTVFRChoisie.SelectedItems.Item(0))
                    Next i
                    ListViewAllChannel.Columns.Item(0).Text = AvailableChannels & ListViewAllChannel.Items.Count & _
                                                               ")"
                    ListXMLTVFRChoisie.Columns.Item(0).Text = ChosenChannels & ListXMLTVFRChoisie.Items.Count & _
                                                               ")"

                    Select Case ListXMLTVFRChoisie.Items.Count
                        Case 0
                            ButtonMiseaJour.Visible = False
                            ButtonSuppr.Enabled = False
                        Case Else
                            ButtonMiseaJour.Visible = True
                            ButtonSuppr.Enabled = True
                            Select Case ListViewAllChannel.Items.Count
                                Case 0
                                    ButtonTout.Enabled = False
                                    ButtonMiseaJour.Visible = True
                                Case Else
                                    ButtonTout.Enabled = True
                            End Select
                    End Select

            End Select
        Catch ex As Exception
            Dim FenMessage As New Message(ex.Message, MsgBoxStyle.Critical, True)
            FenMessage.ShowDialog()
        End Try
    End Sub

    Private Sub ListView_DragDrop2(ByVal sender As Object, ByVal e As  _
                                       DragEventArgs) Handles ListXMLTVFRChoisie.DragDrop

        Dim i As Integer = 0

        Dim nTemp As Integer = 0
        Try
            Select Case ListDraged
                Case "ListViewAllChannel"
                    ListDraged = ""
                    Dim _
                        myItems() As ListViewItem = _
                            DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem()"), ListViewItem())

                    Dim Numitem As Integer
                    Try
                        Dim targetPoint As Point = ListXMLTVFRChoisie.PointToClient(New Point(e.X, e.Y))

                        ' Retrieve the index of the item closest to the mouse pointer.
                        Numitem = _
                            ListXMLTVFRChoisie.InsertionMark.NearestIndex(targetPoint)
                        If Numitem = -1 Then
                            Numitem = 0
                        End If
                        If Numitem = ListXMLTVFRChoisie.Items.Count - 1 Then
                            Numitem = ListXMLTVFRChoisie.Items.Count
                        End If

                    Catch ex As Exception
                        Numitem = 0
                        Trace.WriteLine(" erreur try catch ligne AAA")
                    End Try


                    For i = 0 To myItems.GetUpperBound(0)
                        Dim itmListViewAllChannel As ListViewItem = DirectCast(myItems(i).Clone, ListViewItem)
                        ListXMLTVFRChoisie.Items.Insert(Numitem + i, itmListViewAllChannel)
                        itmListViewAllChannel.ImageIndex = myItems(i).ImageIndex
                        ListXMLTVFRChoisie.SmallImageList = imageListSmall
                        ListViewAllChannel.Items.Remove(ListViewAllChannel.SelectedItems.Item(0))
                    Next i
                Case Else
                    Dim _
                        myItems() As ListViewItem = _
                            DirectCast(e.Data.GetData("System.Windows.Forms.ListViewItem()"), ListViewItem())
                    Dim Numitem As Integer

                    Try
                        Dim targetPoint As Point = ListXMLTVFRChoisie.PointToClient(New Point(e.X, e.Y))

                        ' Retrieve the index of the item closest to the mouse pointer.
                        Numitem = _
                            ListXMLTVFRChoisie.InsertionMark.NearestIndex(targetPoint)
                        If Numitem = -1 Then
                            Numitem = 0
                        End If
                        If Numitem = ListXMLTVFRChoisie.Items.Count - 1 Then
                            Numitem = ListXMLTVFRChoisie.Items.Count
                        End If

                    Catch ex As Exception
                        Numitem = 0
                        Trace.WriteLine(" erreur try catch ligne AAA2")
                    End Try

                    For i = 0 To myItems.GetUpperBound(0)
                        Dim itmListViewAllChannel As ListViewItem = DirectCast(myItems(i).Clone, ListViewItem)
                        ListXMLTVFRChoisie.Items.Insert(Numitem + i, itmListViewAllChannel)
                        itmListViewAllChannel.ImageIndex = myItems(i).ImageIndex
                        ListXMLTVFRChoisie.SmallImageList = imageListSmall
                        ListXMLTVFRChoisie.Items.Remove(ListXMLTVFRChoisie.SelectedItems.Item(0))
                    Next i
            End Select
            ListViewAllChannel.Columns.Item(0).Text = ChosenChannels & ListViewAllChannel.Items.Count & ")"
            ListXMLTVFRChoisie.Columns.Item(0).Text = AvailableChannels & ListXMLTVFRChoisie.Items.Count & ")"


            Select Case ListXMLTVFRChoisie.Items.Count
                Case 0
                    ButtonMiseaJour.Visible = False
                    ButtonSuppr.Enabled = False
                Case Else
                    ButtonMiseaJour.Visible = True
                    ButtonSuppr.Enabled = True
                    Select Case ListViewAllChannel.Items.Count
                        Case 0
                            ButtonTout.Enabled = False
                            ButtonMiseaJour.Visible = True
                        Case Else
                            ButtonTout.Enabled = True
                    End Select
            End Select

        Catch ex As Exception
            Dim FenMessage As New Message(ex.Message, MsgBoxStyle.Critical, True)
            FenMessage.ShowDialog()
        End Try
    End Sub

    Private Sub ButtonAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAnnuler.Click
        'Néo le 06/09/2010
        If My.Settings.DataBaseExpired = True Then
            Application.Exit()
        End If

        If My.Settings.BddExists = False Then
            Me.Close()
            Mainform.Close()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ButtonTout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTout.Click
        For Each litem As ListViewItem In ListViewAllChannel.Items
            Dim itmListViewAllChannel As ListViewItem = DirectCast(litem.Clone, ListViewItem)
            ListXMLTVFRChoisie.Items.Add(itmListViewAllChannel)
            itmListViewAllChannel.ImageIndex = litem.ImageIndex
            ListXMLTVFRChoisie.SmallImageList = imageListSmall
            ListViewAllChannel.Items.Remove(litem)
        Next
        ButtonTout.Enabled = False
        ButtonSuppr.Enabled = True
        ButtonMiseaJour.Visible = True
    End Sub

    Private Sub ButtonSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSuppr.Click
        For Each litem As ListViewItem In ListXMLTVFRChoisie.Items
            Dim itmListXMLTVFRChoisie As ListViewItem = DirectCast(litem.Clone, ListViewItem)
            ListViewAllChannel.Items.Add(itmListXMLTVFRChoisie)
            itmListXMLTVFRChoisie.ImageIndex = litem.ImageIndex
            ListViewAllChannel.SmallImageList = imageListSmall
            ListXMLTVFRChoisie.Items.Remove(litem)
        Next
        ButtonTout.Enabled = True
        ButtonSuppr.Enabled = False
        ButtonMiseaJour.Visible = False
    End Sub
End Class