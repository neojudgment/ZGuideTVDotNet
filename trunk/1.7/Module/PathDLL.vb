' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2016 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
Imports System.Runtime.InteropServices

Module PathDll

    <DllImport("kernel32.dll", setlasterror:=True)>
    Public Function SetDllDirectory(pathname As String) As Boolean
    End Function

    Private Const Dll32 As String = "DLL32"
    Private Const Dll64 As String = "DLL64"

    Private ReadOnly PathDll32 As String = Path.Combine(AppPath, Dll32)
    Private ReadOnly PathDll64 As String = Path.Combine(AppPath, Dll64)

    Public Ret As Boolean

    Private _effectue As Boolean = False

    Public Sub AffecterCheminDll()

        If _effectue = False Then
            If Environment.Is64BitOperatingSystem Then
                Ret = SetDllDirectory(PathDll64)
            Else
                Ret = SetDllDirectory(PathDll32)
            End If
            _effectue = True
        End If
    End Sub
End Module
