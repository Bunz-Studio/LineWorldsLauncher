using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LineWorldsLauncher
{
	public partial class FlowLayoutItem : UserControl
	{
		public FlowLayoutItem()
		{
			InitializeComponent();
		}
		
		void MainTitleClick(object sender, EventArgs e)
		{
			OnClick(e);
		}
		void SecondaryLabelMouseDown(object sender, MouseEventArgs e)
		{
			OnMouseDown(e);
		}
		void MainTitleMouseDown(object sender, MouseEventArgs e)
		{
			OnMouseDown(e);
		}
		void FlowLayoutItemLoad(object sender, EventArgs e)
		{
			Width = Parent.Width - 10;
			Parent.Resize += (esender, ee) => Width = Parent.Width - 10;
		}
	}
}
