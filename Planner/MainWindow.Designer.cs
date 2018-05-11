﻿namespace Planner
{
		partial class MainWindow
		{
				/// <summary>
				/// Required designer variable.
				/// </summary>
				private System.ComponentModel.IContainer components = null;

				/// <summary>
				/// Clean up any resources being used.
				/// </summary>
				/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
				protected override void Dispose(bool disposing)
				{
						if (disposing && (components != null))
						{
								components.Dispose();
						}
						base.Dispose(disposing);
				}

				#region Windows Form Designer generated code

				/// <summary>
				/// Required method for Designer support - do not modify
				/// the contents of this method with the code editor.
				/// </summary>
				private void InitializeComponent()
				{
						this.components = new System.ComponentModel.Container();
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
						this.FilePanel = new System.Windows.Forms.Panel();
						this.FileTree = new System.Windows.Forms.TreeView();
						this.FileTreeImages = new System.Windows.Forms.ImageList(this.components);
						this.FileToolStrip = new System.Windows.Forms.ToolStrip();
						this.NewPlanButton = new System.Windows.Forms.ToolStripButton();
						this.NewFolderButton = new System.Windows.Forms.ToolStripButton();
						this.DeleteButton = new System.Windows.Forms.ToolStripButton();
						this.DesignerPanel = new System.Windows.Forms.Panel();
						this.DesignerTools = new System.Windows.Forms.ToolStrip();
						this.PlanName = new System.Windows.Forms.ToolStripLabel();
						this.NewContainer = new System.Windows.Forms.ToolStripButton();
						this.DeleteContainer = new System.Windows.Forms.ToolStripButton();
						this.PropertiesPanel = new System.Windows.Forms.Panel();
						this.EditText = new System.Windows.Forms.RichTextBox();
						this.TextLableProperties = new System.Windows.Forms.Label();
						this.EditTitle = new System.Windows.Forms.TextBox();
						this.TitleLabelProperties = new System.Windows.Forms.Label();
						this.PropertiesPanelLabel = new System.Windows.Forms.Label();
						this.ToolStrip = new System.Windows.Forms.ToolStrip();
						this.NewProjectButton = new System.Windows.Forms.ToolStripButton();
						this.OpenProjectButton = new System.Windows.Forms.ToolStripButton();
						this.RenderModeGroup = new System.Windows.Forms.GroupBox();
						this.RenderModeRelative = new System.Windows.Forms.RadioButton();
						this.RenderModeLinear = new System.Windows.Forms.RadioButton();
						this.FilePanel.SuspendLayout();
						this.FileToolStrip.SuspendLayout();
						this.DesignerTools.SuspendLayout();
						this.PropertiesPanel.SuspendLayout();
						this.ToolStrip.SuspendLayout();
						this.RenderModeGroup.SuspendLayout();
						this.SuspendLayout();
						// 
						// FilePanel
						// 
						this.FilePanel.Controls.Add(this.FileTree);
						this.FilePanel.Controls.Add(this.FileToolStrip);
						this.FilePanel.Dock = System.Windows.Forms.DockStyle.Left;
						this.FilePanel.Location = new System.Drawing.Point(0, 27);
						this.FilePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
						this.FilePanel.Name = "FilePanel";
						this.FilePanel.Size = new System.Drawing.Size(296, 527);
						this.FilePanel.TabIndex = 0;
						// 
						// FileTree
						// 
						this.FileTree.Dock = System.Windows.Forms.DockStyle.Fill;
						this.FileTree.ImageIndex = 0;
						this.FileTree.ImageList = this.FileTreeImages;
						this.FileTree.Location = new System.Drawing.Point(0, 27);
						this.FileTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
						this.FileTree.Name = "FileTree";
						this.FileTree.SelectedImageIndex = 0;
						this.FileTree.Size = new System.Drawing.Size(296, 500);
						this.FileTree.TabIndex = 1;
						this.FileTree.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.CloseFolderIcon);
						this.FileTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.OpenFolderIcon);
						this.FileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SelectPlan);
						// 
						// FileTreeImages
						// 
						this.FileTreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FileTreeImages.ImageStream")));
						this.FileTreeImages.TransparentColor = System.Drawing.Color.Transparent;
						this.FileTreeImages.Images.SetKeyName(0, "Folder");
						this.FileTreeImages.Images.SetKeyName(1, "FolderOpen");
						this.FileTreeImages.Images.SetKeyName(2, "File");
						// 
						// FileToolStrip
						// 
						this.FileToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
						this.FileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewPlanButton,
            this.NewFolderButton,
            this.DeleteButton});
						this.FileToolStrip.Location = new System.Drawing.Point(0, 0);
						this.FileToolStrip.Name = "FileToolStrip";
						this.FileToolStrip.Size = new System.Drawing.Size(296, 27);
						this.FileToolStrip.TabIndex = 2;
						// 
						// NewPlanButton
						// 
						this.NewPlanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.NewPlanButton.Image = global::Planner.Properties.Resources.AddFile_16x;
						this.NewPlanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.NewPlanButton.Name = "NewPlanButton";
						this.NewPlanButton.Size = new System.Drawing.Size(24, 24);
						this.NewPlanButton.ToolTipText = "New Plan";
						this.NewPlanButton.Click += new System.EventHandler(this.NewPlan);
						// 
						// NewFolderButton
						// 
						this.NewFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.NewFolderButton.Image = global::Planner.Properties.Resources.AddFolder_16x;
						this.NewFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.NewFolderButton.Name = "NewFolderButton";
						this.NewFolderButton.Size = new System.Drawing.Size(24, 24);
						this.NewFolderButton.ToolTipText = "New Folder";
						this.NewFolderButton.Click += new System.EventHandler(this.NewFolder);
						// 
						// DeleteButton
						// 
						this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.DeleteButton.Image = global::Planner.Properties.Resources.Cancel_16x;
						this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.DeleteButton.Name = "DeleteButton";
						this.DeleteButton.Size = new System.Drawing.Size(24, 24);
						this.DeleteButton.ToolTipText = "Remove Folder/Plan";
						this.DeleteButton.Click += new System.EventHandler(this.RemoveNode);
						// 
						// DesignerPanel
						// 
						this.DesignerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
						this.DesignerPanel.Location = new System.Drawing.Point(296, 27);
						this.DesignerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
						this.DesignerPanel.Name = "DesignerPanel";
						this.DesignerPanel.Size = new System.Drawing.Size(466, 527);
						this.DesignerPanel.TabIndex = 1;
						// 
						// DesignerTools
						// 
						this.DesignerTools.ImageScalingSize = new System.Drawing.Size(20, 20);
						this.DesignerTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlanName,
            this.NewContainer,
            this.DeleteContainer});
						this.DesignerTools.Location = new System.Drawing.Point(296, 27);
						this.DesignerTools.Name = "DesignerTools";
						this.DesignerTools.Size = new System.Drawing.Size(466, 27);
						this.DesignerTools.TabIndex = 1;
						this.DesignerTools.Text = "toolStrip1";
						// 
						// PlanName
						// 
						this.PlanName.Name = "PlanName";
						this.PlanName.Size = new System.Drawing.Size(0, 24);
						// 
						// NewContainer
						// 
						this.NewContainer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
						this.NewContainer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.NewContainer.Image = global::Planner.Properties.Resources.AddControl_16x;
						this.NewContainer.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.NewContainer.Name = "NewContainer";
						this.NewContainer.Size = new System.Drawing.Size(24, 24);
						this.NewContainer.ToolTipText = "New Container";
						this.NewContainer.Click += new System.EventHandler(this.AddContainer);
						// 
						// DeleteContainer
						// 
						this.DeleteContainer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
						this.DeleteContainer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.DeleteContainer.Image = global::Planner.Properties.Resources.Cancel_16x;
						this.DeleteContainer.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.DeleteContainer.Name = "DeleteContainer";
						this.DeleteContainer.Size = new System.Drawing.Size(24, 24);
						this.DeleteContainer.Click += new System.EventHandler(this.DeleteSelectedContainer);
						// 
						// PropertiesPanel
						// 
						this.PropertiesPanel.Controls.Add(this.EditText);
						this.PropertiesPanel.Controls.Add(this.TextLableProperties);
						this.PropertiesPanel.Controls.Add(this.RenderModeGroup);
						this.PropertiesPanel.Controls.Add(this.EditTitle);
						this.PropertiesPanel.Controls.Add(this.TitleLabelProperties);
						this.PropertiesPanel.Controls.Add(this.PropertiesPanelLabel);
						this.PropertiesPanel.Dock = System.Windows.Forms.DockStyle.Right;
						this.PropertiesPanel.Location = new System.Drawing.Point(762, 27);
						this.PropertiesPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
						this.PropertiesPanel.Name = "PropertiesPanel";
						this.PropertiesPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
						this.PropertiesPanel.Size = new System.Drawing.Size(305, 527);
						this.PropertiesPanel.TabIndex = 0;
						// 
						// EditText
						// 
						this.EditText.Dock = System.Windows.Forms.DockStyle.Fill;
						this.EditText.Location = new System.Drawing.Point(7, 157);
						this.EditText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
						this.EditText.Name = "EditText";
						this.EditText.Size = new System.Drawing.Size(291, 364);
						this.EditText.TabIndex = 4;
						this.EditText.Text = "";
						this.EditText.TextChanged += new System.EventHandler(this.UpdateText);
						// 
						// TextLableProperties
						// 
						this.TextLableProperties.AutoSize = true;
						this.TextLableProperties.Dock = System.Windows.Forms.DockStyle.Top;
						this.TextLableProperties.Location = new System.Drawing.Point(7, 128);
						this.TextLableProperties.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
						this.TextLableProperties.Name = "TextLableProperties";
						this.TextLableProperties.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
						this.TextLableProperties.Size = new System.Drawing.Size(39, 29);
						this.TextLableProperties.TabIndex = 3;
						this.TextLableProperties.Text = "Text:";
						// 
						// EditTitle
						// 
						this.EditTitle.Dock = System.Windows.Forms.DockStyle.Top;
						this.EditTitle.Location = new System.Drawing.Point(7, 58);
						this.EditTitle.Margin = new System.Windows.Forms.Padding(4);
						this.EditTitle.Name = "EditTitle";
						this.EditTitle.Size = new System.Drawing.Size(291, 22);
						this.EditTitle.TabIndex = 1;
						this.EditTitle.TextChanged += new System.EventHandler(this.UpdateTitle);
						// 
						// TitleLabelProperties
						// 
						this.TitleLabelProperties.AutoSize = true;
						this.TitleLabelProperties.Dock = System.Windows.Forms.DockStyle.Top;
						this.TitleLabelProperties.Location = new System.Drawing.Point(7, 29);
						this.TitleLabelProperties.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
						this.TitleLabelProperties.Name = "TitleLabelProperties";
						this.TitleLabelProperties.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
						this.TitleLabelProperties.Size = new System.Drawing.Size(39, 29);
						this.TitleLabelProperties.TabIndex = 2;
						this.TitleLabelProperties.Text = "Title:";
						// 
						// PropertiesPanelLabel
						// 
						this.PropertiesPanelLabel.AutoSize = true;
						this.PropertiesPanelLabel.Dock = System.Windows.Forms.DockStyle.Top;
						this.PropertiesPanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.PropertiesPanelLabel.Location = new System.Drawing.Point(7, 6);
						this.PropertiesPanelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
						this.PropertiesPanelLabel.Name = "PropertiesPanelLabel";
						this.PropertiesPanelLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
						this.PropertiesPanelLabel.Size = new System.Drawing.Size(83, 23);
						this.PropertiesPanelLabel.TabIndex = 0;
						this.PropertiesPanelLabel.Text = "Properties";
						// 
						// ToolStrip
						// 
						this.ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
						this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewProjectButton,
            this.OpenProjectButton});
						this.ToolStrip.Location = new System.Drawing.Point(0, 0);
						this.ToolStrip.Name = "ToolStrip";
						this.ToolStrip.Size = new System.Drawing.Size(1067, 27);
						this.ToolStrip.TabIndex = 1;
						// 
						// NewProjectButton
						// 
						this.NewProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
						this.NewProjectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.NewProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.NewProjectButton.Name = "NewProjectButton";
						this.NewProjectButton.Size = new System.Drawing.Size(93, 24);
						this.NewProjectButton.Text = "New Project";
						this.NewProjectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
						// 
						// OpenProjectButton
						// 
						this.OpenProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
						this.OpenProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.OpenProjectButton.Name = "OpenProjectButton";
						this.OpenProjectButton.Size = new System.Drawing.Size(99, 24);
						this.OpenProjectButton.Text = "Open Project";
						// 
						// RenderModeGroup
						// 
						this.RenderModeGroup.Controls.Add(this.RenderModeLinear);
						this.RenderModeGroup.Controls.Add(this.RenderModeRelative);
						this.RenderModeGroup.Dock = System.Windows.Forms.DockStyle.Top;
						this.RenderModeGroup.Location = new System.Drawing.Point(7, 80);
						this.RenderModeGroup.Name = "RenderModeGroup";
						this.RenderModeGroup.Padding = new System.Windows.Forms.Padding(5);
						this.RenderModeGroup.Size = new System.Drawing.Size(291, 48);
						this.RenderModeGroup.TabIndex = 6;
						this.RenderModeGroup.TabStop = false;
						this.RenderModeGroup.Text = "Render Mode";
						// 
						// RenderModeRelative
						// 
						this.RenderModeRelative.AutoSize = true;
						this.RenderModeRelative.Location = new System.Drawing.Point(8, 23);
						this.RenderModeRelative.Name = "RenderModeRelative";
						this.RenderModeRelative.Size = new System.Drawing.Size(80, 21);
						this.RenderModeRelative.TabIndex = 0;
						this.RenderModeRelative.TabStop = true;
						this.RenderModeRelative.Text = "Relative";
						this.RenderModeRelative.UseVisualStyleBackColor = true;
						this.RenderModeRelative.CheckedChanged += new System.EventHandler(this.RenderModeToRelative);
						// 
						// RenderModeLinear
						// 
						this.RenderModeLinear.AutoSize = true;
						this.RenderModeLinear.Location = new System.Drawing.Point(94, 23);
						this.RenderModeLinear.Name = "RenderModeLinear";
						this.RenderModeLinear.Size = new System.Drawing.Size(69, 21);
						this.RenderModeLinear.TabIndex = 1;
						this.RenderModeLinear.TabStop = true;
						this.RenderModeLinear.Text = "Linear";
						this.RenderModeLinear.UseVisualStyleBackColor = true;
						this.RenderModeLinear.CheckedChanged += new System.EventHandler(this.RenderModeToLinear);
						// 
						// MainWindow
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(1067, 554);
						this.Controls.Add(this.DesignerTools);
						this.Controls.Add(this.DesignerPanel);
						this.Controls.Add(this.PropertiesPanel);
						this.Controls.Add(this.FilePanel);
						this.Controls.Add(this.ToolStrip);
						this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
						this.Name = "MainWindow";
						this.Text = "Planner";
						this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
						this.FilePanel.ResumeLayout(false);
						this.FilePanel.PerformLayout();
						this.FileToolStrip.ResumeLayout(false);
						this.FileToolStrip.PerformLayout();
						this.DesignerTools.ResumeLayout(false);
						this.DesignerTools.PerformLayout();
						this.PropertiesPanel.ResumeLayout(false);
						this.PropertiesPanel.PerformLayout();
						this.ToolStrip.ResumeLayout(false);
						this.ToolStrip.PerformLayout();
						this.RenderModeGroup.ResumeLayout(false);
						this.RenderModeGroup.PerformLayout();
						this.ResumeLayout(false);
						this.PerformLayout();

				}

				#endregion

				private System.Windows.Forms.Panel FilePanel;
				private System.Windows.Forms.Panel DesignerPanel;
				private System.Windows.Forms.TreeView FileTree;
				private System.Windows.Forms.Panel PropertiesPanel;
				private System.Windows.Forms.ToolStrip ToolStrip;
				private System.Windows.Forms.ToolStripButton NewProjectButton;
				private System.Windows.Forms.ToolStripButton OpenProjectButton;
				private System.Windows.Forms.ToolStrip FileToolStrip;
				private System.Windows.Forms.ToolStripButton NewPlanButton;
				private System.Windows.Forms.ToolStripButton NewFolderButton;
				private System.Windows.Forms.ImageList FileTreeImages;
				private System.Windows.Forms.ToolStripButton DeleteButton;
				private System.Windows.Forms.ToolStrip DesignerTools;
				private System.Windows.Forms.ToolStripLabel PlanName;
				private System.Windows.Forms.Label PropertiesPanelLabel;
				private System.Windows.Forms.ToolStripButton NewContainer;
				private System.Windows.Forms.TextBox EditTitle;
				private System.Windows.Forms.Label TitleLabelProperties;
				private System.Windows.Forms.RichTextBox EditText;
				private System.Windows.Forms.Label TextLableProperties;
				private System.Windows.Forms.ToolStripButton DeleteContainer;
				private System.Windows.Forms.GroupBox RenderModeGroup;
				private System.Windows.Forms.RadioButton RenderModeLinear;
				private System.Windows.Forms.RadioButton RenderModeRelative;
		}
}
