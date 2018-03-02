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
' ReSharper disable CheckNamespace
Public Class TreeViewCategorie
    ' ReSharper restore CheckNamespace
    Inherits TreeView

    Public Sub New()
        DrawMode = TreeViewDrawMode.OwnerDrawAll
        'LabelEdit = True
    End Sub

    Protected Overrides Sub OnDrawNode(e As DrawTreeNodeEventArgs)
        MyBase.OnDrawNode(e)
        If TypeOf (e.Node) Is TreeNodeGroupeCategorie Then

            If e.State = (TreeNodeStates.Focused Or TreeNodeStates.Selected) Then
                e.Node.BackColor = Color.LightBlue
            Else
                e.Node.BackColor = BackColor
            End If
            e.Graphics.FillRectangle(New SolidBrush(e.Node.BackColor), New Rectangle(e.Bounds.Location, e.Bounds.Size))
            Dim tb As New SolidBrush(Color.FromArgb(DirectCast(e.Node, TreeNodeGroupeCategorie).Couleur))
            'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            'e.Graphics.FillEllipse(tb, e.Bounds.Location.X + 1, e.Bounds.Location.Y + 1, 14, 14)
            e.Graphics.FillRectangle(tb, New Rectangle(e.Bounds.Location.X + 1, e.Bounds.Location.Y + 1, 14, 14))
            Dim f As New Font(Font.FontFamily, Font.Size, FontStyle.Bold Or FontStyle.Underline)
            e.Graphics.DrawString(e.Node.Text, f, New SolidBrush(Color.Black), e.Bounds.Left + 17, e.Bounds.Top)
            f.Dispose()
        Else
            e.DrawDefault = True
            MyBase.OnDrawNode(e)
        End If


    End Sub


End Class

Public Class TreeNodeGroupeCategorie
    Inherits TreeNode
    Public Sub New()

    End Sub

    'Dim _Nom As String = ""
    'Public Property Nom As String
    '    Get
    '        Return _Nom
    '    End Get
    '    Set(value As String)
    '        _Nom = value
    '    End Set
    'End Property

    Public Property Couleur As Integer

    Public Property IdGroupe As Integer

    Public Property IdCouleur As Integer
End Class

Public Class TreeNodeCategorie
    Inherits TreeNode
    Public Property IdCategorie As Integer
End Class