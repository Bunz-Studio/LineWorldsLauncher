using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Principal;
using Newtonsoft.Json;

namespace LineWorldsLauncher
{
	public partial class MainForm : Form
	{
		public Panel[] panels;
		public Panel[] projPanels;
		public int projPanelIndex;
		public const float version = 1.3f;
		
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
	        if (!RunningAsAdmin())
	        {
	        	MessageBox.Show("Program is not running as admin, some stuff might break", "Launcher");
	        }
	        
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			panels = new []{
				welcomePanel,
				projectsPanel
			};
			projPanels = new Panel[]{
				proj_projectListPanel,
				proj_editorListPanel,
				proj_tutorialListPanel
			};
			projPanelIndex = 0;
			MoveProjectTab(projPanelIndex);
			
			try
			{
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
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message + e.StackTrace, "Launcher Error");
			}
				
			var client = new WebClient();
			client.DownloadStringCompleted += (sender, e) => {
				if(e.Error != null)
				{
					MessageBox.Show("Failed to check launcher update", "Updater");
				}
				else
				{
					var data = e.Result;
					var info = JsonConvert.DeserializeObject<UpdateInfo>(data);
					if(info.version > version)
					{
						if(MessageBox.Show("There's a new version of the launcher, do you want to download it?", "Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
						{
							File.WriteAllText("UpdateInfo.json", data);
							Process.Start("LauncherUpdater.exe");
							canExit = true;
							Dispose();
							Application.Exit();
						}
					}
				}
			};
			client.DownloadStringAsync(new Uri(InstallForm.mainLink + "/download/launcher.json"));
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
		
		int reloadAttempt;
		bool startupLoad;
		void Proj_tutorialsButtonClick(object sender, EventArgs e)
		{
			MoveProjectTab(2);
			proj_NewButton.Visible = false;
			proj_openButton.Visible = false;
			proj_titleLabel.Text = "Line Worlds Tutorials";
			proj_tutorialListPanel.Visible = true;
			
			reloadAttempt++;
			if(reloadAttempt > 2 || !startupLoad)
				reloadAttempt = 0;
			else
				return;
			
			startupLoad = true;
			var client = new WebClient();
			var data = client.DownloadString(InstallForm.mainLink + "/tutorials.json");
			var info = JsonConvert.DeserializeObject<ServerTutorials>(data);
			proj_tutorialListPanel.Controls.Clear();
			foreach(var tutorial in info.tutorials)
			{
				var item = new TutorialListItem(tutorial);
				proj_tutorialListPanel.Controls.Add(item);
			}
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
			proj_titleLabel.Text = "Line Worlds Editors";
		}
		
		void Proj_projectsButtonClick(object sender, EventArgs e)
		{
			MoveProjectTab(0);
			proj_NewButton.Text = "New";
			proj_NewButton.Visible = true;
			proj_openButton.Visible = true;
			proj_titleLabel.Text = "Line Worlds Projects";
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
		bool canExit;
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			Show();
		}
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			canExit = true;
			Dispose();
			Application.Exit();
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(!canExit)
			{
				e.Cancel = true;
				Hide();
			}
			else
			{
				trayIcon.Dispose();
			}
		}
		void TrayIconMouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				Show();
			}
		}
		
	    private static bool RunningAsAdmin() 
	    {
	        WindowsIdentity id = WindowsIdentity.GetCurrent();
	        var principal = new WindowsPrincipal(id);
	
	        return principal.IsInRole(WindowsBuiltInRole.Administrator);
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
	
public class UpdateInfo
{
	public float version;
	public List<FileUpdate> files = new List<FileUpdate>();
}

public class FileUpdate
{
	public string directory;
	public string link;
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
