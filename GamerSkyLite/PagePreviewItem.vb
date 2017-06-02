Imports System.ComponentModel
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
                '没生成文章缓存文件夹的文章要改变标题颜色
                If Directory.Exists(DownloadDirectory) Then
                    'Debug.Print("存在：" & ReaderForm.CacheDirectory & Path.GetFileNameWithoutExtension(value))
                    DownloadButton.Text = "已存在文件数：" & Directory.GetFiles(DownloadDirectory).Count
                Else
                    'Debug.Print("不存在：" & ReaderForm.CacheDirectory & Path.GetFileNameWithoutExtension(value))
                    TitleLabel.ForeColor = Color.DeepSkyBlue
                End If

                '没下载预览图片的文章要斜体显示标题
                If File.Exists(ReaderForm.CacheDirectory & Path.GetFileName(value)) Then
                    ImagePreviewBox.Text = vbNullString
                    Using PreviewImageStream As FileStream = New FileStream(ReaderForm.CacheDirectory & Path.GetFileName(value), FileMode.Open)
                        ImagePreviewBox.Image = Image.FromStream(PreviewImageStream)
                    End Using

                    Exit Property
                Else
                    TitleLabel.Font = New Font(TitleLabel.Font, FontStyle.Italic Or FontStyle.Underline Or FontStyle.Bold)
                End If


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
            If (Not value.StartsWith("http://www.gamersky.com")) Then value = "http://www.gamersky.com" & value
            in_LinkAddress = value
        End Set
    End Property

