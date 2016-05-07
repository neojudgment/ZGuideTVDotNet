<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectLanguage
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectLanguage))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.comboboxSLanguages = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOK, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 85)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(314, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonOK.Location = New System.Drawing.Point(45, 3)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(67, 23)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(202, 3)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(67, 23)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'comboboxSLanguages
        '
        Me.comboboxSLanguages.DisplayMember = "hkhkjhk"
        Me.comboboxSLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxSLanguages.FormattingEnabled = True
        Me.comboboxSLanguages.Location = New System.Drawing.Point(34, 47)
        Me.comboboxSLanguages.Name = "comboboxSLanguages"
        Me.comboboxSLanguages.Size = New System.Drawing.Size(267, 21)
        Me.comboboxSLanguages.TabIndex = 1
        Me.comboboxSLanguages.Tag = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(35, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Langue / Language / Sprache / Lenguaje / Язык"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SelectLanguage
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(338, 126)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboboxSLanguages)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectLanguage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents comboboxSLanguages As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
