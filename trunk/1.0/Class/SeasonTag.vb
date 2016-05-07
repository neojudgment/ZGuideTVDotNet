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

Namespace ZGuideTVDotNetTvdb
    Friend Class SeasonTag
        Private m_bannerList As List(Of TvdbSeasonBanner)
        Private m_seasonNumber As Integer
        Private m_seasonId As Integer
        Private m_selectedBanner As TvdbSeasonBanner
        Private m_selectedBannerWide As TvdbSeasonBanner

#Region "Property"

        Public Property SelectedBannerWide() As TvdbSeasonBanner
            Get
                Return m_selectedBannerWide
            End Get
            Set(ByVal value As TvdbSeasonBanner)
                m_selectedBannerWide = value
            End Set
        End Property

        Public Property SelectedBanner() As TvdbSeasonBanner
            Get
                Return m_selectedBanner
            End Get
            Set(ByVal value As TvdbSeasonBanner)
                m_selectedBanner = value
            End Set
        End Property

        Public Property SeasonId() As Integer
            Get
                Return m_seasonId
            End Get
            Set(ByVal value As Integer)
                m_seasonId = value
            End Set
        End Property

        Friend Property SeasonNumber() As Integer
            Get
                Return m_seasonNumber
            End Get
            Set(ByVal value As Integer)
                m_seasonNumber = value
            End Set
        End Property

        Friend Property BannerList() As List(Of TvdbSeasonBanner)
            Get
                Return m_bannerList
            End Get
            Set(ByVal value As List(Of TvdbSeasonBanner))
                m_bannerList = value
            End Set
        End Property

#End Region

        Friend Sub New(ByVal _season As Integer, ByVal _seasonId As Integer, _
                        ByVal _bannerList As List(Of TvdbSeasonBanner))
            m_bannerList = _bannerList
            m_seasonNumber = _season
            m_seasonId = _seasonId
        End Sub
    End Class
End Namespace
