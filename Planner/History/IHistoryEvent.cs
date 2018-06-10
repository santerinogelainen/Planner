using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.History
{
		public interface IHistoryEvent
		{



				void Undo();
				void Redo();

		}
}
