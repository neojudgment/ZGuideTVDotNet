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
Imports System.Runtime.InteropServices

' ReSharper disable CheckNamespace
Friend Module GarbageCollector
    ' ReSharper restore CheckNamespace

    ' 06/12/2008
    <DllImport("psapi.dll")>
    Private Function EmptyWorkingSet(ByVal hProcess As IntPtr) As Boolean
    End Function

    ' 06/12/2008
    Friend Sub MyMemoireClean()

        Trace.WriteLine(DateTime.Now & " " & "entree dans memeoire_clean")
        ' Déclaration des variables mémoire

        ' on prend la main du process en cours "ZGuideTV.NET"
        Dim pProcess As Process = Process.GetCurrentProcess()

        ' on vide le plus possible la mémoire inutilisée par le process
        Dim bRes As Boolean = EmptyWorkingSet(pProcess.Handle)

        If Not bRes Then

            ' EmptyWorkingSet a échoué...(dans certains cas cela peut échouer !)
            Trace.WriteLine(DateTime.Now & " " & "EmptyWorkingSet a échoué...")
        End If

        Trace.WriteLine(DateTime.Now & " " & "Mémoire allouée à ZGuideTV.NET après nettoyage de la mémoire = octets " & _
                          Environment.WorkingSet.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Sortie de memoire_clean")
    End Sub
End Module
