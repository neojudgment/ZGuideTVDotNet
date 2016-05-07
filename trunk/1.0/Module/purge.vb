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
Imports System.IO

Module purge

    Sub purge()
        ' Purge des fichiers obsolètes
        Dim XMLFile() As String
        Dim RARFile() As String
        Dim ZIPFile() As String
        Dim SEVENZIPFile() As String
        Dim Purge As Integer

        Purge = My.Settings.Purgefichiers

        Select Case Purge
            Case 1
                XMLFile = Directory.GetFiles(AppData, "*.xml")
                RARFile = Directory.GetFiles(AppData, "*.rar")
                ZIPFile = Directory.GetFiles(AppData, "*.zip")
                SEVENZIPFile = Directory.GetFiles(AppData, "*.7z")

                Dim i As Integer = 0

                Do While i < XMLFile.Length
                    File.Delete(XMLFile(i))
                    i = i + 1
                Loop
                i = 0
                Do While i < RARFile.Length
                    File.Delete(RARFile(i))
                    i = i + 1
                Loop

                i = 0
                Do While i < ZIPFile.Length
                    File.Delete(ZIPFile(i))
                    i = i + 1
                Loop

                i = 0
                Do While i < SEVENZIPFile.Length
                    File.Delete(SEVENZIPFile(i))
                    i = i + 1
                Loop

        End Select
    End Sub
End Module
