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

' ReSharper disable CheckNamespace
Public Class TimeZone
    ' ReSharper restore CheckNamespace
    Public Decalhoraire As Boolean
    Public DecalhoraireHeure As Integer

    Private Sub TimeZoneLoad(sender As Object, e As EventArgs) Handles Me.Load

        LanguageCheck()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans TimeZone.vb")
        NumericUpDown1.Value = My.Settings.decalage_horaire
    End Sub

    Private Sub OkButtonClick(sender As Object, e As EventArgs) Handles OK_Button.Click

        DialogResult = DialogResult.OK

        If My.Settings.decalage_horaire <> CInt(NumericUpDown1.Value) Then
            Decalhoraire = True
            DecalhoraireHeure = CInt(NumericUpDown1.Value)
        End If

        Close()
    End Sub

    Private Sub CancelButtonClick(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub NumericUpDown1ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

        If NumericUpDown1.Value > 24 Then
            NumericUpDown1.Value = 24
        End If
        If NumericUpDown1.Value < -24 Then
            NumericUpDown1.Value = -24
        End If
    End Sub
End Class
