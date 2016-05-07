' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2016 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
' ReSharper disable InconsistentNaming
Public Class calendrier
    ' ReSharper restore InconsistentNaming
    ' ReSharper restore CheckNamespace

#Region "Property"
    ' nbJour => nombre de jours où il y a des données dans le mois
    'Private _nbJour As Integer
    Private _nbJour As Integer
    'Public Property nbJour As Integer
    '    Get
    '        Return _nbJour
    '    End Get
    '    Set(ByVal value As Integer)
    '        _nbJour = value
    '    End Set
    ''End Property

    ' tabJour => tableau de dates sui ont des données
    'Private _tabJour As Date()
    Private _tabJour As Date()
    'Public Property tabJour As Date()
    '    Get
    '        Return _tabJour
    '    End Get
    '    Set(ByVal value As Date())
    '        _tabJour = value
    '    End Set
    'End Property

    ' Numéro du premier jour du mois (ex Mardi:2 .... Dimanche:7)

    Public Property NumPremierJour As Integer

    ' Numéro du mois

    Public Property NumMois As Integer

    'Date Affichée dans le Mainform |

    Public Property DateActif As Date

    ' Année affichée

    Public Property An As Integer

#End Region

    Public Sub New()
        'nbJour = 0
        ReDim _tabJour(1)
        dateActif = Date.Today
    End Sub

    Public Sub Ajoute(ByVal dDate As Date)

        _nbJour += 1
        ReDim Preserve _tabJour(_nbJour - 1)
        _tabJour(_nbJour - 1) = dDate
    End Sub

    Public Function Présent(ByVal numjour As Integer, ByVal month As Integer, ByVal annee As Integer) As Boolean

        Dim i As Integer
        'Dim numjour As Integer = (nLigne * 7) - numJprem
        Dim dDate As New Date(annee, month, numjour)
        For i = 0 To (_nbJour - 1)
            If _tabJour(i).Month = dDate.Month AndAlso _tabJour(i).Day = dDate.Day AndAlso _tabJour(i).Year = dDate.Year _
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
        Mainform.navigtemporelle.EnabledButton = False

        Dim numPremierJourTmp As Integer = NumPremierJour
        If NumPremierJour = 0 Then
            numPremierJourTmp += 7
        End If
        Dim dateChoisie As New Date(An, NumMois, (numBouton - numPremierJourTmp + 1))
        dateChoisie = dateChoisie.AddHours(MomentSouhaite.Hour)


        Dim firstDate As Date = FirstDateWithData
        firstDate = firstDate.AddHours(-firstDate.Hour)
        firstDate = firstDate.AddMinutes(-firstDate.Minute)
        firstDate = firstDate.AddMilliseconds(-firstDate.Millisecond)

        ' on vient de changer la date dans monthcalendar
        Trace.WriteLine("entree month Calendar")

        If Présent(dateChoisie.Day, NumMois, An) Then
           
            Dim jourPické As Integer
            Dim jourAffiché As Integer
            Dim difference As Integer

            DateActif = dateChoisie

            ' Néo le 06/04/2014
            Dim differencespan As TimeSpan = (DateActif - DateTime.Now)
            Dim differenceheure As Integer = CType(differencespan.TotalHours, Integer)
            Mainform.IncrementationSourisHorizontale = differenceheure

            If dateChoisie = firstDate Then
                If dateChoisie = Date.Today() Then
                    dateChoisie = Date.Now()
                Else
                    dateChoisie = FirstDateWithData
                End If
            End If

            ' •———————————————————————————————————————————————————————————————————•
            ' | ne pas prendre en compte du commentaire ci-dessous                |
            ' | La date choisie est endhors de ce qu'il est possible d'afficher   |
            ' | on regarde si il y a des émissions à d'autres heures du même jour |
            ' •———————————————————————————————————————————————————————————————————•
            If dateChoisie < FirstDateWithData OrElse dateChoisie > LastDateWithData Then

                Trace.WriteLine(" sortie de changejour")
                Mainform.AutoriserBoutonCalendrier()
                '230110
                Mainform.navigtemporelle.EnabledButton = True
                Return
            End If

            If dateChoisie > _
               DateReference.AddHours(NbDePeriodesDe_6H * NbHeuresLigneTemps) Then
                Trace.WriteLine(" rechargement des data apres ")
                Mainform.BloquerBoutonCalendrier()
                '230110 
                Mainform.navigtemporelle.EnabledButton = False
                Mainform.Timer_minute.Enabled = False

                MomentSouhaite = dateChoisie
                Mainform.ReloadData()
                Mainform.Timer_minute.Enabled = True
                Mainform.IniCalendrier(dateChoisie)
                DateReference = dateChoisie

                Trace.WriteLine(" sortie de changejour")
                Mainform.AutoriserBoutonCalendrier()
                '230110
                Mainform.navigtemporelle.ReinitBouton()
                Mainform.navigtemporelle.EnabledButton = True
                Return
            End If

            If dateChoisie < DateReference Then
                Mainform.BloquerBoutonCalendrier()
                '230110 
                Mainform.navigtemporelle.EnabledButton = False
                'load_data_before = True
                Mainform.Timer_minute.Enabled = False
                MomentSouhaite = dateChoisie
                Mainform.ReloadData()
                Mainform.Timer_minute.Enabled = True
                Mainform.IniCalendrier(dateChoisie)

                Trace.WriteLine(" sortie de changejour")
                Mainform.AutoriserBoutonCalendrier()
                '230110
                Mainform.navigtemporelle.ReinitBouton()
                Mainform.navigtemporelle.EnabledButton = True
                Return
            End If

            Mainform.IniCalendrier(dateChoisie)

            jourAffiché = DateOrigineEcran.DayOfYear
            jourPické = dateChoisie.DayOfYear
            difference = +jourPické - jourAffiché
            MomentSouhaite = MomentSouhaite.AddDays(difference)
            Mainform.PanelA.SendToBack()
            Mainform.DeplacerPanelA()

            Trace.WriteLine(" panelA.left apres chgmt de date" & Mainform.PanelA.Left.ToString)

            '
            Trace.WriteLine(" change jour entree dans curseur vertical")
            CentralScreen.CurseurVertical()
            'Mainform.Show()
            Trace.WriteLine(" changejour sortie de curseur vertical")
        Else
            'MessageBox.Show ("Aucun programme pour cette date.", "Aucun programme", MessageBoxButtons.OK, _
            '                MessageBoxIcon.Warning)
        End If

        Trace.WriteLine(" sortie de changejour")
        Mainform.AutoriserBoutonCalendrier()
        '230110
        Mainform.navigtemporelle.EnabledButton = True
    End Sub

    Public Function BJourAffiché(ByVal numBouton As Integer) As Boolean

        Dim dateChoisie As New Date(An, NumMois, (numBouton))
        Dim dateActifTmp As New Date(dateActif.Year, dateActif.Month, dateActif.Day)
        Return (dateChoisie = dateActifTmp)
    End Function
End Class
