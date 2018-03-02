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
Module Categorie
    ' ReSharper restore CheckNamespace
    Private _listeCategorie As Dictionary(Of String, Integer)

    Dim _force As Boolean = False
    Public Property Force() As Boolean
        Get
            Return _force
        End Get
        Set(value As Boolean)
            _force = True
        End Set
    End Property

    Private _charge As Boolean = False

    Public Function ListeCategorie() As Dictionary(Of String, Integer)
        If Not _charge OrElse _force Then
            Dim db As SqLiteBase = New SqLiteBase
            Const query As String = "SELECT Categorie.NomCategory,Couleur.Color " &
                                    "FROM Categorie " &
                                    "LEFT OUTER JOIN GroupeCategorie ON (Categorie.IdExtGroupeCategorie = GroupeCategorie.IdGroupeCategory) " &
                                    "LEFT OUTER JOIN Couleur ON (GroupeCategorie.IdExtColor = Couleur.IDcolor) "
            db.OpenDatabase(BddPath & "Categorie.db3")
            _listeCategorie = db.ExecuteQueryListeCouleur(query)
            db.CloseDatabase()
            db.Dispose()
            _charge = True
            _force = False
        End If
        Return _listeCategorie

    End Function

    Public Function ListeCategoriesNouvellesAprèsMaj() As IEnumerable(Of String)
        Dim db As SqLiteBase = New SqLiteBase
        db.OpenDatabase(BddPath & "db_progs.db3")
        Dim catZg As IEnumerable(Of String)
        Dim cat As IEnumerable(Of String)
        Dim query As String = "SELECT distinct PCategoryTV FROM Programtbl"
        catZg = db.ExecuteQuery2IEnumerable(query)
        db.CloseDatabase()
        db.OpenDatabase(BddPath & "Categorie.db3")
        query = "SELECT NomCategory FROM Categorie"
        cat = db.ExecuteQuery2IEnumerable(query)
        db.CloseDatabase()
        db.Dispose()
        'Dim r As IEnumerable(Of String) = CatZG.Except(Cat)

        Return catZg.Except(cat)

    End Function

    Public Sub AddCategorie(listeCat As IEnumerable(Of String))
        Dim db As New SqLiteBase
        db.OpenDatabase(BddPath & "Categorie.db3")

        Dim str As String = "SELECT idColor FROM Couleur WHERE IdColor NOT IN (SELECT IdExtColor FROM GroupeCategorie)"
        Dim dtCouleurNonUtilise As DataTable
        dtCouleurNonUtilise = db.ExecuteQuery(str)

        Dim cptCouleur As Integer = 1
        For Each category As String In listeCat

            str = "insert into GroupeCategorie(NomGroupeCategory,IdExtColor) values('group_" & category.Replace("'", "''") & "' ," & dtCouleurNonUtilise.Rows(cptCouleur).Item(0).ToString() & ");"
            db.ExecuteNonQueryFast(str)
            Dim idgroupeCategorie As Int64 = db.Last()
            str = "insert into Categorie (NomCategory,IdExtGroupeCategorie) values ('" & category.Replace("'", "''") & "'," & idgroupeCategorie.ToString() & ")"
            db.ExecuteNonQueryFast(str)
            cptCouleur = cptCouleur + 1
        Next
        db.CloseDatabase()
        db.Dispose()
    End Sub

    Public Sub InitCategorie()
        Dim db As SqLiteBase = New SqLiteBase
        db.OpenDatabase(BddPath & "db_progs.db3")
        Dim catZg As IEnumerable(Of String)
        Const query As String = "SELECT distinct PCategoryTV FROM Programtbl"
        catZg = db.ExecuteQuery2IEnumerable(query)
        db.CloseDatabase()
        db.Dispose()
        AddCategorie(catZg)
    End Sub

    Public Sub InitColor()

        Dim tabCouleur As Color() = {Color.FromArgb(255, 191, 191), Color.FromArgb(255, 191, 255), Color.FromArgb(223, 191, 255),
                                  Color.FromArgb(206, 189, 255),
                                  Color.FromArgb(191, 191, 255), Color.FromArgb(191, 253, 255),
                                  Color.FromArgb(255, 229, 229), Color.FromArgb(191, 255, 191), Color.FromArgb(223, 255, 191),
                                  Color.FromArgb(239, 255, 191),
                                  Color.FromArgb(255, 174, 128), Color.FromArgb(255, 223, 128), Color.FromArgb(255, 214, 191),
                                  Color.FromArgb(255, 221, 191), Color.FromArgb(236, 236, 236), Color.FromArgb(255, 128, 128),
                                  Color.FromArgb(178, 178, 178), Color.FromArgb(240, 230, 140), Color.FromArgb(240, 255, 128),
                                  Color.FromArgb(191, 255, 128), Color.FromArgb(140, 255, 128), Color.FromArgb(128, 255, 159),
                                  Color.FromArgb(128, 255, 206), Color.FromArgb(128, 255, 255), Color.FromArgb(128, 208, 255),
                                  Color.FromArgb(128, 159, 255), Color.FromArgb(142, 128, 255),
                                  Color.FromArgb(191, 128, 255), Color.FromArgb(238, 128, 255), Color.FromArgb(255, 128, 223),
                                  Color.FromArgb(255, 255, 128), Color.FromArgb(128, 255, 128),
                                  Color.FromArgb(0, 255, 128), Color.FromArgb(128, 255, 255), Color.FromArgb(128, 180, 255),
                                  Color.FromArgb(255, 217, 217), Color.FromArgb(255, 217, 255), Color.FromArgb(237, 217, 255),
                                  Color.FromArgb(236, 217, 255), Color.FromArgb(225, 217, 255)}

        Dim vert, bleu, rouge As Integer

        Dim cptCouleur As Integer = tabCouleur.Length
        ReDim Preserve tabCouleur(tabCouleur.Length + 215)

        Dim palier As Int32() = {255, 220, 235, 175, 205, 190}

        For vert = 0 To 5
            For bleu = 0 To 5
                For rouge = 0 To 5
                    tabCouleur(cptCouleur) =
                        Color.FromArgb(palier(rouge), palier(vert) - 25, palier(bleu) - 5)
                    cptCouleur += 1
                Next
            Next
        Next

        Dim db As New SqLiteBase
        db.OpenDatabase(BddPath & "Categorie.db3")
        db.ExecuteNonQueryFast("Begin transaction;")
        For Each col As Color In tabCouleur
            db.ExecuteNonQueryFast("Insert into Couleur (Color) values (" & col.ToArgb & ");")
        Next
        db.ExecuteNonQueryFast("End transaction;")
        db.CloseDatabase()
        db.Dispose()

    End Sub

    Public Sub CreateCategorieDataBase()
        Dim db As SqLiteBase = New SqLiteBase
        db.OpenDatabase(BddPath & "Categorie.db3")
        db.ExecuteNonQueryFast("PRAGMA synchronous=0;")
        db.ExecuteNonQueryFast("PRAGMA temp_store = 2;")
        db.ExecuteNonQueryFast("PRAGMA Journal_mode = memory;")

        db.ExecuteNonQueryFast("CREATE Table Categorie " & _
                            "(IdCategory INTEGER PRIMARY KEY ASC, " & _
                            "NomCategory TEXT, " & _
                            "IdExtGroupeCategorie INTEGER) ;")


        db.ExecuteNonQueryFast("CREATE Table GroupeCategorie " & _
                                "(IdGroupeCategory INTEGER PRIMARY KEY ASC, " & _
                                "NomGroupeCategory TEXT, " & _
                                "IdExtColor INTEGER)")

        db.ExecuteNonQueryFast("CREATE Table Couleur " & _
                                "(IDcolor INTEGER PRIMARY KEY ASC, " & _
                                "Color INTEGER) ;")
        db.CloseDatabase()
        db.Dispose()
    End Sub

End Module
