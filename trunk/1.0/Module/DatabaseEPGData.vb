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

Module DatabaseEPGData
    Public Sub CreateDBEPGDATA()
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "EPGData.db3")
        db.ExecuteNonQueryFast("PRAGMA synchronous=0;")
        db.ExecuteNonQueryFast("PRAGMA temp_store = 2;")
        db.ExecuteNonQueryFast("PRAGMA Journal_mode = memory;")

        db.ExecuteNonQueryFast("CREATE Table Channel " & _
                        "(Name TEXT, " & _
                        "ID TEXT PRIMARY KEY); ")

        db.ExecuteNonQueryFast("CREATE Table Genre " & _
                "(Name TEXT, " & _
                "ID TEXT); ")

        db.ExecuteNonQueryFast("CREATE Table Category " & _
                "(Name TEXT, " & _
                "ID TEXT); ")

        db.CloseDatabase()
        db = Nothing

    End Sub
    Public Sub DeleteDBEPGData()
        Try

            ' Erase old DB
            If My.Computer.FileSystem.FileExists(BDDPath & "EPGData.db3") Then
                My.Computer.FileSystem.DeleteFile(BDDPath & "EPGData.db3")
            End If

        Catch E As Exception
            'MessageBox.Show(E.Message & " Error in: DataBase.DeleteDB").ToString()
            Dim sql As String
            Dim db As SQLiteBase = New SQLiteBase
            db.OpenDatabase(BDDPath & "EPGData.db3")

            sql = "begin transaction;"
            db.ExecuteNonQueryFast(sql)

            sql = "drop table Channel;"
            db.ExecuteNonQueryFast(sql)

            sql = "drop table Genre;"
            db.ExecuteNonQueryFast(sql)

            sql = "drop table Category;"
            db.ExecuteNonQueryFast(sql)

            sql = "end transaction;"
            db.ExecuteNonQueryFast(sql)

            db.CloseDatabase()
            db = Nothing
        End Try

    End Sub
    Public Sub MiseAjourDBEPGData(ByVal Tablename As String, ByVal RecordCollection As Collection)
        Dim db As SQLiteBase = New SQLiteBase
        db.OpenDatabase(BDDPath & "EPGData.db3")
        db.ExecuteNonQueryFast("begin transaction;")
        Dim strSql As String = ""
        Dim collection_Item As String()
        Dim strName As String = ""
        Dim strId As String = ""

        For Each collection_Item In RecordCollection
            strName = collection_Item(1).ToString
            strId = collection_Item(0).ToString
            strSql = "insert into " & Tablename & " (Name,ID) values ('" & strName.Replace("'", "''") & _
                     "','" & strId & ");"
            db.ExecuteNonQueryFast(strSql)
        Next collection_Item
        db.ExecuteNonQueryFast("end transaction;")

        db.CloseDatabase()
        db = Nothing

    End Sub

End Module
