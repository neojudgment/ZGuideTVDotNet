Partial Class AdvancedSearch_TimeProximity
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
        Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.UnitsOfTimeComboBox = New System.Windows.Forms.ComboBox()
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.label1.Size = New System.Drawing.Size(100, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Si le début est dans"
        '
        'numericUpDown1
        '
        Me.numericUpDown1.Location = New System.Drawing.Point(178, 3)
        Me.numericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericUpDown1.Name = "numericUpDown1"
        Me.numericUpDown1.Size = New System.Drawing.Size(47, 20)
        Me.numericUpDown1.TabIndex = 8
        Me.numericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'UnitsOfTimeComboBox
        '
        Me.UnitsOfTimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UnitsOfTimeComboBox.FormattingEnabled = True
        Me.UnitsOfTimeComboBox.Items.AddRange(New Object() {"minutes", "heures", "jours"})
        Me.UnitsOfTimeComboBox.Location = New System.Drawing.Point(230, 2)
        Me.UnitsOfTimeComboBox.Name = "UnitsOfTimeComboBox"
        Me.UnitsOfTimeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.UnitsOfTimeComboBox.TabIndex = 9
        '
        'AdvancedSearch_TimeProximity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UnitsOfTimeComboBox)
        Me.Controls.Add(Me.numericUpDown1)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_TimeProximity"
        Me.Size = New System.Drawing.Size(354, 25)
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private numericUpDown1 As System.Windows.Forms.NumericUpDown
    Private UnitsOfTimeComboBox As System.Windows.Forms.ComboBox
End Class
