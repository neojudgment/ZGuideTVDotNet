' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2012 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
' |                                                                                                            |
' |    Project administrator : Pascal Hubert (neojudgment@hotmail.com)                                         |
' |                                                                                                            |
' |    This program is free software: you can redistribute it and/or modify                                    |
' |    it under the terms of the GNU General Public License as published by                                    |
' |    the Free Software Foundation, either version 2 of the License, or                                       |
' |    (at your option) any later version.                                                                     |
' |                                                                                                            |
' |    This program is distributed in the hope that it will be useful,                                         |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of                                          |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                                           |
' |    GNU General Public License for more details.                                                            |
' |                                                                                                            |
' |    You should have received a copy of the GNU General Public License                                       |
' |    along with this program.  If not, see <http://www.gnu.org/licenses/>.                                   |
' |                                                                                                            |
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
Public Class Message
    Public Reponse As MsgBoxResult = MsgBoxResult.No

    Friend Sub FrmMessage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' On regarde quel langue utiliser 22/08/2008
        'LanguageCheck()

    End Sub

    Public Sub New()

        InitializeComponent()
        TextBox.Text = ""
        resizeWindows()

    End Sub

    Public Sub New(ByVal Mess As String, Optional ByVal bCopier As Boolean = False, _
                    Optional ByVal nSizePolice As Integer = 9)

        InitializeComponent()
        ButtonCopier.Visible = bCopier
        TextBox.Text = Mess
        Me.Text = "ZGuideTV.NET"
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)

    End Sub

    Public Sub New(ByVal Titre As String, ByVal Mess As String, Optional ByVal bCopier As Boolean = False, _
                    Optional ByVal nSizePolice As Integer = 9)

        InitializeComponent()
        ButtonCopier.Visible = bCopier
        Me.BringToFront()
        TextBox.Text = Mess
        Me.Text = Titre
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)
        resizeWindows()

    End Sub

    Public Sub New(ByVal Titre As String, ByVal Mess As String, ByVal Style As MsgBoxStyle, _
                    Optional ByVal bCopier As Boolean = False, _
                    Optional ByVal nSizePolice As Integer = 9)

        InitializeComponent()
        ButtonCopier.Visible = bCopier
        Me.BringToFront()
        TextBox.Text = Mess
        Me.Text = Titre
        StyleMaker(Style)
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)
        resizeWindows()

    End Sub

    Public Sub New(ByVal Mess As String, ByVal Style As MsgBoxStyle, Optional ByVal bCopier As Boolean = False, _
                    Optional ByVal nSizePolice As Integer = 9)

        InitializeComponent()
        Dim Titre As String = Mess
        ButtonCopier.Visible = bCopier
        Me.BringToFront()
        TextBox.Text = Mess
        Me.Text = Titre
        StyleMaker(Style)
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)
        resizeWindows()

    End Sub

    Public Sub New(ByVal Mess As String, ByVal Style As MsgBoxStyle, ByVal nSizePolice As Integer, _
                    ByVal TextColor As Color, Optional ByVal bCopier As Boolean = False)

        InitializeComponent()
        Dim Titre As String = Mess
        ButtonCopier.Visible = bCopier
        Me.BringToFront()
        TextBox.Text = Mess
        Me.Text = Titre
        StyleMaker(Style)
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)
        TextBox.ForeColor() = TextColor
        resizeWindows()

    End Sub

    Public Sub New(ByVal Titre As String, ByVal Mess As String, ByVal Style As MsgBoxStyle, _
                    ByVal fFont As Font, Optional ByVal bCopier As Boolean = False)

        InitializeComponent()
        ButtonCopier.Visible = bCopier
        Me.BringToFront()
        TextBox.Text = Mess
        Me.Text = Titre
        StyleMaker(Style)
        TextBox.Font = fFont
        resizeWindows()

    End Sub

    Public Sub New(ByVal Mess As String, ByVal Style As MsgBoxStyle, ByVal fFont As Font, _
                    ByVal TextColor As Color, Optional ByVal bCopier As Boolean = False)

        InitializeComponent()
        Dim Titre As String = Mess
        ButtonCopier.Visible = bCopier
        Me.BringToFront()
        TextBox.Text = Mess
        Me.Text = Titre
        StyleMaker(Style)
        TextBox.Font = fFont
        TextBox.ForeColor() = TextColor
        resizeWindows()

    End Sub

    Private Sub StyleMaker(ByVal Style As MsgBoxStyle)
        Select Case Style
            Case MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground
                PictureBox1.Image = SystemIcons.Error.ToBitmap()
                ButtonAnnuler.Visible = False

            Case MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground
                PictureBox1.Image = SystemIcons.Warning.ToBitmap()
                ButtonAnnuler.Text = "No"

            Case MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground
                PictureBox1.Image = SystemIcons.Information.ToBitmap()
                ButtonAnnuler.Visible = False

            Case MsgBoxStyle.Critical
                PictureBox1.Image = SystemIcons.Error.ToBitmap()
                ButtonAnnuler.Visible = False

            Case MsgBoxStyle.Exclamation
                PictureBox1.Image = SystemIcons.Warning.ToBitmap()
                PictureBox1.Image = SystemIcons.Warning.ToBitmap()
                ButtonAnnuler.Text = "Non"

            Case MsgBoxStyle.Information
                PictureBox1.Image = SystemIcons.Information.ToBitmap()
                ButtonAnnuler.Visible = False

            Case Else
                PictureBox1.Image = SystemIcons.Information.ToBitmap()
                ButtonAnnuler.Visible = False
        End Select
    End Sub

    Private Sub resizeWindows()

        Dim moi As Integer = TextBox.GetLineFromCharIndex(TextBox.TextLength) + 1
        TextBox.Height = CInt(TextBox.Font.Height + 2) * moi
        If TextBox.Height > 500 Then
            TextBox.Height = 500
        End If
        Me.Height = TextBox.Top + (TextBox.Height) + 60
        ButtonCopier.Top = TextBox.Top + TextBox.Height + 10
        ButtonOk.Top = ButtonCopier.Top
        ButtonAnnuler.Top = ButtonCopier.Top


    End Sub

    Private Sub ButtonMiseaJour_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOk.Click
        Reponse = MsgBoxResult.Yes
        Me.Close()
    End Sub

    Private Sub ButtonAnnuler_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAnnuler.Click
        Reponse = MsgBoxResult.No
        Me.Close()
    End Sub

    Private Sub TextBox_LinkClicked(ByVal sender As Object, ByVal e As LinkClickedEventArgs) _
        Handles TextBox.LinkClicked
        Process.Start(e.LinkText())
    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCopier.Click
        Clipboard.SetDataObject(TextBox.Text)
    End Sub
End Class