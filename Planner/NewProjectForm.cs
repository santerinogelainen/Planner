using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Planner
{
		public partial class NewProjectForm : Form
		{
				public event Action<string, string> OnOk;

				public NewProjectForm()
				{
						InitializeComponent();
						ProjectLocation.Text = Path.GetDirectoryName(Application.ExecutablePath);
						CenterToParent();
				}

				/// <summary>
				/// Prevent windows filename illegal characters from the title
				/// </summary>
				public void PreventIllegalCharacters(Object sender, KeyPressEventArgs e)
				{
						if (!Char.IsControl(e.KeyChar) && (Path.GetInvalidFileNameChars().Contains(e.KeyChar) || Path.GetInvalidPathChars().Contains(e.KeyChar)))
						{
								e.Handled = true;
						}
				}

				/// <summary>
				/// Closes the form
				/// </summary>
				public void CloseForm(Object sender = null, EventArgs e = null)
				{
						Close();
				}

				/// <summary>
				/// Opens the folder dialog for project location
				/// </summary>
				public void OpenFolderDialog(Object sender, EventArgs e)
				{
						FolderBrowserDialog dialog = new FolderBrowserDialog();
						dialog.Description = "Choose a folder for your project xml location";
						if (Directory.Exists(ProjectLocation.Text))
						{
								dialog.SelectedPath = ProjectLocation.Text;
						} else
						{
								dialog.SelectedPath = Path.GetDirectoryName(Application.ExecutablePath);
						}
						DialogResult result = dialog.ShowDialog();

						if (result == DialogResult.OK)
						{
								ProjectLocation.Text = dialog.SelectedPath;
						}
				}

				/// <summary>
				/// Shows an error
				/// </summary>
				/// <param name="msg">error message</param>
				public void ShowError(string msg)
				{
						ErrorMsg.Text = msg;
						ErrorMsg.Visible = true;
				}

				/// <summary>
				/// Triggers on ok
				/// </summary>
				public void Ok(Object sender, EventArgs e)
				{
						if (Directory.Exists(ProjectLocation.Text))
						{
								OnOk?.Invoke(ProjectName.Text, ProjectLocation.Text);
								CloseForm();
						} else
						{
								ShowError("Location does not exist, or is invalid.\nPlease check the project save location and try again.");
						}
				}
		}
}
