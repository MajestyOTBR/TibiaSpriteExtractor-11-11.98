Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports System.Xml
Imports OpenTibia

Public Class Form1
    Public Shared spritelist As New List(Of Image)
    Public Shared counter As Integer
    Dim xmldoc As XmlDocument
    Public Shared selectedclient As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateListbox()
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
        If IsNothing(ListBox1.SelectedItem) Then
            MessageBox.Show("select a tibia version")
        End If
        Label2.Text = "Creating a spr file from extracted sheets"
        If TextBox2.Text = Nothing Then
            MessageBox.Show("check that extract folder contains sheets(bmp) and extract textbox is not empty!")
        End If
        Dim filelist As String() = Directory.GetFiles(TextBox2.Text, "*.bmp")
        If filelist.Count() = 0 Then
            MessageBox.Show("theres no files in list! navigate to correct extraction folder")
        End If
        Try
            For i As Integer = 0 To filelist.Length - 1
                Dim finfo As FileInfo = New FileInfo(filelist(i))
                Dim t As Tile = New Tile(finfo.Name, TextBox2.Text)
                spritelist.Add(t.CreateImage())
                counter += 1
                ProgressBar1.Value = counter * 100 / filelist.Length
                ProgressBar1.Update()
                Label2.Text = ProgressBar1.Value
            Next
            Createsprfile()

        Catch ex As Exception
            Label1.Text = ex.Message
        End Try


    End Sub

    Private Sub Createsprfile()
        If selectedclient = Nothing Then
            MessageBox.Show("you need to select a client both for loading and saving")
        End If

        Dim Nodes As XmlNode = xmldoc.SelectSingleNode("/clients")

        Dim clientname As String = Nodes.ChildNodes(selectedclient).Attributes("description").Value
        Dim version As UShort = CUShort(Nodes.ChildNodes(selectedclient).Attributes("version").Value)
        Dim otb As UInteger = CUInt(Nodes.ChildNodes(selectedclient).Attributes("otbversion").Value)
        Dim spri As UInteger = CUInt("&H" + Nodes.ChildNodes(selectedclient).Attributes("sprsignature").Value)
        Dim dat As UInteger = CUInt("&H" + Nodes.ChildNodes(selectedclient).Attributes("datsignature").Value)

        If TextBox3.Text = Nothing Then
            MessageBox.Show("you need to select a spr file")
        End If
        Dim versionstorage As OpenTibia.Core.VersionStorage = New Core.VersionStorage()
        versionstorage.Load(CurDir() + "\clients.xml")

        Dim ver As Core.Version = New OpenTibia.Core.Version(version, clientname, dat, spri, otb)

        Dim osprite As OpenTibia.Client.Sprites.SpriteStorage = Client.Sprites.SpriteStorage.Load(TextBox3.Text, ver)
        osprite.Version = ver

        For i As Integer = 0 To spritelist.Count - 1
            Dim spr As Client.Sprites.Sprite = New Client.Sprites.Sprite()
            spr.SetBitmap(spritelist(i))
            osprite.AddSprite(spr)
        Next

        osprite.Save(TextBox2.Text + "\Tibia.spr", ver)


    End Sub

    Private Sub PopulateListbox()

        xmldoc = New XmlDocument()
        Dim fs As New FileStream(CurDir() + "\clients.xml", FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        Dim Nodes As XmlNode = xmldoc.SelectSingleNode("/clients")
        For i As Integer = 0 To Nodes.ChildNodes.Count - 1
            Dim a As String = Nodes.ChildNodes(i).Attributes("description").Value
            ListBox1.Items.Add(a)
        Next

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        selectedclient = ListBox1.SelectedIndex
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If IsNothing(ListBox1.SelectedItem) Then
            MessageBox.Show("select a tibia version")
        End If

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox3.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim db As DatFile
            Dim filelist As String() = Directory.GetFiles(TextBox1.Text, "*.dat")
            For i As Integer = 0 To filelist.Length - 1
                Dim finfo As FileInfo = New FileInfo(filelist(i))
                If filelist(i).Contains("appearances-") Then
                    Dim dbs As Datfiles = New Datfiles()
                    db = dbs.Readfile(TextBox1.Text + "\" + finfo.Name)
                End If

            Next

            Dim ou = "we have " + db.Outfits.Count.ToString + " outfits," + vbNewLine
            Dim ef = "we have " + db.Effects.Count.ToString + " effects," + vbNewLine
            Dim ob = "we have " + db.Objects.Count.ToString + " objects," + vbNewLine
            Dim mi = "we have " + db.Missiles.Count.ToString + " missiles"

            Label5.Text = ou + ef + ob + mi
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
            Label1.Text = ex.Message
        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim od As OldDatfile2 = New OldDatfile2()
        od.Old_load("Tibia.dat")
    End Sub
End Class
