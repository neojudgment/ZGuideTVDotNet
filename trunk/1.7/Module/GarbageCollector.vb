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
