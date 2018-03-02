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
