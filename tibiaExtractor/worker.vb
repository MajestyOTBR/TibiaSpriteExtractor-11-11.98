Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports SevenZip.Compression.LZMA
Public Class Worker
    Public Shared counter As Integer
    Dim progressbar As ProgressBar
    Dim filelist As String()
    Dim status As Label
    Dim pro As Label
    Dim assetfolder As TextBox
    Dim extractfolder As TextBox


    Public Sub New(prog As ProgressBar, asfolder As TextBox, extr As TextBox, stat As Label, proc As Label)
        progressbar = prog
        status = stat
        assetfolder = asfolder
        extractfolder = extr
        pro = proc

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

    Public Sub Extract(ByVal file As String)

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
                SaveStreamToFile(spriteBuffer, extractfolder.Text + "\" + finfo.Name & ".bmp")
            Catch ex As Exception
                status.Text = ex.Message + " :parsing"
            End Try
        End Using
    End Sub

    Public Sub Start()
        Try
            filelist = Directory.GetFiles(assetfolder.Text, "*.lzma")
            If filelist.Count() = 0 Then
                Throw New Exception("theres no files in list! navigate to correct asset folder")
            End If

            For i As Integer = 0 To filelist.Length - 1

                If filelist(i).Contains("sprites-") Then

                    Extract(filelist(i))
                End If
                counter += 1
                progressbar.Value = counter * 100 / filelist.Length
                progressbar.Update()
                pro.Text = progressbar.Value
            Next

        Catch ex As Exception
            status.Text = ex.Message + " :Startfunc"
        End Try

    End Sub

End Class
