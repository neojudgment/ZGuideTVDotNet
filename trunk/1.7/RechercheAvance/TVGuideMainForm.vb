' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
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
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•

Imports System.Collections
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms
Imports System.Globalization
Imports ZGuideTV.TVGuide

Partial Class TVGuideMainForm
    Inherits Form

#Region "Enumerations"

    'Public Enum SearchFieldItems As Integer
    '    Titre = 0
    '    Soustitre = 1
    '    Description = 2
    '    Credits = 3
    'End Enum

#End Region

#Region "Member Variables"

    'Public Shared ProgramConfiguration As ConfigurationData
    Public Shared ListingsOrganizer As New ProgrammeOrganizer()
    Private ReadOnly typeRecherche As ObjRecherche
    Private ReadOnly objRecherche As Object
    Private PremierDemarrage As Boolean = True
#End Region

#Region "Constructor"

    Public Sub New()
        InitializeComponent()

        'Initialize ProgrammeOrganizer object
        'ProgrammeOrganizer.MovieRatingTag1 = ProgramConfiguration.RatingTag1
        'ProgrammeOrganizer.MovieRatingTag2 = ProgramConfiguration.RatingTag2

        'Directory.SetCurrentDirectory(Application.StartupPath)

    End Sub
    Public Sub New(type As objRecherche, Optional obj As Object = Nothing)
        InitializeComponent()
        typeRecherche = type
        objRecherche = obj
    End Sub
#End Region

#Region "Helper Methods"

    Public Function LoadSavedSearches() As Hashtable
        Dim savedSearches As Hashtable = Nothing
        Try
            Dim fs As FileStream
            If File.Exists(Path.Combine(AppData, "SavedSearches2.bin")) Then
                fs = File.OpenRead(Path.Combine(AppData, "SavedSearches2.bin"))
                Dim formatter As New BinaryFormatter()
                savedSearches = DirectCast(formatter.Deserialize(fs), Hashtable)
                fs.Close()
            End If
        Catch ex As Exception
        End Try

        Return (savedSearches)
    End Function

    Public Shared Sub CommitSavedSearches(savedSearches As Hashtable)
        Try
            'serialize to a memory stream first so that if the serializer throws an exception 
            '(common during development when working on new searches) the datafile doesn't get trashed
            Dim ms As New MemoryStream(100000)
            Dim formatter As New BinaryFormatter()
            formatter.Serialize(ms, savedSearches)

            Dim fs As FileStream = File.Open(Path.Combine(AppData, "SavedSearches2.bin"), FileMode.Create)
            fs.Write(ms.ToArray(), 0, CInt(ms.Length))
            fs.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor

        tvAdvancedSearch.Clear()
        listViewEm.Clear()

        'Try
        ListingsOrganizer.LoadListings()
        'Catch ex As Exception
        '    MessageBox.Show([String].Format("{0} - Did you forget to run XMLTV?", ex.Message), "TVGuide Error")
        '    Cursor = Cursors.[Default]
        '    Return
        'End Try


        tvAdvancedSearch.CreateNodes_SavedSearches(LoadSavedSearches())
        tvAdvancedSearch.CreateNodes_SpecificDates(ListingsOrganizer.MinShowDate, ListingsOrganizer.MaxShowDate)
        tvAdvancedSearch.CreateNodes_Channels(ListingsOrganizer.AllChannels)
        tvAdvancedSearch.CreateNodes_Categories(ListingsOrganizer.AllCategories)
        AddHandler tvAdvancedSearch.OnExecuteSearch, New TVTreeViewEx.ExecuteSearch(AddressOf treeView_OnExecuteSearch)
        AddHandler tvAdvancedSearch.OnEditSavedSearch, New TVTreeViewEx.EditSavedSearch(AddressOf treeView_OnEditSavedSearch)

        Cursor = Cursors.[Default]

    End Sub

#End Region

