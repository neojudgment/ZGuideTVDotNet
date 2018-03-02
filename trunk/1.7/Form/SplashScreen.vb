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
Partial Public Class SplashScreen
    ' ReSharper restore CheckNamespace
    Inherits Form

    ' Afin de s'assurer que l'écran de démarrage est bien fermé
    Private _closeSplashScreenFlag As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Affiche le SplashScreen
    Public Sub ShowSplashScreen()
        If InvokeRequired Then
            ' Nous ne sommes pas dans le Thread principal on doit appeler BeginInvoke
            BeginInvoke(New SplashShowCloseDelegate(AddressOf ShowSplashScreen))
            Return
        End If
        Show()
        Application.Run(Me)
    End Sub

    ' Ferme SplashScreen
    Public Sub CloseSplashScreen()
        If InvokeRequired Then
            ' Nous ne sommes pas dans le Thread principal on doit appeler BeginInvoke
            BeginInvoke(New SplashShowCloseDelegate(AddressOf CloseSplashScreen))
            Return
        End If
        _closeSplashScreenFlag = True
        Close()
    End Sub

    ' Mise à jour du texte de la version
    Public Sub VersionText(ByVal Text As String)
        If InvokeRequired Then
            ' Nous ne sommes pas dans le Thread principal on doit appeler BeginInvoke
            BeginInvoke(New StringParameterDelegate(AddressOf VersionText), New Object() {Text})
            Return
        End If

        Version.Text = Text

    End Sub

    ' Mise à jour du texte du Copyright
    Public Sub CopyrightText(ByVal Text As String)
        If InvokeRequired Then
            ' Nous ne sommes pas dans le Thread principal on doit appeler BeginInvoke
            BeginInvoke(New StringParameterDelegate(AddressOf CopyrightText), New Object() {Text})
            Return
        End If

        Copyright.Text = Text

    End Sub

    ' Mise à jour du texte du Multicore
    Public Sub MulticoreText(ByVal Text As String)
        If InvokeRequired Then
            ' Nous ne sommes pas dans le Thread principal on doit appeler BeginInvoke
            BeginInvoke(New StringParameterDelegate(AddressOf MulticoreText), New Object() {Text})
            Return
        End If

        Multicore.Text = Text

    End Sub

    Private Sub SplashFormFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
        Handles MyBase.FormClosing
        If _closeSplashScreenFlag = False Then
            e.Cancel = True
        End If
    End Sub

    Private Delegate Sub SplashShowCloseDelegate()
    Private Delegate Sub StringParameterDelegate(ByVal Text As String)
    'Private Delegate Sub StringParameterWithStatusDelegate(ByVal Text As String, ByVal tom As TypeOfMessage)
End Class
