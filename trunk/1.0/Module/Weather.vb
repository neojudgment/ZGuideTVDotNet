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

Module Weather

    Public wD As Animaonline.Weather.WeatherData.GoogleWeatherData

    Public WeatherLanguage As Integer
    Public WeatherCity As String
    Public WeatherError As Boolean

    'Maintenant
    Public WeatherCelsiusNow As Double
    Public WeatherFahrenheitNow As Double
    Public WeatherConditionNow As String
    Public WeatherImageNow As String

    'Météo prévision jour0
    Public WeatherDay0 As String
    Public WeatherDay0Condition As String
    Public WeatherHighDay0Celsius As Double
    Public WeatherLowDay0Celsius As Double
    Public WeatherHighDay0Fahrenheit As Double
    Public WeatherLowDay0Fahrenheit As Double
    Public WeatherImageDay0 As String

    'Météo prévision jour1
    Public WeatherDay1 As String
    Public WeatherDay1Condition As String
    Public WeatherHighDay1Celsius As Double
    Public WeatherLowDay1Celsius As Double
    Public WeatherHighDay1Fahrenheit As Double
    Public WeatherLowDay1Fahrenheit As Double
    Public WeatherImageDay1 As String

    'Météo prévision jour2
    Public WeatherDay2 As String
    Public WeatherDay2Condition As String
    Public WeatherHighDay2Celsius As Double
    Public WeatherLowDay2Celsius As Double
    Public WeatherHighDay2Fahrenheit As Double
    Public WeatherLowDay2Fahrenheit As Double
    Public WeatherImageDay2 As String

    'Météo prévision jour3
    Public WeatherDay3 As String
    Public WeatherDay3Condition As String
    Public WeatherHighDay3Celsius As Double
    Public WeatherLowDay3Celsius As Double
    Public WeatherHighDay3Fahrenheit As Double
    Public WeatherLowDay3Fahrenheit As Double
    Public WeatherImageDay3 As String

    Sub WeatherMain()

        WeatherError = False

        Try
            If My.Settings.Language = "Français" Then
                wD = Animaonline.Weather.GoogleWeatherAPI.GetWeather(Animaonline.Globals.LanguageCode.fr_FR, My.Settings.WeatherCity)
            Else
                wD = Animaonline.Weather.GoogleWeatherAPI.GetWeather(Animaonline.Globals.LanguageCode.en_US, My.Settings.WeatherCity)
            End If

            'Météo courante
            WeatherCelsiusNow = CDbl(wD.CurrentConditions.Temperature.Celsius)
            WeatherFahrenheitNow = CDbl(wD.CurrentConditions.Temperature.Fahrenheit)
            WeatherConditionNow = wD.CurrentConditions.Condition
            WeatherImageNow = wD.CurrentConditions.Icon

            ' Météo prévision jour0
            WeatherHighDay0Celsius = Math.Round(wD.ForecastConditions(0).High.Celsius)
            WeatherLowDay0Celsius = Math.Round(wD.ForecastConditions(0).Low.Celsius)
            WeatherHighDay0Fahrenheit = Math.Round(wD.ForecastConditions(0).High.Fahrenheit)
            WeatherLowDay0Fahrenheit = Math.Round(wD.ForecastConditions(0).Low.Fahrenheit)
            WeatherDay0 = wD.ForecastConditions(0).Day
            WeatherDay0Condition = wD.ForecastConditions(0).Condition
            WeatherImageDay0 = wD.ForecastConditions(0).Icon

            ' Météo prévision jour1
            WeatherHighDay1Celsius = Math.Round(wD.ForecastConditions(1).High.Celsius)
            WeatherLowDay1Celsius = Math.Round(wD.ForecastConditions(1).Low.Celsius)
            WeatherHighDay1Fahrenheit = Math.Round(wD.ForecastConditions(1).High.Fahrenheit)
            WeatherLowDay1Fahrenheit = Math.Round(wD.ForecastConditions(1).Low.Fahrenheit)
            WeatherDay1 = wD.ForecastConditions(1).Day
            WeatherDay1Condition = wD.ForecastConditions(1).Condition
            WeatherImageDay1 = wD.ForecastConditions(1).Icon

            ' Météo prévision jour2
            WeatherHighDay2Celsius = Math.Round(wD.ForecastConditions(2).High.Celsius)
            WeatherLowDay2Celsius = Math.Round(wD.ForecastConditions(2).Low.Celsius)
            WeatherHighDay2Fahrenheit = Math.Round(wD.ForecastConditions(2).High.Fahrenheit)
            WeatherLowDay2Fahrenheit = Math.Round(wD.ForecastConditions(2).Low.Fahrenheit)
            WeatherDay2 = wD.ForecastConditions(2).Day
            WeatherDay2Condition = wD.ForecastConditions(2).Condition
            WeatherImageDay2 = wD.ForecastConditions(2).Icon

            ' Météo prévision jour3
            WeatherHighDay3Celsius = Math.Round(wD.ForecastConditions(3).High.Celsius)
            WeatherLowDay3Celsius = Math.Round(wD.ForecastConditions(3).Low.Celsius)
            WeatherHighDay3Fahrenheit = Math.Round(wD.ForecastConditions(3).High.Fahrenheit)
            WeatherLowDay3Fahrenheit = Math.Round(wD.ForecastConditions(3).Low.Fahrenheit)
            WeatherDay3 = wD.ForecastConditions(3).Day
            WeatherDay3Condition = wD.ForecastConditions(3).Condition
            WeatherImageDay3 = wD.ForecastConditions(3).Icon

        Catch
            WeatherError = True
            Exit Sub
        End Try

        WeatherImage()
    End Sub

    Sub WeatherImage()

        With Mainform.ToolStripStatusLabelWeatherImage
            If WeatherImageNow = "/ig/images/weather/sunny.gif" Then
                .BackgroundImage = My.Resources.sunny
            End If
            If WeatherImageNow = "/ig/images/weather/chance_of_rain.gif" Then
                .BackgroundImage = My.Resources.chance_of_rain
            End If
            If WeatherImageNow = "/ig/images/weather/mostly_sunny.gif" Then
                .BackgroundImage = My.Resources.mostly_sunny
            End If
            If WeatherImageNow = "/ig/images/weather/partly_cloudy.gif" Then
                .BackgroundImage = My.Resources.partly_cloudy
            End If
            If WeatherImageNow = "/ig/images/weather/mostly_cloudy.gif" Then
                .BackgroundImage = My.Resources.mostly_cloudy
            End If
            If WeatherImageNow = "/ig/images/weather/chance_of_storm.gif" Then
                .BackgroundImage = My.Resources.chance_of_storm
            End If
            If WeatherImageNow = "/ig/images/weather/rain.gif" Then
                .BackgroundImage = My.Resources.rain
            End If
            If WeatherImageNow = "/ig/images/weather/chance_of_snow.gif" Then
                .BackgroundImage = My.Resources.chance_of_snow
            End If
            If WeatherImageNow = "/ig/images/weather/cloudy.gif" Then
                .BackgroundImage = My.Resources.cloudy
            End If
            If WeatherImageNow = "/ig/images/weather/mist.gif" Then
                .BackgroundImage = My.Resources.rain
            End If
            If WeatherImageNow = "/ig/images/weather/storm.gif" Then
                .BackgroundImage = My.Resources.storm
            End If
            If WeatherImageNow = "/ig/images/weather/thunderstorm.gif" Then
                .BackgroundImage = My.Resources.thunderstorm
            End If
            If WeatherImageNow = "/ig/images/weather/chance_of_tstorm.gif" Then
                .BackgroundImage = My.Resources.chance_of_tstorm
            End If
            If WeatherImageNow = "/ig/images/weather/sleet.gif" Then
                .BackgroundImage = My.Resources.sleet
            End If
            If WeatherImageNow = "/ig/images/weather/snow.gif" Then
                .BackgroundImage = My.Resources.snow
            End If
            If WeatherImageNow = "/ig/images/weather/icy.gif" Then
                .BackgroundImage = My.Resources.icy
            End If
            If WeatherImageNow = "/ig/images/weather/dust.gif" Then
                .BackgroundImage = My.Resources.dust
            End If
            If WeatherImageNow = "/ig/images/weather/fog.gif" Then
                .BackgroundImage = My.Resources.fog
            End If
            If WeatherImageNow = "/ig/images/weather/smoke.gif" Then
                .BackgroundImage = My.Resources.smoke
            End If
            If WeatherImageNow = "/ig/images/weather/haze.gif" Then
                .BackgroundImage = My.Resources.haze
            End If
            If WeatherImageNow = "/ig/images/weather/flurries.gif" Then
                .BackgroundImage = My.Resources.flurries
            End If
        End With

        'Si aucune image ne correspond on en met une par défaut
        If WeatherImageNow = "" Then
            Mainform.ToolStripStatusLabelWeatherImage.BackgroundImage = My.Resources.mostly_cloudy
        End If
    End Sub
End Module
