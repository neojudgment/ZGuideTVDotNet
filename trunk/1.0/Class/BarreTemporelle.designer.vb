<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarreTemporelle
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btJourmoins = New ZGuideTV.calendrierpavé()
        Me.btHeuremoins = New ZGuideTV.calendrierpavé()
        Me.bt06h = New ZGuideTV.calendrierpavé()
        Me.bt09h = New ZGuideTV.calendrierpavé()
        Me.bt12h = New ZGuideTV.calendrierpavé()
        Me.bt15h = New ZGuideTV.calendrierpavé()
        Me.bt18h = New ZGuideTV.calendrierpavé()
        Me.bt20h = New ZGuideTV.calendrierpavé()
        Me.bt23h = New ZGuideTV.calendrierpavé()
        Me.btMaintenant = New ZGuideTV.calendrierpavé()
        Me.btHeureplus = New ZGuideTV.calendrierpavé()
        Me.btJourplus = New ZGuideTV.calendrierpavé()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 12
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.895706!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.28221!))
        Me.TableLayoutPanel1.Controls.Add(Me.btJourmoins, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btHeuremoins, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.bt06h, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.bt09h, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.bt12h, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.bt15h, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.bt18h, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.bt20h, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.bt23h, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btMaintenant, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btHeureplus, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btJourplus, 11, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(634, 32)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btJourmoins
        '
        Me.btJourmoins.Align = System.Drawing.StringAlignment.Center
        Me.btJourmoins.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btJourmoins.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btJourmoins.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btJourmoins.BordersColor = System.Drawing.Color.White
        Me.btJourmoins.ForeColor = System.Drawing.Color.White
        Me.btJourmoins.Location = New System.Drawing.Point(3, 3)
        Me.btJourmoins.Name = "btJourmoins"
        Me.btJourmoins.old_UI = True
        Me.btJourmoins.Size = New System.Drawing.Size(46, 26)
        Me.btJourmoins.TabIndex = 0
        Me.btJourmoins.TopColor = System.Drawing.Color.White
        '
        'btHeuremoins
        '
        Me.btHeuremoins.Align = System.Drawing.StringAlignment.Center
        Me.btHeuremoins.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btHeuremoins.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btHeuremoins.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btHeuremoins.BordersColor = System.Drawing.Color.White
        Me.btHeuremoins.ForeColor = System.Drawing.Color.White
        Me.btHeuremoins.Location = New System.Drawing.Point(55, 3)
        Me.btHeuremoins.Name = "btHeuremoins"
        Me.btHeuremoins.old_UI = True
        Me.btHeuremoins.Size = New System.Drawing.Size(46, 26)
        Me.btHeuremoins.TabIndex = 1
        Me.btHeuremoins.TopColor = System.Drawing.Color.White
        '
        'bt06h
        '
        Me.bt06h.Align = System.Drawing.StringAlignment.Center
        Me.bt06h.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt06h.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt06h.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt06h.BordersColor = System.Drawing.Color.White
        Me.bt06h.ForeColor = System.Drawing.Color.White
        Me.bt06h.Location = New System.Drawing.Point(107, 3)
        Me.bt06h.Name = "bt06h"
        Me.bt06h.old_UI = True
        Me.bt06h.Size = New System.Drawing.Size(46, 26)
        Me.bt06h.TabIndex = 2
        Me.bt06h.TopColor = System.Drawing.Color.White
        '
        'bt09h
        '
        Me.bt09h.Align = System.Drawing.StringAlignment.Center
        Me.bt09h.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt09h.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt09h.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt09h.BordersColor = System.Drawing.Color.White
        Me.bt09h.ForeColor = System.Drawing.Color.White
        Me.bt09h.Location = New System.Drawing.Point(159, 3)
        Me.bt09h.Name = "bt09h"
        Me.bt09h.old_UI = True
        Me.bt09h.Size = New System.Drawing.Size(46, 26)
        Me.bt09h.TabIndex = 3
        Me.bt09h.TopColor = System.Drawing.Color.White
        '
        'bt12h
        '
        Me.bt12h.Align = System.Drawing.StringAlignment.Center
        Me.bt12h.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt12h.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt12h.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt12h.BordersColor = System.Drawing.Color.White
        Me.bt12h.ForeColor = System.Drawing.Color.White
        Me.bt12h.Location = New System.Drawing.Point(211, 3)
        Me.bt12h.Name = "bt12h"
        Me.bt12h.old_UI = True
        Me.bt12h.Size = New System.Drawing.Size(46, 26)
        Me.bt12h.TabIndex = 4
        Me.bt12h.TopColor = System.Drawing.Color.White
        '
        'bt15h
        '
        Me.bt15h.Align = System.Drawing.StringAlignment.Center
        Me.bt15h.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt15h.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt15h.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt15h.BordersColor = System.Drawing.Color.White
        Me.bt15h.ForeColor = System.Drawing.Color.White
        Me.bt15h.Location = New System.Drawing.Point(263, 3)
        Me.bt15h.Name = "bt15h"
        Me.bt15h.old_UI = True
        Me.bt15h.Size = New System.Drawing.Size(46, 26)
        Me.bt15h.TabIndex = 5
        Me.bt15h.TopColor = System.Drawing.Color.White
        '
        'bt18h
        '
        Me.bt18h.Align = System.Drawing.StringAlignment.Center
        Me.bt18h.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt18h.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt18h.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt18h.BordersColor = System.Drawing.Color.White
        Me.bt18h.ForeColor = System.Drawing.Color.White
        Me.bt18h.Location = New System.Drawing.Point(315, 3)
        Me.bt18h.Name = "bt18h"
        Me.bt18h.old_UI = True
        Me.bt18h.Size = New System.Drawing.Size(46, 26)
        Me.bt18h.TabIndex = 6
        Me.bt18h.TopColor = System.Drawing.Color.White
        '
        'bt20h
        '
        Me.bt20h.Align = System.Drawing.StringAlignment.Center
        Me.bt20h.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt20h.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt20h.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt20h.BordersColor = System.Drawing.Color.White
        Me.bt20h.ForeColor = System.Drawing.Color.White
        Me.bt20h.Location = New System.Drawing.Point(367, 3)
        Me.bt20h.Name = "bt20h"
        Me.bt20h.old_UI = True
        Me.bt20h.Size = New System.Drawing.Size(46, 26)
        Me.bt20h.TabIndex = 7
        Me.bt20h.TopColor = System.Drawing.Color.White
        '
        'bt23h
        '
        Me.bt23h.Align = System.Drawing.StringAlignment.Center
        Me.bt23h.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt23h.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt23h.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.bt23h.BordersColor = System.Drawing.Color.White
        Me.bt23h.ForeColor = System.Drawing.Color.White
        Me.bt23h.Location = New System.Drawing.Point(419, 3)
        Me.bt23h.Name = "bt23h"
        Me.bt23h.old_UI = True
        Me.bt23h.Size = New System.Drawing.Size(46, 26)
        Me.bt23h.TabIndex = 8
        Me.bt23h.TopColor = System.Drawing.Color.White
        '
        'btMaintenant
        '
        Me.btMaintenant.Align = System.Drawing.StringAlignment.Center
        Me.btMaintenant.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btMaintenant.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.btMaintenant.BGColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.btMaintenant.BordersColor = System.Drawing.Color.White
        Me.btMaintenant.ForeColor = System.Drawing.Color.White
        Me.btMaintenant.Location = New System.Drawing.Point(471, 3)
        Me.btMaintenant.Name = "btMaintenant"
        Me.btMaintenant.old_UI = True
        Me.btMaintenant.Size = New System.Drawing.Size(50, 26)
        Me.btMaintenant.TabIndex = 9
        Me.btMaintenant.TopColor = System.Drawing.Color.White
        '
        'btHeureplus
        '
        Me.btHeureplus.Align = System.Drawing.StringAlignment.Center
        Me.btHeureplus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btHeureplus.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btHeureplus.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btHeureplus.BordersColor = System.Drawing.Color.White
        Me.btHeureplus.ForeColor = System.Drawing.Color.White
        Me.btHeureplus.Location = New System.Drawing.Point(527, 3)
        Me.btHeureplus.Name = "btHeureplus"
        Me.btHeureplus.old_UI = True
        Me.btHeureplus.Size = New System.Drawing.Size(46, 26)
        Me.btHeureplus.TabIndex = 10
        Me.btHeureplus.TopColor = System.Drawing.Color.White
        '
        'btJourplus
        '
        Me.btJourplus.Align = System.Drawing.StringAlignment.Center
        Me.btJourplus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btJourplus.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btJourplus.BGColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btJourplus.BordersColor = System.Drawing.Color.White
        Me.btJourplus.ForeColor = System.Drawing.Color.White
        Me.btJourplus.Location = New System.Drawing.Point(579, 3)
        Me.btJourplus.Name = "btJourplus"
        Me.btJourplus.old_UI = True
        Me.btJourplus.Size = New System.Drawing.Size(52, 26)
        Me.btJourplus.TabIndex = 11
        Me.btJourplus.TopColor = System.Drawing.Color.White
        '
        'BarreTemporelle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "BarreTemporelle"
        Me.Size = New System.Drawing.Size(634, 32)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btJourmoins As calendrierpavé
    Friend WithEvents btHeuremoins As calendrierpavé
    Friend WithEvents bt06h As calendrierpavé
    Friend WithEvents bt09h As calendrierpavé
    Friend WithEvents bt12h As calendrierpavé
    Friend WithEvents bt15h As calendrierpavé
    Friend WithEvents bt18h As calendrierpavé
    Friend WithEvents bt20h As calendrierpavé
    Friend WithEvents bt23h As calendrierpavé
    Friend WithEvents btMaintenant As calendrierpavé
    Friend WithEvents btHeureplus As calendrierpavé
    Friend WithEvents btJourplus As calendrierpavé

End Class
