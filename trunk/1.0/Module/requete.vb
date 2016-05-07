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
Imports System.Runtime.CompilerServices
Imports System.IO
Imports System.Text
Imports ZGuideTV.SQLiteWrapper
Imports System.Globalization

Friend Module requete
    Public cat_distincte_fran(nb_maxi_type_emission) As String
    Public cat_distincte_etran(nb_maxi_type_emission) As String
    'Public nb_categorie_preetablie As Integer

    Public Sub Calcul_Noe_By_Sql()

        ' calcul du nb d emissions pour chaque chaine
        Dim som As Integer
        Dim compte As Integer
        Dim I As Integer = 0
        Dim qw_number As String
        Dim sb As String
        Dim s1 As String
        Dim y1 As String
        Dim y2 As String

        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        Dim dt_Calcul_Noe_By_Sql_back As DataTable

#If DEBUG Then
        Dim mon_stpw As New Stopwatch
        Dim duree As Double
        mon_stpw.Start()
#End If

        Trace.WriteLine(DateTime.Now & " " & "Entrée dans Calcul_Noe_by_Sql(comptage des emissions)")
        y1 = depart_affichage.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)
        y2 = fin_affichage.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)

        sb = "SELECT  COUNT (*) FROM programtbl, channeltbl " & " WHERE ([programtbl].[channeliD] = [channeltbl].[id]) " & _
             " AND ((pstart between '" & y1.ToString & "'" & " AND '" & y2.ToString & "') OR (PSTOP BETWEEN '" & _
             y1.ToString & "' " & " AND '" & y2.ToString & "'))" & " AND (not(PCATEGORYTV is NULL))" & _
             " AND (CHANNELID = '"

        For compte = 1 To nb_total_chaines
            nb_emissions_yc0_apres_tri_par_chaine(compte) = 0
            s1 = table_des_chaines_a_selectionner(compte)
            qw_number = sb & s1 & "')"
            Try
                dt_Calcul_Noe_By_Sql_back = db.ExecuteQuery(qw_number)
                I = CInt(dt_Calcul_Noe_By_Sql_back.Rows(0).Item(0))
            Catch ex As InvalidOperationException
                Trace.WriteLine(DateTime.Now & " Invalid operation exception error " & ex.Message)
                ex = Nothing
            End Try
            nb_emissions_yc0_apres_tri_par_chaine(compte) = I
            I = 0
        Next compte
        nb_emissions_yc0_apres_tri_par_chaine(compte) = 0
        db.CloseDatabase()
        db = Nothing
        dt_Calcul_Noe_By_Sql_back = Nothing

#If DEBUG Then
        mon_stpw.Stop()
        duree = mon_stpw.ElapsedMilliseconds
        Trace.WriteLine( _
                         datetime.now & " " & _
                         "Temps pour le calcul des nombres d'émissions (y compris les valeurs nulles = " & _
                         duree.ToString)
        mon_stpw = Nothing
#End If

        som = 0
        Trace.WriteLine(DateTime.Now & " " & "List of empty channels")
        For I = 1 To nb_total_chaines + 1

#If DEBUG Then

            Trace.WriteLine( _
                             datetime.now & " " & "i= " & I.ToString & "    " & _
                            nb_emissions_yc0_apres_tri_par_chaine(I).ToString)
#End If

            som += nb_emissions_yc0_apres_tri_par_chaine(I)
        Next I
        Trace.WriteLine(DateTime.Now & " " & "Somme de tous les list... = " & som.ToString)
        dt_Calcul_Noe_By_Sql_back = Nothing
    End Sub

    Public Sub Get_Names_Of_Channels_From_Database()
        ' •—————————————————————————————————————————————————————————————————•
        ' | ' input BDD channeltbl                                          |
        ' | ' exemple                                                       |
        ' | 'nom            identificateur      ordering    logo            |
        ' | '13 eme rue     C39.telepoche.com   1            13emerue.gif   |
        ' | 'output : remplit tableau_chaine(i)                             |
        ' | ' initialisation necessaire car faite au demarrage par des      | 
        ' | 'declarations                                                   |
        ' •—————————————————————————————————————————————————————————————————•
        Dim db As SQLiteBase = New SQLiteBase
        Dim dt_channels As DataTable

        Dim record1 As New channel_list
        With record1
            .nom = String.Empty
            .identificateur = String.Empty
            .indice = 0
            .logo = Nothing
        End With

        Dim cpt As Integer
        For cpt = 1 To nb_total_chaines
            tableau_chaine(cpt) = record1
        Next cpt

        Dim qw_all_channeltbl As String
        qw_all_channeltbl = "SELECT  Name,ID,ordering,logo FROM Channeltbl ORDER BY ORDERING "

#If DEBUG Then
        Trace.WriteLine(" ")
        Trace.WriteLine(datetime.now & " " & "Liste des chaines et identificateur")
