Public Class MyPanel
    '继承基类 Panel
    Inherits Panel

    Public Sub New()
        '覆写初始化事件，有效防止闪烁
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor, True)
    End Sub

End Class
