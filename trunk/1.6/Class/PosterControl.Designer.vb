Imports Microsoft.VisualBasic
Imports System
Namespace ZGuideTVDotNetTvdb
    Partial Public Class PosterControl
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
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(PosterControl))
            Me.panelBackground = New System.Windows.Forms.Panel()
            Me.panelImage = New System.Windows.Forms.Panel()
            Me.panelForeground = New System.Windows.Forms.Panel()
            Me.pbLoadingScreen = New System.Windows.Forms.PictureBox()
            Me.panelLeft = New System.Windows.Forms.Panel()
            Me.panelRight = New System.Windows.Forms.Panel()
            Me.panelBackground.SuspendLayout()
            Me.panelImage.SuspendLayout()
            Me.panelForeground.SuspendLayout()
            CType(Me.pbLoadingScreen, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' panelBackground
            ' 
            Me.panelBackground.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.panelBackground.BackColor = System.Drawing.Color.Transparent
            Me.panelBackground.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.dvdbox_back
            Me.panelBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.panelBackground.Controls.Add(Me.panelImage)
            Me.panelBackground.Location = New System.Drawing.Point(0, 0)
            Me.panelBackground.Name = "panelBackground"
            Me.panelBackground.Size = New System.Drawing.Size(300, 400)
            Me.panelBackground.TabIndex = 2
            ' 
            ' panelImage
            ' 
            Me.panelImage.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.panelImage.BackColor = System.Drawing.Color.Transparent
            Me.panelImage.Controls.Add(Me.panelForeground)
            Me.panelImage.Location = New System.Drawing.Point(0, 0)
            Me.panelImage.Name = "panelImage"
            Me.panelImage.Size = New System.Drawing.Size(300, 400)
            Me.panelImage.TabIndex = 2
            ' 
            ' panelForeground
            ' 
            Me.panelForeground.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.panelForeground.BackColor = System.Drawing.Color.Transparent
            Me.panelForeground.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.dvdbox_front1
            Me.panelForeground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.panelForeground.Controls.Add(Me.pbLoadingScreen)
            Me.panelForeground.Controls.Add(Me.panelLeft)
            Me.panelForeground.Controls.Add(Me.panelRight)
            Me.panelForeground.Location = New System.Drawing.Point(0, 0)
            Me.panelForeground.Name = "panelForeground"
            Me.panelForeground.Size = New System.Drawing.Size(300, 400)
            Me.panelForeground.TabIndex = 0
            ' 
            ' pbLoadingScreen
            ' 
            Me.pbLoadingScreen.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.pbLoadingScreen.Image = (CType(resources.GetObject("pbLoadingScreen.Image"), System.Drawing.Image))
            Me.pbLoadingScreen.Location = New System.Drawing.Point(90, 119)
            Me.pbLoadingScreen.Name = "pbLoadingScreen"
            Me.pbLoadingScreen.Size = New System.Drawing.Size(154, 149)
            Me.pbLoadingScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pbLoadingScreen.TabIndex = 2
            Me.pbLoadingScreen.TabStop = False
            Me.pbLoadingScreen.Visible = False
            ' 
            ' panelLeft
            ' 
            Me.panelLeft.BackColor = System.Drawing.Color.Transparent
            Me.panelLeft.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.playback
            Me.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.panelLeft.Location = New System.Drawing.Point(0, 0)
            Me.panelLeft.Name = "panelLeft"
            Me.panelLeft.Size = New System.Drawing.Size(28, 28)
            Me.panelLeft.TabIndex = 0
            Me.panelLeft.Visible = False
            '	  Me.panelLeft.MouseClick += New System.Windows.Forms.MouseEventHandler(Me.panelLeft_MouseClick);
            '	  Me.panelLeft.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.panelLeft_MouseDown);
            '	  Me.panelLeft.MouseUp += New System.Windows.Forms.MouseEventHandler(Me.panelLeft_MouseUp);
            ' 
            ' panelRight
            ' 
            Me.panelRight.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.panelRight.BackColor = System.Drawing.Color.Transparent
            Me.panelRight.BackgroundImage = Global.ZGuideTV.My.Resources.Resources.play
            Me.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.panelRight.Location = New System.Drawing.Point(272, 0)
            Me.panelRight.Name = "panelRight"
            Me.panelRight.Size = New System.Drawing.Size(28, 28)
            Me.panelRight.TabIndex = 1
            Me.panelRight.Visible = False
            '	  Me.panelRight.MouseClick += New System.Windows.Forms.MouseEventHandler(Me.panelRight_MouseClick);
            '	  Me.panelRight.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.panelRight_MouseDown);
            '	  Me.panelRight.MouseUp += New System.Windows.Forms.MouseEventHandler(Me.panelRight_MouseUp);
            ' 
            ' PosterControl
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.panelBackground)
            Me.Name = "PosterControl"
            Me.Size = New System.Drawing.Size(300, 400)
            '	  Me.SizeChanged += New System.EventHandler(Me.PosterControl_SizeChanged);
            Me.panelBackground.ResumeLayout(False)
            Me.panelImage.ResumeLayout(False)
            Me.panelForeground.ResumeLayout(False)
            CType(Me.pbLoadingScreen, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private panelBackground As System.Windows.Forms.Panel
        Private panelForeground As System.Windows.Forms.Panel
        Private WithEvents panelLeft As System.Windows.Forms.Panel
        Private WithEvents panelRight As System.Windows.Forms.Panel
        Private panelImage As System.Windows.Forms.Panel
        Private pbLoadingScreen As System.Windows.Forms.PictureBox
    End Class
End Namespace
