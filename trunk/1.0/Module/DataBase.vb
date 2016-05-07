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
Imports ZGuideTV.SQLiteWrapper

Friend Module DataBase
    'Public largeur_treeview1 As Integer = Mainform.TreeView1.Width
    Private Const DB_Major_Version As Short = 1
    Private Const DB_Minor_Version As Short = 0

    Public Structure Tbl_Control_FieldList
        Public FieldVersion As String

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Public Sub CreateDBTables()
        ' rvs : test creation base de données avec sqlite
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "db_progs.db3")
        db.ExecuteNonQueryFast("PRAGMA synchronous=0;")
        db.ExecuteNonQueryFast("PRAGMA temp_store = 2;")
        db.ExecuteNonQueryFast("PRAGMA Journal_mode = memory;")
        db.ExecuteNonQueryFast("CREATE Table ChannelTbl " & _
                                "(Name TEXT, " & _
                                "ID TEXT, " & _
                                "Ordering INTEGER, " & _
                                "Logo TEXT, " & _
                                "KTV INTEGER default 0); ")

        db.ExecuteNonQueryFast("CREATE Table Control " & _
                                "(version TEXT) ;")

        db.ExecuteNonQueryFast( _
                                "INSERT INTO Control (version) VALUES  ('" & (DB_Major_Version).ToString & "." & _
                                (DB_Minor_Version).ToString & "') ;")

        db.ExecuteNonQueryFast("CREATE Table ProgramTbl " & _
                                "(ChannelID TEXT, " & _
                                "PTitle TEXT, " & _
                                "PSubTitle TEXT, " & _
                                "PIndex INTEGER default 0, " & _
                                "PDiff INTEGER, " & _
                                "PStart TEXT, " & _
                                "PStop TEXT default 0, " & _
                                "PDuration INTEGER default 0, " & _
                                "PCountry TEXT, " & _
                                "PCategory TEXT, " & _
                                "PCategoryTV TEXT, " & _
                                "PDate TEXT, " & _
                                "PDescription TEXT, " & _
                                "PReview TEXT, " & _
                                "PActors TEXT, " & _
                                "PDirectors TEXT, " & _
                                "PWriters TEXT, " & _
                                "PPresents TEXT, " & _
                                "PIconSr TEXT, " & _
                                "PStar TEXT, " & _
                                "PRating TEXT, " & _
                                "Premiere INTEGER, " & _
                                "VideoAspect TEXT, " & _
                                "VideoColour INTEGER  default 0, " & _
                                "AudioStereo TEXT, " & _
                                "Language TEXT, " & _
                                "SubType INTEGER, " & _
                                "ShowView TEXT);")
        db.CloseDatabase()
        db = Nothing
    End Sub

    Public Sub DeleteDB()

        Try

            ' Erase old DB
            If My.Computer.FileSystem.FileExists(BDDPath & "db_progs.db3") Then
                My.Computer.FileSystem.DeleteFile(BDDPath & "db_progs.db3")
            End If

        Catch E As Exception
            'MessageBox.Show(E.Message & " Error in: DataBase.DeleteDB").ToString()
            Dim sql As String
            Dim db As SQLiteBase = New SQLiteBase
            db.OpenDatabase(BDDPath & "db_progs.db3")

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
            db = Nothing
        End Try
    End Sub

    Public Sub MiseAjourDB(ByVal Tablename As String, Optional ByVal RecordCollection As Collection = Nothing, _
                            Optional ByVal etat As String = "")
        Select Case Tablename
            Case "ChannelTbl"
                Dim strSql As String = ""
                Dim collection_Item As String()
                Dim strName As String = ""
                Dim strId As String = ""
                Dim strlogo As String = ""
                Dim intOrdreing As Short = 1

                Dim db As SQLiteBase = New SQLiteBase


                db.OpenDatabase(BDDPath & "db_progs.db3")
                db.ExecuteNonQueryFast("begin transaction;")
                For Each collection_Item In RecordCollection
                    strName = collection_Item(1).ToString
                    strId = collection_Item(0).ToString
                    strlogo = collection_Item(2).ToString
                    strSql = "insert into ChannelTbl(Name,ID,Logo,Ordering) values ('" & strName.Replace("'", "''") & _
                             "','" & strId & "','" & _
                             strlogo.Replace("'", "''") & "'," & intOrdreing & ");"
                    intOrdreing = CShort(intOrdreing + 1)
                    db.ExecuteNonQueryFast(strSql)
                Next collection_Item
                db.ExecuteNonQueryFast("end transaction;")

                db.CloseDatabase()
                db = Nothing
            Case "ProgramTbl"
                Static db As SQLiteBase = New SQLiteBase

                With db
                    Select Case etat
                        Case "Begin"
                            .OpenDatabase(BDDPath & "db_progs.db3")
                            .ExecuteNonQueryFast("begin transaction;")
                        Case "Commit"
                            .ExecuteNonQueryFast("end transaction;")
                            .CloseDatabase()
                            db = Nothing
                        Case Else
                            'Modifié par Néo le 16/07/2010
                            If pDuration = 0 Then
                                pDuration = CInt(DateDiff(DateInterval.Minute, CDate(pStart_A), CDate(pStop_A)))
                            End If

                            Dim strSql As String = ""
                            strSql = "insert into ProgramTbl(ChannelID,PTitle,PSubTitle,PIndex,PDiff,PStart,PStop," & _
                                     "PDuration,Pcountry,PCategory,PcategoryTV,Pdate,PDescription,PReview,PActors,PDirectors," & _
                                     "PWriters,PPresents,PIconSR,PRating,Pstar,Premiere,VideoAspect,VideoColour,AudioStereo,[Language]," & _
                                     "Subtype,ShowView) values ('" & _
                                     pChannel_A & "' , '" & pTitle.Replace("'", "''") & "' , '" & _
                                     pSubTitle.Replace("'", "''") & "' , " & PIndex & " , " & pDiff & _
                                     " , '" & pStart_A & "' , '" & pStop_A & "' , " & _
                                     pDuration & " , '" & PCountry & "' , '" & pCategory.Replace("'", "''") & "' , '" & _
                                     pCategoryTV.Replace("'", "''").TrimEnd & _
                                     "' , '" & pDate & "' , '" & _
                                     pDescription.Replace("'", "''") & "' , '" & PReview & "' , '" & _
                                     pActor.Replace("'", "''") & "' , '" & pDirector.Replace("'", "''") & "' , '" & _
                                     pWriter & "' , '" & _
                                     PPresent & "' , '" & pIconRating & "' , '" & PRating & "' , '" & PStarRating & _
                                     "' , " & _
                                     pPremiere & " ,'" & pVideoAspect & "'  , " & _
                                     PVideoColor & " , '" & PAudioStereo & "' , '" & PLanguage & "' , " & PSubType & _
                                     " , '" & _
                                     pShowview_A & "' )"

                            Dim strSql2 As String = ""
                            strSql2 = _
                                "insert into ProgramTbl(ChannelID, PTitle, PSubTitle, PIndex, PDiff, PStart, PStop, " & _
                                "PDuration, Pcountry, PCategory, PcategoryTV, Pdate, PDescription, PReview, PActors, PDirectors, " & _
                                "PWriters, PPresents, PIconSR, PRating, Pstar, Premiere, VideoAspect, VideoColour, AudioStereo, Language, " & _
                                "Subtype, ShowView) values ('" & _
                                pChannel_A & "' , '" & pTitle.Replace("'", "''") & "' , '" & _
                                pSubTitle.Replace("'", "''") & "' , " & PIndex & " , " & pDiff & _
                                " , '" & pStart_A & "' , '" & pStop_A & "' , " & _
                                pDuration & " , '" & PCountry & "' , '" & pCategory.Replace("'", "''") & "' , '" & _
                                pCategoryTV.Replace("'", "''").TrimEnd & _
                                "' , '" & pDate & "' , '" & _
                                pDescription.Replace("'", "''") & "', '" & PReview & "' , '" & _
                                pActor.Replace("'", "''") & "' , '" & pDirector.Replace("'", "''") & "' , '" & _
                                pWriter.Replace("'", "''") & "', '" & _
                                PPresent & "' , '" & pIconRating & "' , '" & PRating & "' , '" & PStarRating & _
                                "' , " & _
                                pPremiere & " , '" & pVideoAspect & "'  , " & _
                                (CInt(PVideoColor) + 1).ToString & " , '" & PAudioStereo & "' , '" & PLanguage & "' , " & _
                                PSubType & " , '" & _
                                pShowview_A & "' )"

                            .ExecuteNonQueryFast(strSql2)
                    End Select
                End With

        End Select
    End Sub

    Public Sub Charge_Categorie()

        Dim ObjetDataTable As DataTable
        Dim RowNumber As Integer

        ' Numéro de l'enregistrement courant
        Dim strSqlCategory As String = ""
        Dim strSqlPays As String = ""
        Dim strSqlFournisseur As String = ""
        Dim i As Integer = 1

        strSqlCategory = "SELECT distinct PCategoryTV FROM ProgramTbl"
        'Array.Resize(Mainform.GetCatList(), 0)

        Dim db As SQLiteBase = New SQLiteBase

        With db
            .OpenDatabase(BDDPath & "db_progs.db3")
            ObjetDataTable = .ExecuteQuery(strSqlCategory)
            .CloseDatabase()
            db = Nothing
        End With

        Try
            If RowNumber > ObjetDataTable.Rows.Count Then
                Return
            Else
                '************************************************************************************

                Mainform.TreeView1.Nodes.Item(0).Nodes.Item("Categories").Text = _
                    "Catégories (" & ObjetDataTable.Rows.Count.ToString & ")"

                '************************************************************************************

                Mainform.TreeView1.Nodes.Item(0).Nodes.Item("Categories").Nodes.Clear()
                For RowNumber = 0 To (ObjetDataTable.Rows.Count) - 1
                    ' ObjetTable.Rows(Numéro de lignes).Item( Nom de colonne) donne le contenu d'un champ dans une ligne donnée
                    Dim strCategory As String = ""
                    strCategory = ObjetDataTable.Rows(RowNumber).Item("PCategoryTV").ToString
                    If (strCategory.Trim(" "c).Length) > 0 Then '02/10/07
                        Mainform.TreeView1.Nodes.Item(0).Nodes.Item("Categories").Nodes.Add( _
                                                                                               New TreeNode(strCategory))
                        'Try
                        '    Array.Resize(Mainform.GetCatList(), (Mainform.GetCatList().Length + 1))
                        '    Mainform.GetCatList()(Mainform.GetCatList().Length - 1) = strCategory
                        '    '.ToLower.Replace("é", "").Replace("è", "").Replace("ê", "").Replace("â", "").Replace("à", "")
                        'Catch ex As Exception

                        'End Try
                    End If
                    Tableau_Type_Emission_fran_var(i) = strCategory.TrimEnd
                    If (Not Tableau_Type_Emission_fran_var(i) Is Nothing AndAlso String.IsNullOrEmpty(Tableau_Type_Emission_fran_var(i))) Then
                        i = i - 1
                    End If
                    i += 1
                    nb_total_type_emission = i - 1

                Next RowNumber
                ReDim Preserve Tableau_Type_Emission_fran_var(i)

                Dim str As String
                str = "vide"
            End If

        Catch
            MessageBox.Show(ErrorToString, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub
End Module
