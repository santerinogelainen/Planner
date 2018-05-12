using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
		public partial class MainWindow : Form
		{

				public Plan OpenPlan { get; set; }

				public MainWindow()
				{
						InitializeComponent();
						FileTree.LabelEdit = true;
						FileTree.DoubleClick += (Object sender, EventArgs e) =>
						{
								FileTree.SelectedNode.BeginEdit();
						};
						FileTree.AfterLabelEdit += UpdateDesignerTitle;
				}

				public void DeleteSelectedContainer(Object sender, EventArgs e)
				{
						OpenPlan.DeleteSelectedContainer();
				}

				public void SelectPlan(Object sender, TreeViewEventArgs e)
				{
						CustomNode node = (CustomNode)e.Node;
						if (node.NodeType == TreeNodeType.Plan)
						{
								OpenPlan = ((PlanNode)node).Plan;
								PlanName.Text = node.Text;
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
						if (FileTree.SelectedNode != null)
						{
								DialogResult dialogResult;
								if (((CustomNode)FileTree.SelectedNode).NodeType == TreeNodeType.Folder)
								{
										dialogResult = MessageBox.Show("Do you want to delete this folder and all its contents?", "Folder deletion", MessageBoxButtons.YesNo);
								} else
								{
										dialogResult = MessageBox.Show("Do you want to delete this plan?", "Plan deletion", MessageBoxButtons.YesNo);
								}

								if (dialogResult == DialogResult.Yes)
								{
										FileTree.SelectedNode.Remove();
								}
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
								PlanName.Text = "";
								DesignerPanel.Controls.Clear();
						}
				}

				public void NewFolder(Object sender, EventArgs e)
				{
						FindParentAndAdd(TreeNodeType.Folder);
				}

				public void NewPlan(Object sender, EventArgs e)
				{
						FindParentAndAdd(TreeNodeType.Plan);
				}

				public void AddContainer(Object sender, EventArgs e)
				{
						if (DesignerPanel.Controls.OfType<Plan>().ToList()[0] != null)
						{
								DesignerPanel.Controls.OfType<Plan>().ToList()[0].AddContainer();
						}
				}

				public CustomNode GetNodeFromType(TreeNodeType type)
				{
						if (type == TreeNodeType.Plan)
						{
								PlanNode node = new PlanNode(type.ToString(), new Plan());
								node.Plan.OnSelectContainer += SetProperties;
								node.Plan.AddContainer();
								return node;
						}
						return new CustomNode(type.ToString(), type);
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

				public void FindParentAndAdd(TreeNodeType type)
				{
						if (FileTree.SelectedNode == null)
						{
								CustomNode node = GetNodeFromType(type);
								FileTree.Nodes.Add(node);
								FileTree.SelectedNode = node;
								FileTree.SelectedNode.BeginEdit();
								return;
						}

						if (((CustomNode)FileTree.SelectedNode).NodeType == TreeNodeType.Folder)
						{
								CustomNode node = GetNodeFromType(type);
								FileTree.SelectedNode.Nodes.Add(node);
								FileTree.SelectedNode.Expand();
								FileTree.SelectedNode = node;
								FileTree.SelectedNode.BeginEdit();
						}
						else
						{
								FileTree.SelectedNode = FileTree.SelectedNode.Parent;
								FindParentAndAdd(type);
						}
				}
		}
}