#Region "Form Events"

    Private Sub TVGuideMainForm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Directory.SetCurrentDirectory(Application.StartupPath)

        'Save program configuration to disk
        CommitSavedSearches(tvAdvancedSearch.SavedSearches)

    End Sub

    Private Sub TVGuideMainForm_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        e.Cancel = False
    End Sub

    Private Sub TVGuideMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim Start As DateTime, Finish As DateTime
        'time how long it takes the program to initialize itself
        'Dim LoadTime As TimeSpan
        'LanguageCheck()

        ListTab.Text = LngTabSearchList
        AdvancedSearchTab.Text = LngTabSearchAdvancedSearch
        _AdvancedSearchEditor.gbCreation.Text = LngAdvancedSeachGBSearch
        _AdvancedSearchEditor.gbSauver.Text = LngAdvancedSeachGBSave
        _AdvancedSearchEditor.btInserer.Text = LngAdvancedSeachBTInsert
        _AdvancedSearchEditor.btNettoyer.Text = LngAdvancedSeachBTClear
        _AdvancedSearchEditor.btRechercher.Text = LngAdvancedSeachBTSearch
        _AdvancedSearchEditor.btSauver.Text = LngAdvancedSeachBTSave
        _AdvancedSearchEditor.lblNom.Text = LngAdvancedSeachLBName
        _AdvancedSearchEditor.cboAvailableSearchCriteria.Items.Clear()
        _AdvancedSearchEditor.cboAvailableSearchCriteria.Items.AddRange(LngAdvancedSeachCBCriteria.Split("|"c))
        _AdvancedSearchEditor.cboAvailableSearchCriteria.SelectedIndex = 0

        tvAdvancedSearch.deleteSearchToolStripMenuItem.Text = LngTreeviewDeleteMenuItem
        tvAdvancedSearch.editSearchToolStripMenuItem.Text = LngTreeviewEditMenuItem
        tvAdvancedSearch.renameSearchToolStripMenuItem.Text = LngTreeviewRenameMenuItem
        Text = LngSearchAdvancedTxt
        ViewFindOtherOccurrencesContextMenuItem.Text = LngSearchAdvancedFindOtherMenuItem
        mniAjouterAuxRecherche.Text = LngSearchAdvancedAddToSavedSearchesMenuItem
        mniImprimer.Text = LngSearchAdvancedPrintMenuItem


        LoadData()

        'Start = DateTime.Now
        'ProgramConfiguration = New ConfigurationData()
        Dim scc As New SearchCriteriaCollection()
        Dim isc As ISearchCriteria

        Cursor = Cursors.WaitCursor

        If typeRecherche <> Variables.objRecherche.Aucun Then

            Select Case typeRecherche
                Case Variables.objRecherche.ParTerme
                    If Not objRecherche.Equals(Nothing) Then
                        isc = New SearchCriteria_Title(DirectCast(objRecherche, String))
                        scc.Add(isc)
                    End If
                Case Variables.objRecherche.ParCategorie
                    If Not objRecherche.Equals(Nothing) Then
                        isc = New SearchCriteria_Category(DirectCast(objRecherche, String))
                        scc.Add(isc)
                    End If
                Case Variables.objRecherche.ParChaine
                    If Not objRecherche.Equals(Nothing) Then
                        isc = New SearchCriteria_Channel(DirectCast(objRecherche, String))
                        scc.Add(isc)
                    End If
                Case Variables.objRecherche.ParHoraire
                    If Not objRecherche.Equals(Nothing) Then
                        isc = New SearchCriteria_Date(DirectCast(objRecherche, DateTime), SearchCriteria_Date.DateFields.StartTime, SearchCriteria_Date.DateConditions.Equals)
                        scc.Add(isc)
                        Dim isc2 As ISearchCriteria =
                            New SearchCriteria_Time(DirectCast(objRecherche, DateTime), SearchCriteria_Time.TimeFields.StopTime, SearchCriteria_Time.TimeConditions.IsLaterThan)
                        scc.Add(isc2)
                        Dim isc3 As ISearchCriteria = New SearchCriteria_Time(DirectCast(objRecherche, DateTime), SearchCriteria_Time.TimeFields.StartTime, SearchCriteria_Time.TimeConditions.IsEarlierThan)
                        scc.Add(isc3)

                    End If
            End Select
            If Not objRecherche.Equals(Nothing) Then
                listViewEm.Clear()
                txbDescription.Clear()
                pbIcone.Image = Nothing
                Cursor = Cursors.WaitCursor

                listViewEm.InsertTVProgrammeRange(ListingsOrganizer.Search(scc))

                listViewEm.Sort(TVProgrammeComparer.ETVProgrammeSortBy.StartTime, TVProgrammeComparer.ETVProgrammeSortMode.Descending)
                DisplayTabs.SelectedTab = ListTab
                Cursor = Cursors.[Default]
            End If
        End If





        DisplayTabs.SelectedTab = ListTab

        Cursor = Cursors.[Default]
        'Finish = DateTime.Now

        'LoadTime = Finish - Start
        'statusBar.Text += [String].Format("  Démarrage en {0} secondes", LoadTime.TotalSeconds.ToString())
    End Sub

