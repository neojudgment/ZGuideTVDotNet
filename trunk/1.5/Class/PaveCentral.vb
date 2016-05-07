' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2013 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

' ReSharper disable CheckNamespace
Public Class PaveCentral
    ' ReSharper restore CheckNamespace
    Inherits UserControl

    Private _text As String = ""
    Private _mouseHover As Boolean
    Private _bgColor As Color = Color.White

#Region "Property"

    Public Property BgColor As Color
        Get
            Return _bgColor
        End Get
        Set(ByVal value As Color)
            _bgColor = value
        End Set
    End Property

    Private _marquage As Boolean

    Public Property Marquage As Boolean
        Get
            Return _marquage
        End Get
        Set(ByVal value As Boolean)
            _marquage = value
            Invalidate()
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    ' propriété pour savoir si on afficher dans l'ancien style ou le nouveau style
    Private _oldUi As Boolean = True

    Public Property OldUi() As Boolean
        Get
            Return _oldUi
        End Get
        Set(ByVal value As Boolean)
            _oldUi = value
        End Set
    End Property

    Private _brdersColor As Color = Color.White

    Public Property BordersColor() As Color
        Get
            Return _brdersColor
        End Get
        Set(ByVal value As Color)
            _brdersColor = value
        End Set
    End Property

    'Private _topColor As Color = Color.White

    'Public Property TopColor() As Color
    '    Get
    '        Return _topColor
    '    End Get
    '    Set(ByVal Value As Color)
    '        _topColor = Value
    '    End Set
    'End Property

    Private _align As StringAlignment = StringAlignment.Near

    Public Property Align() As StringAlignment
        Get
            Return _align
        End Get
        Set(ByVal value As StringAlignment)
            _align = value
        End Set
    End Property

#End Region

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        SetStyle( _
                     ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or _
                     ControlStyles.OptimizedDoubleBuffer, True)
        AutoSize = False
        AutoScaleMode = Windows.Forms.AutoScaleMode.None
    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        Dim r As New Rectangle(0, 0, Width, Height)
        Dim b2 As New LinearGradientBrush(r, ForeColor, ForeColor, 90)
        Dim gp As GraphicsPath = New GraphicsPath

        Try
            Dim drawingArea As Graphics = pevent.Graphics
            With drawingArea
                Dim hauteurstring As Integer = CInt(14 * .DpiX / 192)

                .Clear(_brdersColor)
                Dim r2 As New RectangleF(0, (Height \ 2) - hauteurstring, Width, hauteurstring * 2)

                Dim w As Integer = Width - 1
                Dim h As Integer = Height - 1

                If _oldUi Then
                    Dim b As New SolidBrush(_bgColor)
                    With gp
                        .AddLine(0, 0, w, 0)
                        .AddLine(w, 0, w, h)
                        .AddLine(w, h, 0, h)
                        .AddLine(0, h, 0, 0)
                    End With
                    .FillPath(b, gp)
                    If b IsNot Nothing Then
                        b.Dispose()
                    End If
                Else
                    .Clear(_brdersColor)
                    Dim b As New LinearGradientBrush(r, Color.White, _bgColor, 90)
                    Const radius As Integer = 4
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
                    .FillPath(b, gp)
                    If b IsNot Nothing Then
                        b.Dispose()
                    End If
                End If

                'remplissage des rectangles
                'coloriage des contours des rectangles
                'avec pseudo simulation "appui bouton"
                If _mouseHover AndAlso OldUi Then
                    .DrawPath(New Pen(Color.White), gp)
                Else
                    .DrawPath(New Pen(Color.DarkBlue), gp)
                End If


                'ecriture du nom de l'emission
                Dim f As New StringFormat
                f.Alignment = _align
                'si old_ui, emulation du comportement d'un bouton
                Dim fo As New Font(Font.FontFamily, 8.5)




                If OldUi Then
                    .DrawString("  " & _text, fo, b2, r2, f)
                Else
                    .DrawString(_text, fo, b2, r2, f)
                End If
                If _marquage Then
                    Dim imgBell As Image = My.Resources.bell
                    Dim rectBell As New Rectangle(3, 3, imgBell.Width, imgBell.Height)
                    .DrawImage(imgBell, rectBell)

                End If

            End With
        Catch ex As Exception
        Finally
            If b2 IsNot Nothing Then
                b2.Dispose()
            End If
            If gp IsNot Nothing Then
                gp.Dispose()
            End If
        End Try
    End Sub

    Private Sub PaveCentralMouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseEnter
        Try
            _mouseHover = True
            Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PaveCentralMouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseLeave
        Try
            _mouseHover = False
            Invalidate()
        Catch ex As Exception
        End Try
    End Sub
End Class

