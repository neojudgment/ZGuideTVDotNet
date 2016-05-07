' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2016 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
Imports System.Globalization
Imports System.Windows.Forms

''' <summary>
''' Summary description for TVListView.
''' </summary>
Public Class TVListView
    Inherits ListView
    'Private ColNotify As New ColumnHeader()
    Private ReadOnly _colDate As New ColumnHeader()
    Public ColStartTime As New ColumnHeader()
    Public ColEndTime As New ColumnHeader()
    Public ColTitle As New ColumnHeader()
    Public ColChannel As New ColumnHeader()
    Public ColCategory As New ColumnHeader()
    'Private ReadOnly ColPreviouslyShown As New ColumnHeader()
    'Private ReadOnly ColAddInfo As New ColumnHeader()

    Private Shared ReadOnly TvComp As New TVGuide.TVProgrammeComparer()

    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private _components As System.ComponentModel.Container = Nothing

    Public Sub New()
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        ' TODO: Add any initialization after the InitializeComponent call

        SetProperties()
        InsertColumns()
    End Sub

#Region "ListView Initialization Code"
    Private Sub SetProperties()
        View = View.Details
        FullRowSelect = True
        GridLines = True
        Scrollable = True
        BorderStyle = BorderStyle.None
    End Sub

    Private Sub InsertColumns()
        'ColNotify.Text = "Notify Me"
        'ColNotify.Width = 60

        _colDate.Text = "Date"
        _colDate.Width = 60

        ColStartTime.Text = LngListSearchAvancedStart '"Début"
        ColStartTime.Width = 65

        ColEndTime.Text = LngListSearchAvancedStop '"Fin"
        ColEndTime.Width = 65

        ColTitle.Text = LngListSearchAvancedTitle '"Titre"
        ColTitle.Width = 360

        ColChannel.Text = LngListSearchAvancedChannel '"Chaine"
        ColChannel.Width = 140

        ColCategory.Text = LngListSearchAvancedCategory '"Catégorie"
        ColCategory.Width = 190
        'ColPreviouslyShown.Text = "Rpt"
        'ColPreviouslyShown.Width = 32

        'ColAddInfo.Text = "Commentaires"
        'ColAddInfo.Width = 165

        'If Me.CheckBoxes = True Then
        '    Me.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColNotify, Me.ColDate, Me.ColStartTime, Me.ColEndTime, Me.ColTitle, Me.ColChannel, _
        '     Me.ColPreviouslyShown, Me.ColAddInfo})
        'Else
        Columns.AddRange(New ColumnHeader() {_colDate, ColStartTime, ColEndTime, ColTitle, ColCategory, ColChannel}) ', ColPreviouslyShown, ColAddInfo})
        'End If
    End Sub
#End Region

#Region "Overloaded Methods"
    Public Shadows Sub Clear()
        MyBase.Clear()
        ListViewItemSorter = Nothing
        InsertColumns()
    End Sub

    Public Overloads Sub Sort(sortBy As TVGuide.TVProgrammeComparer.ETVProgrammeSortBy, sortMode As TVGuide.TVProgrammeComparer.ETVProgrammeSortMode)
        TvComp.SortBy = sortBy
        TvComp.SortMode = SortMode

        ListViewItemSorter = New ListViewItemComparer()
        Sort()
        UpdateListViemItemBackground()
    End Sub
#End Region

#Region "Specialized Item Insertion"

    Public Sub InsertTvProgramme(programme As EmissionsList)
        Dim item As New ListViewItem()
        'item.BackColor = programme.BackColor

        'If CheckBoxes = True Then
        '    item.Text = ""
        '    item.SubItems.Add(programme.StartTime.ToLongDateString())
        'Else
        '    If programme.StartTime.Day = 1 OrElse programme.StartTime.Day = 21 OrElse programme.StartTime.Day = 31 Then
        '        item.Text = programme.StartTime.ToString("ddd d") & "st"
        '    ElseIf programme.StartTime.Day = 2 OrElse programme.StartTime.Day = 22 Then
        '        item.Text = programme.StartTime.ToString("ddd d") & "nd"
        '    ElseIf programme.StartTime.Day = 3 OrElse programme.StartTime.Day = 23 Then
        '        item.Text = programme.StartTime.ToString("ddd d") & "rd"
        '    Else
        '        item.Text = programme.StartTime.ToString("ddd d") & "th"
        '    End If
        'End If


        If LngListSearchAvancedGeneral.Equals("fr") Then
            item.Text = programme.Pstart.ToString("ddd d", New CultureInfo("fr-FR"))
        Else
            If programme.Pstart.Day = 1 OrElse programme.Pstart.Day = 21 OrElse programme.Pstart.Day = 31 Then
                item.Text = programme.Pstart.ToString("ddd d", New CultureInfo("en-GB")) & "st"
            ElseIf programme.Pstart.Day = 2 OrElse programme.Pstart.Day = 22 Then
                item.Text = programme.Pstart.ToString("ddd d", New CultureInfo("en-GB")) & "nd"
            ElseIf programme.Pstart.Day = 3 OrElse programme.Pstart.Day = 23 Then
                item.Text = programme.Pstart.ToString("ddd d", New CultureInfo("en-GB")) & "rd"
            Else
                item.Text = programme.Pstart.ToString("ddd d", New CultureInfo("en-GB")) & "th"
            End If

        End If

        item.SubItems.Add(programme.Pstart.ToLongTimeString())
        item.SubItems.Add(programme.Pstop.ToLongTimeString())
        If programme.Psubtitle Is Nothing OrElse programme.Psubtitle.Length = 0 OrElse programme.Psubtitle.IndexOf("N/A", StringComparison.Ordinal) >= 0 Then
            item.SubItems.Add(programme.Ptitle)
        Else
            item.SubItems.Add(programme.Ptitle & " (" & programme.Psubtitle & ")")
        End If
        If programme.Pcategory Is Nothing Then
            item.SubItems.Add(programme.PcategoryTv)
        Else
            item.SubItems.Add(programme.Pcategory.Substring(0, programme.Pcategory.Length - 1))
        End If
        If programme.ChannelId IsNot Nothing Then
            'item.SubItems.Add(programme.Channel.DisplayName)
            item.SubItems.Add(TVGuideMainForm.ListingsOrganizer.AllChannels(programme.ChannelId).Nom)
        End If
        'item.SubItems.Add(programme.PreviouslyShown)
        'item.SubItems.Add(programme.AddInfo())

        item.Tag = programme

        'this.Items.AddRange(new ListViewItem[]{item});
        Items.Add(item)
    End Sub

    Public Sub InsertTvProgrammeRange(programme As EmissionsList())
        'InsertTVProgrammeRange(programme, Nothing)
        BeginUpdate()

        For Each prog As EmissionsList In programme
            InsertTvProgramme(prog)
        Next
        EndUpdate()
    End Sub

    Friend Sub UpdateListViemItemBackground()
        Dim b As Boolean

        For Each lvi As ListViewItem In Items
            If b Then
                lvi.BackColor = Color.WhiteSmoke
            Else
                lvi.BackColor = Color.White
            End If
            b = Not b
        Next

    End Sub

    'Public Sub InsertTVProgrammeRange(programme As EmissionsList(), sFilterCategory As String)
    '    BeginUpdate()

    '    For Each prog As EmissionsList In programme
    '        If sFilterCategory Is Nothing OrElse sFilterCategory.Length = 0 Then
    '            InsertTVProgramme(prog)
    '        ElseIf prog.IsInCategory(sFilterCategory) = True Then
    '            InsertTVProgramme(prog)
    '        End If
    '    Next
    '    EndUpdate()
    'End Sub
#End Region


    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If _components IsNot Nothing Then
                _components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"
    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        _components = New System.ComponentModel.Container()
        AddHandler Me.ColumnClick, New ColumnClickEventHandler(AddressOf TVListView_ColumnClick)
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub TVListView_ColumnClick(sender As Object, e As ColumnClickEventArgs)
        'This column is not used for sorting
        'If Me.Columns(e.Column) Is ColNotify Then
        '    Return
        'End If

        'This column is not used for sorting
        If Columns(e.Column) Is _colDate Then
            Return
        End If

        If Columns(e.Column) Is ColStartTime Then
            TVComp.SortBy = TVGuide.TVProgrammeComparer.ETVProgrammeSortBy.StartTime
        End If

        If Columns(e.Column) Is ColEndTime Then
            TVComp.SortBy = TVGuide.TVProgrammeComparer.ETVProgrammeSortBy.StopTime
        End If

        If Columns(e.Column) Is ColTitle Then
            TVComp.SortBy = TVGuide.TVProgrammeComparer.ETVProgrammeSortBy.Title
        End If

        If Columns(e.Column) Is ColChannel Then
            TVComp.SortBy = TVGuide.TVProgrammeComparer.ETVProgrammeSortBy.Channel
        End If

        If Columns(e.Column) Is ColCategory Then
            TVComp.SortBy = TVGuide.TVProgrammeComparer.ETVProgrammeSortBy.Category
        End If


        'this.ListViewItemSorter=new ListViewItemComparer();
        ListViewItemComparer.FlipSortingOrder()
        Sort()
        UpdateListViemItemBackground()

    End Sub
#End Region

#Region "ListView's Item Comparer - Uses TVComparer's Comparison Functions"
    Protected Class ListViewItemComparer
        Implements IComparer
        Public Sub New()
            FlipSortingOrder()
        End Sub

        Public Shared Sub FlipSortingOrder()
            'Flip sorting mode
            Select Case TVComp.SortMode
                Case TVGuide.TVProgrammeComparer.ETVProgrammeSortMode.Ascending
                    TVComp.SortMode = TVGuide.TVProgrammeComparer.ETVProgrammeSortMode.Descending
                Case TVGuide.TVProgrammeComparer.ETVProgrammeSortMode.Descending
                    TVComp.SortMode = TVGuide.TVProgrammeComparer.ETVProgrammeSortMode.Ascending
            End Select
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim prog1 As EmissionsList = DirectCast(DirectCast(x, ListViewItem).Tag, EmissionsList)
            Dim prog2 As EmissionsList = DirectCast(DirectCast(y, ListViewItem).Tag, EmissionsList)

            Return (TVComp.Compare(prog1, prog2))
        End Function
    End Class
#End Region
End Class
