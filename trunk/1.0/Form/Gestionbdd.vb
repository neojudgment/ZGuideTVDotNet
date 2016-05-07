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
Imports System.Configuration
Imports System.IO
Imports System.Threading
Imports System.Globalization
Imports Microsoft.DirectX
Imports Microsoft.DirectX.AudioVideoPlayback

Public Class Gestionbdd

#Region "Propery"

    Private _gestionSave As Boolean

    Public Property GestionSave As Boolean
        Get
            Return _gestionSave
        End Get
        Set(ByVal value As Boolean)
            _gestionSave = Value
        End Set
    End Property

    'Griser et désactiver la croix rouge de la form
    Private Const CsNoclose As Integer = &H200

    Private _userConfigDirectory As Configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)

    Public Property UserConfigDirectory As Configuration
        Get
            Return _UserConfigDirectory
        End Get
        Set(ByVal value As Configuration)
            _userConfigDirectory = Value
        End Set
    End Property

    Private _
        _tempDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                   "\ZGuideTVDotNet\Temp\"

    Public Property TempDirectory As String
        Get
            Return _TempDirectory
        End Get
        Set(ByVal value As String)
            _tempDirectory = Value
        End Set
    End Property

    Private _
        _sourceDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                     "\ZGuideTVDotNet"

    Public Property SourceDirectory As String
        Get
            Return _sourceDirectory
        End Get
        Set(ByVal value As String)
            _sourceDirectory = Value
        End Set
    End Property

    Private _
        _destinationDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                          "\ZGuideTVDotNet"

    Public Property DestinationDirectory As String
        Get
            Return _destinationDirectory
        End Get
        Set(ByVal value As String)
            _destinationDirectory = Value
        End Set
    End Property

    Private _destinationDataBase As String = DestinationDirectory & "\db_progs.db3"

    Public Property DestinationDataBase As String
        Get
            Return _destinationDataBase
        End Get
        Set(ByVal value As String)
            _destinationDataBase = Value
        End Set
    End Property

    Private _destinationChannelFile As String = DestinationDirectory & "\ZGuideTVDotNet.channels.set"

    Public Property DestinationChannelFile As String
        Get
            Return _destinationChannelFile
        End Get
        Set(ByVal value As String)
            _destinationChannelFile = Value
        End Set
    End Property

    Private _destinationUrlFile As String = DestinationDirectory & "\ZGuideTVDotNet.url.set"

    Public Property DestinationUrlFile As String
        Get
            Return _destinationUrlFile
        End Get
        Set(ByVal value As String)
            _destinationUrlFile = Value
        End Set
    End Property

    Private _destinationEpgData As String = DestinationDirectory & "\EPGData.db3"

    Public Property DestinationEpgData As String
        Get
            Return _destinationEpgData
        End Get
        Set(ByVal value As String)
            _destinationEpgData = Value
        End Set
    End Property

    Private _destinationUserConfig As String = DestinationDirectory & "\user.config"

    Public Property DestinationUserConfig As String
        Get
            Return _destinationUserConfig
        End Get
        Set(ByVal value As String)
            _destinationUserConfig = Value
        End Set
    End Property

    Private _selectedItems As String

    Public Property SelectedItems As String
        Get
            Return _selectedItems
        End Get
        Set(ByVal value As String)
            _selectedItems = Value
        End Set
    End Property

    Private _messageBoxFileRestore As String

    Public Property MessageBoxFileRestore As String
        Get
            Return _messageBoxFileRestore
        End Get
        Set(ByVal value As String)
            _messageBoxFileRestore = Value
        End Set
    End Property

    Private _messageBoxFileRestore1 As String

    Public Property MessageBoxFileRestore1 As String
        Get
            Return _messageBoxFileRestore1
        End Get
        Set(ByVal value As String)
            _messageBoxFileRestore1 = Value
        End Set
    End Property

    Private _messageBoxFileRestore2 As String

    Public Property MessageBoxFileRestore2 As String
        Get
            Return _messageBoxFileRestore2
        End Get
        Set(ByVal value As String)
            _messageBoxFileRestore2 = Value
        End Set
    End Property

    Private _messageBoxFileRestoreTitre As String

    Public Property MessageBoxFileRestoreTitre As String
        Get
            Return _messageBoxFileRestoreTitre
        End Get
        Set(ByVal value As String)
            _messageBoxFileRestoreTitre = Value
        End Set
    End Property

    Private _messageBoxNoRestoreSelected As String

    Public Property MessageBoxNoRestoreSelected As String
        Get
            Return _messageBoxNoRestoreSelected
        End Get
        Set(ByVal value As String)
            _messageBoxNoRestoreSelected = Value
        End Set
    End Property

    Private _messageBoxNoRestoreSelectedTitre As String

    Public Property MessageBoxNoRestoreSelectedTitre As String
        Get
            Return _messageBoxNoRestoreSelectedTitre
        End Get
        Set(ByVal value As String)
            _messageBoxNoRestoreSelectedTitre = Value
        End Set
    End Property

    Private _messageBoxNoRestoreElement As String

    Public Property MessageBoxNoRestoreElement As String
        Get
            Return _messageBoxNoRestoreElement
        End Get
        Set(ByVal value As String)
            _messageBoxNoRestoreElement = Value
        End Set
    End Property

    Private _messageBoxNoRestoreElementTitre As String

    Public Property MessageBoxNoRestoreElementTitre As String
        Get
            Return _messageBoxNoRestoreElementTitre
        End Get
        Set(ByVal value As String)
            _messageBoxNoRestoreElementTitre = Value
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CsNoclose
            Return cp
        End Get
    End Property

