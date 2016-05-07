


Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_Category
        Implements ISearchCriteria
        Private ReadOnly mSearchText As String

        Public Sub New(pSearchText As String)
            mSearchText = pSearchText
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            If pProg.Pcategory IsNot Nothing Then
                'Return pProg.Pcategory.Any(Function(ct) ct.Value.IndexOf(mSearchText, StringComparison.CurrentCultureIgnoreCase) >= 0)
                'For Each ct As categoryType In pProg.category
                '    If ct.Value.IndexOf(mSearchText, StringComparison.CurrentCultureIgnoreCase) >= 0 Then
                '        Return (True)
                '    End If
                'Next
                If pProg.Pcategory.IndexOf(mSearchText, StringComparison.CurrentCultureIgnoreCase) >= 0 Then
                    Return True
                End If
            End If

            Return (False)
        End Function

#End Region
    End Class
End Namespace
