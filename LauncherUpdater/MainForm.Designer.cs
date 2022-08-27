/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 8/27/2022
 * Time: 6:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LauncherUpdater
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button mainButton;
		private System.Windows.Forms.Label mainLabel;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label progressLabel;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.mainButton = new System.Windows.Forms.Button();
			this.mainLabel = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.progressLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mainButton
			// 
			this.mainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainButton.Location = new System.Drawing.Point(286, 92);
			this.mainButton.Name = "mainButton";
			this.mainButton.Size = new System.Drawing.Size(73, 23);
			this.mainButton.TabIndex = 0;
			this.mainButton.Text = "Update";
			this.mainButton.UseVisualStyleBackColor = true;
			this.mainButton.Click += new System.EventHandler(this.MainButtonClick);
			// 
			// mainLabel
			// 
			this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.mainLabel.Location = new System.Drawing.Point(12, 14);
			this.mainLabel.Name = "mainLabel";
			this.mainLabel.Size = new System.Drawing.Size(347, 23);
			this.mainLabel.TabIndex = 1;
			this.mainLabel.Text = "Line Worlds Launcher Updater";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 40);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(347, 23);
			this.progressBar.TabIndex = 2;
			// 
			// progressLabel
			// 
			this.progressLabel.Location = new System.Drawing.Point(12, 66);
			this.progressLabel.Name = "progressLabel";
			this.progressLabel.Size = new System.Drawing.Size(347, 23);
			this.progressLabel.TabIndex = 3;
			this.progressLabel.Text = "Progress Information";
			this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.ClientSize = new System.Drawing.Size(371, 123);
			this.Controls.Add(this.progressLabel);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.mainLabel);
			this.Controls.Add(this.mainButton);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.Text = "Launcher Updater";
			this.ResumeLayout(false);

		}
	}
}
