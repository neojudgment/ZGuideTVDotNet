
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_DateRange
        Implements ISearchCriteria
        Private mStart As DateTime
        Private mEnd As DateTime

        Public Sub New(pStart As DateTime, pEnd As DateTime)
            mStart = pStart
            mEnd = pEnd
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            If pProg.Pstart.DayOfYear >= mStart.DayOfYear AndAlso pProg.Pstart.DayOfYear <= mEnd.DayOfYear Then
                Return (True)
            Else
                Return (False)
            End If
        End Function

#End Region
    End Class
End Namespace
