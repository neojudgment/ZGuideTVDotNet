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
Imports System.Configuration
Imports System.Globalization
Imports System.IO
Imports System.IO.Compression
Imports System.Threading

' ReSharper disable CheckNamespace
Public Class Gestionbdd
    ' ReSharper restore CheckNamespace

#Region "Propery"

    Private ReadOnly _userConfigDirectory As Configuration =
                         ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)

    Private _selectedItems As String
    Public MessageBoxFileRestore As String
    Public MessageBoxFileRestore1 As String
    Public MessageBoxFileRestore2 As String
    Public MessageBoxFileRestoreTitre As String
    Public MessageBoxNoRestoreSelected As String
    Public MessageBoxNoRestoreSelectedTitre As String
    Public MessageBoxNoRestoreElement As String
    Public MessageBoxNoRestoreElementTitre As String
    Public MessageboxSaveDone As String
    Public MessageboxSaveDoneTitre As String
    Public MessageboxRenameDone As String
    Public MessageboxRenameDoneTitre As String
    Public MessageboxDeleteDone As String
    Public MessageboxDeleteDoneTitre As String
    Public MessageBoxNoDirectorySelected As String
    Public MessageBoxNoDirectorySelectedTitre As String
    Public MessageBoxNoDirectoryExists As String
    Public MessageBoxNoDirectoryExistsTitre As String
    Public InputBoxRenameBdd As String
    Public InputBoxRenameBddTitre As String
    Public InputBoxNameBdd As String
    Public InputBoxNameBddTitre As String

    Public DestinationLogos As String = LogosPath

