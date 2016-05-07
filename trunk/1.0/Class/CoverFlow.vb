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
Imports ZGuideTV.My.Resources
Imports TvdbLib.Data.Banner

'Imports TvdbTester.Properties

Namespace ZGuideTVDotNetTvdb
    Partial Public Class CoverFlow
        Inherits UserControl
        Private m_currentIndex As Integer
        Private pbList As List(Of PictureBox)
        Private m_items As List(Of TvdbFanartBanner)

        Friend Property Items() As List(Of TvdbFanartBanner)
            Get
                Return m_items
            End Get
            Set(ByVal value As List(Of TvdbFanartBanner))
                m_items = value
                If m_items Is Nothing Then
                    Return
                End If
                m_currentIndex = -3

                For i As Integer = 3 To 3 + m_items.Count - 1
                    If i < pbList.Count Then
                        pbList(i).Image = loading
                        pbList(i).SizeMode = PictureBoxSizeMode.Zoom
                    End If
                Next i

                CType(New Thread(New ThreadStart(AddressOf DoLoading)), Thread).Start()
            End Set
        End Property

        Public ReadOnly Property ActiveImage() As Image
            Get
                If m_items Is Nothing OrElse m_items.Count = 0 Then
                    Return Nothing
                End If
                Return pbFull.Image
            End Get
        End Property

        Public Sub Clear()
            For i As Integer = 0 To pbList.Count - 1
                pbList(i).Image = Nothing
            Next i
            If m_items IsNot Nothing Then
                m_items.Clear()
            End If
            pbFull.Image = Nothing
            Me.Tag = Nothing
        End Sub

        Private Sub DoLoading()
            For i As Integer = 0 To m_items.Count - 1
                If m_items(i).IsThumbLoaded OrElse m_items(i).LoadThumb() Then
                    If 3 + i + m_currentIndex >= 0 AndAlso i + m_currentIndex <= 0 AndAlso i < pbList.Count Then
                        SetImageThreadSafe(3 + i, m_items(3 + i + m_currentIndex).ThumbImage)
                    End If
                End If
            Next i
        End Sub

        Private Delegate Sub SetImageThreadSafeDelegate(ByVal _index As Integer, ByVal _img As Image)

        Private Sub SetImageThreadSafe(ByVal _index As Integer, ByVal _img As Image)
            If (Not InvokeRequired) Then
                Try
                    If _index > 0 AndAlso _index <= 6 Then
                        pbList(_index).Image = _img
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.ToString())
                End Try
            Else
                Invoke(New SetImageThreadSafeDelegate(AddressOf SetImageThreadSafe), New Object() {_index, _img})
            End If
        End Sub

        Public Property CurrentIndex() As Integer
            Get
                Return m_currentIndex
            End Get
            Set(ByVal value As Integer)
                m_currentIndex = value
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            pbList = New List(Of PictureBox)()

            With pbList
                .Add(pb0)
                .Add(pb1)
                .Add(pb2)
                .Add(pb3)
                .Add(pb4)
                .Add(pb5)
                .Add(pb6)
            End With

            AddHandler pnlThumbOverview.MouseWheel, AddressOf pnlThumbOverview_MouseWheel
            AddHandler MouseWheel, AddressOf pnlThumbOverview_MouseWheel
        End Sub

        Public Sub SetNext()
            If m_items Is Nothing Then
                Return
            End If
            If m_currentIndex < m_items.Count - 4 Then
                m_currentIndex += 1
                ReloadBitmaps()
            End If
        End Sub

        Public Sub SetPrevious()
            If m_items Is Nothing Then
                Return
            End If
            If m_currentIndex >= -2 Then
                m_currentIndex -= 1
                ReloadBitmaps()
            End If
        End Sub

        Private Sub pnlThumbOverview_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
            Console.WriteLine(e.Delta)
            'throw new NotImplementedException();
        End Sub

        Private Sub ReloadBitmaps()
            If m_items Is Nothing Then
                Return
            End If
            For i As Integer = 0 To pbList.Count - 1
                If i + m_currentIndex >= 0 AndAlso i + m_currentIndex < m_items.Count Then
                    Dim imageIndex As Integer = m_currentIndex + i
                    If i = 3 Then
                        'int rating = m_items[imageIndex].rat
                    End If
                    If m_items(imageIndex).IsThumbLoaded Then
                        pbList(i).SizeMode = PictureBoxSizeMode.Zoom
                        pbList(i).Image = m_items(imageIndex).ThumbImage
                    ElseIf pbList(i).Image Is Nothing Then
                        pbList(i).SizeMode = PictureBoxSizeMode.Zoom
                        pbList(i).Image = loading
                    End If
                Else
                    pbList(i).Image = Nothing
                End If
            Next i

        End Sub

        Private Sub pb0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pb0.Click
            If m_items Is Nothing Then
                Return
            End If
            If m_currentIndex >= 0 Then
                m_currentIndex -= 3
                ReloadBitmaps()
            End If
        End Sub

        Private Sub pb1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pb1.Click
            If m_items Is Nothing Then
                Return
            End If
            If m_currentIndex >= -1 Then
                m_currentIndex -= 2
                ReloadBitmaps()
            End If
        End Sub

        Private Sub pb2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pb2.Click
            If m_items Is Nothing Then
                Return
            End If
            If m_currentIndex >= -2 Then
                m_currentIndex -= 1
                ReloadBitmaps()
            End If
        End Sub

        Private Sub pb4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pb4.Click
            If m_items Is Nothing Then
                Return
            End If
            If m_currentIndex < m_items.Count - 4 Then
                m_currentIndex += 1
                ReloadBitmaps()
            End If
        End Sub

        Private Sub pb5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pb5.Click
            If m_items Is Nothing Then
                Return
            End If
            If m_currentIndex < m_items.Count - 5 Then
                m_currentIndex += 2
                ReloadBitmaps()
            End If
        End Sub

        Private Sub pb6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pb6.Click
            If m_items Is Nothing Then
                Return
            End If
            If m_currentIndex < m_items.Count - 6 Then
                m_currentIndex += 3
                ReloadBitmaps()
            End If
        End Sub

        Private Sub pb3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pb3.Click
            If m_items Is Nothing Then
                Return
            End If
            Dim banner As TvdbFanartBanner = m_items(m_currentIndex + 3)
            If banner.IsLoaded OrElse banner.LoadBanner() Then
                pbFull.Image = banner.BannerImage
            Else
                pbFull.Image = pbFull.ErrorImage
            End If
        End Sub

        Private Sub pnlThumbOverview_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) _
            Handles pnlThumbOverview.MouseClick

        End Sub

        Private Sub CoverFlow_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
            Console.Write("x")
            Dim oldPos As Integer = 20
            Dim widthFactor As Integer = CInt((Me.Width - 30) / 16)

            For i As Integer = 0 To CInt((pbList.Count - 1) / 2)
                pbList(i).Left = oldPos
                pbList(i).Width = widthFactor * (i + 1)
                oldPos = oldPos + pbList(i).Width
            Next i

            For i As Integer = CInt((pbList.Count - 1) / 2 + 1) To pbList.Count - 1
                pbList(i).Left = oldPos
                pbList(i).Width = pbList(pbList.Count - i - 1).Width
                oldPos = oldPos + pbList(i).Width
            Next i
        End Sub
    End Class
End Namespace
