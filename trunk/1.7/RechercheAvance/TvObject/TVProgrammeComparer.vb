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

Imports System.Collections

Namespace TVGuide
    ''' <summary>
    ''' Generic app wide comparer class used to compare various objects used througout the program
    ''' </summary>
    Public Class TVProgrammeComparer
        Implements IComparer
        Public Enum ETVProgrammeSortBy
            StartTime
            StopTime
            Title
            Channel
            Category
        End Enum
        Public Enum ETVProgrammeSortMode
            Ascending
            Descending
        End Enum

        Private mSortBy As ETVProgrammeSortBy
        Private mSortMode As ETVProgrammeSortMode

#Region "Constructors"

        Public Sub New()
            mSortBy = ETVProgrammeSortBy.StartTime
            mSortMode = ETVProgrammeSortMode.Descending
        End Sub

#End Region

#Region "Properties"

        Public Property SortBy() As ETVProgrammeSortBy
            Get
                Return (mSortBy)
            End Get
            Set(value As ETVProgrammeSortBy)
                mSortBy = value
            End Set
        End Property

        Public Property SortMode() As ETVProgrammeSortMode
            Get
                Return (mSortMode)
            End Get
            Set(value As ETVProgrammeSortMode)
                mSortMode = value
            End Set
        End Property

#End Region

#Region "IComparer Members"

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Return (Compare_Programme(DirectCast(x, EmissionsList), DirectCast(y, EmissionsList)))
        End Function

        Public Function Compare_Programme(x As EmissionsList, y As EmissionsList) As Integer
            Select Case mSortBy
                Case ETVProgrammeSortBy.StartTime
                    If mSortMode = ETVProgrammeSortMode.Descending Then
                        Return (y.Pstart.CompareTo(x.Pstart))
                    Else
                        Return (x.Pstart.CompareTo(y.Pstart))
                    End If

                Case ETVProgrammeSortBy.StopTime
                    If mSortMode = ETVProgrammeSortMode.Descending Then
                        Return (y.Pstop.CompareTo(x.Pstop))
                    Else
                        Return (x.Pstop.CompareTo(y.Pstop))
                    End If

                Case ETVProgrammeSortBy.Title
                    If mSortMode = ETVProgrammeSortMode.Descending Then
                        Return (y.Ptitle.CompareTo(x.Ptitle))
                    Else
                        Return (x.Ptitle.CompareTo(y.Ptitle))
                    End If

                Case ETVProgrammeSortBy.Channel
                    'If mSortMode = ETVProgrammeSortMode.Descending Then
                    '    Return (y.ChannelId.CompareTo(x.ChannelId))
                    'Else
                    '    Return (x.ChannelId.CompareTo(y.ChannelId))
                    'End If

                    With TVGuideMainForm.ListingsOrganizer
                        If mSortMode = ETVProgrammeSortMode.Descending Then
                            Return (.AllChannels(y.ChannelId).Ordering.CompareTo(.AllChannels(x.ChannelId).Ordering))
                        Else
                            Return (.AllChannels(x.ChannelId).Ordering.CompareTo(.AllChannels(y.ChannelId).Ordering))
                        End If
                    End With

                Case ETVProgrammeSortBy.Category
                    If mSortMode = ETVProgrammeSortMode.Descending Then
                        Return (y.PcategoryTv.CompareTo(x.PcategoryTv))
                    Else
                        Return (x.PcategoryTv.CompareTo(y.PcategoryTv))
                    End If
            End Select

            Return (0)
        End Function

#End Region
    End Class
End Namespace
