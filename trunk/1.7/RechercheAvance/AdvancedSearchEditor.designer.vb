Partial Class AdvancedSearchEditor
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

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.SearchCriteriaControlsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.flpRecherche = New System.Windows.Forms.FlowLayoutPanel()
        Me.ControlsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.gbCreation = New System.Windows.Forms.GroupBox()
        Me.btRechercher = New System.Windows.Forms.Button()
        Me.btNettoyer = New System.Windows.Forms.Button()
        Me.btInserer = New System.Windows.Forms.Button()
        Me.cboAvailableSearchCriteria = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbSauver = New System.Windows.Forms.GroupBox()
        Me.btSauver = New System.Windows.Forms.Button()
        Me.tbNom = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        CType(Me.SearchCriteriaControlsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchCriteriaControlsSplitContainer.Panel1.SuspendLayout()
        Me.SearchCriteriaControlsSplitContainer.Panel2.SuspendLayout()
        Me.SearchCriteriaControlsSplitContainer.SuspendLayout()
        CType(Me.ControlsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlsSplitContainer.Panel1.SuspendLayout()
        Me.ControlsSplitContainer.Panel2.SuspendLayout()
        Me.ControlsSplitContainer.SuspendLayout()
        Me.gbCreation.SuspendLayout()
        Me.gbSauver.SuspendLayout()
        Me.SuspendLayout()
        '
        'SearchCriteriaControlsSplitContainer
        '
        Me.SearchCriteriaControlsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchCriteriaControlsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SearchCriteriaControlsSplitContainer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchCriteriaControlsSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SearchCriteriaControlsSplitContainer.Name = "SearchCriteriaControlsSplitContainer"
        '
        'SearchCriteriaControlsSplitContainer.Panel1
        '
        Me.SearchCriteriaControlsSplitContainer.Panel1.Controls.Add(Me.flpRecherche)
        '
        'SearchCriteriaControlsSplitContainer.Panel2
        '
        Me.SearchCriteriaControlsSplitContainer.Panel2.Controls.Add(Me.ControlsSplitContainer)
        Me.SearchCriteriaControlsSplitContainer.Size = New System.Drawing.Size(627, 396)
        Me.SearchCriteriaControlsSplitContainer.SplitterDistance = 479
        Me.SearchCriteriaControlsSplitContainer.TabIndex = 0
        '
        'flpRecherche
        '
        Me.flpRecherche.AutoScroll = True
        Me.flpRecherche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpRecherche.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpRecherche.Location = New System.Drawing.Point(0, 0)
        Me.flpRecherche.Name = "flpRecherche"
        Me.flpRecherche.Size = New System.Drawing.Size(479, 396)
        Me.flpRecherche.TabIndex = 0
        '
        'ControlsSplitContainer
        '
        Me.ControlsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.ControlsSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.ControlsSplitContainer.Name = "ControlsSplitContainer"
        Me.ControlsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'ControlsSplitContainer.Panel1
        '
        Me.ControlsSplitContainer.Panel1.Controls.Add(Me.gbCreation)
        '
        'ControlsSplitContainer.Panel2
        '
        Me.ControlsSplitContainer.Panel2.Controls.Add(Me.Label2)
        Me.ControlsSplitContainer.Panel2.Controls.Add(Me.LinkLabel1)
        Me.ControlsSplitContainer.Panel2.Controls.Add(Me.Label1)
        Me.ControlsSplitContainer.Panel2.Controls.Add(Me.gbSauver)
        Me.ControlsSplitContainer.Size = New System.Drawing.Size(144, 396)
        Me.ControlsSplitContainer.SplitterDistance = 187
        Me.ControlsSplitContainer.TabIndex = 0
        '
        'gbCreation
        '
        Me.gbCreation.Controls.Add(Me.btRechercher)
        Me.gbCreation.Controls.Add(Me.btNettoyer)
        Me.gbCreation.Controls.Add(Me.btInserer)
        Me.gbCreation.Controls.Add(Me.cboAvailableSearchCriteria)
        Me.gbCreation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbCreation.Location = New System.Drawing.Point(0, 0)
        Me.gbCreation.Name = "gbCreation"
        Me.gbCreation.Size = New System.Drawing.Size(144, 187)
        Me.gbCreation.TabIndex = 1
        Me.gbCreation.TabStop = False
        Me.gbCreation.Text = "Recherche"
        '
        'btRechercher
        '
        Me.btRechercher.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btRechercher.Enabled = False
        Me.btRechercher.Location = New System.Drawing.Point(6, 110)
        Me.btRechercher.Name = "btRechercher"
        Me.btRechercher.Size = New System.Drawing.Size(129, 23)
        Me.btRechercher.TabIndex = 4
        Me.btRechercher.Text = "Rechercher"
        Me.btRechercher.UseVisualStyleBackColor = True
        '
        'btNettoyer
        '
        Me.btNettoyer.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btNettoyer.Location = New System.Drawing.Point(6, 139)
        Me.btNettoyer.Name = "btNettoyer"
        Me.btNettoyer.Size = New System.Drawing.Size(129, 23)
        Me.btNettoyer.TabIndex = 3
        Me.btNettoyer.Text = "Nettoyer"
        Me.btNettoyer.UseVisualStyleBackColor = True
        '
        'btInserer
        '
        Me.btInserer.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btInserer.Location = New System.Drawing.Point(6, 69)
        Me.btInserer.Name = "btInserer"
        Me.btInserer.Size = New System.Drawing.Size(129, 23)
        Me.btInserer.TabIndex = 2
        Me.btInserer.Text = "Insérer"
        Me.btInserer.UseVisualStyleBackColor = True
        '
        'cboAvailableSearchCriteria
        '
        Me.cboAvailableSearchCriteria.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAvailableSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAvailableSearchCriteria.FormattingEnabled = True
        Me.cboAvailableSearchCriteria.Items.AddRange(New Object() {"Par champs texte", "Par catégorie", "Par chaine", "Par date", "Par heure", "Par durée", "Par Jour de la semaine", "Par plage de jour", "Par plage d'heure", "Est aujourd'hui", "Est en cours", "Par proximité de temp", "Condition OU"})
        Me.cboAvailableSearchCriteria.Location = New System.Drawing.Point(6, 42)
        Me.cboAvailableSearchCriteria.Name = "cboAvailableSearchCriteria"
        Me.cboAvailableSearchCriteria.Size = New System.Drawing.Size(129, 23)
        Me.cboAvailableSearchCriteria.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Par/By Joseph LeBlanc"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(52, 161)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(29, 15)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "TVG"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 26)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Recherche avancé basé sur" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Advanced search based on"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gbSauver
        '
        Me.gbSauver.Controls.Add(Me.btSauver)
        Me.gbSauver.Controls.Add(Me.tbNom)
        Me.gbSauver.Controls.Add(Me.lblNom)
        Me.gbSauver.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbSauver.Location = New System.Drawing.Point(0, 0)
        Me.gbSauver.Name = "gbSauver"
        Me.gbSauver.Size = New System.Drawing.Size(144, 128)
        Me.gbSauver.TabIndex = 0
        Me.gbSauver.TabStop = False
        Me.gbSauver.Text = "Sauver la recherche"
        '
        'btSauver
        '
        Me.btSauver.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSauver.Enabled = False
        Me.btSauver.Location = New System.Drawing.Point(6, 82)
        Me.btSauver.Name = "btSauver"
        Me.btSauver.Size = New System.Drawing.Size(129, 23)
        Me.btSauver.TabIndex = 2
        Me.btSauver.Text = "Sauver"
        Me.btSauver.UseVisualStyleBackColor = True
        '
        'tbNom
        '
        Me.tbNom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNom.Location = New System.Drawing.Point(6, 56)
        Me.tbNom.Name = "tbNom"
        Me.tbNom.Size = New System.Drawing.Size(129, 23)
        Me.tbNom.TabIndex = 1
        '
        'lblNom
        '
        Me.lblNom.AutoSize = True
        Me.lblNom.Location = New System.Drawing.Point(3, 40)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(117, 15)
        Me.lblNom.TabIndex = 0
        Me.lblNom.Text = "Nom de la recherche"
        '
        'AdvancedSearchEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.SearchCriteriaControlsSplitContainer)
        Me.Name = "AdvancedSearchEditor"
        Me.Size = New System.Drawing.Size(627, 396)
        Me.SearchCriteriaControlsSplitContainer.Panel1.ResumeLayout(False)
        Me.SearchCriteriaControlsSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SearchCriteriaControlsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchCriteriaControlsSplitContainer.ResumeLayout(False)
        Me.ControlsSplitContainer.Panel1.ResumeLayout(False)
        Me.ControlsSplitContainer.Panel2.ResumeLayout(False)
        Me.ControlsSplitContainer.Panel2.PerformLayout()
        CType(Me.ControlsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlsSplitContainer.ResumeLayout(False)
        Me.gbCreation.ResumeLayout(False)
        Me.gbSauver.ResumeLayout(False)
        Me.gbSauver.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private SearchCriteriaControlsSplitContainer As System.Windows.Forms.SplitContainer
    Private ControlsSplitContainer As System.Windows.Forms.SplitContainer
    Private tbNom As System.Windows.Forms.TextBox
    Private WithEvents flpRecherche As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents gbCreation As System.Windows.Forms.GroupBox
    Public WithEvents btRechercher As System.Windows.Forms.Button
    Public WithEvents btNettoyer As System.Windows.Forms.Button
    Public WithEvents btInserer As System.Windows.Forms.Button
    Public WithEvents cboAvailableSearchCriteria As System.Windows.Forms.ComboBox
    Public WithEvents gbSauver As System.Windows.Forms.GroupBox
    Public WithEvents btSauver As System.Windows.Forms.Button
    Public WithEvents lblNom As System.Windows.Forms.Label
End Class
