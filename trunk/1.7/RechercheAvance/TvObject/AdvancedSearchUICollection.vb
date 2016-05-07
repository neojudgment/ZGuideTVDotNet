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

Imports System.Collections

Namespace TVGuide
	''' <summary>
	''' Summary description for SearchCriteriaCollection.
	''' </summary>
	<Serializable> _
	Public Class AdvancedSearchUICollection
		Inherits CollectionBase
		Private mName As String

		Public Sub New()
			mName = ""
		End Sub

		#Region "Properties"

		Public Property Name() As String
			Get
				Return (mName)
			End Get
			Set
				mName = value
			End Set
		End Property

		#End Region

		Public Default Property Item(index As Integer) As IAdvancedSearchUI
			Get
				Return DirectCast(List(index), IAdvancedSearchUI)
			End Get
			Set
				List(index) = value
			End Set
		End Property

		Public Function Add(value As IAdvancedSearchUI) As Integer
			Dim retValue As Integer = 0
            Dim SyncedList As ArrayList = ArrayList.Synchronized(InnerList)

			If SyncedList.Contains(value) = False Then
				retValue = List.Add(value)
			End If

			Return (retValue)
		End Function

		Public Function IndexOf(value As IAdvancedSearchUI) As Integer
			Return (List.IndexOf(value))
		End Function

		Public Sub Insert(index As Integer, value As IAdvancedSearchUI)
			List.Insert(index, value)
		End Sub

		Public Sub Remove(value As IAdvancedSearchUI)
            Dim SyncedList As ArrayList = ArrayList.Synchronized(InnerList)

			If SyncedList.Contains(value) = True Then
				List.Remove(value)
			End If
		End Sub

		Public Function Contains(value As IAdvancedSearchUI) As Boolean
			' If value is not of type ISearchCriteria, this will return false.
			Return (List.Contains(value))
		End Function

		Public Sub CopyTo(array As IAdvancedSearchUI(), index As Integer)
			DirectCast(Me, ICollection).CopyTo(array, index)
		End Sub

        Public Function GetSearchCriteriaCollection() As SearchCriteriaCollection
            Dim scc As New SearchCriteriaCollection()
            Dim SyncedList As ArrayList = ArrayList.Synchronized(InnerList)

            SyncLock InnerList
                For Each i As IAdvancedSearchUI In SyncedList
                    scc.Add(i.GetSearchCriteria())
                Next
            End SyncLock

            Return (scc)
        End Function

		#Region "Internal Events"
		Protected Overrides Sub OnInsert(index As Integer, value As [Object])
			If Not (TypeOf value Is IAdvancedSearchUI) Then
				Throw New ArgumentException("OnInsert: value must be of type ISearchCriteria.", "value")
			End If
		End Sub

		Protected Overrides Sub OnRemove(index As Integer, value As [Object])
			If Not (TypeOf value Is IAdvancedSearchUI) Then
				Throw New ArgumentException("OnRemove: value must be of type ISearchCriteria.", "value")
			End If
		End Sub

		Protected Overrides Sub OnSet(index As Integer, oldValue As [Object], newValue As [Object])
			If Not (TypeOf newValue Is IAdvancedSearchUI) Then
				Throw New ArgumentException("OnSet: newValue must be of type ISearchCriteria.", "newValue")
			End If
		End Sub

		Protected Overrides Sub OnValidate(value As [Object])
			If Not (TypeOf value Is IAdvancedSearchUI) Then
				Throw New ArgumentException("OnValidate: value must be of type ISearchCriteria.")
			End If
		End Sub
		#End Region
	End Class
End Namespace
