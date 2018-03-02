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
'Imports System.ComponentModel
'Imports System.Drawing.Drawing2D
'Imports System.Drawing.Imaging

'' ReSharper disable CheckNamespace
'Namespace MG.Controls.BarLib
'    ' ReSharper restore CheckNamespace

'    Public Enum BarType
'        [Static]
'        ' Plain and simple bar with procent display
'        Progressbar
'        ' This makes the control act as a progressbar
'        Animated
'        ' This makes the control "Rubber band" to new procent values (Animated).
'    End Enum

'    Public Delegate Sub BarValueChanged(ByVal sender As Object, ByVal e As EventArgs)

'    <ToolboxBitmap(GetType(ProgressBar))> _
'    Partial Public Class IBar
'        Inherits UserControl

'        Private Shared ReadOnly PreBarBaseDark As Color = Color.FromArgb(199, 200, 201)
'        Private Shared ReadOnly PreBarBaseLight As Color = Color.WhiteSmoke
'        Private Shared ReadOnly PreBarLight As Color = Color.FromArgb(102, 144, 252)
'        Private Shared ReadOnly PreBarDark As Color = Color.FromArgb(40, 68, 202)
'        Private Shared ReadOnly PreBorderColor As Color = Color.DarkGray

'        Private _clrBarBgLight As Color = PreBarBaseLight
'        Private _clrBarBgDark As Color = PreBarBaseDark
'        Private _clrBarLight As Color = PreBarLight
'        Private _clrBarDark As Color = PreBarDark
'        Private _clrBorderColor As Color = PreBorderColor
'        Private _fBorderWidth As Single = 1.25F
'        Private _fMirrorOpacity As Single = 40.0F
'        Private _fFillProcent As Single = 50.0F
'        Private _iNumDividers As Integer = 10
'        Private ReadOnly _tTickTimer As New Timer()
'        Private _iStepSize As Single
'        Private _eBarType As BarType = BarType.Static
'        Private ReadOnly _tAnimTicker As New Timer()
'        Private _fNewProcent As Single
'        Private _bAnimUp As Boolean

'        Public Event OnBarValueChanged As EventHandler(Of EventArgs)

'#Region "Property"

'        <Description("Gets or sets the stepsize. This controls how many steps it will progress when making a move"), _
'    DefaultValue(2)> _
'        Public Property StepSize() As Single
'            Get
'                Return _iStepSize
'            End Get
'            Set(ByVal value As Single)
'                _iStepSize = value
'                _tTickTimer.Enabled = _
'                    (_iStepSize <> 0 AndAlso _tTickTimer.Interval > 0 AndAlso _eBarType = BarType.Progressbar)
'            End Set
'        End Property

'        < _
'            Description _
'                ( _
'                 "Gets or sets the StepInterval. This value determins how ofthen the control is updated using the StepSize"), _
'            DefaultValue(5)> _
'        Public Property StepInterval() As Integer
'            Get
'                Return _tTickTimer.Interval
'            End Get
'            Set(ByVal value As Integer)
'                _tTickTimer.Interval = value
'                _tTickTimer.Enabled = _
'                    (_iStepSize <> 0 AndAlso _tTickTimer.Interval > 0 AndAlso _eBarType = BarType.Progressbar)
'            End Set
'        End Property

'        <Description("Gets or sets how many dividers to display on the bar"), DefaultValue(10), _
'            RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarDividersCount() As Integer
'            Get
'                Return _iNumDividers
'            End Get
'            Set(ByVal value As Integer)
'                _iNumDividers = value
'                Refresh()
'            End Set
'        End Property

'        <Description("Gets or sets the opacity level for the reflecting part of the control"), DefaultValue(35.0F), _
'            RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarMirrorOpacity() As Single
'            Get
'                Return _fMirrorOpacity
'            End Get
'            Set(ByVal value As Single)
'                _fMirrorOpacity = value
'                Refresh()
'            End Set
'        End Property

