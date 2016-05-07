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
Imports System.IO

' ReSharper disable CheckNamespace
Friend Module Language
    ' ReSharper restore CheckNamespace

    'variable pour la langue""
    Private _languagefile As String = ""

    'LANGUAGE
    Public LngLanguage As String

    'SELECTLANGUAGE
    Public LngSelectLanguageButtonOk As String
    Public LngSelectLanguageButtonCancel As String

    'JUMPLIST
    Public LngSiteOfficiel As String
    Public LngForumOfficiel As String

    'PREMIERDEMARRAGE
    Public LngPremierDemarrageTitle As String
    Public LngPremierDemarrageLabelInfo As String
    Public LngPremierDemarrageButtonOk As String
    Public LngPremierDemarrageButtonCancel As String
    Public LngPremierDemarrageButtonCheck As String

    'PREF_TITLE
    Public LngPrefTitle As String

    'PREF_TABPAGE_GENERAL
    Public LngTabPageGeneral As String
    Public LngGroupBoxPurge As String
    Public LngGroupBoxEffects As String
    Public LngGroupBoxConfHardware As String
    Public LngGroupBoxSauvegardeFenetre As String
    Public LngGroupBoxDivers As String
    Public LngGroupBoxFiltres As String
    Public LngGroupBoxPosition As String
    Public LngCheckBoxPurge As String
    Public LngCheckBoxFadeOut As String
    Public LngCheckBoxSlide As String
    Public LngRadioButtonConfNormal As String
    Public LngRadioButtonConfAverage As String
    Public LngRadioButtonConfMinimum As String
    Public LngCheckBoxConfigWindow As String
    Public LngCheckBoxtracelog As String
    Public LngCheckBoxFilters As String
    Public LngCheckBoxbuttonssave As String
    Public LngGroupBoxMouse As String
    Public LngCheckBoxaccordscrollhorizontal As String
    Public LngCheckBoxUrlUpdate As String
    Public LngGroupBoxUrlUpdate As String
    Public LngGroupBoxToolTipsBallon As String
    Public LngCheckBoxToolTipsBallon As String
    Public LngCheckBoxSystray As String
    Public LngGroupBoxSystray As String

    'PREF_TABPAGE_PROXY
    Public LngGroupBoxConnexion As String
    Public LngGroupBoxProxy As String
    Public LngLabelUtilisateur As String
    Public LngLabelMotdePasse As String
    Public LngLabelProxy As String
    Public LngLabelPort As String

    'PREF_TABPAGE_MAJ_DONNEES
    Public LngTabPageMiseajourDonnees As String
    Public LngGroupBoxIntervalle As String
    Public LngGroupBoxUpdateLast As String
    Public LngGroupBoxAutoUpdate As String
    Public LngGroupBoxTailleBdd As String
    Public LngGroupBoxUpdateIn As String
    Public LngUpdateIn As String
    Public LngGroupBoxUpdateNext As String
    Public LngCheckBoxAutoUpdate As String
    Public LngTextBoxUpdateDay As String

    'PREF_TABPAGE_MAJ_LOGICIEL
    Public LngCheckBoxAutoverif As String
    Public LngGroupBoxAutoUpdateExe As String

    'PREF_TABPAGE_MAJ_CESOIR_MAINTENANT
    Public LngTabPageCesoirMaintenant As String
    Public LngGroupBoxCesoir As String
    Public LngGroupBoxMaintenant As String
    Public LngRadioButtonCesoirAll As String
    Public LngRadioButtonCesoir45 As String
    Public LngRadioButtonCesoir60 As String
    Public LngRadioButtonCesoir75 As String
    Public LngRadioButtonCesoir90 As String
    Public LngRadioButtonCesoir105 As String
    Public LngRadioButtonCesoir120 As String
    Public LngRadioButtonMaintenantAll As String
    Public LngRadioButtonMaintenant45 As String
    Public LngRadioButtonMaintenant60 As String
    Public LngRadioButtonMaintenant75 As String
    Public LngRadioButtonMaintenant90 As String
    Public LngRadioButtonMaintenant105 As String
    Public LngRadioButtonMaintenant120 As String

    'PREF_TABPAGE_MODE_VEILLE
    Public LngTabPageResume As String
    Public LngGroupBoxResume As String
    Public LngCheckBoxResume As String
    Public LngGroupBoxResumeBefore As String
    Public LngRadioButtonResume5 As String
    Public LngRadioButtonResume10 As String
    Public LngRadioButtonResume15 As String
    Public LngRadioButtonResume20 As String
    Public LngRadioButtonResume30 As String

    'PREF_TABPAGE_GESTION_SON
    Public LngTabPageSound As String
    Public LngGroupBoxRss As String
    Public LngGroupBoxMessages As String
    Public LngGroupBoxReminder As String
    Public LngGroupBoxMute As String
    Public LngCheckBoxAudioOn As String

    'PREF_BUTTON
    Public LngButtonOk As String
    Public LngButtonCancel As String

    'MAINFORM_TOOLSTRIP_MENU_FILE
    Public LngToolStripMenuFile As String
    Public LngToolStripMenuFileSave As String
    Public LngToolStripMenuFileRestart As String
    Public LngToolStripMenuFileExit As String
    Public LngToolStripMenuItemSettingsReset As String

    'MAINFORM_TOOLSTRIP_MENU_EDIT
    Public LngToolStripMenuEdit As String
    Public LngToolStripMenuEditOntop As String
    Public LngToolStripMenuSearch As String
    Public LngToolStripMenuPrintTonight As String
    Public LngToolStripMenuCategories As String
    Public LngToolStripMenuDescription As String
    Public LngToolStripMenuCalendar As String

    'MAINFORM_TOOLSTRIP_MENU_OPTIONS
    Public LngToolStripMenuOptions As String
    Public LngToolStripMenuOptionsUpdate As String
    Public LngToolStripMenuOptionsAutoUpdate As String
    Public LngToolStripMenuOptionsPreferences As String
    Public LngToolStripMenuOptionsLogos As String
    Public LngToolStripMenuOptionsDualMonitor As String
    Public LngToolStripMenuOptionsEngineSelection As String

    'MAINFORM_TOOLSTRIP_MENU_HELP
    Public LngToolStripMenuHelp As String
    Public LngToolStripMenuHelpHelptopics As String
    Public LngToolStripMenuHelpHelpShortcuts As String
    Public LngToolStripMenuHelpWebsite As String
    Public LngToolStripMenuHelpForum As String
    Public LngToolStripMenuHelpLanguage As String
    Public LngToolStripMenuHelpAbout As String
    Public LngToolStripMenuHelpManualFeedBack As String
    Public LngToolStripMenuHelpDonate As String
    Public LngToolStripMenuHelpCompensation As String

    'MAINFORM_TOOLSTRIP
    Public LngToolStripSave As String
    Public LngToolStripSearch As String
    Public LngToolStripOntop As String
    Public LngToolStripPreferences As String
    Public LngToolStripLogos As String
    Public LngToolStripUpdate As String
    Public LngToolStripAutoUpdate As String
    Public LngToolStripDualMonitor As String
    Public LngToolStripWebsite As String
    Public LngToolStripForum As String
    Public LngToolStripLangue As String
    Public LngToolStripAbout As String
    Public LngToolStripHelptopics As String
    Public LngToolStripHelpShortcuts As String
    Public LngToolStripCategories As String
    Public LngToolStripDescription As String
    Public LngToolStripCalendar As String
    Public LngToolStripManualFeedBack As String
    Public LngToolStripTextBoxRecherche As String
    Public LngToolStripButtonRecherche As String
    Public LngToolStripButtonDonate As String

    'MAINFORM_PAVE
    Public LngPaveJourMoins As String
    Public LngPaveHeureMoins As String
    Public LngPave6H As String
    Public LngPave9H As String
    Public LngPave12H As String
    Public LngPave15H As String
    Public LngPave18H As String
    Public LngPave20H As String
    Public LngPave23H As String
    Public LngPaveMaintenant As String
    Public LngPaveHeurePlus As String
    Public LngPaveJourPlus As String

    'MAINFORM_CESOIR_MAINTENANT
    Public LngPanelTitreCesoir As String
    Public LngPanelTitreMaintenant As String

    'REORGCHANNEL_TITLE
    Public LngReorgChannelTitle As String

    'REORGCHANNEL_BUTTON
    Public LngButtonMonterReorgChannel As String
    Public LngButtonDescendreReorgChannel As String
    Public LngButtonSupprimerReorgChannel As String
    Public LngButtonLogoReorgChannel As String
    Public LngButtonEnregistrerReorgChannel As String
    Public LngButtonAnnulerReorgChannel As String
    Public LngReorgChannelListViewColumns0 As String
    Public LngReorgChannelListViewColumns1 As String

    'FRM_ABOUT_TITLE
    Public LngAboutTitle As String

    'FRM_ABOUT_TABPAGE_ABOUT
    Public LngTabPageAbout As String

    'FRM_ABOUT_TABPAGE_AUTHORS
    Public LngTabPageAuteurs As String
    Public LngTextBoxAdmin As String
    Public LngTextBoxDev As String
    Public LngTextBoxTesters As String
    Public LngTextBoxContributors As String
    Public LngTextBoxThanks As String

    'FRM_ABOUT_TABPAGE_LICENCE
    Public LngTabPagelicence As String

    'FRM_ABOUT_TABPAGE_7ZIP
    Public LngTabPage7Zip As String

    'FRM_ABOUT_TABPAGE_DONATE
    Public LngTabPageDonate As String

    'FRMMISEAJOUR_TITLE
    Public LngFrmMiseajour As String

    'FRMMISEAJOUR
    Public LngRadioButtonDownload As String
    Public LngRadioButtonXmlPath As String
    Public LngButtonTout As String
    Public LngButtonSuppr As String
    Public LngButtonMiseaJour As String
    Public LngButtonDemarrer As String
    Public LngButtonAnnuler As String
    Public LngButtonEdit As String
    Public LngCheckBoxAutoRestartManualUpdate As String

    'FRMMISEAJOUR_MESSAGE
    Public LngErrorInChannelListRecovery As String
    Public LngNoUrlUpdate As String
    Public LngInvalidUrl As String
    Public LngUntraceableFile As String
    Public LngInvalidFile As String
    Public LngErrorInUpdate As String
    Public LngErrorInXmlCopy As String
    Public LngErrorInFileCopy As String
    Public LngErrorInUnzip As String
    Public LngWrongFileName As String
    Public LngFailUrlFileDownload As String
    Public LngUntraceableUrlListFile As String
    Public LngTheFile As String
    Public LngDontExist As String
    Public LngProtectedFile As String
    Public LngChosenChannels As String
    Public LngAvailableChannels As String
    Public LngChoseFile As String
    Public LngInvalidChoice As String

    'MAINFORM_MENU_CONTEXTUEL_DESCRIPTION
    Public LngToolStripMenuPrintDescript As String

    'MAINFORM_MESSAGE_PROXY
    Public LngMsgProxyTitle As String
    Public LngMsgProxy As String

    'MAINFORM_MESSAGE_NODATA
    Public LngMessageBoxNoData As String
    Public LngMessageBoxNoDataTitre As String

    'MAINFORM TREEVIEW CATEGORY
    Public LngNodeFilter As String
    Public LngNodeCategory As String
    Public LngNodeCountry As String
    Public LngNodeProvider As String

    'MESSAGEBOXBASEPERIMEE
    Public LngMessageBoxBasePerimee As String
    Public LngMessageBoxBasePerimee1 As String
    Public LngMessageBoxBasePerimeeTitre As String

    'MESSAGEBOXNOUPDATE
    Public LngMessageBoxnoupdate As String
    Public LngMessageBoxnoupdateTitre As String

    'MESSAGEBOXMISEAJOUR
    Public LngMessageBoxMiseaJour As String
    Public LngMessageBoxMiseaJour1 As String
    Public LngMessageBoxMiseaJourTitre As String

    'MESSAGEBOXMISEAJOURDONE
    Public LngMessageBoxMiseaJourDone As String
    Public LngMessageBoxMiseaJour1Done As String
    Public LngMessageBoxMiseaJourTitreDone As String

    'MESSAGEBOXMODIFPREF
    Public LngMessageBoxModifPref As String
    Public LngMessageBoxModifPref1 As String
    Public LngMessageBoxModifPrefTitre As String

    'MESSAGEBOXNOCONNECTION
    Public LngMessageBoxNoConnection As String
    Public LngMessageBoxNoConnection1 As String
    Public LngMessageBoxNoConnectionTitre As String

    'MESSAGEBOXFEEDBACK
    Public LngMessageBoxFeedback As String
    Public LngMessageBoxFeedbackTitre As String

    'MESSAGEBOXFICHIERCORROMPU
    Public LngMessageFichierCorrompu As String
    Public LngMessageFichierCorrompu1 As String
    Public LngMessageFichierCorrompu2 As String
    Public LngMessageFichierCorrompuTitre As String

    'MESSAGEBOXLISTXMLTVFRCHOISIE
    Public LngMessageBoxListXmltvfrChoisie As String
    Public LngMessageBoxListXmltvfrChoisie1 As String
    Public LngMessageBoxListXmltvfrChoisieTitre As String

    'MESSAGEBOXTHETVDBNORESULT
    Public LngMessageBoxThetvdbNoResult As String
    Public LngMessageBoxThetvdbNoResultTitre As String

    'MESSAGEBOXTHETVDBVALIDESERIEID
    Public LngMessageBoxThetvdbNoValidSeriesId As String
    Public LngMessageBoxThetvdbNoValidSeriesIdTitre As String

    'MESSAGEBOXTHETVDBNOSERIEDETAIL
    Public LngMessageBoxThetvdbNoSerieDetail As String
    Public LngMessageBoxThetvdbNoSerieDetailTitre As String

    'MESSAGEBOXTHETVDBNOACTORINFO
    Public LngMessageBoxThetvdbNoActorInfo As String
    Public LngMessageBoxThetvdbNoActorInfoTitre As String

    'MESSAGEBOXTHETVDBNOBANNER
    Public LngMessageBoxThetvdbNoBanner As String
    Public LngMessageBoxThetvdbNoBannerTitre As String

    'MESSAGEBOXMESSAGEENVOYE
    Public LngMessageBoxMessageEnvoye As String
    Public LngMessageBoxMessageEnvoyeTitre As String

    'MESSAGEBOXMESSAGEISEMPTY
    Public LngMessageBoxMessageIsEmpty As String
    Public LngMessageBoxMessageIsEmptyTitre As String

    'MESSAGEBOXFILESAVE
    Public LngMessageBoxFileRestore As String
    Public LngMessageBoxFileRestore1 As String
    Public LngMessageBoxFileRestore2 As String
    Public LngMessageBoxFileRestoreTitre As String

    'MESSAGEBOXNORESTORESELECTED
    Public LngMessageBoxNoRestoreSelected As String
    Public LngMessageBoxNoRestoreSelectedTitre As String

    'MESSAGEBOXNORESTOREELEMENT
    Public LngMessageBoxNoRestoreElement As String
    Public LngMessageBoxNoRestoreElementTitre As String

    'MESSAGEBOXREORGCHANNEL
    Public LngMessageBoxReorgChannel As String
    Public LngMessageBoxReorgChannel1 As String
    Public LngMessageBoxReorgChannelTitre As String

    'MESSAGEBOXRESUME
    Public LngMessageBoxResume As String
    Public LngMessageBoxResume1 As String
    Public LngMessageBoxResumeTitre As String

    'MESSAGEBOXRAZ
    Public LngMessageBoxRaz As String
    Public LngMessageBoxRaz1 As String
    Public LngMessageBoxTitleRaz As String

    'MESSAGEBOXMISEAJOUREXE
    Public LngMessageBoxMiseaJourExe As String
    Public LngMessageBoxMiseaJourExe1 As String
    Public LngMessageBoxMiseaJourExeTitre As String
    Public LngMessageBoxMiseaJourExeActual As String
    Public LngMessageBoxMiseaJourExeNew As String

    'MESSAGEBOXDIRCHECKED
    Public LngMessageBoxDirChecked As String
    Public LngMessageBoxDirChecked1 As String
    Public LngMessageBoxDirCheckedTitre As String

    'MESSAGEBOXFILENOTEXIST
    Public LngMessageBoxFileNotExist As String
    Public LngMessageBoxFileNotExist1 As String
    Public LngMessageBoxFileNotExistTitre As String

    'MESSAGEBOXURLCHECKED
    Public LngMessageBoxUrlChecked As String
    Public LngMessageBoxUrlChecked1 As String
    Public LngMessageBoxUrlCheckedTitre As String

    'MESSAGEBOXSAVEDONE
    Public LngMessageboxSaveDone As String
    Public LngMessageboxSaveDoneTitre As String

    'MESSAGEBOXRENAMEDONE
    Public LngMessageboxRenameDone As String
    Public LngMessageboxRenameDoneTitre As String

    'MESSAGEBOXDELETEDONE
    Public LngMessageboxDeleteDone As String
    Public LngMessageboxDeleteDoneTitre As String

    'INPUTBOXNAMEBDD
    Public LngInputBoxNameBdd As String
    Public LngInputBoxNameBddTitre As String

    'INPUTBOXRENAMEBDD
    Public LngInputBoxRenameBdd As String
    Public LngInputBoxRenameBddTitre As String

    'MISEAJOURAUTO
    Public LngMiseAJourAutoTitle As String
    Public LngNodeNumber As String
    Public LngAutoUpdateOperation As String
    Public LngdwnlOperation As String
    Public LngParsingOperation As String
    Public LngremainingTime As String
    Public LngfileSize As String

    'MISEAJOURAUTO_MESSAGE
    Public LngError1Majauto As String
    Public LngError2Majauto As String
    Public LngError3Majauto As String
    Public LngError4Majauto As String
    Public LngError5Majauto As String
    Public LngError6Majauto As String

    'NOTIFYICON
    ' ReSharper disable InconsistentNaming
    Public lngBalloonText1 As String
    Public lngBalloonText3 As String

    'SYSTRAY
    Public lngSystrayMenuRestore As String
    Public lngSystrayMenuExit As String

    'TRIAVANCE
    Public LngTriAvanceTitle As String
    Public LngTriAvanceLabeltitre As String
    Public LngTriAvanceLabelauteur As String
    Public LngTriAvanceLabelndefini As String
    Public LngTriAvanceButtonSearch As String
    Public LngTriAvanceButtonCancel As String
    Public LngTriAvanceGroupBoxCriteres As String
    Public LngTriAvanceCheckBoxNow As String
    Public LngTriAvanceCheckBoxBegin As String
    Public LngTriAvanceListViewColumns0 As String
    Public LngTriAvanceListViewColumns1 As String
    Public LngTriAvanceListViewColumns2 As String
    Public LngTriAvanceListViewColumns3 As String
    Public LngTriAvanceListViewColumns4 As String

    'CALENDRIER
    Public LngCalendarLundiLabel As String
    Public LngCalendarMardiLabel As String
    Public LngCalendarMercrediLabel As String
    Public LngCalendarJeudiLabel As String
    Public LngCalendarVendrediLabel As String
    Public LngCalendarSamediLabel As String
    Public LngCalendarDimancheLabel As String
    Public LngNameofMonth1 As String
    Public LngNameofMonth2 As String
    Public LngNameofMonth3 As String
    Public LngNameofMonth4 As String
    Public LngNameofMonth5 As String
    Public LngNameofMonth6 As String
    Public LngNameofMonth7 As String
    Public LngNameofMonth8 As String
    Public LngNameofMonth9 As String
    Public LngNameofMonth10 As String
    Public LngNameofMonth11 As String
    Public LngNameofMonth12 As String

    'DESCRIPTBOX
    Public LngDescriptLundiLabel As String
    Public LngDescriptMardiLabel As String
    Public LngDescriptMercrediLabel As String
    Public LngDescriptJeudiLabel As String
    Public LngDescriptVendrediLabel As String
    Public LngDescriptSamediLabel As String
    Public LngDescriptDimancheLabel As String

    'Feedback
    Public LngFeedbackTitle As String
    Public LngLabelExceptMessage1 As String
    Public LngLabelExceptMessage2 As String
    Public LngLabelExceptMessage3 As String
    Public LngLabelExceptMessage4 As String
    Public LngCheckBoxExceptErrorMessage As String
    Public LngLabelEmail As String
    Public LngSendButton As String
    Public LngCopierButton As String
    Public LngExitButton As String
    Public LngExceptErrorMessage As String
    Public LngLabelFeedbackSend As String
    Public LngZGuideTvRelease As String
    Public LngCompilationDate As String
    Public LngOsRelease As String
    Public LngArchitecture As String
    Public LngOsBootMode As String
    Public LngFramework As String
    Public LngOsLanguage As String
    Public LngTotalMemory As String
    Public LngRemainingMemory As String
    Public LngUsedMemory As String
    Public LngProcessorName As String
    Public LngProcessorNumber As String
    Public LngMonitorNumber As String
    Public LngEmail As String
    Public LngComments As String
    Public LngDescriptionError As String
    Public LngProcessorSpeed As String
    Public LngCheckBoxAcknowledgment As String
    Public LngProcessorDescription As String

    'THETVDBTAB
    Public LngThetvdbLabelSeriesTabSeries As String
    Public LngThetvdbLabelEpisodesTabEpisodes As String
    Public LngThetvdbLabelActorsTabActors As String

    'THETVDB
    Public LngThetvdbLabelSearchName As String
    Public LngThetvdbLabelLanguage As String
    Public LngThetvdbButtonSearch As String
    Public LngThetvdbLabelSiteRating As String
    Public LngThetvdbLabelId As String
    Public LngThetvdbLabelRuntime As String
    Public LngThetvdbLabelRating As String
    Public LngThetvdbLabelDescription As String
    Public LngThetvdbLabelFirstAired As String
    Public LngThetvdbLabelIdtvCom As String
    Public LngThetvdbLabelIdimdbCom As String
    Public LngThetvdbLabelForceUpdate As String
    Public LngThetvdbButtonLoad As String
    Public LngThetvdbButtonCancel As String
    Public LngThetvdbButtonExit As String
    Public LngThetvdbLabelGenre As String
    Public LngThetvdbLabelActors As String
    Public LngThetvdbLabelActors1 As String
    Public LngThetvdbLabelGueststar As String
    Public LngThetvdbLabelDirector As String
    Public LngThetvdbLabelWriter As String
    Public LngThetvdbLabelLoadFull As String
    Public LngThetvdbLabelLoadActors As String
    Public LngThetvdbLabelBanner As String
    Public LngThetvdbLabelUseZipped As String
    Public LngThetvdbLabelOpen As String
    Public LngThetvdbLabelEpisodes As String

    'THETVDBTABEPISODE
    Public LngThetvdbLabelAbsoluteNumberTabEpisodes As String
    Public LngThetvdbLabelProductCodeTabEpisodes As String
    Public LngThetvdbLabelDvdidTabEpisodes As String
    Public LngThetvdbLabelDvdSeasonTabEpisodes As String
    Public LngThetvdbLabelDvdNumberTabEpisodes As String
    Public LngThetvdbLabelDvdChapterTabEpisodes As String
    Public LngThetvdbNodeSeasonTabEpisodes As String

    'THETVDBTABACTORS
    Public LngThetvdbGroupBoxInformationTabActors As String
    Public LngThetvdbLabelIdTabActors As String
    Public LngThetvdbLabelNameTabActors As String
    Public LngThetvdbLabelRoleTabActors As String
    Public LngThetvdbLabelSortOrderTabActors As String

    'THETVDBRESULT
    Public LngThetvdbGroupBoxResult As String
    Public LngThetvdbLabelFirstAiredResult As String
    Public LngThetvdbLabelImdbIdResult As String
    Public LngThetvdbLabelOverviewResult As String
    Public LngThetvdbLabelStatusResult As String
    Public LngThetvdbButtonChooseResult As String
    Public LngThetvdbButtonCancelResult As String
    Public LngThetvdbListviewResultColumns0 As String
    Public LngThetvdbListviewResultColumns1 As String
    Public LngThetvdbListviewResultColumns2 As String

    'THETVDBBOXNOSHEET
    Public LngThetvdbBoxNoSheet As String
    Public LngThetvdbBoxNoSheetTitre As String

    'CHANNELSVIEW
    Public LngChannelViewTitle As String
    Public LngChannelViewCheckBox24HHours As String
    Public LngChannelViewLabelOr As String
    Public LngChannelViewButtonClose As String
    Public LngChannelViewListViewColumns0 As String
    Public LngChannelViewListViewColumns1 As String
    Public LngChannelViewListViewColumns2 As String
    Public LngChannelViewListViewColumns3 As String

    'TIMEZONE
    Public LngTimeZoneTitle As String
    Public LngTimeZoneLabelCompensation As String
    Public LngTimeZoneLabelMinute As String

    'ENGINESELECTION
    Public LngEngineSelectionTitle As String
    Public LngEngineSelectionTvdbListBox As String
    Public LngEngineSelectionImdbListBox As String
    Public LngEngineSelectionAllocineListBox As String
    Public LngEngineSelectionShowCheckBox As String

    'STATUSSTRIP
    Public LngToolStripStatusLabelActiveEngine As String
    Public LngToolStripStatusLabelThedvb As String
    Public LngToolStripStatusLabelImdb As String
    Public LngToolStripStatusLabelAllocine As String
    Public LngToolStripStatusLabelMemory As String
    Public LngToolStripStatusLabelMb As String
    Public LngToolStripStatusLabelUpdate As String

    'BALLONTIPS
    Public LngBallonTipsNoInformation As String

    'GESTIONBDD
    Public LngGestionBddTitre As String
    Public LngGestionBddButtonDelete As String
    Public LngGestionBddButtonSave As String
    Public LngGestionBddButtonRestore As String
    Public LngGestionBddButtonRename As String
    Public LngGestionBddButtonCancel As String
    Public LngListViewGestionBddColumns0 As String
    Public LngListViewGestionBddColumns1 As String
    Public LngListViewGestionBddColumns2 As String
    Public LngGroupBoxRestauration As String
    Public LngCheckBoxRestaurationDataBase As String
    Public LngCheckBoxRestaurationChaines As String
    Public LngCheckBoxRestaurationUrl As String
    Public LngCheckBoxRestaurationUserConfig As String

    'PROGRESSBAR
    Public LngProgressBarSaveTitre As String
    Public LngProgressBarSaveLabel As String
    Public LngProgressBarRestoreTitre As String
    Public LngProgressBarRestoreLabel As String

    Private Sub Init(ByVal languagefile As String)
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
            If str.StartsWith("LngLanguage=", StringComparison.CurrentCulture) Then
                LngLanguage = str.Substring(12)

                'SELECTLANGUAGE
            ElseIf str.StartsWith("LngSelectLanguageButtonOK=", StringComparison.CurrentCulture) Then
                LngSelectLanguageButtonOk = str.Substring(26)
            ElseIf str.StartsWith("LngSelectLanguageButtonCancel=", StringComparison.CurrentCulture) Then
                LngSelectLanguageButtonCancel = str.Substring(30)

                'JUMPLIST
            ElseIf str.StartsWith("LngSiteOfficiel=", StringComparison.CurrentCulture) Then
                LngSiteOfficiel = str.Substring(16)
            ElseIf str.StartsWith("LngForumOfficiel=", StringComparison.CurrentCulture) Then
                LngForumOfficiel = str.Substring(17)

                'PREMIERDEMARRAGE
            ElseIf str.StartsWith("LngPremierDemarrageTitle=", StringComparison.CurrentCulture) Then
                LngPremierDemarrageTitle = str.Substring(25)
            ElseIf str.StartsWith("LngPremierDemarrageLabelInfo=", StringComparison.CurrentCulture) Then
                LngPremierDemarrageLabelInfo = str.Substring(29)
            ElseIf str.StartsWith("LngPremierDemarrageButtonOK=", StringComparison.CurrentCulture) Then
                LngPremierDemarrageButtonOk = str.Substring(28)
            ElseIf str.StartsWith("LngPremierDemarrageButtonCancel=", StringComparison.CurrentCulture) Then
                LngPremierDemarrageButtonCancel = str.Substring(32)
            ElseIf str.StartsWith("LngPremierDemarrageButtonCheck=", StringComparison.CurrentCulture) Then
                LngPremierDemarrageButtonCheck = str.Substring(31)

                'PREF_TITLE
            ElseIf str.StartsWith("LngPrefTitle=", StringComparison.CurrentCulture) Then
                LngPrefTitle = str.Substring(13)

                'PREF_TABPAGE_GENERAL
            ElseIf str.StartsWith("LngTabPageGeneral=", StringComparison.CurrentCulture) Then
                LngTabPageGeneral = str.Substring(18)
            ElseIf str.StartsWith("LngGroupBoxPurge=", StringComparison.CurrentCulture) Then
                LngGroupBoxPurge = str.Substring(17)
            ElseIf str.StartsWith("LngGroupBoxEffects=", StringComparison.CurrentCulture) Then
                LngGroupBoxEffects = str.Substring(19)
            ElseIf str.StartsWith("LngGroupBoxConfHardware=", StringComparison.CurrentCulture) Then
                LngGroupBoxConfHardware = str.Substring(24)
            ElseIf str.StartsWith("LngGroupBoxSauvegardeFenetre=", StringComparison.CurrentCulture) Then
                LngGroupBoxSauvegardeFenetre = str.Substring(29)
            ElseIf str.StartsWith("LngGroupBoxDivers=", StringComparison.CurrentCulture) Then
                LngGroupBoxDivers = str.Substring(18)
            ElseIf str.StartsWith("LngGroupBoxFiltres=", StringComparison.CurrentCulture) Then
                LngGroupBoxFiltres = str.Substring(19)
            ElseIf str.StartsWith("LngGroupBoxPosition=", StringComparison.CurrentCulture) Then
                LngGroupBoxPosition = str.Substring(20)
            ElseIf str.StartsWith("LngCheckBoxPurge=", StringComparison.CurrentCulture) Then
                LngCheckBoxPurge = str.Substring(17)
            ElseIf str.StartsWith("LngCheckBoxFadeOut=", StringComparison.CurrentCulture) Then
                LngCheckBoxFadeOut = str.Substring(19)
            ElseIf str.StartsWith("LngCheckBoxSlide=", StringComparison.CurrentCulture) Then
                LngCheckBoxSlide = str.Substring(17)
            ElseIf str.StartsWith("LngRadioButtonConfNormal=", StringComparison.CurrentCulture) Then
                LngRadioButtonConfNormal = str.Substring(25)
            ElseIf str.StartsWith("LngRadioButtonConfAverage=", StringComparison.CurrentCulture) Then
                LngRadioButtonConfAverage = str.Substring(26)
            ElseIf str.StartsWith("LngRadioButtonConfMinimum=", StringComparison.CurrentCulture) Then
                LngRadioButtonConfMinimum = str.Substring(26)
            ElseIf str.StartsWith("LngCheckBoxConfigWindow=", StringComparison.CurrentCulture) Then
                LngCheckBoxConfigWindow = str.Substring(24)
            ElseIf str.StartsWith("LngCheckBoxtracelog=", StringComparison.CurrentCulture) Then
                LngCheckBoxtracelog = str.Substring(20)
            ElseIf str.StartsWith("LngCheckBoxFilters=", StringComparison.CurrentCulture) Then
                LngCheckBoxFilters = str.Substring(19)
            ElseIf str.StartsWith("LngCheckBoxbuttonssave=", StringComparison.CurrentCulture) Then
                LngCheckBoxbuttonssave = str.Substring(23)
            ElseIf str.StartsWith("LngCheckBoxaccordscrollhorizontal=", StringComparison.CurrentCulture) Then
                LngCheckBoxaccordscrollhorizontal = str.Substring(34)
            ElseIf str.StartsWith("LngGroupBoxMouse=", StringComparison.CurrentCulture) Then
                LngGroupBoxMouse = str.Substring(17)
            ElseIf str.StartsWith("LngCheckBoxUrlUpdate=", StringComparison.CurrentCulture) Then
                LngCheckBoxUrlUpdate = str.Substring(21)
            ElseIf str.StartsWith("LngGroupBoxUrlUpdate=", StringComparison.CurrentCulture) Then
                LngGroupBoxUrlUpdate = str.Substring(21)
            ElseIf str.StartsWith("LngCheckBoxToolTipsBallon=", StringComparison.CurrentCulture) Then
                LngCheckBoxToolTipsBallon = str.Substring(26)
            ElseIf str.StartsWith("LngGroupBoxToolTipsBallon=", StringComparison.CurrentCulture) Then
                LngGroupBoxToolTipsBallon = str.Substring(26)
            ElseIf str.StartsWith("LngCheckBoxSystray=", StringComparison.CurrentCulture) Then
                LngCheckBoxSystray = str.Substring(19)
            ElseIf str.StartsWith("LngGroupBoxSystray=", StringComparison.CurrentCulture) Then
                LngGroupBoxSystray = str.Substring(19)

                'PREF_TABPAGE_PROXY
            ElseIf str.StartsWith("LngGroupBoxConnexion=", StringComparison.CurrentCulture) Then
                LngGroupBoxConnexion = str.Substring(21)
            ElseIf str.StartsWith("LngGroupBoxProxy=", StringComparison.CurrentCulture) Then
                LngGroupBoxProxy = str.Substring(17)
            ElseIf str.StartsWith("LngLabelUtilisateur=", StringComparison.CurrentCulture) Then
                LngLabelUtilisateur = str.Substring(20)
            ElseIf str.StartsWith("LngLabelMotdePasse=", StringComparison.CurrentCulture) Then
                LngLabelMotdePasse = str.Substring(19)
            ElseIf str.StartsWith("LngLabelProxy=", StringComparison.CurrentCulture) Then
                LngLabelProxy = str.Substring(14)
            ElseIf str.StartsWith("LngLabelPort=", StringComparison.CurrentCulture) Then
                LngLabelPort = str.Substring(13)

                'PREF_TABPAGE_MAJ_DONNEES
            ElseIf str.StartsWith("LngTabPageMiseajourDonnees=", StringComparison.CurrentCulture) Then
                LngTabPageMiseajourDonnees = str.Substring(27)
            ElseIf str.StartsWith("LngGroupBoxIntervalle=", StringComparison.CurrentCulture) Then
                LngGroupBoxIntervalle = str.Substring(22)
            ElseIf str.StartsWith("LngGroupBoxUpdateLast=", StringComparison.CurrentCulture) Then
                LngGroupBoxUpdateLast = str.Substring(22)
            ElseIf str.StartsWith("LngGroupBoxAutoUpdate=", StringComparison.CurrentCulture) Then
                LngGroupBoxAutoUpdate = str.Substring(22)
            ElseIf str.StartsWith("LngGroupBoxTailleBdd=", StringComparison.CurrentCulture) Then
                LngGroupBoxTailleBdd = str.Substring(21)
            ElseIf str.StartsWith("LngGroupBoxUpdateIn=", StringComparison.CurrentCulture) Then
                LngGroupBoxUpdateIn = str.Substring(20)
            ElseIf str.StartsWith("LngUpdateIn=", StringComparison.CurrentCulture) Then
                LngUpdateIn = str.Substring(12)
            ElseIf str.StartsWith("LngGroupBoxUpdateNext=", StringComparison.CurrentCulture) Then
                LngGroupBoxUpdateNext = str.Substring(22)
            ElseIf str.StartsWith("LngCheckBoxAutoUpdate=", StringComparison.CurrentCulture) Then
                LngCheckBoxAutoUpdate = str.Substring(22)
            ElseIf str.StartsWith("LngTextBoxUpdateDay=", StringComparison.CurrentCulture) Then
                LngTextBoxUpdateDay = str.Substring(20)

                'PREF_TABPAGE_MAJ_LOGICIEL
            ElseIf str.StartsWith("LngGroupBoxAutoUpdateExe=", StringComparison.CurrentCulture) Then
                LngGroupBoxAutoUpdateExe = str.Substring(25)
            ElseIf str.StartsWith("LngCheckBoxAutoverif=", StringComparison.CurrentCulture) Then
                LngCheckBoxAutoverif = str.Substring(21)

                'PREF_TABPAGE_MAJ_CESOIR_MAINTENANT
            ElseIf str.StartsWith("LngTabPageCesoirMaintenant=", StringComparison.CurrentCulture) Then
                LngTabPageCesoirMaintenant = str.Substring(27)
            ElseIf str.StartsWith("LngGroupBoxCesoir=", StringComparison.CurrentCulture) Then
                LngGroupBoxCesoir = str.Substring(18)
            ElseIf str.StartsWith("LngGroupBoxMaintenant=", StringComparison.CurrentCulture) Then
                LngGroupBoxMaintenant = str.Substring(22)
            ElseIf str.StartsWith("LngRadioButtonCesoirAll=", StringComparison.CurrentCulture) Then
                LngRadioButtonCesoirAll = str.Substring(24)
            ElseIf str.StartsWith("LngRadioButtonCesoir45=", StringComparison.CurrentCulture) Then
                LngRadioButtonCesoir45 = str.Substring(23)
            ElseIf str.StartsWith("LngRadioButtonCesoir60=", StringComparison.CurrentCulture) Then
                LngRadioButtonCesoir60 = str.Substring(23)
            ElseIf str.StartsWith("LngRadioButtonCesoir75=", StringComparison.CurrentCulture) Then
                LngRadioButtonCesoir75 = str.Substring(23)
            ElseIf str.StartsWith("LngRadioButtonCesoir90=", StringComparison.CurrentCulture) Then
                LngRadioButtonCesoir90 = str.Substring(23)
            ElseIf str.StartsWith("LngRadioButtonCesoir105=", StringComparison.CurrentCulture) Then
                LngRadioButtonCesoir105 = str.Substring(24)
            ElseIf str.StartsWith("LngRadioButtonCesoir120=", StringComparison.CurrentCulture) Then
                LngRadioButtonCesoir120 = str.Substring(24)
            ElseIf str.StartsWith("LngRadioButtonMaintenantAll=", StringComparison.CurrentCulture) Then
                LngRadioButtonMaintenantAll = str.Substring(28)
            ElseIf str.StartsWith("LngRadioButtonMaintenant45=", StringComparison.CurrentCulture) Then
                LngRadioButtonMaintenant45 = str.Substring(27)
            ElseIf str.StartsWith("LngRadioButtonMaintenant60=", StringComparison.CurrentCulture) Then
                LngRadioButtonMaintenant60 = str.Substring(27)
            ElseIf str.StartsWith("LngRadioButtonMaintenant75=", StringComparison.CurrentCulture) Then
                LngRadioButtonMaintenant75 = str.Substring(27)
            ElseIf str.StartsWith("LngRadioButtonMaintenant90=", StringComparison.CurrentCulture) Then
                LngRadioButtonMaintenant90 = str.Substring(27)
            ElseIf str.StartsWith("LngRadioButtonMaintenant105=", StringComparison.CurrentCulture) Then
                LngRadioButtonMaintenant105 = str.Substring(28)
            ElseIf str.StartsWith("LngRadioButtonMaintenant120=", StringComparison.CurrentCulture) Then
                LngRadioButtonMaintenant120 = str.Substring(28)

                'PREF_TABPAGE_MODE_VEILLE
            ElseIf str.StartsWith("LngTabPageResume=", StringComparison.CurrentCulture) Then
                LngTabPageResume = str.Substring(17)
            ElseIf str.StartsWith("LngGroupBoxResume=", StringComparison.CurrentCulture) Then
                LngGroupBoxResume = str.Substring(18)
            ElseIf str.StartsWith("LngCheckBoxResume=", StringComparison.CurrentCulture) Then
                LngCheckBoxResume = str.Substring(18)
            ElseIf str.StartsWith("LngGroupBoxResumeBefore=", StringComparison.CurrentCulture) Then
                LngGroupBoxResumeBefore = str.Substring(24)
            ElseIf str.StartsWith("LngRadioButtonResume5=", StringComparison.CurrentCulture) Then
                LngRadioButtonResume5 = str.Substring(22)
            ElseIf str.StartsWith("LngRadioButtonResume10=", StringComparison.CurrentCulture) Then
                LngRadioButtonResume10 = str.Substring(23)
            ElseIf str.StartsWith("LngRadioButtonResume15=", StringComparison.CurrentCulture) Then
                LngRadioButtonResume15 = str.Substring(23)
            ElseIf str.StartsWith("LngRadioButtonResume20=", StringComparison.CurrentCulture) Then
                LngRadioButtonResume20 = str.Substring(23)
            ElseIf str.StartsWith("LngRadioButtonResume30=", StringComparison.CurrentCulture) Then
                LngRadioButtonResume30 = str.Substring(23)

                'PREF_TABPAGE_GESTION_SON
            ElseIf str.StartsWith("LngTabPageSound=", StringComparison.CurrentCulture) Then
                LngTabPageSound = str.Substring(16)
            ElseIf str.StartsWith("LngGroupBoxRSS=", StringComparison.CurrentCulture) Then
                LngGroupBoxRss = str.Substring(15)
            ElseIf str.StartsWith("LngGroupBoxMessages=", StringComparison.CurrentCulture) Then
                LngGroupBoxMessages = str.Substring(20)
            ElseIf str.StartsWith("LngGroupBoxReminder=", StringComparison.CurrentCulture) Then
                LngGroupBoxReminder = str.Substring(20)
            ElseIf str.StartsWith("LngGroupBoxMute=", StringComparison.CurrentCulture) Then
                LngGroupBoxMute = str.Substring(16)
            ElseIf str.StartsWith("LngCheckBoxAudioOn=", StringComparison.CurrentCulture) Then
                LngCheckBoxAudioOn = str.Substring(19)

                'PREF_BUTTON
            ElseIf str.StartsWith("LngButtonOk=", StringComparison.CurrentCulture) Then
                LngButtonOk = str.Substring(12)
            ElseIf str.StartsWith("LngButtonCancel=", StringComparison.CurrentCulture) Then
                LngButtonCancel = str.Substring(16)

                'MAINFORM_TOOLSTRIP_MENU_FILE
            ElseIf str.StartsWith("LngToolStripMenuFile=", StringComparison.CurrentCulture) Then
                LngToolStripMenuFile = str.Substring(21)
            ElseIf str.StartsWith("LngToolStripMenuFileSave=", StringComparison.CurrentCulture) Then
                LngToolStripMenuFileSave = str.Substring(25)
            ElseIf str.StartsWith("LngToolStripMenuFileRestart=", StringComparison.CurrentCulture) Then
                LngToolStripMenuFileRestart = str.Substring(28)
            ElseIf str.StartsWith("LngToolStripMenuFileExit=", StringComparison.CurrentCulture) Then
                LngToolStripMenuFileExit = str.Substring(25)
            ElseIf str.StartsWith("LngToolStripMenuItemSettingsReset=", StringComparison.CurrentCulture) Then
                LngToolStripMenuItemSettingsReset = str.Substring(34)

                'MAINFORM_TOOLSTRIP_MENU_EDIT
            ElseIf str.StartsWith("LngToolStripMenuEdit=", StringComparison.CurrentCulture) Then
                LngToolStripMenuEdit = str.Substring(21)
            ElseIf str.StartsWith("LngToolStripMenuEditOntop=", StringComparison.CurrentCulture) Then
                LngToolStripMenuEditOntop = str.Substring(26)
            ElseIf str.StartsWith("LngToolStripMenuSearch=", StringComparison.CurrentCulture) Then
                LngToolStripMenuSearch = str.Substring(23)
            ElseIf str.StartsWith("LngToolStripMenuPrintTonight=", StringComparison.CurrentCulture) Then
                LngToolStripMenuPrintTonight = str.Substring(29)
            ElseIf str.StartsWith("LngToolStripMenuCategories=", StringComparison.CurrentCulture) Then
                LngToolStripMenuCategories = str.Substring(27)
            ElseIf str.StartsWith("LngToolStripMenuDescription=", StringComparison.CurrentCulture) Then
                LngToolStripMenuDescription = str.Substring(28)
            ElseIf str.StartsWith("LngToolStripMenuCalendar=", StringComparison.CurrentCulture) Then
                LngToolStripMenuCalendar = str.Substring(25)

                'MAINFORM_TOOLSTRIP_MENU_OPTIONS
            ElseIf str.StartsWith("LngToolStripMenuOptions=", StringComparison.CurrentCulture) Then
                LngToolStripMenuOptions = str.Substring(24)
            ElseIf str.StartsWith("LngToolStripMenuOptionsUpdate=", StringComparison.CurrentCulture) Then
                LngToolStripMenuOptionsUpdate = str.Substring(30)
            ElseIf str.StartsWith("LngToolStripMenuOptionsAutoUpdate=", StringComparison.CurrentCulture) Then
                LngToolStripMenuOptionsAutoUpdate = str.Substring(34)
            ElseIf str.StartsWith("LngToolStripMenuOptionsPreferences=", StringComparison.CurrentCulture) Then
                LngToolStripMenuOptionsPreferences = str.Substring(35)
            ElseIf str.StartsWith("LngToolStripMenuOptionsLogos=", StringComparison.CurrentCulture) Then
                LngToolStripMenuOptionsLogos = str.Substring(29)
            ElseIf str.StartsWith("LngToolStripMenuOptionsDualMonitor=", StringComparison.CurrentCulture) Then
                LngToolStripMenuOptionsDualMonitor = str.Substring(35)
            ElseIf str.StartsWith("LngToolStripMenuOptionsEngineSelection=", StringComparison.CurrentCulture) Then
                LngToolStripMenuOptionsEngineSelection = str.Substring(39)

                'MAINFORM_TOOLSTRIP_MENU_HELP
            ElseIf str.StartsWith("LngToolStripMenuHelp=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelp = str.Substring(21)
            ElseIf str.StartsWith("LngToolStripMenuHelpHelptopics=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpHelptopics = str.Substring(31)
            ElseIf str.StartsWith("LngToolStripMenuHelpHelpShortcuts=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpHelpShortcuts = str.Substring(34)
            ElseIf str.StartsWith("LngToolStripMenuHelpWebsite=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpWebsite = str.Substring(28)
            ElseIf str.StartsWith("LngToolStripMenuHelpForum=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpForum = str.Substring(26)
            ElseIf str.StartsWith("LngToolStripMenuHelpLanguage=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpLanguage = str.Substring(29)
            ElseIf str.StartsWith("LngToolStripMenuHelpAbout=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpAbout = str.Substring(26)
            ElseIf str.StartsWith("LngToolStripMenuHelpManualFeedBack=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpManualFeedBack = str.Substring(35)
            ElseIf str.StartsWith("LngToolStripMenuHelpDonate=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpDonate = str.Substring(27)
            ElseIf str.StartsWith("LngToolStripMenuHelpCompensation=", StringComparison.CurrentCulture) Then
                LngToolStripMenuHelpCompensation = str.Substring(33)

                'MAINFORM_TOOLSTRIP
            ElseIf str.StartsWith("LngToolStripSave=", StringComparison.CurrentCulture) Then
                LngToolStripSave = str.Substring(17)
            ElseIf str.StartsWith("LngToolStripSearch=", StringComparison.CurrentCulture) Then
                LngToolStripSearch = str.Substring(19)
            ElseIf str.StartsWith("LngToolStripOntop=", StringComparison.CurrentCulture) Then
                LngToolStripOntop = str.Substring(18)
            ElseIf str.StartsWith("LngToolStripPreferences=", StringComparison.CurrentCulture) Then
                LngToolStripPreferences = str.Substring(24)
            ElseIf str.StartsWith("LngToolStripLogos=", StringComparison.CurrentCulture) Then
                LngToolStripLogos = str.Substring(18)
            ElseIf str.StartsWith("LngToolStripUpdate=", StringComparison.CurrentCulture) Then
                LngToolStripUpdate = str.Substring(19)
            ElseIf str.StartsWith("LngToolStripAutoUpdate=", StringComparison.CurrentCulture) Then
                LngToolStripAutoUpdate = str.Substring(23)
            ElseIf str.StartsWith("LngToolStripDualMonitor=", StringComparison.CurrentCulture) Then
                LngToolStripDualMonitor = str.Substring(24)
            ElseIf str.StartsWith("LngToolStripWebsite=", StringComparison.CurrentCulture) Then
                LngToolStripWebsite = str.Substring(20)
            ElseIf str.StartsWith("LngToolStripForum=", StringComparison.CurrentCulture) Then
                LngToolStripForum = str.Substring(18)
            ElseIf str.StartsWith("LngToolStripLangue=", StringComparison.CurrentCulture) Then
                LngToolStripLangue = str.Substring(19)
            ElseIf str.StartsWith("LngToolStripAbout=", StringComparison.CurrentCulture) Then
                LngToolStripAbout = str.Substring(18)
            ElseIf str.StartsWith("LngToolStripHelptopics=", StringComparison.CurrentCulture) Then
                LngToolStripHelptopics = str.Substring(23)
            ElseIf str.StartsWith("LngToolStripHelpShortcuts=", StringComparison.CurrentCulture) Then
                LngToolStripHelpShortcuts = str.Substring(26)
            ElseIf str.StartsWith("LngToolStripCategories=", StringComparison.CurrentCulture) Then
                LngToolStripCategories = str.Substring(23)
            ElseIf str.StartsWith("LngToolStripDescription=", StringComparison.CurrentCulture) Then
                LngToolStripDescription = str.Substring(24)
            ElseIf str.StartsWith("LngToolStripCalendar=", StringComparison.CurrentCulture) Then
                LngToolStripCalendar = str.Substring(21)
            ElseIf str.StartsWith("LngToolStripManualFeedBack=", StringComparison.CurrentCulture) Then
                LngToolStripManualFeedBack = str.Substring(27)
            ElseIf str.StartsWith("LngToolStripTextBoxRecherche=", StringComparison.CurrentCulture) Then
                LngToolStripTextBoxRecherche = str.Substring(29)
            ElseIf str.StartsWith("LngToolStripButtonRecherche=", StringComparison.CurrentCulture) Then
                LngToolStripButtonRecherche = str.Substring(28)
            ElseIf str.StartsWith("LngToolStripButtonDonate=", StringComparison.CurrentCulture) Then
                LngToolStripButtonDonate = str.Substring(25)

                'MAINFORM_PAVE
            ElseIf str.StartsWith("LngPaveJourMoins=", StringComparison.CurrentCulture) Then
                LngPaveJourMoins = str.Substring(17)
            ElseIf str.StartsWith("LngPaveHeureMoins=", StringComparison.CurrentCulture) Then
                LngPaveHeureMoins = str.Substring(18)
            ElseIf str.StartsWith("LngPave6H=", StringComparison.CurrentCulture) Then
                LngPave6H = str.Substring(10)
            ElseIf str.StartsWith("LngPave9H=", StringComparison.CurrentCulture) Then
                LngPave9H = str.Substring(10)
            ElseIf str.StartsWith("LngPave12H=", StringComparison.CurrentCulture) Then
                LngPave12H = str.Substring(11)
            ElseIf str.StartsWith("LngPave15H=", StringComparison.CurrentCulture) Then
                LngPave15H = str.Substring(11)
            ElseIf str.StartsWith("LngPave18H=", StringComparison.CurrentCulture) Then
                LngPave18H = str.Substring(11)
            ElseIf str.StartsWith("LngPave20H=", StringComparison.CurrentCulture) Then
                LngPave20H = str.Substring(11)
            ElseIf str.StartsWith("LngPave23H=", StringComparison.CurrentCulture) Then
                LngPave23H = str.Substring(11)
            ElseIf str.StartsWith("LngPaveMaintenant=", StringComparison.CurrentCulture) Then
                LngPaveMaintenant = str.Substring(18)
            ElseIf str.StartsWith("LngPaveHeurePlus=", StringComparison.CurrentCulture) Then
                LngPaveHeurePlus = str.Substring(17)
            ElseIf str.StartsWith("LngPaveJourPlus=", StringComparison.CurrentCulture) Then
                LngPaveJourPlus = str.Substring(16)

                'MAINFORM_CESOIR_MAINTENANT
            ElseIf str.StartsWith("LngPanelTitreCesoir=", StringComparison.CurrentCulture) Then
                LngPanelTitreCesoir = str.Substring(20)
            ElseIf str.StartsWith("LngPanelTitreMaintenant=", StringComparison.CurrentCulture) Then
                LngPanelTitreMaintenant = str.Substring(24)

                'REORGCHANNEL_TITLE
            ElseIf str.StartsWith("LngReorgChannelTitle=", StringComparison.CurrentCulture) Then
                LngReorgChannelTitle = str.Substring(21)

                'REORGCHANNEL_BUTTON
            ElseIf str.StartsWith("LngButtonMonterReorgChannel=", StringComparison.CurrentCulture) Then
                LngButtonMonterReorgChannel = str.Substring(28)
            ElseIf str.StartsWith("LngButtonDescendreReorgChannel=", StringComparison.CurrentCulture) Then
                LngButtonDescendreReorgChannel = str.Substring(31)
            ElseIf str.StartsWith("LngButtonSupprimerReorgChannel=", StringComparison.CurrentCulture) Then
                LngButtonSupprimerReorgChannel = str.Substring(31)
            ElseIf str.StartsWith("LngButtonLogoReorgChannel=", StringComparison.CurrentCulture) Then
                LngButtonLogoReorgChannel = str.Substring(26)
            ElseIf str.StartsWith("LngButtonEnregistrerReorgChannel=", StringComparison.CurrentCulture) Then
                LngButtonEnregistrerReorgChannel = str.Substring(33)
            ElseIf str.StartsWith("LngButtonAnnulerReorgChannel=", StringComparison.CurrentCulture) Then
                LngButtonAnnulerReorgChannel = str.Substring(29)
            ElseIf str.StartsWith("LngReorgChannelListViewColumns0=", StringComparison.CurrentCulture) Then
                LngReorgChannelListViewColumns0 = str.Substring(32)
            ElseIf str.StartsWith("LngReorgChannelListViewColumns1=", StringComparison.CurrentCulture) Then
                LngReorgChannelListViewColumns1 = str.Substring(32)

                'FRM_ABOUT_TITLE
            ElseIf str.StartsWith("LngAboutTitle=", StringComparison.CurrentCulture) Then
                LngAboutTitle = str.Substring(14)

                'FRM_ABOUT_TABPAGE_ABOUT
            ElseIf str.StartsWith("LngTabPageAbout=", StringComparison.CurrentCulture) Then
                LngTabPageAbout = str.Substring(16)

                'FRM_ABOUT_TABPAGE_AUTHORS
            ElseIf str.StartsWith("LngTabPageAuteurs=", StringComparison.CurrentCulture) Then
                LngTabPageAuteurs = str.Substring(18)
            ElseIf str.StartsWith("LngTextBoxAdmin=", StringComparison.CurrentCulture) Then
                LngTextBoxAdmin = str.Substring(16)
            ElseIf str.StartsWith("LngTextBoxDev=", StringComparison.CurrentCulture) Then
                LngTextBoxDev = str.Substring(14)
            ElseIf str.StartsWith("LngTextBoxTesters=", StringComparison.CurrentCulture) Then
                LngTextBoxTesters = str.Substring(18)
            ElseIf str.StartsWith("LngTextBoxContributors=", StringComparison.CurrentCulture) Then
                LngTextBoxContributors = str.Substring(23)
            ElseIf str.StartsWith("LngTextBoxThanks=", StringComparison.CurrentCulture) Then
                LngTextBoxThanks = str.Substring(17)

                'FRM_ABOUT_TABPAGE_LICENCE
            ElseIf str.StartsWith("LngTabPagelicence=", StringComparison.CurrentCulture) Then
                LngTabPagelicence = str.Substring(18)

                'FRM_ABOUT_TABPAGE_7ZIP
            ElseIf str.StartsWith("LngTabPage7zip=", StringComparison.CurrentCulture) Then
                LngTabPage7Zip = str.Substring(15)

                'FRM_ABOUT_TABPAGE_DONATE
            ElseIf str.StartsWith("LngTabPageDonate=", StringComparison.CurrentCulture) Then
                LngTabPageDonate = str.Substring(17)

                'FRMMISEAJOUR_TITLE
            ElseIf str.StartsWith("LngFrmMiseajour=", StringComparison.CurrentCulture) Then
                LngFrmMiseajour = str.Substring(16)

                'FRMMISEAJOUR
            ElseIf str.StartsWith("LngRadioButtonDownload=", StringComparison.CurrentCulture) Then
                LngRadioButtonDownload = str.Substring(23)
            ElseIf str.StartsWith("LngRadioButtonXmlPath=", StringComparison.CurrentCulture) Then
                LngRadioButtonXmlPath = str.Substring(22)
            ElseIf str.StartsWith("LngButtonTout=", StringComparison.CurrentCulture) Then
                LngButtonTout = str.Substring(14)
            ElseIf str.StartsWith("LngButtonSuppr=", StringComparison.CurrentCulture) Then
                LngButtonSuppr = str.Substring(15)
            ElseIf str.StartsWith("LngButtonMiseaJour=", StringComparison.CurrentCulture) Then
                LngButtonMiseaJour = str.Substring(19)
            ElseIf str.StartsWith("LngButtonDemarrer=", StringComparison.CurrentCulture) Then
                LngButtonDemarrer = str.Substring(18)
            ElseIf str.StartsWith("LngButtonAnnuler=", StringComparison.CurrentCulture) Then
                LngButtonAnnuler = str.Substring(17)
            ElseIf str.StartsWith("LngButtonEdit=", StringComparison.CurrentCulture) Then
                LngButtonEdit = str.Substring(14)
            ElseIf str.StartsWith("LngCheckBoxAutoRestartManualUpdate=", StringComparison.CurrentCulture) Then
                LngCheckBoxAutoRestartManualUpdate = str.Substring(35)

                'FRMMISEAJOURMESSAGE
            ElseIf str.StartsWith("LngErrorInChannelListRecovery=", StringComparison.CurrentCulture) Then
                LngErrorInChannelListRecovery = str.Substring(30)
            ElseIf str.StartsWith("LngNoURLUpdate=", StringComparison.CurrentCulture) Then
                LngNoUrlUpdate = str.Substring(15)
            ElseIf str.StartsWith("LngInvalidURL=", StringComparison.CurrentCulture) Then
                LngInvalidUrl = str.Substring(14)
            ElseIf str.StartsWith("LngUntraceableFile=", StringComparison.CurrentCulture) Then
                LngUntraceableFile = str.Substring(19)
            ElseIf str.StartsWith("LngInvalidFile=", StringComparison.CurrentCulture) Then
                LngInvalidFile = str.Substring(15)
            ElseIf str.StartsWith("LngErrorInUpdate=", StringComparison.CurrentCulture) Then
                LngErrorInUpdate = str.Substring(17)
            ElseIf str.StartsWith("LngErrorInXMLCopy=", StringComparison.CurrentCulture) Then
                LngErrorInXmlCopy = str.Substring(18)
            ElseIf str.StartsWith("LngErrorInFileCopy=", StringComparison.CurrentCulture) Then
                LngErrorInFileCopy = str.Substring(19)
            ElseIf str.StartsWith("LngErrorInUnzip=", StringComparison.CurrentCulture) Then
                LngErrorInUnzip = str.Substring(16)
            ElseIf str.StartsWith("LngWrongFileName=", StringComparison.CurrentCulture) Then
                LngWrongFileName = str.Substring(17)
            ElseIf str.StartsWith("LngFailURLFileDownload=", StringComparison.CurrentCulture) Then
                LngFailUrlFileDownload = str.Substring(23)
            ElseIf str.StartsWith("LngUntraceableURLListFile=", StringComparison.CurrentCulture) Then
                LngUntraceableUrlListFile = str.Substring(26)
            ElseIf str.StartsWith("LngTheFile=", StringComparison.CurrentCulture) Then
                LngTheFile = str.Substring(11)
            ElseIf str.StartsWith("LngDontExist=", StringComparison.CurrentCulture) Then
                LngDontExist = str.Substring(13)
            ElseIf str.StartsWith("LngProtectedFile=", StringComparison.CurrentCulture) Then
                LngProtectedFile = str.Substring(17)
            ElseIf str.StartsWith("LngChosenChannels=", StringComparison.CurrentCulture) Then
                LngChosenChannels = str.Substring(18)
            ElseIf str.StartsWith("LngAvailableChannels=", StringComparison.CurrentCulture) Then
                LngAvailableChannels = str.Substring(21)
            ElseIf str.StartsWith("LngChoseFile=", StringComparison.CurrentCulture) Then
                LngChoseFile = str.Substring(13)
            ElseIf str.StartsWith("LngInvalidChoice=", StringComparison.CurrentCulture) Then
                LngInvalidChoice = str.Substring(17)

                'MAINFORM_MENU_CONTEXTUEL_DESCRIPTION
            ElseIf str.StartsWith("LngToolStripMenuPrintDescript=", StringComparison.CurrentCulture) Then
                LngToolStripMenuPrintDescript = str.Substring(30)

                'MAINFORM_MESSAGE_PROXY
            ElseIf str.StartsWith("LngMsgProxyTitle=", StringComparison.CurrentCulture) Then
                LngMsgProxyTitle = str.Substring(17)
            ElseIf str.StartsWith("LngMsgProxy=", StringComparison.CurrentCulture) Then
                LngMsgProxy = str.Substring(12)

                ' MAINFORM TREEVIEW NODES
            ElseIf str.StartsWith("LngNodeFilter=", StringComparison.CurrentCulture) Then
                LngNodeFilter = str.Substring(14)
            ElseIf str.StartsWith("LngNodeCategory=", StringComparison.CurrentCulture) Then
                LngNodeCategory = str.Substring(16)
            ElseIf str.StartsWith("LngNodeCountry=", StringComparison.CurrentCulture) Then
                LngNodeCountry = str.Substring(15)
            ElseIf str.StartsWith("LngNodeProvider=", StringComparison.CurrentCulture) Then
                LngNodeProvider = str.Substring(16)

                'MESSAGEBOXBASEPERIMEE
            ElseIf str.StartsWith("LngMessageBoxBasePerimee=", StringComparison.CurrentCulture) Then
                LngMessageBoxBasePerimee = str.Substring(25)
            ElseIf str.StartsWith("LngMessageBoxBasePerimee1=", StringComparison.CurrentCulture) Then
                LngMessageBoxBasePerimee1 = str.Substring(26)
            ElseIf str.StartsWith("LngMessageBoxBasePerimeeTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxBasePerimeeTitre = str.Substring(30)

                'MESSAGEBOXNODATA
            ElseIf str.StartsWith("LngMessageBoxNoData=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoData = str.Substring(20)
            ElseIf str.StartsWith("LngMessageBoxNoDataTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoDataTitre = str.Substring(25)

                'MESSAGEBOXNOUPDATE
            ElseIf str.StartsWith("LngMessageBoxnoupdate=", StringComparison.CurrentCulture) Then
                LngMessageBoxnoupdate = str.Substring(22)
            ElseIf str.StartsWith("LngMessageBoxnoupdateTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxnoupdateTitre = str.Substring(27)

                'MESSAGEBOXMISEAJOUR
            ElseIf str.StartsWith("LngMessageBoxMiseaJour=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJour = str.Substring(23)
            ElseIf str.StartsWith("LngMessageBoxMiseaJour1=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJour1 = str.Substring(24)
            ElseIf str.StartsWith("LngMessageBoxMiseaJourTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJourTitre = str.Substring(28)

                'MESSAGEBOXMISEAJOURDONE
            ElseIf str.StartsWith("LngMessageBoxMiseaJourDone=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJourDone = str.Substring(27)
            ElseIf str.StartsWith("LngMessageBoxMiseaJour1Done=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJour1Done = str.Substring(28)
            ElseIf str.StartsWith("LngMessageBoxMiseaJourTitreDone=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJourTitreDone = str.Substring(32)

                'MESSAGEBOXMODIFPREF
            ElseIf str.StartsWith("LngMessageBoxModifPref=", StringComparison.CurrentCulture) Then
                LngMessageBoxModifPref = str.Substring(23)
            ElseIf str.StartsWith("LngMessageBoxModifPref1=", StringComparison.CurrentCulture) Then
                LngMessageBoxModifPref1 = str.Substring(24)
            ElseIf str.StartsWith("LngMessageBoxModifPrefTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxModifPrefTitre = str.Substring(28)

                'MESSAGEBOXNOCONNECTION
            ElseIf str.StartsWith("LngMessageBoxNoConnection=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoConnection = str.Substring(26)
            ElseIf str.StartsWith("LngMessageBoxNoConnection1=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoConnection1 = str.Substring(27)
            ElseIf str.StartsWith("LngMessageBoxNoConnectionTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoConnectionTitre = str.Substring(31)

                'MESSAGEBOXFEEDBACK
            ElseIf str.StartsWith("LngMessageBoxFeedback=", StringComparison.CurrentCulture) Then
                LngMessageBoxFeedback = str.Substring(22)
            ElseIf str.StartsWith("LngMessageBoxFeedbackTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxFeedbackTitre = str.Substring(27)

                'MESSAGEBOXFICHIERCORROMPU
            ElseIf str.StartsWith("LngMessageFichierCorrompu=", StringComparison.CurrentCulture) Then
                LngMessageFichierCorrompu = str.Substring(26)
            ElseIf str.StartsWith("LngMessageFichierCorrompu1=", StringComparison.CurrentCulture) Then
                LngMessageFichierCorrompu1 = str.Substring(27)
            ElseIf str.StartsWith("LngMessageFichierCorrompu2=", StringComparison.CurrentCulture) Then
                LngMessageFichierCorrompu2 = str.Substring(27)
            ElseIf str.StartsWith("LngMessageFichierCorrompuTitre=", StringComparison.CurrentCulture) Then
                LngMessageFichierCorrompuTitre = str.Substring(31)

                'MESSAGEBOXLISTXMLTVFRCHOISIE
            ElseIf str.StartsWith("LngMessageBoxListXMLTVFRChoisie=", StringComparison.CurrentCulture) Then
                LngMessageBoxListXmltvfrChoisie = str.Substring(32)
            ElseIf str.StartsWith("LngMessageBoxListXMLTVFRChoisie1=", StringComparison.CurrentCulture) Then
                LngMessageBoxListXmltvfrChoisie1 = str.Substring(33)
            ElseIf str.StartsWith("LngMessageBoxListXMLTVFRChoisieTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxListXmltvfrChoisieTitre = str.Substring(37)

                'MESSAGEBOXTHETVDBNORESULT
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoResult=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoResult = str.Substring(29)
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoResultTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoResultTitre = str.Substring(34)

                'MESSAGEBOXTHETVDBVALIDESERIEID
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoValidSeriesId=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoValidSeriesId = str.Substring(36)
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoValidSeriesIdTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoValidSeriesIdTitre = str.Substring(41)

                'THETVDBBOXNOSHEET
            ElseIf str.StartsWith("LngThetvdbBoxNoSheet=", StringComparison.CurrentCulture) Then
                LngThetvdbBoxNoSheet = str.Substring(21)
            ElseIf str.StartsWith("LngThetvdbBoxNoSheetTitre=", StringComparison.CurrentCulture) Then
                LngThetvdbBoxNoSheetTitre = str.Substring(26)

                'MESSAGEBOXTHETVDBNOSERIEDETAIL
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoSerieDetail=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoSerieDetail = str.Substring(34)
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoSerieDetailTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoSerieDetailTitre = str.Substring(39)

                'MESSAGEBOXTHETVDBNOACTORINFO
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoActorInfo=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoActorInfo = str.Substring(32)
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoActorInfoTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoActorInfoTitre = str.Substring(37)

                'MESSAGEBOXTHETVDBNOBANNER
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoBanner=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoBanner = str.Substring(32)
            ElseIf str.StartsWith("LngMessageBoxThetvdbNoNoBannerTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxThetvdbNoBannerTitre = str.Substring(37)

                'MESSAGEBOXMESSAGEENVOYE
            ElseIf str.StartsWith("LngMessageBoxMessageEnvoye=", StringComparison.CurrentCulture) Then
                LngMessageBoxMessageEnvoye = str.Substring(27)
            ElseIf str.StartsWith("LngMessageBoxMessageEnvoyeTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxMessageEnvoyeTitre = str.Substring(32)

                'MESSAGEBOXMESSAGEISEMPTY
            ElseIf str.StartsWith("LngMessageBoxMessageIsEmpty=", StringComparison.CurrentCulture) Then
                LngMessageBoxMessageIsEmpty = str.Substring(28)
            ElseIf str.StartsWith("LngMessageBoxMessageIsEmptyTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxMessageIsEmptyTitre = str.Substring(33)

                'MESSAGEBOXFILERESTORE
            ElseIf str.StartsWith("LngMessageBoxFileRestoreTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxFileRestoreTitre = str.Substring(30)
            ElseIf str.StartsWith("LngMessageBoxFileRestore=", StringComparison.CurrentCulture) Then
                LngMessageBoxFileRestore = str.Substring(25)
            ElseIf str.StartsWith("LngMessageBoxFileRestore1=", StringComparison.CurrentCulture) Then
                LngMessageBoxFileRestore1 = str.Substring(26)
            ElseIf str.StartsWith("LngMessageBoxFileRestore2=", StringComparison.CurrentCulture) Then
                LngMessageBoxFileRestore2 = str.Substring(26)

                'MESSAGEBOXNORESTORESELECTED
            ElseIf str.StartsWith("LngMessageBoxNoRestoreSelectedTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoRestoreSelectedTitre = str.Substring(36)
            ElseIf str.StartsWith("LngMessageBoxNoRestoreSelected=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoRestoreSelected = str.Substring(31)

                'MESSAGEBOXNORESTOREELEMENT
            ElseIf str.StartsWith("LngMessageBoxNoRestoreElementTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoRestoreElementTitre = str.Substring(35)
            ElseIf str.StartsWith("LngMessageBoxNoRestoreElement=", StringComparison.CurrentCulture) Then
                LngMessageBoxNoRestoreElement = str.Substring(30)

                'MESSAGEBOXREORGCHANNEL
            ElseIf str.StartsWith("LngMessageBoxReorgChannel=", StringComparison.CurrentCulture) Then
                LngMessageBoxReorgChannel = str.Substring(26)
            ElseIf str.StartsWith("LngMessageBoxReorgChannel1=", StringComparison.CurrentCulture) Then
                LngMessageBoxReorgChannel1 = str.Substring(27)
            ElseIf str.StartsWith("LngMessageBoxReorgChannelTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxReorgChannelTitre = str.Substring(31)

                'MESSAGEBOXRESUME
            ElseIf str.StartsWith("LngMessageBoxResume=", StringComparison.CurrentCulture) Then
                LngMessageBoxResume = str.Substring(20)
            ElseIf str.StartsWith("LngMessageBoxResume1=", StringComparison.CurrentCulture) Then
                LngMessageBoxResume1 = str.Substring(21)
            ElseIf str.StartsWith("LngMessageBoxResumeTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxResumeTitre = str.Substring(25)

                'MESSAGEBOXRAZ
            ElseIf str.StartsWith("LngMessageBoxRaz=", StringComparison.CurrentCulture) Then
                LngMessageBoxRaz = str.Substring(17)
            ElseIf str.StartsWith("LngMessageBoxRaz1=", StringComparison.CurrentCulture) Then
                LngMessageBoxRaz1 = str.Substring(18)
            ElseIf str.StartsWith("LngMessageBoxTitleRaz=", StringComparison.CurrentCulture) Then
                LngMessageBoxTitleRaz = str.Substring(22)

                'MESSAGEBOXMISEAJOUREXE
            ElseIf str.StartsWith("LngMessageBoxMiseaJourExe=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJourExe = str.Substring(26)
            ElseIf str.StartsWith("LngMessageBoxMiseaJourExe1=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJourExe1 = str.Substring(27)
            ElseIf str.StartsWith("LngMessageBoxMiseaJourExeTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJourExeTitre = str.Substring(31)
            ElseIf str.StartsWith("LngMessageBoxMiseaJourExeActual=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJourExeActual = str.Substring(32)
            ElseIf str.StartsWith("LngMessageBoxMiseaJourExeNew=", StringComparison.CurrentCulture) Then
                LngMessageBoxMiseaJourExeNew = str.Substring(29)

                'MESSAGEBOXDIRCHECKED
            ElseIf str.StartsWith("LngMessageBoxDirChecked=", StringComparison.CurrentCulture) Then
                LngMessageBoxDirChecked = str.Substring(24)
            ElseIf str.StartsWith("LngMessageBoxDirChecked1=", StringComparison.CurrentCulture) Then
                LngMessageBoxDirChecked1 = str.Substring(25)
            ElseIf str.StartsWith("LngMessageBoxDirCheckedTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxDirCheckedTitre = str.Substring(29)

                'MESSAGEBOXFILENOTEXIST
            ElseIf str.StartsWith("LngMessageBoxFileNotExist=", StringComparison.CurrentCulture) Then
                LngMessageBoxFileNotExist = str.Substring(26)
            ElseIf str.StartsWith("LngMessageBoxFileNotExist1=", StringComparison.CurrentCulture) Then
                LngMessageBoxFileNotExist1 = str.Substring(27)
            ElseIf str.StartsWith("LngMessageBoxFileNotExistTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxFileNotExistTitre = str.Substring(31)

                'MESSAGEBOXURLCHECKED
            ElseIf str.StartsWith("LngMessageBoxURLChecked=", StringComparison.CurrentCulture) Then
                LngMessageBoxUrlChecked = str.Substring(24)
            ElseIf str.StartsWith("LngMessageBoxURLChecked1=", StringComparison.CurrentCulture) Then
                LngMessageBoxUrlChecked1 = str.Substring(25)
            ElseIf str.StartsWith("LngMessageBoxURLCheckedTitre=", StringComparison.CurrentCulture) Then
                LngMessageBoxUrlCheckedTitre = str.Substring(29)

                'MESSAGEBOXSAVEDONE
            ElseIf str.StartsWith("LngMessageboxSaveDone=", StringComparison.CurrentCulture) Then
                LngMessageboxSaveDone = str.Substring(22)
            ElseIf str.StartsWith("LngMessageboxSaveDoneTitre=", StringComparison.CurrentCulture) Then
                LngMessageboxSaveDoneTitre = str.Substring(27)

                'MESSAGEBOXRENAMEDONE
            ElseIf str.StartsWith("LngMessageboxRenameDone=", StringComparison.CurrentCulture) Then
                LngMessageboxRenameDone = str.Substring(24)
            ElseIf str.StartsWith("LngMessageboxRenameDoneTitre=", StringComparison.CurrentCulture) Then
                LngMessageboxRenameDoneTitre = str.Substring(30)

                'MESSAGEBOXDELETEDONE
            ElseIf str.StartsWith("LngMessageboxDeleteDone=", StringComparison.CurrentCulture) Then
                LngMessageboxDeleteDone = str.Substring(24)
            ElseIf str.StartsWith("LngMessageboxDeleteDoneTitre=", StringComparison.CurrentCulture) Then
                LngMessageboxDeleteDoneTitre = str.Substring(30)

                'INPUTBOXNAMEBDD
            ElseIf str.StartsWith("LngInputBoxNameBdd=", StringComparison.CurrentCulture) Then
                LngInputBoxNameBdd = str.Substring(19)
            ElseIf str.StartsWith("LngInputBoxNameBddTitre=", StringComparison.CurrentCulture) Then
                LngInputBoxNameBddTitre = str.Substring(24)

                'INPUTBOXRENAMEBDD
            ElseIf str.StartsWith("LngInputBoxRenameBdd=", StringComparison.CurrentCulture) Then
                LngInputBoxRenameBdd = str.Substring(21)
            ElseIf str.StartsWith("LngInputBoxRenameBddTitre=", StringComparison.CurrentCulture) Then
                LngInputBoxRenameBddTitre = str.Substring(26)

                'MISEAJOURAUTO
            ElseIf str.StartsWith("LngMiseAJourAutoTitle=", StringComparison.CurrentCulture) Then
                LngMiseAJourAutoTitle = str.Substring(22)
            ElseIf str.StartsWith("LngNodenumber=", StringComparison.CurrentCulture) Then
                LngNodeNumber = str.Substring(14)
            ElseIf str.StartsWith("LngAutoUpdateOperation=", StringComparison.CurrentCulture) Then
                LngAutoUpdateOperation = str.Substring(23)
            ElseIf str.StartsWith("LngdwnlOperation=", StringComparison.CurrentCulture) Then
                LngdwnlOperation = str.Substring(17)
            ElseIf str.StartsWith("LngParsingOperation=", StringComparison.CurrentCulture) Then
                LngParsingOperation = str.Substring(20)
            ElseIf str.StartsWith("LngremainingTime=", StringComparison.CurrentCulture) Then
                LngremainingTime = str.Substring(17)
            ElseIf str.StartsWith("LngfileSize=", StringComparison.CurrentCulture) Then
                LngfileSize = str.Substring(12)

                'MISEAJOURAUTOMESSAGE
            ElseIf str.StartsWith("LngError1Majauto=", StringComparison.CurrentCulture) Then
                LngError1Majauto = str.Substring(17)
            ElseIf str.StartsWith("LngError2Majauto=", StringComparison.CurrentCulture) Then
                LngError2Majauto = str.Substring(17)
            ElseIf str.StartsWith("LngError3Majauto=", StringComparison.CurrentCulture) Then
                LngError3Majauto = str.Substring(17)
            ElseIf str.StartsWith("LngError4Majauto=", StringComparison.CurrentCulture) Then
                LngError4Majauto = str.Substring(17)
            ElseIf str.StartsWith("LngError5Majauto=", StringComparison.CurrentCulture) Then
                LngError5Majauto = str.Substring(17)
            ElseIf str.StartsWith("LngError6Majauto=", StringComparison.CurrentCulture) Then
                LngError6Majauto = str.Substring(17)

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

                'TRIAVANCE
            ElseIf str.StartsWith("LngTriAvanceTitle=", StringComparison.CurrentCulture) Then
                LngTriAvanceTitle = str.Substring(18)
            ElseIf str.StartsWith("LngTriAvanceLabeltitre=", StringComparison.CurrentCulture) Then
                LngTriAvanceLabeltitre = str.Substring(23)
            ElseIf str.StartsWith("LngTriAvanceLabelauteur=", StringComparison.CurrentCulture) Then
                LngTriAvanceLabelauteur = str.Substring(24)
            ElseIf str.StartsWith("LngTriAvanceLabelndefini=", StringComparison.CurrentCulture) Then
                LngTriAvanceLabelndefini = str.Substring(25)
            ElseIf str.StartsWith("LngTriAvanceButtonSearch=", StringComparison.CurrentCulture) Then
                LngTriAvanceButtonSearch = str.Substring(25)
            ElseIf str.StartsWith("LngTriAvanceButtonCancel=", StringComparison.CurrentCulture) Then
                LngTriAvanceButtonCancel = str.Substring(25)
            ElseIf str.StartsWith("LngTriAvanceGroupBoxCriteres=", StringComparison.CurrentCulture) Then
                LngTriAvanceGroupBoxCriteres = str.Substring(29)
            ElseIf str.StartsWith("LngTriAvanceCheckBoxNow=", StringComparison.CurrentCulture) Then
                LngTriAvanceCheckBoxNow = str.Substring(24)
            ElseIf str.StartsWith("LngTriAvanceCheckBoxBegin=", StringComparison.CurrentCulture) Then
                LngTriAvanceCheckBoxBegin = str.Substring(26)
            ElseIf str.StartsWith("LngTriAvanceListViewColumns0=", StringComparison.CurrentCulture) Then
                LngTriAvanceListViewColumns0 = str.Substring(29)
            ElseIf str.StartsWith("LngTriAvanceListViewColumns1=", StringComparison.CurrentCulture) Then
                LngTriAvanceListViewColumns1 = str.Substring(29)
            ElseIf str.StartsWith("LngTriAvanceListViewColumns2=", StringComparison.CurrentCulture) Then
                LngTriAvanceListViewColumns2 = str.Substring(29)
            ElseIf str.StartsWith("LngTriAvanceListViewColumns3=", StringComparison.CurrentCulture) Then
                LngTriAvanceListViewColumns3 = str.Substring(29)
            ElseIf str.StartsWith("LngTriAvanceListViewColumns4=", StringComparison.CurrentCulture) Then
                LngTriAvanceListViewColumns4 = str.Substring(29)

                'CALENDRIER
            ElseIf str.StartsWith("LngCalendarLundiLabel=", StringComparison.CurrentCulture) Then
                LngCalendarLundiLabel = str.Substring(22)
            ElseIf str.StartsWith("LngCalendarMardiLabel=", StringComparison.CurrentCulture) Then
                LngCalendarMardiLabel = str.Substring(22)
            ElseIf str.StartsWith("LngCalendarMercrediLabel=", StringComparison.CurrentCulture) Then
                LngCalendarMercrediLabel = str.Substring(25)
            ElseIf str.StartsWith("LngCalendarJeudiLabel=", StringComparison.CurrentCulture) Then
                LngCalendarJeudiLabel = str.Substring(22)
            ElseIf str.StartsWith("LngCalendarVendrediLabel=", StringComparison.CurrentCulture) Then
                LngCalendarVendrediLabel = str.Substring(25)
            ElseIf str.StartsWith("LngCalendarSamediLabel=", StringComparison.CurrentCulture) Then
                LngCalendarSamediLabel = str.Substring(23)
            ElseIf str.StartsWith("LngCalendarDimancheLabel=", StringComparison.CurrentCulture) Then
                LngCalendarDimancheLabel = str.Substring(25)

            ElseIf str.StartsWith("LngNameofMonth1=", StringComparison.CurrentCulture) Then
                LngNameofMonth1 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth2=", StringComparison.CurrentCulture) Then
                LngNameofMonth2 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth3=", StringComparison.CurrentCulture) Then
                LngNameofMonth3 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth4=", StringComparison.CurrentCulture) Then
                LngNameofMonth4 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth5=", StringComparison.CurrentCulture) Then
                LngNameofMonth5 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth6=", StringComparison.CurrentCulture) Then
                LngNameofMonth6 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth7=", StringComparison.CurrentCulture) Then
                LngNameofMonth7 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth8=", StringComparison.CurrentCulture) Then
                LngNameofMonth8 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth9=", StringComparison.CurrentCulture) Then
                LngNameofMonth9 = str.Substring(16)
            ElseIf str.StartsWith("LngNameofMonth10=", StringComparison.CurrentCulture) Then
                LngNameofMonth10 = str.Substring(17)
            ElseIf str.StartsWith("LngNameofMonth11=", StringComparison.CurrentCulture) Then
                LngNameofMonth11 = str.Substring(17)
            ElseIf str.StartsWith("LngNameofMonth12=", StringComparison.CurrentCulture) Then
                LngNameofMonth12 = str.Substring(17)

                'DESCRIPTBOX
            ElseIf str.StartsWith("LngDescriptLundiLabel=", StringComparison.CurrentCulture) Then
                LngDescriptLundiLabel = str.Substring(22)
            ElseIf str.StartsWith("LngDescriptMardiLabel=", StringComparison.CurrentCulture) Then
                LngDescriptMardiLabel = str.Substring(22)
            ElseIf str.StartsWith("LngDescriptMercrediLabel=", StringComparison.CurrentCulture) Then
                LngDescriptMercrediLabel = str.Substring(25)
            ElseIf str.StartsWith("LngDescriptJeudiLabel=", StringComparison.CurrentCulture) Then
                LngDescriptJeudiLabel = str.Substring(22)
            ElseIf str.StartsWith("LngDescriptVendrediLabel=", StringComparison.CurrentCulture) Then
                LngDescriptVendrediLabel = str.Substring(25)
            ElseIf str.StartsWith("LngDescriptSamediLabel=", StringComparison.CurrentCulture) Then
                LngDescriptSamediLabel = str.Substring(23)
            ElseIf str.StartsWith("LngDescriptDimancheLabel=", StringComparison.CurrentCulture) Then
                LngDescriptDimancheLabel = str.Substring(25)

                'FEEDBACK
            ElseIf str.StartsWith("LngFeedbackTitle=", StringComparison.CurrentCulture) Then
                LngFeedbackTitle = str.Substring(17)
            ElseIf str.StartsWith("LngLabelExceptMessage1=", StringComparison.CurrentCulture) Then
                LngLabelExceptMessage1 = str.Substring(23)
            ElseIf str.StartsWith("LngLabelExceptMessage2=", StringComparison.CurrentCulture) Then
                LngLabelExceptMessage2 = str.Substring(23)
            ElseIf str.StartsWith("LngLabelExceptMessage3=", StringComparison.CurrentCulture) Then
                LngLabelExceptMessage3 = str.Substring(23)
            ElseIf str.StartsWith("LngLabelExceptMessage4=", StringComparison.CurrentCulture) Then
                LngLabelExceptMessage4 = str.Substring(23)
            ElseIf str.StartsWith("LngCheckBoxExceptErrorMessage=", StringComparison.CurrentCulture) Then
                LngCheckBoxExceptErrorMessage = str.Substring(30)
            ElseIf str.StartsWith("LngLabelEmail=", StringComparison.CurrentCulture) Then
                LngLabelEmail = str.Substring(14)
            ElseIf str.StartsWith("LngSendButton=", StringComparison.CurrentCulture) Then
                LngSendButton = str.Substring(14)
            ElseIf str.StartsWith("LngCopierButton=", StringComparison.CurrentCulture) Then
                LngCopierButton = str.Substring(16)
            ElseIf str.StartsWith("LngExitButton=", StringComparison.CurrentCulture) Then
                LngExitButton = str.Substring(14)
            ElseIf str.StartsWith("LngExceptErrorMessage=", StringComparison.CurrentCulture) Then
                LngExceptErrorMessage = str.Substring(22)
            ElseIf str.StartsWith("LngLabelFeedbackSend=", StringComparison.CurrentCulture) Then
                LngLabelFeedbackSend = str.Substring(21)
            ElseIf str.StartsWith("LngZGuideTVRelease=", StringComparison.CurrentCulture) Then
                LngZGuideTvRelease = str.Substring(19)
            ElseIf str.StartsWith("LngCompilationDate=", StringComparison.CurrentCulture) Then
                LngCompilationDate = str.Substring(19)
            ElseIf str.StartsWith("LngOSRelease=", StringComparison.CurrentCulture) Then
                LngOsRelease = str.Substring(13)
            ElseIf str.StartsWith("LngArchitecture=", StringComparison.CurrentCulture) Then
                LngArchitecture = str.Substring(16)
            ElseIf str.StartsWith("LngOSBootMode=", StringComparison.CurrentCulture) Then
                LngOsBootMode = str.Substring(14)
            ElseIf str.StartsWith("LngFramework=", StringComparison.CurrentCulture) Then
                LngFramework = str.Substring(13)
            ElseIf str.StartsWith("LngOSLanguage=", StringComparison.CurrentCulture) Then
                LngOsLanguage = str.Substring(14)
            ElseIf str.StartsWith("LngTotalMemory=", StringComparison.CurrentCulture) Then
                LngTotalMemory = str.Substring(15)
            ElseIf str.StartsWith("LngRemainingMemory=", StringComparison.CurrentCulture) Then
                LngRemainingMemory = str.Substring(19)
            ElseIf str.StartsWith("LngUsedMemory=", StringComparison.CurrentCulture) Then
                LngUsedMemory = str.Substring(14)
            ElseIf str.StartsWith("LngProcessorName=", StringComparison.CurrentCulture) Then
                LngProcessorName = str.Substring(17)
            ElseIf str.StartsWith("LngProcessorNumber=", StringComparison.CurrentCulture) Then
                LngProcessorNumber = str.Substring(19)
            ElseIf str.StartsWith("LngMonitorNumber=", StringComparison.CurrentCulture) Then
                LngMonitorNumber = str.Substring(17)
            ElseIf str.StartsWith("LngEmail=", StringComparison.CurrentCulture) Then
                LngEmail = str.Substring(9)
            ElseIf str.StartsWith("LngComments=", StringComparison.CurrentCulture) Then
                LngComments = str.Substring(12)
            ElseIf str.StartsWith("LngDescriptionError=", StringComparison.CurrentCulture) Then
                LngDescriptionError = str.Substring(20)
            ElseIf str.StartsWith("LngProcessorSpeed=", StringComparison.CurrentCulture) Then
                LngProcessorSpeed = str.Substring(18)
            ElseIf str.StartsWith("LngCheckBoxAcknowledgment=", StringComparison.CurrentCulture) Then
                LngCheckBoxAcknowledgment = str.Substring(26)
            ElseIf str.StartsWith("LngProcessorDescription=", StringComparison.CurrentCulture) Then
                LngProcessorDescription = str.Substring(24)

                'THETVDBTAB
            ElseIf str.StartsWith("LngThetvdbLabelSeriesTabSeries=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelSeriesTabSeries = str.Substring(31)
            ElseIf str.StartsWith("LngThetvdbLabelEpisodesTabEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelEpisodesTabEpisodes = str.Substring(35)
            ElseIf str.StartsWith("LngThetvdbLabelActorsTabActors=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelActorsTabActors = str.Substring(31)

                'THETVDB
            ElseIf str.StartsWith("LngThetvdbLabelSiteRating=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelSiteRating = str.Substring(26)
            ElseIf str.StartsWith("LngThetvdbLabelID=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelId = str.Substring(18)
            ElseIf str.StartsWith("LngThetvdbLabelRuntime=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelRuntime = str.Substring(23)
            ElseIf str.StartsWith("LngThetvdbLabelRating=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelRating = str.Substring(22)
            ElseIf str.StartsWith("LngThetvdbLabelSearchName=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelSearchName = str.Substring(26)
            ElseIf str.StartsWith("LngThetvdbLabelLanguage=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelLanguage = str.Substring(24)
            ElseIf str.StartsWith("LngThetvdbButtonSearch=", StringComparison.CurrentCulture) Then
                LngThetvdbButtonSearch = str.Substring(23)
            ElseIf str.StartsWith("LngThetvdbButtonExit=", StringComparison.CurrentCulture) Then
                LngThetvdbButtonExit = str.Substring(21)
            ElseIf str.StartsWith("LngThetvdbLabelDescription=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelDescription = str.Substring(27)
            ElseIf str.StartsWith("LngThetvdbLabelGenre=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelGenre = str.Substring(21)
            ElseIf str.StartsWith("LngThetvdbLabelActors=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelActors = str.Substring(22)
            ElseIf str.StartsWith("LngThetvdbLabelActors1=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelActors1 = str.Substring(23)
            ElseIf str.StartsWith("LngThetvdbLabelGueststar=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelGueststar = str.Substring(25)
            ElseIf str.StartsWith("LngThetvdbLabelDirector=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelDirector = str.Substring(24)
            ElseIf str.StartsWith("LngThetvdbLabelWriter=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelWriter = str.Substring(22)
            ElseIf str.StartsWith("LngThetvdbLabelFirstAired=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelFirstAired = str.Substring(26)
            ElseIf str.StartsWith("LngThetvdbLabelIDTVCom=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelIdtvCom = str.Substring(23)
            ElseIf str.StartsWith("LngThetvdbLabelIDIMDBCom=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelIdimdbCom = str.Substring(25)
            ElseIf str.StartsWith("LngThetvdbLabelForceUpdate=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelForceUpdate = str.Substring(27)
            ElseIf str.StartsWith("LngThetvdbButtonLoad=", StringComparison.CurrentCulture) Then
                LngThetvdbButtonLoad = str.Substring(21)
            ElseIf str.StartsWith("LngThetvdbButtonCancel=", StringComparison.CurrentCulture) Then
                LngThetvdbButtonCancel = str.Substring(23)
            ElseIf str.StartsWith("LngThetvdbLabelLoadFull=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelLoadFull = str.Substring(24)
            ElseIf str.StartsWith("LngThetvdbLabelLoadActors=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelLoadActors = str.Substring(26)
            ElseIf str.StartsWith("LngThetvdbLabelBanner=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelBanner = str.Substring(22)
            ElseIf str.StartsWith("LngThetvdbLabelUseZipped=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelUseZipped = str.Substring(25)
            ElseIf str.StartsWith("LngThetvdbLabelOpen=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelOpen = str.Substring(20)
            ElseIf str.StartsWith("LngThetvdbLabelEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelEpisodes = str.Substring(24)

                'THETVDBTABEPISODE
            ElseIf str.StartsWith("LngThetvdbLabelAbsoluteNumberTabEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelAbsoluteNumberTabEpisodes = str.Substring(41)
            ElseIf str.StartsWith("LngThetvdbLabelProductCodeTabEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelProductCodeTabEpisodes = str.Substring(38)
            ElseIf str.StartsWith("LngThetvdbLabelDVDIDTabEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelDvdidTabEpisodes = str.Substring(32)
            ElseIf str.StartsWith("LngThetvdbLabelDVDSeasonTabEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelDvdSeasonTabEpisodes = str.Substring(36)
            ElseIf str.StartsWith("LngThetvdbLabelDVDNumberTabEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelDvdNumberTabEpisodes = str.Substring(36)
            ElseIf str.StartsWith("LngThetvdbLabelDVDChapterTabEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelDvdChapterTabEpisodes = str.Substring(37)
            ElseIf str.StartsWith("LngThetvdbNodeSeasonTabEpisodes=", StringComparison.CurrentCulture) Then
                LngThetvdbNodeSeasonTabEpisodes = str.Substring(32)

                'THETVDBTABACTORS
            ElseIf str.StartsWith("LngThetvdbGroupBoxInformationTabActors=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelIdTabActors = str.Substring(39)
            ElseIf str.StartsWith("LngThetvdbLabelIDTabActors=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelIdTabActors = str.Substring(27)
            ElseIf str.StartsWith("LngThetvdbLabelNameTabActors=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelNameTabActors = str.Substring(29)
            ElseIf str.StartsWith("LngThetvdbLabelRoleTabActors=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelRoleTabActors = str.Substring(29)
            ElseIf str.StartsWith("LngThetvdbLabelSortOrderTabActors=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelSortOrderTabActors = str.Substring(34)

                'THETVDBRESULT
            ElseIf str.StartsWith("LngThetvdbGroupBoxResult=", StringComparison.CurrentCulture) Then
                LngThetvdbGroupBoxResult = str.Substring(25)
            ElseIf str.StartsWith("LngThetvdbLabelFirstAiredResult=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelFirstAiredResult = str.Substring(32)
            ElseIf str.StartsWith("LngThetvdbLabelIMDBIdResult=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelImdbIdResult = str.Substring(28)
            ElseIf str.StartsWith("LngThetvdbLabelOverviewResult=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelOverviewResult = str.Substring(30)
            ElseIf str.StartsWith("LngThetvdbLabelStatusResult=", StringComparison.CurrentCulture) Then
                LngThetvdbLabelStatusResult = str.Substring(28)
            ElseIf str.StartsWith("LngThetvdbButtonChooseResult=", StringComparison.CurrentCulture) Then
                LngThetvdbButtonChooseResult = str.Substring(29)
            ElseIf str.StartsWith("LngThetvdbButtonCancelResult=", StringComparison.CurrentCulture) Then
                LngThetvdbButtonCancelResult = str.Substring(29)
            ElseIf str.StartsWith("LngThetvdbListviewResultColumns0=", StringComparison.CurrentCulture) Then
                LngThetvdbListviewResultColumns0 = str.Substring(33)
            ElseIf str.StartsWith("LngThetvdbListviewResultColumns1=", StringComparison.CurrentCulture) Then
                LngThetvdbListviewResultColumns1 = str.Substring(33)
            ElseIf str.StartsWith("LngThetvdbListviewResultColumns2=", StringComparison.CurrentCulture) Then
                LngThetvdbListviewResultColumns2 = str.Substring(33)

                'CHANNELSVIEW
            ElseIf str.StartsWith("LngChannelViewTitle=", StringComparison.CurrentCulture) Then
                LngChannelViewTitle = str.Substring(20)
            ElseIf str.StartsWith("LngChannelViewCheckBox24hHours=", StringComparison.CurrentCulture) Then
                LngChannelViewCheckBox24HHours = str.Substring(31)
            ElseIf str.StartsWith("LngChannelViewLabelOr=", StringComparison.CurrentCulture) Then
                LngChannelViewLabelOr = str.Substring(22)
            ElseIf str.StartsWith("LngChannelViewButtonClose=", StringComparison.CurrentCulture) Then
                LngChannelViewButtonClose = str.Substring(26)
            ElseIf str.StartsWith("LngChannelViewListViewColumns0=", StringComparison.CurrentCulture) Then
                LngChannelViewListViewColumns0 = str.Substring(31)
            ElseIf str.StartsWith("LngChannelViewListViewColumns1=", StringComparison.CurrentCulture) Then
                LngChannelViewListViewColumns1 = str.Substring(31)
            ElseIf str.StartsWith("LngChannelViewListViewColumns2=", StringComparison.CurrentCulture) Then
                LngChannelViewListViewColumns2 = str.Substring(31)
            ElseIf str.StartsWith("LngChannelViewListViewColumns3=", StringComparison.CurrentCulture) Then
                LngChannelViewListViewColumns3 = str.Substring(31)

                'TIMEZONE
            ElseIf str.StartsWith("LngTimeZoneTitle=", StringComparison.CurrentCulture) Then
                LngTimeZoneTitle = str.Substring(17)
            ElseIf str.StartsWith("LngTimeZoneLabelCompensation=", StringComparison.CurrentCulture) Then
                LngTimeZoneLabelCompensation = str.Substring(29)
            ElseIf str.StartsWith("LngTimeZoneLabelMinute=", StringComparison.CurrentCulture) Then
                LngTimeZoneLabelMinute = str.Substring(23)

                'ENGINESELECTION
            ElseIf str.StartsWith("LngEngineSelectionTitle=", StringComparison.CurrentCulture) Then
                LngEngineSelectionTitle = str.Substring(24)
            ElseIf str.StartsWith("LngEngineSelectionTVDBListBox=", StringComparison.CurrentCulture) Then
                LngEngineSelectionTvdbListBox = str.Substring(30)
            ElseIf str.StartsWith("LngEngineSelectionIMDBListBox=", StringComparison.CurrentCulture) Then
                LngEngineSelectionImdbListBox = str.Substring(30)
            ElseIf str.StartsWith("LngEngineSelectionAllocineListBox=", StringComparison.CurrentCulture) Then
                LngEngineSelectionAllocineListBox = str.Substring(34)
            ElseIf str.StartsWith("LngEngineSelectionShowCheckBox=", StringComparison.CurrentCulture) Then
                LngEngineSelectionShowCheckBox = str.Substring(31)

                'STATUSSTRIP
            ElseIf str.StartsWith("LngToolStripStatusLabelActiveEngine=", StringComparison.CurrentCulture) Then
                LngToolStripStatusLabelActiveEngine = str.Substring(36)
            ElseIf str.StartsWith("LngToolStripStatusLabelTHEDVB=", StringComparison.CurrentCulture) Then
                LngToolStripStatusLabelThedvb = str.Substring(30)
            ElseIf str.StartsWith("LngToolStripStatusLabelIMDB=", StringComparison.CurrentCulture) Then
                LngToolStripStatusLabelImdb = str.Substring(28)
            ElseIf str.StartsWith("LngToolStripStatusLabelALLOCINE=", StringComparison.CurrentCulture) Then
                LngToolStripStatusLabelAllocine = str.Substring(32)
            ElseIf str.StartsWith("LngToolStripStatusLabelMemory=", StringComparison.CurrentCulture) Then
                LngToolStripStatusLabelMemory = str.Substring(30)
            ElseIf str.StartsWith("LngToolStripStatusLabelMB=", StringComparison.CurrentCulture) Then
                LngToolStripStatusLabelMb = str.Substring(26)
            ElseIf str.StartsWith("LngToolStripStatusLabelUpdate=", StringComparison.CurrentCulture) Then
                LngToolStripStatusLabelUpdate = str.Substring(30)

                'BALLONTIPS
            ElseIf str.StartsWith("LngBallonTipsNoInformation=", StringComparison.CurrentCulture) Then
                LngBallonTipsNoInformation = str.Substring(27)

                'GESTIONBDD
            ElseIf str.StartsWith("LngGestionBddTitre=", StringComparison.CurrentCulture) Then
                LngGestionBddTitre = str.Substring(19)
            ElseIf str.StartsWith("LngGestionBddButtonDelete=", StringComparison.CurrentCulture) Then
                LngGestionBddButtonDelete = str.Substring(26)
            ElseIf str.StartsWith("LngGestionBddButtonSave=", StringComparison.CurrentCulture) Then
                LngGestionBddButtonSave = str.Substring(24)
            ElseIf str.StartsWith("LngGestionBddButtonRestore=", StringComparison.CurrentCulture) Then
                LngGestionBddButtonRestore = str.Substring(27)
            ElseIf str.StartsWith("LngGestionBddButtonRename=", StringComparison.CurrentCulture) Then
                LngGestionBddButtonRename = str.Substring(26)
            ElseIf str.StartsWith("LngGestionBddButtonCancel=", StringComparison.CurrentCulture) Then
                LngGestionBddButtonCancel = str.Substring(26)
            ElseIf str.StartsWith("LngListViewGestionBddColumns0=", StringComparison.CurrentCulture) Then
                LngListViewGestionBddColumns0 = str.Substring(30)
            ElseIf str.StartsWith("LngListViewGestionBddColumns1=", StringComparison.CurrentCulture) Then
                LngListViewGestionBddColumns1 = str.Substring(30)
            ElseIf str.StartsWith("LngListViewGestionBddColumns2=", StringComparison.CurrentCulture) Then
                LngListViewGestionBddColumns2 = str.Substring(30)
            ElseIf str.StartsWith("LngGroupBoxRestauration=", StringComparison.CurrentCulture) Then
                LngGroupBoxRestauration = str.Substring(24)
            ElseIf str.StartsWith("LngCheckBoxRestaurationDataBase=", StringComparison.CurrentCulture) Then
                LngCheckBoxRestaurationDataBase = str.Substring(32)
            ElseIf str.StartsWith("LngCheckBoxRestaurationChaines=", StringComparison.CurrentCulture) Then
                LngCheckBoxRestaurationChaines = str.Substring(31)
            ElseIf str.StartsWith("LngCheckBoxRestaurationUrl=", StringComparison.CurrentCulture) Then
                LngCheckBoxRestaurationUrl = str.Substring(27)
            ElseIf str.StartsWith("LngCheckBoxRestaurationUserConfig=", StringComparison.CurrentCulture) Then
                LngCheckBoxRestaurationUserConfig = str.Substring(34)

                'PROGRESSBAR
            ElseIf str.StartsWith("LngProgressBarSaveTitre=", StringComparison.CurrentCulture) Then
                LngProgressBarSaveTitre = str.Substring(24)
            ElseIf str.StartsWith("LngProgressBarSaveLabel=", StringComparison.CurrentCulture) Then
                LngProgressBarSaveLabel = str.Substring(24)
            ElseIf str.StartsWith("LngProgressBarRestoreTitre=", StringComparison.CurrentCulture) Then
                LngProgressBarRestoreTitre = str.Substring(27)
            ElseIf str.StartsWith("LngProgressBarRestoreLabel=", StringComparison.CurrentCulture) Then
                LngProgressBarRestoreLabel = str.Substring(27)
            End If

            str = sr.ReadLine()
        Loop
        sr.Close()
    End Sub

    Public Sub LanguageCheck(Optional ByVal iForm As Integer = 0)

        ' 07/07/2009
        ' Si aucune langue n'est sélectionné au 1er démarrage de ZGuideTV l'anglais est sélectionné par défaut
        If My.Settings.Language = "English" OrElse (Not My.Settings.Language Is Nothing AndAlso String.IsNullOrEmpty(My.Settings.Language)) Then
            _languagefile = Application.StartupPath & "\languages\" & "English" & ".Lng"
            My.Settings.Language = "English"
            My.Settings.Save()
            Init(_languagefile)
            SetControlLanguage(iForm)
        Else
            _languagefile = Application.StartupPath & "\languages\" & My.Settings.Language & ".Lng"
            My.Settings.Save()
            Init(_languagefile)
            SetControlLanguage(iForm)
        End If
    End Sub
End Module
