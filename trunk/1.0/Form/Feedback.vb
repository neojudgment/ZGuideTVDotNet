' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET: An Electronic Program Guide (EPG) - i.e. an "electronic TV magazine"                      |
' |    - which makes the viewing of today's and next week's TV listings possible. It can be customized to      |
' |    pick up the TV listings you only want to have a look at. The application also enables you to carry out  |
' |    a search or even plan to record something later through the K!TV software.                              |
' |                                                                                                            |
' |    Copyright (C) 2004-2013 ZGuideTV.NET Team <http://zguidetv.codeplex.com/>                               |
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
Imports System.ComponentModel
Imports System.Globalization
Imports System.Management
Imports System.Configuration
Imports System.IO
Imports System.Net.Mail
Imports System.Reflection
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Xml
Imports System.Text
Imports System.Threading

' ReSharper disable CheckNamespace
Public Class Feedback
    ' ReSharper restore CheckNamespace

#Region "Property"
    Private _messageBoxFeedback As String

    Public Property MessageBoxFeedback As String
        Private Get
            Return _messageBoxFeedback
        End Get
        Set(ByVal value As String)
            _messageBoxFeedback = value
        End Set
    End Property

    Private _messageBoxFeedbackTitre As String

    Public Property MessageBoxFeedbackTitre As String
        Private Get
            Return _messageBoxFeedbackTitre
        End Get
        Set(ByVal value As String)
            _messageBoxFeedbackTitre = value
        End Set
    End Property

    Private _messageBoxMessageEnvoye As String

    Public Property MessageBoxMessageEnvoye As String
        Private Get
            Return _messageBoxMessageEnvoye
        End Get
        Set(ByVal value As String)
            _messageBoxMessageEnvoye = value
        End Set
    End Property

    Private _messageBoxMessageEnvoyeTitre As String

    Public Property MessageBoxMessageEnvoyeTitre As String
        Private Get
            Return _messageBoxMessageEnvoyeTitre
        End Get
        Set(ByVal value As String)
            _messageBoxMessageEnvoyeTitre = value
        End Set
    End Property

    Private _smtp As String = String.Empty

    Private Property Smtp As String
        Get
            Return _smtp
        End Get
        Set(ByVal value As String)
            _smtp = value
        End Set
    End Property

    Private _port As String = String.Empty

    Private Property Port As String
        Get
            Return _port
        End Get
        Set(ByVal value As String)
            _port = value
        End Set
    End Property

    Private _emailFromAdress As String = String.Empty

    Private Property EmailFromAdress As String
        Get
            Return _emailFromAdress
        End Get
        Set(ByVal value As String)
            _emailFromAdress = value
        End Set
    End Property

    Private _emailFromName As String = String.Empty

    Private Property EmailFromName As String
        Get
            Return _emailFromName
        End Get
        Set(ByVal value As String)
            _emailFromName = value
        End Set
    End Property

    Private _emailToAdress As String = String.Empty

    Private Property EmailToAdress As String
        Get
            Return _emailToAdress
        End Get
        Set(ByVal value As String)
            _emailToAdress = value
        End Set
    End Property

    Private _emailToName As String = String.Empty

    Private Property EmailToName As String
        Get
            Return _emailToName
        End Get
        Set(ByVal value As String)
            _emailToName = value
        End Set
    End Property

    Private _messageBcc As String = String.Empty

    Private Property MessageBcc As String
        Get
            Return _messageBcc
        End Get
        Set(ByVal value As String)
            _messageBcc = value
        End Set
    End Property

    Private _credentialAdress As String = String.Empty

    Private Property CredentialAdress As String
        Get
            Return _credentialAdress
        End Get
        Set(ByVal value As String)
            _credentialAdress = value
        End Set
    End Property

    Private _credentialPassword As String = String.Empty

    Private Property CredentialPassword As String
        Get
            Return _credentialPassword
        End Get
        Set(ByVal value As String)
            _credentialPassword = value
        End Set
    End Property

    Private _zGuideTvRelease As String

    Public Property ZGuideTvRelease As String
        Private Get
            Return _zGuideTvRelease
        End Get
        Set(ByVal value As String)
            _zGuideTvRelease = value
        End Set
    End Property

    Private _compilationDate As String

    Public Property CompilationDate As String
        Private Get
            Return _compilationDate
        End Get
        Set(ByVal value As String)
            _compilationDate = value
        End Set
    End Property

    Private _osRelease As String

    Public Property OsRelease As String
        Private Get
            Return _osRelease
        End Get
        Set(ByVal value As String)
            _osRelease = value
        End Set
    End Property

    Private _architecture As String

    Public Property Architecture As String
        Private Get
            Return _architecture
        End Get
        Set(ByVal value As String)
            _architecture = value
        End Set
    End Property

    Private _osBootMode As String

    Public Property OsBootMode As String
        Private Get
            Return _osBootMode
        End Get
        Set(ByVal value As String)
            _osBootMode = value
        End Set
    End Property

    Private _framework As String

    Public Property Framework As String
        Private Get
            Return _framework
        End Get
        Set(ByVal value As String)
            _framework = value
        End Set
    End Property

    Private _osLanguage As String

    Public Property OsLanguage As String
        Private Get
            Return _osLanguage
        End Get
        Set(ByVal value As String)
            _osLanguage = value
        End Set
    End Property

    Private _totalMemory As String

    Public Property TotalMemory As String
        Private Get
            Return _totalMemory
        End Get
        Set(ByVal value As String)
            _totalMemory = value
        End Set
    End Property

    Private _remainingMemory As String

    Public Property RemainingMemory As String
        Private Get
            Return _remainingMemory
        End Get
        Set(ByVal value As String)
            _remainingMemory = value
        End Set
    End Property

    Private _usedMemory As String

    Public Property UsedMemory As String
        Private Get
            Return _usedMemory
        End Get
        Set(ByVal value As String)
            _usedMemory = value
        End Set
    End Property

    Private _processorName As String

    Public Property ProcessorName As String
        Private Get
            Return _processorName
        End Get
        Set(ByVal value As String)
            _processorName = value
        End Set
    End Property

    Private _processorNumber As String

    Public Property ProcessorNumber As String
        Private Get
            Return _processorNumber
        End Get
        Set(ByVal value As String)
            _processorNumber = value
        End Set
    End Property

    Private _monitorNumber As String

    Public Property MonitorNumber As String
        Private Get
            Return _monitorNumber
        End Get
        Set(ByVal value As String)
            _monitorNumber = value
        End Set
    End Property

    Private _email As String

    Public Property Email As String
        Private Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _comments As String

    Public Property Comments As String
        Private Get
            Return _comments
        End Get
        Set(ByVal value As String)
            _comments = value
        End Set
    End Property

    Private _descriptionError As String

    Public Property DescriptionError As String
        Private Get
            Return _descriptionError
        End Get
        Set(ByVal value As String)
            _descriptionError = value
        End Set
    End Property

    Private _processorSpeed As String

    Public Property ProcessorSpeed As String
        Private Get
            Return _processorSpeed
        End Get
        Set(ByVal value As String)
            _processorSpeed = value
        End Set
    End Property

    Private _processorDescription As String

    Public Property ProcessorDescription As String
        Private Get
            Return _processorDescription
        End Get
        Set(ByVal value As String)
            _processorDescription = value
        End Set
    End Property

