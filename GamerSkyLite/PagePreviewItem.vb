﻿Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions

Public Class PagePreviewItem

#Region "封装起来的属性"
    Private in_ItemID As String
    ''' <summary>
    ''' 文章ID
    ''' </summary>
    Public Property ItemID As String
        Get
            Return in_ItemID
        End Get
        Set(value As String)
            in_ItemID = value
        End Set
    End Property

    ''' <summary>
    ''' 文章标题
    ''' </summary>
    Public Property Title As String
        Get
            Return TitleLabel.Text
        End Get
        Set(value As String)
            TitleLabel.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 文章内容预览
    ''' </summary>
    Public Overrides Property Text As String
        Get
            Return TextLabel.Text
        End Get
        Set(value As String)
            TextLabel.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 文章发布时间
    ''' </summary>
    Public Property Time As String
        Get
            Return TimeLabel.Text
        End Get
        Set(value As String)
            TimeLabel.Text = value
        End Set
    End Property

    Private in_ImageLink As String
    ''' <summary>
    ''' 文章预览图像
    ''' </summary>
    Public Property ImageLink As String
        Get
            Return in_ImageLink
        End Get
        Set(value As String)
            Try
                Dim ImageWebClient As WebClient = New WebClient With {.BaseAddress = value, .Credentials = CredentialCache.DefaultCredentials}
                AddHandler ImageWebClient.DownloadFileCompleted,
                    Sub(sender As Object, e As AsyncCompletedEventArgs)
                        If Not e.Error Is Nothing Then ImagePreviewBox.Text = "图像下载失败！" : Exit Sub
                        ImagePreviewBox.Text = vbNullString
                        '为防止图片读入后被进程占用无法清理：把图像读入流中
                        Using PreviewImageStream As FileStream = New FileStream(ReaderForm.CacheDirectory & Path.GetFileName(value), FileMode.Open)
                            ImagePreviewBox.Image = Image.FromStream(PreviewImageStream)
                        End Using
                    End Sub
                ImageWebClient.DownloadFileAsync(New Uri(value), ReaderForm.CacheDirectory & Path.GetFileName(value))
            Catch ex As Exception
                ImagePreviewBox.Text = "图像下载失败！"
            End Try
        End Set
    End Property

    Private in_LinkAddress As String
    ''' <summary>
    ''' 文章的链接地址
    ''' </summary>
    Public Property LinkAddress As String
        Get
            Return in_LinkAddress
        End Get
        Set(value As String)
            in_LinkAddress = value
        End Set
    End Property

#End Region

    '图像下载目录
    Private DownloadDirectory As String
    '记录已经下载的文件个数
    Private in_DownloadState As Integer
    '记录下载状态
    Private in_Downloading As Boolean

    ''' <summary>
    ''' 抽象所链接页面的文章内图片链接和正文
    ''' </summary>
    Private Structure Content
        Dim ImageLink As String
        Dim Text As String
    End Structure
    ''' <summary>
    ''' 图文内容记录列表
    ''' </summary>
    Dim ContentList As List(Of Content) = New List(Of Content)

