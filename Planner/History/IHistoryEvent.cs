using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.History
{
		public interface IHasHistory
		{

				void Undo();
				void Redo();

		}
}
