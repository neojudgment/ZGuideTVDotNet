' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2014 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

' ReSharper disable CheckNamespace
Public Class Curseur
    ' ReSharper restore CheckNamespace

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        Dim backBuffer As New Bitmap(1, Height)
        Dim drawingArea As Graphics = Graphics.FromImage(backBuffer)
        Dim viewable As Graphics = CreateGraphics()
        Try
            drawingArea.DrawLine(New Pen(Color.Black), New Point(0, 0), New Point(0, Height))
            viewable.DrawImageUnscaled(backBuffer, 0, 0)
        Catch 'ex As Exception
        Finally
            If backBuffer IsNot Nothing Then
                backBuffer.Dispose()
            End If
            If drawingArea IsNot Nothing Then
                drawingArea.Dispose()
            End If
            If viewable IsNot Nothing Then
                viewable.Dispose()
            End If
        End Try
    End Sub
End Class
