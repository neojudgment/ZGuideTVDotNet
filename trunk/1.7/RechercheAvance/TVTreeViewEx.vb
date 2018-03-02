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
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization
Imports ZGuideTV.TVGuide

Partial Public Class TvTreeViewEx
    Inherits UserControl
#Region "Enumerations"

    Public Enum SearchNodeType
        Unknown
        StaticSearch
        SpecificDates
        SavedSearches
    End Enum

    'Public Enum PredefinedSearch
    '    RightNow
    '    OnNext
    '    FewHoursFromNow
    '    RemainingToday
    '    Tomorrow
    '    MoviesToday
    '    MoviesTomorrow
    '    AllMovies
    'End Enum

#End Region

    Private _mSavedSearches As New Hashtable()
    'Private ReadOnly StaticSearchesParent As New SuperTreeNode()
    Private ReadOnly _savedSearchesParent As New SuperTreeNode()
    'Private HighlighterParent As New SuperTreeNode()
    'Private HighlighterGroupsParent As New SuperTreeNode()
    Private ReadOnly _specificDatesParent As New SuperTreeNode()
    Private ReadOnly _channelsParent As New SuperTreeNode()
    Private ReadOnly _categoriesParent As New SuperTreeNode()

    'Private ReadOnly StaticSearch_RightNow As New SuperTreeNode()
    'Private ReadOnly StaticSearch_OnNext As New SuperTreeNode()
    'Private StaticSearch_FewHoursFromNow As New SuperTreeNode()
    'Private ReadOnly StaticSearch_RemainingToday As New SuperTreeNode()
    'Private ReadOnly StaticSearch_Tomorrow As New SuperTreeNode()
    'Private StaticSearch_MoviesToday As New SuperTreeNode()
    'Private StaticSearch_MoviesTomorrow As New SuperTreeNode()
    'Private StaticSearch_AllMovies As New SuperTreeNode()

    Public Delegate Sub ExecuteSearch(node As SuperTreeNode)
    Public Event OnExecuteSearch As ExecuteSearch

    Public Delegate Sub EditSavedSearch(asuic As AdvancedSearchUICollection)
    Public Event OnEditSavedSearch As EditSavedSearch

    Public Sub New()
        InitializeComponent()
        BorderStyle = BorderStyle.None
        Clear()
        _mSavedSearches = New Hashtable()
    End Sub

#Region "Properties"

    Public Property SavedSearches() As Hashtable
        Get
            Return (_mSavedSearches)
        End Get
        Set(value As Hashtable)
            If value Is Nothing Then
                _mSavedSearches = New Hashtable()
            Else
                _mSavedSearches = value
            End If
        End Set
    End Property

#End Region

