using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.History
{
		public class HistoryEvent : IHasHistory
		{
				public bool IsInThePast { get; set; }

				public HistoryEvent()
				{
						IsInThePast = true;
				}

				public virtual void Redo()
				{
						IsInThePast = true;
				}

				public virtual void Undo()
				{
						IsInThePast = false;
				}
		}
}
