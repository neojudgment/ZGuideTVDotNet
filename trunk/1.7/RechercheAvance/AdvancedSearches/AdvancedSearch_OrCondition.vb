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

Imports System.Linq
Imports System.Windows.Forms
Imports System.Runtime.Serialization
Imports ZGuideTV.TVGuide

<Serializable()> _
Partial Public Class AdvancedSearch_OrCondition
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Public Sub New()
        InitializeComponent()
        Traduire()
        SearchCriteriaComboBox.SelectedIndex = 0
    End Sub

    Public Sub New(information As SerializationInfo, context As StreamingContext)
        InitializeComponent()
        Traduire()
        SearchCriteriaComboBox.SelectedIndex = 0

        Dim x As Integer '= 0
        For x = 0 To information.MemberCount - 1
            Dim iasui As IAdvancedSearchUI = DirectCast(information.GetValue(x.ToString(), GetType(IAdvancedSearchUI)), IAdvancedSearchUI)
            AddHandler iasui.OnRemoveControl, New RemoveControl(AddressOf OrConditions_OnRemoveControl)
            flowLayoutPanel1.Controls.Add(TryCast(iasui, UserControl))
        Next
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSearchOrCondition.Split("|"c)
        groupBox1.Text = strlngcol(0)
        InsertCriteriaButton.Text = strlngcol(1)
        SearchCriteriaComboBox.Items.Clear()
        SearchCriteriaComboBox.Items.Add(strlngcol(2))
        SearchCriteriaComboBox.Items.Add(strlngcol(3))
        SearchCriteriaComboBox.Items.Add(strlngcol(4))
        SearchCriteriaComboBox.Items.Add(strlngcol(5))
        SearchCriteriaComboBox.Items.Add(strlngcol(6))
        SearchCriteriaComboBox.Items.Add(strlngcol(7))
        SearchCriteriaComboBox.Items.Add(strlngcol(8))
        SearchCriteriaComboBox.Items.Add(strlngcol(9))
        SearchCriteriaComboBox.Items.Add(strlngcol(10))
        SearchCriteriaComboBox.Items.Add(strlngcol(11))
        SearchCriteriaComboBox.Items.Add(strlngcol(12))
        SearchCriteriaComboBox.Items.Add(strlngcol(13))
    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim x As Integer = 0
        Dim conditions As ISearchCriteria() = New ISearchCriteria(flowLayoutPanel1.Controls.Count - 1) {}
        For Each uc As UserControl In flowLayoutPanel1.Controls
            Dim iasui As IAdvancedSearchUI = TryCast(uc, IAdvancedSearchUI)
            conditions(x) = iasui.GetSearchCriteria()
            x += 1
        Next

        Dim isc As ISearchCriteria = New SearchCriteria_OrCondition(conditions)
        Return (isc)
    End Function

    Public Event OnRemoveControl As RemoveControl Implements IAdvancedSearchUI.OnRemoveControl

#End Region

#Region "ISerializable Members"

    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        Dim x As Integer = 0
        For Each uc As UserControl In flowLayoutPanel1.Controls
            Dim iasui As IAdvancedSearchUI = TryCast(uc, IAdvancedSearchUI)
            info.AddValue(x.ToString(), iasui)
            x += 1
        Next
    End Sub

#End Region

    Private Sub SearchCriteriaComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles SearchCriteriaComboBox.SelectionChangeCommitted, InsertCriteriaButton.Click
        Dim uc As UserControl '= Nothing
        Dim i_uc As IAdvancedSearchUI '= Nothing

        Dim sc As SearchCriteria = CType([Enum].ToObject(GetType(SearchCriteria), CInt(SearchCriteriaComboBox.SelectedIndex)), SearchCriteria)
        uc = AdvancedSearchFactory.CreateAdvancedSearchUc(sc)
        i_uc = DirectCast(uc, IAdvancedSearchUI)
        AddHandler i_uc.OnRemoveControl, New RemoveControl(AddressOf OrConditions_OnRemoveControl)

        flowLayoutPanel1.Controls.Add(uc)
    End Sub

    Private Sub OrConditions_OnRemoveControl(sender As Object)
        flowLayoutPanel1.Controls.Remove(TryCast(sender, Control))
    End Sub

#Region "IAdvancedSearchUI Members"

    Public Function ValidateCriteria() As Boolean Implements IAdvancedSearchUI.ValidateCriteria
        If flowLayoutPanel1.Controls.Count > 0 Then
            Return flowLayoutPanel1.Controls.Cast(Of IAdvancedSearchUI)().All(Function(iasui) iasui.ValidateCriteria() <> False)
            'For Each uc As UserControl In flowLayoutPanel1.Controls
            '    Dim iasui As IAdvancedSearchUI = DirectCast(uc, IAdvancedSearchUI)
            '    If iasui.ValidateCriteria() = False Then
            '        Return (False)
            '    End If
            'Next
        Else
            Return (False)
        End If
    End Function

#End Region

End Class
