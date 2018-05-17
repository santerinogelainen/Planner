﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Planner
{
		public class BaseContainer : Panel, IContainer, IXMLTransformable
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

				public virtual void LoadFromXML(XElement xml)
				{
						if (xml.HasElements)
						{
								if (xml.Name != GetType().Name)
								{
										throw new InvalidXMLException("element name does not equal: " + GetType().Name);
								}

								IEnumerable<XElement> elements = xml.Elements();
								foreach (XElement child in elements)
								{
										BaseContainer container = new BaseContainer();
										AddChild(container);
								}
						}
				}

				public virtual XElement ToXML()
				{
						XElement thisContainer = new XElement(GetType().Name);
						foreach (BaseContainer child in Children)
						{
								thisContainer.Add(child.ToXML());
						}
						return thisContainer;
				}
		}
}
