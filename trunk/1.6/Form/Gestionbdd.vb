' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2014 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
Imports System.Configuration
Imports System.IO
Imports System.Threading
Imports System.Globalization
Imports NAudio.Wave

' ReSharper disable CheckNamespace
Public Class Gestionbdd
    ' ReSharper restore CheckNamespace

#Region "Propery"

    Private ReadOnly _userConfigDirectory As Configuration =
                         ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)

    Private ReadOnly _tempDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                                "\ZGuideTVDotNet\Temp\"

    Private ReadOnly _sourceDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                                  "\ZGuideTVDotNet"

    Private ReadOnly _
        _destinationDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                          "\ZGuideTVDotNet"

    Private ReadOnly _destinationDataBase As String = _destinationDirectory & "\db_progs.db3"
    Private ReadOnly _destinationChannelFile As String = _destinationDirectory & "\ZGuideTVDotNet.channels.set"
    Private ReadOnly _destinationUrlFile As String = _destinationDirectory & "\ZGuideTVDotNet.url.set"
    Private ReadOnly _destinationUserConfig As String = _destinationDirectory & "\user.config"
    Private ReadOnly _destinationLogos As String = LogosPath

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
    Public InputBoxRenameBdd As String
    Public InputBoxRenameBddTitre As String
    Public InputBoxNameBdd As String
    Public InputBoxNameBddTitre As String

