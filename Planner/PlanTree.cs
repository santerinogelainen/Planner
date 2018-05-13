using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Planner
{
		public class PlanTree : TreeView, IXMLTransformable
		{

				public void FindParentAndAdd(CustomNode node)
				{
						if (SelectedNode == null)
						{
								AddNode(Nodes, node);
								return;
						}

						if (SelectedNode is FolderNode)
						{
								SelectedNode.Expand();
								AddNode(SelectedNode.Nodes, node);
								return;
						}
						else
						{
								SelectedNode = SelectedNode.Parent;
								FindParentAndAdd(node);
						}
				}

				public bool RemoveSelectedNode()
				{
						if (SelectedNode != null)
						{
								DialogResult dialogResult;
								if (SelectedNode is FolderNode)
								{
										dialogResult = MessageBox.Show("Do you want to delete this folder and all its contents?", "Folder deletion", MessageBoxButtons.YesNo);
								}
								else
								{
										dialogResult = MessageBox.Show("Do you want to delete this plan?", "Plan deletion", MessageBoxButtons.YesNo);
								}

								if (dialogResult == DialogResult.Yes)
								{
										SelectedNode.Remove();
										return true;
								}
						}
						return false;
				}

				protected void AddNode(TreeNodeCollection to, CustomNode node)
				{
						to.Add(node);
						SelectedNode = node;
						SelectedNode.BeginEdit();
				}

				public XElement ToXML()
				{
						XElement fileTree = new XElement("FileTree");
						foreach (CustomNode node in Nodes)
						{
								fileTree.Add(node.ToXML());
						}
						return fileTree;
				}
		}
}
