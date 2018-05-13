using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Planner
{
		public partial class MainWindow : Form
		{
				public string projectName;

				public string ProjectName {
						get {
								return projectName;
						}
						set {
								projectName = value;
								Text = value;
						}
				}
				public string ProjectPath { get; set; }
				public bool ProjectIsOpen { get; set; }
				public Plan OpenPlan { get; set; }

				public MainWindow()
				{
						InitializeComponent();
						ProjectIsOpen = false;
						FileTree.LabelEdit = true;
						FileTree.DoubleClick += (Object sender, EventArgs e) =>
						{
								FileTree.SelectedNode.BeginEdit();
						};
						FileTree.AfterLabelEdit += UpdateDesignerTitle;
						DisableProperties();
				}

				public MainWindow(string name, string path) : this()
				{
						ProjectName = name;
						ProjectPath = path;
						ProjectIsOpen = true;
				}

				public void DeleteSelectedContainer(Object sender, EventArgs e)
				{
						if (OpenPlan != null)
						{
								OpenPlan.DeleteSelectedContainer();
								DisableProperties();
						}
				}

				public void NewProject(Object sender, EventArgs e)
				{
						NewProjectForm projectSettings = new NewProjectForm();
						projectSettings.StartPosition = FormStartPosition.CenterParent;
						projectSettings.OnOk += (string name, string path) =>
						{
								if (ProjectIsOpen)
								{
								}
								else
								{
										ProjectName = name;
										ProjectPath = path;
										ProjectIsOpen = true;
								}
						};
						projectSettings.ShowDialog(this);
				}

				public void SelectPlan(Object sender, TreeViewEventArgs e)
				{
						if (e.Node is PlanNode)
						{
								OpenPlan = ((PlanNode)e.Node).Plan;
								if (OpenPlan.SelectedContainer != null)
								{
										SetProperties(OpenPlan.SelectedContainer);
								}
								PlanName.Text = e.Node.Text;
								DesignerPanel.Controls.Clear();
								DesignerPanel.Controls.Add(OpenPlan);
						}
				}

				public void UpdateTitle(Object sender, EventArgs e)
				{
						if (OpenPlan != null)
						{
								if (OpenPlan.SelectedContainer != null)
								{
										OpenPlan.SelectedContainer.SetTitle(((Control)sender).Text);
								}
						}
				}

				public void UpdateText(Object sender, EventArgs e)
				{
						if (OpenPlan != null)
						{
								if (OpenPlan.SelectedContainer != null)
								{
										OpenPlan.SelectedContainer.SetText(((RichTextBox)sender).Text);
								}
						}
				}

				public void SetProperties(Container selected)
				{
						EnableProperties();
						EditTitle.Text = selected.Title;
						EditText.Text = selected.ContainerText;
						switch (selected.RenderMode)
						{
								case ContainerRenderMode.Relative:
										RenderModeRelative.Checked = true;
										RenderModeLinear.Checked = false;
										break;
								case ContainerRenderMode.Linear:
										RenderModeRelative.Checked = false;
										RenderModeLinear.Checked = true;
										break;
						}
				}

				public void DisableProperties()
				{
						PropertiesWrapper.Visible = false;
				}

				public void EnableProperties()
				{
						PropertiesWrapper.Visible = true;
				}

				public void OpenFolderIcon(Object sender, TreeViewCancelEventArgs e)
				{
						e.Node.ImageIndex = 1;
						e.Node.SelectedImageIndex = 1;
				}

				public void CloseFolderIcon(Object sender, TreeViewCancelEventArgs e)
				{
						e.Node.ImageIndex = 0;
						e.Node.SelectedImageIndex = 0;
				}

				public void RemoveNode(Object sender, EventArgs e)
				{
						bool removed = FileTree.RemoveSelectedNode();
						if (removed)
						{
								CloseOpenPlan();
						}
				}

				public void UpdateDesignerTitle(Object sender, NodeLabelEditEventArgs e)
				{
						if (e.Node is PlanNode)
						{
								if (((PlanNode)e.Node).Plan == OpenPlan)
								{
										if (e.Label == null)
										{
												PlanName.Text = e.Node.Text;
										} else
										{
												PlanName.Text = e.Label;
										}
								}
						}
				}

				public void CloseOpenPlan()
				{
						if (OpenPlan != null)
						{
								OpenPlan = null;
								PlanName.Text = "";
								DesignerPanel.Controls.Clear();
								DisableProperties();
						}
				}

				public void NewFolder(Object sender, EventArgs e)
				{
						FileTree.FindParentAndAdd(new FolderNode("Folder"));
				}

				public void NewPlan(Object sender, EventArgs e)
				{
						PlanNode node = new PlanNode("Plan", new Plan());
						node.Plan.OnSelectContainer += SetProperties;
						node.Plan.AddContainer();
						FileTree.FindParentAndAdd(node);
						Debug.WriteLine(FileTree.ToXML());
				}

				public void AddContainer(Object sender, EventArgs e)
				{
						if (OpenPlan != null)
						{
								OpenPlan.AddContainer();
						}
				}

				private void ChangeSelectedRenderMode(RadioButton sender, ContainerRenderMode mode)
				{
						if (OpenPlan != null)
						{
								if (OpenPlan.SelectedContainer != null)
								{
										if (sender.Checked)
										{
												OpenPlan.SelectedContainer.ChangeRenderMode(mode);
										}
								}
						}
				}

				public void RenderModeToRelative(Object sender, EventArgs e)
				{
						ChangeSelectedRenderMode((RadioButton)sender, ContainerRenderMode.Relative);
				}

				public void RenderModeToLinear(Object sender, EventArgs e)
				{
						ChangeSelectedRenderMode((RadioButton)sender, ContainerRenderMode.Linear);
				}
		}
}
