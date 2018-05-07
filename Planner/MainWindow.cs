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
				public MainWindow()
				{
						InitializeComponent();
				}

				public void LoadPlan(Object sender, TreeViewEventArgs e)
				{
						CustomNode node = (CustomNode)e.Node;
						if (node.NodeType == TreeNodeType.Plan)
						{
								PlanName.Text = node.Text;
								DesignerPanel.Controls.Clear();
								DesignerPanel.Controls.Add(((PlanNode)node).Plan);
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

				public void NewFolder(Object sender, EventArgs e)
				{
						FindParentAndAdd(TreeNodeType.Folder);
				}

				public void NewPlan(Object sender, EventArgs e)
				{
						FindParentAndAdd(TreeNodeType.Plan);
				}

				public CustomNode GetNodeFromType(TreeNodeType type)
				{
						if (type == TreeNodeType.Plan)
						{
								PlanNode node = new PlanNode(type.ToString(), new Plan());
								node.Plan.AddChild(new Container(type.ToString()));
								return node;
						}
						return new CustomNode(type.ToString(), type);
				}

				public void FindParentAndAdd(TreeNodeType type)
				{
						if (FileTree.SelectedNode == null)
						{
								FileTree.Nodes.Add(GetNodeFromType(type));
								return;
						}

						if (((CustomNode)FileTree.SelectedNode).NodeType == TreeNodeType.Folder)
						{
								FileTree.Nodes.Add(GetNodeFromType(type));
								FileTree.SelectedNode.Expand();
						}
						else
						{
								FileTree.SelectedNode = FileTree.SelectedNode.Parent;
								FindParentAndAdd(type);
						}
				}
		}
}
