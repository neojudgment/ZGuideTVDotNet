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

Public Class ZGuideTvDotNetUpdate

    Private _
        Const UrlMessage As String =
        "http://download-codeplex.sec.s-msft.com/Download/Release?ProjectName=zguidetv&DownloadId=616530&FileTime=130752156029000000&Build=21031#/ZGuideTVDotNet.exe"

    Private ReadOnly _dirMessage As String = My.Computer.FileSystem.SpecialDirectories.Temp
    Private WithEvents _downloader As WebFileDownloader

    ' 10/09/2015 Griser et désactiver la croix rouge de la form
    Private Const CsNoclose As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CsNoclose
            Return cp
        End Get
    End Property

    Private Function GetFileNameFromURL(url As String) As String

        If url.IndexOf("/"c) = -1 Then Return String.Empty

        Return "\" & url.Substring(url.LastIndexOf("/"c) + 1)
    End Function

    Private Sub _Downloader_FileDownloadSizeObtained(iFileSize As Long) Handles _downloader.FileDownloadSizeObtained

        ProgBar.Value = 0
        ProgBar.Maximum = Convert.ToInt32(iFileSize)
    End Sub

    Private Sub _Downloader_FileDownloadComplete() Handles _downloader.FileDownloadComplete

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le FileDownloadComplete de ZGuideTVDotNetUpdate et on lance la mise à jour")
        Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "\ZGuideTVDotNet.exe", "/silent")
        Close()
    End Sub

    Private Sub _Downloader_FileDownloadFailed(ex As Exception) Handles _downloader.FileDownloadFailed

        Trace.WriteLine(DateTime.Now & " " & "Erreur dans le FileDownloadFailed de ZGuideTVDotNetUpdate" & ex.Message)
        MessageBox.Show("Une erreur est survenue lors du téléchargement: " & ex.Message)
    End Sub

    Private Sub _Downloader_AmountDownloadedChanged(iNewProgress As Long) Handles _downloader.AmountDownloadedChanged

        ProgBar.Value = Convert.ToInt32(iNewProgress)
        lblProgress.Text = WebFileDownloader.FormatFileSize(iNewProgress) & " de " &
                           WebFileDownloader.FormatFileSize(ProgBar.Maximum) & " téléchargé"
        Application.DoEvents()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le load de ZGuideTVDotNetUpdate")
        Timer1.Interval = 500
        lblProgress.Text = String.Empty
        BringToFront()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le Timer1 de ZGuideTVDotNetUpdate")

        Timer1.Stop()

        Try
            _downloader = New WebFileDownloader
            _downloader.DownloadFileWithProgress(UrlMessage,
                                                 _dirMessage.TrimEnd("\"c) & GetFileNameFromURL(UrlMessage))
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "Erreur dans le Timer1 de ZGuideTVDotNetUpdate" & ex.Message)
            MessageBox.Show("Erreur: " & ex.Message)
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) _
     Handles Me.FormClosing

        Dispose()
    End Sub
End Class