#Region "Node Creation & Initialization Methods"

    Public Sub Clear()
        treeView1.Nodes.Clear()
        treeView1.TreeViewNodeSorter = New SortChildNodes(New SuperTreeNode() {_savedSearchesParent, _specificDatesParent})
    End Sub

    'searches that are always in the tree in a certain order as part of the app's functionality
    'Public Sub CreateNodes_StaticSearches(FewHoursFromNow As Integer)
    '    Dim isc As ISearchCriteria '= Nothing
    '    Dim scc As SearchCriteriaCollection '= Nothing

    '    treeView1.BeginUpdate()

    '    StaticSearchesParent.Text = "Recherches Internes"
    '    StaticSearchesParent.Nodes.Clear()

    '    'right now
    '    StaticSearch_RightNow.NodeType = SearchNodeType.StaticSearch
    '    StaticSearch_RightNow.Text = "Maintenant"
    '    isc = New SearchCriteria_IsOnNow()
    '    scc = New SearchCriteriaCollection()
    '    scc.Add(isc)
    '    StaticSearch_RightNow.SearchDefinition = scc
    '    StaticSearchesParent.Nodes.Add(StaticSearch_RightNow)

    '    'on next
    '    StaticSearch_OnNext.NodeType = SearchNodeType.StaticSearch
    '    StaticSearch_OnNext.Text = "Suivant"
    '    isc = New SearchCriteria_OnNext()
    '    scc = New SearchCriteriaCollection()
    '    scc.Add(isc)
    '    StaticSearch_OnNext.SearchDefinition = scc
    '    StaticSearchesParent.Nodes.Add(StaticSearch_OnNext)

    '    ''few hours from now
    '    'StaticSearch_FewHoursFromNow.NodeType = SearchNodeType.StaticSearch
    '    'StaticSearch_FewHoursFromNow.Text = "Few Hours From Now"
    '    'isc = New SearchCriteria_TimeProximity(New TimeSpan(FewHoursFromNow, 0, 0))
    '    'scc = New SearchCriteriaCollection()
    '    'scc.Add(isc)
    '    'StaticSearch_FewHoursFromNow.SearchDefinition = scc
    '    'StaticSearch_FewHoursFromNow.ToolTipText = [String].Format("Searches for all shows starting within the next {0} hours.", FewHoursFromNow)
    '    'StaticSearchesParent.Nodes.Add(StaticSearch_FewHoursFromNow)

    '    'remaining today
    '    StaticSearch_RemainingToday.NodeType = SearchNodeType.StaticSearch
    '    StaticSearch_RemainingToday.Text = "Remaining Today"
    '    Dim isc1 As ISearchCriteria = New SearchCriteria_Date(DateTime.Now, SearchCriteria_Date.DateFields.StartTime, SearchCriteria_Date.DateConditions.Equals)
    '    Dim isc2 As ISearchCriteria = New SearchCriteria_Time(DateTime.Now, SearchCriteria_Time.TimeFields.StartTime, SearchCriteria_Time.TimeConditions.Equals)
    '    Dim isc3 As ISearchCriteria = New SearchCriteria_Time(DateTime.Now, SearchCriteria_Time.TimeFields.StartTime, SearchCriteria_Time.TimeConditions.IsLaterThan)
    '    Dim or_condition As ISearchCriteria = New SearchCriteria_OrCondition(New ISearchCriteria() {isc2, isc3})
    '    scc = New SearchCriteriaCollection()
    '    scc.Add(isc1)
    '    scc.Add(or_condition)
    '    StaticSearch_RemainingToday.SearchDefinition = scc
    '    StaticSearchesParent.Nodes.Add(StaticSearch_RemainingToday)

    '    'tomorrow
    '    StaticSearch_Tomorrow.NodeType = SearchNodeType.StaticSearch
    '    StaticSearch_Tomorrow.Text = "Demain"
    '    isc = New SearchCriteria_Date(DateTime.Now.AddDays(1), SearchCriteria_Date.DateFields.StartTime, SearchCriteria_Date.DateConditions.Equals)
    '    scc = New SearchCriteriaCollection()
    '    scc.Add(isc)
    '    StaticSearch_Tomorrow.SearchDefinition = scc
    '    StaticSearchesParent.Nodes.Add(StaticSearch_Tomorrow)


    '    treeView1.Nodes.Add(StaticSearchesParent)
    '    StaticSearchesParent.ExpandAll()
    '    treeView1.EndUpdate()
    'End Sub

    'Public Sub CreateNodes_Highlighters(htHighlihterTags As Hashtable, chc As CustomHighlightCollection)
    '    HighlighterParent.Nodes.Clear()
    '    HighlighterParent.Text = "Highlighters"

    '    HighlighterGroupsParent.Nodes.Clear()
    '    HighlighterGroupsParent.Text = "Highlighter Groups"

    '    treeView1.BeginUpdate()

    '    For Each c As CustomHighlight In chc
    '        Dim node As New SuperTreeNode()
    '        node.NodeType = SearchNodeType.StaticSearch
    '        Dim isc As ISearchCriteria = New SearchCriteria_CustomHighlight(c.SearchString, c.FieldToSearch, c.SearchMatchMethod)
    '        Dim scc As New SearchCriteriaCollection()
    '        scc.Add(isc)
    '        node.SearchDefinition = scc
    '        node.Text = c.ToString()

    '        HighlighterParent.Nodes.Add(node)
    '    Next

    '    For Each oTag As DictionaryEntry In htHighlihterTags
    '        Dim node As New SuperTreeNode()
    '        node.NodeType = SearchNodeType.StaticSearch
    '        Dim isc As ISearchCriteria = New SearchCriteria_CustomHighlightGroup(DirectCast(oTag.Key, String))
    '        Dim scc As New SearchCriteriaCollection()
    '        scc.Add(isc)
    '        node.SearchDefinition = scc
    '        node.Text = Convert.ToString(oTag.Key) & " (" & Convert.ToString(oTag.Value) & ")"

    '        HighlighterGroupsParent.Nodes.Add(node)
    '    Next

    '    If treeView1.Nodes.Contains(HighlighterParent) = False AndAlso treeView1.Nodes.Contains(HighlighterGroupsParent) = False Then
    '        treeView1.Nodes.Add(HighlighterParent)
    '        treeView1.Nodes.Add(HighlighterGroupsParent)
    '    End If

    '    HighlighterParent.ExpandAll()
    '    HighlighterGroupsParent.ExpandAll()

    '    treeView1.EndUpdate()
    'End Sub

    Public Sub CreateNodes_Channels(channels As Dictionary(Of String, ProgrammeOrganizer.InfoChaine))
        treeView1.BeginUpdate()
        treeView1.TreeViewNodeSorter = New SortChildNodes(New SuperTreeNode() {_savedSearchesParent, _specificDatesParent})

        _channelsParent.Nodes.Clear()
        _channelsParent.Text = LngTreeviewSearchAdvancedChannels '"Chaines"

        For Each chan As KeyValuePair(Of String, ProgrammeOrganizer.InfoChaine) In channels
            Dim node As New SuperTreeNode()
            node.NodeType = SearchNodeType.StaticSearch
            Dim isc As ISearchCriteria = New SearchCriteria_Channel(chan.Key)
            Dim scc As New SearchCriteriaCollection()
            scc.Add(isc)
            node.SearchDefinition = scc
            node.Text = chan.Value.Nom

            _channelsParent.Nodes.Add(node)
        Next

        treeView1.Nodes.Add(_channelsParent)
        'treeView1.TreeViewNodeSorter = new SortChildNodes(new SuperTreeNode[] { SavedSearchesParent, HighlighterParent, HighlighterGroupsParent, SpecificDatesParent });
        treeView1.Sort()
        treeView1.EndUpdate()
    End Sub

    Public Sub CreateNodes_Categories(categories As ArrayList)
        treeView1.BeginUpdate()
        treeView1.TreeViewNodeSorter = New SortChildNodes(New SuperTreeNode() {_savedSearchesParent, _specificDatesParent})

        _categoriesParent.Nodes.Clear()
        _categoriesParent.Text = LngTreeviewSearchAdvancedCategories ' "Categories"
        For Each cat As String In categories
            Dim node As New SuperTreeNode()
            node.NodeType = SearchNodeType.StaticSearch
            Dim isc As ISearchCriteria = New SearchCriteria_Category(cat)
            Dim scc As New SearchCriteriaCollection()
            scc.Add(isc)
            node.SearchDefinition = scc
            node.Text = cat

            _categoriesParent.Nodes.Add(node)
        Next
        treeView1.Nodes.Add(_categoriesParent)
        'treeView1.TreeViewNodeSorter = new SortChildNodes(new SuperTreeNode[] { SavedSearchesParent, HighlighterParent, HighlighterGroupsParent, SpecificDatesParent });
        treeView1.Sort()
        treeView1.EndUpdate()

    End Sub
    Public Sub CreateNodes_SpecificDates(dtStartDate As DateTime, dtEndDate As DateTime)
        treeView1.BeginUpdate()

        _specificDatesParent.Nodes.Clear()
        _specificDatesParent.Text = LngTreeviewSearchAdvancedDay '"Jours"

        Dim dt As New DateTime(dtStartDate.Year, dtStartDate.Month, dtStartDate.Day, 8, 0, 0)

        While dtStartDate < dtEndDate
            Dim node As New SuperTreeNode()
            node.NodeType = SearchNodeType.SpecificDates
            Dim isc As ISearchCriteria = New SearchCriteria_Date(dtStartDate, SearchCriteria_Date.DateFields.StartTime, SearchCriteria_Date.DateConditions.Equals)
            Dim scc As New SearchCriteriaCollection()
            scc.Add(isc)
            node.SearchDefinition = scc
            node.ScrollToThisTime = dtStartDate
            node.Text = dtStartDate.ToLongDateString()

            Dim dtDate As DateTime = dtStartDate
            If LngTreeviewSearchAvancedGeneral.Equals("en") Then
                If dtDate.Day = 1 OrElse dtDate.Day = 21 OrElse dtDate.Day = 31 Then
                    node.Text = dtDate.ToString("ddd d", New CultureInfo("en-GB")) & "st" & dtDate.ToString(" MMM yy", New CultureInfo("en-GB"))
                ElseIf dtDate.Day = 2 OrElse dtDate.Day = 22 Then
                    node.Text = dtDate.ToString("ddd d", New CultureInfo("en-GB")) & "nd" & dtDate.ToString(" MMM yy", New CultureInfo("en-GB"))
                ElseIf dtDate.Day = 3 OrElse dtDate.Day = 23 Then
                    node.Text = dtDate.ToString("ddd d", New CultureInfo("en-GB")) & "rd" & dtDate.ToString(" MMM yy", New CultureInfo("en-GB"))
                Else
                    node.Text = dtDate.ToString("ddd d", New CultureInfo("en-GB")) & "th" & dtDate.ToString(" MMM yy", New CultureInfo("en-GB"))
                End If
            Else
                node.Text = dtDate.ToString("ddd d") & dtDate.ToString(" MMM yy", New CultureInfo("fr-FR"))

            End If

            node.Text += " (" & dtDate.ToShortDateString() & ")"

            If dtStartDate.ToShortDateString = DateTime.Now.ToShortDateString AndAlso dtStartDate.ToShortDateString = DateTime.Now.ToShortDateString Then
                node.BackColor = Color.Thistle
            End If
            _specificDatesParent.Nodes.Add(node)

            dt = dt.AddDays(1)
            dtStartDate = dt
        End While

        treeView1.Nodes.Add(_specificDatesParent)
        _specificDatesParent.ExpandAll()

        treeView1.EndUpdate()
    End Sub

    Public Sub CreateNodes_SavedSearches(searches As Hashtable)
        If searches IsNot Nothing Then
            _mSavedSearches = searches
            CreateNodes_SavedSearches()
        End If
    End Sub

    Public Sub CreateNodes_SavedSearches()
        treeView1.BeginUpdate()

        _savedSearchesParent.Nodes.Clear()
        _savedSearchesParent.Text = LngTreeviewSearchAdvancedSavedSearches '"Recherches sauvées"

        For Each key As String In _mSavedSearches.Keys
            Dim node As New SuperTreeNode()
            node.NodeType = SearchNodeType.SavedSearches
            node.Asuic = DirectCast(_mSavedSearches(key), AdvancedSearchUICollection)
            node.Text = node.Asuic.Name

            node.ContextMenuStrip = SavedSearchesContextMenu

            _savedSearchesParent.Nodes.Add(node)
        Next

        If treeView1.Nodes.Contains(_savedSearchesParent) = False Then
            treeView1.Nodes.Add(_savedSearchesParent)
        End If

        treeView1.TreeViewNodeSorter = New SortChildNodes(New SuperTreeNode() {_savedSearchesParent, _specificDatesParent})
        treeView1.Sort()

        _savedSearchesParent.ExpandAll()
        treeView1.EndUpdate()
    End Sub

    Public Sub UpdateSavedSearch(search As AdvancedSearchUICollection)
        'update an existing search that was just edited
        For Each stn As SuperTreeNode In _savedSearchesParent.Nodes
            If stn.Asuic.Name = search.Name Then
                stn.Asuic = search
                _mSavedSearches(search.Name) = search
            End If
        Next
    End Sub

