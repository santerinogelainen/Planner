using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.History
{
		public class ResizeContainerEvent : HistoryEvent
		{

				public Container ResizedContainer { get; private set; }
				public Size StartSize { get; private set; }
				public Size EndSize { get; private set; }

				public ResizeContainerEvent(Container resized)
				{
						ResizedContainer = resized;
				}

				public void SetStartValues(int width, int height)
				{
						StartSize = new Size(width, height);
				}

				public void SetEndValues(int width, int height)
				{
						EndSize = new Size(width, height);
				}

				public override void Redo()
				{
						ResizedContainer.Size = EndSize;
				}

				public override void Undo()
				{
						ResizedContainer.Size = StartSize;
				}

		}
}
