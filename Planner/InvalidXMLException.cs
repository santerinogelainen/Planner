using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
		public class InvalidXMLException : Exception
		{

				public InvalidXMLException(string message) : base(message) { }
		}
}
