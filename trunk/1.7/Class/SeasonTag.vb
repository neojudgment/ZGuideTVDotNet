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
Imports TvdbLib.Data.Banner

' ReSharper disable CheckNamespace
Namespace ZGuideTVDotNetTvdb
    ' ReSharper restore CheckNamespace

    Friend Class SeasonTag

#Region "Property"

        Public Property SelectedBannerWide As TvdbSeasonBanner

        Public Property SelectedBanner As TvdbSeasonBanner

        Public Property SeasonId As Integer

        Friend Property SeasonNumber As Integer

        Friend Property BannerList As List(Of TvdbSeasonBanner)

#End Region

        Friend Sub New(ByVal season As Integer, ByVal seasonId As Integer, ByVal bannerList As List(Of TvdbSeasonBanner))
            Me.BannerList = bannerList
            SeasonNumber = season
            Me.SeasonId = seasonId
        End Sub
    End Class
End Namespace
