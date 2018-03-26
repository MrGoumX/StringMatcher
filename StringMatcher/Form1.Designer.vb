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
        Me.String1 = New System.Windows.Forms.TextBox()
        Me.String2 = New System.Windows.Forms.TextBox()
        Me.KMPMatch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BMMatch = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'String1
        '
        Me.String1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.String1.Location = New System.Drawing.Point(12, 31)
        Me.String1.Name = "String1"
        Me.String1.Size = New System.Drawing.Size(260, 20)
        Me.String1.TabIndex = 0
        '
        'String2
        '
        Me.String2.Location = New System.Drawing.Point(12, 88)
        Me.String2.Name = "String2"
        Me.String2.Size = New System.Drawing.Size(260, 20)
        Me.String2.TabIndex = 1
        '
        'KMPMatch
        '
        Me.KMPMatch.Location = New System.Drawing.Point(12, 173)
        Me.KMPMatch.Name = "KMPMatch"
        Me.KMPMatch.Size = New System.Drawing.Size(75, 23)
        Me.KMPMatch.TabIndex = 2
        Me.KMPMatch.Text = "KMP Match"
        Me.KMPMatch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(113, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "String No 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "String No 2"
        '
        'BMMatch
        '
        Me.BMMatch.Location = New System.Drawing.Point(197, 173)
        Me.BMMatch.Name = "BMMatch"
        Me.BMMatch.Size = New System.Drawing.Size(75, 23)
        Me.BMMatch.TabIndex = 5
        Me.BMMatch.Text = "BM Match"
        Me.BMMatch.UseVisualStyleBackColor = True
        '
        'StringMatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.BMMatch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.KMPMatch)
        Me.Controls.Add(Me.String2)
        Me.Controls.Add(Me.String1)
        Me.Name = "StringMatcher"
        Me.Text = "StringMatcher by p3160026"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents String1 As TextBox
    Friend WithEvents String2 As TextBox
    Friend WithEvents KMPMatch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BMMatch As Button
End Class
