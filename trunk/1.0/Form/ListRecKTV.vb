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
Imports System.IO

Public Class ListRecKTV
    Dim KTV_Profiles() As String
    Dim KTV_DefaultProfile As String
    Dim Nb_KTV_Records As Integer
    Dim KTV_Source As String
    Dim KTV_Path As String = ""
    Public OverlappingRec As String = "Chevauchement d'enregistrement ! Vérifiez les horaires."
    Public CantWhrite As String = "Impossible d'écrire dans "
    Public ParameterKtvChannel As String = "Veuillez paramètrer les correspondances entre ZGuideTV et K!TV."

    Private Structure KTV_Record
        Dim StartTime As DateTime
        Dim EndTime As DateTime
        Dim Channel As Integer
        Dim Name As String
        Dim Profile As String
        Dim VPS As Integer
        Dim RecordType As Integer
        Dim Repeat As Integer
        Dim Activity As Integer
        Dim DefaultSettings As Integer

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Private Const LVM_FIRST As Long = &H1000&
    Private Const LVM_SUBITEMHITTEST As Long = (LVM_FIRST + 57)
    Private Const LVHT_NOWHERE As Long = &H1
    Private Const LVHT_ONITEMICON As Long = &H2
    Private Const LVHT_ONITEMLABEL As Long = &H4
    Private Const LVHT_ONITEMSTATEICON As Long = &H8
    Private Const LVHT_ONITEM As Long = (LVHT_ONITEMICON Or LVHT_ONITEMLABEL Or LVHT_ONITEMSTATEICON)

    Private Structure POINTAPI
        Dim x As Long
        Dim y As Long

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Private Structure LVHITTESTINFO
        Dim pt As POINTAPI
        Dim lFlags As Long
        Dim lItem As Long
        Dim lSubItem As Long

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hWnd As Long, _
                                                                                   ByVal lpOperation As String, _
                                                                                   ByVal lpFile As String, _
                                                                                   ByVal lpParameters As String, _
                                                                                   ByVal lpDirectory As String, _
                                                                                   ByVal nShowCmd As Long) As Long

    Dim ReadRecord(1) As KTV_Record
    Dim KTV_Records() As KTV_Record
    Dim nAction As Integer

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdModify.Click

        If ListView1.SelectedItems.Count > 0 Then

            ' les modifs à faire consiste à détecté la tâche dans tâche palnifier
            ' En recréer une autre
            ' Supprimer(l) 'original
            ' et recréer le fichier "ZoomOut - RecordList.lst"
            Dim Old_Schedule_Name As String
            Dim New_Schedule_Name As String
            Dim i As Integer
            ' If KTV_Records Is Nothing Then
            If ListView1.Items.Count > 0 Then
                Array.Resize(KTV_Records, ReadRecord.Length)
            Else
                Array.Resize(KTV_Records, 1)
            End If
            KTV_Records = ReadRecord

            ' End If
            Nb_KTV_Records = ListView1.Items.Count
            If CboChannel.SelectedIndex > 0 Then

                ' Check if this record is correct
                If ListView1.Items.Count > 0 Then
                    For i = 0 To UBound(KTV_Records)
                        If _
                            (DateDebut.Value >= KTV_Records(i).StartTime AndAlso _
                             DateDebut.Value <= KTV_Records(i).EndTime) Or _
                            (DateFin.Value >= KTV_Records(i).StartTime AndAlso DateFin.Value <= KTV_Records(i).EndTime) _
                            Then
                            If i <> ListView1.SelectedItems(0).Index Then
                                Dim FenMessage As Message = _
                                        New Message(OverlappingRec, MsgBoxStyle.Exclamation, True)
                                FenMessage.ShowDialog()
                                ' MsgBox("Chevauchement d'enregistrement, vérifiez les horaires")
                                Exit Sub
                            End If
                        End If
                    Next i
                End If

                Old_Schedule_Name = "KTV_" & KTV_Records(ListView1.SelectedItems(0).Index).Name & _
                                    "_" & KTV_Records(ListView1.SelectedItems(0).Index).Channel & _
                                    "_" & _
                                    Format(KTV_Records(ListView1.SelectedItems(0).Index).StartTime, "HHmmddMMyyyy")

                KTV_Records(ListView1.SelectedItems(0).Index).Name = RecordName.Text
                KTV_Records(ListView1.SelectedItems(0).Index).Channel = CboChannel.SelectedIndex
                KTV_Records(ListView1.SelectedItems(0).Index).Profile = CboProfile.Text
                KTV_Records(ListView1.SelectedItems(0).Index).StartTime = DateDebut.Value
                KTV_Records(ListView1.SelectedItems(0).Index).EndTime = DateFin.Value

                CalculRecordType(ListView1.SelectedItems(0).Index)

                New_Schedule_Name = "KTV_" & KTV_Records(ListView1.SelectedItems(0).Index).Name & _
                                    "_" & KTV_Records(ListView1.SelectedItems(0).Index).Channel & _
                                    "_" & _
                                    Format(KTV_Records(ListView1.SelectedItems(0).Index).StartTime, "HHmmddMMyyyy")


                CmdModify.Enabled = True
                CmdDelete.Enabled = True

                ModifyZoomOutFile()
                AddSchedule(DateDebut.Value, DateFin.Value, New_Schedule_Name)
                RemoveSchedule(Old_Schedule_Name)
                ChargeEnregistrement()

            End If
        End If
        Me.BringToFront()
    End Sub

    Private Sub CmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmListRecKTV_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' On regarde quel langue utiliser 22/08/2008
        LanguageCheck(5)

    End Sub

    Private Sub IniChannels()
        Dim i As Integer = 0
        Dim ZName As String = ""
        Dim ZId As String = ""

        Dim KTVChannels() As String = KTvForm.Fct_KTV_Channels(KTV_Path)
        Dim XMLChannels As New ChannelsConfigs

        CboChannel.Items.Clear()
        CboChannel.Items.Add("")
        If KTVChannels.Length > 0 Then
            For i = 1 To (KTVChannels.Length)
                XMLChannels.GetLogChannel(i.ToString, "KTV", KTV_Source, ZName, ZId)
                If ZName <> "" Then
                    CboChannel.Items.Add(ZName)
                Else
                    CboChannel.Items.Add(KTVChannels(i - 1))
                End If
            Next
        End If
    End Sub

    Private Sub ChargeEnregistrement()
        Dim fields() As String, ZoomoutListRecs As String, NextLine As String
        Dim NbEnr As Integer = 0
        Dim NumEnr As Integer
        Dim WLigne As String
        Array.Clear(ReadRecord, 0, ReadRecord.Length)
        Array.Resize(ReadRecord, 1)

        If Dir$(KTV_Path & "\Plugins\ZoomOut\ZoomOut - RecordList.lst") <> "ZoomOut - RecordList.lst" Then
            Exit Sub
        End If
        ZoomoutListRecs = KTV_Path & "\Plugins\ZoomOut\ZoomOut - RecordList.lst"

        ListView1.Items.Clear()

        Try
            Dim LisRec As StreamReader = File.OpenText(ZoomoutListRecs)
            If Not (LisRec Is Nothing) Then
                WLigne = LisRec.ReadLine
                If Not (WLigne Is Nothing) Then
                    NbEnr = CInt(WLigne)
                    If NbEnr > 0 Then
                        Array.Resize(ReadRecord, NbEnr)
                        For NumEnr = 0 To (NbEnr - 1)

                            ' il y a 7 lignes par enregistrements
                            ' la ligne 1 :le nom de l'enregistrement
                            ' la ligne 2 :le num de la chaîne
                            ' la ligne 3 :le début
                            ' la ligne 4 :la fin
                            ' la ligne 5 :les répétions
                            ' la ligne 6 :le profile
                            ' la ligne 7 :nada
                            Dim NumLigne As Integer
                            For NumLigne = 1 To 7

                                NextLine = LisRec.ReadLine
                                If Not (NextLine Is Nothing) Then
                                    If NextLine.Replace(" ", "") <> "" Then
                                        Select Case NumLigne
                                            Case 1
                                                ReadRecord(NumEnr).Name = NextLine
                                            Case 2
                                                ReadRecord(NumEnr).Channel = CInt(NextLine)
                                            Case 3
                                                fields = Split(Trim$(Replace(NextLine, Space$(2), Space$(1))))
                                                ReadRecord(NumEnr).StartTime = _
                                                    CDate(fields(0) & ":" & fields(1) & ":" & fields(2) & " " _
                                                           & fields(4) & "/" & fields(5) & "/" & fields(6))
                                            Case 4
                                                fields = Split(Trim$(Replace(NextLine, Space$(2), Space$(1))))
                                                ReadRecord(NumEnr).EndTime = _
                                                    CDate(fields(0) & ":" & fields(1) & ":" & fields(2) & " " _
                                                           & fields(4) & "/" & fields(5) & "/" & fields(6))

                                            Case 5
                                                fields = Split(Trim$(Replace(NextLine, Space$(2), Space$(1))))
                                                ReadRecord(NumEnr).VPS = CInt(fields(0))
                                                ReadRecord(NumEnr).RecordType = CInt(fields(1))
                                                ReadRecord(NumEnr).Repeat = CInt(fields(2))
                                                ReadRecord(NumEnr).Activity = CInt(fields(3))
                                                ReadRecord(NumEnr).DefaultSettings = CInt(fields(4))
                                            Case 6
                                                ReadRecord(NumEnr).Profile = NextLine
                                            Case 7

                                        End Select
                                    End If
                                End If
                            Next
                            Dim LVI As New ListViewItem
                            LVI.Text = ReadRecord(NumEnr).Name
                            LVI.SubItems.Add(CboChannel.Items(ReadRecord(NumEnr).Channel).ToString)
                            LVI.SubItems.Add(Format(ReadRecord(NumEnr).StartTime, "HH:mm dd/MM/yyyy"))
                            LVI.SubItems.Add(Format(ReadRecord(NumEnr).EndTime, "HH:mm dd/MM/yyyy"))
                            ListView1.Items.Add(LVI)
                        Next
                    End If
                End If
            End If
            LisRec.Dispose()
            LisRec.Close()

        Catch ex As Exception
            Me.Close()
        End Try

        ListView1.Columns(0).Width = 100
        ListView1.Columns(1).Width = 80
        ListView1.Columns(2).Width = 110
        ListView1.Columns(3).Width = 110

        CmdModify.Enabled = True
        CmdDelete.Enabled = True

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RadioButtonUnique.CheckedChanged
        If RadioButtonUnique.Checked Then
            CheckBoxLundi.Enabled = False
            CheckBoxMardi.Enabled = False
            CheckBoxMercredi.Enabled = False
            CheckBoxJeudi.Enabled = False
            CheckBoxVendredi.Enabled = False
            CheckBoxSamedi.Enabled = False
            CheckBoxDimanche.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RadioButtonJournalier.CheckedChanged
        If RadioButtonJournalier.Checked Then
            CheckBoxLundi.Enabled = True
            CheckBoxMardi.Enabled = True
            CheckBoxMercredi.Enabled = True
            CheckBoxJeudi.Enabled = True
            CheckBoxVendredi.Enabled = True
            CheckBoxSamedi.Enabled = True
            CheckBoxDimanche.Enabled = True
        Else
            CheckBoxLundi.Enabled = False
            CheckBoxMardi.Enabled = False
            CheckBoxMercredi.Enabled = False
            CheckBoxJeudi.Enabled = False
            CheckBoxVendredi.Enabled = False
            CheckBoxSamedi.Enabled = False
            CheckBoxDimanche.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles CheckBoxMardi.CheckedChanged

    End Sub


    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ListView1.SelectedIndexChanged
        Try
            Dim i As Integer = ListView1.SelectedIndices(0) + 1
            If i <= ReadRecord.Length Then
                IniCombos(i)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IniCombos(ByVal Num As Integer)
        Num = Num - 1
        If Num < 0 Then
            RadioButtonUnique.Checked = True

            CheckBoxLundi.Enabled = False
            CheckBoxMardi.Enabled = False
            CheckBoxMercredi.Enabled = False
            CheckBoxJeudi.Enabled = False
            CheckBoxVendredi.Enabled = False
            CheckBoxSamedi.Enabled = False
            CheckBoxDimanche.Enabled = False

            ListView1.Columns(0).Width = 100
            ListView1.Columns(1).Width = 80
            ListView1.Columns(2).Width = 110
            ListView1.Columns(3).Width = 110
        Else
            Me.CboChannel.Text = CboChannel.Items(ReadRecord(Num).Channel).ToString
            Me.CboProfile.Text = ReadRecord(Num).Profile
            If ReadRecord(Num).StartTime > Me.DateDebut.MinDate Then
                If ReadRecord(Num).StartTime < Me.DateDebut.MaxDate Then
                    Me.DateDebut.Value = ReadRecord(Num).StartTime
                Else
                    Me.DateDebut.Value = Me.DateDebut.MaxDate
                End If
            Else
                Me.DateDebut.Value = Now
            End If

            If ReadRecord(Num).StartTime > Me.DateFin.MinDate Then
                If ReadRecord(Num).StartTime < Me.DateFin.MaxDate Then
                    Me.DateFin.Value = ReadRecord(Num).EndTime
                Else
                    Me.DateFin.Value = Me.DateFin.MaxDate
                End If
            Else
                Me.DateFin.Value = Me.DateDebut.Value
            End If
            Me.RecordName.Text = ReadRecord(Num).Name

            Select Case (ReadRecord(Num).Repeat + 1)
                Case 1
                    RadioButtonUnique.Checked = True
                Case 2
                    RadioButtonJournalier.Checked = True
                Case 3
                    RadioButtonHebdo.Checked = True
                Case 4
                    RadioButtonMensuel.Checked = True
            End Select


            If RadioButtonJournalier.Checked Then
                Dim Wtemp As Integer = 0

                CheckBoxLundi.Enabled = True
                CheckBoxMardi.Enabled = True
                CheckBoxMercredi.Enabled = True
                CheckBoxJeudi.Enabled = True
                CheckBoxVendredi.Enabled = True
                CheckBoxSamedi.Enabled = True
                CheckBoxDimanche.Enabled = True

                If ReadRecord(Num).RecordType > 64 Then
                    Wtemp = 64
                    Me.CheckBoxSamedi.Checked = True
                Else
                    Me.CheckBoxSamedi.Checked = False
                End If

                If (ReadRecord(Num).RecordType - Wtemp) > 32 Then
                    Wtemp += 32
                    Me.CheckBoxVendredi.Checked = True
                Else
                    Me.CheckBoxVendredi.Checked = False
                End If

                If (ReadRecord(Num).RecordType - Wtemp) > 16 Then
                    Wtemp += 16
                    Me.CheckBoxJeudi.Checked = True
                Else
                    Me.CheckBoxJeudi.Checked = False
                End If

                If (ReadRecord(Num).RecordType - Wtemp) > 8 Then
                    Wtemp += 8
                    Me.CheckBoxMercredi.Checked = True
                Else
                    Me.CheckBoxMercredi.Checked = False
                End If

                If (ReadRecord(Num).RecordType - Wtemp) > 4 Then
                    Wtemp += 4
                    Me.CheckBoxMardi.Checked = True
                Else
                    Me.CheckBoxMardi.Checked = False
                End If

                If (ReadRecord(Num).RecordType - Wtemp) > 2 Then
                    Wtemp += 2
                    Me.CheckBoxLundi.Checked = True
                Else
                    Me.CheckBoxLundi.Checked = False
                End If

                If (ReadRecord(Num).RecordType - Wtemp) = 1 Then
                    Me.CheckBoxDimanche.Checked = True
                Else
                    Me.CheckBoxDimanche.Checked = False
                End If
            Else
                CheckBoxLundi.Enabled = False
                CheckBoxMardi.Enabled = False
                CheckBoxMercredi.Enabled = False
                CheckBoxJeudi.Enabled = False
                CheckBoxVendredi.Enabled = False
                CheckBoxSamedi.Enabled = False
                CheckBoxDimanche.Enabled = False
            End If
        End If


    End Sub

    Private Sub CmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdAdd.Click

        Dim New_Schedule_Name As String
        Dim i As Integer
        ' If KTV_Records Is Nothing Then
        If ListView1.Items.Count > 0 Then
            Array.Resize(KTV_Records, ReadRecord.Length)
        Else
            Array.Resize(KTV_Records, 1)
        End If
        ' End If
        KTV_Records = ReadRecord
        Nb_KTV_Records = ListView1.Items.Count
        If CboChannel.SelectedIndex > 0 Then

            ' Check if this record is correct
            If ListView1.Items.Count > 0 Then
                For i = 0 To UBound(KTV_Records)
                    If _
                        (DateDebut.Value >= KTV_Records(i).StartTime AndAlso DateDebut.Value <= KTV_Records(i).EndTime) Or _
                        (DateFin.Value >= KTV_Records(i).StartTime AndAlso DateFin.Value <= KTV_Records(i).EndTime) _
                        Then
                        Dim FenMessage As Message = _
                                New Message(OverlappingRec, MsgBoxStyle.Exclamation, True)
                        FenMessage.ShowDialog()
                        ' MsgBox("Chevauchement d'enregistrement, vérifiez les horaires")
                        Exit Sub
                    End If
                Next i
            End If

            ' Resize the Table of Records
            If Nb_KTV_Records > 0 Then
                Array.Resize(KTV_Records, KTV_Records.Length + 1)
            Else
                Array.Resize(KTV_Records, 1)
            End If


            Nb_KTV_Records = Nb_KTV_Records + 1

            KTV_Records(Nb_KTV_Records - 1).Name = RecordName.Text
            KTV_Records(Nb_KTV_Records - 1).Channel = CboChannel.SelectedIndex
            KTV_Records(Nb_KTV_Records - 1).Profile = CboProfile.Text
            KTV_Records(Nb_KTV_Records - 1).StartTime = DateDebut.Value
            KTV_Records(Nb_KTV_Records - 1).EndTime = DateFin.Value
            KTV_Records(Nb_KTV_Records - 1).VPS = 1
            KTV_Records(Nb_KTV_Records - 1).RecordType = 0


            CalculRecordType(Nb_KTV_Records - 1)

            KTV_Records(Nb_KTV_Records - 1).Activity = 1
            KTV_Records(Nb_KTV_Records - 1).DefaultSettings = 0

            New_Schedule_Name = "KTV_" & KTV_Records(Nb_KTV_Records - 1).Name & _
                                "_" & KTV_Records(Nb_KTV_Records - 1).Channel & _
                                "_" & Format(KTV_Records(Nb_KTV_Records - 1).StartTime, "HHmmddMMyyyy")


            CmdModify.Enabled = True
            CmdDelete.Enabled = True

            ModifyZoomOutFile()
            AddSchedule(DateDebut.Value, DateFin.Value, New_Schedule_Name)
            ChargeEnregistrement()
            Me.BringToFront()
        End If

    End Sub

    Private Sub ModifyZoomOutFile()


        If Not File.Exists(KTV_Path & "\Plugins\ZoomOut\ZoomOut - RecordList.lst") Then
            File.Create(KTV_Path & "\Plugins\ZoomOut\ZoomOut - RecordList.lst").Close()
        End If

        Dim ZoomoutListRecs As String = KTV_Path & "\Plugins\ZoomOut\ZoomOut - RecordList.lst"
        ' Dim Text As String = KTV_Records.Length.ToString
        Dim i As Integer
        Dim NumLigne As Integer

        Dim Rec As New StreamWriter(ZoomoutListRecs)

        ' Première ligne du fichier indique le nombre d'enregistrements
        For i = 0 To (KTV_Records.Length - 1)
            If Not (KTV_Records(i).Name Is Nothing) Then
                If KTV_Records(i).Name.Replace(" ", "") <> "" Then
                    NumLigne += 1
                End If
            End If
        Next
        Rec.WriteLine(NumLigne.ToString)
        For i = 0 To (KTV_Records.Length - 1)

            ' il y a 7 lignes par enregistrements
            ' la ligne 1 :le nom de l'enregistrement
            ' la ligne 2 :le num de la chaîne
            ' la ligne 3 :le début
            ' la ligne 4 :la fin
            ' la ligne 5 :les répétions
            ' la ligne 6 :le profile
            ' la ligne 7 :nada
            For NumLigne = 1 To 7
                If Not (KTV_Records(i).Name Is Nothing) Then
                    If KTV_Records(i).Name.Replace(" ", "") <> "" Then

                        Select Case NumLigne
                            Case 1
                                Rec.WriteLine(KTV_Records(i).Name)
                                ' Text += Chr(13) & KTV_Records(i).Name
                            Case 2
                                Rec.WriteLine(KTV_Records(i).Channel)
                                ' Text += Chr(13) & KTV_Records(i).Channel
                            Case 3
                                Rec.WriteLine( _
                                               Format(KTV_Records(i).StartTime, "HH mm 0") & " " & _
                                               Weekday(DateAdd("d", -1, KTV_Records(i).StartTime)) & " " & _
                                               Format(KTV_Records(i).StartTime, "dd MM yyyy"))
                                ' Text += Chr(13) & Format(KTV_Records(i).StartTime, "HH mm ss") & " " & Weekday(DateAdd("d", -1, KTV_Records(i).StartTime)) & " " & Format(KTV_Records(i).StartTime, "dd MM yyyy")
                            Case 4
                                Rec.WriteLine( _
                                               Format(KTV_Records(i).EndTime, "HH mm 0") & " " & _
                                               Weekday(DateAdd("d", -1, KTV_Records(i).EndTime)) & " " & _
                                               Format(KTV_Records(i).EndTime, "dd MM yyyy"))
                                ' Text += Chr(13) & Format(KTV_Records(i).EndTime, "HH mm ss") & " " & Weekday(DateAdd("d", -1, KTV_Records(i).EndTime)) & " " & Format(KTV_Records(i).EndTime, "dd MM yyyy")
                            Case 5
                                Rec.WriteLine( _
                                               KTV_Records(i).VPS.ToString & " " & KTV_Records(i).RecordType.ToString & _
                                               " " & _
                                               KTV_Records(i).Repeat & " " & KTV_Records(i).Activity & " " & _
                                               KTV_Records(i).DefaultSettings.ToString)
                                ' Text += Chr(13) & KTV_Records(i).VPS.ToString & " " & KTV_Records(i).RecordType.ToString & " " & KTV_Records(i).Repeat & " " & KTV_Records(i).Activity & " " & KTV_Records(i).DefaultSettings.ToString
                            Case 6

                                If KTV_Records(i).Profile = "" Then

                                    ' KTV_Records(i).Profile = "Zo_No_Compression_Profile"
                                End If
                                Rec.WriteLine(KTV_Records(i).Profile)
                                ' Text += Chr(13) & KTV_Records(i).Profile
                            Case 7
                                Rec.WriteLine(" ")
                                ' Text += Chr(13)
                        End Select
                    End If
                End If
            Next
        Next
        Rec.WriteLine(" ")
        Rec.WriteLine(" ")
        Rec.Flush()
        Rec.Dispose()
        Rec.Close()

        Try
            ' Dim Rec As New IO.StreamWriter(ZoomoutListRecs)
            ' Rec.Write(Text)
            ' Rec.Flush()
            ' Rec.Dispose()
        Catch ex As Exception
            Dim FenMessage As Message = _
                    New Message(CantWhrite & ZoomoutListRecs & ".", MsgBoxStyle.Exclamation, True)
            FenMessage.ShowDialog()
            ' MessageBox.Show("Impossible d'écrire dans " & ZoomoutListRecs & ".")
        End Try


    End Sub

    Private Sub RemoveSchedule(ByVal Name As String)

        Dim RetVal As Long
        Dim cmd As String

        cmd = "/c  schtasks /delete /f /tn " & Chr(34) & StripForbiddenChars(Name) & "_start" & Chr(34)
        ' Process.Start(cmd)
        Process.Start("schtasks", cmd)

        RetVal = ShellExecute(Me.Handle.ToInt32, "open", "cmd", cmd, "", 0)

        cmd = "/c  schtasks /delete /f /tn " & Chr(34) & StripForbiddenChars(Name) & "_stop" & Chr(34)
        RetVal = ShellExecute(Me.Handle.ToInt32, "open", "cmd", cmd, "", 0)
        ' Process.Start(cmd)
        Process.Start("schtasks", cmd)

    End Sub

    Private Sub AddSchedule(ByVal date_start As Date, ByVal date_stop As Date, ByVal Name As String)

        'Dim RetVal As Long
        Dim cmd As String

        Dim UserName As String
        Dim Password As String

        Dim ZoomoutListRecs As String = "*****************************************************************"
        Dim Corps As String = ""
        UserName = ""
        Password = ""


        cmd = "/create /tn " & Chr(34) & StripForbiddenChars(Name) & Chr(34) & " /sc once /sd " _
              & Format(date_start, "dd/MM/yyyy") & " /st " & Format(DateAdd("n", 1, date_start), "HH:mm:00") _
              & " /TR " & Chr(34) & KTV_Path & "\K!TV.exe" & Chr(34)

        Process.Start("schtasks", cmd)
        Me.BringToFront()

        ' il y a 7 lignes par enregistrements
        ' la ligne 1 :le nom de l'enregistrement
        ' la ligne 2 :le num de la chaîne
        ' la ligne 3 :le début
        ' la ligne 4 :la fin
        ' la ligne 5 :les répétions
        ' la ligne 6 :le profile
        ' la ligne 7 :nada
        ' Et la première ligne du fichier est le nombre d'enregistrement

        'If Dir$(KTV_Path & "\Plugins\ZoomOut\ZoomOut - RecordList.lst") <> "ZoomOut - RecordList.lst" Then Exit Sub
        'ZoomoutListRecs = KTV_Path & "\Plugins\ZoomOut\ZoomOut - RecordList.lst"

        'If Not File.Exists(ZoomoutListRecs) Then
        'File.Create(ZoomoutListRecs)
        'End If

        ' On va lire toute les ligne du fichier sauf la première
        ' La première ligne sera remplacé par le noveau nombre d'enregistrement
        ' Ensuite on rajoute le nouvel en regitrement à la fin

        'Try
        'Dim NbEnr As Integer
        'Dim NumEnr As Integer
        'Dim NextLine As String
        '
        'Dim LisRec As StreamReader = File.OpenText(ZoomoutListRecs)
        'If Not (LisRec Is Nothing) Then

        'NbEnr = CInt(LisRec.ReadLine)
        'If NbEnr > 0 Then
        'Array.Resize(ReadRecord, NbEnr)
        'For NumEnr = 0 To (NbEnr - 1)
        'Dim NumLigne As Integer
        ' For NumLigne = 1 To 7
        'NextLine = LisRec.ReadLine
        '  Corps = Corps & Chr(10) & NextLine
        '  Next
        ' Next
        'End If
        'Corps = NbEnr.ToString & Chr(10) & Corps

        'Else

        ' Si fichier vide

        'Corps = "1"
        ' End If
        ' Corps = Corps & Chr(10) & KTV_Records(Nb_KTV_Records - 1).Name & Chr(10) & KTV_Records(Nb_KTV_Records - 1).Channel.ToString
        ''ligne 3 ex: 16 38 0 6 29 11 2008 => pour : 16:38:00 le 29/11/2008
        'Corps = Corps & Chr(10) & KTV_Records(Nb_KTV_Records - 1).StartTime.Hour.ToString & " " & KTV_Records(Nb_KTV_Records - 1).StartTime.Minute.ToString
        'Corps = Corps & " 0 6 " & KTV_Records(Nb_KTV_Records - 1).StartTime.Day.ToString
        'Corps = Corps & " " & KTV_Records(Nb_KTV_Records - 1).StartTime.Month.ToString
        'Corps = Corps & " " & KTV_Records(Nb_KTV_Records - 1).StartTime.Year.ToString
        'Ligne 4 date fin
        'Corps = Corps & Chr(10) & KTV_Records(Nb_KTV_Records - 1).EndTime.Hour.ToString & " " & KTV_Records(Nb_KTV_Records - 1).EndTime.Minute.ToString
        'Corps = Corps & " 0 6 " & KTV_Records(Nb_KTV_Records - 1).EndTime.Day.ToString
        'Corps = Corps & " " & KTV_Records(Nb_KTV_Records - 1).EndTime.Month.ToString
        'Corps = Corps & " " & KTV_Records(Nb_KTV_Records - 1).EndTime.Year.ToString
        ''Ligne 5 Répitions
        'Corps = Corps & Chr(10) & "1 " & KTV_Records(Nb_KTV_Records - 1).RecordType.ToString
        'Corps = Corps & " " & KTV_Records(Nb_KTV_Records - 1).Repeat.ToString
        'Corps = Corps & " " & KTV_Records(Nb_KTV_Records - 1).Activity.ToString
        'Ligne 6 profile + ligne blanche
        'Corps = Corps & Chr(10) & "1 " & KTV_Records(Nb_KTV_Records - 1).Profile.ToString & Chr(10)
        'Catch ex As Exception


        'End Try


        'cmd = "/create /tn " & Chr(34) & StripForbiddenChars(Name) & "_stop" & Chr(34) & " /sc once /sd " & Format(date_stop, "dd/mm/yyyy") & " /st " & Format(DateAdd("n", 1, date_stop), "HH:MM:ss") & " /tr " & Chr(34) & "\" & Chr(34) & "%SystemRoot%\system32\schtasks.exe" & "\" & Chr(34) & " /end /tn " & "\" & Chr(34) & StripForbiddenChars(Name) & "_start" & "\" & Chr(34) & Chr(34) & Chr(34)
        'Process.Start("schtasks", cmd)

        'Process.Start("schtasks", "/create /SC daily /ST 04:00:00 /TN Checkdmin /TR C:\Avertisement.bat /RU c2d\Ronaldo /U c2d\Ronaldo /it")
        'Process.Start("schtasks", "/create /SC daily /ST 12:00:00 /TN TacheTest /TR C:\Avertisement.bat")
        'cmd = "/c  %SystemRoot%\system32\schtasks.exe" & Chr(34) & " /create /ru " & UserName & " /rp " & Password & " /tn " & Chr(34) & StripForbiddenChars(Name) & "_start" & Chr(34) & " /sc once /sd " & Format(date_start, "dd/mm/yyyy") & " /st " & Format(DateAdd("n", -1, date_start), "HH:MM:ss") & " /tr " & Chr(34) & "\" & Chr(34) & KTV_Path & "\K!TV.exe" & "\" & Chr(34) & Chr(34) & Chr(34)
        'RetVal = ShellExecute(Me.Handle.ToInt32, "open", "cmd", cmd, "", 0)
        'Process.Start(cmd)
        'cmd = "/c  %SystemRoot%\system32\schtasks.exe" & Chr(34) & " /create /ru " & UserName & " /rp " & Password & " /tn " & Chr(34) & StripForbiddenChars(Name) & "_stop" & Chr(34) & " /sc once /sd " & Format(date_stop, "dd/mm/yyyy") & " /st " & Format(DateAdd("n", 1, date_stop), "HH:MM:ss") & " /tr " & Chr(34) & "\" & Chr(34) & "%SystemRoot%\system32\schtasks.exe" & "\" & Chr(34) & " /end /tn " & "\" & Chr(34) & StripForbiddenChars(Name) & "_start" & "\" & Chr(34) & Chr(34) & Chr(34)
        'RetVal = ShellExecute(Me.Handle.ToInt32, "open", "cmd", cmd, "", 0)
        'Process.Start(cmd)
        'http://technet2.microsoft.com/windowsserver/en/library/1d284efa-9d11-46c2-a8ef-87b297c68d171033.mspx?mfr=true
        'schtasks /create /tn TaskName /tr TaskRun /sc weekly [/mo {1 - 52}] [/d {MON - SUN[,MON - SUN...] | *}] [/st HH:MM] [/sd StartDate] [/ed EndDate] [/it] [/ru {[Domain\]User [/rp Password] | System}] [/s Computer [/u [Domain\]User [/p Password]]]
        'schtasks /create /tn TaskName /tr TaskRun /sc monthly [/mo {1 - 12}] [/d {1 - 31}] [/st HH:MM] [/sd StartDate] [/ed EndDate] [/it] [/ru {[Domain\]User [/rp Password] | System}] [/s Computer [/u [Domain\]User [/p Password]]]
        'schtasks /create /tn TaskName /tr TaskRun /sc daily [/mo {1 - 365}] [/st HH:MM] [/sd StartDate] [/ed EndDate] [/it] [/ru {[Domain\]User [/rp Password] | System}] [/s Computer [/u [Domain\]User [/p Password]]]
        'schtasks /create /tn TaskName /tr TaskRun /sc once /st HH:MM [/sd StartDate] [/it] [/ru {[Domain\]User [/rp Password] | System}] [/s Computer [/u [Domain\]User [/p Password]]]


        'schtasks /create /tn "Check Admin" /tr AdminCheck.exe /sc weekly /d FRI /st 04:00 /s Public /u Domain3\Admin06 /ru Public\Admin01 /it
    End Sub

    Private Function StripForbiddenChars(ByVal Value As String) As String

        Dim i As Integer
        Dim Test As String
        Const BAD_FILENAME_CHARS As String = """" & "/" & "\" & ":" & "|" & "<" & ">" & "*" & "?"

        ' Test illegal and non-printable characters
        Test = BAD_FILENAME_CHARS
        For i = 0 To 31
            Test = Test & Chr(i)
        Next
        For i = 1 To Len(Value)
            If InStr(1, Test, Mid$(Value, i, 1)) > 0 Then
                Mid(Value, i, 1) = "_"
            End If
        Next
        StripForbiddenChars = Value
    End Function

    Private Sub GetCompressionProfiles()

        Dim szBuf As String
        Dim SectionArr() As String
        Dim i As Integer, j As Integer
        Dim File_Compression As String

        Try
            File_Compression = KTV_Path & "\Plugins\ZoomOut\Compressor.dat"

            szBuf = INIRead_SectionNames(File_Compression)
            SectionArr = Split(szBuf, vbNullChar)

            KTV_DefaultProfile = INIRead_Value(File_Compression, "PROFILES", "DefaultProfile")
            Array.Resize(KTV_Profiles, KTV_Profiles.Length + 1)
            j = 0
            For i = 0 To UBound(SectionArr)
                If SectionArr(i) <> "Profiles" Then
                    KTV_Profiles(j) = SectionArr(i)
                    j = j + 1
                End If
            Next i
        Catch ex As Exception

        End Try

        If KTV_Profiles Is Nothing Then
            Array.Resize(KTV_Profiles, 1)
            KTV_Profiles(0) = "Zo_No_Compression_Profile"
        Else
            If KTV_Profiles.Length < 1 Then
                Array.Resize(KTV_Profiles, 1)
                KTV_Profiles(0) = "Zo_No_Compression_Profile"
            End If
        End If

        For i = 0 To (KTV_Profiles.Length - 1)
            CboProfile.Items.Add(KTV_Profiles(i))
        Next
        CboProfile.Text = CboProfile.Items(0).ToString
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles GroupBoxDetails.Enter

    End Sub

    Private Sub Label6_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        CmdModify.Enabled = False
        CmdDelete.Enabled = False
        'Nb_KTV_Records = 0

        KTV_Source = My.Settings.KtvSource
        KTV_Path = My.Settings.KtvPath

        ListView1.Columns.Add("Nom", -2, HorizontalAlignment.Right)
        ListView1.Columns.Add("Chaîne", 40, HorizontalAlignment.Left)
        ListView1.Columns.Add("Début", 40, HorizontalAlignment.Left)
        ListView1.Columns.Add("Fin", 40, HorizontalAlignment.Left)

        GetCompressionProfiles()

        If KTV_Source = "" Or KTV_Path = "" Then
            'nAction = 0

            ' MessageBox.Show("Veuillez paramètrer les correspondances ZGuideTv <=> K!TV.")
            Dim FenMessage As Message = _
                    New Message(ParameterKtvChannel, MsgBoxStyle.Exclamation, True)
            FenMessage.ShowDialog()
            KTvForm.Show()
            Me.Dispose()
            Me.Close()
        Else
            IniChannels()
            DateDebut.Value = Now
            DateFin.Value = Now

            ChargeEnregistrement()

            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Focused = True
                ListView1.Items(0).Selected = True
            End If

            If ListView1.Items.Count > 0 Then
                IniCombos(1)
            Else
                IniCombos(0)
            End If

            Select Case nAction
                Case 0

                    ' il n'y a rien à faire
                Case 1
                    CboChannel.SelectedIndex() = Mainform.KtvChannel
                    DateDebut.Value = CDate(EmmissionSel.pstart)
                    DateFin.Value = CDate(EmmissionSel.pstop)
                    If CboProfile.Items.Count > 0 Then
                        CboProfile.SelectedIndex() = 0
                    End If
                    RecordName.Text = EmmissionSel.Ptitle

                    RadioButtonUnique.Checked = True

                    CheckBoxLundi.Enabled = False
                    CheckBoxMardi.Enabled = False
                    CheckBoxMercredi.Enabled = False
                    CheckBoxJeudi.Enabled = False
                    CheckBoxVendredi.Enabled = False
                    CheckBoxSamedi.Enabled = False
                    CheckBoxDimanche.Enabled = False
                Case 2
                    ' il n'y a rien à faire
            End Select

            'nAction = 0
        End If

    End Sub

    Public Sub Fonction(ByVal nTemp As Integer)
        nAction = nTemp
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RadioButtonHebdo.CheckedChanged
        If RadioButtonHebdo.Checked Then
            CheckBoxLundi.Enabled = False
            CheckBoxMardi.Enabled = False
            CheckBoxMercredi.Enabled = False
            CheckBoxJeudi.Enabled = False
            CheckBoxVendredi.Enabled = False
            CheckBoxSamedi.Enabled = False
            CheckBoxDimanche.Enabled = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RadioButtonMensuel.CheckedChanged
        If RadioButtonMensuel.Checked Then
            CheckBoxLundi.Enabled = False
            CheckBoxMardi.Enabled = False
            CheckBoxMercredi.Enabled = False
            CheckBoxJeudi.Enabled = False
            CheckBoxVendredi.Enabled = False
            CheckBoxSamedi.Enabled = False
            CheckBoxDimanche.Enabled = False
        End If
    End Sub

    Private Sub CalculRecordType(ByVal NumEnr As Integer)
        If CheckBoxDimanche.Checked Then
            KTV_Records(NumEnr).RecordType = 1
        End If

        If CheckBoxLundi.Checked Then
            KTV_Records(NumEnr).RecordType += 2
        End If

        If CheckBoxMardi.Checked Then
            KTV_Records(NumEnr).RecordType += 4
        End If

        If CheckBoxMercredi.Checked Then
            KTV_Records(NumEnr).RecordType += 8
        End If

        If CheckBoxJeudi.Checked Then
            KTV_Records(NumEnr).RecordType += 16
        End If

        If CheckBoxVendredi.Checked Then
            KTV_Records(NumEnr).RecordType += 32
        End If

        If CheckBoxSamedi.Checked Then
            KTV_Records(NumEnr).RecordType += 32
        End If

        KTV_Records(NumEnr).Repeat = 0

        If RadioButtonJournalier.Checked Then
            KTV_Records(NumEnr).Repeat = 1
        Else
            If RadioButtonHebdo.Checked Then
                KTV_Records(NumEnr).Repeat = 2
            Else
                If RadioButtonJournalier.Checked Then
                    KTV_Records(NumEnr).Repeat = 4
                Else

                End If
            End If
        End If
    End Sub

    Private Sub CmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdDelete.Click
        If ListView1.SelectedItems.Count > 0 Then

            ' Supprimer l'original                           |
            ' et recréer le fichier "ZoomOut - RecordList.lst"
            Dim Old_Schedule_Name As String

            Dim i As Integer
            ' If KTV_Records Is Nothing Then
            If ListView1.Items.Count > 0 Then
                Array.Resize(KTV_Records, ReadRecord.Length)
            Else
                Array.Resize(KTV_Records, 1)
            End If
            KTV_Records = ReadRecord

            ' End If
            Nb_KTV_Records = ListView1.Items.Count
            If CboChannel.SelectedIndex > 0 Then

                ' Check if this record is correct |
                If ListView1.Items.Count > 0 Then
                    For i = 0 To UBound(KTV_Records)
                        If _
                            (DateDebut.Value >= KTV_Records(i).StartTime AndAlso _
                             DateDebut.Value <= KTV_Records(i).EndTime) Or _
                            (DateFin.Value >= KTV_Records(i).StartTime AndAlso DateFin.Value <= KTV_Records(i).EndTime) _
                            Then
                            If i <> ListView1.SelectedItems(0).Index Then
                                ' MsgBox ("Chevauchement d'enregistrement, vérifiez les horaires")
                                Dim FenMessage As Message = _
                                        New Message(OverlappingRec, MsgBoxStyle.Exclamation, True)
                                FenMessage.ShowDialog()
                                Exit Sub
                            End If
                        End If
                    Next i
                End If

                Old_Schedule_Name = "KTV_" & KTV_Records(ListView1.SelectedItems(0).Index).Name & _
                                    "_" & KTV_Records(ListView1.SelectedItems(0).Index).Channel & _
                                    "_" & _
                                    Format(KTV_Records(ListView1.SelectedItems(0).Index).StartTime, "HHmmddMMyyyy")

                KTV_Records(ListView1.SelectedItems(0).Index).Name = ""


                CalculRecordType(ListView1.SelectedItems(0).Index)


                ModifyZoomOutFile()
                RemoveSchedule(Old_Schedule_Name)
                ChargeEnregistrement()

                If ListView1.Items.Count < 1 Then
                    CmdModify.Enabled = False
                    CmdDelete.Enabled = False
                End If

            End If
        End If
        Me.BringToFront()
    End Sub
End Class