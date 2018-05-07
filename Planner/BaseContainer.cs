using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
		public class BaseContainer : Panel, IContainer
		{
				public IContainer ParentContainer { get; set; }
				public List<IContainer> Children { get; set; }

				public BaseContainer()
				{
						Children = new List<IContainer>();
				}

				private void RenderChildren()
				{
						Controls.Clear();
						foreach(BaseContainer container in Children)
						{
								container.RenderChildren();
								Controls.Add(container);
						}
				}

				public void AddChild(IContainer container)
				{
						container.ParentContainer = this;
						Children.Add(container);
						RenderChildren();
				}

				public void RemoveChild(IContainer container)
				{
						container.ParentContainer = null;
						Children.Remove(container);
						RenderChildren();
				}
		}
}
