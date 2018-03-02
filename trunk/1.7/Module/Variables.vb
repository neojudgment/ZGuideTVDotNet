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
Imports TvdbLib.Data

' ReSharper disable CheckNamespace
Public Module Variables
    ' ReSharper restore CheckNamespace

    Public ReadOnly ImageListSmall As New ImageList() 'scope trop grand, à déplacer dans Miseajour
    'Public chaine_marquee As String
    Public Structure ChannelList
        Public Nom As String
        Public Identificateur As String
        Public Indice As Integer
        Public Logo As String

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Public Structure EmissionsList
        Public ChannelId As String
        Public Ptitle As String
        Public Psubtitle As String
        Public Pstart As DateTime
        Public Pstop As DateTime
        Public Pduration As Integer
        Public Pcategory As String
        Public PcategoryTv As String
        'Public CouleurCategoryTV As Integer
        Public Pdescription As String
        Public Prating As String
        Public Pactors As String
        Public Pdirector As String 'ajout pour popup 13/11/2013
        Public PPresentateur As String 'ajout pour popup 19/11/2013
        Public Audiostereo As String 'assigné mais plus utilisé au 30/10/2013
        Public Premiere As Integer 'assigné mais plus utilisé au 30/10/2013
        Public Showview As String
        Public Subtype As String 'assigné mais plus utilisé au 30/10/2013
        Public Pdate As String

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            If obj Is Nothing Then
                Return False
            End If
            Throw New NotImplementedException()
        End Function
    End Structure

    Public Structure AffichagePanelA
        Public DebutEmission As Integer
        Public EmissionVisible As Integer
        Public EmissionNonvisible As Integer

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    'rvs75 : 27/10/2010 variable pour savoir si offline
    Public IsOffline As Boolean
    Public DecalHoraire As Integer

    Public DateReference As DateTime '310110= CDate(DateTime.Now.AddHours(decal_horaire).ToString("dd/M/yyyy HH:00:00"))
    Public IdentifiantLogo As String = ""
    Public DateTimeEmission As DateTime '= Nothing
    'rvs le 15/12/09
    ' minuit du jour de demarrage du programme ou minuit des data à partir duquel
    ' il faut recharger les nouvelles data

    ' ReserveDepart As Integer
    'Public Reserve As Integer
    Public AppPath As String
    'Public DDateSelection As Date
    Public GDate As Date
    Public SynthBoutons As Integer = 0

    ' configuration initiale des 3 bits
    ' de positionnement des bouttons 1, gauche et droit
    Public Bdpad As Boolean = False
    ' bouton droit positionné a droite
    'Public Bgpad As Boolean = False
    ' True ' bouton gauche positionnné a droite
    'Public Bb1Peh As Boolean = True
    ' bouton bas 1 positionné en haut
    'Public B1Pad As Boolean = False
    ' True bouton 1 positionné a droite
    'Public L1 As Integer
    Public L2 As Integer
    'listview_channel.width

    Public L3 As Integer '  calendar.width
    Public Increment As Integer = 1
    'Public ReadOnly JourSemaine() As String = {"Di", "Lu", "Ma", "Me", "Je", "Ve", "Sa"}
    Public NomFichierLogo As String
    Public PeriodiciteVerticale As Integer

    ' hauteur d émission + espace entre emission

    Public MomentSouhaite As New DateTime
    ' c est la datetime
    ' des données représentées juste à droite de button gauche

    Public DeplacementPanelAEnPixels As Integer
    'Public HauteurBarreMenus As Integer

    ' calculé dans caracteristiques_ecran
    'Public HauteurBarreOutils As Integer
    ' idem

    Public NumChaineHautEcran As Integer = 1
    'Public LargeurVide As Integer
    Public HauteurPaves As Integer
    'Public LargeurPaveTemps As Integer
    'Public CategorieChoisie As String
    'Public ReadOnly ReducedListviewchannelWidth As Integer = LargeurLogoAdaptee + 30
    Public LargeurEcran As Integer
    'Public HauteurEcran As Integer
    'Public LargeurMaxPanelA As Integer
    Public PanelAPointWidthMax As Integer
    Public Const LargeurBoutonsVerticaux As Integer = 10

    ' possibilite d'en faire un paramètre personamlisé)
    'Public ReadOnly SortieFiltreEntendue As Boolean = My.Settings.Cacher_Filtre
    'Public HauteurTaskbar As Long
    'Public StopTimer As Boolean = False
    'Public FiltreNonAutorise As Boolean
    Public Erreurh As Integer = 0
    'difference entre taille du mainform(1288) et de l ecran(1280)
    'via me.size.width
    'Public Erreurv As Integer = 0
    ' definition similaire à erreurh 

    Public EmissionDurationMaintenant As Integer
    Public EmissionDurationCesoir As Integer
    ' duree minimale d'une émission pour être prise en compte
    ' dans ce_soir ou maintenant

    'Public HauteurMainform As Integer
    'Public LargeurMainform As Integer
    'Public NbMaxScrollCeSoir As Integer
    'Public CompteurScrollCeSoir As Integer
    'Public Datetimenow As String
    Public ReadOnly JourActif As New calendrier

    'Public SwitchVal As Boolean
    ' effet flash sur la StatusStrip

    'Public FinInitialize As Boolean = False

    ' Les 2 tableaux qui suivent contiennet un nombre de pixels
    ' L'indice de 0 à 7 represente une configuration des 3 bits
    ' (boutons gauche, droit et button1)
    ' Ces pixels sont respectivement les pixels à gauche de bouton_gauche.right,
    ' a droite de bouton_droit.left et la somme des 2
    ' cette somme, deduite de largeur ecran , donne le nbre de pixels en largeur
    ' qui representent la portion d ecran reservée aux emissions.(largeur totale
    ' -inutilisé à gauche -inutilisé à droite                                                                          

    Public Const BitsConfig As Integer = 7

    ' nb de configurations des 3 bits precisant
    ' l état des boutons verticaux..001H, 101H, 011H |

    Public InutiliseAGauche(BitsConfig) As Integer
    Public InutiliseADroite(BitsConfig) As Integer
    Public InutiliseTotal(BitsConfig) As Integer
    Public LargMaxPanelA(BitsConfig) As Integer
    Public DateOrigineEcran As New DateTime
    'Public DateFinEcran As New DateTime
    Public NbEmissionsForSqlRequest As Integer
    Public CheminFichierLog As String
    Public NbRecordLimiteForSqlRequest As Integer = 200
    Public Const Val200 As Integer = 200
    Public Const TailleTle As Integer = 4000
    Public NbTotalChaines As Integer = 160
    ' compteur de nb d emissions pour toutes les chaines

    Public NbDePeriodesDe_6H As Integer
    'Public minecran As Integer = 60 * Nb_heures_LigneTemps
    ' nombre de minutes affichées a l ecran

    Public EspaceEntreRichtextbox As Integer = 1
    Public NbChainesEcran As Integer

    ' variables internes
    'Public NomDesChainesMemorisees As String = ""
    'Public SChid As String

    'Public CompteurControlesLogo As Integer
    'Public CompteurControlesRichtextbox As Integer
    Public Echelle1 As Double = 4

    ' à calculer dynamiquement
    Public LargeurLogoAdaptee As Integer = 45
    Public HauteurRichtextbox As Integer = 30
    'Public LargeurUtile As Integer
    'Public TriCategorie As Boolean = False
    'Public index_categorie_choisie As Integer
    'Public number_of_empty_channels As Integer
    Public NbEmissionsYc0ApresTriParChaine(Val200) As Integer
    Public DepartAffichage As DateTime
    Public FinAffichage As New DateTime
    Public ChaineLogoUnique(Val200) As String
    Public TableDesChainesASelectionner(Val200) As String
    Public TableauChaine(Val200) As ChannelList
    'Public NbTotalTypeEmission As Integer
    ' pour les 9 jours de data
    Private Const NbMaxiTypeEmission As Integer = 100
    Public TableauTypeEmissionFranVar(NbMaxiTypeEmission) As String
    'Public StatusstripCalendarWait As Boolean

    ' a remplir dynamiquement avec contenu de db
    ' film....journal... serie...
    Public FirstDateWithData As New DateTime
    Public LastDateWithData As New DateTime
    Public NombreDeChainesDifferentes As Integer
    'Public MaintenantEtHeure As String = "Maintenant"
    Public ReadOnly ValTopCeSoir(Val200) As Integer
    'Public ReadOnly ValBackcolorCeSoir(Val200) As Color
    Public ReadOnly ValTopMaintenant(Val200) As Integer
    'Public ReadOnly ValBackcolorMaintenant(Val200) As Color
    Public NbLignesCeSoir As Integer
    'Public ValLeftCesoirMaintenant As Integer
    Public ValWidthCesoirMaintenant As Integer
    Public NbEmissionsForMaintenant As Integer
    Public ReadOnly TableauListEmissionsCeSoir(Val200) As EmissionsList
    Public ReadOnly TableauListEmissionsMaintenant(Val200) As EmissionsList
    Public NbEmissionsForCeSoir As Integer
    Public ReadOnly NbEmissionsParChaine(600) As Integer
    Public OrdTopLigne(NbRecordLimiteForSqlRequest) As Integer
    'Public QwOnChannels As String
    Public TableauListEmissions(TailleTle) As EmissionsList
    Public ValLeft(NbRecordLimiteForSqlRequest) As Integer
    Public ValTop(NbRecordLimiteForSqlRequest) As Integer
    Public ValWidth(NbRecordLimiteForSqlRequest) As Integer
    'Public ValBackcolor(NbRecordLimiteForSqlRequest) As Color
    Public ValTopLogo(NbRecordLimiteForSqlRequest) As Integer
    Public IndiceCourantTle As Integer = 1

    Public ArrayOnechannel(2) As String
    '{ChannelID, ChannelName, LogoFilename}

    'rvs75: 19/09/2013: n'est utilé que pour la mise à jour de la base
    'il faudrait faire structure et la passer en paramètre au lieu 
    'de d'utiliser des variables globales
    ' Programme 
    Public PIndex As Int32 = 1
    Public PDiff As Int32 = 0
    Public PStartA As String
    Public PStopA As String
    Public PDuration As Int32 = 0
    Public PCountry As String = ""
    Public PShowviewA As String = ""
    Public PChannelA As String = ""
    Public PClumpidxA As String = ""
    Public PPdcStartA As String = ""
    Public PVpsStartA As String = ""
    Public PVideoplusA As String = ""
    Public PTitle As String = ""
    Public PSubTitle As String = ""
    Public PDescription As String = ""
    Public PCredits As String = ""
    Public PActor As String = ""
    Public PDirector As String = ""
    Public PWriter As String = ""
    Public PAdapter As String = ""
    Public PPresent As String = ""
    Public PRating As String = ""
    Public PIconRating As String = ""
    Public PStarRating As String = ""
    Public PStarIconRating As String = ""
    Public PPremiere As Integer = 0
    Public PVideoAspect As String = ""
    Public PVideoColor As Boolean = True
    Public PAudioStereo As String = ""
    Public PSubType As Integer = 0
    Public PLanguage As String = ""
    Public PDate As String = ""
    Public PCategory As String = ""
    Public PCategoryTv As String = ""
    Public PReview As String = ""
    Public TextAttrib As String = ""


    'Public CoordYLigneTemps As Long
    Public LongueurLigneTemp As Integer
    Public NbPixelsPour30Minutes As Integer
    Public Const NbHeuresLigneTemps As Integer = 6
    Public AppData As String
    Public LogosPath As String
    Public BddPath As String
    Public SettingsPath As String
    Public AutoCompletePath As String
    Public TempPath As String
    'Public UnZipPath As String
    Public LogPath As String
    Public UrlPath As String
    Public ChannelSetPath As String
    Public MarqueesPath As String
    Public Wavepath As String
    Public XmlTvName As String
    Public FichierProgramme As String = AppData & "prog.XML"
    Public MajAutoFlag As Boolean = False
    Public ExceptError As String
    Public ThetvdbName As String
    <CLSCompliant(False)> Public Thetvdblanguage As TvdbLanguage
    Public ReadOnly MediaPath As String = Environment.GetEnvironmentVariable("windir") & "\Media\"

    Public Enum ObjRecherche
        ParTerme
        ParChaine
        ParCategorie
        ParHoraire
        Aucun
    End Enum
End Module
