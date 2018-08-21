Public Class settings

    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Text = My.Settings.Assetfolder
        TextBox2.Text = My.Settings.ExtractFolder
        TextBox3.Text = My.Settings.TibiaFolder

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.MySettings.Default.Assetfolder = TextBox1.Text
        My.MySettings.Default.ExtractFolder = TextBox2.Text
        My.MySettings.Default.TibiaFolder = TextBox3.Text
        My.MySettings.Default.Datfile = TextBox3.Text + "\Tibia.dat"
        My.MySettings.Default.Spritefile = TextBox3.Text + "\Tibia.spr"
        My.MySettings.Default.Save()
        MessageBox.Show("Settings has been saved")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.ShowDialog()
        TextBox1.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FolderBrowserDialog1.ShowDialog()
        TextBox3.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FolderBrowserDialog1.ShowDialog()
        TextBox2.Text = FolderBrowserDialog1.SelectedPath
    End Sub

End Class