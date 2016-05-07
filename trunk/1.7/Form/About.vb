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
Imports System.Net
Imports System.Reflection

' ReSharper disable CheckNamespace
' ReSharper disable UnusedMember.Global
Public Class About
    ' ReSharper restore UnusedMember.Global
    ' ReSharper restore CheckNamespace

    Private Sub Button1Click(sender As Object, e As EventArgs) Handles Button1.Click

        Close()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel2.LinkClicked
        Process.Start("http://zguidetv.codeplex.com/")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel3.LinkClicked
        Process.Start("http://igloo.crystalxp.net/djeric")
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel5.LinkClicked
        Process.Start("http://www.codeplex.com/")
    End Sub

    Private Sub PictureBoxPaypalClick(sender As Object, e As EventArgs) Handles PictureBoxPaypal.Click
        Try

            ' Modifié par Néo le 28/01/2010
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://www.paypal.com/") Then
                Process.Start(
                    "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ZZBD7C6HV8V52")

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur Paypal

                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1,
                                    Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException

            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection =
                MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1,
                                Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub AboutLoad(sender As Object, e As EventArgs) Handles Me.Load

        Dim fv As FileVersionInfo
        fv = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)

        Dim opSys As String
        If Environment.Is64BitOperatingSystem Then
            opSys = "64-bit"
        Else
            opSys = "32-bit"
        End If

        TextBoxVersion.Text = fv.ProductName & " v" & fv.FileVersion & " beta " & opSys
        TextBoxCompiledOn.Text = "Compiled on: Windows 10 64-bit"
        TextBoxCompilationDate.Text = "Build date: " &
                                      CStr(File.GetLastWriteTime(AppPath & "ZGuideTVDotNet.exe").ToShortDateString()) &
                                      " " &
                                      CStr(File.GetLastWriteTime(AppPath & "ZGuideTVDotNet.exe").ToShortTimeString())
        TextBoxCopyright.Text = fv.LegalCopyright & " " & fv.CompanyName
    End Sub
End Class