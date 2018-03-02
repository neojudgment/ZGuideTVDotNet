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
Imports System.Threading
Imports System.ComponentModel
Imports TvdbLib.Data.Banner
Imports TvdbLib.Data

' ReSharper disable CheckNamespace
Namespace ZGuideTVDotNetTvdb
    ' ReSharper restore CheckNamespace

    Partial Public Class BannerControl
        Inherits UserControl

        Private _mImageList As List(Of TvdbBanner)
        Private _mIndex As Integer
        Private _mDefaultImage As Image
        Private _mButtonSize As Size
        Private _mLatestLoadingThread As Thread
        Private _mLoadingBackgroundColor As Color = Color.Transparent
        Private _mUnavailableImage As Image

        Public Delegate Sub IndexChangedHandler(ByVal [event] As EventArgs)

        Public Event IndexChanged As IndexChangedHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        <Description("Background color when loading an image")> _
        Public Property LoadingBackgroundColor() As Color
            Get
                Return _mLoadingBackgroundColor
            End Get
            Set(ByVal value As Color)
                _mLoadingBackgroundColor = value
            End Set
        End Property

        Public Property LoadingImage() As Image
            Get
                Return pbLoading.Image
            End Get
            Set(ByVal value As Image)
                pbLoading.Image = value
            End Set
        End Property

        <Description("Image that is shown when the banner has no image available")> _
        Public Property UnavailableImage() As Image
            Get
                Return _mUnavailableImage
            End Get
            Set(ByVal value As Image)
                _mUnavailableImage = value
            End Set
        End Property

        <Description("List of banner images")> _
        Friend Property BannerImages() As List(Of TvdbBanner)
            Set(ByVal value As List(Of TvdbBanner))
                _mImageList = value
                If _mImageList IsNot Nothing Then
                    If _mImageList.Count > 0 Then
                        _mIndex = 0
                        SetBannerImage(value(0))
                    End If
                    If _mImageList.Count <= 1 Then
                        cmdLeft.Visible = False
                        cmdRight.Visible = False
                    Else
                        cmdLeft.Visible = False
                        cmdRight.Visible = True
                    End If
                Else
                    panelImage.BackgroundImage = Nothing
                    cmdLeft.Visible = False
                    cmdRight.Visible = False
                End If
            End Set
            Get
                Return _mImageList
            End Get
        End Property

        Friend Property BannerImage() As TvdbBanner
            Set(ByVal value As TvdbBanner)
                If value IsNot Nothing Then
                    ' if (value == null) value = new TvdbBanner();
                    Dim list As New List(Of TvdbBanner)()
                    list.Add(value)
                    BannerImages = list
                End If
            End Set
            Get
                Return If((_mImageList IsNot Nothing AndAlso _mImageList.Count > 0), _mImageList(0), Nothing)
            End Get
        End Property

        Public Property Index() As Integer
            Get
                Return _mIndex
            End Get
            Set(ByVal value As Integer)
                If _mImageList IsNot Nothing AndAlso _mIndex >= 0 AndAlso _mIndex < _mImageList.Count Then

                    ' 14/02/2010 Si on clique en dehors de l'index (-1) dans la liste des acteurs on quitte
                    If value < 0 Then Exit Property

                    _mIndex = value
                    SetBannerImage(_mImageList(value))
                    RaiseEvent IndexChanged(New EventArgs())

                    If _mIndex >= _mImageList.Count - 1 Then
                        cmdRight.Visible = False
                    Else
                        cmdRight.Visible = True
                    End If

                    If _mIndex <= 0 Then
                        cmdLeft.Visible = False
                    Else
                        cmdLeft.Visible = True
                    End If
                End If
            End Set
        End Property

        <Description("Default Image shown when no control has no banners")> _
        Public Property DefaultImage() As Image
            Get
                Return _mDefaultImage
            End Get
            Set(ByVal value As Image)
                panelImage.BackgroundImage = value
                _mDefaultImage = value
            End Set
        End Property

        Public Property ImageSizeMode() As ImageLayout
            Get
                Return panelImage.BackgroundImageLayout
            End Get
            Set(ByVal value As ImageLayout)
                panelImage.BackgroundImageLayout = value
            End Set
        End Property

        Public ReadOnly Property ActiveImage() As Image
            Get
                If _mImageList Is Nothing OrElse _mImageList.Count = 0 Then
                    Return Nothing
                Else
                    If _
                        _mUseThumbIfPossible AndAlso _
                        _mImageList(_mIndex).GetType().BaseType Is GetType(TvdbBannerWithThumb) Then
                        If (CType(_mImageList(_mIndex), TvdbBannerWithThumb)).IsThumbLoaded Then
                            Return (CType(_mImageList(_mIndex), TvdbBannerWithThumb)).ThumbImage
                        End If
                    Else
                        If _mImageList(_mIndex).IsLoaded Then
                            Return _mImageList(_mIndex).BannerImage
                        End If
                    End If

                    Return Nothing
                End If

            End Get
        End Property

        Private Delegate Sub SetImageThreadSafeDelegate(ByVal image As Image)

        Private Sub SetImageThreadSafe(ByVal image As Image)
            If (Not InvokeRequired) Then
                Try
                    panelImage.BackgroundImage = image
                Catch ex As Exception
                    Console.WriteLine(ex.ToString())
                End Try
            Else
                Invoke(New SetImageThreadSafeDelegate(AddressOf SetImageThreadSafe), New Object() {image})
            End If
        End Sub

        Private Delegate Sub SetLoadingVisibleThreadSafeDelegate(ByVal visible As Boolean)

        Private Sub SetLoadingVisibleThreadSafe(ByVal visib As Boolean)
            If (Not InvokeRequired) Then
                Try
                    pbLoading.Visible = visib
                    If visib Then
                        BackColor = _mLoadingBackgroundColor
                        panelImage.BackColor = _mLoadingBackgroundColor
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.ToString())
                End Try
            Else
                Invoke(New SetLoadingVisibleThreadSafeDelegate(AddressOf SetLoadingVisibleThreadSafe), _
                        New Object() {visib})
            End If
        End Sub

        Public Sub ClearControl()
            _mImageList = Nothing
            _mIndex = 0
            panelImage.BackgroundImage = _mDefaultImage
            cmdLeft.Visible = False
            cmdRight.Visible = False
            pbLoading.Visible = False
        End Sub

        Private _mUseThumbIfPossible As Boolean

        <Description("Will use the thumbnail of the image if a thumbnail is available")> _
        Public Property UseThumb() As Boolean
            Get
                Return _mUseThumbIfPossible
            End Get
            Set(ByVal value As Boolean)
                _mUseThumbIfPossible = value
            End Set
        End Property

        Private Sub DoBannerLoad(ByVal param As Object)
            Dim banner As TvdbBanner = CType(param, TvdbBanner)
            Try
                If banner.BannerPath IsNot Nothing AndAlso (Not String.IsNullOrEmpty(banner.BannerPath)) Then
                    'Dim index As Integer = m_index
                    ' the basetype of the banner is TvdbBannerWithThumb, not TvdbBanner (only poster atm)
                    Dim hasThumb As Boolean = banner.GetType().BaseType Is GetType(TvdbBannerWithThumb)
                    If _mUseThumbIfPossible AndAlso hasThumb Then
                        If Not (CType(banner, TvdbBannerWithThumb)).IsThumbLoaded Then
                            SetImageThreadSafe(Nothing)
                            SetLoadingVisibleThreadSafe(True)
                            CType(banner, TvdbBannerWithThumb).LoadThumb()
                        End If
                    Else
                        If (Not banner.IsLoaded) Then
                            SetImageThreadSafe(Nothing)
                            SetLoadingVisibleThreadSafe(True)

                            ' Néo le 27/01/2012
                            Try
                                banner.LoadBanner()
                            Catch ex As Exception
                                Trace.WriteLine(DateTime.Now & " " & "Exception dans BannerControl.vb")
                                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                                Exit Sub
                            End Try
                        End If
                    End If

                    SyncLock _mLatestLoadingThread
                        If Thread.CurrentThread Is _mLatestLoadingThread Then
                            ' Console.WriteLine("Loading finished of " + banner.Id);
                            If _
                                _mUseThumbIfPossible AndAlso hasThumb AndAlso _
                                (CType(banner, TvdbBannerWithThumb)).IsThumbLoaded Then
                                SetLoadingVisibleThreadSafe(False)
                                SetImageThreadSafe((CType(banner, TvdbBannerWithThumb)).ThumbImage)
                            ElseIf banner.IsLoaded Then
                                SetLoadingVisibleThreadSafe(False)
                                SetImageThreadSafe(banner.BannerImage)
                            Else
                                SetLoadingVisibleThreadSafe(False)
                            End If
                        Else
                            Trace.WriteLine(DateTime.Now & " " & "On ne peut charger " & banner.Id & " car ce n'est pas la dernière image")
                        End If
                    End SyncLock
                Else
                    SetLoadingVisibleThreadSafe(False)
                    SetImageThreadSafe(_mUnavailableImage)
                End If
            Catch e1 As ThreadAbortException
                Trace.WriteLine(DateTime.Now & " " & "Abandon du chargement de la bannière")
            End Try
        End Sub

        Private Sub SetBannerImage(ByVal value As TvdbBanner)
            Dim imageLoader As New Thread(New ParameterizedThreadStart(AddressOf DoBannerLoad))
            _mLatestLoadingThread = imageLoader
            imageLoader.Priority = ThreadPriority.Lowest
            imageLoader.Name = "Imageloader_" & value.BannerPath
            imageLoader.Start(value)

        End Sub

        Private Sub CmdLeftClick(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click
            If _mImageList IsNot Nothing AndAlso _mImageList.Count <> 0 Then
                cmdRight.Visible = True
                _mIndex -= 1
                RaiseEvent IndexChanged(New EventArgs())
                SetBannerImage(_mImageList(_mIndex))
                If _mIndex <= 0 Then
                    cmdLeft.Visible = False
                End If
            End If
        End Sub

        Private Sub CmdRightClick(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click
            If _mImageList IsNot Nothing AndAlso _mImageList.Count <> 0 Then
                cmdLeft.Visible = True
                _mIndex += 1
                RaiseEvent IndexChanged(New EventArgs())
                SetBannerImage(_mImageList(_mIndex))
                If _mIndex >= _mImageList.Count - 1 Then
                    cmdRight.Visible = False
                End If
            End If
        End Sub

        Private Sub BannerControlSizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
            pbLoading.Left = (Width \ 2) - (pbLoading.Width \ 2)
            pbLoading.Top = (Height \ 2) - (pbLoading.Height \ 2)
            cmdLeft.Top = 0
            cmdLeft.Left = 0
            cmdRight.Top = 0
            cmdRight.Left = Width - cmdRight.Width
        End Sub

        Private Sub PanelImageSizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles panelImage.SizeChanged
            _mButtonSize = cmdRight.Size
        End Sub

        Private Sub CmdRightMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdRight.MouseDown
            cmdRight.Size = New Size(_mButtonSize.Width - 1, _mButtonSize.Height - 1)
        End Sub

        Private Sub CmdRightMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdRight.MouseUp
            cmdRight.Size = _mButtonSize
        End Sub

        Private Sub CmdLeftMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdLeft.MouseDown
            cmdLeft.Size = New Size(_mButtonSize.Width - 1, _mButtonSize.Height - 1)
        End Sub

        Private Sub CmdLeftMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdLeft.MouseUp
            cmdLeft.Size = _mButtonSize
        End Sub
    End Class
End Namespace
