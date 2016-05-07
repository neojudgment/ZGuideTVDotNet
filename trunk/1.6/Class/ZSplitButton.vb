Imports System.Drawing.Drawing2D

' ReSharper disable once CheckNamespace
Public Class ZSplitButton

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Me.BackColor = Color.DarkGray
        ' Add any initialization after the InitializeComponent() call.
        SetStyle( _
             ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or _
             ControlStyles.OptimizedDoubleBuffer, True)
        AutoSize = False
        AutoScaleMode = Windows.Forms.AutoScaleMode.None
    End Sub

    Public Property Cliquable As Boolean = True

    Protected Overrides Sub OnPaint(e As Windows.Forms.PaintEventArgs)

        Dim gp As GraphicsPath = New GraphicsPath

        Dim b As New SolidBrush(Color.FromArgb(50, 50, 80))
        Dim b2 As New SolidBrush(Color.FromArgb(242, 242, 242))
        Try
            Dim drawingArea As Graphics = e.Graphics
            drawingArea.SmoothingMode = SmoothingMode.AntiAlias

            Dim w As Integer = Width - 1
            Dim h As Integer = Height - 1

            With drawingArea
                .Clear(Color.White)
                With gp
                    .AddLine(0, 0, w, 0)
                    .AddLine(w, 0, w, h)
                    .AddLine(w, h, 0, h)
                    .AddLine(0, h, 0, 0)
                End With
                gp.CloseFigure()
                .FillPath(b2, gp)

                If _Cliquable Then

                    Dim diametre As Integer = Width - 3
                    Dim baser As Integer = CInt((Height - 3 * Width) / 2)
                    Dim r As New Rectangle(1, baser, diametre, diametre)
                    Dim r2 As New Rectangle(1, baser + Width, Width - 3, Width - 3)
                    Dim r3 As New Rectangle(1, baser + (2 * Width), diametre, diametre)

                    .FillEllipse(b, r)
                    .FillEllipse(b, r2)
                    .FillEllipse(b, r3)
                End If
            End With
        Catch ex As Exception
        Finally
            If b IsNot Nothing Then
                b.Dispose()
            End If
            If b2 IsNot Nothing Then
                b2.Dispose()
            End If
            If gp IsNot Nothing Then
                gp.Dispose()
            End If

        End Try

        MyBase.OnPaint(e)
    End Sub

    Public Sub PerformClick()
        If CanSelect Then
            OnClick(EventArgs.Empty)
        End If
    End Sub

End Class

