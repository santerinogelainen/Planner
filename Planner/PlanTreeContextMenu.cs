using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
		public class PlanTreeContextMenu : ContextMenuStrip
		{
				#region EVENTS, VARIABLES AND PROPERTIES

				/// <summary>
				/// The tree that contains this context menu
				/// </summary>
				private PlanTree Tree { get; set; }

				/// <summary>
				/// The remove button on this context menu
				/// </summary>
				private ToolStripMenuItem RemoveButton { get; set; }

				/// <summary>
				/// The add plan button on this context menu
				/// </summary>
				private ToolStripMenuItem AddPlanButton { get; set; }

				/// <summary>
				/// The add folder button on this context menu
				/// </summary>
				private ToolStripMenuItem AddFolderButton { get; set; }

				#endregion

				public PlanTreeContextMenu(PlanTree tree)
				{
						Tree = tree;
						// add all the buttons
						Items.Add(AddPlanButton = new ToolStripMenuItem("Add plan", Properties.Resources.AddFile_16x, AddPlan));
						Items.Add(AddFolderButton = new ToolStripMenuItem("Add folder", Properties.Resources.AddFolder_16x, AddFolder));
						Items.Add(RemoveButton = new ToolStripMenuItem("Remove", Properties.Resources.Cancel_16x, RemoveNode));
				}

				#region BUTTON EVENT IMPLEMENTATIONS

				/// <summary>
				/// Removes a node trom the plantree
				/// </summary>
				private void RemoveNode(Object sender, EventArgs e)
				{
						Tree.RemoveSelectedNode();
				}

				/// <summary>
				/// Adds a plan to the plantree
				/// </summary>
				private void AddPlan(Object sender, EventArgs e)
				{
						Tree.AddNewPlan();
				}

				/// <summary>
				/// Adds a folder to the plantree
				/// </summary>
				private void AddFolder(Object sender, EventArgs e)
				{
						Tree.AddNewFolder();
				}

				#endregion

		}
}
