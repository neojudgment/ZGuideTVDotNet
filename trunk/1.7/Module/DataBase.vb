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

Imports ZGuideTV.SQLiteWrapper

' ReSharper disable CheckNamespace
Friend Module DataBase
    ' ReSharper restore CheckNamespace

    Public Const DbMajorVersion As String = "1"
    Public Const DbMinorVersion As String = "1"

    Public Sub CreateDbTables()

        ' rvs : creation base de données avec sqlite
        Dim db As SqLiteBase = New SqLiteBase
        db.OpenDatabase(BddPath & "db_progs.db3")
        db.ExecuteNonQueryFast("PRAGMA synchronous=0;")
        db.ExecuteNonQueryFast("PRAGMA temp_store = 2;")
        db.ExecuteNonQueryFast("PRAGMA Journal_mode = memory;")
        db.ExecuteNonQueryFast("CREATE Table ChannelTbl " &
                               "(Name TEXT, " &
                               "ID TEXT, " &
                               "Ordering INTEGER, " &
                               "Logo TEXT) ;")

        db.ExecuteNonQueryFast("CREATE Table Control " &
                               "(version TEXT) ;")

        db.ExecuteNonQueryFast(
            "INSERT INTO Control (version) VALUES  ('" & DbMajorVersion & "." & DbMinorVersion & "') ;")

        db.ExecuteNonQueryFast("CREATE Table ProgramTbl " &
                               "(ChannelID TEXT, " &
                               "PTitle TEXT, " &
                               "PSubTitle TEXT, " &
                               "PIndex INTEGER default 0, " &
                               "PDiff INTEGER, " &
                               "PStart TEXT, " &
                               "PStop TEXT default 0, " &
                               "PDuration INTEGER default 0, " &
                               "PCountry TEXT, " &
                               "PCategory TEXT, " &
                               "PCategoryTV TEXT, " &
                               "PDate TEXT, " &
                               "PDescription TEXT, " &
                               "PReview TEXT, " &
                               "PActors TEXT, " &
                               "PDirectors TEXT, " &
                               "PWriters TEXT, " &
                               "PPresents TEXT, " &
                               "PIconSr TEXT, " &
                               "PStar TEXT, " &
                               "PRating TEXT, " &
                               "Premiere INTEGER, " &
                               "VideoAspect TEXT, " &
                               "VideoColour INTEGER  default 0, " &
                               "AudioStereo TEXT, " &
                               "Language TEXT, " &
                               "SubType INTEGER, " &
                               "ShowView TEXT);")
        db.CloseDatabase()
    End Sub

    Public Sub DeleteDb()

        Try

            ' Erase old DB
            If My.Computer.FileSystem.FileExists(BddPath & "db_progs.db3") Then
                My.Computer.FileSystem.DeleteFile(BddPath & "db_progs.db3")
            End If

        Catch e As Exception
            Dim sql As String
            Dim db As SqLiteBase = New SqLiteBase
            db.OpenDatabase(BddPath & "db_progs.db3")

            sql = "begin transaction;"
            db.ExecuteNonQueryFast(sql)

            sql = "drop table programtbl;"
            db.ExecuteNonQueryFast(sql)

            sql = "drop table ChannelTbl;"
            db.ExecuteNonQueryFast(sql)

            sql = "drop table Control;"
            db.ExecuteNonQueryFast(sql)

            sql = "end transaction;"
            db.ExecuteNonQueryFast(sql)

            db.CloseDatabase()
        End Try
    End Sub

    Public Sub MiseAjourDb(ByVal tablename As String, Optional ByVal recordCollection As Collection = Nothing,
                           Optional ByVal etat As String = "")
        Select Case tablename
            Case "ChannelTbl"
                Dim strSql As String
                Dim collectionItem As String()
                Dim strName As String
                Dim strId As String
                Dim strlogo As String
                Dim intOrdreing As Short = 1

                Dim db As SqLiteBase = New SqLiteBase

                db.OpenDatabase(BddPath & "db_progs.db3")
                db.ExecuteNonQueryFast("begin transaction;")
                For Each collectionItem In recordCollection
                    strName = collectionItem(1).ToString
                    strId = collectionItem(0).ToString
                    strlogo = collectionItem(2).ToString
                    strSql = "insert into ChannelTbl(Name,ID,Logo,Ordering) values ('" & strName.Replace("'", "''") &
                             "','" & strId & "','" &
                             strlogo.Replace("'", "''") & "'," & intOrdreing & ");"
                    intOrdreing = CShort(intOrdreing + 1)
                    db.ExecuteNonQueryFast(strSql)
                Next collectionItem
                db.ExecuteNonQueryFast("end transaction;")

                db.CloseDatabase()
            Case "ProgramTbl"
                Static db As SqLiteBase = New SqLiteBase

                With db
                    Select Case etat
                        Case "Begin"
                            .OpenDatabase(BddPath & "db_progs.db3")
                            .ExecuteNonQueryFast("begin transaction;")
                        Case "Commit"
                            .ExecuteNonQueryFast("end transaction;")
                            .CloseDatabase()
                            db = Nothing
                        Case Else
                            'Modifié par Néo le 16/07/2010
                            If PDuration = 0 Then
                                PDuration = CInt(DateDiff(DateInterval.Minute, CDate(PStartA), CDate(PStopA)))
                            End If

                            Dim strSql2 As String
                            strSql2 =
                                "insert into ProgramTbl(ChannelID, PTitle, PSubTitle, PIndex, PDiff, PStart, PStop, " &
                                "PDuration, Pcountry, PCategory, PcategoryTV, Pdate, PDescription, PReview, PActors, PDirectors, " &
                                "PWriters, PPresents, PIconSR, PRating, Pstar, Premiere, VideoAspect, VideoColour, AudioStereo, Language, " &
                                "Subtype, ShowView) values ('" &
                                PChannelA & "' , '" & PTitle.Replace("'", "''") & "' , '" &
                                PSubTitle.Replace("'", "''") & "' , " & PIndex & " , " & PDiff &
                                " , '" & PStartA & "' , '" & PStopA & "' , " &
                                PDuration & " , '" & PCountry & "' , '" & PCategory.Replace("'", "''") & "' , '" &
                                PCategoryTv.Replace("'", "''").TrimEnd &
                                "' , '" & PDate & "' , '" &
                                PDescription.Replace("'", "''") & "', '" & PReview & "' , '" &
                                PActor.Replace("'", "''") & "' , '" & PDirector.Replace("'", "''") & "' , '" &
                                PWriter.Replace("'", "''") & "', '" &
                                PPresent & "' , '" & PIconRating & "' , '" & PRating & "' , '" & PStarRating &
                                "' , " &
                                PPremiere & " , '" & PVideoAspect & "'  , " &
                                (CInt(PVideoColor) + 1).ToString & " , '" & PAudioStereo & "' , '" & PLanguage & "' , " &
                                PSubType & " , '" &
                                PShowviewA & "' )"

                            .ExecuteNonQueryFast(strSql2)
                    End Select
                End With
        End Select
    End Sub

    Public Sub ChargeCategorie()

        Dim objetDataTable As DataTable
        Dim rowNumber As Integer

        ' Numéro de l'enregistrement courant
        Dim strSqlCategory As String
        'Dim strSqlPays As String = ""
        'Dim strSqlFournisseur As String = ""
        Dim i As Integer = 1

        strSqlCategory = "SELECT distinct PCategoryTV FROM ProgramTbl"
        'Array.Resize(Mainform.GetCatList(), 0)

        Dim db As SqLiteBase = New SqLiteBase

        With db
            .OpenDatabase(BddPath & "db_progs.db3")
            objetDataTable = .ExecuteQuery(strSqlCategory)
            .CloseDatabase()
        End With

        Try
            If rowNumber > objetDataTable.Rows.Count Then
                Return
            Else
                ReDim Preserve TableauTypeEmissionFranVar(i)
            End If

        Catch
            MessageBox.Show(ErrorToString, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub
End Module
