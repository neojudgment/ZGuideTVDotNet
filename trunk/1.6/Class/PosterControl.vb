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
Imports System.Threading
Imports TvdbLib.Data.Banner

' ReSharper disable CheckNamespace
Namespace ZGuideTVDotNetTvdb
    ' ReSharper restore CheckNamespace

    Partial Public Class PosterControl
        Inherits UserControl
        Private m_imageList As List(Of TvdbPosterBanner)
        Private m_index As Integer
        Private m_buttonSizeLeft As Size
        Private m_buttonSizeRight As Size

        Public Sub New()
            InitializeComponent()
        End Sub

        <Description("My Description")> _
        Friend WriteOnly Property PosterImages() As List(Of TvdbPosterBanner)
            Set(ByVal value As List(Of TvdbPosterBanner))
                m_imageList = value
                If m_imageList IsNot Nothing Then
                    If m_imageList.Count > 0 Then
                        m_index = 0
                        SetPosterImage(value(0))
                    End If
                    If m_imageList.Count <= 1 Then
                        panelLeft.Visible = False
                        panelRight.Visible = False
                    Else
                        panelLeft.Visible = False
                        panelRight.Visible = True
                    End If
                Else
                    panelImage.BackgroundImage = Nothing
                    panelLeft.Visible = False
                    panelRight.Visible = False
                End If

            End Set
        End Property

        Public ReadOnly Property ActiveImage() As Image
            Get
                If m_imageList Is Nothing OrElse m_imageList.Count = 0 OrElse (Not m_imageList(m_index).IsLoaded) Then
                    Return Nothing
                End If
                Return m_imageList(m_index).BannerImage
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
                    pbLoadingScreen.Visible = _visible
                Catch ex As Exception
                    Console.WriteLine(ex.ToString())
                End Try
            Else
                Invoke(New SetLoadingVisibleThreadSafeDelegate(AddressOf SetLoadingVisibleThreadSafe), _
                        New Object() {_visible})
            End If
        End Sub

        Public Sub ClearPoster()
            panelImage.BackgroundImage = Nothing
            m_imageList = Nothing
            m_index = 0
            panelLeft.Visible = False
            panelRight.Visible = False
        End Sub

        Private Sub DoPosterLoad(ByVal _param As Object)
            Dim banner As TvdbPosterBanner = CType(_param, TvdbPosterBanner)

            Dim index As Integer = m_index
            If (Not banner.IsLoaded) Then
                SetImageThreadSafe(Nothing)
                SetLoadingVisibleThreadSafe(True)
                banner.LoadBanner()
            End If

            If banner.IsLoaded AndAlso index = m_index Then
                SetLoadingVisibleThreadSafe(False)
                SetImageThreadSafe(CreatePosterBitmap(banner.BannerImage))
            End If

        End Sub

        Private Sub SetPosterImage(ByVal _value As TvdbPosterBanner)
            CType(New Thread(New ParameterizedThreadStart(AddressOf DoPosterLoad)), Thread).Start(_value)

        End Sub

        Private Function CreatePosterBitmap(ByVal _image As Image) As Bitmap
            Dim bm As New Bitmap(Width, Height)
            Dim g As Graphics = Graphics.FromImage(bm)
            g.Clear(Color.Transparent)
            g.DrawImage(_image, _
                         New RectangleF(CSng(bm.Width * 0.15), CSng(bm.Height * 0.07), CSng(bm.Width * 0.8), _
                                         CSng(bm.Height * 0.85)))
            Return bm
        End Function

        Private Sub panelRight_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) _
            Handles panelRight.MouseClick
            If m_imageList IsNot Nothing AndAlso m_imageList.Count <> 0 Then
                panelLeft.Visible = True
                m_index += 1
                SetPosterImage(m_imageList(m_index))
                If m_index >= m_imageList.Count - 1 Then
                    panelRight.Visible = False
                End If
            End If
        End Sub

        Private Sub panelLeft_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) _
            Handles panelLeft.MouseClick
            If m_imageList IsNot Nothing AndAlso m_imageList.Count <> 0 Then

                panelRight.Visible = True
                m_index -= 1
                SetPosterImage(m_imageList(m_index))
                If m_index <= 0 Then
                    panelLeft.Visible = False
                End If
            End If
        End Sub

        Private Sub panelLeft_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles panelLeft.MouseDown
            panelLeft.Size = New Size(m_buttonSizeLeft.Width - 1, m_buttonSizeLeft.Height - 1)
        End Sub

        Private Sub panelLeft_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles panelLeft.MouseUp
            panelLeft.Size = m_buttonSizeLeft
        End Sub

        Private Sub PosterControl_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
            m_buttonSizeLeft = panelLeft.Size
            m_buttonSizeRight = panelRight.Size
        End Sub

        Private Sub panelRight_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
            Handles panelRight.MouseDown
            panelRight.Size = New Size(m_buttonSizeRight.Width - 1, m_buttonSizeRight.Height - 1)
        End Sub

        Private Sub panelRight_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles panelRight.MouseUp
            panelRight.Size = m_buttonSizeRight
        End Sub
    End Class
End Namespace
