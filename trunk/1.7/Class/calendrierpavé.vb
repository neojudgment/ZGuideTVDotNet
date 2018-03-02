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
Imports System.Drawing.Drawing2D

' ReSharper disable CheckNamespace
Public Class Calendrierpavé
    ' ReSharper restore CheckNamespace
    Inherits UserControl

#Region "Property"
    Private _bgColor As Color = Color.Black

    Public Property BgColor As Color
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

    Private _brdersColor As Color = Color.White

    Public Property BordersColor() As Color
        Get
            Return _brdersColor
        End Get
        Set(ByVal value As Color)
            _brdersColor = value
        End Set
    End Property

    Private _topColor As Color = Color.White

    Public Property TopColor() As Color
        Get
            Return _topColor
        End Get
        Set(ByVal value As Color)
            _topColor = value
        End Set
    End Property

    ' Par defaut, l'alignement est centré car les pavés du calendrier sont adressés comme des Control ey n'ont pas accés à la propriété Align
    Private _align As StringAlignment = StringAlignment.Center

    Public Property Align() As StringAlignment
        Get
            Return _align
        End Get
        Set(ByVal value As StringAlignment)
            _align = value
            'Call Redraw()
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
        Dim gp As GraphicsPath = New GraphicsPath
        Dim b As SolidBrush ' LinearGradientBrush
        Try

            Dim drawingArea As Graphics = pevent.Graphics

            With drawingArea
                .Clear(_brdersColor)
                'Dim r As New Rectangle(0, 0, Width, Height)
                Dim r2 As New RectangleF(0, (Height \ 2) - 7, Width, 14)
                Dim w As Integer = Width - 1
                Dim h As Integer = Height - 1
                'If _oldUi Then
                b = New SolidBrush(_bgColor) ' New LinearGradientBrush(r, _bgColor, _bgColor, 90)
                With gp
                    .AddLine(0, 0, w, 0)
                    .AddLine(w, 0, w, h)
                    .AddLine(w, h, 0, h)
                    .AddLine(0, h, 0, 0)
                End With
                'Else


                gp.CloseFigure()
                .FillPath(b, gp)
                If b IsNot Nothing Then
                    b.Dispose()
                End If

                Const correctionFactor As Single = 0.7F
                Dim red As Single = _bgColor.R * correctionFactor
                Dim green As Single = _bgColor.G * correctionFactor
                Dim blue As Single = _bgColor.B * correctionFactor
                Dim darkercolr As Color = Color.FromArgb(_bgColor.A, CInt(red), CInt(green), CInt(blue))

                .DrawPath(New Pen(darkercolr), gp)
                Dim f As New StringFormat
                f.Alignment = _align
                'Dim fo As New Font(Font.FontFamily, 8.5)
                'If OldUi Then
                .DrawString(_text, Font, Brushes.White, r2, f)
                'Else
                '.DrawString(_text, Font, Brushes.Black, r2, f)
                'End If
            End With
        Catch ex As Exception
        Finally
            If gp IsNot Nothing Then
                gp.Dispose()
            End If
        End Try
    End Sub
End Class
