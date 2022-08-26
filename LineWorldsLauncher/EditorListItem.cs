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
		public EditorListItem(string editorPath)
		{
			InitializeComponent();
			
			var versionInfo = FileVersionInfo.GetVersionInfo(editorPath);
			string version = versionInfo.FileVersion;
			editorTitleLabel.Text = "Line Worlds " + version;
			editorPathLabel.Text = editorPath;
		}
	}
}
