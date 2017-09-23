<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReaderForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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
        Me.CloseButton = New System.Windows.Forms.Label()
        Me.MinButton = New System.Windows.Forms.Label()
        Me.MaxButton = New System.Windows.Forms.Label()
        Me.RestoreButton = New System.Windows.Forms.Label()
        Me.LogoLabel = New System.Windows.Forms.Label()
        Me.HTMLBrowser = New System.Windows.Forms.WebBrowser()
        Me.ToolPanel = New GamerSkyLite.MyPanel()
        Me.CleanButton = New System.Windows.Forms.Label()
        Me.GoBackButton = New System.Windows.Forms.Label()
        Me.RefreshButton = New System.Windows.Forms.Label()
        Me.PreviewItemPanel = New GamerSkyLite.MyPanel()
        Me.ToolPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.Color.Transparent
        Me.CloseButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Close_0
        Me.CloseButton.Location = New System.Drawing.Point(885, 5)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(20, 20)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Tag = "Close_"
        '
        'MinButton
        '
        Me.MinButton.BackColor = System.Drawing.Color.Transparent
        Me.MinButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Min_0
        Me.MinButton.Location = New System.Drawing.Point(833, 5)
        Me.MinButton.Name = "MinButton"
        Me.MinButton.Size = New System.Drawing.Size(20, 20)
        Me.MinButton.TabIndex = 1
        Me.MinButton.Tag = "Min_"
        '
        'MaxButton
        '
        Me.MaxButton.BackColor = System.Drawing.Color.Transparent
        Me.MaxButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Max_0
        Me.MaxButton.Location = New System.Drawing.Point(859, 5)
        Me.MaxButton.Name = "MaxButton"
        Me.MaxButton.Size = New System.Drawing.Size(20, 20)
        Me.MaxButton.TabIndex = 2
        Me.MaxButton.Tag = "Max_"
        '
        'RestoreButton
        '
        Me.RestoreButton.BackColor = System.Drawing.Color.Transparent
        Me.RestoreButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Restore_0
        Me.RestoreButton.Location = New System.Drawing.Point(859, 5)
        Me.RestoreButton.Name = "RestoreButton"
        Me.RestoreButton.Size = New System.Drawing.Size(20, 20)
        Me.RestoreButton.TabIndex = 3
        Me.RestoreButton.Tag = "Restore_"
        Me.RestoreButton.Visible = False
        '
        'LogoLabel
        '
        Me.LogoLabel.BackColor = System.Drawing.Color.Transparent
        Me.LogoLabel.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LogoLabel.ForeColor = System.Drawing.Color.White
        Me.LogoLabel.Location = New System.Drawing.Point(5, 5)
        Me.LogoLabel.Name = "LogoLabel"
        Me.LogoLabel.Size = New System.Drawing.Size(370, 23)
        Me.LogoLabel.TabIndex = 4
        Me.LogoLabel.Text = "GamerSky-Lite [需求才是第一生产力！—Leon]"
        Me.LogoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HTMLBrowser
        '
        Me.HTMLBrowser.Location = New System.Drawing.Point(234, 37)
        Me.HTMLBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.HTMLBrowser.Name = "HTMLBrowser"
        Me.HTMLBrowser.Size = New System.Drawing.Size(766, 494)
        Me.HTMLBrowser.TabIndex = 13
        Me.HTMLBrowser.Visible = False
        '
        'ToolPanel
        '
        Me.ToolPanel.BackColor = System.Drawing.Color.Transparent
        Me.ToolPanel.BackgroundImage = Global.GamerSkyLite.My.Resources.UnityResource.ToolBG
        Me.ToolPanel.Controls.Add(Me.CleanButton)
        Me.ToolPanel.Controls.Add(Me.GoBackButton)
        Me.ToolPanel.Controls.Add(Me.RefreshButton)
        Me.ToolPanel.Location = New System.Drawing.Point(0, 150)
        Me.ToolPanel.Name = "ToolPanel"
        Me.ToolPanel.Size = New System.Drawing.Size(75, 250)
        Me.ToolPanel.TabIndex = 11
        '
        'CleanButton
        '
        Me.CleanButton.BackColor = System.Drawing.Color.Transparent
        Me.CleanButton.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CleanButton.ForeColor = System.Drawing.Color.White
        Me.CleanButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Clean_0
        Me.CleanButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CleanButton.Location = New System.Drawing.Point(13, 169)
        Me.CleanButton.Name = "CleanButton"
        Me.CleanButton.Size = New System.Drawing.Size(48, 66)
        Me.CleanButton.TabIndex = 16
        Me.CleanButton.Tag = "Clean_"
        Me.CleanButton.Text = "清理"
        Me.CleanButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GoBackButton
        '
        Me.GoBackButton.BackColor = System.Drawing.Color.Transparent
        Me.GoBackButton.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GoBackButton.ForeColor = System.Drawing.Color.White
        Me.GoBackButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.GoBack_0
        Me.GoBackButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.GoBackButton.Location = New System.Drawing.Point(13, 93)
        Me.GoBackButton.Name = "GoBackButton"
        Me.GoBackButton.Size = New System.Drawing.Size(48, 66)
        Me.GoBackButton.TabIndex = 15
        Me.GoBackButton.Tag = "GoBack_"
        Me.GoBackButton.Text = "返回"
        Me.GoBackButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'RefreshButton
        '
        Me.RefreshButton.BackColor = System.Drawing.Color.Transparent
        Me.RefreshButton.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RefreshButton.ForeColor = System.Drawing.Color.White
        Me.RefreshButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Refresh_0
        Me.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RefreshButton.Location = New System.Drawing.Point(13, 17)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(48, 66)
        Me.RefreshButton.TabIndex = 14
        Me.RefreshButton.Tag = "Refresh_"
        Me.RefreshButton.Text = "刷新"
        Me.RefreshButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PreviewItemPanel
        '
        Me.PreviewItemPanel.AutoScroll = True
        Me.PreviewItemPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PreviewItemPanel.Location = New System.Drawing.Point(139, 64)
        Me.PreviewItemPanel.Name = "PreviewItemPanel"
        Me.PreviewItemPanel.Size = New System.Drawing.Size(766, 494)
        Me.PreviewItemPanel.TabIndex = 0
        '
        'ReaderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GamerSkyLite.My.Resources.UnityResource.BGI
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(913, 593)
        Me.Controls.Add(Me.PreviewItemPanel)
        Me.Controls.Add(Me.HTMLBrowser)
        Me.Controls.Add(Me.ToolPanel)
        Me.Controls.Add(Me.LogoLabel)
        Me.Controls.Add(Me.MaxButton)
        Me.Controls.Add(Me.MinButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.RestoreButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ReaderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GamerSky Lite"
        Me.ToolPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CloseButton As Label
    Friend WithEvents MinButton As Label
    Friend WithEvents MaxButton As Label
    Friend WithEvents RestoreButton As Label
    Friend WithEvents LogoLabel As Label
    Friend WithEvents PreviewItemPanel As MyPanel
    Friend WithEvents ToolPanel As MyPanel
    Friend WithEvents CleanButton As Label
    Friend WithEvents GoBackButton As Label
    Friend WithEvents RefreshButton As Label
    Friend WithEvents HTMLBrowser As WebBrowser
End Class
