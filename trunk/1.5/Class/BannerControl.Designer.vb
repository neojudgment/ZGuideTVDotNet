Imports Microsoft.VisualBasic
Imports System
Namespace ZGuideTVDotNetTvdb
    Partial Public Class BannerControl
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
                If Not _mDefaultImage Is Nothing Then _mDefaultImage.Dispose()


                If Not _mUnavailableImage Is Nothing Then _mUnavailableImage.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.cmdLeft = New System.Windows.Forms.Panel
            Me.cmdRight = New System.Windows.Forms.Panel
            Me.panelImage = New System.Windows.Forms.Panel
            Me.pbLoading = New System.Windows.Forms.PictureBox
            Me.panelImage.SuspendLayout()
            CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cmdLeft
            '
            Me.cmdLeft.BackColor = System.Drawing.Color.Transparent
            Me.cmdLeft.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.first
            Me.cmdLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.cmdLeft.Location = New System.Drawing.Point(0, 0)
            Me.cmdLeft.Name = "cmdLeft"
            Me.cmdLeft.Size = New System.Drawing.Size(22, 22)
            Me.cmdLeft.TabIndex = 0
            Me.cmdLeft.Visible = False
            '
            'cmdRight
            '
            Me.cmdRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmdRight.BackColor = System.Drawing.Color.Transparent
            Me.cmdRight.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.last
            Me.cmdRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.cmdRight.Location = New System.Drawing.Point(693, 0)
            Me.cmdRight.Name = "cmdRight"
            Me.cmdRight.Size = New System.Drawing.Size(22, 22)
            Me.cmdRight.TabIndex = 0
            Me.cmdRight.Visible = False
            '
            'panelImage
            '
            Me.panelImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.panelImage.Controls.Add(Me.cmdLeft)
            Me.panelImage.Controls.Add(Me.cmdRight)
            Me.panelImage.Controls.Add(Me.pbLoading)
            Me.panelImage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panelImage.Location = New System.Drawing.Point(0, 0)
            Me.panelImage.Name = "panelImage"
            Me.panelImage.Size = New System.Drawing.Size(715, 145)
            Me.panelImage.TabIndex = 1
            '
            'pbLoading
            '
            Me.pbLoading.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pbLoading.BackColor = System.Drawing.Color.Transparent
            Me.pbLoading.Location = New System.Drawing.Point(247, 26)
            Me.pbLoading.Name = "pbLoading"
            Me.pbLoading.Size = New System.Drawing.Size(231, 89)
            Me.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.pbLoading.TabIndex = 0
            Me.pbLoading.TabStop = False
            Me.pbLoading.Visible = False
            '
            'BannerControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.panelImage)
            Me.Name = "BannerControl"
            Me.Size = New System.Drawing.Size(715, 145)
            Me.panelImage.ResumeLayout(False)
            CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private WithEvents cmdLeft As System.Windows.Forms.Panel
        Private WithEvents cmdRight As System.Windows.Forms.Panel
        Private WithEvents panelImage As System.Windows.Forms.Panel
        Private pbLoading As System.Windows.Forms.PictureBox

    End Class
End Namespace
