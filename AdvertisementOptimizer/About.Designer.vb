<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.OK_Button = New System.Windows.Forms.Button()
      Me.AboutRichTextBox = New System.Windows.Forms.RichTextBox()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TableLayoutPanel1.ColumnCount = 1
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(350, 264)
      Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 1
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(100, 36)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'OK_Button
      '
      Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.OK_Button.Location = New System.Drawing.Point(5, 4)
      Me.OK_Button.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.OK_Button.Name = "OK_Button"
      Me.OK_Button.Size = New System.Drawing.Size(89, 28)
      Me.OK_Button.TabIndex = 0
      Me.OK_Button.Text = "OK"
      '
      'AboutRichTextBox
      '
      Me.AboutRichTextBox.BackColor = System.Drawing.SystemColors.Control
      Me.AboutRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.AboutRichTextBox.Location = New System.Drawing.Point(12, 12)
      Me.AboutRichTextBox.Name = "AboutRichTextBox"
      Me.AboutRichTextBox.ReadOnly = True
      Me.AboutRichTextBox.Size = New System.Drawing.Size(438, 240)
      Me.AboutRichTextBox.TabIndex = 1
      Me.AboutRichTextBox.Text = resources.GetString("AboutRichTextBox.Text")
      '
      'About
      '
      Me.AcceptButton = Me.OK_Button
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(469, 315)
      Me.Controls.Add(Me.AboutRichTextBox)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "About"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "About"
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents AboutRichTextBox As System.Windows.Forms.RichTextBox

End Class
