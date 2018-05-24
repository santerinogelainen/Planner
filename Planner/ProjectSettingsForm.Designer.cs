namespace Planner
{
		partial class ProjectSettingsForm
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
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectSettingsForm));
						this.ProjectNameLabel = new System.Windows.Forms.Label();
						this.ProjectName = new System.Windows.Forms.TextBox();
						this.ProjectLocationLabel = new System.Windows.Forms.Label();
						this.ChooseProjectLocation = new System.Windows.Forms.Button();
						this.BrowseToolTip = new System.Windows.Forms.ToolTip(this.components);
						this.ProjectLocation = new System.Windows.Forms.TextBox();
						this.OkButton = new System.Windows.Forms.Button();
						this.CancelButton = new System.Windows.Forms.Button();
						this.ErrorMsg = new System.Windows.Forms.Label();
						this.SuspendLayout();
						// 
						// ProjectNameLabel
						// 
						this.ProjectNameLabel.AutoSize = true;
						this.ProjectNameLabel.Location = new System.Drawing.Point(13, 13);
						this.ProjectNameLabel.Name = "ProjectNameLabel";
						this.ProjectNameLabel.Size = new System.Drawing.Size(72, 13);
						this.ProjectNameLabel.TabIndex = 0;
						this.ProjectNameLabel.Text = "Project name:";
						// 
						// ProjectName
						// 
						this.ProjectName.Location = new System.Drawing.Point(16, 30);
						this.ProjectName.Name = "ProjectName";
						this.ProjectName.Size = new System.Drawing.Size(423, 20);
						this.ProjectName.TabIndex = 1;
						this.ProjectName.Text = "Untitled Project";
						this.ProjectName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreventIllegalCharacters);
						// 
						// ProjectLocationLabel
						// 
						this.ProjectLocationLabel.AutoSize = true;
						this.ProjectLocationLabel.Location = new System.Drawing.Point(12, 53);
						this.ProjectLocationLabel.Name = "ProjectLocationLabel";
						this.ProjectLocationLabel.Size = new System.Drawing.Size(109, 13);
						this.ProjectLocationLabel.TabIndex = 2;
						this.ProjectLocationLabel.Text = "Project save location:";
						// 
						// ChooseProjectLocation
						// 
						this.ChooseProjectLocation.Image = global::Planner.Properties.Resources.Folder_16x;
						this.ChooseProjectLocation.Location = new System.Drawing.Point(16, 69);
						this.ChooseProjectLocation.Name = "ChooseProjectLocation";
						this.ChooseProjectLocation.Size = new System.Drawing.Size(23, 23);
						this.ChooseProjectLocation.TabIndex = 4;
						this.BrowseToolTip.SetToolTip(this.ChooseProjectLocation, "Browse");
						this.ChooseProjectLocation.UseVisualStyleBackColor = true;
						this.ChooseProjectLocation.Click += new System.EventHandler(this.OpenFolderDialog);
						// 
						// ProjectLocation
						// 
						this.ProjectLocation.Location = new System.Drawing.Point(45, 71);
						this.ProjectLocation.Name = "ProjectLocation";
						this.ProjectLocation.Size = new System.Drawing.Size(393, 20);
						this.ProjectLocation.TabIndex = 5;
						// 
						// OkButton
						// 
						this.OkButton.Location = new System.Drawing.Point(364, 97);
						this.OkButton.Name = "OkButton";
						this.OkButton.Size = new System.Drawing.Size(75, 23);
						this.OkButton.TabIndex = 6;
						this.OkButton.Text = "Ok";
						this.OkButton.UseVisualStyleBackColor = true;
						this.OkButton.Click += new System.EventHandler(this.Ok);
						// 
						// CancelButton
						// 
						this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
						this.CancelButton.Location = new System.Drawing.Point(283, 97);
						this.CancelButton.Name = "CancelButton";
						this.CancelButton.Size = new System.Drawing.Size(75, 23);
						this.CancelButton.TabIndex = 7;
						this.CancelButton.Text = "Cancel";
						this.CancelButton.UseVisualStyleBackColor = true;
						this.CancelButton.Click += new System.EventHandler(this.CloseForm);
						// 
						// ErrorMsg
						// 
						this.ErrorMsg.ForeColor = System.Drawing.Color.Red;
						this.ErrorMsg.Location = new System.Drawing.Point(13, 97);
						this.ErrorMsg.MaximumSize = new System.Drawing.Size(264, 25);
						this.ErrorMsg.Name = "ErrorMsg";
						this.ErrorMsg.Size = new System.Drawing.Size(264, 25);
						this.ErrorMsg.TabIndex = 8;
						this.ErrorMsg.Visible = false;
						// 
						// ProjectSettingsForm
						// 
						this.AcceptButton = this.OkButton;
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(451, 131);
						this.Controls.Add(this.ErrorMsg);
						this.Controls.Add(this.CancelButton);
						this.Controls.Add(this.OkButton);
						this.Controls.Add(this.ProjectLocation);
						this.Controls.Add(this.ChooseProjectLocation);
						this.Controls.Add(this.ProjectLocationLabel);
						this.Controls.Add(this.ProjectName);
						this.Controls.Add(this.ProjectNameLabel);
						this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
						this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
						this.MaximizeBox = false;
						this.MinimizeBox = false;
						this.Name = "ProjectSettingsForm";
						this.Text = "Project Settings";
						this.TopMost = true;
						this.ResumeLayout(false);
						this.PerformLayout();

				}

				#endregion

				private System.Windows.Forms.Label ProjectNameLabel;
				private System.Windows.Forms.TextBox ProjectName;
				private System.Windows.Forms.Label ProjectLocationLabel;
				private System.Windows.Forms.Button ChooseProjectLocation;
				private System.Windows.Forms.ToolTip BrowseToolTip;
				private System.Windows.Forms.TextBox ProjectLocation;
				private System.Windows.Forms.Button OkButton;
				private System.Windows.Forms.Button CancelButton;
				private System.Windows.Forms.Label ErrorMsg;
		}
}