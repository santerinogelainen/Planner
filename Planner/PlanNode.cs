using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Planner
{
		public class PlanNode : CustomNode
		{
				/// <summary>
				/// The plan of this plannode
				/// </summary>
				public Plan Plan { get; set; }

				public PlanNode(string name = "", Plan plan = null) : base(name)
				{
						Plan = plan;
						ImageIndex = 2;
						SelectedImageIndex = 2;
				}

				#region XML

				/// <summary>
				/// Loads the values to this node from xml
				/// </summary>
				/// <param name="xml">xml elemnt</param>
				public override void LoadFromXML(XElement xml)
				{
						Plan = new Plan();
						Plan.LoadFromXML(xml);
						XAttribute name = xml.Attribute("name");

						if (name == null) throw new InvalidXMLException("plan dies not contain a name");

						Text = name.Value;
				}

				/// <summary>
				/// Transforms this node to xml
				/// </summary>
				/// <returns>xelement</returns>
				public override XElement ToXML()
				{
						XElement node = Plan.ToXML();
						node.Add(new XAttribute("name", Text));
						return node;
				}

				#endregion

		}
}
