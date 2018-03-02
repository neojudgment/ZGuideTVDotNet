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

Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Security
Imports System.Security.Permissions
Friend Class NativeMethods
    Friend Const WM_NCHITTEST As Integer = &H84, WM_NCACTIVATE As Integer = &H86, WS_EX_TRANSPARENT As Integer = &H20, WS_EX_TOOLWINDOW As Integer = &H80, WS_EX_LAYERED As Integer = &H80000, WS_EX_NOACTIVATE As Integer = &H8000000, _
      HTTRANSPARENT As Integer = -1, HTLEFT As Integer = 10, HTRIGHT As Integer = 11, HTTOP As Integer = 12, HTTOPLEFT As Integer = 13, HTTOPRIGHT As Integer = 14, _
      HTBOTTOM As Integer = 15, HTBOTTOMLEFT As Integer = 16, HTBOTTOMRIGHT As Integer = 17, WM_PRINT As Integer = &H317, WM_USER As Integer = &H400, WM_REFLECT As Integer = WM_USER + &H1C00, _
      WM_COMMAND As Integer = &H111, CBN_DROPDOWN As Integer = 7, WM_GETMINMAXINFO As Integer = &H24

    Private Shared HWND_TOPMOST As New HandleRef(Nothing, New IntPtr(-1))

    <Flags> _
    Friend Enum AnimationFlags As Integer
        Roll = &H0
        HorizontalPositive = &H1
        HorizontalNegative = &H2
        VerticalPositive = &H4
        VerticalNegative = &H8
        Center = &H10
        Hide = &H10000
        Activate = &H20000
        Slide = &H40000
        Blend = &H80000
        Mask = &HFFFFF
    End Enum

    <SuppressUnmanagedCodeSecurity, _
     DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function AnimateWindow(windowHandle As HandleRef, time As Integer, flags As AnimationFlags) As Integer
    End Function

    Friend Shared Sub AnimateWindow(control As Control, time As Integer, flags As AnimationFlags)
        If control Is Nothing Then
            Throw New ArgumentNullException
        End If
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.UnmanagedCode)
            sp.Demand()
            AnimateWindow(New HandleRef(control, control.Handle), time, flags)
        Catch generatedExceptionName As SecurityException
        End Try
    End Sub

    <SuppressUnmanagedCodeSecurity, _
     DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)> _
    Private Shared Function SetWindowPos(hWnd As HandleRef, hWndInsertAfter As HandleRef, x As Integer, y As Integer, cx As Integer, cy As Integer, _
    flags As Integer) As Boolean
    End Function

    Friend Shared Sub SetTopMost(control As Control)
        If control Is Nothing Then
            Throw New ArgumentNullException
        End If
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.UnmanagedCode)
            sp.Demand()
            SetWindowPos(New HandleRef(control, control.Handle), HWND_TOPMOST, 0, 0, 0, 0, _
              &H13)
        Catch generatedExceptionName As SecurityException
        End Try
    End Sub

    <StructLayout(LayoutKind.Sequential)> _
    Friend Structure MINMAXINFO
        Public reserved As Point
        Public maxSize As Size
        Public maxPosition As Point
        Public minTrackSize As Size
        Public maxTrackSize As Size
    End Structure

End Class
