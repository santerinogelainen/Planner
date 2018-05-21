using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Linq;

namespace Planner
{
		/// <summary>
		/// Represents a render mode for container's children
		/// </summary>
		public enum ContainerRenderMode
		{
				/// <summary>
				/// Render children in a linear fashion, child location cannot be changed inside the container
				/// </summary>
				Linear,
				/// <summary>
				/// Render children in a relative mode (relative to parent), child location can be changed freely
				/// </summary>
				Relative
		}

		/// <summary>
		/// Represents a single container, that can contain other containers, text or a title
		/// </summary>
		public class Container : BaseContainer
		{

				#region EVENTS

				/// <summary>
				/// Fires when we mousedown this object
				/// </summary>
				public event Action<Container> OnStartDragging;
				/// <summary>
				/// Fires when we mouseup on this object
				/// </summary>
				public event Action OnStopDragging;
				/// <summary>
				/// Fires when we drag the object
				/// </summary>
				public event Action OnDrag;

				#endregion

				#region PROPERTIES / VARIABLES

				/// <summary>
				/// This adds resizeable actions
				/// </summary>
				protected override CreateParams CreateParams {
						get {
								var cp = base.CreateParams;
								cp.Style |= 0x00040000;  // Turn on WS_BORDER + WS_THICKFRAME
								return cp;
						}
				}

				/// <summary>
				/// Location of the mouse when we mouse down
				/// </summary>
				private Point MouseDownLocation { get; set; }

				/// <summary>
				/// Boolean of whether or not we are dragging currently
				/// </summary>
				private bool Dragging { get; set; }

				/// <summary>
				/// Render mode of this container
				/// </summary>
				public ContainerRenderMode RenderMode { get; private set; }

				/// <summary>
				/// Title of the container
				/// </summary>
				public string Title { get; set; }
				private Label TitleLabel { get; set; }

				/// <summary>
				/// Text of the container
				/// </summary>
				public string ContainerText { get; private set; }
				private Label TextLabel { get; set; }

				#endregion

				#region CONTRUCTOR(S)

				/// <summary>
				/// Create a container
				/// </summary>
				/// <param name="title">optional title for the container</param>
				public Container(string title = "") : base()
				{
						// default render mode and add padding
						RenderMode = ContainerRenderMode.Relative;
						Padding = new Padding(5);

						// initialize the controls for title and text
						InitText("");
						InitTitle(title);
						
						// adjust the label widths according to this containers width
						UpdateLabelSizes();
						Resize += UpdateLabelSizes;

						// min size and default color
						MinimumSize = new Size(100, 50);
						BackColor = Color.White;

						// initialize drag events
						MouseMove += Drag;
						MouseDown += StartDragging;
						MouseUp += StopDragging;
				}

				#endregion

				#region RENDER MODE

				/// <summary>
				/// Adjust the children according to the render mode
				/// </summary>
				public void AdjustChildren()
				{
						if (Children.Count > 0)
						{
								int height = Children[0].Location.Y;
								foreach (BaseContainer child in Children)
								{
										if (RenderMode == ContainerRenderMode.Linear)
										{
												child.Dock = DockStyle.Top;
										}
										else
										{
												child.Anchor = AnchorStyles.None;
												child.Location = new Point(5, height);
												height += child.Size.Height;
										}
								}
						}
				}

				/// <summary>
				/// Changes the render mode of this container. Note! changing the rendermode means that the CHILDREN render differently, not this container
				/// </summary>
				/// <param name="mode"></param>
				public void ChangeRenderMode(ContainerRenderMode mode)
				{
						RenderMode = mode;
						OnAdd -= ChildToLinear;
						if (RenderMode == ContainerRenderMode.Linear)
						{
								OnAdd += ChildToLinear;
						}
						AdjustChildren();
				}

				public void ChildToLinear(BaseContainer child)
				{
						child.Dock = DockStyle.Top;
				}

				#endregion

				#region TEXT AND LABEL CONTROLS

				/// <summary>
				/// Inititalizes the text label control
				/// </summary>
				/// <param name="text">text</param>
				private void InitText(string text)
				{
						TextLabel = GetNewLabel();
						Controls.Add(TextLabel);
						SetText(text);
				}

				/// <summary>
				/// Creates a new label with specific styling shared between text and title
				/// </summary>
				/// <returns>label</returns>
				private Label GetNewLabel()
				{
						Label label = new Label();
						label.Dock = DockStyle.Top;
						label.MouseMove += Drag;
						label.MouseUp += StopDragging;
						label.MouseDown += StartDragging;
						label.Padding = new Padding(0, 0, 0, 5);
						label.AutoSize = true;
						return label;
				}

				/// <summary>
				/// Inititalizes the title label control
				/// </summary>
				/// <param name="text">title</param>
				private void InitTitle(string title)
				{
						TitleLabel = GetNewLabel();
						TitleLabel.Font = new Font(TitleLabel.Font, FontStyle.Bold);
						Controls.Add(TitleLabel);
						SetTitle(title);
				}

