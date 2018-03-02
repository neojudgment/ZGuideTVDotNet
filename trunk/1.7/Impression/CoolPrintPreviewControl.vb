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

Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Friend Enum ZoomMode
    ActualSize = 0
    Custom = 4
    FullPage = 1
    PageWidth = 2
    TwoPages = 3
End Enum

Friend Class CoolPrintPreviewControl

    Inherits UserControl

    ' Events
    Public Event PageCountChanged As EventHandler
    Public Event StartPageChanged As EventHandler
    Public Event ZoomModeChanged As EventHandler

    ' Methods
    Public Sub New()
        BackColor = SystemColors.AppWorkspace
        ZoomMode = ZoomMode.FullPage
        StartPage = 0
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
            ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Private Sub _doc_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        SyncPageImages(True)
    End Sub

    Private Sub _doc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        SyncPageImages(False)
        If _cancel Then
            e.Cancel = True
        End If
    End Sub

    Public Sub Cancel()
        _cancel = True
    End Sub

    Private Function GetImage(ByVal page As Integer) As Image
        If (page > -1) AndAlso (page < PageCount) Then
            Return _img.Item(page)
        Else
            Return Nothing
        End If
    End Function

    Private Function GetImageRectangle(ByVal img As Image) As Rectangle

        Dim sz As Size = GetImageSizeInPixels(img)
        Dim rc As New Rectangle(0, 0, sz.Width, sz.Height)

        Dim rcCli As Rectangle = ClientRectangle
        Select Case _zoomMode
            Case ZoomMode.ActualSize
                _zoom = 1
                GoTo Label_00FF
            Case ZoomMode.FullPage
                Exit Select
            Case ZoomMode.PageWidth
                _zoom = CDbl(IIf((rc.Width > 0), (CDbl(rcCli.Width) / CDbl(rc.Width)), 0))
                GoTo Label_00FF
            Case ZoomMode.TwoPages
                rc.Width = (rc.Width * 2)
                Exit Select
            Case Else
                GoTo Label_00FF
        End Select
        Dim zoomX As Double = CDbl(IIf((rc.Width > 0), (CDbl(rcCli.Width) / CDbl(rc.Width)), 0))
        Dim zoomY As Double = CDbl(IIf((rc.Height > 0), (CDbl(rcCli.Height) / CDbl(rc.Height)), 0))
        _zoom = Math.Min(zoomX, zoomY)
