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

Imports System.Windows.Forms
Imports System.Runtime.Serialization
Imports ZGuideTV.TVGuide

<Serializable()> _
Partial Public Class AdvancedSearch_Date
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Private Enum Fields
        StartTime = 0
        StopTime = 1
    End Enum

    Private Enum Conditions
        Equals = 0
        IsEarlierThan = 1
        IsLaterThan = 2
    End Enum

    Public Sub New()
        InitializeComponent()
        Traduire()
        FieldsComboBox.SelectedIndex = 0
        ConditionsComboBox.SelectedIndex = 0
    End Sub

    Protected Sub New(information As SerializationInfo, context As StreamingContext)
        InitializeComponent()
        Traduire()
        FieldsComboBox.SelectedIndex = CInt(information.GetValue("FieldsComboBoxSelectedIndex", GetType(Integer)))
        ConditionsComboBox.SelectedIndex = CInt(information.GetValue("ConditionsComboBoxSelectedIndex", GetType(Integer)))
        DateCriteriaDateTimePicker.Value = CType(information.GetValue("DateCriteriaDateTimePickerDate", GetType(DateTime)), DateTime)
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSeachByDateOrTime.Split("|"c)
        label1.Text = strlngcol(0)
        FieldsComboBox.Items.Clear()
        FieldsComboBox.Items.AddRange({strlngcol(1), strlngcol(2)})

        ConditionsComboBox.Items.Clear()
        ConditionsComboBox.Items.AddRange({strlngcol(3), strlngcol(4), strlngcol(5)})
    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim searchtime As DateTime
        Dim isc As ISearchCriteria '= Nothing
        Dim field As SearchCriteria_Date.DateFields = SearchCriteria_Date.DateFields.StartTime
        Dim condition As SearchCriteria_Date.DateConditions = SearchCriteria_Date.DateConditions.Equals

        searchtime = New DateTime(DateCriteriaDateTimePicker.Value.Year, DateCriteriaDateTimePicker.Value.Month, DateCriteriaDateTimePicker.Value.Day, 0, 0, 0)

        Select Case FieldsComboBox.SelectedIndex
            Case CInt(Fields.StartTime)
                field = SearchCriteria_Date.DateFields.StartTime
            Case CInt(Fields.StopTime)
                field = SearchCriteria_Date.DateFields.StopTime
        End Select

        Select Case ConditionsComboBox.SelectedIndex
            Case CInt(Conditions.Equals)
                condition = SearchCriteria_Date.DateConditions.Equals
            Case CInt(Conditions.IsEarlierThan)
                condition = SearchCriteria_Date.DateConditions.IsEarlierThan
            Case CInt(Conditions.IsLaterThan)
                condition = SearchCriteria_Date.DateConditions.IsLaterThan
        End Select

        isc = New SearchCriteria_Date(searchtime, field, condition)

        Return (isc)
    End Function

    Public Function ValidateCriteria() As Boolean Implements IAdvancedSearchUI.ValidateCriteria
        Return (True)
    End Function

    Public Event OnRemoveControl As RemoveControl Implements IAdvancedSearchUI.OnRemoveControl
#End Region

#Region "ISerializable Members"

    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("FieldsComboBoxSelectedIndex", FieldsComboBox.SelectedIndex)
        info.AddValue("ConditionsComboBoxSelectedIndex", ConditionsComboBox.SelectedIndex)
        info.AddValue("DateCriteriaDateTimePickerDate", DateCriteriaDateTimePicker.Value)
    End Sub

#End Region
End Class
