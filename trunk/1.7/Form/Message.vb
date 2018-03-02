' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2017 ZGuideTV.NET Team <https://github.com/neojudgment>                              |
' |                                                                                                            |
' |    Project administrator : Pascal Hubert (neojudgment@hotmail.com)                                         |
' |                                                                                                            |
' |    This program is free software: you can redistribute it and/or modify                                    |
' |    it under the terms of the Microsoft Reciprocal License (MS-RL)                                          |
' |                                                                                                            |
' |    This program is distributed in the hope that it will be useful,                                         |
' |    but WITHOUT ANY WARRANTY; without even the implied warranty of                                          |
' |    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.                                                    |
' |                                                                                                            |
' |                                                                                                            |
' |    You should have received a copy of the MS-RL License                                                    |
' |    along with this program.  If not, see <https://opensource.org/licenses/MS-RL>.                          |
' |                                                                                                            |
' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' ReSharper disable CheckNamespace
Public Class Message
    ' ReSharper restore CheckNamespace
    Public Reponse As MsgBoxResult = MsgBoxResult.No

    Private Sub FrmMessage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' On regarde quel langue utiliser 22/08/2008
        'LanguageCheck()

    End Sub

    Public Sub New()

        InitializeComponent()
        TextBox.Text = ""
        ResizeWindows()

    End Sub

    Public Sub New(ByVal mess As String, Optional ByVal bCopier As Boolean = False, _
                    Optional ByVal nSizePolice As Integer = 9)

        InitializeComponent()
        ButtonCopier.Visible = bCopier
        TextBox.Text = mess
        Text = "ZGuideTV.NET"
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)

    End Sub

    Public Sub New(ByVal titre As String, ByVal mess As String, Optional ByVal bCopier As Boolean = False, _
                    Optional ByVal nSizePolice As Integer = 9)

        InitializeComponent()
        ButtonCopier.Visible = bCopier
        BringToFront()
        TextBox.Text = mess
        Text = titre
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)
        ResizeWindows()

    End Sub

    Public Sub New(ByVal titre As String, ByVal mess As String, ByVal style As MsgBoxStyle, _
                    Optional ByVal bCopier As Boolean = False, _
                    Optional ByVal nSizePolice As Integer = 9)

        InitializeComponent()
        ButtonCopier.Visible = bCopier
        BringToFront()
        TextBox.Text = mess
        Text = titre
        StyleMaker(style)
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)
        ResizeWindows()

    End Sub

    Public Sub New(ByVal mess As String, ByVal style As MsgBoxStyle, Optional ByVal bCopier As Boolean = False, _
                    Optional ByVal nSizePolice As Integer = 9)

        InitializeComponent()
        Dim titre As String = mess
        ButtonCopier.Visible = bCopier
        BringToFront()
        TextBox.Text = mess
        Text = titre
        StyleMaker(style)
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)
        ResizeWindows()

    End Sub

    Public Sub New(ByVal mess As String, ByVal style As MsgBoxStyle, ByVal nSizePolice As Integer, _
                    ByVal textColor As Color, Optional ByVal bCopier As Boolean = False)

        InitializeComponent()
        Dim titre As String = mess
        ButtonCopier.Visible = bCopier
        BringToFront()
        TextBox.Text = mess
        Text = titre
        StyleMaker(style)
        TextBox.Font = New Font(TextBox.Font.Name, nSizePolice, TextBox.Font.Style)
        TextBox.ForeColor() = textColor
        ResizeWindows()

    End Sub

    Public Sub New(ByVal titre As String, ByVal mess As String, ByVal style As MsgBoxStyle, _
                    ByVal fFont As Font, Optional ByVal bCopier As Boolean = False)

        InitializeComponent()
        ButtonCopier.Visible = bCopier
        BringToFront()
        TextBox.Text = mess
        Text = titre
        StyleMaker(style)
        TextBox.Font = fFont
        ResizeWindows()

    End Sub

    Public Sub New(ByVal mess As String, ByVal style As MsgBoxStyle, ByVal fFont As Font, _
                    ByVal textColor As Color, Optional ByVal bCopier As Boolean = False)

        InitializeComponent()
        Dim titre As String = mess
        ButtonCopier.Visible = bCopier
        BringToFront()
        TextBox.Text = mess
        Text = titre
        StyleMaker(style)
        TextBox.Font = fFont
        TextBox.ForeColor() = textColor
        ResizeWindows()

    End Sub

    Private Sub StyleMaker(ByVal style As MsgBoxStyle)
        Select Case style
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

    Private Sub ResizeWindows()

        Dim moi As Integer = TextBox.GetLineFromCharIndex(TextBox.TextLength) + 1
        TextBox.Height = CInt(TextBox.Font.Height + 2) * moi
        If TextBox.Height > 500 Then
            TextBox.Height = 500
        End If
        Height = TextBox.Top + (TextBox.Height) + 60
        ButtonCopier.Top = TextBox.Top + TextBox.Height + 10
        ButtonOk.Top = ButtonCopier.Top
        ButtonAnnuler.Top = ButtonCopier.Top


    End Sub

    Private Sub ButtonMiseaJourClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOk.Click
        Reponse = MsgBoxResult.Yes
        Close()
    End Sub

    Private Sub ButtonAnnulerClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAnnuler.Click
        Reponse = MsgBoxResult.No
        Close()
    End Sub

    Private Sub TextBox_LinkClicked(ByVal sender As Object, ByVal e As LinkClickedEventArgs) _
        Handles TextBox.LinkClicked
        Process.Start(e.LinkText())
    End Sub

    Private Sub Button1Click1(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCopier.Click
        Clipboard.SetDataObject(TextBox.Text)
    End Sub
End Class