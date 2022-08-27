/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 8/27/2022
 * Time: 6:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LineWorldsLauncher
{
	partial class TutorialListItem
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label chapterLabel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Button mainButton;
		
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
			this.chapterLabel = new System.Windows.Forms.Label();
			this.titleLabel = new System.Windows.Forms.Label();
			this.mainButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// chapterLabel
			// 
			this.chapterLabel.Location = new System.Drawing.Point(9, 9);
			this.chapterLabel.Name = "chapterLabel";
			this.chapterLabel.Size = new System.Drawing.Size(114, 23);
			this.chapterLabel.TabIndex = 0;
			this.chapterLabel.Text = "Chapter 1";
			// 
			// titleLabel
			// 
			this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
			this.titleLabel.Location = new System.Drawing.Point(6, 24);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(491, 23);
			this.titleLabel.TabIndex = 1;
			this.titleLabel.Text = "Setting Up";
			// 
			// mainButton
			// 
			this.mainButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.mainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainButton.Location = new System.Drawing.Point(431, 17);
			this.mainButton.Name = "mainButton";
			this.mainButton.Size = new System.Drawing.Size(75, 23);
			this.mainButton.TabIndex = 2;
			this.mainButton.Text = "Watch";
			this.mainButton.UseVisualStyleBackColor = true;
			this.mainButton.Click += new System.EventHandler(this.MainButtonClick);
			// 
			// TutorialListItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.Controls.Add(this.mainButton);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.chapterLabel);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.Name = "TutorialListItem";
			this.Size = new System.Drawing.Size(520, 57);
			this.Load += new System.EventHandler(this.TutorialListItemLoad);
			this.ResumeLayout(false);

		}
	}
}
