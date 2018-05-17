namespace Planner
{
		partial class StartWindow
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
						this.NewProjectButton = new System.Windows.Forms.Button();
						this.button1 = new System.Windows.Forms.Button();
						this.SuspendLayout();
						// 
						// NewProjectButton
						// 
						this.NewProjectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
						this.NewProjectButton.FlatAppearance.BorderSize = 0;
						this.NewProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.NewProjectButton.ForeColor = System.Drawing.Color.Black;
						this.NewProjectButton.Image = global::Planner.Properties.Resources.AddControl_16x;
						this.NewProjectButton.Location = new System.Drawing.Point(12, 12);
						this.NewProjectButton.Name = "NewProjectButton";
						this.NewProjectButton.Size = new System.Drawing.Size(183, 38);
						this.NewProjectButton.TabIndex = 0;
						this.NewProjectButton.Text = "NEW PROJECT";
						this.NewProjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
						this.NewProjectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
						this.NewProjectButton.UseVisualStyleBackColor = true;
						this.NewProjectButton.Click += new System.EventHandler(this.NewProject);
						// 
						// button1
						// 
						this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
						this.button1.FlatAppearance.BorderSize = 0;
						this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.button1.ForeColor = System.Drawing.Color.Black;
						this.button1.Image = global::Planner.Properties.Resources.Folder_16x;
						this.button1.Location = new System.Drawing.Point(201, 12);
						this.button1.Name = "button1";
						this.button1.Size = new System.Drawing.Size(183, 38);
						this.button1.TabIndex = 1;
						this.button1.Text = "OPEN PROJECT";
						this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
						this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
						this.button1.UseVisualStyleBackColor = true;
						this.button1.Click += new System.EventHandler(this.OpenProject);
						// 
						// StartWindow
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(401, 63);
						this.Controls.Add(this.button1);
						this.Controls.Add(this.NewProjectButton);
						this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
						this.MaximizeBox = false;
						this.MinimizeBox = false;
						this.Name = "StartWindow";
						this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
						this.Text = "Start";
						this.ResumeLayout(false);

				}

				#endregion

				private System.Windows.Forms.Button NewProjectButton;
				private System.Windows.Forms.Button button1;
		}
}