using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LineWorldsLauncher
{
	public partial class ProjectListItem : UserControl
	{
		public ProjectListItem(string directory)
		{
			InitializeComponent();
			
			projectTitleLabel.Text = Path.GetFileName(directory);
			projectPathLabel.Text = directory;
			
			projectOwnerLabel.Text = "Unknown";
		}
	}
}