'        <Description("Gets or sets the fill procent"), DefaultValue(50.0F), _
'            RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarFillProcent() As Single
'            Get
'                Return _fFillProcent
'            End Get
'            Set(ByVal value As Single)
'                If _eBarType = BarType.Animated Then
'                    MakeAnimation(value)
'                    Return
'                End If

'                _fFillProcent = value
'                Refresh()
'            End Set
'        End Property

'        <Description("Gets or sets the with of the borders"), DefaultValue(1.0F), _
'            RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarBorderWidth() As Single
'            Get
'                Return _fBorderWidth
'            End Get
'            Set(ByVal value As Single)
'                _fBorderWidth = value
'                Refresh()
'            End Set
'        End Property

'        <Description("Gets or sets the lighter background color"), RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarBackgroundLight() As Color
'            Get
'                Return _clrBarBgLight
'            End Get
'            Set(ByVal value As Color)
'                _clrBarBgLight = value
'                Refresh()
'            End Set
'        End Property

'        <Description("Gets or sets the darker background color"), RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarBackgroundDark() As Color
'            Get
'                Return _clrBarBgDark
'            End Get
'            Set(ByVal value As Color)
'                _clrBarBgDark = value
'                Refresh()
'            End Set
'        End Property

'        <Description("Gets or sets the light bar color"), RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarLight() As Color
'            Get
'                Return _clrBarLight
'            End Get
'            Set(ByVal value As Color)
'                _clrBarLight = value
'                Refresh()
'            End Set
'        End Property

'        <Description("Gets or sets the dark bar color"), RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarDark() As Color
'            Get
'                Return _clrBarDark
'            End Get
'            Set(ByVal value As Color)
'                _clrBarDark = value
'                Refresh()
'            End Set
'        End Property

'        <Description("Gets or sets the border color"), RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarBorderColor() As Color
'            Get
'                Return _clrBorderColor
'            End Get
'            Set(ByVal value As Color)
'                _clrBorderColor = value
'                Refresh()
'            End Set
'        End Property

'        < _
'            Description _
'                ( _
'                 "Gets or sets the type. This changes the bahaviour of the control. See the BarType enum for specification"), _
'            DefaultValue(BarType.Animated), RefreshProperties(RefreshProperties.Repaint)> _
'        Public Property BarType() As BarType
'            Get
'                Return _eBarType
'            End Get
'            Set(ByVal value As BarType)
'                _eBarType = value
'                If value <> BarType.Progressbar Then
'                    _iStepSize = 0
'                    _tTickTimer.Enabled = False
'                End If
'            End Set
'        End Property

'#End Region

'        Public Sub New()
'            SetStyle( _
'                      ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or _
'                      ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)

'            InitializeComponent()
'            With Me
'                .Width = 300
'                .Height = 50
'            End With

'            ' Progressbar timer
'            AddHandler _tTickTimer.Tick, AddressOf TickTimerTick

'            With _tTickTimer
'                .Enabled = False
'                .Interval = 100
'            End With

'            ' Animation timer
'            With _tAnimTicker
'                .Enabled = False
'                .Interval = 75
'            End With

'            AddHandler _tAnimTicker.Tick, AddressOf AnimationTimerTick

'        End Sub

'        ' END CONSTRUCTOR: iBar(... )
'        Public Function ToImage() As Bitmap

'            Dim retVal As New Bitmap(Width, Height)
'            Dim g As Graphics = Graphics.FromImage(retVal)
'            g.SmoothingMode = SmoothingMode.AntiAlias
'            g.Clear(BackColor)

'            Dim _
'                bmp As Bitmap = _
'                    GenerateProcentBar(Width, Height, _fFillProcent, _fMirrorOpacity, BackColor)
'            g.DrawImage(bmp, 0, 0)

'            g.Dispose()
'            Return retVal
'        End Function

