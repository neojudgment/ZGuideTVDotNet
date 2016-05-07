' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2014 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
