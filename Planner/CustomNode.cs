using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Planner
{
		public abstract class CustomNode : TreeNode, IXMLTransformable
		{
				public CustomNode(string name) : base()
				{
						Text = name;
				}

				#region XML

				/// <summary>
				/// Loads the node values from xml. Implement this in subclasses.
				/// </summary>
				/// <param name="xml">xml element</param>
				public abstract void LoadFromXML(XElement xml);

				/// <summary>
				/// Transforms this node into xml
				/// </summary>
				/// <returns>xml element</returns>
				public abstract XElement ToXML();

				#endregion
		}
}
