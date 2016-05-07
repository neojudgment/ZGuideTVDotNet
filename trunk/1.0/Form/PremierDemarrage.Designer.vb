<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PremierDemarrage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremierDemarrage))
        Me.ProxyPort = New System.Windows.Forms.NumericUpDown()
        Me.LabelProxy = New System.Windows.Forms.Label()
        Me.LabelPort = New System.Windows.Forms.Label()
        Me.ProxyHost = New System.Windows.Forms.TextBox()
        Me.GroupBoxProxy = New System.Windows.Forms.GroupBox()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.LabelUtilisateur = New System.Windows.Forms.Label()
        Me.LabelMotdePasse = New System.Windows.Forms.Label()
        Me.Login = New System.Windows.Forms.TextBox()
        Me.Pass = New System.Windows.Forms.TextBox()
        Me.GroupBoxEPGData = New System.Windows.Forms.GroupBox()
        Me.LabelInfoPrice = New System.Windows.Forms.Label()
        Me.LabelPinCode = New System.Windows.Forms.Label()
        Me.ButtonSubscription = New System.Windows.Forms.Button()
        Me.TextBoxPinCode = New System.Windows.Forms.TextBox()
        Me.GroupBoxChoixSource = New System.Windows.Forms.GroupBox()
        Me.RadioButtonEPGData = New System.Windows.Forms.RadioButton()
        Me.RadioButtonXMLTV = New System.Windows.Forms.RadioButton()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        CType(Me.ProxyPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxProxy.SuspendLayout()
        Me.GroupBoxEPGData.SuspendLayout()
        Me.GroupBoxChoixSource.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProxyPort
        '
        Me.ProxyPort.BackColor = System.Drawing.Color.White
        Me.ProxyPort.Location = New System.Drawing.Point(228, 75)
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
        Me.LabelProxy.Location = New System.Drawing.Point(228, 20)
        Me.LabelProxy.Name = "LabelProxy"
        Me.LabelProxy.Size = New System.Drawing.Size(39, 13)
        Me.LabelProxy.TabIndex = 13
        Me.LabelProxy.Text = "Proxy :"
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = True
        Me.LabelPort.Location = New System.Drawing.Point(228, 59)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(32, 13)
        Me.LabelPort.TabIndex = 14
        Me.LabelPort.Text = "Port :"
        '
        'ProxyHost
        '
        Me.ProxyHost.BackColor = System.Drawing.Color.White
        Me.ProxyHost.Location = New System.Drawing.Point(228, 36)
        Me.ProxyHost.Name = "ProxyHost"
        Me.ProxyHost.Size = New System.Drawing.Size(139, 20)
        Me.ProxyHost.TabIndex = 10
        '
        'GroupBoxProxy
        '
        Me.GroupBoxProxy.Controls.Add(Me.LabelInfo)
        Me.GroupBoxProxy.Controls.Add(Me.ProxyPort)
        Me.GroupBoxProxy.Controls.Add(Me.LabelUtilisateur)
        Me.GroupBoxProxy.Controls.Add(Me.LabelProxy)
        Me.GroupBoxProxy.Controls.Add(Me.LabelMotdePasse)
        Me.GroupBoxProxy.Controls.Add(Me.LabelPort)
        Me.GroupBoxProxy.Controls.Add(Me.Login)
        Me.GroupBoxProxy.Controls.Add(Me.ProxyHost)
        Me.GroupBoxProxy.Controls.Add(Me.Pass)
        Me.GroupBoxProxy.Location = New System.Drawing.Point(31, 16)
        Me.GroupBoxProxy.Name = "GroupBoxProxy"
        Me.GroupBoxProxy.Size = New System.Drawing.Size(388, 130)
        Me.GroupBoxProxy.TabIndex = 11
        Me.GroupBoxProxy.TabStop = False
        Me.GroupBoxProxy.Text = "Proxy"
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInfo.Location = New System.Drawing.Point(11, 106)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(371, 12)
        Me.LabelInfo.TabIndex = 16
        Me.LabelInfo.Text = "Si vous ne savez pas, demandez à votre administrateur, sinon laissez ces champs v" & _
    "ides."
        '
        'LabelUtilisateur
        '
        Me.LabelUtilisateur.AutoSize = True
        Me.LabelUtilisateur.Location = New System.Drawing.Point(10, 20)
        Me.LabelUtilisateur.Name = "LabelUtilisateur"
        Me.LabelUtilisateur.Size = New System.Drawing.Size(59, 13)
        Me.LabelUtilisateur.TabIndex = 13
        Me.LabelUtilisateur.Text = "Utilisateur :"
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
        'GroupBoxEPGData
        '
        Me.GroupBoxEPGData.Controls.Add(Me.LabelInfoPrice)
        Me.GroupBoxEPGData.Controls.Add(Me.LabelPinCode)
        Me.GroupBoxEPGData.Controls.Add(Me.ButtonSubscription)
        Me.GroupBoxEPGData.Controls.Add(Me.TextBoxPinCode)
        Me.GroupBoxEPGData.Enabled = False
        Me.GroupBoxEPGData.Location = New System.Drawing.Point(31, 203)
        Me.GroupBoxEPGData.Name = "GroupBoxEPGData"
        Me.GroupBoxEPGData.Size = New System.Drawing.Size(388, 101)
        Me.GroupBoxEPGData.TabIndex = 14
        Me.GroupBoxEPGData.TabStop = False
        Me.GroupBoxEPGData.Text = "epgData"
        '
        'LabelInfoPrice
        '
        Me.LabelInfoPrice.AutoSize = True
        Me.LabelInfoPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInfoPrice.Location = New System.Drawing.Point(236, 81)
        Me.LabelInfoPrice.Name = "LabelInfoPrice"
        Me.LabelInfoPrice.Size = New System.Drawing.Size(127, 12)
        Me.LabelInfoPrice.TabIndex = 8
        Me.LabelInfoPrice.Text = "* €11-€17  par an (01/09/2010)"
        '
        'LabelPinCode
        '
        Me.LabelPinCode.AutoSize = True
        Me.LabelPinCode.Location = New System.Drawing.Point(6, 22)
        Me.LabelPinCode.Name = "LabelPinCode"
        Me.LabelPinCode.Size = New System.Drawing.Size(59, 13)
        Me.LabelPinCode.TabIndex = 3
        Me.LabelPinCode.Text = "Code PIN ;"
        '
        'ButtonSubscription
        '
        Me.ButtonSubscription.Location = New System.Drawing.Point(9, 51)
        Me.ButtonSubscription.Name = "ButtonSubscription"
        Me.ButtonSubscription.Size = New System.Drawing.Size(149, 37)
        Me.ButtonSubscription.TabIndex = 4
        Me.ButtonSubscription.Text = "Abonnement epgData *"
        Me.ButtonSubscription.UseVisualStyleBackColor = True
        '
        'TextBoxPinCode
        '
        Me.TextBoxPinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPinCode.Location = New System.Drawing.Point(71, 20)
        Me.TextBoxPinCode.Name = "TextBoxPinCode"
        Me.TextBoxPinCode.Size = New System.Drawing.Size(257, 20)
        Me.TextBoxPinCode.TabIndex = 2
        '
        'GroupBoxChoixSource
        '
        Me.GroupBoxChoixSource.Controls.Add(Me.RadioButtonEPGData)
        Me.GroupBoxChoixSource.Controls.Add(Me.RadioButtonXMLTV)
        Me.GroupBoxChoixSource.Enabled = False
        Me.GroupBoxChoixSource.Location = New System.Drawing.Point(31, 152)
        Me.GroupBoxChoixSource.Name = "GroupBoxChoixSource"
        Me.GroupBoxChoixSource.Size = New System.Drawing.Size(388, 45)
        Me.GroupBoxChoixSource.TabIndex = 13
        Me.GroupBoxChoixSource.TabStop = False
        Me.GroupBoxChoixSource.Text = "Source"
        '
        'RadioButtonEPGData
        '
        Me.RadioButtonEPGData.AutoSize = True
        Me.RadioButtonEPGData.Location = New System.Drawing.Point(96, 20)
        Me.RadioButtonEPGData.Name = "RadioButtonEPGData"
        Me.RadioButtonEPGData.Size = New System.Drawing.Size(96, 17)
        Me.RadioButtonEPGData.TabIndex = 1
        Me.RadioButtonEPGData.TabStop = True
        Me.RadioButtonEPGData.Text = "epgData.com *"
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
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(70, 315)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(67, 23)
        Me.ButtonOK.TabIndex = 15
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(313, 315)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(67, 23)
        Me.ButtonCancel.TabIndex = 16
        Me.ButtonCancel.Text = "Annuler"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'PremierDemarrage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(451, 350)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.GroupBoxEPGData)
        Me.Controls.Add(Me.GroupBoxChoixSource)
        Me.Controls.Add(Me.GroupBoxProxy)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PremierDemarrage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Premier Démarrage"
        CType(Me.ProxyPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxProxy.ResumeLayout(False)
        Me.GroupBoxProxy.PerformLayout()
        Me.GroupBoxEPGData.ResumeLayout(False)
        Me.GroupBoxEPGData.PerformLayout()
        Me.GroupBoxChoixSource.ResumeLayout(False)
        Me.GroupBoxChoixSource.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProxyPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelProxy As System.Windows.Forms.Label
    Friend WithEvents LabelPort As System.Windows.Forms.Label
    Friend WithEvents ProxyHost As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxProxy As System.Windows.Forms.GroupBox
    Friend WithEvents LabelUtilisateur As System.Windows.Forms.Label
    Friend WithEvents LabelMotdePasse As System.Windows.Forms.Label
    Friend WithEvents Login As System.Windows.Forms.TextBox
    Friend WithEvents Pass As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxEPGData As System.Windows.Forms.GroupBox
    Friend WithEvents LabelInfoPrice As System.Windows.Forms.Label
    Friend WithEvents LabelPinCode As System.Windows.Forms.Label
    Friend WithEvents ButtonSubscription As System.Windows.Forms.Button
    Friend WithEvents TextBoxPinCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxChoixSource As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonEPGData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonXMLTV As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
End Class
