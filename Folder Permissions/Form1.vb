
Imports System.IO
Imports System.Security
Imports System.Security.AccessControl
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Threading

'Imports System.Security.Permissions
'Imports System.Security.Principal

'TO DO: add HTML output stuff

Public Class Form1
    Private strRootFolder As String = ""
    Private strOutputFile As String = ""
    Private intMaxDepth As Integer
    Private intTotalFolders As Integer
    Private outfile As StreamWriter
    Private dtStartTime As DateTime
    Private ElapsedTime As TimeSpan
    Private boolHTML As Boolean = False
    Private boolIncludeInherited As Boolean

    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Sub ComboBoxScanSubfolders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxScanSubfolders.SelectedIndexChanged
        If ComboBoxScanSubfolders.Text = "No" Then
            ComboBoxMaxDepth.Enabled = False
        Else
            ComboBoxMaxDepth.Enabled = True
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName
        ToolStripStatusLabel1.Text = ""

        ComboBoxScanSubfolders.SelectedIndex = 0
        ComboBoxMaxDepth.Text = 4

        AddHandler BackgroundWorker1.DoWork, AddressOf bw_DoWork
        AddHandler BackgroundWorker1.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        ToolStripStatusLabel1.Text = "Folders scanned:  " & intTotalFolders
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If boolHTML Then
            AddHTML("</body>" & vbCrLf & "</html>")
        End If

        outfile.Close()

        ToolStripProgressBar1.Style = ProgressBarStyle.Blocks
        EnableControls(True)

        If e.Cancelled = True Then
            ToolStripProgressBar1.Value = 0
            ToolStripStatusLabel1.Text = "Scanning cancelled."
        ElseIf e.Error IsNot Nothing Then
            ToolStripProgressBar1.Value = 0
            Dim strError As String = ""
            Try
                'strError = e.Error.Message
                strError = e.Error.ToString
            Catch ex As Exception
                'strError = ex.Message
            End Try
            'e.Error.Source
            ToolStripStatusLabel1.Text = "Error:  " & strError
        Else
            ElapsedTime = Now.Subtract(dtStartTime)
            ToolStripProgressBar1.Value = 100
            ToolStripStatusLabel1.Text = "Scanning complete.  Folders scanned:  " & intTotalFolders & ".  Elapsed Time:  " & String.Format("{0:00}:{1:00}:{2:00}", CInt(ElapsedTime.TotalHours), ElapsedTime.Minutes, ElapsedTime.Seconds)
        End If
    End Sub


    Private Sub ButtonSelectOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelectOutput.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBoxOutputTo.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub ButtonBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBrowse.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBoxRootFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ButtonScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScan.Click
        TextBoxErrors.Text = ""
        ToolStripStatusLabel1.Text = ""
        ToolStripProgressBar1.Value = 0
        boolIncludeInherited = CheckBox1.Checked

        strRootFolder = TextBoxRootFolder.Text
        If Not strRootFolder.EndsWith("\") Then strRootFolder = strRootFolder & "\"

        If Not IO.Directory.Exists(strRootFolder) Then
            MsgBox("Select a valid folder!", MsgBoxStyle.Exclamation)
            TextBoxRootFolder.Focus()
            Exit Sub
        End If

        strOutputFile = TextBoxOutputTo.Text
        If strOutputFile = "" Then
            MsgBox("Enter a valid output file!", MsgBoxStyle.Exclamation)
            TextBoxOutputTo.Focus()
            Exit Sub
        End If

        If Strings.Left(Strings.Right(strOutputFile, 4).ToLower, 3) = "htm" Then
            boolHTML = True
        Else
            boolHTML = False
        End If


        If ComboBoxMaxDepth.Text = "None" Then
            intMaxDepth = Int32.MaxValue
        Else
            intMaxDepth = CInt(ComboBoxMaxDepth.Text)
        End If

        Try
            outfile = New StreamWriter(strOutputFile)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try


        intTotalFolders = 0
        If boolHTML Then
            WriteStartHTML()
        Else
            outfile.WriteLine("""Path"",""Owner"",""User/Group"",""Access Type"",""Inherited"",""Permissions""")
        End If


        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee

        EnableControls(False)
        dtStartTime = Now

        'DO BACKGROUND WORK
        BackgroundWorker1.RunWorkerAsync()



    End Sub

    Private Sub EnableControls(ByVal boolEnable As Boolean)
        ButtonScan.Enabled = boolEnable
        TextBoxRootFolder.Enabled = boolEnable
        TextBoxOutputTo.Enabled = boolEnable
        ButtonBrowse.Enabled = boolEnable
        ButtonSelectOutput.Enabled = boolEnable
        ComboBoxScanSubfolders.Enabled = boolEnable
        ComboBoxMaxDepth.Enabled = boolEnable
        ButtonCancel.Enabled = Not boolEnable
        CheckBox1.Enabled = boolEnable
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)

        Thread.CurrentThread.Priority = ThreadPriority.Lowest

        ListFolderPermissions(strRootFolder)

        If BackgroundWorker1.CancellationPending Then e.Cancel = True

    End Sub

    Private Sub ListFolderPermissions(ByVal myFolder As String)

        If BackgroundWorker1.CancellationPending Then Exit Sub


        Try
            Dim di As DirectoryInfo = New DirectoryInfo(myFolder)
            Dim ds As New DirectorySecurity
            ds = di.GetAccessControl

            Dim strOwner As String = ""

            Dim id As Principal.IdentityReference = ds.GetOwner(GetType(Principal.SecurityIdentifier))
            Dim ntAccount As Principal.NTAccount
            Try
                ntAccount = id.Translate(GetType(Principal.NTAccount))
                strOwner = ntAccount.Value
            Catch ex As Exception
                strOwner = id.Value
            End Try


            Dim strClass As String = ""
            If intTotalFolders Mod 2 = 0 Then
                strClass = "even"
            Else
                strClass = ""
            End If

            Dim tmpHtml As String = ""
            'Dim boolAddedHtmlStart As Boolean = False

            If boolHTML Then
                tmpHtml += "<div class="" outer_collapsed " & strClass & """ onclick="" showNext(this);"">"
                tmpHtml += "<div class="" folderTitle"">" & myFolder & "</div>"
                tmpHtml += "</div>"


                tmpHtml += "<div Class=""hide"">"
                tmpHtml += "<b>Folder: " & myFolder & "</b><br>"
                tmpHtml += "<b>Folder Owner: " & strOwner & "</b><br>"
            End If

            Dim colAccessRules As AuthorizationRuleCollection = ds.GetAccessRules(True, True, GetType(System.Security.Principal.NTAccount))
            Dim countEntries As Integer = 0

            For Each ace As FileSystemAccessRule In colAccessRules

                Dim perms As String = ""
                Dim ACL_Type As String = ""


                If boolIncludeInherited = True Then
                    countEntries += 1
                Else
                    If ace.IsInherited = False Then
                        countEntries += 1
                    Else
                        'If we're not including Inherited entries, then skip this ACE
                        Continue For
                    End If
                End If


                If boolHTML Then
                    'If boolAddedHtmlStart = False Then
                    If countEntries = 1 Then
                        AddHTML(tmpHtml)
                        'boolAddedHtmlStart = True
                    End If
                End If


                Select Case ace.AccessControlType
                    Case AccessControlType.Allow
                        ACL_Type = "Allow"
                    Case AccessControlType.Deny
                        ACL_Type = "Deny"
                    Case Else
                        Continue For
                End Select

                Select Case True
                    Case (ace.FileSystemRights And FileSystemRights.FullControl) = FileSystemRights.FullControl
                        perms = "Full Control"
                    Case (ace.FileSystemRights And FileSystemRights.Modify) = FileSystemRights.Modify
                        perms = "Modify"
                    Case (ace.FileSystemRights And FileSystemRights.ReadAndExecute) = FileSystemRights.ReadAndExecute
                        perms = "Read & execute"
                    Case (ace.FileSystemRights And (FileSystemRights.Read + FileSystemRights.Write)) = (FileSystemRights.Read + FileSystemRights.Write)
                        perms = "Read/Write"
                    Case (ace.FileSystemRights And FileSystemRights.Read) = FileSystemRights.Read
                        perms = "Read"
                    Case (ace.FileSystemRights And 268435456) = 268435456
                        perms = "Full Control (Sub Only)"
                    Case Else
                        perms = ace.FileSystemRights.ToString
                End Select
                '1179785 = Read
                '1180063 = Read, Write
                '1179817 = ReadAndExecute
                '-1610612736 = ReadAndExecuteExtended
                '1245631 = ReadAndExecute, Modify, Write
                '1180095 = ReadAndExecute, Write
                '268435456 = FullControl (Sub Only)



                Debug.Print("Identity:  " & ace.IdentityReference.Value)
                '           Debug.Print(perms)

                Debug.Print("OWNER:  " & strOwner)
                Debug.Print("INHERITED?:  " & ace.IsInherited)
                Debug.Print("PERMS:  " & ace.FileSystemRights.ToString)

                Debug.Print("")

                perms = UnCamelCase(perms)

                If boolHTML Then
                    AddHTML("<div class=""outer_collapsed"" onclick=""showNext(this);"">")
                    AddHTML("<div class='folderTitle'>" & ace.IdentityReference.Value & "</div>")
                    AddHTML("</div>")
                    AddHTML("<div class=""hide"">")
                    AddHTML("ACE Type: " & ACL_Type & "<br>")
                    AddHTML("<br>")
                    If ace.IsInherited Then
                        AddHTML("Permissions (Inherited): <br>" & perms)
                    Else
                        AddHTML("Permissions: <br>" & perms)
                    End If
                    AddHTML("</div>")   'hide
                Else
                    outfile.Write(Chr(34) & myFolder & Chr(34) & ",")
                    outfile.Write(Chr(34) & strOwner & Chr(34) & ",")
                    outfile.Write(Chr(34) & ace.IdentityReference.Value & Chr(34) & ",")
                    outfile.Write(Chr(34) & ACL_Type & Chr(34) & ",")
                    outfile.Write(Chr(34) & ace.IsInherited & Chr(34) & ",")
                    outfile.Write(Chr(34) & perms & Chr(34))
                    outfile.WriteLine()
                End If


            Next


            If boolHTML Then
                'If boolAddedHtmlStart = False Then
                If countEntries > 0 Then
                    'boolAddedHtmlStart = True


                    AddHTML("	</div>") 'hide main
                    AddHTML("</div>") 'outer main
                End If
            End If

            intTotalFolders = intTotalFolders + 1
            BackgroundWorker1.ReportProgress(1)

            'If less than max depth.. scan subfolders
            If Not myFolder.EndsWith("\") Then myFolder = myFolder & "\"
            Dim intFolderDepth As Integer = 0
            Dim tmp As String = Mid(myFolder, Len(strRootFolder) + 1)
            Dim arrFolders As String() = Split(tmp, "\")
            intFolderDepth = UBound(arrFolders)
            Debug.Print("Depth=" & intFolderDepth & "..." & myFolder)
            If intFolderDepth < intMaxDepth Then
                For Each subdir As DirectoryInfo In di.GetDirectories
                    ListFolderPermissions(subdir.FullName)
                Next
            End If
        Catch ex As Exception
            If Me.TextBoxErrors.InvokeRequired Then
                ' It's on a different thread, so use Invoke.
                Dim f As New SetTextCallback(AddressOf SetTextErrors)
                'Dim NewText As String = "Path too long:  " & myFolder
                Dim NewText As String = "ERROR!  " & vbCrLf & myFolder & vbCrLf & ex.Message & vbCrLf & vbCrLf
                Me.Invoke(f, New Object() {[NewText]})
            End If
            Exit Sub
        End Try
        


    End Sub

    Private Sub SetTextErrors(ByVal [text] As String)
        Me.TextBoxErrors.Text = [text] & vbCrLf & TextBoxErrors.Text
    End Sub

    Private Function UnCamelCase(ByVal strText As String)


        Dim strPattern As String = "([a-z])([A-Z])"
        Return Trim(Regex.Replace(strText, strPattern, "$1 $2"))

    End Function

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub WriteStartHTML()
        AddHTML("<html>")
        AddHTML("<head>")
        AddHTML("<style>")
        AddHTML("	body {")
        AddHTML("		font: 10pt Arial;")
        AddHTML("	}")
        AddHTML("")
        AddHTML("	.outer_expanded {")
        AddHTML("		cursor: pointer;")
        AddHTML("		padding-left: 15px;")
        AddHTML("		background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAYAAAA71pVKAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwQAADsEBuJFr7QAAABp0RVh0U29mdHdhcmUAUGFpbnQuTkVUIHYzLjUuMTFH80I3AAAANklEQVQ4T2P4//8/A7mYbI0gC2mnmQEI8HkJvyQlmgkF5HDwMyh8CGHkcCAU2owDE1WDN5EAAFordqcb0c1QAAAAAElFTkSuQmCC) no-repeat;")
        AddHTML("	}")
        AddHTML("")
        AddHTML("	.outer_collapsed {")
        AddHTML("		cursor: pointer;")
        AddHTML("		padding-left: 15px;")
        AddHTML("		background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAYAAAA71pVKAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwAAADsABataJCQAAABp0RVh0U29mdHdhcmUAUGFpbnQuTkVUIHYzLjUuMTFH80I3AAAAM0lEQVQ4T2P4//8/A7mYbI0gC4ejZgawr3AHKF4/DxHNIGcSwshhMBz8jB6nFEUVodwGAJiRfp45ZSrPAAAAAElFTkSuQmCC) no-repeat;")
        AddHTML("	}")
        AddHTML("	.folderTitle:hover { color: blue; text-decoration: underline; }")
        AddHTML("	.folderTitle { padding-top: 3px;}")
        AddHTML("")
        AddHTML("	.even { background-color: #f0f0f0; }")
        AddHTML("	.show { display: block;margin-left: 30px;background-color: Bisque;}")
        AddHTML("	.hide { display: none;margin-left: 30px;}")
        AddHTML("</style>")
        AddHTML("")
        AddHTML("<script>")
        AddHTML("")
        AddHTML("	function showNext(elem) {")
        AddHTML("		var elem_next = get_nextsibling(elem);")
        AddHTML("")
        AddHTML("		if (elem.className.match('outer_collapsed')) {")
        AddHTML("			elem.className = elem.className.replace(/outer_collapsed/,'outer_expanded');")
        AddHTML("			elem_next.className = 'show';")
        AddHTML("		} else {")
        AddHTML("			elem.className = elem.className.replace(/outer_expanded/,'outer_collapsed');")
        AddHTML("			elem_next.className = 'hide';")
        AddHTML("		}")
        AddHTML("	}")
        AddHTML("")
        AddHTML("	function get_nextsibling(n) {")
        AddHTML("		x=n.nextSibling;")
        AddHTML("		while (x.nodeType!=1) {")
        AddHTML("			x=x.nextSibling;")
        AddHTML("		}")
        AddHTML("		return x;")
        AddHTML("	}")
        AddHTML("")
        AddHTML("</script>")
        AddHTML("</head>")
        AddHTML("<body>")
        AddHTML("")
        AddHTML("<h2>" & Application.ProductName & "</h2>")
        AddHTML("Base Folder:  " & strRootFolder & "<br>")
        AddHTML("Date:  " & Now & "<br>")
        AddHTML("Subfolders included?:  " & ComboBoxScanSubfolders.Text)
    End Sub

    Private Sub AddHTML(ByVal myText As String)
        outfile.WriteLine(myText)
    End Sub



    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub
End Class
