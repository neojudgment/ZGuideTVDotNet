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

Imports System.Collections
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports ZGuideTV.SQLiteWrapper
Imports System.Text

Namespace TVGuide
    ''' <summary>
    ''' This class takes the raw array of programmes and builds a bunch of specialized arrays such as
    ''' today's s, tomorrow's s, what's on right now, listings per channel, etc. These specialized
    ''' arrays are stored and only updated when necessary/requested and and used to populate the listview.
    ''' This class will also optionally sort the data if a sorting method is selected
    ''' </summary>
    Public Class ProgrammeOrganizer
        Private ReadOnly mAllShows As New ArrayList()
        Private ReadOnly mCategories As New ArrayList()
        Private mMinShowDate As DateTime = DateTime.MinValue
        Private mMaxShowDate As DateTime = DateTime.MinValue
        Dim list() As EmissionsList = {}
        Private ReadOnly _listechannel As New Dictionary(Of String, InfoChaine)

        Public Structure InfoChaine
            Public Property Logo As String
            Public Property Nom As String
            Public Property Ordering As Integer
            Public Sub New(nomLogo As String, nomchaine As String, numordering As Integer)
                Logo = nomLogo
                Nom = nomchaine
                Ordering = numordering
            End Sub
        End Structure

#Region "Properties"

        Public ReadOnly Property MinShowDate() As DateTime
            Get
                Return (mMinShowDate)
            End Get
        End Property

        Public ReadOnly Property MaxShowDate() As DateTime
            Get
                Return (mMaxShowDate)
            End Get
        End Property

        Public ReadOnly Property AllShows() As EmissionsList()
            Get
                Return list
            End Get
        End Property

        Public ReadOnly Property AllChannels() As Dictionary(Of String, InfoChaine)
            Get
                Return _listechannel
            End Get
        End Property

        Public ReadOnly Property AllCategories() As ArrayList
            Get
                mCategories.Sort()
                Return (mCategories)
            End Get
        End Property

#End Region

#Region "Constructors"

        Public Sub New()
            '_listechannel.Clear()
            'mAllShows.Clear()
        End Sub


#End Region

#Region "Listing Load Methods"

        'Public Function LoadListings() As TimeSpan
        '    Dim Start As DateTime, Finish As DateTime

        '    Start = DateTime.Now

        '    _listechannel.Clear()
        '    mAllShows.Clear()


        '    BuildList_AllChannels()
        '    BuildList_AllShows()
        '    BuildList_AllCategories()

        '    Finish = DateTime.Now
        '    Return (Finish - Start)
        'End Function
        Public Sub LoadListings()
            _listechannel.Clear()
            mAllShows.Clear()


            BuildList_AllChannels()
            BuildList_AllShows()
            BuildList_AllCategories()

        End Sub
#End Region

        '#Region "Load Icons Methods"

        '        Private Sub LoadIconsFromDirectory(pDir As String)
        '            For Each Filename As String In Directory.GetFiles(pDir, "*.jpg", SearchOption.AllDirectories)
        '                Dim ChannelName As String '= ""
        '                Dim x As Integer, y As Integer
        '                Dim im As Image = Image.FromFile(Filename)

        '                x = Filename.LastIndexOf("\"c) + 1
        '                y = Filename.LastIndexOf("."c)
        '                ChannelName = Filename.Substring(x, y - x)

        '                mIconsHash(ChannelName) = im
        '            Next
        '            For Each Filename As String In Directory.GetFiles(pDir, "*.gif", SearchOption.AllDirectories)
        '                Dim ChannelName As String '= ""
        '                Dim x As Integer, y As Integer '
        '                Dim im As Image = Image.FromFile(Filename)

        '                x = Filename.LastIndexOf("\"c) + 1
        '                y = Filename.LastIndexOf("."c)
        '                ChannelName = Filename.Substring(x, y - x)

        '                mIconsHash(ChannelName) = im
        '            Next
        '            For Each Filename As String In Directory.GetFiles(pDir, "*.bmp", SearchOption.AllDirectories)
        '                Dim ChannelName As String '= ""
        '                Dim x As Integer, y As Integer '
        '                Dim im As Image = Image.FromFile(Filename)

        '                x = Filename.LastIndexOf("\"c) + 1
        '                y = Filename.LastIndexOf("."c)
        '                ChannelName = Filename.Substring(x, y - x)

        '                mIconsHash(ChannelName) = im
        '            Next
        '            For Each Filename As String In Directory.GetFiles(pDir, "*.png", SearchOption.AllDirectories)
        '                Dim ChannelName As String '= ""
        '                Dim x As Integer, y As Integer
        '                Dim im As Image = Image.FromFile(Filename)

        '                x = Filename.LastIndexOf("\"c) + 1
        '                y = Filename.LastIndexOf("."c)
        '                ChannelName = Filename.Substring(x, y - x)

        '                mIconsHash(ChannelName) = im
        '            Next
        '        End Sub

        '#End Region

