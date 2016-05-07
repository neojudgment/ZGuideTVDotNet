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
Public Class EngineSelection
    ' ReSharper restore CheckNamespace

#Region "Property"

    Public EngineSelectionTvdbListBox As String
    Public EngineSelectionImdbListBox As String
    Public EngineSelectionAllocineListBox As String

#End Region

    Private Sub EngineSelectionLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Trace.WriteLine(DateTime.Now & " " & "LanguageCheck dans EngineSelection")
        LanguageCheck()

        'Néo 01/05/2010
        If ComboBoxEngine.Items.Count = 0 Then
            Trace.WriteLine(DateTime.Now & " " & "On affiche la liste des moteurs dispo dans la ComboBoxEngine")
            With ComboBoxEngine.Items
                .Add(EngineSelectionTvdbListBox)
                .Add(EngineSelectionImdbListBox)
                .Add(EngineSelectionAllocineListBox)
            End With
        End If

        Trace.WriteLine(DateTime.Now & " " & "On sélectionne le nom du moteur sélectionné dans la ComboBoxEngine")
        Dim engine As Integer
        engine = My.Settings.EngineSelection

        Select Case engine
            Case 1
                ComboBoxEngine.Text = lngEngineSelectionTVDBListBox
            Case 2
                ComboBoxEngine.Text = lngEngineSelectionIMDBListBox
            Case 3
                ComboBoxEngine.Text = lngEngineSelectionAllocineListBox
        End Select

        With My.Settings
            If .EngineShow = False Then
                EngineSelectionShowCheckBox.Checked = True
            Else
                EngineSelectionShowCheckBox.Checked = False
            End If
        End With

    End Sub

    Private Sub OkButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        DialogResult = Windows.Forms.DialogResult.OK

        Trace.WriteLine(DateTime.Now & " " & "On met a jour le nom du moteur actif dans My.settings.EngineSelection")
        With ComboBoxEngine
            If [String].Equals(.Text, lngEngineSelectionTVDBListBox, StringComparison.CurrentCulture) Then
                My.Settings.EngineSelection = 1
            End If
            If [String].Equals(.Text, lngEngineSelectionIMDBListBox, StringComparison.CurrentCulture) Then
                My.Settings.EngineSelection = 2
            End If
            If [String].Equals(.Text, lngEngineSelectionAllocineListBox, StringComparison.CurrentCulture) Then
                My.Settings.EngineSelection = 3
            End If
        End With

        If EngineSelectionShowCheckBox.Checked = True Then
            My.Settings.EngineShow = False
        Else
            My.Settings.EngineShow = True
        End If

        My.Settings.Save()

        Trace.WriteLine( _
                         DateTime.Now & " " & _
                         "On met a jour le nom du moteur actif dans la ToolStatusStrip à partir de EngineSelection")
        Dim engine As Integer
        engine = My.Settings.EngineSelection

        Select Case engine
            Case 1
                Mainform.ToolStripStatusLabelEngine.Text = lngToolStripStatusLabelTHEDVB
            Case 2
                Mainform.ToolStripStatusLabelEngine.Text = lngToolStripStatusLabelIMDB
            Case 3
                Mainform.ToolStripStatusLabelEngine.Text = lngToolStripStatusLabelALLOCINE
        End Select

        Close()
    End Sub

    Private Sub CancelButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class
