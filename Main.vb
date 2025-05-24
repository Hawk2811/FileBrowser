Public Class Main
    Dim errors As String
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        LoadFiles()
    End Sub

    Private Sub UpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpToolStripMenuItem.Click
        Try
            If IO.Directory.Exists(My.Computer.FileSystem.GetParentPath(ToolStripTextBox1.Text)) = True Then

                ToolStripTextBox1.Text = My.Computer.FileSystem.GetParentPath(ToolStripTextBox1.Text)
                ListView1.Items.Clear()
                For directory = 0 To My.Computer.FileSystem.GetDirectories(ToolStripTextBox1.Text).Count - 1
                    ListView1.Items.Add(My.Computer.FileSystem.GetName(My.Computer.FileSystem.GetDirectories(ToolStripTextBox1.Text)(directory)), 1)
                Next

                For file = 0 To My.Computer.FileSystem.GetFiles(ToolStripTextBox1.Text).Count - 1
                    ListView1.Items.Add(My.Computer.FileSystem.GetName(My.Computer.FileSystem.GetFiles(ToolStripTextBox1.Text)(file)), 0)
                Next
            End If
        Catch ex As Exception
            errors = errors & vbNewLine & ex.Message
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\APP.LOG", errors, False)
        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try

            If IO.Directory.Exists(ToolStripTextBox1.Text & "\" & ListView1.SelectedItems(0).Text) = True Then
                ToolStripTextBox1.Text = ToolStripTextBox1.Text & "\" & ListView1.SelectedItems(0).Text
                ListView1.Items.Clear()
                For directory = 0 To My.Computer.FileSystem.GetDirectories(ToolStripTextBox1.Text).Count - 1
                    ListView1.Items.Add(My.Computer.FileSystem.GetName(My.Computer.FileSystem.GetDirectories(ToolStripTextBox1.Text)(directory)), 1)
                Next

                For file = 0 To My.Computer.FileSystem.GetFiles(ToolStripTextBox1.Text).Count - 1
                    ListView1.Items.Add(My.Computer.FileSystem.GetName(My.Computer.FileSystem.GetFiles(ToolStripTextBox1.Text)(file)), 0)
                Next
            End If

            If IO.File.Exists(ToolStripTextBox1.Text & "\" & ListView1.SelectedItems(0).Text) Then
                Process.Start(ToolStripTextBox1.Text & "\" & ListView1.SelectedItems(0).Text)
            End If
        Catch ex As Exception
            errors = errors & vbNewLine & ex.Message
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\APP.LOG", errors, False)
        End Try
    End Sub

    Private Sub DiskSelectorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiskSelectorToolStripMenuItem.Click
        DiskSelector.ShowDialog()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("\APP.LOG", "Starting at " + System.DateTime.Now, False)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Try
            If IO.Directory.Exists(ToolStripTextBox1.Text & "\" & ListView1.SelectedItems(0).Text) = True Then
                ToolStripTextBox1.Text = ToolStripTextBox1.Text & "\" & ListView1.SelectedItems(0).Text
                ListView1.Items.Clear()
                For directory = 0 To My.Computer.FileSystem.GetDirectories(ToolStripTextBox1.Text).Count - 1
                    ListView1.Items.Add(My.Computer.FileSystem.GetName(My.Computer.FileSystem.GetDirectories(ToolStripTextBox1.Text)(directory)), 1)
                Next

                For file = 0 To My.Computer.FileSystem.GetFiles(ToolStripTextBox1.Text).Count - 1
                    ListView1.Items.Add(My.Computer.FileSystem.GetName(My.Computer.FileSystem.GetFiles(ToolStripTextBox1.Text)(file)), 0)
                Next
            End If

            If IO.File.Exists(ToolStripTextBox1.Text & "\" & ListView1.SelectedItems(0).Text) Then
                Process.Start(ToolStripTextBox1.Text & "\" & ListView1.SelectedItems(0).Text)
            End If
        Catch ex As Exception
            errors = errors & vbNewLine & ex.Message
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\APP.LOG", errors, False)
        End Try
    End Sub

    Public Sub LoadFiles()
        Try
            ListView1.Clear()
            For directory = 0 To My.Computer.FileSystem.GetDirectories(ToolStripTextBox1.Text).Count - 1
                ListView1.Items.Add(My.Computer.FileSystem.GetName(My.Computer.FileSystem.GetDirectories(ToolStripTextBox1.Text)(directory)), 1)

            Next
            For file = 0 To My.Computer.FileSystem.GetFiles(ToolStripTextBox1.Text).Count - 1
                ListView1.Items.Add(My.Computer.FileSystem.GetName(My.Computer.FileSystem.GetFiles(ToolStripTextBox1.Text)(file)), 0)
            Next
        Catch ex As Exception
            errors = errors & vbNewLine & ex.Message
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\APP.LOG", errors, False)
        End Try
    End Sub
End Class
