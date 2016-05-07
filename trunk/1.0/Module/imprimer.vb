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
Imports System.Drawing.Printing
Imports System.IO

Friend Module imprimer
    Private WithEvents mon_document_a_imprimer As New PrintDocument
    Public mon_stream_document As StreamReader
    Public emission_ce_soir As String = "Emissions de ce soir :"
    Public printed_on As String = "imprimé sur :"
    ' Public longue_ligne As Boolean = False ' si true est on dans l impression 
    'Public largeur_page As Integer = 90
    '--------------------------------------------------
    Public Sub imprimer_fichier_ce_soir()
        ' Modifie BB 110810
        ' remplir fichier "cesoir" avec les caract des emissions "ce soir"
        Dim largeur_page As Integer = 100
        Dim i As Integer
        Dim ligne As String = ""
        Dim nom_chaine As String = " "
        Dim z1 As String
        Dim nom_du_fichier As String = AppData & "cesoir.rtf"
        Dim sw As New StreamWriter(nom_du_fichier, False)
        'Dim fnt As New Font ("Arial", 10)

        Mainform.Timer_minute.Enabled = False
        ligne = emission_ce_soir & " " & DateTime.Now.ToString & Environment.NewLine
        sw.WriteLine(ligne)
        ' on ecrit la ligne dans le fichier
        ligne = " "
        For i = 1 To nb_emissions_for_ce_soir
            Application.DoEvents() '260710
            'bb110810  ligne = " " & Environment.NewLine
            With tableau_list_emissions_ce_soir(i - 1)
                z1 = .ChannelID

                ' rechercher le nom en clair de la chaine correspondant à channelid
                nom_chaine = ""
                Dim k As Integer
                For k = 1 To nb_total_chaines
                    If tableau_chaine(k).identificateur = .ChannelID Then
                        nom_chaine = tableau_chaine(k).nom
                        Exit For
                    Else
                    End If
                Next k
                If nom_chaine = "" Then
                    Trace.WriteLine("nom de chaine nontrouvé dans impression ce soir")
                    Exit For
                Else
                End If

                ligne &= nom_chaine & "     "
                sw.Write(ligne)

                ligne = "Titre:" & .Ptitle & " "
                sw.Write(ligne)

                'ligne = .Ptitle & Environment.NewLine
                'BB 110810sw.Write(ligne)

                If .Psubtitle <> "" Then
                    ligne = "Sous-Titre :" & .Psubtitle & Environment.NewLine
                    sw.Write(ligne)
                End If

                ligne = " Catégorie:" & .PcategoryTV
                ligne &= Environment.NewLine & .pstart.ToString & vbTab & .pstop.ToString & vbTab & .Pduration.ToString & _
                         " min " & Environment.NewLine
                sw.Write(ligne)

                If .Pactors <> "" Then
                    ligne = "Acteurs: "  'Environment.NewLine
                    sw.Write(ligne)
                    ligne = .Pactors & Environment.NewLine

                    'BB 110810
                    Do While ligne.Length > largeur_page
                        Dim tot1 As String
                        Dim part1 As String
                        Dim part2 As String
                        Dim tot As String
                        tot1 = ligne.Substring(0, largeur_page)
                        Dim pos1 As Integer
                        Dim zz As Integer
                        pos1 = tot1.LastIndexOf(" ", StringComparison.CurrentCulture)
                        part1 = tot1.Substring(0, pos1 + 1)
                        ' terminé par " "
                        part2 = tot1.Substring(pos1 + 1, tot1.Length - (pos1 + 1))
                        zz = ligne.Length - largeur_page
                        tot = part2 & ligne.Substring(largeur_page, zz)
                        ligne = part1 & Environment.NewLine
                        sw.Write(ligne)
                        ligne = tot
                        If ligne.Length < largeur_page Then
                            Exit Do
                        End If
                    Loop
                    sw.Write(ligne)
                End If

                If .Pdescription <> "" Then
                    ligne = "Résumé:" & .Pdescription & Environment.NewLine
                    'BB 110810sw.Write(ligne)
                    'BB 110810 ligne = .Pdescription & Environment.NewLine

                    Do While ligne.Length > largeur_page
                        Dim tot1 As String
                        Dim part1 As String
                        Dim part2 As String
                        Dim tot As String
                        tot1 = ligne.Substring(0, largeur_page)
                        Dim pos1 As Integer
                        Dim zz As Integer
                        pos1 = tot1.LastIndexOf(" ", StringComparison.CurrentCulture)
                        part1 = tot1.Substring(0, pos1 + 1) ' parie gauche d un morceau de ligne
                        ' terminé par " "
                        part2 = tot1.Substring(pos1 + 1, tot1.Length - (pos1 + 1)) ' partie droite du morceau de ligne
                        zz = ligne.Length - largeur_page
                        tot = part2 & ligne.Substring(largeur_page, zz)
                        ligne = part1 & Environment.NewLine
                        sw.Write(ligne)
                        ligne = tot
                        If ligne.Length < largeur_page Then
                            Exit Do
                        End If
                    Loop

                    'BB 110810 sw.Write(ligne)
                End If
            End With
        Next i
        sw.Close()
        sw.Dispose()

        ' imprimer le fichier "cesoir.txt"
        With Mainform.PrintDialog1
            .Document = mon_document_a_imprimer
            .AllowSelection = True
            .AllowSomePages = True
            If .ShowDialog <> DialogResult.OK Then
                Return
            End If

            ' associer les options d'impression de la boite de dialogue au document à imprimer
            mon_document_a_imprimer.PrinterSettings = .PrinterSettings

            ' message à visualiser
            mon_document_a_imprimer.DocumentName = nom_du_fichier & printed_on & "  " & .PrinterSettings.PrinterName

            ' ouvrir le fichier à imprimer
            mon_stream_document = New StreamReader(nom_du_fichier)

            ' lancer l impression du document de maniere à declencher l évenement PrintPage
            mon_document_a_imprimer.Print()
        End With

        ' apres le declenchement des evts PrintPage
        ' supprimer fichier_ce_soir et clôturer les éléments
        ' nécessaires à  limpression
        mon_stream_document.Close()
        mon_document_a_imprimer.Dispose()
        Application.DoEvents()
        File.Delete(nom_du_fichier)
        mon_stream_document = Nothing
        Mainform.Timer_minute.Enabled = True
        sw = Nothing
        'fnt = Nothing
        ligne = Nothing

    End Sub

    Private Sub mon_document_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) _
        Handles mon_document_a_imprimer.PrintPage

        Dim strligne As String
        Dim ligne As String

        ' pos et rct sont utilisées pour déterminer les coordonnées et la taille de
        ' la zone dans laquelle la ligne doit être imprimée.
        Dim pos As PointF
        Dim rct As RectangleF
        Dim fnt As New Font("Arial", 10)

        ' choisir une police
        Dim hauteur_ligne As Single = fnt.GetHeight(e.Graphics)

        ' hauteur ligne d impression
        'largeur_page = 90

        ' à parametrer correctement suivant  police et marges
        Dim num_ligne As Integer = 0
        'Dim longueur As Integer = 1
        Dim engras As Boolean = False
        Dim lignesparpage As Integer = CInt(e.MarginBounds.Height / hauteur_ligne)

        Do Until (mon_stream_document.Peek = -1) ' tant qu il y a des records ds le fichier
            strligne = mon_stream_document.ReadLine

            ' lire 1 ligne du fichier
            'longueur = strligne.Length
            ligne = strligne & Environment.NewLine

            ' trouve t on "Titre" ou "Acteurs" ou "Description" ...alors en gras (bold)
            If _
                ligne.IndexOf("Titre:", StringComparison.CurrentCulture) <> -1 OrElse ligne.IndexOf("Acteurs:", StringComparison.CurrentCulture) <> -1 OrElse _
                ligne.IndexOf("Description:", StringComparison.CurrentCulture) <> -1 Then
                engras = True
            End If

            ' calculer la position du rectangle contenant la ligne à imprimer
            pos = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + num_ligne * hauteur_ligne)

            ' definir les coordonees de la zone dans laquelle la ligne sera imprimée avec la position calculée
            With rct
                .Location = pos
                .Width = e.MarginBounds.Width
                .Height = hauteur_ligne
            End With

            ' imprimer la ligne avec la méthode drawstring
            Select Case engras
                Case True ' imprimer en gras
                    Dim fntbold As New Font("arial", 10, FontStyle.Bold)
                    e.Graphics.DrawString(ligne, fntbold, Brushes.Black, rct)
                    fntbold = Nothing
                    engras = False
                Case False ' imprimer avec une police non bold
                    Dim fnt1 As New Font("Arial", 10, FontStyle.Regular)
                    e.Graphics.DrawString(ligne, fnt1, Brushes.Black, rct)
                    fnt1 = Nothing
            End Select

            ' incrémenter le nombre de lignes imprimées
            ' et vérifier si on est arrivé en fin de page
            num_ligne += 1
            If num_ligne > lignesparpage Then
                e.HasMorePages = True

                ' genere un nouveau PagePrint
                num_ligne = 0
                Exit Do
            Else
                e.HasMorePages = False
            End If
        Loop

        ' sur les records du fichier
        pos = Nothing
        rct = Nothing
        fnt = Nothing
    End Sub
End Module
