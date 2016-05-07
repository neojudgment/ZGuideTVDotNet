Imports System.Net

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
Public Class PremierDemarrage

#Region "Property"
    Private _messageBoxNoConnection As String

    Public Property MessageBoxNoConnection As String
        Get
            Return _messageBoxNoConnection
        End Get
        Set(ByVal Value As String)
            _messageBoxNoConnection = Value
        End Set
    End Property

    Private _messageBoxNoConnection1 As String

    Public Property MessageBoxNoConnection1 As String
        Get
            Return _messageBoxNoConnection1
        End Get
        Set(ByVal Value As String)
            _messageBoxNoConnection1 = Value
        End Set
    End Property

    Private _messageBoxNoConnectionTitre As String

    Public Property MessageBoxNoConnectionTitre As String
        Get
            Return _messageBoxNoConnectionTitre
        End Get
        Set(ByVal Value As String)
            _messageBoxNoConnectionTitre = Value
        End Set
    End Property

    Private _messageBoxNoCodePin As String

    Public Property MessageBoxNoCodePin As String
        Get
            Return _messageBoxNoCodePin
        End Get
        Set(ByVal Value As String)
            _messageBoxNoCodePin = Value
        End Set
    End Property

    Private _messageBoxNoCodePin1 As String

    Public Property MessageBoxNoCodePin1 As String
        Get
            Return _messageBoxNoCodePin1
        End Get
        Set(ByVal Value As String)
            _messageBoxNoCodePin1 = Value
        End Set
    End Property

    Private _messageBoxNoCodePinTitre As String

    Public Property MessageBoxNoCodePinTitre As String
        Get
            Return _messageBoxNoCodePinTitre
        End Get
        Set(ByVal Value As String)
            _messageBoxNoCodePinTitre = Value
        End Set
    End Property
#End Region

    ' 22/08/2010 Griser et désactiver la croix rouge de la form
    Private Const CS_NOCLOSE As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub frmPremierDemarrage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        GroupBoxEPGData.Enabled = False
        LanguageCheck(10)
        Me.AcceptButton = ButtonOK
    End Sub

    Private Sub btOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOK.Click

        If RadioButtonEPGData.Checked AndAlso String.IsNullOrEmpty(TextBoxPinCode.Text) Then

            ' Message indiquant qu'il n'y a pas de code Pin entré
            Dim BoxNoCodePin As DialogResult
            BoxNoCodePin = _
                MessageBox.Show(MessageBoxNoCodePin & Chr(13) & MessageBoxNoCodePin1, _
                                 MessageBoxNoCodePinTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else

            Me.DialogResult = System.Windows.Forms.DialogResult.OK

            ' on va écrire les options du proxy
            My.Settings.loginproxy = Login.Text

            ' login du proxy
            My.Settings.passproxy = Pass.Text

            ' mot de pas du proxy
            My.Settings.Proxy = ProxyHost.Text

            ' url du proxy
            If (Not ProxyPort.Text Is Nothing AndAlso String.IsNullOrEmpty(ProxyPort.Text)) Then
                ProxyPort.Text = "1"
            End If

            ' le port du proxy ne peut pas être à null sinon bug
            My.Settings.ProxyPort = ProxyPort.Text

            If RadioButtonEPGData.Checked Then
                If Not String.IsNullOrEmpty(TextBoxPinCode.Text) Then
                    With My.Settings
                        .Epgdata = True
                        .PinEpgdata = TextBoxPinCode.Text.Trim
                        .Save()
                    End With
                    Return

                Else
                    With My.Settings
                        .Epgdata = False
                        .Save()
                    End With
                    Return
                End If

            Else
                With My.Settings
                    .Epgdata = False
                    .Save()
                End With
                Return
            End If
        End If

    End Sub

    Private Sub btSAbonner_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSubscription.Click

        Try
            If IsNetConnectOnline() AndAlso ConnectionAvailable.ConnectionAvailable("http://www.epgdata.com/") Then

                EPGDataSubscription.ShowDialog()

            Else

                ' Message indiquant qu'il n'y a pas de connexion internet dispo pour
                ' aller sur le epgData.com
                Dim BoxNoConnection As DialogResult
                BoxNoConnection = _
                    MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                     MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
            End If

        Catch ex As WebException

            Dim BoxNoConnection As DialogResult
            BoxNoConnection = _
                MessageBox.Show(MessageBoxNoConnection & Chr(13) & MessageBoxNoConnection1, _
                                 MessageBoxNoConnectionTitre, MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
        End Try


    End Sub

    Private Sub BtCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCancel.Click
        Return
    End Sub

    Private Sub RadioButtonXMLTV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonXMLTV.CheckedChanged
        GroupBoxEPGData.Enabled = False
    End Sub

    Private Sub RadioButtonEPGData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonEPGData.CheckedChanged
        GroupBoxEPGData.Enabled = True
    End Sub
End Class