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
Imports TvdbLib.Data.Banner

' ReSharper disable CheckNamespace
Namespace ZGuideTVDotNetTvdb
    ' ReSharper restore CheckNamespace

    Friend Class SeasonTag
        Private _mBannerList As List(Of TvdbSeasonBanner)
        Private _mSeasonNumber As Integer
        Private _mSeasonId As Integer
        Private _mSelectedBanner As TvdbSeasonBanner
        Private _mSelectedBannerWide As TvdbSeasonBanner

#Region "Property"

        Public Property SelectedBannerWide() As TvdbSeasonBanner
            Get
                Return _mSelectedBannerWide
            End Get
            Set(ByVal value As TvdbSeasonBanner)
                _mSelectedBannerWide = value
            End Set
        End Property

        Public Property SelectedBanner() As TvdbSeasonBanner
            Get
                Return _mSelectedBanner
            End Get
            Set(ByVal value As TvdbSeasonBanner)
                _mSelectedBanner = value
            End Set
        End Property

        Public Property SeasonId() As Integer
            Get
                Return _mSeasonId
            End Get
            Set(ByVal value As Integer)
                _mSeasonId = value
            End Set
        End Property

        Friend Property SeasonNumber() As Integer
            Get
                Return _mSeasonNumber
            End Get
            Set(ByVal value As Integer)
                _mSeasonNumber = value
            End Set
        End Property

        Friend Property BannerList() As List(Of TvdbSeasonBanner)
            Get
                Return _mBannerList
            End Get
            Set(ByVal value As List(Of TvdbSeasonBanner))
                _mBannerList = value
            End Set
        End Property

#End Region

        Friend Sub New(ByVal season As Integer, ByVal seasonId As Integer, _
                        ByVal bannerList As List(Of TvdbSeasonBanner))
            _mBannerList = bannerList
            _mSeasonNumber = season
            _mSeasonId = seasonId
        End Sub
    End Class
End Namespace
