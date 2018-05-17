using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Planner
{
		public class CustomNode : TreeNode, IXMLTransformable
		{
				public TreeNodeType NodeType { get; set; }

				public CustomNode(string name, TreeNodeType type) : base()
				{
						NodeType = type;
						Text = name;
						ImageIndex = GetImageIndexFromType(type);
						SelectedImageIndex = GetImageIndexFromType(type);
				}

				public int GetImageIndexFromType(TreeNodeType type)
				{
						switch(type)
						{
								case TreeNodeType.Folder:
										return 0;
								case TreeNodeType.Plan:
										return 2;
						}
						return 2;
				}

				public virtual void LoadFromXML(XElement xml)
				{
						// implement this in subclasses
				}

				public virtual XElement ToXML()
				{
						XElement node = new XElement("Node");
						node.Add(new XAttribute("type", NodeType));
						node.Add(new XAttribute("name", Text));
						foreach (CustomNode childNode in Nodes)
						{
								node.Add(childNode.ToXML());
						}
						return node;
				}
		}
}
