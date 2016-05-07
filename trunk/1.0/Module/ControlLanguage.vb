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
Imports ZGuideTV.ZGuideTVDotNetTvdb

Friend Module ControlLanguage
    Public Sub SetControlLanguage(Optional ByVal iForm As Integer = 0)

        'SELECTLANGUAGE
        SelectLanguage.ButtonOK.Text = lngSelectLanguageButtonOK
        SelectLanguage.ButtonCancel.Text = lngSelectLanguageButtonCancel

        If iForm = 12 Then
            Return
        End If

        'PREMIERDEMARRAGE
        PremierDemarrage.Text = lngPremierDemarrageTitle
        PremierDemarrage.LabelUtilisateur.Text = lngLabelUtilisateur
        PremierDemarrage.GroupBoxProxy.Text = lngGroupBoxConnexion
        PremierDemarrage.GroupBoxProxy.Text = lngGroupBoxProxy
        PremierDemarrage.LabelUtilisateur.Text = lngLabelUtilisateur
        PremierDemarrage.LabelMotdePasse.Text = lngLabelMotdePasse
        PremierDemarrage.LabelProxy.Text = lngLabelProxy
        PremierDemarrage.LabelPort.Text = lngLabelPort
        PremierDemarrage.LabelInfo.Text = lngPremierDemarrageLabelInfo
        PremierDemarrage.GroupBoxChoixSource.Text = lngPremierDemarrageGroupBoxChoixSource
        PremierDemarrage.RadioButtonXMLTV.Text = lngPremierDemarrageRadioButtonXMLTV
        PremierDemarrage.RadioButtonEPGData.Text = lngPremierDemarrageRadioButtonEPGData
        PremierDemarrage.GroupBoxEPGData.Text = lngPremierDemarrageGroupBoxEPGData
        PremierDemarrage.LabelPinCode.Text = lngPremierDemarrageLabelPinCode
        PremierDemarrage.ButtonSubscription.Text = lngPremierDemarrageButtonSubscription
        PremierDemarrage.LabelInfoPrice.Text = lngPremierDemarrageLabelInfoPrice
        PremierDemarrage.ButtonOK.Text = lngPremierDemarrageButtonOK
        PremierDemarrage.ButtonCancel.Text = lngPremierDemarrageButtonCancel

        'MESSAGEBOXCODEPIN
        PremierDemarrage.MessageBoxNoCodePin = lngMessageBoxNoCodePin
        PremierDemarrage.MessageBoxNoCodePin1 = lngMessageBoxNoCodePin1
        PremierDemarrage.MessageBoxNoCodePinTitre = lngMessageBoxNoCodePinTitre

        'MESSAGEBOXNOCONNECTION
        PremierDemarrage.MessageBoxNoConnection = lngMessageBoxNoConnection
        PremierDemarrage.MessageBoxNoConnection1 = lngMessageBoxNoConnection1
        PremierDemarrage.MessageBoxNoConnectionTitre = lngMessageBoxNoConnectionTitre

        If iForm = 10 Then
            Return
        End If

        'EPGDATASUBSCRIPTION
        EPGDataSubscription.Text = lngEPGDataSubscriptionTitle
        EPGDataSubscription.LabelChoixPays.Text = lngEPGDataSubscriptionLabelChoixPays
        EPGDataSubscription.LabelChoixLangue.Text = lngEPGDataSubscriptionLabelChoixLangue
        EPGDataSubscription.ButtonGoEPGData.Text = lngEPGDataSubscriptionButtonGoEPGData

        'MESSAGEBOXEPGDATANOSUBSCRIPTION
        EPGDataSubscription.MessageBoxEPGDataSubscription = lngMessageBoxEPGDataSubscription
        EPGDataSubscription.MessageBoxEPGDataSubscription1 = lngMessageBoxEPGDataSubscription1
        EPGDataSubscription.MessageBoxEPGDataSubscriptionTitre = lngMessageBoxEPGDataSubscriptionTitre

        If iForm = 11 Then
            Return
        End If

        'PREF_TABPAGE_GENERAL
        Pref.Text = lngPrefTitle
        Pref.TabPageGeneral.Text = lngTabPageGeneral
        Pref.GroupBoxPurge.Text = lngGroupBoxPurge
        Pref.GroupBoxEffects.Text = lngGroupBoxEffects
        Pref.GroupBoxConfHardware.Text = LngGroupBoxConfHardware
        Pref.GroupBoxSauvegardeFenetre.Text = lngGroupBoxSauvegardeFenetre
        Pref.GroupBoxDivers.Text = lngGroupBoxDivers
        Pref.GroupBoxFiltres.Text = lngGroupBoxFiltres
        Pref.GroupBoxPosition.Text = lngGroupBoxPosition
        Pref.CheckBoxPurge.Text = lngCheckBoxPurge
        Pref.CheckBoxFadeOut.Text = lngCheckBoxFadeOut
        Pref.CheckBoxSlide.Text = lngCheckBoxSlide
        Pref.CheckBoxoldUI.Text = lngCheckBoxoldUI
        Pref.RadioButtonConfNormal.Text = lngRadioButtonConfNormal
        Pref.RadioButtonConfAverage.Text = lngRadioButtonConfAverage
        Pref.RadioButtonConfMinimum.Text = lngRadioButtonConfMinimum
        Pref.CheckBoxConfigWindow.Text = lngCheckBoxConfigWindow
        Pref.CheckBoxtracelog.Text = lngCheckBoxtracelog
        Pref.CheckBoxFilters.Text = lngCheckBoxFilters
        Pref.GroupBoxMouse.Text = lngGroupBoxMouse
        Pref.CheckBoxaccordscrollhorizontal.Text = lngCheckBoxaccordscrollhorizontal
        Pref.CheckBoxbuttonssave.Text = lngCheckBoxbuttonssave
        Pref.CheckBoxUrlUpdate.Text = lngCheckBoxUrlUpdate
        Pref.GroupBoxUrlUpdate.Text = lngGroupBoxUrlUpdate
        Pref.CheckBoxToolTipsBallon.Text = lngCheckBoxToolTipsBallon
        Pref.GroupBoxToolTipsBallon.Text = lngGroupBoxToolTipsBallon

        'PREF_TABPAGE_PROXY
        Pref.TabPageProxy.Text = lngTabPageProxy
        Pref.GroupBoxConnexion.Text = lngGroupBoxConnexion
        Pref.GroupBoxProxy.Text = lngGroupBoxProxy
        Pref.LabelUtilisateur.Text = lngLabelUtilisateur
        Pref.LabelMotdePasse.Text = lngLabelMotdePasse
        Pref.LabelProxy.Text = lngLabelProxy
        Pref.LabelPort.Text = lngLabelPort

        'PREF_TABPAGE_MAJ_DONNEES
        Pref.TabPageMiseajourDonnees.Text = lngTabPageMiseajourDonnees
        Pref.GroupBoxIntervalle.Text = lngGroupBoxIntervalle
        Pref.GroupBoxUpdateLast.Text = lngGroupBoxUpdateLast
        Pref.GroupBoxAutoUpdate.Text = lngGroupBoxAutoUpdate
        Pref.GroupBoxTailleBdd.Text = lngGroupBoxTailleBdd
        Pref.GroupBoxUpdateIn.Text = lngGroupBoxUpdateIn
        Pref.UpdateIn = lngUpdateIn
        Pref.GroupBoxUpdateNext.Text = lngGroupBoxUpdateNext
        Pref.RadioButtonDay1.Text = lngRadioButtonDay1
        Pref.RadioButtonDay2.Text = lngRadioButtonDay2
        Pref.RadioButtonDay3.Text = lngRadioButtonDay3
        Pref.RadioButtonDay4.Text = lngRadioButtonDay4
        Pref.RadioButtonDay5.Text = lngRadioButtonDay5
        Pref.CheckBoxAutoUpdate.Text = lngCheckBoxAutoUpdate
        Pref.GroupBoxChoixSource.Text = lngGroupBoxChoixSource
        Pref.RadioButtonXMLTV.Text = lngRadioButtonXMLTV
        Pref.RadioButtonEPGData.Text = lngRadioButtonEPGData
        Pref.GroupBoxEpgdata.Text = lngGroupBoxEpgdata
        Pref.LabelPinCode.Text = lngLabelPinCode
        Pref.LabelNbJourDownload.Text = lngLabelNbJourDownload
        Pref.LabelEpgdataExpiration.Text = lngLabelEpgdataExpiration
        Pref.BoutonSAbonner.Text = lngBoutonSAbonner
        Pref.LabelInfo.Text = lngLabelInfo

        'PREF_TABPAGE_MAJ_LOGICIEL
        Pref.TabPageMiseajourLogiciel.Text = lngTabPageMiseajourLogiciel
        Pref.GroupBoxIntervalles.Text = lngGroupBoxIntervalles
        Pref.GroupBoxLastCheck.Text = lngGroupBoxLastCheck
        Pref.GroupBoxNextCheck.Text = lngGroupBoxNextCheck
        Pref.GroupBoxCheck.Text = lngGroupBoxCheck
        Pref.GroupBoxCheckIn.Text = lngGroupBoxCheckIn
        Pref.CheckIn = lngCheckIn
        Pref.RadioButtonAllDays.Text = lngRadioButtonAllDays
        Pref.RadioButtonAllWeeks.Text = lngRadioButtonAllWeeks
        Pref.RadioButtonAllMonths.Text = lngRadioButtonAllMonths
        Pref.CheckBoxAutoverif.Text = lngCheckBoxAutoverif

        'PREF_TABPAGE_MAJ_CESOIR_MAINTENANT
        Pref.TabPageCesoirMaintenant.Text = lngTabPageCesoirMaintenant
        Pref.GroupBoxCesoir.Text = lngGroupBoxCesoir
        Pref.GroupBoxMaintenant.Text = lngGroupBoxMaintenant
        Pref.RadioButtonCesoirAll.Text = lngRadioButtonCesoirAll
        Pref.RadioButtonCesoir45.Text = lngRadioButtonCesoir45
        Pref.RadioButtonCesoir60.Text = lngRadioButtonCesoir60
        Pref.RadioButtonCesoir75.Text = lngRadioButtonCesoir75
        Pref.RadioButtonCesoir90.Text = lngRadioButtonCesoir90
        Pref.RadioButtonCesoir105.Text = lngRadioButtonCesoir105
        Pref.RadioButtonCesoir120.Text = lngRadioButtonCesoir120
        Pref.RadioButtonMaintenantAll.Text = lngRadioButtonMaintenantAll
        Pref.RadioButtonMaintenant45.Text = lngRadioButtonMaintenant45
        Pref.RadioButtonMaintenant60.Text = lngRadioButtonMaintenant60
        Pref.RadioButtonMaintenant75.Text = lngRadioButtonMaintenant75
        Pref.RadioButtonMaintenant90.Text = lngRadioButtonMaintenant90
        Pref.RadioButtonMaintenant105.Text = lngRadioButtonMaintenant105
        Pref.RadioButtonMaintenant120.Text = lngRadioButtonMaintenant120

        'PREF_TABPAGE_MODE_VEILLE
        Pref.TabPageResume.Text = lngTabPageResume
        Pref.GroupBoxResume.Text = lngGroupBoxResume
        Pref.CheckBoxResume.Text = lngCheckBoxResume
        Pref.GroupBoxResumeBefore.Text = lngGroupBoxResumeBefore
        Pref.RadioButtonResume5.Text = lngRadioButtonResume5
        Pref.RadioButtonResume10.Text = lngRadioButtonResume10
        Pref.RadioButtonResume15.Text = lngRadioButtonResume15
        Pref.RadioButtonResume20.Text = lngRadioButtonResume20
        Pref.RadioButtonResume30.Text = lngRadioButtonResume30

        'PREF_TABPAGE_GESTION_SON
        Pref.TabPageSound.Text = lngTabPageSound
        Pref.GroupBoxRSS.Text = lngGroupBoxRSS
        Pref.GroupBoxMessages.Text = lngGroupBoxMessages
        Pref.GroupBoxReminder.Text = lngGroupBoxReminder
        Pref.GroupBoxMasterVolume.Text = lngGroupBoxMasterVolume
        Pref.GroupBoxMute.Text = lngGroupBoxMute
        Pref.CheckBoxAudioOn.Text = lngCheckBoxAudioOn

        If iForm <> 7 Then

            'PREF_BUTTON
            Pref.ButtonOK.Text = lngButtonOk
            Pref.ButtonCancel.Text = lngButtonCancel

            'MAINFORM_TOOLSTRIP_MENU_FILE
            Mainform.ToolStripMenuFile.Text = lngToolStripMenuFile
            Mainform.ToolStripMenuFileSave.Text = lngToolStripMenuFileSave
            Mainform.ToolStripMenuFileRestart.Text = lngToolStripMenuFileRestart
            Mainform.ToolStripMenuFileExit.Text = lngToolStripMenuFileExit
            Mainform.ToolStripMenuItemSettingsReset.Text = lngToolStripMenuItemSettingsReset

            'MAINFORM_TOOLSTRIP_MENU_EDIT
            Mainform.ToolStripMenuEdit.Text = lngToolStripMenuEdit
            Mainform.ToolStripMenuEditOntop.Text = lngToolStripMenuEditOntop
            Mainform.ToolStripMenuSearch.Text = lngToolStripMenuSearch
            Mainform.ToolStripMenuEditPrint.Text = lngToolStripMenuEditPrint
            Mainform.ToolStripMenuPrintTonight.Text = lngToolStripMenuPrintTonight
            Mainform.ToolStripMenuCategories.Text = lngToolStripMenuCategories
            Mainform.ToolStripMenuDescription.Text = lngToolStripMenuDescription
            Mainform.ToolStripMenuCalendar.Text = lngToolStripMenuCalendar

            'MAINFORM_TOOLSTRIP_MENU_OPTIONS
            Mainform.ToolStripMenuOptions.Text = lngToolStripMenuOptions
            Mainform.ToolStripMenuOptionsUpdate.Text = lngToolStripMenuOptionsUpdate
            Mainform.ToolStripMenuOptionsAutoUpdate.Text = lngToolStripMenuOptionsAutoUpdate
            Mainform.ToolStripMenuOptionsPreferences.Text = lngToolStripMenuOptionsPreferences
            Mainform.ToolStripMenuOptionsLogos.Text = lngToolStripMenuOptionsLogos
            Mainform.ToolStripMenuOptionsDualMonitor.Text = lngToolStripMenuOptionsDualMonitor
            Mainform.ToolStripMenuOptionsEngineSelection.Text = lngToolStripMenuOptionsEngineSelection

            'MAINFORM_TOOLSTRIP_MENU_HELP
            Mainform.ToolStripMenuHelp.Text = lngToolStripMenuHelp
            Mainform.ToolStripMenuHelpHelptopics.Text = lngToolStripMenuHelpHelptopics
            Mainform.ToolStripMenuHelpHelpShortcuts.Text = lngToolStripMenuHelpHelpShortcuts
            Mainform.ToolStripMenuHelpWebsite.Text = lngToolStripMenuHelpWebsite
            Mainform.ToolStripMenuHelpForum.Text = lngToolStripMenuHelpForum
            Mainform.ToolStripMenuHelpCheckupdates.Text = lngToolStripMenuHelpCheckupdates
            Mainform.ToolStripMenuHelpLanguage.Text = lngToolStripMenuHelpLanguage
            Mainform.ToolStripMenuHelpAbout.Text = lngToolStripMenuHelpAbout
            Mainform.ToolStripMenuHelpManualFeedBack.Text = lngToolStripMenuHelpManualFeedBack
            Mainform.ToolStripMenuHelpDonate.Text = lngToolStripMenuHelpDonate
            Mainform.ToolStripMenuHelpCompensation.Text = lngToolStripMenuHelpCompensation
            Mainform.ToolStripMenuHelpContent.Text = lngToolStripMenuHelpContent
            Mainform.ToolStripMenuHelpPlugins.Text = lngToolStripMenuHelpPlugins
            Mainform.ToolStripMenuHelpWeather.Text = lngToolStripMenuHelpWeather
            Mainform.ToolStripMenuHelpLocation.Text = lngToolStripMenuHelpLocation

            'MAINFORM_TOOLSTRIP
            Mainform.ToolStripSave.ToolTipText = lngToolStripSave
            Mainform.ToolStripPrint.ToolTipText = lngToolStripPrint
            Mainform.ToolStripSearch.ToolTipText = lngToolStripSearch
            Mainform.ToolStripOntop.ToolTipText = lngToolStripOntop
            Mainform.ToolStripPreferences.ToolTipText = lngToolStripPreferences
            Mainform.ToolStripLogos.ToolTipText = lngToolStripLogos
            Mainform.ToolStripUpdate.ToolTipText = lngToolStripUpdate
            Mainform.ToolStripAutoUpdate.ToolTipText = lngToolStripAutoUpdate
            Mainform.ToolStripCheckupdates.ToolTipText = lngToolStripCheckupdates
            Mainform.ToolStripDualMonitor.ToolTipText = lngToolStripDualMonitor
            Mainform.ToolStripWebsite.ToolTipText = lngToolStripWebsite
            Mainform.ToolStripForum.ToolTipText = lngToolStripForum
            Mainform.ToolStripLangue.ToolTipText = lngToolStripLangue
            Mainform.ToolStripAbout.ToolTipText = lngToolStripAbout
            Mainform.ToolStripHelptopics.ToolTipText = lngToolStripHelptopics
            Mainform.ToolStripHelpShortcuts.ToolTipText = lngToolStripHelpShortcuts
            Mainform.ToolStripCategories.ToolTipText = lngToolStripCategories
            Mainform.ToolStripDescription.ToolTipText = lngToolStripDescription
            Mainform.ToolStripCalendar.ToolTipText = lngToolStripCalendar
            Mainform.ToolStripManualFeedBack.ToolTipText = lngToolStripManualFeedBack
            Mainform.ToolStripTextBoxRecherche.Text = lngToolStripTextBoxRecherche
            Mainform.ToolStripButtonRecherche.ToolTipText = lngToolStripButtonRecherche

            'MAINFORM_PAVE
            Mainform.navigtemporelle.Text_JourMoins = lngPaveJourMoins
            Mainform.navigtemporelle.Text_HeureMoins = lngPaveHeureMoins
            Mainform.navigtemporelle.Text_06h = lngPave6H
            Mainform.navigtemporelle.Text_09h = lngPave9H
            Mainform.navigtemporelle.Text_12h = lngPave12H
            Mainform.navigtemporelle.Text_15h = lngPave15H
            Mainform.navigtemporelle.Text_18h = lngPave18H
            Mainform.navigtemporelle.Text_20h = lngPave20H
            Mainform.navigtemporelle.Text_23h = lngPave23H
            Mainform.navigtemporelle.Text_Maintenant = lngPaveMaintenant
            Mainform.navigtemporelle.Text_HeurePlus = lngPaveHeurePlus
            Mainform.navigtemporelle.Text_JourPlus = lngPaveJourPlus

            'MESSAGEBOXNOCONNECTION
            Mainform.MessageBoxNoConnection = lngMessageBoxNoConnection
            Mainform.MessageBoxNoConnection1 = lngMessageBoxNoConnection1
            Mainform.MessageBoxNoConnectionTitre = lngMessageBoxNoConnectionTitre

            'NOTIFYICON
            BalloonText1 = lngBalloonText1
            BalloonText3 = lngBalloonText3

            'JUMPLIST
            Mainform.SiteOfficiel = lngSiteOfficiel
            Mainform.ForumOfficiel = lngForumOfficiel

            If iForm = 15 Then
                Return
            End If

            'MESSAGEBOXBASEPERIMEE
            Mainform.MessageBoxBasePerimee = lngMessageBoxBasePerimee
            Mainform.MessageBoxBasePerimee1 = lngMessageBoxBasePerimee1
            Mainform.MessageBoxBasePerimeeTitre = lngMessageBoxBasePerimeeTitre

            If iForm = 16 Then
                Return
            End If

            'GESTIONBDD
            Gestionbdd.ListViewGestionBdd.Columns(0).Text = lngListViewGestionBddColumns0
            Gestionbdd.ListViewGestionBdd.Columns(1).Text = lngListViewGestionBddColumns1
            Gestionbdd.ListViewGestionBdd.Columns(2).Text = lngListViewGestionBddColumns2
            Gestionbdd.Text = lngGestionBddTitre
            Gestionbdd.ButtonDelete.Text = lngGestionBddButtonDelete
            Gestionbdd.ButtonSave.Text = lngGestionBddButtonSave
            Gestionbdd.ButtonRestore.Text = lngGestionBddButtonRestore
            Gestionbdd.ButtonCancel.Text = lngGestionBddButtonCancel
            Gestionbdd.GroupBoxRestauration.Text = lngGroupBoxRestauration
            Gestionbdd.CheckBoxRestaurationDataBase.Text = lngCheckBoxRestaurationDataBase
            Gestionbdd.CheckBoxRestaurationChaines.Text = lngCheckBoxRestaurationChaines
            Gestionbdd.CheckBoxRestaurationUrl.Text = lngCheckBoxRestaurationUrl
            Gestionbdd.CheckBoxRestaurationUserConfig.Text = lngCheckBoxRestaurationUserConfig

            'MESSAGEBOXFILESAVE
            Gestionbdd.MessageBoxFileRestoreTitre = lngMessageBoxFileRestoreTitre
            Gestionbdd.MessageBoxFileRestore = lngMessageBoxFileRestore
            Gestionbdd.MessageBoxFileRestore1 = lngMessageBoxFileRestore1
            Gestionbdd.MessageBoxFileRestore2 = lngMessageBoxFileRestore2

            'MESSAGEBOXNORESTORESELECTED
            Gestionbdd.MessageBoxNoRestoreSelectedTitre = lngMessageBoxNoRestoreSelectedTitre
            Gestionbdd.MessageBoxNoRestoreSelected = lngMessageBoxNoRestoreSelected

            'MESSAGEBOXNORESTOREELEMENT
            Gestionbdd.MessageBoxNoRestoreElementTitre = lngMessageBoxNoRestoreElementTitre
            Gestionbdd.MessageBoxNoRestoreElement = lngMessageBoxNoRestoreElement

            If iForm = 17 Then
                Return
            End If

            'FRM_ABOUT
            About.Text = lngAboutTitle
            About.TabPageAbout.Text = lngTabPageAbout
            About.TabPageAuteurs.Text = lngTabPageAuteurs
            About.TextBoxAdmin.Text = lngTextBoxAdmin
            About.TextBoxDev.Text = lngTextBoxDev
            About.TextBoxTesters.Text = lngTextBoxTesters
            About.TextBoxContributors.Text = lngTextBoxContributors
            About.TextBoxThanks.Text = lngTextBoxThanks
            About.TabPagelicence.Text = lngTabPagelicence
            About.TabPage7zip.Text = lngTabPage7zip
            About.TabPageDonate.Text = lngTabPageDonate

            If iForm = 18 Then
                Return
            End If

            'MAINFORM_CESOIR_MAINTENANT

            '-----------------------------------------------------------------------------------
            ' lorsque les donnees sont perimees on a eu une erreur car index 0 est hors limite
            'BB 121009
            '--------------------------------------------------------------------------------
            Mainform.Panel_titre_ce_soir.Controls.Item(0).Text = lngPanelTitreCesoir
            Mainform.Panel_titre_maintenant.Controls.Item(0).Text = lngPanelTitreMaintenant
        End If

        'REORGCHANNEL_TITLE
        ReorgChannel.Text = lngReorgChannelTitle

        'REORGCHANNEL_BUTTON
        ReorgChannel.btMonter.Text = lngButtonMonterReorgChannel
        ReorgChannel.btDescendre.Text = lngButtonDescendreReorgChannel
        ReorgChannel.btSupprimer.Text = lngButtonSupprimerReorgChannel
        ReorgChannel.btLogo.Text = lngButtonLogoReorgChannel
        ReorgChannel.btEnregistrer.Text = lngButtonEnregistrerReorgChannel
        ReorgChannel.btAnnuler.Text = lngButtonAnnulerReorgChannel
        ReorgChannel.lstChaine.Columns(0).Text = lngReorgChannelListViewColumns0
        ReorgChannel.lstChaine.Columns(1).Text = lngReorgChannelListViewColumns1

        If iForm = 5 Then

            'FRM_LISTRECKTV_TITLE
            ListRecKTV.Text = lngfrmListRecKTV

            'FRM_LISTRECKTV_LISTVIEW1_COLUMN
            ListRecKTV.ListView1.Columns(0).Text = lngfrmListRecKTVListView1Columns0
            ListRecKTV.ListView1.Columns(1).Text = lngfrmListRecKTVListView1Columns1
            ListRecKTV.ListView1.Columns(2).Text = lngfrmListRecKTVListView1Columns2
            ListRecKTV.ListView1.Columns(3).Text = lngfrmListRecKTVListView1Columns3

            'FRM_LISTRECKTV
            ListRecKTV.GroupBoxDetails.Text = lngGroupBoxDetails
            ListRecKTV.GroupBoxRepete.Text = lngGroupBoxRepete
            ListRecKTV.LabelChaine.Text = lngLabelChaine
            ListRecKTV.LabelDebut.Text = lngLabelDebut
            ListRecKTV.LabelFin.Text = lngLabelFin
            ListRecKTV.LabelProfile.Text = lngLabelProfile
            ListRecKTV.LabelNom.Text = lngLabelNom
            ListRecKTV.CmdModify.Text = lngCmdModify
            ListRecKTV.CmdDelete.Text = lngCmdDelete
            ListRecKTV.CmdAdd.Text = lngCmdAdd
            ListRecKTV.CmdCancel.Text = lngCmdCancel
            ListRecKTV.RadioButtonUnique.Text = lngRadioButtonUnique
            ListRecKTV.RadioButtonJournalier.Text = lngRadioButtonJournalier
            ListRecKTV.RadioButtonHebdo.Text = lngRadioButtonHebdo
            ListRecKTV.RadioButtonMensuel.Text = lngRadioButtonMensuel
            ListRecKTV.CheckBoxLundi.Text = lngCheckBoxLundi
            ListRecKTV.CheckBoxMardi.Text = lngCheckBoxMardi
            ListRecKTV.CheckBoxMercredi.Text = lngCheckBoxMercredi
            ListRecKTV.CheckBoxJeudi.Text = lngCheckBoxJeudi
            ListRecKTV.CheckBoxVendredi.Text = lngCheckBoxVendredi
            ListRecKTV.CheckBoxSamedi.Text = lngCheckBoxSamedi
            ListRecKTV.CheckBoxDimanche.Text = lngCheckBoxDimanche

            'FRM_LISTRECKTV_MESSAGES
            ListRecKTV.OverlappingRec = lngfrmListRecKTVOverlappingRec
            ListRecKTV.CantWhrite = lngfrmListRecKTVCantWhrite
            ListRecKTV.ParameterKtvChannel = lngfrmListRecKTVParameterKtvChannel
        End If

        If iForm = 6 Then

            'KTVFORM
            KTvForm.Text = lngKTvForm
            KTvForm.ListView1.Columns(0).Text = lngKTvFormListView1Columns0
            KTvForm.ListView1.Columns(1).Text = lngKTvFormListView1Columns1
            KTvForm.ListView1.Columns(2).Text = lngKTvFormListView1Columns2
            KTvForm.LabelSource.Text = lngKTvFormLabelSource
            KTvForm.ButtonSave.Text = lngKTvFormButtonSave
            KTvForm.ButtonClose.Text = lngKTvFormButtonClose
            KTvForm.TheFile = lngKTvFormTheFile
            KTvForm.NoKtvFolder = lngKTvFormNoKtvFolder
            KTvForm.NoKtvIni = lngKTvFormNoKtvIni
            KTvForm.TheFolder = lngKTvFormTheFolder
            KTvForm.DontExist = lngKTvFormDontExist
            KTvForm.ChannelLoadErr = lngKTvFormChannelLoadErr
            KTvForm.SaveKtvErr = lngKTvFormSaveKtvErr
            KTvForm.NoSource = lngKTvFormNoSource
            KTvForm.NoChannel = lngKTvFormNoChannel
            KTvForm.SelectZgChannel = lngKTvFormSelectZgChannel

        End If

        If iForm = 7 Then

            'FRMMISEAJOUR
            Miseajour.Text = lngFrmMiseajour
            Miseajour.RadioButtonDownload.Text = lngRadioButtonDownload
            Miseajour.RadioButtonXmlPath.Text = lngRadioButtonXmlPath
            Miseajour.ButtonTout.Text = lngButtonTout
            Miseajour.ButtonSuppr.Text = lngButtonSuppr
            Miseajour.ButtonAppliquer.Text = lngButtonMiseaJour
            Miseajour.ButtonDemarrer.Text = lngButtonDemarrer
            Miseajour.ButtonAnnuler.Text = lngButtonAnnuler
            Miseajour.ButtonEdit.Text = lngButtonEdit

            MiseajourEPGData.Text = lngFrmMiseajour
            MiseajourEPGData.ButtonForceDownload.Text = lngButtonForceDownload
            MiseajourEPGData.ButtonMiseaJour.Text = lngButtonMiseaJour
            MiseajourEPGData.ButtonSuppr.Text = lngButtonSuppr
            MiseajourEPGData.ButtonTout.Text = lngButtonTout
            MiseajourEPGData.ButtonAnnuler.Text = lngButtonAnnuler
            UtilitaireMiseaJourEPGData.Parsing = lngParsingoperation
            UtilitaireMiseaJourEPGData.Telechargement = lngtelechargement

            'FRMMISEAJOUR_MESSAGE
            Miseajour.ErrorInChannelListRecovery = lngErrorInChannelListRecovery
            Miseajour.NoURLUpdate = lngNoURLUpdate
            Miseajour.InvalidURL = lngInvalidURL
            Miseajour.UntraceableFile = lngUntraceableFile
            Miseajour.InvalidFile = lngInvalidFile
            Miseajour.ErrorInUpdate = lngErrorInUpdate
            Miseajour.ErrorInXMLCopy = lngErrorInXMLCopy
            Miseajour.ErrorInFileCopy = lngErrorInFileCopy
            Miseajour.ErrorInUnzip = lngErrorInUnzip
            Miseajour.WrongFileName = lngWrongFileName
            Miseajour.FailURLFileDownload = lngFailURLFileDownload
            Miseajour.UntraceableURLListFile = lngUntraceableURLListFile
            Miseajour.TheFile = lngTheFile
            Miseajour.DontExist = lngDontExist
            Miseajour.ProtectedFile = lngProtectedFile
            Miseajour.ChosenChannels = lngChosenChannels
            Miseajour.AvailableChannels = lngAvailableChannels
            Miseajour.ChoseFile = lngChoseFile
            Miseajour.InvalidChoice = lngInvalidChoice
            Miseajour.MessageBoxDirChecked = lngMessageBoxDirChecked
            Miseajour.MessageBoxDirChecked1 = lngMessageBoxDirChecked1
            Miseajour.MessageBoxDirCheckedTitre = lngMessageBoxDirCheckedTitre
            Miseajour.MessageBoxFileNotExist = lngMessageBoxFileNotExist
            Miseajour.MessageBoxFileNotExist1 = lngMessageBoxFileNotExist1
            Miseajour.MessageBoxFileNotExistTitre = lngMessageBoxFileNotExistTitre
            Miseajour.MessageBoxURLChecked = lngMessageBoxURLChecked
            Miseajour.MessageBoxURLChecked1 = lngMessageBoxURLChecked1
            Miseajour.MessageBoxURLCheckedTitre = lngMessageBoxURLCheckedTitre

            MiseajourEPGData.ChosenChannels = lngChosenChannels
            MiseajourEPGData.AvailableChannels = lngAvailableChannels
        End If


        'MAINFORM_MENU_CONTEXTUEL_K!TV
        Mainform.ToolStripMenuProgramKTV.Text = lngToolStripMenuProgramKTV
        Mainform.ToolStripMenuZapperKTV.Text = lngToolStripMenuZapperKTV
        Mainform.ToolStripMenuGestionRecordKTV.Text = lngToolStripMenuGestionRecordKTV
        Mainform.ToolStripMenuGestionChainesKTV.Text = lngToolStripMenuGestionChainesKTV

        'MAINFORM_MENU_CONTEXTUEL_MMTV
        Mainform.ToolStripMenuProgramMMTV.Text = lngToolStripMenuProgramMMTV
        Mainform.ToolStripMenuZapperMMTV.Text = lngToolStripMenuZapperMMTV
        Mainform.ToolStripMenuGestionRecordMMTV.Text = lngToolStripMenuGestionRecordMMTV
        Mainform.ToolStripMenuGestionChainesMMTV.Text = lngToolStripMenuGestionChainesMMTV

        'MAINFORM_MENU_CONTEXTUEL_DESCRIPTION
        Mainform.ToolStripMenuPrintDescript.Text = lngToolStripMenuPrintDescript

        'MAINFORM_MESSAGE_PROXY
        Mainform.MsgProxyTitle = lngMsgProxyTitle
        Mainform.MsgProxy = lngMsgProxy

        'MAINFORM_NOTIFYICON1_BALLOONTIP
        Mainform.NotifyIcon1.BalloonTipTitle = lngNotifyIcon1BalloonTipTitle
        Mainform.NotifyIcon1.Text = lngNotifyIcon1

        'MESSAGEBOXNOUPDATE
        MessageBoxnoupdate = lngMessageBoxnoupdate
        MessageBoxnoupdateTitre = lngMessageBoxnoupdateTitre

        'MESSAGEBOXMISEAJOUR
        Mainform.MessageBoxMiseaJour = lngMessageBoxMiseaJour
        Mainform.MessageBoxMiseaJour1 = lngMessageBoxMiseaJour1
        Mainform.MessageBoxMiseaJourTitre = lngMessageBoxMiseaJourTitre

        'MESSAGEBOXMISEAJOURDONE
        Mainform.MessageBoxMiseaJourDone = lngMessageBoxMiseaJourDone
        Mainform.MessageBoxMiseaJour1Done = lngMessageBoxMiseaJour1Done
        Mainform.MessageBoxMiseaJourTitreDone = lngMessageBoxMiseaJourTitreDone

        Miseajour.MessageBoxMiseaJourDone = lngMessageBoxMiseaJourDone
        Miseajour.MessageBoxMiseaJour1Done = lngMessageBoxMiseaJour1Done
        Miseajour.MessageBoxMiseaJourTitreDone = lngMessageBoxMiseaJourTitreDone

        MiseajourEPGData.MessageBoxMiseaJourDone = lngMessageBoxMiseaJourDone
        MiseajourEPGData.MessageBoxMiseaJour1Done = lngMessageBoxMiseaJour1Done
        MiseajourEPGData.MessageBoxMiseaJourTitreDone = lngMessageBoxMiseaJourTitreDone

        'MESSAGEBOXMODIFPREF
        Mainform.MessageBoxModifPref = lngMessageBoxModifPref
        Mainform.MessageBoxModifPref1 = lngMessageBoxModifPref1
        Mainform.MessageBoxModifPrefTitre = lngMessageBoxModifPrefTitre

        'MESSAGEBOXNOCONNECTION
        Central_Screen.MessageBoxNoConnection = lngMessageBoxNoConnection
        Central_Screen.MessageBoxNoConnection1 = lngMessageBoxNoConnection1
        Central_Screen.MessageBoxNoConnectionTitre = lngMessageBoxNoConnectionTitre

        'MESSAGEBOXFEEDBACK
        Feedback.MessageBoxFeedback = lngMessageBoxFeedback
        Feedback.MessageBoxFeedbackTitre = lngMessageBoxFeedbackTitre

        'MESSAGEBOXFICHIERCORROMPU
        MessageFichierCorrompu = lngMessageFichierCorrompu
        MessageFichierCorrompu1 = lngMessageFichierCorrompu1
        MessageFichierCorrompu2 = lngMessageFichierCorrompu2
        MessageFichierCorrompuTitre = lngMessageFichierCorrompuTitre

        'MESSAGEBOXLISTXMLTVFRCHOISIE
        Miseajour.MessageBoxListXMLTVFRChoisie = lngMessageBoxListXMLTVFRChoisie
        Miseajour.MessageBoxListXMLTVFRChoisie1 = lngMessageBoxListXMLTVFRChoisie1
        Miseajour.MessageBoxListXMLTVFRChoisieTitre = lngMessageBoxListXMLTVFRChoisieTitre

        MiseajourEPGData.MessageBoxListXMLTVFRChoisie = lngMessageBoxListXMLTVFRChoisie
        MiseajourEPGData.MessageBoxListXMLTVFRChoisie1 = lngMessageBoxListXMLTVFRChoisie1
        MiseajourEPGData.MessageBoxListXMLTVFRChoisieTitre = lngMessageBoxListXMLTVFRChoisieTitre

        'MESSAGEBOXTHETVDBNORESULT
        SeriesBrowser.ThetvdbNoResult = lngMessageBoxThetvdbNoResult
        SeriesBrowser.ThetvdbNoResultTitre = lngMessageBoxThetvdbNoResultTitre

        'MESSAGEBOXTHETVDBVALIDESERIEID
        SeriesBrowser.ThetvdbNoSerieDetails = lngMessageBoxThetvdbNoSerieDetail
        SeriesBrowser.ThetvdbNoSerieDetailsTitre = lngMessageBoxThetvdbNoSerieDetailTitre

        'MESSAGEBOXTHETVDBNOSERIEDETAIL
        SeriesBrowser.ThetvdbNoValidSeriesId = lngMessageBoxThetvdbNoValidSeriesId
        SeriesBrowser.ThetvdbNoValidSeriesIdTitre = lngMessageBoxThetvdbNoValidSeriesIdTitre

        'THETVDBBOXNOSHEET
        SeriesBrowser.ThetvdbBoxNoSheet = lngThetvdbBoxNoSheet
        SeriesBrowser.ThetvdbBoxNoSheetTitre = lngThetvdbBoxNoSheetTitre

        'MESSAGEBOXTHETVDBNOACTORINFO
        SeriesBrowser.ThetvdbNoActorInfo = lngMessageBoxThetvdbNoActorInfo
        SeriesBrowser.ThetvdbNoActorInfoTitre = lngMessageBoxThetvdbNoActorInfoTitre

        'MESSAGEBOXTHETVDBNOBANNER
        SeriesBrowser.ThetvdbNoBanner = lngMessageBoxThetvdbNoBanner
        SeriesBrowser.ThetvdbNoBannerTitre = lngMessageBoxThetvdbNoBannerTitre

        'MESSAGEBOXMESSAGEENVOYE
        Feedback.MessageBoxMessageEnvoye = lngMessageBoxMessageEnvoye
        Feedback.MessageBoxMessageEnvoyeTitre = lngMessageBoxMessageEnvoyeTitre

        'MESSAGEBOXNOPLUGIN
        'Feedback.MessageBoxNoPlugin = lngMessageBoxNoPlugin
        'Feedback.MessageBoxNoPlugin1 = lngMessageBoxNoPlugin
        'Feedback.MessageBoxNoPluginTitre = lngMessageBoxNoPluginTitre

        'MESSAGEBOXEPGDATA
        Pref.messageBoxEPGData = lngMessageBoxEPGData
        Pref.messageBoxEPGData1 = lngMessageBoxEPGData1
        Pref.messageBoxEPGDataTitre = lngMessageBoxEPGDataTitre

        'MESSAGEBOXREORGCHANNEL
        ReorgChannel.MessageBoxReorgChannel = lngMessageBoxReorgChannel
        ReorgChannel.MessageBoxReorgChannel1 = lngMessageBoxReorgChannel1
        ReorgChannel.MessageBoxReorgChannelTitre = lngMessageBoxReorgChannelTitre

        'MESSAGEBOXRESUME
        Mainform.MessageBoxResume = lngMessageBoxResume
        Mainform.MessageBoxResume1 = lngMessageBoxResume1
        Mainform.MessageBoxResumeTitre = lngMessageBoxResumeTitre

        'MESSAGEBOXRAZ
        Mainform.MessageBoxRaz = lngMessageBoxRaz
        Mainform.MessageBoxRaz1 = lngMessageBoxRaz1
        Mainform.MessageBoxTitleRaz = lngMessageBoxTitleRaz

        'MESSAGEBOXMISEAJOUREXE
        UpdateXMLParser.MessageBoxMiseaJourExe = lngMessageBoxMiseaJourExe
        UpdateXMLParser.MessageBoxMiseaJourExe1 = lngMessageBoxMiseaJourExe1
        UpdateXMLParser.MessageBoxMiseaJourExeTitre = lngMessageBoxMiseaJourExeTitre

        'MISEAJOURAUTO
        MiseAJourAuto.Text = lngMiseAJourAutoTitle
        MiseAJourAuto.Node_number = lngNode_number
        MiseAJourAuto.Auto_update_operation = lngAuto_update_operation
        MiseAJourAuto.dwnl_operation = lngdwnl_operation
        MiseAJourAuto.Parsing_operation = lngParsing_operation
        MiseAJourAuto.remaining_time = lngremaining_time
        MiseAJourAuto.file_size = lngfile_size
        'MiseAJourAuto.MiseAJourProgress.Text = lngMiseAJourProgress

        'MISEAJOURAUTO_MESSAGE
        MiseAJourAuto.Error1_majauto = lngError1_majauto
        MiseAJourAuto.Error2_majauto = lngError2_majauto
        MiseAJourAuto.Error3_majauto = lngError3_majauto
        MiseAJourAuto.Error4_majauto = lngError4_majauto
        MiseAJourAuto.Error5_majauto = lngError5_majauto
        MiseAJourAuto.Error6_majauto = lngError6_majauto

        'SYSTRAY
        Mainform.SystrayMenuRestore.Text = lngSystrayMenuRestore
        Mainform.SystrayMenuExit.Text = lngSystrayMenuExit

        'TRI_AVANCE
        TriAvance.Text = lngTriAvanceTitle
        TriAvance.TriAvanceLabeltitre.Text = lngTriAvanceLabeltitre
        TriAvance.TriAvanceLabelauteur.Text = lngTriAvanceLabelauteur
        TriAvance.TriAvanceLabelndefini.Text = lngTriAvanceLabelndefini
        TriAvance.TriAvanceButtonSearch.Text = lngTriAvanceButtonSearch
        TriAvance.TriAvanceButtonCancel.Text = lngtTriAvanceButtonCancel
        TriAvance.TriAvanceGroupBoxCriteres.Text = lngTriAvanceGroupBoxCriteres
        TriAvance.TriAvanceCheckBoxNow.Text = lngTriAvanceCheckBoxNow
        TriAvance.TriAvanceCheckBoxBegin.Text = lngTriAvanceCheckBoxBegin
        TriAvance.TriAvanceListView.Columns(0).Text = lngTriAvanceListViewColumns0
        TriAvance.TriAvanceListView.Columns(1).Text = lngTriAvanceListViewColumns1
        TriAvance.TriAvanceListView.Columns(2).Text = lngTriAvanceListViewColumns2
        TriAvance.TriAvanceListView.Columns(3).Text = lngTriAvanceListViewColumns3
        TriAvance.TriAvanceListView.Columns(4).Text = lngTriAvanceListViewColumns4

        'CALENDRIER
        Mainform.CalendarLundiLabel.Text = lngCalendarLundiLabel
        Mainform.CalendarMardiLabel.Text = lngCalendarMardiLabel
        Mainform.CalendarMercrediLabel.Text = lngCalendarMercrediLabel
        Mainform.CalendarJeudiLabel.Text = lngCalendarJeudiLabel
        Mainform.CalendarVendrediLabel.Text = lngCalendarVendrediLabel
        Mainform.CalendarSamediLabel.Text = lngCalendarSamediLabel
        Mainform.CalendarDimancheLabel.Text = lngCalendarDimancheLabel
        Mainform.NameofMonth1 = lngNameofMonth1
        Mainform.NameofMonth2 = lngNameofMonth2
        Mainform.NameofMonth3 = lngNameofMonth3
        Mainform.NameofMonth4 = lngNameofMonth4
        Mainform.NameofMonth5 = lngNameofMonth5
        Mainform.NameofMonth6 = lngNameofMonth6
        Mainform.NameofMonth7 = lngNameofMonth7
        Mainform.NameofMonth8 = lngNameofMonth8
        Mainform.NameofMonth9 = lngNameofMonth9
        Mainform.NameofMonth10 = lngNameofMonth10
        Mainform.NameofMonth11 = lngNameofMonth11
        Mainform.NameofMonth12 = lngNameofMonth12

        'FEEDBACK
        Feedback.Text = lngFeedback_Title
        Feedback.LabelExceptMessage1.Text = lngLabelExceptMessage1
        Feedback.LabelExceptMessage2.Text = lngLabelExceptMessage2
        Feedback.LabelExceptMessage3.Text = lngLabelExceptMessage3
        Feedback.CheckBoxExceptErrorMessage.Text = lngCheckBoxExceptErrorMessage
        Feedback.LabelEmail.Text = lngLabelEmail
        Feedback.Send_Button.Text = lngSend_Button
        Feedback.Copier_Button.Text = lngCopier_Button
        Feedback.Exit_Button.Text = lngExit_Button
        Feedback.ExceptErrorMessage.Text = lngExceptErrorMessage
        Feedback.LabelFeedbackSend.Text = lngLabelFeedbackSend
        Feedback.ZGuideTVRelease = lngZGuideTVRelease
        Feedback.CompilationDate = lngCompilationDate
        Feedback.OSRelease = lngOSRelease
        Feedback.Architecture = lngArchitecture
        Feedback.OSBootMode = lngOSBootMode
        Feedback.Framework = lngFramework
        Feedback.OSLanguage = lngOSLanguage
        Feedback.TotalMemory = lngTotalMemory
        Feedback.RemainingMemory = lngRemainingMemory
        Feedback.UsedMemory = lngUsedMemory
        Feedback.ProcessorName = lngProcessorName
        Feedback.ProcessorNumber = lngProcessorNumber
        Feedback.MonitorNumber = lngMonitorNumber
        Feedback.Email = lngEmail
        Feedback.Comments = lngComments
        Feedback.DescriptionError = lngDescriptionError
        Feedback.ProcessorSpeed = lngProcessorSpeed
        Feedback.CheckBoxAcknowledgment.Text = lngCheckBoxAcknowledgment
        Feedback.ProcessorDescription = lngProcessorDescription

        'THETVDBSEARCH
        search.ThetvdbLabelSearchName.Text = lngThetvdbLabelSearchName
        search.ThetvdbLabelID1.Text = lngThetvdbLabelID
        search.ThetvdbLabelLanguage.Text = lngThetvdbLabelLanguage
        search.ThetvdbButtonSearch.Text = lngThetvdbButtonSearch
        search.ThetvdbLabelLoadFull.Text = lngThetvdbLabelLoadFull
        search.ThetvdbLabelLoadActors.Text = lngThetvdbLabelLoadActors
        search.ThetvdbLabelBanner.Text = lngThetvdbLabelBanner
        search.ThetvdbLabelUseZipped.Text = lngThetvdbLabelUseZipped
        search.ThetvdbButtonLoad.Text = lngThetvdbButtonLoad
        search.ThetvdbButtonCancel.Text = lngThetvdbButtonCancel

        'THETVDBTAB
        SeriesBrowser.ThetvdbLabelSeriesTabSeries.Text = lngThetvdbLabelSeriesTabSeries
        SeriesBrowser.ThetvdbLabelEpisodesTabEpisodes.Text = lngThetvdbLabelEpisodesTabEpisodes
        SeriesBrowser.ThetvdbLabelActorsTabActors.Text = lngThetvdbLabelActorsTabActors

        'THETVDB
        SeriesBrowser.ThetvdbLabelSearchName1.Text = lngThetvdbLabelSearchName
        SeriesBrowser.ThetvdbButtonSearchShow.Text = lngThetvdbButtonSearch
        SeriesBrowser.ThetvdbLabelSiteRating.Text = lngThetvdbLabelSiteRating
        SeriesBrowser.ThetvdbLabelID.Text = lngThetvdbLabelID
        SeriesBrowser.ThetvdbLabelRuntime.Text = lngThetvdbLabelRuntime
        SeriesBrowser.ThetvdbLabelRating.Text = lngThetvdbLabelRating
        SeriesBrowser.ThetvdbLabelDescription.Text = lngThetvdbLabelDescription
        SeriesBrowser.ThetvdbLabelFirstAired.Text = lngThetvdbLabelFirstAired
        SeriesBrowser.ThetvdbLabelIDTVCom.Text = lngThetvdbLabelIDTVCom
        SeriesBrowser.ThetvdbButtonForceUpdate.Text = lngThetvdbLabelForceUpdate
        SeriesBrowser.ThetvdbLabelIDIMDB.Text = lngThetvdbLabelIDIMDBCom
        SeriesBrowser.ThetvdbButtonExit.Text = lngThetvdbButtonExit
        SeriesBrowser.ThetvdbLabelGenre.Text = lngThetvdbLabelGenre
        SeriesBrowser.ThetvdbLabelActors.Text = lngThetvdbLabelActors
        SeriesBrowser.ThetvdbLabelActors1.Text = lngThetvdbLabelActors1
        SeriesBrowser.ThetvdbLabelGueststarTabEpisodes.Text = lngThetvdbLabelGueststar
        SeriesBrowser.ThetvdbLabelDirectorTabTabEpisodes.Text = lngThetvdbLabelDirector
        SeriesBrowser.ThetvdbLabelWriterTabEpisodes.Text = lngThetvdbLabelWriter
        SeriesBrowser.ThetvdbLabelOpen = lngThetvdbLabelOpen
        SeriesBrowser.ThetvdbLabelEpisodes.Text = lngThetvdbLabelEpisodes

        'THETVDBTABEPISODE
        SeriesBrowser.ThetvdbLabelLanguageTabEpisodes.Text = lngThetvdbLabelLanguage
        SeriesBrowser.ThetvdbLabelFirstAiredTabEpisodes.Text = lngThetvdbLabelFirstAired
        SeriesBrowser.ThetvdbLabelAbsoluteNumberTabEpisodes.Text = lngThetvdbLabelAbsoluteNumberTabEpisodes
        SeriesBrowser.ThetvdbLabelIDIMDBComTabEpisodes.Text = lngThetvdbLabelIDIMDBCom
        SeriesBrowser.ThetvdbLabelProductCodeTabEpisodes.Text = lngThetvdbLabelProductCodeTabEpisodes
        SeriesBrowser.ThetvdbLabelDirectorTabTabEpisodes.Text = lngThetvdbLabelDirector
        SeriesBrowser.ThetvdbLabelGueststarTabEpisodes.Text = lngThetvdbLabelGueststar
        SeriesBrowser.ThetvdbLabelWriterTabEpisodes.Text = lngThetvdbLabelWriter
        SeriesBrowser.ThetvdbLabelOverviewTabEpisodes.Text = lngThetvdbLabelDescription
        SeriesBrowser.ThetvdbLabelDVDIDTabEpisodes.Text = lngThetvdbLabelDVDIDTabEpisodes
        SeriesBrowser.ThetvdbLabelDVDSeasonTabEpisodes.Text = lngThetvdbLabelDVDSeasonTabEpisodes
        SeriesBrowser.ThetvdbLabelDVDNumberTabEpisodes.Text = lngThetvdbLabelDVDNumberTabEpisodes
        SeriesBrowser.ThetvdbLabelDVDChapterTabEpisodes.Text = lngThetvdbLabelDVDChapterTabEpisodes
        SeriesBrowser.ThetvdbNodeSeasonTabEpisodes = lngThetvdbNodeSeasonTabEpisodes

        'THETVDBTABACTORS
        SeriesBrowser.ThetvdbGroupBoxInformationTabActors.Text = lngThetvdbGroupBoxInformationTabActors
        SeriesBrowser.ThetvdbLabelIDTabActors.Text = lngThetvdbLabelIDTabActors
        SeriesBrowser.ThetvdbLabelNameTabActors.Text = lngThetvdbLabelNameTabActors
        SeriesBrowser.ThetvdbLabelRoleTabActors.Text = lngThetvdbLabelRoleTabActors
        SeriesBrowser.ThetvdbLabelSortOrderTabActors.Text = lngThetvdbLabelSortOrderTabActors

        'THETVDBRESULT
        SearchResultForm.ThetvdbGroupBoxResult.Text = lngThetvdbGroupBoxResult
        SearchResultForm.ThetvdblabelFirstAiredResult.Text = lngThetvdbLabelFirstAiredResult
        SearchResultForm.ThetvdbLabelIMDBIdResult.Text = lngThetvdbLabelIMDBIdResult
        SearchResultForm.ThetvdbLabelOverviewResult.Text = lngThetvdbLabelOverviewResult
        SearchResultForm.ThetvdbLabelStatusResult.Text = lngThetvdbLabelStatusResult
        SearchResultForm.ThetvdbButtonChooseResult.Text = lngThetvdbButtonChooseResult
        SearchResultForm.ThetvdbButtonCancelResult.Text = lngThetvdbButtonCancelResult
        SearchResultForm.lvSearchResult.Columns(0).Text = lngThetvdbListviewResultColumns0
        SearchResultForm.lvSearchResult.Columns(1).Text = lngThetvdbListviewResultColumns1
        SearchResultForm.lvSearchResult.Columns(2).Text = lngThetvdbListviewResultColumns2

        'RICHTEXTBOXDESCRIP
        Central_Screen.RichTextBoxDescripFrom = lngRichTextBoxDescripFrom
        Central_Screen.RichTextBoxDescripTo = lngRichTextBoxDescripTo
        Central_Screen.RichTextBoxDescripDescrip = lngRichTextBoxDescripDescrip
        Central_Screen.RichTextBoxDescripActors = lngRichTextBoxDescripActors
        Central_Screen.RichTextBoxDescripCategory = lngRichTextBoxDescripCategory
        Central_Screen.RichTextBoxDescripProductionDate = lngRichTextBoxDescripProductionDate
        Central_Screen.RichTextBoxDescripDuree = lngRichTextBoxDescripDuree
        Central_Screen.RichTextBoxDescripShowView = lngRichTextBoxDescripShowView
        Central_Screen.RichTextBoxDescripDate = lngRichTextBoxDescripDate
        Central_Screen.RichTextBoxDescripGenre = lngRichTextBoxDescripGenre

        'CHANNELSVIEW
        ChannelView.Text = lngChannelViewTitle
        ChannelView.ChannelViewCheckBox24hHours.Text = lngChannelViewCheckBox24hHours
        ChannelView.ChannelViewLabelOr.Text = lngChannelViewLabelOr
        ChannelView.ChannelViewButtonClose.Text = lngChannelViewButtonClose
        ChannelView.ChannelListView.Columns(0).Text = lngChannelViewListViewColumns0
        ChannelView.ChannelListView.Columns(1).Text = lngChannelViewListViewColumns1
        ChannelView.ChannelListView.Columns(2).Text = lngChannelViewListViewColumns2
        ChannelView.ChannelListView.Columns(3).Text = lngChannelViewListViewColumns3

        'TIMEZONE
        TimeZone.Text = lngTimeZoneTitle
        TimeZone.TimeZoneLabelCompensation.Text = lngTimeZoneLabelCompensation
        TimeZone.TimeZoneLabelMinute.Text = lngTimeZoneLabelMinute

        'ENGINESELECTION
        EngineSelection.Text = lngEngineSelectionTitle
        EngineSelection.EngineSelectionShowCheckBox.Text = lngEngineSelectionShowCheckBox

        'STATUSSTRIP
        Mainform.ToolStripStatusLabelActiveEngine.Text = lngToolStripStatusLabelActiveEngine
        Mainform.ToolStripStatusLabelMemory.Text = lngToolStripStatusLabelMemory
        Mainform.ToolStripStatusLabelMB = lngToolStripStatusLabelMB

        'LOADER
        Mainform.LbLoader1.Text = lngLoaderLabelWait

        'SIGNALETIQUE
        signaletique.Text = lngSignaletique
        signaletique.SignaletiqueLabel10.Text = lngSignaletiqueLabel10
        signaletique.SignaletiqueLabel12.Text = lngSignaletiqueLabel12
        signaletique.SignaletiqueLabel16.Text = lngSignaletiqueLabel16
        signaletique.SignaletiqueLabel18.Text = lngSignaletiqueLabel18
        signaletique.SignaletiqueLabel43.Text = lngSignaletiqueLabel43
        signaletique.SignaletiqueLabel169.Text = lngSignaletiqueLabel169
        signaletique.SignaletiqueLabelStereo.Text = lngSignaletiqueLabelStereo
        signaletique.SignaletiqueLabelCaption.Text = lngSignaletiqueLabelCaption
        signaletique.SignaletiqueLabelHD.Text = lngSignaletiqueLabelHD
        signaletique.SignaletiqueLabelFirstAir.Text = lngSignaletiqueLabelFirstAir

        'WEATHERUPDATE
        Mainform.WeatherInformation = lngWeatherInformation

        'FRMSELECTWEATHER
        Forecast.Text = lngForecastTitre
        Forecast.OK_Button.Text = lngOK
        Forecast.Cancel_Button.Text = lngAnnuler
        Forecast.Location_Button.Text = lngLocation

        'WEATHERCITYSELECT
        WeatherCitySelect.Text = lngWeatherCitySelectTitre
        WeatherCitySelect.OK_Button.Text = lngOK
        WeatherCitySelect.Cancel_Button.Text = lngAnnuler

        'PROGRESSBAR
        ProgressBar.Text = lngProgressBarSaveTitre
        ProgressBar.ProgressBarLabel.Text = lngProgressBarSaveLabel

    End Sub

    Public Function DateLangue(ByVal laDate As DateTime) As String

        'rvs75 30/11/2009
        'renvoie une date dans une langue indépendemment des options régionale de l'ordinateur
        Dim _
            NameofDay() As String = _
                {lngDescriptDimancheLabel, lngDescriptLundiLabel, lngDescriptMardiLabel, lngDescriptMercrediLabel, _
                 lngDescriptJeudiLabel, lngDescriptVendrediLabel, lngDescriptSamediLabel}
        Dim _
            NameofMonth() As String = _
                {lngNameofMonth1, lngNameofMonth2, lngNameofMonth3, lngNameofMonth4, lngNameofMonth5, _
                 lngNameofMonth6, lngNameofMonth7, lngNameofMonth8, lngNameofMonth9, lngNameofMonth10, _
                 lngNameofMonth11, lngNameofMonth12}

        Dim sjour As String = NameofDay(CType(laDate.DayOfWeek, Integer))
        Dim sjour_du_mois As String = laDate.Day.ToString
        Dim sMois As String = NameofMonth((laDate.Month - 1))
        Dim sAnnée As String = laDate.Year.ToString()

        If My.Settings.Language = "English" Then
            DateLangue = sjour & ", " & sMois & " " & sjour_du_mois & ", " & sAnnée
        Else
            DateLangue = sjour & " " & sjour_du_mois & " " & sMois & " " & sAnnée
        End If
    End Function
End Module
