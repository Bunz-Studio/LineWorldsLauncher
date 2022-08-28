using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LineWorldsLauncher
{
	public partial class EditorListItem : UserControl
	{
		public string path;
		public EditorListItem(string editorPath)
		{
			InitializeComponent();
			path = editorPath;
			var editorDir = MainForm.GoUpFolder(editorPath);
			var verPath = Path.Combine(editorDir, "LineWorlds_Data", "version");
			var versionInfo = FileVersionInfo.GetVersionInfo(editorPath);
			string version = versionInfo.FileVersion;
			if(File.Exists(verPath))
			{
				version = File.ReadAllText(verPath);
			}
			editorTitleLabel.Text = "Line Worlds " + version;
			editorPathLabel.Text = editorPath;
		}
		
		void OpenButtonClick(object sender, EventArgs e)
		{
            var proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.FileName = path;
            proc.Verb = "runas";
            try
            {
                Process.Start(proc);
            }
            catch (Exception ex)
            {
            	proc = new ProcessStartInfo();
            	proc.UseShellExecute = true;
            	proc.FileName = path;
                Process.Start(proc);
                MessageBox.Show("Line Worlds isn't started as administrator, some things might broke", "Warning");
            }
		}
	}
}
