using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using Ionic.Zip;

namespace LauncherUpdater
{
	public partial class MainForm : Form
	{
		public UpdateInfo info;
		public UpdaterMode mode = UpdaterMode.Idle;
		public enum UpdaterMode
		{
			Idle,
			NoExist,
			Updating,
			Finish
		}
		public MainForm()
		{
			InitializeComponent();
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			
			if(File.Exists("UpdateInfo.json"))
			{
				var data = File.ReadAllText("UpdateInfo.json");
				info = JsonConvert.DeserializeObject<UpdateInfo>(data);
				mode = UpdaterMode.Idle;
				progressLabel.Text = "Ready to update";
			}
			else
			{
				progressLabel.Text = "Any update queue isn't found";
				mainButton.Text = "Close";
				mode = UpdaterMode.NoExist;
			}
		}
		
		void MainButtonClick(object sender, EventArgs e)
		{
			if(mode == UpdaterMode.Idle)
			{
				progressLabel.Text = "Updating launcher...";
				mainButton.Text = "Cancel";
				mainButton.Enabled = false;
				mode = UpdaterMode.Updating;
				DownloadFile(0);
			}
			else
			{
				Dispose();
			}
		}
		
		public void DownloadFile(int index)
		{
			CheckDirectory("Cache");
			const string path = "Cache/updateArchive.zip";
			var updateQueue = new UpdateQueue();
			updateQueue.file = info.files[index];
			updateQueue.client = new WebClient();
			updateQueue.client.DownloadProgressChanged += (sender, e) => {
				progressBar.Value = (int)(e.ProgressPercentage / info.files.Count) + (index * 100);
				progressLabel.Text = "Downloading: " + updateQueue.file.link + " | " + GetBytesString(e.BytesReceived) + "/" + GetBytesString(e.TotalBytesToReceive);
			};
			updateQueue.client.DownloadFileCompleted += (sender, e) => 
			{
				if(e.Error != null)
				{
					MessageBox.Show("Failed to download: " + updateQueue.file.link, "Updater");
				}
				else
				{
					using(var zip = ZipFile.Read(path))
					{
						foreach(var entry in zip.Entries)
						{
							if(File.Exists(entry.FileName))
							{
								File.Delete(entry.FileName);
								entry.Extract(string.IsNullOrWhiteSpace(updateQueue.file.directory) ? AppDomain.CurrentDomain.BaseDirectory : updateQueue.file.directory);
							}
						}
					}
				}
				index++;
				if(index >= info.files.Count)
				{
					progressLabel.Text = "Finished updating launcher!";
					mainButton.Text = "Close";
					mode = UpdaterMode.Finish;
					mainButton.Enabled = true;
				}
				else
				{
					DownloadFile(index);
				}
			};
			updateQueue.client.DownloadFileAsync(new Uri(updateQueue.file.link), path);
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
			return String.Format("{0:0.##} {1}", len, sizes[order]);
		}
		public void CheckDirectory(string path)
		{
			if(!Directory.Exists(path)) Directory.CreateDirectory(path);
		}
	}
	
	public class UpdateQueue
	{
		public WebClient client;
		public FileUpdate file;
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
}