#End If

        With db
            .OpenDatabase(BDDPath & "db_progs.db3")
            dt_channels = .ExecuteQuery(qw_all_channeltbl)
            .CloseDatabase()
            db = Nothing
        End With

        Try
            Dim i As Integer
            For i = 0 To dt_channels.Rows.Count - 1
                With tableau_chaine(i + 1)
                    .nom = dt_channels.Rows(i).Item("Name").ToString
                    .identificateur = dt_channels.Rows(i).Item("ID").ToString
                    .indice = CInt(dt_channels.Rows(i).Item("ordering"))
                    .logo = dt_channels.Rows(i).Item("logo").ToString
                End With
#If DEBUG Then
                Trace.WriteLine( _
                                 datetime.now & " " & "i= " & i.ToString & " nom chaine = " & tableau_chaine(i).nom & _
                                 " identif = " & tableau_chaine(i).identificateur & " logo = " & _
                                 tableau_chaine(i).logo)
#End If
            Next
            'ecrire une ligne supplémentaire BB200110
            i = dt_channels.Rows.Count
            Trace.WriteLine( _
                             DateTime.Now & " " & "i= " & i.ToString & " nom chaine = " & tableau_chaine(i).nom & _
                             " identif = " & tableau_chaine(i).identificateur & " logo = " & _
                             tableau_chaine(i).logo)
            Trace.WriteLine(" ")
            nb_total_chaines = dt_channels.Rows.Count
            If nb_total_chaines > val200 Then
                ReDim Preserve tableau_chaine(nb_total_chaines + 1)
                ReDim Preserve table_des_chaines_a_selectionner(nb_total_chaines + 1)
                ReDim Preserve chaine_logo_unique(nb_total_chaines + 10)
                ReDim Preserve ord_top_ligne(nb_total_chaines + 10)
            End If

        Catch ex As NullReferenceException
            Trace.WriteLine(DateTime.Now & " " & "Type de données incorrect")
            ex = Nothing
        End Try
    End Sub

    Public Sub Get_Nb_Emissions_From_Db()


        Trace.WriteLine(DateTime.Now & " " & "Entrée requête.vb --> Get_Nb_Emissions_From_Db()")
        ' calcul du nombre d emissions (>35000 pour 160 chaines et 9 jours)
        Dim I As Integer = 0
        Dim qw_number As String
        Dim db As SQLiteBase = New SQLiteBase
        Dim dt_nb_emission As DataTable

        Trace.WriteLine(DateTime.Now & " " & "Lecture nombre d'enregistrements SIGNIFICATIFS")
        qw_number = "SELECT COUNT(*)  FROM PROGRAMTBL where PCATEGORYTV <> ''"
        db.OpenDatabase(BDDPath & "db_progs.db3")
        dt_nb_emission = db.ExecuteQuery(qw_number)
        db.CloseDatabase()
        db = Nothing

        I = CInt(dt_nb_emission.Rows(0).Item(0))
        If I > taille_TLE Then
            ReDim Preserve tableau_list_emissions(I + 1)
        End If
        Trace.WriteLine(DateTime.Now & " " & "Sortie requête.vb --> Get_Nb_Emissions_From_Db()")
    End Sub

    Public Sub Get_Types_Of_Emissions_for_period()

        'inutile mais gardé pour le merge
        'a retirer après que le code soit sur le svn
    End Sub

    Public Sub Get_List_Of_Emissions_For_Sql_Where_and_Between()

        ' input : qw_on_channels
        ' ouput: tableau_list_emissions

        '#If DEBUG Then
        '        Dim tps_ecoule As Long
        '        Dim monstopwatch As New Stopwatch
        '        monstopwatch.Start()
        '#End If
        Dim I As Integer = indice_courant_TLE
        '#If DEBUG Then
        '        Trace.WriteLine(DateTime.Now & " " & qw_on_channels)
        '#End If
        '        Dim dt_Get_List_Of_Emissions_For_Sql_Where_and_Between As DataTable


        'RuntimeHelpers.PrepareConstrainedRegions()
        'Try
        'Catch
        'Finally
        '    Dim db2 As SQLiteBase = New SQLiteBase
        '    db2.OpenDatabase(BDDPath & "db_progs.db3")
        '    dt_Get_List_Of_Emissions_For_Sql_Where_and_Between = db2.ExecuteQuery(qw_on_channels)
        '    db2.CloseDatabase()
        '    db2 = Nothing

        'End Try

        'ReDim Preserve tableau_list_emissions(dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows.Count + 1)
        '#If DEBUG Then
        '        monstopwatch.Stop()
        '        tps_ecoule = monstopwatch.ElapsedMilliseconds
        '        monstopwatch = Nothing
        '        Trace.WriteLine( _
        '                         datetime.now & " " & "Tps exécution pour connection de get list of emissions = " & _
        '                         tps_ecoule.ToString & " msec")
        '        Dim monstopwatch1 As New Stopwatch
        '        monstopwatch1.Start()

        '#End If
        'Try
        '    For r As Integer = 0 To dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows.Count - 1
        '        With tableau_list_emissions(I)
        '            Try
        '                .ChannelID = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(0).ToString
        '                .Ptitle = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(1).ToString
        '                .Psubtitle = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(2).ToString
        '                .pstart = CDate(dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(3))
        '                .pstop = CDate(dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(4))
        '                .Pduration = CInt(dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(5))
        '                .PcategoryTV = _
        '                    dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(6).ToString.TrimEnd
        '                .Pdescription = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(7).ToString
        '                '290310 .pstar = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(8).ToString
        '                .prating = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(8).ToString
        '                .Pactors = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(9).ToString
        '                .Audiostereo = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(10).ToString ' BB 270310
        '                .Premiere = CInt(dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(11)) ' BB 270310
        '                .Showview = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(12).ToString ' BB 270310
        '                .Subtype = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(13).ToString ' BB 270310
        '                .Pdate = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(14).ToString ' BB 270310
        '                If .PcategoryTV = "" Then I = I - 1
        '                ' on elimine les emissions sans categorie
        '            Catch ex As Exception

        '                Trace.WriteLine(DateTime.Now & " ", ex.Message)
        '                ex = Nothing
        '            End Try
        '        End With
        '        I += 1
        '    Next
        'Catch ex As NullReferenceException

        '    Trace.WriteLine(DateTime.Now & " " & "Non respect des types de données dans db_progs.db3")
        '    ex = Nothing
        'End Try
        '#If DEBUG Then
        '        monstopwatch1.Stop()
        '        tps_ecoule = monstopwatch1.ElapsedMilliseconds
        '        monstopwatch1 = Nothing
        '        Trace.WriteLine(datetime.now & " " & "Tps execution extraction get list = " & tps_ecoule.ToString & " msec")
        '        tps_ecoule = Nothing
        '#End If

        'indice_courant_TLE = I
        ReDim Preserve tableau_list_emissions(taille_TLE)
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        indice_courant_TLE = db.ExecuteQuery2tableau_list_emissions(qw_on_channels)
        db.CloseDatabase()
        db = Nothing

        ReDim Preserve tableau_list_emissions(indice_courant_TLE + 1)


        nb_emissions_for_SQL_Request = indice_courant_TLE - 1
        ReDim Preserve val_left(indice_courant_TLE + 1)
        ReDim Preserve val_top(indice_courant_TLE + 1)
        ReDim Preserve val_width(indice_courant_TLE + 1)
        ReDim Preserve val_backcolor(indice_courant_TLE + 1)
        ReDim Preserve val_top_logo(indice_courant_TLE + 1)

        nb_record_limite_for_sql_request = nb_emissions_for_SQL_Request
