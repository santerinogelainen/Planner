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
				public FolderNode(string name = "") : base(name, TreeNodeType.Folder){}

				public override void LoadFromXML(XElement xml)
				{
						if (xml.Name != "Folder") throw new InvalidXMLException("element name does not equal: Folder");

						XAttribute name = xml.Attribute("name");
						if (name == null) throw new InvalidXMLException("folder does not contain a name");

						Text = name.Value;

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