#End Region

#Region "ListView Events"

    Public Sub listView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewEm.SelectedIndexChanged
        If listViewEm.SelectedItems.Count > 0 Then
            Dim em As EmissionsList = DirectCast(listViewEm.SelectedItems(0).Tag, EmissionsList)
            If em.Pdescription.Equals(String.Empty) Then
                txbDescription.Text = LngListSearchAvancedNoDescription '"Pas de description."
            Else
                txbDescription.Text = em.Pdescription
            End If
            pbIcone.Image = Image.FromFile(Path.Combine(LogosPath, ListingsOrganizer.AllChannels(em.ChannelId).Logo))
        Else
            txbDescription.Text = String.Empty
            pbIcone.Image = Nothing
        End If

    End Sub

#End Region

#Region "TreeView Events"

    Private Sub treeView_OnEditSavedSearch(Asuic As AdvancedSearchUICollection)
        _AdvancedSearchEditor.EditSearch(Asuic)
        DisplayTabs.SelectedTab = AdvancedSearchTab
    End Sub

    Private Sub treeView_OnExecuteSearch(node As SuperTreeNode)
        If Not PremierDemarrage Then
            Dim scc As SearchCriteriaCollection = Nothing

            listViewEm.Clear()
            txbDescription.Clear()
            pbIcone.Image = Nothing
            Cursor = Cursors.WaitCursor

            Select Case node.NodeType
                Case TVTreeViewEx.SearchNodeType.StaticSearch
                    scc = node.SearchDefinition
                Case TVTreeViewEx.SearchNodeType.SpecificDates
                    scc = node.SearchDefinition
                Case TVTreeViewEx.SearchNodeType.SavedSearches
                    scc = node.Asuic.GetSearchCriteriaCollection()
            End Select

            If scc IsNot Nothing Then
                Dim searchResults As EmissionsList() = ListingsOrganizer.Search(scc)
                listViewEm.InsertTvProgrammeRange(searchResults)
                listViewEm.Sort(TVProgrammeComparer.ETVProgrammeSortBy.StartTime, TVProgrammeComparer.ETVProgrammeSortMode.Descending)
                DisplayTabs.SelectedTab = ListTab
            End If

            Cursor = Cursors.[Default]
        End If
        PremierDemarrage = False
    End Sub

#End Region

#Region "Context Menu Events"

    Private Sub FindOtherOccurrencesContextMenuItem_Click(sender As Object, e As EventArgs) Handles ViewFindOtherOccurrencesContextMenuItem.Click
        If listViewEm.SelectedItems.Count > 0 Then

            Dim prog As EmissionsList = Nothing
            Dim scc As New SearchCriteriaCollection()
            Dim isc As ISearchCriteria

            If DisplayTabs.SelectedTab Is ListTab Then
                prog = DirectCast(listViewEm.SelectedItems(0).Tag, EmissionsList)
            End If
            If Not prog.Equals(Nothing) Then
                isc = New SearchCriteria_Title(prog.Ptitle)
                scc.Add(isc)

                listViewEm.Clear()
                txbDescription.Clear()
                pbIcone.Image = Nothing
                Cursor = Cursors.WaitCursor

                listViewEm.InsertTvProgrammeRange(ListingsOrganizer.Search(scc))

                listViewEm.Sort(TVProgrammeComparer.ETVProgrammeSortBy.StartTime, TVProgrammeComparer.ETVProgrammeSortMode.Descending)
                DisplayTabs.SelectedTab = ListTab
                Cursor = Cursors.[Default]
            End If
        End If

    End Sub

#End Region

