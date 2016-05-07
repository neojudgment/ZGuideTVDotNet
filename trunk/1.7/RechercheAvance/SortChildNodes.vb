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
' |    GNU General Public License for more details.                                                            |
' |                                                                                                            |
' |    You should have received a copy of the MS-RL License                                                    |
' |    along with this program.  If not, see <https://opensource.org/licenses/MS-RL>.                          |
' |                                                                                                            |
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•

Imports System.Collections

Public Class SortChildNodes
    Implements IComparer
    Private ReadOnly _NodesToSort As SuperTreeNode()

    Public Sub New(Parents As SuperTreeNode())
        _NodesToSort = Parents
    End Sub

#Region "IComparer Members"

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim tx As SuperTreeNode = TryCast(x, SuperTreeNode)
        Dim ty As SuperTreeNode = TryCast(y, SuperTreeNode)

        If tx IsNot Nothing AndAlso ty IsNot Nothing Then
            For Each root As SuperTreeNode In _NodesToSort
                If tx.Parent Is root AndAlso ty.Parent Is root Then
                    If tx.NodeType = TVTreeViewEx.SearchNodeType.SpecificDates AndAlso ty.NodeType = TVTreeViewEx.SearchNodeType.SpecificDates Then
                        Return (DateTime.Compare(tx.ScrollToThisTime, ty.ScrollToThisTime))
                    Else
                        Return (String.Compare(tx.Text, ty.Text))
                    End If
                End If
            Next
        End If

        Return (0)
    End Function

#End Region
End Class
