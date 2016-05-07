
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_DayOfWeek
        Implements ISearchCriteria
        Private ReadOnly mDayofWeek As DayOfWeek

        Public Sub New(dow As DayOfWeek)
            mDayofWeek = dow
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            If pProg.Pstart.DayOfWeek = mDayofWeek Then
                Return (True)
            Else
                Return (False)
            End If
        End Function

#End Region
    End Class
End Namespace
