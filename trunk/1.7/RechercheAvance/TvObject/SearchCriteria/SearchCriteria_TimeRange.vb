
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_TimeRange
        Implements ISearchCriteria
        Public Enum Fields
            StartTime = 0
            StopTime = 1
        End Enum

        Private ReadOnly mField As Fields
        Private mStart As DateTime
        Private mEnd As DateTime

        Public Sub New(field As Fields, pStart As DateTime, pEnd As DateTime)
            mField = field
            mStart = pStart
            mEnd = pEnd
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            Select Case mField
                Case Fields.StartTime
                    'If pProg.Pstart.TimeOfDay >= mStart.TimeOfDay AndAlso pProg.Pstart.TimeOfDay <= mEnd.TimeOfDay Then
                    '    Return (True)
                    'End If

                    If (mStart.TimeOfDay <= mEnd.TimeOfDay) Then
                        Return mStart.TimeOfDay <= pProg.Pstart.TimeOfDay AndAlso pProg.Pstart.TimeOfDay <= mEnd.TimeOfDay
                    Else
                        Return mStart.TimeOfDay <= pProg.Pstart.TimeOfDay OrElse pProg.Pstart.TimeOfDay <= mEnd.TimeOfDay
                    End If



                Case Fields.StopTime
                    'If pProg.Pstop.TimeOfDay >= mStart.TimeOfDay AndAlso pProg.Pstop.TimeOfDay <= mEnd.TimeOfDay Then
                    '    Return (True)
                    'End If
                    If (mStart.TimeOfDay <= mEnd.TimeOfDay) Then
                        Return mStart.TimeOfDay <= pProg.Pstop.TimeOfDay AndAlso pProg.Pstop.TimeOfDay <= mEnd.TimeOfDay
                    Else
                        Return mStart.TimeOfDay <= pProg.Pstop.TimeOfDay OrElse pProg.Pstop.TimeOfDay <= mEnd.TimeOfDay
                    End If

            End Select

            Return (False)
        End Function

#End Region
    End Class
End Namespace
