' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2012 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
' |                                                                                                            |
' |    Project administrator : Pascal Hubert (neojudgment@hotmail.com)                                         |
' |                                                                                                            |
' |    This program is free software: you can redistribute it and/or modify                                    |
' |    it under the terms of the GNU General Public License as published by                                    |
' |    the Free Software Foundation, either version 2 of the License, or                                       |
' |    (at your option) any later version.                                                                     |
' |                                                                                                            |
' |    This program is distributed in the hope that it will be useful,                                         |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of                                          |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                                           |
' |    GNU General Public License for more details.                                                            |
' |                                                                                                            |
' |    You should have received a copy of the GNU General Public License                                       |
' |    along with this program.  If not, see <http://www.gnu.org/licenses/>.                                   |
' |                                                                                                            |
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
Public Class Custom_Scroll
    Inherits Panel
    Private Rect1 As New RectangleF(0, 0, 100, 100)
    Private Rect2 As New RectangleF(0, 100, 100, 100)
    Private Rect3 As New RectangleF(0, 200, 100, 100)
    Private Rect4 As New RectangleF(0, 300, 100, 100)
    Private Rect5 As New RectangleF(0, 400, 100, 100)

    Public Sub New()
        Me.Size = New Size(Width:=100, Height:=500)
        Application.DoEvents()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim Graphics As Graphics = Me.CreateGraphics
        With Graphics
            .FillRectangle(Brushes.Blue, Rect1)
            .FillRectangle(Brushes.Red, Rect2)
            .FillRectangle(Brushes.Yellow, Rect3)
            .FillRectangle(Brushes.Green, Rect4)
            .FillRectangle(Brushes.Orange, Rect5)
        End With

    End Sub

    Private Sub Custom_Scroll_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        Me.Parent.Text = CStr(Me.PointToClient(MousePosition).Y)

        Select Case Me.PointToClient(MousePosition).Y
            Case 100
                Me.Cursor = Cursors.HSplit
            Case 200
                Me.Cursor = Cursors.HSplit
            Case 300
                Me.Cursor = Cursors.HSplit
            Case 400
                Me.Cursor = Cursors.HSplit
            Case Else
                Me.Cursor = Cursors.Default
        End Select
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Select Case Me.PointToClient(MousePosition).Y
                Case Is < 100
                    Rect1.Size = New Size(CInt(Rect1.Width), Me.PointToClient(MousePosition).Y)
                    With Rect2
                        .Location = New Point(x:=CInt(.Location.X), y:=Me.PointToClient(MousePosition).Y)
                        .Size = New Size(Width:=CInt(.Width), Height:=CInt(Rect3.Y - .Y))
                    End With
                Case Is < 200
                    Rect2.Size = New Size(CInt(Rect2.Width), Me.PointToClient(MousePosition).Y)
                    With Rect3
                        .Location = New Point(x:=CInt(.Location.X), y:=Me.PointToClient(MousePosition).Y)
                    End With
                Case Is < 300
                    Rect3.Size = New Size(CInt(Rect3.Width), Me.PointToClient(MousePosition).Y)
                    With Rect4
                        .Location = New Point(x:=CInt(.Location.X), y:=Me.PointToClient(MousePosition).Y)
                    End With
                Case Is < 400
                    Rect4.Size = New Size(CInt(Rect4.Width), Me.PointToClient(MousePosition).Y)
                    With Rect5
                        .Location = New Point(x:=CInt(.Location.X), y:=Me.PointToClient(MousePosition).Y)
                    End With
                Case Is < 500
                    Rect5.Size = New Size(CInt(Rect5.Width), Me.PointToClient(MousePosition).Y)

            End Select
            Me.Refresh()
        End If
    End Sub
End Class
