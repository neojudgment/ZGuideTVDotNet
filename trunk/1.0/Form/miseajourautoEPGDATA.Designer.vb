<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class miseajourautoEPGDATA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(miseajourautoEPGDATA))
        Me.tbInfo = New System.Windows.Forms.TextBox()
        Me.autoupdate_title = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbInfo
        '
        Me.tbInfo.Location = New System.Drawing.Point(12, 34)
        Me.tbInfo.Multiline = True
        Me.tbInfo.Name = "tbInfo"
        Me.tbInfo.Size = New System.Drawing.Size(242, 141)
        Me.tbInfo.TabIndex = 27
        '
        'autoupdate_title
        '
        Me.autoupdate_title.AutoSize = True
        Me.autoupdate_title.Location = New System.Drawing.Point(12, 9)
        Me.autoupdate_title.Name = "autoupdate_title"
        Me.autoupdate_title.Size = New System.Drawing.Size(103, 13)
        Me.autoupdate_title.TabIndex = 28
        Me.autoupdate_title.Text = "Opération en cours :"
        '
        'miseajourautoEPGDATA
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(267, 189)
        Me.Controls.Add(Me.autoupdate_title)
        Me.Controls.Add(Me.tbInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "miseajourautoEPGDATA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Mise à jour automatique"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbInfo As System.Windows.Forms.TextBox
    Friend WithEvents autoupdate_title As System.Windows.Forms.Label
End Class
