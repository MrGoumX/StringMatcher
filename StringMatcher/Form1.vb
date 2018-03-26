Public Class StringMatcher

    Dim String1T As String
    Dim String2T As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles KMPMatch.Click
        String1T = String1.Text.ToLower()
        String2T = String2.Text.ToLower()
        If String1T.Length < String2T.Length Then
            Dim temp = String1T
            String1T = String2T
            String2T = temp
        End If
        Dim STC = ToCheck(String2T)
        Dim Final = KMP(String1T, STC)
        MessageBox.Show("The Strings Are " & Final & "% Identical With KMP Algorithm")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles BMMatch.Click
        String1T = String1.Text.ToLower()
        String2T = String2.Text.ToLower()
        If String1T.Length < String2T.Length Then
            Dim temp = String1T
            String1T = String2T
            String2T = temp
        End If
        Dim STC = ToCheck(String2T)
        Dim Final = BM(String1T, STC)
        MessageBox.Show("The Strings Are " & Final & "% Identical With BM Algorithm")
    End Sub

    Private Shared Function ToCheck(str2 As String) As List(Of String)
        Dim Fin As Integer = 1
        Dim PosSubStrings As New List(Of String)
        While Fin <= str2.Length
            For s As Integer = 0 To (str2.Length - Fin)
                Dim temp2 = str2.Substring(s, Fin)
                If Not PosSubStrings.Contains(temp2) Then
                    PosSubStrings.Add(temp2)
                End If
            Next
            Fin += 1
        End While
        Dim words As String() = str2.Split(New Char() {" "c})
        Dim temp As String = ""
        Dim max As Integer = Convert.ToInt32(Math.Pow(2, words.Count()))
        Dim bin As String = ""
        For s As Integer = 1 To max - 1
            bin = Convert.ToString(s, 2).PadLeft(words.Count(), Convert.ToChar("0"))
            For x As Integer = 0 To bin.Length - 1
                If bin.Substring(x, 1) = "1" Then
                    temp &= (words(x) & " ")
                End If
            Next
            If Not PosSubStrings.Contains(temp) Then
                PosSubStrings.Add(temp)
            End If
            temp = String.Empty
        Next
        Return PosSubStrings
    End Function

    Private Shared Function KMP(str As String, STC As List(Of String)) As Double
        Dim Counter As Integer = 0
        Dim Checks As Integer = 0
        For x As Integer = 0 To STC.Count - 1
            Dim pat = STC.Item(x)
            Dim K As Integer = pat.Length
            Dim L As Integer = str.Length
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim tc As Integer() = New Integer(K - 1) {}
            ArrToCheck(pat, K, tc)
            While i < L
                If pat(j) = str(i) Then
                    j += 1
                    i += 1
                End If
                If j = K Then
                    Checks += 1
                    Counter += 1
                    j = tc(j - 1)
                ElseIf i < L AndAlso pat(j) <> str(i) Then
                    If j <> 0 Then
                        j = tc(j - 1)
                    Else
                        i = i + 1
                    End If
                    Counter += 1
                End If
            End While
        Next
        Dim Final As Double = Checks / Counter * 100
        Final = Truncate(Final, 3)
        Return Final
    End Function

    Private Shared Sub ArrToCheck(pat As String, m As Integer, atc As Integer())
        Dim len As Integer = 0
        Dim i As Integer = 1
        atc(0) = 0

        While i < m
            If pat(i) = pat(len) Then
                len += 1
                atc(i) = len
                i += 1
            Else
                If len <> 0 Then
                    len = atc(len - 1)
                Else
                    atc(i) = 0
                    i += 1
                End If
            End If
        End While
    End Sub

    Private Shared Function BM(str As String, STC As List(Of String)) As Double
        Dim Counter As Integer = 0
        Dim Checks As Integer = 0
        For x As Integer = 0 To STC.Count - 1
            Dim pat = STC.Item(x)
            Dim k As Integer = pat.Length
            Dim l As Integer = str.Length
            Dim badChar As Integer() = New Integer(255) {}
            BCH(pat, k, badChar)
            Dim s As Integer = 0
            While s <= (l - k)
                Dim j As Integer = k - 1
                While j >= 0 AndAlso pat(j) = str(s + j)
                    j -= 1
                End While
                If j < 0 Then
                    Checks += 1
                    Counter += 1
                    s += If((s + k < l), k - badChar(AscW(str(s + k))), 1)
                Else
                    s += Math.Max(1, j - badChar(AscW(str(s + j))))
                    Counter += 1
                End If
            End While
        Next
        Dim Final As Double = Checks / Counter * 100
        Final = Truncate(Final, 3)
        Return Final
    End Function

    Private Shared Sub BCH(str As String, size As Integer, ByRef badChar As Integer())
        Dim i As Integer
        For i = 0 To 255
            badChar(i) = -1
        Next
        For i = 0 To size - 1
            badChar(AscW(str(i))) = i
        Next
    End Sub

    Private Shared Function Truncate(ByVal value As Double, ByVal dec As Integer) As Double
        Return Math.Round(value - 0.5 / Math.Pow(10, dec), dec)
    End Function

End Class
