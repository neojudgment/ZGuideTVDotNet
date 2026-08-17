

Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_Channel
        Implements ISearchCriteria
        Private ReadOnly mSearchChannel As String

        Public Sub New(chan As String)
            mSearchChannel = chan
        End Sub

#Region "ISearchCriteria Members"

        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            If pProg.ChannelId = mSearchChannel Then
                Return (True)
            Else
                Return (False)
            End If
        End Function

#End Region
    End Class
End Namespace
