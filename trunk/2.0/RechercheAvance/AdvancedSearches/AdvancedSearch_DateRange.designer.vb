Partial Class AdvancedSearch_DateRange
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
        Me.components = New System.ComponentModel.Container()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.ConditionsComboBox = New System.Windows.Forms.ComboBox()
        Me.MinDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.label2 = New System.Windows.Forms.Label()
        Me.MaxDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(0, 0)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(22, 22)
        Me.RemoveButton.TabIndex = 7
        Me.RemoveButton.Text = "X"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 5)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Si la date"
        '
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"est compris entre", "n'est pas compris entre"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(74, 1)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 8
        '
        'MinDateTimePicker
        '
        Me.MinDateTimePicker.Location = New System.Drawing.Point(201, 1)
        Me.MinDateTimePicker.Name = "MinDateTimePicker"
        Me.MinDateTimePicker.Size = New System.Drawing.Size(183, 20)
        Me.MinDateTimePicker.TabIndex = 9
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(390, 4)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(27, 13)
        Me.label2.TabIndex = 10
        Me.label2.Text = "et le"
        '
        'MaxDateTimePicker
        '
        Me.MaxDateTimePicker.Location = New System.Drawing.Point(423, 1)
        Me.MaxDateTimePicker.Name = "MaxDateTimePicker"
        Me.MaxDateTimePicker.Size = New System.Drawing.Size(184, 20)
        Me.MaxDateTimePicker.TabIndex = 11
        '
        'errorProvider1
        '
        Me.errorProvider1.ContainerControl = Me
        '
        'AdvancedSearch_DateRange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MaxDateTimePicker)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.MinDateTimePicker)
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_DateRange"
        Me.Size = New System.Drawing.Size(609, 23)
        CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private ConditionsComboBox As System.Windows.Forms.ComboBox
    Private WithEvents MinDateTimePicker As System.Windows.Forms.DateTimePicker
    Private label2 As System.Windows.Forms.Label
    Private WithEvents MaxDateTimePicker As System.Windows.Forms.DateTimePicker
    Private errorProvider1 As System.Windows.Forms.ErrorProvider
End Class
