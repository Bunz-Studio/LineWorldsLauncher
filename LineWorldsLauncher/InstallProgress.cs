using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LineWorldsLauncher
{
	public partial class InstallProgress : UserControl
	{
		public InstallProgress()
		{
			InitializeComponent();
		}
		void InstallProgressLoad(object sender, EventArgs e)
		{
			Width = Parent.Width - 10;
			Parent.Resize += (esender, ee) => Width = Parent.Width - 10;
		}
	}
}
