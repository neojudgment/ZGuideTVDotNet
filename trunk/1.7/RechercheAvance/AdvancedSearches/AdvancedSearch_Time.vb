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
Partial Public Class AdvancedSearch_Time
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Public Enum Fields
        StartTime = 0
        StopTime = 1
    End Enum

    Public Enum Conditions
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
        TimeCriteriaDateTimePicker.Value = CType(information.GetValue("TimeCriteriaDateTimePickerDate", GetType(DateTime)), DateTime)
    End Sub

#Region "Properties"

    Public Property Field() As Fields
        Get
            Return CType(FieldsComboBox.SelectedIndex, Fields)
        End Get
        Set(value As Fields)
            FieldsComboBox.SelectedIndex = CInt(value)
        End Set
    End Property

    Public Property Condition() As Conditions
        Get
            Return CType(ConditionsComboBox.SelectedIndex, Conditions)
        End Get
        Set(value As Conditions)
            ConditionsComboBox.SelectedIndex = CInt(value)
        End Set
    End Property

    Public Property Time() As DateTime
        Get
            Return (New DateTime(0, 0, 0, TimeCriteriaDateTimePicker.Value.Hour, TimeCriteriaDateTimePicker.Value.Minute, TimeCriteriaDateTimePicker.Value.Second))
        End Get
        Set(value As DateTime)
            TimeCriteriaDateTimePicker.Value = value
        End Set
    End Property

#End Region

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
        Dim tfield As SearchCriteria_Time.TimeFields = SearchCriteria_Time.TimeFields.StartTime
        Dim tcondition As SearchCriteria_Time.TimeConditions = SearchCriteria_Time.TimeConditions.Equals

        searchtime = TimeCriteriaDateTimePicker.Value

        Select Case FieldsComboBox.SelectedIndex
            Case CInt(Fields.StartTime)
                tfield = SearchCriteria_Time.TimeFields.StartTime
            Case CInt(Fields.StopTime)
                tfield = SearchCriteria_Time.TimeFields.StopTime
        End Select

        Select Case ConditionsComboBox.SelectedIndex
            Case CInt(Conditions.Equals)
                tcondition = SearchCriteria_Time.TimeConditions.Equals
            Case CInt(Conditions.IsEarlierThan)
                tcondition = SearchCriteria_Time.TimeConditions.IsEarlierThan
            Case CInt(Conditions.IsLaterThan)
                tcondition = SearchCriteria_Time.TimeConditions.IsLaterThan
        End Select

        isc = New SearchCriteria_Time(searchtime, tfield, tcondition)

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
        info.AddValue("TimeCriteriaDateTimePickerDate", TimeCriteriaDateTimePicker.Value)
    End Sub

#End Region
End Class
