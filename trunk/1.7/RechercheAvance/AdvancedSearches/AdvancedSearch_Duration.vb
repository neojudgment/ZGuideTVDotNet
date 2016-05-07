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
Partial Public Class AdvancedSearch_Duration
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Public Sub New()
        InitializeComponent()
        Traduire()
        ConditionsComboBox.SelectedIndex = 0
        numericUpDown1.Value = 1
        UnitsOfTimeComboBox.SelectedIndex = 0
        NumericUpDown2.Value = 1
        UnitsOfTimeComboBox2.SelectedIndex = 0
        InitVisible()
    End Sub
    Public Enum Conditions
        IsEquals = 0
        isUpper = 1
        isLower = 2
        isBetween = 3
    End Enum

    Public Sub New(information As SerializationInfo, context As StreamingContext)
        InitializeComponent()
        Traduire()
        ConditionsComboBox.SelectedIndex = CInt(information.GetValue("ConditionsComboBoxSelectedIndex", GetType(Integer)))
        numericUpDown1.Value = CInt(information.GetValue("numericUpDown1Value", GetType(Integer)))
        UnitsOfTimeComboBox.SelectedIndex = CInt(information.GetValue("UnitsOfTimeComboBoxSelectedIndex", GetType(Integer)))
        numericUpDown1.Value = CInt(information.GetValue("numericUpDown2Value", GetType(Integer)))
        UnitsOfTimeComboBox.SelectedIndex = CInt(information.GetValue("UnitsOfTimeComboBox2SelectedIndex", GetType(Integer)))
        InitVisible()
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub
#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSearchByDuration.Split("|"c)
        label1.Text = strlngcol(0)
        ConditionsComboBox.Items.Clear()
        ConditionsComboBox.Items.AddRange({strlngcol(1), strlngcol(2), strlngcol(3), strlngcol(4)})
        UnitsOfTimeComboBox.Items.Clear()
        UnitsOfTimeComboBox.Items.AddRange({strlngcol(5), strlngcol(6)})
        UnitsOfTimeComboBox2.Items.Clear()
        UnitsOfTimeComboBox2.Items.AddRange({strlngcol(5), strlngcol(6)})
        Label2.Text = strlngcol(7)
    End Sub
#End Region
#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim isc As ISearchCriteria = Nothing

        Select Case ConditionsComboBox.SelectedIndex
            Case CInt(Conditions.IsEquals)
                isc = New SearchCriteria_Duration(SearchCriteria_Duration.Conditions.IsEquals, EnMinute(0))
            Case (CInt(Conditions.isUpper))
                isc = New SearchCriteria_Duration(SearchCriteria_Duration.Conditions.isUpper, EnMinute(0))
            Case CInt(Conditions.isLower)
                isc = New SearchCriteria_Duration(SearchCriteria_Duration.Conditions.isLower, EnMinute(0))
            Case CInt(Conditions.isBetween)
                isc = New SearchCriteria_Duration(SearchCriteria_Duration.Conditions.isBetween, EnMinute(0), EnMinute(0))
        End Select

        Return (isc)
    End Function

    Public Event OnRemoveControl As RemoveControl Implements IAdvancedSearchUI.OnRemoveControl

#End Region

#Region "ISerializable Members"

    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("numericUpDown1Value", numericUpDown1.Value)
        info.AddValue("UnitsOfTimeComboBoxSelectedIndex", UnitsOfTimeComboBox.SelectedIndex)
        info.AddValue("numericUpDown1Value2", NumericUpDown2.Value)
        info.AddValue("UnitsOfTimeComboBoxSelectedIndex", UnitsOfTimeComboBox2.SelectedIndex)

    End Sub

#End Region

#Region "IAdvancedSearchUI Members"

    Public Function ValidateCriteria() As Boolean Implements IAdvancedSearchUI.ValidateCriteria
        Return Validate_Duree()
    End Function

#End Region

    Private Sub NumericUpDown2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NumericUpDown2.Validating
        Validate_Duree()
    End Sub
    Private Sub numericUpDown1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numericUpDown1.Validating
        Validate_Duree()
    End Sub

    Private Function Validate_Duree() As Boolean

        If ConditionsComboBox.SelectedIndex = 3 AndAlso EnMinute(0) > EnMinute(1) Then
            errorProvider1.SetError(UnitsOfTimeComboBox2, "le maximun de duréé doit-être supérieur au minimum")
            Return (False)
        Else
            errorProvider1.SetError(UnitsOfTimeComboBox2, "")
            Return (True)
        End If
    End Function

    Private Function EnMinute(borne As Integer) As Integer
        Dim duree As Decimal = 0
        Dim multiplieur As Integer = 0

        Select Case borne
            Case 0
                If UnitsOfTimeComboBox.SelectedIndex = 0 Then
                    multiplieur = 1
                Else
                    multiplieur = 60
                End If
                duree = numericUpDown1.Value
            Case 1
                If UnitsOfTimeComboBox2.SelectedIndex = 0 Then
                    multiplieur = 1
                Else
                    multiplieur = 60
                End If
                duree = NumericUpDown2.Value
            Case Else
                Throw New Exception("Valeur non valide")
        End Select
        Return CInt(duree * multiplieur)
    End Function

    Private Sub ConditionsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConditionsComboBox.SelectedIndexChanged
        InitVisible()
    End Sub
    Private Sub InitVisible()
        If ConditionsComboBox.SelectedIndex = 3 Then
            Label2.Visible = True
            NumericUpDown2.Visible = True
            UnitsOfTimeComboBox2.Visible = True
        Else
            Label2.Visible = False
            NumericUpDown2.Visible = False
            UnitsOfTimeComboBox2.Visible = False
        End If

    End Sub
End Class
