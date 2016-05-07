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

Friend Module Language

    'variable pour la langue""
    Public Languagefile As String = ""

    'LANGUAGE
    Public lngLanguage As String
    Public lngAuthor As String
    Public lngLanguageID As String

    'SELECTLANGUAGE
    Public lngSelectLanguageButtonOK As String
    Public lngSelectLanguageButtonCancel As String

    'JUMPLIST
    Public lngSiteOfficiel As String
    Public lngForumOfficiel As String

    'PREMIERDEMARRAGE
    Public lngPremierDemarrageTitle As String
    Public lngPremierDemarrageLabelInfo As String
    Public lngPremierDemarrageGroupBoxChoixSource As String
    Public lngPremierDemarrageRadioButtonXMLTV As String
    Public lngPremierDemarrageRadioButtonEPGData As String
    Public lngPremierDemarrageGroupBoxEPGData As String
    Public lngPremierDemarrageLabelPinCode As String
    Public lngPremierDemarrageButtonSubscription As String
    Public lngPremierDemarrageLabelInfoPrice As String
    Public lngPremierDemarrageButtonOK As String
    Public lngPremierDemarrageButtonCancel As String

    'EPGDATASUBSCRIPTION
    Public lngEPGDataSubscriptionTitle As String
    Public lngEPGDataSubscriptionLabelChoixPays As String
    Public lngEPGDataSubscriptionLabelChoixLangue As String
    Public lngEPGDataSubscriptionButtonGoEPGData As String

    'PREF_TITLE
    Public lngPrefTitle As String

    'PREF_TABPAGE_GENERAL
    Public lngTabPageGeneral As String
    Public lngGroupBoxPurge As String
    Public lngGroupBoxEffects As String
    Public LngGroupBoxConfHardware As String
    Public lngGroupBoxSauvegardeFenetre As String
    Public lngGroupBoxDivers As String
    Public lngGroupBoxFiltres As String
    Public lngGroupBoxPosition As String
    Public lngCheckBoxPurge As String
    Public lngCheckBoxoldUI As String
    Public lngCheckBoxFadeOut As String
    Public lngCheckBoxSlide As String
    Public lngRadioButtonConfNormal As String
    Public lngRadioButtonConfAverage As String
    Public lngRadioButtonConfMinimum As String
    Public lngCheckBoxConfigWindow As String
    Public lngCheckBoxtracelog As String
    Public lngCheckBoxFilters As String
    Public lngCheckBoxbuttonssave As String
    Public lngGroupBoxMouse As String
    Public lngCheckBoxaccordscrollhorizontal As String
    Public lngCheckBoxUrlUpdate As String
    Public lngGroupBoxUrlUpdate As String
    Public lngGroupBoxToolTipsBallon As String
    Public lngCheckBoxToolTipsBallon As String

    'PREF_TABPAGE_PROXY
    Public lngTabPageProxy As String
    Public lngGroupBoxConnexion As String
    Public lngGroupBoxProxy As String
    Public lngLabelUtilisateur As String
    Public lngLabelMotdePasse As String
    Public lngLabelProxy As String
    Public lngLabelPort As String

    'PREF_TABPAGE_MAJ_DONNEES
    Public lngTabPageMiseajourDonnees As String
    Public lngGroupBoxIntervalle As String
    Public lngGroupBoxUpdateLast As String
    Public lngGroupBoxAutoUpdate As String
    Public lngGroupBoxTailleBdd As String
    Public lngGroupBoxUpdateIn As String
    Public lngUpdateIn As String
    Public lngGroupBoxUpdateNext As String
    Public lngRadioButtonDay1 As String
    Public lngRadioButtonDay2 As String
    Public lngRadioButtonDay3 As String
    Public lngRadioButtonDay4 As String
    Public lngRadioButtonDay5 As String
    Public lngCheckBoxAutoUpdate As String

    Public lngGroupBoxChoixSource As String
    Public lngRadioButtonXMLTV As String
    Public lngRadioButtonEPGData As String
    Public lngGroupBoxEpgdata As String
    Public lngLabelPinCode As String
    Public lngLabelNbJourDownload As String
    Public lngLabelEpgdataExpiration As String
    Public lngBoutonSAbonner As String
    Public lngLabelInfo As String

    'PREF_TABPAGE_MAJ_LOGICIEL
    Public lngTabPageMiseajourLogiciel As String
    Public lngGroupBoxIntervalles As String
    Public lngGroupBoxLastCheck As String
    Public lngGroupBoxNextCheck As String
    Public lngGroupBoxCheck As String
    Public lngGroupBoxCheckIn As String
    Public lngCheckIn As String
    Public lngRadioButtonAllDays As String
    Public lngRadioButtonAllWeeks As String
    Public lngRadioButtonAllMonths As String
    Public lngCheckBoxAutoverif As String

    'PREF_TABPAGE_MAJ_CESOIR_MAINTENANT
    Public lngTabPageCesoirMaintenant As String
    Public lngGroupBoxCesoir As String
    Public lngGroupBoxMaintenant As String
    Public lngRadioButtonCesoirAll As String
    Public lngRadioButtonCesoir45 As String
    Public lngRadioButtonCesoir60 As String
    Public lngRadioButtonCesoir75 As String
    Public lngRadioButtonCesoir90 As String
    Public lngRadioButtonCesoir105 As String
    Public lngRadioButtonCesoir120 As String
    Public lngRadioButtonMaintenantAll As String
    Public lngRadioButtonMaintenant45 As String
    Public lngRadioButtonMaintenant60 As String
    Public lngRadioButtonMaintenant75 As String
    Public lngRadioButtonMaintenant90 As String
    Public lngRadioButtonMaintenant105 As String
    Public lngRadioButtonMaintenant120 As String

    'PREF_TABPAGE_MODE_VEILLE
    Public lngTabPageResume As String
    Public lngGroupBoxResume As String
    Public lngCheckBoxResume As String
    Public lngGroupBoxResumeBefore As String
    Public lngRadioButtonResume5 As String
    Public lngRadioButtonResume10 As String
    Public lngRadioButtonResume15 As String
    Public lngRadioButtonResume20 As String
    Public lngRadioButtonResume30 As String

    'PREF_TABPAGE_GESTION_SON
    Public lngTabPageSound As String
    Public lngGroupBoxRSS As String
    Public lngGroupBoxMessages As String
    Public lngGroupBoxReminder As String
    Public lngGroupBoxMasterVolume As String
    Public lngGroupBoxMute As String
    Public lngCheckBoxAudioOn As String

    'PREF_BUTTON
    Public lngButtonOk As String
    Public lngButtonCancel As String

    'MAINFORM_TOOLSTRIP_MENU_FILE
    Public lngToolStripMenuFile As String
    Public lngToolStripMenuFileSave As String
    Public lngToolStripMenuFileRestart As String
    Public lngToolStripMenuFileExit As String
    Public lngToolStripMenuItemSettingsReset As String

    'MAINFORM_TOOLSTRIP_MENU_EDIT
    Public lngToolStripMenuEdit As String
    Public lngToolStripMenuEditOntop As String
    Public lngToolStripMenuSearch As String
    Public lngToolStripMenuEditPrint As String
    Public lngToolStripMenuPrintTonight As String
    Public lngToolStripMenuCategories As String
    Public lngToolStripMenuDescription As String
    Public lngToolStripMenuCalendar As String

    'MAINFORM_TOOLSTRIP_MENU_OPTIONS
    Public lngToolStripMenuOptions As String
    Public lngToolStripMenuOptionsUpdate As String
    Public lngToolStripMenuOptionsAutoUpdate As String
    Public lngToolStripMenuOptionsPreferences As String
    Public lngToolStripMenuOptionsLogos As String
    Public lngToolStripMenuOptionsDualMonitor As String
    Public lngToolStripMenuOptionsEngineSelection As String

    'MAINFORM_TOOLSTRIP_MENU_HELP
    Public lngToolStripMenuHelp As String
    Public lngToolStripMenuHelpHelptopics As String
    Public lngToolStripMenuHelpHelpShortcuts As String
    Public lngToolStripMenuHelpWebsite As String
    Public lngToolStripMenuHelpForum As String
    Public lngToolStripMenuHelpCheckupdates As String
    Public lngToolStripMenuHelpLanguage As String
    Public lngToolStripMenuHelpAbout As String
    Public lngToolStripMenuHelpManualFeedBack As String
    Public lngToolStripMenuHelpDonate As String
    Public lngToolStripMenuHelpCompensation As String
    Public lngToolStripMenuHelpContent As String
    Public lngToolStripMenuHelpPlugins As String
    Public lngToolStripMenuHelpWeather As String
    Public lngToolStripMenuHelpLocation As String

    'MAINFORM_TOOLSTRIP
    Public lngToolStripSave As String
    Public lngToolStripPrint As String
    Public lngToolStripSearch As String
    Public lngToolStripOntop As String
    Public lngToolStripPreferences As String
    Public lngToolStripLogos As String
    Public lngToolStripUpdate As String
    Public lngToolStripAutoUpdate As String
    Public lngToolStripCheckupdates As String
    Public lngToolStripDualMonitor As String
    Public lngToolStripWebsite As String
    Public lngToolStripForum As String
    Public lngToolStripLangue As String
    Public lngToolStripAbout As String
    Public lngToolStripHelptopics As String
    Public lngToolStripHelpShortcuts As String
    Public lngToolStripCategories As String
    Public lngToolStripDescription As String
    Public lngToolStripCalendar As String
    Public lngToolStripManualFeedBack As String
    Public lngToolStripTextBoxRecherche As String
    Public lngToolStripButtonRecherche As String

    'MAINFORM_PAVE
    Public lngPaveJourMoins As String
    Public lngPaveHeureMoins As String
    Public lngPave6H As String
    Public lngPave9H As String
    Public lngPave12H As String
    Public lngPave15H As String
    Public lngPave18H As String
    Public lngPave20H As String
    Public lngPave23H As String
    Public lngPaveMaintenant As String
    Public lngPaveHeurePlus As String
    Public lngPaveJourPlus As String

    'MAINFORM_CESOIR_MAINTENANT
    Public lngPanelTitreCesoir As String
    Public lngPanelTitreMaintenant As String

    'REORGCHANNEL_TITLE
    Public lngReorgChannelTitle As String

    'REORGCHANNEL_BUTTON
    Public lngButtonMonterReorgChannel As String
    Public lngButtonDescendreReorgChannel As String
    Public lngButtonSupprimerReorgChannel As String
    Public lngButtonLogoReorgChannel As String
    Public lngButtonEnregistrerReorgChannel As String
    Public lngButtonAnnulerReorgChannel As String
    Public lngReorgChannelListViewColumns0 As String
    Public lngReorgChannelListViewColumns1 As String

    'FRM_ABOUT_TITLE
    Public lngAboutTitle As String

    'FRM_ABOUT_TABPAGE_ABOUT
    Public lngTabPageAbout As String

    'FRM_ABOUT_TABPAGE_AUTHORS
    Public lngTabPageAuteurs As String
    Public lngTextBoxAdmin As String
    Public lngTextBoxDev As String
    Public lngTextBoxTesters As String
    Public lngTextBoxContributors As String
    Public lngTextBoxThanks As String

    'FRM_ABOUT_TABPAGE_LICENCE
    Public lngTabPagelicence As String

    'FRM_ABOUT_TABPAGE_7ZIP
    Public lngTabPage7zip As String

    'FRM_ABOUT_TABPAGE_DONATE
    Public lngTabPageDonate As String

    'FRM_LISTRECKTV_TITLE
    Public lngfrmListRecKTV As String

    'FRM_LISTRECKTV
    Public lngGroupBoxDetails As String
    Public lngGroupBoxRepete As String
    Public lngLabelChaine As String
    Public lngLabelDebut As String
    Public lngLabelFin As String
    Public lngLabelProfile As String
    Public lngLabelNom As String
    Public lngCmdModify As String
    Public lngCmdDelete As String
    Public lngCmdAdd As String
    Public lngCmdCancel As String
    Public lngRadioButtonUnique As String
    Public lngRadioButtonJournalier As String
    Public lngRadioButtonHebdo As String
    Public lngRadioButtonMensuel As String
    Public lngCheckBoxLundi As String
    Public lngCheckBoxMardi As String
    Public lngCheckBoxMercredi As String
    Public lngCheckBoxJeudi As String
    Public lngCheckBoxVendredi As String
    Public lngCheckBoxSamedi As String
    Public lngCheckBoxDimanche As String

    'FRM_LISTRECKTV_LISTVIEW1_COLUMN
    Public lngfrmListRecKTVListView1Columns0 As String
    Public lngfrmListRecKTVListView1Columns1 As String
    Public lngfrmListRecKTVListView1Columns2 As String
    Public lngfrmListRecKTVListView1Columns3 As String

    'FRM_LISTRECKTV_MESSAGES
    Public lngfrmListRecKTVOverlappingRec As String
    Public lngfrmListRecKTVCantWhrite As String
    Public lngfrmListRecKTVParameterKtvChannel As String

    'KTVFORM_TITLE
    Public lngKTvForm As String

    'KTVFORM_LISTVIEW1_COLUMN
    Public lngKTvFormListView1Columns0 As String
    Public lngKTvFormListView1Columns1 As String
    Public lngKTvFormListView1Columns2 As String

    'KTVFORM
    Public lngKTvFormLabelSource As String
    Public lngKTvFormButtonSave As String
    Public lngKTvFormButtonClose As String

    'KTVFORM_MSG_REP_KTV
    Public lngMsgRepKtvTitle As String
    '= "ZGuideTV.NET - K!TV"
    Public lngMsgRepKtv As String
    '= "Le répertoire K!TV n'a pas été trouvé."

    'KTVFORM_MSG_INI_KTV
    Public lngMsgIniKtvTitle As String
    '= "ZGuideTV.NET - K!TV"
    Public lngMsgIniKtv As String
    '= "Le fichier ini n'a pas été trouvé."

    'KTVFORM_MESSAGES
    Public lngKTvFormTheFile As String
    Public lngKTvFormNoKtvFolder As String
    Public lngKTvFormNoKtvIni As String
    Public lngKTvFormTheFolder As String
    Public lngKTvFormDontExist As String
    Public lngKTvFormChannelLoadErr As String
    Public lngKTvFormSaveKtvErr As String
    Public lngKTvFormNoSource As String
    Public lngKTvFormNoChannel As String
    Public lngKTvFormSelectZgChannel As String

    'FRMMISEAJOUR_TITLE
    Public lngFrmMiseajour As String

    'FRMMISEAJOUR
    Public lngRadioButtonDownload As String
    Public lngRadioButtonXmlPath As String
    Public lngButtonTout As String
    Public lngButtonSuppr As String
    Public lngButtonMiseaJour As String
    Public lngButtonDemarrer As String
    Public lngButtonAnnuler As String
    Public lngButtonEdit As String
    Public lngButtonForceDownload As String
    Public lngtelechargement As String
    Public lngParsingoperation As String

    'FRMMISEAJOUR_MESSAGE
    Public lngErrorInChannelListRecovery As String
    Public lngNoURLUpdate As String
    Public lngInvalidURL As String
    Public lngUntraceableFile As String
    Public lngInvalidFile As String
    Public lngErrorInUpdate As String
    Public lngErrorInXMLCopy As String
    Public lngErrorInFileCopy As String
    Public lngErrorInUnzip As String
    Public lngWrongFileName As String
    Public lngFailURLFileDownload As String
    Public lngUntraceableURLListFile As String
    Public lngTheFile As String
    Public lngDontExist As String
    Public lngProtectedFile As String
    Public lngChosenChannels As String
    Public lngAvailableChannels As String
    Public lngChoseFile As String
    Public lngInvalidChoice As String

    'MAINFORM_MENU_CONTEXTUEL_K!TV
    Public lngToolStripMenuProgramKTV As String
    Public lngToolStripMenuZapperKTV As String
    Public lngToolStripMenuGestionRecordKTV As String
    Public lngToolStripMenuGestionChainesKTV As String

    'MAINFORM_MENU_CONTEXTUEL_MMTV
    Public lngToolStripMenuProgramMMTV As String
    Public lngToolStripMenuZapperMMTV As String
    Public lngToolStripMenuGestionRecordMMTV As String
    Public lngToolStripMenuGestionChainesMMTV As String

    'MAINFORM_MENU_CONTEXTUEL_DESCRIPTION
    Public lngToolStripMenuPrintDescript As String

    'MAINFORM_MESSAGE_PROXY
    Public lngMsgProxyTitle As String
    Public lngMsgProxy As String

    'MAINFORM_NOTIFYICON1_BALLOONTIP
    Public lngNotifyIcon1BalloonTipTitle As String
    Public lngNotifyIcon1 As String

    'MAINFORM TREEVIEW CATEGORY
    Public lngNodeFilter As String
    Public lngNodeCategory As String
    Public lngNodeCountry As String
    Public lngNodeProvider As String

    'MESSAGEBOXBASEPERIMEE
    Public lngMessageBoxBasePerimee As String
    Public lngMessageBoxBasePerimee1 As String
    Public lngMessageBoxBasePerimeeTitre As String

    'MESSAGEBOXCODEPIN
    Public lngMessageBoxNoCodePin As String
    Public lngMessageBoxNoCodePin1 As String
    Public lngMessageBoxNoCodePinTitre As String

    'MESSAGEBOXNOUPDATE
    Public lngMessageBoxnoupdate As String
    Public lngMessageBoxnoupdateTitre As String

    'MESSAGEBOXMISEAJOUR
    Public lngMessageBoxMiseaJour As String
    Public lngMessageBoxMiseaJour1 As String
    Public lngMessageBoxMiseaJourTitre As String

    'MESSAGEBOXMISEAJOURDONE
    Public lngMessageBoxMiseaJourDone As String
    Public lngMessageBoxMiseaJour1Done As String
    Public lngMessageBoxMiseaJourTitreDone As String

    'MESSAGEBOXMODIFPREF
    Public lngMessageBoxModifPref As String
    Public lngMessageBoxModifPref1 As String
    Public lngMessageBoxModifPrefTitre As String

    'MESSAGEBOXNOCONNECTION
    Public lngMessageBoxNoConnection As String
    Public lngMessageBoxNoConnection1 As String
    Public lngMessageBoxNoConnectionTitre As String

    'MESSAGEBOXFEEDBACK
    Public lngMessageBoxFeedback As String
    Public lngMessageBoxFeedbackTitre As String

    'MESSAGEBOXFICHIERCORROMPU
    Public lngMessageFichierCorrompu As String
    Public lngMessageFichierCorrompu1 As String
    Public lngMessageFichierCorrompu2 As String
    Public lngMessageFichierCorrompuTitre As String

    'MESSAGEBOXLISTXMLTVFRCHOISIE
    Public lngMessageBoxListXMLTVFRChoisie As String
    Public lngMessageBoxListXMLTVFRChoisie1 As String
    Public lngMessageBoxListXMLTVFRChoisieTitre As String

    'MESSAGEBOXTHETVDBNORESULT
    Public lngMessageBoxThetvdbNoResult As String
    Public lngMessageBoxThetvdbNoResultTitre As String

    'MESSAGEBOXTHETVDBVALIDESERIEID
    Public lngMessageBoxThetvdbNoValidSeriesId As String
    Public lngMessageBoxThetvdbNoValidSeriesIdTitre As String

    'MESSAGEBOXTHETVDBNOSERIEDETAIL
    Public lngMessageBoxThetvdbNoSerieDetail As String
    Public lngMessageBoxThetvdbNoSerieDetailTitre As String

    'MESSAGEBOXTHETVDBNOACTORINFO
    Public lngMessageBoxThetvdbNoActorInfo As String
    Public lngMessageBoxThetvdbNoActorInfoTitre As String

    'MESSAGEBOXTHETVDBNOBANNER
    Public lngMessageBoxThetvdbNoBanner As String
    Public lngMessageBoxThetvdbNoBannerTitre As String

    'MESSAGEBOXMESSAGEENVOYE
    Public lngMessageBoxMessageEnvoye As String
    Public lngMessageBoxMessageEnvoyeTitre As String

    'MESSAGEBOXEPGDATA
    Public lngMessageBoxEPGData As String
    Public lngMessageBoxEPGData1 As String
    Public lngMessageBoxEPGDataTitre As String

    'MESSAGEBOXFILESAVE
    Public lngMessageBoxFileRestore As String
    Public lngMessageBoxFileRestore1 As String
    Public lngMessageBoxFileRestore2 As String
    Public lngMessageBoxFileRestoreTitre As String

    'MESSAGEBOXNORESTORESELECTED
    Public lngMessageBoxNoRestoreSelected As String
    Public lngMessageBoxNoRestoreSelectedTitre As String

    'MESSAGEBOXNORESTOREELEMENT
    Public lngMessageBoxNoRestoreElement As String
    Public lngMessageBoxNoRestoreElementTitre As String

    'MESSAGEBOXEPGDATANOSUBSCRIPTION
    Public lngMessageBoxEPGDataSubscription As String
    Public lngMessageBoxEPGDataSubscription1 As String
    Public lngMessageBoxEPGDataSubscriptionTitre As String

    'MESSAGEBOXREORGCHANNEL
    Public lngMessageBoxReorgChannel As String
    Public lngMessageBoxReorgChannel1 As String
    Public lngMessageBoxReorgChannelTitre As String

    'MESSAGEBOXRESUME
    Public lngMessageBoxResume As String
    Public lngMessageBoxResume1 As String
    Public lngMessageBoxResumeTitre As String

    'MESSAGEBOXRAZ
    Public lngMessageBoxRaz As String
    Public lngMessageBoxRaz1 As String
    Public lngMessageBoxTitleRaz As String

    'MESSAGEBOXMISEAJOUREXE
    Public lngMessageBoxMiseaJourExe As String
    Public lngMessageBoxMiseaJourExe1 As String
    Public lngMessageBoxMiseaJourExeTitre As String

    'MESSAGEBOXDIRCHECKED
    Public lngMessageBoxDirChecked As String
    Public lngMessageBoxDirChecked1 As String
    Public lngMessageBoxDirCheckedTitre As String

    'MESSAGEBOXFILENOTEXIST
    Public lngMessageBoxFileNotExist As String
    Public lngMessageBoxFileNotExist1 As String
    Public lngMessageBoxFileNotExistTitre As String

    'MESSAGEBOXURLCHECKED
    Public lngMessageBoxURLChecked As String
    Public lngMessageBoxURLChecked1 As String
    Public lngMessageBoxURLCheckedTitre As String

    'MISEAJOURAUTO
    Public lngMiseAJourAutoTitle As String
    Public lngNode_number As String
    Public lngAuto_update_operation As String
    Public lngdwnl_operation As String
    Public lngParsing_operation As String
    Public lngremaining_time As String
    Public lngfile_size As String

    'MISEAJOURAUTO_MESSAGE
    Public lngError1_majauto As String
    Public lngError2_majauto As String
    Public lngError3_majauto As String
    Public lngError4_majauto As String
    Public lngError5_majauto As String
    Public lngError6_majauto As String

    'NOTIFYICON
    Public lngBalloonText1 As String
    Public lngBalloonText3 As String

    'SYSTRAY
    Public lngSystrayMenuRestore As String
    Public lngSystrayMenuExit As String

    'TRI_AVANCE
    Public lngTriAvanceTitle As String
    Public lngTriAvanceLabeltitre As String
    Public lngTriAvanceLabelauteur As String
    Public lngTriAvanceLabelndefini As String
    Public lngTriAvanceButtonSearch As String
    Public lngtTriAvanceButtonCancel As String
    Public lngTriAvanceGroupBoxCriteres As String
    Public lngTriAvanceCheckBoxNow As String
    Public lngTriAvanceCheckBoxBegin As String
    Public lngTriAvanceListViewColumns0 As String
    Public lngTriAvanceListViewColumns1 As String
    Public lngTriAvanceListViewColumns2 As String
    Public lngTriAvanceListViewColumns3 As String
    Public lngTriAvanceListViewColumns4 As String

    'CALENDRIER
    Public lngCalendarLundiLabel As String
    Public lngCalendarMardiLabel As String
    Public lngCalendarMercrediLabel As String
    Public lngCalendarJeudiLabel As String
    Public lngCalendarVendrediLabel As String
    Public lngCalendarSamediLabel As String
    Public lngCalendarDimancheLabel As String
    Public lngNameofMonth1 As String
    Public lngNameofMonth2 As String
    Public lngNameofMonth3 As String
    Public lngNameofMonth4 As String
    Public lngNameofMonth5 As String
    Public lngNameofMonth6 As String
    Public lngNameofMonth7 As String
    Public lngNameofMonth8 As String
    Public lngNameofMonth9 As String
    Public lngNameofMonth10 As String
    Public lngNameofMonth11 As String
    Public lngNameofMonth12 As String

    'DESCRIPTBOX
    Public lngDescriptLundiLabel As String
    Public lngDescriptMardiLabel As String
    Public lngDescriptMercrediLabel As String
    Public lngDescriptJeudiLabel As String
    Public lngDescriptVendrediLabel As String
    Public lngDescriptSamediLabel As String
    Public lngDescriptDimancheLabel As String

    'Feedback
    Public lngFeedback_Title As String
    Public lngLabelExceptMessage1 As String
    Public lngLabelExceptMessage2 As String
    Public lngLabelExceptMessage3 As String
    Public lngCheckBoxExceptErrorMessage As String
    Public lngLabelEmail As String
    Public lngSend_Button As String
    Public lngCopier_Button As String
    Public lngExit_Button As String
    Public lngExceptErrorMessage As String
    Public lngLabelFeedbackSend As String
    Public lngZGuideTVRelease As String
    Public lngCompilationDate As String
    Public lngOSRelease As String
    Public lngArchitecture As String
    Public lngOSBootMode As String
    Public lngFramework As String
    Public lngOSLanguage As String
    Public lngTotalMemory As String
    Public lngRemainingMemory As String
    Public lngUsedMemory As String
    Public lngProcessorName As String
    Public lngProcessorNumber As String
    Public lngMonitorNumber As String
    Public lngEmail As String
    Public lngComments As String
    Public lngDescriptionError As String
    Public lngProcessorSpeed As String
    Public lngCheckBoxAcknowledgment As String
    Public lngProcessorDescription As String

    'THETVDBTAB
    Public lngThetvdbLabelSeriesTabSeries As String
    Public lngThetvdbLabelEpisodesTabEpisodes As String
    Public lngThetvdbLabelActorsTabActors As String

    'THETVDB
    Public lngThetvdbSeason As String
    Public lngThetvdbLabelSearchName As String
    Public lngThetvdbLabelLanguage As String
    Public lngThetvdbButtonSearch As String
    Public lngThetvdbLabelSiteRating As String
    Public lngThetvdbLabelID As String
    Public lngThetvdbLabelID1 As String
    Public lngThetvdbLabelRuntime As String
    Public lngThetvdbLabelRating As String
    Public lngThetvdbLabelDescription As String
    Public lngThetvdbLabelFirstAired As String
    Public lngThetvdbLabelIDTVCom As String
    Public lngThetvdbLabelIDIMDBCom As String
    Public lngThetvdbLabelForceUpdate As String
    Public lngThetvdbLabelZap2it As String
    Public lngThetvdbButtonLoad As String
    Public lngThetvdbButtonCancel As String
    Public lngThetvdbButtonSearchShow As String
    Public lngThetvdbButtonExit As String
    Public lngThetvdbLabelStatus As String
    Public lngThetvdbLabelGenre As String
    Public lngThetvdbLabelActors As String
    Public lngThetvdbLabelActors1 As String
    Public lngThetvdbLabelGueststar As String
    Public lngThetvdbLabelDirector As String
    Public lngThetvdbLabelWriter As String
    Public lngThetvdbLabelEpisodeDescription As String
    Public lngThetvdbLabelLoadFull As String
    Public lngThetvdbLabelLoadActors As String
    Public lngThetvdbLabelBanner As String
    Public lngThetvdbLabelUseZipped As String
    Public lngThetvdbLabelOpen As String
    Public lngThetvdbLabelEpisodes As String

    'THETVDBTABEPISODE
    Public lngThetvdbLabelAbsoluteNumberTabEpisodes As String
    Public lngThetvdbLabelProductCodeTabEpisodes As String
    Public lngThetvdbLabelDVDIDTabEpisodes As String
    Public lngThetvdbLabelDVDSeasonTabEpisodes As String
    Public lngThetvdbLabelDVDNumberTabEpisodes As String
    Public lngThetvdbLabelDVDChapterTabEpisodes As String
    Public lngThetvdbNodeSeasonTabEpisodes As String

    'THETVDBTABACTORS
    Public lngThetvdbGroupBoxInformationTabActors As String
    Public lngThetvdbLabelIDTabActors As String
    Public lngThetvdbLabelNameTabActors As String
    Public lngThetvdbLabelRoleTabActors As String
    Public lngThetvdbLabelSortOrderTabActors As String

    'THETVDBRESULT
    Public lngThetvdbGroupBoxResult As String
    Public lngThetvdbLabelFirstAiredResult As String
    Public lngThetvdbLabelIMDBIdResult As String
    Public lngThetvdbLabelOverviewResult As String
    Public lngThetvdbLabelStatusResult As String
    Public lngThetvdbButtonChooseResult As String
    Public lngThetvdbButtonCancelResult As String
    Public lngThetvdbListviewResultColumns0 As String
    Public lngThetvdbListviewResultColumns1 As String
    Public lngThetvdbListviewResultColumns2 As String

    'THETVDBBOXNOSHEET
    Public lngThetvdbBoxNoSheet As String
    Public lngThetvdbBoxNoSheetTitre As String

    'RICHTEXTBOXDESCRIP
    Public lngRichTextBoxDescripFrom As String
    Public lngRichTextBoxDescripTo As String
    Public lngRichTextBoxDescripDescrip As String
    Public lngRichTextBoxDescripActors As String
    Public lngRichTextBoxDescripCategory As String
    Public lngRichTextBoxDescripProductionDate As String
    Public lngRichTextBoxDescripDuree As String
    Public lngRichTextBoxDescripShowView As String
    Public lngRichTextBoxDescripDate As String
    Public lngRichTextBoxDescripGenre As String

    'CHANNELSVIEW
    Public lngChannelViewTitle As String
    Public lngChannelViewCheckBox24hHours As String
    Public lngChannelViewLabelOr As String
    Public lngChannelViewButtonClose As String
    Public lngChannelViewListViewColumns0 As String
    Public lngChannelViewListViewColumns1 As String
    Public lngChannelViewListViewColumns2 As String
    Public lngChannelViewListViewColumns3 As String

    'TIMEZONE
    Public lngTimeZoneTitle As String
    Public lngTimeZoneLabelCompensation As String
    Public lngTimeZoneLabelMinute As String

    'ENGINESELECTION
    Public lngEngineSelectionTitle As String
    Public lngEngineSelectionTVDBListBox As String
    Public lngEngineSelectionIMDBListBox As String
    Public lngEngineSelectionAllocineListBox As String
    Public lngEngineSelectionShowCheckBox As String

    'STATUSSTRIP
    Public lngToolStripStatusLabelActiveEngine As String
    Public lngToolStripStatusLabelTHEDVB As String
    Public lngToolStripStatusLabelIMDB As String
    Public lngToolStripStatusLabelALLOCINE As String
    Public lngToolStripStatusLabelMemory As String
    Public lngToolStripStatusLabelMB As String

    'LOADER
    Public lngLoaderLabelWait As String

    'SIGNALETIQUE
    Public lngSignaletique As String
    Public lngSignaletiqueLabel10 As String
    Public lngSignaletiqueLabel12 As String
    Public lngSignaletiqueLabel16 As String
    Public lngSignaletiqueLabel18 As String
    Public lngSignaletiqueLabel43 As String
    Public lngSignaletiqueLabel169 As String
    Public lngSignaletiqueLabelStereo As String
    Public lngSignaletiqueLabelCaption As String
    Public lngSignaletiqueLabelHD As String
    Public lngSignaletiqueLabelFirstAir As String

    'WEATHERUPDATE
    Public lngWeatherInformation As String

    'FORECAST
    Public lngForecastTitre As String
    Public lngMax As String
    Public lngMin As String
    Public lngOK As String
    Public lngAnnuler As String
    Public lngLocation As String

    'WEATHERCITYSELECT
    Public lngWeatherCitySelectTitre As String

    'BALLONTIPS
    Public lngBallonTipsNoInformation As String

    'GESTIONBDD
    Public lngGestionBddTitre As String
    Public lngGestionBddButtonDelete As String
    Public lngGestionBddButtonSave As String
    Public lngGestionBddButtonRestore As String
    Public lngGestionBddButtonCancel As String
    Public lngListViewGestionBddColumns0 As String
    Public lngListViewGestionBddColumns1 As String
    Public lngListViewGestionBddColumns2 As String
    Public lngGroupBoxRestauration As String
    Public lngCheckBoxRestaurationDataBase As String
    Public lngCheckBoxRestaurationChaines As String
    Public lngCheckBoxRestaurationUrl As String
    Public lngCheckBoxRestaurationUserConfig As String

    'PROGRESSBAR
    Public lngProgressBarSaveTitre As String
    Public lngProgressBarSaveLabel As String
    Public lngProgressBarRestoreTitre As String
    Public lngProgressBarRestoreLabel As String

    Public Sub Init(ByVal languagefile As String)
        If (Not languagefile Is Nothing AndAlso String.IsNullOrEmpty(languagefile)) Then
            Return
        End If
        If Not (File.Exists(languagefile)) Then
            MessageBox.Show("Languagefile not found!!!", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim str As String
        Dim sr As New StreamReader(languagefile, True)
        str = sr.ReadLine()
        Do While Not (str Is Nothing)

            'LANGUAGE
            If str.StartsWith("lngLanguage=", StringComparison.CurrentCulture) Then
                lngLanguage = str.Substring(12)
            ElseIf str.StartsWith("lngAuthor=", StringComparison.CurrentCulture) Then
                lngAuthor = str.Substring(10)

                'SELECTLANGUAGE
            ElseIf str.StartsWith("lngSelectLanguageButtonOK=", StringComparison.CurrentCulture) Then
                lngSelectLanguageButtonOK = str.Substring(26)
            ElseIf str.StartsWith("lngSelectLanguageButtonCancel=", StringComparison.CurrentCulture) Then
                lngSelectLanguageButtonCancel = str.Substring(30)

                'JUMPLIST
            ElseIf str.StartsWith("lngSiteOfficiel=", StringComparison.CurrentCulture) Then
                lngSiteOfficiel = str.Substring(16)
            ElseIf str.StartsWith("lngForumOfficiel=", StringComparison.CurrentCulture) Then
                lngForumOfficiel = str.Substring(17)

                'PREMIERDEMARRAGE
            ElseIf str.StartsWith("lngPremierDemarrageTitle=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageTitle = str.Substring(25)
            ElseIf str.StartsWith("lngPremierDemarrageLabelInfo=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageLabelInfo = str.Substring(29)
            ElseIf str.StartsWith("lngPremierDemarrageGroupBoxChoixSource=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageGroupBoxChoixSource = str.Substring(39)
            ElseIf str.StartsWith("lngPremierDemarrageRadioButtonXMLTV=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageRadioButtonXMLTV = str.Substring(36)
            ElseIf str.StartsWith("lngPremierDemarrageRadioButtonEPGData=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageRadioButtonEPGData = str.Substring(38)
            ElseIf str.StartsWith("lngPremierDemarrageGroupBoxEPGData=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageGroupBoxEPGData = str.Substring(35)
            ElseIf str.StartsWith("lngPremierDemarrageLabelPinCode=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageLabelPinCode = str.Substring(32)
            ElseIf str.StartsWith("lngPremierDemarrageButtonSubscription=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageButtonSubscription = str.Substring(38)
            ElseIf str.StartsWith("lngPremierDemarrageLabelInfoPrice=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageLabelInfoPrice = str.Substring(34)
            ElseIf str.StartsWith("lngPremierDemarrageButtonOK=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageButtonOK = str.Substring(28)
            ElseIf str.StartsWith("lngPremierDemarrageButtonCancel=", StringComparison.CurrentCulture) Then
                lngPremierDemarrageButtonCancel = str.Substring(32)

                'EPGDATASUBSCRIPTION
            ElseIf str.StartsWith("lngEPGDataSubscriptionTitle=", StringComparison.CurrentCulture) Then
                lngEPGDataSubscriptionTitle = str.Substring(28)
            ElseIf str.StartsWith("lngEPGDataSubscriptionLabelChoixPays=", StringComparison.CurrentCulture) Then
                lngEPGDataSubscriptionLabelChoixPays = str.Substring(37)
            ElseIf str.StartsWith("lngEPGDataSubscriptionLabelChoixLangue=", StringComparison.CurrentCulture) Then
                lngEPGDataSubscriptionLabelChoixLangue = str.Substring(39)
            ElseIf str.StartsWith("lngEPGDataSubscriptionButtonGoEPGData=", StringComparison.CurrentCulture) Then
                lngEPGDataSubscriptionButtonGoEPGData = str.Substring(38)

                'PREF_TITLE
            ElseIf str.StartsWith("lngPrefTitle=", StringComparison.CurrentCulture) Then
                lngPrefTitle = str.Substring(13)

                'PREF_TABPAGE_GENERAL
            ElseIf str.StartsWith("lngTabPageGeneral=", StringComparison.CurrentCulture) Then
                lngTabPageGeneral = str.Substring(18)
            ElseIf str.StartsWith("lngGroupBoxPurge=", StringComparison.CurrentCulture) Then
                lngGroupBoxPurge = str.Substring(17)
            ElseIf str.StartsWith("lngGroupBoxEffects=", StringComparison.CurrentCulture) Then
                lngGroupBoxEffects = str.Substring(19)
            ElseIf str.StartsWith("lngGroupBoxConfHardware=", StringComparison.CurrentCulture) Then
                LngGroupBoxConfHardware = str.Substring(24)
            ElseIf str.StartsWith("lngGroupBoxSauvegardeFenetre=", StringComparison.CurrentCulture) Then
                lngGroupBoxSauvegardeFenetre = str.Substring(29)
            ElseIf str.StartsWith("lngGroupBoxDivers=", StringComparison.CurrentCulture) Then
                lngGroupBoxDivers = str.Substring(18)
            ElseIf str.StartsWith("lngGroupBoxFiltres=", StringComparison.CurrentCulture) Then
                lngGroupBoxFiltres = str.Substring(19)
            ElseIf str.StartsWith("lngGroupBoxPosition=", StringComparison.CurrentCulture) Then
                lngGroupBoxPosition = str.Substring(20)
            ElseIf str.StartsWith("lngCheckBoxPurge=", StringComparison.CurrentCulture) Then
                lngCheckBoxPurge = str.Substring(17)
            ElseIf str.StartsWith("lngCheckBoxoldUI=", StringComparison.CurrentCulture) Then
                lngCheckBoxoldUI = str.Substring(17)
            ElseIf str.StartsWith("lngCheckBoxFadeOut=", StringComparison.CurrentCulture) Then
                lngCheckBoxFadeOut = str.Substring(19)
            ElseIf str.StartsWith("lngCheckBoxSlide=", StringComparison.CurrentCulture) Then
                lngCheckBoxSlide = str.Substring(17)
            ElseIf str.StartsWith("lngRadioButtonConfNormal=", StringComparison.CurrentCulture) Then
                lngRadioButtonConfNormal = str.Substring(25)
            ElseIf str.StartsWith("lngRadioButtonConfAverage=", StringComparison.CurrentCulture) Then
                lngRadioButtonConfAverage = str.Substring(26)
            ElseIf str.StartsWith("lngRadioButtonConfMinimum=", StringComparison.CurrentCulture) Then
                lngRadioButtonConfMinimum = str.Substring(26)
            ElseIf str.StartsWith("lngCheckBoxConfigWindow=", StringComparison.CurrentCulture) Then
                lngCheckBoxConfigWindow = str.Substring(24)
            ElseIf str.StartsWith("lngCheckBoxtracelog=", StringComparison.CurrentCulture) Then
                lngCheckBoxtracelog = str.Substring(20)
            ElseIf str.StartsWith("lngCheckBoxFilters=", StringComparison.CurrentCulture) Then
                lngCheckBoxFilters = str.Substring(19)
            ElseIf str.StartsWith("lngCheckBoxbuttonssave=", StringComparison.CurrentCulture) Then
                lngCheckBoxbuttonssave = str.Substring(23)
            ElseIf str.StartsWith("lngCheckBoxaccordscrollhorizontal=", StringComparison.CurrentCulture) Then
                lngCheckBoxaccordscrollhorizontal = str.Substring(34)
            ElseIf str.StartsWith("lngGroupBoxMouse=", StringComparison.CurrentCulture) Then
                lngGroupBoxMouse = str.Substring(17)
            ElseIf str.StartsWith("lngCheckBoxUrlUpdate=", StringComparison.CurrentCulture) Then
                lngCheckBoxUrlUpdate = str.Substring(21)
            ElseIf str.StartsWith("lngGroupBoxUrlUpdate=", StringComparison.CurrentCulture) Then
                lngGroupBoxUrlUpdate = str.Substring(21)
            ElseIf str.StartsWith("lngCheckBoxToolTipsBallon=", StringComparison.CurrentCulture) Then
                lngCheckBoxToolTipsBallon = str.Substring(26)
            ElseIf str.StartsWith("lngGroupBoxToolTipsBallon=", StringComparison.CurrentCulture) Then
                lngGroupBoxToolTipsBallon = str.Substring(26)

                'PREF_TABPAGE_PROXY
            ElseIf str.StartsWith("lngTabPageProxy=", StringComparison.CurrentCulture) Then
                lngTabPageProxy = str.Substring(16)
            ElseIf str.StartsWith("lngGroupBoxConnexion=", StringComparison.CurrentCulture) Then
                lngGroupBoxConnexion = str.Substring(21)
            ElseIf str.StartsWith("lngGroupBoxProxy=", StringComparison.CurrentCulture) Then
                lngGroupBoxProxy = str.Substring(17)
            ElseIf str.StartsWith("lngLabelUtilisateur=", StringComparison.CurrentCulture) Then
                lngLabelUtilisateur = str.Substring(20)
            ElseIf str.StartsWith("lngLabelMotdePasse=", StringComparison.CurrentCulture) Then
                lngLabelMotdePasse = str.Substring(19)
            ElseIf str.StartsWith("lngLabelProxy=", StringComparison.CurrentCulture) Then
                lngLabelProxy = str.Substring(14)
            ElseIf str.StartsWith("lngLabelPort=", StringComparison.CurrentCulture) Then
                lngLabelPort = str.Substring(13)

                'PREF_TABPAGE_MAJ_DONNEES
            ElseIf str.StartsWith("lngTabPageMiseajourDonnees=", StringComparison.CurrentCulture) Then
                lngTabPageMiseajourDonnees = str.Substring(27)
            ElseIf str.StartsWith("lngGroupBoxIntervalle=", StringComparison.CurrentCulture) Then
                lngGroupBoxIntervalle = str.Substring(22)
            ElseIf str.StartsWith("lngGroupBoxUpdateLast=", StringComparison.CurrentCulture) Then
                lngGroupBoxUpdateLast = str.Substring(22)
            ElseIf str.StartsWith("lngGroupBoxAutoUpdate=", StringComparison.CurrentCulture) Then
                lngGroupBoxAutoUpdate = str.Substring(22)
            ElseIf str.StartsWith("lngGroupBoxTailleBdd=", StringComparison.CurrentCulture) Then
                lngGroupBoxTailleBdd = str.Substring(21)
            ElseIf str.StartsWith("lngGroupBoxUpdateIn=", StringComparison.CurrentCulture) Then
                lngGroupBoxUpdateIn = str.Substring(20)
            ElseIf str.StartsWith("lngUpdateIn=", StringComparison.CurrentCulture) Then
                lngUpdateIn = str.Substring(12)
            ElseIf str.StartsWith("lngGroupBoxUpdateNext=", StringComparison.CurrentCulture) Then
                lngGroupBoxUpdateNext = str.Substring(22)
            ElseIf str.StartsWith("lngRadioButtonDay1=", StringComparison.CurrentCulture) Then
                lngRadioButtonDay1 = str.Substring(19)
            ElseIf str.StartsWith("lngRadioButtonDay2=", StringComparison.CurrentCulture) Then
                lngRadioButtonDay2 = str.Substring(19)
            ElseIf str.StartsWith("lngRadioButtonDay3=", StringComparison.CurrentCulture) Then
                lngRadioButtonDay3 = str.Substring(19)
            ElseIf str.StartsWith("lngRadioButtonDay4=", StringComparison.CurrentCulture) Then
                lngRadioButtonDay4 = str.Substring(19)
            ElseIf str.StartsWith("lngRadioButtonDay5=", StringComparison.CurrentCulture) Then
                lngRadioButtonDay5 = str.Substring(19)
            ElseIf str.StartsWith("lngCheckBoxAutoUpdate=", StringComparison.CurrentCulture) Then
                lngCheckBoxAutoUpdate = str.Substring(22)
            ElseIf str.StartsWith("lngGroupBoxChoixSource=", StringComparison.CurrentCulture) Then
                lngGroupBoxChoixSource = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonXMLTV=", StringComparison.CurrentCulture) Then
                lngRadioButtonXMLTV = str.Substring(20)
            ElseIf str.StartsWith("lngRadioButtonEPGData=", StringComparison.CurrentCulture) Then
                lngRadioButtonEPGData = str.Substring(22)
            ElseIf str.StartsWith("lngGroupBoxEpgdata=", StringComparison.CurrentCulture) Then
                lngGroupBoxEpgdata = str.Substring(19)
            ElseIf str.StartsWith("lngLabelPinCode=", StringComparison.CurrentCulture) Then
                lngLabelPinCode = str.Substring(16)
            ElseIf str.StartsWith("lngLabelNbJourDownload=", StringComparison.CurrentCulture) Then
                lngLabelNbJourDownload = str.Substring(23)
            ElseIf str.StartsWith("lngLabelEpgdataExpiration=", StringComparison.CurrentCulture) Then
                lngLabelEpgdataExpiration = str.Substring(26)
            ElseIf str.StartsWith("lngBoutonSAbonner=", StringComparison.CurrentCulture) Then
                lngBoutonSAbonner = str.Substring(18)
            ElseIf str.StartsWith("lngLabelInfo=", StringComparison.CurrentCulture) Then
                lngLabelInfo = str.Substring(13)

                'PREF_TABPAGE_MAJ_LOGICIEL
            ElseIf str.StartsWith("lngTabPageMiseajourLogiciel=", StringComparison.CurrentCulture) Then
                lngTabPageMiseajourLogiciel = str.Substring(28)
            ElseIf str.StartsWith("lngGroupBoxIntervalles=", StringComparison.CurrentCulture) Then
                lngGroupBoxIntervalles = str.Substring(23)
            ElseIf str.StartsWith("lngGroupBoxLastCheck=", StringComparison.CurrentCulture) Then
                lngGroupBoxLastCheck = str.Substring(21)
            ElseIf str.StartsWith("lngGroupBoxNextCheck=", StringComparison.CurrentCulture) Then
                lngGroupBoxNextCheck = str.Substring(21)
            ElseIf str.StartsWith("lngGroupBoxCheck=", StringComparison.CurrentCulture) Then
                lngGroupBoxCheck = str.Substring(17)
            ElseIf str.StartsWith("lngGroupBoxCheckIn=", StringComparison.CurrentCulture) Then
                lngGroupBoxCheckIn = str.Substring(19)
            ElseIf str.StartsWith("lngCheckIn=", StringComparison.CurrentCulture) Then
                lngCheckIn = str.Substring(11)
            ElseIf str.StartsWith("lngRadioButtonAllDays=", StringComparison.CurrentCulture) Then
                lngRadioButtonAllDays = str.Substring(22)
            ElseIf str.StartsWith("lngRadioButtonAllWeeks=", StringComparison.CurrentCulture) Then
                lngRadioButtonAllWeeks = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonAllMonths=", StringComparison.CurrentCulture) Then
                lngRadioButtonAllMonths = str.Substring(24)
            ElseIf str.StartsWith("lngCheckBoxAutoverif=", StringComparison.CurrentCulture) Then
                lngCheckBoxAutoverif = str.Substring(21)

                'PREF_TABPAGE_MAJ_CESOIR_MAINTENANT
            ElseIf str.StartsWith("lngTabPageCesoirMaintenant=", StringComparison.CurrentCulture) Then
                lngTabPageCesoirMaintenant = str.Substring(27)
            ElseIf str.StartsWith("lngGroupBoxCesoir=", StringComparison.CurrentCulture) Then
                lngGroupBoxCesoir = str.Substring(18)
            ElseIf str.StartsWith("lngGroupBoxMaintenant=", StringComparison.CurrentCulture) Then
                lngGroupBoxMaintenant = str.Substring(22)
            ElseIf str.StartsWith("lngRadioButtonCesoirAll=", StringComparison.CurrentCulture) Then
                lngRadioButtonCesoirAll = str.Substring(24)
            ElseIf str.StartsWith("lngRadioButtonCesoir45=", StringComparison.CurrentCulture) Then
                lngRadioButtonCesoir45 = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonCesoir60=", StringComparison.CurrentCulture) Then
                lngRadioButtonCesoir60 = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonCesoir75=", StringComparison.CurrentCulture) Then
                lngRadioButtonCesoir75 = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonCesoir90=", StringComparison.CurrentCulture) Then
                lngRadioButtonCesoir90 = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonCesoir105=", StringComparison.CurrentCulture) Then
                lngRadioButtonCesoir105 = str.Substring(24)
            ElseIf str.StartsWith("lngRadioButtonCesoir120=", StringComparison.CurrentCulture) Then
                lngRadioButtonCesoir120 = str.Substring(24)
            ElseIf str.StartsWith("lngRadioButtonMaintenantAll=", StringComparison.CurrentCulture) Then
                lngRadioButtonMaintenantAll = str.Substring(28)
            ElseIf str.StartsWith("lngRadioButtonMaintenant45=", StringComparison.CurrentCulture) Then
                lngRadioButtonMaintenant45 = str.Substring(27)
            ElseIf str.StartsWith("lngRadioButtonMaintenant60=", StringComparison.CurrentCulture) Then
                lngRadioButtonMaintenant60 = str.Substring(27)
            ElseIf str.StartsWith("lngRadioButtonMaintenant75=", StringComparison.CurrentCulture) Then
                lngRadioButtonMaintenant75 = str.Substring(27)
            ElseIf str.StartsWith("lngRadioButtonMaintenant90=", StringComparison.CurrentCulture) Then
                lngRadioButtonMaintenant90 = str.Substring(27)
            ElseIf str.StartsWith("lngRadioButtonMaintenant105=", StringComparison.CurrentCulture) Then
                lngRadioButtonMaintenant105 = str.Substring(28)
            ElseIf str.StartsWith("lngRadioButtonMaintenant120=", StringComparison.CurrentCulture) Then
                lngRadioButtonMaintenant120 = str.Substring(28)

                'PREF_TABPAGE_MODE_VEILLE
            ElseIf str.StartsWith("lngTabPageResume=", StringComparison.CurrentCulture) Then
                lngTabPageResume = str.Substring(17)
            ElseIf str.StartsWith("lngGroupBoxResume=", StringComparison.CurrentCulture) Then
                lngGroupBoxResume = str.Substring(18)
            ElseIf str.StartsWith("lngCheckBoxResume=", StringComparison.CurrentCulture) Then
                lngCheckBoxResume = str.Substring(18)
            ElseIf str.StartsWith("lngGroupBoxResumeBefore=", StringComparison.CurrentCulture) Then
                lngGroupBoxResumeBefore = str.Substring(24)
            ElseIf str.StartsWith("lngRadioButtonResume5=", StringComparison.CurrentCulture) Then
                lngRadioButtonResume5 = str.Substring(22)
            ElseIf str.StartsWith("lngRadioButtonResume10=", StringComparison.CurrentCulture) Then
                lngRadioButtonResume10 = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonResume15=", StringComparison.CurrentCulture) Then
                lngRadioButtonResume15 = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonResume20=", StringComparison.CurrentCulture) Then
                lngRadioButtonResume20 = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonResume30=", StringComparison.CurrentCulture) Then
                lngRadioButtonResume30 = str.Substring(23)

                'PREF_TABPAGE_GESTION_SON
            ElseIf str.StartsWith("lngTabPageSound=", StringComparison.CurrentCulture) Then
                lngTabPageSound = str.Substring(16)
            ElseIf str.StartsWith("lngGroupBoxRSS=", StringComparison.CurrentCulture) Then
                lngGroupBoxRSS = str.Substring(15)
            ElseIf str.StartsWith("lngGroupBoxMessages=", StringComparison.CurrentCulture) Then
                lngGroupBoxMessages = str.Substring(20)
            ElseIf str.StartsWith("lngGroupBoxReminder=", StringComparison.CurrentCulture) Then
                lngGroupBoxReminder = str.Substring(20)
            ElseIf str.StartsWith("lngGroupBoxMasterVolume=", StringComparison.CurrentCulture) Then
                lngGroupBoxMasterVolume = str.Substring(24)
            ElseIf str.StartsWith("lngGroupBoxMute=", StringComparison.CurrentCulture) Then
                lngGroupBoxMute = str.Substring(16)
            ElseIf str.StartsWith("lngCheckBoxAudioOn=", StringComparison.CurrentCulture) Then
                lngCheckBoxAudioOn = str.Substring(19)

                'PREF_BUTTON
            ElseIf str.StartsWith("lngButtonOk=", StringComparison.CurrentCulture) Then
                lngButtonOk = str.Substring(12)
            ElseIf str.StartsWith("lngButtonCancel=", StringComparison.CurrentCulture) Then
                lngButtonCancel = str.Substring(16)

                'MAINFORM_TOOLSTRIP_MENU_FILE
            ElseIf str.StartsWith("lngToolStripMenuFile=", StringComparison.CurrentCulture) Then
                lngToolStripMenuFile = str.Substring(21)
            ElseIf str.StartsWith("lngToolStripMenuFileSave=", StringComparison.CurrentCulture) Then
                lngToolStripMenuFileSave = str.Substring(25)
            ElseIf str.StartsWith("lngToolStripMenuFileRestart=", StringComparison.CurrentCulture) Then
                lngToolStripMenuFileRestart = str.Substring(28)
            ElseIf str.StartsWith("lngToolStripMenuFileExit=", StringComparison.CurrentCulture) Then
                lngToolStripMenuFileExit = str.Substring(25)
            ElseIf str.StartsWith("lngToolStripMenuItemSettingsReset=", StringComparison.CurrentCulture) Then
                lngToolStripMenuItemSettingsReset = str.Substring(34)

                'MAINFORM_TOOLSTRIP_MENU_EDIT
            ElseIf str.StartsWith("lngToolStripMenuEdit=", StringComparison.CurrentCulture) Then
                lngToolStripMenuEdit = str.Substring(21)
            ElseIf str.StartsWith("lngToolStripMenuEditOntop=", StringComparison.CurrentCulture) Then
                lngToolStripMenuEditOntop = str.Substring(26)
            ElseIf str.StartsWith("lngToolStripMenuSearch=", StringComparison.CurrentCulture) Then
                lngToolStripMenuSearch = str.Substring(23)
            ElseIf str.StartsWith("lngToolStripMenuEditPrint=", StringComparison.CurrentCulture) Then
                lngToolStripMenuEditPrint = str.Substring(26)
            ElseIf str.StartsWith("lngToolStripMenuPrintTonight=", StringComparison.CurrentCulture) Then
                lngToolStripMenuPrintTonight = str.Substring(29)
            ElseIf str.StartsWith("lngToolStripMenuCategories=", StringComparison.CurrentCulture) Then
                lngToolStripMenuCategories = str.Substring(27)
            ElseIf str.StartsWith("lngToolStripMenuDescription=", StringComparison.CurrentCulture) Then
                lngToolStripMenuDescription = str.Substring(28)
            ElseIf str.StartsWith("lngToolStripMenuCalendar=", StringComparison.CurrentCulture) Then
                lngToolStripMenuCalendar = str.Substring(25)

                'MAINFORM_TOOLSTRIP_MENU_OPTIONS
            ElseIf str.StartsWith("lngToolStripMenuOptions=", StringComparison.CurrentCulture) Then
                lngToolStripMenuOptions = str.Substring(24)
            ElseIf str.StartsWith("lngToolStripMenuOptionsUpdate=", StringComparison.CurrentCulture) Then
                lngToolStripMenuOptionsUpdate = str.Substring(30)
            ElseIf str.StartsWith("lngToolStripMenuOptionsAutoUpdate=", StringComparison.CurrentCulture) Then
                lngToolStripMenuOptionsAutoUpdate = str.Substring(34)
            ElseIf str.StartsWith("lngToolStripMenuOptionsPreferences=", StringComparison.CurrentCulture) Then
                lngToolStripMenuOptionsPreferences = str.Substring(35)
            ElseIf str.StartsWith("lngToolStripMenuOptionsLogos=", StringComparison.CurrentCulture) Then
                lngToolStripMenuOptionsLogos = str.Substring(29)
            ElseIf str.StartsWith("lngToolStripMenuOptionsDualMonitor=", StringComparison.CurrentCulture) Then
                lngToolStripMenuOptionsDualMonitor = str.Substring(35)
            ElseIf str.StartsWith("lngToolStripMenuOptionsEngineSelection=", StringComparison.CurrentCulture) Then
                lngToolStripMenuOptionsEngineSelection = str.Substring(39)

                'MAINFORM_TOOLSTRIP_MENU_HELP
            ElseIf str.StartsWith("lngToolStripMenuHelp=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelp = str.Substring(21)
            ElseIf str.StartsWith("lngToolStripMenuHelpHelptopics=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpHelptopics = str.Substring(31)
            ElseIf str.StartsWith("lngToolStripMenuHelpHelpShortcuts=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpHelpShortcuts = str.Substring(34)
            ElseIf str.StartsWith("lngToolStripMenuHelpWebsite=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpWebsite = str.Substring(28)
            ElseIf str.StartsWith("lngToolStripMenuHelpForum=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpForum = str.Substring(26)
            ElseIf str.StartsWith("lngToolStripMenuHelpCheckupdates=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpCheckupdates = str.Substring(33)
            ElseIf str.StartsWith("lngToolStripMenuHelpLanguage=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpLanguage = str.Substring(29)
            ElseIf str.StartsWith("lngToolStripMenuHelpAbout=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpAbout = str.Substring(26)
            ElseIf str.StartsWith("lngToolStripMenuHelpManualFeedBack=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpManualFeedBack = str.Substring(35)
            ElseIf str.StartsWith("lngToolStripMenuHelpDonate=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpDonate = str.Substring(27)
            ElseIf str.StartsWith("lngToolStripMenuHelpCompensation=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpCompensation = str.Substring(33)
            ElseIf str.StartsWith("lngToolStripMenuHelpContent=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpContent = str.Substring(28)
            ElseIf str.StartsWith("lngToolStripMenuHelpPlugins=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpPlugins = str.Substring(28)
            ElseIf str.StartsWith("lngToolStripMenuHelpWeather=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpWeather = str.Substring(28)
            ElseIf str.StartsWith("lngToolStripMenuHelpLocation=", StringComparison.CurrentCulture) Then
                lngToolStripMenuHelpLocation = str.Substring(29)

                'MAINFORM_TOOLSTRIP
            ElseIf str.StartsWith("lngToolStripSave=", StringComparison.CurrentCulture) Then
                lngToolStripSave = str.Substring(17)
            ElseIf str.StartsWith("lngToolStripPrint=", StringComparison.CurrentCulture) Then
                lngToolStripPrint = str.Substring(18)
            ElseIf str.StartsWith("lngToolStripSearch=", StringComparison.CurrentCulture) Then
                lngToolStripSearch = str.Substring(19)
            ElseIf str.StartsWith("lngToolStripOntop=", StringComparison.CurrentCulture) Then
                lngToolStripOntop = str.Substring(18)
            ElseIf str.StartsWith("lngToolStripPreferences=", StringComparison.CurrentCulture) Then
                lngToolStripPreferences = str.Substring(24)
            ElseIf str.StartsWith("lngToolStripLogos=", StringComparison.CurrentCulture) Then
                lngToolStripLogos = str.Substring(18)
            ElseIf str.StartsWith("lngToolStripUpdate=", StringComparison.CurrentCulture) Then
                lngToolStripUpdate = str.Substring(19)
            ElseIf str.StartsWith("lngToolStripAutoUpdate=", StringComparison.CurrentCulture) Then
                lngToolStripAutoUpdate = str.Substring(23)
            ElseIf str.StartsWith("lngToolStripCheckupdates=", StringComparison.CurrentCulture) Then
                lngToolStripCheckupdates = str.Substring(25)
            ElseIf str.StartsWith("lngToolStripDualMonitor=", StringComparison.CurrentCulture) Then
                lngToolStripDualMonitor = str.Substring(24)
            ElseIf str.StartsWith("lngToolStripWebsite=", StringComparison.CurrentCulture) Then
                lngToolStripWebsite = str.Substring(20)
            ElseIf str.StartsWith("lngToolStripForum=", StringComparison.CurrentCulture) Then
                lngToolStripForum = str.Substring(18)
            ElseIf str.StartsWith("lngToolStripLangue=", StringComparison.CurrentCulture) Then
                lngToolStripLangue = str.Substring(19)
            ElseIf str.StartsWith("lngToolStripAbout=", StringComparison.CurrentCulture) Then
                lngToolStripAbout = str.Substring(18)
            ElseIf str.StartsWith("lngToolStripHelptopics=", StringComparison.CurrentCulture) Then
                lngToolStripHelptopics = str.Substring(23)
            ElseIf str.StartsWith("lngToolStripHelpShortcuts=", StringComparison.CurrentCulture) Then
                lngToolStripHelpShortcuts = str.Substring(26)
            ElseIf str.StartsWith("lngToolStripCategories=", StringComparison.CurrentCulture) Then
                lngToolStripCategories = str.Substring(23)
            ElseIf str.StartsWith("lngToolStripDescription=", StringComparison.CurrentCulture) Then
                lngToolStripDescription = str.Substring(24)
            ElseIf str.StartsWith("lngToolStripCalendar=", StringComparison.CurrentCulture) Then
                lngToolStripCalendar = str.Substring(21)
            ElseIf str.StartsWith("lngToolStripManualFeedBack=", StringComparison.CurrentCulture) Then
                lngToolStripManualFeedBack = str.Substring(27)
            ElseIf str.StartsWith("lngToolStripTextBoxRecherche=", StringComparison.CurrentCulture) Then
                lngToolStripTextBoxRecherche = str.Substring(29)
            ElseIf str.StartsWith("lngToolStripButtonRecherche=", StringComparison.CurrentCulture) Then
                lngToolStripButtonRecherche = str.Substring(28)

                'MAINFORM_PAVE
            ElseIf str.StartsWith("lngPaveJourMoins=", StringComparison.CurrentCulture) Then
                lngPaveJourMoins = str.Substring(17)
            ElseIf str.StartsWith("lngPaveHeureMoins=", StringComparison.CurrentCulture) Then
                lngPaveHeureMoins = str.Substring(18)
            ElseIf str.StartsWith("lngPave6H=", StringComparison.CurrentCulture) Then
                lngPave6H = str.Substring(10)
            ElseIf str.StartsWith("lngPave9H=", StringComparison.CurrentCulture) Then
                lngPave9H = str.Substring(10)
            ElseIf str.StartsWith("lngPave12H=", StringComparison.CurrentCulture) Then
                lngPave12H = str.Substring(11)
            ElseIf str.StartsWith("lngPave15H=", StringComparison.CurrentCulture) Then
                lngPave15H = str.Substring(11)
            ElseIf str.StartsWith("lngPave18H=", StringComparison.CurrentCulture) Then
                lngPave18H = str.Substring(11)
            ElseIf str.StartsWith("lngPave20H=", StringComparison.CurrentCulture) Then
                lngPave20H = str.Substring(11)
            ElseIf str.StartsWith("lngPave23H=", StringComparison.CurrentCulture) Then
                lngPave23H = str.Substring(11)
            ElseIf str.StartsWith("lngPaveMaintenant=", StringComparison.CurrentCulture) Then
                lngPaveMaintenant = str.Substring(18)
            ElseIf str.StartsWith("lngPaveHeurePlus=", StringComparison.CurrentCulture) Then
                lngPaveHeurePlus = str.Substring(17)
            ElseIf str.StartsWith("lngPaveJourPlus=", StringComparison.CurrentCulture) Then
                lngPaveJourPlus = str.Substring(16)

                'MAINFORM_CESOIR_MAINTENANT
            ElseIf str.StartsWith("lngPanelTitreCesoir=", StringComparison.CurrentCulture) Then
                lngPanelTitreCesoir = str.Substring(20)
            ElseIf str.StartsWith("lngPanelTitreMaintenant=", StringComparison.CurrentCulture) Then
                lngPanelTitreMaintenant = str.Substring(24)

                'REORGCHANNEL_TITLE
            ElseIf str.StartsWith("lngReorgChannelTitle=", StringComparison.CurrentCulture) Then
                lngReorgChannelTitle = str.Substring(21)

                'REORGCHANNEL_BUTTON
            ElseIf str.StartsWith("lngButtonMonterReorgChannel=", StringComparison.CurrentCulture) Then
                lngButtonMonterReorgChannel = str.Substring(28)
            ElseIf str.StartsWith("lngButtonDescendreReorgChannel=", StringComparison.CurrentCulture) Then
                lngButtonDescendreReorgChannel = str.Substring(31)
            ElseIf str.StartsWith("lngButtonSupprimerReorgChannel=", StringComparison.CurrentCulture) Then
                lngButtonSupprimerReorgChannel = str.Substring(31)
            ElseIf str.StartsWith("lngButtonLogoReorgChannel=", StringComparison.CurrentCulture) Then
                lngButtonLogoReorgChannel = str.Substring(26)
            ElseIf str.StartsWith("lngButtonEnregistrerReorgChannel=", StringComparison.CurrentCulture) Then
                lngButtonEnregistrerReorgChannel = str.Substring(33)
            ElseIf str.StartsWith("lngButtonAnnulerReorgChannel=", StringComparison.CurrentCulture) Then
                lngButtonAnnulerReorgChannel = str.Substring(29)
            ElseIf str.StartsWith("lngReorgChannelListViewColumns0=", StringComparison.CurrentCulture) Then
                lngReorgChannelListViewColumns0 = str.Substring(32)
            ElseIf str.StartsWith("lngReorgChannelListViewColumns1=", StringComparison.CurrentCulture) Then
                lngReorgChannelListViewColumns1 = str.Substring(32)

                'FRM_ABOUT_TITLE
            ElseIf str.StartsWith("lngAboutTitle=", StringComparison.CurrentCulture) Then
                lngAboutTitle = str.Substring(14)

                'FRM_ABOUT_TABPAGE_ABOUT
            ElseIf str.StartsWith("lngTabPageAbout=", StringComparison.CurrentCulture) Then
                lngTabPageAbout = str.Substring(16)

                'FRM_ABOUT_TABPAGE_AUTHORS
            ElseIf str.StartsWith("lngTabPageAuteurs=", StringComparison.CurrentCulture) Then
                lngTabPageAuteurs = str.Substring(18)
            ElseIf str.StartsWith("lngTextBoxAdmin=", StringComparison.CurrentCulture) Then
                lngTextBoxAdmin = str.Substring(16)
            ElseIf str.StartsWith("lngTextBoxDev=", StringComparison.CurrentCulture) Then
                lngTextBoxDev = str.Substring(14)
            ElseIf str.StartsWith("lngTextBoxTesters=", StringComparison.CurrentCulture) Then
                lngTextBoxTesters = str.Substring(18)
            ElseIf str.StartsWith("lngTextBoxContributors=", StringComparison.CurrentCulture) Then
                lngTextBoxContributors = str.Substring(23)
            ElseIf str.StartsWith("lngTextBoxThanks=", StringComparison.CurrentCulture) Then
                lngTextBoxThanks = str.Substring(17)

                'FRM_ABOUT_TABPAGE_LICENCE
            ElseIf str.StartsWith("lngTabPagelicence=", StringComparison.CurrentCulture) Then
                lngTabPagelicence = str.Substring(18)

                'FRM_ABOUT_TABPAGE_7ZIP
            ElseIf str.StartsWith("lngTabPage7zip=", StringComparison.CurrentCulture) Then
                lngTabPage7zip = str.Substring(15)

                'FRM_ABOUT_TABPAGE_DONATE
            ElseIf str.StartsWith("lngTabPageDonate=", StringComparison.CurrentCulture) Then
                lngTabPageDonate = str.Substring(17)

                'FRM_LISTRECKTV_TITLE
            ElseIf str.StartsWith("lngfrmListRecKTV=", StringComparison.CurrentCulture) Then
                lngfrmListRecKTV = str.Substring(17)

                'FRM_LISTRECKTV_LISTVIEW1_COLUMN
            ElseIf str.StartsWith("lngfrmListRecKTVListView1Columns0=", StringComparison.CurrentCulture) Then
                lngfrmListRecKTVListView1Columns0 = str.Substring(34)
            ElseIf str.StartsWith("lngfrmListRecKTVListView1Columns1", StringComparison.CurrentCulture) Then
                lngfrmListRecKTVListView1Columns1 = str.Substring(34)
            ElseIf str.StartsWith("lngfrmListRecKTVListView1Columns2", StringComparison.CurrentCulture) Then
                lngfrmListRecKTVListView1Columns2 = str.Substring(34)
            ElseIf str.StartsWith("lngfrmListRecKTVListView1Columns3=", StringComparison.CurrentCulture) Then
                lngfrmListRecKTVListView1Columns3 = str.Substring(34)

                'FRM_LISTRECKTV
            ElseIf str.StartsWith("lngGroupBoxDetails=", StringComparison.CurrentCulture) Then
                lngGroupBoxDetails = str.Substring(19)
            ElseIf str.StartsWith("lngGroupBoxRepete=", StringComparison.CurrentCulture) Then
                lngGroupBoxRepete = str.Substring(18)
            ElseIf str.StartsWith("lngLabelChaine=", StringComparison.CurrentCulture) Then
                lngLabelChaine = str.Substring(15)
            ElseIf str.StartsWith("lngLabelDebut=", StringComparison.CurrentCulture) Then
                lngLabelDebut = str.Substring(14)
            ElseIf str.StartsWith("lngLabelFin=", StringComparison.CurrentCulture) Then
                lngLabelFin = str.Substring(12)
            ElseIf str.StartsWith("lngLabelProfile=", StringComparison.CurrentCulture) Then
                lngLabelProfile = str.Substring(16)
            ElseIf str.StartsWith("lngLabelNom=", StringComparison.CurrentCulture) Then
                lngLabelNom = str.Substring(12)
            ElseIf str.StartsWith("lngCmdModify=", StringComparison.CurrentCulture) Then
                lngCmdModify = str.Substring(13)
            ElseIf str.StartsWith("lngCmdDelete=", StringComparison.CurrentCulture) Then
                lngCmdDelete = str.Substring(13)
            ElseIf str.StartsWith("lngCmdAdd=", StringComparison.CurrentCulture) Then
                lngCmdAdd = str.Substring(10)
            ElseIf str.StartsWith("lngCmdCancel=", StringComparison.CurrentCulture) Then
                lngCmdCancel = str.Substring(13)
            ElseIf str.StartsWith("lngRadioButtonUnique=", StringComparison.CurrentCulture) Then
                lngRadioButtonUnique = str.Substring(21)
            ElseIf str.StartsWith("lngRadioButtonJournalier=", StringComparison.CurrentCulture) Then
                lngRadioButtonJournalier = str.Substring(25)
            ElseIf str.StartsWith("lngRadioButtonHebdo=", StringComparison.CurrentCulture) Then
                lngRadioButtonHebdo = str.Substring(20)
            ElseIf str.StartsWith("lngRadioButtonMensuel=", StringComparison.CurrentCulture) Then
                lngRadioButtonMensuel = str.Substring(22)
            ElseIf str.StartsWith("lngCheckBoxLundi=", StringComparison.CurrentCulture) Then
                lngCheckBoxLundi = str.Substring(17)
            ElseIf str.StartsWith("lngCheckBoxMardi=", StringComparison.CurrentCulture) Then
                lngCheckBoxMardi = str.Substring(17)
            ElseIf str.StartsWith("lngCheckBoxMercredi=", StringComparison.CurrentCulture) Then
                lngCheckBoxMercredi = str.Substring(20)
            ElseIf str.StartsWith("lngCheckBoxJeudi=", StringComparison.CurrentCulture) Then
                lngCheckBoxJeudi = str.Substring(17)
            ElseIf str.StartsWith("lngCheckBoxVendredi=", StringComparison.CurrentCulture) Then
                lngCheckBoxVendredi = str.Substring(20)
            ElseIf str.StartsWith("lngCheckBoxSamedi=", StringComparison.CurrentCulture) Then
                lngCheckBoxSamedi = str.Substring(18)
            ElseIf str.StartsWith("lngCheckBoxDimanche=", StringComparison.CurrentCulture) Then
                lngCheckBoxDimanche = str.Substring(20)

                'FRM_LISTRECKTV_MESSAGES
            ElseIf str.StartsWith("lngfrmListRecKTVOverlappingRec=", StringComparison.CurrentCulture) Then
                lngfrmListRecKTVOverlappingRec = str.Substring(31)
            ElseIf str.StartsWith("lngfrmListRecKTVCantWhrite=", StringComparison.CurrentCulture) Then
                lngfrmListRecKTVCantWhrite = str.Substring(27)
            ElseIf str.StartsWith("lngfrmListRecKTVParameterKtvChannel=", StringComparison.CurrentCulture) Then
                lngfrmListRecKTVParameterKtvChannel = str.Substring(34)

                'KTVFORM_TITLE
            ElseIf str.StartsWith("lngKTvForm=", StringComparison.CurrentCulture) Then
                lngKTvForm = str.Substring(11)

                'KTVFORM_LISTVIEW1_COLUMN
            ElseIf str.StartsWith("lngKTvFormListView1Columns0=", StringComparison.CurrentCulture) Then
                lngKTvFormListView1Columns0 = str.Substring(28)
            ElseIf str.StartsWith("lngKTvFormListView1Columns1=", StringComparison.CurrentCulture) Then
                lngKTvFormListView1Columns1 = str.Substring(28)
            ElseIf str.StartsWith("lngKTvFormListView1Columns2=", StringComparison.CurrentCulture) Then
                lngKTvFormListView1Columns2 = str.Substring(28)

                'KTVFORM
            ElseIf str.StartsWith("lngLabelSource=", StringComparison.CurrentCulture) Then
                lngKTvFormLabelSource = str.Substring(15)
            ElseIf str.StartsWith("lngButtonSave=", StringComparison.CurrentCulture) Then
                lngKTvFormButtonSave = str.Substring(14)
            ElseIf str.StartsWith("lngButtonClose=", StringComparison.CurrentCulture) Then
                lngKTvFormButtonClose = str.Substring(15)

                'KTVFORM_MSG_REP_KTV
            ElseIf str.StartsWith("lngMsgRepKtvTitle=", StringComparison.CurrentCulture) Then
                lngMsgRepKtvTitle = str.Substring(18)
            ElseIf str.StartsWith("lngMsgRepKtv=", StringComparison.CurrentCulture) Then
                lngMsgRepKtv = str.Substring(13)

                'KTVFORM_MSG_INI_KTV
            ElseIf str.StartsWith("lngMsgIniKtvTitle=", StringComparison.CurrentCulture) Then
                lngMsgIniKtvTitle = str.Substring(18)
            ElseIf str.StartsWith("lngMsgIniKtv=", StringComparison.CurrentCulture) Then
                lngMsgIniKtv = str.Substring(13)

                'KTVFORM_MESSAGES
            ElseIf str.StartsWith("lngKTvFormTheFile=", StringComparison.CurrentCulture) Then
                lngKTvFormTheFile = str.Substring(18)
            ElseIf str.StartsWith("lngKTvFormNoKtvFolder=", StringComparison.CurrentCulture) Then
                lngKTvFormNoKtvFolder = str.Substring(22)
            ElseIf str.StartsWith("lngKTvFormNoKtvIni=", StringComparison.CurrentCulture) Then
                lngKTvFormNoKtvIni = str.Substring(19)
            ElseIf str.StartsWith("lngKTvFormTheFolder=", StringComparison.CurrentCulture) Then
                lngKTvFormTheFolder = str.Substring(20)
            ElseIf str.StartsWith("lngKTvFormDontExist=", StringComparison.CurrentCulture) Then
                lngKTvFormDontExist = str.Substring(20)
            ElseIf str.StartsWith("lngKTvFormChannelLoadErr=", StringComparison.CurrentCulture) Then
                lngKTvFormChannelLoadErr = str.Substring(25)
            ElseIf str.StartsWith("lngKTvFormSaveKtvErr=", StringComparison.CurrentCulture) Then
                lngKTvFormSaveKtvErr = str.Substring(21)
            ElseIf str.StartsWith("lngKTvFormNoSource=", StringComparison.CurrentCulture) Then
                lngKTvFormNoSource = str.Substring(19)
            ElseIf str.StartsWith("lngKTvFormNoChannel=", StringComparison.CurrentCulture) Then
                lngKTvFormNoChannel = str.Substring(20)
            ElseIf str.StartsWith("lngKTvFormSelectZgChannel=", StringComparison.CurrentCulture) Then
                lngKTvFormSelectZgChannel = str.Substring(26)

                'FRMMISEAJOUR_TITLE
            ElseIf str.StartsWith("lngFrmMiseajour=", StringComparison.CurrentCulture) Then
                lngFrmMiseajour = str.Substring(16)

                'FRMMISEAJOUR
            ElseIf str.StartsWith("lngRadioButtonDownload=", StringComparison.CurrentCulture) Then
                lngRadioButtonDownload = str.Substring(23)
            ElseIf str.StartsWith("lngRadioButtonXmlPath=", StringComparison.CurrentCulture) Then
                lngRadioButtonXmlPath = str.Substring(22)
            ElseIf str.StartsWith("lngButtonTout=", StringComparison.CurrentCulture) Then
                lngButtonTout = str.Substring(14)
            ElseIf str.StartsWith("lngButtonSuppr=", StringComparison.CurrentCulture) Then
                lngButtonSuppr = str.Substring(15)
            ElseIf str.StartsWith("lngButtonMiseaJour=", StringComparison.CurrentCulture) Then
                lngButtonMiseaJour = str.Substring(19)
            ElseIf str.StartsWith("lngButtonDemarrer=", StringComparison.CurrentCulture) Then
                lngButtonDemarrer = str.Substring(18)
            ElseIf str.StartsWith("lngButtonAnnuler=", StringComparison.CurrentCulture) Then
                lngButtonAnnuler = str.Substring(17)
            ElseIf str.StartsWith("lngButtonEdit=", StringComparison.CurrentCulture) Then
                lngButtonEdit = str.Substring(14)
            ElseIf str.StartsWith("lngButtonForceDownload=", StringComparison.CurrentCulture) Then
                lngButtonForceDownload = str.Substring(23)
            ElseIf str.StartsWith("lngtelechargement=", StringComparison.CurrentCulture) Then
                lngtelechargement = str.Substring(18)
            ElseIf str.StartsWith("lngParsingoperation=", StringComparison.CurrentCulture) Then
                lngParsingoperation = str.Substring(20)

                'FRMMISEAJOUR_MESSAGE
            ElseIf str.StartsWith("lngErrorInChannelListRecovery=", StringComparison.CurrentCulture) Then
                lngErrorInChannelListRecovery = str.Substring(30)
            ElseIf str.StartsWith("lngNoURLUpdate=", StringComparison.CurrentCulture) Then
                lngNoURLUpdate = str.Substring(15)
            ElseIf str.StartsWith("lngInvalidURL=", StringComparison.CurrentCulture) Then
                lngInvalidURL = str.Substring(14)
            ElseIf str.StartsWith("lngUntraceableFile=", StringComparison.CurrentCulture) Then
                lngUntraceableFile = str.Substring(19)
            ElseIf str.StartsWith("lngInvalidFile=", StringComparison.CurrentCulture) Then
                lngInvalidFile = str.Substring(15)
            ElseIf str.StartsWith("lngErrorInUpdate=", StringComparison.CurrentCulture) Then
                lngErrorInUpdate = str.Substring(17)
            ElseIf str.StartsWith("lngErrorInXMLCopy=", StringComparison.CurrentCulture) Then
                lngErrorInXMLCopy = str.Substring(18)
            ElseIf str.StartsWith("lngErrorInFileCopy=", StringComparison.CurrentCulture) Then
                lngErrorInFileCopy = str.Substring(19)
            ElseIf str.StartsWith("lngErrorInUnzip=", StringComparison.CurrentCulture) Then
                lngErrorInUnzip = str.Substring(16)
            ElseIf str.StartsWith("lngWrongFileName=", StringComparison.CurrentCulture) Then
                lngWrongFileName = str.Substring(17)
            ElseIf str.StartsWith("lngFailURLFileDownload=", StringComparison.CurrentCulture) Then
                lngFailURLFileDownload = str.Substring(23)
            ElseIf str.StartsWith("lngUntraceableURLListFile=", StringComparison.CurrentCulture) Then
                lngUntraceableURLListFile = str.Substring(26)
            ElseIf str.StartsWith("lngTheFile=", StringComparison.CurrentCulture) Then
                lngTheFile = str.Substring(11)
            ElseIf str.StartsWith("lngDontExist=", StringComparison.CurrentCulture) Then
                lngDontExist = str.Substring(13)
            ElseIf str.StartsWith("lngProtectedFile=", StringComparison.CurrentCulture) Then
                lngProtectedFile = str.Substring(17)
            ElseIf str.StartsWith("lngChosenChannels=", StringComparison.CurrentCulture) Then
                lngChosenChannels = str.Substring(18)
            ElseIf str.StartsWith("lngAvailableChannels=", StringComparison.CurrentCulture) Then
                lngAvailableChannels = str.Substring(21)
            ElseIf str.StartsWith("lngChoseFile=", StringComparison.CurrentCulture) Then
                lngChoseFile = str.Substring(13)
            ElseIf str.StartsWith("lngInvalidChoice=", StringComparison.CurrentCulture) Then
                lngInvalidChoice = str.Substring(17)

                'MAINFORM_MENU_CONTEXTUEL_K!TV
            ElseIf str.StartsWith("lngToolStripMenuProgramKTV=", StringComparison.CurrentCulture) Then
                lngToolStripMenuProgramKTV = str.Substring(27)
            ElseIf str.StartsWith("lngToolStripMenuZapperKTV=", StringComparison.CurrentCulture) Then
                lngToolStripMenuZapperKTV = str.Substring(26)
            ElseIf str.StartsWith("lngToolStripMenuGestionRecordKTV=", StringComparison.CurrentCulture) Then
                lngToolStripMenuGestionRecordKTV = str.Substring(33)
            ElseIf str.StartsWith("lngToolStripMenuGestionChainesKTV=", StringComparison.CurrentCulture) Then
                lngToolStripMenuGestionChainesKTV = str.Substring(34)

                'MAINFORM_MENU_CONTEXTUEL_MMTV
            ElseIf str.StartsWith("lngToolStripMenuProgramMMTV=", StringComparison.CurrentCulture) Then
                lngToolStripMenuProgramMMTV = str.Substring(28)
            ElseIf str.StartsWith("lngToolStripMenuZapperMMTV=", StringComparison.CurrentCulture) Then
                lngToolStripMenuZapperMMTV = str.Substring(27)
            ElseIf str.StartsWith("lngToolStripMenuGestionRecordMMTV=", StringComparison.CurrentCulture) Then
                lngToolStripMenuGestionRecordMMTV = str.Substring(34)
            ElseIf str.StartsWith("lngToolStripMenuGestionChainesMMTV=", StringComparison.CurrentCulture) Then
                lngToolStripMenuGestionChainesMMTV = str.Substring(35)

                'MAINFORM_MENU_CONTEXTUEL_DESCRIPTION
            ElseIf str.StartsWith("lngToolStripMenuPrintDescript=", StringComparison.CurrentCulture) Then
                lngToolStripMenuPrintDescript = str.Substring(30)

                'MAINFORM_MESSAGE_PROXY
            ElseIf str.StartsWith("lngMsgProxyTitle=", StringComparison.CurrentCulture) Then
                lngMsgProxyTitle = str.Substring(17)
            ElseIf str.StartsWith("lngMsgProxy=", StringComparison.CurrentCulture) Then
                lngMsgProxy = str.Substring(12)

                'MAINFORM_NOTIFYICON1_BALLOONTIP
            ElseIf str.StartsWith("lngNotifyIcon1BalloonTipTitle=", StringComparison.CurrentCulture) Then
                lngNotifyIcon1BalloonTipTitle = str.Substring(30)
            ElseIf str.StartsWith("lngNotifyIcon1=", StringComparison.CurrentCulture) Then
                lngNotifyIcon1 = str.Substring(15)

                ' MAINFORM TREEVIEW NODES
            ElseIf str.StartsWith("lngNodeFilter=", StringComparison.CurrentCulture) Then
                lngNodeFilter = str.Substring(14)
            ElseIf str.StartsWith("lngNodeCategory=", StringComparison.CurrentCulture) Then
                lngNodeCategory = str.Substring(16)
            ElseIf str.StartsWith("lngNodeCountry=", StringComparison.CurrentCulture) Then
                lngNodeCountry = str.Substring(15)
            ElseIf str.StartsWith("lngNodeProvider=", StringComparison.CurrentCulture) Then
                lngNodeProvider = str.Substring(16)

                'MESSAGEBOXBASEPERIMEE
            ElseIf str.StartsWith("lngMessageBoxBasePerimee=", StringComparison.CurrentCulture) Then
                lngMessageBoxBasePerimee = str.Substring(25)
            ElseIf str.StartsWith("lngMessageBoxBasePerimee1=", StringComparison.CurrentCulture) Then
                lngMessageBoxBasePerimee1 = str.Substring(26)
            ElseIf str.StartsWith("lngMessageBoxBasePerimeeTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxBasePerimeeTitre = str.Substring(30)

                'MESSAGEBOXCODEPIN
            ElseIf str.StartsWith("lngMessageBoxNoCodePin=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoCodePin = str.Substring(23)
            ElseIf str.StartsWith("lngMessageBoxNoCodePin1=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoCodePin1 = str.Substring(24)
            ElseIf str.StartsWith("lngMessageBoxNoCodePinTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoCodePinTitre = str.Substring(28)

                'MESSAGEBOXNOUPDATE
            ElseIf str.StartsWith("lngMessageBoxnoupdate=", StringComparison.CurrentCulture) Then
                lngMessageBoxnoupdate = str.Substring(22)
            ElseIf str.StartsWith("lngMessageBoxnoupdateTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxnoupdateTitre = str.Substring(27)

                'MESSAGEBOXMISEAJOUR
            ElseIf str.StartsWith("lngMessageBoxMiseaJour=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJour = str.Substring(23)
            ElseIf str.StartsWith("lngMessageBoxMiseaJour1=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJour1 = str.Substring(24)
            ElseIf str.StartsWith("lngMessageBoxMiseaJourTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJourTitre = str.Substring(28)

                'MESSAGEBOXMISEAJOURDONE
            ElseIf str.StartsWith("lngMessageBoxMiseaJourDone=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJourDone = str.Substring(27)
            ElseIf str.StartsWith("lngMessageBoxMiseaJour1Done=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJour1Done = str.Substring(28)
            ElseIf str.StartsWith("lngMessageBoxMiseaJourTitreDone=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJourTitreDone = str.Substring(32)

                'MESSAGEBOXMODIFPREF
            ElseIf str.StartsWith("lngMessageBoxModifPref=", StringComparison.CurrentCulture) Then
                lngMessageBoxModifPref = str.Substring(23)
            ElseIf str.StartsWith("lngMessageBoxModifPref1=", StringComparison.CurrentCulture) Then
                lngMessageBoxModifPref1 = str.Substring(24)
            ElseIf str.StartsWith("lngMessageBoxModifPrefTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxModifPrefTitre = str.Substring(28)

                'MESSAGEBOXNOCONNECTION
            ElseIf str.StartsWith("lngMessageBoxNoConnection=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoConnection = str.Substring(26)
            ElseIf str.StartsWith("lngMessageBoxNoConnection1=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoConnection1 = str.Substring(27)
            ElseIf str.StartsWith("lngMessageBoxNoConnectionTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoConnectionTitre = str.Substring(31)

                'MESSAGEBOXFEEDBACK
            ElseIf str.StartsWith("lngMessageBoxFeedback=", StringComparison.CurrentCulture) Then
                lngMessageBoxFeedback = str.Substring(22)
            ElseIf str.StartsWith("lngMessageBoxFeedbackTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxFeedbackTitre = str.Substring(27)

                'MESSAGEBOXFICHIERCORROMPU
            ElseIf str.StartsWith("lngMessageFichierCorrompu=", StringComparison.CurrentCulture) Then
                lngMessageFichierCorrompu = str.Substring(26)
            ElseIf str.StartsWith("lngMessageFichierCorrompu1=", StringComparison.CurrentCulture) Then
                lngMessageFichierCorrompu1 = str.Substring(27)
            ElseIf str.StartsWith("lngMessageFichierCorrompu2=", StringComparison.CurrentCulture) Then
                lngMessageFichierCorrompu2 = str.Substring(27)
            ElseIf str.StartsWith("lngMessageFichierCorrompuTitre=", StringComparison.CurrentCulture) Then
                lngMessageFichierCorrompuTitre = str.Substring(31)

                'MESSAGEBOXLISTXMLTVFRCHOISIE
            ElseIf str.StartsWith("lngMessageBoxListXMLTVFRChoisie=", StringComparison.CurrentCulture) Then
                lngMessageBoxListXMLTVFRChoisie = str.Substring(32)
            ElseIf str.StartsWith("lngMessageBoxListXMLTVFRChoisie1=", StringComparison.CurrentCulture) Then
                lngMessageBoxListXMLTVFRChoisie1 = str.Substring(33)
            ElseIf str.StartsWith("lngMessageBoxListXMLTVFRChoisieTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxListXMLTVFRChoisieTitre = str.Substring(37)

                'MESSAGEBOXTHETVDBNORESULT
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoResult=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoResult = str.Substring(29)
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoResultTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoResultTitre = str.Substring(34)

                'MESSAGEBOXTHETVDBVALIDESERIEID
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoValidSeriesId=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoValidSeriesId = str.Substring(36)
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoValidSeriesIdTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoValidSeriesIdTitre = str.Substring(41)

                'THETVDBBOXNOSHEET
            ElseIf str.StartsWith("lngThetvdbBoxNoSheet=", StringComparison.CurrentCulture) Then
                lngThetvdbBoxNoSheet = str.Substring(21)
            ElseIf str.StartsWith("lngThetvdbBoxNoSheetTitre=", StringComparison.CurrentCulture) Then
                lngThetvdbBoxNoSheetTitre = str.Substring(26)

                'MESSAGEBOXTHETVDBNOSERIEDETAIL
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoSerieDetail=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoSerieDetail = str.Substring(34)
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoSerieDetailTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoSerieDetailTitre = str.Substring(39)

                'MESSAGEBOXTHETVDBNOACTORINFO
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoActorInfo=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoActorInfo = str.Substring(32)
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoActorInfoTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoActorInfoTitre = str.Substring(37)

                'MESSAGEBOXTHETVDBNOBANNER
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoBanner=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoBanner = str.Substring(32)
            ElseIf str.StartsWith("lngMessageBoxThetvdbNoNoBannerTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxThetvdbNoBannerTitre = str.Substring(37)

                'MESSAGEBOXMESSAGEENVOYE
            ElseIf str.StartsWith("lngMessageBoxMessageEnvoye=", StringComparison.CurrentCulture) Then
                lngMessageBoxMessageEnvoye = str.Substring(27)
            ElseIf str.StartsWith("lngMessageBoxMessageEnvoyeTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxMessageEnvoyeTitre = str.Substring(32)

                'MESSAGEBOXEPGDATA
            ElseIf str.StartsWith("lngMessageBoxEPGData=", StringComparison.CurrentCulture) Then
                lngMessageBoxEPGData = str.Substring(21)
            ElseIf str.StartsWith("lngMessageBoxEPGData1=", StringComparison.CurrentCulture) Then
                lngMessageBoxEPGData1 = str.Substring(22)
            ElseIf str.StartsWith("lngMessageBoxEPGDataTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxEPGDataTitre = str.Substring(26)

                'MESSAGEBOXFILERESTORE
            ElseIf str.StartsWith("lngMessageBoxFileRestoreTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxFileRestoreTitre = str.Substring(30)
            ElseIf str.StartsWith("lngMessageBoxFileRestore=", StringComparison.CurrentCulture) Then
                lngMessageBoxFileRestore = str.Substring(25)
            ElseIf str.StartsWith("lngMessageBoxFileRestore1=", StringComparison.CurrentCulture) Then
                lngMessageBoxFileRestore1 = str.Substring(26)
            ElseIf str.StartsWith("lngMessageBoxFileRestore2=", StringComparison.CurrentCulture) Then
                lngMessageBoxFileRestore2 = str.Substring(26)

                'MESSAGEBOXNORESTORESELECTED
            ElseIf str.StartsWith("lngMessageBoxNoRestoreSelectedTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoRestoreSelectedTitre = str.Substring(36)
            ElseIf str.StartsWith("lngMessageBoxNoRestoreSelected=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoRestoreSelected = str.Substring(31)

                'MESSAGEBOXNORESTOREELEMENT
            ElseIf str.StartsWith("lngMessageBoxNoRestoreElementTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoRestoreElementTitre = str.Substring(35)
            ElseIf str.StartsWith("lngMessageBoxNoRestoreElement=", StringComparison.CurrentCulture) Then
                lngMessageBoxNoRestoreElement = str.Substring(30)

                'MESSAGEBOXEPGDATANOSUBSCRIPTION
            ElseIf str.StartsWith("lngMessageBoxEPGDataSubscription=", StringComparison.CurrentCulture) Then
                lngMessageBoxEPGDataSubscription = str.Substring(33)
            ElseIf str.StartsWith("lngMessageBoxEPGDataSubscription1=", StringComparison.CurrentCulture) Then
                lngMessageBoxEPGDataSubscription1 = str.Substring(34)
            ElseIf str.StartsWith("lngMessageBoxEPGDataSubscriptionTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxEPGDataSubscriptionTitre = str.Substring(38)

                'MESSAGEBOXREORGCHANNEL
            ElseIf str.StartsWith("lngMessageBoxReorgChannel=", StringComparison.CurrentCulture) Then
                lngMessageBoxReorgChannel = str.Substring(26)
            ElseIf str.StartsWith("lngMessageBoxReorgChannel1=", StringComparison.CurrentCulture) Then
                lngMessageBoxReorgChannel1 = str.Substring(27)
            ElseIf str.StartsWith("lngMessageBoxReorgChannelTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxReorgChannelTitre = str.Substring(31)

                'MESSAGEBOXRESUME
            ElseIf str.StartsWith("lngMessageBoxResume=", StringComparison.CurrentCulture) Then
                lngMessageBoxResume = str.Substring(20)
            ElseIf str.StartsWith("lngMessageBoxResume1=", StringComparison.CurrentCulture) Then
                lngMessageBoxResume1 = str.Substring(21)
            ElseIf str.StartsWith("lngMessageBoxResumeTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxResumeTitre = str.Substring(25)

                'MESSAGEBOXRAZ
            ElseIf str.StartsWith("lngMessageBoxRaz=", StringComparison.CurrentCulture) Then
                lngMessageBoxRaz = str.Substring(17)
            ElseIf str.StartsWith("lngMessageBoxRaz1=", StringComparison.CurrentCulture) Then
                lngMessageBoxRaz1 = str.Substring(18)
            ElseIf str.StartsWith("lngMessageBoxTitleRaz=", StringComparison.CurrentCulture) Then
                lngMessageBoxTitleRaz = str.Substring(22)

                'MESSAGEBOXMISEAJOUREXE
            ElseIf str.StartsWith("lngMessageBoxMiseaJourExe=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJourExe = str.Substring(26)
            ElseIf str.StartsWith("lngMessageBoxMiseaJourExe1=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJourExe1 = str.Substring(27)
            ElseIf str.StartsWith("lngMessageBoxMiseaJourExeTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxMiseaJourExeTitre = str.Substring(31)

                'MESSAGEBOXDIRCHECKED
            ElseIf str.StartsWith("lngMessageBoxDirChecked=", StringComparison.CurrentCulture) Then
                lngMessageBoxDirChecked = str.Substring(24)
            ElseIf str.StartsWith("lngMessageBoxDirChecked1=", StringComparison.CurrentCulture) Then
                lngMessageBoxDirChecked1 = str.Substring(25)
            ElseIf str.StartsWith("lngMessageBoxDirCheckedTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxDirCheckedTitre = str.Substring(29)

                'MESSAGEBOXFILENOTEXIST
            ElseIf str.StartsWith("lngMessageBoxFileNotExist=", StringComparison.CurrentCulture) Then
                lngMessageBoxFileNotExist = str.Substring(26)
            ElseIf str.StartsWith("lngMessageBoxFileNotExist1=", StringComparison.CurrentCulture) Then
                lngMessageBoxFileNotExist1 = str.Substring(27)
            ElseIf str.StartsWith("lngMessageBoxFileNotExistTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxFileNotExistTitre = str.Substring(31)

                'MESSAGEBOXURLCHECKED
            ElseIf str.StartsWith("lngMessageBoxURLChecked=", StringComparison.CurrentCulture) Then
                lngMessageBoxURLChecked = str.Substring(24)
            ElseIf str.StartsWith("lngMessageBoxURLChecked1=", StringComparison.CurrentCulture) Then
                lngMessageBoxURLChecked1 = str.Substring(25)
            ElseIf str.StartsWith("lngMessageBoxURLCheckedTitre=", StringComparison.CurrentCulture) Then
                lngMessageBoxURLCheckedTitre = str.Substring(29)

                'MISEAJOURAUTO
            ElseIf str.StartsWith("lngMiseAJourAutoTitle=", StringComparison.CurrentCulture) Then
                lngMiseAJourAutoTitle = str.Substring(22)
            ElseIf str.StartsWith("lngNode_number=", StringComparison.CurrentCulture) Then
                lngNode_number = str.Substring(15)
            ElseIf str.StartsWith("lngAuto_update_operation=", StringComparison.CurrentCulture) Then
                lngAuto_update_operation = str.Substring(25)
            ElseIf str.StartsWith("lngdwnl_operation=", StringComparison.CurrentCulture) Then
                lngdwnl_operation = str.Substring(18)
            ElseIf str.StartsWith("lngParsing_operation=", StringComparison.CurrentCulture) Then
                lngParsing_operation = str.Substring(21)
            ElseIf str.StartsWith("lngremaining_time=", StringComparison.CurrentCulture) Then
                lngremaining_time = str.Substring(18)
            ElseIf str.StartsWith("lngfile_size=", StringComparison.CurrentCulture) Then
                lngfile_size = str.Substring(13)

                'MISEAJOURAUTO_MESSAGE
            ElseIf str.StartsWith("lngError1_majauto=", StringComparison.CurrentCulture) Then
                lngError1_majauto = str.Substring(18)
            ElseIf str.StartsWith("lngError2_majauto=", StringComparison.CurrentCulture) Then
                lngError2_majauto = str.Substring(18)
            ElseIf str.StartsWith("lngError3_majauto=", StringComparison.CurrentCulture) Then
                lngError3_majauto = str.Substring(18)
            ElseIf str.StartsWith("lngError4_majauto=", StringComparison.CurrentCulture) Then
                lngError4_majauto = str.Substring(18)
            ElseIf str.StartsWith("lngError5_majauto=", StringComparison.CurrentCulture) Then
                lngError5_majauto = str.Substring(18)
            ElseIf str.StartsWith("lngError6_majauto=", StringComparison.CurrentCulture) Then
                lngError6_majauto = str.Substring(18)

                'NOTIFYICON
            ElseIf str.StartsWith("lngBalloonText1=", StringComparison.CurrentCulture) Then
                lngBalloonText1 = str.Substring(16)
            ElseIf str.StartsWith("lngBalloonText3=", StringComparison.CurrentCulture) Then
                lngBalloonText3 = str.Substring(16)

                'SYSTRAY
            ElseIf str.StartsWith("lngSystrayMenuRestore=", StringComparison.CurrentCulture) Then
                lngSystrayMenuRestore = str.Substring(22)
            ElseIf str.StartsWith("lngSystrayMenuExit=", StringComparison.CurrentCulture) Then
                lngSystrayMenuExit = str.Substring(19)

                'TRI_AVANCE
            ElseIf str.StartsWith("lngTriAvanceTitle=", StringComparison.CurrentCulture) Then
                lngTriAvanceTitle = str.Substring(18)
            ElseIf str.StartsWith("lngTriAvanceLabeltitre=", StringComparison.CurrentCulture) Then
                lngTriAvanceLabeltitre = str.Substring(23)
            ElseIf str.StartsWith("lngTriAvanceLabelauteur=", StringComparison.CurrentCulture) Then
                lngTriAvanceLabelauteur = str.Substring(24)
            ElseIf str.StartsWith("lngTriAvanceLabelndefini=", StringComparison.CurrentCulture) Then
                lngTriAvanceLabelndefini = str.Substring(25)
            ElseIf str.StartsWith("lngTriAvanceButtonSearch=", StringComparison.CurrentCulture) Then
                lngTriAvanceButtonSearch = str.Substring(25)
            ElseIf str.StartsWith("lngtTriAvanceButtonCancel=", StringComparison.CurrentCulture) Then
                lngtTriAvanceButtonCancel = str.Substring(26)
            ElseIf str.StartsWith("lngTriAvanceGroupBoxCriteres=", StringComparison.CurrentCulture) Then
                lngTriAvanceGroupBoxCriteres = str.Substring(29)
            ElseIf str.StartsWith("lngTriAvanceCheckBoxNow=", StringComparison.CurrentCulture) Then
                lngTriAvanceCheckBoxNow = str.Substring(24)
            ElseIf str.StartsWith("lngTriAvanceCheckBoxBegin=", StringComparison.CurrentCulture) Then
                lngTriAvanceCheckBoxBegin = str.Substring(26)
            ElseIf str.StartsWith("lngTriAvanceListViewColumns0=", StringComparison.CurrentCulture) Then
                lngTriAvanceListViewColumns0 = str.Substring(29)
            ElseIf str.StartsWith("lngTriAvanceListViewColumns1=", StringComparison.CurrentCulture) Then
                lngTriAvanceListViewColumns1 = str.Substring(29)
            ElseIf str.StartsWith("lngTriAvanceListViewColumns2=", StringComparison.CurrentCulture) Then
                lngTriAvanceListViewColumns2 = str.Substring(29)
            ElseIf str.StartsWith("lngTriAvanceListViewColumns3=", StringComparison.CurrentCulture) Then
                lngTriAvanceListViewColumns3 = str.Substring(29)
            ElseIf str.StartsWith("lngTriAvanceListViewColumns4=", StringComparison.CurrentCulture) Then
                lngTriAvanceListViewColumns4 = str.Substring(29)

                'CALENDRIER
            ElseIf str.StartsWith("lngCalendarLundiLabel=", StringComparison.CurrentCulture) Then
                lngCalendarLundiLabel = str.Substring(22)
            ElseIf str.StartsWith("lngCalendarMardiLabel=", StringComparison.CurrentCulture) Then
                lngCalendarMardiLabel = str.Substring(22)
            ElseIf str.StartsWith("lngCalendarMercrediLabel=", StringComparison.CurrentCulture) Then
                lngCalendarMercrediLabel = str.Substring(25)
            ElseIf str.StartsWith("lngCalendarJeudiLabel=", StringComparison.CurrentCulture) Then
                lngCalendarJeudiLabel = str.Substring(22)
            ElseIf str.StartsWith("lngCalendarVendrediLabel=", StringComparison.CurrentCulture) Then
                lngCalendarVendrediLabel = str.Substring(25)
            ElseIf str.StartsWith("lngCalendarSamediLabel=", StringComparison.CurrentCulture) Then
                lngCalendarSamediLabel = str.Substring(23)
            ElseIf str.StartsWith("lngCalendarDimancheLabel=", StringComparison.CurrentCulture) Then
                lngCalendarDimancheLabel = str.Substring(25)

            ElseIf str.StartsWith("lngNameofMonth1=", StringComparison.CurrentCulture) Then
                lngNameofMonth1 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth2=", StringComparison.CurrentCulture) Then
                lngNameofMonth2 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth3=", StringComparison.CurrentCulture) Then
                lngNameofMonth3 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth4=", StringComparison.CurrentCulture) Then
                lngNameofMonth4 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth5=", StringComparison.CurrentCulture) Then
                lngNameofMonth5 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth6=", StringComparison.CurrentCulture) Then
                lngNameofMonth6 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth7=", StringComparison.CurrentCulture) Then
                lngNameofMonth7 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth8=", StringComparison.CurrentCulture) Then
                lngNameofMonth8 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth9=", StringComparison.CurrentCulture) Then
                lngNameofMonth9 = str.Substring(16)
            ElseIf str.StartsWith("lngNameofMonth10=", StringComparison.CurrentCulture) Then
                lngNameofMonth10 = str.Substring(17)
            ElseIf str.StartsWith("lngNameofMonth11=", StringComparison.CurrentCulture) Then
                lngNameofMonth11 = str.Substring(17)
            ElseIf str.StartsWith("lngNameofMonth12=", StringComparison.CurrentCulture) Then
                lngNameofMonth12 = str.Substring(17)

                'DESCRIPTBOX
            ElseIf str.StartsWith("lngDescriptLundiLabel=", StringComparison.CurrentCulture) Then
                lngDescriptLundiLabel = str.Substring(22)
            ElseIf str.StartsWith("lngDescriptMardiLabel=", StringComparison.CurrentCulture) Then
                lngDescriptMardiLabel = str.Substring(22)
            ElseIf str.StartsWith("lngDescriptMercrediLabel=", StringComparison.CurrentCulture) Then
                lngDescriptMercrediLabel = str.Substring(25)
            ElseIf str.StartsWith("lngDescriptJeudiLabel=", StringComparison.CurrentCulture) Then
                lngDescriptJeudiLabel = str.Substring(22)
            ElseIf str.StartsWith("lngDescriptVendrediLabel=", StringComparison.CurrentCulture) Then
                lngDescriptVendrediLabel = str.Substring(25)
            ElseIf str.StartsWith("lngDescriptSamediLabel=", StringComparison.CurrentCulture) Then
                lngDescriptSamediLabel = str.Substring(23)
            ElseIf str.StartsWith("lngDescriptDimancheLabel=", StringComparison.CurrentCulture) Then
                lngDescriptDimancheLabel = str.Substring(25)

                'FEEDBACK
            ElseIf str.StartsWith("lngFeedback_Title=", StringComparison.CurrentCulture) Then
                lngFeedback_Title = str.Substring(18)
            ElseIf str.StartsWith("lngLabelExceptMessage1=", StringComparison.CurrentCulture) Then
                lngLabelExceptMessage1 = str.Substring(23)
            ElseIf str.StartsWith("lngLabelExceptMessage2=", StringComparison.CurrentCulture) Then
                lngLabelExceptMessage2 = str.Substring(23)
            ElseIf str.StartsWith("lngLabelExceptMessage3=", StringComparison.CurrentCulture) Then
                lngLabelExceptMessage3 = str.Substring(23)
            ElseIf str.StartsWith("lngCheckBoxExceptErrorMessage=", StringComparison.CurrentCulture) Then
                lngCheckBoxExceptErrorMessage = str.Substring(30)
            ElseIf str.StartsWith("lngLabelEmail=", StringComparison.CurrentCulture) Then
                lngLabelEmail = str.Substring(14)
            ElseIf str.StartsWith("lngSend_Button=", StringComparison.CurrentCulture) Then
                lngSend_Button = str.Substring(15)
            ElseIf str.StartsWith("lngCopier_Button=", StringComparison.CurrentCulture) Then
                lngCopier_Button = str.Substring(17)
            ElseIf str.StartsWith("lngExit_Button=", StringComparison.CurrentCulture) Then
                lngExit_Button = str.Substring(15)
            ElseIf str.StartsWith("lngExceptErrorMessage=", StringComparison.CurrentCulture) Then
                lngExceptErrorMessage = str.Substring(22)
            ElseIf str.StartsWith("lngLabelFeedbackSend=", StringComparison.CurrentCulture) Then
                lngLabelFeedbackSend = str.Substring(21)
            ElseIf str.StartsWith("lngZGuideTVRelease=", StringComparison.CurrentCulture) Then
                lngZGuideTVRelease = str.Substring(19)
            ElseIf str.StartsWith("lngCompilationDate=", StringComparison.CurrentCulture) Then
                lngCompilationDate = str.Substring(19)
            ElseIf str.StartsWith("lngOSRelease=", StringComparison.CurrentCulture) Then
                lngOSRelease = str.Substring(13)
            ElseIf str.StartsWith("lngArchitecture=", StringComparison.CurrentCulture) Then
                lngArchitecture = str.Substring(16)
            ElseIf str.StartsWith("lngOSBootMode=", StringComparison.CurrentCulture) Then
                lngOSBootMode = str.Substring(14)
            ElseIf str.StartsWith("lngFramework=", StringComparison.CurrentCulture) Then
                lngFramework = str.Substring(13)
            ElseIf str.StartsWith("lngOSLanguage=", StringComparison.CurrentCulture) Then
                lngOSLanguage = str.Substring(14)
            ElseIf str.StartsWith("lngTotalMemory=", StringComparison.CurrentCulture) Then
                lngTotalMemory = str.Substring(15)
            ElseIf str.StartsWith("lngRemainingMemory=", StringComparison.CurrentCulture) Then
                lngRemainingMemory = str.Substring(19)
            ElseIf str.StartsWith("lngUsedMemory=", StringComparison.CurrentCulture) Then
                lngUsedMemory = str.Substring(14)
            ElseIf str.StartsWith("lngProcessorName=", StringComparison.CurrentCulture) Then
                lngProcessorName = str.Substring(17)
            ElseIf str.StartsWith("lngProcessorNumber=", StringComparison.CurrentCulture) Then
                lngProcessorNumber = str.Substring(19)
            ElseIf str.StartsWith("lngMonitorNumber=", StringComparison.CurrentCulture) Then
                lngMonitorNumber = str.Substring(17)
            ElseIf str.StartsWith("lngEmail=", StringComparison.CurrentCulture) Then
                lngEmail = str.Substring(9)
            ElseIf str.StartsWith("lngComments=", StringComparison.CurrentCulture) Then
                lngComments = str.Substring(12)
            ElseIf str.StartsWith("lngDescriptionError=", StringComparison.CurrentCulture) Then
                lngDescriptionError = str.Substring(20)
            ElseIf str.StartsWith("lngProcessorSpeed=", StringComparison.CurrentCulture) Then
                lngProcessorSpeed = str.Substring(18)
            ElseIf str.StartsWith("lngCheckBoxAcknowledgment=", StringComparison.CurrentCulture) Then
                lngCheckBoxAcknowledgment = str.Substring(26)
            ElseIf str.StartsWith("lngProcessorDescription=", StringComparison.CurrentCulture) Then
                lngProcessorDescription = str.Substring(24)

                'THETVDBTAB
            ElseIf str.StartsWith("lngThetvdbLabelSeriesTabSeries=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelSeriesTabSeries = str.Substring(31)
            ElseIf str.StartsWith("lngThetvdbLabelEpisodesTabEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelEpisodesTabEpisodes = str.Substring(35)
            ElseIf str.StartsWith("lngThetvdbLabelActorsTabActors=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelActorsTabActors = str.Substring(31)

                'THETVDB
            ElseIf str.StartsWith("lngThetvdbLabelSiteRating=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelSiteRating = str.Substring(26)
            ElseIf str.StartsWith("lngThetvdbLabelID=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelID = str.Substring(18)
            ElseIf str.StartsWith("lngThetvdbLabelID1=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelID1 = str.Substring(19)
            ElseIf str.StartsWith("lngThetvdbLabelRuntime=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelRuntime = str.Substring(23)
            ElseIf str.StartsWith("lngThetvdbLabelRating=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelRating = str.Substring(22)
            ElseIf str.StartsWith("lngThetvdbLabelSearchName=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelSearchName = str.Substring(26)
            ElseIf str.StartsWith("lngThetvdbLabelLanguage=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelLanguage = str.Substring(24)
            ElseIf str.StartsWith("lngThetvdbButtonSearch=", StringComparison.CurrentCulture) Then
                lngThetvdbButtonSearch = str.Substring(23)
            ElseIf str.StartsWith("lngThetvdbButtonSearchShow=", StringComparison.CurrentCulture) Then
                lngThetvdbButtonSearchShow = str.Substring(27)
            ElseIf str.StartsWith("lngThetvdbButtonExit=", StringComparison.CurrentCulture) Then
                lngThetvdbButtonExit = str.Substring(21)
            ElseIf str.StartsWith("lngThetvdbLabelDescription=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelDescription = str.Substring(27)
            ElseIf str.StartsWith("lngThetvdbLabelStatus=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelStatus = str.Substring(22)
            ElseIf str.StartsWith("lngThetvdbLabelGenre=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelGenre = str.Substring(21)
            ElseIf str.StartsWith("lngThetvdbLabelActors=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelActors = str.Substring(22)
            ElseIf str.StartsWith("lngThetvdbLabelActors1=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelActors1 = str.Substring(23)
            ElseIf str.StartsWith("lngThetvdbLabelGueststar=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelGueststar = str.Substring(25)
            ElseIf str.StartsWith("lngThetvdbLabelDirector=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelDirector = str.Substring(24)
            ElseIf str.StartsWith("lngThetvdbLabelWriter=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelWriter = str.Substring(22)
            ElseIf str.StartsWith("lngThetvdbLabelEpisodeDescription=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelEpisodeDescription = str.Substring(34)
            ElseIf str.StartsWith("lngThetvdbLabelFirstAired=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelFirstAired = str.Substring(26)
            ElseIf str.StartsWith("lngThetvdbLabelIDTVCom=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelIDTVCom = str.Substring(23)
            ElseIf str.StartsWith("lngThetvdbLabelIDIMDBCom=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelIDIMDBCom = str.Substring(25)
            ElseIf str.StartsWith("lngThetvdbLabelForceUpdate=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelForceUpdate = str.Substring(27)
            ElseIf str.StartsWith("lngThetvdbLabelZap2it=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelZap2it = str.Substring(22)
            ElseIf str.StartsWith("lngThetvdbButtonLoad=", StringComparison.CurrentCulture) Then
                lngThetvdbButtonLoad = str.Substring(21)
            ElseIf str.StartsWith("lngThetvdbButtonCancel=", StringComparison.CurrentCulture) Then
                lngThetvdbButtonCancel = str.Substring(23)
            ElseIf str.StartsWith("lngThetvdbLabelLoadFull=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelLoadFull = str.Substring(24)
            ElseIf str.StartsWith("lngThetvdbLabelLoadActors=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelLoadActors = str.Substring(26)
            ElseIf str.StartsWith("lngThetvdbLabelBanner=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelBanner = str.Substring(22)
            ElseIf str.StartsWith("lngThetvdbLabelUseZipped=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelUseZipped = str.Substring(25)
            ElseIf str.StartsWith("lngThetvdbLabelOpen=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelOpen = str.Substring(20)
            ElseIf str.StartsWith("lngThetvdbLabelEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelEpisodes = str.Substring(24)

                'THETVDBTABEPISODE
            ElseIf str.StartsWith("lngThetvdbLabelAbsoluteNumberTabEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelAbsoluteNumberTabEpisodes = str.Substring(41)
            ElseIf str.StartsWith("lngThetvdbLabelProductCodeTabEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelProductCodeTabEpisodes = str.Substring(38)
            ElseIf str.StartsWith("lngThetvdbLabelDVDIDTabEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelDVDIDTabEpisodes = str.Substring(32)
            ElseIf str.StartsWith("lngThetvdbLabelDVDSeasonTabEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelDVDSeasonTabEpisodes = str.Substring(36)
            ElseIf str.StartsWith("lngThetvdbLabelDVDNumberTabEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelDVDNumberTabEpisodes = str.Substring(36)
            ElseIf str.StartsWith("lngThetvdbLabelDVDChapterTabEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelDVDChapterTabEpisodes = str.Substring(37)
            ElseIf str.StartsWith("lngThetvdbNodeSeasonTabEpisodes=", StringComparison.CurrentCulture) Then
                lngThetvdbNodeSeasonTabEpisodes = str.Substring(32)

                'THETVDBTABACTORS
            ElseIf str.StartsWith("lngThetvdbGroupBoxInformationTabActors=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelIDTabActors = str.Substring(39)
            ElseIf str.StartsWith("lngThetvdbLabelIDTabActors=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelIDTabActors = str.Substring(27)
            ElseIf str.StartsWith("lngThetvdbLabelNameTabActors=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelNameTabActors = str.Substring(29)
            ElseIf str.StartsWith("lngThetvdbLabelRoleTabActors=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelRoleTabActors = str.Substring(29)
            ElseIf str.StartsWith("lngThetvdbLabelSortOrderTabActors=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelSortOrderTabActors = str.Substring(34)

                'THETVDBRESULT
            ElseIf str.StartsWith("lngThetvdbGroupBoxResult=", StringComparison.CurrentCulture) Then
                lngThetvdbGroupBoxResult = str.Substring(25)
            ElseIf str.StartsWith("lngThetvdbLabelFirstAiredResult=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelFirstAiredResult = str.Substring(32)
            ElseIf str.StartsWith("lngThetvdbLabelIMDBIdResult=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelIMDBIdResult = str.Substring(28)
            ElseIf str.StartsWith("lngThetvdbLabelOverviewResult=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelOverviewResult = str.Substring(30)
            ElseIf str.StartsWith("lngThetvdbLabelStatusResult=", StringComparison.CurrentCulture) Then
                lngThetvdbLabelStatusResult = str.Substring(28)
            ElseIf str.StartsWith("lngThetvdbButtonChooseResult=", StringComparison.CurrentCulture) Then
                lngThetvdbButtonChooseResult = str.Substring(29)
            ElseIf str.StartsWith("lngThetvdbButtonCancelResult=", StringComparison.CurrentCulture) Then
                lngThetvdbButtonCancelResult = str.Substring(29)
            ElseIf str.StartsWith("lngThetvdbListviewResultColumns0=", StringComparison.CurrentCulture) Then
                lngThetvdbListviewResultColumns0 = str.Substring(33)
            ElseIf str.StartsWith("lngThetvdbListviewResultColumns1=", StringComparison.CurrentCulture) Then
                lngThetvdbListviewResultColumns1 = str.Substring(33)
            ElseIf str.StartsWith("lngThetvdbListviewResultColumns2=", StringComparison.CurrentCulture) Then
                lngThetvdbListviewResultColumns2 = str.Substring(33)

                'RICHTEXTBOXDESCRIP
            ElseIf str.StartsWith("lngRichTextBoxDescripFrom=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripFrom = str.Substring(26)
            ElseIf str.StartsWith("lngRichTextBoxDescripTo=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripTo = str.Substring(24)
            ElseIf str.StartsWith("lngRichTextBoxDescripDescrip=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripDescrip = str.Substring(29)
            ElseIf str.StartsWith("lngRichTextBoxDescripActors=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripActors = str.Substring(28)
            ElseIf str.StartsWith("lngRichTextBoxDescripCategory=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripCategory = str.Substring(30)
            ElseIf str.StartsWith("lngRichTextBoxDescripProductionDate=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripProductionDate = str.Substring(36)
            ElseIf str.StartsWith("lngRichTextBoxDescripDuree=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripDuree = str.Substring(27)
            ElseIf str.StartsWith("lngRichTextBoxDescripShowView=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripShowView = str.Substring(30)
            ElseIf str.StartsWith("lngRichTextBoxDescripDate=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripDate = str.Substring(26)
            ElseIf str.StartsWith("lngRichTextBoxDescripGenre=", StringComparison.CurrentCulture) Then
                lngRichTextBoxDescripGenre = str.Substring(27)

                'CHANNELSVIEW
            ElseIf str.StartsWith("lngChannelViewTitle=", StringComparison.CurrentCulture) Then
                lngChannelViewTitle = str.Substring(20)
            ElseIf str.StartsWith("lngChannelViewCheckBox24hHours=", StringComparison.CurrentCulture) Then
                lngChannelViewCheckBox24hHours = str.Substring(31)
            ElseIf str.StartsWith("lngChannelViewLabelOr=", StringComparison.CurrentCulture) Then
                lngChannelViewLabelOr = str.Substring(22)
            ElseIf str.StartsWith("lngChannelViewButtonClose=", StringComparison.CurrentCulture) Then
                lngChannelViewButtonClose = str.Substring(26)
            ElseIf str.StartsWith("lngChannelViewListViewColumns0=", StringComparison.CurrentCulture) Then
                lngChannelViewListViewColumns0 = str.Substring(31)
            ElseIf str.StartsWith("lngChannelViewListViewColumns1=", StringComparison.CurrentCulture) Then
                lngChannelViewListViewColumns1 = str.Substring(31)
            ElseIf str.StartsWith("lngChannelViewListViewColumns2=", StringComparison.CurrentCulture) Then
                lngChannelViewListViewColumns2 = str.Substring(31)
            ElseIf str.StartsWith("lngChannelViewListViewColumns3=", StringComparison.CurrentCulture) Then
                lngChannelViewListViewColumns3 = str.Substring(31)

                'TIMEZONE
            ElseIf str.StartsWith("lngTimeZoneTitle=", StringComparison.CurrentCulture) Then
                lngTimeZoneTitle = str.Substring(17)
            ElseIf str.StartsWith("lngTimeZoneLabelCompensation=", StringComparison.CurrentCulture) Then
                lngTimeZoneLabelCompensation = str.Substring(29)
            ElseIf str.StartsWith("lngTimeZoneLabelMinute=", StringComparison.CurrentCulture) Then
                lngTimeZoneLabelMinute = str.Substring(23)

                'ENGINESELECTION
            ElseIf str.StartsWith("lngEngineSelectionTitle=", StringComparison.CurrentCulture) Then
                lngEngineSelectionTitle = str.Substring(24)
            ElseIf str.StartsWith("lngEngineSelectionTVDBListBox=", StringComparison.CurrentCulture) Then
                lngEngineSelectionTVDBListBox = str.Substring(30)
            ElseIf str.StartsWith("lngEngineSelectionIMDBListBox=", StringComparison.CurrentCulture) Then
                lngEngineSelectionIMDBListBox = str.Substring(30)
            ElseIf str.StartsWith("lngEngineSelectionAllocineListBox=", StringComparison.CurrentCulture) Then
                lngEngineSelectionAllocineListBox = str.Substring(34)
            ElseIf str.StartsWith("lngEngineSelectionShowCheckBox=", StringComparison.CurrentCulture) Then
                lngEngineSelectionShowCheckBox = str.Substring(31)

                'STATUSSTRIP
            ElseIf str.StartsWith("lngToolStripStatusLabelActiveEngine=", StringComparison.CurrentCulture) Then
                lngToolStripStatusLabelActiveEngine = str.Substring(36)
            ElseIf str.StartsWith("lngToolStripStatusLabelTHEDVB=", StringComparison.CurrentCulture) Then
                lngToolStripStatusLabelTHEDVB = str.Substring(30)
            ElseIf str.StartsWith("lngToolStripStatusLabelIMDB=", StringComparison.CurrentCulture) Then
                lngToolStripStatusLabelIMDB = str.Substring(28)
            ElseIf str.StartsWith("lngToolStripStatusLabelALLOCINE=", StringComparison.CurrentCulture) Then
                lngToolStripStatusLabelALLOCINE = str.Substring(32)
            ElseIf str.StartsWith("lngToolStripStatusLabelMemory=", StringComparison.CurrentCulture) Then
                lngToolStripStatusLabelMemory = str.Substring(30)
            ElseIf str.StartsWith("lngToolStripStatusLabelMB=", StringComparison.CurrentCulture) Then
                lngToolStripStatusLabelMB = str.Substring(26)

                'LOADER
            ElseIf str.StartsWith("lngLoaderLabelWait=", StringComparison.CurrentCulture) Then
                lngLoaderLabelWait = str.Substring(19)

                'SIGNALETIQUE
            ElseIf str.StartsWith("lngSignaletique=", StringComparison.CurrentCulture) Then
                lngSignaletique = str.Substring(16)
            ElseIf str.StartsWith("lngSignaletiqueLabel10=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabel10 = str.Substring(23)
            ElseIf str.StartsWith("lngSignaletiqueLabel12=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabel12 = str.Substring(23)
            ElseIf str.StartsWith("lngSignaletiqueLabel16=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabel16 = str.Substring(23)
            ElseIf str.StartsWith("lngSignaletiqueLabel18=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabel18 = str.Substring(23)
            ElseIf str.StartsWith("lngSignaletiqueLabel43=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabel43 = str.Substring(23)
            ElseIf str.StartsWith("lngSignaletiqueLabel169=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabel169 = str.Substring(24)
            ElseIf str.StartsWith("lngSignaletiqueLabelStereo=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabelStereo = str.Substring(27)
            ElseIf str.StartsWith("lngSignaletiqueLabelCaption=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabelCaption = str.Substring(28)
            ElseIf str.StartsWith("lngSignaletiqueLabelHD=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabelHD = str.Substring(23)
            ElseIf str.StartsWith("lngSignaletiqueLabelFirstAir=", StringComparison.CurrentCulture) Then
                lngSignaletiqueLabelFirstAir = str.Substring(29)

          
                'WEATHERUPDATE
            ElseIf str.StartsWith("lngWeatherInformation=", StringComparison.CurrentCulture) Then
                lngWeatherInformation = str.Substring(22)

                'FORECAST
                'ElseIf str.StartsWith("lngForecastLabelTown=") Then
                'lngForecastLabelTown = str.Substring(21)
            ElseIf str.StartsWith("lngForecastTitre=", StringComparison.CurrentCulture) Then
                lngForecastTitre = str.Substring(17)
            ElseIf str.StartsWith("lngMax=", StringComparison.CurrentCulture) Then
                lngMax = str.Substring(7)
            ElseIf str.StartsWith("lngMin=", StringComparison.CurrentCulture) Then
                lngMin = str.Substring(7)
            ElseIf str.StartsWith("lngOK=", StringComparison.CurrentCulture) Then
                lngOK = str.Substring(6)
            ElseIf str.StartsWith("lngAnnuler=", StringComparison.CurrentCulture) Then
                lngAnnuler = str.Substring(11)
            ElseIf str.StartsWith("lngLocation=", StringComparison.CurrentCulture) Then
                lngLocation = str.Substring(12)

                'WEATHERCITYSELECT
            ElseIf str.StartsWith("lngWeatherCitySelectTitre=", StringComparison.CurrentCulture) Then
                lngWeatherCitySelectTitre = str.Substring(26)

                'BALLONTIPS
            ElseIf str.StartsWith("lngBallonTipsNoInformation=", StringComparison.CurrentCulture) Then
                lngBallonTipsNoInformation = str.Substring(27)

                'GESTIONBDD
            ElseIf str.StartsWith("lngGestionBddTitre=", StringComparison.CurrentCulture) Then
                lngGestionBddTitre = str.Substring(19)
            ElseIf str.StartsWith("lngGestionBddButtonDelete=", StringComparison.CurrentCulture) Then
                lngGestionBddButtonDelete = str.Substring(26)
            ElseIf str.StartsWith("lngGestionBddButtonSave=", StringComparison.CurrentCulture) Then
                lngGestionBddButtonSave = str.Substring(24)
            ElseIf str.StartsWith("lngGestionBddButtonRestore=", StringComparison.CurrentCulture) Then
                lngGestionBddButtonRestore = str.Substring(27)
            ElseIf str.StartsWith("lngGestionBddButtonCancel=", StringComparison.CurrentCulture) Then
                lngGestionBddButtonCancel = str.Substring(26)
            ElseIf str.StartsWith("lngListViewGestionBddColumns0=", StringComparison.CurrentCulture) Then
                lngListViewGestionBddColumns0 = str.Substring(30)
            ElseIf str.StartsWith("lngListViewGestionBddColumns1=", StringComparison.CurrentCulture) Then
                lngListViewGestionBddColumns1 = str.Substring(30)
            ElseIf str.StartsWith("lngListViewGestionBddColumns2=", StringComparison.CurrentCulture) Then
                lngListViewGestionBddColumns2 = str.Substring(30)
            ElseIf str.StartsWith("lngGroupBoxRestauration=", StringComparison.CurrentCulture) Then
                lngGroupBoxRestauration = str.Substring(24)
            ElseIf str.StartsWith("lngCheckBoxRestaurationDataBase=", StringComparison.CurrentCulture) Then
                lngCheckBoxRestaurationDataBase = str.Substring(32)
            ElseIf str.StartsWith("lngCheckBoxRestaurationChaines=", StringComparison.CurrentCulture) Then
                lngCheckBoxRestaurationChaines = str.Substring(31)
            ElseIf str.StartsWith("lngCheckBoxRestaurationUrl=", StringComparison.CurrentCulture) Then
                lngCheckBoxRestaurationUrl = str.Substring(27)
            ElseIf str.StartsWith("lngCheckBoxRestaurationUserConfig=", StringComparison.CurrentCulture) Then
                lngCheckBoxRestaurationUserConfig = str.Substring(34)

                'PROGRESSBAR
            ElseIf str.StartsWith("lngProgressBarSaveTitre=", StringComparison.CurrentCulture) Then
                lngProgressBarSaveTitre = str.Substring(24)
            ElseIf str.StartsWith("lngProgressBarSaveLabel=", StringComparison.CurrentCulture) Then
                lngProgressBarSaveLabel = str.Substring(24)
            ElseIf str.StartsWith("lngProgressBarRestoreTitre=", StringComparison.CurrentCulture) Then
                lngProgressBarRestoreTitre = str.Substring(27)
            ElseIf str.StartsWith("lngProgressBarRestoreLabel=", StringComparison.CurrentCulture) Then
                lngProgressBarRestoreLabel = str.Substring(27)
            End If

            str = sr.ReadLine()
        Loop
        sr.Close()
    End Sub

    Public Sub LanguageCheck(Optional ByVal iForm As Integer = 0)


        ' 07/07/2009
        ' Si aucune langue n'est sélectionné au 1er démarrage de ZGuideTV l'anglais est sélectionné par défaut
        If My.Settings.Language = "English" OrElse (Not My.Settings.Language Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Language)) Then
            Languagefile = Application.StartupPath & "\languages\" & "English" & ".lng"
            My.Settings.Language = "English"
            My.Settings.Save()
            Init(Languagefile)
            SetControlLanguage(iForm)
        Else
            Languagefile = Application.StartupPath & "\languages\" & My.Settings.Language & ".lng"
            My.Settings.Save()
            Init(Languagefile)
            SetControlLanguage(iForm)
        End If

    End Sub
End Module
