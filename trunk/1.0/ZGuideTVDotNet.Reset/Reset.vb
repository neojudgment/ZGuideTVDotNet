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
Imports System.Windows.Forms
Imports System.IO

Public Class Reset
    Public BDDPath As String
    Public ChannelSetPath As String
    Public MarqueesPath As String

    Public MessageBoxReset As String = "All ZGuideTV.NET settings have been deleted!"
    Public MessageBoxResetTitre As String = "ZGuideTV.NET - Reset"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes

        If My.Computer.FileSystem.FileExists(BDDPath & "db_progs.db3") Then
            File.Delete(BDDPath & "db_progs.db3")
        End If

        If My.Computer.FileSystem.FileExists(ChannelSetPath & "ZGuideTVDotNet.channels.set") Then
            File.Delete(ChannelSetPath & "ZGuideTVDotNet.channels.set")
        End If

        If My.Computer.FileSystem.FileExists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
            File.Delete(ChannelSetPath & "ZGuideTVDotNet.marked.set")
        End If

            Dim BoxMiseaJour As DialogResult
            BoxMiseaJour = MessageBox.Show _
                (MessageBoxReset & Chr(13), _
                 MessageBoxResetTitre, MessageBoxButtons.OK, MessageBoxIcon.Information, _
                 MessageBoxDefaultButton.Button1)

            Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Sub New()

        InitializeComponent()

        BDDPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & _
                  "\ZGuideTVDotNet\DataBase\"

        ChannelSetPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & _
                          "\ZGuideTVDotNet\Channels\"

        MarqueesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & _
                       "\ZGuideTVDotNet\Marked\"
    End Sub
End Class
