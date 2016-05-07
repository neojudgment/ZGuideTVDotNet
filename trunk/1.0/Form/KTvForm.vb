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
Imports Microsoft.Win32
Imports ZGuideTV.SQLiteWrapper
Imports System.Globalization

Public Class KTvForm
    Public ImageLogoList As New ImageList
    Public bSelectedSourceEvenActiv As Boolean' = False
    Public bAuto As Boolean
    Public TheFile As String = "Le Fichier "
    Public NoKtvFolder As String = "Le répertoire K!TV n'a pas été trouvé !"
    Public NoKtvIni As String = "Le fichier ini n'a pas été trouvé !"
    Public TheFolder As String = "Le répertoire "
    Public DontExist As String = "n'existe pas!"
    Public ChannelLoadErr As String = "Une erreur est survenue lors du chargement des chaînes !"

    Public _
        SaveKtvErr As String = _
            "Une erreur est survenue durant la sauvegarde des correspondances entre K!TV et ZGuideTV !"

    Public NoSource As String = "Aucune source n'a été trouvée !"
    Public NoChannel As String = "Aucune chaîne n'a été trouvée !"
    Public SelectZgChannel As String = "Veuillez sélectionner une chaine de ZGuideTV.NET."

    Public Sub New()

        InitializeComponent()
        Path.Text = My.Settings.KtvPath()

        ListView1.Columns.Add("Nom ZGuideTV.NET", -2, HorizontalAlignment.Right)
        ListView1.Columns.Add("Num. K!TV", 67, HorizontalAlignment.Left)
        ListView1.Columns.Add("Nom K!TV", 162, HorizontalAlignment.Left)


        ListView1.Columns.Add("", 0, HorizontalAlignment.Left)
        ListView1.Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.None)
        ListView1.Columns(3).Width = 0

        Me.Text = "Gestion des chaînes K!TV "
        LabelSource.Text = "Source Active: "
        ButtonClose.Text = "Fermer"
        ButtonSave.Text = "Sauver"

        IniKtvChannel(Path.Text)
        My.Settings.KtvPath = Path.Text

    End Sub

    Public Function IniKtvChannel(ByVal Ktvpath As String) As Boolean
        Try
            Select Case Ktvpath
                Case "", Nothing
                    bAuto = True
                    Ktvpath = Fct_Path_KTV_Registre()
                    '& "\"
            End Select
            Select Case Ktvpath
                Case "", Nothing
                    Dim FenMessage As Message = _
                            New Message("K!TV", NoKtvFolder, MsgBoxStyle.Critical, True)
                    FenMessage.ShowDialog()

                    Return False
                Case Else
                    Ktvpath = Ktvpath & "\"
                    Path.Text = Ktvpath
                    KTVChannelComboBox.Items.Clear()
                    If Directory.Exists(Ktvpath) Then
                        If File.Exists(Ktvpath & "\K!TV.ini") Then
                            Dim KTVChannels() As String = Fct_KTV_Channels(Ktvpath)
                            Dim i As Integer
                            KTVChannelComboBox.Items.Add("")
                            Dim Length As Integer = KTVChannels.Length - 1
                            For i = 0 To Length
                                KTVChannelComboBox.Items.Add(KTVChannels(i).ToString)
                            Next

                            ChargeList(KTVChannels)
                        Else
                            Dim FenMessage2 As Message = _
                                    New Message("K!TV", NoKtvIni, MsgBoxStyle.Critical, True)
                            FenMessage2.ShowDialog()

                            Return False

                        End If

                    Else
                        Dim FenMessage3 As Message = _
                                New Message("K!TV", TheFolder & Ktvpath & DontExist, MsgBoxStyle.Critical, True)
                        FenMessage3.ShowDialog()

                        Return False

                    End If
            End Select
            bAuto = False
        Catch ex As Exception
            bAuto = False
            Dim FenMessage4 As Message = _
                    New Message("K!TV", ex.Message, MsgBoxStyle.Critical, True)
            FenMessage4.ShowDialog()

            Return False
        End Try
        bAuto = False
        Return True
    End Function

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ListView1.SelectedIndexChanged
        Try
            Dim i As Integer = ListView1.SelectedIndices.Item(0)
            i = Integer.Parse(ListView1.Items.Item(i).SubItems.Item(1).Text, CultureInfo.CurrentCulture)
            If i <= KTVChannelComboBox.Items.Count Then
                KTVChannelComboBox.SelectedIndex = i
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub KTvForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        ' On regarde quel langue utiliser 22/08/2008
        LanguageCheck(6)

    End Sub

    Public Sub ChargeList(Optional ByVal KTVChannels() As String = Nothing)
        Dim ObjetDataSet As New DataSet()
        Dim ObjetDataTable As DataTable
        Dim RowNumber As Integer

        ' Numéro de l'enregistrement courant
        Dim strSqlChannel As String = ""
        Dim LogoName As String = ""
        Dim TmpimageListChannel As New ImageList()
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim db As SQLiteBase = New SQLiteBase
        Dim NbKtvChannel As Integer = 0
        Dim bAgain As Boolean = Not (bAuto)

        ' si a la première lecture on ne trouve  pas
        ' de correspondances entre K!Tv et ZguideTv alors on retente en mode AUTO
        If Not (KTVChannels Is Nothing) Then
            NbKtvChannel = KTVChannels.Length
        End If

        Dim XMLChannels As ChannelsConfigs = New ChannelsConfigs(bAuto)

        ListView1.Items.Clear()

        TmpimageListChannel.ImageSize = New Size(38, 29)
        strSqlChannel = "Select distinct name,logo,ID,Ordering From ChannelTbl ORDER BY Ordering;"


        db.OpenDatabase(BDDPath & "db_progs.db3")
        ObjetDataTable = db.ExecuteQuery(strSqlChannel)
        db.CloseDatabase()
        db = Nothing
        Try

            If RowNumber > ObjetDataTable.Rows.Count Then
                Exit Sub
            Else

                For RowNumber = 0 To ObjetDataTable.Rows.Count - 1

                    LogoName = ObjetDataTable.Rows(RowNumber).Item("Logo").ToString
                    If File.Exists(LogosPath & LogoName) Then
                        TmpimageListChannel.Images.Add(Image.FromFile(LogosPath & LogoName))
                    Else
                        TmpimageListChannel.Images.Add(Image.FromFile(LogosPath & "vide.jpg"))
                    End If

                Next RowNumber

                ImageLogoList = TmpimageListChannel
                ListView1.SmallImageList = ImageLogoList

                For RowNumber = 0 To ObjetDataTable.Rows.Count - 1

                    Dim LVI As New ListViewItem

                    LVI.ImageIndex = RowNumber

                    LVI.Text = ObjetDataTable.Rows(RowNumber).Item("Name").ToString

                    Try
                        i = _
                            CInt( _
                                XMLChannels.GetChannelOption(ObjetDataTable.Rows(RowNumber).Item("ID").ToString, _
                                                              "KTV", _
                                                              My.Settings.KtvSource, "0", LVI.Text))
                    Catch ex As Exception
                        i = 0
                    End Try

                    If i > 0 AndAlso (i + 1) <= KTVChannelComboBox.Items.Count Then
                        bAgain = False
                        LVI.SubItems.Add( _
                                          XMLChannels.GetChannelOption( _
                                                                        ObjetDataTable.Rows(RowNumber).Item("ID"). _
                                                                           ToString, "KTV", _
                                                                        My.Settings.KtvSource, "0", LVI.Text))
                        LVI.SubItems.Add(KTVChannelComboBox.Items.Item(i).ToString)
                    Else

                        If bAuto Then

                            k = 0
                            Dim btrouve As Boolean = False
                            Dim WKTvChannel As String
                            Dim WZgChannel As String

                            While k < NbKtvChannel And Not btrouve

                                WKTvChannel = _
                                    KTVChannels(k).ToLower.Replace(" ", "").Replace("+", "plus").Replace("é", "e"). _
                                        Replace("è", "e").Replace("ê", "e").Replace("&", "").Replace("_", "")
                                WZgChannel = _
                                    LVI.Text().ToLower.Replace(" ", "").Replace("+", "plus").Replace("é", "e"). _
                                        Replace("è", "e").Replace("ê", "e").Replace("&", "").Replace("_", "")

                                k += 1

                                If WKTvChannel = WZgChannel Then
                                    btrouve = True
                                    LVI.SubItems.Add(k.ToString)
                                    LVI.SubItems.Add(KTVChannels(k - 1))
                                    Sauvegarde(ObjetDataTable.Rows(RowNumber).Item("ID").ToString, k, LVI.Text)
                                End If

                            End While
                            If Not btrouve Then

                                LVI.SubItems.Add("0")
                                LVI.SubItems.Add("")
                            End If

                        Else
                            LVI.SubItems.Add("0")
                            LVI.SubItems.Add("")
                        End If

                    End If
                    LVI.SubItems.Add(ObjetDataTable.Rows(RowNumber).Item("ID").ToString)
                    ListView1.Items.Add(LVI)

                    ' ajout de la ligne
                Next RowNumber
            End If
        Catch
            Trace.WriteLine(DateTime.Now & " Erreur d'exception dans charge liste channel du ktvform")

            Dim FenMessage4 As Message = _
                    New Message("K!TV", ChannelLoadErr, MsgBoxStyle.Critical, True)
            FenMessage4.ShowDialog()

        End Try
        ListView1.Columns(0).Width = 200

        If bAgain And Not bAuto Then
            bAuto = True
            ChargeList(KTVChannels)
        End If
    End Sub

    Private Sub Sauvegarde(ByVal ZChannel As String, ByVal kChannel As Integer, ByVal zChannelName As String)
        Try
            Dim XMLChannels As ChannelsConfigs = New ChannelsConfigs()
            XMLChannels.SetChannelOption(ZChannel, "KTV", My.Settings.KtvSource, kChannel.ToString, zChannelName)

        Catch ex As Exception
            Dim FenMessage As Message = _
                    New Message("K!TV", SaveKtvErr, MsgBoxStyle.Critical, True)
            FenMessage.ShowDialog()

        End Try
    End Sub

    Private Function Fct_Path_KTV_Registre() As String
        Dim ReturValue As String = CStr(Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\K!TV", "", ""))
        If ReturValue = Nothing Then
            Return ""
        Else
            Return ReturValue
        End If

    End Function

    Private Sub Fct_ZoomOut_Actif(ByVal KTV_Path As String)

        Dim Str_Liste_Plugins() As String
        Dim i As Integer, UStr_Liste_Plugins As Integer

        Str_Liste_Plugins = Split(INIRead_Value(KTV_Path & "\K!TV.ini", "Plugins", "VIDEO_PLUGINS"), "#")
        UStr_Liste_Plugins = Str_Liste_Plugins.Length

        For i = 1 To UStr_Liste_Plugins - 1

            Select Case Str_Liste_Plugins(i)
                Case "K_ZoomOut.dll"
            End Select
        Next

    End Sub

    Public Function Fct_KTV_Channels(ByVal Path As String) As String()

        Dim Ktv_Source As String
        Dim ChannelListFile As String
        Dim ChannelSection() As String
        Dim KTVChannels() As String = {""}
        Dim ChannelActivity As Integer
        Dim ChannelName As String
        Dim i As Integer, UChannelSection As Integer, comp As Integer
        Dim nSelectSource As Integer

        ' Search KTV Channel name
        bSelectedSourceEvenActiv = False
        ListSources.Text = ""
        ListSources.Items.Clear()
        Ktv_Source = INIRead_Value(Path & "\K!TV.ini", "SOURCE", "CAPTURE_SOURCE")
        comp = 0
        Select Case Ktv_Source
            Case "", Nothing
                bSelectedSourceEvenActiv = True
                Return KTVChannels
        End Select
        Select Case Integer.Parse(Ktv_Source, CultureInfo.CurrentCulture)
            Case 2

                ' Source WDM
                ' Vérifier s'il n' y a pas plusieurs sources
                ChannelListFile = Dir$(Path & "\Plugins\S_WDM\*.set")
                While (Not (Not ChannelListFile Is Nothing AndAlso String.IsNullOrEmpty(ChannelListFile)) AndAlso ChannelListFile <> Nothing)
                    ListSources.Items.Add(ChannelListFile)
                    ChannelListFile = Dir$()
                End While

                If ListSources.Items.Count > 0 Then
                    If Not (Not My.Settings.KtvSource Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.KtvSource)) Then
                        nSelectSource = ListSources.Items.IndexOf(My.Settings.KtvSource)
                        If nSelectSource > -1 Then
                            ListSources.SelectionStart = nSelectSource
                            ChannelListFile = ListSources.Items.Item(nSelectSource).ToString
                        Else
                            ListSources.SelectionStart = 0
                            ChannelListFile = ListSources.Items.Item(0).ToString
                        End If
                    Else
                        ListSources.SelectionStart = 0
                        ChannelListFile = ListSources.Items.Item(0).ToString
                    End If

                    My.Settings.KtvSource = ChannelListFile
                    ListSources.Text = My.Settings.KtvSource
                    Dim WFile As String = Path & "\Plugins\S_WDM\" & ChannelListFile
                    WFile = WFile.Replace("\\", "\").Replace("\\", "\")
                    If File.Exists(WFile) Then
                        ChannelSection = _
                            Split(INIRead_SectionNames(Path & "\Plugins\S_WDM\" & ChannelListFile), vbNullChar)
                        UChannelSection = ChannelSection.Length
                        For i = 1 To UChannelSection - 2
                            ChannelActivity = _
                                Integer.Parse( _
                                               INIRead_Value(Path & "\Plugins\S_WDM\" & ChannelListFile, _
                                                              ChannelSection(i), _
                                                              "active"), CultureInfo.CurrentCulture)
                            If ChannelActivity <> 0 Then
                                ChannelName = _
                                    INIRead_Value(Path & "\Plugins\S_WDM\" & ChannelListFile, ChannelSection(i), _
                                                   "name")
                                comp = comp + 1
                                Array.Resize(KTVChannels, comp)
                                KTVChannels(comp - 1) = ChannelName
                            End If
                        Next i
                    Else

                        Dim FenMessage As Message = _
                                New Message("K!TV", TheFile & WFile & DontExist, MsgBoxStyle.Critical, True)
                        FenMessage.ShowDialog()

                    End If

                Else

                    Dim FenMessage1 As Message = _
                            New Message("K!TV", NoSource, MsgBoxStyle.Critical, True)
                    FenMessage1.ShowDialog()

                    bSelectedSourceEvenActiv = True
                    Return KTVChannels
                End If
            Case Else

                ' DSCALER source
                ' Vérifier s'il n' y a pas plusieurs sources
                ChannelListFile = Dir$(Path & "\Plugins\S_Bt8x8\*.set")
                While (Not (Not ChannelListFile Is Nothing AndAlso String.IsNullOrEmpty(ChannelListFile)) AndAlso ChannelListFile <> Nothing)
                    ListSources.Items.Add(ChannelListFile)
                    ChannelListFile = Dir$()
                End While

                If ListSources.Items.Count > 0 Then
                    If Not (Not My.Settings.KtvSource Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.KtvSource)) Then
                        nSelectSource = ListSources.Items.IndexOf(My.Settings.KtvSource)
                        If nSelectSource > -1 Then
                            ListSources.SelectionStart = nSelectSource
                            ChannelListFile = ListSources.Items.Item(nSelectSource).ToString
                        End If
                    Else
                        ListSources.SelectionStart = 0
                        ChannelListFile = ListSources.Items.Item(0).ToString
                    End If

                    My.Settings.KtvSource = ChannelListFile
                    ListSources.Text = My.Settings.KtvSource
                    Dim WFile As String = Path & "\Plugins\S_Bt8x8\" & ChannelListFile
                    WFile = WFile.Replace("\\", "\").Replace("\\", "\")
                    If File.Exists(WFile) Then
                        If File.Exists(WFile) Then
                            ChannelSection = _
                                Split(INIRead_SectionNames(Path & "\Plugins\S_Bt8x8\" & ChannelListFile), vbNullChar)
                            UChannelSection = ChannelSection.Length
                            For i = 1 To UChannelSection - 2
                                ChannelActivity = _
                                    Integer.Parse( _
                                                   INIRead_Value(Path & "\Plugins\S_Bt8x8\" & ChannelListFile, _
                                                                  ChannelSection(i), "active"), CultureInfo.CurrentCulture)
                                If ChannelActivity <> 0 Then
                                    ChannelName = _
                                        INIRead_Value(Path & "\Plugins\S_Bt8x8\" & ChannelListFile, ChannelSection(i), _
                                                       "name")
                                    comp = comp + 1
                                    Array.Resize(KTVChannels, comp)
                                    KTVChannels(comp - 1) = ChannelName
                                End If
                            Next i
                        Else
                            Dim FenMessage2 As Message = _
                                    New Message("K!TV", TheFile & WFile & DontExist, MsgBoxStyle.Critical, True)
                            FenMessage2.ShowDialog()

                        End If
                    End If

                Else
                    Dim FenMessage2 As Message = _
                            New Message("K!TV", NoSource, MsgBoxStyle.Critical, True)
                    FenMessage2.ShowDialog()

                    bSelectedSourceEvenActiv = True
                    Return KTVChannels
                End If
        End Select

        Select Case comp
            Case 0
                Dim FenMessage3 As Message = _
                        New Message("K!TV", NoChannel, MsgBoxStyle.Critical, True)
                FenMessage3.ShowDialog()

        End Select
        bSelectedSourceEvenActiv = True
        Return KTVChannels

    End Function

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSave.Click

        Dim ZChannel As String = ""
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim kChannel As Integer = 0
        Dim ZChannelName As String = ""
        Try
            i = ListView1.SelectedIndices.Item(0)

            ' on mémorise la position de l'ascencenre (ou plutôt le premier élément affichié de la liste)
            k = ListView1.TopItem().Index
            ZChannelName = ListView1.Items.Item(i).SubItems.Item(0).Text
            ZChannel = ListView1.Items.Item(i).SubItems.Item(3).Text
            kChannel = KTVChannelComboBox.SelectedIndex

        Catch ex As Exception
            Dim FenMessage As Message = _
                    New Message(SelectZgChannel, MsgBoxStyle.Critical, True)
            FenMessage.ShowDialog()

        End Try

        If Not (Not ZChannel Is Nothing AndAlso String.IsNullOrEmpty(ZChannel)) Or ZChannel <> Nothing Then

            Try
                Sauvegarde(ZChannel, kChannel, ZChannelName)
                Me.ChargeList()

                ' on revient à la position de départ
                ListView1.TopItem = ListView1.Items.Item(k)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BT_Path.Click
        Dim Dialog As FolderBrowserDialog = New FolderBrowserDialog

        Select Case Dialog.ShowDialog()
            Case System.Windows.Forms.DialogResult.OK
                IniKtvChannel(Dialog.SelectedPath & "\")
                My.Settings.KtvPath = Dialog.SelectedPath & "\"
                Path.Text = My.Settings.KtvPath
        End Select
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BT_Auto.Click
        bAuto = True
        IniKtvChannel("")
        bAuto = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub ListSources_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ListSources.SelectedValueChanged
        If bSelectedSourceEvenActiv Then
            My.Settings.KtvSource = ListSources.SelectedItem.ToString
            ListSources.Text = My.Settings.KtvSource
            IniKtvChannel(Path.Text)
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub KTVChannelComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles KTVChannelComboBox.SelectedIndexChanged

    End Sub

    Private Sub Path_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Path.TextChanged

    End Sub
End Class