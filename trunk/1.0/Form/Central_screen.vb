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
Imports System.IO
Imports System.Threading
Imports System.ComponentModel
Imports System.Net
Imports System.Text.RegularExpressions
Imports ZGuideTV.SQLiteWrapper
Imports ZGuideTV.ZGuideTVDotNetTvdb

Public Class Central_Screen

#Region "Property"
    Private _delaiAvertissement As Integer = 2

    Public Property delai_avertissement As Integer
        Get
            Return _delaiAvertissement
        End Get
        Set(ByVal Value As Integer)
            _delaiAvertissement = Value
        End Set
    End Property

    ' preavis avant de rappeler une emission marquée
    Private _compteurMinute As Integer = 18

    Public Property compteur_minute As Integer
        Get
            Return _compteurMinute
        End Get
        Set(ByVal Value As Integer)
            _compteurMinute = Value
        End Set
    End Property

    ' pour que l affichage du panneau cinema se fasse apres 2 minutes(20-18)
    Private _intervalCinema As Integer = 20

    Public Property interval_cinema As Integer
        Get
            Return _intervalCinema
        End Get
        Set(ByVal Value As Integer)
            _intervalCinema = Value
        End Set
    End Property

    ' affichage de panel_cinema toutes les 20 minutes
    ' l affichage du panneau cinema se fait pendant une minute
    ' 15 sec d affichage du panneau cinema
    Private _dureeAffichageCinema As Integer = 15000

    Public Property duree_affichage_cinema As Integer
        Get
            Return _dureeAffichageCinema
        End Get
        Set(ByVal Value As Integer)
            _dureeAffichageCinema = Value
        End Set
    End Property

    Private _repereClickEmission As Integer

    Public Property repere_click_emission As Integer
        Get
            Return _repereClickEmission
        End Get
        Set(ByVal Value As Integer)
            _repereClickEmission = Value
        End Set
    End Property

    Private _posInit As Integer

    Public Property pos_init As Integer
        Get
            Return _posInit
        End Get
        Set(ByVal Value As Integer)
            _posInit = Value
        End Set
    End Property

    Private _securiteSignaletique As Integer = 10

    Public Property securite_signaletique As Integer
        Get
            Return _securiteSignaletique
        End Get
        Set(ByVal Value As Integer)
            _securiteSignaletique = Value
        End Set
    End Property

    Private _tailleImageSignaletique As Integer = 20

    Public Property taille_image_signaletique As Integer
        Get
            Return _tailleImageSignaletique
        End Get
        Set(ByVal Value As Integer)
            _tailleImageSignaletique = Value
        End Set
    End Property

    Private _heureDebutDemarquee As String

    Public Property heure_debut_demarquee As String
        Get
            Return _heureDebutDemarquee
        End Get
        Set(ByVal Value As String)
            _heureDebutDemarquee = Value
        End Set
    End Property

    Private _chaineDemarquee As String

    Public Property chaine_demarquee As String
        Get
            Return _chaineDemarquee
        End Get
        Set(ByVal Value As String)
            _chaineDemarquee = Value
        End Set
    End Property

    Private _titreDemarque As String

    Public Property titre_demarque As String
        Get
            Return _titreDemarque
        End Get
        Set(ByVal Value As String)
            _titreDemarque = Value
        End Set
    End Property

    Private _heureFinDemarquee As String

    Public Property heure_fin_demarquee As String
        Get
            Return _heureFinDemarquee
        End Get
        Set(ByVal Value As String)
            _heureFinDemarquee = Value
        End Set
    End Property

    Private _nomFichier As String

    Public Property nom_fichier As String
        Get
            Return _nomFichier
        End Get
        Set(ByVal Value As String)
            _nomFichier = Value
        End Set
    End Property

    Private _messageBoxNoConnection As String

    Public Property MessageBoxNoConnection As String
        Get
            Return _messageBoxNoConnection
        End Get
        Set(ByVal Value As String)
            _messageBoxNoConnection = Value
        End Set
    End Property

    Private _messageBoxNoConnection1 As String

    Public Property MessageBoxNoConnection1 As String
        Get
            Return _messageBoxNoConnection1
        End Get
        Set(ByVal Value As String)
            _messageBoxNoConnection1 = Value
        End Set
    End Property

    Private _messageBoxNoConnectionTitre As String

    Public Property MessageBoxNoConnectionTitre As String
        Get
            Return _messageBoxNoConnectionTitre
        End Get
        Set(ByVal Value As String)
            _messageBoxNoConnectionTitre = Value
        End Set
    End Property

    Private _richTextBoxDescripFrom As String

    Public Property RichTextBoxDescripFrom As String
        Get
            Return _richTextBoxDescripFrom
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripFrom = Value
        End Set
    End Property

    Private _richTextBoxDescripTo As String

    Public Property RichTextBoxDescripTo As String
        Get
            Return _richTextBoxDescripTo
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripTo = Value
        End Set
    End Property
    Private _richTextBoxDescripDescrip As String

    Public Property RichTextBoxDescripDescrip As String
        Get
            Return _richTextBoxDescripDescrip
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripDescrip = Value
        End Set
    End Property

    Private _richTextBoxDescripActors As String

    Public Property RichTextBoxDescripActors As String
        Get
            Return _richTextBoxDescripActors
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripActors = Value
        End Set
    End Property

    Private _richTextBoxDescripCategory As String

    Public Property RichTextBoxDescripCategory As String
        Get
            Return _richTextBoxDescripCategory
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripCategory = Value
        End Set
    End Property

    Private _richTextBoxDescripProductionDate As String

    Public Property RichTextBoxDescripProductionDate As String
        Get
            Return _richTextBoxDescripProductionDate
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripProductionDate = Value
        End Set
    End Property

    Private _richTextBoxDescripDuree As String

    Public Property RichTextBoxDescripDuree As String
        Get
            Return _richTextBoxDescripDuree
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripDuree = Value
        End Set
    End Property

    Private _richTextBoxDescripShowView As String

    Public Property RichTextBoxDescripShowView As String
        Get
            Return _richTextBoxDescripShowView
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripShowView = Value
        End Set
    End Property

    Private _richTextBoxDescripDate As String

    Public Property RichTextBoxDescripDate As String
        Get
            Return _richTextBoxDescripDate
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripDate = Value
        End Set
    End Property

    Private _richTextBoxDescripGenre As String

    Public Property RichTextBoxDescripGenre As String
        Get
            Return _richTextBoxDescripGenre
        End Get
        Set(ByVal Value As String)
            _richTextBoxDescripGenre = Value
        End Set
    End Property

    'ToolTips
    Public descTooltip As New ToolTip

    Private _sTitre As String

    Public Property s_titre As String
        Get
            Return _sTitre
        End Get
        Set(ByVal Value As String)
            _sTitre = Value
        End Set
    End Property

    Private _sSousTitre As String

    Public Property s_sous_titre As String
        Get
            Return _sSousTitre
        End Get
        Set(ByVal Value As String)
            _sSousTitre = Value
        End Set
    End Property

    Public Property Tab_Couleur As Color()
        Get
            Return _tabCouleur
        End Get
        Set(ByVal Value As Color())
            _tabCouleur = Value
        End Set
    End Property
#End Region

    Friend Sub CentralScreen(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Néo le 27/08/2009
        LanguageCheck()

        ' 26/07/2010
        'With descTooltip
        '    .IsBalloon = False
        '    .ShowAlways = True
        '    .AutomaticDelay = 500
        '    .AutoPopDelay = 9999
        '    .InitialDelay = 500
        'End With
    End Sub

    Private _tabCouleur As Color() = {Color.FromArgb(255, 191, 191), Color.FromArgb(255, 191, 255), Color.FromArgb(223, 191, 255), _
                 Color.FromArgb(206, 189, 255), _
                 Color.FromArgb(191, 191, 255), Color.FromArgb(191, 253, 255), _
                 Color.FromArgb(255, 229, 229), Color.FromArgb(191, 255, 191), Color.FromArgb(223, 255, 191), _
                 Color.FromArgb(239, 255, 191), _
                 Color.FromArgb(255, 174, 128), Color.FromArgb(255, 223, 128), Color.FromArgb(255, 214, 191), _
                 Color.FromArgb(255, 221, 191), Color.FromArgb(236, 236, 236), Color.FromArgb(255, 128, 128), _
                 Color.FromArgb(178, 178, 178), Color.FromArgb(240, 230, 140), Color.FromArgb(240, 255, 128), _
                 Color.FromArgb(191, 255, 128), Color.FromArgb(140, 255, 128), Color.FromArgb(128, 255, 159), _
                 Color.FromArgb(128, 255, 206), Color.FromArgb(128, 255, 255), Color.FromArgb(128, 208, 255), _
                 Color.FromArgb(128, 159, 255), Color.FromArgb(142, 128, 255), _
                 Color.FromArgb(191, 128, 255), Color.FromArgb(238, 128, 255), Color.FromArgb(255, 128, 223), _
                 Color.FromArgb(255, 255, 128), Color.FromArgb(128, 255, 128), _
                 Color.FromArgb(0, 255, 128), Color.FromArgb(128, 255, 255), Color.FromArgb(128, 180, 255), _
                 Color.FromArgb(255, 217, 217), Color.FromArgb(255, 217, 255), Color.FromArgb(237, 217, 255), _
                 Color.FromArgb(236, 217, 255), Color.FromArgb(225, 217, 255)}

    Public Sub Pixels_Non_Utilisés_Pour_Les_emissions()

        ' cette sr ne peut etre appelée qu après définition de
        ' l1, l2, l3, panelB.width et panelC.width
        ' cad après create_panelbox et premieres_initialisations
        Dim i As Integer

        inutilise_a_gauche(0) = largeur_boutons_verticaux * 2 + Mainform.PanelB.Width
        inutilise_a_gauche(1) = inutilise_a_gauche(0)
        inutilise_a_gauche(2) = l2 + largeur_boutons_verticaux * 2
        inutilise_a_gauche(3) = inutilise_a_gauche(2)
        inutilise_a_gauche(4) = l1 + largeur_boutons_verticaux * 2 + Mainform.PanelB.Width
        inutilise_a_gauche(5) = inutilise_a_gauche(4)
        inutilise_a_gauche(6) = l1 + l2 + largeur_boutons_verticaux * 2
        inutilise_a_gauche(7) = inutilise_a_gauche(6)

        inutilise_a_droite(0) = largeur_boutons_verticaux + l3
        inutilise_a_droite(1) = largeur_boutons_verticaux
        inutilise_a_droite(2) = largeur_boutons_verticaux + l3
        inutilise_a_droite(3) = largeur_boutons_verticaux
        inutilise_a_droite(4) = largeur_boutons_verticaux + l3
        inutilise_a_droite(5) = largeur_boutons_verticaux
        inutilise_a_droite(6) = largeur_boutons_verticaux + l3
        inutilise_a_droite(7) = largeur_boutons_verticaux

        For i = 0 To bits_config
            inutilise_total(i) = inutilise_a_gauche(i) + inutilise_a_droite(i)
            larg_max_panelA(i) = My.Computer.Screen.Bounds.Right - inutilise_total(i)
        Next i
    End Sub

    Public Sub Calcul_Date_Origine_Ecran()

        ' Chaque fois qu on clique sur un bouton gauche droit, bas1 ...
        ' il faut recalculer la date ORIGINE Car celle ci dépend de la config des 3 bits
        Trace.WriteLine(DateTime.Now & " " & "Calcul origine écran")
        Dim pixels As Integer
        pixels = -Mainform.PanelA.Left + inutilise_a_gauche(synth_boutons)
        date_origine_ecran = date_reference.AddMinutes(pixels * 30 / nb_pixels_pour_30_minutes)
        'date_origine_ecran = CDate(date_origine_ecran.AddMinutes(1).ToString("dd/M/yyyy HH:00:00"))
        date_origine_ecran = DebutHeure(date_origine_ecran.AddMinutes(1))
        date_fin_ecran = date_origine_ecran.AddMinutes(30 * larg_max_panelA(synth_boutons) / nb_pixels_pour_30_minutes)
        Trace.WriteLine(DateTime.Now & " " & "Date origine écran = " & date_origine_ecran.ToString)
    End Sub

    Public Sub premiere_emission_non_visible()

        ' calcule toutes les premieres emissions non visibles
        ' (meme hors ecran .. a gauche de buttongauche )pour toutes les chaines
        ' Cette SR ne peut etre appelee qu apres calcul de :
        ' nombre_de_chaines_differentes()
        ' nb_emissions_par_chaine(i)
        Dim som As Integer = 1
        Dim j As Integer = 1
        Dim i As Integer
        tab_premiere_emission_non_visible(j) = som
        For i = 1 To nombre_de_chaines_differentes
            som += nb_emissions_par_chaine(i)
            j += 1
            tab_premiere_emission_non_visible(j) = som
            Trace.WriteLine(DateTime.Now & " " & _
                             "chaine n°  " & j.ToString & " premiere_emission_non_visible = " & _
                             tab_premiere_emission_non_visible(j).ToString)
        Next i
    End Sub

    Public Function Premiere_Emission_Visible(ByVal Numero_de_chaine As Integer, ByVal date_donnee As DateTime) _
        As Integer

        ' Cette fonction retourne la premiere emission visible
        ' (à droite de buttongauche)
        ' 1)preliminaires:
        ' calcul des indices limit1 et limit2 qui indiquent
        ' entre quelles limites dans tableau_list_emission il
        ' faut rechercher l emission
        ' dont on donne:
        ' a)le numero de chaine
        ' b)une heure qui doit etre à l intérieur de l émission
        ' 2) calcul du numero d emission qui correspond a cela
        ' ouput: un numero d indice de tableau_list_emissions qui correspond                      
        ' a l emission cherchée
#If DEBUG Then
        Trace.WriteLine( _
                         DateTime.Now & " " & "On cherche le numéro d'émission qui correspond à la chaine  :" & _
                         Numero_de_chaine.ToString)
        Trace.WriteLine(DateTime.Now & " et qui contient la date suivante: " & date_donnee.ToString)
#End If
        Dim t1, t2 As New DateTime
        Dim limit1 As Integer
        Dim limit2 As Integer
        Dim i As Integer
        flag_emission_not_found = True
        limit1 = tab_premiere_emission_non_visible(Numero_de_chaine)
        limit2 = tab_premiere_emission_non_visible(Numero_de_chaine + 1)
        '160210  + 1
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "limit 1 et limit2 = " & limit1.ToString & "  " & limit2.ToString)
        Trace.WriteLine(DateTime.Now & " " & "Recherche d'émission entre ces 2 limites")
