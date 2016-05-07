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
Public Class WeatherCitySelect
    Private Sub WeatherCitySelect_Load (ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        'La ville actuellement sélectionnée
        TextBoxWeatherSelected.Text = My.Settings.WeatherCity

        'Température sélectionnée en Fahrenheit
        If My.Settings.WeatherFahrenheit = True Then
            CheckBoxWeatherFahrenheit.Checked = True
        End If

    End Sub

    Private Sub OK_Button_Click (ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        'On passe la 1ère lettre en majuscule 
        TextBoxWeatherSelected.Text = StrConv (TextBoxWeatherSelected.Text, vbProperCase)

        'On sauve Celsius ou Fahrenheit
        If CheckBoxWeatherFahrenheit.Checked = True Then
            My.Settings.WeatherFahrenheit = True
        Else
            My.Settings.WeatherFahrenheit = False
        End If

        If (Not TextBoxWeatherSelected.Text Is Nothing AndAlso String.IsNullOrEmpty(TextBoxWeatherSelected.Text)) Then
            TextBoxWeatherSelected.Text = "Paris"
        End If

        'On sauve la ville sélectionnée
        My.Settings.WeatherCity = TextBoxWeatherSelected.Text
        My.Settings.Save()
        Mainform.WeatherUpdate()

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click (ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
