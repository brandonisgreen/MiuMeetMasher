Public Class Form1

    Private Sub CreateAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAccountsToolStripMenuItem.Click
        Dim accGenForm As New AccountGenerator()
        accGenForm.MdiParent = Me
        accGenForm.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim myDirectory As String = My.Application.Info.DirectoryPath
        If IO.File.Exists(myDirectory & "\t ocr.zip") Then

        Else
            Dim extractTesseract As New SplashScreen1()
            extractTesseract.MdiParent = Me
            extractTesseract.Show()
        End If
    End Sub
End Class
