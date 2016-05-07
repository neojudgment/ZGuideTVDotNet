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
Imports System
Imports System.Runtime.InteropServices

Public Class AudioMixerHelper
    Public Const MMSYSERR_NOERROR As Integer = 0
    Public Const MAXPNAMELEN As Integer = 32
    Public Const MIXER_LONG_NAME_CHARS As Integer = 64
    Public Const MIXER_SHORT_NAME_CHARS As Integer = 16
    Public Const MIXER_GETLINEINFOF_COMPONENTTYPE As Integer = &H3
    Public Const MIXER_GETCONTROLDETAILSF_VALUE As Integer = &H0
    Public Const MIXER_GETLINECONTROLSF_ONEBYTYPE As Integer = &H2
    Public Const MIXER_SETCONTROLDETAILSF_VALUE As Integer = &H0
    Public Const MIXERLINE_COMPONENTTYPE_DST_FIRST As Integer = &H0
    Public Const MIXERLINE_COMPONENTTYPE_SRC_FIRST As Integer = &H1000
    Public Const MIXERLINE_COMPONENTTYPE_DST_SPEAKERS As Integer = MIXERLINE_COMPONENTTYPE_DST_FIRST + 4
    Public Const MIXERLINE_COMPONENTTYPE_SRC_MICROPHONE As Integer = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 3
    Public Const MIXERLINE_COMPONENTTYPE_SRC_LINE As Integer = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 2
    Public Const MIXERCONTROL_CT_CLASS_FADER As Integer = &H50000000
    Public Const MIXERCONTROL_CT_UNITS_UNSIGNED As Integer = &H30000
    Public Const MIXERCONTROL_CONTROLTYPE_FADER As Integer = MIXERCONTROL_CT_CLASS_FADER Or MIXERCONTROL_CT_UNITS_UNSIGNED
    Public Const MIXERCONTROL_CONTROLTYPE_VOLUME As Integer = MIXERCONTROL_CONTROLTYPE_FADER + 1

    Private Declare Ansi Function mixerClose Lib "winmm.dll" (ByVal hmx As Integer) As Integer
    Private Declare Ansi Function mixerGetControlDetailsA Lib "winmm.dll" (ByVal hmxobj As Integer, ByRef pmxcd As MIXERCONTROLDETAILS, ByVal fdwDetails As Integer) As Integer
    Private Declare Ansi Function mixerGetDevCapsA Lib "winmm.dll" (ByVal uMxId As Integer, ByVal pmxcaps As MIXERCAPS, ByVal cbmxcaps As Integer) As Integer
    Private Declare Ansi Function mixerGetID Lib "winmm.dll" (ByVal hmxobj As Integer, ByVal pumxID As Integer, ByVal fdwId As Integer) As Integer
    Private Declare Ansi Function mixerGetLineControlsA Lib "winmm.dll" (ByVal hmxobj As Integer, ByRef pmxlc As MIXERLINECONTROLS, ByVal fdwControls As Integer) As Integer
    Private Declare Ansi Function mixerGetLineInfoA Lib "winmm.dll" (ByVal hmxobj As Integer, ByRef pmxl As MIXERLINE, ByVal fdwInfo As Integer) As Integer
    Private Declare Ansi Function mixerGetNumDevs Lib "winmm.dll" () As Integer
    Private Declare Ansi Function mixerMessage Lib "winmm.dll" (ByVal hmx As Integer, ByVal uMsg As Integer, ByVal dwParam1 As Integer, ByVal dwParam2 As Integer) As Integer
    Private Declare Ansi Function mixerOpen Lib "winmm.dll" (ByRef phmx As Integer, ByVal uMxId As Integer, ByVal dwCallback As Integer, ByVal dwInstance As Integer, ByVal fdwOpen As Integer) As Integer
    Private Declare Ansi Function mixerSetControlDetails Lib "winmm.dll" (ByVal hmxobj As Integer, ByRef pmxcd As MIXERCONTROLDETAILS, ByVal fdwDetails As Integer) As Integer

    Public Structure MIXERCAPS
        Public wMid As Integer
        Public wPid As Integer
        Public vDriverVersion As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAXPNAMELEN)> Public szPname As String
        Public fdwSupport As Integer
        Public cDestinations As Integer
    End Structure 'MIXERCAPS
       _

    Public Structure MIXERCONTROL
        Public cbStruct As Integer
        Public dwControlID As Integer
        Public dwControlType As Integer
        Public fdwControl As Integer
        Public cMultipleItems As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MIXER_SHORT_NAME_CHARS)> Public szShortName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MIXER_LONG_NAME_CHARS)> Public szName As String
        Public lMinimum As Integer
        Public lMaximum As Integer
        <MarshalAs(UnmanagedType.U4, SizeConst:=10)> Public reserved As Integer
    End Structure 'MIXERCONTROL
       _

    Public Structure MIXERCONTROLDETAILS
        Public cbStruct As Integer
        Public dwControlID As Integer
        Public cChannels As Integer
        Public item As Integer
        Public cbDetails As Integer
        Public paDetails As IntPtr
    End Structure 'MIXERCONTROLDETAILS
       _

    Public Structure MIXERCONTROLDETAILS_UNSIGNED
        Public dwValue As Integer
    End Structure 'MIXERCONTROLDETAILS_UNSIGNED
       _

    Public Structure MIXERLINE
        Public cbStruct As Integer
        Public dwDestination As Integer
        Public dwSource As Integer
        Public dwLineID As Integer
        Public fdwLine As Integer
        Public dwUser As Integer
        Public dwComponentType As Integer
        Public cChannels As Integer
        Public cConnections As Integer
        Public cControls As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MIXER_SHORT_NAME_CHARS)> Public szShortName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MIXER_LONG_NAME_CHARS)> Public szName As String
        Public dwType As Integer
        Public dwDeviceID As Integer
        Public wMid As Integer
        Public wPid As Integer
        Public vDriverVersion As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAXPNAMELEN)> Public szPname As String
    End Structure 'MIXERLINE
       _

    Public Structure MIXERLINECONTROLS
        Public cbStruct As Integer
        Public dwLineID As Integer

        Public dwControl As Integer
        Public cControls As Integer
        Public cbmxctrl As Integer
        Public pamxctrl As IntPtr
    End Structure 'MIXERLINECONTROLS

    Private Shared Function GetVolumeControl(ByVal hmixer As Integer, ByVal componentType As Integer, ByVal ctrlType As Integer, ByRef mxc As MIXERCONTROL, ByRef vCurrentVol As Integer) As Boolean
        ' This function attempts to obtain a mixer control. 
        ' Returns True if successful. 
        Dim mxlc As New MIXERLINECONTROLS
        Dim mxl As New MIXERLINE
        Dim pmxcd As New MIXERCONTROLDETAILS
        Dim du As New MIXERCONTROLDETAILS_UNSIGNED
        mxc = New MIXERCONTROL
        Dim rc As Integer
        Dim retValue As Boolean
        vCurrentVol = -1

        mxl.cbStruct = Marshal.SizeOf(mxl)
        mxl.dwComponentType = componentType

        rc = mixerGetLineInfoA(hmixer, mxl, MIXER_GETLINEINFOF_COMPONENTTYPE)

        If MMSYSERR_NOERROR = rc Then
            Dim sizeofMIXERCONTROL As Integer = 152
            Dim ctrl As Integer = Marshal.SizeOf(GetType(MIXERCONTROL))
            mxlc.pamxctrl = Marshal.AllocCoTaskMem(sizeofMIXERCONTROL)
            mxlc.cbStruct = Marshal.SizeOf(mxlc)
            mxlc.dwLineID = mxl.dwLineID
            mxlc.dwControl = ctrlType
            mxlc.cControls = 1
            mxlc.cbmxctrl = sizeofMIXERCONTROL

            ' Allocate a buffer for the control 
            mxc.cbStruct = sizeofMIXERCONTROL

            ' Get the control 
            rc = mixerGetLineControlsA(hmixer, mxlc, MIXER_GETLINECONTROLSF_ONEBYTYPE)

            If MMSYSERR_NOERROR = rc Then
                retValue = True

                ' Copy the control into the destination structure 
                mxc = CType(Marshal.PtrToStructure(mxlc.pamxctrl, GetType(MIXERCONTROL)), MIXERCONTROL)
            Else
                retValue = False
            End If
            Dim sizeofMIXERCONTROLDETAILS As Integer = Marshal.SizeOf(GetType(MIXERCONTROLDETAILS))
            Dim sizeofMIXERCONTROLDETAILS_UNSIGNED As Integer = Marshal.SizeOf(GetType(MIXERCONTROLDETAILS_UNSIGNED))
            pmxcd.cbStruct = sizeofMIXERCONTROLDETAILS
            pmxcd.dwControlID = mxc.dwControlID
            pmxcd.paDetails = Marshal.AllocCoTaskMem(sizeofMIXERCONTROLDETAILS_UNSIGNED)
            pmxcd.cChannels = 1
            pmxcd.item = 0
            pmxcd.cbDetails = sizeofMIXERCONTROLDETAILS_UNSIGNED

            rc = mixerGetControlDetailsA(hmixer, pmxcd, MIXER_GETCONTROLDETAILSF_VALUE)

            du = CType(Marshal.PtrToStructure(pmxcd.paDetails, GetType(MIXERCONTROLDETAILS_UNSIGNED)), MIXERCONTROLDETAILS_UNSIGNED)

            vCurrentVol = du.dwValue

            Return retValue
        End If

        retValue = False
        Return retValue
    End Function 'GetVolumeControl

    Private Shared Function SetVolumeControl(ByVal hmixer As Integer, ByVal mxc As MIXERCONTROL, ByVal volume As Integer) As Boolean
        ' This function sets the value for a volume control. 
        ' Returns True if successful 
        Dim retValue As Boolean
        Dim rc As Integer
        Dim mxcd As New MIXERCONTROLDETAILS
        Dim vol As New MIXERCONTROLDETAILS_UNSIGNED

        mxcd.item = 0
        mxcd.dwControlID = mxc.dwControlID
        mxcd.cbStruct = Marshal.SizeOf(mxcd)
        mxcd.cbDetails = Marshal.SizeOf(vol)

        ' Allocate a buffer for the control value buffer 
        mxcd.cChannels = 1
        vol.dwValue = volume

        ' Copy the data into the control value buffer 
        mxcd.paDetails = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(MIXERCONTROLDETAILS_UNSIGNED)))
        Marshal.StructureToPtr(vol, mxcd.paDetails, False)

        ' Set the control value 
        rc = mixerSetControlDetails(hmixer, mxcd, MIXER_SETCONTROLDETAILSF_VALUE)

        If MMSYSERR_NOERROR = rc Then
            retValue = True
        Else
            retValue = False
        End If
        Return retValue
    End Function 'SetVolumeContr

    Public Shared Function GetVolume() As Integer
        Dim mixer As Integer
        Dim volCtrl As New MIXERCONTROL
        Dim currentVol As Integer
        mixerOpen(mixer, 0, 0, 0, 0)
        Dim type As Integer = MIXERCONTROL_CONTROLTYPE_VOLUME
        GetVolumeControl(mixer, MIXERLINE_COMPONENTTYPE_DST_SPEAKERS, type, volCtrl, currentVol)
        mixerClose(mixer)

        Return currentVol
    End Function ' Récupère le volume

    Public Shared Sub SetVolume(ByVal vVolume As Integer)
        Dim mixer As Integer
        Dim volCtrl As New MIXERCONTROL
        Dim currentVol As Integer
        mixerOpen(mixer, 0, 0, 0, 0)
        Dim type As Integer = MIXERCONTROL_CONTROLTYPE_VOLUME
        GetVolumeControl(mixer, MIXERLINE_COMPONENTTYPE_DST_SPEAKERS, type, volCtrl, currentVol)
        If vVolume > volCtrl.lMaximum Then
            vVolume = volCtrl.lMaximum
        End If
        If vVolume < volCtrl.lMinimum Then
            vVolume = volCtrl.lMinimum
        End If
        SetVolumeControl(mixer, volCtrl, vVolume)
        GetVolumeControl(mixer, MIXERLINE_COMPONENTTYPE_DST_SPEAKERS, type, volCtrl, currentVol)
        If vVolume <> currentVol Then
            Throw New Exception("Cannot Set Volume")
        End If
        mixerClose(mixer)
    End Sub ' Modifie le volume
End Class
