<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ZGuideTvDotNetUpdate
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.ProgBar = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(8, 36)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(272, 16)
        Me.lblProgress.TabIndex = 12
        Me.lblProgress.Text = "#Progression"
        '
        'ProgBar
        '
        Me.ProgBar.Location = New System.Drawing.Point(8, 12)
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(376, 16)
        Me.ProgBar.TabIndex = 9
        '
        'Timer1
        '
        '
        'ZGuideTvDotNetUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(392, 56)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.ProgBar)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ZGuideTvDotNetUpdate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Récupération de la mise à jour"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblProgress As Label
    Friend WithEvents ProgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As Timer
End Class
