Imports Microsoft.VisualBasic
Imports System
Namespace ZGuideTVDotNetTvdb
    Partial Public Class CoverFlow
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
            Me.pnlThumbOverview = New System.Windows.Forms.Panel
            Me.pb0 = New System.Windows.Forms.PictureBox
            Me.pb1 = New System.Windows.Forms.PictureBox
            Me.pb2 = New System.Windows.Forms.PictureBox
            Me.pb3 = New System.Windows.Forms.PictureBox
            Me.pb4 = New System.Windows.Forms.PictureBox
            Me.pb5 = New System.Windows.Forms.PictureBox
            Me.pb6 = New System.Windows.Forms.PictureBox
            Me.pbFull = New System.Windows.Forms.PictureBox
            Me.panelImageFrame = New System.Windows.Forms.Panel
            Me.pnlThumbOverview.SuspendLayout()
            CType(Me.pb0, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pb3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pb4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pb5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pb6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pbFull, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelImageFrame.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlThumbOverview
            '
            Me.pnlThumbOverview.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlThumbOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.pnlThumbOverview.Controls.Add(Me.pb0)
            Me.pnlThumbOverview.Controls.Add(Me.pb1)
            Me.pnlThumbOverview.Controls.Add(Me.pb2)
            Me.pnlThumbOverview.Controls.Add(Me.pb3)
            Me.pnlThumbOverview.Controls.Add(Me.pb4)
            Me.pnlThumbOverview.Controls.Add(Me.pb5)
            Me.pnlThumbOverview.Controls.Add(Me.pb6)
            Me.pnlThumbOverview.Location = New System.Drawing.Point(3, 3)
            Me.pnlThumbOverview.Name = "pnlThumbOverview"
            Me.pnlThumbOverview.Size = New System.Drawing.Size(880, 213)
            Me.pnlThumbOverview.TabIndex = 2
            '
            'pb0
            '
            Me.pb0.BackColor = System.Drawing.Color.Transparent
            Me.pb0.Location = New System.Drawing.Point(11, 81)
            Me.pb0.Name = "pb0"
            Me.pb0.Size = New System.Drawing.Size(55, 50)
            Me.pb0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb0.TabIndex = 0
            Me.pb0.TabStop = False
            '
            'pb1
            '
            Me.pb1.BackColor = System.Drawing.Color.Transparent
            Me.pb1.Location = New System.Drawing.Point(66, 53)
            Me.pb1.Name = "pb1"
            Me.pb1.Size = New System.Drawing.Size(105, 100)
            Me.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb1.TabIndex = 0
            Me.pb1.TabStop = False
            '
            'pb2
            '
            Me.pb2.BackColor = System.Drawing.Color.Transparent
            Me.pb2.Location = New System.Drawing.Point(171, 29)
            Me.pb2.Name = "pb2"
            Me.pb2.Size = New System.Drawing.Size(155, 150)
            Me.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb2.TabIndex = 0
            Me.pb2.TabStop = False
            '
            'pb3
            '
            Me.pb3.BackColor = System.Drawing.Color.Transparent
            Me.pb3.Location = New System.Drawing.Point(327, 14)
            Me.pb3.Name = "pb3"
            Me.pb3.Size = New System.Drawing.Size(221, 178)
            Me.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb3.TabIndex = 0
            Me.pb3.TabStop = False
            '
            'pb4
            '
            Me.pb4.BackColor = System.Drawing.Color.Transparent
            Me.pb4.Location = New System.Drawing.Point(549, 29)
            Me.pb4.Name = "pb4"
            Me.pb4.Size = New System.Drawing.Size(155, 150)
            Me.pb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb4.TabIndex = 0
            Me.pb4.TabStop = False
            '
            'pb5
            '
            Me.pb5.BackColor = System.Drawing.Color.Transparent
            Me.pb5.Location = New System.Drawing.Point(705, 53)
            Me.pb5.Name = "pb5"
            Me.pb5.Size = New System.Drawing.Size(105, 100)
            Me.pb5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb5.TabIndex = 0
            Me.pb5.TabStop = False
            '
            'pb6
            '
            Me.pb6.BackColor = System.Drawing.Color.Transparent
            Me.pb6.Location = New System.Drawing.Point(811, 78)
            Me.pb6.Name = "pb6"
            Me.pb6.Size = New System.Drawing.Size(55, 50)
            Me.pb6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb6.TabIndex = 0
            Me.pb6.TabStop = False
            '
            'pbFull
            '
            Me.pbFull.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pbFull.BackColor = System.Drawing.Color.Black
            Me.pbFull.Location = New System.Drawing.Point(2, 3)
            Me.pbFull.Name = "pbFull"
            Me.pbFull.Size = New System.Drawing.Size(875, 498)
            Me.pbFull.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pbFull.TabIndex = 1
            Me.pbFull.TabStop = False
            '
            'panelImageFrame
            '
            Me.panelImageFrame.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.panelImageFrame.BackColor = System.Drawing.Color.Black
            Me.panelImageFrame.Controls.Add(Me.pbFull)
            Me.panelImageFrame.Location = New System.Drawing.Point(3, 222)
            Me.panelImageFrame.Name = "panelImageFrame"
            Me.panelImageFrame.Size = New System.Drawing.Size(880, 504)
            Me.panelImageFrame.TabIndex = 3
            '
            'CoverFlow
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.Controls.Add(Me.panelImageFrame)
            Me.Controls.Add(Me.pnlThumbOverview)
            Me.Name = "CoverFlow"
            Me.Size = New System.Drawing.Size(886, 729)
            Me.pnlThumbOverview.ResumeLayout(False)
            CType(Me.pb0, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pb3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pb4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pb5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pb6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pbFull, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelImageFrame.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private WithEvents pb1 As System.Windows.Forms.PictureBox
        Private WithEvents pb2 As System.Windows.Forms.PictureBox
        Private WithEvents pb3 As System.Windows.Forms.PictureBox
        Private WithEvents pb4 As System.Windows.Forms.PictureBox
        Private WithEvents pb5 As System.Windows.Forms.PictureBox
        Private WithEvents pb6 As System.Windows.Forms.PictureBox
        Private WithEvents pb0 As System.Windows.Forms.PictureBox
        Private pbFull As System.Windows.Forms.PictureBox
        Private WithEvents pnlThumbOverview As System.Windows.Forms.Panel
        Private panelImageFrame As System.Windows.Forms.Panel

    End Class
End Namespace
