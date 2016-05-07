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

Imports System.Diagnostics
Imports System.Windows.Forms
Imports ZGuideTV.TVGuide

Partial Public Class AdvancedSearchEditor
    Inherits UserControl
    Public Delegate Sub ReturnSearchCollection(asuic As AdvancedSearchUICollection)
    Public Event OnPerformSearch As ReturnSearchCollection
    'fires when the user just wants to execute a search
    Public Event OnSaveSearch As ReturnSearchCollection
    'fires when the user wants to save the current criteria 
    Public Event OnEditSearch As ReturnSearchCollection
    'fires when the user clicks save when a previously defined search has been loaded for editing
    Private _mEditingSearch As Boolean = False

    Public Sub New()
        InitializeComponent()

        cboAvailableSearchCriteria.SelectedIndex = 0
    End Sub

    Public Sub EditSearch(asuic As AdvancedSearchUICollection)
        ClearButton_Click(Nothing, Nothing)
        InsertSearch(asuic)
        _mEditingSearch = True
        tbNom.Text = asuic.Name
        tbNom.Enabled = False
    End Sub

#Region "Helper Methods"

    Private Function GetSearchCriteriaCollection() As AdvancedSearchUICollection
        Dim asuic As AdvancedSearchUICollection = Nothing

        If flpRecherche.Controls.Count > 0 Then
            asuic = New AdvancedSearchUICollection()
            For Each i As IAdvancedSearchUI In flpRecherche.Controls
                asuic.Add(i)
            Next
        End If

        Return (asuic)
    End Function

    Private Sub InsertSearch(asuic As AdvancedSearchUICollection)
        Dim i_uc As IAdvancedSearchUI
        For Each uc As UserControl In asuic
            i_uc = DirectCast(uc, IAdvancedSearchUI)
            flpRecherche.Controls.Add(uc)
            AddHandler i_uc.OnRemoveControl, New RemoveControl(AddressOf i_uc_OnRemoveControl)
        Next
    End Sub

#End Region

#Region "Internal Events"

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles btInserer.Click
        Dim uc As UserControl '= Nothing
        Dim i_uc As IAdvancedSearchUI '= Nothing

        Dim sc As SearchCriteria = CType([Enum].ToObject(GetType(SearchCriteria), CInt(cboAvailableSearchCriteria.SelectedIndex)), SearchCriteria)
        uc = AdvancedSearchFactory.CreateAdvancedSearchUc(sc)

        i_uc = DirectCast(uc, IAdvancedSearchUI)
        AddHandler i_uc.OnRemoveControl, New RemoveControl(AddressOf i_uc_OnRemoveControl)

        flpRecherche.Controls.Add(uc)
    End Sub

    Private Sub i_uc_OnRemoveControl(sender As Object)
        flpRecherche.Controls.Remove(DirectCast(sender, Control))
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles btNettoyer.Click
        flpRecherche.Controls.Clear()
        tbNom.Text = ""
        tbNom.Enabled = True
        _mEditingSearch = False
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles btRechercher.Click
        Dim allCriteriaValid As Boolean = True
        'validate the search objects first before throwing the event
        For Each i As IAdvancedSearchUI In flpRecherche.Controls
            If i.ValidateCriteria() = False Then
                allCriteriaValid = False
            End If
        Next

        If allCriteriaValid = True AndAlso OnPerformSearchEvent IsNot Nothing Then
            RaiseEvent OnPerformSearch(GetSearchCriteriaCollection())
        Else
            MessageBox.Show(LngAdvancedSeachError1Message, LngAdvancedSeachErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub

    Private Sub SaveSearchButton_Click(sender As Object, e As EventArgs) Handles btSauver.Click
        If tbNom.Text.Length > 0 Then
            Dim asuic As AdvancedSearchUICollection = GetSearchCriteriaCollection()
            asuic.Name = tbNom.Text

            If _mEditingSearch = False Then
                RaiseEvent OnSaveSearch(asuic)
            Else
                RaiseEvent OnEditSearch(asuic)
            End If

            ClearButton_Click(Nothing, Nothing)
        Else
            MessageBox.Show(LngAdvancedSeachError2Message, LngAdvancedSeachErrorTitle)
        End If
    End Sub

    Private Sub SearchFlowLayoutPanel_ControlAddedRemoved(sender As Object, e As ControlEventArgs) Handles flpRecherche.ControlRemoved, flpRecherche.ControlAdded
        If flpRecherche.Controls.Count = 0 Then
            btRechercher.Enabled = False
            btSauver.Enabled = False
        Else
            btRechercher.Enabled = True
            btSauver.Enabled = True
        End If
    End Sub

#End Region

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://sourceforge.net/projects/tvguide/")
    End Sub
End Class
