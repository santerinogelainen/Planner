using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.History
{
		public class MoveContainerEvent : HistoryEvent
		{

				public Container MovedContainer { get; private set; }

				public Point StartLocation { get; private set; }
				public Point EndLocation { get; private set; }
				public BaseContainer EndParentContainer { get; private set; }
				public BaseContainer StartParentContainer { get; private set; }
				public int StartParentContainerIndex { get; private set; }
				public int EndParentContainerIndex { get; private set; }

				public MoveContainerEvent(Container container) : base()
				{
						MovedContainer = container;
				}

				public void SetStartValues(int x, int y, BaseContainer parent, int parentindex)
				{
						StartParentContainer = parent;
						StartLocation = new Point(x, y);
				}

				public void SetEndValues(int x, int y, BaseContainer parent, int parentindex)
				{
						EndParentContainer = parent;
						EndLocation = new Point(x, y);
				}

				public override void Redo()
				{
						MovedContainer.MoveTo(EndParentContainer, EndParentContainerIndex);
						MovedContainer.Location = EndLocation;
				}

				public override void Undo()
				{
						MovedContainer.MoveTo(StartParentContainer, StartParentContainerIndex);
						MovedContainer.Location = StartLocation;
				}
		}
}
