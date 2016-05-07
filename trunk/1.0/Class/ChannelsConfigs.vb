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
Imports System.IO

Public Class ChannelsConfigs

    Public path As String = AppData
    Public Name As String = "ZGuideTVDotNet.channels.XML.set"
    Private DocXml As XmlDocument = New XmlDocument
    Private XMLRacine As XmlNode
    Private CurrentNode As XmlNode

    Private _
        root As String = "<?xml version='1.0' encoding='ISO-8859-1'?>" & Chr(13) & "<Channels>" & Chr(13) & _
                         "</Channels>"

    Public Sub New()

        CreateInstance()
    End Sub

    Public Sub New(ByRef bAuto As Boolean)

        CreateInstance(bAuto)
    End Sub

    Public Sub New(ByVal XMLPath As String, ByVal XMLName As String, ByVal entete As String)

        Name = XMLName
        path = XMLPath
        root = entete
        CreateInstance()
    End Sub

    Public Sub New(ByVal XMLName As String)

        Name = XMLName
        CreateInstance()
    End Sub

    Public Sub New(ByVal XMLName As String, ByVal entete As String)

        Name = XMLName
        root = entete
        CreateInstance()
    End Sub

    Public Sub GetChannel(ByVal ChannelId As String, Optional ByVal ChannelName As String = "")
        Dim btrouve As Boolean = False

        ' on vérifie qu'il ai qq chose dans la racine
        If XMLRacine.ChildNodes.Count < 1 Then
            CreateInstance()
        End If
        If XMLRacine.ChildNodes.Count > 0 Then
            Dim TempRacine As XmlNode = XMLRacine
            Dim Channels As XmlNodeList = TempRacine.SelectNodes("channel")
            If Channels.Count > 0 Then
                Dim i As Integer = 0
                Dim TempsAttr As XmlAttribute

                While (Not btrouve AndAlso i < Channels.Count)
                    CurrentNode = Channels.Item(i)
                    TempsAttr = CurrentNode.Attributes("id")

                    ' vrai si le nom de la chaine trouvé correspond à celle que l'on recherche
                    btrouve = (TempsAttr.Value.ToString = ChannelId)

                    i += 1
                End While
            End If
        End If

        If Not btrouve Then

            ' Si on a pas trouver la chaînes alors on la créé
            Dim XMLNode As XmlNode = DocXml.CreateElement("channel")
            Dim Attr1 As XmlAttribute = DocXml.CreateAttribute("id")
            Attr1.InnerText = ChannelId
            XMLNode.Attributes.Append(Attr1)

            Dim Attr2 As XmlAttribute = DocXml.CreateAttribute("Name")
            Attr2.InnerText = ChannelName

            XMLNode.Attributes.Append(Attr2)

            CurrentNode = XMLNode
            Dim KTVElement As XmlElement = DocXml.CreateElement("KTV")
            Dim MMTVElement As XmlElement = DocXml.CreateElement("MMTV")
            XMLNode.AppendChild(KTVElement)
            XMLNode.AppendChild(MMTVElement)

            DocXml.Item("Channels").AppendChild(XMLNode)

            DocXml.Save(path & "\" & Name)

            LitRacine()
            If XMLRacine.ChildNodes.Count < 1 Then
                CreateInstance()
            End If

            ' On refait la recherche
            If XMLRacine.ChildNodes.Count > 0 Then
                Dim TempRacine As XmlNode = XMLRacine
                Dim Channels As XmlNodeList = TempRacine.SelectNodes("channel")
                If Channels.Count > 0 Then
                    Dim i As Integer = 0
                    Dim TempsAttr As XmlAttribute

                    While (Not btrouve AndAlso i < Channels.Count)
                        CurrentNode = Channels.Item(i)
                        TempsAttr = CurrentNode.Attributes("id")

                        ' vrai si le nom de la chaine trouvé correspond à celle que l'on recherche
                        btrouve = (TempsAttr.Value.ToString = ChannelId)

                        i += 1
                    End While
                End If
            End If

            Select Case btrouve
                Case True
                    CurrentNode = XMLNode
                Case Else
                    CurrentNode = Nothing
            End Select
        End If
    End Sub

    Public Function GetLogNode(ByVal Channelid As String, ByVal Log As String, _
                                Optional ByVal ChannelName As String = "") As XmlNode

        GetChannel(Channelid, ChannelName)
        If CurrentNode Is Nothing Then
            MessageBox.Show("Impossible de se positionner sur " & ChannelName & " .")
        End If
        Return CurrentNode.Item(Log)
    End Function

    Public Function GetChannelOption(ByVal ChannelId As String, ByVal Log As String, ByVal Source As String, _
                                      Optional ByVal defaultValue As String = "0", _
                                      Optional ByVal ChannelName As String = "") As String

        ' permet de retrouver la chaine sur K!TV ou MMTV
        Dim Valeur As String = ""
        LitRacine()

        Source = Rename(Source)

        Dim LogNod As XmlNode = GetLogNode(ChannelId, Log, ChannelName)
        If Not (LogNod Is Nothing) Then
            Dim Attr As XmlAttribute = LogNod.Attributes(Source)
            If (Attr Is Nothing) Then
                Dim TmpNode As XmlNode = LogNod
                Attr = DocXml.CreateAttribute(Source)
                Attr.InnerText = defaultValue
                LogNod.Attributes.Append(Attr)
                LogNod.OwnerDocument.Save(path & "\" & Name)
                Valeur = defaultValue
            Else
                Valeur = Attr.Value.ToString
            End If
        Else
            MessageBox.Show("Impossible de se positionner sur " & Log & " .")
        End If
        Return Valeur
    End Function

    Public Sub SetChannelOption(ByVal ChannelId As String, ByVal Log As String, ByVal Source As String, _
                                 ByVal Value As String, Optional ByVal ChannelName As String = "")

        LitRacine()
        Source = Rename(Source)
        Dim LogNod As XmlNode = GetLogNode(ChannelId, Log, ChannelName)
        If Not (LogNod Is Nothing) Then
            Dim Attr As XmlAttribute = LogNod.Attributes(Source)
            If (Attr Is Nothing) Then
                'Dim TmpNode As XmlNode = LogNod
                Attr = DocXml.CreateAttribute(Source)
                Attr.InnerText = Value
                LogNod.Attributes.Append(Attr)
                LogNod.OwnerDocument.Save(path & "\" & Name)
            Else
                Attr.Value = Value
                Attr.OwnerDocument.Save(path & "\" & Name)
            End If
        Else
            MessageBox.Show("Impossible de se positionner sur " & Log & " .")
        End If
    End Sub

    Private Sub CreateInstance()

        With DocXml
            If Not File.Exists(path & "\" & Name) Then
                Try
                    DocXml = New XmlDocument()
                    .LoadXml(root)
                    .Save(path & "\" & Name)
                Catch ex As Exception
                    Dim FenMessage As Message = New Message(ex.Message, MsgBoxStyle.Critical, True)
                    FenMessage.ShowDialog()
                End Try

            End If

            Try
                DocXml = New XmlDocument()
                .Load(path & "\" & Name)
                XMLRacine = .Item("Channels")
            Catch ex As Exception
                File.Delete(path & "\" & Name)
                'Dim doc As XmlDocument = New XmlDocument()
                .LoadXml(root)
                .Save(path & "\" & Name)
                XMLRacine = .Item("Channels")
            End Try
        End With
    End Sub

    Private Sub CreateInstance(ByRef bAuto As Boolean)

        With DocXml
            If Not File.Exists(path & "\" & Name) Then
                bAuto = True
                Try
                    DocXml = New XmlDocument()
                    .LoadXml(root)
                    .Save(path & "\" & Name)
                Catch ex As Exception
                    Dim FenMessage As Message = New Message(ex.Message, MsgBoxStyle.Critical, True)
                    FenMessage.ShowDialog()
                End Try

            End If

            Try
                DocXml = New XmlDocument()
                .Load(path & "\" & Name)
                XMLRacine = .Item("Channels")
            Catch ex As Exception
                File.Delete(path & "\" & Name)
                .LoadXml(root)
                .Save(path & "\" & Name)
                XMLRacine = .Item("Channels")
            End Try
        End With
    End Sub

    Public Sub GetLogChannel(ByVal NumChannel As String, ByVal Log As String, ByVal Source As String, _
                              ByRef ZName As String, ByRef ZId As String)

        ' cette fonction permet de retouver une chaine de ZGuideTV a partir du N° de chaine sur K!TV ou MMTV
        Dim btrouve As Boolean = False
        Dim TmpName As String = ""
        Dim TmpId As String = ""

        'Dim Valeur As String = ""
        LitRacine()

        Source = Rename(Source)
        If Source <> "" Then
            If XMLRacine.ChildNodes.Count < 1 Then
                CreateInstance()
            End If

            If XMLRacine.ChildNodes.Count > 0 Then
                Dim TempRacine As XmlNode = XMLRacine
                Dim Channels As XmlNodeList = TempRacine.SelectNodes("channel")
                If Channels.Count > 0 Then
                    Dim i As Integer = 0

                    While (Not btrouve AndAlso i < Channels.Count)
                        CurrentNode = Channels.Item(i)
                        TmpName = CurrentNode.Attributes("Name").Value.ToString
                        TmpId = CurrentNode.Attributes("id").Value.ToString
                        Dim LogNod As XmlNode = GetLogNode(TmpId, Log)

                        btrouve = (LogNod.Attributes(Source).Value.ToString = NumChannel)

                        i += 1
                    End While
                End If
            End If
        End If

        Select Case btrouve
            Case True
                ZName = TmpName
                ZId = TmpId
            Case Else
                ZName = ""
                ZId = ""
        End Select
    End Sub

    Public Function Rename(ByVal Name As String) As String

        ' un nom d'attribu ne peut pas avoir de caractères spéciaux ni commencer pas un chiffre
        If Name <> "" Then
            With Name
                Name = .Replace(" ", "_ESPA_")
                Name = .Replace("@", "_AROBE_")
                Name = .Replace("*", "_ETOI_")
                Name = .Replace("/", "_Slash_")
                Name = .Replace("\", "_ASlash_")
            End With

            'If (Name (0) = "0" Or Name (0) = "1") Then
            '    Name = "chi_" + Name
            'End If
            'If (Name (0) = "2" Or Name (0) = "3") Then
            '    Name = "chi_" + Name
            'End If
            'If (Name (0) = "4" Or Name (0) = "5") Then
            '    Name = "chi_" + Name
            'End If
            'If (Name (0) = "6" Or Name (0) = "7") Then
            '    Name = "chi_" + Name
            'End If
            'If (Name (0) = "8" Or Name (0) = "9") Then
            '    Name = "chi_" + Name
            'End If
            If Char.IsDigit(Name(0)) Then
                Name = "chi_" + Name
            End If
        End If

        Return Name
    End Function

    Public Sub LitRacine()

        XMLRacine = DocXml.Item("Channels")
    End Sub
End Class
