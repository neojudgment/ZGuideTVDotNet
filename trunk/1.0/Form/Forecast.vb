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
Public Class Forecast
    Private _weatherImageDay As String

#Region "Property"

    Private Property WeatherImageDay As String
        Get
            Return _weatherImageDay
        End Get
        Set(ByVal value As String)
            _weatherImageDay = Value
        End Set
    End Property

    Private _imageDay As Image

    Private Property ImageDay As Image
        Get
            Return _imageDay
        End Get
        Set(ByVal value As Image)
            _imageDay = Value
        End Set
    End Property
#End Region

    Private Sub FrmSelectWeatherLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' On regarde quel langue utiliser 08/08/2010
        LanguageCheck()

        WeatherImageDay = WeatherImageDay1
        weatherday()
        PictureBoxImageDay1.Image = ImageDay

        WeatherImageDay = WeatherImageDay2
        weatherday()
        PictureBoxImageDay2.Image = ImageDay

        WeatherImageDay = WeatherImageDay3
        weatherday()
        PictureBoxImageDay3.Image = ImageDay

        If My.Settings.WeatherFahrenheit = False Then

            ' Day0ConditionLabel.Text = WeatherConditionNow & ". " & WeatherCelsiusNow & " °C."

            Day1ConditionLabel.Text = CStr(WeatherDay1Condition) & ". " & lngMax & " " & WeatherHighDay1Celsius & _
                                      " °C." & " " & lngMin & " " & _
                                      WeatherLowDay1Celsius & " °C."
            Day2ConditionLabel.Text = CStr(WeatherDay2Condition) & ". " & lngMax & " " & WeatherHighDay2Celsius & _
                                      " °C." & " " & lngMin & " " & _
                                      WeatherLowDay2Celsius & " °C."
            Day3ConditionLabel.Text = CStr(WeatherDay3Condition) & ". " & lngMax & " " & WeatherHighDay3Celsius & _
                                      " °C." & " " & lngMin & " " & _
                                      WeatherLowDay3Celsius & " °C."
        Else

            ' ConditionNowLabel.Text = WeatherConditionNow & ". " & WeatherFahrenheitNow & " °F."

            Day1ConditionLabel.Text = CStr(WeatherDay1Condition) & ". " & lngMax & " " & WeatherHighDay1Fahrenheit & _
                                      " °F." & " " & lngMin & " " & _
                                      WeatherLowDay1Fahrenheit & " °F."
            Day2ConditionLabel.Text = CStr(WeatherDay2Condition) & ". " & lngMax & " " & WeatherHighDay2Fahrenheit & _
                                      " °F." & " " & lngMin & " " & _
                                      WeatherLowDay2Fahrenheit & " °F."
            Day3ConditionLabel.Text = CStr(WeatherDay3Condition) & ". " & lngMax & " " & WeatherHighDay3Fahrenheit & _
                                      " °F." & " " & lngMin & " " & _
                                      WeatherLowDay3Fahrenheit & " °F."
        End If

        'ConditionNowLabel.Text = lngConditionNowLabel

        Day1Label.Text = WeatherDay1
        Day2Label.Text = WeatherDay2
        Day3Label.Text = WeatherDay3

    End Sub

    Private Sub OkButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Weatherday()

        If WeatherImageDay = "/ig/images/weather/sunny.gif" Then
            ImageDay = My.Resources.sunny
        End If
        If WeatherImageDay = "/ig/images/weather/chance_of_rain.gif" Then
            ImageDay = My.Resources.chance_of_rain
        End If
        If WeatherImageDay = "/ig/images/weather/mostly_sunny.gif" Then
            ImageDay = My.Resources.mostly_sunny
        End If
        If WeatherImageDay = "/ig/images/weather/partly_cloudy.gif" Then
            ImageDay = My.Resources.partly_cloudy
        End If
        If WeatherImageDay = "/ig/images/weather/mostly_cloudy.gif" Then
            ImageDay = My.Resources.mostly_cloudy
        End If
        If WeatherImageDay = "/ig/images/weather/chance_of_storm.gif" Then
            ImageDay = My.Resources.chance_of_storm
        End If
        If WeatherImageDay = "/ig/images/weather/rain.gif" Then
            ImageDay = My.Resources.rain
        End If
        If WeatherImageDay = "/ig/images/weather/chance_of_snow.gif" Then
            ImageDay = My.Resources.chance_of_snow
        End If
        If WeatherImageDay = "/ig/images/weather/cloudy.gif" Then
            ImageDay = My.Resources.cloudy
        End If
        If WeatherImageDay = "/ig/images/weather/mist.gif" Then
            ImageDay = My.Resources.rain
        End If
        If WeatherImageDay = "/ig/images/weather/storm.gif" Then
            ImageDay = My.Resources.storm
        End If
        If WeatherImageDay = "/ig/images/weather/thunderstorm.gif" Then
            ImageDay = My.Resources.thunderstorm
        End If
        If WeatherImageDay = "/ig/images/weather/chance_of_tstorm.gif" Then
            ImageDay = My.Resources.chance_of_tstorm
        End If
        If WeatherImageDay = "/ig/images/weather/sleet.gif" Then
            ImageDay = My.Resources.sleet
        End If
        If WeatherImageDay = "/ig/images/weather/snow.gif" Then
            ImageDay = My.Resources.snow
        End If
        If WeatherImageDay = "/ig/images/weather/icy.gif" Then
            ImageDay = My.Resources.icy
        End If
        If WeatherImageDay = "/ig/images/weather/dust.gif" Then
            ImageDay = My.Resources.dust
        End If
        If WeatherImageDay = "/ig/images/weather/fog.gif" Then
            ImageDay = My.Resources.fog
        End If
        If WeatherImageDay = "/ig/images/weather/smoke.gif" Then
            ImageDay = My.Resources.smoke
        End If
        If WeatherImageDay = "/ig/images/weather/haze.gif" Then
            ImageDay = My.Resources.haze
        End If
        If WeatherImageDay = "/ig/images/weather/flurries.gif" Then
            ImageDay = My.Resources.flurries
        End If
    End Sub

    Private Sub LocationClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Location_Button.Click
        Dispose()
        Mainform.ToolStripMenuHelpLocation.PerformClick()
    End Sub

    Private Sub CancelButtonClick(sender As System.Object, e As EventArgs) Handles Cancel_Button.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class
