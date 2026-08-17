Partial Class AdvancedSearch_Category
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
        Me.ConditionsComboBox = New System.Windows.Forms.ComboBox()
        Me.CategoriesComboBox = New System.Windows.Forms.ComboBox()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 5)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(63, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Si catégorie"
        '
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"est egale à", "n'est pas égale à"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(91, 0)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 2
        '
        'CategoriesComboBox
        '
        Me.CategoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CategoriesComboBox.FormattingEnabled = True
        Me.CategoriesComboBox.Location = New System.Drawing.Point(218, 0)
        Me.CategoriesComboBox.Name = "CategoriesComboBox"
        Me.CategoriesComboBox.Size = New System.Drawing.Size(161, 21)
        Me.CategoriesComboBox.TabIndex = 3
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(0, 0)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(22, 22)
        Me.RemoveButton.TabIndex = 5
        Me.RemoveButton.Text = "X"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'AdvancedSearch_Category
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.CategoriesComboBox)
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_Category"
        Me.Size = New System.Drawing.Size(382, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

	Private label1 As System.Windows.Forms.Label
	Private ConditionsComboBox As System.Windows.Forms.ComboBox
	Private CategoriesComboBox As System.Windows.Forms.ComboBox
    Private WithEvents RemoveButton As System.Windows.Forms.Button
End Class
