Partial Class TvTreeViewEx
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
        Me.components = New System.ComponentModel.Container()
        Me.treeView1 = New System.Windows.Forms.TreeView()
        Me.SavedSearchesContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.deleteSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.editSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.renameSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SavedSearchesContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'treeView1
        '
        Me.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeView1.FullRowSelect = True
        Me.treeView1.HideSelection = False
        Me.treeView1.Location = New System.Drawing.Point(0, 0)
        Me.treeView1.Name = "treeView1"
        Me.treeView1.ShowNodeToolTips = True
        Me.treeView1.Size = New System.Drawing.Size(300, 300)
        Me.treeView1.TabIndex = 0
        '
        'SavedSearchesContextMenu
        '
        Me.SavedSearchesContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.deleteSearchToolStripMenuItem, Me.editSearchToolStripMenuItem, Me.renameSearchToolStripMenuItem})
        Me.SavedSearchesContextMenu.Name = "SavedSearchesContextMenu"
        Me.SavedSearchesContextMenu.Size = New System.Drawing.Size(134, 70)
        '
        'deleteSearchToolStripMenuItem
        '
        Me.deleteSearchToolStripMenuItem.Name = "deleteSearchToolStripMenuItem"
        Me.deleteSearchToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.deleteSearchToolStripMenuItem.Text = "Supprimer"
        '
        'editSearchToolStripMenuItem
        '
        Me.editSearchToolStripMenuItem.Name = "editSearchToolStripMenuItem"
        Me.editSearchToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.editSearchToolStripMenuItem.Text = "Editer"
        '
        'renameSearchToolStripMenuItem
        '
        Me.renameSearchToolStripMenuItem.Name = "renameSearchToolStripMenuItem"
        Me.renameSearchToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.renameSearchToolStripMenuItem.Text = "Renommer"
        '
        'TVTreeViewEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.treeView1)
        Me.Name = "TVTreeViewEx"
        Me.Size = New System.Drawing.Size(300, 300)
        Me.SavedSearchesContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents treeView1 As System.Windows.Forms.TreeView
    Public WithEvents SavedSearchesContextMenu As System.Windows.Forms.ContextMenuStrip
    Public WithEvents deleteSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents editSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents renameSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
