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
    Public Shared Sub VersionText(text As String)
        If _sf IsNot Nothing Then
            _sf.VersionText(text)
        End If
    End Sub

    ' Mise à jour du Copyright
    Public Shared Sub CopyrightText(text As String)
        If _sf IsNot Nothing Then
            _sf.CopyrightText(text)
        End If
    End Sub

    ' Mise à jour du Muticore
    Public Shared Sub MulticoreText(text As String)
        If _sf IsNot Nothing Then
            _sf.MulticoreText(text)
        End If
    End Sub
End Class