Public NotInheritable Class SplashScreen1
    Dim myDirectory As String = My.Application.Info.DirectoryPath
    Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Timer1.Start()

    End Sub
    Dim count = 0
    Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        count += 1
        If count = 1 Then
            If IO.File.Exists(myDirectory & "\t ocr.zip") Then
                MsgBox("Tesseract exists already.")
                Me.Close()
            Else
                System.IO.File.WriteAllText(myDirectory & "\base.txt", My.Resources.base)
                System.IO.File.WriteAllBytes(myDirectory & "\t ocr.zip", My.Resources.t_ocr)
                Dim sc As New Shell32.Shell()
                Dim output As Shell32.Folder = sc.NameSpace(myDirectory)
                Dim input As Shell32.Folder = sc.NameSpace(myDirectory & "\t ocr.zip")
                output.CopyHere(input.Items, 4)

                Me.Close()
            End If
        End If
    End Sub
End Class