#Region "Internal Array Building Methods"
        Private Sub BuildList_AllChannels()
            Const strSql As String = "select channeltbl.name, channeltbl.id, channeltbl.logo, channeltbl.ordering  from channeltbl group by channeltbl.id order by ordering "

            Dim db As SqLiteBase = New SqLiteBase
            Dim dtChaines As DataTable
            db.OpenDatabase(BddPath & "db_progs.db3")
            dtChaines = db.ExecuteQuery(strSql)
            db.CloseDatabase()
            _listechannel.Clear()
            For r As Integer = 0 To dtChaines.Rows.Count - 1
                _listechannel.Add(dtChaines.Rows(r).Item(1).ToString,
                                  New InfoChaine(dtChaines.Rows(r).Item(2).ToString, dtChaines.Rows(r).Item(0).ToString, CInt(dtChaines.Rows(r).Item(3))))
            Next
        End Sub

        Private Sub BuildList_AllShows()
            mAllShows.Clear()
            Dim db As SqLiteBase = New SqLiteBase
            'Dim debut As String = DateTime.Now.ToString("yyyy-MM-dd hh:mm", CultureInfo.CurrentCulture)

            Const strsql As String = "SELECT COUNT(*)  FROM PROGRAMTBL where PCATEGORYTV <> ''"

            Dim strsql2 As New StringBuilder()
            With strsql2
                .Append("SELECT programtbl.ChannelID , programtbl.PTitle ,programtbl.psubtitle, ")
                .Append("programtbl.Pstart, programtbl.Pstop, programtbl.Pduration, ")
                .Append("programtbl.PCategoryTV , programtbl.PCategory, programtbl.Pdescription,  ")
                .Append("programtbl.Prating , programtbl.pactors ,  programtbl.PDirectors, ")
                .Append("programtbl.Ppresents, programtbl.audiostereo, programtbl.Premiere,")
                .Append("programtbl.Showview, programtbl.subtype, programtbl.Pdate, ")
                .Append("channeltbl.ordering FROM Programtbl , channeltbl ")
                '.Append("WHERE ProgramTbl.ChannelID = ChannelTbl.id and pstop > '" & debut & "' and PCATEGORYTV <> ''")
                .Append("WHERE ProgramTbl.ChannelID = ChannelTbl.id and PCATEGORYTV <> ''")
            End With

            Dim nb As Integer
            With db
                .OpenDatabase(BddPath & "db_progs.db3")

                Dim dtNbEmission As DataTable
                dtNbEmission = db.ExecuteQuery(strsql)
                Dim I As Integer = CInt(dtNbEmission.Rows(0).Item(0))
                ReDim list(I)
                nb = db.ExecuteQuery2TableauListEmissions(strsql2.ToString, list, 0)
                .CloseDatabase()
            End With
            ReDim Preserve list(nb - 1)

            mMinShowDate = (From d In list Select d.Pstart).Min()
            mMaxShowDate = (From d In list Select d.Pstart).Max()

        End Sub
        Private Sub BuildList_AllCategories()

            Dim db As SqLiteBase = New SqLiteBase
            db.OpenDatabase(BddPath & "db_progs.db3")
            Dim dtCat As DataTable
            Const query As String = "SELECT distinct PCategoryTV FROM Programtbl"
            dtCat = db.ExecuteQuery(query)
            db.CloseDatabase()
            db.Dispose()


            mCategories.Clear()
            For i As Integer = 0 To dtCat.Rows.Count - 1
                mCategories.Add(dtCat.Rows(i).Item(0).ToString)
            Next

        End Sub

#End Region

#Region "Search Functions"

        Public Function Search(pCriteriaCollection As SearchCriteriaCollection) As EmissionsList()
            Dim ShowsToSearch As EmissionsList() = AllShows
            Dim SearchResults As New ArrayList()


            'rvs75 ; Ancien code. A garder car très pratique pour tester/debugger les critères

            'Dim FoundMatch As Boolean

            'For Each Prog As EmissionsList In ShowsToSearch
            '    FoundMatch = True
            '    For Each iCriteria As ISearchCriteria In pCriteriaCollection
            '        'if the current program fails any of the search criteria then we haven't found a match
            '        If iCriteria.MatchesCriteria(Prog) = False Then
            '            FoundMatch = False
            '        End If
            '    Next

            '    'if the program passed all search criteria the foundmatch flag will be true
            '    If FoundMatch Then
            '        SearchResults.Add(Prog)
            '    End If
            'Next

            'rvs75 test paralellisation.Laisser tomber le concurentbag, c'est très leeeeeeent.
            Parallel.ForEach(ShowsToSearch, Sub(prog)
                                                Dim found As Boolean = True
                                                For Each iCriteria As ISearchCriteria In pCriteriaCollection
                                                    If iCriteria.MatchesCriteria(prog) = False Then
                                                        found = False
                                                    End If
                                                Next

                                                If found Then
                                                    SyncLock SearchResults
                                                        SearchResults.Add(prog)
                                                    End SyncLock
                                                End If

                                            End Sub)

            Return DirectCast(SearchResults.ToArray(GetType(EmissionsList)), EmissionsList())

        End Function

#End Region
    End Class
End Namespace
