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

Public Class calendrier

#Region "Property"
    ' nbJour => nombre de jours où il y a des données dans le mois
    Private _nbJour As Integer

    Public Property nbJour As Integer
        Get
            Return _nbJour
        End Get
        Set(ByVal Value As Integer)
            _nbJour = Value
        End Set
    End Property

    ' tabJour => tableau de dates sui ont des données
    Private _tabJour As Date()

    Public Property tabJour As Date()
        Get
            Return _tabJour
        End Get
        Set(ByVal Value As Date())
            _tabJour = Value
        End Set
    End Property

    ' Numéro du premier jour du mois (ex Mardi:2 .... Dimanche:7)
    Private _numPremierJour As Integer

    Public Property NumPremierJour As Integer
        Get
            Return _numPremierJour
        End Get
        Set(ByVal Value As Integer)
            _numPremierJour = Value
        End Set
    End Property

    ' Numéro du mois
    Private _numMois As Integer

    Public Property NumMois As Integer
        Get
            Return _numMois
        End Get
        Set(ByVal Value As Integer)
            _numMois = Value
        End Set
    End Property

    'Date Affichée dans le Mainform |
    Private _dateActif As Date

    Public Property dateActif As Date
        Get
            Return _dateActif
        End Get
        Set(ByVal Value As Date)
            _dateActif = Value
        End Set
    End Property

    ' Année affichée
    Private _an As Integer

    Public Property An As Integer
        Get
            Return _an
        End Get
        Set(ByVal Value As Integer)
            _an = Value
        End Set
    End Property
#End Region

    Public Sub New()
        'nbJour = 0
        ReDim tabJour(1)
        dateActif = Date.Today
    End Sub

    Public Sub Inicalendier()
        nbJour = 0
        ReDim tabJour(1)
        'dateActif = System.DateTime.Today
    End Sub

    Public Sub Ajoute(ByVal dDate As Date)
        nbJour += 1
        ReDim Preserve tabJour(nbJour - 1)
        tabJour(nbJour - 1) = dDate
    End Sub

    Public Function Présent(ByVal numjour As Integer, ByVal Month As Integer, ByVal Année As Integer) As Boolean
        Dim i As Integer
        'Dim numjour As Integer = (nLigne * 7) - numJprem
        Dim dDate As New Date(Année, Month, numjour)
        For i = 0 To (nbJour - 1)
            If tabJour(i).Month = dDate.Month AndAlso tabJour(i).Day = dDate.Day AndAlso tabJour(i).Year = dDate.Year _
                Then
                Return True
            End If
        Next i
        Return False
    End Function

    Public Sub ChangeJour(ByVal numBouton As Integer)
        Trace.WriteLine(" entree dans changejour")
        ' eviter les clics miltiples sur des changemmnts d heure, de date , ou de jour
        ' bloque les boutons le temps du traitement'230110
        Mainform.BloquerBoutonCalendrier()
        '230110 
        Mainform.navigtemporelle.Enabled_Button = False
        Dim NumPremierJourTmp As Integer = Me.NumPremierJour
        If Me.NumPremierJour = 0 Then
            NumPremierJourTmp += 7
        End If
        Dim date_choisie As New Date(Me.An, Me.NumMois, (numBouton - NumPremierJourTmp + 1))
        date_choisie = date_choisie.AddHours(moment_souhaite.Hour)


        Dim first_date As Date = first_date_with_data
        first_date = first_date.AddHours(-first_date.Hour)
        first_date = first_date.AddMinutes(-first_date.Minute)
        first_date = first_date.AddMilliseconds(-first_date.Millisecond)

        ' on vient de changer la date dans monthcalendar
        Trace.WriteLine("entree month Calendar")

        If Me.Présent(date_choisie.Day, Me.NumMois, Me.An) Then
            'Dim Wait As New frm_Message
            'Wait.Show()

            statusstrip_calendar_wait = True

            Dim x As Integer
            Dim jour_date_reference As Integer
            ' Dim date1 As New Date
            'Dim deplacement_temps As New TimeSpan
            Dim jour_pické As Integer
            Dim jour_affiché As Integer
            Dim difference As Integer
            'Dim s As String

            x = Mainform.PanelA.Left()
            Me.dateActif = date_choisie

#If DEBUG Then
            Trace.WriteLine(DateTime.Now & " click dans monthcalendar")
            Trace.WriteLine(DateTime.Now & "  panelA.left avant chgmt date = " & x.ToString)
            Trace.WriteLine(DateTime.Now & " on a clique sur " & date_choisie.ToString)