#If DEBUG Then
        Trace.WriteLine(datetime.now & " " & "Nombre d'émissions = " & nb_emissions_for_SQL_Request.ToString)
#End If
        'reader.Close()
#If DEBUG Then

        ' impression des 20 premières et 20 dernières emissions
        Trace.WriteLine(datetime.now & " date  pour les lignes suivantes " & datetime.now)
        Trace.WriteLine(" ")
        For I = 1 To Math.Min(20, nb_emissions_for_SQL_Request)
            Trace.WriteLine( _
                             "i=" & I.ToString & " cha_id=" & tableau_list_emissions(I).ChannelID & " pstart=" & _
                             tableau_list_emissions(I).pstart & " pstop=" & tableau_list_emissions(I).pstop & _
                             " dur.=" & tableau_list_emissions(I).Pduration & " categor =" & _
                             tableau_list_emissions(I).PcategoryTV & " " & tableau_list_emissions(I).Ptitle)
        Next I
        Trace.WriteLine(" ")
        For I = Math.Max(0, nb_emissions_for_SQL_Request - 20) To Math.Max(0, nb_emissions_for_SQL_Request)
            Trace.WriteLine( _
                             "i=" & I.ToString & " cha_id=" & tableau_list_emissions(I).ChannelID & " pstart=" & _
                             tableau_list_emissions(I).pstart & " pstop=" & tableau_list_emissions(I).pstop & _
                             " dur.=" & tableau_list_emissions(I).Pduration & " categor =" & _
                             tableau_list_emissions(I).PcategoryTV & " " & tableau_list_emissions(I).Ptitle)
        Next I
        Trace.WriteLine(" ")
#End If

        If nb_emissions_for_SQL_Request > nb_record_limite_for_sql_request Then
#If DEBUG Then
            Trace.WriteLine(datetime.now & " " & "Taille limite atteinte, redimENSIONNEMENT ")
