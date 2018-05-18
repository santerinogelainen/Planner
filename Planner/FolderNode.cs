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
				public FolderNode(string name = "") : base(name)
				{
						// set the image to be a folder
						ImageIndex = 0;
						SelectedImageIndex = 0;
				}

				#region XML

				/// <summary>
				/// Loads the foldernode values from xml
				/// </summary>
				/// <param name="xml">xml element</param>
				public override void LoadFromXML(XElement xml)
				{
						if (xml.Name != "Folder") throw new InvalidXMLException("element name does not equal: Folder", xml);

						// check that the xml tag has a name attribute and set the name of this node
						XAttribute name = xml.Attribute("name");
						if (name == null) throw new InvalidXMLException("folder does not contain a name", xml);
						Text = name.Value;
						
						// loop through children
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
								else throw new InvalidXMLException("unknown element type: " + child.Name, child);
						}
				}

				/// <summary>
				/// Transforms this foldernode to xml
				/// </summary>
				/// <returns>xml element</returns>
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

				#endregion

		}
}
