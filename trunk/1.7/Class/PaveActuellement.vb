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
Public Class PaveActuellement
    ' ReSharper restore CheckNamespace
    Inherits UserControl

    Private _text As String = ""
    Private _debut As DateTime = DateTime.Now
    Private _fin As DateTime = DateTime.Now
    Private _duree As Long = 60
    Private _tempsEcoule As Long
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

    'propriete de debut d'emission
    Public Property Debut As DateTime
        Get
            Return _debut
        End Get
        Set(ByVal value As DateTime)
            _debut = value
        End Set
    End Property

    'propriete de fin d'emission
    Public Property Fin As DateTime
        Get
            Return _fin
        End Get
        Set(ByVal value As DateTime)
            _fin = value
        End Set
    End Property

    Private _align As StringAlignment = StringAlignment.Near
    Public Property Align() As StringAlignment
        Get
            Return _align
        End Get
        Set(ByVal value As StringAlignment)
            _align = value
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
    Private _oldUI As Boolean = True

    'Public Property old_UI() As Boolean
    '    Get
    '        Return _oldUI
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _oldUI = value
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

#End Region

    'rafraichissement 
    Public Sub Rafraichir()
        _tempsEcoule = DateDiff("n", _debut, DateTime.Now)
        Invalidate()
    End Sub

    'force l'initialisation des variable interne
    Public Sub Initialiser()
        _duree = DateDiff("n", _Debut, _fin)
        _tempsEcoule = DateDiff("n", _Debut, DateTime.Now)
        Invalidate()
    End Sub

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
        Dim r As New Rectangle(0, 0, Width, Height)
        ''Dim b As LinearGradientBrush
        Dim b2 As New SolidBrush(ForeColor)
        'Dim gp As GraphicsPath = New GraphicsPath
        'path des rectangle d'etat d'avancement des émissions
        Dim gp2 As GraphicsPath = New GraphicsPath
        Dim gp As New GraphicsPath
        Dim gp3 As GraphicsPath = New GraphicsPath

        'creation de la brush arcenciel pour le temps ecoulé
        Dim lgbEcoule As New LinearGradientBrush(r, Color.Black, Color.Black, 0)

        'creation de la brush arcenciel pour le temps restant
        Dim lgbRestant As New LinearGradientBrush(r, Color.Black, Color.Black, 0)

        'Redraw()
        Try
            Dim drawingArea As Graphics = pevent.Graphics
            'hauteur daffichage de l'etat d'avancement de l'émission
            Dim hauteur As Integer
            hauteur = 4

            'largeur du rectangle du temps écoulé (une bête regle de trois)
            'le temps restant est calcule comme _duree - _tempsEcoule
            Dim largeur As Integer = CInt(Math.Floor(((Width - 1) * _tempsEcoule) / _duree))

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

                    gp.AddEllipse(r3)
                    Dim b As New PathGradientBrush(gp)
                    b.CenterPoint = PointToClient(MousePosition)
                    b.CenterColor = lighterColor
                    b.SurroundColors = New Color() {_bgColor}
                    gp.Dispose()
                    .FillRectangle(b, rect)
                    If b IsNot Nothing Then
                        b.Dispose()
                    End If
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

                'creation des rectangle pour la barre d'avancement des émissions
                With gp2
                    .AddLine(1, h - hauteur, largeur, h - hauteur)
                    .AddLine(largeur, h - hauteur, largeur, h)
                    .AddLine(largeur, h, 1, h)
                    .AddLine(1, h, 1, h - hauteur)
                End With

                With gp3
                    .AddLine(largeur, h - hauteur, w, h - hauteur)
                    .AddLine(w, h - hauteur, w, h)
                    .AddLine(w, h, largeur, h)
                    .AddLine(largeur, h, largeur, h - hauteur)
                End With

                'fermeture des rectangles
                gp2.CloseFigure()
                gp3.CloseFigure()

                Dim myBlend As ColorBlend = New ColorBlend(2)
                myBlend.Positions = New Single() {0.0, 0.5, 1.0}
                myBlend.Colors = New Color() {Color.Green, Color.Yellow, Color.Red}
                lgbEcoule.InterpolationColors = myBlend
                
                Dim myBlend2 As ColorBlend = New ColorBlend(2)
                myBlend2.Positions = New Single() {0.0F, 0.5F, 1.0F}
                myBlend2.Colors = New Color() {Color.LightGreen, Color.LightYellow, Color.Pink}
                lgbRestant.InterpolationColors = myBlend2

                'remplissage des rectangles
                .FillPath(lgbEcoule, gp2)
                .FillPath(lgbRestant, gp3)

                'ecriture du nom de l'emission
                Dim f As New StringFormat
                f.Alignment = _align
                Dim fo As New Font(Font.FontFamily, 8.5)
                .DrawString(" " & _text, fo, b2, r2, f)
            End With

        Catch ex As Exception
        Finally
            If gp IsNot Nothing Then
                gp.Dispose()
            End If
            If gp2 IsNot Nothing Then
                gp2.Dispose()
            End If
            If gp3 IsNot Nothing Then
                gp3.Dispose()
            End If
            If lgbEcoule IsNot Nothing Then
                lgbEcoule.Dispose()
            End If
            If lgbRestant IsNot Nothing Then
                lgbRestant.Dispose()
            End If
        End Try
    End Sub

    Private Sub PaveActuellementMouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseEnter
        Try
            _mouseHover = True
            Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PaveActuellementMouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseLeave
        Try
            _mouseHover = False
            Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub PaveActuellementMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
    '    Try
    '        _mouseClick = True
    '        Invalidate()
    '    Catch ex As Exception
    '    End Try

    'End Sub

    'Private Sub PaveActuellementMouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.MouseUp
    '    Try
    '        _mouseClick = False
    '        Invalidate()
    '    Catch ex As Exception
    '    End Try

    'End Sub
    Private Sub PaveActuellementMouseMove(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseMove
        Invalidate()
    End Sub
End Class

