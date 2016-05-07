' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2016 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
' |                                                                                                            |
' |    Project administrator : Pascal Hubert (neojudgment@hotmail.com)                                         |
' |                                                                                                            |
' |    This program is free software: you can redistribute it and/or modify                                    |
' |    it under the terms of the Microsoft Reciprocal License (MS-RL)                                          |
' |                                                                                                            |
' |    This program is distributed in the hope that it will be useful,                                         |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of                                          |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.                                                    |
' |                                                                                                            |
' |                                                                                                            |
' |    You should have received a copy of the MS-RL License                                                    |
' |    along with this program.  If not, see <https://opensource.org/licenses/MS-RL>.                          |
' |                                                                                                            |
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•

Imports System.Collections

Namespace TVGuide
	Public NotInheritable Class StringLogicalComparer
		Implements IComparer
		Private Shared ReadOnly _default As IComparer = New StringLogicalComparer()
        'Private Shared ReadOnly _defaultZeroesFirst As IComparer = New StringLogicalComparer(True)
        Private Const _zeroesFirst As Boolean = False

        Private Sub New()
        End Sub

        'Private Sub New(zeroesFirst As Boolean)
        '    Me._zeroesFirst = zeroesFirst
        'End Sub

        Public Shared ReadOnly Property [Default]() As IComparer
            Get
                Return _default
            End Get
        End Property

        'Public Shared ReadOnly Property DefaultZeroesFirst() As IComparer
        '	Get
        '		Return _defaultZeroesFirst
        '	End Get
        'End Property

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            If x Is Nothing AndAlso y Is Nothing Then
                Return 0
            End If
            If x Is Nothing Then
                Return -1
            End If
            If y Is Nothing Then
                Return 1
            End If
            If TypeOf x Is String AndAlso TypeOf y Is String Then
                Return Compare(DirectCast(x, String), DirectCast(y, String), _zeroesFirst)
            End If
            Return Comparer.[Default].Compare(x, y)
        End Function

		Public Shared Function Compare(s1 As String, s2 As String) As Integer
			Return Compare(s1, s2, False)
		End Function

		Public Shared Function Compare(s1 As String, s2 As String, zeroesFirst As Boolean) As Integer
			'get rid of special cases
			If (s1 Is Nothing) AndAlso (s2 Is Nothing) Then
				Return 0
			ElseIf s1 Is Nothing Then
				Return -1
			ElseIf s2 Is Nothing Then
				Return 1
			End If

			If (s1.Length <= 0) AndAlso (s2.Length <= 0) Then
				Return 0
			ElseIf s1.Length <= 0 Then
				Return -1
			ElseIf s2.Length <= 0 Then
				Return 1
			End If

			'special case
			Dim sp1 As Boolean = Char.IsLetterOrDigit(s1(0))
			Dim sp2 As Boolean = Char.IsLetterOrDigit(s2(0))
			If sp1 AndAlso Not sp2 Then Return 1		
			If Not sp1 AndAlso sp2 Then Return -1
				
			Dim i1 As Integer = 0, i2 As Integer = 0'current index
            Dim r As Integer '= 0' temp result
			Dim c1 As Char, c2 As Char
			Dim letter1 As Boolean, letter2 As Boolean

			While True
				c1 = s1(i1)
				c2 = s2(i2)
				sp1 = [Char].IsDigit(c1)
				sp2 = [Char].IsDigit(c2)
				If Not sp1 AndAlso Not sp2 Then
					letter1 = [Char].IsLetter(c1)
					letter2 = [Char].IsLetter(c2)

					If letter1 AndAlso letter2 Then
						r = [Char].ToUpper(c1).CompareTo([Char].ToUpper(c2))
						If r <> 0 Then
							Return r
						End If
					ElseIf Not letter1 AndAlso Not letter2 Then
						r = c1.CompareTo(c2)
						If r <> 0 Then
							Return r
						End If
					ElseIf Not letter1 AndAlso letter2 Then
						Return -1
					ElseIf letter1 AndAlso Not letter2 Then
						Return 1
					End If
				ElseIf sp1 AndAlso sp2 Then
					r = CompareNum(s1, i1, s2, i2, zeroesFirst)
					If r <> 0 Then
						Return r
					End If
				ElseIf sp1 Then
					Return -1
				ElseIf sp2 Then
					Return 1
				End If
				i1 += 1
				i2 += 1
				If (i1 >= s1.Length) AndAlso (i2 >= s2.Length) Then
					Return 0
				ElseIf i1 >= s1.Length Then
					Return -1
				ElseIf i2 >= s2.Length Then
					Return 1
				End If
			End While
		End Function

		Private Shared Function CompareNum(s1 As String, ByRef i1 As Integer, s2 As String, ByRef i2 As Integer, zeroesFirst As Boolean) As Integer
			Dim nzStart1 As Integer = i1, nzStart2 As Integer = i2
			' nz = non zero
			Dim end1 As Integer = i1, end2 As Integer = i2

			ScanNumEnd(s1, i1, end1, nzStart1)
			ScanNumEnd(s2, i2, end2, nzStart2)
			Dim start1 As Integer = i1
			i1 = end1 - 1
			Dim start2 As Integer = i2
			i2 = end2 - 1

			If zeroesFirst Then
				Dim zl1 As Integer = nzStart1 - start1
				Dim zl2 As Integer = nzStart2 - start2
				If zl1 > zl2 Then
					Return -1
				End If
				If zl1 < zl2 Then
					Return 1
				End If
			End If

			Dim nzLength1 As Integer = end1 - nzStart1
			Dim nzLength2 As Integer = end2 - nzStart2

			If nzLength1 < nzLength2 Then
				Return -1
			ElseIf nzLength1 > nzLength2 Then
				Return 1
			End If

			Dim j1 As Integer = nzStart1, j2 As Integer = nzStart2
			While j1 <= i1
				Dim r As Integer = s1(j1).CompareTo(s2(j2))
				If r <> 0 Then
					Return r
				End If
				j1 += 1
				j2 += 1
			End While
			' the nz parts are equal
			Dim length1 As Integer = end1 - start1
			Dim length2 As Integer = end2 - start2
			If length1 = length2 Then
				Return 0
			End If
			If length1 > length2 Then
				Return -1
			End If
			Return 1
		End Function

		'lookahead
		Private Shared Sub ScanNumEnd(s As String, start As Integer, ByRef [end] As Integer, ByRef nzStart As Integer)
			nzStart = start
			[end] = start
			Dim countZeros As Boolean = True
			While [Char].IsDigit(s, [end])
				If countZeros AndAlso s([end]).Equals("0"C) Then
					nzStart += 1
				Else
					countZeros = False
				End If
				[end] += 1
				If [end] >= s.Length Then
					Exit While
				End If
			End While
		End Sub

	End Class
	'EOC
End Namespace