#End Region

    Private Sub GestionbddFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' On quitte
        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonCancel dans Gestionbdd")

        Mainform.ResumeLayout()
    End Sub

    Private Sub GestionbddLoad(sender As Object, e As EventArgs) Handles Me.Load

        ' Néo 21/10/2010
        Trace.WriteLine(DateTime.Now & " " & "On entre dans le Load de Gestionbdd")

        ' On va lire l'état des CheckBox
        With My.Settings
            If .RestaurationDataBase = 1 Then
                CheckBoxRestaurationDataBase.Checked = True
            End If
            If .RestaurationChaines = 1 Then
                CheckBoxRestaurationChaines.Checked = True
            End If
            If .RestaurationUrl = 1 Then
                CheckBoxRestaurationUrl.Checked = True
            End If
            If .RestaurationUserConfig = 1 Then
                CheckBoxRestaurationUserConfig.Checked = True
            End If
            If .RestaurationLogos = 1 Then
                CheckBoxRestaurationLogos.Checked = True
            End If
        End With

        LanguageCheck(17)
        RemplirListview()

        TextBoxDirectory.Text = My.Settings.DirectoryBackup
    End Sub

    Private Sub RemplirListview()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le RemplirListview() de Gestionbdd")

        If String.IsNullOrEmpty(My.Settings.DirectoryBackup) Then
            Exit Sub
        End If

        _selectedItems = ""

        ' On crée les colonnes de la ListView
        With ListViewGestionBdd
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add(LngListViewGestionBddColumns0, 130, HorizontalAlignment.Left)
            .Columns.Add(LngListViewGestionBddColumns1, 90, HorizontalAlignment.Center)
            .Columns.Add(LngListViewGestionBddColumns2, 170, HorizontalAlignment.Center)
        End With

        Dim dFolder As DirectoryInfo = New DirectoryInfo(My.Settings.DirectoryBackup)

        ' Néo le 06/11/2013
        If Not Directory.Exists(dFolder.ToString()) Then

            ' ReSharper disable NotAccessedVariable
            Dim boxNoDirectoryExists As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoDirectoryExists =
                MessageBox.Show(
                    MessageBoxNoDirectoryExists, MessageBoxNoDirectoryExistsTitre, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            My.Settings.DirectoryBackup = String.Empty
            My.Settings.Save()
            Exit Sub
        End If

        Dim fFileArray() As FileInfo = dFolder.GetFiles("*.zip")

        Dim fFile As FileInfo
        Dim lCurrent As ListViewItem
        Dim i As Integer
        Dim reste As Integer
        Dim myfileName As String

        ' On peuple la ListView
        For Each fFile In fFileArray
            i = +1
            myfileName = fFile.Name
            myfileName = Strings.Left(myfileName, myfileName.Length - 4)
            lCurrent = ListViewGestionBdd.Items.Add(myfileName)
            Dim lengthFFile As String = (fFile.Length \ 1024 + 1).ToString()
            lCurrent.SubItems.Add(lengthFFile)
            Dim creationfFile As String = (fFile.LastWriteTime).ToString()
            lCurrent.SubItems.Add(creationfFile)

            Math.DivRem(i, 2, reste)
            If (reste = 0) Then
                lCurrent.BackColor = Color.WhiteSmoke
            End If
        Next

        ListViewGestionBdd.SelectedItems.Clear()
    End Sub

    Private Sub ButtonCancelClick(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ' On quitte
        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonCancel dans Gestionbdd")
        Close()
    End Sub

    Private Sub ButtonSaveClick(sender As Object, e As EventArgs) Handles ButtonSave.Click

        If String.IsNullOrEmpty(My.Settings.DirectoryBackup) Then

            ' ReSharper disable NotAccessedVariable
            Dim boxNoDirectorySelected As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoDirectorySelected =
                MessageBox.Show(
                    MessageBoxNoDirectorySelected, MessageBoxNoDirectorySelectedTitre, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim tempDirectory As String = My.Settings.DirectoryBackup & "\Temp\"
        Dim destinationDataBase As String = My.Settings.DirectoryBackup & "\Temp\db_progs.db3"
        Dim destinationCategory As String = My.Settings.DirectoryBackup & "\Temp\Categorie.db3"
        Dim destinationChannelFile As String = My.Settings.DirectoryBackup & "\Temp\ZGuideTVDotNet.channels.set"
        Dim destinationUrlFile As String = My.Settings.DirectoryBackup & "\Temp\ZGuideTVDotNet.url.set"
        Dim destinationUserConfig As String = My.Settings.DirectoryBackup & "\Temp\user.config"

        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonSave dans Gestionbdd")
        My.Settings.GestionSave = True

        ' Thumbs.db
        If tempDirectory.Contains("Thumbs.db") Then
            File.Delete(tempDirectory & "\Thumbs.db")
        End If

        ' On crée les répertoires si il n'existe pas
        If Not Directory.Exists(tempDirectory) Then
            Directory.CreateDirectory(My.Settings.DirectoryBackup & "\Temp\")
        End If

        Dim i As Integer = 0
        Const fileMask7Z As String = "db_progs({0})"

        Dim name7Z As String

        'On scanne le répertoire et on incrémente
        name7Z = String.Format(CultureInfo.CurrentCulture, fileMask7Z, i)

        Do While My.Computer.FileSystem.FileExists(My.Settings.DirectoryBackup & "\" & name7Z & ".zip")
            i += 1
            name7Z = String.Format(CultureInfo.CurrentCulture, fileMask7Z, i)
        Loop

        ' On demande un nom pour la sauvegarde
        Dim strInput As String = InputBox(InputBoxNameBdd,
                                          InputBoxNameBddTitre,
                                          name7Z)

        ' Si le champs n'est pas vide et s'il n'est pas identique au nom par défaut
        If strInput <> "" AndAlso strInput <> name7Z Then
            name7Z = strInput
        ElseIf strInput = "" Then
            Exit Sub
        End If

        ' On lance une sauvegarde
        ButtonSave.Enabled = False
        ButtonDelete.Enabled = False
        ButtonCancel.Enabled = False
        ButtonRestore.Enabled = False
        ButtonRename.Enabled = False

        ' Néo le 21/09/2010
        ' On crée un thread pour l'affichage de la ProgressBarSave
        Dim threadProgressBarSave As New Thread(AddressOf ThreadProgressBar)
        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "On lance le ThreadProgressBarSave")
        threadProgressBarSave.IsBackground = True
        threadProgressBarSave.Start()

        Trace.WriteLine(DateTime.Now & " " & "On commense à sauver la config de zg")

        ' emplacement fichier original db_progs.db3
        Dim sDbFile As String = BddPath & "db_progs.db3"
        ' emplacement fichier original Categorie.db3
        Dim catFile As String = BddPath & "Categorie.db3"
        ' emplacement fichier original ZGuideTVDotNet.channels.set
        Dim sChannelFile As String = ChannelSetPath & "ZGuideTVDotNet.channels.set"
        ' emplacement fichier original ZGuideTVDotNet.url.set
        Dim sUrlFile As String = UrlPath & "ZGuideTVDotNet.url.set"

        Dim targetName7Z As String = My.Settings.DirectoryBackup & "\" & name7Z

        Try
            ' On copie la bdd, le channel.set et le ZGuideTVDotNet.url dans mes "documents\ZGuideTVDotNet"
            If File.Exists(sDbFile) Then
                File.Copy(sDbFile, destinationDataBase, True)
            End If
            If File.Exists(sChannelFile) Then
                File.Copy(sChannelFile, destinationChannelFile, True)
            End If
            If File.Exists(sUrlFile) Then
                File.Copy(sUrlFile, destinationUrlFile, True)
            End If
            If File.Exists(_userConfigDirectory.FilePath) Then
                File.Copy(_userConfigDirectory.FilePath, destinationUserConfig, True)
            End If
            If File.Exists(catFile) Then
                File.Copy(catFile, destinationCategory, True)
            End If

            Dim dFile As String
            Dim dFilePath As String
            For Each fName As String In Directory.GetFiles(DestinationLogos)
                If File.Exists(fName) Then
                    dFile = Path.GetFileName(fName)
                    dFilePath = tempDirectory & "\" & dFile
                    File.Copy(fName, dFilePath, True)
                End If
            Next

            Trace.WriteLine(
                DateTime.Now & " " &
                "On vient de copier la bdd, channel.set et le ZGuideTVDotNet.url")

            Try

                ZipFile.CreateFromDirectory(tempDirectory, targetName7Z & ".zip", CompressionLevel.Optimal, False)

                Application.DoEvents()

                If (Directory.Exists(tempDirectory)) Then
                    For Each fName As String In Directory.GetFiles(tempDirectory)
                        If File.Exists(fName) Then
                            File.Delete(fName)
                        End If
                    Next
                End If

                Trace.WriteLine(DateTime.Now & " " & "On viens de compresser les fichiers")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Exception")
                Trace.WriteLine(DateTime.Now & " " & "Erreur lors de la compression ds fichier")
            End Try

            ButtonSave.Enabled = True
            ButtonDelete.Enabled = True
            ButtonCancel.Enabled = True
            ButtonRestore.Enabled = True
            ButtonRename.Enabled = True

            ' On arrête le thread de la ProgressBarSave
            Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du ProgressBarSave")
            SyncLock threadProgressBarSave
                threadProgressBarSave.Abort()
            End SyncLock

            RemplirListview()

            Application.DoEvents()
            BringToFront()

            ' ReSharper disable NotAccessedVariable
            Dim boxSaveDone As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxSaveDone =
                MessageBox.Show(
                    MessageboxSaveDone, MessageboxSaveDoneTitre, MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


            Trace.WriteLine(DateTime.Now & " " & "On sort de Gestionbdd Save")
        Catch
            Trace.WriteLine(DateTime.Now & " " &
                            "Erreur : lors de la sauvegarde de la bdd. On sort de Gestionbdd Save")
            Exit Sub
        End Try

        ListViewGestionBdd.SelectedItems.Clear()
    End Sub

    Private Sub ThreadProgressBar()

        ' Néo le 08/09/2010
        ' Affichage de la progressbar dans un thread
        Trace.WriteLine(DateTime.Now & " " & "On entre dans ThreadProgressBar")
        ProgressBar.ShowDialog()
    End Sub

    Private Sub ListMouseDown(sender As Object,
                              e As MouseEventArgs) Handles ListViewGestionBdd.MouseUp

        Trace.WriteLine(DateTime.Now & " " & "On entre dans ListViewGestionBdd")

        _selectedItems = ""

        Try
            ' On regarde quelle sauvegarde est sélectionnée
            Dim clickedItem As ListViewItem = ListViewGestionBdd.GetItemAt(5, e.Y)
            If (clickedItem IsNot Nothing) Then
                clickedItem.Selected = True
                clickedItem.Focused = True
                _selectedItems = clickedItem.Text
            End If

            If _selectedItems = "" Then
                ListViewGestionBdd.SelectedItems.Clear()
            End If

            Trace.WriteLine(DateTime.Now & " " & "On quitte ListViewGestionBdd")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception")
        End Try
    End Sub

    Private Sub ButtonDeleteClick(sender As Object, e As EventArgs) Handles ButtonDelete.Click

        ' On efface la sauvegarde sélectionnée
        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonDelete dans Gestionbdd")

        If String.IsNullOrEmpty(My.Settings.DirectoryBackup) Then
            Exit Sub
        End If

        If Not (Not _selectedItems Is Nothing AndAlso String.IsNullOrEmpty(_selectedItems)) Then

            ButtonSave.Enabled = False
            ButtonDelete.Enabled = False
            ButtonCancel.Enabled = False
            ButtonRestore.Enabled = False
            ButtonRename.Enabled = False

            If File.Exists(My.Settings.DirectoryBackup & "\" & _selectedItems & ".zip") Then
                File.Delete(My.Settings.DirectoryBackup & "\" & _selectedItems & ".zip")

                RemplirListview()

                ' ReSharper disable NotAccessedVariable
                Dim boxDeleteDone As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxDeleteDone =
                    MessageBox.Show(
                        MessageboxDeleteDone, MessageboxDeleteDoneTitre, MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                ButtonSave.Enabled = True
                ButtonDelete.Enabled = True
                ButtonCancel.Enabled = True
                ButtonRestore.Enabled = True
                ButtonRename.Enabled = True
            End If

        Else
            ' ReSharper disable NotAccessedVariable
            Dim boxNoRestoreSelected As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoRestoreSelected =
                MessageBox.Show(
                    MessageBoxNoRestoreSelected, MessageBoxNoRestoreSelectedTitre, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If

        ListViewGestionBdd.SelectedItems.Clear()
        Trace.WriteLine(DateTime.Now & " " & "On quitte Gestionbdd ButtonDelete")
    End Sub

    Private Sub ButtonRestoreClick(sender As Object, e As EventArgs) _
        Handles ButtonRestore.Click, ListViewGestionBdd.DoubleClick

        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonRestore dans Gestionbdd")
        My.Settings.GestionSave = False

        If _
            My.Settings.RestaurationDataBase = 1 OrElse My.Settings.RestaurationChaines = 1 OrElse
            My.Settings.RestaurationUrl = 1 OrElse My.Settings.RestaurationUserConfig = 1 OrElse
            My.Settings.RestaurationLogos = 1 Then

            If Not (Not _selectedItems Is Nothing AndAlso String.IsNullOrEmpty(_selectedItems)) Then
                If File.Exists(My.Settings.DirectoryBackup & "\" & _selectedItems & ".zip") Then

                    ButtonSave.Enabled = False
                    ButtonDelete.Enabled = False
                    ButtonCancel.Enabled = False
                    ButtonRestore.Enabled = False
                    ButtonRename.Enabled = False

                    ' Néo le 21/09/2010
                    ' On crée un thread pour l'affichage de la ProgressBarRestore
                    Dim threadProgressBarRestore As New Thread(AddressOf ThreadProgressBar)
                    Trace.WriteLine(" ")
                    Trace.WriteLine(DateTime.Now & " " & "On lance le ThreadProgressBarRestore")
                    threadProgressBarRestore.IsBackground = True
                    threadProgressBarRestore.Start()

                    Hide()

                    Trace.WriteLine(DateTime.Now & " " & "On commence à restaurer la config de zg")
                    If Not Directory.Exists(My.Settings.DirectoryBackup & "\Temp\") Then
                        Directory.CreateDirectory(My.Settings.DirectoryBackup & "\Temp\")
                    End If

                    Try

                        ZipFile.ExtractToDirectory(My.Settings.DirectoryBackup & "\" & _selectedItems & ".zip",
                                                   My.Settings.DirectoryBackup & "\Temp\")

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Exception")
                        Trace.WriteLine(DateTime.Now & "Erreur lors de la décompression du backup")
                    End Try

                    ' On recopie les fichiers sauvegardés à leurs emplacements d'origine selon la sélection effectuée
                    If My.Settings.RestaurationDataBase = 1 Then
                        If File.Exists(My.Settings.DirectoryBackup & "\Temp\" & "db_progs.db3") Then
                            File.Copy(My.Settings.DirectoryBackup & "\Temp\" & "db_progs.db3", BddPath & "db_progs.bak",
                                      True)
                        End If
                        If File.Exists(My.Settings.DirectoryBackup & "\Temp\" & "Categorie.db3") Then
                            File.Copy(My.Settings.DirectoryBackup & "\Temp\" & "Categorie.db3",
                                      BddPath & "Categorie.bak", True)
                        End If
                    End If

                    If My.Settings.RestaurationChaines = 1 Then
                        If File.Exists(My.Settings.DirectoryBackup & "\Temp\" & "ZGuideTVDotNet.channels.set") Then
                            File.Copy(My.Settings.DirectoryBackup & "\Temp\" & "ZGuideTVDotNet.channels.set",
                                      ChannelSetPath & "ZGuideTVDotNet.channels.bak", True)
                        End If
                    End If

                    If My.Settings.RestaurationUrl = 1 Then
                        If File.Exists(My.Settings.DirectoryBackup & "\Temp\" & "ZGuideTVDotNet.url.set") Then
                            File.Copy(My.Settings.DirectoryBackup & "\Temp\" & "ZGuideTVDotNet.url.set",
                                      UrlPath & "ZGuideTVDotNet.url.bak",
                                      True)
                        End If
                    End If

                    If My.Settings.RestaurationUserConfig = 1 Then
                        If File.Exists(My.Settings.DirectoryBackup & "\Temp\" & "user.config") Then
                            File.Copy(My.Settings.DirectoryBackup & "\Temp\" & "user.config",
                                      _userConfigDirectory.FilePath & ".bak", True)
                        End If
                    End If

                    If My.Settings.RestaurationLogos = 1 Then
                        For Each myLogo As String In
                            From
                                myLogo1 In
                                    Directory.GetFiles(My.Settings.DirectoryBackup & "\Temp\", "*.gif",
                                                       SearchOption.AllDirectories)
                            Where File.Exists(myLogo1)
                            File.Copy(myLogo, Path.Combine(DestinationLogos, Path.GetFileName(myLogo & ".gik")),
                                      True)
                        Next

                        For Each myLogo As String In
                            From
                                myLogo1 In
                                    Directory.GetFiles(My.Settings.DirectoryBackup & "\Temp\", "*.jpg",
                                                       SearchOption.AllDirectories)
                            Where File.Exists(myLogo1)
                            File.Copy(myLogo, Path.Combine(DestinationLogos, Path.GetFileName(myLogo & ".jpk")),
                                      True)
                        Next
                    End If

                    ' On arrête le thread du ThreadProgressBarRestore
                    Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du ThreadProgressBarRestore")
                    SyncLock threadProgressBarRestore
                        threadProgressBarRestore.Abort()
                    End SyncLock

                    Application.DoEvents()
                    Close()

                    Trace.WriteLine(DateTime.Now & " " & "On sort de Gestionbdd Restore")

                    If Directory.Exists(My.Settings.DirectoryBackup & "\Temp\") Then
                        Directory.Delete(My.Settings.DirectoryBackup & "\Temp\", True)
                    End If

                    Try
                        If My.Settings.AudioOn Then
                            Mainform.JouerSon(My.Settings.MessagesSound, CInt(My.Settings.MessagesVolume / 10))
                        End If
                    Catch ex As Exception
                        Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                    End Try

                    ' C'est ici que l'on doit mettre le Flag à 1 pour récupérer la sauvegarde au démarrage de zg
                    ' comme après un plantage de zg!!!!
                    ' Donc on fait semblant que la bbd est corrompue !!!!!
                    My.Settings.FichierCorrompu = 1
                    Dim boxFileRestore As DialogResult
                    boxFileRestore =
                        MessageBox.Show(
                            MessageBoxFileRestore & Chr(13) & MessageBoxFileRestore1 & Chr(13) & Chr(13) &
                            MessageBoxFileRestore2, MessageBoxFileRestoreTitre, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                    If boxFileRestore = DialogResult.Yes Then
                        My.Settings.Save()
                        Close()
                        Mainform.Close()
                        Application.DoEvents()
                        Application.Restart()
                    Else
                        My.Settings.Save()
                        ButtonSave.Enabled = True
                        ButtonDelete.Enabled = True
                        ButtonCancel.Enabled = True
                        ButtonRestore.Enabled = True
                        ButtonRename.Enabled = True
                    End If
                End If
            Else

                ' ReSharper disable NotAccessedVariable
                Dim boxNoRestoreSelected As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoRestoreSelected =
                    MessageBox.Show(
                        MessageBoxNoRestoreSelected, MessageBoxNoRestoreSelectedTitre, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

        Else
            ' ReSharper disable NotAccessedVariable
            Dim boxNoRestoreElement As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxNoRestoreElement =
                MessageBox.Show(
                    MessageBoxNoRestoreElement, MessageBoxNoRestoreElementTitre, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If

        ListViewGestionBdd.SelectedItems.Clear()
        Trace.WriteLine(DateTime.Now & " " & "On quitte Gestionbdd ButtonRestore")
    End Sub

    Private Sub CheckBoxRestaurationDataBaseCheckedChanged(sender As Object, e As EventArgs) _
        Handles CheckBoxRestaurationDataBase.CheckedChanged

        If CheckBoxRestaurationDataBase.Checked = True Then
            My.Settings.RestaurationDataBase = 1
        Else
            My.Settings.RestaurationDataBase = 0
        End If
    End Sub

    Private Sub CheckBoxRestaurationChainesCheckedChanged(sender As Object, e As EventArgs) _
        Handles CheckBoxRestaurationChaines.CheckedChanged

        If CheckBoxRestaurationChaines.Checked = True Then
            My.Settings.RestaurationChaines = 1
        Else
            My.Settings.RestaurationChaines = 0
        End If
    End Sub

    Private Sub CheckBoxRestaurationUrlCheckedChanged(sender As Object, e As EventArgs) _
        Handles CheckBoxRestaurationUrl.CheckedChanged

        If CheckBoxRestaurationUrl.Checked = True Then
            My.Settings.RestaurationUrl = 1
        Else
            My.Settings.RestaurationUrl = 0
        End If
    End Sub

    Private Sub CheckBoxRestaurationUserConfigCheckedChanged(sender As Object, e As EventArgs) _
        Handles CheckBoxRestaurationUserConfig.CheckedChanged

        If CheckBoxRestaurationUserConfig.Checked = True Then
            My.Settings.RestaurationUserConfig = 1
        Else
            My.Settings.RestaurationUserConfig = 0
        End If
    End Sub

    Private Sub CheckBoxRestaurationLogosCheckedChanged(sender As Object, e As EventArgs) _
        Handles CheckBoxRestaurationLogos.CheckedChanged

        If CheckBoxRestaurationLogos.Checked = True Then
            My.Settings.RestaurationLogos = 1
        Else
            My.Settings.RestaurationLogos = 0
        End If
    End Sub

    Private Sub ButtonRenameClick(sender As Object, e As EventArgs) Handles ButtonRename.Click

        Trace.WriteLine(DateTime.Now & " " & "On entre dans GestionBdd ButtonRename")
        Try
            If Not (Not _selectedItems Is Nothing AndAlso String.IsNullOrEmpty(_selectedItems)) Then
                If File.Exists(My.Settings.DirectoryBackup & "\" & _selectedItems & ".zip") Then

                    Dim strInput As String = InputBox(InputBoxRenameBdd,
                                                      InputBoxRenameBddTitre,
                                                      _selectedItems)

                    If strInput = String.Empty OrElse strInput = _selectedItems Then
                        ListViewGestionBdd.SelectedItems.Clear()
                        Exit Sub
                    End If

                    ' On renomme le fichier de sauvegarde
                    File.Move(My.Settings.DirectoryBackup & "\" & _selectedItems & ".zip",
                              My.Settings.DirectoryBackup & "\" & strInput & ".zip")

                    RemplirListview()

                    ' ReSharper disable NotAccessedVariable
                    Dim boxRenameDone As DialogResult
                    ' ReSharper restore NotAccessedVariable
                    boxRenameDone =
                        MessageBox.Show(
                            MessageboxRenameDone, MessageboxRenameDoneTitre, MessageBoxButtons.OK,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If
            Else
                ' ReSharper disable NotAccessedVariable
                Dim boxNoRestoreSelected As DialogResult
                ' ReSharper restore NotAccessedVariable
                boxNoRestoreSelected =
                    MessageBox.Show(
                        MessageBoxNoRestoreSelected, MessageBoxNoRestoreSelectedTitre, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As IOException
            Trace.WriteLine(DateTime.Now & " " & "Erreur GestionBdd ButtonRename" & ex.ToString())
        End Try

        ListViewGestionBdd.SelectedItems.Clear()
        Trace.WriteLine(DateTime.Now & " " & "On quitte GestionBdd ButtonRename")
    End Sub

    Private Sub DirectoryBackup_Click(sender As Object, e As EventArgs) Handles DirectoryBackup.Click

        If (FolderBrowserDialogDirectory.ShowDialog() = DialogResult.OK) Then
            TextBoxDirectory.Text = FolderBrowserDialogDirectory.SelectedPath
            My.Settings.DirectoryBackup = TextBoxDirectory.Text
            My.Settings.Save()

            RemplirListview()
        End If
    End Sub

    Private Sub TextBoxDirectory_Enter(sender As Object, e As EventArgs) Handles TextBoxDirectory.MouseHover

        If TextBoxDirectory.TextLength > 30 Then

            Dim VisibleTime As Integer = 1000 'in milliseconds
            Dim tt As New ToolTip()

            tt.Show(TextBoxDirectory.Text, TextBoxDirectory, 0, 0, VisibleTime)
        End If
    End Sub
End Class
