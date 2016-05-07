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
Imports System.Xml
Imports Microsoft.DirectX.AudioVideoPlayback
Imports Microsoft.DirectX

' ReSharper disable CheckNamespace
' ReSharper disable InconsistentNaming
Module UpdateXMLParser
    ' ReSharper restore InconsistentNaming
    ' ReSharper restore CheckNamespace

#Region "Property"

    Private _messageBoxMiseaJourExe As String

    Public Property MessageBoxMiseaJourExe As String
        Get
            Return _messageBoxMiseaJourExe
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJourExe = Value
        End Set
    End Property

    Private _messageBoxMiseaJourExe1 As String

    Public Property MessageBoxMiseaJourExe1 As String
        Get
            Return _MessageBoxMiseaJourExe1
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJourExe1 = Value
        End Set
    End Property

    Private _messageBoxMiseaJourExeTitre As String

    Public Property MessageBoxMiseaJourExeTitre As String
        Get
            Return _MessageBoxMiseaJourExeTitre
        End Get
        Set(ByVal value As String)
            _messageBoxMiseaJourExeTitre = Value
        End Set
    End Property

    Private _messageBoxnoupdate As String

    Public Property MessageBoxnoupdate As String
        Get
            Return _MessageBoxnoupdate
        End Get
        Set(ByVal value As String)
            _messageBoxnoupdate = Value
        End Set
    End Property

    Private _messageBoxnoupdateTitre As String

    Public Property MessageBoxnoupdateTitre As String
        Get
            Return _MessageBoxnoupdateTitre
        End Get
        Set(ByVal value As String)
            _messageBoxnoupdateTitre = Value
        End Set
    End Property

#End Region

    Sub XmlParser()

        LanguageCheck()

        ' La variable newVersion contient
        ' le version du fichier xml 
        Dim newVersion As Version = Nothing
        ' urlfr et urlen contiennent les url à ouvrir en fonction de la langue
        Dim urlfr As String = ""
        Dim urlen As String = ""
        Dim reader As XmlTextReader = Nothing
        Try
            ' Fourni les url contenue dans le document xml
            Const xmlUrl As String = "http://zguidetv.tuxfamily.org/zguidetv_version.xml"
            reader = New XmlTextReader(xmlUrl)
            reader.MoveToContent()

            Dim elementName As String = ""
            ' On controle si le fichier xml contient le noeud "zguidetv"
            If (reader.NodeType = XmlNodeType.Element) AndAlso (reader.Name = "zguidetv") Then
                Do While reader.Read()
                    ' Quand on trouve un noeud on se souvient de son nom  
                    If reader.NodeType = XmlNodeType.Element Then
                        elementName = reader.Name
                    Else
                        ' noeud suivant 
                        If (reader.NodeType = XmlNodeType.Text) AndAlso (reader.HasValue) Then
                            ' On controle le nom des noeuds  
                            Select Case elementName
                                Case "version"
                                    ' On parse le num de version
                                    ' dans le format :  xxx.xxx.xxx.xxx
                                    newVersion = New Version(reader.Value)
                                Case "urlfr"
                                    urlfr = reader.Value
                                Case "urlen"
                                    urlen = reader.Value
                            End Select
                        End If
                    End If
                Loop
            End If
        Catch ex As Exception
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try

        ' On regarde le numéro de la version actuelle  
        Dim curVersion As Version = Reflection.Assembly.GetExecutingAssembly().GetName().Version

        ' On compare les versions
        If curVersion.CompareTo(newVersion) < 0 Then
            ' On demande à l'utilisateur si  
            ' il veut télécharger la nouvelle version

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

            Dim boxMiseaJourExe As DialogResult
            boxMiseaJourExe = MessageBox.Show _
                (MessageBoxMiseaJourExe & Chr(13) & MessageBoxMiseaJourExe1, _
                 MessageBoxMiseaJourExeTitre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                 MessageBoxDefaultButton.Button1)

            If boxMiseaJourExe = Windows.Forms.DialogResult.Yes Then
                Trace.WriteLine(DateTime.Now & " " & "On va sur le site Web de zg pour mise à jour de l'exe")
                If My.Settings.Language = "Français" Then
                    Process.Start(urlfr)
                Else
                    Process.Start(urlen)
                End If

            Else
                Trace.WriteLine(DateTime.Now & " " & "On ne va pas sur le site Web de zg pour mise à jour de l'exe")
                Return
            End If

        Else

            ' On regarde si c'est une mise à jour auto
            If Not Mainform.MiseaJourAutoExe Then

                ' ReSharper disable NotAccessedVariable
                Dim boxMiseaJour As DialogResult
                ' ReSharper restore NotAccessedVariable

                boxMiseaJour = MessageBox.Show _
                (MessageBoxnoupdate, _
                MessageBoxnoupdateTitre, MessageBoxButtons.OK, MessageBoxIcon.Information, _
                MessageBoxDefaultButton.Button1)
                Return
            Else
                Mainform.MiseaJourAutoExe = False
            End If
        End If
    End Sub
End Module
