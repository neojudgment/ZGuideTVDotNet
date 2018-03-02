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
Partial Public Class AdvancedSearch_Channel
    Inherits UserControl
    Implements IAdvancedSearchUI
    Implements ISerializable
    Implements ITranslatable
    ''' <summary>
    ''' Objet gérant les propriétés Text et Value pour les items d'une ComboBox
    ''' </summary>
    ''' <remarks>Classe intermédiaire pour les combobox</remarks>
    Private Class ComboBoxItem
        Private ReadOnly _Text As String

        Public Sub New(ByVal Text As String, ByVal Value As String)
            _Text = Text
            Me.Value = Value
        End Sub
        Public Overrides Function ToString() As String
            Return _Text
        End Function
        Public Property Value As String
    End Class




    Private Enum Conditions
        Equals = 0
        'DoesNotEqual = 1
    End Enum

    Private ReadOnly mChannels As Dictionary(Of String, ProgrammeOrganizer.InfoChaine)

    Public Sub New()
        InitializeComponent()
        Traduire()
    End Sub

    'Protected Sub New(information As SerializationInfo, context As StreamingContext)
    '    InitializeComponent()

    '    ConditionsComboBox.SelectedIndex = CInt(information.GetValue("ConditionsComboBoxSelectedIndex", GetType(Integer)))
    '    'mChannels = DirectCast(information.GetValue("Channels", GetType(TVChannel())), TVChannel())
    '    For Each chan As TVChannel In mChannels
    '        ChannelComboBox.Items.Add(chan)
    '    Next

    '    ChannelComboBox.SelectedIndex = CInt(information.GetValue("ChannelsComboBoxSelectedIndex", GetType(Integer)))
    'End Sub
    Public Sub New(channels As Dictionary(Of String, ProgrammeOrganizer.InfoChaine))
        InitializeComponent()
        Traduire()
        mChannels = channels

        For Each chan As KeyValuePair(Of String, ProgrammeOrganizer.InfoChaine) In channels
            ChannelComboBox.Items.Add(New ComboBoxItem(chan.Value.Nom, chan.Key))
        Next
        ConditionsComboBox.SelectedIndex = 0

        If channels.Count > 0 Then
            ChannelComboBox.SelectedIndex = 0
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        RaiseEvent OnRemoveControl(Me)
    End Sub

#Region "ITranslatable"
    Private Sub Traduire() Implements ITranslatable.Traduire
        Dim strlngcol As String() = LngSearchByChannel.Split("|"c)
        label1.Text = strlngcol(0)
        ConditionsComboBox.Items.Clear()
        ConditionsComboBox.Items.AddRange({strlngcol(1), strlngcol(2)})
    End Sub
#End Region

#Region "IAdvancedSearchUI Members"

    Public Function GetSearchCriteria() As ISearchCriteria Implements IAdvancedSearchUI.GetSearchCriteria
        Dim isc As ISearchCriteria = New SearchCriteria_Channel(DirectCast(ChannelComboBox.SelectedItem, ComboBoxItem).Value)
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
        info.AddValue("Channels", mChannels)
        info.AddValue("ChannelsComboBoxSelectedIndex", ChannelComboBox.SelectedIndex)
    End Sub

#End Region
End Class
