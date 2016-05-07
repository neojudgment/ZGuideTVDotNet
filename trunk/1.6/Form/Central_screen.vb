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


#Region "Imports"

Imports System.IO
Imports System.ComponentModel
Imports ZGuideTV.SQLiteWrapper
Imports ZGuideTV.ZGuideTVDotNetTvdb
Imports System.Text.RegularExpressions

#End Region

' ReSharper disable CheckNamespace
' ReSharper disable UnusedMember.Global
Public Class CentralScreen
    ' ReSharper restore UnusedMember.Global
    ' ReSharper restore CheckNamespace

#Region "Property"

    Private ReadOnly _descTooltip As New ToolTip
    Private _myFont As Font
    Private _logoChaine As String = Nothing
    Private ReadOnly _toolTipPictureBox As PictureBox = New PictureBox()
    Private _repereClickEmission As Integer
    Private _heureDebutDemarquee As String
    Private _chaineDemarquee As String
    Private _heureFinDemarquee As String
    Public MessageBoxNoConnection As String
    Public MessageBoxNoConnection1 As String
    Public MessageBoxNoConnectionTitre As String
    Private _sTitre As String
    Public MouseWheelInUse As Boolean

#End Region

    Private Sub CentralScreen(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Néo le 27/08/2009
        LanguageCheck()
    End Sub

    Private _tabCouleur As Color() = {Color.FromArgb(255, 191, 191), Color.FromArgb(255, 191, 255), Color.FromArgb(223, 191, 255),
                                      Color.FromArgb(206, 189, 255),
                                      Color.FromArgb(191, 191, 255), Color.FromArgb(191, 253, 255),
                                      Color.FromArgb(255, 229, 229), Color.FromArgb(191, 255, 191), Color.FromArgb(223, 255, 191),
                                      Color.FromArgb(239, 255, 191),
                                      Color.FromArgb(255, 174, 128), Color.FromArgb(255, 223, 128), Color.FromArgb(255, 214, 191),
                                      Color.FromArgb(255, 221, 191), Color.FromArgb(236, 236, 236), Color.FromArgb(255, 128, 128),
                                      Color.FromArgb(178, 178, 178), Color.FromArgb(240, 230, 140), Color.FromArgb(240, 255, 128),
                                      Color.FromArgb(191, 255, 128), Color.FromArgb(140, 255, 128), Color.FromArgb(128, 255, 159),
                                      Color.FromArgb(128, 255, 206), Color.FromArgb(128, 255, 255), Color.FromArgb(128, 208, 255),
                                      Color.FromArgb(128, 159, 255), Color.FromArgb(142, 128, 255),
                                      Color.FromArgb(191, 128, 255), Color.FromArgb(238, 128, 255), Color.FromArgb(255, 128, 223),
                                      Color.FromArgb(255, 255, 128), Color.FromArgb(128, 255, 128),
                                      Color.FromArgb(0, 255, 128), Color.FromArgb(128, 255, 255), Color.FromArgb(128, 180, 255),
                                      Color.FromArgb(255, 217, 217), Color.FromArgb(255, 217, 255), Color.FromArgb(237, 217, 255),
                                      Color.FromArgb(236, 217, 255), Color.FromArgb(225, 217, 255)}

    Public Sub PixelsNonUtilisésPourLesEmissions()

        ' cette sr ne peut etre appelée qu après définition de
        ' l1, l2, l3, panelB.width et panelC.width
        ' cad après create_panelbox et premieres_initialisations
        Dim i As Integer

        InutiliseAGauche(0) = LargeurBoutonsVerticaux * 2 + Mainform.PanelB.Width
        InutiliseAGauche(1) = InutiliseAGauche(0)
        InutiliseAGauche(2) = L2 + LargeurBoutonsVerticaux * 2
        InutiliseAGauche(3) = InutiliseAGauche(2)
        InutiliseAGauche(4) = L1 + LargeurBoutonsVerticaux * 2 + Mainform.PanelB.Width
        InutiliseAGauche(5) = InutiliseAGauche(4)
        InutiliseAGauche(6) = L1 + L2 + LargeurBoutonsVerticaux * 2
        InutiliseAGauche(7) = InutiliseAGauche(6)

        InutiliseADroite(0) = LargeurBoutonsVerticaux + L3
        InutiliseADroite(1) = LargeurBoutonsVerticaux
        InutiliseADroite(2) = LargeurBoutonsVerticaux + L3
        InutiliseADroite(3) = LargeurBoutonsVerticaux
        InutiliseADroite(4) = LargeurBoutonsVerticaux + L3
        InutiliseADroite(5) = LargeurBoutonsVerticaux
        InutiliseADroite(6) = LargeurBoutonsVerticaux + L3
        InutiliseADroite(7) = LargeurBoutonsVerticaux

        For i = 0 To BitsConfig
            InutiliseTotal(i) = InutiliseAGauche(i) + InutiliseADroite(i)
            LargMaxPanelA(i) = My.Computer.Screen.Bounds.Right - InutiliseTotal(i)
        Next i
    End Sub

    Public Sub CalculDateOrigineEcran()

        ' Chaque fois qu on clique sur un bouton gauche droit, bas1 ...
        ' il faut recalculer la date ORIGINE Car celle ci dépend de la config des 3 bits
        Trace.WriteLine(DateTime.Now & " " & "Calcul origine écran")
        Dim pixels As Integer
        pixels = -Mainform.PanelA.Left + InutiliseAGauche(SynthBoutons)
        DateOrigineEcran = DateReference.AddMinutes(pixels * 30 / NbPixelsPour30Minutes)
        'date_origine_ecran = CDate(date_origine_ecran.AddMinutes(1).ToString("dd/M/yyyy HH:00:00"))
        DateOrigineEcran = DebutHeure(DateOrigineEcran.AddMinutes(1))
        'DateFinEcran = DateOrigineEcran.AddMinutes(30 * LargMaxPanelA(SynthBoutons) / NbPixelsPour30Minutes)
        Trace.WriteLine(DateTime.Now & " " & "Date origine écran = " & DateOrigineEcran.ToString)
    End Sub

    Public Sub InitialisationsDiverses()

        Trace.WriteLine(DateTime.Now & " " & " Entrée Central_screen.vb --> Initialisations_Diverses()")
        'depart_affichage = CDate(moment_souhaite.ToString("dd/M/yyyy HH:00:00"))
        DepartAffichage = DebutHeure(MomentSouhaite)
        FinAffichage = DepartAffichage.AddHours(NbDePeriodesDe_6H * NbHeuresLigneTemps)

        GetNbEmissionsFromDb()

        'calcule nb_total_chaines
        GetNamesOfChannelsFromDatabase()

        Trace.WriteLine(DateTime.Now & " identification ") ' & NomDesChainesMemorisees)
        FillTableDesChainesASelectionner()
        'IndiceCourantTle = 1
        CalculDesBoldedDates()
        ' dates où il existe des emissions dans la BDD

        'Build_Qwery_On_Channels_Where_and_Between()
        'IndiceCourantTle = 1
        GroupFonction1()

        GroupFonction2()
        Select Case NbEmissionsForSqlRequest
            Case 0
                Trace.WriteLine(
                    DateTime.Now & " " &
                    "Arrêt de l'application car les données d'émissions sont trop anciennes")

                Miseajour.Show()
                Trace.WriteLine(DateTime.Now & " " & "Suppression de db_progs.db3 qui contient des adonnées périmées")
                Trace.WriteLine(DateTime.Now & " " & "Arrêt de l'application")

                ' Il faut fermer la BDD si elle est perimee(avant de supprimer db_progs.db3 BB101209
                ' IL faut supprimer le fichier db_progs.db3 dans application data
                ' pour pouvoir sortir de ce cycle sans fin
                File.Delete(BddPath & "db_progs.db3")
                Trace.WriteLine(
                    DateTime.Now &
                    " sortie de l application apres suppression de db_prog.mdb pour eviter boucle sans fin")
                Mainform.Tl.Close()
                Application.Exit()
        End Select

        ' On récupère les émissions marquées
        If File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
            MajFichierMarquage()
        End If

        Mainform.Timer_heure.Start()
        'BB110810 pour surveiller le rappel d emissions marquees

        Mainform.Refresh()
        FinInitialize = True
        Trace.WriteLine(DateTime.Now & " " & "Sortie Central_screen.vb --> Initialisations_Diverses()")
    End Sub

    Private Sub ClearAetBPanelboxes()

        Trace.WriteLine(DateTime.Now & " " & "sub clear A et B panel box")
        With Mainform
            .PanelA.Controls.Clear()
            .PanelB.Controls.Clear()
            '.LoaderShow()
        End With

        Application.DoEvents()
    End Sub

    Private Sub CalculDesProprietesTopDesLignesRichtextbox()

        ' en fait on calcule la prop top de toutes les emissions dans l espace
        ' de temps de 6 heures et bien au dela du nbre de chaines affichees a l ecran
        ' PREALABLE :  nb_chaines_ecran,hauteur_richtextbox
        Dim i As Integer = 1
        OrdTopLigne(i) = 0

        For i = 2 To NombreDeChainesDifferentes + 1
            OrdTopLigne(i) = OrdTopLigne(i - 1) + PeriodiciteVerticale
        Next i
    End Sub

    Private Function DateInferieure(ByVal d1 As DateTime, ByVal d2 As DateTime) As DateTime

        Select Case d1
            Case Is >= d2
                Return d2
            Case Else
                Return d1
        End Select
    End Function

    Private Function DateSuperieure(ByVal d1 As DateTime, ByVal d2 As DateTime) As DateTime

        Select Case d1
            Case Is > d2
                Return d1
            Case Else
                Return d2
        End Select
    End Function

    Private Sub FillTableDesChainesASelectionner()

        ' input: tableau_chaine(i)(mis à jour) qui est un tableau de structure
        ' à 4 colonnes
        ' ouput :table_des_chaines_a_selectionner
        ' les identificateurs des chaines ( C31.telepoche.com, C142.telpo)
        ' sont remplis dans un tableau table_des_chaines_à_selectionner
        Dim i As Integer
        For i = 1 To NbTotalChaines
            TableDesChainesASelectionner(i) = TableauChaine(i).Identificateur
        Next i
    End Sub

    Private Sub FillTableauxTopWidthLeft()

        ' input:nb_emissions_par_chaine à jour
        ' input:table_list_emissions mis à jour
        ' output:Ces tableaux contiennent les infos localisant les richtextbox à
        ' l'ecran(propriété top, left, width de richtextbox)
        ' PREALABLE: depart_affichage et fin_affichage calculé par
        ' plage_horaire_a_afficher
        Dim dStart, dDebutEcran, dStop, dFinEcran As DateTime
        Dim tps1, tps2 As TimeSpan
        Dim k, i, j, som As Integer
        Dim doubleM As Double
        Dim doubleP As Double
        Trace.WriteLine(DateTime.Now & " " & "entree dans Fill_Tableaux_Top_Width_Left")

        dFinEcran = FinAffichage
        dDebutEcran = DepartAffichage
        j = 1

        ' indice qui parcourt nb_emissions_par_chaine
        k = j

        ' k = le numero de la chaine ds nb_emissions_par_chaine
        som = NbEmissionsParChaine(1)
        For i = 1 To NbEmissionsForSqlRequest
            '-------------------------
            dStart = TableauListEmissions(i).Pstart
            dStop = TableauListEmissions(i).Pstop
            '-------------------------
            dStop = DateInferieure(dStop, dFinEcran)
            dStart = DateInferieure(dStart, dFinEcran)
            dStop = DateSuperieure(dStop, dDebutEcran)
            dStart = DateSuperieure(dStart, dDebutEcran)

            tps1 = dStop.Subtract(dStart)

            ' duree emission
            doubleM = (1440 * tps1.Days + 60 * tps1.Hours + tps1.Minutes + (tps1.Seconds / 60)) * Echelle1
            If doubleM < 0 Then
                Trace.WriteLine(DateTime.Now & " " & "double_m était négatif " & doubleM.ToString)
                doubleM = 1
                Trace.WriteLine(DateTime.Now & " " & "dstart= " & dStart.ToString & " dstop = " & dStop.ToString)
            End If
            tps2 = dStart.Subtract(dDebutEcran)

            ' ecart debut emission et debut ecran
            doubleP = (1440 * tps2.Days + 60 * tps2.Hours + tps2.Minutes + (tps2.Seconds / 60)) * Echelle1
            If doubleP < 0 Then
                Trace.WriteLine(DateTime.Now & " " & "double_p était négatif " & doubleP.ToString)
                doubleP = 1
            Else
            End If
            ValWidth(i) = CInt(Math.Truncate(doubleM))
            ValLeft(i) = CInt(Math.Truncate(doubleP))
            ValTop(i) = OrdTopLigne(k)

            j += 1

            ' on incremente le compteur de nombre d emissions
            If j > som Then
                k += 1

                ' on passe a la chaine suivante
                som = som + NbEmissionsParChaine(k)
            End If
        Next i
        'Select Case TriCategorie
        '    Case False
        '' S 'assurer que 2 richtextbox ne sont pas séparés que par 1 pixels
        Dim n As Integer
        For i = 1 To NbEmissionsForSqlRequest - 1
            n = ValLeft(i + 1) - (ValLeft(i) + ValWidth(i))
            ValWidth(i) += n - 1
        Next i
        'End Select
    End Sub

    Public Sub FillTableauxTopWidthLeftCeSoir()

        ' input:nb_emissions_par_chaine à jour
        ' input:table_list_emissions mis à jour
        ' output:  Ces tableaux contiennent les infos localisant
        ' les richtextbox à 
        ' l'ecran(propriété top, left, width de richtextbox)
        ' PREALABLE: depart_affichage et fin_affichage calculé
        ' par plage_horaire_a_afficher
        Dim i As Integer

        'ValLeftCesoirMaintenant = LargeurLogoAdaptee
        ValWidthCesoirMaintenant = Mainform.Calendar.Width - LargeurLogoAdaptee
        For i = 0 To NbEmissionsForCeSoir
            ValTopCeSoir(i) = i * (HauteurRichtextbox + EspaceEntreRichtextbox)
        Next i
    End Sub

    Public Sub FillTableauxTopWidthLeftMaintenant()

        ' input:table_list_emissions_maintenant mis à jour
        ' output:  Ces tableaux contiennent les infos localisant
        ' les richtextbox à
        ' l'ecran(propriété top, left, width de richtextbox)
        Dim i As Integer
        'ValLeftCesoirMaintenant = LargeurLogoAdaptee
        ValWidthCesoirMaintenant = Mainform.Calendar.Width - LargeurLogoAdaptee
        For i = 0 To NbEmissionsForMaintenant
            ValTopMaintenant(i) = i * (HauteurRichtextbox + EspaceEntreRichtextbox)
        Next i
    End Sub

    Private Sub FillNbEmissionsParChaineAfterSqlRequest()

        ' input : tableau_list_emissions(i)
        ' output : nb_emissions_par_chaine(i)
        ' cette sr ne repère pas les chaines
        ' qui n'emettent pas pendant le laps de temps choisi
        Dim i, j, count As Integer

        For i = 1 To NbTotalChaines
            NbEmissionsParChaine(i) = 0
        Next i

        j = 1
        count = 1
        Try

            For i = 1 To (NbEmissionsForSqlRequest)
                If [String].Equals(TableauListEmissions(i + 1).ChannelId, TableauListEmissions(i).ChannelId, StringComparison.CurrentCulture) Then
                    count += 1
                Else
                    NbEmissionsParChaine(j) = count
                    j += 1
                    count = 1
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If count <> 1 Then
            NbEmissionsParChaine(j) = count - 1
        End If
    End Sub

    Private Sub CalculProprietesTopDesLogo()

        ' le nbre de logos=le nbre de chaines différentes avec présence
        ' d 'émissions
        Dim i, z1, z2 As Integer
        Dim t As Integer = 1

        ' ces valeurs top sont les mêmes que celles des richtextbox
        ' attention il y a des valeurs identiques pour tous les
        ' richtextbox d'une même chaine
        For i = 1 To NbChainesEcran + 1
            z1 = OrdTopLigne(i - 1)
            z2 = OrdTopLigne(i)
            If z2 <> z1 Then
                ValTopLogo(t) = z1
                t += 1
            End If
        Next i
    End Sub

    Private Sub FillChaineLogoUnique()

        ' input
        ' table_des_chaines_a_selectionner
        ' tableau_chaine(x).logo
        ' output : nb de chaines_differentes
        ' hauteur de panel A et Panel B

        Dim i, m, t As Integer
        Dim z As String
        Dim tableIntermediaire(NbTotalChaines + 1) As String
        Trace.WriteLine(DateTime.Now & " entree dans fill chaine logo unique")
        For i = 1 To NbTotalChaines
            ChaineLogoUnique(i) = Nothing
            tableIntermediaire(i) = TableauChaine(i).Identificateur
        Next i

        Dim oldz As String = ""
        t = 1
        For i = 1 To NbEmissionsForSqlRequest
            z = TableauListEmissions(i).ChannelId
            If Not [String].Equals(z, oldz, StringComparison.CurrentCulture) Then
                oldz = z
                m = Array.IndexOf(tableIntermediaire, z)
                ChaineLogoUnique(t) = TableauChaine(m).Logo
                t += 1
            End If
        Next i
        NombreDeChainesDifferentes = t - 1

        With My.Settings
            .nbchainesdiff = NombreDeChainesDifferentes
            .Save()
        End With

        ' nombre de chaines differentes etant connu on peut attribuer la taille en hauteur de panelA
        With Mainform
            .PanelA.Height = 10 + PeriodiciteVerticale * NombreDeChainesDifferentes
            .PanelB.Height = 10 + PeriodiciteVerticale * NombreDeChainesDifferentes
        End With
    End Sub

    Private Sub FillColorOfRichtextbox()

        Dim i, n, vert, bleu, rouge As Integer
        Dim z As String

        Trace.WriteLine(DateTime.Now & " " & "Entrée sub fill_color_of_richtextbox")

        ' rvs75,08/10/2009, création des couleurs manquantes
        If TableauTypeEmissionFranVar.Length > _tabCouleur.Length Then

            Dim tiit As Integer = CInt(Fix((TableauTypeEmissionFranVar.Length - _tabCouleur.Length) ^ (1 / 3))) + 1
            Dim cptCouleur As Integer = _tabCouleur.Length
            ReDim Preserve _tabCouleur(_tabCouleur.Length + CInt((tiit ^ 3)))

            Dim palier As Int32() = {255, 220, 235, 175, 205, 190}

            For vert = 0 To tiit - 1
                For bleu = 0 To tiit - 1
                    For rouge = 0 To tiit - 1
                        _tabCouleur(cptCouleur) =
                            Color.FromArgb(palier(rouge), palier(vert) - 25, palier(bleu) - 5)
                        cptCouleur += 1
                    Next
                Next
            Next
        End If

        ' Néo 30/05/2013 Les catégories sont triées par ordre alphabétique
        Array.Sort(TableauTypeEmissionFranVar)

        For i = 1 To NbEmissionsForSqlRequest
            z = TableauListEmissions(i).PcategoryTv
            If Not (z Is Nothing) AndAlso Not (z Is String.Empty) Then
                n = Array.IndexOf(TableauTypeEmissionFranVar, z)
                ' Couleur de l'émission suivant la catégorie
                ValBackcolor(i) = _tabCouleur(n)
            Else
                ' Catégorie non précisée
                ValBackcolor(i) = Color.LightGray
            End If
        Next i
        Trace.WriteLine(DateTime.Now & " " & "Sortie de fill color richtextbox")
    End Sub

    Public Sub FillColorOfRichtextboxCeSoir()

        Dim i As Integer
        Dim n As Integer
        Dim z As String

        Trace.WriteLine(DateTime.Now & " " & "Entrée dans fill color richtextbox ce soir")

        ' Néo 30/05/2013 Les catégories sont triées par ordre alphabétique
        Array.Sort(TableauTypeEmissionFranVar)

        For i = 0 To NbEmissionsForCeSoir - 1
            z = TableauListEmissionsCeSoir(i).PcategoryTv
            If Not (z Is Nothing) AndAlso Not (z Is String.Empty) Then
                n = Array.IndexOf(TableauTypeEmissionFranVar, z)
                ValBackcolorCeSoir(i + 1) = _tabCouleur(n)
            Else
                ' Catégorie non précisée
                ValBackcolorCeSoir(i + 1) = Color.LightGray
            End If
        Next i
        Trace.WriteLine(DateTime.Now & " " & "Sortie de fill color richtextbox ce soir")
    End Sub

    Public Sub FillColorOfRichtextboxMaintenant()

        Dim i As Integer
        Dim n As Integer
        Dim z As String
        ValBackcolorMaintenant(0) = Color.LightGray

        Trace.WriteLine(DateTime.Now & " " & "Entrée dans fil color richtextbox Maintenant")

        ' Néo 30/05/2013 Les catégories sont triées par ordre alphabétique
        Array.Sort(TableauTypeEmissionFranVar)

        For i = 0 To NbEmissionsForMaintenant - 1
            z = TableauListEmissionsMaintenant(i).PcategoryTv
            If Not (z Is Nothing) AndAlso Not (z Is String.Empty) Then
                n = Array.IndexOf(TableauTypeEmissionFranVar, z)
                ValBackcolorMaintenant(i + 1) = _tabCouleur(n)
            Else
                ' Catégorie non précisée
                ValBackcolorMaintenant(i + 1) = Color.LightGray
            End If
        Next i
        Trace.WriteLine(DateTime.Now & " " & "Sortie de fill color richtextbox Maintenant")
    End Sub

    Public Sub GroupFonction2()

        ' est appelee dans:btnsauver
        ' dans groupfonction1 , List_of_empty_channles a ete calculé
        ' il ya peut etre des chaines sans emissions
        ' on recalcule donc tableau_chaine(pour ne plus tenir
        ' compte des chaines qui n'ont pas d'emission
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans group_fonction2")
        SecondFillTableauChaine()
        FillChaineLogoUnique()
        SecondFillTableDesChainesASelectionner()
        NbChainesEcran = NombreDeChainesDifferentes
        'PremiereEmissionNonVisible()
        Trace.WriteLine(
            DateTime.Now & " " &
            "Modification de height pour panelA et panelD en fonction nb chaines differentes")
        CalculDesProprietesTopDesLignesRichtextbox()

        FillTableauxTopWidthLeft()
        FillColorOfRichtextbox()
        ClearAetBPanelboxes()
        AffectRichtextboxParameters()
    End Sub

    Public Sub GroupFonction1()

        GetListOfEmissionsForSqlWhereAndBetween()

        Select Case NbEmissionsForSqlRequest
            Case 0
                Trace.WriteLine(
                    DateTime.Now & " " &
                    "Arrêt de l'application car les données d'émissions sont trop anciennes")
                Mainform.Tl.Close()
                ' fermeture du fichier log
                Application.Exit()
        End Select
        FillNbEmissionsParChaineAfterSqlRequest()

        ' calculer , meme pour les chaines vides,  le nombre d emissions
        ' c'est different de nb_emissions_par_chaine qui ne contient pas
        ' de valeurs nulles
        CalculNoeBySql()
    End Sub

    Private Sub SecondFillTableauChaine()

        ' Ouput : on elimine dans tableau_chaine les references 0
        ' à des chaines sans emissions toujours pour la periode choisie
        Dim tempo(NbTotalChaines + 5) As ChannelList
        Dim i As Integer
        Dim origine As Integer
        Dim destination As Integer = 1
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans second_fill_tableau_chaine")

        For i = 1 To NbTotalChaines
            tempo(i) = TableauChaine(i)
        Next i

        For origine = 1 To NbTotalChaines
            If NbEmissionsYc0ApresTriParChaine(origine) <> 0 Then
                TableauChaine(destination) = tempo(origine)
                destination += 1
                Continue For
            Else
                Continue For
            End If
        Next origine
        NbTotalChaines = destination
        'Do While destination < NbTotalChaines
        '    With TableauChaine(destination)
        '        .Nom = String.Empty
        '        .Identificateur = String.Empty
        '        .Indice = 0
        '        .Logo = Nothing
        '        destination += 1
        '    End With
        'Loop
    End Sub

    Private Sub SecondFillTableDesChainesASelectionner()

        ' cette sr permet d avoir une liste des chaines qui comportent
        ' TOUTES des emissions pour la periode de temps imposee
        ' par le nombre de periodes de 6 heures
        Dim i As Integer
        Dim destination As Integer
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans second_fill_table_des_chaines_a_selectionner")

        'destination = 1
        For i = 1 To NbTotalChaines
            'TableDesChainesASelectionner(i) = ""
            TableDesChainesASelectionner(i) = TableauChaine(i).Identificateur
        Next i
        TableDesChainesASelectionner(i) = ""

        Trace.WriteLine(DateTime.Now & " " & "nb_total chaine =  " & NbTotalChaines.ToString)

        ' il faut reconstruire nb_emissions_yc0_apres_tri_par_chaine
        ' à partir de nb_emissions_par_chaines par copie simple
        Trace.WriteLine(DateTime.Now & " ds second_fill_table_des_chines , nb_emissions_yc0_par chaine")
        destination = 1
        For i = 0 To NbTotalChaines
            If NbEmissionsParChaine(i) <> 0 Then
                NbEmissionsYc0ApresTriParChaine(destination) = NbEmissionsParChaine(i)
                Trace.WriteLine(DateTime.Now & " " &
                                " chaine n° = " & destination.ToString & " nb emissions = " &
                                NbEmissionsParChaine(i).ToString)
                destination += 1
                Continue For
            Else
                Continue For
            End If
        Next i
        NbEmissionsYc0ApresTriParChaine(destination) = 0
        Trace.WriteLine(DateTime.Now & " " & "Sortie de second_fill_table_des_chaines_a_selectionner")
    End Sub

    Private Sub AffectLogoPicturebox(ByVal offset As Integer)

        ' cet offset est determine par le nbre de fois qu on est passe
        ' dans mousewheel pour bouger dans les chaines a afficher
        Trace.WriteLine(DateTime.Now & " " & "entree dans Affect Logo Picturebox (offset)")
        Dim indiceReduit As Integer
        Dim i As Integer

        'kill_handle(Mainform.PanelB)
        Mainform.PanelB.Controls.Clear()

        Dim logobox As New PictureBox()
        With logobox
            .SizeMode = PictureBoxSizeMode.Zoom
            .Left = 0
            .Top = 0
            .Height = 0
            .Width = 0
            .Image = Nothing
        End With

        ' panelB contient les picturebox pour les logos et se situe a gauche
        ' de panelA

        Try
            Mainform.PanelB.Controls.Add(logobox)
        Catch ex As Win32Exception
            Dim instance As New Win32Exception
            Dim value As Integer
            value = instance.NativeErrorCode
            Trace.WriteLine(DateTime.Now & " " & "Dans affect logo picture box debut :error code = " & value.ToString)
        End Try

        'CompteurControlesLogo = Mainform.PanelB.Controls.Count

        ' attention il peut y avoir des chaines qui n emettent pas donc
        ' la chaine_logo_unique n est remplie que jusque
        ' nombre_de_chaines_differentes

        indiceReduit = NombreDeChainesDifferentes

        If (offset + 1) > 0 AndAlso indiceReduit > 0 Then
            For i = offset + 1 To offset + NbChainesEcran
                Dim sb4 As String
                sb4 = LogosPath
                sb4 = sb4 & ChaineLogoUnique(i)

                Dim logobox1 As New PictureBox
                With logobox1
                    AddHandler .MouseDoubleClick, AddressOf ShowJournee
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = ValTopLogo(i - offset)
                    .Height = HauteurRichtextbox
                    .Width = LargeurLogoAdaptee
                    Try
                        .Image = Image.FromFile(sb4.ToString)
                    Catch ex As Exception
                        Trace.WriteLine("il manque le logo " & sb4.ToString)
                    End Try
                End With

                Try
                    Mainform.PanelB.Controls.Add(logobox1)
                Catch ex As Win32Exception
                    Dim instance As New Win32Exception
                    Dim value As Integer
                    value = instance.NativeErrorCode
                    Trace.WriteLine(
                        DateTime.Now & " " & "Dans affect logo picture box  n° " & i.ToString &
                        "fin ,error code = " & value.ToString)

                End Try

                Application.DoEvents()
                'BB 260710
            Next i
        Else
        End If

        'CompteurControlesLogo = Mainform.PanelB.Controls.Count
        Trace.WriteLine(DateTime.Now & " " & "Nb controles logobox = " & Mainform.PanelB.Controls.Count.ToString())

        With Mainform
            .PanelB.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picture box")
    End Sub

    Public Sub AffectLogoPictureboxCeSoir(ByVal offset As Integer)
        Dim chaineLogoUniqueCeSoir(Val200) As String 'scope trop grand , a mettre dans centra_screen./AffectLogoPictureboxCeSoir
        ' cet offset est de signification inchangée
        Trace.WriteLine(DateTime.Now & " " & "Affect Logo Picturebox_ce_soir (offset)")
        Dim i As Integer
        Mainform.Panel_ce_soir.SuspendLayout()

        'Dim logobox As New PictureBox()
        'With logobox
        '    .SizeMode = PictureBoxSizeMode.Zoom
        '    .Left = 0
        '    .Top = 0
        '    .Height = 0
        '    .Width = 0
        '    .Image = Nothing
        'End With

        '' panel_ce_soir contient,dans sa partie gauche les picturebox
        '' pour les logos et se situe a droite de panelA
        '' panel_ce_soir contient,dans sa partie droite les picturebox
        '' avec le titre de l emission

        'Try
        '    Mainform.Panel_ce_soir.Controls.Add(logobox)
        'Catch ex As Win32Exception
        '    'Dim instance As New Win32Exception
        '    'Dim value As Integer
        '    'value = instance.NativeErrorCode
        '    'Trace.WriteLine(
        '    '    DateTime.Now & " " & "Dans affect logo picture box ce_soir debut :error code = " &
        '    '    value.ToString)
        '    Trace.WriteLine(
        '            DateTime.Now & " " & "Dans affect logo picture box ce_soir debut :error code = " &
        '             ex.NativeErrorCode.ToString)

        'End Try

        ' attention il peut y avoir des chaines qui n emettent pas donc
        ' la chaine_logo_unique n est remplie que jusque
        ' nombre_de_chaines_differentes

        Trace.WriteLine(DateTime.Now & " " & "nb_emissions pour logo ce soir: " & NbEmissionsForCeSoir)
        ' If (offset + 1) > 0 And indice_reduit > 0 Then
        Trace.WriteLine(" ")
        For i = offset To offset + NbEmissionsForCeSoir - 1
            Dim sb4 As String
            'sb4 = LogosPath

            ' tableau_liste_emissions_ce_Soir  a un champ( channelid) du type
            ' C40.telepoche.com)
            ' on recherche dans tableau_chaine(i) l indice j pour
            ' lequel tableau_chaine(j).id = C40.telepoche
            ' A ce moment tableau_chaine(j).logo est le nom du fichier image

            Trace.WriteLine(
                DateTime.Now & " i= " & i.ToString & " tableau_list_emissions_ce_soir(i).channelID = " &
                TableauListEmissionsCeSoir(i).ChannelId)
            Dim trouveidentif As Boolean = False
            Dim k As Integer

            For k = 1 To NbTotalChaines
                If [String].Equals(TableauChaine(k).Identificateur, TableauListEmissionsCeSoir(i).ChannelId, StringComparison.CurrentCulture) Then
                    Trace.WriteLine(
                        DateTime.Now & " k= " & k.ToString & " tableau_chaine(k).identificateur = " &
                        TableauChaine(k).Identificateur)
                    chaineLogoUniqueCeSoir(i) = TableauChaine(k).Logo
                    trouveidentif = True
                    Exit For
                Else
                End If
            Next k
            Trace.WriteLine(" ")

            If trouveidentif Then

                'sb4 = sb4 & ChaineLogoUniqueCeSoir(i)
                sb4 = LogosPath & chaineLogoUniqueCeSoir(i)
                Dim logobox1 As New PictureBox
                With logobox1
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = ValTopCeSoir(i - offset)
                    .Height = HauteurRichtextbox
                    .Width = LargeurLogoAdaptee
                    .Image = Image.FromFile(sb4)
                End With

                Try
                    Mainform.Panel_ce_soir.Controls.Add(logobox1)
                Catch ex As Win32Exception
                    'Dim instance As New Win32Exception
                    'Dim value As Integer
                    'value = instance.NativeErrorCode
                    'Trace.WriteLine(
                    '    DateTime.Now & " " & "Dans affect logo picture box ce_soir fin ,error code = " &
                    '    value.ToString)
                    'Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & Instance.Message)
                    Trace.WriteLine(
                     DateTime.Now & " " & "Dans affect logo picture box ce_soir fin ,error code = " &
                        ex.NativeErrorCode.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & ex.Message)

                End Try
            Else
                Trace.WriteLine(
                    DateTime.Now & " " & "on n a pas trouve le logo pour " &
                    TableauListEmissionsCeSoir(i).ChannelId)
            End If
        Next i

        With Mainform
            .Panel_ce_soir.ResumeLayout()
            .Panel_ce_soir.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picturebox ce soir")
    End Sub

    Public Sub AffectLogoPictureboxMaintenant(ByVal offset As Integer)
        Dim chaineLogoUniqueMAintenant(Val200) As String 'scope trop grand , a mettre dans centra_screen./AffectLogoPictureboxMaintenant
        ' cet offset est de signification inchangee
        Trace.WriteLine(DateTime.Now & " " & "Affect Logo Picturebox_maintenant (offset)")
        Dim i As Integer
        Mainform.Panel_maintenant.SuspendLayout()
        'Dim logobox As New PictureBox()
        'With logobox
        '    .SizeMode = PictureBoxSizeMode.Zoom
        '    .Left = 0
        '    .Top = 0
        '    .Height = 0
        '    .Width = 0
        '    .Image = Nothing
        'End With

        '' panel_ce_soir contient, dans sa partie gauche
        '' les picturebox pour les logos et se situe a droite de panelA
        '' panel_ce_soir contient, dans sa partie droite
        '' les picturebox avec le titre de l emission

        'Try
        '    Mainform.Panel_maintenant.Controls.Add(logobox)
        'Catch ex As Win32Exception
        '    'Dim instance As New Win32Exception
        '    'Dim value As Integer
        '    'value = instance.NativeErrorCode
        '    'Trace.WriteLine(
        '    '    DateTime.Now & " " & "Dans affect logo picture box ce_soir debut :error code = " &
        '    '    value.ToString)
        '    Trace.WriteLine(
        '        DateTime.Now & " " & "Dans affect logo picture box ce_soir debut :error code = " &
        '        ex.NativeErrorCode.ToString)

        'End Try

        ' attention il peut y avoir des chaines qui n emettent pas donc
        ' la chaine_logo_unique n est remplie que jusque
        ' nombre_de_chaines_differentes

        For i = offset To offset + NbEmissionsForMaintenant - 1
            Dim sb4 As String
            'sb4 = LogosPath

            ' tableau_liste_emissions_maintenant  a un champ( channelid)
            ' du type C40.telepoche.com)
            ' on recherche dans tableau_chaine(i) l indice j
            ' pour lequel tableau_chaine(j).id = C40.telepoche 
            ' Alors tableau_chaine(j).logo est le nom du fichier image
            Dim trouveIdentif As Boolean = False

            Dim k As Integer
            For k = 1 To NbTotalChaines
                If [String].Equals(TableauChaine(k).Identificateur, TableauListEmissionsMaintenant(i).ChannelId, StringComparison.CurrentCulture) Then
                    chaineLogoUniqueMAintenant(i) = TableauChaine(k).Logo
                    trouveIdentif = True
                    Exit For
                Else
                End If
            Next k
            If trouveIdentif Then
                'sb4 = sb4 & ChaineLogoUniqueMAintenant(i)
                sb4 = LogosPath & chaineLogoUniqueMAintenant(i)

                Dim logobox1 As New PictureBox
                With logobox1
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = ValTopMaintenant(i - offset)
                    .Height = HauteurRichtextbox
                    .Width = LargeurLogoAdaptee
                    .Image = Image.FromFile(sb4)
                End With
                Try
                    Mainform.Panel_maintenant.Controls.Add(logobox1)
                Catch ex As Win32Exception
                    'Dim instance As New Win32Exception
                    'Dim value As Integer
                    'value = instance.NativeErrorCode
                    'Trace.WriteLine(
                    '    DateTime.Now & " " & "Dans affect logo picture box ce_soir fin ,error code = " &
                    '    value.ToString)
                    'Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & instance.Message)
                    Trace.WriteLine(
                        DateTime.Now & " " & "Dans affect logo picture box ce_soir fin ,error code = " &
                        ex.NativeErrorCode.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & ex.Message)

                End Try
            Else
                Trace.WriteLine(
                    DateTime.Now & " " & "on n a pas trouve le logo pour " &
                    TableauListEmissionsMaintenant(i).ChannelId)
            End If
        Next i

        With Mainform
            .Panel_maintenant.ResumeLayout()
            .Panel_maintenant.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picture box maintenant")
    End Sub

    Private Sub Mdown(ByVal sender As Object, ByVal e As MouseEventArgs)

        ' AU moyen d'un click sur la molette centrale de la souris,
        ' on peut marquer  l'emission sur laquelle on a cliqué
        ' ( au moyen de ////) ou supprimer cette marque
        ' existante
        Dim l As Integer
        Dim titre, z, z1 As String

        Select Case e.Button

            Case MouseButtons.Left
                If e.Clicks > 1 Then
                    RechercherEmissionSurInternet(DirectCast(sender, Control))
                End If

                ' Néo 04/10/2013
                ' Pour rendre compatible avec Windows 8 on utilise désormais le clic droit afin de marquer une émission
                ' Car le clic sur la molette de la souris active la vue panoramique des applications dans Windows 8.
            Case MouseButtons.Right

                Trace.WriteLine(DateTime.Now & " " & "passage dans sub mousedown roulette centrale")
                _repereClickEmission = CInt(CType(sender, Control).TabIndex)
                Trace.WriteLine(DateTime.Now & " " & "repere_click_emission=" & _repereClickEmission.ToString)
                z1 = TableauListEmissions(_repereClickEmission).Ptitle
                z = z1

                ' rvs75 25/08/2010
                If DirectCast(sender, PaveCentral).Marquage Then

                    ' on veut demarquer une emission deja marquee
                    ' C est a dire enlever 4 espaces  avant et après le titre de l emisson
                    _heureDebutDemarquee =
                        TableauListEmissions(_repereClickEmission).Pstart.ToString("yyyy/MM/dd HH:mm:ss")
                    _chaineDemarquee = TableauListEmissions(_repereClickEmission).ChannelId.ToString

                    _heureFinDemarquee =
                        TableauListEmissions(_repereClickEmission).Pstop.ToString("yyyy/MM/dd HH:mm:ss")
                    l = z.Length
                    titre = Mid(z, 5, l - 8)
                    TableauListEmissions(_repereClickEmission).Ptitle = titre.ToLower

                    DirectCast(sender, PaveCentral).Marquage = False
                    Mainform.PanelA.Controls(_repereClickEmission + 1).Text =
                        TableauListEmissions(_repereClickEmission).Ptitle

                    ' Il faut enlever du fichier marked.set l emission que l on vient de demarquer 
                    Dim nomDuFichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
                    If Not (File.Exists(nomDuFichier)) Then
                        Exit Sub
                    End If

                    ' 250310 si le fichier n existe pas il n y a rien a recuperer
                    Dim strligne As String
                    Dim chaineGlobale As String = ""
                    MonStreamDocument = New StreamReader(nomDuFichier)

                    Do While (MonStreamDocument.Peek <> -1)
                        ' Tant qu il y a des records ds le fichier
                        strligne = MonStreamDocument.ReadLine
                        If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                            Dim hStart, nomChaine, hStop, ttitre As String
                            hStart = ""
                            nomChaine = ""
                            hStop = ""
                            ttitre = ""

                            DecomposerEnregistrement(strligne, hStart, nomChaine, ttitre, hStop)

                            If _
                                Not [String].Equals(hStart, _heureDebutDemarquee, StringComparison.CurrentCulture) Or
                                Not [String].Equals(hStop, _heureFinDemarquee, StringComparison.CurrentCulture) Or
                                Not [String].Equals(nomChaine, _chaineDemarquee, StringComparison.CurrentCulture) Or
                                Not [String].Equals(ttitre, titre, StringComparison.CurrentCulture) Then
                                chaineGlobale = chaineGlobale & strligne & vbCrLf
                            End If
                        End If
                    Loop
                    MonStreamDocument.Close()
                    'sr.Close()
                    Dim nomDuFichierDestination As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
                    Dim sw2 As New StreamWriter(nomDuFichierDestination, False)
                    ' on ecrase le fichier existant
                    Trace.WriteLine(
                        DateTime.Now & " " &
                        "apres suppression eventuelle des lignes perimees,  le fichier devient : " &
                        chaineGlobale & vbCrLf)
                    With sw2
                        .WriteLine(chaineGlobale)
                        .Close()
                        .Dispose()
                    End With

                    Application.DoEvents()
                    If File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
                        SupprimerFichierMarquage()
                    End If

                Else
                    '---------------------------------
                    ' on veut marquer une emission
                    '-------------------------------
                    titre = "    " & z1 & "    "

                    DirectCast(sender, PaveCentral).Marquage = True
                    AjouterLigneFichierMarquage(_repereClickEmission)
                    Application.DoEvents()

                    ' eliminer les emissions marquees qui sont perimées
                    MajFichierMarquage()
                    Application.DoEvents()
                    Mainform.Timer_heure.Start() ' BB260810 on lance d office le timer apres un marquage
                End If

                DirectCast(sender, PaveCentral).Text = titre
                TableauListEmissions(_repereClickEmission).Ptitle = titre

                With Mainform
                    .Timer_minute.Start()
                    .Timer_minute.Enabled = True
                End With
        End Select
    End Sub

    Private Sub CreerEmssionForAffectRichtextboxParameters(ByVal i As Integer)

        Dim box1 As New PaveCentral
        With box1
            AddHandler .MouseEnter, AddressOf MouseToolTip
            AddHandler .MouseLeave, AddressOf Mouse_Leave
            AddHandler .MouseDown, AddressOf Mdown

            .OldUi = CBool(My.Settings.oldUI)
            .Name = "Botton_Em"
            .Left = ValLeft(i)
            .Top = ValTop(i)
            .Height = HauteurRichtextbox
            .Width = ValWidth(i)
            .Text = TableauListEmissions(i).Ptitle
            .BgColor = ValBackcolor(i)
            .Align = StringAlignment.Near
            .Tag = TableauListEmissions(i).PcategoryTv
            .TabIndex = i

        End With
        Try
            Mainform.PanelA.Controls.Add(box1)

        Catch ex As Win32Exception
            Trace.WriteLine(
                DateTime.Now & " " & "Exception lors de l ajout de la box n° " & i.ToString &
                " box1 dans affect richtextbox parameters")
            Dim instance As New Win32Exception
            Dim value As Integer
            value = instance.NativeErrorCode
            Trace.WriteLine(DateTime.Now & " " & "Error code = " & value.ToString)
        End Try
    End Sub

    Private Sub AffectRichtextboxParameters()

        'Modifié par Néo le 24/08/2010
        Dim i As Integer
        Dim memochaine As String = ""
        Dim tableauEmission(NbChainesEcran) As AffichagePanelA
        Dim ctpChaine As Integer = -1

        For i = 1 To NbRecordLimiteForSqlRequest

            'recherche des emissions visible et non visible
            If Not (memochaine.Equals(TableauListEmissions(i).ChannelId)) Then
                memochaine = TableauListEmissions(i).ChannelId
                ctpChaine += 1
                tableauEmission(ctpChaine).DebutEmission = i

            Else
                If TableauListEmissions(i).Pstart < DateReference.AddHours(14) Then
                    tableauEmission(ctpChaine).EmissionVisible += 1
                Else
                    tableauEmission(ctpChaine).EmissionNonvisible += 1
                End If
            End If
        Next

        Trace.WriteLine(DateTime.Now & " entree dans affect_richtextbox_parameters")

        'creation des boutons des emissions visibles 
        For t As Integer = 0 To NbChainesEcran - 1
            With tableauEmission(t)
                For p As Integer = .DebutEmission To .DebutEmission + .EmissionVisible
                    CreerEmssionForAffectRichtextboxParameters(p - 1)
                Next
            End With
        Next
        Mainform.DessineLigneTemps()

        CalculProprietesTopDesLogo()
        AffectLogoPicturebox(0)
        CurseurVertical()

        'creation des boutons des emissions non visibles 
        For t As Integer = 0 To NbChainesEcran - 1
            With tableauEmission(t)
                For p As Integer = .DebutEmission + .EmissionVisible To _
                    .DebutEmission + .EmissionVisible + .EmissionNonvisible
                    CreerEmssionForAffectRichtextboxParameters(p - 1)
                Next
            End With
        Next

        'CompteurControlesRichtextbox = Nothing

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect_richtextbox_parameters")
    End Sub

    Public Sub AffectRichtextboxCeSoir()
        Dim i As Integer
        Mainform.Panel_ce_soir.SuspendLayout()
        Mainform.Panel_ce_soir.Controls.Clear()

        'i = 0
        'Dim box2 As New Button
        'With box2
        '    .FlatStyle = FlatStyle.Popup
        '    .Left = 0
        '    .Top = ValTopCeSoir(i)
        '    .Height = HauteurRichtextbox
        '    .Width = Mainform.Calendar.Width
        '    ' ReSharper disable LocalizableElement
        '    .Text = "Ce soir"
        '    ' ReSharper restore LocalizableElement
        '    ValBackcolorCeSoir(0) = Color.LightGray
        '    .BackColor = ValBackcolorCeSoir(i)
        '    .ForeColor = Color.Black
        '    .TextAlign = ContentAlignment.MiddleLeft
        'End With

        'Mainform.Panel_titre_ce_soir.Controls.Add(box2)

        For i = 0 To NbEmissionsForCeSoir - 1

            ' 17/09/2009 rvs75 si oldUI=1 dans le .config c'est un bouton sinon c'est un GradientButton
            Dim chaine As String
            chaine = TableauListEmissionsCeSoir(i).Ptitle

            Dim box1 As New PaveCentral
            With box1
                AddHandler .MouseDown, AddressOf FonctionClickEmission
                AddHandler .MouseEnter, AddressOf MouseToolTip

                .OldUi = CBool(My.Settings.oldUI)
                .Left = LargeurLogoAdaptee
                .Top = ValTopCeSoir(i)
                .Height = HauteurRichtextbox
                .Width = ValWidthCesoirMaintenant
                If chaine.Length > 38 Then .Text = chaine.Substring(0, 35) & "..." Else .Text = chaine
                .BgColor = ValBackcolorCeSoir(i + 1)
                .ForeColor = Color.Black
                .Align = StringAlignment.Near

            End With
            Try
                Mainform.Panel_ce_soir.Controls.Add(box1)
            Catch ex As Win32Exception
                Trace.WriteLine(
                    DateTime.Now & " " & "Exception lors de l'ajout de la  box n° " & i.ToString &
                    "  dans affect richtextbox ce_soir")
                'Dim instance As New Win32Exception
                'Dim value As Integer
                'value = instance.NativeErrorCode
                'Trace.WriteLine(
                '    DateTime.Now & " " & "Error code = " & value.ToString &
                '    ";  Exception message  = " &
                '    instance.Message)
                Trace.WriteLine(
                    DateTime.Now & " " & "Error code = " & ex.NativeErrorCode.ToString &
                    ";  Exception message  = " &
                    ex.Message)
                Application.DoEvents()
            End Try

            Application.DoEvents()
        Next i
        Mainform.Panel_ce_soir.ResumeLayout()
    End Sub

    Public Sub AffectRichtextboxMaintenant()

        'rvs75 10/08/2010 remplacement des boutons par des paveActuellement
        Dim i As Integer
        Mainform.Panel_maintenant.SuspendLayout()
        Mainform.Panel_maintenant.Controls.Clear()

        Trace.WriteLine(DateTime.Now & " " & "paneau_maintenant.width= " & Mainform.Panel_maintenant.Width.ToString)

        'Dim box2 As New Button
        'With box2
        '    .FlatStyle = FlatStyle.Popup
        '    .Left = 0
        '    .Top = ValTopMaintenant(i)
        '    .Height = HauteurRichtextbox
        '    .Width = Mainform.Calendar.Width
        '    .Text = MaintenantEtHeure
        '    .BackColor = ValBackcolorMaintenant(i)
        '    .ForeColor = Color.Black
        '    .TextAlign = ContentAlignment.MiddleLeft
        'End With

        'Try
        '    Mainform.Panel_titre_maintenant.Controls.Add(box2)
        'Catch ex As Win32Exception
        'Trace.WriteLine(
        '    DateTime.Now & " Exception lors de l'ajout de la  box n° " & i.ToString &
        '    "  dans affect richtextbox ce_soir")
        'Dim instance As New Win32Exception
        'Dim value As Integer
        'value = instance.NativeErrorCode
        'Trace.WriteLine(DateTime.Now & " " & "Error code = " & value.ToString)
        'Trace.WriteLine(DateTime.Now & " " & "Numéro de la box ajoutée posant problème = " & i.ToString)
        'Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & instance.Message)
        'End Try

        For i = 0 To NbEmissionsForMaintenant - 1
            Dim chaine As String
            chaine = TableauListEmissionsMaintenant(i).Ptitle
            'rvs75 10/08/2010 : debut de modif
            Dim debut As DateTime = TableauListEmissionsMaintenant(i).Pstart
            Dim fin As DateTime = TableauListEmissionsMaintenant(i).Pstop

            Dim box1 As New PaveActuellement
            With box1
                AddHandler .MouseDown, AddressOf FonctionClickEmission
                AddHandler .MouseEnter, AddressOf MouseToolTip

                .Left = LargeurLogoAdaptee
                .Top = ValTopMaintenant(i)
                .Height = HauteurRichtextbox
                .Width = ValWidthCesoirMaintenant
                If chaine.Length > 38 Then .Text = chaine.Substring(0, 35) & "..." Else .Text = chaine
                .BgColor = ValBackcolorMaintenant(i + 1)
                .Align = StringAlignment.Near
                .Debut = debut
                .old_UI = CBool(My.Settings.oldUI)
                .Fin = fin
                .Initialiser()
            End With
            Try
                Mainform.Panel_maintenant.Controls.Add(box1)
            Catch ex As Win32Exception
                Trace.WriteLine(
                    DateTime.Now & " " & "Exception lors de l'ajout de la box n° " & i.ToString &
                    "  dans affect richtextbox Maintenant")
                'Dim instance1 As New Win32Exception
                'Dim value1 As Integer
                'value1 = instance1.NativeErrorCode
                'Trace.WriteLine(DateTime.Now & " " & "Error code = " & value1.ToString)
                Trace.WriteLine(DateTime.Now & " " & "Error code = " & ex.NativeErrorCode.ToString)

            End Try
        Next i
    End Sub

    Private Sub MouseToolTip(ByVal sender As Object, ByVal e As EventArgs)

        ' Si la roulette de la souris est en cours d'utilisation on n'affiche pas les ToolTips
        If MouseWheelInUse = True Then
            MouseWheelInUse = False
            Exit Sub
        End If

        Try
            Dim ctrl As Control = DirectCast(sender, Control)
            Dim emissionARechercher As EmissionsList = Nothing
            Select Case ctrl.Parent.Name
                Case Mainform.PanelA.Name
                    emissionARechercher = TableauListEmissions(ctrl.TabIndex)
                    ' on va lire si l'option Slide est activée ou non
                    Select Case My.Settings.Slide
                        Case 1
                            ctrl.Width += 100
                    End Select

                Case Mainform.Panel_ce_soir.Name
                    Mainform.Panel_ce_soir.Select()
                    emissionARechercher = TableauListEmissionsCeSoir(ctrl.TabIndex)

                Case Mainform.Panel_maintenant.Name
                    Mainform.Panel_maintenant.Select()
                    emissionARechercher = TableauListEmissionsMaintenant(ctrl.TabIndex)
            End Select

            For i As Integer = 1 To TableauChaine.Count - 1
                If TableauChaine(i).Identificateur.Equals(emissionARechercher.ChannelId) Then
                    _logoChaine = TableauChaine(i).Logo
                    _toolTipPictureBox.Load(LogosPath & _logoChaine)
                    Exit For
                End If
            Next

            Dim category As String = emissionARechercher.Pcategory
            Dim subcategory As String = emissionARechercher.PcategoryTv
            Dim description As String = emissionARechercher.Pdescription
            Dim dateTvShow As String = DateLangue(emissionARechercher.Pstart.AddMinutes(DecalHoraire))
            Dim clock As String = " | " & emissionARechercher.Pstart.AddMinutes(DecalHoraire).ToString("HH:mm") &
                                  " - " & emissionARechercher.Pstop.AddMinutes(DecalHoraire).ToString("HH:mm")
            Dim duration As String = (emissionARechercher.Pduration).ToString()
            Dim rating As String = emissionARechercher.Prating
            Dim production As String = emissionARechercher.Pdate
            Dim showview As String = emissionARechercher.Showview
            Dim actors As String = emissionARechercher.Pactors
            Dim subtitle As String = emissionARechercher.Psubtitle

            ' Catégorie (on enlève les /)
            If Not (Not category Is Nothing AndAlso String.IsNullOrEmpty(category)) Then

                If category.Contains("/") Then
                    ' On retire le dernier "/" à droite
                    Dim test As String() = category.Split(New Char() {"/"c}, StringSplitOptions.RemoveEmptyEntries)
                    category = test(test.Count - 1)
                End If

                ' Premier caractère en majuscule les suivants en minuscule
                category = category.Chars(0).ToString().ToUpper() & category.Substring(1).ToLower()
            End If

            If Not [String].Equals(description, String.Empty, StringComparison.CurrentCulture) Then
                description = Environment.NewLine & description

                ' Résumé (on enlève la critique)
                If description.Contains("-- ") Then
                    description = description.Substring(0, description.LastIndexOf("--", StringComparison.Ordinal))
                End If

                If description.Contains("- ") Then
                    description = description.Replace("- ", String.Empty)
                End If

                ' Appel de la fonction StripTags
                description = StripTags(description)
            Else
                description = Environment.NewLine & LngBallonTipsNoInformation
            End If

            ' Appel de la fonction SetWidth pour le résumé
            _myFont = New Font("Tahoma", 10)
            description = SetWidth(description, _myFont, 600)

            ' Acteurs
            If Not [String].Equals(actors, String.Empty, StringComparison.CurrentCulture) Then
                If actors.Contains("/") Then
                    'On supprime le 1er / dans la chaine acteur sacteur
                    actors = actors.Remove(0, 1)

                    'On remplace les / suivant par , dans la chaine sacteur
                    actors = actors.Replace("/", ", ")
                End If

                ' Appel de la fonction SetWidth pour Actor
                _myFont = New Font("Tahoma", 10)
                actors = SetWidth(actors, _myFont, 600)
                actors = Environment.NewLine & actors
            End If

            ' Date
            If Not [String].Equals(dateTvShow, String.Empty, StringComparison.CurrentCulture) Then
                dateTvShow = " | " & dateTvShow.ToLower()
            Else
                dateTvShow = String.Empty
            End If

            ' Durée
            If Not [String].Equals(duration, String.Empty, StringComparison.CurrentCulture) Then
                duration = " | " & duration & " " & "min."
            Else
                duration = String.Empty
            End If

            ' Rating
            If Not [String].Equals(rating, String.Empty, StringComparison.CurrentCulture) Then
                rating = " | " & rating
            Else
                rating = String.Empty
            End If

            ' Date de production
            If Not [String].Equals(production, String.Empty, StringComparison.CurrentCulture) Then
                production = " | " & production
            Else
                production = String.Empty
            End If

            ' Showview
            If Not [String].Equals(showview, String.Empty, StringComparison.CurrentCulture) Then
                showview = " | " & showview
            Else
                showview = String.Empty
            End If

            ' subcategory
            If Not [String].Equals(subcategory, String.Empty, StringComparison.CurrentCulture) Then
                subcategory = subcategory & " | "
            Else
                subcategory = String.Empty
            End If

            Application.DoEvents()

            If String.IsNullOrEmpty(_descTooltip.GetToolTip(ctrl)) Then

                Dim all As String = subcategory & category & dateTvShow & clock & duration & rating & production & showview & actors & description ' & review

                With _descTooltip
                    .OwnerDraw = False
                    .BackColor = Color.White
                    .IsBalloon = True
                    .RemoveAll()
                    .AutoPopDelay = 32767
                    .ReshowDelay = 250

                    ' Néo 28/09/2013
                    If String.IsNullOrEmpty(subtitle) Then
                        .ToolTipTitle = ctrl.Text
                    Else
                        .ToolTipTitle = ctrl.Text & " - " & subtitle
                    End If

                    .SetToolTip(ctrl, all)
                End With
            End If

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "MouseTooltip " & ex.ToString)
            Exit Sub
        End Try
    End Sub

    Private Function StripTags(ByVal html As String) As String

        ' Supprime les lignes invisibles
        html = html.Replace("\n", String.Empty)

        ' Supprime les tabulations
        html = html.Replace("\t", String.Empty)

        ' Supprime les multiples espaces vides
        html = Regex.Replace(html, "\\s+", String.Empty)

        ' Supprime les balises HEAD
        html = Regex.Replace(html, "<head.*?</head>", String.Empty _
          , RegexOptions.IgnoreCase Or RegexOptions.Singleline)

        ' Supprime les scripts java
        html = Regex.Replace(html, "<script.*?</script>", String.Empty _
          , RegexOptions.IgnoreCase Or RegexOptions.Singleline)

        ' Remplace les caractères spéciaux
        html = Regex.Replace(html, "&amp;", "&", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&lt;", "<", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&gt;", ">", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&laquo;", "«", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&raquo;", "»", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&iexcl;", "¡", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&iquest;", "¿", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&cent;", "¢", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&pound;", "£", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&curren;", "¤", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&yen;", "¥", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&brvbar;", "¦", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&sect;", "§", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&copy;", "©", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&reg;", "®", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&middot;", "·", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&nbsp;", " ", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&bull;", " * ", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&lsaquo;", "<", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&rsaquo;", ">", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&trade;", "(tm)", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&frasl;", "/", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "<", "<", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, ">", ">", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&mdash;", "—", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "&shy;", "-", RegexOptions.IgnoreCase)

        html = Regex.Replace(html, "&eacute;", "é", RegexOptions.None)
        html = Regex.Replace(html, "&egrave;", "è", RegexOptions.None)
        html = Regex.Replace(html, "&ecirc;", "ê", RegexOptions.None)
        html = Regex.Replace(html, "&ocirc;", "ô", RegexOptions.None)
        html = Regex.Replace(html, "&agrave;", "à", RegexOptions.None)

        html = Regex.Replace(html, "&Eacute;", "É", RegexOptions.None)
        html = Regex.Replace(html, "&Egrave;", "È", RegexOptions.None)
        html = Regex.Replace(html, "&Ecirc;", "Ê", RegexOptions.None)
        html = Regex.Replace(html, "&Ocirc;", "Ô", RegexOptions.None)
        html = Regex.Replace(html, "&Agrave;", "À", RegexOptions.None)

        ' On regarde si il y a des sauts de ligne (<br>) ou des paragraphes (<p>)
        html = html.Replace("<br>", "\n<br>")
        html = html.Replace("<br ", "\n<br ")
        html = html.Replace("<p ", "\n<p ")

        ' Finalement on supprime toutes les balises HTML restantes.
        Return Regex.Replace(html, "<(.|\n)*?>", String.Empty, RegexOptions.IgnoreCase)
    End Function

    Private Function SetWidth(ByVal mytxt As String, ByVal myfont As Font, ByVal mywidth As Integer) As String

        ' Mise en page
        Dim rstr As String = Environment.NewLine & mytxt
        Dim pos As Integer = 1
        Dim pos2 As Integer
        While pos < mytxt.Length
            pos = InStr(pos, rstr, " ") + 1
            If pos = 1 Then
                Exit While
            End If
            pos2 = InStrRev(rstr, Environment.NewLine, pos)

            ' Néo 27/04/2012
            If pos2 <= 0 Then pos2 = 1
            If CreateGraphics.MeasureString(Mid(rstr, pos2, pos - pos2 + 1), myfont).Width > mywidth Then
                rstr = rstr.Insert(InStrRev(rstr, " ", pos - 1), Environment.NewLine)
            End If
        End While
        Return Mid(rstr, 2, rstr.Length - 1)
    End Function

    Private Sub Mouse_Leave(ByVal sender As Object, ByVal e As EventArgs)

        ' on va lire si l'option Slide est activée ou non
        ' Dim ctrl As Control = CType(sender, Control)
        ' If ctrl.Parent.Name = Mainform.PanelA.Name AndAlso My.Settings.Slide = 1 Then
        If My.Settings.Slide = 1 Then
            CType(sender, Control).Width -= 100

        End If
        ' Select Case My.Settings.Slide
        '    Case 1
        '        'CType(sender, Control).Width = CType(sender, Control).Width - 100
        'End Select
    End Sub

    Private Sub RechercherEmissionSurInternet(emission As Control)

        'Dim emissionARechercher As EmissionsList = Nothing
        Select Case emission.Parent.Name
            Case Mainform.PanelA.Name
                _sTitre = TableauListEmissions(emission.TabIndex).Ptitle
            Case Mainform.Panel_ce_soir.Name
                _sTitre = TableauListEmissionsCeSoir(emission.TabIndex).Ptitle
            Case Mainform.Panel_maintenant.Name
                _sTitre = TableauListEmissionsMaintenant(emission.TabIndex).Ptitle
        End Select

        If Not (IsOffline) Then
            If My.Settings.EngineShow = True Then
                EngineSelection.ShowDialog()
            End If

            ' Si double click sur un Film/série on recherche dans TheTVDB.com, IMDB
            ' et on affiche dans le navigateur internet la/les fiches dispos
            Try
                If My.Settings.EngineSelection = 1 Then
                    If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.thetvdb.com") _
                        Then
                        Trace.WriteLine(
                            DateTime.Now & " " &
                            "Un double click gauche ")
                        ThetvdbName = _sTitre
                        SeriesBrowser.ShowDialog()
                        Trace.WriteLine(
                            DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " &
                            _sTitre & " dans TheTVDB.Com")
                    Else

                        ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                        ' la fiche TheTVDB.Com
                        ' ReSharper disable NotAccessedVariable
                        Dim boxNoConnection As DialogResult
                        ' ReSharper restore NotAccessedVariable
                        boxNoConnection =
                            MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                            MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation)
                    End If
                End If

                If My.Settings.EngineSelection = 2 Then
                    If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.imdb.com") Then
                        Trace.WriteLine(
                            DateTime.Now & " " &
                            "Un double click gauche a été effectué dans maintenant pour IMDb.com")

                        If [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                            Process.Start("http://www.imdb.fr/find?q=" & _sTitre)
                        Else
                            Process.Start("http://www.imdb.com/find?q=" & _sTitre)
                        End If

                        Trace.WriteLine(
                            DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " &
                            _sTitre & " dans IMDB.Com")

                    Else
                        ' •———————————————————————————————————————————————————————————————————————————————•
                        ' | Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher   |
                        ' | la fiche IMDb.Com                                                             |
                        ' •———————————————————————————————————————————————————————————————————————————————•
                        ' ReSharper disable NotAccessedVariable
                        Dim boxNoConnection As DialogResult
                        ' ReSharper restore NotAccessedVariable
                        boxNoConnection =
                            MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                            MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation)
                    End If
                End If

                If My.Settings.EngineSelection = 3 AndAlso [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                    If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.allocine.fr") _
                        Then
                        Trace.WriteLine(
                            DateTime.Now & " " &
                            "Un double click gauche a été effectué dans maintenant pour Allocine.fr")
                        Process.Start("http://www.allocine.fr/recherche/?q=" & _sTitre)
                        Trace.WriteLine(
                            DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " &
                            _sTitre & " dans Allocine.fr")
                    Else

                        ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                        ' la fiche allocine.fr
                        ' ReSharper disable NotAccessedVariable
                        ' ReSharper disable InconsistentNaming
                        Dim BoxNoConnection As DialogResult
                        ' ReSharper restore InconsistentNaming
                        ' ReSharper restore NotAccessedVariable
                        BoxNoConnection =
                            MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                            MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation)
                    End If
                End If

                If My.Settings.EngineSelection = 3 AndAlso Not [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                    If _
                        My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.screenrush.co.uk/") Then
                        Trace.WriteLine(
                            DateTime.Now & " " &
                            "Un double click gauche a été effectué dans maintenant pour Screenrush.co.uk")
                        Process.Start("http://www.screenrush.co.uk/recherche/?motcle=" & _sTitre)
                        Trace.WriteLine(
                            DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " &
                            _sTitre & " dans Screenrush.co.uk")
                    Else

                        ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                        ' la fiche Screenrush.co.uk
                        ' ReSharper disable NotAccessedVariable
                        Dim boxNoConnection As DialogResult
                        ' ReSharper restore NotAccessedVariable
                        boxNoConnection =
                            MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                            MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation)
                    End If
                End If

            Catch ex As Exception

                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Sub FonctionClickEmission(ByVal sender As Object, ByVal e As MouseEventArgs)
        Trace.WriteLine(DateTime.Now & " " & "Fonction click emission_ce_soir_ou_maintenant")

        ''Dim i As Integer
        ''Dim z As String
        '_repereClickEmission = CInt(CType(sender, Control).TabIndex)
        'Trace.WriteLine(DateTime.Now & " " & "Tag de l'émission = " & _repereClickEmission.ToString)

        '_sTitre = DirectCast(sender, Control).Text

        '' Bouton gauche de la souris ? Néo le 11/09/09
        Select Case e.Button
            Case MouseButtons.Left

                If e.Clicks > 1 Then
                    RechercherEmissionSurInternet(DirectCast(sender, Control))
                End If
                '' il faut rechercher le nom de la chaine à partir de ChannelID
                'For i = 1 To NbTotalChaines
                '    z = TableauChaine(i).Identificateur
                '    If [String].Equals(z, SChid, StringComparison.CurrentCulture) Then
                '        Exit For
                '    End If
                'Next i

                ' Bouton gauche de la souris ? si oui y a t'il eu plus de 1 clic Néo le 11/09/09
                'rvs75 : 27/10/2010 : ne lance la recherche d'information sur le programme que si on est en mode connecté
                'If Not (IsOffline) AndAlso e.Clicks > 1 Then
                '    If My.Settings.EngineShow = True Then
                '        EngineSelection.ShowDialog()
                '    End If

                '    ' Si double click sur un Film/série on recherche dans TheTVDB.com, IMDB
                '    ' et on affiche dans le navigateur internet la/les fiches dispos
                '    Try
                '        If My.Settings.EngineSelection = 1 Then
                '            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.thetvdb.com") _
                '                Then
                '                Trace.WriteLine(
                '                    DateTime.Now & " " &
                '                    "Un double click gauche a été effectué dans maintenant")
                '                ThetvdbName = _sTitre
                '                SeriesBrowser.ShowDialog()
                '                Trace.WriteLine(
                '                    DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " &
                '                    _sTitre & " dans TheTVDB.Com")
                '            Else

                '                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                '                ' la fiche TheTVDB.Com
                '                ' ReSharper disable NotAccessedVariable
                '                Dim boxNoConnection As DialogResult
                '                ' ReSharper restore NotAccessedVariable
                '                boxNoConnection =
                '                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                '                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                '                                    MessageBoxIcon.Exclamation)
                '            End If
                '        End If

                '        If My.Settings.EngineSelection = 2 Then
                '            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.imdb.com") Then
                '                Trace.WriteLine(
                '                    DateTime.Now & " " &
                '                    "Un double click gauche a été effectué dans maintenant pour IMDb.com")

                '                If [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                '                    Process.Start("http://www.imdb.fr/find?q=" & _sTitre)
                '                Else
                '                    Process.Start("http://www.imdb.com/find?q=" & _sTitre)
                '                End If

                '                Trace.WriteLine(
                '                    DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " &
                '                    _sTitre & " dans IMDB.Com")

                '            Else
                '                ' •———————————————————————————————————————————————————————————————————————————————•
                '                ' | Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher   |
                '                ' | la fiche IMDb.Com                                                             |
                '                ' •———————————————————————————————————————————————————————————————————————————————•
                '                ' ReSharper disable NotAccessedVariable
                '                Dim boxNoConnection As DialogResult
                '                ' ReSharper restore NotAccessedVariable
                '                boxNoConnection =
                '                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                '                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                '                                    MessageBoxIcon.Exclamation)
                '            End If
                '        End If

                '        If My.Settings.EngineSelection = 3 AndAlso [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                '            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.allocine.fr") _
                '                Then
                '                Trace.WriteLine(
                '                    DateTime.Now & " " &
                '                    "Un double click gauche a été effectué dans maintenant pour Allocine.fr")
                '                Process.Start("http://www.allocine.fr/recherche/?q=" & _sTitre)
                '                Trace.WriteLine(
                '                    DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " &
                '                    _sTitre & " dans Allocine.fr")
                '            Else

                '                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                '                ' la fiche allocine.fr
                '                ' ReSharper disable NotAccessedVariable
                '                ' ReSharper disable InconsistentNaming
                '                Dim BoxNoConnection As DialogResult
                '                ' ReSharper restore InconsistentNaming
                '                ' ReSharper restore NotAccessedVariable
                '                BoxNoConnection =
                '                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                '                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                '                                    MessageBoxIcon.Exclamation)
                '            End If
                '        End If

                '        If My.Settings.EngineSelection = 3 AndAlso Not [String].Equals(My.Settings.Language, "Français", StringComparison.CurrentCulture) Then
                '            If _
                '                My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.screenrush.co.uk/") Then
                '                Trace.WriteLine(
                '                    DateTime.Now & " " &
                '                    "Un double click gauche a été effectué dans maintenant pour Screenrush.co.uk")
                '                Process.Start("http://www.screenrush.co.uk/recherche/?motcle=" & _sTitre)
                '                Trace.WriteLine(
                '                    DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " &
                '                    _sTitre & " dans Screenrush.co.uk")
                '            Else

                '                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                '                ' la fiche Screenrush.co.uk
                '                ' ReSharper disable NotAccessedVariable
                '                Dim boxNoConnection As DialogResult
                '                ' ReSharper restore NotAccessedVariable
                '                boxNoConnection =
                '                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                '                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                '                                    MessageBoxIcon.Exclamation)
                '            End If
                '        End If

                '    Catch ex As Exception

                '        ' ReSharper disable NotAccessedVariable
                '        Dim boxNoConnection As DialogResult
                '        ' ReSharper restore NotAccessedVariable
                '        boxNoConnection =
                '            MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                '                            MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                '                            MessageBoxIcon.Exclamation)
                '    End Try
                'End If
        End Select
    End Sub

    Public Sub CurseurVertical()

        'rvs75 18/08/2010 : réécriture du curseur
        Dim ii As Integer
        Dim tps2 As TimeSpan = DateTime.Now.Subtract(DateReference)
        Dim doubleP As Double = (1440 * tps2.Days + 60 * tps2.Hours + tps2.Minutes) - (DecalHoraire * 60)

        ' converti en minutes
        If doubleP < 0 Then
            doubleP = 0
        End If

        ii = CInt(Math.Truncate(doubleP * NbPixelsPour30Minutes / 30))

        'essai de récuperer le curseur s'il existe
        'si on peut, alors on le deplace
        'sinon on créé le curseur dans le catch
        'Try
        If Mainform.Controls.Find("curseur", True).Length > 0 Then
            Dim leCurseur As Curseur = DirectCast(Mainform.Controls.Find("curseur", True)(0), Curseur)
            leCurseur.Left = ii
            'Catch
        Else
            Dim box1 As New Curseur
            With box1
                .Name = "curseur"
                .Left = ii
                .Top = 0
                .Height = Mainform.PanelA.Height
                '.Width = 1
            End With
            Try
                Mainform.PanelA.Controls.Add(box1)
            Catch ex As Win32Exception
                Dim instance As New Win32Exception
                Dim value As Integer
                value = instance.NativeErrorCode
                Trace.WriteLine(DateTime.Now & " " & "Dans curseur ,error code = " & value.ToString)
            End Try
        End If
        'End Try
        Mainform.Controls.Find("curseur", True)(0).BringToFront()
    End Sub

    Private Sub CalculDesBoldedDates()

        'rvs75 16/10/2012 : suppression d'une requete inutile
        ' Calcul des dates en Gras dans le calendrier
        Trace.WriteLine(DateTime.Now & " " & "bolded dates")
        Const qwOnChannels2 As String = "SELECT min(Pstart), max(Pstop)  FROM Programtbl"
        Dim db As SqLiteBase = New SqLiteBase
        Dim dtOnChannels As DataTable
        With db
            .OpenDatabase(BddPath & "db_progs.db3")
            dtOnChannels = .ExecuteQuery(qwOnChannels2)
            .CloseDatabase()
        End With

        Try
            Try
                FirstDateWithData = CDate(dtOnChannels.Rows(0).Item(0))
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & "fichier xml detecté corrompu dans bolded dates")

                ' si maj automatique annonce qu elle a echoue et quelle aura lieu plus tard
                ' remttre l ancienne bdd et mettre flag comme quoi la derniere mise ajour a eu lieu ????
                Miseajour.CopierFichier(BddPath & "db_progs.bak", BddPath & "db_progs.db3", True)

                ' si probleme eviter de revenir sur un mauvais lien
                With Mainform
                    .Tl.Close()
                    .Timer_wait.Start()
                    .Timer_wait.Enabled = True
                    .AppliRestart = True
                End With
            End Try

        Catch ex As NullReferenceException
            Trace.WriteLine(DateTime.Now & " Null reference exception error " & ex.Message)
        End Try

        ' pour les dates comprises entre first_date_with_data et last_date_with_data
        ' c est a dire les dates pour lesuelles il y a des emissions presentes,
        ' mettre en gras ces dates en question dans le monthcalendar
        Trace.WriteLine(DateTime.Now & " " & "Premières données commençant le : " & FirstDateWithData.ToString)
        Trace.WriteLine(DateTime.Now & " " & qwOnChannels2)

        Try
            Try
                LastDateWithData = CDate(dtOnChannels.Rows(0).Item(1))
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & "fichier xml corrompu detcté dans bollded dates")
            End Try

        Catch ex As NullReferenceException
            Trace.WriteLine(DateTime.Now & " Null reference exception error " & ex.Message)
            Trace.WriteLine(DateTime.Now & " " & "Non respect des types de données dans db_progs.db3")
        End Try

        Trace.WriteLine(DateTime.Now & " " & "Dernières données de la BDD le : " & LastDateWithData.ToString)
        For I As Integer = 0 To 20

            ' 20 > nbre de jours de data dans la database
            Dim date1 As DateTime
            date1 = FirstDateWithData.AddDays(I)
            If LastDateWithData < date1 Then
                Exit For
            End If
            JourActif.Ajoute(date1)
        Next I
        JourActif.Ajoute(LastDateWithData)

        'IndiceCourantTle = 1
    End Sub

    Private Sub ShowJournee(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim reperelogo As Integer = CInt(CType(sender, Control).TabIndex)
        IdentifiantLogo = TableauChaine(reperelogo).Identificateur
        ChannelView.ShowDialog()
    End Sub
End Class