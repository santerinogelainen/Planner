using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Planner
{
		public class InvalidXMLException : Exception
		{
				public InvalidXMLException(string message, XElement element = null) : base(GetXMLInfo(element) + " " + message){}

				/// <summary>
				/// Returns the line number and position of the xml element
				/// </summary>
				/// <param name="element">xml element</param>
				/// <returns>empty string if element is null or xdocument load options is not set to "LoadOptions.SetLineInfo"</returns>
				public static string GetXMLInfo(XElement element)
				{
						if (element == null) return "";
						IXmlLineInfo info = element;
						string XMLinfo = "";
						if (info != null) XMLinfo += String.Format("[line: {0}; pos: {1}]", info.LineNumber, info.LinePosition);
						return XMLinfo;
				}
		}
}
