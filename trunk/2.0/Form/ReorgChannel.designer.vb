<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReorgChannel
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReorgChannel))
        Me.lstChaine = New System.Windows.Forms.ListView()
        Me.Nomchaine = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ordering = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.identifiant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.logo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btAnnuler = New System.Windows.Forms.Button()
        Me.btMonter = New System.Windows.Forms.Button()
        Me.btDescendre = New System.Windows.Forms.Button()
        Me.btSupprimer = New System.Windows.Forms.Button()
        Me.btEnregistrer = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btLogo = New System.Windows.Forms.Button()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstChaine
        '
        Me.lstChaine.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Nomchaine, Me.ordering, Me.identifiant, Me.logo})
        Me.lstChaine.FullRowSelect = True
        Me.lstChaine.GridLines = True
        Me.lstChaine.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstChaine.Location = New System.Drawing.Point(12, 12)
        Me.lstChaine.MultiSelect = False
        Me.lstChaine.Name = "lstChaine"
        Me.lstChaine.Size = New System.Drawing.Size(183, 431)
        Me.lstChaine.TabIndex = 0
        Me.lstChaine.UseCompatibleStateImageBehavior = False
        Me.lstChaine.View = System.Windows.Forms.View.Details
        '
        'Nomchaine
        '
        Me.Nomchaine.Text = "Nom de la chaine"
        Me.Nomchaine.Width = 113
        '
        'ordering
        '
        Me.ordering.Text = "Ordre"
        Me.ordering.Width = 47
        '
        'identifiant
        '
        Me.identifiant.Text = ""
        Me.identifiant.Width = 0
        '
        'logo
        '
        Me.logo.Text = ""
        Me.logo.Width = 0
        '
        'btAnnuler
        '
        Me.btAnnuler.Location = New System.Drawing.Point(292, 420)
        Me.btAnnuler.Name = "btAnnuler"
        Me.btAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.btAnnuler.TabIndex = 1
        Me.btAnnuler.Text = "Annuler"
        Me.btAnnuler.UseVisualStyleBackColor = True
        '
        'btMonter
        '
        Me.btMonter.Location = New System.Drawing.Point(215, 22)
        Me.btMonter.Name = "btMonter"
        Me.btMonter.Size = New System.Drawing.Size(152, 53)
        Me.btMonter.TabIndex = 2
        Me.btMonter.Text = "Monter"
        Me.btMonter.UseVisualStyleBackColor = True
        '
        'btDescendre
        '
        Me.btDescendre.Location = New System.Drawing.Point(215, 91)
        Me.btDescendre.Name = "btDescendre"
        Me.btDescendre.Size = New System.Drawing.Size(152, 53)
        Me.btDescendre.TabIndex = 3
        Me.btDescendre.Text = "Descendre"
        Me.btDescendre.UseVisualStyleBackColor = True
        '
        'btSupprimer
        '
        Me.btSupprimer.Location = New System.Drawing.Point(215, 167)
        Me.btSupprimer.Name = "btSupprimer"
        Me.btSupprimer.Size = New System.Drawing.Size(152, 27)
        Me.btSupprimer.TabIndex = 4
        Me.btSupprimer.Text = "Supprimer"
        Me.btSupprimer.UseVisualStyleBackColor = True
        '
        'btEnregistrer
        '
        Me.btEnregistrer.Location = New System.Drawing.Point(215, 420)
        Me.btEnregistrer.Name = "btEnregistrer"
        Me.btEnregistrer.Size = New System.Drawing.Size(71, 23)
        Me.btEnregistrer.TabIndex = 5
        Me.btEnregistrer.Text = "Enregistrer"
        Me.btEnregistrer.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btLogo)
        Me.GroupBox1.Controls.Add(Me.pbLogo)
        Me.GroupBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(215, 213)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 184)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'btLogo
        '
        Me.btLogo.Enabled = False
        Me.btLogo.Location = New System.Drawing.Point(7, 142)
        Me.btLogo.Name = "btLogo"
        Me.btLogo.Size = New System.Drawing.Size(139, 34)
        Me.btLogo.TabIndex = 1
        Me.btLogo.Text = "Changer de logo"
        Me.btLogo.UseVisualStyleBackColor = True
        '
        'pbLogo
        '
        Me.pbLogo.BackColor = System.Drawing.Color.White
        Me.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbLogo.Location = New System.Drawing.Point(7, 19)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(139, 115)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 0
        Me.pbLogo.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ReorgChannel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(390, 465)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btEnregistrer)
        Me.Controls.Add(Me.btSupprimer)
        Me.Controls.Add(Me.btDescendre)
        Me.Controls.Add(Me.btMonter)
        Me.Controls.Add(Me.btAnnuler)
        Me.Controls.Add(Me.lstChaine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReorgChannel"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Réorganisation des chaines"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstChaine As System.Windows.Forms.ListView
    Friend WithEvents Nomchaine As System.Windows.Forms.ColumnHeader
    Friend WithEvents ordering As System.Windows.Forms.ColumnHeader
    Friend WithEvents btAnnuler As System.Windows.Forms.Button
    Friend WithEvents btMonter As System.Windows.Forms.Button
    Friend WithEvents btDescendre As System.Windows.Forms.Button
    Friend WithEvents btSupprimer As System.Windows.Forms.Button
    Friend WithEvents btEnregistrer As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btLogo As System.Windows.Forms.Button
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents identifiant As System.Windows.Forms.ColumnHeader
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents logo As System.Windows.Forms.ColumnHeader
End Class
