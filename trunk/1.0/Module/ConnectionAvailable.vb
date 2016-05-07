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
Imports System.Net

Module ConnectionAvailable
    Private Declare Function InternetGetConnectedState Lib "wininet" _
       (ByRef dwFlags As Long,
        ByVal dwReserved As Long) As Long

    Public Function ConnectionAvailable(ByVal strServer As String) As Boolean

        'rvs75 : 27/10/2010 : renvoie teste isOffline avant tout !!!!
        'evite de figer zg
        If Not (isOffline) Then
            Try

                Dim reqFP As HttpWebRequest = CType(HttpWebRequest.Create(strServer), HttpWebRequest)
                Dim rspFP As HttpWebResponse = CType(reqFP.GetResponse(), HttpWebResponse)

                If HttpStatusCode.OK = rspFP.StatusCode Then
                    ' HTTP = 200 - Connection Internet ou serveur disponible
                    reqFP.Abort()
                    rspFP.Close()
                    Return True
                Else
                    ' Autres status - Connection Internet ou serveur indisponible
                    reqFP.Abort()
                    rspFP.Close()
                    Return False
                End If

            Catch e1 As WebException
                Trace.WriteLine(DateTime.Now & " " & "erreur try catch dans ConnectionAvailable")
                ' Connection non disponible
                Return False
            End Try
        Else
            Trace.WriteLine(DateTime.Now & " " & "On est en mode offline")
            ' Connection non disponible
            Return False
        End If
    End Function

    Public Function IsNetConnectOnline() As Boolean

        ' il y a une connection internet
        IsNetConnectOnline = CBool(InternetGetConnectedState(0&, 0&))
    End Function
End Module
