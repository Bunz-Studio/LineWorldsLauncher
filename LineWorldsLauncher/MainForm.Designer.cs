/*
 * Created by SharpDevelop.
 * User: Bunzhi
 * Date: 24/08/2022
 * Time: 22:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LineWorldsLauncher
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button welc_goButton;
		private System.Windows.Forms.Label welc_titleLabel;
		private System.Windows.Forms.Label welc_descriptionLabel;
		private System.Windows.Forms.Panel welcomePanel;
		private System.Windows.Forms.Panel projectsPanel;
		private System.Windows.Forms.Label proj_titleLabel;
		private System.Windows.Forms.Button proj_NewButton;
		private System.Windows.Forms.Button proj_openButton;
		private System.Windows.Forms.FlowLayoutPanel proj_projectListPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button proj_projectsButton;
		private System.Windows.Forms.Button proj_editorsButton;
		private System.Windows.Forms.Button proj_tutorialsButton;
		private System.Windows.Forms.FlowLayoutPanel proj_editorListPanel;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.welc_goButton = new System.Windows.Forms.Button();
			this.welc_titleLabel = new System.Windows.Forms.Label();
			this.welc_descriptionLabel = new System.Windows.Forms.Label();
			this.welcomePanel = new System.Windows.Forms.Panel();
			this.projectsPanel = new System.Windows.Forms.Panel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.proj_projectsButton = new System.Windows.Forms.Button();
			this.proj_editorsButton = new System.Windows.Forms.Button();
			this.proj_tutorialsButton = new System.Windows.Forms.Button();
			this.proj_NewButton = new System.Windows.Forms.Button();
			this.proj_openButton = new System.Windows.Forms.Button();
			this.proj_titleLabel = new System.Windows.Forms.Label();
			this.proj_editorListPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.proj_projectListPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.welcomePanel.SuspendLayout();
			this.projectsPanel.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// welc_goButton
			// 
			this.welc_goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.welc_goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.welc_goButton.Location = new System.Drawing.Point(670, 400);
			this.welc_goButton.Name = "welc_goButton";
			this.welc_goButton.Size = new System.Drawing.Size(64, 23);
			this.welc_goButton.TabIndex = 0;
			this.welc_goButton.Text = "Go";
			this.welc_goButton.UseVisualStyleBackColor = true;
			this.welc_goButton.Click += new System.EventHandler(this.Welc_goButtonClick);
			// 
			// welc_titleLabel
			// 
			this.welc_titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
			this.welc_titleLabel.Location = new System.Drawing.Point(12, 14);
			this.welc_titleLabel.Name = "welc_titleLabel";
			this.welc_titleLabel.Size = new System.Drawing.Size(440, 35);
			this.welc_titleLabel.TabIndex = 1;
			this.welc_titleLabel.Text = "Welcome to Line Worlds!";
			// 
			// welc_descriptionLabel
			// 
			this.welc_descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.welc_descriptionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.welc_descriptionLabel.Location = new System.Drawing.Point(16, 49);
			this.welc_descriptionLabel.Name = "welc_descriptionLabel";
			this.welc_descriptionLabel.Size = new System.Drawing.Size(718, 337);
			this.welc_descriptionLabel.TabIndex = 2;
			this.welc_descriptionLabel.Text = resources.GetString("welc_descriptionLabel.Text");
			// 
			// welcomePanel
			// 
			this.welcomePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.welcomePanel.Controls.Add(this.welc_descriptionLabel);
			this.welcomePanel.Controls.Add(this.welc_goButton);
			this.welcomePanel.Controls.Add(this.welc_titleLabel);
			this.welcomePanel.Location = new System.Drawing.Point(0, 0);
			this.welcomePanel.Name = "welcomePanel";
			this.welcomePanel.Size = new System.Drawing.Size(748, 438);
			this.welcomePanel.TabIndex = 3;
			// 
			// projectsPanel
			// 
			this.projectsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.projectsPanel.Controls.Add(this.flowLayoutPanel1);
			this.projectsPanel.Controls.Add(this.proj_NewButton);
			this.projectsPanel.Controls.Add(this.proj_openButton);
			this.projectsPanel.Controls.Add(this.proj_titleLabel);
			this.projectsPanel.Controls.Add(this.proj_projectListPanel);
			this.projectsPanel.Controls.Add(this.proj_editorListPanel);
			this.projectsPanel.Location = new System.Drawing.Point(0, 0);
			this.projectsPanel.Name = "projectsPanel";
			this.projectsPanel.Size = new System.Drawing.Size(748, 438);
			this.projectsPanel.TabIndex = 4;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.Controls.Add(this.proj_projectsButton);
			this.flowLayoutPanel1.Controls.Add(this.proj_editorsButton);
			this.flowLayoutPanel1.Controls.Add(this.proj_tutorialsButton);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 49);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(109, 364);
			this.flowLayoutPanel1.TabIndex = 4;
			this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1Paint);
			// 
			// proj_projectsButton
			// 
			this.proj_projectsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.proj_projectsButton.Location = new System.Drawing.Point(3, 3);
			this.proj_projectsButton.Name = "proj_projectsButton";
			this.proj_projectsButton.Size = new System.Drawing.Size(102, 23);
			this.proj_projectsButton.TabIndex = 0;
			this.proj_projectsButton.Text = "Projects";
			this.proj_projectsButton.UseVisualStyleBackColor = true;
			this.proj_projectsButton.Click += new System.EventHandler(this.Proj_projectsButtonClick);
			// 
			// proj_editorsButton
			// 
			this.proj_editorsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.proj_editorsButton.Location = new System.Drawing.Point(3, 32);
			this.proj_editorsButton.Name = "proj_editorsButton";
			this.proj_editorsButton.Size = new System.Drawing.Size(102, 23);
			this.proj_editorsButton.TabIndex = 1;
			this.proj_editorsButton.Text = "Editors";
			this.proj_editorsButton.UseVisualStyleBackColor = true;
			this.proj_editorsButton.Click += new System.EventHandler(this.Proj_editorsButtonClick);
			// 
			// proj_tutorialsButton
			// 
			this.proj_tutorialsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.proj_tutorialsButton.Location = new System.Drawing.Point(3, 61);
			this.proj_tutorialsButton.Name = "proj_tutorialsButton";
			this.proj_tutorialsButton.Size = new System.Drawing.Size(102, 23);
			this.proj_tutorialsButton.TabIndex = 2;
			this.proj_tutorialsButton.Text = "Tutorials";
			this.proj_tutorialsButton.UseVisualStyleBackColor = true;
			// 
			// proj_NewButton
			// 
			this.proj_NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.proj_NewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.proj_NewButton.Location = new System.Drawing.Point(671, 19);
			this.proj_NewButton.Name = "proj_NewButton";
			this.proj_NewButton.Size = new System.Drawing.Size(64, 23);
			this.proj_NewButton.TabIndex = 2;
			this.proj_NewButton.Text = "New";
			this.proj_NewButton.UseVisualStyleBackColor = true;
			// 
			// proj_openButton
			// 
			this.proj_openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.proj_openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.proj_openButton.Location = new System.Drawing.Point(601, 19);
			this.proj_openButton.Name = "proj_openButton";
			this.proj_openButton.Size = new System.Drawing.Size(64, 23);
			this.proj_openButton.TabIndex = 0;
			this.proj_openButton.Text = "Open";
			this.proj_openButton.UseVisualStyleBackColor = true;
			this.proj_openButton.Click += new System.EventHandler(this.Proj_openButtonClick);
			// 
			// proj_titleLabel
			// 
			this.proj_titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
			this.proj_titleLabel.Location = new System.Drawing.Point(12, 14);
			this.proj_titleLabel.Name = "proj_titleLabel";
			this.proj_titleLabel.Size = new System.Drawing.Size(446, 35);
			this.proj_titleLabel.TabIndex = 1;
			this.proj_titleLabel.Text = "Line Worlds Projects";
			// 
			// proj_editorListPanel
			// 
			this.proj_editorListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.proj_editorListPanel.AutoScroll = true;
			this.proj_editorListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.proj_editorListPanel.Location = new System.Drawing.Point(131, 49);
			this.proj_editorListPanel.Name = "proj_editorListPanel";
			this.proj_editorListPanel.Size = new System.Drawing.Size(604, 364);
			this.proj_editorListPanel.TabIndex = 5;
			this.proj_editorListPanel.Resize += new System.EventHandler(this.Proj_editorListPanelResize);
			// 
			// proj_projectListPanel
			// 
			this.proj_projectListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.proj_projectListPanel.AutoScroll = true;
			this.proj_projectListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.proj_projectListPanel.Location = new System.Drawing.Point(131, 49);
			this.proj_projectListPanel.Name = "proj_projectListPanel";
			this.proj_projectListPanel.Size = new System.Drawing.Size(604, 364);
			this.proj_projectListPanel.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.ClientSize = new System.Drawing.Size(747, 437);
			this.Controls.Add(this.projectsPanel);
			this.Controls.Add(this.welcomePanel);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Line Worlds Launcher";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Activated += new System.EventHandler(this.MainFormActivated);
			this.welcomePanel.ResumeLayout(false);
			this.projectsPanel.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
