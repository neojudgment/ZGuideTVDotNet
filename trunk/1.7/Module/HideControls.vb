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

            .ToolStripTextBoxRecherche.ReadOnly = True

            .ZSplitButton1.Visible = False
            .ZSplitButtonGauche.Visible = False
            .ZSplitButtonDroit.Visible = False
            .panel_droit.Visible = False
            .ToolStripStatusLabel_date.Visible = False
            .ToolStripStatusLabel_heure.Visible = False
            .ToolStripStatusLabelCompensation.Visible = False
            .ToolStripStatusLabelMinutes.Visible = False
            '.ToolStripStatusLabelActiveEngine.Visible = False
            '.ToolStripStatusLabelEngine.Visible = False
            .ToolStripStatusLabelMemory.Visible = False
            .ToolStripStatusLabelMemoryUsage.Visible = False
            .ToolStripStatusLabelUpdate.Visible = False
            .ListViewChannel.Visible = False
        End With
    End Sub
End Module
