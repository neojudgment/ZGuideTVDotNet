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
Imports System.Threading
Imports System.ComponentModel
Imports TvdbLib.Data.Banner
Imports TvdbLib.Data

Namespace ZGuideTVDotNetTvdb
    Partial Public Class BannerControl
        Inherits UserControl

        Private m_imageList As List(Of TvdbBanner)
        Private m_index As Integer
        Private m_defaultImage As Image
        Private m_buttonSize As Size
        Private m_latestLoadingThread As Thread
        Private m_loadingBackgroundColor As Color = Color.Transparent
        Private m_unavailableImage As Image

        Public Delegate Sub IndexChangedHandler(ByVal _event As EventArgs)

        Public Event IndexChanged As IndexChangedHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        <Description("Background color when loading an image")> _
        Public Property LoadingBackgroundColor() As Color
            Get
                Return m_loadingBackgroundColor
            End Get
            Set(ByVal value As Color)
                m_loadingBackgroundColor = value
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
                Return m_unavailableImage
            End Get
            Set(ByVal value As Image)
                m_unavailableImage = value
            End Set
        End Property

        <Description("List of banner images")> _
        Friend Property BannerImages() As List(Of TvdbBanner)
            Set(ByVal value As List(Of TvdbBanner))
                m_imageList = value
                If m_imageList IsNot Nothing Then
                    If m_imageList.Count > 0 Then
                        m_index = 0
                        SetBannerImage(value(0))
                    End If
                    If m_imageList.Count <= 1 Then
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
                Return m_imageList
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
                Return If((m_imageList IsNot Nothing AndAlso m_imageList.Count > 0), m_imageList(0), Nothing)
            End Get
        End Property

        Public Property Index() As Integer
            Get
                Return m_index
            End Get
            Set(ByVal value As Integer)
                If m_imageList IsNot Nothing AndAlso m_index >= 0 AndAlso m_index < m_imageList.Count Then

                    ' 14/02/2010 Si on clique en dehors de l'index (-1) dans la liste des acteurs on quitte
                    If value < 0 Then Exit Property

                    m_index = value
                    SetBannerImage(m_imageList(value))
                    RaiseEvent IndexChanged(New EventArgs())

                    If m_index >= m_imageList.Count - 1 Then
                        cmdRight.Visible = False
                    Else
                        cmdRight.Visible = True
                    End If

                    If m_index <= 0 Then
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
                Return m_defaultImage
            End Get
            Set(ByVal value As Image)
                panelImage.BackgroundImage = value
                m_defaultImage = value
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
                If m_imageList Is Nothing OrElse m_imageList.Count = 0 Then
                    Return Nothing
                Else
                    If _
                        m_useThumbIfPossible AndAlso _
                        m_imageList(m_index).GetType().BaseType Is GetType(TvdbBannerWithThumb) Then
                        If (CType(m_imageList(m_index), TvdbBannerWithThumb)).IsThumbLoaded Then
                            Return (CType(m_imageList(m_index), TvdbBannerWithThumb)).ThumbImage
                        End If
                    Else
                        If m_imageList(m_index).IsLoaded Then
                            Return m_imageList(m_index).BannerImage
                        End If
                    End If

                    Return Nothing
                End If

            End Get
        End Property

        Private Delegate Sub SetImageThreadSafeDelegate(ByVal _image As Image)

        Private Sub SetImageThreadSafe(ByVal _image As Image)
            If (Not InvokeRequired) Then
                Try
                    panelImage.BackgroundImage = _image
                Catch ex As Exception
                    Console.WriteLine(ex.ToString())
                End Try
            Else
                Invoke(New SetImageThreadSafeDelegate(AddressOf SetImageThreadSafe), New Object() {_image})
            End If
        End Sub

        Private Delegate Sub SetLoadingVisibleThreadSafeDelegate(ByVal _visible As Boolean)

        Private Sub SetLoadingVisibleThreadSafe(ByVal _visible As Boolean)
            If (Not InvokeRequired) Then
                Try
                    pbLoading.Visible = _visible
                    If _visible Then
                        Me.BackColor = m_loadingBackgroundColor
                        panelImage.BackColor = m_loadingBackgroundColor
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.ToString())
                End Try
            Else
                Invoke(New SetLoadingVisibleThreadSafeDelegate(AddressOf SetLoadingVisibleThreadSafe), _
                        New Object() {_visible})
            End If
        End Sub

        Public Sub ClearControl()
            m_imageList = Nothing
            m_index = 0
            panelImage.BackgroundImage = m_defaultImage
            cmdLeft.Visible = False
            cmdRight.Visible = False
            pbLoading.Visible = False
        End Sub

        Private m_useThumbIfPossible As Boolean

        <Description("Will use the thumbnail of the image if a thumbnail is available")> _
        Public Property UseThumb() As Boolean
            Get
                Return m_useThumbIfPossible
            End Get
            Set(ByVal value As Boolean)
                m_useThumbIfPossible = value
            End Set
        End Property

        Private Sub DoBannerLoad(ByVal _param As Object)
            Dim banner As TvdbBanner = CType(_param, TvdbBanner)
            Try
                If banner.BannerPath IsNot Nothing AndAlso (Not String.IsNullOrEmpty(banner.BannerPath)) Then
                    'Dim index As Integer = m_index
                    ' the basetype of the banner is TvdbBannerWithThumb, not TvdbBanner (only poster atm)
                    Dim hasThumb As Boolean = banner.GetType().BaseType Is GetType(TvdbBannerWithThumb)
                    If m_useThumbIfPossible AndAlso hasThumb Then
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

                    SyncLock m_latestLoadingThread
                        If Thread.CurrentThread Is m_latestLoadingThread Then
                            ' Console.WriteLine("Loading finished of " + banner.Id);
                            If _
                                m_useThumbIfPossible AndAlso hasThumb AndAlso _
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
                    SetImageThreadSafe(m_unavailableImage)
                End If
            Catch e1 As ThreadAbortException
                Trace.WriteLine(DateTime.Now & " " & "Abandon du chargement de la bannière")
            End Try
        End Sub

        Private Sub SetBannerImage(ByVal _value As TvdbBanner)
            Dim imageLoader As New Thread(New ParameterizedThreadStart(AddressOf DoBannerLoad))
            m_latestLoadingThread = imageLoader
            imageLoader.Priority = ThreadPriority.Lowest
            imageLoader.Name = "Imageloader_" & _value.BannerPath
            imageLoader.Start(_value)

        End Sub

        Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click
            If m_imageList IsNot Nothing AndAlso m_imageList.Count <> 0 Then
                cmdRight.Visible = True
                m_index -= 1
                RaiseEvent IndexChanged(New EventArgs())
                SetBannerImage(m_imageList(m_index))
                If m_index <= 0 Then
                    cmdLeft.Visible = False
                End If
            End If
        End Sub

        Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click
            If m_imageList IsNot Nothing AndAlso m_imageList.Count <> 0 Then
                cmdLeft.Visible = True
                m_index += 1
                RaiseEvent IndexChanged(New EventArgs())
                SetBannerImage(m_imageList(m_index))
                If m_index >= m_imageList.Count - 1 Then
                    cmdRight.Visible = False
                End If
            End If
        End Sub

        Private Sub BannerControl_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
            pbLoading.Left = (Me.Width \ 2) - (pbLoading.Width \ 2)
            pbLoading.Top = (Me.Height \ 2) - (pbLoading.Height \ 2)
            cmdLeft.Top = 0
            cmdLeft.Left = 0
            cmdRight.Top = 0
            cmdRight.Left = Me.Width - cmdRight.Width
        End Sub

        Private Sub panelImage_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles panelImage.SizeChanged
            m_buttonSize = cmdRight.Size
        End Sub

        Private Sub cmdRight_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdRight.MouseDown
            cmdRight.Size = New Size(m_buttonSize.Width - 1, m_buttonSize.Height - 1)
        End Sub

        Private Sub cmdRight_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdRight.MouseUp
            cmdRight.Size = m_buttonSize
        End Sub

        Private Sub cmdLeft_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdLeft.MouseDown
            cmdLeft.Size = New Size(m_buttonSize.Width - 1, m_buttonSize.Height - 1)
        End Sub

        Private Sub cmdLeft_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdLeft.MouseUp
            cmdLeft.Size = m_buttonSize
        End Sub
    End Class
End Namespace
