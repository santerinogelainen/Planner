using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
		public class CustomNode : TreeNode
		{
				public TreeNodeType NodeType { get; set; }

				public CustomNode(string name, TreeNodeType type) : base()
				{
						NodeType = type;
						Text = name;
						ImageIndex = GetImageIndexFromType(type);
						SelectedImageIndex = GetImageIndexFromType(type);
				}

				public int GetImageIndexFromType(TreeNodeType type)
				{
						switch(type)
						{
								case TreeNodeType.Folder:
										return 0;
								case TreeNodeType.Plan:
										return 2;
						}
						return 2;
				}
		}
}
