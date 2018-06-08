using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.History
{
		public class MoveContainerEvent : HistoryEvent
		{

				public override void Redo()
				{
						base.Redo();
				}

				public override void Undo()
				{
						base.Undo();
				}
		}
}
