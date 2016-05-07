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
Imports System.ComponentModel

Public Class About
    Inherits Form

    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' On regarde quel langue utiliser 22/08/2008
        LanguageCheck(18)

    End Sub

    Public Sub New()
        MyBase.New()

        InitializeComponent()

        Initalize()
    End Sub

    ' La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As IContainer

    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageAbout As TabPage
    Friend WithEvents TabPageAuteurs As TabPage
    Friend WithEvents TextBoxLicence As TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents TabPage7zip As TabPage
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBoxDev As TextBox
    Friend WithEvents TextBoxAdmin As TextBox
    Friend WithEvents TextBoxThanks As TextBox
    Friend WithEvents TextBoxContributors As TextBox
    Friend WithEvents TextBoxTesters As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents TextBoxCredit As TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents TextBox1 As TextBox

    Private WithEvents _line1 As Label

    Public Property Line1 As Label
        Get
            Return _line1
        End Get
        Set(ByVal value As Label)
            _line1 = Value
        End Set
    End Property

    Private WithEvents _label1 As Label

    Public Property Label1 As Label
        Get
            Return _label1
        End Get
        Set(ByVal value As Label)
            _label1 = Value
        End Set
    End Property

    Private WithEvents _label2 As Label

    Public Property Label2 As Label
        Get
            Return _label2
        End Get
        Set(ByVal value As Label)
            _label2 = value
        End Set
    End Property

    Friend WithEvents TabPageDonate As TabPage
    Private WithEvents PictureBoxPaypal As PictureBox
    Friend WithEvents TabPagelicence As TabPage

    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageAbout = New System.Windows.Forms.TabPage()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
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
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TabPageDonate = New System.Windows.Forms.TabPage()
        Me.PictureBoxPaypal = New System.Windows.Forms.PictureBox()
        Me.TextBoxCredit = New System.Windows.Forms.TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPageAbout.SuspendLayout()
        Me.TabPageAuteurs.SuspendLayout()
        Me.TabPagelicence.SuspendLayout()
        Me.TabPage7zip.SuspendLayout()
        Me.TabPageDonate.SuspendLayout()
        CType(Me.PictureBoxPaypal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(450, 372)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.splash_bleu_tv
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(15, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(210, 264)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageAbout)
        Me.TabControl1.Controls.Add(Me.TabPageAuteurs)
        Me.TabControl1.Controls.Add(Me.TabPagelicence)
        Me.TabControl1.Controls.Add(Me.TabPage7zip)
        Me.TabControl1.Controls.Add(Me.TabPageDonate)
        Me.TabControl1.Location = New System.Drawing.Point(240, 23)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(289, 340)
        Me.TabControl1.TabIndex = 3
        '
        'TabPageAbout
        '
        Me.TabPageAbout.BackColor = System.Drawing.Color.White
        Me.TabPageAbout.Controls.Add(Me.TextBox3)
        Me.TabPageAbout.Controls.Add(Me.LinkLabel2)
        Me.TabPageAbout.Controls.Add(Me.TextBox2)
        Me.TabPageAbout.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAbout.Name = "TabPageAbout"
        Me.TabPageAbout.Size = New System.Drawing.Size(281, 314)
        Me.TabPageAbout.TabIndex = 0
        Me.TabPageAbout.Text = "A Propos"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox3.Location = New System.Drawing.Point(8, 158)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(263, 13)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = "Copyright © 2004 - 2013 ZGuideTV Team"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel2.Location = New System.Drawing.Point(38, 129)
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
        Me.TextBox13.Text = "Néo"
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
        'TextBox6
        '
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Location = New System.Drawing.Point(10, 179)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(263, 13)
        Me.TextBox6.TabIndex = 6
        Me.TextBox6.Text = "Microsoft Codeplex © 2006-2013 Microsoft"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel5
        '
        Me.LinkLabel5.Location = New System.Drawing.Point(10, 163)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(263, 13)
        Me.LinkLabel5.TabIndex = 5
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "http://www.codeplex.com/"
        Me.LinkLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(10, 149)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(263, 13)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "ZGuideTV.NET is hosted by Microsoft Codeplex"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel4
        '
        Me.LinkLabel4.Location = New System.Drawing.Point(7, 113)
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
        Me.TextBox5.Location = New System.Drawing.Point(7, 129)
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
        Me.TextBox4.Location = New System.Drawing.Point(7, 99)
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
        'TextBoxCredit
        '
        Me.TextBoxCredit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCredit.Location = New System.Drawing.Point(16, 317)
        Me.TextBoxCredit.Name = "TextBoxCredit"
        Me.TextBoxCredit.Size = New System.Drawing.Size(208, 13)
        Me.TextBoxCredit.TabIndex = 4
        Me.TextBoxCredit.Text = "Logo created and designed by djeric"
        Me.TextBoxCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel3
        '
        Me.LinkLabel3.Location = New System.Drawing.Point(16, 332)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(208, 16)
        Me.LinkLabel3.TabIndex = 5
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "http://igloo.crystalxp.net/djeric"
        Me.LinkLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - A propos de"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub Initalize()
        'Initialisations

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        Process.Start("http://www.7-zip.org/")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel2.LinkClicked
        Process.Start("http://zguidetv.codeplex.com/")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel3.LinkClicked
        Process.Start("http://igloo.crystalxp.net/djeric")
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel4.LinkClicked
        Process.Start("http://www.7-zip.org/")
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel5.LinkClicked
        Process.Start("http://www.codeplex.com/")
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs)

        Process.Start("http://technet.microsoft.com/en-us/sysinternals/")
    End Sub

    Private Sub PictureBoxPaypal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBoxPaypal.Click
        Try

            ' Modifié par Néo le 28/01/2010
            If ConnectionAvailable.IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("https://www.paypal.com/") Then
                Process.Start( _
                               "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=neojudgment%40hotmail%2ecom&lc=BE&item_name=ZGuideTV%20Team&currency_code=EUR&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted")

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur Paypal
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1, _
                                     Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As Net.WebException

            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(Mainform.MessageBoxNoConnection & Chr(13) & Mainform.MessageBoxNoConnection1, _
                                 Mainform.MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class
