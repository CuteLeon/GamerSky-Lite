<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageBox
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.MessageLabel = New System.Windows.Forms.Label()
        Me.IconLabel = New System.Windows.Forms.Label()
        Me.CancelButton = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TitleLabel
        '
        Me.TitleLabel.BackColor = System.Drawing.Color.Transparent
        Me.TitleLabel.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.Color.Snow
        Me.TitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TitleLabel.Location = New System.Drawing.Point(8, 1)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(335, 32)
        Me.TitleLabel.TabIndex = 0
        Me.TitleLabel.Text = "GamerSky Lite"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MessageLabel
        '
        Me.MessageLabel.BackColor = System.Drawing.Color.Transparent
        Me.MessageLabel.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MessageLabel.ForeColor = System.Drawing.Color.White
        Me.MessageLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.MessageLabel.Location = New System.Drawing.Point(74, 39)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(300, 90)
        Me.MessageLabel.TabIndex = 1
        Me.MessageLabel.Text = "GamerSky Lite"
        Me.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IconLabel
        '
        Me.IconLabel.BackColor = System.Drawing.Color.Transparent
        Me.IconLabel.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.IconLabel.ForeColor = System.Drawing.Color.White
        Me.IconLabel.Location = New System.Drawing.Point(11, 61)
        Me.IconLabel.Name = "IconLabel"
        Me.IconLabel.Size = New System.Drawing.Size(55, 55)
        Me.IconLabel.TabIndex = 2
        Me.IconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CancelButton
        '
        Me.CancelButton.BackColor = System.Drawing.Color.Transparent
        Me.CancelButton.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CancelButton.ForeColor = System.Drawing.Color.White
        Me.CancelButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.SmallButton_0
        Me.CancelButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CancelButton.Location = New System.Drawing.Point(157, 135)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(66, 30)
        Me.CancelButton.TabIndex = 3
        Me.CancelButton.Tag = "SmallButton_"
        Me.CancelButton.Text = "取消"
        Me.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CancelButton.Visible = False
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.Color.Transparent
        Me.OKButton.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OKButton.ForeColor = System.Drawing.Color.White
        Me.OKButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.SmallButton_0
        Me.OKButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.OKButton.Location = New System.Drawing.Point(157, 135)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(66, 30)
        Me.OKButton.TabIndex = 4
        Me.OKButton.Tag = "SmallButton_"
        Me.OKButton.Text = "确定"
        Me.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.Color.Transparent
        Me.CloseButton.Image = Global.GamerSkyLite.My.Resources.UnityResource.Close_0
        Me.CloseButton.Location = New System.Drawing.Point(353, 7)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(20, 20)
        Me.CloseButton.TabIndex = 5
        Me.CloseButton.Tag = "Close_"
        '
        'MessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GamerSkyLite.My.Resources.UnityResource.MessageBoxBGI
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(380, 170)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.IconLabel)
        Me.Controls.Add(Me.MessageLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.CancelButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TitleLabel As Label
    Friend WithEvents MessageLabel As Label
    Friend WithEvents IconLabel As Label
    Friend Shadows WithEvents CancelButton As Label
    Friend WithEvents OKButton As Label
    Friend WithEvents CloseButton As Label
End Class
