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
Imports System.IO
Imports System.Net

Public Class WebFileDownloader
    Public Event AmountDownloadedChanged(iNewProgress As Long)
    Public Event FileDownloadSizeObtained(iFileSize As Long)
    Public Event FileDownloadComplete()
    Public Event FileDownloadFailed(ex As Exception)

    Private _mCurrentFile As String = String.Empty

    Public ReadOnly Property CurrentFile As String
        Get
            Return _mCurrentFile
        End Get
    End Property

    Public Function DownloadFile(url As String, location As String) As Boolean

        Try
            _mCurrentFile = GetFileName(url)
            Dim wc As New WebClient
            wc.DownloadFile(url, location)
            RaiseEvent FileDownloadComplete()
            Return True

        Catch ex As Exception
            RaiseEvent FileDownloadFailed(ex)
            Return False
        End Try
    End Function

    Private Function GetFileName(url As String) As String

        Try
            Return url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1)
        Catch ex As Exception
            Return url
        End Try
    End Function

    Public Function DownloadFileWithProgress(url As String, location As String) As Boolean

        Dim fs As FileStream = Nothing
        Try
            _mCurrentFile = GetFileName(url)
            Dim wRemote As WebRequest
            Dim bBuffer As Byte()
            ReDim bBuffer(256)
            Dim iBytesRead As Integer
            Dim iTotalBytesRead As Integer

            fs = New FileStream(location, FileMode.Create, FileAccess.Write)
            wRemote = WebRequest.Create(url)
            Dim myWebResponse As WebResponse = wRemote.GetResponse
            RaiseEvent FileDownloadSizeObtained(myWebResponse.ContentLength)
            Dim sChunks As Stream = myWebResponse.GetResponseStream
            Do
                iBytesRead = sChunks.Read(bBuffer, 0, 256)
                fs.Write(bBuffer, 0, iBytesRead)
                iTotalBytesRead += iBytesRead
                If myWebResponse.ContentLength < iTotalBytesRead Then
                    RaiseEvent AmountDownloadedChanged(myWebResponse.ContentLength)
                Else
                    RaiseEvent AmountDownloadedChanged(iTotalBytesRead)
                End If
            Loop While Not iBytesRead = 0
            sChunks.Close()
            fs.Close()
            RaiseEvent FileDownloadComplete()
            Return True
        Catch ex As Exception
            If Not (fs Is Nothing) Then
                fs.Close()
            End If
            RaiseEvent FileDownloadFailed(ex)
            Return False
        End Try
    End Function

    Public Shared Function FormatFileSize(size As Long) As String

        Try
            Const kb As Integer = 1024
            Dim mb As Integer = kb * kb

            Select Case size / kb
                Case Is < 1000
                    Return (size / kb).ToString("N") & " KB"
                Case Is < 1000000
                    Return (size / mb).ToString("N") & " MB"
                Case Is < 10000000
                    Return (size / mb / kb).ToString("N") & " GB"
                Case Else
                    Return size.ToString
            End Select

        Catch ex As Exception
            Return size.ToString
        End Try
    End Function
End Class

