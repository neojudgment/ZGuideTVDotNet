<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Feedback
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Feedback))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Send_Button = New System.Windows.Forms.Button()
        Me.Exit_Button = New System.Windows.Forms.Button()
        Me.Copier_Button = New System.Windows.Forms.Button()
        Me.Copy_Button = New System.Windows.Forms.Button()
        Me.ExceptErrorMessage = New System.Windows.Forms.RichTextBox()
        Me.LabelExceptMessage2 = New System.Windows.Forms.Label()
        Me.LabelExceptMessage1 = New System.Windows.Forms.Label()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.RichTextBoxExceptErrorMessage = New System.Windows.Forms.RichTextBox()
        Me.LabelExceptMessage3 = New System.Windows.Forms.Label()
        Me.CheckBoxExceptErrorMessage = New System.Windows.Forms.CheckBox()
        Me.LabelEmail = New System.Windows.Forms.Label()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.BackgroundWorkerFeedback = New System.ComponentModel.BackgroundWorker()
        Me.PictureBoxFeedback = New System.Windows.Forms.PictureBox()
        Me.LabelFeedbackSend = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxAcknowledgment = New System.Windows.Forms.CheckBox()
        Me.LabelExceptMessage4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBoxFeedback, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Send_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Exit_Button, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Copier_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(196, 474)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(249, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Send_Button
        '
        Me.Send_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Send_Button.Location = New System.Drawing.Point(3, 3)
        Me.Send_Button.Name = "Send_Button"
        Me.Send_Button.Size = New System.Drawing.Size(78, 23)
        Me.Send_Button.TabIndex = 3
        Me.Send_Button.Text = "Envoyer"
        Me.Send_Button.UseVisualStyleBackColor = True
        '
        'Exit_Button
        '
        Me.Exit_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Exit_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Exit_Button.Location = New System.Drawing.Point(168, 3)
        Me.Exit_Button.Name = "Exit_Button"
        Me.Exit_Button.Size = New System.Drawing.Size(75, 23)
        Me.Exit_Button.TabIndex = 1
        Me.Exit_Button.Text = "Quitter"
        Me.Exit_Button.UseVisualStyleBackColor = True
        '
        'Copier_Button
        '
        Me.Copier_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Copier_Button.Location = New System.Drawing.Point(87, 3)
        Me.Copier_Button.Name = "Copier_Button"
        Me.Copier_Button.Size = New System.Drawing.Size(73, 23)
        Me.Copier_Button.TabIndex = 2
        Me.Copier_Button.Text = "Copier"
        Me.Copier_Button.UseVisualStyleBackColor = True
        '
        'Copy_Button
        '
        Me.Copy_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Copy_Button.Location = New System.Drawing.Point(150, 3)
        Me.Copy_Button.Name = "Copy_Button"
        Me.Copy_Button.Size = New System.Drawing.Size(67, 23)
        Me.Copy_Button.TabIndex = 0
        Me.Copy_Button.Text = "Copier"
        '
        'ExceptErrorMessage
        '
        Me.ExceptErrorMessage.BackColor = System.Drawing.Color.White
        Me.ExceptErrorMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExceptErrorMessage.Location = New System.Drawing.Point(11, 56)
        Me.ExceptErrorMessage.Name = "ExceptErrorMessage"
        Me.ExceptErrorMessage.ReadOnly = True
        Me.ExceptErrorMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.ExceptErrorMessage.Size = New System.Drawing.Size(433, 248)
        Me.ExceptErrorMessage.TabIndex = 1
        Me.ExceptErrorMessage.Text = ""
        '
        'LabelExceptMessage2
        '
        Me.LabelExceptMessage2.AutoSize = True
        Me.LabelExceptMessage2.Location = New System.Drawing.Point(10, 33)
        Me.LabelExceptMessage2.Name = "LabelExceptMessage2"
        Me.LabelExceptMessage2.Size = New System.Drawing.Size(431, 13)
        Me.LabelExceptMessage2.TabIndex = 2
        Me.LabelExceptMessage2.Text = "Veuillez contacter les développeurs de ZGuideTV en indiquant les informations sui" &
    "vantes :"
        '
        'LabelExceptMessage1
        '
        Me.LabelExceptMessage1.AutoSize = True
        Me.LabelExceptMessage1.Location = New System.Drawing.Point(10, 14)
        Me.LabelExceptMessage1.Name = "LabelExceptMessage1"
        Me.LabelExceptMessage1.Size = New System.Drawing.Size(178, 13)
        Me.LabelExceptMessage1.TabIndex = 3
        Me.LabelExceptMessage1.Text = "Une erreur inattendue s'est produite!"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Line1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Line1.Location = New System.Drawing.Point(13, 460)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(428, 2)
        Me.Line1.TabIndex = 40
        '
        'RichTextBoxExceptErrorMessage
        '
        Me.RichTextBoxExceptErrorMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBoxExceptErrorMessage.Location = New System.Drawing.Point(11, 340)
        Me.RichTextBoxExceptErrorMessage.Name = "RichTextBoxExceptErrorMessage"
        Me.RichTextBoxExceptErrorMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBoxExceptErrorMessage.Size = New System.Drawing.Size(433, 49)
        Me.RichTextBoxExceptErrorMessage.TabIndex = 0
        Me.RichTextBoxExceptErrorMessage.Text = ""
        '
        'LabelExceptMessage3
        '
        Me.LabelExceptMessage3.AutoSize = True
        Me.LabelExceptMessage3.Location = New System.Drawing.Point(10, 317)
        Me.LabelExceptMessage3.Name = "LabelExceptMessage3"
        Me.LabelExceptMessage3.Size = New System.Drawing.Size(128, 13)
        Me.LabelExceptMessage3.TabIndex = 42
        Me.LabelExceptMessage3.Text = "Commentaires (facultatif) :"
        '
        'CheckBoxExceptErrorMessage
        '
        Me.CheckBoxExceptErrorMessage.AutoSize = True
        Me.CheckBoxExceptErrorMessage.Checked = True
        Me.CheckBoxExceptErrorMessage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxExceptErrorMessage.Location = New System.Drawing.Point(11, 405)
        Me.CheckBoxExceptErrorMessage.Name = "CheckBoxExceptErrorMessage"
        Me.CheckBoxExceptErrorMessage.Size = New System.Drawing.Size(129, 17)
        Me.CheckBoxExceptErrorMessage.TabIndex = 43
        Me.CheckBoxExceptErrorMessage.Text = "Joindre les fichiers log"
        Me.CheckBoxExceptErrorMessage.UseVisualStyleBackColor = True
        '
        'LabelEmail
        '
        Me.LabelEmail.AutoSize = True
        Me.LabelEmail.Location = New System.Drawing.Point(157, 406)
        Me.LabelEmail.Name = "LabelEmail"
        Me.LabelEmail.Size = New System.Drawing.Size(94, 13)
        Me.LabelEmail.TabIndex = 45
        Me.LabelEmail.Text = "E-mail (facultatif)* :"
        Me.LabelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(251, 403)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(171, 20)
        Me.TextBoxEmail.TabIndex = 46
        '
        'BackgroundWorkerFeedback
        '
        '
        'PictureBoxFeedback
        '
        Me.PictureBoxFeedback.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxFeedback.Location = New System.Drawing.Point(3, 4)
        Me.PictureBoxFeedback.Name = "PictureBoxFeedback"
        Me.PictureBoxFeedback.Size = New System.Drawing.Size(32, 32)
        Me.PictureBoxFeedback.TabIndex = 47
        Me.PictureBoxFeedback.TabStop = False
        '
        'LabelFeedbackSend
        '
        Me.LabelFeedbackSend.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelFeedbackSend.Location = New System.Drawing.Point(41, 10)
        Me.LabelFeedbackSend.Name = "LabelFeedbackSend"
        Me.LabelFeedbackSend.Size = New System.Drawing.Size(130, 20)
        Me.LabelFeedbackSend.TabIndex = 48
        Me.LabelFeedbackSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBoxFeedback, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelFeedbackSend, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(10, 467)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(175, 40)
        Me.TableLayoutPanel2.TabIndex = 49
        '
        'CheckBoxAcknowledgment
        '
        Me.CheckBoxAcknowledgment.AutoSize = True
        Me.CheckBoxAcknowledgment.Checked = True
        Me.CheckBoxAcknowledgment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAcknowledgment.Location = New System.Drawing.Point(11, 430)
        Me.CheckBoxAcknowledgment.Name = "CheckBoxAcknowledgment"
        Me.CheckBoxAcknowledgment.Size = New System.Drawing.Size(124, 17)
        Me.CheckBoxAcknowledgment.TabIndex = 50
        Me.CheckBoxAcknowledgment.Text = "Accusé de réception"
        Me.CheckBoxAcknowledgment.UseVisualStyleBackColor = True
        '
        'LabelExceptMessage4
        '
        Me.LabelExceptMessage4.AutoSize = True
        Me.LabelExceptMessage4.Location = New System.Drawing.Point(157, 430)
        Me.LabelExceptMessage4.Name = "LabelExceptMessage4"
        Me.LabelExceptMessage4.Size = New System.Drawing.Size(278, 13)
        Me.LabelExceptMessage4.TabIndex = 51
        Me.LabelExceptMessage4.Text = "*Si vous voulez être contacté veuillez indiqué votre email."
        Me.LabelExceptMessage4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Feedback
        '
        Me.AcceptButton = Me.Send_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Exit_Button
        Me.ClientSize = New System.Drawing.Size(458, 515)
        Me.Controls.Add(Me.LabelExceptMessage4)
        Me.Controls.Add(Me.CheckBoxAcknowledgment)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.Controls.Add(Me.LabelEmail)
        Me.Controls.Add(Me.CheckBoxExceptErrorMessage)
        Me.Controls.Add(Me.LabelExceptMessage3)
        Me.Controls.Add(Me.RichTextBoxExceptErrorMessage)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.LabelExceptMessage1)
        Me.Controls.Add(Me.LabelExceptMessage2)
        Me.Controls.Add(Me.ExceptErrorMessage)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Feedback"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Erreur de l'application "
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBoxFeedback, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Send_Button As System.Windows.Forms.Button
    Friend WithEvents Copy_Button As System.Windows.Forms.Button
    Friend WithEvents Exit_Button As System.Windows.Forms.Button
    Friend WithEvents ExceptErrorMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents LabelExceptMessage2 As System.Windows.Forms.Label
    Friend WithEvents LabelExceptMessage1 As System.Windows.Forms.Label
    Friend WithEvents Copier_Button As System.Windows.Forms.Button
    Public WithEvents Line1 As System.Windows.Forms.Label
    Friend WithEvents RichTextBoxExceptErrorMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents LabelExceptMessage3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxExceptErrorMessage As System.Windows.Forms.CheckBox
    Friend WithEvents LabelEmail As System.Windows.Forms.Label
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorkerFeedback As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBoxFeedback As System.Windows.Forms.PictureBox
    Friend WithEvents LabelFeedbackSend As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxAcknowledgment As System.Windows.Forms.CheckBox
    Friend WithEvents LabelExceptMessage4 As System.Windows.Forms.Label

End Class
