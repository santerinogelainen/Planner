using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
		public interface IContainer
		{
				
				IContainer ParentContainer { get; set; }
				List<IContainer> Children { get; set; }

				void AddChild(IContainer container);

				void RemoveChild(IContainer container);

		}
}
