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

' Initialise le SplashScreen
' ReSharper disable ClassNeverInstantiated.Global
' ReSharper disable CheckNamespace
Public NotInheritable Class SplashScreenClass
    ' ReSharper restore CheckNamespace
    ' ReSharper restore ClassNeverInstantiated.Global
    Private Shared _sf As SplashScreen

    Public Shared Sub ShowSplashScreen()
        If _sf Is Nothing Then
            _sf = New SplashScreen()
            _sf.ShowSplashScreen()
        End If
    End Sub

    ' Ferme le SplashScreen
    Public Shared Sub CloseSplashScreen()
        If _sf IsNot Nothing Then
            _sf.CloseSplashScreen()
            _sf = Nothing
        End If
    End Sub

    ' Mise à jour du num de version
    Public Shared Sub VersionText(ByVal text As String)
        If _sf IsNot Nothing Then
            _sf.VersionText(text)
        End If
    End Sub

    ' Mise à jour du Copyright
    Public Shared Sub CopyrightText(ByVal text As String)
        If _sf IsNot Nothing Then
            _sf.CopyrightText(text)
        End If
    End Sub
End Class