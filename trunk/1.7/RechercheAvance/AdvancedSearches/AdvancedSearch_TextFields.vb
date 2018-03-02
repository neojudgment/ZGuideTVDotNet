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
Imports System.Runtime.Serialization
Imports System.Windows.Forms
Imports ZGuideTV.TVGuide

<Serializable()> _
Partial Public Class AdvancedSearch_TextFields
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    Public Enum Fields
        Title = 0
        Subtitle = 1
        Description = 2
    End Enum

    Public Enum Conditions
        Contains = 0
        DoesNotContain = 1
        MatchesRegex = 2
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
        CriteriaTextBox.Text = DirectCast(information.GetValue("CriteriaTextBox", GetType(String)), String)
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

    Public Property CriteriaText() As String
        Get
            Return (CriteriaTextBox.Text)
        End Get
        Set(value As String)
            CriteriaTextBox.Text = value
        End Set
    End Property

#End Region

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSearchByTextField.Split("|"c)
        label1.Text = strlngcol(0)
        FieldsComboBox.Items.Clear()
        FieldsComboBox.Items.AddRange({strlngcol(1), strlngcol(2), strlngcol(3)})
        ConditionsComboBox.Items.Clear()
        ConditionsComboBox.Items.AddRange({strlngcol(4), strlngcol(5)})
    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim isc As ISearchCriteria = Nothing, isc_to_return As ISearchCriteria = Nothing
        Select Case FieldsComboBox.SelectedIndex
            Case Fields.Title
                isc = New SearchCriteria_Title(CriteriaTextBox.Text)
            Case Fields.Subtitle
                isc = New SearchCriteria_SubTitle(CriteriaTextBox.Text)
            Case Fields.Description
                isc = New SearchCriteria_Description(CriteriaTextBox.Text)
                'Case Fields.Credits
                '    isc = New SearchCriteria_Credits(CriteriaTextBox.Text)
        End Select

        Select Case ConditionsComboBox.SelectedIndex
            Case CInt(Conditions.Contains)
                isc_to_return = isc
            Case CInt(Conditions.DoesNotContain)
                isc_to_return = New SearchCriteriaDecorator_NegateMatching(isc)
        End Select

        Return (isc_to_return)
    End Function

    Public Function ValidateCriteria() As Boolean Implements IAdvancedSearchUI.ValidateCriteria
        Return (Validate_CriteriaTextBox())
    End Function

    Public Event OnRemoveControl As RemoveControl Implements IAdvancedSearchUI.OnRemoveControl

#End Region

#Region "ISerializable Members"

    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("FieldsComboBoxSelectedIndex", FieldsComboBox.SelectedIndex)
        info.AddValue("ConditionsComboBoxSelectedIndex", ConditionsComboBox.SelectedIndex)
        info.AddValue("CriteriaTextBox", CriteriaTextBox.Text)
    End Sub

#End Region

    Private Function Validate_CriteriaTextBox() As Boolean
        If CriteriaTextBox.Text = String.Empty OrElse CriteriaTextBox.Text = "" Then
            errorProvider1.SetError(CriteriaTextBox, "This cannot be left blank.")
            Return (False)
        Else
            errorProvider1.SetError(CriteriaTextBox, "")
            Return (True)
        End If
    End Function

    Private Sub CriteriaTextBox_Validating(sender As Object, e As CancelEventArgs) Handles CriteriaTextBox.Validating
        Validate_CriteriaTextBox()
    End Sub
End Class
