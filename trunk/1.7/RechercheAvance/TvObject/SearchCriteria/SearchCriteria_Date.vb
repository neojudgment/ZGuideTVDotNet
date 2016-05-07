
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_Date
        Implements ISearchCriteria
        Public Enum DateFields
            StartTime = 0
            StopTime = 1
        End Enum

        Public Enum DateConditions
            Equals = 0
            IsEarlierThan = 1
            IsLaterThan = 2
        End Enum

        Private ReadOnly mSearchDate As DateTime
        Private ReadOnly mField As DateFields
        Private ReadOnly mCondition As DateConditions

        Public Sub New([date] As DateTime, field As DateFields, condition As DateConditions)
            'since we're only comparing dates, zero out the time values
            mSearchDate = New DateTime([date].Year, [date].Month, [date].Day, 0, 0, 0)
            mField = field
            mCondition = condition
        End Sub

        Private Function Compare([date] As DateTime) As Boolean
            Dim b As Boolean = False

            Select Case mCondition
                Case DateConditions.Equals
                    If [date].Equals(mSearchDate) Then
                        b = True
                    End If


                Case DateConditions.IsEarlierThan
                    If [date] < mSearchDate Then
                        b = True
                    End If


                Case DateConditions.IsLaterThan
                    If [date] > mSearchDate Then
                        b = True
                    End If

            End Select

            Return (b)
        End Function

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            Dim b As Boolean = False

            Select Case mField
                Case DateFields.StartTime
                    b = Compare(New DateTime(pProg.Pstart.Year, pProg.Pstart.Month, pProg.Pstart.Day, 0, 0, 0))


                Case DateFields.StopTime
                    b = Compare(New DateTime(pProg.Pstop.Year, pProg.Pstop.Month, pProg.Pstop.Day, 0, 0, 0))

            End Select

            Return (b)
        End Function

#End Region
    End Class
End Namespace
