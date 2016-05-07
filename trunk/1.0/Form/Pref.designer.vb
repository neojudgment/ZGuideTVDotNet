<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pref
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pref))
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.TabPageCesoirMaintenant = New System.Windows.Forms.TabPage()
        Me.GroupBoxMaintenant = New System.Windows.Forms.GroupBox()
        Me.RadioButtonMaintenant120 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMaintenant105 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMaintenant90 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMaintenant75 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMaintenant60 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMaintenant45 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMaintenantAll = New System.Windows.Forms.RadioButton()
        Me.GroupBoxCesoir = New System.Windows.Forms.GroupBox()
        Me.RadioButtonCesoirAll = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCesoir120 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCesoir105 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCesoir90 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCesoir75 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCesoir60 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCesoir45 = New System.Windows.Forms.RadioButton()
        Me.TabPageMiseajourLogiciel = New System.Windows.Forms.TabPage()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.GroupBoxCheckIn = New System.Windows.Forms.GroupBox()
        Me.LabelCheckIn = New System.Windows.Forms.Label()
        Me.GroupBoxNextCheck = New System.Windows.Forms.GroupBox()
        Me.TextBoxNextUpdate = New System.Windows.Forms.TextBox()
        Me.GroupBoxLastCheck = New System.Windows.Forms.GroupBox()
        Me.TextBoxLastUpdate = New System.Windows.Forms.TextBox()
        Me.GroupBoxCheck = New System.Windows.Forms.GroupBox()
        Me.CheckBoxAutoverif = New System.Windows.Forms.CheckBox()
        Me.GroupBoxIntervalles = New System.Windows.Forms.GroupBox()
        Me.RadioButtonAllMonths = New System.Windows.Forms.RadioButton()
        Me.RadioButtonAllWeeks = New System.Windows.Forms.RadioButton()
        Me.RadioButtonAllDays = New System.Windows.Forms.RadioButton()
        Me.TabPageMiseajourDonnees = New System.Windows.Forms.TabPage()
        Me.GroupBoxEpgdata = New System.Windows.Forms.GroupBox()
        Me.LabelNbJourDownload = New System.Windows.Forms.Label()
        Me.NumericUpDownDownloadEpgdata = New System.Windows.Forms.NumericUpDown()
        Me.LabelEpgdataExpiration = New System.Windows.Forms.Label()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.LabelPinCode = New System.Windows.Forms.Label()
        Me.BoutonSAbonner = New System.Windows.Forms.Button()
        Me.tbPin = New System.Windows.Forms.TextBox()
        Me.GroupBoxChoixSource = New System.Windows.Forms.GroupBox()
        Me.RadioButtonEPGData = New System.Windows.Forms.RadioButton()
        Me.RadioButtonXMLTV = New System.Windows.Forms.RadioButton()
        Me.GroupBoxTailleBdd = New System.Windows.Forms.GroupBox()
        Me.TextBoxTailleBdd = New System.Windows.Forms.TextBox()
        Me.GroupBoxUpdateNext = New System.Windows.Forms.GroupBox()
        Me.TextBoxUpdateNext = New System.Windows.Forms.TextBox()
        Me.GroupBoxUpdateIn = New System.Windows.Forms.GroupBox()
        Me.LabelUpdateIn = New System.Windows.Forms.Label()
        Me.GroupBoxUpdateLast = New System.Windows.Forms.GroupBox()
        Me.TextBoxUpdateLast = New System.Windows.Forms.TextBox()
        Me.GroupBoxIntervalle = New System.Windows.Forms.GroupBox()
        Me.RadioButtonDay5 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDay4 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDay3 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDay2 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDay1 = New System.Windows.Forms.RadioButton()
        Me.GroupBoxAutoUpdate = New System.Windows.Forms.GroupBox()
        Me.CheckBoxAutoUpdate = New System.Windows.Forms.CheckBox()
        Me.TabPageProxy = New System.Windows.Forms.TabPage()
        Me.GroupBoxProxy = New System.Windows.Forms.GroupBox()
        Me.ProxyPort = New System.Windows.Forms.NumericUpDown()
        Me.LabelProxy = New System.Windows.Forms.Label()
        Me.LabelPort = New System.Windows.Forms.Label()
        Me.ProxyHost = New System.Windows.Forms.TextBox()
        Me.GroupBoxConnexion = New System.Windows.Forms.GroupBox()
        Me.LabelUtilisateur = New System.Windows.Forms.Label()
        Me.LabelMotdePasse = New System.Windows.Forms.Label()
        Me.Login = New System.Windows.Forms.TextBox()
        Me.Pass = New System.Windows.Forms.TextBox()
        Me.TabPageGeneral = New System.Windows.Forms.TabPage()
        Me.GroupBoxToolTipsBallon = New System.Windows.Forms.GroupBox()
        Me.CheckBoxToolTipsBallon = New System.Windows.Forms.CheckBox()
        Me.GroupBoxUrlUpdate = New System.Windows.Forms.GroupBox()
        Me.CheckBoxUrlUpdate = New System.Windows.Forms.CheckBox()
        Me.GroupBoxMouse = New System.Windows.Forms.GroupBox()
        Me.CheckBoxaccordscrollhorizontal = New System.Windows.Forms.CheckBox()
        Me.GroupBoxConfHardware = New System.Windows.Forms.GroupBox()
        Me.RadioButtonConfMinimum = New System.Windows.Forms.RadioButton()
        Me.RadioButtonConfAverage = New System.Windows.Forms.RadioButton()
        Me.RadioButtonConfNormal = New System.Windows.Forms.RadioButton()
        Me.GroupBoxPosition = New System.Windows.Forms.GroupBox()
        Me.CheckBoxbuttonssave = New System.Windows.Forms.CheckBox()
        Me.GroupBoxFiltres = New System.Windows.Forms.GroupBox()
        Me.CheckBoxFilters = New System.Windows.Forms.CheckBox()
        Me.GroupBoxDivers = New System.Windows.Forms.GroupBox()
        Me.CheckBoxtracelog = New System.Windows.Forms.CheckBox()
        Me.GroupBoxSauvegardeFenetre = New System.Windows.Forms.GroupBox()
        Me.CheckBoxConfigWindow = New System.Windows.Forms.CheckBox()
        Me.GroupBoxPurge = New System.Windows.Forms.GroupBox()
        Me.CheckBoxPurge = New System.Windows.Forms.CheckBox()
        Me.GroupBoxEffects = New System.Windows.Forms.GroupBox()
        Me.CheckBoxoldUI = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSlide = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFadeOut = New System.Windows.Forms.CheckBox()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPageResume = New System.Windows.Forms.TabPage()
        Me.GroupBoxResume = New System.Windows.Forms.GroupBox()
        Me.CheckBoxResume = New System.Windows.Forms.CheckBox()
        Me.GroupBoxResumeBefore = New System.Windows.Forms.GroupBox()
        Me.RadioButtonResume15 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonResume30 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonResume10 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonResume20 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonResume5 = New System.Windows.Forms.RadioButton()
        Me.TabPageSound = New System.Windows.Forms.TabPage()
        Me.GroupBoxMute = New System.Windows.Forms.GroupBox()
        Me.CheckBoxAudioOn = New System.Windows.Forms.CheckBox()
        Me.GroupBoxMasterVolume = New System.Windows.Forms.GroupBox()
        Me.TrackBarMasterVolume = New System.Windows.Forms.TrackBar()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.GroupBoxReminder = New System.Windows.Forms.GroupBox()
        Me.ComboBoxReminder = New System.Windows.Forms.ComboBox()
        Me.ButtonReminderSound = New System.Windows.Forms.Button()
        Me.TrackBarReminder = New System.Windows.Forms.TrackBar()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.GroupBoxMessages = New System.Windows.Forms.GroupBox()
        Me.ComboBoxMessages = New System.Windows.Forms.ComboBox()
        Me.ButtonMessagesSound = New System.Windows.Forms.Button()
        Me.TrackBarMessages = New System.Windows.Forms.TrackBar()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GroupBoxRSS = New System.Windows.Forms.GroupBox()
        Me.ComboBoxRSS = New System.Windows.Forms.ComboBox()
        Me.ButtonRSSSound = New System.Windows.Forms.Button()
        Me.TrackBarRSS = New System.Windows.Forms.TrackBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TabPageCesoirMaintenant.SuspendLayout()
        Me.GroupBoxMaintenant.SuspendLayout()
        Me.GroupBoxCesoir.SuspendLayout()
        Me.TabPageMiseajourLogiciel.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxCheckIn.SuspendLayout()
        Me.GroupBoxNextCheck.SuspendLayout()
        Me.GroupBoxLastCheck.SuspendLayout()
        Me.GroupBoxCheck.SuspendLayout()
        Me.GroupBoxIntervalles.SuspendLayout()
        Me.TabPageMiseajourDonnees.SuspendLayout()
        Me.GroupBoxEpgdata.SuspendLayout()
        CType(Me.NumericUpDownDownloadEpgdata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxChoixSource.SuspendLayout()
        Me.GroupBoxTailleBdd.SuspendLayout()
        Me.GroupBoxUpdateNext.SuspendLayout()
        Me.GroupBoxUpdateIn.SuspendLayout()
        Me.GroupBoxUpdateLast.SuspendLayout()
        Me.GroupBoxIntervalle.SuspendLayout()
        Me.GroupBoxAutoUpdate.SuspendLayout()
        Me.TabPageProxy.SuspendLayout()
        Me.GroupBoxProxy.SuspendLayout()
        CType(Me.ProxyPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxConnexion.SuspendLayout()
        Me.TabPageGeneral.SuspendLayout()
        Me.GroupBoxToolTipsBallon.SuspendLayout()
        Me.GroupBoxUrlUpdate.SuspendLayout()
        Me.GroupBoxMouse.SuspendLayout()
        Me.GroupBoxConfHardware.SuspendLayout()
        Me.GroupBoxPosition.SuspendLayout()
        Me.GroupBoxFiltres.SuspendLayout()
        Me.GroupBoxDivers.SuspendLayout()
        Me.GroupBoxSauvegardeFenetre.SuspendLayout()
        Me.GroupBoxPurge.SuspendLayout()
        Me.GroupBoxEffects.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPageResume.SuspendLayout()
        Me.GroupBoxResume.SuspendLayout()
        Me.GroupBoxResumeBefore.SuspendLayout()
        Me.TabPageSound.SuspendLayout()
        Me.GroupBoxMute.SuspendLayout()
        Me.GroupBoxMasterVolume.SuspendLayout()
        CType(Me.TrackBarMasterVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxReminder.SuspendLayout()
        CType(Me.TrackBarReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMessages.SuspendLayout()
        CType(Me.TrackBarMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxRSS.SuspendLayout()
        CType(Me.TrackBarRSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(12, 330)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(111, 25)
        Me.ButtonOK.TabIndex = 11
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(129, 330)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(111, 25)
        Me.ButtonCancel.TabIndex = 12
        Me.ButtonCancel.Text = "Annuler"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'TabPageCesoirMaintenant
        '
        Me.TabPageCesoirMaintenant.BackColor = System.Drawing.Color.White
        Me.TabPageCesoirMaintenant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPageCesoirMaintenant.Controls.Add(Me.GroupBoxMaintenant)
        Me.TabPageCesoirMaintenant.Controls.Add(Me.GroupBoxCesoir)
        Me.TabPageCesoirMaintenant.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCesoirMaintenant.Name = "TabPageCesoirMaintenant"
        Me.TabPageCesoirMaintenant.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCesoirMaintenant.Size = New System.Drawing.Size(443, 290)
        Me.TabPageCesoirMaintenant.TabIndex = 5
        Me.TabPageCesoirMaintenant.Text = "Ce soir et Maintenant"
        '
        'GroupBoxMaintenant
        '
        Me.GroupBoxMaintenant.Controls.Add(Me.RadioButtonMaintenant120)
        Me.GroupBoxMaintenant.Controls.Add(Me.RadioButtonMaintenant105)
        Me.GroupBoxMaintenant.Controls.Add(Me.RadioButtonMaintenant90)
        Me.GroupBoxMaintenant.Controls.Add(Me.RadioButtonMaintenant75)
        Me.GroupBoxMaintenant.Controls.Add(Me.RadioButtonMaintenant60)
        Me.GroupBoxMaintenant.Controls.Add(Me.RadioButtonMaintenant45)
        Me.GroupBoxMaintenant.Controls.Add(Me.RadioButtonMaintenantAll)
        Me.GroupBoxMaintenant.Location = New System.Drawing.Point(227, 74)
        Me.GroupBoxMaintenant.Name = "GroupBoxMaintenant"
        Me.GroupBoxMaintenant.Size = New System.Drawing.Size(196, 119)
        Me.GroupBoxMaintenant.TabIndex = 15
        Me.GroupBoxMaintenant.TabStop = False
        Me.GroupBoxMaintenant.Text = "Maintenant"
        '
        'RadioButtonMaintenant120
        '
        Me.RadioButtonMaintenant120.AutoSize = True
        Me.RadioButtonMaintenant120.Location = New System.Drawing.Point(85, 90)
        Me.RadioButtonMaintenant120.Name = "RadioButtonMaintenant120"
        Me.RadioButtonMaintenant120.Size = New System.Drawing.Size(82, 17)
        Me.RadioButtonMaintenant120.TabIndex = 6
        Me.RadioButtonMaintenant120.TabStop = True
        Me.RadioButtonMaintenant120.Text = "120 minutes"
        Me.RadioButtonMaintenant120.UseVisualStyleBackColor = True
        '
        'RadioButtonMaintenant105
        '
        Me.RadioButtonMaintenant105.AutoSize = True
        Me.RadioButtonMaintenant105.Location = New System.Drawing.Point(85, 67)
        Me.RadioButtonMaintenant105.Name = "RadioButtonMaintenant105"
        Me.RadioButtonMaintenant105.Size = New System.Drawing.Size(82, 17)
        Me.RadioButtonMaintenant105.TabIndex = 5
        Me.RadioButtonMaintenant105.TabStop = True
        Me.RadioButtonMaintenant105.Text = "105 minutes"
        Me.RadioButtonMaintenant105.UseVisualStyleBackColor = True
        '
        'RadioButtonMaintenant90
        '
        Me.RadioButtonMaintenant90.AutoSize = True
        Me.RadioButtonMaintenant90.Location = New System.Drawing.Point(85, 44)
        Me.RadioButtonMaintenant90.Name = "RadioButtonMaintenant90"
        Me.RadioButtonMaintenant90.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButtonMaintenant90.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonMaintenant90.TabIndex = 4
        Me.RadioButtonMaintenant90.TabStop = True
        Me.RadioButtonMaintenant90.Text = "90 minutes"
        Me.RadioButtonMaintenant90.UseVisualStyleBackColor = True
        '
        'RadioButtonMaintenant75
        '
        Me.RadioButtonMaintenant75.AutoSize = True
        Me.RadioButtonMaintenant75.Location = New System.Drawing.Point(7, 90)
        Me.RadioButtonMaintenant75.Name = "RadioButtonMaintenant75"
        Me.RadioButtonMaintenant75.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonMaintenant75.TabIndex = 3
        Me.RadioButtonMaintenant75.Text = "75 minutes"
        Me.RadioButtonMaintenant75.UseVisualStyleBackColor = True
        '
        'RadioButtonMaintenant60
        '
        Me.RadioButtonMaintenant60.AutoSize = True
        Me.RadioButtonMaintenant60.Location = New System.Drawing.Point(7, 67)
        Me.RadioButtonMaintenant60.Name = "RadioButtonMaintenant60"
        Me.RadioButtonMaintenant60.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonMaintenant60.TabIndex = 2
        Me.RadioButtonMaintenant60.Text = "60 minutes"
        Me.RadioButtonMaintenant60.UseVisualStyleBackColor = True
        '
        'RadioButtonMaintenant45
        '
        Me.RadioButtonMaintenant45.AutoSize = True
        Me.RadioButtonMaintenant45.Location = New System.Drawing.Point(7, 44)
        Me.RadioButtonMaintenant45.Name = "RadioButtonMaintenant45"
        Me.RadioButtonMaintenant45.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonMaintenant45.TabIndex = 1
        Me.RadioButtonMaintenant45.Text = "45 minutes"
        Me.RadioButtonMaintenant45.UseVisualStyleBackColor = True
        '
        'RadioButtonMaintenantAll
        '
        Me.RadioButtonMaintenantAll.AutoSize = True
        Me.RadioButtonMaintenantAll.Checked = True
        Me.RadioButtonMaintenantAll.Location = New System.Drawing.Point(7, 21)
        Me.RadioButtonMaintenantAll.Name = "RadioButtonMaintenantAll"
        Me.RadioButtonMaintenantAll.Size = New System.Drawing.Size(82, 17)
        Me.RadioButtonMaintenantAll.TabIndex = 0
        Me.RadioButtonMaintenantAll.TabStop = True
        Me.RadioButtonMaintenantAll.Text = "Afficher tout"
        Me.RadioButtonMaintenantAll.UseVisualStyleBackColor = True
        '
        'GroupBoxCesoir
        '
        Me.GroupBoxCesoir.Controls.Add(Me.RadioButtonCesoirAll)
        Me.GroupBoxCesoir.Controls.Add(Me.RadioButtonCesoir120)
        Me.GroupBoxCesoir.Controls.Add(Me.RadioButtonCesoir105)
        Me.GroupBoxCesoir.Controls.Add(Me.RadioButtonCesoir90)
        Me.GroupBoxCesoir.Controls.Add(Me.RadioButtonCesoir75)
        Me.GroupBoxCesoir.Controls.Add(Me.RadioButtonCesoir60)
        Me.GroupBoxCesoir.Controls.Add(Me.RadioButtonCesoir45)
        Me.GroupBoxCesoir.Location = New System.Drawing.Point(14, 74)
        Me.GroupBoxCesoir.Name = "GroupBoxCesoir"
        Me.GroupBoxCesoir.Size = New System.Drawing.Size(196, 119)
        Me.GroupBoxCesoir.TabIndex = 13
        Me.GroupBoxCesoir.TabStop = False
        Me.GroupBoxCesoir.Text = "Ce soir"
        '
        'RadioButtonCesoirAll
        '
        Me.RadioButtonCesoirAll.AutoSize = True
        Me.RadioButtonCesoirAll.Location = New System.Drawing.Point(7, 21)
        Me.RadioButtonCesoirAll.Name = "RadioButtonCesoirAll"
        Me.RadioButtonCesoirAll.Size = New System.Drawing.Size(82, 17)
        Me.RadioButtonCesoirAll.TabIndex = 6
        Me.RadioButtonCesoirAll.TabStop = True
        Me.RadioButtonCesoirAll.Text = "Afficher tout"
        Me.RadioButtonCesoirAll.UseVisualStyleBackColor = True
        '
        'RadioButtonCesoir120
        '
        Me.RadioButtonCesoir120.AutoSize = True
        Me.RadioButtonCesoir120.Location = New System.Drawing.Point(85, 90)
        Me.RadioButtonCesoir120.Name = "RadioButtonCesoir120"
        Me.RadioButtonCesoir120.Size = New System.Drawing.Size(82, 17)
        Me.RadioButtonCesoir120.TabIndex = 5
        Me.RadioButtonCesoir120.TabStop = True
        Me.RadioButtonCesoir120.Text = "120 minutes"
        Me.RadioButtonCesoir120.UseVisualStyleBackColor = True
        '
        'RadioButtonCesoir105
        '
        Me.RadioButtonCesoir105.AutoSize = True
        Me.RadioButtonCesoir105.Location = New System.Drawing.Point(85, 67)
        Me.RadioButtonCesoir105.Name = "RadioButtonCesoir105"
        Me.RadioButtonCesoir105.Size = New System.Drawing.Size(82, 17)
        Me.RadioButtonCesoir105.TabIndex = 4
        Me.RadioButtonCesoir105.Text = "105 minutes"
        Me.RadioButtonCesoir105.UseVisualStyleBackColor = True
        '
        'RadioButtonCesoir90
        '
        Me.RadioButtonCesoir90.AutoSize = True
        Me.RadioButtonCesoir90.Location = New System.Drawing.Point(85, 44)
        Me.RadioButtonCesoir90.Name = "RadioButtonCesoir90"
        Me.RadioButtonCesoir90.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonCesoir90.TabIndex = 3
        Me.RadioButtonCesoir90.Text = "90 minutes"
        Me.RadioButtonCesoir90.UseVisualStyleBackColor = True
        '
        'RadioButtonCesoir75
        '
        Me.RadioButtonCesoir75.AutoSize = True
        Me.RadioButtonCesoir75.Location = New System.Drawing.Point(7, 90)
        Me.RadioButtonCesoir75.Name = "RadioButtonCesoir75"
        Me.RadioButtonCesoir75.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonCesoir75.TabIndex = 2
        Me.RadioButtonCesoir75.TabStop = True
        Me.RadioButtonCesoir75.Text = "75 minutes"
        Me.RadioButtonCesoir75.UseVisualStyleBackColor = True
        '
        'RadioButtonCesoir60
        '
        Me.RadioButtonCesoir60.AutoSize = True
        Me.RadioButtonCesoir60.Checked = True
        Me.RadioButtonCesoir60.Location = New System.Drawing.Point(7, 67)
        Me.RadioButtonCesoir60.Name = "RadioButtonCesoir60"
        Me.RadioButtonCesoir60.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonCesoir60.TabIndex = 1
        Me.RadioButtonCesoir60.TabStop = True
        Me.RadioButtonCesoir60.Text = "60 minutes"
        Me.RadioButtonCesoir60.UseVisualStyleBackColor = True
        '
        'RadioButtonCesoir45
        '
        Me.RadioButtonCesoir45.AutoSize = True
        Me.RadioButtonCesoir45.Location = New System.Drawing.Point(7, 44)
        Me.RadioButtonCesoir45.Name = "RadioButtonCesoir45"
        Me.RadioButtonCesoir45.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonCesoir45.TabIndex = 0
        Me.RadioButtonCesoir45.TabStop = True
        Me.RadioButtonCesoir45.Text = "45 minutes"
        Me.RadioButtonCesoir45.UseVisualStyleBackColor = True
        '
        'TabPageMiseajourLogiciel
        '
        Me.TabPageMiseajourLogiciel.BackColor = System.Drawing.Color.White
        Me.TabPageMiseajourLogiciel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPageMiseajourLogiciel.Controls.Add(Me.PictureBox6)
        Me.TabPageMiseajourLogiciel.Controls.Add(Me.GroupBoxCheckIn)
        Me.TabPageMiseajourLogiciel.Controls.Add(Me.GroupBoxNextCheck)
        Me.TabPageMiseajourLogiciel.Controls.Add(Me.GroupBoxLastCheck)
        Me.TabPageMiseajourLogiciel.Controls.Add(Me.GroupBoxCheck)
        Me.TabPageMiseajourLogiciel.Controls.Add(Me.GroupBoxIntervalles)
        Me.TabPageMiseajourLogiciel.Location = New System.Drawing.Point(4, 22)
        Me.TabPageMiseajourLogiciel.Name = "TabPageMiseajourLogiciel"
        Me.TabPageMiseajourLogiciel.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMiseajourLogiciel.Size = New System.Drawing.Size(443, 290)
        Me.TabPageMiseajourLogiciel.TabIndex = 3
        Me.TabPageMiseajourLogiciel.Text = "Mises à jour logiciel"
        '
        'PictureBox6
        '
        Me.PictureBox6.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.bleu_tv_ericdesign1
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox6.Location = New System.Drawing.Point(257, 142)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(116, 131)
        Me.PictureBox6.TabIndex = 17
        Me.PictureBox6.TabStop = False
        '
        'GroupBoxCheckIn
        '
        Me.GroupBoxCheckIn.Controls.Add(Me.LabelCheckIn)
        Me.GroupBoxCheckIn.Location = New System.Drawing.Point(227, 99)
        Me.GroupBoxCheckIn.Name = "GroupBoxCheckIn"
        Me.GroupBoxCheckIn.Size = New System.Drawing.Size(180, 35)
        Me.GroupBoxCheckIn.TabIndex = 5
        Me.GroupBoxCheckIn.TabStop = False
        Me.GroupBoxCheckIn.Text = "Vérification dans"
        '
        'LabelCheckIn
        '
        Me.LabelCheckIn.Location = New System.Drawing.Point(5, 16)
        Me.LabelCheckIn.Name = "LabelCheckIn"
        Me.LabelCheckIn.Size = New System.Drawing.Size(164, 13)
        Me.LabelCheckIn.TabIndex = 0
        '
        'GroupBoxNextCheck
        '
        Me.GroupBoxNextCheck.Controls.Add(Me.TextBoxNextUpdate)
        Me.GroupBoxNextCheck.Location = New System.Drawing.Point(21, 178)
        Me.GroupBoxNextCheck.Name = "GroupBoxNextCheck"
        Me.GroupBoxNextCheck.Size = New System.Drawing.Size(180, 35)
        Me.GroupBoxNextCheck.TabIndex = 4
        Me.GroupBoxNextCheck.TabStop = False
        Me.GroupBoxNextCheck.Text = "Prochaine vérification"
        '
        'TextBoxNextUpdate
        '
        Me.TextBoxNextUpdate.BackColor = System.Drawing.Color.White
        Me.TextBoxNextUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxNextUpdate.Location = New System.Drawing.Point(10, 16)
        Me.TextBoxNextUpdate.Name = "TextBoxNextUpdate"
        Me.TextBoxNextUpdate.ReadOnly = True
        Me.TextBoxNextUpdate.Size = New System.Drawing.Size(156, 13)
        Me.TextBoxNextUpdate.TabIndex = 0
        '
        'GroupBoxLastCheck
        '
        Me.GroupBoxLastCheck.Controls.Add(Me.TextBoxLastUpdate)
        Me.GroupBoxLastCheck.Location = New System.Drawing.Point(21, 137)
        Me.GroupBoxLastCheck.Name = "GroupBoxLastCheck"
        Me.GroupBoxLastCheck.Size = New System.Drawing.Size(180, 35)
        Me.GroupBoxLastCheck.TabIndex = 3
        Me.GroupBoxLastCheck.TabStop = False
        Me.GroupBoxLastCheck.Text = "Dernière vérification"
        '
        'TextBoxLastUpdate
        '
        Me.TextBoxLastUpdate.BackColor = System.Drawing.Color.White
        Me.TextBoxLastUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLastUpdate.Location = New System.Drawing.Point(10, 16)
        Me.TextBoxLastUpdate.Name = "TextBoxLastUpdate"
        Me.TextBoxLastUpdate.ReadOnly = True
        Me.TextBoxLastUpdate.Size = New System.Drawing.Size(156, 13)
        Me.TextBoxLastUpdate.TabIndex = 0
        '
        'GroupBoxCheck
        '
        Me.GroupBoxCheck.Controls.Add(Me.CheckBoxAutoverif)
        Me.GroupBoxCheck.Location = New System.Drawing.Point(227, 38)
        Me.GroupBoxCheck.Name = "GroupBoxCheck"
        Me.GroupBoxCheck.Size = New System.Drawing.Size(180, 46)
        Me.GroupBoxCheck.TabIndex = 2
        Me.GroupBoxCheck.TabStop = False
        Me.GroupBoxCheck.Text = "Vérification"
        '
        'CheckBoxAutoverif
        '
        Me.CheckBoxAutoverif.AutoSize = True
        Me.CheckBoxAutoverif.Checked = True
        Me.CheckBoxAutoverif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAutoverif.Location = New System.Drawing.Point(7, 20)
        Me.CheckBoxAutoverif.Name = "CheckBoxAutoverif"
        Me.CheckBoxAutoverif.Size = New System.Drawing.Size(139, 17)
        Me.CheckBoxAutoverif.TabIndex = 0
        Me.CheckBoxAutoverif.Text = "Vérification automatique"
        Me.CheckBoxAutoverif.UseVisualStyleBackColor = True
        '
        'GroupBoxIntervalles
        '
        Me.GroupBoxIntervalles.Controls.Add(Me.RadioButtonAllMonths)
        Me.GroupBoxIntervalles.Controls.Add(Me.RadioButtonAllWeeks)
        Me.GroupBoxIntervalles.Controls.Add(Me.RadioButtonAllDays)
        Me.GroupBoxIntervalles.Location = New System.Drawing.Point(21, 38)
        Me.GroupBoxIntervalles.Name = "GroupBoxIntervalles"
        Me.GroupBoxIntervalles.Size = New System.Drawing.Size(180, 93)
        Me.GroupBoxIntervalles.TabIndex = 1
        Me.GroupBoxIntervalles.TabStop = False
        Me.GroupBoxIntervalles.Text = "Intervalle des vérifications"
        '
        'RadioButtonAllMonths
        '
        Me.RadioButtonAllMonths.AutoSize = True
        Me.RadioButtonAllMonths.Location = New System.Drawing.Point(7, 67)
        Me.RadioButtonAllMonths.Name = "RadioButtonAllMonths"
        Me.RadioButtonAllMonths.Size = New System.Drawing.Size(89, 17)
        Me.RadioButtonAllMonths.TabIndex = 2
        Me.RadioButtonAllMonths.Text = "Tous les mois"
        Me.RadioButtonAllMonths.UseVisualStyleBackColor = True
        '
        'RadioButtonAllWeeks
        '
        Me.RadioButtonAllWeeks.AutoSize = True
        Me.RadioButtonAllWeeks.Checked = True
        Me.RadioButtonAllWeeks.Location = New System.Drawing.Point(7, 44)
        Me.RadioButtonAllWeeks.Name = "RadioButtonAllWeeks"
        Me.RadioButtonAllWeeks.Size = New System.Drawing.Size(121, 17)
        Me.RadioButtonAllWeeks.TabIndex = 1
        Me.RadioButtonAllWeeks.TabStop = True
        Me.RadioButtonAllWeeks.Text = "Toutes les semaines"
        Me.RadioButtonAllWeeks.UseVisualStyleBackColor = True
        '
        'RadioButtonAllDays
        '
        Me.RadioButtonAllDays.AutoSize = True
        Me.RadioButtonAllDays.Location = New System.Drawing.Point(7, 21)
        Me.RadioButtonAllDays.Name = "RadioButtonAllDays"
        Me.RadioButtonAllDays.Size = New System.Drawing.Size(90, 17)
        Me.RadioButtonAllDays.TabIndex = 0
        Me.RadioButtonAllDays.Text = "Tous les jours"
        Me.RadioButtonAllDays.UseVisualStyleBackColor = True
        '
        'TabPageMiseajourDonnees
        '
        Me.TabPageMiseajourDonnees.BackColor = System.Drawing.Color.White
        Me.TabPageMiseajourDonnees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPageMiseajourDonnees.Controls.Add(Me.GroupBoxEpgdata)
        Me.TabPageMiseajourDonnees.Controls.Add(Me.GroupBoxChoixSource)
        Me.TabPageMiseajourDonnees.Controls.Add(Me.GroupBoxTailleBdd)
        Me.TabPageMiseajourDonnees.Controls.Add(Me.GroupBoxUpdateNext)
        Me.TabPageMiseajourDonnees.Controls.Add(Me.GroupBoxUpdateIn)
        Me.TabPageMiseajourDonnees.Controls.Add(Me.GroupBoxUpdateLast)
        Me.TabPageMiseajourDonnees.Controls.Add(Me.GroupBoxIntervalle)
        Me.TabPageMiseajourDonnees.Controls.Add(Me.GroupBoxAutoUpdate)
        Me.TabPageMiseajourDonnees.Location = New System.Drawing.Point(4, 22)
        Me.TabPageMiseajourDonnees.Name = "TabPageMiseajourDonnees"
        Me.TabPageMiseajourDonnees.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMiseajourDonnees.Size = New System.Drawing.Size(443, 290)
        Me.TabPageMiseajourDonnees.TabIndex = 2
        Me.TabPageMiseajourDonnees.Text = "Mises à jour des données"
        '
        'GroupBoxEpgdata
        '
        Me.GroupBoxEpgdata.Controls.Add(Me.LabelNbJourDownload)
        Me.GroupBoxEpgdata.Controls.Add(Me.NumericUpDownDownloadEpgdata)
        Me.GroupBoxEpgdata.Controls.Add(Me.LabelEpgdataExpiration)
        Me.GroupBoxEpgdata.Controls.Add(Me.LabelInfo)
        Me.GroupBoxEpgdata.Controls.Add(Me.LabelPinCode)
        Me.GroupBoxEpgdata.Controls.Add(Me.BoutonSAbonner)
        Me.GroupBoxEpgdata.Controls.Add(Me.tbPin)
        Me.GroupBoxEpgdata.Enabled = False
        Me.GroupBoxEpgdata.Location = New System.Drawing.Point(27, 65)
        Me.GroupBoxEpgdata.Name = "GroupBoxEpgdata"
        Me.GroupBoxEpgdata.Size = New System.Drawing.Size(207, 172)
        Me.GroupBoxEpgdata.TabIndex = 9
        Me.GroupBoxEpgdata.TabStop = False
        Me.GroupBoxEpgdata.Text = "Paramètres epgData"
        '
        'LabelNbJourDownload
        '
        Me.LabelNbJourDownload.AutoSize = True
        Me.LabelNbJourDownload.Location = New System.Drawing.Point(6, 61)
        Me.LabelNbJourDownload.Name = "LabelNbJourDownload"
        Me.LabelNbJourDownload.Size = New System.Drawing.Size(152, 13)
        Me.LabelNbJourDownload.TabIndex = 10
        Me.LabelNbJourDownload.Text = "Nombre de jours à télécharger "
        '
        'NumericUpDownDownloadEpgdata
        '
        Me.NumericUpDownDownloadEpgdata.Location = New System.Drawing.Point(164, 59)
        Me.NumericUpDownDownloadEpgdata.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.NumericUpDownDownloadEpgdata.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownDownloadEpgdata.Name = "NumericUpDownDownloadEpgdata"
        Me.NumericUpDownDownloadEpgdata.Size = New System.Drawing.Size(37, 20)
        Me.NumericUpDownDownloadEpgdata.TabIndex = 9
        Me.NumericUpDownDownloadEpgdata.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'LabelEpgdataExpiration
        '
        Me.LabelEpgdataExpiration.AutoSize = True
        Me.LabelEpgdataExpiration.Location = New System.Drawing.Point(5, 88)
        Me.LabelEpgdataExpiration.Name = "LabelEpgdataExpiration"
        Me.LabelEpgdataExpiration.Size = New System.Drawing.Size(92, 13)
        Me.LabelEpgdataExpiration.TabIndex = 5
        Me.LabelEpgdataExpiration.Text = "Date d'expiration :"
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInfo.Location = New System.Drawing.Point(6, 147)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(140, 12)
        Me.LabelInfo.TabIndex = 8
        Me.LabelInfo.Text = "*De €11 à €17 par an (01/092010)"
        '
        'LabelPinCode
        '
        Me.LabelPinCode.AutoSize = True
        Me.LabelPinCode.Location = New System.Drawing.Point(6, 22)
        Me.LabelPinCode.Name = "LabelPinCode"
        Me.LabelPinCode.Size = New System.Drawing.Size(59, 13)
        Me.LabelPinCode.TabIndex = 3
        Me.LabelPinCode.Text = "Code PIN :"
        '
        'BoutonSAbonner
        '
        Me.BoutonSAbonner.Location = New System.Drawing.Point(37, 111)
        Me.BoutonSAbonner.Name = "BoutonSAbonner"
        Me.BoutonSAbonner.Size = New System.Drawing.Size(131, 23)
        Me.BoutonSAbonner.TabIndex = 4
        Me.BoutonSAbonner.Text = "S'abonner à epgData *"
        Me.BoutonSAbonner.UseVisualStyleBackColor = True
        '
        'tbPin
        '
        Me.tbPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPin.Location = New System.Drawing.Point(65, 22)
        Me.tbPin.Multiline = True
        Me.tbPin.Name = "tbPin"
        Me.tbPin.Size = New System.Drawing.Size(136, 31)
        Me.tbPin.TabIndex = 2
        '
        'GroupBoxChoixSource
        '
        Me.GroupBoxChoixSource.Controls.Add(Me.RadioButtonEPGData)
        Me.GroupBoxChoixSource.Controls.Add(Me.RadioButtonXMLTV)
        Me.GroupBoxChoixSource.Enabled = False
        Me.GroupBoxChoixSource.Location = New System.Drawing.Point(26, 13)
        Me.GroupBoxChoixSource.Name = "GroupBoxChoixSource"
        Me.GroupBoxChoixSource.Size = New System.Drawing.Size(207, 45)
        Me.GroupBoxChoixSource.TabIndex = 7
        Me.GroupBoxChoixSource.TabStop = False
        Me.GroupBoxChoixSource.Text = "Sélection de la source"
        '
        'RadioButtonEPGData
        '
        Me.RadioButtonEPGData.AutoSize = True
        Me.RadioButtonEPGData.Location = New System.Drawing.Point(96, 20)
        Me.RadioButtonEPGData.Name = "RadioButtonEPGData"
        Me.RadioButtonEPGData.Size = New System.Drawing.Size(93, 17)
        Me.RadioButtonEPGData.TabIndex = 1
        Me.RadioButtonEPGData.TabStop = True
        Me.RadioButtonEPGData.Text = "EPGData.com"
        Me.RadioButtonEPGData.UseVisualStyleBackColor = True
        '
        'RadioButtonXMLTV
        '
        Me.RadioButtonXMLTV.AutoSize = True
        Me.RadioButtonXMLTV.Checked = True
        Me.RadioButtonXMLTV.Location = New System.Drawing.Point(7, 20)
        Me.RadioButtonXMLTV.Name = "RadioButtonXMLTV"
        Me.RadioButtonXMLTV.Size = New System.Drawing.Size(61, 17)
        Me.RadioButtonXMLTV.TabIndex = 0
        Me.RadioButtonXMLTV.TabStop = True
        Me.RadioButtonXMLTV.Text = "XMLTV"
        Me.RadioButtonXMLTV.UseVisualStyleBackColor = True
        '
        'GroupBoxTailleBdd
        '
        Me.GroupBoxTailleBdd.Controls.Add(Me.TextBoxTailleBdd)
        Me.GroupBoxTailleBdd.Location = New System.Drawing.Point(27, 243)
        Me.GroupBoxTailleBdd.Name = "GroupBoxTailleBdd"
        Me.GroupBoxTailleBdd.Size = New System.Drawing.Size(206, 35)
        Me.GroupBoxTailleBdd.TabIndex = 6
        Me.GroupBoxTailleBdd.TabStop = False
        Me.GroupBoxTailleBdd.Text = "Taille de la base de données"
        '
        'TextBoxTailleBdd
        '
        Me.TextBoxTailleBdd.BackColor = System.Drawing.Color.White
        Me.TextBoxTailleBdd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxTailleBdd.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxTailleBdd.Location = New System.Drawing.Point(10, 16)
        Me.TextBoxTailleBdd.Name = "TextBoxTailleBdd"
        Me.TextBoxTailleBdd.ReadOnly = True
        Me.TextBoxTailleBdd.Size = New System.Drawing.Size(146, 13)
        Me.TextBoxTailleBdd.TabIndex = 0
        '
        'GroupBoxUpdateNext
        '
        Me.GroupBoxUpdateNext.Controls.Add(Me.TextBoxUpdateNext)
        Me.GroupBoxUpdateNext.Location = New System.Drawing.Point(251, 106)
        Me.GroupBoxUpdateNext.Name = "GroupBoxUpdateNext"
        Me.GroupBoxUpdateNext.Size = New System.Drawing.Size(166, 35)
        Me.GroupBoxUpdateNext.TabIndex = 5
        Me.GroupBoxUpdateNext.TabStop = False
        Me.GroupBoxUpdateNext.Text = "Prochaine mise à jour"
        '
        'TextBoxUpdateNext
        '
        Me.TextBoxUpdateNext.BackColor = System.Drawing.Color.White
        Me.TextBoxUpdateNext.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxUpdateNext.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxUpdateNext.Location = New System.Drawing.Point(10, 16)
        Me.TextBoxUpdateNext.Name = "TextBoxUpdateNext"
        Me.TextBoxUpdateNext.ReadOnly = True
        Me.TextBoxUpdateNext.Size = New System.Drawing.Size(150, 13)
        Me.TextBoxUpdateNext.TabIndex = 0
        '
        'GroupBoxUpdateIn
        '
        Me.GroupBoxUpdateIn.Controls.Add(Me.LabelUpdateIn)
        Me.GroupBoxUpdateIn.Location = New System.Drawing.Point(251, 65)
        Me.GroupBoxUpdateIn.Name = "GroupBoxUpdateIn"
        Me.GroupBoxUpdateIn.Size = New System.Drawing.Size(166, 35)
        Me.GroupBoxUpdateIn.TabIndex = 4
        Me.GroupBoxUpdateIn.TabStop = False
        Me.GroupBoxUpdateIn.Text = "Mise à jour dans"
        '
        'LabelUpdateIn
        '
        Me.LabelUpdateIn.Location = New System.Drawing.Point(5, 16)
        Me.LabelUpdateIn.Name = "LabelUpdateIn"
        Me.LabelUpdateIn.Size = New System.Drawing.Size(155, 13)
        Me.LabelUpdateIn.TabIndex = 0
        '
        'GroupBoxUpdateLast
        '
        Me.GroupBoxUpdateLast.Controls.Add(Me.TextBoxUpdateLast)
        Me.GroupBoxUpdateLast.Location = New System.Drawing.Point(251, 147)
        Me.GroupBoxUpdateLast.Name = "GroupBoxUpdateLast"
        Me.GroupBoxUpdateLast.Size = New System.Drawing.Size(166, 35)
        Me.GroupBoxUpdateLast.TabIndex = 3
        Me.GroupBoxUpdateLast.TabStop = False
        Me.GroupBoxUpdateLast.Text = "Dernière mise à jour"
        '
        'TextBoxUpdateLast
        '
        Me.TextBoxUpdateLast.BackColor = System.Drawing.Color.White
        Me.TextBoxUpdateLast.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxUpdateLast.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxUpdateLast.ForeColor = System.Drawing.Color.Black
        Me.TextBoxUpdateLast.Location = New System.Drawing.Point(10, 16)
        Me.TextBoxUpdateLast.Name = "TextBoxUpdateLast"
        Me.TextBoxUpdateLast.ReadOnly = True
        Me.TextBoxUpdateLast.Size = New System.Drawing.Size(150, 13)
        Me.TextBoxUpdateLast.TabIndex = 0
        '
        'GroupBoxIntervalle
        '
        Me.GroupBoxIntervalle.Controls.Add(Me.RadioButtonDay5)
        Me.GroupBoxIntervalle.Controls.Add(Me.RadioButtonDay4)
        Me.GroupBoxIntervalle.Controls.Add(Me.RadioButtonDay3)
        Me.GroupBoxIntervalle.Controls.Add(Me.RadioButtonDay2)
        Me.GroupBoxIntervalle.Controls.Add(Me.RadioButtonDay1)
        Me.GroupBoxIntervalle.Location = New System.Drawing.Point(251, 188)
        Me.GroupBoxIntervalle.Name = "GroupBoxIntervalle"
        Me.GroupBoxIntervalle.Size = New System.Drawing.Size(166, 90)
        Me.GroupBoxIntervalle.TabIndex = 2
        Me.GroupBoxIntervalle.TabStop = False
        Me.GroupBoxIntervalle.Text = "Intervalle des mises à jour"
        '
        'RadioButtonDay5
        '
        Me.RadioButtonDay5.AutoSize = True
        Me.RadioButtonDay5.Location = New System.Drawing.Point(6, 68)
        Me.RadioButtonDay5.Name = "RadioButtonDay5"
        Me.RadioButtonDay5.Size = New System.Drawing.Size(56, 17)
        Me.RadioButtonDay5.TabIndex = 4
        Me.RadioButtonDay5.TabStop = True
        Me.RadioButtonDay5.Text = "5 jours"
        Me.RadioButtonDay5.UseVisualStyleBackColor = True
        '
        'RadioButtonDay4
        '
        Me.RadioButtonDay4.AutoSize = True
        Me.RadioButtonDay4.Location = New System.Drawing.Point(71, 44)
        Me.RadioButtonDay4.Name = "RadioButtonDay4"
        Me.RadioButtonDay4.Size = New System.Drawing.Size(56, 17)
        Me.RadioButtonDay4.TabIndex = 3
        Me.RadioButtonDay4.TabStop = True
        Me.RadioButtonDay4.Text = "4 jours"
        Me.RadioButtonDay4.UseVisualStyleBackColor = True
        '
        'RadioButtonDay3
        '
        Me.RadioButtonDay3.AutoSize = True
        Me.RadioButtonDay3.Checked = True
        Me.RadioButtonDay3.Location = New System.Drawing.Point(7, 44)
        Me.RadioButtonDay3.Name = "RadioButtonDay3"
        Me.RadioButtonDay3.Size = New System.Drawing.Size(56, 17)
        Me.RadioButtonDay3.TabIndex = 2
        Me.RadioButtonDay3.TabStop = True
        Me.RadioButtonDay3.Text = "3 jours"
        Me.RadioButtonDay3.UseVisualStyleBackColor = True
        '
        'RadioButtonDay2
        '
        Me.RadioButtonDay2.AutoSize = True
        Me.RadioButtonDay2.Location = New System.Drawing.Point(71, 21)
        Me.RadioButtonDay2.Name = "RadioButtonDay2"
        Me.RadioButtonDay2.Size = New System.Drawing.Size(56, 17)
        Me.RadioButtonDay2.TabIndex = 1
        Me.RadioButtonDay2.Text = "2 jours"
        Me.RadioButtonDay2.UseVisualStyleBackColor = True
        '
        'RadioButtonDay1
        '
        Me.RadioButtonDay1.AutoSize = True
        Me.RadioButtonDay1.Location = New System.Drawing.Point(7, 21)
        Me.RadioButtonDay1.Name = "RadioButtonDay1"
        Me.RadioButtonDay1.Size = New System.Drawing.Size(51, 17)
        Me.RadioButtonDay1.TabIndex = 0
        Me.RadioButtonDay1.Text = "1 jour"
        Me.RadioButtonDay1.UseVisualStyleBackColor = True
        '
        'GroupBoxAutoUpdate
        '
        Me.GroupBoxAutoUpdate.Controls.Add(Me.CheckBoxAutoUpdate)
        Me.GroupBoxAutoUpdate.Location = New System.Drawing.Point(251, 13)
        Me.GroupBoxAutoUpdate.Name = "GroupBoxAutoUpdate"
        Me.GroupBoxAutoUpdate.Size = New System.Drawing.Size(166, 46)
        Me.GroupBoxAutoUpdate.TabIndex = 0
        Me.GroupBoxAutoUpdate.TabStop = False
        Me.GroupBoxAutoUpdate.Text = "Mises à jour"
        '
        'CheckBoxAutoUpdate
        '
        Me.CheckBoxAutoUpdate.AutoSize = True
        Me.CheckBoxAutoUpdate.Checked = True
        Me.CheckBoxAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAutoUpdate.Location = New System.Drawing.Point(13, 19)
        Me.CheckBoxAutoUpdate.Name = "CheckBoxAutoUpdate"
        Me.CheckBoxAutoUpdate.Size = New System.Drawing.Size(143, 17)
        Me.CheckBoxAutoUpdate.TabIndex = 0
        Me.CheckBoxAutoUpdate.Text = "Mises à jour automatique"
        Me.CheckBoxAutoUpdate.UseVisualStyleBackColor = True
        '
        'TabPageProxy
        '
        Me.TabPageProxy.BackColor = System.Drawing.Color.White
        Me.TabPageProxy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPageProxy.Controls.Add(Me.GroupBoxProxy)
        Me.TabPageProxy.Controls.Add(Me.GroupBoxConnexion)
        Me.TabPageProxy.Location = New System.Drawing.Point(4, 22)
        Me.TabPageProxy.Name = "TabPageProxy"
        Me.TabPageProxy.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageProxy.Size = New System.Drawing.Size(443, 290)
        Me.TabPageProxy.TabIndex = 1
        Me.TabPageProxy.Text = "Proxy"
        '
        'GroupBoxProxy
        '
        Me.GroupBoxProxy.Controls.Add(Me.ProxyPort)
        Me.GroupBoxProxy.Controls.Add(Me.LabelProxy)
        Me.GroupBoxProxy.Controls.Add(Me.LabelPort)
        Me.GroupBoxProxy.Controls.Add(Me.ProxyHost)
        Me.GroupBoxProxy.Location = New System.Drawing.Point(262, 92)
        Me.GroupBoxProxy.Name = "GroupBoxProxy"
        Me.GroupBoxProxy.Size = New System.Drawing.Size(158, 106)
        Me.GroupBoxProxy.TabIndex = 10
        Me.GroupBoxProxy.TabStop = False
        Me.GroupBoxProxy.Text = "Proxy/Port"
        '
        'ProxyPort
        '
        Me.ProxyPort.BackColor = System.Drawing.Color.White
        Me.ProxyPort.Location = New System.Drawing.Point(10, 75)
        Me.ProxyPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.ProxyPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ProxyPort.Name = "ProxyPort"
        Me.ProxyPort.Size = New System.Drawing.Size(100, 20)
        Me.ProxyPort.TabIndex = 15
        Me.ProxyPort.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LabelProxy
        '
        Me.LabelProxy.AutoSize = True
        Me.LabelProxy.Location = New System.Drawing.Point(10, 20)
        Me.LabelProxy.Name = "LabelProxy"
        Me.LabelProxy.Size = New System.Drawing.Size(39, 13)
        Me.LabelProxy.TabIndex = 13
        Me.LabelProxy.Text = "Proxy :"
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = True
        Me.LabelPort.Location = New System.Drawing.Point(10, 59)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(32, 13)
        Me.LabelPort.TabIndex = 14
        Me.LabelPort.Text = "Port :"
        '
        'ProxyHost
        '
        Me.ProxyHost.BackColor = System.Drawing.Color.White
        Me.ProxyHost.Location = New System.Drawing.Point(10, 36)
        Me.ProxyHost.Name = "ProxyHost"
        Me.ProxyHost.Size = New System.Drawing.Size(139, 20)
        Me.ProxyHost.TabIndex = 10
        '
        'GroupBoxConnexion
        '
        Me.GroupBoxConnexion.Controls.Add(Me.LabelUtilisateur)
        Me.GroupBoxConnexion.Controls.Add(Me.LabelMotdePasse)
        Me.GroupBoxConnexion.Controls.Add(Me.Login)
        Me.GroupBoxConnexion.Controls.Add(Me.Pass)
        Me.GroupBoxConnexion.Location = New System.Drawing.Point(22, 92)
        Me.GroupBoxConnexion.Name = "GroupBoxConnexion"
        Me.GroupBoxConnexion.Size = New System.Drawing.Size(218, 106)
        Me.GroupBoxConnexion.TabIndex = 0
        Me.GroupBoxConnexion.TabStop = False
        Me.GroupBoxConnexion.Text = "Connexion"
        '
        'LabelUtilisateur
        '
        Me.LabelUtilisateur.AutoSize = True
        Me.LabelUtilisateur.Location = New System.Drawing.Point(10, 20)
        Me.LabelUtilisateur.Name = "LabelUtilisateur"
        Me.LabelUtilisateur.Size = New System.Drawing.Size(56, 13)
        Me.LabelUtilisateur.TabIndex = 13
        Me.LabelUtilisateur.Text = "Uilisateur :"
        '
        'LabelMotdePasse
        '
        Me.LabelMotdePasse.AutoSize = True
        Me.LabelMotdePasse.Location = New System.Drawing.Point(10, 59)
        Me.LabelMotdePasse.Name = "LabelMotdePasse"
        Me.LabelMotdePasse.Size = New System.Drawing.Size(77, 13)
        Me.LabelMotdePasse.TabIndex = 14
        Me.LabelMotdePasse.Text = "Mot de passe :"
        '
        'Login
        '
        Me.Login.BackColor = System.Drawing.Color.White
        Me.Login.Location = New System.Drawing.Point(10, 36)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(202, 20)
        Me.Login.TabIndex = 8
        '
        'Pass
        '
        Me.Pass.BackColor = System.Drawing.Color.White
        Me.Pass.Location = New System.Drawing.Point(10, 75)
        Me.Pass.Name = "Pass"
        Me.Pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Pass.Size = New System.Drawing.Size(202, 20)
        Me.Pass.TabIndex = 9
        '
        'TabPageGeneral
        '
        Me.TabPageGeneral.BackColor = System.Drawing.Color.White
        Me.TabPageGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxToolTipsBallon)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxUrlUpdate)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxMouse)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxConfHardware)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxPosition)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxFiltres)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxDivers)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxSauvegardeFenetre)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxPurge)
        Me.TabPageGeneral.Controls.Add(Me.GroupBoxEffects)
        Me.TabPageGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TabPageGeneral.Name = "TabPageGeneral"
        Me.TabPageGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageGeneral.Size = New System.Drawing.Size(443, 290)
        Me.TabPageGeneral.TabIndex = 0
        Me.TabPageGeneral.Text = "Générales"
        '
        'GroupBoxToolTipsBallon
        '
        Me.GroupBoxToolTipsBallon.Controls.Add(Me.CheckBoxToolTipsBallon)
        Me.GroupBoxToolTipsBallon.Location = New System.Drawing.Point(232, 207)
        Me.GroupBoxToolTipsBallon.Name = "GroupBoxToolTipsBallon"
        Me.GroupBoxToolTipsBallon.Size = New System.Drawing.Size(196, 38)
        Me.GroupBoxToolTipsBallon.TabIndex = 23
        Me.GroupBoxToolTipsBallon.TabStop = False
        Me.GroupBoxToolTipsBallon.Text = "InfoBulles"
        '
        'CheckBoxToolTipsBallon
        '
        Me.CheckBoxToolTipsBallon.AutoSize = True
        Me.CheckBoxToolTipsBallon.Checked = True
        Me.CheckBoxToolTipsBallon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxToolTipsBallon.Location = New System.Drawing.Point(7, 16)
        Me.CheckBoxToolTipsBallon.Name = "CheckBoxToolTipsBallon"
        Me.CheckBoxToolTipsBallon.Size = New System.Drawing.Size(126, 17)
        Me.CheckBoxToolTipsBallon.TabIndex = 0
        Me.CheckBoxToolTipsBallon.Text = "Afficher les Infobulles"
        Me.CheckBoxToolTipsBallon.UseVisualStyleBackColor = True
        '
        'GroupBoxUrlUpdate
        '
        Me.GroupBoxUrlUpdate.Controls.Add(Me.CheckBoxUrlUpdate)
        Me.GroupBoxUrlUpdate.Location = New System.Drawing.Point(15, 243)
        Me.GroupBoxUrlUpdate.Name = "GroupBoxUrlUpdate"
        Me.GroupBoxUrlUpdate.Size = New System.Drawing.Size(196, 38)
        Me.GroupBoxUrlUpdate.TabIndex = 22
        Me.GroupBoxUrlUpdate.TabStop = False
        Me.GroupBoxUrlUpdate.Text = "URL"
        '
        'CheckBoxUrlUpdate
        '
        Me.CheckBoxUrlUpdate.AutoSize = True
        Me.CheckBoxUrlUpdate.Location = New System.Drawing.Point(7, 16)
        Me.CheckBoxUrlUpdate.Name = "CheckBoxUrlUpdate"
        Me.CheckBoxUrlUpdate.Size = New System.Drawing.Size(126, 17)
        Me.CheckBoxUrlUpdate.TabIndex = 0
        Me.CheckBoxUrlUpdate.Text = "Mise à jour auto URL"
        Me.CheckBoxUrlUpdate.UseVisualStyleBackColor = True
        '
        'GroupBoxMouse
        '
        Me.GroupBoxMouse.Controls.Add(Me.CheckBoxaccordscrollhorizontal)
        Me.GroupBoxMouse.Location = New System.Drawing.Point(232, 167)
        Me.GroupBoxMouse.Name = "GroupBoxMouse"
        Me.GroupBoxMouse.Size = New System.Drawing.Size(196, 38)
        Me.GroupBoxMouse.TabIndex = 21
        Me.GroupBoxMouse.TabStop = False
        Me.GroupBoxMouse.Text = "Souris"
        '
        'CheckBoxaccordscrollhorizontal
        '
        Me.CheckBoxaccordscrollhorizontal.AutoSize = True
        Me.CheckBoxaccordscrollhorizontal.Location = New System.Drawing.Point(7, 16)
        Me.CheckBoxaccordscrollhorizontal.Name = "CheckBoxaccordscrollhorizontal"
        Me.CheckBoxaccordscrollhorizontal.Size = New System.Drawing.Size(124, 17)
        Me.CheckBoxaccordscrollhorizontal.TabIndex = 0
        Me.CheckBoxaccordscrollhorizontal.Text = "Défilement horizontal"
        Me.CheckBoxaccordscrollhorizontal.UseVisualStyleBackColor = True
        '
        'GroupBoxConfHardware
        '
        Me.GroupBoxConfHardware.Controls.Add(Me.RadioButtonConfMinimum)
        Me.GroupBoxConfHardware.Controls.Add(Me.RadioButtonConfAverage)
        Me.GroupBoxConfHardware.Controls.Add(Me.RadioButtonConfNormal)
        Me.GroupBoxConfHardware.Location = New System.Drawing.Point(15, 143)
        Me.GroupBoxConfHardware.Name = "GroupBoxConfHardware"
        Me.GroupBoxConfHardware.Size = New System.Drawing.Size(196, 96)
        Me.GroupBoxConfHardware.TabIndex = 20
        Me.GroupBoxConfHardware.TabStop = False
        Me.GroupBoxConfHardware.Text = "Configuration matérielle"
        '
        'RadioButtonConfMinimum
        '
        Me.RadioButtonConfMinimum.AutoSize = True
        Me.RadioButtonConfMinimum.Location = New System.Drawing.Point(7, 67)
        Me.RadioButtonConfMinimum.Name = "RadioButtonConfMinimum"
        Me.RadioButtonConfMinimum.Size = New System.Drawing.Size(66, 17)
        Me.RadioButtonConfMinimum.TabIndex = 2
        Me.RadioButtonConfMinimum.Text = "Minimale"
        Me.RadioButtonConfMinimum.UseVisualStyleBackColor = True
        '
        'RadioButtonConfAverage
        '
        Me.RadioButtonConfAverage.AutoSize = True
        Me.RadioButtonConfAverage.Location = New System.Drawing.Point(7, 44)
        Me.RadioButtonConfAverage.Name = "RadioButtonConfAverage"
        Me.RadioButtonConfAverage.Size = New System.Drawing.Size(69, 17)
        Me.RadioButtonConfAverage.TabIndex = 1
        Me.RadioButtonConfAverage.Text = "Moyenne"
        Me.RadioButtonConfAverage.UseVisualStyleBackColor = True
        '
        'RadioButtonConfNormal
        '
        Me.RadioButtonConfNormal.AutoSize = True
        Me.RadioButtonConfNormal.Checked = True
        Me.RadioButtonConfNormal.Location = New System.Drawing.Point(7, 21)
        Me.RadioButtonConfNormal.Name = "RadioButtonConfNormal"
        Me.RadioButtonConfNormal.Size = New System.Drawing.Size(121, 17)
        Me.RadioButtonConfNormal.TabIndex = 0
        Me.RadioButtonConfNormal.TabStop = True
        Me.RadioButtonConfNormal.Text = "Normale (par défaut)"
        Me.RadioButtonConfNormal.UseVisualStyleBackColor = True
        '
        'GroupBoxPosition
        '
        Me.GroupBoxPosition.Controls.Add(Me.CheckBoxbuttonssave)
        Me.GroupBoxPosition.Location = New System.Drawing.Point(232, 126)
        Me.GroupBoxPosition.Name = "GroupBoxPosition"
        Me.GroupBoxPosition.Size = New System.Drawing.Size(196, 38)
        Me.GroupBoxPosition.TabIndex = 18
        Me.GroupBoxPosition.TabStop = False
        Me.GroupBoxPosition.Text = "Position des fenêtres"
        '
        'CheckBoxbuttonssave
        '
        Me.CheckBoxbuttonssave.AutoSize = True
        Me.CheckBoxbuttonssave.Checked = True
        Me.CheckBoxbuttonssave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxbuttonssave.Location = New System.Drawing.Point(7, 16)
        Me.CheckBoxbuttonssave.Name = "CheckBoxbuttonssave"
        Me.CheckBoxbuttonssave.Size = New System.Drawing.Size(129, 17)
        Me.CheckBoxbuttonssave.TabIndex = 0
        Me.CheckBoxbuttonssave.Text = "Activer la sauvegarde"
        Me.CheckBoxbuttonssave.UseVisualStyleBackColor = True
        '
        'GroupBoxFiltres
        '
        Me.GroupBoxFiltres.Controls.Add(Me.CheckBoxFilters)
        Me.GroupBoxFiltres.Location = New System.Drawing.Point(232, 86)
        Me.GroupBoxFiltres.Name = "GroupBoxFiltres"
        Me.GroupBoxFiltres.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBoxFiltres.Size = New System.Drawing.Size(196, 38)
        Me.GroupBoxFiltres.TabIndex = 17
        Me.GroupBoxFiltres.TabStop = False
        Me.GroupBoxFiltres.Text = "Les filtres"
        '
        'CheckBoxFilters
        '
        Me.CheckBoxFilters.AutoSize = True
        Me.CheckBoxFilters.Checked = True
        Me.CheckBoxFilters.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxFilters.Location = New System.Drawing.Point(7, 16)
        Me.CheckBoxFilters.Name = "CheckBoxFilters"
        Me.CheckBoxFilters.Size = New System.Drawing.Size(144, 17)
        Me.CheckBoxFilters.TabIndex = 0
        Me.CheckBoxFilters.Text = "Cacher automatiquement"
        Me.CheckBoxFilters.UseVisualStyleBackColor = True
        '
        'GroupBoxDivers
        '
        Me.GroupBoxDivers.Controls.Add(Me.CheckBoxtracelog)
        Me.GroupBoxDivers.Location = New System.Drawing.Point(232, 46)
        Me.GroupBoxDivers.Name = "GroupBoxDivers"
        Me.GroupBoxDivers.Size = New System.Drawing.Size(196, 38)
        Me.GroupBoxDivers.TabIndex = 11
        Me.GroupBoxDivers.TabStop = False
        Me.GroupBoxDivers.Text = "Divers"
        '
        'CheckBoxtracelog
        '
        Me.CheckBoxtracelog.AutoSize = True
        Me.CheckBoxtracelog.Location = New System.Drawing.Point(7, 16)
        Me.CheckBoxtracelog.Name = "CheckBoxtracelog"
        Me.CheckBoxtracelog.Size = New System.Drawing.Size(164, 17)
        Me.CheckBoxtracelog.TabIndex = 0
        Me.CheckBoxtracelog.Text = "Activer l'écriture du fichier log"
        Me.CheckBoxtracelog.UseVisualStyleBackColor = True
        '
        'GroupBoxSauvegardeFenetre
        '
        Me.GroupBoxSauvegardeFenetre.Controls.Add(Me.CheckBoxConfigWindow)
        Me.GroupBoxSauvegardeFenetre.Location = New System.Drawing.Point(232, 6)
        Me.GroupBoxSauvegardeFenetre.Name = "GroupBoxSauvegardeFenetre"
        Me.GroupBoxSauvegardeFenetre.Size = New System.Drawing.Size(196, 38)
        Me.GroupBoxSauvegardeFenetre.TabIndex = 9
        Me.GroupBoxSauvegardeFenetre.TabStop = False
        Me.GroupBoxSauvegardeFenetre.Text = "Sauvegarde fenêtre principale"
        '
        'CheckBoxConfigWindow
        '
        Me.CheckBoxConfigWindow.AutoSize = True
        Me.CheckBoxConfigWindow.Location = New System.Drawing.Point(7, 16)
        Me.CheckBoxConfigWindow.Name = "CheckBoxConfigWindow"
        Me.CheckBoxConfigWindow.Size = New System.Drawing.Size(122, 17)
        Me.CheckBoxConfigWindow.TabIndex = 0
        Me.CheckBoxConfigWindow.Text = "Dimensions/Position"
        Me.CheckBoxConfigWindow.UseVisualStyleBackColor = True
        '
        'GroupBoxPurge
        '
        Me.GroupBoxPurge.Controls.Add(Me.CheckBoxPurge)
        Me.GroupBoxPurge.Location = New System.Drawing.Point(15, 6)
        Me.GroupBoxPurge.Name = "GroupBoxPurge"
        Me.GroupBoxPurge.Size = New System.Drawing.Size(196, 46)
        Me.GroupBoxPurge.TabIndex = 8
        Me.GroupBoxPurge.TabStop = False
        Me.GroupBoxPurge.Text = "Purge des fichiers obsolètes"
        '
        'CheckBoxPurge
        '
        Me.CheckBoxPurge.AutoSize = True
        Me.CheckBoxPurge.Checked = True
        Me.CheckBoxPurge.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxPurge.Location = New System.Drawing.Point(7, 19)
        Me.CheckBoxPurge.Name = "CheckBoxPurge"
        Me.CheckBoxPurge.Size = New System.Drawing.Size(115, 17)
        Me.CheckBoxPurge.TabIndex = 0
        Me.CheckBoxPurge.Text = "Purge automatique"
        Me.CheckBoxPurge.UseVisualStyleBackColor = True
        '
        'GroupBoxEffects
        '
        Me.GroupBoxEffects.Controls.Add(Me.CheckBoxoldUI)
        Me.GroupBoxEffects.Controls.Add(Me.CheckBoxSlide)
        Me.GroupBoxEffects.Controls.Add(Me.CheckBoxFadeOut)
        Me.GroupBoxEffects.Location = New System.Drawing.Point(15, 54)
        Me.GroupBoxEffects.Name = "GroupBoxEffects"
        Me.GroupBoxEffects.Size = New System.Drawing.Size(196, 86)
        Me.GroupBoxEffects.TabIndex = 0
        Me.GroupBoxEffects.TabStop = False
        Me.GroupBoxEffects.Text = "Effets"
        '
        'CheckBoxoldUI
        '
        Me.CheckBoxoldUI.AutoSize = True
        Me.CheckBoxoldUI.Checked = True
        Me.CheckBoxoldUI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxoldUI.Location = New System.Drawing.Point(7, 17)
        Me.CheckBoxoldUI.Name = "CheckBoxoldUI"
        Me.CheckBoxoldUI.Size = New System.Drawing.Size(85, 17)
        Me.CheckBoxoldUI.TabIndex = 3
        Me.CheckBoxoldUI.Text = "Interface 2D"
        Me.CheckBoxoldUI.UseVisualStyleBackColor = True
        '
        'CheckBoxSlide
        '
        Me.CheckBoxSlide.AutoSize = True
        Me.CheckBoxSlide.Checked = True
        Me.CheckBoxSlide.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSlide.Location = New System.Drawing.Point(7, 64)
        Me.CheckBoxSlide.Name = "CheckBoxSlide"
        Me.CheckBoxSlide.Size = New System.Drawing.Size(162, 17)
        Me.CheckBoxSlide.TabIndex = 2
        Me.CheckBoxSlide.Text = "Effet au passage de la souris"
        Me.CheckBoxSlide.UseVisualStyleBackColor = True
        '
        'CheckBoxFadeOut
        '
        Me.CheckBoxFadeOut.AutoSize = True
        Me.CheckBoxFadeOut.Location = New System.Drawing.Point(7, 40)
        Me.CheckBoxFadeOut.Name = "CheckBoxFadeOut"
        Me.CheckBoxFadeOut.Size = New System.Drawing.Size(67, 17)
        Me.CheckBoxFadeOut.TabIndex = 1
        Me.CheckBoxFadeOut.Text = "FadeOut"
        Me.CheckBoxFadeOut.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPageGeneral)
        Me.TabControl.Controls.Add(Me.TabPageProxy)
        Me.TabControl.Controls.Add(Me.TabPageMiseajourDonnees)
        Me.TabControl.Controls.Add(Me.TabPageMiseajourLogiciel)
        Me.TabControl.Controls.Add(Me.TabPageCesoirMaintenant)
        Me.TabControl.Controls.Add(Me.TabPageResume)
        Me.TabControl.Controls.Add(Me.TabPageSound)
        Me.TabControl.Location = New System.Drawing.Point(1, 12)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(451, 316)
        Me.TabControl.TabIndex = 14
        '
        'TabPageResume
        '
        Me.TabPageResume.Controls.Add(Me.GroupBoxResume)
        Me.TabPageResume.Controls.Add(Me.GroupBoxResumeBefore)
        Me.TabPageResume.Location = New System.Drawing.Point(4, 22)
        Me.TabPageResume.Name = "TabPageResume"
        Me.TabPageResume.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageResume.Size = New System.Drawing.Size(443, 290)
        Me.TabPageResume.TabIndex = 6
        Me.TabPageResume.Text = "Mode Veille"
        Me.TabPageResume.UseVisualStyleBackColor = True
        '
        'GroupBoxResume
        '
        Me.GroupBoxResume.Controls.Add(Me.CheckBoxResume)
        Me.GroupBoxResume.Location = New System.Drawing.Point(26, 13)
        Me.GroupBoxResume.Name = "GroupBoxResume"
        Me.GroupBoxResume.Size = New System.Drawing.Size(180, 46)
        Me.GroupBoxResume.TabIndex = 4
        Me.GroupBoxResume.TabStop = False
        Me.GroupBoxResume.Text = "Sortie du mode veille"
        '
        'CheckBoxResume
        '
        Me.CheckBoxResume.AutoSize = True
        Me.CheckBoxResume.Location = New System.Drawing.Point(7, 20)
        Me.CheckBoxResume.Name = "CheckBoxResume"
        Me.CheckBoxResume.Size = New System.Drawing.Size(114, 17)
        Me.CheckBoxResume.TabIndex = 0
        Me.CheckBoxResume.Text = "Sortie automatique"
        Me.CheckBoxResume.UseVisualStyleBackColor = True
        '
        'GroupBoxResumeBefore
        '
        Me.GroupBoxResumeBefore.Controls.Add(Me.RadioButtonResume15)
        Me.GroupBoxResumeBefore.Controls.Add(Me.RadioButtonResume30)
        Me.GroupBoxResumeBefore.Controls.Add(Me.RadioButtonResume10)
        Me.GroupBoxResumeBefore.Controls.Add(Me.RadioButtonResume20)
        Me.GroupBoxResumeBefore.Controls.Add(Me.RadioButtonResume5)
        Me.GroupBoxResumeBefore.Location = New System.Drawing.Point(26, 65)
        Me.GroupBoxResumeBefore.Name = "GroupBoxResumeBefore"
        Me.GroupBoxResumeBefore.Size = New System.Drawing.Size(180, 139)
        Me.GroupBoxResumeBefore.TabIndex = 3
        Me.GroupBoxResumeBefore.TabStop = False
        Me.GroupBoxResumeBefore.Text = "Sortie du mode veille avant"
        '
        'RadioButtonResume15
        '
        Me.RadioButtonResume15.AutoSize = True
        Me.RadioButtonResume15.Location = New System.Drawing.Point(7, 68)
        Me.RadioButtonResume15.Name = "RadioButtonResume15"
        Me.RadioButtonResume15.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonResume15.TabIndex = 4
        Me.RadioButtonResume15.TabStop = True
        Me.RadioButtonResume15.Text = "15 minutes"
        Me.RadioButtonResume15.UseVisualStyleBackColor = True
        '
        'RadioButtonResume30
        '
        Me.RadioButtonResume30.AutoSize = True
        Me.RadioButtonResume30.Location = New System.Drawing.Point(7, 114)
        Me.RadioButtonResume30.Name = "RadioButtonResume30"
        Me.RadioButtonResume30.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonResume30.TabIndex = 3
        Me.RadioButtonResume30.TabStop = True
        Me.RadioButtonResume30.Text = "30 minutes"
        Me.RadioButtonResume30.UseVisualStyleBackColor = True
        '
        'RadioButtonResume10
        '
        Me.RadioButtonResume10.AutoSize = True
        Me.RadioButtonResume10.Checked = True
        Me.RadioButtonResume10.Location = New System.Drawing.Point(7, 44)
        Me.RadioButtonResume10.Name = "RadioButtonResume10"
        Me.RadioButtonResume10.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonResume10.TabIndex = 2
        Me.RadioButtonResume10.TabStop = True
        Me.RadioButtonResume10.Text = "10 minutes"
        Me.RadioButtonResume10.UseVisualStyleBackColor = True
        '
        'RadioButtonResume20
        '
        Me.RadioButtonResume20.AutoSize = True
        Me.RadioButtonResume20.Location = New System.Drawing.Point(7, 91)
        Me.RadioButtonResume20.Name = "RadioButtonResume20"
        Me.RadioButtonResume20.Size = New System.Drawing.Size(76, 17)
        Me.RadioButtonResume20.TabIndex = 1
        Me.RadioButtonResume20.Text = "20 minutes"
        Me.RadioButtonResume20.UseVisualStyleBackColor = True
        '
        'RadioButtonResume5
        '
        Me.RadioButtonResume5.AutoSize = True
        Me.RadioButtonResume5.Location = New System.Drawing.Point(7, 21)
        Me.RadioButtonResume5.Name = "RadioButtonResume5"
        Me.RadioButtonResume5.Size = New System.Drawing.Size(70, 17)
        Me.RadioButtonResume5.TabIndex = 0
        Me.RadioButtonResume5.Text = "5 minutes"
        Me.RadioButtonResume5.UseVisualStyleBackColor = True
        '
        'TabPageSound
        '
        Me.TabPageSound.Controls.Add(Me.GroupBoxMute)
        Me.TabPageSound.Controls.Add(Me.GroupBoxMasterVolume)
        Me.TabPageSound.Controls.Add(Me.GroupBoxReminder)
        Me.TabPageSound.Controls.Add(Me.GroupBoxMessages)
        Me.TabPageSound.Controls.Add(Me.GroupBoxRSS)
        Me.TabPageSound.Location = New System.Drawing.Point(4, 22)
        Me.TabPageSound.Name = "TabPageSound"
        Me.TabPageSound.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageSound.Size = New System.Drawing.Size(443, 290)
        Me.TabPageSound.TabIndex = 7
        Me.TabPageSound.Text = "Gestion du son"
        Me.TabPageSound.UseVisualStyleBackColor = True
        '
        'GroupBoxMute
        '
        Me.GroupBoxMute.Controls.Add(Me.CheckBoxAudioOn)
        Me.GroupBoxMute.Location = New System.Drawing.Point(285, 213)
        Me.GroupBoxMute.Name = "GroupBoxMute"
        Me.GroupBoxMute.Size = New System.Drawing.Size(141, 46)
        Me.GroupBoxMute.TabIndex = 21
        Me.GroupBoxMute.TabStop = False
        Me.GroupBoxMute.Text = "Désactivation du son"
        '
        'CheckBoxAudioOn
        '
        Me.CheckBoxAudioOn.AutoSize = True
        Me.CheckBoxAudioOn.Location = New System.Drawing.Point(7, 20)
        Me.CheckBoxAudioOn.Name = "CheckBoxAudioOn"
        Me.CheckBoxAudioOn.Size = New System.Drawing.Size(50, 17)
        Me.CheckBoxAudioOn.TabIndex = 12
        Me.CheckBoxAudioOn.Text = "Muet"
        Me.CheckBoxAudioOn.UseVisualStyleBackColor = True
        '
        'GroupBoxMasterVolume
        '
        Me.GroupBoxMasterVolume.Controls.Add(Me.TrackBarMasterVolume)
        Me.GroupBoxMasterVolume.Controls.Add(Me.PictureBox10)
        Me.GroupBoxMasterVolume.Controls.Add(Me.PictureBox9)
        Me.GroupBoxMasterVolume.Location = New System.Drawing.Point(17, 213)
        Me.GroupBoxMasterVolume.Name = "GroupBoxMasterVolume"
        Me.GroupBoxMasterVolume.Size = New System.Drawing.Size(256, 70)
        Me.GroupBoxMasterVolume.TabIndex = 20
        Me.GroupBoxMasterVolume.TabStop = False
        Me.GroupBoxMasterVolume.Text = "Volume général"
        '
        'TrackBarMasterVolume
        '
        Me.TrackBarMasterVolume.AutoSize = False
        Me.TrackBarMasterVolume.BackColor = System.Drawing.Color.White
        Me.TrackBarMasterVolume.Location = New System.Drawing.Point(6, 35)
        Me.TrackBarMasterVolume.Name = "TrackBarMasterVolume"
        Me.TrackBarMasterVolume.Size = New System.Drawing.Size(244, 33)
        Me.TrackBarMasterVolume.TabIndex = 17
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = Global.ZGuideTV.My.Resources.Resources.audioplus
        Me.PictureBox10.Location = New System.Drawing.Point(224, 16)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox10.TabIndex = 19
        Me.PictureBox10.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = Global.ZGuideTV.My.Resources.Resources.audiominus
        Me.PictureBox9.Location = New System.Drawing.Point(14, 16)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox9.TabIndex = 18
        Me.PictureBox9.TabStop = False
        '
        'GroupBoxReminder
        '
        Me.GroupBoxReminder.Controls.Add(Me.ComboBoxReminder)
        Me.GroupBoxReminder.Controls.Add(Me.ButtonReminderSound)
        Me.GroupBoxReminder.Controls.Add(Me.TrackBarReminder)
        Me.GroupBoxReminder.Controls.Add(Me.PictureBox7)
        Me.GroupBoxReminder.Controls.Add(Me.PictureBox5)
        Me.GroupBoxReminder.Location = New System.Drawing.Point(17, 142)
        Me.GroupBoxReminder.Name = "GroupBoxReminder"
        Me.GroupBoxReminder.Size = New System.Drawing.Size(409, 70)
        Me.GroupBoxReminder.TabIndex = 2
        Me.GroupBoxReminder.TabStop = False
        Me.GroupBoxReminder.Text = "Rappel des émissions"
        '
        'ComboBoxReminder
        '
        Me.ComboBoxReminder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxReminder.FormattingEnabled = True
        Me.ComboBoxReminder.Location = New System.Drawing.Point(11, 28)
        Me.ComboBoxReminder.Name = "ComboBoxReminder"
        Me.ComboBoxReminder.Size = New System.Drawing.Size(209, 21)
        Me.ComboBoxReminder.TabIndex = 0
        '
        'ButtonReminderSound
        '
        Me.ButtonReminderSound.FlatAppearance.BorderSize = 0
        Me.ButtonReminderSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonReminderSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonReminderSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReminderSound.Image = Global.ZGuideTV.My.Resources.Resources.controlplay
        Me.ButtonReminderSound.Location = New System.Drawing.Point(248, 29)
        Me.ButtonReminderSound.Name = "ButtonReminderSound"
        Me.ButtonReminderSound.Size = New System.Drawing.Size(16, 16)
        Me.ButtonReminderSound.TabIndex = 16
        Me.ButtonReminderSound.UseVisualStyleBackColor = True
        '
        'TrackBarReminder
        '
        Me.TrackBarReminder.AutoSize = False
        Me.TrackBarReminder.BackColor = System.Drawing.Color.White
        Me.TrackBarReminder.LargeChange = 1
        Me.TrackBarReminder.Location = New System.Drawing.Point(285, 29)
        Me.TrackBarReminder.Name = "TrackBarReminder"
        Me.TrackBarReminder.Size = New System.Drawing.Size(112, 33)
        Me.TrackBarReminder.TabIndex = 5
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.ZGuideTV.My.Resources.Resources.audiominus
        Me.PictureBox7.Location = New System.Drawing.Point(293, 10)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox7.TabIndex = 10
        Me.PictureBox7.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.ZGuideTV.My.Resources.Resources.audioplus
        Me.PictureBox5.Location = New System.Drawing.Point(373, 10)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.TabIndex = 11
        Me.PictureBox5.TabStop = False
        '
        'GroupBoxMessages
        '
        Me.GroupBoxMessages.Controls.Add(Me.ComboBoxMessages)
        Me.GroupBoxMessages.Controls.Add(Me.ButtonMessagesSound)
        Me.GroupBoxMessages.Controls.Add(Me.TrackBarMessages)
        Me.GroupBoxMessages.Controls.Add(Me.PictureBox4)
        Me.GroupBoxMessages.Controls.Add(Me.PictureBox3)
        Me.GroupBoxMessages.Location = New System.Drawing.Point(17, 73)
        Me.GroupBoxMessages.Name = "GroupBoxMessages"
        Me.GroupBoxMessages.Size = New System.Drawing.Size(409, 70)
        Me.GroupBoxMessages.TabIndex = 1
        Me.GroupBoxMessages.TabStop = False
        Me.GroupBoxMessages.Text = "Affichage des messages"
        '
        'ComboBoxMessages
        '
        Me.ComboBoxMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMessages.FormattingEnabled = True
        Me.ComboBoxMessages.Location = New System.Drawing.Point(11, 28)
        Me.ComboBoxMessages.Name = "ComboBoxMessages"
        Me.ComboBoxMessages.Size = New System.Drawing.Size(210, 21)
        Me.ComboBoxMessages.TabIndex = 0
        '
        'ButtonMessagesSound
        '
        Me.ButtonMessagesSound.FlatAppearance.BorderSize = 0
        Me.ButtonMessagesSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonMessagesSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonMessagesSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMessagesSound.Image = Global.ZGuideTV.My.Resources.Resources.controlplay
        Me.ButtonMessagesSound.Location = New System.Drawing.Point(248, 29)
        Me.ButtonMessagesSound.Name = "ButtonMessagesSound"
        Me.ButtonMessagesSound.Size = New System.Drawing.Size(16, 16)
        Me.ButtonMessagesSound.TabIndex = 15
        Me.ButtonMessagesSound.UseVisualStyleBackColor = True
        '
        'TrackBarMessages
        '
        Me.TrackBarMessages.AutoSize = False
        Me.TrackBarMessages.BackColor = System.Drawing.Color.White
        Me.TrackBarMessages.LargeChange = 1
        Me.TrackBarMessages.Location = New System.Drawing.Point(285, 29)
        Me.TrackBarMessages.Name = "TrackBarMessages"
        Me.TrackBarMessages.Size = New System.Drawing.Size(112, 33)
        Me.TrackBarMessages.TabIndex = 4
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.ZGuideTV.My.Resources.Resources.audiominus
        Me.PictureBox4.Location = New System.Drawing.Point(293, 10)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 8
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.ZGuideTV.My.Resources.Resources.audioplus
        Me.PictureBox3.Location = New System.Drawing.Point(373, 10)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        '
        'GroupBoxRSS
        '
        Me.GroupBoxRSS.Controls.Add(Me.ComboBoxRSS)
        Me.GroupBoxRSS.Controls.Add(Me.ButtonRSSSound)
        Me.GroupBoxRSS.Controls.Add(Me.TrackBarRSS)
        Me.GroupBoxRSS.Controls.Add(Me.PictureBox1)
        Me.GroupBoxRSS.Controls.Add(Me.PictureBox2)
        Me.GroupBoxRSS.Location = New System.Drawing.Point(17, 3)
        Me.GroupBoxRSS.Name = "GroupBoxRSS"
        Me.GroupBoxRSS.Size = New System.Drawing.Size(409, 70)
        Me.GroupBoxRSS.TabIndex = 0
        Me.GroupBoxRSS.TabStop = False
        Me.GroupBoxRSS.Text = "Mise à jour du Flux RSS"
        '
        'ComboBoxRSS
        '
        Me.ComboBoxRSS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRSS.FormattingEnabled = True
        Me.ComboBoxRSS.Location = New System.Drawing.Point(11, 28)
        Me.ComboBoxRSS.Name = "ComboBoxRSS"
        Me.ComboBoxRSS.Size = New System.Drawing.Size(210, 21)
        Me.ComboBoxRSS.TabIndex = 0
        '
        'ButtonRSSSound
        '
        Me.ButtonRSSSound.FlatAppearance.BorderSize = 0
        Me.ButtonRSSSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonRSSSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonRSSSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRSSSound.Image = Global.ZGuideTV.My.Resources.Resources.controlplay
        Me.ButtonRSSSound.Location = New System.Drawing.Point(248, 29)
        Me.ButtonRSSSound.Name = "ButtonRSSSound"
        Me.ButtonRSSSound.Size = New System.Drawing.Size(16, 16)
        Me.ButtonRSSSound.TabIndex = 14
        Me.ButtonRSSSound.UseVisualStyleBackColor = True
        '
        'TrackBarRSS
        '
        Me.TrackBarRSS.AutoSize = False
        Me.TrackBarRSS.BackColor = System.Drawing.Color.White
        Me.TrackBarRSS.LargeChange = 1
        Me.TrackBarRSS.Location = New System.Drawing.Point(285, 29)
        Me.TrackBarRSS.Name = "TrackBarRSS"
        Me.TrackBarRSS.Size = New System.Drawing.Size(112, 33)
        Me.TrackBarRSS.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ZGuideTV.My.Resources.Resources.audiominus
        Me.PictureBox1.Location = New System.Drawing.Point(293, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ZGuideTV.My.Resources.Resources.audioplus
        Me.PictureBox2.Location = New System.Drawing.Point(373, 10)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'Pref
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(452, 360)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.ButtonOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(468, 394)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(468, 394)
        Me.Name = "Pref"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Préférences"
        Me.TabPageCesoirMaintenant.ResumeLayout(False)
        Me.GroupBoxMaintenant.ResumeLayout(False)
        Me.GroupBoxMaintenant.PerformLayout()
        Me.GroupBoxCesoir.ResumeLayout(False)
        Me.GroupBoxCesoir.PerformLayout()
        Me.TabPageMiseajourLogiciel.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxCheckIn.ResumeLayout(False)
        Me.GroupBoxNextCheck.ResumeLayout(False)
        Me.GroupBoxNextCheck.PerformLayout()
        Me.GroupBoxLastCheck.ResumeLayout(False)
        Me.GroupBoxLastCheck.PerformLayout()
        Me.GroupBoxCheck.ResumeLayout(False)
        Me.GroupBoxCheck.PerformLayout()
        Me.GroupBoxIntervalles.ResumeLayout(False)
        Me.GroupBoxIntervalles.PerformLayout()
        Me.TabPageMiseajourDonnees.ResumeLayout(False)
        Me.GroupBoxEpgdata.ResumeLayout(False)
        Me.GroupBoxEpgdata.PerformLayout()
        CType(Me.NumericUpDownDownloadEpgdata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxChoixSource.ResumeLayout(False)
        Me.GroupBoxChoixSource.PerformLayout()
        Me.GroupBoxTailleBdd.ResumeLayout(False)
        Me.GroupBoxTailleBdd.PerformLayout()
        Me.GroupBoxUpdateNext.ResumeLayout(False)
        Me.GroupBoxUpdateNext.PerformLayout()
        Me.GroupBoxUpdateIn.ResumeLayout(False)
        Me.GroupBoxUpdateLast.ResumeLayout(False)
        Me.GroupBoxUpdateLast.PerformLayout()
        Me.GroupBoxIntervalle.ResumeLayout(False)
        Me.GroupBoxIntervalle.PerformLayout()
        Me.GroupBoxAutoUpdate.ResumeLayout(False)
        Me.GroupBoxAutoUpdate.PerformLayout()
        Me.TabPageProxy.ResumeLayout(False)
        Me.GroupBoxProxy.ResumeLayout(False)
        Me.GroupBoxProxy.PerformLayout()
        CType(Me.ProxyPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxConnexion.ResumeLayout(False)
        Me.GroupBoxConnexion.PerformLayout()
        Me.TabPageGeneral.ResumeLayout(False)
        Me.GroupBoxToolTipsBallon.ResumeLayout(False)
        Me.GroupBoxToolTipsBallon.PerformLayout()
        Me.GroupBoxUrlUpdate.ResumeLayout(False)
        Me.GroupBoxUrlUpdate.PerformLayout()
        Me.GroupBoxMouse.ResumeLayout(False)
        Me.GroupBoxMouse.PerformLayout()
        Me.GroupBoxConfHardware.ResumeLayout(False)
        Me.GroupBoxConfHardware.PerformLayout()
        Me.GroupBoxPosition.ResumeLayout(False)
        Me.GroupBoxPosition.PerformLayout()
        Me.GroupBoxFiltres.ResumeLayout(False)
        Me.GroupBoxFiltres.PerformLayout()
        Me.GroupBoxDivers.ResumeLayout(False)
        Me.GroupBoxDivers.PerformLayout()
        Me.GroupBoxSauvegardeFenetre.ResumeLayout(False)
        Me.GroupBoxSauvegardeFenetre.PerformLayout()
        Me.GroupBoxPurge.ResumeLayout(False)
        Me.GroupBoxPurge.PerformLayout()
        Me.GroupBoxEffects.ResumeLayout(False)
        Me.GroupBoxEffects.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPageResume.ResumeLayout(False)
        Me.GroupBoxResume.ResumeLayout(False)
        Me.GroupBoxResume.PerformLayout()
        Me.GroupBoxResumeBefore.ResumeLayout(False)
        Me.GroupBoxResumeBefore.PerformLayout()
        Me.TabPageSound.ResumeLayout(False)
        Me.GroupBoxMute.ResumeLayout(False)
        Me.GroupBoxMute.PerformLayout()
        Me.GroupBoxMasterVolume.ResumeLayout(False)
        CType(Me.TrackBarMasterVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxReminder.ResumeLayout(False)
        CType(Me.TrackBarReminder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMessages.ResumeLayout(False)
        CType(Me.TrackBarMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxRSS.ResumeLayout(False)
        CType(Me.TrackBarRSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents TabPageCesoirMaintenant As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxMaintenant As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonMaintenant120 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMaintenant105 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMaintenant90 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMaintenant75 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMaintenant60 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMaintenant45 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMaintenantAll As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxCesoir As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonCesoirAll As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCesoir120 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCesoir105 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCesoir90 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCesoir75 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCesoir60 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCesoir45 As System.Windows.Forms.RadioButton
    Friend WithEvents TabPageMiseajourLogiciel As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBoxCheckIn As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxNextCheck As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxNextUpdate As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxLastCheck As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxLastUpdate As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxCheck As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxAutoverif As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxIntervalles As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonAllMonths As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAllWeeks As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAllDays As System.Windows.Forms.RadioButton
    Friend WithEvents TabPageMiseajourDonnees As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxTailleBdd As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxTailleBdd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxUpdateNext As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxUpdateNext As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxUpdateIn As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxUpdateLast As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxUpdateLast As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxIntervalle As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonDay5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDay4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDay3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDay2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDay1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxAutoUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxAutoUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents TabPageProxy As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxProxy As System.Windows.Forms.GroupBox
    Friend WithEvents ProxyPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelProxy As System.Windows.Forms.Label
    Friend WithEvents LabelPort As System.Windows.Forms.Label
    Friend WithEvents ProxyHost As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxConnexion As System.Windows.Forms.GroupBox
    Friend WithEvents LabelUtilisateur As System.Windows.Forms.Label
    Friend WithEvents LabelMotdePasse As System.Windows.Forms.Label
    Friend WithEvents Login As System.Windows.Forms.TextBox
    Friend WithEvents Pass As System.Windows.Forms.TextBox
    Friend WithEvents TabPageGeneral As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxPosition As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxbuttonssave As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxFiltres As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxFilters As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxDivers As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxtracelog As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxSauvegardeFenetre As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxConfigWindow As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxPurge As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxPurge As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxEffects As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxSlide As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxFadeOut As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents LabelUpdateIn As System.Windows.Forms.Label
    Friend WithEvents LabelCheckIn As System.Windows.Forms.Label
    Friend WithEvents GroupBoxConfHardware As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonConfAverage As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonConfNormal As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonConfMinimum As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxMouse As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxaccordscrollhorizontal As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxoldUI As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxUrlUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxUrlUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents TabPageResume As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxToolTipsBallon As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxToolTipsBallon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxChoixSource As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonEPGData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonXMLTV As System.Windows.Forms.RadioButton
    Friend WithEvents BoutonSAbonner As System.Windows.Forms.Button
    Friend WithEvents LabelPinCode As System.Windows.Forms.Label
    Friend WithEvents tbPin As System.Windows.Forms.TextBox
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents GroupBoxEpgdata As System.Windows.Forms.GroupBox
    Friend WithEvents LabelEpgdataExpiration As System.Windows.Forms.Label
    Friend WithEvents LabelNbJourDownload As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownDownloadEpgdata As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBoxResume As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxResume As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxResumeBefore As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonResume15 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonResume30 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonResume10 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonResume20 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonResume5 As System.Windows.Forms.RadioButton
    Friend WithEvents TabPageSound As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxRSS As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxRSS As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBoxReminder As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxReminder As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBoxMessages As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxMessages As System.Windows.Forms.ComboBox
    Friend WithEvents TrackBarRSS As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarReminder As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarMessages As System.Windows.Forms.TrackBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBoxAudioOn As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonRSSSound As System.Windows.Forms.Button
    Friend WithEvents ButtonReminderSound As System.Windows.Forms.Button
    Friend WithEvents ButtonMessagesSound As System.Windows.Forms.Button
    Friend WithEvents TrackBarMasterVolume As System.Windows.Forms.TrackBar
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBoxMasterVolume As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxMute As System.Windows.Forms.GroupBox
End Class
