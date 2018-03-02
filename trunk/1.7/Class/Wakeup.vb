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
Imports System.ComponentModel
Imports Microsoft.Win32.SafeHandles
Imports System.Threading

' ReSharper disable CheckNamespace
Friend Class WakeUp
    ' ReSharper restore CheckNamespace

    <Flags()>
 _
    Public Enum EXECUTION_STATE As UInteger
        ES_CONTINUOUS = &H80000000L
        ES_DISPLAY_REQUIRED = &H2
        ES_SYSTEM_REQUIRED = &H1
        ES_AWAYMODE_REQUIRED = &H40
    End Enum

    Private Const VkNoname As Integer = &HFC
    Private Const KeyeventfSilent As Byte = &H4

    <DllImport("Kernel32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetThreadExecutionState(ByVal state As EXECUTION_STATE) As EXECUTION_STATE
    End Function

    <DllImport("user32.dll")>
 _
    Private Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, _
                                    ByVal dwExtraInfo As Integer)
    End Sub

    <DllImport("kernel32.dll")>
    Private Shared Function CreateWaitableTimer(ByVal lpTimerAttributes As IntPtr, ByVal bManualReset As Boolean, _
                                                ByVal lpTimerName As String) As SafeWaitHandle
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function SetWaitableTimer(ByVal hTimer As SafeWaitHandle, <[In]()> ByRef pDueTime As Long, _
                                             ByVal lPeriod As Integer, ByVal pfnCompletionRoutine As IntPtr, _
                                             ByVal lpArgToCompletionRoutine As IntPtr, ByVal fResume As Boolean) _
        As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Event Woken As EventHandler
    Private ReadOnly _bgWorker As New BackgroundWorker()

    Public Sub New()
        AddHandler _bgWorker.DoWork, AddressOf BgWorkerDoWork
        AddHandler _bgWorker.RunWorkerCompleted, AddressOf BgWorkerRunWorkerCompleted
    End Sub

    Public Sub SetWakeUpTime(ByVal time As Date)
        _bgWorker.RunWorkerAsync(time.ToFileTime())
    End Sub

    Private Sub BgWorkerRunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        RaiseEvent Woken(Me, New EventArgs())
    End Sub

    Private Sub BgWorkerDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim waketime As Long = CLng(Fix(e.Argument))

        Using _
            handle As SafeWaitHandle = _
                CreateWaitableTimer(IntPtr.Zero, True, Me.GetType().Assembly.GetName().Name.ToString() & "Timer")
            If SetWaitableTimer(handle, waketime, 0, IntPtr.Zero, IntPtr.Zero, True) Then
                Using wh As New EventWaitHandle(False, EventResetMode.AutoReset)
                    wh.SafeWaitHandle = handle
                    wh.WaitOne()
                End Using
            Else
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
        End Using

        ' Néo 27/01/2011
        SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED)
        ' Or EXECUTION_STATE.ES_CONTINUOUS)
        SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED)

        ' On réveille Windows par simulation d'un keyboard event
        keybd_event(VkNoname, 0, KeyeventfSilent, 0)
    End Sub
End Class

