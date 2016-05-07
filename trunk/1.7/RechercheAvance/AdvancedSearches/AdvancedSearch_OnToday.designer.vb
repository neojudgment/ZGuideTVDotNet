Partial Class AdvancedSearch_OnToday
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
        Me.label1.Size = New System.Drawing.Size(140, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Si la diffusion est aujourd'hui"
        '
        'AdvancedSearch_OnToday
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.label1)
        Me.Name = "AdvancedSearch_OnToday"
        Me.Size = New System.Drawing.Size(169, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
End Class
