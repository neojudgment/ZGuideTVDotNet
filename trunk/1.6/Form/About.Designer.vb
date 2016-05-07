<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.TextBoxCredit = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageAbout = New System.Windows.Forms.TabPage()
        Me.TextBoxCompiledOn = New System.Windows.Forms.TextBox()
        Me.TextBoxCompilationDate = New System.Windows.Forms.TextBox()
        Me.TextBoxVersion = New System.Windows.Forms.TextBox()
        Me.TextBoxCopyright = New System.Windows.Forms.TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TabPageAuteurs = New System.Windows.Forms.TabPage()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBoxThanks = New System.Windows.Forms.TextBox()
        Me.TextBoxContributors = New System.Windows.Forms.TextBox()
        Me.TextBoxTesters = New System.Windows.Forms.TextBox()
        Me.TextBoxDev = New System.Windows.Forms.TextBox()
        Me.TextBoxAdmin = New System.Windows.Forms.TextBox()
        Me.TabPagelicence = New System.Windows.Forms.TabPage()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TextBoxLicence = New System.Windows.Forms.TextBox()
        Me.TabPage7zip = New System.Windows.Forms.TabPage()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TabPageDonate = New System.Windows.Forms.TabPage()
        Me.PictureBoxPaypal = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPageAbout.SuspendLayout()
        Me.TabPageAuteurs.SuspendLayout()
        Me.TabPagelicence.SuspendLayout()
        Me.TabPage7zip.SuspendLayout()
        Me.TabPageDonate.SuspendLayout()
        CType(Me.PictureBoxPaypal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LinkLabel3
        '
        Me.LinkLabel3.Location = New System.Drawing.Point(26, 335)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(208, 16)
        Me.LinkLabel3.TabIndex = 10
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "http://igloo.crystalxp.net/djeric"
        Me.LinkLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBoxCredit
        '
        Me.TextBoxCredit.BackColor = System.Drawing.Color.White
        Me.TextBoxCredit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCredit.Location = New System.Drawing.Point(26, 320)
        Me.TextBoxCredit.Name = "TextBoxCredit"
        Me.TextBoxCredit.ReadOnly = True
        Me.TextBoxCredit.Size = New System.Drawing.Size(208, 13)
        Me.TextBoxCredit.TabIndex = 9
        Me.TextBoxCredit.Text = "Logo created and designed by djeric"
        Me.TextBoxCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageAbout)
        Me.TabControl1.Controls.Add(Me.TabPageAuteurs)
        Me.TabControl1.Controls.Add(Me.TabPagelicence)
        Me.TabControl1.Controls.Add(Me.TabPage7zip)
        Me.TabControl1.Controls.Add(Me.TabPageDonate)
        Me.TabControl1.Location = New System.Drawing.Point(250, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(289, 340)
        Me.TabControl1.TabIndex = 8
        '
        'TabPageAbout
        '
        Me.TabPageAbout.BackColor = System.Drawing.Color.White
        Me.TabPageAbout.Controls.Add(Me.TextBoxCompiledOn)
        Me.TabPageAbout.Controls.Add(Me.TextBoxCompilationDate)
        Me.TabPageAbout.Controls.Add(Me.TextBoxVersion)
        Me.TabPageAbout.Controls.Add(Me.TextBoxCopyright)
        Me.TabPageAbout.Controls.Add(Me.LinkLabel2)
        Me.TabPageAbout.Controls.Add(Me.TextBox2)
        Me.TabPageAbout.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAbout.Name = "TabPageAbout"
        Me.TabPageAbout.Size = New System.Drawing.Size(281, 314)
        Me.TabPageAbout.TabIndex = 0
        Me.TabPageAbout.Text = "A Propos"
        '
        'TextBoxCompiledOn
        '
        Me.TextBoxCompiledOn.BackColor = System.Drawing.Color.White
        Me.TextBoxCompiledOn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCompiledOn.Location = New System.Drawing.Point(8, 178)
        Me.TextBoxCompiledOn.Name = "TextBoxCompiledOn"
        Me.TextBoxCompiledOn.ReadOnly = True
        Me.TextBoxCompiledOn.Size = New System.Drawing.Size(263, 13)
        Me.TextBoxCompiledOn.TabIndex = 5
        Me.TextBoxCompiledOn.Text = "Compiled on"
        Me.TextBoxCompiledOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCompilationDate
        '
        Me.TextBoxCompilationDate.BackColor = System.Drawing.Color.White
        Me.TextBoxCompilationDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCompilationDate.Location = New System.Drawing.Point(8, 194)
        Me.TextBoxCompilationDate.Name = "TextBoxCompilationDate"
        Me.TextBoxCompilationDate.ReadOnly = True
        Me.TextBoxCompilationDate.Size = New System.Drawing.Size(263, 13)
        Me.TextBoxCompilationDate.TabIndex = 4
        Me.TextBoxCompilationDate.Text = "Build date"
        Me.TextBoxCompilationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxVersion
        '
        Me.TextBoxVersion.BackColor = System.Drawing.Color.White
        Me.TextBoxVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxVersion.Location = New System.Drawing.Point(8, 163)
        Me.TextBoxVersion.Name = "TextBoxVersion"
        Me.TextBoxVersion.ReadOnly = True
        Me.TextBoxVersion.Size = New System.Drawing.Size(263, 13)
        Me.TextBoxVersion.TabIndex = 3
        Me.TextBoxVersion.Text = "Version"
        Me.TextBoxVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCopyright
        '
        Me.TextBoxCopyright.BackColor = System.Drawing.Color.White
        Me.TextBoxCopyright.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCopyright.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBoxCopyright.Location = New System.Drawing.Point(8, 211)
        Me.TextBoxCopyright.Name = "TextBoxCopyright"
        Me.TextBoxCopyright.ReadOnly = True
        Me.TextBoxCopyright.Size = New System.Drawing.Size(263, 13)
        Me.TextBoxCopyright.TabIndex = 2
        Me.TextBoxCopyright.Text = "Copyright"
        Me.TextBoxCopyright.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel2.Location = New System.Drawing.Point(38, 135)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(204, 13)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "http://zguidetv.codeplex.com/"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox2.Location = New System.Drawing.Point(8, 83)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(263, 43)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.Text = "ZGuideTV.NET is an Electronic Program Guide (EPG) - i.e. an ""electronic TV magazi" & _
    "ne"" - which makes the viewing of today's and next week's TV listings possible."
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPageAuteurs
        '
        Me.TabPageAuteurs.Controls.Add(Me.TextBox17)
        Me.TabPageAuteurs.Controls.Add(Me.TextBox16)
        Me.TabPageAuteurs.Controls.Add(Me.TextBox15)
        Me.TabPageAuteurs.Controls.Add(Me.TextBox14)
        Me.TabPageAuteurs.Controls.Add(Me.TextBox13)
        Me.TabPageAuteurs.Controls.Add(Me.TextBoxThanks)
        Me.TabPageAuteurs.Controls.Add(Me.TextBoxContributors)
        Me.TabPageAuteurs.Controls.Add(Me.TextBoxTesters)
        Me.TabPageAuteurs.Controls.Add(Me.TextBoxDev)
        Me.TabPageAuteurs.Controls.Add(Me.TextBoxAdmin)
        Me.TabPageAuteurs.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAuteurs.Name = "TabPageAuteurs"
        Me.TabPageAuteurs.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAuteurs.Size = New System.Drawing.Size(281, 314)
        Me.TabPageAuteurs.TabIndex = 2
        Me.TabPageAuteurs.Text = "Auteurs"
        Me.TabPageAuteurs.UseVisualStyleBackColor = True
        '
        'TextBox17
        '
        Me.TextBox17.BackColor = System.Drawing.Color.White
        Me.TextBox17.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox17.Location = New System.Drawing.Point(2, 274)
        Me.TextBox17.Multiline = True
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.Size = New System.Drawing.Size(276, 27)
        Me.TextBox17.TabIndex = 11
        Me.TextBox17.Text = "Cricri" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Jacky67"
        Me.TextBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox16
        '
        Me.TextBox16.BackColor = System.Drawing.Color.White
        Me.TextBox16.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox16.Location = New System.Drawing.Point(2, 230)
        Me.TextBox16.Multiline = True
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(276, 27)
        Me.TextBox16.TabIndex = 10
        Me.TextBox16.Text = "kevinpato72" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "KaZeR"
        Me.TextBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox15
        '
        Me.TextBox15.BackColor = System.Drawing.Color.White
        Me.TextBox15.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox15.Location = New System.Drawing.Point(2, 109)
        Me.TextBox15.Multiline = True
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(276, 106)
        Me.TextBox15.TabIndex = 9
        Me.TextBox15.Text = "The Real Mc Coy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Starcrasher" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "molloc (momo)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "elicha" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tomaceli" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "newbie78" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manani" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
    "ZamEEmaZ"
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox14
        '
        Me.TextBox14.BackColor = System.Drawing.Color.White
        Me.TextBox14.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox14.Location = New System.Drawing.Point(2, 52)
        Me.TextBox14.Multiline = True
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(276, 43)
        Me.TextBox14.TabIndex = 8
        Me.TextBox14.Text = "barbeblanche" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ronaldo1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "rvs75"
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox13
        '
        Me.TextBox13.BackColor = System.Drawing.Color.White
        Me.TextBox13.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(2, 21)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(276, 14)
        Me.TextBox13.TabIndex = 7
        Me.TextBox13.Text = "Pascal Hubert aka Néo"
        Me.TextBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxThanks
        '
        Me.TextBoxThanks.BackColor = System.Drawing.Color.White
        Me.TextBoxThanks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxThanks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxThanks.Location = New System.Drawing.Point(2, 260)
        Me.TextBoxThanks.Name = "TextBoxThanks"
        Me.TextBoxThanks.ReadOnly = True
        Me.TextBoxThanks.Size = New System.Drawing.Size(276, 14)
        Me.TextBoxThanks.TabIndex = 5
        Me.TextBoxThanks.Text = "Remerciements"
        Me.TextBoxThanks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxContributors
        '
        Me.TextBoxContributors.BackColor = System.Drawing.Color.White
        Me.TextBoxContributors.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxContributors.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxContributors.Location = New System.Drawing.Point(2, 216)
        Me.TextBoxContributors.Name = "TextBoxContributors"
        Me.TextBoxContributors.ReadOnly = True
        Me.TextBoxContributors.Size = New System.Drawing.Size(276, 14)
        Me.TextBoxContributors.TabIndex = 4
        Me.TextBoxContributors.Text = "Contributeurs"
        Me.TextBoxContributors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxTesters
        '
        Me.TextBoxTesters.BackColor = System.Drawing.Color.White
        Me.TextBoxTesters.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxTesters.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTesters.Location = New System.Drawing.Point(2, 95)
        Me.TextBoxTesters.Name = "TextBoxTesters"
        Me.TextBoxTesters.ReadOnly = True
        Me.TextBoxTesters.Size = New System.Drawing.Size(276, 14)
        Me.TextBoxTesters.TabIndex = 3
        Me.TextBoxTesters.Text = "Bêta testeurs"
        Me.TextBoxTesters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDev
        '
        Me.TextBoxDev.BackColor = System.Drawing.Color.White
        Me.TextBoxDev.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxDev.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDev.Location = New System.Drawing.Point(2, 38)
        Me.TextBoxDev.Name = "TextBoxDev"
        Me.TextBoxDev.ReadOnly = True
        Me.TextBoxDev.Size = New System.Drawing.Size(276, 14)
        Me.TextBoxDev.TabIndex = 2
        Me.TextBoxDev.Text = "Développeurs"
        Me.TextBoxDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxAdmin
        '
        Me.TextBoxAdmin.BackColor = System.Drawing.Color.White
        Me.TextBoxAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxAdmin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAdmin.Location = New System.Drawing.Point(2, 7)
        Me.TextBoxAdmin.Name = "TextBoxAdmin"
        Me.TextBoxAdmin.ReadOnly = True
        Me.TextBoxAdmin.Size = New System.Drawing.Size(276, 14)
        Me.TextBoxAdmin.TabIndex = 1
        Me.TextBoxAdmin.Text = "Administrateur du projet"
        Me.TextBoxAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPagelicence
        '
        Me.TabPagelicence.Controls.Add(Me.LinkLabel1)
        Me.TabPagelicence.Controls.Add(Me.TextBoxLicence)
        Me.TabPagelicence.Location = New System.Drawing.Point(4, 22)
        Me.TabPagelicence.Name = "TabPagelicence"
        Me.TabPagelicence.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagelicence.Size = New System.Drawing.Size(281, 314)
        Me.TabPagelicence.TabIndex = 3
        Me.TabPagelicence.Text = "Licence"
        Me.TabPagelicence.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.White
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.Location = New System.Drawing.Point(48, 283)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(184, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://www.gnu.org/copyleft/gpl.html"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBoxLicence
        '
        Me.TextBoxLicence.BackColor = System.Drawing.Color.White
        Me.TextBoxLicence.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLicence.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBoxLicence.ForeColor = System.Drawing.Color.Black
        Me.TextBoxLicence.Location = New System.Drawing.Point(2, 12)
        Me.TextBoxLicence.Multiline = True
        Me.TextBoxLicence.Name = "TextBoxLicence"
        Me.TextBoxLicence.ReadOnly = True
        Me.TextBoxLicence.Size = New System.Drawing.Size(277, 265)
        Me.TextBoxLicence.TabIndex = 0
        Me.TextBoxLicence.Text = resources.GetString("TextBoxLicence.Text")
        Me.TextBoxLicence.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage7zip
        '
        Me.TabPage7zip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.TabPage7zip.Controls.Add(Me.TextBox8)
        Me.TabPage7zip.Controls.Add(Me.LinkLabel6)
        Me.TabPage7zip.Controls.Add(Me.TextBox7)
        Me.TabPage7zip.Controls.Add(Me.TextBox6)
        Me.TabPage7zip.Controls.Add(Me.LinkLabel5)
        Me.TabPage7zip.Controls.Add(Me.TextBox1)
        Me.TabPage7zip.Controls.Add(Me.LinkLabel4)
        Me.TabPage7zip.Controls.Add(Me.TextBox5)
        Me.TabPage7zip.Controls.Add(Me.TextBox4)
        Me.TabPage7zip.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7zip.Name = "TabPage7zip"
        Me.TabPage7zip.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7zip.Size = New System.Drawing.Size(281, 314)
        Me.TabPage7zip.TabIndex = 4
        Me.TabPage7zip.Text = "Crédits"
        Me.TabPage7zip.UseVisualStyleBackColor = True
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.Color.White
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox8.Location = New System.Drawing.Point(11, 159)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(261, 13)
        Me.TextBox8.TabIndex = 45
        Me.TextBox8.Text = "markheath © 2012"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel6
        '
        Me.LinkLabel6.Location = New System.Drawing.Point(10, 143)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(263, 14)
        Me.LinkLabel6.TabIndex = 44
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "http://naudio.codeplex.com/"
        Me.LinkLabel6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.Color.White
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox7.Location = New System.Drawing.Point(7, 129)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(266, 13)
        Me.TextBox7.TabIndex = 43
        Me.TextBox7.Text = "ZGuideTV.NET uses NAudio"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.White
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Location = New System.Drawing.Point(10, 221)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(263, 13)
        Me.TextBox6.TabIndex = 6
        Me.TextBox6.Text = "Microsoft Codeplex © 2006-2013 Microsoft"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel5
        '
        Me.LinkLabel5.Location = New System.Drawing.Point(10, 205)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(263, 13)
        Me.LinkLabel5.TabIndex = 5
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "http://www.codeplex.com/"
        Me.LinkLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(10, 191)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(263, 13)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "ZGuideTV.NET is hosted by Microsoft Codeplex"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel4
        '
        Me.LinkLabel4.Location = New System.Drawing.Point(7, 81)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(267, 14)
        Me.LinkLabel4.TabIndex = 3
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "http://www.7-zip.org/"
        Me.LinkLabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.White
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Location = New System.Drawing.Point(7, 97)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(267, 13)
        Me.TextBox5.TabIndex = 2
        Me.TextBox5.Text = "7-Zip is licensed under the GNU LGPL license"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox4.Location = New System.Drawing.Point(7, 67)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(267, 13)
        Me.TextBox4.TabIndex = 1
        Me.TextBox4.Text = "ZGuideTV.NET uses parts of the 7-Zip program"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPageDonate
        '
        Me.TabPageDonate.Controls.Add(Me.PictureBoxPaypal)
        Me.TabPageDonate.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDonate.Name = "TabPageDonate"
        Me.TabPageDonate.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDonate.Size = New System.Drawing.Size(281, 314)
        Me.TabPageDonate.TabIndex = 5
        Me.TabPageDonate.Text = "Donation"
        Me.TabPageDonate.UseVisualStyleBackColor = True
        '
        'PictureBoxPaypal
        '
        Me.PictureBoxPaypal.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.paypaldonate1
        Me.PictureBoxPaypal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBoxPaypal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxPaypal.Location = New System.Drawing.Point(75, 99)
        Me.PictureBoxPaypal.Name = "PictureBoxPaypal"
        Me.PictureBoxPaypal.Size = New System.Drawing.Size(130, 114)
        Me.PictureBoxPaypal.TabIndex = 0
        Me.PictureBoxPaypal.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.splash_bleu_tv
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(25, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(210, 264)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(460, 375)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'About
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(560, 407)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.TextBoxCredit)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - A propos de"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageAbout.ResumeLayout(False)
        Me.TabPageAbout.PerformLayout()
        Me.TabPageAuteurs.ResumeLayout(False)
        Me.TabPageAuteurs.PerformLayout()
        Me.TabPagelicence.ResumeLayout(False)
        Me.TabPagelicence.PerformLayout()
        Me.TabPage7zip.ResumeLayout(False)
        Me.TabPage7zip.PerformLayout()
        Me.TabPageDonate.ResumeLayout(False)
        CType(Me.PictureBoxPaypal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents TextBoxCredit As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageAbout As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxCopyright As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TabPageAuteurs As System.Windows.Forms.TabPage
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxThanks As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxContributors As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTesters As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDev As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAdmin As System.Windows.Forms.TextBox
    Friend WithEvents TabPagelicence As System.Windows.Forms.TabPage
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents TextBoxLicence As System.Windows.Forms.TextBox
    Friend WithEvents TabPage7zip As System.Windows.Forms.TabPage
    Private WithEvents TextBox8 As System.Windows.Forms.TextBox
    Private WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Private WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TabPageDonate As System.Windows.Forms.TabPage
    Private WithEvents PictureBoxPaypal As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBoxVersion As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCompilationDate As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCompiledOn As System.Windows.Forms.TextBox
End Class
