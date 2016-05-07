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
Imports System.ComponentModel
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing ' pour l'impression
Imports System.Windows.Forms   'pour zg en tant que class et non de usercontrol
Imports System.Drawing         'pour zg en tant que class et non de usercontrol

Namespace RichTextBoxPrintCtrl
    ' STGM
    <Flags(), ComVisible(False)> _
    Public Enum STGM As Integer
        STGM_DIRECT = &H0
        STGM_TRANSACTED = &H10000
        STGM_SIMPLE = &H8000000
        STGM_READ = &H0
        STGM_WRITE = &H1
        STGM_READWRITE = &H2
        STGM_SHARE_DENY_NONE = &H40
        STGM_SHARE_DENY_READ = &H30
        STGM_SHARE_DENY_WRITE = &H20
        STGM_SHARE_EXCLUSIVE = &H10
        STGM_PRIORITY = &H40000
        STGM_DELETEONRELEASE = &H4000000
        STGM_NOSCRATCH = &H100000
        STGM_CREATE = &H1000
        STGM_CONVERT = &H20000
        STGM_FAILIFTHERE = &H0
        STGM_NOSNAPSHOT = &H200000
    End Enum

    ' DVASPECT
    <Flags(), ComVisible(False)> _
    Public Enum DVASPECT As Integer
        DVASPECT_CONTENT = 1
        DVASPECT_THUMBNAIL = 2
        DVASPECT_ICON = 4
        DVASPECT_DOCPRINT = 8
        DVASPECT_OPAQUE = 16
        DVASPECT_TRANSPARENT = 32
    End Enum

    ' CLIPFORMAT
    <ComVisible(False)> _
    Public Enum CLIPFORMAT As Integer
        CF_TEXT = 1
        CF_BITMAP = 2
        CF_METAFILEPICT = 3
        CF_SYLK = 4
        CF_DIF = 5
        CF_TIFF = 6
        CF_OEMTEXT = 7
        CF_DIB = 8
        CF_PALETTE = 9
        CF_PENDATA = 10
        CF_RIFF = 11
        CF_WAVE = 12
        CF_UNICODETEXT = 13
        CF_ENHMETAFILE = 14
        CF_HDROP = 15
        CF_LOCALE = 16
        CF_MAX = 17
        CF_OWNERDISPLAY = &H80
        CF_DSPTEXT = &H81
        CF_DSPBITMAP = &H82
        CF_DSPMETAFILEPICT = &H83
        CF_DSPENHMETAFILE = &H8E
    End Enum

    ' Object flags
    <Flags(), ComVisible(False)> _
    Public Enum REOOBJECTFLAGS As UInteger
        REO_NULL = &H0 ' No flags
        REO_READWRITEMASK = &H3F ' Mask out RO bits
        REO_DONTNEEDPALETTE = &H20 ' Object doesn't need palette
        REO_BLANK = &H10 ' Object is blank
        REO_DYNAMICSIZE = &H8 ' Object defines size always
        REO_INVERTEDSELECT = &H4 ' Object drawn all inverted if sel
        REO_BELOWBASELINE = &H2 ' Object sits below the baseline
        REO_RESIZABLE = &H1 ' Object may be resized
        REO_LINK = &H80000000L ' Object is a link (RO)
        REO_STATIC = &H40000000 ' Object is static (RO)
        REO_SELECTED = &H8000000 ' Object selected (RO)
        REO_OPEN = &H4000000 ' Object open in its server (RO)
        REO_INPLACEACTIVE = &H2000000 ' Object in place active (RO)
        REO_HILITED = &H1000000 ' Object is to be hilited (RO)
        REO_LINKAVAILABLE = &H800000 ' Link believed available (RO)
        REO_GETMETAFILE = &H400000 ' Object requires metafile (RO)
    End Enum

    ' OLERENDER
    <ComVisible(False)> _
    Public Enum OLERENDER As Integer
        OLERENDER_NONE = 0
        OLERENDER_DRAW = 1
        OLERENDER_FORMAT = 2
        OLERENDER_ASIS = 3
    End Enum

    ' TYMED
    <Flags(), ComVisible(False)> _
    Public Enum TYMED As Integer
        TYMED_NULL = 0
        TYMED_HGLOBAL = 1
        TYMED_FILE = 2
        TYMED_ISTREAM = 4
        TYMED_ISTORAGE = 8
        TYMED_GDI = 16
        TYMED_MFPICT = 32
        TYMED_ENHMF = 64
    End Enum

    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Structure FORMATETC
        Public cfFormat As CLIPFORMAT
        Public ptd As IntPtr
        Public dwAspect As DVASPECT
        Public lindex As Integer
        Public tymed As TYMED

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Structure STGMEDIUM
        '[MarshalAs(UnmanagedType.I4)]
        Public tymed As Integer
        Public unionmember As IntPtr
        Public pUnkForRelease As IntPtr

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    <ComVisible(True), ComImport(), Guid("00000103-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumFORMATETC
        <PreserveSig()> _
        Function [Next](<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer, <Out()> ByVal rgelt As FORMATETC, <[In](), Out(), MarshalAs(UnmanagedType.LPArray)> ByVal pceltFetched() As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Skip(<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Reset() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Clone(<Out(), MarshalAs(UnmanagedType.LPArray)> ByVal ppenum() As IEnumFORMATETC) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface
    Public Class RichTextBoxPrintCtrl
        Inherits RichTextBox
        Public Sub New()
        End Sub

        'selection des style
        <StructLayout(LayoutKind.Sequential)> _
        Private Structure STRUCT_CHARFORMAT
            Public cbSize As Integer
            Public dwMask As UInt32
            Public dwEffects As UInt32
            Public yHeight As Int32
            Public yOffset As Int32
            Public crTextColor As Int32
            Public bCharSet As Byte
            Public bPitchAndFamily As Byte
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
            Public szFaceName() As Char

            Public Overloads Overrides Function GetHashCode() As Integer
                Throw New NotImplementedException()
            End Function

            Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
                Throw New NotImplementedException()
            End Function
        End Structure
        'selection style
        'Private Const EM_FORMATRANGE As Int32 = WM_USER + 57
        Private Const EM_GETCHARFORMAT As Int32 = WM_USER + 58
        Private Const EM_SETCHARFORMAT As Int32 = WM_USER + 68

        ' Defines for EM_GETCHARFORMAT/EM_SETCHARFORMAT
        Private SCF_SELECTION As Int32 = &H1&
        Private SCF_WORD As Int32 = &H2&
        Private SCF_ALL As Int32 = &H4&


        ' Defines for STRUCT_CHARFORMAT member dwMask
        ' (Long because UInt32 is not an intrinsic type)
        Private Const CFM_BOLD As Long = &H1&
        Private Const CFM_ITALIC As Long = &H2&
        Private Const CFM_UNDERLINE As Long = &H4&
        Private Const CFM_STRIKEOUT As Long = &H8&
        Private Const CFM_PROTECTED As Long = &H10&
        Private Const CFM_LINK As Long = &H20&
        Private Const CFM_SIZE As Long = &H80000000&
        Private Const CFM_COLOR As Long = &H40000000&
        Private Const CFM_FACE As Long = &H20000000&
        Private Const CFM_OFFSET As Long = &H10000000&
        Private Const CFM_CHARSET As Long = &H8000000&

        ' Defines for STRUCT_CHARFORMAT member dwEffects
        Private Const CFE_BOLD As Long = &H1&
        Private Const CFE_ITALIC As Long = &H2&
        Private Const CFE_UNDERLINE As Long = &H4&
        Private Const CFE_STRIKEOUT As Long = &H8&
        Private Const CFE_PROTECTED As Long = &H10&
        Private Const CFE_LINK As Long = &H20&
        Private Const CFE_AUTOCOLOR As Long = &H40000000&

        'Impression from zg
        Private Const AnInch As Double = 14.4

        Private WithEvents m_PrintDocument As PrintDocument
        Private intCharactersToPrint As Integer
        Private intCurrentPosition As Integer

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer

            Public Overloads Overrides Function GetHashCode() As Integer
                Throw New NotImplementedException()
            End Function

            Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
                Throw New NotImplementedException()
            End Function
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure CHARRANGE
            ' •———————————————————————————————————————————————•
            ' | First character of range (0 for start of doc) |
            ' •———————————————————————————————————————————————•
            Public cpMin As Integer
            ' •—————————————————————————————————————————————•
            ' | Last character of range (-1 for end of doc) |
            ' •—————————————————————————————————————————————•
            Public cpMax As Integer

            Public Overloads Overrides Function GetHashCode() As Integer
                Throw New NotImplementedException()
            End Function

            Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
                Throw New NotImplementedException()
            End Function
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure FORMATRANGE
            ' •——————————————————————•
            ' | Actual DC to draw on |
            ' •——————————————————————•
            Public hdc As IntPtr
            ' •———————————————————————————————————————————•
            ' | Target DC for determining text formatting |
            ' •———————————————————————————————————————————•
            Public hdcTarget As IntPtr
            ' •————————————————————————————————————————•
            ' | Region of the DC to draw to (in twips) |
            ' •————————————————————————————————————————•
            Public rc As RECT
            ' •———————————————————————————————————————————————•
            ' | Region of the whole DC (page size) (in twips) |
            ' •———————————————————————————————————————————————•
            Public rcPage As RECT
            ' •———————————————————————————————————————————————•
            ' | Range of text to draw (see above declaration) |
            ' •———————————————————————————————————————————————•
            Public chrg As CHARRANGE

            Public Overloads Overrides Function GetHashCode() As Integer
                Throw New NotImplementedException()
            End Function

            Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
                Throw New NotImplementedException()
            End Function
        End Structure

        Private Const WM_USER As Integer = &H400
        Private Const EM_FORMATRANGE As Integer = WM_USER + 57

        'fin

        ' It makes no difference if we use PARAFORMAT or
        ' PARAFORMAT2 here, so I have opted for PARAFORMAT2.
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure PARAFORMAT
            Public cbSize As Integer
            Public dwMask As UInteger
            Public wNumbering As Short
            Public wReserved As Short
            Public dxStartIndent As Integer
            Public dxRightIndent As Integer
            Public dxOffset As Integer
            Public wAlignment As Short
            Public cTabCount As Short
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
            Public rgxTabs() As Integer

            ' PARAFORMAT2 from here onwards.
            Public dySpaceBefore As Integer
            Public dySpaceAfter As Integer
            Public dyLineSpacing As Integer
            Public sStyle As Short
            Public bLineSpacingRule As Byte
            Public bOutlineLevel As Byte
            Public wShadingWeight As Short
            Public wShadingStyle As Short
            Public wNumberingStart As Short
            Public wNumberingStyle As Short
            Public wNumberingTab As Short
            Public wBorderSpace As Short
            Public wBorderWidth As Short
            Public wBorders As Short

            Public Overloads Overrides Function GetHashCode() As Integer
                Throw New NotImplementedException()
            End Function

            Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
                Throw New NotImplementedException()
            End Function
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure CHARFORMAT
            Public cbSize As Integer
            Public dwMask As UInt32
            Public dwEffects As UInt32
            Public yHeight As Int32
            Public yOffset As Int32
            Public crTextColor As Int32
            Public bCharSet As Byte
            Public bPitchAndFamily As Byte
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
            Public szFaceName() As Char

            ' CHARFORMAT2 from here onwards.
            Public wWeight As Short
            Public sSpacing As Short
            Public crBackColor As Int32
            Public lcid As UInteger
            Public dwReserved As UInteger
            Public sStyle As Short
            Public wKerning As Short
            Public bUnderlineType As Byte
            Public bAnimation As Byte
            Public bRevAuthor As Byte
            Public bReserved1 As Byte

            Public Overloads Overrides Function GetHashCode() As Integer
                Throw New NotImplementedException()
            End Function

            Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
                Throw New NotImplementedException()
            End Function
        End Structure

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByRef lp As PARAFORMAT) As Integer
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByRef lp As CHARFORMAT) As Integer
        End Function

        Private Const EM_SETEVENTMASK As Integer = 1073
        Private Const WM_SETREDRAW As Integer = 11

        <DllImport("User32.dll", CharSet:=CharSet.Auto, PreserveSig:=False)> _
        Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal message As Integer, ByVal wParam As Integer) As IRichEditOle
        End Function

        <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
        Friend Shared Function GetClientRect(ByVal hWnd As IntPtr, <[In](), Out()> ByRef rect As Rectangle) As Boolean
        End Function

        <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
        Friend Shared Function GetWindowRect(ByVal hWnd As IntPtr, <[In](), Out()> ByRef rect As Rectangle) As Boolean
        End Function

        <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
        Friend Shared Function GetParent(ByVal hWnd As IntPtr) As IntPtr
        End Function

        <DllImport("ole32.dll")> _
        Shared Function OleSetContainedObject(<MarshalAs(UnmanagedType.IUnknown)> ByVal pUnk As Object, ByVal fContained As Boolean) As Integer
        End Function

        <DllImport("ole32.dll")> _
        Shared Function OleLoadPicturePath(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpszPicturePath As String, <MarshalAs(UnmanagedType.IUnknown), [In]()> ByVal pIUnknown As Object, ByVal dwReserved As UInteger, ByVal clrReserved As UInteger, ByRef riid As Guid, <System.Runtime.InteropServices.Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
        End Function

        <DllImport("ole32.dll")> _
        Shared Function OleCreateFromFile(<[In]()> ByRef rclsid As Guid, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszFileName As String, <[In]()> ByRef riid As Guid, ByVal renderopt As UInteger, ByRef pFormatEtc As FORMATETC, ByVal pClientSite As IOleClientSite, ByVal pStg As IStorage, <System.Runtime.InteropServices.Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
        End Function

        <DllImport("ole32.dll")> _
        Shared Function OleCreateFromData(ByVal pSrcDataObj As IDataObject, <[In]()> ByRef riid As Guid, ByVal renderopt As UInteger, ByRef pFormatEtc As FORMATETC, ByVal pClientSite As IOleClientSite, ByVal pStg As IStorage, <System.Runtime.InteropServices.Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
        End Function

        <DllImport("ole32.dll")> _
        Shared Function OleCreateStaticFromData(<MarshalAs(UnmanagedType.Interface)> ByVal pSrcDataObj As IDataObject, <[In]()> ByRef riid As Guid, ByVal renderopt As UInteger, ByRef pFormatEtc As FORMATETC, ByVal pClientSite As IOleClientSite, ByVal pStg As IStorage, <System.Runtime.InteropServices.Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
        End Function

        <DllImport("ole32.dll")> _
        Shared Function OleCreateLinkFromData(<MarshalAs(UnmanagedType.Interface)> ByVal pSrcDataObj As IDataObject, <[In]()> ByRef riid As Guid, ByVal renderopt As UInteger, ByRef pFormatEtc As FORMATETC, ByVal pClientSite As IOleClientSite, ByVal pStg As IStorage, <System.Runtime.InteropServices.Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
        End Function


        Private Declare Function SendMessage Lib "USER32" Alias _
    "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, _
                    ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
        <DllImport("user32.dll")> _
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, _
                                        ByVal msg As Int32, _
                                        ByVal wParam As Int32, _
                                        ByVal lParam As IntPtr) As Int32
        End Function

        'choix style
        ' Sets the font only for the selected part of the rich text box
        ' without modifying the other properties like size or style
        ' <param name="face">Name of the font to use</param>
        ' <returns>true on success, false on failure</returns>
        Public Function SetSelectionFont(ByVal face As String) As Boolean
            Dim cf As New STRUCT_CHARFORMAT()
            cf.cbSize = Marshal.SizeOf(cf)
            cf.dwMask = Convert.ToUInt32(CFM_FACE)

            ' ReDim face name to relevant size
            ReDim cf.szFaceName(32)
            face.CopyTo(0, cf.szFaceName, 0, Math.Min(31, face.Length))

            Dim lParam As IntPtr
            lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf))
            Marshal.StructureToPtr(cf, lParam, False)

            Dim res As Integer
            res = SendMessage(Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam)
            If (res = 0) Then
                Return True
            Else
                Return False
            End If
        End Function

        ' Sets the font size only for the selected part of the rich text box
        ' without modifying the other properties like font or style
        ' <param name="size">new point size to use</param>
        ' <returns>true on success, false on failure</returns>
        Public Function SetSelectionSize(ByVal size As Integer) As Boolean
            Dim cf As New STRUCT_CHARFORMAT()
            cf.cbSize = Marshal.SizeOf(cf)
            cf.dwMask = Convert.ToUInt32(CFM_SIZE)
            ' yHeight is in 1/20 pt
            cf.yHeight = size * 20

            Dim lParam As IntPtr
            lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf))
            Marshal.StructureToPtr(cf, lParam, False)

            Dim res As Integer
            res = SendMessage(Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam)
            If (res = 0) Then
                Return True
            Else
                Return False
            End If
        End Function

        ' Sets the bold style only for the selected part of the rich text box
        ' without modifying the other properties like font or size
        ' <param name="bold">make selection bold (true) or regular (false)</param>
        ' <returns>true on success, false on failure</returns>
        Public Function SetSelectionBold(ByVal bold As Boolean) As Boolean
            If (bold) Then
                Return SetSelectionStyle(CFM_BOLD, CFE_BOLD)
            Else
                Return SetSelectionStyle(CFM_BOLD, 0)
            End If
        End Function

        ' Sets the italic style only for the selected part of the rich text box
        ' without modifying the other properties like font or size
        ' <param name="italic">make selection italic (true) or regular (false)</param>
        ' <returns>true on success, false on failure</returns>
        Public Function SetSelectionItalic(ByVal italic As Boolean) As Boolean
            If (italic) Then
                Return SetSelectionStyle(CFM_ITALIC, CFE_ITALIC)
            Else
                Return SetSelectionStyle(CFM_ITALIC, 0)
            End If
        End Function

        ' Sets the underlined style only for the selected part of the rich text box
        ' without modifying the other properties like font or size
        ' <param name="underlined">make selection underlined (true) or regular (false)</param>
        ' <returns>true on success, false on failure</returns>
        Public Function SetSelectionUnderlined(ByVal underlined As Boolean) As Boolean
            If (underlined) Then
                Return SetSelectionStyle(CFM_UNDERLINE, CFE_UNDERLINE)
            Else
                Return SetSelectionStyle(CFM_UNDERLINE, 0)
            End If
        End Function

        ' Set the style only for the selected part of the rich text box
        ' with the possibility to mask out some styles that are not to be modified
        ' <param name="mask">modify which styles?</param>
        ' <param name="effect">new values for the styles</param>
        ' <returns>true on success, false on failure</returns>
        Private Function SetSelectionStyle(ByVal mask As Int32, ByVal effect As Int32) As Boolean
            Dim cf As New STRUCT_CHARFORMAT()
            cf.cbSize = Marshal.SizeOf(cf)
            cf.dwMask = Convert.ToUInt32(mask)
            cf.dwEffects = Convert.ToUInt32(effect)

            Dim lParam As IntPtr
            lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf))
            Marshal.StructureToPtr(cf, lParam, False)

            Dim res As Integer
            res = SendMessage(Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam)
            If (res = 0) Then
                Return True
            Else
                Return False
            End If
        End Function

        'impression from zg
        Public Sub SelPrint()

            ' •—————————————————————————————————————————————————•
            ' | print only the selected text if any is selected |
            ' •—————————————————————————————————————————————————•
            If Me.SelectionLength > 0 Then
                intCharactersToPrint = Me.SelectionStart + Me.SelectionLength
                intCurrentPosition = Me.SelectionStart
            Else
                ' •—————————————————————————————————————•
                ' | otherwise print the entire document |
                ' •—————————————————————————————————————•
                intCharactersToPrint = Me.TextLength
                intCurrentPosition = 0
            End If

            m_PrintDocument.Print()

        End Sub

        ' •————————————————————————————————————————————————————————————•
        ' | Render the contents of the RichTextBox for printing         |
        ' | Return the last character printed + 1 (printing start from  |
        ' | this point for next page)                                   |
        ' •————————————————————————————————————————————————————————————•
        Private Function Print(ByVal charFrom As Integer, _
                                ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer

            ' •————————————————————————————————————•
            ' | Mark starting and ending character |
            ' •————————————————————————————————————•
            Dim cRange As CHARRANGE
            cRange.cpMin = charFrom
            cRange.cpMax = charTo

            ' •————————————————————————————————————————•
            ' | Calculate the area to render and print |
            ' •————————————————————————————————————————•
            Dim rectToPrint As RECT
            rectToPrint.Top = CInt(e.MarginBounds.Top * AnInch)
            rectToPrint.Bottom = CInt(e.MarginBounds.Bottom * AnInch)
            rectToPrint.Left = CInt(e.MarginBounds.Left * AnInch)
            rectToPrint.Right = CInt(e.MarginBounds.Right * AnInch)

            ' Calculate the size of the page
            Dim rectPage As RECT
            rectPage.Top = CInt(e.PageBounds.Top * AnInch)
            rectPage.Bottom = CInt(e.PageBounds.Bottom * AnInch)
            rectPage.Left = CInt(e.PageBounds.Left * AnInch)
            rectPage.Right = CInt(e.PageBounds.Right * AnInch)

            Dim hdc As IntPtr = e.Graphics.GetHdc()

            Dim fmtRange As FORMATRANGE
            ' •—————————————————————————————————————————•
            ' | Indicate character from to character to |
            ' •—————————————————————————————————————————•
            fmtRange.chrg = cRange
            ' •—————————————————————————————————————————————•
            ' | Use the same DC for measuring and rendering |
            ' •—————————————————————————————————————————————•
            fmtRange.hdc = hdc
            ' •——————————————————————•
            ' | Point at printer hDC |
            ' •——————————————————————•
            fmtRange.hdcTarget = hdc
            ' •————————————————————————————————————•
            ' | Indicate the area on page to print |
            ' •————————————————————————————————————•
            fmtRange.rc = rectToPrint
            ' •—————————————————————————————•
            ' | Indicate whole size of page |
            ' •—————————————————————————————•
            fmtRange.rcPage = rectPage

            Dim res As IntPtr = IntPtr.Zero

            Dim wparam As IntPtr = IntPtr.Zero
            wparam = New IntPtr(1)

            ' •——————————————————————————————————————————————————•
            ' | Move the pointer to the FORMATRANGE structure in  |
            ' | memory()                                          |
            ' •——————————————————————————————————————————————————•
            Dim lparam As IntPtr = IntPtr.Zero
            lparam = _
                Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
            Marshal.StructureToPtr(fmtRange, lparam, False)

            ' •—————————————————————————————————————•
            ' | Send the rendered data for printing |
            ' •—————————————————————————————————————•
            res = _
                SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

            ' •————————————————————————————————————•
            ' | Free the block of memory allocated |
            ' •————————————————————————————————————•
            Marshal.FreeCoTaskMem(lparam)

            ' •—————————————————————————————————————————————————•
            ' | Release the device context handle obtained by a  |
            ' | previous call                                    |
            ' •—————————————————————————————————————————————————•
            e.Graphics.ReleaseHdc(hdc)

            ' •———————————————————————————————————————•
            ' | return the last + 1 character printed |
            ' •———————————————————————————————————————•
            Return res.ToInt32

        End Function

        Public ReadOnly Property PrintDocument() As PrintDocument
            Get
                If m_PrintDocument Is Nothing Then
                    m_PrintDocument = New PrintDocument
                End If

                Return m_PrintDocument
            End Get
        End Property

        Private Sub m_PrintDocument_PrintPage(ByVal sender As _
                                                  Object, ByVal e As PrintPageEventArgs) _
            Handles m_PrintDocument.PrintPage
            ' •———————————————————————————————————————•
            ' | Print the content of the RichTextBox. |
            ' | Store the last character printed.     |
            ' •———————————————————————————————————————•

            intCurrentPosition = Me.Print(intCurrentPosition, _
                                           intCharactersToPrint, e)

            ' •—————————————————————————————————•
            ' | Look for more pages by checking |
            ' •—————————————————————————————————•
            If intCurrentPosition < intCharactersToPrint Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If

        End Sub

        'fin impresion
        Public Sub InsertOleObject(ByVal oleObj As IOleObject)
            Dim ole As New RichEditOle(Me)
            ole.InsertOleObject(oleObj)
        End Sub

        Public Sub InsertControl(ByVal control As Control)
            Dim ole As New RichEditOle(Me)
            ole.InsertControl(control)
        End Sub

        Public Sub InsertMyDataObject(ByVal mdo As myDataObject)
            Dim ole As New RichEditOle(Me)
            ole.InsertMyDataObject(mdo)
        End Sub

        Public Sub UpdateObjects()
            Dim ole As New RichEditOle(Me)
            ole.UpdateObjects()
        End Sub

        Public Sub InsertImage(ByVal image As Image)
            Dim mdo As New myDataObject()

            mdo.SetImage(image)

            Me.InsertMyDataObject(mdo)
        End Sub

        Public Sub InsertImage(ByVal imageFile As String)
            Dim mdo As New myDataObject()

            mdo.SetImage(imageFile)

            Me.InsertMyDataObject(mdo)
        End Sub

        Public Sub InsertImageFromFile(ByVal strFilename As String)
            Dim ole As New RichEditOle(Me)
            ole.InsertImageFromFile(strFilename)
        End Sub

        Public Sub InsertActiveX(ByVal strProgID As String)
            Dim t As Type = Type.GetTypeFromProgID(strProgID)
            If t Is Nothing Then
                Return
            End If

            Dim o As Object = Activator.CreateInstance(t)

            Dim b As Boolean = (TypeOf o Is IOleObject)

            If b Then
                Me.InsertOleObject(CType(o, IOleObject))
            End If
        End Sub

        ' RichEditOle wrapper and helper
        Private Class RichEditOle
            Public Const WM_USER As Integer = &H400
            Public Const EM_GETOLEINTERFACE As Integer = WM_USER + 60

            Private _richEdit As RichTextBoxPrintCtrl
            Private _RichEditOle As IRichEditOle

            Public Sub New(ByVal richEdit As RichTextBoxPrintCtrl)
                Me._richEdit = richEdit
            End Sub

            Private ReadOnly Property IRichEditOle() As IRichEditOle
                Get
                    If Me._RichEditOle Is Nothing Then
                        Me._RichEditOle = SendMessage(Me._richEdit.Handle, EM_GETOLEINTERFACE, 0)
                    End If

                    Return Me._RichEditOle
                End Get
            End Property


            <DllImport("ole32.dll", PreserveSig:=False)> _
            Friend Shared Function CreateILockBytesOnHGlobal(ByVal hGlobal As IntPtr, ByVal fDeleteOnRelease As Boolean, <Out()> ByRef ppLkbyt As ILockBytes) As Integer
            End Function

            <DllImport("ole32.dll")> _
            Shared Function StgCreateDocfileOnILockBytes(ByVal plkbyt As ILockBytes, ByVal grfMode As UInteger, ByVal reserved As UInteger, <System.Runtime.InteropServices.Out()> ByRef ppstgOpen As IStorage) As Integer
            End Function

            Public Sub InsertControl(ByVal control As Control)
                If control Is Nothing Then
                    Return
                End If

                Dim guid As Guid = Marshal.GenerateGuidForType(control.GetType())

                '-----------------------
                Dim pLockBytes As ILockBytes = Nothing
                CreateILockBytesOnHGlobal(IntPtr.Zero, True, pLockBytes)

                Dim pStorage As IStorage = Nothing
                StgCreateDocfileOnILockBytes(pLockBytes, CUInt(STGM.STGM_SHARE_EXCLUSIVE Or STGM.STGM_CREATE Or STGM.STGM_READWRITE), 0, pStorage)

                Dim pOleClientSite As IOleClientSite = Nothing
                Me.IRichEditOle.GetClientSite(pOleClientSite)
                '-----------------------

                '-----------------------
                Dim reoObject As New REOBJECT()

                reoObject.cp = Me._richEdit.TextLength

                reoObject.clsid = guid
                reoObject.pstg = pStorage
                reoObject.poleobj = Marshal.GetIUnknownForObject(control)
                reoObject.polesite = pOleClientSite
                reoObject.dvAspect = CUInt(DVASPECT.DVASPECT_CONTENT)
                reoObject.dwFlags = CUInt(REOOBJECTFLAGS.REO_BELOWBASELINE)
                reoObject.dwUser = 1

                Me.IRichEditOle.InsertObject(reoObject)
                '-----------------------

                '-----------------------
                Marshal.ReleaseComObject(pLockBytes)
                Marshal.ReleaseComObject(pOleClientSite)
                Marshal.ReleaseComObject(pStorage)
                '-----------------------
            End Sub

            Public Function InsertImageFromFile(ByVal strFilename As String) As Boolean
                '-----------------------
                Dim pLockBytes As ILockBytes = Nothing
                CreateILockBytesOnHGlobal(IntPtr.Zero, True, pLockBytes)

                Dim pStorage As IStorage = Nothing
                StgCreateDocfileOnILockBytes(pLockBytes, CUInt(STGM.STGM_SHARE_EXCLUSIVE Or STGM.STGM_CREATE Or STGM.STGM_READWRITE), 0, pStorage)

                Dim pOleClientSite As IOleClientSite = Nothing
                Me.IRichEditOle.GetClientSite(pOleClientSite)
                '-----------------------


                '-----------------------
                Dim formatEtc As New FORMATETC()

                formatEtc.cfFormat = 0
                formatEtc.ptd = IntPtr.Zero
                formatEtc.dwAspect = DVASPECT.DVASPECT_CONTENT
                formatEtc.lindex = -1
                formatEtc.tymed = TYMED.TYMED_NULL

                Dim IID_IOleObject As New Guid("{00000112-0000-0000-C000-000000000046}")
                Dim CLSID_NULL As New Guid("{00000000-0000-0000-0000-000000000000}")

                Dim pOleObjectOut As Object = Nothing

                ' I don't sure, but it appears that this function only loads from bitmap
                ' You can also try OleCreateFromData, OleLoadPictureIndirect, etc.
                Dim hr As Integer = OleCreateFromFile(CLSID_NULL, strFilename, IID_IOleObject, CUInt(OLERENDER.OLERENDER_DRAW), formatEtc, pOleClientSite, pStorage, pOleObjectOut)

                If pOleObjectOut Is Nothing Then
                    Marshal.ReleaseComObject(pLockBytes)
                    Marshal.ReleaseComObject(pOleClientSite)
                    Marshal.ReleaseComObject(pStorage)

                    Return False
                End If

                Dim pOleObject As IOleObject = CType(pOleObjectOut, IOleObject)
                '-----------------------


                '-----------------------
                Dim guid As New Guid()

                'guid = Marshal.GenerateGuidForType(pOleObject.GetType());
                pOleObject.GetUserClassID(guid)
                '-----------------------

                '-----------------------
                OleSetContainedObject(pOleObject, True)

                Dim reoObject As New REOBJECT()

                reoObject.cp = Me._richEdit.TextLength

                reoObject.clsid = guid
                reoObject.pstg = pStorage
                reoObject.poleobj = Marshal.GetIUnknownForObject(pOleObject)
                reoObject.polesite = pOleClientSite
                reoObject.dvAspect = CUInt(DVASPECT.DVASPECT_CONTENT)
                reoObject.dwFlags = CUInt(REOOBJECTFLAGS.REO_BELOWBASELINE)
                reoObject.dwUser = 0

                Me.IRichEditOle.InsertObject(reoObject)
                '-----------------------

                '-----------------------
                Marshal.ReleaseComObject(pLockBytes)
                Marshal.ReleaseComObject(pOleClientSite)
                Marshal.ReleaseComObject(pStorage)
                Marshal.ReleaseComObject(pOleObject)
                '-----------------------

                Return True
            End Function

            Public Sub InsertMyDataObject(ByVal mdo As myDataObject)
                If mdo Is Nothing Then
                    Return
                End If

                '-----------------------
                Dim pLockBytes As ILockBytes = Nothing
                Dim sc As Integer = CreateILockBytesOnHGlobal(IntPtr.Zero, True, pLockBytes)

                Dim pStorage As IStorage = Nothing
                sc = StgCreateDocfileOnILockBytes(pLockBytes, CUInt(STGM.STGM_SHARE_EXCLUSIVE Or STGM.STGM_CREATE Or STGM.STGM_READWRITE), 0, pStorage)

                Dim pOleClientSite As IOleClientSite = Nothing
                Me.IRichEditOle.GetClientSite(pOleClientSite)
                '-----------------------

                Dim guid As Guid = Marshal.GenerateGuidForType(mdo.GetType())

                Dim IID_IOleObject As New Guid("{00000112-0000-0000-C000-000000000046}")
                Dim IID_IDataObject As New Guid("{0000010e-0000-0000-C000-000000000046}")
                Dim IID_IUnknown As New Guid("{00000000-0000-0000-C000-000000000046}")

                Dim pOleObject As Object = Nothing

                Dim hr As Integer = OleCreateStaticFromData(mdo, IID_IOleObject, CUInt(OLERENDER.OLERENDER_FORMAT), mdo.mpFormatetc, pOleClientSite, pStorage, pOleObject)

                If pOleObject Is Nothing Then
                    Return
                End If
                '-----------------------


                '-----------------------
                OleSetContainedObject(pOleObject, True)

                Dim reoObject As New REOBJECT()

                reoObject.cp = Me._richEdit.TextLength

                reoObject.clsid = guid
                reoObject.pstg = pStorage
                reoObject.poleobj = Marshal.GetIUnknownForObject(pOleObject)
                reoObject.polesite = pOleClientSite
                reoObject.dvAspect = CUInt(DVASPECT.DVASPECT_CONTENT)
                reoObject.dwFlags = CUInt(REOOBJECTFLAGS.REO_BELOWBASELINE)
                reoObject.dwUser = 0

                Me.IRichEditOle.InsertObject(reoObject)
                '-----------------------

                '-----------------------
                Marshal.ReleaseComObject(pLockBytes)
                Marshal.ReleaseComObject(pOleClientSite)
                Marshal.ReleaseComObject(pStorage)
                Marshal.ReleaseComObject(pOleObject)
                '-----------------------
            End Sub

            Public Sub InsertOleObject(ByVal oleObject As IOleObject)
                If oleObject Is Nothing Then
                    Return
                End If

                '-----------------------
                Dim pLockBytes As ILockBytes = Nothing
                CreateILockBytesOnHGlobal(IntPtr.Zero, True, pLockBytes)

                Dim pStorage As IStorage = Nothing
                StgCreateDocfileOnILockBytes(pLockBytes, CUInt(STGM.STGM_SHARE_EXCLUSIVE Or STGM.STGM_CREATE Or STGM.STGM_READWRITE), 0, pStorage)

                Dim pOleClientSite As IOleClientSite = Nothing
                Me.IRichEditOle.GetClientSite(pOleClientSite)
                '-----------------------

                '-----------------------
                Dim guid As New Guid()

                oleObject.GetUserClassID(guid)
                '-----------------------

                '-----------------------
                OleSetContainedObject(oleObject, True)

                Dim reoObject As New REOBJECT()

                reoObject.cp = Me._richEdit.TextLength

                reoObject.clsid = guid
                reoObject.pstg = pStorage
                reoObject.poleobj = Marshal.GetIUnknownForObject(oleObject)
                reoObject.polesite = pOleClientSite
                reoObject.dvAspect = CUInt(DVASPECT.DVASPECT_CONTENT)
                reoObject.dwFlags = CUInt(REOOBJECTFLAGS.REO_BELOWBASELINE)

                Me.IRichEditOle.InsertObject(reoObject)
                '-----------------------

                '-----------------------
                Marshal.ReleaseComObject(pLockBytes)
                Marshal.ReleaseComObject(pOleClientSite)
                Marshal.ReleaseComObject(pStorage)
                '-----------------------
            End Sub

            Public Sub UpdateObjects()
                Dim k As Integer = Me.IRichEditOle.GetObjectCount()

                For i As Integer = 0 To k - 1
                    Dim reoObject As New REOBJECT()

                    Me.IRichEditOle.GetObject(i, reoObject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES)

                    If reoObject.dwUser = 1 Then
                        Dim pt As Point = Me._richEdit.GetPositionFromCharIndex(reoObject.cp)
                        Dim rect As New Rectangle(pt, reoObject.sizel)

                        Me._richEdit.Invalidate(rect, False) ' repaint
                    End If
                Next i
            End Sub
        End Class
    End Class

    <ComVisible(True), StructLayout(LayoutKind.Sequential)> _
    Public Class COMRECT
        Private _left As Integer

        Public Property left As Integer
            Get
                Return _left
            End Get
            Set(ByVal Value As Integer)
                _left = Value
            End Set
        End Property

        Private _top As Integer

        Public Property top As Integer
            Get
                Return _top
            End Get
            Set(ByVal Value As Integer)
                _top = Value
            End Set
        End Property

        Private _right As Integer

        Public Property right As Integer
            Get
                Return _right
            End Get
            Set(ByVal Value As Integer)
                _right = Value
            End Set
        End Property

        Private _bottom As Integer

        Public Property bottom As Integer
            Get
                Return _bottom
            End Get
            Set(ByVal Value As Integer)
                _bottom = Value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
            Me.left = left
            Me.top = top
            Me.right = right
            Me.bottom = bottom
        End Sub

        <ComVisible(False)> _
        Public Shared Function FromXYWH(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer) As COMRECT
            Return New COMRECT(x, y, x + width, y + height)
        End Function
    End Class

    Public Enum GETOBJECTOPTIONS
        REO_GETOBJ_NO_INTERFACES = &H0
        REO_GETOBJ_POLEOBJ = &H1
        REO_GETOBJ_PSTG = &H2
        REO_GETOBJ_POLESITE = &H4
        REO_GETOBJ_ALL_INTERFACES = &H7
    End Enum

    Public Enum GETCLIPBOARDDATAFLAGS
        RECO_PASTE = 0
        RECO_DROP = 1
        RECO_COPY = 2
        RECO_CUT = 3
        RECO_DRAG = 4
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure CHARRANGE
        Public cpMin As Integer
        Public cpMax As Integer

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Class REOBJECT
        Implements IDisposable

        Private _cbStruct As Integer = Marshal.SizeOf(GetType(REOBJECT))

        Public Property cbStruct As Integer
            Get
                Return _cbStruct
            End Get
            Set(ByVal Value As Integer)
                _cbStruct = Value
            End Set
        End Property ' Size of structure

        Private _cp As Integer

        Public Property cp As Integer
            Get
                Return _cp
            End Get
            Set(ByVal Value As Integer)
                _cp = Value
            End Set
        End Property ' Character position of object

        Private _clsid As Guid

        Public Property clsid As Guid
            Get
                Return _clsid
            End Get
            Set(ByVal Value As Guid)
                _clsid = Value
            End Set
        End Property ' Class ID of object

        Private _poleobj As IntPtr

        Public Property poleobj As IntPtr
            Get
                Return _poleobj
            End Get
            Set(ByVal Value As IntPtr)
                _poleobj = Value
            End Set
        End Property ' OLE object interface
        Private _pstg As IStorage

        Public Property pstg As IStorage
            Get
                Return _pstg
            End Get
            Set(ByVal Value As IStorage)
                _pstg = Value
            End Set
        End Property ' Associated storage interface

        Private _polesite As IOleClientSite

        Public Property polesite As IOleClientSite
            Get
                Return _polesite
            End Get
            Set(ByVal Value As IOleClientSite)
                _polesite = Value
            End Set
        End Property ' Associated client site interface

        Private _sizel As Size

        Public Property sizel As Size
            Get
                Return _sizel
            End Get
            Set(ByVal Value As Size)
                _sizel = Value
            End Set
        End Property ' Size of object (may be 0,0)

        Private _dvAspect As UInteger

        Public Property dvAspect As UInteger
            Get
                Return _dvAspect
            End Get
            Set(ByVal Value As UInteger)
                _dvAspect = Value
            End Set
        End Property ' Display aspect to use

        Private _dwFlags As UInteger

        Public Property dwFlags As UInteger
            Get
                Return _dwFlags
            End Get
            Set(ByVal Value As UInteger)
                _dwFlags = Value
            End Set
        End Property ' Object status flags

        Private _dwUser As UInteger

        Public Property dwUser As UInteger
            Get
                Return _dwUser
            End Get
            Set(ByVal Value As UInteger)
                _dwUser = Value
            End Set
        End Property ' Dword for user's use

        Protected disposed As Boolean ' = False

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            SyncLock Me
                ' Do nothing if the object has already been disposed of.
                If disposed Then Exit Sub

                If disposing Then
                    ' Release diposable objects used by this instance here.

                End If

                ' Release unmanaged resources here. Don't access reference type fields.

                ' Remember that the object has been disposed of.
                disposed = True
            End SyncLock
        End Sub

        Public Overridable Sub Dispose() _
          Implements IDisposable.Dispose
            Dispose(False)
            ' Unregister object for finalization.
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose(False)
            Catch
                ' Deal with errors or just ignore them
            Finally
                ' Invoke the base object's Finalize method.
                MyBase.Finalize()
            End Try
        End Sub

    End Class

    <ComVisible(True), Guid("0000010F-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IAdviseSink

        'C#r: UNDONE (Field in interface) public static readonly    Guid iid;
        Sub OnDataChange(<[In]()> ByVal pFormatetc As FORMATETC, <[In]()> ByVal pStgmed As STGMEDIUM)

        Sub OnViewChange(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwAspect As Integer, <[In](), MarshalAs(UnmanagedType.I4)> ByVal lindex As Integer)

        Sub OnRename(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal pmk As Object)

        Sub OnSave()


        Sub OnClose()
    End Interface

    <ComVisible(False), StructLayout(LayoutKind.Sequential)> _
    Public NotInheritable Class STATDATA

        <MarshalAs(UnmanagedType.U4)> _
        Private _advf As Integer

        Public Property advf As Integer
            Get
                Return _advf
            End Get
            Set(ByVal Value As Integer)
                _advf = Value
            End Set
        End Property

        <MarshalAs(UnmanagedType.U4)> _
        Private _dwConnection As Integer

        Public Property dwConnection As Integer
            Get
                Return _dwConnection
            End Get
            Set(ByVal Value As Integer)
                _dwConnection = Value
            End Set
        End Property

    End Class

    <ComVisible(False), StructLayout(LayoutKind.Sequential)> _
    Public NotInheritable Class tagOLEVERB
        <MarshalAs(UnmanagedType.I4)> _
        Private _lVerb As Integer

        Public Property lVerb As Integer
            Get
                Return _lVerb
            End Get
            Set(ByVal Value As Integer)
                _lVerb = Value
            End Set
        End Property

        <MarshalAs(UnmanagedType.LPWStr)> _
        Private _lpszVerbName As String

        Public Property lpszVerbName As String
            Get
                Return _lpszVerbName
            End Get
            Set(ByVal Value As String)
                _lpszVerbName = Value
            End Set
        End Property

        <MarshalAs(UnmanagedType.U4)> _
        Private _fuFlags As Integer

        Public Property fuFlags As Integer
            Get
                Return _fuFlags
            End Get
            Set(ByVal Value As Integer)
                _fuFlags = Value
            End Set
        End Property

        <MarshalAs(UnmanagedType.U4)> _
        Private _grfAttribs As Integer

        Public Property grfAttribs As Integer
            Get
                Return _grfAttribs
            End Get
            Set(ByVal Value As Integer)
                _grfAttribs = Value
            End Set
        End Property

    End Class

    <ComVisible(True), ComImport(), Guid("00000104-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumOLEVERB

        <PreserveSig()> _
        Function [Next](<MarshalAs(UnmanagedType.U4)> ByVal celt As Integer, <Out()> ByVal rgelt As tagOLEVERB, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal pceltFetched() As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Skip(<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        Sub Reset()


        Sub Clone(<System.Runtime.InteropServices.Out()> ByRef ppenum As IEnumOLEVERB)


    End Interface

    <ComVisible(True), Guid("00000105-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumSTATDATA

        'C#r: UNDONE (Field in interface) public static readonly    Guid iid;

        Sub [Next](<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer, <Out()> ByVal rgelt As STATDATA, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal pceltFetched() As Integer)


        Sub Skip(<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer)


        Sub Reset()


        Sub Clone(<Out(), MarshalAs(UnmanagedType.LPArray)> ByVal ppenum() As IEnumSTATDATA)


    End Interface

    <ComVisible(True), Guid("0000011B-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleContainer


        Sub ParseDisplayName(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal pbc As Object, <[In](), MarshalAs(UnmanagedType.BStr)> ByVal pszDisplayName As String, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal pchEaten() As Integer, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal ppmkOut() As Object)


        Sub EnumObjects(<[In](), MarshalAs(UnmanagedType.U4)> ByVal grfFlags As Integer, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal ppenum() As Object)


        Sub LockContainer(<[In](), MarshalAs(UnmanagedType.I4)> ByVal fLock As Integer)
    End Interface

    <ComVisible(True), ComImport(), Guid("0000010E-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IDataObject

        'Function EnumDAdvise(ByRef ppenumAdvise As IEnumSTATDATA) As UInteger

        <PreserveSig()> _
        Function GetData(ByRef a As FORMATETC, ByRef b As STGMEDIUM) As UInteger

        <PreserveSig()> _
        Function GetDataHere(ByRef pFormatetc As FORMATETC, <System.Runtime.InteropServices.Out()> ByRef pMedium As STGMEDIUM) As UInteger

        <PreserveSig()> _
        Function QueryGetData(ByRef pFormatetc As FORMATETC) As UInteger

        <PreserveSig()> _
        Function GetCanonicalFormatEtc(ByRef pformatectIn As FORMATETC, <System.Runtime.InteropServices.Out()> ByRef pformatetcOut As FORMATETC) As UInteger

        <PreserveSig()> _
        Function SetData(ByRef pFormatectIn As FORMATETC, ByRef pmedium As STGMEDIUM, <[In](), MarshalAs(UnmanagedType.Bool)> ByVal fRelease As Boolean) As UInteger

        <PreserveSig()> _
        Function EnumFormatEtc(ByVal dwDirection As UInteger, ByVal penum As IEnumFORMATETC) As UInteger

        <PreserveSig()> _
        Function DAdvise(ByRef pFormatetc As FORMATETC, ByVal advf As Integer, <[In](), MarshalAs(UnmanagedType.Interface)> ByVal pAdvSink As IAdviseSink, <System.Runtime.InteropServices.Out()> ByRef pdwConnection As UInteger) As UInteger

        <PreserveSig()> _
        Function DUnadvise(ByVal dwConnection As UInteger) As UInteger

        <PreserveSig()> _
        Function EnumDAdvise(<Out(), MarshalAs(UnmanagedType.Interface)> ByVal ppenumAdvise As IEnumSTATDATA) As UInteger
    End Interface

    <ComVisible(True), Guid("00000118-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleClientSite

        <PreserveSig()> _
        Function SaveObject() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetMoniker(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwAssign As Integer, <[In](), MarshalAs(UnmanagedType.U4)> ByVal dwWhichMoniker As Integer, <Out(), MarshalAs(UnmanagedType.Interface)> ByVal ppmk As Object) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetContainer(<System.Runtime.InteropServices.Out(), MarshalAs(UnmanagedType.Interface)> ByRef container As IOleContainer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ShowObject() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function OnShowWindow(<[In](), MarshalAs(UnmanagedType.I4)> ByVal fShow As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function RequestNewObjectLayout() As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    <ComVisible(False), StructLayout(LayoutKind.Sequential)> _
    Public NotInheritable Class tagLOGPALETTE
        <MarshalAs(UnmanagedType.U2)> _
        Private _palVersion As Short

        Public Property palVersion As Short
            Get
                Return _palVersion
            End Get
            Set(ByVal Value As Short)
                _palVersion = Value
            End Set
        End Property 'leftover(offset=0, palVersion)

        <MarshalAs(UnmanagedType.U2)> _
        Private _palNumEntries As Short

        Public Property palNumEntries As Short
            Get
                Return _palNumEntries
            End Get
            Set(ByVal Value As Short)
                _palNumEntries = Value
            End Set
        End Property 'leftover(offset=2, palNumEntries)

        ' UNMAPPABLE: palPalEntry: Cannot be used as a structure field.
        '   /** @com.structmap(UNMAPPABLE palPalEntry) */
        '  public UNMAPPABLE palPalEntry;
    End Class

    <ComVisible(True), ComImport(), Guid("00000112-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleObject

        <PreserveSig()> _
        Function SetClientSite(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal pClientSite As IOleClientSite) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetClientSite(<System.Runtime.InteropServices.Out()> ByRef site As IOleClientSite) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetHostNames(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal szContainerApp As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal szContainerObj As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Close(<[In](), MarshalAs(UnmanagedType.I4)> ByVal dwSaveOption As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetMoniker(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwWhichMoniker As Integer, <[In](), MarshalAs(UnmanagedType.Interface)> ByVal pmk As Object) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetMoniker(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwAssign As Integer, <[In](), MarshalAs(UnmanagedType.U4)> ByVal dwWhichMoniker As Integer, <System.Runtime.InteropServices.Out()> ByRef moniker As Object) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function InitFromData(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal pDataObject As IDataObject, <[In](), MarshalAs(UnmanagedType.I4)> ByVal fCreation As Integer, <[In](), MarshalAs(UnmanagedType.U4)> ByVal dwReserved As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        Function GetClipboardData(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwReserved As Integer, <System.Runtime.InteropServices.Out()> ByRef data As IDataObject) As Integer

        <PreserveSig()> _
        Function DoVerb(<[In](), MarshalAs(UnmanagedType.I4)> ByVal iVerb As Integer, <[In]()> ByVal lpmsg As IntPtr, <[In](), MarshalAs(UnmanagedType.Interface)> ByVal pActiveSite As IOleClientSite, <[In](), MarshalAs(UnmanagedType.I4)> ByVal lindex As Integer, <[In]()> ByVal hwndParent As IntPtr, <[In]()> ByVal lprcPosRect As COMRECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function EnumVerbs(<System.Runtime.InteropServices.Out()> ByRef e As IEnumOLEVERB) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Update() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function IsUpToDate() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetUserClassID(<[In](), Out()> ByRef pClsid As Guid) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetUserType(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwFormOfType As Integer, <Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal userType As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetExtent(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwDrawAspect As Integer, <[In]()> ByVal pSizel As Size) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetExtent(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwDrawAspect As Integer, <Out()> ByVal pSizel As Size) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Advise(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal pAdvSink As IAdviseSink, <System.Runtime.InteropServices.Out()> ByRef cookie As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Unadvise(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwConnection As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function EnumAdvise(<System.Runtime.InteropServices.Out()> ByRef e As IEnumSTATDATA) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetMiscStatus(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwAspect As Integer, <System.Runtime.InteropServices.Out()> ByRef misc As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetColorScheme(<[In]()> ByVal pLogpal As tagLOGPALETTE) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    <ComImport(), Guid("0000000d-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumSTATSTG
        ' The user needs to allocate an STATSTG array whose size is celt.
        <PreserveSig()> _
        Function [Next](ByVal celt As UInteger, <MarshalAs(UnmanagedType.LPArray), Out()> ByVal rgelt() As System.Runtime.InteropServices.ComTypes.STATSTG, <System.Runtime.InteropServices.Out()> ByRef pceltFetched As UInteger) As UInteger

        Sub Skip(ByVal celt As UInteger)

        Sub Reset()

        Function Clone() As <MarshalAs(UnmanagedType.Interface)> IEnumSTATSTG
    End Interface

    <ComImport(), Guid("0000000b-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IStorage
        Function CreateStream(ByVal pwcsName As String, ByVal grfMode As UInteger, ByVal reserved1 As UInteger, ByVal reserved2 As UInteger, <System.Runtime.InteropServices.Out()> ByRef ppstm As IStream) As Integer ' [out]  -  [in]  -  [in]  -  [in]  -  [string][in] 

        Function OpenStream(ByVal pwcsName As String, ByVal reserved1 As IntPtr, ByVal grfMode As UInteger, ByVal reserved2 As UInteger, <System.Runtime.InteropServices.Out()> ByRef ppstm As IStream) As Integer ' [out]  -  [in]  -  [in]  -  [unique][in]  -  [string][in] 

        Function CreateStorage(ByVal pwcsName As String, ByVal grfMode As UInteger, ByVal reserved1 As UInteger, ByVal reserved2 As UInteger, <System.Runtime.InteropServices.Out()> ByRef ppstg As IStorage) As Integer ' [out]  -  [in]  -  [in]  -  [in]  -  [string][in] 

        Function OpenStorage(ByVal pwcsName As String, ByVal pstgPriority As IStorage, ByVal grfMode As UInteger, ByVal snbExclude As IntPtr, ByVal reserved As UInteger, <System.Runtime.InteropServices.Out()> ByRef ppstg As IStorage) As Integer ' [out]  -  [in]  -  [unique][in]  -  [in]  -  [unique][in]  -  [string][unique][in] 

        Function CopyTo(ByVal ciidExclude As UInteger, ByVal rgiidExclude As Guid, ByVal snbExclude As IntPtr, ByVal pstgDest As IStorage) As Integer ' [unique][in]  -  [unique][in]  -  [size_is][unique][in]  -  [in] 

        Function MoveElementTo(ByVal pwcsName As String, ByVal pstgDest As IStorage, ByVal pwcsNewName As String, ByVal grfFlags As UInteger) As Integer ' [in]  -  [string][in]  -  [unique][in]  -  [string][in] 

        Function Commit(ByVal grfCommitFlags As UInteger) As Integer ' [in] 

        Function Revert() As Integer

        Function EnumElements(ByVal reserved1 As UInteger, ByVal reserved2 As IntPtr, ByVal reserved3 As UInteger, <System.Runtime.InteropServices.Out()> ByRef ppenum As IEnumSTATSTG) As Integer ' [out]  -  [in]  -  [size_is][unique][in]  -  [in] 

        Function DestroyElement(ByVal pwcsName As String) As Integer ' [string][in] 

        Function RenameElement(ByVal pwcsOldName As String, ByVal pwcsNewName As String) As Integer ' [string][in]  -  [string][in] 

        Function SetElementTimes(ByVal pwcsName As String, ByVal pctime As System.Runtime.InteropServices.ComTypes.FILETIME, ByVal patime As System.Runtime.InteropServices.ComTypes.FILETIME, ByVal pmtime As System.Runtime.InteropServices.ComTypes.FILETIME) As Integer ' [unique][in]  -  [unique][in]  -  [unique][in]  -  [string][unique][in] 

        Function SetClass(ByVal clsid As Guid) As Integer ' [in] 

        Function SetStateBits(ByVal grfStateBits As UInteger, ByVal grfMask As UInteger) As Integer ' [in]  -  [in] 

        Function Stat(<System.Runtime.InteropServices.Out()> ByRef pstatstg As System.Runtime.InteropServices.ComTypes.STATSTG, ByVal grfStatFlag As UInteger) As Integer ' [in]  -  [out] 

    End Interface

    <ComImport(), Guid("0000000a-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface ILockBytes
        Function ReadAt(ByVal ulOffset As ULong, ByVal pv As IntPtr, ByVal cb As UInteger, <System.Runtime.InteropServices.Out()> ByRef pcbRead As IntPtr) As Integer ' [out]  -  [in]  -  [unique][out]  -  [in] 

        Function WriteAt(ByVal ulOffset As ULong, ByVal pv As IntPtr, ByVal cb As UInteger, <System.Runtime.InteropServices.Out()> ByRef pcbWritten As IntPtr) As Integer ' [out]  -  [in]  -  [size_is][in]  -  [in] 

        Function Flush() As Integer

        Function SetSize(ByVal cb As ULong) As Integer ' [in] 

        Function LockRegion(ByVal libOffset As ULong, ByVal cb As ULong, ByVal dwLockType As UInteger) As Integer ' [in]  -  [in]  -  [in] 

        Function UnlockRegion(ByVal libOffset As ULong, ByVal cb As ULong, ByVal dwLockType As UInteger) As Integer ' [in]  -  [in]  -  [in] 

        Function Stat(<System.Runtime.InteropServices.Out()> ByRef pstatstg As System.Runtime.InteropServices.ComTypes.STATSTG, ByVal grfStatFlag As UInteger) As Integer ' [in]  -  [out] 

    End Interface

    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")> _
    Public Interface ISequentialStream
        Function Read(ByVal pv As IntPtr, ByVal cb As UInteger, <System.Runtime.InteropServices.Out()> ByRef pcbRead As UInteger) As Integer ' [out]  -  [in]  -  [length_is][size_is][out] 

        Function Write(ByVal pv As IntPtr, ByVal cb As UInteger, <System.Runtime.InteropServices.Out()> ByRef pcbWritten As UInteger) As Integer ' [out]  -  [in]  -  [size_is][in] 

    End Interface

    <ComImport(), Guid("0000000c-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IStream
        Inherits ISequentialStream
        Function Seek(ByVal dlibMove As ULong, ByVal dwOrigin As UInteger, <System.Runtime.InteropServices.Out()> ByRef plibNewPosition As ULong) As Integer ' [out]  -  [in]  -  [in] 

        Function SetSize(ByVal libNewSize As ULong) As Integer ' [in] 

        Function CopyTo(<[In]()> ByVal pstm As IStream, ByVal cb As ULong, <System.Runtime.InteropServices.Out()> ByRef pcbRead As ULong, <System.Runtime.InteropServices.Out()> ByRef pcbWritten As ULong) As Integer ' [out]  -  [out]  -  [in]  -  [unique][in] 

        Function Commit(ByVal grfCommitFlags As UInteger) As Integer ' [in] 

        Function Revert() As Integer

        Function LockRegion(ByVal libOffset As ULong, ByVal cb As ULong, ByVal dwLockType As UInteger) As Integer ' [in]  -  [in]  -  [in] 

        Function UnlockRegion(ByVal libOffset As ULong, ByVal cb As ULong, ByVal dwLockType As UInteger) As Integer ' [in]  -  [in]  -  [in] 

        Function Stat(<System.Runtime.InteropServices.Out()> ByRef pstatstg As System.Runtime.InteropServices.ComTypes.STATSTG, ByVal grfStatFlag As UInteger) As Integer ' [in]  -  [out] 

        Function Clone(<System.Runtime.InteropServices.Out()> ByRef ppstm As IStream) As Integer ' [out] 

    End Interface

    ''' <summary>
    ''' Definition for interface IPersist.
    ''' </summary>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010c-0000-0000-C000-000000000046")> _
    Public Interface IPersist
        ''' <summary>
        ''' getClassID
        ''' </summary>
        ''' <param name="pClassID"></param>
        Sub GetClassID(<System.Runtime.InteropServices.Out()> ByRef pClassID As Guid) ' [out] 
    End Interface

    ''' <summary>
    ''' Definition for interface IPersistStream.
    ''' </summary>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000109-0000-0000-C000-000000000046")> _
    Public Interface IPersistStream
        Inherits IPersist
        ''' <summary>
        ''' GetClassID
        ''' </summary>
        ''' <param name="pClassID"></param>
        Shadows Sub GetClassID(<System.Runtime.InteropServices.Out()> ByRef pClassID As Guid)
        ''' <summary>
        ''' isDirty
        ''' </summary>
        ''' <returns></returns>
        <PreserveSig()> _
        Function IsDirty() As Integer
        ''' <summary>
        ''' Load
        ''' </summary>
        ''' <param name="pStm"></param>
        Sub Load(<[In]()> ByVal pStm As IStream)
        ''' <summary>
        ''' Save
        ''' </summary>
        ''' <param name="pStm"></param>
        ''' <param name="fClearDirty"></param>
        Sub Save(<[In]()> ByVal pStm As IStream, <[In](), MarshalAs(UnmanagedType.Bool)> ByVal fClearDirty As Boolean)
        ''' <summary>
        ''' GetSizeMax
        ''' </summary>
        ''' <param name="pcbSize"></param>
        Sub GetSizeMax(<System.Runtime.InteropServices.Out()> ByRef pcbSize As Long)
    End Interface

    <ComImport(), Guid("00020D00-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IRichEditOle
        <PreserveSig()> _
        Function GetClientSite(<System.Runtime.InteropServices.Out()> ByRef site As IOleClientSite) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetObjectCount() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetLinkCount() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetObject(ByVal iob As Integer, <[In](), Out()> ByVal lpreobject As REOBJECT, <MarshalAs(UnmanagedType.U4)> ByVal flags As GETOBJECTOPTIONS) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function InsertObject(ByVal lpreobject As REOBJECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ConvertObject(ByVal iob As Integer, ByVal rclsidNew As Guid, ByVal lpstrUserTypeNew As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ActivateAs(ByVal rclsid As Guid, ByVal rclsidAs As Guid) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetHostNames(ByVal lpstrContainerApp As String, ByVal lpstrContainerObj As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetLinkAvailable(ByVal iob As Integer, ByVal fAvailable As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetDvaspect(ByVal iob As Integer, ByVal dvaspect As UInteger) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function HandsOffStorage(ByVal iob As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SaveCompleted(ByVal iob As Integer, ByVal lpstg As IStorage) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function InPlaceDeactivate() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ContextSensitiveHelp(ByVal fEnterMode As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetClipboardData(<[In](), Out()> ByRef lpchrg As CHARRANGE, <MarshalAs(UnmanagedType.U4)> ByVal reco As GETCLIPBOARDDATAFLAGS, <System.Runtime.InteropServices.Out()> ByRef lplpdataobj As IDataObject) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ImportDataObject(ByVal lpdataobj As IDataObject, ByVal cf As Integer, ByVal hMetaPict As IntPtr) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    Public Class myDataObject
        Implements IDataObject

        Private mBitmap As Bitmap
        Public mpFormatetc As FORMATETC

        Private Const S_OK As UInteger = 0
        Private Const E_POINTER As UInteger = &H80004003L
        Private Const E_NOTIMPL As UInteger = &H80004001L
        Private Const E_FAIL As UInteger = &H80004005L

        Public Function GetData(ByRef pFormatetc As FORMATETC, ByRef pMedium As STGMEDIUM) As UInteger Implements IDataObject.GetData
            Dim hDst As IntPtr = mBitmap.GetHbitmap()

            pMedium.tymed = CInt(TYMED.TYMED_GDI)
            pMedium.unionmember = hDst
            pMedium.pUnkForRelease = IntPtr.Zero

            Return CUInt(S_OK)
        End Function

        Public Function GetDataHere(ByRef pFormatetc As FORMATETC, <System.Runtime.InteropServices.Out()> ByRef pMedium As STGMEDIUM) As UInteger Implements IDataObject.GetDataHere
            Trace.WriteLine("GetDataHere")

            pMedium = New STGMEDIUM()

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function QueryGetData(ByRef pFormatetc As FORMATETC) As UInteger Implements IDataObject.QueryGetData
            Trace.WriteLine("QueryGetData")

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function GetCanonicalFormatEtc(ByRef pFormatetcIn As FORMATETC, <System.Runtime.InteropServices.Out()> ByRef pFormatetcOut As FORMATETC) As UInteger Implements IDataObject.GetCanonicalFormatEtc
            Trace.WriteLine("GetCanonicalFormatEtc")

            pFormatetcOut = New FORMATETC()

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function SetData(ByRef a As FORMATETC, ByRef b As STGMEDIUM, ByVal fRelease As Boolean) As UInteger Implements IDataObject.SetData
            'mpFormatetc = pFormatectIn;
            'mpmedium = pmedium;

            Trace.WriteLine("SetData")

            Return CUInt(CInt(Fix(S_OK)))
        End Function

        Public Function EnumFormatEtc(ByVal dwDirection As UInteger, ByVal penum As IEnumFORMATETC) As UInteger Implements IDataObject.EnumFormatEtc
            Trace.WriteLine("EnumFormatEtc")

            Return CUInt(CInt(Fix(S_OK)))
        End Function

        Public Function DAdvise(ByRef a As FORMATETC, ByVal advf As Integer, ByVal pAdvSink As IAdviseSink, <System.Runtime.InteropServices.Out()> ByRef pdwConnection As UInteger) As UInteger Implements IDataObject.DAdvise
            Trace.WriteLine("DAdvise")

            pdwConnection = 0

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function DUnadvise(ByVal dwConnection As UInteger) As UInteger Implements IDataObject.DUnadvise
            Trace.WriteLine("DUnadvise")

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function EnumDAdvise(ByVal ppenumAdvise As IEnumSTATDATA) As UInteger Implements IDataObject.EnumDAdvise
            Trace.WriteLine("EnumDAdvise")

            ppenumAdvise = Nothing

            Return CUInt(E_NOTIMPL)
        End Function

        Public Sub New()
            mBitmap = New Bitmap(16, 16)
            mpFormatetc = New FORMATETC()
        End Sub

        Public Sub SetImage(ByVal strFilename As String)
            Try
                mBitmap = CType(Bitmap.FromFile(strFilename, True), Bitmap)

                mpFormatetc.cfFormat = CLIPFORMAT.CF_BITMAP ' Clipboard format = CF_BITMAP
                mpFormatetc.ptd = IntPtr.Zero ' Target Device = Screen
                mpFormatetc.dwAspect = DVASPECT.DVASPECT_CONTENT ' Level of detail = Full content
                mpFormatetc.lindex = -1 ' Index = Not applicaple
                mpFormatetc.tymed = TYMED.TYMED_GDI ' Storage medium = HBITMAP handle
            Catch
            End Try
        End Sub

        Public Sub SetImage(ByVal image As Image)
            Try
                mBitmap = New Bitmap(image)

                mpFormatetc.cfFormat = CLIPFORMAT.CF_BITMAP ' Clipboard format = CF_BITMAP
                mpFormatetc.ptd = IntPtr.Zero ' Target Device = Screen
                mpFormatetc.dwAspect = DVASPECT.DVASPECT_CONTENT ' Level of detail = Full content
                mpFormatetc.lindex = -1 ' Index = Not applicaple
                mpFormatetc.tymed = TYMED.TYMED_GDI ' Storage medium = HBITMAP handle
            Catch
            End Try
        End Sub

        'Public Function EnumDAdvise(ByVal ppenumAdvise As IEnumSTATDATA) As UInteger Implements IDataObject.EnumDAdvise

        'End Function
    End Class


End Namespace
