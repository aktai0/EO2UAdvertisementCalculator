<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WardGroup
   Inherits System.Windows.Forms.UserControl

   'UserControl overrides dispose to clean up the component list.
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
      Me.MainGroupBox = New System.Windows.Forms.GroupBox()
      Me.GroupFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
      Me.DistrictStarsPanel = New System.Windows.Forms.Panel()
      Me.StarLimitComboBox = New System.Windows.Forms.ComboBox()
      Me.HighestRecipeLabel = New System.Windows.Forms.Label()
      Me.DistrictComboBox = New System.Windows.Forms.ComboBox()
      Me.DistrictLabelLabel = New System.Windows.Forms.Label()
      Me.GourmetCheckBox = New System.Windows.Forms.CheckBox()
      Me.InnerPanel = New System.Windows.Forms.FlowLayoutPanel()
      Me.BottomPanel = New System.Windows.Forms.Panel()
      Me.FoodResultLabel = New System.Windows.Forms.Label()
      Me.FoodDisplayLabel = New System.Windows.Forms.Label()
      Me.CalculateButton = New System.Windows.Forms.Button()
      Me.ResetButton = New System.Windows.Forms.Button()
      Me.NextButton = New System.Windows.Forms.Button()
      Me.PrevButton = New System.Windows.Forms.Button()
      Me.ButtonPanel = New System.Windows.Forms.Panel()
      Me.MainGroupBox.SuspendLayout()
      Me.GroupFlowLayoutPanel.SuspendLayout()
      Me.DistrictStarsPanel.SuspendLayout()
      Me.BottomPanel.SuspendLayout()
      Me.ButtonPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      'MainGroupBox
      '
      Me.MainGroupBox.Controls.Add(Me.GroupFlowLayoutPanel)
      Me.MainGroupBox.Controls.Add(Me.BottomPanel)
      Me.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.MainGroupBox.Location = New System.Drawing.Point(0, 0)
      Me.MainGroupBox.Margin = New System.Windows.Forms.Padding(0)
      Me.MainGroupBox.Name = "MainGroupBox"
      Me.MainGroupBox.Size = New System.Drawing.Size(756, 204)
      Me.MainGroupBox.TabIndex = 2
      Me.MainGroupBox.TabStop = False
      Me.MainGroupBox.Text = "Name"
      '
      'GroupFlowLayoutPanel
      '
      Me.GroupFlowLayoutPanel.Controls.Add(Me.DistrictStarsPanel)
      Me.GroupFlowLayoutPanel.Controls.Add(Me.InnerPanel)
      Me.GroupFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.GroupFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
      Me.GroupFlowLayoutPanel.Location = New System.Drawing.Point(3, 18)
      Me.GroupFlowLayoutPanel.Margin = New System.Windows.Forms.Padding(0)
      Me.GroupFlowLayoutPanel.Name = "GroupFlowLayoutPanel"
      Me.GroupFlowLayoutPanel.Size = New System.Drawing.Size(750, 117)
      Me.GroupFlowLayoutPanel.TabIndex = 4
      '
      'DistrictStarsPanel
      '
      Me.DistrictStarsPanel.AutoSize = True
      Me.DistrictStarsPanel.Controls.Add(Me.StarLimitComboBox)
      Me.DistrictStarsPanel.Controls.Add(Me.HighestRecipeLabel)
      Me.DistrictStarsPanel.Controls.Add(Me.DistrictComboBox)
      Me.DistrictStarsPanel.Controls.Add(Me.DistrictLabelLabel)
      Me.DistrictStarsPanel.Controls.Add(Me.GourmetCheckBox)
      Me.DistrictStarsPanel.Location = New System.Drawing.Point(0, 0)
      Me.DistrictStarsPanel.Margin = New System.Windows.Forms.Padding(0)
      Me.DistrictStarsPanel.Name = "DistrictStarsPanel"
      Me.DistrictStarsPanel.Size = New System.Drawing.Size(534, 30)
      Me.DistrictStarsPanel.TabIndex = 3
      '
      'StarLimitComboBox
      '
      Me.StarLimitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.StarLimitComboBox.FormattingEnabled = True
      Me.StarLimitComboBox.Items.AddRange(New Object() {"★☆☆☆☆☆ (1)", "★★☆☆☆☆ (2)", "★★★☆☆☆ (3)", "★★★★☆☆ (4)", "★★★★★☆ (5)", "★★★★★★ (6)"})
      Me.StarLimitComboBox.Location = New System.Drawing.Point(287, 3)
      Me.StarLimitComboBox.Name = "StarLimitComboBox"
      Me.StarLimitComboBox.Size = New System.Drawing.Size(121, 24)
      Me.StarLimitComboBox.TabIndex = 5
      '
      'HighestRecipeLabel
      '
      Me.HighestRecipeLabel.AutoSize = True
      Me.HighestRecipeLabel.Location = New System.Drawing.Point(181, 6)
      Me.HighestRecipeLabel.Name = "HighestRecipeLabel"
      Me.HighestRecipeLabel.Size = New System.Drawing.Size(108, 17)
      Me.HighestRecipeLabel.TabIndex = 6
      Me.HighestRecipeLabel.Text = "Highest Recipe:"
      '
      'DistrictComboBox
      '
      Me.DistrictComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.DistrictComboBox.FormattingEnabled = True
      Me.DistrictComboBox.Items.AddRange(New Object() {"South", "East", "West", "North", "Uptown", "Slums"})
      Me.DistrictComboBox.Location = New System.Drawing.Point(56, 3)
      Me.DistrictComboBox.Name = "DistrictComboBox"
      Me.DistrictComboBox.Size = New System.Drawing.Size(121, 24)
      Me.DistrictComboBox.TabIndex = 1
      '
      'DistrictLabelLabel
      '
      Me.DistrictLabelLabel.AutoSize = True
      Me.DistrictLabelLabel.Location = New System.Drawing.Point(3, 6)
      Me.DistrictLabelLabel.Name = "DistrictLabelLabel"
      Me.DistrictLabelLabel.Size = New System.Drawing.Size(55, 17)
      Me.DistrictLabelLabel.TabIndex = 2
      Me.DistrictLabelLabel.Text = "District:"
      '
      'GourmetCheckBox
      '
      Me.GourmetCheckBox.AutoSize = True
      Me.GourmetCheckBox.Location = New System.Drawing.Point(414, 5)
      Me.GourmetCheckBox.Name = "GourmetCheckBox"
      Me.GourmetCheckBox.Size = New System.Drawing.Size(117, 21)
      Me.GourmetCheckBox.TabIndex = 4
      Me.GourmetCheckBox.Text = "Gourmet King"
      Me.GourmetCheckBox.UseVisualStyleBackColor = True
      '
      'InnerPanel
      '
      Me.InnerPanel.AutoSize = True
      Me.InnerPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.InnerPanel.Location = New System.Drawing.Point(0, 30)
      Me.InnerPanel.Margin = New System.Windows.Forms.Padding(0)
      Me.InnerPanel.Name = "InnerPanel"
      Me.InnerPanel.Size = New System.Drawing.Size(534, 0)
      Me.InnerPanel.TabIndex = 0
      '
      'BottomPanel
      '
      Me.BottomPanel.Controls.Add(Me.ButtonPanel)
      Me.BottomPanel.Controls.Add(Me.FoodResultLabel)
      Me.BottomPanel.Controls.Add(Me.FoodDisplayLabel)
      Me.BottomPanel.Controls.Add(Me.CalculateButton)
      Me.BottomPanel.Controls.Add(Me.ResetButton)
      Me.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.BottomPanel.Location = New System.Drawing.Point(3, 135)
      Me.BottomPanel.Margin = New System.Windows.Forms.Padding(0)
      Me.BottomPanel.Name = "BottomPanel"
      Me.BottomPanel.Size = New System.Drawing.Size(750, 66)
      Me.BottomPanel.TabIndex = 3
      '
      'FoodResultLabel
      '
      Me.FoodResultLabel.AutoSize = True
      Me.FoodResultLabel.Font = New System.Drawing.Font("Book Antiqua", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FoodResultLabel.ForeColor = System.Drawing.Color.DarkGreen
      Me.FoodResultLabel.Location = New System.Drawing.Point(264, 8)
      Me.FoodResultLabel.Name = "FoodResultLabel"
      Me.FoodResultLabel.Size = New System.Drawing.Size(132, 48)
      Me.FoodResultLabel.TabIndex = 4
      Me.FoodResultLabel.Text = "Example Text" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Line 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
      '
      'FoodDisplayLabel
      '
      Me.FoodDisplayLabel.AutoSize = True
      Me.FoodDisplayLabel.Font = New System.Drawing.Font("Modern No. 20", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FoodDisplayLabel.Location = New System.Drawing.Point(192, 21)
      Me.FoodDisplayLabel.Name = "FoodDisplayLabel"
      Me.FoodDisplayLabel.Size = New System.Drawing.Size(66, 25)
      Me.FoodDisplayLabel.TabIndex = 3
      Me.FoodDisplayLabel.Text = "Food:"
      '
      'CalculateButton
      '
      Me.CalculateButton.Location = New System.Drawing.Point(3, 8)
      Me.CalculateButton.Name = "CalculateButton"
      Me.CalculateButton.Size = New System.Drawing.Size(166, 23)
      Me.CalculateButton.TabIndex = 2
      Me.CalculateButton.Text = "Calculate"
      Me.CalculateButton.UseVisualStyleBackColor = True
      '
      'ResetButton
      '
      Me.ResetButton.Location = New System.Drawing.Point(3, 37)
      Me.ResetButton.Name = "ResetButton"
      Me.ResetButton.Size = New System.Drawing.Size(166, 23)
      Me.ResetButton.TabIndex = 1
      Me.ResetButton.Text = "Reset"
      Me.ResetButton.UseVisualStyleBackColor = True
      '
      'NextButton
      '
      Me.NextButton.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.NextButton.Location = New System.Drawing.Point(0, 37)
      Me.NextButton.Name = "NextButton"
      Me.NextButton.Size = New System.Drawing.Size(71, 29)
      Me.NextButton.TabIndex = 5
      Me.NextButton.Text = "Next"
      Me.NextButton.UseVisualStyleBackColor = True
      '
      'PrevButton
      '
      Me.PrevButton.Dock = System.Windows.Forms.DockStyle.Top
      Me.PrevButton.Location = New System.Drawing.Point(0, 0)
      Me.PrevButton.Name = "PrevButton"
      Me.PrevButton.Size = New System.Drawing.Size(71, 31)
      Me.PrevButton.TabIndex = 6
      Me.PrevButton.Text = "Prev"
      Me.PrevButton.UseVisualStyleBackColor = True
      '
      'ButtonPanel
      '
      Me.ButtonPanel.Controls.Add(Me.PrevButton)
      Me.ButtonPanel.Controls.Add(Me.NextButton)
      Me.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Right
      Me.ButtonPanel.Location = New System.Drawing.Point(679, 0)
      Me.ButtonPanel.Name = "ButtonPanel"
      Me.ButtonPanel.Size = New System.Drawing.Size(71, 66)
      Me.ButtonPanel.TabIndex = 7
      '
      'WardGroup
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.MainGroupBox)
      Me.Margin = New System.Windows.Forms.Padding(0)
      Me.Name = "WardGroup"
      Me.Size = New System.Drawing.Size(756, 204)
      Me.MainGroupBox.ResumeLayout(False)
      Me.GroupFlowLayoutPanel.ResumeLayout(False)
      Me.GroupFlowLayoutPanel.PerformLayout()
      Me.DistrictStarsPanel.ResumeLayout(False)
      Me.DistrictStarsPanel.PerformLayout()
      Me.BottomPanel.ResumeLayout(False)
      Me.BottomPanel.PerformLayout()
      Me.ButtonPanel.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents MainGroupBox As System.Windows.Forms.GroupBox
   Friend WithEvents InnerPanel As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents ResetButton As System.Windows.Forms.Button
   Friend WithEvents CalculateButton As System.Windows.Forms.Button
   Friend WithEvents BottomPanel As System.Windows.Forms.Panel
   Friend WithEvents FoodDisplayLabel As System.Windows.Forms.Label
   Friend WithEvents FoodResultLabel As System.Windows.Forms.Label
   Friend WithEvents GroupFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents DistrictComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents DistrictStarsPanel As System.Windows.Forms.Panel
   Friend WithEvents DistrictLabelLabel As System.Windows.Forms.Label
   Friend WithEvents GourmetCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents StarLimitComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents HighestRecipeLabel As System.Windows.Forms.Label
   Friend WithEvents PrevButton As System.Windows.Forms.Button
   Friend WithEvents NextButton As System.Windows.Forms.Button
   Friend WithEvents ButtonPanel As System.Windows.Forms.Panel

End Class
