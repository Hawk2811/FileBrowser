Public Class DiskSelector
    Private Sub DiskSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComboBox1.Items.Clear()
            For disk = 0 To My.Computer.FileSystem.Drives.Count - 1
                If My.Computer.FileSystem.Drives.Item(disk).IsReady Then
                    ComboBox1.Items.Add(My.Computer.FileSystem.Drives.Item(disk).ToString)
                End If
            Next
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "FileBrowser")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.ToolStripTextBox1.Text = ComboBox1.SelectedItem.ToString
        Main.LoadFiles()
        Me.Close()
    End Sub
End Class