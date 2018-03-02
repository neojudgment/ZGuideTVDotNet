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

Imports System.Globalization
Imports System.Text
Imports ZGuideTV.SQLiteWrapper

' ReSharper disable CheckNamespace
Friend Module Requete
    ' ReSharper restore CheckNamespace

    Public Sub CalculNoeBySql()

        ' calcul du nb d emissions pour chaque chaine
        ' Dim som As Integer 'ne sert que pour le trace.writeline
        Dim compte As Integer
        Dim y1 As String
        Dim y2 As String

        Dim db As SqLiteBase = New SqLiteBase
        db.OpenDatabase(BddPath & "db_progs.db3")
        Dim dtCalculNoeBySqlBack As DataTable

        Trace.WriteLine(DateTime.Now & " " & "Entrée dans Calcul_Noe_by_Sql(comptage des emissions)")
        y1 = DepartAffichage.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)
        y2 = FinAffichage.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)

        'rvs75 15/10/2012 : réécriture
        Dim sgb As New StringBuilder()

        'contruction de la requete
        With sgb
            .Append(
                "SELECT  COUNT (*), channelid  FROM programtbl, channeltbl  WHERE ([programtbl].[channeliD] = [channeltbl].[id]) AND ((pstart between '")
            .Append(y1.ToString())
            .Append("' AND '")
            .Append(y2.ToString())
            .Append("') OR (PSTOP BETWEEN '")
            .Append(y1.ToString())
            .Append("' AND '")
            .Append(y2.ToString())
            .Append("')) AND (not(PCATEGORYTV is NULL)) GROUP BY channelid")

            dtCalculNoeBySqlBack = db.ExecuteQuery(.ToString())
        End With

        db.CloseDatabase()

        Dim j As Integer
        'dictionary provisoire
        Dim tempdic As New Dictionary(Of String, Integer)
        For j = 0 To dtCalculNoeBySqlBack.Rows.Count - 1
            Dim co As Integer = CInt(dtCalculNoeBySqlBack.Rows(j).Item(0))
            tempdic.Add(dtCalculNoeBySqlBack.Rows(j).Item(1).ToString(), co)
            'som += co
        Next

        NbEmissionsYc0ApresTriParChaine(j + 1) = 0
        For compte = 1 To NbTotalChaines
            Try
                NbEmissionsYc0ApresTriParChaine(compte) = tempdic(TableDesChainesASelectionner(compte))
            Catch ex As Exception
                'plante si la chaine n'est pas dans le dictionary, donc dans la base
            End Try
        Next
        NbEmissionsYc0ApresTriParChaine(compte) = 0

        Trace.WriteLine(DateTime.Now & " " & "Sortie de CalculNoebySql")
    End Sub

    Public Sub GetNamesOfChannelsFromDatabase()

        Dim db As SqLiteBase = New SqLiteBase
        Dim dtChannels As DataTable

        Dim record1 As New ChannelList
        With record1
            .Nom = String.Empty
            .Identificateur = String.Empty
            .Indice = 0
            .Logo = Nothing
        End With

        Dim cpt As Integer
        For cpt = 1 To NbTotalChaines
            TableauChaine(cpt) = record1
        Next cpt

        Dim qwAllChanneltbl As String
        qwAllChanneltbl = "SELECT  Name,ID,ordering,logo FROM Channeltbl ORDER BY ORDERING "

        With db
            .OpenDatabase(BddPath & "db_progs.db3")
            dtChannels = .ExecuteQuery(qwAllChanneltbl)
            .CloseDatabase()
        End With

        Try
            Dim i As Integer
            For i = 0 To dtChannels.Rows.Count - 1
                With TableauChaine(i + 1)
                    .Nom = dtChannels.Rows(i).Item("Name").ToString
                    .Identificateur = dtChannels.Rows(i).Item("ID").ToString
                    .Indice = CInt(dtChannels.Rows(i).Item("ordering"))
                    .Logo = dtChannels.Rows(i).Item("logo").ToString
                End With
            Next
            'ecrire une ligne supplémentaire BB200110
            i = dtChannels.Rows.Count
            Trace.WriteLine(
                DateTime.Now & " " & "i= " & i.ToString & " nom chaine = " & TableauChaine(i).Nom &
                " identif = " & TableauChaine(i).Identificateur & " logo = " &
                TableauChaine(i).Logo)
            Trace.WriteLine(" ")
            NbTotalChaines = dtChannels.Rows.Count
            If NbTotalChaines > Val200 Then
                ReDim Preserve TableauChaine(NbTotalChaines + 1)
                ReDim Preserve TableDesChainesASelectionner(NbTotalChaines + 1)
                ReDim Preserve ChaineLogoUnique(NbTotalChaines + 10)
                ReDim Preserve OrdTopLigne(NbTotalChaines + 10)
            End If

        Catch ex As NullReferenceException
            Trace.WriteLine(DateTime.Now & " " & "Type de données incorrect")
        End Try
    End Sub

    Public Sub GetNbEmissionsFromDb()

        Trace.WriteLine(DateTime.Now & " " & "Entrée requête.vb --> Get_Nb_Emissions_From_Db()")
        ' calcul du nombre d emissions (>35000 pour 160 chaines et 9 jours)
        Dim I As Integer
        Dim qwNumber As String
        Dim db As SqLiteBase = New SqLiteBase
        Dim dtNbEmission As DataTable

        Trace.WriteLine(DateTime.Now & " " & "Lecture nombre d'enregistrements SIGNIFICATIFS")
        qwNumber = "SELECT COUNT(*)  FROM PROGRAMTBL where PCATEGORYTV <> ''"
        db.OpenDatabase(BddPath & "db_progs.db3")
        dtNbEmission = db.ExecuteQuery(qwNumber)
        db.CloseDatabase()

        I = CInt(dtNbEmission.Rows(0).Item(0))
        If I > TailleTle Then
            ReDim Preserve TableauListEmissions(I + 1)
        End If
        Trace.WriteLine(DateTime.Now & " " & "Sortie requête.vb --> Get_Nb_Emissions_From_Db()")
    End Sub

    Public Sub GetListOfEmissionsForSqlWhereAndBetween()

        'indice_courant_TLE = I
        ReDim Preserve TableauListEmissions(TailleTle)
        Dim db As SqLiteBase = New SqLiteBase

        With db
            .OpenDatabase(BddPath & "db_progs.db3")
            IndiceCourantTle = db.ExecuteQuery2TableauListEmissions(Build_Qwery_On_Channels_Where_and_Between(),
                                                                    TableauListEmissions, 1)
            .CloseDatabase()
        End With

        ReDim Preserve TableauListEmissions(IndiceCourantTle + 1)

        NbEmissionsForSqlRequest = IndiceCourantTle - 1
        ReDim Preserve ValLeft(IndiceCourantTle + 1)
        ReDim Preserve ValTop(IndiceCourantTle + 1)
        ReDim Preserve ValWidth(IndiceCourantTle + 1)
        'ReDim Preserve ValBackcolor(IndiceCourantTle + 1)
        ReDim Preserve ValTopLogo(IndiceCourantTle + 1)

        NbRecordLimiteForSqlRequest = NbEmissionsForSqlRequest

        If NbEmissionsForSqlRequest > NbRecordLimiteForSqlRequest Then

            ReDim Preserve ValLeft(NbEmissionsForSqlRequest + 20)
            ReDim Preserve ValTop(NbEmissionsForSqlRequest + 20)
            ReDim Preserve ValWidth(NbEmissionsForSqlRequest + 20)
            'ReDim Preserve ValBackcolor(NbEmissionsForSqlRequest + 20)
            ReDim Preserve ValTopLogo(NbEmissionsForSqlRequest + 20)
        End If
    End Sub

    Public Sub GetListOfEmissionsForCeSoir()

        ' rvs75 18/10/2012 : optimisation simplification
        Dim strSqlCeSoir As New StringBuilder
        Dim vDate1 As String = DateTime.Today.AddHours(19 - DecalHoraire).AddMinutes(45).ToString("yyyy-MM-dd HH:mm")
        Dim vDate2 As String = DateTime.Today.AddHours(22 - DecalHoraire).ToString("yyyy-MM-dd HH:mm")

        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans traitement ce soir")
        Trace.WriteLine(" ")
        Dim tpsEcoule As Long

        With strSqlCeSoir
            .Append("SELECT programtbl.ChannelID , programtbl.PTitle ,programtbl.psubtitle, ")
            .Append("programtbl.Pstart, programtbl.Pstop, programtbl.Pduration, ")
            .Append("programtbl.PCategoryTV , programtbl.PCategory, programtbl.Pdescription,  ")
            .Append("programtbl.Prating , programtbl.pactors ,  programtbl.PDirectors, ")
            .Append("programtbl.Ppresents, programtbl.audiostereo, programtbl.Premiere,")
            .Append("programtbl.Showview, programtbl.subtype, programtbl.Pdate, ")
            .Append("channeltbl.ordering FROM Programtbl , channeltbl ")
            .Append("WHERE (((ProgramTbl.ChannelID)= ChannelTbl.id)) ")

            .Append(" AND(PStart Between '" & vDate1 & "' and '" & vDate2)
            .Append("') AND  (PDuration>=")
            .Append(EmissionDurationCesoir.ToString)
            .Append(") ORDER BY channeltbl.ordering ASC , programtbl.pstart ASC")
            .Append(" limit " & Val200.ToString())
        End With

        Dim db As SqLiteBase = New SqLiteBase
        With db
            .OpenDatabase(BddPath & "db_progs.db3")
            NbEmissionsForCeSoir = db.ExecuteQuery2TableauListEmissions(strSqlCeSoir.ToString,
                                                                        TableauListEmissionsCeSoir, 0)
            .CloseDatabase()
        End With

        Trace.WriteLine(
            DateTime.Now & " " & "Tps execution extraction get list ce_soir = " & tpsEcoule.ToString &
            " msec")

        Trace.WriteLine(" ")
    End Sub

    Public Sub GetNumberOfEmissionsForMaintenant()

        'rvs75 18/10/2012 : optimisation simplification
        Dim strSqlMaintenant As New StringBuilder
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans calcul nb emissions Maintenant")

        Dim date1 As String
        date1 = DateTime.Now.AddHours(-DecalHoraire).ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)

        With strSqlMaintenant
            .Append("SELECT count (*) from programtbl, channeltbl  WHERE (ProgramTbl.ChannelID= ChannelTbl.id) ")

            .Append("AND (PStart <=  '")
            .Append(date1 & "')" & " AND (Pstop >'" & date1 & "') ")
            .Append("And pDuration >= ")
            .Append(EmissionDurationMaintenant.ToString)
        End With

        Dim I As Integer = 0
        Dim db As SqLiteBase = New SqLiteBase
        Dim dtGetNumberOfEmissionsForMaintenant As DataTable
        With db
            .OpenDatabase(BddPath & "db_progs.db3")
            dtGetNumberOfEmissionsForMaintenant = .ExecuteQuery(strSqlMaintenant.ToString)
            .CloseDatabase()
        End With
        Try
            I = CInt(dtGetNumberOfEmissionsForMaintenant.Rows(0).Item(0))
        Catch ex As InvalidOperationException
            Trace.WriteLine(DateTime.Now & " Invalid operation exception error " & ex.Message)
        End Try
        NbEmissionsForMaintenant = I
    End Sub

    Public Sub GetListOfEmissionsForMaintenant()

        'rvs75 18/10/2012 : optimisation simplification
        Dim strSqlMaintenant As New StringBuilder

        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans traitement Maintenant")

        Dim date1 As String
        date1 = DateTime.Now.AddHours(-DecalHoraire).ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)
        With strSqlMaintenant
            .Append("SELECT programtbl.ChannelID , programtbl.PTitle ,programtbl.psubtitle, ")
            .Append("programtbl.Pstart, programtbl.Pstop, programtbl.Pduration, ")
            .Append("programtbl.PCategoryTV , programtbl.PCategory, programtbl.Pdescription,  ")
            .Append("programtbl.Prating , programtbl.pactors ,  programtbl.PDirectors, ")
            .Append("programtbl.Ppresents, programtbl.audiostereo, programtbl.Premiere,")
            .Append("programtbl.Showview, programtbl.subtype, programtbl.Pdate, ")
            .Append("channeltbl.ordering FROM Programtbl , channeltbl ")
            .Append("WHERE (((ProgramTbl.ChannelID)= ChannelTbl.id)) ")

            .Append("AND (PStart <=  '")
            .Append(date1 & "')" & " AND (Pstop > '" & date1 & "') And pDuration >= ")
            .Append(EmissionDurationMaintenant.ToString)
            .Append(" ORDER by channeltbl.ordering ASC")
            .Append(" limit " & Val200.ToString())
        End With

        Dim db As SqLiteBase = New SqLiteBase
        With db
            .OpenDatabase(BddPath & "db_progs.db3")
            NbEmissionsForMaintenant = db.ExecuteQuery2TableauListEmissions(strSqlMaintenant.ToString,
                                                                            TableauListEmissionsMaintenant, 0)
            .CloseDatabase()
        End With
    End Sub

    Public Function Build_Qwery_On_Channels_Where_and_Between() As String

        ' l ordre ds tableau_list_emission sera l ordre alphabetique
        ' des chaines selon l ordre sql " ORDER BY ORDERING"
        ' input:table_des_chaines_a_selectionner
        ' ouput : qw_on_channels
        ' ON calule ci dessous la chaine qw_on_channels()
        ' qui est en fait la commande SQl qui sera appliquée
        ' a la base de donnée
        ' *************************************************************
        ' en fait la quantite de données triées dépend de
        ' Pstart =départ_affichage défini avant d entrer dans cette SR()
        ' Pstop=fin affichage défini avant d'entrer dans cette SR
        ' cad dans initialisations_diverses


        'rvs75 16/10/2012 : Simplification + optimisation
        Dim sb As New StringBuilder
        Dim y1 As String
        Dim y2 As String
        Dim i As Integer
        Const sor As Integer = 4
        With sb
            .Append("SELECT programtbl.ChannelID , programtbl.PTitle ,programtbl.psubtitle, ")
            .Append("programtbl.Pstart, programtbl.Pstop, programtbl.Pduration, ")
            .Append("programtbl.PCategoryTV , programtbl.PCategory, programtbl.Pdescription,  ")
            .Append("programtbl.Prating , programtbl.pactors ,  programtbl.PDirectors, ")
            .Append("programtbl.Ppresents, programtbl.audiostereo, programtbl.Premiere,")
            .Append("programtbl.Showview, programtbl.subtype, programtbl.Pdate, ")
            .Append("channeltbl.ordering FROM Programtbl , channeltbl ")
            .Append(" WHERE ([programtbl].[channeliD] = [channeltbl].[id])  AND (")
        End With

        For i = 1 To NbTotalChaines
            sb.Append("ChannelID='" & TableDesChainesASelectionner(i) & "' OR ")
        Next i

        sb.Remove(sb.Length - sor, sor)

        y1 = DepartAffichage.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)
        y2 = FinAffichage.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)

        With sb
            .Append(") AND ((pstart between '" & y1)
            .Append("' AND '" & y2 & "') OR (PSTOP BETWEEN '" & y1)
            .Append("' AND '" & y2)
            .Append("')) AND (PCATEGORYTV <>'')")
            .Append(" ORDER BY channeltbl.ordering ASC , programtbl.Pstart ASC")
            .Append(" limit " & TailleTle.ToString())
        End With

        'QwOnChannels = sb.ToString
        Return sb.ToString()
    End Function

    Function BasePerimee() As Boolean

        ' 14/12/2009 rvs75 function renvoyant true si la fin de la dernière émission
        ' est antérieure à aujourd'hui sinon renvoie false
        Dim dtBasePerimee As DataTable
        Dim db As SqLiteBase = New SqLiteBase
        db.OpenDatabase(BddPath & "db_progs.db3")
        dtBasePerimee = db.ExecuteQuery("select version from control")
        If Not dtBasePerimee.Rows(0).Item(0).ToString().Equals(DbMajorVersion.ToString & "." & DbMinorVersion.ToString) Then
            db.CloseDatabase()
            Return True
        End If
        dtBasePerimee = db.ExecuteQuery("select max(programtbl.Pstop) as lastEmission from programtbl;")
        db.CloseDatabase()
        Dim a As Integer
        a = dtBasePerimee.Rows.Count
        If a > 0 Then
            Dim b As Object
            b = dtBasePerimee.Rows(0).Item(0)
            If b Is "" OrElse
            DateDiff("h", CDate(b), DateTime.Now) >= 0 Then
                'BasePerimee = True
                'Exit Function
                Return True
            End If
        ElseIf a = 0 Then
            Return True
        Else
            Return False
        End If

        'If _
        '    a = 0  Then

        'Else
        '    BasePerimee = False
        'End If
    End Function
End Module

