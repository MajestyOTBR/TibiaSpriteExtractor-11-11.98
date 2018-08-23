<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractSpritesheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SliceSpritesheatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CookingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BakeASprToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ExtractingToolStripMenuItem, Me.CookingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(605, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ExtractingToolStripMenuItem
        '
        Me.ExtractingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExtractSpritesheetToolStripMenuItem, Me.SliceSpritesheatToolStripMenuItem})
        Me.ExtractingToolStripMenuItem.Name = "ExtractingToolStripMenuItem"
        Me.ExtractingToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.ExtractingToolStripMenuItem.Text = "Extracting"
        '
        'ExtractSpritesheetToolStripMenuItem
        '
        Me.ExtractSpritesheetToolStripMenuItem.Name = "ExtractSpritesheetToolStripMenuItem"
        Me.ExtractSpritesheetToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ExtractSpritesheetToolStripMenuItem.Text = "Extract spritesheet"
        '
        'SliceSpritesheatToolStripMenuItem
        '
        Me.SliceSpritesheatToolStripMenuItem.Name = "SliceSpritesheatToolStripMenuItem"
        Me.SliceSpritesheatToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SliceSpritesheatToolStripMenuItem.Text = "Slice spritesheat"
        '
        'CookingToolStripMenuItem
        '
        Me.CookingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BakeASprToolStripMenuItem})
        Me.CookingToolStripMenuItem.Name = "CookingToolStripMenuItem"
        Me.CookingToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.CookingToolStripMenuItem.Text = "Cooking"
        '
        'BakeASprToolStripMenuItem
        '
        Me.BakeASprToolStripMenuItem.Name = "BakeASprToolStripMenuItem"
        Me.BakeASprToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BakeASprToolStripMenuItem.Text = "Bake a spr/dat"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 260)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(14, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(196, 121)
        Me.ListBox1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListBox2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Location = New System.Drawing.Point(16, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(577, 245)
        Me.Panel1.TabIndex = 2
        Me.Panel1.Visible = False
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(14, 144)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.ScrollAlwaysVisible = True
        Me.ListBox2.Size = New System.Drawing.Size(196, 56)
        Me.ListBox2.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 209)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Create"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 285)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "TibiaExtractor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExtractingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExtractSpritesheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SliceSpritesheatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents CookingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BakeASprToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox2 As ListBox
End Class
