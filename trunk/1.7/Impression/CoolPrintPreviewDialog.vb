' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2016 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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

Imports System.Drawing.Printing
Imports System.ComponentModel


Public Class CoolPrintPreviewDialog

    ' ** fields
    Private _doc As PrintDocument

    ' ** ctors
    Public Sub New()
        Me.New(Nothing)
        Text = LngPrintPreviewFormName
        _btnPrev.ToolTipText = LngPrintPreviewBtPrev
        _btnCancel.Text = LngPrintPreviewBtCancel_Close
        _btnFirst.ToolTipText = LngPrintPreviewBtFirst
        _btnLast.ToolTipText = LngPrintPreviewBtLast
        _btnNext.ToolTipText = LngPrintPreviewBtNext
        _btnPageSetup.ToolTipText = LngPrintPreviewBtPageSetup
        _btnPrint.ToolTipText = LngPrintPreviewBtPrint
        _itemActualSize.Text = LngPrintPreviewZoomActualSize
        _itemFullPage.Text = LngPrintPreviewZoomFullPage
        _itemPageWidth.Text = LngPrintPreviewZoomPageWidth
        _itemTwoPages.Text=LngPrintPreviewZoomTwoPages
    End Sub

    Public Sub New(ByVal parentForm As Control)
        components = Nothing
        InitializeComponent()
        If (Not parentForm Is Nothing) Then
            Size = parentForm.Size
        End If
    End Sub

    ' ** overrides
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        If Not (Not _preview.IsRendering OrElse e.Cancel) Then
            _preview.Cancel()
        End If
    End Sub

    Protected Overrides Sub OnShown(ByVal e As EventArgs)
        MyBase.OnShown(e)
        _preview.Document = Document
    End Sub

    ' ** properties
    Public Property Document() As PrintDocument
        Get
            Return _doc
        End Get
        Set(ByVal value As PrintDocument)
            If (Not _doc Is Nothing) Then
                RemoveHandler _doc.BeginPrint, New PrintEventHandler(AddressOf _doc_BeginPrint)
                RemoveHandler _doc.EndPrint, New PrintEventHandler(AddressOf _doc_EndPrint)
            End If
            _doc = value
            If (Not _doc Is Nothing) Then
                AddHandler _doc.BeginPrint, New PrintEventHandler(AddressOf _doc_BeginPrint)
                AddHandler _doc.EndPrint, New PrintEventHandler(AddressOf _doc_EndPrint)
            End If
            If Visible Then
                _preview.Document = Document
            End If
        End Set
    End Property

    ' ** event handlers
    Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
        If _preview.IsRendering Then
            _preview.Cancel()
        Else
            Close()
        End If
    End Sub

    Private Sub _btnFirst_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnFirst.Click
        _preview.StartPage = 0
    End Sub

    Private Sub _btnLast_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnLast.Click
        _preview.StartPage = (_preview.PageCount - 1)
    End Sub

    Private Sub _btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnNext.Click
        _preview.StartPage += 1
    End Sub

    Private Sub _btnPrev_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPrev.Click
        _preview.StartPage -= 1
    End Sub

    Private Sub _btnPageSetup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPageSetup.Click
        Using dlg As PageSetupDialog = New PageSetupDialog
            dlg.Document = Document
            If (dlg.ShowDialog(Me) = DialogResult.OK) Then
                _preview.RefreshPreview()
            End If
        End Using
    End Sub

    Private Sub _btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPrint.Click
        Using dlg As PrintDialog = New PrintDialog
            dlg.AllowSomePages = True
            dlg.AllowSelection = True
            dlg.UseEXDialog = True
            dlg.Document = Document
            Dim ps As PrinterSettings = dlg.PrinterSettings
            ps.MinimumPage = 1
            ps.MaximumPage = _preview.PageCount
            ps.FromPage = 1
            ps.ToPage = _preview.PageCount
            If (dlg.ShowDialog(Me) = DialogResult.OK) Then
                _preview.Print()
            End If
        End Using
    End Sub

    Private Sub _btnZoom_ButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles _btnZoom.ButtonClick
        _preview.ZoomMode = CType(IIf((_preview.ZoomMode = ZoomMode.ActualSize), ZoomMode.FullPage, ZoomMode.ActualSize), ZoomMode)
    End Sub

    Private Sub _btnZoom_DropDownItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles _btnZoom.DropDownItemClicked
        If (e.ClickedItem Is _itemActualSize) Then
            _preview.ZoomMode = ZoomMode.ActualSize
        ElseIf (e.ClickedItem Is _itemFullPage) Then
            _preview.ZoomMode = ZoomMode.FullPage
        ElseIf (e.ClickedItem Is _itemPageWidth) Then
            _preview.ZoomMode = ZoomMode.PageWidth
        ElseIf (e.ClickedItem Is _itemTwoPages) Then
            _preview.ZoomMode = ZoomMode.TwoPages
        End If
        If (e.ClickedItem Is _item10) Then
            _preview.Zoom = 0.1
        ElseIf (e.ClickedItem Is _item100) Then
            _preview.Zoom = 1
        ElseIf (e.ClickedItem Is _item150) Then
            _preview.Zoom = 1.5
        ElseIf (e.ClickedItem Is _item200) Then
            _preview.Zoom = 2
        ElseIf (e.ClickedItem Is _item25) Then
            _preview.Zoom = 0.25
        ElseIf (e.ClickedItem Is _item50) Then
            _preview.Zoom = 0.5
        ElseIf (e.ClickedItem Is _item500) Then
            _preview.Zoom = 5
        ElseIf (e.ClickedItem Is _item75) Then
            _preview.Zoom = 0.75
        End If
    End Sub

    Private Sub _doc_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        _btnCancel.Text = LngPrintPreviewBtCancel_Cancel
        _btnPrint.Enabled = _btnPageSetup.Enabled = False
    End Sub

    Private Sub _doc_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        _btnCancel.Text = LngPrintPreviewBtCancel_Close
        _btnPrint.Enabled = _btnPageSetup.Enabled = True
    End Sub

    Private Sub _preview_PageCountChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _preview.PageCountChanged
        Update()
        Application.DoEvents()
        '_lblPageCount.Text = String.Format("de {0}", _preview.PageCount)
        _lblPageCount.Text = LngPrintPreviewOfPage & " " & _preview.PageCount.ToString()
    End Sub

    Private Sub _preview_StartPageChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _preview.StartPageChanged
        _txtStartPage.Text = (_preview.StartPage + 1).ToString
    End Sub

    Private Sub _txtStartPage_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles _txtStartPage.Enter
        _txtStartPage.SelectAll()
    End Sub

    Private Sub _txtStartPage_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _txtStartPage.KeyPress
        Dim c As Char = e.KeyChar
        If (c = ChrW(13)) Then
            CommitPageNumber()
            e.Handled = True
        ElseIf Not ((c <= " "c) OrElse Char.IsDigit(c)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub _txtStartPage_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles _txtStartPage.Validating
        CommitPageNumber()
    End Sub

    Private Sub CommitPageNumber()
        Dim page As Integer
        If Integer.TryParse(_txtStartPage.Text, page) Then
            _preview.StartPage = (page - 1)
        End If
    End Sub

End Class