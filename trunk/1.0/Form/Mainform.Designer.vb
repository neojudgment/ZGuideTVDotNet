<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainform
    Inherits System.Windows.Forms.Form

    Private m_nFirstCharOnPage As Integer

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
            If Not MGraphics Is Nothing Then MGraphics.Dispose()


            If Not gLine Is Nothing Then gLine.Dispose()

            If Not jumplist Is Nothing Then jumplist.Dispose()

            If Not _mGraphics Is Nothing Then _mGraphics.Dispose()

            If Not _gLine Is Nothing Then _gLine.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents Restaurer As System.Windows.Forms.MenuItem
    Friend WithEvents Quitter As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainform))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Catégories")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pays")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fournisseurs")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Filtres", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.SystrayMenuRestore = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.SystrayMenuExit = New System.Windows.Forms.MenuItem()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ListViewChannel = New System.Windows.Forms.ListView()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.Context_menu_KTV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GestionDeKTVToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuProgramKTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuZapperKTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuGestionRecordKTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuGestionChainesKTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionDeMeuhMeuhTVToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuProgramMMTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuZapperMMTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuGestionRecordMMTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuGestionChainesMMTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_minute = New System.Windows.Forms.Timer(Me.components)
        Me.PanelC = New System.Windows.Forms.Panel()
        Me.PanelD = New System.Windows.Forms.Panel()
        Me.PanelE = New System.Windows.Forms.Panel()
        Me.navigtemporelle = New ZGuideTV.BarreTemporelle()
        Me.PanelB = New System.Windows.Forms.Panel()
        Me.Panel_date = New System.Windows.Forms.Panel()
        Me.PanelA = New System.Windows.Forms.Panel()
        Me.Panel_glob_maintenant = New System.Windows.Forms.Panel()
        Me.Panel_titre_maintenant = New System.Windows.Forms.Button()
        Me.Panel_maintenant = New System.Windows.Forms.Panel()
        Me.Panel_glob_ce_soir = New System.Windows.Forms.Panel()
        Me.Panel_titre_ce_soir = New System.Windows.Forms.Button()
        Me.Panel_ce_soir = New System.Windows.Forms.Panel()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Calendar = New System.Windows.Forms.Panel()
        Me.CalendarDimancheLabel = New System.Windows.Forms.Label()
        Me.CalendarSamediLabel = New System.Windows.Forms.Label()
        Me.CalendarVendrediLabel = New System.Windows.Forms.Label()
        Me.CalendarJeudiLabel = New System.Windows.Forms.Label()
        Me.CalendarMercrediLabel = New System.Windows.Forms.Label()
        Me.CalendarMardiLabel = New System.Windows.Forms.Label()
        Me.CalendarLundiLabel = New System.Windows.Forms.Label()
        Me.Button5_3 = New ZGuideTV.calendrierpavé()
        Me.Button6_7 = New ZGuideTV.calendrierpavé()
        Me.Button5_2 = New ZGuideTV.calendrierpavé()
        Me.Button3_2 = New ZGuideTV.calendrierpavé()
        Me.Button5_7 = New ZGuideTV.calendrierpavé()
        Me.Button5_1 = New ZGuideTV.calendrierpavé()
        Me.Button6_1 = New ZGuideTV.calendrierpavé()
        Me.L_MOIS_ANNEE = New System.Windows.Forms.Label()
        Me.MoisS = New System.Windows.Forms.Button()
        Me.Button4_7 = New ZGuideTV.calendrierpavé()
        Me.MoisP = New System.Windows.Forms.Button()
        Me.Button6_6 = New ZGuideTV.calendrierpavé()
        Me.Button4_6 = New ZGuideTV.calendrierpavé()
        Me.Button5_6 = New ZGuideTV.calendrierpavé()
        Me.Button3_4 = New ZGuideTV.calendrierpavé()
        Me.Button6_4 = New ZGuideTV.calendrierpavé()
        Me.Button4_5 = New ZGuideTV.calendrierpavé()
        Me.Button6_5 = New ZGuideTV.calendrierpavé()
        Me.Button4_4 = New ZGuideTV.calendrierpavé()
        Me.Button5_4 = New ZGuideTV.calendrierpavé()
        Me.Button6_3 = New ZGuideTV.calendrierpavé()
        Me.Button4_3 = New ZGuideTV.calendrierpavé()
        Me.Button5_5 = New ZGuideTV.calendrierpavé()
        Me.Button4_2 = New ZGuideTV.calendrierpavé()
        Me.Button6_2 = New ZGuideTV.calendrierpavé()
        Me.Button4_1 = New ZGuideTV.calendrierpavé()
        Me.Button3_7 = New ZGuideTV.calendrierpavé()
        Me.Button3_6 = New ZGuideTV.calendrierpavé()
        Me.Button3_5 = New ZGuideTV.calendrierpavé()
        Me.Button3_3 = New ZGuideTV.calendrierpavé()
        Me.Button3_1 = New ZGuideTV.calendrierpavé()
        Me.Button2_1 = New ZGuideTV.calendrierpavé()
        Me.Button2_2 = New ZGuideTV.calendrierpavé()
        Me.Button2_3 = New ZGuideTV.calendrierpavé()
        Me.Button2_4 = New ZGuideTV.calendrierpavé()
        Me.Button2_5 = New ZGuideTV.calendrierpavé()
        Me.Button2_6 = New ZGuideTV.calendrierpavé()
        Me.Button2_7 = New ZGuideTV.calendrierpavé()
        Me.Button1_7 = New ZGuideTV.calendrierpavé()
        Me.Button1_6 = New ZGuideTV.calendrierpavé()
        Me.Button1_1 = New ZGuideTV.calendrierpavé()
        Me.Button1_5 = New ZGuideTV.calendrierpavé()
        Me.Button1_2 = New ZGuideTV.calendrierpavé()
        Me.Button1_4 = New ZGuideTV.calendrierpavé()
        Me.Button1_3 = New ZGuideTV.calendrierpavé()
        Me.ButtonBas1 = New System.Windows.Forms.Button()
        Me.premiere = New System.Windows.Forms.PictureBox()
        Me.ButtonDroit = New System.Windows.Forms.Button()
        Me.Soustitre = New System.Windows.Forms.PictureBox()
        Me.AudioStereo = New System.Windows.Forms.PictureBox()
        Me.Signaletique_43 = New System.Windows.Forms.PictureBox()
        Me.Signaletique_169 = New System.Windows.Forms.PictureBox()
        Me.Picture_18 = New System.Windows.Forms.PictureBox()
        Me.Picture_16 = New System.Windows.Forms.PictureBox()
        Me.Picture_12 = New System.Windows.Forms.PictureBox()
        Me.Picture_10 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonGauche = New System.Windows.Forms.Button()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
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
        Me.programmerktv = New System.Windows.Forms.ToolStripButton()
        Me.zapperktv = New System.Windows.Forms.ToolStripButton()
        Me.gestionenregistrementktv = New System.Windows.Forms.ToolStripButton()
        Me.aidezguidetv = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripOntop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripCategories = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDescription = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripCalendar = New System.Windows.Forms.ToolStripButton()
        Me.RechercheToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripPreferences = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLogos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripUpdate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDualMonitor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripAutoUpdate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripHelptopics = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripHelpShortcuts = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripAbout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLangue = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripManualFeedBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripForum = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripWebsite = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripCheckupdates = New System.Windows.Forms.ToolStripButton()
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
        Me.ToolStripMenuCategories = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuDescription = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuCalendar = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechercheInfosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuEditPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuPrintTonight = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptionsUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptionsAutoUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuOptionsPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuOptionsLogos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuOptionsDualMonitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuOptionsEngineSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpHelptopics = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpHelpShortcuts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuHelpWebsite = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpForum = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpDonate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuHelpManualFeedBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpCheckupdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpPlugins = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpCompensation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuHelpContent = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpWeather = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuHelpLocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.ImprimerLaDescriptionToolStripMenuItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuPrintDescript = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_date = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_heure = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelCompensation = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelMinutes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelActiveEngine = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelEngine = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelMemory = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelMemoryUsage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelWeatherImage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelWeather = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelWakeUp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelAudio = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabeliMON = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabelStatusInternet = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer_seconde = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_glob_devant = New System.Windows.Forms.Panel()
        Me.Panel_devant = New System.Windows.Forms.Panel()
        Me.LbLoader1 = New ZGuideTV.lbLoader()
        Me.Timer_500msec = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripMenuNews = New System.Windows.Forms.Label()
        Me.TimerUsageMemory = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_cinema = New System.Windows.Forms.Panel()
        Me.Timer_cinema = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_wait = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_heure = New System.Windows.Forms.Timer(Me.components)
        Me.RichTextBoxDescrip = New ZGuideTVDotNet.Description.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl()
        Me.Context_menu_KTV.SuspendLayout()
        Me.PanelE.SuspendLayout()
        Me.Panel_glob_maintenant.SuspendLayout()
        Me.Panel_glob_ce_soir.SuspendLayout()
        Me.Calendar.SuspendLayout()
        CType(Me.premiere, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Soustitre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AudioStereo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Signaletique_43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Signaletique_169, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture_18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture_16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture_12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture_10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.panel_droit.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ImprimerLaDescriptionToolStripMenuItem.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.Panel_glob_devant.SuspendLayout()
        Me.Panel_devant.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenu = Me.ContextMenu1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "ZGuideTV.NET"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.SystrayMenuRestore, Me.MenuItem3, Me.SystrayMenuExit})
        '
        'SystrayMenuRestore
        '
        Me.SystrayMenuRestore.Index = 0
        Me.SystrayMenuRestore.Text = "Restaurer"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "-"
        '
        'SystrayMenuExit
        '
        Me.SystrayMenuExit.Index = 2
        Me.SystrayMenuExit.Text = "Quitter"
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(-7, 39)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Categories"
        TreeNode1.Text = "Catégories"
        TreeNode2.Name = "Pays"
        TreeNode2.Text = "Pays"
        TreeNode3.Name = "Fournisseurs"
        TreeNode3.Text = "Fournisseurs"
        TreeNode4.Checked = True
        TreeNode4.Name = "Noeud0"
        TreeNode4.Text = "Filtres"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4})
        Me.TreeView1.Scrollable = False
        Me.TreeView1.Size = New System.Drawing.Size(148, 614)
        Me.TreeView1.TabIndex = 2
        '
        'ListViewChannel
        '
        Me.ListViewChannel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewChannel.BackColor = System.Drawing.Color.White
        Me.ListViewChannel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListViewChannel.Location = New System.Drawing.Point(160, 88)
        Me.ListViewChannel.Name = "ListViewChannel"
        Me.ListViewChannel.Scrollable = False
        Me.ListViewChannel.Size = New System.Drawing.Size(149, 529)
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
        'Context_menu_KTV
        '
        Me.Context_menu_KTV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionDeKTVToolStripMenuItem1, Me.GestionDeMeuhMeuhTVToolStripMenuItem1})
        Me.Context_menu_KTV.Name = "ContextMenuktv"
        Me.Context_menu_KTV.Size = New System.Drawing.Size(151, 48)
        '
        'GestionDeKTVToolStripMenuItem1
        '
        Me.GestionDeKTVToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuProgramKTV, Me.ToolStripMenuZapperKTV, Me.ToolStripSeparator23, Me.ToolStripMenuGestionRecordKTV, Me.ToolStripMenuGestionChainesKTV})
        Me.GestionDeKTVToolStripMenuItem1.Image = CType(resources.GetObject("GestionDeKTVToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.GestionDeKTVToolStripMenuItem1.Name = "GestionDeKTVToolStripMenuItem1"
        Me.GestionDeKTVToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.GestionDeKTVToolStripMenuItem1.Text = "K!TV"
        '
        'ToolStripMenuProgramKTV
        '
        Me.ToolStripMenuProgramKTV.Name = "ToolStripMenuProgramKTV"
        Me.ToolStripMenuProgramKTV.Size = New System.Drawing.Size(250, 22)
        Me.ToolStripMenuProgramKTV.Text = "Programmer K!TV..."
        '
        'ToolStripMenuZapperKTV
        '
        Me.ToolStripMenuZapperKTV.Image = CType(resources.GetObject("ToolStripMenuZapperKTV.Image"), System.Drawing.Image)
        Me.ToolStripMenuZapperKTV.Name = "ToolStripMenuZapperKTV"
        Me.ToolStripMenuZapperKTV.Size = New System.Drawing.Size(250, 22)
        Me.ToolStripMenuZapperKTV.Text = "Zapper dans K!TV..."
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(247, 6)
        '
        'ToolStripMenuGestionRecordKTV
        '
        Me.ToolStripMenuGestionRecordKTV.Image = CType(resources.GetObject("ToolStripMenuGestionRecordKTV.Image"), System.Drawing.Image)
        Me.ToolStripMenuGestionRecordKTV.Name = "ToolStripMenuGestionRecordKTV"
        Me.ToolStripMenuGestionRecordKTV.Size = New System.Drawing.Size(250, 22)
        Me.ToolStripMenuGestionRecordKTV.Text = "Gestion des enregistrements K!TV"
        '
        'ToolStripMenuGestionChainesKTV
        '
        Me.ToolStripMenuGestionChainesKTV.Name = "ToolStripMenuGestionChainesKTV"
        Me.ToolStripMenuGestionChainesKTV.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.ToolStripMenuGestionChainesKTV.Size = New System.Drawing.Size(250, 22)
        Me.ToolStripMenuGestionChainesKTV.Text = "Gestion des chaînes K!TV"
        '
        'GestionDeMeuhMeuhTVToolStripMenuItem1
        '
        Me.GestionDeMeuhMeuhTVToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuProgramMMTV, Me.ToolStripMenuZapperMMTV, Me.ToolStripSeparator24, Me.ToolStripMenuGestionRecordMMTV, Me.ToolStripMenuGestionChainesMMTV})
        Me.GestionDeMeuhMeuhTVToolStripMenuItem1.Name = "GestionDeMeuhMeuhTVToolStripMenuItem1"
        Me.GestionDeMeuhMeuhTVToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.GestionDeMeuhMeuhTVToolStripMenuItem1.Text = "MeuhMeuhTV"
        '
        'ToolStripMenuProgramMMTV
        '
        Me.ToolStripMenuProgramMMTV.Name = "ToolStripMenuProgramMMTV"
        Me.ToolStripMenuProgramMMTV.Size = New System.Drawing.Size(302, 22)
        Me.ToolStripMenuProgramMMTV.Text = "Programmer MeuhMeuhTV..."
        '
        'ToolStripMenuZapperMMTV
        '
        Me.ToolStripMenuZapperMMTV.Image = CType(resources.GetObject("ToolStripMenuZapperMMTV.Image"), System.Drawing.Image)
        Me.ToolStripMenuZapperMMTV.Name = "ToolStripMenuZapperMMTV"
        Me.ToolStripMenuZapperMMTV.Size = New System.Drawing.Size(302, 22)
        Me.ToolStripMenuZapperMMTV.Text = "Zapper dans MeuhMeuhTV..."
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(299, 6)
        '
        'ToolStripMenuGestionRecordMMTV
        '
        Me.ToolStripMenuGestionRecordMMTV.Image = CType(resources.GetObject("ToolStripMenuGestionRecordMMTV.Image"), System.Drawing.Image)
        Me.ToolStripMenuGestionRecordMMTV.Name = "ToolStripMenuGestionRecordMMTV"
        Me.ToolStripMenuGestionRecordMMTV.Size = New System.Drawing.Size(302, 22)
        Me.ToolStripMenuGestionRecordMMTV.Text = "Gestion des enregistrements MeuhMeuhTV"
        '
        'ToolStripMenuGestionChainesMMTV
        '
        Me.ToolStripMenuGestionChainesMMTV.Name = "ToolStripMenuGestionChainesMMTV"
        Me.ToolStripMenuGestionChainesMMTV.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ToolStripMenuGestionChainesMMTV.Size = New System.Drawing.Size(302, 22)
        Me.ToolStripMenuGestionChainesMMTV.Text = "Gestion des chaînes MeuhMeuhTV"
        '
        'Timer_minute
        '
        Me.Timer_minute.Enabled = True
        Me.Timer_minute.Interval = 60000
        '
        'PanelC
        '
        Me.PanelC.BackColor = System.Drawing.Color.White
        Me.PanelC.Location = New System.Drawing.Point(251, 100)
        Me.PanelC.Name = "PanelC"
        Me.PanelC.Size = New System.Drawing.Size(20, 217)
        Me.PanelC.TabIndex = 51
        '
        'PanelD
        '
        Me.PanelD.BackColor = System.Drawing.Color.White
        Me.PanelD.Location = New System.Drawing.Point(345, 76)
        Me.PanelD.Name = "PanelD"
        Me.PanelD.Size = New System.Drawing.Size(111, 32)
        Me.PanelD.TabIndex = 52
        '
        'PanelE
        '
        Me.PanelE.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelE.BackColor = System.Drawing.Color.White
        Me.PanelE.Controls.Add(Me.navigtemporelle)
        Me.PanelE.Location = New System.Drawing.Point(328, 404)
        Me.PanelE.Name = "PanelE"
        Me.PanelE.Size = New System.Drawing.Size(363, 61)
        Me.PanelE.TabIndex = 53
        Me.PanelE.TabStop = True
        '
        'navigtemporelle
        '
        Me.navigtemporelle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.navigtemporelle.BackColor = System.Drawing.Color.White
        Me.navigtemporelle.Enabled_Button = True
        Me.navigtemporelle.Location = New System.Drawing.Point(0, 0)
        Me.navigtemporelle.Name = "navigtemporelle"
        Me.navigtemporelle.old_UI = True
        Me.navigtemporelle.Size = New System.Drawing.Size(363, 43)
        Me.navigtemporelle.TabIndex = 0
        Me.navigtemporelle.Text_06h = "06H"
        Me.navigtemporelle.Text_09h = "09H"
        Me.navigtemporelle.Text_12h = "12H"
        Me.navigtemporelle.Text_15h = "15H"
        Me.navigtemporelle.Text_18h = "18H"
        Me.navigtemporelle.Text_20h = "20H"
        Me.navigtemporelle.Text_23h = "23H"
        Me.navigtemporelle.Text_HeureMoins = "Heure -1"
        Me.navigtemporelle.Text_HeurePlus = "Heure +1"
        Me.navigtemporelle.Text_JourMoins = "Jour -1"
        Me.navigtemporelle.Text_JourPlus = "Jour +1"
        Me.navigtemporelle.Text_Maintenant = "Maintenant"
        '
        'PanelB
        '
        Me.PanelB.BackColor = System.Drawing.Color.White
        Me.PanelB.Location = New System.Drawing.Point(192, 110)
        Me.PanelB.Name = "PanelB"
        Me.PanelB.Size = New System.Drawing.Size(30, 206)
        Me.PanelB.TabIndex = 54
        '
        'Panel_date
        '
        Me.Panel_date.Location = New System.Drawing.Point(345, 134)
        Me.Panel_date.Name = "Panel_date"
        Me.Panel_date.Size = New System.Drawing.Size(90, 31)
        Me.Panel_date.TabIndex = 55
        '
        'PanelA
        '
        Me.PanelA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelA.ContextMenuStrip = Me.Context_menu_KTV
        Me.PanelA.Location = New System.Drawing.Point(345, 197)
        Me.PanelA.Name = "PanelA"
        Me.PanelA.Size = New System.Drawing.Size(264, 133)
        Me.PanelA.TabIndex = 56
        '
        'Panel_glob_maintenant
        '
        Me.Panel_glob_maintenant.BackColor = System.Drawing.Color.White
        Me.Panel_glob_maintenant.Controls.Add(Me.Panel_titre_maintenant)
        Me.Panel_glob_maintenant.Controls.Add(Me.Panel_maintenant)
        Me.Panel_glob_maintenant.Location = New System.Drawing.Point(0, 320)
        Me.Panel_glob_maintenant.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel_glob_maintenant.Name = "Panel_glob_maintenant"
        Me.Panel_glob_maintenant.Size = New System.Drawing.Size(260, 320)
        Me.Panel_glob_maintenant.TabIndex = 58
        '
        'Panel_titre_maintenant
        '
        Me.Panel_titre_maintenant.BackColor = System.Drawing.Color.White
        Me.Panel_titre_maintenant.Location = New System.Drawing.Point(40, 36)
        Me.Panel_titre_maintenant.Name = "Panel_titre_maintenant"
        Me.Panel_titre_maintenant.Size = New System.Drawing.Size(112, 28)
        Me.Panel_titre_maintenant.TabIndex = 61
        Me.Panel_titre_maintenant.Text = "Maintenant"
        Me.Panel_titre_maintenant.UseVisualStyleBackColor = False
        '
        'Panel_maintenant
        '
        Me.Panel_maintenant.BackColor = System.Drawing.Color.White
        Me.Panel_maintenant.Location = New System.Drawing.Point(40, 76)
        Me.Panel_maintenant.Name = "Panel_maintenant"
        Me.Panel_maintenant.Size = New System.Drawing.Size(117, 232)
        Me.Panel_maintenant.TabIndex = 1
        '
        'Panel_glob_ce_soir
        '
        Me.Panel_glob_ce_soir.BackColor = System.Drawing.Color.White
        Me.Panel_glob_ce_soir.Controls.Add(Me.Panel_titre_ce_soir)
        Me.Panel_glob_ce_soir.Controls.Add(Me.Panel_ce_soir)
        Me.Panel_glob_ce_soir.Location = New System.Drawing.Point(4, 188)
        Me.Panel_glob_ce_soir.Name = "Panel_glob_ce_soir"
        Me.Panel_glob_ce_soir.Size = New System.Drawing.Size(260, 128)
        Me.Panel_glob_ce_soir.TabIndex = 59
        '
        'Panel_titre_ce_soir
        '
        Me.Panel_titre_ce_soir.BackColor = System.Drawing.Color.White
        Me.Panel_titre_ce_soir.Location = New System.Drawing.Point(36, 20)
        Me.Panel_titre_ce_soir.Name = "Panel_titre_ce_soir"
        Me.Panel_titre_ce_soir.Size = New System.Drawing.Size(112, 32)
        Me.Panel_titre_ce_soir.TabIndex = 3
        Me.Panel_titre_ce_soir.Text = "Ce soir"
        Me.Panel_titre_ce_soir.UseVisualStyleBackColor = False
        '
        'Panel_ce_soir
        '
        Me.Panel_ce_soir.BackColor = System.Drawing.Color.White
        Me.Panel_ce_soir.Location = New System.Drawing.Point(36, 72)
        Me.Panel_ce_soir.Name = "Panel_ce_soir"
        Me.Panel_ce_soir.Size = New System.Drawing.Size(113, 25)
        Me.Panel_ce_soir.TabIndex = 1
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Panel1
        '
        Me.Panel1.ContextMenuStrip = Me.Context_menu_KTV
        Me.Panel1.Location = New System.Drawing.Point(756, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 160)
        Me.Panel1.TabIndex = 1
        '
        'Calendar
        '
        Me.Calendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
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
        Me.Calendar.Controls.Add(Me.MoisS)
        Me.Calendar.Controls.Add(Me.Button4_7)
        Me.Calendar.Controls.Add(Me.MoisP)
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
        Me.Button5_3.BGColor = System.Drawing.Color.Black
        Me.Button5_3.BordersColor = System.Drawing.Color.White
        Me.Button5_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_3.ForeColor = System.Drawing.Color.White
        Me.Button5_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_3.Location = New System.Drawing.Point(80, 120)
        Me.Button5_3.Name = "Button5_3"
        Me.Button5_3.old_UI = True
        Me.Button5_3.Size = New System.Drawing.Size(28, 18)
        Me.Button5_3.TabIndex = 81
        Me.Button5_3.TopColor = System.Drawing.Color.White
        '
        'Button6_7
        '
        Me.Button6_7.Align = System.Drawing.StringAlignment.Center
        Me.Button6_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_7.BGColor = System.Drawing.Color.Black
        Me.Button6_7.BordersColor = System.Drawing.Color.White
        Me.Button6_7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_7.ForeColor = System.Drawing.Color.White
        Me.Button6_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_7.Location = New System.Drawing.Point(204, 139)
        Me.Button6_7.Name = "Button6_7"
        Me.Button6_7.old_UI = True
        Me.Button6_7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_7.Size = New System.Drawing.Size(28, 18)
        Me.Button6_7.TabIndex = 95
        Me.Button6_7.TopColor = System.Drawing.Color.White
        '
        'Button5_2
        '
        Me.Button5_2.Align = System.Drawing.StringAlignment.Center
        Me.Button5_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_2.BGColor = System.Drawing.Color.Black
        Me.Button5_2.BordersColor = System.Drawing.Color.White
        Me.Button5_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_2.ForeColor = System.Drawing.Color.White
        Me.Button5_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_2.Location = New System.Drawing.Point(49, 120)
        Me.Button5_2.Name = "Button5_2"
        Me.Button5_2.old_UI = True
        Me.Button5_2.Size = New System.Drawing.Size(28, 18)
        Me.Button5_2.TabIndex = 80
        Me.Button5_2.TopColor = System.Drawing.Color.White
        '
        'Button3_2
        '
        Me.Button3_2.Align = System.Drawing.StringAlignment.Center
        Me.Button3_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_2.BGColor = System.Drawing.Color.Black
        Me.Button3_2.BordersColor = System.Drawing.Color.White
        Me.Button3_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_2.ForeColor = System.Drawing.Color.White
        Me.Button3_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_2.Location = New System.Drawing.Point(49, 82)
        Me.Button3_2.Name = "Button3_2"
        Me.Button3_2.old_UI = True
        Me.Button3_2.Size = New System.Drawing.Size(28, 18)
        Me.Button3_2.TabIndex = 66
        Me.Button3_2.TopColor = System.Drawing.Color.White
        '
        'Button5_7
        '
        Me.Button5_7.Align = System.Drawing.StringAlignment.Center
        Me.Button5_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_7.BGColor = System.Drawing.Color.Black
        Me.Button5_7.BordersColor = System.Drawing.Color.White
        Me.Button5_7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_7.ForeColor = System.Drawing.Color.White
        Me.Button5_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_7.Location = New System.Drawing.Point(204, 120)
        Me.Button5_7.Name = "Button5_7"
        Me.Button5_7.old_UI = True
        Me.Button5_7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button5_7.Size = New System.Drawing.Size(28, 18)
        Me.Button5_7.TabIndex = 88
        Me.Button5_7.TopColor = System.Drawing.Color.White
        '
        'Button5_1
        '
        Me.Button5_1.Align = System.Drawing.StringAlignment.Center
        Me.Button5_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_1.BGColor = System.Drawing.Color.Black
        Me.Button5_1.BordersColor = System.Drawing.Color.White
        Me.Button5_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_1.ForeColor = System.Drawing.Color.White
        Me.Button5_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_1.Location = New System.Drawing.Point(18, 120)
        Me.Button5_1.Name = "Button5_1"
        Me.Button5_1.old_UI = True
        Me.Button5_1.Size = New System.Drawing.Size(28, 18)
        Me.Button5_1.TabIndex = 79
        Me.Button5_1.TopColor = System.Drawing.Color.White
        '
        'Button6_1
        '
        Me.Button6_1.Align = System.Drawing.StringAlignment.Center
        Me.Button6_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_1.BGColor = System.Drawing.Color.Black
        Me.Button6_1.BordersColor = System.Drawing.Color.White
        Me.Button6_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_1.ForeColor = System.Drawing.Color.White
        Me.Button6_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_1.Location = New System.Drawing.Point(18, 139)
        Me.Button6_1.Name = "Button6_1"
        Me.Button6_1.old_UI = True
        Me.Button6_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_1.Size = New System.Drawing.Size(28, 18)
        Me.Button6_1.TabIndex = 90
        Me.Button6_1.TopColor = System.Drawing.Color.White
        '
        'L_MOIS_ANNEE
        '
        Me.L_MOIS_ANNEE.BackColor = System.Drawing.Color.Transparent
        Me.L_MOIS_ANNEE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_MOIS_ANNEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.L_MOIS_ANNEE.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_MOIS_ANNEE.Location = New System.Drawing.Point(33, 3)
        Me.L_MOIS_ANNEE.Name = "L_MOIS_ANNEE"
        Me.L_MOIS_ANNEE.Size = New System.Drawing.Size(183, 17)
        Me.L_MOIS_ANNEE.TabIndex = 82
        Me.L_MOIS_ANNEE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MoisS
        '
        Me.MoisS.ContextMenuStrip = Me.Context_menu_KTV
        Me.MoisS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoisS.Location = New System.Drawing.Point(222, 1)
        Me.MoisS.Name = "MoisS"
        Me.MoisS.Size = New System.Drawing.Size(24, 21)
        Me.MoisS.TabIndex = 86
        Me.MoisS.Text = ">"
        Me.MoisS.UseVisualStyleBackColor = False
        '
        'Button4_7
        '
        Me.Button4_7.Align = System.Drawing.StringAlignment.Center
        Me.Button4_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_7.BGColor = System.Drawing.Color.Black
        Me.Button4_7.BordersColor = System.Drawing.Color.White
        Me.Button4_7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_7.ForeColor = System.Drawing.Color.White
        Me.Button4_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_7.Location = New System.Drawing.Point(204, 101)
        Me.Button4_7.Name = "Button4_7"
        Me.Button4_7.old_UI = True
        Me.Button4_7.Size = New System.Drawing.Size(28, 18)
        Me.Button4_7.TabIndex = 78
        Me.Button4_7.TopColor = System.Drawing.Color.White
        '
        'MoisP
        '
        Me.MoisP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoisP.Location = New System.Drawing.Point(3, 1)
        Me.MoisP.Name = "MoisP"
        Me.MoisP.Size = New System.Drawing.Size(24, 21)
        Me.MoisP.TabIndex = 83
        Me.MoisP.Text = "<"
        Me.MoisP.UseVisualStyleBackColor = False
        '
        'Button6_6
        '
        Me.Button6_6.Align = System.Drawing.StringAlignment.Center
        Me.Button6_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_6.BGColor = System.Drawing.Color.Black
        Me.Button6_6.BordersColor = System.Drawing.Color.White
        Me.Button6_6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_6.ForeColor = System.Drawing.Color.White
        Me.Button6_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_6.Location = New System.Drawing.Point(173, 139)
        Me.Button6_6.Name = "Button6_6"
        Me.Button6_6.old_UI = True
        Me.Button6_6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_6.Size = New System.Drawing.Size(28, 18)
        Me.Button6_6.TabIndex = 94
        Me.Button6_6.TopColor = System.Drawing.Color.White
        '
        'Button4_6
        '
        Me.Button4_6.Align = System.Drawing.StringAlignment.Center
        Me.Button4_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_6.BGColor = System.Drawing.Color.Black
        Me.Button4_6.BordersColor = System.Drawing.Color.White
        Me.Button4_6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_6.ForeColor = System.Drawing.Color.White
        Me.Button4_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_6.Location = New System.Drawing.Point(173, 101)
        Me.Button4_6.Name = "Button4_6"
        Me.Button4_6.old_UI = True
        Me.Button4_6.Size = New System.Drawing.Size(28, 18)
        Me.Button4_6.TabIndex = 77
        Me.Button4_6.TopColor = System.Drawing.Color.White
        '
        'Button5_6
        '
        Me.Button5_6.Align = System.Drawing.StringAlignment.Center
        Me.Button5_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_6.BGColor = System.Drawing.Color.Black
        Me.Button5_6.BordersColor = System.Drawing.Color.White
        Me.Button5_6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_6.ForeColor = System.Drawing.Color.White
        Me.Button5_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_6.Location = New System.Drawing.Point(173, 120)
        Me.Button5_6.Name = "Button5_6"
        Me.Button5_6.old_UI = True
        Me.Button5_6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button5_6.Size = New System.Drawing.Size(28, 18)
        Me.Button5_6.TabIndex = 87
        Me.Button5_6.TopColor = System.Drawing.Color.White
        '
        'Button3_4
        '
        Me.Button3_4.Align = System.Drawing.StringAlignment.Center
        Me.Button3_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_4.BGColor = System.Drawing.Color.Black
        Me.Button3_4.BordersColor = System.Drawing.Color.White
        Me.Button3_4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_4.ForeColor = System.Drawing.Color.White
        Me.Button3_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_4.Location = New System.Drawing.Point(111, 82)
        Me.Button3_4.Name = "Button3_4"
        Me.Button3_4.old_UI = True
        Me.Button3_4.Size = New System.Drawing.Size(28, 18)
        Me.Button3_4.TabIndex = 85
        Me.Button3_4.TopColor = System.Drawing.Color.White
        '
        'Button6_4
        '
        Me.Button6_4.Align = System.Drawing.StringAlignment.Center
        Me.Button6_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_4.BGColor = System.Drawing.Color.Black
        Me.Button6_4.BordersColor = System.Drawing.Color.White
        Me.Button6_4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_4.ForeColor = System.Drawing.Color.White
        Me.Button6_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_4.Location = New System.Drawing.Point(111, 139)
        Me.Button6_4.Name = "Button6_4"
        Me.Button6_4.old_UI = True
        Me.Button6_4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_4.Size = New System.Drawing.Size(28, 18)
        Me.Button6_4.TabIndex = 93
        Me.Button6_4.TopColor = System.Drawing.Color.White
        '
        'Button4_5
        '
        Me.Button4_5.Align = System.Drawing.StringAlignment.Center
        Me.Button4_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_5.BGColor = System.Drawing.Color.Black
        Me.Button4_5.BordersColor = System.Drawing.Color.White
        Me.Button4_5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_5.ForeColor = System.Drawing.Color.White
        Me.Button4_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_5.Location = New System.Drawing.Point(142, 101)
        Me.Button4_5.Name = "Button4_5"
        Me.Button4_5.old_UI = True
        Me.Button4_5.Size = New System.Drawing.Size(28, 18)
        Me.Button4_5.TabIndex = 76
        Me.Button4_5.TopColor = System.Drawing.Color.White
        '
        'Button6_5
        '
        Me.Button6_5.Align = System.Drawing.StringAlignment.Center
        Me.Button6_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_5.BGColor = System.Drawing.Color.Black
        Me.Button6_5.BordersColor = System.Drawing.Color.White
        Me.Button6_5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_5.ForeColor = System.Drawing.Color.White
        Me.Button6_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_5.Location = New System.Drawing.Point(142, 139)
        Me.Button6_5.Name = "Button6_5"
        Me.Button6_5.old_UI = True
        Me.Button6_5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_5.Size = New System.Drawing.Size(28, 18)
        Me.Button6_5.TabIndex = 89
        Me.Button6_5.TopColor = System.Drawing.Color.White
        '
        'Button4_4
        '
        Me.Button4_4.Align = System.Drawing.StringAlignment.Center
        Me.Button4_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_4.BGColor = System.Drawing.Color.Black
        Me.Button4_4.BordersColor = System.Drawing.Color.White
        Me.Button4_4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_4.ForeColor = System.Drawing.Color.White
        Me.Button4_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_4.Location = New System.Drawing.Point(111, 101)
        Me.Button4_4.Name = "Button4_4"
        Me.Button4_4.old_UI = True
        Me.Button4_4.Size = New System.Drawing.Size(28, 18)
        Me.Button4_4.TabIndex = 75
        Me.Button4_4.TopColor = System.Drawing.Color.White
        '
        'Button5_4
        '
        Me.Button5_4.Align = System.Drawing.StringAlignment.Center
        Me.Button5_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_4.BGColor = System.Drawing.Color.Black
        Me.Button5_4.BordersColor = System.Drawing.Color.White
        Me.Button5_4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_4.ForeColor = System.Drawing.Color.White
        Me.Button5_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_4.Location = New System.Drawing.Point(111, 120)
        Me.Button5_4.Name = "Button5_4"
        Me.Button5_4.old_UI = True
        Me.Button5_4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button5_4.Size = New System.Drawing.Size(28, 18)
        Me.Button5_4.TabIndex = 84
        Me.Button5_4.TopColor = System.Drawing.Color.White
        '
        'Button6_3
        '
        Me.Button6_3.Align = System.Drawing.StringAlignment.Center
        Me.Button6_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_3.BGColor = System.Drawing.Color.Black
        Me.Button6_3.BordersColor = System.Drawing.Color.White
        Me.Button6_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_3.ForeColor = System.Drawing.Color.White
        Me.Button6_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_3.Location = New System.Drawing.Point(80, 139)
        Me.Button6_3.Name = "Button6_3"
        Me.Button6_3.old_UI = True
        Me.Button6_3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_3.Size = New System.Drawing.Size(28, 18)
        Me.Button6_3.TabIndex = 92
        Me.Button6_3.TopColor = System.Drawing.Color.White
        '
        'Button4_3
        '
        Me.Button4_3.Align = System.Drawing.StringAlignment.Center
        Me.Button4_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_3.BGColor = System.Drawing.Color.Black
        Me.Button4_3.BordersColor = System.Drawing.Color.White
        Me.Button4_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_3.ForeColor = System.Drawing.Color.White
        Me.Button4_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_3.Location = New System.Drawing.Point(80, 101)
        Me.Button4_3.Name = "Button4_3"
        Me.Button4_3.old_UI = True
        Me.Button4_3.Size = New System.Drawing.Size(28, 18)
        Me.Button4_3.TabIndex = 74
        Me.Button4_3.TopColor = System.Drawing.Color.White
        '
        'Button5_5
        '
        Me.Button5_5.Align = System.Drawing.StringAlignment.Center
        Me.Button5_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5_5.BGColor = System.Drawing.Color.Black
        Me.Button5_5.BordersColor = System.Drawing.Color.White
        Me.Button5_5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button5_5.ForeColor = System.Drawing.Color.White
        Me.Button5_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5_5.Location = New System.Drawing.Point(142, 120)
        Me.Button5_5.Name = "Button5_5"
        Me.Button5_5.old_UI = True
        Me.Button5_5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button5_5.Size = New System.Drawing.Size(28, 18)
        Me.Button5_5.TabIndex = 67
        Me.Button5_5.TopColor = System.Drawing.Color.White
        '
        'Button4_2
        '
        Me.Button4_2.Align = System.Drawing.StringAlignment.Center
        Me.Button4_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_2.BGColor = System.Drawing.Color.Black
        Me.Button4_2.BordersColor = System.Drawing.Color.White
        Me.Button4_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_2.ForeColor = System.Drawing.Color.White
        Me.Button4_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_2.Location = New System.Drawing.Point(49, 101)
        Me.Button4_2.Name = "Button4_2"
        Me.Button4_2.old_UI = True
        Me.Button4_2.Size = New System.Drawing.Size(28, 18)
        Me.Button4_2.TabIndex = 73
        Me.Button4_2.TopColor = System.Drawing.Color.White
        '
        'Button6_2
        '
        Me.Button6_2.Align = System.Drawing.StringAlignment.Center
        Me.Button6_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6_2.BGColor = System.Drawing.Color.Black
        Me.Button6_2.BordersColor = System.Drawing.Color.White
        Me.Button6_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button6_2.ForeColor = System.Drawing.Color.White
        Me.Button6_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6_2.Location = New System.Drawing.Point(49, 139)
        Me.Button6_2.Name = "Button6_2"
        Me.Button6_2.old_UI = True
        Me.Button6_2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6_2.Size = New System.Drawing.Size(28, 18)
        Me.Button6_2.TabIndex = 91
        Me.Button6_2.TopColor = System.Drawing.Color.White
        '
        'Button4_1
        '
        Me.Button4_1.Align = System.Drawing.StringAlignment.Center
        Me.Button4_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4_1.BGColor = System.Drawing.Color.Black
        Me.Button4_1.BordersColor = System.Drawing.Color.White
        Me.Button4_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button4_1.ForeColor = System.Drawing.Color.White
        Me.Button4_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4_1.Location = New System.Drawing.Point(18, 101)
        Me.Button4_1.Name = "Button4_1"
        Me.Button4_1.old_UI = True
        Me.Button4_1.Size = New System.Drawing.Size(28, 18)
        Me.Button4_1.TabIndex = 72
        Me.Button4_1.TopColor = System.Drawing.Color.White
        '
        'Button3_7
        '
        Me.Button3_7.Align = System.Drawing.StringAlignment.Center
        Me.Button3_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_7.BGColor = System.Drawing.Color.Black
        Me.Button3_7.BordersColor = System.Drawing.Color.White
        Me.Button3_7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_7.ForeColor = System.Drawing.Color.White
        Me.Button3_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_7.Location = New System.Drawing.Point(204, 82)
        Me.Button3_7.Name = "Button3_7"
        Me.Button3_7.old_UI = True
        Me.Button3_7.Size = New System.Drawing.Size(28, 18)
        Me.Button3_7.TabIndex = 71
        Me.Button3_7.TopColor = System.Drawing.Color.White
        '
        'Button3_6
        '
        Me.Button3_6.Align = System.Drawing.StringAlignment.Center
        Me.Button3_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_6.BGColor = System.Drawing.Color.Black
        Me.Button3_6.BordersColor = System.Drawing.Color.White
        Me.Button3_6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_6.ForeColor = System.Drawing.Color.White
        Me.Button3_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_6.Location = New System.Drawing.Point(173, 82)
        Me.Button3_6.Name = "Button3_6"
        Me.Button3_6.old_UI = True
        Me.Button3_6.Size = New System.Drawing.Size(28, 18)
        Me.Button3_6.TabIndex = 70
        Me.Button3_6.TopColor = System.Drawing.Color.White
        '
        'Button3_5
        '
        Me.Button3_5.Align = System.Drawing.StringAlignment.Center
        Me.Button3_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_5.BGColor = System.Drawing.Color.Black
        Me.Button3_5.BordersColor = System.Drawing.Color.White
        Me.Button3_5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_5.ForeColor = System.Drawing.Color.White
        Me.Button3_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_5.Location = New System.Drawing.Point(142, 82)
        Me.Button3_5.Name = "Button3_5"
        Me.Button3_5.old_UI = True
        Me.Button3_5.Size = New System.Drawing.Size(28, 18)
        Me.Button3_5.TabIndex = 69
        Me.Button3_5.TopColor = System.Drawing.Color.White
        '
        'Button3_3
        '
        Me.Button3_3.Align = System.Drawing.StringAlignment.Center
        Me.Button3_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_3.BGColor = System.Drawing.Color.Black
        Me.Button3_3.BordersColor = System.Drawing.Color.White
        Me.Button3_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_3.ForeColor = System.Drawing.Color.White
        Me.Button3_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_3.Location = New System.Drawing.Point(80, 82)
        Me.Button3_3.Name = "Button3_3"
        Me.Button3_3.old_UI = True
        Me.Button3_3.Size = New System.Drawing.Size(28, 18)
        Me.Button3_3.TabIndex = 68
        Me.Button3_3.TopColor = System.Drawing.Color.White
        '
        'Button3_1
        '
        Me.Button3_1.Align = System.Drawing.StringAlignment.Center
        Me.Button3_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3_1.BGColor = System.Drawing.Color.Black
        Me.Button3_1.BordersColor = System.Drawing.Color.White
        Me.Button3_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button3_1.ForeColor = System.Drawing.Color.White
        Me.Button3_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3_1.Location = New System.Drawing.Point(18, 82)
        Me.Button3_1.Name = "Button3_1"
        Me.Button3_1.old_UI = True
        Me.Button3_1.Size = New System.Drawing.Size(28, 18)
        Me.Button3_1.TabIndex = 65
        Me.Button3_1.TopColor = System.Drawing.Color.White
        '
        'Button2_1
        '
        Me.Button2_1.Align = System.Drawing.StringAlignment.Center
        Me.Button2_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_1.BGColor = System.Drawing.Color.Black
        Me.Button2_1.BordersColor = System.Drawing.Color.White
        Me.Button2_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_1.ForeColor = System.Drawing.Color.White
        Me.Button2_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_1.Location = New System.Drawing.Point(18, 63)
        Me.Button2_1.Name = "Button2_1"
        Me.Button2_1.old_UI = True
        Me.Button2_1.Size = New System.Drawing.Size(28, 18)
        Me.Button2_1.TabIndex = 64
        Me.Button2_1.TopColor = System.Drawing.Color.White
        '
        'Button2_2
        '
        Me.Button2_2.Align = System.Drawing.StringAlignment.Center
        Me.Button2_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_2.BGColor = System.Drawing.Color.Black
        Me.Button2_2.BordersColor = System.Drawing.Color.White
        Me.Button2_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_2.ForeColor = System.Drawing.Color.White
        Me.Button2_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_2.Location = New System.Drawing.Point(49, 63)
        Me.Button2_2.Name = "Button2_2"
        Me.Button2_2.old_UI = True
        Me.Button2_2.Size = New System.Drawing.Size(28, 18)
        Me.Button2_2.TabIndex = 63
        Me.Button2_2.TopColor = System.Drawing.Color.White
        '
        'Button2_3
        '
        Me.Button2_3.Align = System.Drawing.StringAlignment.Center
        Me.Button2_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_3.BGColor = System.Drawing.Color.Black
        Me.Button2_3.BordersColor = System.Drawing.Color.White
        Me.Button2_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_3.ForeColor = System.Drawing.Color.White
        Me.Button2_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_3.Location = New System.Drawing.Point(80, 63)
        Me.Button2_3.Name = "Button2_3"
        Me.Button2_3.old_UI = True
        Me.Button2_3.Size = New System.Drawing.Size(28, 18)
        Me.Button2_3.TabIndex = 58
        Me.Button2_3.TopColor = System.Drawing.Color.White
        '
        'Button2_4
        '
        Me.Button2_4.Align = System.Drawing.StringAlignment.Center
        Me.Button2_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_4.BGColor = System.Drawing.Color.Black
        Me.Button2_4.BordersColor = System.Drawing.Color.White
        Me.Button2_4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_4.ForeColor = System.Drawing.Color.White
        Me.Button2_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_4.Location = New System.Drawing.Point(111, 63)
        Me.Button2_4.Name = "Button2_4"
        Me.Button2_4.old_UI = True
        Me.Button2_4.Size = New System.Drawing.Size(28, 18)
        Me.Button2_4.TabIndex = 62
        Me.Button2_4.TopColor = System.Drawing.Color.White
        '
        'Button2_5
        '
        Me.Button2_5.Align = System.Drawing.StringAlignment.Center
        Me.Button2_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_5.BGColor = System.Drawing.Color.Black
        Me.Button2_5.BordersColor = System.Drawing.Color.White
        Me.Button2_5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_5.ForeColor = System.Drawing.Color.White
        Me.Button2_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_5.Location = New System.Drawing.Point(142, 63)
        Me.Button2_5.Name = "Button2_5"
        Me.Button2_5.old_UI = True
        Me.Button2_5.Size = New System.Drawing.Size(28, 18)
        Me.Button2_5.TabIndex = 59
        Me.Button2_5.TopColor = System.Drawing.Color.White
        '
        'Button2_6
        '
        Me.Button2_6.Align = System.Drawing.StringAlignment.Center
        Me.Button2_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_6.BGColor = System.Drawing.Color.Black
        Me.Button2_6.BordersColor = System.Drawing.Color.White
        Me.Button2_6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_6.ForeColor = System.Drawing.Color.White
        Me.Button2_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_6.Location = New System.Drawing.Point(173, 63)
        Me.Button2_6.Name = "Button2_6"
        Me.Button2_6.old_UI = True
        Me.Button2_6.Size = New System.Drawing.Size(28, 18)
        Me.Button2_6.TabIndex = 61
        Me.Button2_6.TopColor = System.Drawing.Color.White
        '
        'Button2_7
        '
        Me.Button2_7.Align = System.Drawing.StringAlignment.Center
        Me.Button2_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2_7.BGColor = System.Drawing.Color.Black
        Me.Button2_7.BordersColor = System.Drawing.Color.White
        Me.Button2_7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button2_7.ForeColor = System.Drawing.Color.White
        Me.Button2_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2_7.Location = New System.Drawing.Point(204, 63)
        Me.Button2_7.Name = "Button2_7"
        Me.Button2_7.old_UI = True
        Me.Button2_7.Size = New System.Drawing.Size(28, 18)
        Me.Button2_7.TabIndex = 60
        Me.Button2_7.TopColor = System.Drawing.Color.White
        '
        'Button1_7
        '
        Me.Button1_7.Align = System.Drawing.StringAlignment.Center
        Me.Button1_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_7.BGColor = System.Drawing.Color.Black
        Me.Button1_7.BordersColor = System.Drawing.Color.White
        Me.Button1_7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_7.ForeColor = System.Drawing.Color.White
        Me.Button1_7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_7.Location = New System.Drawing.Point(204, 44)
        Me.Button1_7.Name = "Button1_7"
        Me.Button1_7.old_UI = True
        Me.Button1_7.Size = New System.Drawing.Size(28, 18)
        Me.Button1_7.TabIndex = 57
        Me.Button1_7.TopColor = System.Drawing.Color.White
        '
        'Button1_6
        '
        Me.Button1_6.Align = System.Drawing.StringAlignment.Center
        Me.Button1_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_6.BGColor = System.Drawing.Color.Black
        Me.Button1_6.BordersColor = System.Drawing.Color.White
        Me.Button1_6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_6.ForeColor = System.Drawing.Color.White
        Me.Button1_6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_6.Location = New System.Drawing.Point(173, 44)
        Me.Button1_6.Name = "Button1_6"
        Me.Button1_6.old_UI = True
        Me.Button1_6.Size = New System.Drawing.Size(28, 18)
        Me.Button1_6.TabIndex = 56
        Me.Button1_6.TopColor = System.Drawing.Color.White
        '
        'Button1_1
        '
        Me.Button1_1.Align = System.Drawing.StringAlignment.Center
        Me.Button1_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_1.BGColor = System.Drawing.Color.Black
        Me.Button1_1.BordersColor = System.Drawing.Color.White
        Me.Button1_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_1.ForeColor = System.Drawing.Color.White
        Me.Button1_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_1.Location = New System.Drawing.Point(18, 44)
        Me.Button1_1.Name = "Button1_1"
        Me.Button1_1.old_UI = True
        Me.Button1_1.Size = New System.Drawing.Size(28, 18)
        Me.Button1_1.TabIndex = 51
        Me.Button1_1.TopColor = System.Drawing.Color.White
        '
        'Button1_5
        '
        Me.Button1_5.Align = System.Drawing.StringAlignment.Center
        Me.Button1_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_5.BGColor = System.Drawing.Color.Black
        Me.Button1_5.BordersColor = System.Drawing.Color.White
        Me.Button1_5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_5.ForeColor = System.Drawing.Color.White
        Me.Button1_5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_5.Location = New System.Drawing.Point(142, 44)
        Me.Button1_5.Name = "Button1_5"
        Me.Button1_5.old_UI = True
        Me.Button1_5.Size = New System.Drawing.Size(28, 18)
        Me.Button1_5.TabIndex = 55
        Me.Button1_5.TopColor = System.Drawing.Color.White
        '
        'Button1_2
        '
        Me.Button1_2.Align = System.Drawing.StringAlignment.Center
        Me.Button1_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_2.BGColor = System.Drawing.Color.Black
        Me.Button1_2.BordersColor = System.Drawing.Color.White
        Me.Button1_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_2.ForeColor = System.Drawing.Color.White
        Me.Button1_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_2.Location = New System.Drawing.Point(49, 44)
        Me.Button1_2.Name = "Button1_2"
        Me.Button1_2.old_UI = True
        Me.Button1_2.Size = New System.Drawing.Size(28, 18)
        Me.Button1_2.TabIndex = 52
        Me.Button1_2.TopColor = System.Drawing.Color.White
        '
        'Button1_4
        '
        Me.Button1_4.Align = System.Drawing.StringAlignment.Center
        Me.Button1_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_4.BGColor = System.Drawing.Color.Black
        Me.Button1_4.BordersColor = System.Drawing.Color.White
        Me.Button1_4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_4.ForeColor = System.Drawing.Color.White
        Me.Button1_4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_4.Location = New System.Drawing.Point(111, 44)
        Me.Button1_4.Name = "Button1_4"
        Me.Button1_4.old_UI = True
        Me.Button1_4.Size = New System.Drawing.Size(28, 18)
        Me.Button1_4.TabIndex = 54
        Me.Button1_4.TopColor = System.Drawing.Color.White
        '
        'Button1_3
        '
        Me.Button1_3.Align = System.Drawing.StringAlignment.Center
        Me.Button1_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1_3.BGColor = System.Drawing.Color.Black
        Me.Button1_3.BordersColor = System.Drawing.Color.White
        Me.Button1_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Button1_3.ForeColor = System.Drawing.Color.White
        Me.Button1_3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1_3.Location = New System.Drawing.Point(80, 44)
        Me.Button1_3.Name = "Button1_3"
        Me.Button1_3.old_UI = True
        Me.Button1_3.Size = New System.Drawing.Size(28, 18)
        Me.Button1_3.TabIndex = 53
        Me.Button1_3.TopColor = System.Drawing.Color.White
        '
        'ButtonBas1
        '
        Me.ButtonBas1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBas1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonBas1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonBas1.Location = New System.Drawing.Point(0, 615)
        Me.ButtonBas1.Name = "ButtonBas1"
        Me.ButtonBas1.Size = New System.Drawing.Size(692, 10)
        Me.ButtonBas1.TabIndex = 25
        Me.ButtonBas1.UseVisualStyleBackColor = False
        '
        'premiere
        '
        Me.premiere.Image = CType(resources.GetObject("premiere.Image"), System.Drawing.Image)
        Me.premiere.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.premiere.Location = New System.Drawing.Point(617, 367)
        Me.premiere.Name = "premiere"
        Me.premiere.Size = New System.Drawing.Size(50, 16)
        Me.premiere.TabIndex = 46
        Me.premiere.TabStop = False
        Me.premiere.Visible = False
        '
        'ButtonDroit
        '
        Me.ButtonDroit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDroit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonDroit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonDroit.Location = New System.Drawing.Point(960, 56)
        Me.ButtonDroit.Name = "ButtonDroit"
        Me.ButtonDroit.Size = New System.Drawing.Size(10, 561)
        Me.ButtonDroit.TabIndex = 24
        Me.ButtonDroit.UseVisualStyleBackColor = False
        '
        'Soustitre
        '
        Me.Soustitre.Image = CType(resources.GetObject("Soustitre.Image"), System.Drawing.Image)
        Me.Soustitre.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Soustitre.Location = New System.Drawing.Point(593, 362)
        Me.Soustitre.Name = "Soustitre"
        Me.Soustitre.Size = New System.Drawing.Size(18, 23)
        Me.Soustitre.TabIndex = 44
        Me.Soustitre.TabStop = False
        Me.Soustitre.Visible = False
        '
        'AudioStereo
        '
        Me.AudioStereo.Image = CType(resources.GetObject("AudioStereo.Image"), System.Drawing.Image)
        Me.AudioStereo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AudioStereo.Location = New System.Drawing.Point(567, 363)
        Me.AudioStereo.Name = "AudioStereo"
        Me.AudioStereo.Size = New System.Drawing.Size(20, 20)
        Me.AudioStereo.TabIndex = 42
        Me.AudioStereo.TabStop = False
        Me.AudioStereo.Visible = False
        '
        'Signaletique_43
        '
        Me.Signaletique_43.Image = CType(resources.GetObject("Signaletique_43.Image"), System.Drawing.Image)
        Me.Signaletique_43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Signaletique_43.Location = New System.Drawing.Point(525, 366)
        Me.Signaletique_43.Name = "Signaletique_43"
        Me.Signaletique_43.Size = New System.Drawing.Size(36, 16)
        Me.Signaletique_43.TabIndex = 41
        Me.Signaletique_43.TabStop = False
        Me.Signaletique_43.Visible = False
        '
        'Signaletique_169
        '
        Me.Signaletique_169.Image = CType(resources.GetObject("Signaletique_169.Image"), System.Drawing.Image)
        Me.Signaletique_169.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Signaletique_169.Location = New System.Drawing.Point(483, 367)
        Me.Signaletique_169.Name = "Signaletique_169"
        Me.Signaletique_169.Size = New System.Drawing.Size(36, 16)
        Me.Signaletique_169.TabIndex = 40
        Me.Signaletique_169.TabStop = False
        Me.Signaletique_169.Visible = False
        '
        'Picture_18
        '
        Me.Picture_18.Image = CType(resources.GetObject("Picture_18.Image"), System.Drawing.Image)
        Me.Picture_18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Picture_18.Location = New System.Drawing.Point(456, 363)
        Me.Picture_18.Name = "Picture_18"
        Me.Picture_18.Size = New System.Drawing.Size(21, 23)
        Me.Picture_18.TabIndex = 38
        Me.Picture_18.TabStop = False
        Me.Picture_18.Visible = False
        '
        'Picture_16
        '
        Me.Picture_16.Image = CType(resources.GetObject("Picture_16.Image"), System.Drawing.Image)
        Me.Picture_16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Picture_16.Location = New System.Drawing.Point(427, 363)
        Me.Picture_16.Name = "Picture_16"
        Me.Picture_16.Size = New System.Drawing.Size(23, 20)
        Me.Picture_16.TabIndex = 37
        Me.Picture_16.TabStop = False
        Me.Picture_16.Visible = False
        '
        'Picture_12
        '
        Me.Picture_12.Image = CType(resources.GetObject("Picture_12.Image"), System.Drawing.Image)
        Me.Picture_12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Picture_12.Location = New System.Drawing.Point(400, 363)
        Me.Picture_12.Name = "Picture_12"
        Me.Picture_12.Size = New System.Drawing.Size(21, 23)
        Me.Picture_12.TabIndex = 36
        Me.Picture_12.TabStop = False
        Me.Picture_12.Visible = False
        '
        'Picture_10
        '
        Me.Picture_10.Image = CType(resources.GetObject("Picture_10.Image"), System.Drawing.Image)
        Me.Picture_10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Picture_10.Location = New System.Drawing.Point(373, 363)
        Me.Picture_10.Name = "Picture_10"
        Me.Picture_10.Size = New System.Drawing.Size(21, 23)
        Me.Picture_10.TabIndex = 35
        Me.Picture_10.TabStop = False
        Me.Picture_10.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(144, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(10, 569)
        Me.Button1.TabIndex = 28
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ButtonGauche
        '
        Me.ButtonGauche.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonGauche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonGauche.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonGauche.Location = New System.Drawing.Point(312, 48)
        Me.ButtonGauche.Name = "ButtonGauche"
        Me.ButtonGauche.Size = New System.Drawing.Size(10, 569)
        Me.ButtonGauche.TabIndex = 23
        Me.ButtonGauche.UseVisualStyleBackColor = False
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxLogo.BackColor = System.Drawing.Color.White
        Me.PictureBoxLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxLogo.Location = New System.Drawing.Point(0, 630)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(160, 97)
        Me.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxLogo.TabIndex = 4
        Me.PictureBoxLogo.TabStop = False
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
        'programmerktv
        '
        Me.programmerktv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.programmerktv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.programmerktv.Image = CType(resources.GetObject("programmerktv.Image"), System.Drawing.Image)
        Me.programmerktv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.programmerktv.Name = "programmerktv"
        Me.programmerktv.Size = New System.Drawing.Size(23, 22)
        Me.programmerktv.Text = "ToolStripButton9"
        Me.programmerktv.ToolTipText = "Programmer des enregistrements pour K!TV"
        '
        'zapperktv
        '
        Me.zapperktv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.zapperktv.Image = CType(resources.GetObject("zapperktv.Image"), System.Drawing.Image)
        Me.zapperktv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.zapperktv.Name = "zapperktv"
        Me.zapperktv.Size = New System.Drawing.Size(23, 22)
        Me.zapperktv.Text = "ToolStripButton10"
        Me.zapperktv.ToolTipText = "Zapper dans K!TV"
        '
        'gestionenregistrementktv
        '
        Me.gestionenregistrementktv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.gestionenregistrementktv.Image = CType(resources.GetObject("gestionenregistrementktv.Image"), System.Drawing.Image)
        Me.gestionenregistrementktv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.gestionenregistrementktv.Name = "gestionenregistrementktv"
        Me.gestionenregistrementktv.Size = New System.Drawing.Size(23, 22)
        Me.gestionenregistrementktv.Text = "ToolStripButton11"
        Me.gestionenregistrementktv.ToolTipText = "Gestion des enregistrements K!TV"
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSave, Me.ToolStripPrint, Me.ToolStripSeparator1, Me.ToolStripOntop, Me.ToolStripSearch, Me.ToolStripSeparator22, Me.ToolStripCategories, Me.ToolStripDescription, Me.ToolStripCalendar, Me.RechercheToolStripButton, Me.ToolStripSeparator2, Me.ToolStripPreferences, Me.ToolStripLogos, Me.ToolStripSeparator12, Me.ToolStripUpdate, Me.ToolStripDualMonitor, Me.ToolStripAutoUpdate, Me.ToolStripSeparator17, Me.ToolStripHelptopics, Me.ToolStripHelpShortcuts, Me.ToolStripAbout, Me.ToolStripLangue, Me.ToolStripManualFeedBack, Me.ToolStripForum, Me.ToolStripWebsite, Me.ToolStripCheckupdates, Me.ToolStripTextBoxRecherche, Me.ToolStripButtonRecherche})
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
        'ToolStripPrint
        '
        Me.ToolStripPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripPrint.Image = CType(resources.GetObject("ToolStripPrint.Image"), System.Drawing.Image)
        Me.ToolStripPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripPrint.Name = "ToolStripPrint"
        Me.ToolStripPrint.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripPrint.Text = "ToolStripButton7"
        Me.ToolStripPrint.ToolTipText = "Imprimer la description"
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
        'ToolStripCategories
        '
        Me.ToolStripCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripCategories.Image = CType(resources.GetObject("ToolStripCategories.Image"), System.Drawing.Image)
        Me.ToolStripCategories.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripCategories.Name = "ToolStripCategories"
        Me.ToolStripCategories.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripCategories.Text = "ToolStripFilters"
        Me.ToolStripCategories.ToolTipText = "Afficher/Cacher catégories"
        '
        'ToolStripDescription
        '
        Me.ToolStripDescription.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDescription.Image = CType(resources.GetObject("ToolStripDescription.Image"), System.Drawing.Image)
        Me.ToolStripDescription.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDescription.Name = "ToolStripDescription"
        Me.ToolStripDescription.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripDescription.Text = "ToolStripButton3"
        Me.ToolStripDescription.ToolTipText = "Afficher/Cacher description"
        '
        'ToolStripCalendar
        '
        Me.ToolStripCalendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripCalendar.Image = CType(resources.GetObject("ToolStripCalendar.Image"), System.Drawing.Image)
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
        Me.ToolStripPreferences.Image = CType(resources.GetObject("ToolStripPreferences.Image"), System.Drawing.Image)
        Me.ToolStripPreferences.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripPreferences.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripPreferences.Name = "ToolStripPreferences"
        Me.ToolStripPreferences.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripPreferences.Text = "ToolStripButton10"
        Me.ToolStripPreferences.ToolTipText = "Préférences"
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
        Me.ToolStripDualMonitor.Image = CType(resources.GetObject("ToolStripDualMonitor.Image"), System.Drawing.Image)
        Me.ToolStripDualMonitor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDualMonitor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDualMonitor.Name = "ToolStripDualMonitor"
        Me.ToolStripDualMonitor.RightToLeftAutoMirrorImage = True
        Me.ToolStripDualMonitor.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripDualMonitor.Text = "ToolStripButton4"
        Me.ToolStripDualMonitor.ToolTipText = "Basculer entre les écrans"
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
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripHelptopics
        '
        Me.ToolStripHelptopics.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripHelptopics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripHelptopics.Image = CType(resources.GetObject("ToolStripHelptopics.Image"), System.Drawing.Image)
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
        Me.ToolStripHelpShortcuts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripHelpShortcuts.Name = "ToolStripHelpShortcuts"
        Me.ToolStripHelpShortcuts.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripHelpShortcuts.Text = "ToolStripButton2"
        Me.ToolStripHelpShortcuts.ToolTipText = "Raccourcis clavier"
        '
        'ToolStripAbout
        '
        Me.ToolStripAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripAbout.Image = CType(resources.GetObject("ToolStripAbout.Image"), System.Drawing.Image)
        Me.ToolStripAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripAbout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAbout.Name = "ToolStripAbout"
        Me.ToolStripAbout.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripAbout.Text = "ToolStripButton2"
        Me.ToolStripAbout.ToolTipText = "A propos de ZGuideTV"
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
        Me.ToolStripManualFeedBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripManualFeedBack.Name = "ToolStripManualFeedBack"
        Me.ToolStripManualFeedBack.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripManualFeedBack.Text = "ToolStripManualFeedBack"
        Me.ToolStripManualFeedBack.ToolTipText = "Envoyer un feedback"
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
        Me.ToolStripWebsite.Image = CType(resources.GetObject("ToolStripWebsite.Image"), System.Drawing.Image)
        Me.ToolStripWebsite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripWebsite.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripWebsite.Name = "ToolStripWebsite"
        Me.ToolStripWebsite.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripWebsite.Text = "ToolStripButton9"
        Me.ToolStripWebsite.ToolTipText = "Site officiel ZGuideTV.NET"
        '
        'ToolStripCheckupdates
        '
        Me.ToolStripCheckupdates.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripCheckupdates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripCheckupdates.Image = CType(resources.GetObject("ToolStripCheckupdates.Image"), System.Drawing.Image)
        Me.ToolStripCheckupdates.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripCheckupdates.Name = "ToolStripCheckupdates"
        Me.ToolStripCheckupdates.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripCheckupdates.Text = "ToolStripButton7"
        Me.ToolStripCheckupdates.ToolTipText = "Vérification des mises à jour..."
        '
        'ToolStripTextBoxRecherche
        '
        Me.ToolStripTextBoxRecherche.AutoSize = False
        Me.ToolStripTextBoxRecherche.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBoxRecherche.Name = "ToolStripTextBoxRecherche"
        Me.ToolStripTextBoxRecherche.Size = New System.Drawing.Size(152, 25)
        '
        'ToolStripButtonRecherche
        '
        Me.ToolStripButtonRecherche.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRecherche.Image = CType(resources.GetObject("ToolStripButtonRecherche.Image"), System.Drawing.Image)
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
        Me.panel_droit.Location = New System.Drawing.Point(698, 48)
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
        Me.ToolStripMenuFileExit.Size = New System.Drawing.Size(263, 22)
        Me.ToolStripMenuFileExit.Text = "Quitter"
        '
        'ToolStripMenuEdit
        '
        Me.ToolStripMenuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuEditOntop, Me.ToolStripMenuSearch, Me.ToolStripSeparator5, Me.ToolStripMenuCategories, Me.ToolStripMenuDescription, Me.ToolStripMenuCalendar, Me.RechercheInfosToolStripMenuItem, Me.ToolStripSeparator16, Me.ToolStripMenuEditPrint, Me.ToolStripMenuPrintTonight})
        Me.ToolStripMenuEdit.Name = "ToolStripMenuEdit"
        Me.ToolStripMenuEdit.Size = New System.Drawing.Size(57, 20)
        Me.ToolStripMenuEdit.Text = "Edition"
        '
        'ToolStripMenuEditOntop
        '
        Me.ToolStripMenuEditOntop.Image = CType(resources.GetObject("ToolStripMenuEditOntop.Image"), System.Drawing.Image)
        Me.ToolStripMenuEditOntop.Name = "ToolStripMenuEditOntop"
        Me.ToolStripMenuEditOntop.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ToolStripMenuEditOntop.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuEditOntop.Text = "Avant plan"
        '
        'ToolStripMenuSearch
        '
        Me.ToolStripMenuSearch.Image = CType(resources.GetObject("ToolStripMenuSearch.Image"), System.Drawing.Image)
        Me.ToolStripMenuSearch.Name = "ToolStripMenuSearch"
        Me.ToolStripMenuSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ToolStripMenuSearch.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuSearch.Text = "Recherche avancée"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(257, 6)
        '
        'ToolStripMenuCategories
        '
        Me.ToolStripMenuCategories.Image = CType(resources.GetObject("ToolStripMenuCategories.Image"), System.Drawing.Image)
        Me.ToolStripMenuCategories.Name = "ToolStripMenuCategories"
        Me.ToolStripMenuCategories.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.ToolStripMenuCategories.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuCategories.Text = "Afficher/Cacher catégories"
        '
        'ToolStripMenuDescription
        '
        Me.ToolStripMenuDescription.Image = CType(resources.GetObject("ToolStripMenuDescription.Image"), System.Drawing.Image)
        Me.ToolStripMenuDescription.Name = "ToolStripMenuDescription"
        Me.ToolStripMenuDescription.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ToolStripMenuDescription.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuDescription.Text = "Afficher/Cacher description"
        '
        'ToolStripMenuCalendar
        '
        Me.ToolStripMenuCalendar.Image = CType(resources.GetObject("ToolStripMenuCalendar.Image"), System.Drawing.Image)
        Me.ToolStripMenuCalendar.Name = "ToolStripMenuCalendar"
        Me.ToolStripMenuCalendar.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ToolStripMenuCalendar.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuCalendar.Text = "Afficher/Cacher calendrier"
        '
        'RechercheInfosToolStripMenuItem
        '
        Me.RechercheInfosToolStripMenuItem.Image = CType(resources.GetObject("RechercheInfosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RechercheInfosToolStripMenuItem.Name = "RechercheInfosToolStripMenuItem"
        Me.RechercheInfosToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.RechercheInfosToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.RechercheInfosToolStripMenuItem.Text = "The TVDB.Com..."
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(257, 6)
        '
        'ToolStripMenuEditPrint
        '
        Me.ToolStripMenuEditPrint.Image = CType(resources.GetObject("ToolStripMenuEditPrint.Image"), System.Drawing.Image)
        Me.ToolStripMenuEditPrint.Name = "ToolStripMenuEditPrint"
        Me.ToolStripMenuEditPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ToolStripMenuEditPrint.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuEditPrint.Text = "Imprimer la description"
        '
        'ToolStripMenuPrintTonight
        '
        Me.ToolStripMenuPrintTonight.Image = CType(resources.GetObject("ToolStripMenuPrintTonight.Image"), System.Drawing.Image)
        Me.ToolStripMenuPrintTonight.Name = "ToolStripMenuPrintTonight"
        Me.ToolStripMenuPrintTonight.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ToolStripMenuPrintTonight.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuPrintTonight.Text = "Imprimer ""Ce soir"""
        '
        'ToolStripMenuOptions
        '
        Me.ToolStripMenuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuOptionsUpdate, Me.ToolStripMenuOptionsAutoUpdate, Me.ToolStripSeparator19, Me.ToolStripMenuOptionsPreferences, Me.ToolStripMenuOptionsLogos, Me.ToolStripSeparator18, Me.ToolStripMenuOptionsDualMonitor, Me.ToolStripSeparator25, Me.ToolStripMenuOptionsEngineSelection})
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
        Me.ToolStripMenuOptionsPreferences.Image = CType(resources.GetObject("ToolStripMenuOptionsPreferences.Image"), System.Drawing.Image)
        Me.ToolStripMenuOptionsPreferences.Name = "ToolStripMenuOptionsPreferences"
        Me.ToolStripMenuOptionsPreferences.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ToolStripMenuOptionsPreferences.Size = New System.Drawing.Size(289, 22)
        Me.ToolStripMenuOptionsPreferences.Text = "Préférences"
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
        Me.ToolStripMenuOptionsDualMonitor.Image = CType(resources.GetObject("ToolStripMenuOptionsDualMonitor.Image"), System.Drawing.Image)
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
        'ToolStripMenuOptionsEngineSelection
        '
        Me.ToolStripMenuOptionsEngineSelection.Image = CType(resources.GetObject("ToolStripMenuOptionsEngineSelection.Image"), System.Drawing.Image)
        Me.ToolStripMenuOptionsEngineSelection.Name = "ToolStripMenuOptionsEngineSelection"
        Me.ToolStripMenuOptionsEngineSelection.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.ToolStripMenuOptionsEngineSelection.Size = New System.Drawing.Size(289, 22)
        Me.ToolStripMenuOptionsEngineSelection.Text = "Sélection de la recherche"
        '
        'ToolStripMenuHelp
        '
        Me.ToolStripMenuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuHelpHelptopics, Me.ToolStripMenuHelpHelpShortcuts, Me.ToolStripSeparator6, Me.ToolStripMenuHelpWebsite, Me.ToolStripMenuHelpForum, Me.ToolStripMenuHelpDonate, Me.ToolStripSeparator11, Me.ToolStripMenuHelpManualFeedBack, Me.ToolStripMenuHelpCheckupdates, Me.ToolStripMenuHelpPlugins, Me.ToolStripMenuHelpLanguage, Me.ToolStripMenuHelpCompensation, Me.ToolStripSeparator26, Me.ToolStripMenuHelpContent, Me.ToolStripMenuHelpWeather, Me.ToolStripMenuHelpLocation, Me.ToolStripSeparator15, Me.ToolStripMenuHelpAbout})
        Me.ToolStripMenuHelp.Name = "ToolStripMenuHelp"
        Me.ToolStripMenuHelp.Size = New System.Drawing.Size(26, 20)
        Me.ToolStripMenuHelp.Text = "?"
        '
        'ToolStripMenuHelpHelptopics
        '
        Me.ToolStripMenuHelpHelptopics.Image = CType(resources.GetObject("ToolStripMenuHelpHelptopics.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpHelptopics.Name = "ToolStripMenuHelpHelptopics"
        Me.ToolStripMenuHelpHelptopics.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ToolStripMenuHelpHelptopics.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpHelptopics.Text = "Rubrique d'aide"
        '
        'ToolStripMenuHelpHelpShortcuts
        '
        Me.ToolStripMenuHelpHelpShortcuts.Image = Global.ZGuideTV.My.Resources.Resources.keyboard
        Me.ToolStripMenuHelpHelpShortcuts.Name = "ToolStripMenuHelpHelpShortcuts"
        Me.ToolStripMenuHelpHelpShortcuts.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.ToolStripMenuHelpHelpShortcuts.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpHelpShortcuts.Text = "Raccourcis clavier"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(307, 6)
        '
        'ToolStripMenuHelpWebsite
        '
        Me.ToolStripMenuHelpWebsite.Image = CType(resources.GetObject("ToolStripMenuHelpWebsite.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpWebsite.Name = "ToolStripMenuHelpWebsite"
        Me.ToolStripMenuHelpWebsite.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpWebsite.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpWebsite.Text = "Site officiel ZGuideTV"
        '
        'ToolStripMenuHelpForum
        '
        Me.ToolStripMenuHelpForum.Image = CType(resources.GetObject("ToolStripMenuHelpForum.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpForum.Name = "ToolStripMenuHelpForum"
        Me.ToolStripMenuHelpForum.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpForum.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpForum.Text = "Forum officiel ZGuideTV"
        '
        'ToolStripMenuHelpDonate
        '
        Me.ToolStripMenuHelpDonate.Image = CType(resources.GetObject("ToolStripMenuHelpDonate.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpDonate.Name = "ToolStripMenuHelpDonate"
        Me.ToolStripMenuHelpDonate.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpDonate.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpDonate.Text = "Faire un don"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(307, 6)
        '
        'ToolStripMenuHelpManualFeedBack
        '
        Me.ToolStripMenuHelpManualFeedBack.Image = CType(resources.GetObject("ToolStripMenuHelpManualFeedBack.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpManualFeedBack.Name = "ToolStripMenuHelpManualFeedBack"
        Me.ToolStripMenuHelpManualFeedBack.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpManualFeedBack.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpManualFeedBack.Text = "Envoyer un feedback..."
        Me.ToolStripMenuHelpManualFeedBack.Visible = False
        '
        'ToolStripMenuHelpCheckupdates
        '
        Me.ToolStripMenuHelpCheckupdates.Image = CType(resources.GetObject("ToolStripMenuHelpCheckupdates.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpCheckupdates.Name = "ToolStripMenuHelpCheckupdates"
        Me.ToolStripMenuHelpCheckupdates.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpCheckupdates.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpCheckupdates.Text = "Vérification des mises à jours..."
        '
        'ToolStripMenuHelpPlugins
        '
        Me.ToolStripMenuHelpPlugins.Image = CType(resources.GetObject("ToolStripMenuHelpPlugins.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpPlugins.Name = "ToolStripMenuHelpPlugins"
        Me.ToolStripMenuHelpPlugins.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpPlugins.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpPlugins.Text = "Gestions des Plug-ins"
        '
        'ToolStripMenuHelpLanguage
        '
        Me.ToolStripMenuHelpLanguage.Image = CType(resources.GetObject("ToolStripMenuHelpLanguage.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpLanguage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuHelpLanguage.Name = "ToolStripMenuHelpLanguage"
        Me.ToolStripMenuHelpLanguage.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpLanguage.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpLanguage.Text = "Langue"
        '
        'ToolStripMenuHelpCompensation
        '
        Me.ToolStripMenuHelpCompensation.Image = CType(resources.GetObject("ToolStripMenuHelpCompensation.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpCompensation.Name = "ToolStripMenuHelpCompensation"
        Me.ToolStripMenuHelpCompensation.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpCompensation.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpCompensation.Text = "Compensation fuseaux horaires"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(307, 6)
        '
        'ToolStripMenuHelpContent
        '
        Me.ToolStripMenuHelpContent.Image = CType(resources.GetObject("ToolStripMenuHelpContent.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpContent.Name = "ToolStripMenuHelpContent"
        Me.ToolStripMenuHelpContent.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpContent.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpContent.Text = "Légendes et classement du contenu"
        '
        'ToolStripMenuHelpWeather
        '
        Me.ToolStripMenuHelpWeather.Image = CType(resources.GetObject("ToolStripMenuHelpWeather.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpWeather.Name = "ToolStripMenuHelpWeather"
        Me.ToolStripMenuHelpWeather.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpWeather.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpWeather.Text = "Prévisions météo"
        '
        'ToolStripMenuHelpLocation
        '
        Me.ToolStripMenuHelpLocation.Image = CType(resources.GetObject("ToolStripMenuHelpLocation.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpLocation.Name = "ToolStripMenuHelpLocation"
        Me.ToolStripMenuHelpLocation.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpLocation.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpLocation.Text = "Emplacement géographique"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(307, 6)
        '
        'ToolStripMenuHelpAbout
        '
        Me.ToolStripMenuHelpAbout.Image = CType(resources.GetObject("ToolStripMenuHelpAbout.Image"), System.Drawing.Image)
        Me.ToolStripMenuHelpAbout.Name = "ToolStripMenuHelpAbout"
        Me.ToolStripMenuHelpAbout.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ToolStripMenuHelpAbout.Size = New System.Drawing.Size(310, 24)
        Me.ToolStripMenuHelpAbout.Text = "A propos de ZGuideTV"
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
        'ImprimerLaDescriptionToolStripMenuItem
        '
        Me.ImprimerLaDescriptionToolStripMenuItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuPrintDescript})
        Me.ImprimerLaDescriptionToolStripMenuItem.Name = "ImprimerLaDescriptionToolStripMenuItem"
        Me.ImprimerLaDescriptionToolStripMenuItem.Size = New System.Drawing.Size(239, 26)
        '
        'ToolStripMenuPrintDescript
        '
        Me.ToolStripMenuPrintDescript.Image = CType(resources.GetObject("ToolStripMenuPrintDescript.Image"), System.Drawing.Image)
        Me.ToolStripMenuPrintDescript.Name = "ToolStripMenuPrintDescript"
        Me.ToolStripMenuPrintDescript.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ToolStripMenuPrintDescript.Size = New System.Drawing.Size(238, 22)
        Me.ToolStripMenuPrintDescript.Text = "Imprimer la description"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.AutoSize = False
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_date, Me.ToolStripStatusLabel_heure, Me.ToolStripStatusLabelCompensation, Me.ToolStripStatusLabelMinutes, Me.ToolStripStatusLabelActiveEngine, Me.ToolStripStatusLabelEngine, Me.ToolStripStatusLabelMemory, Me.ToolStripStatusLabelMemoryUsage, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabelWeatherImage, Me.ToolStripStatusLabelWeather, Me.ToolStripStatusLabelEmpty, Me.ToolStripStatusLabelWakeUp, Me.ToolStripStatusLabelAudio, Me.ToolStripStatusLabeliMON, Me.ToolStripLabelStatusInternet})
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
        'ToolStripStatusLabelActiveEngine
        '
        Me.ToolStripStatusLabelActiveEngine.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelActiveEngine.DoubleClickEnabled = True
        Me.ToolStripStatusLabelActiveEngine.Name = "ToolStripStatusLabelActiveEngine"
        Me.ToolStripStatusLabelActiveEngine.Size = New System.Drawing.Size(78, 18)
        Me.ToolStripStatusLabelActiveEngine.Text = "Moteur actif :"
        '
        'ToolStripStatusLabelEngine
        '
        Me.ToolStripStatusLabelEngine.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelEngine.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelEngine.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabelEngine.DoubleClickEnabled = True
        Me.ToolStripStatusLabelEngine.Name = "ToolStripStatusLabelEngine"
        Me.ToolStripStatusLabelEngine.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.ToolStripStatusLabelEngine.Size = New System.Drawing.Size(102, 18)
        Me.ToolStripStatusLabelEngine.Text = "TheTVDB.com"
        Me.ToolStripStatusLabelEngine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'ToolStripStatusLabelWeatherImage
        '
        Me.ToolStripStatusLabelWeatherImage.AutoSize = False
        Me.ToolStripStatusLabelWeatherImage.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelWeatherImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripStatusLabelWeatherImage.DoubleClickEnabled = True
        Me.ToolStripStatusLabelWeatherImage.Name = "ToolStripStatusLabelWeatherImage"
        Me.ToolStripStatusLabelWeatherImage.Size = New System.Drawing.Size(16, 18)
        Me.ToolStripStatusLabelWeatherImage.Visible = False
        '
        'ToolStripStatusLabelWeather
        '
        Me.ToolStripStatusLabelWeather.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelWeather.DoubleClickEnabled = True
        Me.ToolStripStatusLabelWeather.Name = "ToolStripStatusLabelWeather"
        Me.ToolStripStatusLabelWeather.Size = New System.Drawing.Size(41, 18)
        Me.ToolStripStatusLabelWeather.Text = "Météo"
        Me.ToolStripStatusLabelWeather.Visible = False
        '
        'ToolStripStatusLabelEmpty
        '
        Me.ToolStripStatusLabelEmpty.AutoSize = False
        Me.ToolStripStatusLabelEmpty.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelEmpty.Name = "ToolStripStatusLabelEmpty"
        Me.ToolStripStatusLabelEmpty.Size = New System.Drawing.Size(238, 18)
        Me.ToolStripStatusLabelEmpty.Spring = True
        '
        'ToolStripStatusLabelWakeUp
        '
        Me.ToolStripStatusLabelWakeUp.AutoSize = False
        Me.ToolStripStatusLabelWakeUp.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelWakeUp.DoubleClickEnabled = True
        Me.ToolStripStatusLabelWakeUp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripStatusLabelWakeUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripStatusLabelWakeUp.Margin = New System.Windows.Forms.Padding(0, 3, 5, 2)
        Me.ToolStripStatusLabelWakeUp.Name = "ToolStripStatusLabelWakeUp"
        Me.ToolStripStatusLabelWakeUp.Size = New System.Drawing.Size(16, 18)
        Me.ToolStripStatusLabelWakeUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabelAudio
        '
        Me.ToolStripStatusLabelAudio.AutoSize = False
        Me.ToolStripStatusLabelAudio.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelAudio.DoubleClickEnabled = True
        Me.ToolStripStatusLabelAudio.Margin = New System.Windows.Forms.Padding(0, 3, 5, 2)
        Me.ToolStripStatusLabelAudio.Name = "ToolStripStatusLabelAudio"
        Me.ToolStripStatusLabelAudio.Size = New System.Drawing.Size(16, 18)
        '
        'ToolStripStatusLabeliMON
        '
        Me.ToolStripStatusLabeliMON.AutoSize = False
        Me.ToolStripStatusLabeliMON.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabeliMON.Margin = New System.Windows.Forms.Padding(0, 3, 5, 2)
        Me.ToolStripStatusLabeliMON.Name = "ToolStripStatusLabeliMON"
        Me.ToolStripStatusLabeliMON.Size = New System.Drawing.Size(16, 18)
        '
        'ToolStripLabelStatusInternet
        '
        Me.ToolStripLabelStatusInternet.AutoSize = False
        Me.ToolStripLabelStatusInternet.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabelStatusInternet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripLabelStatusInternet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripLabelStatusInternet.Name = "ToolStripLabelStatusInternet"
        Me.ToolStripLabelStatusInternet.Size = New System.Drawing.Size(16, 18)
        '
        'Timer_seconde
        '
        Me.Timer_seconde.Interval = 1000
        '
        'Panel_glob_devant
        '
        Me.Panel_glob_devant.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel_glob_devant.BackColor = System.Drawing.Color.White
        Me.Panel_glob_devant.Controls.Add(Me.Panel_devant)
        Me.Panel_glob_devant.Controls.Add(Me.TreeView1)
        Me.Panel_glob_devant.Location = New System.Drawing.Point(0, 49)
        Me.Panel_glob_devant.Name = "Panel_glob_devant"
        Me.Panel_glob_devant.Size = New System.Drawing.Size(128, 644)
        Me.Panel_glob_devant.TabIndex = 65
        '
        'Panel_devant
        '
        Me.Panel_devant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel_devant.BackColor = System.Drawing.Color.White
        Me.Panel_devant.Controls.Add(Me.LbLoader1)
        Me.Panel_devant.Location = New System.Drawing.Point(20, -27)
        Me.Panel_devant.Name = "Panel_devant"
        Me.Panel_devant.Size = New System.Drawing.Size(100, 663)
        Me.Panel_devant.TabIndex = 0
        '
        'LbLoader1
        '
        Me.LbLoader1.Align = System.Drawing.StringAlignment.Center
        Me.LbLoader1.BackColor = System.Drawing.Color.Transparent
        Me.LbLoader1.Location = New System.Drawing.Point(7, 214)
        Me.LbLoader1.Name = "LbLoader1"
        Me.LbLoader1.Size = New System.Drawing.Size(706, 34)
        Me.LbLoader1.TabIndex = 68
        Me.LbLoader1.Text = "Veuillez patienter. Mise à jour des données en cours..."
        '
        'Timer_500msec
        '
        Me.Timer_500msec.Interval = 500
        '
        'ToolStripMenuNews
        '
        Me.ToolStripMenuNews.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripMenuNews.AutoSize = True
        Me.ToolStripMenuNews.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ToolStripMenuNews.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuNews.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.ToolStripMenuNews.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripMenuNews.Location = New System.Drawing.Point(479, 5)
        Me.ToolStripMenuNews.Name = "ToolStripMenuNews"
        Me.ToolStripMenuNews.Size = New System.Drawing.Size(483, 15)
        Me.ToolStripMenuNews.TabIndex = 66
        Me.ToolStripMenuNews.Text = "---------------------------------------------------------------------------------" & _
    "--------------------------------------"
        Me.ToolStripMenuNews.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TimerUsageMemory
        '
        Me.TimerUsageMemory.Interval = 1000
        '
        'Panel_cinema
        '
        Me.Panel_cinema.Location = New System.Drawing.Point(483, 76)
        Me.Panel_cinema.Name = "Panel_cinema"
        Me.Panel_cinema.Size = New System.Drawing.Size(154, 53)
        Me.Panel_cinema.TabIndex = 67
        '
        'Timer_cinema
        '
        Me.Timer_cinema.Interval = 15000
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
        'RichTextBoxDescrip
        '
        Me.RichTextBoxDescrip.BackColor = System.Drawing.Color.White
        Me.RichTextBoxDescrip.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxDescrip.ContextMenuStrip = Me.ImprimerLaDescriptionToolStripMenuItem
        Me.RichTextBoxDescrip.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.RichTextBoxDescrip.Location = New System.Drawing.Point(160, 620)
        Me.RichTextBoxDescrip.Name = "RichTextBoxDescrip"
        Me.RichTextBoxDescrip.ReadOnly = True
        Me.RichTextBoxDescrip.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RichTextBoxDescrip.Size = New System.Drawing.Size(534, 84)
        Me.RichTextBoxDescrip.TabIndex = 60
        Me.RichTextBoxDescrip.Text = ""
        '
        'Mainform
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(984, 725)
        Me.Controls.Add(Me.Panel_cinema)
        Me.Controls.Add(Me.ToolStripMenuNews)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.ButtonBas1)
        Me.Controls.Add(Me.Panel_date)
        Me.Controls.Add(Me.PanelB)
        Me.Controls.Add(Me.PanelD)
        Me.Controls.Add(Me.PanelC)
        Me.Controls.Add(Me.panel_droit)
        Me.Controls.Add(Me.premiere)
        Me.Controls.Add(Me.Signaletique_169)
        Me.Controls.Add(Me.PanelE)
        Me.Controls.Add(Me.Soustitre)
        Me.Controls.Add(Me.AudioStereo)
        Me.Controls.Add(Me.Picture_18)
        Me.Controls.Add(Me.Picture_16)
        Me.Controls.Add(Me.Signaletique_43)
        Me.Controls.Add(Me.Picture_12)
        Me.Controls.Add(Me.Picture_10)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonDroit)
        Me.Controls.Add(Me.ButtonGauche)
        Me.Controls.Add(Me.ListViewChannel)
        Me.Controls.Add(Me.PanelA)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBoxLogo)
        Me.Controls.Add(Me.RichTextBoxDescrip)
        Me.Controls.Add(Me.Panel_glob_devant)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(900, 617)
        Me.Name = "Mainform"
        Me.Opacity = 0.0R
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Context_menu_KTV.ResumeLayout(False)
        Me.PanelE.ResumeLayout(False)
        Me.Panel_glob_maintenant.ResumeLayout(False)
        Me.Panel_glob_ce_soir.ResumeLayout(False)
        Me.Calendar.ResumeLayout(False)
        CType(Me.premiere, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Soustitre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AudioStereo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Signaletique_43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Signaletique_169, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture_18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture_16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture_12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture_10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.panel_droit.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ImprimerLaDescriptionToolStripMenuItem.ResumeLayout(False)
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.Panel_glob_devant.ResumeLayout(False)
        Me.Panel_devant.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ListViewChannel As System.Windows.Forms.ListView
    Friend WithEvents PictureBoxLogo As System.Windows.Forms.PictureBox
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
    Friend WithEvents programmerktv As System.Windows.Forms.ToolStripButton
    Friend WithEvents zapperktv As System.Windows.Forms.ToolStripButton
    Friend WithEvents gestionenregistrementktv As System.Windows.Forms.ToolStripButton
    Friend WithEvents aidezguidetv As System.Windows.Forms.ToolStripButton
    Friend WithEvents Context_menu_KTV As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonGauche As System.Windows.Forms.Button
    Friend WithEvents ButtonDroit As System.Windows.Forms.Button
    Friend WithEvents ButtonBas1 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer_minute As System.Windows.Forms.Timer
    Friend WithEvents GestionDeKTVToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuProgramKTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionDeMeuhMeuhTVToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuZapperKTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuGestionRecordKTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuProgramMMTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuZapperMMTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuGestionRecordMMTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents premiere As System.Windows.Forms.PictureBox
    Friend WithEvents Soustitre As System.Windows.Forms.PictureBox
    Friend WithEvents AudioStereo As System.Windows.Forms.PictureBox
    Friend WithEvents Signaletique_43 As System.Windows.Forms.PictureBox
    Friend WithEvents Signaletique_169 As System.Windows.Forms.PictureBox
    Friend WithEvents Picture_18 As System.Windows.Forms.PictureBox
    Friend WithEvents Picture_16 As System.Windows.Forms.PictureBox
    Friend WithEvents Picture_12 As System.Windows.Forms.PictureBox
    Friend WithEvents Picture_10 As System.Windows.Forms.PictureBox
    Friend WithEvents SystrayMenuExit As System.Windows.Forms.MenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripOntop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPreferences As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLogos As System.Windows.Forms.ToolStripButton
    Friend WithEvents SystrayMenuRestore As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents PanelC As System.Windows.Forms.Panel
    Friend WithEvents PanelD As System.Windows.Forms.Panel
    Friend WithEvents PanelE As System.Windows.Forms.Panel
    Friend WithEvents PanelB As System.Windows.Forms.Panel
    Friend WithEvents Panel_date As System.Windows.Forms.Panel
    Friend WithEvents PanelA As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuGestionChainesKTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDualMonitor As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel_glob_maintenant As System.Windows.Forms.Panel
    Friend WithEvents Panel_maintenant As System.Windows.Forms.Panel
    Friend WithEvents Panel_glob_ce_soir As System.Windows.Forms.Panel
    Friend WithEvents Panel_ce_soir As System.Windows.Forms.Panel
    Friend WithEvents RichTextBoxDescrip As Global.ZGuideTVDotNet.Description.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ToolStripHelptopics As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripAbout As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripForum As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripWebsite As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLangue As System.Windows.Forms.ToolStripButton
    Friend WithEvents Calendar As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
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
    Friend WithEvents MoisS As System.Windows.Forms.Button
    Friend WithEvents Button4_7 As calendrierpavé
    Friend WithEvents MoisP As System.Windows.Forms.Button
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
    Friend WithEvents ToolStripMenuEditPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuEditOntop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuOptionsPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuOptionsLogos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpCheckupdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpWebsite As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpForum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpHelptopics As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpLanguage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripCheckupdates As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimerLaDescriptionToolStripMenuItem As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuPrintDescript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuGestionChainesMMTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripAutoUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuPrintTonight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel_titre_ce_soir As System.Windows.Forms.Button
    Friend WithEvents Panel_titre_maintenant As System.Windows.Forms.Button
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents Panel_glob_devant As System.Windows.Forms.Panel
    Friend WithEvents Panel_devant As System.Windows.Forms.Panel
    Friend WithEvents ToolStripStatusLabel_date As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_heure As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuFileRestart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer_500msec As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuHelpManualFeedBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripCategories As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripManualFeedBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuCategories As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripCalendar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuCalendar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDescription As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuDescription As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechercheToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuHelpCompensation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpDonate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelCompensation As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelMinutes As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuOptionsEngineSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelActiveEngine As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelEngine As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelMemory As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelMemoryUsage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuNews As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuHelpContent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TimerUsageMemory As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuHelpPlugins As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuHelpWeather As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelWeather As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelWeatherImage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents navigtemporelle As ZGuideTV.BarreTemporelle
    Friend WithEvents Panel_cinema As System.Windows.Forms.Panel
    Friend WithEvents Timer_cinema As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuHelpLocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_wait As System.Windows.Forms.Timer
    Friend WithEvents Timer_heure As System.Windows.Forms.Timer
    Friend WithEvents LbLoader1 As ZGuideTV.lbLoader
    Friend WithEvents ToolStripLabelStatusInternet As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripTextBoxRecherche As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButtonRecherche As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabelWakeUp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelAudio As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItemSettingsReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabeliMON As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripHelpShortcuts As System.Windows.Forms.ToolStripButton


End Class
