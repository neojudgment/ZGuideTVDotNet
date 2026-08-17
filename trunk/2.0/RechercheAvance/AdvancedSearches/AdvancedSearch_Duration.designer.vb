Partial Class AdvancedSearch_Duration
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
        Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.UnitsOfTimeComboBox = New System.Windows.Forms.ComboBox()
        Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UnitsOfTimeComboBox2 = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ConditionsComboBox = New System.Windows.Forms.ComboBox()
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.label1.Size = New System.Drawing.Size(74, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Si la duree est"
        '
        'numericUpDown1
        '
        Me.numericUpDown1.Location = New System.Drawing.Point(233, 3)
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
        Me.UnitsOfTimeComboBox.Items.AddRange(New Object() {"minutes", "heures"})
        Me.UnitsOfTimeComboBox.Location = New System.Drawing.Point(286, 2)
        Me.UnitsOfTimeComboBox.Name = "UnitsOfTimeComboBox"
        Me.UnitsOfTimeComboBox.Size = New System.Drawing.Size(115, 21)
        Me.UnitsOfTimeComboBox.TabIndex = 9
        '
        'errorProvider1
        '
        Me.errorProvider1.ContainerControl = Me
        '
        'UnitsOfTimeComboBox2
        '
        Me.UnitsOfTimeComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UnitsOfTimeComboBox2.FormattingEnabled = True
        Me.UnitsOfTimeComboBox2.Items.AddRange(New Object() {"minutes", "heures"})
        Me.UnitsOfTimeComboBox2.Location = New System.Drawing.Point(499, 2)
        Me.UnitsOfTimeComboBox2.Name = "UnitsOfTimeComboBox2"
        Me.UnitsOfTimeComboBox2.Size = New System.Drawing.Size(115, 21)
        Me.UnitsOfTimeComboBox2.TabIndex = 11
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(446, 3)
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(47, 20)
        Me.NumericUpDown2.TabIndex = 10
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(413, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "et"
        '
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"égale à", "supérieur à", "inférieur à", "compris entre"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(104, 2)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 13
        '
        'AdvancedSearch_Duration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.UnitsOfTimeComboBox2)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.UnitsOfTimeComboBox)
        Me.Controls.Add(Me.numericUpDown1)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_Duration"
        Me.Size = New System.Drawing.Size(619, 25)
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private WithEvents numericUpDown1 As System.Windows.Forms.NumericUpDown
    Private UnitsOfTimeComboBox As System.Windows.Forms.ComboBox
    Private WithEvents errorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ConditionsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents UnitsOfTimeComboBox2 As System.Windows.Forms.ComboBox
    Private WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
End Class
