' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2013 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
