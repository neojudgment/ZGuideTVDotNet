' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2017 ZGuideTV.NET Team <https://github.com/neojudgment>                              |
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
' ReSharper disable CheckNamespace
Module Utilitairedate
    ' ReSharper restore CheckNamespace

    Public Function DebutHeure(ByVal lheure As DateTime) As DateTime
        'retire les minutes, les secondes et les milisecondes à un datetime
        Return New DateTime(lheure.Year, lheure.Month, lheure.Day, lheure.Hour, 0, 0)
    End Function

    Public Function DebutJournee(ByVal lheure As DateTime) As DateTime
        'retire les heures, les minutes, les secondes et les milisecondes à un datetime
        Return New DateTime(lheure.Year, lheure.Month, lheure.Day)
    End Function

    Public Function DateEntre(ByVal dateAComparer As DateTime, ByVal dateInferieur As DateTime, ByVal dateSuperieure As DateTime) As Boolean
        'retourne true si la première date est comprise entre les deux autres dates, sinon false
        If dateAComparer.CompareTo(dateInferieur) < 0 OrElse dateAComparer.CompareTo(dateSuperieure) > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
End Module
