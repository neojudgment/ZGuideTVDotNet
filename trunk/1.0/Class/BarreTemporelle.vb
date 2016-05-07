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
Public Class BarreTemporelle
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

    Public Property Text_JourMoins As String
        Get
            Return btJourmoins.Text
        End Get
        Set(ByVal value As String)
            btJourmoins.Text = value
            btJourmoins.Invalidate()
        End Set
    End Property

    Public Property Text_HeureMoins As String
        Get
            Return btHeuremoins.Text
        End Get
        Set(ByVal value As String)
            btHeuremoins.Text = value
            btHeuremoins.Invalidate()
        End Set
    End Property

    Public Property Text_Maintenant As String
        Get
            Return btMaintenant.Text
        End Get
        Set(ByVal value As String)
            btMaintenant.Text = value
            btMaintenant.Invalidate()
        End Set
    End Property

    Public Property Text_HeurePlus As String
        Get
            Return btHeureplus.Text
        End Get
        Set(ByVal value As String)
            btHeureplus.Text = value
            btHeureplus.Invalidate()
        End Set
    End Property

    Public Property Text_JourPlus As String
        Get
            Return btJourplus.Text
        End Get
        Set(ByVal value As String)
            btJourplus.Text = value
            btJourplus.Invalidate()
        End Set
    End Property

    Public Property Text_06h As String
        Get
            Return bt06h.Text
        End Get
        Set(ByVal value As String)
            bt06h.Text = value
        End Set
    End Property

    Public Property Text_09h As String
        Get
            Return bt09h.Text
        End Get
        Set(ByVal value As String)
            bt09h.Text = value
        End Set
    End Property

    Public Property Text_12h As String
        Get
            Return bt12h.Text
        End Get
        Set(ByVal value As String)
            bt12h.Text = value
        End Set
    End Property

    Public Property Text_15h As String
        Get
            Return bt15h.Text
        End Get
        Set(ByVal value As String)
            bt15h.Text = value
        End Set
    End Property

    Public Property Text_18h As String
        Get
            Return bt18h.Text
        End Get
        Set(ByVal value As String)
            bt18h.Text = value
        End Set
    End Property

    Public Property Text_20h As String
        Get
            Return bt20h.Text
        End Get
        Set(ByVal value As String)
            bt20h.Text = value
        End Set
    End Property

    Public Property Text_23h As String
        Get
            Return bt23h.Text
        End Get
        Set(ByVal value As String)
            bt23h.Text = value
        End Set
    End Property

    Private _Enabled_Button As Boolean = True

    Public Property Enabled_Button As Boolean
        Get
            Return _Enabled_Button
        End Get
        Set(ByVal value As Boolean)
            _Enabled_Button = value
            btJourmoins.Enabled = _Enabled_Button
            btHeuremoins.Enabled = _Enabled_Button
            bt06h.Enabled = _Enabled_Button
            bt09h.Enabled = _Enabled_Button
            bt12h.Enabled = _Enabled_Button
            bt15h.Enabled = _Enabled_Button
            bt18h.Enabled = _Enabled_Button
            bt20h.Enabled = _Enabled_Button
            bt23h.Enabled = _Enabled_Button
            btMaintenant.Enabled = _Enabled_Button
            btHeureplus.Enabled = _Enabled_Button
            btJourplus.Enabled = _Enabled_Button

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
            redrawBouton()
        End Set
    End Property

    Private _old_ui As Boolean = True

    Public Property old_UI As Boolean
        Get
            Return _old_ui
        End Get
        Set(ByVal value As Boolean)
            _old_ui = value
            btJourmoins.old_UI = _old_ui
            btHeuremoins.old_UI = _old_ui
            bt06h.old_UI = _old_ui
            bt09h.old_UI = _old_ui
            bt12h.old_UI = _old_ui
            bt15h.old_UI = _old_ui
            bt18h.old_UI = _old_ui
            bt20h.old_UI = _old_ui
            bt23h.old_UI = _old_ui
            btMaintenant.old_UI = _old_ui
            btHeureplus.old_UI = _old_ui
            btJourplus.old_UI = _old_ui
            redrawBouton()
        End Set
    End Property

    Private Sub redrawBouton()
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
        redrawBouton()
    End Sub

    Event ButtonChanged(ByVal Bouton As String)

    Private memobouton As String = "btMaintenant"
    Private memomaintenant As Integer = DateTime.Now.Hour

    Private Sub TestButtonChanged(ByVal sender As Object, ByVal e As EventArgs) Handles bt06h.Click, _
                                                                                         bt09h.Click, _
                                                                                         bt12h.Click, _
                                                                                         bt15h.Click, _
                                                                                         bt18h.Click, _
                                                                                         bt20h.Click, _
                                                                                         bt23h.Click

        If Not (DirectCast(sender, Control).Name.Equals(memobouton, StringComparison.CurrentCulture)) Then
            memobouton = DirectCast(sender, Control).Name
            RaiseEvent ButtonChanged(DirectCast(sender, Control).Name)
        End If
    End Sub

    Private Sub TestButtonChanged2(ByVal sender As Object, ByVal e As EventArgs) Handles btJourmoins.Click, _
                                                                                          btJourplus.Click, _
                                                                                          btHeuremoins.Click, _
                                                                                          btHeureplus.Click
        RaiseEvent ButtonChanged(DirectCast(sender, Control).Name)
        memobouton = ""
    End Sub

    Private Sub TestButtonChanged3(ByVal sender As Object, ByVal e As EventArgs) Handles btMaintenant.Click
        If _
            Not (DirectCast(sender, Control).Name.Equals(memobouton, StringComparison.CurrentCulture)) OrElse _
            memomaintenant <> DateTime.Now.Hour Then
            memobouton = DirectCast(sender, Control).Name
            memomaintenant = DateTime.Now.Hour
            RaiseEvent ButtonChanged(DirectCast(sender, Control).Name)
        End If

    End Sub
End Class
