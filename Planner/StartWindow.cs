using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
		public partial class StartWindow : Form
		{
				public StartWindow()
				{
						InitializeComponent();
				}

				public void NewProject(Object sender, EventArgs e)
				{
						NewProjectForm projectSettings = new NewProjectForm();
						projectSettings.StartPosition = FormStartPosition.CenterScreen;
						projectSettings.OnOk += (string name, string path) =>
						{
								MainWindow window = new MainWindow(name, path);
								window.FormClosed += (s, args) => Close();
								window.Show();
								Hide();
						};
						projectSettings.ShowDialog(this);
				}

				public void OpenProject(Object sender, EventArgs e)
				{

				}
		}
}
