using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Planner
{
		public class FolderNode : CustomNode
		{
				public FolderNode(string name) : base(name, TreeNodeType.Folder){}

				public override XElement ToXML()
				{
						XElement node = new XElement("Folder");
						foreach (CustomNode childNodes in Nodes)
						{
								node.Add(childNodes.ToXML());
						}
						node.Add(new XAttribute("name", Text));
						return node;
				}

		}
}