#End If

            ReDim Preserve val_left(nb_emissions_for_SQL_Request + 20)
            ReDim Preserve val_top(nb_emissions_for_SQL_Request + 20)
            ReDim Preserve val_width(nb_emissions_for_SQL_Request + 20)
            ReDim Preserve val_backcolor(nb_emissions_for_SQL_Request + 20)
            ReDim Preserve val_top_logo(nb_emissions_for_SQL_Request + 20)
        End If
        'dt_Get_List_Of_Emissions_For_Sql_Where_and_Between = Nothing
    End Sub

    Public Sub Get_List_Of_Emissions_For_ce_soir()
        Dim s1 As String
        Dim s2 As String
        Dim S3 As String

        'Dim date1 As New DateTime
        ''020210
        'Dim date2 As New DateTime
        ''020210

        'calcul de la date(avec décalage horaire) qui correspond à 19h45
        's1 = DateTime.Now.ToString ("yyyy-MM-dd 19:45")

        'date1 = DateTime.Parse (s1)
        'date2 = date1.AddHours (- decal_horaire)
        'Dim V_Date_1 As String = date2.ToString("yyyy-MM-dd HH:mm")
        Dim V_Date_1 As String = DateTime.Today.AddHours(19 - decal_horaire).AddMinutes(45).ToString("yyyy-MM-dd HH:mm")
        '050210
        'Dim V_Date_1 As String = Date.Now().ToString("yyyy-MM-dd 19:45")


        'calcul de la date(avec décalage horaire) qui correspond à 22h00
        's1 = DateTime.Now.ToString ("yyyy-MM-dd 22:00")
        '020210
        'date1 = DateTime.Parse (s1)
        'date2 = date1.AddHours (- decal_horaire)
        'Dim V_Date_2 As String = date2.ToString("yyyy-MM-dd HH:mm")
        Dim V_Date_2 As String = DateTime.Today.AddHours(22 - decal_horaire).ToString("yyyy-MM-dd HH:mm")
        '050210
        'Dim V_Date_2 As String = Date.Now().ToString("yyyy-MM-dd 22:00")

        ' input : qw_on_channels
        ' ouput: tableau_list_emissions_ce_soir

        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans traitement ce soir")
        Trace.WriteLine(" ")
        Dim tps_ecoule As Long

        Select Case des_canaux_sont_memorises
            Case False

                s1 = "SELECT ProgramTbl.PTitle,Programtbl.Psubtitle,ProgramTbl.ChannelID ,Programtbl.PStart, " _
                     & " Programtbl.Pduration,programtbl.PcategoryTV, programtbl.Pcategory , Programtbl.Pstop,Programtbl.Pactors, " _
                     & " Programtbl.Pdescription,Programtbl.Prating,  " _
                     & _
                     " Programtbl.audiostereo,programtbl.premiere,programtbl.showview,programtbl.subtype,programtbl.Pdate " _
                     & " FROM ProgramTbl, ChannelTbl  " & _
                     " WHERE (((ProgramTbl.ChannelID)= ChannelTbl.id))" _
                     & " AND(PStart Between '" & V_Date_1 & "' and '" & V_Date_2 & "')" & _
                     " AND  (PDuration>="
                s2 = emission_duration_cesoir.ToString & ")"
                S3 = " ORDER BY channeltbl.ordering ASC , programtbl.pstart ASC"
                str_sql_ce_soir = s1 & s2 & S3
            Case True

                s1 = "SELECT ProgramTbl.PTitle,Programtbl.Psubtitle,ProgramTbl.ChannelID ,Programtbl.PStart, " _
                     & " Programtbl.Pduration,programtbl.PcategoryTV ,programtbl.Pcategory, Programtbl.Pstop,Programtbl.Pactors, " _
                     & " Programtbl.Pdescription,Programtbl.Prating,  " _
                     & _
                     " Programtbl.audiostereo,programtbl.premiere,programtbl.showview, programtbl.subtype,programtbl.Pdate " _
                     & " FROM ProgramTbl, ChannelTbl  " & _
                     " WHERE (((ProgramTbl.ChannelID)= ChannelTbl.id))" _
                     & " AND  (" & nom_des_chaines_memorisees & ")" & " " _
                     & " AND(PStart Between '" & V_Date_1 & "' and '" & V_Date_2 & "')" & _
                     " AND  (PDuration>="
                s2 = emission_duration_cesoir.ToString & ")"
                S3 = " ORDER BY channeltbl.ordering ASC , programtbl.pstart ASC"
                str_sql_ce_soir = s1 & s2 & S3
        End Select


        Dim I As Integer = 0
#If DEBUG Then
        Trace.WriteLine(datetime.now & " " & str_sql_ce_soir)
#End If
        Dim dt_Get_List_Of_Emissions_For_ce_soir As DataTable = New DataTable

        RuntimeHelpers.PrepareConstrainedRegions()
        Try
        Catch
        Finally
            Dim db As SQLiteBase = New SQLiteBase
            With db
                .OpenDatabase(BDDPath & "db_progs.db3")
                dt_Get_List_Of_Emissions_For_ce_soir = db.ExecuteQuery(str_sql_ce_soir)
                .CloseDatabase()
                db = Nothing
            End With
        End Try


        nb_emissions_for_ce_soir = dt_Get_List_Of_Emissions_For_ce_soir.Rows.Count
#If DEBUG Then
        Dim monstopwatch1 As New Stopwatch
        monstopwatch1.Start()
