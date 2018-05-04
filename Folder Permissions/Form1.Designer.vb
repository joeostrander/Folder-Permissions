<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LabelRootFolder = New System.Windows.Forms.Label()
        Me.TextBoxRootFolder = New System.Windows.Forms.TextBox()
        Me.ButtonBrowse = New System.Windows.Forms.Button()
        Me.ComboBoxMaxDepth = New System.Windows.Forms.ComboBox()
        Me.LabelMaxDepth = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxOutputTo = New System.Windows.Forms.TextBox()
        Me.ButtonSelectOutput = New System.Windows.Forms.Button()
        Me.ComboBoxScanSubfolders = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ButtonScan = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.TextBoxErrors = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelRootFolder
        '
        Me.LabelRootFolder.AutoSize = True
        Me.LabelRootFolder.Location = New System.Drawing.Point(2, 15)
        Me.LabelRootFolder.Name = "LabelRootFolder"
        Me.LabelRootFolder.Size = New System.Drawing.Size(74, 13)
        Me.LabelRootFolder.TabIndex = 0
        Me.LabelRootFolder.Text = "&Folder to scan"
        '
        'TextBoxRootFolder
        '
        Me.TextBoxRootFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxRootFolder.Location = New System.Drawing.Point(120, 12)
        Me.TextBoxRootFolder.Name = "TextBoxRootFolder"
        Me.TextBoxRootFolder.Size = New System.Drawing.Size(388, 20)
        Me.TextBoxRootFolder.TabIndex = 1
        '
        'ButtonBrowse
        '
        Me.ButtonBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonBrowse.FlatAppearance.BorderSize = 0
        Me.ButtonBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonBrowse.Location = New System.Drawing.Point(511, 10)
        Me.ButtonBrowse.Name = "ButtonBrowse"
        Me.ButtonBrowse.Size = New System.Drawing.Size(30, 23)
        Me.ButtonBrowse.TabIndex = 2
        Me.ButtonBrowse.Text = "..."
        Me.ButtonBrowse.UseVisualStyleBackColor = True
        '
        'ComboBoxMaxDepth
        '
        Me.ComboBoxMaxDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMaxDepth.FormattingEnabled = True
        Me.ComboBoxMaxDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "None"})
        Me.ComboBoxMaxDepth.Location = New System.Drawing.Point(120, 93)
        Me.ComboBoxMaxDepth.Name = "ComboBoxMaxDepth"
        Me.ComboBoxMaxDepth.Size = New System.Drawing.Size(55, 21)
        Me.ComboBoxMaxDepth.TabIndex = 10
        '
        'LabelMaxDepth
        '
        Me.LabelMaxDepth.AutoSize = True
        Me.LabelMaxDepth.Location = New System.Drawing.Point(2, 95)
        Me.LabelMaxDepth.Name = "LabelMaxDepth"
        Me.LabelMaxDepth.Size = New System.Drawing.Size(59, 13)
        Me.LabelMaxDepth.TabIndex = 9
        Me.LabelMaxDepth.Text = "Max &Depth"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Save &As (HTML/CSV)"
        '
        'TextBoxOutputTo
        '
        Me.TextBoxOutputTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxOutputTo.Location = New System.Drawing.Point(120, 38)
        Me.TextBoxOutputTo.Name = "TextBoxOutputTo"
        Me.TextBoxOutputTo.Size = New System.Drawing.Size(388, 20)
        Me.TextBoxOutputTo.TabIndex = 4
        '
        'ButtonSelectOutput
        '
        Me.ButtonSelectOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSelectOutput.FlatAppearance.BorderSize = 0
        Me.ButtonSelectOutput.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonSelectOutput.Location = New System.Drawing.Point(511, 36)
        Me.ButtonSelectOutput.Name = "ButtonSelectOutput"
        Me.ButtonSelectOutput.Size = New System.Drawing.Size(30, 23)
        Me.ButtonSelectOutput.TabIndex = 5
        Me.ButtonSelectOutput.Text = "..."
        Me.ButtonSelectOutput.UseVisualStyleBackColor = True
        '
        'ComboBoxScanSubfolders
        '
        Me.ComboBoxScanSubfolders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxScanSubfolders.FormattingEnabled = True
        Me.ComboBoxScanSubfolders.Items.AddRange(New Object() {"Yes", "No"})
        Me.ComboBoxScanSubfolders.Location = New System.Drawing.Point(120, 65)
        Me.ComboBoxScanSubfolders.Name = "ComboBoxScanSubfolders"
        Me.ComboBoxScanSubfolders.Size = New System.Drawing.Size(55, 21)
        Me.ComboBoxScanSubfolders.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Scan Su&bfolders?"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "CSV Files|*.csv|HTML Files|*.html"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select a folder to scan:"
        '
        'ButtonScan
        '
        Me.ButtonScan.Location = New System.Drawing.Point(5, 130)
        Me.ButtonScan.Name = "ButtonScan"
        Me.ButtonScan.Size = New System.Drawing.Size(108, 23)
        Me.ButtonScan.TabIndex = 11
        Me.ButtonScan.Text = "&Scan Now"
        Me.ButtonScan.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 219)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(569, 22)
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Enabled = False
        Me.ButtonCancel.Location = New System.Drawing.Point(119, 130)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(108, 23)
        Me.ButtonCancel.TabIndex = 12
        Me.ButtonCancel.Text = "&Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'TextBoxErrors
        '
        Me.TextBoxErrors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxErrors.Location = New System.Drawing.Point(5, 160)
        Me.TextBoxErrors.Multiline = True
        Me.TextBoxErrors.Name = "TextBoxErrors"
        Me.TextBoxErrors.ReadOnly = True
        Me.TextBoxErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxErrors.Size = New System.Drawing.Size(559, 56)
        Me.TextBoxErrors.TabIndex = 13
        Me.TextBoxErrors.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(83, 26)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(82, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(217, 67)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(163, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Include &Inherited Permissions"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 241)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBoxErrors)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ButtonScan)
        Me.Controls.Add(Me.ComboBoxScanSubfolders)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxOutputTo)
        Me.Controls.Add(Me.ButtonSelectOutput)
        Me.Controls.Add(Me.ComboBoxMaxDepth)
        Me.Controls.Add(Me.LabelMaxDepth)
        Me.Controls.Add(Me.LabelRootFolder)
        Me.Controls.Add(Me.TextBoxRootFolder)
        Me.Controls.Add(Me.ButtonBrowse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(577, 275)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelRootFolder As System.Windows.Forms.Label
    Friend WithEvents TextBoxRootFolder As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBrowse As System.Windows.Forms.Button
    Friend WithEvents ComboBoxMaxDepth As System.Windows.Forms.ComboBox
    Friend WithEvents LabelMaxDepth As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxOutputTo As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSelectOutput As System.Windows.Forms.Button
    Friend WithEvents ComboBoxScanSubfolders As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ButtonScan As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents TextBoxErrors As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox1 As CheckBox
End Class
