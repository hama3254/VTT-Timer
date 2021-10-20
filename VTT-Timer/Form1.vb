Public Class Form1
    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        Dim InputText As String = RichTextBox1.Text
        RichTextBox1.Text = Nothing
        Dim WakaTime As Date = Date.Parse(wakawaka.Text)
        Dim FuniTime As Date = Date.Parse(funi.Text)

        'MsgBox(WakaTime.ToString + "." + WakaTime.Millisecond.ToString)

        Dim Differnce As TimeSpan = FuniTime.Subtract(WakaTime)
        'Dim Differnce2 As Date = Date.Parse(Differnce.ToString)

        'MsgBox(Differnce2.ToString + " " + Differnce2.Millisecond.ToString + "ms")
        Try


            Dim sub_split As String() = InputText.Split(New String() {vbLf}, System.StringSplitOptions.RemoveEmptyEntries)
            For i As Integer = 0 To sub_split.Count - 1
                If InStr(sub_split(i), " --> ") Then
                    Dim sub_split1 As String() = sub_split(i).Split(New String() {" --> "}, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim Zeile As String = sub_split(i)
                    For i2 As Integer = 0 To sub_split1.Count - 1
                        Dim TimeStamp As String = Nothing
                        If InStr(sub_split1(i2), " ") Then
                            Dim sub_split2 As String() = sub_split1(i2).Split(New String() {" "}, System.StringSplitOptions.RemoveEmptyEntries)
                            TimeStamp = sub_split2(0)
                        Else
                            TimeStamp = sub_split1(i2)
                        End If
                        'MsgBox(TimeStamp)
                        Dim OldTime As Date = Date.Parse(TimeStamp)
                        Dim NewTime As Date = OldTime.Add(Differnce)
                        'MsgBox(NewTime.ToString + " " + NewTime.Millisecond.ToString + "ms")
                        Zeile = Zeile.Replace(TimeStamp, String.Format("{0:00}", NewTime.Hour) + ":" + String.Format("{0:00}", NewTime.Minute) + ":" + String.Format("{0:00}", NewTime.Second) + "." + String.Format("{0:000}", NewTime.Millisecond))
                    Next
                    RichTextBox1.AppendText(vbLf)
                    RichTextBox1.AppendText(Zeile)
                    RichTextBox1.AppendText(vbLf)
                Else
                    RichTextBox1.AppendText(sub_split(i))
                    RichTextBox1.AppendText(vbLf)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class
