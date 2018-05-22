using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
		public class InfiniteScrollPanel : Panel
		{

				public event Action OnScrollResize;

				public InfiniteScrollPanel()
				{
						VerticalScroll.Maximum = 100;
				}

				protected override void OnMouseWheel(MouseEventArgs e)
				{
						int max = VerticalScroll.Maximum - VerticalScroll.LargeChange - 1;
						if (VerticalScroll.Value + 100 >= max && e.Delta < 0)
						{
								Controls[0].Height -= e.Delta;
								OnScrollResize?.Invoke();
						}
						else
						{
								base.OnMouseWheel(e);
						}
				}

		}
}