#End Region

    Private Sub GestionbddFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' On quitte
        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonCancel dans Gestionbdd")

        Mainform.ResumeLayout()
    End Sub

    Private Sub GestionbddLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Néo 21/10/2010
        Trace.WriteLine(DateTime.Now & " " & "On entre dans le Load de Gestionbdd")
        If Not Directory.Exists(_sourceDirectory) Then
            Directory.CreateDirectory(_sourceDirectory)
            Directory.CreateDirectory(_tempDirectory)
        End If

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
    End Sub

    Private Sub RemplirListview()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le RemplirListview() de Gestionbdd")

        _selectedItems = ""

        ' On crée les colonnes de la ListView
        With ListViewGestionBdd
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add(LngListViewGestionBddColumns0, 130, HorizontalAlignment.Left)
            .Columns.Add(LngListViewGestionBddColumns1, 90, HorizontalAlignment.Center)
            .Columns.Add(LngListViewGestionBddColumns2, 170, HorizontalAlignment.Center)
        End With

        Dim dFolder As DirectoryInfo = New DirectoryInfo(_sourceDirectory)
        Dim fFileArray() As FileInfo = dFolder.GetFiles("*.7z")

        Dim fFile As FileInfo
        Dim lCurrent As ListViewItem
        Dim i As Integer = 0
        Dim reste As Integer
        Dim myfileName As String

        ' On peuple la ListView
        For Each fFile In fFileArray
            i = i + 1
            myfileName = fFile.Name
            myfileName = Strings.Left(myfileName, myfileName.Length - 3)
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

    Private Sub ButtonCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCancel.Click

        ' On quitte
        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonCancel dans Gestionbdd")
        Close()
    End Sub

    Private Sub ButtonSaveClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSave.Click


        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonSave dans Gestionbdd")
        My.Settings.GestionSave = True

        ' On crée les répertoires si il n'existe pas
        If Not Directory.Exists(_destinationDirectory) Then
            Directory.CreateDirectory(_destinationDirectory)
        End If

        Dim i As Integer = 0
        Const fileMask7Z As String = "db_progs({0})"

        Dim name7Z As String

        'On scanne le répertoire et on incrémente
        name7Z = String.Format(CultureInfo.CurrentCulture, fileMask7Z, i)

        Do While My.Computer.FileSystem.FileExists(_destinationDirectory & "\" & name7Z & ".7z")
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
        ' emplacement fichier original ZGuideTVDotNet.channels.set
        Dim sChannelFile As String = ChannelSetPath & "ZGuideTVDotNet.channels.set"
        ' emplacement fichier original ZGuideTVDotNet.url.set
        Dim sUrlFile As String = UrlPath & "ZGuideTVDotNet.url.set"

        Dim targetName7Z As String = _destinationDirectory & "\" & name7Z

        Try
            ' On copie la bdd, le channel.set et le ZGuideTVDotNet.url dans mes "documents\ZGuideTVDotNet"
            If File.Exists(sDbFile) Then
                File.Copy(sDbFile, _destinationDataBase, True)
            End If
            If File.Exists(sChannelFile) Then
                File.Copy(sChannelFile, _destinationChannelFile, True)
            End If
            If File.Exists(sUrlFile) Then
                File.Copy(sUrlFile, _destinationUrlFile, True)
            End If
            If File.Exists(_userConfigDirectory.FilePath) Then
                File.Copy(_userConfigDirectory.FilePath, _destinationUserConfig, True)
            End If

            Trace.WriteLine(
                DateTime.Now & " " &
                "On vient de copier la bdd, channel.set et le ZGuideTVDotNet.url")

            ' on compresse les fichiers avec 7-zip. Modifié par Néo le 25/05/2013
            Dim p As Process = Nothing
            Try
                p = New Process
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.StartInfo.CreateNoWindow = False
                p.StartInfo.UseShellExecute = True
                p.StartInfo.FileName = UnZipPath
                ' Compression level: Ultra, compression method: LZMA2
                If File.Exists(_destinationDataBase) Then
                    p.StartInfo.Arguments = "a -mx9 -mmt4 -m0=lzma2:d27:fb128 """ & targetName7Z & ".7z"" """ &
                                            _destinationDataBase & """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(_destinationDataBase)
                End If
                If File.Exists(_destinationChannelFile) Then
                    p.StartInfo.Arguments = "a -mx9 -mmt4 -m0=lzma2:d27:fb128 """ & targetName7Z & ".7z"" """ &
                                            _destinationChannelFile &
                                            """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(_destinationChannelFile)
                End If
                If File.Exists(_destinationUrlFile) Then
                    p.StartInfo.Arguments = "a -mx9 -mmt4 -m0=lzma2:d27:fb128 """ & targetName7Z & ".7z"" """ &
                                            _destinationUrlFile & """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(_destinationUrlFile)
                End If
                If File.Exists(_destinationUserConfig) Then
                    p.StartInfo.Arguments = "a -mx9 -mmt4 -m0=lzma2:d27:fb128 """ & targetName7Z & ".7z"" """ &
                                            _destinationUserConfig &
                                            """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(_destinationUserConfig)
                End If
                If Directory.Exists(_destinationLogos) Then
                    If Not Directory.GetDirectories(_destinationLogos) Is Nothing Then
                        p.StartInfo.Arguments = "a -mx9 -mmt4 -m0=lzma2:d27:fb128 """ & targetName7Z & ".7z"" """ &
                                                _destinationLogos & "*" &
                                                """ ms=off"
                        p.Start()
                        p.WaitForExit()
                    End If
                End If

                p.Dispose()
                p = Nothing

                Application.DoEvents()

                Trace.WriteLine(DateTime.Now & " " & "On viens de compresser les fichiers avec 7-zip")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Exception")
                Trace.WriteLine(DateTime.Now & " " & "Erreur lors de la compression ds fichier avec 7-zip")
            Finally
                If p IsNot Nothing Then
                    If Not p.HasExited Then
                        p.Kill()
                    End If
                    p.Dispose()
                End If
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

    Private Sub ListMouseDown(ByVal sender As Object,
                              ByVal e As MouseEventArgs) Handles ListViewGestionBdd.MouseUp

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

    Private Sub ButtonDeleteClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDelete.Click

        ' On efface la sauvegarde sélectionnée
        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonDelete dans Gestionbdd")
        If Not (Not _selectedItems Is Nothing AndAlso String.IsNullOrEmpty(_selectedItems)) Then

            ButtonSave.Enabled = False
            ButtonDelete.Enabled = False
            ButtonCancel.Enabled = False
            ButtonRestore.Enabled = False
            ButtonRename.Enabled = False

            If File.Exists(_sourceDirectory & "\" & _selectedItems & ".7z") Then
                File.Delete(_sourceDirectory & "\" & _selectedItems & ".7z")

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

    Private Sub ButtonRestoreClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ButtonRestore.Click, ListViewGestionBdd.DoubleClick

        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonRestore dans Gestionbdd")
        My.Settings.GestionSave = False

        If _
            My.Settings.RestaurationDataBase = 1 OrElse My.Settings.RestaurationChaines = 1 OrElse
            My.Settings.RestaurationUrl = 1 OrElse My.Settings.RestaurationUserConfig = 1 OrElse
            My.Settings.RestaurationLogos = 1 Then

            If Not (Not _selectedItems Is Nothing AndAlso String.IsNullOrEmpty(_selectedItems)) Then
                If File.Exists(_sourceDirectory & "\" & _selectedItems & ".7z") Then

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
                    If Not Directory.Exists(_tempDirectory) Then
                        Directory.CreateDirectory(_tempDirectory)
                    End If

                    ' on décompresse le backup avec 7-zip dans mes "documents\ZGuideTVDotNet\Temp"
                    Dim p As Process = Nothing
                    Try
                        p = New Process
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        p.StartInfo.CreateNoWindow = False
                        p.StartInfo.UseShellExecute = True
                        p.StartInfo.FileName = UnZipPath
                        p.StartInfo.Arguments = " e " & """" & _sourceDirectory & "\" & _selectedItems & ".7z""" &
                                                " -y -o" &
                                                """" &
                                                _tempDirectory & """"
                        p.Start()
                        p.WaitForExit()
                        p.Dispose()
                        p = Nothing

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Exception")
                        Trace.WriteLine(DateTime.Now & "Erreur lors de la décompression du backup avec 7-zip")
                    Finally
                        If p IsNot Nothing Then
                            If Not p.HasExited Then
                                p.Kill()
                            End If
                            p.Dispose()
                        End If
                    End Try

                    ' On recopie les fichiers sauvegardés à leurs emplacements d'origine selon la sélection effectuée
                    If My.Settings.RestaurationDataBase = 1 Then
                        If File.Exists(_tempDirectory & "db_progs.db3") Then
                            File.Copy(_tempDirectory & "db_progs.db3", BddPath & "db_progs.bak", True)
                        End If
                    End If

                    If My.Settings.RestaurationChaines = 1 Then
                        If File.Exists(_tempDirectory & "ZGuideTVDotNet.channels.set") Then
                            File.Copy(_tempDirectory & "ZGuideTVDotNet.channels.set",
                                      ChannelSetPath & "ZGuideTVDotNet.channels.bak", True)
                        End If
                    End If

                    If My.Settings.RestaurationUrl = 1 Then
                        If File.Exists(_tempDirectory & "ZGuideTVDotNet.url.set") Then
                            File.Copy(_tempDirectory & "ZGuideTVDotNet.url.set", UrlPath & "ZGuideTVDotNet.url.bak",
                                      True)
                        End If
                    End If

                    If My.Settings.RestaurationUserConfig = 1 Then
                        If File.Exists(_tempDirectory & "user.config") Then
                            File.Copy(_tempDirectory & "user.config", _userConfigDirectory.FilePath & ".bak", True)
                        End If
                    End If

                    If My.Settings.RestaurationLogos = 1 Then
                        For Each myLogo As String In From myLogo1 In Directory.GetFiles(_tempDirectory, "*.gif", SearchOption.AllDirectories) Where File.Exists(myLogo1)
                            File.Copy(myLogo, Path.Combine(_destinationLogos, Path.GetFileName(myLogo & ".gik")),
                                      True)
                        Next

                        For Each myLogo As String In From myLogo1 In Directory.GetFiles(_tempDirectory, "*.jpg", SearchOption.AllDirectories) Where File.Exists(myLogo1)
                            File.Copy(myLogo, Path.Combine(_destinationLogos, Path.GetFileName(myLogo & ".jpk")),
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

                    If Directory.Exists(_tempDirectory) Then
                        Directory.Delete(_tempDirectory, True)
                    End If

                    Try
                        If My.Settings.AudioOn Then
                            Dim wave As New WaveOut
                            Dim xa() As Byte = File.ReadAllBytes(MediaPath & My.Settings.MessagesSound)
                            Dim data As New MemoryStream(xa)
                            wave.Init(
                                New BlockAlignReductionStream(
                                    WaveFormatConversionStream.CreatePcmStream(New WaveFileReader(data))))
                            wave.Volume = CInt(My.Settings.MessagesVolume / 10)
                            wave.Play()
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

    Private Sub CheckBoxRestaurationDataBaseCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles CheckBoxRestaurationDataBase.CheckedChanged

        If CheckBoxRestaurationDataBase.Checked = True Then
            My.Settings.RestaurationDataBase = 1
        Else
            My.Settings.RestaurationDataBase = 0
        End If
    End Sub

    Private Sub CheckBoxRestaurationChainesCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles CheckBoxRestaurationChaines.CheckedChanged

        If CheckBoxRestaurationChaines.Checked = True Then
            My.Settings.RestaurationChaines = 1
        Else
            My.Settings.RestaurationChaines = 0
        End If
    End Sub

    Private Sub CheckBoxRestaurationUrlCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles CheckBoxRestaurationUrl.CheckedChanged

        If CheckBoxRestaurationUrl.Checked = True Then
            My.Settings.RestaurationUrl = 1
        Else
            My.Settings.RestaurationUrl = 0
        End If
    End Sub

    Private Sub CheckBoxRestaurationUserConfigCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles CheckBoxRestaurationUserConfig.CheckedChanged

        If CheckBoxRestaurationUserConfig.Checked = True Then
            My.Settings.RestaurationUserConfig = 1
        Else
            My.Settings.RestaurationUserConfig = 0
        End If
    End Sub

    Private Sub CheckBoxRestaurationLogosCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
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
                If File.Exists(_sourceDirectory & "\" & _selectedItems & ".7z") Then

                    Dim strInput As String = InputBox(InputBoxRenameBdd,
                                                      InputBoxRenameBddTitre,
                                                      _selectedItems)

                    If strInput = String.Empty OrElse strInput = _selectedItems Then
                        ListViewGestionBdd.SelectedItems.Clear()
                        Exit Sub
                    End If

                    ' On renomme le fichier de sauvegarde
                    File.Move(_sourceDirectory & "\" & _selectedItems & ".7z", _sourceDirectory & "\" & strInput & ".7z")

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
End Class
