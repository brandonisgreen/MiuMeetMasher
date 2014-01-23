Imports System.Net
Imports System.IO
Imports Shell32
Public Class AccountGenerator
    Dim myDirectory As String = My.Application.Info.DirectoryPath
    Dim tempUser As String
    Dim tempEmail As String
    Dim tempMonth = "1"
    Dim tempDay = "1"
    Dim tempYear = "1991"
    Dim breakingBarriers = "mixed_race"
    Dim gender = "1"
    Dim pngtime As Date
    Dim pngname As String
    Dim dasfile As String
    Dim captchaDownload As String
    Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearmeout()
        WebBrowser1.Navigate("http://www.miumeet.com/logout")
    End Sub

    Dim curStep = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If curStep = 0 Then
            WebBrowser1.Document.InvokeScript("showFrame", _
            New String() {"Register"})
        ElseIf curStep = 1 Then

            Dim sr As New System.IO.StreamReader(myDirectory & "\base.txt")
            Dim sr2 As New System.IO.StreamReader(myDirectory & "\base.txt")
            Dim i As Integer = 0
            Dim curline As Integer = 0
            Dim ran As Integer = 0
            Do Until sr.EndOfStream = True
                sr.ReadLine()
                i += 1
            Loop
            sr.Dispose()
            sr.Close()
            Randomize()
            ran = Rnd() * i
            Do Until ran = curline
                tempUser = sr2.ReadLine()
                curline += 1
            Loop


            WebBrowser1.Document.GetElementById("f_Register_username").InnerText = tempUser
            WebBrowser1.Document.GetElementById("f_Register_email").InnerText = tempUser & "@mailinator.com"
            'option
            For Each element As HtmlElement In WebBrowser1.Document.GetElementsByTagName("select")
                If element.GetAttribute("id") = "f_Register_date_month" Then
                    element.SetAttribute("value", tempMonth)
                ElseIf element.GetAttribute("id") = "f_Register_date_day" Then
                    element.SetAttribute("value", tempDay)
                ElseIf element.GetAttribute("id") = "f_Register_date_year" Then
                    element.SetAttribute("value", tempYear)
                ElseIf element.GetAttribute("id") = "f_Register_gender" Then
                    element.SetAttribute("value", gender)
                ElseIf element.GetAttribute("id") = "f_Register_gender" Then
                    element.SetAttribute("value", gender)
                ElseIf element.GetAttribute("id") = "f_Register_ethnicity" Then
                    element.SetAttribute("value", breakingBarriers)
                End If
            Next
            WebBrowser1.Document.GetElementById("f_Register_password").InnerText = "!!qwerty"
        ElseIf curStep = 2 Then
                WebBrowser1.Document.InvokeScript("frameAction", _
                New String() {"Register", "CheckSubmit"})
        ElseIf curStep = 3 Then
                Dim client As New WebClient
                Dim captchafile = ""
                For Each img As HtmlElement In WebBrowser1.Document.GetElementsByTagName("img")
                    If img.GetAttribute("id") = "f_Register_captcha_img" Then
                        captchafile = img.GetAttribute("src")

                    End If
                Next
                pngtime = Now
                pngname = pngtime.ToString("ymdHHMM")
                Dim dasfile = pngname & ".png"
                Dim captchaDownload = myDirectory & "\" & dasfile
                client.DownloadFile(captchafile, captchaDownload)
        ElseIf curStep = 4 Then
                Dim tesseract As New ProcessStartInfo
                tesseract.FileName = "tesseract.exe"
                tesseract.Arguments = pngname & ".png " & pngname
                Dim proc As Process = Process.Start(tesseract)
        ElseIf curStep = 6 Then
                Dim tesseract_output As String = pngname & ".txt"
                Dim objReader As New System.IO.StreamReader(tesseract_output)
                Dim solved = objReader.ReadToEnd
                objReader.Close()
            If solved = 85753 Then
                WebBrowser1.Document.GetElementById("f_Register_captcha").InnerText = 85763
            Else
                WebBrowser1.Document.GetElementById("f_Register_captcha").InnerText = solved
            End If

        End If
        curStep += 1
    End Sub
    Dim firstWB1Load = 0
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If firstWB1Load = 0 Then
            Timer1.Start()
            firstWB1Load = 1
        End If
    End Sub
    Sub clearmeout()
        'Temporary Internet Files
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8")
        'Cookies()
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2")
        'History()
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1")
        'Form(Data)
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 16")
        'Passwords()
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 32")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
    Sub getEmail()
    End Sub

    Private Sub WebBrowser2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

    End Sub
End Class