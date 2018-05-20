using System;
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
		/// <summary>
		/// Works as a base for other containers. Note! you shouldn't use this on its own even though its not marked as abstract, create a subclass of this, override methods if necessary
		/// </summary>
		public class BaseContainer : Panel, IXMLTransformable
		{
				/// <summary>
				/// Triggers when we add a new child to this container
				/// </summary>
				public event Action<BaseContainer> OnAdd;

				/// <summary>
				/// Triggers when we remove a child from this container
				/// </summary>
				public event Action<BaseContainer> OnRemove;

				#region PROPERTIES / VARIABLES

				/// <summary>
				/// Parent container of this container, can be null
				/// </summary>
				public BaseContainer ParentContainer { get; set; }
				/// <summary>
				/// Children of this container
				/// </summary>
				public List<BaseContainer> Children { get; set; }

				#endregion

				#region CONSTRUCTOR(S)

				public BaseContainer()
				{
						Children = new List<BaseContainer>();
				}

				#endregion

				/// <summary>
				/// Finds the top-most container at the point specified
				/// </summary>
				/// <param name="pos">position in screen coordinates</param>
				/// <param name="ignore">a container that it will ignore even if it is the topmost and under the point</param>
				/// <returns>The container that is the top most and contains the point</returns>
				public virtual BaseContainer FindContainerAtPoint(Point pos, BaseContainer ignore = null)
				{
						BaseContainer mouse = this;
						// check if children contain the point
						foreach(BaseContainer child in Children)
						{
								// if the child contains the position and is not ignored
								if (child.ContainsPos(pos) && child != ignore)
								{
										// find the container in the child
										return child.FindContainerAtPoint(pos, ignore);
								}
						}
						return mouse;
				}

				/// <summary>
				/// Checks if this container contains a position
				/// </summary>
				/// <param name="pos">position in screen coordinates</param>
				/// <returns>true if this container contains the position</returns>
				public bool ContainsPos(Point pos)
				{
						return (Visible && ClientRectangle.Contains(PointToClient(pos)));
				}

				#region ADD / REMOVE / MOVE / REPLACE

				/// <summary>
				/// Adds a child to this container
				/// </summary>
				/// <param name="container">Container</param>
				public virtual void AddChild(BaseContainer container)
				{
						container.ParentContainer = this;
						Children.Add(container);
						Controls.Add(container);
						container.BringToFront();
						OnAdd?.Invoke(container);
				}

				/// <summary>
				/// Move this container to a new parent
				/// </summary>
				/// <param name="newParent">new parent</param>
				public void MoveTo(BaseContainer newParent)
				{
						if (ParentContainer != null)
						{
								ParentContainer.RemoveChild(this);
						}
						newParent.AddChild(this);
				}

				/// <summary>
				/// Removes a child from this container
				/// </summary>
				/// <param name="container">Container to remove</param>
				public virtual void RemoveChild(BaseContainer container)
				{
						container.ParentContainer = null;
						Children.Remove(container);
						Controls.Remove(container);
						OnRemove?.Invoke(container);
				}

				/// <summary>
				/// Replaces this container from the parent with a different container
				/// </summary>
				/// <param name="container">container that replaces this container</param>
				public void ReplaceWith(BaseContainer container)
				{
						if (ParentContainer != null)
						{
								ParentContainer.ReplaceChild(this, container);
						}
				}

				/// <summary>
				/// Replaces a child (if exists) from children with another child
				/// </summary>
				/// <param name="child">child to replace</param>
				/// <param name="newchild">new container that replaces the child</param>
				public void ReplaceChild(BaseContainer child, BaseContainer newchild)
				{
						if (Children.Contains(child))
						{
								int controlindex = Controls.GetChildIndex(child);
								int childindex = Children.IndexOf(child);
								Children[childindex] = newchild;
								newchild.ParentContainer = this;
								Controls.Add(newchild);
								Controls.SetChildIndex(newchild, controlindex);
								Controls.Remove(child);
								OnAdd?.Invoke(newchild);
						}
				}

				#endregion

				#region XML

				/// <summary>
				/// Loads the values for this from xml
				/// </summary>
				/// <param name="xml">xml element</param>
				public virtual void LoadFromXML(XElement xml)
				{
						if (xml.Name != GetType().Name) throw new InvalidXMLException("element name does not equal: " + GetType().Name, xml);
						if (xml.HasElements)
						{
								IEnumerable<XElement> elements = xml.Elements();
								foreach (XElement child in elements)
								{
										BaseContainer container = new BaseContainer();
										AddChild(container);
								}
						}
				}

				/// <summary>
				/// Transforms this to xml
				/// </summary>
				/// <returns>XElement</returns>
				public virtual XElement ToXML()
				{
						XElement thisContainer = new XElement(GetType().Name);
						foreach (BaseContainer child in Children)
						{
								thisContainer.Add(child.ToXML());
						}
						return thisContainer;
				}

				#endregion
		}
}