#End If
        Try
            For r As Integer = 0 To dt_Get_List_Of_Emissions_For_ce_soir.Rows.Count - 1
                With tableau_list_emissions_ce_soir(I)
                    Try
                        .Ptitle = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(0).ToString
                        .Psubtitle = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(1).ToString
                        .ChannelID = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(2).ToString
                        .pstart = CDate(dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(3))
                        .Pduration = CInt(dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(4))
                        .PcategoryTV = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(5).ToString
                        .Pcategory = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(6).ToString
                        .pstop = CDate(dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(7))
                        .Pactors = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(8).ToString
                        .Pdescription = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(9).ToString
                        .prating = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(10).ToString
                        '290310 .Pstar = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(10).ToString
                        .Audiostereo = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(11).ToString
                        .Premiere = CInt(dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(12))
                        .Showview = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(13).ToString
                        .Subtype = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(14).ToString
                        .Pdate = dt_Get_List_Of_Emissions_For_ce_soir.Rows(r).Item(15).ToString

                        '#If DEBUG Then
                        '                       Trace.WriteLine( _
                        '                                       "channel id = " & .channelID & "titre= " & .Ptitle & " " & "Pstart = " & _
                        '                                      .Pstart & " " & "duree= " & .Pduration.ToString & " " & "catego= " & _
                        '                                     .PcategoryTV)
                        '#End If
                    Catch ex As Exception

                        Trace.WriteLine(DateTime.Now & " exception error " & ex.Message)
                        ex = Nothing
                    End Try
                End With
                I += 1
            Next
        Catch ex As NullReferenceException

            Trace.WriteLine(DateTime.Now & " " & "Non respect des types de données dans db_progs.db3")
        End Try
#If DEBUG Then
        monstopwatch1.Stop()
        tps_ecoule = monstopwatch1.ElapsedMilliseconds
        monstopwatch1 = Nothing
#End If
        Trace.WriteLine( _
                         DateTime.Now & " " & "Tps execution extraction get list ce_soir = " & tps_ecoule.ToString & _
                         " msec")
        nb_emissions_for_ce_soir = I
#If DEBUG Then
        Trace.WriteLine(datetime.now & " " & "Nombre d'émissions ce soir = " & nb_emissions_for_ce_soir.ToString)
#End If
#If DEBUG Then
        Trace.WriteLine(datetime.now & " " & "Liste des emissions ce soir ")
        Trace.WriteLine(" ")

        ' impression des 10 prem. et 10 dern. emissions de ce soir
        For I = 0 To Math.Min(10, nb_emissions_for_ce_soir - 1)
            Trace.WriteLine( _
                             datetime.now & " " & "i=" & I.ToString & " cha_id=" & _
                             tableau_list_emissions_ce_soir(I).channelID & " pstart=" & _
                             tableau_list_emissions_ce_soir(I).Pstart & " dur.=" & _
                             tableau_list_emissions_ce_soir(I).Pduration & "  " & _
                             tableau_list_emissions_ce_soir(I).Ptitle)
        Next I
        Trace.WriteLine(" ")
        For I = Math.Max(0, nb_emissions_for_ce_soir - 10) To Math.Max(0, nb_emissions_for_ce_soir - 1)
            Trace.WriteLine( _
                             DateTime.Now & " " & "i=" & I.ToString & " cha_id=" & _
                             tableau_list_emissions_ce_soir(I).ChannelID & " pstart=" & _
                             tableau_list_emissions_ce_soir(I).pstart & " dur.=" & _
                             tableau_list_emissions_ce_soir(I).Pduration & "  " & _
                             tableau_list_emissions_ce_soir(I).Ptitle)
        Next I
#End If

        Trace.WriteLine(" ")
        s1 = Nothing
        s2 = Nothing
        S3 = Nothing
        dt_Get_List_Of_Emissions_For_ce_soir = Nothing
    End Sub

    Public Sub Get_number_Of_Emissions_For_Maintenant()

        Dim s1 As String
        Dim s2 As String
        Dim s3 As String
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans calcul nb emissions Maintenant")

        Dim date1 As String
        'date1 = DateTime.Now.ToString ("yyyy-MM-dd HH:mm")
        date1 = DateTime.Now.AddHours(-decal_horaire).ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)
        '120210
        Select Case des_canaux_sont_memorises
            Case False
                s1 = _
                    "SELECT count (*) from programtbl, channeltbl  WHERE (ProgramTbl.ChannelID= ChannelTbl.id) AND (PStart <=  '" _
                    & date1 & "')" & " AND (Pstop >'" & date1 & "') " _
                    & " And pDuration >= "
                s2 = emission_duration_maintenant.ToString
                s3 = ""
                str_sql_Maintenant = s1 & s2 & s3
            Case True
                s1 = _
                    "SELECT count (*) from programtbl, channeltbl  WHERE (ProgramTbl.ChannelID= ChannelTbl.id) " _
                    & " AND  (" & nom_des_chaines_memorisees & ")" & " " _
                    & " AND (PStart <=  '" _
                    & date1 & "')" & " AND (Pstop > '" & date1 & "') " _
                    & " And pDuration >= "
                s2 = emission_duration_maintenant.ToString
                s3 = ""
                str_sql_Maintenant = s1 & s2 & s3
        End Select

        Dim I As Integer = 0
