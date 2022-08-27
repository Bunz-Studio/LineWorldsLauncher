using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LineWorldsLauncher
{
	internal sealed class Program
	{
	    [DllImport("user32.dll")]
	    public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
	    [DllImport("user32.dll", EntryPoint = "FindWindow")]
	    public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
		[STAThread]
		private static void Main(string[] args)
		{
			var processes = new List<Process>(Process.GetProcesses());
			var current = Process.GetCurrentProcess().Id;
			var proc = processes.Find(val => val.Id != current && val.ProcessName.Contains("LineWorldsLauncher"));
			if(proc != null)
			{
				proc.Kill();
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
