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
Imports ZGuideTV.TVGuide

Public Class SuperTreeNode
    Inherits TreeNode
    Private _ScrollToThisTime As DateTime
    Private _Asuic As AdvancedSearchUICollection
    Private _SearchDefinition As SearchCriteriaCollection
    Private _NodeType As TVTreeViewEx.SearchNodeType

    Public Sub New()
        _ScrollToThisTime = New DateTime()
        _Asuic = Nothing
        _SearchDefinition = Nothing
        _NodeType = TVTreeViewEx.SearchNodeType.Unknown
    End Sub

    Public Property SearchDefinition() As SearchCriteriaCollection
        Get
            Return (_SearchDefinition)
        End Get
        Set(value As SearchCriteriaCollection)
            _SearchDefinition = value
        End Set
    End Property

    Public Property NodeType() As TVTreeViewEx.SearchNodeType
        Get
            Return (_NodeType)
        End Get
        Set(value As TVTreeViewEx.SearchNodeType)
            _NodeType = value
        End Set
    End Property

    Public Property ScrollToThisTime() As DateTime
        Get
            Return (_ScrollToThisTime)
        End Get
        Set(value As DateTime)
            _ScrollToThisTime = value
        End Set
    End Property

    Public Property Asuic() As AdvancedSearchUICollection
        Get
            Return (_Asuic)
        End Get
        Set(value As AdvancedSearchUICollection)
            _Asuic = value
        End Set
    End Property
End Class
