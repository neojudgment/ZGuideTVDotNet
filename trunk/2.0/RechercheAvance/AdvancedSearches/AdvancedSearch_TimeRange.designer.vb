Partial Class AdvancedSearch_TimeRange
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
        Me.label1 = New System.Windows.Forms.Label()
        Me.FieldsComboBox = New System.Windows.Forms.ComboBox()
        Me.ConditionsComboBox = New System.Windows.Forms.ComboBox()
        Me.MinTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.label2 = New System.Windows.Forms.Label()
        Me.MaxTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(0, 0)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(22, 22)
        Me.RemoveButton.TabIndex = 8
        Me.RemoveButton.Text = "X"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 5)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(16, 13)
        Me.label1.TabIndex = 7
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
        Me.FieldsComboBox.TabIndex = 9
        '
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"est compris entre", "n'est pas compris entre"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(168, 0)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 10
        '
        'MinTimePicker
        '
        Me.MinTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.MinTimePicker.Location = New System.Drawing.Point(300, 1)
        Me.MinTimePicker.Name = "MinTimePicker"
        Me.MinTimePicker.ShowUpDown = True
        Me.MinTimePicker.Size = New System.Drawing.Size(121, 20)
        Me.MinTimePicker.TabIndex = 11
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(427, 5)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(16, 13)
        Me.label2.TabIndex = 12
        Me.label2.Text = "et"
        '
        'MaxTimePicker
        '
        Me.MaxTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.MaxTimePicker.Location = New System.Drawing.Point(459, 1)
        Me.MaxTimePicker.Name = "MaxTimePicker"
        Me.MaxTimePicker.ShowUpDown = True
        Me.MaxTimePicker.Size = New System.Drawing.Size(121, 20)
        Me.MaxTimePicker.TabIndex = 13
        '
        'AdvancedSearch_TimeRange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MaxTimePicker)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.MinTimePicker)
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.FieldsComboBox)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_TimeRange"
        Me.Size = New System.Drawing.Size(618, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private FieldsComboBox As System.Windows.Forms.ComboBox
    Private ConditionsComboBox As System.Windows.Forms.ComboBox
    Private WithEvents MinTimePicker As System.Windows.Forms.DateTimePicker
    Private label2 As System.Windows.Forms.Label
    Private WithEvents MaxTimePicker As System.Windows.Forms.DateTimePicker
End Class