#End If
        For i = limit1 To limit2
            t1 = tableau_list_emissions(i).pstart
            t2 = tableau_list_emissions(i).pstop

            If _
                (t1 <= date_donnee And date_donnee < t2) And _
                tableau_list_emissions(i).ChannelID = table_des_chaines_a_selectionner(Numero_de_chaine) Then
                flag_emission_not_found = False
                Return i
            End If
        Next i

        Trace.WriteLine(DateTime.Now & " " & "On n'a pas trouvé l'émission recherchée")
        flag_emission_not_found = True
        ' prendre une emission au hazard 040110
        Trace.WriteLine( _
                         DateTime.Now & " " & _
                         "On n'a pas trouvé l'émission recherchée meme apres incrementation du numero de chaine")
        Return 400

    End Function

    Public Sub Initialisations_Diverses()

        Trace.WriteLine(DateTime.Now & " " & " Entrée Central_screen.vb --> Initialisations_Diverses()")
        'depart_affichage = CDate(moment_souhaite.ToString("dd/M/yyyy HH:00:00"))
        depart_affichage = DebutHeure(moment_souhaite)
        fin_affichage = depart_affichage.AddHours(nb_de_periodes_de_6h * Nb_heures_LigneTemps)

        ' ce sont ces 2 valeurs qui seront prises en compte
        ' dans SR fill_tableaux_top_width_left
        'Clear_AetB_panelboxes()
        'Get_Types_Of_Emissions()

        If des_canaux_sont_memorises Then

        Else
            Get_Nb_Emissions_From_Db()

            'calcule nb_total_chaines
            Get_Names_Of_Channels_From_Database()
        End If

#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Nb total type_emissions pour periode de +- 9 jours :" & _
nb_total_type_emission)
#End If
        Trace.WriteLine(DateTime.Now & " identification " & nom_des_chaines_memorisees)
        Fill_Table_Des_Chaines_A_Selectionner()
        indice_courant_TLE = 1
        Calcul_Des_Bolded_Dates()
        ' dates où il existe des emissions dans la BDD

#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Date du moment = " & DateTime.Now.ToString)
#End If
        Get_Nb_Emissions_From_Db()
        Build_Qwery_On_Channels_Where_and_Between()
        indice_courant_TLE = 1
        Group_Fonction1()

        Group_Fonction2()
        Select Case nb_emissions_for_SQL_Request
            Case 0
                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "Arrêt de l'application car les données d'émissions sont trop anciennes")

                Miseajour.Show()
                Trace.WriteLine(DateTime.Now & " " & "Suppression de db_progs.db3 qui contient des adonnées périmées")
                Trace.WriteLine(DateTime.Now & " " & "Arrêt de l'application")

                ' Il faut fermer la BDD si elle est perimee(avant de supprimer db_progs.db3 BB101209


                ' IL faut supprimer le fichier db_progs.db3 dans application data
                ' pour pouvoir sortir de ce cycle sans fin
                File.Delete(BDDPath & "db_progs.db3")
                Trace.WriteLine( _
                                 DateTime.Now & _
                                 " sortie de l application apres suppression de db_prog.mdb pour eviter boucle sans fin")
                Mainform.tl.Close()
                Application.Exit()
            Case Else
        End Select
        indice_du_controle_curseur = Mainform.PanelA.Controls.Count
        If indice_du_controle_curseur <> 0 Then
            Curseur_Vertical()
        End If

        ' On récupère les émissions marquées
        If File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
            maj_fichier_marquage()
            'BB110810
            ' BB260810  Mainform.Timer_heure.Start()
            'BB110810
        End If
        Mainform.Timer_heure.Start()
        'BB110810 pour surveiller le rappel d emissions marquees
        Mainform.Refresh()
        fin_initialize = True
        Trace.WriteLine(DateTime.Now & " " & "Sortie Central_screen.vb --> Initialisations_Diverses()")
    End Sub

    Public Sub Clear_AetB_panelboxes()

        Trace.WriteLine(DateTime.Now & " " & "sub clear A et B panel box")
        With Mainform
            .PanelA.Controls.Clear()
            .PanelB.Controls.Clear()
            .LoaderShow()
        End With

        Application.DoEvents()
        'Thread.Sleep(250)
    End Sub

    Public Sub Calcul_Des_Proprietes_Top_Des_Lignes_Richtextbox()

        ' en fait on calcule la prop top de toutes les emissions dans l espace
        ' de temps de 6 heures et bien au dela du nbre de chaines affichees a l ecran
        ' PREALABLE :  nb_chaines_ecran,hauteur_richtextbox
        Dim i As Integer = 1
        ord_top_ligne(i) = 0
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Calcul des top des lignes richtextbox")
        Trace.WriteLine(DateTime.Now & " " & "i= " & i.ToString & "   ord_top_ligne = " & ord_top_ligne(i).ToString)
#End If
        For i = 2 To nombre_de_chaines_differentes + 1
            ord_top_ligne(i) = ord_top_ligne(i - 1) + periodicite_verticale
#If DEBUG Then
            Trace.WriteLine( _
                             DateTime.Now & " " & "i= " & i.ToString & "   ord_top_ligne = " & _
                             ord_top_ligne(i).ToString)
#End If
        Next i
    End Sub

    Public Function Date_Inferieure(ByVal d1 As DateTime, ByVal d2 As DateTime) As DateTime

        Select Case d1
            Case Is >= d2
                Return d2
            Case Else
                Return d1
        End Select
    End Function

    Public Function Date_Superieure(ByVal d1 As DateTime, ByVal d2 As DateTime) As DateTime

        Select Case d1
            Case Is > d2
                Return d1
            Case Else
                Return d2
        End Select
    End Function

    Public Sub Fill_Table_Des_Chaines_A_Selectionner()

        ' input: tableau_chaine(i)(mis à jour) qui est un tableau de structure
        ' à 4 colonnes
        ' ouput :table_des_chaines_a_selectionner
        ' les identificateurs des chaines ( C31.telepoche.com, C142.telpo)
        ' sont remplis dans un tableau table_des_chaines_à_selectionner
        Dim i As Integer
        For i = 1 To nb_total_chaines
            table_des_chaines_a_selectionner(i) = tableau_chaine(i).identificateur
        Next i
#If DEBUG Then
        Trace.WriteLine( _
                         DateTime.Now & " " & _
                         "Table_des_chaines_a_selectionner en fin de fill_table_des_chaines a selectionner")
        For i = 1 To nb_total_chaines + 1
            If table_des_chaines_a_selectionner(i) <> "" Then
                Trace.WriteLine( _
                                 DateTime.Now & " " & "i=" & i.ToString & " Identif chaine = " & _
table_des_chaines_a_selectionner(i) & _
                                 " indice = " & tableau_chaine(i).indice.ToString)
            End If
        Next i
#End If
    End Sub

    Public Sub Fill_Tableaux_Top_Width_Left()

        ' input:nb_emissions_par_chaine à jour
        ' input:table_list_emissions mis à jour
        ' output:Ces tableaux contiennent les infos localisant les richtextbox à
        ' l'ecran(propriété top, left, width de richtextbox)
        ' PREALABLE: depart_affichage et fin_affichage calculé par
        ' plage_horaire_a_afficher
        Dim d_start, d_debut_ecran, d_stop, d_fin_ecran As New DateTime
        Dim tps1, tps2 As New TimeSpan
        Dim k, deb, i, j, som As Integer
        Dim double_m As Double
        Dim double_p As Double
        Trace.WriteLine(DateTime.Now & " " & "entree dans Fill_Tableaux_Top_Width_Left")

#If DEBUG Then
        Dim monstopwatch2 As New Stopwatch
        monstopwatch2.Start()
        Dim tps_ecoule As Long
#End If
        Try

        Catch ex As Exception

        End Try

        d_fin_ecran = fin_affichage
        d_debut_ecran = depart_affichage
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "d_debut_ecran = " & d_debut_ecran.ToString)
        Trace.WriteLine(DateTime.Now & " " & "d_fin_ecran = " & d_fin_ecran.ToString)
#End If
        j = 1

        ' indice qui parcourt nb_emissions_par_chaine
        k = j

        ' k = le numero de la chaine ds nb_emissions_par_chaine
        som = nb_emissions_par_chaine(1)
        For i = 1 To nb_emissions_for_SQL_Request
            '-------------------------
            d_start = tableau_list_emissions(i).pstart
            d_stop = tableau_list_emissions(i).pstop
            '-------------------------
            d_stop = Date_Inferieure(d_stop, d_fin_ecran)
            d_start = Date_Inferieure(d_start, d_fin_ecran)
            d_stop = Date_Superieure(d_stop, d_debut_ecran)
            d_start = Date_Superieure(d_start, d_debut_ecran)

            tps1 = d_stop.Subtract(d_start)

            ' duree emission
            double_m = (1440 * tps1.Days + 60 * tps1.Hours + tps1.Minutes + (tps1.Seconds / 60)) * echelle1
            If double_m < 0 Then
                Trace.WriteLine(DateTime.Now & " " & "double_m était négatif " & double_m.ToString)
                double_m = 1
                Trace.WriteLine(DateTime.Now & " " & "dstart= " & d_start.ToString & " dstop = " & d_stop.ToString)
            End If
            tps2 = d_start.Subtract(d_debut_ecran)

            ' ecart debut emission et debut ecran
            double_p = (1440 * tps2.Days + 60 * tps2.Hours + tps2.Minutes + (tps2.Seconds / 60)) * echelle1
            If double_p < 0 Then
                Trace.WriteLine(DateTime.Now & " " & "double_p était négatif " & double_p.ToString)
                double_p = 1
            Else
            End If
            val_width(i) = CInt(Math.Truncate(double_m))
            val_left(i) = CInt(Math.Truncate(double_p))
            deb = val_left(i)
            val_top(i) = ord_top_ligne(k)

            j += 1

            ' on incremente le compteur de nombre d emissions
            If j > som Then
                k += 1

                ' on passe a la chaine suivante
                som = som + nb_emissions_par_chaine(k)
            End If
        Next i
        Select Case tri_categorie
            Case False

                ' S 'assurer que 2 richtextbox ne sont pas séparés que par 1 pixels
                Dim N As Integer
                For i = 1 To nb_emissions_for_SQL_Request - 1
                    N = val_left(i + 1) - (val_left(i) + val_width(i))
                    val_width(i) += N - 1
                Next i
        End Select
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & "val_left(i) dans fill_tableaux_top_width_left")
        Trace.WriteLine("")
        Dim limite As Integer = 50
        If 50 > nb_emissions_for_SQL_Request Then limite = nb_emissions_for_SQL_Request
        For i = 1 To limite
            ' imprimer 50 valeurs de val_left(i)
            Trace.Write(" i= " & i.ToString & " val_left(i)" & val_left(i).ToString & "   ")
        Next i
