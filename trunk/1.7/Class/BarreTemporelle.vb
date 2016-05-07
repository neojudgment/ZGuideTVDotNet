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
' ReSharper disable CheckNamespace
Public Class BarreTemporelle
    ' ReSharper restore CheckNamespace
    Inherits UserControl

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        btJourmoins.Text = "Jour -1"
        btHeuremoins.Text = "Heure -1"
        bt06h.Text = "06H"
        bt09h.Text = "09H"
        bt12h.Text = "12H"
        bt15h.Text = "15H"
        bt18h.Text = "18H"
        bt20h.Text = "20H"
        bt23h.Text = "23H"
        btMaintenant.Text = "Maintenant"
        btHeureplus.Text = "Heure +1"
        btJourplus.Text = "Jour +1"
    End Sub

    Public Property TextJourMoins As String
        Get
            Return btJourmoins.Text
        End Get
        Set(ByVal value As String)
            btJourmoins.Text = value
            btJourmoins.Invalidate()
        End Set
    End Property

    Public Property TextHeureMoins As String
        Get
            Return btHeuremoins.Text
        End Get
        Set(ByVal value As String)
            btHeuremoins.Text = value
            btHeuremoins.Invalidate()
        End Set
    End Property

    Public Property TextMaintenant As String
        Get
            Return btMaintenant.Text
        End Get
        Set(ByVal value As String)
            btMaintenant.Text = value
            btMaintenant.Invalidate()
        End Set
    End Property

    Public Property TextHeurePlus As String
        Get
            Return btHeureplus.Text
        End Get
        Set(ByVal value As String)
            btHeureplus.Text = value
            btHeureplus.Invalidate()
        End Set
    End Property

    Public Property TextJourPlus As String
        Get
            Return btJourplus.Text
        End Get
        Set(ByVal value As String)
            btJourplus.Text = value
            btJourplus.Invalidate()
        End Set
    End Property

    Public Property Text06H As String
        Get
            Return bt06h.Text
        End Get
        Set(ByVal value As String)
            bt06h.Text = value
        End Set
    End Property

    Public Property Text09H As String
        Get
            Return bt09h.Text
        End Get
        Set(ByVal value As String)
            bt09h.Text = value
        End Set
    End Property

    Public Property Text12H As String
        Get
            Return bt12h.Text
        End Get
        Set(ByVal value As String)
            bt12h.Text = value
        End Set
    End Property

    Public Property Text15H As String
        Get
            Return bt15h.Text
        End Get
        Set(ByVal value As String)
            bt15h.Text = value
        End Set
    End Property

    Public Property Text18H As String
        Get
            Return bt18h.Text
        End Get
        Set(ByVal value As String)
            bt18h.Text = value
        End Set
    End Property

    Public Property Text20H As String
        Get
            Return bt20h.Text
        End Get
        Set(ByVal value As String)
            bt20h.Text = value
        End Set
    End Property

    Public Property Text23H As String
        Get
            Return bt23h.Text
        End Get
        Set(ByVal value As String)
            bt23h.Text = value
        End Set
    End Property

    Private _enabledButton As Boolean = True

    Public Property EnabledButton As Boolean
        Get
            Return _enabledButton
        End Get
        Set(ByVal value As Boolean)
            _enabledButton = value
            btJourmoins.Enabled = _enabledButton
            btHeuremoins.Enabled = _enabledButton
            bt06h.Enabled = _enabledButton
            bt09h.Enabled = _enabledButton
            bt12h.Enabled = _enabledButton
            bt15h.Enabled = _enabledButton
            bt18h.Enabled = _enabledButton
            bt20h.Enabled = _enabledButton
            bt23h.Enabled = _enabledButton
            btMaintenant.Enabled = _enabledButton
            btHeureplus.Enabled = _enabledButton
            btJourplus.Enabled = _enabledButton

            If Not (value) Then
                btJourmoins.BGColor = Color.FromArgb(255, 128, 128, 128)
                btHeuremoins.BGColor = Color.FromArgb(255, 128, 128, 128)
                bt06h.BGColor = Color.FromArgb(255, 128, 128, 128)
                bt09h.BGColor = Color.FromArgb(255, 128, 128, 128)
                bt12h.BGColor = Color.FromArgb(255, 128, 128, 128)
                bt15h.BGColor = Color.FromArgb(255, 128, 128, 128)
                bt18h.BGColor = Color.FromArgb(255, 128, 128, 128)
                bt20h.BGColor = Color.FromArgb(255, 128, 128, 128)
                bt23h.BGColor = Color.FromArgb(255, 128, 128, 128)
                btMaintenant.BGColor = Color.FromArgb(255, 128, 128, 128)
                btHeureplus.BGColor = Color.FromArgb(255, 128, 128, 128)
                btJourplus.BGColor = Color.FromArgb(255, 128, 128, 128)
            Else
                btJourmoins.BGColor = Color.FromArgb(255, 72, 181, 130)
                btHeuremoins.BGColor = Color.FromArgb(255, 72, 128, 182)
                bt06h.BGColor = Color.FromArgb(255, 72, 128, 182)
                bt09h.BGColor = Color.FromArgb(255, 72, 128, 182)
                bt12h.BGColor = Color.FromArgb(255, 72, 128, 182)
                bt15h.BGColor = Color.FromArgb(255, 72, 128, 182)
                bt18h.BGColor = Color.FromArgb(255, 72, 128, 182)
                bt20h.BGColor = Color.FromArgb(255, 72, 128, 182)
                bt23h.BGColor = Color.FromArgb(255, 72, 128, 182)
                btMaintenant.BGColor = Color.FromArgb(255, 219, 77, 72)
                btHeureplus.BGColor = Color.FromArgb(255, 72, 128, 182)
                btJourplus.BGColor = Color.FromArgb(255, 72, 181, 130)

            End If
            RedrawBouton()
        End Set
    End Property

    'Private _oldUi As Boolean = True

    'Public Property OldUi As Boolean
    '    Get
    '        Return _oldUi
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _oldUi = value
    '        btJourmoins.OldUi = _oldUi
    '        btHeuremoins.OldUi = _oldUi
    '        bt06h.OldUi = _oldUi
    '        bt09h.OldUi = _oldUi
    '        bt12h.OldUi = _oldUi
    '        bt15h.OldUi = _oldUi
    '        bt18h.OldUi = _oldUi
    '        bt20h.OldUi = _oldUi
    '        bt23h.OldUi = _oldUi
    '        btMaintenant.OldUi = _oldUi
    '        btHeureplus.OldUi = _oldUi
    '        btJourplus.OldUi = _oldUi
    '        RedrawBouton()
    '    End Set
    'End Property

    Private Sub RedrawBouton()
        btJourmoins.Invalidate()
        btHeuremoins.Invalidate()
        bt06h.Invalidate()
        bt09h.Invalidate()
        bt12h.Invalidate()
        bt15h.Invalidate()
        bt18h.Invalidate()
        bt20h.Invalidate()
        bt23h.Invalidate()
        btMaintenant.Invalidate()
        btHeureplus.Invalidate()
        btJourplus.Invalidate()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        RedrawBouton()
    End Sub

    Event ButtonChanged(ByVal bouton As String)

    Private _memobouton As String = "btMaintenant"
    'Private _memomaintenant As Integer = DateTime.Now.Hour

    Private Sub TestButtonChanged(ByVal sender As Object, ByVal e As EventArgs) Handles bt06h.Click, _
                                                                                         bt09h.Click, _
                                                                                         bt12h.Click, _
                                                                                         bt15h.Click, _
                                                                                         bt18h.Click, _
                                                                                         bt20h.Click, _
                                                                                         bt23h.Click

        If Not (DirectCast(sender, Control).Name.Equals(_memobouton, StringComparison.CurrentCulture)) Then
            _memobouton = DirectCast(sender, Control).Name
            RaiseEvent ButtonChanged(DirectCast(sender, Control).Name)
        End If
    End Sub

    Private Sub TestButtonChanged2(ByVal sender As Object, ByVal e As EventArgs) Handles btJourmoins.Click, _
                                                                                          btJourplus.Click, _
                                                                                          btHeuremoins.Click, _
                                                                                          btHeureplus.Click
        RaiseEvent ButtonChanged(DirectCast(sender, Control).Name)
        _memobouton = ""
    End Sub

    Private Sub TestButtonChanged3(ByVal sender As Object, ByVal e As EventArgs) Handles btMaintenant.Click

        _memobouton = DirectCast(sender, Control).Name
        '_memomaintenant = DateTime.Now.Hour
        RaiseEvent ButtonChanged(DirectCast(sender, Control).Name)
    End Sub

    Public Sub ReinitBouton()
        _memobouton = String.Empty
    End Sub
End Class
