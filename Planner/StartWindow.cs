using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

				/// <summary>
				/// Create a new project
				/// </summary>
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

				/// <summary>
				/// Open a project
				/// </summary>
				public void OpenProject(Object sender, EventArgs e)
				{
						OpenFileDialog dialog = new OpenFileDialog();
						dialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
						dialog.Filter = "XML Files (*.xml)|*.xml";
						
						if (dialog.ShowDialog() == DialogResult.OK)
						{
								MainWindow window = new MainWindow(dialog.FileName);
								window.FormClosed += (s, args) => Close();
								window.Show();
								Hide();
						}
				}
		}
}
