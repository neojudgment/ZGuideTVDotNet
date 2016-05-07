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


#Region "Imports"

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text.RegularExpressions
Imports ZGuideTV.SQLiteWrapper
Imports ZGuideTV.ZGuideTVDotNetTvdb

#End Region

' ReSharper disable CheckNamespace
' ReSharper disable UnusedMember.Global
Public Class CentralScreen
    ' ReSharper restore UnusedMember.Global
    ' ReSharper restore CheckNamespace

#Region "Property"

    'Private ReadOnly _descTooltip As New ToolTip

    'Dim WithEvents _popup As New FrmPopup
    Public WithEvents PopupContent As New ucPopup
    Private WithEvents _pu As New Popup(PopupContent)
    'Private _myFont As Font
    'Private ReadOnly _toolTipPictureBox As PictureBox = New PictureBox()
    Private _repereClickEmission As Integer
    Public MessageBoxNoConnection As String
    Public MessageBoxNoConnection1 As String
    Public MessageBoxNoConnectionTitre As String
    Public MouseWheelInUse As Boolean

#End Region

    Private Sub CentralScreen(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Néo le 27/08/2009
        LanguageCheck()
    End Sub

    Dim _dicChaine As Dictionary(Of String, String)

    Public Sub PixelsNonUtilisésPourLesEmissions()

        ' cette sr ne peut etre appelée qu après définition de
        ' l1, l2, l3, panelB.width et panelC.width
        ' cad après create_panelbox et premieres_initialisations
        Dim i As Integer

        InutiliseAGauche(0) = LargeurBoutonsVerticaux * 2 + Mainform.PanelB.Width
        InutiliseAGauche(1) = InutiliseAGauche(0)
        InutiliseAGauche(2) = L2 + LargeurBoutonsVerticaux * 2
        InutiliseAGauche(3) = InutiliseAGauche(2)
        InutiliseAGauche(4) = LargeurBoutonsVerticaux * 2 + Mainform.PanelB.Width
        InutiliseAGauche(5) = InutiliseAGauche(4)
        InutiliseAGauche(6) = L2 + LargeurBoutonsVerticaux * 2
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
        DateOrigineEcran = DebutHeure(DateOrigineEcran.AddMinutes(1))
        Trace.WriteLine(DateTime.Now & " " & "Date origine écran = " & DateOrigineEcran.ToString)
    End Sub

    Public Sub InitialisationsDiverses()

        Trace.WriteLine(DateTime.Now & " " & " Entrée Central_screen.vb --> Initialisations_Diverses()")
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

        GroupFonction1()

        GroupFonction2()
        Select Case NbEmissionsForSqlRequest
            Case 0
                ' Néo 17/04/2015 Réécriture complète du select Case
                Trace.WriteLine(DateTime.Now & " " & "InitialisationsDiverses()")
                Trace.WriteLine(DateTime.Now & " " & "Suppression de db_progs.db3 qui contient des adonnées périmées")

                ' Il faut fermer la BDD si elle est perimee(avant de supprimer db_progs.db3 BB101209
                ' IL faut supprimer le fichier db_progs.db3 dans application data
                ' pour pouvoir sortir de ce cycle sans fin
                File.Delete(BddPath & "db_progs.db3")

                Mainform.Tl.Close()

                Trace.WriteLine(
                    DateTime.Now & " " &
                    "Redémarrage de l'application car les données d'émissions sont trop anciennes")

                Close()
                Application.Restart()
        End Select

        ' On récupère les émissions marquées
        If File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
            MajFichierMarquage()
        End If

        Mainform.Timer_heure.Start()
        'BB110810 pour surveiller le rappel d emissions marquees

        Mainform.Refresh()
        'FinInitialize = True
        Trace.WriteLine(DateTime.Now & " " & "Sortie Central_screen.vb --> Initialisations_Diverses()")
    End Sub

    Private Sub ClearAetBPanelboxes()

        Trace.WriteLine(DateTime.Now & " " & "sub clear A et B panel box")

        Try

            For Each item As Control In Mainform.PanelA.Controls
                Mainform.PanelA.Controls.Remove(item)
                Trace.WriteLine(DateTime.Now & " " & "Mainform.PanelA.Controls.Remove(item): " & item.ToString)
            Next item

            For Each item As Control In Mainform.PanelB.Controls
                Mainform.PanelB.Controls.Remove(item)
                Trace.WriteLine(DateTime.Now & " " & "Mainform.PanelB.Controls.Remove(item): " & item.ToString)
            Next item

            'With Mainform
            '.PanelA.Controls.Clear()
            '.PanelB.Controls.Clear()

            '.Invoke(Sub() Mainform.PanelA.Invalidate())
            '.Invoke(Sub() Mainform.PanelB.Invalidate())

            '.PanelA.Invalidate()
            '.PanelB.Invalidate()

            'Trace.WriteLine(DateTime.Now & " " & ".Invoke(Sub() Mainform.PanelA et B.Remove()) ")
            'End With

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "Erreur dans ClearAetBPanelboxes (.PanelA ou B.Controls.Remove): " & ex.ToString)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub CalculDesProprietesTopDesLignesRichtextbox()

        ' en fait on calcule la prop top de toutes les emissions dans l espace
        ' de temps de 6 heures et bien au dela du nbre de chaines affichees a l ecran
        ' PREALABLE :  nb_chaines_ecran,hauteur_richtextbox
        Dim i As Integer = 1
        OrdTopLigne(i) = 0

        For i = 2 To NombreDeChainesDifferentes
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
                If _
                    [String].Equals(TableauListEmissions(i + 1).ChannelId, TableauListEmissions(i).ChannelId,
                                    StringComparison.CurrentCulture) Then
                    count += 1
                Else
                    NbEmissionsParChaine(j) = count
                    j += 1
                    count = 1
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show(New Form() With {.TopMost = True}, ex.Message)
        End Try
        If count <> 1 Then
            NbEmissionsParChaine(j) = count - 1
        End If
    End Sub

    Private Sub CalculProprietesTopDesLogo()

        ' le nbre de logos=le nbre de chaines différentes avec présence
        ' d 'émissions
        Dim i As Integer
        Dim t As Integer = 1

        ' ces valeurs top sont les mêmes que celles des richtextbox
        ' attention il y a des valeurs identiques pour tous les
        ' richtextbox d'une même chaine
        For i = 1 To NbChainesEcran + 1

            If OrdTopLigne(i) <> OrdTopLigne(i - 1) Then
                ValTopLogo(t) = OrdTopLigne(i - 1)
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

        Trace.WriteLine(DateTime.Now & " entree dans fill chaine logo unique")

        _dicChaine =
            TableauChaine.Where(Function(p) p.Identificateur <> Nothing).Select(
                Function(p) New With {Key p.Identificateur, p.Logo}).Distinct.ToDictionary(Function(p) p.Identificateur,
                                                                                           Function(p) p.Logo)
        Dim listChaine As List(Of String) = From c In TableauListEmissions Select c.ChannelId Distinct.ToList
        NombreDeChainesDifferentes = listChaine.Count - 1
        For s As Integer = 1 To listChaine.Count - 1
            ChaineLogoUnique(s) = _dicChaine(listChaine(s))
        Next


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

        Trace.WriteLine(
            DateTime.Now & " " &
            "Modification de height pour panelA et panelD en fonction nb chaines differentes")
        CalculDesProprietesTopDesLignesRichtextbox()

        FillTableauxTopWidthLeft()
        'FillColorOfRichtextbox()
        ClearAetBPanelboxes()
        AffectRichtextboxParameters()
    End Sub

    Public Sub GroupFonction1()

        GetListOfEmissionsForSqlWhereAndBetween()

        Select Case NbEmissionsForSqlRequest
            Case 0
                ' Néo 17/04/2015 Réécriture complète du select Case
                Trace.WriteLine(DateTime.Now & " " & "GroupFonction1()")
                Trace.WriteLine(DateTime.Now & " " & "Suppression de db_progs.db3 qui contient des adonnées périmées")

                ' Il faut fermer la BDD si elle est perimee(avant de supprimer db_progs.db3 BB101209
                ' IL faut supprimer le fichier db_progs.db3 dans application data
                ' pour pouvoir sortir de ce cycle sans fin
                File.Delete(BddPath & "db_progs.db3")

                Mainform.Tl.Close()

                Trace.WriteLine(
                    DateTime.Now & " " &
                    "Redémarrage de l'application car les données d'émissions sont trop anciennes")

                Close()
                Application.Restart()
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
        Mainform.PanelB.SuspendLayout()

        Mainform.PanelB.Controls.Clear()

        'Dim logobox As New PictureBox()
        'With logobox
        '    .SizeMode = PictureBoxSizeMode.Zoom
        '    .Left = 0
        '    .Top = 0
        '    .Height = 0
        '    .Width = 0
        '    .Image = Nothing
        'End With

        '' panelB contient les picturebox pour les logos et se situe a gauche
        '' de panelA

        'Try
        '    Mainform.PanelB.Controls.Add(logobox)
        'Catch ex As Win32Exception
        '    Dim instance As New Win32Exception
        '    Dim value As Integer
        '    value = instance.NativeErrorCode
        '    Trace.WriteLine(DateTime.Now & " " & "Dans affect logo picture box debut :error code = " & value.ToString)
        'End Try

        'CompteurControlesLogo = Mainform.PanelB.Controls.Count

        ' attention il peut y avoir des chaines qui n emettent pas donc
        ' la chaine_logo_unique n est remplie que jusque
        ' nombre_de_chaines_differentes

        indiceReduit = NombreDeChainesDifferentes

        If (offset + 1) > 0 AndAlso indiceReduit > 0 Then
            For i = offset + 1 To offset + NbChainesEcran

                Dim logobox1 As New PictureBox
                With logobox1
                    AddHandler .MouseDoubleClick, AddressOf ShowJournee
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = ValTopLogo(i - offset)
                    .Height = HauteurRichtextbox
                    .Width = LargeurLogoAdaptee
                    Try
                        Dim test As New FileInfo(LogosPath & ChaineLogoUnique(i))
                        test.Refresh()

                        Dim img As Image = Image.FromFile(test.FullName)
                        Dim scale As Double = Math.Min(logobox1.ClientRectangle.Width / img.Width, logobox1.ClientRectangle.Height / img.Height)
                        Dim imgFinal As Bitmap = New Bitmap(CInt(img.Width * scale), CInt(img.Height * scale), PixelFormat.Format32bppArgb)
                        Using g As Graphics = Graphics.FromImage(imgFinal)
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic
                            g.DrawImage(img, 0, 0, imgFinal.Width, imgFinal.Height)
                        End Using
                        .Image = imgFinal

                        '.Image = Image.FromFile(test.FullName)
                    Catch ex As Exception
                        Trace.WriteLine("il manque le logo " & LogosPath & ChaineLogoUnique(i))
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

        Trace.WriteLine(DateTime.Now & " " & "Nb controles logobox = " & Mainform.PanelB.Controls.Count.ToString())

        With Mainform
            .PanelB.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picture box")
    End Sub

    Public Sub AffectLogoPictureboxCeSoir(ByVal offset As Integer)

        ' cet offset est de signification inchangée
        Trace.WriteLine(DateTime.Now & " " & "Affect Logo Picturebox_ce_soir (offset)")
        Dim i As Integer
        Mainform.Panel_ce_soir.SuspendLayout()

        ' attention il peut y avoir des chaines qui n emettent pas donc
        ' la chaine_logo_unique n est remplie que jusque
        ' nombre_de_chaines_differentes

        Trace.WriteLine(DateTime.Now & " " & "nb_emissions pour logo ce soir: " & NbEmissionsForCeSoir)
        ' If (offset + 1) > 0 And indice_reduit > 0 Then
        Trace.WriteLine(" ")
        For i = offset To offset + NbEmissionsForCeSoir - 1
            Dim sb4 As String

            ' tableau_liste_emissions_ce_Soir  a un champ( channelid) du type
            ' C40.telepoche.com)
            ' on recherche dans tableau_chaine(i) l indice j pour
            ' lequel tableau_chaine(j).id = C40.telepoche
            ' A ce moment tableau_chaine(j).logo est le nom du fichier image

            Trace.WriteLine(
                DateTime.Now & " i= " & i.ToString & " tableau_list_emissions_ce_soir(i).channelID = " &
                TableauListEmissionsCeSoir(i).ChannelId)

            Trace.WriteLine(" ")

            Try
                sb4 = Path.Combine(LogosPath & _dicChaine(TableauListEmissionsCeSoir(i).ChannelId))
                Dim test As New FileInfo(sb4)
                test.Refresh()

                Dim logobox1 As New PictureBox
                With logobox1
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = ValTopCeSoir(i - offset)
                    .Height = HauteurRichtextbox
                    .Width = LargeurLogoAdaptee
                    Dim img As Image = Image.FromFile(test.FullName)
                    Dim scale As Double = Math.Min(logobox1.ClientRectangle.Width / img.Width, logobox1.ClientRectangle.Height / img.Height)
                    Dim imgFinal As Bitmap = New Bitmap(CInt(img.Width * scale), CInt(img.Height * scale), PixelFormat.Format32bppArgb)
                    Using g As Graphics = Graphics.FromImage(imgFinal)
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic
                        g.DrawImage(img, 0, 0, imgFinal.Width, imgFinal.Height)
                    End Using
                    .Image = imgFinal

                    '.Image = Image.FromFile(test.FullName)
                End With

                Mainform.Panel_ce_soir.Controls.Add(logobox1)
            Catch ex As Win32Exception

                Trace.WriteLine(
                    DateTime.Now & " " & "Dans affect logo picture box ce_soir fin ,error code = " &
                    ex.NativeErrorCode.ToString)
                Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & ex.Message)

            End Try
        Next i

        With Mainform
            .Panel_ce_soir.ResumeLayout()
            .Panel_ce_soir.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picturebox ce soir")
    End Sub

    Public Sub AffectLogoPictureboxMaintenant(ByVal offset As Integer)

        ' cet offset est de signification inchangee
        Trace.WriteLine(DateTime.Now & " " & "Affect Logo Picturebox_maintenant (offset)")
        Dim i As Integer
        Mainform.Panel_maintenant.SuspendLayout()

        For i = offset To offset + NbEmissionsForMaintenant - 1
            Dim sb4 As String

            Try
                sb4 = Path.Combine(LogosPath & _dicChaine(TableauListEmissionsMaintenant(i).ChannelId))
                Dim test As New FileInfo(sb4)
                test.Refresh()
                Dim logobox1 As New PictureBox
                With logobox1
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = ValTopMaintenant(i - offset)
                    .Height = HauteurRichtextbox
                    .Width = LargeurLogoAdaptee
                    Dim img As Image = Image.FromFile(test.FullName)
                    Dim scale As Double = Math.Min(logobox1.ClientRectangle.Width / img.Width, logobox1.ClientRectangle.Height / img.Height)
                    Dim imgFinal As Bitmap = New Bitmap(CInt(img.Width * scale), CInt(img.Height * scale), PixelFormat.Format32bppArgb)
                    Using g As Graphics = Graphics.FromImage(imgFinal)
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic
                        g.DrawImage(img, 0, 0, imgFinal.Width, imgFinal.Height)
                    End Using
                    .Image = imgFinal

                    '.Image = Image.FromFile(test.FullName)
                End With
                Mainform.Panel_maintenant.Controls.Add(logobox1)
            Catch ex As Win32Exception

                Trace.WriteLine(
                    DateTime.Now & " " & "Dans affect logo picture box ce_soir fin ,error code = " &
                    ex.NativeErrorCode.ToString)
                Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & ex.Message)

            End Try

        Next i

        With Mainform
            .Panel_maintenant.ResumeLayout()
            .Panel_maintenant.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picture box maintenant")
    End Sub

    Private Sub CreerEmssionForAffectRichtextboxParameters(ByVal i As Integer)

        Dim box1 As New PaveCentral
        With box1
            AddHandler .MouseLeave, AddressOf Pave_MouseLeave
            AddHandler .MouseEnter, AddressOf Pave_MouseEnter
            AddHandler .MouseDown, AddressOf Mdown

            '.OldUi = CBool(My.Settings.oldUI)
            .Name = "Botton_Em"
            .Left = ValLeft(i)
            .Top = ValTop(i)
            .Height = HauteurRichtextbox
            .Width = ValWidth(i)
            .Text = TableauListEmissions(i).Ptitle
            Try
                .BgColor = Color.FromArgb(ListeCategorie(TableauListEmissions(i).PcategoryTv))
            Catch ex As Exception
            End Try
            .Align = StringAlignment.Near
            '.Tag = TableauListEmissions(i).PcategoryTv
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

        Trace.WriteLine(DateTime.Now & " entree dans affectrichtextboxparameters")

        'Modifié par Néo le 24/08/2010
        Dim i As Integer
        Dim memochaine As String = ""
        Dim tableauEmission(NbChainesEcran) As AffichagePanelA
        Dim ctpChaine As Integer = -1

        Try
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
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " Erreur dans affectrichtextboxparameters (NbRecordLimiteForSqlRequest): " & ex.ToString)
        End Try

        Try
            'creation des boutons des emissions visibles 
            For t As Integer = 0 To NbChainesEcran - 1
                With tableauEmission(t)
                    For p As Integer = .DebutEmission To .DebutEmission + .EmissionVisible
                        CreerEmssionForAffectRichtextboxParameters(p - 1)
                    Next
                End With
            Next

        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " Erreur dans affectrichtextboxparameters (NbChainesEcran): " & ex.ToString)
        End Try

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

        Trace.WriteLine(DateTime.Now & " " & "sortie de affectrichtextboxparameters")
    End Sub

    Public Sub AffectRichtextboxCeSoir()

        Dim i As Integer
        Mainform.Panel_ce_soir.SuspendLayout()
        Mainform.Panel_ce_soir.Controls.Clear()

        For i = 0 To NbEmissionsForCeSoir - 1

            ' 17/09/2009 rvs75 si oldUI=1 dans le .config c'est un bouton sinon c'est un GradientButton
            Dim chaine As String = String.Empty

            Try
                chaine = TableauListEmissionsCeSoir(i).Ptitle
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & "Erreur dans affectrichtextboxcesoir (chaine: " & ex.ToString)
            End Try

            Dim box1 As New PaveCentral
            With box1
                AddHandler .MouseDown, AddressOf FonctionClickEmission
                AddHandler .MouseLeave, AddressOf Pave_MouseLeave
                AddHandler .MouseEnter, AddressOf Pave_MouseEnter

                .Left = LargeurLogoAdaptee
                .Top = ValTopCeSoir(i)
                .Height = HauteurRichtextbox
                .Width = ValWidthCesoirMaintenant
                If chaine.Length > 38 Then .Text = chaine.Substring(0, 35) & "..." Else .Text = chaine
                Try
                    .BgColor = Color.FromArgb(ListeCategorie(TableauListEmissionsCeSoir(i).PcategoryTv))

                Catch ex As Exception
                    Trace.WriteLine(DateTime.Now & " " & "Erreur dans affectrichtextboxcesoir (.BgColor: " & ex.ToString)
                End Try
                .ForeColor = Color.Black
                .Align = StringAlignment.Near

            End With
            Try
                Mainform.Panel_ce_soir.Controls.Add(box1)
            Catch ex As Win32Exception
                Trace.WriteLine(
                    DateTime.Now & " " & "Exception lors de l'ajout de la  box n° " & i.ToString &
                    "  dans affect richtextbox ce_soir")

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

        For i = 0 To NbEmissionsForMaintenant - 1
            Dim chaine As String
            chaine = TableauListEmissionsMaintenant(i).Ptitle
            'rvs75 10/08/2010 : debut de modif
            Dim debut As DateTime = TableauListEmissionsMaintenant(i).Pstart
            Dim fin As DateTime = TableauListEmissionsMaintenant(i).Pstop

            Dim box1 As New PaveActuellement
            With box1
                AddHandler .MouseDown, AddressOf FonctionClickEmission
                AddHandler .MouseLeave, AddressOf Pave_MouseLeave
                AddHandler .MouseEnter, AddressOf Pave_MouseEnter

                .Left = LargeurLogoAdaptee
                .Top = ValTopMaintenant(i)
                .Height = HauteurRichtextbox
                .Width = ValWidthCesoirMaintenant
                If chaine.Length > 38 Then .Text = chaine.Substring(0, 35) & "..." Else .Text = chaine
                .BgColor = Color.FromArgb(ListeCategorie(TableauListEmissionsMaintenant(i).PcategoryTv))
                .Align = StringAlignment.Near
                .Debut = debut
                '.old_UI = CBool(My.Settings.oldUI)
                .Fin = fin
                .Initialiser()
            End With
            Try
                Mainform.Panel_maintenant.Controls.Add(box1)
            Catch ex As Win32Exception
                Trace.WriteLine(
                    DateTime.Now & " " & "Exception lors de l'ajout de la box n° " & i.ToString &
                    "  dans affect richtextbox Maintenant")
                Trace.WriteLine(DateTime.Now & " " & "Error code = " & ex.NativeErrorCode.ToString)

            End Try
        Next i
    End Sub

    ' ReSharper disable UnusedMember.Local
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
        Dim reperelogo As Integer = CInt(CType(sender, Control).TabIndex + 1)
        IdentifiantLogo = TableauChaine(reperelogo).Identificateur
        Using ra As New TVGuideMainForm(ObjRecherche.ParChaine, IdentifiantLogo)
            ra.ShowDialog()
        End Using
    End Sub

