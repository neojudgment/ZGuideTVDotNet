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

#Region "Property"

Imports System.Net.Mail
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Xml
Imports System.Globalization
Imports System.Management
Imports System.Configuration
Imports System.Reflection
Imports System.Net
Imports System.Text.RegularExpressions

#End Region

' ReSharper disable CheckNamespace
Public Class Feedback
    ' ReSharper restore CheckNamespace

#Region "Property"

    Private _client As SmtpClient

    Private _userconfig As Attachment
    Private _zGuideTvDotNetexelog As Attachment
    Private _zGuideTvDotNetchannelsset As Attachment
    Private _zGuideTvDotNetmarkedset As Attachment
    Private _zGuideTvDotNetinstalllog As Attachment

    Public MessageBoxFeedback As String
    Public MessageBoxFeedbackTitre As String
    Public MessageBoxMessageEnvoye As String
    Public MessageBoxMessageEnvoyeTitre As String
    Public MessageBoxMessageIsEmpty As String
    Public MessageBoxMessageIsEmptyTitre As String

    Private _smtp As String = String.Empty
    Private _port As String = String.Empty
    Private _emailFromAdress As String = String.Empty
    Private _emailFromName As String = String.Empty
    Private _emailToAdress As String = String.Empty
    Private _emailToName As String = String.Empty
    Private _credentialAdress As String = String.Empty
    Private _credentialPassword As String = String.Empty

    Public ZGuideTvRelease As String
    Public CompilationDate As String
    Public OsRelease As String
    Public Architecture As String
    Public OsBootMode As String
    Public Framework As String
    Public OsLanguage As String
    Public TotalMemory As String
    Public RemainingMemory As String
    Public UsedMemory As String
    Public ProcessorName As String
    Public ProcessorNumber As String
    Public MonitorNumber As String
    Public Email As String
    Public Comments As String
    Public DescriptionError As String
    Public ProcessorSpeed As String
    Public ProcessorDescription As String
    Private _mybootmode As String

