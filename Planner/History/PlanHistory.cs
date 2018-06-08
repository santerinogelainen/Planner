using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.History
{
		public class PlanHistory : IHasHistory
		{

				public int MaxSize { get; set; }
				public Plan Plan { get; set; }
				public DoubleSidedStack<HistoryEvent> PastEvents { get; set; }
				public DoubleSidedStack<HistoryEvent> FutureEvents { get; set; }

				public PlanHistory(Plan plan, int size = 50)
				{
						Plan = plan;
						MaxSize = size;
						PastEvents = new DoubleSidedStack<HistoryEvent>(MaxSize, true);
						FutureEvents = new DoubleSidedStack<HistoryEvent>(MaxSize, true);
				}

				public void RecordEvent(HistoryEvent @event)
				{
						// push the event to past events
						PastEvents.Push(@event);
				}

				public void Undo()
				{
						// move the event from the past events into the future events
						HistoryEvent @event = PastEvents.Pop();
						if (@event != null)
						{
								@event.Undo();
								FutureEvents.Push(@event);
						}
				}

				public void Redo()
				{
						// move the event from the future events into the past events
						HistoryEvent @event = FutureEvents.Pop();
						if (@event != null)
						{
								@event.Redo();
								PastEvents.Push(@event);
						}
				}

		}
}
