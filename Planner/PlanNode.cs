﻿using System;
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

				public PlanNode(string name, Plan plan) : base(name, TreeNodeType.Plan)
				{
						Plan = plan;
				}

				public override XElement ToXML()
				{
						XElement node = Plan.ToXML();
						node.Add(new XAttribute("name", Text));
						return node;
				}

		}
}
