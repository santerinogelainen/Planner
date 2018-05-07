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
				
				private Point MouseDownLocation { get; set; }
				private bool Dragging { get; set; }

				private Label TitleLabel { get; set; }
				public string Title { get; private set; }

				public Container(string title = "") : base()
				{
						TitleLabel = new Label();
						Controls.Add(TitleLabel);

						SetTitle(title);

						// min size and default color / border
						MinimumSize = new Size(100, 50);
						BackColor = Color.White;
						BorderStyle = BorderStyle.FixedSingle;

						MouseMove += Drag;
						MouseDown += StartDragging;
						MouseUp += StopDragging;
				}

				public void StartDragging(Object sender, MouseEventArgs e)
				{
						MouseDownLocation = e.Location;
						Dragging = true;
				}

				public void StopDragging(Object sender, MouseEventArgs e)
				{
						Dragging = false;
				}

				public void Drag(Object sender, MouseEventArgs e)
				{
						if (Dragging)
						{
								Left = e.X + Left - MouseDownLocation.X;
								Top = e.Y + Top - MouseDownLocation.Y;

						}
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
