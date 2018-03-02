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

Public Class ZComboBox

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        SetStyle(
ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
ControlStyles.OptimizedDoubleBuffer, True)
        lblNomRecherche.BackColor = Color.FromArgb(255, 255, 255, 255)
    End Sub

    Private Sub lblListeNomRecherche_Click(sender As Object, e As EventArgs) Handles lblListeNomRecherche.Click
        cmsListeNom.Show(lblNomRecherche, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
    End Sub

    ' ReSharper disable ParameterHidesMember
    Public Event EventEngine(engine As String)
    ' ReSharper restore ParameterHidesMember

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RechercheAvancéeinterneToolStripMenuItem.Click,
        IMDBToolStripMenuItem.Click, AllocinéToolStripMenuItem.Click, TVDBinterneToolStripMenuItem.Click, AllocinéToolStripMenuItem.Click,
        RottenTomatoesToolStripMenuItem.Click, GoogleToolStripMenuItem.Click, YoutubeToolStripMenuItem.Click

        lblNomRecherche.Text = DirectCast(sender, ToolStripMenuItem).Text
    End Sub

    Private Sub lblRechercher_Click(sender As Object, e As EventArgs) Handles lblRechercher.Click

        RaiseEvent EventEngine(lblNomRecherche.Text)
    End Sub

    Private Sub cmsListeNom_Closed(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsListeNom.Closing
        CType(Parent.Parent, ToolStripDropDown).AutoClose = True
    End Sub

    Private Sub cmsListeNom_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsListeNom.Opening
        CType(Parent.Parent, ToolStripDropDown).AutoClose = False
    End Sub
End Class
