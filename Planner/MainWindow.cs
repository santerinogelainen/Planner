using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Planner
{
		/// <summary>
		/// The "main" window of the program where all the editing happens
		/// </summary>
		public partial class MainWindow : Form
		{

				#region VARIABLES, PROPERTIES

				/// <summary>
				/// The file ending of the saved file. should always end with .xml
				/// </summary>
				private static string fileEnding = ".xml";

				private string projectName;

				/// <summary>
				/// Project name. Cannot contain letters that the windows file names cannot handle
				/// </summary>
				public string ProjectName {
						get {
								return projectName;
						}
						set {
								projectName = value;
								Text = value;
						}
				}

				/// <summary>
				/// File name of the project. Contains the file ending
				/// </summary>
				public string FileName { get; set; }

				/// <summary>
				/// The path of the project's save location without filename
				/// </summary>
				public string ProjectPath { get; set; }

				/// <summary>
				/// Boolean whether or not a project is open on the editor
				/// </summary>
				public bool ProjectIsOpen { get; set; }

				/// <summary>
				/// The current open plan on designer panel
				/// </summary>
				public Plan OpenPlan { get; set; }

				#endregion

				#region CONSTRUCTORS

				/// <summary>
				/// Create a new main window with nothing open
				/// </summary>
				private MainWindow()
				{
						InitializeComponent();
						ProjectIsOpen = false;
						FileTree.AfterLabelEdit += UpdateDesignerTitle;
						FileTree.OnRemove += CloseOpenPlan;
						DisableProperties();
						KeyPreview = true;
						KeyDown += DetectKeyCombo;
						FormClosing += (o, e) => CloseProject();
				}

				/// <summary>
				/// Create a new main window with a new project
				/// </summary>
				/// <param name="name">project name</param>
				/// <param name="path">project path without name</param>
				public MainWindow(string name, string path) : this()
				{
						ProjectName = name;
						FileName = name + fileEnding;
						ProjectPath = path;
						ProjectIsOpen = true;
				}

				/// <summary>
				/// Create a mainwindow from xml file
				/// </summary>
				/// <param name="fullpath">the full path of the file, containing the filename</param>
				public MainWindow(string fullpath) : this()
				{
						Open(fullpath);
				}

				#endregion

				/// <summary>
				/// Detects keycomboes and fires events 
				/// </summary>
				private void DetectKeyCombo(Object sender, KeyEventArgs e)
				{
						if (e.KeyCode == Keys.Delete)
						{
								DeleteSelectedContainer();
								e.SuppressKeyPress = true;
						}

						if (e.Control)
						{
								switch (e.KeyCode)
								{
										case Keys.N:
												AddContainer();
												e.SuppressKeyPress = true;
												break;
										case Keys.D:
												DeleteSelectedContainer();
												e.SuppressKeyPress = true;
												break;
								}
						}
				}

				#region UPDATES

				/// <summary>
				/// Updates the title of the selected container
				/// </summary>
				public void UpdateTitle(Object sender, EventArgs e)
				{
						if (OpenPlan != null)
						{
								if (OpenPlan.SelectedContainer != null)
								{
										OpenPlan.SelectedContainer.SetTitle(((Control)sender).Text);
								}
						}
				}

				/// <summary>
				/// Updates the text of the selected container
				/// </summary>
				public void UpdateText(Object sender, EventArgs e)
				{
						if (OpenPlan != null)
						{
								if (OpenPlan.SelectedContainer != null)
								{
										OpenPlan.SelectedContainer.SetText(((RichTextBox)sender).Text);
								}
						}
				}

				/// <summary>
				/// Updates the designer title when we update the folder/plan name
				/// </summary>
				public void UpdateDesignerTitle(Object sender, NodeLabelEditEventArgs e)
				{
						if (e.Node is PlanNode)
						{
								if (((PlanNode)e.Node).Plan == OpenPlan)
								{
										if (e.Label == null)
										{
												PlanName.Text = e.Node.Text;
										}
										else
										{
												PlanName.Text = e.Label;
										}
								}
						}
				}

				#endregion

				#region PROPERTIES PANEL

				/// <summary>
				/// Updates the properties panel input values
				/// </summary>
				/// <param name="selected">selected container</param>
				public void SetProperties(Container selected)
				{
						EnableProperties();
						EditTitle.Text = selected.Title;
						EditText.Text = selected.ContainerText;
						switch (selected.RenderMode)
						{
								case ContainerRenderMode.Relative:
										RenderModeRelative.Checked = true;
										RenderModeLinear.Checked = false;
										break;
								case ContainerRenderMode.Linear:
										RenderModeRelative.Checked = false;
										RenderModeLinear.Checked = true;
										break;
						}
				}

				/// <summary>
				/// Disables / hides the properties panel
				/// </summary>
				public void DisableProperties()
				{
						PropertiesWrapper.Visible = false;
				}

				/// <summary>
				/// Enables / shows the properties panel
				/// </summary>
				public void EnableProperties()
				{
						PropertiesWrapper.Visible = true;
				}

				#endregion

				#region OPEN PLAN

				/// <summary>
				/// Closes the open plan
				/// </summary>
				public void CloseOpenPlan()
				{
						if (OpenPlan != null)
						{
								OpenPlan = null;
								PlanName.Text = "";
								DesignerPanel.Controls.Clear();
								DisableProperties();
						}
				}

				/// <summary>
				/// Select a plan from the treeview
				/// </summary>
				public void SelectPlan(Object sender, TreeViewEventArgs e)
				{
						if (e.Node is PlanNode)
						{
								DisableProperties();
								OpenPlan = ((PlanNode)e.Node).Plan;
								OpenPlan.MinimumSize = DesignerPanel.Size;
								if (OpenPlan.SelectedContainer != null)
								{
										SetProperties(OpenPlan.SelectedContainer);
								}
								PlanName.Text = e.Node.Text;
								DesignerPanel.Controls.Clear();
								DesignerPanel.Controls.Add(OpenPlan);
								OpenPlan.OnSelectContainer -= SetProperties;
								OpenPlan.OnSelectContainer += SetProperties;
						}
				}

				/// <summary>
				/// Adds a container to the open plan
				/// </summary>
				public void AddContainer(Object sender = null, EventArgs e = null)
				{
						if (OpenPlan != null)
						{
								OpenPlan.AddContainer();
						}
				}

				/// <summary>
				/// Deletes the selected container
				/// </summary>
				public void DeleteSelectedContainer(Object sender = null, EventArgs e = null)
				{
						if (OpenPlan != null)
						{
								OpenPlan.DeleteSelectedContainer();
								DisableProperties();
						}
				}

				#endregion

				#region  MODIFY PLANTREE

				/// <summary>
				/// Removes a node from the filetree
				/// </summary>
				public void RemoveNode(Object sender = null, EventArgs e = null)
				{
						FileTree.RemoveSelectedNode();
				}

				/// <summary>
				/// Creates a new folder
				/// </summary>
				public void NewFolder(Object sender, EventArgs e)
				{
						FileTree.AddNewFolder();
				}

				/// <summary>
				/// Create a new plan
				/// </summary>
				public void NewPlan(Object sender, EventArgs e)
				{
						FileTree.AddNewPlan();
				}

				#endregion

				#region RENDER MODE

				/// <summary>
				/// Changes the render mode of the selected container
				/// </summary>
				/// <param name="sender">Event sender</param>
				/// <param name="mode">new render mode</param>
				private void ChangeSelectedRenderMode(RadioButton sender, ContainerRenderMode mode)
				{
						if (OpenPlan != null)
						{
								if (OpenPlan.SelectedContainer != null)
								{
										if (sender.Checked)
										{
												OpenPlan.SelectedContainer.ChangeRenderMode(mode);
										}
								}
						}
				}

				/// <summary>
				/// Changes the selected container's render mode to relative
				/// </summary>
				public void RenderModeToRelative(Object sender, EventArgs e)
				{
						ChangeSelectedRenderMode((RadioButton)sender, ContainerRenderMode.Relative);
				}

				/// <summary>
				/// Changes the selected container's render mode to linear
				/// </summary>
				public void RenderModeToLinear(Object sender, EventArgs e)
				{
						ChangeSelectedRenderMode((RadioButton)sender, ContainerRenderMode.Linear);
				}

				#endregion

				#region SAVE, OPEN, CLOSE, NEW PROJECT, EDIT PROJECT

				/// <summary>
				/// Create a new project
				/// </summary>
				public void NewProject(Object sender, EventArgs e)
				{
						ProjectSettingsForm projectSettings = new ProjectSettingsForm();
						projectSettings.OnOk += (string name, string path) =>
						{
								CloseProject();
								ProjectName = name;
								FileName = name + fileEnding;
								ProjectPath = path;
								ProjectIsOpen = true;
						};
						projectSettings.ShowDialog(this);
				}

				/// <summary>
				/// Open a project
				/// </summary>
				/// <param name="fullpath">the full path of the xml file</param>
				public void Open(string fullpath)
				{
						// set project fullpath
						FileName = Path.GetFileName(fullpath);

						// set project save path
						string path = Path.GetDirectoryName(fullpath);
						ProjectPath = path;

						// load document
						XDocument document = XDocument.Load(fullpath, LoadOptions.SetLineInfo);

						// set project name
						XAttribute name = document.Root.Attribute("name");
						if (name == null) throw new InvalidXMLException("project root node does not contain a name attribute");
						ProjectName = name.Value;

						// load filetree from the xml
						FileTree.LoadFromXML(document.Root);
						ProjectIsOpen = true;
				}

				/// <summary>
				/// Closes the project
				/// </summary>
				public void CloseProject()
				{
						// TODO: make it so that it only asks this if you havent saved already
						DialogResult result = MessageBox.Show("Do you want to save before closing the current project?", "Save?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
								Save();
						}
						ProjectName = "";
						ProjectPath = "";
						ProjectIsOpen = false;
						FileTree.Nodes.Clear();
						CloseOpenPlan();
				}

				/// <summary>
				/// Opens a project
				/// </summary>
				public void OpenProject(Object sender, EventArgs e)
				{
						OpenFileDialog dialog = new OpenFileDialog();
						dialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
						dialog.Filter = "XML Files (*.xml)|*.xml";

						if (dialog.ShowDialog() == DialogResult.OK)
						{
								CloseProject();
								Open(dialog.FileName);
						}
				}

				/// <summary>
				/// Saves the project to the fullpath. This will always overwrite old files
				/// </summary>
				/// <param name="fullpath">the full path of the saved file</param>
				public void Save(string fullpath)
				{
						XElement file = FileTree.ToXML();
						Debug.WriteLine(file);
						file.Add(new XAttribute("name", ProjectName));
						file.Save(fullpath);
				}

				/// <summary>
				/// Saves the project
				/// </summary>
				public void Save(Object sender = null, EventArgs e = null)
				{
						Save(ProjectPath + "/" + FileName);
				}

				/// <summary>
				/// Opens the saveas dialog and saves the project. Note! this will change the ProjectPath property
				/// </summary>
				public void SaveAs(Object sender, EventArgs e)
				{
						SaveFileDialog dialog = new SaveFileDialog();
						dialog.FileName = ProjectName;
						dialog.AddExtension = true;
						dialog.Filter = "XML Files (*.xml)|*.xml";
						dialog.DefaultExt = ".xml";
						dialog.InitialDirectory = ProjectPath;
						if (dialog.ShowDialog() == DialogResult.OK)
						{
								ProjectPath = Path.GetDirectoryName(dialog.FileName);
								FileName = Path.GetFileName(dialog.FileName);
								Save(dialog.FileName);
						}
				}

				/// <summary>
				/// Edits the project's settings
				/// </summary>
				public void EditProjectSettings(Object sender, EventArgs e)
				{
						ProjectSettingsForm projectSettings = new ProjectSettingsForm(ProjectName, ProjectPath);
						projectSettings.OnOk += (name, path) =>
						{
								ProjectName = name;
								ProjectPath = path;
						};
						projectSettings.ShowDialog(this);
				}

				#endregion
		}
}
