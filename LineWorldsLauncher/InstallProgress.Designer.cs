/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 8/27/2022
 * Time: 12:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LineWorldsLauncher
{
	partial class InstallProgress
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label FileNameLabel;
		public System.Windows.Forms.ProgressBar TrueProgressBar;
		public System.Windows.Forms.Label ProgressLabel;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.FileNameLabel = new System.Windows.Forms.Label();
			this.TrueProgressBar = new System.Windows.Forms.ProgressBar();
			this.ProgressLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// FileNameLabel
			// 
			this.FileNameLabel.Location = new System.Drawing.Point(13, 10);
			this.FileNameLabel.Name = "FileNameLabel";
			this.FileNameLabel.Size = new System.Drawing.Size(374, 23);
			this.FileNameLabel.TabIndex = 0;
			this.FileNameLabel.Text = "File Name";
			this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TrueProgressBar
			// 
			this.TrueProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.TrueProgressBar.Location = new System.Drawing.Point(170, 10);
			this.TrueProgressBar.Name = "TrueProgressBar";
			this.TrueProgressBar.Size = new System.Drawing.Size(339, 23);
			this.TrueProgressBar.TabIndex = 1;
			// 
			// ProgressLabel
			// 
			this.ProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgressLabel.Location = new System.Drawing.Point(515, 15);
			this.ProgressLabel.Name = "ProgressLabel";
			this.ProgressLabel.Size = new System.Drawing.Size(104, 11);
			this.ProgressLabel.TabIndex = 3;
			this.ProgressLabel.Text = "Waiting...";
			// 
			// InstallProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.Controls.Add(this.ProgressLabel);
			this.Controls.Add(this.TrueProgressBar);
			this.Controls.Add(this.FileNameLabel);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.Name = "InstallProgress";
			this.Size = new System.Drawing.Size(622, 42);
			this.Load += new System.EventHandler(this.InstallProgressLoad);
			this.ResumeLayout(false);

		}
	}
}
