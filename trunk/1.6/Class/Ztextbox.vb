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

' ReSharper disable once CheckNamespace
Public Class Ztextbox
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        SetStyle( _
             ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or _
             ControlStyles.OptimizedDoubleBuffer, True)
        AutoSize = False
        AutoScaleMode = Windows.Forms.AutoScaleMode.None
    End Sub
    Private _text As String = String.Empty
    Public Overrides Property Text As String
        Set(value As String)
            _text = value
            Refresh()
        End Set
        Get
            Return _text
        End Get
    End Property

    Protected Overrides Sub OnPaint(e As Windows.Forms.PaintEventArgs)
        Try
            Dim drawingArea As Graphics = e.Graphics
            With drawingArea
                .DrawLine(New Pen(Color.Black), New Point(0, CInt(Height / 1.5)), New Point(0, Height - 1))
                .DrawLine(New Pen(Color.Black), New Point(0, Height - 1), New Point(Width, Height - 1))
                Dim f As New StringFormat
                Dim r As New Rectangle(0, 0, Width, Height)
                f.Alignment = StringAlignment.Near
                f.LineAlignment = StringAlignment.Far
                Dim fo As New Font(Font.FontFamily, 8.5)
                .DrawString(" " & _text, fo, Brushes.Black, r, f)
                f.Dispose()
                fo.Dispose()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)

        MyBase.OnResize(e)
        Refresh()
    End Sub
End Class