#End If
        d_debut_ecran = Nothing
        d_start = Nothing
        d_stop = Nothing
        d_fin_ecran = Nothing
        tps1 = Nothing
        tps2 = Nothing

#If DEBUG Then
        monstopwatch2.Stop()
        tps_ecoule = monstopwatch2.ElapsedMilliseconds
        Trace.WriteLine( _
                         DateTime.Now & " " & "Tps exécution fill tableau top left width = " & tps_ecoule.ToString & _
                         " msec")
        monstopwatch2 = Nothing
#End If
    End Sub

    Public Sub Fill_Tableaux_Top_Width_Left_ce_soir()

        ' input:nb_emissions_par_chaine à jour
        ' input:table_list_emissions mis à jour
        ' output:  Ces tableaux contiennent les infos localisant
        ' les richtextbox à 
        ' l'ecran(propriété top, left, width de richtextbox)
        ' PREALABLE: depart_affichage et fin_affichage calculé
        ' par plage_horaire_a_afficher
        Dim i As Integer

        val_left_cesoir_maintenant = largeur_logo_adaptee
        val_width_cesoir_maintenant = Mainform.Calendar.Width - largeur_logo_adaptee
        For i = 0 To nb_emissions_for_ce_soir
            val_top_ce_soir(i) = i * (hauteur_richtextbox + espace_entre_richtextbox)
        Next i
    End Sub

    Public Sub Fill_Tableaux_Top_Width_Left_Maintenant()

        ' input:table_list_emissions_maintenant mis à jour
        ' output:  Ces tableaux contiennent les infos localisant
        ' les richtextbox à
        ' l'ecran(propriété top, left, width de richtextbox)
        Dim i As Integer
        val_left_cesoir_maintenant = largeur_logo_adaptee
        val_width_cesoir_maintenant = Mainform.Calendar.Width - largeur_logo_adaptee
        For i = 0 To nb_emissions_for_Maintenant
            val_top_Maintenant(i) = i * (hauteur_richtextbox + espace_entre_richtextbox)
        Next i
    End Sub

    Public Sub Fill_Nb_Emissions_Par_Chaine_After_Sql_Request()

        ' input : tableau_list_emissions(i)
        ' output : nb_emissions_par_chaine(i)
        ' cette sr ne repère pas les chaines
        ' qui n'emettent pas pendant le laps de temps choisi
        Dim i, j, count As Integer
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans fill_nb_emissions_par_chaine_after_SQL_REQUEST ")
#End If
        For i = 1 To nb_total_chaines
            nb_emissions_par_chaine(i) = 0
        Next i

        j = 1
        count = 1
        Try

            For i = 1 To (nb_emissions_for_SQL_Request)
                If tableau_list_emissions(i + 1).ChannelID = tableau_list_emissions(i).ChannelID Then
                    count += 1
                Else
                    nb_emissions_par_chaine(j) = count
                    j += 1
                    count = 1
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If count <> 1 Then
            nb_emissions_par_chaine(j) = count - 1
        End If
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "i         nb_emissions_par chaine ")
        For i = 1 To nb_total_chaines + 1
            Trace.WriteLine(DateTime.Now & " " & i.ToString & "   " & nb_emissions_par_chaine(i).ToString)
        Next i
#End If
    End Sub

    Public Sub Calcul_Proprietes_Top_Des_Logo()

        ' le nbre de logos=le nbre de chaines différentes avec présence
        ' d 'émissions
        Dim i, z1, z2 As Integer
        Dim t As Integer = 1

        ' ces valeurs top sont les mêmes que celles des richtextbox
        ' attention il y a des valeurs identiques pour tous les
        ' richtextbox d'une même chaine
        For i = 1 To nb_chaines_ecran + 1
            z1 = ord_top_ligne(i - 1)
            z2 = ord_top_ligne(i)
            If z2 <> z1 Then
                val_top_logo(t) = z1
                t += 1
            End If
        Next i
    End Sub

    Public Sub Fill_Chaine_Logo_Unique()

        ' input
        ' table_des_chaines_a_selectionner
        ' tableau_chaine(x).logo
        ' output : nb de chaines_differentes
        ' hauteur de panel A et Panel B
#If DEBUG Then
        Dim tps_ecoule As Long
        Dim monstopwatch As New Stopwatch
        monstopwatch.Start()
#End If
        Dim i, m, t As Integer
        Dim z As String
        Dim table_intermediaire(nb_total_chaines + 1) As String
        Trace.WriteLine(DateTime.Now & " entree dans fill chaine logo unique")
        For i = 1 To nb_total_chaines
            chaine_logo_unique(i) = Nothing
            table_intermediaire(i) = tableau_chaine(i).identificateur
        Next i
#If DEBUG Then
        For i = 1 To nb_total_chaines
            If table_intermediaire(i) <> "" Then
                Trace.WriteLine( _
                                 DateTime.Now & " " & "i=" & i.ToString & " Identif chaine = " & table_intermediaire(i) _
& " indice = " & _
                                 table_intermediaire(i).ToString)
            End If
        Next i
#End If
        Dim oldz As String = ""
        t = 1
        For i = 1 To nb_emissions_for_SQL_Request
            z = tableau_list_emissions(i).ChannelID
            If z <> oldz Then
                oldz = z
                m = Array.IndexOf(table_intermediaire, z)
                chaine_logo_unique(t) = tableau_chaine(m).logo
                t += 1
            End If
        Next i
        nombre_de_chaines_differentes = t - 1

        With My.Settings
            .nbchainesdiff = nombre_de_chaines_differentes
            .Save()
        End With

#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Nombre de chaine différentes : " & nombre_de_chaines_differentes.ToString)
        For i = 1 To nombre_de_chaines_differentes + 1
            Trace.WriteLine(DateTime.Now & " " & " i = " & i.ToString & " Chaine_logo_unique (" & i.ToString & ") = " & _
chaine_logo_unique(i))
        Next i
        monstopwatch.Stop()
        tps_ecoule = monstopwatch.ElapsedMilliseconds
        Trace.WriteLine(DateTime.Now & " " & "Tps exécution fill chaine logo unique = " & tps_ecoule.ToString & " msec")
        monstopwatch = Nothing
        tps_ecoule = Nothing
#End If

        ' nombre de chaines differentes etant connu on peut attribuer la taille en hauteur de panelA
        With Mainform
            .PanelA.Height = 10 + periodicite_verticale * nombre_de_chaines_differentes
            .PanelB.Height = 10 + periodicite_verticale * nombre_de_chaines_differentes
        End With
    End Sub

    Public Sub Fill_Color_Of_Richtextbox()
        ' •——————————————————————————————————————————————•
        ' | La SR pourrait être simplifiée si on garantit| 
        ' | que la categorie ne se termine pas par"\"    |
        ' •——————————————————————————————————————————————•
        Dim i, n, pos, vert, bleu, rouge As Integer
        Dim z As String
        Dim p As String
        Trace.WriteLine(DateTime.Now & " " & "entree sub fill_color_of_richtextbox")

        ' rvs75,08/10/2009, création des couleurs manquantes
        If Tableau_Type_Emission_fran_var.Length > Tab_Couleur.Length Then

            Dim tiit As Integer = CInt(Fix((Tableau_Type_Emission_fran_var.Length - Tab_Couleur.Length) ^ (1 / 3))) + 1
            Dim cpt_couleur As Integer = Tab_Couleur.Length
            ReDim Preserve Tab_Couleur(Tab_Couleur.Length + CInt((tiit ^ 3)))

            Dim palier As Int32() = {255, 220, 235, 175, 205, 190}

            For vert = 0 To tiit - 1
                For bleu = 0 To tiit - 1
                    For rouge = 0 To tiit - 1
                        Tab_Couleur(cpt_couleur) = _
                            Color.FromArgb(palier(rouge), palier(vert) - 25, palier(bleu) - 5)
                        cpt_couleur += 1
                    Next
                Next
            Next
        End If

        For i = 1 To nb_emissions_for_SQL_Request
            z = tableau_list_emissions(i).PcategoryTV
            pos = z.IndexOf("/", StringComparison.CurrentCulture)
            If pos <> -1 Then
                p = z.Substring(0, pos)
                n = Array.IndexOf(Tableau_Type_Emission_fran_var, p)
            Else
                n = Array.IndexOf(Tableau_Type_Emission_fran_var, z)
                If (Not z Is Nothing AndAlso String.IsNullOrEmpty(z)) Then
                    n = 0
                    ' 230809 categorie non precisee
                End If

            End If
            val_backcolor(i) = Tab_Couleur(n)
        Next i
    End Sub

    Public Sub fill_color_of_richtextbox_ce_soir()

        ' La SR pourrait être simplifiée si on garantit
        ' que la categorie ne se termine pas par"\"
        Dim i, n, pos As Integer
        Dim z, p As String
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans fil color richtextbox ce soir")
        For i = 0 To nb_emissions_for_ce_soir - 1
            z = tableau_list_emissions_ce_soir(i).PcategoryTV
            pos = z.IndexOf("/", StringComparison.CurrentCulture)
            If pos <> -1 Then
                p = z.Substring(0, pos)
                n = Array.IndexOf(Tableau_Type_Emission_fran_var, p)
            Else

                ' categorie non precisée 230809
                n = Array.IndexOf(Tableau_Type_Emission_fran_var, z)

                ' 040909 modifié par Ronaldo
                If n < 0 Then
                    n = 0
                End If
                ' If z = "" Then n = 0 ' categorie non precisée

            End If
            val_backcolor_ce_soir(i + 1) = Tab_Couleur(n)
        Next i
    End Sub

    Public Sub fill_color_of_richtextbox_Maintenant()

        ' La SR pourrait être simplifiée si on garantit
        ' que la categorie ne se termine pas par"\"
        Dim i, n, pos As Integer
        Dim z, p As String
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans fil color richtextbox Maintenant")

        For i = 0 To nb_emissions_for_Maintenant - 1
            z = tableau_list_emissions_Maintenant(i).PcategoryTV
            If z IsNot Nothing Then
                ' Trace.WriteLine(datetime.now & "i= " & i.ToString & " categorie = " & tableau_list_emissions_Maintenant(i).PcategoryTV)
                pos = z.IndexOf("/", StringComparison.CurrentCulture)
                If pos <> -1 Then
                    p = z.Substring(0, pos)
                    n = Array.IndexOf(Tableau_Type_Emission_fran_var, p)
                Else
                    n = Array.IndexOf(Tableau_Type_Emission_fran_var, z)

                    ' •—————————————————————————————————————————————•
                    ' | 040909 modifié par Ronaldo                  |
                    ' •—————————————————————————————————————————————•
                    If n < 0 Then
                        n = 0
                    End If
                    ' categorie non precisée
                    'If z = "" Then n = 0 ' categorie non precisée

                End If
                'Trace.WriteLine(datetime.now & " " & "n = " & n.ToString)
                val_backcolor_Maintenant(i + 1) = Tab_Couleur(n)
            End If
        Next i
        Trace.WriteLine(DateTime.Now & " " & "Sortie de fill color richtextbox Maintenant")
    End Sub

    Public Sub Group_Fonction2()

        ' est appelee dans:btnsauver
        ' dans groupfonction1 , List_of_empty_channles a ete calculé
        ' il ya peut etre des chaines sans emissions
        ' on recalcule donc tableau_chaine(pour ne plus tenir
        ' compte des chaines qui n'ont pas d'emission
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans group_fonction2")
        Second_Fill_Tableau_Chaine()
        Fill_Chaine_Logo_Unique()
        Second_Fill_Table_Des_Chaines_A_Selectionner()
        nb_chaines_ecran = nombre_de_chaines_differentes
        premiere_emission_non_visible()
        Trace.WriteLine( _
                         DateTime.Now & " " & _
                         "Modification de height pour panelA et panelD en fonction nb chaines differentes")
        Calcul_Des_Proprietes_Top_Des_Lignes_Richtextbox()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Fonction 2 entrée dans fill top left width")