#Region "初始化接口"
    ''' <summary>
    ''' 默认初始化
    ''' </summary>
    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' 初始化一个文章预览项目
    ''' </summary>
    ''' <param name="strTitle">文章标题</param>
    ''' <param name="strText">文章内容预览</param>
    ''' <param name="strImageLink">文章预览图像的链接地址</param>
    ''' <param name="strTime">文章发布时间</param>
    ''' <param name="strLinkAddress">文章链接地址</param>
    Public Sub New(strTitle As String, strText As String, strImageLink As String, strTime As String, strLinkAddress As String)
        InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor, True)

        '’初始化控件数据
        Title = strTitle
        Text = strText
        ImageLink = strImageLink
        ItemID = Path.GetFileNameWithoutExtension(strImageLink)
        DownloadDirectory = ReaderForm.CacheDirectory & ItemID & "\"
        Time = strTime
        LinkAddress = strLinkAddress
    End Sub
#End Region

#Region "控件响应鼠标效果"

    Private Sub PagePreviewItem_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter, TitleLabel.MouseEnter, TextLabel.MouseEnter, TimeLabel.MouseEnter, ImagePreviewBox.MouseEnter
        TitleLabel.ForeColor = Color.Orange
    End Sub

    Private Sub PagePreviewItem_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave, TitleLabel.MouseLeave, TextLabel.MouseLeave, TimeLabel.MouseLeave, ImagePreviewBox.MouseLeave
        TitleLabel.ForeColor = Color.Black
    End Sub

    Private Sub PagePreviewItem_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, TitleLabel.MouseUp, TextLabel.MouseUp, TimeLabel.MouseUp, ImagePreviewBox.MouseUp
        TitleLabel.ForeColor = Color.Orange
    End Sub

    Private Sub PagePreviewItem_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, TitleLabel.MouseDown, TextLabel.MouseDown, TimeLabel.MouseDown, ImagePreviewBox.MouseDown
        TitleLabel.ForeColor = Color.DarkRed
    End Sub

#End Region

#Region "下载按钮"
    Private Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click
        If Not in_Downloading Then
            If ContentList.Count > 0 AndAlso in_DownloadState = ContentList.Count Then
                '已经下载完成
            Else
                '开始下载
                in_Downloading = True
                DownloadButton.Text = "正在解析文章页面..."
                DownloadButton.ForeColor = Color.DodgerBlue
                Try
                    GamerSkyHomeProcess.GetHTML(Me.LinkAddress, AddressOf AnalysisPage)
                Catch ex As Exception
                    in_Downloading = False
                    DownloadButton.Text = "文章内容解析失败"
                    DownloadButton.ForeColor = Color.Red
                    MessageBox.ShowMessagebox("异步访问时出错：" & LinkAddress, ex.Message, MessageBox.Icons._Error, ReaderForm)
                End Try
            End If
        Else
            '正在下载

        End If
    End Sub

    Private Sub DownloadButton_MouseEnter(sender As Object, e As EventArgs) Handles DownloadButton.MouseEnter
        TitleLabel.ForeColor = Color.Orange
        If Not in_Downloading Then DownloadButton.Image = My.Resources.UnityResource.Download_1
    End Sub

    Private Sub DownloadButton_MouseLeave(sender As Object, e As EventArgs) Handles DownloadButton.MouseLeave
        TitleLabel.ForeColor = Color.Black
        If Not in_Downloading Then DownloadButton.Image = My.Resources.UnityResource.Download_0
    End Sub

#End Region

    Private Sub AnalysisPage(PageHTML As String)
        Dim MainPattern As String = "<([a-z]+)(?:(?!class)[^<>])*class=([""']?){0}\2[^>]*>(?>(?<o><\1[^>]*>)|(?<-o></\1>)|(?:(?!</?\1).))*(?(o)(?!))</\1>"
        Dim HTMLRegex As Regex, MatchResult As Match
        MainPattern = String.Format(MainPattern, Regex.Escape("Mid2L_con"))
        HTMLRegex = New Regex(MainPattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        MatchResult = HTMLRegex.Match(PageHTML)
        Dim MainHTML As String = MatchResult.Value
        If MainHTML = vbNullString Then MessageBox.ShowMessagebox("解析目录失败！", "未找到 class=Mid2L_con 的元素！", MessageBox.Icons._Error, ReaderForm) : Exit Sub

        '分割，上部为正文内容，下部为页数导航"
        Dim ItemHTMLs As String() = Strings.Split(MainHTML, "<!--{pe.begin.pagination}-->", 2)
        If ItemHTMLs.Length < 2 Then MessageBox.ShowMessagebox("解析目录失败！", "分割 class=Mid2L_con 元素未得到文章列表！", MessageBox.Icons._Error, ReaderForm) : Exit Sub

        Dim ImageHTMLs As String() = Strings.Split(ItemHTMLs(0), "</p>")
        Dim TitlePattern As String
        Dim ItemRegex As Regex
        Dim ItemMatchResult As Match
        For Index As Integer = 0 To ImageHTMLs.Length - 1
            If InStr(ImageHTMLs(Index), "http://www.gamersky.com/showimage/id_gamersky.shtml?") Then
                TitlePattern = "<a.*?shtml\?(?<imagelink>.+?)"""
            Else
                TitlePattern = "<img.*?src=""(?<imagelink>.+?)"""
            End If
            ItemRegex = New Regex(TitlePattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            ItemMatchResult = ItemRegex.Match(ImageHTMLs(Index))
            Dim TempString As String() = Split(ImageHTMLs(Index), "</a><br>")
            If ItemMatchResult.Groups("imagelink").Value <> vbNullString Then
                ContentList.Add(New Content() With {.ImageLink = ItemMatchResult.Groups("imagelink").Value, .Text = IIf(TempString.Length > 1, TempString.Last, vbNullString)})
            End If
        Next
        '读取下一页
        TitlePattern = "<a href=""(?<nextpagelink>.+?)"">下一页</a>"
        ItemRegex = New Regex(TitlePattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        ItemMatchResult = ItemRegex.Match(ItemHTMLs(1))

        'Debug.Print(ItemMatchResult.Groups("nextpagelink").Value)
        If ItemMatchResult.Groups("nextpagelink").Value <> vbNullString Then
            ReaderForm.Invoke(
                Sub()
                    GamerSkyHomeProcess.GetHTML(ItemMatchResult.Groups("nextpagelink").Value, AddressOf AnalysisPage)
                End Sub)
        Else
            DownloadButton.Text = "开始下载文章图像..."
            DownloadImage()
        End If
    End Sub

    Private Sub DownloadImage()
        If ContentList.Count = 0 Then
            in_Downloading = False
            DownloadButton.Text = ""
            MessageBox.ShowMessagebox("读取终止！", "没有在目标页面中解析出图文！", MessageBox.Icons.Warning, ReaderForm)
            Exit Sub
        End If

        If in_DownloadState >= ContentList.Count Then
            DownloadCompleted()
            Exit Sub
        End If

        'If Directory.Exists(DownloadDirectory) Then
        '    Try
        '        For Each PreviewFile As String In Directory.GetFiles(DownloadDirectory)
        '            File.Delete(PreviewFile)
        '        Next
        '    Catch ex As Exception
        '        MessageBox.ShowMessagebox("删除文章图像缓存时出错", ex.Message, MessageBox.Icons._Error, Me)
        '    End Try
        'End If
        Try
            Directory.CreateDirectory(DownloadDirectory)
        Catch ex As Exception
            MessageBox.ShowMessagebox("创建目录时出错！", ex.Message, MessageBox.Icons._Error, ReaderForm) : Exit Sub
        End Try

        Dim ImagePath As String = DownloadDirectory & Path.GetFileName(ContentList(in_DownloadState).ImageLink)
        Dim ImageWebClient As WebClient = New WebClient()
        AddHandler ImageWebClient.DownloadFileCompleted,
            Sub(sender As Object, e As AsyncCompletedEventArgs)
                If e.Error Is Nothing Then
                    'todo:使用文件：ImagePath
                    Do While File.Exists(ImagePath) And in_DownloadState < ContentList.Count - 1
                        in_DownloadState += 1
                        ImagePath = DownloadDirectory & Path.GetFileName(ContentList(in_DownloadState).ImageLink)
                    Loop

                    If in_DownloadState >= ContentList.Count - 1 Then
                        DownloadCompleted()
                        Exit Sub
                    Else
                        DownloadButton.Text = String.Format("下载进度：{0} / {1}", in_DownloadState, ContentList.Count - 1)
                    End If

                    ImageWebClient.DownloadFileAsync(New Uri(ContentList(in_DownloadState).ImageLink), ImagePath)
                Else
                    Try
                        File.Delete(ImagePath)
                    Catch ex As Exception
                        MessageBox.ShowMessagebox("下载失败，删除缓存失败！", ex.Message, MessageBox.Icons._Error, ReaderForm)
                    End Try
                End If
            End Sub
        ImageWebClient.DownloadFileAsync(New Uri(ContentList(in_DownloadState).ImageLink), ImagePath)
    End Sub

    Private Sub BrowserButton_Click(sender As Object, e As EventArgs) Handles BrowserButton.Click
        Process.Start(Me.LinkAddress)
    End Sub

    Private Sub PagePreviewItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler BrowserButton.MouseEnter, AddressOf MouseActiveEvent.MouseEnter
        AddHandler BrowserButton.MouseLeave, AddressOf MouseActiveEvent.MouseLeave
        AddHandler BrowserButton.MouseDown, AddressOf MouseActiveEvent.MouseDown
        AddHandler BrowserButton.MouseUp, AddressOf MouseActiveEvent.MouseUp
    End Sub

    Private Sub DownloadCompleted()
        in_Downloading = False
        DownloadButton.Text = "下载完成：" & ContentList.Count
    End Sub

End Class