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
				#region EVENTS

				/// <summary>
				/// Triggers when we remove a node
				/// </summary>
				public event Action OnRemove;

				/// <summary>
				/// Triggers when we add a new plan node
				/// </summary>
				public event Action OnAddPlan;

				/// <summary>
				/// Triggers when we add a new folder node
				/// </summary>
				public event Action OnAddFolder;

				#endregion

				public PlanTree() : base() {
						LabelEdit = true;
						DoubleClick += (Object sender, EventArgs e) =>
						{
								SelectedNode.BeginEdit();
						};
						// enable both left and right click for selecting nodes
						NodeMouseClick += (sender, e) => SelectedNode = e.Node;
						ContextMenuStrip = new PlanTreeContextMenu(this);
						BeforeExpand += OpenFolderIcon;
						BeforeCollapse += CloseFolderIcon;
				}

				/// <summary>
				/// Finds the parent of the currently selected node and will add a new node to the parent
				/// </summary>
				/// <param name="node">node to be added</param>
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

				/// <summary>
				/// Removes the selected node
				/// </summary>
				/// <returns>true if node was removed</returns>
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
										OnRemove?.Invoke();
										return true;
								}
						}
						return false;
				}

				#region ADD NODES

				/// <summary>
				/// Adds a node to the tree
				/// </summary>
				/// <param name="to">where to add the node</param>
				/// <param name="node">the node added</param>
				protected void AddNode(TreeNodeCollection to, CustomNode node)
				{
						to.Add(node);
						SelectedNode = node;
						SelectedNode.BeginEdit();
				}

				/// <summary>
				/// Adds a new plan node into this tree
				/// </summary>
				public void AddNewPlan()
				{
						PlanNode node = new PlanNode("Plan", new Plan());
						node.Plan.AddContainer();
						FindParentAndAdd(node);
						OnAddPlan?.Invoke();
				}

				/// <summary>
				/// Adds a new folder node to this tree
				/// </summary>
				public void AddNewFolder()
				{
						FindParentAndAdd(new FolderNode("Folder"));
						OnAddFolder?.Invoke();
				}

				#endregion

				#region CHANGE ICON

				/// <summary>
				/// Changes the folder icon to open
				/// </summary>
				public void OpenFolderIcon(Object sender, TreeViewCancelEventArgs e)
				{
						e.Node.ImageIndex = 1;
						e.Node.SelectedImageIndex = 1;
				}

				/// <summary>
				/// Changes the folder icon to closed
				/// </summary>
				public void CloseFolderIcon(Object sender, TreeViewCancelEventArgs e)
				{
						e.Node.ImageIndex = 0;
						e.Node.SelectedImageIndex = 0;
				}

				#endregion

				#region XML

				/// <summary>
				/// Loads the values of this plantree from xml
				/// </summary>
				/// <param name="xml">xelement</param>
				public void LoadFromXML(XElement xml)
				{
						if (xml.Name != "FileTree") throw new InvalidXMLException("element name does not equal: FileTree");

						if (xml.HasElements)
						{
								IEnumerable<XElement> elements = xml.Elements();
								foreach (XElement child in elements)
								{
										if (child.Name == "Folder")
										{
												FolderNode node = new FolderNode();
												node.LoadFromXML(child);
												Nodes.Add(node);
										}
										else if (child.Name == "Plan")
										{
												PlanNode node = new PlanNode();
												node.LoadFromXML(child);
												Nodes.Add(node);
										}
										else throw new InvalidXMLException("unknown element type: " + child.Name);
								}
						}
				}

				/// <summary>
				/// Transforms this plantree to xml
				/// </summary>
				/// <returns>xelement</returns>
				public XElement ToXML()
				{
						XElement fileTree = new XElement("FileTree");
						foreach (CustomNode node in Nodes)
						{
								fileTree.Add(node.ToXML());
						}
						return fileTree;
				}

				#endregion
		}
}