#End Region

    Private Const PassPhrase As String = "This Is Not Salt"
    Private Const SaltValue As String = "x@605bn7dna332v653nx2iqcl7"
    Private Const PasswordIterations As Integer = 2
    Private Const InitVector As String = "@1B2c3D4e5F6g7H8"
    Private Const KeySize As Integer = 256

    Private Shared Function Decrypt(ByVal cipherText As String) As String

        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(InitVector)

        Dim saltValueBytes As Byte()
        saltValueBytes = Encoding.ASCII.GetBytes(SaltValue)

        Dim cipherTextBytes As Byte()
        cipherTextBytes = Convert.FromBase64String(cipherText)

        Dim password As Rfc2898DeriveBytes
        password = New Rfc2898DeriveBytes(PassPhrase,
                                          saltValueBytes,
                                          PasswordIterations)

        Dim keyBytes As Byte()
        keyBytes = password.GetBytes(CInt(KeySize / 8))

        Dim symmetricKey As RijndaelManaged
        symmetricKey = New RijndaelManaged()

        symmetricKey.Mode = CipherMode.CBC

        Dim decryptor As ICryptoTransform
        decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        Dim memoryStream As MemoryStream
        memoryStream = New MemoryStream(cipherTextBytes)

        Dim cryptoStream As CryptoStream
        cryptoStream = New CryptoStream(memoryStream,
                                        decryptor,
                                        CryptoStreamMode.Read)

        Dim plainTextBytes As Byte()
        ReDim plainTextBytes(cipherTextBytes.Length)

        Dim decryptedByteCount As Integer
        decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                               0,
                                               plainTextBytes.Length)

        memoryStream.Close()
        memoryStream.Dispose()
        cryptoStream.Close()
        cryptoStream.Dispose()
        Dim plainText As String
        plainText = Encoding.UTF8.GetString(plainTextBytes,
                                            0,
                                            decryptedByteCount)

        Decrypt = plainText
    End Function

    Private Sub FeedbackFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If CheckBoxExceptErrorMessage.Checked Then
            If Not _userconfig Is Nothing Then
                _userconfig.Dispose()
            End If

            If Not _zGuideTvDotNetinstalllog Is Nothing Then
                _zGuideTvDotNetinstalllog.Dispose()
            End If

            If _zGuideTvDotNetexelog IsNot Nothing Then
                _zGuideTvDotNetexelog.Dispose()
            End If

            If _zGuideTvDotNetmarkedset IsNot Nothing Then
                _zGuideTvDotNetmarkedset.Dispose()
            End If

            If _zGuideTvDotNetchannelsset IsNot Nothing Then
                _zGuideTvDotNetchannelsset.Dispose()
            End If
        End If

        Mainform.Timer_minute.Start()

        My.Settings.ManualFeedBack = False
        My.Settings.Save()
    End Sub

    Private Sub FeedbackLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Trace.WriteLine(DateTime.Now.ToString & " " &
                        "On entre dans Feedback_Load")

        AcceptButton = Nothing

        Mainform.Timer_minute.Stop()

        ' On sélectionne la langue
        Trace.WriteLine(DateTime.Now.ToString & " " &
                        "On est dans Feedback_Load et on va faire LanguageCheck")
        LanguageCheck()
        LabelFeedbackSend.Text = String.Empty

        ' Mode de démarrage
        _mybootmode = GetWindowsBootMode.ToString

        TextBoxEmail.Text = My.Settings.UserMail

        Dim reader As XmlTextReader = Nothing

        Try
            Const xmlUrl As String = "http://www.zguidetv.net/zguidetv/feedbacknew.xml"
            reader = New XmlTextReader(xmlUrl)
            reader.MoveToContent()

            Dim elementName As String = Nothing
            ' On controle si le fichier xml contient le noeud "feedback"
            If (reader.NodeType = XmlNodeType.Element) AndAlso ([String].Equals(reader.Name, "feedback", StringComparison.CurrentCulture)) Then
                Do While reader.Read()
                    ' Quand on trouve un noeud on se souvient de son nom  
                    If reader.NodeType = XmlNodeType.Element Then
                        elementName = reader.Name
                    Else
                        ' noeud suivant 
                        If (reader.NodeType = XmlNodeType.Text) AndAlso (reader.HasValue) Then
                            ' On controle le nom des noeuds  
                            Select Case elementName
                                Case "Smtp"
                                    _smtp = Decrypt(reader.Value)
                                Case "Port"
                                    _port = Decrypt(reader.Value)
                                Case "EmailFromAdress"
                                    _emailFromAdress = Decrypt(reader.Value)
                                Case "EmailFromName"
                                    _emailFromName = Decrypt(reader.Value)
                                Case "EmailToAdress"
                                    _emailToAdress = Decrypt(reader.Value)
                                Case "EmailToName"
                                    _emailToName = Decrypt(reader.Value)
                                Case "CredentialAdress"
                                    _credentialAdress = Decrypt(reader.Value)
                                Case "CredentialPassword"
                                    _credentialPassword = Decrypt(reader.Value)
                            End Select
                        End If
                    End If
                Loop
            End If
        Catch ex As Exception
            Trace.WriteLine(DateTime.Now.ToString & " erreur de parsing du fichier feedback.xml")
        Finally
        End Try

        reader.Close()

        ExceptErrorMessage.Text = ExceptError

        If My.Settings.ManualFeedBack Then

            ' C'est un Feedback manuel on réorganise les fenêtres
            LabelExceptMessage1.Text = String.Empty
            LabelExceptMessage2.Text = LngExceptErrorMessage
            LabelExceptMessage3.Text = String.Empty
            DescriptionError = String.Empty

            CheckBoxExceptErrorMessage.Checked = False
            ExceptErrorMessage.Visible = False
            RichTextBoxExceptErrorMessage.Location = New Point(11, 56)
            RichTextBoxExceptErrorMessage.Height = 325
        End If

        ' On enlève les lignes vides dans la RitchTextBox ExceptErrorMessage
        Dim txtlst() As String = ExceptErrorMessage.Text.Split(New Char() {ControlChars.Cr, ControlChars.Lf})
        ExceptErrorMessage.Text = ""

        For Each itrStr As String In From itrStr1 In txtlst Where Not (Not itrStr1.Trim() Is Nothing AndAlso String.IsNullOrEmpty(itrStr1.Trim()))
            ExceptErrorMessage.Text += itrStr & vbCrLf
        Next

        Trace.WriteLine(DateTime.Now.ToString & " " & "On est à la fin du Feedback_Load")
    End Sub

    Private Sub BackgroundWorkerFeedbackDoWork(ByVal sender As Object,
                                               ByVal e As DoWorkEventArgs) Handles BackgroundWorkerFeedback.DoWork

        CheckForIllegalCrossThreadCalls = False

        ' On récupère la langue utilisée par le système
        Dim languageId As String
        languageId = CultureInfo.CurrentCulture.NativeName

        ' On regarde si le champs E-mail est rempli et si il est valide
        If Not [String].Equals(TextBoxEmail.Text, "", StringComparison.CurrentCulture) AndAlso Not EmailValide(TextBoxEmail.Text) Then

            ' ReSharper disable NotAccessedVariable
            Dim boxMiseaJour As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxMiseaJour = MessageBox.Show _
                (MessageBoxFeedback,
                 MessageBoxFeedbackTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning,
                 MessageBoxDefaultButton.Button1)

            Show()
        Else

            My.Settings.UserMail = TextBoxEmail.Text

            ' Description du processeur
            Dim infoProcesseur As ManagementObject = New ManagementObjectSearcher("select * from Win32_Processor").Get().Cast(Of ManagementObject)().First()

            ' On recherche le fichier user.config
            Dim _
                configZGuideTv As Configuration =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)
            Dim localPathZGuideTv As String = configZGuideTv.FilePath
            Dim temp As String = My.Computer.FileSystem.SpecialDirectories.Temp

            If CheckBoxExceptErrorMessage.Checked Then

                'Copie du fichier user.config dans tmp
                Dim config As New FileInfo(localPathZGuideTv)
                config.CopyTo(temp & "\user.config", True)
            End If

            ' On recherche la mémoire totale et disponible
            Dim memoireTotale As Double = Math.Round(My.Computer.Info.TotalPhysicalMemory / 1024 ^ 2, 0)
            Dim memoireDisponible As Double = Math.Round(My.Computer.Info.AvailablePhysicalMemory / 1024 ^ 2, 0)

            ' Mémoire utilisée par ZGuideTV.NET
            Dim memoireUtilisee As Double = Math.Round(Environment.WorkingSet / 1024 ^ 2, 0) / 2

            ' Nombre de processeurs installés
            Dim countProc As Integer = Environment.ProcessorCount

            ' La version de ZGuideTV.NET
            Dim maVersion As Version = Assembly.GetExecutingAssembly.GetName.Version

            ' Nombre d'écrans connectés
            Dim monitorCount As Integer = SystemInformation.MonitorCount

            ' Architecture 32 ou 64 bits
            Is64BitOperatingSystem()
            Dim bitOs As String
            If Is64BitOperatingSystem() Then
                bitOs = "64-bit"
            Else
                bitOs = "32-bit"
            End If

            ' On Configure l'envoi du mail
            _client = New SmtpClient(_smtp, CInt(_port))

            _client.EnableSsl = True

            Dim from As New MailAddress(_emailFromAdress, _emailFromName)

            Dim [to] As New MailAddress(_emailToAdress, _emailToName)

            Dim message As New MailMessage(from, [to])

            With message
                ' Accusé de réception si la case est cochée
                If Not [String].Equals(TextBoxEmail.Text, "", StringComparison.CurrentCulture) AndAlso CheckBoxAcknowledgment.Checked Then
                    .Bcc.Add(TextBoxEmail.Text)
                End If

                .Priority = MailPriority.High
                .IsBodyHtml = False
            End With

            ' le corp du message à envoyer
            message.Body = ZGuideTvRelease & " " & maVersion.ToString & vbCrLf &
                           CompilationDate & " " &
                           File.GetLastWriteTime(AppPath & "ZGuideTVDotNet.exe") &
                           vbCrLf & OsRelease & " " & My.Computer.Info.OSFullName &
                           " " & My.Computer.Info.OSVersion & vbCrLf &
                           Architecture & " " & bitOs & vbCrLf &
                           OsBootMode & " " & _mybootmode & vbCrLf &
                           Framework & " " & Environment.Version.ToString() & vbCrLf &
                           OsLanguage & " " & languageId & vbCrLf &
                           TotalMemory & " " & memoireTotale & " Mo" & vbCrLf &
                           RemainingMemory & " " & memoireDisponible & " Mo" & vbCrLf &
                           UsedMemory & " " & memoireUtilisee & " Mo" & vbCrLf &
                           ProcessorDescription & " " & infoProcesseur("Description").ToString() & vbCrLf &
                           ProcessorName & " " & infoProcesseur("Name").ToString() & vbCrLf &
                           ProcessorSpeed & " " & infoProcesseur("CurrentClockSpeed").ToString() & " Mhz" & vbCrLf &
                           ProcessorNumber & " " & countProc & vbCrLf &
                           MonitorNumber & " " & monitorCount & vbCrLf &
                           Email & " " & TextBoxEmail.Text & vbCrLf & vbCrLf &
                           Comments & " " & RichTextBoxExceptErrorMessage.Text & vbCrLf & vbCrLf &
                           DescriptionError & " " & ExceptError

            message.Subject = "ZGuideTV.NET Feedback"

            If CheckBoxExceptErrorMessage.Checked Then

                Try

                    ' On attache les fichiers à envoyer
                    My.Settings.Save()

                    File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ZGuideTVDotNet\Log\" & "ZGuideTVDotNet.exe.log",
                          temp & "\ZGuideTVDotNet.exe.log", True)

                    File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ZGuideTVDotNet\Marked\" & "ZGuideTVDotNet.marked.set",
                temp & "\ZGuideTVDotNet.marked.set", True)

                    _userconfig = New Attachment(temp & "\user.config")
                    _zGuideTvDotNetexelog = New Attachment(temp & "\ZGuideTVDotNet.exe.log")
                    _zGuideTvDotNetinstalllog = New Attachment(AppPath & "\ZGuideTVDotNet.Install.log")
                    _zGuideTvDotNetmarkedset = New Attachment(temp & "\ZGuideTVDotNet.marked.set")
                    _zGuideTvDotNetchannelsset = New Attachment(ChannelSetPath & "\ZGuideTVDotNet.channels.set")

                    With message.Attachments
                        .Add(_userconfig)
                        .Add(_zGuideTvDotNetinstalllog)
                        .Add(_zGuideTvDotNetmarkedset)
                        .Add(_zGuideTvDotNetexelog)
                        .Add(_zGuideTvDotNetchannelsset)
                    End With

                Catch ex As IOException
                    MsgBox(ex.ToString)
                End Try


            End If

            Dim myCreds As New NetworkCredential(_credentialAdress, _credentialPassword, "")

            _client.Credentials = myCreds

            Dim userState As Object = message

            ' Ajouté par Néo le 13/07/2012
            AddHandler _client.SendCompleted, AddressOf SmtpClientOnCompleted '20082012

            Try
                ' On envoie le message en asynchrone
                _client.SendAsync(message, userState)
            Catch ex As Exception
                Trace.WriteLine("L'exception dans Feedback Form est :" & ex.ToString())
            End Try
        End If
    End Sub

    Private Sub SmtpClientOnCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)

        Dim mail As MailMessage = CType(e.UserState, MailMessage)
        Dim subject As String = mail.Subject

        If e.Cancelled Then
            Trace.WriteLine(DateTime.Now.ToString & " " & "Envoi annulé pour le courrier avec le sujet [{0}] " & subject)
        End If
        If Not (e.Error Is Nothing) Then
            Trace.WriteLine(DateTime.Now.ToString & " " & "Une erreur {1} a eu lieu durant l'envoi du mail [{0}] " & subject & ": " & e.Error.ToString())
        Else
            Trace.WriteLine(DateTime.Now.ToString & " " & "Message [{0}] envoyé " & subject)
        End If

        Hide()

        ' ReSharper disable NotAccessedVariable
        Dim boxMessageEnvoye As DialogResult
        ' ReSharper restore NotAccessedVariable
        boxMessageEnvoye = MessageBox.Show _
            (MessageBoxMessageEnvoye,
             MessageBoxMessageEnvoyeTitre, MessageBoxButtons.OK, MessageBoxIcon.Information,
             MessageBoxDefaultButton.Button1)


        Trace.WriteLine(DateTime.Now.ToString & " " & "On va quitter BackgroundFeedback_RunWorkerCompleted")

        Close()
        Dispose()
    End Sub

    Private Sub SendButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles Send_Button.Click

        Trace.WriteLine(DateTime.Now.ToString & " " & "On est dans Feedback et on vient de cliquer sur Send_Button")

        ' C'est un Feedback manuel et la RitchtextBox est vide
        If My.Settings.ManualFeedBack AndAlso RichTextBoxExceptErrorMessage.Text = String.Empty Then

            ' ReSharper disable NotAccessedVariable
            Dim boxMessageMessageIsEmpty As DialogResult
            ' ReSharper restore NotAccessedVariable
            boxMessageMessageIsEmpty = MessageBox.Show _
                (MessageBoxMessageIsEmpty,
                 MessageBoxMessageIsEmptyTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning,
                 MessageBoxDefaultButton.Button1)

            Exit Sub
        End If

        Send_Button.Enabled = False

        PictureBoxFeedback.Image = My.Resources.loader
        LabelFeedbackSend.Text = LngLabelFeedbackSend
        BackgroundWorkerFeedback.RunWorkerAsync()
    End Sub

    Private Sub ExitButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles Exit_Button.Click
        DialogResult = DialogResult.Cancel

        Trace.WriteLine(DateTime.Now.ToString & " " & "On entre dans Feedback - ExitButtonClick")
        Close()
        Dispose()
    End Sub

    Private Sub CopyClick(ByVal sender As Object, ByVal e As EventArgs) Handles Copier_Button.Click

        Trace.WriteLine(DateTime.Now.ToString & " " & "On entre dans Feedback - Copy_Click")

        ' On copie le message d'erreur dans le presse papier
        Clipboard.SetDataObject(ExceptErrorMessage.Text, True)
    End Sub

    Private Function EmailValide(ByVal mailAddress As String) As Boolean

        ' Test sur la validité de l'adresse E-mail
        Dim _
            rexp As _
                New Regex(
                    "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                    RegexOptions.IgnoreCase)
        Return rexp.IsMatch(mailAddress)
    End Function

    Private Function GetWindowsBootMode() As String

        Dim bm As String

        Select Case SystemInformation.BootMode
            Case BootMode.FailSafe
                bm = "FailSafeBoot"
            Case BootMode.FailSafeWithNetwork
                bm = "FailSafeBootNet"
            Case BootMode.Normal
                bm = "NormalBoot"
            Case Else
                bm = "UnknownBoot"
        End Select

        GetWindowsBootMode = bm
    End Function

    Private Shared Function Is64BitOperatingSystem() As Boolean

        ' Les programmes 64-bit ne démarrent seulement que sous Win64
        If IntPtr.Size = 8 Then
            Return True
        Else
            ' les programmes 32-bits démarre sous Windows 32 et 64 bits
            ' On regarde si le processus courant est en 32 bits
            ' tournant sous un Windows 64 bits
            Dim flag As Boolean
            Return ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") AndAlso IsWow64Process(GetCurrentProcess(), flag)) AndAlso flag)
        End If
    End Function

    Private Shared Function DoesWin32MethodExist(ByVal moduleName As String, ByVal methodName As String) As Boolean

        Dim moduleHandle As IntPtr = GetModuleHandle(moduleName)
        If moduleHandle = IntPtr.Zero Then
            Return False
        End If
        Return (GetProcAddress(moduleHandle, methodName) <> IntPtr.Zero)
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function GetCurrentProcess() As IntPtr
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetModuleHandle(ByVal moduleName As String) As IntPtr
    End Function

    <DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetProcAddress(ByVal hModule As IntPtr, <MarshalAs(UnmanagedType.LPStr)> ByVal procName As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function IsWow64Process(ByVal hProcess As IntPtr, <Out()> ByRef wow64Process As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private Sub RichTextBoxExceptErrorMessageEnter(ByVal sender As Object, ByVal e As EventArgs) Handles RichTextBoxExceptErrorMessage.Enter

        AcceptButton = Nothing
    End Sub

    Private Sub RichTextBoxExceptErrorMessageLeave(ByVal sender As Object, ByVal e As EventArgs) Handles RichTextBoxExceptErrorMessage.Leave

        AcceptButton = Send_Button
    End Sub
End Class
