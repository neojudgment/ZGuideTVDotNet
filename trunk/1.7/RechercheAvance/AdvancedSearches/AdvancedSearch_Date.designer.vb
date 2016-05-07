Partial Class AdvancedSearch_Date
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
        Me.label1 = New System.Windows.Forms.Label()
        Me.FieldsComboBox = New System.Windows.Forms.ComboBox()
        Me.ConditionsComboBox = New System.Windows.Forms.ComboBox()
        Me.DateCriteriaDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 4)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(16, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Si"
        '
        'FieldsComboBox
        '
        Me.FieldsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FieldsComboBox.FormattingEnabled = True
        Me.FieldsComboBox.Items.AddRange(New Object() {"le début", "la fin"})
        Me.FieldsComboBox.Location = New System.Drawing.Point(43, 0)
        Me.FieldsComboBox.Name = "FieldsComboBox"
        Me.FieldsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.FieldsComboBox.TabIndex = 3
        '
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"est égale à", "est avant le", "est après le"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(168, 0)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 4
        '
        'DateCriteriaDateTimePicker
        '
        Me.DateCriteriaDateTimePicker.Location = New System.Drawing.Point(294, 0)
        Me.DateCriteriaDateTimePicker.Name = "DateCriteriaDateTimePicker"
        Me.DateCriteriaDateTimePicker.Size = New System.Drawing.Size(187, 20)
        Me.DateCriteriaDateTimePicker.TabIndex = 5
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(0, 0)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(22, 22)
        Me.RemoveButton.TabIndex = 6
        Me.RemoveButton.Text = "X"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'AdvancedSearch_Date
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.DateCriteriaDateTimePicker)
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.FieldsComboBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_Date"
        Me.Size = New System.Drawing.Size(484, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

	Private label1 As System.Windows.Forms.Label
	Private FieldsComboBox As System.Windows.Forms.ComboBox
	Private ConditionsComboBox As System.Windows.Forms.ComboBox
	Private DateCriteriaDateTimePicker As System.Windows.Forms.DateTimePicker
    Private WithEvents RemoveButton As System.Windows.Forms.Button
End Class
