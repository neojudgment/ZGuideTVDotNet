
Namespace TVGuide
	Public Class SearchCriteria_IsOnNow
		Implements ISearchCriteria
		Public Sub New()
		End Sub

		#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            Dim Today As DateTime = DateTime.Now
            If pProg.Pstart <= Today AndAlso pProg.Pstop >= Today Then
                Return (True)
            Else
                Return (False)
            End If
        End Function

		#End Region
	End Class
End Namespace
