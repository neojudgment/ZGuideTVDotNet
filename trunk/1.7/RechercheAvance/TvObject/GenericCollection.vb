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
    Public Class GenericCollection(Of T)
        Inherits CollectionBase
        Public Sub New()
        End Sub

        Default Public Property Item(index As Integer) As T
            Get
                Return DirectCast(List(index), T)
            End Get
            Set(value As T)
                List(index) = value
            End Set
        End Property

        Public Function Add(value As T) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(value As T) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(index As Integer, value As T)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(value As T)
            List.Remove(value)
        End Sub

        Public Function Contains(value As T) As Boolean
            ' If value is not of type T, this will return false.
            Return (List.Contains(value))
        End Function

        Public Function ToArray() As T()
            Dim x As Integer = 0
            Dim newArray As T() = New T(InnerList.Count - 1) {}

            For Each it As T In InnerList
                newArray(x) = it
                x += 1
            Next
            Return (newArray)
        End Function

#Region "Internal Events"
        '
        '        protected override void OnInsert(int index, Object value)
        '        {
        '            if (value.GetType() != Type.GetType(T))
        '                throw new ArgumentException(String.Format("value must be of type {0} CustomHighlight.",Type.GetType(T).ToString()), "value");
        '        }
        '
        '        protected override void OnRemove(int index, Object value)
        '        {
        '            if (value.GetType() != Type.GetType("TVGuide.CustomHighlight"))
        '                throw new ArgumentException("value must be of type CustomHighlight.", "value");
        '        }
        '
        '        protected override void OnSet(int index, Object oldValue, Object newValue)
        '        {
        '            if (newValue.GetType() != Type.GetType("TVGuide.CustomHighlight"))
        '                throw new ArgumentException("newValue must be of type CustomHighlight.", "newValue");
        '        }
        '
        '        protected override void OnValidate(Object value)
        '        {
        '            if (value.GetType() != Type.GetType("TVGuide.CustomHighlight"))
        '                throw new ArgumentException("value must be of type CustomHighlight.");
        '        }
        '        

#End Region

    End Class
End Namespace
