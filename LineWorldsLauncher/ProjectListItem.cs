using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using YamlDotNet.Serialization;

namespace LineWorldsLauncher
{
	public partial class ProjectListItem : UserControl
	{
	    private static Deserializer m_yamlDeserializer;
	    public static Deserializer yamlDeserializer
	    {
	        get
	        {
	            if (m_yamlDeserializer == null) m_yamlDeserializer = new Deserializer();
	            return m_yamlDeserializer;
	        }
	        private set
	        {
	            m_yamlDeserializer = value;
	        }
	    }
	
	    private static Serializer m_yamlSerializer;
	    public static Serializer yamlSerializer
	    {
	        get
	        {
	            if (m_yamlSerializer == null) m_yamlSerializer = new Serializer();
	            return m_yamlSerializer;
	        }
	        private set
	        {
	            m_yamlSerializer = value;
	        }
    	}
	    public LiwProjectInfo projectInfo;
	    public string projectPath;
	    public MainForm host;
	    
		public ProjectListItem(string directory)
		{
			InitializeComponent();
			
			projectPath = directory;
			projectInfo = yamlDeserializer.Deserialize<LiwProjectInfo>(File.ReadAllText(Path.Combine(directory, "ProjectInfo.liwf")));
			
			projectTitleLabel.Text = projectInfo.levelName;
			projectPathLabel.Text = directory;
			projectOwnerLabel.Text = projectInfo.authorName;
		}
		
		public void ProjectListItemClick(object sender, EventArgs e)
		{
			if(Directory.Exists(projectPath))
			{
				if(projectInfo.gameVersion != "Liw1.0")
				{
					string projectVersion = projectInfo.gameVersion.Remove(0, 2);
					Console.WriteLine(projectVersion);
					var startInfo = new ProcessStartInfo();
					Console.WriteLine(projectInfo);
					var editor = host.preferences.editors.Find(val => val.name.Contains(projectVersion));
					if(editor != null)
					{
						if(File.Exists(editor.path))
						{
							startInfo.FileName = editor.path;
							startInfo.Arguments = "\"" + projectPath + "\"";
							Process.Start(startInfo);
							host.Hide();
						}
						else
						{
							host.preferences.editors.Remove(editor);
							host.SavePreferences();
							if(MessageBox.Show("(EDITOR MISSING) You don't have an editor version " + projectVersion + " to open this, do you want to open it with the latest version of the editor?", "Project Opener", MessageBoxButtons.YesNo) == DialogResult.Yes)
							{
								startInfo = new ProcessStartInfo();
								if(host.preferences.editors.Count <= 0) return;
								editor = host.preferences.editors[host.preferences.editors.Count - 1];
								if(editor != null)
								{
									startInfo.FileName = editor.path;
									startInfo.Arguments = "\"" + projectPath + "\"";
									Process.Start(startInfo);
									host.Hide();
								}
							}
						}
					}
					else
					{
						
						if(MessageBox.Show("You don't have an editor version " + projectVersion + " to open this, do you want to open it with the latest version of the editor?", "Project Opener", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							startInfo = new ProcessStartInfo();
							if(host.preferences.editors.Count <= 0) return;
							editor = host.preferences.editors[host.preferences.editors.Count - 1];
							if(editor != null)
							{
								startInfo.FileName = editor.path;
								startInfo.Arguments = "\"" + projectPath + "\"";
								Process.Start(startInfo);
								host.Hide();
							}
						}
					}
				}
				else
				{
					if(host.preferences.editors.Count > 0)
					{
						var startInfo = new ProcessStartInfo();
						var editor = host.preferences.editors[0];
						Console.WriteLine("is old game version");
						if(editor != null)
						{
							startInfo.FileName = editor.path;
							startInfo.Arguments = "\"" + projectPath + "\"";
							Process.Start(startInfo);
							host.Hide();
						}
					}
					else
					{
						if(MessageBox.Show("You don't have any editor to open this project, do you want to open it with the latest version of the editor?", "Project Opener", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							var startInfo = new ProcessStartInfo();
							if(host.preferences.editors.Count <= 0) return;
							var editor = host.preferences.editors[host.preferences.editors.Count - 1];
							if(editor != null)
							{
								startInfo.FileName = editor.path;
								startInfo.Arguments = "\"" + projectPath + "\"";
								Process.Start(startInfo);
								host.Hide();
							}
						}
					}
				}
			}
		}
		void OpenFolderButtonClick(object sender, EventArgs e)
		{
			if(Directory.Exists(projectPath))
			{
				Process.Start(projectPath);
			}
		}
	}
}
