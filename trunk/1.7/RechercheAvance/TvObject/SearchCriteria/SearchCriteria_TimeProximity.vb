
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_TimeProximity
        Implements ISearchCriteria
        Private ReadOnly StartTimeProximity As TimeSpan

        Public Sub New(ts As TimeSpan)
            StartTimeProximity = ts
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            If pProg.Pstart >= DateTime.Now AndAlso pProg.Pstart - DateTime.Now <= StartTimeProximity Then
                Return (True)
            Else
                Return (False)
            End If
        End Function

#End Region
    End Class
End Namespace
