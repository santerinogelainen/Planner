using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Planner
{
		public class Container : BaseContainer
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

				private Label TitleLabel { get; set; }
				public string Title { get; private set; }

				private Label TextLabel { get; set; }
				public string ContainerText { get; private set; }

				public Container(string title = "") : base()
				{
						Padding = new Padding(5);

						TitleLabel = new Label();
						TitleLabel.Font = new Font(TitleLabel.Font, FontStyle.Bold);
						TitleLabel.Dock = DockStyle.Top;
						TitleLabel.MouseMove += Drag;
						TitleLabel.MouseUp += StopDragging;
						TitleLabel.MouseDown += StartDragging;
						TitleLabel.AutoSize = true;
						SetTitle(title);

						TextLabel = new Label();
						TextLabel.Dock = DockStyle.Top;
						TextLabel.MouseMove += Drag;
						TextLabel.MouseUp += StopDragging;
						TextLabel.MouseDown += StartDragging;
						TextLabel.AutoSize = true;
						
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
						MouseDownLocation = e.Location;
						Dragging = true;
						OnStartDragging?.Invoke(this);
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
				}

				public void SetTitle(string newtitle)
				{
						Title = newtitle;
						TitleLabel.Text = Title;
				}

				public void MoveTo(IContainer newParent)
				{
						if (ParentContainer != null)
						{
								ParentContainer.RemoveChild(this);
						}
						newParent.AddChild(this);
				}

		}
}
