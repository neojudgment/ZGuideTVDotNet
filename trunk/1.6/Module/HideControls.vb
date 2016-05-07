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

' ReSharper disable CheckNamespace
Module HideControls
    ' ReSharper restore CheckNamespace

    Sub Hide()

        With Mainform
            .ShowInTaskbar = True

            '.Panel_date.Visible = False
            '.Panel_cinema.Visible = False
            .PanelA.Visible = False
            .PanelB.Visible = False
            '.PanelC.Visible = False
            .PanelD.Visible = False

            .TreeView1.Visible = False
            .Panel_glob_devant.Visible = False

            .ToolStripTextBoxRecherche.ReadOnly = True

            .ZSplitButton1.Visible = False
            .ZSplitButtonGauche.Visible = False
            .ZSplitButtonDroit.Visible = False
            .panel_droit.Visible = False
            .ToolStripStatusLabel_date.Visible = False
            .ToolStripStatusLabel_heure.Visible = False
            .ToolStripStatusLabelCompensation.Visible = False
            .ToolStripStatusLabelMinutes.Visible = False
            .ToolStripStatusLabelActiveEngine.Visible = False
            .ToolStripStatusLabelEngine.Visible = False
            .ToolStripStatusLabelMemory.Visible = False
            .ToolStripStatusLabelMemoryUsage.Visible = False
            .ToolStripStatusLabelUpdate.Visible = False
            .ListViewChannel.Visible = False
        End With
    End Sub
End Module
