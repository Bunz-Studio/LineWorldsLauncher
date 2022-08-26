/*
 * Created by SharpDevelop.
 * User: Bunzhi
 * Date: 24/08/2022
 * Time: 22:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LineWorldsLauncher
{
	partial class ProjectListItem
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label projectTitleLabel;
		private System.Windows.Forms.Label projectPathLabel;
		private System.Windows.Forms.Label projectOwnerLabel;
		
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
			this.projectTitleLabel = new System.Windows.Forms.Label();
			this.projectPathLabel = new System.Windows.Forms.Label();
			this.projectOwnerLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// projectTitleLabel
			// 
			this.projectTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.projectTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
			this.projectTitleLabel.Location = new System.Drawing.Point(12, 15);
			this.projectTitleLabel.Name = "projectTitleLabel";
			this.projectTitleLabel.Size = new System.Drawing.Size(494, 23);
			this.projectTitleLabel.TabIndex = 0;
			this.projectTitleLabel.Text = "ProjectName";
			// 
			// projectPathLabel
			// 
			this.projectPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.projectPathLabel.Location = new System.Drawing.Point(14, 39);
			this.projectPathLabel.Name = "projectPathLabel";
			this.projectPathLabel.Size = new System.Drawing.Size(492, 23);
			this.projectPathLabel.TabIndex = 1;
			this.projectPathLabel.Text = "C:/ProjectPath/";
			// 
			// projectOwnerLabel
			// 
			this.projectOwnerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.projectOwnerLabel.Location = new System.Drawing.Point(367, 9);
			this.projectOwnerLabel.Name = "projectOwnerLabel";
			this.projectOwnerLabel.Size = new System.Drawing.Size(151, 31);
			this.projectOwnerLabel.TabIndex = 2;
			this.projectOwnerLabel.Text = "ProjectOwner";
			this.projectOwnerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ProjectListItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.Controls.Add(this.projectOwnerLabel);
			this.Controls.Add(this.projectPathLabel);
			this.Controls.Add(this.projectTitleLabel);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.Name = "ProjectListItem";
			this.Size = new System.Drawing.Size(526, 69);
			this.ResumeLayout(false);

		}
	}
}
