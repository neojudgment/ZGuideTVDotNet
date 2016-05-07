' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2014 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

' ReSharper disable CheckNamespace
Module TestConnexion
    ' ReSharper restore CheckNamespace

    Public Function ConnectionAvailable(ByVal strServer As String) As Boolean

        ' rvs75 : 27/10/2010 : renvoie teste isOffline avant tout !!!!
        If Not (IsOffline) Then
            Try

                Dim reqFp As HttpWebRequest
                reqFp = CType(HttpWebRequest.Create(strServer), HttpWebRequest)

                If _
                    My.Settings.Proxy IsNot String.Empty AndAlso My.Settings.ProxyPort IsNot String.Empty AndAlso
                    IsNumeric(My.Settings.ProxyPort) Then

                    ' On utilise le proxy défini par l'utilisateur
                    Dim hcredential As New NetworkCredential(My.Settings.loginproxy, My.Settings.passproxy)
                    Dim myProxy As New WebProxy(My.Settings.Proxy, CType(My.Settings.ProxyPort, Integer))
                    reqFp.Proxy.Credentials = hcredential
                    reqFp.Proxy = myProxy
                Else

                    ' On utilise le proxy par défaut
                    reqFp.Proxy.Credentials = CredentialCache.DefaultCredentials
                    reqFp.Proxy = WebRequest.DefaultWebProxy
                End If

                With reqFp
                    .Timeout = 3000
                    .UserAgent = "ZGuideTV " & My.Application.Info.Version().ToString
                    .AllowAutoRedirect = True
                    ServicePointManager.Expect100Continue = False
                End With

                Dim rspFp As HttpWebResponse = CType(reqFp.GetResponse(), HttpWebResponse)

                If HttpStatusCode.OK = rspFp.StatusCode Then
                    ' HTTP = 200 - Connection Internet ou serveur disponible
                    reqFp.Abort()
                    rspFp.Close()
                    Return True
                Else
                    ' Autres status - Connection Internet ou serveur indisponible
                    reqFp.Abort()
                    rspFp.Close()
                    Return False
                End If

            Catch ex As WebException
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
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
End Module
