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
Imports TvdbLib.Data

Friend Module Variables
    Public Structure FileToDownload
        Public url As String
        Public path As String

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure
    Public imageListSmall As New ImageList()
    'Public chaine_marquee As String
    Public Structure channel_list
        Public nom As String
        Public identificateur As String
        Public indice As Integer
        Public logo As String

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Public Structure Emissions_List
        Public ChannelID As String
        Public Ptitle As String
        Public Psubtitle As String
        Public pstart As DateTime
        Public pstop As DateTime
        Public Pduration As Integer
        Public Pcategory As String
        Public PcategoryTV As String
        Public Pdescription As String
        Public prating As String
        Public Pactors As String
        Public Audiostereo As String
        Public Premiere As Integer
        Public Showview As String
        Public Subtype As String
        Public Pdate As String

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Public Structure AffichagePanelA
        Public debutEmission As Integer
        Public emissionVisible As Integer
        Public emissionNonvisible As Integer

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    'rvs75 : 27/10/2010 variable pour savoir si offline
    Public isOffline As Boolean
    Public decal_horaire As Integer
    Public collectionImagesListViewChannel As New Collection
    'Public collectionImagesListViewCesoir As New Collection
    'Public panel_droit As New Panel
    Public fichier_log_activé As Boolean

    Public date_reference As DateTime '310110= CDate(DateTime.Now.AddHours(decal_horaire).ToString("dd/M/yyyy HH:00:00"))
    Public IdentifiantLogo As String = ""
    'rvs le 15/12/09
    ' minuit du jour de demarrage du programme ou minuit des data à partir duquel
    ' il faut recharger les nouvelles data

    Public reserve_depart As Integer
    Public reserve As Integer
    'Public mdbsource As String = "db_progs.db3"
    'Public jetstring As String = "Provider=Microsoft.jet.OLEDB.4.0;data source="
    Public AppPath As String

    'Private RichTextBoxEx As Object
    Public dDateSelection As Date
    Public g_Date As Date
    'Public sOChamp As String
    'Public d_DateSelectionnée As Date
    Public synth_boutons As Integer = 0

    ' configuration initiale des 3 bits
    ' de positionnement des bouttons 1, gauche et droit
    Public bdpad As Boolean = False
    ' bouton droit positionné a droite
    Public bgpad As Boolean = False
    ' True ' bouton gauche positionnné a droite
    Public bb1peh As Boolean = True
    ' bouton bas 1 positionné en haut
    Public b1pad As Boolean = False
    ' True bouton 1 positionné a droite
    Public l1 As Integer
    ' treeview1.width
    Public l2 As Integer
    'listview_channel.width

    Public l3 As Integer '  calendar.width
    'Public ecart_max As Integer
    Public increment As Integer = 1
    Public jour_semaine() As String = {"Di", "Lu", "Ma", "Me", "Je", "Ve", "Sa"}
    Public num_emission_visible As Integer
    Public nom_fichier_logo As String
    Public date_z As New DateTime
    Public tab_premiere_emission_non_visible(300) As Integer
    'Public tab_premiere_emission_visible(200) As Integer
    Public periodicite_verticale As Integer

    ' hauteur d émission + espace entre emission

    Public moment_souhaite As New DateTime
    ' c est la datetime
    ' des données représentées juste à droite de button gauche

    Public deplacement_panelA_en_pixels As Integer
    Public hauteur_barre_menus As Integer

    ' calculé dans caracteristiques_ecran
    Public hauteur_barre_outils As Integer
    ' idem

    Public num_chaine_haut_ecran As Integer = 1
    'Public nbre_d_emissions_a_afficher As Integer
    Public largeur_vide As Integer
    Public hauteur_paves As Integer
    Public largeur_pave_temps As Integer
    'Public num_de_la_chaine_avant_celle_a_afficher As Integer = 0
    'Public premiere_emission_a_afficher As Integer = 1
    Public categorie_choisie As String
    Public reduced_listviewchannel_width As Integer = largeur_logo_adaptee + 30
    Public largeur_ecran As Integer
    Public hauteur_ecran As Integer
    Public largeur_max_panelA As Integer
    Public longueur_segment As Integer
    Public panelA_point_width_max As Integer
    'Public memo_button_droit_point_left As Integer
    'Public memo_button_1_point_left As Integer
    'Public memo_button_gauche_point_left As Integer
    'Public first_button_click As Boolean = True

    Public largeur_boutons_verticaux As Integer = 10

    ' possibilite d'en faire un paramètre personamlisé)
    Public sortie_filtre_entendue As Boolean = My.Settings.Cacher_Filtre
    Public hauteur_taskbar As Long
    Public stop_timer As Boolean = False
    Public filtre_non_autorise As Boolean
    Public major_haut_richtextboxdescrip As Integer = 75
    Public erreurh As Integer = 0
    'difference entre taille du mainform(1288) et de l ecran(1280)
    'via me.size.width
    Public erreurv As Integer = 0
    ' definition similaire à erreurh 

    Public emission_duration_maintenant As Integer
    Public emission_duration_cesoir As Integer
    ' duree minimale d'une émission pour être prise en compte
    ' dans ce_soir ou maintenant

    Public hauteur_mainform As Integer
    Public largeur_mainform As Integer
    Public nb_max_scroll_ce_soir As Integer
    Public compteur_scroll_ce_soir As Integer
    Public DATETIMENOW As String
    Public JourActif As New calendrier

    'Public SwitchVal As Boolean
    ' effet flash sur la StatusStrip

    Public fin_initialize As Boolean = False

    ' Les 2 tableaux qui suivent contiennet un nombre de pixels
    ' L'indice de 0 à 7 represente une configuration des 3 bits
    ' (boutons gauche, droit et button1)
    ' Ces pixels sont respectivement les pixels à gauche de bouton_gauche.right,
    ' a droite de bouton_droit.left et la somme des 2
    ' cette somme, deduite de largeur ecran , donne le nbre de pixels en largeur
    ' qui representent la portion d ecran reservée aux emissions.(largeur totale
    ' -inutilisé à gauche -inutilisé à droite                                                                           |

    Public bits_config As Integer = 7

    ' nb de configurations des 3 bits precisant
    ' l état des boutons verticaux..001H, 101H, 011H |

    Public inutilise_a_gauche(bits_config) As Integer
    Public inutilise_a_droite(bits_config) As Integer
    Public inutilise_total(bits_config) As Integer
    Public larg_max_panelA(bits_config) As Integer
    Public date_origine_ecran As New DateTime
    Public date_fin_ecran As New DateTime
    Public nb_emissions_for_SQL_Request As Integer
    Public indice_du_controle_curseur As Integer
    'Public connectionstring As String
    Public chemin_fichier_log As String
    Public chemin_fichier_marquage As String

    ' 'false= écraser ancien fichier
    ' true= pour ecrire en bout de fichier

    Public nb_record_limite_for_sql_request As Integer = 200

    Public val200 As Integer = 200

    Public taille_TLE As Integer = 4000
    '8000
    Public nb_total_chaines As Integer = 160
    ' compteur de nb d emissions pour toutes les chaines

    Public flag_emission_not_found As Boolean = True
    Public nb_de_periodes_de_6h As Integer
    'Public minecran As Integer = 60 * Nb_heures_LigneTemps
    ' nombre de minutes affichées a l ecran

    Public espace_entre_richtextbox As Integer = 1
    Public nb_chaines_ecran As Integer
    'Public largeur_logo As Integer = 132
    'Public hauteur_logo As Integer = 99
    ' taille en pixels des images gif des logos de chaines

    ' variables internes
    Public nom_des_chaines_memorisees As String = ""
    Public des_canaux_sont_memorises As Boolean
    Public s_chid As String

    Public compteur_controles_logo As Integer
    Public compteur_controles_richtextbox As Integer
    Public echelle1 As Double = 4

    ' à calculer dynamiquement
    Public largeur_logo_adaptee As Integer = 45
    Public hauteur_richtextbox As Integer = 30
    Public largeur_utile As Integer
    Public tri_categorie As Boolean = False
    'Public index_categorie_choisie As Integer
    'Public number_of_empty_channels As Integer
    Public nb_emissions_yc0_apres_tri_par_chaine(val200) As Integer
    Public depart_affichage As DateTime
    Public fin_affichage As New DateTime
    Public Chaine_logo_unique_ce_soir(val200) As String
    Public Chaine_logo_unique_MAintenant(val200) As String
    Public chaine_logo_unique(val200) As String
    Public table_des_chaines_a_selectionner(val200) As String
    Public tableau_chaine(val200) As channel_list
    Public nb_total_type_emission As Integer
    ' pour les 9 jours de data
    Public nb_maxi_type_emission As Integer = 100
    Public Tableau_Type_Emission_fran_var(nb_maxi_type_emission) As String
    Public statusstrip_calendar_wait As Boolean

    ' a remplir dynamiquement avec contenu de db
    ' film....journal... serie...

    Public first_date_with_data As New DateTime
    Public last_date_with_data As New DateTime
    Public nombre_de_chaines_differentes As Integer

    Public Maintenant_et_heure As String = "Maintenant"
    'Public val_left_ce_soir(val200) As Integer
    Public val_top_ce_soir(val200) As Integer
    'Public val_width_ce_soir(val200) As Integer
    Public val_backcolor_ce_soir(val200) As Color
    'Public val_left_Maintenant(val200) As Integer
    Public val_top_Maintenant(val200) As Integer
    'Public val_width_Maintenant(val200) As Integer
    Public val_backcolor_Maintenant(val200) As Color
    Public nb_lignes_ce_soir As Integer
    'rvs75 11/08/2010 : remplancement des tableau d'integer val_left_ce_soir, val_left_Maintenant, val_width_ce_soir, val_width_Maintenant
    'par deux varible globale
    Public val_left_cesoir_maintenant As Integer
    Public val_width_cesoir_maintenant As Integer

    Public str_sql_Maintenant As String
    Public nb_emissions_for_Maintenant As Integer
    'Public tableau_list_emissions_ce_soir(val200) As ce_soir
    'Public tableau_list_emissions_Maintenant(val200) As ce_soir
    Public tableau_list_emissions_ce_soir(val200) As Emissions_List
    Public tableau_list_emissions_Maintenant(val200) As Emissions_List

    Public nb_emissions_for_ce_soir As Integer
    Public str_sql_ce_soir As String
    Public nb_emissions_par_chaine(600) As Integer
    Public ord_top_ligne(nb_record_limite_for_sql_request) As Integer
    Public qw_on_channels As String

    Public tableau_list_emissions(taille_TLE) As Emissions_List
    Public val_left(nb_record_limite_for_sql_request) As Integer
    Public val_top(nb_record_limite_for_sql_request) As Integer
    Public val_width(nb_record_limite_for_sql_request) As Integer
    Public val_backcolor(nb_record_limite_for_sql_request) As Color
    Public val_top_logo(nb_record_limite_for_sql_request) As Integer
    Public indice_courant_TLE As Integer = 1

    'Public Language As String = "english"

    'Public Channels_All As Collection
    ' toutes les chaines disponibles

    Public arrayOnechannel(2) As String
    '{ChannelID, ChannelName, LogoFilename}

    ' Programme
    Public PIndex As Int32 = 1
    'Public PCount As Int32 = 1
    Public pDiff As Int32 = 0
    Public pStart_A As String
    Public pStop_A As String
    Public pDuration As Int32 = 0
    Public PCountry As String = ""
    Public pShowview_A As String = ""
    Public pChannel_A As String = ""
    Public pClumpidx_A As String = ""
    Public pPdcStart_A As String = ""
    Public pVpsStart_A As String = ""
    Public pVideoplus_A As String = ""
    Public pTitle As String = ""
    Public pSubTitle As String = ""
    Public pDescription As String = ""
    Public pCredits As String = ""
    Public pActor As String = ""
    Public pDirector As String = ""
    Public pWriter As String = ""
    Public pAdapter As String = ""
    Public PPresent As String = ""
    Public PRating As String = ""
    Public pIconRating As String = ""
    Public PStarRating As String = ""
    ' 
    Public pStarIconRating As String = ""
    Public pPremiere As Integer = 0
    Public pVideoAspect As String = ""
    Public PVideoColor As Boolean = True
    Public PAudioStereo As String = ""
    Public PSubType As Integer = 0
    Public PLanguage As String = ""
    Public pDate As String = ""
    Public pCategory As String = ""
    Public pCategoryTV As String = ""
    Public PReview As String = ""
    Public textAttrib As String = ""
    Public CoordY_Ligne_Temps As Long
    'Public Top_LigneTemp As Long
    Public Longueur_Ligne_Temp As Integer
    Public nb_pixels_pour_30_minutes As Decimal
    Public Nb_heures_LigneTemps As Integer = 6

    Public AppData As String
    Public LogosPath As String
    Public BDDPath As String
    Public SettingsPath As String
    Public TempPath As String
    Public UnZipPath As String
    Public LogPath As String
    Public UrlPath As String
    Public ChannelSetPath As String
    Public MarqueesPath As String
    Public wavepath As String

    Public EmmissionSel As Emissions_List
    'Public timer11 As New Stopwatch
    Public XmlTvName As String
    Public FichierProgramme As String = AppData & "prog.XML"
    Public maj_auto_flag As Boolean = False

    Public BalloonText1 As String
    Public BalloonText3 As String

    Public ExceptError As String

    ' Variable contenant le Path vers user.config
    Public Local As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)

    Public ThetvdbName As String
    Public ThetvdbLanguage As TvdbLanguage

    Public MediaPath As String = Application.StartupPath.ToString & "\Media\"

    'Public BoxMiseaJour As DialogResult

    'Public Function decrypt(ByVal strInput As String) As String
    '    Dim n As Integer
    '    Dim i As Integer
    '    n = 13
    '    For i = 1 To strInput.Length
    '        Mid(strInput, i, 1) = Chr(Asc(strInput.Substring(i - 1, 1)) - n)
    '    Next i
    '    Return strInput
    'End Function

    'Public Function encrypt(ByVal strInput As String) As String
    '    Dim n As Integer
    '    Dim i As Integer
    '    n = 13
    '    For i = 1 To strInput.Length
    '        Mid(strInput, i, 1) = Chr(Asc(strInput.Substring(i - 1, 1)) + n)
    '    Next i
    '    Return strInput
    'End Function
End Module
