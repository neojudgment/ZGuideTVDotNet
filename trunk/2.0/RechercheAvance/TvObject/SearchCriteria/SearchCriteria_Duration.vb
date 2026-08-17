
Namespace TVGuide
    <Serializable> _
    Public Class SearchCriteria_Duration
        Implements ISearchCriteria
        Public Enum Conditions
            IsEquals = 0
            isUpper = 1
            isLower = 2
            isBetween = 3
        End Enum
        Private ReadOnly mCond As Conditions
        Private ReadOnly mMinDuration As Integer
        Private ReadOnly mMaxDuration As Integer

        Public Sub New(cond As Conditions, MinDuration As Integer, Optional MaxDuration As Integer = 0)
            mCond = cond
            mMinDuration = MinDuration
            mMaxDuration = MaxDuration
        End Sub

#Region "ISearchCriteria Members"
        Public Function MatchesCriteria(pProg As EmissionsList) As Boolean Implements ISearchCriteria.MatchesCriteria
            Dim pDuration As Double
            If pProg.Pduration = 0 Then
                pDuration = (pProg.Pstop - pProg.Pstart).TotalMinutes
            Else
                pDuration = pProg.Pduration
            End If
            Select Case mCond
                Case Conditions.isUpper
                    If pDuration >= mMinDuration Then
                        Return True
                    End If
                Case Conditions.isLower
                    If pDuration <= mMinDuration Then
                        Return True
                    End If
                Case Conditions.IsEquals
                    If Math.Floor(pDuration) = mMinDuration Then
                        Return True
                    End If
                Case Conditions.isBetween
                    If pDuration >= mMinDuration AndAlso pDuration <= mMaxDuration Then
                        Return True
                    End If
            End Select
            Return False
        End Function
#End Region

    End Class
End Namespace