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
Imports System.Drawing.Drawing2D

' ReSharper disable CheckNamespace
Public Class PaveCentral
    ' ReSharper restore CheckNamespace
    Inherits UserControl

    Private _text As String = ""
    Private _mouseHover As Boolean
    Private _bgColor As Color = Color.White
    Private Const racineCarreDe2 As Double = 1.4143

#Region "Property"

    Public Property BgColor As Color
        Get
            Return _bgColor
        End Get
        Set(ByVal value As Color)
            _bgColor = value
            Invalidate()
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

    '' propriété pour savoir si on afficher dans l'ancien style ou le nouveau style
    'Private _oldUi As Boolean = True

    'Public Property OldUi() As Boolean
    '    Get
    '        Return _oldUi
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _oldUi = value
    '    End Set
    'End Property

    'Private _brdersColor As Color = Color.White

    'Public Property BordersColor() As Color
    '    Get
    '        Return _brdersColor
    '    End Get
    '    Set(ByVal value As Color)
    '        _brdersColor = value
    '    End Set
    'End Property

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
        AutoScaleMode = AutoScaleMode.None
    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        Dim b2 As New SolidBrush(ForeColor)
        Dim gp2 As New GraphicsPath

        Try
            Dim drawingArea As Graphics = pevent.Graphics
            With drawingArea
                Dim hauteurstring As Integer = CInt(14 * .DpiX / 192)

                Dim r2 As New RectangleF(0, (Height \ 2) - hauteurstring, Width, hauteurstring * 2)

                Dim w As Integer = Width - 1
                Dim h As Integer = Height - 1

                Dim rect As New Rectangle(0, 0, w, h)

                If _mouseHover Then
                    Const correctionFactorL As Single = 0.6F
                    Dim redL As Single = (255 - _bgColor.R) * correctionFactorL + _bgColor.R
                    Dim greenL As Single = (255 - _bgColor.G) * correctionFactorL + _bgColor.G
                    Dim blueL As Single = (255 - _bgColor.B) * correctionFactorL + _bgColor.B
                    Dim lighterColor As Color = Color.FromArgb(_bgColor.A, CInt(redL), CInt(greenL), CInt(blueL))
                    Dim r3 As Rectangle = rect
                    Dim infWidth As Integer = CInt(racineCarreDe2 * rect.Width - rect.Width)
                    Dim infHeight As Integer = CInt(racineCarreDe2 * rect.Height - rect.Height)

                    r3.Inflate(infWidth, infHeight)

                    gp2.AddEllipse(r3)
                    Dim b As New PathGradientBrush(gp2)
                    b.CenterPoint = PointToClient(MousePosition)
                    b.CenterColor = lighterColor
                    b.SurroundColors = New Color() {_bgColor}
                    gp2.Dispose()
                    .FillRectangle(b, rect)
                Else

                    Dim b As New SolidBrush(_bgColor)
                    .FillRectangle(b, rect)
                End If
                Const correctionFactor As Single = 0.7F
                Dim red As Single = _bgColor.R * correctionFactor
                Dim green As Single = _bgColor.G * correctionFactor
                Dim blue As Single = _bgColor.B * correctionFactor
                Dim darkercolr As Color = Color.FromArgb(_bgColor.A, CInt(red), CInt(green), CInt(blue))
                .DrawRectangle(New Pen(darkercolr), rect)

                'ecriture du nom de l'emission
                Dim f As New StringFormat
                f.Alignment = _align
                Dim fo As New Font(Font.FontFamily, 8.5)
                .DrawString(" " & _text, fo, b2, r2, f)
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
            If gp2 IsNot Nothing Then
                gp2.Dispose()
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
    Private Sub PavecentralMouseMove(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseMove
        Invalidate()
    End Sub
    Private Sub PaveCentralMouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseLeave
        Try
            _mouseHover = False
            Invalidate()
        Catch ex As Exception
        End Try
    End Sub
End Class

