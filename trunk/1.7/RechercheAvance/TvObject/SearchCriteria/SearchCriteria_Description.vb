
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_Description
        Implements ISearchCriteria
        Private ReadOnly mSearchText As String

        Public Sub New(pSearchText As String)
            mSearchText = pSearchText
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            If pProg.Pdescription.IndexOf(mSearchText, StringComparison.CurrentCultureIgnoreCase) >= 0 Then
                Return (True)
            Else
                Return (False)
            End If
        End Function

#End Region
    End Class
End Namespace
