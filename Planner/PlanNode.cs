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

				public Plan Plan { get; set; }

				public PlanNode(string name = "", Plan plan = null) : base(name, TreeNodeType.Plan)
				{
						Plan = plan;
				}

				public override void LoadFromXML(XElement xml)
				{
						Plan = new Plan();
						Plan.LoadFromXML(xml);
						XAttribute name = xml.Attribute("name");

						if (name == null) throw new InvalidXMLException("plan dies not contain a name");

						Text = name.Value;
				}

				public override XElement ToXML()
				{
						XElement node = Plan.ToXML();
						node.Add(new XAttribute("name", Text));
						return node;
				}

		}
}
