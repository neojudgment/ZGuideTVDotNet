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
Public Class EPGDataSubscription

#Region "Property"
    Private _messageBoxEPGDataSubscription As String

    Public Property MessageBoxEPGDataSubscription As String
        Get
            Return _messageBoxEPGDataSubscription
        End Get
        Set(ByVal Value As String)
            _messageBoxEPGDataSubscription = Value
        End Set
    End Property

    Private _messageBoxEPGDataSubscription1 As String

    Public Property MessageBoxEPGDataSubscription1 As String
        Get
            Return _messageBoxEPGDataSubscription1
        End Get
        Set(ByVal Value As String)
            _messageBoxEPGDataSubscription1 = Value
        End Set
    End Property

    Private _messageBoxEPGDataSubscriptionTitre As String

    Public Property MessageBoxEPGDataSubscriptionTitre As String
        Get
            Return _messageBoxEPGDataSubscriptionTitre
        End Get
        Set(ByVal Value As String)
            _messageBoxEPGDataSubscriptionTitre = Value
        End Set
    End Property
#End Region

    Private Sub EPGDataSubscription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboCountry.SelectedIndex = 0
        cboLangue.SelectedIndex = 0

        LanguageCheck(11)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGoEPGData.Click
        Dim baseURl As String = "http://www.epgdata.com/?action=newSubscription&iLang="
        Dim Lang As String = "" 'langue de la page
        Dim country As String = "" 'pays du package

        Select Case cboCountry.SelectedIndex
            Case 0
                country = "fr"
            Case 1
                country = "it"
            Case 2
                country = "de"
                'Case 3
                '    country = "nl"
            Case 3
                country = "at"
            Case 4
                country = "ch"
        End Select

        Select Case cboLangue.SelectedIndex
            Case 0
                Lang = "fr"
            Case 1
                Lang = "en"
            Case 2
                Lang = "it"
            Case 3
                Lang = "de"
            Case 4
                Lang = "es"
        End Select

        Dim iOEM As String = "" 'identifiant pour zg A DEMANDER

        Dim url As String = baseURl & Lang & "&iCountry=" & country & "&iOEM=" & iOEM

        If Not (String.IsNullOrEmpty(Lang) AndAlso String.IsNullOrEmpty(country)) Then

            ' Néo 11/10/2010
            Dim p As Process = Nothing
            Try
                p = New Process
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.StartInfo.CreateNoWindow = False
                p.StartInfo.UseShellExecute = True
                p.StartInfo.FileName = url
                p.Start()
                p.Dispose()
                p = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Exception")
                Trace.WriteLine(DateTime.Now & "Erreur lors de l'ouverture du navigateur sur epgData.com pour une subscription")
            Finally
                If p IsNot Nothing Then
                    If Not p.HasExited Then
                        p.Kill()
                    End If
                    p.Dispose()
                    p = Nothing
                End If
            End Try

            Me.Dispose()
        Else
            ' On a pas sélectionné le pays ou la langue
            Dim BoxEPGDataSubscription As DialogResult
            BoxEPGDataSubscription = _
                MessageBox.Show(MessageBoxEPGDataSubscription & Chr(13) & MessageBoxEPGDataSubscription1, _
                                 MessageBoxEPGDataSubscriptionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class