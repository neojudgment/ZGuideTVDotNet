Partial Class AdvancedSearch_OrCondition
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
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.InsertCriteriaButton = New System.Windows.Forms.Button()
        Me.SearchCriteriaComboBox = New System.Windows.Forms.ComboBox()
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.groupBox1.SuspendLayout()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.tableLayoutPanel1)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 0)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(638, 203)
        Me.groupBox1.TabIndex = 8
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Condition OU"
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.AutoSize = True
        Me.tableLayoutPanel1.ColumnCount = 3
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tableLayoutPanel1.Controls.Add(Me.RemoveButton, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.InsertCriteriaButton, 2, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.SearchCriteriaComboBox, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.flowLayoutPanel1, 2, 1)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 2
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(632, 184)
        Me.tableLayoutPanel1.TabIndex = 12
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(3, 3)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(26, 22)
        Me.RemoveButton.TabIndex = 14
        Me.RemoveButton.Text = "X"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'InsertCriteriaButton
        '
        Me.InsertCriteriaButton.Location = New System.Drawing.Point(190, 3)
        Me.InsertCriteriaButton.Name = "InsertCriteriaButton"
        Me.InsertCriteriaButton.Size = New System.Drawing.Size(75, 23)
        Me.InsertCriteriaButton.TabIndex = 15
        Me.InsertCriteriaButton.Text = "Insérer"
        Me.InsertCriteriaButton.UseVisualStyleBackColor = True
        '
        'SearchCriteriaComboBox
        '
        Me.SearchCriteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SearchCriteriaComboBox.FormattingEnabled = True
        Me.SearchCriteriaComboBox.Items.AddRange(New Object() {"Par champs texte", "Par catégorie", "Par chaine", "Par date", "Par heure", "Par durée", "Par Jour de la semaine", "Par plage de jour", "Par plage d'heure", "Est aujourd'hui", "Est en cours", "Par proximité de temp"})
        Me.SearchCriteriaComboBox.Location = New System.Drawing.Point(35, 3)
        Me.SearchCriteriaComboBox.Name = "SearchCriteriaComboBox"
        Me.SearchCriteriaComboBox.Size = New System.Drawing.Size(149, 21)
        Me.SearchCriteriaComboBox.TabIndex = 16
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.AutoScroll = True
        Me.flowLayoutPanel1.AutoSize = True
        Me.tableLayoutPanel1.SetColumnSpan(Me.flowLayoutPanel1, 3)
        Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(3, 32)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(626, 149)
        Me.flowLayoutPanel1.TabIndex = 17
        '
        'AdvancedSearch_OrCondition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "AdvancedSearch_OrCondition"
        Me.Size = New System.Drawing.Size(638, 203)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private groupBox1 As System.Windows.Forms.GroupBox
    Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private WithEvents InsertCriteriaButton As System.Windows.Forms.Button
    Private WithEvents SearchCriteriaComboBox As System.Windows.Forms.ComboBox
    Private flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel

End Class
