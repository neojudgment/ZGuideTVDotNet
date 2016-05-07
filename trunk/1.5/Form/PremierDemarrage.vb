' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2013 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
Public Class PremierDemarrage
    ' ReSharper restore CheckNamespace

    Private _proxytest As Boolean

    Private Sub FrmPremierDemarrageLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        With My.Settings
            Login.Text = .loginproxy
            Pass.Text = .passproxy
            ProxyHost.Text = .Proxy
            ProxyPort.Text = .ProxyPort
        End With

        Trace.WriteLine(DateTime.Now & " " & "On entre dans PremierDemarrage.")
        LanguageCheck(10)
        AcceptButton = ButtonOK
    End Sub

    Private Sub BtOkClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonOK.Click

        Trace.WriteLine(DateTime.Now & " " & "On clique sur le button Ok dans PremierDemarrage.")

        If _
            ProxyHost.Text IsNot String.Empty AndAlso ProxyPort.Text IsNot String.Empty AndAlso
            IsNumeric(ProxyPort.Text) AndAlso _proxytest Then

            Trace.WriteLine(
                DateTime.Now & " " & "Le proxy est configuré correctement on clique sur Ok dans PremierDemarrage.")

            With My.Settings
                .ProxyPort = ProxyPort.Text
                .loginproxy = Login.Text
                .passproxy = Pass.Text
                .Proxy = ProxyHost.Text
                .Save()
            End With

            _proxytest = False
            Close()

        ElseIf _
            ProxyHost.Text IsNot String.Empty AndAlso ProxyPort.Text IsNot String.Empty AndAlso
            IsNumeric(ProxyPort.Text) AndAlso Not _proxytest Then

            Trace.WriteLine(
                DateTime.Now & " " &
                "Le proxy n'est pas configuré correctement on clique sur Ok dans PremierDemarrage.")

            ' ReSharper disable NotAccessedVariable
            Dim boxProxytestContinue As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxProxytestContinue = MessageBox.Show _
                (
                    "La configuration du proxy n'a pas été effectuée où le test a échoué !" &
                    (Chr(13) & Chr(13) & "Voulez-vous continuer sans proxy ?"),
                    "Configuration du proxy", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1)

            If boxProxytestContinue = DialogResult.Yes Then
                Trace.WriteLine(DateTime.Now & " " & "La configuration du proxy a échoué on continue malgrés tout.")

                With My.Settings
                    .ProxyPort = String.Empty
                    .loginproxy = String.Empty
                    .passproxy = String.Empty
                    .Proxy = String.Empty
                    .Save()
                End With

                Close()
            Else
                Trace.WriteLine(DateTime.Now & " " & "La configuration du proxy a échoué on réessaye.")
            End If
        Else
            Close()
        End If
    End Sub

    Private Sub BtCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCancel.Click

        Trace.WriteLine(DateTime.Now & " " & "On clique sur le button Cancel dans PremierDemarrage.")
        Close()
    End Sub

    Private Sub ButtonProxyTestClick(sender As Object, e As EventArgs) Handles ButtonProxyTest.Click

        Trace.WriteLine(DateTime.Now & " " & "On teste le proxy dans PremierDemarrage.")

        If ProxyHost.Text IsNot String.Empty AndAlso ProxyPort.Text IsNot String.Empty AndAlso IsNumeric(ProxyPort.Text) _
            Then
            With My.Settings
                .loginproxy = Login.Text
                .passproxy = Pass.Text
                .Proxy = ProxyHost.Text
                .ProxyPort = ProxyPort.Text
                .Save()
            End With

            If My.Computer.Network.IsAvailable AndAlso ConnectionAvailable("http://www.google.com") Then

                Trace.WriteLine(
                    DateTime.Now & " " & "La configuration du proxy a été effectuée avec succès dans PremierDemarrage.")

                ' ReSharper disable NotAccessedVariable
                Dim boxProxytestTrue As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxProxytestTrue = MessageBox.Show _
                    ("La configuration du proxy a été effectuée avec succès !",
                     "Configuration du proxy", MessageBoxButtons.OK, MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1)

                _proxytest = True
            Else
                With My.Settings
                    .loginproxy = String.Empty
                    .passproxy = String.Empty
                    .Proxy = String.Empty
                    .ProxyPort = String.Empty
                    .Save()
                End With

                Trace.WriteLine(DateTime.Now & " " & "La configuration du proxy a échoué dans PremierDemarrage.")

                ' ReSharper disable NotAccessedVariable
                Dim boxProxytestFalse As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxProxytestFalse = MessageBox.Show _
                    ("La configuration du proxy a échoué !",
                     "Configuration du proxy", MessageBoxButtons.OK, MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1)

                _proxytest = False
            End If
        End If
    End Sub
End Class