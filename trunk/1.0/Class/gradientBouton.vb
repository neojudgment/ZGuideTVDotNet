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
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class GradientButton
    Private _mouseHover As Boolean
    Private _mouseState As Int32

    Private _text As String = ""

#Region "Property"

    <Browsable(True)> _
    Public Overrides Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Private _hoverColor As Color = Color.DarkBlue

    Public Property HoverColor() As Color
        Get
            Return _hoverColor
        End Get
        Set(ByVal Value As Color)
            _hoverColor = Value
            'Call Redraw()
        End Set
    End Property

    ' Par defaut, l'alignement est centré car les pavés du calendrier sont adressés comme des Control ey n'ont pas accés à la propriété Align
    Private _Align As StringAlignment = StringAlignment.Center

    Public Property Align() As StringAlignment
        Get
            Return _Align
        End Get
        Set(ByVal Value As StringAlignment)
            _Align = Value
            'Call Redraw()
        End Set
    End Property

    Private _brdersColor As Color = Color.White

    Public Property BordersColor() As Color
        Get
            Return _brdersColor
        End Get
        Set(ByVal Value As Color)
            _brdersColor = Value
            'Call Redraw()
        End Set
    End Property

    Private _topColor As Color = Color.White

    Public Property TopColor() As Color
        Get
            Return _topColor
        End Get
        Set(ByVal Value As Color)
            _topColor = Value
            'Call Redraw()
        End Set
    End Property

    Private _bottomColor As Color = Color.CornflowerBlue

    Public Property BottomColor() As Color
        Get
            Return _bottomColor
        End Get
        Set(ByVal Value As Color)
            _bottomColor = Value
            'Call Redraw()
        End Set
    End Property

#End Region

    Private Sub Redraw()
        Try
            Dim backBuffer As New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
            Dim drawingArea As Graphics = Graphics.FromImage(backBuffer)


            With drawingArea
                .Clear(_brdersColor)
                Dim r As New Rectangle(0, 0, Width, Height)
                Dim r2 As New RectangleF(0, (Height \ 2) - 7, Width, 14)
                Dim b As LinearGradientBrush = Nothing
                If _mouseHover Then
                    If _mouseState = 0 Then
                        b = New LinearGradientBrush(r, _topColor, HoverColor, 90)
                    ElseIf _mouseState = 1 Then
                        b = New LinearGradientBrush(r, HoverColor, _topColor, 90)
                    End If
                Else
                    If _mouseState = 0 Then
                        b = New LinearGradientBrush(r, _topColor, HoverColor, 90)
                    ElseIf _mouseState = 1 Then
                        b = New LinearGradientBrush(r, HoverColor, _topColor, 90)
                    End If
                End If
                Dim b2 As New LinearGradientBrush(r, ForeColor, ForeColor, 90)
                Dim radius As Integer = 4
                Dim w As Integer = Width - 1
                Dim h As Integer = Height - 1
                Dim gp As GraphicsPath = New GraphicsPath

                With gp
                    .AddLine(0 + radius, 0, 0 + w - (radius * 2), 0)
                    .AddArc(0 + w - (radius * 2), 0, radius * 2, radius * 2, 270, 90)
                    .AddLine(0 + w, 0 + radius, 0 + w, 0 + h - (radius * 2))
                    .AddArc(0 + w - (radius * 2), 0 + h - (radius * 2), radius * 2, radius * 2, 0, 90)
                    .AddLine(0 + w - (radius * 2), 0 + h, 0 + radius, 0 + h)
                    .AddArc(0, 0 + h - (radius * 2), radius * 2, radius * 2, 90, 90)
                    .AddLine(0, 0 + h - (radius * 2), 0, 0 + radius)
                    .AddArc(0, 0, radius * 2, radius * 2, 180, 90)
                    .CloseFigure()
                End With

                .FillPath(b, gp)
                .DrawPath(New Pen(Color.DarkBlue), gp)

                Dim f As New StringFormat
                f.Alignment = _Align
                .DrawString(_text, Font, b2, r2, f)

            End With

            Dim Viewable As Graphics = Me.CreateGraphics
            Viewable.DrawImageUnscaled(backBuffer, 0, 0)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub GradientButton_LocationChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.LocationChanged
        Call Redraw()
    End Sub

    Private Sub GradientButton_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        Try
            _mouseState = 1
            Call Redraw()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GradientButton_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseEnter
        Try
            _mouseHover = True
            Call Redraw()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GradientButton_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseLeave
        Try
            _mouseHover = False
            Call Redraw()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GradientButton_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        Try
            _mouseState = 0
            Call Redraw()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GradientButton_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        Call Redraw()
    End Sub

    Private Sub GradientButton_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Call Redraw()
    End Sub
End Class