#Region "Advanced Search Control Events"

    Public Sub AdvancedSearchEditor_OnEditSearch(asuic As AdvancedSearchUICollection) Handles _AdvancedSearchEditor.OnEditSearch, _AdvancedSearchEditor.OnEditSearch
        tvAdvancedSearch.UpdateSavedSearch(asuic)
    End Sub

    Public Sub AdvancedSearchEditor_OnPerformSearch(asuic As AdvancedSearchUICollection) Handles _AdvancedSearchEditor.OnPerformSearch
        listViewEm.Clear()
        txbDescription.Clear()
        pbIcone.Image = Nothing
        Cursor = Cursors.WaitCursor

        listViewEm.InsertTVProgrammeRange(ListingsOrganizer.Search(asuic.GetSearchCriteriaCollection()))
        listViewEm.Sort(TVProgrammeComparer.ETVProgrammeSortBy.StartTime, TVProgrammeComparer.ETVProgrammeSortMode.Descending)
        DisplayTabs.SelectedTab = ListTab

        Cursor = Cursors.[Default]
    End Sub

    Public Sub AdvancedSearchEditor_OnSaveSearch(asuic As AdvancedSearchUICollection) Handles _AdvancedSearchEditor.OnSaveSearch
        tvAdvancedSearch.SavedSearches(asuic.Name) = asuic
        tvAdvancedSearch.CreateNodes_SavedSearches(tvAdvancedSearch.SavedSearches)
        CommitSavedSearches(tvAdvancedSearch.SavedSearches)
    End Sub

#End Region

    Private Sub mniImprimer_Click(sender As Object, e As EventArgs) Handles mniImprimer.Click
        If listViewEm.Items.Count > 0 Then
            Dim retour(listViewEm.Items.Count - 1) As EmissionsList
            For i As Integer = 0 To listViewEm.Items.Count - 1
                retour(i) = DirectCast(listViewEm.Items(i).Tag, EmissionsList)
            Next
            Dim imprim As New ImprimeEmissions(LngPrintDescription, retour)
            imprim.VoirPrevisualisation()
        Else
            MessageBox.Show(LngPrintErrorMessage, LngPrintErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub mniAjouterAuxRecherche_Click(sender As Object, e As EventArgs) Handles mniAjouterAuxRecherche.Click
        If listViewEm.SelectedItems.Count > 0 Then

            Dim prog As EmissionsList = Nothing

            If DisplayTabs.SelectedTab Is ListTab Then
                If listViewEm.SelectedItems.Count > 0 Then
                    prog = DirectCast(listViewEm.SelectedItems(0).Tag, EmissionsList)
                End If
            End If
            'create a saved search consisting of the following criteria:
            ' - show title
            ' - show start time
            ' - show start day of the week
            'name saved search <Title> on <Day> at <Time> and automatically add it to the schedule
            If Not prog.Equals(Nothing) Then
                Dim searchName As String
                If LngListSearchAvancedGeneral.Equals("en") Then
                    searchName = [String].Format("{0} on {1} at {2}", prog.Ptitle, prog.Pstart.ToString("dddd", New CultureInfo("en-GB")), prog.Pstart.ToLongTimeString())
                Else
                    searchName = [String].Format("{0} le {1} à {2}", prog.Ptitle, prog.Pstart.ToString("dddd", New CultureInfo("fr-FR")), prog.Pstart.ToLongTimeString())
                End If
                Dim asuic As New AdvancedSearchUICollection()
                Dim texte As New AdvancedSearch_TextFields()
                Dim dow As New AdvancedSearch_DayOfWeek()
                Dim time As New AdvancedSearch_Time()

                texte.Field = AdvancedSearch_TextFields.Fields.Title
                texte.Condition = AdvancedSearch_TextFields.Conditions.Contains
                texte.CriteriaText = prog.Ptitle

                dow.Condition = AdvancedSearch_DayOfWeek.Conditions.Equals
                dow.Day = prog.Pstart.DayOfWeek

                time.Field = AdvancedSearch_Time.Fields.StartTime
                time.Condition = AdvancedSearch_Time.Conditions.Equals
                time.Time = prog.Pstart

                asuic.Add(texte)
                asuic.Add(dow)
                asuic.Add(time)
                asuic.Name = searchName

                tvAdvancedSearch.SavedSearches(searchName) = asuic
                tvAdvancedSearch.CreateNodes_SavedSearches(tvAdvancedSearch.SavedSearches)
                CommitSavedSearches(tvAdvancedSearch.SavedSearches)
            End If
        End If
    End Sub

End Class
