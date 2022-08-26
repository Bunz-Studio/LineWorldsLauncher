﻿using System;
using System.IO;
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
			
			if(File.Exists("preferences.json"))
			{
				preferences = JsonConvert.DeserializeObject<Preferences>(File.ReadAllText("preferences.json"));
				foreach(var editor in preferences.editors)
				{
					ImportEditor(editor.path);
				}
			}
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
			if(projPanelIndex == 0)
			{
				var dialog = new OpenFileDialog();
				dialog.RestoreDirectory = true;
				dialog.Filter = "Executable file (.exe)|*.exe|All files (*.*)|*.*";
				if(dialog.ShowDialog() == DialogResult.OK)
				{
					ImportEditor(dialog.FileName);
				}
			}
			else
			{
				var dialog = new OpenFileDialog();
				dialog.RestoreDirectory = true;
				dialog.Filter = "Executable file (.exe)|*.exe|All files (*.*)|*.*";
				if(dialog.ShowDialog() == DialogResult.OK)
				{
					ImportEditor(dialog.FileName);
				}
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
				preferences.editors.Add(
					new Preferences.Editor()
					{
						name = inst.editorTitleLabel.Text,
						path = path
					}
				);
				SavePreferences();
				editorInstances.Add(i);
				RefreshEditorList();
			}
		}
		
		
		public void ImportProject(string path)
		{
			if(!instances.Exists(val => val.directory == path))
			{
				var inst = new ProjectListItem(path);
				proj_projectListPanel.Controls.Add(inst);
				var i = new ProjectInstance();
				i.directory = path;
				i.listItem = inst;
				preferences.projects.Add(
					new Preferences.Project()
					{
						name = inst.projectTitleLabel.Text,
						path = path
					}
				);
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