#End If
        Fill_Tableaux_Top_Width_Left()
        Fill_Color_Of_Richtextbox()
        Clear_AetB_panelboxes()
        Affect_Richtextbox_Parameters()

    End Sub

    Public Sub Group_Fonction1()

        Get_List_Of_Emissions_For_Sql_Where_and_Between()

        Select Case nb_emissions_for_SQL_Request
            Case 0
                Trace.WriteLine( _
                                 DateTime.Now & " " & _
                                 "Arrêt de l'application car les données d'émissions sont trop anciennes")
                Mainform.tl.Close()
                ' fermeture du fichier log
                Application.Exit()
        End Select
        Fill_Nb_Emissions_Par_Chaine_After_Sql_Request()

        ' calculer , meme pour les chaines vides,  le nombre d emissions
        ' c'est different de nb_emissions_par_chaine qui ne contient pas
        ' de valeurs nulles
        Calcul_Noe_By_Sql()
    End Sub

    Public Sub Second_Fill_Tableau_Chaine()

        ' Ouput : on elimine dans tableau_chaine les references 0
        ' à des chaines sans emissions toujours pour la periode choisie
        Dim tempo(nb_total_chaines + 5) As channel_list
        Dim i As Integer
        Dim origine As Integer
        Dim destination As Integer = 1
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans second_fill_tableau_chaine")

#If DEBUG Then
        Dim stpw As New Stopwatch
        stpw.Start()
#End If

        For i = 1 To nb_total_chaines
            tempo(i) = tableau_chaine(i)
        Next i

        For origine = 1 To nb_total_chaines
            If nb_emissions_yc0_apres_tri_par_chaine(origine) <> 0 Then
                tableau_chaine(destination) = tempo(origine)
                destination += 1
                Continue For
            Else
                Continue For
            End If
        Next origine

        Do While destination < nb_total_chaines
            With tableau_chaine(destination)
                .nom = String.Empty
                .identificateur = String.Empty
                .indice = 0
                .logo = Nothing
                destination += 1
            End With
        Loop

#If DEBUG Then
        stpw.Stop()
        Dim duree As Long
        duree = stpw.ElapsedMilliseconds
        Trace.WriteLine(DateTime.Now & " " & "temps pour second fill table  au chaine" & duree.ToString)
#End If

#If DEBUG Then
        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " tableau_chaine(i) en fin de second_fill_tableau_chaine")
        For i = 1 To nombre_de_chaines_differentes
            Trace.WriteLine( _
                             DateTime.Now & "i=" & i.ToString & "  tableau_chaine (i) = " & _
                             tableau_chaine(i).nom.ToString)
        Next i
        Trace.WriteLine(DateTime.Now & " " & "Sortie de second_fill_tableau_chaine")
        Trace.WriteLine(" ")
#End If
        tempo = Nothing
    End Sub

    Public Sub Second_Fill_Table_Des_Chaines_A_Selectionner()

        ' cette sr permet d avoir une liste des chaines qui comportent
        ' TOUTES des emissions pour la periode de temps imposee
        ' par le nombre de periodes de 6 heures
        Dim i As Integer
        Dim destination As Integer
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans second_fill_table_des_chaines_a_selectionner")

        destination = 1
        For i = 1 To nb_total_chaines
            table_des_chaines_a_selectionner(i) = ""
            table_des_chaines_a_selectionner(i) = tableau_chaine(i).identificateur
        Next i
        table_des_chaines_a_selectionner(i) = ""

        Trace.WriteLine(DateTime.Now & " " & "nb_total chaine =  " & nb_total_chaines.ToString)
#If DEBUG Then
        For i = 1 To nb_total_chaines + 1
            If table_des_chaines_a_selectionner(i) <> "" Then
                Trace.WriteLine(DateTime.Now & " " & "i = " & i.ToString & "  " & table_des_chaines_a_selectionner(i))
            End If
        Next i