#End Region

    'Dim _nIndex As Integer

    Private Sub GestionbddLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Néo 21/10/2010
        Trace.WriteLine(DateTime.Now & " " & "On entre dans le Load de Gestionbdd")
        If Not Directory.Exists(SourceDirectory) Then
            Directory.CreateDirectory(SourceDirectory)
            Directory.CreateDirectory(TempDirectory)
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
        End With

        LanguageCheck(17)
        RemplirListview()
    End Sub

    Private Sub RemplirListview()

        Trace.WriteLine(DateTime.Now & " " & "On entre dans le RemplirListview() de Gestionbdd")

        SelectedItems = ""

        ' On crée les colonnes de la ListView
        With ListViewGestionBdd
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add(lngListViewGestionBddColumns0, 130, HorizontalAlignment.Left)
            .Columns.Add(lngListViewGestionBddColumns1, 90, HorizontalAlignment.Center)
            .Columns.Add(lngListViewGestionBddColumns2, 170, HorizontalAlignment.Center)
        End With

        Dim dFolder As DirectoryInfo = New DirectoryInfo(SourceDirectory)
        Dim fFileArray() As FileInfo = dFolder.GetFiles("*.7z")

        Dim fFile As FileInfo
        Dim lCurrent As ListViewItem
        Dim i As Integer = 0
        Dim reste As Integer

        ' On peuple la ListView
        For Each fFile In fFileArray
            i = i + 1
            lCurrent = ListViewGestionBdd.Items.Add(fFile.Name)
            Dim lengthFFile As String = CStr(fFile.Length\1024 + 1)
            lCurrent.SubItems.Add(lengthFFile)
            Dim creationfFile As String = CStr(fFile.CreationTime)
            lCurrent.SubItems.Add(creationfFile)

            Math.DivRem(i, 2, reste)
            If (reste = 0) Then
                lCurrent.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub

    Private Sub ButtonCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCancel.Click

        ' On quitte
        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonCancel dans Gestionbdd")
        Mainform.ResumeLayout()
        Close()
    End Sub

    Private Sub ButtonSaveClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSave.Click


        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonSave dans Gestionbdd")
        My.Settings.GestionSave = True

        ' On lance une sauvegarde
        ButtonSave.Enabled = False
        ButtonDelete.Enabled = False
        ButtonCancel.Enabled = False
        ButtonRestore.Enabled = False

        ' Néo le 21/09/2010
        ' On crée un thread pour l'affichage de la ProgressBarSave
        Dim threadProgressBarSave As New Thread(AddressOf ThreadProgressBar)
        Trace.WriteLine(" ")
        Trace.WriteLine(DateTime.Now & " " & "On lance le ThreadProgressBarSave")
        threadProgressBarSave.IsBackground = True
        threadProgressBarSave.Start()

        Trace.WriteLine(DateTime.Now & " " & "On commense à sauver la config de zg")

        ' On crée les répertoires si il n'existe pas
        If Not Directory.Exists(DestinationDirectory) Then
            Directory.CreateDirectory(DestinationDirectory)
        End If

        Dim i As Integer = 0
        Dim FileMask7z As String = "db_progs({0})"

        Dim name7Z As String = String.Empty

        'On scanne le répertoire et on incrémente
        name7Z = String.Format(CultureInfo.CurrentCulture, FileMask7z, i)

        Do While My.Computer.FileSystem.FileExists(DestinationDirectory & "\" & name7Z & ".7z")
            i += 1
            name7Z = String.Format(CultureInfo.CurrentCulture, FileMask7z, i)
        Loop

        ' emplacement fichier original db_progs.db3
        Dim sDBFile As String = BDDPath & "db_progs.db3"
        ' emplacement fichier original ZGuideTVDotNet.channels.set
        Dim sChannelFile As String = ChannelSetPath & "ZGuideTVDotNet.channels.set"
        ' emplacement fichier original ZGuideTVDotNet.url.set
        Dim sUrlFile As String = UrlPath & "ZGuideTVDotNet.url.set"
        ' emplacement fichier original EPGData.db3
        Dim sEpgData As String = BDDPath & "EPGData.db3"

        Dim targetName7Z As String = DestinationDirectory & "\" & name7Z

        Try
            ' On copie la bdd, le channel.set et le ZGuideTVDotNet.url dans mes "documents\ZGuideTVDotNet"
            If File.Exists(sDBFile) Then
                File.Copy(sDBFile, DestinationDataBase, True)
            End If
            If File.Exists(sChannelFile) Then
                File.Copy(sChannelFile, DestinationChannelFile, True)
            End If
            If File.Exists(sUrlFile) Then
                File.Copy(sUrlFile, DestinationUrlFile, True)
            End If
            If File.Exists(sEpgData) Then
                File.Copy(sEpgData, DestinationEPGData, True)
            End If
            If File.Exists(UserConfigDirectory.FilePath) Then
                File.Copy(UserConfigDirectory.FilePath, DestinationUserConfig, True)
            End If

            Trace.WriteLine(
                DateTime.Now & " " &
                "On vient de copier la bdd, channel.set , EPGData.db3 et le ZGuideTVDotNet.url")

            ' on compresse les fichiers avec 7-zip. Modifié par Néo le 19/09/2010
            Dim p As Process = Nothing
            Try
                p = New Process
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.StartInfo.CreateNoWindow = False
                p.StartInfo.UseShellExecute = True
                p.StartInfo.FileName = UnZipPath
                If File.Exists(DestinationDataBase) Then
                    p.StartInfo.Arguments = "a -t7z """ & targetName7Z & ".7z"" """ & DestinationDataBase & """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(DestinationDataBase)
                End If
                If File.Exists(DestinationChannelFile) Then
                    p.StartInfo.Arguments = "a -t7z """ & targetName7Z & ".7z"" """ & DestinationChannelFile &
                                            """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(DestinationChannelFile)
                End If
                If File.Exists(DestinationUrlFile) Then
                    p.StartInfo.Arguments = "a -t7z """ & targetName7Z & ".7z"" """ & DestinationUrlFile & """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(DestinationUrlFile)
                End If
                If File.Exists(DestinationEPGData) Then
                    p.StartInfo.Arguments = "a -t7z """ & targetName7Z & ".7z"" """ & DestinationEPGData & """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(DestinationEPGData)
                End If
                If File.Exists(DestinationUserConfig) Then
                    p.StartInfo.Arguments = "a -t7z """ & targetName7Z & ".7z"" """ & DestinationUserConfig &
                                            """ ms=off"
                    p.Start()
                    p.WaitForExit()
                    File.Delete(DestinationUserConfig)
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

            Try
                If My.Settings.AudioOn Then
                    ' le volume va de 0 (max) à -10000 (min)
                    Dim audioPlay As Audio
                    audioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                    audioPlay.Volume = My.Settings.MessagesVolume
                    audioPlay.Play()
                End If
            Catch ex As DirectXException
                Trace.WriteLine(DateTime.Now & " " & ex.ToString)
            End Try

            ButtonSave.Enabled = True
            ButtonDelete.Enabled = True
            ButtonCancel.Enabled = True
            ButtonRestore.Enabled = True

            ' On arrête le thread de la ProgressBarSave
            Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du ProgressBarSave")
            SyncLock threadProgressBarSave
                threadProgressBarSave.Abort()
            End SyncLock

            RemplirListview()

            Trace.WriteLine(DateTime.Now & " " & "On sort de Gestionbdd Save")
        Catch
            Trace.WriteLine(DateTime.Now & " " &
                            "Erreur : lors de la sauvegarde de la bdd. On sort de Gestionbdd Save")
            Exit Sub
        End Try
    End Sub

    Private Sub ThreadProgressBar()

        ' Néo le 08/09/2010
        ' Affichage de la progressbar dans un thread
        Trace.WriteLine(DateTime.Now & " " & "On entre dans ThreadProgressBar")
        ProgressBar.ShowDialog()
    End Sub

    Private Sub ListMouseDown(ByVal sender As Object,
                              ByVal e As MouseEventArgs) Handles ListViewGestionBdd.MouseClick

        ' On regarde quelle sauvegarde est sélectionnée
        Try
            For i As Integer = 0 To ListViewGestionBdd.Items.Count - 1
                If ListViewGestionBdd.Items(i).Selected = True Then
                    SelectedItems = ListViewGestionBdd.Items(i).SubItems(0).Text
                    Exit For
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception")
        End Try
    End Sub

    Private Sub ButtonDeleteClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDelete.Click

        ' On efface la sauvegarde sélectionnée
        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonDelete dans Gestionbdd")
        If Not (Not SelectedItems Is Nothing AndAlso String.IsNullOrEmpty(SelectedItems)) Then

            ButtonSave.Enabled = False
            ButtonDelete.Enabled = False
            ButtonCancel.Enabled = False
            ButtonRestore.Enabled = False

            If File.Exists(SourceDirectory & "\" & SelectedItems) Then
                File.Delete(SourceDirectory & "\" & SelectedItems)

                Try
                    If My.Settings.AudioOn Then
                        ' le volume va de 0 (max) à -10000 (min)
                        Dim audioPlay As Audio
                        audioPlay = New Audio(MediaPath & My.Settings.MessagesSound, True)
                        audioPlay.Volume = My.Settings.MessagesVolume
                        audioPlay.Play()
                    End If
                Catch ex As DirectXException
                    Trace.WriteLine(DateTime.Now & " " & ex.ToString)
                End Try

                RemplirListview()

                ButtonSave.Enabled = True
                ButtonDelete.Enabled = True
                ButtonCancel.Enabled = True
                ButtonRestore.Enabled = True

            End If
        End If
    End Sub

    Private Sub ButtonRestoreClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonRestore.Click

        Trace.WriteLine(DateTime.Now & " " & "On vient de cliquer sur ButtonRestore dans Gestionbdd")
        My.Settings.GestionSave = False

        If _
            My.Settings.RestaurationDataBase = 1 OrElse My.Settings.RestaurationChaines = 1 OrElse
            My.Settings.RestaurationUrl = 1 OrElse My.Settings.RestaurationUserConfig = 1 Then

            If Not (Not SelectedItems Is Nothing AndAlso String.IsNullOrEmpty(SelectedItems)) Then
                If File.Exists(SourceDirectory & "\" & SelectedItems) Then

                    ButtonSave.Enabled = False
                    ButtonDelete.Enabled = False
                    ButtonCancel.Enabled = False
                    ButtonRestore.Enabled = False

                    ' Néo le 21/09/2010
                    ' On crée un thread pour l'affichage de la ProgressBarRestore
                    Dim threadProgressBarRestore As New Thread(AddressOf ThreadProgressBar)
                    Trace.WriteLine(" ")
                    Trace.WriteLine(DateTime.Now & " " & "On lance le ThreadProgressBarRestore")
                    threadProgressBarRestore.IsBackground = True
                    threadProgressBarRestore.Start()

                    Trace.WriteLine(DateTime.Now & " " & "On commence à restaurer la config de zg")
                    If Not Directory.Exists(TempDirectory) Then
                        Directory.CreateDirectory(TempDirectory)
                    End If

                    ' on décompresse le backup avec 7-zip dans mes "documents\ZGuideTVDotNet\Temp"
                    Dim p As Process = Nothing
                    Try
                        p = New Process
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        p.StartInfo.CreateNoWindow = False
                        p.StartInfo.UseShellExecute = True
                        p.StartInfo.FileName = UnZipPath
                        p.StartInfo.Arguments = " e " & """" & SourceDirectory & "\" & SelectedItems & """" & " -y -o" &
                                                """" &
                                                TempDirectory & """"
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
                        If File.Exists(TempDirectory & "db_progs.db3") Then
                            File.Copy(TempDirectory & "db_progs.db3", BDDPath & "db_progs.bak", True)
                        End If

                        If File.Exists(TempDirectory & "EPGData.db3") Then
                            File.Copy(TempDirectory & "EPGData.db3", BDDPath & "EPGData.db3", True)
                        End If
                    End If

                    If My.Settings.RestaurationChaines = 1 Then
                        If File.Exists(TempDirectory & "ZGuideTVDotNet.channels.set") Then
                            File.Copy(TempDirectory & "ZGuideTVDotNet.channels.set",
                                      ChannelSetPath & "ZGuideTVDotNet.channels.bak", True)
                        End If
                    End If

                    If My.Settings.RestaurationUrl = 1 Then
                        If File.Exists(TempDirectory & "ZGuideTVDotNet.url.set") Then
                            File.Copy(TempDirectory & "ZGuideTVDotNet.url.set", UrlPath & "ZGuideTVDotNet.url.bak",
                                      True)
                        End If
                    End If

                    If My.Settings.RestaurationUserConfig = 1 Then
                        If File.Exists(TempDirectory & "user.config") Then
                            File.Copy(TempDirectory & "user.config", UserConfigDirectory.FilePath & ".bak", True)
                        End If
                    End If

                    ' On arrête le thread du ThreadProgressBarRestore
                    Trace.WriteLine(DateTime.Now & " " & "On arrête le thread du ThreadProgressBarRestore")
                    SyncLock threadProgressBarRestore
                        threadProgressBarRestore.Abort()
                    End SyncLock

                    Application.DoEvents()
                    Close()

                    Trace.WriteLine(DateTime.Now & " " & "On sort de Gestionbdd Restore")

                    ' C'est ici que l'on doit mettre le Flag à 1 pour récupérer la sauvegarde au démarrage de zg
                    ' comme après un plantage de zg!!!!
                    ' Donc on fait semblant que la bbd est corrompue !!!!!
                    My.Settings.FichierCorrompu = 1
                    Dim BoxFileRestore As DialogResult
                    BoxFileRestore =
                        MessageBox.Show(
                            MessageBoxFileRestore & Chr(13) & MessageBoxFileRestore1 & Chr(13) & Chr(13) &
                            MessageBoxFileRestore2, MessageBoxFileRestoreTitre, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If BoxFileRestore = DialogResult.Yes Then
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

                    End If
                End If
            Else

                Dim BoxNoRestoreSelected As DialogResult
                BoxNoRestoreSelected =
                    MessageBox.Show(
                        MessageBoxNoRestoreSelected, MessageBoxNoRestoreSelectedTitre, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

        Else
            Dim BoxNoRestoreElement As DialogResult
            BoxNoRestoreElement =
                MessageBox.Show(
                    MessageBoxNoRestoreElement, MessageBoxNoRestoreElementTitre, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
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
End Class
