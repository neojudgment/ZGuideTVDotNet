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
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports Microsoft.Win32.SafeHandles
Imports System.Threading

Friend Class WakeUP
#Region "Enum"

    <Flags()>
 _
    Public Enum EXECUTION_STATE As UInteger
        ES_CONTINUOUS = &H80000000L
        ES_DISPLAY_REQUIRED = &H2
        ES_SYSTEM_REQUIRED = &H1
        ES_AWAYMODE_REQUIRED = &H40
    End Enum

#End Region

    Private Const VK_NONAME As Integer = &HFC
    Private Const KEYEVENTF_SILENT As Byte = &H4

#Region "DLLImport"

    <DllImport("Kernel32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)>
 _
    Protected Shared Function SetThreadExecutionState(ByVal state As EXECUTION_STATE) As EXECUTION_STATE
    End Function

    <DllImport("user32.dll")>
 _
    Private Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, _
                                    ByVal dwExtraInfo As Integer)
    End Sub

    <DllImport("kernel32.dll")>
 _
    Public Shared Function CreateWaitableTimer(ByVal lpTimerAttributes As IntPtr, ByVal bManualReset As Boolean, _
                                                ByVal lpTimerName As String) As SafeWaitHandle
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
 _
    Public Shared Function SetWaitableTimer(ByVal hTimer As SafeWaitHandle, <[In]()> ByRef pDueTime As Long, _
                                             ByVal lPeriod As Integer, ByVal pfnCompletionRoutine As IntPtr, _
                                             ByVal lpArgToCompletionRoutine As IntPtr, ByVal fResume As Boolean) _
        As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

#End Region

    Public Event Woken As EventHandler
    Private bgWorker As New BackgroundWorker()

    Public Sub New()
        AddHandler bgWorker.DoWork, AddressOf bgWorker_DoWork
        AddHandler bgWorker.RunWorkerCompleted, AddressOf bgWorker_RunWorkerCompleted
    End Sub

    Public Sub SetWakeUpTime(ByVal time As Date)
        bgWorker.RunWorkerAsync(time.ToFileTime())
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        RaiseEvent Woken(Me, New EventArgs())
    End Sub

    Private Sub bgWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
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
        keybd_event(VK_NONAME, 0, KEYEVENTF_SILENT, 0)
    End Sub
End Class

