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
Imports System.IO

' ReSharper disable CheckNamespace
Module Purge
    ' ReSharper restore CheckNamespace

    Sub Mypurge()
        ' Purge des fichiers obsolètes
        Dim xmlFile() As String
        Dim rarFile() As String
        Dim zipFile() As String
        Dim sevenzipFile() As String
        Dim purge As Integer

        purge = My.Settings.Purgefichiers

        Select Case purge
            Case 1
                xmlFile = Directory.GetFiles(AppData, "*.xml")
                rarFile = Directory.GetFiles(AppData, "*.rar")
                zipFile = Directory.GetFiles(AppData, "*.zip")
                sevenzipFile = Directory.GetFiles(AppData, "*.7z")

                Dim i As Integer = 0

                Do While i < xmlFile.Length
                    File.Delete(xmlFile(i))
                    i = i + 1
                Loop
                i = 0
                Do While i < rarFile.Length
                    File.Delete(rarFile(i))
                    i = i + 1
                Loop

                i = 0
                Do While i < zipFile.Length
                    File.Delete(zipFile(i))
                    i = i + 1
                Loop

                i = 0
                Do While i < sevenzipFile.Length
                    File.Delete(sevenzipFile(i))
                    i = i + 1
                Loop

        End Select
    End Sub
End Module