#End Region

    '下载图像时声场HTML
    Dim HTMLWriter As StreamWriter

    '图像下载目录
    Private DownloadDirectory As String
    '记录已经下载的文件个数
    Private in_DownloadState As Integer
    '下载出错
    Private in_DownloadError As Integer
    '记录下载状态
    Private in_Downloading As Boolean
    '生成的HTML文件路径
    Private HTMLPath As String

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
        ItemID = Path.GetFileNameWithoutExtension(strImageLink)
        DownloadDirectory = ReaderForm.CacheDirectory & ItemID & "\"
        ImageLink = strImageLink
        Time = strTime
        LinkAddress = strLinkAddress
        HTMLPath = DownloadDirectory & Title & ".html"
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
            If ContentList.Count > 0 AndAlso in_DownloadState = ContentList.Count - 1 Then
                '已经下载完成
                ReaderForm.BrowseHTML(HTMLPath)
            Else
                '开始下载
                in_Downloading = True
                DownloadButton.Text = "正在解析文章页面..."
                DownloadButton.ForeColor = Color.DodgerBlue
                Try
                    GamerSkyHomeProcess.GetHTML(Me.LinkAddress, AddressOf AnalysisPage)
                Catch ex As Exception
                    in_Downloading = False
                    HTMLWriter.Close()
                    HTMLWriter.Dispose()
                    DownloadButton.Text = "文章内容解析失败"
                    DownloadButton.ForeColor = Color.Red
                    MessageBox.ShowMessagebox("异步访问时出错：" & LinkAddress, ex.Message, MessageBox.Icons._Error, ReaderForm)
                End Try
            End If
        Else
            '正在下载
            in_Downloading = False
            DownloadButton.Text = "已经停止下载"
            ContentList = New List(Of Content)
            in_DownloadState = 0
            in_DownloadError = 0
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
        If Not in_Downloading Then Exit Sub
        Dim MainPattern As String = "<([a-z]+)(?:(?!class)[^<>])*class=([""']?){0}\2[^>]*>(?>(?<o><\1[^>]*>)|(?<-o></\1>)|(?:(?!</?\1).))*(?(o)(?!))</\1>"
        Dim HTMLRegex As Regex, MatchResult As Match
        MainPattern = String.Format(MainPattern, Regex.Escape("Mid2L_con"))
        HTMLRegex = New Regex(MainPattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        MatchResult = HTMLRegex.Match(PageHTML)
        Dim MainHTML As String = MatchResult.Value
        If MainHTML = vbNullString Then
            MessageBox.ShowMessagebox("解析目录失败！", "未找到 class=Mid2L_con 的元素！", MessageBox.Icons._Error, ReaderForm)
            Exit Sub
        End If

        Dim ImageHTMLs As String()
        Dim TitlePattern As String
        Dim ItemRegex As Regex
        Dim ItemMatchResult As Match
        '分割，上部为正文内容，下部为页数导航"
        Dim ItemHTMLs As String() = Strings.Split(MainHTML, "<!--{pe.begin.pagination}-->", 2)

        If ItemHTMLs.Length < 2 Then DownloadButton.Text = "解析目录失败" : MessageBox.ShowMessagebox("解析目录失败！", "分割 class=Mid2L_con 元素未得到文章列表！", MessageBox.Icons._Error, ReaderForm) : Exit Sub
        ImageHTMLs = Strings.Split(ItemHTMLs(0), "</p>")
        For Index As Integer = 0 To ImageHTMLs.Length - 1
            If Not in_Downloading Then Exit Sub
            If InStr(ImageHTMLs(Index), "http://www.gamersky.com/showimage/id_gamersky.shtml?") Then
                TitlePattern = "<a.*?shtml\?(?<imagelink>.+?)"""
            Else
                TitlePattern = "<img.*?src=""(?<imagelink>.+?)"""
            End If
            ItemRegex = New Regex(TitlePattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            ItemMatchResult = ItemRegex.Match(ImageHTMLs(Index))
            Dim TempString As String() = Split(ImageHTMLs(Index), "</a>")
            If ItemMatchResult.Groups("imagelink").Value <> vbNullString Then
                ContentList.Add(New Content() With {
                                    .ImageLink = ItemMatchResult.Groups("imagelink").Value,
                                    .Text = IIf(TempString.Length > 1, TempString.Last, vbNullString)
                                    })
            End If
        Next
        '读取下一页
        TitlePattern = "<a href=""(?<nextpagelink>.+?)"">下一页</a>"
        ItemRegex = New Regex(TitlePattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        ItemMatchResult = ItemRegex.Match(ItemHTMLs(1))
        If Not in_Downloading Then Exit Sub
        If ItemMatchResult.Groups("nextpagelink").Value <> vbNullString Then
            ReaderForm.Invoke(
                Sub()
                    GamerSkyHomeProcess.GetHTML(ItemMatchResult.Groups("nextpagelink").Value, AddressOf AnalysisPage)
                End Sub)
        Else
            If Not in_Downloading Then HTMLWriter.Close() : HTMLWriter.Dispose() : Exit Sub
            Try
                File.WriteAllText(DownloadDirectory & "ImageLinks.txt", String.Join(vbCrLf, ContentList.Select(Function(content) content.ImageLink).ToArray()))
            Catch ex As Exception
            End Try
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
        ExportHTMLHead()

        Dim FileName As String = Path.GetFileName(ContentList(in_DownloadState).ImageLink)
        Dim ImagePath As String = DownloadDirectory & FileName
        Dim ImageWebClient As WebClient = New WebClient()
        AddHandler ImageWebClient.DownloadFileCompleted,
            Sub(sender As Object, e As AsyncCompletedEventArgs)
                If e.Error IsNot Nothing Or File.ReadAllBytes(ImagePath).Length = 0 Then
                    'MessageBox.ShowMessagebox("下载失败！" & in_DownloadState, e.Error.Message, MessageBox.Icons._Error, ReaderForm)
                    in_DownloadError += 1
                    Try
                        File.Delete(ImagePath)
                    Catch ex As Exception
                        'MessageBox.ShowMessagebox("下载失败，删除缓存失败！", ex.Message, MessageBox.Icons._Error, ReaderForm)
                    End Try
                End If

                If in_DownloadState >= ContentList.Count - 1 Then
                    DownloadCompleted()
                    Exit Sub
                Else
                    DownloadButton.Text = String.Format("下载进度：{0} / {1}", in_DownloadState, ContentList.Count)
                End If

                Do While File.Exists(ImagePath) And in_DownloadState < ContentList.Count - 1
                    If Not in_Downloading Then HTMLWriter.Close() : HTMLWriter.Dispose() : Exit Sub
                    in_DownloadState += 1
                    FileName = Path.GetFileName(ContentList(in_DownloadState).ImageLink)
                    If HTMLWriter IsNot Nothing Then HTMLWriter.WriteLine("<img src="".\{0}"" alt=""{1}""><br>{2}<br><hr>", FileName, ContentList(in_DownloadState).ImageLink, ContentList(in_DownloadState).Text)
                    ImagePath = DownloadDirectory & FileName
                Loop

                ImageWebClient.DownloadFileAsync(New Uri(ContentList(in_DownloadState).ImageLink), ImagePath)
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
        AddHandler LocationButton.MouseEnter, AddressOf MouseActiveEvent.MouseEnter
        AddHandler LocationButton.MouseLeave, AddressOf MouseActiveEvent.MouseLeave
        AddHandler LocationButton.MouseDown, AddressOf MouseActiveEvent.MouseDown
        AddHandler LocationButton.MouseUp, AddressOf MouseActiveEvent.MouseUp
        AddHandler DeleteButton.MouseEnter, AddressOf MouseActiveEvent.MouseEnter
        AddHandler DeleteButton.MouseLeave, AddressOf MouseActiveEvent.MouseLeave
        AddHandler DeleteButton.MouseDown, AddressOf MouseActiveEvent.MouseDown
        AddHandler DeleteButton.MouseUp, AddressOf MouseActiveEvent.MouseUp
    End Sub

    Private Sub DownloadCompleted()
        in_Downloading = False
        DownloadButton.Text = "成功：" & ContentList.Count & IIf(in_DownloadError > 0, " /失败：" & in_DownloadError, "")
        DownloadButton.ForeColor = Color.Green
        ExportHTMLFoot()
    End Sub

    Private Sub ExportHTMLHead()
        HTMLWriter?.Close()
        HTMLWriter?.Dispose()
        Try
            HTMLWriter = New StreamWriter(HTMLPath)
            HTMLWriter?.Write("<html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" /></head><body style=""width:70%;margin:0 auto""><center><pre><h1><strong>{0}</strong></h1></pre>" & vbCrLf, Title)
        Catch ex As Exception
            MessageBox.ShowMessagebox("生成精简HTML时出错！", ex.Message, MessageBox.Icons._Error, ReaderForm)
        End Try
    End Sub

    Private Sub ExportHTMLFoot()
        Try
            HTMLWriter?.Write(vbCrLf & "<<<< 文章结束 >>>></center></body></html>")
            HTMLWriter?.Close()
            HTMLWriter?.Dispose()
        Catch ex As Exception
            MessageBox.ShowMessagebox("生成精简HTML时出错！", ex.Message, MessageBox.Icons._Error, ReaderForm)
        End Try
    End Sub

    Private Sub TitleLabel_Click(sender As Object, e As EventArgs) Handles TitleLabel.Click
        If File.Exists(HTMLPath) Then ReaderForm.BrowseHTML(HTMLPath)
    End Sub

    Private Sub LocationButton_Click(sender As Object, e As EventArgs) Handles LocationButton.Click
        If Directory.Exists(Me.DownloadDirectory) Then Process.Start(Me.DownloadDirectory)
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If Directory.Exists(Me.DownloadDirectory) Then
            If in_Downloading Then
                in_Downloading = False
                DownloadButton.Text = "已经停止下载"
                ContentList = New List(Of Content)
                in_DownloadState = 0
                in_DownloadError = 0
            End If

            For Each FilePath As String In Directory.GetFiles(DownloadDirectory)
                Try
                    FileSystem.Kill(FilePath)
                Catch ex As Exception
                    'MessageBox.ShowMessagebox("删除文章缓存失败！", ex.Message, MessageBox.Icons._Error, ReaderForm)
                End Try
            Next
            Try
                Directory.Delete(DownloadDirectory)
            Catch ex As Exception
                '
            End Try
        End If
        If Directory.Exists(Me.DownloadDirectory) Then
            DownloadButton.Text = "已存在文件数：" & Directory.GetFiles(DownloadDirectory).Count
        Else
            DownloadButton.Text = ""
        End If
    End Sub
End Class
