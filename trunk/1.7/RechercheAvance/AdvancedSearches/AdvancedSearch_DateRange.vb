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
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.Serialization
Imports ZGuideTV.TVGuide

<Serializable()> _
Partial Public Class AdvancedSearch_DateRange
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Private Enum Conditions
        IsBetween = 0
        'IsNotBetween = 1
    End Enum
    Private _lngValidatorError As String
    Public Sub New()
        InitializeComponent()
        Traduire()
        ConditionsComboBox.SelectedIndex = 0
        MinDateTimePicker.Value = DateTime.Now
        MaxDateTimePicker.Value = DateTime.Now.AddDays(1)
    End Sub

    Protected Sub New(information As SerializationInfo, context As StreamingContext)
        InitializeComponent()
        Traduire()
        ConditionsComboBox.SelectedIndex = CInt(information.GetValue("ConditionsComboBoxSelectedIndex", GetType(Integer)))
        MinDateTimePicker.Value = CType(information.GetValue("MinDateTimePicker", GetType(DateTime)), DateTime)
        MaxDateTimePicker.Value = CType(information.GetValue("MaxDateTimePicker", GetType(DateTime)), DateTime)
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSeachByDateRange.Split("|"c)
        label1.Text = strlngcol(0)
        ConditionsComboBox.Items.Clear()
        ConditionsComboBox.Items.AddRange({strlngcol(1), strlngcol(2)})
        label2.Text = strlngcol(3)
        _lngValidatorError = strlngcol(4)
    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim isc As ISearchCriteria = New SearchCriteria_DateRange(MinDateTimePicker.Value, MaxDateTimePicker.Value)

        If ConditionsComboBox.SelectedIndex = CInt(Conditions.IsBetween) Then
            Return (isc)
        Else
            Return (New SearchCriteriaDecorator_NegateMatching(isc))
        End If
    End Function

    Public Function ValidateCriteria() As Boolean Implements IAdvancedSearchUI.ValidateCriteria
        Return (Validate_DateTimePickers())
    End Function

    Public Event OnRemoveControl As RemoveControl Implements IAdvancedSearchUI.OnRemoveControl

#End Region

#Region "ISerializable Members"

    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("ConditionsComboBoxSelectedIndex", ConditionsComboBox.SelectedIndex)
        info.AddValue("MinDateTimePicker", MinDateTimePicker.Value)
        info.AddValue("MaxDateTimePicker", MaxDateTimePicker.Value)
    End Sub

#End Region

    Private Function Validate_DateTimePickers() As Boolean
        If MaxDateTimePicker.Value < MinDateTimePicker.Value Then
            errorProvider1.SetError(MaxDateTimePicker, _lngValidatorError)
            Return (False)
        Else
            errorProvider1.SetError(MaxDateTimePicker, "")
            Return (True)
        End If
    End Function

    Private Sub MinDateTimePicker_Validating(sender As Object, e As CancelEventArgs) Handles MinDateTimePicker.Validating
        Validate_DateTimePickers()
    End Sub

    Private Sub MaxDateTimePicker_Validating(sender As Object, e As CancelEventArgs) Handles MaxDateTimePicker.Validating
        Validate_DateTimePickers()
    End Sub
End Class
