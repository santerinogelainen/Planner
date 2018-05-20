﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
		static class Program
		{
				/// <summary>
				/// The main entry point for the application.
				/// </summary>
				[STAThread]
				static void Main()
				{
						Debug.WriteLine(SystemInformation.FrameBorderSize);

						Application.EnableVisualStyles();
						Application.SetCompatibleTextRenderingDefault(false);
						Application.Run(new StartWindow());
				}
		}
}