Label_00FF:
        rc.Width = CInt((rc.Width * _zoom))
        rc.Height = CInt((rc.Height * _zoom))
        Dim dx As Integer = CInt(((rcCli.Width - rc.Width) / 2))
        If (dx > 0) Then
            rc.X = (rc.X + dx)
        End If
        Dim dy As Integer = CInt(((rcCli.Height - rc.Height) / 2))
        If (dy > 0) Then
            rc.Y = (rc.Y + dy)
        End If
        rc.Inflate(-4, -4)
        If (_zoomMode = ZoomMode.TwoPages) Then
            rc.Inflate(-2, 0)
        End If
        Return rc
    End Function

    Private Function GetImageSizeInPixels(ByVal img As Image) As Size
        Dim szf As SizeF = img.PhysicalDimension
        If TypeOf img Is Metafile Then
            If (_himm2pix.X < 0.0!) Then
                Using g As Graphics = CreateGraphics()
                    _himm2pix.X = (g.DpiX / 2540.0!)
                    _himm2pix.Y = (g.DpiY / 2540.0!)
                End Using
            End If
            szf.Width = (szf.Width * _himm2pix.X)
            szf.Height = (szf.Height * _himm2pix.Y)
        End If
        Return Size.Truncate(szf)
    End Function

    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Prior, Keys.Next, Keys.End, Keys.Home, Keys.Left, Keys.Up, Keys.Right, Keys.Down
                Return True
        End Select
        Return MyBase.IsInputKey(keyData)
    End Function

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.Handled Then Return

        Select Case e.KeyCode

            ' arrow keys scroll or browse, depending on ZoomMode
            Case Keys.Left, Keys.Up, Keys.Right, Keys.Down

                ' browse
                If ZoomMode = ZoomMode.FullPage OrElse ZoomMode = ZoomMode.TwoPages Then
                    Select Case e.KeyCode
                        Case Keys.Left, Keys.Up
                            StartPage -= 1

                        Case Keys.Right, Keys.Down
                            StartPage += 1
                    End Select
                End If

                ' scroll
                Dim pt As Point = AutoScrollPosition
                Select Case e.KeyCode
                    Case Keys.Left
                        pt.X += 20
                    Case Keys.Right
                        pt.X -= 20
                    Case Keys.Up
                        pt.Y += 20
                    Case Keys.Down
                        pt.Y -= 20
                End Select
                AutoScrollPosition = New Point(-pt.X, -pt.Y)

                ' page up/down browse pages
            Case Keys.PageUp
                StartPage -= 1
            Case Keys.PageDown
                StartPage += 1

                ' home/end 
            Case Keys.Home
                AutoScrollPosition = Point.Empty
                StartPage = 0
            Case Keys.End
                AutoScrollPosition = Point.Empty
                StartPage = PageCount - 1

            Case Else
                Return
        End Select

        ' if we got here, the event was handled
        e.Handled = True
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If ((e.Button = MouseButtons.Left) AndAlso (AutoScrollMinSize <> Size.Empty)) Then
            Cursor = Cursors.NoMove2D
            _ptLast = New Point(e.X, e.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If (Cursor Is Cursors.NoMove2D) Then
            Dim dx As Integer = (e.X - _ptLast.X)
            Dim dy As Integer = (e.Y - _ptLast.Y)
            If ((dx <> 0) OrElse (dy <> 0)) Then
                Dim pt As Point = AutoScrollPosition
                AutoScrollPosition = New Point(-(pt.X + dx), -(pt.Y + dy))
                _ptLast = New Point(e.X, e.Y)
            End If
        End If

    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        If e.Delta <> 0 Then
            If e.Delta > 0 Then
                StartPage -= 1
            Else
                StartPage += 1
            End If
        End If

    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If ((e.Button = MouseButtons.Left) AndAlso (Cursor Is Cursors.NoMove2D)) Then
            Cursor = Cursors.Default
        End If
    End Sub

    Protected Sub OnPageCountChanged(ByVal e As EventArgs)
        RaiseEvent PageCountChanged(Me, e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim img As Image = GetImage(StartPage)
        If (Not img Is Nothing) Then
            Dim rc As Rectangle = GetImageRectangle(img)
            If ((rc.Width > 2) AndAlso (rc.Height > 2)) Then
                rc.Offset(AutoScrollPosition)
                If (_zoomMode <> ZoomMode.TwoPages) Then
                    RenderPage(e.Graphics, img, rc)
                Else
                    rc.Width = CInt(((rc.Width - 4) / 2))
                    RenderPage(e.Graphics, img, rc)
                    img = GetImage((StartPage + 1))
                    If (Not img Is Nothing) Then
                        rc = GetImageRectangle(img)
                        rc.Width = CInt(((rc.Width - 4) / 2))
                        rc.Offset((rc.Width + 4), 0)
                        RenderPage(e.Graphics, img, rc)
                    End If
                End If
            End If
        End If
        e.Graphics.FillRectangle(_backBrush, ClientRectangle)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        UpdateScrollBars()
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Sub OnStartPageChanged(ByVal e As EventArgs)
        RaiseEvent StartPageChanged(Me, e)
    End Sub

    Protected Sub OnZoomModeChanged(ByVal e As EventArgs)
        RaiseEvent ZoomModeChanged(Me, e)
    End Sub

    Public Sub Print()
        Dim ps As PrinterSettings = _doc.PrinterSettings
        Dim first As Integer = (ps.MinimumPage - 1)
        Dim last As Integer = (ps.MaximumPage - 1)
        Select Case ps.PrintRange
            Case PrintRange.AllPages
                Document.Print()
                Return
            Case PrintRange.Selection
                first = StartPage
                last = StartPage
                If (ZoomMode = ZoomMode.TwoPages) Then
                    last = Math.Min(CInt((first + 1)), CInt((PageCount - 1)))
                End If
                Exit Select
            Case PrintRange.SomePages
                first = (ps.FromPage - 1)
                last = (ps.ToPage - 1)
                Exit Select
            Case PrintRange.CurrentPage
                first = StartPage
                last = StartPage
                Exit Select
        End Select

        Dim dp As New DocumentPrinter(Me, first, last)
        dp.Print()
    End Sub

    Public Sub RefreshPreview()
        If (Not _doc Is Nothing) Then
            _img.Clear()
            Dim savePC As PrintController = _doc.PrintController
            Try
                _cancel = False
                _rendering = True
                _doc.PrintController = New PreviewPrintController
                AddHandler _doc.PrintPage, New PrintPageEventHandler(AddressOf _doc_PrintPage)
                AddHandler _doc.EndPrint, New PrintEventHandler(AddressOf _doc_EndPrint)
                _doc.Print()
            Finally
                _cancel = False
                _rendering = False
                RemoveHandler _doc.PrintPage, New PrintPageEventHandler(AddressOf _doc_PrintPage)
                RemoveHandler _doc.EndPrint, New PrintEventHandler(AddressOf _doc_EndPrint)
                _doc.PrintController = savePC
            End Try
        End If
        OnPageCountChanged(EventArgs.Empty)
        UpdatePreview()
        UpdateScrollBars()
    End Sub

    Private Sub RenderPage(ByVal g As Graphics, ByVal img As Image, ByVal rc As Rectangle)
        rc.Offset(1, 1)
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.SmoothingMode = SmoothingMode.HighQuality
        g.CompositingQuality = CompositingQuality.HighQuality
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.DrawRectangle(Pens.Black, rc)
        rc.Offset(-1, -1)
        g.FillRectangle(Brushes.White, rc)
        g.DrawImage(img, rc)
        g.DrawRectangle(Pens.Black, rc)
        rc.Width += 1
        rc.Height += 1
        g.ExcludeClip(rc)
        rc.Offset(1, 1)
        g.ExcludeClip(rc)
    End Sub

    Private Sub SyncPageImages(ByVal lastPageReady As Boolean)
        Dim pv As PreviewPrintController = DirectCast(_doc.PrintController, PreviewPrintController)
        If (Not pv Is Nothing) Then
            Dim pageInfo As PreviewPageInfo() = pv.GetPreviewPageInfo
            Dim count As Integer = CInt(IIf(lastPageReady, pageInfo.Length, (pageInfo.Length - 1)))
            Dim i As Integer
            For i = _img.Count To count - 1
                Dim img As Image = pageInfo(i).Image
                _img.Add(img)
                OnPageCountChanged(EventArgs.Empty)
                If (StartPage < 0) Then
                    StartPage = 0
                End If
                If ((i = StartPage) OrElse (i = (StartPage + 1))) Then
                    Refresh()
                End If
                Application.DoEvents()
            Next i
        End If
    End Sub

    Private Sub UpdatePreview()
        If (_startPage < 0) Then
            _startPage = 0
        End If
        If (_startPage > (PageCount - 1)) Then
            _startPage = (PageCount - 1)
        End If
        Invalidate()
    End Sub

    Private Sub UpdateScrollBars()
        Dim rc As Rectangle = Rectangle.Empty
        Dim img As Image = GetImage(StartPage)
        If (Not img Is Nothing) Then
            rc = GetImageRectangle(img)
        End If
        Dim scrollSize As New Size(0, 0)
        Select Case _zoomMode
            Case ZoomMode.ActualSize, ZoomMode.Custom
                scrollSize = New Size((rc.Width + 8), (rc.Height + 8))
                Exit Select
            Case ZoomMode.PageWidth
                scrollSize = New Size(0, (rc.Height + 8))
                Exit Select
        End Select
        If (scrollSize <> AutoScrollMinSize) Then
            AutoScrollMinSize = scrollSize
        End If
        UpdatePreview()
    End Sub


    ' Properties
    <DefaultValue(GetType(Color), "AppWorkspace")> _
    Public Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            MyBase.BackColor = value
            _backBrush = New SolidBrush(value)
        End Set
    End Property

    Public Property Document() As PrintDocument
        Get
            Return _doc
        End Get
        Set(ByVal value As PrintDocument)
            If (Not value Is _doc) Then
                _doc = value
                RefreshPreview()
            End If
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)> _
    Public ReadOnly Property IsRendering() As Boolean
        Get
            Return _rendering
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property PageCount() As Integer
        Get
            Return _img.Count
        End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property PageImages() As PageImageList
        Get
            Return _img
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property StartPage() As Integer
        Get
            Return _startPage
        End Get
        Set(ByVal value As Integer)
            If (value > (PageCount - 1)) Then
                value = (PageCount - 1)
            End If
            If (value < 0) Then
                value = 0
            End If
            If (value <> _startPage) Then
                _startPage = value
                UpdateScrollBars()
                OnStartPageChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Zoom() As Double
        Get
            Return _zoom
        End Get
        Set(ByVal value As Double)
            If ((value <> _zoom) OrElse (ZoomMode <> ZoomMode.Custom)) Then
                ZoomMode = ZoomMode.Custom
                _zoom = value
                UpdateScrollBars()
                OnZoomModeChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <DefaultValue(1)> _
    Public Property ZoomMode() As ZoomMode
        Get
            Return _zoomMode
        End Get
        Set(ByVal value As ZoomMode)
            If (value <> _zoomMode) Then
                _zoomMode = value
                UpdateScrollBars()
                OnZoomModeChanged(EventArgs.Empty)
            End If
        End Set
    End Property


    ' Fields
    Private _backBrush As Brush
    Private _cancel As Boolean
    Private _doc As PrintDocument
    Private _himm2pix As PointF = New PointF(-1.0!, -1.0!)
    Private ReadOnly _img As PageImageList = New PageImageList
    Private _ptLast As Point
    Private _rendering As Boolean
    Private _startPage As Integer
    Private _zoom As Double
    Private _zoomMode As ZoomMode
    'Private Const MARGIN As Integer = 4

    ' Nested Types
    Friend Class DocumentPrinter
        Inherits PrintDocument
        ' Methods
        Public Sub New(ByVal preview As CoolPrintPreviewControl, ByVal first As Integer, ByVal last As Integer)
            _first = first
            _last = last
            _imgList = preview.PageImages
            DefaultPageSettings = preview.Document.DefaultPageSettings
            PrinterSettings = preview.Document.PrinterSettings
        End Sub

        Protected Overrides Sub OnBeginPrint(ByVal e As PrintEventArgs)
            _index = _first
        End Sub

        Protected Overrides Sub OnPrintPage(ByVal e As PrintPageEventArgs)
            e.Graphics.PageUnit = GraphicsUnit.Display
            e.Graphics.DrawImage(_imgList.Item(_index), e.PageBounds)
            _index = _index + 1
            e.HasMorePages = (_index <= _last)
        End Sub


        ' Fields
        Private ReadOnly _first As Integer
        Private ReadOnly _imgList As PageImageList
        Private _index As Integer
        Private ReadOnly _last As Integer
    End Class
End Class


