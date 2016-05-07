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
Imports System.Collections.ObjectModel
Imports System.IO

' ReSharper disable CheckNamespace
Public Class SelectLanguage
    ' ReSharper restore CheckNamespace

    Private Sub OkButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOK.Click

        ' on vient de selectionner une langue en cliquant sur OK
        DialogResult = DialogResult.OK

        ' Sélection de la langue au 1er lancement de ZGuideTV
        If My.Settings.firststart Then
            With My.Settings

                .Language = comboboxSLanguages.Text
                .Save()
            End With
            Close()
        End If

        ' Sélection de la langue via les menus
        If Not [String].Equals(comboboxSLanguages.Text, My.Settings.Language, StringComparison.CurrentCulture) Then

            With My.Settings
                .Language = comboboxSLanguages.Text
                .Save()
            End With

            ' Néo 24/01/2011
            ' On active la langue après changement sans redémarrer
            ' si la bdd est périmée ou n'existe pas
            Dim fichierInfo As FileInfo = New FileInfo(BddPath & "db_progs.db3")
            Dim tailleBdd As Integer = CInt(fichierInfo.Length)
            If BasePerimee() OrElse tailleBdd < 6000 Then

                LanguageCheck(15)

                'On réinitialise la TextBox de recherche dans la barre d'outils du Mainform
                Mainform.RechercheTextBoxToolStrip()
                Close()
                Return
            End If

            ' Néo 24/01/2011
            ' On active la langue après changement sans redémarrer
            ' si la bdd n'est pas périmée ou existe
            If My.Settings.DataBaseExpired = False OrElse My.Settings.BddExists Then

                LanguageCheck()

                ' On réinitialise le calendrier dans la langue sélectionnée
                Mainform.IniCalendrier(Date.Now)

                ' On réinitialise la StatusBar dans la langue sélectionnée
                Mainform.MaJDateStatusBar()

                ' On réinitialise la StatusStrip dans la langue sélectionnée
                'Mainform.ToolStripStatusLabelActiveEngine.Text = LngToolStripStatusLabelActiveEngine

                'With My.Settings
                '    If .EngineSelection = 1 Then
                '        Mainform.ToolStripStatusLabelEngine.Text = LngToolStripStatusLabelThedvb
                '    End If
                '    If .EngineSelection = 2 Then
                '        Mainform.ToolStripStatusLabelEngine.Text = LngToolStripStatusLabelImdb
                '    End If
                '    If .EngineSelection = 3 Then
                '        Mainform.ToolStripStatusLabelEngine.Text = LngToolStripStatusLabelAllocine
                '    End If
                'End With

                'On réinitialise la TextBox de recherche dans la barre d'outils du Mainform
                Mainform.RechercheTextBoxToolStrip()

                'POPUP
                CentralScreen.popupContent.MajLangagePopup()
                Close()
            Else
                Close()
            End If
        End If
    End Sub

    Private Sub CancelButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCancel.Click
        DialogResult = DialogResult.Cancel

        Close()
    End Sub

    Private Sub SelectLanguageFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        With My.Settings
            If .firststart AndAlso .Language = Nothing Then
                .Language = "English"
            End If
            .Save()
        End With
    End Sub

    Private Sub FrmSelectLanguageLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If My.Settings.firststart Then
            Dim a As Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
            If [String].Equals(a.Parent.Name, "fr", StringComparison.CurrentCulture) Then
                ButtonOK.Text = "OK"
                ButtonCancel.Text = "Annuler"
            Else
                ButtonOK.Text = "OK"
                ButtonCancel.Text = "Cancel"
            End If
        Else
            LanguageCheck(12)
        End If

        comboboxSLanguages.Items.Clear()

        ' On scanne le répertoire 'Languages' et on affiche dans la combobox
        Dim item As String
        Dim i As Integer = 0
        Dim reader As ReadOnlyCollection(Of String)
        Dim nomFichierSansExtension As String
        Dim lastLocation As Integer
        Dim point As Integer
        reader = My.Computer.FileSystem.GetFiles(Application.StartupPath.ToString & "\languages\")

        Do While (i < reader.Count)
            item = reader.Item(i)

            ' On regarde si le fichier comporte une extention .lng
            Dim test As String = Path.GetExtension(item)
            If Not [String].Equals(test, ".lng", StringComparison.CurrentCulture) Then Exit Do

            ' on retire l'extention du fichier language
            point = (item.LastIndexOf(".", StringComparison.CurrentCulture) + 1)
            nomFichierSansExtension = LSet(item, point - 1)
            lastLocation = nomFichierSansExtension.LastIndexOf("\", StringComparison.CurrentCulture)
            comboboxSLanguages.Items.Add(nomFichierSansExtension.Remove(0, lastLocation + 1))
            i += 1
        Loop

        ' On affiche la langue sélectionnée
        comboboxSLanguages.Text = My.Settings.Language

        If My.Settings.firststart AndAlso (Not comboboxSLanguages.Text Is Nothing AndAlso String.IsNullOrEmpty(comboboxSLanguages.Text)) Then
            comboboxSLanguages.Text = "Français"
        End If
    End Sub
End Class