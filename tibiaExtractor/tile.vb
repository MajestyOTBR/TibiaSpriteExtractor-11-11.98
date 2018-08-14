Imports System

Public Class Tile
    Public Shared filename As String 'this is for naming our folder with corresponding spritesheet name
    Public Shared path As String 'uh just incase
    Public Sub New(sfilename As String, filepath As String)
        filename = sfilename
        path = filepath
    End Sub
    Public Function CreateImage() As Image

        Dim spritesheet = Image.FromFile(path + "\" + filename)
        Dim si As Size = New Size(32, 32)

        For i As Integer = 0 To 32
            Dim sprite = GetSprite(spritesheet, si, i)
            Return sprite
        Next
        Return Nothing
    End Function


    Public Function GetSprite(ByVal spriteSheet As Image, ByVal spriteSize As Size, ByVal spriteIndex As Integer) As Image
        Try
            Dim spriteImage As New Bitmap(spriteSize.Width, spriteSize.Height, spriteSheet.PixelFormat)
            Dim g As Graphics = Graphics.FromImage(spriteImage)
            Dim sourceRect As New Rectangle(spriteSize.Width * spriteIndex, 0, spriteSize.Width, spriteSize.Height)
            g.DrawImage(spriteSheet, New Rectangle(0, 0, spriteSize.Width, spriteSize.Height), sourceRect, GraphicsUnit.Pixel)
            g.Dispose()

            Return spriteImage

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Return Nothing

    End Function
End Class
