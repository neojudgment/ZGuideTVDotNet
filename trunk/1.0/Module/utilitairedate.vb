' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2012 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
' |                                                                                                            |
' |    Project administrator : Pascal Hubert (neojudgment@hotmail.com)                                         |
' |                                                                                                            |
' |    This program is free software: you can redistribute it and/or modify                                    |
' |    it under the terms of the GNU General Public License as published by                                    |
' |    the Free Software Foundation, either version 2 of the License, or                                       |
' |    (at your option) any later version.                                                                     |
' |                                                                                                            |
' |    This program is distributed in the hope that it will be useful,                                         |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of                                          |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                                           |
' |    GNU General Public License for more details.                                                            |
' |                                                                                                            |
' |    You should have received a copy of the GNU General Public License                                       |
' |    along with this program.  If not, see <http://www.gnu.org/licenses/>.                                   |
' |                                                                                                            |
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
Module utilitairedate
    Public Function DebutHeure(ByVal lheure As DateTime) As DateTime
        'retire les minutes, les secondes et les milisecondes à un datetime
        Return New DateTime(lheure.Year, lheure.Month, lheure.Day, lheure.Hour, 0, 0)
    End Function

    Public Function DebutJournee(ByVal lheure As DateTime) As DateTime
        'retire les heures, les minutes, les secondes et les milisecondes à un datetime
        Return New DateTime(lheure.Year, lheure.Month, lheure.Day)
    End Function

    Public Function DateEntre(ByVal Date_a_comparer As DateTime, ByVal Date_inferieur As DateTime, ByVal Date_superieure As DateTime) As Boolean
        'retourne true si la première date est comprise entre les deux autres dates, sinon false
        If Date_a_comparer.CompareTo(Date_inferieur) < 0 OrElse Date_a_comparer.CompareTo(Date_superieure) > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
End Module
