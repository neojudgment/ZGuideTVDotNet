
Imports System.Linq

Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_OrCondition
        Implements ISearchCriteria
        Private ReadOnly _Criteria As ISearchCriteria() = Nothing

        Public Sub New(Criteria As ISearchCriteria())
            _Criteria = Criteria
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            Return _Criteria.Any(Function(isc) isc.MatchesCriteria(pProg))
            'For Each isc As ISearchCriteria In _Criteria
            '    If isc.MatchesCriteria(pProg) Then
            '        Return (True)
            '    End If
            'Next
        End Function

#End Region
    End Class
End Namespace
