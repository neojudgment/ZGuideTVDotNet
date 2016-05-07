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
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Namespace ZGuideTVDotNetRender
    Public Class Render
        Inherits ToolStripProfessionalRenderer

        Public Sub New()
            _tsManager = New IToolstrip()
            _btnManager = New IButton()
            _dBtnManager = New IDropDownButton()
            _tsCtrlManager = New IToolstripControls()
            _pManager = New IPanel()
            _sBtnManager = New ISplitButton()
            _sBarManager = New IStatusBar()
            _mnuManager = New IMenustrip()
        End Sub

        Private ReadOnly _btnManager As IButton
        Private ReadOnly _dBtnManager As IDropDownButton
        Private ReadOnly _mnuManager As IMenustrip
        Private ReadOnly _pManager As IPanel
        Private ReadOnly _sBarManager As IStatusBar
        Private ReadOnly _sBtnManager As ISplitButton
        Private ReadOnly _tsCtrlManager As IToolstripControls
        Private ReadOnly _tsManager As IToolstrip
        Private _overrideColor As Color = Color.FromArgb(47, 92, 150)
        Private _overrideText As [Boolean] = True
        Private _smoothText As [Boolean] = True

        <[ReadOnly](True)> _
        Public ReadOnly Property Toolstrip() As IToolstrip
            Get
                Return _tsManager
            End Get
        End Property

        <[ReadOnly](True)> _
        Public ReadOnly Property ToolstripButton() As IButton
            Get
                Return _btnManager
            End Get
        End Property

        <[ReadOnly](True)> _
        Public ReadOnly Property ToolstripControls() As IToolstripControls
            Get
                Return _tsCtrlManager
            End Get
        End Property

        <[ReadOnly](True)> _
        Public ReadOnly Property Panels() As IPanel
            Get
                Return _pManager
            End Get
        End Property

        <[ReadOnly](True)> _
        Public ReadOnly Property SplitButton() As ISplitButton
            Get
                Return _sBtnManager
            End Get
        End Property

        <[ReadOnly](True)> _
        Public ReadOnly Property StatusBar() As IStatusBar
            Get
                Return _sBarManager
            End Get
        End Property

        Public Property SmoothText() As [Boolean]
            Get
                Return _smoothText
            End Get
            Set(ByVal value As [Boolean])
                _smoothText = value
            End Set
        End Property

        Public Property OverrideColor() As Color
            Get
                Return _overrideColor
            End Get
            Set(ByVal value As Color)
                _overrideColor = value
            End Set
        End Property

        Public Property AlterColor() As [Boolean]
            Get
                Return _overrideText
            End Get
            Set(ByVal value As [Boolean])
                _overrideText = value
            End Set
        End Property

        '
        '		/// <summary>
        '		/// Gets a brush dependent on the dock style of a panel
        '		/// </summary>
        '		/// <param name="Panel">The panel which is docked</param>
        '		/// <returns></returns>
        '		private Brush CreatePanelBrush(ToolStripPanel Panel)
        '		{
        '			switch (Panel.Dock)
        '			{
        '				case DockStyle.Top: return new SolidBrush(ContentPanelTop);
        '				case DockStyle.Bottom: return new SolidBrush(ContentPanelBottom);
        '				case DockStyle.Left:
        '				case DockStyle.Right:
        '					return new LinearGradientBrush(Panel.ClientRectangle, ContentPanelTop, ContentPanelBottom, 90f);
        '			}
        '
        '			return null;
        '		}
        '		 
        ''' <summary>
        ''' Creates a GraphicsPath that appreciates an area where things can be drawn
        ''' </summary>
        ''' <param name="Area">The rectangular area which will serve as the base</param>
        ''' <param name="Curve">The curve amount of the corners</param>
        ''' <returns></returns>
        ''' 
        Private Function CreateDrawingPath(ByVal Area As Rectangle, ByVal Curve As Single) As GraphicsPath
            Dim Result As GraphicsPath = New GraphicsPath()

            Result.AddLine(Area.Left + Curve, Area.Top, Area.Right - Curve, Area.Top)
            ' •—————•
            ' | Top |
            ' •—————•
            Result.AddLine(Area.Right - Curve, Area.Top, Area.Right, Area.Top + Curve)
            ' •———————————•
            ' | Top-right |
            ' •———————————•
            Result.AddLine(Area.Right, Area.Top + Curve, Area.Right, Area.Bottom - Curve)
            ' •———————•
            ' | Right |
            ' •———————•
            Result.AddLine(Area.Right, Area.Bottom - Curve, Area.Right - Curve, Area.Bottom)
            ' •——————————————•
            ' | Bottom-right |
            ' •——————————————•
            Result.AddLine(Area.Right - Curve, Area.Bottom, Area.Left + Curve, Area.Bottom)
            ' •————————•
            ' | Bottom |
            ' •————————•
            Result.AddLine(Area.Left + Curve, Area.Bottom, Area.Left, Area.Bottom - Curve)
            ' •—————————————•
            ' | Bottom-left |
            ' •—————————————•
            Result.AddLine(Area.Left, Area.Bottom - Curve, Area.Left, Area.Top + Curve)
            ' •——————•
            ' | Left |
            ' •——————•
            Result.AddLine(Area.Left, Area.Top + Curve, Area.Left + Curve, Area.Top)
            ' •——————————•
            ' | Top-left |
            ' •——————————•
            Return Result
        End Function

        Private Function CreateTrianglePath(ByVal Bounds As Rectangle, ByVal Size As Int32, _
                                             ByVal Direction As ArrowDirection) As GraphicsPath
            Dim Result As GraphicsPath = New GraphicsPath()
            Dim x As Integer, y As Integer, c As Integer, j As Integer

            If Direction = ArrowDirection.Left OrElse Direction = ArrowDirection.Right Then
                x = CInt(Bounds.Right - (Bounds.Width - Size) / 2)
                y = CInt(Bounds.Y + Bounds.Height / 2)
                c = Size
                j = 0
            Else
                x = CInt(Bounds.X + Bounds.Width / 2)
                y = CInt(Bounds.Bottom - ((Bounds.Height - (Size - 1)) / 2))
                c = Size - 1
                j = Size - 2
            End If

            Select Case Direction
                Case ArrowDirection.Right
                    Result.AddLine(x, y, x - c, y - c)
                    Result.AddLine(x - c, y - c, x - c, y + c)
                    Result.AddLine(x - c, y + c, x, y)
                    Exit Select
                Case ArrowDirection.Down
                    Result.AddLine(x + j, y - j, x - j, y - j)
                    Result.AddLine(x - j, y - j, x, y)
                    Result.AddLine(x, y, x + j, y - j)
                    Exit Select
                Case ArrowDirection.Left
                    Result.AddLine(x - c, y, x, y - c)
                    Result.AddLine(x, y - c, x, y + c)
                    Result.AddLine(x, y + c, x - c, y)
                    Exit Select
            End Select

            Return Result
        End Function

        Private Function GetButtonBackColor(ByVal Item As ToolStripButton, ByVal Type As ButtonType) As Color()
            Dim [Return] As Color() = New Color(1) {}

            If (Not Item.Selected) AndAlso (Not Item.Pressed AndAlso Not Item.Checked) Then
                [Return](0) = Color.Transparent
                [Return](1) = Color.Transparent
            ElseIf (Item.Selected) AndAlso (Not Item.Pressed AndAlso Not Item.Checked) Then
                [Return](0) = _btnManager.HoverBackgroundTop
                [Return](1) = _btnManager.HoverBackgroundBottom
            Else
                [Return](0) = _btnManager.ClickBackgroundTop
                [Return](1) = _btnManager.ClickBackgroundBottom
            End If

            Return [Return]
        End Function

        Private Function GetButtonBackColor(ByVal Item As ToolStripSplitButton, ByVal Type As ButtonType) As Color()
            Dim [Return] As Color() = New Color(1) {}

            If (Not Item.Selected) AndAlso (Not Item.ButtonPressed AndAlso Not Item.DropDownButtonPressed) Then
                [Return](0) = Color.Transparent
                [Return](1) = Color.Transparent
            ElseIf (Item.Selected) AndAlso (Not Item.ButtonPressed AndAlso Not Item.DropDownButtonPressed) Then
                [Return](0) = _sBtnManager.HoverBackgroundTop
                [Return](1) = _sBtnManager.HoverBackgroundBottom
            Else
                If Item.ButtonPressed Then
                    [Return](0) = _sBtnManager.ClickBackgroundTop
                    [Return](1) = _sBtnManager.ClickBackgroundBottom
                ElseIf Item.DropDownButtonPressed Then
                    [Return](0) = _mnuManager.MenustripButtonBackground
                    [Return](1) = _mnuManager.MenustripButtonBackground
                End If
            End If

            Return [Return]
        End Function

        Private Function GetButtonBackColor(ByVal Item As ToolStripMenuItem, ByVal Type As ButtonType) As Color()
            Dim [Return] As Color() = New Color(1) {}

            If (Not Item.Selected) AndAlso (Not Item.Pressed AndAlso Not Item.Checked) Then
                [Return](0) = Color.Transparent
                [Return](1) = Color.Transparent
            ElseIf (Item.Selected OrElse Item.Pressed) AndAlso (Not Item.Checked) Then
                If Item.Pressed AndAlso Item.OwnerItem Is Nothing Then
                    [Return](0) = _mnuManager.MenustripButtonBackground
                    [Return](1) = _mnuManager.MenustripButtonBackground
                Else
                    [Return](0) = _mnuManager.Items.HoverBackgroundTop
                    [Return](1) = _mnuManager.Items.HoverBackgroundBottom
                End If
            Else
                [Return](0) = _mnuManager.Items.ClickBackgroundTop
                [Return](1) = _mnuManager.Items.ClickBackgroundBottom
            End If

            Return [Return]
        End Function

        Private Function GetButtonBackColor(ByVal Item As ToolStripDropDownButton, ByVal Type As ButtonType) As Color()
            Dim [Return] As Color() = New Color(1) {}

            If (Not Item.Selected) AndAlso (Not Item.Pressed) Then
                [Return](0) = Color.Transparent
                [Return](1) = Color.Transparent
            ElseIf (Item.Selected) AndAlso (Not Item.Pressed) Then
                [Return](0) = _dBtnManager.HoverBackgroundTop
                [Return](1) = _dBtnManager.HoverBackgroundBottom
            Else
                [Return](0) = _mnuManager.MenustripButtonBackground
                [Return](1) = _mnuManager.MenustripButtonBackground
            End If

            Return [Return]
        End Function

        Private Function GetBlend(ByVal TSItem As ToolStripItem, ByVal Type As ButtonType) As Blend
            Dim BackBlend As Blend = Nothing

            If Type = ButtonType.NormalButton Then
                Dim Item As ToolStripButton = DirectCast(TSItem, ToolStripButton)

                If _
                    Item.Selected AndAlso (Not Item.Checked AndAlso Not Item.Pressed) AndAlso _
                    (_btnManager.BlendOptions And BlendRender.Hover) = BlendRender.Hover Then
                    BackBlend = _btnManager.BackgroundBlend
                ElseIf _
                    Item.Pressed AndAlso (Not Item.Checked) AndAlso _
                    (_btnManager.BlendOptions And BlendRender.Click) = BlendRender.Click Then
                    BackBlend = _btnManager.BackgroundBlend
                ElseIf Item.Checked AndAlso (_btnManager.BlendOptions And BlendRender.Check) = BlendRender.Check Then
                    BackBlend = _btnManager.BackgroundBlend
                End If
            End If
            If Type = ButtonType.DropDownButton Then
                Dim Item As ToolStripDropDownButton = DirectCast(TSItem, ToolStripDropDownButton)

                If _
                    Item.Selected AndAlso (Not Item.Pressed) AndAlso _
                    (_btnManager.BlendOptions And BlendRender.Hover) = BlendRender.Hover Then
                    BackBlend = _btnManager.BackgroundBlend
                End If
            ElseIf Type = ButtonType.MenuItem Then
                Dim Item As ToolStripMenuItem = DirectCast(TSItem, ToolStripMenuItem)

                If _
                    Item.Selected AndAlso (Not Item.Checked AndAlso Not Item.Pressed) AndAlso _
                    (_btnManager.BlendOptions And BlendRender.Hover) = BlendRender.Hover Then
                    BackBlend = _mnuManager.Items.BackgroundBlend
                ElseIf _
                    Item.Pressed AndAlso (Not Item.Checked) AndAlso _
                    (_btnManager.BlendOptions And BlendRender.Click) = BlendRender.Click Then
                    BackBlend = _mnuManager.Items.BackgroundBlend
                ElseIf Item.Checked AndAlso (_btnManager.BlendOptions And BlendRender.Check) = BlendRender.Check Then
                    BackBlend = _mnuManager.Items.BackgroundBlend
                End If
            ElseIf Type = ButtonType.SplitButton Then
                Dim Item As ToolStripSplitButton = DirectCast(TSItem, ToolStripSplitButton)

                If _
                    Item.Selected AndAlso (Not Item.ButtonPressed AndAlso Not Item.DropDownButtonPressed) AndAlso _
                    (_sBtnManager.BlendOptions And BlendRender.Hover) = BlendRender.Hover Then
                    BackBlend = _sBtnManager.BackgroundBlend
                ElseIf _
                    Item.ButtonPressed AndAlso (Not Item.DropDownButtonPressed) AndAlso _
                    (_sBtnManager.BlendOptions And BlendRender.Click) = BlendRender.Click Then
                    BackBlend = _sBtnManager.BackgroundBlend
                End If
            End If

            Return BackBlend
        End Function

        Public Sub PaintBackground(ByVal Link As Graphics, ByVal Boundary As Rectangle, ByVal Brush As Brush)
            Link.FillRectangle(Brush, Boundary)
        End Sub

        Public Sub PaintBackground(ByVal Link As Graphics, ByVal Boundary As Rectangle, ByVal Top As Color, _
                                    ByVal Bottom As Color)
            PaintBackground(Link, Boundary, Top, Bottom, 90.0F, Nothing)
        End Sub

        Public Sub PaintBackground(ByVal Link As Graphics, ByVal Boundary As Rectangle, ByVal Top As Color, _
                                    ByVal Bottom As Color, ByVal Angle As Single)
            PaintBackground(Link, Boundary, Top, Bottom, Angle, Nothing)
        End Sub

        Public Sub PaintBackground(ByVal Link As Graphics, ByVal Boundary As Rectangle, ByVal Top As Color, _
                                    ByVal Bottom As Color, ByVal Angle As Single, ByVal Blend As Blend)
            If Angle = Nothing Then
                Angle = 90.0F
            End If

            Using Fill As LinearGradientBrush = New LinearGradientBrush(Boundary, Top, Bottom, Angle)
                If Blend IsNot Nothing Then
                    Fill.Blend = Blend
                End If

                Link.FillRectangle(CType(Fill, Brush), Boundary)
                Fill.Dispose()
            End Using
        End Sub

        Public Sub PaintBorder(ByVal Link As Graphics, ByVal Path As GraphicsPath, ByVal Brush As Brush)
            Link.DrawPath(New Pen(Brush), Path)
        End Sub

        Public Sub PaintBorder(ByVal Link As Graphics, ByVal Path As GraphicsPath, ByVal Area As Rectangle, _
                                ByVal Top As Color, ByVal Bottom As Color)
            PaintBorder(Link, Path, Area, Top, Bottom, 90.0F, _
                         Nothing)
        End Sub

        Public Sub PaintBorder(ByVal Link As Graphics, ByVal Path As GraphicsPath, ByVal Area As Rectangle, _
                                ByVal Top As Color, ByVal Bottom As Color, ByVal Angle As Single)
            PaintBorder(Link, Path, Area, Top, Bottom, Angle, _
                         Nothing)
        End Sub

        Public Sub PaintBorder(ByVal Link As Graphics, ByVal Path As GraphicsPath, ByVal Area As Rectangle, _
                                ByVal Top As Color, ByVal Bottom As Color, ByVal Angle As Single, _
                                ByVal Blend As Blend)
            If Angle = Nothing Then
                Angle = 90.0F
            End If

            Using Fill As LinearGradientBrush = New LinearGradientBrush(Area, Top, Bottom, Angle)
                If Blend IsNot Nothing Then
                    Fill.Blend = Blend
                End If

                Link.DrawPath(New Pen(Fill), Path)
                Fill.Dispose()
            End Using
        End Sub

        Public Sub IDrawToolstripButton(ByVal Item As ToolStripButton, ByVal Link As Graphics, _
                                         ByVal Parent As ToolStrip)
            Dim _
                Area As Rectangle = _
                    New Rectangle(New Point(0, 0), New Size(Item.Bounds.Size.Width - 1, Item.Bounds.Size.Height - 1))

            Dim BackBlend As Blend = GetBlend(Item, ButtonType.NormalButton)
            Dim Render As Color() = GetButtonBackColor(Item, ButtonType.NormalButton)

            Using Path As GraphicsPath = CreateDrawingPath(Area, _btnManager.Curve)
                Link.SetClip(Path)

                PaintBackground(Link, Area, Render(0), Render(1), _btnManager.BackgroundAngle, BackBlend)

                Link.ResetClip()

                Link.SmoothingMode = SmoothingMode.AntiAlias

                Using OBPath As GraphicsPath = CreateDrawingPath(Area, _btnManager.Curve)
                    PaintBorder(Link, OBPath, Area, _btnManager.BorderTop, _btnManager.BorderBottom, _
                                 _btnManager.BorderAngle, _
                                 _btnManager.BorderBlend)

                    OBPath.Dispose()
                End Using

                Area.Inflate(-1, -1)

                Using IBPath As GraphicsPath = CreateDrawingPath(Area, _btnManager.Curve)
                    Using InnerBorder As SolidBrush = New SolidBrush(_btnManager.InnerBorder)
                        PaintBorder(Link, IBPath, CType(InnerBorder, Brush))

                        InnerBorder.Dispose()
                    End Using
                End Using

                Link.SmoothingMode = SmoothingMode.[Default]
            End Using
        End Sub

        Public Sub IDrawDropDownButton(ByVal Item As ToolStripDropDownButton, ByVal Link As Graphics, _
                                        ByVal Parent As ToolStrip)
            Dim _
                Area As Rectangle = _
                    New Rectangle(New Point(0, 0), New Size(Item.Bounds.Size.Width - 1, Item.Bounds.Size.Height - 1))

            Dim BackBlend As Blend = GetBlend(Item, ButtonType.DropDownButton)
            Dim Render As Color() = GetButtonBackColor(Item, ButtonType.DropDownButton)

            Using Path As GraphicsPath = CreateDrawingPath(Area, _btnManager.Curve)
                Link.SetClip(Path)

                PaintBackground(Link, Area, Render(0), Render(1), _btnManager.BackgroundAngle, BackBlend)

                Link.ResetClip()

                Link.SmoothingMode = SmoothingMode.AntiAlias

                Using OBPath As GraphicsPath = CreateDrawingPath(Area, _btnManager.Curve)
                    PaintBorder(Link, OBPath, Area, _btnManager.BorderTop, _btnManager.BorderBottom, _
                                 _btnManager.BorderAngle, _
                                 _btnManager.BorderBlend)

                    OBPath.Dispose()
                End Using

                If Not Item.Pressed Then
                    Area.Inflate(-1, -1)

                    Using IBPath As GraphicsPath = CreateDrawingPath(Area, _dBtnManager.Curve)
                        Using InnerBorder As SolidBrush = New SolidBrush(_dBtnManager.InnerBorder)
                            PaintBorder(Link, IBPath, CType(InnerBorder, Brush))

                            InnerBorder.Dispose()
                        End Using
                    End Using
                End If

                Link.SmoothingMode = SmoothingMode.[Default]
            End Using
        End Sub

        Public Sub IDrawToolstripBackground(ByVal Item As ToolStrip, ByVal Link As Graphics, ByVal Bounds As Rectangle)
            Dim Area As Rectangle = New Rectangle(0, 0, Bounds.Width - 1, Bounds.Height - 1)

            Link.SmoothingMode = SmoothingMode.None

            Using Path As GraphicsPath = CreateDrawingPath(CType(Area, Rectangle), _tsManager.Curve)
                Link.SetClip(Path)

                PaintBackground(Link, CType(Area, Rectangle), _tsManager.BackgroundTop, _tsManager.BackgroundBottom, _
                                 _tsManager.BackgroundAngle, _tsManager.BackgroundBlend)

                Link.ResetClip()

                Path.Dispose()
            End Using
        End Sub

        Public Sub IDrawToolstripSplitButton(ByVal Item As ToolStripSplitButton, ByVal Link As Graphics, _
                                              ByVal Parent As ToolStrip)
            If Item.Selected OrElse Item.DropDownButtonPressed OrElse Item.ButtonPressed Then
                Dim _
                    Area As Rectangle = _
                        New Rectangle(New Point(0, 0), _
                                       New Size(Item.Bounds.Size.Width - 1, Item.Bounds.Size.Height - 1))

                Dim BackBlend As Blend = GetBlend(Item, ButtonType.SplitButton)
                Dim NormalRender() As Color = {_sBtnManager.HoverBackgroundTop, _sBtnManager.HoverBackgroundBottom}
                Dim Render As Color() = GetButtonBackColor(Item, ButtonType.SplitButton)

                Using Path As GraphicsPath = CreateDrawingPath(Area, _sBtnManager.Curve)
                    Link.SetClip(Path)

                    If Not Item.DropDownButtonPressed Then
                        PaintBackground(Link, Area, NormalRender(0), NormalRender(1), _sBtnManager.BackgroundAngle, _
                                         BackBlend)
                    Else
                        PaintBackground(Link, Area, Render(0), Render(1))
                    End If

                    If Item.ButtonPressed Then
                        Dim _
                            ButtonArea As Rectangle = _
                                New Rectangle(New Point(0, 0), _
                                               New Size(Item.ButtonBounds.Width, Item.ButtonBounds.Height - 1))

                        PaintBackground(Link, ButtonArea, Render(0), Render(1), _sBtnManager.BackgroundAngle, _
                                         _sBtnManager.BackgroundBlend)
                    End If

                    Link.ResetClip()

                    Link.SmoothingMode = SmoothingMode.AntiAlias

                    Using OBPath As GraphicsPath = CreateDrawingPath(Area, _sBtnManager.Curve)
                        Dim _
                            TopColor As Color = _
                                (If _
                                (Item.DropDownButtonPressed, _mnuManager.MenustripButtonBorder, _sBtnManager.BorderTop))
                        Dim _
                            BottomColor As Color = _
                                (If _
                                (Item.DropDownButtonPressed, _mnuManager.MenustripButtonBorder, _
                                 _sBtnManager.BorderBottom))

                        PaintBorder(Link, OBPath, Area, TopColor, BottomColor, _sBtnManager.BorderAngle, _
                                     _sBtnManager.BorderBlend)

                        OBPath.Dispose()
                    End Using

                    If Not Item.DropDownButtonPressed Then
                        Area.Inflate(-1, -1)

                        Using IBPath As GraphicsPath = CreateDrawingPath(Area, _sBtnManager.Curve)
                            Using InnerBorder As SolidBrush = New SolidBrush(_sBtnManager.InnerBorder)
                                PaintBorder(Link, IBPath, CType(InnerBorder, Brush))


                                Link.DrawRectangle(New Pen(_sBtnManager.InnerBorder), _
                                                    New Rectangle(Item.ButtonBounds.Width, 1, 2, _
                                                                   Item.ButtonBounds.Height - 3))

                                InnerBorder.Dispose()
                            End Using
                        End Using

                        Using _
                            SplitLine As LinearGradientBrush = _
                                New LinearGradientBrush(New Rectangle(0, 0, 1, Item.Height), _sBtnManager.BorderTop, _
                                                         _sBtnManager.BorderBottom, _sBtnManager.BackgroundAngle)
                            If _sBtnManager.BackgroundBlend IsNot Nothing Then
                                SplitLine.Blend = _sBtnManager.BackgroundBlend
                            End If

                            Link.DrawLine(New Pen(SplitLine), Item.ButtonBounds.Width + 1, 0, _
                                           Item.ButtonBounds.Width + 1, Item.Height - 1)

                            SplitLine.Dispose()
                        End Using
                    End If

                    Link.SmoothingMode = SmoothingMode.[Default]
                End Using
            End If

            Dim ArrowSize As Int32 = 5

            If _
                (_sBtnManager.ArrowDisplay = ArrowDisplay.Always) OrElse _
                (_sBtnManager.ArrowDisplay = ArrowDisplay.Hover AndAlso Item.Selected) Then
                Using _
                    TrianglePath As GraphicsPath = _
                        CreateTrianglePath( _
                                            New Rectangle(CInt(Item.DropDownButtonBounds.Left + (ArrowSize / 2) - 1), _
                                                           CInt( _
                                                              (Item.DropDownButtonBounds.Height / 2) - (ArrowSize / 2) - 3), _
                                                           ArrowSize * 2, ArrowSize * 2), ArrowSize, ArrowDirection.Down)
                    Link.FillPath(New SolidBrush(_sBtnManager.ArrowColor), TrianglePath)

                    TrianglePath.Dispose()
                End Using
            End If
        End Sub

        Public Sub IDrawStatusbarBackground(ByVal Item As StatusStrip, ByVal Link As Graphics, _
                                             ByVal Bounds As Rectangle)
            PaintBackground(Link, Bounds, _sBarManager.BackgroundTop, _sBarManager.BackgroundBottom, _
                             _sBarManager.BackgroundAngle, _sBarManager.BackgroundBlend)

            Link.DrawLine(New Pen(_sBarManager.DarkBorder), 0, 0, Bounds.Width, 0)

            Link.DrawLine(New Pen(_sBarManager.LightBorder), 0, 1, Bounds.Width, 1)
        End Sub

        Public Sub IDrawMenustripItem(ByVal Item As ToolStripMenuItem, ByVal Link As Graphics, _
                                       ByVal Parent As ToolStrip)
            Dim _
                Area As Rectangle = _
                    New Rectangle(New Point(0, 0), New Size(Item.Bounds.Size.Width - 1, Item.Bounds.Size.Height - 1))

            If Item.OwnerItem IsNot Nothing Then
                Area.X += 2
                Area.Width -= 3
            End If

            Dim BackBlend As Blend = GetBlend(Item, ButtonType.MenuItem)
            Dim Render As Color() = GetButtonBackColor(Item, ButtonType.MenuItem)

            Using Path As GraphicsPath = CreateDrawingPath(Area, _btnManager.Curve)
                Link.SetClip(Path)

                PaintBackground(Link, Area, Render(0), Render(1), _btnManager.BackgroundAngle, BackBlend)

                Link.ResetClip()

                Link.SmoothingMode = SmoothingMode.AntiAlias

                Using OBPath As GraphicsPath = CreateDrawingPath(Area, _btnManager.Curve)
                    PaintBorder(Link, OBPath, Area, _mnuManager.MenustripButtonBorder, _
                                 _mnuManager.MenustripButtonBorder, _btnManager.BorderAngle, _
                                 _btnManager.BorderBlend)

                    OBPath.Dispose()
                End Using

                If Not Item.Pressed Then
                    Area.Inflate(-1, -1)

                    Using IBPath As GraphicsPath = CreateDrawingPath(Area, _btnManager.Curve)
                        Using InnerBorder As SolidBrush = New SolidBrush(_btnManager.InnerBorder)
                            PaintBorder(Link, IBPath, CType(InnerBorder, Brush))

                            InnerBorder.Dispose()
                        End Using
                    End Using
                End If

                Link.SmoothingMode = SmoothingMode.[Default]
            End Using
        End Sub

        Protected Overloads Overrides Sub OnRenderButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
            If _
                TypeOf e.ToolStrip Is ContextMenuStrip OrElse TypeOf e.ToolStrip Is ToolStripDropDownMenu OrElse _
                TypeOf e.ToolStrip Is MenuStrip Then
                Dim Item As ToolStripMenuItem = DirectCast(e.Item, ToolStripMenuItem)

                If Item.Selected OrElse Item.Checked OrElse Item.Pressed Then
                    IDrawMenustripItem(Item, e.Graphics, e.ToolStrip)
                End If
            ElseIf TypeOf e.ToolStrip Is StatusStrip Then
            Else
                Dim Item As ToolStripButton = DirectCast(e.Item, ToolStripButton)

                If Item.Selected OrElse Item.Checked OrElse Item.Pressed Then
                    IDrawToolstripButton(Item, e.Graphics, e.ToolStrip)
                End If
            End If
        End Sub

        Protected Overloads Overrides Sub OnRenderDropDownButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
            If e.Item.Selected OrElse e.Item.Pressed Then
                IDrawDropDownButton(DirectCast(e.Item, ToolStripDropDownButton), e.Graphics, e.ToolStrip)
            End If
        End Sub

        Protected Overloads Overrides Sub OnRenderImageMargin(ByVal e As ToolStripRenderEventArgs)
            Dim Area As Rectangle = New Rectangle(2, 2, e.AffectedBounds.Width, e.AffectedBounds.Height - 4)

            PaintBackground(e.Graphics, CType(Area, Rectangle), _mnuManager.MarginLeft, _mnuManager.MarginRight, 0.0F)

            e.Graphics.DrawLine(New Pen(_mnuManager.MenuBorderDark), e.AffectedBounds.Width + 1, 2, _
                                 e.AffectedBounds.Width + 1, e.AffectedBounds.Height - 3)
        End Sub

        Protected Overloads Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
            If _smoothText Then
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            End If

            If _overrideText Then
                e.TextColor = _overrideColor
            End If

            MyBase.OnRenderItemText(e)
        End Sub

        Protected Overloads Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
            Dim Item As ToolStripMenuItem = DirectCast(e.Item, ToolStripMenuItem)

            If (Not Item.Selected AndAlso Not Item.Checked AndAlso Not Item.Pressed) OrElse Item.Enabled = False Then
                Exit Sub
            End If

            If _
                TypeOf e.ToolStrip Is MenuStrip OrElse TypeOf e.ToolStrip Is ToolStripDropDownMenu OrElse _
                TypeOf e.ToolStrip Is ContextMenuStrip Then
                IDrawMenustripItem(Item, e.Graphics, e.ToolStrip)
            End If
        End Sub

        Protected Overloads Overrides Sub OnRenderSeparator(ByVal e As ToolStripSeparatorRenderEventArgs)
            If TypeOf e.ToolStrip Is ContextMenuStrip OrElse TypeOf e.ToolStrip Is ToolStripDropDownMenu Then
                ' Draw it

                e.Graphics.DrawLine(New Pen(_mnuManager.SeperatorDark), _mnuManager.SeperatorInset, 3, _
                                     e.Item.Width + 1, 3)
                e.Graphics.DrawLine(New Pen(_mnuManager.SeperatorLight), _mnuManager.SeperatorInset, 4, _
                                     e.Item.Width + 1, 4)
            Else
                If e.Vertical Then
                    e.Graphics.DrawLine(New Pen(_tsCtrlManager.SeperatorDark), 3, 5, 3, e.Item.Height - 6)
                    e.Graphics.DrawLine(New Pen(_tsCtrlManager.SeperatorLight), 4, 6, 4, e.Item.Height - 6)
                Else
                    e.Graphics.DrawLine(New Pen(_tsCtrlManager.SeperatorDark), 8, 0, e.Item.Width - 6, 0)
                    e.Graphics.DrawLine(New Pen(_tsCtrlManager.SeperatorLight), 9, 1, e.Item.Width - 6, 1)
                End If
            End If
        End Sub

        Protected Overloads Overrides Sub OnRenderSplitButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
            Dim Item As ToolStripSplitButton = DirectCast(e.Item, ToolStripSplitButton)

            IDrawToolstripSplitButton(Item, e.Graphics, e.ToolStrip)
        End Sub

        Protected Overloads Overrides Sub OnRenderStatusStripSizingGrip(ByVal e As ToolStripRenderEventArgs)
            Using Top As New SolidBrush(_sBarManager.GripTop), Bottom As New SolidBrush(_sBarManager.GripBottom)
                Dim d As Int32 = _sBarManager.GripSpacing
                Dim y As Int32 = e.AffectedBounds.Bottom - (d * 4)

                For a As Integer = 1 To 3
                    y = y + d

                    Dim b As Integer = 1
                    While a >= b
                        Dim x As Int32 = e.AffectedBounds.Right - (d * b)

                        e.Graphics.FillRectangle(Bottom, x + 1, y + 1, 2, 2)
                        e.Graphics.FillRectangle(Top, x, y, 2, 2)
                        b += 1
                    End While
                Next
            End Using
        End Sub

        Protected Overloads Overrides Sub OnRenderToolStripBackground(ByVal e As ToolStripRenderEventArgs)
            If TypeOf e.ToolStrip Is ContextMenuStrip OrElse TypeOf e.ToolStrip Is ToolStripDropDownMenu Then
                PaintBackground(e.Graphics, e.AffectedBounds, _mnuManager.BackgroundTop, _mnuManager.BackgroundBottom, _
                                 90.0F, _mnuManager.BackgroundBlend)

                Dim Border As Rectangle = New Rectangle(0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1)

                Using Path As GraphicsPath = CreateDrawingPath(Border, 0)
                    e.Graphics.ExcludeClip(New Rectangle(1, 0, e.ConnectedArea.Width, e.ConnectedArea.Height - 1))

                    PaintBorder(e.Graphics, Path, New SolidBrush(_mnuManager.MenuBorderDark))

                    e.Graphics.ResetClip()

                    Path.Dispose()
                End Using
            ElseIf TypeOf e.ToolStrip Is MenuStrip Then
                Dim Area As Rectangle = e.AffectedBounds

                PaintBackground(e.Graphics, Area, New SolidBrush(_pManager.ContentPanelTop))
            ElseIf TypeOf e.ToolStrip Is StatusStrip Then
                IDrawStatusbarBackground(DirectCast(e.ToolStrip, StatusStrip), e.Graphics, e.AffectedBounds)
            Else
                e.ToolStrip.BackColor = Color.Transparent

                IDrawToolstripBackground(e.ToolStrip, e.Graphics, e.AffectedBounds)
            End If
        End Sub

        Protected Overloads Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
            If TypeOf e.ToolStrip Is ContextMenuStrip OrElse TypeOf e.ToolStrip Is ToolStripDropDownMenu Then
            ElseIf TypeOf e.ToolStrip Is StatusStrip Then
            ElseIf TypeOf e.ToolStrip Is MenuStrip Then
            Else
                Dim Area As Rectangle = New Rectangle(0, -2, e.AffectedBounds.Width - 2, e.AffectedBounds.Height + 1)
                Using Path As GraphicsPath = CreateDrawingPath(CType(Area, Rectangle), _tsManager.Curve)
                    PaintBorder(e.Graphics, Path, e.AffectedBounds, _tsManager.BorderTop, _tsManager.BorderBottom, _
                                 _tsManager.BorderAngle, _
                                 _tsManager.BorderBlend)

                    Path.Dispose()
                End Using
            End If
        End Sub

        Protected Overloads Overrides Sub OnRenderToolStripContentPanelBackground( _
                                                                                   ByVal e As  _
                                                                                      ToolStripContentPanelRenderEventArgs)
            If _
                e.ToolStripContentPanel.ClientRectangle.Width < 3 OrElse _
                e.ToolStripContentPanel.ClientRectangle.Height < 3 Then
                Exit Sub
            End If

            e.Handled = True

            e.Graphics.SmoothingMode = _pManager.Mode

            PaintBackground(e.Graphics, e.ToolStripContentPanel.ClientRectangle, _pManager.ContentPanelTop, _
                             _pManager.ContentPanelBottom, _pManager.BackgroundAngle, _pManager.BackgroundBlend)
        End Sub

        Protected Overloads Overrides Sub OnRenderToolStripPanelBackground(ByVal e As ToolStripPanelRenderEventArgs)
            If e.ToolStripPanel.ClientRectangle.Width < 3 OrElse e.ToolStripPanel.ClientRectangle.Height < 3 Then
                Exit Sub
            End If

            e.Handled = True

            Select Case e.ToolStripPanel.Dock
                Case DockStyle.Top
                    PaintBackground(e.Graphics, e.ToolStripPanel.ClientRectangle, _
                                     New SolidBrush(_pManager.ContentPanelTop))
                    Exit Select

                Case DockStyle.Bottom
                    PaintBackground(e.Graphics, e.ToolStripPanel.ClientRectangle, _
                                     New SolidBrush(_pManager.ContentPanelBottom))
                    Exit Select

                Case DockStyle.Left, DockStyle.Right
                    PaintBackground(e.Graphics, e.ToolStripPanel.ClientRectangle, _pManager.ContentPanelTop, _
                                     _pManager.ContentPanelBottom, _pManager.BackgroundAngle, _pManager.BackgroundBlend)
                    Exit Select
            End Select
        End Sub

        Public Sub Apply()
            ToolStripManager.Renderer = Me
        End Sub
    End Class

    Public Class IToolstrip
        Implements IDisposable

        Public Sub New()
            DefaultBlending()
        End Sub

        Public Sub New(ByVal Import As IToolstrip)
            DefaultBlending()

            Apply(Import)
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub

        Private _backAngle As Single = 90
        Private _backBlend As Blend
        Private _backBottom As Color = Color.FromArgb(163, 193, 234)
        Private _backTop As Color = Color.FromArgb(227, 239, 255)
        Private _borderAngle As Single = 90
        Private _borderBlend As Blend
        Private _borderBottom As Color = Color.FromArgb(71, 117, 177)
        Private _borderTop As Color = Color.Transparent
        Private _curve As Integer = 2

        Public Property BackgroundTop() As Color
            Get
                Return _backTop
            End Get

            Set(ByVal value As Color)
                _backTop = value
            End Set
        End Property

        Public Property BackgroundBottom() As Color
            Get
                Return _backBottom
            End Get

            Set(ByVal value As Color)
                _backBottom = value
            End Set
        End Property

        Public Property BackgroundBlend() As Blend
            Get
                Return _backBlend
            End Get

            Set(ByVal value As Blend)
                _backBlend = value
            End Set
        End Property

        Public Property BackgroundAngle() As Single
            Get
                Return _backAngle
            End Get

            Set(ByVal value As Single)
                _backAngle = value
            End Set
        End Property

        Public Property BorderTop() As Color
            Get
                Return _borderTop
            End Get

            Set(ByVal value As Color)
                _borderTop = value
            End Set
        End Property

        Public Property BorderBottom() As Color
            Get
                Return _borderBottom
            End Get

            Set(ByVal value As Color)
                _borderBottom = value
            End Set
        End Property

        Public Property BorderBlend() As Blend
            Get
                Return _borderBlend
            End Get

            Set(ByVal value As Blend)
                _borderBlend = value
            End Set
        End Property

        Public Property BorderAngle() As Single
            Get
                Return _borderAngle
            End Get

            Set(ByVal value As Single)
                _borderAngle = value
            End Set
        End Property

        Public Property Curve() As Integer
            Get
                Return _curve
            End Get

            Set(ByVal value As Integer)
                _curve = value
            End Set
        End Property

        Public Sub Apply(ByVal Import As IToolstrip)
            _backTop = Import._borderTop
            _backBottom = Import._borderBottom
            _backAngle = Import._borderAngle
            _backBlend = Import._backBlend

            _borderTop = Import._borderTop
            _borderBottom = Import._borderBottom
            _borderAngle = Import._borderAngle
            _borderBlend = Import._borderBlend

            _curve = Import._curve
        End Sub

        Public Sub DefaultBlending()
            _borderBlend = New Blend()
            _borderBlend.Positions = New Single() {0.0F, 0.1F, 0.2F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F, 1.0F}
            _borderBlend.Factors = New Single() {0.1F, 0.2F, 0.3F, 0.3F, 0.3F, 0.4F, 0.4F, 0.4F, 0.5F, 0.7F, 0.7F}

            _backBlend = New Blend()
            _backBlend.Positions = New Single() {0.0F, 0.3F, 0.5F, 0.8F, 1.0F}
            _backBlend.Factors = New Single() {0.0F, 0.0F, 0.0F, 0.5F, 1.0F}
        End Sub
    End Class

    Public Class IToolstripControls
        Implements IDisposable

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub

        Private _gripBottom As Color = Color.White
        Private _gripDistance As Integer = 4
        Private _gripSize As New Size(2, 2)
        Private _gripStyle As GripType = GripType.Dotted
        Private _gripTop As Color = Color.FromArgb(111, 157, 217)
        Private _sepDark As Color = Color.FromArgb(154, 198, 255)
        Private _sepHeight As Integer = 8
        Private _sepLight As Color = Color.White

        Public Property SeperatorDark() As Color
            Get
                Return _sepDark
            End Get

            Set(ByVal value As Color)
                _sepDark = value
            End Set
        End Property

        Public Property SeperatorLight() As Color
            Get
                Return _sepLight
            End Get

            Set(ByVal value As Color)
                _sepLight = value
            End Set
        End Property

        Public Property SeperatorHeight() As Integer
            Get
                Return _sepHeight
            End Get

            Set(ByVal value As Integer)
                _sepHeight = value
            End Set
        End Property

        Public Property GripTop() As Color
            Get
                Return _gripTop
            End Get

            Set(ByVal value As Color)
                _gripTop = value
            End Set
        End Property

        Public Property GripShadow() As Color
            Get
                Return _gripBottom
            End Get

            Set(ByVal value As Color)
                _gripBottom = value
            End Set
        End Property

        Public Property GripStyle() As GripType
            Get
                Return _gripStyle
            End Get
            Set(ByVal value As GripType)
                _gripStyle = value
            End Set
        End Property

        Public Property GripDistance() As Integer
            Get
                Return _gripDistance
            End Get
            Set(ByVal value As Integer)
                _gripDistance = value
            End Set
        End Property

        Public Property GripSize() As Size
            Get
                Return _gripSize
            End Get
            Set(ByVal value As Size)
                _gripSize = value
            End Set
        End Property

        Public Sub Apply(ByVal Import As IToolstripControls)
            _sepDark = Import._sepDark
            _sepLight = Import._sepLight
            _sepHeight = Import._sepHeight

            _gripTop = Import._gripTop
            _gripBottom = Import._gripBottom
            _gripDistance = Import._gripDistance
            _gripStyle = Import._gripStyle
            _gripSize = Import._gripSize
        End Sub
    End Class

    Public Class IButton
        Implements IDisposable

        Public Sub New()
            DefaultBlending()
        End Sub

        Public Sub New(ByVal Import As IButton)
            DefaultBlending()

            Apply(Import)
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub

        Private _backAngle As Single = 90.0F
        Private _backBlend As Blend

        Private _blendRender As BlendRender = BlendRender.Hover Or BlendRender.Click Or BlendRender.Check
        Private _borderAngle As Single = 90.0F
        Private _borderBlend As Blend
        Private _borderBottom As Color = Color.FromArgb(157, 183, 217)
        Private _borderInner As Color = Color.FromArgb(255, 247, 185)
        Private _borderTop As Color = Color.FromArgb(157, 183, 217)
        Private _clickBackBottom As Color = Color.FromArgb(245, 225, 124)
        Private _clickBackTop As Color = Color.FromArgb(245, 207, 57)
        Private _curve As Integer = 1
        Private _hoverBackBottom As Color = Color.FromArgb(237, 189, 62)
        Private _hoverBackTop As Color = Color.FromArgb(255, 249, 218)

        Public Property HoverBackgroundTop() As Color
            Get
                Return _hoverBackTop
            End Get

            Set(ByVal value As Color)
                _hoverBackTop = value
            End Set
        End Property

        Public Property HoverBackgroundBottom() As Color
            Get
                Return _hoverBackBottom
            End Get

            Set(ByVal value As Color)
                _hoverBackBottom = value
            End Set
        End Property

        Public Property ClickBackgroundTop() As Color
            Get
                Return _clickBackTop
            End Get

            Set(ByVal value As Color)
                _clickBackTop = value
            End Set
        End Property

        Public Property ClickBackgroundBottom() As Color
            Get
                Return _clickBackBottom
            End Get

            Set(ByVal value As Color)
                _clickBackBottom = value
            End Set
        End Property

        Public Property BackgroundBlend() As Blend
            Get
                Return _backBlend
            End Get

            Set(ByVal value As Blend)
                _backBlend = value
            End Set
        End Property

        Public Property BackgroundAngle() As Single
            Get
                Return _backAngle
            End Get

            Set(ByVal value As Single)
                _backAngle = value
            End Set
        End Property

        Public Property BorderTop() As Color
            Get
                Return _borderTop
            End Get

            Set(ByVal value As Color)
                _borderTop = value
            End Set
        End Property

        Public Property BorderBottom() As Color
            Get
                Return _borderBottom
            End Get

            Set(ByVal value As Color)
                _borderBottom = value
            End Set
        End Property

        Public Property BorderBlend() As Blend
            Get
                Return _borderBlend
            End Get

            Set(ByVal value As Blend)
                _borderBlend = value
            End Set
        End Property

        Public Property BorderAngle() As Single
            Get
                Return _borderAngle
            End Get

            Set(ByVal value As Single)
                _borderAngle = value
            End Set
        End Property

        Public Property InnerBorder() As Color
            Get
                Return _borderInner
            End Get
            Set(ByVal value As Color)
                _borderInner = value
            End Set
        End Property

        Public Property BlendOptions() As BlendRender
            Get
                Return _blendRender
            End Get

            Set(ByVal value As BlendRender)
                _blendRender = value
            End Set
        End Property

        Public Property Curve() As Integer
            Get
                Return _curve
            End Get

            Set(ByVal value As Integer)
                _curve = value
            End Set
        End Property

        Public Sub Apply(ByVal Import As IButton)
            _borderTop = Import._borderTop
            _borderBottom = Import._borderBottom
            _borderAngle = Import._borderAngle
            _borderBlend = Import._borderBlend

            _hoverBackTop = Import._hoverBackTop
            _hoverBackBottom = Import._hoverBackBottom
            _clickBackTop = Import._clickBackTop
            _clickBackBottom = Import._clickBackBottom

            _backAngle = Import._backAngle
            _backBlend = Import._backBlend

            _blendRender = Import._blendRender
            _curve = Import._curve
        End Sub

        Public Sub DefaultBlending()
            _borderBlend = Nothing

            _backBlend = New Blend()
            _backBlend.Positions = New Single() {0.0F, 0.5F, 0.5F, 1.0F}
            _backBlend.Factors = New Single() {0.0F, 0.2F, 1.0F, 0.3F}
        End Sub
    End Class

    Public Class IDropDownButton
        Implements IDisposable

        Public Sub New()
            DefaultBlending()
        End Sub

        Public Sub New(ByVal Import As IDropDownButton)
            DefaultBlending()

            Apply(Import)
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub

        Private _backAngle As Single = 90.0F
        Private _backBlend As Blend

        Private _blendRender As BlendRender = BlendRender.Hover Or BlendRender.Check
        Private _borderAngle As Single = 90.0F
        Private _borderBlend As Blend
        Private _borderBottom As Color = Color.FromArgb(157, 183, 217)
        Private _borderInner As Color = Color.FromArgb(255, 247, 185)
        Private _borderTop As Color = Color.FromArgb(157, 183, 217)
        Private _curve As Integer = 1
        Private _hoverBackBottom As Color = Color.FromArgb(237, 189, 62)
        Private _hoverBackTop As Color = Color.FromArgb(255, 249, 218)

        Public Property HoverBackgroundTop() As Color
            Get
                Return _hoverBackTop
            End Get

            Set(ByVal value As Color)
                _hoverBackTop = value
            End Set
        End Property

        Public Property HoverBackgroundBottom() As Color
            Get
                Return _hoverBackBottom
            End Get

            Set(ByVal value As Color)
                _hoverBackBottom = value
            End Set
        End Property

        Public Property BackgroundBlend() As Blend
            Get
                Return _backBlend
            End Get

            Set(ByVal value As Blend)
                _backBlend = value
            End Set
        End Property

        Public Property BackgroundAngle() As Single
            Get
                Return _backAngle
            End Get

            Set(ByVal value As Single)
                _backAngle = value
            End Set
        End Property

        Public Property BorderTop() As Color
            Get
                Return _borderTop
            End Get

            Set(ByVal value As Color)
                _borderTop = value
            End Set
        End Property

        Public Property BorderBottom() As Color
            Get
                Return _borderBottom
            End Get

            Set(ByVal value As Color)
                _borderBottom = value
            End Set
        End Property

        Public Property BorderBlend() As Blend
            Get
                Return _borderBlend
            End Get

            Set(ByVal value As Blend)
                _borderBlend = value
            End Set
        End Property

        Public Property BorderAngle() As Single
            Get
                Return _borderAngle
            End Get

            Set(ByVal value As Single)
                _borderAngle = value
            End Set
        End Property

        Public Property InnerBorder() As Color
            Get
                Return _borderInner
            End Get
            Set(ByVal value As Color)
                _borderInner = value
            End Set
        End Property

        Public Property BlendOptions() As BlendRender
            Get
                Return _blendRender
            End Get

            Set(ByVal value As BlendRender)
                _blendRender = value
            End Set
        End Property

        Public Property Curve() As Integer
            Get
                Return _curve
            End Get

            Set(ByVal value As Integer)
                _curve = value
            End Set
        End Property

        Public Sub Apply(ByVal Import As IDropDownButton)
            _borderTop = Import._borderTop
            _borderBottom = Import._borderBottom
            _borderAngle = Import._borderAngle
            _borderBlend = Import._borderBlend

            _hoverBackTop = Import._hoverBackTop
            _hoverBackBottom = Import._hoverBackBottom

            _backAngle = Import._backAngle
            _backBlend = Import._backBlend

            _blendRender = Import._blendRender
            _curve = Import._curve
        End Sub

        Public Sub DefaultBlending()
            _borderBlend = Nothing

            _backBlend = New Blend()
            _backBlend.Positions = New Single() {0.0F, 0.5F, 0.5F, 1.0F}
            _backBlend.Factors = New Single() {0.0F, 0.2F, 1.0F, 0.3F}
        End Sub
    End Class

    Public Class ISplitButton
        Implements IDisposable

        Public Sub New()
            DefaultBlending()
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub

        Private _arrowColor As Color = Color.Black
        Private _arrowDisplay As ArrowDisplay = ArrowDisplay.Always
        Private _backAngle As Single = 90.0F
        Private _backBlend As Blend

        Private _blendRender As BlendRender = BlendRender.Hover Or BlendRender.Click Or BlendRender.Check
        Private _borderAngle As Single = 90.0F
        Private _borderBlend As Blend
        Private _borderBottom As Color = Color.FromArgb(157, 183, 217)
        Private _borderInner As Color = Color.FromArgb(255, 247, 185)
        Private _borderTop As Color = Color.FromArgb(157, 183, 217)
        Private _clickBackBottom As Color = Color.FromArgb(245, 225, 124)
        Private _clickBackTop As Color = Color.FromArgb(245, 207, 57)
        Private _curve As Integer = 1
        Private _hoverBackBottom As Color = Color.FromArgb(237, 189, 62)
        Private _hoverBackTop As Color = Color.FromArgb(255, 249, 218)

        Public Property HoverBackgroundTop() As Color
            Get
                Return _hoverBackTop
            End Get

            Set(ByVal value As Color)
                _hoverBackTop = value
            End Set
        End Property

        Public Property HoverBackgroundBottom() As Color
            Get
                Return _hoverBackBottom
            End Get

            Set(ByVal value As Color)
                _hoverBackBottom = value
            End Set
        End Property

        Public Property ClickBackgroundTop() As Color
            Get
                Return _clickBackTop
            End Get

            Set(ByVal value As Color)
                _clickBackTop = value
            End Set
        End Property

        Public Property ClickBackgroundBottom() As Color
            Get
                Return _clickBackBottom
            End Get

            Set(ByVal value As Color)
                _clickBackBottom = value
            End Set
        End Property

        Public Property BackgroundBlend() As Blend
            Get
                Return _backBlend
            End Get

            Set(ByVal value As Blend)
                _backBlend = value
            End Set
        End Property

        Public Property BackgroundAngle() As Single
            Get
                Return _backAngle
            End Get

            Set(ByVal value As Single)
                _backAngle = value
            End Set
        End Property

        Public Property BorderTop() As Color
            Get
                Return _borderTop
            End Get

            Set(ByVal value As Color)
                _borderTop = value
            End Set
        End Property

        Public Property BorderBottom() As Color
            Get
                Return _borderBottom
            End Get

            Set(ByVal value As Color)
                _borderBottom = value
            End Set
        End Property

        Public Property BorderBlend() As Blend
            Get
                Return _borderBlend
            End Get

            Set(ByVal value As Blend)
                _borderBlend = value
            End Set
        End Property

        Public Property BorderAngle() As Single
            Get
                Return _borderAngle
            End Get

            Set(ByVal value As Single)
                _borderAngle = value
            End Set
        End Property

        Public Property InnerBorder() As Color
            Get
                Return _borderInner
            End Get
            Set(ByVal value As Color)
                _borderInner = value
            End Set
        End Property

        Public Property BlendOptions() As BlendRender
            Get
                Return _blendRender
            End Get

            Set(ByVal value As BlendRender)
                _blendRender = value
            End Set
        End Property

        Public Property Curve() As Integer
            Get
                Return _curve
            End Get

            Set(ByVal value As Integer)
                _curve = value
            End Set
        End Property

        Public Property ArrowDisplay() As ArrowDisplay
            Get
                Return _arrowDisplay
            End Get
            Set(ByVal value As ArrowDisplay)
                _arrowDisplay = value
            End Set
        End Property

        Public Property ArrowColor() As Color
            Get
                Return _arrowColor
            End Get
            Set(ByVal value As Color)
                _arrowColor = value
            End Set
        End Property

        Public Sub Apply(ByVal Import As ISplitButton)
            _borderTop = Import._borderTop
            _borderBottom = Import._borderBottom
            _borderAngle = Import._borderAngle
            _borderBlend = Import._borderBlend

            _hoverBackTop = Import._hoverBackTop
            _hoverBackBottom = Import._hoverBackBottom
            _clickBackTop = Import._clickBackTop
            _clickBackBottom = Import._clickBackBottom

            _backAngle = Import._backAngle
            _backBlend = Import._backBlend

            _blendRender = Import._blendRender
            _curve = Import._curve

            _arrowDisplay = Import._arrowDisplay
            _arrowColor = Import._arrowColor
        End Sub

        Public Sub DefaultBlending()
            _borderBlend = Nothing

            _backBlend = New Blend()
            _backBlend.Positions = New Single() {0.0F, 0.5F, 0.5F, 1.0F}
            _backBlend.Factors = New Single() {0.0F, 0.2F, 1.0F, 0.3F}
        End Sub
    End Class

    Public Class IPanel
        Implements IDisposable

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub

        Private _cPanelAngle As Single = 90.0F

        Private _cPanelTop As Color = Color.FromArgb(220, 230, 244)
        Private _cPanelBottom As Color = Color.FromArgb(255, 255, 255)


        Private _mode As SmoothingMode = SmoothingMode.HighSpeed

        Public Property ContentPanelTop() As Color
            Get
                Return _cPanelTop
            End Get
            Set(ByVal value As Color)
                _cPanelTop = value
            End Set
        End Property

        Public Property ContentPanelBottom() As Color
            Get
                Return _cPanelBottom
            End Get
            Set(ByVal value As Color)
                _cPanelBottom = value
            End Set
        End Property

        Private _PanelInheritance As [Boolean]

        Public Property PanelInheritance() As [Boolean]
            Get
                Return _PanelInheritance
            End Get
            Set(ByVal value As [Boolean])
                _PanelInheritance = value
            End Set
        End Property

        Public Property BackgroundAngle() As Single
            Get
                Return _cPanelAngle
            End Get
            Set(ByVal value As Single)
                _cPanelAngle = value
            End Set
        End Property

        Private _BackgroundBlend As Blend

        Public Property BackgroundBlend() As Blend
            Get
                Return _BackgroundBlend
            End Get
            Set(ByVal value As Blend)
                _BackgroundBlend = value
            End Set
        End Property

        Public Property Mode() As SmoothingMode
            Get
                Return _mode
            End Get
            Set(ByVal value As SmoothingMode)
                _mode = value
            End Set
        End Property
    End Class

    Public Class IStatusBar
        Implements IDisposable

        Public Sub New()
            DefaultBlending()
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub

        Private _backAngle As Single = 90
        Private _backBlend As Blend
        Private _backBottom As Color = Color.FromArgb(173, 209, 255)
        Private _backTop As Color = Color.FromArgb(227, 239, 255)
        Private _borderAngle As Single = 90
        Private _borderBlend As Blend

        Private _borderDark As Color = Color.FromArgb(86, 125, 176)
        Private _borderLight As Color = Color.White
        Private _gripBottom As Color = Color.FromArgb(248, 248, 248)
        Private _gripSpacing As Int32 = 4
        Private _gripTop As Color = Color.FromArgb(114, 152, 204)

        Public Property BackgroundTop() As Color
            Get
                Return _backTop
            End Get
            Set(ByVal value As Color)
                _backTop = value
            End Set
        End Property

        Public Property BackgroundBottom() As Color
            Get
                Return _backBottom
            End Get
            Set(ByVal value As Color)
                _backBottom = value
            End Set
        End Property

        Public Property BackgroundBlend() As Blend
            Get
                Return _backBlend
            End Get
            Set(ByVal value As Blend)
                _backBlend = value
            End Set
        End Property

        Public Property BackgroundAngle() As Single
            Get
                Return _backAngle
            End Get
            Set(ByVal value As Single)
                _backAngle = value
            End Set
        End Property

        Public Property DarkBorder() As Color
            Get
                Return _borderDark
            End Get
            Set(ByVal value As Color)
                _borderDark = value
            End Set
        End Property

        Public Property LightBorder() As Color
            Get
                Return _borderLight
            End Get
            Set(ByVal value As Color)
                _borderLight = value
            End Set
        End Property

        Public Property GripTop() As Color
            Get
                Return _gripTop
            End Get
            Set(ByVal value As Color)
                _gripTop = value
            End Set
        End Property

        Public Property GripBottom() As Color
            Get
                Return _gripBottom
            End Get
            Set(ByVal value As Color)
                _gripBottom = value
            End Set
        End Property

        Public Property GripSpacing() As Int32
            Get
                Return _gripSpacing
            End Get
            Set(ByVal value As Int32)
                _gripSpacing = value
            End Set
        End Property

        Public Sub Apply(ByVal Import As IStatusBar)
            _borderDark = Import._borderDark
            _borderLight = Import._borderLight

            _backTop = Import._backTop
            _backBottom = Import._backBottom
            _backAngle = Import._backAngle
            _backBlend = Import._backBlend
        End Sub

        Public Sub DefaultBlending()
            _borderBlend = Nothing

            _backBlend = New Blend()
            _backBlend.Positions = New Single() {0.0F, 0.25F, 0.25F, 0.57F, 0.86F, 1.0F}
            _backBlend.Factors = New Single() {0.1F, 0.6F, 1.0F, 0.4F, 0.0F, 0.95F}
        End Sub
    End Class

    Public Class IMenustrip
        Implements IDisposable

        Public Sub New()
            _buttons = New IButton()

            DefaultBlending()
        End Sub

        Public Sub New(ByVal Import As IMenustrip)
            _buttons = New IButton()

            DefaultBlending()

            Apply(Import)
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub

        Private _buttons As IButton
        Private _marginBorder As Color = Color.FromArgb(197, 197, 197)
        Private _marginLeft As Color = Color.FromArgb(242, 255, 255)
        Private _marginRight As Color = Color.FromArgb(233, 238, 238)
        Private _menuBackBlend As Blend
        Private _menuBackBottom As Color = Color.White
        Private _menuBackInh As InheritenceType = InheritenceType.FromContentPanel
        Private _menuBackTop As Color = Color.White
        Private _menuBorderDark As Color = Color.FromArgb(157, 183, 217)
        Private _menuBorderLight As Color = Color.Transparent

        Private _menuStripBtnBackground As Color = Color.White
        Private _menuStripBtnBorder As Color = Color.FromArgb(157, 183, 217)

        Private _sepDark As Color = Color.FromArgb(197, 197, 197)
        Private _sepInset As Int32 = 30
        Private _sepLight As Color = Color.FromArgb(254, 254, 254)

        Public Property MenuBorderDark() As Color
            Get
                Return _menuBorderDark
            End Get
            Set(ByVal value As Color)
                _menuBorderDark = value
            End Set
        End Property

        Public Property MenuBorderLight() As Color
            Get
                Return _menuBorderLight
            End Get
            Set(ByVal value As Color)
                _menuBorderLight = value
            End Set
        End Property

        Public Property BackgroundInheritence() As InheritenceType
            Get
                Return _menuBackInh
            End Get
            Set(ByVal value As InheritenceType)
                _menuBackInh = value
            End Set
        End Property

        Public Property BackgroundTop() As Color
            Get
                Return _menuBackTop
            End Get
            Set(ByVal value As Color)
                _menuBackTop = value
            End Set
        End Property

        Public Property BackgroundBottom() As Color
            Get
                Return _menuBackBottom
            End Get
            Set(ByVal value As Color)
                _menuBackBottom = value
            End Set
        End Property

        Public Property BackgroundBlend() As Blend
            Get
                Return _menuBackBlend
            End Get
            Set(ByVal value As Blend)
                _menuBackBlend = value
            End Set
        End Property

        Public Property MarginLeft() As Color
            Get
                Return _marginLeft
            End Get
            Set(ByVal value As Color)
                _marginLeft = value
            End Set
        End Property

        Public Property MarginRight() As Color
            Get
                Return _marginRight
            End Get
            Set(ByVal value As Color)
                _marginRight = value
            End Set
        End Property

        Public Property MarginBorder() As Color
            Get
                Return _marginBorder
            End Get
            Set(ByVal value As Color)
                _marginBorder = value
            End Set
        End Property

        Public Property MenustripButtonBackground() As Color
            Get
                Return _menuStripBtnBackground
            End Get
            Set(ByVal value As Color)
                _menuStripBtnBackground = value
            End Set
        End Property

        Public Property MenustripButtonBorder() As Color
            Get
                Return _menuStripBtnBorder
            End Get
            Set(ByVal value As Color)
                _menuStripBtnBorder = value
            End Set
        End Property

        Public Property SeperatorDark() As Color
            Get
                Return _sepDark
            End Get
            Set(ByVal value As Color)
                _sepDark = value
            End Set
        End Property

        Public Property SeperatorLight() As Color
            Get
                Return _sepLight
            End Get
            Set(ByVal value As Color)
                _sepLight = value
            End Set
        End Property

        Public Property SeperatorInset() As Int32
            Get
                Return _sepInset
            End Get
            Set(ByVal value As Int32)
                _sepInset = value
            End Set
        End Property

        <[ReadOnly](True)> _
        Public ReadOnly Property Items() As IButton
            Get
                Return _buttons
            End Get
        End Property

        Public Sub Apply(ByVal Import As IMenustrip)
            _menuBackInh = Import._menuBackInh
            _menuBackTop = Import._menuBackTop
            _menuBackBottom = Import._menuBackBottom
            _menuBorderDark = Import._menuBorderDark
            _menuBorderLight = Import._menuBorderLight
            _menuBackBlend = Import._menuBackBlend
            _buttons = Import._buttons
        End Sub

        Public Sub DefaultBlending()
            _menuBackBlend = New Blend()
            _menuBackBlend.Positions = New Single() {0.0F, 0.3F, 0.5F, 0.8F, 1.0F}
            _menuBackBlend.Factors = New Single() {0.0F, 0.0F, 0.0F, 0.5F, 1.0F}
        End Sub
    End Class

    Public Enum ArrowDisplay
        Always
        Hover
        Never
    End Enum

    Public Enum BlendRender

        Normal

        Hover

        Click

        Check

        All = Normal Or Hover Or Click Or Check
    End Enum

    Public Enum GripType

        Dotted

        Lines

        None
    End Enum

    Public Enum ButtonType
        NormalButton
        SplitButton
        MenuItem
        DropDownButton
    End Enum

    Public Enum InheritenceType
        FromContentPanel
        None
    End Enum

    Public Enum RenderingMode
        System
        Professional
        [Custom]
    End Enum
End Namespace