#End Region

    ' 16/07/2010 Griser et désactiver la croix rouge de la form
    Private Const CsNoclose As Integer = &H200

    Private Const PassPhrase As String = ""
    Private Const SaltValue As String = ""
    Private Const PasswordIterations As Integer = 5456
    Private Const InitVector As String = ""
    Private Const KeySize As Integer = 4444

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
        cryptoStream.Close()

        Dim plainText As String
        plainText = Encoding.UTF8.GetString(plainTextBytes,
                                            0,
                                            decryptedByteCount)

        Decrypt = plainText
    End Function

    Private Sub FeedbackLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Trace.WriteLine(DateTime.Now.ToString & " " & _
                         "On entre dans Feedback_Load")

        Mainform.Timer_minute.Stop()

        ' On sélectionne la langue
        Trace.WriteLine(DateTime.Now.ToString & " " & _
                         "On est dans Feedback_Load et on va faire LanguageCheck")
        LanguageCheck()
        LabelFeedbackSend.Text = ""

        Dim reader As XmlTextReader = Nothing

        Try
            Const xmlUrl As String = "http://zguidetv.tuxfamily.org/feedback.xml"
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
                                    'Smtp = Decrypt(New String(CType(reader.Value, Char())))
                                    Smtp = Decrypt(reader.Value)
                                Case "Port"
                                    'Port = Decrypt(New String(CType(reader.Value, Char())))
                                    Port = Decrypt(reader.Value)
                                Case "EmailFromAdress"
                                    'EmailFromAdress = Decrypt(New String(CType(reader.Value, Char())))
                                    EmailFromAdress = Decrypt(reader.Value)
                                Case "EmailFromName"
                                    'EmailFromName = Decrypt(New String(CType(reader.Value, Char())))
                                    EmailFromName = Decrypt(reader.Value)
                                Case "EmailToAdress"
                                    'EmailToAdress = Decrypt(New String(CType(reader.Value, Char())))
                                    EmailToAdress = Decrypt(reader.Value)
                                Case "EmailToName"
                                    'EmailToName = Decrypt(New String(CType(reader.Value, Char())))
                                    EmailToName = Decrypt(reader.Value)
                                Case "MessageBcc"
                                    'MessageBcc = Decrypt(New String(CType(reader.Value, Char())))
                                    MessageBcc = Decrypt(reader.Value)
                                Case "CredentialAdress"
                                    'CredentialAdress = Decrypt(New String(CType(reader.Value, Char())))
                                    CredentialAdress = Decrypt(reader.Value)
                                Case "CredentialPassword"
                                    'CredentialPassword = Decrypt(New String(CType(reader.Value, Char())))
                                    CredentialPassword = Decrypt(reader.Value)
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

        With My.Settings
            If .ManualFeedBack Then
                ExceptErrorMessage.Text = lngExceptErrorMessage
                .ManualFeedBack = False
            End If
        End With

        ' On enlève les lignes vides dans la RitchTextBox ExceptErrorMessage
        Dim txtlst() As String = ExceptErrorMessage.Text.Split(New Char() {ControlChars.Cr, ControlChars.Lf})
        ExceptErrorMessage.Text = ""
        For Each itrStr As String In txtlst
            If Not (Not itrStr.Trim() Is Nothing AndAlso String.IsNullOrEmpty(itrStr.Trim())) Then
                ExceptErrorMessage.Text += itrStr & vbCrLf
            End If
        Next itrStr

        Trace.WriteLine(DateTime.Now.ToString & " " & "On est à la fin du Feedback_Load")
    End Sub

    Private Sub BackgroundWorkerFeedbackDoWork(ByVal sender As Object, _
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
                (MessageBoxFeedback, _
                 MessageBoxFeedbackTitre, MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                 MessageBoxDefaultButton.Button1)

            Show()
        Else

            ' Description du processeur
            Dim sys As New ManagementObjectSearcher("Select * from Win32_Processor")
            Dim infoProcesseur As ManagementObject
            For Each infoProcesseur In sys.Get()
            Next

            ' On recherche le fichier user.config
            Dim _
                configZGuideTv As Configuration = _
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)
            Dim localPathZGuideTv As String = configZGuideTv.FilePath
            Dim temp As String = My.Computer.FileSystem.SpecialDirectories.Temp
            'Copie de fichier
            File.Copy(localPathZGuideTv, temp & "\user.config", True)

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

            ' Version du Framework
            'Dim ver As Version = Environment.Version

            ' Mode de démarrage
            GetWindowsBootMode()

            ' Architecture 32 ou 64 bits
            Is64BitOperatingSystem()
            Dim bitOs As String
            If Is64BitOperatingSystem() Then
                bitOs = "64-bit"
            Else
                bitOs = "32-bit"
            End If

            ' On Configure l'envoi du mail
            Dim client As New SmtpClient(Smtp, CInt(Port))

            client.EnableSsl = True

            Dim from As New MailAddress(EmailFromAdress, EmailFromName)

            Dim [to] As New MailAddress(EmailToAdress, EmailToName)

            Dim message As New MailMessage(from, [to])

            With message
                .Bcc.Add(MessageBcc)

                ' Accusé de réception si la case est cochée
                If Not [String].Equals(TextBoxEmail.Text, "", StringComparison.CurrentCulture) AndAlso CheckBoxAcknowledgment.Checked Then
                    .Bcc.Add(TextBoxEmail.Text)
                End If

                .Priority = MailPriority.High
                .IsBodyHtml = False
            End With

            ' le corp du message à envoyer
            message.Body = ZGuideTvRelease & " " & maVersion.ToString & vbCrLf & _
                           CompilationDate & " " & _
                           File.GetLastWriteTime(AppPath & "ZGuideTVDotNet.exe") & _
                           vbCrLf & OsRelease & " " & My.Computer.Info.OSFullName & _
                           My.Computer.Info.OSVersion & _
                           vbCrLf & _
                           Architecture & " " & bitOs & vbCrLf & _
                           OsBootMode & " " & GetWindowsBootMode.ToString & vbCrLf & _
                           Framework & " " & Environment.Version.ToString() & vbCrLf & _
                           OsLanguage & " " & languageId & vbCrLf & _
                           TotalMemory & " " & memoireTotale & " Mo" & vbCrLf & _
                           RemainingMemory & " " & memoireDisponible & " Mo" & vbCrLf & _
                           UsedMemory & " " & memoireUtilisee & " Mo" & vbCrLf & _
                           ProcessorDescription & " " & infoProcesseur("Description").ToString() & vbCrLf & _
                           ProcessorName & " " & infoProcesseur("Name").ToString() & vbCrLf & _
                           ProcessorSpeed & " " & infoProcesseur("CurrentClockSpeed").ToString() & " Mhz" & vbCrLf & _
                           ProcessorNumber & " " & countProc & vbCrLf & _
                           MonitorNumber & " " & monitorCount & vbCrLf & _
                           Email & " " & TextBoxEmail.Text & vbCrLf & vbCrLf & _
                           Comments & " " & RichTextBoxExceptErrorMessage.Text & vbCrLf & vbCrLf & _
                           DescriptionError & " " & ExceptError

            message.Subject = "ZGuideTV.NET Exception Error"

            If CheckBoxExceptErrorMessage.Checked Then

                ' On attache les fichiers à envoyer
                My.Settings.Save()

                With message.Attachments
                    .Add(New Attachment(LogPath & "ZGuideTVDotNet.exe.log"))
                    .Add(New Attachment(ChannelSetPath & "ZGuideTVDotNet.channels.set"))
                    .Add(New Attachment(temp & "\user.config"))
                End With

            End If

            Dim myCreds As New NetworkCredential(CredentialAdress, CredentialPassword, "")

            client.Credentials = myCreds

            Dim userState As Object = message

            ' Ajouté par Néo le 26/09/2012
            AddHandler client.SendCompleted, AddressOf SmtpClient_OnCompleted

            Try
                ' On envoie le message en asynchrone
                client.SendAsync(message, userState)

            Catch ex As Exception
                Trace.WriteLine("L'exception dans Feedback Form est :" & ex.ToString())
            End Try

        End If
    End Sub

    Private Sub SmtpClient_OnCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)

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

        Smtp = Nothing
        Port = Nothing
        EmailFromAdress = Nothing
        EmailFromName = Nothing
        EmailToAdress = Nothing
        EmailToName = Nothing
        MessageBcc = Nothing
        CredentialAdress = Nothing
        CredentialPassword = Nothing
    End Sub

    Private Sub SendButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles Send_Button.Click

        Trace.WriteLine(DateTime.Now.ToString & " " & "On est dans Feedback et on vient de cliquer sur Send_Button")
        Mainform.Tl.Close()
        PictureBoxFeedback.Image = My.Resources.loader
        LabelFeedbackSend.Text = lngLabelFeedbackSend
        BackgroundWorkerFeedback.RunWorkerAsync()

    End Sub

    Private Sub BackgroundFeedbackRunWorkerCompleted(ByVal sender As Object, _
                                                       ByVal e As RunWorkerCompletedEventArgs) _
        Handles BackgroundWorkerFeedback.RunWorkerCompleted

        Mainform.InitialisationTraceListener()
        Mainform.Timer_minute.Start()

        Trace.WriteLine(DateTime.Now.ToString & " " & "On entre dans BackgroundFeedback_RunWorkerCompleted")

        Hide()

        Trace.WriteLine(DateTime.Now.ToString & " " & _
                         "On est dans BackgroundFeedback_RunWorkerCompleted et on va afficher le message : Feedback envoyé")

        ' ReSharper disable NotAccessedVariable
        Dim boxMessageEnvoye As DialogResult
        ' ReSharper restore NotAccessedVariable
        boxMessageEnvoye = MessageBox.Show _
            (MessageBoxMessageEnvoye, _
             MessageBoxMessageEnvoyeTitre, MessageBoxButtons.OK, MessageBoxIcon.Information, _
             MessageBoxDefaultButton.Button1)

        Trace.WriteLine(DateTime.Now.ToString & " " & "On va quitter BackgroundFeedback_RunWorkerCompleted")

        Thread.Sleep(4000)

        Dispose()
        Close()

    End Sub

    Private Sub ExitButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles Exit_Button.Click
        DialogResult = Windows.Forms.DialogResult.Cancel

        With Mainform
            .Timer_minute.Start()
            .InitialisationTraceListener()
        End With

        Trace.WriteLine(DateTime.Now.ToString & " " & "On entre dans Feedback - Exit_Button_Click")
        Dispose()
        Close()
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
                New Regex( _
                           "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", _
                           RegexOptions.IgnoreCase)
        Return rexp.IsMatch(mailAddress)
    End Function

    Private Declare Function GetSystemMetrics Lib "user32.dll" (ByVal nIndex As Integer) As Integer

    Private Enum BootMode As Integer

        NormalBoot = 0
        'Démarrage normal

        FailSafeBoot = 1
        'Démarrage sans échec

        FailSafeBootNet = 2
        'Démarrage sans échec avec prise en charge du réseau

        UnknownBoot = 3
        'Mode de démarrage inconnu
    End Enum

    Private Function GetWindowsBootMode() As BootMode

        Const smCleanboot As Integer = 67
        Dim iRet As Integer

        iRet = GetSystemMetrics(smCleanboot)
        Dim bm As BootMode
        Select Case iRet
            Case 0
                bm = BootMode.NormalBoot
            Case 1
                bm = BootMode.FailSafeBoot
            Case 2
                bm = BootMode.FailSafeBootNet
            Case Else
                bm = BootMode.UnknownBoot
        End Select

        GetWindowsBootMode = bm
    End Function

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CsNoclose
            Return cp
        End Get
    End Property

    Private Shared Function Is64BitOperatingSystem() As Boolean
        If IntPtr.Size = 8 Then ' 64-bit programs run only on Win64
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
    Private Shared Function IsWow64Process(ByVal hProcess As IntPtr, <Runtime.InteropServices.Out()> ByRef wow64Process As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
End Class
