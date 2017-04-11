Public Class MouseActiveEvent
    Private Declare Function ReleaseCapture Lib "user32" () As Integer
    Private Declare Function SendMessageA Lib "user32" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, lParam As VariantType) As Integer

    Public Shared Sub MoveWindow(sender As Object, e As MouseEventArgs)
        ReleaseCapture()
        SendMessageA(CType(sender, Form).Handle, &HA1, 2, 0&)
    End Sub

    Public Shared Sub MoveWindowByControl(sender As Object, e As MouseEventArgs)
        ReleaseCapture()
        SendMessageA(CType(sender, Control).FindForm.Handle, &HA1, 2, 0&)
    End Sub

    Public Shared Sub MouseEnter(sender As Object, e As EventArgs)
        CType(sender, Label).Image = My.Resources.UnityResource.ResourceManager.GetObject(CType(sender, Label).Tag & "1")
    End Sub

    Public Shared Sub MouseLeave(sender As Object, e As EventArgs)
        CType(sender, Label).Image = My.Resources.UnityResource.ResourceManager.GetObject(CType(sender, Label).Tag & "0")
    End Sub

    Public Shared Sub MouseDown(sender As Object, e As MouseEventArgs)
        CType(sender, Label).Image = My.Resources.UnityResource.ResourceManager.GetObject(CType(sender, Label).Tag & "2")
    End Sub

    Public Shared Sub MouseUp(sender As Object, e As MouseEventArgs)
        CType(sender, Label).Image = My.Resources.UnityResource.ResourceManager.GetObject(CType(sender, Label).Tag & "1")
    End Sub
End Class
