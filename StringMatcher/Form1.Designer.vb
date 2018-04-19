<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StringMatcher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StringMatcher))
        Me.String1 = New System.Windows.Forms.TextBox()
        Me.String2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'String1
        '
        Me.String1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.String1.Location = New System.Drawing.Point(12, 31)
        Me.String1.Name = "String1"
        Me.String1.Size = New System.Drawing.Size(310, 20)
        Me.String1.TabIndex = 0
        '
        'String2
        '
        Me.String2.Location = New System.Drawing.Point(12, 88)
        Me.String2.Name = "String2"
        Me.String2.Size = New System.Drawing.Size(310, 20)
        Me.String2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(144, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "String No 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(144, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "String No 2"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 126)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Symmetric Match"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(208, 126)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(114, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Asymmetric Match"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'StringMatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(334, 161)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.String2)
        Me.Controls.Add(Me.String1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "StringMatcher"
        Me.Text = "StringMatcher by p3160026"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents String1 As TextBox
    Friend WithEvents String2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
End Class
