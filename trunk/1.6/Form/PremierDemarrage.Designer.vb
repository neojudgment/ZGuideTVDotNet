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
        Me.LabelProxy = New System.Windows.Forms.Label()
        Me.LabelPort = New System.Windows.Forms.Label()
        Me.ProxyHost = New System.Windows.Forms.TextBox()
        Me.GroupBoxProxy = New System.Windows.Forms.GroupBox()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.LabelUtilisateur = New System.Windows.Forms.Label()
        Me.LabelMotdePasse = New System.Windows.Forms.Label()
        Me.Login = New System.Windows.Forms.TextBox()
        Me.Pass = New System.Windows.Forms.TextBox()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonProxyTest = New System.Windows.Forms.Button()
        Me.ProxyPort = New System.Windows.Forms.TextBox()
        Me.GroupBoxProxy.SuspendLayout
        Me.SuspendLayout
        '
        'LabelProxy
        '
        Me.LabelProxy.AutoSize = true
        Me.LabelProxy.Location = New System.Drawing.Point(228, 20)
        Me.LabelProxy.Name = "LabelProxy"
        Me.LabelProxy.Size = New System.Drawing.Size(39, 13)
        Me.LabelProxy.TabIndex = 13
        Me.LabelProxy.Text = "Proxy :"
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = true
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
        Me.GroupBoxProxy.Controls.Add(Me.ProxyPort)
        Me.GroupBoxProxy.Controls.Add(Me.LabelInfo)
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
        Me.GroupBoxProxy.TabStop = false
        Me.GroupBoxProxy.Text = "Proxy"
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = true
        Me.LabelInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelInfo.Location = New System.Drawing.Point(11, 106)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(371, 12)
        Me.LabelInfo.TabIndex = 16
        Me.LabelInfo.Text = "Si vous ne savez pas, demandez à votre administrateur, sinon laissez ces champs v"& _ 
    "ides."
        '
        'LabelUtilisateur
        '
        Me.LabelUtilisateur.AutoSize = true
        Me.LabelUtilisateur.Location = New System.Drawing.Point(10, 20)
        Me.LabelUtilisateur.Name = "LabelUtilisateur"
        Me.LabelUtilisateur.Size = New System.Drawing.Size(59, 13)
        Me.LabelUtilisateur.TabIndex = 13
        Me.LabelUtilisateur.Text = "Utilisateur :"
        '
        'LabelMotdePasse
        '
        Me.LabelMotdePasse.AutoSize = true
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
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(70, 155)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(67, 23)
        Me.ButtonOK.TabIndex = 15
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = true
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(313, 155)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(67, 23)
        Me.ButtonCancel.TabIndex = 16
        Me.ButtonCancel.Text = "Annuler"
        Me.ButtonCancel.UseVisualStyleBackColor = true
        '
        'ButtonProxyTest
        '
        Me.ButtonProxyTest.Location = New System.Drawing.Point(193, 155)
        Me.ButtonProxyTest.Name = "ButtonProxyTest"
        Me.ButtonProxyTest.Size = New System.Drawing.Size(67, 23)
        Me.ButtonProxyTest.TabIndex = 17
        Me.ButtonProxyTest.Text = "Vérifier"
        Me.ButtonProxyTest.UseVisualStyleBackColor = true
        '
        'ProxyPort
        '
        Me.ProxyPort.Location = New System.Drawing.Point(228, 75)
        Me.ProxyPort.Name = "ProxyPort"
        Me.ProxyPort.Size = New System.Drawing.Size(139, 20)
        Me.ProxyPort.TabIndex = 17
        '
        'PremierDemarrage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(451, 192)
        Me.Controls.Add(Me.ButtonProxyTest)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.GroupBoxProxy)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "PremierDemarrage"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Premier Démarrage"
        Me.GroupBoxProxy.ResumeLayout(false)
        Me.GroupBoxProxy.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents LabelProxy As System.Windows.Forms.Label
    Friend WithEvents LabelPort As System.Windows.Forms.Label
    Friend WithEvents ProxyHost As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxProxy As System.Windows.Forms.GroupBox
    Friend WithEvents LabelUtilisateur As System.Windows.Forms.Label
    Friend WithEvents LabelMotdePasse As System.Windows.Forms.Label
    Friend WithEvents Login As System.Windows.Forms.TextBox
    Friend WithEvents Pass As System.Windows.Forms.TextBox
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonProxyTest As System.Windows.Forms.Button
    Friend WithEvents ProxyPort As System.Windows.Forms.TextBox
End Class
