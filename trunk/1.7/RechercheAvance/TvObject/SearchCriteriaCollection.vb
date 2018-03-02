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

Namespace TVGuide
    ''' <summary>
    ''' Summary description for SearchCriteriaCollection.
    ''' </summary>
    <Serializable> _
    Public Class SearchCriteriaCollection
        Inherits CollectionBase

        Public Sub New()
        End Sub

        Public Function Add(value As ISearchCriteria) As Integer
            Dim retValue As Integer = 0
            Dim SyncedList As ArrayList = ArrayList.Synchronized(InnerList)

            If SyncedList.Contains(value) = False Then
                retValue = List.Add(value)
            End If

            Return (retValue)
        End Function

#Region "Internal Events"
        Protected Overrides Sub OnInsert(index As Integer, value As [Object])
            If Not (TypeOf value Is ISearchCriteria) Then
                Throw New ArgumentException("OnInsert: value must be of type ISearchCriteria.", "value")
            End If
        End Sub

        Protected Overrides Sub OnRemove(index As Integer, value As [Object])
            If Not (TypeOf value Is ISearchCriteria) Then
                Throw New ArgumentException("OnRemove: value must be of type ISearchCriteria.", "value")
            End If
        End Sub

        Protected Overrides Sub OnSet(index As Integer, oldValue As [Object], newValue As [Object])
            If Not (TypeOf newValue Is ISearchCriteria) Then
                Throw New ArgumentException("OnSet: newValue must be of type ISearchCriteria.", "newValue")
            End If
        End Sub

        Protected Overrides Sub OnValidate(value As [Object])
            If Not (TypeOf value Is ISearchCriteria) Then
                Throw New ArgumentException("OnValidate: value must be of type ISearchCriteria.")
            End If
        End Sub
#End Region
    End Class
End Namespace
