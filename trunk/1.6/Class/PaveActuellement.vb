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
    Private _mouseClick As Boolean
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

    'propriete de debut d'emission
    Public Property Debut As DateTime
        Get
            Return _Debut
        End Get
        Set(ByVal value As DateTime)
            _Debut = value
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
            Return _Align
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
        AutoScaleMode = Windows.Forms.AutoScaleMode.None
    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        Dim r As New Rectangle(0, 0, Width, Height)
        Dim b As LinearGradientBrush
        Dim b2 As New LinearGradientBrush(r, ForeColor, ForeColor, 90)
        Dim gp As GraphicsPath = New GraphicsPath

        'path des rectangle d'etat d'avancement des émissions
        Dim gp2 As GraphicsPath = New GraphicsPath
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
                .Clear(_brdersColor)
                Dim r2 As New RectangleF(0, (Height \ 2) - hauteurstring, Width, hauteurstring * 2)

                Dim w As Integer = Width - 1
                Dim h As Integer = Height - 1

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
                    b = New LinearGradientBrush(r, Color.White, _bgColor, 90)
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
                End If

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
                gp.CloseFigure()
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
                .FillPath(b, gp)
                .FillPath(lgbEcoule, gp2)
                .FillPath(lgbRestant, gp3)

                'coloriage des contours des rectangles
                'avec pseudo simulation "appui bouton"
                If _mouseClick AndAlso _oldUI Then
                    .DrawPath(New Pen(Color.DarkBlue, 3), gp)
                Else
                    If _mouseHover AndAlso old_UI Then
                        .DrawPath(New Pen(Color.White), gp)
                    Else
                        .DrawPath(New Pen(Color.DarkBlue), gp)
                    End If

                End If

                'ecriture du nom de l'emission
                Dim f As New StringFormat
                f.Alignment = _align
                Dim fo As New Font(Font.FontFamily, 8.5)
                'si old_ui, emulation du comportement d'un bouton
                If old_UI Then
                    .DrawString("  " & _text, fo, b2, r2, f)
                Else
                    .DrawString(_text, fo, b2, r2, f)
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

    Private Sub PaveActuellementMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        Try
            _mouseClick = True
            Invalidate()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub PaveActuellementMouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.MouseUp
        Try
            _mouseClick = False
            Invalidate()
        Catch ex As Exception
        End Try

    End Sub
End Class

