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
'' ReSharper disable CheckNamespace
'Friend Module TaskBar
'    ' ReSharper restore CheckNamespace

'    ' Envoi d'un message au systéme
'    Private Function ShAppBarMessage(ByVal dwMessage As Integer, ByRef pData As Appbardata) As Integer
'        Return 0
'    End Function

'    ' Demande si la barre de tâche est en avant plan et si elle se masque automatiquement
'    Private Const AbmGetstate As Int32 = &H4

'    ' Demande la position de barre de tâche (RECT)
'    Private Const AbmGettaskbarpos As Int32 = &H5

'    Private Const AbsAutohide As Int32 = &H1
'    Private Const AbsOntop As Int32 = &H2

'    Private Structure Rect
'        Public Left As Integer
'        Public Top As Integer
'        Public Right As Integer
'        Public Bottom As Integer

'        Public Overloads Overrides Function GetHashCode() As Integer
'            Throw New NotImplementedException()
'        End Function

'        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
'            Throw New NotImplementedException()
'        End Function
'    End Structure

'    ' Structure des données
'    Private Structure Appbardata
'        Public CbSize As Integer
'        Public Hwnd As Integer
'        Public UCallbackMessage As Integer
'        Public UEdge As Integer
'        Public rc As Rect
'        Public LParam As Integer

'        Public Overloads Overrides Function GetHashCode() As Integer
'            Throw New NotImplementedException()
'        End Function

'        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
'            Throw New NotImplementedException()
'        End Function
'    End Structure

'    ' alignement de la barre de tâche
'    Public Enum TaskBarAlign
'        Left
'        Right
'        Top
'        Bottom
'    End Enum

'    Public Function GetTaskBarAlign() As TaskBarAlign

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' L'écran sur lequel la barre de tâche se trouve
'        Dim oScreen As Screen

'        ' Demande la position de barre de tâche
'        ShAppBarMessage(AbmGettaskbarpos, oAbData)

'        ' On regarde sur quel écran la barre de tâche se trouve
'        oScreen = Screen.FromRectangle(GetTaskBarRectangle)

'        ' On teste la position (basé sur l'écran sur lequel la barre de tâche est active), largeur
'        ' et hauteur pour déterminer l'alignement de la barre de tâche
'        If _
'            (oAbData.rc.Left = oScreen.Bounds.Left) AndAlso (oAbData.rc.Top = oScreen.Bounds.Top) AndAlso _
'            (GetTaskBarHeight() < GetTaskBarWidth()) Then

'            ' La barre de tâche alignée en haut
'            Return TaskBarAlign.Top
'        End If

'        If _
'            (oAbData.rc.Left = oScreen.Bounds.Left) AndAlso (oAbData.rc.Top = oScreen.Bounds.Top) AndAlso _
'            (GetTaskBarWidth() < GetTaskBarHeight()) Then

'            ' La barre de tâche alignée à gauche
'            Return TaskBarAlign.Left
'        End If

'        If (oAbData.rc.Left = oScreen.Bounds.Left) AndAlso (oAbData.rc.Top <> oScreen.Bounds.Top) Then

'            ' La barre de tâche alignée en bas
'            Return TaskBarAlign.Bottom
'        End If

'        If (oAbData.rc.Left <> oScreen.Bounds.Left) AndAlso (oAbData.rc.Top = oScreen.Bounds.Top) Then

'            ' La barre de tâche alignée à droite
'            Return TaskBarAlign.Right
'        End If
'        Return Nothing
'    End Function

'    Private Function GetTaskBarRectangle() As Rectangle

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' Demande la position de barre de tâche
'        ShAppBarMessage(AbmGettaskbarpos, oAbData)

'        Return _
'            New Rectangle(oAbData.rc.Left, oAbData.rc.Top, oAbData.rc.Right - oAbData.rc.Left, _
'                           oAbData.rc.Bottom - oAbData.rc.Top)
'    End Function

'    Public Function GetTaskBarLeft() As Long

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' Demande la position de barre de tâche
'        ShAppBarMessage(AbmGettaskbarpos, oAbData)

'        Return oAbData.rc.Left
'    End Function

'    Public Function GetTaskBarRight() As Long

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' Demande la position de barre de tâche
'        ShAppBarMessage(AbmGettaskbarpos, oAbData)

'        Return oAbData.rc.Right
'    End Function

'    Public Function GetTaskBarTop() As Long

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' Demande la position de barre de tâche
'        ShAppBarMessage(AbmGettaskbarpos, oAbData)

'        Return oAbData.rc.Top
'    End Function

'    Public Function GetTaskBarBottom() As Long
'        'Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        'Demande la position de barre de tâche
'        ShAppBarMessage(AbmGettaskbarpos, oAbData)

'        Return oAbData.rc.Bottom
'    End Function

'    Private Function GetTaskBarWidth() As Long

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' Demande la position de barre de tâche
'        ShAppBarMessage(AbmGettaskbarpos, oAbData)

'        Return oAbData.rc.Right - oAbData.rc.Left
'    End Function

'    Public Function GetTaskBarHeight() As Long

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' Demande la position de barre de tâche
'        ShAppBarMessage(AbmGettaskbarpos, oAbData)

'        Return oAbData.rc.Bottom - oAbData.rc.Top
'    End Function

'    Public Function IsTaskbarIsTopMost() As Boolean

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' Si la barre de tâche est toujours en avant plan = True
'        Return (AbsOntop = ShAppBarMessage(AbmGetstate, oAbData))
'    End Function

'    Public Function IsTaskbarAutoHide() As Boolean

'        ' Utilisé pour récupérer des informations de la barre de tâche
'        Dim oAbData As Appbardata

'        ' Si la barre de tâche est sur masquer automatiquement = True
'        Return (AbsAutohide = ShAppBarMessage(AbmGetstate, oAbData))
'    End Function

'    Public Function GetTaskbarDisplayName() As String

'        ' Nom de l'écran sur lequel la barre de tâche se trouve
'        Return Screen.FromRectangle(GetTaskBarRectangle).DeviceName
'    End Function
'End Module
