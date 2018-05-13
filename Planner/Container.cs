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

		public class Container : BaseContainer, IXMLTransformable
		{

				public event Action<Object> OnStartDragging;
				public event Action OnStopDragging;
				public event Action OnDrag;

				protected override CreateParams CreateParams {
						get {
								var cp = base.CreateParams;
								cp.Style |= 0x00040000;  // Turn on WS_BORDER + WS_THICKFRAME
								return cp;
						}
				}

				private Point MouseDownLocation { get; set; }
				private bool Dragging { get; set; }

				public ContainerRenderMode RenderMode { get; private set; }

				private Label TitleLabel { get; set; }
				public string Title { get; private set; }

				private Label TextLabel { get; set; }
				public string ContainerText { get; private set; }

				public Container(string title = "") : base()
				{
						// default render mode
						RenderMode = ContainerRenderMode.Relative;
						DuringRender += AdjustRenderedChild;
						Padding = new Padding(5);

						TitleLabel = new Label();
						TitleLabel.Font = new Font(TitleLabel.Font, FontStyle.Bold);
						TitleLabel.Dock = DockStyle.Top;
						TitleLabel.MouseMove += Drag;
						TitleLabel.MouseUp += StopDragging;
						TitleLabel.MouseDown += StartDragging;
						TitleLabel.AutoSize = true;
						TitleLabel.Padding = new Padding(0, 0, 0, 5);
						SetTitle(title);

						TextLabel = new Label();
						TextLabel.Dock = DockStyle.Top;
						TextLabel.MouseMove += Drag;
						TextLabel.MouseUp += StopDragging;
						TextLabel.MouseDown += StartDragging;
						TextLabel.Padding = new Padding(0, 0, 0, 5);
						TextLabel.AutoSize = true;
						TextLabel.Visible = false;
						SetText("");
						
						UpdateLabelSizes();

						BeforeRender += () =>
						{
								AddControl(TextLabel);
								AddControl(TitleLabel);
						};

						Resize += (Object sender, EventArgs e) =>
						{
								UpdateLabelSizes();
						};

						// min size and default color / border
						MinimumSize = new Size(100, 50);
						BackColor = Color.White;

						MouseMove += Drag;
						MouseDown += StartDragging;
						MouseUp += StopDragging;
				}

				private void AdjustRenderedChild(BaseContainer child)
				{
						if (RenderMode == ContainerRenderMode.Linear)
						{
								child.Dock = DockStyle.Top;
								child.Size = new Size(child.ClientSize.Width, child.Size.Height);
						}
				}

				private void UpdateLabelSizes()
				{
						if (TextLabel != null)
						{
								TextLabel.MaximumSize = new Size(ClientSize.Width - (Padding.Left + Padding.Right), 0);
						}
						if (TitleLabel != null)
						{
								TitleLabel.MaximumSize = new Size(ClientSize.Width - (Padding.Left + Padding.Right), 0);
						}
				}

				private void AddControl(Control control)
				{
						if (control != null)
						{
								Controls.Add(control);
						}
				}

				public void StartDragging(Object sender, MouseEventArgs e)
				{
						Dock = DockStyle.None;
						MouseDownLocation = e.Location;
						Dragging = true;
						OnStartDragging?.Invoke(this);
				}

				public void ChangeRenderMode(ContainerRenderMode mode)
				{
						RenderMode = mode;
						RenderChildren();
				}

				public void StopDragging(Object sender, MouseEventArgs e)
				{
						Dragging = false;
						OnStopDragging?.Invoke();
				}

				public void Drag(Object sender, MouseEventArgs e)
				{
						if (Dragging)
						{
								Left = e.X + Left - MouseDownLocation.X;
								Top = e.Y + Top - MouseDownLocation.Y;
								OnDrag?.Invoke();
						}
				}

				public void SetText(string newtext)
				{
						ContainerText = newtext;
						TextLabel.Text = ContainerText;
						// show textlabel if its not empty, hide it if it is empty
						TextLabel.Visible = newtext != "";
				}

				public void SetTitle(string newtitle)
				{
						Title = newtitle;
						TitleLabel.Text = Title;
						// show titlelabel if its not empty, hide it if it is empty
						TitleLabel.Visible = newtitle != "";
				}

				public void MoveTo(IContainer newParent)
				{
						if (ParentContainer != null)
						{
								ParentContainer.RemoveChild(this);
						}
						newParent.AddChild(this);
				}

				public override XElement ToXML()
				{
						XElement xml = base.ToXML();
						xml.Add(new XAttribute("location", Location.X + "," + Location.Y));
						xml.Add(new XAttribute("renderMode", RenderMode));
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
		}
}
