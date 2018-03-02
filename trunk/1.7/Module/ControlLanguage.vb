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
Imports ZGuideTV.ZGuideTVDotNetTvdb

' ReSharper disable CheckNamespace
Friend Module ControlLanguage
    ' ReSharper restore CheckNamespace

    Public Sub SetControlLanguage(Optional ByVal iForm As Integer = 0)

        'SELECTLANGUAGE
        SelectLanguage.ButtonOK.Text = LngSelectLanguageButtonOk
        SelectLanguage.ButtonCancel.Text = LngSelectLanguageButtonCancel

        If iForm = 12 Then
            Return
        End If

        'PREMIERDEMARRAGE
        PremierDemarrage.Text = LngPremierDemarrageTitle
        PremierDemarrage.LabelUtilisateur.Text = LngLabelUtilisateur
        PremierDemarrage.GroupBoxProxy.Text = LngGroupBoxConnexion
        PremierDemarrage.GroupBoxProxy.Text = LngGroupBoxProxy
        PremierDemarrage.LabelUtilisateur.Text = LngLabelUtilisateur
        PremierDemarrage.LabelMotdePasse.Text = LngLabelMotdePasse
        PremierDemarrage.LabelProxy.Text = LngLabelProxy
        PremierDemarrage.LabelPort.Text = LngLabelPort
        PremierDemarrage.LabelInfo.Text = LngPremierDemarrageLabelInfo
        PremierDemarrage.ButtonOK.Text = LngPremierDemarrageButtonOk
        PremierDemarrage.ButtonCancel.Text = LngPremierDemarrageButtonCancel
        PremierDemarrage.ButtonProxyTest.Text = LngPremierDemarrageButtonCheck

        If iForm = 10 Then
            Return
        End If

        'PREF_TABPAGE_GENERAL
        Pref.Text = LngPrefTitle
        Pref.TabPageGeneral.Text = LngTabPageGeneral
        Pref.GroupBoxPurge.Text = LngGroupBoxPurge
        Pref.GroupBoxEffects.Text = LngGroupBoxEffects
        Pref.GroupBoxConfHardware.Text = LngGroupBoxConfHardware
        Pref.GroupBoxSauvegardeFenetre.Text = LngGroupBoxSauvegardeFenetre
        Pref.GroupBoxDivers.Text = LngGroupBoxDivers
        'Pref.GroupBoxFiltres.Text = LngGroupBoxFiltres
        Pref.GroupBoxPosition.Text = LngGroupBoxPosition
        Pref.CheckBoxPurge.Text = LngCheckBoxPurge
        Pref.CheckBoxFadeOut.Text = LngCheckBoxFadeOut
        Pref.CheckBoxSlide.Text = LngCheckBoxSlide
        Pref.RadioButtonConfNormal.Text = LngRadioButtonConfNormal
        Pref.RadioButtonConfAverage.Text = LngRadioButtonConfAverage
        Pref.RadioButtonConfMinimum.Text = LngRadioButtonConfMinimum
        Pref.CheckBoxConfigWindow.Text = LngCheckBoxConfigWindow
        Pref.CheckBoxtracelog.Text = LngCheckBoxtracelog
        'Pref.CheckBoxFilters.Text = LngCheckBoxFilters
        Pref.GroupBoxMouse.Text = LngGroupBoxMouse
        Pref.CheckBoxaccordscrollhorizontal.Text = LngCheckBoxaccordscrollhorizontal
        Pref.CheckBoxbuttonssave.Text = LngCheckBoxbuttonssave
        Pref.CheckBoxUrlUpdate.Text = LngCheckBoxUrlUpdate
        Pref.GroupBoxUrlUpdate.Text = LngGroupBoxUrlUpdate
        Pref.CheckBoxToolTipsBallon.Text = LngCheckBoxToolTipsBallon
        Pref.GroupBoxToolTipsBallon.Text = LngGroupBoxToolTipsBallon
        Pref.CheckBoxSystray.Text = LngCheckBoxSystray
        Pref.GroupBoxSystray.Text = LngGroupBoxSystray

        'PREF_TABPAGE_MAJ_DONNEES
        Pref.TabPageMiseajourDonnees.Text = LngTabPageMiseajourDonnees
        Pref.GroupBoxIntervalle.Text = LngGroupBoxIntervalle
        Pref.GroupBoxUpdateLast.Text = LngGroupBoxUpdateLast
        Pref.GroupBoxAutoUpdate.Text = LngGroupBoxAutoUpdate
        Pref.GroupBoxTailleBdd.Text = LngGroupBoxTailleBdd
        Pref.GroupBoxUpdateIn.Text = LngGroupBoxUpdateIn
        Pref.GroupBoxUpdateNext.Text = LngGroupBoxUpdateNext
        Pref.CheckBoxAutoUpdate.Text = LngCheckBoxAutoUpdate
        Pref.TextBoxUpdateDay.Text = LngTextBoxUpdateDay

        'PREF_TABPAGE_MAJ_LOGICIEL
        Pref.CheckBoxAutoverif.Text = LngCheckBoxAutoverif
        Pref.GroupBoxAutoUpdateExe.Text = LngGroupBoxAutoUpdateExe

        'PREF_TABPAGE_MAJ_CESOIR_MAINTENANT
        Pref.TabPageCesoirMaintenant.Text = LngTabPageCesoirMaintenant
        Pref.GroupBoxCesoir.Text = LngGroupBoxCesoir
        Pref.GroupBoxMaintenant.Text = LngGroupBoxMaintenant
        Pref.RadioButtonCesoirAll.Text = LngRadioButtonCesoirAll
        Pref.RadioButtonCesoir45.Text = LngRadioButtonCesoir45
        Pref.RadioButtonCesoir60.Text = LngRadioButtonCesoir60
        Pref.RadioButtonCesoir75.Text = LngRadioButtonCesoir75
        Pref.RadioButtonCesoir90.Text = LngRadioButtonCesoir90
        Pref.RadioButtonCesoir105.Text = LngRadioButtonCesoir105
        Pref.RadioButtonCesoir120.Text = LngRadioButtonCesoir120
        Pref.RadioButtonMaintenantAll.Text = LngRadioButtonMaintenantAll
        Pref.RadioButtonMaintenant45.Text = LngRadioButtonMaintenant45
        Pref.RadioButtonMaintenant60.Text = LngRadioButtonMaintenant60
        Pref.RadioButtonMaintenant75.Text = LngRadioButtonMaintenant75
        Pref.RadioButtonMaintenant90.Text = LngRadioButtonMaintenant90
        Pref.RadioButtonMaintenant105.Text = LngRadioButtonMaintenant105
        Pref.RadioButtonMaintenant120.Text = LngRadioButtonMaintenant120

        'PREF_TABPAGE_MODE_VEILLE
        Pref.TabPageResume.Text = LngTabPageResume
        Pref.GroupBoxResume.Text = LngGroupBoxResume
        Pref.CheckBoxResume.Text = LngCheckBoxResume
        Pref.GroupBoxResumeBefore.Text = LngGroupBoxResumeBefore
        Pref.RadioButtonResume5.Text = LngRadioButtonResume5
        Pref.RadioButtonResume10.Text = LngRadioButtonResume10
        Pref.RadioButtonResume15.Text = LngRadioButtonResume15
        Pref.RadioButtonResume20.Text = LngRadioButtonResume20
        Pref.RadioButtonResume30.Text = LngRadioButtonResume30

        'PREF_TABPAGE_GESTION_SON
        Pref.TabPageSound.Text = LngTabPageSound
        Pref.GroupBoxRSS.Text = LngGroupBoxRss
        Pref.GroupBoxMessages.Text = LngGroupBoxMessages
        Pref.GroupBoxReminder.Text = LngGroupBoxReminder
        Pref.GroupBoxMute.Text = LngGroupBoxMute
        Pref.CheckBoxAudioOn.Text = LngCheckBoxAudioOn

        If iForm <> 7 Then

            'PREF_BUTTON
            Pref.ButtonOK.Text = LngButtonOk
            Pref.ButtonCancel.Text = LngButtonCancel

            'GESTIONCATEGORIE
            GestionCategorie.Text = LngGestionCategorietxt
            GestionCategorie.lblInfo.Text = LngGestionCategorielblInfo
            GestionCategorie.gbxGroupeCategorie.Text = LngGestionCategoriegbxGroupeCategorie
            GestionCategorie.lblNomGroupeCategorie.Text = LngGestionCategorielblNomGroupeCategorie
            GestionCategorie.lblCouleurGroupeCategorie.Text = LngGestionCategorielblCouleurGroupeCategorie
            'GestionCategorie.lblCouleur.Text = LngGestionCategorielblCouleur
            GestionCategorie.pvCouleur.Text = LngGestionCategorielblCouleur
            GestionCategorie.btModifierGroupeCategorie.Text = LngGestionCategoriebtModifierGroupeCategorie
            GestionCategorie.btAjouterGroupe.Text = LngGestionCategoriebtAjouterGroupe
            GestionCategorie.chkSuppGroupeVide.Text = LngGestionCategoriechkSuppGroupeVide
            GestionCategorie.btSauvegarder.Text = LngGestionCategoriebtSauvegarder
            GestionCategorie.btRecharger.Text = LngGestionCategoriebtRecharger
            GestionCategorie.btFermer.Text = LngGestionCategoriebtFermer
            GestionCategorie.cmsGroup.Items(0).Text = LngGestionCategorieDeplacerVers

            'MAINFORM_TOOLSTRIP_MENU_FILE
            Mainform.ToolStripMenuFile.Text = LngToolStripMenuFile
            Mainform.ToolStripMenuFileSave.Text = LngToolStripMenuFileSave
            Mainform.ToolStripMenuFileRestart.Text = LngToolStripMenuFileRestart
            Mainform.ToolStripMenuFileExit.Text = LngToolStripMenuFileExit
            Mainform.ToolStripMenuItemSettingsReset.Text = LngToolStripMenuItemSettingsReset

            'MAINFORM_TOOLSTRIP_MENU_EDIT
            Mainform.ToolStripMenuEdit.Text = LngToolStripMenuEdit
            Mainform.ToolStripMenuEditOntop.Text = LngToolStripMenuEditOntop
            Mainform.ToolStripMenuSearch.Text = LngToolStripMenuSearch
            Mainform.ToolStripMenuPrintTonight.Text = LngToolStripMenuPrintTonight
            Mainform.ToolStripMenuCalendar.Text = LngToolStripMenuCalendar

            'MAINFORM_TOOLSTRIP_MENU_OPTIONS
            Mainform.ToolStripMenuOptions.Text = LngToolStripMenuOptions
            Mainform.ToolStripMenuOptionsUpdate.Text = LngToolStripMenuOptionsUpdate
            Mainform.ToolStripMenuOptionsAutoUpdate.Text = LngToolStripMenuOptionsAutoUpdate
            Mainform.ToolStripMenuOptionsPreferences.Text = LngToolStripMenuOptionsPreferences
            Mainform.ToolStripMenuOptionsLogos.Text = LngToolStripMenuOptionsLogos
            Mainform.ToolStripMenuOptionsDualMonitor.Text = LngToolStripMenuOptionsDualMonitor
            Mainform.ToolStripMenuOptionsCouleurCategorie.Text = LngToolStripMenuOptionsCouleurCategorie

            'MAINFORM_TOOLSTRIP_MENU_HELP
            Mainform.ToolStripMenuHelp.Text = LngToolStripMenuHelp
            Mainform.ToolStripMenuHelpHelptopics.Text = LngToolStripMenuHelpHelptopics
            Mainform.ToolStripMenuHelpHelpShortcuts.Text = LngToolStripMenuHelpHelpShortcuts
            Mainform.ToolStripMenuHelpWebsite.Text = LngToolStripMenuHelpWebsite
            Mainform.ToolStripMenuHelpForum.Text = LngToolStripMenuHelpForum
            Mainform.ToolStripMenuHelpLanguage.Text = LngToolStripMenuHelpLanguage
            Mainform.ToolStripMenuHelpAbout.Text = LngToolStripMenuHelpAbout
            Mainform.ToolStripMenuHelpManualFeedBack.Text = LngToolStripMenuHelpManualFeedBack
            Mainform.ToolStripMenuHelpDonate.Text = LngToolStripMenuHelpDonate
            Mainform.ToolStripMenuHelpCompensation.Text = LngToolStripMenuHelpCompensation

            'MAINFORM_TOOLSTRIP
            Mainform.ToolStripSave.ToolTipText = LngToolStripSave
            Mainform.ToolStripPrintTonight.ToolTipText = LngToolStripMenuPrintTonight
            Mainform.ToolStripSearch.ToolTipText = LngToolStripSearch
            Mainform.ToolStripOntop.ToolTipText = LngToolStripOntop
            Mainform.ToolStripPreferences.ToolTipText = LngToolStripPreferences
            Mainform.ToolStripLogos.ToolTipText = LngToolStripLogos
            Mainform.ToolStripUpdate.ToolTipText = LngToolStripUpdate
            Mainform.ToolStripAutoUpdate.ToolTipText = LngToolStripAutoUpdate
            Mainform.ToolStripDualMonitor.ToolTipText = LngToolStripDualMonitor
            Mainform.ToolStripWebsite.ToolTipText = LngToolStripWebsite
            Mainform.ToolStripForum.ToolTipText = LngToolStripForum
            Mainform.ToolStripLangue.ToolTipText = LngToolStripLangue
            Mainform.ToolStripAbout.ToolTipText = LngToolStripAbout
            Mainform.ToolStripHelptopics.ToolTipText = LngToolStripHelptopics
            Mainform.ToolStripHelpShortcuts.ToolTipText = LngToolStripHelpShortcuts
            Mainform.ToolStripCalendar.ToolTipText = LngToolStripCalendar
            Mainform.ToolStripManualFeedBack.ToolTipText = LngToolStripManualFeedBack
            Mainform.ToolStripTextBoxRecherche.Text = LngToolStripTextBoxRecherche
            Mainform.ToolStripButtonRecherche.ToolTipText = LngToolStripButtonRecherche
            Mainform.ToolStripButtonDonate.ToolTipText = LngToolStripButtonDonate
            Mainform.ToolStripOptionsCouleurCategorie.ToolTipText = LngToolStripOptionsCouleurCategorie

            'MAINFORM_PAVE
            Mainform.navigtemporelle.TextJourMoins = LngPaveJourMoins
            Mainform.navigtemporelle.TextHeureMoins = LngPaveHeureMoins
            Mainform.navigtemporelle.Text06H = LngPave6H
            Mainform.navigtemporelle.Text09H = LngPave9H
            Mainform.navigtemporelle.Text12H = LngPave12H
            Mainform.navigtemporelle.Text15H = LngPave15H
            Mainform.navigtemporelle.Text18H = LngPave18H
            Mainform.navigtemporelle.Text20H = LngPave20H
            Mainform.navigtemporelle.Text23H = LngPave23H
            Mainform.navigtemporelle.TextMaintenant = LngPaveMaintenant
            Mainform.navigtemporelle.TextHeurePlus = LngPaveHeurePlus
            Mainform.navigtemporelle.TextJourPlus = LngPaveJourPlus

            'MESSAGEBOXNOCONNECTION
            Mainform.MessageBoxNoConnection = LngMessageBoxNoConnection
            Mainform.MessageBoxNoConnection1 = LngMessageBoxNoConnection1
            Mainform.MessageBoxNoConnectionTitre = LngMessageBoxNoConnectionTitre

            'NOTIFYICON
            Mainform.BalloonText1 = lngBalloonText1
            Mainform.BalloonText3 = lngBalloonText3

            ''SYSTRAY
            'Mainform.SystrayMenuRestore.Text = lngSystrayMenuRestore
            'Mainform.SystrayMenuExit.Text = lngSystrayMenuExit

            'MESSAGEBOXNODATA
            Mainform.MessageBoxNoData = LngMessageBoxNoData
            Mainform.MessageBoxNoDataTitre = LngMessageBoxNoDataTitre

            'JUMPLIST
            Mainform.Siteofficiel = LngSiteOfficiel
            Mainform.Forumofficiel = LngForumOfficiel

            'MESSAGEBOXGESTIONCATEGORIESAUVEGARDER
            GestionCategorie.MsgBoxTitre = LngMessageBoxGestionCategorieTitre
            GestionCategorie.MsgBoxNonSauvegarde1 = LngMessageBoxGestionCategorieNonSauvegarde1
            GestionCategorie.MsgBoxNonSauvegarde2 = LngMessageBoxGestionCategorieNonSauvegarde2

            If iForm = 15 Then
                Return
            End If

            'MESSAGEBOXBASEPERIMEE
            Mainform.MessageBoxBasePerimee = LngMessageBoxBasePerimee
            Mainform.MessageBoxBasePerimee1 = LngMessageBoxBasePerimee1
            Mainform.MessageBoxBasePerimeeTitre = LngMessageBoxBasePerimeeTitre

            If iForm = 16 Then
                Return
            End If

            'GESTIONBDD
            Gestionbdd.ListViewGestionBdd.Columns(0).Text = LngListViewGestionBddColumns0
            Gestionbdd.ListViewGestionBdd.Columns(1).Text = LngListViewGestionBddColumns1
            Gestionbdd.ListViewGestionBdd.Columns(2).Text = LngListViewGestionBddColumns2
            Gestionbdd.Text = LngGestionBddTitre
            Gestionbdd.ButtonDelete.Text = LngGestionBddButtonDelete
            Gestionbdd.ButtonSave.Text = LngGestionBddButtonSave
            Gestionbdd.ButtonRestore.Text = LngGestionBddButtonRestore
            Gestionbdd.ButtonRename.Text = LngGestionBddButtonRename
            Gestionbdd.ButtonCancel.Text = LngGestionBddButtonCancel
            Gestionbdd.GroupBoxRestauration.Text = LngGroupBoxRestauration
            Gestionbdd.CheckBoxRestaurationDataBase.Text = LngCheckBoxRestaurationDataBase
            Gestionbdd.CheckBoxRestaurationChaines.Text = LngCheckBoxRestaurationChaines
            Gestionbdd.CheckBoxRestaurationUrl.Text = LngCheckBoxRestaurationUrl
            Gestionbdd.CheckBoxRestaurationUserConfig.Text = LngCheckBoxRestaurationUserConfig
            Gestionbdd.DirectoryBackup.Text = LngDirectoryBackup
            Gestionbdd.LabelBackupDirectory.Text = LngBackupDirectory

            'MESSAGEBOXSAVEDONE
            Gestionbdd.MessageboxSaveDone = LngMessageboxSaveDone
            Gestionbdd.MessageboxSaveDoneTitre = LngMessageboxSaveDoneTitre

            'MESSAGEBOXRENAMEDONE
            Gestionbdd.MessageboxRenameDone = LngMessageboxRenameDone
            Gestionbdd.MessageboxRenameDoneTitre = LngMessageboxRenameDoneTitre

            'MESSAGEBOXDELETEDONE
            Gestionbdd.MessageboxDeleteDone = LngMessageboxDeleteDone
            Gestionbdd.MessageboxDeleteDoneTitre = LngMessageboxDeleteDoneTitre

            'INPUTBOXNAMEBDD
            Gestionbdd.InputBoxNameBdd = LngInputBoxNameBdd
            Gestionbdd.InputBoxNameBddTitre = LngInputBoxNameBddTitre

            'INPUTBOXRENAMEBDD
            Gestionbdd.InputBoxRenameBdd = LngInputBoxRenameBdd
            Gestionbdd.InputBoxRenameBddTitre = LngInputBoxRenameBddTitre

            'MESSAGEBOXFILESAVE
            Gestionbdd.MessageBoxFileRestoreTitre = LngMessageBoxFileRestoreTitre
            Gestionbdd.MessageBoxFileRestore = LngMessageBoxFileRestore
            Gestionbdd.MessageBoxFileRestore1 = LngMessageBoxFileRestore1
            Gestionbdd.MessageBoxFileRestore2 = LngMessageBoxFileRestore2

            'MESSAGEBOXNORESTORESELECTED
            Gestionbdd.MessageBoxNoRestoreSelectedTitre = LngMessageBoxNoRestoreSelectedTitre
            Gestionbdd.MessageBoxNoRestoreSelected = LngMessageBoxNoRestoreSelected

            'MESSAGEBOXNORESTOREELEMENT
            Gestionbdd.MessageBoxNoRestoreElementTitre = LngMessageBoxNoRestoreElementTitre
            Gestionbdd.MessageBoxNoRestoreElement = LngMessageBoxNoRestoreElement

            'MESSAGEBOXNODIRECTORYSELECTED
            Gestionbdd.MessageBoxNoDirectorySelectedTitre = LngMessageBoxNoDirectorySelectedTitre
            Gestionbdd.MessageBoxNoDirectorySelected = LngMessageBoxNoDirectorySelected

            'MESSAGEBOXNODIRECTORYEXISTS
            Gestionbdd.MessageBoxNoDirectoryExistsTitre = LngMessageBoxNoDirectoryExistsTitre
            Gestionbdd.MessageBoxNoDirectoryExists = LngMessageBoxNoDirectoryExists

            If iForm = 17 Then
                Return
            End If

            'FRM_ABOUT
            About.Text = LngAboutTitle
            About.TabPageAbout.Text = LngTabPageAbout
            About.TabPageAuteurs.Text = LngTabPageAuteurs
            About.TextBoxAdmin.Text = LngTextBoxAdmin
            About.TextBoxDev.Text = LngTextBoxDev
            About.TextBoxTesters.Text = LngTextBoxTesters
            About.TextBoxContributors.Text = LngTextBoxContributors
            About.TextBoxThanks.Text = LngTextBoxThanks
            About.TabPagelicence.Text = LngTabPagelicence
            About.TabPage7zip.Text = LngTabPage7Zip
            About.TabPageDonate.Text = LngTabPageDonate

            If iForm = 18 Then
                Return
            End If

            'MAINFORM_CESOIR_MAINTENANT

            '-----------------------------------------------------------------------------------
            ' lorsque les donnees sont perimees on a eu une erreur car index 0 est hors limite
            'BB 121009
            '--------------------------------------------------------------------------------
            'Mainform.Panel_titre_ce_soir.Controls.Item(0).Text = LngPanelTitreCesoir
            Mainform.lbl_Titre_Ce_Soir.Text = LngPanelTitreCesoir
            'Mainform.Panel_titre_maintenant.Controls.Item(0).Text = LngPanelTitreMaintenant
            Mainform.lbl_titre_maintenant.Text = LngPanelTitreMaintenant

        End If

        'REORGCHANNEL_TITLE
        ReorgChannel.Text = LngReorgChannelTitle

        'REORGCHANNEL_BUTTON
        ReorgChannel.btMonter.Text = LngButtonMonterReorgChannel
        ReorgChannel.btDescendre.Text = LngButtonDescendreReorgChannel
        ReorgChannel.btSupprimer.Text = LngButtonSupprimerReorgChannel
        ReorgChannel.btLogo.Text = LngButtonLogoReorgChannel
        ReorgChannel.btEnregistrer.Text = LngButtonEnregistrerReorgChannel
        ReorgChannel.btAnnuler.Text = LngButtonAnnulerReorgChannel
        ReorgChannel.lstChaine.Columns(0).Text = LngReorgChannelListViewColumns0
        ReorgChannel.lstChaine.Columns(1).Text = LngReorgChannelListViewColumns1

        If iForm = 7 Then

            'FRMMISEAJOUR
            Miseajour.Text = LngFrmMiseajour
            Miseajour.RadioButtonDownload.Text = LngRadioButtonDownload
            Miseajour.RadioButtonXmlPath.Text = LngRadioButtonXmlPath
            Miseajour.ButtonTout.Text = LngButtonTout
            Miseajour.ButtonSuppr.Text = LngButtonSuppr
            Miseajour.ButtonAppliquer.Text = LngButtonMiseaJour
            Miseajour.ButtonDemarrer.Text = LngButtonDemarrer
            Miseajour.ButtonAnnuler.Text = LngButtonAnnuler
            Miseajour.ButtonEdit.Text = LngButtonEdit
            Miseajour.CheckBoxAutoRestartManualUpdate.Text = LngCheckBoxAutoRestartManualUpdate
            Miseajour.txbRecherche.Text = LngTextBoxRecherche

            'FRMMISEAJOUR_MESSAGE
            Miseajour.ErrorInChannelListRecovery = LngErrorInChannelListRecovery
            Miseajour.InvalidUrl = LngInvalidUrl
            Miseajour.UntraceableFile = LngUntraceableFile
            Miseajour.ErrorInUpdate = LngErrorInUpdate
            Miseajour.ErrorInXmlCopy = LngErrorInXmlCopy
            Miseajour.ErrorInFileCopy = LngErrorInFileCopy
            Miseajour.ErrorInUnzip = LngErrorInUnzip
            Miseajour.WrongFileName = LngWrongFileName
            Miseajour.FailUrlFileDownload = LngFailUrlFileDownload
            Miseajour.UntraceableUrlListFile = LngUntraceableUrlListFile
            Miseajour.TheFile = LngTheFile
            Miseajour.DontExist = LngDontExist
            Miseajour.ProtectedFile = LngProtectedFile
            Miseajour.ChosenChannels = LngChosenChannels
            Miseajour.AvailableChannels = LngAvailableChannels
            Miseajour.MessageBoxDirChecked = LngMessageBoxDirChecked
            Miseajour.MessageBoxDirChecked1 = LngMessageBoxDirChecked1
            Miseajour.MessageBoxDirCheckedTitre = LngMessageBoxDirCheckedTitre
            Miseajour.MessageBoxFileNotExist = LngMessageBoxFileNotExist
            Miseajour.MessageBoxFileNotExist1 = LngMessageBoxFileNotExist1
            Miseajour.MessageBoxFileNotExistTitre = LngMessageBoxFileNotExistTitre
            Miseajour.MessageBoxUrlChecked = LngMessageBoxUrlChecked
            Miseajour.MessageBoxUrlChecked1 = LngMessageBoxUrlChecked1
            Miseajour.MessageBoxUrlCheckedTitre = LngMessageBoxUrlCheckedTitre
        End If

        ''MAINFORM_MENU_CONTEXTUEL_DESCRIPTION
        'Mainform.ToolStripMenuPrintDescript.Text = LngToolStripMenuPrintDescript

        'MAINFORM_MESSAGE_PROXY
        Mainform.MsgProxyTitle = LngMsgProxyTitle
        Mainform.MsgProxy = LngMsgProxy

        'MESSAGEBOXNOUPDATE
        Mainform.MessageBoxnoupdate = LngMessageBoxnoupdate
        Mainform.MessageBoxnoupdateTitre = LngMessageBoxnoupdateTitre

        'MESSAGEBOXMISEAJOUR
        Mainform.MessageBoxMiseaJour = LngMessageBoxMiseaJour
        Mainform.MessageBoxMiseaJour1 = LngMessageBoxMiseaJour1
        Mainform.MessageBoxMiseaJourTitre = LngMessageBoxMiseaJourTitre
        Mainform.MessageBoxMajauto = LngMessageBoxMajauto
        Mainform.MessageBoxMajautoTitre = LngMessageBoxMajautoTitre
        Mainform.MessageBoxfichierRetabli = LngMessageBoxfichierRetabli
        Mainform.MessageBoxfichierRetabliTitre = LngMessageBoxfichierRetabliTitre

        'MESSAGEBOXMISEAJOURDONE
        Mainform.MessageBoxMiseaJourDone = LngMessageBoxMiseaJourDone
        Mainform.MessageBoxMiseaJour1Done = LngMessageBoxMiseaJour1Done
        Mainform.MessageBoxMiseaJourTitreDone = LngMessageBoxMiseaJourTitreDone

        Miseajour.MessageBoxMiseaJourDone = LngMessageBoxMiseaJourDone
        Miseajour.MessageBoxMiseaJour1Done = LngMessageBoxMiseaJour1Done
        Miseajour.MessageBoxMiseaJourTitreDone = LngMessageBoxMiseaJourTitreDone

        'MESSAGEBOXMODIFPREF
        Mainform.MessageBoxModifPref = LngMessageBoxModifPref
        Mainform.MessageBoxModifPref1 = LngMessageBoxModifPref1
        Mainform.MessageBoxModifPrefTitre = LngMessageBoxModifPrefTitre

        'MESSAGEBOXNOCONNECTION
        CentralScreen.MessageBoxNoConnection = LngMessageBoxNoConnection
        CentralScreen.MessageBoxNoConnection1 = LngMessageBoxNoConnection1
        CentralScreen.MessageBoxNoConnectionTitre = LngMessageBoxNoConnectionTitre

        'MESSAGEBOXFEEDBACK
        Feedback.MessageBoxFeedback = LngMessageBoxFeedback
        Feedback.MessageBoxFeedbackTitre = LngMessageBoxFeedbackTitre

        'MESSAGEBOXFICHIERCORROMPU
        MessageFichierCorrompu = LngMessageFichierCorrompu
        MessageFichierCorrompu1 = LngMessageFichierCorrompu1
        MessageFichierCorrompu2 = LngMessageFichierCorrompu2
        MessageFichierCorrompuTitre = LngMessageFichierCorrompuTitre

        'MESSAGEBOXLISTXMLTVFRCHOISIE
        Miseajour.MessageBoxListXmltvfrChoisie = LngMessageBoxListXmltvfrChoisie
        Miseajour.MessageBoxListXmltvfrChoisie1 = LngMessageBoxListXmltvfrChoisie1
        Miseajour.MessageBoxListXmltvfrChoisieTitre = LngMessageBoxListXmltvfrChoisieTitre

        'MESSAGEBOXTHETVDBNORESULT
        SeriesBrowser.ThetvdbNoResult = LngMessageBoxThetvdbNoResult
        SeriesBrowser.ThetvdbNoResultTitre = LngMessageBoxThetvdbNoResultTitre

        'MESSAGEBOXTHETVDBVALIDESERIEID
        SeriesBrowser.ThetvdbNoSerieDetails = LngMessageBoxThetvdbNoSerieDetail
        SeriesBrowser.ThetvdbNoSerieDetailsTitre = LngMessageBoxThetvdbNoSerieDetailTitre

        'MESSAGEBOXTHETVDBNOSERIEDETAIL
        SeriesBrowser.ThetvdbNoValidSeriesId = LngMessageBoxThetvdbNoValidSeriesId
        SeriesBrowser.ThetvdbNoValidSeriesIdTitre = LngMessageBoxThetvdbNoValidSeriesIdTitre

        'THETVDBBOXNOSHEET
        SeriesBrowser.ThetvdbBoxNoSheet = LngThetvdbBoxNoSheet
        SeriesBrowser.ThetvdbBoxNoSheetTitre = LngThetvdbBoxNoSheetTitre

        'MESSAGEBOXTHETVDBNOACTORINFO
        SeriesBrowser.ThetvdbNoActorInfo = LngMessageBoxThetvdbNoActorInfo
        SeriesBrowser.ThetvdbNoActorInfoTitre = LngMessageBoxThetvdbNoActorInfoTitre

        'MESSAGEBOXTHETVDBNOBANNER
        SeriesBrowser.ThetvdbNoBanner = LngMessageBoxThetvdbNoBanner
        SeriesBrowser.ThetvdbNoBannerTitre = LngMessageBoxThetvdbNoBannerTitre

        'MESSAGEBOXMESSAGEENVOYE
        Feedback.MessageBoxMessageEnvoye = LngMessageBoxMessageEnvoye
        Feedback.MessageBoxMessageEnvoyeTitre = LngMessageBoxMessageEnvoyeTitre

        'MESSAGEBOXMESSAGEISEMPTY
        Feedback.MessageBoxMessageIsEmpty = LngMessageBoxMessageIsEmpty
        Feedback.MessageBoxMessageIsEmptyTitre = LngMessageBoxMessageIsEmptyTitre

        'MESSAGEBOXREORGCHANNEL
        ReorgChannel.MessageBoxReorgChannel = LngMessageBoxReorgChannel
        ReorgChannel.MessageBoxReorgChannel1 = LngMessageBoxReorgChannel1
        ReorgChannel.MessageBoxReorgChannelTitre = LngMessageBoxReorgChannelTitre

        'MESSAGEBOXRESUME
        Mainform.MessageBoxResume = LngMessageBoxResume
        Mainform.MessageBoxResume1 = LngMessageBoxResume1
        Mainform.MessageBoxResumeTitre = LngMessageBoxResumeTitre

        'MESSAGEBOXRAZ
        Mainform.MessageBoxRaz = LngMessageBoxRaz
        Mainform.MessageBoxRaz1 = LngMessageBoxRaz1
        Mainform.MessageBoxTitleRaz = LngMessageBoxTitleRaz

        'MESSAGEBOXMISEAJOUREXE
        Mainform.MessageBoxMiseaJourExe = LngMessageBoxMiseaJourExe
        Mainform.MessageBoxMiseaJourExe1 = LngMessageBoxMiseaJourExe1
        Mainform.MessageBoxMiseaJourExeTitre = LngMessageBoxMiseaJourExeTitre
        Mainform.MessageBoxMiseaJourExeActual = LngMessageBoxMiseaJourExeActual
        Mainform.MessageBoxMiseaJourExeNew = LngMessageBoxMiseaJourExeNew

        'MISEAJOURAUTO
        MiseAJourAuto.Text = LngMiseAJourAutoTitle
        MiseAJourAuto.NodeNumber = LngNodeNumber
        MiseAJourAuto.AutoUpdateOperation = LngAutoUpdateOperation
        MiseAJourAuto.DwnlOperation = LngdwnlOperation
        MiseAJourAuto.ParsingOperation = LngParsingOperation
        MiseAJourAuto.RemainingTime = LngremainingTime
        MiseAJourAuto.FileSize = LngfileSize

        'MISEAJOURAUTO_MESSAGE
        MiseAJourAuto.MessageBoxMajautoUrl = LngMessageBoxMajautoUrl
        MiseAJourAuto.MessageBoxMajautoUrlTitre = LngMessageBoxMajautoUrlTitre

        MiseAJourAuto.MessageBoxMajautoserverError = LngMessageBoxMajautoUrl
        MiseAJourAuto.MessageBoxMajautoserverErrorTitre = LngMessageBoxMajautoUrlTitre

        MiseAJourAuto.MessageBoxMajautoxmlError = LngMessageBoxMajautoxmlError
        MiseAJourAuto.MessageBoxMajautoxmlErrorTitre = LngMessageBoxMajautoxmlErrorTitre

        MiseAJourAuto.MessageBoxMajautoextractionError = LngMessageBoxMajautoextractionError
        MiseAJourAuto.MessageBoxMajautoextractionErrorTitre = LngMessageBoxMajautoextractionErrorTitre

        MiseAJourAuto.MessageBoxMajautocopyError = LngMessageBoxMajautocopyError
        MiseAJourAuto.MessageBoxMajautocopyErrorTitre = LngMessageBoxMajautocopyErrorTitre

        MiseAJourAuto.MessageBoxMajautonameError = LngMessageBoxMajautonameError
        MiseAJourAuto.MessageBoxMajautonameErrorTitre = LngMessageBoxMajautonameErrorTitre

        'CALENDRIER
        Mainform.CalendarLundiLabel.Text = LngCalendarLundiLabel
        Mainform.CalendarMardiLabel.Text = LngCalendarMardiLabel
        Mainform.CalendarMercrediLabel.Text = LngCalendarMercrediLabel
        Mainform.CalendarJeudiLabel.Text = LngCalendarJeudiLabel
        Mainform.CalendarVendrediLabel.Text = LngCalendarVendrediLabel
        Mainform.CalendarSamediLabel.Text = LngCalendarSamediLabel
        Mainform.CalendarDimancheLabel.Text = LngCalendarDimancheLabel
        Mainform.NameofMonth1 = LngNameofMonth1
        Mainform.NameofMonth2 = LngNameofMonth2
        Mainform.NameofMonth3 = LngNameofMonth3
        Mainform.NameofMonth4 = LngNameofMonth4
        Mainform.NameofMonth5 = LngNameofMonth5
        Mainform.NameofMonth6 = LngNameofMonth6
        Mainform.NameofMonth7 = LngNameofMonth7
        Mainform.NameofMonth8 = LngNameofMonth8
        Mainform.NameofMonth9 = LngNameofMonth9
        Mainform.NameofMonth10 = LngNameofMonth10
        Mainform.NameofMonth11 = LngNameofMonth11
        Mainform.NameofMonth12 = LngNameofMonth12

        'FEEDBACK
        Feedback.Text = LngFeedbackTitle
        Feedback.LabelExceptMessage1.Text = LngLabelExceptMessage1
        Feedback.LabelExceptMessage2.Text = LngLabelExceptMessage2
        Feedback.LabelExceptMessage3.Text = LngLabelExceptMessage3
        Feedback.LabelExceptMessage4.Text = LngLabelExceptMessage4
        Feedback.CheckBoxExceptErrorMessage.Text = LngCheckBoxExceptErrorMessage
        Feedback.LabelEmail.Text = LngLabelEmail
        Feedback.Send_Button.Text = LngSendButton
        Feedback.Copier_Button.Text = LngCopierButton
        Feedback.Exit_Button.Text = LngExitButton
        Feedback.ExceptErrorMessage.Text = LngExceptErrorMessage
        Feedback.LabelFeedbackSend.Text = LngLabelFeedbackSend
        Feedback.ZGuideTvRelease = LngZGuideTvRelease
        Feedback.CompilationDate = LngCompilationDate
        Feedback.OsRelease = LngOsRelease
        Feedback.Architecture = LngArchitecture
        Feedback.OsBootMode = LngOsBootMode
        Feedback.Framework = LngFramework
        Feedback.OsLanguage = LngOsLanguage
        Feedback.TotalMemory = LngTotalMemory
        Feedback.RemainingMemory = LngRemainingMemory
        Feedback.UsedMemory = LngUsedMemory
        Feedback.ProcessorName = LngProcessorName
        Feedback.ProcessorNumber = LngProcessorNumber
        Feedback.MonitorNumber = LngMonitorNumber
        Feedback.Email = LngEmail
        Feedback.Comments = LngComments
        Feedback.DescriptionError = LngDescriptionError
        Feedback.ProcessorSpeed = LngProcessorSpeed
        Feedback.CheckBoxAcknowledgment.Text = LngCheckBoxAcknowledgment
        Feedback.ProcessorDescription = LngProcessorDescription

        'THETVDBSEARCH
        MySearch.ThetvdbLabelSearchName.Text = LngThetvdbLabelSearchName
        MySearch.ThetvdbLabelID1.Text = LngThetvdbLabelId
        MySearch.ThetvdbLabelLanguage.Text = LngThetvdbLabelLanguage
        MySearch.ThetvdbButtonSearch.Text = LngThetvdbButtonSearch
        MySearch.ThetvdbLabelLoadFull.Text = LngThetvdbLabelLoadFull
        MySearch.ThetvdbLabelLoadActors.Text = LngThetvdbLabelLoadActors
        MySearch.ThetvdbLabelBanner.Text = LngThetvdbLabelBanner
        MySearch.ThetvdbLabelUseZipped.Text = LngThetvdbLabelUseZipped
        MySearch.ThetvdbButtonLoad.Text = LngThetvdbButtonLoad
        MySearch.ThetvdbButtonCancel.Text = LngThetvdbButtonCancel

        'THETVDBTAB
        SeriesBrowser.ThetvdbLabelSeriesTabSeries.Text = LngThetvdbLabelSeriesTabSeries
        SeriesBrowser.ThetvdbLabelEpisodesTabEpisodes.Text = LngThetvdbLabelEpisodesTabEpisodes
        SeriesBrowser.ThetvdbLabelActorsTabActors.Text = LngThetvdbLabelActorsTabActors

        'THETVDB
        SeriesBrowser.ThetvdbLabelSearchName1.Text = LngThetvdbLabelSearchName
        SeriesBrowser.ThetvdbButtonSearchShow.Text = LngThetvdbButtonSearch
        SeriesBrowser.ThetvdbLabelSiteRating.Text = LngThetvdbLabelSiteRating
        SeriesBrowser.ThetvdbLabelID.Text = LngThetvdbLabelId
        SeriesBrowser.ThetvdbLabelRuntime.Text = LngThetvdbLabelRuntime
        SeriesBrowser.ThetvdbLabelRating.Text = LngThetvdbLabelRating
        SeriesBrowser.ThetvdbLabelDescription.Text = LngThetvdbLabelDescription
        SeriesBrowser.ThetvdbLabelFirstAired.Text = LngThetvdbLabelFirstAired
        SeriesBrowser.ThetvdbLabelIDTVCom.Text = LngThetvdbLabelIdtvCom
        SeriesBrowser.ThetvdbButtonForceUpdate.Text = LngThetvdbLabelForceUpdate
        SeriesBrowser.ThetvdbLabelIDIMDB.Text = LngThetvdbLabelIdimdbCom
        SeriesBrowser.ThetvdbButtonExit.Text = LngThetvdbButtonExit
        SeriesBrowser.ThetvdbLabelGenre.Text = LngThetvdbLabelGenre
        SeriesBrowser.ThetvdbLabelActors.Text = LngThetvdbLabelActors
        SeriesBrowser.ThetvdbLabelActors1.Text = LngThetvdbLabelActors1
        SeriesBrowser.ThetvdbLabelGueststarTabEpisodes.Text = LngThetvdbLabelGueststar
        SeriesBrowser.ThetvdbLabelDirectorTabTabEpisodes.Text = LngThetvdbLabelDirector
        SeriesBrowser.ThetvdbLabelWriterTabEpisodes.Text = LngThetvdbLabelWriter
        SeriesBrowser.ThetvdbLabelOpen = LngThetvdbLabelOpen
        SeriesBrowser.ThetvdbLabelEpisodes.Text = LngThetvdbLabelEpisodes

        'THETVDBTABEPISODE
        SeriesBrowser.ThetvdbLabelLanguageTabEpisodes.Text = LngThetvdbLabelLanguage
        SeriesBrowser.ThetvdbLabelFirstAiredTabEpisodes.Text = LngThetvdbLabelFirstAired
        SeriesBrowser.ThetvdbLabelAbsoluteNumberTabEpisodes.Text = LngThetvdbLabelAbsoluteNumberTabEpisodes
        SeriesBrowser.ThetvdbLabelIDIMDBComTabEpisodes.Text = LngThetvdbLabelIdimdbCom
        SeriesBrowser.ThetvdbLabelProductCodeTabEpisodes.Text = LngThetvdbLabelProductCodeTabEpisodes
        SeriesBrowser.ThetvdbLabelDirectorTabTabEpisodes.Text = LngThetvdbLabelDirector
        SeriesBrowser.ThetvdbLabelGueststarTabEpisodes.Text = LngThetvdbLabelGueststar
        SeriesBrowser.ThetvdbLabelWriterTabEpisodes.Text = LngThetvdbLabelWriter
        SeriesBrowser.ThetvdbLabelOverviewTabEpisodes.Text = LngThetvdbLabelDescription
        SeriesBrowser.ThetvdbLabelDVDIDTabEpisodes.Text = LngThetvdbLabelDvdidTabEpisodes
        SeriesBrowser.ThetvdbLabelDVDSeasonTabEpisodes.Text = LngThetvdbLabelDvdSeasonTabEpisodes
        SeriesBrowser.ThetvdbLabelDVDNumberTabEpisodes.Text = LngThetvdbLabelDvdNumberTabEpisodes
        SeriesBrowser.ThetvdbLabelDVDChapterTabEpisodes.Text = LngThetvdbLabelDvdChapterTabEpisodes
        SeriesBrowser.ThetvdbNodeSeasonTabEpisodes = LngThetvdbNodeSeasonTabEpisodes

        'THETVDBTABACTORS
        SeriesBrowser.ThetvdbGroupBoxInformationTabActors.Text = LngThetvdbGroupBoxInformationTabActors
        SeriesBrowser.ThetvdbLabelIDTabActors.Text = LngThetvdbLabelIdTabActors
        SeriesBrowser.ThetvdbLabelNameTabActors.Text = LngThetvdbLabelNameTabActors
        SeriesBrowser.ThetvdbLabelRoleTabActors.Text = LngThetvdbLabelRoleTabActors
        SeriesBrowser.ThetvdbLabelSortOrderTabActors.Text = LngThetvdbLabelSortOrderTabActors

        'THETVDBRESULT
        SearchResultForm.ThetvdbGroupBoxResult.Text = LngThetvdbGroupBoxResult
        SearchResultForm.ThetvdblabelFirstAiredResult.Text = LngThetvdbLabelFirstAiredResult
        SearchResultForm.ThetvdbLabelIMDBIdResult.Text = LngThetvdbLabelImdbIdResult
        SearchResultForm.ThetvdbLabelOverviewResult.Text = LngThetvdbLabelOverviewResult
        SearchResultForm.ThetvdbLabelStatusResult.Text = LngThetvdbLabelStatusResult
        SearchResultForm.ThetvdbButtonChooseResult.Text = LngThetvdbButtonChooseResult
        SearchResultForm.ThetvdbButtonCancelResult.Text = LngThetvdbButtonCancelResult
        SearchResultForm.lvSearchResult.Columns(0).Text = LngThetvdbListviewResultColumns0
        SearchResultForm.lvSearchResult.Columns(1).Text = LngThetvdbListviewResultColumns1
        SearchResultForm.lvSearchResult.Columns(2).Text = LngThetvdbListviewResultColumns2

        'TIMEZONE
        TimeZone.Text = LngTimeZoneTitle
        TimeZone.TimeZoneLabelCompensation.Text = LngTimeZoneLabelCompensation
        TimeZone.TimeZoneLabelMinute.Text = LngTimeZoneLabelMinute

        ''ENGINESELECTION
        'EngineSelection.Text = LngEngineSelectionTitle
        'EngineSelection.EngineSelectionShowCheckBox.Text = LngEngineSelectionShowCheckBox
        'EngineSelection.EngineSelectionTvdbListBox = LngEngineSelectionTvdbListBox
        'EngineSelection.EngineSelectionImdbListBox = LngEngineSelectionImdbListBox
        'EngineSelection.EngineSelectionAllocineListBox = LngEngineSelectionAllocineListBox

        'STATUSSTRIP
        'Mainform.ToolStripStatusLabelActiveEngine.Text = LngToolStripStatusLabelActiveEngine
        Mainform.ToolStripStatusLabelMemory.Text = LngToolStripStatusLabelMemory
        Mainform.ToolStripStatusLabelMb = LngToolStripStatusLabelMb
        Mainform.ToolStripStatusLabelUpdate.Text = LngToolStripStatusLabelUpdate

        'IMPRIMEREMISSIONS
        ImprimeEmissions.ImprimerEmissionsTonight = LngImprimerEmissionsTonight
        ImprimeEmissions.ImprimerEmissionsNow = LngImprimerEmissionsNow

        ImprimeEmissions.ImprimerEmissionsLe = LngImprimerEmissionsLe
        ImprimeEmissions.ImprimerEmissionsDe = LngImprimerEmissionsDe
        ImprimeEmissions.ImprimerEmissionsA = LngImprimerEmissionsA
        ImprimeEmissions.ImprimerEmissionsRealise = LngImprimerEmissionsRealise
        ImprimeEmissions.ImprimerEmissionsAvec = LngImprimerEmissionsAvec
        ImprimeEmissions.ImprimerEmissionsResume = LngImprimerEmissionsResume

        'PROGRESSBAR
        ProgressBar.Text = LngProgressBarSaveTitre
        ProgressBar.ProgressBarLabel.Text = LngProgressBarSaveLabel

        'POPUP
        CentralScreen.popupContent.MajLangagePopup()
    End Sub

    Public Function DateLangue(ByVal laDate As DateTime) As String

        'rvs75 30/11/2009
        'renvoie une date dans une langue indépendemment des options régionale de l'ordinateur
        Dim _
            nameofDay() As String = _
                {LngDescriptDimancheLabel, LngDescriptLundiLabel, LngDescriptMardiLabel, LngDescriptMercrediLabel, _
                 LngDescriptJeudiLabel, LngDescriptVendrediLabel, LngDescriptSamediLabel}
        Dim _
            nameofMonth() As String = _
                {LngNameofMonth1, LngNameofMonth2, LngNameofMonth3, LngNameofMonth4, LngNameofMonth5, _
                 LngNameofMonth6, LngNameofMonth7, LngNameofMonth8, LngNameofMonth9, LngNameofMonth10, _
                 LngNameofMonth11, LngNameofMonth12}

        Dim sjour As String = nameofDay(CType(laDate.DayOfWeek, Integer))
        Dim sjourDuMois As String = laDate.Day.ToString
        Dim sMois As String = nameofMonth((laDate.Month - 1))
        Dim sAnnée As String = laDate.Year.ToString()

        If [String].Equals(My.Settings.Language, "English", StringComparison.CurrentCulture) Then
            DateLangue = sjour & ", " & sMois & " " & sjourDuMois & ", " & sAnnée
        Else
            DateLangue = sjour & " " & sjourDuMois & " " & sMois & " " & sAnnée
        End If
    End Function
End Module
