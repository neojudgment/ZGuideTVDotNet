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
Public Class lbLoader
    Inherits Panel

    Private Const WS_EX_TRANSPARENT As Int32 = &H20

    Private titi As New Font("Microsoft Sans Serif", 20.25, FontStyle.Bold, GraphicsUnit.Point)
    Private _text As String = "Veuillez patienter. Mise à jour des données en cours..."

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        ' surcharge pour vider le onpaintbackground
    End Sub

    Public Overrides Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
            'calcul automatique de la taille du control
            Dim drawingArea As Graphics = CreateGraphics()
            Dim StringSize As New SizeF(drawingArea.MeasureString(_text, titi))
            Width = CInt(StringSize.Width)
            Height = CInt(StringSize.Height)
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

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        With Me
            .SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            .UpdateStyles()
            .BackColor = Color.Transparent
        End With
    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        Try
            'Dim backBuffer As New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
            Dim drawingArea As Graphics = pevent.Graphics

            Dim b2 As New SolidBrush(Color.LimeGreen)
            Dim r2 As New RectangleF(0, 0, Me.Width, Me.Height)

            With drawingArea
                Dim f As New StringFormat
                f.Alignment = _Align
                .DrawString(_text, titi, b2, r2, f)
            End With
        Catch
        End Try
    End Sub
End Class
