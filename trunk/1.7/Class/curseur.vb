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