'        ' END METHOD: ToImage(... )
'        Private Sub TickTimerTick(ByVal sender As Object, ByVal e As EventArgs)
'            _fFillProcent += _iStepSize
'            If _fFillProcent >= 100.0F Then
'                _fFillProcent = 0.0F
'            ElseIf _fFillProcent < 0.0F Then
'                _fFillProcent = 100.0F
'            End If

'            Refresh()

'            ' Trigger event if any defined
'            RaiseEvent OnBarValueChanged(Me, EventArgs.Empty)

'        End Sub

'        ' END METHOD: TickTimer_Tick(... )
'        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
'            Dim g As Graphics = e.Graphics
'            g.SmoothingMode = SmoothingMode.AntiAlias
'            g.Clear(BackColor)

'            Dim _
'                bmp As Bitmap = _
'                    GenerateProcentBar(Width, Height, _fFillProcent, _fMirrorOpacity, BackColor)
'            g.DrawImage(bmp, 0, 0)

'        End Sub

'        ' END METHOD: OnPaint(... )
'        Private Sub GenerateBar(ByRef g As Graphics, ByVal x As Single, ByVal y As Single, ByVal width As Single, _
'                                 ByVal height As Single, ByVal fillProcent As Single)
'            Dim procentMarkerWidth As Single = (width / _iNumDividers)
'            Dim totalWidth As Single = width
'            Dim rect As New RectangleF(x, y, width, height)

'            Using white As New LinearGradientBrush(rect, _clrBarBgLight, _clrBarBgDark, 90.0F, False)
'                g.FillRectangle(white, rect)

'            End Using
'            ' END using( LinearGradientBrush white = new LinearGradientBrush( rect, clrBarBgLight, clrBarBgDark, 90.0F, false ) )

'            Using p As New Pen(_clrBorderColor, _fBorderWidth * 2)
'                p.Alignment = PenAlignment.Outset
'                p.LineJoin = LineJoin.Round
'                g.DrawRectangle(p, x, y, width, height)

'            End Using
'            ' END using( Pen p = new Pen( this.clrBorderColor, this.fBorderWidth * 2 ) )

'            width = (If(fillProcent > 0, ((fillProcent / 100) * width), 0))
'            If width > 0.1F Then
'                rect = New RectangleF(x, y, width, height)
'                Using bg As New LinearGradientBrush(rect, _clrBarLight, _clrBarDark, 90.0F, False)
'                    g.FillRectangle(bg, rect)

'                End Using
'                ' END using( LinearGradientBrush bg = new LinearGradientBrush( rect, this.clrBarLight, this.clrBarDark, 90.0F, false ) )

'                Using p As New Pen(_clrBorderColor, _fBorderWidth)
'                    p.Alignment = PenAlignment.Inset
'                    p.LineJoin = LineJoin.Round
'                    g.DrawLine(p, width, y, width, height)

'                End Using
'                ' END using( Pen p = new Pen( this.clrBorderColor, this.fBorderWidth ) )

'            End If
'            ' END if( width > 0 )

'            Using p As New Pen(_clrBarDark, _fBorderWidth)
'                p.Alignment = PenAlignment.Inset
'                p.LineJoin = LineJoin.Round
'                Using p2 As New Pen(_clrBarLight, _fBorderWidth)
'                    p2.Alignment = PenAlignment.Inset
'                    p2.LineJoin = LineJoin.Round
'                    For i As Single = procentMarkerWidth To totalWidth - 1 Step procentMarkerWidth
'                        If i >= width Then
'                            p.Color = _clrBarBgLight
'                            p2.Color = _clrBarBgDark

'                        End If
'                        ' END if( i >= width )

'                        g.DrawLine(p, i, 0, i, height)
'                        g.DrawLine(p2, i + _fBorderWidth, 0, i + _fBorderWidth, height)

'                    Next i
'                    ' END for( float i = procentMarkerWidth; i < totalWidth; i += procentMarkerWidth )