				/// <summary>
				/// Updates the size of the label controls (title and text) to match parent
				/// </summary>
				private void UpdateLabelSizes(Object sender = null, EventArgs e = null)
				{
						if (TextLabel != null) TextLabel.MaximumSize = new Size(ClientSize.Width - (Padding.Left + Padding.Right), 0);
						if (TitleLabel != null) TitleLabel.MaximumSize = new Size(ClientSize.Width - (Padding.Left + Padding.Right), 0);
				}

				/// <summary>
				/// Set the text of this container
				/// </summary>
				public void SetText(string newtext)
				{
						ContainerText = newtext;
						TextLabel.Text = ContainerText;
						// show textlabel if its not empty, hide it if it is empty
						TextLabel.Visible = newtext != "";
				}

				/// <summary>
				/// Set the title of this container
				/// </summary>
				public void SetTitle(string newtitle)
				{
						Title = newtitle;
						TitleLabel.Text = Title;
						// show titlelabel if its not empty, hide it if it is empty
						TitleLabel.Visible = newtitle != "";
				}

				#endregion

				#region DRAG EVENT IMPLEMENTATIONS

				/// <summary>
				/// Event that fires when we mouse down
				/// </summary>
				private void StartDragging(Object sender, MouseEventArgs e)
				{
						// remove all dock styles, set location of the mouse, start dragging, and invoke events
						MouseDownLocation = e.Location;
						Dragging = true;
						OnStartDragging?.Invoke(this);
						Anchor = AnchorStyles.None;
				}
				
				/// <summary>
				/// Fires when we mouseup
				/// </summary>
				private void StopDragging(Object sender, MouseEventArgs e)
				{
						// stop dragging and invoke event
						Dragging = false;
						OnStopDragging?.Invoke();
				}

				/// <summary>
				/// Fires when we mousemove
				/// </summary>
				private void Drag(Object sender, MouseEventArgs e)
				{
						// only fire if we are dragging
						if (Dragging)
						{
								// set the new location and invoke event
								Left = e.X + Left - MouseDownLocation.X;
								Top = e.Y + Top - MouseDownLocation.Y;
								OnDrag?.Invoke();
						}
				}

				#endregion

				#region XML

				/// <summary>
				/// Loads the containers values from xml. Throws InvalidXMLExceptions if xml is invalid or other exceptions
				/// </summary>
				/// <param name="xml">xml element</param>
				public override void LoadFromXML(XElement xml)
				{
						// check that the xml tag name is Container
						if (xml.Name != GetType().Name) throw new InvalidXMLException("element name does not equal: " + GetType().Name, xml);

						// load all attributes
						XAttribute location = xml.Attribute("location");
						XAttribute size = xml.Attribute("size");
						XAttribute renderMode = xml.Attribute("renderMode");
						XAttribute title = xml.Attribute("title");
						XAttribute text = xml.Attribute("text");

						// check required attributes
						if (location == null || renderMode == null || size == null)
								throw new InvalidXMLException("element for a container does not have required attributes 'location' or 'renderMode' or 'size'", xml);

						// split location into two, x and y
						string[] locationXY = location.Value.Split(',');
						if (locationXY.Length != 2) throw new InvalidXMLException("container location attribute has too many or little values, location syntax: x,y", xml);

						// these will throw exceptions if the value is anything other than an integer
						// maybe in the future we want to use InvalidXMLExeption for these as well
						int x = int.Parse(locationXY[0]);
						int y = int.Parse(locationXY[1]);
						// set location
						Location = new Point(x, y);

						string[] sizeWH = size.Value.Split(',');
						if (sizeWH.Length != 2) throw new InvalidXMLException("container size attribute has too many values, size syntax: width,height", xml);

						// these will throw exceptions if the value is anything other than an integer
						// maybe in the future we want to use TryParse/InvalidXMLExeption for these as well
						int w = int.Parse(sizeWH[0]);
						int h = int.Parse(sizeWH[1]);
						// set size
						ClientSize = new Size(w, h);

						// set render mode
						ChangeRenderMode((ContainerRenderMode)Enum.Parse(typeof(ContainerRenderMode), renderMode.Value));

						// set title and text
						if (title != null) SetTitle(title.Value);
						if (text != null) SetText(text.Value);

						// loop child containers if there are any
						if (xml.HasElements)
						{
								IEnumerable<XElement> elements = xml.Elements();
								foreach (XElement child in elements)
								{
										Container container = new Container();
										container.OnStartDragging = OnStartDragging;
										container.OnStopDragging = OnStopDragging;
										container.LoadFromXML(child);
										AddChild(container);
								}
						}
				}

				/// <summary>
				/// Transforms this container into xml
				/// </summary>
				/// <returns>xelement</returns>
				public override XElement ToXML()
				{
						XElement xml = base.ToXML(); // basecontainer does all the work for looping the children
						xml.Add(new XAttribute("location", Location.X + "," + Location.Y));
						xml.Add(new XAttribute("size", ClientSize.Width + "," + ClientSize.Height));
						xml.Add(new XAttribute("renderMode", RenderMode));
						// only add title and text if there is one
						if (Title != "")
						{
								xml.Add(new XAttribute("title", Title));
						}
						if (ContainerText != "")
						{
								xml.Add(new XAttribute("text", ContainerText));
						}
						return xml;
				}

				#endregion
		}
}
