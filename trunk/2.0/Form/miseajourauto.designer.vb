<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiseAJourAuto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MiseAJourAuto))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.MiseAJourAuto_Weight = New System.Windows.Forms.Label()
        Me.MiseAJourProgress = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.autoupdate_title = New System.Windows.Forms.Label()
        Me.MiseajourAuto_estimated = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(52, 116)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(362, 20)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 1
        '
        'MiseAJourAuto_Weight
        '
        Me.MiseAJourAuto_Weight.AutoSize = True
        Me.MiseAJourAuto_Weight.Location = New System.Drawing.Point(47, 46)
        Me.MiseAJourAuto_Weight.Name = "MiseAJourAuto_Weight"
        Me.MiseAJourAuto_Weight.Size = New System.Drawing.Size(87, 13)
        Me.MiseAJourAuto_Weight.TabIndex = 2
        Me.MiseAJourAuto_Weight.Text = "Taille du fichier : "
        '
        'MiseAJourProgress
        '
        Me.MiseAJourProgress.AutoSize = True
        Me.MiseAJourProgress.Location = New System.Drawing.Point(47, 101)
        Me.MiseAJourProgress.Name = "MiseAJourProgress"
        Me.MiseAJourProgress.Size = New System.Drawing.Size(71, 13)
        Me.MiseAJourProgress.TabIndex = 5
        Me.MiseAJourProgress.Text = "Progression : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 6
        '
        'autoupdate_title
        '
        Me.autoupdate_title.AutoSize = True
        Me.autoupdate_title.Location = New System.Drawing.Point(47, 24)
        Me.autoupdate_title.Name = "autoupdate_title"
        Me.autoupdate_title.Size = New System.Drawing.Size(103, 13)
        Me.autoupdate_title.TabIndex = 7
        Me.autoupdate_title.Text = "Opération en cours :"
        '
        'MiseajourAuto_estimated
        '
        Me.MiseajourAuto_estimated.AutoSize = True
        Me.MiseajourAuto_estimated.Location = New System.Drawing.Point(47, 68)
        Me.MiseajourAuto_estimated.Name = "MiseajourAuto_estimated"
        Me.MiseajourAuto_estimated.Size = New System.Drawing.Size(108, 13)
        Me.MiseajourAuto_estimated.TabIndex = 8
        Me.MiseajourAuto_estimated.Text = "Temps restant Estimé"
        '
        'MiseAJourAuto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(460, 152)
        Me.Controls.Add(Me.MiseajourAuto_estimated)
        Me.Controls.Add(Me.autoupdate_title)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MiseAJourProgress)
        Me.Controls.Add(Me.MiseAJourAuto_Weight)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MiseAJourAuto"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZGuideTV.NET - Mise à jour automatique"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents MiseAJourAuto_Weight As System.Windows.Forms.Label
    Friend WithEvents MiseAJourProgress As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents autoupdate_title As System.Windows.Forms.Label
    Friend WithEvents MiseajourAuto_estimated As System.Windows.Forms.Label
End Class
