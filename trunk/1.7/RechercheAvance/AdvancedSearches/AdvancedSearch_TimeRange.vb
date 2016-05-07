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

Imports System.Windows.Forms
Imports System.Runtime.Serialization
Imports ZGuideTV.TVGuide

<Serializable()> _
Partial Public Class AdvancedSearch_TimeRange
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Private Enum Fields
        StartTime = 0
        StopTime = 1
    End Enum

    Private Enum Conditions
        'IsBetween = 0
        IsNotBetween = 1
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
        MinTimePicker.Value = CType(information.GetValue("MinTimePicker", GetType(DateTime)), DateTime)
        MaxTimePicker.Value = CType(information.GetValue("MaxTimePicker", GetType(DateTime)), DateTime)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSeachByTimeRange.Split("|"c)
        label1.Text = strlngcol(0)
        FieldsComboBox.Items.Clear()
        FieldsComboBox.Items.AddRange({strlngcol(1), strlngcol(2)})
        ConditionsComboBox.Items.Clear()
        ConditionsComboBox.Items.AddRange({strlngcol(3), strlngcol(4)})
        label2.Text = strlngcol(5)
    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim isc As ISearchCriteria = Nothing

        Select Case FieldsComboBox.SelectedIndex
            Case CInt(Fields.StartTime)
                isc = New SearchCriteria_TimeRange(SearchCriteria_TimeRange.Fields.StartTime, MinTimePicker.Value, MaxTimePicker.Value)


            Case CInt(Fields.StopTime)
                isc = New SearchCriteria_TimeRange(SearchCriteria_TimeRange.Fields.StopTime, MinTimePicker.Value, MaxTimePicker.Value)

        End Select

        If ConditionsComboBox.SelectedIndex = CInt(Conditions.IsNotBetween) Then
            Return (New SearchCriteriaDecorator_NegateMatching(isc))
        Else
            Return (isc)
        End If
    End Function

    Public Function ValidateCriteria() As Boolean Implements IAdvancedSearchUI.ValidateCriteria
        Return True ' (Validate_TimePickers())
    End Function

    Public Event OnRemoveControl As RemoveControl Implements IAdvancedSearchUI.OnRemoveControl

#End Region

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ISerializable Members"

    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("FieldsComboBoxSelectedIndex", FieldsComboBox.SelectedIndex)
        info.AddValue("ConditionsComboBoxSelectedIndex", ConditionsComboBox.SelectedIndex)
        info.AddValue("MinTimePicker", MinTimePicker.Value)
        info.AddValue("MaxTimePicker", MaxTimePicker.Value)
    End Sub

#End Region

    'Private Function Validate_TimePickers() As Boolean
    '    'If MaxTimePicker.Value < MinTimePicker.Value Then
    '    '    errorProvider1.SetError(MaxTimePicker, "This time must be later than the minimum time.")
    '    '    Return (False)
    '    'Else
    '    'errorProvider1.SetError(MaxTimePicker, "")
    '    'Return (True)
    '    'End If
    '    If (MaxTimePicker.Value - MinTimePicker.Value).Duration.Seconds > 86400 Then
    '        errorProvider1.SetError(MaxTimePicker, "This time must be later than the minimum time.")
    '        Return (False)
    '    Else
    '        errorProvider1.SetError(MaxTimePicker, "")
    '        Return (True)
    '    End If

    'End Function

    'Private Sub MinTimePicker_Validating(sender As Object, e As CancelEventArgs) Handles MinTimePicker.Validating
    '    Validate_TimePickers()
    'End Sub

    'Private Sub MaxTimePicker_Validating(sender As Object, e As CancelEventArgs) Handles MaxTimePicker.Validating
    '    Validate_TimePickers()
    'End Sub
End Class