#End Region

    'Public Sub ExecutePredefinedSearch(ps As PredefinedSearch)
    '    Select Case ps
    '        Case PredefinedSearch.RightNow
    '            treeView1.SelectedNode = StaticSearch_RightNow


    '        Case PredefinedSearch.OnNext
    '            treeView1.SelectedNode = StaticSearch_OnNext


    '            'Case PredefinedSearch.FewHoursFromNow
    '            '    treeView1.SelectedNode = StaticSearch_FewHoursFromNow


    '        Case PredefinedSearch.RemainingToday
    '            treeView1.SelectedNode = StaticSearch_RemainingToday


    '        Case PredefinedSearch.Tomorrow
    '            treeView1.SelectedNode = StaticSearch_RemainingToday


    '            'Case PredefinedSearch.MoviesToday
    '            '    treeView1.SelectedNode = StaticSearch_MoviesToday


    '            'Case PredefinedSearch.MoviesTomorrow
    '            '    treeView1.SelectedNode = StaticSearch_MoviesTomorrow


    '            'Case PredefinedSearch.AllMovies
    '            '    treeView1.SelectedNode = StaticSearch_AllMovies

    '    End Select
    'End Sub

#Region "Helper Methods"

    Private Function IsSearchNameTaken(nom As String) As Boolean
        For Each key As String In _mSavedSearches.Keys
            Dim asuic As AdvancedSearchUICollection = DirectCast(_mSavedSearches(key), AdvancedSearchUICollection)
            If asuic.Name = Nom Then
                Return (True)
            End If
        Next

        Return (False)
    End Function

