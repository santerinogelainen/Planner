using Planner.History;
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

				/// <summary>
				/// Triggers when a container is selected
				/// </summary>
				public event Action<Container> OnSelectContainer;

				/// <summary>
				/// Current selected container
				/// </summary>
				public Container SelectedContainer { get; private set; }

				/// <summary>
				/// A placeholder for a container, can be null
				/// </summary>
				public PlaceHolder PlaceHolder { get; set; }

				/// <summary>
				/// the event history for this plan
				/// </summary>
				public PlanHistory History { get; private set; }

				public Plan() : base()
				{
						History = new PlanHistory(this, 100);
				}

				/// <summary>
				/// Deletes the selected container
				/// </summary>
				public void DeleteSelectedContainer()
				{
						if (SelectedContainer != null)
						{
								SelectedContainer.ParentContainer.RemoveChild(SelectedContainer);
								SelectedContainer = null;
						}
				}

				/// <summary>
				/// Moves the selected container to the container that is below the mouse (ignoreing the selected container)
				/// </summary>
				public void MoveSelectedToBelow()
				{
						if (SelectedContainer != null)
						{

								// get the new container of the selected container
								BaseContainer newContainer = FindContainerAtPoint(MousePosition, SelectedContainer);

								if (newContainer is PlaceHolder) {
										newContainer = newContainer.ParentContainer;
										if (newContainer is Container)
										{
												Container container = (Container)newContainer;
												if (container.RenderMode == ContainerRenderMode.Linear)
												{
														// discard the last moveevent that was recorded by the container
														History.DiscardLastEvent();
														RemoveChild(SelectedContainer);
														PlaceHolder.ReplaceWith(SelectedContainer);
														SelectedContainer.Location = PlaceHolder.Location;
														RemovePlaceHolder();
														return;
												}
										}
								}

								// update the location of the selected
								Point selectedScreen = SelectedContainer.PointToScreen(Point.Empty);
								Point difference = newContainer.PointToClient(selectedScreen);
								SelectedContainer.Location = difference;

								// move to new
								SelectedContainer.MoveTo(newContainer);
								RemovePlaceHolder();
						}
				}

				/// <summary>
				/// Moves the selected container to this plan
				/// </summary>
				public void MoveSelectedToThis()
				{
						if (SelectedContainer != null)
						{
								if (SelectedContainer.ParentContainer is Container && ((Container)SelectedContainer.ParentContainer).RenderMode == ContainerRenderMode.Linear) {
										PutPlaceHolder(SelectedContainer);
										SelectedContainer.Location = PointToClient(PlaceHolder.ParentContainer.PointToScreen(SelectedContainer.Location));
										SelectedContainer.ClientSize = PlaceHolder.ClientSize;
										SelectedContainer.Size = SelectedContainer.ClientSize;
								} else
								{
										SelectedContainer.Location = PointToClient(SelectedContainer.ParentContainer.PointToScreen(SelectedContainer.Location));
								}
								SelectedContainer.MoveTo(this);
						}
				}

				/// <summary>
				/// Selects the container that sends this event
				/// </summary>
				/// <param name="sender">container that sent the event</param>
				private void SelectContainer(Object sender)
				{
						if (SelectedContainer != null)
						{
								SelectedContainer.BackColor = Color.White;
						}
						SelectedContainer = (Container)sender;
						SelectedContainer.BackColor = Color.LightYellow;
						MoveSelectedToThis();
						SelectedContainer.BringToFront();
						OnSelectContainer?.Invoke(SelectedContainer);
				}

				/// <summary>
				/// Adds a new container to this plan
				/// </summary>
				/// <param name="title">container title</param>
				public void AddContainer(string title = "")
				{
						Container container = new Container(this, title);
						container.Location = new Point(50, 50);
						container.OnStartDragging += SelectContainer;
						container.OnStopDragging += MoveSelectedToBelow;
						AddChild(container);
						SelectContainer(container);
				}

				/// <summary>
				/// Replace a container with a placeholder
				/// </summary>
				/// <param name="replace">container to replace</param>
				private void PutPlaceHolder(Container replace)
				{
						PlaceHolder = new PlaceHolder(replace);
				}

				/// <summary>
				/// Remove the placeholder from the plan
				/// </summary>
				private void RemovePlaceHolder()
				{
						if (PlaceHolder != null)
						{
								if (PlaceHolder.ParentContainer != null)
								{
										PlaceHolder.ParentContainer.RemoveChild(PlaceHolder);
								}
								PlaceHolder = null;
						}
				}

				/// <summary>
				/// Undo the last event
				/// </summary>
				public void Undo()
				{
						History.Undo();
				}

				/// <summary>
				/// Redo the last undone event
				/// </summary>
				public void Redo()
				{
						History.Redo();
				}

				#region XML

				/// <summary>
				/// Loads the values for this plan from xml
				/// </summary>
				/// <param name="xml">xml element</param>
				public override void LoadFromXML(XElement xml)
				{
						if (xml.Name != GetType().Name) throw new InvalidXMLException("element name does not equal: " + GetType().Name);

						if (xml.HasElements)
						{
								IEnumerable<XElement> elements = xml.Elements();
								foreach (XElement child in elements)
								{
										Container container = new Container(this);
										container.OnStartDragging += SelectContainer;
										container.OnStopDragging += MoveSelectedToBelow;
										container.LoadFromXML(child);
										AddChild(container);
								}
						}
				}

				#endregion
				
		}
}
