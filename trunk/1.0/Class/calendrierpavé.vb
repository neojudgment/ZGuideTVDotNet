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
Imports System.Drawing.Drawing2D

Public Class calendrierpavé
    Inherits UserControl

#Region "Property"
    Private _bgColor As Color = Color.Black

    Public Property BGColor As Color
        Get
            Return _bgColor
        End Get
        Set(ByVal value As Color)
            _bgColor = value
        End Set
    End Property

    Private _text As String = ""
    'String.Empty

    Public Overrides Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
            'Call Redraw()
        End Set
    End Property

    ' propriété pour savoir si on afficher dans l'ancien style ou le nouveau style
    Private _oldUI As Boolean = True

    Public Property old_UI() As Boolean
        Get
            Return _oldUI
        End Get
        Set(ByVal value As Boolean)
            _oldUI = value
        End Set
    End Property

    Private _brdersColor As Color = Color.White

    Public Property BordersColor() As Color
        Get
            Return _brdersColor
        End Get
        Set(ByVal Value As Color)
            _brdersColor = Value
        End Set
    End Property

    Private _topColor As Color = Color.White

    Public Property TopColor() As Color
        Get
            Return _topColor
        End Get
        Set(ByVal Value As Color)
            _topColor = Value
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
#End Region

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me.SetStyle( _
                     ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or _
                     ControlStyles.OptimizedDoubleBuffer, True)

    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        Try

            Dim drawingArea As Graphics = pevent.Graphics

            With drawingArea
                .Clear(_brdersColor)
                Dim r As New Rectangle(0, 0, Width, Height)
                Dim r2 As New RectangleF(0, (Height \ 2) - 7, Width, 14)
                Dim b As LinearGradientBrush = Nothing
                Dim w As Integer = Width - 1
                Dim h As Integer = Height - 1
                Dim gp As GraphicsPath = New GraphicsPath

                If _oldUI Then
                    b = New LinearGradientBrush(r, _bgColor, _bgColor, 90)
                    With gp
                        .AddLine(0, 0, w, 0)
                        .AddLine(w, 0, w, h)
                        .AddLine(w, h, 0, h)
                        .AddLine(0, h, 0, 0)
                    End With
                Else

                    .Clear(_brdersColor)
                    b = New LinearGradientBrush(r, _bgColor, _topColor, 90)
                    Dim radius As Integer = 4

                    With gp
                        .AddLine(0 + radius, 0, 0 + w - (radius * 2), 0)
                        .AddArc(0 + w - (radius * 2), 0, radius * 2, radius * 2, 270, 90)
                        .AddLine(0 + w, 0 + radius, 0 + w, 0 + h - (radius * 2))
                        .AddArc(0 + w - (radius * 2), 0 + h - (radius * 2), radius * 2, radius * 2, 0, 90)
                        .AddLine(0 + w - (radius * 2), 0 + h, 0 + radius, 0 + h)
                        .AddArc(0, 0 + h - (radius * 2), radius * 2, radius * 2, 90, 90)
                        .AddLine(0, 0 + h - (radius * 2), 0, 0 + radius)
                        .AddArc(0, 0, radius * 2, radius * 2, 180, 90)
                    End With
                End If

                gp.CloseFigure()
                .FillPath(b, gp)
                .DrawPath(New Pen(Color.DarkBlue), gp)
                Dim f As New StringFormat
                f.Alignment = _Align
                If old_UI Then
                    .DrawString(_text, Font, Brushes.White, r2, f)
                Else
                    .DrawString(_text, Font, Brushes.Black, r2, f)
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
End Class
