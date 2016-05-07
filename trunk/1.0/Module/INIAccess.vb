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
Module INIAccess

    ' standard API declarations for K!TV INI access
    ' changing only "As Long" to "As Int32" (As Integer would work also)
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" ( _
                                                                                                          ByVal _
                                                                                                             lpApplicationName _
                                                                                                             As String, _
                                                                                                          ByVal _
                                                                                                             lpKeyName _
                                                                                                             As String, _
                                                                                                          ByVal LPString _
                                                                                                             As String, _
                                                                                                          ByVal _
                                                                                                             lpFileName _
                                                                                                             As String) _
        As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" ( _
                                                                                                      ByVal _
                                                                                                         lpApplicationName _
                                                                                                         As String, _
                                                                                                      ByVal lpKeyName As _
                                                                                                         String, _
                                                                                                      ByVal lpDefault As _
                                                                                                         String, _
                                                                                                      ByVal _
                                                                                                         lpReturnedString _
                                                                                                         As String, _
                                                                                                      ByVal nSize As _
                                                                                                         Integer, _
                                                                                                      ByVal lpFileName _
                                                                                                         As String) _
        As Integer
    Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" ( _
                                                                                                        ByVal _
                                                                                                           lpApplicationName _
                                                                                                           As String, _
                                                                                                        ByVal _
                                                                                                           lpszReturnBuffer _
                                                                                                           As String, _
                                                                                                        ByVal nSize As _
                                                                                                           Integer, _
                                                                                                        ByVal lpFileName _
                                                                                                           As String) _
        As Integer

    Public Function INIRead(ByVal INIPath As String, ByVal SectionName As String, ByVal KeyName As String, _
                             ByVal DefaultValue As String, ByVal BufferSize As Short) As String

        ' primary version of call gets single value given all parameters
        Try
            Dim n As Integer
            Dim sData As String
            sData = New String(" "c, BufferSize)

            ' allocate some room
            n = GetPrivateProfileString(SectionName, KeyName, DefaultValue, sData, sData.Length, INIPath)
            If n > 0 Then ' return whatever it gave us
                INIRead = Mid(sData, 1, n)

                ' vers dotnet pur
            Else
                INIRead = ""
            End If
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function INIRead_Value(ByVal INIPath As String, ByVal SectionName As String, ByVal KeyName As String) _
        As String

        ' overload 1 assumes zero-length default
        Return INIRead(INIPath, SectionName, KeyName, vbNullString, 4096)
    End Function

    Public Function INIRead_KeyNames(ByVal INIPath As String, ByVal SectionName As String) As String

        ' overload 2 returns all keys in a given section of the given file
        Return INIRead(INIPath, SectionName, vbNullString, vbNullString, 4096)
    End Function

    Public Function INIRead_SectionNames(ByVal INIPath As String) As String

        ' overload 3 returns all section names given just path
        Return INIRead(INIPath, vbNullString, vbNullString, vbNullString, 4096)
    End Function

    Public Function INIRead_Section(ByVal INIPath As String, ByVal SectionName As String) As String

        ' return a whole section in one string
        Dim n As Integer
        Dim sData As String
        sData = New String(" "c, 32000)

        ' allocate some room
        n = GetPrivateProfileSection(SectionName, sData, sData.Length, INIPath)
        If n > 0 Then ' return whatever it gave us
            INIRead_Section = Mid(sData, 1, n)

            ' vers dotnet pur
        Else
            INIRead_Section = ""
        End If
    End Function

    Public Sub INIWrite(ByVal INIPath As String, ByVal SectionName As String, ByVal KeyName As String, _
                         ByVal TheValue As String)
        WritePrivateProfileString(SectionName, KeyName, TheValue, INIPath)
    End Sub

    Public Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String, ByVal KeyName As String) _

        ' delete single line from section
        WritePrivateProfileString(SectionName, KeyName, vbNullString, INIPath)
    End Sub

    Public Sub INIDelete_Section(ByVal INIPath As String, ByVal SectionName As String)

        ' delete section from INI file
        WritePrivateProfileString(SectionName, vbNullString, vbNullString, INIPath)
    End Sub
End Module