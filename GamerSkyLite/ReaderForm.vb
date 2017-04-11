Imports System.IO

Public Class ReaderForm
    ''' <summary>
    ''' 当前程序所显示状态
    ''' </summary>
    Private Enum FrameStateEnum
        ''' <summary>
        ''' 正在显示主页文章目录
        ''' </summary>
        Home = 0
        ''' <summary>
        ''' 正在显示文章内容
        ''' </summary>
        Page = 1
    End Enum
    Dim FrameState As FrameStateEnum = FrameStateEnum.Home

    ''' <summary>
    ''' 文章目录的主页地址
    ''' </summary>
    Private Const HomeURL As String = "http://www.gamersky.com/ent/qw/"

    ''' <summary>
    ''' 存放图像缓存的路径
    ''' </summary>
    Public CacheDirectory As String = Environment.CurrentDirectory & "\GSLiteCache\"

    Private Sub ReaderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        Me.Icon = My.Resources.UnityResource.GamerSky

        For Each LabelButton As Label In New Label() {MinButton, MaxButton, RestoreButton, CloseButton, RefreshButton, GoBackButton, CleanButton}
            AddHandler LabelButton.MouseEnter, AddressOf MouseActiveEvent.MouseEnter
            AddHandler LabelButton.MouseLeave, AddressOf MouseActiveEvent.MouseLeave
            AddHandler LabelButton.MouseDown, AddressOf MouseActiveEvent.MouseDown
            AddHandler LabelButton.MouseUp, AddressOf MouseActiveEvent.MouseUp
        Next
        AddHandler Me.MouseDown, AddressOf MouseActiveEvent.MoveWindow
        AddHandler LogoLabel.MouseDown, AddressOf MouseActiveEvent.MoveWindowByControl

        '创建缓存目录
        Try
            Directory.CreateDirectory(CacheDirectory)
        Catch ex As Exception
            MessageBox.ShowMessagebox("创建缓存目录时出错！", ex.Message, MessageBox.Icons._Error, Me)
            Application.Exit()
        End Try

        '获取首页文章列表
        GamerSkyHomeProcess.ScanHome(HomeURL)
    End Sub

#Region "窗体大小改变"

    Private Sub ReaderForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Select Case Me.WindowState
            Case FormWindowState.Minimized
                Exit Sub
            Case FormWindowState.Normal
                MaxButton.Show()
                RestoreButton.Hide()
            Case FormWindowState.Maximized
                RestoreButton.Show()
                MaxButton.Hide()
        End Select
        MinButton.Left = Me.Width - 75
        RestoreButton.Left = MinButton.Right + 5
        MaxButton.Left = RestoreButton.Left
        CloseButton.Left = RestoreButton.Right + 5

        PreviewItemPanel.Left = Me.Width * 0.1
        PreviewItemPanel.Width = Me.Width * 0.8
        PreviewItemPanel.Height = (Me.Height - LogoLabel.Bottom) * 0.9
        PreviewItemPanel.Top = (Me.Height - LogoLabel.Bottom - PreviewItemPanel.Height) * 0.5 + LogoLabel.Bottom
    End Sub

    Private Sub MinButton_Click(sender As Object, e As EventArgs) Handles MinButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub RestoreButton_Click(sender As Object, e As EventArgs) Handles RestoreButton.Click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        If New MessageBox("真的要退出吗？"， "您确定真的要退出吗？", MessageBox.Icons.Question).ShowDialog(Me) = DialogResult.OK Then
            Do Until Me.Opacity <= 0
                Me.Opacity -= 0.1
                Threading.Thread.Sleep(30)
            Loop
            Application.Exit()
        End If
    End Sub

    Private Sub MaxButton_Click(sender As Object, e As EventArgs) Handles MaxButton.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
#End Region

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        If FrameState = FrameStateEnum.Home Then
            Do While PreviewItemPanel.Controls.Count > 0
                PreviewItemPanel.Controls(0).Dispose()
            Loop

            Try
                For Each PreviewFile As String In Directory.GetFiles(CacheDirectory)
                    File.Delete(PreviewFile)
                Next
            Catch ex As Exception
                MessageBox.ShowMessagebox("删除首页图像缓存时出错", ex.Message, MessageBox.Icons._Error, Me)
            End Try

            GamerSkyHomeProcess.ScanHome(HomeURL)
        End If
    End Sub

    Private Sub PreviewItemPanel_Click(sender As Object, e As EventArgs) Handles PreviewItemPanel.Click
        PreviewItemPanel.Refresh()
    End Sub

End Class
