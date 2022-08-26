using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LineWorldsLauncher
{
	public partial class MainForm : Form
	{
		public Panel[] panels;
		public Panel[] projPanels;
		public int projPanelIndex;
		
		public List<ProjectInstance> instances = new List<ProjectInstance>();
		public List<EditorInstance> editorInstances = new List<EditorInstance>();
		
		public MainForm()
		{
			InitializeComponent();
			panels = new []{
				welcomePanel,
				projectsPanel
			};
			projPanels = new []{
				proj_projectListPanel,
				proj_editorListPanel
			};
			projPanelIndex = 0;
			MoveTab(0);
			MoveProjectTab(projPanelIndex);
		}
		
		public void MoveTab(int index)
		{
			for(int i = 0; i < panels.Length; i++)
			{
				panels[i].Visible = i == index;
			}
		}
		public void MoveProjectTab(int index)
		{
			for(int i = 0; i < projPanels.Length; i++)
			{
				projPanels[i].Visible = i == index;
			}
		}
		
		public void RefreshList()
		{
			
		}
		
		void Welc_goButtonClick(object sender, EventArgs e)
		{
			MoveTab(1);
			RefreshList();
		}
		
		void FlowLayoutPanel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void MainFormActivated(object sender, EventArgs e)
		{
			RefreshList();
		}
		
		void Proj_editorsButtonClick(object sender, EventArgs e)
		{
			MoveProjectTab(1);
			proj_NewButton.Text = "Install";
		}
		
		void Proj_projectsButtonClick(object sender, EventArgs e)
		{
			MoveProjectTab(0);
			proj_NewButton.Text = "New";
		}
		
		void Proj_openButtonClick(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog();
			dialog.RestoreDirectory = true;
			dialog.Filter = "Executable file (.exe)|*.exe|All files (*.*)|*.*";
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				ImportEditor(dialog.FileName);
			}
		}
		
		public void ImportEditor(string path)
		{
			if(!editorInstances.Exists(val => val.path == path))
			{
				var inst = new EditorListItem(path);
				proj_editorListPanel.Controls.Add(inst);
				var i = new EditorInstance();
				i.path = path;
				i.listItem = inst;
				editorInstances.Add(i);
				RefreshEditorList();
			}
		}
		
		public void RefreshEditorList()
		{
			foreach(Control c in proj_editorListPanel.Controls)
			{
				c.Width = proj_editorListPanel.Width - 10;
			}
		}
		
		void Proj_editorListPanelResize(object sender, EventArgs e)
		{
			RefreshEditorList();
		}
	}
	
	public class ProjectInstance
	{
		public string directory;
		public ProjectListItem listItem;
	}
	
	public class EditorInstance
	{
		public string path;
		public EditorListItem listItem;
	}
}

[Serializable]
public class LiwProjectInfo
{
	// Token: 0x060003BE RID: 958 RVA: 0x00013204 File Offset: 0x00011404
	public LiwProjectInfo()
	{
		var random = new Random();
		this.levelID = random.Next(1, 9999999);
		this.authorID = random.Next(1, 9999999);
	}
	public string levelName = "Untitled";
	public string description;
	public string authorName;
	public string musicName = "Untitled";
	public string musicArtist = "Unknown";
	public string musicFile = "audio.ogg";
	public int levelID;
	public int authorID;
	public int levelVersion = 1;
	public string gameVersion = "Liw1.0";
}
