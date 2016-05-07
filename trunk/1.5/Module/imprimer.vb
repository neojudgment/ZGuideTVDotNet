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
Imports System.Drawing.Printing
Imports System.IO

' ReSharper disable InconsistentNaming
' ReSharper disable CheckNamespace
Friend Module imprimer
    ' ReSharper restore CheckNamespace
    ' ReSharper restore InconsistentNaming

    Private WithEvents _monDocumentAImprimer As New PrintDocument
    Public MonStreamDocument As StreamReader
    Private Const EmissionCeSoir As String = "Emissions de ce soir :"
    Private Const PrintedOn As String = "imprimé sur :"
    ' Public longue_ligne As Boolean = False ' si true est on dans l impression 
    'Public largeur_page As Integer = 90
    '--------------------------------------------------
    Public Sub ImprimerFichierCeSoir()
        ' Modifie BB 110810
        ' remplir fichier "cesoir" avec les caract des emissions "ce soir"
        Const largeurPage As Integer = 100
        Dim i As Integer
        Dim ligne As String
        Dim nomChaine As String
        'Dim z1 As String
        Dim nomDuFichier As String = AppData & "cesoir.rtf"
        Dim sw As New StreamWriter(nomDuFichier, False)
        'Dim fnt As New Font ("Arial", 10)

        Mainform.Timer_minute.Enabled = False
        ligne = EmissionCeSoir & " " & DateTime.Now.ToString & Environment.NewLine
        sw.WriteLine(ligne)
        ' on ecrit la ligne dans le fichier
        ligne = " "
        For i = 1 To NbEmissionsForCeSoir
            Application.DoEvents() '260710
            'bb110810  ligne = " " & Environment.NewLine
            With TableauListEmissionsCeSoir(i - 1)
                'z1 = .ChannelID

                ' rechercher le nom en clair de la chaine correspondant à channelid
                nomChaine = ""
                Dim k As Integer
                For k = 1 To NbTotalChaines
                    If [String].Equals(TableauChaine(k).Identificateur, .ChannelId, StringComparison.CurrentCulture) Then
                        nomChaine = TableauChaine(k).Nom
                        Exit For
                    Else
                    End If
                Next k
                If [String].Equals(nomChaine, "", StringComparison.CurrentCulture) Then
                    Trace.WriteLine("nom de chaine nontrouvé dans impression ce soir")
                    Exit For
                Else
                End If

                ligne &= nomChaine & "     "
                sw.Write(ligne)

                ligne = "Titre:" & .Ptitle & " "
                sw.Write(ligne)

                'ligne = .Ptitle & Environment.NewLine
                'BB 110810sw.Write(ligne)

                If Not [String].Equals(.Psubtitle, "", StringComparison.CurrentCulture) Then
                    ligne = "Sous-Titre :" & .Psubtitle & Environment.NewLine
                    sw.Write(ligne)
                End If

                ligne = " Catégorie:" & .PcategoryTv
                ligne &= Environment.NewLine & .Pstart.ToString & vbTab & .Pstop.ToString & vbTab & .Pduration.ToString & _
                         " min " & Environment.NewLine
                sw.Write(ligne)

                If Not [String].Equals(.Pactors, "", StringComparison.CurrentCulture) Then
                    ligne = "Acteurs: "  'Environment.NewLine
                    sw.Write(ligne)
                    ligne = .Pactors & Environment.NewLine

                    'BB 110810
                    Do While ligne.Length > largeurPage
                        Dim tot1 As String
                        Dim part1 As String
                        Dim part2 As String
                        Dim tot As String
                        tot1 = ligne.Substring(0, largeurPage)
                        Dim pos1 As Integer
                        Dim zz As Integer
                        pos1 = tot1.LastIndexOf(" ", StringComparison.CurrentCulture)
                        part1 = tot1.Substring(0, pos1 + 1)
                        ' terminé par " "
                        part2 = tot1.Substring(pos1 + 1, tot1.Length - (pos1 + 1))
                        zz = ligne.Length - largeurPage
                        tot = part2 & ligne.Substring(largeurPage, zz)
                        ligne = part1 & Environment.NewLine
                        sw.Write(ligne)
                        ligne = tot
                        If ligne.Length < largeurPage Then
                            Exit Do
                        End If
                    Loop
                    sw.Write(ligne)
                End If

                If Not [String].Equals(.Pdescription, "", StringComparison.CurrentCulture) Then
                    ligne = "Résumé:" & .Pdescription & Environment.NewLine
                    'BB 110810sw.Write(ligne)
                    'BB 110810 ligne = .Pdescription & Environment.NewLine

                    Do While ligne.Length > largeurPage
                        Dim tot1 As String
                        Dim part1 As String
                        Dim part2 As String
                        Dim tot As String
                        tot1 = ligne.Substring(0, largeurPage)
                        Dim pos1 As Integer
                        Dim zz As Integer
                        pos1 = tot1.LastIndexOf(" ", StringComparison.CurrentCulture)
                        part1 = tot1.Substring(0, pos1 + 1) ' parie gauche d un morceau de ligne
                        ' terminé par " "
                        part2 = tot1.Substring(pos1 + 1, tot1.Length - (pos1 + 1)) ' partie droite du morceau de ligne
                        zz = ligne.Length - largeurPage
                        tot = part2 & ligne.Substring(largeurPage, zz)
                        ligne = part1 & Environment.NewLine
                        sw.Write(ligne)
                        ligne = tot
                        If ligne.Length < largeurPage Then
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
            .Document = _monDocumentAImprimer
            .AllowSelection = True
            .AllowSomePages = True
            If .ShowDialog <> DialogResult.OK Then
                Return
            End If

            ' associer les options d'impression de la boite de dialogue au document à imprimer
            _monDocumentAImprimer.PrinterSettings = .PrinterSettings

            ' message à visualiser
            _monDocumentAImprimer.DocumentName = nomDuFichier & PrintedOn & "  " & .PrinterSettings.PrinterName

            ' ouvrir le fichier à imprimer
            MonStreamDocument = New StreamReader(nomDuFichier)

            ' lancer l impression du document de maniere à declencher l évenement PrintPage
            _monDocumentAImprimer.Print()
        End With

        ' apres le declenchement des evts PrintPage
        ' supprimer fichier_ce_soir et clôturer les éléments
        ' nécessaires à  limpression
        MonStreamDocument.Close()
        _monDocumentAImprimer.Dispose()
        Application.DoEvents()
        File.Delete(nomDuFichier)
        MonStreamDocument = Nothing
        Mainform.Timer_minute.Enabled = True
    End Sub

    Private Sub MonDocumentPrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) _
        Handles _monDocumentAImprimer.PrintPage

        Dim strligne As String
        Dim ligne As String

        ' pos et rct sont utilisées pour déterminer les coordonnées et la taille de
        ' la zone dans laquelle la ligne doit être imprimée.
        Dim pos As PointF
        Dim rct As RectangleF
        Dim fnt As New Font("Arial", 10)

        ' choisir une police
        Dim hauteurLigne As Single = fnt.GetHeight(e.Graphics)

        ' hauteur ligne d impression
        'largeur_page = 90

        ' à parametrer correctement suivant  police et marges
        Dim numLigne As Integer = 0
        'Dim longueur As Integer = 1
        Dim engras As Boolean = False
        Dim lignesparpage As Integer = CInt(e.MarginBounds.Height / hauteurLigne)

        Do Until (MonStreamDocument.Peek = -1) ' tant qu il y a des records ds le fichier
            strligne = MonStreamDocument.ReadLine

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
            pos = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + numLigne * hauteurLigne)

            ' definir les coordonees de la zone dans laquelle la ligne sera imprimée avec la position calculée
            With rct
                .Location = pos
                .Width = e.MarginBounds.Width
                .Height = hauteurLigne
            End With

            ' imprimer la ligne avec la méthode drawstring
            Select Case engras
                Case True ' imprimer en gras
                    Dim fntbold As New Font("arial", 10, FontStyle.Bold)
                    e.Graphics.DrawString(ligne, fntbold, Brushes.Black, rct)
                    engras = False
                Case False ' imprimer avec une police non bold
                    Dim fnt1 As New Font("Arial", 10, FontStyle.Regular)
                    e.Graphics.DrawString(ligne, fnt1, Brushes.Black, rct)
            End Select

            ' incrémenter le nombre de lignes imprimées
            ' et vérifier si on est arrivé en fin de page
            numLigne += 1
            If numLigne > lignesparpage Then
                e.HasMorePages = True

                ' genere un nouveau PagePrint
                Exit Do
            Else
                e.HasMorePages = False
            End If
        Loop
    End Sub
End Module