#If DEBUG Then
        Trace.WriteLine(datetime.now & " " & str_sql_Maintenant)
#End If

        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        Dim dt_Get_number_Of_Emissions_For_Maintenant As DataTable
        dt_Get_number_Of_Emissions_For_Maintenant = db.ExecuteQuery(str_sql_Maintenant)
        db.CloseDatabase()
        db = Nothing
        Try
            I = CInt(dt_Get_number_Of_Emissions_For_Maintenant.Rows(0).Item(0))
        Catch ex As InvalidOperationException

            Trace.WriteLine(DateTime.Now & " Invalid operation exception error " & ex.Message)
            ex = Nothing
        End Try
        nb_emissions_for_Maintenant = I
#If DEBUG Then
        Trace.WriteLine( _
                         datetime.now & " " & "Nombre d'émissions maintenant = " & _
                         nb_emissions_for_Maintenant.ToString)
#End If
        s1 = Nothing
        s2 = Nothing
        s3 = Nothing

        dt_Get_number_Of_Emissions_For_Maintenant = Nothing
    End Sub

    Public Sub Get_List_Of_Emissions_For_Maintenant()
        Dim s1 As String
        Dim s2 As String
        Dim s3 As String
        Dim s4 As String

        ' input : qw_on_channels
        ' ouput: tableau_list_emissions_maintenant
        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "Entrée dans traitement Maintenant")

        'calcul de la date avec decalage horaire qui correspond a "maintenant"
        Dim date1 As String
        date1 = DateTime.Now.AddHours(-decal_horaire).ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)
        '020210

        Select Case des_canaux_sont_memorises
            Case False
                s1 = "SELECT distinct (channeltbl.ordering), ProgramTbl.PTitle,ProgramTbl.PsubTitle,ProgramTbl.ChannelID ," _
                     & _
                     "Programtbl.PStart,Programtbl.Pduration,ProgramTbl.PcategoryTv,ProgramTbl.Pcategory,ProgramTbl.Pstop, ProgramTbl.Pactors,ProgramTbl.Pdescription, ProgramTbl.Prating, " & _
                     " programtbl.audiostereo,programtbl.premiere,programtbl.showview, programtbl.subtype,programtbl.pdate   FROM ProgramTbl, ChannelTbl " & _
                     "WHERE (((ProgramTbl.ChannelID)= ChannelTbl.id))AND (PStart <=  '" _
                     & date1 & "')" & " AND (Pstop > '" & date1 & "') " _
                     & " And pDuration >= "
                s2 = emission_duration_maintenant.ToString
                s3 = ""
                s4 = " ORDER by channeltbl.ordering ASC"

                str_sql_Maintenant = s1 & s2 & s3 & s4

            Case True
                s1 = "SELECT distinct (channeltbl.ordering), ProgramTbl.PTitle,ProgramTbl.PsubTitle,ProgramTbl.ChannelID ," _
                     & _
                     "Programtbl.PStart,Programtbl.Pduration,ProgramTbl.PcategoryTv,ProgramTbl.Pcategory,ProgramTbl.Pstop, ProgramTbl.Pactors,ProgramTbl.Pdescription, ProgramTbl.Prating, " & _
                     " programtbl.audiostereo,programtbl.premiere,programtbl.showview, programtbl.subtype,programtbl.pdate  FROM ProgramTbl, ChannelTbl " & _
                     "WHERE (((ProgramTbl.ChannelID)= ChannelTbl.id))" _
                     & " AND  (" & nom_des_chaines_memorisees & ")" & " " _
                     & "AND (PStart <=  '" _
                     & date1 & "')" & " AND (Pstop > '" & date1 & "') " _
                     & " And pDuration >= "
                s2 = emission_duration_maintenant.ToString
                s3 = ""
                s4 = " ORDER by channeltbl.ordering ASC"

                str_sql_Maintenant = s1 & s2 & s3 & s4

        End Select

        Dim I As Integer = 0
#If DEBUG Then
        Trace.WriteLine(datetime.now & " " & str_sql_Maintenant)
#End If
        Dim dt_Get_List_Of_Emissions_For_Maintenant As DataTable = New DataTable
        RuntimeHelpers.PrepareConstrainedRegions()
        Try
        Catch
        Finally
            Dim db As SQLiteBase = New SQLiteBase
            db.OpenDatabase(BDDPath & "db_progs.db3")
            dt_Get_List_Of_Emissions_For_Maintenant = db.ExecuteQuery(str_sql_Maintenant)
            db.CloseDatabase()
            db = Nothing
        End Try

        nb_emissions_for_Maintenant = dt_Get_List_Of_Emissions_For_Maintenant.Rows.Count

#If DEBUG Then
        Dim monstopwatch1 As New Stopwatch
        monstopwatch1.Start()
        Dim tps_ecoule As Long
