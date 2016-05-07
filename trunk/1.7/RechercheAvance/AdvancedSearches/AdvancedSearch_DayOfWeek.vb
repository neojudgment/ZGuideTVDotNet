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
Partial Public Class AdvancedSearch_DayOfWeek
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Public Enum Conditions
        Equals = 0
        DoesNotEqual = 1
    End Enum

    Public Sub New()
        InitializeComponent()
        Traduire()
        ConditionsComboBox.SelectedIndex = 0
        CriteriaComboBox.SelectedIndex = 0
    End Sub

    Protected Sub New(information As SerializationInfo, context As StreamingContext)
        InitializeComponent()
        Traduire()
        ConditionsComboBox.SelectedIndex = CInt(information.GetValue("ConditionsComboBoxSelectedIndex", GetType(Integer)))
        CriteriaComboBox.SelectedIndex = CInt(information.GetValue("CriteriaComboBoxSelectedIndex", GetType(Integer)))
    End Sub

#Region "Properties"

    Public Property Condition() As Conditions
        Get
            Return CType(ConditionsComboBox.SelectedIndex, Conditions)
        End Get
        Set(value As Conditions)
            ConditionsComboBox.SelectedIndex = CInt(value)
        End Set
    End Property

    Public Property Day() As DayOfWeek
        Get
            Return CType(CriteriaComboBox.SelectedIndex, DayOfWeek)
        End Get
        Set(value As DayOfWeek)
            CriteriaComboBox.SelectedIndex = CInt(value)
        End Set
    End Property

#End Region

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSearchByDayOfWeek.Split("|"c)
        label1.Text = strlngcol(0)
        ConditionsComboBox.Items.Clear()
        ConditionsComboBox.Items.AddRange({strlngcol(1), strlngcol(2)})
        CriteriaComboBox.Items.Clear()
        CriteriaComboBox.Items.AddRange({LngDescriptDimancheLabel, LngDescriptLundiLabel, LngDescriptMardiLabel, LngDescriptMercrediLabel, LngDescriptJeudiLabel, LngDescriptVendrediLabel, LngDescriptSamediLabel})

    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim dow As DayOfWeek = DayOfWeek.Sunday
        Dim isc As ISearchCriteria

        Select Case CriteriaComboBox.SelectedIndex
            Case 0
                dow = DayOfWeek.Sunday

            Case 1
                dow = DayOfWeek.Monday

            Case 2
                dow = DayOfWeek.Tuesday

            Case 3
                dow = DayOfWeek.Wednesday

            Case 4
                dow = DayOfWeek.Thursday

            Case 5
                dow = DayOfWeek.Friday

            Case 6
                dow = DayOfWeek.Saturday

        End Select

        isc = New SearchCriteria_DayOfWeek(dow)

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
        info.AddValue("CriteriaComboBoxSelectedIndex", CriteriaComboBox.SelectedIndex)
    End Sub

#End Region
End Class
