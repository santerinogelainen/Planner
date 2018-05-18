using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Planner
{
		/// <summary>
		/// Represents an object that can be transformed to xml, or values loaded from xml
		/// </summary>
		interface IXMLTransformable
		{
				void LoadFromXML(XElement xml);
				XElement ToXML();
		}
}
