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
		public class BaseContainer : Panel, IContainer
		{
				public event Action BeforeRender;
				public event Action<BaseContainer> DuringRender;
				public event Action AfterRender;

				public IContainer ParentContainer { get; set; }
				public List<IContainer> Children { get; set; }

				public BaseContainer()
				{
						Children = new List<IContainer>();
				}

				public virtual BaseContainer FindContainerAtPoint(BaseContainer selected, Point pos)
				{
						BaseContainer mouse = this;
						foreach(BaseContainer container in Children)
						{
								bool isnotselected = container != selected;
								bool contains = container.ContainsPos(pos);
								if (container.ContainsPos(pos) && container != selected)
								{
										return container.FindContainerAtPoint(selected, pos);
								}
						}
						return mouse;
				}

				public bool ContainsPos(Point pos)
				{
						return (Visible && ClientRectangle.Contains(PointToClient(pos)));
				}

				protected void RenderChildren()
				{
						Controls.Clear();
						BeforeRender?.Invoke();
						foreach(BaseContainer container in Children)
						{
								container.RenderChildren();
								Controls.Add(container);
								container.BringToFront();
								DuringRender?.Invoke(container);
						}
						AfterRender?.Invoke();
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
