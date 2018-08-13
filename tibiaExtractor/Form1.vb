Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading
Imports OpenTibia


Public Class Form1
    Public Shared spritelist As New List(Of Image)
    Public Shared counter As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Dim work = New worker(ProgressBar1, TextBox1, TextBox2, Label1, Label2)
        Dim thread As New Thread(AddressOf work.Start)
        thread.Start()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label2.Text = "Creating a spr file from extracted sheets"
        If TextBox2.Text = Nothing Then
            Throw New Exception("check that extract folder contains sheets(bmp) and extract textbox is not empty!")
        End If
        Dim filelist As String() = Directory.GetFiles(TextBox2.Text, "*.bmp")
        If filelist.Count() = 0 Then
            Throw New Exception("theres no files in list! navigate to correct extraction folder")
        End If
        Try
            For i As Integer = 0 To filelist.Length - 1
                Dim finfo As FileInfo = New FileInfo(filelist(i))
                Dim t As tile = New tile(finfo.Name, TextBox2.Text)
                spritelist.Add(t.CreateImage())
                counter += 1
                ProgressBar1.Value = counter * 100 / filelist.Length
                ProgressBar1.Update()
                Label2.Text = ProgressBar1.Value
            Next
            createsprfile()
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try


    End Sub

    Private Sub createsprfile()
        Dim version As OpenTibia.Core.Version = New OpenTibia.Core.Version(1079, "Client 10.79", &H3A71, &H59E48E02, 0)
        Dim path As String = "C:\Users\tess\Documents\Visual Studio 2017\Projects\otxserver-new-master\build\RelWithDebInfo\client\Tibia\Tibia.spr"
        Dim osprite As OpenTibia.Client.Sprites.SpriteStorage = OpenTibia.Client.Sprites.SpriteStorage.Load(path, version)

        For i As Integer = 0 To spritelist.Count - 1
            Dim spr As Client.Sprites.Sprite = New Client.Sprites.Sprite()
            spr.SetBitmap(spritelist(i))
            osprite.AddSprite(spr)
        Next
        Dim ver As Core.Version = New OpenTibia.Core.Version(1079, "Client 10.79", &H3A71, &H59E48E02, 0)
        osprite.Save(TextBox2.Text + "\" + TextBox3.Text + ".spr", ver)
    End Sub
End Class
