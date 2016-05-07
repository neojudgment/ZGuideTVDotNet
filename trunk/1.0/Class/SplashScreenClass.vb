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

#Region "Enum"

' Messages définis: Success/Warning/Error.
Public Enum TypeOfMessage
    Success
    Warning
    [Error]
End Enum

#End Region

' Initialise le SplashScreen
Public NotInheritable Class SplashScreenClass
    Private Shared sf As SplashScreen

    Public Shared Sub ShowSplashScreen()
        If sf Is Nothing Then
            sf = New SplashScreen()
            sf.ShowSplashScreen()
        End If
    End Sub

    ' Ferme le SplashScreen
    Public Shared Sub CloseSplashScreen()
        If sf IsNot Nothing Then
            sf.CloseSplashScreen()
            sf = Nothing
        End If
    End Sub

    ' Mise à jour du num de version
    Public Shared Sub VersionText(ByVal Text As String)
        If sf IsNot Nothing Then
            sf.VersionText(Text)
        End If
    End Sub

    ' Mise à jour du Copyright
    Public Shared Sub CopyrightText(ByVal Text As String)
        If sf IsNot Nothing Then
            sf.CopyrightText(Text)
        End If
    End Sub
End Class