#End If

            If date_choisie = first_date Then
                If date_choisie = Date.Today() Then
                    date_choisie = Date.Now()
                Else
                    date_choisie = first_date_with_data
                End If
            End If

            ' •———————————————————————————————————————————————————————————————————•
            ' | ne pas prendre en compte du commentaire ci-dessous                |
            ' | La date choisie est endhors de ce qu'il est possible d'afficher   |
            ' | on regarde si il y a des émissions à d'autres heures du même jour |
            ' •———————————————————————————————————————————————————————————————————•
            If date_choisie < first_date_with_data Then
                'Dim Tmpdate As New Date(first_date_with_data.Year, first_date_with_data.Month, first_date_with_data.Day)
                'Dim TmpdateChoisie As New Date(date_choisie.Year, date_choisie.Month, date_choisie.Day)
                'If TmpdateChoisie < Tmpdate Then
                Trace.WriteLine(" sortie de changejour")
                Mainform.AutoriserBoutonCalendrier()
                '230110
                Mainform.navigtemporelle.Enabled_Button = True
                Return
                'Else
                'date_choisie = Tmpdate
                'End If
            End If
            If date_choisie > last_date_with_data Then
                'Dim Tmpdate As New Date(last_date_with_data.Year, last_date_with_data.Month, last_date_with_data.Day)
                'Dim TmpdateChoisie As New Date(date_choisie.Year, date_choisie.Month, date_choisie.Day)
                'If TmpdateChoisie > Tmpdate Then
                Trace.WriteLine(" sortie de changejour")
                Mainform.AutoriserBoutonCalendrier()
                '230110
                Mainform.navigtemporelle.Enabled_Button = True

                Return
                'Else
                'date_choisie = Tmpdate
                'End If
            End If

            If date_choisie > _
               date_reference.AddHours(nb_de_periodes_de_6h * Nb_heures_LigneTemps) Then
                Trace.WriteLine(" rechargement des data apres ")
                Mainform.BloquerBoutonCalendrier()
                '230110 
                Mainform.navigtemporelle.Enabled_Button = False
                Mainform.Timer_minute.Enabled = False

                moment_souhaite = date_choisie
                Mainform.ReloadData()
                Mainform.Timer_minute.Enabled = True
                Mainform.IniCalendrier(date_choisie)
                date_reference = date_choisie

                'Wait.Close()
                statusstrip_calendar_wait = False
                Trace.WriteLine(" sortie de changejour")
                Mainform.AutoriserBoutonCalendrier()
                '230110
                Mainform.navigtemporelle.Enabled_Button = True
                Return
            End If

            If date_choisie < date_reference Then
                Mainform.BloquerBoutonCalendrier()
                '230110 
                Mainform.navigtemporelle.Enabled_Button = False
                'load_data_before = True
                Mainform.Timer_minute.Enabled = False
                moment_souhaite = date_choisie
                Mainform.ReloadData()
                Mainform.Timer_minute.Enabled = True
                Mainform.IniCalendrier(date_choisie)

                'Wait.Close()
                statusstrip_calendar_wait = False
                Trace.WriteLine(" sortie de changejour")
                Mainform.AutoriserBoutonCalendrier()
                '230110
                Mainform.navigtemporelle.Enabled_Button = True
                Return
            End If
            Mainform.IniCalendrier(date_choisie)
            'Wait.Close()

            statusstrip_calendar_wait = False

            jour_date_reference = date_reference.DayOfYear
            jour_affiché = date_origine_ecran.DayOfYear
            jour_pické = date_choisie.DayOfYear
            difference = +jour_pické - jour_affiché
            moment_souhaite = moment_souhaite.AddDays(difference)
            Mainform.PanelA.SendToBack()
            Mainform.DeplacerPanelA()

            Trace.WriteLine(" panelA.left apres chgmt de date" & Mainform.PanelA.Left.ToString)

            '
            Trace.WriteLine(" change jour entree dans curseur vertical")
            Central_Screen.Curseur_Vertical()
            'Mainform.Show()
            Trace.WriteLine(" changejour sortie de curseur vertical")

            x = Nothing
            date_choisie = Nothing
            jour_pické = Nothing
            difference = Nothing

        Else
            'MessageBox.Show ("Aucun programme pour cette date.", "Aucun programme", MessageBoxButtons.OK, _
            '                MessageBoxIcon.Warning)
        End If
        Trace.WriteLine(" sortie de changejour")
        Mainform.AutoriserBoutonCalendrier()
        '230110
        Mainform.navigtemporelle.Enabled_Button = True
    End Sub

    Public Function bJourAffiché(ByVal numBouton As Integer) As Boolean
        Dim date_choisie As New Date(Me.An, Me.NumMois, (numBouton))
        Dim DateActifTmp As New Date(dateActif.Year, dateActif.Month, dateActif.Day)
        Return (date_choisie = DateActifTmp)

        'Return (date_choisie = System.DateTime.Today() Or date_choisie = System.datetime.now())
    End Function
End Class
