Partial Class AdvancedSearch_Time
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
        Me.FieldsComboBox = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.TimeCriteriaDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(0, 0)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(22, 22)
        Me.RemoveButton.TabIndex = 10
        Me.RemoveButton.Text = "X"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"est égal à", "est avant le", "est après le"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(168, 0)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 9
        '
        'FieldsComboBox
        '
        Me.FieldsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FieldsComboBox.FormattingEnabled = True
        Me.FieldsComboBox.Items.AddRange(New Object() {"le début", "la fin"})
        Me.FieldsComboBox.Location = New System.Drawing.Point(43, 0)
        Me.FieldsComboBox.Name = "FieldsComboBox"
        Me.FieldsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.FieldsComboBox.TabIndex = 8
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 4)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(16, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Si"
        '
        'TimeCriteriaDateTimePicker
        '
        Me.TimeCriteriaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimeCriteriaDateTimePicker.Location = New System.Drawing.Point(294, 0)
        Me.TimeCriteriaDateTimePicker.Name = "TimeCriteriaDateTimePicker"
        Me.TimeCriteriaDateTimePicker.ShowUpDown = True
        Me.TimeCriteriaDateTimePicker.Size = New System.Drawing.Size(132, 20)
        Me.TimeCriteriaDateTimePicker.TabIndex = 11
        '
        'AdvancedSearch_Time
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TimeCriteriaDateTimePicker)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.FieldsComboBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_Time"
        Me.Size = New System.Drawing.Size(430, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private ConditionsComboBox As System.Windows.Forms.ComboBox
    Private FieldsComboBox As System.Windows.Forms.ComboBox
    Private label1 As System.Windows.Forms.Label
    Private TimeCriteriaDateTimePicker As System.Windows.Forms.DateTimePicker
End Class
