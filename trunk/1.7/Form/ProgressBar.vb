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

    Private Sub SetTextRestore(ByVal texte As String)

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
            texte = LngProgressBarRestoreTitre
        End If
    End Sub
End Class