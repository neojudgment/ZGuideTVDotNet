' •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
' |                                                                                                            |
' |    ZGuideTV.NET is an Electronic Program Guide (EPG) - an electronic TV magazine which lets you see        |
' |    TV listings for today and next week.                                                                    |
' |                                                                                                            |
' |    It can be customised to include only those TV listings you want to see.                                 |
' |                                                                                                            |
' |    Copyright (C) 2004-2017 ZGuideTV.NET Team <https://github.com/neojudgment>                              |
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

Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Globalization

Public Class ucPopup

    Public MystrDe As String = " de "
    Public MystrA As String = " à "
    Public MystrSur As String = " sur"

    Private _titreCourt As String = String.Empty
    Private Const Largeur As Integer = 585

    ' ReSharper disable ParameterHidesMember
    Public Event EventInfo(titre As String, engine As String)
    ' ReSharper restore ParameterHidesMember

    Dim _memPosition As Integer

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        SetStyle(
    ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
    ControlStyles.OptimizedDoubleBuffer, True)
        SuspendLayout()

        lblInfoActeur.Text = String.Empty
        lblInfoRealisateur.Text = String.Empty
        lblInfoPresentateur.Text = String.Empty
        lblInfoSynopsis.Text = String.Empty
        lblShowView.Text = String.Empty

        lblRealise.Text = LngPopupLblRealise
        lblPresents.Text = LngPopupLblPresents
        lblAvec.Text = LngPopupLblAvec
        lblSynopsis.Text = LngPopupLblResume
        cboRecherche.lblNomRecherche.Text = LngPopupStrRechercheAvancee

        lblInfoActeur.MaximumSize = New Size(Largeur, 0)
        lblInfoSynopsis.MaximumSize = New Size(Largeur, 0)
        lblTitre.MaximumSize = New Size(Largeur - pbClose.Width, 0)
        CalculeLargeurMaxLabel()
        ResumeLayout()
    End Sub

    Private Sub cboRecherche_EventEngine(engine As String) Handles cboRecherche.EventEngine

        RaiseEvent EventInfo(_titreCourt, engine)
    End Sub

    Public Sub MajLangagePopup()

        'changement des text des labels
        SuspendLayout()
        lblRealise.Text = LngPopupLblRealise
        lblPresents.Text = LngPopupLblPresents
        lblAvec.Text = LngPopupLblAvec
        lblSynopsis.Text = LngPopupLblResume
        MystrDe = LngPopupLblDe
        MystrA = LngPopupLblA
        MystrSur = LngPopupLblSur
        cboRecherche.RechercheAvancéeinterneToolStripMenuItem.Text = LngPopupStrRechercheAvancee
        cboRecherche.TVDBinterneToolStripMenuItem.Text = LngPopupStrTVDB
        cboRecherche.lblNomRecherche.Text = LngPopupStrRechercheAvancee
        'changement des largeurs maximum
        CalculeLargeurMaxLabel()
        ResumeLayout()
    End Sub

    Private Sub CalculeLargeurMaxLabel()
        lblInfoRealisateur.MaximumSize = New Size(Largeur - lblRealise.Width, 0)
        lblInfoPresentateur.MaximumSize = New Size(Largeur - lblPresents.Width, 0)
    End Sub

    Public ReadOnly Property Hauteur As Integer
        Get
            Return _memPosition
        End Get
    End Property


    Private _emission As EmissionsList

    Public WriteOnly Property Emission As EmissionsList
        Set(value As EmissionsList)
            _emission = value
            SuspendLayout()
            'LOGO
            Dim logoChaine As String = Nothing
            For i As Integer = 1 To TableauChaine.Count - 1
                If TableauChaine(i).Identificateur.Equals(_emission.ChannelId) Then
                    logoChaine = TableauChaine(i).Logo
                    '_toolTipPictureBox.Load(LogosPath & _logoChaine)
                    Exit For
                End If
            Next

            Dim img As Image = Image.FromFile(LogosPath & logoChaine)
            Dim scale As Double = Math.Min(pbChaine.ClientRectangle.Width / img.Width, pbChaine.ClientRectangle.Height / img.Height)
            Dim imgFinal As Bitmap = New Bitmap(CInt(img.Width * scale), CInt(img.Height * scale), PixelFormat.Format32bppArgb)
            Using g As Graphics = Graphics.FromImage(imgFinal)
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.DrawImage(img, 0, 0, imgFinal.Width, imgFinal.Height)
            End Using
            pbChaine.Image = imgFinal ' Image.FromFile(LogosPath & logoChaine)

            'TITRE
            If String.IsNullOrEmpty(_emission.Psubtitle) Then
                lblTitre.Text = _emission.Ptitle
            Else
                lblTitre.Text = _emission.Ptitle & " ● " & _emission.Psubtitle
            End If
            _titreCourt = _emission.Ptitle

            'CATEGORIE
            Dim category As String = _emission.Pcategory
            Dim categoryTv As String = _emission.PcategoryTv

            If category.StartsWith(categoryTv & ",") Then
                category = category
            Else
                category = PCategoryTv & " - " & category
            End If

            If Not String.IsNullOrEmpty(category) Then
                If category.Chars(category.Count - 1).Equals(","c) Then
                    category = category.Remove(category.Length - 1)
                End If
            End If
            category = UpperFirstChar(category)

            'DATE
            Dim strDate As String
            If LngLanguage = "Français" Then
                strDate = UpperFirstChar(_emission.Pstart.ToString("D", New CultureInfo("fr-FR")))
            Else
                strDate = UpperFirstChar(_emission.Pstart.ToString("D", New CultureInfo("en-US")))
            End If
            ' anglais 

            lblDateEmission.Text = strDate & MystrDe &
                _emission.Pstart.ToString("HH:mm") & MystrA &
                _emission.Pstop.ToString("HH:mm") & MystrSur

            'INFO
            Dim strIfoEm As String = category & " ● " & _emission.Pduration.ToString() & " min"
            If Not String.IsNullOrEmpty(_emission.Prating) Then
                strIfoEm += " ● " & _emission.Prating
            End If
            If Not String.IsNullOrEmpty(_emission.Pdate) Then
                strIfoEm += " ● " & _emission.Pdate
            End If
            lblInfosEmission.Text = strIfoEm

            'SHOWVIEW
            If Not String.IsNullOrEmpty(_emission.Showview) Then
                'lblShowView.Text = "ShowView : " & _emission.Showview
                lblShowView.Text = "VideoPlus+\ShowView : " & _emission.Showview
            Else
                lblShowView.Text = String.Empty
            End If

            'PRESENTATEUR
            lblInfoPresentateur.Text = _emission.PPresentateur
            'REALISATEUR
            lblInfoRealisateur.Text = _emission.Pdirector
            'ACTEUR
            lblInfoActeur.Text = _emission.Pactors
            'RESUME
            lblInfoSynopsis.Text = _emission.Pdescription.Replace(ControlChars.Lf, ControlChars.Lf & ControlChars.Lf)

            MiseEnPlace()
            ResumeLayout()

        End Set
    End Property

    Private Sub MiseEnPlace()
        Const petitEspacement As Integer = 7
        Const grandEspacement As Integer = 12
        Const espacementApresInfo As Integer = 28

        _memPosition = lblTitre.Bottom + petitEspacement
        lblDateEmission.Top = _memPosition
        pbChaine.Top = _memPosition - 5
        lblInfosEmission.Top = _memPosition
        lblInfosEmission.MaximumSize = New Size(Largeur - pbChaine.Right + lblDateEmission.Left, 0)
        pbChaine.Left = lblDateEmission.Right
        lblInfosEmission.Left = pbChaine.Right

        _memPosition = lblInfosEmission.Bottom
        If lblInfoPresentateur.Text.Trim().Length = 0 Then
            lblInfoPresentateur.Hide()
            lblPresents.Hide()
        Else
            lblInfoPresentateur.Show()
            lblPresents.Show()
            _memPosition += grandEspacement
            lblInfoPresentateur.Top = _memPosition
            lblPresents.Top = _memPosition
            lblInfoPresentateur.Left = lblPresents.Right
            _memPosition += lblInfoPresentateur.Height
        End If

        If lblInfoRealisateur.Text.Trim().Length = 0 Then
            lblInfoRealisateur.Hide()
            lblRealise.Hide()
        Else
            lblInfoRealisateur.Show()
            lblRealise.Show()
            _memPosition += grandEspacement
            lblInfoRealisateur.Top = _memPosition
            lblRealise.Top = _memPosition
            lblInfoRealisateur.Left = lblRealise.Right
            _memPosition += lblInfoRealisateur.Height
        End If

        If lblInfoActeur.Text.Trim.Length = 0 Then
            lblInfoActeur.Hide()
            lblAvec.Hide()
        Else
            lblInfoActeur.Show()
            lblAvec.Show()
            _memPosition += grandEspacement
            lblAvec.Top = _memPosition
            _memPosition += petitEspacement + lblAvec.Height
            lblInfoActeur.Top = _memPosition
            _memPosition += lblInfoActeur.Height
        End If

        If lblInfoSynopsis.Text.Trim.Length = 0 Then
            lblSynopsis.Hide()
            lblInfoSynopsis.Hide()
        Else
            lblSynopsis.Show()
            lblInfoSynopsis.Show()
            _memPosition += grandEspacement
            lblSynopsis.Top = _memPosition
            _memPosition += petitEspacement + lblSynopsis.Height
            lblInfoSynopsis.Top = _memPosition
            _memPosition += lblInfoSynopsis.Height
        End If
        _memPosition = _memPosition + espacementApresInfo
        cboRecherche.Top = _memPosition
        lblShowView.Top = _memPosition
        btImprimer.Top = _memPosition
        _memPosition += cboRecherche.Height + petitEspacement
        Height = _memPosition
        pnlBorder.Height = _memPosition
    End Sub

    Private Function UpperFirstChar(str As String) As String
        If String.IsNullOrEmpty(str) Then
            Return String.Empty
        Else
            Dim a As Char() = str.ToCharArray()
            a(0) = Char.ToUpper(a(0))
            Return New String(a)
        End If
    End Function

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        CType(Parent, Popup).Close()
    End Sub

    Private Sub pbClose_MouseHover(sender As Object, e As EventArgs) Handles pbClose.MouseHover

        pbClose.Image = My.Resources.redcross
    End Sub

    Private Sub pbClose_MouseLeave(sender As Object, e As EventArgs) Handles pbClose.MouseLeave

        pbClose.Image = My.Resources.whitecross
    End Sub

    Private Sub btImprimer_Click(sender As Object, e As EventArgs) Handles btImprimer.Click
        Dim imprim As New ImprimeEmissions("INFOS EMISSION", (_emission))
        imprim.VoirPrevisualisation()
    End Sub

    Private Sub btImprimer_MouseHover(sender As Object, e As EventArgs) Handles btImprimer.MouseHover

        btImprimer.BackColor = ColorTranslator.FromHtml("#C2E0FF")
        btImprimer.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3399FF")
        btImprimer.FlatAppearance.BorderSize = 1
    End Sub

    Private Sub btImprimer_MouseLeave(sender As Object, e As EventArgs) Handles btImprimer.MouseLeave

        btImprimer.BackColor = Color.FromArgb(255, 255, 255, 255)
        btImprimer.FlatAppearance.BorderSize = 0
    End Sub

End Class
