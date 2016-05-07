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
Public Class TimeZone
    ' ReSharper restore CheckNamespace

    Private Sub TimeZoneLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        LanguageCheck()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans TimeZone.vb")
        NumericUpDown1.Value = CDec(My.Settings.decalage_horaire)
    End Sub

    Private Sub OkButtonClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles OK_Button.Click

        DialogResult = Windows.Forms.DialogResult.OK

        If My.Settings.decalage_horaire <> CInt(NumericUpDown1.Value) Then
            Trace.WriteLine("le décalage choisi est de " & NumericUpDown1.Value & " minutes")
            My.Settings.decalage_horaire = CInt(NumericUpDown1.Value)
            My.Settings.Save()
            Trace.WriteLine("sauvetage du décalage horaire dans les settings")
            Mainform.Tl.Close()

            Mainform.Close()
            Dispose()
            Close()
            Application.DoEvents()
            Application.Restart()
        End If

        Close()
    End Sub

    Private Sub CancelButtonClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub NumericUpDown1ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NumericUpDown1.ValueChanged

        If NumericUpDown1.Value > 24 Then
            NumericUpDown1.Value = 24
        End If
        If NumericUpDown1.Value < -24 Then
            NumericUpDown1.Value = -24
        End If
    End Sub
End Class
