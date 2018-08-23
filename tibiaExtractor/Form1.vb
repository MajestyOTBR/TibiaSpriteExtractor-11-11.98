Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports System.Xml
Imports OpenTibia

Public Class Form1
    Dim oc As Client.IClient
    Dim thread As Thread
    Dim imlist As ImageList
    Dim xmldoc As XmlDocument
    Dim multiArray As List(Of ListitemObject) = New List(Of ListitemObject)

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        settings.Show()

    End Sub

    Private Sub ExtractSpritesheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtractSpritesheetToolStripMenuItem.Click
        Dim work = New Worker(Label1)
        thread = New Thread(AddressOf work.Start)
        thread.Start()
        Label1.Text = "Done"
    End Sub

    Private Sub SliceSpritesheatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SliceSpritesheatToolStripMenuItem.Click
        Dim work As Worker = New Worker(Label1)
        Dim tileSize As Size = New Size(64, 64)
        Dim Offset As Point = New Point(0, 0)
        Dim Space As Size = New Size(0, 0)
        imlist = New ImageList()
        Dim filelist As String() = Directory.GetFiles(My.MySettings.Default.ExtractFolder + "\", "*.bmp")
        For i As Integer = 0 To filelist.Length - 1
            Dim spritesheet As Image = Image.FromFile(filelist(i))
            imlist = work.GenerateTileSetImageList(spritesheet, tileSize, Offset, Space)
        Next
        imlist.ImageSize = New Size(32, 32)
        For i As Integer = 0 To imlist.Images.Count - 1

            imlist.Images(i).Save(My.MySettings.Default.ExtractFolder + "\" + i.ToString + "_sprite" + ".png")

        Next
        Label1.Text = "Done"
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If IsNothing(False) Then
            thread.Abort()
        End If

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub BakeASprToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BakeASprToolStripMenuItem.Click
        Panel1.Visible = True
        LoadList()
    End Sub

    Private Sub LoadList()
        xmldoc = New XmlDocument()
        Dim fs As New FileStream(CurDir() + "\clients.xml", FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        Dim Nodes As XmlNode = xmldoc.SelectSingleNode("/clients")
        For i As Integer = 0 To Nodes.ChildNodes.Count - 1
            Dim a As String = Nodes.ChildNodes(i).Attributes("description").Value
            Dim lob As ListitemObject = New ListitemObject()

            lob.description = Nodes.ChildNodes(i).Attributes("description").Value
            lob.version = CUShort(Nodes.ChildNodes(i).Attributes("version").Value)
            lob.otbversion = CUInt("&H" + Nodes.ChildNodes(i).Attributes("otbversion").Value)
            lob.sprsignature = CUInt("&H" + Nodes.ChildNodes(i).Attributes("sprsignature").Value)
            lob.datsignature = CUInt("&H" + Nodes.ChildNodes(i).Attributes("datsignature").Value)
            multiArray.Add(lob)

            ListBox1.Items.Add(a)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim loads As Loader = New Loader()

        'loads.Load(My.MySettings.Default.TibiaFolder, Client.ClientFeatures.None)
        loads.LoadOc(My.MySettings.Default.TibiaFolder)
        Dim thing = oc.Things.GetItem(100).Clone()
        'Dim thing = New Client.Things.ThingType(100, Client.Things.ThingCategory.Item)
        MessageBox.Show(thing.ID.ToString())



        'Dim spr As Client.Sprites.Sprite = New Client.Sprites.Sprite(0, False)

        'If loads.OcAdd(thing, spr) = True Then
        '    MessageBox.Show("dat and sprite added")
        'End If

        'loads.SaveOc(My.MySettings.Default.ExtractFolder)

    End Sub
End Class
