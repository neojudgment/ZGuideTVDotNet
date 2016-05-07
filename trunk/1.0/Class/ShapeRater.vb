' •—————————————————————————————————————————————————————————————————————————————————•
' |                                                                                 |
' |    TvdbLib: A library to retrieve information and media from http://thetvdb.com |
' |                                                                                 |
' |    Copyright (C) 2008  Benjamin Gmeiner                                         |
' |                                                                                 |
' |    This program is free software: you can redistribute it and/or modify         |
' |    it under the terms of the GNU General Public License as published by         |
' |    the Free Software Foundation, either version 3 of the License, or            |
' |    (at your option) any later version.                                          |
' |                                                                                 |
' |    This program is distributed in the hope that it will be useful,              |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of               |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                |
' |    GNU General Public License for more details.                                 |
' |                                                                                 |
' |    You should have received a copy of the GNU General Public License            |
' |    along with this program.  If not, see <http://www.gnu.org/licenses/>.        |
' |                                                                                 |
' |    Converted to VB.NET and modified by Neo (neojudgment) and rvs75.             |
' |    October 2009 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>.              |
' |                                                                                 |
' •—————————————————————————————————————————————————————————————————————————————————•
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Globalization

<DefaultProperty("CurrentRating"), DefaultEvent("CurrentRatingChanged"), DefaultBindingProperty("CurrentRating")> _
Public Class Rater
    Inherits UserControl
    Implements ISupportInitialize

    Private Const DEFAULTVALUE As Integer = 0

    Private m_Initializing As Boolean
    Private m_CurrentRating As Integer = DEFAULTVALUE
    Private PaintRating As Integer
    Private IsPainting As Boolean
    Private PaintColor As Color
    Private RateLabel As Label
    Private PaintBorderColor As Color

    Public Sub New()
        MyBase.New()

        InitializeComponent()
        LabelText = "RateLabel"
        SetStyle( _
                  ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or _
                  ControlStyles.UserPaint, True)
    End Sub

#Region "Enum"

    Public Enum eShape
        Star
        Circle
        Square
        Triangle
        Diamond
        Heart
    End Enum

    Public Enum eLabelType
        Text
        TextItems
        FormatString
    End Enum

    Public Enum eShapeNumberShow
        None
        All
        RateOnly
    End Enum

