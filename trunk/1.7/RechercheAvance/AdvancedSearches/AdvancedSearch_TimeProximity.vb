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
Partial Public Class AdvancedSearch_TimeProximity
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Public Sub New()
        InitializeComponent()
        Traduire()
        numericUpDown1.Value = 1
        UnitsOfTimeComboBox.SelectedIndex = 0
    End Sub

    Public Sub New(information As SerializationInfo, context As StreamingContext)
        InitializeComponent()
        Traduire()
        numericUpDown1.Value = CInt(information.GetValue("numericUpDown1Value", GetType(Integer)))
        UnitsOfTimeComboBox.SelectedIndex = CInt(information.GetValue("UnitsOfTimeComboBoxSelectedIndex", GetType(Integer)))
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSeachByTimeProximity.Split("|"c)
        label1.Text = strlngcol(0)
        UnitsOfTimeComboBox.Items.Clear()
        UnitsOfTimeComboBox.Items.AddRange({strlngcol(1), strlngcol(2), strlngcol(3)})
    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim isc As ISearchCriteria = Nothing

        Select Case UnitsOfTimeComboBox.SelectedIndex
            'minutes
            Case 0
                isc = New SearchCriteria_TimeProximity(New TimeSpan(0, CInt(Math.Truncate(numericUpDown1.Value)), 0))
                'hours
            Case 1
                isc = New SearchCriteria_TimeProximity(New TimeSpan(CInt(Math.Truncate(numericUpDown1.Value)), 0, 0))
                'days
            Case 2
                isc = New SearchCriteria_TimeProximity(New TimeSpan(CInt(Math.Truncate(numericUpDown1.Value)), 0, 0, 0))
        End Select

        Return (isc)
    End Function

    Public Event OnRemoveControl As RemoveControl Implements IAdvancedSearchUI.OnRemoveControl

#End Region

#Region "ISerializable Members"

    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("numericUpDown1Value", numericUpDown1.Value)
        info.AddValue("UnitsOfTimeComboBoxSelectedIndex", UnitsOfTimeComboBox.SelectedIndex)
    End Sub

#End Region

#Region "IAdvancedSearchUI Members"

    Public Function ValidateCriteria() As Boolean Implements IAdvancedSearchUI.ValidateCriteria
        Return (True)
    End Function

#End Region
End Class