#End If

        Try
            For r As Integer = 0 To dt_Get_List_Of_Emissions_For_Maintenant.Rows.Count - 1
                With tableau_list_emissions_Maintenant(I)
                    Try
                        .Ptitle = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(1).ToString
                        .Psubtitle = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(2).ToString
                        .ChannelID = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(3).ToString
                        .pstart = CDate(dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(4))
                        .Pduration = CInt(dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(5))
                        .PcategoryTV = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(6).ToString
                        .Pcategory = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(7).ToString
                        .pstop = CDate(dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(8))
                        .Pactors = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(9).ToString
                        .Pdescription = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(10).ToString
                        .prating = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(11).ToString
                        '290310.Pstar = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(11).ToString
                        .Audiostereo = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(12).ToString
                        .Premiere = CInt(dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(13))
                        .Showview = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(14).ToString
                        .Subtype = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(15).ToString
                        .Pdate = dt_Get_List_Of_Emissions_For_Maintenant.Rows(r).Item(16).ToString
#If DEBUG Then
                        Trace.WriteLine(" id = " & .ChannelID & " titre= " & .Ptitle & " " & "Pstart = " & _
                                         .pstart & " " & "duree= " & .Pduration.ToString & " " & "catego= " & _
                                         .PcategoryTV)
#End If
                    Catch ex As Exception

                        Trace.WriteLine(DateTime.Now & " exception " & ex.Message)
                        ex = Nothing
                    End Try
                End With
                I += 1
            Next

        Catch ex As NullReferenceException

            Trace.WriteLine(DateTime.Now & " " & "Non respect des types de données dans db_progs.db3")
            ex = Nothing
        End Try
#If DEBUG Then
        monstopwatch1.Stop()
        tps_ecoule = monstopwatch1.ElapsedMilliseconds
        monstopwatch1 = Nothing
        Trace.WriteLine( _
                         datetime.now & " " & "Tps exécution extraction get list Maintenant = " & _
                         tps_ecoule.ToString & " msec")
#End If

        nb_emissions_for_Maintenant = I
#If DEBUG Then
        Trace.WriteLine( _
                         datetime.now & " " & "Nombre d'émissions maintenant = " & _
                         nb_emissions_for_Maintenant.ToString)
#End If
        'reader.Close()

#If DEBUG Then
        Trace.WriteLine(datetime.now & " " & "Liste des émissions Maintenant ")
        Trace.WriteLine(" ")

        ' impression des 10 prem. et 10 dern. emissions de ce soir
        For I = 0 To Math.Min(10, nb_emissions_for_Maintenant - 1)
            Trace.WriteLine( _
                             datetime.now & " " & "i=" & I.ToString & " cha_id=" & _
                             tableau_list_emissions_Maintenant(I).channelID & " pstart=" & _
                             tableau_list_emissions_Maintenant(I).Pstart & " dur.=" & _
                             tableau_list_emissions_Maintenant(I).Pduration & "  " & _
                             tableau_list_emissions_Maintenant(I).Ptitle)
        Next I
        Trace.WriteLine(" ")
        For I = Math.Max(0, nb_emissions_for_Maintenant - 10) To Math.Max(0, nb_emissions_for_Maintenant - 1)
            Trace.WriteLine( _
                             datetime.now & " " & "i=" & I.ToString & " cha_id=" & _
                             tableau_list_emissions_Maintenant(I).channelID & " pstart=" & _
                             tableau_list_emissions_Maintenant(I).Pstart & " dur.=" & _
                             tableau_list_emissions_Maintenant(I).Pduration & "  " & _
                             tableau_list_emissions_Maintenant(I).Ptitle)
        Next I
        Trace.WriteLine(" ")
#End If
        s1 = Nothing
        s2 = Nothing
        s3 = Nothing
        dt_Get_List_Of_Emissions_For_Maintenant = Nothing
    End Sub

    Public Sub lecture_des_chaines_memorisees()

        ' lecture des chaines présélectionnées dans le fichier "zguidetvdotnet.channels.set"
        Dim filename As String
        Dim chaine_lue As String
        des_canaux_sont_memorises = False
        filename = AppData & "zguidetvdotnet.channels.set"
        Dim FichierInfo As New FileInfo(filename)
        If My.Computer.FileSystem.FileExists(filename) Then
            If FichierInfo.Length > 0 Then

                des_canaux_sont_memorises = True
                Dim str As String
                Dim chaine1 As String
                Dim chaine2 As String
                Dim chaine3 As String

                Dim z As Integer
                Dim i As Integer = 1
                Trace.WriteLine(DateTime.Now & " contenu du fichier des canaux memorises zguidetvdotnet.channels.set")
                Dim sr As New StreamReader(filename)
                str = sr.ReadLine
                Do While Not (str Is Nothing)
                    chaine_lue = str
                    z = chaine_lue.IndexOf("|", StringComparison.CurrentCulture)
                    chaine1 = chaine_lue.Substring(0, z)

                    With tableau_chaine(i)
                        .identificateur = chaine1
                        .indice = i
                        chaine2 = chaine_lue.Substring(z + 1)
                        z = chaine2.IndexOf("|", StringComparison.CurrentCulture)
                        chaine3 = chaine2.Substring(0, z)
                        .nom = chaine3
                        .logo = chaine2.Substring(z).Replace("|", "")
                    End With
