using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LineWorldsLauncher
{
	public partial class TutorialListItem : UserControl
	{
		public TutorialItem item;
		public TutorialListItem(TutorialItem item)
		{
			InitializeComponent();
			this.item = item;
			
			chapterLabel.Text = item.chapter;
			titleLabel.Text = item.title;
		}
		
		void TutorialListItemLoad(object sender, EventArgs e)
		{
			Width = Parent.Width - 10;
			Parent.Resize += (esender, ee) => Width = Parent.Width - 10;
		}
		
		void MainButtonClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(item.link);
		}
	}
	
	public class TutorialItem
	{
		public string chapter;
		public string title;
		public string link;
	}
	
	public class ServerTutorials
	{
		public List<TutorialItem> tutorials = new List<TutorialItem>();
	}
}
