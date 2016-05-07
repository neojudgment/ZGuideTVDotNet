Partial Class TVGuideMainForm
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TVGuideMainForm))
        Me.panelNonToolbarArea = New System.Windows.Forms.Panel()
        Me.panelWorkingArea = New System.Windows.Forms.Panel()
        Me.splitterRightOfTree = New System.Windows.Forms.Splitter()
        Me.panelRightOfTreeSplitter = New System.Windows.Forms.Panel()
        Me.panelAllTabContents = New System.Windows.Forms.Panel()
        Me.DisplayTabs = New System.Windows.Forms.TabControl()
        Me.ListTab = New System.Windows.Forms.TabPage()
        Me.listViewEm = New ZGuideTV.TVListView()
        Me.ViewContextMenu = New System.Windows.Forms.ContextMenu()
        Me.ViewFindOtherOccurrencesContextMenuItem = New System.Windows.Forms.MenuItem()
        Me.mniAjouterAuxRecherche = New System.Windows.Forms.MenuItem()
        Me.mniImprimer = New System.Windows.Forms.MenuItem()
        Me.AdvancedSearchTab = New System.Windows.Forms.TabPage()
        Me._AdvancedSearchEditor = New ZGuideTV.AdvancedSearchEditor()
        Me.splitterAboveShowDetails = New System.Windows.Forms.Splitter()
        Me.panelShowDetails = New System.Windows.Forms.Panel()
        Me.pbIcone = New System.Windows.Forms.PictureBox()
        Me.txbDescription = New System.Windows.Forms.TextBox()
        Me.tvAdvancedSearch = New ZGuideTV.TvTreeViewEx()
        Me.ShowNotificationContextMenuRemoveShow = New System.Windows.Forms.MenuItem()
        Me.ShowNotificationContextMenuRemoveAllShows = New System.Windows.Forms.MenuItem()
        Me.panelNonToolbarArea.SuspendLayout()
        Me.panelWorkingArea.SuspendLayout()
        Me.panelRightOfTreeSplitter.SuspendLayout()
        Me.panelAllTabContents.SuspendLayout()
        Me.DisplayTabs.SuspendLayout()
        Me.ListTab.SuspendLayout()
        Me.AdvancedSearchTab.SuspendLayout()
        Me.panelShowDetails.SuspendLayout()
        CType(Me.pbIcone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelNonToolbarArea
        '
        Me.panelNonToolbarArea.BackColor = System.Drawing.Color.White
        Me.panelNonToolbarArea.Controls.Add(Me.panelWorkingArea)
        Me.panelNonToolbarArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelNonToolbarArea.Location = New System.Drawing.Point(0, 0)
        Me.panelNonToolbarArea.Name = "panelNonToolbarArea"
        Me.panelNonToolbarArea.Size = New System.Drawing.Size(1118, 608)
        Me.panelNonToolbarArea.TabIndex = 3
        '
        'panelWorkingArea
        '
        Me.panelWorkingArea.Controls.Add(Me.splitterRightOfTree)
        Me.panelWorkingArea.Controls.Add(Me.panelRightOfTreeSplitter)
        Me.panelWorkingArea.Controls.Add(Me.tvAdvancedSearch)
        Me.panelWorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelWorkingArea.Location = New System.Drawing.Point(0, 0)
        Me.panelWorkingArea.Margin = New System.Windows.Forms.Padding(0)
        Me.panelWorkingArea.Name = "panelWorkingArea"
        Me.panelWorkingArea.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.panelWorkingArea.Size = New System.Drawing.Size(1118, 608)
        Me.panelWorkingArea.TabIndex = 7
        '
        'splitterRightOfTree
        '
        Me.splitterRightOfTree.BackColor = System.Drawing.Color.WhiteSmoke
        Me.splitterRightOfTree.Location = New System.Drawing.Point(208, 0)
        Me.splitterRightOfTree.Name = "splitterRightOfTree"
        Me.splitterRightOfTree.Size = New System.Drawing.Size(4, 608)
        Me.splitterRightOfTree.TabIndex = 6
        Me.splitterRightOfTree.TabStop = False
        '
        'panelRightOfTreeSplitter
        '
        Me.panelRightOfTreeSplitter.Controls.Add(Me.panelAllTabContents)
        Me.panelRightOfTreeSplitter.Controls.Add(Me.splitterAboveShowDetails)
        Me.panelRightOfTreeSplitter.Controls.Add(Me.panelShowDetails)
        Me.panelRightOfTreeSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelRightOfTreeSplitter.Location = New System.Drawing.Point(208, 0)
        Me.panelRightOfTreeSplitter.Name = "panelRightOfTreeSplitter"
        Me.panelRightOfTreeSplitter.Size = New System.Drawing.Size(910, 608)
        Me.panelRightOfTreeSplitter.TabIndex = 5
        '
        'panelAllTabContents
        '
        Me.panelAllTabContents.Controls.Add(Me.DisplayTabs)
        Me.panelAllTabContents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelAllTabContents.Location = New System.Drawing.Point(0, 0)
        Me.panelAllTabContents.Name = "panelAllTabContents"
        Me.panelAllTabContents.Padding = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.panelAllTabContents.Size = New System.Drawing.Size(910, 508)
        Me.panelAllTabContents.TabIndex = 15
        '
        'DisplayTabs
        '
        Me.DisplayTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.DisplayTabs.Controls.Add(Me.ListTab)
        Me.DisplayTabs.Controls.Add(Me.AdvancedSearchTab)
        Me.DisplayTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DisplayTabs.Location = New System.Drawing.Point(1, 1)
        Me.DisplayTabs.Name = "DisplayTabs"
        Me.DisplayTabs.Padding = New System.Drawing.Point(0, 0)
        Me.DisplayTabs.SelectedIndex = 0
        Me.DisplayTabs.Size = New System.Drawing.Size(909, 507)
        Me.DisplayTabs.TabIndex = 7
        '
        'ListTab
        '
        Me.ListTab.Controls.Add(Me.listViewEm)
        Me.ListTab.Location = New System.Drawing.Point(4, 27)
        Me.ListTab.Name = "ListTab"
        Me.ListTab.Size = New System.Drawing.Size(901, 476)
        Me.ListTab.TabIndex = 0
        Me.ListTab.Text = "Liste"
        Me.ListTab.UseVisualStyleBackColor = True
        '
        'listViewEm
        '
        Me.listViewEm.BackColor = System.Drawing.Color.White
        Me.listViewEm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listViewEm.ContextMenu = Me.ViewContextMenu
        Me.listViewEm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewEm.FullRowSelect = True
        Me.listViewEm.GridLines = True
        Me.listViewEm.Location = New System.Drawing.Point(0, 0)
        Me.listViewEm.Name = "listViewEm"
        Me.listViewEm.Size = New System.Drawing.Size(901, 476)
        Me.listViewEm.TabIndex = 7
        Me.listViewEm.UseCompatibleStateImageBehavior = False
        Me.listViewEm.View = System.Windows.Forms.View.Details
        '
        'ViewContextMenu
        '
        Me.ViewContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewFindOtherOccurrencesContextMenuItem, Me.mniAjouterAuxRecherche, Me.mniImprimer})
        '
        'ViewFindOtherOccurrencesContextMenuItem
        '
        Me.ViewFindOtherOccurrencesContextMenuItem.Index = 0
        Me.ViewFindOtherOccurrencesContextMenuItem.Text = "Rechercher les autres émissions"
        '
        'mniAjouterAuxRecherche
        '
        Me.mniAjouterAuxRecherche.Index = 1
        Me.mniAjouterAuxRecherche.Text = "Ajouter aux recherches personnalisées"
        '
        'mniImprimer
        '
        Me.mniImprimer.Index = 2
        Me.mniImprimer.Text = "Imprimer la liste"
        '
        'AdvancedSearchTab
        '
        Me.AdvancedSearchTab.Controls.Add(Me._AdvancedSearchEditor)
        Me.AdvancedSearchTab.Location = New System.Drawing.Point(4, 27)
        Me.AdvancedSearchTab.Name = "AdvancedSearchTab"
        Me.AdvancedSearchTab.Size = New System.Drawing.Size(901, 476)
        Me.AdvancedSearchTab.TabIndex = 2
        Me.AdvancedSearchTab.Text = "Recherche avancée"
        Me.AdvancedSearchTab.UseVisualStyleBackColor = True
        '
        '_AdvancedSearchEditor
        '
        Me._AdvancedSearchEditor.BackColor = System.Drawing.Color.White
        Me._AdvancedSearchEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me._AdvancedSearchEditor.Location = New System.Drawing.Point(0, 0)
        Me._AdvancedSearchEditor.Name = "_AdvancedSearchEditor"
        Me._AdvancedSearchEditor.Size = New System.Drawing.Size(901, 476)
        Me._AdvancedSearchEditor.TabIndex = 0
        '
        'splitterAboveShowDetails
        '
        Me.splitterAboveShowDetails.BackColor = System.Drawing.Color.WhiteSmoke
        Me.splitterAboveShowDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splitterAboveShowDetails.Location = New System.Drawing.Point(0, 508)
        Me.splitterAboveShowDetails.Name = "splitterAboveShowDetails"
        Me.splitterAboveShowDetails.Size = New System.Drawing.Size(910, 5)
        Me.splitterAboveShowDetails.TabIndex = 0
        Me.splitterAboveShowDetails.TabStop = False
        '
        'panelShowDetails
        '
        Me.panelShowDetails.BackColor = System.Drawing.Color.White
        Me.panelShowDetails.Controls.Add(Me.pbIcone)
        Me.panelShowDetails.Controls.Add(Me.txbDescription)
        Me.panelShowDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelShowDetails.Location = New System.Drawing.Point(0, 513)
        Me.panelShowDetails.Name = "panelShowDetails"
        Me.panelShowDetails.Padding = New System.Windows.Forms.Padding(1, 2, 2, 2)
        Me.panelShowDetails.Size = New System.Drawing.Size(910, 95)
        Me.panelShowDetails.TabIndex = 13
        '
        'pbIcone
        '
        Me.pbIcone.Location = New System.Drawing.Point(22, 2)
        Me.pbIcone.Margin = New System.Windows.Forms.Padding(0)
        Me.pbIcone.Name = "pbIcone"
        Me.pbIcone.Size = New System.Drawing.Size(104, 91)
        Me.pbIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbIcone.TabIndex = 15
        Me.pbIcone.TabStop = False
        '
        'txbDescription
        '
        Me.txbDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbDescription.BackColor = System.Drawing.Color.White
        Me.txbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txbDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.txbDescription.Location = New System.Drawing.Point(148, 3)
        Me.txbDescription.Margin = New System.Windows.Forms.Padding(0)
        Me.txbDescription.Multiline = True
        Me.txbDescription.Name = "txbDescription"
        Me.txbDescription.ReadOnly = True
        Me.txbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txbDescription.ShortcutsEnabled = False
        Me.txbDescription.Size = New System.Drawing.Size(753, 90)
        Me.txbDescription.TabIndex = 14
        '
        'tvAdvancedSearch
        '
        Me.tvAdvancedSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvAdvancedSearch.Location = New System.Drawing.Point(3, 0)
        Me.tvAdvancedSearch.Name = "tvAdvancedSearch"
        Me.tvAdvancedSearch.SavedSearches = CType(resources.GetObject("tvAdvancedSearch.SavedSearches"), System.Collections.Hashtable)
        Me.tvAdvancedSearch.Size = New System.Drawing.Size(205, 608)
        Me.tvAdvancedSearch.TabIndex = 4
        '
        'ShowNotificationContextMenuRemoveShow
        '
        Me.ShowNotificationContextMenuRemoveShow.Index = -1
        Me.ShowNotificationContextMenuRemoveShow.Text = ""
        '
        'ShowNotificationContextMenuRemoveAllShows
        '
        Me.ShowNotificationContextMenuRemoveAllShows.Index = -1
        Me.ShowNotificationContextMenuRemoveAllShows.Text = ""
        '
        'TVGuideMainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1118, 608)
        Me.Controls.Add(Me.panelNonToolbarArea)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.HelpButton = True
        Me.KeyPreview = True
        Me.Name = "TVGuideMainForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proto recherche émissions"
        Me.panelNonToolbarArea.ResumeLayout(False)
        Me.panelWorkingArea.ResumeLayout(False)
        Me.panelRightOfTreeSplitter.ResumeLayout(False)
        Me.panelAllTabContents.ResumeLayout(False)
        Me.DisplayTabs.ResumeLayout(False)
        Me.ListTab.ResumeLayout(False)
        Me.AdvancedSearchTab.ResumeLayout(False)
        Me.panelShowDetails.ResumeLayout(False)
        Me.panelShowDetails.PerformLayout()
        CType(Me.pbIcone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public ListTab As System.Windows.Forms.TabPage
    'private HansBlomme.Windows.Forms.NotifyIcon notifyIcon;
    Private ShowNotificationContextMenuRemoveShow As System.Windows.Forms.MenuItem
    Private ViewContextMenu As System.Windows.Forms.ContextMenu
    Private panelShowDetails As System.Windows.Forms.Panel
    Private panelNonToolbarArea As System.Windows.Forms.Panel
    Private panelWorkingArea As System.Windows.Forms.Panel
    Private splitterRightOfTree As System.Windows.Forms.Splitter
    Private panelRightOfTreeSplitter As System.Windows.Forms.Panel
    Private panelAllTabContents As System.Windows.Forms.Panel
    Private splitterAboveShowDetails As System.Windows.Forms.Splitter

    'private CustomUIControls.TaskbarNotifier mTaskbarNotifier = new CustomUIControls.TaskbarNotifier();
    Private ShowNotificationContextMenuRemoveAllShows As System.Windows.Forms.MenuItem
    Public WithEvents txbDescription As System.Windows.Forms.TextBox
    Public WithEvents pbIcone As System.Windows.Forms.PictureBox
    Public WithEvents DisplayTabs As System.Windows.Forms.TabControl
    Public WithEvents AdvancedSearchTab As System.Windows.Forms.TabPage
    Public WithEvents ViewFindOtherOccurrencesContextMenuItem As System.Windows.Forms.MenuItem
    Public WithEvents mniAjouterAuxRecherche As System.Windows.Forms.MenuItem
    Public WithEvents mniImprimer As System.Windows.Forms.MenuItem
    Private WithEvents tvAdvancedSearch As ZGuideTV.TVTreeViewEx
    Private WithEvents _AdvancedSearchEditor As ZGuideTV.AdvancedSearchEditor
    Private WithEvents listViewEm As ZGuideTV.TVListView

End Class
