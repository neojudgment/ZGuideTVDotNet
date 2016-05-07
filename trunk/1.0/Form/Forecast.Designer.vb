<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Forecast
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                If Not ImageDay Is Nothing Then ImageDay.Dispose()


                If Not _imageDay Is Nothing Then _imageDay.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Forecast))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Location_Button = New System.Windows.Forms.Button()
        Me.PictureBoxImageDay1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxImageDay2 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxImageDay3 = New System.Windows.Forms.PictureBox()
        Me.Day1ConditionLabel = New System.Windows.Forms.Label()
        Me.Day2ConditionLabel = New System.Windows.Forms.Label()
        Me.Day3ConditionLabel = New System.Windows.Forms.Label()
        Me.Day1Label = New System.Windows.Forms.Label()
        Me.Day2Label = New System.Windows.Forms.Label()
        Me.Day3Label = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBoxImageDay1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxImageDay2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxImageDay3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Location_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 109)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(439, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(39, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(332, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 2
        Me.Cancel_Button.Text = "Annuler"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'Location_Button
        '
        Me.Location_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Location_Button.Location = New System.Drawing.Point(176, 3)
        Me.Location_Button.Name = "Location_Button"
        Me.Location_Button.Size = New System.Drawing.Size(86, 23)
        Me.Location_Button.TabIndex = 3
        Me.Location_Button.Text = "Emplacement"
        Me.Location_Button.UseVisualStyleBackColor = True
        '
        'PictureBoxImageDay1
        '
        Me.PictureBoxImageDay1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxImageDay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBoxImageDay1.Location = New System.Drawing.Point(132, 11)
        Me.PictureBoxImageDay1.Name = "PictureBoxImageDay1"
        Me.PictureBoxImageDay1.Size = New System.Drawing.Size(22, 22)
        Me.PictureBoxImageDay1.TabIndex = 1
        Me.PictureBoxImageDay1.TabStop = False
        '
        'PictureBoxImageDay2
        '
        Me.PictureBoxImageDay2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxImageDay2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBoxImageDay2.Location = New System.Drawing.Point(132, 42)
        Me.PictureBoxImageDay2.Name = "PictureBoxImageDay2"
        Me.PictureBoxImageDay2.Size = New System.Drawing.Size(22, 22)
        Me.PictureBoxImageDay2.TabIndex = 2
        Me.PictureBoxImageDay2.TabStop = False
        '
        'PictureBoxImageDay3
        '
        Me.PictureBoxImageDay3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxImageDay3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBoxImageDay3.Location = New System.Drawing.Point(132, 73)
        Me.PictureBoxImageDay3.Name = "PictureBoxImageDay3"
        Me.PictureBoxImageDay3.Size = New System.Drawing.Size(22, 22)
        Me.PictureBoxImageDay3.TabIndex = 3
        Me.PictureBoxImageDay3.TabStop = False
        '
        'Day1ConditionLabel
        '
        Me.Day1ConditionLabel.AutoSize = True
        Me.Day1ConditionLabel.Location = New System.Drawing.Point(180, 13)
        Me.Day1ConditionLabel.Name = "Day1ConditionLabel"
        Me.Day1ConditionLabel.Size = New System.Drawing.Size(102, 13)
        Me.Day1ConditionLabel.TabIndex = 9
        Me.Day1ConditionLabel.Text = "Day1ConditionLabel"
        Me.Day1ConditionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Day2ConditionLabel
        '
        Me.Day2ConditionLabel.AutoSize = True
        Me.Day2ConditionLabel.Location = New System.Drawing.Point(180, 44)
        Me.Day2ConditionLabel.Name = "Day2ConditionLabel"
        Me.Day2ConditionLabel.Size = New System.Drawing.Size(102, 13)
        Me.Day2ConditionLabel.TabIndex = 10
        Me.Day2ConditionLabel.Text = "Day2ConditionLabel"
        Me.Day2ConditionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Day3ConditionLabel
        '
        Me.Day3ConditionLabel.AutoSize = True
        Me.Day3ConditionLabel.Location = New System.Drawing.Point(180, 75)
        Me.Day3ConditionLabel.Name = "Day3ConditionLabel"
        Me.Day3ConditionLabel.Size = New System.Drawing.Size(102, 13)
        Me.Day3ConditionLabel.TabIndex = 11
        Me.Day3ConditionLabel.Text = "Day3ConditionLabel"
        Me.Day3ConditionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Day1Label
        '
        Me.Day1Label.Location = New System.Drawing.Point(44, 9)
        Me.Day1Label.Name = "Day1Label"
        Me.Day1Label.Size = New System.Drawing.Size(77, 22)
        Me.Day1Label.TabIndex = 13
        Me.Day1Label.Text = "Day1Label"
        Me.Day1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Day2Label
        '
        Me.Day2Label.Location = New System.Drawing.Point(44, 40)
        Me.Day2Label.Name = "Day2Label"
        Me.Day2Label.Size = New System.Drawing.Size(77, 22)
        Me.Day2Label.TabIndex = 14
        Me.Day2Label.Text = "Day2Label"
        Me.Day2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Day3Label
        '
        Me.Day3Label.Location = New System.Drawing.Point(44, 70)
        Me.Day3Label.Name = "Day3Label"
        Me.Day3Label.Size = New System.Drawing.Size(77, 22)
        Me.Day3Label.TabIndex = 15
        Me.Day3Label.Text = "Day3Label"
        Me.Day3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.Location = New System.Drawing.Point(19, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(428, 2)
        Me.Label9.TabIndex = 42
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label10.Location = New System.Drawing.Point(19, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(428, 2)
        Me.Label10.TabIndex = 43
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label11.Location = New System.Drawing.Point(18, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(428, 2)
        Me.Label11.TabIndex = 44
        '
        'Forecast
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(466, 152)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Day3Label)
        Me.Controls.Add(Me.Day2Label)
        Me.Controls.Add(Me.Day1Label)
        Me.Controls.Add(Me.Day3ConditionLabel)
        Me.Controls.Add(Me.PictureBoxImageDay3)
        Me.Controls.Add(Me.PictureBoxImageDay2)
        Me.Controls.Add(Me.Day2ConditionLabel)
        Me.Controls.Add(Me.PictureBoxImageDay1)
        Me.Controls.Add(Me.Day1ConditionLabel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Forecast"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Prévisions météo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBoxImageDay1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxImageDay2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxImageDay3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBoxImageDay1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxImageDay2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxImageDay3 As System.Windows.Forms.PictureBox
    Friend WithEvents Day1ConditionLabel As System.Windows.Forms.Label
    Friend WithEvents Day2ConditionLabel As System.Windows.Forms.Label
    Friend WithEvents Day3ConditionLabel As System.Windows.Forms.Label
    Friend WithEvents Day1Label As System.Windows.Forms.Label
    Friend WithEvents Day2Label As System.Windows.Forms.Label
    Friend WithEvents Day3Label As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Location_Button As System.Windows.Forms.Button

End Class
