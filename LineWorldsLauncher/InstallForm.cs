using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using Ionic.Zip;

namespace LineWorldsLauncher
{
	public partial class InstallForm : Form
	{
		public const string mainLink = "https://raw.githubusercontent.com/Bunz-Studio/LineWorldsLauncher/main/Server";
		public List<ServerFile> selectedFiles = new List<ServerFile>();
		public List<InstallQueue> queue = new List<InstallQueue>();
		public string version;
		public bool finishInstall;
		
		public MainForm host;
		public InstallForm(MainForm host)
		{
			InitializeComponent();
			this.host = host;
			Load += (senderee, eee) => 
			{
				using(var client = new WebClient())
				{
					var str = client.DownloadString(mainLink + "/versions.json");
					var versions = JsonConvert.DeserializeObject<ServerVersions>(str);
					foreach(var ver in versions.versions)
					{
						string name = "Line Worlds " + ver.version;
						if(!host.editorInstances.Exists(val => val.listItem.editorTitleLabel.Text == name))
						{
							var item = new FlowLayoutItem();
							item.MainTitle.Text = "Line Worlds " + ver.version;
							item.MouseDown += (sender, e) => {
								filesPanel.Visible = true;
								EditorsPanel.Visible = false;
								PrepareList(ver.list);
								version = ver.version;
							};
							editorsList.Controls.Add(item);
						}
					}
				}
			};
		}
		
		public void PrepareList(string url)
		{
			selectedFiles.Clear();
			filesList.Controls.Clear();
			using(var client = new WebClient())
			{
				var str = client.DownloadString(url);
				var versions = JsonConvert.DeserializeObject<DownloadFiles>(str);
				foreach(var file in versions.files)
				{
					var item = new FlowLayoutItem();
					item.MainTitle.Text = file.name;
					item.SecondaryLabel.Text = GetBytesString(file.size * 1024);
					if(file.name == "Line Worlds")
					{
						selectedFiles.Add(file);
						item.BackColor = Color.FromArgb(255, 0, 50, 50);
					}
					else
					{
						item.MouseDown += (sender, e) => {
							if(item.BackColor.G == 50)
							{
								item.BackColor = Color.FromArgb(255, 0, 30, 30);
								selectedFiles.Remove(file);
							}
							else
							{
								item.BackColor = Color.FromArgb(255, 0, 50, 50);
								selectedFiles.Add(file);
							}
						};
					}
					filesList.Controls.Add(item);
				}
			}
		}
		void BackButtonClick(object sender, EventArgs e)
		{
			filesPanel.Visible = false;
			EditorsPanel.Visible = true;
		}
		
		public string GetBytesString(int size)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			double len = (double)size;
			int order = 0;
			while (len >= 1024 && order < sizes.Length - 1) {
			    order++;
			    len = len/1024;
			}
			
			// Adjust the format string to your preferences. For example "{0:0.#}{1}" would
			// show a single decimal place, and no space.
			return String.Format("{0:0.##} {1}", len, sizes[order]);
		}
		
		public string GetBytesString(long size)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			double len = (double)size;
			int order = 0;
			while (len >= 1024 && order < sizes.Length - 1) {
			    order++;
			    len = len/1024;
			}
			
			// Adjust the format string to your preferences. For example "{0:0.#}{1}" would
			// show a single decimal place, and no space.
			return String.Format("{0:0.##} {1}", len, sizes[order]);
		}
		
		void InstallButtonClick(object sender, EventArgs e)
		{
			filesPanel.Visible = false;
			InstallPanel.Visible = true;
			
			CheckDirectory("Editor".CorrectPath());
			CheckDirectory(("Editor/" + version).CorrectPath());
			CheckDirectory("Cache".CorrectPath());
			int i = 0;
			int index = 0;
			foreach(var sel in selectedFiles)
			{
				var cls = new InstallQueue();
				var client = new WebClient();
				var item = new InstallProgress();
				cls.file = sel;
				cls.prog = item;
				cls.client = client;
				item.FileNameLabel.Text = sel.name;
				client.DownloadProgressChanged += (s, ev) => 
				{
					item.TrueProgressBar.Value = ev.ProgressPercentage;
					item.ProgressLabel.Text = GetBytesString(ev.BytesReceived) + "/" + GetBytesString(ev.TotalBytesToReceive);
				};
				client.DownloadFileCompleted += (sendesr, es) => 
				{
					if(es.Error != null)
					{
						MessageBox.Show(es.Error.Message + es.Error.Source, "Error downloading file");
						cls.isFailed = true;
						item.ProgressLabel.Text = "Failed";
					}
					else
					{
						using(ZipFile zip = ZipFile.Read(("Cache/" + sel.name + version).CorrectPath()))
						{
							zip.ExtractAll(("Editor/" + version + "/").CorrectPath());
						}
						item.ProgressLabel.Text = "Installed";
					}
					cls.isCompleted = true;
					i++;
					if(i >= selectedFiles.Count)
					{
						CancelButton.Text = "Finish";
						finishInstall = true;
						if(File.Exists(("Editor/" + version + "/LineWorlds.exe").CorrectPath()))
						{
							host.ImportEditor(("Editor/" + version + "/LineWorlds.exe").CorrectPath());
						}
					}
					else
					{
						index++;
						DownloadFile(index);
					}
				};
				InstallList.Controls.Add(item);
				queue.Add(cls);
			}
			DownloadFile(index);
		}
		public void DownloadFile(int index)
		{
			queue[index].client.DownloadFileAsync(new Uri(queue[index].file.link), ("Cache/" + queue[index].file.name + version).CorrectPath());
		}
		
		public void CheckDirectory(string path)
		{
			if(!Directory.Exists(path)) Directory.CreateDirectory(path);
		}
		
		void CancelButtonClick(object sender, EventArgs e)
		{
			if(!finishInstall)
			{
				foreach(var que in queue)
				{
					que.client.CancelAsync();
					que.prog.ProgressLabel.Text = "Cancelled";
					que.client.Dispose();
				}
			}
			Dispose();
		}
		
		public class InstallQueue
		{
			public bool isFailed;
			public bool isCompleted;
			public WebClient client;
			public InstallProgress prog;
			public ServerFile file;
		}
	}
}
