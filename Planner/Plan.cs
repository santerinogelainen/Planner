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
		public class Plan : BaseContainer
		{


				public event Action<Container> OnSelectContainer;

				public Container SelectedContainer { get; private set; }
				//public PlaceHolder PlaceHolder { get; set; }

				public Plan() : base()
				{
						Dock = DockStyle.Fill;
				}

				public void DeleteSelectedContainer()
				{
						if (SelectedContainer != null)
						{
								SelectedContainer.ParentContainer.RemoveChild(SelectedContainer);
								SelectedContainer = null;
						}
				}

				public void MoveSelectedToBelow()
				{
						if (SelectedContainer != null)
						{
								BaseContainer newContainer = FindContainerAtPoint(SelectedContainer, MousePosition);
								Point selectedScreen = SelectedContainer.PointToScreen(Point.Empty);
								Point newScreen = newContainer.PointToScreen(Point.Empty);
								Point difference = new Point(selectedScreen.X - newScreen.X - 7, selectedScreen.Y - newScreen.Y - 7);
								SelectedContainer.Location = difference;
								SelectedContainer.MoveTo(newContainer);
						}
				}

				public void MoveSelectedToThis(BaseContainer oldContainer)
				{
						if (SelectedContainer != null)
						{
								SelectedContainer.MoveTo(this);
								SelectedContainer.Location = PointToClient(oldContainer.PointToScreen(SelectedContainer.Location));
						}
				}

				private void SelectContainer(Object sender)
				{
						if (SelectedContainer != null)
						{
								SelectedContainer.BackColor = Color.White;
						}
						SelectedContainer = (Container)sender;
						SelectedContainer.BackColor = Color.LightYellow;
						SelectedContainer.BringToFront();
						MoveSelectedToThis((BaseContainer)SelectedContainer.ParentContainer);
						OnSelectContainer?.Invoke(SelectedContainer);
				}

				/*private void PutPlaceHolder(Container replace)
				{
						PlaceHolder = new PlaceHolder();
						PlaceHolder.BackColor = Color.Red;
						PlaceHolder.ClientSize = replace.ClientSize;
						PlaceHolder.Location = replace.Location;
						BaseContainer parent = (BaseContainer)replace.ParentContainer;
						parent.AddChild(PlaceHolder);
						parent.Controls.SetChildIndex(PlaceHolder, parent.Controls.IndexOf(replace));
						PlaceHolder.ParentContainer = parent;
				}*/

				public override void LoadFromXML(XElement xml)
				{
						if (xml.Name != GetType().Name) throw new InvalidXMLException("element name does not equal: " + GetType().Name);

						if (xml.HasElements)
						{
								IEnumerable<XElement> elements = xml.Elements();
								foreach (XElement child in elements)
								{
										Container container = new Container();
										container.OnStartDragging += SelectContainer;
										container.OnStopDragging += MoveSelectedToBelow;
										container.LoadFromXML(child);
										AddChild(container);
								}
						}
				}

				public void AddContainer(string title = "")
				{
						Container container = new Container(title);
						container.Location = new Point(50, 50);
						container.OnStartDragging += SelectContainer;
						container.OnStopDragging += MoveSelectedToBelow;
						AddChild(container);
						SelectContainer(container);
				}

		}
}
