' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2013 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
' ReSharper disable CheckNamespace
Public Class ProgressBar
    ' ReSharper restore CheckNamespace
    Private Sub ProgressBarLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If My.Settings.GestionSave = True Then
            SetTextSave(lngProgressBarSaveLabel)
            SetTextSave(lngProgressBarSaveTitre)

        End If

        If My.Settings.GestionSave = False Then
            SetTextRestore(lngProgressBarRestoreLabel)
            SetTextRestore(lngProgressBarRestoreTitre)
        End If

    End Sub

    Private Delegate Sub SetTextCallback(ByVal text As String)

    Private Sub SetTextSave(ByVal [text] As String)

        If ProgressBarLabel.InvokeRequired Then
            Dim a As New SetTextCallback(AddressOf SetTextSave)
            Invoke(a, New Object() {lngProgressBarSaveLabel})
        Else
            ProgressBarLabel.Text = lngProgressBarSaveLabel
        End If

        If InvokeRequired Then
            Dim b As New SetTextCallback(AddressOf SetTextSave)
            Invoke(b, New Object() {lngProgressBarSaveTitre})
        Else
            Me.Text = lngProgressBarSaveTitre
        End If
    End Sub

    Private Sub SetTextRestore(ByVal [text] As String)

        If ProgressBarLabel.InvokeRequired Then
            Dim c As New SetTextCallback(AddressOf SetTextRestore)
            Invoke(c, New Object() {lngProgressBarRestoreLabel})
        Else
            ProgressBarLabel.Text = lngProgressBarRestoreLabel
        End If

        If InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetTextRestore)
            Invoke(d, New Object() {lngProgressBarRestoreTitre})
        Else
            Me.Text = lngProgressBarRestoreTitre
        End If
    End Sub
End Class