<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PagePreviewItem
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ImagePreviewBox = New System.Windows.Forms.Label()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.TextLabel = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.DownloadButton = New System.Windows.Forms.Label()
        Me.BrowserButton = New System.Windows.Forms.Label()
        Me.LocationButton = New System.Windows.Forms.Label()
        Me.DeleteButton = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ImagePreviewBox
        '
        Me.ImagePreviewBox.BackColor = System.Drawing.Color.Transparent
        Me.ImagePreviewBox.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ImagePreviewBox.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.ImagePreviewBox.Location = New System.Drawing.Point(6, 10)
        Me.ImagePreviewBox.Name = "ImagePreviewBox"
        Me.ImagePreviewBox.Size = New System.Drawing.Size(200, 112)
        Me.ImagePreviewBox.TabIndex = 12
        Me.ImagePreviewBox.Text = "正在下载图像..."
        Me.ImagePreviewBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimeLabel
        '
        Me.TimeLabel.BackColor = System.Drawing.Color.Transparent
        Me.TimeLabel.CausesValidation = False
        Me.TimeLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TimeLabel.ForeColor = System.Drawing.Color.DarkGray
        Me.TimeLabel.Image = Global.GamerSkyLite.My.Resources.UnityResource.ClockIcon
        Me.TimeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TimeLabel.Location = New System.Drawing.Point(216, 101)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(130, 18)
        Me.TimeLabel.TabIndex = 11
        Me.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextLabel
        '
        Me.TextLabel.BackColor = System.Drawing.Color.Transparent
        Me.TextLabel.CausesValidation = False
        Me.TextLabel.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.TextLabel.Location = New System.Drawing.Point(216, 41)
        Me.TextLabel.Name = "TextLabel"
        Me.TextLabel.Size = New System.Drawing.Size(480, 60)
        Me.TextLabel.TabIndex = 10
        Me.TextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TitleLabel
        '
        Me.TitleLabel.BackColor = System.Drawing.Color.Transparent
        Me.TitleLabel.CausesValidation = False
        Me.TitleLabel.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.Color.DimGray
        Me.TitleLabel.Location = New System.Drawing.Point(216, 11)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(410, 30)
        Me.TitleLabel.TabIndex = 9
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DownloadButton
        '
        Me.DownloadButton.BackColor = System.Drawing.Color.White
        Me.DownloadButton.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DownloadButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.DownloadButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Download_0
        Me.DownloadButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DownloadButton.Location = New System.Drawing.Point(484, 101)
        Me.DownloadButton.Name = "DownloadButton"
        Me.DownloadButton.Size = New System.Drawing.Size(167, 20)
        Me.DownloadButton.TabIndex = 13
        Me.DownloadButton.Tag = "Download_"
        '
        'BrowserButton
        '
        Me.BrowserButton.BackColor = System.Drawing.Color.White
        Me.BrowserButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Browser_0
        Me.BrowserButton.Location = New System.Drawing.Point(660, 8)
        Me.BrowserButton.Name = "BrowserButton"
        Me.BrowserButton.Size = New System.Drawing.Size(32, 32)
        Me.BrowserButton.TabIndex = 14
        Me.BrowserButton.Tag = "Browser_"
        '
        'LocationButton
        '
        Me.LocationButton.BackColor = System.Drawing.Color.White
        Me.LocationButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Location_0
        Me.LocationButton.Location = New System.Drawing.Point(627, 8)
        Me.LocationButton.Name = "LocationButton"
        Me.LocationButton.Size = New System.Drawing.Size(32, 32)
        Me.LocationButton.TabIndex = 15
        Me.LocationButton.Tag = "Location_"
        '
        'DeleteButton
        '
        Me.DeleteButton.BackColor = System.Drawing.Color.White
        Me.DeleteButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Delete_0
        Me.DeleteButton.Location = New System.Drawing.Point(660, 90)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(32, 32)
        Me.DeleteButton.TabIndex = 16
        Me.DeleteButton.Tag = "Delete_"
        '
        'PagePreviewItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImage = Global.GamerSkyLite.My.Resources.UnityResource.PaperShadow
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.LocationButton)
        Me.Controls.Add(Me.BrowserButton)
        Me.Controls.Add(Me.DownloadButton)
        Me.Controls.Add(Me.ImagePreviewBox)
        Me.Controls.Add(Me.TimeLabel)
        Me.Controls.Add(Me.TextLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.DoubleBuffered = True
        Me.Name = "PagePreviewItem"
        Me.Size = New System.Drawing.Size(702, 138)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImagePreviewBox As Label
    Private WithEvents TimeLabel As Label
    Private WithEvents TextLabel As Label
    Private WithEvents TitleLabel As Label
    Friend WithEvents DownloadButton As Label
    Friend WithEvents BrowserButton As Label
    Friend WithEvents LocationButton As Label
    Friend WithEvents DeleteButton As Label
End Class
