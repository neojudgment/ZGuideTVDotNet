' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2014 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

Imports System.Reflection
Imports System.IO

' ReSharper disable CheckNamespace
' ReSharper disable UnusedMember.Global
Public Class About
    ' ReSharper restore UnusedMember.Global
    ' ReSharper restore CheckNamespace

    Private Sub Button1Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Close()

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel2.LinkClicked
        Process.Start("http://zguidetv.codeplex.com/")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel3.LinkClicked
        Process.Start("http://igloo.crystalxp.net/djeric")
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel4.LinkClicked
        Process.Start("http://www.7-zip.org/")
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel5.LinkClicked
        Process.Start("http://www.codeplex.com/")
    End Sub

    Private Sub PictureBoxPaypalClick(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBoxPaypal.Click
        Try

            ' Modifié par Néo le 28/01/2010
            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://www.paypal.com/") Then
                Process.Start( _
                               "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ZZBD7C6HV8V52")

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur Paypal

                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection = _
                    MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1, _
                                     Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As Net.WebException

            ' ReSharper disable NotAccessedVariable
            Dim boxNoConnection As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoConnection = _
                MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1, _
                                 Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub AboutLoad(sender As Object, e As EventArgs) Handles Me.Load

        Dim fv As FileVersionInfo
        fv = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)

        TextBoxVersion.Text = fv.ProductName & " v" & fv.FileVersion & " beta release"
        TextBoxCompiledOn.Text = "Compiled on: Windows 7 64-bit"
        TextBoxCompilationDate.Text = "Build date: " & CStr(File.GetLastWriteTime(AppPath & "ZGuideTVDotNet.exe").ToShortDateString()) & " " & _
        CStr(File.GetLastWriteTime(AppPath & "ZGuideTVDotNet.exe").ToShortTimeString())
        TextBoxCopyright.Text = fv.LegalCopyright & " " & fv.CompanyName
    End Sub
End Class