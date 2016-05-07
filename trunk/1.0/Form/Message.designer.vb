<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Message
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Message))
        Me.TextBox = New System.Windows.Forms.RichTextBox()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonAnnuler = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonCopier = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox
        '
        Me.TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.TextBox, "TextBox")
        Me.TextBox.Name = "TextBox"
        Me.TextBox.ReadOnly = True
        '
        'ButtonOk
        '
        Me.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        resources.ApplyResources(Me.ButtonOk, "ButtonOk")
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnuler
        '
        Me.ButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Abort
        resources.ApplyResources(Me.ButtonAnnuler, "ButtonAnnuler")
        Me.ButtonAnnuler.Name = "ButtonAnnuler"
        Me.ButtonAnnuler.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'ButtonCopier
        '
        Me.ButtonCopier.DialogResult = System.Windows.Forms.DialogResult.Abort
        resources.ApplyResources(Me.ButtonCopier, "ButtonCopier")
        Me.ButtonCopier.Name = "ButtonCopier"
        Me.ButtonCopier.UseVisualStyleBackColor = True
        '
        'Message
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dial
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.TextBox)
        Me.Controls.Add(Me.ButtonCopier)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonAnnuler)
        Me.Controls.Add(Me.ButtonOk)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Message"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnuler As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonCopier As System.Windows.Forms.Button
End Class