#Region "Souris et popup"

    Private Sub AffichePopup(sender As Object)
        Static memoBascule As Boolean = False
        Static memoObject As Object = New Object
        If MouseWheelInUse = True Then
            MouseWheelInUse = False
            Exit Sub
        End If
        If Not memoBascule OrElse Not memoObject.Equals(sender) Then

            Try
                Dim ctrl As Control = DirectCast(sender, Control)
                Dim emissionARechercher As EmissionsList = Nothing
                Select Case ctrl.Parent.Name
                    Case Mainform.PanelA.Name
                        emissionARechercher = TableauListEmissions(ctrl.TabIndex)

                    Case Mainform.Panel_ce_soir.Name
                        Mainform.Panel_ce_soir.Select()
                        emissionARechercher = TableauListEmissionsCeSoir(ctrl.TabIndex)

                    Case Mainform.Panel_maintenant.Name
                        Mainform.Panel_maintenant.Select()
                        emissionARechercher = TableauListEmissionsMaintenant(ctrl.TabIndex)
                End Select

                'With _popup
                '    .emission = emissionARechercher
                '    .Diffusion()
                '    .CalculHauteur()
                'End With

                With PopupContent
                    .Emission = emissionARechercher
                End With
                With _pu
                    'Height = _popup.Height
                    .Height = PopupContent.Hauteur
                    .Show(CType(sender, Control))
                End With
                CType(sender, Control).Focus()
                memoBascule = True
                memoObject = sender
                Application.DoEvents()
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & "MouseTooltip " & ex.ToString)
                Exit Sub
            End Try
        Else
            _pu.Close()
            memoBascule = False
            memoObject = New Object
        End If


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
                If e.Clicks = 1 Then
                    AffichePopup(sender)
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
                    Dim heureDebutDemarquee As String
                    Dim heureFinDemarquee As String
                    Dim chaineDemarquee As String

                    ' on veut demarquer une emission deja marquee
                    ' C est a dire enlever 4 espaces  avant et après le titre de l emisson
                    heureDebutDemarquee =
                        TableauListEmissions(_repereClickEmission).Pstart.ToString("yyyy/MM/dd HH:mm:ss")
                    chaineDemarquee = TableauListEmissions(_repereClickEmission).ChannelId.ToString

                    heureFinDemarquee =
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
                    Dim monStreamDocument As New StreamReader(nomDuFichier)

                    Do While (monStreamDocument.Peek <> -1)
                        ' Tant qu il y a des records ds le fichier
                        strligne = monStreamDocument.ReadLine
                        If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                            Dim hStart, nomChaine, hStop, ttitre As String
                            hStart = ""
                            nomChaine = ""
                            hStop = ""
                            ttitre = ""

                            DecomposerEnregistrement(strligne, hStart, nomChaine, ttitre, hStop)

                            If _
                                Not [String].Equals(hStart, heureDebutDemarquee, StringComparison.CurrentCulture) Or
                                Not [String].Equals(hStop, heureFinDemarquee, StringComparison.CurrentCulture) Or
                                Not [String].Equals(nomChaine, chaineDemarquee, StringComparison.CurrentCulture) Or
                                Not [String].Equals(ttitre, titre, StringComparison.CurrentCulture) Then
                                chaineGlobale = chaineGlobale & strligne & vbCrLf
                            End If
                        End If
                    Loop
                    monStreamDocument.Close()
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
                    'If File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
                    '    SupprimerFichierMarquage()
                    'End If

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

    Private Sub FonctionClickEmission(ByVal sender As Object, ByVal e As MouseEventArgs)
        Trace.WriteLine(DateTime.Now & " " & "Fonction click emission_ce_soir_ou_maintenant")
        Select Case e.Button
            Case MouseButtons.Left
                If e.Clicks = 1 Then
                    AffichePopup(sender)
                End If

        End Select
    End Sub

    Private Sub Pave_MouseLeave(sender As System.Object, e As EventArgs)
        If My.Settings.Slide = 1 Then
            CType(sender, Control).Width -= 100
        End If
    End Sub

    Private Sub Pave_MouseEnter(sender As System.Object, e As EventArgs)
        If My.Settings.Slide = 1 Then
            CType(sender, Control).Width += 100
        End If
    End Sub

    Private Sub SeachInfo(titre As String, engine As String) Handles PopupContent.EventInfo
        'gestion des clics sur les linklabel
        'envoi un event personnalisé composé du titre et d'un string contenant l'info sur quoi rechercher

        If Not (IsOffline) Then
            Try
                Select Case engine
                    Case LngPopupStrRechercheAvancee
                        Using ra As New TVGuideMainForm(ObjRecherche.ParTerme, titre)
                            ra.ShowDialog()
                        End Using

                    Case "IMDB"
                        If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.imdb.com") Then
                            If My.Settings.Language = "Français" Then
                                Process.Start("http://www.imdb.fr/find?q=" & titre)
                            Else
                                Process.Start("http://www.imdb.com/find?q=" & titre)
                            End If
                        Else
                            ' ReSharper disable NotAccessedVariable
                            Dim boxNoConnection As DialogResult
                            ' ReSharper restore NotAccessedVariable
                            boxNoConnection =
                                MessageBox.Show(New Form() With {.TopMost = True}, MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation)
                        End If
                    Case "Allociné"
                        If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.allocine.fr") Then
                            Process.Start("http://www.allocine.fr/recherche/?q=" & titre)
                        Else
                            ' ReSharper disable NotAccessedVariable
                            Dim boxNoConnection As DialogResult
                            ' ReSharper restore NotAccessedVariable
                            boxNoConnection =
                                MessageBox.Show(New Form() With {.TopMost = True}, MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation)
                        End If
                    Case LngPopupStrTVDB
                        If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.thetvdb.com") Then
                            ThetvdbName = titre
                            SeriesBrowser.ShowDialog()
                        Else
                            ' ReSharper disable NotAccessedVariable
                            Dim boxNoConnection As DialogResult
                            ' ReSharper restore NotAccessedVariable
                            boxNoConnection =
                                MessageBox.Show(New Form() With {.TopMost = True}, MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation)
                        End If
                    Case "Rotten Tomatoes"
                        If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.rottentomatoes.com/") Then
                            Process.Start("http://www.rottentomatoes.com/search/?search=" & titre)
                        Else
                            ' ReSharper disable NotAccessedVariable
                            Dim boxNoConnection As DialogResult
                            ' ReSharper restore NotAccessedVariable
                            boxNoConnection =
                                MessageBox.Show(New Form() With {.TopMost = True}, MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation)
                        End If
                    Case "Google"
                        If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://www.google.com/") Then
                            Process.Start("https://www.google.com/search?q=" & titre)
                        Else
                            ' ReSharper disable NotAccessedVariable
                            Dim boxNoConnection As DialogResult
                            ' ReSharper restore NotAccessedVariable
                            boxNoConnection =
                                MessageBox.Show(New Form() With {.TopMost = True}, MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation)
                        End If
                    Case "Youtube"
                        If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("https://www.youtube.com") Then
                            Process.Start("https://www.youtube.com/results?search_query=" & titre)
                        Else
                            ' ReSharper disable NotAccessedVariable
                            Dim boxNoConnection As DialogResult
                            ' ReSharper restore NotAccessedVariable
                            boxNoConnection =
                                MessageBox.Show(New Form() With {.TopMost = True}, MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                                MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation)
                        End If

                End Select
            Catch ex As Exception
                ' ReSharper disable NotAccessedVariable
                Dim boxNoConnection As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoConnection =
                    MessageBox.Show(New Form() With {.TopMost = True}, MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1,
                                    MessageBoxNoConnectionTitre, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
            End Try
        ElseIf engine = "Recherche avancée (interne)" Then
            Using ra As New TVGuideMainForm(ObjRecherche.ParTerme, titre)
                ra.ShowDialog()
            End Using

        End If
    End Sub

#End Region
    Public Sub MajEmission()
        Force = True
        Dim listC As Dictionary(Of String, Integer) = ListeCategorie()
        Mainform.SuspendLayout()
        For Each ctrl As Control In Mainform.PanelA.Controls
            If TypeOf (ctrl) Is PaveCentral Then
                If Not String.IsNullOrEmpty(ctrl.Text) Then ' Ouais genial y des pavés vides 
                    DirectCast(ctrl, PaveCentral).BgColor =
                        Color.FromArgb(listC(TableauListEmissions(ctrl.TabIndex).PcategoryTv))
                End If
            End If
        Next

        For Each ctrl As Control In Mainform.Panel_ce_soir.Controls
            If TypeOf (ctrl) Is PaveCentral Then
                DirectCast(ctrl, PaveCentral).BgColor =
                    Color.FromArgb(listC(TableauListEmissionsCeSoir(ctrl.TabIndex).PcategoryTv))
            End If
        Next

        For Each ctrl As Control In Mainform.Panel_maintenant.Controls
            If TypeOf (ctrl) Is PaveActuellement Then
                DirectCast(ctrl, PaveActuellement).BgColor =
                    Color.FromArgb(listC(TableauListEmissionsMaintenant(ctrl.TabIndex).PcategoryTv))
            End If
        Next
        Mainform.ResumeLayout()
    End Sub

End Class