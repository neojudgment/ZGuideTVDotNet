
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteriaDecorator_NegateMatching
        Implements ISearchCriteria
        Private ReadOnly mSearchCriteria As ISearchCriteria

        Public Sub New(obj As ISearchCriteria)
            mSearchCriteria = obj
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            Return Not (mSearchCriteria.MatchesCriteria(pProg))
        End Function

#End Region
    End Class
End Namespace
