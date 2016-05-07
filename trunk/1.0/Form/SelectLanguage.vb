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
Imports System.Collections.ObjectModel
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.IO

Public Class SelectLanguage
    Private _reponse As MsgBoxResult = MsgBoxResult.No

    Public Property Reponse As MsgBoxResult
        Get
            Return _reponse
        End Get
        Set(ByVal Value As MsgBoxResult)
            _reponse = Value
        End Set
    End Property

    ' 22/08/2010 Griser et désactiver la croix rouge de la form
    Private Const CS_NOCLOSE As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOK.Click

        ' on vient de selectionner une langue en cliquant sur OK
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        ' Sélection de la langue au 1er lancement de ZGuideTV
        If My.Settings.firststart Then
            With My.Settings
                .Language = comboboxSLanguages.Text
                .Save()
                Me.Close()
            End With
            Return
        End If

        ' Sélection de la langue via les menus
        If comboboxSLanguages.Text <> My.Settings.Language Then

            With My.Settings
                .Language = comboboxSLanguages.Text
                .Save()
            End With

            ' Néo 24/01/2011
            ' On active la langue après changement sans redémarrer
            ' si la bdd est périmée ou n'existe pas
            Dim FichierInfo As FileInfo = New FileInfo(BDDPath & "db_progs.db3")
            Dim TailleBdd As Integer = CInt(FichierInfo.Length)
            If BasePerimee() OrElse TailleBdd < 6000 Then

                LanguageCheck(15)

                'On réinitialise la TextBox de recherche dans la barre d'outils du Mainform
                Mainform.RechercheTextBoxToolStrip()

                'On réinitialise la jumplist dans Windows 7
                Dim os As OperatingSystem = Environment.OSVersion
                If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
               TaskbarManager.IsPlatformSupported Then
                    Mainform.Myjumplist()
                End If
                Me.Close()
                Return
            End If

            ' Néo 24/01/2011
            ' On active la langue après changement sans redémarrer
            ' si la bdd n'est pas périmée ou existe
            If My.Settings.DataBaseExpired = False OrElse My.Settings.BddExists = False Then

                LanguageCheck()

                Get_Types_Of_Emissions_for_period()

                ' On applique la langue sélectionnée dans le treeview 12/09/09
                With Mainform.TreeView1.Nodes
                    .Item(0).Text = lngNodeFilter
                    .Item(0).Nodes.Item(0).Text = lngNodeCategory & " (" & _
                                                    nb_total_type_emission.ToString & ")"
                    .Item(0).Nodes.Item(1).Text = lngNodeCountry
                    .Item(0).Nodes.Item(2).Text = lngNodeProvider
                End With

                ' On réinitialise le calendrier dans la langue sélectionnée
                Mainform.IniCalendrier(Date.Now)

                ' On réinitialise la StatusBar dans la langue sélectionnée
                Mainform.MaJDateStatusBar()

                ' On réinitialise la RichTextBox dans la langue sélectionnée
                If Central_Screen.repere_click_emission > 0 Then
                    Central_Screen.ComposerMessageDescrip(Central_Screen.repere_click_emission, "principale")
                Else
                    Central_Screen.ComposerMessageDescrip(1, "principale")
                End If

                ' On réinitialise la StatusStrip dans la langue sélectionnée
                Mainform.ToolStripStatusLabelActiveEngine.Text = lngToolStripStatusLabelActiveEngine

                With My.Settings
                    If .EngineSelection = 1 Then
                        Mainform.ToolStripStatusLabelEngine.Text = lngToolStripStatusLabelTHEDVB
                    End If
                    If .EngineSelection = 2 Then
                        Mainform.ToolStripStatusLabelEngine.Text = lngToolStripStatusLabelIMDB
                    End If
                    If .EngineSelection = 3 Then
                        Mainform.ToolStripStatusLabelEngine.Text = lngToolStripStatusLabelALLOCINE
                    End If
                End With

                ' On réinitialise le flux rss dans la langue sélectionnée
                My.Settings.RssFeedLanguage = True
                Mainform.rssfeed()

                'On réinitialise la langue de la météo
                Mainform.WeatherUpdate()


                'On réinitialise la TextBox de recherche dans la barre d'outils du Mainform
                Mainform.RechercheTextBoxToolStrip()

                'On réinitialise la jumplist dans Windows 7
                Dim os As OperatingSystem = Environment.OSVersion
                If ((os.Version.Major = 6 AndAlso os.Version.Minor >= 1) OrElse os.Version.Major > 6) AndAlso _
               TaskbarManager.IsPlatformSupported Then
                    Mainform.Myjumplist()
                End If

                Me.Close()
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        If My.Settings.firststart Then
            With My.Settings
                .Language = "English"
                .firststart = False
                .Save()
                Me.Close()
            End With
            Return

        Else
            Me.Close()
        End If

    End Sub

    Private Sub frmSelectLanguage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If My.Settings.firststart Then
            Dim a As Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
            If a.Parent.Name = "fr" Then
                Me.ButtonOK.Text = "OK"
                Me.ButtonCancel.Text = "Annuler"
            Else
                Me.ButtonOK.Text = "OK"
                Me.ButtonCancel.Text = "Cancel"
            End If
        Else
            LanguageCheck(12)
        End If

        comboboxSLanguages.Items.Clear()

        ' On scanne le répertoire 'Languages' et on affiche dans la combobox
        Dim item As String
        Dim i As Integer = 0
        Dim reader As ReadOnlyCollection(Of String)
        Dim NomFichierSansExtension As String
        Dim lastLocation As Integer
        Dim Point As Integer
        reader = My.Computer.FileSystem.GetFiles(Application.StartupPath.ToString & "\languages\")

        Do While (i < reader.Count)
            item = reader.Item(i)

            ' On regarde si le fichier comporte une extention .lng
            Dim test As String = System.IO.Path.GetExtension(item)
            If test <> ".lng" Then Exit Do

            ' on retire l'extention du fichier language
            Point = (item.LastIndexOf(".", StringComparison.CurrentCulture) + 1)
            NomFichierSansExtension = LSet(item, Point - 1)
            lastLocation = NomFichierSansExtension.LastIndexOf("\", StringComparison.CurrentCulture)
            comboboxSLanguages.Items.Add(NomFichierSansExtension.Remove(0, lastLocation + 1))
            i += 1
        Loop

        ' On affiche la langue sélectionnée
        comboboxSLanguages.Text = My.Settings.Language

        If My.Settings.firststart AndAlso (Not comboboxSLanguages.Text Is Nothing AndAlso String.IsNullOrEmpty(comboboxSLanguages.Text)) Then
            comboboxSLanguages.Text = "Français"
        End If

    End Sub
End Class