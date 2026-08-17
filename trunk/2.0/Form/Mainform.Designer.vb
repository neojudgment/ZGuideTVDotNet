<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mainform
    Inherits System.Windows.Forms.Form

    Private m_nFirstCharOnPage As Integer

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
            If Not _MGraphics Is Nothing Then _MGraphics.Dispose()


            'If Not _gLine Is Nothing Then _gLine.Dispose()

            'If Not _MGraphics Is Nothing Then _MGraphics.Dispose()

            'If Not _gLine Is Nothing Then _gLine.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    Friend WithEvents Restaurer As System.Windows.Forms.MenuItem
    Friend WithEvents Quitter As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainform))
        Me.ListViewChannel = New System.Windows.Forms.ListView()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.Timer_minute = New System.Windows.Forms.Timer(Me.components)
        Me.PanelD = New System.Windows.Forms.Panel()
        Me.PanelE = New System.Windows.Forms.Panel()
        Me.navigtemporelle = New ZGuideTV.BarreTemporelle()
        Me.PanelB = New System.Windows.Forms.Panel()
        Me.Panel_date = New System.Windows.Forms.Panel()
        Me.PanelA = New System.Windows.Forms.Panel()
        Me.Panel_glob_maintenant = New System.Windows.Forms.Panel()
        Me.btImprimemaintenant = New System.Windows.Forms.Button()
        Me.lbl_titre_maintenant = New System.Windows.Forms.Label()
        Me.Panel_maintenant = New System.Windows.Forms.Panel()
        Me.Panel_glob_ce_soir = New System.Windows.Forms.Panel()
        Me.btImprimeCeSoir = New System.Windows.Forms.Button()
        Me.lbl_Titre_Ce_Soir = New System.Windows.Forms.Label()
        Me.Panel_ce_soir = New System.Windows.Forms.Panel()
        Me.Calendar = New System.Windows.Forms.Panel()
        Me.lblMoisS = New System.Windows.Forms.Label()
        Me.lblMoisP = New System.Windows.Forms.Label()
        Me.CalendarDimancheLabel = New System.Windows.Forms.Label()
        Me.CalendarSamediLabel = New System.Windows.Forms.Label()
        Me.CalendarVendrediLabel = New System.Windows.Forms.Label()
        Me.CalendarJeudiLabel = New System.Windows.Forms.Label()
        Me.CalendarMercrediLabel = New System.Windows.Forms.Label()
        Me.CalendarMardiLabel = New System.Windows.Forms.Label()
        Me.CalendarLundiLabel = New System.Windows.Forms.Label()
        Me.Button5_3 = New ZGuideTV.Calendrierpavé()
        Me.Button6_7 = New ZGuideTV.Calendrierpavé()
        Me.Button5_2 = New ZGuideTV.Calendrierpavé()
        Me.Button3_2 = New ZGuideTV.Calendrierpavé()
        Me.Button5_7 = New ZGuideTV.Calendrierpavé()
        Me.Button5_1 = New ZGuideTV.Calendrierpavé()
        Me.Button6_1 = New ZGuideTV.Calendrierpavé()
        Me.L_MOIS_ANNEE = New System.Windows.Forms.Label()
        Me.Button4_7 = New ZGuideTV.Calendrierpavé()
        Me.Button6_6 = New ZGuideTV.Calendrierpavé()
        Me.Button4_6 = New ZGuideTV.Calendrierpavé()
        Me.Button5_6 = New ZGuideTV.Calendrierpavé()
        Me.Button3_4 = New ZGuideTV.Calendrierpavé()
        Me.Button6_4 = New ZGuideTV.Calendrierpavé()
        Me.Button4_5 = New ZGuideTV.Calendrierpavé()
        Me.Button6_5 = New ZGuideTV.Calendrierpavé()
        Me.Button4_4 = New ZGuideTV.Calendrierpavé()
        Me.Button5_4 = New ZGuideTV.Calendrierpavé()
        Me.Button6_3 = New ZGuideTV.Calendrierpavé()
        Me.Button4_3 = New ZGuideTV.Calendrierpavé()
        Me.Button5_5 = New ZGuideTV.Calendrierpavé()
        Me.Button4_2 = New ZGuideTV.Calendrierpavé()
        Me.Button6_2 = New ZGuideTV.Calendrierpavé()
        Me.Button4_1 = New ZGuideTV.Calendrierpavé()
        Me.Button3_7 = New ZGuideTV.Calendrierpavé()
        Me.Button3_6 = New ZGuideTV.Calendrierpavé()
        Me.Button3_5 = New ZGuideTV.Calendrierpavé()
        Me.Button3_3 = New ZGuideTV.Calendrierpavé()
        Me.Button3_1 = New ZGuideTV.Calendrierpavé()
        Me.Button2_1 = New ZGuideTV.Calendrierpavé()
        Me.Button2_2 = New ZGuideTV.Calendrierpavé()
        Me.Button2_3 = New ZGuideTV.Calendrierpavé()
        Me.Button2_4 = New ZGuideTV.Calendrierpavé()
        Me.Button2_5 = New ZGuideTV.Calendrierpavé()
        Me.Button2_6 = New ZGuideTV.Calendrierpavé()
        Me.Button2_7 = New ZGuideTV.Calendrierpavé()
        Me.Button1_7 = New ZGuideTV.Calendrierpavé()
        Me.Button1_6 = New ZGuideTV.Calendrierpavé()
        Me.Button1_1 = New ZGuideTV.Calendrierpavé()
        Me.Button1_5 = New ZGuideTV.Calendrierpavé()
        Me.Button1_2 = New ZGuideTV.Calendrierpavé()
        Me.Button1_4 = New ZGuideTV.Calendrierpavé()
        Me.Button1_3 = New ZGuideTV.Calendrierpavé()
        Me.ouvrirbasededonnees = New System.Windows.Forms.ToolStripButton()
        Me.sauvegardebasededonnees = New System.Windows.Forms.ToolStripButton()
        Me.copierladescriptionselectionnee = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Preview = New System.Windows.Forms.ToolStripButton()
        Me.Print = New System.Windows.Forms.ToolStripButton()
        Me.rechercheavancee = New System.Windows.Forms.ToolStripButton()
        Me.toujoursenavantplan = New System.Windows.Forms.ToolStripButton()
        Me.préférences = New System.Windows.Forms.ToolStripButton()
        Me.miseajourdeschaines = New System.Windows.Forms.ToolStripButton()
        Me.ajoutermodifierlogo = New System.Windows.Forms.ToolStripButton()
        Me.aidezguidetv = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripPrintTonight = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripOntop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripCalendar = New System.Windows.Forms.ToolStripButton()
        Me.RechercheToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripPreferences = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripOptionsCouleurCategorie = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripUpdate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDualMonitor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLogos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripAutoUpdate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripHelptopics = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripHelpShortcuts = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDonate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripAbout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLangue = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripManualFeedBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripFacebook = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripForum = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripWebsite = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTextBoxRecherche = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButtonRecherche = New System.Windows.Forms.ToolStripButton()
        Me.panel_droit = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuFileRestart = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemSettingsReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuEditOntop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuCalendar = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechercheInfosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuPrintTonight = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptionsUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptionsAutoUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuOptionsPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptionsCouleurCategorie = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptionsLogos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuOptionsDualMonitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpHelptopics = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpHelpShortcuts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuHelpWebsite = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpForum = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacebookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpDonate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuHelpManualFeedBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpCompensation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.RaccourcisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemJour_Moins = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemheure_moins = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6H = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9H = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12H = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15H = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem18H = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem20H = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem23H = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMaintenant = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemheure_plus = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemJour_Plus = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemChaineBas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemChaineHaut = New System.Windows.Forms.ToolStripMenuItem()
        Me.CeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CeSoirBasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaintenantHautToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaintenantBasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_date = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_heure = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelCompensation = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelMinutes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelMemory = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelMemoryUsage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelUpdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer_seconde = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_250msec = New System.Windows.Forms.Timer(Me.components)
        Me.TimerUsageMemory = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_wait = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_heure = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ZSplitButtonDroit = New ZGuideTV.ZSplitButton()
        Me.ZSplitButtonGauche = New ZGuideTV.ZSplitButton()
        Me.ZSplitButton1 = New ZGuideTV.ZSplitButton()
        Me.Timer_AutoUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.PanelE.SuspendLayout()
        Me.PanelB.SuspendLayout()
        Me.Panel_glob_maintenant.SuspendLayout()
        Me.Panel_glob_ce_soir.SuspendLayout()
        Me.Calendar.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.panel_droit.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewChannel
        '
        Me.ListViewChannel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewChannel.BackColor = System.Drawing.Color.White
        Me.ListViewChannel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListViewChannel.Location = New System.Drawing.Point(3, 44)
        Me.ListViewChannel.Name = "ListViewChannel"
        Me.ListViewChannel.Scrollable = False
        Me.ListViewChannel.Size = New System.Drawing.Size(27, 162)
        Me.ListViewChannel.TabIndex = 3
        Me.ListViewChannel.UseCompatibleStateImageBehavior = False
        Me.ListViewChannel.View = System.Windows.Forms.View.SmallIcon
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'Timer_minute
        '
        Me.Timer_minute.Enabled = True
        Me.Timer_minute.Interval = 60000
        '
        'PanelD
        '
        Me.PanelD.BackColor = System.Drawing.Color.White
        Me.PanelD.Location = New System.Drawing.Point(93, 59)
        Me.PanelD.Name = "PanelD"
        Me.PanelD.Size = New System.Drawing.Size(599, 32)
        Me.PanelD.TabIndex = 52
        '
        'PanelE
        '
        Me.PanelE.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelE.BackColor = System.Drawing.Color.White
        Me.PanelE.Controls.Add(Me.navigtemporelle)
        Me.PanelE.Location = New System.Drawing.Point(246, 615)
        Me.PanelE.Name = "PanelE"
        Me.PanelE.Size = New System.Drawing.Size(446, 45)
        Me.PanelE.TabIndex = 53
        Me.PanelE.TabStop = True
        '
        'navigtemporelle
        '
        Me.navigtemporelle.BackColor = System.Drawing.Color.White
        Me.navigtemporelle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.navigtemporelle.EnabledButton = True
        Me.navigtemporelle.Location = New System.Drawing.Point(0, 0)
        Me.navigtemporelle.Name = "navigtemporelle"
        Me.navigtemporelle.Size = New System.Drawing.Size(446, 45)
        Me.navigtemporelle.TabIndex = 0
        Me.navigtemporelle.Text06H = "06H"
        Me.navigtemporelle.Text09H = "09H"
        Me.navigtemporelle.Text12H = "12H"
        Me.navigtemporelle.Text15H = "15H"
        Me.navigtemporelle.Text18H = "18H"
        Me.navigtemporelle.Text20H = "20H"
        Me.navigtemporelle.Text23H = "23H"
        Me.navigtemporelle.TextHeureMoins = "Heure -1"
        Me.navigtemporelle.TextHeurePlus = "Heure +1"
        Me.navigtemporelle.TextJourMoins = "Jour -1"
        Me.navigtemporelle.TextJourPlus = "Jour +1"
        Me.navigtemporelle.TextMaintenant = "Maintenant"
        '
        'PanelB
        '
        Me.PanelB.BackColor = System.Drawing.Color.White
        Me.PanelB.Controls.Add(Me.ListViewChannel)
        Me.PanelB.Location = New System.Drawing.Point(20, 111)
        Me.PanelB.Name = "PanelB"
        Me.PanelB.Size = New System.Drawing.Size(48, 290)
        Me.PanelB.TabIndex = 54
        '
        'Panel_date
        '
        Me.Panel_date.BackColor = System.Drawing.Color.White
        Me.Panel_date.Location = New System.Drawing.Point(20, 59)
        Me.Panel_date.Name = "Panel_date"
        Me.Panel_date.Size = New System.Drawing.Size(48, 31)
        Me.Panel_date.TabIndex = 55
        '
        'PanelA
        '
        Me.PanelA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelA.Location = New System.Drawing.Point(96, 111)
        Me.PanelA.Name = "PanelA"
        Me.PanelA.Size = New System.Drawing.Size(596, 290)
        Me.PanelA.TabIndex = 56
        '
        'Panel_glob_maintenant
        '
        Me.Panel_glob_maintenant.BackColor = System.Drawing.Color.White
        Me.Panel_glob_maintenant.Controls.Add(Me.btImprimemaintenant)
        Me.Panel_glob_maintenant.Controls.Add(Me.lbl_titre_maintenant)
        Me.Panel_glob_maintenant.Controls.Add(Me.Panel_maintenant)
        Me.Panel_glob_maintenant.Location = New System.Drawing.Point(0, 402)
        Me.Panel_glob_maintenant.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel_glob_maintenant.Name = "Panel_glob_maintenant"
        Me.Panel_glob_maintenant.Size = New System.Drawing.Size(260, 238)
        Me.Panel_glob_maintenant.TabIndex = 58
        '
        'btImprimemaintenant
        '
        Me.btImprimemaintenant.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btImprimemaintenant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btImprimemaintenant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btImprimemaintenant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btImprimemaintenant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImprimemaintenant.Image = Global.ZGuideTV.My.Resources.Resources.PrintHS
        Me.btImprimemaintenant.Location = New System.Drawing.Point(205, 5)
        Me.btImprimemaintenant.Name = "btImprimemaintenant"
        Me.btImprimemaintenant.Size = New System.Drawing.Size(31, 23)
        Me.btImprimemaintenant.TabIndex = 6
        Me.btImprimemaintenant.UseVisualStyleBackColor = False
        '
        'lbl_titre_maintenant
        '
        Me.lbl_titre_maintenant.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.lbl_titre_maintenant.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_titre_maintenant.Location = New System.Drawing.Point(11, 11)
        Me.lbl_titre_maintenant.Name = "lbl_titre_maintenant"
        Me.lbl_titre_maintenant.Size = New System.Drawing.Size(239, 23)
        Me.lbl_titre_maintenant.TabIndex = 5
        Me.lbl_titre_maintenant.Text = "Actuellement"
        Me.lbl_titre_maintenant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel_maintenant
        '
        Me.Panel_maintenant.BackColor = System.Drawing.Color.White
        Me.Panel_maintenant.Location = New System.Drawing.Point(11, 37)
        Me.Panel_maintenant.Name = "Panel_maintenant"
        Me.Panel_maintenant.Size = New System.Drawing.Size(242, 188)
        Me.Panel_maintenant.TabIndex = 1
        '
        'Panel_glob_ce_soir
        '
        Me.Panel_glob_ce_soir.BackColor = System.Drawing.Color.White
        Me.Panel_glob_ce_soir.Controls.Add(Me.btImprimeCeSoir)
        Me.Panel_glob_ce_soir.Controls.Add(Me.lbl_Titre_Ce_Soir)
        Me.Panel_glob_ce_soir.Controls.Add(Me.Panel_ce_soir)
        Me.Panel_glob_ce_soir.Location = New System.Drawing.Point(4, 176)
        Me.Panel_glob_ce_soir.Name = "Panel_glob_ce_soir"
        Me.Panel_glob_ce_soir.Size = New System.Drawing.Size(260, 223)
        Me.Panel_glob_ce_soir.TabIndex = 59
        '
        'btImprimeCeSoir
        '
        Me.btImprimeCeSoir.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btImprimeCeSoir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btImprimeCeSoir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btImprimeCeSoir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btImprimeCeSoir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImprimeCeSoir.Image = Global.ZGuideTV.My.Resources.Resources.PrintHS
        Me.btImprimeCeSoir.Location = New System.Drawing.Point(205, 5)
        Me.btImprimeCeSoir.Name = "btImprimeCeSoir"
        Me.btImprimeCeSoir.Size = New System.Drawing.Size(31, 23)
        Me.btImprimeCeSoir.TabIndex = 5
        Me.btImprimeCeSoir.UseVisualStyleBackColor = False
        '
        'lbl_Titre_Ce_Soir
        '
        Me.lbl_Titre_Ce_Soir.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.lbl_Titre_Ce_Soir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Titre_Ce_Soir.Location = New System.Drawing.Point(10, 11)
        Me.lbl_Titre_Ce_Soir.Name = "lbl_Titre_Ce_Soir"
        Me.lbl_Titre_Ce_Soir.Size = New System.Drawing.Size(236, 23)
        Me.lbl_Titre_Ce_Soir.TabIndex = 4
        Me.lbl_Titre_Ce_Soir.Text = "Ce soir"
        Me.lbl_Titre_Ce_Soir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel_ce_soir
        '
        Me.Panel_ce_soir.BackColor = System.Drawing.Color.White
        Me.Panel_ce_soir.Location = New System.Drawing.Point(10, 37)
        Me.Panel_ce_soir.Name = "Panel_ce_soir"
        Me.Panel_ce_soir.Size = New System.Drawing.Size(246, 174)
        Me.Panel_ce_soir.TabIndex = 1
        '
        'Calendar
        '
        Me.Calendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Calendar.Controls.Add(Me.lblMoisS)
        Me.Calendar.Controls.Add(Me.lblMoisP)
        Me.Calendar.Controls.Add(Me.CalendarDimancheLabel)
        Me.Calendar.Controls.Add(Me.CalendarSamediLabel)
        Me.Calendar.Controls.Add(Me.CalendarVendrediLabel)
        Me.Calendar.Controls.Add(Me.CalendarJeudiLabel)
        Me.Calendar.Controls.Add(Me.CalendarMercrediLabel)
        Me.Calendar.Controls.Add(Me.CalendarMardiLabel)
        Me.Calendar.Controls.Add(Me.CalendarLundiLabel)
        Me.Calendar.Controls.Add(Me.Button5_3)
        Me.Calendar.Controls.Add(Me.Button6_7)
        Me.Calendar.Controls.Add(Me.Button5_2)
        Me.Calendar.Controls.Add(Me.Button3_2)
        Me.Calendar.Controls.Add(Me.Button5_7)
        Me.Calendar.Controls.Add(Me.Button5_1)
        Me.Calendar.Controls.Add(Me.Button6_1)
        Me.Calendar.Controls.Add(Me.L_MOIS_ANNEE)
        Me.Calendar.Controls.Add(Me.Button4_7)
        Me.Calendar.Controls.Add(Me.Button6_6)
        Me.Calendar.Controls.Add(Me.Button4_6)
        Me.Calendar.Controls.Add(Me.Button5_6)
        Me.Calendar.Controls.Add(Me.Button3_4)
        Me.Calendar.Controls.Add(Me.Button6_4)
        Me.Calendar.Controls.Add(Me.Button4_5)
        Me.Calendar.Controls.Add(Me.Button6_5)
        Me.Calendar.Controls.Add(Me.Button4_4)
        Me.Calendar.Controls.Add(Me.Button5_4)
        Me.Calendar.Controls.Add(Me.Button6_3)
        Me.Calendar.Controls.Add(Me.Button4_3)
        Me.Calendar.Controls.Add(Me.Button5_5)
        Me.Calendar.Controls.Add(Me.Button4_2)
        Me.Calendar.Controls.Add(Me.Button6_2)
        Me.Calendar.Controls.Add(Me.Button4_1)
        Me.Calendar.Controls.Add(Me.Button3_7)
        Me.Calendar.Controls.Add(Me.Button3_6)
        Me.Calendar.Controls.Add(Me.Button3_5)
        Me.Calendar.Controls.Add(Me.Button3_3)
        Me.Calendar.Controls.Add(Me.Button3_1)
        Me.Calendar.Controls.Add(Me.Button2_1)
        Me.Calendar.Controls.Add(Me.Button2_2)
        Me.Calendar.Controls.Add(Me.Button2_3)
        Me.Calendar.Controls.Add(Me.Button2_4)
        Me.Calendar.Controls.Add(Me.Button2_5)
        Me.Calendar.Controls.Add(Me.Button2_6)
        Me.Calendar.Controls.Add(Me.Button2_7)
        Me.Calendar.Controls.Add(Me.Button1_7)
        Me.Calendar.Controls.Add(Me.Button1_6)
        Me.Calendar.Controls.Add(Me.Button1_1)
        Me.Calendar.Controls.Add(Me.Button1_5)
        Me.Calendar.Controls.Add(Me.Button1_2)
        Me.Calendar.Controls.Add(Me.Button1_4)
        Me.Calendar.Controls.Add(Me.Button1_3)
        Me.Calendar.Location = New System.Drawing.Point(8, 0)
        Me.Calendar.Name = "Calendar"
        Me.Calendar.Size = New System.Drawing.Size(248, 170)
        Me.Calendar.TabIndex = 1
        '
        'lblMoisS
        '
        Me.lblMoisS.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.lblMoisS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMoisS.Location = New System.Drawing.Point(221, 3)
        Me.lblMoisS.Name = "lblMoisS"
        Me.lblMoisS.Size = New System.Drawing.Size(24, 17)
        Me.lblMoisS.TabIndex = 104
        Me.lblMoisS.Text = ">"
        Me.lblMoisS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMoisP
        '
        Me.lblMoisP.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.lblMoisP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMoisP.Location = New System.Drawing.Point(3, 3)
        Me.lblMoisP.Name = "lblMoisP"
        Me.lblMoisP.Size = New System.Drawing.Size(24, 17)
        Me.lblMoisP.TabIndex = 103
        Me.lblMoisP.Text = "<"
        Me.lblMoisP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalendarDimancheLabel
        '
        Me.CalendarDimancheLabel.BackColor = System.Drawing.Color.Transparent
        Me.CalendarDimancheLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CalendarDimancheLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarDimancheLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CalendarDimancheLabel.Location = New System.Drawing.Point(203, 22)
        Me.CalendarDimancheLabel.Name = "CalendarDimancheLabel"
        Me.CalendarDimancheLabel.Size = New System.Drawing.Size(32, 20)
        Me.CalendarDimancheLabel.TabIndex = 102
        Me.CalendarDimancheLabel.Text = "Dim."
        Me.CalendarDimancheLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalendarSamediLabel
        '
        Me.CalendarSamediLabel.BackColor = System.Drawing.Color.Transparent
        Me.CalendarSamediLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CalendarSamediLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarSamediLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CalendarSamediLabel.Location = New System.Drawing.Point(172, 22)
        Me.CalendarSamediLabel.Name = "CalendarSamediLabel"
        Me.CalendarSamediLabel.Size = New System.Drawing.Size(32, 20)
        Me.CalendarSamediLabel.TabIndex = 101
        Me.CalendarSamediLabel.Text = "Sam."
        Me.CalendarSamediLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalendarVendrediLabel
        '
        Me.CalendarVendrediLabel.BackColor = System.Drawing.Color.Transparent
        Me.CalendarVendrediLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CalendarVendrediLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarVendrediLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CalendarVendrediLabel.Location = New System.Drawing.Point(140, 22)
        Me.CalendarVendrediLabel.Name = "CalendarVendrediLabel"
        Me.CalendarVendrediLabel.Size = New System.Drawing.Size(32, 20)
        Me.CalendarVendrediLabel.TabIndex = 100
        Me.CalendarVendrediLabel.Text = "Ven."
        Me.CalendarVendrediLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalendarJeudiLabel
        '
        Me.CalendarJeudiLabel.BackColor = System.Drawing.Color.Transparent
        Me.CalendarJeudiLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CalendarJeudiLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarJeudiLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CalendarJeudiLabel.Location = New System.Drawing.Point(109, 22)
        Me.CalendarJeudiLabel.Name = "CalendarJeudiLabel"
        Me.CalendarJeudiLabel.Size = New System.Drawing.Size(32, 20)
        Me.CalendarJeudiLabel.TabIndex = 99
        Me.CalendarJeudiLabel.Text = "Jeu."
        Me.CalendarJeudiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalendarMercrediLabel
        '
        Me.CalendarMercrediLabel.BackColor = System.Drawing.Color.Transparent
        Me.CalendarMercrediLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CalendarMercrediLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarMercrediLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CalendarMercrediLabel.Location = New System.Drawing.Point(78, 22)
        Me.CalendarMercrediLabel.Name = "CalendarMercrediLabel"
        Me.CalendarMercrediLabel.Size = New System.Drawing.Size(33, 20)
        Me.CalendarMercrediLabel.TabIndex = 98
        Me.CalendarMercrediLabel.Text = "Mer."
        Me.CalendarMercrediLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalendarMardiLabel
        '
        Me.CalendarMardiLabel.BackColor = System.Drawing.Color.Transparent
        Me.CalendarMardiLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CalendarMardiLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarMardiLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CalendarMardiLabel.Location = New System.Drawing.Point(46, 22)
        Me.CalendarMardiLabel.Name = "CalendarMardiLabel"
        Me.CalendarMardiLabel.Size = New System.Drawing.Size(32, 20)
        Me.CalendarMardiLabel.TabIndex = 97
        Me.CalendarMardiLabel.Text = "Mar."
        Me.CalendarMardiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CalendarLundiLabel
        '
        Me.CalendarLundiLabel.BackColor = System.Drawing.Color.Transparent
        Me.CalendarLundiLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CalendarLundiLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarLundiLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CalendarLundiLabel.Location = New System.Drawing.Point(14, 22)
        Me.CalendarLundiLabel.Name = "CalendarLundiLabel"
        Me.CalendarLundiLabel.Size = New System.Drawing.Size(32, 20)
        Me.CalendarLundiLabel.TabIndex = 96
        Me.CalendarLundiLabel.Text = "Lun."
        Me.CalendarLundiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button5_3
        '
        Me.Button5_3.Align = System.Drawing.StringAlignment.Center
        Me.Button5_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_3.BgColor = System.Drawing.Color.Black
        Me.Button5_3.BordersColor = System.Drawing.Color.White
        Me.Button5_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_3.ForeColor = System.Drawing.Color.White
        Me.Button5_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_3.Location = New System.Drawing.Point(80, 120)
        Me.Button5_3.Name = "Button5_3"
        Me.Button5_3.Size = New System.Drawing.Size(28, 18)
        Me.Button5_3.TabIndex = 81
        Me.Button5_3.TopColor = System.Drawing.Color.White
        '
        'Button6_7
        '
        Me.Button6_7.Align = System.Drawing.StringAlignment.Center
        Me.Button6_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_7.BgColor = System.Drawing.Color.Black
        Me.Button6_7.BordersColor = System.Drawing.Color.White
        Me.Button6_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_7.ForeColor = System.Drawing.Color.White
        Me.Button6_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_7.Location = New System.Drawing.Point(204, 139)
        Me.Button6_7.Name = "Button6_7"
        Me.Button6_7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_7.Size = New System.Drawing.Size(28, 18)
        Me.Button6_7.TabIndex = 95
        Me.Button6_7.TopColor = System.Drawing.Color.White
        '
        'Button5_2
        '
        Me.Button5_2.Align = System.Drawing.StringAlignment.Center
        Me.Button5_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_2.BgColor = System.Drawing.Color.Black
        Me.Button5_2.BordersColor = System.Drawing.Color.White
        Me.Button5_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_2.ForeColor = System.Drawing.Color.White
        Me.Button5_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_2.Location = New System.Drawing.Point(49, 120)
        Me.Button5_2.Name = "Button5_2"
        Me.Button5_2.Size = New System.Drawing.Size(28, 18)
        Me.Button5_2.TabIndex = 80
        Me.Button5_2.TopColor = System.Drawing.Color.White
        '
        'Button3_2
        '
        Me.Button3_2.Align = System.Drawing.StringAlignment.Center
        Me.Button3_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_2.BgColor = System.Drawing.Color.Black
        Me.Button3_2.BordersColor = System.Drawing.Color.White
        Me.Button3_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_2.ForeColor = System.Drawing.Color.White
        Me.Button3_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_2.Location = New System.Drawing.Point(49, 82)
        Me.Button3_2.Name = "Button3_2"
        Me.Button3_2.Size = New System.Drawing.Size(28, 18)
        Me.Button3_2.TabIndex = 66
        Me.Button3_2.TopColor = System.Drawing.Color.White
        '
        'Button5_7
        '
        Me.Button5_7.Align = System.Drawing.StringAlignment.Center
        Me.Button5_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_7.BgColor = System.Drawing.Color.Black
        Me.Button5_7.BordersColor = System.Drawing.Color.White
        Me.Button5_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_7.ForeColor = System.Drawing.Color.White
        Me.Button5_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_7.Location = New System.Drawing.Point(204, 120)
        Me.Button5_7.Name = "Button5_7"
        Me.Button5_7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button5_7.Size = New System.Drawing.Size(28, 18)
        Me.Button5_7.TabIndex = 88
        Me.Button5_7.TopColor = System.Drawing.Color.White
        '
        'Button5_1
        '
        Me.Button5_1.Align = System.Drawing.StringAlignment.Center
        Me.Button5_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_1.BgColor = System.Drawing.Color.Black
        Me.Button5_1.BordersColor = System.Drawing.Color.White
        Me.Button5_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_1.ForeColor = System.Drawing.Color.White
        Me.Button5_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_1.Location = New System.Drawing.Point(18, 120)
        Me.Button5_1.Name = "Button5_1"
        Me.Button5_1.Size = New System.Drawing.Size(28, 18)
        Me.Button5_1.TabIndex = 79
        Me.Button5_1.TopColor = System.Drawing.Color.White
        '
        'Button6_1
        '
        Me.Button6_1.Align = System.Drawing.StringAlignment.Center
        Me.Button6_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_1.BgColor = System.Drawing.Color.Black
        Me.Button6_1.BordersColor = System.Drawing.Color.White
        Me.Button6_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_1.ForeColor = System.Drawing.Color.White
        Me.Button6_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_1.Location = New System.Drawing.Point(18, 139)
        Me.Button6_1.Name = "Button6_1"
        Me.Button6_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_1.Size = New System.Drawing.Size(28, 18)
        Me.Button6_1.TabIndex = 90
        Me.Button6_1.TopColor = System.Drawing.Color.White
        '
        'L_MOIS_ANNEE
        '
        Me.L_MOIS_ANNEE.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.L_MOIS_ANNEE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_MOIS_ANNEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.L_MOIS_ANNEE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.L_MOIS_ANNEE.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_MOIS_ANNEE.Location = New System.Drawing.Point(33, 3)
        Me.L_MOIS_ANNEE.Name = "L_MOIS_ANNEE"
        Me.L_MOIS_ANNEE.Size = New System.Drawing.Size(183, 17)
        Me.L_MOIS_ANNEE.TabIndex = 82
        Me.L_MOIS_ANNEE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4_7
        '
        Me.Button4_7.Align = System.Drawing.StringAlignment.Center
        Me.Button4_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_7.BgColor = System.Drawing.Color.Black
        Me.Button4_7.BordersColor = System.Drawing.Color.White
        Me.Button4_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_7.ForeColor = System.Drawing.Color.White
        Me.Button4_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_7.Location = New System.Drawing.Point(204, 101)
        Me.Button4_7.Name = "Button4_7"
        Me.Button4_7.Size = New System.Drawing.Size(28, 18)
        Me.Button4_7.TabIndex = 78
        Me.Button4_7.TopColor = System.Drawing.Color.White
        '
        'Button6_6
        '
        Me.Button6_6.Align = System.Drawing.StringAlignment.Center
        Me.Button6_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_6.BgColor = System.Drawing.Color.Black
        Me.Button6_6.BordersColor = System.Drawing.Color.White
        Me.Button6_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_6.ForeColor = System.Drawing.Color.White
        Me.Button6_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_6.Location = New System.Drawing.Point(173, 139)
        Me.Button6_6.Name = "Button6_6"
        Me.Button6_6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_6.Size = New System.Drawing.Size(28, 18)
        Me.Button6_6.TabIndex = 94
        Me.Button6_6.TopColor = System.Drawing.Color.White
        '
        'Button4_6
        '
        Me.Button4_6.Align = System.Drawing.StringAlignment.Center
        Me.Button4_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_6.BgColor = System.Drawing.Color.Black
        Me.Button4_6.BordersColor = System.Drawing.Color.White
        Me.Button4_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_6.ForeColor = System.Drawing.Color.White
        Me.Button4_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_6.Location = New System.Drawing.Point(173, 101)
        Me.Button4_6.Name = "Button4_6"
        Me.Button4_6.Size = New System.Drawing.Size(28, 18)
        Me.Button4_6.TabIndex = 77
        Me.Button4_6.TopColor = System.Drawing.Color.White
        '
        'Button5_6
        '
        Me.Button5_6.Align = System.Drawing.StringAlignment.Center
        Me.Button5_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_6.BgColor = System.Drawing.Color.Black
        Me.Button5_6.BordersColor = System.Drawing.Color.White
        Me.Button5_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_6.ForeColor = System.Drawing.Color.White
        Me.Button5_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_6.Location = New System.Drawing.Point(173, 120)
        Me.Button5_6.Name = "Button5_6"
        Me.Button5_6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button5_6.Size = New System.Drawing.Size(28, 18)
        Me.Button5_6.TabIndex = 87
        Me.Button5_6.TopColor = System.Drawing.Color.White
        '
        'Button3_4
        '
        Me.Button3_4.Align = System.Drawing.StringAlignment.Center
        Me.Button3_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_4.BgColor = System.Drawing.Color.Black
        Me.Button3_4.BordersColor = System.Drawing.Color.White
        Me.Button3_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_4.ForeColor = System.Drawing.Color.White
        Me.Button3_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_4.Location = New System.Drawing.Point(111, 82)
        Me.Button3_4.Name = "Button3_4"
        Me.Button3_4.Size = New System.Drawing.Size(28, 18)
        Me.Button3_4.TabIndex = 85
        Me.Button3_4.TopColor = System.Drawing.Color.White
        '
        'Button6_4
        '
        Me.Button6_4.Align = System.Drawing.StringAlignment.Center
        Me.Button6_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_4.BgColor = System.Drawing.Color.Black
        Me.Button6_4.BordersColor = System.Drawing.Color.White
        Me.Button6_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_4.ForeColor = System.Drawing.Color.White
        Me.Button6_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_4.Location = New System.Drawing.Point(111, 139)
        Me.Button6_4.Name = "Button6_4"
        Me.Button6_4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_4.Size = New System.Drawing.Size(28, 18)
        Me.Button6_4.TabIndex = 93
        Me.Button6_4.TopColor = System.Drawing.Color.White
        '
        'Button4_5
        '
        Me.Button4_5.Align = System.Drawing.StringAlignment.Center
        Me.Button4_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_5.BgColor = System.Drawing.Color.Black
        Me.Button4_5.BordersColor = System.Drawing.Color.White
        Me.Button4_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_5.ForeColor = System.Drawing.Color.White
        Me.Button4_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_5.Location = New System.Drawing.Point(142, 101)
        Me.Button4_5.Name = "Button4_5"
        Me.Button4_5.Size = New System.Drawing.Size(28, 18)
        Me.Button4_5.TabIndex = 76
        Me.Button4_5.TopColor = System.Drawing.Color.White
        '
        'Button6_5
        '
        Me.Button6_5.Align = System.Drawing.StringAlignment.Center
        Me.Button6_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_5.BgColor = System.Drawing.Color.Black
        Me.Button6_5.BordersColor = System.Drawing.Color.White
        Me.Button6_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_5.ForeColor = System.Drawing.Color.White
        Me.Button6_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_5.Location = New System.Drawing.Point(142, 139)
        Me.Button6_5.Name = "Button6_5"
        Me.Button6_5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_5.Size = New System.Drawing.Size(28, 18)
        Me.Button6_5.TabIndex = 89
        Me.Button6_5.TopColor = System.Drawing.Color.White
        '
        'Button4_4
        '
        Me.Button4_4.Align = System.Drawing.StringAlignment.Center
        Me.Button4_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_4.BgColor = System.Drawing.Color.Black
        Me.Button4_4.BordersColor = System.Drawing.Color.White
        Me.Button4_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_4.ForeColor = System.Drawing.Color.White
        Me.Button4_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_4.Location = New System.Drawing.Point(111, 101)
        Me.Button4_4.Name = "Button4_4"
        Me.Button4_4.Size = New System.Drawing.Size(28, 18)
        Me.Button4_4.TabIndex = 75
        Me.Button4_4.TopColor = System.Drawing.Color.White
        '
        'Button5_4
        '
        Me.Button5_4.Align = System.Drawing.StringAlignment.Center
        Me.Button5_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_4.BgColor = System.Drawing.Color.Black
        Me.Button5_4.BordersColor = System.Drawing.Color.White
        Me.Button5_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_4.ForeColor = System.Drawing.Color.White
        Me.Button5_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_4.Location = New System.Drawing.Point(111, 120)
        Me.Button5_4.Name = "Button5_4"
        Me.Button5_4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button5_4.Size = New System.Drawing.Size(28, 18)
        Me.Button5_4.TabIndex = 84
        Me.Button5_4.TopColor = System.Drawing.Color.White
        '
        'Button6_3
        '
        Me.Button6_3.Align = System.Drawing.StringAlignment.Center
        Me.Button6_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_3.BgColor = System.Drawing.Color.Black
        Me.Button6_3.BordersColor = System.Drawing.Color.White
        Me.Button6_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_3.ForeColor = System.Drawing.Color.White
        Me.Button6_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_3.Location = New System.Drawing.Point(80, 139)
        Me.Button6_3.Name = "Button6_3"
        Me.Button6_3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_3.Size = New System.Drawing.Size(28, 18)
        Me.Button6_3.TabIndex = 92
        Me.Button6_3.TopColor = System.Drawing.Color.White
        '
        'Button4_3
        '
        Me.Button4_3.Align = System.Drawing.StringAlignment.Center
        Me.Button4_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_3.BgColor = System.Drawing.Color.Black
        Me.Button4_3.BordersColor = System.Drawing.Color.White
        Me.Button4_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_3.ForeColor = System.Drawing.Color.White
        Me.Button4_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_3.Location = New System.Drawing.Point(80, 101)
        Me.Button4_3.Name = "Button4_3"
        Me.Button4_3.Size = New System.Drawing.Size(28, 18)
        Me.Button4_3.TabIndex = 74
        Me.Button4_3.TopColor = System.Drawing.Color.White
        '
        'Button5_5
        '
        Me.Button5_5.Align = System.Drawing.StringAlignment.Center
        Me.Button5_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_5.BgColor = System.Drawing.Color.Black
        Me.Button5_5.BordersColor = System.Drawing.Color.White
        Me.Button5_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_5.ForeColor = System.Drawing.Color.White
        Me.Button5_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_5.Location = New System.Drawing.Point(142, 120)
        Me.Button5_5.Name = "Button5_5"
        Me.Button5_5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button5_5.Size = New System.Drawing.Size(28, 18)
        Me.Button5_5.TabIndex = 67
        Me.Button5_5.TopColor = System.Drawing.Color.White
        '
        'Button4_2
        '
        Me.Button4_2.Align = System.Drawing.StringAlignment.Center
        Me.Button4_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_2.BgColor = System.Drawing.Color.Black
        Me.Button4_2.BordersColor = System.Drawing.Color.White
        Me.Button4_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_2.ForeColor = System.Drawing.Color.White
        Me.Button4_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_2.Location = New System.Drawing.Point(49, 101)
        Me.Button4_2.Name = "Button4_2"
        Me.Button4_2.Size = New System.Drawing.Size(28, 18)
        Me.Button4_2.TabIndex = 73
        Me.Button4_2.TopColor = System.Drawing.Color.White
        '
        'Button6_2
        '
        Me.Button6_2.Align = System.Drawing.StringAlignment.Center
        Me.Button6_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_2.BgColor = System.Drawing.Color.Black
        Me.Button6_2.BordersColor = System.Drawing.Color.White
        Me.Button6_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_2.ForeColor = System.Drawing.Color.White
        Me.Button6_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_2.Location = New System.Drawing.Point(49, 139)
        Me.Button6_2.Name = "Button6_2"
        Me.Button6_2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_2.Size = New System.Drawing.Size(28, 18)
        Me.Button6_2.TabIndex = 91
        Me.Button6_2.TopColor = System.Drawing.Color.White
        '
        'Button4_1
        '
        Me.Button4_1.Align = System.Drawing.StringAlignment.Center
        Me.Button4_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_1.BgColor = System.Drawing.Color.Black
        Me.Button4_1.BordersColor = System.Drawing.Color.White
        Me.Button4_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_1.ForeColor = System.Drawing.Color.White
        Me.Button4_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_1.Location = New System.Drawing.Point(18, 101)
        Me.Button4_1.Name = "Button4_1"
        Me.Button4_1.Size = New System.Drawing.Size(28, 18)
        Me.Button4_1.TabIndex = 72
        Me.Button4_1.TopColor = System.Drawing.Color.White
        '
        'Button3_7
        '
        Me.Button3_7.Align = System.Drawing.StringAlignment.Center
        Me.Button3_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_7.BgColor = System.Drawing.Color.Black
        Me.Button3_7.BordersColor = System.Drawing.Color.White
        Me.Button3_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_7.ForeColor = System.Drawing.Color.White
        Me.Button3_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_7.Location = New System.Drawing.Point(204, 82)
        Me.Button3_7.Name = "Button3_7"
        Me.Button3_7.Size = New System.Drawing.Size(28, 18)
        Me.Button3_7.TabIndex = 71
        Me.Button3_7.TopColor = System.Drawing.Color.White
        '
        'Button3_6
        '
        Me.Button3_6.Align = System.Drawing.StringAlignment.Center
        Me.Button3_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_6.BgColor = System.Drawing.Color.Black
        Me.Button3_6.BordersColor = System.Drawing.Color.White
        Me.Button3_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_6.ForeColor = System.Drawing.Color.White
        Me.Button3_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_6.Location = New System.Drawing.Point(173, 82)
        Me.Button3_6.Name = "Button3_6"
        Me.Button3_6.Size = New System.Drawing.Size(28, 18)
        Me.Button3_6.TabIndex = 70
        Me.Button3_6.TopColor = System.Drawing.Color.White
        '
        'Button3_5
        '
        Me.Button3_5.Align = System.Drawing.StringAlignment.Center
        Me.Button3_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_5.BgColor = System.Drawing.Color.Black
        Me.Button3_5.BordersColor = System.Drawing.Color.White
        Me.Button3_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_5.ForeColor = System.Drawing.Color.White
        Me.Button3_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_5.Location = New System.Drawing.Point(142, 82)
        Me.Button3_5.Name = "Button3_5"
        Me.Button3_5.Size = New System.Drawing.Size(28, 18)
        Me.Button3_5.TabIndex = 69
        Me.Button3_5.TopColor = System.Drawing.Color.White
        '
        'Button3_3
        '
        Me.Button3_3.Align = System.Drawing.StringAlignment.Center
        Me.Button3_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_3.BgColor = System.Drawing.Color.Black
        Me.Button3_3.BordersColor = System.Drawing.Color.White
        Me.Button3_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_3.ForeColor = System.Drawing.Color.White
        Me.Button3_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_3.Location = New System.Drawing.Point(80, 82)
        Me.Button3_3.Name = "Button3_3"
        Me.Button3_3.Size = New System.Drawing.Size(28, 18)
        Me.Button3_3.TabIndex = 68
        Me.Button3_3.TopColor = System.Drawing.Color.White
        '
        'Button3_1
        '
        Me.Button3_1.Align = System.Drawing.StringAlignment.Center
        Me.Button3_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_1.BgColor = System.Drawing.Color.Black
        Me.Button3_1.BordersColor = System.Drawing.Color.White
        Me.Button3_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_1.ForeColor = System.Drawing.Color.White
        Me.Button3_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_1.Location = New System.Drawing.Point(18, 82)
        Me.Button3_1.Name = "Button3_1"
        Me.Button3_1.Size = New System.Drawing.Size(28, 18)
        Me.Button3_1.TabIndex = 65
        Me.Button3_1.TopColor = System.Drawing.Color.White
        '
        'Button2_1
        '
        Me.Button2_1.Align = System.Drawing.StringAlignment.Center
        Me.Button2_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_1.BgColor = System.Drawing.Color.Black
        Me.Button2_1.BordersColor = System.Drawing.Color.White
        Me.Button2_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_1.ForeColor = System.Drawing.Color.White
        Me.Button2_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_1.Location = New System.Drawing.Point(18, 63)
        Me.Button2_1.Name = "Button2_1"
        Me.Button2_1.Size = New System.Drawing.Size(28, 18)
        Me.Button2_1.TabIndex = 64
        Me.Button2_1.TopColor = System.Drawing.Color.White
        '
        'Button2_2
        '
        Me.Button2_2.Align = System.Drawing.StringAlignment.Center
        Me.Button2_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_2.BgColor = System.Drawing.Color.Black
        Me.Button2_2.BordersColor = System.Drawing.Color.White
        Me.Button2_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_2.ForeColor = System.Drawing.Color.White
        Me.Button2_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_2.Location = New System.Drawing.Point(49, 63)
        Me.Button2_2.Name = "Button2_2"
        Me.Button2_2.Size = New System.Drawing.Size(28, 18)
        Me.Button2_2.TabIndex = 63
        Me.Button2_2.TopColor = System.Drawing.Color.White
        '
        'Button2_3
        '
        Me.Button2_3.Align = System.Drawing.StringAlignment.Center
        Me.Button2_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_3.BgColor = System.Drawing.Color.Black
        Me.Button2_3.BordersColor = System.Drawing.Color.White
        Me.Button2_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_3.ForeColor = System.Drawing.Color.White
        Me.Button2_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_3.Location = New System.Drawing.Point(80, 63)
        Me.Button2_3.Name = "Button2_3"
        Me.Button2_3.Size = New System.Drawing.Size(28, 18)
        Me.Button2_3.TabIndex = 58
        Me.Button2_3.TopColor = System.Drawing.Color.White
        '
        'Button2_4
        '
        Me.Button2_4.Align = System.Drawing.StringAlignment.Center
        Me.Button2_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_4.BgColor = System.Drawing.Color.Black
        Me.Button2_4.BordersColor = System.Drawing.Color.White
        Me.Button2_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_4.ForeColor = System.Drawing.Color.White
        Me.Button2_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_4.Location = New System.Drawing.Point(111, 63)
        Me.Button2_4.Name = "Button2_4"
        Me.Button2_4.Size = New System.Drawing.Size(28, 18)
        Me.Button2_4.TabIndex = 62
        Me.Button2_4.TopColor = System.Drawing.Color.White
        '
        'Button2_5
        '
        Me.Button2_5.Align = System.Drawing.StringAlignment.Center
        Me.Button2_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_5.BgColor = System.Drawing.Color.Black
        Me.Button2_5.BordersColor = System.Drawing.Color.White
        Me.Button2_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_5.ForeColor = System.Drawing.Color.White
        Me.Button2_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_5.Location = New System.Drawing.Point(142, 63)
        Me.Button2_5.Name = "Button2_5"
        Me.Button2_5.Size = New System.Drawing.Size(28, 18)
        Me.Button2_5.TabIndex = 59
        Me.Button2_5.TopColor = System.Drawing.Color.White
        '
        'Button2_6
        '
        Me.Button2_6.Align = System.Drawing.StringAlignment.Center
        Me.Button2_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_6.BgColor = System.Drawing.Color.Black
        Me.Button2_6.BordersColor = System.Drawing.Color.White
        Me.Button2_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_6.ForeColor = System.Drawing.Color.White
        Me.Button2_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_6.Location = New System.Drawing.Point(173, 63)
        Me.Button2_6.Name = "Button2_6"
        Me.Button2_6.Size = New System.Drawing.Size(28, 18)
        Me.Button2_6.TabIndex = 61
        Me.Button2_6.TopColor = System.Drawing.Color.White
        '
        'Button2_7
        '
        Me.Button2_7.Align = System.Drawing.StringAlignment.Center
        Me.Button2_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_7.BgColor = System.Drawing.Color.Black
        Me.Button2_7.BordersColor = System.Drawing.Color.White
        Me.Button2_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_7.ForeColor = System.Drawing.Color.White
        Me.Button2_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_7.Location = New System.Drawing.Point(204, 63)
        Me.Button2_7.Name = "Button2_7"
        Me.Button2_7.Size = New System.Drawing.Size(28, 18)
        Me.Button2_7.TabIndex = 60
        Me.Button2_7.TopColor = System.Drawing.Color.White
        '
        'Button1_7
        '
        Me.Button1_7.Align = System.Drawing.StringAlignment.Center
        Me.Button1_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_7.BgColor = System.Drawing.Color.Black
        Me.Button1_7.BordersColor = System.Drawing.Color.White
        Me.Button1_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_7.ForeColor = System.Drawing.Color.White
        Me.Button1_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_7.Location = New System.Drawing.Point(204, 44)
        Me.Button1_7.Name = "Button1_7"
        Me.Button1_7.Size = New System.Drawing.Size(28, 18)
        Me.Button1_7.TabIndex = 57
        Me.Button1_7.TopColor = System.Drawing.Color.White
        '
        'Button1_6
        '
        Me.Button1_6.Align = System.Drawing.StringAlignment.Center
        Me.Button1_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_6.BgColor = System.Drawing.Color.Black
        Me.Button1_6.BordersColor = System.Drawing.Color.White
        Me.Button1_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_6.ForeColor = System.Drawing.Color.White
        Me.Button1_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_6.Location = New System.Drawing.Point(173, 44)
        Me.Button1_6.Name = "Button1_6"
        Me.Button1_6.Size = New System.Drawing.Size(28, 18)
        Me.Button1_6.TabIndex = 56
        Me.Button1_6.TopColor = System.Drawing.Color.White
        '
        'Button1_1
        '
        Me.Button1_1.Align = System.Drawing.StringAlignment.Center
        Me.Button1_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_1.BgColor = System.Drawing.Color.Black
        Me.Button1_1.BordersColor = System.Drawing.Color.White
        Me.Button1_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_1.ForeColor = System.Drawing.Color.White
        Me.Button1_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_1.Location = New System.Drawing.Point(18, 44)
        Me.Button1_1.Name = "Button1_1"
        Me.Button1_1.Size = New System.Drawing.Size(28, 18)
        Me.Button1_1.TabIndex = 51
        Me.Button1_1.TopColor = System.Drawing.Color.White
        '
        'Button1_5
        '
        Me.Button1_5.Align = System.Drawing.StringAlignment.Center
        Me.Button1_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_5.BgColor = System.Drawing.Color.Black
        Me.Button1_5.BordersColor = System.Drawing.Color.White
        Me.Button1_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_5.ForeColor = System.Drawing.Color.White
        Me.Button1_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_5.Location = New System.Drawing.Point(142, 44)
        Me.Button1_5.Name = "Button1_5"
        Me.Button1_5.Size = New System.Drawing.Size(28, 18)
        Me.Button1_5.TabIndex = 55
        Me.Button1_5.TopColor = System.Drawing.Color.White
        '
        'Button1_2
        '
        Me.Button1_2.Align = System.Drawing.StringAlignment.Center
        Me.Button1_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_2.BgColor = System.Drawing.Color.Black
        Me.Button1_2.BordersColor = System.Drawing.Color.White
        Me.Button1_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_2.ForeColor = System.Drawing.Color.White
        Me.Button1_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_2.Location = New System.Drawing.Point(49, 44)
        Me.Button1_2.Name = "Button1_2"
        Me.Button1_2.Size = New System.Drawing.Size(28, 18)
        Me.Button1_2.TabIndex = 52
        Me.Button1_2.TopColor = System.Drawing.Color.White
        '
        'Button1_4
        '
        Me.Button1_4.Align = System.Drawing.StringAlignment.Center
        Me.Button1_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_4.BgColor = System.Drawing.Color.Black
        Me.Button1_4.BordersColor = System.Drawing.Color.White
        Me.Button1_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_4.ForeColor = System.Drawing.Color.White
        Me.Button1_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_4.Location = New System.Drawing.Point(111, 44)
        Me.Button1_4.Name = "Button1_4"
        Me.Button1_4.Size = New System.Drawing.Size(28, 18)
        Me.Button1_4.TabIndex = 54
        Me.Button1_4.TopColor = System.Drawing.Color.White
        '
        'Button1_3
        '
        Me.Button1_3.Align = System.Drawing.StringAlignment.Center
        Me.Button1_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_3.BgColor = System.Drawing.Color.Black
        Me.Button1_3.BordersColor = System.Drawing.Color.White
        Me.Button1_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_3.ForeColor = System.Drawing.Color.White
        Me.Button1_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_3.Location = New System.Drawing.Point(80, 44)
        Me.Button1_3.Name = "Button1_3"
        Me.Button1_3.Size = New System.Drawing.Size(28, 18)
        Me.Button1_3.TabIndex = 53
        Me.Button1_3.TopColor = System.Drawing.Color.White
        '
        'ouvrirbasededonnees
        '
        Me.ouvrirbasededonnees.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ouvrirbasededonnees.Image = CType(resources.GetObject("ouvrirbasededonnees.Image"), System.Drawing.Image)
        Me.ouvrirbasededonnees.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ouvrirbasededonnees.Name = "ouvrirbasededonnees"
        Me.ouvrirbasededonnees.Size = New System.Drawing.Size(23, 22)
        Me.ouvrirbasededonnees.Text = "ToolStripButton1"
        Me.ouvrirbasededonnees.ToolTipText = "Ouvrir une base de données"
        '
        'sauvegardebasededonnees
        '
        Me.sauvegardebasededonnees.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sauvegardebasededonnees.Image = CType(resources.GetObject("sauvegardebasededonnees.Image"), System.Drawing.Image)
        Me.sauvegardebasededonnees.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sauvegardebasededonnees.Name = "sauvegardebasededonnees"
        Me.sauvegardebasededonnees.Size = New System.Drawing.Size(23, 22)
        Me.sauvegardebasededonnees.Text = "ToolStripButton2"
        Me.sauvegardebasededonnees.ToolTipText = "Sauver la base de données"
        '
        'copierladescriptionselectionnee
        '
        Me.copierladescriptionselectionnee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.copierladescriptionselectionnee.Image = CType(resources.GetObject("copierladescriptionselectionnee.Image"), System.Drawing.Image)
        Me.copierladescriptionselectionnee.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.copierladescriptionselectionnee.Name = "copierladescriptionselectionnee"
        Me.copierladescriptionselectionnee.Size = New System.Drawing.Size(23, 22)
        Me.copierladescriptionselectionnee.Text = "ToolStripButton3"
        Me.copierladescriptionselectionnee.ToolTipText = "Copier la description sélectionnée"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Copier toute la description"
        '
        'Preview
        '
        Me.Preview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Preview.Image = CType(resources.GetObject("Preview.Image"), System.Drawing.Image)
        Me.Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(23, 22)
        Me.Preview.ToolTipText = "Aperçu avant impression"
        '
        'Print
        '
        Me.Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Print.Image = CType(resources.GetObject("Print.Image"), System.Drawing.Image)
        Me.Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Print.Name = "Print"
        Me.Print.Size = New System.Drawing.Size(23, 22)
        Me.Print.Text = "ToolStripButton2"
        Me.Print.ToolTipText = "Imprimer la description"
        '
        'rechercheavancee
        '
        Me.rechercheavancee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.rechercheavancee.Image = CType(resources.GetObject("rechercheavancee.Image"), System.Drawing.Image)
        Me.rechercheavancee.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.rechercheavancee.Name = "rechercheavancee"
        Me.rechercheavancee.Size = New System.Drawing.Size(23, 22)
        Me.rechercheavancee.Text = "ToolStripButton4"
        Me.rechercheavancee.ToolTipText = "Recherche avancée"
        '
        'toujoursenavantplan
        '
        Me.toujoursenavantplan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toujoursenavantplan.Image = CType(resources.GetObject("toujoursenavantplan.Image"), System.Drawing.Image)
        Me.toujoursenavantplan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toujoursenavantplan.Name = "toujoursenavantplan"
        Me.toujoursenavantplan.Size = New System.Drawing.Size(23, 22)
        Me.toujoursenavantplan.Text = "ToolStripButton5"
        Me.toujoursenavantplan.ToolTipText = "Toujours en avant plan"
        '
        'préférences
        '
        Me.préférences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.préférences.Image = CType(resources.GetObject("préférences.Image"), System.Drawing.Image)
        Me.préférences.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.préférences.Name = "préférences"
        Me.préférences.Size = New System.Drawing.Size(23, 22)
        Me.préférences.Text = "ToolStripButton6"
        Me.préférences.ToolTipText = "Préférences"
        '
        'miseajourdeschaines
        '
        Me.miseajourdeschaines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.miseajourdeschaines.Image = CType(resources.GetObject("miseajourdeschaines.Image"), System.Drawing.Image)
        Me.miseajourdeschaines.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.miseajourdeschaines.Name = "miseajourdeschaines"
        Me.miseajourdeschaines.Size = New System.Drawing.Size(23, 22)
        Me.miseajourdeschaines.Text = "ToolStripButton7"
        Me.miseajourdeschaines.ToolTipText = "Mise à jour des chaines"
        '
        'ajoutermodifierlogo
        '
        Me.ajoutermodifierlogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ajoutermodifierlogo.Image = CType(resources.GetObject("ajoutermodifierlogo.Image"), System.Drawing.Image)
        Me.ajoutermodifierlogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ajoutermodifierlogo.Name = "ajoutermodifierlogo"
        Me.ajoutermodifierlogo.Size = New System.Drawing.Size(23, 22)
        Me.ajoutermodifierlogo.Text = "ToolStripButton8"
        Me.ajoutermodifierlogo.ToolTipText = "Ajouter/Modifier Logo"
        '
        'aidezguidetv
        '
        Me.aidezguidetv.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.aidezguidetv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.aidezguidetv.Image = CType(resources.GetObject("aidezguidetv.Image"), System.Drawing.Image)
        Me.aidezguidetv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.aidezguidetv.Name = "aidezguidetv"
        Me.aidezguidetv.Size = New System.Drawing.Size(23, 22)
        Me.aidezguidetv.Text = "ToolStripButton12"
        Me.aidezguidetv.ToolTipText = "Aide de ZGuideTV.NET"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSave, Me.ToolStripPrintTonight, Me.ToolStripSeparator1, Me.ToolStripOntop, Me.ToolStripSearch, Me.ToolStripSeparator22, Me.ToolStripCalendar, Me.RechercheToolStripButton, Me.ToolStripSeparator2, Me.ToolStripPreferences, Me.ToolStripOptionsCouleurCategorie, Me.ToolStripUpdate, Me.ToolStripDualMonitor, Me.ToolStripLogos, Me.ToolStripSeparator12, Me.ToolStripAutoUpdate, Me.ToolStripHelptopics, Me.ToolStripHelpShortcuts, Me.ToolStripButtonDonate, Me.ToolStripAbout, Me.ToolStripLangue, Me.ToolStripManualFeedBack, Me.ToolStripFacebook, Me.ToolStripForum, Me.ToolStripWebsite, Me.ToolStripTextBoxRecherche, Me.ToolStripButtonRecherche})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(984, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 50
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'ToolStripSave
        '
        Me.ToolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSave.Image = CType(resources.GetObject("ToolStripSave.Image"), System.Drawing.Image)
        Me.ToolStripSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSave.Name = "ToolStripSave"
        Me.ToolStripSave.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripSave.Text = "Gestion bases de données sous..."
        '
        'ToolStripPrintTonight
        '
        Me.ToolStripPrintTonight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripPrintTonight.Image = CType(resources.GetObject("ToolStripPrintTonight.Image"), System.Drawing.Image)
        Me.ToolStripPrintTonight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripPrintTonight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripPrintTonight.Name = "ToolStripPrintTonight"
        Me.ToolStripPrintTonight.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripPrintTonight.Text = "ToolStripButton7"
        Me.ToolStripPrintTonight.ToolTipText = "Imprimer ""Ce soir"""
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripOntop
        '
        Me.ToolStripOntop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripOntop.Image = CType(resources.GetObject("ToolStripOntop.Image"), System.Drawing.Image)
        Me.ToolStripOntop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripOntop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripOntop.Name = "ToolStripOntop"
        Me.ToolStripOntop.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripOntop.Text = "ToolStripButton9"
        Me.ToolStripOntop.ToolTipText = "Avant plan"
        '
        'ToolStripSearch
        '
        Me.ToolStripSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSearch.Image = CType(resources.GetObject("ToolStripSearch.Image"), System.Drawing.Image)
        Me.ToolStripSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSearch.Name = "ToolStripSearch"
        Me.ToolStripSearch.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripSearch.Text = "ToolStripButton8"
        Me.ToolStripSearch.ToolTipText = "Recherche Avancée"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripCalendar
        '
        Me.ToolStripCalendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripCalendar.Image = CType(resources.GetObject("ToolStripCalendar.Image"), System.Drawing.Image)
        Me.ToolStripCalendar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripCalendar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripCalendar.Name = "ToolStripCalendar"
        Me.ToolStripCalendar.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripCalendar.Text = "ToolStripButton3"
        Me.ToolStripCalendar.ToolTipText = "Afficher/Cacher calendrier"
        '
        'RechercheToolStripButton
        '
        Me.RechercheToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RechercheToolStripButton.Image = CType(resources.GetObject("RechercheToolStripButton.Image"), System.Drawing.Image)
        Me.RechercheToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RechercheToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RechercheToolStripButton.Name = "RechercheToolStripButton"
        Me.RechercheToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.RechercheToolStripButton.Text = "The TVDB.Com..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripPreferences
        '
        Me.ToolStripPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripPreferences.Image = Global.ZGuideTV.My.Resources.Resources.PropertiesHS
        Me.ToolStripPreferences.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripPreferences.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripPreferences.Name = "ToolStripPreferences"
        Me.ToolStripPreferences.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripPreferences.Text = "ToolStripButton10"
        Me.ToolStripPreferences.ToolTipText = "Préférences"
        '
        'ToolStripOptionsCouleurCategorie
        '
        Me.ToolStripOptionsCouleurCategorie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripOptionsCouleurCategorie.Image = CType(resources.GetObject("ToolStripOptionsCouleurCategorie.Image"), System.Drawing.Image)
        Me.ToolStripOptionsCouleurCategorie.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripOptionsCouleurCategorie.Name = "ToolStripOptionsCouleurCategorie"
        Me.ToolStripOptionsCouleurCategorie.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripOptionsCouleurCategorie.Text = "Couleur des catégories"
        '
        'ToolStripUpdate
        '
        Me.ToolStripUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripUpdate.Image = CType(resources.GetObject("ToolStripUpdate.Image"), System.Drawing.Image)
        Me.ToolStripUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripUpdate.Name = "ToolStripUpdate"
        Me.ToolStripUpdate.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripUpdate.Text = "ToolStripButton11"
        Me.ToolStripUpdate.ToolTipText = "Mise à jour manuelle"
        '
        'ToolStripDualMonitor
        '
        Me.ToolStripDualMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDualMonitor.Image = Global.ZGuideTV.My.Resources.Resources.monitor
        Me.ToolStripDualMonitor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDualMonitor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDualMonitor.Name = "ToolStripDualMonitor"
        Me.ToolStripDualMonitor.RightToLeftAutoMirrorImage = True
        Me.ToolStripDualMonitor.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripDualMonitor.Text = "ToolStripButton4"
        Me.ToolStripDualMonitor.ToolTipText = "Basculer entre les écrans"
        '
        'ToolStripLogos
        '
        Me.ToolStripLogos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLogos.Image = CType(resources.GetObject("ToolStripLogos.Image"), System.Drawing.Image)
        Me.ToolStripLogos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLogos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripLogos.Name = "ToolStripLogos"
        Me.ToolStripLogos.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripLogos.Text = "ToolStripButton12"
        Me.ToolStripLogos.ToolTipText = "Réorganisation logos et chaines"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripAutoUpdate
        '
        Me.ToolStripAutoUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripAutoUpdate.Enabled = False
        Me.ToolStripAutoUpdate.Image = CType(resources.GetObject("ToolStripAutoUpdate.Image"), System.Drawing.Image)
        Me.ToolStripAutoUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAutoUpdate.Name = "ToolStripAutoUpdate"
        Me.ToolStripAutoUpdate.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripAutoUpdate.Text = "ToolStripButton2"
        Me.ToolStripAutoUpdate.ToolTipText = "Mise à jour automatique"
        Me.ToolStripAutoUpdate.Visible = False
        '
        'ToolStripHelptopics
        '
        Me.ToolStripHelptopics.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripHelptopics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripHelptopics.Image = Global.ZGuideTV.My.Resources.Resources.Help
        Me.ToolStripHelptopics.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripHelptopics.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripHelptopics.Name = "ToolStripHelptopics"
        Me.ToolStripHelptopics.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripHelptopics.Text = "ToolStripButton5"
        Me.ToolStripHelptopics.ToolTipText = "Rubrique d'aide"
        '
        'ToolStripHelpShortcuts
        '
        Me.ToolStripHelpShortcuts.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripHelpShortcuts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripHelpShortcuts.Image = Global.ZGuideTV.My.Resources.Resources.keyboard
        Me.ToolStripHelpShortcuts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripHelpShortcuts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripHelpShortcuts.Name = "ToolStripHelpShortcuts"
        Me.ToolStripHelpShortcuts.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripHelpShortcuts.Text = "ToolStripButton2"
        Me.ToolStripHelpShortcuts.ToolTipText = "Raccourcis clavier"
        '
        'ToolStripButtonDonate
        '
        Me.ToolStripButtonDonate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonDonate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDonate.Image = Global.ZGuideTV.My.Resources.Resources.paypal
        Me.ToolStripButtonDonate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonDonate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDonate.Name = "ToolStripButtonDonate"
        Me.ToolStripButtonDonate.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonDonate.Text = "ToolStripButton2"
        '
        'ToolStripAbout
        '
        Me.ToolStripAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripAbout.Image = Global.ZGuideTV.My.Resources.Resources.ico_bleu_tv
        Me.ToolStripAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripAbout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAbout.Name = "ToolStripAbout"
        Me.ToolStripAbout.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripAbout.Text = "ToolStripButton2"
        Me.ToolStripAbout.ToolTipText = "À propos de ZGuideTV"
        '
        'ToolStripLangue
        '
        Me.ToolStripLangue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLangue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLangue.Image = CType(resources.GetObject("ToolStripLangue.Image"), System.Drawing.Image)
        Me.ToolStripLangue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLangue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripLangue.Name = "ToolStripLangue"
        Me.ToolStripLangue.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripLangue.Text = "ToolStripButton10"
        Me.ToolStripLangue.ToolTipText = "Langue"
        '
        'ToolStripManualFeedBack
        '
        Me.ToolStripManualFeedBack.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripManualFeedBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripManualFeedBack.Image = CType(resources.GetObject("ToolStripManualFeedBack.Image"), System.Drawing.Image)
        Me.ToolStripManualFeedBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripManualFeedBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripManualFeedBack.Name = "ToolStripManualFeedBack"
        Me.ToolStripManualFeedBack.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripManualFeedBack.Text = "ToolStripManualFeedBack"
        Me.ToolStripManualFeedBack.ToolTipText = "Envoyer un feedback"
        '
        'ToolStripFacebook
        '
        Me.ToolStripFacebook.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripFacebook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripFacebook.Image = Global.ZGuideTV.My.Resources.Resources.icon16facebook
        Me.ToolStripFacebook.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripFacebook.Name = "ToolStripFacebook"
        Me.ToolStripFacebook.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripFacebook.Text = "ToolStripFacebook"
        Me.ToolStripFacebook.ToolTipText = "Facebook"
        '
        'ToolStripForum
        '
        Me.ToolStripForum.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripForum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripForum.Image = CType(resources.GetObject("ToolStripForum.Image"), System.Drawing.Image)
        Me.ToolStripForum.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripForum.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripForum.Name = "ToolStripForum"
        Me.ToolStripForum.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripForum.Text = "ToolStripButton8"
        Me.ToolStripForum.ToolTipText = "Forum officiel ZGuideTV.NET"
        '
        'ToolStripWebsite
        '
        Me.ToolStripWebsite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripWebsite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripWebsite.Image = Global.ZGuideTV.My.Resources.Resources.internet1
        Me.ToolStripWebsite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripWebsite.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripWebsite.Name = "ToolStripWebsite"
        Me.ToolStripWebsite.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripWebsite.Text = "ToolStripButton9"
        Me.ToolStripWebsite.ToolTipText = "Site officiel ZGuideTV.NET"
        '
        'ToolStripTextBoxRecherche
        '
        Me.ToolStripTextBoxRecherche.AutoSize = False
        Me.ToolStripTextBoxRecherche.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBoxRecherche.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBoxRecherche.Name = "ToolStripTextBoxRecherche"
        Me.ToolStripTextBoxRecherche.Size = New System.Drawing.Size(152, 16)
        '
        'ToolStripButtonRecherche
        '
        Me.ToolStripButtonRecherche.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRecherche.Image = CType(resources.GetObject("ToolStripButtonRecherche.Image"), System.Drawing.Image)
        Me.ToolStripButtonRecherche.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonRecherche.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRecherche.Name = "ToolStripButtonRecherche"
        Me.ToolStripButtonRecherche.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonRecherche.Text = "ToolStripButton2"
        Me.ToolStripButtonRecherche.ToolTipText = "Recherche"
        '
        'panel_droit
        '
        Me.panel_droit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_droit.Controls.Add(Me.Panel_glob_maintenant)
        Me.panel_droit.Controls.Add(Me.Panel_glob_ce_soir)
        Me.panel_droit.Controls.Add(Me.Calendar)
        Me.panel_droit.Location = New System.Drawing.Point(711, 49)
        Me.panel_droit.Margin = New System.Windows.Forms.Padding(0)
        Me.panel_droit.Name = "panel_droit"
        Me.panel_droit.Size = New System.Drawing.Size(264, 656)
        Me.panel_droit.TabIndex = 62
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuFile, Me.ToolStripMenuEdit, Me.ToolStripMenuOptions, Me.ToolStripMenuHelp, Me.RaccourcisToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(984, 24)
        Me.MenuStrip1.TabIndex = 64
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuFile
        '
        Me.ToolStripMenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuFileSave, Me.ToolStripSeparator4, Me.ToolStripMenuFileRestart, Me.ToolStripSeparator21, Me.ToolStripMenuItemSettingsReset, Me.ToolStripSeparator3, Me.ToolStripMenuFileExit})
        Me.ToolStripMenuFile.Name = "ToolStripMenuFile"
        Me.ToolStripMenuFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ToolStripMenuFile.Size = New System.Drawing.Size(56, 20)
        Me.ToolStripMenuFile.Text = "Fichier"
        '
        'ToolStripMenuFileSave
        '
        Me.ToolStripMenuFileSave.Image = CType(resources.GetObject("ToolStripMenuFileSave.Image"), System.Drawing.Image)
        Me.ToolStripMenuFileSave.Name = "ToolStripMenuFileSave"
        Me.ToolStripMenuFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.ToolStripMenuFileSave.Size = New System.Drawing.Size(263, 22)
        Me.ToolStripMenuFileSave.Text = "Gestion bases de données"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(260, 6)
        '
        'ToolStripMenuFileRestart
        '
        Me.ToolStripMenuFileRestart.Image = CType(resources.GetObject("ToolStripMenuFileRestart.Image"), System.Drawing.Image)
        Me.ToolStripMenuFileRestart.Name = "ToolStripMenuFileRestart"
        Me.ToolStripMenuFileRestart.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ToolStripMenuFileRestart.Size = New System.Drawing.Size(263, 22)
        Me.ToolStripMenuFileRestart.Text = "Redémarrer"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(260, 6)
        '
        'ToolStripMenuItemSettingsReset
        '
        Me.ToolStripMenuItemSettingsReset.Name = "ToolStripMenuItemSettingsReset"
        Me.ToolStripMenuItemSettingsReset.Size = New System.Drawing.Size(263, 22)
        Me.ToolStripMenuItemSettingsReset.Text = "Réinitialisation des paramètres"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(260, 6)
        '
        'ToolStripMenuFileExit
        '
        Me.ToolStripMenuFileExit.Image = CType(resources.GetObject("ToolStripMenuFileExit.Image"), System.Drawing.Image)
        Me.ToolStripMenuFileExit.Name = "ToolStripMenuFileExit"
        Me.ToolStripMenuFileExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ToolStripMenuFileExit.Size = New System.Drawing.Size(263, 22)
        Me.ToolStripMenuFileExit.Text = "Quitter"
        '
        'ToolStripMenuEdit
        '
        Me.ToolStripMenuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuEditOntop, Me.ToolStripMenuSearch, Me.ToolStripSeparator5, Me.ToolStripMenuCalendar, Me.RechercheInfosToolStripMenuItem, Me.ToolStripSeparator16, Me.ToolStripMenuPrintTonight})
        Me.ToolStripMenuEdit.Name = "ToolStripMenuEdit"
        Me.ToolStripMenuEdit.Size = New System.Drawing.Size(57, 20)
        Me.ToolStripMenuEdit.Text = "Edition"
        '
        'ToolStripMenuEditOntop
        '
        Me.ToolStripMenuEditOntop.Image = CType(resources.GetObject("ToolStripMenuEditOntop.Image"), System.Drawing.Image)
        Me.ToolStripMenuEditOntop.Name = "ToolStripMenuEditOntop"
        Me.ToolStripMenuEditOntop.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ToolStripMenuEditOntop.Size = New System.Drawing.Size(250, 22)
        Me.ToolStripMenuEditOntop.Text = "Avant plan"
        '
        'ToolStripMenuSearch
        '
        Me.ToolStripMenuSearch.Image = CType(resources.GetObject("ToolStripMenuSearch.Image"), System.Drawing.Image)
        Me.ToolStripMenuSearch.Name = "ToolStripMenuSearch"
        Me.ToolStripMenuSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ToolStripMenuSearch.Size = New System.Drawing.Size(250, 22)
        Me.ToolStripMenuSearch.Text = "Recherche avancée"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(247, 6)
        '
        'ToolStripMenuCalendar
        '
        Me.ToolStripMenuCalendar.Image = CType(resources.GetObject("ToolStripMenuCalendar.Image"), System.Drawing.Image)
        Me.ToolStripMenuCalendar.Name = "ToolStripMenuCalendar"
        Me.ToolStripMenuCalendar.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ToolStripMenuCalendar.Size = New System.Drawing.Size(250, 22)
        Me.ToolStripMenuCalendar.Text = "Afficher/Cacher calendrier"
        '
        'RechercheInfosToolStripMenuItem
        '
        Me.RechercheInfosToolStripMenuItem.Image = CType(resources.GetObject("RechercheInfosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RechercheInfosToolStripMenuItem.Name = "RechercheInfosToolStripMenuItem"
        Me.RechercheInfosToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.RechercheInfosToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.RechercheInfosToolStripMenuItem.Text = "The TVDB.Com..."
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(247, 6)
        '
        'ToolStripMenuPrintTonight
        '
        Me.ToolStripMenuPrintTonight.Image = CType(resources.GetObject("ToolStripMenuPrintTonight.Image"), System.Drawing.Image)
        Me.ToolStripMenuPrintTonight.Name = "ToolStripMenuPrintTonight"
        Me.ToolStripMenuPrintTonight.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ToolStripMenuPrintTonight.Size = New System.Drawing.Size(250, 22)
        Me.ToolStripMenuPrintTonight.Text = "Imprimer ""Ce soir"""
        '
        'ToolStripMenuOptions
        '
        Me.ToolStripMenuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuOptionsUpdate, Me.ToolStripMenuOptionsAutoUpdate, Me.ToolStripSeparator19, Me.ToolStripMenuOptionsPreferences, Me.ToolStripMenuOptionsCouleurCategorie, Me.ToolStripMenuOptionsLogos, Me.ToolStripSeparator18, Me.ToolStripMenuOptionsDualMonitor, Me.ToolStripSeparator25})
        Me.ToolStripMenuOptions.Name = "ToolStripMenuOptions"
        Me.ToolStripMenuOptions.Size = New System.Drawing.Size(61, 20)
        Me.ToolStripMenuOptions.Text = "Options"
        '
        'ToolStripMenuOptionsUpdate
        '
        Me.ToolStripMenuOptionsUpdate.Image = CType(resources.GetObject("ToolStripMenuOptionsUpdate.Image"), System.Drawing.Image)
        Me.ToolStripMenuOptionsUpdate.Name = "ToolStripMenuOptionsUpdate"
        Me.ToolStripMenuOptionsUpdate.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ToolStripMenuOptionsUpdate.Size = New System.Drawing.Size(289, 22)
        Me.ToolStripMenuOptionsUpdate.Text = "Mise à jour manuelle"
        '
        'ToolStripMenuOptionsAutoUpdate
        '
        Me.ToolStripMenuOptionsAutoUpdate.Enabled = False
        Me.ToolStripMenuOptionsAutoUpdate.Image = CType(resources.GetObject("ToolStripMenuOptionsAutoUpdate.Image"), System.Drawing.Image)
        Me.ToolStripMenuOptionsAutoUpdate.Name = "ToolStripMenuOptionsAutoUpdate"
        Me.ToolStripMenuOptionsAutoUpdate.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ToolStripMenuOptionsAutoUpdate.Size = New System.Drawing.Size(289, 22)
        Me.ToolStripMenuOptionsAutoUpdate.Text = "Mise à jour automatique"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(286, 6)
        '
        'ToolStripMenuOptionsPreferences
        '
        Me.ToolStripMenuOptionsPreferences.Image = Global.ZGuideTV.My.Resources.Resources.PropertiesHS
        Me.ToolStripMenuOptionsPreferences.Name = "ToolStripMenuOptionsPreferences"
        Me.ToolStripMenuOptionsPreferences.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ToolStripMenuOptionsPreferences.Size = New System.Drawing.Size(289, 22)
        Me.ToolStripMenuOptionsPreferences.Text = "Préférences"
        '
        'ToolStripMenuOptionsCouleurCategorie
        '
        Me.ToolStripMenuOptionsCouleurCategorie.Image = Global.ZGuideTV.My.Resources.Resources.color_swatch
        Me.ToolStripMenuOptionsCouleurCategorie.Name = "ToolStripMenuOptionsCouleurCategorie"
        Me.ToolStripMenuOptionsCouleurCategorie.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.ToolStripMenuOptionsCouleurCategorie.Size = New System.Drawing.Size(289, 22)
        Me.ToolStripMenuOptionsCouleurCategorie.Text = "Couleur des catégories"
        '
        'ToolStripMenuOptionsLogos
        '
        Me.ToolStripMenuOptionsLogos.Image = CType(resources.GetObject("ToolStripMenuOptionsLogos.Image"), System.Drawing.Image)
        Me.ToolStripMenuOptionsLogos.Name = "ToolStripMenuOptionsLogos"
        Me.ToolStripMenuOptionsLogos.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ToolStripMenuOptionsLogos.Size = New System.Drawing.Size(289, 22)
        Me.ToolStripMenuOptionsLogos.Text = "Réorganisation logos et chaines"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(286, 6)
        '
        'ToolStripMenuOptionsDualMonitor
        '
        Me.ToolStripMenuOptionsDualMonitor.Image = Global.ZGuideTV.My.Resources.Resources.monitor
        Me.ToolStripMenuOptionsDualMonitor.Name = "ToolStripMenuOptionsDualMonitor"
        Me.ToolStripMenuOptionsDualMonitor.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuOptionsDualMonitor.Size = New System.Drawing.Size(289, 22)
        Me.ToolStripMenuOptionsDualMonitor.Text = "Basculer entre les écrans"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(286, 6)
        '
        'ToolStripMenuHelp
        '
        Me.ToolStripMenuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuHelpHelptopics, Me.ToolStripMenuHelpHelpShortcuts, Me.ToolStripSeparator6, Me.ToolStripMenuHelpWebsite, Me.ToolStripMenuHelpForum, Me.FacebookToolStripMenuItem, Me.ToolStripMenuHelpDonate, Me.ToolStripSeparator11, Me.ToolStripMenuHelpManualFeedBack, Me.ToolStripMenuHelpLanguage, Me.ToolStripMenuHelpCompensation, Me.ToolStripSeparator26, Me.ToolStripMenuHelpAbout})
        Me.ToolStripMenuHelp.Name = "ToolStripMenuHelp"
        Me.ToolStripMenuHelp.Size = New System.Drawing.Size(26, 20)
        Me.ToolStripMenuHelp.Text = "?"
        '
        'ToolStripMenuHelpHelptopics
        '
        Me.ToolStripMenuHelpHelptopics.Image = CType(resources.GetObject("ToolStripMenuHelpHelptopics.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpHelptopics.Name = "ToolStripMenuHelpHelptopics"
        Me.ToolStripMenuHelpHelptopics.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ToolStripMenuHelpHelptopics.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpHelptopics.Text = "Rubrique d'aide"
        '
        'ToolStripMenuHelpHelpShortcuts
        '
        Me.ToolStripMenuHelpHelpShortcuts.Image = Global.ZGuideTV.My.Resources.Resources.keyboard
        Me.ToolStripMenuHelpHelpShortcuts.Name = "ToolStripMenuHelpHelpShortcuts"
        Me.ToolStripMenuHelpHelpShortcuts.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.ToolStripMenuHelpHelpShortcuts.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpHelpShortcuts.Text = "Raccourcis clavier"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(281, 6)
        '
        'ToolStripMenuHelpWebsite
        '
        Me.ToolStripMenuHelpWebsite.Image = Global.ZGuideTV.My.Resources.Resources.internet1
        Me.ToolStripMenuHelpWebsite.Name = "ToolStripMenuHelpWebsite"
        Me.ToolStripMenuHelpWebsite.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpWebsite.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpWebsite.Text = "Site officiel ZGuideTV"
        '
        'ToolStripMenuHelpForum
        '
        Me.ToolStripMenuHelpForum.Image = CType(resources.GetObject("ToolStripMenuHelpForum.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpForum.Name = "ToolStripMenuHelpForum"
        Me.ToolStripMenuHelpForum.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpForum.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpForum.Text = "Forum officiel ZGuideTV"
        '
        'FacebookToolStripMenuItem
        '
        Me.FacebookToolStripMenuItem.Image = Global.ZGuideTV.My.Resources.Resources.icon16facebook
        Me.FacebookToolStripMenuItem.Name = "FacebookToolStripMenuItem"
        Me.FacebookToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FacebookToolStripMenuItem.Size = New System.Drawing.Size(284, 24)
        Me.FacebookToolStripMenuItem.Text = "Facebook"
        '
        'ToolStripMenuHelpDonate
        '
        Me.ToolStripMenuHelpDonate.Image = CType(resources.GetObject("ToolStripMenuHelpDonate.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpDonate.Name = "ToolStripMenuHelpDonate"
        Me.ToolStripMenuHelpDonate.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpDonate.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpDonate.Text = "Faire un don"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(281, 6)
        '
        'ToolStripMenuHelpManualFeedBack
        '
        Me.ToolStripMenuHelpManualFeedBack.Image = CType(resources.GetObject("ToolStripMenuHelpManualFeedBack.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpManualFeedBack.Name = "ToolStripMenuHelpManualFeedBack"
        Me.ToolStripMenuHelpManualFeedBack.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpManualFeedBack.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpManualFeedBack.Text = "Envoyer un feedback..."
        '
        'ToolStripMenuHelpLanguage
        '
        Me.ToolStripMenuHelpLanguage.Image = CType(resources.GetObject("ToolStripMenuHelpLanguage.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpLanguage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuHelpLanguage.Name = "ToolStripMenuHelpLanguage"
        Me.ToolStripMenuHelpLanguage.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpLanguage.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpLanguage.Text = "Langue"
        '
        'ToolStripMenuHelpCompensation
        '
        Me.ToolStripMenuHelpCompensation.Image = Global.ZGuideTV.My.Resources.Resources.decalage
        Me.ToolStripMenuHelpCompensation.Name = "ToolStripMenuHelpCompensation"
        Me.ToolStripMenuHelpCompensation.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpCompensation.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpCompensation.Text = "Compensation fuseaux horaires"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(281, 6)
        '
        'ToolStripMenuHelpAbout
        '
        Me.ToolStripMenuHelpAbout.Image = Global.ZGuideTV.My.Resources.Resources.ico_bleu_tv
        Me.ToolStripMenuHelpAbout.Name = "ToolStripMenuHelpAbout"
        Me.ToolStripMenuHelpAbout.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpAbout.Size = New System.Drawing.Size(284, 24)
        Me.ToolStripMenuHelpAbout.Text = "À propos de ZGuideTV"
        '
        'RaccourcisToolStripMenuItem
        '
        Me.RaccourcisToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemJour_Moins, Me.ToolStripMenuItemheure_moins, Me.ToolStripMenuItem6H, Me.ToolStripMenuItem9H, Me.ToolStripMenuItem12H, Me.ToolStripMenuItem15H, Me.ToolStripMenuItem18H, Me.ToolStripMenuItem20H, Me.ToolStripMenuItem23H, Me.ToolStripMenuItemMaintenant, Me.ToolStripMenuItemheure_plus, Me.ToolStripMenuItemJour_Plus, Me.ToolStripMenuItemChaineBas, Me.ToolStripMenuItemChaineHaut, Me.CeToolStripMenuItem, Me.CeSoirBasToolStripMenuItem, Me.MaintenantHautToolStripMenuItem, Me.MaintenantBasToolStripMenuItem})
        Me.RaccourcisToolStripMenuItem.Name = "RaccourcisToolStripMenuItem"
        Me.RaccourcisToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.RaccourcisToolStripMenuItem.Text = "Raccourcis"
        Me.RaccourcisToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItemJour_Moins
        '
        Me.ToolStripMenuItemJour_Moins.Name = "ToolStripMenuItemJour_Moins"
        Me.ToolStripMenuItemJour_Moins.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad1), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemJour_Moins.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemJour_Moins.Text = "Jour -1"
        '
        'ToolStripMenuItemheure_moins
        '
        Me.ToolStripMenuItemheure_moins.Name = "ToolStripMenuItemheure_moins"
        Me.ToolStripMenuItemheure_moins.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad2), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemheure_moins.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemheure_moins.Text = "Heure -1"
        '
        'ToolStripMenuItem6H
        '
        Me.ToolStripMenuItem6H.Name = "ToolStripMenuItem6H"
        Me.ToolStripMenuItem6H.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad6), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem6H.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem6H.Text = "06H"
        '
        'ToolStripMenuItem9H
        '
        Me.ToolStripMenuItem9H.Name = "ToolStripMenuItem9H"
        Me.ToolStripMenuItem9H.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad9), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem9H.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem9H.Text = "09H"
        '
        'ToolStripMenuItem12H
        '
        Me.ToolStripMenuItem12H.Name = "ToolStripMenuItem12H"
        Me.ToolStripMenuItem12H.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad2), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem12H.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem12H.Text = "12H"
        '
        'ToolStripMenuItem15H
        '
        Me.ToolStripMenuItem15H.Name = "ToolStripMenuItem15H"
        Me.ToolStripMenuItem15H.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad5), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem15H.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem15H.Text = "15H"
        '
        'ToolStripMenuItem18H
        '
        Me.ToolStripMenuItem18H.Name = "ToolStripMenuItem18H"
        Me.ToolStripMenuItem18H.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad8), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem18H.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem18H.Text = "18H"
        '
        'ToolStripMenuItem20H
        '
        Me.ToolStripMenuItem20H.Name = "ToolStripMenuItem20H"
        Me.ToolStripMenuItem20H.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad0), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem20H.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem20H.Text = "20H"
        '
        'ToolStripMenuItem23H
        '
        Me.ToolStripMenuItem23H.Name = "ToolStripMenuItem23H"
        Me.ToolStripMenuItem23H.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad3), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem23H.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem23H.Text = "23H"
        '
        'ToolStripMenuItemMaintenant
        '
        Me.ToolStripMenuItemMaintenant.Name = "ToolStripMenuItemMaintenant"
        Me.ToolStripMenuItemMaintenant.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMaintenant.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemMaintenant.Text = "Maintenant"
        '
        'ToolStripMenuItemheure_plus
        '
        Me.ToolStripMenuItemheure_plus.Name = "ToolStripMenuItemheure_plus"
        Me.ToolStripMenuItemheure_plus.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad3), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemheure_plus.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemheure_plus.Text = "Heure +1"
        '
        'ToolStripMenuItemJour_Plus
        '
        Me.ToolStripMenuItemJour_Plus.Name = "ToolStripMenuItemJour_Plus"
        Me.ToolStripMenuItemJour_Plus.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad4), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemJour_Plus.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemJour_Plus.Text = "Jour +1"
        '
        'ToolStripMenuItemChaineBas
        '
        Me.ToolStripMenuItemChaineBas.Name = "ToolStripMenuItemChaineBas"
        Me.ToolStripMenuItemChaineBas.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemChaineBas.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemChaineBas.Text = "Chaînes haut"
        '
        'ToolStripMenuItemChaineHaut
        '
        Me.ToolStripMenuItemChaineHaut.Name = "ToolStripMenuItemChaineHaut"
        Me.ToolStripMenuItemChaineHaut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemChaineHaut.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemChaineHaut.Text = "Chaînes bas"
        '
        'CeToolStripMenuItem
        '
        Me.CeToolStripMenuItem.Name = "CeToolStripMenuItem"
        Me.CeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)
        Me.CeToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CeToolStripMenuItem.Text = "Ce ""soir"" haut"
        '
        'CeSoirBasToolStripMenuItem
        '
        Me.CeSoirBasToolStripMenuItem.Name = "CeSoirBasToolStripMenuItem"
        Me.CeSoirBasToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.CeSoirBasToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CeSoirBasToolStripMenuItem.Text = "Ce ""soir"" bas"
        '
        'MaintenantHautToolStripMenuItem
        '
        Me.MaintenantHautToolStripMenuItem.Name = "MaintenantHautToolStripMenuItem"
        Me.MaintenantHautToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.MaintenantHautToolStripMenuItem.Text = """Maintenant"" haut"
        '
        'MaintenantBasToolStripMenuItem
        '
        Me.MaintenantBasToolStripMenuItem.Name = "MaintenantBasToolStripMenuItem"
        Me.MaintenantBasToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)
        Me.MaintenantBasToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.MaintenantBasToolStripMenuItem.Text = """Maintenant"" bas"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.AutoSize = False
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_date, Me.ToolStripStatusLabel_heure, Me.ToolStripStatusLabelCompensation, Me.ToolStripStatusLabelMinutes, Me.ToolStripStatusLabelMemory, Me.ToolStripStatusLabelMemoryUsage, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabelEmpty, Me.ToolStripStatusLabelUpdate})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 702)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.ShowItemToolTips = True
        Me.StatusStrip2.Size = New System.Drawing.Size(984, 23)
        Me.StatusStrip2.SizingGrip = False
        Me.StatusStrip2.TabIndex = 63
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel_date
        '
        Me.ToolStripStatusLabel_date.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel_date.Name = "ToolStripStatusLabel_date"
        Me.ToolStripStatusLabel_date.Size = New System.Drawing.Size(96, 18)
        Me.ToolStripStatusLabel_date.Text = "lun 12 novembre"
        Me.ToolStripStatusLabel_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel_heure
        '
        Me.ToolStripStatusLabel_heure.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel_heure.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel_heure.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel_heure.Name = "ToolStripStatusLabel_heure"
        Me.ToolStripStatusLabel_heure.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.ToolStripStatusLabel_heure.Size = New System.Drawing.Size(78, 18)
        Me.ToolStripStatusLabel_heure.Text = "hh:mm:ss"
        Me.ToolStripStatusLabel_heure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelCompensation
        '
        Me.ToolStripStatusLabelCompensation.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelCompensation.DoubleClickEnabled = True
        Me.ToolStripStatusLabelCompensation.Name = "ToolStripStatusLabelCompensation"
        Me.ToolStripStatusLabelCompensation.Size = New System.Drawing.Size(91, 18)
        Me.ToolStripStatusLabelCompensation.Text = "Compensation :"
        Me.ToolStripStatusLabelCompensation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelMinutes
        '
        Me.ToolStripStatusLabelMinutes.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelMinutes.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelMinutes.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabelMinutes.DoubleClickEnabled = True
        Me.ToolStripStatusLabelMinutes.Name = "ToolStripStatusLabelMinutes"
        Me.ToolStripStatusLabelMinutes.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.ToolStripStatusLabelMinutes.Size = New System.Drawing.Size(47, 18)
        Me.ToolStripStatusLabelMinutes.Text = "OFF"
        Me.ToolStripStatusLabelMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelMemory
        '
        Me.ToolStripStatusLabelMemory.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelMemory.Name = "ToolStripStatusLabelMemory"
        Me.ToolStripStatusLabelMemory.Size = New System.Drawing.Size(117, 18)
        Me.ToolStripStatusLabelMemory.Text = "Utilisation mémoire :"
        '
        'ToolStripStatusLabelMemoryUsage
        '
        Me.ToolStripStatusLabelMemoryUsage.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelMemoryUsage.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelMemoryUsage.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabelMemoryUsage.Name = "ToolStripStatusLabelMemoryUsage"
        Me.ToolStripStatusLabelMemoryUsage.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.ToolStripStatusLabelMemoryUsage.Size = New System.Drawing.Size(43, 18)
        Me.ToolStripStatusLabelMemoryUsage.Text = "0/0"
        Me.ToolStripStatusLabelMemoryUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.BackgroundImage = CType(resources.GetObject("ToolStripStatusLabel1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStripStatusLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 18)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabelEmpty
        '
        Me.ToolStripStatusLabelEmpty.AutoSize = False
        Me.ToolStripStatusLabelEmpty.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelEmpty.Name = "ToolStripStatusLabelEmpty"
        Me.ToolStripStatusLabelEmpty.Size = New System.Drawing.Size(307, 18)
        Me.ToolStripStatusLabelEmpty.Spring = True
        '
        'ToolStripStatusLabelUpdate
        '
        Me.ToolStripStatusLabelUpdate.ActiveLinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabelUpdate.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelUpdate.IsLink = True
        Me.ToolStripStatusLabelUpdate.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabelUpdate.Name = "ToolStripStatusLabelUpdate"
        Me.ToolStripStatusLabelUpdate.Size = New System.Drawing.Size(159, 18)
        Me.ToolStripStatusLabelUpdate.Text = "Rechercher une mise à jour..."
        Me.ToolStripStatusLabelUpdate.VisitedLinkColor = System.Drawing.Color.Black
        '
        'Timer_seconde
        '
        Me.Timer_seconde.Interval = 1000
        '
        'Timer_250msec
        '
        Me.Timer_250msec.Interval = 250
        '
        'TimerUsageMemory
        '
        Me.TimerUsageMemory.Interval = 1000
        '
        'Timer_wait
        '
        Me.Timer_wait.Interval = 500
        '
        'Timer_heure
        '
        Me.Timer_heure.Enabled = True
        Me.Timer_heure.Interval = 120000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "ZGuideTV.NET"
        '
        'ZSplitButtonDroit
        '
        Me.ZSplitButtonDroit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ZSplitButtonDroit.BackColor = System.Drawing.Color.DarkGray
        Me.ZSplitButtonDroit.Cliquable = True
        Me.ZSplitButtonDroit.Location = New System.Drawing.Point(698, 51)
        Me.ZSplitButtonDroit.Name = "ZSplitButtonDroit"
        Me.ZSplitButtonDroit.Size = New System.Drawing.Size(10, 641)
        Me.ZSplitButtonDroit.TabIndex = 68
        '
        'ZSplitButtonGauche
        '
        Me.ZSplitButtonGauche.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ZSplitButtonGauche.BackColor = System.Drawing.Color.DarkGray
        Me.ZSplitButtonGauche.Cliquable = False
        Me.ZSplitButtonGauche.Location = New System.Drawing.Point(77, 51)
        Me.ZSplitButtonGauche.Name = "ZSplitButtonGauche"
        Me.ZSplitButtonGauche.Size = New System.Drawing.Size(10, 641)
        Me.ZSplitButtonGauche.TabIndex = 67
        '
        'ZSplitButton1
        '
        Me.ZSplitButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ZSplitButton1.BackColor = System.Drawing.Color.DarkGray
        Me.ZSplitButton1.Cliquable = True
        Me.ZSplitButton1.Enabled = False
        Me.ZSplitButton1.Location = New System.Drawing.Point(4, 51)
        Me.ZSplitButton1.Name = "ZSplitButton1"
        Me.ZSplitButton1.Size = New System.Drawing.Size(10, 641)
        Me.ZSplitButton1.TabIndex = 66
        '
        'Timer_AutoUpdate
        '
        Me.Timer_AutoUpdate.Interval = 3000
        '
        'Mainform
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(984, 725)
        Me.Controls.Add(Me.ZSplitButtonDroit)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.ZSplitButtonGauche)
        Me.Controls.Add(Me.ZSplitButton1)
        Me.Controls.Add(Me.Panel_date)
        Me.Controls.Add(Me.PanelD)
        Me.Controls.Add(Me.PanelB)
        Me.Controls.Add(Me.panel_droit)
        Me.Controls.Add(Me.PanelE)
        Me.Controls.Add(Me.PanelA)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(900, 617)
        Me.Name = "Mainform"
        Me.Opacity = 0R
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.PanelE.ResumeLayout(False)
        Me.PanelB.ResumeLayout(False)
        Me.Panel_glob_maintenant.ResumeLayout(False)
        Me.Panel_glob_ce_soir.ResumeLayout(False)
        Me.Calendar.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.panel_droit.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListViewChannel As System.Windows.Forms.ListView
    Friend WithEvents ouvrirbasededonnees As System.Windows.Forms.ToolStripButton
    Friend WithEvents sauvegardebasededonnees As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents copierladescriptionselectionnee As System.Windows.Forms.ToolStripButton
    Friend WithEvents rechercheavancee As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toujoursenavantplan As System.Windows.Forms.ToolStripButton
    Friend WithEvents préférences As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miseajourdeschaines As System.Windows.Forms.ToolStripButton
    Friend WithEvents ajoutermodifierlogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents aidezguidetv As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer_minute As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPrintTonight As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripOntop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPreferences As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLogos As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelD As System.Windows.Forms.Panel
    Friend WithEvents PanelE As System.Windows.Forms.Panel
    Friend WithEvents PanelB As System.Windows.Forms.Panel
    Friend WithEvents Panel_date As System.Windows.Forms.Panel
    Friend WithEvents PanelA As System.Windows.Forms.Panel
    Friend WithEvents ToolStripDualMonitor As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel_glob_maintenant As System.Windows.Forms.Panel
    Friend WithEvents Panel_maintenant As System.Windows.Forms.Panel
    Friend WithEvents Panel_glob_ce_soir As System.Windows.Forms.Panel
    Friend WithEvents Panel_ce_soir As System.Windows.Forms.Panel
    Friend WithEvents ToolStripHelptopics As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripAbout As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripForum As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripWebsite As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLangue As System.Windows.Forms.ToolStripButton
    Friend WithEvents Calendar As System.Windows.Forms.Panel
    Friend WithEvents CalendarDimancheLabel As System.Windows.Forms.Label
    Friend WithEvents CalendarSamediLabel As System.Windows.Forms.Label
    Friend WithEvents CalendarVendrediLabel As System.Windows.Forms.Label
    Friend WithEvents CalendarJeudiLabel As System.Windows.Forms.Label
    Friend WithEvents CalendarMercrediLabel As System.Windows.Forms.Label
    Friend WithEvents CalendarMardiLabel As System.Windows.Forms.Label
    Friend WithEvents CalendarLundiLabel As System.Windows.Forms.Label
    Friend WithEvents Button5_3 As calendrierpavé
    Friend WithEvents Button6_7 As calendrierpavé
    Friend WithEvents Button5_2 As calendrierpavé
    Friend WithEvents Button3_2 As calendrierpavé
    Friend WithEvents Button5_7 As calendrierpavé
    Friend WithEvents Button5_1 As calendrierpavé
    Friend WithEvents Button6_1 As calendrierpavé
    Friend WithEvents L_MOIS_ANNEE As System.Windows.Forms.Label
    Friend WithEvents Button4_7 As Calendrierpavé
    Friend WithEvents Button6_6 As calendrierpavé
    Friend WithEvents Button4_6 As calendrierpavé
    Friend WithEvents Button5_6 As calendrierpavé
    Friend WithEvents Button3_4 As calendrierpavé
    Friend WithEvents Button6_4 As calendrierpavé
    Friend WithEvents Button4_5 As calendrierpavé
    Friend WithEvents Button6_5 As calendrierpavé
    Friend WithEvents Button4_4 As calendrierpavé
    Friend WithEvents Button5_4 As calendrierpavé
    Friend WithEvents Button6_3 As calendrierpavé
    Friend WithEvents Button4_3 As calendrierpavé
    Friend WithEvents Button5_5 As calendrierpavé
    Friend WithEvents Button4_2 As calendrierpavé
    Friend WithEvents Button6_2 As calendrierpavé
    Friend WithEvents Button4_1 As calendrierpavé
    Friend WithEvents Button3_7 As calendrierpavé
    Friend WithEvents Button3_6 As calendrierpavé
    Friend WithEvents Button3_5 As calendrierpavé
    Friend WithEvents Button3_3 As calendrierpavé
    Friend WithEvents Button3_1 As calendrierpavé
    Friend WithEvents Button2_1 As calendrierpavé
    Friend WithEvents Button2_2 As calendrierpavé
    Friend WithEvents Button2_3 As calendrierpavé
    Friend WithEvents Button2_5 As calendrierpavé
    Friend WithEvents Button2_6 As calendrierpavé
    Friend WithEvents Button2_7 As calendrierpavé
    Friend WithEvents Button1_7 As calendrierpavé
    Friend WithEvents Button1_6 As calendrierpavé
    Friend WithEvents Button1_1 As calendrierpavé
    Friend WithEvents Button1_5 As calendrierpavé
    Friend WithEvents Button1_2 As calendrierpavé
    Friend WithEvents Button1_4 As calendrierpavé
    Friend WithEvents Button1_3 As calendrierpavé
    Friend WithEvents Button2_4 As calendrierpavé
    Friend WithEvents panel_droit As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuFileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuPrintTonight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuEditOntop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuOptionsPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuOptionsLogos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpWebsite As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpForum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpHelptopics As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpLanguage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripAutoUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuOptionsDualMonitor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuOptionsUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuOptionsAutoUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RaccourcisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemJour_Moins As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemheure_moins As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6H As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9H As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12H As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15H As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem18H As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem20H As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem23H As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMaintenant As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemheure_plus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemJour_Plus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemChaineBas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemChaineHaut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CeSoirBasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaintenantHautToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaintenantBasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_seconde As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuHelpHelpShortcuts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechercheInfosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel_date As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_heure As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuFileRestart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer_250msec As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuHelpManualFeedBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripManualFeedBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripCalendar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuCalendar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechercheToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuHelpCompensation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpDonate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelCompensation As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelMinutes As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabelMemory As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelMemoryUsage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TimerUsageMemory As System.Windows.Forms.Timer
    Friend WithEvents navigtemporelle As ZGuideTV.BarreTemporelle
    Friend WithEvents Timer_wait As System.Windows.Forms.Timer
    Friend WithEvents Timer_heure As System.Windows.Forms.Timer
    Friend WithEvents ToolStripTextBoxRecherche As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButtonRecherche As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabelEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItemSettingsReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripHelpShortcuts As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonDonate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabelUpdate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ZSplitButton1 As ZGuideTV.ZSplitButton
    Friend WithEvents ZSplitButtonGauche As ZGuideTV.ZSplitButton
    Friend WithEvents ZSplitButtonDroit As ZGuideTV.ZSplitButton
    Friend WithEvents lbl_Titre_Ce_Soir As System.Windows.Forms.Label
    Friend WithEvents lbl_titre_maintenant As System.Windows.Forms.Label
    Friend WithEvents lblMoisS As System.Windows.Forms.Label
    Friend WithEvents lblMoisP As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolStripFacebook As System.Windows.Forms.ToolStripButton
    Friend WithEvents FacebookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btImprimemaintenant As System.Windows.Forms.Button
    Friend WithEvents btImprimeCeSoir As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuOptionsCouleurCategorie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripOptionsCouleurCategorie As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_AutoUpdate As Timer
End Class
