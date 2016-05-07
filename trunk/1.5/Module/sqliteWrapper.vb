' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2013 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

' ReSharper disable CheckNamespace
Namespace SQLiteWrapper
    ' ReSharper restore CheckNamespace
    ''' <summary>
    ''' SQLite wrapper with functions for opening, closing and executing queries.
    ''' </summary>
    ''' 
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

    Public Class SqLiteBase
        Implements IDisposable
        ' SQLite constants 
        Private Const SqlOk As Integer = 0
        Private Const SqlRow As Integer = 100
        'Private Const SqlDone As Integer = 101
        Dim _i2 As Integer = IndiceCourantTle

        ''' <summary>
        ''' SQLite data types.
        ''' </summary>
        Private Enum SqLiteDataTypes
            ''' <summary>
            ''' Integer numbers.
            ''' </summary>
            Int = 1
            ''' <summary>
            ''' Decimal numbers.
            ''' </summary>
            Float
            ''' <summary>
            ''' All kinds of texts.
            ''' </summary>
            Text
            ''' <summary>
            ''' Blob objects - binary large objects.
            ''' </summary>
            Blob
            ''' <summary>
            ''' Nothing.
            ''' </summary>
            Null
        End Enum

        ' pointer to database
        Private _database As IntPtr

        ' Creates new instance of SQLiteBase class with no database attached.
        Public Sub New()
            _database = IntPtr.Zero
        End Sub

        ' Opens database. 
        Public Sub OpenDatabase(ByVal baseName As String)
            ' opens database 
            If SafeNativeMethods.sqlite3_open16(baseName, _database) <> SqlOk Then
                ' if there is some error, database pointer is set to 0 and exception is throws
                _database = IntPtr.Zero
                Throw New Exception("Error with opening database " & baseName & "!")
            End If
        End Sub

        ' Closes opened database.
        Public Sub CloseDatabase()
            ' closes the database if there is one opened
            If _database <> IntPtr.Zero Then
                SafeNativeMethods.sqlite3_close(_database)
            End If

        End Sub

        ' Executes query that does return something (e.g. SELECT).
        Public Function ExecuteQuery(ByVal query As String) As DataTable

            ' processed query
            Dim statement As IntPtr

            ' excess data, it has no use
            Dim excessData As IntPtr
            ' process query and make statement
            SafeNativeMethods.sqlite3_prepare16_v2(_database, query, Encoding.Unicode.GetBytes(query).Length, statement, _
                                                    excessData)
            ' table for result of function
            Dim table As New DataTable()

            ' reads first row - it is different from next rows because it also creates table columns
            ' result - returns SLQ_ROW while there is next row
            Dim result As Integer = ReadFirstRow(statement, table)

            ' reads rows
            While result = SqlRow
                result = ReadNextRow(statement, table)
            End While

            ' finalize executing this query
            SafeNativeMethods.sqlite3_finalize(statement)

            ' returns table
            Return table
        End Function

        'execute une requete et la met dans tableau_list_emissions
        'SR créé spécialement pour Get_List_Of_Emissions_For_Sql_Where_and_Between
        Public Function ExecuteQuery2TableauListEmissions(ByVal query As String, ByRef tab() As EmissionsList) As Integer
            Dim statement As IntPtr

            ' excess data, it has no use
            Dim excessData As IntPtr
            ' process query and make statement
            SafeNativeMethods.sqlite3_prepare16_v2(_database, query, Encoding.Unicode.GetBytes(query).Length, statement, _
                                                    excessData)
            ' reads first row - it is different from next rows because it also creates table columns
            ' result - returns SLQ_ROW while there is next row
            Dim result As Integer = ReadFirstRow2TableauListEmissions(statement, tab)

            ' reads rows
            While result = SqlRow
                result = ReadNextRow2TableauListEmissions(statement, tab)
            End While

            ' finalize executing this query
            SafeNativeMethods.sqlite3_finalize(statement)

            Return _i2

        End Function

        Private Function ReadFirstRow2TableauListEmissions(ByVal statement As IntPtr, ByRef tab() As EmissionsList) As Integer

            Dim resultType As Integer = SafeNativeMethods.sqlite3_step(statement)
            If resultType = SqlRow Then
                With tab(_i2)
                    .ChannelId = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 0))
                    .Ptitle = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 1))
                    .Psubtitle = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 2))
                    .Pstart = CDate(Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 3)))
                    .Pstop = CDate(Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 4)))
                    .Pduration = SafeNativeMethods.sqlite3_column_int(statement, 5)
                    .PcategoryTv = _
                        Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 6)).TrimEnd
                    .Pcategory = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 7)).TrimEnd
                    .Pdescription = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 8))
                    ' '290310 .pstar = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(8).ToString
                    .Prating = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 9))
                    .Pactors = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 10))
                    .Audiostereo = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 11))
                    .Premiere = SafeNativeMethods.sqlite3_column_int(statement, 12)
                    .Showview = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 13))
                    .Subtype = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 14))
                    .Pdate = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 15))
                    If (Not .PcategoryTv Is Nothing AndAlso String.IsNullOrEmpty(.PcategoryTv)) Then
                        _i2 = _i2 - 1
                    End If
                End With
                _i2 += 1

            End If
            Return SafeNativeMethods.sqlite3_step(statement)

        End Function

        Private Function ReadNextRow2TableauListEmissions(ByVal statement As IntPtr, ByRef tab() As EmissionsList) As Integer

            With tab(_i2)
                .ChannelId = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 0))
                .Ptitle = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 1))
                .Psubtitle = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 2))
                .Pstart = CDate(Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 3)))
                .Pstop = CDate(Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 4)))
                .Pduration = SafeNativeMethods.sqlite3_column_int(statement, 5)
                .PcategoryTv = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 6)).TrimEnd
                .Pcategory = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 7)).TrimEnd
                .Pdescription = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 8))
                '    '290310 .pstar = dt_Get_List_Of_Emissions_For_Sql_Where_and_Between.Rows(r).Item(8).ToString
                .Prating = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 9))
                .Pactors = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 10))
                .Audiostereo = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 11))
                .Premiere = SafeNativeMethods.sqlite3_column_int(statement, 12)
                .Showview = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 13))
                .Subtype = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 14))
                .Pdate = Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, 15))
                If (Not .PcategoryTv Is Nothing AndAlso String.IsNullOrEmpty(.PcategoryTv)) Then
                    _i2 = _i2 - 1
                End If
            End With
            _i2 += 1
            Return SafeNativeMethods.sqlite3_step(statement)
        End Function

        ' private function for reading firs row and creating DataTable
        Private Function ReadFirstRow(ByVal statement As IntPtr, ByRef table As DataTable) As Integer

            ' create new instance of DataTable with name "resultTable"
            table = New DataTable("resultTable")

            ' evaluates statement 
            Dim resultType As Integer = SafeNativeMethods.sqlite3_step(statement)

            ' if result of statement is SQL_ROW, create new table and write row in it
            If resultType = SqlRow Then
                ' returns number of columns returned by statement
                Dim columnCount As Integer = SafeNativeMethods.sqlite3_column_count(statement)

                ' declartaion of variables for reading first row
                Dim columnName As String
                Dim columnType As Integer
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
                        Case SqLiteDataTypes.Int
                            ' adds new integer column to table
                            table.Columns.Add(columnName, Type.GetType("System.Int32"))
                            ' writes column value in object array
                            columnValues(i) = SafeNativeMethods.sqlite3_column_int(statement, i)
                            ' same as for integer, this one is for float
                        Case SqLiteDataTypes.Float
                            table.Columns.Add(columnName, Type.GetType("System.Single"))
                            columnValues(i) = SafeNativeMethods.sqlite3_column_double(statement, i)
                            ' ... for text
                        Case SqLiteDataTypes.Text
                            table.Columns.Add(columnName, Type.GetType("System.String"))
                            columnValues(i) = _
                                Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, i))
                            ' ... for blob - blob are written in table as strings!!
                        Case SqLiteDataTypes.Blob
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
            Dim columnType As Integer
            Dim columnValues As Object() = New Object(columnCount - 1) {}

            For i As Integer = 0 To columnCount - 1
                columnType = SafeNativeMethods.sqlite3_column_type(statement, i)

                Select Case columnType
                    Case SqLiteDataTypes.Int
                        columnValues(i) = SafeNativeMethods.sqlite3_column_int(statement, i)
                    Case SqLiteDataTypes.Float
                        columnValues(i) = SafeNativeMethods.sqlite3_column_double(statement, i)
                    Case SqLiteDataTypes.Text
                        columnValues(i) = _
                            Marshal.PtrToStringUni(SafeNativeMethods.sqlite3_column_text16(statement, i))
                    Case SqLiteDataTypes.Blob
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
            SafeNativeMethods.sqlite3_prepare16_v2(_database, query, Encoding.Unicode.GetBytes(query).Length, stmHandle, _
                                                    IntPtr.Zero)
            SafeNativeMethods.sqlite3_step(stmHandle)
            SafeNativeMethods.sqlite3_finalize(stmHandle)
        End Sub

        Private _disposed As Boolean

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)

            SyncLock Me
                ' Do nothing if the object has already been disposed of.
                If _disposed Then Exit Sub

                If disposing Then
                    ' Release diposable objects used by this instance here.

                End If

                ' Release unmanaged resources here. Don't access reference type fields.

                ' Remember that the object has been disposed of.
                _disposed = True
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

