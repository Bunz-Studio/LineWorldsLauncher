using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace LineWorldsLauncher
{
	internal sealed class Program
	{
	    [DllImport("user32.dll")]
	    public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
	    [DllImport("user32.dll", EntryPoint = "FindWindow")]
	    public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
	    
	    public static string launcherPath;
	    public static string queueProject;
		[STAThread]
		private static void Main(string[] args)
		{
			Console.WriteLine(string.Join("\n", args));
			RegisterFileAssoc();
			
			if(args.Length > 1)
			{
				if(args[0] == "-proj")
				{
					if(args[1].Contains("https://"))
					{
						Console.WriteLine("Online projects are not yet supported.");
					}
					else
					{
						var extension = Path.GetExtension(args[1]);
						if(extension.Contains("liwb"))
						{
							queueProject = args[1];
						}
						else
						{
							if(File.Exists(args[1]))
							{
								queueProject = MainForm.GoUpFolder(args[1]);
							}
						}
					}
				}
			}
			
			try
			{
				var processes = new List<Process>(Process.GetProcesses());
				var current = Process.GetCurrentProcess().Id;
				var proc = processes.Find(val => val.Id != current && val.ProcessName.Contains("LineWorldsLauncher"));
				if(proc != null)
				{
					proc.Kill();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Failed to find other Launcher instances: " + e.Message);
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		
        static void RegisterFileAssoc()
        {
            try
            {
	            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\.liw", null, "Line Worlds");
	            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\.liwb", null, "Line Worlds");
	            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("Line Worlds");
	            bool flag = registryKey == null;
	            if (flag)
	            {
	                Program.CreateRegis();
	            }
	            else
	            {
	                RegistryKey registryKey2 = Registry.ClassesRoot.OpenSubKey("Line Worlds").OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command");
	                bool flag2 = registryKey2.GetValue("").ToString() != "\"" + Assembly.GetExecutingAssembly().Location + "\" -proj \"%1\"" || Registry.ClassesRoot.OpenSubKey("Stority").GetValue("Loca") == null;
	                if (flag2)
	                {
	                    Program.CreateRegis();
	                }
	                else
	                {
	                    Program.launcherPath = Registry.ClassesRoot.OpenSubKey("Line Worlds").GetValue("Loca").ToString();
	                }
	            }
            }
            catch (Exception e)
            {
            	// MessageBox.Show("Failed to register file associaion for Line Worlds: " + e.Message);
            }
        }
        public static void CreateRegis()
        {
            try
            {
                RegistryKey registryKey = Registry.ClassesRoot.CreateSubKey("Line Worlds");
                registryKey.SetValue("", "Line Worlds File");
                registryKey.SetValue("URL Protocol", "liw:");
                registryKey.SetValue("Loca", Assembly.GetExecutingAssembly().Location);
                RegistryKey registryKey2 = registryKey.CreateSubKey("shell");
                RegistryKey registryKey3 = registryKey2.CreateSubKey("open").CreateSubKey("command");
                registryKey3.SetValue("", "\"" + Assembly.GetExecutingAssembly().Location + "\" -proj \"%1\"");
            }
            catch (Exception e)
            {
            	// MessageBox.Show("Failed to register internet protocol for Line Worlds: " + e.Message);
            }
        }
	}
}