#End If

        ' il faut reconstruire nb_emissions_yc0_apres_tri_par_chaine
        ' à partir de nb_emissions_par_chaines par copie simple
        Trace.WriteLine(DateTime.Now & " ds second_fill_table_des_chines , nb_emissions_yc0_par chaine")
        destination = 1
        For i = 0 To nb_total_chaines
            If nb_emissions_par_chaine(i) <> 0 Then
                nb_emissions_yc0_apres_tri_par_chaine(destination) = nb_emissions_par_chaine(i)
                Trace.WriteLine(DateTime.Now & " " & _
                                 " chaine n° = " & destination.ToString & " nb emissions = " & _
                                 nb_emissions_par_chaine(i).ToString)
                destination += 1
                Continue For
            Else
                Continue For
            End If
        Next i
        nb_emissions_yc0_apres_tri_par_chaine(destination) = 0
        Trace.WriteLine(DateTime.Now & " " & "Sortie de second_fill_table_des_chaines_a_selectionner")
    End Sub

    Public Sub Affect_Logo_Picturebox(ByVal offset As Integer)

        ' cet offset est determine par le nbre de fois qu on est passe
        ' dans mousewheel pour bouger dans les chaines a afficher
        Trace.WriteLine(DateTime.Now & " " & "entree dans Affect Logo Picturebox (offset)")
        Dim indice_reduit As Integer
        Dim i As Integer
        Dim str As String
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
            instance = Nothing
        End Try
        logobox = Nothing
        compteur_controles_logo = Mainform.PanelB.Controls.Count
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Compteur de logobox = " & compteur_controles_logo.ToString)
#End If

        ' attention il peut y avoir des chaines qui n emettent pas donc
        ' la chaine_logo_unique n est remplie que jusque
        ' nombre_de_chaines_differentes

        indice_reduit = nombre_de_chaines_differentes
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "nb_emissions pour logo : " & nb_emissions_for_SQL_Request)
#End If
        If (offset + 1) > 0 AndAlso indice_reduit > 0 Then
            For i = offset + 1 To offset + nb_chaines_ecran
                Dim sb4 As String
                sb4 = LogosPath
                sb4 = sb4 & chaine_logo_unique(i)

                Dim logobox1 As New PictureBox
                AddHandler logobox1.MouseDoubleClick, AddressOf ShowJournee
                With logobox1
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = val_top_logo(i - offset)
                    .Height = hauteur_richtextbox
                    .Width = largeur_logo_adaptee
                    Try
                        .Image = Image.FromFile(sb4.ToString)
                    Catch ex As Exception
                        Trace.WriteLine("il manque le logo " & sb4.ToString)
                    End Try
                End With

                sb4 = Nothing
                Try
                    Mainform.PanelB.Controls.Add(logobox1)
                Catch ex As Win32Exception
                    Dim instance As New Win32Exception
                    Dim value As Integer
                    value = instance.NativeErrorCode
                    Trace.WriteLine( _
                                     DateTime.Now & " " & "Dans affect logo picture box  n° " & i.ToString & _
                                     "fin ,error code = " & value.ToString)

                    instance = Nothing
                End Try
                logobox1 = Nothing
                Application.DoEvents()
                'BB 260710
            Next i
        Else
        End If

        str = Nothing
        compteur_controles_logo = Mainform.PanelB.Controls.Count
        Trace.WriteLine(DateTime.Now & " " & "Nb controles logobox = " & compteur_controles_logo.ToString)

        With Mainform
            .PanelB.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picture box")
    End Sub

    Public Sub Affect_Logo_Picturebox_ce_soir(ByVal offset As Integer)

        ' cet offset est de signification inchangée
        Trace.WriteLine(DateTime.Now & " " & "Affect Logo Picturebox_ce_soir (offset)")
        Dim indice_reduit, i As Integer
        Dim str As String
        Mainform.Panel_ce_soir.SuspendLayout()

        Dim logobox As New PictureBox()
        With logobox
            .SizeMode = PictureBoxSizeMode.Zoom
            .Left = 0
            .Top = 0
            .Height = 0
            .Width = 0
            .Image = Nothing
        End With

        ' panel_ce_soir contient,dans sa partie gauche les picturebox
        ' pour les logos et se situe a droite de panelA
        ' panel_ce_soir contient,dans sa partie droite les picturebox
        ' avec le titre de l emission

        Try
            Mainform.Panel_ce_soir.Controls.Add(logobox)
        Catch ex As Win32Exception
            Dim instance As New Win32Exception
            Dim value As Integer
            value = instance.NativeErrorCode
            Trace.WriteLine( _
                             DateTime.Now & " " & "Dans affect logo picture box ce_soir debut :error code = " & _
                             value.ToString)
            instance = Nothing
        End Try
        logobox = Nothing

        ' attention il peut y avoir des chaines qui n emettent pas donc
        ' la chaine_logo_unique n est remplie que jusque
        ' nombre_de_chaines_differentes

        indice_reduit = nb_emissions_for_ce_soir

        Trace.WriteLine(DateTime.Now & " " & "nb_emissions pour logo ce soir: " & nb_emissions_for_ce_soir)
        ' If (offset + 1) > 0 And indice_reduit > 0 Then
        Trace.WriteLine(" ")
        For i = offset To offset + nb_emissions_for_ce_soir - 1
            Dim sb4 As String
            sb4 = LogosPath

            ' tableau_liste_emissions_ce_Soir  a un champ( channelid) du type
            ' C40.telepoche.com)
            ' on recherche dans tableau_chaine(i) l indice j pour
            ' lequel tableau_chaine(j).id = C40.telepoche
            ' A ce moment tableau_chaine(j).logo est le nom du fichier image

            Trace.WriteLine( _
                             DateTime.Now & " i= " & i.ToString & " tableau_list_emissions_ce_soir(i).channelID = " & _
                             tableau_list_emissions_ce_soir(i).ChannelID.ToString)
            Dim trouveidentif As Boolean = False
            Dim k As Integer


            For k = 1 To nb_total_chaines
                If tableau_chaine(k).identificateur = tableau_list_emissions_ce_soir(i).ChannelID Then
                    Trace.WriteLine( _
                                     DateTime.Now & " k= " & k.ToString & " tableau_chaine(k).identificateur = " & _
                                     tableau_chaine(k).identificateur.ToString)
                    Chaine_logo_unique_ce_soir(i) = tableau_chaine(k).logo
                    trouveidentif = True
                    Exit For
                Else
                End If
            Next k
            Trace.WriteLine(" ")

            If trouveidentif Then

                sb4 = sb4 & Chaine_logo_unique_ce_soir(i)
                Dim logobox1 As New PictureBox
                With logobox1
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = val_top_ce_soir(i - offset)
                    .Height = hauteur_richtextbox
                    .Width = largeur_logo_adaptee
                    .Image = Image.FromFile(sb4.ToString)
                End With
                sb4 = Nothing

                Try
                    Mainform.Panel_ce_soir.Controls.Add(logobox1)
                Catch ex As Win32Exception
                    Dim instance As New Win32Exception
                    Dim value As Integer
                    value = instance.NativeErrorCode
                    Trace.WriteLine( _
                                     DateTime.Now & " " & "Dans affect logo picture box ce_soir fin ,error code = " & _
                                     value.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & instance.Message)
                    instance = Nothing
                End Try
                logobox1 = Nothing
            Else
                Trace.WriteLine( _
                                 DateTime.Now & " " & "on n a pas trouve le logo pour " & _
                                 tableau_list_emissions_ce_soir(i).ChannelID.ToString)
            End If
        Next i

        str = Nothing

        With Mainform
            .Panel_ce_soir.ResumeLayout()
            .Panel_ce_soir.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picturebox ce soir")
    End Sub

    Public Sub Affect_Logo_Picturebox_Maintenant(ByVal offset As Integer)

        ' cet offset est de signification inchangee
        Trace.WriteLine(DateTime.Now & " " & "Affect Logo Picturebox_maintenant (offset)")
        Dim indice_reduit As Integer
        Dim i As Integer
        Mainform.Panel_maintenant.SuspendLayout()
        Dim logobox As New PictureBox()
        With logobox
            .SizeMode = PictureBoxSizeMode.Zoom
            .Left = 0
            .Top = 0
            .Height = 0
            .Width = 0
            .Image = Nothing
        End With

        ' panel_ce_soir contient, dans sa partie gauche
        ' les picturebox pour les logos et se situe a droite de panelA
        ' panel_ce_soir contient, dans sa partie droite
        ' les picturebox avec le titre de l emission

        Try
            Mainform.Panel_maintenant.Controls.Add(logobox)
        Catch ex As Win32Exception
            Dim instance As New Win32Exception
            Dim value As Integer
            value = instance.NativeErrorCode
            Trace.WriteLine( _
                             DateTime.Now & " " & "Dans affect logo picture box ce_soir debut :error code = " & _
                             value.ToString)
            instance = Nothing
        End Try
        logobox = Nothing

        ' attention il peut y avoir des chaines qui n emettent pas donc
        ' la chaine_logo_unique n est remplie que jusque
        ' nombre_de_chaines_differentes

        indice_reduit = nb_emissions_for_Maintenant
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "nb_emissions pour logo ce soir : " & nb_emissions_for_ce_soir)
#End If
        For i = offset To offset + nb_emissions_for_Maintenant - 1
            Dim sb4 As String
            sb4 = LogosPath

            ' tableau_liste_emissions_maintenant  a un champ( channelid)
            ' du type C40.telepoche.com)
            ' on recherche dans tableau_chaine(i) l indice j
            ' pour lequel tableau_chaine(j).id = C40.telepoche 
            ' Alors tableau_chaine(j).logo est le nom du fichier image
            Dim trouve_identif As Boolean = False

            Dim k As Integer
            For k = 1 To nb_total_chaines
                If tableau_chaine(k).identificateur = tableau_list_emissions_Maintenant(i).ChannelID Then
                    Chaine_logo_unique_MAintenant(i) = tableau_chaine(k).logo
                    trouve_identif = True
                    Exit For
                Else
                End If
            Next k
            If trouve_identif Then
                sb4 = sb4 & Chaine_logo_unique_MAintenant(i)
                Dim logobox1 As New PictureBox
                With logobox1
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Left = 0
                    .Top = val_top_Maintenant(i - offset)
                    .Height = hauteur_richtextbox
                    .Width = largeur_logo_adaptee
                    .Image = Image.FromFile(sb4.ToString)
                End With
                sb4 = Nothing
                Try
                    Mainform.Panel_maintenant.Controls.Add(logobox1)
                Catch ex As Win32Exception
                    Dim instance As New Win32Exception
                    Dim value As Integer
                    value = instance.NativeErrorCode
                    Trace.WriteLine( _
                                     DateTime.Now & " " & "Dans affect logo picture box ce_soir fin ,error code = " & _
                                     value.ToString)
                    Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & instance.Message)
                    instance = Nothing
                End Try
                logobox1 = Nothing
            Else
                Trace.WriteLine( _
                                 DateTime.Now & " " & "on n a pas trouve le logo pour " & _
                                 tableau_list_emissions_Maintenant(i).ChannelID)
            End If
        Next i

        With Mainform
            .Panel_maintenant.ResumeLayout()
            .Panel_maintenant.Show()
            .ToolStrip1.BringToFront()
        End With

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect logo picture box maintenant")
    End Sub

    Public Function ConnectionAvailable(ByVal strServer As String) As Boolean

        ' rvs75 : 27/10/2010 : renvoie teste isOffline avant tout !!!!
        ' Evite de figer zg
        If Not (isOffline) Then

            Try

                Dim reqFP As HttpWebRequest = CType(HttpWebRequest.Create(strServer), HttpWebRequest)
                Dim rspFP As HttpWebResponse = CType(reqFP.GetResponse(), HttpWebResponse)

                If HttpStatusCode.OK = rspFP.StatusCode Then

                    ' HTTP = 200 - Connection Internet ou serveur disponible
                    reqFP.Abort()
                    rspFP.Close()
                    Return True

                Else

                    ' Autres status - Connection Internet ou serveur indisponible
                    reqFP.Abort()
                    rspFP.Close()
                    Return False

                End If

            Catch e1 As WebException

                ' Connection non disponible
                Return False
            End Try
        End If
    End Function

    ' MARQUAGE d EMISSIONS  et autres fonctions....

    Friend Sub mdown(ByVal sender As Object, ByVal e As MouseEventArgs)

        ' AU moyen d'un click sur la molette centrale de la souris,
        ' on peut marquer  l'emission sur laquelle on a cliqué
        ' ( au moyen de ////) ou supprimer cette marque
        ' existante
        Dim l As Integer
        Dim titre, z, z1 As String

        Select Case e.Button

            Case System.Windows.Forms.MouseButtons.Left

                ' sur bouton gauche
                Trace.WriteLine(DateTime.Now & " " & "passage dans sub mousedown bouton gauche")
                Trace.WriteLine(DateTime.Now & " " & "le click gauche a ete operé")
                Trace.WriteLine(DateTime.Now & " " & "Fonction click  gauche emission")
                Dim i As Integer

                repere_click_emission = CInt(CType(sender, Control).TabIndex)
                Trace.WriteLine(DateTime.Now & " " & "Tag de l'émission = " & repere_click_emission.ToString)
                Trace.WriteLine(DateTime.Now & " " & "composer message descrip ")
                ComposerMessageDescrip(repere_click_emission, "principale")

                With Mainform
                    .PictureBoxLogo.SuspendLayout()
                    .PictureBoxLogo.Controls.Clear()
                End With

                ' il faut rechercher le nom de la chaine à partir de ChannelID
                For i = 1 To nb_total_chaines
                    z = tableau_chaine(i).identificateur
                    If z = s_chid Then
                        Exit For
                    End If
                Next i

                nom_fichier = tableau_chaine(i).logo

                With Mainform
                    .DrawLogoInPictureboxlogo(nom_fichier)
                    .PictureBoxLogo.ResumeLayout()
                End With

                'rvs75 : 27/10/2010 : ne lance la recherche d'information sur le programme que si on est en mode connecté
                If Not (isOffline) AndAlso e.Clicks > 1 Then
                    Trace.WriteLine(DateTime.Now & " " & "passage dans sub mousedown multi clicks ")

                    If My.Settings.EngineShow = True Then
                        EngineSelection.ShowDialog()
                    End If

                    ' Si double click sur un Film/série on recherche dans TheTVDB.Com, IMDb.com, Allocine
                    ' et on affiche dans le navigateur internet la/les fiches dispos
                    Try
                        If My.Settings.EngineSelection = 1 Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.thetvdb.com") _
                                Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans central_screen pour TheTVDB.Com")
                                z1 = tableau_list_emissions(repere_click_emission).Ptitle
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & z1 & _
                                                 " dans TheTVDB.Com")
                                ThetvdbName = tableau_list_emissions(repere_click_emission).Ptitle
                                SeriesBrowser.ShowDialog()
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche TheTVDB.Com
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 2 Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.imdb.com") Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans central_screen pour IMDb.com")
                                z1 = tableau_list_emissions(repere_click_emission).Ptitle

                                If My.Settings.Language = "Français" Then
                                    Process.Start("http://www.imdb.fr/find?q=" & z1)
                                Else
                                    Process.Start("http://www.imdb.com/find?q=" & z1)
                                End If

                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & z1 & _
                                                 " dans IMDB.Com")

                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche IMDb.Com
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 3 AndAlso My.Settings.Language = "Français" Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.allocine.fr") _
                                Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans central_screen pour Allocine.fr")
                                z1 = tableau_list_emissions(repere_click_emission).Ptitle
                                Process.Start("http://www.allocine.fr/recherche/?q=" & z1)
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & z1 & _
                                                 " dans Allocine.fr")
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche allocine.fr
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 3 AndAlso My.Settings.Language <> "Français" Then
                            If _
                                IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.screenrush.co.uk/") Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans central_screen pour Screenrush.co.uk")
                                z1 = tableau_list_emissions(repere_click_emission).Ptitle
                                Process.Start("http://www.screenrush.co.uk/recherche/?motcle=" & z1)
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & z1 & _
                                                 " dans Screenrush.co.uk")
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche Screenrush.co.uk
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                    Catch ex As Exception

                        Dim BoxNoConnection As DialogResult
                        BoxNoConnection = _
                            MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                             MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                             MessageBoxIcon.Exclamation)
                    End Try

                End If

            Case System.Windows.Forms.MouseButtons.Right

                ' sur boutton droit

            Case System.Windows.Forms.MouseButtons.XButton1

                ' sur bouton lateral
                Trace.WriteLine(DateTime.Now & " " & "passage dans sub mousedown bouton lateral")
                repere_click_emission = CInt(CType(sender, Control).TabIndex)
                titre = tableau_list_emissions(repere_click_emission).Ptitle
                titre = titre.Substring(0, titre.Length)
                titre = titre.ToLower
                Mainform.PanelA.Controls(repere_click_emission + 1).Text = titre
            Case System.Windows.Forms.MouseButtons.XButton2

                ' sur roulette centrale superieure
            Case System.Windows.Forms.MouseButtons.Middle

                Trace.WriteLine(DateTime.Now & " " & "passage dans sub mousedown roulette centrale")
                repere_click_emission = CInt(CType(sender, Control).TabIndex)
                Trace.WriteLine(DateTime.Now & " " & "repere_click_emission=" & repere_click_emission.ToString)
                z1 = tableau_list_emissions(repere_click_emission).Ptitle
                z = z1
                'rvs75 25/08/2010
                If DirectCast(sender, PaveCentral).Marquage Then
                    '---------------------------------------------------
                    ' une emission est marquée et on veut la demarquer
                    '---------------------------------------------------
                    'If tableau_list_emissions(repere_click_emission).Ptitle.IndexOf("    ") = 0 Then
                    ' on veut demarquer une emission deja marquee
                    ' C est a dire enlever 4 espaces  avant et après le titre de l emisson
                    heure_debut_demarquee = _
                        tableau_list_emissions(repere_click_emission).pstart.ToString("yyyy/MM/dd HH:mm:ss")
                    chaine_demarquee = tableau_list_emissions(repere_click_emission).ChannelID.ToString
                    titre_demarque = tableau_list_emissions(repere_click_emission).Ptitle.ToString
                    heure_fin_demarquee = _
                        tableau_list_emissions(repere_click_emission).pstop.ToString("yyyy/MM/dd HH:mm:ss")
                    l = z.Length
                    titre = Mid(z, 5, l - 8)
                    tableau_list_emissions(repere_click_emission).Ptitle = titre.ToLower

                    DirectCast(sender, PaveCentral).Marquage = False
                    Mainform.PanelA.Controls(repere_click_emission + 1).Text = _
                        tableau_list_emissions(repere_click_emission).Ptitle

                    '-------------------------------------------------------------------------------------
                    ' il faut enlever du fichier marked.set l emission que l on vient de demarquer 
                    '-------------------------------------------------------------------------------------
                    Dim nom_du_fichier As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
                    If Not (File.Exists(nom_du_fichier)) Then
                        Exit Sub
                    End If
                    '250310 si le fichier n existe pas il n y a rien a recuperer
                    'Dim sr As New StreamReader(nom_du_fichier)
                    Dim strligne As String
                    Dim chaine_globale As String = ""
                    mon_stream_document = New StreamReader(nom_du_fichier)

                    Do While (mon_stream_document.Peek <> -1)
                        ' tant qu il y a des records ds le fichier
                        strligne = mon_stream_document.ReadLine
                        If Not (Not strligne Is Nothing AndAlso String.IsNullOrEmpty(strligne)) Then
                            Dim h_start, nom_chaine, h_stop, ttitre As String
                            h_start = ""
                            nom_chaine = ""
                            h_stop = ""
                            ttitre = ""

                            decomposer_enregistrement(strligne, h_start, nom_chaine, ttitre, h_stop)

                            If _
                                h_start <> heure_debut_demarquee Or h_stop <> heure_fin_demarquee Or _
                                nom_chaine <> chaine_demarquee Or ttitre <> titre Then
                                chaine_globale = chaine_globale & strligne & vbCrLf
                            End If
                        End If
                    Loop
                    mon_stream_document.Close()
                    'sr.Close()
                    Dim nom_du_fichier_destination As String = MarqueesPath & "ZGuideTVDotNet.marked.set"
                    Dim sw2 As New StreamWriter(nom_du_fichier_destination, False)
                    ' on ecrase le fichier existant
                    Trace.WriteLine( _
                                     DateTime.Now & " " & _
                                     "apres suppression eventuelle des lignes perimees,  le fichier devient : " & _
                                     chaine_globale & vbCrLf)
                    With sw2
                        .WriteLine(chaine_globale)
                        .Close()
                        .Dispose()
                    End With

                    Application.DoEvents()
                    If File.Exists(MarqueesPath & "ZGuideTVDotNet.marked.set") Then
                        supprimer_fichier_marquage()
                    End If

                Else
                    '---------------------------------
                    ' on veut marquer une emission
                    '-------------------------------
                    titre = "    " & z1 & "    "

                    DirectCast(sender, PaveCentral).Marquage = True
                    ajouter_ligne_fichier_marquage(repere_click_emission)
                    Application.DoEvents()

                    ' eliminer les emissions marquees qui sont perimées
                    maj_fichier_marquage()
                    Application.DoEvents()
                    Mainform.Timer_heure.Start() ' BB260810 on lance d office le timer apres un marquage
                End If

                DirectCast(sender, PaveCentral).Text = titre
                tableau_list_emissions(repere_click_emission).Ptitle = titre

                With Mainform
                    .Timer_minute.Start()
                    .Timer_minute.Enabled = True
                End With
            Case Else
        End Select
    End Sub

    Public Sub Creer_Emssion_for_Affect_Richtextbox_Parameters(ByVal i As Integer)

        Dim box1 As New PaveCentral
        AddHandler box1.MouseEnter, AddressOf Mouse_Enter
        AddHandler box1.MouseLeave, AddressOf Mouse_Leave
        AddHandler box1.MouseDown, AddressOf mdown

        With box1
            .old_UI = CBool(My.Settings.oldUI)
            .Name = "Botton_Em"
            .Left = val_left(i)
            .Top = val_top(i)
            .Height = hauteur_richtextbox
            .Width = val_width(i)
            .Text = tableau_list_emissions(i).Ptitle
            '.BackColor = val_backcolor(i)
            .BGColor = val_backcolor(i)
            '.FlatStyle = FlatStyle.Popup
            '.TextAlign = ContentAlignment.MiddleLeft
            .Align = StringAlignment.Near
            .Tag = tableau_list_emissions(i).PcategoryTV
            .TabIndex = i

        End With
        Try
            Mainform.PanelA.Controls.Add(box1)

        Catch ex As Win32Exception
            Trace.WriteLine( _
                             DateTime.Now & " " & "Exception lors de l ajout de la box n° " & i.ToString & _
                             " box1 dans affect richtextbox parameters")
            Dim instance As New Win32Exception
            Dim value As Integer
            value = instance.NativeErrorCode
            Trace.WriteLine(DateTime.Now & " " & "Error code = " & value.ToString)
            instance = Nothing
        End Try
        box1 = Nothing
    End Sub

    Public Sub Affect_Richtextbox_Parameters()

        'Modifié par Néo le 24/08/2010
