namespace Planner
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
						this.DesignerPanel = new System.Windows.Forms.Panel();
						this.DesignerTools = new System.Windows.Forms.ToolStrip();
						this.PlanName = new System.Windows.Forms.ToolStripLabel();
						this.PropertiesPanel = new System.Windows.Forms.Panel();
						this.PropertiesWrapper = new System.Windows.Forms.Panel();
						this.EditText = new System.Windows.Forms.RichTextBox();
						this.TextLableProperties = new System.Windows.Forms.Label();
						this.RenderModeGroup = new System.Windows.Forms.GroupBox();
						this.RenderModeLinear = new System.Windows.Forms.RadioButton();
						this.RenderModeRelative = new System.Windows.Forms.RadioButton();
						this.EditTitle = new System.Windows.Forms.TextBox();
						this.TitleLabelProperties = new System.Windows.Forms.Label();
						this.PropertiesPanelLabel = new System.Windows.Forms.Label();
						this.ToolStrip = new System.Windows.Forms.ToolStrip();
						this.NewContainer = new System.Windows.Forms.ToolStripButton();
						this.DeleteContainer = new System.Windows.Forms.ToolStripButton();
						this.NewPlanButton = new System.Windows.Forms.ToolStripButton();
						this.NewFolderButton = new System.Windows.Forms.ToolStripButton();
						this.DeleteButton = new System.Windows.Forms.ToolStripButton();
						this.SmallSaveButton = new System.Windows.Forms.ToolStripButton();
						this.FileDropDown = new System.Windows.Forms.ToolStripDropDownButton();
						this.NewProjectButton = new System.Windows.Forms.ToolStripMenuItem();
						this.OpenProjectButton = new System.Windows.Forms.ToolStripMenuItem();
						this.ProjectSaveSeparator = new System.Windows.Forms.ToolStripSeparator();
						this.SaveButton = new System.Windows.Forms.ToolStripMenuItem();
						this.SaveAsButton = new System.Windows.Forms.ToolStripMenuItem();
						this.FilePanel.SuspendLayout();
						this.FileToolStrip.SuspendLayout();
						this.DesignerTools.SuspendLayout();
						this.PropertiesPanel.SuspendLayout();
						this.PropertiesWrapper.SuspendLayout();
						this.RenderModeGroup.SuspendLayout();
						this.ToolStrip.SuspendLayout();
						this.SuspendLayout();
						// 
						// FilePanel
						// 
						this.FilePanel.Controls.Add(this.FileTree);
						this.FilePanel.Controls.Add(this.FileToolStrip);
						this.FilePanel.Dock = System.Windows.Forms.DockStyle.Left;
						this.FilePanel.Location = new System.Drawing.Point(0, 25);
						this.FilePanel.Name = "FilePanel";
						this.FilePanel.Size = new System.Drawing.Size(222, 425);
						this.FilePanel.TabIndex = 0;
						// 
						// FileTree
						// 
						this.FileTree.Dock = System.Windows.Forms.DockStyle.Fill;
						this.FileTree.ImageIndex = 0;
						this.FileTree.ImageList = this.FileTreeImages;
						this.FileTree.Location = new System.Drawing.Point(0, 25);
						this.FileTree.Name = "FileTree";
						this.FileTree.SelectedImageIndex = 0;
						this.FileTree.Size = new System.Drawing.Size(222, 400);
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
						this.FileToolStrip.Size = new System.Drawing.Size(222, 25);
						this.FileToolStrip.TabIndex = 2;
						// 
						// DesignerPanel
						// 
						this.DesignerPanel.AutoScroll = true;
						this.DesignerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
						this.DesignerPanel.Location = new System.Drawing.Point(222, 25);
						this.DesignerPanel.Name = "DesignerPanel";
						this.DesignerPanel.Size = new System.Drawing.Size(349, 425);
						this.DesignerPanel.TabIndex = 1;
						// 
						// DesignerTools
						// 
						this.DesignerTools.ImageScalingSize = new System.Drawing.Size(20, 20);
						this.DesignerTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlanName,
            this.NewContainer,
            this.DeleteContainer});
						this.DesignerTools.Location = new System.Drawing.Point(222, 25);
						this.DesignerTools.Name = "DesignerTools";
						this.DesignerTools.Size = new System.Drawing.Size(349, 25);
						this.DesignerTools.TabIndex = 1;
						this.DesignerTools.Text = "toolStrip1";
						// 
						// PlanName
						// 
						this.PlanName.Name = "PlanName";
						this.PlanName.Size = new System.Drawing.Size(0, 22);
						// 
						// PropertiesPanel
						// 
						this.PropertiesPanel.Controls.Add(this.PropertiesWrapper);
						this.PropertiesPanel.Controls.Add(this.PropertiesPanelLabel);
						this.PropertiesPanel.Dock = System.Windows.Forms.DockStyle.Right;
						this.PropertiesPanel.Location = new System.Drawing.Point(571, 25);
						this.PropertiesPanel.Name = "PropertiesPanel";
						this.PropertiesPanel.Padding = new System.Windows.Forms.Padding(5);
						this.PropertiesPanel.Size = new System.Drawing.Size(229, 425);
						this.PropertiesPanel.TabIndex = 0;
						// 
						// PropertiesWrapper
						// 
						this.PropertiesWrapper.Controls.Add(this.EditText);
						this.PropertiesWrapper.Controls.Add(this.TextLableProperties);
						this.PropertiesWrapper.Controls.Add(this.RenderModeGroup);
						this.PropertiesWrapper.Controls.Add(this.EditTitle);
						this.PropertiesWrapper.Controls.Add(this.TitleLabelProperties);
						this.PropertiesWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
						this.PropertiesWrapper.Location = new System.Drawing.Point(5, 23);
						this.PropertiesWrapper.Name = "PropertiesWrapper";
						this.PropertiesWrapper.Size = new System.Drawing.Size(219, 397);
						this.PropertiesWrapper.TabIndex = 0;
						// 
						// EditText
						// 
						this.EditText.Dock = System.Windows.Forms.DockStyle.Fill;
						this.EditText.Location = new System.Drawing.Point(0, 105);
						this.EditText.Name = "EditText";
						this.EditText.Size = new System.Drawing.Size(219, 292);
						this.EditText.TabIndex = 4;
						this.EditText.Text = "";
						this.EditText.TextChanged += new System.EventHandler(this.UpdateText);
						// 
						// TextLableProperties
						// 
						this.TextLableProperties.AutoSize = true;
						this.TextLableProperties.Dock = System.Windows.Forms.DockStyle.Top;
						this.TextLableProperties.Location = new System.Drawing.Point(0, 82);
						this.TextLableProperties.Name = "TextLableProperties";
						this.TextLableProperties.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
						this.TextLableProperties.Size = new System.Drawing.Size(31, 23);
						this.TextLableProperties.TabIndex = 3;
						this.TextLableProperties.Text = "Text:";
						// 
						// RenderModeGroup
						// 
						this.RenderModeGroup.Controls.Add(this.RenderModeLinear);
						this.RenderModeGroup.Controls.Add(this.RenderModeRelative);
						this.RenderModeGroup.Dock = System.Windows.Forms.DockStyle.Top;
						this.RenderModeGroup.Location = new System.Drawing.Point(0, 43);
						this.RenderModeGroup.Margin = new System.Windows.Forms.Padding(2);
						this.RenderModeGroup.Name = "RenderModeGroup";
						this.RenderModeGroup.Padding = new System.Windows.Forms.Padding(4);
						this.RenderModeGroup.Size = new System.Drawing.Size(219, 39);
						this.RenderModeGroup.TabIndex = 6;
						this.RenderModeGroup.TabStop = false;
						this.RenderModeGroup.Text = "Render Mode";
						// 
						// RenderModeLinear
						// 
						this.RenderModeLinear.AutoSize = true;
						this.RenderModeLinear.Location = new System.Drawing.Point(70, 19);
						this.RenderModeLinear.Margin = new System.Windows.Forms.Padding(2);
						this.RenderModeLinear.Name = "RenderModeLinear";
						this.RenderModeLinear.Size = new System.Drawing.Size(54, 17);
						this.RenderModeLinear.TabIndex = 1;
						this.RenderModeLinear.TabStop = true;
						this.RenderModeLinear.Text = "Linear";
						this.RenderModeLinear.UseVisualStyleBackColor = true;
						this.RenderModeLinear.CheckedChanged += new System.EventHandler(this.RenderModeToLinear);
						// 
						// RenderModeRelative
						// 
						this.RenderModeRelative.AutoSize = true;
						this.RenderModeRelative.Location = new System.Drawing.Point(6, 19);
						this.RenderModeRelative.Margin = new System.Windows.Forms.Padding(2);
						this.RenderModeRelative.Name = "RenderModeRelative";
						this.RenderModeRelative.Size = new System.Drawing.Size(64, 17);
						this.RenderModeRelative.TabIndex = 0;
						this.RenderModeRelative.TabStop = true;
						this.RenderModeRelative.Text = "Relative";
						this.RenderModeRelative.UseVisualStyleBackColor = true;
						this.RenderModeRelative.CheckedChanged += new System.EventHandler(this.RenderModeToRelative);
						// 
						// EditTitle
						// 
						this.EditTitle.Dock = System.Windows.Forms.DockStyle.Top;
						this.EditTitle.Location = new System.Drawing.Point(0, 23);
						this.EditTitle.Name = "EditTitle";
						this.EditTitle.Size = new System.Drawing.Size(219, 20);
						this.EditTitle.TabIndex = 1;
						this.EditTitle.TextChanged += new System.EventHandler(this.UpdateTitle);
						// 
						// TitleLabelProperties
						// 
						this.TitleLabelProperties.AutoSize = true;
						this.TitleLabelProperties.Dock = System.Windows.Forms.DockStyle.Top;
						this.TitleLabelProperties.Location = new System.Drawing.Point(0, 0);
						this.TitleLabelProperties.Name = "TitleLabelProperties";
						this.TitleLabelProperties.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
						this.TitleLabelProperties.Size = new System.Drawing.Size(30, 23);
						this.TitleLabelProperties.TabIndex = 2;
						this.TitleLabelProperties.Text = "Title:";
						// 
						// PropertiesPanelLabel
						// 
						this.PropertiesPanelLabel.AutoSize = true;
						this.PropertiesPanelLabel.Dock = System.Windows.Forms.DockStyle.Top;
						this.PropertiesPanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.PropertiesPanelLabel.Location = new System.Drawing.Point(5, 5);
						this.PropertiesPanelLabel.Name = "PropertiesPanelLabel";
						this.PropertiesPanelLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
						this.PropertiesPanelLabel.Size = new System.Drawing.Size(64, 18);
						this.PropertiesPanelLabel.TabIndex = 0;
						this.PropertiesPanelLabel.Text = "Properties";
						// 
						// ToolStrip
						// 
						this.ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
						this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SmallSaveButton,
            this.FileDropDown});
						this.ToolStrip.Location = new System.Drawing.Point(0, 0);
						this.ToolStrip.Name = "ToolStrip";
						this.ToolStrip.Size = new System.Drawing.Size(800, 25);
						this.ToolStrip.TabIndex = 1;
						// 
						// NewContainer
						// 
						this.NewContainer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
						this.NewContainer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.NewContainer.Image = global::Planner.Properties.Resources.AddControl_16x;
						this.NewContainer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.NewContainer.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.NewContainer.Name = "NewContainer";
						this.NewContainer.Size = new System.Drawing.Size(23, 22);
						this.NewContainer.ToolTipText = "New Container";
						this.NewContainer.Click += new System.EventHandler(this.AddContainer);
						// 
						// DeleteContainer
						// 
						this.DeleteContainer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
						this.DeleteContainer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.DeleteContainer.Image = global::Planner.Properties.Resources.Cancel_16x;
						this.DeleteContainer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.DeleteContainer.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.DeleteContainer.Name = "DeleteContainer";
						this.DeleteContainer.Size = new System.Drawing.Size(23, 22);
						this.DeleteContainer.Click += new System.EventHandler(this.DeleteSelectedContainer);
						// 
						// NewPlanButton
						// 
						this.NewPlanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.NewPlanButton.Image = global::Planner.Properties.Resources.AddFile_16x;
						this.NewPlanButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.NewPlanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.NewPlanButton.Name = "NewPlanButton";
						this.NewPlanButton.Size = new System.Drawing.Size(23, 22);
						this.NewPlanButton.ToolTipText = "New Plan";
						this.NewPlanButton.Click += new System.EventHandler(this.NewPlan);
						// 
						// NewFolderButton
						// 
						this.NewFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.NewFolderButton.Image = global::Planner.Properties.Resources.AddFolder_16x;
						this.NewFolderButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.NewFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.NewFolderButton.Name = "NewFolderButton";
						this.NewFolderButton.Size = new System.Drawing.Size(23, 22);
						this.NewFolderButton.ToolTipText = "New Folder";
						this.NewFolderButton.Click += new System.EventHandler(this.NewFolder);
						// 
						// DeleteButton
						// 
						this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.DeleteButton.Image = global::Planner.Properties.Resources.Cancel_16x;
						this.DeleteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.DeleteButton.Name = "DeleteButton";
						this.DeleteButton.Size = new System.Drawing.Size(23, 22);
						this.DeleteButton.ToolTipText = "Remove Folder/Plan";
						this.DeleteButton.Click += new System.EventHandler(this.RemoveNode);
						// 
						// SmallSaveButton
						// 
						this.SmallSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
						this.SmallSaveButton.Image = global::Planner.Properties.Resources.Save_16x;
						this.SmallSaveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.SmallSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.SmallSaveButton.Name = "SmallSaveButton";
						this.SmallSaveButton.Size = new System.Drawing.Size(23, 22);
						this.SmallSaveButton.ToolTipText = "Save (Ctrl + S)";
						// 
						// FileDropDown
						// 
						this.FileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
						this.FileDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewProjectButton,
            this.OpenProjectButton,
            this.ProjectSaveSeparator,
            this.SaveButton,
            this.SaveAsButton});
						this.FileDropDown.Image = ((System.Drawing.Image)(resources.GetObject("FileDropDown.Image")));
						this.FileDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
						this.FileDropDown.Name = "FileDropDown";
						this.FileDropDown.Size = new System.Drawing.Size(38, 22);
						this.FileDropDown.Text = "File";
						// 
						// NewProjectButton
						// 
						this.NewProjectButton.Name = "NewProjectButton";
						this.NewProjectButton.Size = new System.Drawing.Size(180, 22);
						this.NewProjectButton.Text = "New Project";
						// 
						// OpenProjectButton
						// 
						this.OpenProjectButton.Name = "OpenProjectButton";
						this.OpenProjectButton.Size = new System.Drawing.Size(180, 22);
						this.OpenProjectButton.Text = "Open Project";
						// 
						// ProjectSaveSeparator
						// 
						this.ProjectSaveSeparator.Name = "ProjectSaveSeparator";
						this.ProjectSaveSeparator.Size = new System.Drawing.Size(177, 6);
						// 
						// SaveButton
						// 
						this.SaveButton.Image = global::Planner.Properties.Resources.Save_16x;
						this.SaveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.SaveButton.Name = "SaveButton";
						this.SaveButton.ShortcutKeyDisplayString = "Ctrl + S";
						this.SaveButton.Size = new System.Drawing.Size(180, 22);
						this.SaveButton.Text = "Save";
						// 
						// SaveAsButton
						// 
						this.SaveAsButton.Image = global::Planner.Properties.Resources.SaveAs_16x;
						this.SaveAsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
						this.SaveAsButton.Name = "SaveAsButton";
						this.SaveAsButton.Size = new System.Drawing.Size(180, 22);
						this.SaveAsButton.Text = "Save As";
						// 
						// MainWindow
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(800, 450);
						this.Controls.Add(this.DesignerTools);
						this.Controls.Add(this.DesignerPanel);
						this.Controls.Add(this.PropertiesPanel);
						this.Controls.Add(this.FilePanel);
						this.Controls.Add(this.ToolStrip);
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
						this.PropertiesWrapper.ResumeLayout(false);
						this.PropertiesWrapper.PerformLayout();
						this.RenderModeGroup.ResumeLayout(false);
						this.RenderModeGroup.PerformLayout();
						this.ToolStrip.ResumeLayout(false);
						this.ToolStrip.PerformLayout();
						this.ResumeLayout(false);
						this.PerformLayout();

				}

				#endregion

				private System.Windows.Forms.Panel FilePanel;
				private System.Windows.Forms.Panel DesignerPanel;
				private System.Windows.Forms.TreeView FileTree;
				private System.Windows.Forms.Panel PropertiesPanel;
				private System.Windows.Forms.ToolStrip ToolStrip;
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
				private System.Windows.Forms.Panel PropertiesWrapper;
				private System.Windows.Forms.ToolStripButton SmallSaveButton;
				private System.Windows.Forms.ToolStripDropDownButton FileDropDown;
				private System.Windows.Forms.ToolStripMenuItem NewProjectButton;
				private System.Windows.Forms.ToolStripMenuItem OpenProjectButton;
				private System.Windows.Forms.ToolStripSeparator ProjectSaveSeparator;
				private System.Windows.Forms.ToolStripMenuItem SaveButton;
				private System.Windows.Forms.ToolStripMenuItem SaveAsButton;
		}
}

