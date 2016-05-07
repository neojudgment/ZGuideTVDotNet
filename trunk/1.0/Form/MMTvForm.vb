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
Imports System.Xml
Imports ZGuideTV.SQLiteWrapper

Public Class MMTvForm
    Public _
        MMTvData As String = _
            Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", _
                               "AppData", "").ToString & "\MeuhMeuhTV\"

    Public MMTvExe As String
    Public ImageLogoList As New ImageList
    Public SList As String()
    Public bAuto As Boolean
    Public bSelectedSourceEvenActiv As Boolean' = False

    Public Function SourcesList() As String()

        Dim ListOfSource As String()
        Dim i As Integer = 0
        ListOfSource = New String(10) {}
        Try
            If File.Exists(MMTvData & "\MeuhMeuhTV.xml") Then
                Dim XmlTvDoc As XmlDocument = New XmlDocument()
                Dim TvSources As XmlNodeList
                Dim SourcesNode As XmlNode
                Dim Element As XmlAttribute

                XmlTvDoc.Load(MMTvData & "\MeuhMeuhTV.xml")
                TvSources = XmlTvDoc.DocumentElement.GetElementsByTagName("DShowSource")
                For Each SourcesNode In TvSources
                    Dim TmpSources As String

                    Element = SourcesNode.Attributes("CommonName")
                    TmpSources = Element.Value()


                    ListOfSource.SetValue(TmpSources, i)
                    i += 1
                Next
            Else
                Array.Resize(ListOfSource, i)
                Return ListOfSource
            End If
            Array.Resize(ListOfSource, i)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return ListOfSource
    End Function

    Public Function ChannelList(ByVal Path As String) As String()

        Dim ListOfChannel As String()
        Dim i As Integer = 0
        ListOfChannel = New String(500) {}
        Try
            If File.Exists(Path) Then
                Dim XmlTvDoc As XmlDocument = New XmlDocument()
                Dim TvSources As XmlNodeList
                Dim SourcesNode As XmlNode
                Dim Element As XmlAttribute

                XmlTvDoc.Load(Path)
                TvSources = XmlTvDoc.DocumentElement.GetElementsByTagName("Channel")
                For Each SourcesNode In TvSources
                    Element = SourcesNode.Attributes("Name")
                    ListOfChannel(i) = Element.Value
                    i += 1
                Next
            Else
                Array.Resize(ListOfChannel, i)
                Return ListOfChannel
            End If
            Array.Resize(ListOfChannel, i)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return ListOfChannel
    End Function

    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ListView1.Columns.Add("Nom ZGuideTV.NET", -2, HorizontalAlignment.Right)
        ListView1.Columns.Add("Num. MMTv", 72, HorizontalAlignment.Left)
        ListView1.Columns.Add("Nom MeuhMeuhTv", 157, HorizontalAlignment.Left)


        ListView1.Columns.Add("", 0, HorizontalAlignment.Left)
        ListView1.Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.None)
        ListView1.Columns(3).Width = 0

        IniMMTVSources()


        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Private Sub Label1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label1.Click

    End Sub

    Public Sub ChargeList(Optional ByVal MMTVChannels() As String = Nothing)
        Dim ObjetDataSet As New DataSet()
        Dim ObjetDataTable As DataTable
        Dim RowNumber As Integer

        ' Numéro de l'enregistrement couran
        Dim strSqlChannel As String = ""
        Dim LogoName As String = ""
        Dim TmpimageListChannel As New ImageList()
        Dim i As Integer = 0
        Dim k As Integer = 0
        'Dim db As sqlite.SQLite = New sqlite.SQLite
        Dim db As SQLiteBase = New SQLiteBase

        Dim NbMMTVChannel As Integer = 0
        If Not (MMTVChannels Is Nothing) Then
            NbMMTVChannel = MMTVChannels.Length
        End If

        Dim XMLChannels As ChannelsConfigs = New ChannelsConfigs()

        ListView1.Items.Clear()

        TmpimageListChannel.ImageSize = New Size(38, 29)
        strSqlChannel = "Select distinct name,logo,ID,Ordering From ChannelTbl ORDER BY Ordering;"

        ObjetDataTable = ObjetDataSet.Tables("ChannelTbl")
        db.OpenDatabase(BDDPath & "db_progs.db3")
        ObjetDataTable = db.ExecuteQuery(strSqlChannel)
        db.CloseDatabase()
        db = Nothing

        If RowNumber < 0 Then
            Exit Sub
        End If

        ' Lors de l'ouverture de la BD, s'il n'y a aucun enregistrement
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
                    '(ObjetDataTable.Rows(RowNumber).Item("Name").ToString)              'seconde cellule

                    Try
                        i = _
                            CInt( _
                                XMLChannels.GetChannelOption(ObjetDataTable.Rows(RowNumber).Item("ID").ToString, _
                                                              "MMTV", _
                                                              My.Settings.MMTVSource, "0", LVI.Text))
                    Catch ex As Exception
                        i = 0
                    End Try


                    If i > 0 AndAlso (i + 1) <= MMTVChannelsCombo.Items.Count Then
                        LVI.SubItems.Add( _
                                          XMLChannels.GetChannelOption( _
                                                                        ObjetDataTable.Rows(RowNumber).Item("ID"). _
                                                                           ToString, "MMTV", _
                                                                        My.Settings.MMTVSource, "0", LVI.Text))
                        LVI.SubItems.Add(MMTVChannelsCombo.Items.Item(i).ToString)
                    Else
                        If bAuto Then
                            k = 0
                            Dim btrouve As Boolean = False
                            Dim WMMTVChannel As String
                            Dim WZgChannel As String
                            While k < NbMMTVChannel And Not btrouve
                                WMMTVChannel = _
                                    MMTVChannels(k).ToLower.Replace(" ", "").Replace("+", "plus").Replace("é", "e"). _
                                        Replace("è", "e").Replace("ê", "e").Replace("&", "").Replace("_", "")
                                WZgChannel = _
                                    LVI.Text().ToLower.Replace(" ", "").Replace("+", "plus").Replace("é", "e"). _
                                        Replace("è", "e").Replace("ê", "e").Replace("&", "").Replace("_", "")

                                k += 1
                                If WMMTVChannel = WZgChannel Then
                                    btrouve = True
                                    LVI.SubItems.Add(k.ToString)
                                    LVI.SubItems.Add(MMTVChannels(k - 1))
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
                    'ajout de la ligne
                Next RowNumber

            End If
        Catch
            Trace.WriteLine(DateTime.Now & " Erreur d'exception dans charge liste channel du MMTVform")
            MessageBox.Show("Une erreur est survenue lors du chargement des chaînes.")
        End Try
        ListView1.Columns(0).Width = 200

    End Sub

    Private Sub Sauvegarde(ByVal ZChannel As String, ByVal kChannel As Integer, ByVal ZChannelName As String)
        Try
            Dim XMLChannels As ChannelsConfigs = New ChannelsConfigs()
            XMLChannels.SetChannelOption(ZChannel, "MMTV", My.Settings.MMTVSource, kChannel.ToString, ZChannelName)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub IniMMTVSources()

        Dim i As Integer
        Try
            SList = SourcesList()

            Select Case My.Settings.MMTVSource
                Case ""
                    If SList.Length > 0 Then
                        My.Settings.MMTVSource = SList(0)
                        bAuto = True
                    Else
                        MessageBox.Show("Aucune source n'a été trouvé.")
                        Close()
                    End If
            End Select

            Me.MMTVSourcesCombo.Items.Clear()
            For i = 0 To SList.Length - 1
                If SList(i) IsNot Nothing Then
                    Me.MMTVSourcesCombo.Items.Add(SList(i))
                End If
            Next
            bSelectedSourceEvenActiv = False
            MMTVSourcesCombo.Text = My.Settings.MMTVSource
            bSelectedSourceEvenActiv = True
            IniMMTVChannels()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub IniMMTVChannels()

        Dim CList As String()

        Dim i As Integer
        Try
            CList = ChannelList(MMTvData & "MeuhMeuhTV_" & SList(0) & ".xml")

            Me.MMTVChannelsCombo.Items.Clear()
            Me.MMTVChannelsCombo.Items.Add("")
            For i = 0 To CList.Length - 1
                If CList(i) IsNot Nothing Then
                    Me.MMTVChannelsCombo.Items.Add(CList(i))
                End If
            Next

            ChargeList(CList)
            bAuto = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BT_Save_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BT_Save.Click

        Dim ZChannel As String = ""
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim kChannel As Integer = 0
        Dim ZChannelName As String = ""
        Try
            i = ListView1.SelectedIndices.Item(0)

            ' on mémorise la position de l'ascencenre (ou plutôt le premier élément affichié de la liste)
            k = ListView1.TopItem().Index
            ZChannel = ListView1.Items.Item(i).SubItems.Item(3).Text
            kChannel = MMTVChannelsCombo.SelectedIndex
            ZChannelName = ListView1.Items.Item(i).SubItems.Item(0).Text
        Catch ex As Exception

            MessageBox.Show("Veuillez sélectionner une chaine de ZGuideTV.NET")

        End Try

        If ZChannel <> "" Or ZChannel <> Nothing Then

            Try
                Sauvegarde(ZChannel, kChannel, ZChannelName)
                Me.ChargeList()

                ' on revient à la position de départ
                ListView1.TopItem = ListView1.Items.Item(k)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Fermer.Click
        Me.Close()
    End Sub

    Private Sub MMTVSourcesCombo_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MMTVSourcesCombo.SelectedValueChanged
        If bSelectedSourceEvenActiv Then
            My.Settings.MMTVSource = MMTVSourcesCombo.SelectedItem.ToString
            MMTVSourcesCombo.Text = My.Settings.MMTVSource
            IniMMTVSources()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles BT_Auto.Click
        bAuto = True
        IniMMTVSources()
        bAuto = False
    End Sub
End Class