#If DEBUG Then
        Dim monstopwatch3 As New Stopwatch
        monstopwatch3.Start()
        Dim tps_ecoule As Long
#End If
        Dim i As Integer
        Dim memochaine As String = ""
        Dim TableauEmission(nb_chaines_ecran) As AffichagePanelA
        Dim ctpChaine As Integer = -1

        For i = 1 To nb_record_limite_for_sql_request

            'recherche des emissions visible et non visible
            If Not (memochaine.Equals(tableau_list_emissions(i).ChannelID)) Then
                memochaine = tableau_list_emissions(i).ChannelID
                ctpChaine += 1
                TableauEmission(ctpChaine).debutEmission = i

            Else
                If tableau_list_emissions(i).pstart < date_reference.AddHours(14) Then
                    TableauEmission(ctpChaine).emissionVisible += 1
                Else
                    TableauEmission(ctpChaine).emissionNonvisible += 1
                End If
            End If
        Next

        Trace.WriteLine(DateTime.Now & " entree dans affect_richtextbox_parameters")

        'creation des boutons des emissions visibles 
        For t As Integer = 0 To nb_chaines_ecran - 1
            With TableauEmission(t)
                For p As Integer = .debutEmission To .debutEmission + .emissionVisible
                    Creer_Emssion_for_Affect_Richtextbox_Parameters(p - 1)
                Next
            End With
        Next
        Mainform.DessineLigneTemps()

        Calcul_Proprietes_Top_Des_Logo()
        Affect_Logo_Picturebox(0)
        Curseur_Vertical()
        Mainform.LoaderHide()
        'test sur le langage est appliqué à centralScreen !!!
        If Not (RichTextBoxDescripDate Is Nothing) Then
            Mainform.ChercherPremiereEmission()
        End If

        With Mainform
            .ButtonBas1.BringToFront()
            .RichTextBoxDescrip.BringToFront()
        End With

        'creation des boutons des emissions non visibles 
        For t As Integer = 0 To nb_chaines_ecran - 1
            With TableauEmission(t)
                For p As Integer = .debutEmission + .emissionVisible To _
                    .debutEmission + .emissionVisible + .emissionNonvisible
                    Creer_Emssion_for_Affect_Richtextbox_Parameters(p - 1)
                Next
            End With
        Next

#If DEBUG Then
        compteur_controles_richtextbox = Mainform.PanelA.Controls.Count
        monstopwatch3.Stop()
        tps_ecoule = monstopwatch3.ElapsedMilliseconds
        Trace.WriteLine( _
        DateTime.Now & " " & "Tps exécution affect richtextbox parameters = " & tps_ecoule.ToString & _
        " msec")
        Trace.WriteLine(DateTime.Now & " " & "Nb controles richtextbox = " & compteur_controles_richtextbox.ToString)
        Trace.WriteLine(DateTime.Now & " " & "sortie de affect_richtextbox_parameters")
        monstopwatch3 = Nothing
        tps_ecoule = Nothing
#End If

        compteur_controles_richtextbox = Nothing

        Trace.WriteLine(DateTime.Now & " " & "sortie de affect_richtextbox_parameters")
    End Sub

    Public Sub Affect_Richtextbox_ce_soir()
        Dim i As Integer
        Mainform.Panel_ce_soir.SuspendLayout()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans Affect_Richtextbox_ce_soir() ")
#End If
        Mainform.Panel_ce_soir.Controls.Clear()

        i = 0
        Dim box2 As New Button
        With box2
            .FlatStyle = FlatStyle.Popup
            .Left = 0
            .Top = val_top_ce_soir(i)
            .Height = hauteur_richtextbox
            .Width = Mainform.Calendar.Width
            .Text = "Ce soir"
            val_backcolor_ce_soir(0) = Color.LightGray
            .BackColor = val_backcolor_ce_soir(i)
            .ForeColor = Color.Black
            .TextAlign = ContentAlignment.MiddleLeft
        End With
#If DEBUG Then
        Trace.WriteLine( _
                         DateTime.Now & " " & "left = " & val_left_cesoir_maintenant.ToString & " top = " & _
                         val_top_ce_soir(0).ToString & " text= " & tableau_list_emissions_ce_soir(0).Ptitle)
#End If
        Mainform.Panel_titre_ce_soir.Controls.Add(box2)
        box2 = Nothing

        For i = 0 To nb_emissions_for_ce_soir - 1
#If DEBUG Then
            Trace.WriteLine( _
                             DateTime.Now & " " & "left = " & val_left_cesoir_maintenant.ToString & " top = " & _
                             val_top_ce_soir(i).ToString & " text= " & tableau_list_emissions_ce_soir(i).Ptitle)
#End If

            ' 17/09/2009 rvs75 si oldUI=1 dans le .config c'est un bouton sinon c'est un GradientButton
            Dim chaine As String
            chaine = tableau_list_emissions_ce_soir(i).Ptitle

            Dim box1 As New PaveCentral
            AddHandler box1.MouseDown, AddressOf Fonction_Click_Emission_ce_soir
            AddHandler box1.MouseEnter, AddressOf Mainform.PanelCeSoirEnter
            '051109AddHandler box1.MouseLeave, AddressOf Mainform.Panel_ce_soir_Leave
            With box1
                .old_UI = CBool(My.Settings.oldUI)
                .Left = val_left_cesoir_maintenant
                .Top = val_top_ce_soir(i)
                .Height = hauteur_richtextbox
                .Width = val_width_cesoir_maintenant
                If chaine.Length > 38 Then .Text = chaine.Substring(0, 35) & "..." Else .Text = chaine
                '.BackColor = val_backcolor_ce_soir(i + 1)
                .BGColor = val_backcolor_ce_soir(i + 1)
                .ForeColor = Color.Black
                '.FlatStyle = FlatStyle.Popup
                '.TextAlign = ContentAlignment.MiddleLeft
                .Align = StringAlignment.Near

            End With
            Try
                Mainform.Panel_ce_soir.Controls.Add(box1)
            Catch ex As Win32Exception
                Trace.WriteLine( _
                                 DateTime.Now & " " & "Exception lors de l'ajout de la  box n° " & i.ToString & _
                                 "  dans affect richtextbox ce_soir")
                Dim instance As New Win32Exception
                Dim value As Integer
                value = instance.NativeErrorCode
                Trace.WriteLine( _
                                 DateTime.Now & " " & "Error code = " & value.ToString & _
                                 ";  Exception message  = " & _
                                 instance.Message)
                instance = Nothing
                Application.DoEvents()
            End Try
            box1 = Nothing
            'End Select
            Application.DoEvents()
            'BB 260710
        Next i
        Mainform.Panel_ce_soir.ResumeLayout()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Sortie de affect_richtextbox_ce_soir")
#End If
    End Sub

    Public Sub Affect_Richtextbox_Maintenant()

        'rvs75 10/08/2010 remplacement des boutons par des paveActuellement
        Dim i As Integer = 0
        'Dim ii As Integer
        Mainform.Panel_maintenant.SuspendLayout()
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans Affect_Richtextbox Maintenant")
#End If

        Mainform.Panel_maintenant.Controls.Clear()

        Trace.WriteLine(DateTime.Now & " " & "paneau_maintenant.width= " & Mainform.Panel_maintenant.Width.ToString)

        Dim box2 As New Button
        With box2
            .FlatStyle = FlatStyle.Popup
            .Left = 0
            .Top = val_top_Maintenant(i)
            .Height = hauteur_richtextbox
            .Width = Mainform.Calendar.Width
            .Text = Maintenant_et_heure
            val_backcolor_Maintenant(0) = Color.LightGray
            .BackColor = val_backcolor_Maintenant(i)
            .ForeColor = Color.Black
            .TextAlign = ContentAlignment.MiddleLeft
        End With

#If DEBUG Then
        Trace.WriteLine( _
                         DateTime.Now & " " & "left = " & val_left_cesoir_maintenant.ToString & " top = " & _
                         val_top_Maintenant(0).ToString & " text= " & tableau_list_emissions_Maintenant(0).Ptitle)
#End If

        Try
            Mainform.Panel_titre_maintenant.Controls.Add(box2)
        Catch ex As Win32Exception
            Trace.WriteLine( _
                             DateTime.Now & " Exception lors de l'ajout de la  box n° " & i.ToString & _
                             "  dans affect richtextbox ce_soir")
            Dim instance As New Win32Exception
            Dim value As Integer
            value = instance.NativeErrorCode
            Trace.WriteLine(DateTime.Now & " " & "Error code = " & value.ToString)
            Trace.WriteLine(DateTime.Now & " " & "Numéro de la box ajoutée posant problème = " & i.ToString)
            Trace.WriteLine(DateTime.Now & " " & "Exception message  = " & instance.Message)
            instance = Nothing

        End Try

        box2 = Nothing
        For i = 0 To nb_emissions_for_Maintenant - 1

#If DEBUG Then
            Trace.WriteLine( _
                             DateTime.Now & " " & "left = " & val_left_cesoir_maintenant.ToString & " top = " & _
                             val_top_Maintenant(i).ToString & " text= " & tableau_list_emissions_Maintenant(i).Ptitle)
