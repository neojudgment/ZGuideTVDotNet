' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2016 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

Imports System.Windows.Forms

Public Enum SearchCriteria
    ByTextField = 0
    ByCategory = 1
    ByChannel = 2
    ByDate = 3
    ByTime = 4
    ByDuration = 5
    ByDayOfWeek = 6
    ByDateRange = 7
    ByTimeRange = 8
    IsOnToday = 9
    EstActuellement = 10
    ByTimeProximity = 11
    OrCondition = 12
End Enum

Public NotInheritable Class AdvancedSearchFactory
    Private Sub New()
    End Sub
    Public Shared Function CreateAdvancedSearchUc(sc As SearchCriteria) As UserControl
        Dim uc As UserControl '= Nothing

        Select Case sc
            Case SearchCriteria.ByTextField
                uc = New AdvancedSearch_TextFields()
            Case SearchCriteria.ByCategory
                uc = New AdvancedSearch_Category(TVGuideMainForm.ListingsOrganizer.AllCategories)
            Case SearchCriteria.ByChannel
                uc = New AdvancedSearch_Channel(TVGuideMainForm.ListingsOrganizer.AllChannels)
            Case SearchCriteria.ByDate
                uc = New AdvancedSearch_Date()
            Case SearchCriteria.ByTime
                uc = New AdvancedSearch_Time()
            Case SearchCriteria.ByDuration
                uc = New AdvancedSearch_Duration()
            Case SearchCriteria.ByDayOfWeek
                uc = New AdvancedSearch_DayOfWeek()
            Case SearchCriteria.ByDateRange
                uc = New AdvancedSearch_DateRange()
            Case SearchCriteria.ByTimeRange
                uc = New AdvancedSearch_TimeRange()
            Case SearchCriteria.IsOnToday
                uc = New AdvancedSearch_OnToday()
            Case SearchCriteria.EstActuellement
                uc = New AdvancedSearch_Actuellement
            Case SearchCriteria.ByTimeProximity
                uc = New AdvancedSearch_TimeProximity()
            Case SearchCriteria.OrCondition
                uc = New AdvancedSearch_OrCondition()
            Case Else
                Throw New Exception("Invalid search criteria type!")
        End Select

        Return (uc)
    End Function
End Class
