
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_Time
        Implements ISearchCriteria
        Public Enum TimeFields
            StartTime = 0
            StopTime = 1
        End Enum

        Public Enum TimeConditions
            Equals = 0
            IsEarlierThan = 1
            IsLaterThan = 2
        End Enum

        Private mSearchTime As DateTime
        Private ReadOnly mField As TimeFields
        Private ReadOnly mCondition As TimeConditions

        Public Sub New(time As DateTime, field As TimeFields, condition As TimeConditions)
            mSearchTime = time
            mField = field
            mCondition = condition
        End Sub

        Private Function Compare([date] As DateTime) As Boolean
            Dim b As Boolean = False

            Select Case mCondition
                Case TimeConditions.Equals
                    If [date].Equals(mSearchTime) Then
                        b = True
                    End If
                Case TimeConditions.IsEarlierThan
                    If [date] <= mSearchTime Then
                        b = True
                    End If
                Case TimeConditions.IsLaterThan
                    If [date] >= mSearchTime Then
                        b = True
                    End If
            End Select

            Return (b)
        End Function

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            Dim TimeToCompare As DateTime = DateTime.Now

            'make the date fields identical to our search value so that we only end up comparing times
            Select Case mField
                Case TimeFields.StartTime
                    TimeToCompare = New DateTime(mSearchTime.Year, mSearchTime.Month, mSearchTime.Day, pProg.Pstart.Hour, pProg.Pstart.Minute, pProg.Pstart.Second)


                Case TimeFields.StopTime
                    TimeToCompare = New DateTime(mSearchTime.Year, mSearchTime.Month, mSearchTime.Day, pProg.Pstop.Hour, pProg.Pstop.Minute, pProg.Pstop.Second)

            End Select

            Return (Compare(TimeToCompare))
        End Function

#End Region
    End Class
End Namespace
