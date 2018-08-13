Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports SevenZip.Compression.LZMA

Public Class Form1
    Public Shared _spriteBuffer As MemoryStream
    Public Shared counter As Integer
    Dim thread As New Thread(AddressOf Start)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Shared Sub SaveStreamToFile(ByVal stream As Stream, ByVal filename As String)
        Using destination As Stream = File.Create(filename)
            Write(stream, destination)
        End Using
    End Sub

    Public Shared Sub Write(ByVal from As Stream, ByVal [to] As Stream)
        Dim a As Integer = from.ReadByte()

        While a <> -1
            [to].WriteByte(CByte(a))
            a = from.ReadByte()
        End While
    End Sub

    Public Sub TExtract(ByVal file As String)

        Dim finfo As FileInfo = New FileInfo(file)
        Dim spriteBuffer As MemoryStream = New MemoryStream(&H100000)
        Dim decoder As Decoder = New Decoder()
        Dim filestream As FileStream = New FileStream(file, FileMode.Open)
        Using reader As BinaryReader = New BinaryReader(filestream)
            Dim input As Stream = reader.BaseStream

            While reader.ReadByte() = 0
            End While

            reader.ReadUInt32()

            While (reader.ReadByte() And &H80) = &H80
            End While

            decoder.SetDecoderProperties(reader.ReadBytes(5))
            reader.ReadUInt64()
            spriteBuffer.Position = 0
            decoder.Code(input, spriteBuffer, input.Length - input.Position, &H100000, Nothing)
            spriteBuffer.Position = 0

            Try
                SaveStreamToFile(spriteBuffer, Me.TextBox2.Text + "\" + finfo.Name & ".bmp")
            Catch ex As Exception
                Me.Label1.Text = ex.Message
            End Try
        End Using
    End Sub

    Public Sub Start()

    Dim fileArray As String() = Directory.GetFiles(Me.TextBox1.Text, "*.lzma")

        For i As Integer = 0 To fileArray.Length - 1

            If fileArray(i).Contains("sprites-") Then

                TExtract(fileArray(i))
            End If
            counter += 1
            Me.ProgressBar1.Value = counter * 100 / fileArray.Length
            Me.ProgressBar1.Update()

        Next
        thread.Abort()
    End Sub

    Public Shared Sub Extract(ByVal file As String)

        Dim finfo As FileInfo = New FileInfo(file)
        Dim spriteBuffer As MemoryStream = New MemoryStream(&H100000)
        Dim decoder As Decoder = New Decoder()
        Dim filestream As FileStream = New FileStream(file, FileMode.Open)
        Using reader As BinaryReader = New BinaryReader(filestream)
            Dim input As Stream = reader.BaseStream

            While reader.ReadByte() = 0
            End While

            reader.ReadUInt32()

            While (reader.ReadByte() And &H80) = &H80
            End While

            decoder.SetDecoderProperties(reader.ReadBytes(5))
            reader.ReadUInt64()
            spriteBuffer.Position = 0
            decoder.Code(input, spriteBuffer, input.Length - input.Position, &H100000, Nothing)
            spriteBuffer.Position = 0

            Try
                SaveStreamToFile(spriteBuffer, Form1.TextBox2.Text + "\" + finfo.Name & ".bmp")
            Catch ex As Exception
                Form1.Label1.Text = ex.Message
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Label1.Text = "Extracting ...."
        'Me.BackgroundWorker1.RunWorkerAsync()
        thread.Start()
    End Sub


    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        '' This event is fired when you call the ReportProgress method from inside your DoWork.
        '' Any visual indicators about the progress should go here.
        ProgressBar1.Value = e.ProgressPercentage
        Me.Label1.Text = e.ProgressPercentage.ToString & "% complete."
    End Sub


    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.BackgroundWorker1.CancelAsync()
    End Sub


    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Label1.Text = "Finished!"
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim fileArray As String() = Directory.GetFiles(Me.TextBox1.Text, "*.lzma")

        For i As Integer = 0 To fileArray.Length - 1

            If fileArray(i).Contains("sprites-") Then

                Extract(fileArray(i))
            End If
            counter += 1
            BackgroundWorker1.ReportProgress(counter * 100 / fileArray.Length)
        Next
    End Sub

End Class
