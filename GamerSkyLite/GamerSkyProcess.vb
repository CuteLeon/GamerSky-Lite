Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions

Public Module GamerSkyHomeProcess

    Public Sub ScanHome(HomeLink As String)
        GetHTML(HomeLink, AddressOf AnalysisHome)
    End Sub

    Public Sub GetHTML(LinkAddress As String, AnalysisFunction As Action(Of String))
        Try
            Dim WebClientObject As WebClient = New WebClient With {
                .BaseAddress = LinkAddress, .Encoding = Encoding.UTF8}
            WebClientObject.Credentials = CredentialCache.DefaultCredentials
            AddHandler WebClientObject.DownloadStringCompleted,
                Sub(sender As Object, e As DownloadStringCompletedEventArgs)
                    If Not e.Error Is Nothing Then MessageBox.ShowMessagebox("异步读取时出错：" & LinkAddress, e.Error.Message, MessageBox.Icons._Error, ReaderForm) : Exit Sub
                    AnalysisFunction(e.Result)
                End Sub
            WebClientObject.DownloadStringAsync(New Uri(LinkAddress))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AnalysisHome(HomeHTML As String)
        '这段正则很神奇！勿动！
        Dim CatalogPattern As String = "<([a-z]+)(?:(?!class)[^<>])*class=([""']?){0}\2[^>]*>(?>(?<o><\1[^>]*>)|(?<-o></\1>)|(?:(?!</?\1).))*(?(o)(?!))</\1>"
        Dim HTMLRegex As Regex, MatchResult As Match
        '正则匹配出目录HTML
        CatalogPattern = String.Format(CatalogPattern, Regex.Escape("pictxt contentpaging"))
        HTMLRegex = New Regex(CatalogPattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        MatchResult = HTMLRegex.Match(HomeHTML)
        Dim CatalogHTML As String = MatchResult.Value
        If CatalogHTML = vbNullString Then MessageBox.ShowMessagebox("解析目录失败！", "未找到 class=pictxt contentpaging 的元素！", MessageBox.Icons._Error, ReaderForm) : Exit Sub
        Dim ItemHTMLs As String() = Strings.Split(CatalogHTML, "</li>")
        If ItemHTMLs.Length = 0 Then MessageBox.ShowMessagebox("解析目录失败！", "分割 class=pictxt contentpaging 元素未得到文章列表！", MessageBox.Icons._Error, ReaderForm) : Exit Sub
        Dim TitlePattern As String = "<a href.*?=.*?""(?<link>.+?)"".*?target=.*?""_blank"">.*?<img src.*?=.*?""(?<image>.+?)"" alt.*?title=""(?<title>.+?)"".*?>.*?<div Class.*?=.*?""txt"".*?>(?<text>.+?)</div>.*?<div Class.*?=.*?""time"".*?>(?<time>.+?)</div>.*?<div.*?>"
        Dim ItemRegex As Regex = New Regex(TitlePattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        For Index As Integer = 0 To ItemHTMLs.Length - 2
            Dim ItemMatchResult As Match = ItemRegex.Match(ItemHTMLs(Index))
            Dim T As PagePreviewItem = New PagePreviewItem(
                ItemMatchResult.Groups("title").Value,
                ItemMatchResult.Groups("text").Value.Replace(vbCrLf, "").Replace(vbCr, "").Replace(vbLf, ""),
                ItemMatchResult.Groups("image").Value,
                ItemMatchResult.Groups("time").Value,
            ItemMatchResult.Groups("link").Value)
            T.Left = 0
            T.Top = Index * T.Height
            ReaderForm.PreviewItemPanel.Controls.Add(T)
            T.Show()
        Next
    End Sub

End Module