'                End Using
'                ' END using( Pen p2 = new Pen( this.clrBarLight, this.fBorderWidth ) )

'            End Using
'            ' END using( Pen p = new Pen( this.clrBarDark, this.fBorderWidth ) )

'        End Sub

'        ' END METHOD: GenerateBar(... )
'        Private Function GenerateBarImage(ByVal width As Integer, ByVal height As Integer, ByVal procent As Single) _
'            As Bitmap
'            Dim bmp As New Bitmap(width, height)
'            Dim g As Graphics = Graphics.FromImage(bmp)

'            GenerateBar(g, 0.0F, 0.0F, width, height, procent)
'            g.Dispose()

'            Return bmp

'        End Function

'        ' END METHOD: GenerateBarImage(... )
'        Private Function FadeToBg(ByVal image As Bitmap, ByVal bgColor As Color, ByVal angle As Single) As Bitmap
'            Dim bmp As New Bitmap(image.Width, image.Height)
'            Dim g As Graphics = Graphics.FromImage(bmp)

'            g.DrawImage(image, 0, 0)
'            Dim source As New Rectangle(0, -1, bmp.Width, bmp.Height)
'            Using bg As New LinearGradientBrush(source, Color.Transparent, bgColor, angle, False)
'                g.FillRectangle(bg, source)

'            End Using
'            ' END using( LinearGradientBrush bg = new LinearGradientBrush( source, Color.Transparent, bgColor, angle, false ) )

'            g.Dispose()

'            Return bmp

'        End Function

'        ' END METHOD: FadeToBg(... )
'        Private Function GenerateProcentBar(ByVal width As Integer, ByVal height As Integer, ByVal procent As Single, _
'                                             ByVal mirrorOpacity As Single, ByVal bgColor As Color) As Bitmap
'            Dim theImage As New Bitmap(width, height)
'            Dim g As Graphics = Graphics.FromImage(theImage)

'            g.SmoothingMode = SmoothingMode.AntiAlias
'            g.Clear(bgColor)

'            Dim bmp As Bitmap = GenerateBarImage(width, height - (height \ 3), procent)
'            Dim mirror As Bitmap = FadeToBg(bmp, bgColor, -90.0F)
'            Dim state As GraphicsState = g.Save()
'            g.ScaleTransform(1, -1.0F, MatrixOrder.Prepend)

'            Dim clr As New ColorMatrix()
'            Dim attributes As New ImageAttributes()

'            clr.Matrix33 = (mirrorOpacity / 100)
'            attributes.SetColorMatrix(clr)

'            Dim source As New Rectangle(0, -(height), mirror.Width, mirror.Height)
'            g.DrawImage(mirror, source, 0, 0, mirror.Width, mirror.Height, GraphicsUnit.Pixel, attributes)

'            g.Restore(state)
'            g.DrawImage(bmp, 0, -5)

'            g.Dispose()
'            bmp.Dispose()
'            mirror.Dispose()

'            Return theImage

'        End Function

'        ' END METHOD: GenerateProcentBar(... )
'        Private Sub MakeAnimation(ByVal newProcent As Single)
'            _fNewProcent = newProcent
'            _bAnimUp = ((_fFillProcent - newProcent) > 0)
'            _tAnimTicker.Interval = 1
'            _tAnimTicker.Enabled = True

'        End Sub

'        ' END METHOD: MakeAnimation(... )
'        Private Sub AnimationTimerTick(ByVal sender As Object, ByVal e As EventArgs)
'            _fFillProcent -= ((_fFillProcent - _fNewProcent) / 5.0F)
'            _tAnimTicker.Enabled = (If((Not _bAnimUp), (_fFillProcent <= _fNewProcent), (_fFillProcent >= _fNewProcent)))

'            Refresh()

'        End Sub

'        ' END METHOD: AnimationTimer_Tick(... )
'    End Class
'End Namespace