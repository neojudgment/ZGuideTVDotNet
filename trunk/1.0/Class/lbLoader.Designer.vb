<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lbLoader
    Inherits System.Windows.Forms.Panel

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                If Not titi Is Nothing Then titi.Dispose()

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
        Me.SuspendLayout()
        '
        'lbLoader
        '
        Me.Name = "lbLoader"
        Me.Size = New System.Drawing.Size(507, 49)
        Me.ResumeLayout(False)

    End Sub

End Class