#If DEBUG Then
                    Trace.WriteLine( _
                                     tableau_chaine(i).indice.ToString & " " & _
                                     tableau_chaine(i).identificateur.ToString & " " & tableau_chaine(i).nom.ToString, _
                                     tableau_chaine(i).logo.ToString)
#End If

                    nom_des_chaines_memorisees = nom_des_chaines_memorisees & " ChannelId = '" & chaine1 & _
                                                 "' OR "
                    i += 1
                    str = sr.ReadLine
                Loop
                z = nom_des_chaines_memorisees.LastIndexOf("OR", StringComparison.CurrentCulture)
                nom_des_chaines_memorisees = nom_des_chaines_memorisees.Substring(0, z)
                Trace.WriteLine(DateTime.Now & "  nom_des_chaines_memorisees" & nom_des_chaines_memorisees)
                nb_total_chaines = i - 1
            End If
        End If
    End Sub

    Public Sub Build_Qwery_On_Channels_Where_and_Between()

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

#If DEBUG Then
        Dim monstopwatch6 As New Stopwatch
        monstopwatch6.Start()
#End If
        Dim sb As New StringBuilder
        Dim sb1 As New StringBuilder
        Dim sb3 As New StringBuilder
        Dim s1 As String
        Dim s2 As String
        Dim y1 As String
        Dim y2 As String
        Dim i As Integer
        Dim longueur As Integer
        Dim sor As String = " OR "

        With sb
            .Append("SELECT programtbl.ChannelID , programtbl.PTitle ,")
            .Append("programtbl.psubtitle, programtbl.Pstart, programtbl.Pstop, ")
            .Append("programtbl.Pduration, programtbl.PCategoryTV , programtbl.PCategory,")
            .Append("programtbl.Pdescription,  programtbl.Prating , ")
            .Append("programtbl.pactors , ")
            .Append( _
                       "programtbl.audiostereo,programtbl.Premiere,programtbl.Showview,programtbl.subtype,programtbl.Pdate, ")
            .Append("channeltbl.ordering FROM Programtbl , channeltbl ")
            .Append(" WHERE ([programtbl].[channeliD] = [channeltbl].[id]) ")
            .Append(" AND (")
        End With

        For i = 1 To nb_total_chaines
            sb1.Append("ChannelID='" & table_des_chaines_a_selectionner(i).ToString & "' OR ")
        Next i
        s1 = sb1.ToString
        longueur = s1.Length
        s2 = s1.Substring(0, longueur - sor.Length)
        sb.Append(s2 & ")")

        s1 = Nothing
        s2 = Nothing
        sb1 = Nothing

        y1 = depart_affichage.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)
        y2 = fin_affichage.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)

        With sb3
            .Append(" AND ((pstart between '" & y1.ToString & "'")
            .Append(" AND '" & y2.ToString & "') OR (PSTOP BETWEEN '" & y1.ToString & "' ")
            .Append(" AND '" & y2.ToString & "'))")
            .Append(" AND (PCATEGORYTV <>'')")
            .Append(" ORDER BY channeltbl.ordering ASC , programtbl.Pstart ASC")
        End With

        sb.Append(sb3)
        qw_on_channels = sb.ToString

#If DEBUG Then
        monstopwatch6.Stop()
        Dim tps_ecoule As Long
        tps_ecoule = monstopwatch6.ElapsedMilliseconds
        Trace.WriteLine(datetime.now & " " & "Temps pour buid qwery = " & tps_ecoule.ToString)
        monstopwatch6 = Nothing
        tps_ecoule = Nothing
#End If
        sb = Nothing
        sb3 = Nothing
        sb1 = Nothing
        sb = Nothing
        y1 = Nothing
        y2 = Nothing
    End Sub

    Function BasePerimee() As Boolean

        ' 14/12/2009 rvs75 function renvoyant true si la fin de la dernière émission
        ' est antérieure à aujourd'hui sinon renvoie false
        Dim dt_basePerimee As DataTable
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        dt_basePerimee = db.ExecuteQuery("select max(programtbl.Pstop) as lastEmission from programtbl;")
        db.CloseDatabase()
        db = Nothing
        Dim a As Integer
        a = dt_basePerimee.Rows.Count
        Dim b As Object
        b = dt_basePerimee.Rows(0).Item(0)
        If b Is "" Then
            BasePerimee = True
            Exit Function
        End If
        Dim c As New DateTime
        c = CDate(b)

        If _
            a = 0 OrElse _
            DateDiff("h", CDate(b), DateTime.Now) >= 0 Then
            BasePerimee = True
        Else
            BasePerimee = False
        End If
    End Function
End Module

