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
		public class PlaceHolder : BaseContainer
		{

				public PlaceHolder(Container replace)
				{
						BackColor = Color.Transparent;
						Size = replace.Size;
						Location = replace.Location;
						replace.ReplaceWith(this);
				}

		}
}
