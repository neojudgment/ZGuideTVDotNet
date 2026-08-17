Partial Class AdvancedSearch_TextFields
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
        Me.label1 = New System.Windows.Forms.Label()
        Me.FieldsComboBox = New System.Windows.Forms.ComboBox()
        Me.ConditionsComboBox = New System.Windows.Forms.ComboBox()
        Me.CriteriaTextBox = New System.Windows.Forms.TextBox()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 3)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(16, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Si"
        '
        'FieldsComboBox
        '
        Me.FieldsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FieldsComboBox.FormattingEnabled = True
        Me.FieldsComboBox.Items.AddRange(New Object() {"le titre", "le soustitre", "la description"})
        Me.FieldsComboBox.Location = New System.Drawing.Point(42, 0)
        Me.FieldsComboBox.Name = "FieldsComboBox"
        Me.FieldsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.FieldsComboBox.TabIndex = 1
        '
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"contient", "ne contient pas"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(168, 0)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 2
        '
        'CriteriaTextBox
        '
        Me.CriteriaTextBox.Location = New System.Drawing.Point(295, 1)
        Me.CriteriaTextBox.Name = "CriteriaTextBox"
        Me.CriteriaTextBox.Size = New System.Drawing.Size(183, 20)
        Me.CriteriaTextBox.TabIndex = 3
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(0, 0)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(22, 22)
        Me.RemoveButton.TabIndex = 4
        Me.RemoveButton.Text = "X"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'errorProvider1
        '
        Me.errorProvider1.ContainerControl = Me
        '
        'AdvancedSearch_TextFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.CriteriaTextBox)
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.FieldsComboBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_TextFields"
        Me.Size = New System.Drawing.Size(511, 23)
        CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private label1 As System.Windows.Forms.Label
    Private FieldsComboBox As System.Windows.Forms.ComboBox
    Private ConditionsComboBox As System.Windows.Forms.ComboBox
    Private WithEvents CriteriaTextBox As System.Windows.Forms.TextBox
    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private errorProvider1 As System.Windows.Forms.ErrorProvider
End Class
