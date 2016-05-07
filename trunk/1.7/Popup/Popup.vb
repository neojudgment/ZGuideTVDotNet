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

Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Drawing


<CLSCompliant(True), ToolboxItem(False)>
Partial Public Class Popup
    Inherits ToolStripDropDown
#Region " Fields & Properties "

    ''' <summary>
    ''' Gets the content of the pop-up.
    ''' </summary>
    Public Property Content() As Control

    ''' <summary>
    ''' Determines which animation to use while showing the pop-up window.
    ''' </summary>
    Public Property ShowingAnimation() As PopupAnimations

    ''' <summary>
    ''' Determines which animation to use while hiding the pop-up window.
    ''' </summary>
    Public Property HidingAnimation() As PopupAnimations

    ''' <summary>
    ''' Determines the duration of the animation.
    ''' </summary>
    Public Property AnimationDuration() As Integer

    ''' <summary>
    ''' Gets or sets a value indicating whether the content should receive the focus after the pop-up has been opened.
    ''' </summary>
    ''' <value><c>true</c> if the content should be focused after the pop-up has been opened; otherwise, <c>false</c>.</value>
    ''' <remarks>If the FocusOnOpen property is set to <c>false</c>, then pop-up cannot use the fade effect.</remarks>
    Public Property FocusOnOpen() As Boolean

    ''' <summary>
    ''' Gets or sets a value indicating whether pressing the alt key should close the pop-up.
    ''' </summary>
    ''' <value><c>true</c> if pressing the alt key does not close the pop-up; otherwise, <c>false</c>.</value>
    Public Property AcceptAlt() As Boolean
    Private ReadOnly _host As ToolStripControlHost

    Private _nonInteractive As Boolean
    Public Property NonInteractive() As Boolean
        Get
            Return _nonInteractive
        End Get
        Set(value As Boolean)
            If value <> _nonInteractive Then
                _nonInteractive = value
                If IsHandleCreated Then
                    RecreateHandle()
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a minimum size of the pop-up.
    ''' </summary>
    ''' <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
    Private Shadows Property MinimumSize() As Size

    ''' <summary>
    ''' Gets or sets a maximum size of the pop-up.
    ''' </summary>
    ''' <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
    Private Shadows Property MaximumSize() As Size

    ''' <summary>
    ''' Gets parameters of a new window.
    ''' </summary>
    ''' <returns>An object of type <see cref="T:System.Windows.Forms.CreateParams" /> used when creating a new window.</returns>
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        <SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or NativeMethods.WS_EX_NOACTIVATE
            If NonInteractive Then
                cp.ExStyle = cp.ExStyle Or NativeMethods.WS_EX_TRANSPARENT Or NativeMethods.WS_EX_LAYERED Or NativeMethods.WS_EX_TOOLWINDOW
            End If
            Return cp
        End Get
    End Property

#End Region

#Region " Constructors "
    Public Sub New(ncontent As Control)
        If ncontent Is Nothing Then
            Throw New ArgumentNullException("_content")
        End If
        AutoClose = True
        Content = ncontent
        FocusOnOpen = True
        AcceptAlt = True
        ShowingAnimation = PopupAnimations.Blend
        HidingAnimation = PopupAnimations.None
        AnimationDuration = 250
        InitializeComponent()
        AutoSize = False
        DoubleBuffered = True
        ResizeRedraw = True
        _host = New ToolStripControlHost(ncontent)
        Padding = Padding.Empty
        Margin = Padding.Empty
        _host.Padding = Padding.Empty
        _host.Margin = Padding.Empty
        MinimumSize = ncontent.MinimumSize
        Content.MinimumSize = ncontent.Size
        MaximumSize = ncontent.MaximumSize
        Content.MaximumSize = ncontent.Size
        Size = ncontent.Size
        TabStop = ncontent.TabStop = True
        ncontent.Location = Point.Empty
        Items.Add(_host)

        AddHandler ncontent.Disposed, Sub(sender, e)
                                          Content = Nothing
                                          Dispose(True)
                                      End Sub

        AddHandler ncontent.RegionChanged, Sub(sender, e)
                                               UpdateRegion()
                                           End Sub

    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If (Visible AndAlso ShowingAnimation = PopupAnimations.None) OrElse (Not Visible AndAlso HidingAnimation = PopupAnimations.None) Then
            Return
        End If
        Dim flags As NativeMethods.AnimationFlags = If(Visible, NativeMethods.AnimationFlags.Roll, NativeMethods.AnimationFlags.Hide)
        Dim _flags As PopupAnimations = If(Visible, ShowingAnimation, HidingAnimation)
        flags = flags Or (NativeMethods.AnimationFlags.Mask And CType(_flags, NativeMethods.AnimationFlags))
        NativeMethods.SetTopMost(Me)
        NativeMethods.AnimateWindow(Me, AnimationDuration, flags)
    End Sub


#End Region

#Region " Methods "

    ''' <summary>
    ''' Processes a dialog box key.
    ''' </summary>
    ''' <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
    ''' <returns>
    ''' true if the key was processed by the control; otherwise, false.
    ''' </returns>
    <UIPermission(SecurityAction.LinkDemand, Window:=UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        If AcceptAlt AndAlso ((keyData And Keys.Alt) = Keys.Alt) Then
            If (keyData And Keys.F4) <> Keys.F4 Then
                Return False
            Else
                Close()
            End If
        End If
        Dim processed As Boolean = MyBase.ProcessDialogKey(keyData)
        If Not processed AndAlso (keyData = Keys.Tab OrElse keyData = (Keys.Tab Or Keys.Shift)) Then
            Dim backward As Boolean = (keyData And Keys.Shift) = Keys.Shift
            Content.SelectNextControl(Nothing, Not backward, True, True, True)
        End If
        Return processed
    End Function

    ''' <summary>
    ''' Updates the pop-up region.
    ''' </summary>
    Protected Sub UpdateRegion()
        If Not Region Is Nothing Then
            Region.Dispose()
            Region = Nothing
        End If
        If Not Content.Region Is Nothing Then
            Region = Content.Region.Clone()
        End If
    End Sub

    ''' <summary>
    ''' Shows the pop-up window below the specified control.
    ''' </summary>
    ''' <param name="control">The control below which the pop-up will be shown.</param>
    ''' <remarks>
    ''' When there is no space below the specified control, the pop-up control is shown above it.
    ''' </remarks>
    ''' <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
    Public Overloads Sub Show(control As Control)
        If control Is Nothing Then
            Throw New ArgumentNullException("control")
        End If
        Show(control, control.ClientRectangle)
    End Sub

    ''' <summary>
    ''' Shows the pop-up window below the specified area of the specified control.
    ''' </summary>
    ''' <param name="control">The control used to compute screen location of specified area.</param>
    ''' <param name="area">The area of control below which the pop-up will be shown.</param>
    ''' <remarks>
    ''' When there is no space below specified area, the pop-up control is shown above it.
    ''' </remarks>
    ''' <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
    Public Overloads Sub Show(control As Control, area As Rectangle)
        If control Is Nothing Then
            Throw New ArgumentNullException("control")
        End If

        Dim nlocation As Point = control.PointToScreen(New Point(area.Left, area.Top + area.Height))
        Dim screen1 As Rectangle = control.FindForm().Bounds
        'screen1 = FromControl(control).WorkingArea
        If nlocation.X + Size.Width > (screen1.Width + screen1.Left) Then
            nlocation.X = (screen1.Width + screen1.Left) - Size.Width
        End If

        If nlocation.Y + Size.Height > (screen1.Top + screen1.Height) Then
            nlocation.Y -= Size.Height + area.Height
        End If

        nlocation = control.PointToClient(nlocation)
        Show(control, nlocation, ToolStripDropDownDirection.BelowRight)
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
    ''' </summary>
    ''' <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        If Not Content Is Nothing Then
            Content.MinimumSize = Size
            Content.MaximumSize = Size
            Content.Size = Size
            Content.Location = Point.Empty
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Opening" /> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
    Protected Overrides Sub OnOpening(e As CancelEventArgs)
        If Content.IsDisposed OrElse Content.Disposing Then
            e.Cancel = True
            Return
        End If
        UpdateRegion()
        MyBase.OnOpening(e)
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Opened" /> event.
    ''' </summary>
    ''' <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    Protected Overrides Sub OnOpened(e As EventArgs)
        If FocusOnOpen Then
            Content.Focus()
        End If
        MyBase.OnOpened(e)
    End Sub

#End Region

End Class

