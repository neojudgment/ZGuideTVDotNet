Partial Class AdvancedSearch_DayOfWeek
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
        Me.CriteriaComboBox = New System.Windows.Forms.ComboBox()
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
        'ConditionsComboBox
        '
        Me.ConditionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConditionsComboBox.FormattingEnabled = True
        Me.ConditionsComboBox.Items.AddRange(New Object() {"est égal à", "n'est pas égal à"})
        Me.ConditionsComboBox.Location = New System.Drawing.Point(145, 0)
        Me.ConditionsComboBox.Name = "ConditionsComboBox"
        Me.ConditionsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ConditionsComboBox.TabIndex = 7
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 5)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(115, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Si le jour de la semaine"
        '
        'CriteriaComboBox
        '
        Me.CriteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CriteriaComboBox.FormattingEnabled = True
        Me.CriteriaComboBox.Items.AddRange(New Object() {"Dimanche", "Lundi", "Mardi", "Mercredi", "Jeud", "Vendredi", "Samedi"})
        Me.CriteriaComboBox.Location = New System.Drawing.Point(272, 0)
        Me.CriteriaComboBox.Name = "CriteriaComboBox"
        Me.CriteriaComboBox.Size = New System.Drawing.Size(121, 21)
        Me.CriteriaComboBox.TabIndex = 9
        '
        'AdvancedSearch_DayOfWeek
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CriteriaComboBox)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.ConditionsComboBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_DayOfWeek"
        Me.Size = New System.Drawing.Size(399, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private ConditionsComboBox As System.Windows.Forms.ComboBox
    Private label1 As System.Windows.Forms.Label
    Private CriteriaComboBox As System.Windows.Forms.ComboBox
End Class