#End Region

#Region "InternalEvents"

    Private Sub treeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeView1.AfterSelect
        Dim node As SuperTreeNode = TryCast(e.Node, SuperTreeNode)

        RaiseEvent OnExecuteSearch(node)
    End Sub

    Private Sub deleteSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles deleteSearchToolStripMenuItem.Click
        _mSavedSearches.Remove(treeView1.SelectedNode.Text)
        _savedSearchesParent.Nodes.Remove(treeView1.SelectedNode)
    End Sub

    Private Sub editSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles editSearchToolStripMenuItem.Click
        If OnEditSavedSearchEvent IsNot Nothing Then
            Dim node As SuperTreeNode = TryCast(treeView1.SelectedNode, SuperTreeNode)
            RaiseEvent OnEditSavedSearch(node.Asuic)
        End If
    End Sub

    Private Sub renameSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles renameSearchToolStripMenuItem.Click
        treeView1.LabelEdit = True
        If Not treeView1.SelectedNode.IsEditing Then
            treeView1.SelectedNode.BeginEdit()
        End If
    End Sub

    Private Sub treeView1_MouseUp(sender As Object, e As MouseEventArgs) Handles treeView1.MouseUp
        If e.Button = MouseButtons.Right Then
            ' Point where the mouse is clicked.
            Dim p As New Point(e.X, e.Y)

            ' Get the node that the user has clicked.
            Dim node As TreeNode = treeView1.GetNodeAt(p)
            If node IsNot Nothing Then
                ' Select the node the user has clicked.
                ' The node appears selected until the menu is displayed on the screen.                    
                treeView1.SelectedNode = node
            End If
        End If
    End Sub

    'Public Delegate Sub SavedSearchRenamed(OldName As String, NewName As String)
    'Public Event OnSavedSearchRenamed As SavedSearchRenamed

    Private Delegate Sub MyDelegate()
    Private Sub treeView1_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles treeView1.AfterLabelEdit
        If e.Label IsNot Nothing Then
            If e.Label.Length > 0 AndAlso IsSearchNameTaken(e.Label) = False Then
                Dim asuic As AdvancedSearchUICollection = DirectCast(_mSavedSearches(e.Node.Text), AdvancedSearchUICollection)
                asuic.Name = e.Label
                _mSavedSearches.Remove(e.Node.Text)
                _mSavedSearches.Add(e.Label, asuic)
                'RaiseEvent OnSavedSearchRenamed(e.Node.Text, e.Label)
                e.Node.Text = e.Label
                e.Node.EndEdit(False)
            Else
                ' Cancel the label edit action, inform the user, and 
                '                       place the node in edit mode again. 

                e.CancelEdit = True
                MessageBox.Show("Invalid saved search name." & vbLf & "The label cannot be blank or match an existing saved search", "ZG")
                e.Node.BeginEdit()
            End If
        End If
        treeView1.LabelEdit = False

        BeginInvoke(DirectCast(Sub()
                                   treeView1.BeginUpdate()
                                   treeView1.TreeViewNodeSorter = New SortChildNodes(New SuperTreeNode() {_savedSearchesParent, _specificDatesParent})
                                   treeView1.Sort()
                                   treeView1.EndUpdate()

                               End Sub, MyDelegate))
    End Sub

#End Region

End Class
