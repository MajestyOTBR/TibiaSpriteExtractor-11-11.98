Imports System
Imports System.IO
Imports SevenZip.Compression.LZMA

Public Structure ListitemObject
    Dim version As UShort
    Dim description As String
    Dim otbversion As UInteger
    Dim datsignature As UInteger
    Dim sprsignature As UInteger
End Structure

Public Class Worker
    Public Shared counter As Integer
    Dim filelist As String()
    Dim status As Label
    Public Sub New(stat As Label)

        status = stat

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
                SaveStreamToFile(spriteBuffer, My.MySettings.Default.ExtractFolder + "\" + finfo.Name & ".bmp")
            Catch ex As Exception
                status.Text = ex.Message + " :parsing"
            End Try
        End Using
    End Sub

    Public Sub Start()
        Try
            filelist = Directory.GetFiles(My.MySettings.Default.Assetfolder + "\", "*.lzma")
            If filelist.Count() = 0 Then
                MessageBox.Show("theres no files in list! navigate to correct asset folder")
            End If

            For i As Integer = 0 To filelist.Length - 1

                If filelist(i).Contains("sprites-") Then

                    Extract(filelist(i))
                End If
                counter += 1

                status.Text = counter * 100 / filelist.Length
            Next

        Catch ex As Exception
            status.Text = ex.Message + " :Startfunc"
        End Try

    End Sub

    Public Function GenerateTileSetImageList(ByVal tileSetImage As Image, ByVal tileSize As Size, ByVal offset As Point, ByVal space As Size) As ImageList
        Try
            Dim Tiles As New ImageList
            Tiles.ImageSize = tileSize

            Dim width, height As Single
            width = tileSetImage.PhysicalDimension.Width
            height = tileSetImage.PhysicalDimension.Height

            If (tileSize.Width > 0) And (tileSize.Height > 0) Then

                If (width >= tileSize.Width) And (height >= tileSize.Height) Then
                    Dim tile As Image
                    Dim rows, columns As Integer

                    rows = height \ CInt(tileSize.Height) 'integer division
                    columns = width \ CInt(tileSize.Width) 'integer division

                    If (rows * columns) > 64 Then
                        Return Nothing
                    End If

                    For j As Integer = 0 To (rows - 1)
                        For i As Integer = 0 To (columns - 1)
                            tile = New Bitmap(tileSize.Width, tileSize.Height, tileSetImage.PixelFormat)
                            Dim g As Graphics = Graphics.FromImage(tile)
                            Dim sourceRect As New Rectangle(offset.X + (i * tileSize.Width) + (i * space.Width), offset.Y + (j * tileSize.Height) + (j * space.Width), tileSize.Width, tileSize.Height)
                            g.DrawImage(tileSetImage, New Rectangle(0, 0, tileSize.Width, tileSize.Height), sourceRect, GraphicsUnit.Pixel)
                            Tiles.Images.Add(i + 1, tile)
                            g.Dispose()
                        Next
                    Next

                End If
            End If

            Return Tiles

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Return Nothing

    End Function

End Class
