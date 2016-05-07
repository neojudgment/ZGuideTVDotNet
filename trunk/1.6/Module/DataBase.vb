' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2014 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

Imports ZGuideTV.SQLiteWrapper

' ReSharper disable CheckNamespace
Friend Module DataBase
    ' ReSharper restore CheckNamespace

    'Public largeur_treeview1 As Integer = Mainform.TreeView1.Width
    Private Const DbMajorVersion As Short = 1
    Private Const DbMinorVersion As Short = 0

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
            "INSERT INTO Control (version) VALUES  ('" & (DbMajorVersion).ToString & "." &
            (DbMinorVersion).ToString & "') ;")

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
                '************************************************************************************

                Mainform.TreeView1.Nodes.Item(0).Nodes.Item("Categories").Text =
                    "Catégories (" & objetDataTable.Rows.Count.ToString & ")"

                '************************************************************************************

                Mainform.TreeView1.Nodes.Item(0).Nodes.Item("Categories").Nodes.Clear()
                Dim nodeReset As New TreeNode("RESET")
                Mainform.TreeView1.Nodes.Item(0).Nodes.Add(nodeReset)

                For rowNumber = 0 To (objetDataTable.Rows.Count) - 1
                    ' ObjetTable.Rows(Numéro de lignes).Item( Nom de colonne) donne le contenu d'un champ dans une ligne donnée
                    Dim strCategory As String
                    strCategory = objetDataTable.Rows(rowNumber).Item("PCategoryTV").ToString
                    If (strCategory.Trim(" "c).Length) > 0 Then '02/10/07
                        Mainform.TreeView1.Nodes.Item(0).Nodes.Item("Categories").Nodes.Add(
                            New TreeNode(strCategory))

                    End If
                    TableauTypeEmissionFranVar(i) = strCategory.TrimEnd
                    If _
                        (Not TableauTypeEmissionFranVar(i) Is Nothing AndAlso
                         String.IsNullOrEmpty(TableauTypeEmissionFranVar(i))) Then
                        i = i - 1
                    End If
                    i += 1
                    NbTotalTypeEmission = i - 1

                Next rowNumber
                ReDim Preserve TableauTypeEmissionFranVar(i)
            End If

        Catch
            MessageBox.Show(ErrorToString, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub
End Module
