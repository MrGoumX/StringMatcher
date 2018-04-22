Imports System.IO
Imports System.Text

Public Class StringMatcher

    Dim String1T As String
    Dim String2T As String

    Private Shared Async Function SymmetricMatch(ByVal original As String, ByVal modified As String) As Task(Of Double)
        Dim n As Integer = original.Length
        Dim m As Integer = modified.Length
        Dim d(n + 1, m + 1) As Integer
        If n = 0 Then
            Return m
        End If
        If m = 0 Then
            Return n
        End If
        Dim i As Integer
        Dim j As Integer
        For i = 0 To n
            d(i, 0) = i
        Next
        For j = 0 To m
            d(0, j) = j
        Next
        For i = 1 To n
            For j = 1 To m
                Dim cost As Integer
                If modified(j - 1) = original(i - 1) Then
                    cost = 0
                Else
                    cost = 1
                End If
                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
            Next
        Next
        Dim min As String = original
        Dim max As String = modified
        If (original.Length > modified.Length) Then
            max = original
            min = modified
        End If
        Return Truncate((max.Length - d(n, m)) / max.Length * 100, 2)
    End Function

    Private Shared Async Function AsymmetricMatch(ByVal original As String, ByVal modified As String) As Task(Of Double)
        Dim len_orig = original.Length
        Dim len_diff = modified.Length
        Dim Matrix(len_orig + 1, len_diff + 1) As Integer
        For i = 0 To len_orig
            Matrix(i, 0) = i
        Next
        For j = 0 To len_diff
            Matrix(0, j) = j
        Next
        For i = 1 To len_orig
            For j = 1 To len_diff
                Dim cost As Integer
                If modified(j - 1) = original(i - 1) Then
                    cost = 0
                Else
                    cost = 1
                End If
                Dim vals = New Integer() {Matrix(i - 1, j) + 1, Matrix(i, j - 1) + 1, Matrix(i - 1, j - 1) + cost}
                Matrix(i, j) = vals.Min
                If i > 1 And j > 1 Then
                    If original(i - 1) = modified(j - 2) And original(i - 2) = modified(j - 1) Then
                        Matrix(i, j) = Math.Min(Matrix(i, j), Matrix(i - 2, j - 2) + cost)
                    End If
                End If
            Next
        Next
        Dim min As String = original
        Dim max As String = modified
        If (original.Length > modified.Length) Then
            max = original
            min = modified
        End If
        Return Truncate((max.Length - Matrix(len_orig, len_diff)) / max.Length * 100, 2)
    End Function

    Private Shared Function Truncate(ByVal value As Double, ByVal dec As Integer) As Double
        Return Math.Round(value - 0.5 / Math.Pow(10, dec), dec)
    End Function

    Private Async Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Dim watch As Stopwatch = Stopwatch.StartNew()
        String1T = String1.Text
        String2T = String2.Text
        Dim match As Double = Await (Task.Run(Function() SymmetricMatch(String1T, String2T)))
        watch.Stop()
        MessageBox.Show("The Strings Are " & match & "% Identical With Symmetric Matching")
    End Sub

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim watch As Stopwatch = Stopwatch.StartNew()
        String1T = String1.Text
        String2T = String2.Text
        Dim match As Double = Await (Task.Run(Function() AsymmetricMatch(String1T, String2T)))
        watch.Stop()
        MessageBox.Show("The Strings Are " & match & "% Identical With Asymmetric Matching")
    End Sub

    Private Async Sub MechanicTest(file As String, dest As String)
        Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(file)
        Dim sentences As List(Of String) = New List(Of String)
        Dim symTime As List(Of Double) = New List(Of Double)
        Dim symRes As List(Of Double) = New List(Of Double)
        Dim asymTime As List(Of Double) = New List(Of Double)
        Dim asymRes As List(Of Double) = New List(Of Double)
        Dim a As String
        Dim count As Integer = 0
        Do
            a = reader.ReadLine()
            If (a <> Nothing) Then
                sentences.Add(a)
                count += 1
            End If
        Loop Until a Is Nothing
        reader.Close()
        count -= 2
        For k = 0 To count
            Dim watch As Stopwatch = Stopwatch.StartNew()
            Dim original As String = sentences.Item(k)
            Dim modified As String = sentences.Item(k + 1)
            Dim final = 0
            Dim n As Integer = original.Length
            Dim m As Integer = modified.Length
            Dim d(n + 1, m + 1) As Integer
            If n = 0 Then
                final = m
            End If
            If m = 0 Then
                final = n
            End If
            Dim i As Integer
            Dim j As Integer
            For i = 0 To n
                d(i, 0) = i
            Next
            For j = 0 To m
                d(0, j) = j
            Next
            For i = 1 To n
                For j = 1 To m
                    Dim cost As Integer
                    If modified(j - 1) = original(i - 1) Then
                        cost = 0
                    Else
                        cost = 1
                    End If
                    d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
                Next
            Next
            Dim min As String = original
            Dim max As String = modified
            If (original.Length > modified.Length) Then
                max = original
                min = modified
            End If
            final = Truncate((max.Length - d(n, m)) / max.Length * 100, 2)
            watch.Stop()
            symTime.Add(watch.Elapsed.TotalMilliseconds * 100)
            symRes.Add(final)
        Next
        For k = 0 To count
            Dim watch As Stopwatch = Stopwatch.StartNew()
            Dim original As String = sentences.Item(k)
            Dim l = k + 1
            Dim modified As String = sentences.Item(l)
            Dim final = 0
            Dim len_orig = original.Length
            Dim len_diff = modified.Length
            Dim Matrix(len_orig + 1, len_diff + 1) As Integer
            For i = 0 To len_orig
                Matrix(i, 0) = i
            Next
            For j = 0 To len_diff
                Matrix(0, j) = j
            Next
            For i = 1 To len_orig
                For j = 1 To len_diff
                    Dim cost As Integer
                    If modified(j - 1) = original(i - 1) Then
                        cost = 0
                    Else
                        cost = 1
                    End If
                    Dim vals = New Integer() {Matrix(i - 1, j) + 1, Matrix(i, j - 1) + 1, Matrix(i - 1, j - 1) + cost}
                    Matrix(i, j) = vals.Min
                    If i > 1 And j > 1 Then
                        If original(i - 1) = modified(j - 2) And original(i - 2) = modified(j - 1) Then
                            Matrix(i, j) = Math.Min(Matrix(i, j), Matrix(i - 2, j - 2) + cost)
                        End If
                    End If
                Next
            Next
            Dim min As String = original
            Dim max As String = modified
            If (original.Length > modified.Length) Then
                max = original
                min = modified
            End If
            final = Truncate((max.Length - Matrix(len_orig, len_diff)) / max.Length * 100, 2)
            watch.Stop()
            asymTime.Add(watch.Elapsed.TotalMilliseconds * 100)
            asymRes.Add(final)
        Next
        Dim sum As Integer = 0
        For i = 0 To count
            If symRes.Item(i) < asymRes.Item(i) Then
                sum += 1
            End If
        Next
        Dim Write As New System.IO.StreamWriter(dest + "\results.csv")
        Dim Init As String = "Iteration" & ";" & "Symmetric Result" & ";" & "Symmetric Time" & ";" & "Asymmetric Result" & ";" & "Asymmetric Time"
        Write.WriteLine(Init)
        For i = 0 To count
            Dim Text As String = i.ToString() & ";" & symRes.Item(i).ToString() & ";" & symTime.Item(i).ToString() & ";" & asymRes.Item(i).ToString() & ";" & asymTime.Item(i).ToString()
            Write.WriteLine(Text)
        Next
        Write.Close()
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filec As OpenFileDialog = New OpenFileDialog()
        Dim folc As FolderBrowserDialog = New FolderBrowserDialog()
        filec.DefaultExt = "txt"
        filec.Title = "Please select a TXT file"
        filec.InitialDirectory = "c:\users\"
        filec.Filter = "All files|*.*|Text files|*.txt"
        folc.Description = "Please choose output file path"
        MessageBox.Show("In order to perform a mechanic test the string must be seperated by a new line", "Critical Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        If filec.ShowDialog() <> DialogResult.Cancel Then
            If folc.ShowDialog() <> DialogResult.Cancel Then
                Await (Task.Run(Sub() MechanicTest(filec.FileName, folc.SelectedPath)))
                MessageBox.Show("Mechanic Test Completed Successfully")
            End If
        End If
    End Sub
End Class