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
Imports System.Windows.Forms
Imports System.Runtime.Serialization
Imports ZGuideTV.TVGuide

<Serializable()> _
Partial Public Class AdvancedSearch_Category
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Private Enum Conditions
        Equals = 0
        'DoesNotEqual = 1
    End Enum

    Private ReadOnly mCategories As ArrayList

    Public Sub New()
        InitializeComponent()
        Traduire()
    End Sub

    Protected Sub New(information As SerializationInfo, context As StreamingContext)
        InitializeComponent()
        Traduire()
        ConditionsComboBox.SelectedIndex = CInt(information.GetValue("ConditionsComboBoxSelectedIndex", GetType(Integer)))
        mCategories = DirectCast(information.GetValue("Categories", GetType(ArrayList)), ArrayList)
        For Each category As String In mCategories
            CategoriesComboBox.Items.Add(category)
        Next

        CategoriesComboBox.SelectedIndex = CInt(information.GetValue("CategoriesComboBoxSelectedIndex", GetType(Integer)))
    End Sub

    Public Sub New(categories As ArrayList)
        InitializeComponent()
        Traduire()
        mCategories = categories
        For Each category As String In categories
            CategoriesComboBox.Items.Add(category)
        Next

        ConditionsComboBox.SelectedIndex = 0

        If categories.Count > 0 Then
            CategoriesComboBox.SelectedIndex = 0
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSearchByCategories.Split("|"c)
        label1.Text = strlngcol(0)
        ConditionsComboBox.Items.Clear()
        ConditionsComboBox.Items.AddRange({strlngcol(1), strlngcol(2)})
    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim isc As ISearchCriteria = New SearchCriteria_Category(CategoriesComboBox.SelectedItem.ToString())

        If ConditionsComboBox.SelectedIndex = CInt(Conditions.Equals) Then
            Return (isc)
        Else
            Return (New SearchCriteriaDecorator_NegateMatching(isc))
        End If
    End Function

    Public Function ValidateCriteria() As Boolean Implements IAdvancedSearchUI.ValidateCriteria
        Return (True)
    End Function

    Public Event OnRemoveControl As RemoveControl Implements IAdvancedSearchUI.OnRemoveControl

#End Region

#Region "ISerializable Members"

    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("ConditionsComboBoxSelectedIndex", ConditionsComboBox.SelectedIndex)
        info.AddValue("Categories", mCategories)
        info.AddValue("CategoriesComboBoxSelectedIndex", CategoriesComboBox.SelectedIndex)
    End Sub

#End Region
End Class
