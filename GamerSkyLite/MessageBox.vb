Public Class MessageBox
    Public Enum Icons
        Info = 0
        _Error = 1
        Warning = 2
        Question = 3
    End Enum

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(Title As String, Message As String, Icon As Icons)
        InitializeComponent()
        TitleLabel.Text = Title
        MessageLabel.Text = Message
        IconLabel.Image = My.Resources.UnityResource.ResourceManager.GetObject(Icon.ToString)
        If (Icon = Icons.Question) Then
            CancelButton.Show()
            CancelButton.Left = 107
            OKButton.Left = 207
        End If
    End Sub

    Public Shared Sub ShowMessagebox(Title As String, Message As String, Icon As Icons, Owner As Form)
        Dim NewMessageBox As MessageBox = New MessageBox(Title, Message, Icon)
        NewMessageBox.ShowDialog(Owner)
    End Sub

    Private Sub MessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Me.MouseDown, AddressOf MouseActiveEvent.MoveWindow
        For Each LabelControl As Label In New Label() {TitleLabel, MessageLabel, IconLabel}
            AddHandler LabelControl.MouseDown, AddressOf MouseActiveEvent.MoveWindowByControl
        Next
        For Each LabelButton As Label In New Label() {CancelButton, OKButton, CloseButton}
            AddHandler LabelButton.MouseEnter, AddressOf MouseActiveEvent.MouseEnter
            AddHandler LabelButton.MouseLeave, AddressOf MouseActiveEvent.MouseLeave
            AddHandler LabelButton.MouseDown, AddressOf MouseActiveEvent.MouseDown
            AddHandler LabelButton.MouseUp, AddressOf MouseActiveEvent.MouseUp
        Next
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class