/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 8/27/2022
 * Time: 11:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LineWorldsLauncher
{
	partial class InstallForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel EditorsPanel;
		private System.Windows.Forms.Label editorListLabel;
		private System.Windows.Forms.FlowLayoutPanel editorsList;
		private System.Windows.Forms.Panel filesPanel;
		private System.Windows.Forms.FlowLayoutPanel filesList;
		private System.Windows.Forms.Label filesLabel;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.Panel InstallPanel;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.FlowLayoutPanel InstallList;
		private System.Windows.Forms.Label InstallLabel;
		private System.Windows.Forms.Button button1;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallForm));
			this.EditorsPanel = new System.Windows.Forms.Panel();
			this.editorsList = new System.Windows.Forms.FlowLayoutPanel();
			this.editorListLabel = new System.Windows.Forms.Label();
			this.filesPanel = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.filesList = new System.Windows.Forms.FlowLayoutPanel();
			this.filesLabel = new System.Windows.Forms.Label();
			this.InstallPanel = new System.Windows.Forms.Panel();
			this.CancelButton = new System.Windows.Forms.Button();
			this.InstallList = new System.Windows.Forms.FlowLayoutPanel();
			this.InstallLabel = new System.Windows.Forms.Label();
			this.EditorsPanel.SuspendLayout();
			this.filesPanel.SuspendLayout();
			this.InstallPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// EditorsPanel
			// 
			this.EditorsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.EditorsPanel.Controls.Add(this.editorsList);
			this.EditorsPanel.Controls.Add(this.editorListLabel);
			this.EditorsPanel.Location = new System.Drawing.Point(0, 0);
			this.EditorsPanel.Name = "EditorsPanel";
			this.EditorsPanel.Size = new System.Drawing.Size(682, 416);
			this.EditorsPanel.TabIndex = 1;
			// 
			// editorsList
			// 
			this.editorsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.editorsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.editorsList.Location = new System.Drawing.Point(12, 55);
			this.editorsList.Name = "editorsList";
			this.editorsList.Size = new System.Drawing.Size(657, 348);
			this.editorsList.TabIndex = 1;
			// 
			// editorListLabel
			// 
			this.editorListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.editorListLabel.Location = new System.Drawing.Point(12, 18);
			this.editorListLabel.Name = "editorListLabel";
			this.editorListLabel.Size = new System.Drawing.Size(274, 23);
			this.editorListLabel.TabIndex = 0;
			this.editorListLabel.Text = "Select the editor version";
			// 
			// filesPanel
			// 
			this.filesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.filesPanel.Controls.Add(this.button1);
			this.filesPanel.Controls.Add(this.backButton);
			this.filesPanel.Controls.Add(this.filesList);
			this.filesPanel.Controls.Add(this.filesLabel);
			this.filesPanel.Location = new System.Drawing.Point(0, 0);
			this.filesPanel.Name = "filesPanel";
			this.filesPanel.Size = new System.Drawing.Size(682, 416);
			this.filesPanel.TabIndex = 2;
			this.filesPanel.Visible = false;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(607, 380);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(62, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Install";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.InstallButtonClick);
			// 
			// backButton
			// 
			this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.backButton.Location = new System.Drawing.Point(594, 18);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 2;
			this.backButton.Text = "Back";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.BackButtonClick);
			// 
			// filesList
			// 
			this.filesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.filesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.filesList.Location = new System.Drawing.Point(12, 55);
			this.filesList.Name = "filesList";
			this.filesList.Size = new System.Drawing.Size(657, 319);
			this.filesList.TabIndex = 1;
			// 
			// filesLabel
			// 
			this.filesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.filesLabel.Location = new System.Drawing.Point(12, 18);
			this.filesLabel.Name = "filesLabel";
			this.filesLabel.Size = new System.Drawing.Size(274, 23);
			this.filesLabel.TabIndex = 0;
			this.filesLabel.Text = "Select what you need";
			// 
			// InstallPanel
			// 
			this.InstallPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.InstallPanel.Controls.Add(this.CancelButton);
			this.InstallPanel.Controls.Add(this.InstallList);
			this.InstallPanel.Controls.Add(this.InstallLabel);
			this.InstallPanel.Location = new System.Drawing.Point(0, 0);
			this.InstallPanel.Name = "InstallPanel";
			this.InstallPanel.Size = new System.Drawing.Size(682, 416);
			this.InstallPanel.TabIndex = 3;
			this.InstallPanel.Visible = false;
			// 
			// CancelButton
			// 
			this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CancelButton.Location = new System.Drawing.Point(594, 18);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 2;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// InstallList
			// 
			this.InstallList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.InstallList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.InstallList.Location = new System.Drawing.Point(12, 55);
			this.InstallList.Name = "InstallList";
			this.InstallList.Size = new System.Drawing.Size(657, 348);
			this.InstallList.TabIndex = 1;
			// 
			// InstallLabel
			// 
			this.InstallLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.InstallLabel.Location = new System.Drawing.Point(12, 18);
			this.InstallLabel.Name = "InstallLabel";
			this.InstallLabel.Size = new System.Drawing.Size(274, 23);
			this.InstallLabel.TabIndex = 0;
			this.InstallLabel.Text = "Installing the Editor";
			// 
			// InstallForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.ClientSize = new System.Drawing.Size(681, 415);
			this.Controls.Add(this.InstallPanel);
			this.Controls.Add(this.filesPanel);
			this.Controls.Add(this.EditorsPanel);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "InstallForm";
			this.Text = "Install Editor";
			this.EditorsPanel.ResumeLayout(false);
			this.filesPanel.ResumeLayout(false);
			this.InstallPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
