using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LineWorldsLauncher
{
	public partial class MainForm : Form
	{
		public Panel[] panels;
		public Panel[] projPanels;
		public int projPanelIndex;
		
		public List<ProjectInstance> instances = new List<ProjectInstance>();
		public List<EditorInstance> editorInstances = new List<EditorInstance>();
		
		public Preferences preferences = new Preferences();
		public void SavePreferences()
		{
			File.WriteAllText("preferences.json", JsonConvert.SerializeObject(preferences));
		}
		public MainForm()
		{
			InitializeComponent();
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			panels = new []{
				welcomePanel,
				projectsPanel
			};
			projPanels = new Panel[]{
				proj_projectListPanel,
				proj_editorListPanel,
				TutorialPanel
			};
			projPanelIndex = 0;
			MoveProjectTab(projPanelIndex);
			
			if(File.Exists("preferences.json"))
			{
				preferences = JsonConvert.DeserializeObject<Preferences>(File.ReadAllText("preferences.json"));
				foreach(var editor in preferences.editors)
				{
					if(File.Exists(editor.path))
					{
						ImportEditor(editor.path.Replace('/', '\\'));
					}
				}
				foreach(var project in preferences.projects)
				{
					if(Directory.Exists(project.path))
					{
						ImportProject(project.path.Replace('/', '\\'));
					}
				}
				MoveTab(1);
			}
			else
			{
				MoveTab(0);
			}
			Load += (sender, e) => RefreshProjectList();
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
			projPanelIndex = index;
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
		
		void Proj_tutorialsButtonClick(object sender, EventArgs e)
		{
			MoveProjectTab(2);
			proj_NewButton.Visible = false;
			proj_openButton.Visible = false;
		}
		
		void MainFormActivated(object sender, EventArgs e)
		{
			RefreshList();
		}
		
		void Proj_editorsButtonClick(object sender, EventArgs e)
		{
			MoveProjectTab(1);
			proj_NewButton.Text = "Install";
			proj_NewButton.Visible = true;
			proj_openButton.Visible = true;
		}
		
		void Proj_projectsButtonClick(object sender, EventArgs e)
		{
			MoveProjectTab(0);
			proj_NewButton.Text = "New";
			proj_NewButton.Visible = true;
			proj_openButton.Visible = true;
		}
		
		void Proj_openButtonClick(object sender, EventArgs e)
		{
			if(projPanelIndex == 0)
			{
				var dialog = new OpenFileDialog();
				dialog.RestoreDirectory = true;
				dialog.Filter = "Line Worlds Project (.liw)|*.liw|All files (*.*)|*.*";
				if(dialog.ShowDialog() == DialogResult.OK)
				{
					ImportProject(GoUpFolder(dialog.FileName).Replace('/', '\\'));
					//ImportEditor(dialog.FileName);
				}
			}
			else
			{
				var dialog = new OpenFileDialog();
				dialog.RestoreDirectory = true;
				dialog.Filter = "Executable file (.exe)|*.exe|All files (*.*)|*.*";
				if(dialog.ShowDialog() == DialogResult.OK)
				{
					ImportEditor(dialog.FileName.Replace('/', '\\'));
				}
			}
		}
		
		public void ImportEditor(string path)
		{
			if(!editorInstances.Exists(val => val.path.Replace('/', '\\') == path))
			{
				string editorDirectory = GoUpFolder(path);
				var projectsDirectory = Path.Combine(editorDirectory, "Projects");
				if(Directory.Exists(projectsDirectory))
				{
					GetProjectsFromFolder(projectsDirectory);
				}
				var inst = new EditorListItem(path);
				proj_editorListPanel.Controls.Add(inst);
				var i = new EditorInstance();
				i.path = path;
				i.listItem = inst;
				if(!preferences.editors.Exists(val => val.path == path))
				{
					preferences.editors.Add(
						new Preferences.Editor
						{
							name = inst.editorTitleLabel.Text,
							path = path
						}
					);
				}
				SavePreferences();
				editorInstances.Add(i);
				inst.removeButton.Click += (object sender, EventArgs e) => {
					var f = preferences.editors.Find(val => val.path == path);
					if(f != null)
					{
						preferences.editors.Remove(f);
						SavePreferences();
						inst.Dispose();
					}
				};
				RefreshEditorList();
			}
		}
		
		public void GetProjectsFromFolder(string directory)
		{
			foreach(var dir in Directory.GetDirectories(directory))
			{
				if(File.Exists(Path.Combine(dir, "ProjectInfo.liwf")))
				{
					ImportProject(dir);
				}
			}
		}
		
		public void ImportProject(string path)
		{
			if(!instances.Exists(val => val.directory.Replace('/', '\\') == path))
			{
				var inst = new ProjectListItem(path);
				proj_projectListPanel.Controls.Add(inst);
				var i = new ProjectInstance();
				inst.host = this;
				i.directory = path;
				i.listItem = inst;
				if(!preferences.projects.Exists(val => val.path == path))
				{
					preferences.projects.Add(
						new Preferences.Project()
						{
							name = inst.projectTitleLabel.Text,
							path = path
						}
					);
				}
				SavePreferences();
				instances.Add(i);
				RefreshProjectList();
			}
		}
		
		public void RefreshEditorList()
		{
			foreach(Control c in proj_editorListPanel.Controls)
			{
				c.Width = proj_editorListPanel.Width - 10;
			}
		}
		
		public void RefreshProjectList()
		{
			foreach(Control c in proj_projectListPanel.Controls)
			{
				c.Width = proj_projectListPanel.Width - 10;
			}
		}
		
		void Proj_editorListPanelResize(object sender, EventArgs e)
		{
			RefreshEditorList();
		}

	    public static string GoUpFolder(string dir)
	    {
			var e = dir.Split(new [] {'/', '\\'});
			var y = dir.Remove(dir.Length - e[e.Length - 1].Length, e[e.Length - 1].Length);
	        if(y.EndsWith("\\", StringComparison.CurrentCulture) || y.EndsWith("/", StringComparison.CurrentCulture))
	        {
	            y = y.Remove(y.Length - 1, 1);
	        }
			return y;
	    }
		void Proj_NewButtonClick(object sender, EventArgs e)
		{
			if(projPanelIndex == 0)
			{
				MessageBox.Show("You can only create new project from the editor for now", "Coming Soon");
			}
			else
			{
				var installDialog = new InstallForm(this);
				installDialog.Show();
			}
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
	
	public class Preferences
	{
		public List<Project> projects = new List<Project>();
		public List<Editor> editors = new List<Editor>();
		public class Project
		{
			public string name;
			public string path;
			public LiwProjectInfo info;
		}
		public class Editor
		{
			public string name;
			public string path;
		}
	}
}

public class ServerVersions
{
	public EditorVersion[] versions;
}

public class EditorVersion
{
	public string version;
	public string list;
}

public class DownloadFiles
{
	public string version;
	public ServerFile[] files;
}

public class ServerFile
{
	public string name;
	public string directory;
	public string link;
	public int size;
}
[Serializable]
public class LiwProjectInfo
{
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
