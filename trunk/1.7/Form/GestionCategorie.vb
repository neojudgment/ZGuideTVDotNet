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
Public Class GestionCategorie
    ' ReSharper restore CheckNamespace

#Region "traduction"
    Public MsgBoxNonSauvegarde1 As String
    Public MsgBoxNonSauvegarde2 As String
    Public MsgBoxTitre As String
#End Region


    Dim _apresMajXmltv As Boolean = True
    Dim _sauvegarde As Boolean = True

    Public Property ApresMajXmltv As Boolean
        Get
            Return _apresMajXmltv
        End Get
        Set(value As Boolean)
            _apresMajXmltv = value
        End Set
    End Property

    Private Sub frmCategorie_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LanguageCheck()

        Text = LngGestionCategorietxt
        lblInfo.Text = LngGestionCategorielblInfo
        gbxGroupeCategorie.Text = LngGestionCategoriegbxGroupeCategorie
        lblNomGroupeCategorie.Text = LngGestionCategorielblNomGroupeCategorie
        lblCouleurGroupeCategorie.Text = LngGestionCategorielblCouleurGroupeCategorie
        pvCouleur.Text = LngGestionCategorielblCouleur
        btModifierGroupeCategorie.Text = LngGestionCategoriebtModifierGroupeCategorie
        btAjouterGroupe.Text = LngGestionCategoriebtAjouterGroupe
        chkSuppGroupeVide.Text = LngGestionCategoriechkSuppGroupeVide
        btSauvegarder.Text = LngGestionCategoriebtSauvegarder
        btRecharger.Text = LngGestionCategoriebtRecharger
        btFermer.Text = LngGestionCategoriebtFermer
        cmsGroup.Items(0).Text = LngGestionCategorieDeplacerVers
        MsgBoxTitre = LngMessageBoxGestionCategorieTitre
        MsgBoxNonSauvegarde1 = LngMessageBoxGestionCategorieNonSauvegarde1
        MsgBoxNonSauvegarde2 = LngMessageBoxGestionCategorieNonSauvegarde2

        AfficherTreeview()
        tvwCategorie.ContextMenuStrip = cmsGroup
    End Sub

    Private Sub tvwCategorie_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwCategorie.NodeMouseClick
        If e.Button = MouseButtons.Left Then
            Dim tn As TreeNode = e.Node
            If TypeOf (tn) Is TreeNodeGroupeCategorie Then
                txbNomGroupeCategorie.Text = tn.Text
                pvCouleur.BgColor = Color.FromArgb(DirectCast(tn, TreeNodeGroupeCategorie).Couleur)
                lblIdGroupe.Text = DirectCast(tn, TreeNodeGroupeCategorie).IdGroupe.ToString()
            End If

        ElseIf e.Button = MouseButtons.Right Then


        End If
    End Sub

    Private Sub tvwCategorie_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles tvwCategorie.ItemDrag

        If Not (TypeOf (e.Item) Is TreeNodeGroupeCategorie) Then
            If e.Button = MouseButtons.Left Then
                DoDragDrop(e.Item, DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub tvwCategorie_DragOver(sender As Object, e As DragEventArgs) Handles tvwCategorie.DragOver
        ' Récupère les coordonnées de la souris au click
        Dim targetPoint As Point = tvwCategorie.PointToClient(New Point(e.X, e.Y))
        Dim tn As TreeNode = tvwCategorie.GetNodeAt(targetPoint)
        If TypeOf (tn) Is TreeNodeGroupeCategorie Then
            ' Sélectionne le node qui est sur les ccordonnées de la souris
            tvwCategorie.SelectedNode = tvwCategorie.GetNodeAt(targetPoint)
        End If
    End Sub

    Private Sub tvwCategorie_DragDrop(sender As Object, e As DragEventArgs) Handles tvwCategorie.DragDrop
        ' Rubrique pour le déplacer dans un TreeView
        ' Récupère les coordonnées de la souris au relacher de la souris
        Dim targetPoint As Point = tvwCategorie.PointToClient(New Point(e.X, e.Y))
        ' Récupère le nom du node qui est sous le relacher de la souris
        Dim targetNode As TreeNode = tvwCategorie.GetNodeAt(targetPoint)
        If TypeOf (targetNode) Is TreeNodeGroupeCategorie Then
            ' Récupère le nom du node que l'on déplace
            Dim draggedNode As TreeNodeCategorie = CType(e.Data.GetData(GetType(TreeNodeCategorie)), TreeNodeCategorie)
            If draggedNode IsNot Nothing Then
                ' Confirme que le node qui est déplacé et que la cible n'est pas au dessous du node déplacé
                If Not draggedNode.Equals(targetNode) AndAlso Not ContainsNode(draggedNode, targetNode) Then
                    ' Si c'est un opération de déplacement déplace le node à l'emplacement actuel
                    If e.Effect = DragDropEffects.Move Then
                        draggedNode.Remove()
                        targetNode.Nodes.Add(draggedNode)
                    End If
                    ' Expand le node

                End If
            End If
            targetNode.Expand()
        End If

    End Sub

    Private Shared Function ContainsNode(ByVal node1 As TreeNode, ByVal node2 As TreeNode) As Boolean
        If Not (node1 Is Nothing) AndAlso Not (node2 Is Nothing) Then

            If node1.Parent.Equals(node2) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub tvwCategorie_DragEnter(sender As Object, e As DragEventArgs) Handles tvwCategorie.DragEnter
        e.Effect = e.AllowedEffect
    End Sub

    Private Sub btAjouterGroupe_Click(sender As Object, e As EventArgs) Handles btAjouterGroupe.Click
        Static idNouveau As Integer = -1
        If lblNomGroupeCategorie.Text.Trim.Length > 0 Then
            Dim tn As New TreeNodeGroupeCategorie
            tn.Text = txbNomGroupeCategorie.Text
            'tn.Couleur = lblCouleur.BackColor.ToArgb
            tn.Couleur = pvCouleur.BgColor.ToArgb
            tn.IdGroupe = idNouveau
            tvwCategorie.Nodes.Add(tn)
            idNouveau = idNouveau - 1
        End If
    End Sub

    Private Sub btCouleur_Click(sender As Object, e As EventArgs) Handles btCouleur.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            'lblCouleur.BackColor = ColorDialog1.Color
            pvCouleur.BgColor = ColorDialog1.Color
        End If
    End Sub


    'Private Sub lbxCategorieDansGroupe_DragEnter(sender As Object, e As DragEventArgs)
    '    e.Effect = e.AllowedEffect
    'End Sub

    Private Sub btEnregistrerGroupeCategorie_Click(sender As Object, e As EventArgs) Handles btModifierGroupeCategorie.Click
        If lblIdGroupe.Text.Trim.Length > 0 Then
            For Each tn As TreeNode In tvwCategorie.Nodes
                If lblNomGroupeCategorie.Text.Trim = tn.Text Then
                    Exit Sub
                End If
            Next
            For Each tn As TreeNode In tvwCategorie.Nodes
                If DirectCast(tn, TreeNodeGroupeCategorie).IdGroupe = CInt(lblIdGroupe.Text) Then
                    'DirectCast(tn, TreeNodeGroupeCategorie).Couleur = lblCouleur.BackColor.ToArgb
                    DirectCast(tn, TreeNodeGroupeCategorie).Couleur = pvCouleur.BgColor.ToArgb
                    tn.Text = txbNomGroupeCategorie.Text.Trim
                    Exit Sub
                End If
            Next
        End If
        _sauvegarde = False
    End Sub

    Private Sub AfficherTreeview()
        'Dim strSql As String = "SELECT Categorie.NomCategory, GroupeCategorie.idGroupeCategory,GroupeCategorie.NomGroupeCategory ,Couleur.Idcolor,Couleur.Color, IdCategory " &
        '    "FROM(Couleur, Categorie, GroupeCategorie) " &
        '    "WHERE GroupeCategorie.IdExtColor = Couleur.IdColor " &
        '    "AND " &
        '    "GroupeCategorie.IDGroupeCategory = Categorie.IdExtGroupeCategorie " &
        '    "ORDER BY GroupeCategorie.idGroupeCategory"

        Const strSql As String = "SELECT coalesce(Categorie.NomCategory,''), GroupeCategorie.IdGroupeCategory, GroupeCategorie.NomGroupeCategory, Couleur.IdColor, Couleur.Color, coalesce(Categorie.IdCategory,-1) " &
                                 "FROM GroupeCategorie LEFT OUTER JOIN " &
                                 "Couleur ON GroupeCategorie.IdExtColor = Couleur.IdColor LEFT OUTER JOIN " &
                                 "Categorie ON GroupeCategorie.IdGroupeCategory = Categorie.IdExtGroupeCategorie " &
                                 "ORDER BY GroupeCategorie.NomGroupeCategory"
        Dim db As SqLiteBase = New SqLiteBase
        Dim dtCategorie As DataTable
        db.OpenDatabase(BddPath & "Categorie.db3")
        dtCategorie = db.ExecuteQuery(strSql)
        db.CloseDatabase()

        Dim memoIdGroupe As Integer = 0

        Dim test As New List(Of TreeNode)
        Dim tnGroupe As TreeNodeGroupeCategorie = New TreeNodeGroupeCategorie
        DirectCast(cmsGroup.Items(0), ToolStripMenuItem).DropDownItems.Clear()
        For Each it As DataRow In dtCategorie.Rows
            If CInt(it.Item(1)) <> memoIdGroupe Then
                If memoIdGroupe > 0 Then
                    test.Add(tnGroupe)
                End If
                tnGroupe = New TreeNodeGroupeCategorie
                tnGroupe.Text = it.Item(2).ToString
                tnGroupe.IdGroupe = CInt(it.Item(1))
                tnGroupe.IdCouleur = CInt(it.Item(3))
                tnGroupe.Couleur = CInt(it.Item(4))
                Dim tsmi As New ToolStripMenuItem(it.Item(2).ToString)
                AddHandler tsmi.MouseDown, AddressOf Cms_SubItem_MouseDown
                DirectCast(cmsGroup.Items(0), ToolStripMenuItem).DropDownItems.Add(tsmi)
                memoIdGroupe = tnGroupe.IdGroupe
                If CInt(it.Item(5)) > 0 Then
                    Dim tnCat As New TreeNodeCategorie
                    tnCat.Text = it.Item(0).ToString
                    tnCat.IdCategorie = CInt(it.Item(5))
                    tnGroupe.Nodes.Add(tnCat)
                End If

            Else
                Dim tnCat As New TreeNodeCategorie
                tnCat.Text = it.Item(0).ToString
                tnGroupe.Nodes.Add(tnCat)
            End If
        Next
        test.Add(tnGroupe)
        tvwCategorie.Nodes.AddRange(test.ToArray)
        tvwCategorie.ExpandAll()
        If test.Count > 0 Then
            tvwCategorie.Nodes(0).EnsureVisible()
        End If

    End Sub



    Private Sub btRecharger_Click(sender As Object, e As EventArgs) Handles btRecharger.Click
        tvwCategorie.Nodes.Clear()
        AfficherTreeview()
    End Sub

    Private Sub btFermer_Click(sender As Object, e As EventArgs) Handles btFermer.Click
        Close()
    End Sub

    Private Sub btSauvegarder_Click(sender As Object, e As EventArgs) Handles btSauvegarder.Click
        SauvegarderCategorie()
        _sauvegarde = True
        tvwCategorie.Nodes.Clear()
        AfficherTreeview()

    End Sub

    Private Sub GestionCategorie_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _apresMajXmltv Then
            If _sauvegarde Then
                CentralScreen.MajEmission()
            Else
                If MessageBox.Show(New Form With {.TopMost = True},
                                MsgBoxNonSauvegarde1 & Environment.NewLine & MsgBoxNonSauvegarde2,
                                MsgBoxTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    SauvegarderCategorie()
                    CentralScreen.MajEmission()
                End If

            End If
        End If
    End Sub

    Private Sub SauvegarderCategorie()
        Dim db As SqLiteBase = New SqLiteBase
        db.OpenDatabase(BddPath & "Categorie.db3")

        For Each tn As TreeNode In tvwCategorie.Nodes
            Dim strSql As String
            Dim castTn As TreeNodeGroupeCategorie = DirectCast(tn, TreeNodeGroupeCategorie)
            If tn.Nodes.Count > 0 OrElse chkSuppGroupeVide.Checked = False Then
                If DirectCast(tn, TreeNodeGroupeCategorie).IdGroupe > 0 Then
                    'a modifier
                    strSql = "UPDATE GroupeCategorie SET NomGroupeCategory='" & tn.Text.Replace("'", "''") &
                        "' WHERE IdGroupeCategory= " & castTn.IdGroupe.ToString

                    db.ExecuteNonQueryFast(strSql)

                    strSql = "UPDATE Couleur SET Color=" & castTn.Couleur &
                        " WHERE Idcolor=" & castTn.IdCouleur

                    db.ExecuteNonQueryFast(strSql)
                Else
                    'a creer
                    strSql = "INSERT INTO Couleur (Color) VALUES (" & castTn.Couleur.ToString & ")"
                    db.ExecuteNonQueryFast(strSql)
                    strSql = "INSERT INTO GroupeCategorie (NomGroupeCategory,IdExtColor) VALUES ('" & castTn.Text.Replace("'", "''") & "'," & db.Last & ")"
                    db.ExecuteNonQueryFast(strSql)
                End If
                'les noeuds enfants
                For Each tnEnfant As TreeNode In tn.Nodes
                    strSql = "UPDATE Categorie SET IdExtGroupeCategorie=" & castTn.IdGroupe & " WHERE IdCategory=" & DirectCast(tnEnfant, TreeNodeCategorie).IdCategorie
                    db.ExecuteNonQueryFast(strSql)

                Next

            Else
                'a supprimer
                If castTn.IdGroupe > 0 Then
                    strSql = "DELETE FROM GroupeCategorie WHERE IdGroupeCategory=" & castTn.IdGroupe
                    db.ExecuteNonQueryFast(strSql)
                End If
            End If


        Next
        db.CloseDatabase()

    End Sub

    Private Sub TvwCategorie_MouseClick(sender As Object, e As MouseEventArgs) Handles tvwCategorie.MouseClick
        Dim tn As TreeNode = tvwCategorie.GetNodeAt(e.X, e.Y)
        tvwCategorie.SelectedNode = tn
    End Sub
    Private Sub Cms_SubItem_MouseDown(sender As Object, e As MouseEventArgs)

        Dim tn As TreeNode = tvwCategorie.SelectedNode
        Dim target As TreeNode = tvwCategorie.Nodes.Cast(Of TreeNode).ToList.Find(Function(n) n.Text.Equals(DirectCast(sender, ToolStripMenuItem).Text))

        If TypeOf (tn) Is TreeNodeGroupeCategorie Then
            For i As Integer = tn.Nodes.Count - 1 To 0 Step -1
                Dim ttn As TreeNode = tn.Nodes.Item(i)
                tn.Nodes.RemoveAt(i)
                target.Nodes.Add(ttn)
            Next
        Else
            tn.Nodes.Remove(tn)
            target.Nodes.Add(tn)
        End If
    End Sub
End Class