#End Region

    Public Event CurrentRatingChanged As EventHandler

    <Category("AppearanceShaperRater"), Description("Get or Set the current Ratings value"), Bindable(True)> _
    Public Property CurrentRating() As Integer
        Get
            Return Me.m_CurrentRating
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.m_CurrentRating) AndAlso Not (Me.m_Initializing) Then
                Me.m_CurrentRating = value
                RaiseEvent CurrentRatingChanged(Me, EventArgs.Empty)
                PaintRating = value
                Me.Invalidate()
            End If
        End Set
    End Property

    Private Function ShouldSerializeCurrentRating() As Boolean
        Return Not CBool(Me.m_CurrentRating <> DEFAULTVALUE)
    End Function

    Public Overrides Function ToString() As String
        Return Me.CurrentRating.ToString(CultureInfo.CurrentCulture)
    End Function

    Private _MaxRating As Integer = 5

    <Category("AppearanceShaperRater"), Description("Get or Set number of shapes"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(5)> _
    Public Property MaxRating() As Integer
        Get
            Return _MaxRating
        End Get
        Set(ByVal value As Integer)
            _MaxRating = value
            Me.Invalidate()
        End Set
    End Property

    Private _LabelShow As Boolean = True

    <Category("AppearanceShaperRater"), Description("Get or Set if the Label is Visible"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(True)> _
    Public Property LabelShow() As Boolean
        Get
            Return _LabelShow
        End Get
        Set(ByVal value As Boolean)
            _LabelShow = value
            RateLabel.Visible = value
            Me.Invalidate()
        End Set
    End Property

    Private _LabelText As String = ""

    <Category("AppearanceShaperRater"), Description("Get or Set the base Label text with rating of 0"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue("")> _
    Public Property LabelText() As String
        Get
            Return _LabelText
        End Get
        Set(ByVal value As String)
            _LabelText = value
            RateLabel.Text = value

            Me.Invalidate()
        End Set
    End Property

    Private _LabelAlignment As ContentAlignment = ContentAlignment.MiddleCenter

    <Category("AppearanceShaperRater"), Description("Get or Set Alignment for the Label"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(StringAlignment.Near)> _
    Public Property LabelAlignment() As ContentAlignment
        Get
            Return _LabelAlignment
        End Get
        Set(ByVal value As ContentAlignment)
            _LabelAlignment = value
            RateLabel.TextAlign = value

            Me.Invalidate()
        End Set
    End Property

    Private _LabelIndent As Integer = 10

    <Category("AppearanceShaperRater"), Description("Get or Set the Gap between Rating and the Label"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(10)> _
    Public Property LabelIndent() As Integer
        Get
            Return _LabelIndent
        End Get
        Set(ByVal value As Integer)
            _LabelIndent = value
            Me.Invalidate()
        End Set
    End Property

    Private _LabelTextItems() As String = {"Poor", "Fair", "Good", "Better", "Best"}

    <Category("AppearanceShaperRater"), Description("Get or Set the text array of Label Items"), _
        DefaultValue(New String() {"Poor", "Fair", "Good", "Better", "Best"})> _
    Public Property LabelTextItems() As String()
        Get
            Return _LabelTextItems
        End Get
        Set(ByVal value As String())
            _LabelTextItems = value
            Me.Invalidate()
        End Set
    End Property

    Private _LabelFormatString As String = "{0} / {1}"

    <Category("AppearanceShaperRater"), _
        Description("Get or Set the a String.Format where {0} = Rate being hovered over and {1} = the MaxRating"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue("{0} out of {1}")> _
    Public Property LabelFormatString() As String
        Get
            Return _LabelFormatString
        End Get
        Set(ByVal value As String)
            _LabelFormatString = value
            Me.Invalidate()
        End Set
    End Property

    Private _LabelTypeText As eLabelType = eLabelType.Text

    <Category("AppearanceShaperRater"), Description("Get or Set the what text to show in the Label after selection"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(eLabelType.Text)> _
    Public Property LabelTypeText() As eLabelType
        Get
            Return _LabelTypeText
        End Get
        Set(ByVal value As eLabelType)
            _LabelTypeText = value
            Me.Invalidate()
        End Set
    End Property

    Private _LabelTypeHover As eLabelType = eLabelType.TextItems

    <Category("AppearanceShaperRater"), Description("Get or Set the what text to show in the Label while hovering"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(eLabelType.TextItems)> _
    Public Property LabelTypeHover() As eLabelType
        Get
            Return _LabelTypeHover
        End Get
        Set(ByVal value As eLabelType)
            _LabelTypeHover = value
            Me.Invalidate()
        End Set
    End Property

    Private _RadiusOuter As Single = 10

    <Category("AppearanceShaperRater"), Description("Get or Set Radius of the shape"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(10)> _
    Public Property RadiusOuter() As Single
        Get
            Return _RadiusOuter
        End Get
        Set(ByVal value As Single)
            _RadiusOuter = value
            Me.Invalidate()
        End Set
    End Property

    Private _RadiusInner As Single

    <Category("AppearanceShaperRater"), Description("Get or Set inner Radius of the Star shape"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(0)> _
    Public Property RadiusInner() As Single
        Get
            Return _RadiusInner
        End Get
        Set(ByVal value As Single)
            _RadiusInner = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeGap As Integer = 4

    <Category("AppearanceShaperRater"), Description("Get or Set the distance between the shapes"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(4)> _
    Public Property ShapeGap() As Integer
        Get
            Return _ShapeGap
        End Get
        Set(ByVal value As Integer)
            _ShapeGap = value
            Me.Invalidate()
        End Set
    End Property

    Private _Shape As eShape = eShape.Star

    <Category("AppearanceShaperRater"), Description("Get or Set what shape to draw"), _
        RefreshProperties(RefreshProperties.Repaint), DefaultValue(eShape.Star)> _
    Public Property Shape() As eShape
        Get
            Return _Shape
        End Get
        Set(ByVal value As eShape)
            _Shape = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeColorEmpty As Color = Color.Transparent

    <Category("AppearanceShaperRater"), Description("Get or Set the Color to fill the empty Shape"), _
        DefaultValue(GetType(Color), "Transparent")> _
    Public Property ShapeColorEmpty() As Color
        Get
            Return _ShapeColorEmpty
        End Get
        Set(ByVal value As Color)
            _ShapeColorEmpty = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeColorHover As Color = Color.LightCoral

    <Category("AppearanceShaperRater"), Description("Get or Set the Color to fill the Shapes being hovered over"), _
        DefaultValue(GetType(Color), "LightCoral")> _
    Public Property ShapeColorHover() As Color
        Get
            Return _ShapeColorHover
        End Get
        Set(ByVal value As Color)
            _ShapeColorHover = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeColorFill As Color = Color.Yellow

    <Category("AppearanceShaperRater"), Description("Get or Set the Color to fill the rated Shape"), _
        DefaultValue(GetType(Color), "Yellow")> _
    Public Property ShapeColorFill() As Color
        Get
            Return _ShapeColorFill
        End Get
        Set(ByVal value As Color)
            _ShapeColorFill = value
            Me.Invalidate()
        End Set
    End Property

    Private _HighlightRateHover As Boolean
    ' = False

    <Category("AppearanceShaperRater"), _
        Description _
            ("Get or Set the fill color of just the shape under the Mouse or all selected shapes while hovering"), _
        DefaultValue(False)> _
    Public Property HighlightRateHover() As Boolean
        Get
            Return _HighlightRateHover
        End Get
        Set(ByVal value As Boolean)
            _HighlightRateHover = value
        End Set
    End Property

    Private _HighlightRateFill As Boolean
    ' = False

    <Category("AppearanceShaperRater"), _
        Description("Get or Set the fill color of just the rated shape or all selected shapes up to the rated shape"), _
        DefaultValue(False)> _
    Public Property HighlightRateFill() As Boolean
        Get
            Return _HighlightRateFill
        End Get
        Set(ByVal value As Boolean)
            _HighlightRateFill = value
        End Set
    End Property

    Private _ShapeBorderFilledColor As Color = Color.Blue

    <Category("AppearanceShaperRater"), Description("Get or Set the Color to border the rated Shapes"), _
        DefaultValue(GetType(Color), "Blue")> _
    Public Property ShapeBorderFilledColor() As Color
        Get
            Return _ShapeBorderFilledColor
        End Get
        Set(ByVal value As Color)
            _ShapeBorderFilledColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeBorderEmptyColor As Color = Color.LightBlue

    <Category("AppearanceShaperRater"), Description("Get or Set the Color to border the empty Shape"), _
        DefaultValue(GetType(Color), "LightBlue")> _
    Public Property ShapeBorderEmptyColor() As Color
        Get
            Return _ShapeBorderEmptyColor
        End Get
        Set(ByVal value As Color)
            _ShapeBorderEmptyColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeBorderHoverColor As Color = Color.Blue

    <Category("AppearanceShaperRater"), Description("Get or Set the Color to border the Shape when hovering"), _
        DefaultValue(GetType(Color), "Blue")> _
    Public Property ShapeBorderHoverColor() As Color
        Get
            Return _ShapeBorderHoverColor
        End Get
        Set(ByVal value As Color)
            _ShapeBorderHoverColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeBorderWidth As Integer = 1

    <Category("AppearanceShaperRater"), Description("Get or Set the Width of the Shapes border"), DefaultValue(1)> _
    Public Property ShapeBorderWidth() As Integer
        Get
            Return _ShapeBorderWidth
        End Get
        Set(ByVal value As Integer)
            _ShapeBorderWidth = value
            Me.Invalidate()
        End Set
    End Property


    Private _ShapeNumberShow As eShapeNumberShow = eShapeNumberShow.None

    <Category("AppearanceShaperRater"), Description("Get or Set if the number is shown inside the Shape"), _
        DefaultValue(eShapeNumberShow.None)> _
    Public Property ShapeNumberShow() As eShapeNumberShow
        Get
            Return _ShapeNumberShow
        End Get
        Set(ByVal value As eShapeNumberShow)
            _ShapeNumberShow = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeNumberColor As Color = Color.Black

    <Category("AppearanceShaperRater"), Description("Get or Set the Color for the Number inside the Shape"), _
        DefaultValue(GetType(Color), "Black")> _
    Public Property ShapeNumberColor() As Color
        Get
            Return _ShapeNumberColor
        End Get
        Set(ByVal value As Color)
            _ShapeNumberColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeNumberFont As New Font("Arial", 8)

    <Category("AppearanceShaperRater"), Description("Get or Set the Font for the Number inside the Shape"), _
        DefaultValue(GetType(Font), "Arial, 8pt")> _
    Public Property ShapeNumberFont() As Font
        Get
            Return _ShapeNumberFont
        End Get
        Set(ByVal value As Font)
            _ShapeNumberFont = value
            Me.Invalidate()
        End Set
    End Property

    Private _ShapeNumberIndent As New Point(0, 0)

    <Category("AppearanceShaperRater"), Description("Get or Set the offset for the Number inside the Shape"), _
        DefaultValue(GetType(Point), "0, 0")> _
    Public Property ShapeNumberIndent() As Point
        Get
            Return _ShapeNumberIndent
        End Get
        Set(ByVal value As Point)
            _ShapeNumberIndent = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If (Not Me.m_Initializing) Then

            If _
                e.Y > (Me.Height - (RadiusOuter * 2)) / 2 And e.Y < ((Me.Height - (RadiusOuter * 2)) / 2) + (RadiusOuter * 2) - 1 And _
                e.X > Padding.Left And e.X < (RadiusOuter * 2 * MaxRating) + (ShapeGap * MaxRating) + Padding.Left Then
                Me.PaintRating = GetRate(e.X)
                IsPainting = True
                PaintColor = ShapeColorHover
                PaintBorderColor = ShapeBorderHoverColor
            End If
            Me.Refresh()
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If (Not Me.m_Initializing) Then
            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                Me.CurrentRating = 0
            Else
                If _
                    e.Y > (Me.Height - (RadiusOuter * 2)) / 2 And _
                    e.Y < ((Me.Height - (RadiusOuter * 2)) / 2) + (RadiusOuter * 2) - 1 And e.X > Padding.Left And _
                    e.X < (RadiusOuter * 2 * MaxRating) + (ShapeGap * MaxRating) + Padding.Left Then
                    Me.CurrentRating = GetRate(e.X)
                End If
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        If (Not Me.m_Initializing) Then
            PaintRating = CurrentRating
            PaintColor = ShapeColorFill
            PaintBorderColor = ShapeBorderFilledColor
            IsPainting = False
        End If
        Me.Refresh()
    End Sub

    Public Function GetLabelText(ByVal LabelType As eLabelType) As String
        Select Case LabelType
            Case eLabelType.Text
                Return LabelText
            Case eLabelType.TextItems
                Select Case Me.PaintRating
                    Case 0
                        Return LabelText
                        'case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                        'LabelTextItems.GetUpperBound(0) + 1:
                        'return "";
                    Case Else
                        Return _
                            If _
                                ((LabelTextItems.Length > Me.PaintRating AndAlso Me.PaintRating > 0), _
                                 LabelTextItems(Me.PaintRating - 1), "n/a")
                End Select
            Case eLabelType.FormatString
                Return String.Format(CultureInfo.CurrentCulture, LabelFormatString, Me.PaintRating, MaxRating)
            Case Else
                Return ""
        End Select

    End Function

    Public Function GetRate(ByVal eX As Integer) As Integer
        Dim mRate As Integer = 0

        Do _
            While _
                Not _
                (eX >= (ShapeGap * mRate) + ((RadiusOuter * 2) * mRate) + Padding.Left And _
                 eX <= (ShapeGap * (mRate + 1)) + ((RadiusOuter * 2) * (mRate + 1)) + Padding.Left)
            mRate += 1
        Loop
        Return mRate + 1
    End Function

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim intRate As Integer = 0
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim UseFillColor As New Color()
        Dim UseBorderColor As New Color()
        Dim ShapePath As New GraphicsPath()
        Dim ptx As Single
        Dim pty As Single
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        pty = (Me.Height - (RadiusOuter * 2)) / 2
        intRate = 0
        Do While Not (intRate = MaxRating)
            ptx = CSng(intRate * (RadiusOuter * 2 + ShapeGap) + Padding.Left + (ShapeGap / 2))
            If PaintRating > intRate Then
                If (Not IsPainting) And HighlightRateFill And (PaintRating <> intRate + 1) Then
                    UseFillColor = ShapeColorHover
                    UseBorderColor = ShapeBorderHoverColor
                ElseIf IsPainting And HighlightRateHover And (PaintRating = intRate + 1) Then
                    UseFillColor = ShapeColorFill
                    UseBorderColor = ShapeBorderFilledColor
                Else
                    UseFillColor = PaintColor
                    UseBorderColor = PaintBorderColor
                End If
            Else
                UseFillColor = ShapeColorEmpty
                UseBorderColor = ShapeBorderEmptyColor
            End If

            ShapePath.Reset()
            Dim pts() As Point
            Select Case Shape
                Case eShape.Star
                    ShapePath = DrawStar(ptx, pty)
                Case eShape.Heart
                    ShapePath = DrawHeart(ptx, pty)
                Case eShape.Square
                    ShapePath.AddRectangle( _
                                            New Rectangle(CInt(Fix(ptx)), CInt(Fix(pty)), _
                                                           CInt(Fix(RadiusOuter * 2)), CInt(Fix(RadiusOuter * 2))))
                Case eShape.Circle
                    ShapePath.AddEllipse(ptx, pty, RadiusOuter * 2, RadiusOuter * 2)
                Case eShape.Diamond
                    pts = _
                        New Point() _
                            {New Point(CInt(Fix(ptx + RadiusOuter)), CInt(Fix(pty))), _
                             New Point(CInt(Fix(ptx + RadiusOuter * 2)), CInt(Fix(pty + RadiusOuter))), _
                             New Point(CInt(Fix(ptx + RadiusOuter)), CInt(Fix(pty + RadiusOuter * 2))), _
                             New Point(CInt(Fix(ptx)), CInt(Fix(pty + RadiusOuter)))}
                    ShapePath.AddPolygon(pts)
                Case eShape.Triangle
                    pts = _
                        New Point() _
                            {New Point(CInt(Fix(ptx + RadiusOuter)), CInt(Fix(pty))), _
                             New Point(CInt(Fix(ptx + RadiusOuter * 2)), CInt(Fix(pty + RadiusOuter * 2))), _
                             New Point(CInt(Fix(ptx)), CInt(Fix(pty + RadiusOuter * 2)))}
                    ShapePath.AddPolygon(pts)

            End Select

            With e.Graphics
                .FillPath(New SolidBrush(UseFillColor), ShapePath)
                .DrawPath(New Pen(UseBorderColor, ShapeBorderWidth), ShapePath)
            End With

            If ShapeNumberShow <> eShapeNumberShow.None Then
                If _
                    ShapeNumberShow = eShapeNumberShow.All Or _
                    (ShapeNumberShow = eShapeNumberShow.RateOnly And PaintRating = intRate + 1) Then
                    e.Graphics.DrawString((intRate + 1).ToString(CultureInfo.CurrentCulture), ShapeNumberFont, _
                                           New SolidBrush(ShapeNumberColor), _
                                           New RectangleF(ShapeNumberIndent.X + ptx, ShapeNumberIndent.Y + pty, _
                                                           RadiusOuter * 2, RadiusOuter * 2), sf)
                End If
            End If

            intRate += 1
        Loop

        If LabelShow Then
            Dim _
                R_x As Integer = _
                    CInt(Fix(((RadiusOuter * 2) * (MaxRating)) + LabelIndent + ((ShapeGap) * MaxRating) + Padding.Left))
            If IsPainting Then
                RateLabel.Text = GetLabelText(LabelTypeHover)
            Else
                RateLabel.Text = GetLabelText(LabelTypeText)
            End If

            With RateLabel
                .Width = (Me.Width - R_x)
                .Height = (Me.Height)
                .Location = New Point(R_x, 0)
            End With

        End If
    End Sub

    Public Function DrawStar(ByVal Xc As Single, ByVal Yc As Single) As GraphicsPath
        Dim gp As New GraphicsPath()
        Xc += RadiusOuter
        Yc += RadiusOuter
        ' RadiusInner and InnerRadius: determines how far from the center the inner vertices of the star are.
        ' RadiusOuter: determines the size of the star.
        ' xc, yc: determine the location of the star.
        Dim sin36 As Single = CSng(Math.Sin(36.0 * Math.PI / 180.0))
        Dim sin72 As Single = CSng(Math.Sin(72.0 * Math.PI / 180.0))
        Dim cos36 As Single = CSng(Math.Cos(36.0 * Math.PI / 180.0))
        Dim cos72 As Single = CSng(Math.Cos(72.0 * Math.PI / 180.0))
        Dim InnerRadius As Single = (RadiusOuter * cos72 / cos36) + RadiusInner

        Dim pts(9) As PointF
        pts(0) = New PointF(Xc, Yc - RadiusOuter)
        pts(1) = New PointF(Xc + InnerRadius * sin36, Yc - InnerRadius * cos36)
        pts(2) = New PointF(Xc + RadiusOuter * sin72, Yc - RadiusOuter * cos72)
        pts(3) = New PointF(Xc + InnerRadius * sin72, Yc + InnerRadius * cos72)
        pts(4) = New PointF(Xc + RadiusOuter * sin36, Yc + RadiusOuter * cos36)
        pts(5) = New PointF(Xc, Yc + InnerRadius)
        pts(6) = New PointF(Xc - RadiusOuter * sin36, Yc + RadiusOuter * cos36)
        pts(7) = New PointF(Xc - InnerRadius * sin72, Yc + InnerRadius * cos72)
        pts(8) = New PointF(Xc - RadiusOuter * sin72, Yc - RadiusOuter * cos72)
        pts(9) = New PointF(Xc - InnerRadius * sin36, Yc - InnerRadius * cos36)

        gp.AddPolygon(pts)

        Return gp

    End Function

    Public Function DrawHeart(ByVal Xc As Single, ByVal Yc As Single) As GraphicsPath
        Dim gp As New GraphicsPath()

        Dim _
            HeartTopLeftSquare As _
                New Rectangle(CInt(Fix(Xc)), CInt(Fix(Yc)), CInt(Fix(RadiusOuter)), CInt(Fix(RadiusOuter)))
        Dim _
            HeartTopRightSquare As _
                New Rectangle(CInt(Fix(Xc)) + CInt(Fix(RadiusOuter)), CInt(Fix(Yc)), CInt(Fix(RadiusOuter)), _
                               CInt(Fix(RadiusOuter)))

        With gp
            .AddArc(HeartTopLeftSquare, 135.0F, 225.0F)
            .AddArc(HeartTopRightSquare, 180.0F, 225.0F)
            .AddLine(CInt(Fix(Xc + (RadiusOuter * 2) - (1 - Math.Sin(45 \ CLng(180 * Math.PI))) * RadiusOuter / 2)), _
                      CInt(Fix(Yc + RadiusOuter / 2 + Math.Sin(45 \ CLng(180 * Math.PI)) * RadiusOuter / 2)), _
                      CInt(Fix(Xc + RadiusOuter)), CInt(Fix(Yc + (RadiusOuter * 2))))
            .AddLine(CInt(Fix(Xc + RadiusOuter / 2 - Math.Sin(45 \ CLng(180 * Math.PI)) * RadiusOuter / 2)), _
                      CInt(Fix(Yc + RadiusOuter / 2 + Math.Sin(45 \ CLng(180 * Math.PI)) * RadiusOuter / 2)), _
                      CInt(Fix(Xc + RadiusOuter)), CInt(Fix(Yc + (RadiusOuter * 2))))
        End With

        Return gp
    End Function

    Public Sub BeginInit() Implements ISupportInitialize.BeginInit
        Me.m_Initializing = True
    End Sub

    Public Sub EndInit() Implements ISupportInitialize.EndInit
        Me.m_Initializing = False
        PaintColor = ShapeColorFill
        PaintBorderColor = ShapeBorderFilledColor
        PaintRating = CurrentRating
        Me.CurrentRating = Me.m_CurrentRating
    End Sub

    Private Sub InitializeComponent()
        Me.RateLabel = New Label()
        Me.SuspendLayout()
        ' 
        ' RateLabel
        ' 
        With Me.RateLabel
            .Anchor = (CType(((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left), AnchorStyles))
            .AutoSize = True
            .Location = New Point(4, 8)
            .Name = "RateLabel"
            .Size = New Size(35, 13)
            .TabIndex = 0
            .Text = "label1"
        End With
        ' 
        ' Rater
        ' 
        Me.Controls.Add(Me.RateLabel)
        With Me
            .Name = "Rater"
            .Size = New Size(78, 30)
            .ResumeLayout(False)
            .PerformLayout()
        End With

    End Sub
End Class
