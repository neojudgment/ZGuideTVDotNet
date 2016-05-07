Partial Class AdvancedSearch_Channel
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
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.ConditionsComboBox = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.ChannelComboBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(0, 0)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(22, 22)
        Me.RemoveButton.TabIndex = 9
        Me.RemoveButton.Text = "X"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"est égale à", "n'est pas égale à"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(82, 0)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 8
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 4)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Si chaine"
        '
        'ChannelComboBox
        '
        Me.ChannelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ChannelComboBox.FormattingEnabled = True
        Me.ChannelComboBox.Location = New System.Drawing.Point(209, 0)
        Me.ChannelComboBox.Name = "ChannelComboBox"
        Me.ChannelComboBox.Size = New System.Drawing.Size(225, 21)
        Me.ChannelComboBox.TabIndex = 10
        '
        'AdvancedSearch_Channel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ChannelComboBox)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_Channel"
        Me.Size = New System.Drawing.Size(437, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

    Private WithEvents RemoveButton As System.Windows.Forms.Button
	Private ConditionsComboBox As System.Windows.Forms.ComboBox
	Private label1 As System.Windows.Forms.Label
	Private ChannelComboBox As System.Windows.Forms.ComboBox
End Class
