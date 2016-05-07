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
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SQLiteWrapper
    ''' <summary>
    ''' SQLite wrapper with functions for opening, closing and executing queries.
    ''' </summary>
    Friend NotInheritable Class SafeNativeMethods
        ' imports SQLite functions
        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_open16(<MarshalAs(UnmanagedType.LPWStr)> ByVal dbname As String, _
                                               ByRef database As IntPtr) As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_close(ByVal database As IntPtr) As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_exec16(ByVal database As IntPtr, ByVal query As String, ByVal callback As IntPtr, _
                                               ByVal arguments As IntPtr, ByRef [error] As IntPtr) As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_errmsg16(ByVal database As IntPtr) As IntPtr
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_prepare16_v2(ByVal database As IntPtr, _
                                                     <MarshalAs(UnmanagedType.LPWStr)> ByVal zSql As String, _
                                                     ByVal length As Integer, ByRef statement As IntPtr, _
                                                     ByRef tail As IntPtr) As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_step(ByVal statement As IntPtr) As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_column_count(ByVal statement As IntPtr) As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_column_name16(ByVal statement As IntPtr, ByVal columnNumber As Integer) _
            As IntPtr
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_column_type(ByVal statement As IntPtr, ByVal columnNumber As Integer) _
            As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_column_int(ByVal statement As IntPtr, ByVal columnNumber As Integer) As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_column_double(ByVal statement As IntPtr, ByVal columnNumber As Integer) _
            As Double
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_column_text16(ByVal statement As IntPtr, ByVal columnNumber As Integer) _
            As IntPtr
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_column_blob(ByVal statement As IntPtr, ByVal columnNumber As Integer) As IntPtr
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_column_table_name16(ByVal statement As IntPtr, ByVal columnNumber As Integer) _
            As IntPtr
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_finalize(ByVal handle As IntPtr) As Integer
        End Function

        <DllImport("sqlite3", CallingConvention:=CallingConvention.Cdecl)> _
        Friend Shared Function sqlite3_free(ByVal [error] As IntPtr) As IntPtr
        End Function

        '        Protected Overrides Sub Finalize()
        '            MyBase.Finalize()
        '        End Sub
    End Class

    Public Class SQLiteBase
        Implements IDisposable
        ' SQLite constants 
        Private Const SQL_OK As Integer = 0
        Private Const SQL_ROW As Integer = 100
        Private Const SQL_DONE As Integer = 101
        Dim I2 As Integer = indice_courant_TLE

        ''' <summary>
        ''' SQLite data types.
        ''' </summary>
        Private Enum SQLiteDataTypes
            ''' <summary>
            ''' Integer numbers.
            ''' </summary>
            INT = 1
            ''' <summary>
            ''' Decimal numbers.
            ''' </summary>
            FLOAT
            ''' <summary>
            ''' All kinds of texts.
            ''' </summary>
            TEXT
            ''' <summary>
            ''' Blob objects - binary large objects.
            ''' </summary>
            BLOB
            ''' <summary>
            ''' Nothing.
            ''' </summary>
            NULL
        End Enum

        ' pointer to database
        Private database As IntPtr

        ''' <summary>
        ''' Creates new instance of SQLiteBase class with no database attached.
        ''' </summary>
        Public Sub New()
            database = IntPtr.Zero
        End Sub

        ''' <summary>
        ''' Creates new instance of SQLiteBase class and opens database with given name.
        ''' </summary>
        ''' <param name="baseName">Name (and path) to SQLite database file</param>
        Public Sub New(ByVal baseName As String)
            OpenDatabase(baseName)
        End Sub

        ''' <summary>
        ''' Opens database. 
        ''' </summary>
        ''' <param name="baseName">Name of database file</param>
        Public Sub OpenDatabase(ByVal baseName As String)
            ' opens database 
            If SafeNativeMethods.sqlite3_open16(baseName, database) <> SQL_OK Then
                ' if there is some error, database pointer is set to 0 and exception is throws
                database = IntPtr.Zero
                Throw New Exception("Error with opening database " & baseName & "!")
            End If
        End Sub

        ''' <summary>
        ''' Closes opened database.
        ''' </summary>
        Public Sub CloseDatabase()
            ' closes the database if there is one opened
            If database <> IntPtr.Zero Then
                SafeNativeMethods.sqlite3_close(database)
            End If

        End Sub

        ''' <summary>
        ''' Attach database in opened database.
        ''' </summary>
        Public Sub AttachDatabase(ByVal baseName As String, ByVal AliasName As String)
            Dim query As String
            query = "ATTACH '" & baseName & "' AS " & AliasName
            ExecuteNonQueryFast(query)

        End Sub

        ''' <summary>
        ''' Detach database in opened database.
        ''' </summary>
        Public Sub DetachDatabase(ByVal AliasName As String)
            Dim query As String
            query = "DETACH " & AliasName
            ExecuteNonQueryFast(query)
        End Sub

        ''' <summary>
        ''' Returns the list of tables in opened database.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetTables() As ArrayList
            ' executes query that select names of all tables and views in master table of every database
            Dim _
                query As String = "SELECT name FROM sqlite_master " & _
                                  "WHERE type IN ('table','view') AND name NOT LIKE 'sqlite_%'" & "UNION ALL " & _
                                  "SELECT name FROM sqlite_temp_master " & "WHERE type IN ('table','view') " & _
                                  "ORDER BY 1"
            Dim table As DataTable = ExecuteQuery(query)

            ' when table is generater, it writes all table names in list that is returned
            Dim list As New ArrayList()
            For Each row As DataRow In table.Rows
                list.Add(row.ItemArray(0).ToString())
            Next
            Return list
        End Function


        Public Sub ExecuteNonQuery(ByVal query As String)
            ' calles SQLite function that executes non-query
            Dim erreur As IntPtr
            SafeNativeMethods.sqlite3_exec16(database, query, IntPtr.Zero, IntPtr.Zero, erreur)
            ' if there is error, excetion is thrown
            If erreur <> IntPtr.Zero Then
                Throw _
                    New Exception( _
                                   ("Error with executing non-query: """ & query & """!" & vbLf) + _
                                   Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_errmsg16(erreur)))
            End If
        End Sub

        ''' <summary>
        ''' Executes query that does return something (e.g. SELECT).
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Public Function ExecuteQuery(ByVal query As String) As DataTable
            ' processed query
            Dim statement As IntPtr

            ' excess data, it has no use
            Dim excessData As IntPtr
            ' process query and make statement
            SafeNativeMethods.sqlite3_prepare16_v2(database, query, Encoding.Unicode.GetBytes(query).Length, statement, _
                                                    excessData)
            ' table for result of function
            Dim table As New DataTable()

            ' reads first row - it is different from next rows because it also creates table columns
            ' result - returns SLQ_ROW while there is next row
            Dim result As Integer = ReadFirstRow(statement, table)

            ' reads rows
            While result = SQL_ROW
                result = ReadNextRow(statement, table)
            End While

            ' finalize executing this query
            SafeNativeMethods.sqlite3_finalize(statement)

            ' returns table
            Return table
        End Function

        'execute une requete et la met dans tableau_list_emissions
        'SR créé spécialement pour Get_List_Of_Emissions_For_Sql_Where_and_Between
        Public Function ExecuteQuery2tableau_list_emissions(ByVal query As String) As Integer
            Dim statement As IntPtr

            ' excess data, it has no use
            Dim excessData As IntPtr
            ' process query and make statement
            SafeNativeMethods.sqlite3_prepare16_v2(database, query, Encoding.Unicode.GetBytes(query).Length, statement, _
                                                    excessData)
            ' reads first row - it is different from next rows because it also creates table columns
            ' result - returns SLQ_ROW while there is next row
            Dim result As Integer = ReadFirstRow2tableau_list_emissions(statement)

            ' reads rows
            While result = SQL_ROW
                result = ReadNextRow2tableau_list_emissions(statement)
            End While

            ' finalize executing this query
            SafeNativeMethods.sqlite3_finalize(statement)

            Return I2

        End Function

        Private Function ReadFirstRow2tableau_list_emissions(ByVal statement As IntPtr) As Integer
            Dim resultType As Integer = SafeNativeMethods.sqlite3_step(statement)
            If resultType = SQL_ROW Then
                With tableau_list_emissions(I2)
                    .ChannelID = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 0))
                    .Ptitle = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 1))
                    .Psubtitle = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 2))
                    .pstart = CDate(Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 3)))
                    .pstop = CDate(Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 4)))
                    .Pduration = SafeNativeMethods.sqlite3_column_int(statement, 5)
                    .PcategoryTV = _
                        Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 6)).TrimEnd
                    .Pcategory = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 7)).TrimEnd
                    .Pdescription = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 8))
                    ' '290310 .pstar = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(8).ToString
                    .prating = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 9))
                    .Pactors = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 10))
                    .Audiostereo = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 11))
                    .Premiere = SafeNativeMethods.sqlite3_column_int(statement, 12)
                    .Showview = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 13))
                    .Subtype = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 14))
                    .Pdate = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 15))
                    If (Not .PcategoryTV Is Nothing AndAlso String.IsNullOrEmpty(.PcategoryTV)) Then
                        I2 = I2 - 1
                    End If
                End With
                I2 += 1

            End If
            Return SafeNativeMethods.sqlite3_step(statement)

        End Function

        Private Function ReadNextRow2tableau_list_emissions(ByVal statement As IntPtr) As Integer
            With tableau_list_emissions(I2)
                .ChannelID = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 0))
                .Ptitle = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 1))
                .Psubtitle = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 2))
                .pstart = CDate(Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 3)))
                .pstop = CDate(Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 4)))
                .Pduration = SafeNativeMethods.sqlite3_column_int(statement, 5)
                .PcategoryTV = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 6)).TrimEnd
                .Pcategory = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 7)).TrimEnd
                .Pdescription = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 8))
                '    '290310 .pstar = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(8).ToString
                .prating = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 9))
                .Pactors = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 10))
                .Audiostereo = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 11))
                .Premiere = SafeNativeMethods.sqlite3_column_int(statement, 12)
                .Showview = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 13))
                .Subtype = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 14))
                .Pdate = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 15))
                If (Not .PcategoryTV Is Nothing AndAlso String.IsNullOrEmpty(.PcategoryTV)) Then
                    I2 = I2 - 1
                End If
            End With
            I2 += 1
            Return SafeNativeMethods.sqlite3_step(statement)

        End Function

        ' private function for reading firs row and creating DataTable
        Private Function ReadFirstRow(ByVal statement As IntPtr, ByRef table As DataTable) As Integer
            ' create new instance of DataTable with name "resultTable"
            table = New DataTable("resultTable")

            ' evaluates statement 
            Dim resultType As Integer = SafeNativeMethods.sqlite3_step(statement)

            ' if result of statement is SQL_ROW, create new table and write row in it
            If resultType = SQL_ROW Then
                ' returns number of columns returned by statement
                Dim columnCount As Integer = SafeNativeMethods.sqlite3_column_count(statement)

                ' declartaion of variables for reading first row
                Dim columnName As String = ""
                Dim columnType As Integer = 0
                Dim columnValues As Object() = New Object(columnCount - 1) {}

                ' reads columns one by one
                For i As Integer = 0 To columnCount - 1
                    ' returns the name of current column
                    columnName = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_name16(statement, i))
                    ' returns the type of current column
                    columnType = SafeNativeMethods.sqlite3_column_type(statement, i)
                    ' checks type of columns - neccessary because different functions are required for different types
                    Select Case columnType
                        ' in case of integer column
                        Case SQLiteDataTypes.INT
                            ' adds new integer column to table
                            table.Columns.Add(columnName, Type.GetType("System.Int32"))
                            ' writes column value in object array
                            columnValues(i) = SafeNativeMethods.sqlite3_column_int(statement, i)
                            ' same as for integer, this one is for float
                        Case SQLiteDataTypes.FLOAT
                            table.Columns.Add(columnName, Type.GetType("System.Single"))
                            columnValues(i) = SafeNativeMethods.sqlite3_column_double(statement, i)
                            ' ... for text
                        Case SQLiteDataTypes.TEXT
                            table.Columns.Add(columnName, Type.GetType("System.String"))
                            columnValues(i) = _
                                Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, i))
                            ' ... for blob - blob are written in table as strings!!
                        Case SQLiteDataTypes.BLOB
                            table.Columns.Add(columnName, Type.GetType("System.String"))
                            columnValues(i) = _
                                Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_blob(statement, i))
                        Case Else
                            ' in case of something other, value is read as string
                            table.Columns.Add(columnName, Type.GetType("System.String"))
                            columnValues(i) = ""
                    End Select
                Next

                ' writes column values to table
                table.Rows.Add(columnValues)
            End If

            ' evalute statemnet for next results
            Return SafeNativeMethods.sqlite3_step(statement)
        End Function

        ' private function for reading rows other than first
        ' it' same like first row, only without creating table and columns
        Private Function ReadNextRow(ByVal statement As IntPtr, ByRef table As DataTable) As Integer
            Dim columnCount As Integer = SafeNativeMethods.sqlite3_column_count(statement)

            Dim columnType As Integer = 0
            Dim columnValues As Object() = New Object(columnCount - 1) {}

            For i As Integer = 0 To columnCount - 1
                columnType = SafeNativeMethods.sqlite3_column_type(statement, i)

                Select Case columnType
                    Case SQLiteDataTypes.INT
                        columnValues(i) = SafeNativeMethods.sqlite3_column_int(statement, i)
                    Case SQLiteDataTypes.FLOAT
                        columnValues(i) = SafeNativeMethods.sqlite3_column_double(statement, i)
                    Case SQLiteDataTypes.TEXT
                        columnValues(i) = _
                            Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, i))
                    Case SQLiteDataTypes.BLOB
                        columnValues(i) = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_blob(statement, i))
                    Case Else
                        columnValues(i) = ""
                End Select
            Next
            table.Rows.Add(columnValues)
            Return SafeNativeMethods.sqlite3_step(statement)
        End Function

        Public Sub ExecuteNonQueryFast(ByVal query As String)
            Dim stmHandle As IntPtr
            GC.KeepAlive(stmHandle)
            SafeNativeMethods.sqlite3_prepare16_v2(database, query, Encoding.Unicode.GetBytes(query).Length, stmHandle, _
                                                    IntPtr.Zero)
            SafeNativeMethods.sqlite3_step(stmHandle)
            SafeNativeMethods.sqlite3_finalize(stmHandle)
        End Sub

        Protected disposed As Boolean ' = False

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            SyncLock Me
                ' Do nothing if the object has already been disposed of.
                If disposed Then Exit Sub

                If disposing Then
                    ' Release diposable objects used by this instance here.

                End If

                ' Release unmanaged resources here. Don't access reference type fields.

                ' Remember that the object has been disposed of.
                disposed = True
            End SyncLock
        End Sub

        Public Overridable Sub Dispose() _
            Implements IDisposable.Dispose
            Dispose(False)
            ' Unregister object for finalization.
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose(False)
            Catch
                ' Deal with errors or just ignore them
            Finally
                ' Invoke the base object's Finalize method.
                MyBase.Finalize()
            End Try
        End Sub
    End Class
End Namespace

