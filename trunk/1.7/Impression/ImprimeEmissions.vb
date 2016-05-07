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
Imports System.Globalization
Imports ZGuideTV.SQLiteWrapper ' ReSharper disable once CheckNamespace

Public Class ImprimeEmissions
    Implements IDisposable

    Public Shared ImprimerEmissionsTonight As String
    Public Shared ImprimerEmissionsNow As String
    Public Shared ImprimerEmissionsLe As String
    Public Shared ImprimerEmissionsDe As String
    Public Shared ImprimerEmissionsA As String
    Public Shared ImprimerEmissionsRealise As String
    Public Shared ImprimerEmissionsAvec As String
    Public Shared ImprimerEmissionsResume As String

    Dim _disposed As Boolean = False

    Public Sub Dispose() _
               Implements IDisposable.Dispose

        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If _disposed Then Return

        If disposing Then
            _printDocument.Dispose()
        End If
        _printDocument = Nothing
        _disposed = True
    End Sub
    Private ReadOnly _pemissions() As EmissionsList
    ' ReSharper disable once FieldCanBeMadeReadOnly.Local
    Dim _printDocument As New PrintDocument
    Private _mParagraphsToPrint As List(Of ParagraphInfo)
    ' ReSharper disable once FieldCanBeMadeReadOnly.Local
    Private _mParagraphsToPrint2 As List(Of ParagraphInfo)
    Dim _memochaine As String = ""

    ' ReSharper disable once InconsistentNaming
    Dim WithEvents dlgPrintPreview As New CoolPrintPreviewDialog

    ' ReSharper disable once FieldCanBeMadeReadOnly.Local
    Private _listechannel As New Dictionary(Of String, InfoChaine)

    Private Structure ParagraphInfo
        Public ReadOnly FontSize As Integer
        Public Text As String
        Public ReadOnly Chaine As Boolean
        ' ReSharper disable once InconsistentNaming
        Public Sub New(ByVal font_size As Integer, ByVal txt As String, type As Boolean)
            Chaine = type
            FontSize = font_size
            Text = txt
        End Sub
    End Structure

    Private Structure InfoChaine
        Public Property Logo As String
        Public Property Nom As String

        Public Sub New(nomLogo As String, nomchaine As String)
            Logo = nomLogo
            Nom = nomchaine
        End Sub
    End Structure

    Public Sub New(titre As String, ParamArray emissions() As EmissionsList)
        ReDim _pemissions(emissions.Length)

        LanguageCheck()

        Array.Copy(emissions, _pemissions, emissions.Length)
        _mParagraphsToPrint2 = New List(Of ParagraphInfo)()
        _mParagraphsToPrint2.Add(New ParagraphInfo(28, titre, False))
        _mParagraphsToPrint2.Add(New ParagraphInfo(16, " ", False))
        Dim strSql As String
        strSql =
            "select channeltbl.name, channeltbl.id, channeltbl.logo  from channeltbl group by channeltbl.id order by ordering "

        Dim db As SqLiteBase = New SqLiteBase
        Dim dtChaines As DataTable
        db.OpenDatabase(BddPath & "db_progs.db3")
        dtChaines = db.ExecuteQuery(strSql)
        db.CloseDatabase()

        For r As Integer = 0 To dtChaines.Rows.Count - 1
            _listechannel.Add(dtChaines.Rows(r).Item(1).ToString,
                              New InfoChaine(dtChaines.Rows(r).Item(2).ToString, dtChaines.Rows(r).Item(0).ToString))
        Next
        For Each c As EmissionsList In From c1 In emissions Where Not String.IsNullOrWhiteSpace(c1.Ptitle)

            _mParagraphsToPrint2.Add(New ParagraphInfo(24, c.ChannelId, True))
            _mParagraphsToPrint2.Add(New ParagraphInfo(16, c.Ptitle, False))
            If c.Psubtitle.Length > 0 Then
                _mParagraphsToPrint2.Add(New ParagraphInfo(12, c.Psubtitle, False))
            End If
            _mParagraphsToPrint2.Add(New ParagraphInfo(12,
                                                       ImprimerEmissionsLe & " " & c.Pstart.ToString("dd/MM/yyyy") & " " & ImprimerEmissionsDe & " " &
                                                       c.Pstart.ToString("HH:mm") & " " & ImprimerEmissionsA & " " & c.Pstop.ToString("HH:mm"),
                                                       False))
            _mParagraphsToPrint2.Add(New ParagraphInfo(4, " ", False))
            If c.Pdirector.Length > 0 Then
                _mParagraphsToPrint2.Add(New ParagraphInfo(10, ImprimerEmissionsRealise & " " & c.Pdirector, False))
                _mParagraphsToPrint2.Add(New ParagraphInfo(4, " ", False))
            End If
            If c.Pactors.Length > 0 Then
                _mParagraphsToPrint2.Add(New ParagraphInfo(10, ImprimerEmissionsAvec & " " & c.Pactors, False))
                _mParagraphsToPrint2.Add(New ParagraphInfo(4, " ", False))
            End If
            If c.Pdescription.Length > 0 Then
                _mParagraphsToPrint2.Add(New ParagraphInfo(10, ImprimerEmissionsResume & " " & c.Pdescription, False))
            End If
            _mParagraphsToPrint2.Add(New ParagraphInfo(16, " ", False))
        Next


        AddHandler _printDocument.BeginPrint, AddressOf Print_BeginPrint
        AddHandler _printDocument.PrintPage, AddressOf Print_PrintPage
    End Sub

    Public Sub VoirPrevisualisation()

        Dim dlg As New PrintDialog

        dlg.Document = _printDocument

        Dim result As DialogResult = dlg.ShowDialog()

        If (result = DialogResult.OK) Then
            dlgPrintPreview.Document = _printDocument

            If dlgPrintPreview.ShowDialog() = DialogResult.OK Then
                _printDocument.Print()
            End If

        End If
    End Sub

    ' Get ready to print pages.
    Private Sub Print_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        _mParagraphsToPrint = New List(Of ParagraphInfo)()
        _mParagraphsToPrint.AddRange(_mParagraphsToPrint2)
    End Sub

    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Dim theFont As Font
        Dim stringFormat As New StringFormat

        ' Draw the rest of the text left justified,
        ' wrap at words, and don't draw partial lines.
        stringFormat.Alignment = StringAlignment.Near
        stringFormat.FormatFlags = StringFormatFlags.LineLimit
        stringFormat.Trimming = StringTrimming.Word

        ' Draw some text.
        Dim itemParagraphInfo As ParagraphInfo
        Dim ymin As Integer = e.MarginBounds.Top
        Dim layoutRect As RectangleF
        Dim textSize As SizeF
        Dim charactersFitted As Integer
        Dim linesFilled As Integer
        Do While _mParagraphsToPrint.Count > 0

            ' Print the next paragraph.
            itemParagraphInfo = _mParagraphsToPrint(0)

            With itemParagraphInfo
                'If .Text = "CE SOIR".ToUpper(CultureInfo.InvariantCulture) Then
                '    .Text = ImprimerEmissionsTonight
                'ElseIf .Text = "MAINTENANT".ToUpper(CultureInfo.InvariantCulture) Then
                '    .Text = ImprimerEmissionsNow
                'End If
                If .Text.ToUpper(CultureInfo.InvariantCulture).Equals("CE SOIR") Then
                    .Text = ImprimerEmissionsTonight
                ElseIf .Text.ToUpper(CultureInfo.InvariantCulture).Equals("MAINTENANT") Then
                    .Text = ImprimerEmissionsNow
                End If
            End With

            _mParagraphsToPrint.RemoveAt(0)
            If itemParagraphInfo.Chaine Then
                If Not _memochaine.Equals(itemParagraphInfo.Text) Then
                    _memochaine = itemParagraphInfo.Text

                    Dim img As Image = Image.FromFile(LogosPath & _listechannel(itemParagraphInfo.Text).Logo)
                    e.Graphics.DrawImage(img, e.MarginBounds.Left, ymin, 66, 50)
                    ymin += 10
                    itemParagraphInfo.Text = "        " & _listechannel(itemParagraphInfo.Text).Nom
                Else
                    itemParagraphInfo.Text = ""
                End If

            End If

            ' Get the font.
            theFont = New Font("Times New Roman",
                               itemParagraphInfo.FontSize,
                               FontStyle.Regular, GraphicsUnit.Point)

            ' Get the area available for this paragraph.
            layoutRect = New RectangleF(
                e.MarginBounds.Left, ymin,
                e.MarginBounds.Width,
                e.MarginBounds.Bottom - ymin)

            ' If the layout rectangle's height < 1, make it 1.
            If layoutRect.Height < 1 Then layoutRect.Height = 1

            ' See how big the text will be and 
            ' how many characters will fit.
            textSize = e.Graphics.MeasureString(
                itemParagraphInfo.Text, theFont,
                New SizeF(layoutRect.Width, layoutRect.Height),
                stringFormat, charactersFitted, linesFilled)

            ' See if any characters will fit.
            If charactersFitted > 0 Then
                ' Draw the text.
                e.Graphics.DrawString(itemParagraphInfo.Text,
                                      theFont, Brushes.Black,
                                      layoutRect, stringFormat)

                ' Increase the location where we can start.
                ' Add a little interparagraph spacing.
                ymin += CInt(textSize.Height) ' + e.Graphics.MeasureString("M", theFont).Height / 5)
            End If

            ' See if some of the paragraph didn't fit on the page.
            If charactersFitted < itemParagraphInfo.Text.Length Then
                If itemParagraphInfo.Chaine Then
                    itemParagraphInfo.Text = _memochaine
                End If
                ' Some of the paragraph didn't fit.
                ' Prepare to print the rest on the next page.
                itemParagraphInfo.Text = itemParagraphInfo.Text.
                    Substring(charactersFitted)
                _mParagraphsToPrint.Insert(0, itemParagraphInfo)
                ' That's all that will fit on this page.
                Exit Do
            End If
        Loop

        ' If we have more paragraphs, we have more pages.
        e.HasMorePages = (_mParagraphsToPrint.Count > 0)
    End Sub

End Class