#End If
            Dim chaine As String
            chaine = tableau_list_emissions_Maintenant(i).Ptitle
            'rvs75 10/08/2010 : debut de modif
            Dim debut As DateTime = tableau_list_emissions_Maintenant(i).pstart
            Dim fin As DateTime = tableau_list_emissions_Maintenant(i).pstop

            Dim box1 As New PaveActuellement
            AddHandler box1.MouseDown, AddressOf Fonction_Click_Emission_Maintenant
            AddHandler box1.MouseEnter, AddressOf Mainform.PanelMaintenantEnter
            With box1
                .Left = val_left_cesoir_maintenant
                .Top = val_top_Maintenant(i)
                .Height = hauteur_richtextbox
                .Width = val_width_cesoir_maintenant
                If chaine.Length > 38 Then .Text = chaine.Substring(0, 35) & "..." Else .Text = chaine
                '.BackColor = val_backcolor_Maintenant(i + 1)
                .BGColor = val_backcolor_Maintenant(i + 1)
                .Align = StringAlignment.Near
                .Debut = debut
                .old_UI = CBool(My.Settings.oldUI)
                .Fin = fin
                .Initialiser()
            End With
            Try
                Mainform.Panel_maintenant.Controls.Add(box1)
            Catch ex As Win32Exception
                Trace.WriteLine( _
                                 DateTime.Now & " " & "Exception lors de l'ajout de la box n° " & i.ToString & _
                                 "  dans affect richtextbox Maintenant")
                Dim instance As New Win32Exception
                Dim value As Integer
                value = instance.NativeErrorCode
                Trace.WriteLine(DateTime.Now & " " & "Error code = " & value.ToString)
                instance = Nothing
            End Try
            box1 = Nothing
        Next i
    End Sub

    Friend Sub Mouse_Enter(ByVal sender As Object, ByVal e As EventArgs)

        Dim ctrl As Control = DirectCast(sender, Control)
        Dim txt As String = tableau_list_emissions(ctrl.TabIndex).Pdescription

        If My.Settings.ToolTipsBallon = True Then

            Select Case txt.Length
                'si le texte est supérieur à 0
                Case Is > 0
                    txt = txt.Substring(0, Math.Min(txt.Length, 80)) & "..."
                Case Else
                    'sinon affichage qu'il n'y pas d'info
                    txt = lngBallonTipsNoInformation
            End Select

            'With descTooltip
            '    .RemoveAll()
            '    .IsBalloon = True
            '    .ToolTipTitle = ctrl.Text
            '    .SetToolTip(ctrl, txt)
            'End With

            'couleur du de l'infobulle
            Dim bg As Color = ctrl.BackColor
            descTooltip.BackColor = _
                Color.FromArgb(200, Math.Min(bg.R + 35, 255), Math.Min(bg.G + 35, 255), Math.Min(bg.B + 35, 255))
        End If

        ' on va lire si l'option Slide est activée ou non
        Select Case My.Settings.Slide
            Case 1
                CType(sender, Control).Width = CType(sender, Control).Width + 100
        End Select
    End Sub

    Friend Sub Mouse_Leave(ByVal sender As Object, ByVal e As EventArgs)

        ' on va lire si l'option Slide est activée ou non
        Select Case My.Settings.Slide
            Case 1
                CType(sender, Control).Width = CType(sender, Control).Width - 100

        End Select
    End Sub

    Friend Sub Fonction_Click_Emission_ce_soir(ByVal sender As Object, ByVal e As MouseEventArgs)
        Trace.WriteLine(DateTime.Now & " " & "Fonction click emission_ce_soir")

        Dim i As Integer
        Dim z As String
        repere_click_emission = CInt(CType(sender, Control).TabIndex)
        Trace.WriteLine(DateTime.Now & " " & "Tag de l'émission = " & repere_click_emission.ToString)

        ' Bouton gauche de la souris ? Néo le 11/09/09
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left

                ComposerMessageDescrip(repere_click_emission, "ce_soir")

                With Mainform
                    .PictureBoxLogo.SuspendLayout()
                    .PictureBoxLogo.Controls.Clear()
                End With

                ' il faut rechercher le nom de la chaine à partir de ChannelID
                For i = 1 To nb_total_chaines
                    z = tableau_chaine(i).identificateur
                    If z = s_chid Then
                        Exit For
                    End If
                Next i

                nom_fichier = tableau_chaine(i).logo

                With Mainform
                    .DrawLogoInPictureboxlogo(nom_fichier)
                    .PictureBoxLogo.ResumeLayout()
                End With

                ' Bouton gauche de la souris ? si oui y a t'il eu + de 1 clics Néo le 11/09/09
                'rvs75 : 27/10/2010 : ne lance la recherche d'information sur le programme que si on est en mode connecté
                If Not (isOffline) AndAlso e.Clicks > 1 Then
                    If My.Settings.EngineShow = True Then
                        EngineSelection.ShowDialog()
                    End If

                    ' Si double click sur un Film/série on recherche dans TheTVDB.com, IMDb.com
                    ' et on affiche dans le navigateur internet la/les fiches dispos
                    Try
                        If My.Settings.EngineSelection = 1 Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.IMDb.com") Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans ce soir pour TVDB.com")
                                ThetvdbName = s_titre
                                SeriesBrowser.ShowDialog()
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & _
                                                 s_titre & " dans TVBD.Com")
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche TVBD.com
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 2 Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.imdb.com") Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans ce soir pour IMDb.com")

                                If My.Settings.Language = "Français" Then
                                    Process.Start("http://www.imdb.fr/find?q=" & s_titre)
                                Else
                                    Process.Start("http://www.imdb.com/find?q=" & s_titre)
                                End If

                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & _
                                                 s_titre & " dans IMDB.Com")

                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche IMDb.Com
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 3 AndAlso My.Settings.Language = "Français" Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.allocine.fr") _
                                Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans ce soir pour Allocine.fr")
                                Process.Start("http://www.allocine.fr/recherche/?q=" & s_titre)
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & _
                                                 s_titre & " dans Allocine.fr")
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche allocine.fr
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 3 AndAlso My.Settings.Language <> "Français" Then
                            If _
                                                               IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.screenrush.co.uk/") Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans dans ce soir pour Screenrush.co.uk")
                                Process.Start("http://www.screenrush.co.uk/recherche/?motcle=" & s_titre)
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & _
                                                 s_titre & " dans Screenrush.co.uk")
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche Screenrush.co.uk
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                    Catch ex As Exception

                        Dim BoxNoConnection As DialogResult
                        BoxNoConnection = _
                            MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                             MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                             MessageBoxIcon.Exclamation)
                    End Try
                End If
        End Select
    End Sub

    Friend Sub Fonction_Click_Emission_Maintenant(ByVal sender As Object, ByVal e As MouseEventArgs)
        Trace.WriteLine(DateTime.Now & " " & "Fonction click emission_Maintenant")

        Dim i As Integer
        Dim z As String
        repere_click_emission = CInt(CType(sender, Control).TabIndex)
        Trace.WriteLine(DateTime.Now & " " & "Tag de l'émission = " & repere_click_emission.ToString)

        ' Bouton gauche de la souris ? Néo le 11/09/09
        Select Case e.Button
            Case System.Windows.Forms.MouseButtons.Left

                ComposerMessageDescrip(repere_click_emission, "maintenant")

                With Mainform
                    .PictureBoxLogo.SuspendLayout()
                    .PictureBoxLogo.Controls.Clear()
                End With

                ' il faut rechercher le nom de la chaine à partir de ChannelID
                For i = 1 To nb_total_chaines
                    z = tableau_chaine(i).identificateur
                    If z = s_chid Then
                        Exit For
                    End If
                Next i

                nom_fichier = tableau_chaine(i).logo

                With Mainform
                    .DrawLogoInPictureboxlogo(nom_fichier)
                    .PictureBoxLogo.ResumeLayout()
                End With

                ' Bouton gauche de la souris ? si oui y a t'il eu plus de 1 clic Néo le 11/09/09
                'rvs75 : 27/10/2010 : ne lance la recherche d'information sur le programme que si on est en mode connecté
                If Not (isOffline) AndAlso e.Clicks > 1 Then
                    If My.Settings.EngineShow = True Then
                        EngineSelection.ShowDialog()
                    End If

                    ' Si double click sur un Film/série on recherche dans TheTVDB.com, IMDB
                    ' et on affiche dans le navigateur internet la/les fiches dispos
                    Try
                        If My.Settings.EngineSelection = 1 Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.thetvdb.com") _
                                Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans maintenant")
                                ThetvdbName = s_titre
                                SeriesBrowser.ShowDialog()
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & _
                                                 s_titre & " dans TheTVDB.Com")
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche TheTVDB.Com
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 2 Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.imdb.com") Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans maintenant pour IMDb.com")

                                If My.Settings.Language = "Français" Then
                                    Process.Start("http://www.imdb.fr/find?q=" & s_titre)
                                Else
                                    Process.Start("http://www.imdb.com/find?q=" & s_titre)
                                End If

                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & _
                                                 s_titre & " dans IMDB.Com")

                            Else
                                ' •———————————————————————————————————————————————————————————————————————————————•
                                ' | Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher   |
                                ' | la fiche IMDb.Com                                                             |
                                ' •———————————————————————————————————————————————————————————————————————————————•
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 3 AndAlso My.Settings.Language = "Français" Then
                            If IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.allocine.fr") _
                                Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans maintenant pour Allocine.fr")
                                Process.Start("http://www.allocine.fr/recherche/?q=" & s_titre)
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & _
                                                 s_titre & " dans Allocine.fr")
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche allocine.fr
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                        If My.Settings.EngineSelection = 3 AndAlso My.Settings.Language <> "Français" Then
                            If _
                                IsNetConnectOnline() AndAlso ConnectionAvailable("http://www.screenrush.co.uk/") Then
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & _
                                                 "Un double click gauche a été effectué dans maintenant pour Screenrush.co.uk")
                                Process.Start("http://www.screenrush.co.uk/recherche/?motcle=" & s_titre)
                                Trace.WriteLine( _
                                                 DateTime.Now & " " & "On vient d'afficher la fiche du Film/série " & _
                                                 s_titre & " dans Screenrush.co.uk")
                            Else

                                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour afficher
                                ' la fiche Screenrush.co.uk
                                Dim BoxNoConnection As DialogResult
                                BoxNoConnection = _
                                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Exclamation)
                            End If
                        End If

                    Catch ex As Exception

                        Dim BoxNoConnection As DialogResult
                        BoxNoConnection = _
                            MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                             MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                             MessageBoxIcon.Exclamation)
                    End Try
                End If
        End Select
    End Sub

    Public Sub ComposerMessageDescrip(ByVal repere As Integer, ByVal quiAppel As String)

        Try

            'recuperation des donnees de l'émission selon le tableau et le repere
            Dim detailEmission As Emissions_List = Nothing
            Select Case quiAppel
                Case "principale"
                    detailEmission = tableau_list_emissions(repere)
                Case "ce_soir"
                    detailEmission = tableau_list_emissions_ce_soir(repere)
                Case "maintenant"
                    detailEmission = tableau_list_emissions_Maintenant(repere)
            End Select

            'sert à afficher le logo de la chaine
            s_chid = detailEmission.ChannelID
            s_titre = detailEmission.Ptitle
            With Mainform.RichTextBoxDescrip
                .SuspendLayout()

                'le titre
                .Text = detailEmission.Ptitle
                .Select(0, .Text.Length)
                .SetSelectionSize(14)
                .SetSelectionBold(True)
                .SetSelectionFont("Microsoft sans Serif")

                'le soustitre
                If detailEmission.Psubtitle.Length > 0 Then
                    Dim stitre As String = " (" & detailEmission.Psubtitle & ") "
                    If stitre.Length <> 3 Then
                        .AppendText(stitre)
                        .Select(.Text.Length - stitre.Length + 1, stitre.Length)
                        .SetSelectionSize(10)
                        .SetSelectionBold(False)
                        .SetSelectionFont("Microsoft sans Serif")
                    End If
                Else
                    .AppendText(" ")
                End If

                'la signaletique 

                'signaletique age
                If Not (Not detailEmission.prating Is Nothing AndAlso String.IsNullOrEmpty(detailEmission.prating)) Then ' Copie l'image dans le presse-papier
                    Dim pb As PictureBox = New PictureBox
                    Dim age As Match = Regex.Match(detailEmission.prating, "(\b[0-9]{1,2}\b)")
                    Dim intage As Integer
                    If Integer.TryParse("-" & age.ToString, intage) Then
                        With pb
                            .SizeMode = PictureBoxSizeMode.Zoom
                            .Size = New Size(20, 20)
                            .BackColor = Color.White
                            Select Case intage
                                Case -10
                                    .Image = My.Resources._10
                                Case -12
                                    .Image = My.Resources._12
                                Case -16
                                    .Image = My.Resources._16
                                Case -18
                                    .Image = My.Resources._18
                                Case Else
                            End Select
                        End With
                        .InsertControl(pb)

                    End If
                End If

                'signaletique stereo
                'If detail_emission.Audiostereo = "stereo" Then
                'Dim pb As New PictureBox()
                'With pb
                '.SizeMode = PictureBoxSizeMode.Zoom
                '.Size = New Size(20, 20)
                '.BackColor = Color.White
                '.Image = My.Resources.stereo
                'End With
                '.InsertControl(pb)
                'pb = Nothing
                'End If

                'signaletique première
                If detailEmission.Premiere = 1 Then

                    Dim pb As New PictureBox()
                    With pb
                        .SizeMode = PictureBoxSizeMode.Zoom
                        .Size = New Size(20, 20)
                        .BackColor = Color.White
                        .Image = My.Resources.premiere
                    End With
                    .InsertControl(pb)
                End If

                'saut de ligne
                .AppendText(Environment.NewLine)

                ' start et stop
                Dim startstop As String = RichTextBoxDescripDate

                .AppendText(startstop)
                .Select(.Text.Length - startstop.Length, startstop.Length)
                .SetSelectionSize(10)
                .SetSelectionBold(True)
                .SetSelectionFont("Microsoft sans Serif")

                Dim _
                    sstart As String = DateLangue(detailEmission.pstart.AddHours(decal_horaire)) & " " & _
                                       RichTextBoxDescripFrom & " " & _
                                       detailEmission.pstart.AddHours(decal_horaire).ToString("HH:mm")
                Dim _
                    sstop As String = " " & RichTextBoxDescripTo & " " & _
                                      detailEmission.pstop.AddHours(decal_horaire).ToString("HH:mm")
                Dim debutfin As String = sstart & sstop
                .AppendText(debutfin)
                .Select(.Text.Length - debutfin.Length, debutfin.Length)
                .SetSelectionSize(10)
                .SetSelectionBold(False)
                .SetSelectionFont("Microsoft sans Serif")

                'On ajoute un séparateur
                Dim separator1 As New PictureBox()
                With separator1
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .Size = New Size(14, 14)
                    .BackColor = Color.White
                    .Image = My.Resources.separator
                End With
                .InsertControl(separator1)

                'durée
                Dim dureeenminute As String = RichTextBoxDescripDuree
                .AppendText(dureeenminute)
                .Select(.Text.Length - dureeenminute.Length, dureeenminute.Length)
                .SetSelectionSize(10)
                .SetSelectionBold(True)
                .SetSelectionFont("Microsoft sans Serif")

                Dim duree As String = (detailEmission.Pduration).ToString & " minutes"
                .AppendText(duree)
                .Select(.Text.Length - duree.Length, duree.Length)
                .SetSelectionSize(10)
                .SetSelectionBold(False)
                .SetSelectionFont("Microsoft sans Serif")

                'saut de ligne
                .AppendText(Environment.NewLine)

                'Catégorie A AFFICHER QUE SI DIFFERENT DE ""
                If Not (Not detailEmission.PcategoryTV.ToString Is Nothing AndAlso String.IsNullOrEmpty(detailEmission.PcategoryTV.ToString)) Then

                    Dim categorie As String = RichTextBoxDescripCategory

                    .AppendText(categorie)
                    .Select(.Text.Length - categorie.Length, categorie.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(True)
                    .SetSelectionFont("Microsoft sans Serif")

                    ' On passe la 1ère lettre de la catégorie en majuscule  
                    detailEmission.PcategoryTV = StrConv(detailEmission.PcategoryTV, vbProperCase)

                    Dim category As String = detailEmission.PcategoryTV

                    .AppendText(category)
                    .Select(.Text.Length - category.Length, category.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(False)
                    .SetSelectionFont("Microsoft sans Serif")
                Else
                    .AppendText(" ")
                End If

                'Sous-catégorie (genre) A AFFICHER QUE SI DIFFERENT DE ""
                If Not (Not detailEmission.Pcategory.ToString Is Nothing AndAlso String.IsNullOrEmpty(detailEmission.Pcategory.ToString)) Then

                    'On ajoute un séparateur
                    Dim separator As New PictureBox()
                    With separator
                        .SizeMode = PictureBoxSizeMode.CenterImage
                        .Size = New Size(14, 14)
                        .BackColor = Color.White
                        .Image = My.Resources.separator
                    End With
                    .InsertControl(separator)

                    Dim categorie As String = RichTextBoxDescripGenre

                    .AppendText(categorie)
                    .Select(.Text.Length - categorie.Length, categorie.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(True)
                    .SetSelectionFont("Microsoft sans Serif")

                    ' On passe la 1ère lettre de la catégorie en majuscule  
                    detailEmission.Pcategory = StrConv(detailEmission.Pcategory, vbProperCase)

                    Dim category As String = detailEmission.Pcategory

                    If category.Contains("/") Then
                        ' On retire le dernier "/" à droite
                        Dim separation As Integer = InStrRev(category, "/")
                        category = LSet(category, separation - 1)
                    End If

                    If category.Contains("/") Then
                        ' On retire les caractères à gauche de "/"
                        Dim longueur As Integer
                        Dim separation As Integer = InStr(category, "/")
                        longueur = Len(category) - separation
                        category = category.Substring(separation, longueur)
                    End If

                    If category.Contains("/") Then
                        ' On retire les caractères à droite de "/"
                        Dim longueur As Integer
                        Dim separation As Integer = InStrRev(category, "/")
                        longueur = Len(category) - separation
                        category = category.Substring(separation, longueur)
                    End If

                    .AppendText(category)
                    .Select(.Text.Length - category.Length, category.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(False)
                    .SetSelectionFont("Microsoft sans Serif")

                Else
                    .AppendText(" ")
                End If

                'Date de production  A AFFICHER QUE SI DIFFERENT DE ""
                If Not (Not detailEmission.Pdate.ToString Is Nothing AndAlso String.IsNullOrEmpty(detailEmission.Pdate.ToString)) Then

                    'On ajoute un séparateur
                    Dim separator As New PictureBox()
                    With separator
                        .SizeMode = PictureBoxSizeMode.CenterImage
                        .Size = New Size(14, 14)
                        .BackColor = Color.White
                        .Image = My.Resources.separator
                    End With
                    .InsertControl(separator)

                    Dim dateproduction As String = RichTextBoxDescripProductionDate

                    .AppendText(dateproduction)
                    .Select(.Text.Length - dateproduction.Length, dateproduction.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(True)
                    .SetSelectionFont("Microsoft sans Serif")

                    Dim firstair As String = detailEmission.Pdate

                    ' Néo 28/08/2010 ajout pour compatibilité date de production
                    If Len(firstair) = 8 Then
                        firstair = LSet(firstair, 4)
                    End If

                    .AppendText(firstair)
                    .Select(.Text.Length - firstair.Length, firstair.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(False)
                    .SetSelectionFont("Microsoft sans Serif")
                Else
                    .AppendText("")
                End If

                'Showview A AFFICHER QUE SI DIFFERENT DE ""
                If Not (Not detailEmission.Showview.ToString Is Nothing AndAlso String.IsNullOrEmpty(detailEmission.Showview.ToString)) Then

                    'On ajoute un séparateur
                    Dim separator As New PictureBox()
                    With separator
                        .SizeMode = PictureBoxSizeMode.CenterImage
                        .Size = New Size(14, 14)
                        .BackColor = Color.White
                        .Image = My.Resources.separator
                    End With
                    .InsertControl(separator)

                    Dim numeroshowview As String = RichTextBoxDescripShowView
                    .AppendText(numeroshowview)
                    .Select(.Text.Length - numeroshowview.Length, numeroshowview.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(True)
                    .SetSelectionFont("Microsoft sans Serif")

                    Dim showview As String = detailEmission.Showview
                    .AppendText(showview)
                    .Select(.Text.Length - showview.Length, showview.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(False)
                    .SetSelectionFont("Microsoft sans Serif")
                End If

                'saut de ligne
                .AppendText(Environment.NewLine)

                'Acteurs
                If detailEmission.Pactors.Length > 0 Then
                    'libelle acteur
                    Dim libelleacteur As String = RichTextBoxDescripActors
                    .AppendText(libelleacteur)
                    .Select(.Text.Length - libelleacteur.Length, libelleacteur.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(True)
                    .SetSelectionFont("Microsoft sans Serif")

                    'liste Acteurs
                    Dim sacteur As String = detailEmission.Pactors & "."

                    If sacteur.Contains("/") Then
                        'On supprime le 1er / dans la chaine acteur sacteur
                        sacteur = sacteur.Remove(0, 1)

                        'On remplace les / suivant par , dans la chaine sacteur
                        sacteur = sacteur.Replace("/", ", ")
                    End If

                    .AppendText(sacteur)
                    .Select(.Text.Length - sacteur.Length, sacteur.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(False)
                    .SetSelectionFont("Microsoft sans Serif")

                    'saut de ligne
                    .AppendText(Environment.NewLine)
                End If

                'description
                If detailEmission.Pdescription.Length > 0 Then

                    'libelle Description
                    Dim libelledascription As String = RichTextBoxDescripDescrip
                    .AppendText(libelledascription)
                    .Select(.Text.Length - libelledascription.Length, libelledascription.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(True)
                    .SetSelectionFont("Microsoft sans Serif")

                    'description
                    Dim sdescription As String = detailEmission.Pdescription
                    .AppendText(sdescription)
                    .Select(.Text.Length - sdescription.Length, sdescription.Length)
                    .SetSelectionSize(10)
                    .SetSelectionBold(False)
                    .SetSelectionFont("Microsoft sans Serif")
                End If
                .SelectionStart = 0
                .DeselectAll()
                .ResumeLayout()
            End With

            ' Néo 20/04/2013
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now & " " & "Problème! sortie de ComposerMessageDescrip" & ex.ToString())
            Trace.WriteLine(DateTime.Now & " " & "Repère :" & repere & "quiappel :" & quiAppel)
            Return
        End Try

    End Sub

    Public Sub Curseur_Vertical()
        'rvs75 18/08/2010 : réécriture du curseur
        Dim ii As Integer
        Dim tps2 As TimeSpan = DateTime.Now.Subtract(date_reference)
        Dim double_p As Double = (1440 * tps2.Days + 60 * tps2.Hours + tps2.Minutes) - (decal_horaire * 60)

        ' converti en minutes
        If double_p < 0 Then
            double_p = 0
        End If

        ii = CInt(Math.Truncate(double_p * nb_pixels_pour_30_minutes / 30))

        'essai de récuperer le curseur s'il existe
        'si on peut, alors on le deplace
        'sinon on créé le curseur dans le catch
        'Try
        If Mainform.Controls.Find("curseur", True).Length > 0 Then
            Dim leCurseur As curseur = DirectCast(Mainform.Controls.Find("curseur", True)(0), curseur)
            leCurseur.Left = ii
            'Catch
        Else
            Dim box1 As New curseur
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
                instance = Nothing
            End Try
            box1 = Nothing
        End If
        'End Try
        Mainform.Controls.Find("curseur", True)(0).BringToFront()
    End Sub

    Public Sub Calcul_Des_Bolded_Dates()

        ' Calcul des dates en Gras dans le calendrier
        Trace.WriteLine(DateTime.Now & " " & "bolded dates")
        qw_on_channels = "SELECT min(Pstart) FROM Programtbl"
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        Dim dt_on_channels As DataTable
        dt_on_channels = db.ExecuteQuery(qw_on_channels)
#If DEBUG Then
        Trace.WriteLine(DateTime.Now & " " & qw_on_channels)
#End If
#If DEBUG Then
        '                    Trace.WriteLine(datetime.now & " " & "Problème d'ouverture de la BD db_progs.db3 : chemin ou existence")
#End If
        Dim record As New Emissions_List
        Try
            Try
                first_date_with_data = CDate(dt_on_channels.Rows(0).Item(0))
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & "fichier xml detecté corrompu dans bolded dates")

                ' si maj automatique annonce qu elle a echoue et quelle aura lieu plus tard
                ' remttre l ancienne bdd et mettre flag comme quoi la derniere mise ajour a eu lieu ????
                Miseajour.CopierFichier(BDDPath & "db_progs.bak", BDDPath & "db_progs.db3", True)

                ' si probleme eviter de revenir sur un mauvais lien
                With Mainform
                    .tl.Close()
                    .Timer_wait.Start()
                    .Timer_wait.Enabled = True
                    .AppliRestart = True
                End With
            End Try

        Catch ex As NullReferenceException

            Trace.WriteLine(DateTime.Now & " Null reference exception error " & ex.Message)
            ex = Nothing
#If DEBUG Then
            Trace.WriteLine(DateTime.Now & " " & "Non respect des types de données dans db_progs.db3")
#End If
        End Try

        ' pour les dates comprises entre first_date_with_data et last_date_with_data
        ' c est a dire les dates pour lesuelles il y a des emissions presentes,
        ' mettre en gras ces dates en question dans le monthcalendar
        Trace.WriteLine(DateTime.Now & " " & "Premières données commençant le : " & first_date_with_data.ToString)
        qw_on_channels = "SELECT max(Pstart) FROM Programtbl"
        qw_on_channels = "SELECT max(Pstop) FROM Programtbl"
        ' 160210
        Trace.WriteLine(DateTime.Now & " " & qw_on_channels)
        dt_on_channels = db.ExecuteQuery(qw_on_channels)
        db.CloseDatabase()
        db = Nothing
        Try
            Try
                last_date_with_data = CDate(dt_on_channels.Rows(0).Item(0))
            Catch ex As Exception
                Trace.WriteLine(DateTime.Now & " " & "fichier xml corrompu detcté dans bollded dates")
            End Try

        Catch ex As NullReferenceException

            Trace.WriteLine(DateTime.Now & " Null reference exception error " & ex.Message)
            Trace.WriteLine(DateTime.Now & " " & "Non respect des types de données dans db_progs.db3")
            ex = Nothing
        End Try
        Trace.WriteLine(DateTime.Now & " " & "Dernières données de la BDD le : " & last_date_with_data.ToString)
        For I As Integer = 0 To 20

            ' 20 > nbre de jours de data dans la database
            Dim date1 As New DateTime
            date1 = first_date_with_data.AddDays(I)
            If last_date_with_data < date1 Then
                Exit For
            End If
            JourActif.Ajoute(date1)
        Next I
        JourActif.Ajoute(last_date_with_data)

        indice_courant_TLE = 1
    End Sub

    Friend Sub ShowJournee(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim reperelogo As Integer = CInt(CType(sender, Control).TabIndex)
        IdentifiantLogo = tableau_chaine(reperelogo).identificateur
        ChannelView.ShowDialog()
    End Sub
End Class